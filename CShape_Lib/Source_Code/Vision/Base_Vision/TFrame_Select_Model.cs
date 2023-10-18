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
    public partial class TFrame_Select_Model : UserControl
    {
        public TJJS_ShapeModel JJS_Model = new TJJS_ShapeModel();
        public TFrame_Select_Model()
        {
            InitializeComponent();
        }
        public void Set_Model(TJJS_ShapeModel jjs_model)
        {
            JJS_Model.Set(jjs_model);
            HW.HalconWindow.ClearWindow();
            E_File_Name.Text = System.IO.Path.GetFileName(JJS_Model.File_Name);
            if (!JJS_Vision.Is_Empty(JJS_Model.Model))
            {
                try
                {
                    JJS_Model.Set_Part(HW);
                    HW.HalconWindow.SetColor("white");
                    JJS_Model.XLD.DispObj(HW.HalconWindow);
                    JJS_Vision.Display_Hairline(HW, 0.0, 0.0, 20, 0, "red");
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
        private void button1_Click(object sender, EventArgs e)
        {
            TForm_Edit_Model form = new TForm_Edit_Model();
            form.Set_Pram(JJS_Model);
            if (form.ShowDialog() == DialogResult.OK)
            {
                JJS_Model.Set(form.Param);
                Set_Model(JJS_Model);
            }
        }
    }
}
