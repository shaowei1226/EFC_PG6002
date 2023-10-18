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
    public partial class TForm_Inport_CMD : Form
    {
        public THalcon_Tool_File CMD_File = new THalcon_Tool_File();
        public TCommand_Define Select_CMD = new TCommand_Define();
 

        public TForm_Inport_CMD()
        {
            InitializeComponent();
        }
        public void Set_Param(string filename)
        {
            CMD_File.Read(filename);
            Set_List();
        }
        public void Set_List()
        {
            ListBox lb = null;
            TCommand_Define cmd;

            cmd = CMD_File.CMD;
            lb = listBox1;
            lb.Items.Clear();
            for (int i = 0; i < cmd.User_Cmd_List_Count; i++)
            {
                lb.Items.Add(cmd.User_Cmd_List[i].Name);
            }
            if (lb.Items.Count > 0) lb.SelectedIndex = 0;
        }
        public void Update_Param()
        {
            int no = -1;

            Select_CMD.User_Cmd_List_Count = 0;
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                no = listBox1.Items.IndexOf(listBox1.SelectedItems[i]);
                if (no >= 0)
                    Select_CMD.Add_User_Cmd_List(CMD_File.CMD.User_Cmd_List[no]);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
