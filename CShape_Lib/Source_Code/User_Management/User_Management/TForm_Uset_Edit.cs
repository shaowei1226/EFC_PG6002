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
    public enum emUser_Info_Type { RFID, User};
    public enum emForm_Mode { Add, Edit };
    public partial class TForm_Uset_Edit : Form
    {
        public User_Manager Manager = null;
        public TUser_List User_List = null;
        public TUser_Info Param = new TUser_Info();
        public emForm_Mode Form_Mode = emForm_Mode.Add;
        public emUser_Info_Type User_Type = emUser_Info_Type.RFID;
        public string RFID_Code = "";
        public bool Reflash_Code = false;

        public TForm_Uset_Edit(User_Manager manager, TUser_List user_list, TUser_Info user, emForm_Mode f_mode, emUser_Info_Type type)
        {
            InitializeComponent();
            Manager = manager;
            User_List = user_list;
            Param.Set(user);
            Form_Mode = f_mode;
            User_Type = type;
            Set_Param();
            Manager.On_Reader_Read += On_Reader_Read;
        }
        private void TForm_Uset_Edit_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        public void Set_Param()
        {
            E_ID.Text = Param.ID;
            E_Name.Text = Param.Name;
            E_Password1.Text = Param.Password;
            E_Password2.Text = Param.Password;
            CB_Level.Text = Param.Level.ToString();

            if (Param.Type == emUser_Info_Type.User) CB_Type.SelectedIndex = 0;
            if (Param.Type == emUser_Info_Type.RFID) CB_Type.SelectedIndex = 1;

            if (Param.Display) CB_Display.SelectedIndex = 1;
            else CB_Display.SelectedIndex = 0;

            E_Info.Text = Param.Info;

            if (Form_Mode == emForm_Mode.Edit)
            {
                E_ID.Enabled = false;
                E_Name.Enabled = false;
                CB_Type.Enabled = false;
                CB_Display.Enabled = false;
            }

            if (User_Type == emUser_Info_Type.RFID)
            {
                E_ID.Enabled = false;
                //E_Name.Enabled = false;
                //E_Password1.Enabled = false;
                //E_Password2.Enabled = false;
                //CB_Level.Enabled = false;
                CB_Type.Enabled = false;
                CB_Display.Enabled = false;
                //E_Info.Enabled = false;
            }
        }
        public void Get_Param()
        {
            if (E_Password1.Text == E_Password2.Text)
            {
                Param.ID = E_ID.Text;
                Param.Name = E_Name.Text;
                Param.Password = E_Password1.Text;

                if (CB_Type.SelectedIndex == 0) Param.Type = emUser_Info_Type.User;
                if (CB_Type.SelectedIndex == 1) Param.Type = emUser_Info_Type.RFID;

                if (CB_Display.SelectedIndex == 1) Param.Display = true;
                else Param.Display = false;

                Param.Info = E_Info.Text;
                try
                {
                    Param.Level = Convert.ToInt32(CB_Level.Text);
                }
                catch { }
            }
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            bool flag = false;
            Manager.On_Reader_Read -= On_Reader_Read;

            Get_Param();
            if (Form_Mode == emForm_Mode.Add)
            {
                if (User_List.IndexOf_ID(Param.ID) >= 0) MessageBox.Show("使用者 ID 已存在。", "錯誤", MessageBoxButtons.OK);
                else if (Param.Name == "") MessageBox.Show("使用者 名稱 不能為空白。", "錯誤", MessageBoxButtons.OK);
                else if (User_List.IndexOf_Name(Param.Name) >= 0) MessageBox.Show("使用者 名稱 已存在。", "錯誤", MessageBoxButtons.OK);
                else if (E_Password1.Text != E_Password2.Text) MessageBox.Show("密碼錯誤,請確認密碼。", "錯誤", MessageBoxButtons.OK);
                else flag = true;
            }
            else flag = true;

            if (flag)
                DialogResult = System.Windows.Forms.DialogResult.OK;
           
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Manager.On_Reader_Read -= On_Reader_Read;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void On_Reader_Read(object sender, string code)
        {
            RFID_Code = code;
            Reflash_Code = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (Reflash_Code) RFID_Read_In(RFID_Code);
            timer1.Enabled = true;
        }
        private void RFID_Read_In(string code)
        {
            Reflash_Code = false;
            TUser_Info tmp_user = User_List[code];
            if (tmp_user != null) tmp_user.Copy(Param);
            Param.ID = code;
            Param.Type = emUser_Info_Type.RFID;
            Param.Display = false;
            Set_Param();
        }

    }
}
