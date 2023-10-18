using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Drawing.Design;
using EFC.PLC;


namespace EFC.HMI
{
    public partial class THMI_Message : TextBox, IHMI_Component
    {
        private THMI_Info_Message inHMI_Info = null;

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Message()
        {
            InitializeComponent();
            Set_Default();
        }
        private void Set_Default()
        {
            inHMI_Info = new THMI_Info_Message(this);
            ReadOnly = true;
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
        public THMI_Info_Message HMI_Info
        {
            get
            {
                inHMI_Info.Owner = this;
                return inHMI_Info;
            }
            set
            {
                if (value != null) value.Copy(ref inHMI_Info);
                Refresh();
            }
        }
        public new System.Drawing.Font Font
        {
            get
            {
                return inHMI_Info.Font;
            }
            set
            {
                if (inHMI_Info.Font != value)
                {
                    inHMI_Info.Font = (System.Drawing.Font)value.Clone();
                    Refresh();
                }
            }
        }
        #endregion

        #region 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        //-- 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        override public void Refresh()
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

    public class THMI_Info_Message : THMI_Info_Base
    {
        #region 物件屬性
        private string               in_Device = "D0000";
        private int                  in_Value = 0;
        private THMI_Msg_Collection  in_Msg_List = new THMI_Msg_Collection();
        private System.Drawing.Font  in_Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        #endregion

        #region 元件可編輯屬性
        //--------------------------------------------------------------------------------
        //-- 元件可編輯屬性
        //--------------------------------------------------------------------------------
        public string Device
        {
            get
            {
                return in_Device;
            }
            set
            {
                in_Device = Generate_Device(value);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public THMI_Msg_Collection Msg_List
        {
            get
            {
                return in_Msg_List;
            }
            set
            {
                in_Msg_List = value.Copy();
            }
        }
        public System.Drawing.Font Font
        {
            get
            {
                return in_Font;
            }
            set
            {
                if (in_Font != value)
                {
                    in_Font = (System.Drawing.Font)value.Clone();
                    Refresh_Component();
                }
            }
        }
        public int Value
        {
            get
            {
                return in_Value;
            }
            set
            {
                Set_HMI_Data(value);
            }
        }
        #endregion

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Info_Message(Component owner = null)
        {
            Owner = owner;
            Set_Default();
        }
        private void Set_Default()
        {
        }
        public void Copy(THMI_Info_Message sor, ref THMI_Info_Message dis)
        {
            THMI_Info_Base tmp_dis = (THMI_Info_Base)dis;
            dis.Owner = sor.Owner;
            dis.in_HMI_PLC = sor.in_HMI_PLC;

            dis.in_Device = sor.in_Device;
            dis.in_Font = sor.in_Font;
            dis.in_Msg_List = sor.in_Msg_List.Copy();
        }
        public void Copy(ref THMI_Info_Message dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Info_Message Copy()
        {
            THMI_Info_Message result = new THMI_Info_Message();
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
            return Device;
        }
        override public void Copy_Base(THMI_Info_Base sor, THMI_Info_Base dis)
        {
            if (sor is THMI_Info_Message && dis is THMI_Info_Message)
            {
                THMI_Info_Message dis_b = (THMI_Info_Message)dis;
                Copy((THMI_Info_Message)sor, ref dis_b);
            }
        }
        override public THMI_Info_Base New_Base()
        {
            return new THMI_Info_Edit();
        }
        override public bool Edit_Info()
        {
            bool result = false;
            THMI_Info_Message tmp = this;
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
        public void Set_Component_Data(TextBox obj)
        {
            Set_Component_Data(obj, in_Value);
        }
        public void Set_Component_Data(TextBox obj, int no)
        {
            THMI_Meg_Item msg = null;
            if (obj != null)
            {
                obj.Font = (Font)in_Font.Clone();
                msg = in_Msg_List[no];
                if (msg != null)
                {
                    obj.BackColor = msg.Face_Color;
                    obj.ForeColor = msg.Font_Color;
                    obj.TextAlign = msg.TextAlign;
                    obj.Text = msg.Str;
                }
            }
        }
        public void Set_HMI_Data(int value)
        {
            if (in_Value != value)
            {
                in_Value = value;
                Refresh_Component();
            }
        }
        public int Get_PLC_Value()
        {
            int result = 0;
            
            if (in_HMI_PLC != null)
                result = in_HMI_PLC.Read.Get_Data_Word(Device);
            return result;
        }
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        #endregion
    }
}
