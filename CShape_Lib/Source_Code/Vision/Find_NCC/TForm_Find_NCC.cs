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
using EFC.Tool;
using EFC.INI;
using EFC.CAD;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Find_NCC : Form
    {
        public TFind_NCC_Mothed_Param    Param = new TFind_NCC_Mothed_Param();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;
        public double                    R1, C1, R2, C2;

        private HImage                   Image = new HImage();
        private HImage                   In_Image = new HImage();

        public TForm_Find_NCC()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public void Set_Param(TFind_NCC_Mothed_Param param, HImage image = null)
        {
            Param.Set(param);
            In_Image = image;
            if (JJS_Vision.Is_Not_Empty(image)) Image = In_Image.Clone();

            tFrame_Select_NCC_Model1.Set_Model(Param.JJS_Model);
            tFrame_Create_NCC_Param1.Set_Param(Param.Create_Param);
            tFrame_Find_NCC_Param1.Set_Param(Param.Find_Param);

            CB_Auto_Select_Region.Checked = Param.Auto_Set_Region;
            E_Ofs_X.Text = Param.Ofs_X.ToString();
            E_Ofs_Y.Text = Param.Ofs_Y.ToString();
            Set_Param_Find_Rect();

        }
        public void Set_Param_Find_Rect()
        {
            E_Rect_Col1.Text = string.Format("{0:f1}", Param.Find_Region.X1);
            E_Rect_Row1.Text = string.Format("{0:f1}", Param.Find_Region.Y1);
            E_Rect_Col2.Text = string.Format("{0:f1}", Param.Find_Region.X2);
            E_Rect_Row2.Text = string.Format("{0:f1}", Param.Find_Region.Y2);
        }
        public void Update_Param()
        {

            Param.JJS_Model.Set(tFrame_Select_NCC_Model1.JJS_Model);
            tFrame_Create_NCC_Param1.Get_Param(ref Param.Create_Param);
            tFrame_Find_NCC_Param1.Get_Param(ref Param.Find_Param);

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
            JJS_HW.SetPart(Image);
            JJS_HW.HW_Buf.HalconWindow.DispObj(Image);
            JJS_HW.Copy_HW();
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
            JJS_HW.Mode = emJJS_HW_Mode.None;
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
            Set_Param_Find_Rect();
            B_Rect_Select.Enabled = true;
            B_Rect_Edit.Enabled = true;
            B_Rect_Max.Enabled = true;
       }
        private void B_Select_Rect_Click(object sender, EventArgs e)
        {
            HImage tmp_image = new HImage();

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.None;
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
                Param.JJS_Model.Image = tmp_image.Clone();
                Param.JJS_Model.Model = tmp_image.CreateNccModel(
                                                 Param.Create_Param.NumLevels,
                                                 Param.Create_Param.AngleStart,
                                                 Param.Create_Param.AngleExtent,
                                                 Param.Create_Param.AngleStep,
                                                 Param.Create_Param.Metric);
                tFrame_Select_NCC_Model1.Set_Model(Param.JJS_Model);
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
                    Set_Param_Find_Rect();
                    JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
                }

                if (MessageBox.Show("覆蓋掉原始影像??", "儲存影像", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    if (JJS_Vision.Is_Not_Empty(Image)) Param.Sor_Image = Image.Clone();
                    Param.Write_Sor_Image();
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
            JJS_HW.Mode = emJJS_HW_Mode.None;
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
            Set_Param_Find_Rect();
            B_Rect_Select.Enabled = true;
            B_Rect_Edit.Enabled = true;
            B_Rect_Max.Enabled = true;
        }
        private void B_Rect_Max_Click(object sender, EventArgs e)
        {
            string type;
            int width, height;

            JJS_HW.Mode = emJJS_HW_Mode.None;
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
            Set_Param_Find_Rect();
        }
        public void Find_Model()
        {
            TFind_NCC_Result find_result = new TFind_NCC_Result();
            Param.Find(Image, ref find_result);
            Disp_find_Result(find_result, 1);
        }
        public void Disp_find_Result(TFind_NCC_Result find, double scale)
        {
            find.Display_Model(JJS_HW.HW_Buf, scale);
            find.Display_Message(JJS_HW.HW_Buf, scale);
            JJS_HW.Copy_HW();
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
                JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                JJS_HW.SetPart(Image);
                JJS_HW.HW_Buf.HalconWindow.DispObj(Image);

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
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
            Param.JJS_Model.Model.SetNccModelOrigin(row - center_r, col - center_c);
            tFrame_Select_NCC_Model1.Set_Model(Param.JJS_Model);
        }
        private void B_Used_In_Image_Click(object sender, EventArgs e)
        {
            if (JJS_Vision.Is_Not_Empty(In_Image))
            {
                B_Used_In_Image.BackColor = Color.PaleTurquoise;
                B_Used_Sor_Image.BackColor = Color.Transparent;
                Image = In_Image.Clone();
                Update_View();
            }
        }
        private void B_Used_Sor_Image_Click(object sender, EventArgs e)
        {
            if (JJS_Vision.Is_Not_Empty(Param.Sor_Image))
            {
                B_Used_Sor_Image.BackColor = Color.PaleTurquoise;
                B_Used_In_Image.BackColor = Color.Transparent;
                Image = Param.Sor_Image.Clone();
                Update_View();
            }
        }
    }
    public class TFind_NCC_Mothed_Param : TBase_Param
    {

        public TJJS_NCC_Model          JJS_Model = new TJJS_NCC_Model();
        public bool                    Auto_Set_Region;
        public double                  Ofs_X,
                                       Ofs_Y;
        public TNCC_Create_Param       Create_Param = new TNCC_Create_Param();
        public TNCC_Find_Param         Find_Param = new TNCC_Find_Param();
        public stRect_Double           Find_Region = new stRect_Double();
        public HImage                  Sor_Image = new HImage();
        public string                  Sor_Image_File_Name = "Sor_Image.bmp";

        public TFind_NCC_Mothed_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TFind_NCC_Mothed_Param();
        }
        override public TBase_Result New_Base_Result()
        {
            return new TFind_NCC_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_NCC_Mothed_Param && dis_base is TFind_NCC_Mothed_Param)
            {
                TFind_NCC_Mothed_Param sor = (TFind_NCC_Mothed_Param)sor_base;
                TFind_NCC_Mothed_Param dis = (TFind_NCC_Mothed_Param)dis_base;
                base.Copy(sor, dis);

                dis.Auto_Set_Region = sor.Auto_Set_Region;
                dis.Ofs_X = sor.Ofs_X;
                dis.Ofs_Y = sor.Ofs_Y;

                dis.JJS_Model.Set(sor.JJS_Model);
                dis.Create_Param.Set(sor.Create_Param);
                dis.Find_Param.Set(sor.Find_Param);
                dis.Find_Region = sor.Find_Region;
                if (JJS_Vision.Is_Not_Empty(sor.Sor_Image)) dis.Sor_Image = sor.Sor_Image.Clone();
                dis.Sor_Image_File_Name = sor.Sor_Image_File_Name;
            }
        }
 
        override public void Set_Default()
        {
            base.Set_Default();
            Auto_Set_Region = false;
            Ofs_X = 100;
            Ofs_Y = 100;
            Find_Region.X1 = 0;
            Find_Region.Y1 = 0;
            Find_Region.X2 = 0;
            Find_Region.Y2 = 0;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                base.Read(ini, section);
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");
                Auto_Set_Region = ini.ReadBool(tmp_section, "Auto_Set_Region", true);
                Ofs_X = ini.ReadFloat(tmp_section, "Ofs_X", 50);
                Ofs_Y = ini.ReadFloat(tmp_section, "Ofs_Y", 50);
                     
                Create_Param.Read(ini, tmp_section + "/Create_Param");
                Find_Param.Read(ini, tmp_section + "/Find_Param");

                Find_Region.X1 = ini.ReadFloat(tmp_section, "Find_Region_X1", 0.0);
                Find_Region.Y1 = ini.ReadFloat(tmp_section, "Find_Region_Y1", 0.0);
                Find_Region.X2 = ini.ReadFloat(tmp_section, "Find_Region_X2", 0.0);
                Find_Region.Y2 = ini.ReadFloat(tmp_section, "Find_Region_Y2", 0.0);
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                base.Write(ini, section);
                ini.WriteString(tmp_section, "Info", Info);
                ini.WriteBool(tmp_section, "Auto_Set_Region", Auto_Set_Region);
                ini.WriteFloat(tmp_section, "Ofs_X", Ofs_X);
                ini.WriteFloat(tmp_section, "Ofs_Y", Ofs_Y);

                Create_Param.Write(ini, tmp_section + "/Create_Param");
                Find_Param.Write(ini, tmp_section + "/Find_Param");

                ini.WriteFloat(tmp_section, "Find_Region_X1", Find_Region.X1);
                ini.WriteFloat(tmp_section, "Find_Region_Y1", Find_Region.Y1);
                ini.WriteFloat(tmp_section, "Find_Region_X2", Find_Region.X2);
                ini.WriteFloat(tmp_section, "Find_Region_Y2", Find_Region.Y2);
            }
        }
        override public void Read_Other_File()
        {
            JJS_Model.Read();
            string filename = Default_Path + Sor_Image_File_Name;
            if (System.IO.File.Exists(filename)) Sor_Image.ReadImage(filename);
        }
        override public void Write_Other_File()
        {
            if (Default_Path != "")
            {
                System.IO.Directory.CreateDirectory(JJS_Model.Default_Path);
                JJS_Model.Write();
            }
        }
        public void Log_Diff(TLog log, string section, TFind_NCC_Mothed_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Info", Info, new_value.Info, ref flag);
            log.Log_Diff(section + "/Auto_Set_Region", Auto_Set_Region, new_value.Auto_Set_Region, ref flag);
            log.Log_Diff(section + "/Ofs_X", Ofs_X, new_value.Ofs_X, ref flag);
            log.Log_Diff(section + "/Ofs_Y", Ofs_Y, new_value.Ofs_Y, ref flag);

            Create_Param.Log_Diff(log, section + "/Create_Param", new_value.Create_Param, ref flag);
            Find_Param.Log_Diff(log, section + "/Find_Param", new_value.Find_Param, ref flag);

            log.Log_Diff(section + "/Find_Region.X1", Find_Region.X1, new_value.Find_Region.X1, ref flag);
            log.Log_Diff(section + "/Find_Region.Y1", Find_Region.Y1, new_value.Find_Region.Y1, ref flag);
            log.Log_Diff(section + "/Find_Region.X2", Find_Region.X2, new_value.Find_Region.X2, ref flag);
            log.Log_Diff(section + "/Find_Region.Y2", Find_Region.Y2, new_value.Find_Region.Y2, ref flag);
        }
        public void Write_Sor_Image()
        {
            if (JJS_Vision.Is_Not_Empty(Sor_Image))
            {
                string filename = Default_Path + Sor_Image_File_Name;
                Sor_Image.WriteImage("bmp", 1, filename);
            }
        }
       
        
        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Find_NCC form = new TForm_Find_NCC();
            form.Set_Param(this, image);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        public override bool Find_Base(HImage image, ref TBase_Result f_result)
        {
            bool result = false;
            TFind_NCC_Result in_result = (TFind_NCC_Result)f_result;

            result = Find(image, ref in_result);
            return result;
        }
        public bool Find_Base(HImage image, ref TFind_NCC_Result f_result)
        {
            bool result = false;

            result = Find(image, ref f_result);
            return result;
        }

        public bool Find(HImage image, ref TFind_NCC_Result result_data, bool border_shape = true)
        {
            return Find(image, Find_Region, ref result_data, border_shape);
        }
        public bool Find(HImage image, stRect_Double find_region, ref TFind_NCC_Result result_data, bool border_shape = true)
        {
            HImage tmp_image = new HImage();
            HTuple row, col, angle,  score;
            int r1, c1, r2, c2;
            int width, height;

            result_data.Reset();
            if (!JJS_Vision.Is_Empty(image))
            {
                try
                {
                    if (border_shape) HSystem.SetSystem("border_shape_models", "true");
                    else HSystem.SetSystem("border_shape_models", "false");

                    image.GetImageSize(out width, out height);
                    tmp_image = new HImage();
                    c1 = (int)find_region.X1;
                    r1 = (int)find_region.Y1;
                    c2 = (int)find_region.X2;
                    r2 = (int)find_region.Y2;
                    tmp_image = image.Rectangle1Domain(r1, c1, r2, c2);
                    tmp_image = tmp_image.CropDomain();

                    result_data.JJS_Model.Set(JJS_Model);
                    result_data.Find_Region = find_region;
                    if (JJS_Vision.Is_Not_Empty(JJS_Model.Model))
                    {
                        tmp_image.FindNccModel(
                                                   JJS_Model.Model,
                                                   Find_Param.AngleStart,
                                                   Find_Param.AngleExtent,
                                                   Find_Param.MinScore,
                                                   Find_Param.NumMatches,
                                                   Find_Param.MaxOverlap,
                                                   Find_Param.SubPixel,
                                                   Find_Param.NumLevels,
                                                   out row,
                                                   out col,
                                                   out angle,
                                                   out score);

                        if (row.Length == 1)
                        {
                            result_data.Row = row + r1;
                            result_data.Col = col + c1;
                            result_data.Angle = angle;
                            result_data.Score = score;
                            result_data.Find_OK = true;
                        }
                    }
                }
                catch { };
            }

            return result_data.Find_OK;
        }
    }
    public class TFind_NCC_Result : TBase_Result
    {
        public TJJS_NCC_Model          JJS_Model = new TJJS_NCC_Model();
        public double                  Angle,
                                       Score;

        public stRect_Double           Find_Region;


        public TFind_NCC_Result()
        {
             Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TFind_NCC_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_NCC_Result && dis_base is TFind_NCC_Result)
            {
                base.Copy(sor_base, dis_base);
                TFind_NCC_Result sor = (TFind_NCC_Result)sor_base;
                TFind_NCC_Result dis = (TFind_NCC_Result)dis_base;

                dis.JJS_Model.Set(sor.JJS_Model);
                dis.Find_OK = sor.Find_OK;
                dis.Col = sor.Col;
                dis.Row = sor.Row;
                dis.Angle = sor.Angle;
                dis.Score = sor.Score;

                dis.Find_Region = sor.Find_Region;
            }
        }

        override public void Set_Default()
        {
            base.Set_Default();
            Find_OK = false;
            Col = 0;
            Row = 0;
            Angle = 0;
            Score = 0;

            Find_Region.X1 = 0;
            Find_Region.Y1 = 0;
            Find_Region.X2 = 0;
            Find_Region.Y2 = 0;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Find_OK = ini.ReadBool(tmp_section, "Find_Ok", false);
                Col = ini.ReadFloat(tmp_section, "Col", 0.0);
                Row = ini.ReadFloat(tmp_section, "Row", 0.0);
                Angle = ini.ReadFloat(tmp_section, "Angle", 0.0);
                Score = ini.ReadFloat(tmp_section, "Score", 0.0);

                Find_Region.X1 = ini.ReadFloat(tmp_section, "Find_Region_X1", 0.0);
                Find_Region.Y1 = ini.ReadFloat(tmp_section, "Find_Region_Y1", 0.0);
                Find_Region.X2 = ini.ReadFloat(tmp_section, "Find_Region_X2", 0.0);
                Find_Region.Y2 = ini.ReadFloat(tmp_section, "Find_Region_Y2", 0.0);
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteBool(tmp_section, "Find_Ok", Find_OK);
                ini.WriteFloat(tmp_section, "Col", Col);
                ini.WriteFloat(tmp_section, "Row", Row);
                ini.WriteFloat(tmp_section, "Angle", Angle);
                ini.WriteFloat(tmp_section, "Score", Score);

                ini.WriteFloat(tmp_section, "Find_Region_X1", Find_Region.X1);
                ini.WriteFloat(tmp_section, "Find_Region_Y1", Find_Region.Y1);
                ini.WriteFloat(tmp_section, "Find_Region_X2", Find_Region.X2);
                ini.WriteFloat(tmp_section, "Find_Region_Y2", Find_Region.Y2);
            }
        }
        override public void Read_Other_File() 
        {
        }
        override public void Write_Other_File()
        {

        }


        override public void Reset()
        {
            Find_OK = false;
            Col = 0;
            Row = 0;
            Angle = 0;
            Score = 0;
        }
        override public void Display_Message(HWindowControl hw, double scale)
        {
            string color;

            if (Find_OK) color = Msg_Color_OK;
            else color = Msg_Color_NG;

            Msg_Scale = scale;
            JJS_Vision.Display_String(hw, Get_Message(), Msg_X * Msg_Scale, Msg_Y * Msg_Scale, Msg_Font_Size * Msg_Scale, 1, color);
        }
        override public void Display_Model(HWindowControl hw, double scale)
        {
            string color;

            if (Find_OK) color = Model_Color_OK;
            else color = Model_Color_NG;

            if (Find_OK)
            {
                hw.HalconWindow.SetLineWidth((int)Line_Width);
                //JJS_Vision.Display_Model_XLD(hw, Col, Row, Angle, JJS_Model.XLD, color);
                JJS_Vision.Display_Hairline(hw, Col, Row, Hairline_Size, 0, "yellow");
            }
        }
        override public string Get_Message()
        {
            string result = "";

            result = string.Format("{0:s} Col={1:f2} Row={2:f2} Angle={3:f3} Score={4:f3} {5:s}",
                                   Msg_Name, Col, Row, Angle, Score, Find_OK ? "OK" : "NG");
            return result;
        }
    }
    public class TNCC_Create_Param : TBase_Class
    {
        public int NumLevels;
        public double AngleStart;
        public double AngleExtent;
        public double AngleStep;
        public string Metric;
        
        public TNCC_Create_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Class result = new TNCC_Create_Param();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TNCC_Create_Param && dis_base is TNCC_Create_Param)
            {
                TNCC_Create_Param sor = (TNCC_Create_Param)sor_base;
                TNCC_Create_Param dis = (TNCC_Create_Param)dis_base;

                dis.NumLevels = sor.NumLevels;
                dis.AngleStart = sor.AngleStart;
                dis.AngleExtent = sor.AngleExtent;
                dis.AngleStep = sor.AngleStep;
                dis.Metric = sor.Metric;
            }
        }

        public void Set_Default()
        {
            NumLevels = 0;
            AngleStart = -0.2;
            AngleExtent = 0.39;
            AngleStep = 0.0;
            Metric = "use_polarity";
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
                Metric = ini.ReadString(tmp_section, "Metric", "use_polarity");
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
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TNCC_Create_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/NumLevels", NumLevels, new_value.NumLevels, ref flag);
            log.Log_Diff(section + "/AngleStart", AngleStart, new_value.AngleStart, ref flag);
            log.Log_Diff(section + "/AngleExtent", AngleExtent, new_value.AngleExtent, ref flag);
            log.Log_Diff(section + "/AngleStep", AngleStep, new_value.AngleStep, ref flag);
            log.Log_Diff(section + "/Metric", Metric, new_value.Metric, ref flag);
        }
    }
    public class TNCC_Find_Param : TBase_Class
    {
        public double                AngleStart;
        public double                AngleExtent;
        public double                MinScore;
        public int                   NumMatches;
        public double                MaxOverlap;
        public string                SubPixel;
        public int                   NumLevels;

        public TNCC_Find_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return  new TNCC_Find_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TNCC_Find_Param && dis_base is TNCC_Find_Param)
            {
                TNCC_Find_Param sor = (TNCC_Find_Param)sor_base;
                TNCC_Find_Param dis = (TNCC_Find_Param)dis_base;

                dis.AngleStart = sor.AngleStart;
                dis.AngleExtent = sor.AngleExtent;
                dis.MinScore = sor.MinScore;
                dis.NumMatches = sor.NumMatches;
                dis.MaxOverlap = sor.MaxOverlap;
                dis.SubPixel = sor.SubPixel;
                dis.NumLevels = sor.NumLevels;
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
            SubPixel = "true";
        }
        public void Read(TJJS_XML_File ini, string section)
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
            }
        }
        public void Write(TJJS_XML_File ini, string section)
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
            }
        }
        public void Log_Diff(TLog log, string section, TNCC_Find_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/AngleStart", AngleStart, new_value.AngleStart, ref flag);
            log.Log_Diff(section + "/AngleExtent", AngleExtent, new_value.AngleExtent, ref flag);
            log.Log_Diff(section + "/MinScore", MinScore, new_value.MinScore, ref flag);
            log.Log_Diff(section + "/NumMatches", NumMatches, new_value.NumMatches, ref flag);
            log.Log_Diff(section + "/MaxOverlap", MaxOverlap, new_value.MaxOverlap, ref flag);
            log.Log_Diff(section + "/SubPixel", SubPixel, new_value.SubPixel, ref flag);
            log.Log_Diff(section + "/NumLevels", NumLevels, new_value.NumLevels, ref flag);
        }
    }
}
