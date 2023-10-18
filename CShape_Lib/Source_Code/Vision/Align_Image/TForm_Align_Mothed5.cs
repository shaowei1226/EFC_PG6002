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
    public partial class TForm_Align_Mothed5 : Form
    {
        public string Default_Path;
        public HImage Image1 = new HImage();
        public HImage Image2 = new HImage();
        public TAlign_Mothed_5_Param Param = new TAlign_Mothed_5_Param();
        public TAlign_Mothed_5_Result Result = new TAlign_Mothed_5_Result();
        public TFrame_JJS_HW JJS_HW = null;
        public int Step = 0;
        public double Disp_Scale = 1.0;
        public int  Model_No = -1;

        
        public TForm_Align_Mothed5()
        {
            InitializeComponent();
            //JJS_HW = tFrame_JJS_HW1;
        }
        private void TForm_Align_Mothed4_Shown(object sender, EventArgs e)
        {
            JJS_HW = tFrame_JJS_HW1;
            JJS_HW.Init();
            WindowState = FormWindowState.Maximized;
            if (!JJS_Vision.Is_Empty(Param.Base_Image))
            {
                Image1 = Param.Base_Image.Clone();
                B_Base_Image.BackColor = Color.LightGreen;
            }
            if (!JJS_Vision.Is_Empty(Image2)) B_Trans_Image.BackColor = Color.LightGreen;
          
            if (!JJS_Vision.Is_Empty(Image1)) Param.Base_Image = Image1.Clone();
            JJS_HW.SetPart(Image1);
            Draw_Image(Image1);
        }
        public void Set_Param(TAlign_Mothed_5_Param param)
        {
            Param.Set(param);
            ListBox lb;

            lb = LB_Model;
            lb.Items.Clear();
            for(int i=0; i<Param.Model_Count; i++)
            {
                lb.Items.Add("Model" + (i + 1).ToString());
            }
        }
        public void Update_Param()
        {
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
                    JJS_HW.HW_Buf.HalconWindow.DispObj(image);
                }
            }
            catch
            {

            }
            JJS_HW.Copy_HW();
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
                JJS_HW.HW_Buf.HalconWindow.ClearWindow();

                if (JJS_Vision.Is_Empty(Image1))
                    flag = false;

                //if (TJJS_Vision.Is_Empty(Image2))
                //    flag = false;

                #region Step1 display image
                if (Step >= 1 && flag)
                {
                    image1 = Image1.Clone();
                    if (!JJS_Vision.Is_Empty(Image2)) image2 = Image2.Clone();
                    else flag = false;

                    if (Step == 1)
                        image1.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    if (Step == 2)
                        image1.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step3 select Circle
                if (Step >= 3 && flag)
                {
                    Param.Update();

                    if (Step == 3)
                    {
                        JJS_HW.HW_Buf.HalconWindow.DispObj(image1);
                        for (int i = 0; i < Param.Base_Find_Result.Length; i++ )
                            Param.Base_Find_Result[i].Display(JJS_HW.HW_Buf);
                    }
                }
                #endregion

                #region Step4 select Circle
                if (Step >= 4 && flag)
                {
                    Param.Find(image2, ref Result.Sample_Find_Result);

                    if (Step == 4)
                    {
                        JJS_HW.HW_Buf.HalconWindow.DispObj(image2);
                        Result.Display(JJS_HW.HW_Buf);
                    }
                }
                #endregion

                #region Step5 Display result image
                if (Step >= 5 && flag)
                {
                    Param.Trans(image2, ref Result);
                    if (Step == 5) 
                        Draw_Image(Result.Image);
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
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Finish_Click(object sender, EventArgs e)
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
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
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
            if (Param.Trans(Image2, ref Result))
            {
                Draw_Image(Result.Image);
            }
        }
        private void LB_Auto_Focus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb;

            lb = LB_Model;
            Model_No = -1;
            if (lb.SelectedIndex >= 0)
            {
                Model_No = lb.SelectedIndex;
                tFrame_Select_Model1.Enabled = true;
                tFrame_Select_Model1.Set_Model(Param.Model[Model_No].JJS_Model);                
            }
            else tFrame_Select_Model1.Enabled = false;
        }
        private void B_Create_Model_Click(object sender, EventArgs e)
        {
            if (Model_No >= 0)
            {
                if (Param.Model[Model_No].Set_Param(Image1))
                {
                    tFrame_Select_Model1.Set_Model(Param.Model[Model_No].JJS_Model);
                }
            }
        }
        private void B_Base_Image_Find_Click(object sender, EventArgs e)
        {
            Param.Update();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            JJS_HW.HW_Buf.HalconWindow.DispObj(Image1);
            for (int i = 0; i < Param.Base_Find_Result.Length; i++ )
                Param.Base_Find_Result[i].Display(JJS_HW.HW_Buf);
            JJS_HW.Copy_HW();
        }
        private void B_Sample_Image_Find_Click(object sender, EventArgs e)
        {
            Param.Find(Image2, ref Result.Sample_Find_Result);
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            JJS_HW.HW_Buf.HalconWindow.DispObj(Image2);
            Result.Display(JJS_HW.HW_Buf);
            JJS_HW.Copy_HW();
        }
    }
    public class TAlign_Mothed_5_Param : TBase_Param
    {
        public bool                     Param_Data_OK = false;
        public HImage                   Base_Image = null;
        public TFind_Mothed_1_Param[]   Model = new TFind_Mothed_1_Param[0];
        public TFind_Mothed_1_Result[]  Base_Find_Result = new TFind_Mothed_1_Result[0];


        public int Model_Count
        {
            get
            {
                return Model.Length;
            }
            set
            {
                int old_count = Model_Count;
                Array.Resize(ref Model, value);
                for(int i=old_count; i<value; i++)
                {
                    Model[i] = new TFind_Mothed_1_Param();
                }
            }
        }
        public int Base_Find_Result_Count
        {
            get
            {
                return Base_Find_Result.Length;
            }
            set
            {
                int old_count = Base_Find_Result_Count;
                Array.Resize(ref Base_Find_Result, value);
                for (int i = old_count; i < value; i++)
                {
                    Base_Find_Result[i] = new TFind_Mothed_1_Result();
                }
            }
        }
        public TAlign_Mothed_5_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Mothed_5_Param();
        }
        override public TBase_Result New_Base_Result()
        {
            return new TAlign_Mothed_5_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Mothed_5_Param && dis_base is TAlign_Mothed_5_Param)
            {
                TAlign_Mothed_5_Param sor = (TAlign_Mothed_5_Param)sor_base;
                TAlign_Mothed_5_Param dis = (TAlign_Mothed_5_Param)dis_base;
                base.Copy(sor, dis);

                dis.Param_Data_OK = sor.Param_Data_OK;
                dis.Base_Image = sor.Base_Image;
                dis.Model_Count = sor.Model_Count;
                for (int i = 0; i < sor.Model_Count; i++) dis.Model[i].Set(sor.Model[i]);
            }
        }


        public override void Set_Default()
        {
            base.Set_Default();
            Param_Data_OK = false;
            Base_Image = null;
            Model_Count = 4;
            Base_Find_Result_Count = 4;
            for (int i = 0; i < Model_Count; i++) Model[i].Set_Default();
        }
        public override void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                base.Read(ini, section);
                for (int i = 0; i < Model_Count; i++) Model[i].Read(ini, section + "/Model" + (i + 1).ToString());
            }
        }
        public override void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                base.Write(ini, section);
                for (int i = 0; i < Model_Count; i++) Model[i].Write(ini, section + "/Model" + (i + 1).ToString());
            }
        }
        public override void Read_Other_File()
        {
            for (int i = 0; i < Model_Count; i++) Model[i].Read_Other_File();
        }
        public override void Write_Other_File()
        {
            for (int i = 0; i < Model_Count; i++) Model[i].Write_Other_File();
        }
        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Align_Mothed5 form = new TForm_Align_Mothed5();
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
        public bool Find_Base(HImage image, ref TAlign_Mothed_5_Result f_result)
        {
            return Trans(image, ref f_result);
        }



        public bool Trans(HImage image, ref TBase_Result f_result)
        {
            bool result = false;
            if (f_result is TAlign_Mothed_5_Result)
            {
                TAlign_Mothed_5_Result in_result = (TAlign_Mothed_5_Result)f_result;
                result = Trans(image, ref in_result);
            }
            return result;
        }
        public bool Trans(HImage image, ref TAlign_Mothed_5_Result f_result)
        {
            bool result = false;
            HHomMat2D HomMat2D = new HHomMat2D();
            HTuple base_cols = new HTuple();
            HTuple base_rows = new HTuple();
            HTuple sample_cols = new HTuple();
            HTuple sample_rows = new HTuple();
            HTuple covXX1 = new HTuple();
            HTuple covYY1 = new HTuple();
            HTuple covXY1 = new HTuple();
            HTuple covXX2 = new HTuple();
            HTuple covYY2 = new HTuple();
            HTuple covXY2 = new HTuple();
            int w, h;

            f_result.Reset();
            if (!JJS_Vision.Is_Empty(image)) f_result.Image = image.Clone();

            if (Find(image, ref f_result.Sample_Find_Result))
            {
                try
                {
                    for (int i = 0; i < Base_Find_Result.Length; i++)
                    {
                        base_cols = base_cols.TupleConcat(Base_Find_Result[i].Col);
                        base_rows = base_rows.TupleConcat(Base_Find_Result[i].Row);
                    }

                    for (int i = 0; i < f_result.Sample_Find_Result.Length; i++)
                    {
                        sample_cols = sample_cols.TupleConcat(f_result.Sample_Find_Result[i].Col);
                        sample_rows = sample_rows.TupleConcat(f_result.Sample_Find_Result[i].Row);
                    }

                    HomMat2D.VectorToProjHomMat2d(sample_rows, sample_cols, base_rows, base_cols, "normalized_dlt",
                                                  covXX1, covYY1, covXY1, covXX2, covYY2, covXY2);
                    image.GetImageSize(out w, out h);
                    f_result.Image = image.ProjectiveTransImageSize(HomMat2D, "bilinear", w, h, "false");
                    f_result.Find_OK = true;
                }
                catch { };
            }

            result = f_result.Find_OK;
            return result;
        }
        public TJJS_Point Get_Ofs(HImage image1, HImage image2, TFind_Mothed_1_Param param)
        {
            TJJS_Point result = new TJJS_Point();
            TFind_Mothed_1_Result find1 = new TFind_Mothed_1_Result();
            TFind_Mothed_1_Result find2 = new TFind_Mothed_1_Result();

            result.Set(0, 0);
            param.Find(image1, ref find1, false);
            param.Find(image2, ref find2, false);
            if (find1.Find_OK && find2.Find_OK)
            {
                result.Set(find2.Col - find1.Col, find2.Row - find1.Row);
            }
            return result;
        }
        public bool Find(HImage image, ref TFind_Mothed_1_Result[] find_result)
        {
            bool result = true;
            stRect_Double tmp_rect = new stRect_Double();
            TJJS_Point ofs = new TJJS_Point();

            ofs = Get_Ofs(Base_Image, image, Model[0]);
            if (find_result.Length >= Model_Count)
            {
                for (int i = 0; i < Model_Count; i++)
                {
                    tmp_rect = Model[i].Find_Region + ofs;
                    find_result[i].Reset();
                    if (!Model[i].Find(image, tmp_rect, ref find_result[i], false)) result = false;
                }
            }
            return result;
        }
        public bool Update()
        {
            Param_Data_OK = false;
            try
            {
                Find(Base_Image, ref Base_Find_Result);
            }
            catch { }
            return Param_Data_OK;
        }
    }
    public class TAlign_Mothed_5_Result : TBase_Result
    {
        public HImage Image = new HImage();
        public TFind_Mothed_1_Result[] Sample_Find_Result = new TFind_Mothed_1_Result[0];

        public int Sample_Find_Result_Count
        {
            get
            {
                return Sample_Find_Result.Length;
            }
            set
            {
                int old_count = Sample_Find_Result_Count;
                Array.Resize(ref Sample_Find_Result, value);
                for (int i = old_count; i < value; i++)
                {
                    Sample_Find_Result[i] = new TFind_Mothed_1_Result();
                }
            }
        }
        public TAlign_Mothed_5_Result()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Mothed_5_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Mothed_5_Result && dis_base is TAlign_Mothed_5_Result)
            {
                base.Copy(sor_base, dis_base);
                TAlign_Mothed_5_Result sor = (TAlign_Mothed_5_Result)sor_base;
                TAlign_Mothed_5_Result dis = (TAlign_Mothed_5_Result)dis_base;

                if (JJS_Vision.Is_Not_Empty(sor.Image)) dis.Image = sor.Image.Clone();
                for (int i = 0; i < sor.Sample_Find_Result_Count; i++)
                    sor.Sample_Find_Result[i].Copy(dis.Sample_Find_Result[i]);
            }
        }


        override public void Set_Default()
        {
            base.Set_Default();
            Sample_Find_Result_Count = 4;
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
            for (int i = 0; i < Sample_Find_Result_Count; i++) Sample_Find_Result[i].Reset();
        }
        override public void Display_Message(HWindowControl hw)
        {

        }
        override public void Display_Model(HWindowControl hw)
        {
            for (int i = 0; i < Sample_Find_Result.Length; i++)
            {
                Sample_Find_Result[i].Display(hw);
            }
        }
        override public string Get_Message()
        {
            string result = "";
            return result;
        }
    }
}
