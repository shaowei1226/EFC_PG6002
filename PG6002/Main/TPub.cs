using System;
using System.Collections;
using System.ComponentModel; 
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;  
using System.Threading.Tasks;

using EFC.Camera; 
using EFC.Camera.Sentech;
using EFC.Light;
using EFC.Light.EFC;
using EFC.INI;
using EFC.PLC.Melsec; 
using EFC.Tool; 
using EFC.Vision.Halcon;
using EFC.CAD;
using EFC.File_Manager;
using EFC.User_Manager;
using EFC.Measure;
using HalconDotNet;
using EFC.TCP_Handshake;
using EFC.Robot.Epson;


namespace Main
{
    public enum emCCD_Name { None, PCB1, PCB2 };
    public enum emModel { None, PCB_L, PCB_R, ACF_Check1, ACF_Check2 };
    public enum emCal_Model { None, PCB1 };

    class TPub
    {
        #region 參數
        static public TEnvironment Environment = new TEnvironment();
        static public TRecipe Recipe = new TRecipe();

        static public TLog Log = new TLog();
        static public TLog Log_Robot1 = new TLog();
        static public string Log_Source = "TPub";
        static public TPLC PLC = new TPLC();
        static public TPLC_CMD_Thread CMD_Thread     = new TPLC_CMD_Thread();
      //  static public TRobot_CMD_Thread Robot_Thread = new TRobot_CMD_Thread();

        static public TTeach Teach = new TTeach();
        static public TLight_EFC Light1 = new TLight_EFC();
        static public TLight_Channel_List Light_Channels = new TLight_Channel_List();

        static public int Cameras_Count = 2; 
        static public User_Manager User_Management = new User_Manager();
        static public TCamera_Base[] Cameras = new TCamera_Base[Cameras_Count];
        static public TCamera_View[] Camera_View = new TCamera_View[Cameras_Count];
        static public TFind_Data Find_Data = new TFind_Data();
        static public TMU_Select_Data_List MU_Data_List = new TMU_Select_Data_List();
        static public TEpson_Robot Robot1 = new TEpson_Robot(1);

   

        static public TRobot1_Program Robot1_Program = null;
        static public TImage_Logs Image_Logs = new TImage_Logs(24);
        static public int Check_No = 0;

        #endregion

        #region 初始化相關函數&結束相關函數
        static public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            Log.Add(Log_Source, fun, msg_str, type);
        }
        static public void Dispose()
        {
            Robot1_Program.Program_Stop();
            Robot1.Dispose();
            Robot1_Program.Dispose();
            Log_Robot1.Dispose();
            CMD_Thread.Dispose();
            //Robot_Thread.Dispose(); //2023_09_28
            PLC.Dispose();
            All_Grab_Stop();
            All_Grab_Close();
            Environment.Write();
            //TBasler_Giga.Dispose();
           // JJS_LIB.Sleep(300);
        }
        private async void StartLongRunningOperationButton_Click(object sender, EventArgs e)
        {
            // 禁用按钮以防止多次点击
          //  StartLongRunningOperationButton.Enabled = false;

            try
            {
                // 异步执行长时间运行的操作
                await Task.Run(() => LongRunningOperation());

                // 长时间运行的操作已完成

                // 在操作完成后更新 UI 或执行其他任务
            }
            finally
            {
                // 操作完成后启用按钮
              //  StartLongRunningOperationButton.Enabled = true;
            }
        }
        private void LongRunningOperation()
        {
            
        }

        public static void Init()
        {
            string fun = "Init";

            for (int i = 0; i < Cameras.Length; i++) Cameras[i] = new TCamera_Base();
            for (int i = 0; i < Camera_View.Length; i++)
            {
                Camera_View[i] = new TCamera_View();
                Camera_View[i].Camera = Cameras[i];
            }


 //Application.DoEvents();
            
            TEFC_Message.Show("初始化環境", "", 500);
           

            JJS_LIB.Sleep(100);
            TEFC_Message.Add_Message("初始化環境檔案");
            JJS_LIB.Sleep(100);
            Init_File();

            TEFC_Message.Add_Message("初始化Log");
            JJS_LIB.Sleep(100);
            Init_Log();

            TEFC_Message.Add_Message("初始化使用者管理");
            JJS_LIB.Sleep(100);
            Init_User_Management();

            TEFC_Message.Add_Message("初始化檔案管理");
            JJS_LIB.Sleep(100);
            Init_File_Management();

            TEFC_Message.Add_Message("初始化PLC");
            JJS_LIB.Sleep(100);
            Init_PLC();

            TEFC_Message.Add_Message("初始化Robot");
            JJS_LIB.Sleep(100);
            Init_Robot();

            TEFC_Message.Add_Message("初始化Recipe");
            JJS_LIB.Sleep(100);
            Init_Recipe();

            TEFC_Message.Add_Message("初始化Camera");
            JJS_LIB.Sleep(100);
            Init_Camera();

            TEFC_Message.Add_Message("初始化Light");
            JJS_LIB.Sleep(100);
            Init_Light();

            TEFC_Message.Add_Message("初始化Teach");
            JJS_LIB.Sleep(100);
            Init_Teach();

            TEFC_Message.Add_Message("初始化Image_Log");
            JJS_LIB.Sleep(100);
            Init_Image_Log();
            
            TEFC_Message.Add_Message("初始化完成");
            TEFC_Message.End();

            Apply_Recipe();
            PLC.Start();
            CMD_Thread.Start();
            //Robot_Thread.Start();//2023_09_28新增
            Log_Add(fun, "Pub Init Ok.");
        }


        public static void Init_File()
        {
            try
            {
                Environment.Default_Path = System.Windows.Forms.Application.StartupPath + "\\";
                Environment.Default_FileName = "Environment.xml";
                Environment.Read();

                User_Management.Log = Log;
                Update_Environment();
            }
            catch { }
        }
        public static void Init_Log()
        {
            Log.Default_Path = Environment.Base.Database_Path + "Log\\";
            Log.Enabled = true;

            Log_Robot1.Default_Path = Environment.Base.Database_Path + "Log_Robot1\\";
            Log_Robot1.Enabled = true;
        }
        public static void Init_PLC()
        {
            string fun = "Init_PLC";

            Log_Add(fun, "Init_PLC");

            TMelsec_QPLC_Eth_Connect Temp_PLC = (TMelsec_QPLC_Eth_Connect)PLC.PLC_Socket;
            Temp_PLC.Host = Environment.PLC.Host;
            Temp_PLC.Port = Environment.PLC.Port;

            PLC.Log = Log;
            PLC.PLC_In.Start_Code = Environment.PLC.In_Start_Code;
            PLC.PLC_In.Count = Environment.PLC.In_Count;

            PLC.PLC_Out.Start_Code = Environment.PLC.Out_Start_Code;
            PLC.PLC_Out.Count = Environment.PLC.Out_Count;

            PLC.PLC_Recipe.Start_Code = Environment.PLC.Recipe_Start_Code;
            PLC.PLC_Recipe.Count = Environment.PLC.Recipe_Count;
           
            PLC.PLC_Socket.Connect = true;
        }

        public static void Init_Recipe()
        {
            string fun = "Init_Recipe";

            Log_Add(fun, "Init_Recipe");
            Recipe.Default_FileName = "Produce.xml";
            Recipe.Default_Path = Environment.Base.Recipe_Path;
            Recipe.Recipe_Name = Environment.Base.Recipe_Name;
            Recipe.Read();

            //Recipe.COF1.L_Edge_X.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;
            //Recipe.COF1.L_Edge_Y.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;
            //Recipe.COF1.R_Edge_X.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;
            //Recipe.COF1.R_Edge_Y.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;

            //Recipe.COF2.L_Edge_X.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;
            //Recipe.COF2.L_Edge_Y.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;
            //Recipe.COF2.R_Edge_X.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;
            //Recipe.COF2.R_Edge_Y.Pixel_Size = TPub.Environment.CCDs[0].Pixel_Size_X;
        }
        public static void Init_Teach()
        {
            string fun = "Init_Teach";

            Log_Add(fun, "Init_Teach");
            Teach.Default_Path = Environment.Base.Recipe_Path + "Teach\\";
            Teach.Teach_Name = Environment.Base.Recipe_Name;
            Teach.Default_FileName = "Teach.xml";
            Teach.Read();
        }
        static public void Init_Robot()
        {
            string fun = "Init_Robot";
            string filename = "";
            string robot_name = "";

            Robot1_Program = new TRobot1_Program(Robot1);
          

            Log_Add(fun, "Init_Robot1");
            if (Environment.Robot1.Enabled)
            {
                filename = Environment.Robot1.Project_Name;
                robot_name = Environment.Robot1.Name;
                Init_Robot(Robot1, robot_name, filename, Robot1_Program, Log_Robot1);
            }
        }
        static public void Init_Robot(TEpson_Robot robot, string robot_name, string prj_filename, TRobot_Program_Base program, TLog log)
        {
            string fun = "Init_Robot";

            robot.Program = program;
            robot.Log = log;
            robot.Program.Log = log;
            robot.Init();
            robot.Connect_Name(robot_name);
            if (System.IO.File.Exists(prj_filename))
            {
                robot.Connect_Project_Name(prj_filename);
            }
            else
            {
                Log_Add(fun, string.Format("專案檔找不到. Filename={0:s}", prj_filename), emLog_Type.Error);
            }
            robot.Robot_Local = 0;
        }
        static public void Init_Camera()
        {
            string fun = "Init_Camera";
            string disp_name = "";
            string ccd_name = "";

            Log_Add(fun, "Init_Camera");
            try
            {
                #region Sentech_Giga
                TSentech_Giga.Find_All_Camera();
                for (int i = 0; i < Cameras.Length; i++)
                {
                    disp_name = string.Format("({0:d}){1:s}", i + 1, Environment.CCDs[i].Name);
                    ccd_name = Environment.CCDs[i].CCD_Name;
                    Cameras[i].Set_Camera_Size(Environment.CCDs[i].Pixel_X, Environment.CCDs[i].Pixel_Y);
                    Set_Camera_Data(ref Cameras[i], disp_name, TSentech_Giga.Get_Camera_By_UserDefinedName(ccd_name));
                
                }
                #endregion

                #region Other
                Cameras[0].Rotate_Image = true;
                Cameras[0].Mirror_Col = true;
                Cameras[1].Rotate_Image = true;
                Cameras[1].Mirror_Col = true;
                for (int i = 0; i < Cameras.Length; i++)
                {
                    Cameras[i].Name = string.Format("({0:d}){1:s}", i + 1, Environment.CCDs[i].Name);
                    Cameras[i].Log = Log;
                }
                #endregion
            }
            catch(Exception e)
            {
                Log_Add(fun, e.Message, emLog_Type.Error);
            }
            
            for (int i = 0; i < Cameras.Length; i++)
            {
                Cameras[i].Log = Log;
            }
            for (int i = 0; i < Camera_View.Length; i++)
            {
                Camera_View[i].Camera = Cameras[i];
            }

        }
        static public void Set_Camera_Data(ref TCamera_Base dist, string name, TCamera_Base sor)
        {
            if (sor != null) dist = sor;
            dist.Name = name;
        }

        public static void Init_Light()
        {
            string fun = "Init_Light";

            Log_Add(fun, "Init_Light");
            //設定燈源連線ComPort
            Light1.COM.Set_Com_Port("COM" + Environment.Light.EFC_Light1_COM_Port.ToString());
            Light1.Enabled = true;
            Light1.Channels[0].Set(Light1, "PCB_R外環光", 0);
            Light1.Channels[1].Set(Light1, "PCB_L外環光", 1);
            Light1.Channels[2].Set(Light1, "PCB_R內同軸", 2);
            Light1.Channels[3].Set(Light1, "PCB_L內同軸", 3);
            Light1.Channels[4].Set(Light1, "預留", 4);
            Light1.Channels[5].Set(Light1, "預留", 5);
            Light1.Channels[6].Set(Light1, "預留", 6);
            Light1.Channels[7].Set(Light1, "預留", 7);
            Light1.Channels[8].Set(Light1, "預留", 8);
            Light1.Channels[9].Set(Light1, "預留", 9);
            Light1.Channels[10].Set(Light1, "預留", 10);
            Light1.Channels[11].Set(Light1, "預留", 11);
            Light1.Channels[12].Set(Light1, "預留", 12);
            Light1.Channels[13].Set(Light1, "預留", 13);
            Light1.Channels[14].Set(Light1, "預留", 14);
            Light1.Channels[15].Set(Light1, "預留", 15);

            Light_Channels.Count = 0;
            for (int i = 0; i < Light1.Channel_Count; i++) Light_Channels.Add(Light1.Channels[i]);
        }
        public static void Init_Image_Log()
        {
            string fun = "Init_Image_Log";
            int page = 0;
            int page_count = 24;

            Log_Add(fun, "Init_Image_Log");
            page = 0;
            Image_Logs[page * page_count + 00].Set_Data(Get_Model_Name(emModel.PCB_L), new TFind_Mothed_1_Result());
            Image_Logs[page * page_count + 01].Set_Data(Get_Model_Name(emModel.PCB_R), new TFind_Mothed_1_Result());
            Image_Logs[page * page_count + 02].Set_Data(Get_Model_Name(emModel.ACF_Check1, 0), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 03].Set_Data(Get_Model_Name(emModel.ACF_Check2, 0), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 04].Set_Data(Get_Model_Name(emModel.ACF_Check1, 1), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 05].Set_Data(Get_Model_Name(emModel.ACF_Check2, 1), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 06].Set_Data(Get_Model_Name(emModel.ACF_Check1, 2), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 07].Set_Data(Get_Model_Name(emModel.ACF_Check2, 2), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 08].Set_Data(Get_Model_Name(emModel.ACF_Check1, 3), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 09].Set_Data(Get_Model_Name(emModel.ACF_Check2, 3), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 10].Set_Data(Get_Model_Name(emModel.ACF_Check1, 4), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 11].Set_Data(Get_Model_Name(emModel.ACF_Check2, 4), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 12].Set_Data(Get_Model_Name(emModel.ACF_Check1, 5), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 13].Set_Data(Get_Model_Name(emModel.ACF_Check2, 5), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 14].Set_Data(Get_Model_Name(emModel.ACF_Check1, 6), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 15].Set_Data(Get_Model_Name(emModel.ACF_Check2, 6), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 16].Set_Data(Get_Model_Name(emModel.ACF_Check1, 7), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 17].Set_Data(Get_Model_Name(emModel.ACF_Check2, 7), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 18].Set_Data(Get_Model_Name(emModel.ACF_Check1, 8), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 19].Set_Data(Get_Model_Name(emModel.ACF_Check2, 8), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 20].Set_Data(Get_Model_Name(emModel.ACF_Check1, 9), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 21].Set_Data(Get_Model_Name(emModel.ACF_Check2, 9), new TFind_ACF_Check_Result());
            Image_Logs[page * page_count + 22].Set_Data("預留", new TFind_Mothed_1_Result());
            Image_Logs[page * page_count + 23].Set_Data("預留", new TFind_Mothed_1_Result());
           // page = 1;



            for (int i = 0; i < Image_Logs.Count; i++ )
            {
                Image_Logs[i].No = i;
                TFind_Mothed_1_Result result_mothed1 = Image_Logs[i].Result_Mothed_1;
                if (result_mothed1 != null)
                {
                    result_mothed1.Disp_Param.Msg_X = 20;
                    result_mothed1.Disp_Param.Msg_Y = 50;
                    result_mothed1.Disp_Param.Msg_Font_Size = 16;
                }

                TFind_ACF_Check_Result result_check = Image_Logs[i].Result_ACF_Check;
                if (result_check != null)
                {
                    result_check.Disp_Param.Msg_X = 20;
                    result_check.Disp_Param.Msg_Y = 50;
                    result_check.Disp_Param.Msg_Font_Size = 16;
                }
            }

        }
        static public string Get_Model_Name(emModel model, int no = 0)
        {
            string result = "";
            switch (model)
            {
                case emModel.PCB_L: result = emModel.PCB_L.ToString(); break;
                case emModel.PCB_R: result = emModel.PCB_R.ToString(); break;
                case emModel.ACF_Check1: result = emModel.ACF_Check1.ToString() + "_" + (no + 1).ToString(); break;
                case emModel.ACF_Check2: result = emModel.ACF_Check2.ToString() + "_" + (no + 1).ToString(); break;
            }
            return result;
        }
        static public void Init_File_Management()
        {
            string fun = "Init_File_Management";

            Log_Add(fun, "Init_File_Management");

            File_Manager.Log = TPub.Log;
            File_Manager.Add_Path(Environment.Base.Database_Path + "Log\\");
            File_Manager.Add_Files(Environment.Base.Database_Path + "Log\\", "log");
            File_Manager.Auto_Delete_File = Environment.Log.Auto_Delete_File;
            File_Manager.Days = Environment.Log.Days_Count;
            File_Manager.Delete();
        }
        static public void Init_User_Management()
        {
            string fun = "Init_User_Management";
            string filename = "";

            Log_Add(fun, "Init_User_Manabement");
            filename = Environment.Base.Database_Path + "UserTable.xml";

            if (!System.IO.File.Exists(filename))
            {
                User_Management.Create_Table(filename);
            }
            else
            {
                User_Management.User_List.Read_File(filename);
            }

            User_Management.Log = Log;
            //Reader[0] = new TSoyal_RFID_Reader();
            //Reader[0].Com_Port = Environment.Other.RFID_COM_Port;
            //Reader[0].Log = Log;
            //Reader[0].Enabled = true;
            //User_Management.Add_Reader(Reader[0]);
            User_Management.Logout_Time = Environment.Base.Auto_Log_Out_Time;
            User_Management.Auto_Logout_Out = Environment.Base.Auto_Log_Out;
        }
        static public void Update_Environment()
        {
            User_Management.Auto_Logout_Out = Environment.Base.Auto_Log_Out;
            User_Management.Logout_Time = Environment.Base.Auto_Log_Out_Time;
            for (int i = 0; i < Cameras.Length; i++)
            {
                if (Environment.CCDs[i] != null)
                    Cameras[i].Name = string.Format("({0:d}) {1:s}", i + 1, Environment.CCDs[i].Name);
            }

        }
        #endregion

        #region Recipe
        static public void Apply_Recipe()
        {
            Apply_Recipe_To_Pub();
            Apply_Recipe_To_View();
            Apply_Recipe_To_PLC();
        }
        static public void Apply_Recipe_To_Pub()
        {
            TImage_Log image_log = null;
            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                image_log = TPub.Image_Logs.Get_Image_Log(TPub.Get_Model_Name(emModel.ACF_Check1, i));
                image_log.Result_ACF_Check.Param_Ptr = Recipe.ACF.Pos_List[i].Check[0].Param;

                image_log = TPub.Image_Logs.Get_Image_Log(TPub.Get_Model_Name(emModel.ACF_Check2, i));
                image_log.Result_ACF_Check.Param_Ptr = Recipe.ACF.Pos_List[i].Check[1].Param;
            }
            //Image_Logs["COF_In_Arm_A_L"].Result = Find_Data.COF_In[0].Find_Mothed1;
            //Image_Logs["COF_In_Arm_A_R"].Result = Find_Data.COF_In[1].Find_Mothed1;
            //Image_Logs["COF_In_Arm_B_L"].Result = Find_Data.COF_In[2].Find_Mothed1;
            //Image_Logs["COF_In_Arm_B_R"].Result = Find_Data.COF_In[3].Find_Mothed1;
        }
        static public void Apply_Recipe_To_View()
        {
            TCamera_View view = null;
            int no = 0;

            #region PCB_L
            view = Camera_View[0];
            view.Find_Data_Count = 1;
            view.Find_Data[0].Find_Mothed1.JJS_Model.Set(Recipe.PCB.Mark.L.Model);
            view.Find_Data[0] = Find_Data.PCB[0];
            for (int i = 0; i < view.Find_Data_Count; i++)
            {
                view.Find_Data[i].Find_Mothed1.Disp_Param.Msg_Font_Size = 20;
                view.Find_Data[i].Find_Mothed1.Disp_Param.Msg_X = 10;
                view.Find_Data[i].Find_Mothed1.Disp_Param.Msg_Y = 60 + 20 * i;
            }
            #endregion

            #region PCB_R
            view = Camera_View[1];
            view.Find_Data_Count = 1;
            view.Find_Data[0].Find_Mothed1.JJS_Model.Set(Recipe.PCB.Mark.R.Model);
            view.Find_Data[0] = Find_Data.PCB[1];
            for (int i = 0; i < view.Find_Data_Count; i++)
            {
                view.Find_Data[i].Find_Mothed1.Disp_Param.Msg_Font_Size = 20;
                view.Find_Data[i].Find_Mothed1.Disp_Param.Msg_X = 10;
                view.Find_Data[i].Find_Mothed1.Disp_Param.Msg_Y = 60 + 20 * i;
            }
            #endregion
        }
        static public void Apply_Recipe_To_PLC()
        {
            string section = "";
            int axis_no = 0;
           

            PLC.PLC_Recipe.Recipe_Code = Recipe.Recipe_Code;
            PLC.PLC_Recipe.Recipe_Name = Recipe.Recipe_Name;

            //PLC.PLC_Recipe.Tray_Start_X = Recipe.PCB_Tray.Start_X;
            //PLC.PLC_Recipe.Tray_Start_Y = Recipe.PCB_Tray.Start_Y;
            PLC.PLC_Recipe.Tray_Pitch_X = Recipe.PCB_Tray.Pitch_X;
            PLC.PLC_Recipe.Tray_Pitch_Y = Recipe.PCB_Tray.Pitch_Y;
            PLC.PLC_Recipe.Tray_Num_X = Recipe.PCB_Tray.Num_X;
            PLC.PLC_Recipe.Tray_Num_Y = Recipe.PCB_Tray.Num_Y;
            PLC.PLC_Recipe.Robot_Home_Start_no = Recipe.Robot.Robot_Home.List_Home.Start_No;
            PLC.PLC_Recipe.Robot_Plasma_Load_Start_no = Recipe.Robot.Robot_Plasma.List_Load.Start_No;
            PLC.PLC_Recipe.Robot_Plasma_Unload_Start_no = Recipe.Robot.Robot_Plasma.List_Unload.Start_No;       
            PLC.PLC_Recipe.Robot_ACF_Load_Start_no = Recipe.Robot.Robot_ACF.List_Load.Start_No;
            PLC.PLC_Recipe.Robot_ACF_Unload_Start_no = Recipe.Robot.Robot_ACF.List_Unload.Start_No;
            PLC.PLC_Recipe.Robot_PCB_Load_Start_no = Recipe.Robot.Robot_PCB.List_Load.Start_No;
            PLC.PLC_Recipe.Robot_PCB_Unload_Start_no = Recipe.Robot.Robot_PCB.List_Unload.Start_No;
            PLC.PLC_Recipe.Robot_NG_Start_no = Recipe.Robot.Robot_NG.List_NG.Start_No;
            PLC.PLC_Recipe.Robot_Tray_Start_no = Recipe.Robot.Robot_Tray.List_Load.Start_No;
            PLC.PLC_Recipe.Robot_Teach_Start_no = Recipe.Robot.Robot_Teach.List_Teach.Start_No;
            PLC.PLC_Recipe.Plasma_Clean_Speed = Recipe.Plasma.Clean_Speed;
            PLC.PLC_Recipe.Plasma_Clean_Count = Recipe.Plasma.Clean_Count;

            PLC.PLC_Recipe.Robot_X = Recipe.MS_Param.Get_Value_Double("Robot_取Tray", "X");
            PLC.PLC_Recipe.Robot_Y = Recipe.MS_Param.Get_Value_Double("Robot_取Tray", "Y");
            PLC.PLC_Recipe.Robot_Q = Recipe.MS_Param.Get_Value_Double("Robot_取Tray", "Q");


            PLC.PLC_Recipe.ACF_Time = Recipe.ACF.Bond.Time;
            PLC.PLC_Recipe.ACF_Pressure[0] = Recipe.ACF.Bond.Pressure;
            PLC.PLC_Recipe.ACF_Pressure[1] = Recipe.ACF.Bond.Pressure2;
            PLC.PLC_Recipe.ACF_Pressure[2] = Recipe.ACF.Bond.Pressure3;
            PLC.PLC_Recipe.ACF_Up_Temp[0] = Recipe.ACF.Bond.Up_Temp[0];
            PLC.PLC_Recipe.ACF_Dn_Temp[0] = Recipe.ACF.Bond.Dn_Temp[0];

            PLC.PLC_Recipe.ACF_Pos_Count = Recipe.ACF.Pos_List.Count;
            PLC.PLC_Recipe.ACF_Length = Recipe.ACF.Pos_List.ACF_Length;
            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                PLC.PLC_Recipe.ACF_Pos_List[i].Bond_X = Recipe.MS_Param.Get_Value_Double("基準位置/貼附", "X") - Recipe.ACF.Pos_List[i].Y;
                PLC.PLC_Recipe.ACF_Pos_List[i].Bond_Y = Recipe.MS_Param.Get_Value_Double("基準位置/貼附", "Y") + Recipe.ACF.Pos_List[i].X + Recipe.ACF.Pos_List.ACF_Length / 2;
                PLC.PLC_Recipe.ACF_Pos_List[i].Bond_Q = Recipe.MS_Param.Get_Value_Double("基準位置/貼附", "Q");
                PLC.PLC_Recipe.ACF_Pos_List[i].Check_X = Recipe.MS_Param.Get_Value_Double("基準位置/取像", "X") - Recipe.ACF.Pos_List[i].Y + Recipe.ACF.Pos_List[i].C_Ofs_X;
                PLC.PLC_Recipe.ACF_Pos_List[i].Check_Y = Recipe.MS_Param.Get_Value_Double("基準位置/取像", "Y") + Recipe.ACF.Pos_List[i].X + Recipe.ACF.Pos_List[i].C_Ofs_Y - Recipe.ACF.Pos_List.Check_Pitch / 2;//檢查使用取像基準
                PLC.PLC_Recipe.ACF_Pos_List[i].Check_Q = Recipe.MS_Param.Get_Value_Double("基準位置/取像", "Q") + Recipe.ACF.Pos_List[i].C_Ofs_Q;
            }

            #region MS_Param
            #region ACF載台
            #region X
            axis_no = 0;
            section = "ACF載台/X";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "入料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "取像位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "壓合位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = Recipe.MS_Param.Get_Value_Double(section, "檢查位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region Z
            axis_no = 1;
            section = "ACF載台/Z";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "入料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "取像位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "壓合位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = Recipe.MS_Param.Get_Value_Double(section, "檢查位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region Q
            axis_no = 2;
            section = "ACF載台/Q";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "入料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "取像位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "壓合位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = Recipe.MS_Param.Get_Value_Double(section, "檢查位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
            #endregion

            #region ACF壓合
            #region Y
            axis_no = 3;
            section = "ACF壓合/Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取像位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "壓合位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "檢查位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "維修位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region CCD_Y
            axis_no = 4;
            section = "ACF壓合/CCD_Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "取像位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "檢查位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion      
            #endregion

            #region ACF拉帶/Y
            axis_no = 5;
            section = "ACF拉帶/Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "貼附位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "切刀位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region PCB_LD
            #region 供料Z
            axis_no = 6;
            section = "PCB_LD/供料Z";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "供料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "供料完成位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "CV位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "對位位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 收料Z
            axis_no = 7;
            section = "PCB_LD/收料Z";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "收料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "收料位置完成位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "CV位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion

            #region 搬送X
            axis_no = 8;
            section = "PCB_LD/搬送X";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "取料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
            #endregion

            #region Plasma
            axis_no = 9;
            section = "Plasma/Y";
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[0] = Recipe.MS_Param.Get_Value_Double(section, "等待");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[1] = Recipe.MS_Param.Get_Value_Double(section, "入料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[2] = Recipe.MS_Param.Get_Value_Double(section, "掃碼位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[3] = Recipe.MS_Param.Get_Value_Double(section, "起始位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[4] = Recipe.MS_Param.Get_Value_Double(section, "終點位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[5] = Recipe.MS_Param.Get_Value_Double(section, "出料位置");
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[6] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[7] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[8] = 0.0;
            PLC.PLC_Recipe.MS_Param.Axis[axis_no].Pos[9] = 0.0;
            #endregion
            #endregion

            PLC.PLC_Recipe.Update();
        }
        static public bool Write_Recipe_To_PLC()
        {
            bool result = true;
            string fun = "Write_Recipe_To_PLC";
           
            Log_Add(fun, "Update Recipe To PLC.");
            PLC.PLC_In.Write_Recipe_Req = true;
            while (!PLC.PLC_Out.Write_Recipe.Finish) 
            { 
                Application.DoEvents();
                JJS_LIB.Sleep(1);
            }

            if (!PLC.PLC_Out.Write_Recipe.OK)
            {
                Log_Add(fun, "Recipe 更新至PLC失敗.", emLog_Type.Warning);
                MessageBox.Show("Recipe 更新至PLC失敗", "警告", MessageBoxButtons.OK);
            }
            PLC.PLC_In.Write_Recipe_Req = false;
            return result;
        }
        #endregion

        #region 相機
        static public string[] Get_CCD_Name_All()
        {
            string[] result = new string[Cameras.Length];

            for (int i = 0; i < Cameras.Length; i++)
                result[i] = Get_CCD_Name(i);
            return result;
        }
        static private string Get_CCD_Name(int no)
        {
            string result = "";
            result = Cameras[no].Name;
            return result;
        }

        static public int Get_Camera_No(emModel model)
        {
            int result = -1;
            emCCD_Name ccd_name = Get_emCCD_Name(model);
            result = Get_Camera_No(ccd_name);
            return result;
        }
        static public int Get_Camera_No(emCCD_Name ccd_name)
        {
            int result = 0;
            switch (ccd_name)
            {
                case emCCD_Name.PCB1: result = 0; break;
                case emCCD_Name.PCB2: result = 1; break;
            }
            return result;
        }
        static public int Get_Camera_No(TCamera_Base camera)
        {
            int result = 0;
            for (int i = 0; i < Cameras.Length; i++)
            {
                if (camera == Cameras[i])
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        static public emCCD_Name Get_emCCD_Name(int no)
        {
            emCCD_Name result = emCCD_Name.None;

            switch (no)
            {
                case 0: result = emCCD_Name.PCB1; break;
                case 1: result = emCCD_Name.PCB2; break;
            }
            return result;
        }
        static public emCCD_Name Get_emCCD_Name(emModel model)
        {
            emCCD_Name result = emCCD_Name.None;
            switch (model)
            {
                case emModel.PCB_L:
                    result = emCCD_Name.PCB1;
                    break;

                case emModel.PCB_R:
                    result = emCCD_Name.PCB2;
                    break;

                case emModel.ACF_Check1:
                    result = emCCD_Name.PCB1;
                    break;

                case emModel.ACF_Check2:
                    result = emCCD_Name.PCB2;
                    break;
            }
            return result;

        }

        static public TCamera_Base Get_Camera(emModel model)
        {
            TCamera_Base result = Get_Camera(Get_emCCD_Name(model));
            return result;
        }
        static public TCamera_Base Get_Camera(emCCD_Name em_ccd_name)
        {
            TCamera_Base result = null;
            int no = Get_Camera_No(em_ccd_name);

            if (no >= 0) result = Cameras[no];
            return result;
        }
        static public TCamera_View Get_Camera_View(emModel model)
        {
            TCamera_View result = Camera_View[Get_Camera_No(model)];
            return result;
        }
        static public emModel Get_emModel(string model_str)
        {
            emModel result = emModel.None;

            switch (model_str)
            {
                case "PCB_L": result = emModel.PCB_L; break;
                case "PCB_R": result = emModel.PCB_R; break;
            }
            return result;
        }
        static public void All_Grab_Life()
        {
            for (int i = 0; i < Cameras.Length; i++)
                if (Cameras[i] != null) Cameras[i].Grab_Life();
        }
        static public void All_Grab_Stop()
        {
            for (int i = 0; i < Cameras.Length; i++)
                if (Cameras[i] != null) Cameras[i].Grab_Stop();
        }
        static public void All_Grab_Close()
        {
            TCamera_Sentech_Giga camera = null;

            for (int i = 0; i < Cameras.Length; i++)
            {
                if (Cameras[i] != null)
                {
                    if (Cameras[i] is TCamera_Sentech_Giga)
                    {
                        camera = (TCamera_Sentech_Giga)Cameras[i];
                        camera.Dispose();
                    }
                };
            }
        }
        #endregion

        #region Model
        static public void Get_PLC_Pos(emModel model, ref TJJS_Value_List values)
        {
            values.Clear();
            switch (model)
            {
                case emModel.PCB_L:
                case emModel.PCB_R:
                    values.Add("Table_X", PLC.PLC_In.Pos_PCB_Table_X);
                    values.Add("Table_Y", PLC.PLC_In.Pos_PCB_Table_Y);
                    values.Add("Table_Z", PLC.PLC_In.Pos_PCB_Table_Z);
                    values.Add("Table_Q", PLC.PLC_In.Pos_PCB_Table_Q);
                    values.Add("ACF_Y", PLC.PLC_In.Pos_PCB_CCD_Y);
                    break;
            }
        }
        static public int Get_Last_No(emModel model)
        {
            int result = 0;

            switch (model)
            {
                case emModel.PCB_L: result = 0; break;
                case emModel.PCB_R: result = 0; break;
            }
            return result;
        }
        static public TBase_Param Get_Model_Param(emModel model)
        {
            int pre_type = 0;
            TBase_Param result = null;

            switch (model)
            {
                case emModel.PCB_L:
                    result = Recipe.PCB.Mark.L.Model;
                    break;

                case emModel.PCB_R:
                    result = Recipe.PCB.Mark.R.Model;
                    break;
            }
            return result;
        }
        static public TFind_Data_Result Get_Find_Data(emModel model)
        {
            TFind_Data_Result result = null;
            switch (model)
            {
                case emModel.PCB_L:
                    result = Find_Data.PCB[0];
                    break;

                case emModel.PCB_R:
                    result = Find_Data.PCB[1];
                    break;
            }
            return result;
        }
        static public void Get_Model_Info(emModel model, ref TCamera_View camera_view, ref int last_no, ref TBase_Param param, ref TFind_Data_Result f_result, ref TImage_Log f_result_log)
        {
            camera_view = Get_Camera_View(model);
            last_no = Get_Last_No(model);
            param = Get_Model_Param(model);
            f_result = Get_Find_Data(model);
            f_result_log = Image_Logs.Get_Image_Log(model);
        }
        static public bool Find(emModel model)
        {
            bool result = false;
            string fun = "Find";
            HImage tmp_Image = new HImage();
            string title_str = "";
            TCamera_View camera_view = null;
            int last_no = 0;
            TBase_Param param = null;
            TFind_Data_Result f_result = null;
            TImage_Log f_result_log = null;
            TFind_Mothed_1_Param model_param = null;
            TFind_Mothed_1_Result model_result = null;
            string log_name = "";

            title_str = string.Format("[Find] Model={0:s}", model.ToString());
            Log_Add(fun, title_str);
            Get_Model_Info(model, ref camera_view, ref last_no, ref param, ref f_result, ref f_result_log);
            camera_view.Camera.Grab_Image(ref tmp_Image);

            if (JJS_Vision.Is_Not_Empty(tmp_Image) && param != null && f_result != null && f_result_log != null)
            {
                f_result.Reset();
                Get_PLC_Pos(model, ref f_result.Pos);

                model_param = (TFind_Mothed_1_Param)param;
                if (f_result != null) model_result = f_result.Result_Mothed_1;

                result = model_param.Find(tmp_Image, ref model_result);
                f_result_log.Set_Data(tmp_Image, model_result);

                camera_view.Last_No = last_no;
                Log_Find_Data(fun, title_str, f_result);
                tmp_Image = DumpWindowImage(tmp_Image, f_result);
                Save_Image(tmp_Image, f_result.Result.Find_OK, log_name);
            }
            if (!result) Log_Add(fun, title_str + "失敗", emLog_Type.Warning);
            return result;
        }
        static public bool Check_Limit(string fun, string title, double value, TLimit limit)
        {
            bool result = false;

            if (limit.SW)
            {
                if (value >= limit.Min && value <= limit.Max) result = true;
                Log_Limit(fun, title, limit, value, result);
            }
            else result = true;
            return result;
        }
        static public bool Cal_PCB()
        {
            bool result = false;
            string fun = "Cal_ACF1";
            string title_str = "";
            TJJS_Line line_base = new TJJS_Line();
            TJJS_Line line_panel = new TJJS_Line();
            TJJS_Line line_panel_new = new TJJS_Line();
            TJJS_Point center = Teach.Cal_Data.PCB.Center;
            double dx, dy, dq;
            TOfs ofs = new TOfs();
            TLimit limit = new TLimit();
            emModel model_l = emModel.PCB_L;
            emModel model_r = emModel.PCB_R;
            TCamera_Base camera_l = null;
            TCamera_Base camera_r = null;
            TFind_Data_Result f_result_l = null;
            TFind_Data_Result f_result_r = null;
            TImage_Log f_result_log_l = null;
            TImage_Log f_result_log_r = null;

            title_str = string.Format("[Cal_ACF1]");
            Log_Add(fun, title_str);
            f_result_l = Get_Find_Data(model_l);
            f_result_r = Get_Find_Data(model_r);
            f_result_log_l = Image_Logs.Get_Image_Log(model_l);
            f_result_log_r = Image_Logs.Get_Image_Log(model_r);
            if (f_result_l.Result.Find_OK && f_result_r.Result.Find_OK)
            {
                ofs = Recipe.PCB.Ofs;
                limit = Recipe.PCB.Mark.Limit;
                Log_Ofs(fun, title_str, ofs);

                camera_l = Get_Camera(model_l);
                camera_r = Get_Camera(model_l);
                line_base.Start = Get_Abs_Pos(model_l, camera_l.Image_Width / 2, camera_l.Image_Height / 2, f_result_l.Pos);
                line_base.End = Get_Abs_Pos(model_r, camera_l.Image_Width / 2, camera_l.Image_Height / 2, f_result_r.Pos);
                Log_Line(fun, title_str + " line_base", line_base);

                line_panel.Start = Get_Abs_Pos(model_l, f_result_l);
                line_panel.End = Get_Abs_Pos(model_r, f_result_r);
                Log_Line(fun, title_str + " line_panel", line_panel);

                dq = line_panel.V.Angle.d - line_base.V.Angle.d + ofs.Q;
                line_panel_new = line_panel.Rotate(center, -dq);
                Log_Line(fun, title_str + " line_panel_new", line_panel_new);

                dx = -(line_panel_new.Mid.X - line_base.Mid.X) + ofs.X;
                dy = -(line_panel_new.Mid.Y - line_base.Mid.Y) + ofs.Y;

                PLC.PLC_Out.PCB_DX = dy;
                PLC.PLC_Out.PCB_DY = dx;
                PLC.PLC_Out.PCB_DQ = dq;

                Cal_PCB_Point(fun, title_str, line_base.End, line_panel.End, center, line_panel.V.Angle.d, dq);

                result = true;
                if (!Check_Limit(fun, title_str, line_panel.Length(), limit)) result = false;
                Log_Add(fun, title_str + string.Format("DX={0:f3}, DY={1:f3}, DQ={2:f3} Result={3:s}", PLC.PLC_Out.PCB_DX, PLC.PLC_Out.PCB_DY, PLC.PLC_Out.PCB_DQ, result ? "OK" : "NG"));
            }
            if (!result) Log_Add(fun, title_str + "失敗", emLog_Type.Warning);
            return result;
        }
        static void Cal_PCB_Point(string fun, string title_str, TJJS_Point b_t_point, TJJS_Point s_t_point, TJJS_Point center, double sample_q, double dq)
        {
            TJJS_Point[] recipe_point_list = null;
            TJJS_Point[] base_point_list = null;
            TJJS_Point[] sample_point_list = null;
            TJJS_Point[] new_point_list = null;
            TJJS_Point f_point = new TJJS_Point();
            double[] bond_dx = new double[0];
            double[] bond_dy = new double[0];
            double[] bond_dq = new double[0]; ;

            f_point.Set(-Recipe.PCB.Mark.R_Mark_X, Recipe.PCB.Mark.R_Mark_Y);
            recipe_point_list = Get_Recipe_Point();
            base_point_list = Point_Ofs(recipe_point_list, f_point, b_t_point);
            sample_point_list = Point_Ofs(recipe_point_list, f_point, s_t_point);
            sample_point_list = Point_Rotate(sample_point_list, s_t_point, sample_q);

            Get_Bond_DQ(sample_point_list, dq, ref bond_dq);
            new_point_list = Point_Rotate(sample_point_list, center, bond_dq);
            Get_Bond_DXY(new_point_list, base_point_list, ref bond_dx, ref bond_dy);
            
            Log_Point_List(fun, title_str + "recipe_point_list ", recipe_point_list);
            Log_Point_List(fun, title_str + "base_point_list ", base_point_list);
            Log_Point_List(fun, title_str + "sample_point_list ", sample_point_list);
            Log_Point_List(fun, title_str + "new_point_list ", new_point_list);
            Log_DXYQ(fun, title_str + "DXYQ  ", bond_dx, bond_dy, bond_dq);

            for(int i=0; i<bond_dx.Length; i++)
            {
                PLC.PLC_Out.Bond_DXYQ[i].DX = bond_dy[i];
                PLC.PLC_Out.Bond_DXYQ[i].DY = bond_dx[i];
                PLC.PLC_Out.Bond_DXYQ[i].DQ = bond_dq[i];
            }
        }
        static TJJS_Point[] Get_Recipe_Point()
        {
            TJJS_Point[] result = new TJJS_Point[Recipe.ACF.Pos_List.Count];


            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                result[i] = new TJJS_Point();
                result[i].X = -Recipe.ACF.Pos_List[i].X;
                result[i].Y = Recipe.ACF.Pos_List[i].Y;
            }
            return result;
        }
        static void Get_Bond_DQ(TJJS_Point[] in_point_list, double dq, ref double[] bond_dq)
        {
            Array.Resize(ref bond_dq, in_point_list.Length);
            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                bond_dq[i] = dq + Recipe.ACF.Pos_List[i].B_Ofs_Q;
            }
        }
        static void Get_Bond_DXY(TJJS_Point[] new_point_list, TJJS_Point[] base_point_list, ref double[] bond_dx, ref double[] bond_dy)
        {
            Array.Resize(ref bond_dx, new_point_list.Length);
            Array.Resize(ref bond_dy, new_point_list.Length);

            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                bond_dx[i] = -(new_point_list[i].X - base_point_list[i].X) + Recipe.ACF.Pos_List[i].B_Ofs_Y;
                bond_dy[i] = -(new_point_list[i].Y - base_point_list[i].Y) + Recipe.ACF.Pos_List[i].B_Ofs_X;
            }
        }
        static TJJS_Point[] Point_Ofs(TJJS_Point[] in_point_list, TJJS_Point f_point, TJJS_Point t_point)
        {
            TJJS_Point[] result = new TJJS_Point[in_point_list.Length];
            TJJS_Point ofs = new TJJS_Point();

            ofs = t_point - f_point;
            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                result[i] = new TJJS_Point();
                result[i].Set(in_point_list[i] + ofs);
            }
            return result;
        }
        static TJJS_Point[] Point_Rotate(TJJS_Point[] in_point_list, TJJS_Point center, double dq)
        {
            TJJS_Point[] result = new TJJS_Point[in_point_list.Length];
            TJJS_Point ofs = new TJJS_Point();

            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                result[i] = new TJJS_Point();
                result[i].Set(in_point_list[i].Rotate(center, dq));
            }
            return result;
        }
        static TJJS_Point[] Point_Rotate(TJJS_Point[] in_point_list, TJJS_Point center, double[] bond_dq)
        {
            TJJS_Point[] result = new TJJS_Point[in_point_list.Length];

            for (int i = 0; i < Recipe.ACF.Pos_List.Count; i++)
            {
                result[i] = new TJJS_Point();
                result[i].Set(in_point_list[i].Rotate(center, -bond_dq[i]));
            }
            return result;
        }
        static public bool Cal_ACF_Check_1(int no)
        {
            bool result = true;
            string fun = "Cal_ACF_Check_1";
            emModel model = emModel.ACF_Check1;
            TCamera_Base camera = null;
            TFind_ACF_Check_Param param = null;
            TImage_Log image_log = null;
            string title_str = "";
            HImage in_image = new HImage();

            Check_No = no;
            title_str = fun + string.Format(" No={0:d}", no + 1);
            Log_Add(fun, title_str);
            if (no >= 0 && no < Recipe.ACF.Pos_List.Count)
            {
                camera = Get_Camera(model);
                if (camera.Grab_Image(ref in_image))
                {
                    param = Recipe.ACF.Pos_List[no].Check[0].Param;
                    image_log = Image_Logs.Get_Image_Log(Get_Model_Name(model, no));
                    result = Cal_ACF_Check(fun, title_str, in_image, param, ref image_log);
                }
            }
            return result;
        }
        static public bool Cal_ACF_Check_2(int no)
        {
            bool result = true;
            string fun = "Cal_ACF_Check_2";
            emModel model = emModel.ACF_Check2;
            TCamera_Base camera = null;
            TFind_ACF_Check_Param param = null;
            TImage_Log image_log = null;
            string title_str = "";
            HImage in_image = new HImage();

            Check_No = no;
            title_str = fun + string.Format(" No={0:d}", no + 1);
            Log_Add(fun, title_str);
            if (no >= 0 && no < Recipe.ACF.Pos_List.Count)
            {
                camera = Get_Camera(model);
                if (camera.Grab_Image(ref in_image))
                {
                    param = Recipe.ACF.Pos_List[no].Check[1].Param;
                    image_log = Image_Logs.Get_Image_Log(Get_Model_Name(model, no));
                    result = Cal_ACF_Check(fun, title_str, in_image, param, ref image_log);
                }
            }
            return result;
        }
        static public bool Cal_ACF_Check(string fun, string title_str, HImage in_image, TFind_ACF_Check_Param param, ref TImage_Log image_log)
        {
            bool result = true;
            HImage tmp_Image = new HImage();
            TFind_ACF_Check_Result check_result = null;

            if (param != null && image_log != null)
            {
                check_result = image_log.Result_ACF_Check;
                if (check_result != null)
                {
                    image_log.Image = in_image;
                    result = param.Find(in_image, ref check_result);
                    Log_Add(fun, title_str + string.Format("Result={0:s}", result ? "OK" : "NG"));

                    image_log.Reflash = true;
                    tmp_Image = DumpWindowImage(in_image, check_result);
                    Save_Image(tmp_Image, check_result.Find_OK, image_log.Name);
                }
            }
            if (!result) Log_Add(fun, title_str + "失敗", emLog_Type.Warning);
            return result;
        }

        #endregion

        #region 光源
        static public void Set_Light_All_OFF()
        {
            for (int i = 0; i < Light1.Channel_Count; i++)
            {
                TPub.Light1.Set_Light(i, 0);
            }
        }
        static public void Set_Light_All_ON()
        {
            for (int i = 0; i < Light1.Channels.Count; i++)
            {
                TPub.Light1.Set_Light(i, Light1.Max_Value);
            }
        }
        static public TLight_Channel_List Get_Light_Channels(emModel model)
        {
            TLight_Channel_List result = new TLight_Channel_List();

            switch (model)
            {
                case emModel.PCB_L:
                    result.Add(Light_Channels["PCB_L外環光"]);
                    result.Add(Light_Channels["PCB_L內同軸"]);
                    break;

                case emModel.PCB_R:
                    result.Add(Light_Channels["PCB_R外環光"]);
                    result.Add(Light_Channels["PCB_R內同軸"]);
                    break;

                case emModel.ACF_Check1:
                    result.Add(Light_Channels["PCB_L外環光"]);
                    result.Add(Light_Channels["PCB_L內同軸"]);
                    break;

                case emModel.ACF_Check2:
                    result.Add(Light_Channels["PCB_R外環光"]);
                    result.Add(Light_Channels["PCB_R內同軸"]);
                    break;
            }
            return result;
        }
        static public bool Set_Light(emModel model, int no = 0)
        {
            bool result = true;
            string fun = "Set_Light";
            TLight_Channel_List light_channels = new TLight_Channel_List();

            Log_Add(fun, string.Format("[Set_Light] Model={0:s} No={1:d}", model.ToString(), no + 1));
            light_channels = Get_Light_Channels(model);
            if (no >= 0 && no < Recipe.ACF.Pos_List.Count)
            {
                switch (model)
                {
                    case emModel.PCB_L: light_channels.Set_Value(Recipe.PCB.Mark.L.Light); break;
                    case emModel.PCB_R: light_channels.Set_Value(Recipe.PCB.Mark.R.Light); break;
                    case emModel.ACF_Check1: light_channels.Set_Value(Recipe.ACF.Pos_List[no].Check[0].Light); break;
                    case emModel.ACF_Check2: light_channels.Set_Value(Recipe.ACF.Pos_List[no].Check[1].Light); break;
                }

                for (int i = 0; i < light_channels.Count; i++) light_channels[i].Set_Light();
            }
            return result;
        }
        #endregion

        #region Display相關
        public static HImage Get_Image_Log_Image(TImage_Log image_log)
        {
            HImage result = null;

            result = image_log.Image;
            return result;
        }
        public static void Disp_View(ref TFrame_JJS_HW jjs_hw, int index, bool fore_disp)
        {

            TCamera_View view = null;
            HImage image = new HImage();
            double scale = 1;
            int line_width = 1;
            int w, h;

            //hw_buf.HalconWindow.ClearWindow();
            try
            {
                if (index < Camera_View.Length)
                {
                    view = Camera_View[index];


                    //display image
                    view.Camera.Get_HImage(ref image);
                    image.GetImageSize(out w, out h);
                    scale = (double)w / jjs_hw.Width;
                    view.Set_Scale(scale);

                    jjs_hw.SetPart(image);
                    jjs_hw.HW_Buf.HalconWindow.DispObj(image);


                    //display CCD name
                    JJS_Vision.Display_String(jjs_hw.HW_Buf, view.Camera.Name, 10, 10, 25, scale, "blue");

                    //display 畫面十字線
                    line_width = (int)Math.Round(2 * scale + 1, 0);
                    jjs_hw.HW_Buf.HalconWindow.SetLineWidth(line_width);
                    JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, image, "red");

                    //display find data
                    Disp_View_Message(jjs_hw.HW_Buf, view);
                    Disp_View_Model(jjs_hw.HW_Buf, view);

                }
            }
            catch { }
            jjs_hw.Copy_HW();
            image.Dispose();
        }
        public static void Disp_View_Message(HWindowControl hw, TCamera_View view)
        {
            for (int i = 0; i < view.Find_Data_Count; i++)
                view.Find_Data[i].Display_Message(hw);
        }
        public static void Disp_View_Model(HWindowControl hw, TCamera_View view)
        {
            HRegion tmp_region = new HRegion();

            for (int i = 0; i < view.Find_Data.Length; i++)
                JJS_Vision.Display_Hairline(hw, view.Find_Data[i].Col, view.Find_Data[i].Row, 30, 0, "yellow");

            view.Find_Data[view.Last_No].Display_Model(hw);

            hw.HalconWindow.SetColor(emSetColor.green);
            hw.HalconWindow.SetDraw(emSetDraw.margin);
            tmp_region = Get_Find_Region(view.Last_No);
            hw.HalconWindow.DispObj(tmp_region);
        }
        public static void Disp_Log(ref TFrame_JJS_HW jjs_hw, int index, bool fore_disp)
        {
            TImage_Log image_log = null;
            TFind_ACF_Check_Result check_result = null;
            HImage tmp_image = null;
            string disp_name = "";
            double scale = 1;
            double line_width = 1;
            int w = 640, h = 480;
            string msg = "";

            image_log = Image_Logs[index];
            if (image_log != null && image_log.Result != null && (image_log.Reflash || fore_disp))
            {
                image_log.Reflash = false;
                tmp_image = Get_Image_Log_Image(image_log);
                if (JJS_Vision.Is_Not_Empty(tmp_image))
                {
                    tmp_image.GetImageSize(out w, out h);
                    jjs_hw.SetPart(tmp_image);
                    jjs_hw.HW_Buf.HalconWindow.DispObj(tmp_image);
                }

                if (jjs_hw.Width > 0) scale = (double)w / jjs_hw.Width;
                image_log.Set_Scale(scale);

                //display result info
                image_log.Result.Display(jjs_hw.HW_Buf);

                //display CCD name
                disp_name = string.Format("({0:d}).{1:s}", image_log.No + 1, image_log.Name);
                JJS_Vision.Display_String(jjs_hw.HW_Buf, disp_name, 10, 10, 20, scale, emSetColor.blue);

                //display 螢幕十字線
                if (JJS_Vision.Is_Not_Empty(tmp_image))
                {
                    line_width = 2 * scale + 1;
                    jjs_hw.HW_Buf.HalconWindow.SetLineWidth((int)line_width);
                    JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, tmp_image, emSetColor.red);
                }

                //check_result = image_log.Result_ACF_Check;
                //if (check_result != null)
                //{
                //    msg = string.Format("SN={0:d}", check_result.SN);
                //    JJS_Vision.Display_String(jjs_hw.HW_Buf, msg, 10, 40, 16, scale, "green");
                //}
                jjs_hw.Copy_HW();
            }
        }
        public static void Disp_Log_ACF(ref TFrame_JJS_HW jjs_hw, int index, bool fore_disp)
        {
            TImage_Log image_log = null;
            TFind_ACF_Check_Result check_result = null;
            HImage tmp_image = null;
            string disp_name = "";
            double scale = 1;
            double line_width = 1;
            int w = 640, h = 480;
            string msg = "";

            switch (index)
            {
                case 0: image_log = Image_Logs.Get_Image_Log(Get_Model_Name(emModel.ACF_Check1, Check_No)); break;
                case 1: image_log = Image_Logs.Get_Image_Log(Get_Model_Name(emModel.ACF_Check2, Check_No)); break;
            }
            if (image_log != null && image_log.Result != null && (image_log.Reflash || fore_disp))
            {
                image_log.Reflash = false;
                tmp_image = Get_Image_Log_Image(image_log);
                if (JJS_Vision.Is_Not_Empty(tmp_image))
                {
                    tmp_image.GetImageSize(out w, out h);
                    jjs_hw.SetPart(tmp_image);
                    jjs_hw.HW_Buf.HalconWindow.DispObj(tmp_image);
                }

                if (jjs_hw.Width > 0) scale = (double)w / jjs_hw.Width;
                image_log.Set_Scale(scale);

                //display result info
                image_log.Result.Display(jjs_hw.HW_Buf);

                //display CCD name
                disp_name = string.Format("({0:d}).{1:s}", image_log.No + 1, image_log.Name);
                JJS_Vision.Display_String(jjs_hw.HW_Buf, disp_name, 10, 10, 20, scale, emSetColor.blue);

                //display 螢幕十字線
                if (JJS_Vision.Is_Not_Empty(tmp_image))
                {
                    line_width = 2 * scale + 1;
                    jjs_hw.HW_Buf.HalconWindow.SetLineWidth((int)line_width);
                    JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, tmp_image, emSetColor.red);
                }

                //check_result = image_log.Result_ACF_Check;
                //if (check_result != null)
                //{
                //    msg = string.Format("SN={0:d}", check_result.SN);
                //    JJS_Vision.Display_String(jjs_hw.HW_Buf, msg, 10, 40, 16, scale, "green");
                //}
                jjs_hw.Copy_HW();
            }
        }
        public static void Reset_All()
        {
            Find_Data.Reset();
        }
        public static HRegion Get_Find_Region(int last_no)
        {
            HRegion result = new HRegion();
            stRect_Double rect = new stRect_Double();

            if (last_no == 0) rect = Recipe.PCB.Mark.L.Model.Find_Region;
            if (last_no == 1) rect = Recipe.PCB.Mark.R.Model.Find_Region;
            result.GenRectangle1(rect.Y1, rect.X1, rect.Y2, rect.X2);

            return result;
        }
        #endregion

        #region 量測相關
        static public TJJS_Point Get_Abs_Pos(emModel model, TFind_Data_Result data)
        {
            TJJS_Point result = new TJJS_Point();
            TFind_Mothed_1_Result model_result = null;

            if (data.Result is TFind_Mothed_1_Result)
            {
                model_result = (TFind_Mothed_1_Result)data.Result;
                result = Get_Abs_Pos(model, model_result.Col, model_result.Row, data.Pos);
            }
            return result;
        }
        static public TJJS_Point Get_Abs_Pos(emModel model, double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();
            switch (model)
            {
                case emModel.PCB_L:
                    result = Get_Abs_Pos_PCB_L(col, row, pos);
                    break;

                case emModel.PCB_R:
                    result = Get_Abs_Pos_PCB_R(col, row, pos);
                    break;
            }
            return result;
        }
        static private TJJS_Point Get_Abs_Pos_PCB_L(double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point tmp = new TJJS_Point();
            emCCD_Name ccd_name = emCCD_Name.PCB1;
            double x, y, ccd_x, ccd_y;

            TCamera_Base camera = Get_Camera(ccd_name);
            x = pos.Get_Value_Double("Table_Y");
            y = pos.Get_Value_Double("Table_X");
            ccd_x = pos.Get_Value_Double("ACF_Y");
            ccd_y = 0.0;

            tmp = Pixel_To_Pos(ccd_name, new TJJS_Point(col - camera.Image_Width / 2, row - camera.Image_Height / 2));
            result.X = tmp.X - x - ccd_x;
            result.Y = -tmp.Y - y - ccd_y;
            return result;
        }
        static private TJJS_Point Get_Abs_Pos_PCB_R(double col, double row, TJJS_Value_List pos)
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point tmp = new TJJS_Point();
            emCCD_Name ccd_name = emCCD_Name.PCB2;
            double x, y, ccd_x, ccd_y;

            TCamera_Base camera = Get_Camera(ccd_name);
            x = pos.Get_Value_Double("Table_Y");
            y = pos.Get_Value_Double("Table_X");
            ccd_x = 0.0;
            ccd_y = 0.0;

            tmp = Pixel_To_Pos(ccd_name, new TJJS_Point(col - camera.Image_Width / 2, row - camera.Image_Height / 2));
            result.X = tmp.X - x - ccd_x;
            result.Y = -tmp.Y - y - ccd_y;
            return result;
        }
        static private TJJS_Point Pixel_To_Pos(emCCD_Name ccd_name, TJJS_Point in_pixel)
        {
            TJJS_Point result = new TJJS_Point();
            int no = Get_Camera_No(ccd_name);

            result.X = in_pixel.X * Environment.CCDs[no].Pixel_Size_X;
            result.Y = in_pixel.Y * Environment.CCDs[no].Pixel_Size_Y;
            return result;
        }

        static public void Measure_Get_Find_Data(int ccd_no, ref TMeasure_Data m_data)
        {
            emCCD_Name ccd_name = emCCD_Name.None;
            emModel mode = emModel.None;

            ccd_name = Get_emCCD_Name(ccd_no);
            mode = Measure_Get_Model(ccd_name);
            Get_PLC_Pos(mode, ref m_data.Param);
        }
        static public void Measure_CCD_Change(TForm_Measure form, int no)
        {
            HImage image = new HImage();

            form.Camera = Cameras[no];
            image = form.Camera.Get_HImage();
            form.Set_Scale(image);
        }
        static public TJJS_Point Measure_Get_Abs_Pos(int ccd_no, TMeasure_Data m_data)
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Value_List pos = new TJJS_Value_List();
            emCCD_Name ccd_name = Get_emCCD_Name(ccd_no);
            emModel mode = emModel.None;
            
            mode = Measure_Get_Model(ccd_name);
            result = Get_Abs_Pos(mode, m_data.Col, m_data.Row, m_data.Param);
            return result;
        }
        static public emModel Measure_Get_Model(emCCD_Name ccd_name)
        {
            emModel result = emModel.None;
            switch (ccd_name)
            {
                case emCCD_Name.PCB1: result = emModel.PCB_L; break;
                case emCCD_Name.PCB2: result = emModel.PCB_R; break;
            }
            return result;
        }
        #endregion

        #region MU Select 手動選取相關功能
        static public bool MU_Select(emModel model)
        {
            bool result = false;
            string model_name = model.ToString();
            TMU_Select_Data mu_data = new TMU_Select_Data();
            TJJS_Value_List mu_param = new TJJS_Value_List();

            Set_MU_Param(ref mu_param, model);
            mu_data.Set(model_name, model_name + "手動選取中", Get_Camera(model), mu_param);
            MU_Data_List.Add(mu_data);
            return result;
        }
        static public void Set_MU_Param(ref TJJS_Value_List mu_param, emModel model)
        {
            mu_param.Add("Model", model);
        }
        static public void Get_MU_Data(TMU_Select_Data mu_data, ref TCamera_View camera_view, ref int last_no, ref TFind_Data_Result f_result, ref TImage_Log f_result_log, ref emModel model)
        {
            TJJS_Value value = null;

            value = mu_data.Param.Get_Value("Model");
            if (value != null) model = (emModel)value.Value;

            camera_view = Get_Camera_View(model);
            last_no = Get_Last_No(model);

            f_result = Get_Find_Data(model);
            f_result_log = Image_Logs.Get_Image_Log(model);
        }
        static public void MU_Select_Display(TFrame_JJS_HW jjs_hw, TMU_Select_Data mu_data)
        {
            HImage image = new HImage();
            TCamera_View camera_view = null;
            int last_no = 0;
            TFind_Data_Result f_result = null;
            TImage_Log f_result_log = null;
            emModel model = emModel.None;
            double scale = 1;
            int line_width = 1;
            int w, h;

            Get_MU_Data(mu_data, ref camera_view, ref last_no, ref f_result, ref f_result_log, ref model);
            try
            {
                //display image
                camera_view.Camera.Get_HImage(ref image);
                image.GetImageSize(out w, out h);
                scale = 1;// (double)w / jjs_hw.Width;

                jjs_hw.SetPart(image);
                jjs_hw.HW_Buf.HalconWindow.DispObj(image);

                //display 畫面十字線
                line_width = (int)Math.Round(2 * scale + 1, 0);
                jjs_hw.HW_Buf.HalconWindow.SetLineWidth(line_width);
                JJS_Vision.Display_Hairline(jjs_hw.HW_Buf, image, "red");

                //display find data
                f_result.Set_Scale(scale);
                f_result.Display_Message(jjs_hw.HW_Buf);
                f_result.Display_Model(jjs_hw.HW_Buf);
            }
            catch { }
        }
        static public void MU_Select_Get_Find_Data(TMU_Select_Data mu_data)
        {
            TCamera_View camera_view = null;
            int last_no = 0;
            TFind_Data_Result f_result = null;
            TImage_Log f_result_log = null;
            emModel model = emModel.None;

            Get_MU_Data(mu_data, ref camera_view, ref last_no, ref f_result, ref f_result_log, ref model);

            Get_PLC_Pos(model, ref f_result.Pos);
            if (f_result.Result is TFind_Mothed_1_Result)
            {
                TFind_Mothed_1_Result model_result = (TFind_Mothed_1_Result)f_result.Result;
                model_result.Find_OK = true;
                model_result.Col = mu_data.Col;
                model_result.Row = mu_data.Row;
                model_result.Score = 0.99;
                model_result.Angle = 0;
            }
        }
        static public void MU_Select_Get_Finish(TMU_Select_Data mu_data)
        {
            string log_name = "";
            string fun = "MU_Select_Get_Finish";
            TCamera_View camera_view = null;
            int last_no = 0;
            TFind_Data_Result f_result = null;
            TImage_Log f_result_log = null;
            emModel model = emModel.None;

            Get_MU_Data(mu_data, ref camera_view, ref last_no, ref f_result, ref f_result_log, ref model);
            switch (model)
            {
                case emModel.PCB_L:
                    log_name = model.ToString();
                    TPub.PLC.PLC_Out.PCB_L_MU_Grab.Finish = true;
                    TPub.PLC.PLC_Out.PCB_L_MU_Grab.OK = mu_data.Select_OK;
                    Log_Add(fun, string.Format("[MU_Select_Get_Finish] Model={0:s} Result={1:s}", model.ToString(), TPub.PLC.PLC_Out.PCB_L_MU_Grab.OK ? "OK" : "NG"));
                    break;

                case emModel.PCB_R:
                    log_name = model.ToString();
                    TPub.PLC.PLC_Out.PCB_R_MU_Grab.Finish = true;
                    TPub.PLC.PLC_Out.PCB_R_MU_Grab.OK = mu_data.Select_OK;
                    Log_Add(fun, string.Format("[MU_Select_Get_Finish] Model={0:s} Result={1:s}", model.ToString(), TPub.PLC.PLC_Out.PCB_R_MU_Grab.OK ? "OK" : "NG"));
                    break;
            }

            camera_view.Last_No = last_no;
            mu_data.Select = false;
        }
        #endregion

        #region Log
        static public void Log_Find_Data(string fun, string title, TFind_Data_Result find_data)
        {
            double x = find_data.Pos.Get_Value_Double("X");
            double y = find_data.Pos.Get_Value_Double("Y");
            double q = find_data.Pos.Get_Value_Double("Q");
            double ccd = find_data.Pos.Get_Value_Double("CCD");

            if (find_data.Result is TFind_Mothed_1_Result)
            {
                TFind_Mothed_1_Result model_result = find_data.Result_Mothed_1;
                Log_Add(fun, string.Format("{0:s} Col={1:f1} Row={2:f1} result={3:s} X={4:f3} Y={5:f3} Q={6:f3} CCD={7:f3}.",
                                       title, model_result.Col, model_result.Row, model_result.Find_OK ? "OK" : "NG",
                                       x, y, q, ccd));
            }
            Log_Add(fun, find_data.Pos.To_String());
        }
        static public void Log_Line(string fun, string title, TJJS_Line line)
        {
            Log_Add(fun, title + string.Format("{0:s} S({1:f3},{2:f3}), E({3:f3},{4:f3}) Len={5:f3} angle={6:f4}",
                                   title, line.Start.X, line.Start.Y, line.End.X, line.End.Y, line.Length(), line.V.Angle.d));
        }
        static public void Log_Ofs(string fun, string title, TOfs ofs)
        {
            Log_Add(fun, string.Format("{0:s} Ofs_X={1:f3}, Ofs_Y={2:f3}, Ofs_Q={3:f3}", title, ofs.X, ofs.Y, ofs.Q));
        }
        static public void Log_Limit(string fun, string title, TLimit limit, double value, bool result)
        {
            Log_Add(fun, string.Format("{0:s} Limit_Min={1:f3}, Value={2:f3}, Limit_Max={3:f3} Result={4:f}",
                                   title, limit.Min, value, limit.Max, result ? "OK" : "NG"));
        }
        static public void Log_Point_List(string fun, string title, TJJS_Point[] in_point_list)
        {
            for (int i = 0; i < in_point_list.Length; i++)
            {
                Log_Add(fun, string.Format("{0:s} Point{1:d}({2:f3},{3:f3})",
                                       title, i + 1, in_point_list[i].X, in_point_list[i].Y)); 
            }
        }
        static public void Log_DXYQ(string fun, string title, double[] bond_dx, double[] bond_dy, double[] bond_dq)
        {
            for (int i = 0; i < bond_dx.Length; i++)
            {
                Log_Add(fun, string.Format("{0:s} No={1:d} DX={2:f3}, DY={3:f3}, DQ={4:f3}.",
                                       title, i + 1, bond_dx[i], bond_dy[i], bond_dq[i]));
            }
        }

        

        static public string Get_Log_Path(bool f_result)
        {
            string result = "";
            System.DateTime dt;
            string date_str = "";
            string find_str = "";

            dt = System.DateTime.Now;
            date_str = dt.ToString("yyyy_MM_dd");

            if (f_result) find_str = "Image_OK";
            else find_str = "Image_NG";

            result = Environment.Base.Database_Path + "Log\\" + date_str + "\\" + find_str + "\\";
            return result;
        }
        static public string Get_Log_File_Name(string title_str)
        {
            string result = "";
            System.DateTime dt;
            string time_str = "";

            dt = System.DateTime.Now;
            time_str = dt.ToString("_hh_mm_ss") + string.Format("_{0:d3}", dt.Millisecond);
            result = title_str + time_str + Get_Log_File_Ext();
            return result;
        }
        static public string Get_Log_File_Ext()
        {
            string result = ".jpg";

            //if (Environment.Log.Save_Image_Type == "BMP") result = result + ".bmp";
            //if (Environment.Log.Save_Image_Type == "JPG") result = result + ".jpg";
            return result;
        }
        static public string Get_Log_Full_File_Name(bool f_result, string title_str)
        {
            string result = "";
            result = Get_Log_Path(f_result) + Get_Log_File_Name(title_str);
            return result;
        }
        static public void Save_Image(HImage in_image, bool f_result, string log_name)
        {
            string filename = Get_Log_Full_File_Name(f_result, log_name);

            if ((f_result && Environment.Log.Save_OK_Image) ||
                (!f_result && Environment.Log.Save_NG_Image))
                Save_Image(in_image, filename);
        }
        static public void Save_Image(HImage in_image, string filename)
        {
            JJS_Vision.Write_File(in_image, filename);
        }
        static public HImage DumpWindowImage(HImage in_image, TFind_Data_Result f_result)
        {
            HImage result = new HImage();
            HWindowControl hw = new HWindowControl();
            TImage_Log tmp_result = new TImage_Log();

            if (in_image != null)
            {
                tmp_result.Set(f_result);
                tmp_result.Set_Scale(1);
                JJS_Vision.Set_HW_Size(hw, in_image);
                JJS_Vision.SetPart(hw, in_image);
                hw.HalconWindow.DispObj(in_image);
                tmp_result.Display_Message(hw);
                tmp_result.Display_Model(hw);
                result = hw.HalconWindow.DumpWindowImage();
            }
            return result;
        }
        static public HImage DumpWindowImage(HImage in_image, TFind_ACF_Check_Result f_result)
        {
            HImage result = new HImage();
            HWindowControl hw = new HWindowControl();
            TFind_ACF_Check_Result tmp_result = new TFind_ACF_Check_Result();

            if (in_image != null)
            {
                tmp_result.Set(f_result);
                //tmp_result.Disp_Param.Set_Scale(1);

                JJS_Vision.Set_HW_Size(hw, in_image);
                JJS_Vision.SetPart(hw, in_image);
                hw.HalconWindow.DispObj(in_image);
                tmp_result.Display_Message(hw);
                tmp_result.Display_Model(hw);
                result = hw.HalconWindow.DumpWindowImage();
            }
            return result;
        }
        #endregion
        
        #region Robot1
        static public bool Robot1_Program_Run()
        {
            bool result = false;
            string fun = "Robot1_Program_Run";

            Log_Add(fun, "Robot1_Program_Run");
            Robot1.Program_Start();
            result = true;
            return result;
        }
        static public bool Robot1_Program_Stop()
        {
            bool result = false;
            string fun = "Robot1_Program_Stop";

            Log_Add(fun, "Robot1_Program_Stop");
            Robot1.Program_Stop();
            result = true;
            return result;
        }
        static public bool Robot1_Program_Reset()
        {
            bool result = false;
            string fun = "Robot1_Program_Reset";

            Log_Add(fun, "Robot1_Program_Reset");
            Robot1.Reset_Abort();
            result = true;
            return result;
        }
        #endregion

        #region Other
        static public int Get_Max_Int(double x, double block_x)
        {
            int result = 0;
            result = (int)(x / block_x);

            if (result * block_x != x) result = result + 1;
            return result;
        }
        static public HImage Get_Whilte_Image(string filename)
        {
            HImage result = new HImage();
            HImage in_image = new HImage();
            HImage white_mean = new HImage();
            HImage white_base = new HImage();
            HRegion region = new HRegion();
            int w = 0, h = 0;
            double mean, div;

            if (System.IO.File.Exists(filename))
            {
                in_image.ReadImage(filename);
                in_image.GetImageSize(out w, out h);
                region.GenRectangle1(0.0, 0.0, w, h);
                in_image = in_image.ConvertImageType("real");
                white_mean = in_image.MeanImage(20, 20);
                mean = white_mean.Intensity(region, out div);

                white_base.GenImageConst("real", w, h);
                white_base = white_base.GenImageProto(mean);
                result = white_base.DivImage(white_mean, 1.0, 0);
                //result.WriteImage("jpg", 0, "e:\\white_result.jpg");
            }
            return result;
        }
        static public HImage Cal_Whilte_Image(HImage in_image, HImage white_image)
        {
            HImage result = null;
            HImage tmp_image = new HImage();

            if (Environment.Base.Cal_White)
            {
                tmp_image = in_image.ConvertImageType("real");
                if (JJS_Vision.Is_Not_Empty(white_image))
                    tmp_image = tmp_image.MultImage(white_image, Environment.Base.Image_Mult, 0);

                result = tmp_image.ConvertImageType("byte");
            }
            else
            {
                result = in_image.Clone();
            }

            return result;
        }
        #endregion
    }

    //-----------------------------------------------------------------------------------------------------
    // TCamera_View
    //-----------------------------------------------------------------------------------------------------
    public class TCamera_View
    {
        public TCamera_Base Camera = null;
        public int Last_No = 0;
        public TFind_Data_Result[] Find_Data = new TFind_Data_Result[0];

        public int Find_Data_Count
        {
            get
            {
                return Find_Data.Length;
            }
            set
            {
                int old_count;

                old_count = Find_Data.Length;
                Array.Resize(ref Find_Data, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Find_Data[i] = new TFind_Data_Result();
                }
            }
        }
        public TCamera_View()
        {
        }
        public void Set_Scale(double scale)
        {
            for (int i = 0; i < Find_Data.Length; i++)
            {
                Find_Data[i].Set_Scale(scale);
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TFind_Data
    //-----------------------------------------------------------------------------------------------------
    public class TFind_Data
    {
        public TFind_Data_Result[] PCB = new TFind_Data_Result[2];

        public TFind_Data()
        {
            for (int i = 0; i < PCB.Length; i++) PCB[i] = new TFind_Data_Result();
        }
        public void Reset()
        {
            for (int i = 0; i < PCB.Length; i++) PCB[i].Reset();
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TFind_Data_Result
    //-----------------------------------------------------------------------------------------------------
    public class TFind_Data_Result : TBase_Class
    {
        public TJJS_Value_List Pos = new TJJS_Value_List();
        public TFind_Mothed_1_Result Find_Mothed1 = new TFind_Mothed_1_Result();

        public TBase_Result Result
        {
            get
            {
                return Find_Mothed1;
            }
        }
        public TFind_Mothed_1_Result Result_Mothed_1
        {
            get
            {
                return Find_Mothed1;
            }
        }
        public double Col
        {
            get
            {
                double result = 0;
                result = Find_Mothed1.Col;
                return result;
            }
        }
        public double Row
        {
            get
            {
                double result = 0;
                result = Find_Mothed1.Row;
                return result;
            }
        }
        public bool Find_OK
        {
            get
            {
                bool result = false;
                result = Find_Mothed1.Find_OK;
                return result;
            }
        }
        public TFind_Data_Result()
        {
        }
        override public TBase_Class New_Class()
        {
            return new TFind_Data_Result();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TFind_Data_Result && dis_base is TFind_Data_Result)
            {
                TFind_Data_Result sor = (TFind_Data_Result)sor_base;
                TFind_Data_Result dis = (TFind_Data_Result)dis_base;
                dis.Pos.Set(sor.Pos);
                dis.Find_Mothed1.Set(sor.Find_Mothed1);
            }
        }

        public void Reset()
        {
            Find_Mothed1.Reset();
        }
        public void Display_Message(HWindowControl hw)
        {
            Find_Mothed1.Display_Message(hw);
        }
        public void Display_Model(HWindowControl hw)
        {
            Find_Mothed1.Display_Model(hw);
        }
        public void Set_Scale(double scale)
        {
            Find_Mothed1.Disp_Param.Scale = scale;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TImage_Logs
    //-----------------------------------------------------------------------------------------------------
    public class TImage_Logs
    {
        public TImage_Log[] Items = new TImage_Log[0];

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count = Items.Length;
                Array.Resize(ref Items, value);
                for (int i = old_count; i < value; i++)
                {
                    Items[i] = new TImage_Log();
                }
            }
        }
        public TImage_Log this[int index]
        {
            get
            {
                TImage_Log result = null;

                if (index >= 0 && index < Items.Length)
                {
                    result = Items[index];
                }
                return result;
            }
        }
        public TImage_Log this[string name]
        {
            get
            {
                TImage_Log result = null;
                int index = Get_Index(name);

                return this[index];
            }
        }
        public TImage_Logs(int count = 0)
        {
            Count = count;
            for (int i = 0; i < Count; i++) Items[i].Name = string.Format("({0:d2})", i + 1);
        }
        public void Set_Data(string name, TBase_Result result)
        {
            TImage_Log image_log = this[name];
            if (image_log != null)
            {
                image_log.Set_Result(result);
            }
        }
        public int Get_Index(string name)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (name == Items[i].Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public TImage_Log Get_Image_Log(string name)
        {
            TImage_Log result = null;

            result = this[name];
            return result;
        }
        public TImage_Log Get_Image_Log(emModel model)
        {
            TImage_Log result = null;

            result = this[model.ToString()];
            return result;
        }
        public TFind_Mothed_1_Result Get_Result_Mothed_1(emModel model)
        {
            TFind_Mothed_1_Result result = null;
            TImage_Log image_log = null;

            image_log = Get_Image_Log(model);
            if (image_log != null)
            {
                result = image_log.Result_Mothed_1;
            }
            return result;
        }
        public TFind_ACF_Check_Result Get_Result_ACF_Check(emModel model)
        {
            TFind_ACF_Check_Result result = null;
            TImage_Log image_log = null;

            image_log = Get_Image_Log(model);
            if (image_log != null)
            {
                result = image_log.Result_ACF_Check;
            }
            return result;
        }
    }
    public class TImage_Log : TBase_Class
    {
        public string Name = "";
        public int No = 0;
        public HImage Image = new HImage();
        public TBase_Result Result = null;

        public bool Reflash
        {
            get
            {
                return Result.Reflash;
            }
            set
            {
                Result.Reflash = value;
            }
        }
        public TFind_Mothed_1_Result Result_Mothed_1
        {
            get
            {
                TFind_Mothed_1_Result result = null;

                if (Result != null && Result is TFind_Mothed_1_Result)
                {
                    result = (TFind_Mothed_1_Result)Result;
                }
                return result;
            }
        }
        public TFind_ACF_Check_Result Result_ACF_Check
        {
            get
            {
                TFind_ACF_Check_Result result = null;

                if (Result != null && Result is TFind_ACF_Check_Result)
                {
                    result = (TFind_ACF_Check_Result)Result;
                }
                return result;
            }
        }
        public TImage_Log()
        {
            Name = "default";
            Image.GenImageConst("byte", 640, 480);
        }
        override public TBase_Class New_Class()
        {
            return new TImage_Log();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TImage_Log && dis_base is TImage_Log)
            {
                TImage_Log sor = (TImage_Log)sor_base;
                TImage_Log dis = (TImage_Log)dis_base;

                dis.Name = sor.Name;
                JJS_Vision.Copy_Obj(sor.Image, ref dis.Image);
                dis.Result = (TBase_Result)sor.Result.Copy();
                dis.Reflash = sor.Reflash;
            }
        }
        public void Set_Data(string name, TBase_Result result)
        {
            Name = name;
            Set_Result(result);
        }
        public void Set_Data(HImage in_image, TBase_Result result)
        {
            JJS_Vision.Copy_Obj(in_image, ref Image);
            Set_Result(result);
            Reflash = true;
        }
        public void Set_Image(HImage image)
        {
            JJS_Vision.Copy_Obj(image, ref Image);
        }
        public void Set_Result(TBase_Result result)
        {
            Result = (TBase_Result)result.Copy();
        }

        public void Reset()
        {
            Result.Reset();
        }
        public void Display_Message(HWindowControl hw)
        {
            if (Result != null) Result.Display_Message(hw);
        }
        public void Display_Model(HWindowControl hw)
        {
            if (Result != null) Result.Display_Model(hw);
        }
        public void Set_Scale(double scale)
        {
            if (Result_Mothed_1 != null)
                Result_Mothed_1.Disp_Param.Scale = scale;

            if (Result_ACF_Check != null)
                Result_ACF_Check.Disp_Param.Scale = scale;
        }
    }
}
