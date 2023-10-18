using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.PLC;
using EFC.PLC.Melsec;

namespace EFC.HMI
{
    public enum emPLC_TYPE { Melsec_Q, Keyence }
    public partial class THMI_PLC : Component
    {
        #region 物件屬性
        private TBase_Device_List       in_Read = null;
        private ArrayList               in_Component_List = new ArrayList();
        private TBase_PLC               in_PLC_Socket = null;
        private System.Timers.Timer     in_Read_Timer = new System.Timers.Timer();
        private TBase_Device_Tool       in_Device_Tool = null;
        private emPLC_TYPE              in_PLC_Type = emPLC_TYPE.Melsec_Q;
        #endregion

        #region 元件可編輯屬性
        //--------------------------------------------------------------------------------
        //-- 元件可編輯屬性
        //--------------------------------------------------------------------------------
        public double Interval
        {
            get
            {
                return in_Read_Timer.Interval;
            }
            set
            {
                in_Read_Timer.Interval = value;
            }
        }
        public emPLC_TYPE PLC_Type
        {
            get
            {
                return in_PLC_Type;
            }
            set
            {
                Set_PLC_Type(value);
           }
        }

        [Browsable(false)]
        public bool Enabled
        {
            get
            {
                return in_Read_Timer.Enabled;
            }
            set
            {
                in_Read_Timer.Enabled = value;
            }
        }

        [Browsable(false)]
        public TBase_Device_List Read
        {
            get
            {
                return in_Read;
            }
        }

        [Browsable(false)]
        public TBase_Device_Tool Device_Tool
        {
            get
            {
                return in_Device_Tool;
            }
        }

        [Browsable(false)]
        public TBase_PLC PLC_Socket
        {
            get
            {
                return in_PLC_Socket;
            }
            set
            {
                in_PLC_Socket = value;
            }
        }
        #endregion

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_PLC()
        {
            InitializeComponent();
            Set_Default();
        }
        private void Set_Default()
        {
            in_Device_Tool = new TQPLC_Device_Tool();
            PLC_Type = emPLC_TYPE.Melsec_Q;
            in_Read = New_Device_List();

            in_Read_Timer.Enabled = false;
            in_Read_Timer.Interval = 100;
            in_Read_Timer.Elapsed += On_Read_Timer;
        }
        #endregion

        #region 元件公用方法
        //--------------------------------------------------------------------------------
        //-- 元件公用方法
        //--------------------------------------------------------------------------------
        public TBase_Device_List New_Device_List()
        {
            TBase_Device_List result = null;
            switch(in_PLC_Type)
            {
                case emPLC_TYPE.Melsec_Q: result = new TQPLC_Device_List(); break;
                case emPLC_TYPE.Keyence: result = null; break;
            }
            return result;
        }
        public void Component_Add(object in_obj)
        {
            if (in_Component_List.IndexOf(in_obj) < 0)
            {
                in_Component_List.Add(in_obj);
            }
        }
        public void Component_Remove(object in_obj)
        {
            if (in_Component_List.IndexOf(in_obj) >= 0)
            {
                in_Component_List.Remove(in_obj);
            }
        }
        public void Component_Purge()
        {
            object component = null;
            int no = 0;
            bool remove_flag = false;

            while (no < in_Component_List.Count)
            {
                component = in_Component_List[no];
                if (!Is_HMI_Component(component))
                {
                    //元件不屬於 HMI
                    in_Component_List.Remove(component);
                    remove_flag = true;
                }
                else 
                {
                    //HMI_PLC 關聯已中斷
                    THMI_Info_Base info = Get_HMI_Info(component);
                    if (info != null && info.HMI_PLC != this)
                    {
                        in_Component_List.Remove(component);
                        remove_flag = true;
                    }
                }

                if (!remove_flag) no++;
            }
        }
        public void Reflash_Component_Device()
        {
            Component_Purge();
            object component = null;

            Read.Clear();
            for (int i = 0; i < in_Component_List.Count; i++)
            {
                component = in_Component_List[i];
                Add_HMI_Info_Base(ref in_Read, Get_HMI_Info(component));
            }
        }
        public string[] Get_Component_Name()
        {
            Control obj;
            string[] result = new string[in_Component_List.Count];

            for (int i = 0; i < in_Component_List.Count; i++)
            {
                obj = (Control)in_Component_List[i];
                result[i] = obj.Name;
            }
            return result;
        }
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        private void On_Read_Timer(object sender, EventArgs e)
        {
            in_Read_Timer.Enabled = false;
            if (in_PLC_Socket != null && in_PLC_Socket.Connect)
            {
                in_PLC_Socket.Read_Device_List(ref in_Read);
            }

            Reflsh_Component();
            in_Read_Timer.Enabled = true;
        }
        private void Set_PLC_Type(emPLC_TYPE value)
        {
            if (value != in_PLC_Type)
            {
                in_PLC_Type = value;
                in_Device_Tool = null;
                switch (in_PLC_Type)
                {
                    case emPLC_TYPE.Melsec_Q:
                        in_Device_Tool = new TQPLC_Device_Tool();
                        break;
                }
            }
        }
        private THMI_Info_Base Get_HMI_Info(object component)
        {
            THMI_Info_Base result = null;

            if (component is THMI_Button)  result = ((THMI_Button)component).HMI_Info;
            if (component is THMI_Edit)    result =  ((THMI_Edit)component).HMI_Info;
            if (component is THMI_Lamp)    result =  ((THMI_Lamp)component).HMI_Info;
            if (component is THMI_Alarm)   result =  ((THMI_Alarm)component).HMI_Info;
            if (component is THMI_Message) result =  ((THMI_Message)component).HMI_Info;
            return result;
        }
        private bool Is_HMI_Component(object component)
        {
            bool result = false;

            if (Get_HMI_Info(component) != null) result = true;
            return result;
        }
        private void Reflsh_Component()
        {
            Control obj;

            for (int i = 0; i < in_Component_List.Count; i++)
            {
                obj = (Control)in_Component_List[i];
                if (Is_HMI_Component(obj))
                {
                    if (obj is THMI_Button) ((THMI_Button)obj).HMI_Info.Update_HMI_Data();
                    if (obj is THMI_Lamp) ((THMI_Lamp)obj).HMI_Info.Update_HMI_Data();
                    if (obj is THMI_Edit) ((THMI_Edit)obj).HMI_Info.Update_HMI_Data();
                    if (obj is THMI_Alarm) ((THMI_Alarm)obj).HMI_Info.Update_HMI_Data();
                    if (obj is THMI_Message) ((THMI_Message)obj).HMI_Info.Update_HMI_Data();
                }
            }
        }
        private void Add_HMI_Info_Base(ref TBase_Device_List devices, THMI_Info_Base info)
        {
            if (info != null && info.HMI_PLC != null)
            {
                if (info is THMI_Info_Button) Add_HMI_Info(ref in_Read, (THMI_Info_Button)info);
                if (info is THMI_Info_Lamp) Add_HMI_Info(ref in_Read, (THMI_Info_Lamp)info);
                if (info is THMI_Info_Edit) Add_HMI_Info(ref in_Read, (THMI_Info_Edit)info);
                if (info is THMI_Info_Alarm) Add_HMI_Info(ref in_Read, (THMI_Info_Alarm)info);
                if (info is THMI_Info_Message) Add_HMI_Info(ref in_Read, (THMI_Info_Message)info);
            }
        }
        private void Add_HMI_Info(ref TBase_Device_List devices, THMI_Info_Button info)
        {
            if (info.Light_Switch) devices.Add_Bit(info.Light_Device);
            if (info.Lock_Switch) devices.Add_Bit(info.Lock_Device);
        }
        private void Add_HMI_Info(ref TBase_Device_List devices, THMI_Info_Lamp info)
        {
            string device_name = "";

            for (int i = 0; i < info.Light_Bit_Count; i++)
            {
                device_name = devices.Device_Tool.Generate_Device(info.Light_Device, i);
                devices.Add_Bit(device_name);
            }
        }
        private void Add_HMI_Info(ref TBase_Device_List devices, THMI_Info_Edit info)
        {
            string device_name = "";

            switch (info.Data_Type)
            {
                case emEDIT_DATA_TYPE.Text:
                    for (int i = 0; i < info.Value_String_Num / 2; i++)
                    {
                        device_name = devices.Device_Tool.Generate_Device(info.Device, i);
                        devices.Add_Word(device_name);
                    }
                    break;

                case emEDIT_DATA_TYPE.Number:
                    switch (info.Num_Data_Type)
                    {
                        case emEDIT_NUM_DATA_TYPE.Bit16:
                            devices.Add_Word(info.Device);
                            break;

                        case emEDIT_NUM_DATA_TYPE.Bit32:
                            for (int i = 0; i < 2; i++)
                            {
                                device_name = devices.Device_Tool.Generate_Device(info.Device, i);
                                devices.Add_Word(device_name);
                            }
                            break;
                    }
                    break;
            }

            if (info.Lock_Switch) devices.Add_Bit(info.Lock_Device);
        }
        private void Add_HMI_Info(ref TBase_Device_List devices, THMI_Info_Alarm info)
        {
            string device_name = "";

            for (int i = 0; i < info.Msg_Word_Count; i++)
            {
                device_name = devices.Device_Tool.Generate_Device(info.Msg_Device, i);
                devices.Add_Word(device_name);
            }
        }
        private void Add_HMI_Info(ref TBase_Device_List devices, THMI_Info_Message info)
        {
            devices.Add_Word(info.Device);
        }
        #endregion
    }
}
