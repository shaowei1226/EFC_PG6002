using System;
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
using EFC.PLC;

namespace EFC.HMI
{
    public partial class THMI_Button : Panel, IHMI_Component
    {
        private THMI_Info_Button inHMI_Info = null;
        public bool On_Mouse_Down_Flag = false;

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Button()
        {
            InitializeComponent();
            Set_Default();
        }
        private void Set_Default()
        {
            inHMI_Info = new THMI_Info_Button(this);
            BackgroundImageLayout = ImageLayout.Stretch;
            Size = new System.Drawing.Size(64, 64);
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            //Update_HMI_Data();
            //this.Paint += New_Paint;
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
        public THMI_Info_Button HMI_Info 
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
        override protected void OnPaint(PaintEventArgs e)
        {
            HMI_Info.Set_Component_Data(e, this, HMI_Info.Status_Index);
        }
        public void Refresh_Component()
        {
            UpdateUI(this);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool hmi_data = false;

            On_Mouse_Down_Flag = true;
            Refresh();

            if (e.Button == System.Windows.Forms.MouseButtons.Left &&
                inHMI_Info.Get_PLC_Lock_Device() && inHMI_Info.HMI_PLC != null)
            {
                switch (inHMI_Info.Type)
                {
                    case emDEVICE_BUTTON_TYPE.emBT_M:
                    case emDEVICE_BUTTON_TYPE.emBT_Set:
                        hmi_data = true;
                        inHMI_Info.HMI_PLC.PLC_Socket.Write_Bit(inHMI_Info.Device, hmi_data);
                        break;

                    case emDEVICE_BUTTON_TYPE.emBT_Reset:
                        hmi_data = false;
                        inHMI_Info.HMI_PLC.PLC_Socket.Write_Bit(inHMI_Info.Device, hmi_data);
                        break;

                    case emDEVICE_BUTTON_TYPE.emBT_Inv:
                        hmi_data = !inHMI_Info.Get_PLC_Device();
                        inHMI_Info.HMI_PLC.PLC_Socket.Write_Bit(inHMI_Info.Device, hmi_data);
                        break;
                }
                Set_Off_Line_Bit(hmi_data);
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            On_Mouse_Down_Flag = false;
            Refresh();

            if (e.Button == System.Windows.Forms.MouseButtons.Left &&
                 inHMI_Info.HMI_PLC != null)
            {
                switch (inHMI_Info.Type)
                {
                    case emDEVICE_BUTTON_TYPE.emBT_M:
                        inHMI_Info.HMI_PLC.PLC_Socket.Write_Bit(inHMI_Info.Device, false);
                        Set_Off_Line_Bit(false);
                        break;

                    case emDEVICE_BUTTON_TYPE.emBT_Set:
                    case emDEVICE_BUTTON_TYPE.emBT_Reset:
                    case emDEVICE_BUTTON_TYPE.emBT_Inv:
                        break;
                }
            }
            base.OnMouseUp(e);
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
                base.Refresh();
            }
        }
        private void Set_Off_Line_Bit(bool data)
        {
            if (inHMI_Info.HMI_PLC != null)
            {
                if (!inHMI_Info.HMI_PLC.PLC_Socket.Connect && inHMI_Info.Light_Switch)
                {
                    inHMI_Info.HMI_PLC.Read.Add_Bit(inHMI_Info.Device, data);
                    //HMI_Status = Read_Bit(inHMI.Light_Device, data);
                }
            }
            else
            {
                //HMI_Status = data;
            }
        }
        #endregion
    }
    public class THMI_Info_Button : THMI_Info_Base 
    {
        #region 物件屬性
        private string                   in_Device = "X0000";
        private emDEVICE_BUTTON_TYPE     in_Type = emDEVICE_BUTTON_TYPE.emBT_M;

        private THMI_Status_List         in_Status_List = new THMI_Status_List();
        private bool                     in_Light_Switch = true;
        private string                   in_Light_Device = "X0000";
                                  
        private bool                     in_Lock_Switch = false;
        private string                   in_Lock_Device = "X0000";
        private emDEVICE_LOCK_TYPE       in_Lock_Type = emDEVICE_LOCK_TYPE.emBit_On;
                                         
        private int                      in_Status_Index = 0;
        private THMI_ImageList           in_HMI_ImageList = null;
        private emHMI_Bonder_Shape       in_Bonder_Shape = emHMI_Bonder_Shape.Rect;
        private string                   in_Image_Name = "";
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
        public emDEVICE_BUTTON_TYPE Type
        {
            get
            {
                return in_Type;
            }
            set
            {
                in_Type = value;
            }
        }
        public bool Light_Switch
        {
            get
            {
                return in_Light_Switch;
            }
            set
            {
                in_Light_Switch = value;
            }
        }
        public string Light_Device
        {
            get
            {
                return in_Light_Device;
            }
            set
            {
                in_Light_Device = Generate_Device(value);
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
        public bool Status_Flag
        {
            get
            {
                bool result = false;

                if (in_Status_Index == 0) result = false;
                else result = true;
                return result;
            }
            set
            {
                Set_HMI_Data(value);
            }
        }
        public int Status_Index
        {
            get
            {
                return in_Status_Index;
            }
            set
            {
                Set_HMI_Data(value);
            }
        }
        public THMI_ImageList HMI_ImageList
        {
            get
            {
                return in_HMI_ImageList;
            }
            set
            {
                if (in_HMI_ImageList != value)
                {
                    in_HMI_ImageList = value;
                    Refresh_Component();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public THMI_Status_List Status_List
        {
            get
            {
                return in_Status_List;
            }
            set
            {
                in_Status_List.Set(value);
            }
        }

        public emHMI_Bonder_Shape Bonder_Shape
        {
            get
            {
                return in_Bonder_Shape;
            }
            set
            {
                if (in_Bonder_Shape != value)
                {
                    in_Bonder_Shape = value;
                }
            }
        }
        public string Image_Name
        {
            get
            {
                return in_Image_Name;
            }
            set
            {
                in_Image_Name = value;
            }
        }
        #endregion

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Info_Button(Component owner = null)
        {
            Owner = owner;
            Set_Default();
        }
        private void Set_Default()
        {
            in_Status_List.Set_Count(2);
            in_Status_List.Set(0, "Status1", "OFF", Color.Black, Color.Gray, 0);
            in_Status_List.Set(1, "Status2", "ON", Color.Black, Color.Green, 1);
        }
        public void Copy(THMI_Info_Button sor, ref THMI_Info_Button dis)
        {
            THMI_Info_Base tmp_dis = (THMI_Info_Base)dis;
            dis.Owner = sor.Owner;
            dis.in_HMI_PLC = sor.in_HMI_PLC;
            dis.in_Status_List = sor.in_Status_List.Copy();

            dis.in_Device = sor.in_Device;
            dis.in_Type = sor.in_Type;

            dis.in_Light_Switch = sor.in_Light_Switch;
            dis.in_Light_Device = sor.in_Light_Device;

            dis.in_Lock_Switch = sor.in_Lock_Switch;
            dis.in_Lock_Device = sor.in_Lock_Device;
            dis.in_Lock_Type = sor.in_Lock_Type;

            dis.in_Status_Index = sor.in_Status_Index;
            dis.in_HMI_ImageList = sor.in_HMI_ImageList;
            dis.in_Bonder_Shape = sor.in_Bonder_Shape;
            dis.in_Image_Name = sor.in_Image_Name;
        }
        public void Copy(ref THMI_Info_Button dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Info_Button Copy()
        {
            THMI_Info_Button result = new THMI_Info_Button();
            Copy(this, ref result);
            return result;
        }
        #endregion

        #region 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        //-- 覆蓋繼承物件
        //--------------------------------------------------------------------------------
        public override string ToString()
        {
            return Device;
        }
        override public void Copy_Base(THMI_Info_Base sor, THMI_Info_Base dis)
        {
            if (sor is THMI_Info_Button && dis is THMI_Info_Button)
            {
                THMI_Info_Button dis_b = (THMI_Info_Button)dis;
                Copy((THMI_Info_Button)sor, ref dis_b);
            }
        }
        override public THMI_Info_Base New_Base()
        {
            return new THMI_Info_Button();
        }
        override public bool Edit_Info()
        {
            bool result = false;
            THMI_Info_Button tmp = this;
            result = HMI_Tool.Edit_HMI_Info(ref tmp);
            return result;
        }
        override public void Update_HMI_Data()
        {
            if (in_Light_Switch)
            {
                Status_Flag = Get_PLC_Light_Device();
            }
        }
        #endregion

        #region 元件公用方法
        //--------------------------------------------------------------------------------
        //-- 元件公用方法
        //--------------------------------------------------------------------------------
        public void Set_Component_Data(PaintEventArgs e, Panel obj)
        {
            Set_Component_Data(e, obj, in_Status_Index);
        }
        public void Set_Component_Data(PaintEventArgs e, Panel obj, int status_index)
        {
            Disp_Border(e, obj, status_index);
            Disp_Image(e, obj, status_index);
            Disp_Text(e, obj, status_index);          
            //obj.Enabled = Get_PLC_Lock_Device();
        }
        public void Set_Component_Data(PaintEventArgs e, Panel obj, bool status)
        {
            Set_Component_Data(e, obj, Get_Status_Index(status));
        }
        private Bitmap Get_Status_Image(int status_index)
        {
            Bitmap result = null;

            THMI_Status status = in_Status_List[status_index];
            if (status != null && in_HMI_ImageList != null)
            {
                result = in_HMI_ImageList.HMI_Info.Image_Boxs.Get_Image(in_Image_Name, status.Image_Index);
            }
            return result;
        }
        private Bitmap Get_Status_Image(int status_index, System.Drawing.Size size)
        {
            Bitmap result = null;

            THMI_Status status = in_Status_List[status_index];
            if (status != null && in_HMI_ImageList != null)
            {
                result = in_HMI_ImageList.HMI_Info.Image_Boxs.Get_Image(in_Image_Name, status.Image_Index, size);
            }
            return result;
        }
        public void Disp_Border(PaintEventArgs e, Panel obj, int index)
        {
            THMI_Status tmp_status = null;
            Bitmap tmp_bmp = null;
            System.Drawing.Drawing2D.GraphicsPath path_out = null;
            System.Drawing.Drawing2D.GraphicsPath path_bnd = null;
            Region region_out = null;
            Region region_bnd = null;


            int bond_size = 2;
            System.Drawing.Size draw_size = obj.Size;
            System.Drawing.Size bnd_size = HMI_Tool.Size_Ofs(draw_size, -bond_size * 2);

            tmp_status = in_Status_List[index];
            if (e != null && obj != null && tmp_status != null)
            {
                switch (in_Bonder_Shape)
                {
                    case emHMI_Bonder_Shape.Rect:
                        path_out = GraphicsPath_Tool.Get_Path_Round(draw_size, 2);
                        path_bnd = GraphicsPath_Tool.Get_Path_Round(bnd_size, 2);
                        break;

                    case emHMI_Bonder_Shape.Round:
                        path_out = GraphicsPath_Tool.Get_Path_Round(draw_size);
                        path_bnd = GraphicsPath_Tool.Get_Path_Round(bnd_size);
                        break;

                    case emHMI_Bonder_Shape.Ellipse:
                        path_out = GraphicsPath_Tool.Get_Path_Ellipse(draw_size);
                        path_bnd = GraphicsPath_Tool.Get_Path_Ellipse(bnd_size);
                        break;

                    case emHMI_Bonder_Shape.Image:
                        tmp_bmp = JJS_Image_Tool.Get_Image_Loop(Get_Status_Image(index, draw_size), 0, 0);
                        path_out = GraphicsPath_Tool.Get_Path_Bitmap(tmp_bmp);

                        tmp_bmp = JJS_Image_Tool.Get_Image_Loop(Get_Status_Image(index, bnd_size), 0, 0);
                        path_bnd = GraphicsPath_Tool.Get_Path_Bitmap(tmp_bmp);
                        break;
                }

                if (path_out == null)
                {
                    path_out = GraphicsPath_Tool.Get_Path_Round(draw_size, 2);
                    path_bnd = GraphicsPath_Tool.Get_Path_Round(bnd_size, 2);
                }

                obj.Region = new Region(path_out);

                region_out = new Region(path_out);
                region_bnd = new Region(path_bnd);
                region_bnd.Translate(bond_size, bond_size);

                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(Color.Black);
                if (region_out != null && region_bnd != null)
                {
                    brush.Color = Color.Gray;
                    e.Graphics.FillRegion(brush, region_out);

                    brush.Color = tmp_status.Face_Color;
                    e.Graphics.FillRegion(brush, region_bnd);
                }
            }
        }
        private void Disp_Image(PaintEventArgs e, Panel obj, int index)
        {
            THMI_Status tmp_status = null;
            float x = 0, y = 0;
             

            tmp_status = in_Status_List[index];
            if (e != null && obj != null && tmp_status != null)
            {
                Bitmap new_image = Get_Status_Image(index, obj.Size);
                if (new_image != null)
                {
                    if (obj is THMI_Button)
                    {
                        THMI_Button tmp_obj = (THMI_Button)obj;
                        if (tmp_obj.On_Mouse_Down_Flag) { x = 2; y = 2; };
                    }
                    e.Graphics.DrawImage(new_image, x, y);
                }
                else
                {
                    obj.BackgroundImage = null;
                }
            }
        }
        private void Disp_Text(PaintEventArgs e, Panel obj, int index)
        {
            THMI_Status tmp_status = null;
            System.Drawing.SolidBrush brush = null;
            StringFormat format = new StringFormat();


            tmp_status = in_Status_List[index];
            if (obj != null && tmp_status != null)
            {
                if (tmp_status.Disp_Text)
                {
                    brush = new System.Drawing.SolidBrush(tmp_status.Font_Color);
                    format = HMI_Tool.Get_StringFormat(tmp_status.Text_Align);
                    e.Graphics.DrawString(tmp_status.Text, tmp_status.Font, brush, e.ClipRectangle, format);
                }
                else
                {
                    obj.Text = "";
                }
            }
        }
        public void Set_HMI_Data(bool value)
        {
            Set_HMI_Data(Get_Status_Index(value));
        }
        public void Set_HMI_Data(int value)
        {
            if (in_Status_Index != value)
            {
                in_Status_Index = value;
                Refresh_Component();
            }
        }
        public bool Get_PLC_Device()
        {
            bool result = false;

            if (HMI_PLC != null) result = HMI_PLC.Read.Get_Data_Bit(in_Device);
            return result;
        }
        public bool Get_PLC_Light_Device()
        {
            bool result = false;

            if (HMI_PLC != null) result = HMI_PLC.Read.Get_Data_Bit(in_Light_Device);
            return result;
        }
        public bool Get_PLC_Lock_Device()
        {
            bool result = false;
            bool tmp_flag = false;

            if (HMI_PLC != null) tmp_flag = HMI_PLC.Read.Get_Data_Bit(in_Lock_Device);
            if (in_Lock_Switch)
            {
                switch(Lock_Type)
                {
                    case emDEVICE_LOCK_TYPE.emBit_On: result = tmp_flag; break;
                    case emDEVICE_LOCK_TYPE.emBit_Off: result = !tmp_flag; break;
                }
            }
            else result = true;
            return result;
        }
        public THMI_Status Get_Status_Item(int status_index)
        {
            THMI_Status result = null;

            result = Status_List[status_index];
            return result;
        }
        public THMI_Status Get_Status_Item(bool status)
        {
            return Get_Status_Item(Get_Status_Index(status));
        }
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        private int Get_Status_Index(bool value)
        {
            int result = 0;

            if (!value) result = 0;
            else result = 1;
            return result;
        }
        #endregion
    }
}
