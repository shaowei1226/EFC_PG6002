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
using EFC.Vision.Halcon;
using EFC.Tool;
using EFC.CAD;
using EFC.Camera;

namespace EFC.Measure
{
    public enum emMeasure_Mode { P1_Point, P2_Dist, P3_Dist, P3_Angle, P3_Circle }
    public delegate void evGet_Find_Data(int ccd_no, ref TMeasure_Data m_data);
    public delegate void evCCD_Change(TForm_Measure form, int ccd_no);
    public delegate TJJS_Point evMeasure_Get_Abs_Pos(int ccd_no, TMeasure_Data m_data);

    public partial class TForm_Measure : Form
    {
        public TCamera_Base              Camera = null;
        public int                       Image_Width,
                                         Image_Height;
        public bool                      Select = false;
        public TMeasure_Data[]           Measure_Data = new TMeasure_Data[0];
        public int                       Measure_No = 0;
        public emMeasure_Mode            Measure_Mode;
        public double                    MU_MX,
                                         MU_MY;
        public string[]                  CCD_Name = new string[0];
        public double                    Scale = 1;
        public int                       Line_Width = 2; 
                         
        public evCCD_Change              On_CCD_Change = null;
        public evGet_Find_Data           On_Get_Find_Data = null;
        public evMeasure_Get_Abs_Pos     On_Get_Abs_Pos = null;

        public int Measure_Data_Count
        {
            get
            {
                return Measure_Data.Length;
            }
            set
            {
                int old_count;

                old_count = Measure_Data.Length;
                Array.Resize(ref Measure_Data, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Measure_Data[i] = new TMeasure_Data();
                }
            }
        }
        public TForm_Measure()
        {
            InitializeComponent();
            for (int i = 0; i < Measure_Data.Length; i++)
                Measure_Data[i] = new TMeasure_Data();
        }
        public TForm_Measure(string[] ccd_names, evCCD_Change on_change, evGet_Find_Data on_find_data, evMeasure_Get_Abs_Pos on_get_abs_pos)
        {
            InitializeComponent();
            for (int i = 0; i < Measure_Data.Length; i++) Measure_Data[i] = new TMeasure_Data();

            CCD_Name = ccd_names;
            On_CCD_Change = on_change;
            On_Get_Find_Data = on_find_data;
            On_Get_Abs_Pos = on_get_abs_pos;
        }
        private void TForm_Measure_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            Set_CCD_Name();
            CB_CCD_ID.SelectedIndex = 0;
            CCD_Change(CB_CCD_ID.SelectedIndex);
        }
        public void Set_CCD_Name()
        {
            CB_CCD_ID.Items.Clear();
            for (int i = 0; i < CCD_Name.Length; i++)
                CB_CCD_ID.Items.Add(CCD_Name[i]);
        }
        private void TForm_Measure_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refalsh_Camera();
        }
        public void Refalsh_Camera()
        {
            HImage image = new HImage();
            HWindowControl hw_buf;
            int w, h;

            hw_buf = tFrame_JJS_HW1.HW_Buf;
            if (Camera != null)
            {
                Camera.Get_HImage(ref image);

                if (JJS_Vision.Is_Not_Empty(image))
                {
                    JJS_Vision.Set_HW_Size(hw_buf, image);
                    hw_buf.HalconWindow.ClearWindow();
                    hw_buf.HalconWindow.DispObj(image);

                    //display 畫面十字線
                    hw_buf.HalconWindow.SetLineWidth(Line_Width);
                    JJS_Vision.Display_Hairline(hw_buf, image, emSetColor.red);
                }

                //display CCD name
                JJS_Vision.Display_String(hw_buf, Camera.Name, 10, 10, 25, Scale, "blue");
            }

            //display 選取十字線
            if (Select)
            {
                hw_buf.HalconWindow.SetLineWidth(Line_Width);
                JJS_Vision.Display_Hairline(hw_buf, MU_MX, MU_MY, Image_Width * 2, 0, "blue");
            }

            //display 選取十字線
            hw_buf.HalconWindow.SetLineWidth(Line_Width);
            for (int i = 0; i < Measure_Data_Count; i++)
                JJS_Vision.Display_Hairline(hw_buf, Measure_Data[i].Col, Measure_Data[i].Row, 20 * Scale, 0, "yellow");                

            tFrame_JJS_HW1.Copy_HW();
        }
        private void tFrame_JJS_HW1_JJS_HW_MouseDown(object sender, MouseEventArgs e)
        {
            TMeasure_Data data;
            TJJS_Point p = new TJJS_Point();

            tFrame_JJS_HW1.Get_Draw_Pos((double)e.X, (double)e.Y, out MU_MX, out MU_MY);
            if (Select)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left: 
                        data = Measure_Data[Measure_No];
                        data.Col = MU_MX;
                        data.Row = MU_MY;
                        if (On_Get_Find_Data != null) On_Get_Find_Data(CB_CCD_ID.SelectedIndex, ref data);
                        Log_Add(string.Format("Point={0:d} Col={1:f3} Row={2:f3} ", Measure_No, data.Col, data.Row) + Get_Param_String(data));
                        p = Get_Abs_Pos(CB_CCD_ID.SelectedIndex, data);
                        Log_Add(string.Format("Abs_Point=({0:f3},{1:f3})", p.X, p.Y));

                        Measure_No++;
                        if (Measure_No >= Measure_Data_Count)
                        {
                            Select = false;
                            Cal();
                        }
                        break;
                }
            }
        }
        public string Get_Param_String(TMeasure_Data data)
        {
            string result = "";
            string type_str = "";
            for (int i = 0; i < data.Param.Count; i++)
            {
                type_str = data.Param[i].Value.GetType().ToString();
                switch (type_str)
                {
                    case "System.Boolean":
                        result = result + string.Format(" {0:s}={1:s}", data.Param[i].Name, (bool)data.Param[i].Value?"True":"False");
                        break;

                    case "System.Int8":
                    case "System.Int16":
                    case "System.Int32":
                    case "System.Int64":
                        result = result + string.Format(" {0:s}={1:d}", data.Param[i].Name, (int)data.Param[i].Value); 
                        break;

                    case "System.Double": 
                        result = result + string.Format(" {0:s}={1:f3}", data.Param[i].Name, (double)data.Param[i].Value); 
                        break;

                    case "System.String": 
                        result = result + string.Format(" {0:s}={1:s}", data.Param[i].Name, (string)data.Param[i].Value); 
                        break;

                }
            }
            return result;
        }
        private void tFrame_JJS_HW1_JJS_HW_MouseMove(object sender, MouseEventArgs e)
        {
            if (Select)
            {
                tFrame_JJS_HW1.Get_Draw_Pos((double)e.X, (double)e.Y, out MU_MX, out MU_MY);
            }
        }
        public void Log_Add(string str)
        {
            listBox1.Items.Add(str);
        }
        public TJJS_Point Get_Abs_Pos(int ccd_no, TMeasure_Data m_data)
        {
            TJJS_Point result = new TJJS_Point();

            if (On_Get_Abs_Pos != null) result = On_Get_Abs_Pos(ccd_no, m_data);
            else result = Default_Get_Abs_Pos(ccd_no, m_data);
            return result;
        }
        public TJJS_Point Default_Get_Abs_Pos(int ccd_no, TMeasure_Data m_data)
        {
            TJJS_Point result = new TJJS_Point();
            double center_x, center_y;
            double pixel_size_x, pixel_size_y;
            double x, y;


            pixel_size_x = 1;
            pixel_size_y = 1;
            center_x = Image_Width / 2;
            center_y = Image_Height / 2;
            x = m_data.Param.Get_Value_Double("X");
            y = m_data.Param.Get_Value_Double("Y");
            result.X = x + (m_data.Col - center_x) * pixel_size_x;
            result.Y = y + (m_data.Row - center_y) * pixel_size_y;
            return result;
        }
        public void Cal()
        {
            switch (Measure_Mode)
            {
                case emMeasure_Mode.P2_Dist: Cal_P2_Dist(); break;
                case emMeasure_Mode.P3_Dist: Cal_P3_Dist(); break;
                case emMeasure_Mode.P3_Angle: Cal_P3_Angle(); break;
            }
        }
        public void Cal_P2_Dist()
        {
            TJJS_Point[] p = new TJJS_Point[2];
            TJJS_Line line = new TJJS_Line();
            TJJS_Point dp = new TJJS_Point();

            if (Measure_Data_Count >= 2)
            {
                for(int i=0; i<Measure_Data_Count; i++ )
                {
                    p[i] = Get_Abs_Pos(CB_CCD_ID.SelectedIndex, Measure_Data[i]);
                }
                line.Start = p[0];             
                line.End = p[1];
                dp = line.End - line.Start;

                Log_Add("[Cal P2_Dist]");
                Log_Add(string.Format("Dist={0:f5}", line.Length()));
                Log_Add(string.Format("DX={0:f3} DY={1:f3}", dp.X, dp.Y));
            }
        }
        public void Cal_P3_Dist()
        {
            TJJS_Point[] p = new TJJS_Point[3];
            TJJS_Line line = new TJJS_Line();
            TJJS_Point dp = new TJJS_Point();
            TJJS_Point l_p = new TJJS_Point();

            if (Measure_Data_Count >= 3)
            {
                for (int i = 0; i < Measure_Data_Count; i++)
                {
                    p[i] = Get_Abs_Pos(CB_CCD_ID.SelectedIndex, Measure_Data[i]);
                }
                line.Start = p[0];
                line.End = p[1];
                l_p = line.Perpendicular(p[2]);
                dp = p[2] - l_p;

                Log_Add("[Cal P3_Dist]");
                Log_Add(string.Format("Dist={0:f5}", p[2].Dist(l_p)));
                Log_Add(string.Format("DX={0:f3} DY={1:f3}", dp.X, dp.Y));
            }
        }
        public void Cal_P3_Angle()
        {
            TJJS_Point[] p = new TJJS_Point[3];
            TJJS_Line line1 = new TJJS_Line();
            TJJS_Line line2 = new TJJS_Line();
            TJJS_Angle ang = new TJJS_Angle();

            if (Measure_Data_Count >= 3)
            {
                for (int i = 0; i < Measure_Data_Count; i++)
                {
                    p[i] = Get_Abs_Pos(CB_CCD_ID.SelectedIndex, Measure_Data[i]);
                }
                line1.Start = p[1];
                line1.End = p[0];
                line2.Start = p[1];
                line2.End = p[2];
                ang.d = line1.V.Angle.d - line2.V.Angle.d;
                Log_Add("[Cal P3_Angle]");
                Log_Add(string.Format("Angle={0:f5}", ang.d));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Select = false;
            Log_Add("取消功能");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Measure_Mode = emMeasure_Mode.P2_Dist;
            Measure_Data_Count = 2;
            Measure_No = 0;
            Select = true;
            Log_Add("2點距離");
        }
        private void B_P1_Click(object sender, EventArgs e)
        {
            Measure_Mode = emMeasure_Mode.P1_Point;
            Measure_Data_Count = 1;
            Measure_No = 0;
            Select = true;
            Log_Add("1點");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Measure_Mode = emMeasure_Mode.P3_Dist;
            Measure_Data_Count = 3;
            Measure_No = 0;
            Select = true;
            Log_Add("3點距離");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Measure_Mode = emMeasure_Mode.P3_Angle;
            Measure_Data_Count = 3;
            Measure_No = 0;
            Select = true;
            Log_Add("3點角度");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Measure_Mode = emMeasure_Mode.P3_Circle;
            Measure_Data_Count = 3;
            Measure_No = 0;
            Select = true;
            Log_Add("3點圓");
        }
        private void CB_CCD_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            CCD_Change(CB_CCD_ID.SelectedIndex);
        }
        public void CCD_Change(int no)
        {
            HImage image = new HImage();

            if (On_CCD_Change != null) On_CCD_Change(this, no);
            if (Camera != null)
            {
                Image_Width = Camera.Image_Width;
                Image_Height = Camera.Image_Height;
                tFrame_JJS_HW1.SetPart(Camera.Get_HImage());
                tFrame_JJS_HW1.Zoom_Windows_Fit();
            }
        }
        public void Set_Scale(double scale)
        {
            Scale = scale;
            Line_Width = (int)(2.0 * Scale);
        }
        public void Set_Scale(double camera_width, double hw_width)
        {
            double scale = camera_width / hw_width;
            Set_Scale(scale);
        }
        public void Set_Scale(HImage image)
        {
            int w, h;

            image.GetImageSize(out w, out h);
            Set_Scale(w, tFrame_JJS_HW1.HW.Width);
        }
        private void B_Clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
    public class TMeasure_Data : TBase_Class
    {
        public double          Col,
                               Row;
        public TJJS_Value_List Param = new TJJS_Value_List();


        public TMeasure_Data()
        {
            Col = 0;
            Row = 0;
        }
        override public TBase_Class New_Class()
        {
            return new TMeasure_Data();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMeasure_Data && dis_base is TMeasure_Data)
            {
                TMeasure_Data sor = (TMeasure_Data)sor_base;
                TMeasure_Data dis = (TMeasure_Data)dis_base;
                dis.Col = sor.Col;
                dis.Row = sor.Row;
                dis.Param.Set(sor.Param);
            }
        }
    }
}
