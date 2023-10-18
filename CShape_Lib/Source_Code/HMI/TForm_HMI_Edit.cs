using System;
using System.Collections.Generic;
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
    public partial class TForm_HMI_Edit : Form
    {
        public THMI_Info_Edit Param = new THMI_Info_Edit();
        public int Disp_Value = 0;
        public bool On_Setting = false;
        //private System.Windows.Forms.Button[] B_Status = new Button[16];

        public TForm_HMI_Edit()
        {
            InitializeComponent();
            Set_Default();
        }
        public TForm_HMI_Edit(THMI_Info_Edit info)
        {
            InitializeComponent();
            info.Copy(ref Param);
            Set_Default();
        }
        public void Set_Default()
        {
            if (Param.Owner != null)
            {
                TextBox obj = (TextBox)Param.Owner;
                //E_Disp.Font = (Font)Param.Font.Clone();
                E_Disp.Size = obj.Size;
                //E_Disp.Text = obj.Text;
            }
        }
        private void TForm_HMI_Edit_Shown(object sender, EventArgs e)
        {
            PageControl_Tool.Tab_Page_Hide(tabControl2);
            Set_Param();
        }
        public string Get_Value_String()
        {
            string result = "";
            int no = 0;

            if (Param.Data_Type == emEDIT_DATA_TYPE.Number)
            {
                if (Param.Flag_Signed) result = "-";
                for (int i = 0; i < Param.All_Num - Param.Dot_Num; i++)
                {
                    no++;
                    result = result + no.ToString();
                }
                if (Param.Dot_Num > 0) result = result + ".";
                for (int i = 0; i < Param.Dot_Num; i++)
                {
                    no++;
                    result = result + no.ToString();
                }
            }
            else
            {
                char ch = 'A';
                char ch2;
                for (int i = 0; i < Param.Value_String_Num; i++)
                {
                    ch2 = (char)(ch + i % 26);
                    result = result + ch2;
                }
            }
            return result;
        }
        public void Set_Param()
        {
            On_Setting = true;
            E_Device.Text = Param.Device;
            CB_All_Num.Text = Param.All_Num.ToString();
            CB_Dot_Num.Text = Param.Dot_Num.ToString();

            CB_Sting_Num.Text = Param.Value_String_Num.ToString();

            switch (Param.Data_Type)
            {
                case emEDIT_DATA_TYPE.Number: RB_Data_Type1.Checked = true; break;
                case emEDIT_DATA_TYPE.Text: RB_Data_Type2.Checked = true; break;
            }

            switch (Param.Num_Data_Type)
            {
                case emEDIT_NUM_DATA_TYPE.Bit16: RB_Num_Data_Type1.Checked = true; break;
                case emEDIT_NUM_DATA_TYPE.Bit32: RB_Num_Data_Type2.Checked = true; break;
            }

            CB_Flag_F_Zero.Checked = Param.Flag_F_Zero;
            CB_Flag_Signed.Checked = Param.Flag_Signed;
            CB_Flag_Round.Checked = Param.Flag_Round;
            CB_Flag_Hide_Disp.Checked = Param.Flag_Hide_Disp;

            B_Text_Align1.BackColor = Color.LightGray;
            B_Text_Align2.BackColor = Color.LightGray;
            B_Text_Align3.BackColor = Color.LightGray;
            if (Param.TextAlign == HorizontalAlignment.Left) B_Text_Align1.BackColor = Color.Yellow;
            if (Param.TextAlign == HorizontalAlignment.Center) B_Text_Align2.BackColor = Color.Yellow;
            if (Param.TextAlign == HorizontalAlignment.Right) B_Text_Align3.BackColor = Color.Yellow;

            Set_Param_Lock();

            Param.Set_Component_Data(E_Disp);
            E_Disp.Text = Get_Value_String();
            B_Status_Font.Text = HMI_Tool.Get_Font_String(Param.Font);
            B_Status_Color.BackColor = Param.Face_Color;
            B_Status_Font_Color.BackColor = Param.Font_Color;
            On_Setting = false;
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
        public void Get_Param()
        {
            Param.Device = E_Device.Text;

            Param.All_Num = Convert.ToInt32(CB_All_Num.Text);
            Param.Dot_Num = Convert.ToInt32(CB_Dot_Num.Text);

            Param.Value_String_Num = Convert.ToInt32(CB_Sting_Num.Text);

            if (RB_Data_Type1.Checked) Param.Data_Type = emEDIT_DATA_TYPE.Number;
            if (RB_Data_Type2.Checked) Param.Data_Type = emEDIT_DATA_TYPE.Text;

            if (RB_Num_Data_Type1.Checked) Param.Num_Data_Type = emEDIT_NUM_DATA_TYPE.Bit16;
            if (RB_Num_Data_Type2.Checked) Param.Num_Data_Type = emEDIT_NUM_DATA_TYPE.Bit32;

            Param.Flag_F_Zero = CB_Flag_F_Zero.Checked;
            Param.Flag_Signed = CB_Flag_Signed.Checked;
            Param.Flag_Round = CB_Flag_Round.Checked;
            Param.Flag_Hide_Disp = CB_Flag_Hide_Disp.Checked;

            Get_Param_Lock();
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
        private void B_Status_Font_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Get_Param();
                Param.Font = (Font)dialog.Font.Clone();
                Set_Param();
            }
        }
        private void B_Status_Font_Color_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Get_Param();
                Param.Font_Color = dialog.Color;
                Set_Param();
            }
        }
        private void B_Status_Color_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Get_Param();
                Param.Face_Color = dialog.Color;
                Set_Param();
            }
        }
        public void Reflash_Param()
        {
            if (!On_Setting)
            {
                Get_Param();
                Set_Param();
            }
        }
        private void CB_All_Num_TextChanged(object sender, EventArgs e)
        {
            Reflash_Param();
        }
        private void CB_Dot_Num_TextChanged(object sender, EventArgs e)
        {
            Reflash_Param();
        }
        private void CB_Flag_F_Zero_Click(object sender, EventArgs e)
        {
            Reflash_Param();
        }
        private void B_Text_Align1_Click(object sender, EventArgs e)
        {
            Param.TextAlign = HorizontalAlignment.Left;
            Reflash_Param();
        }
        private void B_Text_Align2_Click(object sender, EventArgs e)
        {
            Param.TextAlign = HorizontalAlignment.Center;
            Reflash_Param();
        }
        private void B_Text_Align3_Click(object sender, EventArgs e)
        {
            Param.TextAlign = HorizontalAlignment.Right;
            Reflash_Param();
        }
        private void RB_Data_Type1_CheckedChanged(object sender, EventArgs e)
        {
            PageControl_Tool.Tab_Page_Select(tabControl2, "數值");
            Reflash_Param();
        }
        private void RB_Data_Type2_CheckedChanged(object sender, EventArgs e)
        {
            PageControl_Tool.Tab_Page_Select(tabControl2, "文字");
            Reflash_Param();
        }
    }
}
