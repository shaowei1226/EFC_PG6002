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
    public partial class TForm_User_Login : Form
    {
        public User_Manager Param = null;
        public TUser_Info User = new TUser_Info();

        public TForm_User_Login(User_Manager param, TUser_Info user)
        {
            InitializeComponent();
            Param = param;
            user.Copy(User);
            Set_User_Name();
        }
        private void TForm_Password_Shown(object sender, EventArgs e)
        {
            Set_Param();
        }
        public void Set_Param()
        {
            CB_User_Name.Text = User.Name;
            E_Password1.Text = User.Password;
            L_Change_Password.Enabled = (User.Level >= 1);
            L_User_Manager.Enabled = (User.Level >= 2);
        }
        public void Set_User_Name()
        {
            ArrayList name_list = Param.Get_Name_List();

            CB_User_Name.Items.Clear();
            for (int i = 0; i < name_list.Count; i++) CB_User_Name.Items.Add(name_list[i].ToString());
            if (CB_User_Name.Items.Count > 0) CB_User_Name.SelectedIndex = 0;
        }
        private void B_Login_Click(object sender, EventArgs e)
        {
            TUser_Info tmp_user = null;

            int pos = Param.User_List.IndexOf_Name(CB_User_Name.Text);
            if (pos >= 0) tmp_user = Param.User_List[pos];
            if (tmp_user != null && tmp_user.Type == emUser_Info_Type.User && tmp_user.Password == E_Password1.Text)
            {
                Param.Log_User_Login(tmp_user);
                tmp_user.Copy(User);
                B_Login.Text = "登入成功";
                Set_Param();
            }
            else
            {
                E_Password1.Text = "";
                B_Login.Text = "登入失敗";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void L_Change_Password_Click(object sender, EventArgs e)
        {
            if (Param.User_Change_Password(ref User))
            {
            }
        }
        private void L_User_Manager_Click(object sender, EventArgs e)
        {
            if (Param.User_Table_Edit())
            {
                Set_User_Name();
            }
        }
    }
}
