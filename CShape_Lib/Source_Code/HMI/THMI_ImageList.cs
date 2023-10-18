using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace EFC.HMI
{
    public partial class THMI_ImageList : Component
    {
        private System.Drawing.Size in_Size = new System.Drawing.Size(64, 64);
        private THMI_Info_ImageList in_HMI_Info = new THMI_Info_ImageList();
        
        public THMI_ImageList()
        {
            InitializeComponent();
            Set_Default();
        }
        private void Set_Default()
        {
            //in_HMI_Info.ImageSize = new Size(64, 64);
        }
 
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(THMI_Editor), typeof(UITypeEditor))]
        public THMI_Info_ImageList HMI_Info
        {
            get
            {
                return in_HMI_Info;
            }
            set
            {
                if (value != null)
                {
                    value.Copy(ref in_HMI_Info);
                }
            }
        }


        public void Copy(THMI_ImageList sor, ref THMI_ImageList dis)
        {
            dis.in_Size = sor.in_Size;
            sor.in_HMI_Info.Copy(ref dis.in_HMI_Info);
        }
    }
    public class THMI_Info_ImageList : THMI_Info_Base
    {
        #region 物件屬性
        private THMI_Image_Box_List in_Image_Boxs = new THMI_Image_Box_List();
        #endregion

        #region 元件可編輯屬性
        //--------------------------------------------------------------------------------
        //-- 元件可編輯屬性
        //--------------------------------------------------------------------------------
        public string Database_Path
        {
            get
            {
                return Image_Boxs.Database_Path;
            }
            set
            {
                Image_Boxs.Database_Path = value;
            }
        }
        public THMI_Image_Box_List Image_Boxs
        {
            get
            {
                return in_Image_Boxs;
            }
            set
            {
                if (value != null)
                {
                    value.Copy(ref in_Image_Boxs);
                }
            }
        }

        #region 隱藏屬性,方法,事件
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public THMI_PLC HMI_PLC;
        #endregion

        #endregion

        #region 物件基礎
        //--------------------------------------------------------------------------------
        //-- 物件基礎
        //--------------------------------------------------------------------------------
        public THMI_Info_ImageList()
        {
            Set_Default();
        }
        private void Set_Default()
        {
        }
        public void Copy(THMI_Info_ImageList sor, ref THMI_Info_ImageList dis)
        {
            THMI_Info_Base tmp_dis = (THMI_Info_Base)dis;
            dis.Owner = sor.Owner;
            dis.in_HMI_PLC = sor.in_HMI_PLC;

            sor.in_Image_Boxs.Copy(ref dis.in_Image_Boxs);
        }
        public void Copy(ref THMI_Info_ImageList dis)
        {
            Copy(this, ref dis);
        }
        public THMI_Info_ImageList Copy()
        {
            THMI_Info_ImageList result = new THMI_Info_ImageList();
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
            return "";
        }
        override public void Copy_Base(THMI_Info_Base sor, THMI_Info_Base dis)
        {
            if (sor is THMI_Info_ImageList && dis is THMI_Info_ImageList)
            {
                THMI_Info_ImageList dis_b = (THMI_Info_ImageList)dis;
                Copy((THMI_Info_ImageList)sor, ref dis_b);
            }
        }
        override public THMI_Info_Base New_Base()
        {
            return new THMI_Info_ImageList();
        }
        override public bool Edit_Info()
        {
            bool result = false;
            THMI_Info_ImageList tmp = this;
            result = HMI_Tool.Edit_HMI_Info(ref tmp);
            return result;
        }
        override public void Update_HMI_Data()
        {
        }
        #endregion

        #region 元件公用方法
        //--------------------------------------------------------------------------------
        //-- 元件公用方法
        //--------------------------------------------------------------------------------
        public void Set_Component_Data(DataGridView obj)
        {
        }
        public void Set_HMI_Data(ushort[] data)
        {
            //Set_HMI_Data(Trans_Ushort_To_Bool(data));
        }
        #endregion

        #region 元件私用方法
        //--------------------------------------------------------------------------------
        //-- 元件私用方法
        //--------------------------------------------------------------------------------
        #endregion
    }
}
