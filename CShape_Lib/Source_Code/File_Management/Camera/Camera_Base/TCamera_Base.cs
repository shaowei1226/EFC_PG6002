using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using EFC.Vision.Halcon;
using EFC.Tool;


namespace EFC.Camera
{
    public enum emColor_Format { RGB8, RGB15, RGB16, RGB24, RGB32, GRAY8, RAW8X, YUY24, Bayer_GR8, Bayer_GB8, Bayer_BG8, Bayer_RG8 };
    public enum emCamera_Grab_Status { Stop, Life, Grab_Image, Grab_Image_List};
    public delegate void JJS_Camera_CallBack(TCamera_Base sender);
    public delegate void evGrab_List_Back(TCamera_Base sender, object buffer_ptr, TImage_List list);

    public class TCamera_Base
    {
        public TLog                      Log = null;
        public TLog                      Log_Error = null;
        public emCamera_Grab_Status      Grab_Status = emCamera_Grab_Status.Stop;
        public bool                      Mirror_Col = false;
        public bool                      Mirror_Row = false;
        public string                    Name = "Default_CCD";
        public bool                      Refalsh = false;
        public JJS_Camera_CallBack       CallBack = null;
        public bool                      Used_Select_Image = false;
        public HImage                    Select_Image = new HImage();
        public HImage                    Image = new HImage();


        protected string                 FCamera_Type_Name = "";
        protected bool                   FInit = false;
        protected emColor_Format         FColor_Format = emColor_Format.GRAY8;
        protected int                    FImage_Width = 640;
        protected int                    FImage_Height = 480;
        protected int                    FPixel_Size = 1;
        protected bool                   OnCallBack = false;
        protected bool                   Grab_Timeout = false;
        protected System.Timers.Timer    Timer_Grab_Timeout = new System.Timers.Timer();
        protected double                 Grab_Timeout_Time = 2000;

                                    
        public emColor_Format Color_Format
        {
            get
            {
                return FColor_Format;
            }
        }
        public void Log_Add(string msg)
        {
            if (Log != null) Log.Add(string.Format("[Camera] Name={0:s}", Name) + msg);
        }
        public void Log_Error_Add(string msg)
        {
            if (Log_Error != null) Log_Error.Add(string.Format("[Camera] Name={0:s}", Name) + msg);
        }
        public bool OnStop
        {
            get
            {
                return (Grab_Status == emCamera_Grab_Status.Stop);
            }
        }
        public bool OnGrab
        {
            get
            {
                return (Grab_Status == emCamera_Grab_Status.Grab_Image);
            }
        }
        public bool OnLife
        {
            get
            {
                return (Grab_Status == emCamera_Grab_Status.Life);
            }
        }
        public bool On_Grab_Image_List
        {
            get
            {
                return (Grab_Status == emCamera_Grab_Status.Grab_Image_List);
            }
            set
            {
                if (value) Grab_Status = emCamera_Grab_Status.Grab_Image_List;
                else Grab_Status = emCamera_Grab_Status.Stop;
            }
        }
        public string Camera_Type_Name
        {
            get
            {
                return FCamera_Type_Name;
            }
        }
        public int Image_Width
        {
            get
            {
                int result = FImage_Width;
                int w, h;

                if (Used_Select_Image)
                {
                    Select_Image.GetImageSize(out w, out h);
                    result = w;
                }
                return result;
            }
        }
        public int Image_Height
        {
            get
            {
                int result = FImage_Height;
                int w, h;

                if (Used_Select_Image)
                {
                    Select_Image.GetImageSize(out w, out h);
                    result = h;
                }
                return result;
            }
        }
        public bool Init
        {
            get
            {
                return FInit;
            }
        }
        public bool Connected
        {
            get
            {
                return Get_Connected();
            }
        }



        public TCamera_Base()
        {
            Timer_Grab_Timeout.Enabled = false;
            Timer_Grab_Timeout.Interval = Grab_Timeout_Time;
            Timer_Grab_Timeout.Elapsed += On_Grab_Timeout;

            Image.GenImageConst("byte", FImage_Width, FImage_Height);
            Select_Image.GenImageConst("byte", FImage_Width, FImage_Height);
        }
        public bool Get_HImage(ref HImage in_image)
        {
            bool result = false;
            lock (Image)
            {
                if (Used_Select_Image)
                {
                    if (JJS_Vision.Is_Not_Empty(Select_Image)) in_image = Select_Image.Clone();
                }
                else
                {
                    if (!JJS_Vision.Is_Empty(Image) && in_image != null)
                    {
                        JJS_Vision.Copy_Obj(Image, ref in_image);
                        //if (Mirror_Row) in_image = in_image.MirrorImage("row");
                        //if (Mirror_Col) in_image = in_image.MirrorImage("column");
                        result = true;
                    }
                }
            }
            return result;
        }
        public HImage Get_HImage()
        {
            HImage result = new HImage();
            Get_HImage(ref result);
            return result;
        }
        public void Set_Camera_Size(HImage image)
        {
            int w, h;
            if (!JJS_Vision.Is_Empty(image))
            {
                image.GetImageSize(out w, out h);
                Set_Camera_Size(w, h);
            }
        }
        public void Set_Camera_Size(int w, int h)
        {
            FImage_Width = w;
            FImage_Height = h;
            Image.GenImageConst("byte", FImage_Width, FImage_Height);
        }
        public void On_Grab_Timeout(object sender, EventArgs e)
        {
            Log_Add("Camera=" + Name + " On_Grab_Timeout.");
            Timer_Grab_Timeout.Enabled = false;
            if (Grab_Status != emCamera_Grab_Status.Stop) Grab_Stop();
            Grab_Timeout = true;
        }
        public bool Grab_Image(ref HImage out_image)
        {
            bool result = false;

            Refalsh = false;
            if (!Used_Select_Image)
            {
                Set_Grab_Timeout();
                if (Grab_Status == emCamera_Grab_Status.Stop) Grab_One_Image();
                while (!Refalsh && !Grab_Timeout) { };
                Timer_Grab_Timeout.Enabled = false;
                if (Refalsh)
                {
                    JJS_Vision.Copy_Obj(Image, ref out_image);
                    result = true;
                }
            }
            else
            {
                Refalsh = true;
                JJS_Vision.Copy_Obj(Select_Image, ref out_image);
                result = true;
            }
            return result;
        }


        virtual public void Camera_Init()
        {
        }
        virtual public void Grab_One_Image()
        {
        }
        virtual public void Grab_Life()
        {
        }
        virtual public void Grab_Stop()
        {
        }
        virtual public void Dispose()
        {

        }
        virtual public bool Get_Connected()
        {
            return false;
        }



        public void Set_Grab_Timeout()
        {
            Set_Grab_Timeout(Grab_Timeout_Time);
        }
        public void Set_Grab_Timeout(double time_ms)
        {
            Reset_Grab_Timeout();
            Timer_Grab_Timeout.Interval = time_ms;
            Timer_Grab_Timeout.Enabled = true;
        }
        public void Reset_Grab_Timeout()
        {
            Grab_Timeout = false;
            Timer_Grab_Timeout.Enabled = false;
        }
    }


    public class TImage_List 
    {
        public object             Key = null;
        public evGrab_List_Back   Grab_Call_Back = null;
        public evGrab_List_Back   Grab_Finish_Call_Back = null;
        public ArrayList          Items = new ArrayList();
        public int                Grab_Count = 0;
        public bool               Grab_Finish_Flag = false;

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }
        public bool Grab_Finish
        {
            get
            {
                return Count == Grab_Count;
            }
        }
        public TImage_List()
        {

        }
        public void Copy(TImage_List sor, TImage_List dis)
        {
            dis.Grab_Count = sor.Grab_Count;
            dis.Key = sor.Key;
            dis.Grab_Call_Back = sor.Grab_Call_Back;
            dis.Grab_Finish_Call_Back = sor.Grab_Finish_Call_Back;
            dis.Grab_Count = sor.Grab_Count;
            dis.Items = (ArrayList)sor.Items.Clone();
        }
        public TImage_List Copy()
        {
            TImage_List result = new TImage_List();
            Copy(this, result);
            return result;
        }
        public void Set(TImage_List sor)
        {
            Copy(sor, this);
        }
        public void Reset()
        {
            Items.Clear();
            Grab_Count = 0;
            Key = "";
        }
        public void Add(HImage image)
        {
            Items.Add(image);
        }
        public HImage Last_Image()
        {
            HImage result = null;
            if (Items.Count > 0) result = (HImage)Items[Items.Count - 1];
            return result;
        }
    }
}
