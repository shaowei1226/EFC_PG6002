using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Vision.Halcon;
using HalconDotNet;

namespace Main
{
    public delegate void evDisplay(ref TFrame_JJS_HW jjs_hw, int index, bool fore_disp);

    public partial class TFrame_Display : UserControl
    {
        public static int Max_Count = 24;
        private int Page_Count = 20;
        public bool Init_Flag = false;
        public int[] Index = new int[Max_Count];
        public TFrame_JJS_HW[] JJS_HW = new TFrame_JJS_HW[Max_Count];
        public TFrame_JJS_HW JJS_HW_One = null;
        public evDisplay On_Display = null;
        private bool Disp_Single = false;
        private int Single_No = 0;

        private int tmp_Num_X;
        private int tmp_Num_Y;
        private int tmp_Width;
        private int tmp_Height;

        public bool Disp_Enabled
        {
            get
            {
                return timer1.Enabled;
            }
            set
            {
                timer1.Enabled = value;
            }
        }
        public TFrame_Display()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            for (int i = 0; i < JJS_HW.Length; i++)
            {
                JJS_HW[i] = new TFrame_JJS_HW();
                JJS_HW[i].Only_Window = false;
                JJS_HW[i].HW.Tag = i;
                JJS_HW[i].JJS_HW_MouseDown += JJS_HW_JJS_HW_MouseDown;
                Controls.Add(JJS_HW[i]);
            }
            JJS_HW_One = new TFrame_JJS_HW();
            JJS_HW_One.Tag = 0;
            JJS_HW_One.Dock = DockStyle.Fill;
            JJS_HW_One.JJS_HW_MouseDown += JJS_HW_One_JJS_HW_MouseDown;
            Controls.Add(JJS_HW_One);

            for (int i = 0; i < Index.Length; i++) Index[i] = i;
            Init_Flag = true;
        }
        private void TFrame_Display_Resize(object sender, EventArgs e)
        {
            Set_HW_Size(tmp_Num_X, tmp_Num_Y, Index, tmp_Width, tmp_Height);
            Repaint();
        }
        public void Set_HW_Size(int x_num, int y_num, int[] index, int w = 640, int h = 480)
        {
            HImage image = new HImage();
            Rectangle[] rect;

            if (x_num * y_num <= Max_Count && x_num <= 6 && y_num <= 4)
            {
                tmp_Num_X = x_num;
                tmp_Num_Y = y_num;
                tmp_Width = w;
                tmp_Height = h;
                Page_Count = x_num * y_num;

                Set_Index(index);
                rect = JJS_Vision.Get_Window_Rect(ClientRectangle, new Rectangle(0, 0, w, h), x_num, y_num);
                for (int i = 0; i < rect.Length; i++)
                {
                    Set_HW_Size(JJS_HW[i], rect[i]);
                }
                Update_HW_View();
                Disp_View();
            }
        }
        public void Set_Index(int[] index)
        {
            for(int i=0; i< index.Length; i++)
            {
                if (i < index.Length) Index[i] = index[i];
                else Index[i] = 0;
            }
        }
        public void Repaint()
        {
            Disp_View();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Disp_View(false);
            timer1.Enabled = true;
        }
        private void Disp_View(bool fore_disp = true)
        {
            if (Disp_Single)
                Disp_View_X1(fore_disp);
            else
                Disp_View_nXn(fore_disp);
        }
        private void Disp_View_X1(bool fore_disp = true)
        {
            if (JJS_HW_One.Visible)
            {
                if (On_Display != null && JJS_HW_One.Visible) On_Display(ref JJS_HW_One, Get_Index(Single_No), fore_disp);
            }
        }
        private void Disp_View_nXn(bool fore_disp = true)
        {
            for (int i = 0; i < Page_Count; i++)
            {
                if (JJS_HW[i].Visible)
                {
                    if (On_Display != null) On_Display(ref JJS_HW[i], Get_Index(i), fore_disp);
                }
            }
        }
        private int Get_Index(int no)
        {
            int result = 0;

            if (no < Index.Length) result = Index[no];
            return result;
        }
        private void Update_HW_View()
        {
            if (Disp_Single)
            {
                for (int i = 0; i < JJS_HW.Length; i++) JJS_HW[i].Visible = false;
                JJS_HW_One.Visible = true;
            }
            else
            {
                JJS_HW_One.Visible = false;
                for (int i = 0; i < JJS_HW.Length; i++)
                {
                    JJS_HW[i].Zoom_Windows_Fit();
                    if (i < Page_Count)
                        JJS_HW[i].Visible = true;
                    else
                        JJS_HW[i].Visible = false;
                }
            }
        }
        private void JJS_HW_JJS_HW_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                HalconDotNet.HWindowControl hw = (HalconDotNet.HWindowControl)sender;
                Single_No = (int)hw.Tag;
                Disp_Single = true;
                Update_HW_View();
                Disp_View();
            }
        }
        private void JJS_HW_One_JJS_HW_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Disp_Single = false;
                Update_HW_View();
                Disp_View();
            }
        }
        private void Set_HW_Size(TFrame_JJS_HW hw, Rectangle rect)
        {
            hw.Top = rect.Top;
            hw.Left = rect.Left;
            hw.Width = rect.Width;
            hw.Height = rect.Height;
        }

    }
}
