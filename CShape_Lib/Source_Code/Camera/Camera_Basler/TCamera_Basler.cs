using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EFC.Camera;
using HalconDotNet;
using EFC.Tool;
using Basler.Pylon;


namespace EFC.Camera.BaslerEE
{
    public static class TBasler_Giga
    {
        public static TCamera_Basler_Giga[] Cameras = new TCamera_Basler_Giga[0];


        public static int Camera_Count
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
                    Cameras[i] = new TCamera_Basler_Giga();
            }
        }
        public static void Find_All_Camera()
        {
            List<ICameraInfo> list_cameras = CameraFinder.Enumerate();

            Camera_Count = list_cameras.Count;
            for (int i = 0; i < Camera_Count; i++)
            {
                Cameras[i].InCamera = new Basler.Pylon.Camera();
                Cameras[i].Camera_Init();
            }
        }
        public static void Dispose()
        {
            for (int i = 0; i < Camera_Count; i++) Cameras[i].Dispose();
        }
        public static TCamera_Basler_Giga Get_Camera_By_IP(string ip)
        {
            TCamera_Basler_Giga result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Cameras[i].IPAddress == ip)
                {
                    result = Cameras[i];
                    break;
                }
            }
            return result;
        }
        public static TCamera_Basler_Giga Get_Camera_By_UserDefinedName(string name)
        {
            TCamera_Basler_Giga result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Cameras[i].UserDefinedName == name)
                {
                    result = Cameras[i];
                    break;
                }
            }
            return result;
        }
        public static TCamera_Basler_Giga Get_Camera_By_SerialNumber(string serial_number)
        {
            TCamera_Basler_Giga result = null;

            for (int i = 0; i < Camera_Count; i++)
            {
                if (Cameras[i].SerialNumber == serial_number)
                {
                    result = Cameras[i];
                    break;
                }
            }
            return result;
        }
    }

    public class TCamera_Basler_Giga : TCamera_Base
    {
        //public bool                          Terminate;
        //private Thread                       Back_Thread = null;
        public Basler.Pylon.Camera           InCamera = null;

        public System.Timers.Timer           Timer_Reconnect = new System.Timers.Timer();
        public ArrayList                     Property_List = new ArrayList();
                                             

        //protected DeviceCallbackHandler m_callbackHandler = new DeviceCallbackHandler();
        //protected PYLON_DEVICECALLBACK_HANDLE m_hRemovalCallback = new PYLON_DEVICECALLBACK_HANDLE();

        public string IPAddress
        {
            get
            {
                return Get_Property("IpAddress");
            }
        }
        public string SerialNumber
        {
            get
            {
                return  Get_Property("SerialNumber");
            }
        }
        public string UserDefinedName
        {
            get
            {
                return Get_Property("UserDefinedName");
            }
        }
        public TCamera_Basler_Giga()
        {
            FCamera_Type_Name = "TBasler_Giga_Camera";
            //Terminate = false;
            //Back_Thread = new Thread(Execute);
            //Back_Thread.Start();

            Timer_Reconnect.Enabled = false;
            Timer_Reconnect.Interval = 3000;
            Timer_Reconnect.Elapsed += On_Reconnect;
        }
        public override void Dispose()
        {
            if (InCamera != null && InCamera.IsOpen) InCamera.Close();
            //Terminate = true;
        }
        ~TCamera_Basler_Giga()
        {
            //Terminate = true;
        }
        public void Execute()
        {
            //IGrabResult grabResult;

            //while (!Terminate)
            //{
            //    if (OnLife || OnGrab)
            //    {
            //        grabResult = InCamera.StreamGrabber.RetrieveResult(5000, TimeoutHandling.ThrowException);
            //        if (grabResult.GrabSucceeded)
            //        {
            //            FImage_Width = grabResult.Width;
            //            FImage_Height = grabResult.Height;
            //            lock (Image)
            //            {
            //                Image.GenImage1("byte", FImage_Width, FImage_Height, (System.IntPtr)grabResult.PixelData);
            //            }
            //            Refalsh = true;
            //            if (CallBack != null) CallBack(this);

            //            Timer_Reconnect.Enabled = false;
            //            if (OnLife) Timer_Reconnect.Enabled = true;
            //            if (OnGrab) Grab_Stop();
            //        }
            //        else
            //        {
            //            //
            //        }
            //    }
            //    System.Threading.Thread.Sleep(1);
            //}
        }
        public void On_Reconnect(object sender, EventArgs e)
        {
            Timer_Reconnect.Enabled = false;
            Camera_Init();
            Grab_Life();
        }
        public void Get_Property_List()
        {
            if(InCamera != null)
            {
                Property_List.Clear();
                Property_List.Add("SerialNumber" + "," + InCamera.CameraInfo[CameraInfoKey.SerialNumber]);
                Property_List.Add("IPAddress" + "," + InCamera.CameraInfo[CameraInfoKey.DeviceIpAddress]);
                Property_List.Add("UserDefinedName" + "," + InCamera.CameraInfo[CameraInfoKey.UserDefinedName]);
            }
        }
        public string Get_Property(string name)
        {
            string result = "";
            ArrayList list = new ArrayList();

            for (int i = 0; i < Property_List.Count; i++)
            {
                String_Tool.Break_String((string)Property_List[i], ",", ref list);
                if (list.Count >= 2 && (string)list[0] == name)
                {
                    result = (string)list[1];
                    break;
                }
            }
            return result;
        }
        public string Get_Parameters(string class_name, string name)
        {
            string result = "";

            switch (class_name)
            {
                case "PLCamera": result = Get_Parameters_PLCamera(name); break;
                default: result = "not find"; break;
            }
            return result;
        }
        public string Get_Parameters_PLCamera(string name)
        {
            string result = "";

            try
            {
                switch (name)
                {
                    case "PixelFormat": result = InCamera.Parameters[PLCamera.PixelFormat].GetValue().ToString(); break;
                    case "Width": result = InCamera.Parameters[PLCamera.Width].GetValue().ToString(); break;
                    case "Height": result = InCamera.Parameters[PLCamera.Height].GetValue().ToString(); break;
                    case "DeviceSerialNumber": result = InCamera.Parameters[PLCamera.DeviceSerialNumber].GetValue().ToString(); break;
                    case "GevCurrentIPAddress": result = InCamera.Parameters[PLCamera.GevCurrentIPAddress].GetValue().ToString(); break;
                    default: result = "not find"; break;
                }
            }
            catch(Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        public override void Camera_Init()
        {
            if (!InCamera.IsOpen) InCamera.Open();
            Get_Property_List();
            if (InCamera != null)
            {
                string format = Get_Parameters("PLCamera", "PixelFormat");
                switch (format)
                {
                    case "Mono8": FColor_Format = emColor_Format.GRAY8; break;
                }

                FImage_Width = Convert.ToInt32(Get_Parameters("PLCamera","Width"));
                FImage_Height = Convert.ToInt32(Get_Parameters("PLCamera", "Height"));
                InCamera.StreamGrabber.ImageGrabbed += OnImageBack;
                FInit = true;
            }

        }

        override public void Grab_Image()
        {
            Grab_Stop();
            try
            {
                // Starts the grabbing of one image.
                InCamera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.SingleFrame);
                InCamera.StreamGrabber.Start(1, GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception e)
            {
                ShowException(e);
            }
            Grab_Status = emCamera_Grab_Status.Grab_Image;
            while (OnGrab) { };
        }
        override public void Grab_Stop()
        {
            try
            {
                InCamera.StreamGrabber.Stop();
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
            Grab_Status = emCamera_Grab_Status.Stop;
            Timer_Reconnect.Enabled = false;
        }
        override public void Grab_Life()
        {
            try
            {
                // Start the grabbing of images until grabbing is stopped.
                InCamera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
                InCamera.StreamGrabber.Start(GrabStrategy.OneByOne, GrabLoop.ProvidedByStreamGrabber);
            }
            catch (Exception exception)
            {
                ShowException(exception);
            }
            Grab_Status = emCamera_Grab_Status.Life;
            Timer_Reconnect.Enabled = true;
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
            return InCamera.IsOpen;
        }


        private void ShowException(Exception e)
        {
            MessageBox.Show("Exception caught:\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void OnImageBack(Object sender, ImageGrabbedEventArgs e)
        {
            IGrabResult grabResult = e.GrabResult;

            if (grabResult.IsValid)
            {
                if (OnLife || OnGrab)
                {
                    if (grabResult.GrabSucceeded)
                    {
                        FImage_Width = grabResult.Width;
                        FImage_Height = grabResult.Height;
                        lock (Image)
                        {
                            Image.GenImage1("byte", FImage_Width, FImage_Height, JJS_LIB.ByteToIntPtr(grabResult.PixelData as byte[]));
                        }
                        Refalsh = true;
                        if (CallBack != null) CallBack(this);

                        Timer_Reconnect.Enabled = false;
                        if (OnLife) Timer_Reconnect.Enabled = true;
                        if (OnGrab) Grab_Stop();
                    }
                }
            }
        }

    }
}
