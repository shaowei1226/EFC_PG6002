using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class TForm_Select_Path : Form
    {
        public string              Default_Path,
                                   Path_Name,
                                   Check_File;
        public string              Dialog_Type; 
        public TForm_Select_Path()
        {
            InitializeComponent();
            Default_Path = "";
            Path_Name = "";
            Check_File = "";
            Dialog_Type = "OpenDialog";
        }

        public void Update_List()
        {
            string file_name, path_name;

            LB_Path.Items.Clear();
            List<string> dirs = new List<string>(System.IO.Directory.EnumerateDirectories(Default_Path));
            foreach (string dir in dirs)
            {
                path_name = System.IO.Path.GetFileName(dir);
                if (Check_File != "")
                {
                    file_name = dir + "\\" + Check_File;
                    if (System.IO.File.Exists(file_name))
                        LB_Path.Items.Add(path_name);
                }
                else
                    LB_Path.Items.Add(path_name);
            }
        }

        private void TForm_Select_Path_Shown(object sender, EventArgs e)
        {
            int no;

            if (Dialog_Type == "OpenDialog")
            {
                Text = "Open File Dialog";
                E_Select_File.Enabled = false;
            }
            else
            {
                Text = "Save File Dialog";
                E_Select_File.Enabled = true;
            }

            E_Sor_File.Text = Path_Name;
            E_Select_File.Text = Path_Name;
            Update_List();
            no = LB_Path.Items.IndexOf(Path_Name);
            if (no != -1)
            {
                LB_Path.SelectedIndex = no;
            }
        }
        private void LB_Path_Click(object sender, EventArgs e)
        {
            if (LB_Path.SelectedItem != null)
                E_Select_File.Text = LB_Path.SelectedItem.ToString();
        }
        public void Apply()
        {
            Path_Name = E_Select_File.Text;

            if (Dialog_Type == "SaveDialog")
            {
                if (E_Select_File.Text != "")
                {
                    Path_Name = E_Select_File.Text;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                if (LB_Path.Items.IndexOf(E_Select_File.Text) != -1)
                {
                    Path_Name = E_Select_File.Text;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Apply();
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void LB_Path_DoubleClick(object sender, EventArgs e)
        {
            if (LB_Path.Items.IndexOf(E_Select_File.Text) != -1)
            {
                Apply();
            }
        }
    }
}
