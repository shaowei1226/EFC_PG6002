using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFC.HMI
{
    public partial class TForm_Image_List_Get : Form
    {
        public ImageList ImageList = null;
        public TFrame_ImageList[] Image_Obj_List = new TFrame_ImageList[0];
        public int Select_Index = -1;

        public TForm_Image_List_Get(ImageList list)
        {
            InitializeComponent();
            ImageList = list;
            Set_Image_List();
        }
        private void Set_Image_List()
        {
            ImageList list = ImageList;
            if (list != null)
            {
                Image_Obj_List = new TFrame_ImageList[list.Images.Count];
                for (int i = 0; i < Image_Obj_List.Length; i++)
                {
                    Image_Obj_List[i] = new TFrame_ImageList();
                    Image_Obj_List[i].Name = "JJS_PictureBox" + (i + 1).ToString();
                    Image_Obj_List[i].Set_Bitmap(list, i);
                    Image_Obj_List[i].PB_Bitmap.Tag = i;
                    Image_Obj_List[i].PB_Bitmap.MouseClick += Image_MouseClick;
                    flowLayoutPanel1.Controls.Add(Image_Obj_List[i]);
                }
            }
        }
        private void Image_MouseClick(object sender, MouseEventArgs e)
        {
            PictureBox obj = (PictureBox)sender;

            if (Select_Index >= 0) Image_Obj_List[Select_Index].BackColor = Color.Gray;
            Select_Index = (int)obj.Tag;           
            Image_Obj_List[Select_Index].BackColor = Color.Yellow;
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
}
