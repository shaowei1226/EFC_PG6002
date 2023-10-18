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
using EFC.Tool;
using EFC.INI;
using EFC.CAD.CAD_DXF;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        ACAD_DXF DXF = new ACAD_DXF();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "E:\\";
            dialog.Filter = "*.dxf|*.dxf";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DXF.Load_File(dialog.FileName);
                DXF.Root.To_Tree(treeView1);
                PageControl_Tool.Tab_Page_Select(tabControl1, "Tree");
            }
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            PageControl_Tool.Tab_Page_Select(tabControl1, "Message");
            TDXF_Data_Polyline[] line = DXF.ENTITIES.Polylines;
            TDXF_Data_UCSORG ucs = DXF.HEADER.UCSORG;
            if (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    line[i].Ofs(-ucs.X, -ucs.Y);
                    listBox1.Items.Add(line[i].ToString());
                    for(int j =0; j<line[i].Point_Count; j++)
                    {
                        listBox1.Items.Add(line[i].Point[j].ToString());
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            PageControl_Tool.Tab_Page_Select(tabControl1, "Message");
            TDXF_Data_Line[] line = DXF.ENTITIES.Lines;
            TDXF_Data_UCSORG ucs = DXF.HEADER.UCSORG;
            if (line != null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    line[i].Ofs(-ucs.X, -ucs.Y);
                    listBox1.Items.Add(line[i].ToString());
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            PageControl_Tool.Tab_Page_Select(tabControl1, "Message");
            TDXF_Data_Circle[] circle = DXF.ENTITIES.Circles;
            TDXF_Data_UCSORG ucs = DXF.HEADER.UCSORG;
            if (circle != null)
            {
                for (int i = 0; i < circle.Length; i++)
                {
                    circle[i].Ofs(-ucs.X, -ucs.Y);
                    listBox1.Items.Add(circle[i].ToString());
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            PageControl_Tool.Tab_Page_Select(tabControl1, "Message");
            TDXF_Data_Arc[] arc = DXF.ENTITIES.Arcs;
            TDXF_Data_UCSORG ucs = DXF.HEADER.UCSORG;
            if (arc != null)
            {
                for (int i = 0; i < arc.Length; i++)
                {
                    arc[i].Ofs(-ucs.X, -ucs.Y);
                    listBox1.Items.Add(arc[i].ToString());
                }
            }
        }
    }



}
