using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;
using EFC.PLC;
using EFC.PLC.Melsec;//TMelsec_QPLC_Eth_Connect功能
using EFC.Robot.Epson;

namespace Main
{
    public delegate void evPLC_No_Thread_Run(string thread_name);

    public class TPLC
    {
        public TMelsec_QPLC_Eth_Connect          PLC_Socket = new TMelsec_QPLC_Eth_Connect();      
        public TPLC_Data_In                      PLC_In = new TPLC_Data_In();
        public TPLC_Data_Out                     PLC_Out = new TPLC_Data_Out();
        public TPLC_Data_Recipe                  PLC_Recipe = new TPLC_Data_Recipe();

        private Thread                           PLC_Thread;
        private PLC_Thread_List                  Thread_List = new PLC_Thread_List();


        private TLog                             in_Log = null;
        public string                            Log_Source = "TPLC";
        private bool                             Terminate = false;
        private bool                             Thread_ON = false;
        private double                           in_Scan_Time;
        private System.Diagnostics.Stopwatch     Watch = new System.Diagnostics.Stopwatch();


        public TPLC()
        {
            
            PLC_Thread = new Thread(Thread_Start); }
        public void Dispose()
        {
            Stop();
        }
        public TLog Log
        {
            get
            { 
                return in_Log; 
            }
            set
            {
                in_Log = value; 
                //PLC_Socket.Log = value; 
            }
        }
        public double Scan_Time
        {
            get
            {
                return in_Scan_Time;
            }
        }
        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Log_Source, fun, msg_str, type);
        }

        public void Start()
        {
            PLC_Thread.Start();
        }
        public void Stop()
        {
            Terminate = true;
            while (Thread_ON)
            {
                Application.DoEvents();
            }
        }
        public void Thread_Start()
        {
            Thread_ON = true;
            while (!Terminate)
            {
                
                Watch.Reset();
                Watch.Start();

                PLC_Out.On_Line = !PLC_Out.On_Line;

                Read_From_PLC();
                Write_To_PLC();
                No_Thread_Add(PLC_In.Write_Recipe_Req, PLC_Out.Write_Recipe, "Write_Recipe", Write_Recipe);

                Watch.Stop();  
                Thread.Sleep(10);
                in_Scan_Time = Watch.Elapsed.TotalMilliseconds;
              
            }
            Thread_ON = false;
        }
        private void Thread_Add(bool req, TPLC_CMD_Data cmd, string thread_name, evPLC_Thread_Run run_fun)
        {
            TJJS_Value_List param = new TJJS_Value_List();
            Thread_Add(req, cmd, thread_name, run_fun, param);
        }
        private void Thread_Add(bool req, TPLC_CMD_Data cmd, string thread_name, evPLC_Thread_Run run_fun, int model_no)
        {
            TJJS_Value_List param = new TJJS_Value_List();
            param.Add("model_no", model_no);
            Thread_Add(req, cmd, thread_name, run_fun, param);
        }
        private void Thread_Add(bool req, TPLC_CMD_Data cmd, string thread_name, evPLC_Thread_Run run_fun, TJJS_Value_List param)
        {
            if (req && !cmd.Running && !cmd.Finish)
            {
                cmd.Running = true;
                Thread_List.Add(new PLC_Thread(thread_name, run_fun, param));
            }
            else if (!req)
            {
                cmd.Running = false;
                cmd.Finish = false;
                cmd.OK = false;
            }
        }
        private void No_Thread_Add(bool req, TPLC_CMD_Data cmd, string thread_name, evPLC_No_Thread_Run run_fun)
        {
            if (req && !cmd.Running && !cmd.Finish)
            {
                cmd.Running = true;
                run_fun(thread_name);
            }
            else if (!req)
            {
                cmd.Running = false;
                cmd.Finish = false;
                cmd.OK = false;
            }
        }
        private void Read_From_PLC()
        {
            string fun = "Read_From_PLC";

            if (PLC_Socket.Connect)
            {
                if (!PLC_In.Read(PLC_Socket))
                    Log_Add(fun, "[PLC] Read_From_PLC Error.", emLog_Type.Error);
            }
        }
        private void Write_To_PLC()
        {
            string fun = "Read_From_PLC";

            TEpson_Robot robot = TPub.Robot1;

            #region Robot1
            PLC_Out.Robot1_Ready = robot.Connected;
            PLC_Out.Robot1_Running = robot.Program_Running;
            PLC_Out.Robot1_Warning = robot.Warning_On;
            PLC_Out.Robot1_Error = robot.Error_On;
            PLC_Out.Robot1_S_Error = false;
            PLC_Out.Robot1_E_Stop_On = robot.EStop_On;
            PLC_Out.Robot1_Safe_Door_On = robot.Safety_On;
            #endregion

            if (PLC_Socket.Connect)
            {
                if (!PLC_Out.Write(PLC_Socket))
                    Log_Add(fun, "[PLC] Write_To_PLC Error.", emLog_Type.Error);
            }
        }
        private void Write_Recipe(string thread_Name)//PLC_Thread thread, TJJS_Value_List param)
        {
            string fun = "Write_Recipe";

            PLC_In.Can_Change_Recipe = true;
            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", thread_Name));
            if (PLC_Socket.Connect)
            {
                if (PLC_In.Can_Change_Recipe)
                {
                    if (PLC_Recipe.Write(PLC_Socket))
                    {
                        PLC_Out.Write_Recipe.OK = true;
                        Log_Add(fun, "[PLC] PLC Recipe更新完成");
                    }
                    else
                    {
                        PLC_Out.Write_Recipe.OK = false;
                        Log_Add(fun, "[PLC] PLC Recipe更新失敗", emLog_Type.Error);
                    }
                }
                else
                {
                    PLC_Out.Write_Recipe.OK = false;
                    Log_Add(fun, "[PLC] PLC Recipe無法更新,請確認PLC狀態.", emLog_Type.Warning);
                }
            }
            else
            {
                PLC_Out.Write_Recipe.OK = false;
                Log_Add(fun, "[PLC] PLC  未連線, PLC Recipe更新失敗", emLog_Type.Warning);
            }
            PLC_Out.Write_Recipe.Finish = true;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_In
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Data_In : TPLC_Base_Data
    {
        #region Bit
        #region main
        public bool Write_Recipe_Req = false;
        public bool Write_MS_Param_Req = false;
        public bool Can_Change_Recipe = false;
        public bool Set_Light_All_OFF_Req = false;
        #endregion

        #region PCB
        public bool PCB_L_Set_Light_Req;
        public bool PCB_L_Grab_Req;
        public bool PCB_L_MU_Grab_Req;
        public bool PCB_R_Set_Light_Req;
        public bool PCB_R_Grab_Req;
        public bool PCB_R_MU_Grab_Req;
        public bool PCB_Cal_Req;
        public bool PCB_Check1_Set_Light_Req;
        public bool PCB_Check1_Check_Req;
        public bool PCB_Check2_Set_Light_Req;
        public bool PCB_Check2_Check_Req;
        public bool PCB_Check3_Set_Light_Req;
        public bool PCB_Check3_Check_Req;
        #endregion

        #region Robot1
        public bool Robot1_Program_Run_Req;        // 啟動程式要求
        public bool Robot1_Program_Stop_Req;       // 停止程式要求
        public bool Robot1_Error_Reset_Req;        // 系統異常重置
        public bool Robot1_Loop_Run_Req;           // 定點驅動要求

        public int Robot1_Speed = 50;              // Robot速度(1~100)
        public int Robot1_Loop_Run_Type = 0;       // Robot驅動Type編號  //手臂站別
        public int Robot1_Loop_Run_Step = 0;       // Robot驅動Step編號
        public int Robot1_Loop_Run_Tray_No = 0;    // Robot驅動Tray編號
        public int Robot1_Loop_Run_Tray_Z_No = 0;  // Robot驅動Tray 第No層
        public double Keyence_return_X = 0.00;
        public double Keyence_return_Y = 0.00;
        public double Keyence_return_Q = 0.00;
        public double PCB_Out_Ofs_X = 0.00;
        public double PCB_Out_Ofs_Y = 0.00;
        public double PCB_Out_Ofs_Q = 0.00;
        #endregion

        #endregion

        #region Word
        #region Main
        public int ACF_Banding_No;            //ACF貼附編號
        public int ACF_Check_No;              //ACF檢查編號
        public double PCB_DX;
        public double PCB_DY;
        public double PCB_DQ;
        #endregion

        #region 伺服軸位置
        public double Pos_PCB_Table_X;//ACF載台X_現在位置
        public double Pos_PCB_Table_Y;//ACF壓合Y_現在位置
        public double Pos_PCB_Table_Z;//ACF載台Z_現在位置
        public double Pos_PCB_Table_Q;//ACF壓合Q_現在位置
        public double Pos_PCB_CCD_Y;  //ACF CCD_Y_現在位置
        public double Pos_ACF_Supply; //ACF拉帶軸
        public double AP;             //Plasma載台



        public double Pos_Tray_LD_X;      //Tray LD_搬送X_現在位置
        public double Pos_Tray_LD_Z_G;    //Tray LD_供料Z現在位置
        public double Pos_Tray_LD_Z_S;    //Tray LD_收料Z現在位置

        public double Pos_Robot_X;      //Robot現在位置X
        public double Pos_Robot_Y;      //Robot現在位置Y
        public double Pos_Robot_Q;      //Robot現在位置Q
        #endregion
        #endregion

        public TPLC_Data_In()
        {

        }
        public bool Read(TMelsec_QPLC_Eth_Connect plc)
        {
            bool result = false;
            ushort[] read_data = new ushort[Count];
            if (plc.Connect)
            {
                int c = Max_Count;
                result = plc.Read_Byte(Start_Code, ref read_data, Count);
                Array.Copy(read_data, 0, Data, 0, Count);
            }
            Update();
            return result;
        }
        override public void Update()
        {
            #region Bit
            #region Main
            Can_Change_Recipe          = PLC_Data_Tool.Get_Bit(Data, 0, 1);
            Set_Light_All_OFF_Req      = PLC_Data_Tool.Get_Bit(Data, 0, 2);
            #endregion


            PCB_L_Grab_Req = PLC_Data_Tool.Get_Bit(Data, 1, 00);
            PCB_R_Grab_Req = PLC_Data_Tool.Get_Bit(Data, 1, 01);
            PCB_Cal_Req = PLC_Data_Tool.Get_Bit(Data, 1, 02);
            PCB_L_Set_Light_Req = PLC_Data_Tool.Get_Bit(Data, 1, 03);
            PCB_Check1_Set_Light_Req = PLC_Data_Tool.Get_Bit(Data, 1, 04);
            PCB_L_MU_Grab_Req = PLC_Data_Tool.Get_Bit(Data, 1, 05);
            PCB_R_MU_Grab_Req = PLC_Data_Tool.Get_Bit(Data, 1, 06);
            PCB_Check1_Check_Req = PLC_Data_Tool.Get_Bit(Data, 1, 07);
            PCB_Check2_Check_Req = PLC_Data_Tool.Get_Bit(Data, 1, 08);
            #region PCB
            //PCB_L_Grab_Req             = PLC_Data_Tool.Get_Bit(Data, 1, 00);
            //PCB_R_Grab_Req             = PLC_Data_Tool.Get_Bit(Data, 1, 01);
            //PCB_Cal_Req                = PLC_Data_Tool.Get_Bit(Data, 1, 02);
            //PCB_L_Set_Light_Req        = PLC_Data_Tool.Get_Bit(Data, 1, 03);
            //PCB_R_Set_Light_Req        = PLC_Data_Tool.Get_Bit(Data, 1, 04);

            //PCB_Check1_Set_Light_Req   = PLC_Data_Tool.Get_Bit(Data, 1, 05);
            //PCB_Check2_Set_Light_Req   = PLC_Data_Tool.Get_Bit(Data, 1, 06);
            //PCB_L_MU_Grab_Req          = PLC_Data_Tool.Get_Bit(Data, 1, 07);
            //PCB_R_MU_Grab_Req          = PLC_Data_Tool.Get_Bit(Data, 1, 08);
            //PCB_Check1_Check_Req       = PLC_Data_Tool.Get_Bit(Data, 1, 09);
            //PCB_Check2_Check_Req       = PLC_Data_Tool.Get_Bit(Data, 1, 10);
            #endregion   

            #region RB
            Robot1_Program_Run_Req = PLC_Data_Tool.Get_Bit(Data, 1, 11);
            Robot1_Program_Stop_Req = PLC_Data_Tool.Get_Bit(Data, 1, 12);
            Robot1_Error_Reset_Req = PLC_Data_Tool.Get_Bit(Data, 1, 13);
            Robot1_Loop_Run_Req = PLC_Data_Tool.Get_Bit(Data, 1, 14); 
            #endregion
            #endregion             
                       
            #region Word

            #region Main
            ACF_Banding_No = PLC_Data_Tool.Get_Word(Data, 10);               //ACF_壓合編號
            ACF_Check_No = PLC_Data_Tool.Get_Word(Data, 11);                 //ACF_檢查編號
            #endregion

            #region Pos
            Pos_PCB_Table_Z = PLC_Data_Tool.Get_DWord(Data, 300, 3);
            Pos_PCB_Table_X = PLC_Data_Tool.Get_DWord(Data, 302, 3);
            Pos_PCB_Table_Y = PLC_Data_Tool.Get_DWord(Data, 304, 3);

            Pos_PCB_CCD_Y = PLC_Data_Tool.Get_DWord(Data, 306, 3);
            Pos_ACF_Supply = PLC_Data_Tool.Get_DWord(Data, 308, 3);

            Pos_Tray_LD_Z_G = PLC_Data_Tool.Get_DWord(Data, 310, 3);
            Pos_Tray_LD_Z_S = PLC_Data_Tool.Get_DWord(Data, 312, 3);
            Pos_Tray_LD_X = PLC_Data_Tool.Get_DWord(Data, 314, 3);

            Pos_PCB_Table_Q = PLC_Data_Tool.Get_DWord(Data, 460, 3);
            Pos_Robot_X = PLC_Data_Tool.Get_DWord(Data, 516, 3);
            Pos_Robot_Y = PLC_Data_Tool.Get_DWord(Data, 518, 3);
            Pos_Robot_Q = PLC_Data_Tool.Get_DWord(Data, 520, 3);  
            #endregion

            #region Robot1
            Robot1_Speed = PLC_Data_Tool.Get_Word(Data, 54);
            Robot1_Loop_Run_Type = PLC_Data_Tool.Get_Word(Data, 55);
            Robot1_Loop_Run_Step = PLC_Data_Tool.Get_Word(Data, 56);
            Robot1_Loop_Run_Tray_No = PLC_Data_Tool.Get_Word(Data, 57);
            Robot1_Loop_Run_Tray_Z_No = PLC_Data_Tool.Get_Word(Data, 58);
            Keyence_return_X = PLC_Data_Tool.Get_DWord(Data, 59, 3);
            Keyence_return_Y = PLC_Data_Tool.Get_DWord(Data, 61, 3);
            Keyence_return_Q = PLC_Data_Tool.Get_DWord(Data, 63, 3);
            PCB_Out_Ofs_X = PLC_Data_Tool.Get_DWord(Data, 65, 3);
            PCB_Out_Ofs_Y = PLC_Data_Tool.Get_DWord(Data, 67, 3);
            PCB_Out_Ofs_Q = PLC_Data_Tool.Get_DWord(Data, 69, 3);

            #endregion
            #endregion

        }
        public void View_Data(string filename)
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, filename);
            form.ShowDialog();
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_Out
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Data_Out : TPLC_Base_Data
    {
        #region Bit
        #region Main
        public bool On_Line;
        public TPLC_CMD_Data Write_Recipe = new TPLC_CMD_Data();
        public TPLC_CMD_Data Set_Light_All_OFF = new TPLC_CMD_Data();
        #endregion

        #region PCB
        public TPLC_CMD_Data PCB_L_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_L_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_L_MU_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_R_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_R_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_R_MU_Grab = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_Cal = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_Check1_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_Check1_Check = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_Check2_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_Check2_Check = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_Check3_Set_Light = new TPLC_CMD_Data();
        public TPLC_CMD_Data PCB_Check3_Check = new TPLC_CMD_Data();
         
        #endregion

        #region Robot1
        public TPLC_CMD_Data Robot1_Program_Run = new TPLC_CMD_Data();
        public TPLC_CMD_Data Robot1_Program_Stop = new TPLC_CMD_Data();
        public TPLC_CMD_Data Robot1_Error_Reset = new TPLC_CMD_Data();
        public TPLC_CMD_Data Robot1_Loop_Run = new TPLC_CMD_Data();


        public bool Robot1_Ready;                // 程式等待啟動
        public bool Robot1_Running;              // 程式已啟動
        public bool Robot1_Warning;              // 警告
        public bool Robot1_Error;                // 異常
        public bool Robot1_S_Error;              // 系統異常
        public bool Robot1_On_Home;              // 原點位置到達
        public bool Robot1_E_Stop_On;            // 緊急停止
        public bool Robot1_Safe_Door_On;         // 安全門

        public int RB_Type; //站
        public int RB_Step; //點

        public bool[] Robot1_On_Pos_Tray_Load = new bool[10];   // Load Pos位置到達
        public bool[] Robot1_On_Pos_Plasma_Load = new bool[10];  
        public bool[] Robot1_On_Pos_Plasma_Unload = new bool[10];
        public bool[] Robot1_On_Pos_ACF_Load = new bool[10];
        public bool[] Robot1_On_Pos_ACF_Unload = new bool[10];
        public bool[] Robot1_On_Pos_PCB_Load = new bool[10];
        public bool[] Robot1_On_Pos_PCB_Unload = new bool[10];
        public bool[] Robot1_On_Pos_NG = new bool[10];     // NG Pos位置到達
        public bool[] Robot1_On_Pos_Teach = new bool[10];
    

        public int Robot1_Speed = 50;              // Robot速度(1~100)
        public int Robot1_Loop_Run_Type = 0;       // Robot驅動Type編號
        public int Robot1_Loop_Run_Step = 0;       // Robot驅動Step編號
        public int Robot1_Loop_Run_Tray_No = 0;    // Robot驅動Tray_No編號
        public double RB_Now_Pos_X = 0.00;
        public double RB_Now_Pos_Y = 0.00;
        public double RB_Now_Pos_Q = 0.00;
        public double RB_Now_Pos_U = 0.00;
        public double RB_Now_Pos_V = 0.00;
        public double RB_Now_Pos_W = 0.00;

        #endregion
        #endregion

        #region Word
        public int PCB_Camera_Status = 0;
        public double PCB_DX;
        public double PCB_DY;
        public double PCB_DQ;
        public TPLC_Out_DXYQ[] Bond_DXYQ = new TPLC_Out_DXYQ[10];
        #endregion

        public TPLC_Data_Out()
        {
            for (int i = 0; i < Bond_DXYQ.Length; i++) Bond_DXYQ[i] = new TPLC_Out_DXYQ();
        }
        public bool Write(TMelsec_QPLC_Eth_Connect plc)
        {
            bool result = false;

            Update();
            if (plc.Connect)
            {
                result = plc.Write_Byte(Start_Code, Data, Count);
            }
            return result;
        }
        override public void Update()
        {
            #region Bit
            #region Main
            PLC_Data_Tool.Set_Bit(Data, 00, 00, On_Line);
            PLC_Data_Tool.Set_Bit(Data, 00, 01, Write_Recipe.Finish);
            PLC_Data_Tool.Set_Bit(Data, 00, 02, Set_Light_All_OFF.Finish);
            #endregion


            #region PCB
            PLC_Data_Tool.Set_Bit(Data, 01, 00, PCB_L_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 01, PCB_R_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 02, PCB_L_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 01, 03, PCB_R_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 01, 04, PCB_Cal.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 05, PCB_Cal.OK);
            PLC_Data_Tool.Set_Bit(Data, 01, 06, PCB_L_Set_Light.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 07, PCB_Check1_Set_Light.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 08, PCB_L_MU_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 09, PCB_R_MU_Grab.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 10, PCB_L_MU_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 01, 11, PCB_R_MU_Grab.OK);
            PLC_Data_Tool.Set_Bit(Data, 01, 12, PCB_Check1_Check.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 13, PCB_Check1_Check.OK);
            PLC_Data_Tool.Set_Bit(Data, 01, 14, PCB_Check2_Check.Finish);
            PLC_Data_Tool.Set_Bit(Data, 01, 15, PCB_Check2_Check.OK);

            #endregion
            //#region PCB
            //PLC_Data_Tool.Set_Bit(Data, 01, 00, PCB_L_Set_Light.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 01, PCB_L_Grab.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 02, PCB_L_MU_Grab.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 03, PCB_R_Set_Light.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 04, PCB_R_Grab.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 05, PCB_R_MU_Grab.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 06, PCB_Cal.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 07, PCB_Check1_Check.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 08, PCB_Check2_Check.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 09, PCB_Check1_Set_Light.Finish);
            //PLC_Data_Tool.Set_Bit(Data, 01, 10, PCB_Check2_Set_Light.Finish);
   
            //#endregion

            #region Robot1
            PLC_Data_Tool.Set_Bit(Data, 02, 00, Robot1_Ready);
            PLC_Data_Tool.Set_Bit(Data, 02, 01, Robot1_Running);
            PLC_Data_Tool.Set_Bit(Data, 02, 02, Robot1_Warning);
            PLC_Data_Tool.Set_Bit(Data, 02, 03, Robot1_Error);
            PLC_Data_Tool.Set_Bit(Data, 02, 04, Robot1_S_Error);
            PLC_Data_Tool.Set_Bit(Data, 02, 05, Robot1_On_Home);
            PLC_Data_Tool.Set_Bit(Data, 02, 06, Robot1_E_Stop_On);
            PLC_Data_Tool.Set_Bit(Data, 02, 07, Robot1_Safe_Door_On);
            PLC_Data_Tool.Set_Bit(Data, 02, 08, Robot1_Loop_Run.Finish);
            PLC_Data_Tool.Set_Bit(Data, 02, 09, Robot1_Loop_Run.OK);

            for (int i = 0; i < Robot1_On_Pos_Tray_Load.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 100, 0 + i, Robot1_On_Pos_Tray_Load[i]);

            for (int i = 0; i < Robot1_On_Pos_Plasma_Load.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 101, 0 + i, Robot1_On_Pos_Plasma_Load[i]);

            for (int i = 0; i < Robot1_On_Pos_Plasma_Unload.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 102, 0 + i, Robot1_On_Pos_Plasma_Unload[i]);

            for (int i = 0; i < Robot1_On_Pos_NG.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 103, 0 + i, Robot1_On_Pos_NG[i]);

            for (int i = 0; i < Robot1_On_Pos_ACF_Load.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 104, 0 + i, Robot1_On_Pos_ACF_Load[i]);

            for (int i = 0; i < Robot1_On_Pos_ACF_Unload.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 105, 0 + i, Robot1_On_Pos_ACF_Unload[i]);

            for (int i = 0; i < Robot1_On_Pos_PCB_Load.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 106, 0 + i, Robot1_On_Pos_PCB_Load[i]);

            for (int i = 0; i < Robot1_On_Pos_PCB_Unload.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 107, 0 + i, Robot1_On_Pos_PCB_Unload[i]);

            for (int i = 0; i < Robot1_On_Pos_Teach.Length; i++)
                PLC_Data_Tool.Set_Bit(Data, 108, 0 + i, Robot1_On_Pos_Teach[i]);

            #endregion

            //#region PCB_OK
            //PLC_Data_Tool.Set_Bit(Data, 03, 00, PCB_L_Set_Light.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 01, PCB_L_Grab.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 02, PCB_L_MU_Grab.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 03, PCB_R_Set_Light.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 04, PCB_R_Grab.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 05, PCB_R_MU_Grab.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 06, PCB_Cal.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 07, PCB_Check1_Check.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 08, PCB_Check2_Check.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 09, PCB_Check1_Set_Light.OK);
            //PLC_Data_Tool.Set_Bit(Data, 03, 10, PCB_Check2_Set_Light.OK);
            //#endregion


            #endregion

            #region Word
            PLC_Data_Tool.Set_DWord(Data, 10, 3, PCB_DX);
            PLC_Data_Tool.Set_DWord(Data, 12, 3, PCB_DY);
            PLC_Data_Tool.Set_DWord(Data, 14, 3, PCB_DQ);

            #region Robot1
            PLC_Data_Tool.Set_Word(Data, 18, Robot1_Speed);
            PLC_Data_Tool.Set_Word(Data, 19, Robot1_Loop_Run_Type);
            PLC_Data_Tool.Set_Word(Data, 20, Robot1_Loop_Run_Step);
            PLC_Data_Tool.Set_Word(Data, 21, Robot1_Loop_Run_Tray_No);
            PLC_Data_Tool.Set_DWord(Data, 22,3, RB_Now_Pos_X);
            PLC_Data_Tool.Set_DWord(Data, 24,3, RB_Now_Pos_Y);
            PLC_Data_Tool.Set_DWord(Data, 26,3, RB_Now_Pos_Q);//Z
            PLC_Data_Tool.Set_DWord(Data, 28, 3, RB_Now_Pos_U);
            PLC_Data_Tool.Set_DWord(Data, 30, 3, RB_Now_Pos_V);
            PLC_Data_Tool.Set_DWord(Data, 32, 3, RB_Now_Pos_W);
            PLC_Data_Tool.Set_DWord(Data, 110, RB_Type);
            PLC_Data_Tool.Set_DWord(Data, 112, RB_Step);


            #endregion

            for (int i = 0; i < Bond_DXYQ.Length; i++)
            {
                PLC_Data_Tool.Set_DWord(Data, 40 + i * 6 + 00, 3, Bond_DXYQ[i].DX);
                PLC_Data_Tool.Set_DWord(Data, 40 + i * 6 + 02, 3, Bond_DXYQ[i].DY);
                PLC_Data_Tool.Set_DWord(Data, 40 + i * 6 + 04, 3, Bond_DXYQ[i].DQ);
            }
            #endregion
        }
        public void View_Data(string filename)
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, filename);
            form.ShowDialog();
        }
    }
    
    public class TPLC_CMD_Data
    {
        public bool Running;
        public bool Finish;
        public bool OK;
    }
    public class TPLC_Out_DXYQ
    {
        public double DX;
        public double DY;
        public double DQ;
    }
    //-----------------------------------------------------------------------------------------------------
    /// TPLC_Data_Recipe
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Data_Recipe : TPLC_Base_Data
    {
        public int Recipe_Code;
        public string Recipe_Name;

        //public double Tray_Start_X;
        //public double Tray_Start_Y;
        public double Tray_Pitch_X;
        public double Tray_Pitch_Y;
        public int Tray_Num_X;
        public int Tray_Num_Y;

        public double Robot_X;
        public double Robot_Y;
        public double Robot_Q;

        public double Plasma_Clean_Speed;
        public int Plasma_Clean_Count;
        
        public int Robot_Home_Start_no;
        public int Robot_Tray_Start_no;
        public int Robot_Plasma_Load_Start_no;
        public int Robot_Plasma_Unload_Start_no;
        public int Robot_Teach_Start_no;


        public int Robot_ACF_Load_Start_no;
        public int Robot_ACF_Unload_Start_no;
        

        public int Robot_PCB_Load_Start_no;
        public int Robot_PCB_Unload_Start_no;
        public int Robot_NG_Start_no;

        public double ACF_Time;
        public double[] ACF_Pressure = new double[3];
        public double[] ACF_Up_Temp = new double[1];
        public double[] ACF_Dn_Temp = new double[1];
        public int ACF_Pos_Count = 0;
        public double ACF_Length = 0;


        public TPLC_Data_ACF_Grab_Pos[] ACF_Pos_List = new TPLC_Data_ACF_Grab_Pos[10];
        public TPLC_MS_Param MS_Param = new TPLC_MS_Param();

        public TPLC_Data_Recipe()
        {
            for (int i = 0; i < ACF_Pos_List.Length; i++) ACF_Pos_List[i] = new TPLC_Data_ACF_Grab_Pos();
        }
        public bool Write(TMelsec_QPLC_Eth_Connect plc)
        {
            bool result = false;

            Update();
            if (plc.Connect)
            {
                result = plc.Write_Byte(Start_Code, Data, Count);
            }
            return result;
        }
        override public void Update()
        {
            int start_no = 0;
            int tmp_no = 0;

            PLC_Data_Tool.Set_DWord(Data, 0, Recipe_Code);
            PLC_Data_Tool.Set_String(Data, 2, 18, Recipe_Name);

            PLC_Data_Tool.Set_Word(Data, 20, 0, ACF_Up_Temp[0]);
            PLC_Data_Tool.Set_Word(Data, 21, 0, ACF_Dn_Temp[0]);
            PLC_Data_Tool.Set_Word(Data, 22, 0, ACF_Pressure[0]);
            PLC_Data_Tool.Set_Word(Data, 23, 1, ACF_Time);
            PLC_Data_Tool.Set_Word(Data, 27, ACF_Pos_Count);
            PLC_Data_Tool.Set_DWord(Data, 28, 3, ACF_Length);

            PLC_Data_Tool.Set_DWord(Data, 30, 3, Plasma_Clean_Speed);
            PLC_Data_Tool.Set_DWord(Data, 32, Plasma_Clean_Count);

            PLC_Data_Tool.Set_DWord(Data, 40, Tray_Num_X);
            PLC_Data_Tool.Set_DWord(Data, 42, Tray_Num_Y);
            PLC_Data_Tool.Set_DWord(Data, 44, 3, Tray_Pitch_X);
            PLC_Data_Tool.Set_DWord(Data, 46, 3, Tray_Pitch_Y);

            PLC_Data_Tool.Set_DWord(Data, 50, 3, Robot_X);
            PLC_Data_Tool.Set_DWord(Data, 52, 3, Robot_Y);
            PLC_Data_Tool.Set_DWord(Data, 54, 3, Robot_Q);

            PLC_Data_Tool.Set_DWord(Data, 56, 3, Robot_Home_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 58, 3, Robot_Plasma_Load_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 60, 3, Robot_Plasma_Unload_Start_no);

            PLC_Data_Tool.Set_DWord(Data, 62, 3, Robot_ACF_Load_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 64, 3, Robot_ACF_Unload_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 66, 3, Robot_PCB_Load_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 68, 3, Robot_PCB_Unload_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 70, 3, Robot_NG_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 72, 3, Robot_Tray_Start_no);
            PLC_Data_Tool.Set_DWord(Data, 74, 3, Robot_Teach_Start_no);
            start_no = 100;

            for (int i = 0; i < ACF_Pos_List.Length; i++)
            {
                PLC_Data_Tool.Set_DWord(Data, start_no + i * 20 + 00, 3, ACF_Pos_List[i].Bond_X);
                PLC_Data_Tool.Set_DWord(Data, start_no + i * 20 + 02, 3, ACF_Pos_List[i].Bond_Y);
                PLC_Data_Tool.Set_DWord(Data, start_no + i * 20 + 04, 3, ACF_Pos_List[i].Bond_Q);
                PLC_Data_Tool.Set_DWord(Data, start_no + i * 20 + 06, 3, ACF_Pos_List[i].Check_X);
                PLC_Data_Tool.Set_DWord(Data, start_no + i * 20 + 08, 3, ACF_Pos_List[i].Check_Y);
                PLC_Data_Tool.Set_DWord(Data, start_no + i * 20 + 10, 3, ACF_Pos_List[i].Check_Q);
            }
            //PLC_Data_Tool.Set_Word(Data, 34, 3, ACF_Table_Z_IN);
            //PLC_Data_Tool.Set_Word(Data, 36, 3, ACF_Table_X_IN);
            //PLC_Data_Tool.Set_Word(Data, 38, 3, ACF_Table_Q_IN);


            //PLC_Data_Tool.Set_Word(Data, 46, 3, ACF_Table_Z_OUT);
            //PLC_Data_Tool.Set_Word(Data, 48, 3, ACF_Table_X_OUT);
            //PLC_Data_Tool.Set_Word(Data, 50, 3, ACF_Table_Q_OUT);

            //PLC_Data_Tool.Set_Word(Data, 46, 3, ACF_Table_Z_OUT);
            //PLC_Data_Tool.Set_Word(Data, 48, 3, ACF_Table_X_OUT);
            //PLC_Data_Tool.Set_Word(Data, 50, 3, ACF_Table_Q_OUT);
            //PLC_Data_Tool.Set_Word(Data, 46, 3, ACF_Table_Z_OUT);
            //PLC_Data_Tool.Set_Word(Data, 48, 3, ACF_Table_X_OUT);
            //PLC_Data_Tool.Set_Word(Data, 50, 3, ACF_Table_Q_OUT);


            //ACF載台入料位置
            //PLC_Data_Tool.Set_DWord(Data, 22, 3, ACF.ACF_Stage_Loader.X);
            //PLC_Data_Tool.Set_DWord(Data, 20, 3, ACF.ACF_Stage_Loader.Z);
            //PLC_Data_Tool.Set_DWord(Data, 24, 3, ACF.ACF_Stage_Loader.Q);

            //CF載台出料位置
            //PLC_Data_Tool.Set_DWord(Data, 34, 3, ACF.ACF_Stage_Unloader.X);
            //PLC_Data_Tool.Set_DWord(Data, 32, 3, ACF.ACF_Stage_Unloader.Z);
            //PLC_Data_Tool.Set_DWord(Data, 36, 3, ACF.ACF_Stage_Unloader.Q);

            //ACF載台取像位置
            //PLC_Data_Tool.Set_DWord(Data, 46, 3, ACF.ACF_Stage_Grab.X);
            //PLC_Data_Tool.Set_DWord(Data, 48, 3, ACF.ACF_Stage_Grab.Y);
            //PLC_Data_Tool.Set_DWord(Data, 44, 3, ACF.ACF_Stage_Grab.Z);
            //PLC_Data_Tool.Set_DWord(Data, 50, 3, ACF.ACF_Stage_Grab.Q);
            //PLC_Data_Tool.Set_DWord(Data, 52, 3, ACF.ACF_Stage_Grab.CCDX);

            #region ACF載台壓合參數&位置
            //PLC_Data_Tool.Set_Word(Data, 7, ACF.ACF_Banding_Num);
            ////PLC_Data_Tool.Set_DWord(Data, 16, 3, ACF.ACF_Stick_Length);
            //PLC_Data_Tool.Set_DWord(Data, 18, 3, ACF.ACF_Cut_Distance);

            //PLC_Data_Tool.Set_DWord(Data, 58, 3, ACF.ACF_Stage_Banding[0].Z);

            //for (int i = 0; i < Define.DACFMAXSTICKCOUNT; i++)
            //{
            //    PLC_Data_Tool.Set_DWord(Data, 60 + (i * 2), 3, ACF.ACF_Stage_Banding[i].X);
            //    PLC_Data_Tool.Set_DWord(Data, 100 + (i * 2), 3, ACF.ACF_Stage_Banding[i].Y);
            //    PLC_Data_Tool.Set_DWord(Data, 140 + (i * 2), 3, ACF.ACF_Stage_Banding[i].Q);
            //    PLC_Data_Tool.Set_DWord(Data, 350 + (i * 2), 3, ACF.ACF_Stick_Length[i]);
            //}
            #endregion

            #region ACF載台檢查位置
            //PLC_Data_Tool.Set_DWord(Data, 180, 3, ACF.Check_Data_L.ACF_Check_Pos[0].Z);

            //for (int i = 0; i < Define.DACFMAXSTICKCOUNT; i++)
            //{
            //    PLC_Data_Tool.Set_DWord(Data, 182 + (i * 2), 3, ACF.Check_Data_L.ACF_Check_Pos[i].X);
            //    PLC_Data_Tool.Set_DWord(Data, 222 + (i * 2), 3, ACF.Check_Data_L.ACF_Check_Pos[i].Y);
            //    PLC_Data_Tool.Set_DWord(Data, 262 + (i * 2), 3, ACF.Check_Data_L.ACF_Check_Pos[i].Q);
            //    PLC_Data_Tool.Set_DWord(Data, 302 + (i * 2), 3, ACF.Check_Data_L.ACF_Check_Pos[i].CCDX);
            //}
            #endregion

            #region Tray參數
            //PLC_Data_Tool.Set_DWord(Data, 0, LD.Tray_Num_X);
            //PLC_Data_Tool.Set_DWord(Data, 2, LD.Tray_Num_Y);
            //PLC_Data_Tool.Set_DWord(Data, 4, 3, LD.Tray_Picth_X);
            //PLC_Data_Tool.Set_DWord(Data, 6, 3, LD.Tray_Picth_Y);
            #endregion

            #region Robot參數
            //PLC_Data_Tool.Set_DWord(Data, 10, 3, LD.Robot_Tray_LD_Pos.X);
            //PLC_Data_Tool.Set_DWord(Data, 12, 3, LD.Robot_Tray_LD_Pos.Y);
            //PLC_Data_Tool.Set_DWord(Data, 14, 3, LD.Robot_Tray_LD_Pos.Q);
            #endregion
            
            #region MS_Param
            start_no = 500;
            for (int i = 0; i < MS_Param.Axis.Length; i++)
            {
                for (int j = 0; j < MS_Param.Axis[i].Pos.Length; j++)
                {
                    tmp_no = start_no + i * 20 + j * 2;
                    PLC_Data_Tool.Set_DWord(Data, tmp_no, 3, MS_Param.Axis[i].Pos[j]);
                }
            }
            #endregion
        }
        public void View_Data(string filename)
        {
            TForm_Data_View form = new TForm_Data_View();
            form.Set_Param(this, filename);
            form.ShowDialog();
        }
    }
    public class TPLC_Data_ACF_Grab_Pos
    {
        public double Bond_X;
        public double Bond_Y;
        public double Bond_Q;
        public double Check_X;
        public double Check_Y;
        public double Check_Q;
    }

    //-----------------------------------------------------------------------------------------------------
    // TPLC_Data_MS_Param
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_MS_Param
    {
        public TPLC_MS_Param_Axis_Pos[] Axis = new TPLC_MS_Param_Axis_Pos[20];

        public TPLC_MS_Param()
        {
            for (int i = 0; i < Axis.Length; i++) Axis[i] = new TPLC_MS_Param_Axis_Pos();
        }
    }

    public class TPLC_MS_Param_Axis_Pos 
    {
        public int Dot_Num = 3;
        public double[] Pos = new double[10];

        public TPLC_MS_Param_Axis_Pos()
        {

        }
    }

}