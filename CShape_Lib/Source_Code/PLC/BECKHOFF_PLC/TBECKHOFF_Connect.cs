using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using EFC.PLC;
using EFC.Tool;
using TwinCAT.Ads;


namespace EFC.PLC.BECKHOFF
{
    public enum emBECKHOFF_Data_Type { Bool, Int, Real, LReal, Array_Bool, Array_Int, Array_Real, Array_LReal };


    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號相關功能
    //-----------------------------------------------------------------------------------------------------
    public class TADS_Device_Tool : TBase_Device_Tool
    {
        public TADS_Device_Tool()
        {
            Device_Code_Count = 5;
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
                case "MR": result = emDevice_Num_Type.emTen; break;

                case "DM": result = emDevice_Num_Type.emTen; break;
                case "EM": result = emDevice_Num_Type.emTen; break;
                case "FM": result = emDevice_Num_Type.emTen; break;
                case "ZF": result = emDevice_Num_Type.emTen; break;
                case "W": result = emDevice_Num_Type.emTen; break;
                case "TM": result = emDevice_Num_Type.emTen; break;
                case "Z": result = emDevice_Num_Type.emTen; break;
                case "T": result = emDevice_Num_Type.emTen; break;
                case "TC": result = emDevice_Num_Type.emTen; break;
                case "TS": result = emDevice_Num_Type.emTen; break;

                case "C": result = emDevice_Num_Type.emTen; break;
                case "CC": result = emDevice_Num_Type.emTen; break;
                case "CS": result = emDevice_Num_Type.emTen; break;
                case "CTH": result = emDevice_Num_Type.emTen; break;
                case "CTC": result = emDevice_Num_Type.emTen; break;
                case "AT": result = emDevice_Num_Type.emTen; break;
                case "CM": result = emDevice_Num_Type.emTen; break;
                case "VM": result = emDevice_Num_Type.emTen; break;
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
                tmp_code = String_Tool.Cut_Num_Char(tmp_device);
                tmp_num = String_Tool.Get_Num_Char(tmp_device);

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
            return new TADS_Device_Info();
        }
        override public TBase_Device_List New_Device_List()
        {
            return new TADS_Device_List();
        }


        public ArrayList Get_Code_List_Bit()
        {
            ArrayList result = new ArrayList();
            result.Add("R");
            result.Add("B");
            result.Add("MR");
            result.Add("LR");
            result.Add("CR");
            result.Add("VB");
            return result;
        }
        public ArrayList Get_Code_List_Word()
        {
            ArrayList result = new ArrayList();
            result.Add("DM");
            result.Add("EM");
            result.Add("FM");
            result.Add("ZF");
            result.Add("W");
            result.Add("TM");
            result.Add("Z");
            result.Add("T");
            result.Add("TC");
            result.Add("TS");
            result.Add("C");
            result.Add("CC");
            result.Add("CS");
            result.Add("CTH");
            result.Add("CTC");
            result.Add("AT");
            result.Add("CM");
            result.Add("VM");
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
    public class TADS_Device_Info : TBase_Device_Info
    {
        public TADS_Device_Info()
        {
            Device_Tool = new TADS_Device_Tool();
        }
        public void Copy(TADS_Device_Info sor, ref TADS_Device_Info dis)
        {
            TBase_Device_Info tmp_dis = dis;
            base.Copy(sor, ref tmp_dis);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號串列儲存結構
    //-----------------------------------------------------------------------------------------------------
    public class TADS_Device_List : TBase_Device_List
    {
        public TADS_Device_List()
        {
            Device_Tool = new TADS_Device_Tool();
        }
        public void Copy(TADS_Device_List sor, ref TADS_Device_List dis)
        {
            TBase_Device_List tmp_dis = dis;
            base.Copy(sor, tmp_dis);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 連線 
    //上位鏈 TCP/IP Port = 8501
    //上位鏈 UDP/IP Port = 8501
    //-----------------------------------------------------------------------------------------------------
    public enum emDevice_Type_Code {uint16, int16, uint32, int32, hex_int16}
    public class TBECKHOFF_Eth_Connect : TBase_PLC
    {
        public string Host = "127.0.0.1";
        public int Port = 851;
        public TcAdsClient ADS = new TcAdsClient();

        //protected TJJS_CLientSockect PLC_Socket = new TJJS_CLientSockect();
        //protected stQPLC_Header_3E_Bin Header = new stQPLC_Header_3E_Bin();
        public string CR = "\x0D";
        public string LF = "\x0A";

        //建構式
        public TBECKHOFF_Eth_Connect()
        {
            Device_Tool = new TADS_Device_Tool();
            Host = "5.70.37.242.1.1";
            Port = 851;

            //Header
            //Header.Sub_Header = 0x0050;
            //Header.Network_No = 0x00;
            //Header.PC_No = 0xFF;
            //Header.Request_Model_No = 0x03FF;
            //Header.Request_Model_Station_No = 0x00;
            //Header.Data_Length = 0;
            //Header.CPU_Time = 0x10;
            //Header.Command = 0x0401;
            //Header.SubCommand = 0x0000;
        }
        override protected bool Get_Connect()
        {
            return ADS.IsConnected;
        }
        override protected void Set_Connect(bool value)
        {
            Host = "5.70.37.242.1.1";

            if (value)
            {
                try
                {
                    ADS.Connect(Host, Port);  // connect BeckHoff PLC using default port 851
                }
                catch
                {

                }
            }
            else
            {

            }
            //PLC_Socket.Active = value;
        }
        //---------------------------------------------------------------------------
        //max points=???? point
        //---------------------------------------------------------------------------
        override protected void Run_Command_Read_Bit(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            string new_devicve_code = "";
            int in_count = 0;
            int start_count = 0, read_count = 0;
            bool[] read_data = new bool[0];
            string cmd_str = "";

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                Array.Resize(ref read_data, in_count);

                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = in_count - start_count;
                    if (read_count > 1000) read_count = 1000;

                    new_devicve_code = Device_Tool.Generate_Device(start_code, start_count);
                    cmd_str = "RDS" + " " + new_devicve_code + " " + in_count.ToString() + CR;
                    String_To_Byte(cmd_str, ref Write_Buffer, 0);
                    Write_Count = cmd_str.Length;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        Byte_To_Bool(Read_Buffer, 0, ref read_data, start_count, read_count);
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    };
                }
            }
            if (result) cmd.Set_Data(read_data);
            cmd.Finish = true;
            cmd.Result = result;
        }
        override protected void Run_Command_Write_Bit(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            string new_devicve_code = "";
            int in_count = 0;
            int start_count = 0, read_count = 0;
            bool[] cmd_data = new bool[0];
            string cmd_str = "";

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                cmd.Get_Data(ref cmd_data);

                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = in_count - start_count;
                    if (read_count > 1000) read_count = 1000;

                    new_devicve_code = Device_Tool.Generate_Device(start_code, start_count);

                    cmd_str = "WRS" + " " + new_devicve_code + " " + in_count.ToString() +
                              Bool_To_String(cmd_data, start_count, read_count) + CR;
                    String_To_Byte(cmd_str, ref Write_Buffer, 0);
                    Write_Count = cmd_str.Length;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        if (Read_Buffer[0] == 'O' && Read_Buffer[1] == 'K')
                        {
                            result = true;
                            start_count = start_count + read_count;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    };
                }
            }
            cmd.Finish = true;
            cmd.Result = result;
        }

        //---------------------------------------------------------------------------
        //max word=???? word
        //---------------------------------------------------------------------------
        override protected void Run_Command_Read_Byte(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            string new_devicve_code = "";
            int in_count = 0;
            int start_count = 0, read_count = 0;
            ushort[] read_data = new ushort[0];
            string cmd_str = "";

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                Array.Resize(ref read_data, in_count);

                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = in_count - start_count;
                    if (read_count > 1000) read_count = 1000;

                    new_devicve_code = Device_Tool.Generate_Device(start_code, start_count);

                    cmd_str = "RDS" + " " + new_devicve_code + " " + in_count.ToString() + CR;
                    String_To_Byte(cmd_str, ref Write_Buffer, 0);
                    Write_Count = cmd_str.Length;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        Byte_To_UShort(Read_Buffer, 0, ref read_data, start_count, read_count);
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    };
                }
            }
            if (result) cmd.Set_Data(read_data);
            cmd.Finish = true;
            cmd.Result = result;
        }
        override protected void Run_Command_Write_Byte(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            string new_devicve_code = "";
            int in_count = 0;
            int start_count = 0, read_count = 0;
            ushort[] cmd_data = new ushort[0];
            string cmd_str = "";

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                cmd.Get_Data(ref cmd_data);

                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = in_count - start_count;
                    if (read_count > 1000) read_count = 1000;

                    new_devicve_code = Device_Tool.Generate_Device(start_code, start_count);
                    cmd_str = "WRS" + " " + new_devicve_code + " " + in_count.ToString() +
                             UShort_To_String(cmd_data, start_count, read_count) + CR;
                    String_To_Byte(cmd_str, ref Write_Buffer, 0);
                    Write_Count = cmd_str.Length;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        if (Read_Buffer[0] == 'O' && Read_Buffer[1] == 'K')
                        {
                            result = true;
                            start_count = start_count + read_count;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    else
                    {
                        result = false;
                        break;
                    };
                }
            }
            cmd.Finish = true;
            cmd.Result = result;
        }

        //---------------------------------------------------------------------------
        //max word=192 word
        //---------------------------------------------------------------------------
        override protected void Run_Command_Random_Read_Byte(TPLC_Command cmd)
        {
            bool result = false;
            //string device_code = "";
            //int device_num = 0;
            //char index_code = ' ';
            //int w_count, dw_count;
            //int start_count, read_count;
            int start_count = 0, read_count = 0;
            string[] code_list = new string[0];
            ushort[] read_data = new ushort[0];
            string cmd_str = "";

            if (cmd.Get_Param(ref code_list))
            {
                read_count = code_list.Length - start_count;
                if (read_count > 1000) read_count = 1000;
                result = true;
                while (start_count < code_list.Length && result)
                {
                    Array.Resize(ref read_data, code_list.Length);

                    cmd_str = "RDS" + " " + "DM00" + "  1 " + "DM01" + " 1" + CR;
                    String_To_Byte(cmd_str, ref Write_Buffer, 0);
                    Write_Count = cmd_str.Length;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        //Byte_To_UShort(Read_Buffer, 0, ref read_data, start_count, read_count);
                        //start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    };
                }
            }

                    //    w_count = code_list.Length;
                    //    dw_count = 0;

                    //    Header.Command = 0x0403;
                    //    Header.SubCommand = 0x0000;
                    //    start_count = 0; read_count = 0;
                    //    result = true;
                    //    while (start_count < w_count && result)
                    //    {
                    //        read_count = w_count - start_count;
                    //        if (read_count > 192) read_count = 192;

                    //        Header.Data_Length = (short)(8 + read_count * 4);
                    //        Header.Get_Char_Data(ref Write_Buffer);
                    //        Write_Buffer[15] = (byte)w_count;
                    //        Write_Buffer[16] = (byte)dw_count;
                    //        Write_Count = 17;

                    //        for (int i = 0; i < read_count; i++)
                    //        {
                    //            Device_Tool.Break_Device(code_list[i + start_count], ref device_code, ref device_num);
                    //            index_code = Get_Index_Code(device_code);

                    //            Array.Copy(BitConverter.GetBytes(device_num), 0, Write_Buffer, Write_Count, 3);
                    //            Write_Buffer[Write_Count + 3] = (byte)index_code;
                    //            Write_Count = Write_Count + 4;
                    //        }

                    //        if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    //        {
                    //            Byte_To_UShort(Read_Buffer, 11, ref read_data, start_count, read_count);
                    //            start_count = start_count + read_count;
                    //        }
                    //        else
                    //        {
                    //            result = false;
                    //            break;
                    //        }
                    //    }
 
            if (result) cmd.Set_Data(read_data);
            cmd.Finish = true;
            cmd.Result = result;
        }

        //---------------------------------------------------------------------------
        //max word=160 word
        //---------------------------------------------------------------------------
        override protected void Run_Command_Random_Write_Byte(TPLC_Command cmd)
        {
            //bool result = false;
            //string device_code = "";
            //int device_num = 0;
            //char index_code = ' ';
            //int w_count, dw_count;
            //int start_count, read_count;
            //string[] code_list = new string[0];
            //ushort[] write_data = new ushort[0];


            //if (cmd.Get_Param(ref code_list))
            //{
            //    cmd.Get_Data(ref write_data);

            //    w_count = code_list.Length;
            //    dw_count = 0;

            //    Header.Command = 0x1402;
            //    Header.SubCommand = 0x0000;
            //    start_count = 0; read_count = 0;
            //    result = true;
            //    while (start_count < w_count && result)
            //    {
            //        read_count = w_count - start_count;
            //        if (read_count > 160) read_count = 160;

            //        Header.Data_Length = (short)(8 + read_count * 6);
            //        Header.Get_Char_Data(ref Write_Buffer);
            //        Write_Buffer[15] = (byte)w_count;
            //        Write_Buffer[16] = (byte)dw_count;
            //        Write_Count = 17;

            //        for (int i = 0; i < read_count; i++)
            //        {
            //            Device_Tool.Break_Device(code_list[i + start_count], ref device_code, ref device_num);
            //            index_code = Get_Index_Code(device_code);

            //            Array.Copy(BitConverter.GetBytes(device_num), 0, Write_Buffer, Write_Count, 3);
            //            Write_Buffer[Write_Count + 3] = (byte)index_code;
            //            Array.Copy(BitConverter.GetBytes(write_data[i + start_count]), 0, Write_Buffer, Write_Count + 4, 2);
            //            Write_Count = Write_Count + 6;
            //        }

            //        if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
            //        {
            //            start_count = start_count + read_count;
            //        }
            //        else
            //        {
            //            result = false;
            //            break;
            //        }
            //    }
            //}

            //cmd.Finish = true;
            //cmd.Result = result;
        }

        //---------------------------------------------------------------------------
        //max word=??? bit
        //---------------------------------------------------------------------------
        override protected void Run_Command_Random_Read_Bit(TPLC_Command cmd)
        {
            //bool result = true;
            //bool[] data = new bool[16];

            //cmd.Finish = true;
            //cmd.Result = result;
        }
        override protected void Run_Command_Random_Write_Bit(TPLC_Command cmd)
        {
            //bool result = false;
            //string device_code = "";
            //int device_num = 0;
            //char index_code = ' ';
            //int w_count, dw_count;
            //int start_count, read_count;
            //string[] code_list = new string[0];
            //bool[] write_data = new bool[0];


            //if (cmd.Get_Param(ref code_list))
            //{
            //    cmd.Get_Data(ref write_data);

            //    w_count = code_list.Length;
            //    dw_count = 0;

            //    Header.Command = 0x1402;
            //    Header.SubCommand = 0x0001;
            //    start_count = 0; read_count = 0;
            //    result = true;
            //    while (start_count < w_count && result)
            //    {
            //        read_count = w_count - start_count;
            //        if (read_count > 160) read_count = 160;

            //        Header.Data_Length = (short)(8 + read_count * 5);
            //        Header.Get_Char_Data(ref Write_Buffer);
            //        Write_Buffer[15] = (byte)read_count;
            //        Write_Count = 16;

            //        for (int i = 0; i < read_count; i++)
            //        {
            //            Device_Tool.Break_Device(code_list[i + start_count], ref device_code, ref device_num);
            //            index_code = Get_Index_Code(device_code);

            //            Array.Copy(BitConverter.GetBytes(device_num), 0, Write_Buffer, Write_Count, 3);
            //            Write_Buffer[Write_Count + 3] = (byte)index_code;
            //            if (write_data[i + start_count]) Write_Buffer[Write_Count + 4] = 0x01;
            //            else Write_Buffer[Write_Count + 4] = 0x00;
            //            Write_Count = Write_Count + 5;
            //        }

            //        if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
            //        {
            //            start_count = start_count + read_count;
            //        }
            //        else
            //        {
            //            result = false;
            //            break;
            //        }
            //    }
            //}

            //cmd.Finish = true;
            //cmd.Result = result;
        }
        override public bool Write_Byte(byte[] data, int data_len)
        {
            return false;
        }
        override public bool Read_Byte(ref byte[] data, ref int data_len)
        {
            return false;
        }
        override public bool Read_String(ref string str)
        {
            return false;
        }
        override public bool Write_String(string str)
        {
            return false;
        }


        public void Log_Exception(string fun_name, string name, Exception e)
        {
            Log_Add(string.Format("[{0:s}] name = {1:s} msg={2:s}", fun_name, name, e.Message));
        }

        public bool Read_Bool(string name, bool default_value, ref bool read_value)
        {
            bool result = false;
            int handle = -1;

            read_value = default_value;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_value = (bool)ADS.ReadAny(handle, typeof(bool));
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Read_Bool", name, e); 
            }
            return result;
        }
        public bool Read_Integer(string name, int default_value, ref int read_value)
        {
            bool result = false;
            int handle = -1;

            read_value = default_value;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_value = (int)ADS.ReadAny(handle, typeof(int));
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Read_Integer", name, e);
            }
            return result;
        }
        public bool Read_Real(string name, float default_value, ref float read_value)
        {
            bool result = false;
            int handle = -1;

            read_value = default_value;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_value = (float)ADS.ReadAny(handle, typeof(float));
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Read_Real", name, e);
            }
            return result;
        }
        public bool Read_LReal(string name, double default_value, ref double read_value)
        {
            bool result = false;
            int handle = -1;

            read_value = default_value;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_value = (double)ADS.ReadAny(handle, typeof(double));
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Read_LReal", name, e);
            }
            return result;
        }
        public bool Read_String(string name, string default_value, int max_count, ref string read_value)
        {
            bool result = false;
            int handle = -1;

            read_value = default_value;
            try
            {
                AdsStream adsStream = new AdsStream(max_count);
                BinaryReader reader = new BinaryReader(adsStream, System.Text.Encoding.ASCII);

                handle = ADS.CreateVariableHandle(name);
                int length = ADS.Read(handle, adsStream);
                read_value = new string(reader.ReadChars(length));
                read_value = read_value.Replace("\0", "");
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Read_String", name, e);
            }
            return result;
        }
        public bool Read_Array(string name, int count, ref bool[] read_value)
        {
            bool result = false;
            bool[] read_data = null;
            int handle = -1;

            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_data = (bool[])ADS.ReadAny(handle, typeof(bool[]), new int[] { count });
                if (read_data != null && read_data.Length >= count && read_value.Length >= count)
                {
                    Array.Copy(read_data, 0, read_value, 0, count);
                    result = true;
                }
                ADS.DeleteVariableHandle(handle);
            }
            catch (Exception e)
            {
                Log_Exception("Read_Array", name, e);
            }

            return result;
        }
        public bool Read_Array(string name, int count, ref int[] read_value)
        {
            bool result = false;
            int[] read_data = null;
            int handle = -1;

            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_data = (int[])ADS.ReadAny(handle, typeof(int[]), new int[] { count });
                if (read_data != null && read_data.Length >= count && read_value.Length >= count)
                {
                    Array.Copy(read_data, 0, read_value, 0, count);
                    result = true;
                }
                ADS.DeleteVariableHandle(handle);
            }
            catch (Exception e)
            {
                Log_Exception("Read_Array", name, e);
            }

            return result;
        }
        public bool Read_Array(string name, int count, ref float[] read_value)
        {
            bool result = false;
            float[] read_data = null;
            int handle = -1;

            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_data = (float[])ADS.ReadAny(handle, typeof(float[]), new int[] { count });
                if (read_data != null && read_data.Length >= count && read_value.Length >= count)
                {
                    Array.Copy(read_data, 0, read_value, 0, count);
                    result = true;
                }
                ADS.DeleteVariableHandle(handle);
            }
            catch (Exception e)
            {
                Log_Exception("Read_Array", name, e);
            }

            return result;
        }
        public bool Read_Array(string name, int count, ref double[] read_value)
        {
            bool result = false;
            double[] read_data = new double[count];
            int handle = -1;
            int[] args = new int[count];

            try
            {
                handle = ADS.CreateVariableHandle(name);
                read_data = (double[])ADS.ReadAny(handle, typeof(double[]), new int[] { count });
                if (read_data != null && read_data.Length >= count && read_value.Length >= count)
                {
                    Array.Copy(read_data, 0, read_value, 0, count);
                    result = true;
                }
                ADS.DeleteVariableHandle(handle);
            }
            catch (Exception e)
            {
                Log_Exception("Read_LReal_Array", name, e);
            }

            return result;
        }
        public bool Read_Struct(string name, TBECKHOFF_Struct_Base read_value)
        {
            bool result = false;
            int handle = -1;
            int size;
            int read_size;

            try
            {
                size = read_value.Sizeof();
                AdsStream adsStream = new AdsStream(size);
                BinaryReader reader = new BinaryReader(adsStream, System.Text.Encoding.ASCII);

                handle = ADS.CreateVariableHandle(name);
                read_size = ADS.Read(handle, adsStream);
                if (read_size == size)
                {
                    read_value.Read(reader);
                    result = true;
                }
                ADS.DeleteVariableHandle(handle);
            }
            catch (Exception e)
            {
                Log_Exception("Read_Struct", name, e);
            }
            return result;
        }


        public bool Write_Bool(string name, bool write_value)
        {
            bool result = false;
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                ADS.WriteAny(handle, write_value);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch(Exception e)
            {
                Log_Exception("Write_Bool", name, e);
            }
            return result;
        }
        public bool Write_Integer(string name, int write_value)
        {
            bool result = false;
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                ADS.WriteAny(handle, write_value);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_Integer", name, e);
            }
            return result;
        }
        public bool Write_Real(string name, float write_value)
        {
            bool result = false;
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                ADS.WriteAny(handle, write_value);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_Real", name, e);
            }
            return result;
        }
        public bool Write_LReal(string name, double write_value)
        {
            bool result = false;
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                ADS.WriteAny(handle, write_value);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_LReal", name, e);
            }
            return result;
        }
        public bool Write_String(string name, string write_value, int max_count)
        {
            bool result = false;
            int handle = -1;
            string tmp_str = write_value; 
            try
            {
                handle = ADS.CreateVariableHandle(name);
                AdsStream adsStream = new AdsStream(max_count);
                BinaryWriter writer = new BinaryWriter(adsStream, System.Text.Encoding.ASCII);
                if (tmp_str.Length > max_count) tmp_str = tmp_str.Substring(0, max_count);
                writer.Write(tmp_str.ToCharArray());
                ADS.Write(handle, adsStream);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_String", name, e);
            }
            return result;
        }
        public bool Write_Array(string name, int count, bool[] write_value)
        {
            bool result = false;
            bool[] write_data = new bool[count];
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                Array.Copy(write_value, 0, write_data, 0, count);
                ADS.WriteAny(handle, write_data);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_Array", name, e);
            }
            return result;
        }
        public bool Write_Array(string name, int count, int[] write_value)
        {
            bool result = false;
            int[] write_data = new int[count];
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                Array.Copy(write_value, 0, write_data, 0, count);
                ADS.WriteAny(handle, write_data);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_Array", name, e);
            }
            return result;
        }
        public bool Write_Array(string name, int count, float[] write_value)
        {
            bool result = false;
            float[] write_data = new float[count];
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                Array.Copy(write_value, 0, write_data, 0, count);
                ADS.WriteAny(handle, write_data);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_Array", name, e);
            }
            return result;
        }
        public bool Write_Array(string name, int count, double[] write_value)
        {
            bool result = false;
            double[] write_data = new double[count];
            int handle = -1;
            try
            {
                handle = ADS.CreateVariableHandle(name);
                Array.Copy(write_value, 0, write_data, 0, count);
                ADS.WriteAny(handle, write_data);
                ADS.DeleteVariableHandle(handle);
                result = true;
            }
            catch (Exception e)
            {
                Log_Exception("Write_Array", name, e);
            }
            return result;
        }
        public bool Write_Struct(string name, TBECKHOFF_Struct_Base write_value)
        {
            bool result = false;
            int handle = -1;
            int size;

            try
            {
                size = write_value.Sizeof();
                AdsStream adsStream = new AdsStream(size);
                BinaryWriter writer = new BinaryWriter(adsStream, System.Text.Encoding.ASCII);

                handle = ADS.CreateVariableHandle(name);
                {
                    write_value.Write(writer);
                    ADS.Write(handle, adsStream);
                    result = true;
                }
                ADS.DeleteVariableHandle(handle);
            }
            catch (Exception e)
            {
                Log_Exception("Write_Struct", name, e);
            }
            return result;
        }




        protected bool Write_To_PLC(byte[] write_buffer, int write_count, ref byte[] read_buffer, ref int read_count)
        {
            bool result = false;

            //read_count = 0;
            //if (Connect)
            //{
            //    FOn_TimeOut = false;
            //    Timout_Timer.Enabled = true;

            //    read_count = 0;
            //    Array.Resize(ref read_buffer, 0);
            //    PLC_Socket.Send_Byte(write_buffer, write_count, SocketFlags.None);
            //    while (!FOn_TimeOut)
            //    {
            //        if (PLC_Socket.Buf_Length > 0)
            //        {
            //            read_buffer = PLC_Socket.Recive_Byte(PLC_Socket.Buf_Length);
            //            read_count = read_buffer.Length;
            //            break;
            //        }
            //    }

            //    string str = Byte_To_Hex(read_buffer, read_count);

            //    if (read_count > 2 && read_buffer[read_count - 2] == '\x0D' && read_buffer[read_count - 1] == '\x0A') result = true;
            //    if (read_count == 4 && read_buffer[0] == 'E' && read_buffer[1] == '0') result = false;
            //    if (read_count == 4 && read_buffer[0] == 'E' && read_buffer[1] == '1') result = false;
            //    Timout_Timer.Enabled = false;
            //}
            return result;
        }
        private char Get_Index_Code(string code)
        {
            return ((TADS_Device_Tool)Device_Tool).Get_Index_Code(code);
        }
        public string Get_Device_Type_Code(emDevice_Type_Code type)
        {
            string result = "";

            switch (type)
            {
                case emDevice_Type_Code.int16: result = ".S"; break;
                case emDevice_Type_Code.uint16: result = ".U"; break;
                case emDevice_Type_Code.int32: result = ".L"; break;
                case emDevice_Type_Code.uint32: result = ".D"; break;
                case emDevice_Type_Code.hex_int16: result = ".H"; break;
            }
            return result;

        }
        public void String_To_Byte(string cmd, ref byte[] data, int start)
        {
            byte[] bytes = System.Text.Encoding.Default.GetBytes(cmd);
            Array.Copy(bytes, 0, data, start, cmd.Length);
        }
        public string Byte_To_Hex(byte[] data)
        {
            string result = "";

            for (int i = 0; i < data.Length; i++ )
            {
                result = result + String_Tool.IntToHexStr(data[i], 2) + " ";
            }
            return result;
        }
        public string Byte_To_Hex(byte[] data, int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
            {
                result = result + String_Tool.IntToHexStr(data[i], 2) + " ";
            }
            return result;
        }
        public string Bool_To_String(bool[] in_data, int start, int count)
        {
            string result = "";

            if (start + count <= in_data.Length)
            {
                for (int i = start; i < start + count; i++)
                {
                    if (in_data[i])
                        result = result + " 1";
                    else
                        result = result + " 0";
                }
            }

            return result;
        }
        public string UShort_To_String(ushort[] in_data, int start, int count)
        {
            string result = "";

            if (start + count <= in_data.Length)
            {
                for (int i = start; i < start + count; i++)
                    result = result + " " + in_data[i].ToString();
            }

            return result;
        }
        override public void Byte_To_UShort(byte[] in_data, int in_index, ref ushort[] out_data, int out_index, int ushort_count)
        {
            ArrayList list = new ArrayList();
            string tm_str = "";

            string str = Byte_ToStr(in_data, in_index, in_data.Length);
            String_Tool.Break_String(str, " ", ref list);

            if (list.Count >= ushort_count)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    tm_str = (string)list[i];
                    out_data[i + out_index] = (ushort)String_Tool.TenStrToInt(tm_str);
                }
            }
        }
        override public void Byte_To_Bool(byte[] in_data, int in_index, ref bool[] out_data, int out_index, int ushort_count)
        {
            ArrayList list = new ArrayList();
            string tm_str = "";

            string str = Byte_ToStr(in_data, in_index, in_data.Length);
            String_Tool.Break_String(str, " ", ref list);

            if (list.Count >= ushort_count)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    tm_str = (string)list[i];
                    out_data[i + out_index] = tm_str == "1";
                }
            }
        }
        public string Byte_ToStr(byte[] in_data, int start, int end)
        {
            string result = "";

            for (int i = start; i < end; i++)
                result = result + (char)in_data[i];
            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //TBEAKHOFF_Value
    //-----------------------------------------------------------------------------------------------------
    public class TBECKHOFF_Value
    {
        public string Name = "";
        public emBECKHOFF_Data_Type Type = emBECKHOFF_Data_Type.Bool;
        public TBECKHOFF_Eth_Connect PLC = null;
        private object Value;


        public TBECKHOFF_Value()
        {
            Data_Set_Bool(false);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, bool value)
        {
            PLC = plc;
            Name = name;
            Data_Set_Bool(value);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, int value)
        {
            PLC = plc;
            Name = name;
            Data_Set_Integer(value);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, float value)
        {
            PLC = plc;
            Name = name;
            Data_Set_Real(value);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, double value)
        {
            PLC = plc;
            Name = name;
            Data_Set_LReal(value);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, bool[] value)
        {
            PLC = plc;
            Name = name;
            Data_Set_Array_Bool(value);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, int[] value)
        {
            PLC = plc;
            Name = name;
            Data_Set_Array_Integer(value);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, float[] value)
        {
            PLC = plc;
            Name = name;
            Data_Set_Array_Real(value);
        }
        public TBECKHOFF_Value(TBECKHOFF_Eth_Connect plc, string name, double[] value)
        {
            PLC = plc;
            Name = name;
            Data_Set_Array_LReal(value);
        }

        public bool Is_Array
        {
            get
            {
                bool result = false;

                if (Type == emBECKHOFF_Data_Type.Array_Bool || Type == emBECKHOFF_Data_Type.Array_Int ||
                    Type == emBECKHOFF_Data_Type.Array_Real || Type == emBECKHOFF_Data_Type.Array_LReal)
                    result = true;
                return result;
            }
        }
        public int Count
        {
            get
            {
                int result = 1;

                if(Is_Array)
                {
                    switch(Type)
                    {
                        case emBECKHOFF_Data_Type.Array_Bool:
                            bool[] value_bool = (bool[])Value;
                            result = value_bool.Length;
                            break;

                        case emBECKHOFF_Data_Type.Array_Int:
                            int[] value_Int = (int[])Value;
                             result = value_Int.Length;
                           break;

                        case emBECKHOFF_Data_Type.Array_Real:
                           float[] value_real = (float[])Value;
                           result = value_real.Length;
                           break;

                        case emBECKHOFF_Data_Type.Array_LReal:
                           double[] value_lreal = (double[])Value;
                           result = value_lreal.Length;
                           break;
                    }
                }
                return result;
            }
        }
        public void Data_Set_Bool(bool value)
        {
            Type = emBECKHOFF_Data_Type.Bool;
            Value = value;
        }
        public void Data_Set_Integer(int value)
        {
            Type = emBECKHOFF_Data_Type.Int;
            Value = value;
        }
        public void Data_Set_Real(float value)
        {
            Type = emBECKHOFF_Data_Type.Real;
            Value = value;
        }
        public void Data_Set_LReal(double value)
        {
            Type = emBECKHOFF_Data_Type.LReal;
            Value = value;
        }
        public void Data_Set_Array_Bool(bool[] value)
        {
            Type = emBECKHOFF_Data_Type.Array_Bool;
            Value = value;
        }
        public void Data_Set_Array_Integer(int[] value)
        {
            Type = emBECKHOFF_Data_Type.Array_Int;
            Value = value;
        }
        public void Data_Set_Array_Real(float[] value)
        {
            Type = emBECKHOFF_Data_Type.Array_Real;
            Value = value;
        }
        public void Data_Set_Array_LReal(double[] value)
        {
            Type = emBECKHOFF_Data_Type.Array_LReal;
            Value = value;
        }


        public bool Data_Get_Bool()
        {
            bool result = false;

            if (Value is bool) result = (bool)Value;
            return result;
        }
        public int Data_Get_Integer()
        {
            int result = 0;

            if (Value is int) result = (int)Value;
            return result;
        }
        public float Data_Get_Real()
        {
            float result = 0;

            if (Value is float) result = (float)Value;
            return result;
        }
        public double Data_Get_LReal()
        {
            double result = 0;

            if (Value is double) result = (double)Value;
            return result;
        }
        public bool[] Data_Get_Array_Bool()
        {
            bool[] result = null;

            if (Value is bool[]) result = (bool[])Value;
            return result;
        }
        public int[] Data_Get_Array_Integer()
        {
            int[] result = null;

            if (Value is int[]) result = (int[])Value;
            return result;
        }
        public float[] Data_Get_Array_Real()
        {
            float[] result = null;

            if (Value is float[]) result = (float[])Value;
            return result;
        }
        public double[] Data_Get_Array_LReal()
        {
            double[] result = null;

            if (Value is double[]) result = (double[])Value;
            return result;
        }

        public bool Read()
        {
            return Read(PLC);
        }
        public bool Read(TBECKHOFF_Eth_Connect plc)
        {
            bool result = false;

            if (plc != null)
            {
                switch (Type)
                {
                    case emBECKHOFF_Data_Type.Bool:
                        bool read_bool = false;

                        if (result = plc.Read_Bool(Name, read_bool, ref read_bool))
                        {
                            Data_Set_Bool(read_bool);
                        }
                        break;

                    case emBECKHOFF_Data_Type.Int:
                        int read_int = 0;
                        if (result = plc.Read_Integer(Name, read_int, ref read_int))
                        {
                            Data_Set_Integer(read_int);
                        }
                        break;

                    case emBECKHOFF_Data_Type.Real:
                        float read_real = 0;
                        if (result = plc.Read_Real(Name, read_real, ref read_real))
                        {
                            Data_Set_Real(read_real);
                        }
                        break;

                    case emBECKHOFF_Data_Type.LReal:
                        double read_lreal = 0;
                        if (result = plc.Read_LReal(Name, read_lreal, ref read_lreal))
                        {
                            Data_Set_LReal(read_lreal);
                        }
                        break;

                    case emBECKHOFF_Data_Type.Array_Bool:
                        bool[] read_bool_array = Data_Get_Array_Bool();
                        if (read_bool_array != null)
                        {
                            if (result = plc.Read_Array(Name, read_bool_array.Length, ref read_bool_array))
                            {
                                Data_Set_Array_Bool(read_bool_array);
                            }
                        }
                        break;

                    case emBECKHOFF_Data_Type.Array_Int:
                        int[] read_int_array = Data_Get_Array_Integer();
                        if (read_int_array != null)
                        {
                            if (result = plc.Read_Array(Name, read_int_array.Length, ref read_int_array))
                            {
                                Data_Set_Array_Integer(read_int_array);
                            }
                        }
                        break;

                    case emBECKHOFF_Data_Type.Array_Real:
                        float[] read_real_array = Data_Get_Array_Real();
                        if (read_real_array != null)
                        {
                            if (result = plc.Read_Array(Name, read_real_array.Length, ref read_real_array))
                            {
                                Data_Set_Array_Real(read_real_array);
                            }
                        }
                        break;

                    case emBECKHOFF_Data_Type.Array_LReal:
                        double[] read_lreal_array = Data_Get_Array_LReal();
                        if (read_lreal_array != null)
                        {
                            if (result = plc.Read_Array(Name, read_lreal_array.Length, ref read_lreal_array))
                            {
                                Data_Set_Array_LReal(read_lreal_array);
                            }
                        }
                        break;
                }
            }

            return result;
        }
        public bool Write()
        {
            return Write(PLC);
        }
        public bool Write(TBECKHOFF_Eth_Connect plc)
        {
            bool result = false;

            if (plc != null)
            {
                switch (Type)
                {
                    case emBECKHOFF_Data_Type.Bool: result = plc.Write_Bool(Name, Data_Get_Bool()); break;
                    case emBECKHOFF_Data_Type.Int: result = plc.Write_Integer(Name, Data_Get_Integer()); break;
                    case emBECKHOFF_Data_Type.Real: result = plc.Write_Real(Name, Data_Get_Real()); break;
                    case emBECKHOFF_Data_Type.LReal: result = plc.Write_LReal(Name, Data_Get_LReal()); break;

                    case emBECKHOFF_Data_Type.Array_Bool:
                        bool[] array_bool = Data_Get_Array_Bool();
                        result = plc.Write_Array(Name, array_bool.Length, array_bool); 
                        break;

                    case emBECKHOFF_Data_Type.Array_Int:
                        int[] array_int = Data_Get_Array_Integer();
                        result = plc.Write_Array(Name, array_int.Length, array_int);
                        break;

                    case emBECKHOFF_Data_Type.Array_Real:
                        float[] array_real = Data_Get_Array_Real();
                        result = plc.Write_Array(Name, array_real.Length, array_real);
                        break;

                    case emBECKHOFF_Data_Type.Array_LReal:
                        double[] array_lreal = Data_Get_Array_LReal();
                        result = plc.Write_Array(Name, array_lreal.Length, array_lreal);
                        break;
                }
            }
            return result;
        }

    }

}
