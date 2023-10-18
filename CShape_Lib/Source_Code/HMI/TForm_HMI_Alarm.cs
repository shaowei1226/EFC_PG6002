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
    public partial class TForm_HMI_Alarm : Form
    {
        public THMI_Info_Alarm Param = new THMI_Info_Alarm();

        public TForm_HMI_Alarm()
        {
            InitializeComponent();
        }
        public TForm_HMI_Alarm(THMI_Info_Alarm info)
        {
            InitializeComponent();
            info.Copy(ref Param);
            if (Param.Owner != null)
            {
                DataGridView obj = (DataGridView)Param.Owner;
                DG_Grid.Size = obj.Size;
            }
        }
        private void TForm_HMI_Button_Shown(object sender, EventArgs e)
        {
            Set_Param();
        }
        public void Set_Param()
        {
            Set_Param_Light();
            CB_Column1_SW.Checked = Param.Columns_Info_List[0].Switch;
            CB_Column1_SW.Text = Param.Columns_Info_List[0].Title;
            E_Column1_Width.Text = Param.Columns_Info_List[0].Width.ToString();

            CB_Column2_SW.Checked = Param.Columns_Info_List[1].Switch;
            CB_Column2_SW.Text = Param.Columns_Info_List[1].Title;
            E_Column2_Width.Text = Param.Columns_Info_List[1].Width.ToString();

            CB_Column3_SW.Checked = Param.Columns_Info_List[2].Switch;
            CB_Column3_SW.Text = Param.Columns_Info_List[2].Title;
            E_Column3_Width.Text = Param.Columns_Info_List[2].Width.ToString();

            CB_Column4_SW.Checked = Param.Columns_Info_List[3].Switch;
            CB_Column4_SW.Text = Param.Columns_Info_List[3].Title;
            E_Column4_Width.Text = Param.Columns_Info_List[3].Width.ToString();

            switch(Param.Mode)
            {
                case THMI_Alarm_Mode.Active: CB_Active_Mode.SelectedIndex = 0; break;
                case THMI_Alarm_Mode.History: CB_Active_Mode.SelectedIndex = 1; break;
                case THMI_Alarm_Mode.Log: CB_Active_Mode.SelectedIndex = 2; break;
                case THMI_Alarm_Mode.Count: CB_Active_Mode.SelectedIndex = 3; break;
            }
            Param.Set_Component_Data(DG_Grid); 
        }
        public void Set_Param_Light()
        {
            E_Light_Device.Text = Param.Msg_Device;
            CB_Light_Bit_Count.Text = Param.Msg_Word_Count.ToString();
        }
        public void Get_Param()
        {
            Get_Param_Light();

            Param.Columns_Info_List[0].Switch = CB_Column1_SW.Checked;
            Param.Columns_Info_List[0].Width = Convert.ToInt32(E_Column1_Width.Text);

            Param.Columns_Info_List[1].Switch = CB_Column2_SW.Checked;
            Param.Columns_Info_List[1].Width = Convert.ToInt32(E_Column2_Width.Text);

            Param.Columns_Info_List[2].Switch = CB_Column3_SW.Checked;
            Param.Columns_Info_List[2].Width = Convert.ToInt32(E_Column3_Width.Text);

            Param.Columns_Info_List[3].Switch = CB_Column4_SW.Checked;
            Param.Columns_Info_List[3].Width = Convert.ToInt32(E_Column4_Width.Text);

            switch (CB_Active_Mode.SelectedIndex)
            {
                case 0: Param.Mode = THMI_Alarm_Mode.Active; break;
                case 1: Param.Mode = THMI_Alarm_Mode.History; break;
                case 2: Param.Mode = THMI_Alarm_Mode.Log; break;
                case 3: Param.Mode = THMI_Alarm_Mode.Count; break;
            }
        }
        public void Get_Param_Light()
        {
            Param.Msg_Device = E_Light_Device.Text;
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
                //    status.Font = (Font)dialog.Font.Clone();
                //    //Set_Status(Status_Index);
            }
        }
        private void B_Status_Color_Click(object sender, EventArgs e)
        {
            //THMI_Status_Info status;

            //ColorDialog dialog = new ColorDialog();
            //if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //{
            //    Get_Param();
            //    status = Param.Get_Status(Status_Index);
            //    if (status != null)
            //    {
            //        status.Face_Color = dialog.Color;
            //        //Set_Status(Status_Index);
            //    }
            //}
        }
        private void B_Status_Font_Color_Click(object sender, EventArgs e)
        {
            //THMI_Status_Info status;

            //ColorDialog dialog = new ColorDialog();
            //if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //{
            //    Get_Param();
            //    status = Param.Get_Status(Status_Index);
            //    if (status != null)
            //    {
            //        status.Font_Color = dialog.Color;
            //        //Set_Status(Status_Index);
            //    }
            //}
        }
        private void CB_Light_Bit_Count_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Param.Msg_Word_Count = Convert.ToInt32(CB_Light_Bit_Count.Text);
                Set_Param_Light();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "*.txt|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Msg_File_Name = dialog.FileName;
            }
        }

     }
}
