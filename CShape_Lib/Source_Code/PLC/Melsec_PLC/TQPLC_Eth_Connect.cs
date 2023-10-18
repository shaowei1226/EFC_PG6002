using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using EFC.Tool;
using EFC.PLC;


namespace EFC.PLC.Melsec
{
    public class TMelsec_QPLC_Eth_Connect : TBase_PLC
    {
        protected TJJS_ClientSockect PLC_Socket = new TJJS_ClientSockect();
        protected stQPLC_Header_3E_Bin Header = new stQPLC_Header_3E_Bin();

        //建構式
        public TMelsec_QPLC_Eth_Connect()
        {
            Device_Tool = new TQPLC_Device_Tool();
            PLC_Socket.Host = "192.168.1.100";
            PLC_Socket.Port = 5010;

            //Header
            Header.Sub_Header = 0x0050;
            Header.Network_No = 0x00;
            Header.PC_No = 0xFF;
            Header.Request_Model_No = 0x03FF;
            Header.Request_Model_Station_No = 0x00;
            Header.Data_Length = 0;
            Header.CPU_Time = 0x10;
            Header.Command = 0x0401;
            Header.SubCommand = 0x0000;
        }
        override protected bool Get_Connect()
        {
            return PLC_Socket.Connected;
        }
        override protected void Set_Connect(bool value)
        {
            if (value) PLC_Socket.Connect();
            else PLC_Socket.Disconnect();
        }
        //---------------------------------------------------------------------------
        //max points=3584 point
        //---------------------------------------------------------------------------
        override protected void Run_Command_Read_Bit(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            int in_count = 0;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int start_count = 0, read_count = 0;
            bool[] read_data = new bool[0];

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                Array.Resize(ref read_data, in_count);

                Header.Command = 0x0401;
                Header.SubCommand = 0x0001;
                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = in_count - start_count;
                    if (read_count > 3584) read_count = 3584;

                    Header.Data_Length = 12;
                    Header.Get_Char_Data(ref Write_Buffer);

                    Device_Tool.Break_Device(start_code, ref device_code, ref device_num);
                    index_code = Get_Index_Code(device_code);

                    Array.Copy(BitConverter.GetBytes(device_num + start_count), 0, Write_Buffer, 15, 3);
                    Write_Buffer[18] = (byte)index_code;
                    Array.Copy(BitConverter.GetBytes(read_count), 0, Write_Buffer, 19, 2);
                    Write_Count = 21;


                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        Byte_To_Bool(Read_Buffer, 11, ref read_data, start_count, read_count);
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
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
            int in_count = 0;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int bit_count;
            int start_count, read_count;
            bool[] write_data = new bool[0];


            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                cmd.Get_Data(ref write_data);

                Header.Command = 0x1401;
                Header.SubCommand = 0x0001;
                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = (ushort)(in_count - start_count);
                    if (read_count > 3584) read_count = 3584;

                    bit_count = (read_count - 1) / 2 + 1;
                    Header.Data_Length = (short)(12 + bit_count);
                    Header.Get_Char_Data(ref Write_Buffer);

                    Device_Tool.Break_Device(start_code, ref device_code, ref device_num);
                    index_code = Get_Index_Code(device_code);

                    Array.Copy(BitConverter.GetBytes(device_num + start_count), 0, Write_Buffer, 15, 3);
                    Write_Buffer[18] = (byte)index_code;
                    Array.Copy(BitConverter.GetBytes(read_count), 0, Write_Buffer, 19, 2);

                    Bool_To_Byte(write_data, 0, ref Write_Buffer, 21, read_count);
                    Write_Count = 21 + bit_count;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            cmd.Finish = true;
            cmd.Result = result;
        }

        //---------------------------------------------------------------------------
        //max word=960 word
        //---------------------------------------------------------------------------
        override protected void Run_Command_Read_Byte(TPLC_Command cmd)
        {
            bool result = false;
            string start_code = "";
            int in_count = 0;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int start_count = 0, read_count = 0;
            ushort[] read_data = new ushort[0];

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                Array.Resize(ref read_data, in_count);

                Header.Command = 0x0401;
                Header.SubCommand = 0x0000;
                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = in_count - start_count;
                    if (read_count > 960) read_count = 960;

                    Header.Data_Length = 12;
                    Header.Get_Char_Data(ref Write_Buffer);

                    Device_Tool.Break_Device(start_code, ref device_code, ref device_num);
                    index_code = Get_Index_Code(device_code);

                    Array.Copy(BitConverter.GetBytes(device_num + start_count), 0, Write_Buffer, 15, 3);
                    Write_Buffer[18] = (byte)index_code;
                    Array.Copy(BitConverter.GetBytes(read_count), 0, Write_Buffer, 19, 2);
                    Write_Count = 21;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        Byte_To_UShort(Read_Buffer, 11, ref read_data, start_count, read_count);
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
            int in_count = 0;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int start_count = 0, read_count = 0;
            ushort[] write_data = new ushort[0];

            if (cmd.Get_Param(ref start_code, ref in_count))
            {
                cmd.Get_Data(ref write_data);

                Header.Command = 0x1401;
                Header.SubCommand = 0x0000;
                start_count = 0; read_count = 0;
                if (in_count > 960)
                {

                }
                while (start_count < in_count)
                {
                    read_count = (ushort)(in_count - start_count);
                    if (read_count > 960) read_count = 960;

                    Header.Data_Length = Convert.ToInt16(12 + read_count * 2);
                    Header.Get_Char_Data(ref Write_Buffer);

                    Device_Tool.Break_Device(start_code, ref device_code, ref device_num);
                    index_code = Get_Index_Code(device_code);

                    Array.Copy(BitConverter.GetBytes(device_num + start_count), 0, Write_Buffer, 15, 3);
                    Write_Buffer[18] = (byte)index_code;
                    Array.Copy(BitConverter.GetBytes(read_count), 0, Write_Buffer, 19, 2);
                    UShort_To_Byte(write_data, start_count, ref Write_Buffer, 21, read_count);
                    Write_Count = 21 + read_count * 2;

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        result = true;
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    };
                };
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
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int w_count, dw_count;
            int start_count, read_count;
            string[] code_list = new string[0];
            ushort[] read_data = new ushort[0];

            if (cmd.Get_Param(ref code_list))
            {
                Array.Resize(ref read_data, code_list.Length);

                w_count = code_list.Length;
                dw_count = 0;

                Header.Command = 0x0403;
                Header.SubCommand = 0x0000;
                start_count = 0; read_count = 0;
                result = true;
                while (start_count < w_count && result)
                {
                    read_count = w_count - start_count;
                    if (read_count > 192) read_count = 192;

                    Header.Data_Length = (short)(8 + read_count * 4);
                    Header.Get_Char_Data(ref Write_Buffer);
                    Write_Buffer[15] = (byte)w_count;
                    Write_Buffer[16] = (byte)dw_count;
                    Write_Count = 17;

                    for (int i = 0; i < read_count; i++)
                    {
                        Device_Tool.Break_Device(code_list[i + start_count], ref device_code, ref device_num);
                        index_code = Get_Index_Code(device_code);

                        Array.Copy(BitConverter.GetBytes(device_num), 0, Write_Buffer, Write_Count, 3);
                        Write_Buffer[Write_Count + 3] = (byte)index_code;
                        Write_Count = Write_Count + 4;
                    }

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        Byte_To_UShort(Read_Buffer, 11, ref read_data, start_count, read_count);
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }
            if (result) cmd.Set_Data(read_data);
            cmd.Finish = true;
            cmd.Result = result;
        }

        //---------------------------------------------------------------------------
        //max word=160 word
        //---------------------------------------------------------------------------
        override protected void Run_Command_Random_Write_Byte(TPLC_Command cmd)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int w_count, dw_count;
            int start_count, read_count;
            string[] code_list = new string[0];
            ushort[] write_data = new ushort[0];


            if (cmd.Get_Param(ref code_list))
            {
                cmd.Get_Data(ref write_data);

                w_count = code_list.Length;
                dw_count = 0;

                Header.Command = 0x1402;
                Header.SubCommand = 0x0000;
                start_count = 0; read_count = 0;
                result = true;
                while (start_count < w_count && result)
                {
                    read_count = w_count - start_count;
                    if (read_count > 160) read_count = 160;

                    Header.Data_Length = (short)(8 + read_count * 6);
                    Header.Get_Char_Data(ref Write_Buffer);
                    Write_Buffer[15] = (byte)w_count;
                    Write_Buffer[16] = (byte)dw_count;
                    Write_Count = 17;

                    for (int i = 0; i < read_count; i++)
                    {
                        Device_Tool.Break_Device(code_list[i + start_count], ref device_code, ref device_num);
                        index_code = Get_Index_Code(device_code);

                        Array.Copy(BitConverter.GetBytes(device_num), 0, Write_Buffer, Write_Count, 3);
                        Write_Buffer[Write_Count + 3] = (byte)index_code;
                        Array.Copy(BitConverter.GetBytes(write_data[i + start_count]), 0, Write_Buffer, Write_Count + 4, 2);
                        Write_Count = Write_Count + 6;
                    }

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            cmd.Finish = true;
            cmd.Result = result;
        }

        //---------------------------------------------------------------------------
        //max word=??? bit
        //---------------------------------------------------------------------------
        override protected void Run_Command_Random_Read_Bit(TPLC_Command cmd)
        {
            bool result = true;
            bool[] data = new bool[16];

            cmd.Finish = true;
            cmd.Result = result;
        }
        override protected void Run_Command_Random_Write_Bit(TPLC_Command cmd)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int w_count, dw_count;
            int start_count, read_count;
            string[] code_list = new string[0];
            bool[] write_data = new bool[0];


            if (cmd.Get_Param(ref code_list))
            {
                cmd.Get_Data(ref write_data);

                w_count = code_list.Length;
                dw_count = 0;

                Header.Command = 0x1402;
                Header.SubCommand = 0x0001;
                start_count = 0; read_count = 0;
                result = true;
                while (start_count < w_count && result)
                {
                    read_count = w_count - start_count;
                    if (read_count > 160) read_count = 160;

                    Header.Data_Length = (short)(8 + read_count * 5);
                    Header.Get_Char_Data(ref Write_Buffer);
                    Write_Buffer[15] = (byte)read_count;
                    Write_Count = 16;

                    for (int i = 0; i < read_count; i++)
                    {
                        Device_Tool.Break_Device(code_list[i + start_count], ref device_code, ref device_num);
                        index_code = Get_Index_Code(device_code);

                        Array.Copy(BitConverter.GetBytes(device_num), 0, Write_Buffer, Write_Count, 3);
                        Write_Buffer[Write_Count + 3] = (byte)index_code;
                        if (write_data[i + start_count]) Write_Buffer[Write_Count + 4] = 0x01;
                        else Write_Buffer[Write_Count + 4] = 0x00;
                        Write_Count = Write_Count + 5;
                    }

                    if (Write_To_PLC(Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
                    {
                        start_count = start_count + read_count;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            cmd.Finish = true;
            cmd.Result = result;
        }
        override public bool Write_Byte(byte[] data, int data_len)
        {
            PLC_Socket.Send_Byte(data, data_len, SocketFlags.None);
            return true;
        }
        override public bool Read_Byte(ref byte[] data, ref int data_len)
        {
            bool result = true;

            FOn_TimeOut = false;
            Timout_Timer.Enabled = true;
            data_len = 0;
            Array.Resize(ref data, 0);
            while (!FOn_TimeOut)
            {
                if (PLC_Socket.Recive_Length > 0)
                {
                    data = PLC_Socket.Recive_Byte(PLC_Socket.Recive_Length);
                    data_len = data.Length;
                    break;
                }
            }
            if (FOn_TimeOut) Log_Add("Read Timeout.");
            Timout_Timer.Enabled = false;

            return result;
        }
        override public bool Read_String(ref string str)
        {
            return false;
        }
        override public bool Write_String(string str)
        {
            return false;
        }

 
        public string Host
        {
            get
            {
                return PLC_Socket.Host;
            }
            set
            {
                PLC_Socket.Host = value;
            }
        }
        public int Port
        {
            get
            {
                return PLC_Socket.Port;
            }
            set
            {
                PLC_Socket.Port = value;
            }
        }
        protected bool Write_To_PLC(byte[] write_buffer, int write_count, ref byte[] read_buffer, ref int read_count)
        {
            bool result = false;

            read_count = 0;
            Array.Resize(ref read_buffer, 0);
            if (Connect)
            {
                PLC_Write_Byte(write_buffer, write_count);
                PLC_Read_Byte(ref read_buffer, ref read_count);

                if (read_count > 10 && read_buffer[0] == '\xD0' && read_buffer[1] == '\x00'
                    && read_buffer[9] == '\x00' && read_buffer[10] == '\x00') result = true;
            }
            return result;
        }
        private char Get_Index_Code(string code)
        {
            return ((TQPLC_Device_Tool)Device_Tool).Get_Index_Code(code);
        }
    }
}
