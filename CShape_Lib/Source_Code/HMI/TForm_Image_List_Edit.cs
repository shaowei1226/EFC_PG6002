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
using System.Threading;
using EFC.Tool;

namespace EFC.HMI
{
    public partial class TForm_Image_List_Edit : Form
    {
        public ImageList Param = new ImageList();
        public int Select_Index = -1;
        private ArrayList Do_Work_File_List = null;

        public TForm_Image_List_Edit(ImageList list)
        {
            InitializeComponent();
            Set_Param(list);
        }
        private void Set_Param(ImageList param)
        {
            Param = HMI_Tool.Copy_ImageList(param);
            Image_List_Clear();
            for (int i = 0; i < Param.Images.Count; i++)
            {
                Image_List_Add(Param.Images.Keys[i], Param.Images[i]);
            }
        }
        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            int index = Get_Image_Index(sender);
            Select_Image(index);
        }
        public int Get_Image_Index(object sender)
        {
            int result = -1;


            PictureBox p = (PictureBox)sender;
            string n = p.Parent.Name;

            if (p.Parent is TFrame_ImageList)
            {
                TFrame_ImageList tmp_obj = (TFrame_ImageList)p.Parent;
                result = flowLayoutPanel1.Controls.IndexOf(tmp_obj);
            }
            return result;
        }
        public void Select_Image(int index)
        {
            if (index >= 0 && index < flowLayoutPanel1.Controls.Count)
            {
                Set_Image_Color(Select_Index, Color.Gray);
                Set_Image_Color(index, Color.Yellow);
                Select_Index = index;
            }
        }
        public void Set_Image_Color(int index, Color color)
        {
            TFrame_ImageList tmp_obj = null;

            if (index >= 0 && index < flowLayoutPanel1.Controls.Count)
            {
                tmp_obj = (TFrame_ImageList)flowLayoutPanel1.Controls[index];
                tmp_obj.BackColor = color;
            }
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void MI_Load_Path_Click(object sender, EventArgs e)
        {
        }

        private void Image_List_Add(string key, Image in_image)
        {
            //TFrame_Image_List tmp_obj = null;
            int no = 0;
            
            if (Param.Images.Keys.IndexOf(key) < 0)
            {
                no = Param.Images.Count;
                Param.Images.Add(key, in_image);
                //tmp_obj = new TFrame_Image_List();
                ////tmp_obj.Name = "JJS_PictureBox" + (Serial_No++).ToString();
                //tmp_obj.Set_Bitmap(Param, no);
                //tmp_obj.PB_Bitmap.MouseClick += Image_MouseClick;
                //flowLayoutPanel1.Controls.Add(tmp_obj);
            }
        }
        private void Image_List_Add(string filename)
        {
            string key = System.IO.Path.GetFileName(filename);
            Image_List_Add(key, Image.FromFile(filename));
        }
        private void Image_List_Add_Range(string title, ArrayList file_list)
        {
            Do_Work_File_List = file_list;
            TForm_Process Process_Bar = new TForm_Process(title, Do_Work_File_List.Count, Do_Work);
        }
        private void Do_Work(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            for (int i = 0; i < Do_Work_File_List.Count; i++)
            {
                Image_List_Add(Do_Work_File_List[i].ToString());
                worker.ReportProgress(i + 1);
            }
        }
        private void Image_List_Add_Range(string path)
        {
            ArrayList file_list = new ArrayList();

            path = "E:\\BMP\\新增資料夾\\";
            file_list = String_Tool.Get_Files_List(path, "*.png");
            Image_List_Add_Range("Load Image List *.png", file_list);

            file_list = String_Tool.Get_Files_List(path, "*.jpg");
            Image_List_Add_Range("Load Image List *.jpg", file_list);

            file_list = String_Tool.Get_Files_List(path, "*.bmp");
            Image_List_Add_Range("Load Image List *.bmp", file_list);
        }
        private void Image_List_RemoveAt(int index)
        {
            if (index >= 0 && index < Param.Images.Count)
            {
                Param.Images.RemoveAt(index);
                flowLayoutPanel1.Controls.RemoveAt(index);
            }
        }
        private void Image_List_Clear()
        {
            Param.Images.Clear();
            flowLayoutPanel1.Controls.Clear();
        }

        private void B_Image_Add_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            int index = -1;

            dialog.Filter = "(*.bmp;*.jpg)|*.bmp;*.jpg";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dialog.FileNames.Length; i++ )
                    Image_List_Add(dialog.FileNames[i]);
               
                index = Param.Images.Count - 1;
                Select_Image(index);
            }
        }
        private void B_Image_Del_Click(object sender, EventArgs e)
        {
            int index = Select_Index;

            Image_List_RemoveAt(index);
            if (index > Param.Images.Count - 1) index = Param.Images.Count - 1;
            Select_Image(index);
        }
        private void B_Image_Clear_Click(object sender, EventArgs e)
        {
            Image_List_Clear();
        }
        private void B_Image_Add_Range_Click(object sender, EventArgs e)
        {
            string path = "";
            ArrayList file_list = new ArrayList();
            System.Windows.Forms.FolderBrowserDialog dialog = new FolderBrowserDialog();

            dialog.SelectedPath = "E:\\BMP\\新增資料夾";// E_Recipe_Path.Text;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Images.Clear();
                path = dialog.SelectedPath + "\\";
                Image_List_Add_Range(path);
            }
        }

        private bool Image_List_Swap(ImageList list, int no1, int no2)
        {
            bool result = false;
            Image tmp_image = null;
            string tmp_key = "";
            TFrame_ImageList frame1 = null;
            TFrame_ImageList frame2 = null;
          
            if (no1 >= 0 && no1 < list.Images.Count && no2 >= 0 && no2 < list.Images.Count)
            {
                tmp_image = Param.Images[no1];
                Param.Images[no1] = Param.Images[no2];
                Param.Images[no2] = tmp_image;

                tmp_key = Param.Images.Keys[no1];
                Param.Images.SetKeyName(no1, Param.Images.Keys[no2]); 
                Param.Images.SetKeyName(no2, tmp_key); 

                frame1 = (TFrame_ImageList)flowLayoutPanel1.Controls[no1];
                frame2 = (TFrame_ImageList)flowLayoutPanel1.Controls[no2];
                frame1.Set_Bitmap(Param, no1);
                frame2.Set_Bitmap(Param, no2);
                result = true;
            }
            return result;
        }
        private void B_Image_Up_Click(object sender, EventArgs e)
        {
            Image_List_Swap(Param, Select_Index, Select_Index-1);
            Select_Image(Select_Index-1);
        }
        private void B_Image_Dn_Click(object sender, EventArgs e)
        {
            Image_List_Swap(Param, Select_Index, Select_Index + 1);
            Select_Image(Select_Index + 1);
        }
    }
}
