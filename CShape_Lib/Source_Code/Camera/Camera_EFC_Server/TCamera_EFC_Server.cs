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
using EFC.Camera.MultiCam;
using System.Threading;

namespace EFC.Camera.EFC
{
    public class TCamera_EFC_Server 
    {
        protected TLog inLog = null;
        public string Log_Source = "TCamera_EFC_Server";
        public bool Terminate = false;
        public THS_Server HS_Socket = null;
        public TCamera_MultiCam Camera = null;
        public int SN = 0;

        public emCamera_Grab_Status Grab_Status
        {
            get
            {
                emCamera_Grab_Status result = emCamera_Grab_Status.Stop;

                if(Camera != null)
                {
                    result = Camera.Grab_Status;
                }
                return result;
            }
        }

        public TLog Log
        {
            get
            {
                return inLog;
            }
            set
            {
                inLog = value;
            }
        }
        public emTrig_Mode Trig_Mode
        {
            get
            {
                emTrig_Mode result = emTrig_Mode.FreeRun;
                if (Camera != null) result = Camera.Trig_Mode;
                return result;
            }
            set
            {
                if (Camera != null) Camera.Trig_Mode = value;
            }
        }
        public TJJS_Socket Client_Socket
        {
            get
            {
                TJJS_Socket result = null;

                if (HS_Socket != null) result = HS_Socket.Info.JJS_Socket;
                return result;
            }
        }
        public bool On_Connected
        {
            get
            {
                bool result = false;

                if (HS_Socket != null) result = HS_Socket.Info.Connected;
                return result;
            }
        }
        public TCamera_EFC_Server()
        {
            Terminate = false;
            //HS_Socket_Server.Host = "192.168.200.66";
            //HS_Socket_Server.Port = 1234;
            //HS_Socket_Server.On_ClientConnect += On_ClientConnect;
            //HS_Socket.On_Recive += On_Recive;
        }
        public void Dispose()
        {
            Terminate = true;
        }
        ~TCamera_EFC_Server()
        {
            Terminate = true;
        }
        public void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
        {
            if (inLog != null) inLog.Add(Log_Source, fun, msg, type);
        }

        public void Free()
        {
        }
        public void Camera_Init()
        {
            if (Camera != null)
            {
                Camera.Camera_Init();
            }
        }
        public void Grab_One_Image()
        {
            if (Camera != null)
            {
                Camera.Grab_One_Image();
            }
        }
        public void Grab_Stop()
        {
            if (Camera != null)
            {
                Camera.Grab_Stop();
                Send_Set_Status();
            }
        }
        public void Grab_Life()
        {
            if (Camera != null)
            {
                Camera.Grab_Life();
            }
        }
        public bool Get_Connected()
        {
            bool result = false;

            if (Camera != null) result = Camera.Get_Connected();
            return result;
        }
        public void Grab_Start()
        {
            if (Camera != null)
            {
                Camera.Grab_Start();
            }
        }
        public void Set_Grab_TrigMode_Hard()
        {
            if (Camera != null)
            {
                Camera.Set_Grab_TrigMode_Hard();
            }
        }
        public void Set_Grab_TrigMode_Free()
        {
            if (Camera != null)
            {
                Camera.Set_Grab_TrigMode_Free();
            }
        }
        public void Set_PageLength_Ln(int len)
        {
            if (Camera != null)
            {
                Camera.Set_PageLength_Ln(len);
            }
        }
        public void Set_Expose_us(int value)
        {
            if (Camera != null)
            {
                Camera.Set_Expose_us(value);
            }
        }
        public void On_Recive(TJJS_Socket s_socket, THS_Socket_Read read)
        {
            switch (read.CMD)
            {
                case "Grab_Stop":
                    Grab_Stop();
                    Send_CMD_Respond(read);
                    break;

                case "Grab_One_Image":
                    Grab_One_Image();
                    Send_CMD_Respond(read);
                    break;

                case "Grab_Life":
                    Grab_Life();
                    Send_CMD_Respond(read);
                    break;

                case "Set_Grab_TrigMode_Hard":
                    Set_Grab_TrigMode_Hard();
                    Send_CMD_Respond(read);
                    break;

                case "Set_Grab_TrigMode_Free":
                    Set_Grab_TrigMode_Free();
                    Send_CMD_Respond(read);
                    break;

                case "Set_PageLength_Ln":
                    int len = 0;
                    if (read.Values.Count >= 3)
                    {
                        len = read.Values[2].Get_Data_Int();
                        Set_PageLength_Ln(len);
                        Send_CMD_Respond(read);
                    }
                    break;

                case "Set_Expose_us":
                    int value = 0;
                    if (read.Values.Count >= 3)
                    {
                        value = read.Values[2].Get_Data_Int();
                        Set_Expose_us(value);
                        Send_CMD_Respond(read);
                    }
                    break;

                case "Grab_Start":
                    Grab_Start();
                     Send_CMD_Respond(read);
                   break;
            }
        }

        protected bool Send_CMD(string cmd, bool need_respond, bool need_log)
        {
            bool result = false;
            THS_Socket_Send send = new THS_Socket_Send();

            if (HS_Socket != null)
            {
                send.CMD = cmd;
                send.System_Code = HS_Socket.System_Code++;
                send.Need_Log = need_log;

                result = Send_CMD(send);
            }
            return result;
        }
        protected bool Send_CMD(THS_Socket_Send send)
        {
            bool result = false;
            THS_Socket_Read read = new THS_Socket_Read();

            if (HS_Socket != null && HS_Socket.Connected)
            {
                result = HS_Socket.Send_CMD(send, ref read);
            }
            return result;
        }
        protected bool Send_CMD_Respond(THS_Socket_Read read)
        {
            bool result = false;
            THS_Socket_Send send = new THS_Socket_Send();

            if (HS_Socket != null)
            {
                send.CMD = read.CMD + "@";
                send.System_Code = read.System_Code;
                send.Need_Log = read.Need_Log;

                result = HS_Socket.Send_CMD_Respond(send);
            }
            return result;
        }


        public void Send_Free_Callback_Image(HImage image)
        {
            THS_Socket_Send send = new THS_Socket_Send();

            if (HS_Socket != null && Camera != null)
            {
                send.CMD = "Free_Callback_Image";
                send.System_Code = HS_Socket.System_Code++;
                send.Need_Log = false;
                send.Values.Add(image);

                Send_CMD(send);
            }
        }
        public void Send_Hard_Callback_Image(HImage image)
        {
            THS_Socket_Send send = new THS_Socket_Send();

            if (HS_Socket != null && Camera != null)
            {
                send.CMD = "Hard_Callback_Image";
                send.System_Code = HS_Socket.System_Code++;
                send.Need_Log = true;
                send.Values.Add(image);

                Send_CMD(send);
            }
        }
        public bool Send_Set_Status()
        {
            bool result = false;
            THS_Socket_Send send = new THS_Socket_Send();

            if (HS_Socket != null && Camera != null)
            {
                send.CMD = "Set_Status";
                send.System_Code = HS_Socket.System_Code++;
                send.Need_Log = false;
                send.Values.Add(Camera.Grab_Status.ToString());
                send.Values.Add(Camera.Trig_Mode.ToString());

                result = Send_CMD(send);
            }
            return result;
        }
    }
}
