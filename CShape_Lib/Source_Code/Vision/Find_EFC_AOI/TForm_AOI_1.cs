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
    public partial class TForm_AOI_1 : Form
    {
        public string           Default_Path;
        public HImage           Image2 = new HImage();

        public HImage           Diff_Image = new HImage();
        public HImage           Sub_Image_Light = new HImage();
        public HImage           Sub_Image_Dark = new HImage();
        public HRegion          Select_Region = new HRegion();

        public HImage           Filter_Image = new HImage();
        public HRegion          Filter_Region = new HRegion();

        public string           Golden_Image_File,
                                Sample_Image_File;
        public TAOI_1_Param     Param = new TAOI_1_Param();
        public TAOI_1_Result    Result_Find = new TAOI_1_Result();
        public int              Step;
        public TFrame_JJS_HW    JJS_HW;
        public double           Disp_Scale = 1.0;
        public bool             On_Set_Param = false;


        public TForm_AOI_1()
        {
            InitializeComponent();
            Param = new TAOI_1_Param();
            JJS_HW = tFrame_JJS_HW1;
            Step = 0;
            Golden_Image_File = "";
            Sample_Image_File = "";
        }
        private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
        {
            tFrame_JJS_HW1.SetPart();
            tFrame_JJS_HW1.Copy_HW();
        }
        private void TForm_AOI_1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            E_Sample_Image_File.Text = Sample_Image_File;
            if (TJJS_Vision.Is_Not_Empty(Image2)) B_Sample_Image.BackColor = Color.LightGreen;
            if (TJJS_Vision.Is_Not_Empty(Param.Image_Avg))
            {
                JJS_HW.SetPart(Param.Image_Avg);
                JJS_HW.HW_Buf.HalconWindow.DispObj(Param.Image_Avg);
                JJS_HW.Copy_HW();
            }
        }
        public void Set_Param(TAOI_1_Param param)
        {
            On_Set_Param = true;

            Param = param.Copy();
            E_Info.Text = Param.Info;

            E_Std_Scale.Text = Param.Std_Scale.ToString("0.00");
            Set_Param_Image_Pre_Process();
            Set_Param_Region_Process();

            On_Set_Param = false;
        }
        public void Set_Param_Image_Pre_Process()
        {
            ListBox lb = null;

            lb = LB_Image_Pre_Process;
            lb.Items.Clear();
            for (int i = 0; i < Param.Image_Pre_Process.Programs_List.Count; i++)
            {
                lb.Items.Add(Param.Image_Pre_Process.Programs_List[i].ToString());
            }
            if (lb.Items.Count > 0) lb.SelectedIndex = 0;
        }
        public void Set_Param_Region_Process()
        {
            ListBox lb = null;

            lb = LB_Region_Process;
            lb.Items.Clear();
            for (int i = 0; i < Param.Region_Process.Programs_List.Count; i++)
            {
                lb.Items.Add(Param.Region_Process.Programs_List[i].ToString());
            }
            if (lb.Items.Count > 0) lb.SelectedIndex = 0;
        }
        public void Update_Param()
        {
            Param.Info = E_Info.Text;
            Param.Std_Scale = Convert.ToDouble(E_Std_Scale.Text);
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Finish_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.InitialDirectory = Param.Default_Path;
            dialog.Filter = "AOI Param File(*.xml)|*.xml";
            dialog.FileName = Param.Default_FileName;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Update_Param();
                Param.Write(dialog.FileName);
            }
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
        public void Draw_Region(HRegion region)
        {
            try
            {
                if (region != null)
                {
                    HW_SetColored(JJS_HW.HW_Buf);
                    HW_SetDraw(JJS_HW.HW_Buf);
                    HW_Set_Line_Width(JJS_HW.HW_Buf);

                    JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                    region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    JJS_HW.Copy_HW();
                }
            }
            catch 
            { 
            }
        }
        private void B_Golden_Image_Click(object sender, EventArgs e)
        {
        }
        private void B_Golden_Min_Click(object sender, EventArgs e)
        {
            Draw_Image(Param.Image_Min);
        }
        private void B_Golden_Max_Click(object sender, EventArgs e)
        {
            Draw_Image(Param.Image_Max);
        }
        private void B_Golden_Avg_Click(object sender, EventArgs e)
        {
            Draw_Image(Param.Image_Avg);
        }
        private void B_Golden_Std_Click(object sender, EventArgs e)
        {
            Draw_Image(Param.Image_Std);
        }
        private void B_Disp_Sample_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Disp_Result_Click(object sender, EventArgs e)
        {
            Disp_Result();
        }
        private void B_Sample_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Disp_Region_Click(object sender, EventArgs e)
        {
            Draw_Image(Param.Image_Avg);
            Draw_Region(Param.Test_Region.Region);
        }
        private void B_Create_Region_Click(object sender, EventArgs e)
        {
            TForm_Select_Area form = new TForm_Select_Area();
            form.Image = Param.Image_Avg.Clone();
            form.Select_Region = Param.Test_Region.Region.CopyObj(1, -1);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Test_Region.Region = form.Select_Region.Clone();
                Draw_Image(Param.Image_Avg);
                Draw_Region(Param.Test_Region.Region);
            }
        }
        private void B_Select_Sample_File_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Sample_Image_File.Text = dialog.FileName;
                Image2.ReadImage(E_Sample_Image_File.Text);
                B_Sample_Image.BackColor = Color.LightGreen;
                Draw_Image(Image2);
            }
        }
        public void Update_View()
        {
            bool flag=true;

            HImage tmp_image = new HImage();
            HImage image2 = new HImage();
            HRegion region1 = new HRegion();
            HRegion get_region = new HRegion();
            TAlign_Mothed_3_Result f_result = new TAlign_Mothed_3_Result();

            Select_Region.GenEmptyRegion();
            Update_Param();
            if (true) 
            {
                Disp_Scale = TJJS_Vision.Get_Scale(Param.Image_Avg);
                JJS_HW.HW_Buf.HalconWindow.ClearWindow();

                if (TJJS_Vision.Is_Empty(Image2)) 
                    flag = false;

                #region Step1 display image
                if (Step >= 1)
                {
                    if (flag)
                    {
                        image2 = Image2.Clone();
                    }
                    if (Step == 1)
                    {
                        JJS_HW.HW_Buf.HalconWindow.DispObj(Param.Image_Avg);
                    }
                }
                #endregion 

                #region Step2 Edit AOI Region Param
                if (Step >= 2)
                {
                    if (Step == 2)
                    {
                        HW_SetColored(JJS_HW.HW_Buf);
                        HW_Set_Line_Width(JJS_HW.HW_Buf);
                        HW_SetDraw(JJS_HW.HW_Buf);
                        JJS_HW.HW_Buf.HalconWindow.DispObj(Param.Image_Avg);
                        JJS_HW.HW_Buf.HalconWindow.DispObj(Param.Test_Region.Region);
                    }
                }
                #endregion

                #region Step3 Image Pre Process
                if (Step >= 3)
                {
                    TAOI_1.Run_Image_Pre_Process(Param, image2, ref Sub_Image_Light, ref Sub_Image_Dark);

                    if (TJJS_Vision.Is_Empty(Sub_Image_Light)) flag = false;
                    if (Step == 3)
                    {
                        HW_SetColored(JJS_HW.HW_Buf);
                        HW_Set_Line_Width(JJS_HW.HW_Buf);
                        HW_SetDraw(JJS_HW.HW_Buf);
                        if (flag && RB_Disp_Image_Light.Checked) JJS_HW.HW_Buf.HalconWindow.DispObj(Sub_Image_Light);
                        if (flag && RB_Disp_Image_Dark.Checked) JJS_HW.HW_Buf.HalconWindow.DispObj(Sub_Image_Dark);
                    }
                }
                #endregion

                #region Step4 display sub image
                if (Step >= 4 && flag)
                {
                    flag = TAOI_1.Run_Region_Process(Param, Sub_Image_Light, Sub_Image_Dark, ref region1);
                    if (Step == 4)
                    {
                        HW_SetColored(JJS_HW.HW_Buf);
                        HW_Set_Line_Width(JJS_HW.HW_Buf);
                        HW_SetDraw(JJS_HW.HW_Buf);
                        if (RB_Disp_Image_Light.Checked) JJS_HW.HW_Buf.HalconWindow.DispObj(Sub_Image_Light);
                        if (RB_Disp_Image_Dark.Checked) JJS_HW.HW_Buf.HalconWindow.DispObj(Sub_Image_Dark);
                        
                        if (flag)
                        {
                            if (TJJS_Vision.Is_Not_Empty(region1)) JJS_HW.HW_Buf.HalconWindow.DispObj(region1);
                        }
                    }
                }
                #endregion
           
                #region Step5
                if (Step >= 5 && flag)
                {
                    TAOI_1.Find(Image2, Param, ref Result_Find);
                    Disp_Result();
                }
                #endregion

                JJS_HW.Copy_HW();
            }
        }
        public void Disp_Result()
        {
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            HW_SetColored(JJS_HW.HW_Buf);
            HW_Set_Line_Width(JJS_HW.HW_Buf);
            Result_Find.Disp_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);

            HW_SetDraw(JJS_HW.HW_Buf);
            JJS_HW.HW_Buf.HalconWindow.SetColor("red");
            Result_Find.Disp_Region.DispObj(JJS_HW.HW_Buf.HalconWindow);

            JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
            JJS_HW.HW_Buf.HalconWindow.SetColor("green");
            Result_Find.Test_Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
            JJS_HW.Copy_HW();
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
        }
        private void tabPage1_Enter(object sender, EventArgs e)
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
        private void B_Update_Click(object sender, EventArgs e)
        {
            Update_Param();
            Update_View();
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
        }
        private void B_Open_Click(object sender, EventArgs e)
        {

        }
        private void B_Image_Pre_Process_Click(object sender, EventArgs e)
        {
            TForm_Halcon_Tool form = new TForm_Halcon_Tool();

            form.Set_Param(Param.Image_Pre_Process);
            form.Set_Part(Param.Image_Avg);
            Param.Set_Tool_Value_Image_Pre_Process(ref form.Org_Tool_Values, Image2);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Image_Pre_Process = form.Param.Copy();
                Set_Param_Image_Pre_Process();
            }
        }
        private void B_Region_Process_Click(object sender, EventArgs e)
        {
            TForm_Halcon_Tool form = new TForm_Halcon_Tool();

            form.Set_Param(Param.Region_Process);
            form.Set_Part(Param.Image_Avg);
            Param.Set_Tool_Value_Region_Process(ref form.Org_Tool_Values, Sub_Image_Light, Sub_Image_Dark);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Region_Process = form.Param.Copy();
                Set_Param_Region_Process();
            }
        }
        public void Set_Colored(int no)
        {
            TSM_Color_3.Checked = false;
            TSM_Color_6.Checked = false;
            TSM_Color_12.Checked = false;
            switch (no)
            {
                case 3: TSM_Color_3.Checked = true; break;
                case 6: TSM_Color_6.Checked = true; break;
                case 12: TSM_Color_12.Checked = true; break;
                default: TSM_Color_12.Checked = true; break;
            }
            HW_SetColored(JJS_HW.HW_Buf);
        }
        public void Set_Draw(string mode)
        {
            TSM_Draw_Fill.Checked = false;
            TSM_Draw_Margin.Checked = false;
            switch (mode)
            {
                case "fill": TSM_Draw_Fill.Checked = true; break;
                case "margin": TSM_Draw_Margin.Checked = true; break;
                default: TSM_Draw_Fill.Checked = true; break;
            }
            HW_SetDraw(JJS_HW.HW_Buf);
        }
        public void Set_Line_Width(int width)
        {
            if (width >= 1 && width <= 5)
            {
                TSM_Line_Width_1.Checked = false;
                TSM_Line_Width_2.Checked = false;
                TSM_Line_Width_3.Checked = false;
                TSM_Line_Width_4.Checked = false;
                TSM_Line_Width_5.Checked = false;
                switch (width)
                {
                    case 1: TSM_Line_Width_1.Checked = true; break;
                    case 2: TSM_Line_Width_2.Checked = true; break;
                    case 3: TSM_Line_Width_3.Checked = true; break;
                    case 4: TSM_Line_Width_4.Checked = true; break;
                    case 5: TSM_Line_Width_5.Checked = true; break;
                    default: TSM_Line_Width_1.Checked = true; break;
                }
                HW_Set_Line_Width(JJS_HW.HW_Buf);
            }
        }
        public void HW_SetColored(HWindowControl hw)
        {
            if (TSM_Color_3.Checked) hw.HalconWindow.SetColored(3);
            if (TSM_Color_6.Checked) hw.HalconWindow.SetColored(6);
            if (TSM_Color_12.Checked) hw.HalconWindow.SetColored(12);
        }
        public void HW_SetDraw(HWindowControl hw)
        {
            if (TSM_Draw_Fill.Checked) hw.HalconWindow.SetDraw("fill");
            if (TSM_Draw_Margin.Checked) hw.HalconWindow.SetDraw("margin");
        }
        public void HW_Set_Line_Width(HWindowControl hw)
        {
            if (TSM_Line_Width_1.Checked) hw.HalconWindow.SetLineWidth(1);
            if (TSM_Line_Width_2.Checked) hw.HalconWindow.SetLineWidth(2);
            if (TSM_Line_Width_3.Checked) hw.HalconWindow.SetLineWidth(3);
            if (TSM_Line_Width_4.Checked) hw.HalconWindow.SetLineWidth(4);
            if (TSM_Line_Width_5.Checked) hw.HalconWindow.SetLineWidth(5);
        }
        private void TSM_Color_3_Click(object sender, EventArgs e)
        {
            Set_Colored(3);
        }
        private void TSM_Color_6_Click(object sender, EventArgs e)
        {
            Set_Colored(6);
        }
        private void TSM_Color_12_Click(object sender, EventArgs e)
        {
            Set_Colored(12);
        }
        private void TSM_Draw_Fill_Click(object sender, EventArgs e)
        {
            Set_Draw("fill");
        }
        private void TSM_Draw_Margin_Click(object sender, EventArgs e)
        {
            Set_Draw("margin");
        }
        private void TSM_Line_Width_1_Click(object sender, EventArgs e)
        {
            Set_Line_Width(1);
        }
        private void TSM_Line_Width_2_Click(object sender, EventArgs e)
        {
            Set_Line_Width(2);
        }
        private void TSM_Line_Width_3_Click(object sender, EventArgs e)
        {
            Set_Line_Width(3);
        }
        private void TSM_Line_Width_4_Click(object sender, EventArgs e)
        {
            Set_Line_Width(4);
        }
        private void TSM_Line_Width_5_Click(object sender, EventArgs e)
        {
            Set_Line_Width(5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Update_Param();
            Param.Update();
        }
    }
    public class TAOI_1
    {
        public static string Default_Path;

        public static bool Set_Param(HImage image_sample, ref TAOI_1_Param param)
        {
            bool result = false;    
            TForm_AOI_1 form = new TForm_AOI_1();
            form.Default_Path = param.Default_Path;
            if (!TJJS_Vision.Is_Empty(image_sample)) form.Image2 = image_sample.Clone();
            form.Set_Param(param);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                param = form.Param.Copy();
                result = true;
            }
            return result;
        }
        public static bool Find(HImage image_sample, TAOI_1_Param param, ref TAOI_1_Result result)
        {
            HImage sub_image_light = new HImage();
            HImage sub_image_dark = new HImage();
            HRegion region = new HRegion();

            result.Reset();
            if (TJJS_Vision.Is_Not_Empty(param.Image_Min) &&
                TJJS_Vision.Is_Not_Empty(param.Image_Max) &&
                TJJS_Vision.Is_Not_Empty(image_sample))
            {
                try
                {
                    Run_Image_Pre_Process(param, image_sample, ref sub_image_light, ref sub_image_dark);
                    Run_Region_Process(param, sub_image_light, sub_image_dark, ref region);
                    result.Disp_Image = image_sample.Clone();
                    result.Test_Region = param.Test_Region.Region.Clone();
                    result.Disp_Region = region.Clone();
                    if (region.CountObj() > 0) result.Find_OK = false;
                    else result.Find_OK = true;
                }
                catch
                {

                }
           }
            return result.Find_OK;
        }
        public static HRegion Cut_Region_HV(HRegion region)
        {
            HRegion result = new HRegion();
            HRegion tmp_region1 = new HRegion();
            HRegion tmp_region2 = new HRegion();
            HRegion tmp_region3 = new HRegion();
            HRegion tmp_region4 = new HRegion();
            HRegion tmp_region5 = new HRegion();
            TJJS_Angle angle_base = new TJJS_Angle();
            TJJS_Angle angle_ofs = new TJJS_Angle();

            angle_ofs.d = 5;

            angle_base.d = 0;
            tmp_region1 = region.SelectShape("phi", "and", angle_base.r - angle_ofs.r, angle_base.r + angle_ofs.r);
            angle_base.d = 90;
            tmp_region2 = region.SelectShape("phi", "and", angle_base.r - angle_ofs.r, angle_base.r + angle_ofs.r);
            angle_base.d = -90;
            tmp_region3 = region.SelectShape("phi", "and", angle_base.r - angle_ofs.r, angle_base.r + angle_ofs.r);
            angle_base.d = 180;
            tmp_region4 = region.SelectShape("phi", "and", angle_base.r - angle_ofs.r, angle_base.r + angle_ofs.r);
            angle_base.d = -180;
            tmp_region5 = region.SelectShape("phi", "and", angle_base.r - angle_ofs.r, angle_base.r + angle_ofs.r);

            tmp_region1 = tmp_region1.Union2(tmp_region2);
            tmp_region1 = tmp_region1.Union2(tmp_region3);
            tmp_region1 = tmp_region1.Union2(tmp_region4);
            tmp_region1 = tmp_region1.Union2(tmp_region5);
            tmp_region1 = region.Difference(tmp_region1);
            result = tmp_region1.Clone();
            return result;
        }
        public static HRegion Select_Region_Filter(HRegion region, string[] filter_list)
        {
            HRegion result = new HRegion();
            ArrayList list = new ArrayList();

            TTool_Values tool_values = new TTool_Values();

            result = region.Clone();
            tool_values.Add_Region("In_Region", region);
            ArrayList_Tool.Set_String(ref list, filter_list);
            //if(.Execute(list, ref tool_values))
            {
                result = tool_values.Values_Region[tool_values.Values_Region_Count - 1].Value.Clone();
            }
            return result;
        }
        public static void Disp_Result(HWindowControl hw, TAOI_1_Result result)
        {
            hw.HalconWindow.ClearWindow();

            if (!TJJS_Vision.Is_Empty(result.Disp_Image))
                result.Disp_Image.DispObj(hw.HalconWindow);

            hw.HalconWindow.SetColor("green");
            if (!TJJS_Vision.Is_Empty(result.Test_Region))
                result.Test_Region.DispObj(hw.HalconWindow);

            hw.HalconWindow.SetColor("red");
            hw.HalconWindow.SetColored(12);
            if (!TJJS_Vision.Is_Empty(result.Disp_Region)) 
                result.Disp_Region.DispObj(hw.HalconWindow);
        }
        public static bool Run_Image_Pre_Process(TAOI_1_Param param, HImage image2, ref HImage image_light, ref HImage image_dark)
        {
            bool result = true;
            TCommand_manager  manager = new TCommand_manager();
            TTool_Values tool_values = new TTool_Values();
            TCommand_Define cmd = null;

            cmd = param.Image_Pre_Process;
            manager.Register_All_Command();
            manager.Register_User_Command(cmd.User_Cmd_List);
            param.Set_Tool_Value_Image_Pre_Process(ref tool_values, image2);

            result = manager.Execute(cmd, ref tool_values);
            image_light = tool_values.Get_Value_Image("Out_Image_Light");
            image_dark = tool_values.Get_Value_Image("Out_Image_Dark");
            return result;
        }
        public static bool Run_Region_Process(TAOI_1_Param param, HImage image_light, HImage image_dark, ref HRegion out_region)
        {
            bool result = false;
            TCommand_manager manager = new TCommand_manager();
            TTool_Values tool_values = new TTool_Values();
            TCommand_Define cmd = null;

            cmd = param.Region_Process;
            manager.Register_All_Command();
            manager.Register_User_Command(cmd.User_Cmd_List);
            param.Set_Tool_Value_Region_Process(ref tool_values, image_light, image_dark);

            result = manager.Execute(cmd, ref tool_values);
            out_region = tool_values.Get_Value_Region("Out_Region");
            return result;
        }
    }
    public class TAOI_1_Param
    {
        public string                    Default_Path,
                                         Default_FileName,
                                         FileName,
                                         Info;

        public TCommand_Define           Image_Pre_Process = new TCommand_Define();
        public TCommand_Define           Region_Process = new TCommand_Define();
        public TJJS_Region               Test_Region = new TJJS_Region();
        public double                    Std_Scale = 1.0;

        public HImage                    Image_Min = new HImage();
        public HImage                    Image_Max = new HImage();
        public HImage                    Image_Avg = new HImage();
        public HImage                    Image_Std = new HImage();

        public TAOI_1_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        public void Set_Default()
        {
            Std_Scale = 1.0;
            Image_Pre_Process.Set_Default();
            Region_Process.Set_Default();
            Test_Region.Region.GenEmptyRegion();
        }
        public void Set_Default_Filename()
        {
            Test_Region.Default_Path = Default_Path;
            Test_Region.Default_FileName = "region.rgn";
        }
        public TAOI_1_Param Copy()
        {
            TAOI_1_Param result = new TAOI_1_Param();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;

            result.Std_Scale = Std_Scale;
            result.Image_Pre_Process = Image_Pre_Process;
            result.Region_Process = Region_Process;
            result.Test_Region = Test_Region.Copy();

            if (TJJS_Vision.Is_Not_Empty(Image_Min)) result.Image_Min = Image_Min.Clone();
            if (TJJS_Vision.Is_Not_Empty(Image_Max)) result.Image_Max = Image_Max.Clone();
            if (TJJS_Vision.Is_Not_Empty(Image_Avg)) result.Image_Avg = Image_Avg.Clone();
            if (TJJS_Vision.Is_Not_Empty(Image_Std)) result.Image_Std = Image_Std.Clone();
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

                Std_Scale = ini.ReadFloat(tmp_section, "Std_Scale", 1.0);
                Image_Pre_Process.Read(ini, tmp_section + "/Image_Pre_Process");
                Region_Process.Read(ini, tmp_section + "/Region_Process");
                Read_Other_File();
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

                ini.WriteFloat(tmp_section, "Std_Scale", Std_Scale);
                Image_Pre_Process.Write(ini, tmp_section + "/Image_Pre_Process");
                Region_Process.Write(ini, tmp_section + "/Region_Process");
                Write_Other_File();
            }
            return true;
        }
        public void SaveAs(string dis_path)
        {
            Default_Path = dis_path;
            Test_Region.Default_Path = dis_path;
            Write(Default_Path + Default_FileName);
        }
        public void Read_Other_File()
        {
            string filename;

            Test_Region.Read(Test_Region.Default_Path + Test_Region.Default_FileName);
            //filename = Test_Region.Default_Path + "Golden_Avg.bmp";
            //if (System.IO.File.Exists(filename)) Image_Avg.ReadImage(filename);

            //filename = Test_Region.Default_Path + "Golden_Std.bmp";
            //if (System.IO.File.Exists(filename)) Image_Std.ReadImage(filename);
            Update();
        }
        public void Write_Other_File()
        {
            Test_Region.Write(Test_Region.Default_Path + Test_Region.Default_FileName);
            Update();
        }
        public void Set_Image(HImage image_avg, HImage image_std)
        {
            if (TJJS_Vision.Is_Not_Empty(image_avg)) Image_Avg = image_avg.Clone();
            if (TJJS_Vision.Is_Not_Empty(image_std)) Image_Std = image_std.Clone();
            Cal_Image_Min_Max();
        }
        public void Update()
        {
            Image_Pre_Process.In.Values_Count = 0;
            Image_Pre_Process.In.Add(emValue_Type.Image, "In_Sample", "In_Sample","", null);
            Image_Pre_Process.In.Add(emValue_Type.Image, "In_Golden_Min", "In_Golden_Min", "", null);
            Image_Pre_Process.In.Add(emValue_Type.Image, "In_Golden_Max", "In_Golden_Max", "", null);
            Image_Pre_Process.In.Add(emValue_Type.Image, "In_Golden_Avg", "In_Golden_Avg", "", null);
            Image_Pre_Process.In.Add(emValue_Type.Image, "In_Golden_Std", "In_Golden_Std", "", null);
            Image_Pre_Process.In.Add(emValue_Type.Region, "In_Select_Region", "In_Select_Region", "", null);

            Image_Pre_Process.Out.Values_Count = 0;
            Image_Pre_Process.Out.Add(emValue_Type.Image, "Out_Image_Light", "Out_Image_Light", "", null);
            Image_Pre_Process.Out.Add(emValue_Type.Image, "Out_Image_Dark", "Out_Image_Dark", "", null);


            Region_Process.In.Values_Count = 0;
            Region_Process.In.Add(emValue_Type.Image, "In_Image_Light", "In_Image_Light", "", null);
            Region_Process.In.Add(emValue_Type.Image, "In_Image_Dark", "In_Image_Dark", "", null);


            Region_Process.Out.Values_Count = 0;
            Region_Process.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", null);
            Cal_Image_Min_Max();
        }
        public void Set_Tool_Value_Image_Pre_Process(ref TTool_Values tool_values, HImage sample)
        {
            tool_values.Add(Image_Pre_Process.In);
            tool_values.Add(Image_Pre_Process.Out);
            tool_values.Set_Image("In_Sample", sample);
            tool_values.Set_Image("In_Golden_Min", Image_Min);
            tool_values.Set_Image("In_Golden_Max", Image_Max);
            tool_values.Set_Image("In_Golden_Avg", Image_Avg);
            tool_values.Set_Image("In_Golden_Std", Image_Std);
            tool_values.Set_Region("In_Select_Region", Test_Region.Region);
        }
        public void Set_Tool_Value_Region_Process(ref TTool_Values tool_values, HImage light, HImage dark)
        {
            tool_values.Add(Region_Process.In);
            tool_values.Add(Region_Process.Out);
            tool_values.Set_Image("In_Image_Light", light);
            tool_values.Set_Image("In_Image_Dark", dark);
        }
        public void Cal_Image_Min_Max()
        {
            HImage tmp_std_image = new HImage();

            if (TJJS_Vision.Is_Not_Empty(Image_Avg) && TJJS_Vision.Is_Not_Empty(Image_Std))
            {
                tmp_std_image = Image_Std.AddImage(Image_Std, 0.5 * Std_Scale, 0);
                Image_Max = Image_Avg.AddImage(tmp_std_image, 1.0, 0);
                Image_Min = Image_Avg.SubImage(tmp_std_image, 1.0, 0);
            }
        }
    }
    public class TAOI_1_Result
    {
        public string                        Default_Path,
                                             Default_FileName;
        public bool                          Find_OK;
        public HImage                        Disp_Image;
        public HRegion                       Disp_Region,
                                             Test_Region;     

        public TAOI_1_Result()
        {
            Default_Path = "";
            Default_FileName = "";
            Disp_Image = new HImage();
            Disp_Region = new HRegion();
            Test_Region = new HRegion();
        }
        public TAOI_1_Result Copy()
        {
            TAOI_1_Result result = new TAOI_1_Result();
            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.Disp_Image  = Disp_Image.Clone();
            result.Disp_Region = Disp_Region.Clone();
            result.Test_Region = Test_Region.Clone();
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
        public void Read_Other_File()
        {
            string filename;

            System.IO.Directory.CreateDirectory(Default_Path);
            filename = Default_Path + Default_FileName + ".jpg";
            if (System.IO.File.Exists(filename)) 
                Disp_Image.ReadImage(filename);

            filename = Default_Path + Default_FileName + "_defect.rgn";
            if (System.IO.File.Exists(filename)) 
                Disp_Region.ReadRegion(filename);

            filename = Default_Path + Default_FileName + "_Test.rgn";
            if (System.IO.File.Exists(filename)) 
                Test_Region.ReadRegion(filename);
        }
        public void Write_Other_File()
        {
            string filename;

            System.IO.Directory.CreateDirectory(Default_Path);
            filename = Default_Path + Default_FileName + ".jpg";
            if (! TJJS_Vision.Is_Empty(Disp_Image)) 
                Disp_Image.WriteImage("jpg", 0, filename);

            filename = Default_Path + Default_FileName + "_defect.rgn";
            if (! TJJS_Vision.Is_Empty(Disp_Region)) 
                Disp_Region.WriteRegion(filename);

            filename = Default_Path + Default_FileName + "_Test.rgn";
            if (!TJJS_Vision.Is_Empty(Test_Region)) 
                Test_Region.WriteRegion(filename);            
        }
        public void Reset()
        {
            Find_OK = false;
            Disp_Image.GenEmptyObj();
            Disp_Region.GenEmptyRegion();
            Test_Region.GenEmptyRegion();
        }
    }
}
