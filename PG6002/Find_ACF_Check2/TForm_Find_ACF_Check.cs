using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using EFC.Tool;
using EFC.INI;
using EFC.CAD;


namespace EFC.Vision.Halcon
{
    //public enum emDisp_Sor_Mode { Base, Avg, Std, Min, Max, Align, Source };
    //public enum emDisp_Sor2_Mode { Base, Avg, Std, Min, Max, Align, Source };

    public partial class TForm_Find_ACF_Check : Form
    {
        public TFind_ACF_Check_Param    Param = new TFind_ACF_Check_Param();
        public int                      Step = 0;
        public TFrame_JJS_HW            JJS_HW;
        private HImage                  Sample_Image = new HImage();
        public TFind_ACF_Check_Result   F_Result = new TFind_ACF_Check_Result();
        public stRegion_Info[]          Region_Info = new stRegion_Info[0];


        public HImage Show_Image
        {
            get
            {
                HImage result = null;

                if (RB_Sor_Base_Image.Checked) result = Param.Image_Base;
                if (RB_Sor_Sample_Image.Checked) result = Sample_Image;
                return result;
            }
        }
        public int Image_Width
        {
            get
            {
                int w = 640, h = 480;
                HImage image = Param.Image_Base;

                if (JJS_Vision.Is_Not_Empty(image))
                {
                    image.GetImageSize(out w, out h);
                }
                return w;
            }
        }
        public int Image_Height
        {
            get
            {
                int w = 640, h = 480;
                HImage image = Param.Image_Base;

                if (JJS_Vision.Is_Not_Empty(image))
                {
                    image.GetImageSize(out w, out h);
                }
                return h;
            }
        }
        public TForm_Find_ACF_Check()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            JJS_HW.Init();
        }
        public void Set_Param(TFind_ACF_Check_Param param, HImage image = null)
        {
            Param.Set(param);
            if (JJS_Vision.Is_Not_Empty(image))
            {
                Sample_Image = image.Clone();
            } 
            Set_Param();
        }
        public void Set_Param()
        {
            Form_Tool.Set_Button_Face(B_Sample_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.PaleTurquoise, Color.Transparent);
            Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Param.Image_Base), Color.PaleTurquoise, Color.Transparent);


            JJS_HW.SetPart(Show_Image);

            E_Min_Gray.Text = Param.Min_Gray.ToString("0");
            E_Max_Gray.Text = Param.Max_Gray.ToString("0");
        }
        public void Update_Param()
        {
            try
            {
                Param.Min_Gray = Convert.ToDouble(E_Min_Gray.Text);
                Param.Max_Gray = Convert.ToDouble(E_Max_Gray.Text);
            }
            catch { }
        }
        private void Form_Find_Mothed_1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Disp_Image(JJS_HW.HW_Buf, Show_Image);
            JJS_HW.Copy_HW();
            JJS_HW.HW_Param.Set_Line_Width(JJS_HW.HW.Width, Image_Width, 2);
            JJS_HW.Zoom_Windows_Fit();
        }
        public void Disp_Image(HWindowControl hw, HImage image, bool clear_flag = true)
        {
            if (clear_flag) hw.HalconWindow.ClearWindow();
            if (JJS_Vision.Is_Not_Empty(image))
            {
                JJS_HW.SetPart(image);
                hw.HalconWindow.DispObj(image);
            }
        }
        public void Disp_Region(HWindowControl hw, HRegion region)
        {
            if (JJS_Vision.Is_Not_Empty(region))
            {
                hw.HalconWindow.DispObj(region);
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Save_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();

            //dialog.Filter = "Param File|*.xml";
            //dialog.InitialDirectory = Param.Default_Path;
            //dialog.FileName = "default.xml";
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    Param.Write(dialog.FileName, "default");
            //}            
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            //dialog.Filter = "Param File|*.xml";
            //dialog.InitialDirectory = Param.Default_Path;
            //dialog.FileName = "default.xml";
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    Param.Write(dialog.FileName, "default");
            //}
        }
        private void B_Finish_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        public void Disp_Find_Result()
        {
            HWindowControl hw = JJS_HW.HW_Buf;
            double scale = (double)Image_Width / JJS_HW.HW.Width;

            F_Result.Disp_Param.Msg_X = 50;
            F_Result.Disp_Param.Msg_Y = 50;
            F_Result.Disp_Param.Msg_Font_Size = 30;
            F_Result.Disp_Param.Scale = scale;
            hw.HalconWindow.ClearWindow();
            F_Result.Display(hw);
            JJS_HW.Copy_HW();
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();
            double scale = 1;

            Update_Param();
            if (true)
            {
                scale = Get_Scale(Sample_Image, JJS_HW.Width);

                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                Disp_Image(JJS_HW.HW_Buf, Show_Image, true);


                #region Step1  
                if (Step >= 1 && flag)
                {
                    if (Step == 1)
                    {
                        Disp_Region(JJS_HW.HW_Buf, Param.Region_ROI);
                    }
                }
                #endregion

                #region Step2 
                if (Step >= 2 && flag)
                {
                    Param.Find(Show_Image, ref F_Result);
                    if (Step == 2)
                    {
                        //Disp_Find_Result();
                    }
                }
                #endregion

                #region Step3  
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        Disp_Find_Result();
                    }
                }
                #endregion

                JJS_HW.Copy_HW();
            }
        }
        public double Get_Scale(HImage in_image, int width)
        {
            double result = 1;
            int w = 0, h = 0;

            in_image.GetImageSize(out w, out h);
            result = (double)(w / width);
            if (result < 1) result = 1;
            return result;
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
        private void TP_Space_Enter(object sender, EventArgs e)
        {
            Step = 0;
            Update_View();
        }
        private void TP_Step1_Enter(object sender, EventArgs e)
        {
            Step = 1;
            Update_View();
        }
        private void TP_Step2_Enter(object sender, EventArgs e)
        {
            Step = 2;
            Update_View();
        }
        private void TP_Step3_Enter(object sender, EventArgs e)
        {
            Step = 3;
            Update_View();
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Disp_Image(JJS_HW.HW_Buf, Param.Image_Base, true);
            JJS_HW.Copy_HW();
        }
        private void B_Sample_Image_Click(object sender, EventArgs e)
        {
            Disp_Image(JJS_HW.HW_Buf, Sample_Image, true);
            JJS_HW.Copy_HW();
        }
        private void B_Select_Base_File_Click(object sender, EventArgs e)
        {
            HImage image = Param.Image_Base;
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.InitialDirectory = Param.Default_Path;
            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Base_Image_File_Name.Text = dialog.FileName;
                image.ReadImage(E_Base_Image_File_Name.Text);
                Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.PaleTurquoise, Color.Transparent);

                Disp_Image(JJS_HW.HW_Buf, image);
                JJS_HW.Copy_HW();
            }
        }
        private void B_Select_Sample_File_Click(object sender, EventArgs e)
        {
            HImage image = Sample_Image;
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.InitialDirectory = Param.Default_Path;
            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Sample_Image_File_Name.Text = dialog.FileName;
                image.ReadImage(E_Sample_Image_File_Name.Text);
                Form_Tool.Set_Button_Face(B_Sample_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.PaleTurquoise, Color.Transparent);

                Disp_Image(JJS_HW.HW_Buf, image);
                JJS_HW.Copy_HW();
            }
        }
        private void B_Edit_Region_Click(object sender, EventArgs e)
        {

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            bool test = true;
            if (test) 
            {
                HImage in_image = Sample_Image;
                JJS_Vision.Copy_Obj(in_image, ref Param.Image_Base);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////*/

            if (JJS_Vision.Edit_Region(Param.Image_Base, ref Param.Region_ROI))
            {
                Update_View();
            }
        }
        private void B_Save_To_Base_Click(object sender, EventArgs e)
        {
            HImage in_image = Sample_Image;

            if (MessageBox.Show("原始影像將被覆蓋,確定要儲存Base影像??", "儲存Base影像", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TEFC_Message.Show("儲存Base影像", "", 500);

                JJS_Vision.Copy_Obj(in_image, ref Param.Image_Base);
                Param.Write_Base_Image();
                TEFC_Message.End();

                Set_Param();
                Update_View();
            }
        }
        private void RB_Sor_Base_Image_CheckedChanged(object sender, EventArgs e)
        {
            Update_View();
        }
        private void RB_Sor_Sample_Image_CheckedChanged(object sender, EventArgs e)
        {
            Update_View();
        }
    }

    //------------------------------------------------------------------------------------------------------
    //- TFind_ACF_Check_Param
    //------------------------------------------------------------------------------------------------------
    public class TFind_ACF_Check_Param : TBase_Param
    {
        public HImage Image_Base = new HImage();
        public HRegion Region_ROI = new HRegion();
        public double Min_Gray = 0;
        public double Max_Gray = 120;

        public string Full_File_Name_Image_Base
        {
            get
            {
                string result = "";
                result = In_Default_Path + "Image_Base.jpg";
                return result;
            }
        }
        public string Full_File_Name_Region_ROI
        {
            get
            {
                string result = "";
                result = In_Default_Path + "Region_ROI.rgn";
                return result;
            }
        }
        public TFind_ACF_Check_Param()
        {
            Region_ROI = new HRegion();
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Class result = new TFind_ACF_Check_Param();
            return result;
        }
        override public TBase_Result New_Base_Result()
        {
            TBase_Result result = null;
            result = new TFind_ACF_Check_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_ACF_Check_Param && dis_base is TFind_ACF_Check_Param)
            {
                TFind_ACF_Check_Param sor = (TFind_ACF_Check_Param)sor_base;
                TFind_ACF_Check_Param dis = (TFind_ACF_Check_Param)dis_base;
                base.Copy(sor, dis);

                JJS_Vision.Copy_Obj(sor.Image_Base, ref dis.Image_Base);
                JJS_Vision.Copy_Obj(sor.Region_ROI, ref dis.Region_ROI);

                dis.Min_Gray = sor.Min_Gray;
                dis.Max_Gray = sor.Max_Gray;
                dis.Update();

            }
        }
        public void Dispose()
        {
            //if (Image_Base != null) Image_Base.Dispose();
            //if (Image_Avg  != null) Image_Avg.Dispose();
            //if (Image_Std  != null) Image_Std.Dispose();
                             
            //if (Image_Min  != null) Image_Min.Dispose();
            //if (Image_Max  != null) Image_Max.Dispose();
        }


        override public void Set_Default()
        {
            Image_Base = new HImage();
            Region_ROI = new HRegion();
            Min_Gray = 0;
            Max_Gray = 120;
        }
        override public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Min_Gray = ini.ReadFloat(section, "Min_Gray", Min_Gray);
                Max_Gray = ini.ReadFloat(section, "Max_Gray", Max_Gray);

                Read_Other_File();
                Update();
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Min_Gray", Min_Gray);
                ini.WriteFloat(section, "Max_Gray", Max_Gray);
                Write_Other_File();
                Update();
            }
        }
        override public void Read_Other_File()
        {
            JJS_Vision.Read_File(ref Region_ROI, Full_File_Name_Region_ROI);
            Read_Base_Image();
        }
        override public void Write_Other_File()
        {
            JJS_Vision.Write_File(Region_ROI, Full_File_Name_Region_ROI);
        }
        override public bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Find_ACF_Check form = new TForm_Find_ACF_Check();
            form.Set_Param(this, image);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        override public bool Find_Base(HImage image, ref TBase_Result f_result)
        {
            bool result = false;
            TFind_ACF_Check_Result in_result = (TFind_ACF_Check_Result)f_result;

            result = Find(image, ref in_result);
            return result;
        }
        public bool Find(HImage in_image, ref TFind_ACF_Check_Result f_result) 
        {
            bool result = false;

            f_result.Reset();
            f_result.Param_Ptr = this;
            JJS_Vision.Copy_Obj(in_image, ref f_result.Sample_Image);
            try
            {
                f_result.Mean_Gray = in_image.Intensity(Region_ROI, out f_result.Deviation);

                if (f_result.Mean_Gray > Min_Gray && f_result.Mean_Gray < Max_Gray)
                    f_result.Find_OK = true;
                else
                    f_result.Find_OK = false;

            }
            catch { };
            result = f_result.Find_OK;
            return result;
        }
        public void Log_Diff(TLog log, string section, TFind_ACF_Check_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Min_Gray", Min_Gray, new_value.Min_Gray, ref flag);
            log.Log_Diff(section + "/Max_Gray", Max_Gray, new_value.Max_Gray, ref flag);
        }
        public void Copy_Param(TFind_ACF_Check_Param in_param)
        {
            Min_Gray = in_param.Min_Gray;
            Max_Gray = in_param.Max_Gray;
        }


        public void Read_Base_Image()
        {
            JJS_Vision.Read_File(ref Image_Base, Full_File_Name_Image_Base);
        }
        public void Write_Base_Image()
        {
            JJS_Vision.Write_File(Image_Base, Full_File_Name_Image_Base);
        }
        public void Update()
        {
        }
    }

    //------------------------------------------------------------------------------------------------------
    //- TFind_ACF_Check_Result      Param & Disp_Param
    //------------------------------------------------------------------------------------------------------
    public class TFind_ACF_Check_Result : TBase_Result
    {
        public TFind_ACF_Check_Param Param_Ptr = null;
        public TFind_ACF_Check_Disp_Param Disp_Param = new TFind_ACF_Check_Disp_Param();
        public HImage Sample_Image = null;
        public double Mean_Gray = 0;
        public double Deviation = 0;
        public HImage Region_Defect = null;

        public TFind_ACF_Check_Result()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TFind_ACF_Check_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_ACF_Check_Result && dis_base is TFind_ACF_Check_Result)
            {
                base.Copy(sor_base, dis_base);
                TFind_ACF_Check_Result sor = (TFind_ACF_Check_Result)sor_base;
                TFind_ACF_Check_Result dis = (TFind_ACF_Check_Result)dis_base;

                dis.Param_Ptr = sor.Param_Ptr;
                dis.Mean_Gray = sor.Mean_Gray;
                dis.Deviation = sor.Deviation;
                JJS_Vision.Copy_Obj(sor.Region_Defect, ref dis.Region_Defect);
            }
        }
        override public void Set_Default()
        {
            Param_Ptr = null;
            Mean_Gray = 0;
            Deviation = 0;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
        }
        override public void Read_Other_File()
        {

        }
        override public void Write_Other_File()
        {

        }

        override public void Reset()
        {
            Find_OK = false;
            Region_Defect = null;
        }
        override public void Display_Message(HWindowControl hw)
        {
            string str = "";
            string color = "";
            int w = 0, h = 0;
            double col, row, font_size;

            if (JJS_Vision.Is_Not_Empty(Sample_Image))
            {
                hw.HalconWindow.DispObj(Sample_Image);
                
                Sample_Image.GetImageSize(out w, out h);
                if (Find_OK)
                {
                    str = "OK";
                    color = emSetColor.green;
                }
                else
                {
                    str = "NG";
                    color = emSetColor.red;
                }

                font_size = 100 * Disp_Param.Scale;
                col = w / 2 - font_size * 2;
                row = h / 2 - font_size;
                 
                JJS_Vision.Display_String(hw, str, col, row, font_size, 1, color);

                JJS_Vision.Display_String(hw, Get_Message(), Disp_Param.Msg_X, Disp_Param.Msg_Y, Disp_Param.Msg_Font_Size, Disp_Param.Scale, color);
            }
        }
        override public void Display_Model(HWindowControl hw)
        {
            double line_width = 1;

            //Disp_Image(hw);

            if (Disp_Param.Disp_ROI_Region)
            {
                line_width = 2 * Disp_Param.Scale + 5;
                hw.HalconWindow.SetLineWidth((int)line_width);
                hw.HalconWindow.SetColor(emSetColor.green);
                hw.HalconWindow.SetDraw(emSetDraw.margin);
                if (Param_Ptr != null && JJS_Vision.Is_Not_Empty(Param_Ptr.Region_ROI)) hw.HalconWindow.DispObj(Param_Ptr.Region_ROI);
            }
        }
        override public string Get_Message()
        {
            string result = "";

            result = string.Format("Mean_Gray={0:f1}, Deviation={1:f1} ", Mean_Gray, Deviation);
            return result;
        }
    }
    public class TFind_ACF_Check_Disp_Param : TBase_Disp_Param
    {
        public bool Disp_Defect = true;
        public bool Disp_ROI_Region = true;

        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_ACF_Check_Disp_Param && dis_base is TFind_ACF_Check_Disp_Param)
            {
                base.Copy(sor_base, dis_base);
                TFind_ACF_Check_Disp_Param sor = (TFind_ACF_Check_Disp_Param)sor_base;
                TFind_ACF_Check_Disp_Param dis = (TFind_ACF_Check_Disp_Param)dis_base;

                base.Copy(sor_base, dis_base);
                dis.Disp_Defect = sor.Disp_Defect;
                dis.Disp_ROI_Region = sor.Disp_ROI_Region;
            }
        }

    }
}
