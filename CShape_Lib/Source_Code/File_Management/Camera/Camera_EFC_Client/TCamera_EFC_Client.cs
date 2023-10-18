using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Vision.Halcon;
using EFC.Camera;
using EFC.TCP_Handshake;
using EFC.Tool;
using HalconDotNet;


namespace EFC.Camera.EFC
{
    public enum emTrig_Mode { FreeRun, Hard };

    public class TCamera_EFC_Client : TCamera_Base
    {
        public bool Terminate;
        public THS_Client Socket = new THS_Client();
        public TImage_List Image_List = null;
        public emTrig_Mode Trig_Mode = emTrig_Mode.FreeRun;
        public bool On_Callback = false;
        public int SN = 0;
        public System.Timers.Timer Timer_Disconnect = new System.Timers.Timer();
        public System.Timers.Timer Timer_Reconnect = new System.Timers.Timer();
        private bool In_IsConnected = false;
        private bool On_Reconnected = false;
        private bool On_Disconnected = false;


        public bool On_Connected
        {
            get
            {
                return Socket.Connected;
            }
        }
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
        public TCamera_EFC_Client()
        {
            FCamera_Type_Name = "TSentech_Giga_Camera";
            Terminate = false;
            //Socket.Host = "127.0.0.1";
            Socket.Host = "192.168.200.66";
            Socket.Port = 1234;
            Socket.On_Recive = On_Recive;

            Timer_Disconnect.Enabled = false;
            Timer_Disconnect.Interval = 3000;
            Timer_Disconnect.Elapsed += On_Timer_Disconnect;

            Timer_Reconnect.Enabled = false;
            Timer_Reconnect.Interval = 3000;
            Timer_Reconnect.Elapsed += On_Timer_Reconnect;
        }
        public override void Dispose()
        {
            Terminate = true;
        }
        ~TCamera_EFC_Client()
        {
            Terminate = true;
        }
        public void Free()
        {
        }
        override public void Camera_Init()
        {

        }
        override public void Grab_Stop()
        {
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Grab_Stop";
                send.Need_Replay = false;
                Socket.Send(send);
                Grab_Status = emCamera_Grab_Status.Stop;
            }
        }
        override public void Grab_One_Image()
        {
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Grab_One_Image";
                send.Need_Replay = false;
                Socket.Send(send);
                Grab_Status = emCamera_Grab_Status.Grab_Image;
            }

        }
        override public void Grab_Life()
        {
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Grab_Life";
                send.Need_Replay = false;
                Socket.Send(send);
                Grab_Status = emCamera_Grab_Status.Life;
            }
        }
        override public bool Get_Connected()
        {
            return In_IsConnected;
        }
        public void Reconnect()
        {
            On_Reconnected = true;
            Log_Add("Reconnect.");
            Camera_Init();
            Grab_Life();
            On_Reconnected = false;
            On_Disconnected = false;
        }



        public void Connect()
        {
            Socket.Connect();
        }
        public void Set_Grab_TrigMode_Hard()
        {
            Trig_Mode = emTrig_Mode.Hard;
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Set_Grab_TrigMode_Hard";
                send.Need_Replay = false;
                Socket.Send(send);
            }
        }
        public void Set_Grab_TrigMode_Free()
        {
            Trig_Mode = emTrig_Mode.FreeRun;
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Set_Grab_TrigMode_Free";
                send.Need_Replay = false;
                Socket.Send(send);
            }
        }
        public void Set_Line_Page_Length(int len)
        {
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Set_Line_Page_Length";
                send.Values.Add(len);
                send.Need_Replay = false;
                Socket.Send(send);
            }
        }
        public void SeqLength_Pg(int len)
        {
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "SeqLength_Pg";
                send.Values.Add(len);
                send.Need_Replay = false;
                Socket.Send(send);
            }
        }
        public void Set_Expose_us(int value)
        {
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Set_Expose_us";
                send.Values.Add(value);
                send.Need_Replay = false;
                Socket.Send(send);
            }
        }
        public void Grab_Start()
        {
            if (Socket.Connected)
            {
                THS_Socket_Send send = new THS_Socket_Send();
                send.CMD = "Grab_Start";
                send.Need_Replay = false;
                Socket.Send(send);
            }
            JJS_LIB.Sleep(200);
        }
        public void Grab_Image_List(ref TImage_List list)
        {
            Image_List = list;
            //SeqLength_Pg(1);
            Grab_Status = emCamera_Grab_Status.Grab_Image_List;
        }


        private void On_Timer_Disconnect(object sender, EventArgs e)
        {
            On_Disconnected = true;
            Log_Add("On_Timer_Disconnect.");
            Timer_Disconnect.Enabled = false;
            In_IsConnected = false;
            Grab_Stop();
            Timer_Reconnect.Enabled = true;
        }
        private void On_Timer_Reconnect(object sender, EventArgs e)
        {
            Log_Add("On_Timer_Reconnect.");
            Timer_Reconnect.Enabled = false;
            Reconnect();
        }
        public void Set_Log(TLog log)
        {
            Log = log;
            Socket.Log = log;
        }
        public void On_Recive(TJJS_Socket s_socket, THS_Socket_Read read)
        {
            switch (read.CMD)
            {
                case "Callback_Image":
                    JJS_Vision.Copy_Obj(read.Values[1].Get_Data_HImage(), ref Image);
                    Inside_Callback(Image);
                    break;
            }
        }
        public void Inside_Callback(HImage in_image)
        {
            SN++;
            if (SN > 1000000) SN = 0;
             
            switch (Grab_Status)
            {
                case emCamera_Grab_Status.Grab_Image:
                    Grab_Stop();
                    if (CallBack != null) CallBack(this);
                    break;

                case emCamera_Grab_Status.Life:
                    if (CallBack != null) CallBack(this);
                    break;

                case emCamera_Grab_Status.Grab_Image_List:
                    if (Image_List.Grab_Call_Back != null) Image_List.Grab_Call_Back(this, in_image, Image_List);
                    if (Image_List.Grab_Finish)
                    {
                        Image_List.Grab_Finish_Flag = true;
                        //Grab_Stop();
                        if (Image_List.Grab_Finish_Call_Back != null) Image_List.Grab_Finish_Call_Back(this, in_image, Image_List);
                    }
                    break;
            }
            Refalsh = true;

            if (CallBack != null) CallBack(this);
        }
    }

}
