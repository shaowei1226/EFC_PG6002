using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Timers;
using EFC.Tool;


namespace EFC.PLC.Melsec
{
    public class TQPLC_RS232_Connect : TBase_PLC
    {
        public TBase_SerialPort COM = new TBase_SerialPort();
        private stQPLC_Header_4C_F4 Header;


        public TQPLC_RS232_Connect()
        {
            COM.Setting("1,115200,N,7,1");
            //COM = new SerialPort();
            //COM.PortName = "COM7";
            //COM.BaudRate = 115200;
            //COM.Parity = System.IO.Ports.Parity.None;
            //COM.StopBits = System.IO.Ports.StopBits.One;
            //COM.DataBits = 7;
            COM.ReadBufferSize = 4096;
            COM.WriteBufferSize = 4096;
            COM.ReadTimeout = 2000;
            COM.Handshake = Handshake.None;
            COM.RtsEnable = true;
            COM.DtrEnable = true;

            FBusy = false;
            Header.Start_Code = "\x05";
            Header.Frame_ID_No = "F8";
            Header.Station_No = "00";
            Header.Network_No = "00";
            Header.PC_No = "00";
            Header.Request_Model_No = "03FF";
            Header.Request_Model_Station_No = "00";
            Header.Self_Station_No = "00";
            Header.Command = "0000";
            Header.SubCommand = "00";
            Header.Data = "";
            Header.SumCheck = "";
            Header.End_Code = "\x0D\x0A";
        }
        protected override bool Get_Connect()
        {
            return COM.IsOpen;
        }
        protected override void Set_Connect(bool value)
        {
            if (value) 
                if (!COM.IsOpen) COM.Open();
            else COM.Close();
        }

 
        
        override protected void Run_Command_Read_Bit(TPLC_Command cmd)
        {
        }
        override protected void Run_Command_Write_Bit(TPLC_Command cmd)
        {
        }

        override protected void Run_Command_Read_Byte(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            int in_count = 0;
            ushort[] read_data = new ushort[0];

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                Array.Resize(ref read_data, in_count);
                result = in_Read_Byte(start_code, ref read_data, in_count);
            }
            if (result) cmd.Set_Data(read_data);
            cmd.Finish = true;
            cmd.Result = result;
        }
        override protected void Run_Command_Write_Byte(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            int in_count = 0;
            ushort[] write_data = new ushort[0];

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                cmd.Get_Data(ref write_data);
                result = in_Write_Byte(start_code, write_data, in_count);
            }
            cmd.Finish = true;
            cmd.Result = result;
        }
        override protected void Run_Command_Random_Read_Byte(TPLC_Command cmd)
        {
        }
        override protected void Run_Command_Random_Write_Byte(TPLC_Command cmd)
        {
        }
        override protected void Run_Command_Random_Read_Bit(TPLC_Command cmd)
        {
        }
        override protected void Run_Command_Random_Write_Bit(TPLC_Command cmd)
        {
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
            str = COM.ReadTo("\x0D\x0A");
            return true;
        }
        override public bool Write_String(string str)
        {
            COM.Write(str);
            return true;
        }




        private bool in_Read_Byte(string start_code, ref ushort[] read_data, int count = 1)
        {
            bool result = false;
            string sum, write_str;
            string read_str = "";
            string data = "";
            int start_count, r_count;

            //if (!FBusy)
            {
                Header.Command = "0401";
                Header.SubCommand = "0000";
                start_count = 0; r_count = 0;
                while (start_count < count)
                {
                    r_count = count - start_count;
                    if (r_count > 960)
                    {
                        r_count = 960;
                    }
                    Header.Data = Get_Device_Code(start_code, start_count) + String_Tool.IntToHexStr(r_count, 4);
                    write_str = Header.Get_Write_Str() + Header.Data;
                    sum = Header.Get_SumCheck(write_str.Substring(1, write_str.Length - 1), write_str.Length - 1);
                    write_str = write_str + sum + Header.End_Code;
                    if (WriteToPLC(write_str, ref read_str))
                    {
                        Get_Data(read_str, ref data);

                        if (data.Length >= r_count * 4)
                        {
                            for (int i = 0; i < r_count; i++)
                            {
                                read_data[start_count + i] = Convert.ToUInt16(String_Tool.HexStrToInt(data.Substring(i * 4, 4)));
                            }
                            result = true;
                        }
                        else
                        {
                            // 清除Buffer
                            string tmp_data = "";
                            try
                            {
                                tmp_data = COM.ReadTo("\x0D\x0A");
                            }
                            catch (Exception e)
                            {
                                Log_Add("清除Buffer.");
                            };
                        }

                        start_count = start_count + r_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }
        private bool in_Write_Byte(string start_code, ushort[] write_data, int count = 1)
        {
            bool result = false;
            string sum, write_str, read_str = "";
            //string data = "";
            int start_count, r_count;

            //if (!FBusy)
            {
                Header.Command = "1401";
                Header.SubCommand = "0000";
                start_count = 0; r_count = 0;
                while (start_count < count)
                {
                    r_count = count - start_count;
                    if (r_count > 960)
                    {
                        r_count = 960;
                    }
                    Header.Data = Get_Device_Code(start_code, start_count) + String_Tool.IntToHexStr(r_count, 4);
                    for (int i = 0; i < r_count; i++)
                    {
                        int aa;
                        aa = write_data[start_count + i];
                        Header.Data += String_Tool.IntToHexStr(write_data[start_count + i], 4);
                    }

                    write_str = Header.Get_Write_Str() + Header.Data;
                    sum = Header.Get_SumCheck(write_str.Substring(1, write_str.Length - 1), write_str.Length - 1);
                    write_str = write_str + sum + Header.End_Code;

                    if (WriteToPLC(write_str, ref read_str))
                    {
                        result = true;
                        start_count = start_count + r_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }


        private string Get_Device_Code(string code, int ofs = 0)
        {
            string result = "";

            string device_num_str = "";
            int device_num = 0;
            device_num_str = code.Substring(1, code.Length - 1);
            switch (code[0])
            {
                case 'X':
                case 'x':
                    result = "X*";
                    device_num = String_Tool.HexStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToHexStr(device_num, 6);
                    break;

                case 'Y':
                case 'y':
                    result = "Y*";
                    device_num = String_Tool.HexStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToHexStr(device_num, 6);
                    break;

                case 'M':
                case 'm':
                    result = "M*";
                    device_num = String_Tool.TenStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToTenStr(device_num, 6);
                    break;

                case 'L':
                case 'l':
                    result = "L*";
                    device_num = String_Tool.TenStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToTenStr(device_num, 6);
                    break;

                case 'B':
                case 'b':
                    result = "B*";
                    device_num = String_Tool.HexStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToHexStr(device_num, 6);
                    break;

                case 'D':
                case 'd':
                    result = "D*";
                    device_num = String_Tool.TenStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToTenStr(device_num, 6);
                    break;

                case 'W':
                case 'w':
                    result = "W*";
                    device_num = String_Tool.HexStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToHexStr(device_num, 6);
                    break;

                case 'T':
                case 't':
                    result = "TC";
                    device_num = String_Tool.TenStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToTenStr(device_num, 6);
                    break;

                case 'C':
                case 'c':
                    result = "CC";
                    device_num = String_Tool.TenStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToTenStr(device_num, 6);
                    break;

                case 'R':
                case 'r':
                    result = "R*";
                    device_num = String_Tool.TenStrToInt(device_num_str) + ofs;
                    result = result + String_Tool.IntToTenStr(device_num, 6);
                    break;
            }
            return result;
        }
        private bool WriteToPLC(string write_str, ref string read_str)
        {
            bool result = false;
            //if (!FBusy)
            {
                //FBusy = true;
                try
                {
                    PLC_Write_String(write_str);
                    JJS_LIB.Sleep(100);
                    PLC_Read_String(ref read_str);
                    result = true;
                }
                catch
                {

                }
            }
            //FBusy = false;

            return result;
        }
        private void Get_Data(string return_data, ref string data)
        {
            if (return_data.Length > 18)
                data = return_data.Substring(17, return_data.Length - 18);
        }
    }
}
