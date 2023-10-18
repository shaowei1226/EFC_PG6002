using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using EFC.Tool;
using EFC.Camera;
using EFC.Vision.Halcon;

namespace Main
{
    public delegate void evMU_Select_Disp(TFrame_JJS_HW jjs_hw, TMU_Select_Data m_data);
    public delegate void evMU_Select_Get_Find_Data(TMU_Select_Data m_data);
    public delegate void evMU_Select_Get_Finish(TMU_Select_Data m_data);

    public partial class TForm_MU_Select : Form
    {
        public TMU_Select_Data    MU_Data = null;
        public double             MU_X,
                                  MU_Y,
                                  MU_MX,
                                  MU_MY;

        public evMU_Select_Disp   On_Display = null;
        public evMU_Select_Get_Find_Data On_Get_Find_Data = null;
        public evMU_Select_Get_Finish On_Get_Finish = null;




        public TCamera_Base Camera
        {
            get
            {
                TCamera_Base result = null;

                if (MU_Data != null) result = MU_Data.Camera;
                return result;
            }
        }
        public TForm_MU_Select(TMU_Select_Data mu_data, evMU_Select_Disp display, evMU_Select_Get_Find_Data get_find_data, evMU_Select_Get_Finish get_finish)
        {
            InitializeComponent();
            MU_Data = mu_data;
            On_Display = display;
            On_Get_Find_Data = get_find_data;
            On_Get_Finish = get_finish;
        }
        private void TForm_MU_Select_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tFrame_JJS_HW1.Set_ToolBar(!MU_Data.Select);
        }
        private void TForm_MU_Select_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            if (MU_Data.Select_OK)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refalsh_Camera();
            if( MU_Data.Select)
                B_Used_ToolBar.Text = "使用工具列";
            else
                B_Used_ToolBar.Text = "選取位置";

        }
        public void Refalsh_Camera()
        {
            double scale = 1;
            double msg_col, msg_row;
            double msg_font_size;

            scale = (double)Camera.Image_Width / tFrame_JJS_HW1.Width;
            
            if (On_Display != null) On_Display(tFrame_JJS_HW1, MU_Data);

            msg_font_size = 50 * scale;
            msg_col = Get_Center(Camera.Image_Width, MU_Data.Title_String, msg_font_size);
            msg_row = 10 * scale;
            JJS_Vision.Display_String(tFrame_JJS_HW1.HW_Buf, MU_Data.Title_String, msg_col, msg_row, msg_font_size, 1, "blue");
            JJS_Vision.Display_Hairline(tFrame_JJS_HW1.HW_Buf, MU_MX, MU_MY, Camera.Image_Width * 2, 0, "yellow");
            tFrame_JJS_HW1.Copy_HW();
        }
        public double Get_Center(double width, string msg, double font_size)
        {
            double result = 0;
            double text_width;

            text_width = msg.Length * font_size;
            result = (width - text_width ) / 2;
            return result;
        }
        public void Get_Find_Data()
        {
            MU_Data.Select_OK = true;
            MU_Data.Col = MU_MX;
            MU_Data.Row = MU_MY;
            if (On_Get_Find_Data != null) On_Get_Find_Data(MU_Data);
        }
        private void tFrame_JJS_HW1_JJS_HW_MouseDown(object sender, MouseEventArgs e)
        {
            if (MU_Data.Select)
            {
                tFrame_JJS_HW1.Get_Draw_Pos((double)e.X, (double)e.Y, out MU_MX, out MU_MY);
                switch (e.Button)
                {
                    case MouseButtons.Left: Get_Find_Data(); break;
                    case MouseButtons.Right:
                        if (MU_Data.Select_OK)
                        {
                            if (On_Get_Finish != null) On_Get_Finish(MU_Data);
                            Close();
                        }
                        break;
                }
            }
        }
        private void tFrame_JJS_HW1_JJS_HW_MouseMove(object sender, MouseEventArgs e)
        {
            if (MU_Data.Select)
                tFrame_JJS_HW1.Get_Draw_Pos((double)e.X, (double)e.Y, out MU_MX, out MU_MY);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape: DialogResult = System.Windows.Forms.DialogResult.Cancel; break;
                case Keys.Up: MU_Data.Row--; break;
                case Keys.Down: MU_Data.Row++; break;
                case Keys.Left: MU_Data.Col--; break;
                case Keys.Right: MU_Data.Col++; break;
            }
            if (On_Get_Find_Data != null) On_Get_Find_Data(MU_Data);
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void B_Select_Click(object sender, EventArgs e)
        {
            MU_Data.Select = !MU_Data.Select;
            tFrame_JJS_HW1.Set_ToolBar(!MU_Data.Select);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TMU_Select_Data_List
    //-----------------------------------------------------------------------------------------------------
    public class TMU_Select_Data_List : TBase_Class
    {
        public TMU_Select_Data[] Items = new TMU_Select_Data[0];

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count;

                old_count = Items.Length;
                Array.Resize(ref Items, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Items[i] = new TMU_Select_Data();
                }
            }
        }
        public TMU_Select_Data this[int index]
        {
            get
            {
                TMU_Select_Data result = null;

                if (index >= 0 && index < Count)
                {
                    result = Items[index];
                }

                return result;
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    Items[index].Set(value);
                }
            }
        }
        public TMU_Select_Data_List()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TMU_Select_Data_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMU_Select_Data_List && dis_base is TMU_Select_Data_List)
            {
                TMU_Select_Data_List sor = (TMU_Select_Data_List)sor_base;
                TMU_Select_Data_List dis = (TMU_Select_Data_List)dis_base;

                dis.Count = sor.Count;
                for (int i = 0; i < sor.Count; i++) dis.Items[i].Set(sor.Items[i]);
            }
        }


        public void Add(TMU_Select_Data value)
        {
            int no = 0;

            if (Count < 10)
            {
                no = Count;
                Count++;
                Items[no].Set(value);
            }
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Items.Length)
            {
                for (int i = index; i < Items.Length - 1; i++)
                {
                    Items[i] = Items[i + 1];
                }
                Array.Resize(ref Items, Count - 1);
            }
        }

    }

    public class TMU_Select_Data : TBase_Class
    {
        public string               Name = "";
        public string               Title_String;
        public TCamera_Base         Camera = null;
        public TJJS_Value_List      Param = new TJJS_Value_List();
        public double               Col = 0;
        public double               Row = 0;
        

        public bool Select = false;
        public bool Select_OK = false;

        public TMU_Select_Data()
        {
        }
        override public TBase_Class New_Class()
        {
            return new TMU_Select_Data();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMU_Select_Data && dis_base is TMU_Select_Data)
            {
                TMU_Select_Data sor = (TMU_Select_Data)sor_base;
                TMU_Select_Data dis = (TMU_Select_Data)dis_base;

                dis.Name = sor.Name;
                dis.Title_String = sor.Title_String;
                dis.Camera = sor.Camera;
                dis.Param.Set(sor.Param);
                dis.Col = sor.Col;
                dis.Row = sor.Row;


                dis.Select = sor.Select;
                dis.Select_OK = sor.Select_OK;
            }
        }


        public TMU_Select_Data(string name, string title_string, TCamera_Base carera, TJJS_Value_List param)
        {
            Set(name, title_string, carera, param);
        }
        public void Set(string name, string title_string, TCamera_Base carera, TJJS_Value_List param)
        {
            Select = true;
            Name = name;
            Title_String = title_string;
            Camera = carera;
            Param.Set(param);
        }
        public void Set(TMU_Select_Data data)
        {
            Select = data.Select;
            Select_OK = data.Select_OK;
            Name = data.Name;
            Title_String = data.Title_String;
            Camera = data.Camera;
            Param.Set(data.Param);
            Col = data.Col;
            Row = data.Row;
        }
    }
}
