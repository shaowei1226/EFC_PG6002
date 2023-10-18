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
    public partial class TForm_Find_Barcode1 : Form
    {
        public TFind_Barcode1_Param      Param = new TFind_Barcode1_Param();
        public HImage                    Image = new HImage();
        public int                       Step = 0;
        public TFrame_JJS_HW             JJS_HW;
        public HRegion                   Find_Model_Region = new HRegion();

        public TForm_Find_Barcode1()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            tFrame_Select_Model1.B_Edit.Visible = false;
            tFrame_Select_Model1.B_Select_File.Visible = false;
        }
        public void Set_Param(TFind_Barcode1_Param param)
        {
            Param.Set(param);

            CB_Used_Find_Model.Checked = Param.Find_Model_Flag;
            B_Edit_Model_Param.Enabled = CB_Used_Find_Model.Checked;

            tFrame_Select_Model1.Set_Model(Param.Model_Param.JJS_Model);
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
            Param.Find_Model_Flag = CB_Used_Find_Model.Checked;
        }
        private void Form_Find_Barcode1_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            tFrame_JJS_HW1.SetPart(Image);
            tFrame_JJS_HW1.HW_Buf.HalconWindow.DispObj(Image);
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
        public void Update_View()
        {
            bool flag = true;
            HRegion region = new HRegion();
            HImage tmp_image = new HImage();
            TBase_Result f_result = Param.Model_Param.New_Base_Result();

            Update_Param();
            if (true)//jjs_hw.Init)
            {
                JJS_HW.HW_Buf.HalconWindow.SetColored(12);
                JJS_HW.HW_Buf.HalconWindow.SetLineWidth(2);
                JJS_HW.HW_Buf.HalconWindow.SetDraw("margin");

                #region Step1 Set Create Param
                if (Step >= 1 && flag)
                {
                    JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                    Image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                }
                #endregion

                #region Step2 Select Model
                if (Step >= 2 && flag)
                {
                    if (Param.Find_Model_Flag)
                    {
                        if (Param.Model_Param.Find_Base(Image, ref f_result))
                        {
                            f_result.Display_Model(JJS_HW.HW_Buf, 1);
                            ((TFind_Mothed_1_Result)f_result).Get_Find_Region(ref Find_Model_Region);
                        }
                        else
                        {
                            Find_Model_Region.GenEmptyRegion();
                            flag = false;
                        }
                    }
                }
                #endregion

                #region Step3 Select Test Region
                if (Step >= 3 && flag)
                {
                    if (Step == 3)
                    {
                        if (Param.Run_Process(Image, Find_Model_Region, ref tmp_image))
                        {
                            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
                            if (JJS_Vision.Is_Not_Empty(tmp_image)) tmp_image.DispObj(JJS_HW.HW_Buf.HalconWindow);
                        }
                        else flag = false;
                    }
                }
                #endregion

                #region Step4 Set Find Param
                if (Step >= 4 && flag)
                {
                    TBase_Result ff_result = new TFind_Barcode1_Result();
                    if (Param.Find_Base(Image, ref ff_result))
                    {
                        ff_result.Display(JJS_HW.HW_Buf, 1);
                    }
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
            if (Param.Model_Param.Set_Param(Image))
            {
                tFrame_Select_Model1.Set_Model(Param.Model_Param.JJS_Model);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TForm_Halcon_Tool form = new TForm_Halcon_Tool();

            form.Set_Param(Param.Process);
            form.Set_Part(Image);
            form.Org_Tool_Values.Add(Param.Process.In);
            form.Org_Tool_Values.Add(Param.Process.Out);
            form.Org_Tool_Values.Set_Image("In_Image", Image);
            form.Org_Tool_Values.Set_Region("In_Region", Find_Model_Region);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Param.Process.Set(form.Param);
                Set_Param_Process();
            }
        }
        private void CB_Used_Find_Model_CheckedChanged(object sender, EventArgs e)
        {
            B_Edit_Model_Param.Enabled = CB_Used_Find_Model.Checked;
        }
    }
    public class TFind_Barcode1_Param : TBase_Param
    {
        public TFind_Mothed_1_Param    Model_Param = new TFind_Mothed_1_Param();
        public TCommand_Define         Process = new TCommand_Define();
        public bool                    Find_Model_Flag = false;
        public static HDataCode2D      Code_Handle = new HDataCode2D();
        public static bool             Init_Flag = false;

        public TFind_Barcode1_Param()
        {
            Set_Default();
        }
 
        override public TBase_Class New_Class()
        {
            TBase_Class result = new TFind_Barcode1_Param();
            return result;
        }
        override public TBase_Result New_Base_Result()
        {
            TBase_Result result = null;
            result = new TFind_Barcode1_Result();
            return result;
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Barcode1_Param && dis_base is TFind_Barcode1_Param)
            {
                TFind_Barcode1_Param sor = (TFind_Barcode1_Param)sor_base;
                TFind_Barcode1_Param dis = (TFind_Barcode1_Param)dis_base;

                base.Copy(sor, dis);
                dis.Find_Model_Flag = sor.Find_Model_Flag;
                dis.Model_Param.Set(sor.Model_Param);
                dis.Process.Set(sor.Process);
            }
        }
        override public void Set_Default()
        {
            base.Set_Default();
            Find_Model_Flag = false;
            Model_Param.Set_Default();
            Process.Set_Default();
            Code_Handle.CreateDataCode2dModel("Data Matrix ECC 200", "default_parameters", "enhanced_recognition");
            Code_Handle.SetDataCode2dParam("contrast_tolerance", "high");
            Init_Flag = true;
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                base.Read(ini, section);
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                Find_Model_Flag = ini.ReadBool(tmp_section, "Find_Model_Flag", false);
                Model_Param.Read(ini, tmp_section + "/Model_Param");
                Process.Read(ini, tmp_section + "/Process");
                Process.In.Values_Count = 0;
                Process.In.Add(emValue_Type.Image, "In_Image", "In Image", "In_Image", null);
                Process.In.Add(emValue_Type.Region, "In_Region", "In Region", "In_Region", null);
                Process.Out.Values_Count = 0;
                Process.Out.Add(emValue_Type.Image, "Out_Image", "Out Image", "Out_Image", null);
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                base.Write(ini, section);
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);

                ini.WriteBool(tmp_section, "Find_Model_Flag", Find_Model_Flag);
                Model_Param.Write(ini, tmp_section + "/Model_Param");
                Process.Write(ini, tmp_section + "/Process");
            }
        }
        override public void Read_Other_File()
        {
            Model_Param.Read_Other_File();
        }
        override public void Write_Other_File()
        {
            Model_Param.Write_Other_File();
        }
        override public bool Set_Param(HImage image)
        {
            bool result = false;
            TForm_Find_Barcode1 form = new TForm_Find_Barcode1();

            form.Image = image.Clone();
            form.Set_Param(this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        override public bool Find_Base(HImage image, ref TBase_Result f_result)
        {
            return Find(image, ref f_result);
        }
        public bool Find_Base(HImage image, ref TFind_Barcode1_Result f_result)
        {
            return Find(image, ref f_result);
        }



        public bool Find(HImage image, ref TBase_Result f_result)
        {
            bool result = false;
            if (f_result is TFind_Barcode1_Result && JJS_Vision.Is_Not_Empty(image))
            {
                TFind_Barcode1_Result in_result = (TFind_Barcode1_Result)f_result;
                result = Find(image, ref in_result);
            }
            return result;
        }
        public bool Find(HImage image, ref TFind_Barcode1_Result f_result)
        {
            bool result = false;
            HRegion find_region = new HRegion();
            HImage tmp_image = new HImage();

            f_result.Reset();
            if (Find_Model_Flag)
            {
                if (Model_Param.Find_Base(image, ref f_result.Model_Result))
                {
                    f_result.Model_Result.Get_Find_Region(ref find_region);
                }
            }
            else
            {
                find_region = null;
            }

            if (Run_Process(image, find_region, ref tmp_image))
            {
                f_result.Find_OK = Find_Barcode(tmp_image, ref f_result.Barcode_XLD, ref f_result.Barcode);
            }
            result = f_result.Find_OK;

            tmp_image.Dispose();
            return result;
        }
        public bool Run_Process(HImage in_image, HRegion in_region, ref HImage out_image)
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
            out_image = tool_values.Get_Value_Image("Out_Image");
            return result;
        }
        public bool Find_Barcode(HImage image, ref HXLDCont out_xld, ref string out_barcode)
        {
            bool result = false;
            HTuple param = new HTuple();
            HTuple value = new HTuple();
            HTuple handle = new HTuple();
            HTuple code_str = new HTuple();

            if (Init_Flag)
            {
                out_xld = image.FindDataCode2d(Code_Handle, param, value, out handle, out code_str);
                if (code_str.TupleLength() > 0)
                {
                    out_barcode = code_str;
                    result = true;
                }
            }
            return result;
        }
    }
    public class TFind_Barcode1_Result : TBase_Result
    {
        public TJJS_ShapeModel         JJS_Model = new TJJS_ShapeModel();
        public TFind_Mothed_1_Result   Model_Result = new TFind_Mothed_1_Result();
        public TJJS_Region             Find_Region = new TJJS_Region();
        public HXLDCont                Barcode_XLD = new HXLDCont();
        public HImage                  Image = new HImage();

        public string                  Barcode;
        public double                  Barcode_X,
                                       Barcode_Y;
        public double                  Barcode_Font_Size;


        public TFind_Barcode1_Result()
        {
             Set_Default();
        }

        override public TBase_Class New_Class()
        {
            return new TFind_Barcode1_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Barcode1_Result && dis_base is TFind_Barcode1_Result)
            {
                TFind_Barcode1_Result sor = (TFind_Barcode1_Result)sor_base;
                TFind_Barcode1_Result dis = (TFind_Barcode1_Result)dis_base;
                
                base.Copy(sor, dis);
                dis.JJS_Model.Set(sor.JJS_Model);
                dis.Find_Region.Set(sor.Find_Region);
                dis.Model_Result.Set(sor.Model_Result);
                //dis.Barcode_XLD = sor.Barcode_XLD.Clone();
                dis.Barcode = sor.Barcode;
            }
        }

        public override void Reset()
        {
            Find_OK = false;
            Barcode = "";
            JJS_Model.Set_Default();
            Find_Region.Set_Default();

            Barcode_XLD.Dispose();
            Barcode_XLD = new HXLDCont();

            Image.Dispose();
            Image = new HImage();
        }
        public override void Set_Default()
        {
            base.Set_Default();
            Find_OK = false;
            Msg_X = 10;
            Msg_Y = 300;
            Msg_Font_Size = 150;
            Barcode_X = 1;
            Barcode_Y = 50;
            Barcode_Font_Size = 30;
            JJS_Model.Set_Default();
            Find_Region.Set_Default();
        }
        override public void Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                base.Read(ini, section);
                tmp_section = section;
                Find_OK = ini.ReadBool(tmp_section, "Find_Ok", false);
            }
        }
        override public void Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                base.Write(ini, section);
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

        override public void Display_Message(HWindowControl hw, double scale)
        {
            string color = "";

            if (Find_OK) color = Model_Color_OK;
            else color = Model_Color_NG;

            if (Find_OK) JJS_Vision.Display_String(hw, Barcode, Barcode_X, Barcode_Y, Barcode_Font_Size, 1, color);
            JJS_Vision.Display_String(hw, Get_Message(), Msg_X, Msg_Y, Msg_Font_Size, 1, color);
        }
        override public void Display_Model(HWindowControl hw, double scale)
        {
            string color = "";

            if (Find_OK) color = Model_Color_OK;
            else color = Model_Color_NG;
                
            if (JJS_Vision.Is_Not_Empty(Barcode_XLD))
            {
                hw.HalconWindow.SetColor(color);
                Barcode_XLD.DispObj(hw.HalconWindow);
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
