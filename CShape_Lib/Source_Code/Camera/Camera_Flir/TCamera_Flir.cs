using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using EFC.Camera;
using HalconDotNet;
using FlyCapture2Managed;


namespace EFC.Camera.Flir
{
    public static class TFlir_GigaE
    {
        public static string Version; 
        public static TCamera_Flir_GigaE[] Camera = new TCamera_Flir_GigaE[0];


        private static void Get_GigaE_Camera(IntPtr device_info)
        {
            //MyCamera.MV_CC_DEVICE_INFO device;
            //MyCamera.MV_GIGE_DEVICE_INFO giga_Info;
            //int no = 0;

            //device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(device_info, typeof(MyCamera.MV_CC_DEVICE_INFO));
            //if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
            //{
            //    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
            //    giga_Info = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

            //    no = Camera_Count;
            //    Camera_Count++;
            //    Camera[no].Device_Info = device;
            //    Camera[no].Defined_Name = giga_Info.chUserDefinedName;
            //    Camera[no].Serial_Number = giga_Info.chSerialNumber;
            //}
        }
        private static void Get_USB_Camera(IntPtr device_info)
        {
            //MyCamera.MV_CC_DEVICE_INFO device;
            //MyCamera.MV_USB3_DEVICE_INFO usb_Info;
            //int no = 0;

            //device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(device_info, typeof(MyCamera.MV_CC_DEVICE_INFO));
            //if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
            //{
            //    IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
            //    usb_Info = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));

            //    no = Camera_Count;
            //    Camera_Count++;
            //    Camera[no].Device_Info = device;
            //    Camera[no].Defined_Name = usb_Info.chUserDefinedName;
            //    Camera[no].Serial_Number = usb_Info.chSerialNumber;
            //}
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
                    Camera[i] = new TCamera_Flir_GigaE();
            }
        }
        public static void Find_All_Camera()
        {
            FC2Version version = ManagedUtilities.libraryVersion;
            ManagedBusManager busMgr = new ManagedBusManager();

            Version = string.Format("FlyCapture2 library version:{0:d}.{1:d}.{2:d}.{3:d}",
                                     version.major, version.minor, version.type, version.build);

            Camera_Count = (int)busMgr.GetNumOfCameras();
            for (uint i = 0; i < Camera_Count; i++)
            {
                Camera[i].GUID = busMgr.GetCameraFromIndex(i);
            }


            //csi_return = CameraOperator.EnumDevices(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref Device_List);
            //if (csi_return == 0)
            //{
            //    for (int i = 0; i < Device_List.nDeviceNum; i++)
            //    {
            //        Get_GigaE_Camera(Device_List.pDeviceInfo[i]);
            //        //Get_USB_Camera(DeviceList.pDeviceInfo[i]);
            //    }
            //}
        }
    }
    public class TCamera_Flir_GigaE : TCamera_Base
    {
        public ManagedPGRGuid GUID = null;
        private ManagedCamera Camera = new ManagedCamera();
        private CameraInfo Camera_Info = null;
        private EmbeddedImageInfo Embedded_Info = null;

        public double Frame_Rate
        {
            get
            {
                CameraProperty frame_rate;
                frame_rate = Camera.GetProperty(PropertyType.FrameRate);
                return frame_rate.absValue;
            }
        }
        public TCamera_Flir_GigaE()
        {
            FCamera_Type_Name = "TFlir_GigaE_Camera";
        }
        ~TCamera_Flir_GigaE()
        {
            Grab_Stop();
            Close();
        }
        private void Open()
        {
            ManagedCamera cam = new ManagedCamera();

            if (GUID != null)
            {
                Camera.Connect(GUID);
                Camera_Info = Camera.GetCameraInfo();
                Embedded_Info = Camera.GetEmbeddedImageInfo();
            }
        }
        private void Close()
        {
            if (Camera != null)
            {
                Grab_Stop();
                Camera.Disconnect();
            }
        }
        private emColor_Format Get_Color_Format(PixelFormat type)
        {
            emColor_Format result = emColor_Format.GRAY8;

            switch (type)
            {
                case PixelFormat.PixelFormatMono8: result = emColor_Format.GRAY8; break;
                case PixelFormat.PixelFormatRgb8: result = emColor_Format.RGB8; break;
                case PixelFormat.PixelFormatRaw8: result = emColor_Format.RGB8; break;
            }

            return result;
        }
        private void InSide_CallBack(ManagedImage back_image)
        {
            ManagedImage new_image = new ManagedImage();
            Timer_Grab_Timeout.Enabled = false;
            OnCallBack = true;

            lock (Image)
            {
                FImage_Width = (int)back_image.cols;
                FImage_Height = (int)back_image.rows;
                FColor_Format = Get_Color_Format(back_image.pixelFormat);
                back_image.Convert(PixelFormat.PixelFormatRgb8, new_image);

                unsafe
                {
                    Gen_Image((IntPtr)new_image.data, FColor_Format, FImage_Width, FImage_Height, ref Image);
                }

                Refalsh = true;
                if (CallBack != null) CallBack(this);
                if (Grab_Status == emCamera_Grab_Status.Grab_Image)
                {
                    Grab_Stop();
                };
                OnCallBack = false;
                Timer_Grab_Timeout.Enabled = false;
            }
        }
        override public void Camera_Init()
        {
            try
            {
                if (!FInit)
                {
                    Open();
                    //Grab_Image();
                    FInit = true;
                }
            }
            catch
            {

            }
        }
        override public void Grab_Image()
        {
            if (Camera != null && Grab_Status == emCamera_Grab_Status.Stop)
            {
                Camera.StartCapture(InSide_CallBack);
                Grab_Status = emCamera_Grab_Status.Grab_Image;
                Timer_Grab_Timeout.Enabled = true;
                while (Grab_Status == emCamera_Grab_Status.Grab_Image && !Grab_Timeout) { };
            }
        }
        override public void Grab_Life()
        {
            if (Camera != null)
            {
                Camera.StartCapture(InSide_CallBack);
                Grab_Status = emCamera_Grab_Status.Life;
            }
        }
        override public void Grab_Stop()
        {
            if (Camera != null)
            {
                Camera.StartCapture();
                Camera.StopCapture();
                Grab_Status = emCamera_Grab_Status.Stop;
            }
        }
        override public void Reconnect()
        {
            try
            {
                Log_Add("Camera=" + Name + " Camera Reconnect.");
                Camera_Init();
            }
            catch { };
        }
        override public bool Get_Connected()
        {
            return true;
        }

        private void Gen_Image(IntPtr data, emColor_Format color_format, int w, int h, ref HImage Image)
        {

        }
    }
}
