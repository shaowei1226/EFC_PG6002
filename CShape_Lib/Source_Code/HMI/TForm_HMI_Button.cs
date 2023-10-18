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
    public partial class TForm_HMI_Button : Form
    {
        public THMI_Info_Button Param = new THMI_Info_Button();
        private System.Windows.Forms.Button[] B_Status = new Button[16];
        public int Status_Index = 0;
        public TFrame_Status Frame_Status = null;

        public TForm_HMI_Button()
        {
            InitializeComponent();
            Frame_Status = tFrame_Status1;
        }
        public TForm_HMI_Button(THMI_Info_Button info)
        {
            InitializeComponent();
            Frame_Status = tFrame_Status1;
            info.Copy(ref Param);
            Status_Index = Param.Status_Index;
        }
        private void TForm_HMI_Button_Shown(object sender, EventArgs e)
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
        private string[] Get_Color_List()
        {
            string[] result = new string[]{"Transparent","White","Silver","Gray","DarkGray","Black",
                                           "Blue","LightBlue","Yellow","LightYellow","Gold","Olive","Red",
                                           "Purple","Pink","LightPink","Orange","Brown","LightBlue",
                                           "Green","LightGreen"};
            return result;
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
            for (int i = 0; i < B_Status.Length; i++)
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
                panel2.Controls.Add(B_Status[15 - i]);
        }
        private void B_Status_Click(object sender, EventArgs e)
        {
            Get_Param();
            System.Windows.Forms.Button bt = (Button)sender;
            Set_Status_Index((int)bt.Tag);
            tFrame_Status1.panel3.Refresh();
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
            E_Switch_Device.Text = Param.Device;
            switch (Param.Type)
            {
                case emDEVICE_BUTTON_TYPE.emBT_Set: CB_E_Switch_Type.SelectedIndex = 0; break;
                case emDEVICE_BUTTON_TYPE.emBT_Reset: CB_E_Switch_Type.SelectedIndex = 1; break;
                case emDEVICE_BUTTON_TYPE.emBT_M: CB_E_Switch_Type.SelectedIndex = 2; break;
                case emDEVICE_BUTTON_TYPE.emBT_Inv: CB_E_Switch_Type.SelectedIndex = 3; break;
            }

            CB_Bonder_Shape.SelectedIndex = Get_Bonder_Shape(Param.Bonder_Shape);
            Set_Param_Light();
            Set_Param_Lock();

            E_Image_Name.Text = Param.Image_Name;
            Set_Param_Status();
        }
        public void Set_Param_Light()
        {
            CB_Light_Switch.Checked = Param.Light_Switch;
            E_Light_Device.Text = Param.Light_Device;

            for (int i = 0; i < B_Status.Length; i++)
            {
                if (i < 2) B_Status[i].Visible = true;
                else B_Status[i].Visible = false;
            }
        }
        public void Set_Param_Lock()
        {
            CB_Lock_Switch.Checked = Param.Lock_Switch;
            E_Lock_Device.Text = Param.Lock_Device;
            switch (Param.Lock_Type)
            {
                case emDEVICE_LOCK_TYPE.emBit_On: RB_Lock_Type1.Checked = true; break;
                case emDEVICE_LOCK_TYPE.emBit_Off: RB_Lock_Type2.Checked = true; break;
            }
        }
        public void Set_Param_Status()
        {
            THMI_Status tmp_status = Param.Status_List[Status_Index];
            
            if (Param.HMI_ImageList != null)
            {
                THMI_Image_Box box = Param.HMI_ImageList.HMI_Info.Image_Boxs[Param.Image_Name];
                if (tmp_status != null)
                {
                    Frame_Status.Set(tmp_status, box, Update_Status);
                    Frame_Status.Set_Param();
                }
            }
        }
        private void Update_Status()
        {
            PaintEventArgs e = new PaintEventArgs(Frame_Status.P_Component.CreateGraphics(), Frame_Status.P_Component.ClientRectangle);
            Param.Set_Component_Data(e, Frame_Status.P_Component, Status_Index);
        }
        public void Get_Param()
        {
            Param.Device = E_Switch_Device.Text;
            switch (CB_E_Switch_Type.SelectedIndex)
            {
                case 0: Param.Type = emDEVICE_BUTTON_TYPE.emBT_Set; break;
                case 1: Param.Type = emDEVICE_BUTTON_TYPE.emBT_Reset; break;
                case 2: Param.Type = emDEVICE_BUTTON_TYPE.emBT_M; break;
                case 3: Param.Type = emDEVICE_BUTTON_TYPE.emBT_Inv; break;
            }
            Get_Param_Status();
            Get_Param_Light();
            Get_Param_Lock();
        }
        public void Get_Param_Status()
        {
            //THMI_Status status = null;

            //status = Param.Get_Status_Item(Status_Index);
            //status.Text = E_Status_Text.Text;
        }
        public void Get_Param_Light()
        {
            Param.Light_Switch = CB_Light_Switch.Checked;
            Param.Light_Device = E_Light_Device.Text;
        }
        public void Get_Param_Lock()
        {
            Param.Lock_Switch = CB_Lock_Switch.Checked;
            Param.Lock_Device = E_Lock_Device.Text;
            if (RB_Lock_Type1.Checked) Param.Lock_Type = emDEVICE_LOCK_TYPE.emBit_On;
            if (RB_Lock_Type2.Checked) Param.Lock_Type = emDEVICE_LOCK_TYPE.emBit_Off;
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
    }
}
