using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFC.HMI
{
    public partial class TForm_Keybord : Form
    {
        public double Value = 0.0;
        public string Format;

        public TForm_Keybord()
        {
            InitializeComponent();
            E_Value.Focus();
        }
        private void TForm_Keybord_Shown(object sender, EventArgs e)
        {
            E_Value.SelectAll();
        }
        public void Set_Param(double value, string format)
        {
            Value = value;
            Format = format;
            E_Value.Text = Value.ToString(Format);
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                Value = Convert.ToDouble(E_Value.Text);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch 
            {
                MessageBox.Show("輸入資料錯誤,無法成功轉換", "資料錯誤", MessageBoxButtons.OK);
            }
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void Set_Key(string key)
        {
            E_Value.Focus();
            SendKeys.Send(key);

        }
        private void B_0_Click(object sender, EventArgs e)
        {
            Set_Key("0");
        }
        private void B_1_Click(object sender, EventArgs e)
        {
            Set_Key("1");
        }
        private void B_2_Click(object sender, EventArgs e)
        {
            Set_Key("2");
        }
        private void B_3_Click(object sender, EventArgs e)
        {
            Set_Key("3");
        }
        private void B_4_Click(object sender, EventArgs e)
        {
            Set_Key("4");
        }
        private void B_5_Click(object sender, EventArgs e)
        {
            Set_Key("5");
        }
        private void B_6_Click(object sender, EventArgs e)
        {
            Set_Key("6");
        }
        private void B_7_Click(object sender, EventArgs e)
        {
            Set_Key("7");
        }
        private void B_8_Click(object sender, EventArgs e)
        {
            Set_Key("8");
        }
        private void B_9_Click(object sender, EventArgs e)
        {
            Set_Key("9");
        }
        private void B_Dot_Click(object sender, EventArgs e)
        {
            Set_Key(".");
        }
        private void button14_Click(object sender, EventArgs e)
        {
            Set_Key("-");
        }
        private void B_Del_Click(object sender, EventArgs e)
        {
            Set_Key("{DEL}");
        }
        private void B_Left_Click(object sender, EventArgs e)
        {
            Set_Key("{LEFT}");
        }
        private void B_Right_Click(object sender, EventArgs e)
        {
            Set_Key("{RIGHT}");
        }
        private void B_CLR_Click(object sender, EventArgs e)
        {
            E_Value.Focus();
            E_Value.Text = "";
        }
    }
}
