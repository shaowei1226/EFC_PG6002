using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;

namespace EFC.HMI
{
    public partial class TForm_HMI_ImageList : Form
    {
        public THMI_Image_Box_List Param = new THMI_Image_Box_List();
        public TFrame_ImageList[] Database_Images = new TFrame_ImageList[0];
        public int Select_Index = -1;
        public string Select_Name = "";


        public TForm_HMI_ImageList(THMI_Image_Box_List param)
        {
            InitializeComponent();
            param.Copy(ref Param);
            Set_Image_Databae();
        }
        private void Set_Image_Databae()
        {
            THMI_Image_Box tmp_obj = null;

            if (Param != null)
            {
                listBox1.Items.Clear();
                for (int i = 0; i < Param.Count; i++)
                {
                    tmp_obj = Param[i];
                    listBox1.Items.Add(tmp_obj.Name);
                }
            }
        }
        private void Set_Database_Image_List(THMI_Image_Box list)
        {
            ImageList tmp_list = null;
            if (list != null)
            {
                flowLayoutPanel1.Controls.Clear();
                tmp_list = list.ImageList;
                Database_Images = new TFrame_ImageList[tmp_list.Images.Count];
                for (int i = 0; i < Database_Images.Length; i++)
                {
                    Database_Images[i] = new TFrame_ImageList();
                    Database_Images[i].Name = "JJS_PictureBox" + (i + 1).ToString();
                    Database_Images[i].Set_Bitmap(tmp_list, i);
                    Database_Images[i].PB_Bitmap.Tag = i;
                    Database_Images[i].PB_Bitmap.MouseClick += Image_MouseClick;
                    flowLayoutPanel1.Controls.Add(Database_Images[i]);
                }
            }
        }
        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox obj = (PictureBox)sender;

            if (Select_Index >= 0) Database_Images[Select_Index].BackColor = Color.Gray;
            Select_Index = (int)obj.Tag;
            Database_Images[Select_Index].BackColor = Color.Yellow;
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Load_Click(object sender, EventArgs e)
        {
            string path = "";
            System.Windows.Forms.FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = Param.Database_Path;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = dialog.SelectedPath + "\\";
                Param.Database_Path = path;
                Set_Image_Databae();
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int no = listBox1.SelectedIndex;

            Select_Name = (string)listBox1.Items[no];
            Set_Database_Image_List(Param[Select_Name]);
        }
    }
}
