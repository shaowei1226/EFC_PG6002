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
    public partial class TForm_Find_Mothed_1 : Form
    {
        public TFind_Mothed_1_Param      Param = new TFind_Mothed_1_Param();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;
        public double                    R1, C1, R2, C2;

        private HImage                   Show_Image = null;
        private HImage                   Sample_Image = new HImage();


        public TForm_Find_Mothed_1()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            JJS_HW.Init();
        }
        public int Image_Width
        {
            get
            {
                int w = 640, h = 480;
                if (JJS_Vision.Is_Not_Empty(Show_Image)) Show_Image.GetImageSize(out w, out h);
                return w;
            }
        }
        public int Image_Height
        {
            get
            {
                int w = 640, h = 480;
                if (JJS_Vision.Is_Not_Empty(Show_Image)) Show_Image.GetImageSize(out w, out h);
                return h;
            }
        }
        public void Set_Param(TFind_Mothed_1_Param param, HImage image = null)
        {
            Param.Set(param);
            if (JJS_Vision.Is_Not_Empty(image))
            {
                Sample_Image = image.Clone();
            } 
            Set_Param();
        }
        public void Set_Param()
        {
            Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Param.Sor_Image), Color.PaleTurquoise, Color.Transparent);
            Form_Tool.Set_Button_Face(B_Sample_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.PaleTurquoise, Color.Transparent);

            if (RB_Sor_Base_Image.Checked) Show_Image = Param.Sor_Image;
            if (RB_Sor_Sample_Image.Checked) Show_Image = Sample_Image;

            JJS_HW.SetPart(Show_Image);

            tFrame_Select_Model1.Set_Model(Param.JJS_Model);
            tFrame_Create_Param1.Set_Param(Param.Create_Param);
            tFrame_Find_Param1.Set_Param(Param.Find_Param);

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

            Param.JJS_Model.Set(tFrame_Select_Model1.JJS_Model);
            tFrame_Create_Param1.Get_Param(ref Param.Create_Param);
            tFrame_Find_Param1.Get_Param(ref Param.Find_Param);

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
            Disp_Image(JJS_HW.HW_Buf, Sample_Image);
            JJS_HW.Copy_HW();
            JJS_HW.HW_Param.Set_Line_Width(JJS_HW.HW.Width, Image_Width, 2);
            JJS_HW.Zoom_Windows_Fit();
        }
        public void Disp_Image(HWindowControl hw, HImage image, bool clear_flag = true)
        {
            if (clear_flag) hw.HalconWindow.ClearWindow();
            if (JJS_Vision.Is_Not_Empty(image))
            {
                JJS_HW.SetPart(image);
                hw.HalconWindow.DispObj(image);
            }
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
            B_Rect_Select.Enabled = false;
            B_Rect_Edit.Enabled = false;
            B_Rect_Max.Enabled = false;


            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.None;
            Disp_Image(JJS_HW.HW, Show_Image);

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
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

            tmp_image = Show_Image;
            B_Select_Rect.Enabled = false;
            B_Select_Center.Enabled = false;

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.None;
            try
            {
                Disp_Image(JJS_HW.HW, tmp_image);
                JJS_HW.HW.HalconWindow.SetColor("red");
                JJS_HW.HW.HalconWindow.SetDraw("margin");
                JJS_HW.HW.HalconWindow.SetTposition(10, 10);
                JJS_HW.HW.HalconWindow.WriteString("請圈選畫面標把區域,按滑鼠右鍵結束輸入.");
                JJS_HW.HW.Focus();
                JJS_HW.HW.HalconWindow.DrawRectangle1(out R1, out C1, out R2, out C2);
                JJS_HW.HW.HalconWindow.DispRectangle1(R1, C1, R2, C2);
                tmp_image = tmp_image.Rectangle1Domain((int)R1, (int)C1, (int)R2, (int)C2);
                tmp_image = tmp_image.CropDomain();
                Param.JJS_Model.Model = tmp_image.CreateScaledShapeModel(
                                                 Param.Create_Param.NumLevels,
                                                 Param.Create_Param.AngleStart,
                                                 Param.Create_Param.AngleExtent,
                                                 Param.Create_Param.AngleStep,
                                                 Param.Create_Param.ScaleMin,
                                                 Param.Create_Param.ScaleMax,
                                                 Param.Create_Param.ScaleStep,
                                                 Param.Create_Param.Optimization,
                                                 Param.Create_Param.Metric,
                                                 Param.Create_Param.Contrast,
                                                 Param.Create_Param.MinContrast);
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
                    Set_Param_Find_Rect();
                    JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Model建立發生錯誤.\r\n" + ex.Message, "儲存影像", MessageBoxButtons.OK);
            }

            B_Select_Rect.Enabled = true;
            B_Select_Center.Enabled = true;
        }
        private void B_Rect_Edit_Click(object sender, EventArgs e)
        {
            HImage tmp_image = new HImage();

            tmp_image = Show_Image;
            B_Rect_Select.Enabled = false;
            B_Rect_Edit.Enabled = false;
            B_Rect_Max.Enabled = false;

            Update_Param();
            JJS_HW.Mode = emJJS_HW_Mode.None;
            Disp_Image(JJS_HW.HW, tmp_image);

            JJS_HW.HW.HalconWindow.SetColor("red");
            JJS_HW.HW.HalconWindow.SetDraw("margin");
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
            HImage tmp_image = new HImage();

            tmp_image = Show_Image;
            if (JJS_Vision.Is_Not_Empty(tmp_image))
            {
                JJS_HW.Mode = emJJS_HW_Mode.None;
                Param.Find_Region.X1 = 0;
                Param.Find_Region.Y1 = 0;
                Param.Find_Region.X2 = Image_Width;
                Param.Find_Region.Y2 = Image_Height;

                JJS_HW.HW.HalconWindow.SetColor("red");
                JJS_HW.HW.HalconWindow.SetDraw("margin");
                Disp_Image(JJS_HW.HW, tmp_image);

                JJS_HW.HW.HalconWindow.DispRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
                Set_Param_Find_Rect();
            }
        }
        public void Find_Model()
        {
            TFind_Mothed_1_Result find_result = new TFind_Mothed_1_Result();
            Param.Find(Show_Image, ref find_result);
            Disp_find_Result(find_result);
        }
        public void Disp_find_Result(TFind_Mothed_1_Result find)
        {
            double scale = (double)Image_Width / JJS_HW.HW.Width;

            Disp_Image(JJS_HW.HW_Buf, Show_Image);
            find.Disp_Param.Msg_X = 50 * scale;
            find.Disp_Param.Msg_Y = 50 * scale;
            find.Disp_Param.Msg_Font_Size = 20 * scale;
            find.Display_Model(JJS_HW.HW_Buf);
            find.Display_Message(JJS_HW.HW_Buf);
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
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                if (Step == 0) Disp_Image(JJS_HW.HW_Buf, Show_Image, true);

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    if (Step == 1) Disp_Image(JJS_HW.HW_Buf, Show_Image, true);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    if (Step == 2) Disp_Image(JJS_HW.HW_Buf, Show_Image, true);
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        region.GenRectangle1(Param.Find_Region.Y1, Param.Find_Region.X1, Param.Find_Region.Y2, Param.Find_Region.X2);
                        Disp_Image(JJS_HW.HW_Buf, Show_Image, true);
                        JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                        JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                        region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    }
                }
                #endregion

                #region Step4 Set Find Param
                if (Step >= 4 && flag)
                {
                    if (Step == 4) Disp_Image(JJS_HW.HW_Buf, Show_Image, true);
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
        private void B_Select_Center_Click(object sender, EventArgs e)
        {
            double row, col;
            double center_r, center_c;

            B_Select_Rect.Enabled = false;
            B_Select_Center.Enabled = false;

            JJS_HW.HW.Focus();
            JJS_HW.Get_Point(out col, out row);
            //JJS_HW.HW.HalconWindow.DrawPoint(out row, out col);
            center_r = (R1 + R2) / 2;
            center_c = (C1 + C2) / 2;
            Param.JJS_Model.Model.SetShapeModelOrigin(row - center_r, col - center_c);
            Param.JJS_Model.XLD = Param.JJS_Model.Model.GetShapeModelContours(1);
            tFrame_Select_Model1.Set_Model(Param.JJS_Model);

            B_Select_Rect.Enabled = true;
            B_Select_Center.Enabled = true;
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Disp_Image(JJS_HW.HW_Buf, Param.Sor_Image, true);
            JJS_HW.Copy_HW();
        }
        private void B_Sample_Image_Click(object sender, EventArgs e)
        {
            Disp_Image(JJS_HW.HW_Buf, Sample_Image, true);
            JJS_HW.Copy_HW();
        }
        private void B_Select_Base_File_Click(object sender, EventArgs e)
        {
            HImage image = Param.Sor_Image;
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.InitialDirectory = Param.Default_Path;
            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Base_Image_File_Name.Text = dialog.FileName;
                image.ReadImage(E_Base_Image_File_Name.Text);
                Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.PaleTurquoise, Color.Transparent);

                Disp_Image(JJS_HW.HW_Buf, image);
                JJS_HW.Copy_HW();
            }
        }
        private void B_Select_Sample_File_Click(object sender, EventArgs e)
        {
            HImage image = Sample_Image;
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.InitialDirectory = Param.Default_Path;
            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Sample_Image_File_Name.Text = dialog.FileName;
                image.ReadImage(E_Sample_Image_File_Name.Text);
                Form_Tool.Set_Button_Face(B_Sample_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.PaleTurquoise, Color.Transparent);

                Disp_Image(JJS_HW.HW_Buf, image);
                JJS_HW.Copy_HW();
            }
        }
        private void RB_Sor_Base_Image_CheckedChanged(object sender, EventArgs e)
        {
            Show_Image = Param.Sor_Image;
            Update_View();
        }
        private void RB_Sor_Sample_Image_CheckedChanged(object sender, EventArgs e)
        {
            Show_Image = Sample_Image;
            Update_View();
        }
        private void B_Save_Base_Image_Click(object sender, EventArgs e)
        {
            JJS_Vision.Copy_Obj(Sample_Image, ref Param.Sor_Image);
            Param.Write_Sor_Image();
            Set_Param();
        }
    }
    public class TFind_Mothed_1_Param : TBase_Param
    {
          
        public TJJS_ShapeModel             JJS_Model = new TJJS_ShapeModel();
        public bool                        Auto_Set_Region;
        public double                      Ofs_X,
                                           Ofs_Y;
        public TCreate_Param               Create_Param = new TCreate_Param();
        public TFind_Param                 Find_Param = new TFind_Param();
        public stRect_Double               Find_Region = new stRect_Double();
        public HImage                      Sor_Image = new HImage();
        public string                      Sor_Image_File_Name = "Sor_Image.bmp";

        
        public TFind_Mothed_1_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Class result = new TFind_Mothed_1_Param();
            return result;
        }
        override public TBase_Result New_Base_Result()
        {
            TBase_Result result = null;
            result = new TFind_Mothed_1_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Mothed_1_Param && dis_base is TFind_Mothed_1_Param)
            {
                TFind_Mothed_1_Param sor = (TFind_Mothed_1_Param)sor_base;
                TFind_Mothed_1_Param dis = (TFind_Mothed_1_Param)dis_base;
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
            JJS_Model.Default_FileName = "Model.mod";
        }
        override public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            JJS_Model.Default_Path = Default_Path;
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
                Read_Other_File();
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
                Write_Other_File();
            }
        }
        override public void Read_Other_File()
        {
            JJS_Model.Read(JJS_Model.Default_Path + JJS_Model.Default_FileName);

            string filename = JJS_Model.Default_Path + Sor_Image_File_Name;
            if (System.IO.File.Exists(filename)) Sor_Image.ReadImage(filename);
        }
        override public void Write_Other_File()
        {
            if (JJS_Model.Default_Path != "")
            {
                System.IO.Directory.CreateDirectory(JJS_Model.Default_Path);
                JJS_Model.Write(JJS_Model.Default_Path + JJS_Model.Default_FileName);
            }
        }
        public void Log_Diff(TLog log, string section, TFind_Mothed_1_Param new_value, ref bool flag)
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
                string filename = JJS_Model.Default_Path + Sor_Image_File_Name;
                JJS_Vision.Write_File(Sor_Image, filename);
            }
        }
       
        
        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Find_Mothed_1 form = new TForm_Find_Mothed_1();
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
            TFind_Mothed_1_Result in_result = (TFind_Mothed_1_Result)f_result;

            result = Find(image, ref in_result);
            return result;
        }
        public bool Find_Base(HImage image, ref TFind_Mothed_1_Result f_result)
        {
            bool result = false;

            result = Find(image, ref f_result);
            return result;
        }

        public bool Find(HImage image, ref TFind_Mothed_1_Result result_data, bool border_shape = true)
        {
            return Find(image, Find_Region, ref result_data, border_shape);
        }
        public bool Find(HImage image, stRect_Double find_region, ref TFind_Mothed_1_Result result_data, bool border_shape = true)
        {
            HImage tmp_image = new HImage();
            HTuple row, col, angle, scale, score;
            int r1, c1, r2, c2;
            int width, height;

            result_data.Reset();
            if (JJS_Vision.Is_Not_Empty(image))
            {
                try
                {
                    JJS_Vision.Copy_Obj(image, ref result_data.Sample_Image);
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
                    if (!JJS_Vision.Is_Empty(JJS_Model.Model))
                    {
                        tmp_image.FindScaledShapeModel(
                                                   JJS_Model.Model,
                                                   Find_Param.AngleStart,
                                                   Find_Param.AngleExtent,
                                                   Find_Param.ScaleMin,
                                                   Find_Param.ScaleMax,
                                                   Find_Param.MinScore,
                                                   Find_Param.NumMatches,
                                                   Find_Param.MaxOverlap,
                                                   Find_Param.SubPixel,
                                                   Find_Param.NumLevels,
                                                   Find_Param.Greediness,
                                                   out row,
                                                   out col,
                                                   out angle,
                                                   out scale,
                                                   out score);

                        if (row.Length == 1)
                        {
                            result_data.Row = row + r1;
                            result_data.Col = col + c1;
                            result_data.Angle = angle;
                            result_data.Scale = scale;
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
    public class TFind_Mothed_1_Result : TBase_Result
    {
        public TJJS_ShapeModel           JJS_Model = new TJJS_ShapeModel();
        public double                    Col, 
                                         Row;
        public double                    Angle,
                                         Scale,
                                         Score;
        public HImage                    Sample_Image = null;        
                          
        public stRect_Double             Find_Region;
        public TBase_Disp_Param          Disp_Param = new TBase_Disp_Param();

        public TFind_Mothed_1_Result()
        {
             Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TFind_Mothed_1_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Mothed_1_Result && dis_base is TFind_Mothed_1_Result)
            {
                base.Copy(sor_base, dis_base);
                TFind_Mothed_1_Result sor = (TFind_Mothed_1_Result)sor_base;
                TFind_Mothed_1_Result dis = (TFind_Mothed_1_Result)dis_base;

                dis.JJS_Model.Set(sor.JJS_Model);
                dis.Find_OK = sor.Find_OK;
                dis.Col = sor.Col;
                dis.Row = sor.Row;
                dis.Angle = sor.Angle;
                dis.Scale = sor.Scale;
                dis.Score = sor.Score;

             
                dis.Find_Region = sor.Find_Region;
                dis.Disp_Param.Set(sor.Disp_Param);
            }
        }

        override public void Set_Default()
        {
            base.Set_Default();
            Find_OK = false;
            Col = 0;
            Row = 0;
            Angle = 0;
            Scale = 1;
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
                Scale = ini.ReadFloat(tmp_section, "Scale", 0.0);
                Score = ini.ReadFloat(tmp_section, "Score", 0.0);

                Find_Region.X1 = ini.ReadFloat(tmp_section, "Find_Region_X1", 0.0);
                Find_Region.Y1 = ini.ReadFloat(tmp_section, "Find_Region_Y1", 0.0);
                Find_Region.X2 = ini.ReadFloat(tmp_section, "Find_Region_X2", 0.0);
                Find_Region.Y2 = ini.ReadFloat(tmp_section, "Find_Region_Y2", 0.0);
                Disp_Param.Read(ini, "/Disp_Param");
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
                ini.WriteFloat(tmp_section, "Scale", Scale);
                ini.WriteFloat(tmp_section, "Score", Score);

                ini.WriteFloat(tmp_section, "Find_Region_X1", Find_Region.X1);
                ini.WriteFloat(tmp_section, "Find_Region_Y1", Find_Region.Y1);
                ini.WriteFloat(tmp_section, "Find_Region_X2", Find_Region.X2);
                ini.WriteFloat(tmp_section, "Find_Region_Y2", Find_Region.Y2);
                Disp_Param.Write(ini, "/Disp_Param");
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
        override public void Display_Message(HWindowControl hw)
        {
            string color;

            if (Find_OK) color = Disp_Param.Msg_Color_OK;
            else color = Disp_Param.Msg_Color_NG;

            JJS_Vision.Display_String(hw, Get_Message(), Disp_Param.Msg_X, Disp_Param.Msg_Y, Disp_Param.Msg_Font_Size, Disp_Param.Scale, color);
        }
        override public void Display_Model(HWindowControl hw)
        {
            string color;

            if (Find_OK) color = Disp_Param.Model_Color_OK;
            else color = Disp_Param.Model_Color_NG;

            if (Find_OK)
            {
                hw.HalconWindow.SetLineWidth((int)(Disp_Param.Line_Width * Disp_Param.Scale));
                JJS_Vision.Display_Model_XLD(hw, Col, Row, Angle, JJS_Model.XLD, color);
                JJS_Vision.Display_Hairline(hw, Col, Row, Disp_Param.Hairline_Size, 0, "yellow");
            }
        }
        override public string Get_Message()
        {
            string result = "";

            result = string.Format("{0:s} Col={1:f1} Row={2:f1} Score={3:f3} Scale={4:f1} {5:s}",
                                   Disp_Param.Msg_Name, Col, Row, Score, Scale, Find_OK ? "OK" : "NG");
            return result;
        }


        public void Get_Find_Region(ref HRegion out_region)
        {
            HXLDCont xld = new HXLDCont();
            HRegion region = new HRegion();
            double row = 0, column = 0, phi = 0, length1 = 0, length2 = 0;

            if (Find_OK)
            {
                xld = JJS_Vision.Affine_Trans_XLD(JJS_Model.XLD, 0, 0, 0, Col, Row, Angle);
                region = JJS_Vision.XLD_To_Region(xld);
                region = region.Union1();
                region.SmallestRectangle2(out row, out column, out phi, out length1, out length2);
                region.GenRectangle2(row, column, phi, length1, length2);
                out_region = region.Clone();
            }
            xld.Dispose();
            region.Dispose();
        }
    }
}
