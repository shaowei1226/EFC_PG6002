using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Timers;

namespace EFC.Tool
{
    public delegate void evJJS_SocketEvent(TJJS_Socket s_socket);
    public delegate void evJJS_SocketErrorEvent(TJJS_Socket s_socket, SocketException e);
    //----------------------------------------------------------------------------------
    //-- TJJS_Socket
    //----------------------------------------------------------------------------------

    public static class Socket_Tool
    {

    }


    public class TJJS_Sockets : CollectionBase
    {
        public TJJS_Sockets()
        {

        }
        public TJJS_Socket this[int index]
        {
            get
            {
                return Get_Socket(index);
            }
            set
            {
                TJJS_Socket socket = null;
                socket = Get_Socket(index);
                if (socket != null) socket.Set(value);
            }
        }
        public void Add(TJJS_Socket socket)
        {
            List.Add(socket);
        }
        public void Add(Socket socket)
        {
            TJJS_Socket tmp_socket = new TJJS_Socket();
            tmp_socket.Socket = socket;
            List.Add(tmp_socket);
        }
        public TJJS_Socket Get_Socket(int index)
        {
            TJJS_Socket result = null;

            if (index >= 0 && index < Count)
            {
                result = (TJJS_Socket)List[index];
            }
            return result;
        }
        public TJJS_Socket Get_Socket(Socket socket)
        {
            TJJS_Socket result = null;
            TJJS_Socket tmp_socket = null;

            for (int i = 0; i < Count; i++)
            {
                tmp_socket = (TJJS_Socket)List[i];
                if (socket == tmp_socket.Socket)
                {
                    result = tmp_socket;
                    break;
                }
            }
            return result;
        }
        public void Remove(Socket socket)
        {
            TJJS_Socket jjs_socket = Get_Socket(socket);
            if (jjs_socket != null) List.Remove(jjs_socket);
        }
    }
    public class TJJS_Socket : TBase_Class
    {
        public Socket Socket = null;
        public int Recive_Length = 0;               //接收到的資料長度
        public byte[] Buffer = new byte[10000];     //接收到的資料區域,
        public byte[] Tmp_Buffer = new byte[10000]; //BeginReceive 指定回傳資料進入Buffer

        public int Buffer_Max_Length
        {
            get
            {
                return Buffer.Length;
            }
            set
            {
                Array.Resize(ref Buffer, value);
            }
        }
        public bool Connected
        {
            get
            {
                return Socket.Connected;
            }
        }
        public TJJS_Socket()
        {
        }
        public TJJS_Socket(Socket socket)
        {
            Socket = socket;
        }
        public void Dispose()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TJJS_Socket();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_Socket && dis_base is TJJS_Socket)
            {
                TJJS_Socket sor = (TJJS_Socket)sor_base;
                TJJS_Socket dis = (TJJS_Socket)dis_base;

                dis.Socket = sor.Socket;
                dis.Recive_Length = sor.Recive_Length;
                Array.Resize(ref dis.Buffer, sor.Buffer.Length);
                Array.Copy(sor.Buffer, 0,dis.Buffer,0, sor.Buffer.Length);
            }
        }

        public string Get_Host_Name()
        {
            string result;
            result = Dns.GetHostName();
            return result;
        }
        public IPAddress[] Get_Host_IP()
        {
            IPAddress[] result;
            result = Dns.GetHostAddresses(Get_Host_Name());
            return result;
        }

        public byte[] Recive_Byte(int max_read_len)
        {
            byte[] result;
            int read_len = 0;
            int move_len = 0;

            lock (Buffer)
            {
                read_len = max_read_len;
                if (max_read_len > Recive_Length) read_len = Recive_Length;

                move_len = Buffer.Length - read_len;
                result = new byte[read_len];
                Array.Copy(Buffer, 0, result, 0, read_len);
                Array.Copy(Buffer, read_len, Buffer, 0, move_len);
                Recive_Length = Recive_Length - read_len;
            }

            return result;
        }
        public byte[] Recive_Byte()
        {
            return Recive_Byte(Recive_Length);
        }
        public byte[] Recive_Byte(byte[] end_code)
        {
            byte[] result = null;
            int end_pos = Recive_Length;
            int end_code_pos = -1;

            end_code_pos = End_Code_Pos(end_code);
            if (end_code_pos >= 0)
            {
                result = Recive_Byte(end_code_pos + end_code.Length);
            }
            return result;
        }
        public string Recive_String()
        {
            string result;
            byte[] data = null;


            data = Recive_Byte();
            result = Encoding.GetEncoding("Big5").GetString(data);
            Recive_Length = 0;
            return result;
        }
        public string Recive_String(string end_str)
        {
            string result = "";
            byte[] end_code = null;
            byte[] data = null;

            if (end_str != "")
            {
                end_code = Encoding.GetEncoding("Big5").GetBytes(end_str);
                data = Recive_Byte(end_code);
                result = Encoding.GetEncoding("Big5").GetString(data);
            }
            else
                data = Recive_Byte();

            return result;
        }

        public int Send_Byte(byte[] data, int size, SocketFlags socketFlags)
        {
            int result = 0;

            if (Connected) result = Socket.Send(data, size, socketFlags);
            return result;
        }
        public void Send_Byte(byte[] data)
        {
            if (Socket.Connected) Socket.Send(data);
        }
        public void Send_String(string str)
        {
            byte[] buffer;

            buffer = Encoding.GetEncoding("Big5").GetBytes(str);
            if (Connected) Socket.Send(buffer);
        }


        private int End_Code_Pos(byte[] end_code)
        {
            int result = -1;
            bool flag;
            int end_code_len = end_code.Length;

            for (int i = 0; i < Recive_Length - end_code_len + 1; i++)
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
    }

    public class TJJS_ServerSockect : TJJS_Socket
    {
        public string Host = "127.0.0.1";
        public int Port = 7777;

        public TJJS_Sockets Client_Sockets = new TJJS_Sockets();
        public evJJS_SocketEvent OnAccept = null;
        public evJJS_SocketEvent OnClientConnect = null;
        public evJJS_SocketEvent OnClientDisconnect = null;
        public evJJS_SocketEvent OnClientRecive = null;
        public evJJS_SocketEvent OnClientSend = null;
        public evJJS_SocketErrorEvent OnError = null;

        private bool in_Connected = false;


        new public bool Connected
        {
            get
            {
                return in_Connected;
            }
        }
        public TJJS_ServerSockect()
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Buffer_Max_Length = 32000000;
        }
        public void Dispone()
        { 
        }
        public void Connect()
        {
            IPAddress ipa;
            IPEndPoint ipe;

            if (!in_Connected)
            {
                ipa = IPAddress.Parse(Host);
                ipe = new IPEndPoint(ipa, Port);

                try
                {
                    Socket.Bind(ipe);
                    Socket.Listen(4);
                    Socket.BeginAccept(Accept_Callback, this);
                    if (OnAccept != null) OnAccept(this);
                    //設定網路斷線監聽
                    Socket.IOControl(IOControlCode.KeepAliveValues, GetKeepAliveSetting(1, 5000, 500), null);

                    in_Connected = true;
                }
                catch (SocketException e)
                {
                    if (OnError != null) OnError(this, e);
                }
            }
        }
        //public void Disconnect()
        //{
        //    try
        //    {
        //        in_Connected = false;
        //        Socket.Close();
        //        Client_Sockets.Clear();
        //    }
        //    catch (SocketException e)
        //    {
        //        if (OnError != null) OnError(this, e);
        //    }
        //}



        private void Accept_Callback(IAsyncResult ar)
        {
            TJJS_Socket socket = null;

            try
            {
                //"連線成功!"
                socket = new TJJS_Socket();
                socket.Buffer_Max_Length = Buffer_Max_Length;
                socket.Socket = Socket.EndAccept(ar);
                Client_Sockets.Add(socket);

                //設定網路斷線監聽
                socket.Socket.IOControl(IOControlCode.KeepAliveValues, GetKeepAliveSetting(1, 1000, 1000), null);


                if (OnClientConnect != null) OnClientConnect(socket);
                BeginReceive(socket);
                //BeginDisconnect(socket);
            }
            catch (SocketException e)
            {
            }
            Socket.BeginAccept(Accept_Callback, this);
        }
        private byte[] GetKeepAliveSetting(int onOff, int keepAliveTime, int keepAliveInterval)
        {
            byte[] buffer = new byte[12];
            BitConverter.GetBytes(onOff).CopyTo(buffer, 0);
            BitConverter.GetBytes(keepAliveTime).CopyTo(buffer, 4);
            BitConverter.GetBytes(keepAliveInterval).CopyTo(buffer, 8);
            return buffer;
        }
        private void BeginReceive(TJJS_Socket socket)
        {
            try
            {
                socket.Socket.BeginReceive(socket.Tmp_Buffer, 0, socket.Tmp_Buffer.Length, SocketFlags.None, ClientRecive_Callback, socket);
            }
            catch (SocketException e)
            {
                //嘗試存取通訊端時發生錯誤。
                //if (OnClientDisconnect != null) OnClientDisconnect(socket);
                //Client_Sockets.Remove(socket.Socket);
            }
            catch (ObjectDisposedException e)
            {
                //這個 Socket 已關閉
                //if (OnClientDisconnect != null) OnClientDisconnect(socket);
                //Client_Sockets.Remove(socket.Socket);
            }
        }
        private void ClientRecive_Callback(IAsyncResult ar)
        {
            TJJS_Socket socket = null;

            socket = (TJJS_Socket)ar.AsyncState;
            EndRecive(socket, ar);
            BeginReceive(socket);
        }
        private void EndRecive(TJJS_Socket socket, IAsyncResult ar)
        {
            int read_len;
            bool recive = false;

            try
            {
                read_len = socket.Socket.EndReceive(ar);
                if (read_len > 0)
                {
                    lock (socket.Buffer)
                    {
                        Array.Copy(socket.Tmp_Buffer, 0, socket.Buffer, socket.Recive_Length, read_len);
                        socket.Recive_Length = socket.Recive_Length + read_len;
                    }
                }
                recive = true;
            }
            catch (SocketException e)
            {
                //斷線，無接收資料
                if (OnClientDisconnect != null) OnClientDisconnect(socket);
                Client_Sockets.Remove(socket.Socket);
            }
            catch (ObjectDisposedException e)
            {
                //Socket 已關閉。
                if (OnClientDisconnect != null) OnClientDisconnect(socket);
                Client_Sockets.Remove(socket.Socket);
            }
            if (recive && OnClientRecive != null && socket.Recive_Length > 0) OnClientRecive(socket);
        }
        private void BeginDisconnect(TJJS_Socket socket)
        {
            try
            {
                socket.Socket.BeginDisconnect(true, Disconnect_Callback, socket);
            }
            catch (SocketException e)
            {
            }
        }
        private void Disconnect_Callback(IAsyncResult ar)
        {
            TJJS_Socket socket = null;

            socket = (TJJS_Socket)ar.AsyncState;
            socket.Socket.EndDisconnect(ar);
        }
    }
    public class TJJS_ClientSockect : TJJS_Socket 
    {
        public string Host = "127.0.0.1";
        public int Port = 7777;

        public evJJS_SocketEvent OnConnect = null;
        public evJJS_SocketEvent OnDisconnect = null;
        public evJJS_SocketEvent OnRecive = null;
        public evJJS_SocketErrorEvent OnError = null;


        public TJJS_ClientSockect()
        {
            //FActive = false;
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Set_Active(bool value)
        {
            IPAddress ipa;
            IPEndPoint ipe;

            if (value)
            {
                if (!Connected)
                {
                    ipa = IPAddress.Parse(Host);
                    ipe = new IPEndPoint(ipa, Port);

                    try
                    {
                        Socket.Dispose();
                        Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        Socket.BeginConnect(ipe, BeginAccept_Callback, this);
                    }
                    catch (SocketException e)
                    {
                        if (OnError != null) OnError(this, e);
                    }
                }
            }
            else
                Disconnect();
        }
        public void Connect()
        {
            IPAddress ipa;
            IPEndPoint ipe;

            if (!Connected)
            {
                ipa = IPAddress.Parse(Host);
                ipe = new IPEndPoint(ipa, Port);

                try
                {
                    Socket.Dispose();
                    Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    Socket.BeginConnect(ipe, BeginAccept_Callback, this);
                }
                catch (SocketException e)
                {
                    if (OnError != null) OnError(this, e);
                }
            }

            //if (Socket.Connected)
            //{
            //    FActive = true;
            //    BeginReceive(Recive);
            //    if (OnConnect != null) OnConnect(this);
            //    //設定網路斷線監聽
            //    Check_Connect_Timer.Enabled = true;
            //}
            //else
            //{
            //    FActive = false;
            //}
        }
        public void Disconnect()
        {
            try
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Disconnect(false);
                Socket.Close();
            }
            catch (SocketException e)
            {
                if (OnError != null) OnError(this, e);
            }
        }
        public bool Check_Connect()
        {
            bool result = false;
            byte[] test_buffer = new byte[1000];

            if (Socket.Connected)
            {
                if (Socket.Receive(test_buffer, SocketFlags.Peek) == 0)
                {
                }
            }
            return result;
        }

        private void BeginAccept_Callback(IAsyncResult ar)
        {
            try
            {
                if (Socket.Connected)
                {
                    if (OnConnect != null) OnConnect(this);
                    BeginReceive(this);
                }
            }
            catch (SocketException e)
            {
            }
        }
        private void Recive_Callback(IAsyncResult ar)
        {
            TJJS_Socket socket = null;

            socket = (TJJS_Socket)ar.AsyncState;
            EndReceive(socket, ar);
            BeginReceive(socket);
        }
        private void BeginReceive(TJJS_Socket socket)
        {
            try
            {
                socket.Socket.BeginReceive(socket.Tmp_Buffer, 0, socket.Tmp_Buffer.Length, SocketFlags.None, Recive_Callback, socket);
            }
            catch (SocketException e)
            {
                //嘗試存取通訊端時發生錯誤。
                if (OnDisconnect != null) OnDisconnect(socket);
            }
            catch (ObjectDisposedException e)
            {
                //這個 Socket 已關閉
                if (OnDisconnect != null) OnDisconnect(socket);
            }
        }
        private void EndReceive(TJJS_Socket socket, IAsyncResult ar)
        {
            int read_len;

            try
            {
                read_len = socket.Socket.EndReceive(ar);
                if (read_len <= 0)
                {
                    return;
                }
                else
                {
                    lock (socket.Buffer)
                    {
                        if (read_len + socket.Recive_Length < socket.Buffer.Length)
                        {
                            Array.Copy(socket.Tmp_Buffer, 0, socket.Buffer, socket.Recive_Length, read_len);
                            socket.Recive_Length = socket.Recive_Length + read_len;
                        }
                    }
                    if (OnRecive != null && socket.Recive_Length > 0) OnRecive(socket);
                }
            }
            catch (SocketException e)
            {
                //嘗試存取通訊端時發生錯誤。
            }
            catch (ObjectDisposedException e)
            {
                //Socket 已關閉。
            }
        }
    }



    //----------------------------------------------------------------------------------
    //-- TBase_Socket
    //----------------------------------------------------------------------------------
    abstract public class TBase_Socket : TJJS_ClientSockect
    {
        public TLog Log = null;
        public string Log_Source = "TBase_Socket";

        private bool Terminate = false;
        private Thread In_Thread = null;
        public ArrayList Send_List = new ArrayList();
        public int Reconnect_Count = 5000;

        
        private bool Send_List_On_Lock = false;
        private System.Timers.Timer Reconnect_Timer = new System.Timers.Timer();

        public TBase_Socket()
        {
            In_Thread = new Thread(Thread_Start);
            In_Thread.Priority = ThreadPriority.Lowest;
            In_Thread.Start();

            Reconnect_Timer.Interval = Reconnect_Count;
            Reconnect_Timer.Elapsed += On_Reconnect;

            OnConnect += inOnConnect;
            OnDisconnect += inOnDisconnect;
            OnRecive += inOnRecive;
        }
        new public void Dispose()
        {
            Terminate = true;
        }

        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Log_Source, fun, "[TBase_Socket]" + msg_str, type);
        }

        private void Thread_Start()
        {
            TSocket_Send_List_Data item = null;

            while (!Terminate || (Send_List.Count > 0))
            {
                if (!Connected && !Reconnect_Timer.Enabled && Reconnect_Timer.Interval > 0) Reconnect_Timer.Enabled = true;

                if (Send_List.Count > 0)
                {
                    Wait_Send_List_UnLock();
                    Send_List_On_Lock = true;
                    item = Get_Send_List(0);
                    if (Read_Timeout(item))
                    {
                        OnRead_Timeout(item);
                        item.Finish = true;
                        item.Data_OK = false;
                        Send_List.RemoveAt(0);
                    }
                    Send_List_On_Lock = false;
                }
                Thread.Sleep(1);
            }
        }
        public bool Is_Connect
        {
            get
            {
                return Connected;
            }
        }
        public TSocket_Send_List_Data CMD_Write(TBase_Socket_Data data, double timeout)
        {
            TSocket_Send_List_Data result = new TSocket_Send_List_Data(data, timeout);
            Socket_Write(this, result.Send);
            Send_List_Add(result);
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


        //處理Socket 讀取的資料 轉成所需的 Base Data
        abstract public TBase_Socket_Data Socket_Read(TJJS_Socket s_socket);
        abstract public void Socket_Write(TJJS_Socket s_socket, TBase_Socket_Data send_data);

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

        public void Send_List_Add(TSocket_Send_List_Data data)
        {
            Wait_Send_List_UnLock();
            Send_List.Add(data);
        }
        private void inOnConnect(TJJS_Socket s_socket)
        {
            Log_Add("inOnConnect", "Connect");
        }
        private void inOnDisconnect(TJJS_Socket s_socket)
        {
            Log_Add("inOnDisconnect", "Disconnect", emLog_Type.Error);
        }
        private void inOnRecive(TJJS_Socket s_socket)
        {
            TBase_Socket_Data read_data = null;
            TSocket_Send_List_Data send_item = null;
            int index = -1;

            read_data = Socket_Read(s_socket);
            while (read_data != null)
            {
                read_data.Data_OK = Check_Read_Data(read_data);

                Wait_Send_List_UnLock();
                Send_List_On_Lock = true;
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
                Send_List_On_Lock = false;

                read_data = null;
                if (s_socket.Recive_Length > 0) read_data = Socket_Read(s_socket);
            }
        }
        public bool Read_Timeout(TSocket_Send_List_Data item)
        {
            bool result = false;
            if (item != null)
            {
                result = Read_Timeout(item.Send_Time, item.Timeout_Time);
            }
            return result;
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
            Log_Add("On_Reconnect", "Socket Reconnect.");
            Connect();
            Reconnect_Timer.Enabled = false;
        }
        private void Wait_Send_List_UnLock()
        {
            while (Send_List_On_Lock) { Thread.Sleep(1); };
        }

    }

    //----------------------------------------------------------------------------------
    //-- TSocket_Send_List_Data
    //----------------------------------------------------------------------------------
    public class TSocket_Send_List_Data
    {
        public bool Finish = false;
        public bool Data_OK = false;
        public TBase_Socket_Data Send = null;
        public TBase_Socket_Data Read = null;
        public DateTime Send_Time = new DateTime();
        public DateTime Read_Time = new DateTime();
        public double Timeout_Time = 1000;

        public TSocket_Send_List_Data()
        {
            Send_Time = DateTime.Now;
            Read_Time = DateTime.Now;
        }
        public TSocket_Send_List_Data(TBase_Socket_Data data, double timeout)
        {
            Send_Time = DateTime.Now;
            Send = data;
            Timeout_Time = timeout;
        }
    }

    //----------------------------------------------------------------------------------
    //-- TBase_Socket_Data
    //----------------------------------------------------------------------------------
    public class TBase_Socket_Data
    {
        public bool Data_OK = false;
        public bool Need_Respond = true;
        public bool Wait_Respond = true;
    }


    public class TNew_Server
    {
        public string Host = "127.0.0.1";
        public int Port = 7777;
        public TcpListener Socket = null;
        public NetworkStream Stream = null;


        public TNew_Server()
        {

        }
        public void Connect()
        {
            IPAddress localAddr = IPAddress.Parse(Host);
            Socket = new TcpListener(localAddr, Port);
            //建立新的TcpListener  
            Socket.Start();//開始監聽client的請求  
            TcpClient client = Socket.AcceptTcpClient();
            Stream = client.GetStream(); 
        }
    }
    public class TNew_Client
    {
        public string Host = "127.0.0.1";
        public int Port = 7777;

        public TcpClient Socket = null;
        public NetworkStream Stream = null;


        public TNew_Client()
        {
        }
        public void Connect()
        {
            Socket = new TcpClient(Host, Port);
            Stream = Socket.GetStream();
        }
        public void Disconnect()
        {
            Stream.Close();
            Socket.Close();
            Stream = null;
            Socket = null;
        }
        public void Send(byte[] data)
        {
            Send(data, 0, data.Length);
        }
        public void Send(byte[] data, int offset, int size)
        {
            Stream.Write(data, offset, size);
        }
    }
}