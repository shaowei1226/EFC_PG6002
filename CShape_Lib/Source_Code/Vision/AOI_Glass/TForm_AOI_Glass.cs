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
    public partial class TForm_AOI_Glass : Form
    {
        public TAOI_Glass_Param          Param = new TAOI_Glass_Param();
        public HImage                    Sample_Image = new HImage();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;
        TAOI_Glass_Result                F_Result = new TAOI_Glass_Result();

        public TForm_AOI_Glass()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public void Set_Param(HImage image, TAOI_Glass_Param param)
        {
            if (JJS_Vision.Is_Not_Empty(image)) Sample_Image = image.Clone();
            Param.Set(param);

            E_Sigma1.Text = Param.Filter_Sigma1.ToString("0.0");
            E_Sigma2.Text = Param.Filter_Sigma2.ToString("0.0");
        }
        public void Update_Param()
        {
            Param.Filter_Sigma1 = Convert.ToDouble(E_Sigma1.Text);
            Param.Filter_Sigma2 = Convert.ToDouble(E_Sigma2.Text); 
            Param.Update();
        }
        private void Form_Find_Barcode1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tFrame_JJS_HW1.SetPart(Sample_Image);
            if (JJS_Vision.Is_Not_Empty(Sample_Image)) tFrame_JJS_HW1.HW_Buf.HalconWindow.DispObj(Sample_Image);
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
        public void Disp_Image(HImage in_image)
        {
            HWindowControl hw = JJS_HW.HW_Buf;

            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            if (JJS_Vision.Is_Not_Empty(in_image))
            {
                hw.HalconWindow.DispObj(in_image);
            }
        }
        public void Disp_Region(HRegion in_region)
        {
            HWindowControl hw = JJS_HW.HW_Buf;

            if (JJS_Vision.Is_Not_Empty(in_region))
            {
                hw.HalconWindow.SetColored(12);
                hw.HalconWindow.SetLineWidth(5);
                hw.HalconWindow.SetDraw("margin");
                hw.HalconWindow.SetColor("red");
                hw.HalconWindow.DispObj(in_region);
            }
        }
        public void Disp_Result()
        {
            HWindowControl hw = JJS_HW.HW_Buf;

            F_Result.Display(hw);
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion tmp_region = new HRegion();
            HImage tmp_image = new HImage();

            Update_Param();
            if (true)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(5);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                #region Step1 
                if (Step >= 1 && flag)
                {
                    JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                    if (JJS_Vision.Is_Not_Empty(Sample_Image)) Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    if (JJS_Vision.Is_Not_Empty(Param.Find_Region.Region)) Param.Find_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2  
                if (Step >= 2 && flag)
                {
                }
                #endregion

                #region Step3 big defect
                if (Step >= 3 && flag)
                {
                    Param.Get_Defect(Sample_Image, ref F_Result);
                    Disp_Result();
                }
                #endregion

                #region Step4 small defect
                if (Step >= 4 && flag)
                {

                }
                #endregion
                JJS_HW.Copy_HW();
            }
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            TabColtrol1.SelectedIndex++;
        }
        private void TP_Space_Enter(object sender, EventArgs e)
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
        private void B_Big_Param_Click(object sender, EventArgs e)
        {
            Edit_CMD(Param.Big_CMD);
            Update_View();
        }
        private void B_Small_Param_Click(object sender, EventArgs e)
        {
            Edit_CMD(Param.Small_CMD);
            Update_View();
        }
        public bool Edit_CMD(TCommand_Define cmd)
        {
            bool result = false;
            TForm_Halcon_Tool form = new TForm_Halcon_Tool();
            HImage image = Sample_Image.Clone();// Param.Get_Defect_Image(Sample_Image);

            image.WriteImage("bmp", 0, "e:\\1.bmp");

            form.Set_Param(cmd);
            form.Set_Part(Sample_Image);
            form.Org_Tool_Values.Add_Value(cmd.In);
            form.Org_Tool_Values.Add_Value_Out(cmd.Out);
            form.Org_Tool_Values.Set_Image("In_Image", image);
            form.Org_Tool_Values.Set_Region("In_Region", Param.Find_Region.Region);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cmd.Set(form.Param);
                result = true;
            }
            return result;
        }
        private void E_Edit_Find_Region_Click(object sender, EventArgs e)
        {
            TForm_Select_Area form = new TForm_Select_Area();

            form.Image = Sample_Image.Clone();
            form.HW_Line_Width = 5;
            form.Select_Region = Param.Find_Region.Region.CopyObj(1, -1);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Find_Region.Region = form.Select_Region.Clone();
                Disp_Image(Sample_Image);
                Disp_Region(Param.Find_Region.Region);
                JJS_HW.Copy_HW();
            }
        }
        private void B_Trans_Image_Click(object sender, EventArgs e)
        {
            Disp_Image(Sample_Image);
            JJS_HW.Copy_HW();
        }
        private void B_Select_Trans_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Sample_Image_File.Text = dialog.FileName;
                Sample_Image.ReadImage(E_Sample_Image_File.Text);
                Disp_Image(Sample_Image);
                JJS_HW.Copy_HW();
            }
        }

        private void RB_Display1_Click(object sender, EventArgs e)
        {
            if (RB_Display1.Checked) F_Result.Disp_Param.Display_Index = 0;
            if (RB_Display2.Checked) F_Result.Disp_Param.Display_Index = 1;
            if (RB_Display3.Checked) F_Result.Disp_Param.Display_Index = 2;
            F_Result.Disp_Param.Disp_Big_Defect = CB_Big.Checked;
            F_Result.Disp_Param.Disp_Small_Defect = CB_Small.Checked;
            Update_View();
        }



    }
    public class TAOI_Glass_Param : TBase_Param
    {
        public static HDataCode2D      Code_Handle = new HDataCode2D();
        public static bool             Init_Flag = false;
        public double                  Filter_Sigma1 = 10;
        public double                  Filter_Sigma2 = 3;

        public TJJS_Region             Find_Region = new TJJS_Region();
        public TCommand_Define         Big_CMD = new TCommand_Define();
        public TCommand_Define         Small_CMD = new TCommand_Define();



        public TAOI_Glass_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAOI_Glass_Param();
        }
        override public TBase_Result New_Base_Result()
        {
            return new TAOI_Glass_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAOI_Glass_Param && dis_base is TAOI_Glass_Param)
            {

                TAOI_Glass_Param sor = (TAOI_Glass_Param)sor_base;
                TAOI_Glass_Param dis = (TAOI_Glass_Param)dis_base;

                base.Copy(sor, dis);

                dis.Filter_Sigma1 = sor.Filter_Sigma1;
                dis.Filter_Sigma2 = sor.Filter_Sigma2;

                dis.Find_Region.Set(sor.Find_Region);
                dis.Big_CMD.Set(sor.Big_CMD);
                dis.Small_CMD.Set(sor.Small_CMD);
                dis.Update();
            }
        }

        override public void Set_Default()
        {
            Find_Region.Set_Default();
            Big_CMD.Set_Default();
            Small_CMD.Set_Default();
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                Filter_Sigma1 = ini.ReadFloat(section, "Filter_Sigma1", Filter_Sigma1);
                Filter_Sigma2 = ini.ReadFloat(section, "Filter_Sigma2", Filter_Sigma2);

                Big_CMD.Read(ini, tmp_section + "/Big_CMD");
                Big_CMD.In.Values_Count = 0;
                Big_CMD.In.Add(emValue_Type.Image, "In_Image", "In Image", "In_Image", null);
                Big_CMD.In.Add(emValue_Type.Region, "In_Region", "In Region", "In_Region", null);
                Big_CMD.Out.Values_Count = 0;
                Big_CMD.Out.Add(emValue_Type.Region, "Out_Region", "Out Region", "Out_Region", null);

                Small_CMD.Read(ini, tmp_section + "/Small_CMD");
                Small_CMD.In.Values_Count = 0;
                Small_CMD.In.Add(emValue_Type.Image, "In_Image", "In Image", "In_Image", null);
                Small_CMD.In.Add(emValue_Type.Region, "In_Region", "In Region", "In_Region", null);
                Small_CMD.Out.Values_Count = 0;
                Small_CMD.Out.Add(emValue_Type.Region, "Out_Region", "Out Region", "Out_Region", null);
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);
                ini.WriteFloat(section, "Filter_Sigma1", Filter_Sigma1);
                ini.WriteFloat(section, "Filter_Sigma2", Filter_Sigma2);

                Big_CMD.Write(ini, tmp_section + "/Big_CMD");
                Small_CMD.Write(ini, tmp_section + "/Small_CMD");
            }
        }
        override public void Read_Other_File()
        {
            string filename;

            Find_Region.Read(Find_Region.Default_Path + Find_Region.Default_FileName);
            Update();
        }
        override public void Write_Other_File()
        {
            Find_Region.Write(Find_Region.Default_Path + Find_Region.Default_FileName);
        }
        override public bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_AOI_Glass form = new TForm_AOI_Glass();

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
            return result;
        }
        public bool Get_Defect(HImage in_image, ref TAOI_Glass_Result f_result)
        {
            bool result = false;

            HRegion region_big = new HRegion();
            HRegion region_small = new HRegion();
            if (JJS_Vision.Is_Not_Empty(in_image))
            {
                f_result.Image_Sample = in_image.Clone();
                f_result.Image_Filter = Get_Filter(in_image);
                f_result.Image_Defect = Get_Defect_Image(in_image, f_result.Image_Filter);
                Run_Process(f_result.Image_Sample, Big_CMD, Find_Region.Region, ref f_result.Region_Big_Defect);
                Run_Process(f_result.Image_Sample, Small_CMD, Find_Region.Region, ref f_result.Region_Small_Defect);

                f_result.Region_Defect.GenEmptyRegion();
                if (JJS_Vision.Is_Not_Empty(f_result.Region_Big_Defect)) f_result.Region_Defect = f_result.Region_Defect.Union2(f_result.Region_Big_Defect);
                if (JJS_Vision.Is_Not_Empty(f_result.Region_Small_Defect)) f_result.Region_Defect = f_result.Region_Defect.Union2(f_result.Region_Small_Defect);
                f_result.Region_Defect = f_result.Region_Defect.Connection();
            }
            return result;
        }
        public void Init()
        {
            Code_Handle.CreateDataCode2dModel("Data Matrix ECC 200", "default_parameters", "enhanced_recognition");
            Code_Handle.SetDataCode2dParam("contrast_tolerance", "high");
            Init_Flag = true;
        }
        public void Update()
        {
        }
        public bool Run_Process(HImage in_image, TCommand_Define cmd, HRegion in_region, ref HRegion out_region)
        {
            bool result = true;
            Command_Manager manager = new Command_Manager();
            TTool_Values tool_values = new TTool_Values();

            manager.Register_All_Command();
            manager.Register_User_Command(cmd.User_Cmd_List);
            tool_values.Add_Value(cmd.In);
            tool_values.Add_Value_Out(cmd.Out);
            tool_values.Set_Image("In_Image", in_image);
            tool_values.Set_Region("In_Region", in_region);
            result = manager.Execute(cmd, ref tool_values);
            if (result) out_region = tool_values.Get_Value_Region("Out_Region");
            return result;
        }
        public HImage Get_Defect_Image(HImage in_image)
        {
            HImage image_filter = Get_Filter(in_image);
            return Get_Defect_Image(in_image, image_filter);
        }
        public HImage Get_Defect_Image(HImage in_image, HImage image_filter)
        {
            HImage result = new HImage();
            HImage tmp_image = new HImage();
            HImage image_fft = new HImage();
            HImage image_cov = new HImage();
            HImage image_temp = new HImage();
            int width = 0;
            int height = 0;

            tmp_image = in_image.Clone();
            tmp_image.GetImageSize(out width, out height);
            image_fft = tmp_image.RftGeneric("to_freq", "none", "complex", width);
            image_cov = image_fft.ConvolFft(image_filter);
            result = image_cov.RftGeneric("from_freq", "n", "real", width);
            result = JJS_Vision.Scale_Image_EFC(result);
            return result;
        }
        private HImage Get_Filter(HImage in_image)
        {
            int w, h;

            in_image.GetImageSize(out w, out h);
            return Get_Filter(w, h, Filter_Sigma1, Filter_Sigma2);
        }



        private HImage Get_Filter(int width,int height, double sigma1, double sigma2)
        {
            HImage result = new HImage();
            HImage image_gauss1 = new HImage();
            HImage image_gauss2 = new HImage();

            image_gauss1.GenGaussFilter(sigma1, sigma1, 0.0, "none", "rft", width, height);
            image_gauss2.GenGaussFilter(sigma2, sigma2, 0.0, "none", "rft", width, height);
            result = image_gauss1.SubImage(image_gauss2, 1.0, 0.0);
            return result;
        }
        private bool Get_Big_Defect(HImage in_image, ref HRegion out_region)
        {
            bool result = false;

            HRegion region = new HRegion();
            HRegion tmp_region = new HRegion();

            region = in_image.Threshold(0.0, 40.0);
            tmp_region = region.DilationCircle(5.0);
            tmp_region = tmp_region.ErosionCircle(5.0);
            tmp_region = tmp_region.Connection();
            tmp_region = tmp_region.SelectShape("contlength", "and", 5, 99999);
            out_region = region.Intersection(tmp_region);

            return result;
        }
        private bool Get_Small_Defect(HImage in_image, ref HRegion out_region)
        {
            bool result = false;

            HRegion region = new HRegion();
            HRegion tmp_region = new HRegion();

            region = in_image.Threshold(0.0, 80.0);

            tmp_region = region.DilationCircle(10.0);
            tmp_region = tmp_region.ErosionCircle(10.0);
            tmp_region = tmp_region.Connection();
            tmp_region = tmp_region.SelectShape("contlength", "and", 100, 99999);
            out_region = region.Intersection(tmp_region);

            return result;
        }

        
        
        public void Get_Images_Form_Path(string path, ref HImage out_images, ProgressBar progressBar1 = null)
        {
            ArrayList file_list = null;
            HImage tmp_image = new HImage();
            TAOI_Glass_Result f_result = new TAOI_Glass_Result();
            bool image_ok_flag = true;
            int count, add_count;
            string msg = "";

            file_list = Get_Image_Files(path, ".jpg");
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

                if (image_ok_flag)
                {
                    if (add_count == 0) out_images = tmp_image.Clone();
                    else out_images = out_images.AppendChannel(tmp_image);
                    add_count++;
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
    public class TAOI_Glass_Result : TBase_Result
    {
        public HImage                  Image = new HImage();
        public HRegion                 Find_Region = new HRegion();
        public HRegion                 Defect_Region = new HRegion();
        public HImage                  Image_Sample = new HImage();
        public HImage                  Image_Filter = new HImage();
        public HImage                  Image_Defect = new HImage();
        public HRegion                 Region_Big_Defect = new HRegion();
        public HRegion                 Region_Small_Defect = new HRegion();
        public HRegion                 Region_Defect = new HRegion();


        public TAOI_Glass_Disp_Param   Disp_Param = new TAOI_Glass_Disp_Param();

        public TAOI_Glass_Result()
        {
             Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAOI_Glass_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAOI_Glass_Result && dis_base is TAOI_Glass_Result)
            {

                TAOI_Glass_Result sor = (TAOI_Glass_Result)sor_base;
                TAOI_Glass_Result dis = (TAOI_Glass_Result)dis_base;

                base.Copy(sor, dis);
                if (JJS_Vision.Is_Not_Empty(sor.Image)) dis.Image = sor.Image.Clone();
                if (JJS_Vision.Is_Not_Empty(sor.Find_Region)) dis.Find_Region = sor.Find_Region.Clone();
                if (JJS_Vision.Is_Not_Empty(sor.Defect_Region)) dis.Defect_Region = sor.Defect_Region.Clone();
            }
        }


        override public void Set_Default()
        {
            base.Set_Default();
            Find_OK = false;
            Find_Region.GenEmptyRegion();
            Defect_Region.GenEmptyRegion();
            Disp_Param.Msg_X = 300;
            Disp_Param.Msg_Y = 300;
            Disp_Param.Msg_Font_Size = 100;
        }
        override public void Reset()
        {
            Find_OK = false;
            Find_Region.GenEmptyRegion();
            Defect_Region.GenEmptyRegion();

            Image.Dispose();
            Image = new HImage();
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
        override public void Display_Message(HWindowControl hw)
        {
        }
        override public void Display_Model(HWindowControl hw)
        {
            Display(hw, Disp_Param.Display_Index);
        }
        override public string Get_Message()
        {
            string result = "";

            //if (Find_OK) result = "OK";
            //else result = "NG";
            return result;
        }

        private void Display(HWindowControl hw, int index)
        {
            hw.HalconWindow.ClearWindow();
            switch (index)
            {
                case 0:
                    Disp_Image(hw, Image_Sample);
                    break;

                case 1:
                    //Disp_Image(hw, Image_Filter);
                    break;

                case 2:
                    Disp_Image(hw, Image_Defect);
                    break;
            }

            if (Disp_Param.Disp_Big_Defect && Disp_Param.Disp_Small_Defect) Disp_Region(hw, Region_Defect);
            else if (Disp_Param.Disp_Big_Defect && !Disp_Param.Disp_Small_Defect) Disp_Region(hw, Region_Big_Defect);
            else if (!Disp_Param.Disp_Big_Defect && Disp_Param.Disp_Small_Defect) Disp_Region(hw, Region_Small_Defect);
        }
        private void Disp_Image(HWindowControl hw, HImage in_image)
        {
            if (JJS_Vision.Is_Not_Empty(in_image))
            {
                hw.HalconWindow.DispObj(in_image);
            }
        }
        public void Disp_Region(HWindowControl hw, HRegion in_region)
        {
            if (JJS_Vision.Is_Not_Empty(in_region))
            {
                hw.HalconWindow.SetDraw(emSetDraw.margin);
                hw.HalconWindow.SetColored(12);
                hw.HalconWindow.SetLineWidth(1);

                hw.HalconWindow.DispObj(in_region);
            }
        }

    }
    public class TAOI_Glass_Disp_Param : TBase_Disp_Param
    {
        public bool Disp_Big_Defect = true;
        public bool Disp_Small_Defect = true;
        public int Display_Index = 0;

    }
}
