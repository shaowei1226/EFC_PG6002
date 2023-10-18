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
    public partial class TForm_KDL_Check1 : Form
    {
        public TKDL_Check1_Param      Param = new TKDL_Check1_Param();
        public HImage                    Base_Image = new HImage();
        public HImage                    Sample_Image = new HImage();
        public HImage                    Tmp_Sample_Image = new HImage();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;

        public TForm_KDL_Check1()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public void Set_Param(HImage image, TKDL_Check1_Param param)
        {
            if (JJS_Vision.Is_Not_Empty(image)) Sample_Image = image.Clone();
            Param.Set(param);

            CB_Used_Align_Image.Checked = Param.Align_Image_Flag;
            B_Edit_Model_Param.Enabled = CB_Used_Align_Image.Checked;
            if (JJS_Vision.Is_Not_Empty(Param.Align_Param.Base_Image)) Base_Image = Param.Align_Param.Base_Image.Clone();
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
            Param.Update();
        }
        private void Form_Find_Barcode1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tFrame_JJS_HW1.SetPart(Base_Image);
            if (JJS_Vision.Is_Not_Empty(Base_Image)) tFrame_JJS_HW1.HW_Buf.HalconWindow.DispObj(Base_Image);
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
            if (JJS_Vision.Is_Not_Empty(image)) image.DispObj(JJS_HW.HW_Buf.HalconWindow);
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
                    if (JJS_Vision.Is_Not_Empty(Base_Image)) Base_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    if (JJS_Vision.Is_Not_Empty(Param.Find_Region.Region)) Param.Find_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    if (Param.Align_Image_Flag)
                    {

                        if (Param.Align_Param.Trans(Sample_Image, ref f_result))
                        {
                            Tmp_Sample_Image = f_result.Image.Clone();
                        }
                        else
                        {
                            Tmp_Sample_Image = Sample_Image.Clone();
                        }
                        Tmp_Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    }
                    else 
                        Tmp_Sample_Image = Sample_Image.Clone();
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        if (Param.Run_Process(Tmp_Sample_Image, Param.Find_Region.Region, ref tmp_region))
                        {
                            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                            if (JJS_Vision.Is_Not_Empty(Tmp_Sample_Image)) Tmp_Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                            if (JJS_Vision.Is_Not_Empty(tmp_region)) tmp_region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        }
                        else flag = false;
                    }
                }
                #endregion

                #region Step4 Set Find Param
                if (Step >= 4 && flag)
                {
                    TBase_Result ff_result = new TKDL_Check1_Result();
                    Param.Find_Base(Sample_Image, ref ff_result);
                    if (JJS_Vision.Is_Not_Empty(Sample_Image)) Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
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
            if (Param.Align_Param.Set_Param(Sample_Image))
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
                Param.Process.Set(form.Param);
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

        private void button4_Click(object sender, EventArgs e)
        {
            Draw_Image(Base_Image);
        }

        private void button8_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Update_View();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Draw_Image(Tmp_Sample_Image);
        }
        private void B_Param_Update_Click(object sender, EventArgs e)
        {
            Update_Param();
        }
    }
    public class TKDL_Check1_Param : TBase_Param
    {
        public bool                    Align_Image_Flag = false;
        public TAlign_Mothed_3_Param   Align_Param = new TAlign_Mothed_3_Param();
        public TJJS_Region             Find_Region = new TJJS_Region();
        public TCommand_Define         Process = new TCommand_Define();
        public static HDataCode2D      Code_Handle = new HDataCode2D();
        
        public TKDL_Check1_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TKDL_Check1_Param();
        }
        override public TBase_Result New_Base_Result()
        {
            return new TKDL_Check1_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TKDL_Check1_Param && dis_base is TKDL_Check1_Param)
            {
                TKDL_Check1_Param sor = (TKDL_Check1_Param)sor_base;
                TKDL_Check1_Param dis = (TKDL_Check1_Param)dis_base;

                base.Copy(sor, dis);
                dis.Align_Image_Flag = sor.Align_Image_Flag;
                dis.Align_Param.Set(sor.Align_Param);
                dis.Find_Region.Set(sor.Find_Region);
                dis.Process.Set(sor.Process);
            }
        }
        override public void Set_Default()
        {
            Align_Image_Flag = false;
            Align_Param.Set_Default();
            Find_Region.Set_Default();
            Process.Set_Default();
            Code_Handle.CreateDataCode2dModel("Data Matrix ECC 200", "default_parameters", "enhanced_recognition");
            Code_Handle.SetDataCode2dParam("contrast_tolerance", "high");
        }
        override public void Read(TJJS_XML_File ini, string section)
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
        }
        override public void Write(TJJS_XML_File ini, string section)
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
        }
        override public void Read_Other_File()
        {
            string filename;

            Align_Param.Read_Other_File();
            Find_Region.Read(Find_Region.Default_Path + Find_Region.Default_FileName);
            Update();
        }
        override public void Write_Other_File()
        {
            Align_Param.Write_Other_File();
            Find_Region.Write(Find_Region.Default_Path + Find_Region.Default_FileName);
        }
        override public bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_KDL_Check1 form = new TForm_KDL_Check1();

            form.Set_Param(image, this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        override public bool Find_Base(HImage image, ref TBase_Result f_result)
        {
            bool result = false;
            if (f_result is TKDL_Check1_Result && JJS_Vision.Is_Not_Empty(image))
            {
                TKDL_Check1_Result in_result = (TKDL_Check1_Result)f_result;
                TAlign_Mothed_3_Result al_result = new TAlign_Mothed_3_Result();
                HRegion find_region = new HRegion();
                HImage tmp_image = new HImage();

                in_result.Reset();
                in_result.Find_Region = Find_Region.Region.Clone();
                if (Align_Image_Flag)
                {
                    if (Align_Param.Trans(image, ref al_result))
                    {
                        tmp_image = al_result.Image.Clone();
                    }
                    else
                    {
                        tmp_image = image.Clone();
                    }
                }
                else tmp_image = image.Clone();

                in_result.Image = tmp_image.Clone();
                if (Run_Process(tmp_image, Find_Region.Region, ref in_result.Get_Region))
                {
                    if (JJS_Vision.Is_Not_Empty(in_result.Get_Region))
                        if (in_result.Get_Region.CountObj() > 0) in_result.Find_OK = true;
                }

                if (JJS_Vision.Is_Not_Empty(in_result.Get_Region))
                    in_result.Get_Region = JJS_Vision.Affine_Trans_Region(in_result.Get_Region, 0, 0, 0, al_result.D_Col, al_result.D_Row, al_result.D_Angle);

                result = in_result.Find_OK;
            }
            return result;
        }
        public bool Run_Process(HImage in_image, HRegion in_region, ref HRegion out_region)
        {
            bool result = true;
            TCommand_manager manager = new TCommand_manager();
            TTool_Values tool_values = new TTool_Values();
            TCommand_Define cmd = null;

            cmd = Process;
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

        public void Update()
        {
            HImage tmp_std_image = new HImage();

            Align_Param.Update();
            tmp_std_image.Dispose();
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
                    if (Align_Param.Trans(tmp_image, ref f_result))
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

            if (JJS_Vision.Is_Not_Empty(image))
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
    public class TKDL_Check1_Result : TBase_Result
    {
        public HImage                  Image = new HImage();
        public HRegion                 Find_Region = new HRegion();
        public HRegion                 Get_Region = new HRegion();
        public bool                    Find_OK;


        public TKDL_Check1_Result()
        {
             Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TKDL_Check1_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TKDL_Check1_Result && dis_base is TKDL_Check1_Result)
            {
                TKDL_Check1_Result sor = (TKDL_Check1_Result)sor_base;
                TKDL_Check1_Result dis = (TKDL_Check1_Result)dis_base;

                dis.Find_Region = sor.Find_Region.Clone();
                dis.Get_Region = sor.Get_Region.Clone();
                dis.Find_OK = sor.Find_OK;
            }
        }
        override public void Set_Default()
        {
            Find_OK = false;
            Find_Region.GenEmptyRegion();
            Get_Region.GenEmptyRegion();
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Find_OK = ini.ReadBool(tmp_section, "Find_Ok", false);
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteBool(tmp_section, "Find_Ok", Find_OK);
            }
        }

        override public void Reset()
        {
            Find_OK = false;
            Find_Region.GenEmptyRegion();
            Get_Region.GenEmptyRegion();

            Image.Dispose();
            Image = new HImage();
        }
        override public void Display_Message(HWindowControl hw, double scale)
        {
            //string color = "";

            //if (Find_OK) color = Model_Color_OK;
            //else color = Model_Color_NG;

            //if (Find_OK) JJS_Vision.Display_String(hw, Barcode, Barcode_X, Barcode_Y, Barcode_Font_Size, 1, color);
            //JJS_Vision.Display_String(hw, Get_Message(), Msg_X, Msg_Y, Msg_Font_Size, 1, color);
        }
        override public void Display_Model(HWindowControl hw, double scale)
        {
            if (Find_OK)
            {
                hw.HalconWindow.SetColor("red");
                if (JJS_Vision.Is_Not_Empty(Get_Region)) Get_Region.DispObj(hw.HalconWindow);
                JJS_Vision.Display_String(hw, "OK", 10, 100, 200, 1, "green");
            }
            else
            {
                JJS_Vision.Display_String(hw, "NG", 10, 100, 200, 1, "red");
            }
        }
        override public string Get_Message()
        {
            string result = "";
            if (Find_OK) result = "OK";
            else result = "NG";
            return result;
        }
    }
}
