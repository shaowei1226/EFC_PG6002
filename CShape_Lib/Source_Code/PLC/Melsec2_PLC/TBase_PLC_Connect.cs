using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;
using EFC.PLC;

namespace EFC.PLC.Melsec
{
    //-----------------------------------------------------------------------------------------------------
    //封包檔頭格式 3E
    //-----------------------------------------------------------------------------------------------------
    public class stQPLC_Header_3E_Bin
    {
        public byte[] Data = new byte[15];

        public void Set_Char_Data(byte[] in_data)
        {
            Array.Copy(in_data, 0, Data, 0, 15);
        }
        public void Get_Char_Data(ref byte[] out_data)
        {
            Array.Copy(Data, 0, out_data, 0, 15);
        }
        public ushort Sub_Header
        {
            get
            {
                ushort result;
                byte[] out_data = new byte[2];

                Array.Copy(Data, 0, out_data, 0, out_data.Length);
                out_data = Swap(out_data);
                result = BitConverter.ToUInt16(out_data, 0);
                return result;
            }
            set
            {
                byte[] data = Swap(BitConverter.GetBytes(value));
                Array.Copy(data, 0, Data, 0, 2);
            }
        }
        public byte Network_No
        {
            get
            {
                return Data[2];
            }
            set
            {
                Data[2] = value;
            }
        }
        public byte PC_No
        {
            get
            {
                return Data[3];
            }
            set
            {
                Data[3] = value;
            }
        }
        public ushort Request_Model_No
        {
            get
            {
                ushort result;
                byte[] out_data = new byte[2];

                Array.Copy(Data, 4, out_data, 0, out_data.Length);
                out_data = Swap(out_data);
                result = BitConverter.ToUInt16(out_data, 0);
                return result;
            }
            set
            {
                byte[] data = Swap(BitConverter.GetBytes(value));
                Array.Copy(data, 0, Data, 4, 2);
            }
        }
        public byte Request_Model_Station_No
        {
            get
            {
                return Data[6];
            }
            set
            {
                Data[6] = value;
            }
        }
        public ushort Data_Length
        {
            get
            {
                ushort result;
                result = BitConverter.ToUInt16(Data, 7);
                return result;
            }
            set
            {
                byte[] data = BitConverter.GetBytes(value);
                Array.Copy(data, 0, Data, 7, 2);
            }
        }
        public ushort CPU_Time
        {
            get
            {
                ushort result;
                byte[] out_data = new byte[2];

                Array.Copy(Data, 9, out_data, 0, out_data.Length);
                out_data = Swap(out_data);
                result = BitConverter.ToUInt16(out_data, 0);
                return result;
            }
            set
            {
                byte[] data = BitConverter.GetBytes(value);
                Array.Copy(data, 0, Data, 9, 2);
            }
        }
        public ushort Command
        {
            get
            {
                ushort result;
                result = BitConverter.ToUInt16(Data, 11);
                return result;
            }
            set
            {
                byte[] data = BitConverter.GetBytes(value);
                Array.Copy(data, 0, Data, 11, 2);
            }
        }
        public ushort SubCommand
        {
            get
            {
                ushort result;
                result = BitConverter.ToUInt16(Data, 13);
                return result;
            }
            set
            {
                byte[] data = BitConverter.GetBytes(value);
                Array.Copy(data, 0, Data, 13, 2);
            }
        }

        private byte[] Swap(byte[] in_data)
        {
            byte[] result = new byte[in_data.Length];

            for (int i = 0; i < in_data.Length; i++) result[i] = in_data[in_data.Length - i - 1];
            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //封包檔頭格式 3E
    //-----------------------------------------------------------------------------------------------------
    public struct stQPLC_Header_4C_F4
    {
        public string Start_Code;                  //1 char
        public string Frame_ID_No;                 //2 char
        public string Station_No;                  //2 char
        public string Network_No;                  //2 char
        public string PC_No;                       //2 char
        public string Request_Model_No;            //4 char
        public string Request_Model_Station_No;    //2 char
        public string Self_Station_No;             //2 char
        public string Command;                     //4 char
        public string SubCommand;                  //4 char
        public string Data;                        //
        public string SumCheck;                    //2 char
        public string End_Code;                    //2 char

        /// <summary>
        /// Get_SumCheck
        /// </summary>
        /// <remarks>
        /// <para>Content: Get CkeckSum Value</para>
        /// <para>Remark:  </para>
        /// </remarks>    
        public string Get_SumCheck(string data, int count)
        {
            string result;
            int sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += data[i];
            }
            result = String_Tool.IntToHexStr(sum, 2);
            return result;
        }
        /// <summary>
        /// Get_Write_Str
        /// </summary>
        /// <returns>Return: Start_Code+Frame_ID_No+.....</returns>
        /// <remarks>
        /// <para>Content: Get Command Header</para>
        /// <para>Remark:  </para>
        /// </remarks>  
        public string Get_Write_Str()
        {
            string result;

            result = Start_Code +
                     Frame_ID_No +
                     Station_No +
                     Network_No +
                     PC_No +
                     Request_Model_No +
                     Request_Model_Station_No +
                     Self_Station_No +
                     Command +
                     SubCommand;

            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號相關功能
    //-----------------------------------------------------------------------------------------------------
    public class TQPLC_Device_Tool : TBase_Device_Tool
    {
        public TQPLC_Device_Tool()
        {
            Code_List_Bit = Get_Code_List_Bit();
            Code_List_Word = Get_Code_List_Word();
            Code_List_All = Get_Code_List_All();
        }
        override public emDevice_Type Get_Device_Type(string device)
        {
            emDevice_Type result = emDevice_Type.emNone;
            string code = "";
            int num = 0;

            if (Break_Device(device, ref code, ref num))
            {
                if (Is_Code_Bit(code)) result = emDevice_Type.emBit;
                if (Is_Code_Word(code)) result = emDevice_Type.emWord;
            }
            return result;
        }
        override public emDevice_Num_Type Get_Device_Num_Type(string code)
        {
            emDevice_Num_Type result = emDevice_Num_Type.emNone;
            switch (code.ToUpper())
            {
                case "X": result = emDevice_Num_Type.emHex; break;
                case "Y": result = emDevice_Num_Type.emHex; break;
                case "M": result = emDevice_Num_Type.emTen; break;
                case "L": result = emDevice_Num_Type.emTen; break;
                case "B": result = emDevice_Num_Type.emHex; break;
                case "D": result = emDevice_Num_Type.emTen; break;
                case "W": result = emDevice_Num_Type.emHex; break;
                case "T": result = emDevice_Num_Type.emTen; break;
                case "C": result = emDevice_Num_Type.emTen; break;
                case "R": result = emDevice_Num_Type.emTen; break;
            }
            return result;
        }
        override public bool Break_Device(string device, ref string code, ref int num)
        {
            bool result = false;
            string tmp_device = "";
            string tmp_code = "";
            string tmp_num = "";

            if (device.Length > 1)
            {
                tmp_device = device.ToUpper();
                tmp_code = tmp_device.Substring(0, 1);
                tmp_num = tmp_device.Substring(1, device.Length - 1);
             
                if (Is_Code(tmp_code))
                {
                    code = tmp_code;
                    num = Str_To_Int(tmp_num, Get_Device_Num_Type(tmp_code));
                    result = true;
                }
            }
            return result;
        }
        override public TBase_Device_Info New_Device()
        {
            return new TQPLC_Device_Info();
        }
        override public TBase_Device_List New_Device_List()
        {
            return new TQPLC_Device_List();
        }


        public ArrayList Get_Code_List_Bit()
        {
            ArrayList result = new ArrayList();
            result.Add("X");
            result.Add("Y");
            result.Add("M");
            result.Add("L");
            result.Add("B");
            return result;
        }
        public ArrayList Get_Code_List_Word()
        {
            ArrayList result = new ArrayList();
            result.Add("D");
            result.Add("W");
            result.Add("T");
            result.Add("C");
            result.Add("R");
            return result;
        }
        public ArrayList Get_Code_List_All()
        {
            ArrayList result = new ArrayList();

            result = ArrayList_Tool.Add(Get_Code_List_Bit(), Get_Code_List_Word());
            return result;
        }
        public char Get_Index_Code(string code)
        {
            char result = ' ';
            switch (code)
            {
                case "X": result = Convert.ToChar(0x9C); break;
                case "Y": result = Convert.ToChar(0x9D); break;
                case "M": result = Convert.ToChar(0x90); break;
                case "L": result = Convert.ToChar(0x92); break;
                case "B": result = Convert.ToChar(0xA0); break;
                case "D": result = Convert.ToChar(0xA8); break;
                case "W": result = Convert.ToChar(0xB4); break;
                case "T": result = Convert.ToChar(0xC0); break;
                case "C": result = Convert.ToChar(0xC3); break;
                case "R": result = Convert.ToChar(0xAF); break;
            }
            return result;

        }

    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號儲存結構
    //-----------------------------------------------------------------------------------------------------
    public class TQPLC_Device_Info : TBase_Device_Info
    {
        public TQPLC_Device_Info()
        {
            Device_Tool = new TQPLC_Device_Tool();
        }
        public void Copy(TQPLC_Device_Info sor, ref TQPLC_Device_Info dis)
        {
            TBase_Device_Info tmp_dis = dis;
            base.Copy(sor, ref tmp_dis);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號串列儲存結構
    //-----------------------------------------------------------------------------------------------------
    public class TQPLC_Device_List : TBase_Device_List
    {
        public TQPLC_Device_List()
        {
            Device_Tool = new TQPLC_Device_Tool();
        }
        public void Copy(TQPLC_Device_List sor, ref TQPLC_Device_List dis)
        {
            TBase_Device_List tmp_dis = dis;
            base.Copy(sor, tmp_dis);
        }
    }
}
