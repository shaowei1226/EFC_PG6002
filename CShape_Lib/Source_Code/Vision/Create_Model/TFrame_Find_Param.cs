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
}