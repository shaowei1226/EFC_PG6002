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
using EFC.Tool;

namespace EFC.Vision.Halcon
{
    public partial class TForm_User_Define : Form
    {
        public TCommand_Define Param = new TCommand_Define();


        public TForm_User_Define()
        {
            DataGridView dg;

            InitializeComponent();
            
            dg = DG_In_Value;
            dg.Columns.Clear();
            dg.Columns.Add("No", "No");
            dg.Columns.Add(Get_Value_Type_ComboBox_List());
            dg.Columns.Add("Name", "Name");
            dg.Columns.Add("Disp_String", "Disp_String");
            dg.Columns.Add("Default", "Default");
            dg.Columns[0].Width = 40;
            dg.Columns[1].Width = 200;
            dg.Columns[2].Width = 160;
            dg.Columns[3].Width = 160;
            dg.Columns[4].Width = 160;

            dg = DG_Out_Value;
            dg.Columns.Clear();
            dg.Columns.Add("No", "No");
            dg.Columns.Add(Get_Value_Type_ComboBox_List());
            dg.Columns.Add("Name", "Name");
            dg.Columns.Add("Disp_String", "Disp_String");
            dg.Columns.Add("Default", "Default");
            dg.Columns[0].Width = 40;
            dg.Columns[1].Width = 200;
            dg.Columns[2].Width = 160;
            dg.Columns[3].Width = 160;
            dg.Columns[4].Width = 160;
        }
        public void Set_Param(TCommand_Define param)
        {
            Param.Set(param);

            E_Command_Name.Text = Param.Name;
            Set_Values_Grid(DG_In_Value, Param.In.Values);
            Set_Values_Grid(DG_Out_Value, Param.Out.Values);
        }
        public void Set_Values_Grid(DataGridView dg, TCommand_Value[] values)
        {
            dg.RowCount = values.Length;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != null)
                {
                    dg.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dg.Rows[i].Cells[1].Value = Value_Type.Type_To_String(values[i].Type);
                    dg.Rows[i].Cells[2].Value = values[i].Name;
                    dg.Rows[i].Cells[3].Value = values[i].Disp_String;
                    dg.Rows[i].Cells[4].Value = values[i].Default_Value;
                }
            }
        }
        public void Update_Param()
        {
            Param.Name = E_Command_Name.Text;
            Update_Param_Values_Grid();
        }
        public string Get_Grid_String(DataGridView dg, int no)
        {
            string result = "";
            if (dg != null && no < dg.RowCount)
            {
                result = dg.Rows[no].Cells[1].Value + "," +
                         dg.Rows[no].Cells[2].Value + "," +
                         dg.Rows[no].Cells[3].Value + "," +
                         "" + "," +
                         dg.Rows[no].Cells[4].Value;
            }
            return result;
        }
        public void Update_Param_Values_Grid()
        {

            for (int i = 0; i < Param.In.Values_Count; i++)
            {
                Param.In.Values[i].Set_Data(Get_Grid_String(DG_In_Value, i));
            }

            for (int i = 0; i < Param.Out.Values_Count; i++)
            {
                Param.Out.Values[i].Set_Data(Get_Grid_String(DG_Out_Value, i));
            }
        }
        public DataGridViewComboBoxColumn Get_Value_Type_ComboBox_List()
        {
            DataGridViewComboBoxColumn result = new DataGridViewComboBoxColumn();
            ArrayList list = new ArrayList();

            result.HeaderText = "Type";
            result.Name = "cmb";
            list = Value_Type.Get_List();
            result.MaxDropDownItems = list.Count;
            for (int i = 0; i < list.Count; i++ )
                result.Items.Add(list[i].ToString());
            return result;
        }
        private void B_In_Values_Up_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_In_Value;
            if (dg.SelectedRows.Count >= 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no >= 1 && no < Param.In.Values_Count)
                {
                    Update_Param();
                    Param.In.Move_Up(no);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no - 1].Cells[0];
                }
            }
        }
        private void B_In_Values_Dn_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_In_Value;
            if (dg.SelectedRows.Count >= 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no >= 0 && no < Param.In.Values_Count - 1)
                {
                    Update_Param();
                    Param.In.Move_Dn(no);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no + 1].Cells[0];
                }
            }
        }
        private void B_In_Values_Add_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;

            dg = DG_In_Value;
            Update_Param();
            Param.In.Add();
            Param.In.Values[Param.In.Values_Count - 1].Name = "Default" + Param.In.Values_Count.ToString();
            Set_Param(Param);
            dg.CurrentCell = dg.Rows[Param.In.Values_Count - 1].Cells[0];
        }
        private void B_In_Values_Del_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_In_Value;
            if (dg.SelectedRows.Count >= 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no >= 0 && no < Param.In.Values_Count)
                {
                    Update_Param();
                    Param.In.Del(no);
                    Set_Param(Param);

                    if (no < Param.In.Values_Count - 1) dg.CurrentCell = dg.Rows[no].Cells[0];
                    else if (Param.In.Values_Count > 0) dg.CurrentCell = dg.Rows[Param.In.Values_Count - 1].Cells[0];
                }
            }
        }

        private void B_Out_Values_Up_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_Out_Value;
            if (dg.SelectedRows.Count >= 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no >= 1 && no < Param.Out.Values_Count)
                {
                    Update_Param();
                    Param.Out.Move_Up(no);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no - 1].Cells[0];
                }
            }
        }
        private void B_Out_Values_Dn_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_Out_Value;
            if (dg.SelectedRows.Count >= 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no >= 0 && no < Param.Out.Values_Count - 1)
                {
                    Update_Param();
                    Param.Out.Move_Dn(no);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no + 1].Cells[0];
                }
            }
        }
        private void B_Out_Values_Add_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;

            dg = DG_Out_Value;
            Update_Param();
            Param.Out.Add();
            Param.Out.Values[Param.Out.Values_Count - 1].Name = "Default" + Param.Out.Values_Count.ToString();
            Set_Param(Param);
            dg.CurrentCell = dg.Rows[Param.Out.Values_Count - 1].Cells[0];
        }
        private void B_Out_Values_Del_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_Out_Value;
            if (dg.SelectedRows.Count >= 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no >= 0 && no < Param.Out.Values_Count)
                {
                    Update_Param();
                    Param.Out.Del(no);
                    Set_Param(Param);

                    if (no < Param.Out.Values_Count - 1) dg.CurrentCell = dg.Rows[no].Cells[0];
                    else if (Param.Out.Values_Count > 0) dg.CurrentCell = dg.Rows[Param.Out.Values_Count - 1].Cells[0];
                }
            }
        }


        private void B_Apply_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
