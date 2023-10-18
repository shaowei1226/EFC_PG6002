using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;
using EFC.INI;

namespace EFC.CAD.CAD_DXF
{
    public enum emACAD_DXF_Type { None, Bin, String, Int8, Int16, Int32, Double, Handle, Comment }
    public class ACAD_DXF
    {
        public TDXF_Node Root = new TDXF_Node();
        public TDXF_Data_Section_HEADER HEADER = new TDXF_Data_Section_HEADER();
        public TDXF_Data_Section_CLASSES CLASSES = new TDXF_Data_Section_CLASSES();
        public TDXF_Data_Section_TABLES TABLES = new TDXF_Data_Section_TABLES();
        public TDXF_Data_Section_BLOCKS BLOCKS = new TDXF_Data_Section_BLOCKS();
        public TDXF_Data_Section_ENTITIES ENTITIES = new TDXF_Data_Section_ENTITIES();
        public TDXF_Data_Section_OBJECTS OBJECTS = new TDXF_Data_Section_OBJECTS();
 
        public ACAD_DXF()
        {
            Set_Default();
        }
        public bool Load_File(string filename)
        {
            bool result = false;
            TACAD_DXF_Value_List dxf_value_list = new TACAD_DXF_Value_List();
            TACAD_DXF_Value_List[] section_list = null;

            ArrayList list = new ArrayList();

            ArrayList_Tool.LoadFromFile(ref list, filename);
            if (Decode_To_Value_List(list, dxf_value_list))
            {
                section_list = Break_Value_List_To_Section(dxf_value_list);
                Set_Section(section_list);
                result = true;
            }
            return result;
        }
       
        
        private void Set_Default()
        {
            Root.Clear();
            Root.Name = "Main";
            HEADER.Root = Root.Add_SubNode(new TDXF_Node("HEADER"));
            CLASSES.Root = Root.Add_SubNode(new TDXF_Node("CLASSES"));
            TABLES.Root = Root.Add_SubNode(new TDXF_Node("TABLES"));
            BLOCKS.Root = Root.Add_SubNode(new TDXF_Node("BLOCKS"));
            ENTITIES.Root = Root.Add_SubNode(new TDXF_Node("ENTITIES"));
            OBJECTS.Root = Root.Add_SubNode(new TDXF_Node("OBJECTS"));
        }
        private emACAD_DXF_Type Get_Data_Type(string data)
        {
            //0              Section
            //1              ????????
            //2              Sub_Section
            //3-9            字符串（最多255个字符，对于UNICODE字符串则更少）
            //10-59          双精度三维点
            //60-79          16位整数值
            //90-99          32位整数值
            //100            字符串（最多255个字符，对于UNICODE字符串则更少）
            //102            字符串（最多255个字符，对于UNICODE字符串则更少）
            //105            表示十六进制句柄值的字符串
            //110-???        ????????
            //120-???        ????????
            //130-???        ????????

            //140-147        双精度标量浮点值
            //148-???        ????????

            //170-175        16位整数值
            //270-???        ???????? 
            //280-289        8位整数值
            //290-???        ????????

            //300-309        任意文字字符串
            //310-319        表示二进制数据组的十六进制值的字符串
            //320-329        表示十六进制句柄值的字符串
            //330-369        表示十六进制对象标识符的字符串
            //370-???        ????????

            //999            注释（字符串）
            //1000-1009      字符串（最多255个字符；对于UNICODE字符串则更少）
            //1010-1059      浮点值
            //1060-1070      16位整数值
            //1071           32位整数值
            emACAD_DXF_Type result = emACAD_DXF_Type.None;

            try
            {
                int no = Convert.ToInt32(data);
                if (no >= 0 && no <= 9) result = emACAD_DXF_Type.String;
                if (no >= 10 && no <= 59) result = emACAD_DXF_Type.Double;
                if (no >= 60 && no <= 79) result = emACAD_DXF_Type.Int16;
                if (no >= 90 && no <= 99) result = emACAD_DXF_Type.Int32;
                if (no == 100) result = emACAD_DXF_Type.String;
                if (no == 102) result = emACAD_DXF_Type.String;
                if (no == 105) result = emACAD_DXF_Type.Handle;

                if (no >= 110 && no <= 139) result = emACAD_DXF_Type.Double;   //????????

                if (no >= 140 && no <= 147) result = emACAD_DXF_Type.Double;
                if (no >= 147 && no <= 149) result = emACAD_DXF_Type.Double;   //????????
                if (no >= 170 && no <= 175) result = emACAD_DXF_Type.Int16;

                if (no >= 270 && no <= 279) result = emACAD_DXF_Type.Int8;     //????????
                if (no >= 280 && no <= 289) result = emACAD_DXF_Type.Int8;
                if (no >= 290 && no <= 299) result = emACAD_DXF_Type.Int8;     //????????

                if (no >= 300 && no <= 309) result = emACAD_DXF_Type.String;
                if (no >= 310 && no <= 319) result = emACAD_DXF_Type.Bin;
                if (no >= 320 && no <= 329) result = emACAD_DXF_Type.Handle;
                if (no >= 330 && no <= 369) result = emACAD_DXF_Type.Handle;

                if (no >= 370) result = emACAD_DXF_Type.Double;                //????????

                if (no >= 999) result = emACAD_DXF_Type.Comment;
                if (no >= 1000 && no <= 1009) result = emACAD_DXF_Type.String;
                if (no >= 1010 && no <= 1059) result = emACAD_DXF_Type.Double;
                if (no >= 1060 && no <= 1070) result = emACAD_DXF_Type.Int16;
                if (no >= 1071) result = emACAD_DXF_Type.Int32;
            }
            catch { };

            return result;
        }
        private bool Decode_To_Value_List(ArrayList dxf_list, TACAD_DXF_Value_List value_list)
        {
            bool result = true;
            int index = 0;
            emACAD_DXF_Type type = emACAD_DXF_Type.None;
            string index_code = "";
            string data_code = "";

            while (index < dxf_list.Count && result)
            {
                index_code = (string)dxf_list[index];
                type = Get_Data_Type(index_code);
                index++;
                data_code = (string)dxf_list[index];
                data_code = data_code.Trim();
                index++;

                if (type != emACAD_DXF_Type.None)
                {
                    TACAD_DXF_Value value = new TACAD_DXF_Value();
                    value.Code = Convert.ToInt32(index_code);
                    value.Type = type;
                    value.Value = data_code;
                    value_list.Add(value);
                }
                else result = false;
            }
            return result;
        }
        private TACAD_DXF_Value_List[] Break_Value_List_To_Section(TACAD_DXF_Value_List param)
        {
            TACAD_DXF_Value_List[] result = new TACAD_DXF_Value_List[20];
            bool in_section = false;
            int count = 0;
           
            for(int i=0; i<param.Count; i++)
            {
                if (param[i].Value == "SECTION") 
                {
                    in_section = true; 
                    count++;
                    result[count - 1] = new TACAD_DXF_Value_List();
                }
                if (param[i].Value == "ENDSEC") in_section = false;

                if (in_section)
                    if (count < result.Length) result[count - 1].Add(param[i]);
            }
            Array.Resize(ref result, count);

            for (int i = 0; i < result.Length; i++) result[i].Remove_First();
            return result;
        }
        private void Set_Section(TACAD_DXF_Value_List[] section_list)
        {
            TACAD_DXF_Value_List value_list = null;
            Set_Default();
            for (int i = 0; i < section_list.Length; i++)
            {
                value_list = section_list[i];
                switch (value_list[0].Value)
                {
                    case "HEADER": HEADER.Set(value_list); break;
                    case "CLASSES": CLASSES.Set(value_list); break;
                    case "TABLES": TABLES.Set(value_list); break;
                    case "BLOCKS": BLOCKS.Set(value_list); break;
                    case "ENTITIES": ENTITIES.Set(value_list); break;
                    case "OBJECTS": OBJECTS.Set(value_list); break;
                }
            }
        }
    }
    public class TACAD_DXF_Value : TBase_Class
    {
        public int Code = 0;
        public emACAD_DXF_Type Type = emACAD_DXF_Type.None;
        public string Value = "";

        public int V_Int
        {
            get
            {
                int result = 0;
                try
                {
                    result = Convert.ToInt32(Value);
                }
                catch { }
                return result;
            }
        }
        public double V_Double
        {
            get
            {
                double result = 0;
                try
                {
                    result = Convert.ToDouble(Value);
                }
                catch { }
                return result;
            }
        }
        public string V_String
        {
            get
            {
                return Value;
            }
        }
        public bool Is_Section
        {
            get
            {
                bool result = false;
                if (Code == 0 && Value == "SECTION") result = true;
                else result = false;
                return result;
            }
        }
        public bool Is_Sub_Section
        {
            get
            {
                bool result = false;
                if (Code == 2) result = true;
                else result = false;
                return result;
            }
        }
        public bool Is_End_Section
        {
            get
            {
                bool result = false;
                if (Code == 0 && Value == "ENDSEC") result = true;
                else result = false;
                return result;
            }
        }
        override public TBase_Class New_Class()
        {
            return new TACAD_DXF_Value();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TACAD_DXF_Value && dis_base is TACAD_DXF_Value)
            {
                TACAD_DXF_Value sor = (TACAD_DXF_Value)sor_base;
                TACAD_DXF_Value dis = (TACAD_DXF_Value)dis_base;
                dis.Code = sor.Code;
                dis.Type = sor.Type;
                dis.Value = sor.Value;
            }
        }
        public string Get_Type_Name(emACAD_DXF_Type type)
        {
            string result = "";
            switch (type)
            {
                case emACAD_DXF_Type.Bin: result = "Bin"; break;

                case emACAD_DXF_Type.Int8: result = "Int8"; break;
                case emACAD_DXF_Type.Int16: result = "Int16"; break;
                case emACAD_DXF_Type.Int32: result = "Int32"; break;

                case emACAD_DXF_Type.Double: result = "Double"; break;
                case emACAD_DXF_Type.String: result = "String"; break;
                case emACAD_DXF_Type.Handle: result = "Handle"; break;
                case emACAD_DXF_Type.None: result = "None"; break;
                default: result = "None"; break;
            }
            return result;
        }
        override public string ToString()
        {
            string result = "";
            result = string.Format("{0:d},{1:s},{2:s}", Code, Get_Type_Name(Type), Value);
            return result;
        }
        public bool Equals(TACAD_DXF_Value in_obj)
        {
            if (Code != in_obj.Code) return false;
            if (Type != in_obj.Type) return false;
            if (Value != in_obj.Value) return false;
            return true;
        }
    }
    public class TACAD_DXF_Value_List : CollectionBase
    {
        public TACAD_DXF_Value_List()
        {
        }
        public TACAD_DXF_Value this[int index]
        {
            get
            {
                TACAD_DXF_Value result = null;
                if (index >= 0 && index < List.Count) result = (TACAD_DXF_Value)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    TACAD_DXF_Value tmp_obj = (TACAD_DXF_Value)List[index];
                    value.Copy(tmp_obj);
                }
            }
        }
        public TACAD_DXF_Value Get_Value_By_Code(int code)
        {
            TACAD_DXF_Value result = null;

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Code == code)
                {
                    result = this[i];
                    break;
                }
            }
            return result;
        }
        public int IndexOf(TACAD_DXF_Value member)
        {
            return this.List.IndexOf(member);
        }
        public void Add(TACAD_DXF_Value member)
        {
            TACAD_DXF_Value tmp_obj = new TACAD_DXF_Value();
            tmp_obj.Set(member);
            this.List.Add(tmp_obj);
        }
        public void Remove(TACAD_DXF_Value member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }
        public void Remove_First()
        {
            if (Count > 0) List.RemoveAt(0);
        }
        public void Remove_Last()
        {
            if (Count > 0) List.RemoveAt(Count - 1);
        }

        public void Copy(TACAD_DXF_Value_List sor, TACAD_DXF_Value_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.List.Add(sor[i]);
        }
        public void Copy(ref TACAD_DXF_Value_List dis)
        {
            Copy(this, dis);
        }
        public TACAD_DXF_Value_List Copy()
        {
            TACAD_DXF_Value_List result = new TACAD_DXF_Value_List();
            Copy(this, result);
            return result;
        }
        public void Set(TACAD_DXF_Value_List sor)
        {
            Copy(sor, this);
        }
        public bool Equals(TACAD_DXF_Value_List in_obj)
        {
            if (Count != in_obj.Count) return false;
            for (int i = 0; i < in_obj.Count; i++)
            {
                if (!this[i].Equals(in_obj[i])) return false;
            }
            return true;
        }
    }

    //------------------------------------------------------
    //DXF Section
    //------------------------------------------------------
    public class TDXF_Node : TBase_Class
    {
        public string Name;
        public TDXF_Node[] SubNodes = new TDXF_Node[0];
        public TACAD_DXF_Value_List Values = new TACAD_DXF_Value_List();

        public int SubNodes_Count
        {
            get
            {
                return SubNodes.Length;
            }
            set
            {
                int old_count;

                old_count = SubNodes.Length;
                Array.Resize(ref SubNodes, value);
                for (int i = old_count; i < value; i++)
                    SubNodes[i] = new TDXF_Node();
            }
        }



        public TDXF_Node()
        {
            Clear();
        }
        public TDXF_Node(string name)
        {
            Clear();
            Name = name;
        }
        public void Clear()
        {
            SubNodes_Count = 0;
        }
        override public TBase_Class New_Class()
        {
            return new TDXF_Node();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TDXF_Node && dis_base is TDXF_Node)
            {
                TDXF_Node sor = (TDXF_Node)sor_base;
                TDXF_Node dis = (TDXF_Node)dis_base;
                dis.Name = sor.Name;
                dis.SubNodes_Count = sor.SubNodes_Count;
                for (int i = 0; i < sor.SubNodes.Length; i++) dis.SubNodes[i].Set(sor.SubNodes[i]);
            }
        }

       
        public bool Equals(TDXF_Node in_node)
        {
            //判定Type是否相等
            if (Name != in_node.Name) return false;
            if (!Values.Equals(in_node.Values)) return false;
            if (SubNodes.Length != in_node.SubNodes.Length) return false;

            for (int i = 0; i < SubNodes.Length; i++)
                if (!SubNodes[i].Equals(in_node.SubNodes[i])) return false;

            return true;
        }
        public TDXF_Node Add_SubNode(TDXF_Node node)
        {
            return Append_SubNode(SubNodes.Length, node);
        }
        public TDXF_Node Append_SubNode(int index, TDXF_Node node)
        {
            TDXF_Node result = null;

            SubNodes_Count++;
            SubNodes[SubNodes_Count - 1].Set(node);
            SubNode_Move(SubNodes_Count - 1, index);
            result = SubNodes[index];
            return result;
        }
        public bool Delete_SubNode(int index)
        {
            //TSxFx_Node* new_item;
            //
            //if (index < FSubNode_Count && FSubNode_Count > 0)
            //{
            //    new_item = SubNode[index];
            //    for (int i = index; i < FSubNode_Count - 1; i++)
            //        SubNode[i] = SubNode[i + 1];
            //
            //    SubNode[FSubNode_Count - 1] = new_item;
            //    new_item->Free();
            //    FSubNode_Count--;
            //    return true;
            //};
            return false;
        }
        public void SubNode_MoveUp(int index)
        {
            SubNode_Move(index, index - 1);
        }
        public void SubNode_MoveDn(int index)
        {
            SubNode_Move(index, index + 1);
        }
        public void SubNode_Move(int src, int dest)
        {
            TDXF_Node tmp;

            if (src >= 0 && dest >= 0 && dest < SubNodes.Length && src < SubNodes.Length && dest != src)
            {
                tmp = SubNodes[dest];
                SubNodes[src] = SubNodes[dest];
                SubNodes[dest] = tmp;
            }
        }
        public TDXF_Node Get_Node(ArrayList name_list)
        {
            TDXF_Node result = null;

            if (name_list.Count == 1)
            {
                if (Name == (string)name_list[0]) result = this;
            }
            else if(name_list.Count > 1)
            {
                ArrayList tmp_node_list = (ArrayList)name_list.Clone();
                tmp_node_list.RemoveAt(0);

                for (int i = 0; i < SubNodes.Length; i++)
                {
                    result = SubNodes[i].Get_Node(tmp_node_list);
                    if (result != null) break;
                }
            }
            return result;
        }
        public TDXF_Node Get_Node(string name_list)
        {
            ArrayList tmp_list = new ArrayList();

            String_Tool.Break_String(name_list, "/", ref tmp_list);
            return Get_Node(tmp_list);
        }
        public TDXF_Node[] Get_Nodes(ArrayList name_list)
        {
            TDXF_Node[] result = new TDXF_Node[0];
            string name = "";
            ArrayList tmp_list = new ArrayList();
            TDXF_Node pre_node = null;
            int count = 0;

            if (name_list.Count > 0)
            {
                name = (string)name_list[name_list.Count - 1];
                tmp_list = ArrayList_Tool.Sub_String(name_list, 0, name_list.Count - 1);
                if (name_list.Count == 1)
                {
                    if (Name == name)
                    {
                        count++;
                        result = new TDXF_Node[1];
                        result[0] = this;
                    }
                }
                if (name_list.Count > 1)
                {
                    pre_node = Get_Node(tmp_list);
                    if(pre_node != null)
                    {
                        result = new TDXF_Node[pre_node.SubNodes_Count];
                        for (int i = 0; i < pre_node.SubNodes_Count; i++)
                        {
                            if (pre_node.SubNodes[i].Name == name)
                           {
                               result[count] = pre_node.SubNodes[i];
                               count++;
                           }
                        }
                    }
                }
            }

            Array.Resize(ref result, count);
            if (result.Length == 0) result = null;
            return result;
        }
        public TDXF_Node[] Get_Nodes(string name_list)
        {
            ArrayList tmp_list = new ArrayList();

            String_Tool.Break_String(name_list, "/", ref tmp_list);
            return Get_Nodes(tmp_list);
        }
        public void To_ArrayList(ArrayList list, int level)
        {
            string pre_str = String_Count(" ", level * 5);
            string v_pre_str = String_Count(" ", (level + 1) * 5);

            list.Add(pre_str + "+" + Name);
            for (int i = 0; i < SubNodes_Count; i++)
            {
                SubNodes[i].To_ArrayList(list, level + 1);
            }
            for (int i = 0; i < Values.Count; i++)
            {
                list.Add(v_pre_str + Values[i].Value);
            }
        }
        public string String_Count(string str, int count)
        {
            string result = "";
            for (int i = 0; i < count; i++) result = result + str;
            return result;
        }
        private void Add_Node(System.Windows.Forms.TreeNode tree_node, TDXF_Node dxf_node)
        {
            System.Windows.Forms.TreeNode tree_sub_node;

            tree_sub_node = tree_node.Nodes.Add(dxf_node.Name);
            for (int i = 0; i < dxf_node.SubNodes.Length; i++)
            {
                Add_Node(tree_sub_node, dxf_node.SubNodes[i]);
            }
            for (int i = 0; i < dxf_node.Values.Count; i++)
            {
                tree_sub_node.Nodes.Add(dxf_node.Values[i].Value);
            }
        }
        public void To_Tree(System.Windows.Forms.TreeView tree)
        {
            System.Windows.Forms.TreeNode tree_node;

            tree.Nodes.Clear();
            tree_node = tree.Nodes.Add("Root");
            Add_Node(tree_node, this);
        }
        public void To_ListBox(System.Windows.Forms.ListBox list_box)
        {
            ArrayList list = new ArrayList();
            To_ArrayList(list, 0);

            list_box.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                list_box.Items.Add(list[i]);
            }
        }
        public int Get_Value_Int(int no)
        {
            int result = 0;
            if (Values.Count > no) result = Values[no].V_Int;
            return result;
        }
        public double Get_Value_Double(int no)
        {
            double result = 0.0;
            if (Values.Count > no) result = Values[no].V_Double;
            return result;
        }
        public string Get_Value_String(int no)
        {
            string result = "";
            if (Values.Count > no) result = Values[no].V_String;
            return result;
        }
       
        private void Break_Name_List(string name_list, ref string name, ref string sub_name_list)
        {
            int pos;

            pos = name_list.IndexOf("/");
            if (pos >= 0)
            {
                name = name_list.Substring(0, pos);
                sub_name_list = name_list.Substring(pos + 1);
            }
            else
            {
                name = name_list;
                sub_name_list = "";
            }
        }
    }

    //------------------------------------------------------
    //DXF Section
    //------------------------------------------------------
    abstract public class TDXF_Data_Section
    {
        public TDXF_Node Root = null;
        public TACAD_DXF_Value_List Value_List = new TACAD_DXF_Value_List();

        public TDXF_Data_Section()
        {

        }
        public TDXF_Data_Section(TDXF_Node node, TACAD_DXF_Value_List value_list)
        {
            Root = node;
            Set(value_list);
        }
        virtual public bool Set(TACAD_DXF_Value_List value_list)
        {
            bool result = true;
            Value_List.Set(value_list);
            if (Root != null) Root.Clear();
            return result;
        }
        public bool In_Key_List(string value, string[] keys)
        {
            bool result = false;

            for (int i = 0; i < keys.Length; i++)
                if (value == keys[i]) return true;
            return result;
        }
    }
    public class TDXF_Data_Section_HEADER : TDXF_Data_Section
    {
        public TDXF_Data_UCSORG UCSORG
        {
            get
            {
                TDXF_Data_UCSORG result = new TDXF_Data_UCSORG();
                TDXF_Node node = Root.Get_Node("HEADER/$UCSORG");
                if (node != null) result.Set(node);
                return result;
            }
        }

        public TDXF_Data_Section_HEADER()
        {
        }
        public TDXF_Data_Section_HEADER(TDXF_Node node, TACAD_DXF_Value_List value_list)
        {
            Root = node;
            Set(value_list);
        }
        override public bool Set(TACAD_DXF_Value_List value_list)
        {
            bool error_flag = false;
            int index = 1;

            base.Set(value_list);
            Add_Node(Root, Value_List, ref index, ref error_flag);
            return !error_flag;
        }
        public void Add_Node(TDXF_Node in_node, TACAD_DXF_Value_List in_list, ref int index, ref bool error_flag)
        {
            TDXF_Node tmp_node = null;
            bool end_flag = false;
            bool can_sub_node = true;

            while (index < in_list.Count && !end_flag && !error_flag)
            {
                if (Is_Key(in_list[index]))
                {
                    if (can_sub_node)
                    {
                        TDXF_Node new_node = new TDXF_Node();
                        new_node.Name = in_list[index].Value;
                        tmp_node = in_node.Add_SubNode(new_node);
                        index++;
                        Add_Node(tmp_node, in_list, ref index, ref error_flag);
                    }
                    else end_flag = true;
                }
                else
                {
                    can_sub_node = false;
                    in_node.Values.Add(in_list[index]);
                    index++;
                }
            }
        }
        public bool Is_Key(TACAD_DXF_Value value)
        {
            bool result = false;
            string str = "";

            if (value.Value.Length > 0)
            {
                str = value.Value.Substring(0, 1);
                if (str == "$") return true;
            }
            return result;
        }
    }
    public class TDXF_Data_Section_CLASSES : TDXF_Data_Section
    {
        public string[] CLASSES_Key = new string[] { "CLASS" };

        public TDXF_Data_Section_CLASSES()
        {
        }
        public TDXF_Data_Section_CLASSES(TDXF_Node node, TACAD_DXF_Value_List value_list)
        {
            Root = node;
            Set(value_list);
        }
        override public bool Set(TACAD_DXF_Value_List value_list)
        {
            bool error_flag = false;
            int index = 1;

            base.Set(value_list);
            Add_Node(Root, Value_List, ref index, ref error_flag);
            return !error_flag;
        }
        public void Add_Node(TDXF_Node in_node, TACAD_DXF_Value_List in_list, ref int index, ref bool error_flag)
        {
            TDXF_Node tmp_node = null;
            bool end_flag = false;
            bool can_sub_node = true;

            while (index < in_list.Count && !end_flag && !error_flag)
            {
                if (Is_Key(in_list[index]))
                {
                    if (can_sub_node)
                    {
                        TDXF_Node new_node = new TDXF_Node();
                        new_node.Name = in_list[index].Value;
                        tmp_node = in_node.Add_SubNode(new_node);
                        index++;
                        Add_Node(tmp_node, in_list, ref index, ref error_flag);
                    }
                    else end_flag = true;
                }
                else
                {
                    can_sub_node = false;
                    in_node.Values.Add(in_list[index]);
                    index++;
                }
            }
        }
        public bool Is_Key(TACAD_DXF_Value value)
        {
            bool result = false;

            if (value.Code == 0 && In_Key_List(value.Value, CLASSES_Key)) return true;
            if (value.Code == 0)
            {
                //須確認的名稱
            }
            return result;
        }
    }
    public class TDXF_Data_Section_TABLES : TDXF_Data_Section
    {
        public string[] TABLES_Key = new string[] { "Table" };
        public string[] TABLE_Key = new string[] { "APPID", "BLOCK_RECORD", "DIMSTYLE", "LAYER", "LTYPE", "STYLE", "UCS", "VIEW", "VPORT" };

        public TDXF_Data_Section_TABLES()
        {
        }
        public TDXF_Data_Section_TABLES(TDXF_Node node, TACAD_DXF_Value_List value_list)
        {
            Root = node;
            Set(value_list);
        }
        override public bool Set(TACAD_DXF_Value_List value_list)
        {
            bool error_flag = false;
            int index = 1;
            TACAD_DXF_Value_List[] table_list = null;

            base.Set(value_list);
            Get_Table(Value_List, ref table_list);
            for (int i = 0; i < table_list.Length; i++)
            {
                TDXF_Node new_node = new TDXF_Node();
                TDXF_Node tmp_node = null;
                new_node.Name = table_list[i][0].Value;
                tmp_node = Root.Add_SubNode(new_node);
                index = 1;
                Add_Table_Node(tmp_node, table_list[i], ref index, ref error_flag);
                if (error_flag) break;
            }
            return !error_flag;
        }
        public void Add_Table_Node(TDXF_Node in_node, TACAD_DXF_Value_List in_list, ref int index, ref bool error_flag)
        {
            TDXF_Node tmp_node = null;
            bool end_flag = false;
            bool can_sub_node = true;

            while (index < in_list.Count && !end_flag && !error_flag)
            {
                if (Is_Key(in_list[index]))
                {
                    if (can_sub_node)
                    {
                        TDXF_Node new_node = new TDXF_Node();
                        new_node.Name = in_list[index].Value;
                        tmp_node = in_node.Add_SubNode(new_node);
                        index++;
                        Add_Table_Node(tmp_node, in_list, ref index, ref error_flag);
                    }
                    else end_flag = true;
                }
                else
                {
                    can_sub_node = false;
                    in_node.Values.Add(in_list[index]);
                    index++;
                }
            }
        }
        public void Get_Table(TACAD_DXF_Value_List in_list, ref TACAD_DXF_Value_List[] table_list)
        {
            int count = 0;
            bool in_table = false;

            table_list = new TACAD_DXF_Value_List[100];
            for (int i = 0; i < in_list.Count; i++)
            {
                if (in_list[i].Code == 0 && in_list[i].Value == "ENDTAB") in_table = false;

                if (in_list[i].Code == 0 && in_list[i].Value == "TABLE")
                {
                    in_table = true;
                    count++;
                    table_list[count - 1] = new TACAD_DXF_Value_List();
                }

                if (in_table)
                {
                    table_list[count - 1].Add(in_list[i]);
                }
            }
            Array.Resize(ref table_list, count);
        }
        public bool Is_Key(TACAD_DXF_Value value)
        {
            bool result = false;

            //if (value.Code == 0 && value.Value == "TABLE") return true;
            if (value.Code == 2 && In_Key_List(value.Value, TABLE_Key)) return true;
            if (value.Code == 2)
            {
                //須確認的名稱
            }
            return result;
        }
    }
    public class TDXF_Data_Section_BLOCKS : TDXF_Data_Section
    {
        public string[] BLOCKS_Key = new string[] { "BLOCK", "ENDBLK" };

        public TDXF_Data_Section_BLOCKS()
        {
        }
        public TDXF_Data_Section_BLOCKS(TDXF_Node node, TACAD_DXF_Value_List value_list)
        {
            Root = node;
            Set(value_list);
        }
        override public bool Set(TACAD_DXF_Value_List value_list)
        {
            bool error_flag = false;
            int index = 1;

            base.Set(value_list);
            Add_Node(Root, Value_List, ref index, ref error_flag);
            return !error_flag;
        }
        public void Add_Node(TDXF_Node in_node, TACAD_DXF_Value_List in_list, ref int index, ref bool error_flag)
        {
            TDXF_Node tmp_node = null;
            bool end_flag = false;
            bool can_sub_node = true;

            while (index < in_list.Count && !end_flag && !error_flag)
            {
                if (Is_Key(in_list[index]))
                {
                    if (can_sub_node)
                    {
                        TDXF_Node new_node = new TDXF_Node();
                        new_node.Name = in_list[index].Value;
                        tmp_node = in_node.Add_SubNode(new_node);
                        index++;
                        Add_Node(tmp_node, in_list, ref index, ref error_flag);
                    }
                    else end_flag = true;
                }
                else
                {
                    can_sub_node = false;
                    in_node.Values.Add(in_list[index]);
                    index++;
                }
            }
        }
        public bool Is_Key(TACAD_DXF_Value value)
        {
            bool result = false;

            if (value.Code == 0 && In_Key_List(value.Value, BLOCKS_Key)) return true;
            if (value.Code == 0)
            {
                //須確認的名稱
            }
            return result;
        }
    }
    public class TDXF_Data_Section_ENTITIES : TDXF_Data_Section
    {
        public string[] ENTITIES_Key = new string[] { "3DFACE", "3DSOLID", "ACAD_PROXY_ENTITY", "ARC", "ATTDEF", "ATTRIB",
                                                      "BODY", "CIRCLE", "DIMENSION", "ELLIPSE", "HATCH", "HELIX", "IMAGE",
                                                      "INSERT", "LEADER", "LIGHT", "LINE", "LWPOLYLINE", "MESH", "MLINE",
                                                      "MLEADERSTYLE", "MLEADER", "MTEXT", "OLEFRAME", "OLE2FRAME", "POINT",
                                                      "POLYLINE", "RAY", "REGION", "SECTION", "SEQEND", "SHAPE", "SOLID",
                                                      "SPLINE", "SUN", "SURFACE", "TABLE", "TEXT", "TOLERANCE", "TRACE",
                                                      "UNDERLAY", "VERTEX", "VIEWPORT", "WIPEOUT", "XLINE"};

        public TDXF_Data_Arc[] Arcs
        {
            get
            {
                TDXF_Data_Arc[] result = null;
                TDXF_Node[] nodes = Root.Get_Nodes("ENTITIES/ARC");
                if (nodes != null)
                {
                    result = new TDXF_Data_Arc[nodes.Length];
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        result[i] = new TDXF_Data_Arc();
                        result[i].Set(nodes[i]);
                    }
                }
                return result;
            }
        }
        public TDXF_Data_Circle[] Circles
        {
            get
            {
                TDXF_Data_Circle[] result = null;
                TDXF_Node[] nodes = Root.Get_Nodes("ENTITIES/CIRCLE");
                if (nodes != null)
                {
                    result = new TDXF_Data_Circle[nodes.Length];
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        result[i] = new TDXF_Data_Circle();
                        result[i].Set(nodes[i]);
                    }
                }
                return result;
            }
        }
        public TDXF_Data_Line[] Lines
        {
            get
            {
                TDXF_Data_Line[] result = null;
                TDXF_Node[] nodes = Root.Get_Nodes("ENTITIES/LINE");
                if (nodes != null)
                {
                    result = new TDXF_Data_Line[nodes.Length];
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        result[i] = new TDXF_Data_Line();
                        result[i].Set(nodes[i]);
                    }
                }
                return result;
            }
        }
        public TDXF_Data_Polyline[] Polylines
        {
            get
            {
                TDXF_Data_Polyline[] result = null;
                TDXF_Node[] nodes = Root.Get_Nodes("ENTITIES/LWPOLYLINE");
                if (nodes != null)
                {
                    result = new TDXF_Data_Polyline[nodes.Length];
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        result[i] = new TDXF_Data_Polyline();
                        result[i].Set(nodes[i]);
                    }
                }
                return result;
            }
        }
        public TDXF_Data_Section_ENTITIES()
        {
        }
        public TDXF_Data_Section_ENTITIES(TDXF_Node node, TACAD_DXF_Value_List value_list)
        {
            Root = node;
            Set(value_list);
        }
        override public bool Set(TACAD_DXF_Value_List value_list)
        {
            bool error_flag = false;
            int index = 1;

            base.Set(value_list);
            Add_Node(Root, Value_List, ref index, ref error_flag);
            return !error_flag;
        }
        public void Add_Node(TDXF_Node in_node, TACAD_DXF_Value_List in_list, ref int index, ref bool error_flag)
        {
            TDXF_Node tmp_node = null;
            bool end_flag = false;
            bool can_sub_node = true;

            while (index < in_list.Count && !end_flag && !error_flag)
            {
                if (Is_Key(in_list[index]))
                {
                    if (can_sub_node)
                    {
                        TDXF_Node new_node = new TDXF_Node();
                        new_node.Name = in_list[index].Value;
                        tmp_node = in_node.Add_SubNode(new_node);
                        index++;
                        Add_Node(tmp_node, in_list, ref index, ref error_flag);
                    }
                    else end_flag = true;
                }
                else
                {
                    can_sub_node = false;
                    in_node.Values.Add(in_list[index]);
                    index++;
                }
            }
        }
        public bool Is_Key(TACAD_DXF_Value value)
        {
            bool result = false;

            if (value.Code == 0 && In_Key_List(value.Value, ENTITIES_Key)) return true;
            if (value.Code == 0)
            {
                //須確認的名稱
            } 
            return result;
        }
    }
    public class TDXF_Data_Section_OBJECTS : TDXF_Data_Section
    {
        public string[] OBJECTS_Key = new string[] { "ACAD_PROXY_OBJECT", "ACDBDICTIONARYWDFLT", "ACDBPLACEHOLDER", 
                                                     "DATATABLE", "DICTIONARY", "DICTIONARYVAR", "DIMASSOC", "FIELD", 
                                                     "GEODATA", "GROUP", "IDBUFFER", "IMAGEDEF", "IMAGEDEF_REACTOR",
                                                      "LAYER_INDEX", "LAYER_FILTER", "LAYOUT", "LIGHTLIST", "MATERIAL",
                                                      "MLINESTYLE", "OBJECT_PTR", "PLOTSETTINGS", "RASTERVARIABLES",
                                                      "RENDER", "SECTION", "SPATIAL_INDEX", "SPATIAL_FILTER",
                                                      "SORTENTSTABLE", "TABLESTYLE", "UNDERLAYDEFINITION", "VISUALSTYLE",
                                                      "VBA_PROJECT", "WIPEOUTVARIABLES", "XRECORD"};

        public TDXF_Data_Section_OBJECTS()
        {
        }
        public TDXF_Data_Section_OBJECTS(TDXF_Node node, TACAD_DXF_Value_List value_list)
        {
            Root = node;
            Set(value_list);
        }
        override public bool Set(TACAD_DXF_Value_List value_list)
        {
            bool error_flag = false;
            int index = 1;

            base.Set(value_list);
            Add_Node(Root, Value_List, ref index, ref error_flag);
            return !error_flag;
        }
        public void Add_Node(TDXF_Node in_node, TACAD_DXF_Value_List in_list, ref int index, ref bool error_flag)
        {
            TDXF_Node tmp_node = null;
            bool end_flag = false;
            bool can_sub_node = true;

            while (index < in_list.Count && !end_flag && !error_flag)
            {
                if (Is_Key(in_list[index]))
                {
                    if (can_sub_node)
                    {
                        TDXF_Node new_node = new TDXF_Node();
                        new_node.Name = in_list[index].Value;
                        tmp_node = in_node.Add_SubNode(new_node);
                        index++;
                        Add_Node(tmp_node, in_list, ref index, ref error_flag);
                    }
                    else end_flag = true;
                }
                else
                {
                    can_sub_node = false;
                    in_node.Values.Add(in_list[index]);
                    index++;
                }
            }
        }
        public bool Is_Key(TACAD_DXF_Value value)
        {
            bool result = false;

            if (value.Code == 0 && In_Key_List(value.Value, OBJECTS_Key)) return true;
            if (value.Code == 0)
            {
                //須確認的名稱
            }
            return result;
        }
    }


    //------------------------------------------------------
    //DXF Section
    //------------------------------------------------------
    public class TDXF_Data_UCSORG
    {
        public double X, Y, Z;
        public void Set(TDXF_Node node)
        {
            X = node.Get_Value_Double(0);
            Y = node.Get_Value_Double(1);
            Z = node.Get_Value_Double(2);
        }
    }
    public class TDXF_Data_Arc
    {
        public string Layer = "";
        public double Center_X = 0.0, Center_Y = 0.0, Center_Z = 0.0;
        public double Radius = 0.0;
        public double Start_Angle = 0.0;
        public double End_Angle = 0.0;

        public TDXF_Data_Arc()
        {
            Set_Default();
        }
        public void Set_Default()
        {
            Layer = "";
            Center_X = 0.0;
            Center_Y = 0.0;
            Center_Z = 0.0;
            Radius = 0.0;
            Start_Angle = 0.0;
            End_Angle = 0.0;
       }
        public void Set(TDXF_Node node)
        {
            Set_Default();
            if (node != null)
            {
                for (int i = 0; i < node.Values.Count; i++)
                {
                    switch (node.Values[i].Code)
                    {
                        case 100: break;                                       //子類別標籤
                        case 39: break;                                        //厚度
                        case 8: Layer = node.Values[i].V_String; break;        //圖層

                        case 10: Center_X = node.Values[i].V_Double; break;    //中心X座標
                        case 20: Center_Y = node.Values[i].V_Double; break;    //中心Y座標
                        case 30: Center_Z = node.Values[i].V_Double; break;    //中心Z座標
                        case 40: Radius = node.Values[i].V_Double; break;      //半徑

                        case 50: Start_Angle = node.Values[i].V_Double; break; //起始角度
                        case 51: End_Angle = node.Values[i].V_Double; break;   //結束角度

                        case 210: break;                                       //擠出方向 X
                        case 220: break;                                       //擠出方向 Y
                        case 230: break;                                       //擠出方向 Z
                    }
                }
            }
        }
        public void Ofs(double x, double y, double z = 0.0)
        {
            Center_X = Center_X + x;
            Center_Y = Center_Y + y;
            Center_Z = Center_Z + z;
        }
        override public string ToString()
        {
            string result = "";
            result = string.Format("Layer={0:s}, Center_X={1:f}, Center_Y={2:f}, Center_Z={3:f}, Radius={4:f}, Start_Angle={5:f}, End_Angle={6:f}",
                                   Layer, Center_X, Center_Y, Center_Z, Radius, Start_Angle, End_Angle);
            return result;
        }
    }
    public class TDXF_Data_Circle
    {
        public string Layer = "";
        public double Center_X = 0.0, Center_Y = 0.0, Center_Z = 0.0;
        public double Radius = 0.0;

        public TDXF_Data_Circle()
        {
            Set_Default();
        }
        public void Set_Default()
        {
            Layer = "";
            Center_X = 0.0;
            Center_Y = 0.0;
            Center_Z = 0.0;
            Radius = 0.0;
        }
        public void Set(TDXF_Node node)
        {
            Set_Default();
            if (node != null)
            {
                for (int i = 0; i < node.Values.Count; i++)
                {
                    switch (node.Values[i].Code)
                    {
                        case 100: break;                                       //子類別標籤
                        case 39: break;                                        //厚度
                        case 8: Layer = node.Values[i].V_String; break;        //圖層

                        case 10: Center_X = node.Values[i].V_Double; break;    //中心X座標
                        case 20: Center_Y = node.Values[i].V_Double; break;    //中心Y座標
                        case 30: Center_Z = node.Values[i].V_Double; break;    //中心Z座標
                        case 40: Radius = node.Values[i].V_Double; break;      //半徑

                        case 210: break;                                       //擠出方向 X
                        case 220: break;                                       //擠出方向 Y
                        case 230: break;                                       //擠出方向 Z
                    }
                }
            }
        }
        public void Ofs(double x, double y, double z = 0.0)
        {
            Center_X = Center_X + x;
            Center_Y = Center_Y + y;
            Center_Z = Center_Z + z;
        }
        override public string ToString()
        {
            string result = "";
            result = string.Format("Layer={0:s}, Center_X={1:f}, Center_Y={2:f}, Center_Z={3:f}, Radius={4:f}",
                                   Layer, Center_X, Center_Y, Center_Z, Radius);
            return result;
        }
    }
    public class TDXF_Data_Line
    {
        public string Layer = "";
        public double S_X = 0.0, S_Y = 0.0, S_Z = 0.0, E_X = 0.0, E_Y = 0.0, E_Z = 0.0;

        public TDXF_Data_Line()
        {
            Set_Default();
        }
        public void Set_Default()
        {
            Layer = "";
            S_X = 0.0;
            S_Y = 0.0;
            S_Z = 0.0;
            E_X = 0.0;
            E_Y = 0.0;
            E_Z = 0.0;
        }
        public void Set(TDXF_Node node)
        {
            Set_Default();
            if (node != null)
            {
                for (int i = 0; i < node.Values.Count; i++)
                {
                    switch (node.Values[i].Code)
                    {
                        case 100: break;                                       //子類別標籤
                        case 39: break;                                        //厚度
                        case 8: Layer = node.Values[i].V_String; break;        //圖層

                        case 10: S_X = node.Values[i].V_Double; break;         //起點X座標
                        case 20: S_Y = node.Values[i].V_Double; break;         //起點Y座標
                        case 30: S_Z = node.Values[i].V_Double; break;         //起點Z座標
                        case 11: E_X = node.Values[i].V_Double; break;         //終點X座標
                        case 21: E_Y = node.Values[i].V_Double; break;         //終點Y座標
                        case 31: E_Z = node.Values[i].V_Double; break;         //終點Z座標

                        case 210: break;                                       //擠出方向 X
                        case 220: break;                                       //擠出方向 Y
                        case 230: break;                                       //擠出方向 Z
                    }
                }
            }
        }
        public void Ofs(double x, double y, double z = 0.0)
        {
            S_X = S_X + x;
            S_Y = S_Y + y;
            S_Z = S_Z + z;
            E_X = E_X + x;
            E_Y = E_Y + y;
            E_Z = E_Z + z;
        }
        override public string ToString()
        {
            string result = "";
            result = string.Format("Layer={0:s}, S_X={1:f}, S_Y={2:f}, S_Z={3:f}, E_X={4:f}, E_Y={5:f}, E_Z={6:f}",
                                   Layer, S_X, S_Y, S_Z, E_X, E_Y, E_Z);
            return result;
        }
    }
    public class TDXF_Data_Polyline
    {
        public string Layer = "";
        public int Close_Loop = 0;
        public TDXF_Data_PolyLine_Point[] Point = new TDXF_Data_PolyLine_Point[0];

        public int Point_Count
        {
            get
            {
                return Point.Length;
            }
            set
            {
                int old_count;

                old_count = Point.Length;
                Array.Resize(ref Point, value);
                for (int i = old_count; i < value; i++)
                    Point[i] = new TDXF_Data_PolyLine_Point();
            }
        }
        public TDXF_Data_Polyline()
        {
            Set_Default();
        }
        public void Set_Default()
        {
            Layer = "";
            Close_Loop = 0;
            Point_Count = 0;
        }
        public void Set(TDXF_Node node)
        {
            int point_no = 0;
            bool set_flag = false;

            Set_Default();
            if (node != null)
            {
                for (int i = 0; i < node.Values.Count; i++)
                {
                    switch (node.Values[i].Code)
                    {
                        case 100: break;                                       //子類別標籤
                        case 90: Point_Count = node.Values[i].V_Int; break;    //頂點數
                        case 70: Close_Loop = node.Values[i].V_Int; break;     //聚合線旗標 1:封閉
                        case 43: break;                                        //固定寬度
                        case 38: break;                                        //高程
                        case 39: break;                                        //厚度
                        case 8: Layer = node.Values[i].V_String; break;        //圖層

                        case 10:                                               //X座標
                            if (set_flag) point_no++;
                            if (point_no < Point_Count)
                            {
                                Point[point_no].X = node.Values[i].V_Double;
                                set_flag = true;
                            }
                            break;

                        case 20:                                               //Y座標
                            if (point_no < Point_Count)
                                Point[point_no].Y = node.Values[i].V_Double;
                            break;

                        case 91: break;                                        //頂點識別
                        case 40: break;                                        //起點寬度
                        case 41: break;                                        //終點寬度

                        case 42:                                               //凸度
                            if (point_no < Point_Count)
                                Point[point_no].DZ = node.Values[i].V_Double;
                            break;

                        case 210: break;                                       //擠出方向 X
                        case 220: break;                                       //擠出方向 Y
                        case 230: break;                                       //擠出方向 Z
                    }
                }
            }
        }
        public void Ofs(double x, double y)
        {
            for (int i = 0; i < Point_Count; i++)
            {
                Point[i].Ofs(x, y);
            }
        }
        override public string ToString()
        {
            string result = "";
            result = string.Format("Layer={0:s}, Point_Count={1:d}, Loop={2:d}", Layer, Point_Count, Close_Loop);
            return result;
        }
    }
    public class TDXF_Data_PolyLine_Point
    {
        public double X, Y;
        public double DZ;

        public TDXF_Data_PolyLine_Point()
        {
            Set_Default();
        }
        public void Set_Default()
        {
            X = 0.0;
            Y = 0.0;
            DZ = 0.0;
        }
        public void Ofs(double x, double y)
        {
            X = X + x;
            Y = Y + y;
        }
        override public string ToString()
        {
            string result = "";
            result = string.Format("X={0:f}, Y={1:f}, DZ={2:f}", X, Y, DZ);
            return result;
        }
    }
}
