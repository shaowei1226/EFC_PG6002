using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using HalconDotNet;
using EFC.Camera;
using AD_LINK;


namespace EFC.Camera.AD_Link
{
    public enum emVideo_Format { Full_NTSC, Full_Pal, CIF_NTSC, CIF_Pal, QCIF_NTSC, QCIF_Pal };
    public class AD_Link_Angelo
    {
        static public int Max_Camera_Count = 16;
        static public TCamera_AD_Link[] Cameras = new TCamera_AD_Link[0];

        static public int Camera_Count
        {
            get
            {
                return Cameras.Length;
            }
            set
            {
                int old_count;
                old_count = Cameras.Length;
                Array.Resize(ref Cameras, value);
                for (int i = old_count; i < value; i++)
                    Cameras[i] = new TCamera_AD_Link();
            }
        }
        static public void Find_All_Camera()
        {
            try
            {
                for (int i = 0; i < Max_Camera_Count; i++)
                {
                    if (Angelo.AngeloRTV_Initial((ushort)i) == 0)
                    {
                        Camera_Count++;
                        Cameras[Camera_Count - 1].Set("Camera_Name"+i.ToString(), i);
                        Cameras[Camera_Count - 1].Camera_Init();
                    }
                }
            }
            catch
            {

            }
        }
        static public TCamera_AD_Link Get_Camera_By_Port(int no)
        {
            TCamera_AD_Link result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Cameras[i].Port_No == no)
                {
                    result = Cameras[i];
                    break;
                }
            }
            return result;
        }
    }
    public class TCamera_AD_Link : TCamera_Base
    {
        private int FPort_No = -1;
        private emVideo_Format FVideo_Format;
        private CallBack ADLink_Callback;

        public int Port_No
        {
            get
            {
                return FPort_No;
            }
        }
        public int Card_No
        {
            get
            {
                return (FPort_No / 4);
            }
        }
        public int Channel_No
        {
            get
            {
                return FPort_No % 4;
            }
        }

        public TCamera_AD_Link()
        {
            FCamera_Type_Name = "TAD_Link_Camera";
            FImage_Width = 640;
            FImage_Height = 480;
            FColor_Format = emColor_Format.GRAY8;
            FVideo_Format = emVideo_Format.Full_NTSC;
        }
        public void Set_Color_Format(emColor_Format format)
        {
            switch (format)
            {
                case emColor_Format.RGB16: Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 0); break;
                case emColor_Format.GRAY8: Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 1); break;
                case emColor_Format.RGB15: Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 2); break;
                case emColor_Format.RGB24: Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 3); break;
                case emColor_Format.RGB32: Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 4); break;
                case emColor_Format.RGB8:  Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 5); break;
                case emColor_Format.RAW8X: Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 6); break;
                case emColor_Format.YUY24: Angelo.AngeloRTV_Set_Color_Format((ushort)FPort_No, 7); break;
            }
        }
        public void Set_Video_Format(emVideo_Format format)
        {
            switch (format)
            {
                case emVideo_Format.Full_NTSC: Angelo.AngeloRTV_Set_Video_Format((ushort)FPort_No, 0); break;
                case emVideo_Format.Full_Pal:  Angelo.AngeloRTV_Set_Video_Format((ushort)FPort_No, 1); break;
                case emVideo_Format.CIF_NTSC:  Angelo.AngeloRTV_Set_Video_Format((ushort)FPort_No, 2); break;
                case emVideo_Format.CIF_Pal:   Angelo.AngeloRTV_Set_Video_Format((ushort)FPort_No, 3); break;
                case emVideo_Format.QCIF_NTSC: Angelo.AngeloRTV_Set_Video_Format((ushort)FPort_No, 4); break;
                case emVideo_Format.QCIF_Pal:  Angelo.AngeloRTV_Set_Video_Format((ushort)FPort_No, 5); break;
            }
        }
        public void Set(string camera_name, int port_no, emColor_Format cf, emVideo_Format vf)
        {
            Name = camera_name;
            FPort_No = port_no;
            FColor_Format = cf;
            FVideo_Format = vf;
        }
        public void Set(string camera_name, int port_no)
        {
            Name = camera_name;
            FPort_No = port_no;
        }
        public void Set(emColor_Format cf, emVideo_Format vf)
        {
            FColor_Format = cf;
            FVideo_Format = vf;
        }
        public void Set_Camera(string type)
        {
            switch (type)
            {
                default:
                case "CIS":
                    FColor_Format = emColor_Format.GRAY8;
                    FVideo_Format = emVideo_Format.Full_NTSC;
                    break;
            }
        }
        public override void Camera_Init()
        {
            base.Camera_Init();
            try
            {
                //if (Angelo.AngeloRTV_Initial(Camera_Index) == 0)
                {
                    Angelo.AngeloRTV_Capture_Stop((ushort)Port_No);
                    ADLink_Callback = new CallBack(Inside_CallBack);
                    Angelo.AngeloRTV_Set_Callback((ushort)Port_No, ADLink_Callback);
                    Set_Color_Format(FColor_Format);
                    Set_Video_Format(FVideo_Format);
                    FImage_Width = 640;
                    FImage_Height = 480;
                    FInit = true;
                }
            }
            catch
            {

            }
        }
        private void Inside_CallBack(IntPtr BufferAddress, UInt16 PortNo)
        {
            lock (Image)
            {
                Image.GenImage1("byte", Image_Width, Image_Height, BufferAddress);
                Timer_Grab_Timeout.Enabled = false;
                if (CallBack != null) CallBack(this);
                Refalsh = true;
            }
        }
        override public void Grab_Image()
        {
            if (FInit)
            {
                Timer_Grab_Timeout.Enabled = true;
                Grab_Status = emCamera_Grab_Status.Grab_Image;
                Angelo.AngeloRTV_Capture_Start((ushort)FPort_No, 0x01);
                while (Grab_Status == emCamera_Grab_Status.Grab_Image && !Grab_Timeout)
                {
                    //System.Windows.Forms.Application.DoEvents();
                }
                Grab_Stop();
            }
        }
        override public void Grab_Life()
        {
            short rr;
            if (FInit)
            {
                Grab_Status = emCamera_Grab_Status.Life;
                rr = Angelo.AngeloRTV_Capture_Start((ushort)FPort_No, 0xFFFFFFFF);
            }
        }
        override public void Grab_Stop()
        {
            try
            {
                Angelo.AngeloRTV_Capture_Stop((ushort)FPort_No);
                Grab_Status = emCamera_Grab_Status.Stop;
                Timer_Grab_Timeout.Enabled = false;
            }
            catch
            {

            }
        }
        override public bool Get_Connected()
        {
            return true;
        }
        override public void Reconnect()
        {
        }

    }
}
