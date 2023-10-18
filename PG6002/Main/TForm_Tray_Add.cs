using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;

namespace Main
{
    public partial class TForm_Tray_Add : Form
    {
        public TTray_Param Param = new TTray_Param();

        public TForm_Tray_Add()
        {
            InitializeComponent();
        }
        public void Set_Param(TTray_Param param)
        {
            Param.Set(param);
            CB_Group.SelectedIndex = Param.Group;
            CB_Dir.SelectedIndex = Param.Dir;
            E_Start_X.Text = Param.Start_X.ToString("0.000");
            E_Start_Y.Text = Param.Start_Y.ToString("0.000");
            E_Pitch_X.Text = Param.Pitch_X.ToString("0.000");
            E_Pitch_Y.Text = Param.Pitch_Y.ToString("0.000");
            E_Num_X.Text = Param.Num_X.ToString("0");
            E_Num_Y.Text = Param.Num_Y.ToString("0");
        }
        public void Update_Param()
        {
            Param.Group = CB_Group.SelectedIndex;
            Param.Dir = CB_Dir.SelectedIndex;
            Param.Start_X = Convert.ToDouble(E_Start_X.Text);
            Param.Start_Y = Convert.ToDouble(E_Start_Y.Text);
            Param.Pitch_X = Convert.ToDouble(E_Pitch_X.Text);
            Param.Pitch_Y = Convert.ToDouble(E_Pitch_Y.Text);
            Param.Num_X =  Convert.ToInt32(E_Num_X.Text);
            Param.Num_Y =  Convert.ToInt32(E_Num_Y.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }

    public class TTray_Param : TBase_Class
    {
        public int Group;
        public int Dir;
        public double Start_X;
        public double Start_Y;
        public double Pitch_X;
        public double Pitch_Y;
        public double Num_X;
        public double Num_Y;

        public TTray_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTray_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTray_Param && dis_base is TTray_Param)
            {
                TTray_Param sor = (TTray_Param)sor_base;
                TTray_Param dis = (TTray_Param)dis_base;

                dis.Group = sor.Group;
                dis.Dir = sor.Dir;
                dis.Start_X = sor.Start_X;
                dis.Start_Y = sor.Start_Y;
                dis.Pitch_X = sor.Pitch_X;
                dis.Pitch_Y = sor.Pitch_Y;
                dis.Num_X = sor.Num_X;
                dis.Num_Y = sor.Num_Y;
            }
        }


        public void Set_Default()
        {
            Group = 1;
            Dir = 0;
            Start_X = 0;
            Start_Y = 0;
            Pitch_X = 10;
            Pitch_Y = 10;
            Num_X = 1;
            Num_Y = 1;
        }
    }
}
