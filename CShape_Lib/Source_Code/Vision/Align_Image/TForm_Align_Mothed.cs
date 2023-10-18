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


namespace EFC.Vision.Halcon
{
    public partial class TForm_Align_Mothed : Form
    {
        public string Default_Path;
        public HImage Image1 = new HImage();
        public HImage Image2 = new HImage();
        public TAlign_Mothed_1_Param Param = new TAlign_Mothed_1_Param();
        public TAlign_Mothed_1_Result Result = new TAlign_Mothed_1_Result();
        public stJJS_HW_Info JJS_HW;
        public int Step = 0;

        public TForm_Align_Mothed()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1.JJS_HW;
        }
        private void TForm_Align_Mothed_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (!TJJS_Vision.Is_Empty(Image1)) B_Base_Image.BackColor = Color.LightGreen;
            if (!TJJS_Vision.Is_Empty(Image2)) B_Trans_Image.BackColor = Color.LightGreen;
            Draw_Image(Image1);
            treeView1.TopNode.Expand();
        }
        public void Set_Param(TAlign_Mothed_1_Param param)
        {
            Param = param.Copy();
            E_Sigma_Grad.Text = Param.Sigma_Grad.ToString();
            E_Sigma_Smooth.Text = Param.Sigma_Smooth.ToString();
            E_Alpha.Text = Param.Alpha.ToString();
            E_Point_Num.Text = Param.Point_Num.ToString();
        }
        public void Update_Param()
        {
            Param.Sigma_Grad = Convert.ToDouble(E_Sigma_Grad.Text);
            Param.Sigma_Smooth = Convert.ToDouble(E_Sigma_Smooth.Text);
            Param.Alpha = Convert.ToDouble(E_Alpha.Text);
            Param.Point_Num = Convert.ToDouble(E_Point_Num.Text);
        }
        public void Draw_Image(HImage image)
        {
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            try
            {
                if (image != null)
                {
                    JJS_HW.SetPart(image);
                    JJS_HW.HW_Buf.HalconWindow.DispObj(image);
                }
            }
            catch
            {

            }
            JJS_HW.Copy_HW();
        }
        public void Draw_Region(HRegion region)
        {
            Draw_Image(Image1);
            try
            {
                if (region != null)
                {
                    JJS_HW.HW.HalconWindow.SetColored(12);
                    JJS_HW.HW.HalconWindow.SetLineWidth(2);
                    JJS_HW.HW.HalconWindow.SetDraw("margin");
                    JJS_HW.HW.HalconWindow.SetColor("red");
                    region.DispObj(JJS_HW.HW.HalconWindow);
                }
            }
            catch
            {
            }
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void B_Trans_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Out_Image_Click(object sender, EventArgs e)
        {
        }
        private void B_Select_Base_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "BMP File|*.bmp|JPG File|*.jpg";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Base_Image_File.Text = dialog.FileName;
                Image1.ReadImage(E_Base_Image_File.Text);
                B_Base_Image.BackColor = Color.LightGreen;
                Draw_Image(Image1);
            }
        }
        private void B_Select_Trans_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "BMP File|*.bmp|JPG File|*.jpg";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Trans_Image_File.Text = dialog.FileName;
                Image2.ReadImage(E_Trans_Image_File.Text);
                B_Trans_Image.BackColor = Color.LightGreen;
                Draw_Image(Image2);
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HImage image1 = new HImage();
            HImage image2 = new HImage();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                if (TJJS_Vision.Is_Empty(Image1))
                    flag = false;

                //if (TJJS_Vision.Is_Empty(Image2))
                //    flag = false;

                #region Step1 display image
                if (Step >= 1 && flag)
                {
                    image1 = Image1.Clone();
                    if (!TJJS_Vision.Is_Empty(Image2)) image2 = Image1.Clone();
                    image1.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Test Region
                if (Step >= 2 && flag)
                {
                }
                #endregion

                #region Step3 display sub image
                if (Step >= 3 && flag)
                {
                    TAlign_Mothed_1.Trans(Image1, Image2, Param, ref Result);
                    if (RB_Base_Image.Checked)
                    {
                        image1.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                        Param.Test_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        Result.Draw_Point1(JJS_HW.HW_Buf);
                    }
                    else
                    {
                        image2.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                        Param.Test_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        Result.Draw_Point2(JJS_HW.HW_Buf);
                    }
                }
                #endregion

                #region Step4 Display result image
                if (Step >= 4 && flag)
                {
                    Draw_Image(Result.Image);
                }
                #endregion
                JJS_HW.Copy_HW();
            }
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
        }
        private void B_Update_Click(object sender, EventArgs e)
        {
            Update_View();
        }
        private void tabPage2_Enter(object sender, EventArgs e)
        {
            Step = 1;
            Update_View();
        }
        private void tabPage5_Enter(object sender, EventArgs e)
        {
            Step = 2;
            Update_View();
        }
        private void tabPage3_Enter(object sender, EventArgs e)
        {
            Step = 3;
            Update_View();
        }
        private void tabPage4_Enter(object sender, EventArgs e)
        {
            Step = 4;
            Update_View();
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Disp_Region_Click(object sender, EventArgs e)
        {
            Draw_Region(Param.Test_Region.Region);
        }
        private void B_Create_Region_Click(object sender, EventArgs e)
        {
            TForm_Select_Area form = new TForm_Select_Area();
            form.Image = Image1.Clone();
            form.Region = Param.Test_Region.Region.CopyObj(1, -1);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Test_Region.Region = form.Region.Clone();
                Draw_Region(Param.Test_Region.Region);
            }
        }
        private void RB_Base_Image_CheckedChanged(object sender, EventArgs e)
        {
            Update_View();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Result_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Result.Image);
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
        }

    }
    public class TAlign_Mothed_1
    {
        public static string Default_Path;

        public static bool Set_Param(HImage image, ref TAlign_Mothed_1_Param param)
        {
            bool result = false;
            TForm_Align_Mothed form = new TForm_Align_Mothed();
            form.Image1 = image.Clone();
            form.Default_Path = param.Default_Path;
            form.Set_Param(param);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                param = form.Param.Copy();
                result = true;
            }
            return result;
        }
        public static bool Trans(HImage image1, HImage image2, TAlign_Mothed_1_Param param, ref TAlign_Mothed_1_Result result_p)
        {
            bool result = false;
            HImage tmp_image1 = new HImage();
            HImage tmp_image2 = new HImage();

            if (image1 != null && image2 != null)
            {
                try
                {
                    tmp_image1 = image1.ReduceDomain(param.Test_Region.Region);
                    tmp_image1.PointsHarris(param.Sigma_Grad, param.Sigma_Smooth,
                                            param.Alpha, param.Point_Num, out result_p.Row_1, out result_p.Col_1);

                    tmp_image2 = image2.ReduceDomain(param.Test_Region.Region);
                    tmp_image2.PointsHarris(param.Sigma_Grad, param.Sigma_Smooth,
                                            param.Alpha, param.Point_Num, out result_p.Row_2, out result_p.Col_2);
                    result_p.HomMat2D = tmp_image2.ProjMatchPointsRansac(
                                                 tmp_image1, result_p.Row_2, result_p.Col_2, result_p.Row_1, result_p.Col_1,
                                                 "ssd", 10, 0, 0, 255, 255, 0, 10, "normalized_dlt", 0.2, 0,
                                                 out result_p.Points1, out result_p.Points2);

                    result_p.Image = image2.ProjectiveTransImage(result_p.HomMat2D, "nearest_neighbor", "false", "true");
                    result = true;
                }
                catch
                {
                }
            }
            return result;
        }
        public static void Disp_Result(HWindowControl hw, TAlign_Mothed_1_Result result)
        {
            if (result.Find_OK)
            {
                //顯示標靶輪廓線
                //Vision.Display_Model_XLD(hw,Image_Data.Column,Image_Data.Row,Image_Data.Angle,Model.XLD,"green");

                //顯示標靶中心十字
                //Vision.Display_Hairline(hw,Image_Data.Column,Image_Data.Row,20,"yellow");

                //顯示標靶外型區域
                //Vision.Display_Model_Rectangle(HW,find_data,&Model,color);

                //顯示搜尋區域
                //Vision.Display_Model_Area(HW,find_data,"green");
            };
        }
    }
    public class TAlign_Mothed_1_Param
    {
        public string Default_Path,
                                Default_FileName,
                                FileName,
                                Info;

        public double Sigma_Grad,
                                Sigma_Smooth,
                                Alpha,
                                Point_Num;
        public TJJS_Region Test_Region = new TJJS_Region();

        public TAlign_Mothed_1_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        public void Set_Default()
        {
            Sigma_Grad = 3;
            Sigma_Smooth = 2.0;
            Alpha = 0.08;
            Point_Num = 1000;
            Test_Region.Set_Default();
        }
        public TAlign_Mothed_1_Param Copy()
        {
            TAlign_Mothed_1_Param result = new TAlign_Mothed_1_Param();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;

            result.Sigma_Grad = Sigma_Grad;
            result.Sigma_Smooth = Sigma_Smooth;
            result.Alpha = Alpha;
            result.Point_Num = Point_Num;
            result.Test_Region = Test_Region.Copy();
            return result;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = Default_Path + Default_FileName;
            if (System.IO.File.Exists(filename))
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                result = Read(ini, section);
                //ini.UpdateFile();
            };
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                Sigma_Grad = ini.ReadFloat(tmp_section, "Sigma_Grad", 3);
                Sigma_Smooth = ini.ReadFloat(tmp_section, "Sigma_Smooth", 2.0);
                Alpha = ini.ReadFloat(tmp_section, "Alpha", 0.08);
                Point_Num = ini.ReadFloat(tmp_section, "Point_Num", 1000);
            }
            return true;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "") filename = Default_Path + Default_FileName;
            FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);

                ini.WriteFloat(tmp_section, "Sigma_Grad", Sigma_Grad);
                ini.WriteFloat(tmp_section, "Sigma_Smooth", Sigma_Smooth);
                ini.WriteFloat(tmp_section, "Alpha", Alpha);
                ini.WriteFloat(tmp_section, "Point_Num", Point_Num);
            }
            return true;
        }
    }
    public class TAlign_Mothed_1_Result
    {
        public bool Find_OK;
        public HImage Image = new HImage();
        public HHomMat2D HomMat2D = new HHomMat2D();
        public HTuple Row_1,
                                 Col_1,
                                 Row_2,
                                 Col_2;
        public HTuple Points1,
                                 Points2;

        public TAlign_Mothed_1_Result()
        {
            Find_OK = false;
        }
        public TAlign_Mothed_1_Result Copy()
        {
            TAlign_Mothed_1_Result result = new TAlign_Mothed_1_Result();
            result.Image = Image.Clone();
            result.HomMat2D = HomMat2D.Clone();
            result.Row_1 = Row_1;
            result.Col_1 = Col_1;
            result.Row_2 = Row_2;
            result.Col_2 = Col_2;

            result.Points1 = Points1;
            result.Points2 = Points2;
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
            }
            return true;
        }
        public void Draw_Point1(HWindowControl hw)
        {
            hw.HalconWindow.SetColor("green");
            hw.HalconWindow.SetLineWidth(2);
            hw.HalconWindow.DispCross(Row_1, Col_1, 10.0, 0.0);
        }
        public void Draw_Point2(HWindowControl hw)
        {
            hw.HalconWindow.SetColor("green");
            hw.HalconWindow.SetLineWidth(2);
            hw.HalconWindow.DispCross(Row_2, Col_2, 10.0, 0.0);
        }
        public void Resset()
        {
            Find_OK = false;
        }
    }
}
