using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using EFC.INI;
using EFC.CAD;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Create_Model : Form
    {
        public HImage                    Image = new HImage();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;
        public double                    R1, C1, R2, C2;

        public TForm_Create_Model()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public void Set_Param(TFind_Mothed_1_Param param)
        {
            Param = param.Copy();

            tFrame_Select_Model1.Set_Model(Param.JJS_Model);
            tFrame_Create_Param1.Set_Param(Param.Create);

            CB_Auto_Select_Region.Checked = Param.Auto_Set_Region;
            E_Ofs_X.Text = Param.Ofs_X.ToString();
            E_Ofs_Y.Text = Param.Ofs_Y.ToString();

            E_Rect_Col1.Text = Param.Find_Region.X1.ToString();
            E_Rect_Row1.Text = Param.Find_Region.Y1.ToString();
            E_Rect_Col2.Text = Param.Find_Region.X2.ToString();
            E_Rect_Row2.Text = Param.Find_Region.Y2.ToString();
        }
        public void Update_Param()
        {

            Param.JJS_Model = tFrame_Select_Model1.JJS_Model.Copy();
            tFrame_Create_Param1.Get_Param(ref Param.Create);
            tFrame_Find_Param1.Get_Param(ref Param.Find);

            Param.Auto_Set_Region = CB_Auto_Select_Region.Checked;
            Param.Ofs_X = Convert.ToDouble(E_Ofs_X.Text);
            Param.Ofs_Y = Convert.ToDouble(E_Ofs_Y.Text);

            Param.Find_Region.X1 = Convert.ToDouble(E_Rect_Col1.Text);
            Param.Find_Region.Y1 = Convert.ToDouble(E_Rect_Row1.Text);
            Param.Find_Region.X2 = Convert.ToDouble(E_Rect_Col2.Text);
            Param.Find_Region.Y2 = Convert.ToDouble(E_Rect_Row2.Text);
        }
        private void Form_Find_Mothed_1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tFrame_JJS_HW1.SetPart(Image);
            tFrame_JJS_HW1.HW_Buf.HalconWindow.DispObj(Image);
            tFrame_JJS_HW1.Copy_HW();
        }
        private void button15_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Next1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
        private void Save_Model_Click(object sender, EventArgs e)
        {
        }
        private void B_Rect_Select_Click(object sender, EventArgs e)
        {

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow);

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            JJS_HW.HW.HalconWindow.SetTposition(1, 10);
            JJS_HW.HW.HalconWindow.WriteString("請圈選畫面搜尋區域,按滑鼠右鍵結束輸入.");
            B_Rect_Select.Enabled = false;
            B_Rect_Edit.Enabled = false;
            B_Rect_Max.Enabled = false;


            JJS_HW.HW.Focus();
            tFrame_JJS_HW1.HW.HalconWindow.DrawRectangle1(out Param.Find_Region.Y1, out Param.Find_Region.X1,
                                                                 out Param.Find_Region.Y2, out Param.Find_Region.X2);
          
            if (Param.Find_Region.X1 < 0) Param.Find_Region.X1 = 0;
            if (Param.Find_Region.Y1 < 0) Param.Find_Region.Y1 = 0;
            if (Param.Find_Region.X2 < 0) Param.Find_Region.X2 = 0;
            if (Param.Find_Region.Y2 < 0) Param.Find_Region.Y2 = 0;
            JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
            E_Rect_Col1.Text = string.Format("{0:f3}", Param.Find_Region.X1);
            E_Rect_Row1.Text = string.Format("{0:f3}", Param.Find_Region.Y1);
            E_Rect_Col2.Text = string.Format("{0:f3}", Param.Find_Region.X2);
            E_Rect_Row2.Text = string.Format("{0:f3}", Param.Find_Region.Y2);
            B_Rect_Select.Enabled = true;
            B_Rect_Edit.Enabled = true;
            B_Rect_Max.Enabled = true;
       }
        private void B_Select_Rect_Click(object sender, EventArgs e)
        {
            HImage tmp_image = new HImage();

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow);
            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            JJS_HW.HW.HalconWindow.SetTposition(10, 10);
            JJS_HW.HW.HalconWindow.WriteString("請圈選畫面標把區域,按滑鼠右鍵結束輸入.");
            JJS_HW.HW.Focus();
            JJS_HW.HW.HalconWindow.DrawRectangle1(out R1, out C1, out R2, out C2);
            JJS_HW.HW.HalconWindow.DispRectangle1(R1, C1, R2, C2);
            tmp_image = Image.Rectangle1Domain((int)R1, (int)C1, (int)R2, (int)C2);
            tmp_image = tmp_image.CropDomain();
            try
            {
                Param.JJS_Model.Model = tmp_image.CreateScaledShapeModel(
                                                 Param.Create.NumLevels,
                                                 Param.Create.AngleStart,
                                                 Param.Create.AngleExtent,
                                                 Param.Create.AngleStep,
                                                 Param.Create.ScaleMin,
                                                 Param.Create.ScaleMax,
                                                 Param.Create.ScaleStep,
                                                 Param.Create.Optimization,
                                                 Param.Create.Metric,
                                                 Param.Create.Contrast,
                                                 Param.Create.MinContrast);
                Param.JJS_Model.XLD = Param.JJS_Model.Model.GetShapeModelContours(1);
                tFrame_Select_Model1.Set_Model(Param.JJS_Model);
                if (CB_Auto_Select_Region.Checked)
                {
                    Param.Find_Region.Y1 = R1 - Param.Ofs_Y;
                    Param.Find_Region.X1 = C1 - Param.Ofs_X;
                    Param.Find_Region.Y2 = R2 + Param.Ofs_Y;
                    Param.Find_Region.X2 = C2 + Param.Ofs_X;
                    if (Param.Find_Region.X1 < 0) Param.Find_Region.X1 = 0;
                    if (Param.Find_Region.Y1 < 0) Param.Find_Region.Y1 = 0;
                    if (Param.Find_Region.X2 < 0) Param.Find_Region.X2 = 0;
                    if (Param.Find_Region.Y2 < 0) Param.Find_Region.Y2 = 0;
                    E_Rect_Col1.Text = string.Format("{0:f3}", Param.Find_Region.X1);
                    E_Rect_Row1.Text = string.Format("{0:f3}", Param.Find_Region.Y1);
                    E_Rect_Col2.Text = string.Format("{0:f3}", Param.Find_Region.X2);
                    E_Rect_Row2.Text = string.Format("{0:f3}", Param.Find_Region.Y2);
                    JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
                }
            }
            catch
            {

            }
            
        }
        private void B_Rect_Edit_Click(object sender, EventArgs e)
        {
            B_Rect_Select.Enabled = false;
            B_Rect_Edit.Enabled = false;
            B_Rect_Max.Enabled = false;

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow);
            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            JJS_HW.HW.HalconWindow.SetTposition(1, 10);
            JJS_HW.HW.HalconWindow.WriteString("請圈選畫面搜尋區域,按滑鼠右鍵結束輸入.");

            JJS_HW.HW.Focus();
            tFrame_JJS_HW1.HW.HalconWindow.DrawRectangle1Mod(
                           Param.Find_Region.Y1, Param.Find_Region.X1,
                           Param.Find_Region.Y2, Param.Find_Region.X2,
                           out Param.Find_Region.Y1, out Param.Find_Region.X1,
                           out Param.Find_Region.Y2, out Param.Find_Region.X2);

            JJS_HW.HW.HalconWindow.SetDraw("margin");
            if (Param.Find_Region.X1 < 0) Param.Find_Region.X1 = 0;
            if (Param.Find_Region.Y1 < 0) Param.Find_Region.Y1 = 0;
            if (Param.Find_Region.X2 < 0) Param.Find_Region.X2 = 0;
            if (Param.Find_Region.Y2 < 0) Param.Find_Region.Y2 = 0;
            JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
            E_Rect_Col1.Text = string.Format("{0:f3}", Param.Find_Region.X1);
            E_Rect_Row1.Text = string.Format("{0:f3}", Param.Find_Region.Y1);
            E_Rect_Col2.Text = string.Format("{0:f3}", Param.Find_Region.X2);
            E_Rect_Row2.Text = string.Format("{0:f3}", Param.Find_Region.Y2);
            B_Rect_Select.Enabled = true;
            B_Rect_Edit.Enabled = true;
            B_Rect_Max.Enabled = true;
        }
        private void B_Rect_Max_Click(object sender, EventArgs e)
        {
            string type;
            int width, height;

            JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
            JJS_HW.HW.HalconWindow.ClearWindow();
            Image.DispObj(JJS_HW.HW.HalconWindow); 
            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
            JJS_HW.HW.HalconWindow.SetLineWidth(3);
            Image.GetImagePointer1(out type, out width, out height);
            Param.Find_Region.X1 = 0;
            Param.Find_Region.Y1 = 0;
            Param.Find_Region.X2 = width;
            Param.Find_Region.Y2 = height;
            JJS_HW.HW.HalconWindow.ClearWindow();
            JJS_HW.HW.HalconWindow.DispImage(Image);
            JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
            E_Rect_Col1.Text = string.Format("{0:f3}", Param.Find_Region.X1);
            E_Rect_Row1.Text = string.Format("{0:f3}", Param.Find_Region.Y1);
            E_Rect_Col2.Text = string.Format("{0:f3}", Param.Find_Region.X2);
            E_Rect_Row2.Text = string.Format("{0:f3}", Param.Find_Region.Y2);
        }
        public void Find_Model()
        {
            TFind_Mothed_1_Result find = new TFind_Mothed_1_Result();
            TFind_Mothed_1.Find(Image, Param, ref find);
            Disp_find_Result(find);
        }
        public void Disp_find_Result(TFind_Mothed_1_Result find)
        {
            TFrame_JJS_HW frame;
            string color = "";


            frame = tFrame_JJS_HW1;
            if (find.Find_OK) color = "green";
            else color = "red";
            TFind_Mothed_1.Disp_Message(frame.HW_Buf, find, 20, 20, 20, 1, color);
            TFind_Mothed_1.Disp_XLD(frame.HW_Buf, find, color);
            TFind_Mothed_1.Disp_Hairline(frame.HW_Buf, find, 30, color);
            frame.Copy_HW();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Find_Model();
        }
        private void B_Save_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog dialog = new System.Windows.Forms.SaveFileDialog();

            dialog.Filter = "Param File|*.xml";
            dialog.InitialDirectory = Param.Default_Path;
            dialog.FileName = "default.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Write(dialog.FileName, "default");
            }            
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "Param File|*.xml";
            dialog.InitialDirectory = Param.Default_Path;
            dialog.FileName = "default.xml";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Write(dialog.FileName, "default");
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                    Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    region.GenRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
                    JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                    Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                    JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                    region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step4 Set Find Param
                if (Step >= 4 && flag)
                {
                }
                #endregion

                #region Find Model
                if (Step >= 5 && flag)
                {
                    Find_Model();
                }
                #endregion
                JJS_HW.Copy_HW();
            }
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            Step = 1;
            Update_View();
        }
        private void tabPage3_Enter(object sender, EventArgs e)
        {
            Step = 2;
            Update_View();
        }
        private void tabPage5_Enter(object sender, EventArgs e)
        {
            Step = 3;
            Update_View();
        }
        private void tabPage4_Enter(object sender, EventArgs e)
        {
            Step = 4;
            Update_View();
        }
        private void tabPage6_Enter(object sender, EventArgs e)
        {
            Step = 5;
            Update_View();
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }
        private void B_Select_Center_Click(object sender, EventArgs e)
        {
            double row, col;
            double center_r, center_c;


            JJS_HW.HW.Focus();
            JJS_HW.HW.HalconWindow.DrawPoint(out row, out col);
            center_r = (R1 + R2) / 2;
            center_c = (C1 + C2) / 2;
            Param.JJS_Model.Model.SetShapeModelOrigin(row - center_r, col - center_c);
            Param.JJS_Model.XLD = Param.JJS_Model.Model.GetShapeModelContours(1);
            tFrame_Select_Model1.Set_Model(Param.JJS_Model);
        }
    }
}
