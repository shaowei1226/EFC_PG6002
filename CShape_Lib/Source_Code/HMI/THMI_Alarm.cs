using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Drawing;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using EFC.Tool;
using EFC.PLC;

namespace EFC.HMI
{
    public enum THMI_Alarm_History_Item_Type { Msg_On, Msg_OFF, Msg_End };
    public enum THMI_Alarm_Mode { Active, History, Log, Count };

    public partial class THMI_Alarm : DataGridView, IHMI_Component
    {
        private THMI_Info_Alarm inHMI_Info = null;

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Alarm()
        {
            InitializeComponent();
            Set_Default();
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Set_Default()
        {
            inHMI_Info = new THMI_Info_Alarm(this);                
            BackgroundImageLayout = ImageLayout.Stretch;
            //Size = new System.Drawing.Size(64, 64);
            Refresh();
        }
        #endregion

        #region 元件可編輯屬性
        //--------------------------------------------------------------------------------
        //-- 元件可編輯屬性
        //--------------------------------------------------------------------------------
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(THMI_Editor), typeof(UITypeEditor))]
        public THMI_Info_Alarm HMI_Info 
        { 
            get
            {
                return inHMI_Info;
            }
            set
            {
                if (value != null) value.Copy(ref inHMI_Info);
                Refresh();
            }
        }
        #endregion

        #region 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        //-- 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        public override void Refresh()
        {
            UpdateUI(this);
        }
        public void Refresh_Component()
        {
            UpdateUI(this);
        }
        #endregion

        #region 元件公用方法
        //--------------------------------------------------------------------------------
        //-- 元件公用方法
        //--------------------------------------------------------------------------------
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        private void UpdateUI(Control ctl)
        {
            if (InvokeRequired)
            {
                UpdateUICallBack uu = new UpdateUICallBack(UpdateUI);
                this.Invoke(uu, ctl);
            }
            else
            {
                Update_HMI_Data();
                base.Refresh();
            }
        }
        private void Update_HMI_Data()
        {
            inHMI_Info.Set_Component_Data(this);
        }
        #endregion
    }
    public class THMI_Info_Alarm : THMI_Info_Base 
    {
        #region 物件屬性
        private string                in_Msg_Device = "D0000";
        private int                   in_Msg_Word_Count = 1;
        private string                in_Msg_File_Name = "";
        private string                in_Log_File_Name = "";
        private THMI_Alarm_Mode       in_Mode = THMI_Alarm_Mode.Active;

        private THMI_Alarm_Column_Info_List in_Columns_Info_List = new THMI_Alarm_Column_Info_List();

        private int                   in_Msg_Max_Count = 0;
        private ArrayList             in_Msg_List = new ArrayList();
        private int[]                 in_Msg_Count = new int[0];
        private bool[]                in_Msg_Flag = new bool[0];

        private THMI_Alarm_Item_List        in_Alarm_Active = new THMI_Alarm_Item_List();
        private THMI_Alarm_Item_List        in_Alarm_Log = new THMI_Alarm_Item_List();
        #endregion

        #region 元件可編輯屬性
        //--------------------------------------------------------------------------------
        //-- 元件可編輯屬性
        //--------------------------------------------------------------------------------
        public string Msg_Device
        {
            get
            {
                return in_Msg_Device;
            }
            set
            {
                in_Msg_Device = Generate_Device(value);
            }
        }
        public void Set_Status_Count(int value)
        {
            //int old_count = Status.Length;
            //Array.Resize(ref Status, value);
            //for (int i = old_count; i < value; i++)
            //{
            //    Status[i] = new THMI_Status_Info();
            //    Set_Default(Status[i]);
            //}
        }
        public int Msg_Word_Count
        {
            get
            {
                return in_Msg_Word_Count;
            }
            set
            {
                int count = 0;

                in_Msg_Word_Count = value;
                if (in_Msg_Word_Count < 1) in_Msg_Word_Count = 1;
                if (in_Msg_Word_Count > 100) in_Msg_Word_Count = 100;
                count = (int)Math.Pow(2, in_Msg_Word_Count);
                Set_Status_Count(count);
            }
        }
        public string Msg_File_Name
        {
            get
            {
                return in_Msg_File_Name;
            }
            set
            {
                ArrayList list = new ArrayList();
                in_Msg_File_Name = value;
                ArrayList_Tool.LoadFromFile(ref list, in_Msg_File_Name);
                Set_Msg(in_Msg_Word_Count, list);
            }
        }
        public string Log_File_Name
        {
            get
            {
                return in_Log_File_Name;
            }
            set
            {
                in_Log_File_Name = value;
            }
        }
        public THMI_Alarm_Mode Mode
        {
            get
            {
                return in_Mode;
            }
            set
            {
                if (in_Mode != value)
                {
                    in_Mode = value;
                    Refresh_Component();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public THMI_Alarm_Column_Info_List Columns_Info_List
        {
            get
            {
                return in_Columns_Info_List;
            }
            set
            {
                in_Columns_Info_List.Copy(value, ref in_Columns_Info_List);
            }
        }
        #endregion

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Info_Alarm(Component owner = null)
        {
            Owner = owner;
            Set_Default();
        }
        private void Set_Default()
        {
            Msg_Word_Count = 1;
            in_Columns_Info_List.Add("Index", "Index", 60);
            in_Columns_Info_List.Add("訊息", "訊息", 500);
            in_Columns_Info_List.Add("發生時間", "發生時間", 120);
            in_Columns_Info_List.Add("解除時間", "解除時間", 120);
            in_Columns_Info_List.Add("發生次數", "發生次數", 120);
        }
        private void Set_Default(THMI_Status status)
        {
            status.Text = "";
            status.Face_Color = Color.Gray;
        }

        public void Copy(THMI_Info_Alarm sor, ref THMI_Info_Alarm dis)
        {
            dis.Owner = sor.Owner;
            dis.in_HMI_PLC = sor.in_HMI_PLC;

            dis.in_Msg_Device = sor.in_Msg_Device;
            dis.in_Msg_Word_Count = sor.in_Msg_Word_Count;
            dis.in_Msg_File_Name = sor.in_Msg_File_Name;
            dis.in_Log_File_Name = sor.in_Log_File_Name;
            dis.in_Mode = sor.in_Mode;

            dis.in_Columns_Info_List = sor.in_Columns_Info_List.Copy();
            dis.in_Msg_Max_Count = sor.in_Msg_Max_Count;
            dis.in_Msg_List = (ArrayList)sor.in_Msg_List.Clone();

            Array.Resize(ref dis.in_Msg_Count, sor.in_Msg_Count.Length);
            for (int i = 0; i < sor.in_Msg_Count.Length; i++) dis.in_Msg_Count[i] = sor.in_Msg_Count[i];

            Array.Resize(ref dis.in_Msg_Flag, sor.in_Msg_Flag.Length);
            for (int i = 0; i < sor.in_Msg_Flag.Length; i++) dis.in_Msg_Flag[i] = sor.in_Msg_Flag[i];

            dis.in_Alarm_Active = sor.in_Alarm_Active.Copy();
            dis.in_Alarm_Log = sor.in_Alarm_Log.Copy();
        }
        public void Copy(ref THMI_Info_Alarm dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Info_Alarm Copy()
        {
            THMI_Info_Alarm result = new THMI_Info_Alarm();
            Copy(this, ref result);
            return result;
        }
        #endregion

        #region 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        //-- 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        override public string ToString()
        {
            return in_Msg_Device;
        }
        override public void Copy_Base(THMI_Info_Base sor, THMI_Info_Base dis)
        {
            if (sor is THMI_Info_Alarm && dis is THMI_Info_Alarm)
            {
                THMI_Info_Alarm dis_b = (THMI_Info_Alarm)dis;
                Copy((THMI_Info_Alarm)sor, ref dis_b);
            }
        }
        override public THMI_Info_Base New_Base()
        {
            return new THMI_Info_Button();
        }
        override public bool Edit_Info()
        {
            bool result = false;
            THMI_Info_Alarm tmp = this;
            result = HMI_Tool.Edit_HMI_Info(ref tmp);
            return result;
        }
        override public void Update_HMI_Data()
        {
            Set_HMI_Data(Get_PLC_Value());
        }
        #endregion

        #region 元件公用方法
        //--------------------------------------------------------------------------------
        //-- 元件公用方法
        //--------------------------------------------------------------------------------
        public void Set_Component_Data(DataGridView obj)
        {
            int no = 0;

            if (obj != null)
            {
                obj.Columns.Clear();
                switch(in_Mode)
                {
                    case THMI_Alarm_Mode.Active:
                        no = obj.Columns.Add(Columns_Info_List[0].Name, Columns_Info_List[0].Title);
                        obj.Columns[no].Width = Columns_Info_List[0].Width;

                        no = obj.Columns.Add(Columns_Info_List[1].Name, Columns_Info_List[1].Title);
                        obj.Columns[no].Width = Columns_Info_List[1].Width;

                        no = obj.Columns.Add(Columns_Info_List[2].Name, Columns_Info_List[2].Title);
                        obj.Columns[no].Width = Columns_Info_List[2].Width;
                        break;

                    case THMI_Alarm_Mode.History:
                    case THMI_Alarm_Mode.Log:
                        no = obj.Columns.Add(Columns_Info_List[0].Name, Columns_Info_List[0].Title);
                        obj.Columns[no].Width = Columns_Info_List[0].Width;

                        no = obj.Columns.Add(Columns_Info_List[1].Name, Columns_Info_List[1].Title);
                        obj.Columns[no].Width = Columns_Info_List[1].Width;

                        no = obj.Columns.Add(Columns_Info_List[2].Name, Columns_Info_List[2].Title);
                        obj.Columns[no].Width = Columns_Info_List[2].Width;

                        no = obj.Columns.Add(Columns_Info_List[3].Name, Columns_Info_List[3].Title);
                        obj.Columns[no].Width = Columns_Info_List[3].Width;
                        break;

                    case THMI_Alarm_Mode.Count:
                        no = obj.Columns.Add(Columns_Info_List[0].Name, Columns_Info_List[0].Title);
                        obj.Columns[no].Width = Columns_Info_List[0].Width;

                        no = obj.Columns.Add(Columns_Info_List[1].Name, Columns_Info_List[1].Title);
                        obj.Columns[no].Width = Columns_Info_List[1].Width;

                        no = obj.Columns.Add(Columns_Info_List[4].Name, Columns_Info_List[4].Title);
                        obj.Columns[no].Width = Columns_Info_List[4].Width;
                       break;

                }
                Disp_Alarm(obj);
            }
        }
        public void Set_HMI_Data(ushort[] data)
        {
            Set_HMI_Data(Trans_Ushort_To_Bool(data));
        }
        public void Set_HMI_Data(bool[] data)
        {
            Array.Resize(ref data, in_Msg_Flag.Length);
            if (!Is_Same(data, in_Msg_Flag))
            {
                Array.Copy(data, in_Msg_Flag, data.Length);
                Update_Alarm_Data(data);
                Refresh_Component();
            }
        }
        public ushort[] Get_PLC_Value()
        {
            ushort[] result = null;

            if (HMI_PLC != null)
            {
                result = HMI_PLC.Read.Get_Data_Word_List(in_Msg_Device, in_Msg_Word_Count);
            }
            return result;
        }
        public void Clear()
        {
            in_Alarm_Log.Clear();
            for (int i = 0; i < in_Msg_Count.Length; i++) in_Msg_Count[i] = 0;
            for (int i = 0; i < in_Msg_Flag.Length; i++) in_Msg_Flag[i] = false;
        }
        public void Disp_Alarm(DataGridView dg)
        {
            switch (in_Mode)
            {
                case THMI_Alarm_Mode.Active: Disp_Alarm(dg, Get_Alarm_Active()); break;
                case THMI_Alarm_Mode.History: Disp_Alarm(dg, Get_Alarm_History()); break;
                case THMI_Alarm_Mode.Log: Disp_Alarm(dg, Get_Alarm_Log()); break;
                case THMI_Alarm_Mode.Count: Disp_Alarm(dg, Get_Alarm_Count()); break;
            }

        }
        public void Load_Msg_File(string file_name)
        {
            ArrayList_Tool.LoadFromFile(ref in_Msg_List, file_name);
        }
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        private bool[] Trans_Ushort_To_Bool(ushort[] data)
        {
            int no = 0;
            bool[] result = new bool[data.Length * 16];
            for (int words = 0; words < data.Length; words++)
            {
                for (int bits = 0; bits < 16; bits++)
                {
                    result[no] = PLC_Data_Tool.Get_Bit(data, words, bits);
                    no++;
                }
            }
            return result;
        }
        private void Set_Msg(int word_count, ArrayList msg)
        {
            in_Msg_Max_Count = word_count * 16;

            Array.Resize(ref in_Msg_Count, in_Msg_Max_Count);
            Array.Resize(ref in_Msg_Flag, in_Msg_Max_Count);
            in_Msg_List.Clear();
            for (int i = 0; i < in_Msg_Max_Count; i++)
            {
                if (i < msg.Count) in_Msg_List.Add(msg[i]);
                else in_Msg_List.Add("");
            }

        }
        private void Update_Alarm_Data(bool[] data)
        {
            THMI_Alarm_Item active_item = null;
            THMI_Alarm_Item tmp_item = null;

            for (int i = 0; i < in_Msg_Max_Count; i++)
            {
                active_item = in_Alarm_Active[i];
                if (i < data.Length)
                {
                    if (data[i])
                    {
                        if (active_item == null)
                        {
                            // OFF -> ON
                            in_Msg_Count[i]++;
                            tmp_item = new THMI_Alarm_Item(i, THMI_Alarm_History_Item_Type.Msg_On);
                            in_Alarm_Active.Add(tmp_item);
                            in_Alarm_Log.Add(tmp_item);
                        }
                    }
                    else
                    {
                        if (active_item != null)
                        {
                            // ON -> OFF
                            in_Alarm_Active.Remove(active_item);
                            tmp_item = new THMI_Alarm_Item(i, THMI_Alarm_History_Item_Type.Msg_OFF);
                            in_Alarm_Log.Add(tmp_item);
                        }
                    }
                }
            }
        }
        private bool Is_Same(bool[] data1, bool[] data2)
        {
            bool result = true;

            if (data1.Length == data2.Length)
            {
                for (int i = 0; i < data1.Length; i++)
                {
                    if (data1[i] != data2[i])
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
                result = false;

            return result;
        }
        private ArrayList Get_Alarm_Active()
        {
            ArrayList result = new ArrayList();
            string[] item_str = new string[4];

            for (int i = 0; i < in_Alarm_Active.Count; i++)
            {
                item_str = Get_Alarm_Item_String(in_Alarm_Active[i]);
                result.Add(string.Format("{0:s}|{1:s}", item_str[0], item_str[1]));
            }
            return result;
        }
        private ArrayList Get_Alarm_History()
        {
            ArrayList result = new ArrayList();
            THMI_Alarm_Item_List active = new THMI_Alarm_Item_List();
            THMI_Alarm_Item_List history = new THMI_Alarm_Item_List();
            THMI_Alarm_Item avtive_item = null;
            string[] item_str = new string[4];


            #region make_list
            for (int i = 0; i < in_Alarm_Log.Count; i++)
            {
                avtive_item = active.Get_By_Key(in_Alarm_Log[i].Msg_Index);
                if (in_Alarm_Log[i].Mode == THMI_Alarm_History_Item_Type.Msg_On)
                {
                    if (avtive_item == null)
                    {
                        //狀態切換為ON, 現況不存在
                        active.Add(in_Alarm_Log[i]);
                    }
                    else
                    {
                        //狀態切換為ON, 現況為ON
                        history.Add(avtive_item);
                        active.Remove(avtive_item);
                        active.Add(in_Alarm_Log[i]);
                    }
                }
                else
                {
                    if (avtive_item == null)
                    {
                        //狀態切換為OFF, 現況不存在
                        history.Add(in_Alarm_Log[i]);
                    }
                    else
                    {
                        //狀態切換為OFF, 現況為ON
                        THMI_Alarm_Item new_item = avtive_item.Copy();
                        new_item.End = in_Alarm_Log[i].End;
                        new_item.Mode = THMI_Alarm_History_Item_Type.Msg_End;
                        history.Add(new_item);
                        active.Remove(avtive_item);
                    }
                }
            }
            #endregion

            for (int i = 0; i < active.Count; i++)
            {
                history.Add(active[i]);
            }

            history.Sort();
            for (int i = history.Count - 1; i >= 0; i--)
            {
                item_str = Get_Alarm_Item_String(history[i]);
                result.Add(string.Format("{0:s}|{1:s}|{2:s}|{3:s}", item_str[0], item_str[1], item_str[2], item_str[3]));
            }

            return result;
        }
        private ArrayList Get_Alarm_Log()
        {
            ArrayList result = new ArrayList();
            string[] item_str = new string[4];

            for (int i = in_Alarm_Log.Count - 1; i >= 0; i--)
            {
                item_str = Get_Alarm_Item_String(in_Alarm_Log[i]);
                result.Add(string.Format("{0:s}|{1:s}|{2:s}|{3:s}", item_str[0], item_str[1], item_str[2], item_str[3]));
            }
            return result;
        }
        private ArrayList Get_Alarm_Count()
        {
            ArrayList result = new ArrayList();
            string tmp_str = "";
            string msg = "";

            for (int i = 0; i < in_Msg_Max_Count; i++)
            {
                if (in_Msg_Count[i] > 0)
                {
                    msg = in_Msg_List[i].ToString();
                    tmp_str = string.Format("{0:s}|{1:d}", msg, in_Msg_Count[i]);
                    result.Add(tmp_str);
                }
            }
            return result;
        }
        private string[] Get_Alarm_Item_String(THMI_Alarm_Item item)
        {
            string[] result = new string[4];

            result[0] = in_Msg_List[item.Msg_Index].ToString();
            result[1] = item.Start.ToString("hh:mm:ss.ff");
            result[2] = item.End.ToString("hh:mm:ss.ff");
            result[3] = in_Msg_Count[item.Msg_Index].ToString();
            switch (item.Mode)
            {
                case THMI_Alarm_History_Item_Type.Msg_On:
                    result[2] = "";
                    break;

                case THMI_Alarm_History_Item_Type.Msg_OFF:
                    result[1] = "";
                    break;

                case THMI_Alarm_History_Item_Type.Msg_End:
                    break;
            }

            return result;
        }
        private void Disp_Alarm(DataGridView dg, ArrayList list)
        {
            ArrayList tmp_list = new ArrayList();

            if (list.Count > 0)
            {
                dg.RowCount = list.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    String_Tool.Break_String(list[i].ToString(), "|", ref tmp_list);

                    dg.Rows[i].Cells[0].Value = i + 1;
                    for (int j = 0; j < tmp_list.Count; j++)
                    {
                        if (j < dg.Rows[i].Cells.Count - 1)
                            dg.Rows[i].Cells[j + 1].Value = tmp_list[j];
                    }
                }
            }
        }
        #endregion
    }

    public class THMI_Alarm_Column_Info
    {
        private string in_Name = "";
        private string in_Title = "";
        private int in_Width = 100;
        private bool in_Switch = true;

        public string Name
        {
            get
            {
                return in_Name;
            }
            set
            {
                in_Name = value;
            }
        }
        public string Title
        {
            get
            {
                return in_Title;
            }
            set
            {
                in_Title = value;
            }
        }
        public int Width
        {
            get
            {
                return in_Width;
            }
            set
            {
                in_Width = value;
            }
        }
        public bool Switch
        {
            get
            {
                return in_Switch;
            }
            set
            {
                in_Switch = value;
            }
        }

        public THMI_Alarm_Column_Info()
        {

        }
        public THMI_Alarm_Column_Info(string name, string title, int width)
        {
            Set(name, title, width);
        }
        public void Copy(THMI_Alarm_Column_Info sor, ref THMI_Alarm_Column_Info dis)
        {
            dis.in_Name = sor.in_Name;
            dis.in_Title = sor.in_Title;
            dis.in_Width = sor.in_Width;
            dis.in_Switch = sor.in_Switch;
        }
        public void Copy(ref THMI_Alarm_Column_Info dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Alarm_Column_Info Copy()
        {
            THMI_Alarm_Column_Info result = new THMI_Alarm_Column_Info();
            Copy(this, ref result);
            return result;
        }
        public void Set(string name, string title, int width)
        {
            in_Name = name;
            in_Title = title;
            in_Width = width;
        }
    }
    public sealed class THMI_Alarm_Column_Info_List : CollectionBase
    {
        public THMI_Alarm_Column_Info_List()
        {

        }
        public THMI_Alarm_Column_Info this[int index]
        {
            get
            {
                THMI_Alarm_Column_Info result = null;
                if (index >= 0 && index < List.Count) result = (THMI_Alarm_Column_Info)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    THMI_Alarm_Column_Info tmp_obj = (THMI_Alarm_Column_Info)List[index];
                    value.Copy(ref tmp_obj);
                }
            }
        }
        public THMI_Alarm_Column_Info this[string name]
        {
            get
            {
                return this[IndexOf_Name(name)];
            }
            set
            {
                this[IndexOf_Name(name)] = value;
            }
        }
        public int IndexOf(THMI_Alarm_Column_Info member)
        {
            return this.List.IndexOf(member);
        }
        public int IndexOf_Name(string name)
        {
            int result = -1;
            THMI_Alarm_Column_Info tmp_obj = null;
            for (int i = 0; i < List.Count; i++)
            {
                tmp_obj = (THMI_Alarm_Column_Info)List[i];
                if (name == tmp_obj.Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Add(string name, THMI_Alarm_Column_Info member)
        {
            THMI_Alarm_Column_Info tmp_obj = member.Copy();

            THMI_Alarm_Column_Info old_obj = this[name];
            if (old_obj != null)
            {
                tmp_obj.Name = name;
                tmp_obj.Copy(ref old_obj);
            }
            else
            {
                tmp_obj.Name = name;
                List.Add(tmp_obj);
            }
        }
        public void Add(string name, string title, int width)
        {
            THMI_Alarm_Column_Info tmp_obj = new THMI_Alarm_Column_Info(name, title, width);
            Add(name, tmp_obj);
        }
        public void Set(int index, string name, string title, int width)
        {
            THMI_Alarm_Column_Info old_obj = this[index];
            if (old_obj != null)
            {
                old_obj.Name = name;
                old_obj.Title = title;
                old_obj.Width = width;
            }
        }
        public void Add(THMI_Alarm_Column_Info member)
        {
            Add(member.Name, member);
        }
        public void Remove(THMI_Alarm_Column_Info member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }
        public void Remove(string name)
        {
            RemoveAt(IndexOf_Name(name));
        }

        public void Copy(THMI_Alarm_Column_Info_List sor, ref THMI_Alarm_Column_Info_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.List.Add(sor[i]);
        }
        public void Copy(ref THMI_Alarm_Column_Info_List dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Alarm_Column_Info_List Copy()
        {
            THMI_Alarm_Column_Info_List result = new THMI_Alarm_Column_Info_List();
            Copy(this, ref result);
            return result;
        }
        public void Set_Count(int count)
        {
            if (count < Count)
            {
                while (List.Count > count)
                {
                    List.RemoveAt(List.Count - 1);
                }
            }
            else
            {
                int add_count = count - Count;
                for (int i = 0; i < add_count; i++)
                    List.Add(new THMI_Meg_Item());
            }
        }
    }

    public class THMI_Alarm_Item
    {
        public int Msg_Index;
        public THMI_Alarm_History_Item_Type Mode;
        public DateTime Start;
        public DateTime End;

        public THMI_Alarm_Item()
        {

        }
        public void Copy(THMI_Alarm_Item sor, ref THMI_Alarm_Item dis)
        {
            dis.Msg_Index = sor.Msg_Index;
            dis.Mode = sor.Mode;
            dis.Start = sor.Start;
            dis.End = sor.End;
        }
        public void Copy(ref THMI_Alarm_Item dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Alarm_Item Copy()
        {
            THMI_Alarm_Item result = new THMI_Alarm_Item();
            Copy(this, ref result);
            return result;
        }
        public THMI_Alarm_Item(int Msg_Index, THMI_Alarm_History_Item_Type mode)
        {
            Set(Msg_Index, mode);
        }
        public THMI_Alarm_Item(int Msg_Index, THMI_Alarm_History_Item_Type mode, DateTime time)
        {
            Set(Msg_Index, mode, time);
        }
        public void Set(int msg_index, THMI_Alarm_History_Item_Type mode)
        {
            Msg_Index = msg_index;
            Mode = mode;
            Start = DateTime.Now;
        }
        public void Set(int msg_index, THMI_Alarm_History_Item_Type mode, DateTime time)
        {
            Msg_Index = msg_index;
            Mode = mode;
            Start = time;
        }
    }
    public sealed class THMI_Alarm_Item_List : CollectionBase
    {
        public THMI_Alarm_Item_List()
        {

        }
        public THMI_Alarm_Item this[int index]
        {
            get
            {
                THMI_Alarm_Item result = null;
                if (index >= 0 && index < List.Count) result = (THMI_Alarm_Item)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    THMI_Alarm_Item tmp_obj = (THMI_Alarm_Item)List[index];
                    value.Copy(ref tmp_obj);
                }
            }
        }
        public THMI_Alarm_Item Get_By_Key(int key)
        {
            THMI_Alarm_Item result = null;
            THMI_Alarm_Item obj = null;

            for (int i = 0; i < Count; i++)
            {
                obj = (THMI_Alarm_Item)List[i];
                if (key == obj.Msg_Index)
                {
                    result = obj;
                    break;
                }
            }
            return result;
        }
        public int IndexOf(THMI_Alarm_Item member)
        {
            return this.List.IndexOf(member);
        }
        public void Add(THMI_Alarm_Item member)
        {
            THMI_Alarm_Item tmp_obj = member.Copy();
            List.Add(tmp_obj);
        }
        public void Add(int msg_index, THMI_Alarm_History_Item_Type mode)
        {
            THMI_Alarm_Item tmp_obj = new THMI_Alarm_Item(msg_index, mode);
            Add(tmp_obj);
        }
        public void Add(int msg_index, THMI_Alarm_History_Item_Type mode, DateTime time)
        {
            THMI_Alarm_Item tmp_obj = new THMI_Alarm_Item( msg_index, mode, time);
            Add(tmp_obj);
        }
        public void Set(int index, int msg_index, THMI_Alarm_History_Item_Type mode, DateTime time)
        {
            THMI_Alarm_Item old_obj = this[index];
            if (old_obj != null)
            {
                old_obj.Set(msg_index, mode, time);
            }
        }
        public void Remove(THMI_Alarm_Item member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }

        public void Copy(THMI_Alarm_Item_List sor, ref THMI_Alarm_Item_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.List.Add(sor[i]);
        }
        public void Copy(ref THMI_Alarm_Item_List dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Alarm_Item_List Copy()
        {
            THMI_Alarm_Item_List result = new THMI_Alarm_Item_List();
            Copy(this, ref result);
            return result;
        }
        public void Set_Count(int count)
        {
            if (count < Count)
            {
                while (List.Count > count)
                {
                    List.RemoveAt(List.Count - 1);
                }
            }
            else
            {
                int add_count = count - Count;
                for (int i = 0; i < add_count; i++)
                    List.Add(new THMI_Meg_Item());
            }
        }
        public void Sort()
        {
            InnerList.Sort(new Alarm_Log_Compare());
        }

        private class Alarm_Log_Compare : IComparer
        {
            public int Compare(object x, object y)
            {
                THMI_Alarm_Item obj1 = (THMI_Alarm_Item)x;
                THMI_Alarm_Item obj2 = (THMI_Alarm_Item)y;
                return DateTime.Compare(obj1.Start, obj2.Start);
            }
        }
    }
}
