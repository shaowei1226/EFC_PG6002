using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFC.HMI
{
    public partial class TFrame_ImageList : UserControl
    {
        public TFrame_ImageList()
        {
            InitializeComponent();
        }
        public void Set_Bitmap(ImageList list, int no)
        {
            if (no != list.Images.Count)
            {
                if (list.Images[no] != null)
                    PB_Bitmap.BackgroundImage = (Image)list.Images[no].Clone();
                else
                    PB_Bitmap.BackgroundImage = null;

                PB_Bitmap.BackgroundImageLayout = ImageLayout.Stretch;
                L_Bitmap_Name.Text = list.Images.Keys[no];
            }
        }
    }
}
