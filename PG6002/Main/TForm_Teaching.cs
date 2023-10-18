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
using EFC.Vision.Halcon;
using EFC.Tool;
using EFC.INI;
using EFC.Camera;
using EFC.CAD;


namespace Main
{
    public partial class TForm_Teaching : Form
    {
        public TFind_Mothed_1_Result F_Result = new TFind_Mothed_1_Result();
        public TTeach Param = new TTeach();
        public emModel Model = emModel.PCB_L;
        public TTeach_Data_One_CCD Teach_Data = null;
        public TTeach_Cal_Data_One_CCD Cal_Data = null;

        public TForm_Teaching(TTeach param)
        {
            InitializeComponent();

            PageControl_Tool.Tab_Page_Select(TC_Main_01, "空白");
            PageControl_Tool.Tab_Page_Hide(TC_Main_01);
            Set_Param(param);
        }
        private void TForm_Teaching_Shown(object sender, EventArgs e)
        {
            TV_Menu.ExpandAll();
            TV_Menu.SelectedNode = TV_Menu.Nodes[0];

            tFrame_Display1.Dock = DockStyle.Fill;
            tFrame_Display1.On_Display = Disp_View; 
            Update_CCD();
            tFrame_Display1.Disp_Enabled = true;
        }
        private void TForm_Teaching_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void Disp_View(ref TFrame_JJS_HW jjs_hw, int index, bool fore_disp)
        {

            TCamera_Base camera = null;
            HImage image = new HImage();
            double scale = 1;
            int line_width = 1;
            int w, h;
            TFind_Mothed_1_Result f_result = null;

            try
            {
                camera = TPub.Cameras[index];

                f_result = F_Result; 

                //display image
                camera.Get_HImage(ref image);
                image.GetImageSize(out w, out h);
                scale = (double)w / jjs_hw.Width;

                jjs_hw.SetPart(image);
                jjs_hw.HW_Buf.HalconWindow.DispObj(image);
                f_result.Disp_Param.Msg_Font_Size = 20;
                f_result.Disp_Param.Msg_X = 20;
                f_result.Disp_Param.Msg_Y = 60;
                f_result.Disp_Param.Scale = scale;

                //display CCD name
                JJS_Vision.Display_String(jjs_hw.HW_Buf, camera.Name, 10, 10, 25, scale, "blue");

                //display 畫面十字線
                line_width = (int)Math.Round(2 * scale + 1, 0);
                jjs_hw.HW_Buf.HalconWindow.SetLineWidth(line_width);
                JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, image, "red");

                //display find data
                f_result.Display_Message(jjs_hw.HW_Buf);
                f_result.Display_Model(jjs_hw.HW_Buf);
            }
            catch { }
            jjs_hw.Copy_HW();
            image.Dispose();
        }
        private void Update_CCD()
        {
            int no = TPub.Get_Camera_No(Model);
            TCamera_Base camera = TPub.Get_Camera(Model);
            tFrame_Display1.Set_HW_Size(1, 1, new int[] { no }, camera.Image_Width, camera.Image_Height);
        }
        private void Set_Param(TTeach param)
        {
            Param.Set(param);
            Set_Param();
        }
        private void Set_Param()
        {
            Set_Param_Model();
            Set_Param_Teach_Data();
            Set_Param_Cal_Data();
        }
        private void Set_Param_Model()
        {
            if (Teach_Data != null && Cal_Data != null)
            {
            }
        }
        private void Set_Param_Teach_Data()
        {
            if (Teach_Data != null && Cal_Data != null)
            {
                E_Q1_Col.Text = Teach_Data.Q1.Col.ToString("0.000");
                E_Q1_Row.Text = Teach_Data.Q1.Row.ToString("0.000");
                E_Q1_Pos.Text = Teach_Data.Q1.Pos.ToString("0.000");
                                 
                E_Q2_Col.Text = Teach_Data.Q2.Col.ToString("0.000");
                E_Q2_Row.Text = Teach_Data.Q2.Row.ToString("0.000");
                E_Q2_Pos.Text = Teach_Data.Q2.Pos.ToString("0.000");

                E_Q_TX.Text = Teach_Data.Q_TX.ToString("0.000");
                E_Q_TY.Text = Teach_Data.Q_TY.ToString("0.000");
                E_Q_CCD_Y.Text = Teach_Data.Q_CCD_Y.ToString("0.000");

                E_CCD_Ofs_X.Text = Teach_Data.CCD_Ofs_X.ToString("0.000");
                E_CCD_Ofs_Y.Text = Teach_Data.CCD_Ofs_Y.ToString("0.000");
            }
        }
        private void Set_Param_Cal_Data()
        {
            if (Teach_Data != null && Cal_Data != null)
            {
                TJJS_Point center = null;

                center = Cal_Data.Center;
                E_Cal_Data_Center_X.Text = Cal_Data.Center.X.ToString("f3");
                E_Cal_Data_Center_Y.Text = Cal_Data.Center.Y.ToString("f3");
            }
        }

        private void Update_Param()
        {
            Update_Param_Teach_Data();
        }
        private void Update_Param_Teach_Data()
        {
            if (Teach_Data != null && Cal_Data != null)
            {
                try
                {
                    Teach_Data.Q1.Col = Convert.ToDouble(E_Q1_Col.Text);
                    Teach_Data.Q1.Row = Convert.ToDouble(E_Q1_Row.Text);
                    Teach_Data.Q1.Pos = Convert.ToDouble(E_Q1_Pos.Text);
                
                    Teach_Data.Q2.Col = Convert.ToDouble(E_Q2_Col.Text);
                    Teach_Data.Q2.Row = Convert.ToDouble(E_Q2_Row.Text);
                    Teach_Data.Q2.Pos = Convert.ToDouble(E_Q2_Pos.Text);
                   
                    Teach_Data.Q_TX = Convert.ToDouble(E_Q_TX.Text);
                    Teach_Data.Q_TY = Convert.ToDouble(E_Q_TY.Text);
                    Teach_Data.Q_CCD_Y = Convert.ToDouble(E_Q_CCD_Y.Text);
                 
                    Teach_Data.CCD_Ofs_X = Convert.ToDouble(E_CCD_Ofs_X.Text);
                    Teach_Data.CCD_Ofs_Y = Convert.ToDouble(E_CCD_Ofs_Y.Text);
                }
                catch { };
            }
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要套用設定並儲存檔案??", "套用生產設定", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Update_Param();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Save_As_Click(object sender, EventArgs e)
        {

        }
        private void B_Open_Click(object sender, EventArgs e)
        {

        }
        private void TV_Menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node;
            string node_full_name;

            Update_Param();
            node = TV_Menu.SelectedNode;
            node_full_name = TreeView_Tool.Get_Node_Full_Name(node);

            Teach_Data = null;
            Cal_Data = null;
            PageControl_Tool.Tab_Page_Select(TC_Main_01, "空白");
            L_Tree_Info.Text = "Root" + TreeView_Tool.Get_Node_Full_Text(node);
            switch (node_full_name)
            {
                #region PCB
                case "\\PCB\\Edit_Model":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "編輯標靶");
                    Model = emModel.PCB_L;
                    Update_CCD();
                    Teach_Data = Param.Teach_Data.PCB;
                    Cal_Data = Param.Cal_Data.PCB;
                    Set_Param();
                    break;

                case "\\PCB\\Teach":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "校驗");
                    Model = emModel.PCB_L;
                    Update_CCD();
                    Teach_Data = Param.Teach_Data.PCB;
                    Cal_Data = Param.Cal_Data.PCB;
                    Set_Param();
                    break;

                case "\\PCB\\Result":
                    PageControl_Tool.Tab_Page_Select(TC_Main_01, "校驗資訊");
                    Model = emModel.PCB_L;
                    Update_CCD();
                    Teach_Data = Param.Teach_Data.PCB;
                    Cal_Data = Param.Cal_Data.PCB;
                    Set_Param();
                    break;
                #endregion
            }
        }
        private void B_Model_L_Edit_Click(object sender, EventArgs e)
        {
            if (Teach_Data != null)
            {
                HImage image = new HImage();
                TCamera_Base camera = TPub.Get_Camera(Model);
                camera.Get_HImage(ref image);
                Teach_Data.Model.Set_Param(image);
            }
        }

        private void B_Q1_Click(object sender, EventArgs e)
        {
            double x = 0, y = 0, q = 0, ccd = 0;

            F_Result = Find(Model);
            Get_PLC_Pos(Model, ref x, ref y, ref q, ref ccd);
            if (F_Result.Find_OK)
            {
                E_Q1_Col.Text = F_Result.Col.ToString("0.00");
                E_Q1_Row.Text = F_Result.Row.ToString("0.00");
                E_Q1_Pos.Text = q.ToString("0.000");

                E_Q_TX.Text = x.ToString("0.00");
                E_Q_TY.Text = y.ToString("0.00");
                E_Q_CCD_Y.Text = ccd.ToString("0.00");
            }
        }
        private void B_Q2_Click(object sender, EventArgs e)
        {
            double x = 0, y = 0, q = 0, ccd = 0;

            F_Result = Find(Model);
            Get_PLC_Pos(Model, ref x, ref y, ref q, ref ccd);
            if (F_Result.Find_OK)
            {
                E_Q2_Col.Text = F_Result.Col.ToString("0.00");
                E_Q2_Row.Text = F_Result.Row.ToString("0.00");
                E_Q2_Pos.Text = q.ToString("0.000");

                E_Q_TX.Text = x.ToString("0.00");
                E_Q_TY.Text = y.ToString("0.00");
                E_Q_CCD_Y.Text = ccd.ToString("0.00");
            }
        }
        private void TForm_Teaching_Load(object sender, EventArgs e)
        {

        }


        private TFind_Mothed_1_Result Find(emModel model)
        {
            TFind_Mothed_1_Result result = new TFind_Mothed_1_Result();
            TCamera_Base camera = null;

            camera = TPub.Get_Camera(model);
            if (Teach_Data != null)
            {
                HImage tmp_Image = new HImage();
                camera.Get_HImage(ref tmp_Image);
                Teach_Data.Model.Find_Base(tmp_Image, ref result);
                if (!result.Find_OK)
                {
                    MessageBox.Show("自動搜索標把失敗", "警告", MessageBoxButtons.OK);
                }
            }
            return result; 
        }
        private void Get_PLC_Pos(emModel model, ref double x, ref double y, ref double q, ref double ccd)
        {
            TJJS_Value_List values = new TJJS_Value_List();

            TPub.Get_PLC_Pos(model, ref values);
            x = values.Get_Value_Double("Table_X");
            y = values.Get_Value_Double("Table_Y");
            q = values.Get_Value_Double("Table_Q");
            ccd = values.Get_Value_Double("ACF_Y");
        }


    }

    //-----------------------------------------------------------------------------------------------------
    // TTeach
    //-----------------------------------------------------------------------------------------------------
    public class TTeach : TBase_Class
    {
        private string In_Default_Path;
        public string Default_FileName;
        public string Teach_Name;
        public string FileName;
        public string Info;

        public TTeach_Data Teach_Data = new TTeach_Data();
        public TTeach_Cal_Data Cal_Data = new TTeach_Cal_Data();

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TTeach()
        {
        }
        override public TBase_Class New_Class()
        {
            return new TTeach();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach && dis_base is TTeach)
            {
                TTeach sor = (TTeach)sor_base;
                TTeach dis = (TTeach)dis_base;

                dis.Default_Path = sor.Default_Path;
                dis.Default_FileName = sor.Default_FileName;
                dis.FileName = sor.FileName;
                dis.Info = sor.Info;

                dis.Teach_Data.Set(sor.Teach_Data);
                dis.Cal_Data.Set(sor.Cal_Data);
                dis.Cal();
            }
        }

        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Teach_Data.Default_Path = path;
        }
        public void Set_Default()
        {
            In_Default_Path = "";
            Default_FileName = "Teach.xml";
            FileName = "";
            Info = "";
            Teach_Data.Set_Default();
            Cal_Data.Set_Default();
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Teach_Data.Read(ini, section + "/Teach_Data");
                Read_Other_File();
            }
            Cal();
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Teach_Data.Write(ini, section + "/Teach_Data");
                Write_Other_File();
            }
            Cal();
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Cal()
        {
            Cal_PCB_Center(Teach_Data.PCB, ref Cal_Data.PCB);
        }


        private void Cal_PCB_Center(TTeach_Data_One_CCD teach_data, ref TTeach_Cal_Data_One_CCD cal_data)
        {
            TJJS_Line l1 = new TJJS_Line();
            TJJS_Line l2 = new TJJS_Line();
            TJJS_Line l3 = new TJJS_Line();
            double dq = 0;
            TJJS_Point movedist = new TJJS_Point();
            TJJS_Value_List pos = new TJJS_Value_List();

            try
            {
                if (teach_data.Q1.Col != 0 && teach_data.Q1.Row != 0 && teach_data.Q1.Pos != 0 &&
                    teach_data.Q2.Col != 0 && teach_data.Q2.Row != 0 && teach_data.Q2.Pos != 0)
                {
                    pos.Add("Table_X", teach_data.Q_TX);
                    pos.Add("Table_Y", teach_data.Q_TY);
                    pos.Add("ACF_Y", teach_data.Q_CCD_Y);
                    l1.Start = TPub.Get_Abs_Pos(emModel.PCB_L, teach_data.Q1.Col, teach_data.Q1.Row, pos);
                    l1.End = TPub.Get_Abs_Pos(emModel.PCB_L, teach_data.Q2.Col, teach_data.Q2.Row, pos);
                    dq = (teach_data.Q2.Pos - teach_data.Q1.Pos) / 2;
                    l2 = l1.Rotate(l1.Start, 90 + dq);
                    l3 = l1.Rotate(l1.End, 90 - dq);
                    cal_data.Center = l2.Intersect(l3);
                    cal_data.Data_OK = true;
                }
                else
                    cal_data.Data_OK = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TTeach_Data
    //-----------------------------------------------------------------------------------------------------
    public class TTeach_Data : TBase_Class
    {
        private string In_Default_Path;
        public TTeach_Data_One_CCD PCB = new TTeach_Data_One_CCD();

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TTeach_Data()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Data();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Data && dis_base is TTeach_Data)
            {
                TTeach_Data sor = (TTeach_Data)sor_base;
                TTeach_Data dis = (TTeach_Data)dis_base;

                dis.PCB.Set(sor.PCB);
            }
        }

        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            PCB.Default_Path = In_Default_Path + "PCB\\";
        }
        public void Set_Default()
        {
            PCB.Set_Default();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                PCB.Read(ini, section + "/PCB");
                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                PCB.Write(ini, section + "/PCB");
                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
    }

    public class TTeach_Data_One_CCD : TBase_Class
    {
        private string In_Default_Path;
        public TTeach_Point Q1 = new TTeach_Point();
        public TTeach_Point Q2 = new TTeach_Point();
        public double Q_TX;
        public double Q_TY;
        public double Q_CCD_Y;

        public double CCD_Ofs_X;
        public double CCD_Ofs_Y;

        public TFind_Mothed_1_Param Model = new TFind_Mothed_1_Param();

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TTeach_Data_One_CCD()
        {
            Set_Default();
            Model.JJS_Model.Default_FileName = "Model1.mod";
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Data_One_CCD();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Data_One_CCD && dis_base is TTeach_Data_One_CCD)
            {
                TTeach_Data_One_CCD sor = (TTeach_Data_One_CCD)sor_base;
                TTeach_Data_One_CCD dis = (TTeach_Data_One_CCD)dis_base;

                dis.Q1.Set(sor.Q1);
                dis.Q2.Set(sor.Q2);
                dis.Q_TX = sor.Q_TX;
                dis.Q_TY = sor.Q_TY;
                dis.Q_CCD_Y = sor.Q_CCD_Y;

                dis.CCD_Ofs_X = sor.CCD_Ofs_X;
                dis.CCD_Ofs_Y = sor.CCD_Ofs_Y;

                dis.Model.Set(sor.Model);
            }
        }

        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Model.Default_Path = In_Default_Path + "Model\\";
            Model.JJS_Model.Default_Path = Model.Default_Path;
            Model.JJS_Model.Default_FileName = "Model.mod";
        }
        public void Set_Default()
        {
            Q1.Set_Default();
            Q2.Set_Default();
            Q_TX = 0;
            Q_TY = 0;
            Q_CCD_Y = 0;

            CCD_Ofs_X = 0.0;
            CCD_Ofs_Y = 0.0;

            Model.Set_Default();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Q1.Read(ini, section + "/Q1");
                Q2.Read(ini, section + "/Q2");
                Q_TX = ini.ReadFloat(section, "Q_TX", Q_TX);
                Q_TY = ini.ReadFloat(section, "Q_TY", Q_TY);
                Q_CCD_Y = ini.ReadFloat(section, "Q_CCD_Y", Q_CCD_Y);

                CCD_Ofs_X = ini.ReadFloat(section, "CCD_Ofs_X", CCD_Ofs_X);
                CCD_Ofs_Y = ini.ReadFloat(section, "CCD_Ofs_Y", CCD_Ofs_Y);

                Model.Read(ini, section + "/Model");

                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Q1.Write(ini, section + "/Q1");
                Q2.Write(ini, section + "/Q2");
                ini.WriteFloat(section, "Q_TX", Q_TX);
                ini.WriteFloat(section, "Q_TY", Q_TY);
                ini.WriteFloat(section, "Q_CCD_Y", Q_CCD_Y);

                ini.WriteFloat(section, "CCD_Ofs_X", CCD_Ofs_X);
                ini.WriteFloat(section, "CCD_Ofs_Y", CCD_Ofs_Y);

                Model.Write(ini, section + "/Model");

                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
    }

    public class TTeach_Point : TBase_Class
    {
        public double Col, Row, Pos;

        public TTeach_Point()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Point();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Point && dis_base is TTeach_Point)
            {
                TTeach_Point sor = (TTeach_Point)sor_base;
                TTeach_Point dis = (TTeach_Point)dis_base;

                dis.Col = sor.Col;
                dis.Row = sor.Row;
                dis.Pos = sor.Pos;
            }
        }

        public void Set_Default()
        {
            Col = 0;
            Row = 0;
            Pos = 0;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Col = ini.ReadFloat(section, "Col", 0.0);
                Row = ini.ReadFloat(section, "Row", 0.0);
                Pos = ini.ReadFloat(section, "Pos", 0.0);

                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Col", Col);
                ini.WriteFloat(section, "Row", Row);
                ini.WriteFloat(section, "Pos", Pos);

                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {

        }
        public void Write_Other_File()
        {

        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TTeach_Cal_Data
    //-----------------------------------------------------------------------------------------------------
    public class TTeach_Cal_Data : TBase_Class
    {
        public TTeach_Cal_Data_One_CCD PCB = new TTeach_Cal_Data_One_CCD();

        public TTeach_Cal_Data()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Cal_Data();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Cal_Data_One_CCD && dis_base is TTeach_Cal_Data_One_CCD)
            {
                TTeach_Cal_Data sor = (TTeach_Cal_Data)sor_base;
                TTeach_Cal_Data dis = (TTeach_Cal_Data)dis_base;

                dis.PCB.Set(sor.PCB);
            }
        }

        public void Set_Default()
        {
            PCB.Set_Default();
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                PCB.Read(ini, section + "/PCB");
                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                PCB.Write(ini, section + "/PCB");
                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {

        }
        public void Write_Other_File()
        {

        }
    }
    public class TTeach_Cal_Data_One_CCD : TBase_Class
    {
        public bool Data_OK = false;
        public TJJS_Point Center = new TJJS_Point();

        public TTeach_Cal_Data_One_CCD()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TTeach_Cal_Data_One_CCD();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TTeach_Cal_Data_One_CCD && dis_base is TTeach_Cal_Data_One_CCD)
            {
                TTeach_Cal_Data_One_CCD sor = (TTeach_Cal_Data_One_CCD)sor_base;
                TTeach_Cal_Data_One_CCD dis = (TTeach_Cal_Data_One_CCD)dis_base;

                dis.Data_OK = sor.Data_OK;
                dis.Center.Set(sor.Center);
            }
        }

        public void Set_Default()
        {
            Data_OK = false;
            Center.Set(0, 0);
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Read_Other_File();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Write_Other_File();
            }
            return true;
        }
        public void Read_Other_File()
        {

        }
        public void Write_Other_File()
        {

        }
    }
}
