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
using EFC.CAD;

namespace EFC.Vision.Halcon
{
    public partial class TFrame_Select_NCC_Model : UserControl
    {
        public TJJS_NCC_Model JJS_Model = new TJJS_NCC_Model();
        public TFrame_Select_NCC_Model()
        {
            InitializeComponent();
        }
        public void Set_Model(TJJS_NCC_Model jjs_model)
        {
            int w, h;
            double r,c;
            double cx, cy;

            JJS_Model.Set(jjs_model);
            HW.HalconWindow.ClearWindow();
            E_File_Name.Text = System.IO.Path.GetFileName(JJS_Model.File_Name);
            if (!JJS_Vision.Is_Empty(JJS_Model.Model))
            {
                try
                {
                    JJS_Model.Image.GetImageSize(out w, out h);
                    JJS_Model.Set_Part(HW);
                    HW.HalconWindow.SetColor("white");
                    JJS_Model.Image.DispObj(HW.HalconWindow);
                    JJS_Model.Model.GetNccModelOrigin(out r, out c);
                    cx = (double)w / 2.0 + c;
                    cy = (double)h / 2.0 + r;
                    JJS_Vision.Display_Hairline(HW, cx, cy, 20, 0, "red");
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
                    JJS_Model.Model.ReadNccModel(openFileDialog1.FileName);
                    JJS_Model.Image.ReadImage(openFileDialog1.FileName + ".bmp");
                    Set_Model(JJS_Model);
                }
            }
        }
    }
}
