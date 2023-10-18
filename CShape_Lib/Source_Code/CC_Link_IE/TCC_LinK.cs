using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace WindowsFormsApplication1
{
    public enum DivType
    {
        //資料參考sh081035engn.pdf 52頁
        //目前先列常用的
        X = 1,      //Bit
        Y = 2,      //Bit
        L = 3,      //Bit
        M = 4,      //Bit
        SM = 5,     //Bit
        D = 13,     //Word
        B = 23,     //Bit
        W = 24     //Word
    };

    public class TJJS_CC_Link
    {
        public int Handle = 0;       //連結的通道Channel 程式參數叫path
        public int Netno = 1;
        public TCC_Link_Station Station1 = new TCC_Link_Station();
        public TCC_Link_Station Station2 = new TCC_Link_Station();

        public bool[] Station1_LB = new bool[0x400];
        public ushort[] Station1_LW = new ushort[0x1000];
        public bool[] Station2_LB = new bool[0x400];
        public ushort[] Station2_LW = new ushort[0x1000];

        public TJJS_CC_Link()
        {
            Station1.LB_Start_No = 0x400;//0x000;
            Station1.LB_Count = 0x400;
            Station1.LW_Start_No = 0x1000;// 0x000;
            Station1.LW_Count = 0x1000;

            Station2.LB_Start_No = 0x400;
            Station2.LB_Count = 0x400;
            Station2.LW_Start_No = 0x1000;
            Station2.LW_Count = 0x1000;
        }
        public void Connect()
        {
           int ErrorCode;

           if ((ErrorCode = CC_LinK_IE_Dll.mdOpen(151, 0, ref Handle)) == 0) //中間參數0為Mode尚未有詳細說明,須注意
           {
               Station1.Handle = Handle;
               Station2.Handle = Handle;

               Station1.Read_LB();
               Station1.Read_LW();
               Station1_LB = (bool[])Station1.LB.Clone();
               Station1_LW = (ushort[])Station1.LW.Clone();
           };
        }
        public void Reslash()
        {
            Station1.LB = (bool[])Station1_LB.Clone();  //直接存取會照成記憶體錯誤,加Clone鏡像為了不要是指標傳遞,究還是會發生記憶體存取錯誤。
            Station1.LW = (ushort[])Station1_LW.Clone();
            Station1.Write_LB();
            Station1.Write_LW();
            Station2.Read_LB();
            Station2.Read_LW();
            Station2_LB = (bool[])Station2.LB.Clone();
            Station2_LW = (ushort[])Station2.LW.Clone();
        }
     }

    public class TCC_Link_Station
    {
        public int Handle = 0;       
        public bool[] LB = new bool[0x400];
        public ushort[] LW = new ushort[0x1000];
        public int LB_Start_No = 0x00;
        public int LW_Start_No = 0x00;

        public int LB_Count
        {
            get
            {
                return LB.Length;
            }
            set
            {
                Array.Resize(ref LB, value);
            }
        }
        public int LW_Count
        {
            get
            {
                return LW.Length;
            }
            set
            {
                Array.Resize(ref LW, value);
            }
        }

        public TCC_Link_Station()
        {
        }
        public bool Read_LB()
        {
            bool result = false;
            short[] read_data = new short[LB_Count / 16];
            int error_code = 0;
            int type = (int)DivType.B;
            int length = LB_Count;

            error_code = CC_LinK_IE_Dll.mdReceiveEx(Handle, 0, 0xFF, type, LB_Start_No, ref length, ref read_data[0]);
            if (error_code == 0)
            {
                ushort[] tmp_data = read_data.Select(Convert.ToUInt16).ToArray();

                UShort_To_Bool(tmp_data, LB);
                result = true;
            }
            return result;
        }
        public bool Read_LW()
        {
            bool result = false;
            short[] read_data = new short[LW_Count];
            int error_code = 0;
            int type = (int)DivType.W;
            int length = LW_Count;

            error_code = CC_LinK_IE_Dll.mdReceiveEx(Handle, 0, 0xFF, type, LW_Start_No, ref length, ref read_data[0]);
            if (error_code == 0)
            {
                for (int i = 0; i < LW_Count; i++) LW[i] = (ushort)read_data[i];
                result = true;
            }
            return result;
        }
        public bool Write_LB()
        {
            bool result = false;
            ushort[] tmp_data = new ushort[LB_Count / 16];
            short[] send_data;
            int error_code = 0;
            int type = (int)DivType.B;
            int length = LB_Count;

            Bool_To_UShort(LB, tmp_data);
            send_data = tmp_data.Select(Convert.ToInt16).ToArray();
            error_code = CC_LinK_IE_Dll.mdSendEx(Handle, 0, 0xFF, type, LB_Start_No, ref length, ref send_data[0]);
            if (error_code == 0)
            {
                result = true;
            }
            return result;
        }
        public bool Write_LW()
        {
            bool result = false;
            short[] send_data = new short[LW_Count];
            int error_code = 0;
            int type = (int)DivType.W;
            int length = LW_Count;

            for (int i = 0; i < LW_Count; i++) send_data[i] = (short)LW[i];
            error_code = CC_LinK_IE_Dll.mdSendEx(Handle, 0, 0xFF, type, LW_Start_No, ref length, ref send_data[0]);
            if (error_code == 0)
            {
                result = true;
            }
            return result;
        }


        public void Bool_To_UShort(bool[] in_data, ushort[] out_data)
        {
            int out_count = in_data.Length / 16;
            int word_no = 0;
            int bit_no = 0;

            if (out_data.Length >= out_count)
            {
                for (int i = 0; i < in_data.Length; i++)
                {
                    word_no = i / 16;
                    bit_no = i % 16;
                    PLC_Data_Tool.Set_Bit(out_data, word_no, bit_no, in_data[i]);
                }
            }
        }
        public void UShort_To_Bool(ushort[] in_data, bool[] out_data)
        {
            int out_count = in_data.Length * 16;
            int word_no = 0;
            int bit_no = 0;

            if (out_data.Length >= out_count)
            {
                for (int i = 0; i < out_data.Length; i++)
                {
                    word_no = i / 16;
                    bit_no = i % 16;
                    out_data[i] = PLC_Data_Tool.Get_Bit(in_data, word_no, bit_no);
                }
            }
        }
    }
}
