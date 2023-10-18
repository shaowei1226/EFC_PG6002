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
    public delegate void evUpdate_Status();
    public partial class TFrame_Status : UserControl
    {
        public THMI_Image_Box Image_Box = null;
        public string Image_Name = "";
        public THMI_Status Param = null;
        public evUpdate_Status Update_Status = null;

        public TFrame_Status()
        {
            InitializeComponent();
        }
        public void Init()
        {
            CB_Status_Font_Color.Items.Clear();
            CB_Status_Font_Color.Items.AddRange(Get_Color_List());

            CB_Status_Color.Items.Clear();
            CB_Status_Color.Items.AddRange(Get_Color_List());
        }
        public void Set(THMI_Status param, THMI_Image_Box image_box, evUpdate_Status fun)
        {
            Param = param;
            Image_Box = image_box;
            Update_Status = fun;
        }
        private string[] Get_Color_List()
        {
            string[] result = new string[]{"Transparent","White","Silver","Gray","DarkGray","Black",
                                           "Blue","LightBlue","Yellow","LightYellow","Gold","Olive","Red",
                                           "Purple","Pink","LightPink","Orange","Brown","LightBlue",
                                           "Green","LightGreen"};
            return result;
        }
        public void Set_Param()
        {
            if (Param != null)
            {
                E_Status_Text.Text = Param.Text;
                E_Status_Font.Text = HMI_Tool.Get_Font_String(Param.Font);

                B_Status_Font_Color.BackColor = Param.Font_Color;
                CB_Status_Font_Color.Text = JJS_Image_Tool.Color_To_String(Param.Font_Color);

                B_Status_Color.BackColor = Param.Face_Color;
                CB_Status_Color.Text = JJS_Image_Tool.Color_To_String(Param.Face_Color);

                CB_Disp_Text.Checked = Param.Disp_Text;
                Set_Param_Text_Align();
                E_Status_Picture_Index.Text = Param.Image_Index.ToString();
                if (Image_Box != null && Param.Image_Index >= 0 && Param.Image_Index < Image_Box.ImageList.Images.Keys.Count)
                {
                    E_Status_Picture_Name.Text = Image_Box.ImageList.Images.Keys[Param.Image_Index];
                }
                if (Update_Status != null) Update_Status();
            }
        }
        public void Set_Param_Text_Align()
        {
            if (Param != null)
            {
                B_Text_Align11.BackColor = Color.LightGray;
                B_Text_Align12.BackColor = Color.LightGray;
                B_Text_Align13.BackColor = Color.LightGray;

                B_Text_Align21.BackColor = Color.LightGray;
                B_Text_Align22.BackColor = Color.LightGray;
                B_Text_Align23.BackColor = Color.LightGray;

                B_Text_Align31.BackColor = Color.LightGray;
                B_Text_Align32.BackColor = Color.LightGray;
                B_Text_Align33.BackColor = Color.LightGray;

                switch (Param.Text_Align)
                {
                    case emHMI_Text_Align.Top_Left: B_Text_Align11.BackColor = Color.Yellow; break;
                    case emHMI_Text_Align.Top_Center: B_Text_Align12.BackColor = Color.Yellow; break;
                    case emHMI_Text_Align.Top_Right: B_Text_Align13.BackColor = Color.Yellow; break;

                    case emHMI_Text_Align.Middle_Left: B_Text_Align21.BackColor = Color.Yellow; break;
                    case emHMI_Text_Align.Middle_Center: B_Text_Align22.BackColor = Color.Yellow; break;
                    case emHMI_Text_Align.Middle_Right: B_Text_Align23.BackColor = Color.Yellow; break;

                    case emHMI_Text_Align.Bottom_Left: B_Text_Align31.BackColor = Color.Yellow; break;
                    case emHMI_Text_Align.Bottom_Center: B_Text_Align32.BackColor = Color.Yellow; break;
                    case emHMI_Text_Align.Bottom_Right: B_Text_Align33.BackColor = Color.Yellow; break;
                }
            }
        }
        public void Get_Param()
        {
            if (Param != null)
            {
                Param.Text = E_Status_Text.Text;
            }
        }
        private void B_Status_Font_Click(object sender, EventArgs e)
        {
            if (Param != null)
            {
                FontDialog dialog = new FontDialog();

                dialog.Font = Param.Font;
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Get_Param();
                    Param.Font = (Font)dialog.Font.Clone();
                    Set_Param();
                }
            }
        }
        private void B_Status_Font_Color_Click(object sender, EventArgs e)
        {
            if (Param != null)
            {
                ColorDialog dialog = new ColorDialog();
                dialog.Color = Param.Font_Color;
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Get_Param();
                    Param.Font_Color = dialog.Color;
                    Set_Param();
                }
            }
        }
        private void B_Status_Color_Click(object sender, EventArgs e)
        {
            if (Param != null)
            {
                ColorDialog dialog = new ColorDialog();
                dialog.Color = Param.Face_Color;
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Get_Param();
                    Param.Face_Color = dialog.Color;
                    Set_Param();
                }
            }
        }
        private void CB_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            SolidBrush brush;
            Rectangle r = e.Bounds;
            Rectangle rd = new Rectangle(r.X, r.Y, r.Height, r.Height);
            Rectangle rd2 = new Rectangle(r.X + r.Height, r.Y, r.Width - r.Height, r.Height);

            string str = (string)this.CB_Status_Color.Items[e.Index];

            brush = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(str, e.Font, brush, rd2);

            brush = new SolidBrush(JJS_Image_Tool.String_To_Color(str));
            e.Graphics.FillRectangle(brush, rd);
        }
        private void CB_Status_Font_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Param != null)
            {
                Color color = JJS_Image_Tool.String_To_Color(CB_Status_Font_Color.Text);

                Get_Param();
                Param.Font_Color = color;
                Set_Param();
            }
        }
        private void CB_Status_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Param != null)
            {
                Color color = JJS_Image_Tool.String_To_Color(CB_Status_Color.Text);

                Get_Param();
                if (Param.Face_Color != color)
                {
                    Param.Face_Color = color;
                    Set_Param();
                }
            }
        }
        private void CB_Disp_Text_CheckedChanged(object sender, EventArgs e)
        {
            if (Param != null)
            {
                Param.Disp_Text = CB_Disp_Text.Checked;
                Set_Param();
            }
        }
        private void B_Text_Align11_Click(object sender, EventArgs e)
        {
            if (Param != null)
            {
                Button obj = (Button)sender;
                string flag = (string)obj.Tag;

                switch (flag)
                {
                    case "11": Param.Text_Align = emHMI_Text_Align.Top_Left; break;
                    case "12": Param.Text_Align = emHMI_Text_Align.Top_Center; break;
                    case "13": Param.Text_Align = emHMI_Text_Align.Top_Right; break;

                    case "21": Param.Text_Align = emHMI_Text_Align.Middle_Left; break;
                    case "22": Param.Text_Align = emHMI_Text_Align.Middle_Center; break;
                    case "23": Param.Text_Align = emHMI_Text_Align.Middle_Right; break;

                    case "31": Param.Text_Align = emHMI_Text_Align.Bottom_Left; break;
                    case "32": Param.Text_Align = emHMI_Text_Align.Bottom_Center; break;
                    case "33": Param.Text_Align = emHMI_Text_Align.Bottom_Right; break;
                }
                Set_Param_Text_Align();
                Update_Status();
            }
        }
        private void E_Status_Text_Leave(object sender, EventArgs e)
        {
            Get_Param();
            Set_Param();
        }
        private void B_Status_Picture_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (Param != null && Image_Box != null)
            {
                if (HMI_Tool.Get_Image_Box_Index(Image_Box, ref index))
                {
                    Get_Param();
                    Param.Image_Index = index;
                    Set_Param();
                }
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
