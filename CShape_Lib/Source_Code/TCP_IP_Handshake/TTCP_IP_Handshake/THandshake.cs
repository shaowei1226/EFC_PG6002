using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Timers;
using EFC.Tool;
using HalconDotNet;


namespace EFC.TCP_Handshake
{
    public delegate void evHS_SocketEvent(TJJS_Socket s_socket, THS_Socket_Read read);

    static public class HS_Tool
    {
        static public int Copy_Bytes(byte[] sor_data, int sor_start, byte[] dis_data, int dis_start, int len)
        {
            int result = 0;

            if ( sor_start + len <= sor_data.Length &&  dis_start + len <= dis_data.Length)
            {
                Array.Copy(sor_data, sor_start, dis_data, dis_start, len);
                result = len;
            }
            return result;
        }
        static public int Copy_Bytes(byte[] sor_data, byte[] dis_data, int dis_start = 0)
        {
            return Copy_Bytes(sor_data, 0, dis_data, dis_start, sor_data.Length);
        }
        static public int Copy_Bytes(bool value, byte[] dis_data, int dis_start = 0)
        {
            return Copy_Bytes(BitConverter.GetBytes(value), dis_data, dis_start);
        }
        static public int Copy_Bytes(byte value, byte[] dis_data, int dis_start = 0)
        {
            int result = 0;

            if (dis_start + 1 <= dis_data.Length)
            {
                dis_data[dis_start] = value;
                result = 1;
            }
            return result;
        }
        static public int Copy_Bytes(int value, byte[] dis_data, int dis_start = 0)
        {
            return Copy_Bytes(BitConverter.GetBytes(value), dis_data, dis_start);
        }
        static public int Copy_Bytes(double value, byte[] dis_data, int dis_start = 0)
        {
            return Copy_Bytes(BitConverter.GetBytes(value), dis_data, dis_start);
        }
        static public int Copy_Bytes(string value, byte[] dis_data, int dis_start = 0)
        {
            return Copy_Bytes(String_To_Byte(value), dis_data, dis_start);
        }
        static public int Copy_Bytes(string value, byte[] dis_data, int dis_start, int fix_len)
        {
            string tmp_str = value;
            byte[] tmp_byte = new byte[fix_len];

            Set_Byte(0x00, tmp_byte, 0, fix_len);
            if (tmp_str.Length > fix_len) tmp_str = tmp_str.Substring(0, fix_len);
            Copy_Bytes(tmp_str, tmp_byte, 0);

            return Copy_Bytes(tmp_byte, dis_data, dis_start);
        }
        static public int Copy_Bytes(IntPtr sor_data, byte[] dis_data, int dis_start, int sor_len)
        {
            int result = 0;

            if (dis_start + sor_len <= dis_data.Length)
            {
                Marshal.Copy(sor_data, dis_data, dis_start, sor_len);
                result = sor_len;
            }
            return result;
        }


        static public int Get_Bytes(byte[] sor_data, int sor_start, int get_len, ref byte[] dis_data)
        {
            return Get_Bytes(sor_data, sor_data.Length, sor_start, get_len, ref dis_data);
        }
        static public int Get_Bytes(byte[] sor_data, int sor_length, int sor_start, int get_len, ref byte[] dis_data)
        {
            int result = 0;

            if (sor_start + get_len <= sor_length)
            {
                Array.Resize(ref dis_data, get_len);
                Array.Copy(sor_data, sor_start, dis_data, 0, get_len);
                result = get_len;
            }
            else
            {
                Array.Resize(ref dis_data, 0);
            }
            return result;
        }
        static public int Get_Bytes(byte[] sor_data, int sor_length, int sor_start, ref byte dis_data)
        {
            int result = 0;

            if (sor_start + 1 <= sor_length)
            {
                dis_data = sor_data[sor_start];
                result = 1;
            }
            return result;
        }

        static public int Get_Bytes_Bool(byte[] sor_data, int sor_start, ref bool value)
        {
            return Get_Bytes_Bool(sor_data, sor_data.Length, sor_start, ref value);
        }
        static public int Get_Bytes_Bool(byte[] sor_data, int sor_length, int sor_start, ref bool value)
        {
            int result = 0;
            byte[] tmp_byte = BitConverter.GetBytes(value);

            if (sor_start + tmp_byte.Length <= sor_length)
            {
                value = BitConverter.ToBoolean(sor_data, sor_start);
                result = tmp_byte.Length;
            }
            return result;
        }

        static public int Get_Bytes_Int32(byte[] sor_data, int sor_start, ref int value)
        {
            return Get_Bytes_Int32(sor_data, sor_data.Length, sor_start, ref value);
        }
        static public int Get_Bytes_Int32(byte[] sor_data, int sor_length, int sor_start, ref int value)
        {
            int result = 0;
            byte[] tmp_byte = BitConverter.GetBytes(value);

            if (sor_start + tmp_byte.Length < sor_length)
            {
                value = BitConverter.ToInt32(sor_data, sor_start);
                result = tmp_byte.Length;
            }
            return result;
        }

        static public int Get_Bytes_Double(byte[] sor_data, int sor_start, ref double value)
        {
            return Get_Bytes_Double(sor_data, sor_data.Length, sor_start, ref value);
        }
        static public int Get_Bytes_Double(byte[] sor_data, int sor_length, int sor_start, ref double value)
        {
            int result = 0;
            byte[] tmp_byte = BitConverter.GetBytes(value);

            if (sor_start + tmp_byte.Length < sor_length)
            {
                value = BitConverter.ToDouble(sor_data, sor_start);
                result = tmp_byte.Length;
            }
            return result;
        }

        static public int Get_Bytes_String(byte[] sor_data, ref string value)
        {
            return Get_Bytes_String(sor_data, sor_data.Length, 0, sor_data.Length, ref value);
        }
        static public int Get_Bytes_String(byte[] sor_data, int sor_start, int max_len, ref string value)
        {
            return Get_Bytes_String(sor_data, sor_data.Length, sor_start, max_len, ref value);
        }
        static public int Get_Bytes_String(byte[] sor_data, int sor_length, int sor_start, int max_len, ref string value)
        {
            int result = 0;

            if (sor_start + max_len <= sor_length)
            {
                value = Byte_To_String(sor_data, sor_start, max_len);
                result = max_len;
            }
            return result;
        }



        static public void Set_Byte(byte value, byte[] data, int start, int len)
        {
            if (start + len <= data.Length)
            {
                for (int i = start; i < start + len; i++)
                {
                    data[i] = value;
                }
            }
        }
        static public int Pos(byte[] cmp_data, byte[] data, int length)
        {
            int result = -1;
            bool find = false;

            for (int i = 0; i < length; i++ )
            {
                find = true;
                for(int j=0; j<cmp_data.Length; j++)
                {
                    if (cmp_data[j] != data[i+j])
                    {
                        find = false;
                        break;
                    }
                }

                if (find)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        static public byte[] Bool_To_Byte(bool data)
        {
            byte[] result = BitConverter.GetBytes(data);
            return result;
        }
        static public byte[] Int_To_Byte(int data)
        {
            byte[] result = BitConverter.GetBytes(data);
            return result;
        }
        static public byte[] Double_To_Byte(double data)
        {
            byte[] result = BitConverter.GetBytes(data);
            return result;
        }
        static public byte[] String_To_Byte(string str)
        {
            byte[] result = System.Text.Encoding.Default.GetBytes(str);
            return result;
        }
        static public byte[] HImage_To_Byte(HImage image)
        {
            byte[] result = null;
            string type = "";
            int w = 0 ,h =0;
            int len = 0;

            IntPtr ptr = image.GetImagePointer1(out type, out w, out h);
            len = w * h;
            result = new byte[len + 8];
            Array.Copy(Int_To_Byte(w), 0, result, 0, 4);
            Array.Copy(Int_To_Byte(h), 0, result, 4, 4);
            Marshal.Copy(ptr, result, 8, len);
            return result;
        }

        static public bool Byte_To_Bool(byte[] data, int start = 0)
        {
            return BitConverter.ToBoolean(data, start);
        }
        static public int Byte_To_Int(byte[] data, int start = 0)
        {
            return BitConverter.ToInt32(data, start);
        }
        static public double Byte_To_Double(byte[] data, int start = 0)
        {
            return BitConverter.ToDouble(data, start);
        }
        static public string Byte_To_String(byte[] data)
        {
            return Byte_To_String(data, 0, data.Length);
        }
        static public string Byte_To_String(byte[] data, int start, int len)
        {
            string result = "";

            if (start + len <= data.Length)
            {
                for (int i = start; i < start + len; i++)
                {
                    if (data[i] == 0x00) break;
                    result = result + (char)data[i];
                }
            }
            return result;
        }
        static public HImage Byte_To_HImage(byte[] data)
        {
            HImage result = null;
            int w, h;

            w = BitConverter.ToInt32(data, 0);
            h = BitConverter.ToInt32(data, 4);

            if (data.Length >= w * h + 8)
            {
                result = new HImage();
                result.GenImage1("byte", w, h, Byte_To_IntPtr(data, 8));
            }
            return result;
        }

        static public byte[] IntPtr_To_Byte(IntPtr in_data, int len)
        {
            byte[] result = new byte[len];
            Marshal.Copy(in_data, result, 0, len);
            return result;
        }
        static public IntPtr Byte_To_IntPtr(byte[] in_data)
        {
            return Byte_To_IntPtr(in_data, 0);
        }
        static public IntPtr Byte_To_IntPtr(byte[] in_data, int start)
        {
            IntPtr result = new IntPtr();
            unsafe
            {
                fixed (byte* p = in_data)
                {
                    result = (IntPtr)(p + start);
                }
            }
            return result;
        }
        static public bool Get_Bit(int idata, int bit_no)
        {
            bool result;
            int flag;

            flag = 0x0001;
            flag = flag << bit_no;
            if ((idata & flag) == flag) result = true;
            else result = false;
            return result;
        }
        static public void Set_Bit(ref int idata, int bit_no, bool value)
        {
            int flag1, flag2;

            flag1 = 0x0001;
            flag1 = flag1 << bit_no;
            flag2 = flag1 ^ 0xFFFF;
            if (value) idata = (idata & flag2) | flag1;
            else idata = (idata & flag2);
        }
    }

    //----------------------------------------------------------------------------------
    //-- THS_Socket_Infos
    //----------------------------------------------------------------------------------
    public class THS_Socket_Infos : CollectionBase
    {
        public THS_Socket_Infos()
        {

        }
        public THS_Socket_Info this[int index]
        {
            get
            {
                return Get_Info(index);
            }
            set
            {
                THS_Socket_Info socket = null;
                socket = Get_Info(index);
                if (socket != null) socket.Set(value);
            }
        }
        public void Add(THS_Socket_Info socket)
        {
            List.Add(socket);
        }
        public void Add(TJJS_Socket socket)
        {
            THS_Socket_Info tmp_socket = new THS_Socket_Info();
            tmp_socket.JJS_Socket = socket;
            List.Add(tmp_socket);
        }
        public THS_Socket_Info Get_Info(int index)
        {
            THS_Socket_Info result = null;

            if (index >= 0 && index < Count)
            {
                result = (THS_Socket_Info)List[index];
            }
            return result;
        }
        public THS_Socket_Info Get_Info(TJJS_Socket socket)
        {
            THS_Socket_Info result = null;
            THS_Socket_Info tmp_socket = null;

            for (int i = 0; i < Count; i++)
            {
                tmp_socket = (THS_Socket_Info)List[i];
                if (socket == tmp_socket.JJS_Socket)
                {
                    result = tmp_socket;
                    break;
                }
            }
            return result;
        }
        public void Remove(TJJS_Socket socket)
        {
            THS_Socket_Info info = Get_Info(socket);

            if (info != null) List.Remove(info);
        }
    }
    public class THS_Socket_Info : TBase_Class
    {
        public TJJS_Socket JJS_Socket = null;
        public bool Connected = false;
        public string Name = "";
        public string IP = "";
        public string Recipe_Name = "";


        public THS_Socket_Info()
        {

        }
        override public TBase_Class New_Class()
        {
            return new THS_Socket_Info();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is THS_Socket_Info && dis_base is THS_Socket_Info)
            {
                THS_Socket_Info sor = (THS_Socket_Info)sor_base;
                THS_Socket_Info dis = (THS_Socket_Info)dis_base;

                dis.JJS_Socket = sor.JJS_Socket;
                dis.Name = sor.Name;
                dis.IP = sor.IP;
            }
        }
        public THS_Value_List Get_Values()
        {
            THS_Value_List result = new THS_Value_List();
            result.Add(IP);
            result.Add(Name);
            result.Add(Recipe_Name);
            return result;
        }
        public void Set_Values(THS_Value_List values)
        {
            if (values.Count >= 4)
            {
                IP = values[1].Get_Data_String();
                Name = values[2].Get_Data_String();
                Recipe_Name = values[3].Get_Data_String();
                Connected = true;
            }
        }
    }
    public class THS_Command_Lists : CollectionBase
    {
        public bool Reflash = false;

        public THS_Command_Lists()
        {

        }
        public THS_Command this[int index]
        {
            get
            {
                return Get_Command(index);
            }
            set
            {
                THS_Command cmd = null;
                cmd = Get_Command(index);
                if (cmd != null) cmd.Set(value);
            }
        }
        public void Add(THS_Command cmd)
        {
            List.Add(cmd);
            Reflash = true;
        }
        public THS_Command Get_Command(int index)
        {
            THS_Command result = null;

            if (index >= 0 && index < Count)
            {
                result = (THS_Command)List[index];
            }
            return result;
        }
        public THS_Command Get_Command(THS_Command cmd)
        {
            THS_Command result = null;
            THS_Command tmp_cmd = null;

            for (int i = 0; i < Count; i++)
            {
                tmp_cmd = (THS_Command)List[i];
                if (cmd == tmp_cmd)
                {
                    result = tmp_cmd;
                    break;
                }
            }
            return result;
        }
        public void Remove(THS_Command cmd)
        {
            THS_Command info = Get_Command(cmd);

            if (info != null)
            {
                List.Remove(info);
                Reflash = true;
            }
        }
        public void RemoveAt(int no)
        {
            List.RemoveAt(no);
            Reflash = true;
        }
        public void Display_List(System.Windows.Forms.ListBox list_box)
        {
            if (Reflash)
            {
                list_box.Items.Clear();
                for (int i = 0; i < Count; i++) list_box.Items.Add(this[i].ToString());
            }
            Reflash = false;
        }

    }
    public class THS_Command : TBase_Class
    {
        public THS_Socket_Send Send_Ptr = null;
        public THS_Socket_Read Read_Ptr = null;
        public bool Timeout = false;


        public THS_Command()
        {

        }
        override public TBase_Class New_Class()
        {
            return new THS_Command();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is THS_Command && dis_base is THS_Command)
            {
                THS_Command sor = (THS_Command)sor_base;
                THS_Command dis = (THS_Command)dis_base;

                dis.Send_Ptr = sor.Send_Ptr;
                dis.Read_Ptr = sor.Read_Ptr;
                dis.Timeout = sor.Timeout;
            }
        }
        public string ToString()
        {
            string result = "";
            string time = Send_Ptr.Time.ToString("hh:mm:ss");

            result = string.Format("CMD={0:s} Code={1:d} Time={2:s}", Send_Ptr.CMD, Send_Ptr.System_Code, time);
            return result;
        }
    }

    public class THS_Command_Log : TLog
    {
        public THS_Command_Log()
        {

        }

    }
    //----------------------------------------------------------------------------------
    //-- THS_Server
    //----------------------------------------------------------------------------------
    public class THS_Socket_Base
    {
        public TLog Log = null;
        public TLog HS_Log = null;
        //public THS_Command_Lists CMD = new THS_Command_Lists();
        public int System_Code = 0;


        public THS_Socket_Base()
        {
        }
        public void Dispone()
        {
        }
        public void Log_Add(string msg)
        {
            if (Log != null) Log.Add(msg);
        }

        public void HS_Log_Add(string msg)
        {
            if (HS_Log != null) HS_Log.Add(msg);
        }
        public void HS_Log_Add(THS_Socket_Send send)
        {
            string str = "";
            string time = "";

            str = string.Format("[Send ->] CMD = {0:s}, Code = {1:d}", send.CMD, send.System_Code);
            HS_Log_Add(str);
        }
        public void HS_Log_Add(THS_Socket_Read read)
        {
            string str = "";

            str = string.Format("[Recv <-] CMD = {0:s}, Code = {1:d}", read.CMD, read.System_Code);
            HS_Log_Add(str);
        }
        public void HS_Log_Timeout(THS_Socket_Send send)
        {
            string str = "";

            str = string.Format("[Timeout] CMD = {0:s}, Code = {1:d}", send.CMD, send.System_Code);
            HS_Log_Add(str);
        }

        //Command
        public void Send(TJJS_Socket socket, THS_Socket_Send send)
        {
            THS_Command cmd = new THS_Command();
            if (socket.Connected)
            {
                send.Update();
                //cmd.Send_Ptr = send;
                //cmd.Send_Ptr.Time = DateTime.Now;
                //CMD.Add(cmd);
                HS_Log_Add(send);

                Log_Send(send);
                socket.Send_Byte(send.Data);
            }
        }
        public void Send_Connect_Req(TJJS_Socket socket, THS_Socket_Info info)
        {
            THS_Socket_Send send = new THS_Socket_Send();
            send.Timeout_Time = 3000;
            send.Values.Add("Connect");
            send.Values.Add(System_Code++);
            send.Values.Add(info.Get_Values());
            Send(socket, send);
        }
        public void Send_Connect_Apply(TJJS_Socket socket, int system_code)
        {
            THS_Socket_Send send = new THS_Socket_Send();
            send.Values.Add("Connect@");
            send.Values.Add(system_code);
            Send(socket, send);
        }
        public void Send_Disconnect_Req(TJJS_Socket socket, THS_Socket_Info info)
        {
            THS_Socket_Send send = new THS_Socket_Send();
            send.Values.Add("Disconnect");
            send.Values.Add(info.Get_Values());
            Send(socket, send);
        }
        public void Send_Disconnect_Apply(TJJS_Socket socket)
        {
            THS_Socket_Send send = new THS_Socket_Send();
            send.Values.Add("Disconnect@");
            Send(socket, send);
        }
        public void Send_Link_Test_Req(TJJS_Socket socket)
        {
            THS_Socket_Send send = new THS_Socket_Send();
            send.Values.Add("Link_Test");
            Send(socket, send);
        }
        public void Send_Link_Apply(TJJS_Socket socket)
        {
            THS_Socket_Send send = new THS_Socket_Send();
            send.Values.Add("Link_Test@");
            Send(socket, send);
        }

        public THS_Socket_Read Recive(TJJS_Socket socket)
        {
            THS_Socket_Read result = null;
            byte[] recive_byte = null;
            int data_len = 0;

            if (Socket_Length_OK(socket.Buffer, socket.Recive_Length))
            {
                result = new THS_Socket_Read();
                data_len = Get_Data_Length(socket.Buffer, socket.Recive_Length);
                recive_byte = socket.Recive_Byte(data_len);
                result.Set_Data(recive_byte);
                Log_Read(result);
                HS_Log_Add(result);
            }
            return result;
        }

        public void Log_Read(THS_Socket_Read read)
        {
            THS_Base_Value value = null;
            string str = "";

            //Log_Add(string.Format("[Recv <-] Data Size = {0:d}", read.Data.Length));
            for (int i = 0; i < read.Values.Count; i++)
            {
                value = read.Values[i];
                switch (value.Type)
                {
                    case HS_Type.Bool:   str = string.Format("[{0:d2},Bool] = {1:s}", i + 1, value.Get_Data_Bool() ? "1" : "0"); break;
                    case HS_Type.Int:    str = string.Format("[{0:d2},Int] = {1:d}", i + 1, value.Get_Data_Int()); break;
                    case HS_Type.Double: str = string.Format("[{0:d2},Double] = {1:f3}", i + 1, value.Get_Data_Double()); break;
                    case HS_Type.String: str = string.Format("[{0:d2},String] = {1:s}", i + 1, value.Get_Data_String()); break;
                    case HS_Type.Image:  str = string.Format("[{0:d2},Image]", i + 1); break;
                }
                Log_Add("[Recv <-]" + str);
            }
        }
        public void Log_Send(THS_Socket_Send send)
        {
            THS_Base_Value value = null;
            string str = "";

            Log_Add(string.Format("[Send ->] Data Size = {0:d}", send.Data.Length));
            for (int i = 0; i < send.Values.Count; i++)
            {
                value = send.Values[i];
                switch (value.Type)
                {
                    case HS_Type.Bool:   str = string.Format("[{0:d2},Bool] = {1:s}", i + 1, value.Get_Data_Bool() ? "1" : "0"); break;
                    case HS_Type.Int:    str = string.Format("[{0:d2},Int] = {1:d}", i + 1, value.Get_Data_Int()); break;
                    case HS_Type.Double: str = string.Format("[{0:d2},Double] = {1:f3}", i + 1, value.Get_Data_Double()); break;
                    case HS_Type.String: str = string.Format("[{0:d2},String] = {1:s}", i + 1, value.Get_Data_String()); break;
                    case HS_Type.Image:  str = string.Format("[{0:d2},Image]", i + 1); break;
                }
                Log_Add("[Send <-]" + str);
            }
        }
        public int Get_Data_Length(byte[] data, int len)
        {
            int result = 0;

            if (len < data.Length && len >= 4)
                result = BitConverter.ToInt32(data, 0);
            return result;
        }
        public bool Socket_Length_OK(byte[] buffer, int buffer_len)
        {
            bool result = false;
            int data_len = 0;

            data_len = Get_Data_Length(buffer, buffer_len);
            if (data_len > 0 && data_len <= buffer_len) result = true;
            return result;
        }
        public double Sub_Time(DateTime s_time, DateTime e_time)
        {
            double result = 0;

            TimeSpan tt = e_time - s_time;
            result = tt.TotalMilliseconds;
            return result;
        }
        public bool Is_Timeout(DateTime time, double timeout_time)
        {
            bool result = false;

            if (Sub_Time(time, DateTime.Now) > timeout_time) result = true;
            return result;
        }

    }
    public class THS_Server : THS_Socket_Base
    {
        public TJJS_ServerSockect Socket = new TJJS_ServerSockect();
        public THS_Socket_Infos Infos = new THS_Socket_Infos();
        public bool Terminate = false;
        public evHS_SocketEvent On_Recive = null;
        private Thread In_Thread = null;

        public string Host
        {
            get
            {
                return Socket.Host;
            }
            set
            {
                Socket.Host = value;
            }
        }
        public int Port
        {
            get
            {
                return Socket.Port;
            }
            set
            {
                Socket.Port = value;
            }
        }
        public bool Connected
        {
            get
            {
                return Socket.Connected;
            }
        }


        public THS_Server()
        {
            Socket.OnClientConnect += In_OnClientConnect;
            Socket.OnClientDisconnect += In_OnClientDisconnect;
            Socket.OnClientRecive += In_OnClientRecive;

            In_Thread = new Thread(Execute);
            In_Thread.IsBackground = true;
            In_Thread.Start();
        }
        public void Dispose()
        {
            base.Dispone();
            Terminate = true;
        }
        public void Execute()
        {
            while (!Terminate)
            {
                //if (!Socket.Connected && !Timer_Reconnect.Enabled && In_Auto_Reconnect) Timer_Reconnect.Enabled = true;
                //if (Socket.Connected && !Info.Selected && !Info.On_Select) Send_Connect_Req();

                System.Threading.Thread.Sleep(1);
            }
        }
        public void Connect()
        {
            Socket.Connect();
        }
        public void Set_Info(TJJS_Socket socket, THS_Socket_Read read)
        {
            THS_Socket_Info info = Infos.Get_Info(socket);
            if (info != null) info.Set_Values(read.Values);
        }
      

        private void In_OnClientConnect(TJJS_Socket s_socket)
        {
            string str = "";
            str = string.Format("On_Client_Connect. IP={0:s}", s_socket.Get_Host_Name());
            Infos.Add(s_socket);
            Log_Add(str);
        }
        private void In_OnClientDisconnect(TJJS_Socket s_socket)
        {
            Log_Add("On_Client_Disconnect");
            Infos.Remove(s_socket);
        }
        private void In_OnClientRecive(TJJS_Socket s_socket)
        {
            THS_Socket_Read read = null;
            //Log_Add(string.Format("[Recv <-] Buffer Size = {0:d}", s_socket.Recive_Length));

            read = Recive(s_socket);
            while (read != null)
            {
                switch (read.CMD)
                {
                    case "Connect":
                        Socket tt = s_socket.Socket;
                        Set_Info(s_socket, read);
                        Send_Connect_Apply(s_socket, read.System_Code);
                        break;

                    case "Link_Test": Send_Link_Apply(s_socket); break;
                }
                if (On_Recive != null) On_Recive(s_socket, read);
                read = Recive(s_socket);
            }
        }
    }
    public class THS_Client: THS_Socket_Base
    {
        public TJJS_ClientSockect Socket = new TJJS_ClientSockect();
        public THS_Socket_Info Info = new THS_Socket_Info();
        public bool Terminate = false;
        public int Link_Test_Time = 30;
        public evHS_SocketEvent On_Recive = null;


        private bool In_Auto_Reconnect = true;
        private System.Timers.Timer Timer_Reconnect = new System.Timers.Timer();
        private Thread In_Thread = null;
        private bool Connecting = false;
        private bool Link_Testing = false;
        private DateTime Time_Link_Test;
        
        public string Host
        {
            get
            {
                return Socket.Host;
            }
            set
            {
                Socket.Host = value;
            }
        }
        public int Port
        {
            get
            {
                return Socket.Port;
            }
            set
            {
                Socket.Port = value;
            }
        }
        public bool Connected
        {
            get
            {
                return Socket.Connected;
            }
        }
        public bool Auto_Reconnect
        {
            get
            {
                return In_Auto_Reconnect;
            }
            set
            {
                In_Auto_Reconnect = value;
            }
        }
        public double Reconnect_Time
        {
            get
            {
                return Timer_Reconnect.Interval;
            }
            set
            {
                Timer_Reconnect.Interval = value;
            }
        }
        
        
        public THS_Client()
        {
            Socket.OnConnect += In_OnConnect;
            Socket.OnDisconnect += In_OnDisconnect;
            Socket.OnRecive += In_OnRecive;

            Socket.Buffer_Max_Length = 32000000;

            Timer_Reconnect.Enabled = false;
            Timer_Reconnect.Interval = 5000;
            Timer_Reconnect.Elapsed += On_Reconnect;

            In_Thread = new Thread(Execute);
            In_Thread.IsBackground = true;
            In_Thread.Start();

            Info.IP = Socket.Host;
            Info.Name = "AOI_001";
        }
        public void Dispose()
        {
            base.Dispone();
            Terminate = true;
        }
        public void Execute()
        {
            while (!Terminate)
            {
                //Auto Socket Connect
                if (!Socket.Connected && !Timer_Reconnect.Enabled && In_Auto_Reconnect) Timer_Reconnect.Enabled = true;

                //Auto Potocol Connect
                if (Socket.Connected && !Info.Connected && !Connecting)
                {
                    Connecting = true;
                    Send_Connect_Req(Socket, Info);
                }

                //Auto Link Test
                if (Socket.Connected && Info.Connected && !Link_Testing && Is_Timeout(Time_Link_Test, Link_Test_Time * 1000))
                {
                    Link_Testing = true;
                    Time_Link_Test = DateTime.Now;
                    Send_Link_Test_Req(Socket);
                }

                Remove_Timeout();

                System.Threading.Thread.Sleep(1);
            }
        }
        public void Connect()
        {
            Socket.Connect();
        }
        public void Disconnect()
        {
            Socket.Disconnect();
            Connecting = false;
        }
        public void Remove_Timeout()
        {
            //int no = 0;
            //while(no < CMD.Count)
            //{
            //    if (CMD[no].Send_Ptr.Timeout())
            //    {
            //        HS_Log_Timeout(CMD[no].Send_Ptr);
            //        switch (CMD[no].Send_Ptr.CMD)
            //        {
            //            case "Connect": Connect_Timeout(CMD[no].Send_Ptr); break;
            //            case "Link_Test": Link_Test_Timeout(CMD[no].Send_Ptr); break;
            //        }
            //        CMD.RemoveAt(no);
            //    }
            //    else no++;
            //}
        }


        //Command
        public void Send(THS_Socket_Send send)
        {
            Send(Socket, send);
        }
        public void Send_Connect_Req()
        {
            Send_Connect_Req(Socket, Info);
        }
        public void Send_Disconnect_Req()
        {
            Info.Connected = false;
            Send_Disconnect_Req(Socket, Info);
        }
        public void Send_Disonnect_Apply()
        {
            Send_Disconnect_Apply(Socket);
        }
        public void Send_Link_Test_Req()
        {
            Send_Link_Test_Req(Socket);
        }
        public void Send_Link_Apply()
        {
            Send_Link_Apply(Socket);
        }



        private void On_Reconnect(object sender, EventArgs e)
        {
            Log_Add("嘗試重新連線.");
            Socket.Connect();
            Thread.Sleep(1000);
            Timer_Reconnect.Enabled = false;
        }
        private void In_OnConnect(TJJS_Socket s_socket)
        {
            Timer_Reconnect.Enabled = false;
            Log_Add("Connect");
        }
        private void In_OnDisconnect(TJJS_Socket s_socket)
        {
            Log_Add("Disconnect");
        }
        private void In_OnRecive(TJJS_Socket s_socket)
        {
            THS_Socket_Read read = null;
            //Log_Add(string.Format("[Recv <-] Buffer Size = {0:d}", s_socket.Recive_Length));

            read = Recive(s_socket);
            while (read != null)
            {
                switch (read.CMD)
                {
                    case "Connect@": Connect_Apply(read); break;
                    case "Link_Test": Send_Link_Apply(s_socket); break;
                    case "Link_Test@": Link_Test_Apply(read); break;
                }
                if (On_Recive != null) On_Recive(s_socket, read);
                Remove_CMD(read);
                read = Recive(s_socket);
            }
        }
        private void Remove_CMD(THS_Socket_Read read)
        {
            //THS_Command cmd = null;
            //int no = 0;

            //while(no < CMD.Count)
            //{
            //    cmd = CMD[no];
            //    if ((cmd.Send_Ptr.CMD + "@") == read.CMD && cmd.Send_Ptr.System_Code == read.System_Code)
            //        CMD.RemoveAt(no);
            //    else no++;
            //}
        }
        private void Connect_Apply(THS_Socket_Read read)
        {
            Connecting = false; 
            Info.Connected = true;
            Time_Link_Test = DateTime.Now;
        }
        private void Connect_Timeout(THS_Socket_Send send)
        {
            Connecting = false;
            Info.Connected = false;
        }
        private void Link_Test_Apply(THS_Socket_Read read)
        {
            Link_Testing = false;
            Time_Link_Test = DateTime.Now;
        }
        private void Link_Test_Timeout(THS_Socket_Send send)
        {
            Info.Connected = false;
            Link_Testing = false;
            Time_Link_Test = DateTime.Now;
        }
    }

    
    //----------------------------------------------------------------------------------
    //-- THS_Base_Value
    //----------------------------------------------------------------------------------
    public enum HS_Type { None = 0, Int = 1, Double = 2, String = 3, Image = 4 , Bool = 5, Array_Byte = 6};
    public class THS_Base_Value
    {
        public byte[] Data = new byte[0];

        private int Hand_Size = 6;
        private HS_Type inType = HS_Type.None;

        public HS_Type Type
        {
            get
            {
                return inType;
            }
        }
        public int Byte_Size
        {
            get
            {
                return Data_Size + Hand_Size;
            }
        }
        public int Data_Size
        {
            get
            {
                return Data.Length;
            }
            set
            {
                Array.Resize(ref Data, value);
            }
        }
        public THS_Base_Value()
        {

        }
        public THS_Base_Value(bool in_data)
        {
            Set_Data(in_data);
        }
        public THS_Base_Value(int in_data)
        {
            Set_Data(in_data);
        }
        public THS_Base_Value(double in_data)
        {
            Set_Data(in_data);
        }
        public THS_Base_Value(string in_data)
        {
            Set_Data(in_data);
        }
        public THS_Base_Value(HImage in_data)
        {
            Set_Data(in_data);
        }
        public THS_Base_Value(byte[] in_data)
        {
            Set_Data(in_data);
        }


        public void Set_Data(bool in_data)
        {
            byte[] tmp_data = HS_Tool.Bool_To_Byte(in_data);
            inType = HS_Type.Bool;
            Data_Size = tmp_data.Length;
            Array.Copy(tmp_data, 0, Data, 0, tmp_data.Length);
        }
        public void Set_Data(int in_data)
        {
            byte[] tmp_data = HS_Tool.Int_To_Byte(in_data);
            inType = HS_Type.Int;
            Data_Size = tmp_data.Length;
            Array.Copy(tmp_data, 0, Data, 0, tmp_data.Length);
        }
        public void Set_Data(double in_data)
        {
            byte[] tmp_data = HS_Tool.Double_To_Byte(in_data);
            inType = HS_Type.Double;
            Data_Size = tmp_data.Length;
            Array.Copy(tmp_data, 0, Data, 0, tmp_data.Length);
        }
        public void Set_Data(string in_data)
        {
            byte[] tmp_data = HS_Tool.String_To_Byte(in_data);
            inType = HS_Type.String;
            Data_Size = tmp_data.Length;
            Array.Copy(tmp_data, 0, Data, 0, tmp_data.Length);
        }
        public void Set_Data(HImage in_data)
        {
            byte[] tmp_data = HS_Tool.HImage_To_Byte(in_data);
            inType = HS_Type.Image;
            Data_Size = tmp_data.Length;
            Array.Copy(tmp_data, 0, Data, 0, tmp_data.Length);
        }
        public void Set_Data(byte[] in_data)
        {
            inType = HS_Type.Array_Byte;
            Data_Size = in_data.Length;
            Array.Copy(in_data, 0, Data, 0, in_data.Length);
        }
        public bool Get_Data_Bool()
        {
            bool result = false;
            if (inType == HS_Type.Bool)
                result = HS_Tool.Byte_To_Bool(Data);

            return result;
        }
        public int Get_Data_Int()
        {
            int result = 0;
            if (inType == HS_Type.Int)
                result = HS_Tool.Byte_To_Int(Data);

            return result;
        }
        public double Get_Data_Double()
        {
            double result = 0;
            if (inType == HS_Type.Double)
                result = HS_Tool.Byte_To_Double(Data);

            return result;
        }
        public string Get_Data_String()
        {
            string result = "";

            if (inType == HS_Type.String)
                result = HS_Tool.Byte_To_String(Data);
            return result;
        }
        public HImage Get_Data_HImage()
        {
            HImage result = null;

            if (inType == HS_Type.Image)
                result = HS_Tool.Byte_To_HImage(Data);
            return result;
        }
        public byte[] Get_Data_Array_Byte()
        {
            byte[] result = null;

            if (inType == HS_Type.Array_Byte)
                result = Data;
            return result;
        }
        public byte[] Get_Byte()
        {
            int no = 0;
            byte[] result = new byte[Data_Size + 6];

            Array.Copy(HS_Tool.Int_To_Byte(Data_Size + 6), 0, result, no, 4);
            no = no + 4;

            result[4] = (byte)inType;
            no = no + 1;

            result[5] = 0x00;
            no = no + 1;

            Array.Copy(Data, 0, result, no, Data.Length);
            no = no + Data.Length;
            return result;
        }
        public bool Set_Byte(byte[] data, ref int index)
        {
            bool result = false;
            int length = 0;

            if (data.Length >= index + Hand_Size)
            {
                length = BitConverter.ToInt32(data, index) - Hand_Size;
                inType = (HS_Type)data[index + 4];
                index = index + Hand_Size;
                if (data.Length >= index + length)
                {
                    Array.Resize(ref Data, length);
                    Array.Copy(data, index, Data, 0, length);
                    index = index + length;
                    result = true;
                }
            }
            return result;
        }
    }
    public class THS_Value_List : CollectionBase
    {
        public THS_Base_Value this[int index]
        {
            get
            {
                THS_Base_Value result = null;
                if (index >= 0 && index < List.Count) result = (THS_Base_Value)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    List[index] = value;
                }
            }
        }
        public void Add(THS_Base_Value value)
        {
            List.Add(value);
        }
        public void Add(bool in_data)
        {
            List.Add(new THS_Base_Value(in_data));
        }
        public void Add(int in_data)
        {
            List.Add(new THS_Base_Value(in_data));
        }
        public void Add(double in_data)
        {
            List.Add(new THS_Base_Value(in_data));
        }
        public void Add(string in_data)
        {
            List.Add(new THS_Base_Value(in_data));
        }
        public void Add(byte[] in_data)
        {
            List.Add(new THS_Base_Value(in_data));
        }
        public void Add(HImage in_data)
        {
            List.Add(new THS_Base_Value(in_data));
        }
        public void Add(THS_Value_List list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                List.Add(list[i]);
            }
        }

        public int Get_Byte_Size()
        {
            int result = 0;
            THS_Base_Value value = null;

            for (int i = 0; i < List.Count; i++)
            {
                value = this[i];
                result = result + value.Byte_Size;
            }
            return result;
        }
        public byte[] Get_Byte()
        {
            byte[] result = null;
            int no = 0;
            THS_Base_Value value = null;
            byte[] value_byte = null;
            
            
            result = new byte[Get_Byte_Size()];

            for (int i = 0; i < List.Count; i++)
            {
                value = this[i];
                value_byte = value.Get_Byte();
                if (value_byte != null)
                {
                    Array.Copy(value_byte, 0, result, no, value_byte.Length);
                    no = no + value_byte.Length;
                }
            }
            return result;
        }
        public bool Set_Byte(byte[] data, int start)
        {
            bool result = true;
            int no = start;
            THS_Base_Value value = null;

            Clear();
            while (no < data.Length - 1)
            {
                value = new THS_Base_Value();
                if (value.Set_Byte(data, ref no))
                {
                    Add(value);
                }
                else
                {
                    result = false;
                    break;
                }
            }
            if (!result) Clear();
            return result;
        }
        public void Copy(THS_Value_List sor, THS_Value_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.List.Count; i++) dis.List.Add(sor.List);
        }
        public void Copy(THS_Value_List dis)
        {
            Copy(this, dis);
        }
        public THS_Value_List Copy()
        {
            THS_Value_List result = new THS_Value_List();
            Copy(this, result);
            return result;
        }
        public void Set(THS_Value_List sor)
        {
            Copy(sor, this);
        }
    }

    //----------------------------------------------------------------------------------
    //-- THirata_Align_Com_Data
    //----------------------------------------------------------------------------------
    public class THS_Socket_Data : TBase_Socket_Data
    {
        public byte ETX = 0x0D;
        public THS_Value_List Values = new THS_Value_List();
        public byte[]  Data = null;

        public string CMD
        {
            get
            {
                string result = "";

                if (Values.Count >= 1 && Values[0].Type == HS_Type.String) result = Values[0].Get_Data_String();
                return result;
            }
            set
            {
                if (Values.Count >= 1)
                {
                    Values[0].Set_Data(value);
                }
                else
                {
                    Values.Add(new THS_Base_Value(value));
                }
            }
        }
        public int System_Code
        {
            get
            {
                int result = 0;

                if (Values.Count >= 2 && Values[1].Type == HS_Type.Int) result = Values[1].Get_Data_Int();
                return result;
            }
            set
            {
                if (Values.Count >= 2)
                {
                    Values[1].Set_Data(value);
                }
                else
                {
                    Values.Add(new THS_Base_Value(value));
                }
            }
        }
        public THS_Socket_Data()
        {

        }
        virtual public void Reset()
        {
            Data_OK = false;
            Data = null;
        }
        public void Copy(THS_Socket_Data sor, THS_Socket_Data dis)
        {
            dis.ETX = sor.ETX;
            dis.Values.Set(sor.Values);
            Array.Resize(ref dis.Data, sor.Data.Length);
            Array.Copy(sor.Data, 0, dis.Data, 0, sor.Data.Length);
        }
        public void Copy(THS_Socket_Data dis)
        {
            Copy(this, dis);
        }
        public THS_Socket_Data Copy()
        {
            THS_Socket_Data result = new THS_Socket_Data();
            Copy(this, result);
            return result;
        }
        public void Set(THS_Socket_Data sor)
        {
            Copy(sor, this);
        }
    }
    public class THS_Socket_Send : THS_Socket_Data
    {
        public DateTime Time = new DateTime();
        public double Timeout_Time = 3000;

        public THS_Socket_Send()
        {

        }
        public void Update()
        {
            int value_len = Values.Get_Byte_Size();
            int total_len = value_len + 5;
            byte[] value_byte = Values.Get_Byte();

            Data = new byte[total_len];
            Array.Copy(HS_Tool.Int_To_Byte(total_len), 0, Data, 0, 4);
            Array.Copy(value_byte, 0, Data, 4, value_byte.Length);
            Data[total_len - 1] = ETX;
        }

        public bool Timeout()
        {
            return Timeout(Time, Timeout_Time);
        }
        public bool Timeout(DateTime send_time, double timeout_time)
        {
            bool result = false;

            TimeSpan tt = DateTime.Now - send_time;
            if (tt.TotalMilliseconds > timeout_time)
                result = true;
            return result;
        }
    }
    public class THS_Socket_Read : THS_Socket_Data
    {
        public string Data_String = "";
        public string Error_Code = "";
        public string Error_Msg = "";
        public DateTime Time = new DateTime();

        public THS_Socket_Read()
        {

        }
        override public void Reset()
        {
            base.Reset();
        }

        public bool Set_Data(byte[] read_byte)
        {
            int total_len = 0;
            Reset();
            Data = read_byte;
            if (read_byte.Length > 4)
            {
                total_len = BitConverter.ToInt32(read_byte, 0);
                if (read_byte.Length >= total_len)
                {
                    Data_OK = Values.Set_Byte(read_byte, 4);
                    if (read_byte[total_len - 1] != ETX) 
                        Data_OK = false;
                }
            }
            return Data_OK;
        }
    }
}
