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
    public partial class TFrame_Find_Param : UserControl
    {
        public TFrame_Find_Param()
        {
            InitializeComponent();
        }
        public void Get_Param(ref TFind_Param param)
        {
            try
            {
                param.NumLevels = Convert.ToInt32(CB_NumLevels.Text);
                param.AngleStart = Convert.ToDouble(CB_AngleStart.Text);
                param.AngleExtent = Convert.ToDouble(CB_AngleExtent.Text);
                param.MinScore = Convert.ToDouble(CB_MinScore.Text);
                param.MaxOverlap = Convert.ToDouble(CB_MaxOverlap.Text);
                param.ScaleMin = Convert.ToDouble(CB_ScaleMin.Text);
                param.ScaleMax = Convert.ToDouble(CB_ScaleMax.Text);
                param.Greediness = Convert.ToDouble(CB_Greediness.Text);
                param.NumMatches = Convert.ToInt32(CB_NumMatches.Text);
                param.SubPixel = CB_SubPixel.Text;
            }
            catch
            {

            }
        }
        public void Set_Param(TFind_Param param)
        {
            try
            {
                CB_NumLevels.Text = param.NumLevels.ToString();
                CB_AngleStart.Text = param.AngleStart.ToString();
                CB_AngleExtent.Text = param.AngleExtent.ToString();
                CB_MinScore.Text = param.MinScore.ToString();
                CB_MaxOverlap.Text = param.MaxOverlap.ToString();
                CB_ScaleMin.Text = param.ScaleMin.ToString();
                CB_ScaleMax.Text = param.ScaleMax.ToString();
                CB_Greediness.Text = param.Greediness.ToString();
                CB_NumMatches.Text = param.NumMatches.ToString();
                CB_SubPixel.Text = param.SubPixel;
            }
            catch
            {

            }
        }
    }
    public class TFind_Param : TBase_Class
    {
        public int NumLevels,
                                     NumMatches;
        public double AngleStart,
                                     AngleExtent,
                                     MinScore,
                                     MaxOverlap,
                                     Greediness,
                                     ScaleMin,
                                     ScaleMax;
        public string SubPixel;

        public TFind_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Class result = new TFind_Param();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Param && dis_base is TFind_Param)
            {
                TFind_Param sor = (TFind_Param)sor_base;
                TFind_Param dis = (TFind_Param)dis_base;

                dis.NumLevels = sor.NumLevels;
                dis.NumMatches = sor.NumMatches;
                dis.AngleStart = sor.AngleStart;
                dis.AngleExtent = sor.AngleExtent;
                dis.MinScore = sor.MinScore;
                dis.MaxOverlap = sor.MaxOverlap;
                dis.Greediness = sor.Greediness;
                dis.ScaleMin = sor.ScaleMin;
                dis.ScaleMax = sor.ScaleMax;
                dis.SubPixel = sor.SubPixel;
            }
        }

        public void Set_Default()
        {
            NumLevels = 0;
            NumMatches = 1;
            AngleStart = -0.2;
            AngleExtent = 0.39;
            MinScore = 0.7;
            MaxOverlap = 0.7;
            Greediness = 0;
            ScaleMin = 0.9;
            ScaleMax = 1.1;
            SubPixel = "none";
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                AngleStart = ini.ReadFloat(tmp_section, "AngleStart", -0.2);
                AngleExtent = ini.ReadFloat(tmp_section, "AngleExtent", 0.39);
                MinScore = ini.ReadFloat(tmp_section, "MinScore", 0.7);
                NumMatches = ini.ReadInteger(tmp_section, "NumMatches", 1);
                MaxOverlap = ini.ReadFloat(tmp_section, "MaxOverlap", 1.0);
                SubPixel = ini.ReadString(tmp_section, "SubPixel", "none");
                NumLevels = ini.ReadInteger(tmp_section, "NumLevels", 0);
                Greediness = ini.ReadFloat(tmp_section, "Greediness", 0.0);
                ScaleMin = ini.ReadFloat(tmp_section, "ScaleMin", 1.0);
                ScaleMax = ini.ReadFloat(tmp_section, "ScaleMax", 1.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteFloat(tmp_section, "AngleStart", AngleStart);
                ini.WriteFloat(tmp_section, "AngleExtent", AngleExtent);
                ini.WriteFloat(tmp_section, "MinScore", MinScore);
                ini.WriteInteger(tmp_section, "NumMatches", NumMatches);
                ini.WriteFloat(tmp_section, "MaxOverlap", MaxOverlap);
                ini.WriteString(tmp_section, "SubPixel", SubPixel);
                ini.WriteInteger(tmp_section, "NumLevels", NumLevels);
                ini.WriteFloat(tmp_section, "Greediness", Greediness);
                ini.WriteFloat(tmp_section, "ScaleMin", ScaleMin);
                ini.WriteFloat(tmp_section, "ScaleMax", ScaleMax);
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TFind_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/AngleStart", AngleStart, new_value.AngleStart, ref flag);
            log.Log_Diff(section + "/AngleExtent", AngleExtent, new_value.AngleExtent, ref flag);
            log.Log_Diff(section + "/MinScore", MinScore, new_value.MinScore, ref flag);
            log.Log_Diff(section + "/NumMatches", NumMatches, new_value.NumMatches, ref flag);
            log.Log_Diff(section + "/MaxOverlap", MaxOverlap, new_value.MaxOverlap, ref flag);
            log.Log_Diff(section + "/SubPixel", SubPixel, new_value.SubPixel, ref flag);
            log.Log_Diff(section + "/NumLevels", NumLevels, new_value.NumLevels, ref flag);
            log.Log_Diff(section + "/Greediness", Greediness, new_value.Greediness, ref flag);
            log.Log_Diff(section + "/ScaleMin", ScaleMin, new_value.ScaleMin, ref flag);
            log.Log_Diff(section + "/ScaleMax", ScaleMax, new_value.ScaleMax, ref flag);
        }
    }
}