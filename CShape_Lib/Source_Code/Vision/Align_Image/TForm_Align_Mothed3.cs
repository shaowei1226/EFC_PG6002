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
using EFC.Vision.Halcon;
using EFC.CAD;
using EFC.INI;


namespace EFC.Vision.Halcon
{
    public partial class TForm_Align_Mothed3 : Form
    {
        public string Default_Path;
        public HImage Image1 = new HImage();
        public HImage Image2 = new HImage();
        public TAlign_Mothed_3_Param Param = new TAlign_Mothed_3_Param();
        public TAlign_Mothed_3_Result Result = new TAlign_Mothed_3_Result();
        public TFrame_JJS_HW JJS_HW;
        public int Step = 0;

        
        public TForm_Align_Mothed3()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
        }
        private void TForm_Align_Mothed2_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            if (!TJJS_Vision.Is_Empty(Image1)) B_Base_Image.BackColor = Color.LightGreen;
            if (!TJJS_Vision.Is_Empty(Image2)) B_Trans_Image.BackColor = Color.LightGreen;
            Draw_Image(Image1);
        }
        public void Set_Param(TAlign_Mothed_3_Param param)
        {
            Param = param.Copy();

            switch(Param.Align_Mode)
            {
                case 0: RB_Align_Mode1.Checked = true; break;
                case 1: RB_Align_Mode2.Checked = true; break;
                default: RB_Align_Mode1.Checked = true; break;
            }
            CB_Align_Angle.Checked = Param.Align_Angle;
            tFrame_Select_Model1.Set_Model(Param.Param1.JJS_Model);
            tFrame_Select_Model2.Set_Model(Param.Param2.JJS_Model);
        }
        public void Update_Param()
        {
            Param.Align_Mode = 0;
            if (RB_Align_Mode1.Checked) Param.Align_Mode = 0;
            if (RB_Align_Mode2.Checked) Param.Align_Mode = 1;

            Param.Align_Angle = CB_Align_Angle.Checked;

            Param.Param1.JJS_Model = tFrame_Select_Model1.JJS_Model.Copy();
            Param.Param2.JJS_Model = tFrame_Select_Model2.JJS_Model.Copy();
        }
        private void B_Set_Default_Click(object sender, EventArgs e)
        {
            Param.Set_Default();
            Set_Param(Param);
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
        public void Draw_Find_Model(HWindowControl hw, TFind_Mothed_1_Result find_result, int no)
        {
            TFind_Mothed_1.Disp_XLD(hw, find_result, "green");
            TFind_Mothed_1.Disp_Hairline(hw, find_result, 20, "yellow");
            TFind_Mothed_1.Disp_Message(hw, find_result, 20, 20 + no * 20, 10, 4, "green");
        }
        public void Update_View()
        {
            bool flag = true;
            HImage image1 = new HImage();
            HImage image2 = new HImage();
            HImage image = new HImage();
            HRegion region = new HRegion();
            double row, col, radius;
            TFind_Mothed_1_Result[] sample_result = new TFind_Mothed_1_Result[3];

            for(int i=0; i<sample_result.Length; i++) sample_result[i] = new TFind_Mothed_1_Result();
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
                    if (!TJJS_Vision.Is_Empty(Image2)) image2 = Image2.Clone();
                    image1.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                }
                #endregion

                #region Step3 display base mode
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        Param.Update();
                        image1.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        Draw_Find_Model(JJS_HW.HW_Buf, Param.Find_Result[0], 0);
                        Draw_Find_Model(JJS_HW.HW_Buf, Param.Find_Result[1], 1);
                    }
                }
                #endregion

                #region Step4 select Circle
                if (Step >= 4 && flag)
                {
                    if (Step == 4)
                    {
                        TAlign_Mothed_3.Find(image2, Param, ref sample_result[0], ref sample_result[1], ref sample_result[2]);
                        if (!TJJS_Vision.Is_Empty(Image2))
                            image2.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        else
                            MessageBox.Show("請載入測試樣本圖片");
                        
                        Draw_Find_Model(JJS_HW.HW_Buf, sample_result[0], 0);
                        Draw_Find_Model(JJS_HW.HW_Buf, sample_result[1], 1);
                    }
                }
                #endregion

                #region Step5 select Circle
                if (Step >= 5 && flag)
                {
                    try
                    {
                        TAlign_Mothed_3.Trans(image2, Param, ref Result);
                        JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                        Result.Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                #endregion

                JJS_HW.Copy_HW();
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
        private void B_Select_Base_Image_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
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

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                E_Trans_Image_File.Text = dialog.FileName;
                Image2.ReadImage(E_Trans_Image_File.Text);
                B_Trans_Image.BackColor = Color.LightGreen;
                Draw_Image(Image2);
            }
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
            Draw_Image(Result.Image);
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
        private void TP_Step6_Enter(object sender, EventArgs e)
        {
            Step = 6;
            Update_View();
        }
        private void B_Select_Rect1_Click_1(object sender, EventArgs e)
        {
            if (TFind_Mothed_1.Set_Param(Image1, ref Param.Param1))
            {
                tFrame_Select_Model1.Set_Model(Param.Param1.JJS_Model);
            }
        }
        private void B_Select_Rect2_Click(object sender, EventArgs e)
        {
            if (TFind_Mothed_1.Set_Param(Image1, ref Param.Param2))
            {
                tFrame_Select_Model2.Set_Model(Param.Param2.JJS_Model);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Update_Param();
            Update_View();
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex++;
            Update_View();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            HImage image = new HImage();
            TFind_Mothed_1_Result[] find_result = new TFind_Mothed_1_Result[3];

            image = Image2;
            for (int i = 0; i < find_result.Length; i++) find_result[i] = new TFind_Mothed_1_Result();
            if (!TJJS_Vision.Is_Empty(image))
            {
                TAlign_Mothed_3.Find(image, Param, ref find_result[0], ref find_result[1], ref find_result[2]);

                tFrame_JJS_HW1.HW_Buf.HalconWindow.ClearWindow();
                tFrame_JJS_HW1.HW_Buf.HalconWindow.DispImage(image);
                for (int i = 0; i < 2; i++)
                {
                    TFind_Mothed_1.Disp_XLD(tFrame_JJS_HW1.HW_Buf, find_result[i], "green");
                    TFind_Mothed_1.Disp_Hairline(tFrame_JJS_HW1.HW_Buf, find_result[i], 20, "yellow");
                    TFind_Mothed_1.Disp_Message(tFrame_JJS_HW1.HW_Buf, find_result[i], 20, 20 + i * 20, 10, 4, "green");
                }
                tFrame_JJS_HW1.Copy_HW();
            }
        }
        private void B_Base_Image2_Click_1(object sender, EventArgs e)
        {
            Draw_Image(Image1);
        }
        private void B_Sample_Image2_Click_1(object sender, EventArgs e)
        {
            Draw_Image(Image2);
        }
        private void B_Result_Image_Click_1(object sender, EventArgs e)
        {
            Draw_Image(Result.Image);
        }
    }
    public class TAlign_Mothed_3
    {
        public static string Default_Path;

        public static bool Set_Param(HImage image2, ref TAlign_Mothed_3_Param param)
        {
            bool result = false;
            TForm_Align_Mothed3 form = new TForm_Align_Mothed3();
            if (!TJJS_Vision.Is_Empty(param.Base_Image)) form.Image1 = param.Base_Image.Clone();
            if (!TJJS_Vision.Is_Empty(image2)) form.Image2 = image2.Clone();
            form.Default_Path = param.Default_Path;
            form.Set_Param(param);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                param = form.Param.Copy();
                result = true;
            }
            return result;
        }
        public static bool Find(HImage image, TAlign_Mothed_3_Param param, ref TFind_Mothed_1_Result find1, ref TFind_Mothed_1_Result find2, ref TFind_Mothed_1_Result find_result)
        {
            bool result = false;
            TJJS_Line line = new TJJS_Line();
            double dist = 0;

            find_result.Reset();
            switch (param.Align_Mode)
            {
                case 0:
                    TFind_Mothed_1.Find(image, param.Param1, ref find1);
                    find_result = find1.Copy();
                    break;

                case 1:
                    TFind_Mothed_1.Find(image, param.Param1, ref find1);
                    TFind_Mothed_1.Find(image, param.Param2, ref find2);

                    if (find1.Find_OK && find2.Find_OK)
                    {
                        line.Start = new TJJS_Point(find1.Col, find1.Row);
                        line.End = new TJJS_Point(find2.Col, find2.Row);
                        dist = line.Length();

                        find_result.Col = line.Mid.X;
                        find_result.Row = line.Mid.Y;
                        find_result.Angle = line.V.Angle.r;
                        find_result.Find_OK = true;
                    }
                    break;
            }
            if (!param.Align_Angle) find_result.Angle = 0;
            result = find_result.Find_OK;
            return result;
        }
        public static bool Trans(HImage image, TAlign_Mothed_3_Param param, ref TAlign_Mothed_3_Result result_p)
        {
            bool result = false;
            TFind_Mothed_1_Result[] base_find = new TFind_Mothed_1_Result[3];
            TFind_Mothed_1_Result[] sample_find = new TFind_Mothed_1_Result[3];

            result_p.Resset();
            if (param.Param_Data_OK && !TJJS_Vision.Is_Empty(image))
            {
                for (int i = 0; i < sample_find.Length; i++) sample_find[i] = new TFind_Mothed_1_Result();
                base_find[0] = param.Find_Result[0].Copy();
                base_find[1] = param.Find_Result[1].Copy();
                base_find[2] = param.Find_Result[2].Copy();
                
                Find(image, param, ref sample_find[0], ref sample_find[1], ref sample_find[2]);
                if (param.Align_Angle)
                {
                    if (base_find[2].Find_OK && sample_find[2].Find_OK)
                    {
                        result_p.Image = TJJS_Vision.Affine_Trans_Image(image, 0, 0, sample_find[2].Angle, 0, 0, base_find[2].Angle);
                        result_p.D_Angle = sample_find[2].Angle - base_find[2].Angle;

                        Find(result_p.Image, param, ref sample_find[0], ref sample_find[1], ref sample_find[2]);
                        if (sample_find[2].Find_OK)
                        {
                            result_p.Image = TJJS_Vision.Affine_Trans_Image(result_p.Image, sample_find[2].Col, sample_find[2].Row, 0, base_find[2].Col, base_find[2].Row, 0);
                            result_p.D_Col = sample_find[2].Col - base_find[2].Col;
                            result_p.D_Row = sample_find[2].Row - base_find[2].Row;
                            result_p.Find_OK = true;
                        }
                    }
                }
                else
                {
                    if (base_find[2].Find_OK && sample_find[2].Find_OK)
                    {
                        result_p.Image = TJJS_Vision.Affine_Trans_Image(image, sample_find[2].Col, sample_find[2].Row, 0, base_find[2].Col, base_find[2].Row, 0);
                        result_p.D_Col = sample_find[2].Col - base_find[2].Col;
                        result_p.D_Row = sample_find[2].Row - base_find[2].Row;
                        result_p.D_Angle = 0;
                        result_p.Find_OK = true;
                    }
                }
            }
            result = result_p.Find_OK;
            return result;
        }
    }
    public class TAlign_Mothed_3_Param 
    {
        public string                   Class_Name,
                                        Default_Path,
                                        Default_FileName,
                                        FileName,
                                        Info; 
        public int                      Align_Mode = 0;
        public bool                     Align_Angle = false;
        public TFind_Mothed_1_Param     Param1 = new TFind_Mothed_1_Param();
        public TFind_Mothed_1_Param     Param2 = new TFind_Mothed_1_Param();

        public bool                     Param_Data_OK;
        public HImage                   Base_Image = null;          
        public TFind_Mothed_1_Result[]  Find_Result = new TFind_Mothed_1_Result[3];



        public TAlign_Mothed_3_Param()
        {
            Class_Name = "TAlign_Mothed_3_Param";
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            for (int i = 0; i < Find_Result.Length; i++) Find_Result[i] = new TFind_Mothed_1_Result();
            Set_Default();
        }
        public void Set_Default()
        {
            Align_Mode = 0;
            Align_Angle = false;
            Param1.Set_Default();
            Param2.Set_Default();

            Param_Data_OK = false;
            for (int i = 0; i < Find_Result.Length; i++) Find_Result[i].Set_Default();
        }
        public TAlign_Mothed_3_Param Copy()
        {
            TAlign_Mothed_3_Param result = new TAlign_Mothed_3_Param();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;

            result.Align_Mode = Align_Mode;
            result.Align_Angle = Align_Angle;
            result.Param1 = Param1.Copy();
            result.Param2 = Param2.Copy();

            result.Param_Data_OK = Param_Data_OK;
            result.Base_Image = Base_Image;
            for (int i = 0; i < Find_Result.Length; i++) result.Find_Result[i] = Find_Result[i].Copy();
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
                Read_Other_File();
                Update();
            };
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                Class_Name = ini.ReadString(section, "Class_Name", "TAlign_Mothed_3_Param");
                Info = ini.ReadString(section, "Info", "");

                Align_Mode = ini.ReadInteger(section, "Align_Mode", 0);
                Align_Angle = ini.ReadBool(section, "Align_Angle", false);

                Param1.Read(ini, section + "/Param1");
                Param2.Read(ini, section + "/Param2");
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
            Write_Other_File();
            return result;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null)
            {
                ini.WriteString(section, "Class_Name", Class_Name);
                ini.WriteString(section, "Info", Info);

                ini.WriteInteger(section, "Align_Mode", Align_Mode);
                ini.WriteBool(section, "Align_Angle", Align_Angle);

                Param1.Write(ini, section + "/Param1");
                Param2.Write(ini, section + "/Param2");
            }
            return true;
        }
        public void Read_Other_File()
        {
            Param1.Read_Other_File();
            Param2.Read_Other_File();
        }
        public void Write_Other_File()
        {
            Param1.Write_Other_File();
            Param2.Write_Other_File();
        }
        public bool Update()
        {
            Param_Data_OK = false;
            try
            {
                if (TAlign_Mothed_3.Find(Base_Image, this, ref Find_Result[0], ref Find_Result[1], ref Find_Result[2]))
                {
                    Param_Data_OK = true;
                }
            }
            catch { }
            return Param_Data_OK;
        }
    }
    public class TAlign_Mothed_3_Result 
    {
        public bool Find_OK;
        public string Class_Name;
        public HImage Image = new HImage();
        public double D_Col, D_Row, D_Angle;

        public TAlign_Mothed_3_Result()
        {
            Class_Name = "TAlign_Mothed_3_Result";
            Find_OK = false;
        }
        public TAlign_Mothed_3_Result Copy()
        {
            TAlign_Mothed_3_Result result = new TAlign_Mothed_3_Result();
            result.Image = Image.Clone();
            result.D_Col = D_Col;
            result.D_Row = D_Row;
            result.D_Angle = D_Angle;

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
        }
    }
}
