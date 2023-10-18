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
using EFC.CAD;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Edit_Model : Form
    {
        public TJJS_ShapeModel      Param = new TJJS_ShapeModel();
        public TShape_Model_Param   ShapeModel_Param = new TShape_Model_Param();
        public HXLDCont             Undo_XLD = null;
        public HXLDCont             Tmp_XLD = new HXLDCont();
        public HRegion              Max_Region = new HRegion();
        public stRect_Double        XLD_Rect = new stRect_Double();
        public int                  Model_Width, Model_Height;
        public double               Disp_Scale = 5.0;
      
        public bool                 On_Get_Point_Flag = false;
        public bool                 Get_Point_Snap = false;
        public double               Get_Point_Snap_Size = 3.0;
 
        public double               Mouse_X = 0.0,
                                    Mouse_Y = 0.0;
        public double               Old_Origin_Col = 0.0,
                                    Old_Origin_Row = 0.0;

        public TForm_Edit_Model()
        {
            InitializeComponent();
        }
        public void Set_Pram(TJJS_ShapeModel model)
        {
            Param.Set(model);
            ShapeModel_Param = JJS_Vision.Get_ShapeModel_Param(Param.Model);
            Old_Origin_Col = ShapeModel_Param.Origin_Col;
            Old_Origin_Row = ShapeModel_Param.Origin_Row;
            Set_Param(ShapeModel_Param);
            
            Get_Default();
            JJS_Vision.Get_Model_Smallest_Rect(Param.Model, ref XLD_Rect);
            XLD_Rect = XLD_Rect.To_Square();
            XLD_Rect = XLD_Rect.Offset(XLD_Rect.Width() * 0.1);

            Model_Width = (int)XLD_Rect.Width();
            Model_Height = (int)XLD_Rect.Height();
            HW.HalconWindow.SetPart((int)XLD_Rect.Y1, (int)XLD_Rect.X1, (int)XLD_Rect.Y2, (int)XLD_Rect.X2);
            Max_Region.GenRectangle1(XLD_Rect.Y1, XLD_Rect.X1, XLD_Rect.Y2, XLD_Rect.X2);

        }
        public void Set_Param(TShape_Model_Param param)
        {
            try
            {
                CB_NumLevels.Text = param.Num_Levels.I.ToString();
                CB_AngleStart.Text = Math.Round(param.Angle_Start, 2).ToString();
                CB_AngleExtent.Text =  Math.Round(param.Angle_Extent, 2).ToString();
                CB_ScaleMin.Text = Math.Round(param.Scale_Min, 2).ToString();
                CB_ScaleMax.Text = Math.Round(param.Scale_Max, 2).ToString();
                CB_Metric.Text = param.Metric;
            }
            catch
            {

            }
        }

        public void Get_Param()
        {
            Get_Param(ref ShapeModel_Param);
        }
        public void Get_Param(ref TShape_Model_Param param)
        {
            try
            {
                param.Num_Levels = Convert.ToInt32(CB_NumLevels.Text);
                param.Angle_Start = Convert.ToDouble(CB_AngleStart.Text);
                param.Angle_Extent = Convert.ToDouble(CB_AngleExtent.Text);
                param.Scale_Min = Convert.ToDouble(CB_ScaleMin.Text);
                param.Scale_Max = Convert.ToDouble(CB_ScaleMax.Text);
                param.Metric = CB_Metric.Text;
            }
            catch
            {

            }
        }
        private void TForm_Edit_Model_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Set_Tool_Botton_All_On();
            Set_Scale_Fit();
        }
        public bool XLD_Inside(HXLDCont in_xld, stRect_Double rect)
        {
            bool result = true;
            HTuple col = new HTuple();
            HTuple row = new HTuple();

            in_xld.GetContourXld(out row, out col);
            for (int i = 0; i < col.Length; i++)
            {
                if (!rect.InSide(col[i], row[i]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public HXLDCont Remove_XLD(HXLDCont in_xld, double c1, double r1, double c2, double r2)
        {
            HXLDCont result = null;
            HXLDCont tmp_xld = null;
            bool flag = false;
            stRect_Double rect = new stRect_Double();

            rect.Set_Data(c1, r1, c2, r2);
            for (int i = 0; i < in_xld.CountObj(); i++)
            {
                tmp_xld = in_xld.SelectObj(i + 1);
                if (!XLD_Inside(tmp_xld, rect))
                {
                    if (!flag)
                    {
                        result = tmp_xld;
                        flag = true;
                    }
                    else
                        result = result.ConcatObj(tmp_xld);
                }
            }
            return result;
        }
        public HXLDCont Remove_XLD(HXLDCont in_xld, double col, double row)
        {
            HXLDCont result = null;
            HXLDCont tmp_xld = null;
            bool flag = false;
            double min, max;

            for (int i = 0; i < in_xld.CountObj(); i++)
            {
                tmp_xld = in_xld.SelectObj(i + 1);
                tmp_xld.DistancePc(row, col, out min,out max);

                if (min > Get_Point_Snap_Size)
                {
                    if (!flag)
                    {
                        result = tmp_xld;
                        flag = true;
                    }
                    else
                        result = result.ConcatObj(tmp_xld);
                }
            }
            return result;
        }
        public HXLDCont Cut_XLD(HXLDCont in_xld, double c1, double r1, double c2, double r2)
        {
            HXLDCont result = null;

            result = in_xld.CropContoursXld(XLD_Rect.Y1, XLD_Rect.X1, XLD_Rect.Y2, c1, "false");
            result = result.ConcatObj(in_xld.CropContoursXld(XLD_Rect.Y1, c2, XLD_Rect.Y2, XLD_Rect.X2, "false"));
            result = result.ConcatObj(in_xld.CropContoursXld(XLD_Rect.Y1, c1, r1, c2, "false"));
            result = result.ConcatObj(in_xld.CropContoursXld(r2, c1, XLD_Rect.Y2, c2, "false"));
            return result;
        }
        public void Set_Scale_Fit()
        {
            double scale_w = (double)panel3.Width / Model_Width;
            double scale_h = (double)panel3.Height / Model_Height;

            if (scale_w < scale_h) Disp_Scale = scale_w;
            else Disp_Scale = scale_h;

            HW.Top = 1;
            HW.Left = 1;
            HW.Width = (int)(Model_Width * Disp_Scale);
            HW.Height = (int)(Model_Height * Disp_Scale);


            panel3.VerticalScroll.Value = 0;
            panel3.HorizontalScroll.Value = 0;
            Disp_XLD();
        }
        public void Set_Scale(double scale)
        {
            Disp_Scale = scale;
            if (Disp_Scale < 0.1) Disp_Scale = 0.1;
            if (Disp_Scale > 20) Disp_Scale = 20;

            HW.Top = 1;
            HW.Left = 1;
            HW.Width = (int)(Model_Width * Disp_Scale);
            HW.Height = (int)(Model_Height * Disp_Scale);
            
            panel3.VerticalScroll.Value = 0;
            panel3.HorizontalScroll.Value = 0;
            Disp_XLD();
        }
        public void Set_Tool_Botton_Select(object sender)
        {
            Button select_b = null;
            Color color;

            select_b = (Button)sender;
            color = Color.White;
            Set_Tool_Botton_All_Off();

            if (select_b != null)
            {
                select_b.Enabled = true;
                select_b.BackColor = color;
            }
        }
        public void Set_Tool_Botton_All_On()
        {
            Color  color;

            color = Color.White;
            B_Remove_Rect.BackColor = color;
            B_Remove_Point.BackColor = color;
            B_Cut_Rect.BackColor = color;
            B_Segment.BackColor = color;
            B_Union.BackColor = color;
            B_Add_Line.BackColor = color;
            B_Center.BackColor = color;

            B_Remove_Rect.Enabled = true;
            B_Remove_Point.Enabled = true;
            B_Cut_Rect.Enabled = true;
            B_Segment.Enabled = true;
            B_Union.Enabled = true;
            B_Add_Line.Enabled = true;
            B_Center.Enabled = true;
        }
        public void Set_Tool_Botton_All_Off()
        {
            Color color;

            color = Color.DarkGray;
            B_Remove_Rect.BackColor = color;
            B_Remove_Point.BackColor = color;
            B_Cut_Rect.BackColor = color;
            B_Segment.BackColor = color;
            B_Union.BackColor = color;
            B_Add_Line.BackColor = color;
            B_Center.BackColor = color;

            B_Remove_Rect.Enabled = false;
            B_Remove_Point.Enabled = false;
            B_Cut_Rect.Enabled = false;
            B_Segment.Enabled = false;
            B_Union.Enabled = false;
            B_Add_Line.Enabled = false;
            B_Center.Enabled = false;
        }
        public void Disp_XLD()
        {
            HW.HalconWindow.ClearWindow();
            if (JJS_Vision.Is_Not_Empty(Tmp_XLD))
            {
                JJS_Vision.Display_Hairline(HW, ShapeModel_Param.Origin_Col - Old_Origin_Col,
                                                 ShapeModel_Param.Origin_Row - Old_Origin_Row, 20, 0, "blue");
                HW.HalconWindow.SetColored(12);
                HW.HalconWindow.DispObj(Tmp_XLD);
            }
        }
        public void Draw_Select_Line()
        {
            JJS_Vision.Display_Hairline(HW, Mouse_X, Mouse_Y, 1000 * 2, 0, "blue");
            if (Get_Point_Snap)
            {
                JJS_Vision.Display_Rectangle(HW, Mouse_X - Get_Point_Snap_Size, Mouse_Y - Get_Point_Snap_Size,
                                                  Mouse_X + Get_Point_Snap_Size, Mouse_Y + Get_Point_Snap_Size,
                                                  "blue");
            }
        }
        public void Get_Default()
        {
            try
            {
                Tmp_XLD = Param.Model.GetShapeModelContours(1);
            }
            catch
            {

            }
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Get_Default();
            Disp_XLD();
        }
        private void B_Scale_Zoom_In_Click(object sender, EventArgs e)
        {
            Set_Scale(Disp_Scale * 1.25);
        }
        private void B_Scale_Zoom_Out_Click(object sender, EventArgs e)
        {
            Set_Scale(Disp_Scale * 0.75);
        }
        private void B_Scale_Zoom_Fit_Click(object sender, EventArgs e)
        {
            Set_Scale_Fit();
        }
        private void B_Undo_Click(object sender, EventArgs e)
        {
            if (Undo_XLD != null)
            {
                Tmp_XLD = Undo_XLD;
                Undo_XLD = null;
                Disp_XLD();
            }
        }
        private void B_Remove_Rect_Click(object sender, EventArgs e)
        {
            double r1 = 0, c1 = 0, r2 = 0, c2 = 0;

            Set_Tool_Botton_Select(sender);
            HW.Focus();
            HW.HalconWindow.DrawRectangle1(out r1, out c1, out r2, out c2);
            Undo_XLD = Tmp_XLD;
            Tmp_XLD = Remove_XLD(Tmp_XLD, c1, r1, c2, r2);

            Disp_XLD();
            Set_Tool_Botton_All_On();
        }
        private void B_Remove_Point_Click(object sender, EventArgs e)
        {
            double c1 = 0.0, r1 = 0.0;

            Set_Tool_Botton_Select(sender);
            HW.Focus();
            Get_Point(out c1, out r1, "blue", true, Get_Point_Snap_Size);
            Undo_XLD = Tmp_XLD;
            Tmp_XLD = Remove_XLD(Tmp_XLD, c1, r1);

            Disp_XLD();
            Set_Tool_Botton_All_On();
        }
        private void B_Segment_Click(object sender, EventArgs e)
        {
            Set_Tool_Botton_Select(sender);
            Undo_XLD = Tmp_XLD;
            Tmp_XLD = Tmp_XLD.SegmentContoursXld("lines", 1, 1, 1);
            Disp_XLD();
            Set_Tool_Botton_All_On();
        }
        private void B_Add_Line_Click(object sender, EventArgs e)
        {
            double r1, c1, r2, c2;
            HXLDCont tmp_xld = new HXLDCont();
            HTuple row = new HTuple();
            HTuple col = new HTuple();

            Set_Tool_Botton_Select(sender);
            Undo_XLD = Tmp_XLD;
            HW.HalconWindow.DrawLine(out r1, out c1, out r2, out c2);
            row = row.TupleConcat(r1);
            row = row.TupleConcat(r2);
            col = col.TupleConcat(c1);
            col = col.TupleConcat(c2);
            tmp_xld.GenContourPolygonXld(row, col);
            Tmp_XLD = Tmp_XLD.ConcatObj(tmp_xld);
            Disp_XLD();
            Set_Tool_Botton_All_On();
        }
        private void B_Union_Click(object sender, EventArgs e)
        {
            Set_Tool_Botton_Select(sender);
            Undo_XLD = Tmp_XLD;
            Tmp_XLD = Tmp_XLD.UnionAdjacentContoursXld(10, 1, "attr_keep");
            Disp_XLD();
            Set_Tool_Botton_All_On();
        }
        private void B_Cut_Rect_Click(object sender, EventArgs e)
        {
            double r1 = 0, c1 = 0, r2 = 0, c2 = 0;

            Set_Tool_Botton_Select(sender);
            HW.Focus();
            HW.HalconWindow.DrawRectangle1(out r1, out c1, out r2, out c2);
            Undo_XLD = Tmp_XLD;
            Tmp_XLD = Cut_XLD(Tmp_XLD, c1, r1, c2, r2);

            Disp_XLD();
            Set_Tool_Botton_All_On();
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            HTuple numLevels = "auto";
            HTuple optimization = "none";
            string metric = "ignore_local_polarity";
            stRect_Double new_rect = new stRect_Double();
            TJJS_Point center;
            double ofs_r, ofs_c;

            Get_Param();
            JJS_Vision.Get_XLD_Smallest_Rect(Tmp_XLD, ref new_rect);

            Param.Model = Tmp_XLD.CreateScaledShapeModelXld(
                                                      numLevels,
                                                      ShapeModel_Param.Angle_Start, ShapeModel_Param.Angle_Extent, ShapeModel_Param.Angle_Step,
                                                      ShapeModel_Param.Scale_Min, ShapeModel_Param.Scale_Max, ShapeModel_Param.Scale_Step,
                                                      optimization,
                                                      metric,
                                                      ShapeModel_Param.Min_Contrast);
            center = new_rect.Center();
            ofs_c = -center.X;
            ofs_r = -center.Y;
            Param.Model.SetShapeModelOrigin(ofs_r, ofs_c);
            Param.XLD = Param.Model.GetShapeModelContours(1);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Center_Click(object sender, EventArgs e)
        {
            double col = 0.0, row = 0.0;
            Get_Point(out col, out row);
            ShapeModel_Param.Origin_Col = col + Old_Origin_Col;
            ShapeModel_Param.Origin_Row = row + Old_Origin_Row;
            Disp_XLD();
        }
        public void Get_Point(out double col, out double row, string color = "blue", bool snap = false, double snap_size = 10.0)
        {
            HW.Focus();
            On_Get_Point_Flag = true;
            Get_Point_Snap = snap;
            while (On_Get_Point_Flag) { Application.DoEvents(); };
            col = Mouse_X;
            row = Mouse_Y;
        }
        public void Get_Draw_Pos(double panel_col, double panel_row, out double hw_col, out double hw_row)
        {
            int c1, r1, c2, r2;
            double ofs_col, ofs_row, scale;

            HW.HalconWindow.GetPart(out r1, out c1, out r2, out c2);
            ofs_col = c1;
            ofs_row = r1;
            scale = (double)(c2 - c1) / HW.Size.Width;
            hw_col = panel_col * scale + ofs_col;
            hw_row = panel_row * scale + ofs_row;
        }
        private void HW_MouseDown(object sender, MouseEventArgs e)
        {
            if (On_Get_Point_Flag)
            {
                On_Get_Point_Flag = false;
            }
        }
        private void HW_MouseMove(object sender, MouseEventArgs e)
        {
            Get_Draw_Pos((double)e.X, (double)e.Y, out Mouse_X, out Mouse_Y);
            if (On_Get_Point_Flag)
            {
                Disp_XLD();
                Draw_Select_Line();
            }
        }

    }
}
