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
    public partial class TForm_Select_Threshold : Form
    {
        public string            Image_Type;
        public long              Image_Width,
                                 Image_Height;
        public int               Threshold_Min,
                                 Threshold_Max;

        public HImage            Image = new HImage();
        public HRegion           Seleect_Region = new HRegion();
        public TFrame_JJS_HW     JJS_HW = null;

        public TForm_Select_Threshold()
        {
            InitializeComponent();
        }
        private void TForm_Select_Threshold_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            JJS_HW = tFrame_JJS_HW1;
            JJS_HW.Init();
            JJS_HW.SetPart(Image);
            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
            JJS_HW.Copy_HW();
            JJS_HW.HW_Param.Set_Line_Width(JJS_HW.HW.Width, Image_Width, 2);
        }
        public void Get_Param()
        {
            Threshold_Min = Convert.ToInt32(E_Threshold_Min.Text);
            Threshold_Max = Convert.ToInt32(E_Threshold_Max.Text);
            if (Threshold_Max < Threshold_Min) Threshold_Max = Threshold_Min;
        }
        public void Set_Param()
        {
            E_Threshold_Min.Text = Threshold_Min.ToString();
            E_Threshold_Max.Text = Threshold_Max.ToString();
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        public void Update_View()
        {
            Get_Param();
            Seleect_Region = Image.Threshold((double)Threshold_Min, (double)Threshold_Max);
            Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
            JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
            JJS_HW.HW_Buf.HalconWindow.SetColor("red");
            JJS_HW.HW_Buf.HalconWindow.SetDraw("fill");
            Seleect_Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
            JJS_HW.Copy_HW();
        }
        private void E_Threshold_Min_TextChanged(object sender, EventArgs e)
        {
            SB_Threshold_Min.Value = Convert.ToInt32(E_Threshold_Min.Text);
            Update_View();
        }
        private void E_Threshold_Max_TextChanged(object sender, EventArgs e)
        {
            SB_Threshold_Max.Value = Convert.ToInt32(E_Threshold_Max.Text);
            Update_View();
        }
        private void SB_Threshold_Min_Scroll(object sender, ScrollEventArgs e)
        {
            E_Threshold_Min.Text = SB_Threshold_Min.Value.ToString();
            Update_View();
        }
        private void SB_Threshold_Max_Scroll(object sender, ScrollEventArgs e)
        {
            E_Threshold_Max.Text = SB_Threshold_Max.Value.ToString();
            Update_View();
        }

        private void tFrame_JJS_HW1_JJS_HW_Reflash(TFrame_JJS_HW jjs_hw)
        {
            Update_View();
        }

    }
}
