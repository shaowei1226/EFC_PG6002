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
using EFC.CAD;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Find_Natch_1 : Form
    {
        public TFind_Natch_1_Param Param = new TFind_Natch_1_Param();
        public HImage Image = new HImage();
        public HRegion Select_Region = new HRegion();
        public TFrame_JJS_HW JJS_HW;
        public int Step = 0;
        public bool On_Set_Param = false;

        public TForm_Find_Natch_1()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public void Set_Param(TFind_Natch_1_Param param)
        {
            Param = param.Copy();

            On_Set_Param = true;
            SB_Threshold_Min.Value = Param.Threshold_Min;
            SB_Threshold_Max.Value = Param.Threshold_Max;
            E_Threshold_Min.Text = Param.Threshold_Min.ToString();
            E_Threshold_Max.Text = Param.Threshold_Max.ToString();

            E_Dilation_Circle.Text = Param.Dilation_Circle.ToString("0.0");
            E_Erosion_Circle.Text = Param.Erosion_Circle.ToString("0.0");
            E_Wafer_Circularity_Min.Text = Param.Wafer_Circularity_Min.ToString("0.00");
            E_Wafer_Circularity_Max.Text = Param.Wafer_Circularity_Max.ToString("0.00");

            E_Wafer_Circle.Text = Param.Wafer_Circle.ToString("0");

            CB_Natch_Filter.Checked = Param.Natch_Filter;
            E_Natch_Erosion_Circle.Text = Param.Natch_Erosion_Circle.ToString("0.0");
            E_Natch_Area_Min.Text = Param.Natch_Area_Min.ToString("0");
            E_Natch_Area_Max.Text = Param.Natch_Area_Max.ToString("0");
            E_Natch_Compactness_Min.Text = Param.Natch_Compactness_Min.ToString("0.00");
            E_Natch_Compactness_Max.Text = Param.Natch_Compactness_Max.ToString("0.00");
            On_Set_Param = false;
        }
        public void Update_Param()
        {
            Param.Threshold_Min = SB_Threshold_Min.Value;
            Param.Threshold_Max = SB_Threshold_Max.Value;
            if (Param.Threshold_Min > Param.Threshold_Max) Param.Threshold_Min = Param.Threshold_Max;

            Param.Dilation_Circle = Convert.ToDouble(E_Dilation_Circle.Text);
            Param.Erosion_Circle = Convert.ToDouble(E_Erosion_Circle.Text);
            Param.Wafer_Circularity_Min = Convert.ToDouble(E_Wafer_Circularity_Min.Text);
            Param.Wafer_Circularity_Max = Convert.ToDouble(E_Wafer_Circularity_Max.Text);

            Param.Wafer_Circle = Convert.ToDouble(E_Wafer_Circle.Text);

            Param.Natch_Filter = CB_Natch_Filter.Checked;
            Param.Natch_Erosion_Circle = Convert.ToDouble(E_Natch_Erosion_Circle.Text);
            Param.Natch_Area_Min = Convert.ToDouble(E_Natch_Area_Min.Text);
            Param.Natch_Area_Max = Convert.ToDouble(E_Natch_Area_Max.Text);
            Param.Natch_Compactness_Min = Convert.ToDouble(E_Natch_Compactness_Min.Text);
            Param.Natch_Compactness_Max = Convert.ToDouble(E_Natch_Compactness_Max.Text);
        }
        private void TForm_Find_Natch_1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            JJS_HW.SetPart(Image);
            JJS_HW.HW_Buf.HalconWindow.DispObj(Image);
            JJS_HW.Copy_HW();
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
        private void B_Next1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
        private void SB_Threshold_Min_ValueChanged(object sender, EventArgs e)
        {
            if (!On_Set_Param)
            {
                E_Threshold_Min.Text = SB_Threshold_Min.Value.ToString();
                Update_View();
            }
        }
        private void SB_Threshold_Max_ValueChanged(object sender, EventArgs e)
        {
            if (!On_Set_Param)
            {
                E_Threshold_Max.Text = SB_Threshold_Max.Value.ToString();
                Update_View();
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HImage image = new HImage();
            HRegion region = new HRegion();
            HRegion region2 = new HRegion();
            HRegion wafer_region = new HRegion();
            double center_c=0, center_r=0, center_radius=0;
            int w, h;
            int count;
            double wafer_pixel;

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                image = Image.Clone();
                image.GetImageSize(out w, out h);
                JJS_HW.HW_Buf.HalconWindow.ClearWindow();

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    region = image.Threshold((double)Param.Threshold_Min, (double)Param.Threshold_Max);
                    region = region.Connection();
                    Select_Region = region;

                    if (Step == 1)
                    {
                        Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        JJS_HW.HW_Buf.HalconWindow.SetDraw("fill");
                        region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    }
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    region = region.DilationCircle(Param.Dilation_Circle);
                    region = region.ErosionCircle(Param.Erosion_Circle);
                    region = region.FillUp();
                    region = region.SelectShape("circularity", "and", Param.Wafer_Circularity_Min, Param.Wafer_Circularity_Max);
                    wafer_pixel = Param.Wafer_Size * Param.Wafer_Scale / 2;
                    region = region.SelectShape("outer_radius", "and", wafer_pixel * 0.9, wafer_pixel * 1.1);
                    wafer_region = region.Clone();
                    Select_Region = region;

                    if (Step == 2)
                    {
                        Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        JJS_HW.HW_Buf.HalconWindow.SetDraw("fill");
                        region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    }
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    region2 = region.OpeningCircle(Param.Wafer_Circle);
                    region2 = region2.ClosingCircle(Param.Wafer_Circle);
                    count = region2.CountObj();
                    if (count == 1)
                    {
                        region2.SmallestCircle(out center_r, out center_c, out center_radius);
                        region2.GenCircle(center_r, center_c, center_radius);

                        if (Step == 3)
                        {
                            JJS_HW.HW_Buf.HalconWindow.SetLineWidth(10);
                            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                            JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                            region2.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        }
                    }
                    else flag = false;
                }
                #endregion

                #region Step4 Set Find Param
                if (Step >= 4 && flag)
                {
                    region = region2.Difference(wafer_region);
                    region = region.Connection();
                    Select_Region = region;
                    if (Param.Natch_Filter)
                    {
                        if (Param.Natch_Erosion_Circle > 0.0) region = region.ErosionCircle(Param.Natch_Erosion_Circle);
                        region = region.SelectShape("area", "and", Param.Natch_Area_Min, Param.Natch_Area_Max);
                        region = region.SelectShape("compactness", "and", Param.Natch_Compactness_Min, Param.Natch_Compactness_Max);
                    }
                    if (Step == 4)
                    {
                        Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        JJS_HW.HW_Buf.HalconWindow.SetDraw("fill");
                        region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    }
                }
                #endregion

                #region Find Model
                if (Step >= 5 && flag)
                {
                    TFind_Natch_1_Result tmp_result = new TFind_Natch_1_Result();

                    TFind_Natch_1.Find(image, Param, ref tmp_result);
                    if (Step == 5)
                    {
                        Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        TFind_Natch_1.Disp_Result(JJS_HW.HW_Buf, tmp_result, 100);
                        TFind_Natch_1.Disp_Find_Message(JJS_HW.HW_Buf, tmp_result, 10, 10 , 80, 1);
                    }
                }
                #endregion
                JJS_HW.Copy_HW();
            }
        }

        private void B_Update_Click(object sender, EventArgs e)
        {
            Update_View();
        }
        private void tabPage1_Enter(object sender, EventArgs e)
        {
            Step = 1;
            Update_View();
        }
        private void tabPage7_Enter(object sender, EventArgs e)
        {
            Step = 2;
            Update_View();
        }
        private void tabPage2_Enter(object sender, EventArgs e)
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
        private void button6_Click(object sender, EventArgs e)
        {

        }
        private void B_Get_Region_Info_Click(object sender, EventArgs e)
        {
            double col, row;
            HRegion tmp_region = new HRegion();
            TJJS_XML_File ini = new TJJS_XML_File();
            stRegion_Info region_info = new stRegion_Info();

            B_Get_Region_Info.BackColor = Color.Black;
            TV_Region_Info.Nodes.Clear();
            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.Focus();
            JJS_HW.HW.HalconWindow.DrawPoint(out row, out col);
            tmp_region = Select_Region.SelectRegionPoint((int)Math.Round(row, 0), (int)Math.Round(col, 0));
            if (tmp_region.CountObj() == 1)
            {
                region_info = TJJS_Vision.Get_Region_Info(tmp_region);
                region_info.Write(ini, "Default");
                TJJS_XML_Tool.Display_TreeView(TV_Region_Info, ini);
            }
            B_Get_Region_Info.BackColor = Color.Transparent;
        }
    }
    public class TFind_Natch_1
    {

        public TFind_Natch_1()
        {
        }
        public static bool Set_Param(HImage image, ref TFind_Natch_1_Param param)
        {
            bool result = false;
            TForm_Find_Natch_1 form = new TForm_Find_Natch_1();

            form.Image = image.Clone();
            form.Set_Param(param);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                param = form.Param.Copy();
                result = true;
            }
            return result;
        }
        public static bool Find(HImage image, TFind_Natch_1_Param param, ref TFind_Natch_1_Result result)
        {
            HRegion region = new HRegion();
            HRegion region2 = new HRegion();
            HRegion wafer_region = new HRegion();
            double center_c = 0, center_r = 0, center_radius = 0;
            int w, h;
            int count;
            double natch_c, natch_r;
            double wafer_pixel;


            result.Reset();
            image.GetImageSize(out w, out h);
            result.Image_Center_Col = w / 2;
            result.Image_Center_Row = h / 2;

            region = image.Threshold((double)param.Threshold_Min, (double)param.Threshold_Max);
            region = region.Connection();

            region = region.DilationCircle(param.Dilation_Circle);
            region = region.ErosionCircle(param.Erosion_Circle);
            region = region.FillUp();
            region = region.SelectShape("circularity", "and", param.Wafer_Circularity_Min, param.Wafer_Circularity_Max);
            wafer_pixel = param.Wafer_Size * param.Wafer_Scale / 2;
            region = region.SelectShape("outer_radius", "and", wafer_pixel * 0.9, wafer_pixel * 1.1);
            wafer_region = region.Clone();

            region2 = region.OpeningCircle(param.Wafer_Circle);
            region2 = region2.ClosingCircle(param.Wafer_Circle);
            if (region2.CountObj() == 1)
            {
                region2.SmallestCircle(out center_r, out center_c, out center_radius);
                region2.GenCircle(center_r, center_c, center_radius);


                region = region2.Difference(wafer_region);
                region = region.Connection();
                if (param.Natch_Filter)
                {
                    if (param.Natch_Erosion_Circle > 0.0) region = region.ErosionCircle(param.Natch_Erosion_Circle);
                    region = region.SelectShape("area", "and", param.Natch_Area_Min, param.Natch_Area_Max);
                    region = region.SelectShape("compactness", "and", param.Natch_Compactness_Min, param.Natch_Compactness_Max);
                }

                count = region.CountObj();
                if (count == 1)
                {
                    result.Find_Ok = true;
                    result.Natch_Region = region.Clone();
                    region.AreaCenter(out natch_r, out natch_c);
                    result.Line.Start = new TJJS_Point(center_c, center_r);
                    result.Line.End = new TJJS_Point(natch_c, natch_r);
                    result.Col = center_c - result.Image_Center_Col;
                    result.Row = -(center_r - result.Image_Center_Row);
                    result.Angle = -result.Line.V.Angle.d;
                    result.Radius = center_radius;
                }
            }
            return result.Find_Ok;
        }
        public static void Disp_Result(HWindowControl hw, TFind_Natch_1_Result result, double size)
        {
            if (result.Find_Ok)
            {
                hw.HalconWindow.SetDraw("fill");
                hw.HalconWindow.SetLineWidth(5);
                hw.HalconWindow.SetColor("red");
                result.Natch_Region.DispObj(hw.HalconWindow);

                hw.HalconWindow.SetDraw("margin");
                hw.HalconWindow.SetColor("green");
                hw.HalconWindow.DispLine(result.Line.Start.Y, result.Line.Start.X, result.Line.End.Y, result.Line.End.X);
                hw.HalconWindow.DispCross(result.Line.Start.Y, result.Line.Start.X, size, 0.0);

                hw.HalconWindow.SetColor("red");
                hw.HalconWindow.DispCircle(result.Line.Start.Y, result.Line.Start.X, result.Radius);
            };
            hw.HalconWindow.SetColor("red");
            hw.HalconWindow.DispCross(result.Image_Center_Row, result.Image_Center_Col, size, 0.0);
        }
        public static void Disp_Find_Message(HWindowControl hw, TFind_Natch_1_Result result, double col, double row, int size, double scale)
        {
            string str;
            string color;

            if (result.Find_Ok) color = "green";
            else color = "red";

            str = string.Format("Center_X = {0:f1}, Center_Y = {1:f1}, Center_Radius = {2:f1}, Angle = {3:f3}",
                                 result.Col, result.Row, result.Radius, result.Angle);
            TJJS_Vision.Display_String(hw, str, col, row, size, scale, color);
        }
    }
    public class TFind_Natch_1_Param
    {
        public string               Default_Path;

        public double               Wafer_Size,
                                    Wafer_Scale;

        public int                  Threshold_Min,
                                    Threshold_Max;
        public double               Dilation_Circle,
                                    Erosion_Circle,
                                    Closing_Circle,
                                    Erosion_Circle2;
        public double               Wafer_Circularity_Min,
                                    Wafer_Circularity_Max;
        public double               Wafer_Circle;

        public bool                 Natch_Filter;
        public double               Natch_Erosion_Circle;
        public double               Natch_Area_Min,
                                    Natch_Area_Max,
                                    Natch_Compactness_Min,
                                    Natch_Compactness_Max;
        public double               Natch_Ofs_X,
                                    Natch_Ofs_Y,
                                    Natch_Ofs_Q;

        public TFind_Natch_1_Param()
        {
            Default_Path = "";
            Set_Default();
        }
        public TFind_Natch_1_Param Copy()
        {
            TFind_Natch_1_Param result = new TFind_Natch_1_Param();
            result.Default_Path = Default_Path;

            result.Wafer_Size = Wafer_Size;
            result.Wafer_Scale = Wafer_Scale;
            result.Threshold_Min = Threshold_Min;
            result.Threshold_Max = Threshold_Max;
            result.Dilation_Circle = Dilation_Circle;
            result.Erosion_Circle = Erosion_Circle;
            result.Closing_Circle = Closing_Circle;
            result.Erosion_Circle2 = Erosion_Circle2;
            result.Wafer_Circularity_Min = Wafer_Circularity_Min;
            result.Wafer_Circularity_Max = Wafer_Circularity_Max;
            result.Wafer_Circle = Wafer_Circle;

            result.Natch_Filter = Natch_Filter;
            result.Natch_Erosion_Circle = Natch_Erosion_Circle;
            result.Natch_Area_Min = Natch_Area_Min;
            result.Natch_Area_Max = Natch_Area_Max;
            result.Natch_Compactness_Min = Natch_Compactness_Min;
            result.Natch_Compactness_Max = Natch_Compactness_Max;
            result.Natch_Ofs_X = Natch_Ofs_X;
            result.Natch_Ofs_Y = Natch_Ofs_Y;
            result.Natch_Ofs_Q = Natch_Ofs_Q;
            return result;
        }
        public void Set_Default()
        {
            Wafer_Size = 300;
            Wafer_Scale = 10;
            Threshold_Min = 0;
            Threshold_Max = 255;
            Dilation_Circle = 3.5;
            Erosion_Circle = 3.5;
            Closing_Circle = 3.5;
            Erosion_Circle2 = 3.5;
            Wafer_Circularity_Min = 0.8;
            Wafer_Circularity_Max = 1;
            Wafer_Circle = 300;

            Natch_Filter = true;
            Natch_Erosion_Circle = 1.0;
            Natch_Area_Min = 0;
            Natch_Area_Max = 99999999;
            Natch_Compactness_Min = 0;
            Natch_Compactness_Max = 0.9;
            Natch_Ofs_X = 0;
            Natch_Ofs_Y = 0;
            Natch_Ofs_Q = 0;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Threshold_Min = ini.ReadInteger(tmp_section, "Threshold_Min", 0);
                Threshold_Max = ini.ReadInteger(tmp_section, "Threshold_Max", 255);
                Dilation_Circle = ini.ReadFloat(tmp_section, "Dilation_Circle", 3.5);

                Erosion_Circle = ini.ReadFloat(tmp_section, "Erosion_Circle", 3.5);
                Closing_Circle = ini.ReadFloat(tmp_section, "Closing_Circle", 300);
                Erosion_Circle2 = ini.ReadFloat(tmp_section, "Erosion_Circle2", 2.0);
                Wafer_Circularity_Min = ini.ReadFloat(tmp_section, "Wafer_Circularity_Min", 0.8);
                Wafer_Circularity_Max = ini.ReadFloat(tmp_section, "Wafer_Circularity_Max", 1.0);
                Wafer_Circle = ini.ReadFloat(tmp_section, "Wafer_Circle", 300.0);

                Natch_Filter = ini.ReadBool(tmp_section, "Natch_Filter", true);
                Natch_Erosion_Circle = ini.ReadFloat(tmp_section, "Natch_Erosion_Circle", 1.0); 
                Natch_Area_Min = ini.ReadFloat(tmp_section, "Natch_Area_Min", 100);
                Natch_Area_Max = ini.ReadFloat(tmp_section, "Natch_Area_Max", 500);
                Natch_Compactness_Min = ini.ReadFloat(tmp_section, "Natch_Compactness_Min", 0.5);
                Natch_Compactness_Max = ini.ReadFloat(tmp_section, "Natch_Compactness_Max", 1.0);

                Natch_Ofs_X = ini.ReadFloat(tmp_section, "Natch_Ofs_X", 0.0);
                Natch_Ofs_Y = ini.ReadFloat(tmp_section, "Natch_Ofs_Y", 0.0);
                Natch_Ofs_Q = ini.ReadFloat(tmp_section, "Natch_Ofs_Q", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteInteger(tmp_section, "Threshold_Min", Threshold_Min);
                ini.WriteInteger(tmp_section, "Threshold_Max", Threshold_Max);

                ini.WriteFloat(tmp_section, "Dilation_Circle", Dilation_Circle);
                ini.WriteFloat(tmp_section, "Erosion_Circle", Erosion_Circle);
                ini.WriteFloat(tmp_section, "Closing_Circle", Closing_Circle);
                ini.WriteFloat(tmp_section, "Erosion_Circle2", Erosion_Circle2);
                ini.WriteFloat(tmp_section, "Wafer_Circularity_Min", Wafer_Circularity_Min);
                ini.WriteFloat(tmp_section, "Wafer_Circularity_Max", Wafer_Circularity_Max);
                ini.WriteFloat(tmp_section, "Wafer_Circle", Wafer_Circle);

                ini.WriteBool(tmp_section, "Natch_Filter", Natch_Filter);
                ini.WriteFloat(tmp_section, "Natch_Erosion_Circle", Natch_Erosion_Circle);
                ini.WriteFloat(tmp_section, "Natch_Area_Min", Natch_Area_Min);
                ini.WriteFloat(tmp_section, "Natch_Area_Max", Natch_Area_Max);
                ini.WriteFloat(tmp_section, "Natch_Compactness_Min", Natch_Compactness_Min);
                ini.WriteFloat(tmp_section, "Natch_Compactness_Max", Natch_Compactness_Max);

                ini.WriteFloat(tmp_section, "Natch_Ofs_X", Natch_Ofs_X);
                ini.WriteFloat(tmp_section, "Natch_Ofs_Y", Natch_Ofs_Y);
                ini.WriteFloat(tmp_section, "Natch_Ofs_Q", Natch_Ofs_Q);
            }
            return true;
        }
    }
    public class TFind_Natch_1_Result
    {
        public bool                    Find_Ok;
        public double                  Col,
                                       Row,
                                       Angle;
        public double                  Radius;
        public double                  Image_Center_Col,
                                       Image_Center_Row;
        public TJJS_Line               Line = new TJJS_Line();
        public HRegion                 Natch_Region = new HRegion();

        public TFind_Natch_1_Result()
        {
            Reset();
        }
        public TFind_Natch_1_Result Copy()
        {
            TFind_Natch_1_Result result = new TFind_Natch_1_Result();
            result.Find_Ok = Find_Ok;
            result.Col = Col;
            result.Row = Row;
            result.Angle = Angle;
            result.Radius = Radius;
            result.Image_Center_Col = Image_Center_Col;
            result.Image_Center_Row = Image_Center_Row;
            result.Line = Line.Copy();
            result.Natch_Region = Natch_Region.Clone();
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
            }
            return true;
        }
        public void Reset()
        {
            Find_Ok = false;
            Col = 0.0;
            Row = 0.0;
            Angle = 0.0;
            Radius = 0;
        }
    }
}