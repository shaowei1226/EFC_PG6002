using System;
using System.Collections;
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
    public partial class TForm_RFID_Login : Form
    {
        public User_Manager Manager = null;
        public TUser_Info User = new TUser_Info();

        public TForm_RFID_Login(User_Manager manager, TUser_Info user)
        {
            InitializeComponent();
            Manager = manager;
            User.Set(user);
        }
        private void TForm_Password_Shown(object sender, EventArgs e)
        {
            Set_Param();
        }
        public void Set_Param()
        {
            E_User_ID.Text = User.ID;
            E_User_Name.Text = User.Name;
            E_Password1.Text = "";
            L_Change_Password.Enabled = (User.Level >= 1);
            L_User_Manager.Enabled = (User.Level >= 1);
        }
        private void B_Login_Click(object sender, EventArgs e)
        {
            TUser_Info tmp_user = Manager.User_List[User.ID];
            if (tmp_user != null && tmp_user.Password == E_Password1.Text )
            {
                Manager.Log_User_Login(tmp_user);
                tmp_user.Copy(User);
                B_Login.Text = "登入成功";
                Set_Param();
            }
            else E_Password1.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void L_User_Manager_Click(object sender, EventArgs e)
        {
            if (Manager.User_Table_Edit())
            {
            }
        }
        private void L_Change_Password_Click(object sender, EventArgs e)
        {
            if (Manager.User_Change_Password(ref User))
            {
            }
        }
    }
}
