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


namespace EFC.Vision.Halcon
{
    public partial class TForm_Select_Area : Form
    {
        public HImage                Image = new HImage();
        public HRegion               Select_Region = new HRegion();
        public TFrame_JJS_HW         JJS_HW = null;
        public string                Image_Type;
        public int                   Image_Width,
                                     Image_Height;

        public bool                  Auto_Set_Line_Width = true;

        private int                  in_HW_Line_Width = 2;
        private string               in_HW_SetDraw = emSetDraw.fill;
        private string               in_HW_SetColor = emSetColor.red;


        public int HW_Line_Width
        {
            get
            {
                return in_HW_Line_Width;
            }
            set
            {
                in_HW_Line_Width = value;
                Auto_Set_Line_Width = false;
            }
        }
        public string HW_SetDraw
        {
            get
            {
                return in_HW_SetDraw;
            }
            set
            {
                in_HW_SetDraw = value;
            }
        }
        public string HW_SetColor
        {
            get
            {
                return in_HW_SetColor;
            }
            set
            {
                in_HW_SetColor = value;
            }
        }
        public TForm_Select_Area()
        {
            InitializeComponent();
        }
        public TForm_Select_Area(HImage image, HRegion region)
        {
            InitializeComponent();
            JJS_Vision.Copy_Obj(image, ref Image);
            JJS_Vision.Copy_Obj(region, ref Select_Region);

            Image.GetImagePointer1(out Image_Type, out Image_Width, out Image_Height);
            if (Select_Region == null)
            {
                Select_Region = new HRegion();
                Select_Region.GenEmptyRegion();
            }
        }
        public void Set_Draw(HWindowControl hw)
        {
            if (RB_Fill.Checked) HW_SetDraw = emSetDraw.fill;
            else HW_SetDraw = emSetDraw.margin;

            JJS_HW.HW_Buf.HalconWindow.SetColor(in_HW_SetColor);
            JJS_HW.HW_Buf.HalconWindow.SetDraw(in_HW_SetDraw);
            JJS_HW.HW_Buf.HalconWindow.SetLineWidth(in_HW_Line_Width);
        }
        private void TForm_Select_Area_Shown(object sender, EventArgs e)
        {
            JJS_HW = tFrame_JJS_HW1;
            WindowState = FormWindowState.Maximized;
            JJS_HW.SetPart(Image);
            if (Auto_Set_Line_Width) in_HW_Line_Width = Get_Auto_Line_Width();
            Update_View();
        }
        public void Update_View()
        {
            try
            {
                Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                Set_Draw(JJS_HW.HW_Buf);
                Select_Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                JJS_HW.Copy_HW();
            }
            catch
            {

            }
        }
        private void B_Clear_Click(object sender, EventArgs e)
        {
            if (Select_Region == null) Select_Region = new HRegion();
            Select_Region.GenEmptyRegion();
            Update_View();
        }
        private void B_Select_Click(object sender, EventArgs e)
        {
            HRegion tmp_region = new HRegion();
            string Disp_String;

            JJS_HW.HW.Focus();
            JJS_HW.HW.HalconWindow.SetColor("blue");
            JJS_HW.HW.HalconWindow.SetTposition(1, 10);
            Disp_String = "請圈選畫面搜尋區域,按滑鼠右鍵結束輸入.";
            JJS_HW.HW.HalconWindow.WriteString(Disp_String);
            JJS_HW.Mode = emJJS_HW_Mode.None;

            switch (CB_Mode.Text)
            {
                case "Rectangle1":
                    if (true)
                    {
                        double c1, r1, c2, r2;
                        JJS_HW.HW.HalconWindow.DrawRectangle1(out r1, out c1, out r2, out c2);
                        tmp_region.GenRectangle1(r1 + 1, c1 + 1, r2 + 1, c2 + 1);
                    };
                    break;

                case "Rectangle2":
                    if (true)
                    {
                        double col, row, phi, len1, len2;
                        JJS_HW.HW.HalconWindow.DrawRectangle2(out row, out col, out phi, out len1, out len2);
                        tmp_region.GenRectangle2(row + 1, col + 1, phi, len1, len2);
                    };
                    break;

                case "Circle":
                    if (true)
                    {
                        double col, row, radius;
                        JJS_HW.HW.HalconWindow.DrawCircle(out row, out col, out radius);
                        tmp_region.GenCircle(row + 1, col + 1, radius);
                    };
                    break;

                case "DrawEllipse":
                    if (true)
                    {
                        double col, row, phi, radius1, radius2;
                        JJS_HW.HW.HalconWindow.DrawEllipse(out row, out col, out phi, out radius1, out radius2);
                        tmp_region.GenEllipse(row + 1, col + 1, phi, radius1, radius2);
                    };
                    break;

                case "Polygon":
                    if (true)
                    {
                        tmp_region = JJS_HW.HW.HalconWindow.DrawPolygon();
                    };
                    break;

                case "Threshold":
                    if (true)
                    {
                        TForm_Select_Threshold form = new TForm_Select_Threshold();
                        form.Image = Image.CopyObj(1, -1);
                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            tmp_region = form.Seleect_Region.CopyObj(1, -1);
                        }
                        else
                            tmp_region.GenEmptyRegion();
                    };
                    break;
            }

            if (RB_Add.Checked)
                Select_Region = Select_Region.Union2(tmp_region);
            else
                Select_Region = Select_Region.Difference(tmp_region);

            Update_View();
        }
        private void B_Move_Click(object sender, EventArgs e)
        {
            string Disp_String;

            JJS_HW.HW.Focus();
            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetTposition(1, 10);
            Disp_String = "請圈選畫面移動區域,按滑鼠右鍵結束輸入.";
            JJS_HW.HW.HalconWindow.WriteString(Disp_String);
            Select_Region = Select_Region.DragRegion1(JJS_HW.HW.HalconWindow);
            Update_View();
        }
        private void B_Max_Click(object sender, EventArgs e)
        {
            JJS_HW.HW.Focus();
            Select_Region.GenRectangle1(0, 0, (double)Image_Height, (double)Image_Width);
            Update_View();
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void RB_Fill_CheckedChanged(object sender, EventArgs e)
        {
            Update_View();
        }
        private void RB_Margin_CheckedChanged(object sender, EventArgs e)
        {
            Update_View();
        }
        private void tFrame_JJS_HW1_JJS_HW_Reflash(TFrame_JJS_HW jjs_hw)
        {
            Update_View();
        }
        private int Get_Auto_Line_Width()
        {
            int result = 0;
            double tmp_w = 2;

            tmp_w = 2 * Image_Width / JJS_HW.HW.Width;
            if (tmp_w < 1) tmp_w = 1;
            result = (int)Math.Round(tmp_w, 0);

            return result;
        }
    }
}
