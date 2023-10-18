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
    public partial class TForm_HMI_Message : Form
    {
        public THMI_Info_Message Param = new THMI_Info_Message();
        public int Disp_Value = 0;
        public bool On_Setting = false;
        public int Status = -1;
        public THMI_Meg_Item Status_Item = null;

        public TForm_HMI_Message()
        {
            InitializeComponent();
            Set_Default();
        }
        public TForm_HMI_Message(THMI_Info_Message info)
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
                E_Disp.Font = (Font)Param.Font.Clone();
                E_Disp.Size = obj.Size;
                //E_Disp.Text = obj.Text;
            }
        }
        private void TForm_HMI_Edit_Shown(object sender, EventArgs e)
        {
            Set_Param();
        }
        public void Set_Param()
        {
            On_Setting = true;
            E_Device.Text = Param.Device;
            E_Msg_Count.Text = Param.Msg_List.Count.ToString();

            B_Status_Font.Text = HMI_Tool.Get_Font_String(Param.Font);
            Set_Param_Msg();

            if (Status < 0 && Param.Msg_List.Count > 0) Status = 0;
            Set_Param_Status(Status);

            On_Setting = false;
        }
        public void Set_Param_Msg()
        {
            DataGridView dg = dataGridView1;

            dg.RowCount = Param.Msg_List.Count;
            for (int i = 0; i < Param.Msg_List.Count; i++ )
            {
                dg.Rows[i].Cells[0].Value = (i + 1).ToString();
                dg.Rows[i].Cells[1].Value = Param.Msg_List[i].Str;
            }
        }
        public void Set_Param_Status(int no)
        {
            Status = no;
            if (Status > Param.Msg_List.Count) Status = Param.Msg_List.Count - 1;
            if (Status >= 0 && Status < Param.Msg_List.Count)
            {
                Status_Item = Param.Msg_List[Status];

                B_Text_Align1.BackColor = Color.LightGray;
                B_Text_Align2.BackColor = Color.LightGray;
                B_Text_Align3.BackColor = Color.LightGray;
                if (Status_Item.TextAlign == HorizontalAlignment.Left) B_Text_Align1.BackColor = Color.Yellow;
                if (Status_Item.TextAlign == HorizontalAlignment.Center) B_Text_Align2.BackColor = Color.Yellow;
                if (Status_Item.TextAlign == HorizontalAlignment.Right) B_Text_Align3.BackColor = Color.Yellow;

                B_Status_Color.BackColor = Status_Item.Face_Color;
                B_Status_Font_Color.BackColor = Status_Item.Font_Color;

                Param.Set_Component_Data(E_Disp, Status);
                //E_Disp.Text = Param.Msg_List[no].Str;
            }
        }
        public void Get_Param()
        {
            Param.Device = E_Device.Text;
            Get_Param_Msg();
        }
        public void Get_Param_Msg()
        {
            DataGridView dg = dataGridView1;

            for (int i = 0; i < Param.Msg_List.Count; i++)
            {
                Param.Msg_List[i].Str = dg.Rows[i].Cells[1].Value.ToString();
            }
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
                E_Disp.Font = (Font)Param.Font.Clone();
                Set_Param();
            }
        }
        private void B_Status_Font_Color_Click(object sender, EventArgs e)
        {
            if (Status_Item != null)
            {
                ColorDialog dialog = new ColorDialog();
                dialog.Color = Status_Item.Font_Color;
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Get_Param();
                    Status_Item.Font_Color = dialog.Color;
                    Set_Param();
                }
            }
        }
        private void B_Status_Color_Click(object sender, EventArgs e)
        {
            if (Status_Item != null)
            {
                ColorDialog dialog = new ColorDialog();
                dialog.Color = Status_Item.Face_Color;
                if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    Get_Param();
                    Status_Item.Face_Color = dialog.Color;
                    Set_Param();
                }
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
        private void B_Text_Align1_Click(object sender, EventArgs e)
        {
            if (Status_Item != null)
            {
                Status_Item.TextAlign = HorizontalAlignment.Left;
                Reflash_Param();
            }
        }
        private void B_Text_Align2_Click(object sender, EventArgs e)
        {
            if (Status_Item != null)
            {
                Status_Item.TextAlign = HorizontalAlignment.Center;
                Reflash_Param();
            }
        }
        private void B_Text_Align3_Click(object sender, EventArgs e)
        {
            if (Status_Item != null)
            {
                Status_Item.TextAlign = HorizontalAlignment.Right;
                Reflash_Param();
            }
        }
        private void E_Msg_Count_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(E_Msg_Count.Text);
                Param.Msg_List.Set_Count(count);
                Set_Param();
                if (Status > Param.Msg_List.Count) Set_Param_Status(Param.Msg_List.Count - 1);
            }
            catch { };
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Get_Param_Msg();
            if (dataGridView1.SelectedCells.Count > 0)
            {
                Set_Param_Status(dataGridView1.SelectedCells[0].RowIndex);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            THMI_Meg_Item tmp_item = new THMI_Meg_Item();
            
            if (Status_Item != null)
            {
                tmp_item = Status_Item.Copy();
                for (int i = 0; i < Param.Msg_List.Count; i++ )
                {
                    Param.Msg_List[i].Face_Color = tmp_item.Face_Color;
                    Param.Msg_List[i].Font_Color = tmp_item.Font_Color;
                    Param.Msg_List[i].TextAlign = tmp_item.TextAlign;
                }
                Set_Param();
            }
        }
    }
}
