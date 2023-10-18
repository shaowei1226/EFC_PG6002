using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double row, col;
            HW.HalconWindow.DrawPoint(out row, out col);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double r1, c1, r2, c2;
            Random r = new Random();

            r1 = r.Next(0, 300);
            c1 = r.Next(0, 300);
            r2 = r.Next(0, 300);
            c2 = r.Next(0, 300);
            HW.HalconWindow.DispLine(r1, c1, r2, c2);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}
