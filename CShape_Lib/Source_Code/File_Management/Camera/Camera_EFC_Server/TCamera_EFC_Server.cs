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

namespace Camera_EFC
{
    public class TCamera_EFC_Server : TCamera_Base
    {
        public bool Terminate;
        public THS_Server Socket = new THS_Server();
        public TCamera_Base Camera = null;

        public TCamera_EFC_Server()
        {
            FCamera_Type_Name = "TSentech_Giga_Camera";
            Terminate = false;
            Socket.Port = 1234;
            Socket.On_Recive = On_Recive;
        }
        public override void Dispose()
        {
            Terminate = true;
        }
        ~TCamera_EFC_Server()
        {
            Terminate = true;
        }
        public void Free()
        {
        }
        override public void Camera_Init()
        {
            if (Camera != null) Camera.Camera_Init();
        }
        override public void Grab_Image()
        {
            if (Camera != null) Camera.Grab_Image();
        }
        override public void Grab_Stop()
        {
            if (Camera != null) Camera.Grab_Stop();
            Grab_Status = emCamera_Grab_Status.Stop;
        }
        override public void Grab_Life()
        {
            if (Camera != null) Camera.Grab_Life();
            Grab_Status = emCamera_Grab_Status.Life;
        }
        override public bool Get_Connected()
        {
            bool result = false;

            if (Camera != null) result = Camera.Get_Connected();
            return result;
        }
        override public void Reconnect()
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
        private void On_Timer_Disconnect(object sender, EventArgs e)
        {
            On_Disconnected = true;
            Log_Add("On_Timer_Disconnect.");
            Timer_Disconnect.Enabled = false;
            Is_Connected = false;
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
            //Socket.Log = log;
        }
        public void On_Recive(TJJS_Socket s_socket, THS_Socket_Read read)
        {
            switch (read.CMD)
            {
                case "Grab_Life": Grab_Life(); break;
                case "Grab_Stop": Grab_Stop(); break;
            }
        }
        public void Callback_Image(HImage image)
        {
            try
            {
                if (Socket.Infos.Count > 0)
                {
                    THS_Socket_Send send = new THS_Socket_Send();
                    send.CMD = "Callback_Image";
                    send.Need_Replay = false;
                    send.Values.Add(image);
                    Socket.Send(Socket.Infos[Socket.Infos.Count - 1].JJS_Socket, send);
                }
            }
            catch(Exception e)
            {

            }
        }

    }
}
