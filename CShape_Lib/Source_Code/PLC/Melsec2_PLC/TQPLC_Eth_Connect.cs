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
    public class TMelsec_QPLC_Eth_Connect 
    {
        public TQPLC_Device_Tool Device_Tool = new TQPLC_Device_Tool();
        public TJJS_ClientSockect PLC_Socket = new TJJS_ClientSockect();
        public stQPLC_Header_3E_Bin Header = new stQPLC_Header_3E_Bin();
        protected TLog in_Log = null;
        public string Log_Source = "TMelsec_QPLC_Eth_Connect";
        public bool Log_Read_Write = false;

        protected bool FBusy = false;

        protected System.Timers.Timer Reconnect_Timer = new System.Timers.Timer();
        protected bool in_Auto_Reconnect = true;

        protected Thread in_Thread = null;
        private bool Terminate = false;
        private bool Thread_ON = false;

        protected bool FOn_TimeOut = false;
        protected System.Timers.Timer Timout_Timer = new System.Timers.Timer();

        public int Write_Count = 0;
        public byte[] Write_Buffer = new byte[40000];
        public int Read_Count = 0;
        public byte[] Read_Buffer = new byte[40000];

        public TLog Log
        {
            get
            {
                return in_Log;
            }
            set
            {
                in_Log = value;
            }
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
        public bool Connect
        {
            get
            {
                return Get_Connect();
            }
            set
            {
                Set_Connect(value);
            }
        }
        public bool Auto_Reconnect
        {
            get
            {
                return in_Auto_Reconnect;
            }
            set
            {
                in_Auto_Reconnect = value;
            }
        }
        public double Reconnect_Time
        {
            get
            {
                return Reconnect_Timer.Interval;
            }
            set
            {
                Reconnect_Timer.Interval = value;
            }
        }
        public double Timeout_Time
        {
            get
            {
                return Timout_Timer.Interval;
            }
            set
            {
                Timout_Timer.Interval = value;
            }
        }
        public TMelsec_QPLC_Eth_Connect()
        {
            PLC_Socket.Host = "192.168.1.100";
            PLC_Socket.Port = 5010;

            //Header
            Header.Sub_Header = 0x5000;
            Header.Network_No = 0x00;
            Header.PC_No = 0xFF;
            Header.Request_Model_No = 0xFF03;
            Header.Request_Model_Station_No = 0x00;
            Header.Data_Length = 0;
            Header.CPU_Time = 0x0010;
            Header.Command = 0x0401;
            Header.SubCommand = 0x0000;

            in_Thread = new Thread(Execute);
            in_Thread.IsBackground = true;
            in_Thread.Start();

            //Reconnect_Timer
            Reconnect_Timer.Enabled = false;
            Reconnect_Timer.Interval = 1000;
            Reconnect_Timer.Elapsed += On_Reconnect_PLC;

            //Timer1
            Timout_Timer.Enabled = false;
            Timout_Timer.Interval = 500;
            Timout_Timer.Elapsed += On_TimeOut;
        }
        public void Dispose()
        {
            Terminate = true;
            while (Thread_ON)
            {
                Application.DoEvents();
            }
        }
        public void Execute()
        {
            bool old_connect = Connect;
            string fun = "Execute";

            Thread_ON = true;
            while (!Terminate)
            {
                if (!old_connect && Connect) Log_Add(fun, "[Base_PLC] Connect.");
                if (old_connect && !Connect) Log_Add(fun, "[Base_PLC] Disconnect.", emLog_Type.Error);

                if (!Connect && !Reconnect_Timer.Enabled && in_Auto_Reconnect) Reconnect_Timer.Enabled = true;
                if (Reconnect_Timer.Enabled && Connect) Reconnect_Timer.Enabled = false;

                old_connect = Connect;
                System.Threading.Thread.Sleep(10);
            }
            Thread_ON = false;
        }
        private void On_TimeOut(object sender, EventArgs e)
        {
            Timout_Timer.Enabled = false;
            FOn_TimeOut = true;
        }
        private void On_Reconnect_PLC(object sender, EventArgs e)
        {
            string fun = "Execute";

            Reconnect_Timer.Enabled = false;
            Log_Add(fun, "[On_Reconnect_PLC] 嘗試重新連線 PLC.");
            Connect = true;
            Thread.Sleep(500);
        }

        //---------------------------------------------------------------------------
        //max points=3584 point
        //---------------------------------------------------------------------------
        public bool Read_Bit(string start_code, ref bool[] read_data, int in_count)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int start_count = 0, read_count = 0;
            string fun = "Read_Bit";

            if (Log_Read_Write) Log_Add(fun, "Read_Bit");
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
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


                    if (Write_To_PLC(fun, Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
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
            FBusy = false;
            return result;
        }
        public bool Write_Bit(string start_code, bool[] write_data, int in_count)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int bit_count;
            int start_count, read_count;
            string fun = "Write_Bit";

            if (Log_Read_Write) Log_Add(fun, "Write_Bit");
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
            {
                Header.Command = 0x1401;
                Header.SubCommand = 0x0001;
                start_count = 0; read_count = 0;
                result = true;
                while (start_count < in_count && result)
                {
                    read_count = (ushort)(in_count - start_count);
                    if (read_count > 3584) read_count = 3584;

                    bit_count = (read_count - 1) / 2 + 1;
                    Header.Data_Length = (ushort)(12 + bit_count);
                    Header.Get_Char_Data(ref Write_Buffer);

                    Device_Tool.Break_Device(start_code, ref device_code, ref device_num);
                    index_code = Get_Index_Code(device_code);

                    Array.Copy(BitConverter.GetBytes(device_num + start_count), 0, Write_Buffer, 15, 3);
                    Write_Buffer[18] = (byte)index_code;
                    Array.Copy(BitConverter.GetBytes(read_count), 0, Write_Buffer, 19, 2);

                    Bool_To_Byte(write_data, 0, ref Write_Buffer, 21, read_count);
                    Write_Count = 21 + bit_count;

                    if (Write_To_PLC(fun, Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
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

            FBusy = false;
            return result;
        }

        //---------------------------------------------------------------------------
        //max word=960 word
        //---------------------------------------------------------------------------
        public bool Read_Byte(string start_code, ref ushort[] read_data, int in_count)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int start_count = 0, read_count = 0;
            string fun = "Read_Byte";

            if (Log_Read_Write) Log_Add(fun, string.Format("start_code={0:s}, Count={1:d}", start_code, in_count));
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
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

                    if (Write_To_PLC(fun, Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
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
            FBusy = false;
            return result;
        }
        public bool Write_Byte(string start_code, ushort[] write_data, int in_count)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int start_count = 0, read_count = 0;
            string fun = "Write_Byte";

            if (Log_Read_Write) Log_Add(fun, string.Format("start_code={0:s}, Count={1:d}", start_code, in_count));
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
            {
                Header.Command = 0x1401;
                Header.SubCommand = 0x0000;
                start_count = 0; read_count = 0;

                while (start_count < in_count)
                {
                    read_count = (ushort)(in_count - start_count);
                    if (read_count > 960) read_count = 960;

                    Header.Data_Length = (ushort)(12 + read_count * 2);
                    Header.Get_Char_Data(ref Write_Buffer);

                    Device_Tool.Break_Device(start_code, ref device_code, ref device_num);
                    index_code = Get_Index_Code(device_code);

                    Array.Copy(BitConverter.GetBytes(device_num + start_count), 0, Write_Buffer, 15, 3);
                    Write_Buffer[18] = (byte)index_code;
                    Array.Copy(BitConverter.GetBytes(read_count), 0, Write_Buffer, 19, 2);
                    UShort_To_Byte(write_data, start_count, ref Write_Buffer, 21, read_count);
                    Write_Count = 21 + read_count * 2;

                    if (Write_To_PLC(fun, Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
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
            FBusy = false;
            return result;
        }

        //---------------------------------------------------------------------------
        //max word=192 word
        //---------------------------------------------------------------------------
        public bool Random_Read_Byte(string[] device_list, ref ushort[] read_data)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int w_count, dw_count;
            int start_count, read_count;
            string[] code_list = new string[0];
            string fun = "Random_Read_Byte";

            if (Log_Read_Write) Log_Add(fun, "Random_Read_Byte");
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
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

                    Header.Data_Length = (ushort)(8 + read_count * 4);
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

                    if (Write_To_PLC(fun, Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
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
            FBusy = false;
            return result;
        }

        //---------------------------------------------------------------------------
        //max word=160 word
        //---------------------------------------------------------------------------
        public bool Random_Write_Byte(string[] device_list, ushort[] write_data)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int w_count, dw_count;
            int start_count, read_count;
            string[] code_list = new string[0];
            string fun = "Random_Write_Byte";

            if (Log_Read_Write) Log_Add(fun, "Random_Write_Byte");
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
            {
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

                    Header.Data_Length = (ushort)(8 + read_count * 6);
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

                    if (Write_To_PLC(fun, Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
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
            FBusy = false;
            return result;
        }

        //---------------------------------------------------------------------------
        //max word=??? bit
        //---------------------------------------------------------------------------
        public bool Random_Read_Bit(string[] device_list, ref bool[] read_data)
        {
            bool result = true;
            bool[] data = new bool[16];
            string fun = "Random_Read_Bit";

            if (Log_Read_Write) Log_Add(fun, "Random_Read_Bit");
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
            {
            }
            FBusy = false;
            return result;
        }
        public bool Random_Write_Bit(string[] device_list, bool[] write_data)
        {
            bool result = false;
            string device_code = "";
            int device_num = 0;
            char index_code = ' ';
            int w_count, dw_count;
            int start_count, read_count;
            string[] code_list = new string[0];
            string fun = "Random_Write_Bit";

            if (Log_Read_Write) Log_Add(fun, "Random_Write_Bit");
            Wait_Ready();
            FBusy = true;
            if (PLC_Socket.Connected)
            {
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

                    Header.Data_Length = (ushort)(8 + read_count * 5);
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

                    if (Write_To_PLC(fun, Write_Buffer, Write_Count, ref Read_Buffer, ref Read_Count))
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

            FBusy = false;
            return result;
        }

        public void Clear_Buffer()
        {
            string fun = "Clear_Buffer";
            string msg = "";

            if (PLC_Socket.Recive_Length > 0)
            {
                msg = string.Format("Recive_Length={0:d}", PLC_Socket.Recive_Length);
                Log_Add(fun, msg, emLog_Type.Warning);
            }
            PLC_Socket.Recive_Byte(PLC_Socket.Recive_Length);
        }



        private void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null && Log.Enabled) Log.Add(Log_Source, fun, msg, type);
        }
        private void Log_Add(string fun, byte[] data, int data_len)
        {
            Log_Add(fun, Byte_To_String(data, data_len));
        }
        private void Log_Add(string fun, string str, byte[] data, int data_len)
        {
            Log_Add(fun, str + Byte_To_String(data, data_len));
        }
        private bool Get_Connect()
        {
            return PLC_Socket.Connected;
        }
        private void Set_Connect(bool value)
        {
            if (value) PLC_Socket.Connect();
            else PLC_Socket.Disconnect();
        }
        private bool Socket_Read_Byte(ref byte[] data, ref int data_len)
        {
            bool result = true;
            string fun = "Socket_Read_Byte";

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
                    if (Log_Read_Write) Log_Add("Socket_Read_Byte", "Read=", data, data_len);
                    break;
                }
            }
            if (FOn_TimeOut) Log_Add(fun, "Read Timeout.", emLog_Type.Error);
            Timout_Timer.Enabled = false;

            return result;
        }
        private bool Socket_Write_Byte(byte[] data, int data_len)
        {
            bool result = false;
            int count = 0;
            if (Log_Read_Write) Log_Add("Socket_Write_Byte", "Write=", data, data_len);
            count = PLC_Socket.Send_Byte(data, data_len, SocketFlags.None);
            result = (count == data_len);
            return result;
        }
        private bool Write_To_PLC(string fun, byte[] write_buffer, int write_count, ref byte[] read_buffer, ref int read_count)
        {
            bool result = false;
            string sub_hender = "";
            int read_len = 0;
            Int16 error_code = 0;
            string error_code_str = "";
            string error_code_msg = "";
            string msg = "";

            read_count = 0;
            Array.Resize(ref read_buffer, 0);
            if (Connect)
            {
                Clear_Buffer();
                Socket_Write_Byte(write_buffer, write_count);

                if (write_count > 500) Timout_Timer.Interval = 5000;
                if (write_count < 500) Timout_Timer.Interval = 1000;

                Socket_Read_Byte(ref read_buffer, ref read_count);

                if (read_count >= 11)
                {
                    sub_hender = string.Format("{0:X2}{1:X2}", read_buffer[0], read_buffer[1]);
                    read_len = BitConverter.ToInt16(read_buffer, 7);
                    error_code = BitConverter.ToInt16(read_buffer, 9);
                    error_code_str = string.Format("{0:X4}", error_code);
                    error_code_msg = Get_Error_Code(error_code);

                    result = true;
                    if (error_code_str != "0000")
                    {
                        msg = string.Format("錯誤代碼={0:s} Msg={1:s}", error_code_str, error_code_msg);
                        Log_Add(fun, msg, emLog_Type.Error); ;
                        result = false;
                    };

                    if (sub_hender != "D000")
                    {
                        Log_Add(fun, "起始碼不正確。", emLog_Type.Error);
                        result = false;
                    };

                    if (read_len != read_buffer.Length - 9)
                    {
                        Log_Add(fun, "讀取資料長度不正確。", emLog_Type.Error);
                        result = false;
                    };
                }
                else
                {
                    Log_Add(fun, "接收資料長度小於11。", emLog_Type.Error);
                }
            }
            return result;
        }

        private string Get_Error_Code(int error_code)
        {
            string result = "";
            // 錯誤代碼說明
            // sh081105engg.pdf 
            // 16.7.3 Error codes stored in the buffer memory

            switch (error_code)
            {
                case 0x0000:
                    result = "OK";
                    break;

                default:
                    result = string.Format("{0:X4}", error_code);
                    break;
            }
            return result;
        }
        private char Get_Index_Code(string code)
        {
            return ((TQPLC_Device_Tool)Device_Tool).Get_Index_Code(code);
        }
        private void Wait_Ready()
        {
            while (FBusy) { };
        }
        private void Bool_To_Byte(bool[] in_data, int in_index, ref byte[] out_data, int out_index, int count)
        {
            int byte_no, bit_no;
            byte tmp_byte;

            for (int i = 0; i < count; i++)
            {
                byte_no = i / 2;
                bit_no = i % 2;
                tmp_byte = out_data[byte_no + out_index];
                if (bit_no == 0 && in_data[i + in_index])
                    tmp_byte = (byte)(tmp_byte | 0x10);
                else
                    tmp_byte = (byte)(tmp_byte & 0xEF);

                if (bit_no == 1 && in_data[i + in_index])
                    tmp_byte = (byte)(tmp_byte | 0x01);
                else
                    tmp_byte = (byte)(tmp_byte & 0xFE);

                out_data[byte_no + out_index] = tmp_byte;

            }
        }
        private void Byte_To_Bool(byte[] in_data, int in_index, ref bool[] out_data, int out_index, int count)
        {
            int byte_no, bit_no;

            for (int i = 0; i < count; i++)
            {
                byte_no = i / 2;
                bit_no = i % 2;
                if (bit_no == 0) out_data[i + out_index] = ((in_data[byte_no + in_index] & 0xF0) == 0x10);
                if (bit_no == 1) out_data[i + out_index] = ((in_data[byte_no + in_index] & 0x0F) == 0x01);
            }
        }
        private void UShort_To_Byte(ushort[] in_data, int in_index, ref byte[] out_data, int out_index, int ushort_count)
        {
            for (int i = 0; i < ushort_count; i++)
            {
                Array.Copy(BitConverter.GetBytes(in_data[i + in_index]), 0, out_data, i * 2 + out_index, 2);
            }
        }
        private void Byte_To_UShort(byte[] in_data, int in_index, ref ushort[] out_data, int out_index, int ushort_count)
        {
            if (in_data.Length >= (in_index + ushort_count))
            {
                for (int i = 0; i < ushort_count; i++)
                {
                    out_data[i + out_index] = BitConverter.ToUInt16(in_data, i * 2 + in_index);
                }
            }
        }
        private string Byte_To_String(byte[] data, int data_len)
        {
            string result = "";

            for (int i = 0; i < data_len; i++)
            {
                if (result != "") result = result + " ";
                result = result + String_Tool.IntToHexStr(data[i], 2);
            }

            return result;
        }
    }
}
