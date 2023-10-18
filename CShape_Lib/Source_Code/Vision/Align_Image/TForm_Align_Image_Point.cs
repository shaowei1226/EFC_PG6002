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
using EFC.Tool;


namespace EFC.Vision.Halcon
{
    //-----------------------------------------------------------------------------------------------------
    //
    //使用大量資訊點作對位
    //
    // Test_Region = 須取資訊點的範圍
    //-----------------------------------------------------------------------------------------------------
    public partial class TForm_Align_Image_Point : Form
    {
        public string Default_Path;
        //public HImage Image1 = new HImage();
        public HImage Sample_Image = new HImage();
        public TAlign_Image_Point_Param Param = new TAlign_Image_Point_Param();
        public TAlign_Image_Point_Result Result = new TAlign_Image_Point_Result();
        public TFrame_JJS_HW JJS_HW = null;
        public int Step = 0;
        public int Result_Image_Index = 0;

        public TForm_Align_Image_Point()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            JJS_HW.Init();
        }
        private void TForm_Align_Mothed_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            JJS_HW.SetPart(Param.Base_Image);
            Draw_Image(Param.Base_Image);
            Set_Button_Color();
        }
        public void Set_Param(TAlign_Image_Point_Param param)
        {
            Param.Set(param);
            E_Sigma_Grad.Text = Param.Sigma_Grad.ToString();
            E_Sigma_Smooth.Text = Param.Sigma_Smooth.ToString();
            E_Alpha.Text = Param.Alpha.ToString();
            E_Point_Num.Text = Param.Point_Num.ToString();

            CB_Get_Match_Method.Text = Param.Get_Match_Method;
            CB_Mask_Size.Text = Param.Mask_Size.ToString();
            CB_Row_Move.Text = Param.Row_Move.ToString();
            CB_Col_Move.Text = Param.Col_Move.ToString();
            CB_Row_Tolerance.Text = Param.Row_Tolerance.ToString();
            CB_Col_Tolerance.Text = Param.Col_Tolerance.ToString();
            CB_Rotation.Text = Param.Rotation.ToString("0.00");
            CB_Match_Threshold.Text = Param.Match_Threshold.ToString("0.00");
            CB_Estimation_Method.Text = Param.Estimation_Method;
            CB_Distance_Threshold.Text = Param.Distance_Threshold.ToString("0.00");
            CB_Rand_Seed.Text = Param.Rand_Seed.ToString();
        }
        public void Update_Param()
        {
            Param.Sigma_Grad = Convert.ToDouble(E_Sigma_Grad.Text);
            Param.Sigma_Smooth = Convert.ToDouble(E_Sigma_Smooth.Text);
            Param.Alpha = Convert.ToDouble(E_Alpha.Text);
            Param.Point_Num = Convert.ToDouble(E_Point_Num.Text);

            Param.Get_Match_Method = CB_Get_Match_Method.Text;
            Param.Mask_Size = Convert.ToInt32(CB_Mask_Size.Text);
            Param.Row_Move = Convert.ToInt32(CB_Row_Move.Text);
            Param.Col_Move = Convert.ToInt32(CB_Col_Move.Text); 
            Param.Row_Tolerance =  Convert.ToInt32(CB_Row_Tolerance.Text);
            Param.Col_Tolerance =  Convert.ToInt32(CB_Col_Tolerance.Text);
            Param.Rotation = Convert.ToDouble(CB_Rotation.Text);
            Param.Match_Threshold = Convert.ToDouble(CB_Match_Threshold.Text);
            Param.Estimation_Method = CB_Estimation_Method.Text;
            Param.Distance_Threshold = Convert.ToDouble(CB_Distance_Threshold.Text);
            Param.Rand_Seed = Convert.ToInt32(CB_Rand_Seed.Text);
            Param.Update();
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
            Draw_Image(Param.Base_Image);
            try
            {
                if (region != null)
                {
                    JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                    JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                    JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");
                    JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                    region.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
            }
            catch
            {
            }
            JJS_HW.Copy_HW();
        }
        private void B_Base_Image_Click(object sender, EventArgs e)
        {
            Draw_Image(Param.Base_Image);
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
                Param.Base_Image.ReadImage(E_Base_Image_File.Text);
                Draw_Image(Param.Base_Image);
            }
            Set_Button_Color();
        }
        private void B_Select_Trans_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Trans_Image_File.Text = dialog.FileName;
                Sample_Image.ReadImage(E_Trans_Image_File.Text);
                Draw_Image(Sample_Image);
            }
            Set_Button_Color();
        }
        public void Update_View()
        {
            bool flag = true;
            //HImage base_image = new HImage();
            //HImage sample_image = new HImage();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                if (JJS_Vision.Is_Empty(Param.Base_Image)) flag = false;
                if (JJS_Vision.Is_Empty(Sample_Image)) flag = false;

                #region Step1 display image
                if (Step >= 1 && flag)
                {
                    if (Step == 1) Param.Base_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Test Region
                if (Step >= 2 && flag)
                {
                    if (Step == 2)
                    {
                        Param.Base_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        Draw_Region(Param.Test_Region.Region);
                    }
                }
                #endregion

                #region Step3 display Find Point
                if (Step >= 3 && flag)
                {
                    Param.Trans(Sample_Image, ref Result);
                    
                    if (Step == 3) Disp_Point();
                }
                #endregion

                 #region Step3 display Find Match Point
                if (Step >= 4 && flag)
                {
                    if (Step == 4) Disp_Match_Point();
                }
                #endregion               
                
                #region Step5 Display result image
                if (Step >= 5 && flag)
                {
                    Disp_Result_Image();
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
        private void button10_Click(object sender, EventArgs e)
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
        private void tabPage6_Enter(object sender, EventArgs e)
        {
            Step = 4;

            Update_View();
        }
        private void tabPage4_Enter(object sender, EventArgs e)
        {
            Step = 5;
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
        private void B_Create_Region_Click(object sender, EventArgs e)
        {
            TForm_Select_Area form = new TForm_Select_Area();
            form.Image = Param.Base_Image.Clone();
            form.Select_Region = Param.Test_Region.Region.CopyObj(1, -1);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Test_Region.Region = form.Select_Region.Clone();
                Draw_Region(Param.Test_Region.Region);
            }
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
        }
        private void Set_Button_Color()
        {
            Form_Tool.Set_Button_Face(B_Base_Image, JJS_Vision.Is_Not_Empty(Param.Base_Image), Color.LightGreen, Color.Transparent);
            Form_Tool.Set_Button_Face(B_Trans_Image, JJS_Vision.Is_Not_Empty(Sample_Image), Color.LightGreen, Color.Transparent);
        }
        private void RB_Base_Image_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Point();
        }
        private void RB_Trans_Image_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Point();
        }
        private void RB_Match_Base_Image_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Match_Point();
        }
        private void RB_Match_Trans_Image_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Match_Point();
        }
        private void RB_Step5_Image1_CheckedChanged(object sender, EventArgs e)
        {
            Disp_Result_Image();
        }
        public void Disp_Point()
        {
            if (RB_Base_Image.Checked)
            {
                Param.Base_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                Param.Test_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);

                Result.Disp_Base_Point(JJS_HW.HW_Buf);
            }
            else
            {
                Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                Param.Test_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);
               
                Result.Disp_Sample_Point(JJS_HW.HW_Buf);
            }
            JJS_HW.Copy_HW();
        }
        public void Disp_Match_Point()
        {
            if (RB_Match_Base_Image.Checked)
            {
                Param.Base_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                Param.Test_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);

                    Result.Disp_Match_Base_Point(JJS_HW.HW_Buf);
            }
            else
            {
                Sample_Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                JJS_HW.HW_Buf.HalconWindow.SetColor("red");
                Param.Test_Region.Region.DispObj(JJS_HW.HW_Buf.HalconWindow);

                Result.Disp_Match_Sample_Point(JJS_HW.HW_Buf);
            }
            JJS_HW.Copy_HW();
        }
        private void Disp_Result_Image()
        {
            if (RB_Step5_Image1.Checked) Draw_Image(Param.Base_Image);
            if (RB_Step5_Image2.Checked) Draw_Image(Sample_Image);
            if (RB_Step5_Image3.Checked) Draw_Image(Result.Image);
        }


    }
    public class TAlign_Image_Point_Param : TBase_Param
    {
        public double           Sigma_Grad,
                                Sigma_Smooth,
                                Alpha,
                                Point_Num;
        public TJJS_Region      Test_Region = new TJJS_Region();

        public string           Get_Match_Method;
        public int              Mask_Size;
        public int              Row_Move;
        public int              Col_Move;
        public int              Row_Tolerance;
        public int              Col_Tolerance;
        public double           Rotation;
        public double           Match_Threshold;
        public string           Estimation_Method;
        public double           Distance_Threshold;
        public int              Rand_Seed;


        public bool             Param_Data_OK;
        public HImage           Base_Image = new HImage();  
        public HTuple           Base_Rows = new HTuple();
        public HTuple           Base_Cols = new HTuple();

        private string          inBase_Image_File_Name = "Base_Image.bmp";

        public string Base_Image_File_Name
        {
            get
            {
                return inBase_Image_File_Name;
            }
            set
            {
                inBase_Image_File_Name = value;
            }
        }
        public string Base_Image_Full_File_Name
        {
            get
            {
                return Default_Path + inBase_Image_File_Name;
            }
        }
        public TAlign_Image_Point_Param()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Image_Point_Param();
        }
        override public TBase_Result New_Base_Result()
        {
            TBase_Result result = new TAlign_Image_Point_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Image_Point_Param && dis_base is TAlign_Image_Point_Param)
            {
                TAlign_Image_Point_Param sor = (TAlign_Image_Point_Param)sor_base;
                TAlign_Image_Point_Param dis = (TAlign_Image_Point_Param)dis_base;
                base.Copy(sor, dis);

                dis.Sigma_Grad = sor.Sigma_Grad;
                dis.Sigma_Smooth = sor.Sigma_Smooth;
                dis.Alpha = sor.Alpha;
                dis.Point_Num = sor.Point_Num;
                dis.Test_Region.Set(sor.Test_Region);

                dis.Get_Match_Method = sor.Get_Match_Method;
                dis.Mask_Size = sor.Mask_Size;
                dis.Row_Move = sor.Row_Move;
                dis.Col_Move = sor.Col_Move;
                dis.Row_Tolerance = sor.Row_Tolerance;
                dis.Col_Tolerance = sor.Col_Tolerance;
                dis.Rotation = sor.Rotation;
                dis.Match_Threshold = sor.Match_Threshold;
                dis.Estimation_Method = sor.Estimation_Method;
                dis.Distance_Threshold = sor.Distance_Threshold;
                dis.Rand_Seed = sor.Rand_Seed;

                dis.Param_Data_OK = sor.Param_Data_OK;
                if (JJS_Vision.Is_Not_Empty(sor.Base_Image)) dis.Base_Image = sor.Base_Image.Clone();
                dis.Base_Rows = sor.Base_Rows.Clone();
                dis.Base_Cols = sor.Base_Cols.Clone();
            }
        }


        public override void Set_Default()
        {
            base.Set_Default();
            Sigma_Grad = 3;
            Sigma_Smooth = 2.0;
            Alpha = 0.08;
            Point_Num = 1000;
            Test_Region.Set_Default();

            Get_Match_Method = "sad";
            Mask_Size = 5;
            Row_Move = 0;
            Col_Move = 0;
            Row_Tolerance = 100;
            Col_Tolerance = 100;
            Rotation = 0.1;
            Match_Threshold = 50;
            Estimation_Method = "normalized_dlt";
            Distance_Threshold = 0.8;
            Rand_Seed = 9;

            Param_Data_OK = false;
            Base_Image = new HImage();  
            inBase_Image_File_Name = "Base_Image.bmp";
            Test_Region.Default_FileName = "Test_Region.rgn";
        }
        public void Set_Default_Path(string path)
        {
            Default_Path = path;
            Update_Default_Path();
        }
        public void Update_Default_Path()
        {
            Test_Region.Default_Path = Default_Path;
        }
        public override void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                base.Read(ini, section);
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                Sigma_Grad = ini.ReadFloat(tmp_section, "Sigma_Grad", Sigma_Grad);
                Sigma_Smooth = ini.ReadFloat(tmp_section, "Sigma_Smooth", Sigma_Smooth);
                Alpha = ini.ReadFloat(tmp_section, "Alpha", Alpha);
                Point_Num = ini.ReadFloat(tmp_section, "Point_Num", Point_Num);


                Get_Match_Method = ini.ReadString(tmp_section, "Get_Match_Method", Get_Match_Method);
                Mask_Size = ini.ReadInteger(tmp_section, "Mask_Size", Mask_Size);
                Row_Move = ini.ReadInteger(tmp_section, "Row_Move", Row_Move);
                Col_Move = ini.ReadInteger(tmp_section, "Col_Move", Col_Move);
                Row_Tolerance = ini.ReadInteger(tmp_section, "Row_Tolerance", Row_Tolerance);
                Col_Tolerance = ini.ReadInteger(tmp_section, "Col_Tolerance", Col_Tolerance);
                Rotation = ini.ReadFloat(tmp_section, "Rotation", Rotation);
                Match_Threshold = ini.ReadFloat(tmp_section, "Match_Threshold", Match_Threshold);
                Estimation_Method = ini.ReadString(tmp_section, "Estimation_Method", Estimation_Method);
                Distance_Threshold = ini.ReadFloat(tmp_section, "Distance_Threshold", Distance_Threshold);
                Rand_Seed = ini.ReadInteger(tmp_section, "Rand_Seed", Rand_Seed);
                Read_Other_File();
            }
        }
        public override void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                base.Write(ini, section);
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);

                ini.WriteFloat(tmp_section, "Sigma_Grad", Sigma_Grad);
                ini.WriteFloat(tmp_section, "Sigma_Smooth", Sigma_Smooth);
                ini.WriteFloat(tmp_section, "Alpha", Alpha);
                ini.WriteFloat(tmp_section, "Point_Num", Point_Num);

                ini.WriteString(tmp_section, "Get_Match_Method", Get_Match_Method);
                ini.WriteInteger(tmp_section, "Mask_Size", Mask_Size);
                ini.WriteInteger(tmp_section, "Row_Move", Row_Move);
                ini.WriteInteger(tmp_section, "Col_Move", Col_Move);
                ini.WriteInteger(tmp_section, "Row_Tolerance", Row_Tolerance);
                ini.WriteInteger(tmp_section, "Col_Tolerance", Col_Tolerance);
                ini.WriteFloat(tmp_section, "Rotation", Rotation);
                ini.WriteFloat(tmp_section, "Match_Threshold", Match_Threshold);
                ini.WriteString(tmp_section, "Estimation_Method", Estimation_Method);
                ini.WriteFloat(tmp_section, "Distance_Threshold", Distance_Threshold);
                ini.WriteInteger(tmp_section, "Rand_Seed", Rand_Seed);
                Write_Other_File();
            }
        }
        public override void Read_Other_File()
        {
            string filename = Base_Image_Full_File_Name;
            if (System.IO.File.Exists(filename)) Base_Image.ReadImage(filename);
            else Base_Image.GenEmptyObj();

            Test_Region.Read(Test_Region.Default_Path + Test_Region.Default_FileName);
            Update();
        }
        public override void Write_Other_File()
        {
            Test_Region.Write(Test_Region.Default_Path + Test_Region.Default_FileName);
        }
        public void Log_Diff(TLog log, string section, TAlign_Image_Point_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Info", Info, new_value.Info, ref flag);
            log.Log_Diff(section + "/Sigma_Grad", Sigma_Grad, new_value.Sigma_Grad, ref flag);
            log.Log_Diff(section + "/Sigma_Smooth", Sigma_Smooth, new_value.Sigma_Smooth, ref flag);
            log.Log_Diff(section + "/Alpha", Alpha, new_value.Alpha, ref flag);
            log.Log_Diff(section + "/Point_Num", Point_Num, new_value.Point_Num, ref flag);
        }

        public void Set_Base_Image(HImage image)
        {
            if (JJS_Vision.Is_Not_Empty(image))
            {
                Base_Image = image.Clone();
                Update();
            }
        }
        public override bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Align_Image_Point form = new TForm_Align_Image_Point();
            if (!JJS_Vision.Is_Empty(image)) form.Sample_Image = image.Clone();
            form.Default_Path = Default_Path;
            form.Set_Param(this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        public override bool Find_Base(HImage image, ref TBase_Result f_result)
        {
            return Trans(image, ref f_result);
        }
        public bool Find_Base(HImage image, ref TAlign_Image_Point_Result f_result)
        {
            return Trans(image, ref f_result);
        }


        public bool Trans(HImage sample_image, ref TBase_Result f_result)
        {
            bool result = false;
            if (f_result is TAlign_Image_Point_Result)
            {
                TAlign_Image_Point_Result in_result = (TAlign_Image_Point_Result)f_result;
                result = Trans(sample_image, ref in_result);
            }
            return result;
        }
        public bool Trans(HImage sample_image, ref TAlign_Image_Point_Result result_p)
        {
            bool result = false;

            result_p.Reset();
            result_p.Base_Rows = Base_Rows.Clone();
            result_p.Base_Cols = Base_Cols.Clone();
            if (Param_Data_OK)
            {
                if (Get_Point(sample_image, out result_p.Sample_Rows, out result_p.Sample_Cols))
                {
                    try
                    {
                       HTuple rotation = new HTuple();
                       HTuple matchThreshold = new HTuple();

                       rotation = Rotation;
                       if (Get_Match_Method == "ncc") matchThreshold = Match_Threshold;
                       else
                           matchThreshold = (int)Match_Threshold;



                        result_p.HomMat2D = sample_image.ProjMatchPointsRansac(
                                                     Base_Image, result_p.Sample_Rows, result_p.Sample_Cols, result_p.Base_Rows, result_p.Base_Cols,
                                                     Get_Match_Method, Mask_Size, Row_Move, Col_Move, Row_Tolerance, Col_Tolerance,
                                                     rotation, matchThreshold, Estimation_Method, Distance_Threshold, Rand_Seed,
                                                     out result_p.Sample_Points, out result_p.Base_Points);


                        Get_Match_Point(result_p.Base_Rows, result_p.Base_Cols, result_p.Base_Points, out result_p.Match_Base_Rows, out result_p.Match_Base_Cols);
                        Get_Match_Point(result_p.Sample_Rows, result_p.Sample_Cols, result_p.Sample_Points, out result_p.Match_Sample_Rows, out result_p.Match_Sample_Cols);

                        result_p.Image = sample_image.ProjectiveTransImage(result_p.HomMat2D, "nearest_neighbor", "false", "true");
                        result = true;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        public bool Trans(HImage sample_image, ref HImage out_image)
        {
            bool result = false;
            HTuple sample_rows = new HTuple();
            HTuple sample_cols = new HTuple();
            HHomMat2D HomMat2D = new HHomMat2D();
            HTuple base_points = new HTuple();
            HTuple sample_points = new HTuple();
            HTuple match_base_rows = new HTuple();
            HTuple match_base_cols = new HTuple();
            HTuple match_sample_rows = new HTuple();
            HTuple match_sample_cols = new HTuple();

            out_image = null;
            if (Param_Data_OK)
            {
                if (Get_Point(sample_image, out sample_rows, out sample_cols))
                {
                    try
                    {
                        HTuple rotation = new HTuple();
                        HTuple matchThreshold = new HTuple();

                        rotation = Rotation;
                        if (Get_Match_Method == "ncc") matchThreshold = Match_Threshold;
                        else
                            matchThreshold = (int)Match_Threshold;

                        HomMat2D = sample_image.ProjMatchPointsRansac(
                                                     Base_Image, sample_rows, sample_cols, Base_Rows, Base_Cols,
                                                     Get_Match_Method, Mask_Size, Row_Move, Col_Move, Row_Tolerance, Col_Tolerance,
                                                     rotation, matchThreshold, Estimation_Method, Distance_Threshold, Rand_Seed,
                                                     out sample_points, out base_points);


                        Get_Match_Point(Base_Rows, Base_Cols, base_points, out match_base_rows, out match_base_cols);
                        Get_Match_Point(sample_rows, sample_cols, sample_points, out match_sample_rows, out match_sample_cols);

                        out_image = sample_image.ProjectiveTransImage(HomMat2D, "nearest_neighbor", "false", "true");
                        result = true;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        public bool Get_Point(HImage image, out HTuple rows, out HTuple cols)
        {
            bool result = false;
            HImage tmp_image = new HImage();

            rows = new HTuple();
            cols = new HTuple();
            if (JJS_Vision.Is_Not_Empty(image))
            {
                try
                {
                    tmp_image = image.ReduceDomain(Test_Region.Region);

                    tmp_image.PointsHarris(Sigma_Grad, Sigma_Smooth, Alpha, Point_Num, out rows, out cols);
                    result = true;
                }
                catch { }
            }
            tmp_image.Dispose();
            return result;
        }
        public void Get_Match_Point(HTuple rows, HTuple cols, HTuple indexs, out HTuple match_rows, out HTuple match_cols)
        {
            int no = 0;
            match_rows = new HTuple();
            match_cols = new HTuple();
            for(int i=0; i<indexs.Length; i++)
            {
                no = indexs[i].I;
                match_rows.Append(rows[no].D);
                match_cols.Append(cols[no].D);
            }
        }
        public bool Update()
        {
            Param_Data_OK = Get_Point(Base_Image, out Base_Rows, out Base_Cols);
            return Param_Data_OK;
        }
    }
    public class TAlign_Image_Point_Result : TBase_Result
    {
        public HImage            Image = new HImage();
        public HHomMat2D         HomMat2D = new HHomMat2D();
        public HTuple            Base_Rows,
                                 Base_Cols;
        public HTuple            Sample_Rows,
                                 Sample_Cols;
        public HTuple            Base_Points,
                                 Sample_Points;

        public HTuple            Match_Base_Rows,
                                 Match_Base_Cols;
        public HTuple            Match_Sample_Rows,
                                 Match_Sample_Cols;
        public TBase_Disp_Param  Disp_Param = new TBase_Disp_Param();

        public TAlign_Image_Point_Result()
        {
            Find_OK = false;
        }
        override public TBase_Class New_Class()
        {
            return new TAlign_Image_Point_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TAlign_Image_Point_Result && dis_base is TAlign_Image_Point_Result)
            {
                base.Copy(sor_base, dis_base);
                TAlign_Image_Point_Result sor = (TAlign_Image_Point_Result)sor_base;
                TAlign_Image_Point_Result dis = (TAlign_Image_Point_Result)dis_base;

                if (JJS_Vision.Is_Not_Empty(sor.Image)) dis.Image = sor.Image.Clone();
                dis.HomMat2D = sor.HomMat2D.Clone();
                dis.Base_Rows = sor.Base_Rows;
                dis.Base_Cols = sor.Base_Cols;
                dis.Sample_Rows = sor.Sample_Rows;
                dis.Sample_Cols = sor.Sample_Cols;

                dis.Base_Points = sor.Base_Points;
                dis.Sample_Points = sor.Sample_Points;
                dis.Disp_Param.Set(sor.Disp_Param);
            }
        }

        override public void Set_Default()
        {
            base.Set_Default();
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                Disp_Param.Read(ini, "/Disp_Param");
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
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
        }
        override public void Display_Message(HWindowControl hw)
        {

        }
        override public void Display_Model(HWindowControl hw)
        {

        }
        override public string Get_Message()
        {
            string result = "";
            return result;
        }


        public void Disp_Base_Point(HWindowControl hw)
        {
            Disp_Point(hw, Base_Rows, Base_Cols, "green", 10, 0);
        }
        public void Disp_Sample_Point(HWindowControl hw)
        {
            Disp_Point(hw, Sample_Rows, Sample_Cols, "green", 10, 0);
        }
        public void Disp_Match_Base_Point(HWindowControl hw)
        {
            Disp_Point(hw, Match_Base_Rows, Match_Base_Cols, "green", 10, 0);
        }
        public void Disp_Match_Sample_Point(HWindowControl hw)
        {
            Disp_Point(hw, Match_Sample_Rows, Match_Sample_Cols, "green", 10, 0);
        }
        public void Disp_Point(HWindowControl hw, HTuple rows, HTuple cols, string color, double size, double angle)
        {
            hw.HalconWindow.SetColor(color);
            if (rows != null && rows.Length > 0)
                hw.HalconWindow.DispCross(rows, cols, size, angle);
        }
    }
}
