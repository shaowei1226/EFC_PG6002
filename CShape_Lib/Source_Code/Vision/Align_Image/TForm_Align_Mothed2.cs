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
    public partial class TForm_Align_Mothed2 : Form
    {
        public string Default_Path;
        public HImage Image1 = new HImage();
        public HImage Image2 = new HImage();
        public TAlign_Mothed_2_Param Param = new TAlign_Mothed_2_Param();
        public TAlign_Mothed_2_Result Result = new TAlign_Mothed_2_Result();
        public TFrame_JJS_HW JJS_HW;
        public int Step = 0;

        
        public TForm_Align_Mothed2()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        private void TForm_Align_Mothed2_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (!TJJS_Vision.Is_Empty(Param.Base_Image))
            {
                Image1 = Param.Base_Image.Clone();
                JJS_HW.SetPart(Image1);
                B_Base_Image.BackColor = Color.LightGreen;
            }
            if (!TJJS_Vision.Is_Empty(Image2)) B_Trans_Image.BackColor = Color.LightGreen;
            
            Draw_Image(Image1);
            treeView1.TopNode.Expand();
        }
        public void Set_Param(TAlign_Mothed_2_Param param)
        {
            
            Param = param.Copy();

            tFrame_Select_Model1.Set_Model(Param.Param.JJS_Model);
            Set_Param_Find_Info();
        }
        public void Set_Param_Find_Info()
        {
        }
        public void Update_Param()
        {
            Param.Param.JJS_Model = tFrame_Select_Model1.JJS_Model.Copy();
            Update_Param_Find_Info();
            Param.Update();
        }
        public void Update_Param_Find_Info()
        {
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
        }
        public void Draw_Image(HImage image)
        {
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            try
            {
                if (image != null)
                {
                    JJS_HW.HW_Buf.HalconWindow.DispObj(image);
                }
            }
            catch
            {

            }
            JJS_HW.Copy_HW();
        }
        public void Update_View()
        {
            bool flag = true;

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                if (TJJS_Vision.Is_Empty(Image1)) flag = false;

                //if (TJJS_Vision.Is_Empty(Image2))
                //    flag = false;

                #region Step1 display image
                if (Step >= 1 && flag)
                {
                    if (Step == 1)
                    {
                        JJS_HW.HW_Buf.HalconWindow.DispObj(Image1);
                    }
                }
                #endregion

                #region Step2 Select Test Region
                if (Step >= 2 && flag)
                {
                    if (Step == 2)
                    {
                        JJS_HW.HW_Buf.HalconWindow.DispObj(Image1);
                    }
                }
                #endregion

                #region Step3 Disp_Base Image
                if (Step >= 3 && flag)
                {
                    Param.Update();

                    if (Step == 3)
                    {
                        JJS_HW.HW_Buf.HalconWindow.DispObj(Image1);
                        Disp_find_Result(JJS_HW.HW_Buf, Param.Base_Find_Result);
                    }
                }
                #endregion

                #region Step4 Disp_Base Image
                if (Step >= 4 && flag)
                {
                    TAlign_Mothed_2.Find(Image2, Param, ref Result.Sample_Find_Result);

                    if (Step == 4)
                    {
                        JJS_HW.HW_Buf.HalconWindow.DispObj(Image2);
                        Disp_find_Result(JJS_HW.HW_Buf, Result.Sample_Find_Result);
                    }
                }
                #endregion

                #region Step5 Display result image
                if (Step >= 5 && flag)
                {
                    TAlign_Mothed_2.Trans(Image2, Param, ref Result);
                    if (Step == 5)
                        Draw_Image(Result.Image);
                }
                #endregion

                JJS_HW.Copy_HW();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button6_Click(object sender, EventArgs e)
        {
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
        private void B_Edit_Param_Click(object sender, EventArgs e)
        {
            if (TFind_Mothed_1.Set_Param(Image1, ref Param.Param))
            {
                tFrame_Select_Model1.Set_Model(Param.Param.JJS_Model);
            }
        }
        private void TP_Step0_Enter(object sender, EventArgs e)
        {
            Step = 0;
            Update_View();
        }
        private void TP_Step1_Enter(object sender, EventArgs e)
        {
            Step = 1;
            Update_View();
        }
        private void TP_Step2_Enter(object sender, EventArgs e)
        {
            Step = 2;
            Update_View();
        }
        private void TP_Step3_Enter(object sender, EventArgs e)
        {
            Step = 3;
            Update_View();
        }
        private void TP_Step4_Enter(object sender, EventArgs e)
        {
            Step = 4;
            Update_View();
        }
        private void TP_Step5_Enter(object sender, EventArgs e)
        {
            Step = 5;
            Update_View();
        }
        public void Disp_find_Result(HWindowControl hw, TFind_Mothed_1_Result find)
        {
            string color = "";

            if (find.Find_OK) color = "green";
            else color = "red";
            TFind_Mothed_1.Disp_Message(hw, find, 20, 20, 20, 1, color);
            TFind_Mothed_1.Disp_XLD(hw, find, color);
            TFind_Mothed_1.Disp_Hairline(hw, find, 30, color);
            TFind_Mothed_1.Disp_Find_Rectangle(hw, find, "green");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Find_Model();
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void B_Trans_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Base_Image_Find_Click(object sender, EventArgs e)
        {
            Param.Update();
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            JJS_HW.HW_Buf.HalconWindow.DispObj(Image1);
            Disp_find_Result(JJS_HW.HW_Buf, Param.Base_Find_Result);
            JJS_HW.Copy_HW();
        }
        private void B_Sample_Image_Find_Click(object sender, EventArgs e)
        {
            TAlign_Mothed_2.Find(Image2, Param, ref Result.Sample_Find_Result);
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            if (TJJS_Vision.Is_Not_Empty(Image2))
            {
                JJS_HW.HW_Buf.HalconWindow.DispObj(Image2);
                Disp_find_Result(JJS_HW.HW_Buf, Result.Sample_Find_Result);
            }
            JJS_HW.Copy_HW();
        }
        private void B_Base_Image2_Click(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void B_Sample_Image2_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Result_Image_Click(object sender, EventArgs e)
        {
            if (TAlign_Mothed_2.Trans(Image2, Param, ref Result))
            {
                Draw_Image(Result.Image);
            }
        }
    }
    public class TAlign_Mothed_2
    {
        public static string Default_Path;

        public static bool Set_Param(HImage image, ref TAlign_Mothed_2_Param param)
        {
            bool result = false;
            TForm_Align_Mothed2 form = new TForm_Align_Mothed2();
            if (TJJS_Vision.Is_Not_Empty(param.Base_Image)) form.Image1 = param.Base_Image.Clone();
            if (TJJS_Vision.Is_Not_Empty(image)) form.Image2 = image.Clone();    
            form.Default_Path = param.Default_Path;
            form.Set_Param(param);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                param = form.Param.Copy();
                result = true;
            }
            return result;           
        }
        public static bool Find(HImage image, TAlign_Mothed_2_Param param, ref TFind_Mothed_1_Result find_result)
        {
            bool result = true;
            TJJS_Point ofs = new TJJS_Point();

            if (!TFind_Mothed_1.Find(image, param.Param, param.Param.Find_Region, ref find_result, false)) result = false;

            return result;
        }
        public static bool Trans(HImage image, TAlign_Mothed_2_Param param, ref TAlign_Mothed_2_Result result_p)
        {
            double d_col, d_row,d_ang;

            result_p.Resset();
            if (TJJS_Vision.Is_Not_Empty(image))
            {
                try
                {
                    Find(image, param, ref result_p.Sample_Find_Result);
                    if (param.Base_Find_Result.Find_OK && result_p.Sample_Find_Result.Find_OK)
                    {
                        d_col = result_p.Sample_Find_Result.Col - param.Base_Find_Result.Col;
                        d_row = result_p.Sample_Find_Result.Row - param.Base_Find_Result.Row;
                        d_ang = 0;
                        result_p.Image = TJJS_Vision.Affine_Trans_Image(image, d_col, d_row, d_ang, 0, 0, 0);
                        result_p.Find_OK = true;
                    }
                }
                catch
                {
                }
            }
            return result_p.Find_OK;
        }
        public static void Disp_Result(HWindowControl hw, TAlign_Mothed_2_Result result)
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
    public class TAlign_Mothed_2_Param
    {
        public string                   Default_Path,
                                        Default_FileName,
                                        FileName,
                                        Info;

        public bool                     Param_Data_OK;
        public HImage                   Base_Image = null;
        public TFind_Mothed_1_Param     Param = new TFind_Mothed_1_Param();
        public TFind_Mothed_1_Result    Base_Find_Result = new TFind_Mothed_1_Result();

        public TAlign_Mothed_2_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        public void Set_Default()
        {
            Param.Set_Default();
            Base_Find_Result.Set_Default();
            Param_Data_OK = false;
        }
        public TAlign_Mothed_2_Param Copy()
        {
            TAlign_Mothed_2_Param result = new TAlign_Mothed_2_Param();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;

            result.Param_Data_OK = Param_Data_OK;
            result.Base_Image = Base_Image;
            result.Base_Find_Result = Base_Find_Result.Copy();
            result.Param = Param.Copy();
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
                Update();
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

                Param.Read(ini, section + "/Param");
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


                Param.Write(ini, section + "/Param");
            }
            return true;
        }
        public void Read_Other_File()
        {
            Param.Read_Other_File();
        }
        public void Write_Other_File()
        {
            Param.Write_Other_File();
        }
        public bool Update()
        {
            Param_Data_OK = false;
            try
            {
                Param_Data_OK = TAlign_Mothed_2.Find(Base_Image, this, ref Base_Find_Result);
            }
            catch { }
            return Param_Data_OK;
        }
    }
    public class TAlign_Mothed_2_Result
    {
        public bool Find_OK;
        public HImage Image = new HImage();
        public stRect_Double Find_Region = new stRect_Double();
        public TFind_Mothed_1_Result Sample_Find_Result = new TFind_Mothed_1_Result();

        public TAlign_Mothed_2_Result()
        {
            Find_OK = false;

            Sample_Find_Result = new TFind_Mothed_1_Result();
        }
        public TAlign_Mothed_2_Result Copy()
        {
            TAlign_Mothed_2_Result result = new TAlign_Mothed_2_Result();
            result.Image = Image.Clone();

            result.Sample_Find_Result = Sample_Find_Result.Copy();
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
        public void Resset()
        {
            Find_OK = false;
            Sample_Find_Result.Reset();
        }
    }
}
