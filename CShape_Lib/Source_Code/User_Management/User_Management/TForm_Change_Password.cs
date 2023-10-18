using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFC.User_Manager
{
    public partial class TForm_Change_Password : Form
    {
        public TUser_Info Param = new TUser_Info();

        public TForm_Change_Password(TUser_Info user)
        {
            InitializeComponent();
            Param.Set(user);
            Set_Param();
        }
        private void TForm_Uset_Edit_Shown(object sender, EventArgs e)
        {
        }
        public void Set_Param()
        {
            E_ID.Text = Param.ID;
            E_Name.Text = Param.Name;
            E_Password1.Text = Param.Password;
            E_Password2.Text = Param.Password;
        }
        public void Get_Param()
        {
            if (E_Password1.Text == E_Password2.Text)
            {
                Param.ID = E_ID.Text;
                Param.Name = E_Name.Text;
                Param.Password = E_Password1.Text;
            }
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Get_Param();
            if (E_Password1.Text != E_Password2.Text) 
                MessageBox.Show("密碼錯誤,請確認密碼。", "錯誤", MessageBoxButtons.OK);
            else 
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
