using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFC.Vision.Halcon
{
    public partial class TForm_Input_Password : Form
    {
        public string Password
        {
            get
            {
                return E_Password.Text;
            }
        }
        public TForm_Input_Password()
        {
            InitializeComponent();
        }
        private void TForm_Uset_Edit_Shown(object sender, EventArgs e)
        {
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
    static public class Input_Password
    {
        static public bool Check(string password)
        {
            bool result = false;
            TForm_Input_Password form = new TForm_Input_Password();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Password == password) result = true;
                else MessageBox.Show("輸入密碼錯誤。", "錯誤", MessageBoxButtons.OK);
            }
            return result;
        }
    }
}
