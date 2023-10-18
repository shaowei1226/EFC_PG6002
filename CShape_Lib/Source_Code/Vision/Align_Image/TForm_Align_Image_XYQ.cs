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
    //-----------------------------------------------------------------------------------------------------
    //Align_Mode = 0, 無
    //
    //Align_Mode = 1, 使用1點定位 X,Y,
    //
    //Align_Mode = 2, 使用2點定位 X,Y,Q
    //Align_Angle = false, 角度不修正, Align_Angle = true,角度修正
    //
    //Base_Image = 參考的基準影像
    //
    //Find_Result[0] = 第1點資訊
    //Find_Result[1] = 第2點資訊
    //Find_Result[2] = 對位基準點資訊,2點模式，目前基準為第1點
    //-----------------------------------------------------------------------------------------------------
    public partial class TForm_Align_Image_XYQ : Form
    {
        public string Default_Path;
        public HImage Sample_Image = new HImage();
        public TAlign_Image_XYQ_Param Param = new TAlign_Image_XYQ_Param();
        public TAlign_Image_XYQ_Result Result = new TAlign_Image_XYQ_Result();
        public TFrame_JJS_HW JJS_HW = null;
        public int Step = 0;

        
        public TForm_Align_Image_XYQ()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            tFrame_Select_Model1.B_Edit.Visible = false;
            tFrame_Select_Model1.B_Select_File.Visible = false;
            tFrame_Select_Model2.B_Edit.Visible = false;
            tFrame_Select_Model2.B_Select_File.Visible = false;

            Param.Model1_Result.Disp_Param.Msg_Y = 10;
            Param.Model2_Result.Disp_Param.Msg_Y = 50;
            Result.Model1_Result.Disp_Param.Msg_Y = 10;
            Result.Model2_Result.Disp_Param.Msg_Y = 50;
        }
        public int Image_Width
        {
            get
            {
                int w, h;
                Param.Image_Base.GetImageSize(out w, out h);
                return w;
            }
        }
        public int Image_Height
        {
            get
            {
                int w, h;
                Param.Image_Base.GetImageSize(out w, out h);
                return h;
            }
        }
        private void TForm_Align_Mothed2_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Param.Image_Base), Color.LightGreen, Color.Transparent);
            Form_Tool.Set_Button_Face(B_Trans_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.LightGreen, Color.Transparent);
            JJS_HW.SetPart(Param.Image_Base);
            Disp_Image(JJS_HW.HW_Buf, Param.Image_Base);
            JJS_HW.Copy_HW();
        }
        public void Set_Param(TAlign_Image_XYQ_Param param)
        {
            Param.Set(param);

            switch(Param.Align_Mode)
            {
                case 0: RB_Align_Mode1.Checked = true;  Set_Mark_No(0); break;
                case 1: RB_Align_Mode2.Checked = true; Set_Mark_No(1); break;
                case 2: RB_Align_Mode3.Checked = true; Set_Mark_No(2); break;
                default: RB_Align_Mode1.Checked = true; Set_Mark_No(0); break;
            }
            tFrame_Select_Model1.Set_Model(Param.Model1.JJS_Model);
            tFrame_Select_Model2.Set_Model(Param.Model2.JJS_Model);
        }
        public void Update_Param()
        {
            Param.Align_Mode = 0;
            if (RB_Align_Mode1.Checked) Param.Align_Mode = 0;
            if (RB_Align_Mode2.Checked) Param.Align_Mode = 1;
            if (RB_Align_Mode3.Checked) Param.Align_Mode = 2;

            Param.Model1.JJS_Model.Set(tFrame_Select_Model1.JJS_Model);
            Param.Model2.JJS_Model.Set(tFrame_Select_Model2.JJS_Model);
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
        }
        public void Disp_Image(HWindowControl hw, HImage image, bool clear_flag = true)
        {
            if (clear_flag) hw.HalconWindow.ClearWindow();
            if (JJS_Vision.Is_Not_Empty(image))
                hw.HalconWindow.DispObj(image);
        }
        public void Draw_Find_Model(HWindowControl hw, TFind_Mothed_1_Result find_result)
        {
            find_result.Display(hw);
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();
            double row, col, radius;
            TFind_Mothed_1_Result[] sample_result = new TFind_Mothed_1_Result[3];

            for(int i=0; i<sample_result.Length; i++) sample_result[i] = new TFind_Mothed_1_Result();
            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                if (JJS_Vision.Is_Empty(Param.Image_Base)) flag = false;

                #region Step1 display image
                if (Step >= 1 && flag)
                {
                    if (Step == 1) Param.Image_Base.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    if (Step == 2) Param.Image_Base.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step3 display base mode
                if (Step >= 3 && flag)
                {
                    if (JJS_Vision.Is_Empty(Sample_Image)) flag = false;
                    else
                    {
                        Param.Trans(Sample_Image, ref Result);
                        if (Step == 3) Disp_Result_Model();
                    }
                }
                #endregion

                #region Step4 select Circle
                if (Step >= 4 && flag)
                {
                    Disp_Result_Image();
                }
                #endregion

                JJS_HW.Copy_HW();
            }
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Disp_Image(JJS_HW.HW_Buf, Param.Image_Base);
            JJS_HW.Copy_HW();
        }
        private void B_Trans_Image_Click(object sender, EventArgs e)
        {
            Disp_Image(JJS_HW.HW_Buf, Sample_Image);
            JJS_HW.Copy_HW();
        }
        private void B_Select_Base_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Base_Image_File.Text = dialog.FileName;
                Param.Image_Base.ReadImage(E_Base_Image_File.Text);
                JJS_HW.SetPart(Param.Image_Base);
                Disp_Image(JJS_HW.HW_Buf, Param.Image_Base);
                JJS_HW.Copy_HW();
                Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Param.Image_Base), Color.LightGreen, Color.Transparent);
            }
        }
        private void B_Select_Trans_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Trans_Image_File.Text = dialog.FileName;
                Sample_Image.ReadImage(E_Trans_Image_File.Text);
                JJS_HW.SetPart(Sample_Image);
                Disp_Image(JJS_HW.HW_Buf, Sample_Image);
                JJS_HW.Copy_HW();
                Form_Tool.Set_Button_Face(B_Trans_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.LightGreen, Color.Transparent);
            }
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
        private void B_Select_Rect1_Click_1(object sender, EventArgs e)
        {
            if (Param.Model1.Set_Param(Param.Image_Base))
            {
                tFrame_Select_Model1.Set_Model(Param.Model1.JJS_Model);
                Param.Update();
            }
        }
        private void B_Select_Rect2_Click(object sender, EventArgs e)
        {
            if (Param.Model2.Set_Param(Param.Image_Base))
            {
                tFrame_Select_Model2.Set_Model(Param.Model2.JJS_Model);
                Param.Update();
            }
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
        }
        private void RB_Align_Mode1_Click(object sender, EventArgs e)
        {
            Set_Mark_No(0);
        }
        private void RB_Align_Mode2_Click(object sender, EventArgs e)
        {
            Set_Mark_No(1);
        }
        private void RB_Align_Mode3_Click(object sender, EventArgs e)
        {
            Set_Mark_No(2);
        }
        public void Set_Mark_No(int no)
        {
            switch (no)
            {
                case 0:
                    tabControl2.Visible = false;
                    break;

                case 1:
                    tabControl2.Visible = true;
                    tabControl2.TabPages.Remove(TP_Mark2);
                    break;

                case 2:
                    tabControl2.Visible = true;
                    if (tabControl2.TabPages.Count < 2) tabControl2.TabPages.Insert(1, TP_Mark2);
                    break;
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RB_Step3_Image1_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Result_Model();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Result_Model();
        }
        private void RB_Step4_Image1_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Result_Image();
        }
        private void Disp_Result_Model()
        {
            if (RB_Step3_Image1.Checked)
            {
                Set_Result_Msg(ref Param.Model1_Result, 0);
                Set_Result_Msg(ref Param.Model2_Result, 1);

                Disp_Image(JJS_HW.HW_Buf, Param.Image_Base);
                Draw_Find_Model(JJS_HW.HW_Buf, Param.Model1_Result);
                if (Param.Align_Mode == 1)
                    Draw_Find_Model(JJS_HW.HW_Buf, Param.Model2_Result);
            }
            else
            {
                Set_Result_Msg(ref Result.Model1_Result, 0);
                Set_Result_Msg(ref Result.Model2_Result, 1);

                Disp_Image(JJS_HW.HW_Buf, Sample_Image);
                Draw_Find_Model(JJS_HW.HW_Buf, Result.Model1_Result);
                if (Param.Align_Mode == 1)
                    Draw_Find_Model(JJS_HW.HW_Buf, Result.Model2_Result);
            }
            JJS_HW.Copy_HW();
        }
        private void Set_Result_Msg(ref TFind_Mothed_1_Result f_result, int index)
        {
            double scale = (double)Image_Width / JJS_HW.HW.Width;
            f_result.Disp_Param.Msg_X = 50 * scale;
            f_result.Disp_Param.Msg_Y = (50 + index * 30) * scale;
            f_result.Disp_Param.Msg_Font_Size = 20 * scale;
            f_result.Disp_Param.Msg_Name = "Model" + (index + 1).ToString();
        }
        private void Disp_Result_Image()
        {
            if (RB_Step4_Image1.Checked) Disp_Image(JJS_HW.HW_Buf, Param.Image_Base);
            if (RB_Step4_Image2.Checked) Disp_Image(JJS_HW.HW_Buf, Sample_Image);
            if (RB_Step4_Image3.Checked) Disp_Image(JJS_HW.HW_Buf, Result.Image);
            JJS_HW.Copy_HW();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
    public class TAlign_Image_XYQ_Param : TBase_Param
    {
        public string                   Class_Name; 
        public int                      Align_Mode = 0;
        public TFind_Mothed_1_Param     Model1 = new TFind_Mothed_1_Param();
        public TFind_Mothed_1_Param     Model2 = new TFind_Mothed_1_Param();
        public HImage                   Image_Base = new HImage();
        private string                  inFile_Name_Base_Image = "Base_Image.bmp";

        public bool                     Param_Data_OK;
        public TFind_Mothed_1_Result    Model1_Result = new TFind_Mothed_1_Result();
        public TFind_Mothed_1_Result    Model2_Result = new TFind_Mothed_1_Result();
        public double                   Base_Col = 0;
        public double                   Base_Row = 0;
        public double                   Base_Angle = 0;


        public string File_Name_Image_Base
        {
            get
            {
                return inFile_Name_Base_Image;
            }
            set
            {
                inFile_Name_Base_Image = value;
            }
        }
        public string Full_File_Name_Image_Base
        {
            get
            {
                return Default_Path + inFile_Name_Base_Image;
            }
        }
        public TAlign_Image_XYQ_Param()
        {
            Class_Name = "TAlign_Image_XYQ_Param";
            Set_Default();
        }
        public override TBase_Class New_Class()
        {
            TBase_Class result = new TAlign_Image_XYQ_Param();
            return result;
        }
        public override TBase_Result New_Base_Result()
        {
            TBase_Result result = new TAlign_Image_XYQ_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Image_XYQ_Param && dis_base is TAlign_Image_XYQ_Param)
            {

                TAlign_Image_XYQ_Param sor = (TAlign_Image_XYQ_Param)sor_base;
                TAlign_Image_XYQ_Param dis = (TAlign_Image_XYQ_Param)dis_base;
                base.Copy(sor, dis);
                dis.Align_Mode = sor.Align_Mode;
                dis.Model1.Set(sor.Model1);
                dis.Model2.Set(sor.Model2);

                dis.Param_Data_OK = sor.Param_Data_OK;
                if (JJS_Vision.Is_Not_Empty(sor.Image_Base)) dis.Image_Base = sor.Image_Base.Clone();
                dis.Update();
            }
        }
        public override void Set_Default()
        {
            base.Set_Default();
            Align_Mode = 0;
            Model1.Set_Default();
            Model2.Set_Default();

            Param_Data_OK = false;
            Model1_Result.Set_Default();
            Model2_Result.Set_Default();
            Base_Col = 0;
            Base_Row = 0;
            Base_Angle = 0;
            inFile_Name_Base_Image = "Base_Image.bmp";
        }
        override public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Model1.Set_Default_Path(Default_Path + "Model1\\");
            Model2.Set_Default_Path(Default_Path + "Model2\\");
        }
        public override void Read(TJJS_XML_File ini, string section)
        {
            string path = Default_Path;
            if (ini != null)
            {
                base.Read(ini, section);
                Class_Name = ini.ReadString(section, "Class_Name", "TAlign_Image_XYQ_Param");
                path = Default_Path;
                Align_Mode = ini.ReadInteger(section, "Align_Mode", 0);

                Model1.Read(ini, section + "/Model1");
                Model2.Read(ini, section + "/Model2");
                Read_Other_File();
                Update();
            }
        }
        public override void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                base.Write(ini, section);
                ini.WriteString(section, "Class_Name", Class_Name);

                ini.WriteInteger(section, "Align_Mode", Align_Mode);

                Model1.Write(ini, section + "/Model1");
                Model2.Write(ini, section + "/Model2");
                Write_Other_File();
                Update();
            }
        }
        public override void Read_Other_File()
        {
            string filename = Full_File_Name_Image_Base;
            if (System.IO.File.Exists(filename)) Image_Base.ReadImage(filename);
            else Image_Base.GenEmptyObj();
        }
        public override void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TAlign_Image_XYQ_Param new_value, ref bool flag)
        {
            Model1.Log_Diff(log, section + "/Model1", new_value.Model1, ref flag);
            Model2.Log_Diff(log, section + "/Model2", new_value.Model2, ref flag);
            log.Log_Diff(section + "/Align_Mode", Align_Mode, new_value.Align_Mode, ref flag);
        }

        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Align_Image_XYQ form = new TForm_Align_Image_XYQ();
            JJS_Vision.Copy_Obj(image, ref form.Sample_Image);
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
        public bool Find_Base(HImage image, ref TAlign_Image_XYQ_Result f_result)
        {
            return Trans(image, ref f_result);
        }

        public bool Trans(HImage image, ref TBase_Result f_result)
        {
            bool result = false;
            if (f_result is TAlign_Image_XYQ_Result)
            {
                TAlign_Image_XYQ_Result in_result = (TAlign_Image_XYQ_Result)f_result;
                result = Trans(image, ref in_result);
            }
            return result;
        }
        public bool Trans(HImage image, ref TAlign_Image_XYQ_Result f_result)
        {
            bool result = false;

            f_result.Reset();
            if (JJS_Vision.Is_Not_Empty(image)) f_result.Image = image.Clone();
            else f_result.Image = new HImage();

            if (Param_Data_OK && JJS_Vision.Is_Not_Empty(image))
            {
                if (Align_Mode == 0)
                {
                    JJS_Vision.Copy_Obj(image, ref f_result.Image);
                    f_result.Find_OK = true;
                }
                else
                {
                    if (Find(image, ref f_result.Model1_Result, ref f_result.Model2_Result, ref f_result.Sample_Col, ref f_result.Sample_Row, ref f_result.Sample_Angle))
                    {
                        f_result.Image = JJS_Vision.Affine_Trans_Image(f_result.Image, Base_Col, Base_Row, 0, f_result.Sample_Col, f_result.Sample_Row, Base_Angle - f_result.Sample_Angle);
                        f_result.Find_OK = true;
                    }
                }
            }
            result = f_result.Find_OK;
            return result;
        }
        public bool Trans(HImage image, ref HImage out_image)
        {
            bool result = false;
            TAlign_Image_XYQ_Result f_result = new TAlign_Image_XYQ_Result();

            result = Trans(image, ref f_result);
            JJS_Vision.Copy_Obj(f_result.Image, ref out_image);
            return result;
        }
        public bool Find(HImage image, ref TFind_Mothed_1_Result find1, ref TFind_Mothed_1_Result find2, ref double col, ref double row, ref double angle)
        {
            bool result = false;
            TJJS_Line line = new TJJS_Line();
            double dist = 0;

            if (JJS_Vision.Is_Not_Empty(image))
            {
                switch (Align_Mode)
                {
                    case 0:
                        find1.Find_OK = true;
                        col = 0;
                        row = 0;
                        angle = 0.0;
                        result = true;
                        break;

                    case 1:
                        Model1.Find(image, ref find1);
                        if (find1.Find_OK)
                        {
                            col = find1.Col;
                            row = find1.Row;
                            angle = 0.0;
                            result = true;
                        }
                        break;

                    case 2:
                        Model1.Find(image, ref find1);
                        Model2.Find(image, ref find2);

                        if (find1.Find_OK && find2.Find_OK)
                        {
                            line.Start = new TJJS_Point(find1.Col, find1.Row);
                            line.End = new TJJS_Point(find2.Col, find2.Row);
                            dist = line.Length();

                            col = line.Mid.X;
                            row = line.Mid.Y;
                            angle = line.V.Angle.r;
                            result = true;
                        }
                        break;
                }
            }
            return result;
        }
        public void Update()
        {
            Param_Data_OK = Find(Image_Base, ref Model1_Result, ref Model2_Result, ref Base_Col, ref Base_Row, ref Base_Angle);
        }
    }
    public class TAlign_Image_XYQ_Result : TBase_Result
    {
        public HImage                Image = new HImage();
        public TFind_Mothed_1_Result Model1_Result = new TFind_Mothed_1_Result();
        public TFind_Mothed_1_Result Model2_Result = new TFind_Mothed_1_Result();
        public double                Sample_Col = 0;
        public double                Sample_Row = 0;
        public double                Sample_Angle = 0;
        public TBase_Disp_Param      Disp_Param = new TBase_Disp_Param();

        public TAlign_Image_XYQ_Result()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Image_XYQ_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Image_XYQ_Result && dis_base is TAlign_Image_XYQ_Result)
            {
                base.Copy(sor_base, dis_base);
                TAlign_Image_XYQ_Result sor = (TAlign_Image_XYQ_Result)sor_base;
                TAlign_Image_XYQ_Result dis = (TAlign_Image_XYQ_Result)dis_base;

                if (JJS_Vision.Is_Not_Empty(sor.Image)) dis.Image = sor.Image.Clone();
                dis.Disp_Param.Set(sor.Disp_Param);
            }
        }


        override public void Set_Default()
        {
            base.Set_Default();
            Sample_Col = 0;
            Sample_Row = 0;
            Sample_Angle = 0;
            Disp_Param.Set_Default();
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Disp_Param.Read(ini, "/Disp_Param");
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Disp_Param.Write(ini, "/Disp_Param");
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
            Image = new HImage();
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
