using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
}