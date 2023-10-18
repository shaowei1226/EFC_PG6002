using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using EFC.Vision.Halcon;
using EFC.Tool;
using EFC.CAD;
using EFC.INI;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Align_Mothed4 : Form
    {
        public string Default_Path;
        public HImage Image1 = new HImage();
        public HImage Image2 = new HImage();
        public TAlign_Mothed_4_Param Param = new TAlign_Mothed_4_Param();
        public TAlign_Mothed_4_Result Result = new TAlign_Mothed_4_Result();
        public TFrame_JJS_HW JJS_HW;
        public int Step = 0;
        public double Disp_Scale = 1.0;

        
        public TForm_Align_Mothed4()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        private void TForm_Align_Mothed4_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (!JJS_Vision.Is_Empty(Param.Base_Image))
            {
                Image1 = Param.Base_Image.Clone();
                B_Base_Image.BackColor = Color.LightGreen;
            }
            if (!JJS_Vision.Is_Empty(Image2)) B_Trans_Image.BackColor = Color.LightGreen;
          
            if (!JJS_Vision.Is_Empty(Image1)) Param.Base_Image = Image1.Clone();
            Draw_Image(Image1);
        }
        public void Set_Param(TAlign_Mothed_4_Param param)
        {
            Param.Set(param);

            CB_Align_Angle.Checked = Param.Align_Angle;
            E_Find_Ofs.Text = Param.Find_Ofs.ToString();
            tFrame_Create_Param1.Set_Param(Param.Create_Param);
            tFrame_Find_Param1.Set_Param(Param.Find_Param);
        }
        public void Update_Param()
        {
            Param.Align_Angle = CB_Align_Angle.Checked;
            Param.Find_Ofs = Convert.ToInt32(E_Find_Ofs.Text);
            tFrame_Create_Param1.Get_Param(ref Param.Create_Param);
            tFrame_Find_Param1.Get_Param(ref Param.Find_Param);
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
        }
        public void Draw_Image(HImage image)
        {
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            try
            {
                if (image != null)
                {
                    JJS_HW.SetPart(image);
                    JJS_HW.HW_Buf.HalconWindow.DispObj(image);
                }
            }
            catch
            {

            }
            JJS_HW.Copy_HW();
        }
        public void Draw_Region()
        {
            HImage image = null;
            HWindowControl hw;

            image = Image1;
            hw = JJS_HW.HW_Buf;
            if (image != null)
            {
                JJS_HW.SetPart(image);
                hw.HalconWindow.ClearWindow();
                hw.HalconWindow.DispObj(image);
                hw.HalconWindow.SetColored(12);
                hw.HalconWindow.SetLineWidth((int)Disp_Scale);
                hw.HalconWindow.SetDraw("margin");
                hw.HalconWindow.SetColor("red");
                Param.Create_Region.Region.DispObj(hw.HalconWindow);

                hw.HalconWindow.SetColor("green");
                Param.Find_Region.Region.DispObj(hw.HalconWindow);
                JJS_HW.Copy_HW();
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HImage image1 = new HImage();
            HImage image2 = new HImage();
            HImage image = new HImage();
            HRegion region = new HRegion();
            TFind_Mothed_1_Result find1_result = new TFind_Mothed_1_Result();

            Update_Param();
            if (true) 
            {
                Disp_Scale = JJS_Vision.Get_Scale(Image1);
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth((int)Disp_Scale);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                if (JJS_Vision.Is_Empty(Image1))
                    flag = false;

                //if (TJJS_Vision.Is_Empty(Image2))
                //    flag = false;

                #region Step1 display image
                if (Step >= 1 && flag)
                {
                    image1 = Image1.Clone();
                    if (!JJS_Vision.Is_Empty(Image2)) image2 = Image1.Clone();
                    image1.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                }
                #endregion

                #region Step3 select Circle
                if (Step >= 3 && flag)
                {
                    //if (RB_Source1_Golden.Checked && !TJJS_Vision.Is_Empty(Image1)) image = Image1.Clone();
                    //else if (RB_Source1_Sample.Checked && !TJJS_Vision.Is_Empty(Image2)) image = Image2.Clone();
                    //if (!TJJS_Vision.Is_Empty(image))
                    //{
                    //    region = image.Threshold((double)Param.Threshold_Min, (double)Param.Threshold_Max);
                    //    if (region.CountObj() > 0)
                    //    {
                    //        JJS_HW.HW_Buf.HalconWindow.SetLineWidth(3);
                    //        JJS_HW.HW_Buf.HalconWindow.SetDraw("fill");
                    //        JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                    //        image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    //        region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    //    }
                    //    else flag = false;
                    //}
                    //else flag = false;
                }
                #endregion

                #region Step4 select Circle
                if (Step >= 4 && flag)
                {
                    //region = region.Connection();
                    //region = region.SelectShape("area", "and", 300, 9999999999);
                    //if (region.CountObj() > 0)
                    //{
                    //    region.SmallestCircle(out row, out col, out radius);
                    //    JJS_HW.HW_Buf.HalconWindow.SetLineWidth(5);
                    //    JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                    //    JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                    //    image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    //    JJS_HW.HW_Buf.HalconWindow.DispCircle(row, col, radius);
                    //}
                    //else flag = false;
                }
                #endregion

                #region Step5 select Circle
                if (Step >= 5 && flag)
                {
                    //TFind_Mothed_1.Find(image, Param.Param, ref find1_result);
                    //TFind_Mothed_1.Disp_Result(JJS_HW.HW_Buf, find1_result);
                }
                #endregion

                #region Step6 Display result image
                if (Step >= 6 && flag)
                {
                    //TAlign_Mothed_3.Trans(Image1, Image2, Param, ref Result);
                    //Draw_Image(Result.Image);
                }
                #endregion
                JJS_HW.Copy_HW();
            }
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void B_Trans_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Select_Base_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Base_Image_File.Text = dialog.FileName;
                Image1.ReadImage(E_Base_Image_File.Text);
                B_Base_Image.BackColor = Color.LightGreen;
               
                Param.Base_Image = Image1.Clone();
                Param.Update();
  
                Draw_Image(Image1);
            }
        }
        private void B_Select_Trans_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Trans_Image_File.Text = dialog.FileName;
                Image2.ReadImage(E_Trans_Image_File.Text);
                B_Trans_Image.BackColor = Color.LightGreen;
                Draw_Image(Image2);
            }
        }
        private void B_Base_Image2_Click(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void B_Sample_Image2_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Result_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Result.Image);
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
        private void TP_Step0_Enter(object sender, EventArgs e)
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
        private void TP_Step4_Enter(object sender, EventArgs e)
        {
            Step = 4;
            Update_View();
        }
        private void TP_Step5_Enter(object sender, EventArgs e)
        {
            Step = 5;
            Update_View();
        }
        private void TP_Step6_Enter(object sender, EventArgs e)
        {
            Step = 6;
            Update_View();
        }
        private void B_Create_Region_Edit_Click(object sender, EventArgs e)
        {
            Update_Param();

            TForm_Select_Area form = new TForm_Select_Area();
            form.Image = Image1.Clone();
            form.Select_Region = Param.Create_Region.Region.CopyObj(1, -1);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Create_Region.Region = form.Select_Region.Clone();
                Param.Update();
                Draw_Region();
            }
        }
        private void B_Create_Region_Disp_Click(object sender, EventArgs e)
        {
            Update_Param();
            Draw_Region();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Update_Param();
            Update_View();
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            HWindowControl hw;
            TFind_Mothed_1_Result find_result = new TFind_Mothed_1_Result();

            Update_Param();
            Param.Update();
            hw = tFrame_JJS_HW1.HW_Buf;
            find_result = Param.Find_Result;
            hw.HalconWindow.SetLineWidth((int)Disp_Scale);
            hw.HalconWindow.ClearWindow();
            hw.HalconWindow.DispImage(Param.Base_Image);
            find_result.Display(hw);
            tFrame_JJS_HW1.Copy_HW();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HWindowControl hw;
            TFind_Mothed_1_Result find_result = new TFind_Mothed_1_Result();

            Update_Param();
            hw = tFrame_JJS_HW1.HW_Buf;

            Param.Find(Image2, ref find_result);
            hw.HalconWindow.ClearWindow();
            hw.HalconWindow.DispImage(Image2);
            find_result.Display(hw);
            tFrame_JJS_HW1.Copy_HW();
        }
        private void B_Base_Image2_Click_1(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void B_Sample_Image2_Click_1(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Result_Image_Click_1(object sender, EventArgs e)
        {
            if (Param.Trans(Image2, ref Result))
            {
                Draw_Image(Result.Image);
            }
        }

    }
    public class TAlign_Mothed_4_Param : TBase_Param
    {
        public bool                     Align_Angle = false;
        public int                      Find_Ofs;
        public TCreate_Param            Create_Param = new TCreate_Param();
        public TFind_Param              Find_Param = new TFind_Param();
        public TJJS_Region              Create_Region = new TJJS_Region();

        public bool                     Param_Data_OK = false;        
        public TJJS_Region              Find_Region = new TJJS_Region();
        public HImage                   Base_Image = null;
        public TJJS_ShapeModel          Model = new TJJS_ShapeModel();
        public TFind_Mothed_1_Result    Find_Result = new TFind_Mothed_1_Result();

        public TAlign_Mothed_4_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Mothed_4_Param();
        }
        override public TBase_Result New_Base_Result()
        {
            return new TAlign_Mothed_4_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Mothed_4_Param && dis_base is TAlign_Mothed_4_Param)
            {
                TAlign_Mothed_4_Param sor = (TAlign_Mothed_4_Param)sor_base;
                TAlign_Mothed_4_Param dis = (TAlign_Mothed_4_Param)dis_base;
                base.Copy(sor, dis);

                dis.Align_Angle = sor.Align_Angle;
                dis.Find_Ofs = sor.Find_Ofs;
                dis.Create_Param.Set(sor.Create_Param);
                dis.Find_Param.Set(sor.Find_Param);
                dis.Create_Region.Set(sor.Create_Region);

                dis.Param_Data_OK = sor.Param_Data_OK;
                dis.Find_Region.Set(sor.Find_Region);
                dis.Base_Image = sor.Base_Image;
                dis.Model.Set(sor.Model);
                sor.Find_Result.Copy(dis.Find_Result);
            }
        }

        public override void Set_Default()
        {
            base.Set_Default();
            Align_Angle = false;
            Find_Ofs = 20;
            Create_Param.Set_Default();
            Find_Param.Set_Default();
            Create_Region.Set_Default();


            Param_Data_OK = false;
            Find_Region.Set_Default();
            Base_Image = null;
            Model.Set_Default();
            Find_Result.Set_Default();
        }
        public override void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                base.Read(ini, section);
                Align_Angle = ini.ReadBool(section, "Align_Angle", false);
                Find_Ofs = ini.ReadInteger(section, "Find_Ofs", 20);

                Create_Param.Read(ini, section + "/Create_Param");
                Find_Param.Read(ini, section + "/Find_Param");
            }
        }
        public override void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                base.Write(ini, section);
                ini.WriteBool(section, "Align_Angle", Align_Angle);
                ini.WriteInteger(section, "Find_Ofs", Find_Ofs);

                Create_Param.Write(ini, section + "/Create_Param");
                Find_Param.Write(ini, section + "/Find_Param");
            }
        }
        public override void Read_Other_File()
        {
            Create_Region.Read(Create_Region.Default_Path + Create_Region.Default_FileName);
            Find_Region.Read(Find_Region.Default_Path + Find_Region.Default_FileName);
        }
        public override void Write_Other_File()
        {
            Create_Region.Write(Create_Region.Default_Path + Create_Region.Default_FileName);
            Find_Region.Write(Find_Region.Default_Path + Find_Region.Default_FileName);
        }
        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Align_Mothed4 form = new TForm_Align_Mothed4();
            if (!JJS_Vision.Is_Empty(image)) form.Image2 = image.Clone();
            form.Default_Path = Default_Path;
            form.Set_Param(this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        public override bool Find_Base(HImage image, ref TBase_Result f_result)
        {
            return Trans(image, ref f_result);
        }
        public bool Find_Base(HImage image, ref TAlign_Mothed_4_Result f_result)
        {
            return Trans(image, ref f_result);
        }


        public bool Trans(HImage image, ref TBase_Result f_result)
        {
            bool result = false;
            if (f_result is TAlign_Mothed_4_Result)
            {
                TAlign_Mothed_4_Result in_result = (TAlign_Mothed_4_Result)f_result;
                result = Trans(image, ref in_result);
            }
            return result;
        }
        public bool Trans(HImage image, ref TAlign_Mothed_4_Result result_p)
        {
            bool result = false;
            TFind_Mothed_1_Result base_find = new TFind_Mothed_1_Result();
            TFind_Mothed_1_Result sample_find = new TFind_Mothed_1_Result();

            result_p.Reset();
            if (!JJS_Vision.Is_Empty(image)) result_p.Image = image.Clone();
            {
                Find_Result.Copy(base_find);
                Find(image, ref sample_find);
                if (base_find.Find_OK && sample_find.Find_OK)
                {
                    result_p.Image = JJS_Vision.Affine_Trans_Image(image, sample_find.Col, sample_find.Row, sample_find.Angle, base_find.Col, base_find.Row, base_find.Angle);
                    result_p.D_Angle = sample_find.Angle - base_find.Angle;
                    result_p.D_Col = sample_find.Col - base_find.Col;
                    result_p.D_Row = sample_find.Row - base_find.Row;
                    result_p.Find_OK = true;
                }
            }
            result = result_p.Find_OK;
            return result;
        }
        public bool Create_Shape_Model(HImage image, TCreate_Param param, ref TJJS_ShapeModel model)
        {
            bool result = false;
            HImage tmp_image = new HImage();

            if (!JJS_Vision.Is_Empty(image))
            {
                try
                {
                    tmp_image = image.ReduceDomain(Create_Region.Region);
                    model.Model = tmp_image.CreateScaledShapeModel(
                                                     param.NumLevels,
                                                     param.AngleStart,
                                                     param.AngleExtent,
                                                     param.AngleStep,
                                                     param.ScaleMin,
                                                     param.ScaleMax,
                                                     param.ScaleStep,
                                                     param.Optimization,
                                                     param.Metric,
                                                     param.Contrast,
                                                     param.MinContrast);
                    model.XLD = model.Model.GetShapeModelContours(1);
                    result = true;
                }
                catch { }
            }
            return result;
        }
        public bool Find(HImage image, ref TFind_Mothed_1_Result find_result)
        {
            HImage tmp_image = new HImage();
            HTuple row, col, angle, scale, score;

            find_result.Reset();
            if (image != null)
            {
                HSystem.SetSystem("border_shape_models", "true");
                if (!JJS_Vision.Is_Empty(Model.Model))
                {
                    //tmp_image = image.ReduceDomain(Find_Region.Region);
                    image.FindScaledShapeModel(
                                               Model.Model,
                                               Find_Param.AngleStart,
                                               Find_Param.AngleExtent,
                                               Find_Param.ScaleMin,
                                               Find_Param.ScaleMax,
                                               Find_Param.MinScore,
                                               Find_Param.NumMatches,
                                               Find_Param.MaxOverlap,
                                               Find_Param.SubPixel,
                                               Find_Param.NumLevels,
                                               Find_Param.Greediness,
                                               out row,
                                               out col,
                                               out angle,
                                               out scale,
                                               out score);

                    if (row.Length == 1)
                    {
                        find_result.Row = row;
                        find_result.Col = col;
                        find_result.Angle = angle;
                        find_result.Scale = scale;
                        find_result.Score = score;
                        find_result.JJS_Model.Set(Model);
                        find_result.Find_OK = true;
                    }
                }
            }

            return find_result.Find_OK;
        }
        public bool Update()
        {
            Param_Data_OK = false;
            try
            {
                Find_Region.Region = Create_Region.Region.DilationRectangle1(Find_Ofs, Find_Ofs);
                if (Create_Shape_Model(Base_Image, Create_Param, ref Model))
                {
                    if (Find(Base_Image, ref Find_Result))
                        Param_Data_OK = true;
                }
            }
            catch { }
            return Param_Data_OK;
        }
    }
    public class TAlign_Mothed_4_Result : TBase_Result
    {
        public HImage Image = new HImage();
        public double D_Col, D_Row, D_Angle;

        public TAlign_Mothed_4_Result()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Mothed_4_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Mothed_4_Result && dis_base is TAlign_Mothed_4_Result)
            {
                base.Copy(sor_base, dis_base);
                TAlign_Mothed_4_Result sor = (TAlign_Mothed_4_Result)sor_base;
                TAlign_Mothed_4_Result dis = (TAlign_Mothed_4_Result)dis_base;
                if (JJS_Vision.Is_Not_Empty(sor.Image)) dis.Image = sor.Image.Clone();
                dis.D_Col = sor.D_Col;
                dis.D_Row = sor.D_Row;
                dis.D_Angle = sor.D_Angle;
            }
        }


        override public void Set_Default()
        {
            base.Set_Default();
            D_Col = 0;
            D_Row = 0;
            D_Angle = 0;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
            }
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
        }
        override public void Display_Message(HWindowControl hw)
        {

        }
        override public void Display_Model(HWindowControl hw)
        {

        }
        override public string Get_Message()
        {
            string result = "";
            return result;
        }
    }
}
