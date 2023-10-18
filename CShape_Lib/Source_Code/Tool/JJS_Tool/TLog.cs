using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFC.Tool
{
    public enum emLog_Type { None, Generally, Warning, Error, Remark }

    public class TLog
    {
        private bool      FEnabled = true;

        public string     Default_Path = "";
        public string     Pre_String = "";                     // 檔案日期前文字
        public string     Date_Format = "yy_MM_dd";            // 檔案名稱格式
        public string     DefaultExt = ".Log";                 // 檔案副檔名
        public string     Date_String;                         // 辨識日期是否變更 
        public bool       Reflash = false;                     // Log訊息更新
        public bool       Save_HDD = true;                     // Log存入檔案
        public int        Disp_Old_Count = 0;                  // 目前顯示位置指標
        public int        Max_Count = 500;                     // 顯示最大筆數
        public int        Cut_Count = 200;                     // 筆數過多時，刪除至此筆數
        public TLog_Message Default_Msg = new TLog_Message();  // 預設訊息
        public TLog_Message_List Log_Msg = new TLog_Message_List();
        public TLog_Sort  Sort = new TLog_Sort();
        public bool       Lock = false;
        public string File_Name
        {
            get
            {
                return Get_File_Name(System.DateTime.Now);
            }
        }
        public bool Enabled
        {
            get
            {
                return FEnabled;
            }
            set
            {
                Set_Enabled(value);
            }
        }
        public TLog()
        {
            FEnabled = true;
        }
        public void Dispose()
        {
        }
        public void Add(TLog_Message msg)
        {
            Wait_Ready();
            Lock = true;
            if (FEnabled)
            {
                Log_Msg.Add(msg);
                try
                {
                    if (Save_HDD) System.IO.File.AppendAllText(File_Name, msg.ToString() + "\r\n");
                }
                catch (Exception ex)
                {
                }
                Reflash = true;
            }
            Lock = false;
        }
        public void Add(TLog_Message msg, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            Add(new TLog_Message(msg.Source, msg.Fun, msg_str, type));
        }
        public void Add(string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            Add(new TLog_Message(Default_Msg.Source, Default_Msg.Fun, msg_str, type));
        }
        public void Add(string source, string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            Add(new TLog_Message(source, fun, msg_str, type));
        }

        public void Display(System.Windows.Forms.ListBox list_box)
        {
            if (Reflash)
            {
                if (Disp_Old_Count >= 0)
                {
                    for (int i = Disp_Old_Count; i < Log_Msg.Count; i++)
                        list_box.Items.Insert(0, Log_Msg[i].ToString());

                    Disp_Old_Count = Log_Msg.Count;

                    Cut_Msg_List();
                    Cut_ListBox(list_box);
                }
                Reflash = false;
            }
        }
        public void Display(System.Windows.Forms.DataGridView dg)
        {
            int no = 0;
            int select_row = Get_Grid_Select_Row(dg);
            int old_index = -1;
            int new_index = -1;
            TLog_Message_List tmp_msg = null;

            if (Reflash)
            {
                Cut_Msg_List();
                old_index = Get_Message_Index(dg);
                tmp_msg = Log_Msg.Get_List(Sort);
                dg.RowCount = tmp_msg.Count;
                for (int i = 0; i < dg.RowCount; i++)
                {
                    no = tmp_msg.Count - i - 1;
                    dg.Rows[no].Cells[0].Value = string.Format("{0:s}", tmp_msg[i].Index_Str);
                    dg.Rows[no].Cells[1].Value = string.Format("{0:s}", tmp_msg[i].Time_Str);
                    dg.Rows[no].Cells[2].Value = string.Format("{0:s}", tmp_msg[i].Type.ToString());
                    dg.Rows[no].Cells[3].Value = string.Format("{0:s}", tmp_msg[i].Source);
                    dg.Rows[no].Cells[4].Value = string.Format("{0:s}", tmp_msg[i].Fun);
                    dg.Rows[no].Cells[5].Value = string.Format("{0:s}", tmp_msg[i].Message);

                    dg.Rows[no].DefaultCellStyle.BackColor = Get_Type_Color(tmp_msg[i].Type);
                }
                if (select_row >= 0)
                {
                    new_index = tmp_msg.Count - tmp_msg.Get_Index(old_index) - 1;
                    Move_Grid_Select_Row(dg, new_index);
                }
                else
                {
                    if (dg.RowCount > 0) dg.FirstDisplayedScrollingRowIndex = 0;
                }


                Cut_Msg_List();
                Reflash = false;
            }
        }
        public void Log_Diff(string value_name, string old_value, string new_value, ref bool flag)
        {
            string str = "";
            if (old_value != new_value)
            {
                str = string.Format("{0:s} old={1:s}, new={2:s}", value_name, old_value, new_value);
                Add(str);
                flag = true;
            }
        }
        public void Log_Diff(string value_name, int old_value, int new_value, ref bool flag)
        {
            string str = "";
            if (old_value != new_value)
            {
                str = string.Format("{0:s} old={1:d}, new={2:d}", value_name, old_value, new_value);
                Add(str);
                flag = true;
            }
        }
        public void Log_Diff(string value_name, float old_value, float new_value, ref bool flag)
        {
            string str = "";
            if (old_value != new_value)
            {
                str = string.Format("{0:s} old={1:f}, new={2:f}", value_name, old_value, new_value);
                Add(str);
                flag = true;
            }
        }
        public void Log_Diff(string value_name, double old_value, double new_value, ref bool flag)
        {
            string str = "";
            if (old_value != new_value)
            {
                str = string.Format("{0:s} old={1:f}, new={2:f}", value_name, old_value, new_value);
                Add(str);
                flag = true;
            }
        }
        public void Log_Diff(string value_name, bool old_value, bool new_value, ref bool flag)
        {
            string str = "";
            if (old_value != new_value)
            {
                str = string.Format("{0:s} old={1:s}, new={2:s}", value_name, old_value.ToString(), new_value.ToString());
                Add(str);
                flag = true;
            }
        }


        public void Wait_Ready()
        {
            bool time_out = false;
            DateTime in_time = DateTime.Now;

            while (Lock && !time_out)
            {
                Application.DoEvents();
                JJS_LIB.Sleep(10);
                time_out = JJS_LIB.Is_Timeout(in_time, 3000);
            };
            Lock = false;
        }
        private int Get_Message_Index(System.Windows.Forms.DataGridView dg)
        {
            int result = -1;
            int dg_row = Get_Grid_Select_Row(dg);

            try
            {
                result = Convert.ToInt32(dg.Rows[dg_row].Cells[0].Value);
            }
            catch (Exception e)
            {
            }
            return result;
        }
        private void Set_Enabled(bool flag)
        {
            if (flag)
            {
                FEnabled = true;
                Date_String = System.DateTime.Now.ToString("yy_MM_dd");
                if (!System.IO.Directory.Exists(Default_Path))
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Default_Path));
            }
            else
            {
                FEnabled = false;
            }

        }
        private string Get_File_Name(System.DateTime date)
        {
            string result;
            result = Default_Path + Pre_String + date.ToString(Date_Format) + DefaultExt;
            return result;
        }
        private void Cut_Msg_List()
        {
            int remove_count = 0;

            if (Log_Msg.Count > Max_Count)
            {
                remove_count = Log_Msg.Count - Cut_Count;
                Log_Msg.Remove_Count(remove_count);
            }
        }
        private void Cut_ListBox(System.Windows.Forms.ListBox list_box)
        {
            if (list_box.Items.Count > Max_Count)
            {
                while (list_box.Items.Count > Cut_Count)
                {
                    list_box.Items.RemoveAt(list_box.Items.Count - 1);
                }
            }
        }
        private void Cut_DataGridView(System.Windows.Forms.DataGridView dg)
        {
            //if (list_box.Items.Count > Max_Count)
            //{
            //    while (list_box.Items.Count > Cut_Count)
            //    {
            //        list_box.Items.RemoveAt(list_box.Items.Count - 1);
            //    }
            //}
        }
        private ArrayList ArrayList_Clone(ArrayList in_list)
        {
            ArrayList result = new ArrayList();

            for (int i = 0; i < in_list.Count; i++) result.Add(in_list[i]);
            return result;
        }
        private int Get_Grid_Select_Row(DataGridView dg)
        {
            int result = -1;
            int[] select = Get_Grid_Select_Rows(dg);

            if (select.Length > 0) result = select[0];
            return result;
        }
        private int[] Get_Grid_Select_Rows(DataGridView dg)
        {
            int[] result = new int[0];
            ArrayList list = new ArrayList();
            int no = 0;
            bool select = false;

            for (int i = 0; i < dg.SelectedCells.Count; i++)
            {
                no = dg.SelectedCells[i].RowIndex;
                select = false;
                for (int j = 0; j < list.Count; j++)
                {
                    if ((int)list[j] == no)
                    {
                        select = true;
                        break;
                    }
                }
                if (!select) list.Add(no);
            }
            list.Sort();

            Array.Resize(ref result, list.Count);
            for (int i = 0; i < list.Count; i++) result[i] = (int)list[i];

            return result;
        }
        private void Set_Grid_Select_Row(DataGridView dg, int no)
        {
            if (no >= 0)
            {
                for (int i = 0; i < dg.Rows.Count; i++) dg.Rows[i].Selected = false;
                if (no < dg.Rows.Count) dg.Rows[no].Selected = true;
                else if (dg.Rows.Count > 0) dg.Rows[dg.Rows.Count - 1].Selected = true;
            }
        }
        private void Move_Grid_Select_Row(DataGridView dg, int no, int ofs = 3)
        {
            int first_no = 0;

            if (no >= 0 && no < dg.RowCount)
            {
                first_no = no - ofs;
                if (first_no < 0) first_no = 0;
                dg.Rows[no].Selected = true;
                if (first_no < dg.RowCount) dg.FirstDisplayedScrollingRowIndex = first_no;
            }
        }
        private System.Drawing.Color Get_Type_Color(emLog_Type type)
        {
            System.Drawing.Color result = System.Drawing.Color.White;

            switch (type)
            {
                case emLog_Type.None: result = System.Drawing.Color.White; break;
                case emLog_Type.Generally: result = System.Drawing.Color.White; break;
                case emLog_Type.Warning: result = System.Drawing.Color.Pink; break;
                case emLog_Type.Error: result = System.Drawing.Color.Red; break;
                case emLog_Type.Remark: result = System.Drawing.Color.Yellow; break;
            }
            return result;
        }
    }
    public class TLog_Message_List : TBase_Class 
    {
        public TLog_Message[] Items = new TLog_Message[0];
        public bool Lock = false;
        public int Index = 0;

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count = Items.Length;
                Array.Resize(ref Items, value);
                for (int i = old_count; i < value; i++) Items[i] = new TLog_Message();
            }
        }
        public TLog_Message_List()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TLog_Message_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TLog_Message_List && dis_base is TLog_Message_List)
            {
                TLog_Message_List sor = (TLog_Message_List)sor_base;
                TLog_Message_List dis = (TLog_Message_List)dis_base;
             
                Wait_On_Lock();
                Lock = true;
                dis.Count = sor.Count;
                for (int i = 0; i < dis.Count; i++) dis.Items[i].Set(sor.Items[i]);
                Lock = false;
            }
        }

        public TLog_Message this[int index]
        {
            get
            {
                TLog_Message result = null;

                if (index >= 0 && index < Items.Length)
                {
                    Wait_On_Lock();
                    result = Items[index];
                }
                return result;
            }
            set
            {
                if (index >= 0 && index < Items.Length)
                {
                    Wait_On_Lock();
                    Items[index].Set(value);
                }
            }
        }
        public void Clear()
        {
            Count = 0;
        }
        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }
        public void RemoveAt(int index)
        {
            Wait_On_Lock();
            Lock = true;
            if (index >= 0 && index < Items.Length)
            {
                for (int i = index; i < Items.Length - 1; i++)
                {
                    Items[i].Set(Items[i + 1]);
                }
                Count = Count - 1;
            }
            Lock = false;
        }
        public void Remove_Count(int count)
        {
            Wait_On_Lock();
            Lock = true;
            if (count > 0)
            {
                if (count < Items.Length)
                {
                    for (int i = 0; i < Items.Length - count; i++)
                    {
                        Items[i].Set(Items[i + count]);
                    }
                    Count = Count - count;
                }
                else 
                    Count = 0;

            }
            Lock = false;
        }

        public void Add(TLog_Message value)
        {
            Wait_On_Lock();
            Lock = true;
            Count++;
            value.Index = Index++;
            value.Time = DateTime.Now;
            Items[Count - 1].Set(value);
            Lock = false;
        }
        public void Add(TLog_Message value, string msg, emLog_Type type = emLog_Type.Generally)
        {
            Add(new TLog_Message(value.Source, value.Fun, msg, type));
        }
        public void Add(string source, string fun, string message, emLog_Type type = emLog_Type.Generally)
        {
            Add(new TLog_Message(source, fun, message, type));
        }
        public void Wait_On_Lock()
        {
            while (Lock) { System.Windows.Forms.Application.DoEvents(); Thread.Sleep(1); };
        }
        public TLog_Message_List Get_List(TLog_Sort sort)
        {
            TLog_Message_List result = new TLog_Message_List();
            int no = 0;

            Wait_On_Lock();
            Lock = true;
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].Is_Sort(sort))
                {
                    result.Add(new TLog_Message());
                    result[no].Set(Items[i]);
                    no++;
                }
            }
            Lock = false;
            return result;
        }
        public int Get_Index(int index)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i].Index == index)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public ArrayList Get_Type_List()
        {
            ArrayList result = new ArrayList();

            result.Add(emLog_Type.None.ToString());
            result.Add(emLog_Type.Generally.ToString());
            result.Add(emLog_Type.Warning.ToString());
            result.Add(emLog_Type.Error.ToString());
            result.Add(emLog_Type.Remark.ToString());
            return result;
        }
        public ArrayList Get_Source_List()
        {
            ArrayList result = new ArrayList();
            string str = "";

            Wait_On_Lock();
            Lock = true; 
            for (int i = 0; i < Items.Length; i++)
            {
                str = Items[i].Source;
                if (result.IndexOf(str) < 0) result.Add(str);
            }
            Lock = false;
            return result;
        }
        public ArrayList Get_Fun_List()
        {
            ArrayList result = new ArrayList();
            string str = "";

            Wait_On_Lock();
            Lock = true;
            for (int i = 0; i < Items.Length; i++)
            {
                str = Items[i].Fun;
                if (result.IndexOf(str) < 0) result.Add(str);
            }
            Lock = false;
            return result;
        }
       
        private int IndexOf(object value)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == value)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
    public class TLog_Message : TBase_Class
    {
        public DateTime Time;
        public emLog_Type Type = emLog_Type.Generally;
        public int Index = 0;
        public string Source = "";
        public string Fun = "";
        public string Message = "";

        public string Time_Str
        {
            get
            {
                string result = "";
                result = string.Format("[{0:d2}:{1:d2}:{2:d2}.{3:d3}]", Time.Hour, Time.Minute, Time.Second, Time.Millisecond);
                return result;
            }
        }
        public string Index_Str
        {
            get
            {
                string result = "";

                result = string.Format("{0:d6}", Index);
                return result;
            }
        }
        public TLog_Message()
        {

        }
        public TLog_Message(string msg)
        {
            Set_Data("", "", msg, emLog_Type.Generally);
        }
        public TLog_Message(string source, string fun)
        {
            Set_Data(source, fun, "", emLog_Type.Generally);
        }
        public TLog_Message(string source, string fun, string message, emLog_Type type = emLog_Type.Generally)
        {
            Set_Data(source, fun, message, type);
        }
        override public TBase_Class New_Class()
        {
            return new TLog_Message();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TLog_Message && dis_base is TLog_Message)
            {
                TLog_Message sor = (TLog_Message)sor_base;
                TLog_Message dis = (TLog_Message)dis_base;

                dis.Time = sor.Time;
                dis.Index = sor.Index;
                dis.Type = sor.Type;
                dis.Source = sor.Source;
                dis.Fun = sor.Fun;
                dis.Message = sor.Message;
            }
        }
        public bool Is_Sort(TLog_Sort sort)
        {
            bool result = true;

            if (sort.Type != emLog_Type.None && sort.Type != Type) result = false;
            if (sort.Source != "" && Source.ToUpper().IndexOf(sort.Source.ToUpper()) < 0) result = false;
            if (sort.Fun != "" && Fun.ToUpper().IndexOf(sort.Fun.ToUpper()) < 0) result = false;

            return result;
        }
        public void Set_Source(string source, string fun)
        {
            Source = source;
            Fun = fun;
        }
        public void Set_Data(string message, emLog_Type type = emLog_Type.Generally)
        {
            Set_Data(Source, Fun, message, type);
        }
        public void Set_Data(string source, string fun, string message, emLog_Type type = emLog_Type.Generally)
        {
            Time = DateTime.Now;
            Source = source;
            Fun = fun;
            Message = message;
            Type = type;
        }
        public string ToString()
        {
            string result = "";

            result = string.Format("{0:s},{1:s},{2:s},{3:s},{4:s},{5:s}", Time_Str, Index_Str, Source, Fun, Type.ToString(), Message);
            return result;
        }
        public void Reset()
        {
            Time = DateTime.Now;
            Type = emLog_Type.Generally;
            Index = 0;
            Source = "";
            Fun = "";
            Message = "";
        }
    }

    public class TLog_Sort
    {
        public emLog_Type Type = emLog_Type.None;
        public string Source = "";
        public string Fun = "";

        public TLog_Sort()
        {

        }
        public void Reset()
        {
            Type = emLog_Type.None;
            Source = "";
            Fun = "";
        }
    }
}
