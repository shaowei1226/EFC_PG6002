using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvCamCtrl.NET;
using System.Runtime.InteropServices;
using EFC.Camera;
using HIK_Sor;

namespace EFC.Camera.HIK
{
    public static class THIK_GigaE
    {
        public static MyCamera.MV_CC_DEVICE_INFO_LIST Device_List = new MyCamera.MV_CC_DEVICE_INFO_LIST();
        public static TCamera_HIK_GigaE[] Camera = new TCamera_HIK_GigaE[0];


        private static void Get_GigaE_Camera(IntPtr device_info)
        {
            MyCamera.MV_CC_DEVICE_INFO device;
            MyCamera.MV_GIGE_DEVICE_INFO giga_Info;
            int no = 0;

            device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(device_info, typeof(MyCamera.MV_CC_DEVICE_INFO));
            if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
            {
                IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stGigEInfo, 0);
                giga_Info = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                no = Camera_Count;
                Camera_Count++;
                Camera[no].Device_Info = device;
                Camera[no].IP = giga_Info.nCurrentIp.ToString();
                Camera[no].Defined_Name = giga_Info.chUserDefinedName;
                Camera[no].Serial_Number = giga_Info.chSerialNumber;
            }
        }
        private static void Get_USB_Camera(IntPtr device_info)
        {
            MyCamera.MV_CC_DEVICE_INFO device;
            MyCamera.MV_USB3_DEVICE_INFO usb_Info;
            int no = 0;

            device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(device_info, typeof(MyCamera.MV_CC_DEVICE_INFO));
            if (device.nTLayerType == MyCamera.MV_USB_DEVICE)
            {
                IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(device.SpecialInfo.stUsb3VInfo, 0);
                usb_Info = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));

                no = Camera_Count;
                Camera_Count++;
                Camera[no].Device_Info = device;
                Camera[no].Defined_Name = usb_Info.chUserDefinedName;
                Camera[no].Serial_Number = usb_Info.chSerialNumber;
            }
        }

        //public static int Card_Count
        //{
        //    get
        //    {
        //        return Pv_Card.Length;
        //    }
        //    set
        //    {
        //        int old_count;
        //        old_count = Pv_Card.Length;
        //        Array.Resize(ref Pv_Card, value);
        //    }
        //}
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
                    Camera[i] = new TCamera_HIK_GigaE();
            }
        }
        public static void Find_All_Camera()
        {
            int csi_return;

            csi_return = CameraOperator.EnumDevices(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref Device_List);
            if (csi_return == 0)
            {
                for (int i = 0; i < Device_List.nDeviceNum; i++)
                {
                    Get_GigaE_Camera(Device_List.pDeviceInfo[i]);
                    //Get_USB_Camera(DeviceList.pDeviceInfo[i]);
                }
            }
        }
        public static TCamera_HIK_GigaE Get_Camera_By_IP(string ip)
        {
            TCamera_HIK_GigaE result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Camera[i].IP == ip)
                {
                    result = Camera[i];
                    break;
                }
            }
            return result;
        }
        public static TCamera_HIK_GigaE Get_Camera_By_UserDefinedName(string name)
        {
            TCamera_HIK_GigaE result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Camera[i].Defined_Name == name)
                {
                    result = Camera[i];
                    break;
                }
            }
            return result;
        }
        public static TCamera_HIK_GigaE Get_Camera_By_SerialNumber(string serial_number)
        {
            TCamera_HIK_GigaE result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Camera[i].Serial_Number == serial_number)
                {
                    result = Camera[i];
                    break;
                }
            }
            return result;
        }
    }

    public class TCamera_HIK_GigaE : TCamera_Base
    {
        public MyCamera.MV_CC_DEVICE_INFO Device_Info = new MyCamera.MV_CC_DEVICE_INFO();
        private MyCamera CSI_Handle = new MyCamera();
        public string IP;
        public string Defined_Name;
        public string Serial_Number;
        public MyCamera.cbOutputdelegate Callback;

        public TCamera_HIK_GigaE()
        {
            FCamera_Type_Name = "THIK_GigaE_Camera";
        }
        ~TCamera_HIK_GigaE()
        {
            Grab_Stop();
        }
        private int Open()
        {
            int result = CameraOperator.CO_OK;
            int csi_return;

            csi_return = CSI_Handle.MV_CC_CreateDevice_NET(ref Device_Info);
            if (csi_return != MyCamera.MV_OK) result = CameraOperator.CO_FAIL;

            csi_return = CSI_Handle.MV_CC_OpenDevice_NET();
            if (csi_return != MyCamera.MV_OK) result = CameraOperator.CO_FAIL;
            return result;
        }
        private int Close()
        {
            int result = CameraOperator.CO_OK;
            int csi_return;

            csi_return = CSI_Handle.MV_CC_CloseDevice_NET();
            if (csi_return != MyCamera.MV_OK) result = CameraOperator.CO_FAIL;

            csi_return = CSI_Handle.MV_CC_DestroyDevice_NET();
            if (csi_return != MyCamera.MV_OK) result = CameraOperator.CO_FAIL;
            return result;
        }
        private void InSide_CallBack(IntPtr pData, ref MyCamera.MV_FRAME_OUT_INFO pFrameInfo, IntPtr pUser)
        {
            OnCallBack = true;
            if (!FLock)
            {
                FLock = true;
                FImage_Width = pFrameInfo.nWidth;
                FImage_Height = pFrameInfo.nHeight;
                unsafe
                {
                    Image.GenImage1("byte", FImage_Width, FImage_Height, pData);
                }
                Refalsh = true;
                if (CallBack != null) CallBack(this);
                Grab_Status = emCamera_Grab_Status.Stop;
                FLock = false;
                OnCallBack = false;
                Timer.Enabled = false;
            }
            else
                Lost_Count++;
        }
        public override void Camera_Init()
        {
            int csi_return;

            try
            {
                Open();
                Callback = new MyCamera.cbOutputdelegate(InSide_CallBack);
                csi_return = CSI_Handle.MV_CC_RegisterImageCallBack_NET(Callback, IntPtr.Zero);
                //Grab_Image();
                FInit = true;
            }
            catch
            {

            }
        }
        public override void Grab_Image()
        {
            CSI_Handle.MV_CC_SetEnumValue_NET("TriggerMode", 1);
            CSI_Handle.MV_CC_SetEnumValue_NET("TriggerSource", 7);
            CSI_Handle.MV_CC_StartGrabbing_NET();
            CSI_Handle.MV_CC_SetCommandValue_NET("TriggerSoftware");
            Grab_Status = emCamera_Grab_Status.Grab_Image;
            Timer.Enabled = true;
            while (Grab_Status == emCamera_Grab_Status.Grab_Image && !Grab_Timeout) { };
        }
        public override void Grab_Life()
        {
            CSI_Handle.MV_CC_SetEnumValue_NET("TriggerMode", 0);
            CSI_Handle.MV_CC_StartGrabbing_NET();
            Grab_Status = emCamera_Grab_Status.Life;
        }
        public override void Grab_Stop()
        {
            CSI_Handle.MV_CC_StopGrabbing_NET();
            Grab_Status = emCamera_Grab_Status.Stop;
        }
    }
}
