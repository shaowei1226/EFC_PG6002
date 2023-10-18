using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCAPINet;
using EFC.Tool;
using EFC.INI;


namespace EFC.Robot.Epson
{
    //-----------------------------------------------------------------------------------------------------
    // Epson_Robot_Tool
    //-----------------------------------------------------------------------------------------------------
    static public class Epson_Robot_Tool
    {
        static public double D_X(SpelPoint p1, SpelPoint p2)
        {
            double result = 0;

            result = p1.X - p2.X;
            return result;
        }
        static public double D_Y(SpelPoint p1, SpelPoint p2)
        {
            double result = 0;

            result = p1.Y - p2.Y;
            return result;
        }
        static public double D_Z(SpelPoint p1, SpelPoint p2)
        {
            double result = 0;

            result = p1.Z - p2.Z;
            return result;
        }
        static public double D_U(SpelPoint p1, SpelPoint p2)
        {
            double result = 0;

            result = p1.U - p2.U;
            if (result <= -180) result = result + 360;
            if (result >= 180) result = result - 360;
            return result;
        }
        static public double D_V(SpelPoint p1, SpelPoint p2)
        {
            double result = 0;

            result = p1.V - p2.V;
            if (result <= -180) result = result + 360;
            if (result >= 180) result = result - 360;
            return result;
        }
        static public double D_W(SpelPoint p1, SpelPoint p2)
        {
            double result = 0;

            result = p1.W - p2.W;
            if (result <= -180) result = result + 360;
            if (result >= 180) result = result - 360;
            return result;
        }
        static public void D_XYZ(SpelPoint p1, SpelPoint p2, out double dx, out double dy, out double dz)
        {
            dx = D_X(p1, p2);
            dy = D_Y(p1, p2);
            dz = D_Z(p1, p2);
        }
        static public void D_XYZUVW(SpelPoint p1, SpelPoint p2, out double dx, out double dy, out double dz, out double du, out double dv, out double dw)
        {
            dx = D_X(p1, p2);
            dy = D_Y(p1, p2);
            dz = D_Z(p1, p2);
            du = D_U(p1, p2);
            dv = D_V(p1, p2);
            dw = D_W(p1, p2);
        }

        static public bool Equal(TEFC_SpelPoint p1, TEFC_SpelPoint p2, double ofs = 0.001)
        {
            bool result = false;

            result = Equal(p1, p2, ofs, ofs, ofs, ofs, ofs, ofs);
            return result;
        }
        static public bool Equal(TEFC_SpelPoint p1, TEFC_SpelPoint p2, double ofs_x, double ofs_y, double ofs_z)
        {
            bool result = false;
            double dx = 0, dy = 0, dz = 0;

            D_XYZ(p1.SPoint, p2.SPoint, out  dx, out dy, out dz);
            if (Equal(dx, ofs_x) && Equal(dy, ofs_y) && Equal(dz, ofs_z))
                result = true;

            return result;
        }
        static public bool Equal(TEFC_SpelPoint p1, TEFC_SpelPoint p2, double ofs_x, double ofs_y, double ofs_z, double ofs_u, double ofs_v, double ofs_w)
        {
            bool result = false;
            double dx = 0, dy = 0, dz = 0, du = 0, dv = 0, dw = 0;

            D_XYZUVW(p1.SPoint, p2.SPoint, out  dx, out dy, out dz, out du, out dv, out dw);
            if (Equal(dx, ofs_x) && Equal(dy, ofs_y) && Equal(dz, ofs_z) && Equal(du, ofs_u) && Equal(dv, ofs_v) && Equal(dw, ofs_w))
                result = true;

            return result;
        }
        static public bool Equal(double value1, double value2, double ofs = 0.001)
        {
            bool result = false;
            double d_value;

            d_value = value2 - value1;
            result = Equal(d_value, ofs);
            return result;
        }
        static public bool Equal_Angle(double value1, double value2, double ofs = 0.001)
        {
            bool result = false;
            double d_value;

            d_value = value2 - value1;
            if (d_value <= -180) d_value = d_value + 360;
            if (d_value >= 180) d_value = d_value - 360;
            result = Equal(d_value, ofs);
            return result;
        }
        static public bool Equal(double d_value, double ofs = 0.001)
        {
            bool result = false;

            if (d_value >= -ofs && d_value <= ofs) result = true; return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // Epson_Robot
    //-----------------------------------------------------------------------------------------------------
    public class TEpson_Robot
    {
        #region 參數
        public TEFC_Spel M_Spel = null;
        public SpelConnectionInfo[] Connection_Infos = null;
        protected SpelConnectionInfo inConnection_Info = new SpelConnectionInfo();
        protected SpelControllerInfo inController_Info = new SpelControllerInfo();
        protected bool inConnected = false;
        protected TLog inLog = null;
        public string Log_Source = "Epson_Robot";
        protected string inProject_Name = "";
        protected bool Init_Flag = false;
        public TEFC_SpelPoint Now_Pos = new TEFC_SpelPoint();
        public SpelRobotPosType Robot_Word = SpelRobotPosType.World;
        public int Robot_Arm = 0;
        public int Robot_Tool = 0;
        public int Robot_Local =0 ;
        public TRobot_Program_Base Program = null;
        public System.Timers.Timer Read_Timer = new System.Timers.Timer();


        public TLog Log
        {
            get
            {
                return inLog;
            }
            set
            {
                inLog = value;
                M_Spel.Log = inLog;
            }
        }
        public bool Connected
        {
            get
            {
                return inConnected;
            }
        }
        public int ServerInstance
        {
            get
            {
                return M_Spel.ServerInstance;
            }
            set
            {
                M_Spel.ServerInstance = value;
            }
        }


        public int ErrorCode
        {
            get
            {
                int result = 0;

                if(Connected) result = M_Spel.ErrorCode;
                return result;
            }
        }
        public bool Error_On
        {
            get
            {
                bool result = false;

                if (Connected) result = M_Spel.ErrorOn;
                return result;
            }
        }
        public bool EStop_On
        {
            get
            {
                bool result = false;

                if (Connected) result = M_Spel.EStopOn;
                return result;
            }
        }
        public bool Safety_On
        {
            get
            {
                bool result = false;

                if (Connected) result = M_Spel.SafetyOn;
                return result;
            }
        }
        public bool Motors_On
        {
            get
            {
                bool result = false;

                if (Connected) result = M_Spel.MotorsOn;
                return result;
            }
            set
            {
                if (Connected) M_Spel.MotorsOn = value;
            }
        }
        public bool Power_High
        {
            get
            {
                bool result = false;

                if (Connected) result = M_Spel.PowerHigh;
                return result;
            }
            set
            {
                if (Connected) M_Spel.PowerHigh = value;
            }
        }
        public bool Program_Running
        {
            get
            {
                bool result = false;
                if (Program != null)result = Program.Program_Running;
                return result;
            }
        }
        public int Program_Speed_Factor
        {
            get
            {
                int result = 0;
                if (Program != null) result = Program.Program_Speed_Factor;
                return result;
            }
        }
        public int Warning_Code
        {
            get
            {
                int result = 0;

                if (Connected) result = M_Spel.WarningCode;
                return result;
            }
        }
        public bool Warning_On
        {
            get
            {
                bool result = false;

                if (Connected) result = M_Spel.WarningOn;
                return result;
            }
        }
        public SpelConnectionInfo Connection_Info
        {
            get
            {
                return inConnection_Info;
            }
        }
        #endregion

        #region Main
        public TEpson_Robot(int no)
        {
            M_Spel = new TEFC_Spel();
            M_Spel.Robot = no;
            M_Spel.ServerInstance = no;
            Read_Timer.Interval = 500;
            Read_Timer.Elapsed += On_Get_Now_Pos;
            Read_Timer.Enabled = true;
        }
        public void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
        {
            if (inLog != null) inLog.Add(Log_Source, fun, msg, type);
        }
        public void Dispose()
        {
            if (Program_Running) Program_Stop();
            Disconnect();
            M_Spel.Dispose();
        }
        public void Init()
        {
            string fun = "Init";
            if(!Init_Flag)
            {
                try
                {
                    M_Spel.Initialize();
                    Init_Flag = true;
                }
                catch (Exception ex)
                {
                    Log_Add(fun, ex.Message, emLog_Type.Error);
                }
            }
        }
        public void On_Get_Now_Pos(object sender, EventArgs e)
        {
            Read_Timer.Enabled = false;
            if (Connected)
            {
                Now_Pos.Set(Get_Point_Here());
            }

            Read_Timer.Enabled = true;
        }
        public bool Connect_Project_Name(string project_name)
        {
            bool result = false;
            string fun = "Connect_Project_Name";

            Log_Add(fun, string.Format("Connect_Project_Name Name={0:s}", project_name));
            if (System.IO.File.Exists(project_name))
            {
                result = M_Spel.Set_Project_Name(project_name);
                if (result) inConnected = true;
            }
            else
            {
                Log_Add(fun, string.Format("專案檔找不到."), emLog_Type.Error);
            }
            return result;
        }
        public bool Connect_No(int connect_no)
        {
            bool result = false;
            string fun = "Connect_No";

            Log_Add(fun, string.Format("Connect_No No={0:d}", connect_no));
            result = Connect_Info(connect_no);
            return result;
        }
        public bool Connect_Name(string connect_name)
        {
            bool result = false;
            string fun = "Connect_Name";

            Log_Add(fun, string.Format("Connect_Name Name={0:s}", connect_name));
            result = Connect_Info(Get_Connection_Info(connect_name));
            return result;
        }
        public void Disconnect()
        {
            string fun = "Disconnect";

            Log_Add(fun, string.Format("Disconnect."));
            if (Connected)
            {
                M_Spel.Disconnect();
                inConnection_Info = null;
                inConnected = false;
            }
        }
        public void Reset_Abort()
        {
            string fun = "Reset_Abort";

            Log_Add(fun, string.Format("Reset_Abort."));
            M_Spel.ResetAbort();
            //if (Program != null)
            //{
            //    //Program.Program_Speed_Factor = 1;
            //    //Program.Robot_Speed = 1;
            //}
        }
        public void Program_Start()
        {
            string fun = "Program_Start";

            if (Program != null)
            {
               // Log_Add(fun, string.Format("Program_Start."));
                Program.Program_Start();
            }
        }
        public void Program_Stop()
        {
            string fun = "Program_Stop";

            if (Program != null)
            {
                Log_Add(fun, string.Format("Program_Stop."));
                Program.Program_Stop();
            }
        }
        public void Stop()
        {
            string fun = "Stop";

            Log_Add(fun, string.Format("Stop."));
            M_Spel.Stop();
        }
        public void Go(int no)
        {
            string fun = "Go";

            Log_Add(fun, string.Format("Go. No={0:d}", no));
            M_Spel.Go(no);
        }
        public void Go(TEFC_SpelPoint pos)
        {
            string fun = "Go";

            Log_Add(fun, string.Format("Go. pos={0:s}", pos.ToString()));
            M_Spel.Go(pos.SPoint);
        }
        public void Move(int no)
        {
            string fun = "Move";

            Log_Add(fun, string.Format("Move. No={0:d}", no));
            M_Spel.Move(no);
        }
        public void Move(TEFC_SpelPoint pos)
        {
            string fun = "Move";

            Log_Add(fun, string.Format("Move. pos={0:s}", pos.ToString()));
            M_Spel.Move(pos.SPoint);
        }
        public void Save_Points(string file_name = "Robot1.pts")
        {
            string fun = "Save_Points";

            Log_Add(fun, string.Format("Save_Points File_Name={0:s}", file_name));
            M_Spel.SavePoints(file_name);
        }
        #endregion

        #region Get
        public TEFC_SpelPoint Get_Point(int no)
        {
            TEFC_SpelPoint result = null;
            SpelPoint tmp_point = null;
            string fun = "Get_Point";


            Log_Add(fun, string.Format("Get_Point. No={0:d}", no));
            tmp_point = M_Spel.GetPoint(no);
            if (tmp_point != null)
            {
                result = new TEFC_SpelPoint();
                result.Set_Data(tmp_point);
            }
            return result;
        }
        public TEFC_SpelPoint Get_Point(string point_name)
        {
            TEFC_SpelPoint result = null;
            SpelPoint tmp_point = new SpelPoint();
            string fun = "Get_Point";


            Log_Add(fun, string.Format("Get_Point. Point_Name={0:s}", point_name));
            tmp_point = M_Spel.GetPoint(point_name);
            if (tmp_point != null)
            {
                result = new TEFC_SpelPoint();
                result.Set_Data(tmp_point);
            }
            return result;
        }

        public TEFC_SpelPoint Get_Point_Here()
        {
            // 取得Robot現在位置
            TEFC_SpelPoint result = null;
            float[] get_pos = null;

            get_pos = M_Spel.GetRobotPos(Robot_Word, Robot_Arm, Robot_Tool, Robot_Local);
            if (get_pos != null)
            {
                result = new TEFC_SpelPoint();
                result.Set_Data(get_pos);
                result.Local = Robot_Local;
            }
            return result;
        }

        public bool Get_Value_Bool(string value_name)
        {
            bool result = false;
            string fun = "Get_Value_Bool";
            object tmp_value = null;

            Log_Add(fun, string.Format("Get_Value_Bool Name={0:s}", value_name));
            tmp_value = Get_Value(value_name);
            if (tmp_value != null)
            {
                try
                {
                    result = (bool)result;
                }
                catch(Exception ex)
                {
                    Log_Add(fun, ex.Message, emLog_Type.Error);
                };
            }
            return result;
        }
        public int Get_Value_Int(string value_name)
        {
            int result = 0;
            string fun = "Get_Value_Int";
            object tmp_value = null;

            Log_Add(fun, string.Format("Get_Value_Int Name={0:s}", value_name));
            tmp_value = Get_Value(value_name);
            if (tmp_value != null)
            {
                try
                {
                    result = (int)result;
                }
                catch (Exception ex)
                {
                    Log_Add(fun, ex.Message, emLog_Type.Error);
                };
            }

            return result;
        }
        public double Get_Value_Double(string value_name)
        {
            double result = 0.0;
            string fun = "Get_Value_Double";
            object tmp_value = null;

            Log_Add(fun, string.Format("Get_Value_Double Name={0:s}", value_name));
            tmp_value = Get_Value(value_name);
            if (tmp_value != null)
            {
                try
                {
                    result = (double)result;
                }
                catch (Exception ex)
                {
                    Log_Add(fun, ex.Message, emLog_Type.Error);
                };
            }

            return result;
        }
        public string Get_Value_String(string value_name)
        {
            string result = "";
            string fun = "Get_Value_String";
            object tmp_value = null;

            Log_Add(fun, string.Format("Get_Value_String Name={0:s}", value_name));
            tmp_value = Get_Value(value_name);
            if (tmp_value != null)
            {
                try
                {
                    result = (string)result;
                }
                catch (Exception ex)
                {
                    Log_Add(fun, ex.Message, emLog_Type.Error);
                };
            }

            return result;
        }
        #endregion

        #region Set

        /// <summary>
        /// 設定整體運轉百分比(1~100%)
        /// </summary>
        /// <param name="speed">(1～100)(單位：%)</param>
        public void Set_Speed_Factor(double speed)
        {
            string fun = "Set_Speed_Factor";

            if (speed < 1) speed = 1;
            if (speed > 100) speed = 100;
            if (speed >= 1 && speed <= 100)
            {
                Log_Add(fun, string.Format("Set_Speed_Factor Speed={0:f0}", speed));
                M_Spel.Set_Speed_Factor((int)speed);
            }
        }

        /// <summary>
        /// 用於設置 Go、Jump、Pulse 命令等的 PTP 動作速度
        /// </summary>
        /// <param name="speed">(1～100)(單位：%)</param>
        public void Set_Speed(double speed)
        {
            string fun = "Set_Speed";

            if (speed >= 1 && speed <= 100)
            {
                Log_Add(fun, string.Format("Set_Speed Speed={0:f0}", speed));
                M_Spel.Set_Speed((int)speed);
            }
        }

        /// <summary>
        /// 圓弧速度,該命令僅在利用 Move、Arc、Arc3、BMove、TMove、Jump3CP
        /// </summary>
        /// <param name="speed">(0.1～1000)(單位：deg/sec)</param>
        public void Set_SpeedR(double speed)
        {
            string fun = "Set_SpeedR";

            if (speed >= 0.1 && speed <= 1000)
            {
                Log_Add(fun, string.Format("Set_SpeedR Speed={0:f0}", speed));
                M_Spel.Set_SpeedR((int)speed);
            }
        }

        /// <summary>
        /// 直線速度,適用CP(Move, Arc, Jump3, Jump3CP)
        /// </summary>
        /// <param name="speed">(0.1～2000)(單位：mm/sec)</param>
        public void Set_SpeedS(double speed)
        {
            string fun = "Set_SpeedS";

            if (speed >= 0.1 && speed <= 2000)
            {
                Log_Add(fun, string.Format("Set_SpeedS Speed={0:f1}", speed));
                M_Spel.Set_SpeedS((float)speed);
            }
        }

        /// <summary>
        /// 用於設置 Go、Jump、Pulse 命令等的 PTP 動作加速度
        /// </summary>
        /// <param name="accel">(1～100)(單位：%)</param>
        /// <param name="decel">(1～100)(單位：%)</param>
        public void Set_Accel(int accel, int decel)
        {
            string fun = "Set_Accel";

            if (accel >= 1 && accel <= 100 && decel >= 1 && decel <= 100)
            {
                Log_Add(fun, string.Format("Set_Accel Acc={0:d}, Dec={1:d}", accel, decel));
                M_Spel.Set_Accel(accel, decel);
            }
        }

        /// <summary>
        /// 用於設置 CP 動作時工具姿勢變化的加減速度
        /// 僅在 Move、Arc、Arc3、BMove、TMove、Jump3CP使用 ROT 修飾參數時有效
        /// </summary>
        /// <param name="accel">(0.1 - 5000)(單位：deg/sec2)</param>
        /// <param name="decel">(0.1 - 5000)(單位：deg/sec2)</param>
        public void Set_Accel_R(double accel, double decel)
        {
            string fun = "Set_Accel_R";

            if (accel >= 0.1 && accel <= 5000 && decel >= 0.1 && decel <= 5000)
            {
                Log_Add(fun, string.Format("Set_Accel_R Acc={0:f1}, Dec={1:f1}", accel, decel));
                M_Spel.Set_AccelR((float)accel, (float)decel);
            }
        }

        /// <summary>
        /// 用於設置機器人的直線動作和 CP 動作的加減速度
        /// Move、Arc、Arc3、Jump3
        /// </summary>
        /// <param name="accel">(0.1 - 25000)(單位：mm/sec2)</param>
        /// <param name="decel">(0.1 - 25000)(單位：mm/sec2)</param>
        public void Set_Accel_S(double accel, double decel)
        {
            string fun = "Set_Accel_S";

            if (accel >= 0.1 && accel <= 25000 && decel >= 0.1 && decel <= 25000)
            {
                Log_Add(fun, string.Format("Set_Accel_S Acc={0:f1}, Dec={1:f1}", accel, decel));
                M_Spel.Set_AccelS((float)accel, (float)decel);
            }
        }

        public void Set_Point(TEFC_SpelPoint point)
        {
            string fun = "Set_Point";

            Log_Add(fun, string.Format("Set_Point Lable={0:s} Pos={1:s}", point.Label, point.ToString()));
            M_Spel.SetPoint(point.No, point.SPoint);
            M_Spel.Set_Label(point.No, point.Label);
        }
       
        public void Set_Value_Bool(string value_name, bool value)
        {
            string fun = "Set_Value_Bool";

            Log_Add(fun, string.Format("Set_Value_Bool Name={0:s} Value={1:s}", value_name, value.ToString()));
            Set_Value(value_name, value);
        }
        public void Set_Value_Int(string value_name, int value)
        {
            string fun = "Set_Value_Int";

            Log_Add(fun, string.Format("Set_Value_Int Name={0:s} Value={1:d}", value_name, value));
            Set_Value(value_name, value);
        }
        public void Set_Value_Double(string value_name, double value)
        {
            string fun = "Set_Value_Double";

            Log_Add(fun, string.Format("Set_Value_Double Name={0:s} Value={1:f3}", value_name, value));
            Set_Value(value_name, value);
        }
        public void Set_Value_String(string value_name, string value)
        {
            string fun = "Set_Value_String";

            Log_Add(fun, string.Format("Set_Value_String Name={0:s} Value={1:s}", value_name, value));
            Set_Value(value_name, value);
        }
        #endregion

        #region Dialog
        public void Show_Dialog_Robot_Manager(System.Windows.Forms.Form form = null)
        {
            string fun = "Show_Form_Robot_Manager";

            Log_Add(fun, string.Format("Show_Dialog_Robot_Manager"));
            if (form != null)
                M_Spel.RunDialog(SpelDialogs.RobotManager, form);
            else
                M_Spel.RunDialog(SpelDialogs.RobotManager);
        }
        public void Show_Dialog_Controller_Tools(System.Windows.Forms.Form form = null)
        {
            string fun = "Show_Dialog_Controller_Tools";

            Log_Add(fun, string.Format("Show_Dialog_Controller_Tools"));
            if (form != null)
                M_Spel.RunDialog(SpelDialogs.ControllerTools, form);
            else
                M_Spel.RunDialog(SpelDialogs.ControllerTools);
        }
        public void Show_Dialog_Program_Mode()
        {
            string fun = "Show_Form_Program_Mode";

            Log_Add(fun, string.Format("Show_Form_Program_Mode"));
            M_Spel.Set_OperationMode(SpelOperationMode.Program);
        }
        public void Show_Dialog_Teach_Point()
        {
            string fun = "Show_Form_Teach_Point";
            try
            {
                M_Spel.TeachPoint("robot1.pts", 1, "Teach Pick Position");
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Show_Window_IO_Monitor(System.Windows.Forms.Form form = null)
        {
            string fun = "Show_Form_IO_Monitor";
            try
            {
                if (form != null)
                    M_Spel.ShowWindow(SpelWindows.IOMonitor, form);
                else
                    M_Spel.ShowWindow(SpelWindows.IOMonitor);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Show_Window_Task_Manager(System.Windows.Forms.Form form = null)
        {
            string fun = "Show_Form_Task_Manager";
            try
            {
                if (form != null)
                    M_Spel.ShowWindow(SpelWindows.TaskManager, form);
                else
                    M_Spel.ShowWindow(SpelWindows.TaskManager);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Show_Window_Simulator(System.Windows.Forms.Form form = null)
        {
            string fun = "Show_Form_Simulator";
            try
            {
                if (form != null)
                    M_Spel.ShowWindow(SpelWindows.Simulator, form);
                else
                    M_Spel.ShowWindow(SpelWindows.Simulator);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region private
        private object Get_Value(string value_name)
        {
            object result = null;

            result = M_Spel.GetVar(value_name);
            return result;
        }
        private void Set_Value(string value_name, object value)
        {
            M_Spel.SetVar(value_name, value);
        }
        private bool Connect_Info(SpelConnectionInfo connect_info)
        {
            bool result = false;

            Init();
            if (!inConnected && connect_info != null)
            {
                result = M_Spel.Connect(connect_info.ConnectionNumber);
                if (result)
                {
                    //連線成功
                    inConnection_Info = connect_info;
                    //inConnected = true;
                }
            }
            return result;
        }
        private bool Connect_Info(int no)
        {
            bool result = false;

            Init();
            if (!inConnected)
            {
                result = M_Spel.Connect(no);
                if (result)
                {
                    //連線成功
                    //inConnected = true;
                }
            }
            return result;
        }

        private SpelConnectionInfo[] Get_Connection_Info()
        {
            SpelConnectionInfo[] result = null;
            string fun = "Get_Connection_Info";

            try
            {
                result = M_Spel.GetConnectionInfo();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        private SpelConnectionInfo Get_Connection_Info(int no)
        {
            SpelConnectionInfo result = null;

            if (Connection_Infos == null) Connection_Infos = Get_Connection_Info();
            if (Connection_Infos != null)
            {
                for (int i = 0; i < Connection_Infos.Length; i++)
                {
                    if (no == Connection_Infos[i].ConnectionNumber)
                    {
                        result = Connection_Infos[i];
                        break;
                    }
                }
            }
            return result;
        }
        private SpelConnectionInfo Get_Connection_Info(string cnt_name)
        {
            SpelConnectionInfo result = null;

            if (Connection_Infos == null) Connection_Infos = Get_Connection_Info();
            if (Connection_Infos != null)
            {
                for (int i = 0; i < Connection_Infos.Length; i++)
                {
                    if (cnt_name == Connection_Infos[i].ConnectionName)
                    {
                        result = Connection_Infos[i];
                        break;
                    }
                }
            }
            return result;
        }

        private SpelControllerInfo Get_Controller_Info()
        {
            SpelControllerInfo result = null;

            string fun = "Get_Controller_Info";

            try
            {
                result = M_Spel.GetControllerInfo();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

    }

    //-----------------------------------------------------------------------------------------------------
    // TRobot_Program_Base
    //-----------------------------------------------------------------------------------------------------
    abstract public class TRobot_Program_Base
    {
        #region 參數
        public TEpson_Robot Robot = null;
        public string Log_Source = "TRobot_Program_Base";
        public int Robot_Speed = 25;                   // 移動速度%,(1～100)(單位：%)
        public double Program_Speed = 100;            // PTP速度,(1～100)(單位：%)
        public double Program_Speed_R = 500.0;        // 圓弧速度,(0.1～1000)(單位：deg/sec)
        public double Program_Speed_S = 1000.0;        // 直線速度,(0.1～2000)(單位：mm/sec)
        public int Program_Acc = 100;                 // PTP加減速度(1～100)(單位：%)
        public double Program_Acc_R = 1000.0;         // 設置圓弧加減速度,(0.1～5000)(單位：deg/sec2)
        public double Program_Acc_S = 10000.0;        // 設置直線加減速度,0.1～25000(單位：mm/sec2)


        protected TLog inLog = null;
        protected bool Terminate = false;
        protected Thread Prog_Thread = null;
        protected bool inProgram_Running = false;
        protected int inProgram_Speed_Factor = 50;    // 整體速度%,(1～100)(單位：%)

        public TLog Log
        {
            get
            {
                return inLog;
            }
            set
            {
                inLog = value;
            }
        }
        public bool Program_Running
        {
            get
            {
                return inProgram_Running;
            }
        }
        public int Program_Speed_Factor
        {
            get
            {
                return inProgram_Speed_Factor;
            }
            set
            {
                inProgram_Speed_Factor = value;
            }
        }
        #endregion

        public TRobot_Program_Base()
        {

        }
        public TRobot_Program_Base(TEpson_Robot robot)
        {
            Robot = robot;
            Init();
        }
        public void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
        {
            if (inLog != null) inLog.Add(Log_Source, fun, msg, type);
        }
        public void Program_Start()
        {
            Terminate = false;
            if (!inProgram_Running)
            {
                Prog_Thread = new Thread(Program_Thread_Start);
                Prog_Thread.Start();
            }
        }
        public void Program_Stop()
        {
            Terminate = true;
            if (Robot != null && Robot.Connected) Robot.Stop();
            if (inProgram_Running) Prog_Thread.Interrupt();
        }
        protected void Program_Thread_Start()
        {
            string fun = "Program_Thread_Start";

            inProgram_Running = true;
            if (Robot != null && Robot.Connected)
            {
                try
                {
                    Log_Add(fun, "Program Start.");
                    Program_Init();
                    while (!Terminate)
                    {
                        Program_IO_In();
                        Program_Main();
                        Program_IO_Out();
                        Thread.Sleep(10);
                   }
                    Log_Add(fun, "Program End.");
                }
                catch (Exception ex)
                {
                    Log_Add(fun, ex.Message, emLog_Type.Error);
                }
            }
            inProgram_Running = false;
            Prog_Thread = null;
        }


        abstract protected void Init();
        abstract public void Program_Init();
        abstract public void Program_Main();
        abstract public void Program_IO_In();
        abstract public void Program_IO_Out();
    }

    //-----------------------------------------------------------------------------------------------------
    // TEFC_SpelPoint
    //-----------------------------------------------------------------------------------------------------
    public class TEFC_SpelPoint : TBase_Class
    {
        public string Label = "";
        public int No = 0;
        public int Local;

        public double X;
        public double Y;
        public double Z;
        public double U;
        public double V;
        public double W;
        public double R;
        public double S;
        public double T;

        public double J1Angle;
        public int J1Flag;
        public int J2Flag;
        public double J4Angle;
        public int J4Flag;
        public int J6Flag;

        public SpelElbow Elbow;
        public SpelHand Hand;
        public SpelWrist Wrist;

        //新增描述字串位置
        public string Description;

        public string Elbow_Str
        {
            get
            {
                return Elbow.ToString();
            }
            set
            {
                switch(value)
                {
                    case "Above": Elbow = SpelElbow.Above; break;
                    case "Below": Elbow = SpelElbow.Below; break;
                }
            }
        }
        public string Hand_Str
        {
            get
            {
                return Hand.ToString();
            }
            set
            {
                switch (value)
                {
                    case "Lefty": Hand = SpelHand.Lefty; break;
                    case "Righty": Hand = SpelHand.Righty; break;
                }
            }
        }
        public string Wrist_Str
        {
            get
            {
                return Wrist.ToString();
            }
            set
            {
                switch (value)
                {
                    case "Flip": Wrist = SpelWrist.Flip; break;
                    case "NoFlip": Wrist = SpelWrist.NoFlip; break;
                }
            }
        }
        
        //=====================================================================
        public SpelPoint SPoint
        {
            get
            {
                return Get_SpelPoint();
            }
        }
        public TEFC_SpelPoint()
        {
            Set_Default();
        }
        public TEFC_SpelPoint(int no, string label = "")
        {
            Set_Default();
            No = no;
            Label = label;
        }
        override public TBase_Class New_Class()
        {
            return new TEFC_SpelPoint();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TEFC_SpelPoint && dis_base is TEFC_SpelPoint)
            {
                TEFC_SpelPoint sor = (TEFC_SpelPoint)sor_base;
                TEFC_SpelPoint dis = (TEFC_SpelPoint)dis_base;

                dis.Label = sor.Label;
                dis.No = sor.No;
                dis.X = sor.X;
                dis.Y = sor.Y;
                dis.Z = sor.Z;
                dis.U = sor.U;
                dis.V = sor.V;
                dis.W = sor.W;
                dis.R = sor.R;
                dis.S = sor.S;
                dis.T = sor.T;

                dis.J1Angle = sor.J1Angle;
                dis.J1Flag = sor.J1Flag;
                dis.J2Flag = sor.J2Flag;
                dis.J4Angle = sor.J4Angle;
                dis.J4Flag = sor.J4Flag;
                dis.J6Flag = sor.J6Flag;
                dis.Local = sor.Local;

                dis.Elbow = sor.Elbow;
                dis.Hand = sor.Hand;
                dis.Wrist = sor.Wrist;
                //新增描述字串位置
                dis.Description = sor.Description;
            }
        }

        public void Set_Default()
        {
            Label = "";
            No = 0;

            X = 0;
            Y = 0;
            Z = 0;
            U = 0;
            V = 0;
            W = 0;
            R = 0;
            S = 0;
            T = 0;

            J1Angle = 0;
            J1Flag = 0;
            J2Flag = 0;
            J4Angle = 0;
            J4Flag = 0;
            J6Flag = 0;
            Local = 0;

            Elbow = SpelElbow.Above;
            Hand = SpelHand.Righty;
            Wrist = SpelWrist.NoFlip;
            //新增描述字串位置
            Description = "";
        }
        override public string ToString()
        {
            string result = "";

            result = string.Format("X={0:f3}, Y={1:f3}, Z={2:f3}, U={3:f3}, V={4:f3}, W={5:f3}",
                                   X, Y, Z, U, V, W);
            return result;
        }
        public void Set_Data(TEFC_SpelPoint point)
        {
            Set_Data(point.SPoint);
        }
        public void Set_Data(SpelPoint point)
        {
            Set_SpelPoint(point);
        }
        public void Set_Data(float x, float y, float z, int local = 0)
        {
            X = x;
            Y = y;
            Z = z;
            Local = local;
        }
        public void Set_Data(float x, float y, float z, float u, float v, float w, int local = 0)
        {
            X = x;
            Y = y;
            Z = z;
            U = u;
            V = v;
            W = w;
            Local = local;
        }
        public void Set_Data(float[] in_pos)
        {
            if (in_pos.Length > 0) X = in_pos[0];
            if (in_pos.Length > 1) Y = in_pos[1];
            if (in_pos.Length > 2) Z = in_pos[2];
            if (in_pos.Length > 3) U = in_pos[3];
            if (in_pos.Length > 4) V = in_pos[4];
            if (in_pos.Length > 5) W = in_pos[5];
            if (in_pos.Length > 6) R = in_pos[6];
            if (in_pos.Length > 7) S = in_pos[7];
            if (in_pos.Length > 8) T = in_pos[8];
        }
        public void Add_Ofs(double ofs_x, double ofs_y, double ofs_q)
        {
            X = X + ofs_x;
            Y = Y + ofs_y;
            U = U + ofs_q;
        }

        private SpelPoint Get_SpelPoint()
        {
            SpelPoint result = new SpelPoint();

            result.X = (float)X;
            result.Y = (float)Y;
            result.Z = (float)Z;
            result.U = (float)U;
            result.V = (float)V;
            result.W = (float)W;
            result.R = (float)R;
            result.S = (float)S;
            result.T = (float)T;

            result.J1Angle = (float)J1Angle;
            result.J1Flag = J1Flag;
            result.J2Flag = J2Flag;
            result.J4Angle = (float)J4Angle;
            result.J4Flag = J4Flag;
            result.J6Flag = J6Flag;
            result.Local = Local;

            result.Elbow = Elbow;
            result.Hand = Hand;
            result.Wrist = Wrist;



            return result;
        }
        private void Set_SpelPoint(SpelPoint point)
        {
            if (point != null)
            {
                X = point.X;
                Y = point.Y;
                Z = point.Z;
                U = point.U;
                V = point.V;
                W = point.W;
                R = point.R;
                S = point.S;
                T = point.T;

                J1Angle = point.J1Angle;
                J1Flag = point.J1Flag;
                J2Flag = point.J2Flag;
                J4Angle = point.J4Angle;
                J4Flag = point.J4Flag;
                J6Flag = point.J6Flag;
                Local = point.Local;

                Elbow = point.Elbow;
                Hand = point.Hand;
                Wrist = point.Wrist;
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TMove_Pos_List
    //-----------------------------------------------------------------------------------------------------
    public class TMove_Pos_List : TBase_Class
    {
        public TMove_Pos[] Items = new TMove_Pos[0];

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
                    Items[i] = new TMove_Pos();
                }
            }
        }
        public TMove_Pos this[int index]
        {
            get
            {
                TMove_Pos result = null;

                if (index >= 0 && index < Count)
                {
                    result = Items[index];
                }
                return result;
            }
        }
        public TMove_Pos this[string name]
        {
            get
            {
                TMove_Pos result = null;
                int index = Get_Index(name);

                if (index >= 0 && index < Count)
                {
                    result = Items[index];
                }
                return result;
            }
        }
        public TMove_Pos_List()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TMove_Pos_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMove_Pos_List && dis_base is TMove_Pos_List)
            {
                TMove_Pos_List sor = (TMove_Pos_List)sor_base;
                TMove_Pos_List dis = (TMove_Pos_List)dis_base;

                dis.Count = sor.Count;
                for (int i = 0; i < dis.Count; i++) dis.Items[i].Set(sor.Items[i]);
            }
        }
        public void Set_Default()
        {
            for (int i = 0; i < Count; i++) Items[i].Set_Default();
        }
        public void Add(string name)
        {
            TMove_Pos point = new TMove_Pos(name);
            point.Pos.Label = name;
            Add(point);
        }
        public void Add(string name, int no)
        {
            TMove_Pos point = new TMove_Pos(name);
            point.Pos.No = no;
            point.Pos.Label = name;
            Add(point);
        }
        public void Add(string name, string label, int no)
        {
           TMove_Pos point = new TMove_Pos(name);
           point.Pos.No = no;
           point.Pos.Label = label;
           Add(point);
        }
        public void Add(TMove_Pos item)
        {
            if (Get_Index(item.Name) < 0)
            {
                Count++;
                Items[Count - 1].Set(item);
            }
        }



        private int Get_Index(string name)
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
    }
    public class TMove_Pos : TBase_Class
    {
        public string Name = "";                            // 點位名稱
        public bool Can_Move;                               // 驅動允用
        public bool On_Pos;                                 // 驅動位置到達
        public double inSpeed = 100;                        // 驅動速度
        public TEFC_SpelPoint Pos = new TEFC_SpelPoint();   // 位置


        public double Speed
        {
            get
            {
                return inSpeed;
            }
            set
            {
                inSpeed = value;
                if (inSpeed < 1) inSpeed = 1;
                if (inSpeed > 100) inSpeed = 100;
            }
        }
        public TMove_Pos()
        {
            Set_Default();
        }
        public TMove_Pos(string name)
        {
            Set_Default();
            Name = name;
        }
        override public TBase_Class New_Class()
        {
            return new TMove_Pos();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TMove_Pos && dis_base is TMove_Pos)
            {
                TMove_Pos sor = (TMove_Pos)sor_base;
                TMove_Pos dis = (TMove_Pos)dis_base;

                dis.Name = sor.Name;
                dis.Can_Move = sor.Can_Move;
                dis.On_Pos = sor.On_Pos;
                dis.inSpeed = sor.inSpeed;
                dis.Pos.Set(sor.Pos);
            }
        }
        public void Set_Default()
        {
            Name = "";
            Can_Move = false;
            On_Pos = true;
            inSpeed = 100;
            Pos.Set_Default();
        }
    }
}
