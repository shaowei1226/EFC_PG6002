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
    public partial class TFrame_Create_NCC_Param : UserControl
    {
        public TFrame_Create_NCC_Param()
        {
            InitializeComponent();
        }
        public void Get_Param(ref TNCC_Create_Param param)
        {
            try
            {
                param.NumLevels = Convert.ToInt32(CB_NumLevels.Text);
                param.AngleStart = Convert.ToDouble(CB_AngleStart.Text);
                param.AngleStep = Convert.ToDouble(CB_AngleStep.Text);
                param.AngleExtent = Convert.ToDouble(CB_AngleExtent.Text);
                param.Metric = CB_Metric.Text;
            }
            catch
            {

            }
        }
        public void Set_Param(TNCC_Create_Param param)
        {
            try
            {
                CB_NumLevels.Text = param.NumLevels.ToString();
                CB_AngleStart.Text = param.AngleStart.ToString();
                CB_AngleStep.Text = param.AngleStep.ToString();
                CB_AngleExtent.Text = param.AngleExtent.ToString();
                CB_Metric.Text = param.Metric;
            }
            catch
            {

            }
        }
    }
}