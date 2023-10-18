using System;
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
using EFC.Tool;


namespace EFC.HMI
{
    public enum emEDIT_DATA_TYPE { Number, Text }
    public enum emEDIT_NUM_DATA_TYPE { Bit16, Bit32 = 1 }

    public partial class THMI_Edit : TextBox, IHMI_Component
    {
        private THMI_Info_Edit inHMI_Info = null;

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Edit()
        {
            InitializeComponent();
            Set_Default();
        }
        private void Set_Default()
        {
            inHMI_Info = new THMI_Info_Edit(this);
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
        public THMI_Info_Edit HMI_Info
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
        public override void Refresh()
        {
            UpdateUI(this);
        }
        public void Refresh_Component()
        {
            UpdateUI(this);
        }
        override protected void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left &&
                inHMI_Info.Get_PLC_Lock_Device())
            {
                switch (inHMI_Info.Data_Type)
                {
                    case emEDIT_DATA_TYPE.Number: Set_Number(); break;
                    case emEDIT_DATA_TYPE.Text: Set_Text(); break;
                }
            }
            base.OnClick(e);
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
        private void Set_Number()
        {
            double value = inHMI_Info.Value_Number;
            string devive_name = "";
            ushort[] tmp_data = new ushort[8];

            if (Keyboard_Number(ref value))
            {
                inHMI_Info.Value_Number = value;
                //Text = HMI_Tool.Get_Number_Text(inHMI_Info.Value_Number, inHMI_Info.Dot_Num);
                if (inHMI_Info.HMI_PLC != null)
                {
                    switch (inHMI_Info.Data_Type)
                    {
                        case emEDIT_DATA_TYPE.Number:
                            switch (inHMI_Info.Num_Data_Type)
                            {
                                case emEDIT_NUM_DATA_TYPE.Bit16:
                                    PLC_Data_Tool.Set_Word(tmp_data, 0, inHMI_Info.Dot_Num, inHMI_Info.Value_Number);
                                    inHMI_Info.HMI_PLC.PLC_Socket.Write_Byte(inHMI_Info.Device, tmp_data, 1);
                                    break;

                                case emEDIT_NUM_DATA_TYPE.Bit32:
                                    PLC_Data_Tool.Set_DWord(tmp_data, 0, inHMI_Info.Dot_Num, inHMI_Info.Value_Number);
                                    inHMI_Info.HMI_PLC.PLC_Socket.Write_Byte(inHMI_Info.Device, tmp_data, 2);
                                    break;
                            }
                            break;
                    }
                }
            }

        }
        private void Set_Text()
        {
            string value = inHMI_Info.Value_String;
            string devive_name = "";
            ushort[] tmp_data = new ushort[inHMI_Info.Value_String_Num];

            if (Keyboard_Text(ref value))
            {
                inHMI_Info.Value_String = value;
                //Text = HMI_Tool.Get_Number_Text(inHMI_Info.Value_Number, inHMI_Info.Dot_Num);

                if (inHMI_Info.HMI_PLC != null)
                {
                    switch (inHMI_Info.Data_Type)
                    {
                        case emEDIT_DATA_TYPE.Text:
                            PLC_Data_Tool.Set_String(tmp_data, 0, inHMI_Info.Value_String_Num, inHMI_Info.Value_String);
                            inHMI_Info.HMI_PLC.PLC_Socket.Write_Byte(inHMI_Info.Device, tmp_data, inHMI_Info.Value_String_Num);
                            break;
                    }
                }
            }

        }
        private bool Keyboard_Number(ref double value)
        {
            bool result = false;
            TForm_Keybord form = new TForm_Keybord();
            form.Set_Param(inHMI_Info.Value_Number, inHMI_Info.Get_Value_Format());
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                value = form.Value;
                result = true;
            }
            return result;
        }
        private bool Keyboard_Text(ref string value)
        {
            bool result = false;
            //TForm_Keybord form = new TForm_Keybord();
            //form.Set_Param(inHMI_Info.Value_Number);
            //if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    value = form.Value;
            //    result = true;
            //}
            return result;
        }
        #endregion
    }
    
    public class THMI_Info_Edit : THMI_Info_Base
    {
        #region 物件屬性
        private string               in_Device = "D0000";
        private emEDIT_NUM_DATA_TYPE in_Num_Data_Type = emEDIT_NUM_DATA_TYPE.Bit32;
        private emEDIT_DATA_TYPE     in_Data_Type = emEDIT_DATA_TYPE.Number;
        private int                  in_All_Num = 6;
        private int                  in_Dot_Num = 3;

        private bool                 in_Flag_F_Zero = false;
        private bool                 in_Flag_Signed = true;
        private bool                 in_Flag_Round = true;
        private bool                 in_Flag_Hide_Disp = false;

        private System.Drawing.Color in_Face_Color = Color.Blue;
        private System.Drawing.Font  in_Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        private System.Drawing.Color in_Font_Color = Color.White;
        private HorizontalAlignment  in_TextAlign = HorizontalAlignment.Right;


        private bool                 in_Lock_Switch = false;
        private string               in_Lock_Device = "X0000";
        private emDEVICE_LOCK_TYPE   in_Lock_Type = emDEVICE_LOCK_TYPE.emBit_On;
  
        private ImageList            in_HMI_ImageList = null;
        private double               in_Value_Number = 0.0;
        private string               in_Value_String = "";
        private int                  in_Value_String_Num = 10;
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
        public emEDIT_NUM_DATA_TYPE Num_Data_Type
        {
            get
            {
                return in_Num_Data_Type;
            }
            set
            {
                in_Num_Data_Type = value;
            }
        }
        public emEDIT_DATA_TYPE Data_Type
        {
            get
            {
                return in_Data_Type;
            }
            set
            {
                in_Data_Type = value;
            }
        }
        public int All_Num
        {
            get
            {
                return in_All_Num;
            }
            set
            {
                if (in_All_Num != value)
                {
                    in_All_Num = value;
                    if (in_All_Num < 1) in_All_Num = 1;
                    if (in_Dot_Num > in_All_Num - 1) in_Dot_Num = in_All_Num - 1;
                    Refresh_Component();
                }

            }
        }
        public int Dot_Num
        {
            get
            {
                return in_Dot_Num;
            }
            set
            {
                if (in_All_Num != value)
                {
                    in_Dot_Num = value;
                    if (in_Dot_Num < 0) in_Dot_Num = 0;
                    if (in_All_Num < in_Dot_Num + 1) in_All_Num = in_Dot_Num + 1;
                    Refresh_Component();
                }
            }
        }
        public bool Flag_F_Zero
        {
            get
            {
                return in_Flag_F_Zero;
            }
            set
            {
                if (in_Flag_F_Zero != value)
                {
                    in_Flag_F_Zero = value;
                    Refresh_Component();
                }
            }
        }
        public bool Flag_Signed
        {
            get
            {
                return in_Flag_Signed;
            }
            set
            {
                if (in_Flag_Signed != value)
                {
                    in_Flag_Signed = value;
                    Refresh_Component();
                }
            }
        }
        public bool Flag_Round
        {
            get
            {
                return in_Flag_Round;
            }
            set
            {
                if (in_Flag_Round != value)
                {
                    in_Flag_Round = value;
                    Refresh_Component();
                }
            }
        }
        public bool Flag_Hide_Disp
        {
            get
            {
                return in_Flag_Hide_Disp;
            }
            set
            {
                if (in_Flag_Hide_Disp != value)
                {
                    in_Flag_Hide_Disp = value;
                    Refresh_Component();
                }
            }
        }

        public System.Drawing.Color Face_Color
        {
            get
            {
                return in_Face_Color;
            }
            set
            {
                if (in_Face_Color != value)
                {
                    in_Face_Color = value;
                    Refresh_Component();
                }
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
        public System.Drawing.Color Font_Color
        {
            get
            {
                return in_Font_Color;
            }
            set
            {
                if (in_Font_Color != value)
                {
                    in_Font_Color = value;
                    Refresh_Component();
                }
            }
        }
        public HorizontalAlignment TextAlign
        {
            get
            {
                return in_TextAlign;
            }
            set
            {
                if (in_TextAlign != value)
                {
                    in_TextAlign = value;
                    Refresh_Component();
                }
            }
        }

        public bool Lock_Switch
        {
            get
            {
                return in_Lock_Switch;
            }
            set
            {
                in_Lock_Switch = value;
            }
        }
        public string Lock_Device
        {
            get
            {
                return in_Lock_Device;
            }
            set
            {
                in_Lock_Device = Generate_Device(value);
            }
        }
        public emDEVICE_LOCK_TYPE Lock_Type
        {
            get
            {
                return in_Lock_Type;
            }
            set
            {
                in_Lock_Type = value;
            }
        }
        public double Value_Number
        {
            get
            {
                return in_Value_Number;
            }
            set
            {
                Set_HMI_Data(value);
            }
        }
        public string Value_String
        {
            get
            {
                return in_Value_String;
            }
            set
            {
                Set_HMI_Data(value);
            }
        }
        public int Value_String_Num
        {
            get
            {
                return in_Value_String_Num;
            }
            set
            {
                if (in_Value_String_Num != value)
                {
                    in_Value_String_Num = value;
                    if (in_Value_String_Num < 2) in_Value_String_Num = 2;
                    Refresh_Component();
                }
            }
        }
        #endregion

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Info_Edit(Component owner = null)
        {
            Owner = owner;
            Set_Default();
        }
        private void Set_Default()
        {
        }
        public void Copy(THMI_Info_Edit sor, ref THMI_Info_Edit dis)
        {
            THMI_Info_Base tmp_dis = (THMI_Info_Base)dis;
            dis.Owner = sor.Owner;
            dis.in_HMI_PLC = sor.in_HMI_PLC;

            dis.in_Device = sor.in_Device;
            dis.in_Num_Data_Type = sor.in_Num_Data_Type;
            dis.in_Data_Type = sor.in_Data_Type;

            dis.in_All_Num = sor.in_All_Num;
            dis.in_Dot_Num = sor.in_Dot_Num;

            dis.in_Flag_F_Zero = sor.in_Flag_F_Zero;
            dis.in_Flag_Signed = sor.in_Flag_Signed;
            dis.in_Flag_Round = sor.in_Flag_Round;
            dis.in_Flag_Hide_Disp = sor.in_Flag_Hide_Disp;

            dis.in_Face_Color = sor.in_Face_Color;
            dis.in_Font = sor.in_Font;
            dis.in_Font_Color = sor.in_Font_Color;
 
            dis.in_Lock_Switch = sor.in_Lock_Switch;
            dis.in_Lock_Device = sor.in_Lock_Device;
            dis.in_Lock_Type = sor.in_Lock_Type;

            dis.in_HMI_ImageList = sor.in_HMI_ImageList;
            dis.in_Value_Number = sor.in_Value_Number;
            dis.in_Value_String = sor.in_Value_String;
            dis.in_Value_String_Num = sor.in_Value_String_Num;
        }
        public void Copy(ref THMI_Info_Edit dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Info_Edit Copy()
        {
            THMI_Info_Edit result = new THMI_Info_Edit();
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
            if (sor is THMI_Info_Edit && dis is THMI_Info_Edit)
            {
                THMI_Info_Edit dis_b = (THMI_Info_Edit)dis;
                Copy((THMI_Info_Edit)sor, ref dis_b);
            }
        }
        override public THMI_Info_Base New_Base()
        {
            return new THMI_Info_Edit();
        }
        override public bool Edit_Info()
        {
            bool result = false;
            THMI_Info_Edit tmp = this;
            result = HMI_Tool.Edit_HMI_Info(ref tmp);
            return result;
        }
        override public void Update_HMI_Data()
        {
            switch (in_Data_Type)
            {
                case emEDIT_DATA_TYPE.Number:
                    Value_Number = Get_PLC_Value_Number();
                    break;

                case emEDIT_DATA_TYPE.Text:
                    Value_String = Get_PLC_Value_String();
                    break;
            }
        }
        #endregion

        #region 元件公用方法
        //--------------------------------------------------------------------------------
        //-- 元件公用方法
        //--------------------------------------------------------------------------------
        public void Set_Component_Data(TextBox obj)
        {
            if (obj != null)
            {
                obj.BackColor = in_Face_Color;
                obj.ForeColor = in_Font_Color;
                obj.Font = (Font)in_Font.Clone();
                obj.TextAlign = in_TextAlign;
                obj.Text = Get_Value();
                if (Flag_Hide_Disp) obj.PasswordChar = '*';
                else obj.PasswordChar = '\x0';
            }
        }
        public void Set_HMI_Data(double value)
        {
            if (in_Value_Number != value)
            {
                in_Value_Number = value;
                Refresh_Component();
            }
        }
        public void Set_HMI_Data(string value)
        {
            if (in_Value_String != value)
            {
                in_Value_String = value;
                if (in_Value_String.Length > in_Value_String_Num)
                    in_Value_String = in_Value_String.Substring(0, in_Value_String_Num);
                Refresh_Component();
            }
        }
        public string Get_Value()
        {
            string result = "";
            if (Data_Type == emEDIT_DATA_TYPE.Number) result = Get_Value(in_Value_Number);
            if (Data_Type == emEDIT_DATA_TYPE.Text) result = in_Value_String;
            return result;
        }
        public string Get_Value(double value)
        {
            string result = "";
            double tmp_value = value;

            if (Data_Type == emEDIT_DATA_TYPE.Number)
            {
                if (Flag_Round) tmp_value = Math.Round(value, Dot_Num);
                result = tmp_value.ToString(Get_Value_Format());
            }

            return result;
        }
        public double Get_PLC_Value_Number()
        {
            double result = 0.0;

            if (in_HMI_PLC != null && in_Data_Type == emEDIT_DATA_TYPE.Number)
            {
                    switch (in_Num_Data_Type)
                    {
                        case emEDIT_NUM_DATA_TYPE.Bit16:
                            result = in_HMI_PLC.Read.Get_Data_Word(Device, in_Dot_Num);
                            break;

                        case emEDIT_NUM_DATA_TYPE.Bit32:
                            result = in_HMI_PLC.Read.Get_Data_DWord(Device, in_Dot_Num);
                            break;
                    }
            }
            return result;
        }
        public string Get_PLC_Value_String()
        {
            string result = "";

            if (in_HMI_PLC != null && in_Data_Type == emEDIT_DATA_TYPE.Text)
            {
                result = in_HMI_PLC.Read.Get_Data_String(Device, in_Value_String_Num);
            }
            return result;
        }
        public bool Get_PLC_Lock_Device()
        {
            bool result = false;
            bool tmp_flag = false;

            if (HMI_PLC != null) tmp_flag = HMI_PLC.Read.Get_Data_Bit(in_Lock_Device);
            if (in_Lock_Switch)
            {
                switch (Lock_Type)
                {
                    case emDEVICE_LOCK_TYPE.emBit_On: result = tmp_flag; break;
                    case emDEVICE_LOCK_TYPE.emBit_Off: result = !tmp_flag; break;
                }
            }
            else result = true;
            return result;
        }
        public string Get_Value_Format()
        {
            string result = "0";

            if (Data_Type == emEDIT_DATA_TYPE.Number)
            {
                if (in_Flag_F_Zero)
                {
                    for (int i = 0; i < in_All_Num - in_Dot_Num; i++) result = result + "0";
                }
                result = result + ".";
                for (int i = 0; i < in_Dot_Num; i++) result = result + "0";
            }

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
