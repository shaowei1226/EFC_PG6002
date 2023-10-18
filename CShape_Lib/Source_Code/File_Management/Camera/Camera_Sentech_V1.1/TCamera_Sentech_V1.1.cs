using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading;
using System.Runtime.InteropServices;
using EFC.Tool;
using EFC.Camera;
using EFC.Vision.Halcon;
using HalconDotNet;
using Sentech.GenApiDotNET;
using Sentech.StApiDotNET;


namespace EFC.Camera.Sentech
{
    public enum emNode_Type { Interface, Local_Device, Remote_Device, Data_Stream }
    public static class TSentech_Giga
    {

        static public TCamera_Sentech_Giga[] Camera = new TCamera_Sentech_Giga[0];
        static public CStApiAutoInit API = null;
        static public CStSystem System = null;

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
            CStDevice device = null;
            TCamera_Sentech_Giga camera = null;

            API = new CStApiAutoInit();
            System = new CStSystem();
            while (true)
            {
                try
                {
                    // Create a camera device object and connect to first detected device.
                    device = System.CreateFirstStDevice();
                    if (device != null)
                    {
                        Camera_Count++;
                        camera = Camera[Camera_Count - 1];
                        camera.Set_Device(device);
                        camera.Camera_Init();
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            }
        }
        public static CStDevice Get_Device(string device_id)
        {
            CStDevice result = null;
            CStDevice device = null;
            IStDeviceInfo new_device_info;

            while (true)
            {
                try
                {
                    device = System.CreateFirstStDevice();
                    if (device != null)
                    {
                        new_device_info = device.GetIStDeviceInfo();
                        if (new_device_info.ID == device_id)
                        {
                            result = device;
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            }
            return result;
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
        public static TCamera_Sentech_Giga Get_Camera_By_UserDefinedName(string name)
        {
            TCamera_Sentech_Giga result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Camera[i].UserDefinedName == name)
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
                if (Camera[i].SerialNumber == serial_number)
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
        private bool                   In_IsConnected = false;
        protected System.Timers.Timer  Timer_Reconnect = new System.Timers.Timer();
        private bool                   On_Loop = false;
        public CStDevice               Device = null;
        public IStDeviceInfo           Device_Info = null;
        public string                  Device_ID = "";
        public CStDataStream           Stream = null;

        public string IP
        {
            get
            {
                string result = "";

                if (Device != null)
                {
                    result = Get_Note_String(emNode_Type.Interface, "GevDeviceForceIPAddress");
                }
                return result;
            }
        }
        public string UserDefinedName
        {
            get
            {
                string result = "";

                if (Device != null)
                {
                    result = Device_Info.UserDefinedName;
                }
                return result;
            }
        }
        public string SerialNumber
        {
            get
            {
                string result = "";

                if (Device != null)
                {
                    result = Device_Info.SerialNumber;
                }
                return result;
            }
        }
        public TCamera_Sentech_Giga()
        {
            FCamera_Type_Name = "TSentech_Giga_Camera";
            //Terminate = false;
            //Back_Thread = new Thread(Execute);
            //Back_Thread.Start();

            Timer_Reconnect.Interval = 5000;
            Timer_Reconnect.Enabled = false;
            Timer_Reconnect.Elapsed += On_Reconnected;
        }
        public override void Dispose()
        {
            Stream.Dispose();
            Device.Dispose();
        }
        ~TCamera_Sentech_Giga()
        {
            //Terminate = true;
        }
        public void Set_Device(CStDevice device)
        {
            if (device != null)
            {
                Device = device;
                Device_Info = Device.GetIStDeviceInfo();
                Device_ID = Device_Info.ID;
            }
        }
        public void OnNodeCallback(INode node, object[] param)
        {
            if (node.IsAvailable)
            {
                IStDevice device = param[0] as IStDevice;

                // Node event will be triggered when it is invalidated. 
                // Check if DeviceLost occurred.
                if (device.IsDeviceLost)
                {
                    On_Disconnected();
                }
                else
                {
                    Log_Error_Add("OnNodeEvent:" + node.DisplayName + " : Invalidated");
                }
            }
        }
        private void OnCallback(IStCallbackParamBase paramBase, object[] param)
        {
            IStCallbackParamGenTLEventNewBuffer callbackParam = paramBase as IStCallbackParamGenTLEventNewBuffer;
            IStDataStream dataStream = callbackParam.GetIStDataStream();
            CStStreamBuffer streamBuffer = null;
            IStImage stImage = null;
            IntPtr image_data = new IntPtr();

            try
            {
                if (paramBase.CallbackType == eStCallbackType.TL_DataStreamNewBuffer)
                {
                    streamBuffer = dataStream.RetrieveBuffer(0);
                    {
                        if (streamBuffer.GetIStStreamBufferInfo().IsImagePresent)
                        {
                            stImage = streamBuffer.GetIStImage();
                            image_data = IntPtr_Tool.Byte_To_IntPtr(stImage.GetByteArray());
                            Inside_CallBack(image_data);
                        }
                    }
                    streamBuffer.Dispose();
                }
            }
            catch(Exception e)
            {
                Log_Error_Add(e.Message);
            }
        }
        private void Inside_CallBack(IntPtr buffer_p)
        {
            OnCallBack = true;

            Timer_Grab_Timeout.Enabled = false;
            switch (Grab_Status)
            {
                case emCamera_Grab_Status.Grab_Image:
                    Set_HImage(buffer_p);
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
            FInit = false;
            try
            {
                if (Device != null)
                {
                    Stream.Dispose();
                    Stream = null;
                    Device.Dispose();
                    Device = null;
                }
            }
            catch (Exception e)
            {
                Log_Error_Add("[Free]" + e.Message);
            }
        }
        override public void Camera_Init()
        {
            Log_Add("Camera_Init Start.");
            try
            {
                if (Device != null)
                {
                    Stream = Device.CreateStDataStream(0);
                    Stream.RegisterCallbackMethod(OnCallback);
                    Set_EventDeviceLost(OnNodeCallback);

                    FImage_Width = Get_Note_Integer(emNode_Type.Remote_Device, "Width");
                    FImage_Height = Get_Note_Integer(emNode_Type.Remote_Device, "Height");
                    Get_Color_Format();

                    Gen_Empty_Image();
                    Grab_Life();
                    FInit = true;
                }

            }
            catch (Exception e)
            {
                Log_Error_Add("[Camera_Init]" + e.Message);
            }

            //if (Pv_Device.IsConnected)
            //{
            //    Log_Add("Camera_Init OK.");
            //    In_IsConnected = true;
            //}
            //else
            //    Log_Add("Camera_Init NG.");
        }
        override public void Grab_Stop()
        {
            try
            {
                if (Device != null && Grab_Status != emCamera_Grab_Status.Stop)
                {
                    Grab_Status = emCamera_Grab_Status.Stop;
                    eDeviceAccessStatus status = Device_Info.AccessStatus;
                    Device.AcquisitionStop();
                    Stream.StopAcquisition();
                }
            }
            catch (Exception e)
            {
                Log_Add(e.Message);
            }
            ////Timer_Disconnect.Enabled = false;
        }
        override public void Grab_One_Image()
        {
            Set_Grab_Timeout();
            if (Device != null)
            {
                Stream.StartAcquisition(1);
                Device.AcquisitionStart();
            }
            Grab_Status = emCamera_Grab_Status.Grab_Image;
            while (!Refalsh && !Grab_Timeout) { };
            Timer_Grab_Timeout.Enabled = false;
            Grab_Stop();
        }
        override public void Grab_Life()
        {
            if (Device != null)
            {
                try
                {
                    Stream.StartAcquisition();
                    Device.AcquisitionStart();
                }
                catch (Exception e)
                {
                    Log_Error_Add(e.Message);
                }
            }
            Grab_Status = emCamera_Grab_Status.Life;
        }
        override public bool Get_Connected()
        {
            bool result = false;

            //result = In_IsConnected;
            ////if (Pv_Device != null && Pv_Pipeline != null) result = Pv_Device.IsConnected;
            return result;
        }

  
        private void Set_EventDeviceLost(NodeEventHandler handler)
        {
            INode nodeCallback = null;
            INodeMap nodeMapLocal;

            object[] param = { Device };
            nodeMapLocal = Device.GetLocalIStPort().GetINodeMap();
            nodeCallback = nodeMapLocal.GetNode<INode>("EventDeviceLost");
            nodeCallback.RegisterCallbackMethod(OnNodeCallback, param, eCallbackType.PostOutsideLock);
            Device.StartEventAcquisitionThread();
        }
        private void On_Disconnected()
        {
            Log_Error_Add("[On_Disconnected].");
            Gen_Empty_Image();
            In_IsConnected = false;
            FInit = false;
            Grab_Status = emCamera_Grab_Status.Stop;
            Timer_Reconnect.Enabled = true;
        }
        private void On_Reconnected(object sender, EventArgs e)
        {
            Timer_Reconnect.Enabled = false;
            Log_Error_Add("[On_Reconnected].");
            Free();

            CStDevice device = TSentech_Giga.Get_Device(Device_ID);
            if (device != null)
            {
                Set_Device(device);
                Camera_Init();
                Grab_Life();
            }

            if (FInit)
            {
                Log_Error_Add("[On_Reconnected] OK.");
            }
            else
            {
                Log_Error_Add(Name + "[On_Reconnected] NG.");
                Timer_Reconnect.Enabled = true;
            }
        }
        private void Set_HImage(IntPtr buffer_p)
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
                JJS_Vision.Copy_Obj(tmp_image, ref Image);
                Refalsh = true;
            }
            tmp_image.Dispose();
        }
        private void Gen_Empty_Image()
        {
            Image.GenImageConst("byte", FImage_Width, FImage_Height);
        }
        private void Get_Color_Format()
        {
            string pixel_format = Get_Note_EnumNode(emNode_Type.Remote_Device, "PixelFormat");

            switch (pixel_format)
            {
                case "Mono8": FColor_Format = emColor_Format.GRAY8; break;
                case "BayerGR8": FColor_Format = emColor_Format.Bayer_GR8; break;
                case "BayerGB8": FColor_Format = emColor_Format.Bayer_GB8; break;
                case "BayerBG8": FColor_Format = emColor_Format.Bayer_BG8; break;
                case "BayerRG8": FColor_Format = emColor_Format.Bayer_RG8; break;
            }            
        }
        private int Get_Note_Integer(emNode_Type node_type, string note_name)
        {
            int result = 0;

            switch (node_type)
            {
                case emNode_Type.Interface: 
                    result = Get_Interface_Note_Integer(note_name);
                    break;

                case emNode_Type.Remote_Device: 
                    result = Get_Remote_Device_Note_Integer(note_name);
                    break;
            }
            return result;
        }
        private string Get_Note_String(emNode_Type node_type, string note_name)
        {
            string result = "";

            switch (node_type)
            {
                case emNode_Type.Interface: result = Get_Interface_Note_String(note_name); break;
                case emNode_Type.Remote_Device: result = Get_Remote_Device_Note_String(note_name); break;
            }
            return result;
        }
        private EnumNode Get_Note_EnumNode(emNode_Type node_type, string note_name)
        {
            EnumNode result = null;

            switch (node_type)
            {
                case emNode_Type.Interface: result = Get_Interface_Note_EnumNode(note_name); break;
                case emNode_Type.Remote_Device: result = Get_Remote_Device_Note_EnumNode(note_name); break;
            }
            return result;
        }
        private int Get_Nore()
        {
            int result = 0;

            IInteger note = Device.GetRemoteIStPort().GetINodeMap().GetNode<IInteger>("Width");
            result = (int)note.Value;
            return result;
        }

        private int Get_Interface_Note_Integer(string note_name)
        {
            int result = 0;
            IStPort port = null;

            if (Device != null)
            {
                port = Device.GetIStInterface().GetIStPort();
                result = Get_Note_Integer(port, note_name);
            }
            return result;
        }
        private string Get_Interface_Note_String(string note_name)
        {
            string result = "";
            IStPort port = null;

            if (Device != null)
            {
                port = Device.GetIStInterface().GetIStPort();
                result = Get_Note_String(port, note_name);
            }
            return result;
        }
        private EnumNode Get_Interface_Note_EnumNode(string note_name)
        {
            EnumNode result = null;
            IStPort port = null;

            if (Device != null)
            {
                port = Device.GetIStInterface().GetIStPort();
                result = Get_Note_EnumNode(port, note_name);
            }
            return result;
        }

        private int Get_Remote_Device_Note_Integer(string note_name)
        {
            int result = 0;
            IStPort port = null;

            if (Device != null)
            {
                port = Device.GetRemoteIStPort();
                result = Get_Note_Integer(port, note_name);
            }
            return result;
        }
        private string Get_Remote_Device_Note_String(string note_name)
        {
            string result = "";
            IStPort port = null;

            if (Device != null)
            {
                port = Device.GetRemoteIStPort();
                result = Get_Note_String(port, note_name);
            }
            return result;
        }
        private EnumNode Get_Remote_Device_Note_EnumNode(string note_name)
        {
            EnumNode result = null;
            IStPort port = null;

            if (Device != null)
            {
                port = Device.GetRemoteIStPort();
                result = Get_Note_EnumNode(port, note_name);
            }
            return result;
        }

        private int Get_Note_Integer(IStPort port, string note_name)
        {
            int result = 0;
            IInteger node = null;

            if (port != null)
            {
                node = port.GetINodeMap().GetNode<IInteger>(note_name);
                if (node != null) result = (int)node.Value;
            }
            return result;
        }
        private string Get_Note_String(IStPort port, string note_name)
        {
            string result = "";
            IInteger node = null;

            if (port != null)
            {
                node = port.GetINodeMap().GetNode<IInteger>(note_name);
                if (node != null) result = node.ToString();
            }
            return result;
        }
        private EnumNode Get_Note_EnumNode(IStPort port, string note_name)
        {
            EnumNode result = null;

            if (port != null)
            {
                result = port.GetINodeMap().GetNode<EnumNode>(note_name);
            }
            return result;
        }
    }
}
