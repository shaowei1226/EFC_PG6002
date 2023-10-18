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
    public partial class TForm_Find_Edge_1 : Form
    {
        public TFind_Edge_1_Param Param = new TFind_Edge_1_Param();
        public TFind_Edge_1_Result Result = new TFind_Edge_1_Result();
        public int Step = 0;
        public TFrame_JJS_HW JJS_HW;
        public int Image_Width,
                   Image_Height;
        private HImage Image = new HImage();
        private HImage In_Image = new HImage();

        public TForm_Find_Edge_1()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            JJS_HW.Init();
        }
        public void Set_Param(TFind_Edge_1_Param param)
        {
            Param.Set(param);
            E_Rect_Row.Text = string.Format("{0:f3}", Param.Rect.Row);
            E_Rect_Col.Text = string.Format("{0:f3}", Param.Rect.Col);
            E_Rect_Phi.Text = string.Format("{0:f3}", Param.Rect.Phi);
            E_Rect_Len1.Text = string.Format("{0:f3}", Param.Rect.Len1);
            E_Rect_Len2.Text = string.Format("{0:f3}", Param.Rect.Len2);

            CB_Sigma.Text = string.Format("{0:f1}", Param.Sigma);
            CB_Threshold.Text = string.Format("{0:d}", Param.Threshold);
            CB_Transition.Text = Param.Transition;
            CB_Select.Text = Param.Select;
            E_Point_Count.Text = string.Format("{0:d}", Param.Point_Count);
            Result.Rect = Param.Rect;
        }
        public void Set_Param(TFind_Edge_1_Param param, HImage image = null)
        {
            In_Image = image;
            if (JJS_Vision.Is_Not_Empty(image))
            {
                Image = In_Image.Clone();
                Image.GetImageSize(out Image_Width, out Image_Height);
            }
            Set_Param(param);
        }
        public void Update_Param()
        {
            Param.Rect.Row = Convert.ToDouble(E_Rect_Row.Text);
            Param.Rect.Col = Convert.ToDouble(E_Rect_Col.Text);
            Param.Rect.Phi = Convert.ToDouble(E_Rect_Phi.Text);
            Param.Rect.Len1 = Convert.ToDouble(E_Rect_Len1.Text);
            Param.Rect.Len2 = Convert.ToDouble(E_Rect_Len2.Text);

            Param.Sigma = Convert.ToDouble(CB_Sigma.Text);
            Param.Threshold = Convert.ToInt32(CB_Threshold.Text);
            Param.Transition = CB_Transition.Text;
            Param.Select = CB_Select.Text;
            Param.Point_Count = Convert.ToInt32(E_Point_Count.Text);
            Result.Rect = Param.Rect;
        }
        private void Form_Find_Edge_1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            JJS_HW.SetPart(Image);
            JJS_HW.HW_Buf.HalconWindow.DispObj(Image);
            JJS_HW.Copy_HW();
            JJS_HW.HW_Param.Set_Line_Width(JJS_HW.HW.Width, Image_Width, 2);
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

            JJS_HW.Mode = emJJS_HW_Mode.None;
            JJS_HW.HW.Focus();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
            JJS_HW.Copy_HW();

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.DrawRectangle2(out Param.Rect.Row, out Param.Rect.Col, out Param.Rect.Phi, out Param.Rect.Len1, out Param.Rect.Len2);


            Set_Param(Param);
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
            Result.Disp_Rect(JJS_HW.HW_Buf, "red");
            JJS_HW.Copy_HW();

            if (MessageBox.Show("覆蓋掉原始影像??", "儲存影像", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (JJS_Vision.Is_Not_Empty(Image)) Param.Sor_Image = Image.Clone();
                Param.Write_Sor_Image();
            }
        }
        private void B_Rect_Edit_Click(object sender, EventArgs e)
        {
            Update_Param();
            JJS_HW.HW.Focus();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
            JJS_HW.Copy_HW();

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.DrawRectangle2Mod(Param.Rect.Row, Param.Rect.Col, Param.Rect.Phi, Param.Rect.Len1, Param.Rect.Len2,
                                                     out Param.Rect.Row, out Param.Rect.Col, out Param.Rect.Phi, out Param.Rect.Len1, out Param.Rect.Len2);

            Set_Param(Param);
            Result.Disp_Rect(JJS_HW.HW_Buf, "red");
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
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();
            double scale = (double)Image_Width / JJS_HW.HW.Width;


            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                Image.DispObj(JJS_HW.HW_Buf.HalconWindow);

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    JJS_Vision.Display_Rectangle2(JJS_HW.HW_Buf, Param.Rect, "red");
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    Param.Find(Image, ref Result);
                    Result.Disp_Param.Line_Width = 2 * scale;

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

            Param.Get_Point(Image, ref Result);

            JJS_HW.Mode = emJJS_HW_Mode.None;
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
            Result.Disp_Rect(JJS_HW.HW_Buf, "red");
            Result.Disp_Point(JJS_HW.HW_Buf, 15, "green");
            JJS_HW.Copy_HW();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Result.Update_Line();

            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
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
                Image = In_Image.Clone();
                Image.GetImageSize(out Image_Width, out Image_Height);
                Update_View();
            }
        }
        private void B_Used_Sor_Image_Click(object sender, EventArgs e)
        {
            if (JJS_Vision.Is_Not_Empty(Param.Sor_Image))
            {
                B_Used_Sor_Image.BackColor = Color.PaleTurquoise;
                B_Used_In_Image.BackColor = Color.Transparent;
                Image = Param.Sor_Image.Clone();
                Image.GetImageSize(out Image_Width, out Image_Height);
                Update_View();
            }
        }

        private void tFrame_JJS_HW1_JJS_HW_Reflash(TFrame_JJS_HW jjs_hw)
        {
            Update_View();
        }
    }
    public class TFind_Edge_1_Param : TBase_Param
    {
        public int             Point_Count;
        public double          Sigma;
        public int             Threshold;
        public string          Transition;
        public string          Select;
        public stRectangle2    Rect = new stRectangle2();
        public HImage          Sor_Image = new HImage();
        public string          Sor_Image_File_Name = "Sor_Image.bmp";

        public TFind_Edge_1_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Param result = new TFind_Edge_1_Param();
            return result;
        }
        override public TBase_Result New_Base_Result()
        {
            TBase_Result result = new TFind_Edge_1_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Edge_1_Param && dis_base is TFind_Edge_1_Param)
            {
                TFind_Edge_1_Param sor = (TFind_Edge_1_Param)sor_base;
                TFind_Edge_1_Param dis = (TFind_Edge_1_Param)dis_base;
                base.Copy(sor, dis);

                dis.Point_Count = sor.Point_Count;
                dis.Sigma = sor.Sigma;
                dis.Threshold = sor.Threshold;
                dis.Transition = sor.Transition;
                dis.Select = sor.Select;
                dis.Rect = sor.Rect;
                if (JJS_Vision.Is_Not_Empty(sor.Sor_Image)) dis.Sor_Image = sor.Sor_Image.Clone();
                dis.Sor_Image_File_Name = sor.Sor_Image_File_Name;
            }
        }
        override public void Set_Default()
        {
            Point_Count = 20;
            Sigma = 1;
            Threshold = 30;
            Transition = "all";
            Select = "first";
            Rect.Row = 0;
            Rect.Col = 0;
            Rect.Phi = 0;
            Rect.Len1 = 10;
            Rect.Len2 = 20;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                Point_Count = ini.ReadInteger(tmp_section, "Point_Count", 20);
                Sigma = ini.ReadFloat(tmp_section, "Sigma", 20);
                Threshold = ini.ReadInteger(tmp_section, "Threshold", 20);
                Transition = ini.ReadString(tmp_section, "Transition", "all");
                Select = ini.ReadString(tmp_section, "Select", "first");

                tmp_section = section + "//Rect";
                Rect.Col = ini.ReadFloat(tmp_section, "Col", 0.0);
                Rect.Row = ini.ReadFloat(tmp_section, "Row", 0.0);
                Rect.Phi = ini.ReadFloat(tmp_section, "Phi", 0.0);
                Rect.Len1 = ini.ReadFloat(tmp_section, "Len1", 0.0);
                Rect.Len2 = ini.ReadFloat(tmp_section, "Len2", 0.0);
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

                tmp_section = section + "//Rect";
                ini.WriteFloat(tmp_section, "Col", Rect.Col);
                ini.WriteFloat(tmp_section, "Row", Rect.Row);
                ini.WriteFloat(tmp_section, "Phi", Rect.Phi);
                ini.WriteFloat(tmp_section, "Len1", Rect.Len1);
                ini.WriteFloat(tmp_section, "Len2", Rect.Len2);
            }
        }
        override public void Read_Other_File()
        {
            string filename = Default_Path + Sor_Image_File_Name;
            if (System.IO.File.Exists(filename)) Sor_Image.ReadImage(filename);
        }
        override public void Write_Other_File()
        {
        }
        override public bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Find_Edge_1 form = new TForm_Find_Edge_1();
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

            if (f_result is TFind_Edge_1_Result)
            {
                TFind_Edge_1_Result in_result = (TFind_Edge_1_Result)f_result;
                result = Find(image, ref in_result);
            }

            return result;
        }
        public bool Find_Base(HImage image, ref TFind_Edge_1_Result f_result)
        {
            bool result = false;

            result = Find(image, ref f_result);
            return result;
        }
        public void Log_Diff(TLog log, string section, TFind_Edge_1_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Point_Count", Point_Count, new_value.Point_Count, ref flag);
            log.Log_Diff(section + "/Sigma", Sigma, new_value.Sigma, ref flag);
            log.Log_Diff(section + "/Threshold", Threshold, new_value.Threshold, ref flag);
            log.Log_Diff(section + "/Transition", Transition, new_value.Transition, ref flag);
            log.Log_Diff(section + "/Select", Select, new_value.Select, ref flag);

            log.Log_Diff(section + "/Rect.Col", Rect.Col, new_value.Rect.Col, ref flag);
            log.Log_Diff(section + "/Rect.Row", Rect.Row, new_value.Rect.Row, ref flag);
            log.Log_Diff(section + "/Rect.Len1", Rect.Len1, new_value.Rect.Len1, ref flag);
            log.Log_Diff(section + "/Rect.Len2", Rect.Len2, new_value.Rect.Len2, ref flag);
            log.Log_Diff(section + "/Rect.Phi", Rect.Phi, new_value.Rect.Phi, ref flag);
        }
        public void Write_Sor_Image()
        {
            if (JJS_Vision.Is_Not_Empty(Sor_Image))
            {
                string filename = Default_Path + Sor_Image_File_Name;
                Sor_Image.WriteImage("bmp", 1, filename);
            }
        }


        public bool Find(HImage image, ref TFind_Edge_1_Result result)
        {
            if (image != null)
            {
                result.Reset();
                Get_Point(image, ref result);
                result.Update_Line();
            }

            return result.Find_OK;
        }
        public void Get_Point(HImage image, ref TFind_Edge_1_Result result)
        {
            HMeasure measure = new HMeasure();
            HTuple row_Edge = new HTuple();
            HTuple col_Edge = new HTuple();
            HTuple amplitude = new HTuple();
            HTuple distance = new HTuple();

            TJJS_Line l1 = new TJJS_Line();
            TJJS_Point p = new TJJS_Point();
            TJJS_Angle ang = new TJJS_Angle();
            double dx, dy;
            int point_no = 0;
            string type;
            int w, h;


            result.Rect = Rect;
            image.GetImagePointer1(out type, out w, out h);
            p.Set(Rect.Col - Rect.Len2, Rect.Row);
            l1.Start = (TJJS_Point)p.Copy();
            p.Set(Rect.Col + Rect.Len2, Rect.Row);
            l1.End = (TJJS_Point)p.Copy();

            ang.r = Rect.Phi;
            l1 = l1.Rotate(l1.Mid, -(ang.d - 90));

            dx = (l1.End.X - l1.Start.X) / (Point_Count - 1);
            dy = (l1.End.Y - l1.Start.Y) / (Point_Count - 1);

            result.XLD_Point_Count = Point_Count;
            for (int i = 0; i < Point_Count; i++)
            {
                p.X = l1.Start.X + dx * i;
                p.Y = l1.Start.Y + dy * i;

                try
                {
                    measure.GenMeasureRectangle2(p.Y, p.X, Rect.Phi, Rect.Len1, 5, w, h, "nearest_neighbor");
                    measure.MeasurePos(image, Sigma, Threshold, Transition, Select, out row_Edge, out col_Edge, out amplitude, out distance);

                    if (col_Edge.Length >= 0)
                    {
                        result.XLD_Point[point_no].Col = col_Edge;
                        result.XLD_Point[point_no].Row = row_Edge;
                        point_no++;
                    }

                }
                catch
                {

                }
            }
            result.XLD_Point_Count = point_no;
        }
    }
    public class TFind_Edge_1_Result : TBase_Result
    {
        public stXLD_Pos[]             XLD_Point = new stXLD_Pos[0];
        public TJJS_Line               Line = new TJJS_Line();
        public stRectangle2            Rect;
        public double                  Col,  
                                       Row;
        public TFind_Edge_1_Disp_Param Disp_Param = new TFind_Edge_1_Disp_Param();

        public int XLD_Point_Count
        {
            get
            {
                return XLD_Point.Length;
            }
            set
            {
                int old_count;

                old_count = XLD_Point.Length;
                Array.Resize(ref XLD_Point, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        XLD_Point[i] = new stXLD_Pos();
                }
            }
        }
        public TFind_Edge_1_Result()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Result result = new TFind_Edge_1_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Edge_1_Result && dis_base is TFind_Edge_1_Result)
            {
                TFind_Edge_1_Result sor = (TFind_Edge_1_Result)sor_base;
                TFind_Edge_1_Result dis = (TFind_Edge_1_Result)dis_base;
                base.Copy(sor, dis);

                dis.XLD_Point_Count = sor.XLD_Point_Count;
                for (int i = 0; i < sor.XLD_Point_Count; i++) dis.XLD_Point[i] = sor.XLD_Point[i];

                dis.Line.Set(sor.Line);
                dis.Rect = sor.Rect;
                dis.Col = sor.Col;
                dis.Row = sor.Row;
                dis.Disp_Param.Set(sor.Disp_Param);
            }
        }
        override public void Reset()
        {
            Find_OK = false;
            Col = 0;
            Row = 0;
            XLD_Point_Count = 0;
        }
        override public void Set_Default()
        {
            base.Set_Default();
            Find_OK = false;
            Col = 0;
            Row = 0;
            XLD_Point_Count = 0;
            Line.Set(0, 0, 0, 0);
            Rect.Set(0, 0, 0, 0);
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

            JJS_Vision.Display_String(hw, Get_Message(), Disp_Param.Msg_X, Disp_Param.Msg_Y, Disp_Param.Msg_Font_Size, Disp_Param.Scale, color);
        }
        override public void Display_Model(HWindowControl hw)
        {
            string color;

            if (Find_OK) color = Disp_Param.Model_Color_OK;
            else color = Disp_Param.Model_Color_NG;

            if (Find_OK)
            {
                if (Disp_Param.Disp_Rect_Flag) Disp_Rect(hw, Disp_Param.Rect_Color);
                if (Disp_Param.Disp_Point_Flag) Disp_Point(hw, Disp_Param.Point_Size, Disp_Param.Point_Color);

                if (Disp_Param.Disp_Line_Flag) Disp_Line(hw, Disp_Param.Line_Color);

                hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
                JJS_Vision.Display_Hairline(hw, Col, Row, Disp_Param.Hairline_Size, 0, "yellow");
            }
        }
        override public string Get_Message()
        {
            string result = "";

            result = string.Format("{0:s} Col={1:f2} Row={2:f2} {3:s}", Disp_Param.Msg_Name, Col, Row, Find_OK ? "OK" : "NG");
            return result;
        }

        public void Update_Line()
        {
            HXLDCont xld = new HXLDCont();
            HTuple xld_row = new HTuple();
            HTuple xld_col = new HTuple();
            double rowBegin, colBegin, rowEnd, colEnd, nr, nc, dist;

            if (XLD_Point_Count >= 3)
            {
                for (int i = 0; i < XLD_Point_Count; i++)
                {
                    xld_row.Append(XLD_Point[i].Row);
                    xld_col.Append(XLD_Point[i].Col);
                }

                xld.GenContourPolygonXld(xld_row, xld_col);
                xld.FitLineContourXld("tukey", -1, 0, 5, 2, out rowBegin, out colBegin, out rowEnd, out colEnd, out nr, out nc, out dist);
                Line.Start = new TJJS_Point(colBegin, rowBegin);
                Line.End = new TJJS_Point(colEnd, rowEnd);
                Col = Line.Mid.X;
                Row = Line.Mid.Y;
                Find_OK = true;
            }
            else
            {
                Find_OK = false;
            }
        }
        public void Disp_Rect(HWindowControl hw, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
            hw.HalconWindow.SetDraw("margin");
            hw.HalconWindow.DispRectangle2(Rect.Row, Rect.Col, Rect.Phi, Rect.Len1, Rect.Len2);
        }
        public void Disp_Point(HWindowControl hw, double size, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
            for (int i = 0; i < XLD_Point_Count; i++)
            {
                hw.HalconWindow.DispCross(XLD_Point[i].Row, XLD_Point[i].Col, size, 0);
            }
        }
        public void Disp_Line(HWindowControl hw, string color)
        {
            hw.HalconWindow.SetColor(color);
            hw.HalconWindow.SetLineWidth((int)Disp_Param.Line_Width);
            hw.HalconWindow.DispLine(Line.Start.Y, Line.Start.X, Line.End.Y, Line.End.X);
        }
    }
    public class TFind_Edge_1_Disp_Param : TBase_Disp_Param
    {
        public string                  Rect_Color,
                                       Point_Color,
                                       Line_Color;
        public double                  Point_Size;
        public bool                    Disp_Rect_Flag = true;
        public bool                    Disp_Point_Flag = false;
        public bool                    Disp_Line_Flag = true;

        public TFind_Edge_1_Disp_Param()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TFind_Edge_1_Disp_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Edge_1_Disp_Param && dis_base is TFind_Edge_1_Disp_Param)
            {
                TFind_Edge_1_Disp_Param sor = (TFind_Edge_1_Disp_Param)sor_base;
                TFind_Edge_1_Disp_Param dis = (TFind_Edge_1_Disp_Param)dis_base;
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