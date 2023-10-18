using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;

namespace EFC.Language
{
    public enum emLanguage { Traditional, English, Simplified };

    public static class TLanguage
    {
        static public void Get_Compoent(Form form, ref ArrayList ctl_list)
        {
            Get_Compoent(form.Controls, ref ctl_list);
        }
        static public void Get_Compoent(Control.ControlCollection controls, ref ArrayList ctl_list)
        {
            Control control;

            for (int i = 0; i < controls.Count; i++)
            {
                control = controls[i];
                ctl_list.Add(control);
                if (control.Controls.Count > 0)
                {
                    Get_Compoent(control.Controls, ref ctl_list);
                }
            }
        }
        static public string Get_Parent(Control obj)
        {
            string result = "";

            Get_Parent(obj, ref result);
            return result;
        }
        static public void Get_Parent(Control obj, ref string owner)
        {
            if (obj.Parent != null)
            {
                if (owner == "") owner = obj.Parent.Name;
                else owner = obj.Parent.Name + "/" + owner;
                Get_Parent(obj.Parent, ref owner);
            }
        }
        static public string Get(string key)
        {
            string result = "";

            return result;
        }
        //static public void Copy(string path, string form_name)
        //{
        //    string sor_file_name = path + form_name + ".txt";
        //    string dis_file_name = path + form_name + ".new";
        //    string bak_file_name = path + form_name + ".bak";

        //    TLanguage_Items sor = new TLanguage_Items();
        //    TLanguage_Items dis = new TLanguage_Items();
        //    TLanguage_Item item;

        //    sor.Read_File(sor_file_name);
        //    dis.Read_File(dis_file_name);
        //    for (int i = 0; i < dis.Count; i++)
        //    {
        //        item = sor[dis[i].Form_Name, dis[i].Key];
        //        if (item != null)
        //            dis[i].Set_Value(item.Values);
        //    }
        //    System.IO.File.Copy(sor_file_name, bak_file_name);
        //    dis.Save_File(sor_file_name);
        //}
        static public string Get_Language(emLanguage language)
        {
            string result = "繁體中文";
            switch (language)
            {
                case emLanguage.Traditional: result = "繁體中文"; break;
                case emLanguage.English: result = "English"; break;
                case emLanguage.Simplified: result = "簡體中文"; break;
            }
            return result;
        }
        static public emLanguage Get_Language(string language_name)
        {
            emLanguage result = emLanguage.Traditional;

            switch (language_name)
            {
                case "繁體中文": result = emLanguage.Traditional; break;
                case "English":  result = emLanguage.English; break;
                case "簡體中文": result = emLanguage.Simplified; break;
            }
            return result;
        }
        static public string[] Get_Language_List()
        {
            string[] result = new string[3];

            result[0] = Get_Language(emLanguage.Traditional);
            result[1] = Get_Language(emLanguage.English);
            result[2] = Get_Language(emLanguage.Simplified);
            return result;
        }
        static public void Break_File_Name(string full_file_name, ref string path, ref string file_name, ref string ext)
        {
            ext = System.IO.Path.GetExtension(full_file_name);
            file_name = System.IO.Path.GetFileNameWithoutExtension(full_file_name);
            path = System.IO.Path.GetDirectoryName(full_file_name);
        }
        static public string Change_File_Ext(string file_name, string new_ext)
        {
            string result = "";
            string path = "", file = "", ext = "";

            Break_File_Name(file_name, ref path, ref file, ref ext);
            if (path == "")
                result = file + new_ext;
            else
                result = path + "\\" + file + new_ext;

            return result;
        }
    }

    public class TLanguage_Items
    {
        public string Default_Path = "";
        public string Default_File = "Language.csv";
        public ArrayList Items = new ArrayList();


        private string[]   inLanguage_Names = new string[0];
        private int        inLanguage_Index = 0;

        public int Language_Count
        {
            get
            {
                return inLanguage_Names.Length;
            }
        }
        public int Language_Index
        {
            get
            {
                return Language_Index;
            }
            set
            {
                if (value >= 0 && value < Language_Count)
                    inLanguage_Index = value;
            }

        }
        public int Count
        {
            get
            {
                return Items.Count;
            }
        }
        public emLanguage Language
        {
            get
            {
                emLanguage result = emLanguage.Traditional;
                switch(inLanguage_Index)
                {
                    case 0: result = emLanguage.Traditional; break;
                    case 1: result = emLanguage.English; break;
                    case 2: result = emLanguage.Simplified; break;
                }
                return result;
            }
            set
            {
                switch(value)
                {
                    case emLanguage.Traditional: inLanguage_Index = 0; break;
                    case emLanguage.English:     inLanguage_Index = 1; break;
                    case emLanguage.Simplified:  inLanguage_Index = 2; break;
                }
            }
        }
        public string Language_Name
        {
            get
            {
                return inLanguage_Names[inLanguage_Index];
            }
            set
            {
                Language = TLanguage.Get_Language(value);
            }
        }
        public string Full_File_Name
        {
            get
            {
                return Default_Path + Default_File;
            }
        }
        public TLanguage_Items()
        {
            inLanguage_Names = TLanguage.Get_Language_List();
        }
        public TLanguage_Item this[int index]
        {
            get
            {
                TLanguage_Item result = null;

                if (index >= 0 && index < Items.Count) result = (TLanguage_Item)Items[index];
                return result;
            }
        }
        public TLanguage_Item this[string form_name, string key]
        {
            get
            {
                return this[IndexOf(form_name, key)];
            }
        }
        public int IndexOf(string form_name, string key)
        {
            int result = -1;
            TLanguage_Item item = null;

            for (int i = 0; i < Items.Count; i++)
            {
                item = (TLanguage_Item)Items[i];
                if (form_name == item.Form_Name && key == item.Key)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Add(TLanguage_Item in_item)
        {
            TLanguage_Item item = new TLanguage_Item();

            item.Count = Language_Count;
            item.Form_Name = in_item.Form_Name;
            item.Key = in_item.Key;
            item.Set_Value(in_item.Values);
            if (IndexOf(item.Form_Name, item.Key) < 0)
            {
                Items.Add(item);
            }
        }
        public void Add(string form_name, string key, string value)
        {
            Add(new TLanguage_Item(form_name, key, value));
        }
        public void Add(string form_name, string key, string[] values)
        {
            Add(new TLanguage_Item(form_name, key, values));
        }
        public void Add(Form form)
        {
            ArrayList ctl_list = new ArrayList();
            Control obj;
            string owner = form.Name;

            TLanguage.Get_Compoent(form, ref ctl_list);
            for (int i = 0; i < ctl_list.Count; i++)
            {
                obj = (Control)ctl_list[i];
                Add(form, obj);
                if (obj is MenuStrip) Add(form, ((MenuStrip)obj).Items);
                if (obj is TreeView) Add(form, ((TreeView)obj).Nodes);
            }
        }
        public void Add(Form form, Control obj)
        {
            Add(form.Name, Get_Key(obj), obj.Text);
        }
        public void Add(Form form, ToolStripItemCollection items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Add(form, (ToolStripMenuItem)items[i]);
            }
        }
        public void Add(Form form, ToolStripMenuItem obj)
        {
            Add(form.Name, Get_Key(obj), obj.Text);
            if(obj.DropDownItems.Count > 0)
                Add(form, obj.DropDownItems);
        }
        public void Add(Form form, TreeNodeCollection nodes)
        {
            TreeNode node = null;
            for (int i = 0; i < nodes.Count; i++)
            {
                node = nodes[i];
                Add(form.Name, Get_Key(node), node.Text);
                Add(form, node.Nodes);
            }
        }
        public void Delete(string form_name)
        {
            TLanguage_Item item = null;
            int index=0;
            while( index< Items.Count)
            {
                item = (TLanguage_Item)Items[index];
                if (form_name == item.Form_Name) Items.RemoveAt(index);
                else index++;
            }
        }
        public string Get_Value(string form, string key)
        {
            return Get_Value(form, key, inLanguage_Index);
        }
        public string Get_Value(string form, string key, int language_index)
        {
            string result = "";
            TLanguage_Item item = this[form, key];

            if (item != null && language_index < item.Values.Length) result = item.Values[language_index];
            if (result == null) result = "";
            return result;
        }
        public void Set(Form form)
        {
            Set(form, inLanguage_Index);
        }
        public void Set(Form form,int language_index)
        {
            ArrayList ctl_list = new ArrayList();
            Control obj;
            string owner = form.Name;

            TLanguage.Get_Compoent(form, ref ctl_list);
            for (int i = 0; i < ctl_list.Count; i++)
            {
                obj = (Control)ctl_list[i];
                Set(form, language_index, obj);
                if (obj is MenuStrip) Set(form, language_index, ((MenuStrip)obj).Items);
                if (obj is TreeView) Set(form, language_index, ((TreeView)obj).Nodes);
            }
        }
        public void Set(Form form, int language_index, Control obj)
        {
            string value = "";

            value = Get_Value(form.Name, Get_Key(obj), language_index);
            if (value != "") obj.Text = value;
        }
        public void Set(Form form, int language_index, ToolStripItemCollection items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                try
                {
                    Set(form, language_index, (ToolStripMenuItem)items[i]);
                }
                catch
                {

                }
            }
        }
        public void Set(Form form, int language_index, ToolStripMenuItem obj)
        {
            string value = "";

            value = Get_Value(form.Name, Get_Key(obj), language_index);
            if (value != "") obj.Text = value;
            if (obj.DropDownItems.Count > 0)
                Set(form, language_index, obj.DropDownItems);
        }
        public void Set(Form form, int language_index, TreeNodeCollection nodes)
        {
            string value = "";
            TreeNode node = null;

            for (int i = 0; i < nodes.Count; i++)
            {
                node = nodes[i];
                value = Get_Value(form.Name, Get_Key(node), language_index);
                if (value != "") node.Text = value;
                Set(form, language_index, node.Nodes);
            }
        }
        public void Set(string form_name, string key, ref string obj)
        {
            Set(form_name, key, inLanguage_Index, ref obj);
        }
        public void Set(string form_name, string key, int language_index, ref string obj)
        {
            string value = "";

            value = Get_Value(form_name, key, language_index);
            if (value != "") obj = value;
        }

        public ArrayList To_ArrayList()
        {
            ArrayList result = new ArrayList();
            TLanguage_Item item = null;

            for (int i = 0; i < Items.Count; i++)
            {
                item = (TLanguage_Item)Items[i];
                result.Add(item.ToString());
            }
            return result;
        }
        public void Save_File(string in_file_name = "")
        {
            ArrayList list = To_ArrayList();
            string file_name = "";

            list.Insert(0, Get_Title());
            if (in_file_name == "") file_name = Full_File_Name;
            else file_name = in_file_name;
            Save_File(list, file_name);
        }
        public void Read_File(string in_file_name = "")
        {
            string file_name = "";
            ArrayList list = new ArrayList();
            TLanguage_Item item = new TLanguage_Item();

            if (in_file_name == "") file_name = Full_File_Name;
            else file_name = in_file_name;

            ArrayList_Tool.LoadFromFile(ref list, file_name);
            Clear();
            for (int i = 1; i < list.Count; i++)
            {
                item = new TLanguage_Item();
                item.Set(list[i].ToString());
                Add(item);
            }
        }
        public void Copy_File_Value(string in_file_name)
        {
            TLanguage_Items sor = new TLanguage_Items();
            TLanguage_Item sor_item = null;
            TLanguage_Item dis_item = null;

            sor.Read_File(in_file_name);
            for(int i=0; i<Items.Count; i++)
            {
                dis_item = (TLanguage_Item)Items[i];
                sor_item = sor[dis_item.Form_Name, dis_item.Key];
                if(sor_item != null)
                {
                    dis_item.Set_Value(sor_item.Values);
                }
            }
        }
        public void Clear()
        {
            Items.Clear();
        }


        private string Get_Title()
        {
            string result = "Form_Name,Key";

            for (int i = 0; i < inLanguage_Names.Length; i++)
            {
                result = result + "," + inLanguage_Names[i];
            }
            return result;
        }
        private void Save_File(ArrayList list, string in_file_name)
        {
            string path = "";

            path = System.IO.Path.GetDirectoryName(in_file_name);
            if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);
            if (System.IO.File.Exists(in_file_name)) System.IO.File.Delete(in_file_name);
            for (int i = 0; i < list.Count; i++)
                System.IO.File.AppendAllText(in_file_name, list[i].ToString() + "\r\n");
        }
        private string Get_Key(Control obj)
        {
            string result = "";

            result = obj.GetType().ToString() + "/" + obj.Name;
            return result;
        }
        private string Get_Key(ToolStripMenuItem obj)
        {
            string result = "";

            result = obj.GetType().ToString() + "/" + obj.Name;
            return result;
        }
        private string Get_Key(TreeNode obj)
        {
            string result = "";

            result = obj.GetType().ToString() + "/" + obj.Name;
            return result;
        }
    }
    public class TLanguage_Item : TBase_Class
    {
        public string Form_Name = "";
        public string Key = "";
        public string[] Values = new string[0];


        public int Count
        {
            get
            {
                return Values.Length;
            }
            set
            {
                if (value > 0)
                {
                    int old_count = Values.Length;
                    Array.Resize(ref Values, value);
                }
            }
        }
        public TLanguage_Item()
        {

        }
        public TLanguage_Item(string form_name, string key, string value)
        {
            Count = 1;
            Set(form_name, key, value);
        }
        public TLanguage_Item(string form_name, string key, string[] values)
        {
            Count = values.Length;
            Set(form_name, key, values);
        }
        override public TBase_Class New_Class()
        {
            return new TLanguage_Item();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TLanguage_Item && dis_base is TLanguage_Item)
            {
                TLanguage_Item sor = (TLanguage_Item)sor_base;
                TLanguage_Item dis = (TLanguage_Item)dis_base;

                dis.Form_Name = sor.Form_Name;
                dis.Key = sor.Key;
                dis.Count = sor.Count;
                for (int i = 0; i < Values.Length; i++) dis.Values = sor.Values;
            }
        }
        public void Set(string str)
        {
            int no = 0;
            ArrayList list = new ArrayList();
            String_Tool.Break_String(str, ",", ref list);
            Count = list.Count - 2;
            if (list.Count >= 3)
            {
                Form_Name = list[0].ToString();
                Key = list[1].ToString();
                for (int i = 2; i < list.Count; i++)
                {
                    no = i - 2;
                    if(no < Values.Length)
                    {
                        Values[no] = list[i].ToString();
                        if (Values[no] == null) Values[no] = "";
                    }
                }
            }
        }
        public void Set(string form_name, string key, string value)
        {
            Set(form_name, key, new string[] { value });
        }
        public void Set(string form_name, string key, string[] values)
        {
            Form_Name = form_name;
            Key = key;
            for (int i = 0; i < Values.Length; i++)
            {
                if (i < values.Length)
                    Values[i] = values[i];
            }
        }
        public void Set_Value(string[] values)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                if (i < values.Length)
                    Values[i] = values[i];
            }
        }
        public string ToString()
        {
            string result = "";

            result = Form_Name + "," + Key;
            for (int i = 0; i < Values.Length; i++)
            {
                result = result + "," + Values[i];
            }
            return result;
        }
    }
}
