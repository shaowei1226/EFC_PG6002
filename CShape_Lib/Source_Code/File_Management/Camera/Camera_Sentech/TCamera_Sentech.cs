using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading;
using System.Runtime.InteropServices;
using PvDotNet;
using EFC.Tool;
using EFC.Camera;
using EFC.Vision.Halcon;
using HalconDotNet;


namespace EFC.Camera.Sentech
{
    public static class TSentech_Giga
    {
        private static PvSystem Pv_System = new PvSystem();
        private static PvInterface[] Pv_Card = new PvInterface[0];
        public static TCamera_Sentech_Giga[] Camera = new TCamera_Sentech_Giga[0];


        public static int Card_Count
        {
            get
            {
                return Pv_Card.Length;
            }
            set
            {
                int old_count;
                old_count = Pv_Card.Length;
                Array.Resize(ref Pv_Card, value);
            }
        }
        public static int Camera_Count
        {
            get
            {
                return Camera.Length;
            }
            set
            {
                int old_count;
                old_count = Camera.Length;
                Array.Resize(ref Camera, value);
                for (int i = old_count; i < value; i++)
                    Camera[i] = new TCamera_Sentech_Giga();
            }
        }
        public static void Find_All_Camera()
        {
            int card_count = 0;
            int start_camera_count = 0;
            int camera_count = 0;

            try
            {
                Pv_System.Find();
                card_count = (int)Pv_System.InterfaceCount;
                Card_Count = card_count;
                for (int i = 0; i < card_count; i++)
                {
                    Pv_Card[i] = Pv_System.GetInterface((uint)i);
                    camera_count = (int)Pv_Card[i].DeviceCount;
                    start_camera_count = Camera_Count;
                    Camera_Count = Camera_Count + camera_count;
                    for (int j = 0; j < camera_count; j++)
                    {
                        Camera[start_camera_count + j].Pv_DeviceInfo = Pv_Card[i].GetDeviceInfo((uint)j);
                        Camera[start_camera_count + j].Camera_Init();
                    }
                }
            }
            catch
            {

            }
        }
        public static void Dispose()
        {
            for(int i=0; i<Camera.Length; i++)
            {
                Camera[i].Grab_Stop();
                Camera[i].Dispose();
            }
        }
        public static TCamera_Sentech_Giga Get_Camera_By_IP(string ip)
        {
            TCamera_Sentech_Giga result = null;

            for(int i=0; i<Camera_Count; i++)
            {
                if (Camera[i].Pv_DeviceInfo.IPAddress == ip)
                {
                    result = Camera[i];
                    break;
                }
            }
            return result;
        }
        public static TCamera_Sentech_Giga Get_Camera_By_UserDefinedName(string name)
        {
            TCamera_Sentech_Giga result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Camera[i].Pv_DeviceInfo.UserDefinedName == name)
                {
                    result = Camera[i];
                    break;
                }
            }
            return result;
        }
        public static TCamera_Sentech_Giga Get_Camera_By_SerialNumber(string serial_number)
        {
            TCamera_Sentech_Giga result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Camera[i].Pv_DeviceInfo.SerialNumber == serial_number)
                {
                    result = Camera[i];
                    break;
                }
            }
            return result;
        }
    }

    public class TCamera_Sentech_Giga : TCamera_Base
    {
        public bool                    Terminate;
        private Thread                 Back_Thread = null;
        public PvDeviceInfo            Pv_DeviceInfo = null;
        public PvDevice                Pv_Device = null;
        public PvStreamBase            Stream = null;
        public PvPipeline              Pv_Pipeline = null;
        public PvResult                Pv_Result = new PvResult();

        private bool                   In_IsConnected = false;
        protected System.Timers.Timer  Timer_Reconnect = new System.Timers.Timer();
        private bool                   On_Loop = false;

        public TCamera_Sentech_Giga()
        {
            FCamera_Type_Name = "TSentech_Giga_Camera";
            Terminate = false;
            Back_Thread = new Thread(Execute);
            Back_Thread.Start();

            Timer_Reconnect.Interval = 5000;
            Timer_Reconnect.Enabled = false;
            Timer_Reconnect.Elapsed += On_Reconnected;
        }
        public override void Dispose()
        {
            Terminate = true;
        }
        ~TCamera_Sentech_Giga()
        {
            Terminate = true;
        }
        public void Execute()
        {
            PvBuffer pv_buffer = null;
            int w, h;

            while (!Terminate)
            {
                if (Init && Connected)
                {
                    On_Loop = true;
                    Pv_Result = Pv_Pipeline.RetrieveNextBuffer(ref pv_buffer);
                    if (Pv_Result.IsOK && pv_buffer != null && pv_buffer.OperationResult.IsOK)
                    {
                        w = (int)pv_buffer.Image.Width;
                        h = (int)pv_buffer.Image.Height;
                        if (w > 0 && h > 0)
                        {
                            FImage_Width = w;
                            FImage_Height = h;
                            if (!OnCallBack)
                            {
                                unsafe
                                {
                                    Inside_CallBack((IntPtr)pv_buffer.DataPointer);
                                }
                            }
                        }
                    }
                    if (pv_buffer != null && Pv_Pipeline != null) Pv_Pipeline.ReleaseBuffer(pv_buffer);
                    On_Loop = false;
                }
                    
                System.Threading.Thread.Sleep(1);
            }         
        }
        private void Inside_CallBack(IntPtr buffer_p)
        {
            OnCallBack = true;

            switch (Grab_Status)
            {
                case emCamera_Grab_Status.Grab_Image:
                    Set_HImage(buffer_p);
                    Grab_Stop();
                    if (CallBack != null) CallBack(this);
                    break;

                case emCamera_Grab_Status.Life:
                    Set_HImage(buffer_p);
                    if (CallBack != null) CallBack(this);
                    break;
            }
            OnCallBack = false;
        }
        public void Free()
        {
            try
            {
                if (Pv_Device.IsConnected)
                {
                    Pv_Device.Disconnect();
                    Pv_Device.Dispose();

                    Pv_Pipeline.Stop();
                    Pv_Pipeline.Dispose();

                    Stream.Close();
                    Stream.Dispose();

                    Pv_Device = null;
                    Pv_Pipeline = null;
                    Stream = null;
                }
            }
            catch(Exception e)
            {
                Log_Add("Free Exception=" + e.Message);
            }
        }
        override public void Camera_Init()
        {
            Int64 lPayloadSize;

            Log_Add("Camera_Init Start.");
            try
            {
                Free();
                Pv_Device = new PvDevice();
                Stream = new PvStream();

                Pv_Device.Connect(Pv_DeviceInfo);
                Pv_Device.NegotiatePacketSize();
                Pv_Device.OnLinkDisconnected += On_Disconnected;
                Pv_Device.OnLinkReconnected += On_Reconnected;

                Stream.Open(Pv_DeviceInfo.IPAddress);
                Pv_Pipeline = new PvPipeline(Stream);
                Pv_Device.SetStreamDestination(Stream.LocalIPAddress, Stream.LocalPort);

                FImage_Width = (int)Pv_Device.GenParameters.GetIntegerValue("Width");
                FImage_Height = (int)Pv_Device.GenParameters.GetIntegerValue("Height");
                Get_Color_Format();
                Image.GenImageConst("byte", FImage_Width, FImage_Height);

                PvGenEnum AcquisitionMode = Pv_Device.GenParameters.GetEnum("AcquisitionMode");
                //AcquisitionMode.ValueString = "SingleFrame";
                AcquisitionMode.ValueString = "Continuous";

                Pv_Device.GenParameters.SetIntegerValue("TLParamsLocked", 1);
                lPayloadSize = Pv_Device.GenParameters.GetIntegerValue("PayloadSize");
                Pv_Pipeline.BufferSize = (UInt32)lPayloadSize;
                Pv_Pipeline.BufferCount = 16;
                Pv_Pipeline.Start();

                //Grab_Image();
                FInit = true;
            }
            catch(Exception e)
            {
                Log_Add("Camera_Init Exception=" + e.Message);
            }

            if (Pv_Device.IsConnected)
            {
                Log_Add("Camera_Init OK.");
                In_IsConnected = true;
            }
            else
                Log_Add("Camera_Init NG.");
        }
        override public void Grab_Stop()
        {
            try
            {
                Pv_Device.GenParameters.ExecuteCommand("AcquisitionStop");
            }
            catch { }
            Grab_Status = emCamera_Grab_Status.Stop;
            //Timer_Disconnect.Enabled = false;
        }
        override public void Grab_One_Image()
        {
            if (Pv_Device.IsConnected)
            {
                //Pv_Device.GenParameters.SetIntegerValue("TLParamsLocked", 0);
                //PvGenEnum AcquisitionMode = Pv_Device.GenParameters.GetEnum("AcquisitionMode");
                //AcquisitionMode.ValueString = "SingleFrame";
                //Pv_Device.GenParameters.SetIntegerValue("TLParamsLocked", 1);
                Pv_Device.GenParameters.ExecuteCommand("AcquisitionStart");
                Grab_Status = emCamera_Grab_Status.Grab_Image;
            }
        }
        override public void Grab_Life()
        {
            if (Pv_Device.IsConnected)
            {
                //Pv_Device.GenParameters.SetIntegerValue("TLParamsLocked", 0);
                //PvGenEnum AcquisitionMode = Pv_Device.GenParameters.GetEnum("AcquisitionMode");
                //AcquisitionMode.ValueString = "SingleFrame";
                //Pv_Device.GenParameters.SetIntegerValue("TLParamsLocked", 1);
                Pv_Device.GenParameters.ExecuteCommand("AcquisitionStart");
            }
            Grab_Status = emCamera_Grab_Status.Life;
            //Timer_Disconnect.Enabled = true;
        }
        override public bool Get_Connected()
        {
            bool result = false;

            result = In_IsConnected;
            //if (Pv_Device != null && Pv_Pipeline != null) result = Pv_Device.IsConnected;
            return result;
        }

  
        
        
        public void On_Disconnected(PvDevice aDevice)
        {
            Log_Add("Camera=" + Name + " On_Disconnected.");
            In_IsConnected = false;
            FInit = false;
            while (On_Loop) { };
            Grab_Status = emCamera_Grab_Status.Stop;
            Timer_Reconnect.Enabled = true;
        }
        public void On_Reconnected(PvDevice aDevice)
        {
            Log_Add("Camera=" + Name + " On_Reconnected.");
        }
        public void On_Reconnected(object sender, EventArgs e)
        {
            Timer_Reconnect.Enabled = false;
            Log_Add("Camera=" + Name + " On_Reconnected.");
            Camera_Init();
            if (!FInit) Timer_Reconnect.Enabled = true;
        }
        private void Set_HImage(IntPtr buffer_p)
        {
            lock (Image)
            {
                Image.GenImage1("byte", FImage_Width, FImage_Height, buffer_p);
                switch (FColor_Format)
                {
                    case emColor_Format.Bayer_GR8:
                        Image = Image.CfaToRgb("bayer_gr", "bilinear"); 
                        break;

                    case emColor_Format.Bayer_GB8:
                        Image = Image.CfaToRgb("bayer_gb", "bilinear");
                        break;

                    case emColor_Format.Bayer_BG8: 
                        Image = Image.CfaToRgb("bayer_bg", "bilinear"); 
                        break;

                    case emColor_Format.Bayer_RG8:
                        Image = Image.CfaToRgb("bayer_rg", "bilinear");
                        break;
                }

                if (Mirror_Row) Image = Image.MirrorImage("row");
                if (Mirror_Col) Image = Image.MirrorImage("column");
                Refalsh = true;
            }
        }
        private void Get_Color_Format()
        {
                PvGenEnum PixelFormat = null;

            PixelFormat = Pv_Device.GenParameters.GetEnum("PixelFormat");

            switch(PixelFormat.ValueString)
            {
                case "Mono8": FColor_Format = emColor_Format.GRAY8; break;
                case "BayerGR8": FColor_Format = emColor_Format.Bayer_GR8; break;
                case "BayerGB8": FColor_Format = emColor_Format.Bayer_GB8; break;
                case "BayerBG8": FColor_Format = emColor_Format.Bayer_BG8; break;
                case "BayerRG8": FColor_Format = emColor_Format.Bayer_RG8; break;
            }            
        }
    }
}
