using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Euresys.MultiCam;
using HalconDotNet;
using System.Threading;
using EFC.Tool;
using EFC.Camera;
using EFC.Vision.Halcon;

namespace EFC.Camera.MultiCam
{
    public enum emTrig_Mode {FreeRun, Hard};


    public struct stMultiCam_Board_Info
    {
        public string Board_Name;
        public string Serial_Number;
        public string Board_Type;
    }
    public class TMultiCam_Cards_Info
    {
        public int Board_Count;
        public stMultiCam_Board_Info[] Boards = new stMultiCam_Board_Info[0];
    }
    public static class MultiCam_Cards
    {
        static public bool FInit;
        static public TMultiCam_Cards_Info System_Info = new TMultiCam_Cards_Info();
        //public int Cards_Count;
        static public TMultiCam_Card[] Cards = new TMultiCam_Card[0];

        static public int Cards_Count
        {
            get
            {
                return Cards.Length;
            }
            set
            {
                int old_count;

                old_count = Cards.Length;
                Array.Resize(ref Cards, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Cards[i] = new TMultiCam_Card();
                }
            }
        }
        static public void Init()
        {
            try
            {
                MC.OpenDriver();
                Get_System_Info();
                FInit = true;
            }
            catch
            {

            }
        }
        static public void Close()
        {
            MC.CloseDriver();
        }
        static public void Get_System_Info()
        {
            // get number of boards
            MC.GetParam(MC.CONFIGURATION, "BoardCount", out System_Info.Board_Count);
            Array.Resize(ref System_Info.Boards, System_Info.Board_Count);
            for (int i = 0; i < System_Info.Board_Count; i++)
            {
                // get number of boards           
                MC.GetParam((uint)(MC.BOARD + i), "BoardName", out System_Info.Boards[i].Board_Name);
                // get serial number
                MC.GetParam((uint)(MC.BOARD + i), "SerialNumber", out System_Info.Boards[i].Serial_Number);
                // get board type
                MC.GetParam((uint)(MC.BOARD + i), "BoardType", out System_Info.Boards[i].Board_Type);
            }

        }
        static public bool Add_Card(string name, string type, bool channel_a, bool channel_b)
        {
            bool result = false;
            int no = 0;

            no = Cards_Count;
            Cards_Count = Cards_Count + 1;
            Cards[no].Set(name, type, no, channel_a, channel_b);
            result = true;

            return result;
        }
        static public bool Add_System_All_Card()
        {
            bool result = false;

            for (int i = 0; i < System_Info.Board_Count; i++)
            {
                switch (System_Info.Boards[i].Board_Type)
                {
                    case "GRABLINK_BASE":
                        Add_Card(System_Info.Boards[i].Board_Name, "BASE", true, false);
                        break;

                    case "GRABLINK_FULL":
                        Add_Card(System_Info.Boards[i].Board_Name, "FULL", true, true);
                        break;
                }
            }
            return result;
        }
    }
    public class TMultiCam_Card
    {
        string FCard_Name;
        int FCard_Index;
        public string FCard_Type;
        public TCamera_MultiCam[] Cameras = new TCamera_MultiCam[0];

        public int Camera_Count
        {
            get
            {
                return Cameras.Length;
            }
            set
            {
                int old_count = Cameras.Length;
                Array.Resize(ref Cameras, value);
                for (int i = old_count; i < value; i++)
                    Cameras[i] = new TCamera_MultiCam();
            }

        }
        public TMultiCam_Card()
        {
            FCard_Name = "Default_Card";
            Camera_Count = 0;
            FCard_Index = 0;
            for (int i = 0; i < Cameras.Length; i++) Cameras[i] = new TCamera_MultiCam();
        }
        public void Set(string card_name, string type, int index, bool channel_a, bool channel_b)
        {
            FCard_Name = card_name;
            FCard_Type = type;
            FCard_Index = index;
        }
        public bool Add_Camera(string camera_name, bool channel_a, bool channel_b)
        {
            bool result = false;
            UInt32 handle;
            TCamera_MultiCam camera = null;

            try
            {
                if (Camera_Count <= 0)
                {
                    //建立Channel
                    Camera_Count++;
                    camera = Cameras[0];
                    
                    MC.Create("CHANNEL", out handle);
                    camera.Handle = handle;
                    camera.Name = camera_name;

                    //設定Index      
                    MC.SetParam(camera.Handle, "DriverIndex", FCard_Index);
                    
                    //設定Channel
                    string type = Get_Connector_Type(channel_a, channel_b);
                    MC.SetParam(camera.Handle, "Connector", "M");

                    //配置取像用的Surface. 指定Surface的數目, 由Multicam自動配置.
                    //Euresys.MultiCam.MC.SetParam(Cards.Handle, MC_SurfaceCount, EURESYS_SURFACE_COUNT);    
                    //Enable MultiCam signals
                    MC.SetParam(camera.Handle,
                                MC.SignalEnable
                              + MC.SIG_SURFACE_PROCESSING, "ON");
                    //MC.SetParam(camera.Handle,
                    //            MC.SignalEnable
                    //          + MC.SIG_ACQUISITION_FAILURE, "ON");

                    //設定狀態為Ready
                    //MC.SetParam(camera.Handle, "ChannelState", "READY");
                    MC.RegisterCallback(camera.Handle, camera.m_CallBack, camera.Handle);

                    result = true;
                }
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }

            if (!result) Camera_Count = 0;
            return result;
        }
        public bool Add_Camera(string camera_name, bool channel_a, bool channel_b, string cam_file)
        {
            bool result = false;
            TCamera_MultiCam camera;

            result = Add_Camera(camera_name, channel_a, channel_b);
            if (result)
            {
                camera = Cameras[Camera_Count - 1];
                //設定像機設定檔           
                if (System.IO.File.Exists(cam_file)) MC.SetParam(camera.Handle, "CamFile", cam_file);
                else result = false;
            }
            return result;
        }
        public bool Add_Camera(string camera_name, bool channel_a, bool channel_b, string cam_file, string board_topology)
        {
            bool result = false;

            MC.SetParam((uint)(MC.BOARD + FCard_Index), "BoardTopology", board_topology);
            result = Add_Camera(camera_name, channel_a, channel_b, cam_file);
            return result;
        }
        public string Get_Status_Str(string status)
        {
            return "aaa";
        }
        private string Get_Connector_Type(bool channel_a, bool channel_b)
        {
            string result = "";

            if (FCard_Type == "BASE")
            {
                if (channel_a || channel_b) result = "M";
            }
            else
            {
                if (channel_a && channel_b) result = "M";
                if (channel_a && !channel_b) result = "A";
                if (!channel_a && channel_b) result = "B";
            }
            return result;
        }
    }
    public class TCamera_MultiCam : TCamera_Base
    {
        protected UInt32                    FHandle;
        public MC.CALLBACK                  m_CallBack;
        public bool                         Wait_Unlock;
        public TImage_List                  Image_List = null;
        public emTrig_Mode                  Trig_Mode = emTrig_Mode.FreeRun;

        public string ChannelState
        {
            get
            {
                string result = "";

                Euresys.MultiCam.MC.GetParam(FHandle, "ChannelState", out result);
                return result;
            }
        }
        public UInt32 Handle
        {
            get
            {
                return FHandle;
            }
            set
            {
                FHandle = value;
            }
        }
        public TCamera_MultiCam()
        {
            FCamera_Type_Name = "TMultiCam_Camera";
            Log_Source = "TCamera_MultiCam";
            FInit = false;
            OnCallBack = false;
            CallBack = null;
            m_CallBack = new MC.CALLBACK(Inside_CallBack);
        }
        override public void Dispose()
        {
            Grab_Stop();
        }
        public void Camera_Init()
        {
            base.Camera_Init();
            Update();
        }
        public bool Grab_Start()
        {
            bool result = false;
            string st = "";

            Log_Add("Grab_Start", "Grab_Start", emLog_Type.Generally);
            if (ChannelState != "ACTIVE")
            {
                result = Set_ChannelState("ACTIVE", 500);
            }
            return result;
        }
        override public void Grab_Stop()
        {
            Log_Add("Grab_Stop", "Grab_Stop", emLog_Type.Generally);
            if (ChannelState != "ORPHAN")
            {
                if (Set_ChannelState("ORPHAN", 500))
                {
                }
            }
            JJS_LIB.Sleep(100);
            Grab_Status = emCamera_Grab_Status.Stop;
        }
        override public void Grab_One_Image()
        {
            Log_Add("Grab_One_Image", "Grab_One_Image", emLog_Type.Generally);
            
            if (Grab_Status != emCamera_Grab_Status.Stop) Grab_Stop();
            Grab_Start();
            Grab_Status = emCamera_Grab_Status.Grab_Image;
        }
        override public void Grab_Life()
        {
            Log_Add("Grab_Life", "Grab_Life", emLog_Type.Generally);
            if (!OnLife)
            {
                Grab_Stop();
                Set_Grab_TrigMode_Free();
                Grab_Start();
            }
            Grab_Status = emCamera_Grab_Status.Life;
        }
        override public bool Get_Connected()
        {
            return true;
        }



        public void Gen_Image(emColor_Format format, object bufferAddress, int w, int h, ref HImage image)
        {
            IntPtr bufferAddress_ptr = (IntPtr)bufferAddress;
            switch (format)
            {
                case emColor_Format.GRAY8: image.GenImage1("byte", w, h, bufferAddress_ptr); break;
                case emColor_Format.RGB24: Gen_Image_RGB(bufferAddress_ptr, w, h, ref image); break;
            }
        }
        public void Gen_Image_RGB(IntPtr bufferAddress, int w, int h, ref HImage image)
        {
            int FiCount = w * h;
            byte[] pixel_r = new byte[FiCount];
            byte[] pixel_g = new byte[FiCount];
            byte[] pixel_b = new byte[FiCount];
            IntPtr ptr_r, ptr_g, ptr_b;
            
            unsafe
            {
                byte* ptr = (byte*)bufferAddress;
                for (int i = 0; i < FiCount; i++)
                {
                    pixel_r[i] = *(ptr + i * 3 + 2);
                    pixel_g[i] = *(ptr + i * 3 + 1);
                    pixel_b[i] = *(ptr + i * 3 + 0);
                }

                fixed (byte* p = pixel_r) { ptr_r = (IntPtr)p; }
                fixed (byte* p = pixel_g) { ptr_g = (IntPtr)p; }
                fixed (byte* p = pixel_b) { ptr_b = (IntPtr)p; }

                image.GenImage3("byte", w, h, ptr_r, ptr_g, ptr_b);
            }
        }
        private void Inside_CallBack(ref MC.SIGNALINFO signalInfo)
        {
            IntPtr bufferAddress;
            HImage new_image = new HImage();

            if (!OnCallBack)
            {
                OnCallBack = true;
                switch (signalInfo.Signal)
                {
                    case MC.SIG_SURFACE_PROCESSING:
                        //Get_Image_Width(signalInfo.SignalInfo, out FImage_Width);
                        //Get_Image_Height(signalInfo.SignalInfo, out FImage_Height);
                        MC.GetParam(signalInfo.SignalInfo, "SurfaceAddr", out bufferAddress);

                        lock (Image)
                        {
                            if (Grab_Status != emCamera_Grab_Status.Grab_Image_List)
                            {
                                Image.Dispose();
                                Gen_Image(FColor_Format, bufferAddress, FImage_Width, FImage_Height, ref Image);
                                Refalsh = true;
                            }
                        }

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
                                if (Image_List.Grab_Call_Back != null) Image_List.Grab_Call_Back(this, bufferAddress, Image_List);
                                if (Image_List.Grab_Finish)
                                {
                                    Image_List.Grab_Finish_Flag = true;
                                    Grab_Stop();
                                    if (Image_List.Grab_Finish_Call_Back != null) Image_List.Grab_Finish_Call_Back(this, bufferAddress, Image_List);
                                }
                                break;
                        }
                        if (CallBack != null) CallBack(this);
                        Refalsh = true;
                        break;

                    default:
                        //throw new Euresys.MultiCamException("Unknown signal.");
                        break;
                }

                OnCallBack = false;
            }
        }
        public void Set_Color_Format(string color_format)
        {
            switch (color_format)
            {
                case "RGB8": FColor_Format = emColor_Format.RGB8; break;
                case "RGB15": FColor_Format = emColor_Format.RGB15; break;
                case "RGB16": FColor_Format = emColor_Format.RGB16; break;
                case "RGB24": FColor_Format = emColor_Format.RGB24; break;
                case "RGB32": FColor_Format = emColor_Format.RGB32; break;
                case "GRAY8": FColor_Format = emColor_Format.GRAY8; break;
                case "RAW8X": FColor_Format = emColor_Format.RAW8X; break;
                case "YUY24": FColor_Format = emColor_Format.YUY24; break;
            }
        }
        public void Update()
        {
            int buffer_size = 0;
            string color_format;

            Grab_Stop();
            MC.SetParam(FHandle, "SurfaceCount", 50);
            Get_Image_Width(FHandle, out FImage_Width);
            Get_Image_Height(FHandle, out FImage_Height);   

            MC.GetParam(FHandle, "ColorFormat", out color_format);            //取得Color_Format
            MC.GetParam(FHandle, "BufferSize", out buffer_size);              //取得影像緩衝區大小
            Set_Color_Format(color_format);

            FPixel_Size = buffer_size / (FImage_Width * FImage_Height);
            lock(Image)
            {
                Image.GenImageConst("byte", FImage_Width, FImage_Height);
            }
            FInit = true;
        }
        public void Grab_Image_List(ref TImage_List list)
        {
            Grab_Stop();
            Image_List = list;
            MC.SetParam(FHandle, "SeqLength_Pg", -1);
            Grab_Start();
            Grab_Status = emCamera_Grab_Status.Grab_Image_List;
        }
        public void Set_Param(string name, int value)
        {
            MC.SetParam(Handle, name, value);
        }
        public void Set_Param(string name, double value)
        {
            MC.SetParam(Handle, name, value);
        }
        public void Set_Param(string name, string value)
        {
            MC.SetParam(Handle, name, value);
        }
        public void Set_Grab_TrigMode_Hard()
        {
            Log_Add("Set_Grab_TrigMode_Hard", "Set_Grab_TrigMode_Hard", emLog_Type.Generally);
            Grab_Stop();
            MC.SetParam(FHandle, "SurfaceCount", 50);
            MC.SetParam(FHandle, "TrigMode", "HARD");
            Trig_Mode = emTrig_Mode.Hard;
            Grab_Start();
        }
        public void Set_Grab_TrigMode_Free()
        {
            Log_Add("Set_Grab_TrigMode_Free", "Set_Grab_TrigMode_Free", emLog_Type.Generally);

            Grab_Stop();
            MC.SetParam(FHandle, "SurfaceCount", 1);
            MC.SetParam(FHandle, "SeqLength_Fr", -1);
            Euresys.MultiCam.MC.SetParam(FHandle, "AcquisitionMode", "SNAPSHOT");
            Euresys.MultiCam.MC.SetParam(FHandle, "TrigMode", "IMMEDIATE");
            Trig_Mode = emTrig_Mode.FreeRun;
            Grab_Start();
        }
        public void Set_PageLength_Ln(int len)
        {
            Log_Add("Set_PageLength_Ln", "Set_PageLength_Ln", emLog_Type.Generally);
            MC.SetParam(FHandle, "PageLength_Ln", len);
        }
        public void SeqLength_Pg(int len)
        {
            Log_Add("SeqLength_Pg", "SeqLength_Pg", emLog_Type.Generally);
            MC.SetParam(FHandle, "SeqLength_Pg", -1);
        }
        public void Set_Expose_us(int value)
        {
            Log_Add("Set_Expose_us", "Set_Expose_us", emLog_Type.Generally);
            MC.SetParam(FHandle, "Expose_us", value);
        }
        public void Set_HImage(IntPtr buffer_p)
        {
            HImage tmp_image = new HImage();
            lock (Image)
            {
                tmp_image.GenImage1("byte", FImage_Width, FImage_Height, buffer_p);
                switch (FColor_Format)
                {
                    case emColor_Format.Bayer_GR8:
                        tmp_image = tmp_image.CfaToRgb("bayer_gr", "bilinear");
                        break;

                    case emColor_Format.Bayer_GB8:
                        tmp_image = tmp_image.CfaToRgb("bayer_gb", "bilinear");
                        break;

                    case emColor_Format.Bayer_BG8:
                        tmp_image = tmp_image.CfaToRgb("bayer_bg", "bilinear");
                        break;

                    case emColor_Format.Bayer_RG8:
                        tmp_image = tmp_image.CfaToRgb("bayer_rg", "bilinear");
                        break;
                }

                if (Mirror_Row) tmp_image = tmp_image.MirrorImage("row");
                if (Mirror_Col) tmp_image = tmp_image.MirrorImage("column");
                if (Rotate_Image) tmp_image = tmp_image.RotateImage(90.0, "constant");
                JJS_Vision.Copy_Obj(tmp_image, ref Image);
                Refalsh = true;
            }
            tmp_image.Dispose();
        }

        private void Get_Image_Width(UInt32 instance, out Int32 value)
        {
            //MC.GetParam(FHandle, "ImageSizeX", out FImage_Width);             //取得影像寬度
            MC.GetParam(instance, "Hactive_Px", out value);             //取得影像寬度
        }
        private void Get_Image_Height(UInt32 instance, out Int32 value)
        {
            string imaging = "";

            //MC.GetParam(FHandle, "ImageSizeY", out FImage_Height);            //取得影像高度
            MC.GetParam(instance, "Imaging", out imaging);
            if (imaging == "LINE")
            {
                MC.GetParam(instance, "PageLength_Ln", out value);         //取得影像高度
            }
            else
            {
                MC.GetParam(instance, "Vactive_Ln", out value);            //取得影像高度
            }
        }
        public bool Set_ChannelState(string status, double time = 500)
        {
            bool result = false;
            DateTime in_time;
            bool time_out = false;
            string msg = "";

            in_time = DateTime.Now;
            if (ChannelState != status)
            {
                Euresys.MultiCam.MC.SetParam(FHandle, "ChannelState", status);
                while (ChannelState != status && !time_out)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                    time_out = JJS_LIB.Is_Timeout(in_time, time);
                };
            }

            if (time_out)
            {
                result = false;
                msg = string.Format("Set_ChannelState={0:s} Now_ChannelState={1:s}", status, ChannelState);
                Log_Add("Set_ChannelState", msg, Tool.emLog_Type.Error);
            }
            else
            {
                result = true;
                msg = string.Format("Set_ChannelState={0:s} OK.", status);
                Log_Add("Set_ChannelState", msg, Tool.emLog_Type.Generally);
            }

            return result;
        }
    }
}
