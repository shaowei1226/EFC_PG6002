using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using System.Windows.Forms;
using EFC.Tool;


namespace EFC.INI
{
    public interface ITBase_Ini
    {
        void Set_Default();
        bool Read(string filename = "", string section = "Default");
        bool Write(string filename = "", string section = "Default");
        void Read(TJJS_XML_File ini, string section);
        void Write(TJJS_XML_File ini, string section);
        void Read_Other_File();
        void Write_Other_File();
    }

    public class TJJS_XML_File
    {
        public string Path;
        public string File_Name;
        public XmlDocument XML;

        public TJJS_XML_File()
        {
            Path = "";
            File_Name = "";
            Clear();
        }
        public TJJS_XML_File(string file_name)
        {
            Clear();
            Load_File(file_name);
        }
        public void Clear()
        {
            XML = new XmlDocument();
            XmlElement elem = XML.CreateElement("Root");
            XML.AppendChild(elem);
        }
        public bool Load_File()
        {
            return Load_File(Path + File_Name);
        }
        public bool Load_File(string file_name)
        {
            bool result = false;
            Path = System.IO.Path.GetDirectoryName(file_name) + "\\";
            File_Name = System.IO.Path.GetFileName(file_name);
            if (System.IO.File.Exists(file_name))
            {
                try
                {
                    XML.Load(file_name);
                    result = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Read " + file_name + "Error!(XML_File)");
                    Clear();
                }

            }
            else
                Clear();

            return result;
        }
        public bool Save_File()
        {
            return Save_File(Path + File_Name);
        }
        public bool Save_File(string file_name)
        {
            Path = System.IO.Path.GetDirectoryName(file_name) + "\\";
            File_Name = System.IO.Path.GetFileName(file_name);
            System.IO.Directory.CreateDirectory(Path);
            XML.Save(file_name);
            return true;
        }
        public void Load_String(string str)
        {
            XML.LoadXml(str);
        }
        public string To_String()
        {
            return XML.InnerXml;
        }

        //添加節點
        private XmlNode Create_Element(string str_element, string inner_str = "")
        {
            XmlNode result;
            XmlElement elem;

            if (XML.DocumentElement == null)
            {
                elem = XML.CreateElement("Root");
                result = XML.AppendChild(elem);
            }
            else
                result = Create_Element(XML.DocumentElement, str_element, inner_str);

            return result;
        }
        private XmlNode Create_Element(XmlNode in_node, string str_element, string inner_str)
        {
            XmlNode result;
            XmlElement elem;
            XmlNode node, s_node, add_node;
            string[] element_list;

            node = in_node;
            element_list = str_element.Split('/');
            foreach (string ele_str in element_list)
            {
                add_node = null;
                if (node != null)
                {
                    if (ele_str == "")
                        s_node = node;
                    else
                        s_node = node.SelectSingleNode(ele_str);

                    //找不到節點後新增節點
                    if (s_node == null)
                    {
                        elem = XML.CreateElement(ele_str);
                        elem.InnerText = inner_str;
                        add_node = node.AppendChild(elem);
                    }
                    else
                        add_node = s_node;
                }
                else
                {
                    elem = XML.CreateElement(ele_str);
                    add_node = XML.AppendChild(elem);
                }
                node = add_node;
            }
            result = node;
            return result;
        }
        private XmlNode Delete_Element(string str_element)
        {
            return Delete_Element(XML.DocumentElement, str_element);
        }
        private XmlNode Delete_Element(XmlNode node, string str_element)
        {
            XmlNode result;
            XmlNode tmp_node;

            tmp_node = node.SelectSingleNode(str_element);
            result = node.RemoveChild(tmp_node);
            return result;
        }
        public string Get_Attribute(XmlElement element, string attr_name, string default_value)
        {
            string result;

            result = default_value;
            if (element != null)
            {
                result = element.GetAttribute(attr_name);
            }
            return result;
        }
        public string Get_Attribute(XmlNode node, string attr_name, string default_value)
        {
            return Get_Attribute((XmlElement)node, attr_name, default_value);
        }
        public XmlNode Get_Child_Node(XmlNode node, string child_node_name)
        {
            XmlNode result = null;

            for (int i = 0; i < node.ChildNodes.Count; i++)
            {
                if (node.ChildNodes[i].Name == child_node_name)
                {
                    result = node.ChildNodes[i];
                    break;
                }
            }
            return result;
        }


        public bool ReadBool(string section_list, string name, bool default_value)
        {
            return ReadBool(section_list, name, "value", default_value);
        }
        public double ReadFloat(string section_list, string name, double default_value)
        {
            return ReadFloat(section_list, name, "value", default_value);
        }
        public int ReadInteger(string section_list, string name, int default_value)
        {
            return ReadInteger(section_list, name, "value", default_value);
        }
        public string ReadString(string section_list, string name, string default_value)
        {
            return ReadString(section_list, name, "value", default_value);
        }
        public bool ReadBool(string section_list, string name, string attr_name, bool default_value)
        {
            bool result = default_value;
            XmlNode node = XML.DocumentElement;
            if (node != null)
            {
                if (section_list == "")
                    node = node.SelectSingleNode(name);
                else
                    node = node.SelectSingleNode(section_list + "/" + name);
                result = Convert.ToBoolean(Get_Attribute(node, attr_name, default_value.ToString()));
            }
            return result;
        }
        public double ReadFloat(string section_list, string name, string attr_name, double default_value)
        {
            double result = default_value;
            XmlNode node = XML.DocumentElement;
            if (node != null)
            {
                try
                {
                    if (section_list == "")
                        node = node.SelectSingleNode(name);
                    else
                        node = node.SelectSingleNode(section_list + "/" + name);
                }
                catch
                {
                    node = null;
                };

                result = Convert.ToDouble(Get_Attribute(node, attr_name, default_value.ToString()));
            }
            return result;
        }
        public int ReadInteger(string section_list, string name, string attr_name, int default_value)
        {
            int result = default_value;
            XmlNode node = XML.DocumentElement;
            if (node != null)
            {
                if (section_list == "")
                    node = node.SelectSingleNode(name);
                else
                    node = node.SelectSingleNode(section_list + "/" + name);
                result = Convert.ToInt32(Get_Attribute(node, attr_name, default_value.ToString()));
            }
            return result;
        }
        public string ReadString(string section_list, string name, string attr_name, string default_value)
        {
            string result = default_value;
            XmlNode node = XML.DocumentElement;
            if (node != null)
            {
                if (section_list == "")
                    node = node.SelectSingleNode(name);
                else
                    node = node.SelectSingleNode(section_list + "/" + name);
                result = Get_Attribute(node, attr_name, default_value);
            }
            return result;
        }



        public void WriteBool(string section_list, string name, bool value)
        {
            WriteBool(section_list, name, "value", value);
        }
        public void WriteFloat(string section_list, string name, double value)
        {
            WriteFloat(section_list, name, "value", value);
        }
        public void WriteInteger(string section_list, string name, int value)
        {
            WriteInteger(section_list, name, "value", value);
        }
        public void WriteString(string section_list, string name, string value)
        {
            WriteString(section_list, name, "value", value);
        }
        public void WriteBool(string section_list, string name, string attr_name, bool value)
        {
            XmlElement elem;

            elem = (XmlElement)Create_Element(section_list + "/" + name);
            if (elem != null) elem.SetAttribute(attr_name, value.ToString());
        }
        public void WriteFloat(string section_list, string name, string attr_name, double value)
        {
            XmlElement elem;

            elem = (XmlElement)Create_Element(section_list + "/" + name);
            if (elem != null) elem.SetAttribute(attr_name, value.ToString());
        }
        public void WriteInteger(string section_list, string name, string attr_name, int value)
        {
            XmlElement elem;

            elem = (XmlElement)Create_Element(section_list + "/" + name);
            if (elem != null) elem.SetAttribute(attr_name, value.ToString());
        }
        public void WriteString(string section_list, string name, string attr_name, string value)
        {
            XmlElement elem;

            elem = (XmlElement)Create_Element(section_list + "/" + name);
            if (elem != null) elem.SetAttribute(attr_name, value);
        }
    }
    public class TJJS_XML_Tool
    {
        //----------------------------------------------------------------------------------------------------
        // section_list format
        // sample: Items[1].ItemName[2].ItemType
        //
        //----------------------------------------------------------------------------------------------------

        static public TJJS_XmlNodeList Get_Node_List(XmlNode node, TSection_Data_List section_data_list)
        {
            TJJS_XmlNodeList result = new TJJS_XmlNodeList();
            XmlNode tmp_node = null;
            XmlNodeList node_list = null;
            TSection_Data section_data = null;

            tmp_node = node;
            for (int i = 0; i < section_data_list.Count; i++)
            {
                section_data = section_data_list[i];
                if (tmp_node != null)
                {
                    node_list = tmp_node.SelectNodes(section_data.Name);
                    if (i < section_data_list.Count - 1)
                    {
                        if (section_data.Index >= 0 && section_data.Index < node_list.Count)
                            tmp_node = node_list[section_data.Index];
                        else 
                            tmp_node = null;
                    }
                    else
                    {
                        if (section_data.Index < 0)
                        {
                            result.Add(node_list);
                        }
                        else
                        {
                            result.Add(node_list[section_data.Index]);
                        }
                    }
                }
            }
            return result;
        }
        static public TJJS_XmlNodeList Get_Node_List(XmlNode node, string section_list)
        {
            TJJS_XmlNodeList result = null;

            result = Get_Node_List(node, new TSection_Data_List(section_list));
            return result;
        }
        static public int Get_Node_List_Count(XmlNode node, string section_list)
        {
            int result = 0;
            TJJS_XmlNodeList node_list = null;

            node_list = Get_Node_List(node, new TSection_Data_List(section_list));
            result = node_list.Count;
            return result;
        }


        #region Create function
        static public void Create_Section(XmlDocument xml, XmlNode node, string section_list)
        {
            Create_Section(xml, node, new TSection_Data_List(section_list));
        }
        static public void Create_Section(XmlDocument xml, XmlNode node, TSection_Data_List section_data_list)
        {
            XmlElement new_node = null;
            TSection_Data section_data = null;
            XmlNode tmp_node = null;
            XmlNodeList node_list = null;
            int add_count = 0;

            if (xml != null && node != null)
            {
                tmp_node = node;
                for (int i = 0; i < section_data_list.Count; i++ )
                {
                    section_data = section_data_list[i];
                    node_list = tmp_node.SelectNodes(section_data.Name);
                    if (section_data.Index < 0 && node_list.Count == 0) add_count = 1;
                    else if (node_list.Count < section_data.Index + 1) add_count = section_data.Index - node_list.Count + 1;
                    else add_count = 0;
                    
                    for(int j=0; j<add_count; j++)
                    {
                        new_node = xml.CreateElement(section_data.Name);
                        tmp_node.AppendChild(new_node);
                    }
                    node_list = tmp_node.SelectNodes(section_data.Name);

                    if (section_data.Index == -1)
                        tmp_node = node_list[0];
                    else
                        tmp_node = node_list[section_data.Index];
                }
            }
        }
        static public void Delete_Section(XmlDocument xml, string section_list)
        {
            Delete_Section(xml.DocumentElement, new TSection_Data_List(section_list));
        }
        static public void Delete_Section(XmlNode node, string section_list)
        {
            Delete_Section(node, new TSection_Data_List(section_list));
        }
        static public void Delete_Section(XmlNode node, TSection_Data_List section_data_list)
        {
            TJJS_XmlNodeList get_node_list = Get_Node_List(node, section_data_list);
            for (int i = 0; i < get_node_list.Count; i++)
                node.RemoveChild(get_node_list[i]);
        }
        #endregion

        #region Read function
        static public bool[] ReadBool_List(XmlNode node, string section_list, bool default_value)
        {
            bool[] result = null;
            string[] string_list = ReadString_List(node, section_list, default_value.ToString());

            if (string_list != null)
            {
                result = new bool[string_list.Length];
                for (int i = 0; i < string_list.Length; i++)
                    result[i] = Convert.ToBoolean(string_list[i]); 
            }
            return result;
        }
        static public double[] ReadFloat_List(XmlNode node, string section_list, double default_value)
        {
            double[] result = null;
            string[] string_list = ReadString_List(node, section_list, default_value.ToString());

            if (string_list != null)
            {
                result = new double[string_list.Length];
                for (int i = 0; i < string_list.Length; i++)
                    result[i] = Convert.ToDouble(string_list[i]);
            }
            return result;
        }
        static public int[] ReadInteger_List(XmlNode node, string section_list, int default_value)
        {
            int[] result = null;
            string[] string_list = ReadString_List(node, section_list, default_value.ToString());

            if (string_list != null)
            {
                result = new int[string_list.Length];
                for (int i = 0; i < string_list.Length; i++)
                    result[i] = Convert.ToInt32(string_list[i]);
            }
            return result;
        }
        static public string[] ReadString_List(XmlNode node, string section_list, string default_value)
        {
            string[] result = null;
            XmlElement get_node = null;
            TJJS_XmlNodeList node_list = Get_Node_List(node, section_list);

            if (node_list != null)
            {
                result = new string[node_list.Count];
                for (int i = 0; i < node_list.Count; i++)
                {
                    get_node = (XmlElement)node_list[i];
                    result[i] = get_node.InnerText;
                }
            }
            return result;
        }


        static public bool[] ReadBool_Attribute_List(XmlNode node, string section_list, string key, bool default_value)
        {
            bool[] result = null;
            string[] string_list = ReadString_Attribute_List(node, section_list, key, default_value.ToString());

            if (string_list != null)
            {
                result = new bool[string_list.Length];
                for (int i = 0; i < string_list.Length; i++)
                    result[i] = Convert.ToBoolean(string_list[i]);
            }
            return result;
        }
        static public double[] ReadFloat_Attribute_List(XmlNode node, string section_list, string key, double default_value)
        {
            double[] result = null;
            string[] string_list = ReadString_Attribute_List(node, section_list, key, default_value.ToString());

            if (string_list != null)
            {
                result = new double[string_list.Length];
                for (int i = 0; i < string_list.Length; i++)
                    result[i] = Convert.ToDouble(string_list[i]);
            }
            return result;
        }
        static public int[] ReadInteger_Attribute_List(XmlNode node, string section_list, string key, int default_value)
        {
            int[] result = null;
            string[] string_list = ReadString_Attribute_List(node, section_list, key, default_value.ToString());

            if (string_list != null)
            {
                result = new int[string_list.Length];
                for (int i = 0; i < string_list.Length; i++)
                    result[i] = Convert.ToInt32(string_list[i]);
            }
            return result;
        }
        static public string[] ReadString_Attribute_List(XmlNode node, string section_list, string key, string default_value)
        {
            string[] result = null;
            XmlElement get_node = null;
            TJJS_XmlNodeList node_list = Get_Node_List(node, section_list);

            if (node_list != null)
            {
                result = new string[node_list.Count];
                for (int i = 0; i < node_list.Count; i++)
                {
                    get_node = (XmlElement)node_list[i];
                    result[i] = get_node.GetAttribute(key);
                }
            }
            return result;
        }


        static public bool ReadBool(XmlNode node, string section_list, bool default_value)
        {
            bool result = default_value;

            bool[] read_list = ReadBool_List(node, section_list, default_value);
            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }
        static public double ReadFloat(XmlNode node, string section_list, double default_value)
        {
            double result = default_value;

            double[] read_list = ReadFloat_List(node, section_list, default_value);
            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }
        static public int ReadInteger(XmlNode node, string section_list, int default_value)
        {
            int result = default_value;

            int[] read_list = ReadInteger_List(node, section_list, default_value);

            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }
        static public string ReadString(XmlNode node, string section_list, string default_value)
        {
            string result = default_value;

            string[] read_list = ReadString_List(node, section_list, default_value);
            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }

        static public bool ReadBool_Attribute(XmlNode node, string section_list, string key, bool default_value)
        {
            bool result = default_value;

            bool[] read_list = ReadBool_List(node, section_list, default_value);
            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }
        static public double ReadFloat_Attribute(XmlNode node, string section_list, string key, double default_value)
        {
            double result = default_value;

            double[] read_list = ReadFloat_List(node, section_list, default_value);
            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }
        static public int ReadInteger_Attribute(XmlNode node, string section_list, string key, int default_value)
        {
            int result = default_value;

            int[] read_list = ReadInteger_List(node, section_list, default_value);

            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }
        static public string ReadString_Attribute(XmlNode node, string section_list, string key, string default_value)
        {
            string result = default_value;

            string[] read_list = ReadString_List(node, section_list, default_value);
            if (read_list != null && read_list.Length > 0) result = read_list[0];
            return result;
        }
        #endregion

        #region write function
        static public void WriteBool_List(XmlNode node, string section_list, bool[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.InnerText = value[i].ToString();
            }
        }
        static public void WriteFloat_List(XmlNode node, string section_list, double[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.InnerText = value[i].ToString();
            }
        }
        static public void WriteInteger_List(XmlNode node, string section_list, int[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.InnerText = value[i].ToString();
            }
        }
        static public void WriteString_List(XmlNode node, string section_list, string[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.InnerText = value[i].ToString();
            }
        }

        static public void WriteBool_Attribute_List(XmlNode node, string section_list, string key, bool[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.SetAttribute(key, value[i].ToString());
            }
        }
        static public void WriteFloat_Attribute_List(XmlNode node, string section_list, string key, double[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.SetAttribute(key, value[i].ToString());
            }
        }
        static public void WriteInteger_Attribute_List(XmlNode node, string section_list, string key, int[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.SetAttribute(key, value[i].ToString());
            }
        }
        static public void WriteString_Attribute_List(XmlNode node, string section_list, string key, string[] value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                if (i < value.Length)
                    get_node.SetAttribute(key, value[i].ToString());
            }
        }
        
        static public void WriteBool(XmlNode node, string section_list, bool value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.InnerText = value.ToString();
            }
        }
        static public void WriteFloat(XmlNode node, string section_list, double value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.InnerText = value.ToString();
            }
        }
        static public void WriteInteger(XmlNode node, string section_list, int value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.InnerText = value.ToString();
            }
        }
        static public void WriteString(XmlNode node, string section_list, string value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.InnerText = value.ToString();
            }
        }

        static public void WriteBool_Attribute(XmlNode node, string section_list, string key, bool value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.SetAttribute(key, value.ToString());
            }
        }
        static public void WriteFloat_Attribute(XmlNode node, string section_list, string key, double value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.SetAttribute(key, value.ToString());
            }
        }
        static public void WriteInteger_Attribute(XmlNode node, string section_list, string key, int value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.SetAttribute(key, value.ToString());
            }
        }
        static public void WriteString_Attribute(XmlNode node, string section_list, string key, string value)
        {
            TJJS_XmlNodeList get_node_list = null;
            XmlElement get_node = null;

            get_node_list = Get_Node_List(node, section_list);
            for (int i = 0; i < get_node_list.Count; i++)
            {
                get_node = (XmlElement)get_node_list[i];
                get_node.SetAttribute(key, value.ToString());
            }
        }
        #endregion

        static public void AddBool(XmlDocument xml, XmlNode node, string section_list, bool value)
        {
            Create_Section(xml, node, section_list);
            WriteBool(node, section_list, value);
        }
        static public void AddFloat(XmlDocument xml, XmlNode node, string section_list, double value)
        {
            Create_Section(xml, node, section_list);
            WriteFloat(node, section_list, value);
        }
        static public void AddInteger(XmlDocument xml, XmlNode node, string section_list, int value)
        {
            Create_Section(xml, node, section_list);
            WriteInteger(node, section_list, value);
        }
        static public void AddString(XmlDocument xml, XmlNode node, string section_list, string value)
        {
            Create_Section(xml, node, section_list);
            WriteString(node, section_list, value);
        }


        static public bool Exist(XmlNode node, string section_list)
        {
            bool result = false;
            TJJS_XmlNodeList get_node_list = null;

            get_node_list = Get_Node_List(node, section_list);
            result = (get_node_list.Count > 0);
            return result;
        }
        static private string Get_Attr_String(XmlNode elem, bool add_attr)
        {
            string result = "";
            int count;

            if (elem != null)
            {
                count = elem.Attributes.Count;
                for (int i = 0; i < count; i++)
                {
                    result = result
                             + " "
                             + elem.Attributes.Item(i).Name
                             + "="
                             + elem.Attributes.Item(i).Value;
                }
            }
            return result;
        }
        static private string Get_Ini_Attr_String(XmlNode elem)
        {
            string result = "";
            int count;

            if (elem != null)
            {
                count = elem.Attributes.Count;
                for (int i = 0; i < count; i++)
                {
                    if (elem.Attributes.Item(i).Name == "value")
                    {
                        result = "=" + elem.Attributes.Item(i).Value;
                    }
                }
            }
            return result;
        }
        static private string Get_Attribute(XmlElement element, string attr_name, string default_value)
        {
            string result;

            result = default_value;
            if (element != null)
            {
                result = element.GetAttribute(attr_name);
            }
            return result;
        }
        static private string Get_Attribute(XmlNode node, string attr_name, string default_value)
        {
            return Get_Attribute((XmlElement)node, attr_name, default_value);
        }


        private static void Add_Sub_Tree_Node(TreeNode tree_node, XmlNode xml_node, bool add_attr)
        {
            System.Windows.Forms.TreeNode tree_sub_node;
            XmlNode xml_sub_node;
            int child_count;

            child_count = xml_node.ChildNodes.Count;
            for (int i = 0; i < child_count; i++)
            {
                xml_sub_node = xml_node.ChildNodes[i];
                if (xml_sub_node.Name != "#text")
                {
                    tree_sub_node = tree_node.Nodes.Add(xml_sub_node.Name + Get_Attr_String(xml_sub_node, add_attr));
                    Add_Sub_Tree_Node(tree_sub_node, xml_sub_node, add_attr);
                }
            }
        }
        private static void Add_Ini_Sub_Tree_Node(TreeNode tree_node, XmlNode xml_node)
        {
            System.Windows.Forms.TreeNode tree_sub_node;
            XmlNode xml_sub_node;
            int child_count;

            child_count = xml_node.ChildNodes.Count;
            for (int i = 0; i < child_count; i++)
            {
                xml_sub_node = xml_node.ChildNodes[i];
                if (xml_sub_node.Name != "#text")
                {
                    tree_sub_node = tree_node.Nodes.Add(xml_sub_node.Name + Get_Ini_Attr_String(xml_sub_node));
                    Add_Ini_Sub_Tree_Node(tree_sub_node, xml_sub_node);
                }
            }
        }
        public static void Display_TreeView(TreeView tree, XmlDocument xml, bool add_attr = false)
        {
            System.Windows.Forms.TreeNode tree_node;
            XmlNode xml_node;

            tree.Nodes.Clear();
            xml_node = xml.DocumentElement;
            if (xml_node != null)
            {
                while (xml_node != null)
                {
                    tree_node = tree.Nodes.Add(xml_node.Name + Get_Attr_String(xml_node, add_attr));
                    Add_Sub_Tree_Node(tree_node, xml_node, add_attr);
                    xml_node = xml.NextSibling;
                }
            }
        }
        public static void Display_TreeView(TreeView tree, TJJS_XML_File ini)
        {
            System.Windows.Forms.TreeNode tree_node;
            XmlNode xml_node;

            tree.Nodes.Clear();
            xml_node = ini.XML.DocumentElement;
            if (xml_node != null)
            {
                while (xml_node != null)
                {
                    tree_node = tree.Nodes.Add(xml_node.Name + Get_Ini_Attr_String(xml_node));
                    Add_Ini_Sub_Tree_Node(tree_node, xml_node);
                    xml_node = ini.XML.NextSibling;
                }
            }
        }
    }

    public class TSection_Data_List : CollectionBase
    {
        public TSection_Data_List()
        {

        }
        public TSection_Data_List(string section_list)
        {
            Set_Data(section_list);
        }
        public TSection_Data this[int index]
        {
            get
            {
                TSection_Data result = null;

                if (index >= 0 && index < List.Count) result = (TSection_Data)List[index];
                return result;
            }
            set
            {
                TSection_Data item = null;
                if (index >= 0 && index < List.Count)
                {
                    item.Set(value);
                }
            }
        }
        public void Add(TSection_Data data)
        {
            List.Add(data);
        }
        public bool Set_Data(string section_list)
        {
            bool result = true;
            ArrayList list = new ArrayList();
            TSection_Data value_data = null;

            String_Tool.Break_String(section_list, ".", ref list);
            if (list.Count > 0 && list[0].ToString() == "") list.RemoveAt(0);

            for (int i = 0; i < list.Count; i++)
            {
                value_data = Get_Value_Data(list[i].ToString());
                if (value_data != null) Add(value_data);
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }


        private TSection_Data Get_Value_Data(string value)
        {
            TSection_Data result = null;
            string name_str = "";
            string count_str = "";

            int pos1 = value.IndexOf("[");
            int pos2 = value.IndexOf("]");
            if (pos1 < 0 && pos2 < 0)
            {
                name_str = value;
                count_str = "-1";
                result = new TSection_Data(name_str, count_str);
            }
            else if (pos1 >= 0 && pos2 >= 0)
            {
                name_str = value.Substring(0, pos1);
                count_str = value.Substring(pos1 + 1, pos2 - pos1 - 1);
                result = new TSection_Data(name_str, count_str);
            }

            return result;
        }
    }
    public class TSection_Data : TBase_Class
    {
        public string Name = "";
        public int Index = -1;

        public TSection_Data()
        {

        }
        public TSection_Data(string name, int index = -1)
        {
            Name = name;
            Index = index;
        }
        public TSection_Data(string name, string index = "-1")
        {
            Name = name;
            Index = Convert.ToInt32(index);
        }

        override public TBase_Class New_Class()
        {
            return new TSection_Data();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {

        }
    }

    public class TJJS_XmlNodeList : CollectionBase
    {
        public TJJS_XmlNodeList()
        {

        }
        public void Add(XmlNodeList node_list)
        {
            for (int i = 0; i < node_list.Count; i++)
                List.Add(node_list[i]);
        }
        public void Add(XmlNode node)
        {
            if (node != null) List.Add(node);
        }
        public  XmlNode this[int index]
        {
            get
            {
                XmlNode result = null;
                if (index >= 0 && index < Count) result = (XmlNode)List[index];
                return result;
            }
        }

    }
}