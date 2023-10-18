using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;

namespace EFC.Tool
{
    public delegate void evComRead(TBase_SerialPort sender);
    public class TBase_SerialPort : SerialPort
    {
        //public SerialPort COM = new SerialPort();
        public string Class_Name = "TBase_Reader";
        public evComRead On_Read = null;
        public TLog Log = null;
        public string Log_Source = "TBase_SerialPort";

        public int Write_Count = 0;
        public byte[] Read_Data = new byte[0];
        public byte[] Buffer = new byte[320000];
        public byte[] Tmp_Buffer = new byte[32000];
        public int Buf_Length = 0;
        public bool On_Lock = false;
        public System.Timers.Timer Read_Timer = new System.Timers.Timer();
        public bool Read_Timeout = false;

        private bool FEnabled;

        public bool Enabled
        {
            set
            {
                try
                {
                    if (FEnabled != value)
                    {
                        FEnabled = value;
                        if (FEnabled)
                            Open();
                        else
                            Close();
                    }
                }
                catch
                {

                }
            }
            get
            {
                return IsOpen;// FEnabled;
            }
        }
        public int Com_Port
        {
            get
            {
                return Get_Com_Port(PortName);
            }
            set
            {
                Set_Com_Port(value);
            }
        }


        public TBase_SerialPort()
        {
            Set_Default();
        }
        public TBase_SerialPort(int com_port)
        {
            Set_Default();
            Set_Com_Port(com_port);
        }
        virtual public void Dispose()
        {
        }

        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Log_Source, fun, "[TBase_SerialPort]" + msg_str, type);
        }


        virtual public void Set_Default()
        {
            Setting("1,19200,N,8,1");
            ReadTimeout = 200;
            DataReceived += in_On_Read;

            Read_Timer.Enabled = false;
            Read_Timer.Interval = 500;
            Read_Timer.Elapsed += On_Read_Timeout;
        }
        virtual public void in_On_Read(object sender, SerialDataReceivedEventArgs e)
        {
            int count = 0;

            try
            {
                Thread.Sleep(100);
                count = Read(Tmp_Buffer, 0, Tmp_Buffer.Length);
            }
            catch { };

            if (count > 0)
            {
                while (On_Lock) { };
                On_Lock = true;
                Array.Copy(Tmp_Buffer, 0, Buffer, Buf_Length, count);
                Buf_Length = Buf_Length + count;
                On_Lock = false;
            }

            if (On_Read != null) On_Read(this);
        }
        //傳入字串格式 ("Port,BaudRate,Parity,ByteSize,StopBit")
        //例:1,9600,N,8,1
        public void Setting(string setting_str)
        {
            ArrayList list = new ArrayList();
            String_Tool.Break_String(setting_str.ToUpper(), ",", ref list);

            if (list.Count == 5)
            {
                try
                {
                    string str_Com = list[0].ToString();
                    string str_BaudRate = list[1].ToString();
                    string str_Parity = list[2].ToString();
                    string str_ByteSize = list[3].ToString();
                    string str_StopBit = list[4].ToString();

                    //1.設定Com Port
                    PortName = "COM" + str_Com;
                    //2.設定BaudRate 9600 19200 38400 115200 128000
                    switch (str_BaudRate)
                    {
                        case "2400": BaudRate = 2400; break;
                        case "4800": BaudRate = 4800; break;
                        case "9600": BaudRate = 9600; break;
                        case "14400": BaudRate = 14400; break;
                        case "19200": BaudRate = 19200; break;
                        case "38400": BaudRate = 38400; break;
                        case "56000": BaudRate = 56000; break;
                        case "115200": BaudRate = 115200; break;
                        case "128000": BaudRate = 128000; break;
                        default: BaudRate = Convert.ToInt32(str_BaudRate); break;
                    }

                    //3.設定Parity
                    switch (str_Parity)
                    {
                        case "N": Parity = System.IO.Ports.Parity.None; break;
                        case "O": Parity = System.IO.Ports.Parity.Odd; break;
                        case "E": Parity = System.IO.Ports.Parity.Even; break;
                        default: Parity = System.IO.Ports.Parity.None; break;
                    }

                    //4.設定ByteSize
                    switch (str_ByteSize)
                    {
                        case "7": DataBits = 7; break;
                        case "8": DataBits = 8; break;
                        default: DataBits = 8; break;
                    }

                    //5.設定StopBit
                    switch (str_StopBit)
                    {
                        case "N": StopBits = System.IO.Ports.StopBits.None; break;
                        case "1": StopBits = System.IO.Ports.StopBits.One; break;
                        case "2": StopBits = System.IO.Ports.StopBits.Two; break;
                        default: StopBits = System.IO.Ports.StopBits.One; break;
                    }
                }
                catch
                {
                }
            }
        }
        public void Set_Com_Port(String port_name)
        {
            try
            {
                PortName = port_name;
            }
            catch 
            { 
            };
        }
        public void Set_Com_Port(int port_no)
        {
            Set_Com_Port("COM" + port_no.ToString());
        }
        public int Get_Com_Port(string com_port)
        {
            int result = 1;
            try
            {
                result = Convert.ToInt32(String_Tool.Get_Num_Char(com_port));
            }
            catch { };
            return result;
        }
        public string Byte_To_Hex(byte[] data)
        {
            string result = "";

            for (int i = 0; i < data.Length; i++)
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
        public string String_To_Hex(string str)
        {
            string result = "";
            char[] chars;

            chars = str.ToCharArray(0, str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                result = result + String_Tool.IntToStr_A(chars[i], emJJS_DataType.emJJS_dtHex, 2) + " ";
            };
            return result;
        }
        public void String_To_Byte(string cmd, ref byte[] data, int start)
        {
            byte[] bytes = String_To_Byte(cmd);
            Array.Copy(bytes, 0, data, start, bytes.Length);
        }
        public byte[] String_To_Byte(string cmd)
        {
            byte[] result = new byte[cmd.Length];

            byte[] bytes = System.Text.Encoding.Default.GetBytes(cmd);
            Array.Copy(bytes, 0, result, 0, result.Length);
            return result;
        }

        public void On_Read_Timeout(object sender, EventArgs e)
        {
            Read_Timer.Enabled = false;
            Read_Timeout = true;
        }
        public string Recive_String(string end_str)
        {
            string result;
            byte[] end_code;
            int end_code_pos = -1;
            int read_len;
            bool flag = true;

            Read_Timeout = false;
            Read_Timer.Interval = 3000;
            Read_Timer.Enabled = true;
            while (flag && !Read_Timeout)
            {
                if (end_str != "")
                {
                    end_code_pos = Indexof(Buffer, Buf_Length, end_str);
                    if (end_code_pos >= 0)
                        flag = false;
                    else
                        System.Threading.Thread.Sleep(10);
                }
                else flag = false;
            }
            if (end_code_pos >= 0)
                read_len = end_code_pos + end_str.Length;
            else
                read_len = Buf_Length;

            while (On_Lock) { };
            On_Lock = true;
            result = Encoding.GetEncoding("Big5").GetString(Buffer, 0, read_len);
            Array.Copy(Buffer, read_len, Buffer, 0, Buf_Length - read_len);
            Buf_Length = Buf_Length - read_len;
            On_Lock = false;
            return result;
        }
        public byte[] Recive_Byte()
        {
            return Recive_Byte(Buf_Length);
        }
        public byte[] Recive_Byte(int read_len)
        {
            byte[] result;

            result = new byte[read_len];
            Array.Copy(Buffer, result, read_len);
            Array.Copy(Buffer, read_len, Buffer, 0, Buf_Length - read_len);
            Buf_Length = Buf_Length - read_len;
            return result;
        }
        public int End_Code_Pos(byte[] end_code)
        {
            int result = -1;
            bool flag;
            int end_code_len = end_code.Length;


            for (int i = 0; i < Buf_Length - end_code_len + 1; i++)
            {
                flag = true;
                for (int j = 0; j < end_code_len; j++)
                {
                    if (Buffer[i + j] != end_code[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public int Indexof(byte[] in_data, int len, string end_str)
        {
            int result = -1;
            byte[] tmp_data = new byte[len];

            Array.Copy(in_data, 0, tmp_data, 0, len);
            result = String_Tool.Indexof(tmp_data, end_str);
            return result;
        }
    }

    abstract public class TBase_SerialPort2 : TBase_SerialPort
    {
        private bool Terminate = false;
        private Thread In_Thread = null;
        public ArrayList Send_List = new ArrayList();
        public int Reconnect_Count = 5000;

        private System.Timers.Timer Reconnect_Timer = new System.Timers.Timer();


        public bool Connected
        {
            get
            {
                return Get_Connect();
            }
        }
        public TBase_SerialPort2()
        {
            Set_Default();
            Init();
        }
        public TBase_SerialPort2(int com_port)
        {
            Set_Default();
            Set_Com_Port(com_port);
            Init();
        }
        public void Init()
        {
            In_Thread = new Thread(Thread_Start);
            In_Thread.Priority = ThreadPriority.Lowest;
            In_Thread.Start();

            Reconnect_Timer.Interval = Reconnect_Count;
            Reconnect_Timer.Elapsed += On_Reconnect;
            On_Read = inOnRead;
        }
        override public void Dispose()
        {
            Terminate = true;
        }
        private void Thread_Start()
        {
            TSocket_Send_List_Data item = null;

            while (!Terminate)
            {
                if (!Connected && !Reconnect_Timer.Enabled && Reconnect_Timer.Interval > 0) Reconnect_Timer.Enabled = true;

                if (Send_List.Count > 0)
                {
                    item = Get_Send_List(0);
                    if (Read_Timeout(item))
                    {
                        OnRead_Timeout(item);
                        item.Finish = true;
                        item.Data_OK = false;
                        Send_List.RemoveAt(0);
                    }
                }
                Thread.Sleep(1);
            }
        }
        public TSocket_Send_List_Data CMD_Write(TBase_Socket_Data data, double timeout)
        {
            TSocket_Send_List_Data result = new TSocket_Send_List_Data(data, timeout);
            Socket_Write(this, result.Send);
            Send_List.Add(result);
            if (data.Wait_Respond)
            {
                while (!result.Finish)
                {
                    System.Windows.Forms.Application.DoEvents();
                    Thread.Sleep(1);
                };
            }
            return result;
        }
        public TSocket_Send_List_Data Get_Send_List(int index)
        {
            TSocket_Send_List_Data result = null;

            if (index >= 0 && index < Send_List.Count)
            {
                result = (TSocket_Send_List_Data)Send_List[index];
            }
            return result;
        }
        virtual public bool Get_Connect()
        {
            return Enabled;
        }
        virtual public bool Set_Connect()
        {
            Enabled = true;
            return Enabled;
        }

        //處理Socket 讀取的資料 轉成所需的 Base Data
        abstract public TBase_Socket_Data Socket_Read(TBase_SerialPort com_port);
        abstract public void Socket_Write(TBase_SerialPort com_port, TBase_Socket_Data send_data);

        //取得回應編號
        abstract public int Get_Reply_Item(TBase_Socket_Data data);

        //檢查讀回的資料是否正確
        abstract public bool Check_Read_Data(TBase_Socket_Data data);

        //檢查回應的資料是否正確
        abstract public bool Check_Reply_Data(TBase_Socket_Data data);

        //不屬於回應資料，如Event
        abstract public void On_Not_Reply_Read(TBase_Socket_Data data);

        //讀取串列中有資料timeout
        abstract public void OnRead_Timeout(TSocket_Send_List_Data data);

        private void inOnRead(TBase_SerialPort sender)
        {
            TBase_Socket_Data read_data = null;
            TSocket_Send_List_Data send_item = null;
            int index = -1;

            read_data = Socket_Read(sender);
            while (read_data != null)
            {
                read_data.Data_OK = Check_Read_Data(read_data);
                index = Get_Reply_Item(read_data);
                if (index >= 0)
                {
                    send_item = Get_Send_List(index);
                    send_item.Read = read_data;
                    send_item.Read_Time = DateTime.Now;
                    send_item.Finish = true;
                    send_item.Data_OK = Check_Reply_Data(read_data);
                    Send_List.RemoveAt(index);
                }
                else
                    On_Not_Reply_Read(read_data);

                read_data = null;
                if (Buf_Length > 0)
                    read_data = Socket_Read(sender);
            }
        }
        public bool Read_Timeout(TSocket_Send_List_Data item)
        {
            return Read_Timeout(item.Send_Time, item.Timeout_Time);
        }
        public bool Read_Timeout(DateTime send_time, double timeout_time)
        {
            bool result = false;

            TimeSpan tt = DateTime.Now - send_time;
            if (tt.TotalMilliseconds > timeout_time)
                result = true;
            return result;
        }

        private void On_Reconnect(object sender, ElapsedEventArgs e)
        {
            Log_Add("On_Reconnect","Socket Reconnect.");
            Set_Connect();
            Reconnect_Timer.Enabled = false;
        }
    }
}
