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
using EFC.INI;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Find_Mothed_1 : Form
    {
        public TFind_Mothed_1_Param Param = new TFind_Mothed_1_Param();
        public HImage Image = new HImage();
        public int Step = 0;
        public stJJS_HW_Info JJS_HW;

        public TForm_Find_Mothed_1()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1.JJS_HW;
        }
        public void Set_Param(TFind_Mothed_1_Param param)
        {
            TFrame_Create_Param c_frame;
            TFrame_Find_Param f_frame;

            Param = param.Copy();
            tFrame_Select_Model1.Set_Model(Param.JJS_Model);
            c_frame = tFrame_Create_Param1;
            c_frame.CB_NumLevels.Text = Param.Create.NumLevels.ToString();
            c_frame.CB_AngleStart.Text = Param.Create.AngleStart.ToString();
            c_frame.CB_AngleStep.Text = Param.Create.AngleStep.ToString();
            c_frame.CB_AngleExtent.Text = Param.Create.AngleExtent.ToString();
            c_frame.CB_Contrast.Text = Param.Create.Contrast.ToString();
            c_frame.CB_MinContrast.Text = Param.Create.MinContrast.ToString();
            c_frame.CB_ScaleMin.Text = Param.Create.ScaleMin.ToString();
            c_frame.CB_ScaleMax.Text = Param.Create.ScaleMax.ToString();
            c_frame.CB_ScaleStep.Text = Param.Create.ScaleStep.ToString();
            c_frame.CB_Optimization.Text = Param.Create.Optimization;
            c_frame.CB_Metric.Text = Param.Create.Metric;

            f_frame = tFrame_Find_Param1;
            f_frame.CB_NumLevels.Text = Param.Find.NumLevels.ToString();
            f_frame.CB_AngleStart.Text = Param.Find.AngleStart.ToString();
            f_frame.CB_AngleExtent.Text = Param.Find.AngleExtent.ToString();
            f_frame.CB_MinScore.Text = Param.Find.MinScore.ToString();
            f_frame.CB_MaxOverlap.Text = Param.Find.MaxOverlap.ToString();
            f_frame.CB_ScaleMin.Text = Param.Find.ScaleMin.ToString();
            f_frame.CB_ScaleMax.Text = Param.Find.ScaleMax.ToString();
            f_frame.CB_Greediness.Text = Param.Find.Greediness.ToString();
            f_frame.CB_NumMatches.Text = Param.Find.NumMatches.ToString();
            f_frame.CB_SubPixel.Text = Param.Find.SubPixel;

            CB_Auto_Select_Region.Checked = Param.Auto_Set_Region;
            E_Ofs_X.Text = Param.Ofs_X.ToString();
            E_Ofs_Y.Text = Param.Ofs_Y.ToString();

            E_Rect_Row1.Text = string.Format("{0:f0}", Param.Find.Area_Row1);
            E_Rect_Col1.Text = string.Format("{0:f0}", Param.Find.Area_Col1);
            E_Rect_Row2.Text = string.Format("{0:f0}", Param.Find.Area_Row2);
            E_Rect_Col2.Text = string.Format("{0:f0}", Param.Find.Area_Col2);
        }
        public void Update_Param()
        {
            TFrame_Create_Param c_frame;
            TFrame_Find_Param f_frame;

            Param.JJS_Model = tFrame_Select_Model1.JJS_Model.Copy();
            c_frame = tFrame_Create_Param1;
            Param.Create.NumLevels = Convert.ToInt32(c_frame.CB_NumLevels.Text);
            Param.Create.AngleStart = Convert.ToDouble(c_frame.CB_AngleStart.Text);
            Param.Create.AngleStep = Convert.ToDouble(c_frame.CB_AngleStep.Text);
            Param.Create.AngleExtent = Convert.ToDouble(c_frame.CB_AngleExtent.Text);
            Param.Create.Contrast = Convert.ToInt32(c_frame.CB_Contrast.Text);
            Param.Create.MinContrast = Convert.ToInt32(c_frame.CB_MinContrast.Text);
            Param.Create.ScaleMin = Convert.ToDouble(c_frame.CB_ScaleMin.Text);
            Param.Create.ScaleMax = Convert.ToDouble(c_frame.CB_ScaleMax.Text);
            Param.Create.ScaleStep = Convert.ToDouble(c_frame.CB_ScaleStep.Text);
            Param.Create.Optimization = c_frame.CB_Optimization.Text;
            Param.Create.Metric = c_frame.CB_Metric.Text;

            f_frame = tFrame_Find_Param1;
            Param.Find.NumLevels = Convert.ToInt32(f_frame.CB_NumLevels.Text);
            Param.Find.AngleStart = Convert.ToDouble(f_frame.CB_AngleStart.Text);
            Param.Find.AngleExtent = Convert.ToDouble(f_frame.CB_AngleExtent.Text);
            Param.Find.MinScore = Convert.ToDouble(f_frame.CB_MinScore.Text);
            Param.Find.MaxOverlap = Convert.ToDouble(f_frame.CB_MaxOverlap.Text);
            Param.Find.ScaleMin = Convert.ToDouble(f_frame.CB_ScaleMin.Text);
            Param.Find.ScaleMax = Convert.ToDouble(f_frame.CB_ScaleMax.Text);

            Param.Find.Greediness = Convert.ToDouble(f_frame.CB_Greediness.Text);
            Param.Find.NumMatches = Convert.ToInt32(f_frame.CB_NumMatches.Text);
            Param.Find.SubPixel = f_frame.CB_SubPixel.Text;

            Param.Auto_Set_Region = CB_Auto_Select_Region.Checked;
            Param.Ofs_X = Convert.ToDouble(E_Ofs_X.Text);
            Param.Ofs_Y = Convert.ToDouble(E_Ofs_Y.Text);

            Param.Find.Area_Row1 = Convert.ToDouble(E_Rect_Row1.Text);
            Param.Find.Area_Col1 = Convert.ToDouble(E_Rect_Col1.Text);
            Param.Find.Area_Row2 = Convert.ToDouble(E_Rect_Row2.Text);
            Param.Find.Area_Col2 = Convert.ToDouble(E_Rect_Col2.Text);
        }
        private void Form_Find_Mothed_1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tFrame_JJS_HW1.JJS_HW.SetPart(Image);
            tFrame_JJS_HW1.JJS_HW.HW_Buf.HalconWindow.DispObj(Image);
            tFrame_JJS_HW1.JJS_HW.Copy_HW();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Next1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
        private void Save_Model_Click(object sender, EventArgs e)
        {
        }
        private void B_Rect_Select_Click(object sender, EventArgs e)
        {

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow);

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            JJS_HW.HW.HalconWindow.SetTposition(1, 10);
            JJS_HW.HW.HalconWindow.WriteString("請圈選畫面搜尋區域,按滑鼠右鍵結束輸入.");
            B_Rect_Select.Enabled = false;
            B_Rect_Edit.Enabled = false;
            B_Rect_Max.Enabled = false;


            JJS_HW.HW.Focus();
            tFrame_JJS_HW1.JJS_HW.HW.HalconWindow.DrawRectangle1(out Param.Find.Area_Row1, out Param.Find.Area_Col1,
                                                                 out Param.Find.Area_Row2, out Param.Find.Area_Col2);

            if (Param.Find.Area_Col1 < 0) Param.Find.Area_Col1 = 0;
            if (Param.Find.Area_Row1 < 0) Param.Find.Area_Row1 = 0;
            if (Param.Find.Area_Col2 < 0) Param.Find.Area_Col2 = 0;
            if (Param.Find.Area_Row2 < 0) Param.Find.Area_Row2 = 0;
            JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find.Area_Row1, Param.Find.Area_Col1, Param.Find.Area_Row2, Param.Find.Area_Col2);
            E_Rect_Row1.Text = string.Format("{0:f0}", Param.Find.Area_Row1);
            E_Rect_Col1.Text = string.Format("{0:f0}", Param.Find.Area_Col1);
            E_Rect_Row2.Text = string.Format("{0:f0}", Param.Find.Area_Row2);
            E_Rect_Col2.Text = string.Format("{0:f0}", Param.Find.Area_Col2);
            B_Rect_Select.Enabled = true;
            B_Rect_Edit.Enabled = true;
            B_Rect_Max.Enabled = true;
        }
        private void B_Select_Rect_Click(object sender, EventArgs e)
        {
            HImage tmp_image = new HImage();
            double r1, c1, r2, c2;

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow);
            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            JJS_HW.HW.HalconWindow.SetTposition(10, 10);
            JJS_HW.HW.HalconWindow.WriteString("請圈選畫面標把區域,按滑鼠右鍵結束輸入.");
            JJS_HW.HW.Focus();
            JJS_HW.HW.HalconWindow.DrawRectangle1(out r1, out c1, out r2, out c2);
            JJS_HW.HW.HalconWindow.DispRectangle1(r1, c1, r2, c2);
            tmp_image = Image.Rectangle1Domain((int)r1, (int)c1, (int)r2, (int)c2);
            tmp_image = tmp_image.CropDomain();
            try
            {
                Param.JJS_Model.Model = tmp_image.CreateScaledShapeModel(
                                                 Param.Create.NumLevels,
                                                 Param.Create.AngleStart,
                                                 Param.Create.AngleExtent,
                                                 Param.Create.AngleStep,
                                                 Param.Create.ScaleMin,
                                                 Param.Create.ScaleMax,
                                                 Param.Create.ScaleStep,
                                                 Param.Create.Optimization,
                                                 Param.Create.Metric,
                                                 Param.Create.Contrast,
                                                 Param.Create.MinContrast);
                Param.JJS_Model.XLD = Param.JJS_Model.Model.GetShapeModelContours(1);
                tFrame_Select_Model1.Set_Model(Param.JJS_Model);
                if (CB_Auto_Select_Region.Checked)
                {
                    Param.Find.Area_Row1 = r1 - Param.Ofs_Y;
                    Param.Find.Area_Col1 = c1 - Param.Ofs_X;
                    Param.Find.Area_Row2 = r2 + Param.Ofs_Y;
                    Param.Find.Area_Col2 = c2 + Param.Ofs_X;
                    if (Param.Find.Area_Col1 < 0) Param.Find.Area_Col1 = 0;
                    if (Param.Find.Area_Row1 < 0) Param.Find.Area_Row1 = 0;
                    if (Param.Find.Area_Col2 < 0) Param.Find.Area_Col2 = 0;
                    if (Param.Find.Area_Row2 < 0) Param.Find.Area_Row2 = 0;
                    E_Rect_Row1.Text = string.Format("{0:f0}", Param.Find.Area_Row1);
                    E_Rect_Col1.Text = string.Format("{0:f0}", Param.Find.Area_Col1);
                    E_Rect_Row2.Text = string.Format("{0:f0}", Param.Find.Area_Row2);
                    E_Rect_Col2.Text = string.Format("{0:f0}", Param.Find.Area_Col2);
                    JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find.Area_Row1, Param.Find.Area_Col1, Param.Find.Area_Row2, Param.Find.Area_Col2);
                }
            }
            catch
            {

            }

        }
        private void B_Rect_Edit_Click(object sender, EventArgs e)
        {
            B_Rect_Select.Enabled = false;
            B_Rect_Edit.Enabled = false;
            B_Rect_Max.Enabled = false;

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow);
            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            JJS_HW.HW.HalconWindow.SetTposition(1, 10);
            JJS_HW.HW.HalconWindow.WriteString("請圈選畫面搜尋區域,按滑鼠右鍵結束輸入.");

            JJS_HW.HW.Focus();
            tFrame_JJS_HW1.JJS_HW.HW.HalconWindow.DrawRectangle1Mod(
                           Param.Find.Area_Row1, Param.Find.Area_Col1,
                           Param.Find.Area_Row2, Param.Find.Area_Col2,
                           out Param.Find.Area_Row1, out Param.Find.Area_Col1,
                           out Param.Find.Area_Row2, out Param.Find.Area_Col2);

            JJS_HW.HW.HalconWindow.SetDraw("margin");
            if (Param.Find.Area_Col1 < 0) Param.Find.Area_Col1 = 0;
            if (Param.Find.Area_Row1 < 0) Param.Find.Area_Row1 = 0;
            if (Param.Find.Area_Col2 < 0) Param.Find.Area_Col2 = 0;
            if (Param.Find.Area_Row2 < 0) Param.Find.Area_Row2 = 0;
            JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find.Area_Row1, Param.Find.Area_Col1, Param.Find.Area_Row2, Param.Find.Area_Col2);
            E_Rect_Row1.Text = string.Format("{0:f0}", Param.Find.Area_Row1);
            E_Rect_Col1.Text = string.Format("{0:f0}", Param.Find.Area_Col1);
            E_Rect_Row2.Text = string.Format("{0:f0}", Param.Find.Area_Row2);
            E_Rect_Col2.Text = string.Format("{0:f0}", Param.Find.Area_Col2);
            B_Rect_Select.Enabled = true;
            B_Rect_Edit.Enabled = true;
            B_Rect_Max.Enabled = true;
        }
        private void B_Rect_Max_Click(object sender, EventArgs e)
        {
            string type;
            int width, height;

            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow);
            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            Image.GetImagePointer1(out type, out width, out height);
            Param.Find.Area_Row1 = 0;
            Param.Find.Area_Col1 = 0;
            Param.Find.Area_Row2 = height;
            Param.Find.Area_Col2 = width;
            JJS_HW.HW.HalconWindow.ClearWindow();
            JJS_HW.HW.HalconWindow.DispImage(Image);
            JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find.Area_Row1, Param.Find.Area_Col1, Param.Find.Area_Row2, Param.Find.Area_Col2);
            E_Rect_Row1.Text = string.Format("{0:f0}", Param.Find.Area_Row1);
            E_Rect_Col1.Text = string.Format("{0:f0}", Param.Find.Area_Col1);
            E_Rect_Row2.Text = string.Format("{0:f0}", Param.Find.Area_Row2);
            E_Rect_Col2.Text = string.Format("{0:f0}", Param.Find.Area_Col2);
        }
        public void Find_Model()
        {
            string color;

            TFind_Mothed_1_Result find = new TFind_Mothed_1_Result();
            TFind_Mothed_1.Find(Image, Param, ref find);

            if (find.Find_OK) color = "green";
            else color = "red";
            TFind_Mothed_1.Disp_Message(tFrame_JJS_HW1.JJS_HW.HW_Buf, find, 10, 10, 20, 1, color);
            TFind_Mothed_1.Disp_XLD(tFrame_JJS_HW1.JJS_HW.HW_Buf, find, color);
            TFind_Mothed_1.Disp_Hairline(tFrame_JJS_HW1.JJS_HW.HW_Buf, find, 20, color);
            TFind_Mothed_1.Disp_Model_Rectangle(tFrame_JJS_HW1.JJS_HW.HW_Buf, find, color);
            TFind_Mothed_1.Disp_Find_Rectangle(tFrame_JJS_HW1.JJS_HW.HW_Buf, find, color);

            tFrame_JJS_HW1.JJS_HW.Copy_HW();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Find_Model();
        }
        private void B_Save_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();

            dialog.Filter = "Param File|*.xml";
            dialog.InitialDirectory = Param.Default_Path;
            dialog.FileName = "default.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Write(dialog.FileName, "default");
            }
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "Param File|*.xml";
            dialog.InitialDirectory = Param.Default_Path;
            dialog.FileName = "default.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Write(dialog.FileName, "default");
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                    Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    region.GenRectangle1(Param.Find.Area_Row1, Param.Find.Area_Col1, Param.Find.Area_Row2, Param.Find.Area_Col2);
                    JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                    Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                    JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                    region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step4 Set Find Param
                if (Step >= 4 && flag)
                {
                }
                #endregion

                #region Find Model
                if (Step >= 5 && flag)
                {
                    Find_Model();
                }
                #endregion
                JJS_HW.Copy_HW();
            }
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            Step = 1;
            Update_View();
        }
        private void tabPage3_Enter(object sender, EventArgs e)
        {
            Step = 2;
            Update_View();
        }
        private void tabPage5_Enter(object sender, EventArgs e)
        {
            Step = 3;
            Update_View();
        }
        private void tabPage4_Enter(object sender, EventArgs e)
        {
            Step = 4;
            Update_View();
        }
        private void tabPage6_Enter(object sender, EventArgs e)
        {
            Step = 5;
            Update_View();
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
    public class TFind_Mothed_1
    {
        public static string Default_Path;
        public static bool Set_Param(HImage image, ref TFind_Mothed_1_Param param)
        {
            bool result = false;
            TForm_Find_Mothed_1 form = new TForm_Find_Mothed_1();

            form.Image = image.Clone();
            form.Set_Param(param);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                param = form.Param.Copy();
                result = true;
            }
            return result;
        }
        public static bool Find(HImage image, TFind_Mothed_1_Param param, ref TFind_Mothed_1_Result result)
        {
            if (image != null)
            {
                try
                {
                    HImage tmp_image = new HImage();
                    HTuple row, col, angle, scale, score;
                    int r1, c1, r2, c2;
                    string type;
                    int width, height;

                    HSystem.SetSystem("border_shape_models", "true");
                    image.GetImagePointer1(out type, out width, out height);
                    tmp_image = new HImage();
                    r1 = (int)param.Find.Area_Row1;
                    c1 = (int)param.Find.Area_Col1;
                    r2 = (int)param.Find.Area_Row2;
                    c2 = (int)param.Find.Area_Col2;

                    result.Area_Row1 = param.Find.Area_Row1;
                    result.Area_Col1 = param.Find.Area_Col1;
                    result.Area_Row2 = param.Find.Area_Row2;
                    result.Area_Col2 = param.Find.Area_Col2;

                    tmp_image = image.Rectangle1Domain(r1, c1, r2, c2);
                    result.JJS_Model = param.JJS_Model.Copy();
                    tmp_image.FindScaledShapeModel(
                                               param.JJS_Model.Model,
                                               param.Find.AngleStart,
                                               param.Find.AngleExtent,
                                               param.Find.ScaleMin,
                                               param.Find.ScaleMax,
                                               param.Find.MinScore,
                                               param.Find.NumMatches,
                                               param.Find.MaxOverlap,
                                               param.Find.SubPixel,
                                               param.Find.NumLevels,
                                               param.Find.Greediness,
                                               out row,
                                               out col,
                                               out angle,
                                               out scale,
                                               out score);

                    if (row.Length == 1)
                    {
                        result.Row = row;
                        result.Col = col;
                        result.Angle = angle;
                        result.Scale = scale;
                        result.Score = score;
                        result.Find_OK = true;
                    }
                }
                catch
                {

                }
            }
            return result.Find_OK;
        }
        public static string Get_Message(TFind_Mothed_1_Result f_result)
        {
            string result = "";

            result = string.Format("Col={0:f2} Row={1:f2} Angle={2:f3} Score={3:f3} Scale={4:f1} {5:s}",
                f_result.Col, f_result.Row, f_result.Angle, f_result.Score, f_result.Scale, f_result.Find_OK ? "OK" : "NG");

            return result;
        }
        public static void Disp_Message(HWindowControl hw, TFind_Mothed_1_Result result, double col, double row, int size, double scale, string color)
        {
            TJJS_Vision.Display_String(hw, Get_Message(result), col, row, size, scale, color);
        }
        public static void Disp_XLD(HWindowControl hw, TFind_Mothed_1_Result result, string color)
        {
            TJJS_Vision.Display_Model_XLD(hw, result.Col, result.Row, result.Angle, result.JJS_Model.XLD, color);
        }
        public static void Disp_Hairline(HWindowControl hw, TFind_Mothed_1_Result result, int size, string color)
        {
            TJJS_Vision.Display_Hairline(hw, result.Col, result.Row, size, color);
        }
        public static void Disp_Model_Rectangle(HWindowControl hw, TFind_Mothed_1_Result result, string color)
        {
            TJJS_Vision.Display_Model_Rectangle(hw, result.Col, result.Row, result.Angle, result.JJS_Model.XLD, color);
        }
        public static void Disp_Find_Rectangle(HWindowControl hw, TFind_Mothed_1_Result result, string color)
        {
            TJJS_Vision.Display_Rectangle(hw, result.Area_Col1, result.Area_Row1, result.Area_Col2, result.Area_Row2, color);
        }
    }
    public class TFind_Mothed_1_Param
    {
        public string                  Default_Path,
                                       Default_FileName,
                                       FileName,
                                       Info;

        public TJJS_ShapeModel         JJS_Model = new TJJS_ShapeModel();
        public bool                    Auto_Set_Region;
        public double                  Ofs_X,
                                       Ofs_Y;
        public TCreate_Param           Create = new TCreate_Param();
        public TFind_Param             Find = new TFind_Param();

        public TFind_Mothed_1_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        public void Set_Default()
        {
            Auto_Set_Region = true;
            Ofs_X = 50;
            Ofs_Y = 50;
        }
        public TFind_Mothed_1_Param Copy()
        {
            TFind_Mothed_1_Param result = new TFind_Mothed_1_Param();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;
            result.Auto_Set_Region = Auto_Set_Region;
            result.Ofs_X = Ofs_X;
            result.Ofs_Y = Ofs_Y;

            result.JJS_Model = JJS_Model.Copy();
            result.Create = Create.Copy();
            result.Find = Find.Copy();
            return result;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = Default_Path + Default_FileName;
            if (System.IO.File.Exists(filename))
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                result = Read(ini, section);
                //ini.UpdateFile();
            };
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");
                Auto_Set_Region = ini.ReadBool(tmp_section, "Auto_Set_Region", true);
                Ofs_X = ini.ReadFloat(tmp_section, "Ofs_X", 50);
                Ofs_Y = ini.ReadFloat(tmp_section, "Ofs_Y", 50);

                Create.Read(ini, tmp_section + "/Create_Param");
                Find.Read(ini, tmp_section + "/Find_Param");
            }
            return true;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "") filename = Default_Path + Default_FileName;
            FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);
                ini.WriteBool(tmp_section, "Auto_Set_Region", Auto_Set_Region);
                ini.WriteFloat(tmp_section, "Ofs_X", Ofs_X);
                ini.WriteFloat(tmp_section, "Ofs_Y", Ofs_Y);

                Create.Write(ini, tmp_section + "/Create_Param");
                Find.Write(ini, tmp_section + "/Find_Param");
            }
            return true;
        }
        public void Read_Other_File()
        {
            JJS_Model.Read();
        }
        public void Write_Other_File()
        {
            JJS_Model.Write();
        }
    }
    public class TFind_Mothed_1_Result
    {
        public TJJS_ShapeModel JJS_Model = new TJJS_ShapeModel();
        public bool Find_OK;
        public double Col,
                                       Row,
                                       Angle,
                                       Scale,
                                       Score;
        public double Area_Col1,
                                       Area_Row1,
                                       Area_Col2,
                                       Area_Row2;

        public TFind_Mothed_1_Result()
        {
            Find_OK = false;
            Col = 0;
            Row = 0;
            Angle = 0;
            Scale = 1.0;
            Score = 0;
        }
        public TFind_Mothed_1_Result Copy()
        {
            TFind_Mothed_1_Result result = new TFind_Mothed_1_Result();
            result.JJS_Model = JJS_Model.Copy();
            result.Find_OK = Find_OK;
            result.Col = Col;
            result.Row = Row;
            result.Scale = Scale;
            result.Score = Score;

            result.Area_Col1 = Area_Col1;
            result.Area_Row1 = Area_Row1;
            result.Area_Col2 = Area_Col2;
            result.Area_Row2 = Area_Row2;

            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Find_OK = ini.ReadBool(tmp_section, "Find_Ok", false);
                Col = ini.ReadFloat(tmp_section, "Col", 0.0);
                Row = ini.ReadFloat(tmp_section, "Row", 0.0);
                Angle = ini.ReadFloat(tmp_section, "Angle", 0.0);
                Scale = ini.ReadFloat(tmp_section, "Scale", 0.0);
                Score = ini.ReadFloat(tmp_section, "Score", 0.0);

                Area_Col1 = ini.ReadFloat(tmp_section, "Area_Col1", 0.0);
                Area_Row1 = ini.ReadFloat(tmp_section, "Area_Row1", 0.0);
                Area_Col2 = ini.ReadFloat(tmp_section, "Area_Col2", 0.0);
                Area_Row2 = ini.ReadFloat(tmp_section, "Area_Row2", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteBool(tmp_section, "Find_Ok", Find_OK);
                ini.WriteFloat(tmp_section, "Col", Col);
                ini.WriteFloat(tmp_section, "Row", Row);
                ini.WriteFloat(tmp_section, "Angle", Angle);
                ini.WriteFloat(tmp_section, "Scale", Scale);
                ini.WriteFloat(tmp_section, "Score", Score);

                ini.WriteFloat(tmp_section, "Area_Col1", Area_Col1);
                ini.WriteFloat(tmp_section, "Area_Row1", Area_Row1);
                ini.WriteFloat(tmp_section, "Area_Col2", Area_Col2);
                ini.WriteFloat(tmp_section, "Area_Row2", Area_Row2);
            }
            return true;
        }
        public void Reset()
        {
            Find_OK = false;
            Col = 0;
            Row = 0;
            Angle = 0;
            Score = 0;
        }
    }
    public class TCreate_Param
    {
        public int NumLevels;
        public double AngleStart,
                                     AngleExtent,
                                     AngleStep,
                                     ScaleMin,
                                     ScaleMax,
                                     ScaleStep;
        public string Optimization,
                                     Metric;
        public int Contrast,
                                     MinContrast;

        public TCreate_Param()
        {
            NumLevels = 0;
            AngleStart = -0.2;
            AngleExtent = 0.39;
            AngleStep = 0.0;
            ScaleMin = 0.9;
            ScaleMax = 1.1;
            ScaleStep = 0;
            Optimization = "none";
            Metric = "use_polarity";
            Contrast = 30;
            MinContrast = 10;
        }
        public TCreate_Param Copy()
        {
            TCreate_Param result = new TCreate_Param();
            result.NumLevels = NumLevels;
            result.AngleStart = AngleStart;
            result.AngleExtent = AngleExtent;
            result.AngleStep = AngleStep;
            result.ScaleMin = ScaleMin;
            result.ScaleMax = ScaleMax;
            result.ScaleStep = ScaleStep;
            result.Optimization = Optimization;
            result.Metric = Metric;
            result.Contrast = Contrast;
            result.MinContrast = MinContrast;
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                NumLevels = ini.ReadInteger(tmp_section, "NumLevels", 0);
                AngleStart = ini.ReadFloat(tmp_section, "AngleStart", -0.2);
                AngleExtent = ini.ReadFloat(tmp_section, "AngleExtent", 0.39);
                AngleStep = ini.ReadFloat(tmp_section, "AngleStep", 0.0);
                Optimization = ini.ReadString(tmp_section, "Optimization", "none");
                Metric = ini.ReadString(tmp_section, "Metric", "use_polarity");
                Contrast = ini.ReadInteger(tmp_section, "Contrast", 30);
                MinContrast = ini.ReadInteger(tmp_section, "MinContrast", 5);
                ScaleMin = ini.ReadFloat(tmp_section, "ScaleMin", 1.0);
                ScaleMax = ini.ReadFloat(tmp_section, "ScaleMax", 1.0);
                ScaleStep = ini.ReadFloat(tmp_section, "ScaleStep", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteInteger(tmp_section, "NumLevels", NumLevels);
                ini.WriteFloat(tmp_section, "AngleStart", AngleStart);
                ini.WriteFloat(tmp_section, "AngleExtent", AngleExtent);
                ini.WriteFloat(tmp_section, "AngleStep", AngleStep);
                ini.WriteString(tmp_section, "Metric", Metric);
                ini.WriteInteger(tmp_section, "Contrast", Contrast);
                ini.WriteInteger(tmp_section, "MinContrast", MinContrast);
                ini.WriteFloat(tmp_section, "ScaleMin", ScaleMin);
                ini.WriteFloat(tmp_section, "ScaleMax", ScaleMax);
                ini.WriteFloat(tmp_section, "ScaleStep", ScaleStep);
            }
            return true;
        }
    }
    public class TFind_Param
    {
        public int NumLevels,
                                     NumMatches;
        public double AngleStart,
                                     AngleExtent,
                                     MinScore,
                                     MaxOverlap,
                                     Greediness,
                                     ScaleMin,
                                     ScaleMax;
        public string SubPixel;
        public double Area_Col1,
                                     Area_Row1,
                                     Area_Col2,
                                     Area_Row2;

        public TFind_Param()
        {
            NumLevels = 0;
            NumMatches = 1;
            AngleStart = -0.2;
            AngleExtent = 0.39;
            MinScore = 0.7;
            MaxOverlap = 0.7;
            Greediness = 0;
            ScaleMin = 0.9;
            ScaleMax = 1.1;
            SubPixel = "none";
            Area_Col1 = 0;
            Area_Row1 = 0;
            Area_Col2 = 640;
            Area_Row2 = 480;
        }
        public TFind_Param Copy()
        {
            TFind_Param result = new TFind_Param();
            result.NumLevels = NumLevels;
            result.NumMatches = NumMatches;
            result.AngleStart = AngleStart;
            result.AngleExtent = AngleExtent;
            result.MinScore = MinScore;
            result.MaxOverlap = MaxOverlap;
            result.Greediness = Greediness;
            result.ScaleMin = ScaleMin;
            result.ScaleMax = ScaleMax;
            result.SubPixel = SubPixel;
            result.Area_Col1 = Area_Col1;
            result.Area_Row1 = Area_Row1;
            result.Area_Col2 = Area_Col2;
            result.Area_Row2 = Area_Row2;
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                AngleStart = ini.ReadFloat(tmp_section, "AngleStart", -0.2);
                AngleExtent = ini.ReadFloat(tmp_section, "AngleExtent", 0.39);
                MinScore = ini.ReadFloat(tmp_section, "MinScore", 0.7);
                NumMatches = ini.ReadInteger(tmp_section, "NumMatches", 1);
                MaxOverlap = ini.ReadFloat(tmp_section, "MaxOverlap", 1.0);
                SubPixel = ini.ReadString(tmp_section, "SubPixel", "none");
                NumLevels = ini.ReadInteger(tmp_section, "NumLevels", 0);
                Greediness = ini.ReadFloat(tmp_section, "Greediness", 0.0);
                ScaleMin = ini.ReadFloat(tmp_section, "ScaleMin", 1.0);
                ScaleMax = ini.ReadFloat(tmp_section, "ScaleMax", 1.0);

                Area_Col1 = ini.ReadFloat(tmp_section, "Area_Col1", 0);
                Area_Row1 = ini.ReadFloat(tmp_section, "Area_Row1", 0);
                Area_Col2 = ini.ReadFloat(tmp_section, "Area_Col2", 0);
                Area_Row2 = ini.ReadFloat(tmp_section, "Area_Row2", 0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteFloat(tmp_section, "AngleStart", AngleStart);
                ini.WriteFloat(tmp_section, "AngleExtent", AngleExtent);
                ini.WriteFloat(tmp_section, "MinScore", MinScore);
                ini.WriteInteger(tmp_section, "NumMatches", NumMatches);
                ini.WriteFloat(tmp_section, "MaxOverlap", MaxOverlap);
                ini.WriteString(tmp_section, "SubPixel", SubPixel);
                ini.WriteInteger(tmp_section, "NumLevels", NumLevels);
                ini.WriteFloat(tmp_section, "Greediness", Greediness);
                ini.WriteFloat(tmp_section, "ScaleMin", ScaleMin);
                ini.WriteFloat(tmp_section, "ScaleMax", ScaleMax);

                ini.WriteFloat(tmp_section, "Area_Col1", Area_Col1);
                ini.WriteFloat(tmp_section, "Area_Row1", Area_Row1);
                ini.WriteFloat(tmp_section, "Area_Col2", Area_Col2);
                ini.WriteFloat(tmp_section, "Area_Row2", Area_Row2);
            }
            return true;
        }
    }
}
