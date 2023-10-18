using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using EFC.INI;

namespace EFC.SPC_Chart
{
    public delegate void evSPC_Draw_Reflash(TSPC_Data spc_data);
   
    public partial class TFrame_Chart : UserControl
    {
        public TSPC_View_Data Spc_View = new TSPC_View_Data();
        private TSPC_Data[] SPC_Data_Ptr = null;
        public event evSPC_Draw_Reflash SPC_Reflash;

        public TFrame_Chart()
        {
            InitializeComponent();
            panel1.Dock = DockStyle.Fill;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            int no = 0;

            if (Spc_View != null && Spc_View.Data_Ptr != null && Spc_View.Data_Ptr.Data.Length >= 0)
            {
                var results = SPC_Chart.HitTest(e.Location.X, e.Location.Y, false, System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea);
                foreach (var result in results)
                {
                    if (result.ChartElementType == System.Windows.Forms.DataVisualization.Charting.ChartElementType.PlottingArea)
                    {
                        var x_var = result.ChartArea.AxisX.PixelPositionToValue(e.Location.X);
                        var y_var = result.ChartArea.AxisY.PixelPositionToValue(e.Location.Y);
                        Point mp = new Point((int)e.Location.X, (int)result.ChartArea.AxisY.ValueToPixelPosition(y_var));
                        SPC_Chart.ChartAreas[0].CursorX.SetCursorPixelPosition(mp, true);
                        SPC_Chart.ChartAreas[0].CursorY.SetCursorPixelPosition(mp, true);

                        no = (int)x_var;
                        if (no >= 0 && no < Spc_View.Data_Ptr.Data_Count)
                        {
                            if (no < Spc_View.Data_Ptr.Data.Length) E_Value.Text = string.Format("{0:f3}", Spc_View.Data_Ptr.Data[no]);
                            L_Info.Text = string.Format("X={0:f3}, Y={1:f3}", x_var, y_var);
                        }
                    }
                }
            }
        }
        public void Init()
        {
            string data_name;

            data_name = "Data1";
            //Data_Ptr.Set_Default_Limit();
            //chart1.Series[data_name].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Cross;
            SPC_Chart.ChartAreas[data_name].AxisX.Title = Spc_View.X_Title;
            SPC_Chart.ChartAreas[data_name].AxisY.Title = Spc_View.Y_Title;

            SPC_Chart.ChartAreas[data_name].AxisX.Maximum = 100;
            SPC_Chart.ChartAreas[data_name].AxisX.Minimum = 0;
            SPC_Chart.ChartAreas[data_name].AxisY.Maximum = 1.1;
            SPC_Chart.ChartAreas[data_name].AxisY.Minimum = -0.1;
        }
        public void Set_SPC_Data(TSPC_Data[] spc_data)
        {
            if (spc_data != null)
            {
                SPC_Data_Ptr = spc_data;
                CB_SPC_Name.Items.Clear();
                for (int i = 0; i < SPC_Data_Ptr.Length; i++)
                {
                    CB_SPC_Name.Items.Add(SPC_Data_Ptr[i].Name);
                }
            }
        }
        public double Double_Dot(double data, int no)
        {
            double result;
            int tmp;

            tmp = (int)(data * Math.Pow(10, no));
            result = tmp / Math.Pow(10, no);
            return result;
        }
        public void Draw_Chart()
        {
            string data_name = "";
            double x_min, x_max, y_min, y_max;

            if (Spc_View.Data_Ptr != null)
            {
                data_name = "Data1";
                SPC_Chart.Series["Data1"].Points.Clear();
                SPC_Chart.Series["Up_Limit"].Points.Clear();
                SPC_Chart.Series["Dn_Limit"].Points.Clear();

                x_min = Spc_View.X_Min;
                x_max = Spc_View.X_Min + Spc_View.X_Width;
                y_min = Spc_View.Y_Min;
                y_max = Spc_View.Y_Min + Spc_View.Y_Width;

                SPC_Chart.ChartAreas[data_name].AxisX.Title = Spc_View.X_Title;
                SPC_Chart.ChartAreas[data_name].AxisY.Title = Spc_View.Y_Title;

                SPC_Chart.ChartAreas[data_name].AxisX.Minimum = Spc_View.Double_Dot(x_min);
                SPC_Chart.ChartAreas[data_name].AxisX.Maximum = Spc_View.Double_Dot(x_max);
                SPC_Chart.ChartAreas[data_name].AxisY.Minimum = Spc_View.Double_Dot(y_min);
                SPC_Chart.ChartAreas[data_name].AxisY.Maximum = Spc_View.Double_Dot(y_max);

                Chart_Clear();
                Draw_Chart_SPC_Line();
                Draw_Chart_Data_Line();
                E_Up_Limit.Text = Spc_View.Data_Ptr.UCL.ToString("0.000");
                E_Center.Text = Spc_View.Data_Ptr.Center.ToString("0.000");
                E_Dn_Limit.Text = Spc_View.Data_Ptr.LCL.ToString("0.000");
                E_Avg.Text = Spc_View.Data_Ptr.Data_Avg().ToString("0.000");
            }
        }
        public void Chart_Clear()
        {
            SPC_Chart.Series["Up_Limit"].Points.Clear();
            SPC_Chart.Series["Center"].Points.Clear();
            SPC_Chart.Series["Dn_Limit"].Points.Clear();
            SPC_Chart.Series["Data1"].Points.Clear();
        }
        public void Draw_Chart_SPC_Line()
        {
            int x_min = 0, x_max = 0;
            double x;

            x_min = (int)Spc_View.X_Min;
            x_max = (int)(Spc_View.X_Min + Spc_View.X_Width);
            for (int i = 0; i < Spc_View.Data_Ptr.Data_Max_Count; i++)
            {
                x = i;
                SPC_Chart.Series["Up_Limit"].Points.AddXY(x, Spc_View.Data_Ptr.UCL);
                SPC_Chart.Series["Center"].Points.AddXY(x, Spc_View.Data_Ptr.Center);
                SPC_Chart.Series["Dn_Limit"].Points.AddXY(x, Spc_View.Data_Ptr.LCL);
            }
        }
        public void Draw_Chart_Data_Line()
        {
            int x_min = 0, x_max = 0;
            double x, y;

            x_min = (int)Spc_View.X_Min;
            x_max = (int)(Spc_View.X_Min + Spc_View.X_Width);
            for (int i = x_min; i < x_max; i++)
            {
                if (i >= 0 && i < Spc_View.Data_Ptr.Data_Count)
                {
                    x = i;
                    y = Spc_View.Data_Ptr.Data[i];
                    SPC_Chart.Series["Data1"].Points.AddXY(x, y);
                }
            }
        }
        private void B_Zoom_Fit_Click(object sender, EventArgs e)
        {
            Spc_View.Zoom_Fit();
            Draw_Chart();
        }
        private void B_X_Zoom_In_Click(object sender, EventArgs e)
        {
            Spc_View.X_Zoom_In();
            Draw_Chart();
        }
        private void B_X_Zoom_Out_Click(object sender, EventArgs e)
        {
            Spc_View.X_Zoom_Out();
            Draw_Chart();
        }
        private void B_X_Shift_Left_Click(object sender, EventArgs e)
        {
            Spc_View.X_Shift_Left();
            Draw_Chart();
        }
        private void B_X_Shift_Right_Click(object sender, EventArgs e)
        {
            Spc_View.X_Shift_Right();
            Draw_Chart();
        }
        private void B_Y_Zoom_In_Click(object sender, EventArgs e)
        {
            Spc_View.Y_Zoom_In();
            Draw_Chart();
        }
        private void B_Y_Zoom_Out_Click(object sender, EventArgs e)
        {
            Spc_View.Y_Zoom_Out();
            Draw_Chart();
        }
        private void B_Y_Shift_Up_Click(object sender, EventArgs e)
        {
            Spc_View.Y_Shift_Up();
            Draw_Chart();
        }
        private void B_Y_Shift_Dn_Click(object sender, EventArgs e)
        {
            Spc_View.Y_Shift_Dn();
            Draw_Chart();
        }
        private void CB_SPC_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            Select_SPC_Data(CB_SPC_Name.Text);
        }
        public void Select_SPC_Data(string spc_name)
        {
            CB_SPC_Name.Text = spc_name;
            Spc_View.Data_Ptr = Get_SPC_Data(spc_name);
            Spc_View.Get_Default_View();
            Draw_Chart();
            if (SPC_Reflash != null) SPC_Reflash(Spc_View.Data_Ptr);
        }
        private TSPC_Data Get_SPC_Data(string name)
        {
            TSPC_Data result = null;

            if (SPC_Data_Ptr != null)
            {
                for (int i = 0; i < SPC_Data_Ptr.Length; i++)
                {
                    if (name == SPC_Data_Ptr[i].Name)
                    {
                        result = SPC_Data_Ptr[i];
                        break;
                    }
                }
            }
            return result;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (Spc_View.Data_Ptr != null && Spc_View.Data_Ptr.Reflash)
            {
                if (SPC_Reflash != null) SPC_Reflash(Spc_View.Data_Ptr);
                Draw_Chart();
                Spc_View.Data_Ptr.Reflash = false;
            }
            timer1.Enabled = true;
        }

    }
    public class TSPC_Data_Manager
    {
        public string In_Default_Path;
        public string Default_FileName,
                      FileName;

        public TSPC_Data[] SPC_Data = new TSPC_Data[0];

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public int SPC_Data_Count
        {
            get
            {
                return SPC_Data.Length;
            }
            set
            {
                int old_count;

                old_count = SPC_Data.Length;
                Array.Resize(ref SPC_Data, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        SPC_Data[i] = new TSPC_Data();
                }
            }
        }
        public TSPC_Data_Manager()
        {
        }

        public TSPC_Data Get_SPC_Data(string name)
        {
            TSPC_Data result = null;

            for (int i = 0; i < SPC_Data.Length; i++ )
            {
                if (name == SPC_Data[i].Name)
                {
                    result = SPC_Data[i];
                    break;
                }
            }
            return result;
        }
        public void Add_SPC_Data(TSPC_Data spc_data)
        {
            if (Get_SPC_Data(spc_data.Name) == null)
            {
                SPC_Data_Count++;
                SPC_Data[SPC_Data_Count - 1].Set(spc_data);
            }
        }
        public void Add_SPC_Data(string name)
        {
            TSPC_Data spc_data = Get_SPC_Data(name);

            if (spc_data == null)
            {
                spc_data = new TSPC_Data(name);
                Add_SPC_Data(spc_data);
            }
        }
        public void Add_SPC_Data(string name, double center, double ucl, double lcl)
        {
            Add_SPC_Data(name);
            Set_SPC_Data(name, center, ucl, lcl);
        }
        public void Add_SPC_Data(string name, double ucl, double lcl)
        {
            Add_SPC_Data(name);
            Set_SPC_Data(name, ucl, lcl);
        }
        public void Add_SPC_Data(string name, double ucl)
        {
            Add_SPC_Data(name);
            Set_SPC_Data(name, ucl);
        }

        public void Set_SPC_Data(TSPC_Data in_spc_data)
        {
            TSPC_Data spc_data = Get_SPC_Data(in_spc_data.Name);
            if (spc_data != null)
            {
                spc_data.Set(in_spc_data);
            }
        }
        public void Set_SPC_Data(string name, double center, double ucl, double lcl)
        {
            TSPC_Data spc_data = Get_SPC_Data(name);
            if (spc_data != null)
                spc_data.Set(center, ucl, lcl);
        }
        public void Set_SPC_Data(string name, double ucl, double lcl)
        {
            TSPC_Data spc_data = Get_SPC_Data(name);
            if (spc_data != null)
                spc_data.Set(ucl, lcl);
        }
        public void Set_SPC_Data(string name, double ucl)
        {
            TSPC_Data spc_data = Get_SPC_Data(name);
            if (spc_data != null)
                spc_data.Set(ucl, 0);
        }
        public void Add_Data(string name, double data)
        {
            TSPC_Data spc_data = Get_SPC_Data(name);
            if (spc_data != null) spc_data.Add(data);
        }

        public void Set_Default_Path(string path)
        {
            string tmp_path = "";
            In_Default_Path = path;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = In_Default_Path + Default_FileName;
            else
                FileName = filename;

            ini = new TJJS_XML_File(FileName);
            result = Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = In_Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                SPC_Data_Count = ini.ReadInteger(section, "SPC_Count", SPC_Data_Count);
                for (int i = 0; i < SPC_Data_Count; i++)
                {
                    SPC_Data[i].Read(ini, section + "/SPC_Data" + (i + 1).ToString());
                }
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "SPC_Count", SPC_Data_Count);
                for (int i = 0; i < SPC_Data_Count; i++)
                {
                    SPC_Data[i].Write(ini, section + "/SPC_Data" + (i + 1).ToString());
                }
            }

            return true;
        }
    }
    public class TSPC_Data
    {
        public string                 Name = "";
        public double[]               Data = new double[0];
        public int                    Data_Count = 0;
        public double                 UCL,
                                      LCL,
                                      Center;
        public bool                   Reflash = false;

        public int Data_Max_Count
        {
            get
            {
                return Data.Length;
            }
            set
            {
                int old_count;

                old_count = Data.Length;
                Array.Resize(ref Data, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Data[i] = new double();
                }
            }
        }
        public TSPC_Data()
        {
            Data_Max_Count = 100;
            Reset();
            Set(0, 1, -1);
        }
        public TSPC_Data(string name)
        {
            Data_Max_Count = 100;
            Reset();
            Name = name;
        }
        public TSPC_Data(string name, double center, double ucl, double lcl)
        {
            Data_Max_Count = 100;
            Reset();
            Set(name, center, ucl, lcl);
        }
        public TSPC_Data(string name, double ucl, double lcl)
        {
            Data_Max_Count = 100;
            Reset();
            Set(name, (ucl + lcl) / 2, ucl, lcl);
        }
        public TSPC_Data(double center, double ucl, double lcl)
        {
            Data_Max_Count = 100;
            Reset();
            Set(center, ucl, lcl);
        }
        public TSPC_Data(double ucl, double lcl)
        {
            Data_Max_Count = 100;
            Reset();
            Set(ucl, lcl);
        }
        public TSPC_Data(double ucl)
        {
            Data_Max_Count = 100;
            Reset();
            Set(ucl);
        }
        public void Add(double value)
        {
            if (Data_Count < Data_Max_Count)
            {
                Data[Data_Count] = value;
                Data_Count++;
            }
            else
            {
                for (int i = 0; i < Data_Max_Count - 1; i++) Data[i] = Data[i + 1];
                Data[Data_Max_Count-1] = value;
                Data_Count = Data_Max_Count;
            }
            Reflash = true;
        }
        public void Add(double[] value)
        {
            for (int i = 0; i < value.Length; i++) Add(value[i]);
        }
        public void Set(TSPC_Data spc_data)
        {
           Name = spc_data.Name;
           Array.Resize(ref Data, spc_data.Data.Length);
           Array.Copy(spc_data.Data, Data, Data.Length);
           Data_Count = spc_data.Data_Count;
           UCL = spc_data.UCL;
           LCL = spc_data.LCL;
           Center = spc_data.Center;
           Reflash = true;
        }
        public void Set(string name)
        {
            Name = name;
        }
        public void Set(string name, double center, double ucl, double lcl)
        {
            Name = name;
            UCL = ucl;
            LCL = lcl;
            Center = center;
        }
        public void Set(string name, double ucl, double lcl)
        {
            Set(name, (ucl + lcl) / 2, ucl, lcl);
        }
        public void Set(double center, double ucl, double lcl)
        {
            Set(Name, center, ucl, lcl);
        }
        public void Set(double ucl, double lcl)
        {
            Set(Name, (ucl + lcl) / 2, ucl, lcl);
        }
        public void Set(double ucl)
        {
            Set(0, ucl, 0);
        }
        public double Data_Max()
        {
            double result = 0;
            double[] tmp_data = new double[Data_Count];
            Array.Copy(Data, tmp_data, Data_Count);
            if (tmp_data.Length > 0) result = tmp_data.Max();
            return result;
        }
        public double Data_Min()
        {
            double result = 0;
            double[] tmp_data = new double[Data_Count];
            Array.Copy(Data, tmp_data, Data_Count);
            if (tmp_data.Length > 0) result = tmp_data.Min();
            return result;
        }
        public double Data_Avg()
        {
            double result = 0;

            double[] tmp_data = new double[Data_Count];
            Array.Copy(Data, tmp_data, Data_Count);
            if (tmp_data.Length > 0) result = tmp_data.Average();
            return result;
        }
        public void Reset()
        {
            Data_Count = 0;
            for (int i = 0; i < Data_Max_Count; i++) Data[i] = 0;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Name = ini.ReadString(section, "Name", Name);
                UCL = ini.ReadFloat(section, "UCL", UCL);
                LCL = ini.ReadFloat(section, "LCL", LCL);
                Center = ini.ReadFloat(section, "Center", Center);

                Data_Max_Count = ini.ReadInteger(section, "Data_Max_Count", Data_Max_Count);
                Data_Count = ini.ReadInteger(section, "Data_Count", Data_Count);
                for (int i = 0; i < Data_Count; i++)
                {
                    Data[i] = ini.ReadFloat(section, "Data" + (i + 1).ToString(), Data[i]);
                }
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Name", Name);
                ini.WriteFloat(section, "UCL", UCL);
                ini.WriteFloat(section, "LCL", LCL);
                ini.WriteFloat(section, "Center", Center);

                ini.WriteInteger(section, "Data_Max_Count", Data_Max_Count);
                ini.WriteInteger(section, "Data_Count", Data_Count);
                for (int i = 0; i < Data_Count; i++)
                {
                    ini.WriteFloat(section, "Data" + (i + 1).ToString(), Data[i]);
                }
            }
            return true;
        }
    }
    public class TSPC_View_Data
    {
        public string      X_Title,
                           Y_Title;
//        public int         View_Count;
        public double      X_Min = 0,                //管制表顯示最小值 
                           X_Width = 20,             //管制表顯示最大值 
                           X_Width_Min = 20,
                           X_Width_Max = 100,
                           Y_Min = 0,
                           Y_Width = 20,
                           Y_Width_Min = 20,
                           Y_Width_Max = 100;
        public int         Dot_Num = 3;

        public TSPC_Data   Data_Ptr = null;

        public TSPC_View_Data()
        {

        }
        public void Get_Default_View()
        {
            double dy; 

            if (Data_Ptr != null)
            {
                X_Min = 0;
                X_Width = Data_Ptr.Data_Max_Count;
                X_Width_Min = 20;
                X_Width_Max = Data_Ptr.Data_Max_Count;

                dy = Data_Ptr.UCL - Data_Ptr.LCL;
                Y_Min = Data_Ptr.LCL - dy * 0.1;
                Y_Width = dy + dy * 0.1 * 2;
                Y_Width_Min = dy * 0.2;
                Y_Width_Max = dy * 2.0;
            }
        }
        public void Check_View_Limit()
        {
            if (X_Width < X_Width_Min) X_Width = X_Width_Min;
            if (X_Width > X_Width_Max) X_Width = X_Width_Max;
            if (Y_Width < Y_Width_Min) Y_Width = Y_Width_Min;
            if (Y_Width > Y_Width_Max) Y_Width = Y_Width_Max;
        }
        public double Double_Dot(double data)
        {
            double result;
            int tmp;

            tmp = (int)(data * Math.Pow(10, Dot_Num));
            result = tmp / Math.Pow(10, Dot_Num);
            return result;
        }
        public void X_Zoom(double scale)
        {
            X_Width = X_Width * scale;
            Check_View_Limit();
        }
        public void X_Zoom_Fit()
        {
            X_Min = 0;
            X_Width = X_Width_Max; 
            Check_View_Limit();
        }
        public void X_Shift(double ofs)
        {
            X_Min = X_Min + ofs;
            Check_View_Limit();
        }
        public void Y_Zoom(double scale)
        {
            Y_Width = Y_Width * scale;
            Check_View_Limit();
        }
        public void Y_Zoom_Fit()
        {
            double dy;

            dy = Data_Ptr.UCL - Data_Ptr.LCL;
            Y_Min = Data_Ptr.LCL - dy * 0.1;
            Y_Width = dy + dy * 0.1 * 2;
            Check_View_Limit();
        }
        public void Y_Shift(double ofs)
        {
            Y_Min = Y_Min + ofs;
            Check_View_Limit();
        }
        public void Zoom_Fit()
        {
            X_Zoom_Fit();
            Y_Zoom_Fit();
        }
        public void X_Zoom_In()
        {
            X_Zoom(0.9);
        }
        public void X_Zoom_Out()
        {
            X_Zoom(1.1);
        }
        public void X_Shift_Left()
        {
            X_Shift(-10);
        }
        public void X_Shift_Right()
        {
            X_Shift(10);
        }
        public void Y_Zoom_In()
        {
            Y_Zoom(0.9);
        }
        public void Y_Zoom_Out()
        {
            Y_Zoom(1.1);
        }
        public void Y_Shift_Up()
        {
            double ofs;

            ofs = (Y_Width_Max - Y_Width_Min) / 10;
            Y_Shift(-ofs);
        }
        public void Y_Shift_Dn()
        {
            double ofs;

            ofs = (Y_Width_Max - Y_Width_Min) / 10;
            Y_Shift(ofs);
        }
    }
}
