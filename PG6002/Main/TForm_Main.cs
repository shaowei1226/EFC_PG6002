using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using HalconDotNet;
using System.IO;
using EFC.CAD;
using EFC.Tool;
using EFC.Light;
using EFC.Measure;
using EFC.Vision.Halcon;
using EFC.Camera;
using EFC.Camera.Sentech;
using EFC.File_Manager;
using EFC.Robot.Epson;


namespace Main
{
    public enum emDisplay_Mode { X1_1, X1_2, X2_1 };
    public enum emLog_Display_Mode { None, X6_4 };


    public partial class TForm_Main : Form
    {
        public string Log_Source = "TForm_Main";

        public bool On_MU_Select = false;
        public emDisplay_Mode View_Mode = emDisplay_Mode.X2_1;
        public emLog_Display_Mode Log_Disp_Mode = emLog_Display_Mode.X6_4;
        public int Disp_Mode_Page = 0;
        public TFrame_Set_Light[] Frame_Set_Light = new TFrame_Set_Light[4];
        public bool Flag_Show_Tool = false;
        public TEpson_Robot Robot = null;
       
        public int Page_Count
        {
            get
            {
                int result = 0;
                switch (Log_Disp_Mode)
                {
                    case emLog_Display_Mode.X6_4: result = 24; break;
                }
                return result;
            }
        }
        public TForm_Main()
        {
            InitializeComponent();//初始化組件
            Frame_Set_Light[0] = tFrame_Set_Light1;
            Frame_Set_Light[1] = tFrame_Set_Light2;
            Frame_Set_Light[2] = tFrame_Set_Light3;
            Frame_Set_Light[3] = tFrame_Set_Light4;

            HSystem.SetSystem("clip_region", "false");    //設置HALCON系統參數(要更改的系統參數的名稱_默認值“init_new_image”,系統參數的新值_默認值“true”)
            TPub.Init();
            //JJS_Vision.Read_File(ref TPub.Find_Data.COF_Out_Check.Tile_Image, "e:\\110607.jpg");
        }
        private void TForm_Main_Shown(object sender, EventArgs e)
        {
            Robot = TPub.Robot1;
            //TPub.User_Management.User.Level = 2;
            tFrame_Display1.Dock = DockStyle.Fill;
            tFrame_Display1.On_Display = TPub.Disp_View; 
            tFrame_Display1.Disp_Enabled = true;
            Set_Halcon_View(View_Mode);//畫面分割
            Set_CCD_Name();
            Set_Light_Box(0);

            tFrame_Display2.Dock = DockStyle.Fill;
            tFrame_Display2.On_Display = TPub.Disp_Log;
            Set_Disp_Mode(Log_Disp_Mode);

            tFrame_Display3.Dock = DockStyle.Fill;
            tFrame_Display3.On_Display = TPub.Disp_Log_ACF;
            tFrame_Display3.Set_HW_Size(2, 1, Get_Check_Index(), TPub.Environment.CCDs[0].Pixel_X, TPub.Environment.CCDs[0].Pixel_Y);

            Update_Menu();
            Update_Recipe();
            Update_View_Mode();

            TPub.All_Grab_Life();
            //TPub.All_Grab_Stop();
            Form_Start();
        }
        private void TSB_Reset_All_Click(object sender, EventArgs e)
        {
            TPub.Reset_All();
        }
        private void Form_Close()
        {
            Form_Stop();
            TPub.Set_Light_All_OFF();
            TPub.Dispose();
            try
            {
                Environment.Exit(Environment.ExitCode); //強制結束所有處理程序
            }
            catch { }
            Close();
        }
        private void TForm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_Close();
        }
        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            TPub.Log.Add(Log_Source, fun, msg_str, type);
        }


        #region tFrame_Display2
        public void Set_Disp_Mode(emLog_Display_Mode mode)
        {
            Log_Disp_Mode = mode;
            int[] index = null;
            int w = 640;
            int h = 480;

            index = Get_Disp_Mode_Index();
            switch (Log_Disp_Mode)
            {
                case emLog_Display_Mode.X6_4: tFrame_Display2.Set_HW_Size(6, 4, index, w, h); break;
            }
            //CB_View_Mode.SelectedIndex = Get_Display_Mode_Int(View_Mode);
            Set_Page_List();
            //Update_HW_View();
        }
        private void Set_Page_List()
        {
            int count = TPub.Get_Max_Int(TPub.Image_Logs.Count, Page_Count);
            int old_index = CB_Page_Name.SelectedIndex;

            CB_Page_Name.Items.Clear();
            for (int i = 0; i < count; i++)
            {
                CB_Page_Name.Items.Add((i + 1).ToString());
            }
            if (old_index >= CB_Page_Name.Items.Count) old_index = CB_Page_Name.Items.Count - 1;
            if (old_index < CB_Page_Name.Items.Count) CB_Page_Name.SelectedIndex = old_index;
        }
        public int[] Get_Disp_Mode_Index()
        {
            int[] result = new int[Page_Count];
          
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Disp_Mode_Page * Page_Count + i;
            }
            return result;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Set_Disp_Mode(emLog_Display_Mode.X6_4);
        }
        private void CB_Page_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] index = null;

            Disp_Mode_Page = CB_Page_Name.SelectedIndex;
            index = Get_Disp_Mode_Index();
            tFrame_Display2.Set_Index(index);
            tFrame_Display2.Repaint();
        }
        #endregion

        #region tFrame_Display3
        public int[] Get_Check_Index()
        {
            int[] result = new int[2];

            result[0] = 0;
            result[1] = 1;
            return result;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            #region PLC
            if (TPub.PLC.PLC_Socket.Connect)
            {
                P_PLC.BackColor = Color.Green;
                L_PLC_Text.Text = "連線中";
                E_PLC_Time.Text = string.Format("{0:f0}ms", TPub.PLC.Scan_Time);
            }
            else
            {
                P_PLC.BackColor = Color.Red;
                L_PLC_Text.Text = "中斷";
                E_PLC_Time.Text = string.Format("{0:f0}ms", 0);
            }
            #endregion

            #region Log
            TPub.Log.Display(DG_Log);
            #endregion

            #region Robot1
            Form_Tool.Set_Panel_Face(P_Robot1, TPub.Robot1.Connected, Color.Green, Color.Red);
            if (TPub.Robot1.Connected)
            {
                L_Robot1_Text.Text = "連線中";
            }
            else
            {
                L_Robot1_Text.Text = "連線中斷";
            }
            #endregion
            if (TPub.PLC.PLC_Out.Robot1_Loop_Run.Finish && TPub.PLC.PLC_Out.Robot1_Loop_Run.OK)
            {
                Log_Add("On_Pos", string.Format("Robot1_Loop_Run type={0:d}, step={1:d}___On_Pos", TPub.PLC.PLC_In.Robot1_Loop_Run_Type, TPub.PLC.PLC_In.Robot1_Loop_Run_Step));
            }
            #region Robot
            switch (CB_Robot.SelectedIndex)
            {
                   case 0: Set_Robot_Status(TPub.Robot1); Set_Robot1_Program_Status(); break;
            }
            #endregion

            Disp_ACF_Check_Result();
            Plasma_Clean_Count();
            Open_MU_Select();
            File_Manager.Delete();

            timer1.Enabled = true;
        }
        public void Set_Robot_Status(TEpson_Robot robot)
        {
       //     TPLC RB_POS = new TPLC();
            E_Robot_X.Text = robot.Now_Pos.X.ToString("0.000");
         //   RB_POS.PLC_Out.RB_Now_Pos_X = robot.Now_Pos.X;
          //  RB_now_X.Text = RB_POS.PLC_Out.RB_Now_Pos_X.ToString();
            E_Robot_Y.Text = robot.Now_Pos.Y.ToString("0.000");
          //  RB_POS.PLC_Out.RB_Now_Pos_Y = robot.Now_Pos.Y;
           // RB_now_Y.Text = RB_POS.PLC_Out.RB_Now_Pos_Y.ToString();
            E_Robot_Z.Text = robot.Now_Pos.Z.ToString("0.000");
            E_Robot_U.Text = robot.Now_Pos.U.ToString("0.000");
            E_Robot_V.Text = robot.Now_Pos.V.ToString("0.000");
            E_Robot_W.Text = robot.Now_Pos.W.ToString("0.000");

            E_Robot_Speed_Factor.Text = robot.Program_Speed_Factor.ToString();
            CB_Robot_Error_On.Checked = robot.Error_On;
            CB_Robot_EStop_On.Checked = robot.EStop_On;
            CB_Robot_Safety_On.Checked = robot.Safety_On;
            CB_Robot_Motors_On.Checked = robot.Motors_On;
            CB_Robot_Power_High.Checked = robot.Power_High;
            CB_Robot_Warning_On.Checked = robot.Warning_On;

            E_Robot_Error_On_Code.Text = robot.ErrorCode.ToString();
            E_Robot_Warning_On_Code.Text = robot.Warning_Code.ToString();
        }
        public void Set_Robot1_Program_Status()
        {
            TRobot1_Program prg = TPub.Robot1_Program;

            Form_Tool.Set_Button_Face(B_Robot_Run, prg.Program_Running, Color.Green, Color.Gray);
            Form_Tool.Set_Button_Face(B_Robot_Stop, !prg.Program_Running, Color.Green, Color.Gray);

            B_Robot_Loop_Run_Apply.Enabled = (prg.Program_Running && !prg.IO_In.Loop_Run_Req);
            B_Robot_Loop_Run_Reset.Enabled = (prg.Program_Running && prg.IO_In.Loop_Run_Req && prg.IO_Out.Loop_Run_Finish);

            E_Robot_Program_Speed.Text = prg.Program_Speed_Factor.ToString();
            E_Robot_Loop_Type.Text = prg.IO_Out.Loop_Run_Type.ToString();
            E_Robot_Loop_Step.Text = prg.IO_Out.Loop_Run_Step.ToString();
            E_Robot_Loop_Tray_No.Text = prg.IO_Out.Loop_Run_Tray_No.ToString();
            E_Robot_Loop_Tray_Z_No.Text = prg.IO_Out.Loop_Run_Tray_Z_No.ToString();

            CB_Robot_Program_Running.Checked = prg.Program_Running;
            CB_Robot_Loop_Run_Req.Checked = prg.IO_In.Loop_Run_Req;
            CB_Robot_Loop_Running.Checked = prg.IO_Out.Loop_Running;
            CB_Robot_Loop_Run_Finish.Checked = prg.IO_Out.Loop_Run_Finish;
            CB_Robot_Loop_Run_OK.Checked = prg.IO_Out.Loop_Run_OK;

            if (prg != null)
            {
                B_Robot_Loop_Run_Apply.Enabled = (prg.Program_Running && !prg.IO_In.Loop_Run_Req);
                B_Robot_Loop_Run_Reset.Enabled = (prg.Program_Running && prg.IO_In.Loop_Run_Req && prg.IO_Out.Loop_Run_Finish);
            }
        }


        public void Disp_ACF_Check_Result()
        {
            DataGridView dg = DG_ACF_Check;
            Color color1, color2;
            TImage_Log image_log1 = null;
            TImage_Log image_log2 = null;

            if (TPub.Recipe.ACF.Pos_List.Count > 0)
            {
                dg.RowCount = TPub.Recipe.ACF.Pos_List.Count;
                for (int i = 0; i < dg.RowCount; i++)
                {
                    image_log1 = TPub.Image_Logs.Get_Image_Log(TPub.Get_Model_Name(emModel.ACF_Check1, i));
                    image_log2 = TPub.Image_Logs.Get_Image_Log(TPub.Get_Model_Name(emModel.ACF_Check2, i));
                    if (image_log1 != null && image_log2 != null)
                    {
                        if (image_log1.Result_ACF_Check.Find_OK) color1 = Color.Green;
                        else color1 = Color.Red;

                        if (image_log2.Result_ACF_Check.Find_OK) color2 = Color.Green;
                        else color2 = Color.Red;

                        dg.Rows[i].Cells[00].Value = string.Format("{0:d}", i + 1);
                        dg.Rows[i].Cells[01].Value = string.Format("{0:f1}", image_log1.Result_ACF_Check.Param_Ptr.Min_Gray);
                        dg.Rows[i].Cells[02].Value = string.Format("{0:f1}", image_log1.Result_ACF_Check.Mean_Gray);
                        dg.Rows[i].Cells[03].Value = string.Format("{0:f1}", image_log1.Result_ACF_Check.Param_Ptr.Max_Gray);
                        dg.Rows[i].Cells[04].Value = string.Format("{0:f1}", image_log2.Result_ACF_Check.Param_Ptr.Min_Gray);
                        dg.Rows[i].Cells[05].Value = string.Format("{0:f1}", image_log2.Result_ACF_Check.Mean_Gray);
                        dg.Rows[i].Cells[06].Value = string.Format("{0:f1}", image_log2.Result_ACF_Check.Param_Ptr.Max_Gray);

                        dg.Rows[i].Cells[01].Style.BackColor = Color.Gray;
                        dg.Rows[i].Cells[02].Style.BackColor = color1;
                        dg.Rows[i].Cells[03].Style.BackColor = Color.Gray;
                        dg.Rows[i].Cells[04].Style.BackColor = Color.Gray;
                        dg.Rows[i].Cells[05].Style.BackColor = color2;
                        dg.Rows[i].Cells[06].Style.BackColor = Color.Gray;
                    };
                }
            }
        }
        public void Plasma_Clean_Count()
        {
            ME_Plasma_Clean_Speed.Text = TPub.PLC.PLC_Recipe.Plasma_Clean_Speed.ToString();
            ME_Plasma_Clean_Count.Text = TPub.PLC.PLC_Recipe.Plasma_Clean_Count.ToString();
        }
        public void Open_MU_Select()
        {
            if (!On_MU_Select && TPub.MU_Data_List.Count > 0)
            {
                Form_Stop();
                On_MU_Select = true;
                TForm_MU_Select form = new TForm_MU_Select(TPub.MU_Data_List[0], TPub.MU_Select_Display, TPub.MU_Select_Get_Find_Data, TPub.MU_Select_Get_Finish);
                Log_Add("Open_MU_Select", string.Format("[On_MU_Select] Name={0:s} Title={1:s}", TPub.MU_Data_List[0].Name, TPub.MU_Data_List[0].Title_String));
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TPub.MU_Data_List.RemoveAt(0);
                }
                On_MU_Select = false;
                Form_Start();
            }
        }
        public void Form_Start()
        {
            timer1.Enabled = true;
            tFrame_Display1.Disp_Enabled = true;
            tFrame_Display2.Disp_Enabled = true;
            tFrame_Display3.Disp_Enabled = true;
        }
        public void Form_Stop()
        {
            timer1.Enabled = false;
            tFrame_Display1.Disp_Enabled = false;
            tFrame_Display2.Disp_Enabled = false;
            tFrame_Display3.Disp_Enabled = false;
        }
        public void Update_Menu()
        {
            TPub.User_Management.User.Level = 9;
            E_User_Name.Text = TPub.User_Management.User.Name;
            E_User_Level.Text = TPub.User_Management.User.Level.ToString();
            if (TPub.User_Management.User.Level <= 0)
            {
                MI_Recipe.Enabled = false;
                MI_Teach.Enabled = false;
                MI_Environment.Enabled = false;
            }
            else
            {
                MI_Recipe.Enabled = true;
                MI_Teach.Enabled = true;
                MI_Environment.Enabled = true;
            }
        }
        public void Update_Recipe()
        {
            ComboBox cb = null;
            int count = 0;

            E_Recipe_ID.Text = TPub.Recipe.Recipe_Name;
            E_Recipe_Info.Text = TPub.Recipe.Info;

            Set_ComboBox(CB_ACF_Check_No, TPub.Recipe.ACF.Pos_List.Count);

            //TPub.Set_Light(emModel.ACF_In_A_L, 0);
            //TPub.Set_Light(emModel.ACF_In_A_R, 0);
            //TPub.Set_Light(emModel.ACF_Out_A_L, 0);
            //TPub.Set_Light(emModel.ACF_Out_A_R, 0);

            //TPub.Set_Light(emModel.Pre1_A_L, 0);
            //TPub.Set_Light(emModel.Pre1_A_R, 0);
            //TPub.Set_Light(emModel.Pre2_A_L, 0);
            //TPub.Set_Light(emModel.Pre2_A_R, 0);
            //TPub.Set_Light(emModel.Main_A_L, 0);
            //TPub.Set_Light(emModel.Main_A_R, 0);
            //Set_Light_Box(CB_Light_Box.SelectedIndex);
        }
        public void Set_ComboBox(ComboBox cb, int count, int index = 0)
        {
            cb.Items.Clear();
            for (int i = 0; i < count; i++) cb.Items.Add((i + 1).ToString());
            if (index >= 0 && index < count) cb.SelectedIndex = index;
        }
        private void MI_Login_Click(object sender, EventArgs e)
        {
            TPub.User_Management.RFID_Login = false;
            if (TPub.User_Management.Login_Form_User(TPub.User_Management.User))
            {

            }
            Update_Menu();
            TPub.User_Management.RFID_Login = true;
        }
        private void MI_Logout_Click(object sender, EventArgs e)
        {
            TPub.User_Management.Logout();
            Update_Menu();
        }
        private void MI_Close_Click(object sender, EventArgs e)
        {
            Form_Close();
        }
        private void MI_Environment_Click(object sender, EventArgs e)
        {
            if (TPub.User_Management.User.Level >= 1)
            {
                Form_Stop();
                TForm_Environment form = new TForm_Environment(TPub.Environment);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    TPub.Environment.Set(form.Param);
                    TPub.Environment.Write();
                    TPub.Update_Environment();
                }
  
                Form_Start();
            }
            else
            {
                MessageBox.Show("請登入使用者帳號");
            }
        }
        private void MI_Teach2_Click(object sender, EventArgs e)
        {
            Form_Stop();

            TEFC_Message.Show("編輯教導參數", "", 500);
            TForm_Teaching form = new TForm_Teaching(TPub.Teach);
            TEFC_Message.End();

            if (form.ShowDialog() == DialogResult.OK)
            {
                TEFC_Message.Show("套用教導參數", "", 500);
                TPub.Teach.Set(form.Param);
                TPub.Teach.Teach_Name = TPub.Recipe.Recipe_Name;
                TPub.Teach.Write();
                TEFC_Message.End();
            }
            form.Dispose();
            form = null;
            Form_Start();
        }
        private void TSM_Recipe_Click(object sender, EventArgs e)
        {
            string fun = "TSM_Recipe_Click";
            TPub.User_Management.User.Level = 9;
            if (TPub.User_Management.User.Level >= 1)
            {
                Form_Stop();

                TEFC_Message.Show("編輯生產參數", "", 500);
                TForm_Select_Recipe form = new TForm_Select_Recipe(TPub.Recipe);
                TEFC_Message.End();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    Log_Add(fun, "套用生產參數");
                    bool flag = false;
                    TEFC_Message.Show("套用生產參數", "", 500);
                    TPub.Recipe.Log_Diff(TPub.Log, "Recipe", form.Param, ref flag);
                    TPub.Recipe.Set(form.Param);
                    TPub.Recipe.Write();
                    TPub.Environment.Base.Recipe_Name = TPub.Recipe.Recipe_Name;
                    TEFC_Message.End();

                    TPub.Environment.Write();
                    TPub.Apply_Recipe();
                    TPub.Write_Recipe_To_PLC();
                    Update_Recipe();
                }
                form.Dispose();
                form = null;
                Form_Start();
            }
            else
            {
                MessageBox.Show("請登入使用者帳號");
            }
        }
        private void MI_ViewData_In_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_In.View_Data(TPub.Environment.Base.Database_Path + "In.csv");
        }
        private void MI_ViewData_Out_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_Out.View_Data(TPub.Environment.Base.Database_Path + "Out.csv");
        }
        private void MI_ViewData_Recipe_Click(object sender, EventArgs e)
        {
            TPub.PLC.PLC_Recipe.View_Data(TPub.Environment.Base.Database_Path + "Recipe.csv");
        }
        private void MI_Info_Click(object sender, EventArgs e)
        {
            TForm_Information form = new TForm_Information();
            form.ShowDialog();
        }

        #region Find PCB
        private void B_PCB_L_Find_Click(object sender, EventArgs e)
        {
            emModel model = emModel.PCB_L;

            TPub.Find(model);
        }
        private void B_PCB_R_Find_Click(object sender, EventArgs e)
        {
            emModel model = emModel.PCB_R;

            TPub.Find(model);
        }
        private void B_PCB_L_MU_Find_Click(object sender, EventArgs e)
        {
            emModel model = emModel.PCB_L;

            TPub.MU_Select(model);
        }
        private void B_PCB_R_MU_Find_Click(object sender, EventArgs e)
        {
            emModel model = emModel.PCB_R;

            TPub.MU_Select(model);
        }
        private void B_PCB_L_Light_Click(object sender, EventArgs e)
        {
            emModel model = emModel.PCB_L;

            TPub.Set_Light(model);
        }
        private void B_PCB_R_Light_Click(object sender, EventArgs e)
        {
            emModel model = emModel.PCB_R;

            TPub.Set_Light(model);
        }
        private void B_PCB_Cal_Click(object sender, EventArgs e)
        {
            TPub.Cal_PCB();
        }
        private void B_PCB_Cal_Check_Click(object sender, EventArgs e)
        {
            int no = CB_ACF_Check_No.SelectedIndex;

            TPub.Cal_ACF_Check_1(no);
        }
        private void B_PCB_Cal_Check_R_Click(object sender, EventArgs e)
        {
            int no = CB_ACF_Check_No.SelectedIndex;

            TPub.Cal_ACF_Check_2(no);
        }
        private void B_PCB_Check_Read_Click(object sender, EventArgs e)
        {
            TFind_ACF_Check_Result check_result = null;
            emModel model = emModel.ACF_Check1;

            check_result = TPub.Image_Logs.Get_Result_ACF_Check(model);
            if (check_result != null)
            {
                check_result.Sample_Image = Dialog_Tool.Open_Dialog_Image();
            }
        }
        private void B_PCB_Check_Write_Click(object sender, EventArgs e)
        {
            TFind_ACF_Check_Result check_result = null;
            emModel model = emModel.ACF_Check1;

            check_result = TPub.Image_Logs.Get_Result_ACF_Check(model);
            if (check_result != null)
            {
                Dialog_Tool.Save_Dialog_Image(check_result.Sample_Image);
            }
        }
        #endregion
        public void Update_View_Mode()
        {
        }
        private void TSM_View_Click(object sender, EventArgs e)
        {
            ToolStripItem obj = (ToolStripItem)sender;
            string name = obj.Name;

            switch (name)
            {
                #region X1
                case "TSM_X1_1": Set_Halcon_View(emDisplay_Mode.X1_1); break;
                case "TSM_X1_2": Set_Halcon_View(emDisplay_Mode.X1_2); break;
                #endregion

                #region X2
                case "TSM_X2": Set_Halcon_View(emDisplay_Mode.X2_1); break;
                #endregion
            }
        }
        private void Set_Halcon_View(emDisplay_Mode mode)
        {
            int w, h;

            w = TPub.Cameras[0].Image_Width;
            h = TPub.Cameras[0].Image_Height;
            View_Mode = mode;
            switch (View_Mode)
            {
                #region X1
                case emDisplay_Mode.X1_1:
                    tFrame_Display1.Set_HW_Size(1, 1, new int[] { 0 }, w, h);
                    break;

                case emDisplay_Mode.X1_2:
                    tFrame_Display1.Set_HW_Size(1, 1, new int[] { 1 }, w, h);
                    break;
                #endregion

                #region X2
                case emDisplay_Mode.X2_1:
                    tFrame_Display1.Set_HW_Size(2, 1, new int[] { 0 , 1}, w, h);
                    break;
                #endregion
            }
            tFrame_Display1.Repaint();
        }
        private void B_Measure_Click(object sender, EventArgs e)
        {
            Form_Stop();
            TForm_Measure form = new TForm_Measure(TPub.Get_CCD_Name_All(), TPub.Measure_CCD_Change, TPub.Measure_Get_Find_Data, TPub.Measure_Get_Abs_Pos);
            form.ShowDialog();
            Form_Start();
        }
        private void B_Load_Image_Click(object sender, EventArgs e)
        {
            int ccd_no = CB_Select_CCD.SelectedIndex;
            //int pos_no = CB_Pos.SelectedIndex;
            HImage image = null;

            if (ccd_no >= 0)
            {
                image = Dialog_Tool.Open_Dialog_Image();
                if (JJS_Vision.Is_Not_Empty(image))
                {
                    TPub.Cameras[ccd_no].Select_Image = image.Clone();
                    TPub.Cameras[ccd_no].Used_Select_Image = true;
                    TPub.Cameras[ccd_no].Refalsh = true;
                    CB_Used_Select_Image.Checked = TPub.Cameras[ccd_no].Used_Select_Image;
                }
            }
        }
        private void B_Save_Image_Click(object sender, EventArgs e)
        {
            int ccd_no = CB_Select_CCD.SelectedIndex;
            //int pos_no = CB_Pos.SelectedIndex;
            HImage image = null;

            if (ccd_no >= 0)
            {
                image = TPub.Cameras[ccd_no].Get_HImage();
                Dialog_Tool.Save_Dialog_Image(image);
            }
        }
        private void CB_Select_CCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Image_Tool(CB_Select_CCD.SelectedIndex);
        }
        private void CB_Used_Select_Image_CheckedChanged(object sender, EventArgs e)
        {
            int no = 0;

            no = CB_Select_CCD.SelectedIndex;
            if (no < TPub.Cameras.Length && TPub.Cameras[no] != null)
            {
                TPub.Cameras[no].Used_Select_Image = CB_Used_Select_Image.Checked;
                Set_Image_Tool(CB_Select_CCD.SelectedIndex);
            }
        }
        private void Set_Image_Tool(int no)
        {
            if (no < TPub.Cameras.Length)
                if (TPub.Cameras[no] != null)
                    CB_Used_Select_Image.Checked = TPub.Cameras[no].Used_Select_Image;
        }
        public void Set_CCD_Name()
        {
            string[] ccd_name = new string[TPub.Cameras.Length];

            ccd_name = TPub.Get_CCD_Name_All();
            CB_Select_CCD.Items.Clear();
            for (int i = 0; i < ccd_name.Length; i++)
                CB_Select_CCD.Items.Add(ccd_name[i]);
            CB_Select_CCD.SelectedIndex = 0;
        }
        private void B_ALL_Open_Click(object sender, EventArgs e)
        {
            TPub.Set_Light_All_ON();
        }
        private void B_ALL_Close_Click(object sender, EventArgs e)
        {
            TPub.Set_Light_All_OFF();
        }
        private void CB_Light_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Light_Box(CB_Light_Box.SelectedIndex);
        }
        public void Set_Light_Box(int index)
        {
            TLight_Channel[] light_data = new TLight_Channel[4];

            if (index >= 0 && index <= 3)
            {
                for (int i = 0; i < 4; i++)
                    light_data[i] = TPub.Light1.Channels[index * 4 + i];
            }

            for (int i = 0; i < light_data.Length; i++)
                Frame_Set_Light[i].Set(light_data[i]);
        }
        private void TSM_All_Grab_Life_Click(object sender, EventArgs e)
        {
            TPub.All_Grab_Life();
        }
        private void TSM_All_Grab_Stop_Click(object sender, EventArgs e)
        {
            TPub.All_Grab_Stop();
        }
        private void panel7_VisibleChanged(object sender, EventArgs e)
        {
            tFrame_Display2.Repaint();
        }
        private void panel27_VisibleChanged(object sender, EventArgs e)
        {
            tFrame_Display3.Repaint();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            DG_Log.ClearSelection();
            if (DG_Log.RowCount > 0) DG_Log.FirstDisplayedScrollingRowIndex = 0;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            TForm_Log_Sort form = new TForm_Log_Sort(TPub.Log);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TPub.Log.Reflash = true;
            }
        }
        private void TSM_X1_Click(object sender, EventArgs e)
        {

        }

        private void B_Tool_Click(object sender, EventArgs e)
        {
            Flag_Show_Tool = !Flag_Show_Tool;
            Show_Tool();
        }
        private void Show_Tool()
        {
            if (TPub.User_Management.User.Level >= 1 && Flag_Show_Tool)
            {
                panel6.Width = 412;
               TPC_Tool.Enabled = true;
            }
            else
            {
                panel6.Width = 1;
                TPC_Tool.Enabled = false;
            }
        }

        #region Robot
        private void CB_Robot_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private void B_Robot_Manager_Click(object sender, EventArgs e)
        {
            Robot.Show_Dialog_Robot_Manager(this);
        }
        private void B_Robot_Simulator_Click(object sender, EventArgs e)
        {
            Robot.Show_Window_Simulator(this);
        }

        private int Get_Robot1_Type(string type)
        {
            int result = 0;

            switch (type)
            {
                case "Home": result = 1; break;
                case "Tray_Load": result = 2; break;
                case "Plasma_Load": result = 3; break;
                case "Plasma_Unload": result = 4; break;
                case "ACF_Load": result = 5; break;
                case "ACF_Unload": result = 6; break;
                case "PCB_Load": result = 7; break;
                case "PCB_Unload": result = 8; break;
                case "NG": result = 9; break;
                case "Teach": result = 10; break;
               
            }
            return result;
        }
        #endregion

        private void CB_Robot_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int robot_no = CB_Robot.SelectedIndex;

            switch (robot_no)
            {
                case 0:
                    Robot = TPub.Robot1;
                    string[] robot1_type = new string[] { "Home", "Tray_Load", "Plasma_Load", "Plasma_Unload","ACF_Load","ACF_Unload","PCB_Load","PCB_Unload", "NG","Teach" };
                    CB_Robot_In_Loop_Run_Type.Items.Clear();
                    CB_Robot_In_Loop_Run_Type.Items.AddRange(robot1_type);
                    CB_Robot_In_Loop_Run_Type.SelectedIndex = 0;
                    break;
            }
        }

        private void B_Robot_Run_Click_1(object sender, EventArgs e)
        {
            Robot.Program_Start();
        }

        private void B_Robot_Stop_Click_1(object sender, EventArgs e)
        {
            Robot.Program_Stop();
        }

        private void B_Robot_Init_Click(object sender, EventArgs e)
        {   
             
             Robot.Program.Program_Init();

        }

        private void B_Robot_Speed_Apply_Click_1(object sender, EventArgs e)
        {
            int robot_no = CB_Robot.SelectedIndex;

            switch (robot_no)
            {
                case 0:
                    TPub.PLC.PLC_In.Robot1_Speed = Convert.ToInt32(CB_Robot_In_Speed.Text);
                    break;
            }
        }

        private void B_Robot_Loop_Run_Apply_Click_1(object sender, EventArgs e)
        {
            string fun = "Loop_Run";
            string title_str = "";
            int type = -1;
            int step = 0;
            int tray_no = 0;
            int robot_no = CB_Robot.SelectedIndex;
                switch (robot_no)
                {
                    case 0:
                        type = Get_Robot1_Type(CB_Robot_In_Loop_Run_Type.Text);
                        step = CB_Robot_In_Loop_Run_Step.SelectedIndex;
                        tray_no = CB_Robot_In_Loop_Run_Tray_No.SelectedIndex;
                        TPub.PLC.PLC_In.Robot1_Loop_Run_Type = type;
                        TPub.PLC.PLC_In.Robot1_Loop_Run_Step = step;
                        TPub.PLC.PLC_In.Robot1_Loop_Run_Tray_No = tray_no;
                        TPub.PLC.PLC_In.Robot1_Loop_Run_Req = true;
                        break;
                }
                Log_Add(fun, string.Format("Robot1_Loop_Run type={0:d}, step={1:d}", TPub.PLC.PLC_In.Robot1_Loop_Run_Type, TPub.PLC.PLC_In.Robot1_Loop_Run_Step));
                
        }

        private void B_Robot_Loop_Run_Reset_Click_1(object sender, EventArgs e)
        {
            int robot_no = CB_Robot.SelectedIndex;

            switch (robot_no)
            {
                case 0:
                    TPub.PLC.PLC_In.Robot1_Loop_Run_Req = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //// 要执行的多个命令
            //string commands = "cd C:\\test\\script && python backupzip.py";

            //// 创建一个进程启动信息对象
            //ProcessStartInfo psi = new ProcessStartInfo
            //{
            //    FileName = "cmd.exe",               // 指定要运行的程序
            //    Arguments = "/C " + commands,       // 要执行的多个命令
            //    RedirectStandardOutput = true,      // 启用标准输出重定向，以便我们可以获取命令输出
            //    UseShellExecute = false,            // 不使用系统外壳启动程序
            //    CreateNoWindow = true               // 不创建窗口显示程序
            //};

            //// 创建一个进程对象
            //Process process = new Process { StartInfo = psi };

            //// 启动进程
            //process.Start();

            //// 获取标准输出流，用于获取命令的输出
            //string output = process.StandardOutput.ReadToEnd();

            //// 等待进程结束
            //process.WaitForExit();

            //// 输出命令的输出
            //MessageBox.Show(output, "Command Output");
        }
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            TPub.PLC.PLC_Recipe.Plasma_Clean_Speed = double.Parse(T_Set_Speed.Text);
            TPub.PLC.PLC_Recipe.Plasma_Clean_Count =  int.Parse(T_Set_Count.Text);
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

      
    }
}
