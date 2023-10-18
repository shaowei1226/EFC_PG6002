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
    public partial class THMI_Lamp : Panel, IHMI_Component
    {
        private THMI_Info_Lamp inHMI_Info = null;
        public bool On_UPdate_HMI_Data = false;

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Lamp()
        {
            InitializeComponent();
            Set_Default();
        }
        private void Set_Default()
        {
            inHMI_Info = new THMI_Info_Lamp(this);
            //BackgroundImageLayout = ImageLayout.Stretch;
            Size = new System.Drawing.Size(64, 64);
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
        public THMI_Info_Lamp HMI_Info 
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
        #endregion

        #region 隱藏屬性,方法,事件
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public event MouseEventHandler MouseDown;
        //protected override void OnMouseDown(MouseEventArgs mevent){}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public event MouseEventHandler MouseUp;

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public event MouseEventHandler MouseClick;
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        public void UpdateUI(Control ctl)
        {
            if (InvokeRequired)
            {
                UpdateUICallBack uu = new UpdateUICallBack(UpdateUI);
                Invoke(uu, ctl);
            }
            else
            {
                Refresh();
            }
        }
        #endregion
    }
    public class THMI_Info_Lamp : THMI_Info_Base 
    {
        #region 物件屬性
        private string                 in_Light_Device = "X0000";
        private int                    in_Status_Index = 0;
        private THMI_ImageList         in_HMI_ImageList = null;
        private THMI_Status_List       in_Status_List = new THMI_Status_List();
        private emHMI_Bonder_Shape     in_Bonder_Shape = emHMI_Bonder_Shape.Rect;
        private string                 in_Image_Name = "";
        private int                    in_Light_Bit_Count = 1;
        #endregion

        #region 元件可編輯屬性
        //--------------------------------------------------------------------------------
        //-- 元件可編輯屬性
        //--------------------------------------------------------------------------------
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
        public int Light_Bit_Count
        {
            get
            {
                return in_Light_Bit_Count;
            }
            set
            {
                int count = 0;

                if (value >= 1 && value <= 3)
                {
                    in_Light_Bit_Count = value;
                    count = (int)Math.Pow(2, in_Light_Bit_Count);
                    in_Status_List.Set_Count(count);
                    for (int i = 0; i < in_Status_List.Count; i++)
                    {
                        in_Status_List[i].Name = "Status" + (i + 1).ToString();
                    }
                }
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
                in_Status_List.Copy(value, in_Status_List);
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
        public THMI_Info_Lamp(Component owner = null)
        {
            Owner = owner;
            Set_Default();
        }
        private void Set_Default()
        {
            Light_Bit_Count = 1;
            in_Status_List.Set(0, "Status1", "Status1", Color.Black, Color.Gray, 0);
            in_Status_List.Set(1, "Status2", "Status2", Color.Black, Color.Green, 1);
        }
        private void Set_Default(ref THMI_Status status)
        {
            status.Text = "";
            status.Face_Color = Color.Gray;
        }
        public void Copy(THMI_Info_Lamp sor, ref THMI_Info_Lamp dis)
        {
            THMI_Info_Base tmp_dis = (THMI_Info_Base)dis;
            dis.Owner = sor.Owner;
            dis.in_HMI_PLC = sor.in_HMI_PLC;
            dis.in_Light_Bit_Count = sor.in_Light_Bit_Count;

            dis.in_Light_Device = sor.in_Light_Device;
            dis.in_Status_List = sor.in_Status_List.Copy();

            dis.in_Status_Index = sor.in_Status_Index;
            dis.in_HMI_ImageList = sor.in_HMI_ImageList;
            dis.in_Bonder_Shape = sor.in_Bonder_Shape;
            dis.in_Image_Name = sor.in_Image_Name;
        }
        public void Copy(ref THMI_Info_Lamp dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Info_Lamp Copy()
        {
            THMI_Info_Lamp result = new THMI_Info_Lamp();
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
            return in_Light_Device;
        }
        override public void Copy_Base(THMI_Info_Base sor, THMI_Info_Base dis)
        {
            if (sor is THMI_Info_Lamp && dis is THMI_Info_Lamp)
            {
                THMI_Info_Lamp dis_b = (THMI_Info_Lamp)dis;
                Copy((THMI_Info_Lamp)sor, ref dis_b);
            }
        }
        override public THMI_Info_Base New_Base()
        {
            return new THMI_Info_Button();
        }
        override public bool Edit_Info()
        {
            bool result = false;
            THMI_Info_Lamp tmp = this;
            result = HMI_Tool.Edit_HMI_Info(ref tmp);
            return result;
        }
        override public void Update_HMI_Data()
        {
            Status_Index = Get_PLC_Status_Index();
        }
        #endregion

        #region 元件公用方法
        //--------------------------------------------------------------------------------
        //-- 元件公用方法
        //--------------------------------------------------------------------------------
        public void Set_Component_Data(PaintEventArgs e, Panel obj)
        {
            Set_Component_Data(e, obj, Status_Index);
        }
        public void Set_Component_Data(PaintEventArgs e, Panel obj, int index)
        {
            if (obj != null)
            {
                Disp_Border(e, obj, index);
                Disp_Image(e, obj, index);
                Disp_Text(e, obj, index);
            }
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
        public void Set_HMI_Data(int value)
        {
            if (in_Status_Index != value)
            {
                in_Status_Index = value;
                if (in_Status_Index > Status_List.Count - 1) in_Status_Index = Status_List.Count - 1;
                if (in_Status_Index < 0) in_Status_Index = 0;
                Refresh_Component();
            }
        }
        public void Set_HMI_Data(bool[] data)
        {
            Set_HMI_Data(Trans(data));
        }
        public int Get_PLC_Status_Index()
        {
            int result = 0;
            bool[] data_b = null;

            if (in_HMI_PLC != null)
            {
                data_b = in_HMI_PLC.Read.Get_Data_Bit_List(in_Light_Device, Light_Bit_Count);
                if (data_b != null) result = Trans(data_b);
            }

            return result;
        }
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        private int Trans(bool[] data)
        {
            int result = 0;
            ushort[] status = new ushort[1];

            if (data != null && data.Length <= 16)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    PLC_Data_Tool.Set_Bit(status, 0, i, data[i]);
                }
                result = status[0];
            }
            return result;
        }
        #endregion
    }
}
