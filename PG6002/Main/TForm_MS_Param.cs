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
using EFC.INI;


namespace Main
{
    public enum emMS_Info_Value_Type { Int, Bool, String, Double }
    public delegate void evMS_Param_Section_Get(TMS_Info_Section section);
    public delegate void evMS_Param_Value_Get(TMS_Info_Section section, TMS_Info_Value value);
    public delegate void evMS_Param_Update(TMS_Param param);

    public partial class TForm_MS_Param : Form
    {
        public TMS_Param Param = new TMS_Param();
        public TMS_Info_Section Section = null;

        public TForm_MS_Param()
        {
            InitializeComponent();
        }
        public void Set_Param(TMS_Param param)
        {
            Param.Set(param);
            Set_Param();
        }
        public void Set_Param()
        {
            Param.Disp_TreeView(TV_Menu);
            Set_Param_Section();
        }
        public void Set_Param_Section()
        {
            if (Section != null)
            {
                E_Item_List_Name.Text = Section.Name;
                Param.Disp_Grid(dataGridView1, Section);
            }
        }
        public void Update_Param()
        {
            Param.Update_Grid(dataGridView1, ref Section);
            Param.Update();
        }
        private void TV_Menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Update_Param();
            Section = Param.Get_Section(TV_Menu);
            Set_Param_Section();
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void B_Write_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_no = 0;
            int col_no = 0;
            TMS_Info_Section section = null;
            TMS_Info_Value value = null;

            row_no = e.RowIndex;
            col_no = e.ColumnIndex;
            if (col_no == 4)
            {
                section = Param.Get_Section(TV_Menu);
                value = section.Values[row_no];
                if (value != null && value.Get_Fun != null)
                {
                    Update_Param();
                    value.Get_Fun(section, value);
                    Set_Param_Section();
                }
            }
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public class TMS_Param : TBase_Class
    {
        public string FileName;
        public string Info;
        public string Default_Path;
        public string Default_FileName;

        public TMS_Info_Section_List Sections = new TMS_Info_Section_List();
        public evMS_Param_Update On_Update = null;
 
        public TMS_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TMS_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMS_Param && dis_base is TMS_Param)
            {
                TMS_Param sor = (TMS_Param)sor_base;
                TMS_Param dis = (TMS_Param)dis_base;

                dis.FileName = sor.FileName;
                dis.Info = sor.Info;
                dis.Default_Path = sor.Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                dis.On_Update = sor.On_Update;

                dis.Sections.Set(sor.Sections);
            }
        }

        public void Set_Default()
        {
            FileName = "";
            Info = "";
            Default_Path = "";
            Default_FileName = "";
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result = true;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Write(ini, section);
            ini.Save_File();

            return result;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            TMS_Info_Section tmp_section = null;
            TMS_Info_Value tmp_value = null;
            string section_str = "";
            string value_str = "";

            Info = ini.ReadString(section, "Info", "");
            for (int i = 0; i < Sections.Count; i++)
            {
                tmp_section = Sections[i];
                for (int j = 0; j < tmp_section.Values.Count; j++)
                {
                    tmp_value = tmp_section.Values[j];
                    section_str = section + "/" + tmp_section.Name;
                    value_str = tmp_value.Name;
                    if (tmp_value.Value is bool) tmp_value.Value = ini.ReadBool(section_str, value_str, (bool)tmp_value.Value);
                    if (tmp_value.Value is int) tmp_value.Value = ini.ReadInteger(section_str, value_str, (int)tmp_value.Value);
                    if (tmp_value.Value is double) tmp_value.Value = ini.ReadFloat(section_str, value_str, (double)tmp_value.Value);
                    if (tmp_value.Value is string) tmp_value.Value = ini.ReadString(section_str, value_str, (string)tmp_value.Value);
                }
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            TMS_Info_Section tmp_section = null;
            TMS_Info_Value tmp_value = null;
            string section_str = "";
            string value_str = "";

            ini.WriteString(section, "Info", Info);
            for (int i = 0; i < Sections.Count; i++)
            {
                tmp_section = Sections[i];
                for (int j = 0; j < tmp_section.Values.Count; j++)
                {
                    tmp_value = tmp_section.Values[j];
                    section_str = section + "/" + tmp_section.Name;
                    value_str = tmp_value.Name;
                    if (tmp_value.Value is bool) ini.WriteBool(section_str, value_str, (bool)tmp_value.Value);
                    if (tmp_value.Value is int) ini.WriteInteger(section_str, value_str, (int)tmp_value.Value);
                    if (tmp_value.Value is double) ini.WriteFloat(section_str, value_str, (double)tmp_value.Value);
                    if (tmp_value.Value is string) ini.WriteString(section_str, value_str, (string)tmp_value.Value);
                }
            }
        }
        public bool Set_Param()
        {
            bool result = false;
            TForm_MS_Param form = new TForm_MS_Param();
            form.Set_Param(this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        public void Update()
        {
            if (On_Update != null) On_Update(this);
        }


        public TMS_Info_Value Get_Info_Value(string section_name, string value_name)
        {
            TMS_Info_Value result = null;
            TMS_Info_Section tmp_section = null;

            tmp_section = Sections[section_name];
            if (tmp_section != null)
                result = tmp_section.Values[value_name];
            return result;
        }
        public bool Get_Value_Bool(string section_name, string value_name)
        {
            bool result = false;

            TMS_Info_Value info_value = Get_Info_Value(section_name, value_name);
            if (info_value != null)
            {
                if (info_value.Value is bool) result = (bool)info_value.Value;
            }
            return result;
        }
        public int Get_Value_Int(string section_name, string value_name)
        {
            int result = 0;

            TMS_Info_Value info_value = Get_Info_Value(section_name, value_name);
            if (info_value != null)
            {
                if (info_value.Value is int) result = (int)info_value.Value;
            }
            return result;
        }
        public double Get_Value_Double(string section_name, string value_name)
        {
            double result = 0;

            TMS_Info_Value info_value = Get_Info_Value(section_name, value_name);
            if (info_value != null)
            {
                if (info_value.Value is double) result = (double)info_value.Value;
            }
            return result;
        }
        public string Get_Value_String(string section_name, string value_name)
        {
            string result = "";

            TMS_Info_Value info_value = Get_Info_Value(section_name, value_name);
            if (info_value != null)
            {
                if (info_value.Value is string) result = (string)info_value.Value;
            }
            return result;
        }

        public void Add_Value(string section_name, string value_name, emMS_Info_Value_Type type, evMS_Param_Value_Get get_fun = null)
        {
            object value = Get_Value(type);

            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            
            tmp_section.Values.Add(value_name, type, value, get_fun);
        }
        public void Add_Value(string section_name, string value_name, emMS_Info_Value_Type type, string info, evMS_Param_Value_Get get_fun = null)
        {
            object value = Get_Value(type);
            
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, type, value, info, get_fun);
        }
        public void Add_Value(string section_name, string value_name, emMS_Info_Value_Type type, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            object value = Get_Value(type);

            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, type, value, info, flag_read_only, flag_ref, get_fun);
        }

        public void Add_Value_Bool(string section_name, string value_name, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Bool, new bool(), get_fun);
        }
        public void Add_Value_Bool(string section_name, string value_name, string info, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Bool, new bool(), info, get_fun);
        }
        public void Add_Value_Bool(string section_name, string value_name, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Bool, new bool(), info, flag_read_only, flag_ref, get_fun);
        }

        public void Add_Value_Int(string section_name, string value_name, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Int, new int(), get_fun);
        }
        public void Add_Value_Int(string section_name, string value_name, string info, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Int, new int(), info, get_fun);
        }
        public void Add_Value_Int(string section_name, string value_name, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Int, new int(), info,  flag_read_only, flag_ref, get_fun);
        }

        public void Add_Value_Double(string section_name, string value_name, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Double, new double(), get_fun);
        }
        public void Add_Value_Double(string section_name, string value_name, string info, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Double, new double(), info, get_fun);
        }
        public void Add_Value_Double(string section_name, string value_name, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.Double, new double(), info, flag_read_only, flag_ref, get_fun);
        }
        
        public void Add_Value_String(string section_name, string value_name, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.String, new string(' ', 0), get_fun);
        }
        public void Add_Value_String(string section_name, string value_name, string info, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.String, new string(' ', 0), info, get_fun);
        }
        public void Add_Value_String(string section_name, string value_name, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            TMS_Info_Section tmp_section = Sections[section_name];
            if (tmp_section == null)
            {
                Sections.Add(section_name);
                tmp_section = Sections[section_name];
            }
            tmp_section.Values.Add(value_name, emMS_Info_Value_Type.String, new string(' ', 0), info, flag_read_only, flag_ref, get_fun);
        }

        public TMS_Info_Value Get_Value(string section_name, string value_name)
        {
            TMS_Info_Value result = null;

            if (Sections[section_name] != null)
            {
                result = Sections[section_name].Values[value_name];
            }
            return result;
        }
        public void Set_Value(string section_name, string value_name, object value)
        {
            if (value is bool) Set_Value_Bool(section_name, value_name, (bool)value);
            if (value is int) Set_Value_Int(section_name, value_name, (int)value);
            if (value is double) Set_Value_Double(section_name, value_name, (double)value);
            if (value is string) Set_Value_String(section_name, value_name, (string)value);
        }
        public void Set_Value_Info(string section_name, string value_name, object value, string info, bool flag_read_only = true, bool flag_ref = true)
        {
            TMS_Info_Value tmp_value = Get_Value(section_name, value_name);

            if (tmp_value != null)
            {
                tmp_value.Flag_Read_Only = flag_read_only;
                tmp_value.Flag_Ref = flag_ref;
                Set_Value(section_name, value_name, value);
                Set_Info(section_name, value_name, info);
            }
        }

        public void Set_Value_Bool(string section_name, string value_name, bool value)
        {
            TMS_Info_Value tmp_value = Get_Value(section_name, value_name);

            if (tmp_value != null) tmp_value.Set_Value_Bool(value);
        }
        public void Set_Value_Int(string section_name, string value_name, int value)
        {
            TMS_Info_Value tmp_value = Get_Value(section_name, value_name);

            if (tmp_value != null) tmp_value.Set_Value_Int(value);
        }
        public void Set_Value_Double(string section_name, string value_name, double value)
        {
            TMS_Info_Value tmp_value = Get_Value(section_name, value_name);

            if (tmp_value != null) tmp_value.Set_Value_Double(value);
        }
        public void Set_Value_String(string section_name, string value_name, string value)
        {
            TMS_Info_Value tmp_value = Get_Value(section_name, value_name);

            if (tmp_value != null) tmp_value.Set_Value_String(value);
        }
        public void Set_Info(string section_name, string value_name, string info)
        {
            TMS_Info_Value tmp_value = Get_Value(section_name, value_name);

            if (tmp_value != null) tmp_value.Info = info;
        }



        public void Log_Diff(TLog log, string section, TMS_Param new_value, ref bool flag)
        {
            string log_name = "";
            TMS_Info_Value old_v = null;
            TMS_Info_Value new_v = null;

            for (int i = 0; i < Sections.Count; i++ )
            {
                for(int j=0; j<Sections[i].Values.Count; j++)
                {
                    old_v = Sections[i].Values[j];
                    if (i < new_value.Sections.Count && j < new_value.Sections[i].Values.Count) new_v = new_value.Sections[i].Values[j];
                    else new_v = null;

                    if (old_v != null && new_v != null)
                    {
                        log_name = section + "/" + Sections[i].Name + "/" + old_v.Name;
                        switch (old_v.Type)
                        {
                            case emMS_Info_Value_Type.Bool: log.Log_Diff(log_name, (bool)old_v.Value, (bool)new_v.Value, ref flag); break;
                            case emMS_Info_Value_Type.Int: log.Log_Diff(log_name, (int)old_v.Value, (int)new_v.Value, ref flag); break;
                            case emMS_Info_Value_Type.Double: log.Log_Diff(log_name, (double)old_v.Value, (double)new_v.Value, ref flag); break;
                            case emMS_Info_Value_Type.String: log.Log_Diff(log_name, (string)old_v.Value, (string)new_v.Value, ref flag); break;
                        }
                    }
                }
            }
        }
        public void Update_Tree(System.Windows.Forms.TreeView tree_view)
        {
            string node_str = "";
            TreeNode[] node = new TreeNode[3];

            node[0] = tree_view.Nodes[0];
            node[0].Nodes.Clear();
            for (int i = 0; i < Sections.Count; i++)
            {
                node_str = Item_Name_To_Node_Name(Sections[i].Name);
                TreeView_Tool.Add_Node_Name(node[0], node_str);
                node[1] = TreeView_Tool.Get_Sub_Node_Name(node[0], node_str);
            }
        }
        public string Item_Name_To_Node_Name(string item_name)
        {
            string result = "";
            ArrayList list = new ArrayList();

            String_Tool.Break_String(item_name, "/", ref list);
            for (int i = 0; i < list.Count; i++)
            {
                if (result == "") result = list[i].ToString();
                else result = result + "\\" + list[i].ToString();
            }
            return result;
        }
        public string Node_Name_To_Item_Name(string item_name)
        {
            string result = "";
            ArrayList list = new ArrayList();

            String_Tool.Break_String(item_name, "\\", ref list);
            for (int i = 0; i < list.Count; i++)
            {
                if (result == "") result = list[i].ToString();
                else result = result + "/" + list[i].ToString();
            }
            return result;
        }
        public void Disp_TreeView(System.Windows.Forms.TreeView tv)
        {
            string node_str = "";
            TreeNode[] node = new TreeNode[3];

            node[0] = tv.Nodes[0];
            node[0].Nodes.Clear();
            for (int i = 0; i < Sections.Count; i++)
            {
                node_str = Item_Name_To_Node_Name(Sections[i].Name);
                TreeView_Tool.Add_Node_Name(node[0], node_str);
                node[1] = TreeView_Tool.Get_Sub_Node_Name(node[0], node_str);
            }
        }
        public void Disp_Grid(DataGridView dg, TMS_Info_Section section)
        {
            DataGridViewButtonColumn cb = null;
            if (section != null)
            {
                cb = (DataGridViewButtonColumn)dg.Columns["C_Get_Pos"];
                cb.Text = "Get";
                cb.UseColumnTextForButtonValue = true;

                dg.RowCount = section.Values.Count;
                for (int i = 0; i < section.Values.Count; i++)
                {
                    dg.Rows[i].ReadOnly = section.Values[i].Flag_Read_Only;

                    
                    if (section.Values[i].Flag_Read_Only)
                    {
                        dg.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;
                    }
                    else if (section.Values[i].Flag_Ref)
                    {
                        dg.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    }
                    else
                        dg.Rows[i].DefaultCellStyle.BackColor = Color.White;

                    dg.Rows[i].Cells[0].Value = string.Format("{0:s}", section.Values[i].Name);
                    dg.Rows[i].Cells[1].Value = string.Format("{0:f3}", section.Values[i].Value);
                    dg.Rows[i].Cells[2].Value = string.Format("{0:s}", section.Values[i].Type_String);
                    dg.Rows[i].Cells[3].Value = string.Format("{0:s}", section.Values[i].Info);
                }
            }
        }
        public void Update_Grid(DataGridView dg, ref TMS_Info_Section section)
        {
            if (dg != null && section != null)
            {
                for (int i = 0; i < section.Values.Count; i++)
                {
                    switch(section.Values[i].Type)
                    {
                        case emMS_Info_Value_Type.Bool: section.Values[i].Set_Value_Bool((string)dg.Rows[i].Cells[1].Value); break;
                        case emMS_Info_Value_Type.Int: section.Values[i].Set_Value_Int((string)dg.Rows[i].Cells[1].Value); break;
                        case emMS_Info_Value_Type.Double: section.Values[i].Set_Value_Double((string)dg.Rows[i].Cells[1].Value); break;
                        case emMS_Info_Value_Type.String: section.Values[i].Set_Value_String((string)dg.Rows[i].Cells[1].Value); break;
                    }
                }
            }
        }
        public TMS_Info_Section Get_Section(System.Windows.Forms.TreeView tv)
        {
            TMS_Info_Section result = null;

            TreeNode node;
            ArrayList node_list = new ArrayList();
            string node_full_name = "";
            string tmp_name = "";
            string item_name = "";

            node = tv.SelectedNode;
            node_full_name = TreeView_Tool.Get_Node_Full_Name(node);
            if (node_full_name != "")
            {
                tmp_name = node_full_name.Substring(1, node_full_name.Length - 1);
                item_name = Node_Name_To_Item_Name(tmp_name);
                result = Sections[item_name];
            }
            return result;
        }
        public void Clear()
        {
            Sections.Clear();
        }
        public object Get_Value(emMS_Info_Value_Type type)
        {
            object result = null;

            switch (type)
            {
                case emMS_Info_Value_Type.Bool: result = new bool(); break;
                case emMS_Info_Value_Type.Int: result = new int(); break;
                case emMS_Info_Value_Type.Double: result = new double(); break;
                case emMS_Info_Value_Type.String: result = new string(' ', 0); break;
            }
            return result;
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public class TMS_Info_Section
    {
        public string Name;
        public TMS_Info_Value_List Values = new TMS_Info_Value_List();

        public TMS_Info_Section()
        {

        }
        public TMS_Info_Section(string name)
        {
            Name = name;
        }
        public void Copy(TMS_Info_Section sor, TMS_Info_Section dis)
        {
            dis.Name = sor.Name;
            dis.Values.Set(sor.Values);
        }
        public void Copy(TMS_Info_Section dis)
        {
            Copy(this, dis);
        }
        public TMS_Info_Section Copy()
        {
            TMS_Info_Section result = new TMS_Info_Section();
            Copy(this, result);
            return result;
        }
        public void Set(TMS_Info_Section sor)
        {
            Copy(sor, this);
        }
    }
    public class TMS_Info_Section_List : CollectionBase
    {
        public TMS_Info_Section_List()
        {

        }
        public TMS_Info_Section this[int index]
        {
            get
            {
                TMS_Info_Section result = null;
                if (index >= 0 && index < List.Count) result = (TMS_Info_Section)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count) 
                    List[index] = value.Copy();
            }
        }
        public TMS_Info_Section this[string name]
        {
            get
            {
                TMS_Info_Section result = null;
                int index = IndexOf_Name(name);
                if (index >= 0 && index < List.Count) result = (TMS_Info_Section)List[index];
                return result;
            }
            set
            {
                int index = IndexOf_Name(name);
                if (index >= 0 && index < List.Count)
                    List[index] = value.Copy();
            }
        }
        public int IndexOf(TMS_Info_Section section)
        {
            return this.List.IndexOf(section);
        }
        public int IndexOf_Name(string name)
        {
            int result = -1;
            TMS_Info_Section value = null;

            if (name != "")
            {
                for (int i = 0; i < List.Count; i++)
                {
                    value = (TMS_Info_Section)List[i];
                    if (value.Name == name)
                    {
                        result = i;
                        break;
                    }
                }
            }
            return result;
        }
        public void Add(string section_name)
        {
            Add(new TMS_Info_Section(section_name));
        }
        public void Add(TMS_Info_Section section)
        {
            if (IndexOf_Name(section.Name) < 0) List.Add(section.Copy());
            else Set_Data(section);
        }
        public void Set_Data(TMS_Info_Section section)
        {
            Set_Data(IndexOf_Name(section.Name), section);
        }
        public void Set_Data(int index, TMS_Info_Section section)
        {
            TMS_Info_Section tmp_section = this[index];
            if (tmp_section != null && section != null) section.Copy(tmp_section);
        }
        public void Remove(TMS_Info_Section section)
        {
            if (this.IndexOf(section) != -1)
                List.Remove(section);
        }
        public void Copy(TMS_Info_Section_List sor, TMS_Info_Section_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.Add(sor[i]);
        }
        public void Copy(ref TMS_Info_Section_List dis)
        {
            Copy(this, dis);
        }
        public TMS_Info_Section_List Copy()
        {
            TMS_Info_Section_List result = new TMS_Info_Section_List();
            Copy(this, result);
            return result;
        }
        public void Set(TMS_Info_Section_List sor)
        {
            Copy(sor, this);
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public class TMS_Info_Value : TBase_Class
    {
        public string Name;
        public string Info;
        public emMS_Info_Value_Type Type = emMS_Info_Value_Type.Double;
        public object Value = null;
        public evMS_Param_Value_Get Get_Fun = null;
        public bool Flag_Read_Only = false;
        public bool Flag_Ref = false;

        public string Type_String
        {
            get
            {
                string result = "none";

                switch (Type)
                {
                    case emMS_Info_Value_Type.Bool: result = "Bool"; break;
                    case emMS_Info_Value_Type.Int: result = "Int"; break;
                    case emMS_Info_Value_Type.Double: result = "Double"; break;
                    case emMS_Info_Value_Type.String: result = "String"; break;
                }
                return result;
            }
        }
        public TMS_Info_Value()
        {

        }
        public TMS_Info_Value(string name, emMS_Info_Value_Type type, object value, evMS_Param_Value_Get get_fun = null)
        {
            Set_Data(name, type, value, get_fun);
        }
        public TMS_Info_Value(string name, emMS_Info_Value_Type type, object value, string info, evMS_Param_Value_Get get_fun = null)
        {
            Set_Data(name, type, value, info, get_fun);
        }
        public TMS_Info_Value(string name, emMS_Info_Value_Type type, object value, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            Set_Data(name, type, value, info, flag_read_only, flag_ref, get_fun);
        }
        override public TBase_Class New_Class()
        {
            return new TMS_Info_Value();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMS_Info_Value && dis_base is TMS_Info_Value)
            {
                TMS_Info_Value sor = (TMS_Info_Value)sor_base;
                TMS_Info_Value dis = (TMS_Info_Value)dis_base;

                dis.Name = sor.Name;
                dis.Info = sor.Info;
                dis.Type = sor.Type;
                dis.Value = sor.Value;
                dis.Flag_Read_Only = sor.Flag_Read_Only;
                dis.Flag_Ref = sor.Flag_Ref;
                dis.Get_Fun = sor.Get_Fun;
            }
        }

        public void Set_Data(string name, emMS_Info_Value_Type type, object value, evMS_Param_Value_Get get_fun = null)
        {
            Name = name;
            Type = type;
            Value = value;
            Get_Fun = get_fun;
        }
        public void Set_Data(string name, emMS_Info_Value_Type type, object value, string info, evMS_Param_Value_Get get_fun = null)
        {
            Name = name;
            Type = type;
            Value = value;
            Get_Fun = get_fun;
            Info = info;
        }
        public void Set_Data(string name, emMS_Info_Value_Type type, object value, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            Name = name;
            Type = type;
            Value = value;
            Get_Fun = get_fun;
            Info = info;
            Flag_Read_Only = flag_read_only;
            Flag_Ref = flag_ref;
        }
        public void Set_Value_Bool(bool value)
        {
            Type = emMS_Info_Value_Type.Bool;
            Value = value;
        }
        public void Set_Value_Bool(string value)
        {
            Set_Value_Bool(String_Tool.StrToBool(value));
        }
        public void Set_Value_Int(int value)
        {
            Type = emMS_Info_Value_Type.Int;
            Value = value;
        }
        public void Set_Value_Int(string value)
        {
            Set_Value_Int(String_Tool.StrToInt(value));
        }
        public void Set_Value_Double(double value)
        {
            Type = emMS_Info_Value_Type.Double;
            Value = value;
        }
        public void Set_Value_Double(string value)
        {
            Set_Value_Double(String_Tool.StrToDouble(value));
        }
        public void Set_Value_String(string value)
        {
            Type = emMS_Info_Value_Type.String;
            Value = value;
        }
    }
    public class TMS_Info_Value_List : TBase_Class 
    {
        public TMS_Info_Value[] Items = new TMS_Info_Value[0];

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count;

                old_count = Items.Length;
                Array.Resize(ref Items, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Items[i] = new TMS_Info_Value();
                }
            }
        }
        public TMS_Info_Value_List()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TMS_Info_Value_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMS_Info_Value_List && dis_base is TMS_Info_Value_List)
            {
                TMS_Info_Value_List sor = (TMS_Info_Value_List)sor_base;
                TMS_Info_Value_List dis = (TMS_Info_Value_List)dis_base;

                dis.Count = sor.Count;
                for (int i = 0; i < sor.Count; i++) dis.Items[i].Set(sor.Items[i]);
            }
        }

        public TMS_Info_Value this[int index]
        {
            get
            {
                TMS_Info_Value result = null;
                if (index >= 0 && index < Items.Length) result = Items[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < Items.Length)
                    Items[index].Set(value);
            }
        }
        public TMS_Info_Value this[string name]
        {
            get
            {
                TMS_Info_Value result = null;
                int index = IndexOf_Name(name);
                return this[index];
            }
            set
            {
                int index = IndexOf_Name(name);
                this[index] = value;
            }
        }
        public int IndexOf_Name(string name)
        {
            int result = -1;

            if (name != "")
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i].Name == name)
                    {
                        result = i;
                        break;
                    }
                }
            }
            return result;
        }
        public void Add(string name, emMS_Info_Value_Type type, object value, evMS_Param_Value_Get get_fun = null)
        {
            Add(new TMS_Info_Value(name, type, value, get_fun));
        }
        public void Add(string name, emMS_Info_Value_Type type, object value, string info, evMS_Param_Value_Get get_fun = null)
        {
            Add(new TMS_Info_Value(name, type, value, info, get_fun));
        }
        public void Add(string name, emMS_Info_Value_Type type, object value, string info, bool flag_read_only, bool flag_ref, evMS_Param_Value_Get get_fun = null)
        {
            Add(new TMS_Info_Value(name, type, value, info, flag_read_only, flag_ref, get_fun));
        }
        public void Add(TMS_Info_Value value)
        {
            int no = 0;

            no = IndexOf_Name(value.Name);
            if (no < 0)
            {
                no = Count;
                Count++;
            }
            Items[no].Set(value);
        }
        public void Set_Data(TMS_Info_Value value)
        {
            Set_Data(IndexOf_Name(value.Name), value);
        }
        public void Set_Data(int index, TMS_Info_Value value)
        {
            TMS_Info_Value tmp_value = this[index];
            if (tmp_value != null && value != null) tmp_value.Set(value);
        }
        public void Remove(TMS_Info_Value value)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == value)
                {
                    RemoveAt(i);
                    break;
                }
            }
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Items.Length)
            {
                for (int i = index; i < Items.Length - 1; i++)
                {
                    Items[i] = Items[i + 1];
                }
                Array.Resize(ref Items, Count - 1);
            }
        }
    }
}
