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

namespace EFC.Tool
{
    public partial class TForm_Log_Sort : Form
    {
        public TLog Param = null;

        public TForm_Log_Sort()
        {
            InitializeComponent();
        }
        public TForm_Log_Sort(TLog param)
        {
            InitializeComponent();
            Param = param;
        }
        private void Form_Log_Sort_Shown(object sender, EventArgs e)
        {
            Set_CB_Sort_Type();
            Set_CB_Sort_Source();
            Set_CB_Sort_Fun();
            Set_Param();
        }
        public void Set_Param()
        {
            if (Param != null)
            {
                CB_Sort_Type.Text = Param.Sort.Type.ToString();
                CB_Sort_Source.Text = Param.Sort.Source;
                CB_Sort_Fun.Text = Param.Sort.Fun;
            }
        }
        public void Update_Param()
        {
            if (Param != null)
            {
                switch (CB_Sort_Type.SelectedIndex)
                {
                    case 0: Param.Sort.Type = emLog_Type.None; break;
                    case 1: Param.Sort.Type = emLog_Type.Generally; break;
                    case 2: Param.Sort.Type = emLog_Type.Warning; break;
                    case 3: Param.Sort.Type = emLog_Type.Error; break;
                    case 4: Param.Sort.Type = emLog_Type.Remark; break;
                }

                Param.Sort.Source = CB_Sort_Source.Text;
                Param.Sort.Fun = CB_Sort_Fun.Text;
            }
        }
        public void Set_CB_Sort_Type()
        {
            System.Windows.Forms.ComboBox cb = CB_Sort_Type;
            ArrayList list = null;

            if (Param != null)
            {
                list = Param.Log_Msg.Get_Type_List();
                cb.Items.Clear();
                for (int i = 0; i < list.Count; i++) cb.Items.Add(list[i].ToString());
            }
        }
        public void Set_CB_Sort_Source()
        {
            System.Windows.Forms.ComboBox cb = CB_Sort_Source;
            ArrayList list = null;

            if (Param != null)
            {
                list = Param.Log_Msg.Get_Source_List();
                cb.Items.Clear();
                cb.Items.Add("");
                for (int i = 0; i < list.Count; i++) cb.Items.Add(list[i].ToString());
            }
        }
        public void Set_CB_Sort_Fun()
        {
            System.Windows.Forms.ComboBox cb = CB_Sort_Fun;
            ArrayList list = null;

            if (Param != null)
            {
                list = Param.Log_Msg.Get_Fun_List();
                cb.Items.Clear();
                cb.Items.Add("");
                for (int i = 0; i < list.Count; i++) cb.Items.Add(list[i].ToString());
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
        private void B_Clear_Click(object sender, EventArgs e)
        {
            CB_Sort_Type.SelectedIndex = 0;
            CB_Sort_Source.Text = "";
            CB_Sort_Fun.Text = "";
        }

    }
}
