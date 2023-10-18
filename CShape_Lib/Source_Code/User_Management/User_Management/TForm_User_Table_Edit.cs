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
    public partial class TForm_User_Table_Edit : Form
    {
        public User_Manager Manager = null;
        public TUser_List User_List = new TUser_List();

        public TForm_User_Table_Edit(User_Manager param)
        {
            InitializeComponent();
            Manager = param;
            User_List.Set(Manager.User_List);
            Manager.RFID_Login = false;
            Set_Param();
        }
        public void Set_Param()
        {
            DataGridView dg = dataGridView1;
            TUser_Info user = null;
            int no = 0;
            int s_no = 0;
            if (dg.CurrentRow != null) s_no = dg.CurrentRow.Index;

            dg.Columns.Clear();
            dg.Columns.Add("Index", "Index");
            dg.Columns[no++].Width = 60;

            dg.Columns.Add(TUser_Info.TableName_ID, TUser_Info.TableName_ID);
            dg.Columns[no++].Width = 200;

            dg.Columns.Add(TUser_Info.TableName_Name, TUser_Info.TableName_Name);
            dg.Columns[no++].Width = 300;

            dg.Columns.Add(TUser_Info.TableName_Level, TUser_Info.TableName_Level);
            dg.Columns[no++].Width = 60;

            dg.Columns.Add(TUser_Info.TableName_Type, TUser_Info.TableName_Type);
            dg.Columns[no++].Width = 60;

            dg.Columns.Add(TUser_Info.TableName_Display, TUser_Info.TableName_Display);
            dg.Columns[no++].Width = 60;

            dg.RowCount = User_List.Count;
            for (int i = 0; i < User_List.Count; i++)
            {
                user = User_List[i];
                dg.Rows[i].Cells[0].Value = (i+1).ToString();
                dg.Rows[i].Cells[1].Value = user.ID;
                dg.Rows[i].Cells[2].Value = user.Name;
                dg.Rows[i].Cells[3].Value = user.Level;
                dg.Rows[i].Cells[4].Value = user.Type;
                dg.Rows[i].Cells[5].Value = user.Display;
            }

            if (s_no >= dg.RowCount) s_no = dg.RowCount - 1;
            if (s_no >= 0) dg.CurrentCell = dg.Rows[s_no].Cells[0];
        }
        private void B_Edit_Click(object sender, EventArgs e)
        {
            int no = 0;
            TUser_Info user = null;
            if (dataGridView1.CurrentRow != null)
            {
                no = dataGridView1.CurrentRow.Index;
                user = User_List[no];
                switch (user.Type)
                {
                    case emUser_Info_Type.User:
                        if (Manager.User_Edit(User_List, ref user))
                        {
                            User_List.Set_User(user);
                            Set_Param();
                        }
                        break;

                    case emUser_Info_Type.RFID:
                        if (Manager.User_RFID_Edit(User_List, ref user))
                        {
                            User_List.Set_User(user);
                            Set_Param();
                        }
                        break;
                }
            }
        }
        private void B_Add_Click(object sender, EventArgs e)
        {
            TUser_Info user = new TUser_Info();
            if (Manager.User_Add(User_List, ref user))
            {
                User_List.Add(user);
                Set_Param();
            }
        }
        private void B_RFID_Add_Click(object sender, EventArgs e)
        {
            TUser_Info user = new TUser_Info();
            user.Type = emUser_Info_Type.RFID;
            user.Display = false;
            if (Manager.User_RFID_Add(User_List, ref user))
            {
                User_List.Add(user);
                Set_Param();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int no = 0;
            if (dataGridView1.CurrentRow != null)
            {
                no = dataGridView1.CurrentRow.Index;
                User_List.RemoveAt(no);
                Set_Param();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
