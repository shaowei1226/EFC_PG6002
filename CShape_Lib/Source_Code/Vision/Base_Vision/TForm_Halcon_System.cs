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
    public partial class TForm_Halcon_System : Form
    {
        public int Line_Width = 1;
        public int Colored = 12;
        public string Draw = "fill";

        public TForm_Halcon_System()
        {
            InitializeComponent();
        }
        public void Set_Param(THalcon_System_Param param)
        {
            Line_Width = param.Line_Width;
            Colored = param.Colored;
            Draw = param.Draw;

            CB_Line_Width.Text = Line_Width.ToString();
            CB_Colored.Text = Colored.ToString();
            CB_Draw.Text = Draw;
        }
        public void Update_Param()
        {
            Line_Width = Convert.ToInt32(CB_Line_Width.Text);
            Colored = Convert.ToInt32(CB_Colored.Text);
            Draw = CB_Draw.Text;
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
    }

}
