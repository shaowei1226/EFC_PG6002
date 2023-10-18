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
    public partial class TForm_Input_CMD_Name : Form
    {
        public string CMD_Name
        {
            get
            {
                return E_CMD_Name.Text;
            }
        }
        public TForm_Input_CMD_Name(string name)
        {
            InitializeComponent();
            E_CMD_Name.Text = name;
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
    static public class Input_CMD_Name
    {
        static public bool Input(ref string cmd_name)
        {
            bool result = false;
            TForm_Input_CMD_Name form = new TForm_Input_CMD_Name(cmd_name);

            if (form.ShowDialog() == DialogResult.OK)
            {
                cmd_name = form.CMD_Name;
                result = true;
            }
            return result;
        }
    }
}
