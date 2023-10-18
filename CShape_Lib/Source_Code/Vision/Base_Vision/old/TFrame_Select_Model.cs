using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace EFC.Vision.Halcon
{
    public partial class TFrame_Select_Model : UserControl
    {
        public TJJS_ShapeModel JJS_Model = new TJJS_ShapeModel();
        public TFrame_Select_Model()
        {
            InitializeComponent();
        }
        public void Set_Model(TJJS_ShapeModel jjs_model)
        {
            double origin_r=0, origin_c=0;

            JJS_Model = jjs_model.Copy();
            if (JJS_Model.File_Name != "")
            {
                HW.HalconWindow.ClearWindow();
                try
                {
                    JJS_Model.Model.GetShapeModelOrigin(out origin_r, out origin_c);
                    E_File_Name.Text = System.IO.Path.GetFileName(JJS_Model.File_Name);
                    JJS_Model.Set_Part(HW);
                    HW.HalconWindow.SetColor("white");
                    JJS_Model.XLD.DispObj(HW.HalconWindow);
                    HW.HalconWindow.SetColor("red");
                    HW.HalconWindow.DispCross(origin_r, origin_c, 20, 0);
                }
                catch
                {

                }
            }
        }
        private void B_Select_File_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = JJS_Model.Default_Path;
            openFileDialog1.FileName = JJS_Model.Default_FileName; 
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (JJS_Model.Model != null)
                {
                    JJS_Model.Read(openFileDialog1.FileName);
                    JJS_Model.Model.ReadShapeModel(openFileDialog1.FileName);
                    JJS_Model.XLD = JJS_Model.Model.GetShapeModelContours(1);
                    Set_Model(JJS_Model);
                }
            }
        }
    }
}
