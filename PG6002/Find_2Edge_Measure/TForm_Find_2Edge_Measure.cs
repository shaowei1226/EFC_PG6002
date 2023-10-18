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
using EFC.Tool;
using EFC.INI;
using EFC.CAD;

namespace EFC.Vision.Halcon
{
    public enum emUsed_Image { Base, Sample };

    public partial class TForm_Find_2Edge_Measure : Form
    {
        public TFind_2Edge_Measure_Param Param = new TFind_2Edge_Measure_Param();
        public TFind_2Edge_Measure_Result Result = new TFind_2Edge_Measure_Result();
        public int Step = 0;
        public TFrame_JJS_HW JJS_HW;
        private HImage In_Image = new HImage();
        public emUsed_Image Used_Image = emUsed_Image.Base;


        public double Image_Width
        {
            get
            {
                int w = 0, h = 0;
                HImage image = Get_Image();
                if (JJS_Vision.Is_Not_Empty(image)) image.GetImageSize(out w, out h);
                return w;
            }
        }
        public double Image_Height
        {
            get
            {
                int w = 0, h = 0;
                HImage image = Get_Image();
                if (JJS_Vision.Is_Not_Empty(image)) image.GetImageSize(out w, out h);
                return h;
            }
        }
        public TForm_Find_2Edge_Measure()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            JJS_HW.Init();
        }
        public void Set_Param(TFind_2Edge_Measure_Param param)
        {
            Param.Set(param);
            E_Edge1_Rect_Row.Text = string.Format("{0:f3}", Param.Edge1_Rect.Row);
            E_Edge1_Rect_Col.Text = string.Format("{0:f3}", Param.Edge1_Rect.Col);
            E_Edge1_Rect_Phi.Text = string.Format("{0:f3}", Param.Edge1_Rect.Phi);
            E_Edge1_Rect_Len1.Text = string.Format("{0:f3}", Param.Edge1_Rect.Len1);
            E_Edge1_Rect_Len2.Text = string.Format("{0:f3}", Param.Edge1_Rect.Len2);

            CB_Sigma.Text = string.Format("{0:f1}", Param.Sigma);
            CB_Threshold.Text = string.Format("{0:d}", Param.Threshold);
            CB_Transition.Text = Param.Transition;
            CB_Select.Text = Param.Select;
            E_Point_Count.Text = string.Format("{0:d}", Param.Point_Count);
            Result.Edge1_Rect = Param.Edge1_Rect;

            E_Base_X.Text = Param.Base_X.ToString("0.000");
            E_Base_Y.Text = Param.Base_Y.ToString("0.000");
            E_Ofs_X.Text = Param.Ofs_X.ToString("0.000");
            E_Ofs_Y.Text = Param.Ofs_Y.ToString("0.000");

            CB_Switch.Checked = Param.SW;
            E_Value_Min.Text = Param.Limit_Min.ToString("0.000");
            E_Value_Max.Text = Param.Limit_Max.ToString("0.000");
        }
        public void Set_Param(TFind_2Edge_Measure_Param param, HImage image = null)
        {
            Used_Image = emUsed_Image.Sample;
            JJS_Vision.Copy_Obj(image, ref In_Image);
            Set_Param(param);
        }
        public void Update_Param()
        {
            try
            {
                Param.Edge1_Rect.Row = Convert.ToDouble(E_Edge1_Rect_Row.Text);
                Param.Edge1_Rect.Col = Convert.ToDouble(E_Edge1_Rect_Col.Text);
                Param.Edge1_Rect.Phi = Convert.ToDouble(E_Edge1_Rect_Phi.Text);
                Param.Edge1_Rect.Len1 = Convert.ToDouble(E_Edge1_Rect_Len1.Text);
                Param.Edge1_Rect.Len2 = Convert.ToDouble(E_Edge1_Rect_Len2.Text);

                Param.Sigma = Convert.ToDouble(CB_Sigma.Text);
                Param.Threshold = Convert.ToInt32(CB_Threshold.Text);
                Param.Transition = CB_Transition.Text;
                Param.Select = CB_Select.Text;
                Param.Point_Count = Convert.ToInt32(E_Point_Count.Text);
                Result.Edge1_Rect = Param.Edge1_Rect;

                Param.SW = CB_Switch.Checked;
                Param.Limit_Min = Convert.ToDouble(E_Value_Min.Text);
                Param.Limit_Max = Convert.ToDouble(E_Value_Max.Text);
            }
            catch { };
        }
        private void Form_Find_Edge_1_Shown(object sender, EventArgs e)
        {
            HImage tmp_image = Param.Sor_Image_Ptr;

            WindowState = FormWindowState.Maximized;
            JJS_HW.SetPart(tmp_image);
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            JJS_HW.Copy_HW();
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

        private void B_Edge1_Rect_Select_Click(object sender, EventArgs e)
        {
            Update_Param();
            HImage tmp_image = Get_Image();
            stRectangle2 rect = Get_Edge1_Rect();

            JJS_HW.Mode = emJJS_HW_Mode.None;
            JJS_HW.HW.Focus();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            JJS_HW.Copy_HW();

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.DrawRectangle2(out rect.Row, out rect.Col, out rect.Phi, out rect.Len1, out rect.Len2);
            Set_Edge1_Rect(rect);

            Set_Param(Param);
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            JJS_Vision.Display_Rectangle2(JJS_HW.HW_Buf, rect, "red");
            JJS_HW.Copy_HW();
        }
        private void B_Edge1_Rect_Edit_Click(object sender, EventArgs e)
        {
            HImage tmp_image = Get_Image();
            stRectangle2 rect = Get_Edge1_Rect();

            Update_Param();
            JJS_HW.HW.Focus();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            JJS_HW.Copy_HW();

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.DrawRectangle2Mod(rect.Row, rect.Col, rect.Phi, rect.Len1, rect.Len2,
                                                     out rect.Row, out rect.Col, out rect.Phi, out rect.Len1, out rect.Len2);
            Set_Edge1_Rect(rect);
            Set_Param(Param);
            JJS_Vision.Display_Rectangle2(JJS_HW.HW_Buf, rect, "red");
            JJS_HW.Copy_HW();
        }
        private void B_Edge2_Rect_Select_Click(object sender, EventArgs e)
        {
            Update_Param();
            HImage tmp_image = Get_Image();
            stRectangle2 rect = Get_Edge2_Rect();

            JJS_HW.Mode = emJJS_HW_Mode.None;
            JJS_HW.HW.Focus();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            JJS_HW.Copy_HW();

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.DrawRectangle2(out rect.Row, out rect.Col, out rect.Phi, out rect.Len1, out rect.Len2);
            Set_Edge2_Rect(rect);

            Set_Param(Param);
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            JJS_Vision.Display_Rectangle2(JJS_HW.HW_Buf, rect, "red");
            JJS_HW.Copy_HW();
        }
        private void B_Edge2_Rect_Edit_Click(object sender, EventArgs e)
        {
            HImage tmp_image = Get_Image();
            stRectangle2 rect = Get_Edge2_Rect();

            Update_Param();
            JJS_HW.HW.Focus();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            JJS_HW.Copy_HW();

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.DrawRectangle2Mod(rect.Row, rect.Col, rect.Phi, rect.Len1, rect.Len2,
                                                     out rect.Row, out rect.Col, out rect.Phi, out rect.Len1, out rect.Len2);
            Set_Edge2_Rect(rect);
            Set_Param(Param);
            JJS_Vision.Display_Rectangle2(JJS_HW.HW_Buf, rect, "red");
            JJS_HW.Copy_HW();
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
        public void Disp_Image(HWindowControl hw, HImage image)
        {
            if (JJS_Vision.Is_Not_Empty(image))
            {
                image.DispObj(hw.HalconWindow);
            }
        }
        public HImage Get_Image()
        {
            HImage result = null;
            if (Used_Image == emUsed_Image.Base) result = Param.Sor_Image_Ptr;
            if (Used_Image == emUsed_Image.Sample) result = In_Image;
            return result;
        }
        public TJJS_Point Get_Base()
        {
            TJJS_Point result = new TJJS_Point();

            result = new TJJS_Point(Param.Base_X, Param.Base_Y);
            if (Used_Image == emUsed_Image.Sample)
            {
                result.X = result.X + Param.Ofs_X;
                result.Y = result.Y + Param.Ofs_Y;
            }
            return result;
        }
        public stRectangle2 Get_Edge1_Rect()
        {
            stRectangle2 result = new stRectangle2();

            result = Param.Edge1_Rect;
            if (Used_Image == emUsed_Image.Sample) result = Param.Edge1_Rect_Ofs;
            return result;
        }
        public stRectangle2 Get_Edge2_Rect()
        {
            stRectangle2 result = new stRectangle2();

            result = Param.Edge2_Rect;
            if (Used_Image == emUsed_Image.Sample) result = Param.Edge2_Rect_Ofs;
            return result;
        }
        public void Set_Edge1_Rect(stRectangle2 rect)
        {
            Param.Edge1_Rect = rect;
            if (Used_Image == emUsed_Image.Sample)
            {
                Param.Edge1_Rect.Col = Param.Edge1_Rect.Col - Param.Ofs_X;
                Param.Edge1_Rect.Row = Param.Edge1_Rect.Row - Param.Ofs_Y;
            }
        }
        public void Set_Edge2_Rect(stRectangle2 rect)
        {
            Param.Edge2_Rect = rect;
            if (Used_Image == emUsed_Image.Sample)
            {
                Param.Edge2_Rect.Col = Param.Edge2_Rect.Col - Param.Ofs_X;
                Param.Edge2_Rect.Row = Param.Edge2_Rect.Row - Param.Ofs_Y;
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();
            double scale = (double)Image_Width / JJS_HW.HW.Width;
            HImage tmp_image = null;
            TJJS_Point base_point = new TJJS_Point();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                tmp_image = Get_Image();
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                Disp_Image(JJS_HW.HW_Buf, tmp_image);

                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(10);
                base_point = Get_Base();
                JJS_Vision.Display_Hairline(JJS_HW.HW_Buf, base_point.X, base_point.Y, 20 * scale, 0, emSetColor.yellow);


                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    Result.Disp_Param.Line_Width = 2 * scale;
                    JJS_HW.HW_Buf.HalconWindow.SetLineWidth((int)Result.Disp_Param.Line_Width);
                    JJS_Vision.Display_Rectangle2(JJS_HW.HW_Buf, Get_Edge1_Rect(), "red");
                    JJS_Vision.Display_Rectangle2(JJS_HW.HW_Buf, Get_Edge2_Rect(), "red");
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    if (Used_Image == emUsed_Image.Base) Param.Find(tmp_image, ref Result, false);
                    if (Used_Image == emUsed_Image.Sample) Param.Find(tmp_image, ref Result, true);
                    
                    Result.Disp_Param.Line_Width = 2 * scale;
                    JJS_HW.HW_Buf.HalconWindow.SetLineWidth((int)Result.Disp_Param.Line_Width);
                    if (Step == 2) Result.Disp_Point(JJS_HW.HW_Buf, 15 * scale, "green");
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        Result.Disp_Rect(JJS_HW.HW_Buf, "red");
                        if (CB_Disp_Point.Checked) Result.Disp_Point(JJS_HW.HW_Buf, 15 * scale, "green");
                        if (CB_Disp_Line.Checked)
                        {
                            Result.Disp_Line(JJS_HW.HW_Buf, "blue");
                        }
                        E_Value_Now.Text = Result.Dist.ToString("0.000");
                    }
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
        private void B_Get_Point_Click(object sender, EventArgs e)
        {
            Update_Param();
            HImage tmp_image = Get_Image();

            Param.Get_Point(tmp_image, ref Result);

            JJS_HW.Mode = emJJS_HW_Mode.None;
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            Result.Disp_Rect(JJS_HW.HW_Buf, "red");
            Result.Disp_Point(JJS_HW.HW_Buf, 15, "green");
            JJS_HW.Copy_HW();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            HImage tmp_image = Get_Image();

            Result.Update_Line();

            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Image(JJS_HW.HW_Buf, tmp_image);
            Result.Disp_Rect(JJS_HW.HW_Buf, "red");
            if (CB_Disp_Point.Checked) Result.Disp_Point(JJS_HW.HW_Buf, 15, "green");
            if (CB_Disp_Line.Checked) Result.Disp_Line(JJS_HW.HW_Buf, "blue");
            JJS_HW.Copy_HW();
        }
        private void B_Finish_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Used_In_Image_Click(object sender, EventArgs e)
        {
            if (JJS_Vision.Is_Not_Empty(In_Image))
            {
                B_Used_In_Image.BackColor = Color.PaleTurquoise;
                B_Used_Sor_Image.BackColor = Color.Transparent;
                Used_Image = emUsed_Image.Sample;
                Update_View();
            }
        }
        private void B_Used_Sor_Image_Click(object sender, EventArgs e)
        {
            if (JJS_Vision.Is_Not_Empty(Param.Sor_Image_Ptr))
            {
                B_Used_Sor_Image.BackColor = Color.PaleTurquoise;
                B_Used_In_Image.BackColor = Color.Transparent;
                Used_Image = emUsed_Image.Base;
                Update_View();
            }
        }

        private void tFrame_JJS_HW1_JJS_HW_Reflash(TFrame_JJS_HW jjs_hw)
        {
            Update_View();
        }

    }
    public class TFind_2Edge_Measure_Param : TBase_Param
    {
        public int             Point_Count;
        public double          Sigma;
        public int             Threshold;
        public string          Transition;
        public string          Select;
        public stRectangle2    Edge1_Rect = new stRectangle2();
        public stRectangle2    Edge2_Rect = new stRectangle2();
        public double          Base_X;
        public double          Base_Y;
        public double          Ofs_X;
        public double          Ofs_Y;

        public bool            SW;
        public double          Limit_Min;
        public double          Limit_Max;
        public double          Pixel_Size = 1;

        public HImage          Sor_Image_Ptr = null;

        public stRectangle2 Edge1_Rect_Ofs
        {
            get
            {
                stRectangle2 result = new stRectangle2();
                result = Edge1_Rect;
                result.Col = result.Col + Ofs_X;
                result.Row = result.Row + Ofs_Y;
                return result;
            }
        }
        public stRectangle2 Edge2_Rect_Ofs
        {
            get
            {
                stRectangle2 result = new stRectangle2();
                result = Edge2_Rect;
                result.Col = result.Col + Ofs_X;
                result.Row = result.Row + Ofs_Y;
                return result;
            }
        }
        public TJJS_Point Base_Ofs
        {
            get
            {
                TJJS_Point result = new TJJS_Point();

                result = new TJJS_Point(Base_X, Base_Y);
                result = result + new TJJS_Point(Ofs_X, Ofs_Y);
                return result;
            }
        }
        public TFind_2Edge_Measure_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Param result = new TFind_2Edge_Measure_Param();
            return result;
        }
        override public TBase_Result New_Base_Result()
        {
            TBase_Result result = new TFind_2Edge_Measure_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_2Edge_Measure_Param && dis_base is TFind_2Edge_Measure_Param)
            {
                TFind_2Edge_Measure_Param sor = (TFind_2Edge_Measure_Param)sor_base;
                TFind_2Edge_Measure_Param dis = (TFind_2Edge_Measure_Param)dis_base;
                base.Copy(sor, dis);

                dis.Point_Count = sor.Point_Count;
                dis.Sigma = sor.Sigma;
                dis.Threshold = sor.Threshold;
                dis.Transition = sor.Transition;
                dis.Select = sor.Select;
                dis.Edge1_Rect = sor.Edge1_Rect;
                dis.Edge2_Rect = sor.Edge2_Rect;

                dis.Base_X = sor.Base_X;
                dis.Base_Y = sor.Base_Y;
                dis.Ofs_X = sor.Ofs_X;
                dis.Ofs_Y = sor.Ofs_Y;
                dis.SW = sor.SW;
                dis.Limit_Min = sor.Limit_Min;
                dis.Limit_Max = sor.Limit_Max;
                dis.Pixel_Size = sor.Pixel_Size;

                dis.Sor_Image_Ptr = sor.Sor_Image_Ptr;
            }
        }
        override public void Set_Default()
        {
            Point_Count = 20;
            Sigma = 1;
            Threshold = 30;
            Transition = "all";
            Select = "first";

            Edge1_Rect.Row = 0;
            Edge1_Rect.Col = 0;
            Edge1_Rect.Phi = 0;
            Edge1_Rect.Len1 = 10;
            Edge1_Rect.Len2 = 20;

            Edge2_Rect.Row = 0;
            Edge2_Rect.Col = 0;
            Edge2_Rect.Phi = 0;
            Edge2_Rect.Len1 = 10;
            Edge2_Rect.Len2 = 20;

            Base_X = 0;
            Base_Y = 0;
            Ofs_X = 0;
            Ofs_Y = 0;
            SW = true;
            Limit_Min = 0;
            Limit_Max = 0;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                Point_Count = ini.ReadInteger(tmp_section, "Point_Count", Point_Count);
                Sigma = ini.ReadFloat(tmp_section, "Sigma", Sigma);
                Threshold = ini.ReadInteger(tmp_section, "Threshold", Threshold);
                Transition = ini.ReadString(tmp_section, "Transition", Transition);
                Select = ini.ReadString(tmp_section, "Select", Select);

                tmp_section = section + "/Edge1_Rect";
                Edge1_Rect.Col = ini.ReadFloat(tmp_section, "Col", Edge1_Rect.Col);
                Edge1_Rect.Row = ini.ReadFloat(tmp_section, "Row", Edge1_Rect.Row);
                Edge1_Rect.Phi = ini.ReadFloat(tmp_section, "Phi", Edge1_Rect.Phi);
                Edge1_Rect.Len1 = ini.ReadFloat(tmp_section, "Len1", Edge1_Rect.Len1);
                Edge1_Rect.Len2 = ini.ReadFloat(tmp_section, "Len2", Edge1_Rect.Len2);

                tmp_section = section + "/Edge2_Rect";
                Edge2_Rect.Col = ini.ReadFloat(tmp_section, "Col", Edge2_Rect.Col);
                Edge2_Rect.Row = ini.ReadFloat(tmp_section, "Row", Edge2_Rect.Row);
                Edge2_Rect.Phi = ini.ReadFloat(tmp_section, "Phi", Edge2_Rect.Phi);
                Edge2_Rect.Len1 = ini.ReadFloat(tmp_section, "Len1", Edge2_Rect.Len1);
                Edge2_Rect.Len2 = ini.ReadFloat(tmp_section, "Len2", Edge2_Rect.Len2);

                Base_X = ini.ReadFloat(tmp_section, "Base_X", Base_X);
                Base_Y = ini.ReadFloat(tmp_section, "Base_Y", Base_Y);
                SW = ini.ReadBool(tmp_section, "SW", SW);
                Limit_Min = ini.ReadFloat(tmp_section, "Limit_Min", Limit_Min);
                Limit_Max = ini.ReadFloat(tmp_section, "Limit_Max", Limit_Max);
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);

                ini.WriteInteger(tmp_section, "Point_Count", Point_Count);
                ini.WriteFloat(tmp_section, "Sigma", Sigma);
                ini.WriteInteger(tmp_section, "Threshold", Threshold);
                ini.WriteString(tmp_section, "Transition", Transition);
                ini.WriteString(tmp_section, "Select", Select);

                tmp_section = section + "/Edge1_Rect";
                ini.WriteFloat(tmp_section, "Col", Edge1_Rect.Col);
                ini.WriteFloat(tmp_section, "Row", Edge1_Rect.Row);
                ini.WriteFloat(tmp_section, "Phi", Edge1_Rect.Phi);
                ini.WriteFloat(tmp_section, "Len1", Edge1_Rect.Len1);
                ini.WriteFloat(tmp_section, "Len2", Edge1_Rect.Len2);

                tmp_section = section + "/Edge2_Rect";
                ini.WriteFloat(tmp_section, "Col", Edge2_Rect.Col);
                ini.WriteFloat(tmp_section, "Row", Edge2_Rect.Row);
                ini.WriteFloat(tmp_section, "Phi", Edge2_Rect.Phi);
                ini.WriteFloat(tmp_section, "Len1", Edge2_Rect.Len1);
                ini.WriteFloat(tmp_section, "Len2", Edge2_Rect.Len2);

                ini.WriteFloat(tmp_section, "Base_X", Base_X);
                ini.WriteFloat(tmp_section, "Base_Y", Base_Y);
                ini.WriteBool(tmp_section, "SW", SW);
                ini.WriteFloat(tmp_section, "Limit_Min", Limit_Min);
                ini.WriteFloat(tmp_section, "Limit_Max", Limit_Max);
            }
        }
        override public void Read_Other_File()
        {
        }
        override public void Write_Other_File()
        {
        }
        override public bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Find_2Edge_Measure form = new TForm_Find_2Edge_Measure();
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

            if (f_result is TFind_2Edge_Measure_Result)
            {
                TFind_2Edge_Measure_Result in_result = (TFind_2Edge_Measure_Result)f_result;
                result = Find(image, ref in_result);
            }

            return result;
        }
        public bool Find_Base(HImage image, ref TFind_2Edge_Measure_Result f_result)
        {
            bool result = false;

            result = Find(image, ref f_result);
            return result;
        }
        public void Log_Diff(TLog log, string section, TFind_2Edge_Measure_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Point_Count", Point_Count, new_value.Point_Count, ref flag);
            log.Log_Diff(section + "/Sigma", Sigma, new_value.Sigma, ref flag);
            log.Log_Diff(section + "/Threshold", Threshold, new_value.Threshold, ref flag);
            log.Log_Diff(section + "/Transition", Transition, new_value.Transition, ref flag);
            log.Log_Diff(section + "/Select", Select, new_value.Select, ref flag);

            log.Log_Diff(section + "/Rect.Col", Edge1_Rect.Col, new_value.Edge1_Rect.Col, ref flag);
            log.Log_Diff(section + "/Rect.Row", Edge1_Rect.Row, new_value.Edge1_Rect.Row, ref flag);
            log.Log_Diff(section + "/Rect.Len1", Edge1_Rect.Len1, new_value.Edge1_Rect.Len1, ref flag);
            log.Log_Diff(section + "/Rect.Len2", Edge1_Rect.Len2, new_value.Edge1_Rect.Len2, ref flag);
            log.Log_Diff(section + "/Rect.Phi", Edge1_Rect.Phi, new_value.Edge1_Rect.Phi, ref flag);

            log.Log_Diff(section + "/Base_X", Base_X, new_value.Base_X, ref flag);
            log.Log_Diff(section + "/Base_Y", Base_Y, new_value.Base_Y, ref flag);
            log.Log_Diff(section + "/SW", SW, new_value.SW, ref flag);
            log.Log_Diff(section + "/Limit_Min", Limit_Min, new_value.Limit_Min, ref flag);
            log.Log_Diff(section + "/Limit_Max", Limit_Max, new_value.Limit_Max, ref flag);
        }

        public bool Find(HImage image, ref TFind_2Edge_Measure_Result result, bool ofs_flag = true)
        {
            double dist = 0;
            if (image != null)
            {
                result.Reset();
                Get_Point(image, ref result, ofs_flag);
                result.Update_Line();
                if (result.Edge1_XLD_Point_Count >= 3 && result.Edge2_XLD_Point_Count >= 3) result.Find_OK = true;
                if (result.Find_OK && SW)
                {
                    dist = result.Edge1_Line.Dist(result.Edge2_Line.Mid) * Pixel_Size;
                    result.Dist= dist;
                    if (dist < Limit_Min) result.Find_OK = false;
                    if (dist > Limit_Max) result.Find_OK = false;
                }
            }

            return result.Find_OK;
        }
        public void Get_Point(HImage image, ref TFind_2Edge_Measure_Result result, bool ofs_flag = true)
        {
            stRectangle2 tmp_rect = new stRectangle2();

            if (ofs_flag) tmp_rect = Edge1_Rect_Ofs;
            else tmp_rect = Edge1_Rect;
            result.Edge1_Rect = tmp_rect;
            Get_Point(image, tmp_rect, ref result.Edge1_XLD_Point);

            if (ofs_flag) tmp_rect = Edge2_Rect_Ofs;
            else tmp_rect = Edge2_Rect;
            result.Edge2_Rect = tmp_rect;
            Get_Point(image, tmp_rect, ref result.Edge2_XLD_Point);
        }
        public void Get_Point(HImage image, stRectangle2 rect, ref stXLD_Pos[] pos)
        {
            HMeasure measure = new HMeasure();
            HTuple row_Edge = new HTuple();
            HTuple col_Edge = new HTuple();
            HTuple amplitude = new HTuple();
            HTuple distance = new HTuple();
            stRectangle2[] rects = null;
            int w = 0, h = 0;
            int point_no = 0;

            image.GetImageSize(out w, out h);
            rects = Break_Rectangle2(rect, Point_Count);
            Array.Resize(ref pos, rects.Length);
            for (int i = 0; i < rects.Length; i++)
            {
                pos[i] = new stXLD_Pos();
                try
                {
                    measure.GenMeasureRectangle2(rects[i].Row, rects[i].Col, rects[i].Phi, rects[i].Len1, rects[i].Len2, w, h, "nearest_neighbor");
                    measure.MeasurePos(image, Sigma, Threshold, Transition, Select, out row_Edge, out col_Edge, out amplitude, out distance);

                    if (col_Edge.Length > 0)
                    {
                        pos[point_no].Col = col_Edge;
                        pos[point_no].Row = row_Edge;
                        point_no++;
                    }
                }
                catch
                {

                }
            }
            Array.Resize(ref pos, point_no);
        }
        public stRectangle2[] Break_Rectangle2(stRectangle2 rect, int count)
        {
            stRectangle2[] result = new stRectangle2[count];

            TJJS_Line l1 = new TJJS_Line();
            TJJS_Point p = new TJJS_Point();
            TJJS_Angle ang = new TJJS_Angle();
            double dx, dy;

            l1.Start = new TJJS_Point(rect.Col - rect.Len2, rect.Row);
            l1.End = new TJJS_Point(rect.Col + rect.Len2, rect.Row);
            ang.r = rect.Phi;
            l1 = l1.Rotate(l1.Mid, -(ang.d - 90));

            dx = (l1.End.X - l1.Start.X) / (Point_Count - 1);
            dy = (l1.End.Y - l1.Start.Y) / (Point_Count - 1);
            for (int i = 0; i < Point_Count; i++)
            {
                p.X = l1.Start.X + dx * i;
                p.Y = l1.Start.Y + dy * i;

                result[i].Set(p.Y, p.X, rect.Len1, 5, rect.Phi);
            }
            return result;
        }
        public void Set_Base(double base_x, double base_y)
        {
            Base_X = base_x;
            Base_Y = base_y;
        }
        public void Set_Ofs(double sample_x, double sample_y)
        {
            Ofs_X = sample_x - Base_X;
            Ofs_Y = sample_y - Base_Y;
        }
    }
    public class TFind_2Edge_Measure_Result : TBase_Result
    {
        public stXLD_Pos[]             Edge1_XLD_Point = new stXLD_Pos[0];
        public TJJS_Line               Edge1_Line = new TJJS_Line();
        public stRectangle2            Edge1_Rect = new stRectangle2();
        public stXLD_Pos[]             Edge2_XLD_Point = new stXLD_Pos[0];
        public TJJS_Line               Edge2_Line = new TJJS_Line();
        public stRectangle2            Edge2_Rect = new stRectangle2();
        public double                  Dist = 0;

        public TFind_2Edge_Measure_Disp_Param Disp_Param = new TFind_2Edge_Measure_Disp_Param();

        public int Edge1_XLD_Point_Count
        {
            get
            {
                return Edge1_XLD_Point.Length;
            }
            set
            {
                int old_count;

                old_count = Edge1_XLD_Point.Length;
                Array.Resize(ref Edge1_XLD_Point, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Edge1_XLD_Point[i] = new stXLD_Pos();
                }
            }
        }
        public int Edge2_XLD_Point_Count
        {
            get
            {
                return Edge2_XLD_Point.Length;
            }
            set
            {
                int old_count;

                old_count = Edge2_XLD_Point.Length;
                Array.Resize(ref Edge2_XLD_Point, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Edge2_XLD_Point[i] = new stXLD_Pos();
                }
            }
        }
        public TFind_2Edge_Measure_Result()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Result result = new TFind_2Edge_Measure_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_2Edge_Measure_Result && dis_base is TFind_2Edge_Measure_Result)
            {
                TFind_2Edge_Measure_Result sor = (TFind_2Edge_Measure_Result)sor_base;
                TFind_2Edge_Measure_Result dis = (TFind_2Edge_Measure_Result)dis_base;
                base.Copy(sor, dis);

                dis.Edge1_XLD_Point_Count = sor.Edge1_XLD_Point_Count;
                for (int i = 0; i < sor.Edge1_XLD_Point_Count; i++) dis.Edge1_XLD_Point[i] = sor.Edge1_XLD_Point[i];
                dis.Edge1_Line.Set(sor.Edge1_Line);
                dis.Edge1_Rect = sor.Edge1_Rect;

                dis.Edge2_XLD_Point_Count = sor.Edge2_XLD_Point_Count;
                for (int i = 0; i < sor.Edge2_XLD_Point_Count; i++) dis.Edge2_XLD_Point[i] = sor.Edge2_XLD_Point[i];
                dis.Edge2_Line.Set(sor.Edge2_Line);
                dis.Edge2_Rect = sor.Edge2_Rect;

                dis.Disp_Param.Set(sor.Disp_Param);
            }
        }
        override public void Reset()
        {
            Find_OK = false;

            Edge1_XLD_Point_Count = 0;
            Edge1_Line.Set(0, 0, 0, 0);
            Edge1_Rect.Set(0, 0, 0, 0);

            Edge2_XLD_Point_Count = 0;
            Edge2_Line.Set(0, 0, 0, 0);
            Edge2_Rect.Set(0, 0, 0, 0);
        }
        override public void Set_Default()
        {
            base.Set_Default();
            Find_OK = false;

            Edge1_XLD_Point_Count = 0;
            Edge1_Line.Set(0, 0, 0, 0);
            Edge1_Rect.Set(0, 0, 0, 0);

            Edge2_XLD_Point_Count = 0;
            Edge2_Line.Set(0, 0, 0, 0);
            Edge2_Rect.Set(0, 0, 0, 0);

            Disp_Param.Set_Default();
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Find_OK = ini.ReadBool(tmp_section, "Find_Ok", false);
                Disp_Param.Read(ini, "/Disp_Param");
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteBool(tmp_section, "Find_Ok", Find_OK);
                Disp_Param.Write(ini, "/Disp_Param");
            }
        }
        override public void Display_Message(HWindowControl hw)
        {
            string color;

            if (Find_OK) color = Disp_Param.Msg_Color_OK;
            else color = Disp_Param.Msg_Color_NG;

            JJS_Vision.Display_String(hw, Get_Message(), Disp_Param.Msg_X, Disp_Param.Msg_Y, Disp_Param.Msg_Font_Size, color);
        }
        override public void Display_Model(HWindowControl hw)
        {
            string color;

            if (Find_OK) color = Disp_Param.Model_Color_OK;
            else color = Disp_Param.Model_Color_NG;

            //if (Find_OK)
            {
                if (Disp_Param.Disp_Rect_Flag) Disp_Rect(hw, Disp_Param.Rect_Color);
                if (Disp_Param.Disp_Point_Flag) Disp_Point(hw, Disp_Param.Point_Size, Disp_Param.Point_Color);

                if (Disp_Param.Disp_Line_Flag) Disp_Line(hw, color);

                //hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
                //JJS_Vision.Display_Hairline(hw, Col, Row, Disp_Param.Hairline_Size, 0, "yellow");
            }
        }
        override public string Get_Message()
        {
            string result = "";

            result = string.Format("{0:s} Dist={1:f3} {2:s}", Disp_Param.Msg_Name, Dist, Find_OK ? "OK" : "NG");
            return result;
        }

        public void Update_Line()
        {
            Update_Line(Edge1_XLD_Point, ref Edge1_Line);
            Update_Line(Edge2_XLD_Point, ref Edge2_Line);
            if (Edge1_XLD_Point_Count >= 3 && Edge2_XLD_Point_Count >= 3)
                Find_OK = true;
            else
                Find_OK = false;
        }
        public void Update_Line(stXLD_Pos[] pos, ref TJJS_Line out_line)
        {
            HXLDCont xld = new HXLDCont();
            HTuple xld_row = new HTuple();
            HTuple xld_col = new HTuple();
            double rowBegin, colBegin, rowEnd, colEnd, nr, nc, dist;

            if (pos.Length >= 3)
            {
                for (int i = 0; i < pos.Length; i++)
                {
                    xld_row.Append(pos[i].Row);
                    xld_col.Append(pos[i].Col);
                }

                xld.GenContourPolygonXld(xld_row, xld_col);
                xld.FitLineContourXld("tukey", -1, 0, 5, 2, out rowBegin, out colBegin, out rowEnd, out colEnd, out nr, out nc, out dist);
                out_line.Start = new TJJS_Point(colBegin, rowBegin);
                out_line.End = new TJJS_Point(colEnd, rowEnd);
            }
        }
        public void Disp_Rect(HWindowControl hw, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
            hw.HalconWindow.SetDraw("margin");
            hw.HalconWindow.DispRectangle2(Edge1_Rect.Row, Edge1_Rect.Col, Edge1_Rect.Phi, Edge1_Rect.Len1, Edge1_Rect.Len2);
            hw.HalconWindow.DispRectangle2(Edge2_Rect.Row, Edge2_Rect.Col, Edge2_Rect.Phi, Edge2_Rect.Len1, Edge2_Rect.Len2);
        }
        public void Disp_Point(HWindowControl hw, double size, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
            for (int i = 0; i < Edge1_XLD_Point_Count; i++)
            {
                hw.HalconWindow.DispCross(Edge1_XLD_Point[i].Row, Edge1_XLD_Point[i].Col, size, 0);
            }
            for (int i = 0; i < Edge2_XLD_Point_Count; i++)
            {
                hw.HalconWindow.DispCross(Edge2_XLD_Point[i].Row, Edge2_XLD_Point[i].Col, size, 0);
            }
        }
        public void Disp_Line(HWindowControl hw, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
            hw.HalconWindow.DispLine(Edge1_Line.Start.Y, Edge1_Line.Start.X, Edge1_Line.End.Y, Edge1_Line.End.X);
            hw.HalconWindow.DispLine(Edge2_Line.Start.Y, Edge2_Line.Start.X, Edge2_Line.End.Y, Edge2_Line.End.X);
        }
    }
    public class TFind_2Edge_Measure_Disp_Param : TBase_Disp_Param
    {
        public string                  Rect_Color,
                                       Point_Color,
                                       Line_Color;
        public double                  Point_Size;
        public bool                    Disp_Rect_Flag = true;
        public bool                    Disp_Point_Flag = false;
        public bool                    Disp_Line_Flag = true;

        public TFind_2Edge_Measure_Disp_Param()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TFind_2Edge_Measure_Disp_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_2Edge_Measure_Disp_Param && dis_base is TFind_2Edge_Measure_Disp_Param)
            {
                TFind_2Edge_Measure_Disp_Param sor = (TFind_2Edge_Measure_Disp_Param)sor_base;
                TFind_2Edge_Measure_Disp_Param dis = (TFind_2Edge_Measure_Disp_Param)dis_base;
                base.Copy(sor_base, dis_base);

                dis.Rect_Color = sor.Rect_Color;
                dis.Point_Color = sor.Point_Color;
                dis.Line_Color = sor.Line_Color;
                dis.Point_Size = sor.Point_Size;
                dis.Disp_Rect_Flag = sor.Disp_Rect_Flag;
                dis.Disp_Point_Flag = sor.Disp_Point_Flag;
                dis.Disp_Line_Flag = sor.Disp_Line_Flag;
            }
        }
        override public void Set_Default()
        {
            base.Set_Default();
            Rect_Color = emSetColor.green;
            Point_Color = emSetColor.red;
            Line_Color = emSetColor.blue;
            Point_Size = 20;
            Disp_Rect_Flag = true;
            Disp_Point_Flag = false;
            Disp_Line_Flag = true;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            base.Read(ini, section);

            Rect_Color = ini.ReadString(section, "Rect_Color", Rect_Color);
            Point_Color = ini.ReadString(section, "Point_Color", Point_Color);
            Line_Color = ini.ReadString(section, "Line_Color", Line_Color);
            Point_Size = ini.ReadFloat(section, "Point_Size", Point_Size);
            Disp_Rect_Flag = ini.ReadBool(section, "Disp_Rect_Flag", Disp_Rect_Flag);
            Disp_Point_Flag = ini.ReadBool(section, "Disp_Point_Flag", Disp_Point_Flag);
            Disp_Line_Flag = ini.ReadBool(section, "Disp_Line_Flag", Disp_Line_Flag);
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            base.Write(ini, section);

            ini.WriteString(section, "Rect_Color", Rect_Color);
            ini.WriteString(section, "Point_Color", Point_Color);
            ini.WriteString(section, "Line_Color", Line_Color);
            ini.WriteFloat(section, "Point_Size", Point_Size);
            ini.WriteBool(section, "Disp_Rect_Flag", Disp_Rect_Flag);
            ini.WriteBool(section, "Disp_Point_Flag", Disp_Point_Flag);
            ini.WriteBool(section, "Disp_Line_Flag", Disp_Line_Flag);
        }
    }
    public struct stXLD_Pos
    {
        public double Col, Row;
    }
}