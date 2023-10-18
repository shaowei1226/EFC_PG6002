using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;
using EFC.INI;

namespace EFC.Vision.Halcon
{
    public partial class TFrame_Create_Param : UserControl
    {
        public TFrame_Create_Param()
        {
            InitializeComponent();
        }
        public void Get_Param(ref TCreate_Param param)
        {
            try
            {
                param.NumLevels = Convert.ToInt32(CB_NumLevels.Text);
                param.AngleStart = Convert.ToDouble(CB_AngleStart.Text);
                param.AngleStep = Convert.ToDouble(CB_AngleStep.Text);
                param.AngleExtent = Convert.ToDouble(CB_AngleExtent.Text);
                param.Contrast = Convert.ToInt32(CB_Contrast.Text);
                param.MinContrast = Convert.ToInt32(CB_MinContrast.Text);
                param.ScaleMin = Convert.ToDouble(CB_ScaleMin.Text);
                param.ScaleMax = Convert.ToDouble(CB_ScaleMax.Text);
                param.ScaleStep = Convert.ToDouble(CB_ScaleStep.Text);
                param.Optimization = CB_Optimization.Text;
                param.Metric = CB_Metric.Text;
            }
            catch
            {

            }
        }
        public void Set_Param(TCreate_Param param)
        {
            try
            {
                CB_NumLevels.Text = param.NumLevels.ToString();
                CB_AngleStart.Text = param.AngleStart.ToString();
                CB_AngleStep.Text = param.AngleStep.ToString();
                CB_AngleExtent.Text = param.AngleExtent.ToString();
                CB_Contrast.Text = param.Contrast.ToString();
                CB_MinContrast.Text = param.MinContrast.ToString();
                CB_ScaleMin.Text = param.ScaleMin.ToString();
                CB_ScaleMax.Text = param.ScaleMax.ToString();
                CB_ScaleStep.Text = param.ScaleStep.ToString();
                CB_Optimization.Text = param.Optimization;
                CB_Metric.Text = param.Metric;
            }
            catch
            {

            }
        }
    }
    public class TCreate_Param : TBase_Class
    {
        public int NumLevels;
        public double AngleStart,
                                     AngleExtent,
                                     AngleStep,
                                     ScaleMin,
                                     ScaleMax,
                                     ScaleStep;
        public string Optimization,
                                     Metric;
        public int Contrast,
                                     MinContrast;

        public TCreate_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Class result = new TCreate_Param();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TCreate_Param && dis_base is TCreate_Param)
            {
                TCreate_Param sor = (TCreate_Param)sor_base;
                TCreate_Param dis = (TCreate_Param)dis_base;

                dis.NumLevels = sor.NumLevels;
                dis.AngleStart = sor.AngleStart;
                dis.AngleExtent = sor.AngleExtent;
                dis.AngleStep = sor.AngleStep;
                dis.ScaleMin = sor.ScaleMin;
                dis.ScaleMax = sor.ScaleMax;
                dis.ScaleStep = sor.ScaleStep;
                dis.Optimization = sor.Optimization;
                dis.Metric = sor.Metric;
                dis.Contrast = sor.Contrast;
                dis.MinContrast = sor.MinContrast;
            }
        }

        public void Set_Default()
        {
            NumLevels = 0;
            AngleStart = -0.2;
            AngleExtent = 0.39;
            AngleStep = 0.0;
            ScaleMin = 0.9;
            ScaleMax = 1.1;
            ScaleStep = 0;
            Optimization = "none";
            Metric = "use_polarity";
            Contrast = 30;
            MinContrast = 10;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                NumLevels = ini.ReadInteger(tmp_section, "NumLevels", 0);
                AngleStart = ini.ReadFloat(tmp_section, "AngleStart", -0.2);
                AngleExtent = ini.ReadFloat(tmp_section, "AngleExtent", 0.39);
                AngleStep = ini.ReadFloat(tmp_section, "AngleStep", 0.0);
                Optimization = ini.ReadString(tmp_section, "Optimization", "none");
                Metric = ini.ReadString(tmp_section, "Metric", "use_polarity");
                Contrast = ini.ReadInteger(tmp_section, "Contrast", 30);
                MinContrast = ini.ReadInteger(tmp_section, "MinContrast", 5);
                ScaleMin = ini.ReadFloat(tmp_section, "ScaleMin", 1.0);
                ScaleMax = ini.ReadFloat(tmp_section, "ScaleMax", 1.0);
                ScaleStep = ini.ReadFloat(tmp_section, "ScaleStep", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteInteger(tmp_section, "NumLevels", NumLevels);
                ini.WriteFloat(tmp_section, "AngleStart", AngleStart);
                ini.WriteFloat(tmp_section, "AngleExtent", AngleExtent);
                ini.WriteFloat(tmp_section, "AngleStep", AngleStep);
                ini.WriteString(tmp_section, "Metric", Metric);
                ini.WriteInteger(tmp_section, "Contrast", Contrast);
                ini.WriteInteger(tmp_section, "MinContrast", MinContrast);
                ini.WriteFloat(tmp_section, "ScaleMin", ScaleMin);
                ini.WriteFloat(tmp_section, "ScaleMax", ScaleMax);
                ini.WriteFloat(tmp_section, "ScaleStep", ScaleStep);
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TCreate_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/NumLevels", NumLevels, new_value.NumLevels, ref flag);
            log.Log_Diff(section + "/AngleStart", AngleStart, new_value.AngleStart, ref flag);
            log.Log_Diff(section + "/AngleExtent", AngleExtent, new_value.AngleExtent, ref flag);
            log.Log_Diff(section + "/AngleStep", AngleStep, new_value.AngleStep, ref flag);

            log.Log_Diff(section + "/Metric", Metric, new_value.Metric, ref flag);
            log.Log_Diff(section + "/Contrast", Contrast, new_value.Contrast, ref flag);
            log.Log_Diff(section + "/MinContrast", MinContrast, new_value.MinContrast, ref flag);
            log.Log_Diff(section + "/ScaleMin", ScaleMin, new_value.ScaleMin, ref flag);
            log.Log_Diff(section + "/ScaleMax", ScaleMax, new_value.ScaleMax, ref flag);
            log.Log_Diff(section + "/ScaleStep", ScaleStep, new_value.ScaleStep, ref flag);
        }
    }
}