using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using EFC.CAD;

namespace EFC.Vision.Halcon
{
    public enum emJJS_HW_Mode { None, Move, Zoom_In, Zoom_Out, Zoom_Window, Zoom_Fit, Zoom_X10, Zoom_Max, Zoom_Wheel }
    public delegate void evReflash(TFrame_JJS_HW jjs_hw);

    public partial class TFrame_JJS_HW : UserControl
    {
        public event MouseEventHandler    JJS_HW_MouseUp;
        public event MouseEventHandler    JJS_HW_MouseDown;
        public event MouseEventHandler    JJS_HW_MouseMove;
        public event KeyEventHandler      JJS_HW_KeyDown;
        public event KeyPressEventHandler JJS_HW_KeyPress;
        public event KeyEventHandler      JJS_HW_KeyUp;
        public event evReflash            JJS_HW_Reflash;

        public bool                    Init_Ok = false;
        public emJJS_HW_Mode           Mode = emJJS_HW_Mode.None;
        public stRect_Double           HW_Rect = new stRect_Double();          //HW 實際顯示大小
        public stRect_Double           HW_Rect_Part = new stRect_Double();     //HW SetPart大小
        public stRect_Double           HW_Buf_Rect = new stRect_Double();      //HW_Buf 繪圖的大小
        public double                  FDisp_Scale = 1;
        public double                  Ofs_X = 0,
                                       Ofs_Y = 0;        
        public bool                    Mouse_Down = false;
        public double                  Mouse_Down_X = 0.0,
                                       Mouse_Down_Y = 0.0,
                                       Mouse_Down_Ofs_X = 0.0,
                                       Mouse_Down_Ofs_Y = 0.0;
        public double                  Mouse_X = 0.0,
                                       Mouse_Y = 0.0;
        public double                  Move_X = 0.0,
                                       Move_Y = 0.0;

        public bool                    On_Setting = false;
        public bool                    Reflash = false;

        public bool                    On_Get_Point_Flag = false;
        public bool                    On_Get_Rect_Flag = false;
        public bool                    Get_Point_Snap_Flag = false;
        public double                  Get_Point_Snap_Size = 10;

        public THalcon_System_Param    HW_Param = new THalcon_System_Param();


        private int                    Old_Part_X1 = 0;
        private int                    Old_Part_Y1 = 0;
        private int                    Old_Part_X2 = 0;
        private int                    Old_Part_Y2 = 0;


        public bool Only_Window
        {
            get
            {
                return panel1.Visible;
            }
            set
            {
                panel1.Visible = value;
                ScrollBar_H.Visible = value;
                ScrollBar_V.Visible = value;
                statusStrip1.Visible = value;
            }
        }
        public double Disp_Scale
        {
            get
            {
                return FDisp_Scale;
            }
            set
            {
                FDisp_Scale = value;
                if (FDisp_Scale > 20) FDisp_Scale = 20;
                if (FDisp_Scale < 0.01) FDisp_Scale = 0.01;
            }
        }
        public TFrame_JJS_HW()
        {
            InitializeComponent();
            HW.Top = 0;
            HW.Left = 0;
            HW.Width = panel2.Width;
            HW.Height = panel2.Height;
            HW_Buf.Visible = false;
            HW.MouseWheel += HW_HMouseWheel;
        }
        public void Init()
        {
            SetPart(640, 480);
            Set_ToolBar(true);
            Set_Button_Color(Mode);
            
            Reflash = true;
            timer1.Enabled = true;

            HW_Param.HW = HW_Buf;
            Init_Ok = true;
        }
        public void Close()
        {
            timer1.Enabled = false;
        }
        public void Set_ToolBar(bool flag)
        {
            if (flag)
            {
                panel1.ForeColor = Color.Gray;
                panel1.Enabled = flag;
            }
            else
            {
                panel1.ForeColor = Color.Brown;
                panel1.Enabled = flag;
            };
        }
        public void Set_Button_Color(emJJS_HW_Mode mode)
        {
            Color color;

            color = Color.DarkGray;
            B_None.BackColor = color;
            B_Move.BackColor = color;
            B_Zoom_In.BackColor = color;
            B_Zoom_Out.BackColor = color;
            B_Zoom_Window.BackColor = color;
            B_Fit.BackColor = color;
            B_Zoom_X10.BackColor = color;
            B_Zoom_X1.BackColor = color;
            B_Wheel.BackColor = color;

            color = Color.White;
            switch (mode)
            {
                case emJJS_HW_Mode.None: B_None.BackColor = color; break;
                case emJJS_HW_Mode.Move: B_Move.BackColor = color; break;
                case emJJS_HW_Mode.Zoom_In: B_Zoom_In.BackColor = color; break;
                case emJJS_HW_Mode.Zoom_Out: B_Zoom_Out.BackColor = color; break;
                case emJJS_HW_Mode.Zoom_Window: B_Zoom_Window.BackColor = color; break;
                case emJJS_HW_Mode.Zoom_Fit: B_Fit.BackColor = color; break;
                case emJJS_HW_Mode.Zoom_X10: B_Zoom_X10.BackColor = color; break;
                case emJJS_HW_Mode.Zoom_Max: B_Zoom_X1.BackColor = color; break;
                case emJJS_HW_Mode.Zoom_Wheel: B_Wheel.BackColor = color; break;
            }
        }
        public void Set_Mode(emJJS_HW_Mode mode)
        {
            if(Mode != mode)
            {
                Mode = mode;
                HW.Focus();
                Reflash = true;
            }
        }
        private void B_None_Click(object sender, EventArgs e)
        {
            Set_Mode(emJJS_HW_Mode.None);
        }
        private void B_Move_Click(object sender, EventArgs e)
        {
            Set_Mode(emJJS_HW_Mode.Move);
        }
        private void B_Zoom_In_Click(object sender, EventArgs e)
        {
            Zoom_In();
        }
        private void B_Zoom_Out_Click(object sender, EventArgs e)
        {
            Zoom_Out();
        }
        private void B_Zoom_Window_Click(object sender, EventArgs e)
        {
            Zoom_Window();
        }
        private void B_Zoom_X10_Click(object sender, EventArgs e)
        {
            Zoom_X10();
        }
        private void B_Fit_Click(object sender, EventArgs e)
        {
            Zoom_Windows_Fit();
        }
        private void B_Zoom_X1_Click(object sender, EventArgs e)
        {
            Zoom_X1();
        }
        private void B_Wheel_Click(object sender, EventArgs e)
        {
            Set_Mode(emJJS_HW_Mode.Zoom_Wheel);
        }
        private void HW_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Mouse_Down) Mouse_Down = false;
            }
            if (JJS_HW_MouseUp != null) JJS_HW_MouseUp(sender, e);
        }
        private void HW_MouseDown(object sender, MouseEventArgs e)
        {
            Get_Draw_Pos((double)e.X, (double)e.Y, out Mouse_X, out Mouse_Y);
            if (e.Button == MouseButtons.Left)
            {
                switch (Mode)
                {
                    case emJJS_HW_Mode.Move:
                        if (!Mouse_Down)
                        {
                            Mouse_Down = true;
                            Mouse_Down_X = e.X;
                            Mouse_Down_Y = e.Y;
                            Mouse_Down_Ofs_X = Ofs_X;
                            Mouse_Down_Ofs_Y = Ofs_Y;
                        }
                        break;

                    case emJJS_HW_Mode.Zoom_X10:
                        Reflash = true;
                        //SetPart();
                        //Copy_HW();
                        break;
                }

                if (On_Get_Point_Flag)
                {
                    On_Get_Point_Flag = false;
                    Reflash = true;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (Mode == emJJS_HW_Mode.Move || Mode == emJJS_HW_Mode.Zoom_Wheel)
                    Set_Mode(emJJS_HW_Mode.None);
            }
            if (JJS_HW_MouseDown != null) JJS_HW_MouseDown(sender, e);
        }
        private void HW_MouseMove(object sender, MouseEventArgs e)
        {
            double ofs_x = 0, ofs_y = 0;

            Get_Draw_Pos((double)e.X, (double)e.Y, out Mouse_X, out Mouse_Y);
            if (Mode == emJJS_HW_Mode.Move && Mouse_Down)
            {
                ofs_x = e.X - Mouse_Down_X;
                ofs_y = e.Y - Mouse_Down_Y;
                ofs_x = ofs_x / Disp_Scale;
                ofs_y = ofs_y / Disp_Scale;
                Ofs_X = Mouse_Down_Ofs_X - ofs_x;
                Ofs_Y = Mouse_Down_Ofs_Y - ofs_y;
                Reflash = true;
                //SetPart();
                //Copy_HW();
            }
            if (On_Get_Point_Flag)
            {
                //Copy_HW();
                Draw_Select_Line();
                Reflash = true;
            }

            string tmp_str;

            tmp_str = string.Format("({0:F1},{1:F1})", Mouse_X, Mouse_Y);
            TStatus_01.Text = tmp_str;
            
            HImage image = HW.HalconWindow.DumpWindowImage();
            try
            {
                tmp_str = string.Format("Gray={0:F3}", image.GetGrayval(e.Y, e.X));
            }
            catch { };
            TStatus_02.Text = tmp_str;

            tmp_str = string.Format("WX={0:F3}", e.X);
            TStatus_03.Text = tmp_str;
            tmp_str = string.Format("WY={0:F3}", e.Y);
            TStatus_04.Text = tmp_str;
            tmp_str = string.Format("WX={0:F3}", ofs_x);
            TStatus_05.Text = tmp_str;
            tmp_str = string.Format("WY={0:F3}", ofs_y);
            TStatus_06.Text = tmp_str;

            if (JJS_HW_MouseMove != null) JJS_HW_MouseMove(sender, e);
        }
        private void HW_HMouseWheel(object sender, MouseEventArgs e)
        {
            int move_pixel = 0;
            double scale;

            if (Mode == emJJS_HW_Mode.Zoom_Wheel)
            {
                move_pixel = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                if (move_pixel > 0) scale = Disp_Scale * 1.05;
                else scale = Disp_Scale * 0.95;
                Zoom_Windows_HW(Mouse_X, Mouse_Y, e.X, e.Y, scale);
                Reflash = true;
                //SetPart();
                //Copy_HW();

            }
        }
        private void HW_KeyDown(object sender, KeyEventArgs e)
        {
            if (JJS_HW_KeyDown != null) JJS_HW_KeyDown(sender, e);
        }
        private void HW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (JJS_HW_KeyPress != null) JJS_HW_KeyPress(sender, e);
        }
        private void HW_KeyUp(object sender, KeyEventArgs e)
        {
            if (JJS_HW_KeyUp != null) JJS_HW_KeyUp(sender, e);
        }
        public void Draw_Select_Line()
        {
            Copy_HW();
            JJS_Vision.Display_Hairline(HW, Mouse_X, Mouse_Y, HW_Buf_Rect.Width() * 2, 0, "blue");
            if (Get_Point_Snap_Flag)
            {
                JJS_Vision.Display_Rectangle(HW, Mouse_X - Get_Point_Snap_Size, Mouse_Y - Get_Point_Snap_Size,
                                                  Mouse_X + Get_Point_Snap_Size, Mouse_Y + Get_Point_Snap_Size,
                                                  "blue");
            }
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
        public void HW_Set_Size(double x1, double y1, double x2, double y2)
        {
            double disp_scale = 1;
            double image_scale = 1;

            disp_scale = (double)Disp_Panel.Width / Disp_Panel.Height;
            image_scale = (x2 - x1) / (y2 - y1);
            if (disp_scale < image_scale)
            {
                HW_Rect.X1 = Disp_Panel.Top;
                HW_Rect.Y1 = Disp_Panel.Left;
                HW_Rect.X2 = HW_Rect.X1 + Disp_Panel.Width;
                HW_Rect.Y2 = HW_Rect.Y1 + Disp_Panel.Width / image_scale;
            }
            else
            {
                HW_Rect.X1 = Disp_Panel.Top;
                HW_Rect.Y1 = Disp_Panel.Left;
                HW_Rect.X2 = HW_Rect.X1 + Disp_Panel.Height * image_scale;
                HW_Rect.Y2 = HW_Rect.Y1 + Disp_Panel.Height;
            }
            HW_Update_Size();
        }
        public void HW_Update_Size()
        {
            HW.Top = (int)HW_Rect.X1;
            HW.Left = (int)HW_Rect.Y1;
            HW.Width = (int)HW_Rect.Width();
            HW.Height = (int)HW_Rect.Height();
        }
        public void HW_Buf_Set_Size(double x1, double y1, double x2, double y2)
        {
            HW_Buf_Rect = new stRect_Double(x1, y1, x2, y2);
            HW_Buf_Update_Size();
        }
        private void HW_Buf_Update_Size()
        {
            HW_Buf.Left = (int)HW_Buf_Rect.X1;
            HW_Buf.Top = (int)HW_Buf_Rect.Y1;
            HW_Buf.Width = (int)HW_Buf_Rect.Width();
            HW_Buf.Height = (int)HW_Buf_Rect.Height();
            HW_Buf.HalconWindow.SetPart((int)HW_Buf_Rect.Y1, (int)HW_Buf_Rect.X1,
                                        (int)HW_Buf_Rect.Y2, (int)HW_Buf_Rect.X2);
        }
        public void SetPart()
        {
            TJJS_Point ofs = new TJJS_Point();
            if (HW != null && HW_Buf != null)
            {
                ofs.Set(Ofs_X, Ofs_Y);
                HW_Rect_Part = HW_Rect / Disp_Scale + ofs;
                HW.HalconWindow.SetPart((int)HW_Rect_Part.Y1, (int)HW_Rect_Part.X1,
                                        (int)HW_Rect_Part.Y2, (int)HW_Rect_Part.X2);
                Set_Scroll_Box();
            };
        }
        public void SetPart(double x1, double y1, double x2, double y2)
        {
            if (x1 != HW_Rect_Part.X1 || y1 != HW_Rect_Part.Y1 ||
                x2 != HW_Rect_Part.X2 || y2 != HW_Rect_Part.Y2)
            {
                HW_Set_Size(x1, y1, x2, y2);
                Ofs_X = x1;
                Ofs_Y = y1;
                Disp_Scale = HW_Rect.Width() / HW_Buf_Rect.Width();
                SetPart();
            }
        }
        public void SetPart(double w, double h)
        {
            SetPart(0, 0, w, h);
        }
        public void SetPart(HImage image)
        {
            int w, h;

            if (!JJS_Vision.Is_Empty(image))
            {
                image.GetImageSize(out w, out h);
                SetPart_Image(w, h);
            }
        }
        public void SetPart_Image(double w, double h)
        {
            SetPart_Image(0, 0, w, h);
        }
        public void SetPart_Image(double x1, double y1, double x2, double y2)
        {
            if (Old_Part_X1 != x1 || Old_Part_Y1 != y1 || Old_Part_X2 != x2 || Old_Part_Y2 != y2)
            {
                Old_Part_X1 = (int)x1;
                Old_Part_Y1 = (int)y1;
                Old_Part_X2 = (int)x2;
                Old_Part_Y2 = (int)y2;

                HW_Buf_Set_Size(x1, y1, x2, y2);
                HW_Set_Size(x1, y1, x2, y2);
                Zoom_Windows_Fit();
            }
        }
        public void SetPart_Image(stRect_Double rect)
        {
            stRect_Double tmp_rect = rect;
            tmp_rect.Sort();
            SetPart_Image(tmp_rect.X1, tmp_rect.Y1, tmp_rect.X2, tmp_rect.Y2);
        }
        public void Copy_HW()
        {
            Copy_HW(HW_Buf, HW);
        }
        public void Copy_HW(HWindowControl sor_hw, HWindowControl dist_hw)
        {
            HImage dump_image;

            try
            {
                dump_image = new HImage();
                dump_image = sor_hw.HalconWindow.DumpWindowImage();
                //dist_hw.HalconWindow.ClearWindow();
                if (JJS_Vision.Is_Not_Empty(dump_image))
                    dump_image.DispObj(dist_hw.HalconWindow);
            }
            catch(Exception ex)
            {
   
            }
        }
        private void Disp_Panel_Resize(object sender, EventArgs e)
        {
            if (Init_Ok)
            {
                HW_Update_Size();
                SetPart();
                Copy_HW();
            }
        }
        private void Set_Scroll_Box()
        {
            On_Setting = true;
            ScrollBar_V.Maximum = (int)(HW_Buf_Rect.Width() - HW_Rect.X2 / Disp_Scale);
            ScrollBar_H.Maximum = (int)(HW_Buf_Rect.Height() - HW_Rect.Y2 / Disp_Scale);
            if (ScrollBar_V.Maximum < 0) ScrollBar_V.Maximum = 0;
            if (ScrollBar_H.Maximum < 0) ScrollBar_H.Maximum = 0;
            if (ScrollBar_V.Value > ScrollBar_V.Maximum) ScrollBar_V.Value = ScrollBar_V.Maximum;
            if (ScrollBar_H.Value > ScrollBar_H.Maximum) ScrollBar_H.Value = ScrollBar_H.Maximum;
            if (ScrollBar_V.Minimum < 0) ScrollBar_V.Minimum = 0;
            if (ScrollBar_H.Minimum < 0) ScrollBar_H.Minimum = 0;
            On_Setting = false;
        }
        private void ScrollBar_V_ValueChanged(object sender, EventArgs e)
        {
            if (!On_Setting && Init_Ok)
            {
                if (ScrollBar_V.Value < 0) ScrollBar_V.Value = 0;
                Ofs_X = ScrollBar_V.Value;
                SetPart();
                Copy_HW();
            }
        }
        private void ScrollBar_H_ValueChanged(object sender, EventArgs e)
        {
            if (!On_Setting && Init_Ok)
            {
                if (ScrollBar_H.Value < 0) ScrollBar_H.Value = 0;
                Ofs_Y = ScrollBar_H.Value;
                SetPart();
                Copy_HW();
            }
        }
        public void Get_Point(out double col, out double row, string color = "blue", bool snap = false, double snap_size = 10.0)
        {
            Get_Point_Snap_Flag = snap;
            Get_Point_Snap_Size = snap_size;
            Set_ToolBar(false);
            Focus();
            On_Get_Point_Flag = true;
            while (On_Get_Point_Flag) { Application.DoEvents(); };
            col = Mouse_X;
            row = Mouse_Y;            
            Set_ToolBar(true);
            Reflash = true;
        }
        public void Get_Rect1(out double col1, out double row1, out double col2, out double row2, string color = "blue")
        {
            Set_ToolBar(false);
            Focus();
            On_Get_Rect_Flag = true;
            HW.HalconWindow.SetColor(color);
            HW.HalconWindow.DrawRectangle1(out row1, out col1, out row2, out col2);
            On_Get_Rect_Flag = false;
            Set_ToolBar(true);
            Reflash = true;
        }
        public void Get_Rect2(out double col, out double row, out double len1, out double len2, out double phi, string color = "blue")
        {
            Set_ToolBar(false);
            Focus();
            On_Get_Rect_Flag = true;
            HW.HalconWindow.SetColor(color);
            HW.HalconWindow.DrawRectangle2(out row, out col, out len1, out len2, out phi);
            On_Get_Rect_Flag = false;
            Set_ToolBar(true);
            Reflash = true;
        }
        public void Zoom_Windows_HW(double col, double row, double disp_col, double disp_row, double scale)
        {
            Disp_Scale = scale;
            Ofs_X = col - disp_col / Disp_Scale;
            Ofs_Y = row - disp_row / Disp_Scale;
        }
        public void Zoom_In()
        {
            Zoom_Windows_HW(HW_Rect_Part.Center().X, HW_Rect_Part.Center().Y,
                            HW_Rect.Center().X, HW_Rect.Center().Y,
                            Disp_Scale * 1.1);
            HW.HalconWindow.ClearWindow();
            Reflash = true;
        }
        public void Zoom_Out()
        {
            Zoom_Windows_HW(HW_Rect_Part.Center().X, HW_Rect_Part.Center().Y,
                            HW_Rect.Center().X, HW_Rect.Center().Y,
                            Disp_Scale * 0.9);
            HW.HalconWindow.ClearWindow();
            Reflash = true;
        }
        public void Zoom_Window()
        {
            double x1, y1, x2, y2;
            double scale;

            Set_Button_Color(emJJS_HW_Mode.Zoom_Window);
            Get_Rect1(out x1, out y1, out x2, out y2);
            if (HW_Rect.Width() / (x2 - x1) < HW_Rect.Height() / (y2 - y1))
                scale = HW_Rect.Width() / (x2 - x1);
            else
                scale = HW_Rect.Height() / (y2 - y1);

            Zoom_Windows_HW((x2 + x1) / 2, (y2 + y1) / 2,
                            HW_Rect.Center().X, HW_Rect.Center().Y,
                            scale);
            Reflash = true;
            Set_Button_Color(emJJS_HW_Mode.None);
        }
        public void Zoom_X1()
        {
            Ofs_X = 0;
            Ofs_Y = 0;
            Disp_Scale = 1;
            HW_Rect.X1 = Disp_Panel.Top;
            HW_Rect.Y1 = Disp_Panel.Left;
            HW_Rect.X2 = Disp_Panel.Width;
            HW_Rect.Y2 = Disp_Panel.Height;
            if (HW_Rect.X2 > HW_Buf_Rect.X2) HW_Rect.X2 = HW_Buf_Rect.X2;
            if (HW_Rect.Y2 > HW_Buf_Rect.Y2) HW_Rect.Y2 = HW_Buf_Rect.Y2;
            HW_Update_Size();
            Reflash = true;
        }
        public void Zoom_X10()
        {
            double col = 0, row = 0;

            Set_Button_Color(emJJS_HW_Mode.Zoom_X10);
            Get_Point(out col, out row);
            Zoom_Windows_HW(col, row,
                            HW_Rect.Center().X, HW_Rect.Center().Y,
                            Disp_Scale * 10);
            Reflash = true;
            Set_Button_Color(emJJS_HW_Mode.None);
        }
        public void Zoom_Windows_Fit()
        {
            HW_Set_Size(HW_Buf_Rect.X1, HW_Buf_Rect.Y1, HW_Buf_Rect.X2, HW_Buf_Rect.Y2);
            Ofs_X = 0;
            Ofs_Y = 0;
            Disp_Scale = HW_Rect.Width() / HW_Buf_Rect.Width();
            Reflash = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            //if (!On_Get_Point_Flag && !On_Get_Rect_Flag)
            {

                if (Reflash)
                {
                    Reflash = false;
                    if (JJS_HW_Reflash != null) JJS_HW_Reflash(this);
                    Set_Button_Color(Mode);
                    SetPart();
                    Copy_HW();
                    if (On_Get_Point_Flag) Draw_Select_Line();

                }
            }
            timer1.Enabled = true;
        }
        private void B_System_Click(object sender, EventArgs e)
        {
            THalcon_System_Param param = new THalcon_System_Param(HW_Buf);
            if (param.Edit_Param())
            {
                Reflash = true;
            }
        }

    }
}