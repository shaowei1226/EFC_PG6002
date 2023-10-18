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
    public partial class TForm_ACF_Check : Form
    {
        public TACF_Check_Param          Param = new TACF_Check_Param();
        public HImage                    Sample_Image = new HImage();
        public HImage                    Tmp_Sample_Image = new HImage();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;

        public HImage Base_Image
        {
            get
            {
                return Param.Image_Base;
            }
        }
        public int Image_Width
        {
            get
            {
                int w = 640, h = 480;
                if (JJS_Vision.Is_Not_Empty(Sample_Image)) Sample_Image.GetImageSize(out w, out h);
                return w;
            }
        }
        public int Image_Height
        {
            get
            {
                int w = 640, h = 480;
                if (JJS_Vision.Is_Not_Empty(Sample_Image)) Sample_Image.GetImageSize(out w, out h);
                return h;
            }
        }
        public TForm_ACF_Check()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        public void Set_Param(HImage image, TACF_Check_Param param)
        {
            JJS_Vision.Copy_Obj(image, ref Sample_Image);
            Param.Set(param);
            Set_Param();
        }
        public void Set_Param()
        {
            Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Base_Image), Color.PaleTurquoise, Color.Transparent);
            Form_Tool.Set_Button_Face(B_Trans_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.PaleTurquoise, Color.Transparent);

            CB_Used_Align_Image.Checked = Param.Align_Image_Flag;
            B_Edit_Model_Param.Enabled = CB_Used_Align_Image.Checked;
            E_Std_Ofs.Text = Param.Std_Ofs.ToString("0.00");
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
            Param.Std_Ofs = Convert.ToDouble(E_Std_Ofs.Text);
            Param.Update();
        }
        private void Form_Find_Barcode1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (JJS_Vision.Is_Not_Empty(Base_Image)) tFrame_JJS_HW1.HW_Buf.HalconWindow.DispObj(Base_Image);


            JJS_HW.SetPart(Sample_Image);
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
        public void Disp_Region(HWindowControl hw, HRegion region)
        {
            if (JJS_Vision.Is_Not_Empty(region))
            {
                hw.HalconWindow.DispObj(region);
            }
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
            if (JJS_Vision.Is_Not_Empty(image))
            {
                JJS_HW.SetPart(image);
                hw.HalconWindow.ClearWindow();
                hw.HalconWindow.DispObj(image);
                hw.HalconWindow.SetColored(12);
                hw.HalconWindow.SetLineWidth(5);
                hw.HalconWindow.SetDraw("margin");
                hw.HalconWindow.SetColor("red");
                Param.Find_Region.DispObj(hw.HalconWindow);
                JJS_HW.Copy_HW();
            }
        }
        public void Update_View()
        {
            bool flag = true;
            HRegion tmp_region = new HRegion();
            HImage tmp_image = new HImage();
            TAlign_Image_XYQ_Result f_result = new TAlign_Image_XYQ_Result();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(5);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                if (Step == 0) Disp_Image(JJS_HW.HW_Buf, Sample_Image, true);

                #region Step1 Make Gold Image
                if (Step >= 1 && flag)
                {
                    if (Step == 1) Disp_Image(JJS_HW.HW_Buf, Param.Image_Avg);
                }
                #endregion


                #region Step2 Set Create Check Region
                if (Step >= 2 && flag)
                {
                    if (Step == 2)
                    {
                        Disp_Image(JJS_HW.HW_Buf, Param.Image_Avg);
                        Disp_Region(JJS_HW.HW_Buf, Param.Find_Region);
                    }
                }
                #endregion

                #region Step3 Align Param
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        Disp_Image(JJS_HW.HW_Buf, Sample_Image);
                    }
                }
                #endregion

                #region Step4 Align Param Result
                if (Step >= 4 && flag)
                {
                    if (Param.Align_Image_Flag)
                    {
                        TBase_Result base_result = f_result;
                        if (Param.Align_Param.Trans(Sample_Image, ref base_result))
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

                    if (Step == 4)
                    {
                        Disp_Image(JJS_HW.HW_Buf, Tmp_Sample_Image);
                    }
                }
                #endregion

                #region Step5 Select Test Region
                if (Step >= 5 && flag)
                {
                    if (Step == 5)
                    {
                        if (Param.Run_Process(Tmp_Sample_Image, Param.Find_Region, ref tmp_region))
                        {
                            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                            if (JJS_Vision.Is_Not_Empty(Tmp_Sample_Image)) 
                                Tmp_Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);

                            if (JJS_Vision.Is_Not_Empty(tmp_region)) 
                                tmp_region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        }
                        else flag = false;
                    }
                }
                #endregion

                #region Step6 Set Find Param
                if (Step >= 6 && flag)
                {
                    TACF_Check_Result ff_result = new TACF_Check_Result();
                    Param.Find_Base(Sample_Image, ref ff_result);
                    if (JJS_Vision.Is_Not_Empty(Sample_Image)) Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    ff_result.Display(JJS_HW.HW_Buf);
                }
                #endregion

                JJS_HW.Copy_HW();
            }
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
        }
        private void TP_Space_Enter(object sender, EventArgs e)
        {
            Control obj = (Control)sender;
            Step = Convert.ToInt32((string)obj.Tag);
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
            form.Org_Tool_Values.Add_Value(Param.Process.In);
            form.Org_Tool_Values.Add_Value_Out(Param.Process.Out);
            form.Org_Tool_Values.Set_Image("In_Image", Tmp_Sample_Image);
            form.Org_Tool_Values.Set_Image("Min_Image", Param.Image_Min);
            form.Org_Tool_Values.Set_Image("Max_Image", Param.Image_Max);
            form.Org_Tool_Values.Set_Region("In_Region", Param.Find_Region);
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

            JJS_Vision.Copy_Obj(Param.Image_Avg, ref form.Image);
            JJS_Vision.Copy_Obj(Param.Find_Region, ref form.Select_Region);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Find_Region = form.Select_Region.Clone();
                Update_View();
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
            Draw_Image(Param.Image_Min);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Draw_Image(Param.Image_Max);
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
        private void E_Base_Image_File_TextChanged(object sender, EventArgs e)
        {

        }
        private void button11_Click(object sender, EventArgs e)
        {
            Param.Mark_Golden_Image(ref Param.Image_Avg, ref Param.Image_Std, progressBar1);
            Update_View();
        }
        private void B_Save_To_OK_Image_Click(object sender, EventArgs e)
        {
            string filename = Param.Get_New_OK_Image_File_Name();

            JJS_Vision.Write_File(Sample_Image, filename);
        }
        private void B_Copy_Base_Click(object sender, EventArgs e)
        {
            string filename = Param.Image_Base_File_Name_Full;

            JJS_Vision.Write_File(Sample_Image, Param.Image_Base_File_Name_Full);
            JJS_Vision.Write_File(Sample_Image, Param.Align_Param.Base_Image_Full_File_Name);
            Set_Param();
        }

    }
    public class TACF_Check_Param : TBase_Param
    {
        public static HDataCode2D      Code_Handle = new HDataCode2D();
        public static bool             Init_Flag = false;

        public bool                    Align_Image_Flag = false;
        public TAlign_Image_XYQ_Param  Align_Param = new TAlign_Image_XYQ_Param();
        public HRegion                 Find_Region = new HRegion();
        public string                  Find_Region_File_Name = "Check_Region.rgn";
        public TCommand_Define         Process = new TCommand_Define();
        public double                  Std_Ofs = 1;

        public HImage                  Image_Base = new HImage();
        public string                  Image_Base_File_Name = "Image_Base.bmp";

        public HImage                  Image_Avg = new HImage();
        public HImage                  Image_Std = new HImage();
        public HImage                  Image_Min = new HImage();
        public HImage                  Image_Max = new HImage();

        public string Find_Region_File_Name_Full
        {
            get
            {
                return Default_Path + Find_Region_File_Name;
            }
        }
        public string OK_Image_Path
        {
            get
            {
                return Default_Path + "OK_Image\\";
            }
        }
        public string Image_Base_File_Name_Full
        {
            get
            {
                return Default_Path + Image_Base_File_Name;
            }
        }
        public string Golden_Avg_File_Name_Full
        {
            get
            {
                return Default_Path + "Golden_Avg.bmp";
            }
        }
        public string Golden_Std_File_Name_Full
        {
            get
            {
                return Default_Path + "Golden_Std.bmp";
            }
        }
        public TACF_Check_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            TBase_Class result = new TACF_Check_Param();
            return result;
        }
        override public TBase_Result New_Base_Result()
        {
            TBase_Result result = new TACF_Check_Result();
            return result;
        }
        override public void Copy(TBase_Class base_sor, TBase_Class base_dis)
        {
            if (base_sor is TACF_Check_Param && base_dis is TACF_Check_Param)
            {
                TACF_Check_Param sor = (TACF_Check_Param)base_sor;
                TACF_Check_Param dis = (TACF_Check_Param)base_dis;
                base.Copy(sor, dis);

                dis.Align_Image_Flag = sor.Align_Image_Flag;
                dis.Std_Ofs = sor.Std_Ofs;
                dis.Align_Param.Set(sor.Align_Param);
                JJS_Vision.Copy_Obj(sor.Find_Region, ref dis.Find_Region);
                dis.Process.Set(sor.Process);
                JJS_Vision.Copy_Obj(sor.Image_Base, ref dis.Image_Base);
                JJS_Vision.Copy_Obj(sor.Image_Avg, ref dis.Image_Avg);
                JJS_Vision.Copy_Obj(sor.Image_Std, ref dis.Image_Std);
                JJS_Vision.Copy_Obj(sor.Image_Min, ref dis.Image_Min);
                JJS_Vision.Copy_Obj(sor.Image_Max, ref dis.Image_Max);
            }
        }
        override public void Set_Default()
        {
            Align_Image_Flag = false;
            Std_Ofs = 0;
            Align_Param.Set_Default();
            Find_Region.GenEmptyRegion();
            Process.Set_Default();
            Image_Avg = new HImage();
            Image_Std = new HImage();
            Image_Min = new HImage();
            Image_Max = new HImage();
        }
        override public void Set_Default_Path(string default_path)
        {
            In_Default_Path = default_path;

            Align_Param.Default_Path = default_path + "Align_Param\\";
            Align_Param.Model1.JJS_Model.Default_Path = Align_Param.Default_Path + "Align_Param\\";
            Align_Param.Model1.JJS_Model.Default_FileName = "Model1.mod";
            Align_Param.Model2.JJS_Model.Default_Path = Align_Param.Default_Path + "Align_Param\\";
            Align_Param.Model2.JJS_Model.Default_FileName = "Model2.mod";
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                Align_Image_Flag = ini.ReadBool(tmp_section, "Align_Image_Flag", false);
                Std_Ofs = ini.ReadFloat(tmp_section, "Std_Ofs", 1.0);
                Align_Param.Read(ini, tmp_section + "/Model_Param");
                Process.Read(ini, tmp_section + "/Process");
                Process.In.Values_Count = 0;
                Process.In.Add(emValue_Type.Image, "In_Image", "In Image", "In_Image", null);
                Process.In.Add(emValue_Type.Image, "Min_Image", "Min Image", "Min_Image", null);
                Process.In.Add(emValue_Type.Image, "Max_Image", "Max Image", "Max_Image", null);
                Process.In.Add(emValue_Type.Region, "In_Region", "In Region", "In_Region", null);
                Process.Out.Values_Count = 0;
                Process.Out.Add(emValue_Type.Region, "Out_Region", "Out Region", "Out_Region", null);
            }
            Read_Other_File();
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);

                ini.WriteBool(tmp_section, "Align_Image_Flag", Align_Image_Flag);
                ini.WriteFloat(tmp_section, "Std_Ofs", Std_Ofs);
                Align_Param.Write(ini, tmp_section + "/Model_Param");
                Process.Write(ini, tmp_section + "/Process");
            }
            Write_Other_File();
        }
        override public void Read_Other_File()
        {
            Align_Param.Read_Other_File();
            JJS_Vision.Read_File(ref Find_Region, Find_Region_File_Name_Full);
            JJS_Vision.Read_File(ref Image_Base, Image_Base_File_Name_Full);
            JJS_Vision.Read_File(ref Image_Avg, Golden_Avg_File_Name_Full);
            JJS_Vision.Read_File(ref Image_Std, Golden_Std_File_Name_Full);
            Update();
        }
        public override void Write_Other_File()
        {
            Align_Param.Write_Other_File();
            JJS_Vision.Write_File(Find_Region, Find_Region_File_Name_Full);
        }
        public void Write_Golden_File()
        {
            JJS_Vision.Write_File(Image_Avg, Golden_Avg_File_Name_Full);
            JJS_Vision.Write_File(Image_Std, Golden_Std_File_Name_Full);
        }
        public void Log_Diff(TLog log, string section, TACF_Check_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Align_Image_Flag", Align_Image_Flag, new_value.Align_Image_Flag, ref flag);
            Align_Param.Log_Diff(log, section + "/Align_Param", new_value.Align_Param, ref flag);
            //Process.Log_Diff(log, section + "/Process", new_value.Process, ref flag);
            log.Log_Diff(section + "/Std_Ofs", Std_Ofs, new_value.Std_Ofs, ref flag);
        }





        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_ACF_Check form = new TForm_ACF_Check();

            form.Set_Param(image, this);
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

            if (f_result is TACF_Check_Result)
            {
                TACF_Check_Result in_result = (TACF_Check_Result)f_result;
                result = Find_Base(image, ref in_result);
            }
            return result;
        }
        public bool Find_Base(HImage image, ref TACF_Check_Result f_result)
        {
            bool result = false;

            TAlign_Image_XYQ_Result al_result = new TAlign_Image_XYQ_Result();
            HRegion find_region = new HRegion();
            HImage tmp_image = new HImage();

            f_result.Reset();
            JJS_Vision.Copy_Obj(Find_Region, ref  f_result.Find_Region);
            if (Align_Image_Flag)
            {
                if (Align_Param.Find_Base(image, ref al_result))
                {
                    tmp_image = ((TAlign_Image_XYQ_Result)al_result).Image.Clone();
                }
                else
                {
                    tmp_image = image.Clone();
                }
            }
            else tmp_image = image.Clone();

            f_result.Image = tmp_image.Clone();
            if (Run_Process(tmp_image, Find_Region, ref f_result.Defect_Region))
            {
                if (JJS_Vision.Is_Not_Empty(f_result.Defect_Region))
                {
                    if (f_result.Defect_Region.CountObj() > 0) f_result.Find_OK = false;
                    else f_result.Find_OK = true;
                }
                else f_result.Find_OK = true;
            }

            if (JJS_Vision.Is_Not_Empty(f_result.Defect_Region))
                f_result.Defect_Region = JJS_Vision.Affine_Trans_Region(f_result.Defect_Region, 0, 0, 0, al_result.Sample_Col, al_result.Sample_Row, al_result.Sample_Angle);

            result = f_result.Find_OK;
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
            HImage tmp_std_image = new HImage();

            Align_Param.Update();
            if (JJS_Vision.Is_Not_Empty(Image_Avg) && JJS_Vision.Is_Not_Empty(Image_Std))
            {
                tmp_std_image = Image_Std.GenImageProto(1.0);
                tmp_std_image = Image_Std.MultImage(tmp_std_image, Std_Ofs, 0);
                Image_Min = Image_Avg.SubImage(tmp_std_image, 1.0, 0);
                Image_Max = Image_Avg.AddImage(tmp_std_image, 1.0, 0);
            }
            tmp_std_image.Dispose();
        }
        public bool Run_Process(HImage in_image, HRegion in_region, ref HRegion out_region)
        {
            bool result = true;
            Command_Manager manager = new Command_Manager();
            TTool_Values tool_values = new TTool_Values();
            TCommand_Define cmd = null;

            cmd = Process;
            manager.Register_All_Command();
            manager.Register_User_Command(cmd.User_Cmd_List);
            tool_values.Add_Value(cmd.In);
            tool_values.Add_Value_Out(cmd.Out);
            tool_values.Set_Image("In_Image", in_image);
            tool_values.Set_Image("Min_Image", Image_Min);
            tool_values.Set_Image("Max_Image", Image_Max);
            tool_values.Set_Region("In_Region", in_region);
            result = manager.Execute(cmd, ref tool_values);
            if (result) out_region = tool_values.Get_Value_Region("Out_Region");
            return result;
        }

        
        
        public void Get_Images_Form_Path(string path, ref HImage out_images, ProgressBar progressBar1 = null)
        {
            ArrayList file_list = null;
            HImage tmp_image = new HImage();
            TAlign_Image_XYQ_Result f_result = new TAlign_Image_XYQ_Result();
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
                }

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
        public void Get_Images_N(HImage in_images, ref HImage avg, ref HImage std)
        {
            if (JJS_Vision.Is_Not_Empty(in_images))
            {
                avg = in_images.MeanN();
                std = in_images.DeviationN();
            }
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
        public void Mark_Golden_Image(ref HImage avg_image, ref HImage std_image, ProgressBar progressBar1 = null)
        {
            HImage images = new HImage();

            Get_Images_Form_Path(OK_Image_Path, ref images, progressBar1);
            Get_Images_N(images, ref avg_image, ref std_image);
            Write_Golden_File();
        }
        public string Get_New_OK_Image_File_Name()
        {
            string result = "";
            bool flag = true;
            int no = 1;

            while (flag)
            {
                result = OK_Image_Path + string.Format("OK_Image{0:d3}.jpg", no);
                flag = System.IO.File.Exists(result);
                no++;
            }
            return result;
        }
    }
    public class TACF_Check_Result : TBase_Result
    {
        public HImage                  Image = new HImage();
        public HRegion                 Find_Region = new HRegion();
        public HRegion                 Defect_Region = new HRegion();
        public TBase_Disp_Param        Disp_Param = new TBase_Disp_Param();


        public TACF_Check_Result()
        {
             Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TACF_Check_Result();
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
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TACF_Check_Result && dis_base is TACF_Check_Result)
            {
                TACF_Check_Result sor = (TACF_Check_Result)sor_base;
                TACF_Check_Result dis = (TACF_Check_Result)dis_base;
                base.Copy(sor, dis);

                if (JJS_Vision.Is_Not_Empty(sor.Image)) dis.Image = sor.Image.Clone();
                if (JJS_Vision.Is_Not_Empty(sor.Find_Region)) dis.Find_Region = sor.Find_Region.Clone();
                if (JJS_Vision.Is_Not_Empty(sor.Defect_Region)) dis.Defect_Region = sor.Defect_Region.Clone();
            }
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
        override public void Read_Other_File()
        {

        }
        override public void Write_Other_File()
        {

        }
        override public void Display_Message(HWindowControl hw)
        {
            string color = "";

            if (Find_OK) color = Disp_Param.Model_Color_OK;
            else color = Disp_Param.Model_Color_NG;

            if (Find_OK)
            {
                JJS_Vision.Display_String(hw, "OK", Disp_Param.Msg_X, Disp_Param.Msg_Y, Disp_Param.Msg_Font_Size, 1, color);
            }
            else
            {
                JJS_Vision.Display_String(hw, "NG", Disp_Param.Msg_X, Disp_Param.Msg_Y, Disp_Param.Msg_Font_Size, 1, color);
            }
        }
        override public void Display_Model(HWindowControl hw)
        {
            string color = "";

            if (Find_OK) color = Disp_Param.Model_Color_OK;
            else color = Disp_Param.Model_Color_NG;

            hw.HalconWindow.SetColor(color);
            if (JJS_Vision.Is_Not_Empty(Defect_Region)) Defect_Region.DispObj(hw.HalconWindow);
        }
        override public string Get_Message()
        {
            string result = "";

            if (Find_OK) result = "OK";
            else result = "NG";
            return result;
        }
        public void Display(HWindowControl hw)
        {
        }
    }
}
