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
using HalconDotNet;
using EFC.INI;
using EFC.CAD;
using EFC.Tool;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Find_KDL_AOI2 : Form
    {
        public TFind_KDL_AOI2_Param      Param = new TFind_KDL_AOI2_Param();
        public HImage                    Base_Image = new HImage();
        public HImage                    Sample_Image = new HImage();
        public HImage                    Tmp_Sample_Image = new HImage();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;

        public TForm_Find_KDL_AOI2()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public void Set_Param(HImage image, TFind_KDL_AOI2_Param param)
        {
            if (TJJS_Vision.Is_Not_Empty(image)) Sample_Image = image.Clone();
            Param = param.Copy();

            CB_Used_Align_Image.Checked = Param.Align_Image_Flag;
            B_Edit_Model_Param.Enabled = CB_Used_Align_Image.Checked;
            if (TJJS_Vision.Is_Not_Empty(Param.Align_Param.Base_Image)) Base_Image = Param.Align_Param.Base_Image.Clone();
            //tFrame_Select_Model1.Set_Model(Param.Model_Param.JJS_Model);
            Set_Param_Process();
        }
        public void Set_Param_Process()
        {
            ListBox lb = null;

            lb = LB_Process;
            lb.Items.Clear();
            for (int i = 0; i < Param.Process.Programs_List.Count; i++)
            {
                lb.Items.Add(Param.Process.Programs_List[i].ToString());
            }
            if (lb.Items.Count > 0) lb.SelectedIndex = 0;
        }
        public void Update_Param()
        {
            Param.Align_Image_Flag = CB_Used_Align_Image.Checked;
        }
        private void Form_Find_Barcode1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tFrame_JJS_HW1.SetPart(Base_Image);
            if (TJJS_Vision.Is_Not_Empty(Base_Image)) tFrame_JJS_HW1.HW_Buf.HalconWindow.DispObj(Base_Image);
            tFrame_JJS_HW1.Copy_HW();
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
        public void Find_Model()
        {
            //TFind_Mothed_1_Result find = new TFind_Mothed_1_Result();
            //TFind_Mothed_1.Find(Image, Param, ref find);
            //Disp_find_Result(find);
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
        public void Draw_Region()
        {
            HImage image = null;
            HWindowControl hw;

            image = Base_Image;
            hw = JJS_HW.HW_Buf;
            if (image != null)
            {
                JJS_HW.SetPart(image);
                hw.HalconWindow.ClearWindow();
                hw.HalconWindow.DispObj(image);
                hw.HalconWindow.SetColored(12);
                hw.HalconWindow.SetLineWidth(5);
                hw.HalconWindow.SetDraw("margin");
                hw.HalconWindow.SetColor("red");
                Param.Find_Region.Region.DispObj(hw.HalconWindow);
                JJS_HW.Copy_HW();
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion tmp_region = new HRegion();
            HImage tmp_image = new HImage();
            TAlign_Mothed_3_Result f_result = new TAlign_Mothed_3_Result();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(5);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                    if (TJJS_Vision.Is_Not_Empty(Base_Image)) Base_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    if (TJJS_Vision.Is_Not_Empty(Param.Find_Region.Region)) Param.Find_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    if (Param.Align_Image_Flag)
                    {

                        if (TAlign_Mothed_3.Trans(Sample_Image, Param.Align_Param, ref f_result))
                        {
                            Tmp_Sample_Image = f_result.Image.Clone();
                        }
                        else
                        {
                            Tmp_Sample_Image = Sample_Image.Clone();
                        }
                        Tmp_Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    }
                    Tmp_Sample_Image = Sample_Image.Clone();
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        if (TFind_KDL_AOI2.Run_Process(Param, Tmp_Sample_Image, Param.Find_Region.Region, ref tmp_region))
                        {
                            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                            if (TJJS_Vision.Is_Not_Empty(Tmp_Sample_Image)) Tmp_Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                            if (TJJS_Vision.Is_Not_Empty(tmp_region)) tmp_region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        }
                        else flag = false;
                    }
                }
                #endregion

                #region Step4 Set Find Param
                if (Step >= 4 && flag)
                {
                    TFind_KDL_AOI2_Result ff_result = new TFind_KDL_AOI2_Result();
                    TFind_KDL_AOI2.Find(Sample_Image, Param, ref ff_result);
                    ff_result.Display(JJS_HW.HW_Buf, 1);
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
        private void B_Edit_Model_Param_Click(object sender, EventArgs e)
        {
            if (TAlign_Mothed_3.Set_Param(Sample_Image, ref Param.Align_Param))
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TForm_Halcon_Tool form = new TForm_Halcon_Tool();

            form.Set_Param(Param.Process);
            form.Set_Part(Base_Image);
            form.Org_Tool_Values.Add(Param.Process.In);
            form.Org_Tool_Values.Add(Param.Process.Out);
            form.Org_Tool_Values.Set_Image("In_Image", Tmp_Sample_Image);
            form.Org_Tool_Values.Set_Region("In_Region", Param.Find_Region.Region);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Process = form.Param.Copy();
                Set_Param_Process();
            }
        }
        private void CB_Used_Find_Model_CheckedChanged(object sender, EventArgs e)
        {
            B_Edit_Model_Param.Enabled = CB_Used_Align_Image.Checked;
        }
        private void E_Edit_Find_Region_Click(object sender, EventArgs e)
        {
            TForm_Select_Area form = new TForm_Select_Area();

            form.Image = Base_Image.Clone();
            form.Line_Width = 5;
            form.Select_Region = Param.Find_Region.Region.CopyObj(1, -1);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Find_Region.Region = form.Select_Region.Clone();
                Draw_Region();
            }
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Base_Image);
        }
        private void B_Trans_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Sample_Image);
        }
        private void B_Select_Base_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Base_Image_File.Text = dialog.FileName;
                Base_Image.ReadImage(E_Base_Image_File.Text);
                B_Base_Image.BackColor = Color.LightGreen;

                Param.Align_Param.Base_Image = Base_Image.Clone();
                Param.Align_Param.Update();

                Draw_Image(Base_Image);
            }

        }
        private void B_Select_Trans_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Trans_Image_File.Text = dialog.FileName;
                Sample_Image.ReadImage(E_Trans_Image_File.Text);
                B_Trans_Image.BackColor = Color.LightGreen;
                Draw_Image(Sample_Image);
            }
        }
    }
    public class TFind_KDL_AOI2
    {
        public static HDataCode2D Code_Handle = new HDataCode2D();
        public static bool Init_Flag = false;
        
        public static string Default_Path;
        public static void Init()
        {
            Code_Handle.CreateDataCode2dModel("Data Matrix ECC 200", "default_parameters", "enhanced_recognition");
            Code_Handle.SetDataCode2dParam("contrast_tolerance", "high");
            Init_Flag = true;
        }
        public static bool Set_Param(HImage image, ref TFind_KDL_AOI2_Param param)
        {
            bool result = false;
            TForm_Find_KDL_AOI2 form = new TForm_Find_KDL_AOI2();

            form.Set_Param(image, param);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                param = form.Param.Copy();
                result = true;
            }
            return result;
        }
        public static bool Find(HImage image, TFind_KDL_AOI2_Param param, ref TFind_KDL_AOI2_Result result_data)
        {
            TAlign_Mothed_3_Result f_result = new TAlign_Mothed_3_Result();
            HRegion find_region = new HRegion();
            HImage tmp_image = new HImage();

            result_data.Reset();
            result_data.Find_Region = param.Find_Region.Region.Clone();
            if (param.Align_Image_Flag)
            {
                if (TAlign_Mothed_3.Trans(image, param.Align_Param, ref f_result))
                {
                    tmp_image = f_result.Image.Clone();
                }
                else
                {
                    tmp_image = image.Clone();
                }
            }
            else tmp_image = image.Clone();

            result_data.Image = tmp_image.Clone();
            if (Run_Process(param, tmp_image, param.Find_Region.Region, ref result_data.Defect_Region))
            {
                if (result_data.Defect_Region.CountObj() > 0) result_data.Find_OK = true;
            }

            if (TJJS_Vision.Is_Not_Empty(result_data.Defect_Region))
                result_data.Defect_Region = TJJS_Vision.Affine_Trans_Region(result_data.Defect_Region, 0, 0, 0, f_result.D_Col, f_result.D_Row, f_result.D_Angle);

            return result_data.Find_OK;
        }
        public static bool Run_Process(TFind_KDL_AOI2_Param param, HImage in_image, HRegion in_region, ref HRegion out_region)
        {
            bool result = true;
            TCommand_manager manager = new TCommand_manager();
            TTool_Values tool_values = new TTool_Values();
            TCommand_Define cmd = null;

            cmd = param.Process;
            manager.Register_All_Command();
            manager.Register_User_Command(cmd.User_Cmd_List);
            tool_values.Add(cmd.In);
            tool_values.Add(cmd.Out);
            tool_values.Set_Image("In_Image", in_image);
            tool_values.Set_Region("In_Region", in_region);
            result = manager.Execute(cmd, ref tool_values);
            if (result) out_region = tool_values.Get_Value_Region("Out_Region");
            return result;
        }
    }
    public class TFind_KDL_AOI2_Param
    {
        public string                  Default_Path,
                                       Default_FileName,
                                       FileName,
                                       Info;

        public bool                    Align_Image_Flag = false;
        public TAlign_Mothed_3_Param   Align_Param = new TAlign_Mothed_3_Param();
        public TJJS_Region             Find_Region = new TJJS_Region();
        public TCommand_Define         Process = new TCommand_Define();

        public TFind_KDL_AOI2_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        public void Set_Default()
        {
            Align_Image_Flag = false;
            Align_Param.Set_Default();
            Find_Region.Set_Default();
            Process.Set_Default();
        }
        public TFind_KDL_AOI2_Param Copy()
        {
            TFind_KDL_AOI2_Param result = new TFind_KDL_AOI2_Param();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;

            result.Align_Image_Flag = Align_Image_Flag;
            result.Align_Param = Align_Param.Copy();
            result.Find_Region = Find_Region.Copy();
            result.Process = Process.Copy();
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

                Align_Image_Flag = ini.ReadBool(tmp_section, "Align_Image_Flag", false);
                Align_Param.Read(ini, tmp_section + "/Model_Param");
                Process.Read(ini, tmp_section + "/Process");
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

                ini.WriteBool(tmp_section, "Align_Image_Flag", Align_Image_Flag);
                Align_Param.Write(ini, tmp_section + "/Model_Param");
                Process.Write(ini, tmp_section + "/Process");
            }
            return true;
        }
        public void Read_Other_File()
        {
            string filename;

            Align_Param.Read_Other_File();
            Find_Region.Read(Find_Region.Default_Path + Find_Region.Default_FileName);
           
            Align_Param.Base_Image = new HImage();
            filename = Default_Path + "Base.bmp";
            if (System.IO.File.Exists(filename)) Align_Param.Base_Image.ReadImage(filename);
            Align_Param.Update();
        }
        public void Write_Other_File()
        {
            Align_Param.Write_Other_File();
            Find_Region.Write(Find_Region.Default_Path + Find_Region.Default_FileName);
        }
        public void Get_Images_Form_Path(string path, ref HImage out_images, ProgressBar progressBar1 = null)
        {
            ArrayList file_list = null;
            HImage tmp_image = new HImage();
            TAlign_Mothed_3_Result f_result = new TAlign_Mothed_3_Result();
            bool image_ok_flag = true;
            int count, add_count;
            string msg = "";

            file_list = Get_Image_Files(path, ".bmp");
            count = file_list.Count;

            if (progressBar1 != null)
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = count;
            }
            out_images = new HImage();

            add_count = 0;
            for (int i = 0; i < count; i++)
            {
                tmp_image.ReadImage(file_list[i].ToString());
                image_ok_flag = true;
                if (Align_Image_Flag)
                {
                    if (TAlign_Mothed_3.Trans(tmp_image, Align_Param, ref f_result))
                    {
                        tmp_image = f_result.Image.Clone();
                    }
                    else
                    {
                        image_ok_flag = false;
                        msg = string.Format("Golden Align Error?? file_name = {0:s}", file_list[i].ToString());
                        MessageBox.Show(msg, "錯誤", MessageBoxButtons.OK);
                    }

                    if (image_ok_flag)
                    {
                        if (add_count == 0) out_images = tmp_image.Clone();
                        else out_images = out_images.AppendChannel(tmp_image);
                        add_count++;
                    }

                }
                if (progressBar1 != null) progressBar1.Value++;
            }
        }
        public ArrayList Get_Image_Files(string sor_dir, string ext_str)
        {
            ArrayList result = new ArrayList();

            result = String_Tool.Get_Files_List(sor_dir, ext_str);
            return result;
        }
        public void Get_Images_N(HImage in_images, out HImage avg, out HImage std)
        {
            avg = in_images.MeanN();
            std = in_images.DeviationN();
        }
        public double Cal_Golden_Image_Std(HImage image)
        {
            double result = 0.0;
            int w, h;
            HRegion region = new HRegion();
            double deviation, avg;

            if (TJJS_Vision.Is_Not_Empty(image))
            {
                image.GetImageSize(out w, out h);
                region.GenRectangle1(0.0, 0.0, h, w);
                avg = image.Intensity(region, out deviation);
                result = (1 - avg / 255) * 100;
            }
            return result;
        }
        public void Mark_Golden_Image(string path, ref HImage avg_image, ref HImage std_image, ProgressBar progressBar1 = null)
        {
            HImage images = new HImage();

            Get_Images_Form_Path(path, ref images, progressBar1);
            Get_Images_N(images, out avg_image, out std_image);
        }
    }
    public class TFind_KDL_AOI2_Result
    {
        public HImage                  Image = new HImage();
        public HRegion                 Find_Region = new HRegion();
        public HRegion                 Defect_Region = new HRegion();
        public bool                    Find_OK;


        public TFind_KDL_AOI2_Result()
        {
             Set_Default();
        }
        public TFind_KDL_AOI2_Result Copy()
        {
            TFind_KDL_AOI2_Result result = new TFind_KDL_AOI2_Result();

            result.Find_Region = Find_Region.Clone();
            result.Defect_Region = Defect_Region.Clone();
            result.Find_OK = Find_OK;
            return result;
        }
        public void Set_Default()
        {
            Find_OK = false;
            Find_Region.GenEmptyRegion();
            Defect_Region.GenEmptyRegion();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Find_OK = ini.ReadBool(tmp_section, "Find_Ok", false);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteBool(tmp_section, "Find_Ok", Find_OK);
            }
            return true;
        }
        public void Reset()
        {
            Find_OK = false;
            Find_Region.GenEmptyRegion();
            Defect_Region.GenEmptyRegion();

            Image.Dispose();
            Image = new HImage();
        }
        public void Display(HWindowControl hw, double scale)
        {
            if (Find_OK)
            {
                hw.HalconWindow.SetColor("red");
                if (TJJS_Vision.Is_Not_Empty(Defect_Region)) Defect_Region.DispObj(hw.HalconWindow);
                TJJS_Vision.Display_String(hw, "NG", 10, 100, 200, 1, "red");
            }
            else
            {
                TJJS_Vision.Display_String(hw, "OK", 10, 100, 200, 1, "green");
            }
        }
    }
}
