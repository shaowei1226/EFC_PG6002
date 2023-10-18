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
    public partial class TForm_HMI_Lamp : Form
    {
        public THMI_Info_Lamp Param = new THMI_Info_Lamp();
        private System.Windows.Forms.Button[] B_Status = new Button[16];
        public int Status_Index = 0;
        public TFrame_Status Frame_Status = null;

        public TForm_HMI_Lamp()
        {
            InitializeComponent();
            Frame_Status = tFrame_Status1;
        }
        public TForm_HMI_Lamp(THMI_Info_Lamp info)
        {
            InitializeComponent();
            Frame_Status = tFrame_Status1;
            info.Copy(ref Param);
            Status_Index = Param.Status_Index;
        }
        private void TForm_HMI_Lamp_Shown(object sender, EventArgs e)
        {
            if (Param.Owner != null)
            {
                Panel obj = (Panel)Param.Owner;

                Frame_Status.P_Component.Size = obj.Size;
                Status_Index = Param.Status_Index;
            }
            Set_B_Status();
            Set_Status_Index(Status_Index);
            Set_Param();
        }
        public int Get_Bonder_Shape(emHMI_Bonder_Shape value)
        {
            int result = 0;

            switch (value)
            {
                case emHMI_Bonder_Shape.Rect: result = 0; break;
                case emHMI_Bonder_Shape.Round: result = 1; break;
                case emHMI_Bonder_Shape.Ellipse: result = 2; break;
                case emHMI_Bonder_Shape.Image: result = 3; break;
            }
            return result;
        }
        public emHMI_Bonder_Shape Get_Bonder_Shape(int value)
        {
            emHMI_Bonder_Shape result = emHMI_Bonder_Shape.Rect;

            switch (value)
            {
                case 0: result = emHMI_Bonder_Shape.Rect; break;
                case 1: result = emHMI_Bonder_Shape.Round; break;
                case 2: result = emHMI_Bonder_Shape.Ellipse; break;
                case 3: result = emHMI_Bonder_Shape.Image; break;
            }
            return result;
        }
        private void Set_B_Status()
        {
            for(int i=0; i<B_Status.Length; i++)
            {
                B_Status[i] = new Button();
                B_Status[i].Dock = System.Windows.Forms.DockStyle.Left;
                B_Status[i].Size = new System.Drawing.Size(64, 64);
                B_Status[i].Tag = i;
                B_Status[i].Text = (i + 1).ToString("00");
                B_Status[i].UseVisualStyleBackColor = true;
                B_Status[i].Click += B_Status_Click;
                B_Status[i].BackColor = Color.Gray;

            }
            for (int i = 0; i < B_Status.Length; i++)
                panel2.Controls.Add(B_Status[15-i]);
        }
        private void B_Status_Click(object sender, EventArgs e)
        {
            Get_Param();
            System.Windows.Forms.Button bt = (Button)sender;
            Set_Status_Index((int)bt.Tag);
            Set_Param_Status();
        }
        private void Set_Status_Index(int index)
        {
            if (Status_Index >= 0) B_Status[Status_Index].BackColor = Color.Gray;
            Status_Index = index;
            if (Status_Index >= 0) B_Status[Status_Index].BackColor = Color.Yellow;
        }
        public void Set_Param()
        {
            E_Status_Picture_Index.Text = Param.Image_Name;
            Set_Param_Light();
            Set_Param_Status();
        }
        public void Set_Param_Light()
        {
            E_Light_Device.Text = Param.Light_Device;
            if (Param.Light_Bit_Count <= 1) Param.Status_List.Set_Count(2);
            CB_Light_Bit_Count.Text = Param.Light_Bit_Count.ToString();
            for (int i = 0; i < B_Status.Length; i++)
            {
                if (i < Param.Status_List.Count) B_Status[i].Visible = true;
                else B_Status[i].Visible = false;
            }
            CB_Bonder_Shape.SelectedIndex = Get_Bonder_Shape(Param.Bonder_Shape);
        }
        public void Set_Param_Status()
        {
            THMI_Status tmp_status = Param.Status_List[Status_Index];
            THMI_Image_Box box = null;

            if (Param.HMI_ImageList != null) box = Param.HMI_ImageList.HMI_Info.Image_Boxs[Param.Image_Name];
            if (tmp_status != null)
            {
                Frame_Status.Set(tmp_status, box, Update_Status);
                Frame_Status.Set_Param();
            }
        }
        private void Update_Status()
        {
            PaintEventArgs e = new PaintEventArgs(Frame_Status.P_Component.CreateGraphics(), Frame_Status.P_Component.ClientRectangle);
            Param.Set_Component_Data(e, Frame_Status.P_Component, Status_Index);
        }
        public void Get_Param()
        {
            Get_Param_Light();
            Get_Param_Status();
        }
        public void Get_Param_Light()
        {
            Param.Light_Device = E_Light_Device.Text;
            Param.Bonder_Shape = Get_Bonder_Shape(CB_Bonder_Shape.SelectedIndex);
        }
        public void Get_Param_Status()
        {
            Frame_Status.Get_Param();
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Get_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void CB_Light_Bit_Count_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Param.Light_Bit_Count = Convert.ToInt32(CB_Light_Bit_Count.Text);
                Set_Param_Light();
            }
            catch
            {

            }
        }
        private void B_Image_Name_Click(object sender, EventArgs e)
        {
            string name = "";
            if (Param.HMI_ImageList != null)
            {
                if (HMI_Tool.Get_Image_Boxs_Name(Param.HMI_ImageList.HMI_Info.Image_Boxs, ref name))
                {
                    Get_Param();
                    Param.Image_Name = name;
                    Set_Param();
                }
            }
        }
        private void CB_Bonder_Shape_SelectedValueChanged(object sender, EventArgs e)
        {
            THMI_Status status;

            status = Param.Status_List[Status_Index];
            if (status != null)
            {
                Param.Bonder_Shape = Get_Bonder_Shape(CB_Bonder_Shape.SelectedIndex);
                Set_Param_Status();
            }
        }
     }
}
