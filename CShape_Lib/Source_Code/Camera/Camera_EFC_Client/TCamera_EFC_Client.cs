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
namespace EFC.Camera.EFC
{
    public class TCamera_EFC_Client : TCamera_Base
    {
        public THS_Client HS_Socket = null;
        public TImage_List Image_List = null;
        public emTrig_Mode Trig_Mode = emTrig_Mode.FreeRun;
        public bool On_Callback = false;


        public TCamera_EFC_Client()
        {
        }
        override public void Dispose()
        {
        }
        ~TCamera_EFC_Client()
        {
        }
        public void Free()
        {
        }
        override public void Set_Log(TLog value)
        {
            inLog = value;
        }
        override public void Camera_Init()
        {

        }
        override public void Grab_Stop()
        {
            if (Send_CMD("Grab_Stop", true, true))
            {
            }
            Grab_Status = emCamera_Grab_Status.Stop;
        }
        override public void Grab_One_Image()
        {
            if (Send_CMD("Grab_One_Image", true, true))
            {
            }
            Grab_Status = emCamera_Grab_Status.Grab_Image;
        }
        override public void Grab_Life()
        {
            if (Send_CMD("Grab_Life", true, true))
            {
            }
            Grab_Status = emCamera_Grab_Status.Life;
        }
        override public bool Get_Connected()
        {
            bool result = false;

            if (HS_Socket != null) result = HS_Socket.Connected;
            return result;
        }
        public bool Set_Grab_TrigMode_Hard()
        {
            bool result = false;
            if (result = Send_Set_Grab_TrigMode_Hard())
            {
                Trig_Mode = emTrig_Mode.Hard;
                Grab_Status = emCamera_Grab_Status.Stop;
            }
            return result;
        }
        public bool Set_Grab_TrigMode_Free()
        {
            bool result = false;
            if (result = Send_Set_Grab_TrigMode_Free())
            {
                Trig_Mode = emTrig_Mode.FreeRun;
                Grab_Status = emCamera_Grab_Status.Life;
            }
            return result;
        }
        public bool Set_PageLength_Ln(int len)
        {
            bool result = false;

            result = Send_Set_PageLength_Ln(len);
            return result;
        }
        public bool Set_Expose_us(int value)
        {
            bool result = false;

            result = Send_Set_Expose_us(value);
            return result;
        }
        public bool Grab_Start()
        {
            bool result = false;

            result = Send_Grab_Start();
            return result;
        }
        public void Grab_Image_List(ref TImage_List list)
        {
            Image_List = list;
            Set_PageLength_Ln(-1);
            Grab_Status = emCamera_Grab_Status.Grab_Image_List;
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


        public void On_Recive(TJJS_Socket s_socket, THS_Socket_Read read)
        {
            switch (read.CMD)
            {
                case "Free_Callback_Image": 
                    Free_Callback_Image_Apply(read); 
                    Send_CMD_Respond(read);
                    break;

                case "Hard_Callback_Image":
                    Hard_Callback_Image_Apply(read);
                    Send_CMD_Respond(read);
                    break;
                
                case "Set_Status": 
                    Set_Status_Apply(read); 
                    Send_CMD_Respond(read);
                    break;
            }
        }
        public bool Free_Callback_Image_Apply(THS_Socket_Read read)
        {
            bool result = false;

            if (read != null && read.Values.Count >= 4)
            {
                JJS_Vision.Copy_Obj(read.Values[3].Get_Data_HImage(), ref Image);
                Inside_Callback(Image);
                result = true;
            }
            return result;
        }
        public bool Hard_Callback_Image_Apply(THS_Socket_Read read)
        {
            bool result = false;

            if (read != null && read.Values.Count >= 4)
            {
                JJS_Vision.Copy_Obj(read.Values[3].Get_Data_HImage(), ref Image);
                Inside_Callback(Image);
                result = true;
            }
            return result;
        }
        public bool Set_Status_Apply(THS_Socket_Read read)
        {
            bool result = false;
            string grab_status = "";
            string trig_mode = "";

            if (read.Values.Count >= 5)
            {
                grab_status = read.Values[3].Get_Data_String();
                trig_mode = read.Values[4].Get_Data_String();

                //switch (grab_status)
                //{
                //    case "Stop": Grab_Status = emCamera_Grab_Status.Stop; break;
                //    case "Life": Grab_Status = emCamera_Grab_Status.Life; break;
                //    case "Grab_Image": Grab_Status = emCamera_Grab_Status.Grab_Image; break;
                //    case "Grab_Image_List": Grab_Status = emCamera_Grab_Status.Grab_Image_List; break;
                //}
                switch (trig_mode)
                {
                    case "FreeRun": Trig_Mode = emTrig_Mode.FreeRun; break;
                    case "Hard": Trig_Mode = emTrig_Mode.Hard; break;
                }
                result = true;
            }

            return result;
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

        protected bool Send_Set_Grab_TrigMode_Hard()
        {
            return Send_CMD("Set_Grab_TrigMode_Hard", true, true);
        }
        protected bool Send_Set_Grab_TrigMode_Free()
        {
            return Send_CMD("Set_Grab_TrigMode_Free", true, true);
        }
        protected bool Send_Set_PageLength_Ln(int len)
        {
            bool result = false;
            THS_Socket_Send send = new THS_Socket_Send();

            if (HS_Socket != null)
            {
                send.CMD = "Set_PageLength_Ln";
                send.System_Code = HS_Socket.System_Code++;
                send.Need_Log = true;
                send.Values.Add(len);
                result = Send_CMD(send);
            }
            return result;
        }
        protected bool Send_Set_Expose_us(int value)
        {
            bool result = false;
            THS_Socket_Send send = new THS_Socket_Send();

            if (HS_Socket != null)
            {
                send.CMD = "Set_Expose_us";
                send.System_Code = HS_Socket.System_Code++;
                send.Need_Log = true;
                send.Values.Add(value);
                result = Send_CMD(send);
            }
            return result;
        }
        protected bool Send_Grab_Start()
        {
            return Send_CMD("Grab_Start", true, true);
        }
    }

}
