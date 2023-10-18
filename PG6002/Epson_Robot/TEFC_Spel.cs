using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RCAPINet;
using EFC.Tool;

namespace EFC.Robot.Epson
{
    //-----------------------------------------------------------------------------------------------------
    // TEFC_Spel
    //-----------------------------------------------------------------------------------------------------
    public class TEFC_Spel
    {
        Spel M_Spel = null;
        protected TLog inLog = null;
        public string Log_Source = "EFC_Spel";
        public event Spel.EventReceivedEventHandler EventReceived;

        #region Spel 屬性
        public bool AsyncMode
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.AsyncMode;
                }
                catch (Exception ex)
                {
                    Log_Add("AsyncMode", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.AsyncMode = value;
                }
                catch (Exception ex)
                {
                    Log_Add("AsyncMode", ex.Message, emLog_Type.Error);
                }
            }
        }
        public bool AvoidSingularity
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.AvoidSingularity;
                }
                catch (Exception ex)
                {
                    Log_Add("AvoidSingularity", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.AvoidSingularity = value;
                }
                catch (Exception ex)
                {
                    Log_Add("AvoidSingularity", ex.Message, emLog_Type.Error);
                }
            }
        }
        public bool CommandInCycle
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.CommandInCycle;
                }
                catch (Exception ex)
                {
                    Log_Add("CommandInCycle", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public int CommandTask
        {
            get
            {
                int result = 0;
                try
                {
                    result = M_Spel.CommandTask;
                }
                catch (Exception ex)
                {
                    Log_Add("CommandTask", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.CommandTask = value;
                }
                catch (Exception ex)
                {
                    Log_Add("CommandTask", ex.Message, emLog_Type.Error);
                }
            }
        }
        public bool DisableMsgDispatch
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.DisableMsgDispatch;
                }
                catch (Exception ex)
                {
                    Log_Add("DisableMsgDispatch", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.AvoidSingularity = value;
                }
                catch (Exception ex)
                {
                    Log_Add("DisableMsgDispatch", ex.Message, emLog_Type.Error);
                }
            }

        }
        public int ErrorCode
        {
            get
            {
                int result = 0;
                try
                {
                    result = M_Spel.ErrorCode;
                }
                catch (Exception ex)
                {
                    Log_Add("ErrorCode", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public bool ErrorOn 
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.ErrorOn;
                }
                catch (Exception ex)
                {
                    Log_Add("ErrorOn", ex.Message, emLog_Type.Error);
                }
                return result;
            }

        }
        public bool EStopOn
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.EStopOn;
                }
                catch (Exception ex)
                {
                    Log_Add("EStopOn", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public int Force_Sensor
        {
            get
            {
                int result = 0;
                try
                {
                    result = M_Spel.Force_Sensor;
                }
                catch (Exception ex)
                {
                    Log_Add("Force_Sensor", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.Force_Sensor = value;
                }
                catch (Exception ex)
                {
                    Log_Add("Force_Sensor", ex.Message, emLog_Type.Error);
                }
            }
        }
        public bool MotorsOn
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.MotorsOn;
                }
                catch (Exception ex)
                {
                    Log_Add("MotorsOn", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.MotorsOn = value;
                }
                catch (Exception ex)
                {
                    Log_Add("MotorsOn", ex.Message, emLog_Type.Error);
                }
            }
        }
        public bool NoProjectSync
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.NoProjectSync;
                }
                catch (Exception ex)
                {
                    Log_Add("NoProjectSync", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.NoProjectSync = value;
                }
                catch (Exception ex)
                {
                    Log_Add("NoProjectSync", ex.Message, emLog_Type.Error);
                }
            }
        }
        public SpelOperationMode OperationMode
        {
            get
            {
                SpelOperationMode result = SpelOperationMode.Auto;
                try
                {
                    result = M_Spel.OperationMode;
                }
                catch (Exception ex)
                {
                    Log_Add("OperationMode", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.OperationMode = value;
                }
                catch (Exception ex)
                {
                    Log_Add("OperationMode", ex.Message, emLog_Type.Error);
                }
            }
        }
        public int ParentWindowHandle
        {
            get
            {
                int result = 0;
                try
                {
                    result = M_Spel.ParentWindowHandle;
                }
                catch (Exception ex)
                {
                    Log_Add("ParentWindowHandle", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.ParentWindowHandle = value;
                }
                catch (Exception ex)
                {
                    Log_Add("ParentWindowHandle", ex.Message, emLog_Type.Error);
                }
            }
        }
        public bool PauseOn
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.PauseOn;
                }
                catch (Exception ex)
                {
                    Log_Add("PauseOn", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public bool PowerHigh
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.PowerHigh;
                }
                catch (Exception ex)
                {
                    Log_Add("PowerHigh", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.PowerHigh = value;
                }
                catch (Exception ex)
                {
                    Log_Add("PowerHigh", ex.Message, emLog_Type.Error);
                }
            }
        }
        public string Project
        {
            get
            {
                string result = "";
                try
                {
                    result = M_Spel.Project;
                }
                catch (Exception ex)
                {
                    Log_Add("Project", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.Project = value;
                }
                catch (Exception ex)
                {
                    Log_Add("Project", ex.Message, emLog_Type.Error);
                }
            }

        }
        public bool ProjectBuildComplete
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.ProjectBuildComplete;
                }
                catch (Exception ex)
                {
                    Log_Add("ProjectBuildComplete", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public bool ProjectOverwriteWarningEnabled
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.ProjectOverwriteWarningEnabled;
                }
                catch (Exception ex)
                {
                    Log_Add("ProjectOverwriteWarningEnabled", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.ProjectOverwriteWarningEnabled = value;
                }
                catch (Exception ex)
                {
                    Log_Add("ProjectOverwriteWarningEnabled", ex.Message, emLog_Type.Error);
                }
            }
        }
        public bool ResetAbortEnabled
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.ResetAbortEnabled;
                }
                catch (Exception ex)
                {
                    Log_Add("ResetAbortEnabled", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.ResetAbortEnabled = value;
                }
                catch (Exception ex)
                {
                    Log_Add("ResetAbortEnabled", ex.Message, emLog_Type.Error);
                }
            }
        }
        public int Robot
        {
            get
            {
                int result = 0;
                try
                {
                    result = M_Spel.Robot;
                }
                catch (Exception ex)
                {
                    Log_Add("Robot", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.Robot = value;
                }
                catch (Exception ex)
                {
                    Log_Add("Robot", ex.Message, emLog_Type.Error);
                }
            }
        }
        public string RobotModel
        {
            get
            {
                string result = "";
                try
                {
                    result = M_Spel.RobotModel;
                }
                catch (Exception ex)
                {
                    Log_Add("RobotModel", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public SpelRobotType RobotType
        {
            get
            {
                SpelRobotType result = SpelRobotType.Cartesian;
                try
                {
                    result = M_Spel.RobotType;
                }
                catch (Exception ex)
                {
                    Log_Add("RobotType", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public bool SafetyOn
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.SafetyOn;
                }
                catch (Exception ex)
                {
                    Log_Add("SafetyOn", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public int ServerInstance
        {
            get
            {
                int result = 0;
                try
                {
                    result = M_Spel.ServerInstance;
                }
                catch (Exception ex)
                {
                    Log_Add("ServerInstance", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.ServerInstance = value;
                }
                catch (Exception ex)
                {
                    Log_Add("ServerInstance", ex.Message, emLog_Type.Error);
                }
            }
        }
        public RCProductType ServerProductType
        {
            get
            {
                RCProductType result = RCProductType.RC70;
                try
                {
                    result = M_Spel.ServerProductType;
                }
                catch (Exception ex)
                {
                    Log_Add("ServerProductType", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.ServerProductType = value;
                }
                catch (Exception ex)
                {
                    Log_Add("ServerProductType", ex.Message, emLog_Type.Error);
                }
            }
        }
        public SPELVideo SpelVideoControl
        {
            get
            {
                SPELVideo result = null;
                try
                {
                    result = M_Spel.SpelVideoControl;
                }
                catch (Exception ex)
                {
                    Log_Add("SpelVideoControl", ex.Message, emLog_Type.Error);
                }
                return result;
            }
            set
            {
                try
                {
                    M_Spel.SpelVideoControl = value;
                }
                catch (Exception ex)
                {
                    Log_Add("SpelVideoControl", ex.Message, emLog_Type.Error);
                }
            }
        }
        public string Version
        {
            get
            {
                string result = "";
                try
                {
                    result = M_Spel.Version;
                }
                catch (Exception ex)
                {
                    Log_Add("Version", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public int WarningCode
        {
            get
            {
                int result = 0;
                try
                {
                    result = M_Spel.WarningCode;
                }
                catch (Exception ex)
                {
                    Log_Add("WarningCode", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        public bool WarningOn 
        {
            get
            {
                bool result = false;
                try
                {
                    result = M_Spel.WarningOn;
                }
                catch (Exception ex)
                {
                    Log_Add("WarningOn", ex.Message, emLog_Type.Error);
                }
                return result;
            }
        }
        #endregion

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



        public TEFC_Spel()
        {
            M_Spel = new Spel();
        }
        public void Dispose()
        {
            M_Spel.Dispose();
        }
        public void Log_Add(string fun, string msg, emLog_Type type = emLog_Type.Generally)
        {
            if (inLog != null) inLog.Add(Log_Source, fun, msg, type);
        }

        #region A
        public void Abort()
        {
            string fun = "Abort";

            try
            {
                M_Spel.Abort();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Accel(int Accel, int Decel)
        {
            string fun = "Accel";

            try
            {
                M_Spel.Accel(Accel, Decel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Accel(int Accel, int Decel, int JumpDepartAccel, int JumpDepartDecel, int JumpApproAccel, int JumpApproDecel)
        {
            string fun = "Accel";

            try
            {
                M_Spel.Accel(Accel, Decel, JumpDepartAccel, JumpDepartDecel, JumpApproAccel, JumpApproDecel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void AccelR(float Accel)
        {
            string fun = "AccelR";

            try
            {
                M_Spel.AccelR(Accel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void AccelR(float Accel, float Decel)
        {
            string fun = "AccelR";

            try
            {
                M_Spel.AccelR(Accel, Decel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void AccelS(float Accel, float Decel)
        {
            string fun = "AccelS";

            try
            {
                M_Spel.AccelS(Accel, Decel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void AccelS(float Accel, float Decel, float JumpDepartAccel, float JumpDepartDecel, float JumpApproAccel, float JumpApproDecel)
        {
            string fun = "AccelS";

            try
            {
                M_Spel.AccelS(Accel, Decel, JumpDepartAccel, JumpDepartDecel, JumpApproAccel, JumpApproDecel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float Agl(int JointNumber)
        {
            float result = 0;
            string fun = "Agl";

            try
            {
                result = M_Spel.Agl(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float AIO_In(int Channel)
        {
            float result = 0;
            string fun = "AIO_In";

            try
            {
                result = M_Spel.AIO_In(Channel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int AIO_InW(int Channel)
        {
            int result = 0;
            string fun = "AIO_InW";

            try
            {
                result = M_Spel.AIO_InW(Channel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float AIO_Out(int Channel)
        {
            float result = 0;
            string fun = "AIO_Out";

            try
            {
                result = M_Spel.AIO_Out(Channel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void AIO_Out(int Channel, float Value)
        {
            string fun = "AIO_Out";

            try
            {
                M_Spel.AIO_Out(Channel, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public int AIO_OutW(int Channel)
        {
            int result = 0;
            string fun = "AIO_OutW";

            try
            {
                result = M_Spel.AIO_OutW(Channel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void AIO_OutW(int Channel, int OutputData)
        {
            string fun = "AIO_OutW";

            try
            {
                M_Spel.AIO_OutW(Channel, OutputData);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arc(int MidPoint, int EndPoint)
        {
            string fun = "Arc";

            try
            {
                M_Spel.Arc(MidPoint, EndPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arc(SpelPoint MidPoint, SpelPoint EndPoint)
        {
            string fun = "Arc";

            try
            {
                M_Spel.Arc(MidPoint, EndPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arc(string MidPoint, string EndPoint)
        {
            string fun = "Arc";

            try
            {
                M_Spel.Arc(MidPoint, EndPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arc3(int MidPoint, int EndPoint)
        {
            string fun = "Arc3";

            try
            {
                M_Spel.Arc3(MidPoint, EndPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arc3(SpelPoint MidPoint, SpelPoint EndPoint)
        {
            string fun = "Arc3";

            try
            {
                M_Spel.Arc3(MidPoint, EndPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arc3(string MidPoint, string EndPoint)
        {
            string fun = "Arc3";

            try
            {
                M_Spel.Arc3(MidPoint, EndPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arch(int ArchNumber, float DepartDist, float ApproDist)
        {
            string fun = "Arch";

            try
            {
                M_Spel.Arch(ArchNumber, DepartDist, ApproDist);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Arm(int ArmNumber)
        {
            string fun = "Arm";

            try
            {
                M_Spel.Arm(ArmNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ArmClr(int ArmNumber)
        {
            string fun = "ArmClr";

            try
            {
                M_Spel.ArmClr(ArmNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool ArmDef(int ArmNumber)
        {
            bool result = false;
            string fun = "ArmDef";

            try
            {
                result = M_Spel.ArmDef(ArmNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void ArmSet(int ArmNumber, float Param1, float Param2, float Param3, float Param4, float Param5)
        {
            string fun = "ArmSet";

            try
            {
                M_Spel.ArmSet(ArmNumber, Param1, Param2, Param3, Param4, Param5);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public double Atan(double Tangent)
        {
            double result = 0;
            string fun = "Atan";

            try
            {
                result = M_Spel.Atan(Tangent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public double Atan2(double X, double Y)
        {
            double result = 0;
            string fun = "Atan";

            try
            {
                result = M_Spel.Atan2(X, Y);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void ATCLR()
        {
            string fun = "ATCLR";

            try
            {
                M_Spel.ATCLR();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool AtHome()
        {
            bool result = false;
            string fun = "AtHome";

            try
            {
                result = M_Spel.AtHome();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float ATRQ(int JointNumber)
        {
            float result = 0;
            string fun = "ATRQ";

            try
            {
                result = M_Spel.ATRQ(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float AvgSpeed(int JointNumber)
        {
            float result = 0;
            string fun = "AvgSpeed";

            try
            {
                result = M_Spel.AvgSpeed(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void AvgSpeedClear()
        {
            string fun = "AvgSpeedClear";

            try
            {
                M_Spel.AvgSpeedClear();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool AxisLocked(int AxisNumber)
        {
            bool result = false;
            string fun = "AxisLocked";

            try
            {
                result = M_Spel.AxisLocked(AxisNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

        #region B
        public void Base(SpelPoint OriginPoint)
        {
            string fun = "Base";

            try
            {
                M_Spel.Base(OriginPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Base(SpelPoint OriginPoint, SpelPoint XAxisPoint, SpelPoint YAxisPoint, SpelBaseAlignment Alignment)
        {
            string fun = "Base";

            try
            {
                M_Spel.Base(OriginPoint, XAxisPoint, YAxisPoint, Alignment);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BGo(int PointNumber)
        {
            string fun = "BGo";

            try
            {
                M_Spel.BGo(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BGo(SpelPoint Point)
        {
            string fun = "BGo";

            try
            {
                M_Spel.BGo(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BGo(string PointExpr)
        {
            string fun = "BGo";

            try
            {
                M_Spel.BGo(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BGo(SpelPoint Point, string AttribExpr)
        {
            string fun = "BGo";

            try
            {
                M_Spel.BGo(Point, AttribExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BMove(int PointNumber)
        {
            string fun = "BMove";

            try
            {
                M_Spel.BMove(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BMove(SpelPoint Point)
        {
            string fun = "BMove";

            try
            {
                M_Spel.BMove(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BMove(string PointExpr)
        {
            string fun = "BMove";

            try
            {
                M_Spel.BMove(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BMove(SpelPoint Point, string AttribExpr)
        {
            string fun = "BMove";

            try
            {
                M_Spel.BMove(Point, AttribExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Box(int AreaNumber, float MinX, float MaxX, float MinY, float MaxY, float MinZ, float MaxZ)
        {
            string fun = "Box";

            try
            {
                M_Spel.Box(AreaNumber, MinX, MaxX, MinY, MaxY, MinZ, MaxZ);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Box(int AreaNumber, float MinX, float MaxX, float MinY, float MaxY, float MinZ, float MaxZ, bool polarityOn)
        {
            string fun = "Box";

            try
            {
                M_Spel.Box(AreaNumber, MinX, MaxX, MinY, MaxY, MinZ, MaxZ, polarityOn);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void BoxClr(int AreaNumber)
        {
            string fun = "BoxClr";

            try
            {
                M_Spel.BoxClr(AreaNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool BoxDef(int AreaNumber)
        {
            bool result = false;
            string fun = "BoxDef";

            try
            {
                result = M_Spel.BoxDef(AreaNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int Brake(int JointNumber)
        {
            int result = 0;
            string fun = "Brake";

            try
            {
                result = M_Spel.Brake(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Brake(int JointNumber, bool State)
        {
            string fun = "Brake";

            try
            {
                M_Spel.Brake(JointNumber, State);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool BTst(int InputData, int BitNumber)
        {
            bool result = false;
            string fun = "BTst";

            try
            {
                result = M_Spel.BTst(InputData, BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void BuildProject()
        {
            string fun = "BuildProject";

            try
            {
                M_Spel.BuildProject();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region C
        public object Call(string FunctionName)
        {
            object result = null;
            string fun = "Call";

            try
            {
                result = M_Spel.Call(FunctionName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public object Call(string FunctionName, string Parameters)
        {
            object result = null;
            string fun = "Call";

            try
            {
                result = M_Spel.Call(FunctionName, Parameters);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int CalPls(int JointNumber)
        {
            int result = 0;
            string fun = "CalPls";

            try
            {
                result = M_Spel.CalPls(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void CalPls(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses)
        {
            string fun = "CalPls";

            try
            {
                M_Spel.CalPls(J1Pulses, J2Pulses, J3Pulses, J4Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void CalPls(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses)
        {
            string fun = "CalPls";

            try
            {
                M_Spel.CalPls(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void CalPls(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses, int J7Pulses, int J8Pulses, int J9Pulses)
        {
            string fun = "CalPls";

            try
            {
                M_Spel.CalPls(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses, J7Pulses, J8Pulses, J9Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ClearPoints()
        {
            string fun = "ClearPoints";

            try
            {
                M_Spel.ClearPoints();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool Connect(int ConnectionNumber)
        {
            bool result = false;
            string fun = "Connect";

            try
            {
                M_Spel.Connect(ConnectionNumber);
                result = true;
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool Connect(string ConnectionName)
        {
            bool result = false;
            string fun = "Connect";

            try
            {
                M_Spel.Connect(ConnectionName);
                result = true;
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool Connect(int ConnectionNumber, string ConnectionPassword)
        {
            bool result = false;
            string fun = "Connect";

            try
            {
                M_Spel.Connect(ConnectionNumber, ConnectionPassword);
                result = true;
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool Connect(string ConnectionName, string ConnectionPassword)
        {
            bool result = false;
            string fun = "Connect";

            try
            {
                M_Spel.Connect(ConnectionName, ConnectionPassword);
                result = true;
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Continue()
        {
            string fun = "Continue";

            try
            {
                M_Spel.Continue();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float CR(string PointExpr)
        {
            float result = 0;
            string fun = "CR";

            try
            {
                result = M_Spel.CR(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float CS(string PointExpr)
        {
            float result = 0;
            string fun = "CS";

            try
            {
                result = M_Spel.CS(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float CT(string PointExpr)
        {
            float result = 0;
            string fun = "CT";

            try
            {
                result = M_Spel.CT(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int Ctr(int BitNumber)
        {
            int result = 0;
            string fun = "Ctr";

            try
            {
                result = M_Spel.Ctr(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void CtReset(int BitNumber)
        {
            string fun = "CtReset";

            try
            {
                M_Spel.CtReset(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float CU(string PointExpr)
        {
            float result = 0;
            string fun = "CU";

            try
            {
                result = M_Spel.CU(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Curve(string FileName, bool Closure, int Mode, int NumberOfAxes, string PointList)
        {
            string fun = "Curve";

            try
            {
                M_Spel.Curve(FileName, Closure, Mode, NumberOfAxes, PointList);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float CV(string PointExpr)
        {
            float result = 0;
            string fun = "CV";

            try
            {
                result = M_Spel.CV(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void CVMove(string FileName)
        {
            string fun = "CVMove";

            try
            {
                M_Spel.CVMove(FileName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void CVMove(string FileName, string OptionList)
        {
            string fun = "CVMove";

            try
            {
                M_Spel.CVMove(FileName, OptionList);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float CW(string PointExpr)
        {
            float result = 0;
            string fun = "CW";

            try
            {
                result = M_Spel.CW(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float CX(string PointExpr)
        {
            float result = 0;
            string fun = "CX";

            try
            {
                result = M_Spel.CX(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float CY(string PointExpr)
        {
            float result = 0;
            string fun = "CY";

            try
            {
                result = M_Spel.CY(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float CZ(string PointExpr)
        {
            float result = 0;
            string fun = "CZ";

            try
            {
                result = M_Spel.CZ(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

        #region D
        public double DegToRad(double Degrees)
        {
            double result = 0;
            string fun = "DegToRad";

            try
            {
                result = M_Spel.DegToRad(Degrees);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Delay(int Milliseconds)
        {
            string fun = "Delay";

            try
            {
                M_Spel.Delay(Milliseconds);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Disconnect()
        {
            string fun = "Disconnect";

            try
            {
                M_Spel.Disconnect();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region E
        public void ECP(int ECPNumber)
        {
            string fun = "ECP";

            try
            {
                M_Spel.ECP(ECPNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ECPClr(int ECPNumber)
        {
            string fun = "ECPClr";

            try
            {
                M_Spel.ECPClr(ECPNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool ECPDef(int ECPNumber)
        {
            bool result = false;
            string fun = "ECPDef";

            try
            {
                result = M_Spel.ECPDef(ECPNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void ECPSet(int ECPNumber, SpelPoint Point)
        {
            string fun = "ECPSet";

            try
            {
                M_Spel.ECPSet(ECPNumber, Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ECPSet(int ECPNumber, float X, float Y, float Z, float U, float V, float W)
        {
            string fun = "ECPSet";

            try
            {
                M_Spel.ECPSet(ECPNumber, X, Y, Z, U, V, W);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void EnableEvent(SpelEvents Event, bool Enable)
        {
            string fun = "EnableEvent";

            try
            {
                M_Spel.EnableEvent(Event, Enable);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ExecuteCommand(string Command)
        {
            string fun = "ExecuteCommand";

            try
            {
                M_Spel.ExecuteCommand(Command);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ExecuteCommand(string Command, ref string Reply)
        {
            string fun = "ExecuteCommand";

            try
            {
                M_Spel.ExecuteCommand(Command, ref Reply);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region F
        public int FbusIO_GetBusStatus(int BusNumber)
        {
            int result = 0;
            string fun = "FbusIO_GetBusStatus";

            try
            {
                result = M_Spel.FbusIO_GetBusStatus(BusNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int FbusIO_GetDeviceStatus(int BusNumber, int DeviceID)
        {
            int result = 0;
            string fun = "FbusIO_GetDeviceStatus";

            try
            {
                result = M_Spel.FbusIO_GetDeviceStatus(BusNumber, DeviceID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void FbusIO_SendMsg(int BusNumber, int DeviceID, int MsgParam, byte[] SendData, out byte[] RecvData)
        {
            string fun = "FbusIO_SendMsg";

            RecvData = null;
            try
            {
                M_Spel.FbusIO_SendMsg(BusNumber, DeviceID, MsgParam, SendData, out RecvData);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void FGGet(string Sequence, string Object, SpelForceProps Property, out bool Result)
        {
            string fun = "FGGet";

            Result = false;
            try
            {
                M_Spel.FGGet(Sequence, Object, Property, out Result);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void FGGet(string Sequence, string Object, SpelForceProps Property, out double Result)
        {
            string fun = "FGGet";

            Result = 0;
            try
            {
                M_Spel.FGGet(Sequence, Object, Property, out Result);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void FGGet(string Sequence, string Object, SpelForceProps Property, out int Result)
        {
            string fun = "FGGet";

            Result = 0;
            try
            {
                M_Spel.FGGet(Sequence, Object, Property, out Result);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void FGGet(string Sequence, string Object, SpelForceProps Property, out string Result)
        {
            string fun = "FGGet";

            Result = "";
            try
            {
                M_Spel.FGGet(Sequence, Object, Property, out Result);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void FGRun(string Sequence)
        {
            string fun = "FGRun";

            try
            {
                M_Spel.FGRun(Sequence);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Find(string Condition)
        {
            string fun = "Find";

            try
            {
                M_Spel.Find(Condition);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Fine(int J1MaxErr, int J2MaxErr, int J3MaxErr, int J4MaxErr, int J5MaxErr, int J6MaxErr)
        {
            string fun = "Fine";

            try
            {
                M_Spel.Fine(J1MaxErr, J2MaxErr, J3MaxErr, J4MaxErr, J5MaxErr, J6MaxErr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Fine(int J1MaxErr, int J2MaxErr, int J3MaxErr, int J4MaxErr, int J5MaxErr, int J6MaxErr, int J7MaxErr, int J8MaxErr, int J9MaxErr)
        {
            string fun = "Fine";

            try
            {
                M_Spel.Fine(J1MaxErr, J2MaxErr, J3MaxErr, J4MaxErr, J5MaxErr, J6MaxErr, J7MaxErr, J8MaxErr, J9MaxErr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Force_Calibrate()
        {
            string fun = "Force_Calibrate";

            try
            {
                M_Spel.Force_Calibrate();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Force_ClearTrigger()
        {
            string fun = "Force_ClearTrigger";

            try
            {
                M_Spel.Force_ClearTrigger();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float Force_GetForce(SpelForceAxis Axis)
        {
            float result = 0;
            string fun = "Force_GetForce";

            try
            {
                result = M_Spel.Force_GetForce(Axis);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Force_GetForces(ref float[] Values)
        {
            string fun = "Force_GetForces";

            try
            {
                M_Spel.Force_GetForces(ref Values);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Force_SetTrigger(SpelForceAxis Axis, float Threshold, SpelForceCompareType CompareType)
        {
            string fun = "Force_SetTrigger";

            try
            {
                M_Spel.Force_SetTrigger(Axis, Threshold, CompareType);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region G
        public int GetAccel(int ParamNumber)
        {
            int result = 0;
            string fun = "GetAccel";

            try
            {
                result = M_Spel.GetAccel(ParamNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int GetArm()
        {
            int result = 0;
            string fun = "GetArm";

            try
            {
                result = M_Spel.GetArm();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelConnectionInfo[] GetConnectionInfo()
        {
            SpelConnectionInfo[] result = null;
            string fun = "GetConnectionInfo";

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
        public SpelControllerInfo GetControllerInfo()
        {
            SpelControllerInfo result = null;
            string fun = "GetControllerInfo";

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
        public SpelConnectionInfo GetCurrentConnectionInfo()
        {
            SpelConnectionInfo result = null;
            string fun = "GetCurrentConnectionInfo";

            try
            {
                result = M_Spel.GetCurrentConnectionInfo();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public string GetCurrentUser()
        {
            string result = "";
            string fun = "GetCurrentUser";

            try
            {
                result = M_Spel.GetCurrentUser();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int GetECP()
        {
            int result = 0;
            string fun = "GetECP";

            try
            {
                result = M_Spel.GetECP();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public string GetErrorMessage(int ErrorCode)
        {
            string result = "";
            string fun = "GetErrorMessage";

            try
            {
                result = M_Spel.GetErrorMessage(ErrorCode);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void GetIODef(SpelIOLabelTypes Type, int Index, out string Label, out string Description)
        {
            string fun = "GetIODef";

            Label = "";
            Description = "";
            try
            {
                M_Spel.GetIODef(Type, Index, out Label, out Description);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public int GetJRange(int JointNumber, int Bound)
        {
            int result = 0;
            string fun = "GetJRange";

            try
            {
                result = M_Spel.GetJRange(JointNumber, Bound);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int GetLimitTorque(int JointNumber)
        {
            int result = 0;
            string fun = "GetLimitTorque";

            try
            {
                result = M_Spel.GetLimitTorque(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float GetLimZ()
        {
            float result = 0;
            string fun = "GetLimZ";

            try
            {
                result = M_Spel.GetLimZ();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelPoint GetPoint(int PointNumber)
        {
            SpelPoint result = null;
            string fun = "GetPoint";

            try
            {
                result = M_Spel.GetPoint(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelPoint GetPoint(string PointExpr)
        {
            SpelPoint result = null;
            string fun = "GetPoint";

            try
            {
                M_Spel.GetPoint(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public double GetRealTorque(int JointNumber)
        {
            double result = 0;
            string fun = "GetRealTorque";

            try
            {
                result = M_Spel.GetRealTorque(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelRobotInfo GetRobotInfo(int RobotNumber)
        {
            SpelRobotInfo result = null;
            string fun = "GetRobotInfo";

            try
            {
                result = M_Spel.GetRobotInfo(RobotNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float[] GetRobotPos(SpelRobotPosType PosType, int Arm, int Tool, int Local)
        {
            float[] result = null;
            string fun = "GetRobotPos";

            try
            {
                result = M_Spel.GetRobotPos(PosType, Arm, Tool, Local);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int GetSpeed(int ParamNumber)
        {
            int result = 0;
            string fun = "GetSpeed";

            try
            {
                result = M_Spel.GetSpeed(ParamNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelTaskInfo GetTaskInfo(int TaskNumber)
        {
            SpelTaskInfo result = null;
            string fun = "GetTaskInfo";

            try
            {
                result = M_Spel.GetTaskInfo(TaskNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelTaskInfo GetTaskInfo(string TaskName)
        {
            SpelTaskInfo result = null;
            string fun = "GetTaskInfo";

            try
            {
                result = M_Spel.GetTaskInfo(TaskName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int GetTool()
        {
            int result = 0;
            string fun = "GetTool";

            try
            {
                result = M_Spel.GetTool();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public object GetVar(string VarName)
        {
            object result = null;
            string fun = "GetVar";

            try
            {
                result = M_Spel.GetVar(VarName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Go(int PointNumber)
        {
            string fun = "Go";

            try
            {
                M_Spel.Go(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Go(SpelPoint Point)
        {
            string fun = "Go";

            try
            {
                M_Spel.Go(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Go(string PointExpr)
        {
            string fun = "Go";

            try
            {
                M_Spel.Go(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Go(SpelPoint Point, string AttribExpr)
        {
            string fun = "Go";

            try
            {
                M_Spel.Go(Point, AttribExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region H
        public void Halt(int TaskNumber)
        {
            string fun = "Halt";

            try
            {
                M_Spel.Halt(TaskNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Halt(string TaskName)
        {
            string fun = "Halt";

            try
            {
                M_Spel.Halt(TaskName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Here(int PointNumber)
        {
            string fun = "Here";

            try
            {
                M_Spel.Here(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Here(string PointName)
        {
            string fun = "Here";

            try
            {
                M_Spel.Here(PointName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void HideWindow(SpelWindows windowID)
        {
            string fun = "HideWindow";

            try
            {
                M_Spel.HideWindow(windowID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public int Hofs(int JointNumber)
        {
            int result = 0;
            string fun = "Hofs";

            try
            {
                result = M_Spel.Hofs(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Hofs(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses)
        {
            string fun = "Hofs";

            try
            {
                M_Spel.Hofs(J1Pulses, J2Pulses, J3Pulses, J4Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Hofs(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses)
        {
            string fun = "Hofs";

            try
            {
                M_Spel.Hofs(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Hofs(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses, int J7Pulses, int J8Pulses, int J9Pulses)
        {
            string fun = "Hofs";

            try
            {
                M_Spel.Hofs(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses, J7Pulses, J8Pulses, J9Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Home()
        {
            string fun = "Home";

            try
            {
                M_Spel.Home();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Homeset(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses)
        {
            string fun = "Homeset";

            try
            {
                M_Spel.Homeset(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Homeset(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses, int J7Pulses, int J8Pulses, int J9Pulses)
        {
            string fun = "Homeset";

            try
            {
                M_Spel.Homeset(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses, J7Pulses, J8Pulses, J9Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Hordr(int Step1, int Step2, int Step3, int Step4, int Step5, int Step6)
        {
            string fun = "Hordr";

            try
            {
                M_Spel.Hordr(Step1, Step2, Step3, Step4, Step5, Step6);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Hordr(int Step1, int Step2, int Step3, int Step4, int Step5, int Step6, int Step7, int Step8, int Step9)
        {
            string fun = "Hordr";

            try
            {
                M_Spel.Hordr(Step1, Step2, Step3, Step4, Step5, Step6, Step7, Step8, Step9);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float Hour()
        {
            float result = 0;
            string fun = "Hour";

            try
            {
                result = M_Spel.Hour();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

        #region I
        public void ImportPoints(string SourcePath, string ProjectFileName)
        {
            string fun = "ImportPoints";

            try
            {
                M_Spel.ImportPoints(SourcePath, ProjectFileName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ImportPoints(string SourcePath, string ProjectFileName, int RobotNumber)
        {
            string fun = "ImportPoints";

            try
            {
                M_Spel.ImportPoints(SourcePath, ProjectFileName, RobotNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public int In(int PortNumber)
        {
            int result = 0;
            string fun = "In";

            try
            {
                result = M_Spel.In(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int In(string Label)
        {
            int result = 0;
            string fun = "In";

            try
            {
                result = M_Spel.In(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int InBCD(int PortNumber)
        {
            int result = 0;
            string fun = "InBCD";

            try
            {
                result = M_Spel.InBCD(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int InBCD(string Label)
        {
            int result = 0;
            string fun = "InBCD";

            try
            {
                result = M_Spel.InBCD(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Inertia(float LoadInertia, float Eccentricity)
        {
            string fun = "Inertia";

            try
            {
                M_Spel.Inertia(LoadInertia, Eccentricity);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Initialize()
        {
            string fun = "Initialize";

            try
            {
                M_Spel.Initialize();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float InReal(int PortNumber)
        {
            float result = 0;
            string fun = "InReal";

            try
            {
                result = M_Spel.InReal(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool InsideBox(int AreaNumber)
        {
            bool result = false;
            string fun = "InsideBox";

            try
            {
                result = M_Spel.InsideBox(AreaNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool InsidePlane(int PlaneNumber)
        {
            bool result = false;
            string fun = "InsidePlane";

            try
            {
                result = M_Spel.InsidePlane(PlaneNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int InW(int PortNumber)
        {
            int result = 0;
            string fun = "InW";

            try
            {
                result = M_Spel.InW(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int InW(string Label)
        {
            int result = 0;
            string fun = "InW";

            try
            {
                result = M_Spel.InW(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool IsOptionActive(SpelOptions Option)
        {
            bool result = false;
            string fun = "IsOptionActive";

            try
            {
                result = M_Spel.IsOptionActive(Option);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

        #region J
        public void JRange(int JointNumber, int LowerLimitPulses, int UpperLimitPulses)
        {
            string fun = "JRange";

            try
            {
                M_Spel.JRange(JointNumber, LowerLimitPulses, UpperLimitPulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool JS()
        {
            bool result = false;
            string fun = "JS";

            try
            {
                result = M_Spel.JS();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void JTran(int JointNumber, float Distance)
        {
            string fun = "JTran";

            try
            {
                M_Spel.JTran(JointNumber, Distance);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump(int JointNumber)
        {
            string fun = "Jump";

            try
            {
                M_Spel.Jump(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump(SpelPoint Point)
        {
            string fun = "Jump";

            try
            {
                M_Spel.Jump(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump(string PointExpr)
        {
            string fun = "Jump";

            try
            {
                M_Spel.Jump(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump(SpelPoint Point, string AttribExpr)
        {
            string fun = "Jump";

            try
            {
                M_Spel.Jump(Point, AttribExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump3(int DepartPointNumber, int ApproPointNumber, int DestPointNumber)
        {
            string fun = "Jump3";

            try
            {
                M_Spel.Jump3(DepartPointNumber, ApproPointNumber, DestPointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump3(SpelPoint DepartPoint, SpelPoint ApproPoint, SpelPoint DestPoint)
        {
            string fun = "Jump3";

            try
            {
                M_Spel.Jump3(DepartPoint, ApproPoint, DestPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump3(string DepartPointExpr, string ApproPointExpr, string DestPointExpr)
        {
            string fun = "Jump3";

            try
            {
                M_Spel.Jump3(DepartPointExpr, ApproPointExpr, DestPointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump3CP(int DepartPointNumber, int ApproPointNumber, int DestPointNumber)
        {
            string fun = "Jump3CP";

            try
            {
                M_Spel.Jump3CP(DepartPointNumber, ApproPointNumber, DestPointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump3CP(SpelPoint DepartPoint, SpelPoint ApproPoint, SpelPoint DestPoint)
        {
            string fun = "Jump3CP";

            try
            {
                M_Spel.Jump3CP(DepartPoint, ApproPoint, DestPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Jump3CP(string DepartPointExpr, string ApproPointExpr, string DestPointExpr)
        {
            string fun = "Jump3CP";

            try
            {
                M_Spel.Jump3CP(DepartPointExpr, ApproPointExpr, DestPointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region K
        #endregion

        #region L
        public void LimitTorque(int AllJointsMax)
        {
            string fun = "LimitTorque";

            try
            {
                M_Spel.LimitTorque(AllJointsMax);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void LimitTorque(int J1Max, int J2Max, int J3Max, int J4Max, int J5Max, int J6Max)
        {
            string fun = "LimitTorque";

            try
            {
                M_Spel.LimitTorque(J1Max, J2Max, J3Max, J4Max, J5Max, J6Max);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void LimZ(float ZLimit)
        {
            string fun = "LimZ";

            try
            {
                M_Spel.LimZ(ZLimit);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void LoadPoints(string FileName)
        {
            string fun = "LoadPoints";

            try
            {
                M_Spel.LoadPoints(FileName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void LoadPoints(string FileName, bool Merge)
        {
            string fun = "LoadPoints";

            try
            {
                M_Spel.LoadPoints(FileName, Merge);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Local(int LocalNumber, SpelPoint OriginPoint)
        {
            string fun = "Local";

            try
            {
                M_Spel.Local(LocalNumber, OriginPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Local(int LocalNumber, SpelPoint OriginPoint, SpelPoint XAxisPoint, SpelPoint YAxisPoint)
        {
            string fun = "Local";

            try
            {
                M_Spel.Local(LocalNumber, OriginPoint, XAxisPoint, YAxisPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Local(int LocalNumber, int LocalPoint1, int BasePoint1, int LocalPoint2, int BasePoint2)
        {
            string fun = "Local";

            try
            {
                M_Spel.Local(LocalNumber, LocalPoint1, BasePoint1, LocalPoint2, BasePoint2);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Local(int LocalNumber, string LocalPoint1, string BasePoint1, string LocalPoint2, string BasePoint2)
        {
            string fun = "Local";

            try
            {
                M_Spel.Local(LocalNumber, LocalPoint1, BasePoint1, LocalPoint2, BasePoint2);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void LocalClr(int LocalNumber)
        {
            string fun = "LocalClr";

            try
            {
                M_Spel.LocalClr(LocalNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void LocalDef(int LocalNumber)
        {
            string fun = "LocalDef";

            try
            {
                M_Spel.LocalDef(LocalNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Login(string LoginID, string Password)
        {
            string fun = "Login";

            try
            {
                M_Spel.Login(LoginID, Password);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region M
        public void MCal()
        {
            string fun = "MCal";

            try
            {
                M_Spel.MCal();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool MCalComplete()
        {
            bool result = false;
            string fun = "MCalComplete";

            try
            {
                result = M_Spel.MCalComplete();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Mcordr(int Step1, int Step2, int Step3, int Step4, int Step5, int Step6)
        {
            string fun = "Mcordr";

            try
            {
                M_Spel.Mcordr(Step1, Step2, Step3, Step4, Step5, Step6);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Mcordr(int Step1, int Step2, int Step3, int Step4, int Step5, int Step6, int Step7, int Step8, int Step9)
        {
            string fun = "Mcordr";

            try
            {
                M_Spel.Mcordr(Step1, Step2, Step3, Step4, Step5, Step6, Step7, Step8, Step9);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public int MemIn(int PortNumber)
        {
            int result = 0;
            string fun = "MemIn";

            try
            {
                result = M_Spel.MemIn(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int MemIn(string Label)
        {
            int result = 0;
            string fun = "MemIn";

            try
            {
                result = M_Spel.MemIn(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int MemInW(int PortNumber)
        {
            int result = 0;
            string fun = "MemInW";

            try
            {
                result = M_Spel.MemInW(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int MemInW(string Label)
        {
            int result = 0;
            string fun = "MemInW";

            try
            {
                result = M_Spel.MemInW(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void MemOff(int BitNumber)
        {
            string fun = "MemOff";

            try
            {
                M_Spel.MemOff(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void MemOff(string Label)
        {
            string fun = "MemOff";

            try
            {
                M_Spel.MemOff(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void MemOn(int BitNumber)
        {
            string fun = "MemOn";

            try
            {
                M_Spel.MemOn(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void MemOn(string Label)
        {
            string fun = "MemOn";

            try
            {
                M_Spel.MemOn(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void MemOut(int PortNumber, int Value)
        {
            string fun = "MemOut";

            try
            {
                M_Spel.MemOut(PortNumber, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void MemOut(string Label, int Value)
        {
            string fun = "MemOut";

            try
            {
                M_Spel.MemOut(Label, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void MemOutW(int PortNumber, int Value)
        {
            string fun = "MemOutW";

            try
            {
                M_Spel.MemOutW(PortNumber, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void MemOutW(string Label, int Value)
        {
            string fun = "MemOutW";

            try
            {
                M_Spel.MemOutW(Label, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool MemSw(int BitNumber)
        {
            bool result = false;
            string fun = "MemSw";

            try
            {
                result = M_Spel.MemSw(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool MemSw(string Label)
        {
            bool result = false;
            string fun = "MemSw";

            try
            {
                result = M_Spel.MemSw(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Move(int PointNumber)
        {
            string fun = "Move";

            try
            {
                M_Spel.Move(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Move(SpelPoint Point)
        {
            string fun = "Move";

            try
            {
                M_Spel.Move(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Move(string PointExpr)
        {
            string fun = "Move";

            try
            {
                M_Spel.Move(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Move(SpelPoint Point, string AttribExpr)
        {
            string fun = "Move";

            try
            {
                M_Spel.Move(Point, AttribExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region N
        #endregion

        #region O
        public void Off(int BitNumber)
        {
            string fun = "Off";

            try
            {
                M_Spel.Off(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Off(string Label)
        {
            string fun = "Off";

            try
            {
                M_Spel.Off(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float OLRate(int JointNumber)
        {
            float result = 0;
            string fun = "OLRate";

            try
            {
                result = M_Spel.OLRate(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void On(int BitNumber)
        {
            string fun = "On";

            try
            {
                M_Spel.On(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void On(string Label)
        {
            string fun = "On";

            try
            {
                M_Spel.On(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void OpBCD(int PortNumber, int Value)
        {
            string fun = "OpBCD";

            try
            {
                M_Spel.OpBCD(PortNumber, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void OpBCD(string Label, int Value)
        {
            string fun = "OpBCD";

            try
            {
                M_Spel.OpBCD(Label, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool Oport(int BitNumber)
        {
            bool result = false;
            string fun = "Oport";

            try
            {
                result = M_Spel.Oport(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool Oport(string Label)
        {
            bool result = false;
            string fun = "Oport";

            try
            {
                result = M_Spel.Oport(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int Out(int PortNumber)
        {
            int result = 0;
            string fun = "Out";

            try
            {
                result = M_Spel.Out(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int Out(string Label)
        {
            int result = 0;
            string fun = "Out";

            try
            {
                result = M_Spel.Out(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Out(int PortNumber, int Value)
        {
            string fun = "Out";

            try
            {
                M_Spel.Out(PortNumber, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Out(string Label, int Value)
        {
            string fun = "Out";

            try
            {
                M_Spel.Out(Label, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float OutReal(int WordPortNumber)
        {
            float result = 0;
            string fun = "OutReal";

            try
            {
                result = M_Spel.OutReal(WordPortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void OutReal(int WordPortNumber, float Value)
        {
            string fun = "OutReal";

            try
            {
                M_Spel.OutReal(WordPortNumber, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public int OutW(int PortNumber)
        {
            int result = 0;
            string fun = "OutW";

            try
            {
                result = M_Spel.OutW(PortNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int OutW(string Label)
        {
            int result = 0;
            string fun = "OutW";

            try
            {
                result = M_Spel.OutW(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void OutW(int PortNumber, int Value)
        {
            string fun = "OutW";

            try
            {
                M_Spel.OutW(PortNumber, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void OutW(string Label, int Value)
        {
            string fun = "OutW";

            try
            {
                M_Spel.OutW(Label, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region P
        public float PAgl(int PointNumber, int JointNumber)
        {
            float result = 0;
            string fun = "PAgl";

            try
            {
                result = M_Spel.PAgl(PointNumber, JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float PAgl(SpelPoint Point, int JointNumber)
        {
            float result = 0;
            string fun = "PAgl";

            try
            {
                result = M_Spel.PAgl(Point, JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public float PAgl(string PointExpr, int JointNumber)
        {
            float result = 0;
            string fun = "PAgl";

            try
            {
                result = M_Spel.PAgl(PointExpr, JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Pallet(int PaletNumber, string Point1, string Point2, string Point3, int rows, int columns)
        {
            string fun = "Pallet";

            try
            {
                M_Spel.Pallet(PaletNumber, Point1, Point2, Point3, rows, columns);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Pallet(int PaletNumber, string Point1, string Point2, string Point3, string Point4, int rows, int columns)
        {
            string fun = "Pallet";

            try
            {
                M_Spel.Pallet(PaletNumber, Point1, Point2, Point3, Point4, rows, columns);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Pass(int PointNumber)
        {
            string fun = "Pass";

            try
            {
                M_Spel.Pass(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Pass(string PassExpr)
        {
            string fun = "Pass";

            try
            {
                M_Spel.Pass(PassExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Pause()
        {
            string fun = "Pause";

            try
            {
                M_Spel.Pause();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool PDef(int PointNumber)
        {
            bool result = false;
            string fun = "PDef";

            try
            {
                result = M_Spel.PDef(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void PDel(int PointNumber)
        {
            string fun = "PDel";

            try
            {
                M_Spel.PDel(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PDel(int FirstPointNumber, int LastPointNumber)
        {
            string fun = "PDel";

            try
            {
                M_Spel.PDel(FirstPointNumber, LastPointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float PeakSpeed(int JointNumber)
        {
            float result = 0;
            string fun = "PeakSpeed";

            try
            {
                result = M_Spel.PeakSpeed(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void PeakSpeedClear()
        {
            string fun = "PeakSpeedClear";

            try
            {
                M_Spel.PeakSpeedClear();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PF_Abort(int PartID)
        {
            string fun = "PF_Abort";

            try
            {
                M_Spel.PF_Abort(PartID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PF_Backlight(int FeederNumber, bool State)
        {
            string fun = "PF_Backlight";

            try
            {
                M_Spel.PF_Backlight(FeederNumber, State);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PF_BacklightBrightness(int FeederNumber, int Brightness)
        {
            string fun = "PF_BacklightBrightness";

            try
            {
                M_Spel.PF_BacklightBrightness(FeederNumber, Brightness);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public string PF_Name(int PartID)
        {
            string result = "";
            string fun = "PF_Name";

            try
            {
                result = M_Spel.PF_Name(PartID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int PF_Number(string PartName)
        {
            int result = 0;
            string fun = "PF_Number";

            try
            {
                result = M_Spel.PF_Number(PartName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void PF_Start(int PartID)
        {
            string fun = "PF_Start";

            try
            {
                M_Spel.PF_Start(PartID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PF_Start(int PartID1, int PartID2)
        {
            string fun = "PF_Start";

            try
            {
                M_Spel.PF_Start(PartID1, PartID2);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PF_Start(int PartID1, int PartID2, int PartID3)
        {
            string fun = "PF_Start";

            try
            {
                M_Spel.PF_Start(PartID1, PartID2, PartID3);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PF_Start(int PartID1, int PartID2, int PartID3, int PartID4)
        {
            string fun = "PF_Start";

            try
            {
                M_Spel.PF_Start(PartID1, PartID2, PartID3, PartID4);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PF_Stop(int PartID)
        {
            string fun = "PF_Stop";

            try
            {
                M_Spel.PF_Stop(PartID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public string PLabel(int PointNumber)
        {
            string result = "";
            string fun = "PLabel";

            try
            {
                result = M_Spel.PLabel(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void PLabel(int PointNumber, string PointName)
        {
            string fun = "PLabel";

            try
            {
                M_Spel.PLabel(PointNumber, PointName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Plane(int PlaneNumber, SpelPoint Point)
        {
            string fun = "Plane";

            try
            {
                M_Spel.Plane(PlaneNumber, Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Plane(int PlaneNumber, float X, float Y, float Z, float U, float V, float W)
        {
            string fun = "Plane";

            try
            {
                M_Spel.Plane(PlaneNumber, X, Y, Z, U, V, W);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PlaneClr(int PlaneNumber)
        {
            string fun = "PlaneClr";

            try
            {
                M_Spel.PlaneClr(PlaneNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool PlaneDef(int PlaneNumber)
        {
            bool result = false;
            string fun = "PlaneDef";

            try
            {
                result = M_Spel.PlaneDef(PlaneNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public int Pls(int JointNumber)
        {
            int result = 0;
            string fun = "Pls";

            try
            {
                result = M_Spel.Pls(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void PTCLR()
        {
            string fun = "PTCLR";

            try
            {
                M_Spel.PTCLR();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PTPBoost(int BoostValue)
        {
            string fun = "PTPBoost";

            try
            {
                M_Spel.PTPBoost(BoostValue);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void PTPBoost(int BoostValue, int DepartBoost, int ApproBoost)
        {
            string fun = "PTPBoost";

            try
            {
                M_Spel.PTPBoost(BoostValue, DepartBoost, ApproBoost);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool PTPBoostOK(int PointNumber)
        {
            bool result = false;
            string fun = "PTPBoostOK";

            try
            {
                result = M_Spel.PTPBoostOK(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool PTPBoostOK(SpelPoint Point)
        {
            bool result = false;
            string fun = "PTPBoostOK";

            try
            {
                result = M_Spel.PTPBoostOK(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool PTPBoostOK(string PointExpr)
        {
            bool result = false;
            string fun = "PTPBoostOK";

            try
            {
                result = M_Spel.PTPBoostOK(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void PTran(int JointNumber, int Pulses)
        {
            string fun = "PTran";

            try
            {
                M_Spel.PTran(JointNumber, Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public float PTRQ(int JointNumber)
        {
            float result = 0;
            string fun = "PTRQ";

            try
            {
                result = M_Spel.PTRQ(JointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Pulse(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses)
        {
            string fun = "Pulse";

            try
            {
                M_Spel.Pulse(J1Pulses, J2Pulses, J3Pulses, J4Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Pulse(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses)
        {
            string fun = "Pulse";

            try
            {
                M_Spel.Pulse(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Pulse(int J1Pulses, int J2Pulses, int J3Pulses, int J4Pulses, int J5Pulses, int J6Pulses, int J7Pulses, int J8Pulses, int J9Pulses)
        {
            string fun = "Pulse";

            try
            {
                M_Spel.Pulse(J1Pulses, J2Pulses, J3Pulses, J4Pulses, J5Pulses, J6Pulses, J7Pulses, J8Pulses, J9Pulses);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region Q
        public void Quit(int TaskNumber)
        {
            string fun = "Quit";

            try
            {
                M_Spel.Quit(TaskNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Quit(string TaskName)
        {
            string fun = "Quit";

            try
            {
                M_Spel.Quit(TaskName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region R
        public double RadToDeg(double Radians)
        {
            double result = 0;
            string fun = "RadToDeg";

            try
            {
                result = M_Spel.RadToDeg(Radians);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void RebootController(bool ShowStatusDialog)
        {
            string fun = "RebootController";

            try
            {
                M_Spel.RebootController(ShowStatusDialog);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void RebuildProject()
        {
            string fun = "RebuildProject";

            try
            {
                M_Spel.RebuildProject();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool Recover()
        {
            bool result = false;
            string fun = "Recover";

            try
            {
                result = M_Spel.Recover();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Reset()
        {
            string fun = "Reset";

            try
            {
                M_Spel.Reset();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ResetAbort()
        {
            string fun = "ResetAbort";

            try
            {
                M_Spel.ResetAbort();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Resume(int TaskNumber)
        {
            string fun = "Resume";

            try
            {
                M_Spel.Resume(TaskNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Resume(string TaskName)
        {
            string fun = "Resume";

            try
            {
                M_Spel.Resume(TaskName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void RunDialog(SpelDialogs DialogID)
        {
            string fun = "RunDialog";

            try
            {
                M_Spel.RunDialog(DialogID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void RunDialog(SpelDialogs DialogID, Form Parent)
        {
            string fun = "RunDialog";

            try
            {
                M_Spel.RunDialog(DialogID, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region S
        public void SavePoints(string FileName)
        {
            // 設定指定點編號中定義的點標籤
            string fun = "SavePoints";

            try
            {
                M_Spel.SavePoints(FileName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Sense(string Condition)
        {
            string fun = "Sense";

            try
            {
                M_Spel.Sense(Condition);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetIODef(SpelIOLabelTypes Type, int Index, string Label, string Description)
        {
            string fun = "SetIODef";

            try
            {
                M_Spel.SetIODef(Type, Index, Label, Description);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(int PointNumber, SpelPoint point)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointNumber, point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(int PointNumber, string PointExpr)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointNumber, PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(string PointLabel, SpelPoint Point)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointLabel, Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(string PointLabel, string PointExpr)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointLabel, PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(int PointNumber, float X, float Y, float Z, float U)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointNumber, X, Y, Z, U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(string PointLabel, float X, float Y, float Z, float U)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointLabel, X, Y, Z, U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(int PointNumber, float X, float Y, float Z, float U, float V, float W)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointNumber, X, Y, Z, U, V, W);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(int PointNumber, float X, float Y, float Z, float U, int Local, SpelHand Hand)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointNumber, X, Y, Z, U, Local, Hand);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(string PointLabel, float X, float Y, float Z, float U, float V, float W)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointLabel, X, Y, Z, U, V, W);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(string PointLabel, float X, float Y, float Z, float U, int Local, SpelHand Hand)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointLabel, X, Y, Z, U, Local, Hand);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(int PointNumber, float X, float Y, float Z, float U, float V, float W, float S, float T)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointNumber, X, Y, Z, U, V, W, S, T);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(string PointLabel, float X, float Y, float Z, float U, float V, float W, float S, float T)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointLabel, X, Y, Z, U, V, W, S, T);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(int PointNumber, float X, float Y, float Z, float U, float V, float W, int Local, SpelHand Hand, SpelElbow Elbow, SpelWrist Wrist, int J4Flag, int J6Flag)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointNumber, X, Y, Z, U, V, W, Local, Hand, Elbow, Wrist, J4Flag, J6Flag);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetPoint(string PointLabel, float X, float Y, float Z, float U, float V, float W, int Local, SpelHand Hand, SpelElbow Elbow, SpelWrist Wrist, int J4Flag, int J6Flag)
        {
            string fun = "SetPoint";

            try
            {
                M_Spel.SetPoint(PointLabel, X, Y, Z, U, V, W, Local, Hand, Elbow, Wrist, J4Flag, J6Flag);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SetVar(string VarName, object Value)
        {
            string fun = "SetVar";

            try
            {
                M_Spel.SetVar(VarName, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SFree()
        {
            string fun = "SFree";

            try
            {
                M_Spel.SFree();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SFree(int[] Axes)
        {
            string fun = "SFree";

            try
            {
                M_Spel.SFree(Axes);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ShowWindow(SpelWindows WindowID)
        {
            string fun = "ShowWindow";

            try
            {
                M_Spel.ShowWindow(WindowID);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void ShowWindow(SpelWindows WindowID, Form Parent)
        {
            string fun = "ShowWindow";

            try
            {
                M_Spel.ShowWindow(WindowID, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Shutdown(SpelShutdownMode Mode)
        {
            string fun = "Shutdown";

            try
            {
                M_Spel.Shutdown(Mode);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string Object, SpelSimProps Property, out bool Value)
        {
            string fun = "SimGet";

            Value = false;
            try
            {
                M_Spel.SimGet(Object, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string Object, SpelSimProps Property, out double Value)
        {
            string fun = "SimGet";

            Value = 0;
            try
            {
                M_Spel.SimGet(Object, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string Object, SpelSimProps Property, out int Value)
        {
            string fun = "SimGet";

            Value = 0;
            try
            {
                M_Spel.SimGet(Object, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string Object, SpelSimProps Property, out string Value)
        {
            string fun = "SimGet";

            Value = "";
            try
            {
                M_Spel.SimGet(Object, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string RobotName, string HandName, SpelSimProps Property, out bool Value)
        {
            string fun = "SimGet";

            Value = false;
            try
            {
                M_Spel.SimGet(RobotName, HandName, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string RobotName, string HandName, SpelSimProps Property, out double Value)
        {
            string fun = "SimGet";

            Value = 0;
            try
            {
                M_Spel.SimGet(RobotName, HandName, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string RobotName, string HandName, SpelSimProps Property, out int Value)
        {
            string fun = "SimGet";

            Value = 0;
            try
            {
                M_Spel.SimGet(RobotName, HandName, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimGet(string RobotName, string HandName, SpelSimProps Property, out string Value)
        {
            string fun = "SimGet";

            Value = "";
            try
            {
                M_Spel.SimGet(RobotName, HandName, Property, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimResetCollision()
        {
            string fun = "SimResetCollision";

            try
            {
                M_Spel.SimResetCollision();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string Object, SpelSimProps Property, bool Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(Object, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string Object, SpelSimProps Property, double Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(Object, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string Object, SpelSimProps Property, int Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(Object, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string Object, SpelSimProps Property, string Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(Object, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string RobotName, string HandName, SpelSimProps Property, bool Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(RobotName, HandName, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string RobotName, string HandName, SpelSimProps Property, double Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(RobotName, HandName, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string RobotName, string HandName, SpelSimProps Property, int Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(RobotName, HandName, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSet(string RobotName, string HandName, SpelSimProps Property, string Value)
        {
            string fun = "SimSet";

            try
            {
                M_Spel.SimSet(RobotName, HandName, Property, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSetParent(string Object)
        {
            string fun = "SimSetParent";

            try
            {
                M_Spel.SimSetParent(Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSetParent(string Object, string ParentObject)
        {
            string fun = "SimSetParent";

            try
            {
                M_Spel.SimSetParent(Object, ParentObject);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSetPick(string RobotName, string Object)
        {
            string fun = "SimSetPick";

            try
            {
                M_Spel.SimSetPick(RobotName, Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSetPick(string RobotName, string Object, int ToolNumber)
        {
            string fun = "SimSetPick";

            try
            {
                M_Spel.SimSetPick(RobotName, Object, ToolNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SimSetPlace(string RobotName, string Object)
        {
            string fun = "SimSetPlace";

            try
            {
                M_Spel.SimSetPlace(RobotName, Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SLock()
        {
            string fun = "SLock";

            try
            {
                M_Spel.SLock();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SLock(int[] Axes)
        {
            string fun = "SLock";

            try
            {
                M_Spel.SLock(Axes);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Speed(int PointToPointSpeed)
        {
            string fun = "Speed";

            try
            {
                M_Spel.Speed(PointToPointSpeed);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Speed(int PointToPointSpeed, int JumpDepartSpeed, int JumpApproSpeed)
        {
            string fun = "Speed";

            try
            {
                M_Spel.Speed(PointToPointSpeed, JumpDepartSpeed, JumpApproSpeed);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SpeedR(int RotationSpeed)
        {
            string fun = "SpeedR";

            try
            {
                M_Spel.SpeedR(RotationSpeed);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SpeedS(float LinearSpeed)
        {
            string fun = "SpeedS";

            try
            {
                M_Spel.SpeedS(LinearSpeed);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void SpeedS(float LinearSpeed, float JumpDepartSpeed, float JumpApproSpeed)
        {
            string fun = "SpeedS";

            try
            {
                M_Spel.SpeedS(LinearSpeed, JumpDepartSpeed, JumpApproSpeed);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Start(int ProgramNumber)
        {
            string fun = "Start";

            try
            {
                M_Spel.Start(ProgramNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void StartBGTask(string FuncName)
        {
            string fun = "StartBGTask";

            try
            {
                M_Spel.StartBGTask(FuncName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Stat(int Address)
        {
            string fun = "Stat";

            try
            {
                M_Spel.Stat(Address);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool Stat(int Address, ref int stat)
        {
            bool result = false;
            string fun = "Stat";

            try
            {
                stat = M_Spel.Stat(Address);
                result = true;
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Stop()
        {
            string fun = "Stop";

            try
            {
                M_Spel.Stop();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Stop(SpelStopType StopType)
        {
            string fun = "Stop";

            try
            {
                M_Spel.Stop(StopType);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool Sw(int BitNumber)
        {
            bool result = false;
            string fun = "Sw";

            try
            {
                result = M_Spel.Sw(BitNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool Sw(string Label)
        {
            bool result = false;
            string fun = "Sw";

            try
            {
                result = M_Spel.Sw(Label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

        #region T
        public bool TargetOK(int PointNumber)
        {
            bool result = false;
            string fun = "TargetOK";

            try
            {
                result = M_Spel.TargetOK(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool TargetOK(SpelPoint Point)
        {
            bool result = false;
            string fun = "TargetOK";

            try
            {
                result = M_Spel.TargetOK(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool TargetOK(string PointExpr)
        {
            bool result = false;
            string fun = "TargetOK";

            try
            {
                result = M_Spel.TargetOK(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool TasksExecuting()
        {
            bool result = false;
            string fun = "TasksExecuting";

            try
            {
                result = M_Spel.TasksExecuting();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelTaskState TaskState(int TaskNumber)
        {
            SpelTaskState result = SpelTaskState.Aborted;
            string fun = "TaskState";

            try
            {
                result = M_Spel.TaskState(TaskNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelTaskState TaskState(string TaskName)
        {
            SpelTaskState result = SpelTaskState.Aborted;
            string fun = "TaskState";

            try
            {
                result = M_Spel.TaskState(TaskName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void TeachPoint(string PointFile, int PointNumber, string Prompt)
        {
            string fun = "TeachPoint";

            try
            {
                M_Spel.TeachPoint(PointFile, PointNumber, Prompt);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TeachPoint(string PointFile, string PointName, string Prompt)
        {
            string fun = "TeachPoint";

            try
            {
                M_Spel.TeachPoint(PointFile, PointName, Prompt);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TeachPoint(string PointFile, int PointNumber, string Prompt, Form Parent)
        {
            string fun = "TeachPoint";

            try
            {
                M_Spel.TeachPoint(PointFile, PointNumber, Prompt, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TeachPoint(string PointFile, string PointName, string Prompt, Form Parent)
        {
            string fun = "TeachPoint";

            try
            {
                M_Spel.TeachPoint(PointFile, PointName, Prompt, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TGo(int PointNumber)
        {
            string fun = "TGo";

            try
            {
                M_Spel.TGo(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TGo(SpelPoint Point)
        {
            string fun = "TGo";

            try
            {
                M_Spel.TGo(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TGo(string PointExpr)
        {
            string fun = "TGo";

            try
            {
                M_Spel.TGo(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TGo(SpelPoint Point, string AttribExpr)
        {
            string fun = "TGo";

            try
            {
                M_Spel.TGo(Point, AttribExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Till(string Condition)
        {
            string fun = "Till";

            try
            {
                M_Spel.Till(Condition);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool TillOn()
        {
            bool result = false;
            string fun = "TillOn";

            try
            {
                result = M_Spel.TillOn();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void TLClr(int ToolNumber)
        {
            string fun = "TLClr";

            try
            {
                M_Spel.TLClr(ToolNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TLDef(int ToolNumber)
        {
            string fun = "TLDef";

            try
            {
                M_Spel.TLDef(ToolNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TLSet(int ToolNumber, SpelPoint Point)
        {
            string fun = "TLSet";

            try
            {
                M_Spel.TLSet(ToolNumber, Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TLSet(int ToolNumber, float X, float Y, float Z, float U, float V, float W)
        {
            string fun = "TLSet";

            try
            {
                M_Spel.TLSet(ToolNumber, X, Y, Z, U, V, W);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TMove(int PointNumber)
        {
            string fun = "TMove";

            try
            {
                M_Spel.TMove(PointNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TMove(SpelPoint Point)
        {
            string fun = "TMove";

            try
            {
                M_Spel.TMove(Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TMove(string PointExpr)
        {
            string fun = "TMove";

            try
            {
                M_Spel.TMove(PointExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void TMove(SpelPoint Point, string AttribExpr)
        {
            string fun = "TMove";

            try
            {
                M_Spel.TMove(Point, AttribExpr);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Tool(int ToolNumber)
        {
            string fun = "Tool";

            try
            {
                M_Spel.Tool(ToolNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool TrapStop()
        {
            bool result = false;
            string fun = "TrapStop";

            try
            {
                result = M_Spel.TrapStop();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public bool TW()
        {
            bool result = false;
            string fun = "TW";

            try
            {
                result = M_Spel.TW();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

        #region U
        public bool UserHasRight(SpelUserRights Right)
        {
            bool result = false;
            string fun = "UserHasRight";

            try
            {
                result = M_Spel.UserHasRight(Right);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        #endregion

        #region V
        public void VCal(string Calib)
        {
            string fun = "VCal";

            try
            {
                M_Spel.VCal(Calib);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCal(string Calib, Form Parent)
        {
            string fun = "VCal";

            try
            {
                M_Spel.VCal(Calib, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCal(string Calib, out int Status)
        {
            string fun = "VCal";

            Status = 0;
            try
            {
                M_Spel.VCal(Calib, out Status);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCal(string Calib, Form Parent, out int Status)
        {
            string fun = "VCal";

            Status = 0;
            try
            {
                M_Spel.VCal(Calib, Parent, out Status);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCalPoints(string Calib)
        {
            string fun = "VCalPoints";

            try
            {
                M_Spel.VCalPoints(Calib);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCalPoints(string Calib, Form Parent)
        {
            string fun = "VCalPoints";

            try
            {
                M_Spel.VCalPoints(Calib, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCalPoints(string Calib, out int Status)
        {
            string fun = "VCalPoints";

            Status = 0;
            try
            {
                M_Spel.VCalPoints(Calib, out Status);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCalPoints(string Calib, Form Parent, out int Status)
        {
            string fun = "VCalPoints";

            Status = 0;
            try
            {
                M_Spel.VCalPoints(Calib, Parent, out Status);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCls()
        {
            string fun = "VCls";

            try
            {
                M_Spel.VCls();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCreateCalibration(int Camera, string CalibName)
        {
            string fun = "VCreateCalibration";

            try
            {
                M_Spel.VCreateCalibration(Camera, CalibName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCreateCalibration(int Camera, string CalibName, string CopyCalibName)
        {
            string fun = "VCreateCalibration";

            try
            {
                M_Spel.VCreateCalibration(Camera, CalibName, CopyCalibName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCreateObject(string Sequence, string ObjectName, SpelVisionObjectTypes ObjectType)
        {
            string fun = "VCreateObject";

            try
            {
                M_Spel.VCreateObject(Sequence, ObjectName, ObjectType);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCreateSequence(int Camera, string SequenceName)
        {
            string fun = "VCreateSequence";

            try
            {
                M_Spel.VCreateSequence(Camera, SequenceName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VCreateSequence(int Camera, string SequenceName, string CopySequenceName)
        {
            string fun = "VCreateSequence";

            try
            {
                M_Spel.VCreateSequence(Camera, SequenceName, CopySequenceName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefArm(int ArmNumber, SpelArmDefType ArmDefType, SpelArmDefMode ArmDefMode, string Sequence, double Rotation, double TargetTolerance)
        {
            string fun = "VDefArm";

            try
            {
                M_Spel.VDefArm(ArmNumber, ArmDefType, ArmDefMode, Sequence, Rotation, TargetTolerance);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefArm(int ArmNumber, SpelArmDefType ArmDefType, SpelArmDefMode ArmDefMode, string Sequence, double Rotation, double TargetTolerance, Form Parent)
        {
            string fun = "VDefArm";

            try
            {
                M_Spel.VDefArm(ArmNumber, ArmDefType, ArmDefMode, Sequence, Rotation, TargetTolerance, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefArm(int ArmNumber, SpelArmDefType ArmDefType, SpelArmDefMode ArmDefMode, string Sequence, double Rotation, double TargetTolerance, int RobotSpeed, int RobotAccel, SpelVDefShowWarning ShowWarning)
        {
            string fun = "VDefArm";

            try
            {
                M_Spel.VDefArm(ArmNumber, ArmDefType, ArmDefMode, Sequence, Rotation, TargetTolerance, RobotSpeed, RobotAccel, ShowWarning);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefArm(int ArmNumber, SpelArmDefType ArmDefType, SpelArmDefMode ArmDefMode, string Sequence, double Rotation, double TargetTolerance, int RobotSpeed, int RobotAccel, SpelVDefShowWarning ShowWarning, Form Parent)
        {
            string fun = "VDefArm";

            try
            {
                M_Spel.VDefArm(ArmNumber, ArmDefType, ArmDefMode, Sequence, Rotation, TargetTolerance, RobotSpeed, RobotAccel, ShowWarning, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefGetMotionRange(out double MaxMoveDist, out double MaxPoseDiffAngle, out int LJMMode)
        {
            string fun = "VDefGetMotionRange";

            MaxMoveDist = 0;
            MaxPoseDiffAngle = 0;
            LJMMode = 0;
            try
            {
                M_Spel.VDefGetMotionRange(out MaxMoveDist, out MaxPoseDiffAngle, out LJMMode);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefLocal(int LocalNumber, SpelLocalDefType LocalDefType, SpelCalPlateType CalPlateType, string Sequence, double TargetTolerance, int CameraTool, SpelPoint RefPoint)
        {
            string fun = "VDefLocal";

            try
            {
                M_Spel.VDefLocal(LocalNumber, LocalDefType, CalPlateType, Sequence, TargetTolerance, CameraTool, RefPoint);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefLocal(int LocalNumber, SpelLocalDefType LocalDefType, SpelCalPlateType CalPlateType, string Sequence, double TargetTolerance, int CameraTool, SpelPoint RefPoint, Form Parent)
        {
            string fun = "VDefLocal";

            try
            {
                M_Spel.VDefLocal(LocalNumber, LocalDefType, CalPlateType, Sequence, TargetTolerance, CameraTool, RefPoint, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefLocal(int LocalNumber, SpelLocalDefType LocalDefType, SpelCalPlateType CalPlateType, string Sequence, double TargetTolerance, int CameraTool, SpelPoint RefPoint, int RobotSpeed, int RobotAccel)
        {
            string fun = "VDefLocal";

            try
            {
                M_Spel.VDefLocal(LocalNumber, LocalDefType, CalPlateType, Sequence, TargetTolerance, CameraTool, RefPoint, RobotSpeed, RobotAccel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefLocal(int LocalNumber, SpelLocalDefType LocalDefType, SpelCalPlateType CalPlateType, string Sequence, double TargetTolerance, int CameraTool, SpelPoint RefPoint, int RobotSpeed, int RobotAccel, Form Parent)
        {
            string fun = "VDefLocal";

            try
            {
                M_Spel.VDefLocal(LocalNumber, LocalDefType, CalPlateType, Sequence, TargetTolerance, CameraTool, RefPoint, RobotSpeed, RobotAccel, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefSetMotionRange(double MaxMoveDist, double MaxPoseDiffAngle, int LJMMode)
        {
            string fun = "VDefSetMotionRange";

            try
            {
                M_Spel.VDefSetMotionRange(MaxMoveDist, MaxPoseDiffAngle, LJMMode);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefTool(int ToolNumber, SpelToolDefType ToolDefType, string Sequence, string Object)
        {
            string fun = "VDefTool";

            try
            {
                M_Spel.VDefTool(ToolNumber, ToolDefType, Sequence, Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefTool(int ToolNumber, SpelToolDefType ToolDefType, string Sequence, string Object, Form Parent)
        {
            string fun = "VDefTool";

            try
            {
                M_Spel.VDefTool(ToolNumber, ToolDefType, Sequence, Object, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefTool(int ToolNumber, SpelToolDefType ToolDefType, string Sequence, double FinalAngle, double InitAngle, double TargetTolerance)
        {
            string fun = "VDefTool";

            try
            {
                M_Spel.VDefTool(ToolNumber, ToolDefType, Sequence, FinalAngle, InitAngle, TargetTolerance);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefTool(int ToolNumber, SpelToolDefType ToolDefType, string Sequence, double FinalAngle, double InitAngle, double TargetTolerance, Form Parent)
        {
            string fun = "VDefTool";

            try
            {
                M_Spel.VDefTool(ToolNumber, ToolDefType, Sequence, FinalAngle, InitAngle, TargetTolerance, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefTool(int ToolNumber, SpelToolDefType ToolDefType, string Sequence, double FinalAngle, double InitAngle, double TargetTolerance, int RobotSpeed, int RobotAccel)
        {
            string fun = "VDefTool";

            try
            {
                M_Spel.VDefTool(ToolNumber, ToolDefType, Sequence, FinalAngle, InitAngle, TargetTolerance, RobotSpeed, RobotAccel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefTool(int ToolNumber, SpelToolDefType ToolDefType, string Sequence, double FinalAngle, double InitAngle, double TargetTolerance, int RobotSpeed, int RobotAccel, Form Parent)
        {
            string fun = "VDefTool";

            try
            {
                M_Spel.VDefTool(ToolNumber, ToolDefType, Sequence, FinalAngle, InitAngle, TargetTolerance, RobotSpeed, RobotAccel, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefToolXYZ(int ToolNumber, int LocalNumber, int Point1, int Point2, string Sequence1, string Sequence2, double FinalAngle, double InitAngle, double TargetTolerance, int RobotSpeed, int RobotAccel)
        {
            string fun = "VDefToolXYZ";

            try
            {
                M_Spel.VDefToolXYZ(ToolNumber, LocalNumber, Point1, Point2, Sequence1, Sequence2, FinalAngle, InitAngle, TargetTolerance, RobotSpeed, RobotAccel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefToolXYZ(int ToolNumber, int LocalNumber, int Point1, int Point2, string Sequence1, string Sequence2, double FinalAngle, double InitAngle, double TargetTolerance, int RobotSpeed, int RobotAccel, Form Parent)
        {
            string fun = "VDefToolXYZ";

            try
            {
                M_Spel.VDefToolXYZ(ToolNumber, LocalNumber, Point1, Point2, Sequence1, Sequence2, FinalAngle, InitAngle, TargetTolerance, RobotSpeed, RobotAccel, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDefToolXYZUVW(int ToolNumber1, int ToolNumber2, int ToolNumber3, SpelToolDefType3D ToolDefType3D)
        {
            string fun = "VDefToolXYZUVW";

            try
            {
                M_Spel.VDefToolXYZUVW(ToolNumber1, ToolNumber2, ToolNumber3, ToolDefType3D);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDeleteCalibration(string Calib)
        {
            string fun = "VDeleteCalibration";

            try
            {
                M_Spel.VDeleteCalibration(Calib);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDeleteObject(string Sequence, string Object)
        {
            string fun = "VDeleteObject";

            try
            {
                M_Spel.VDeleteObject(Sequence, Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VDeleteSequence(string Sequence)
        {
            string fun = "VDeleteSequence";

            try
            {
                M_Spel.VDeleteSequence(Sequence);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VEditWindow(string Sequence, string Object)
        {
            string fun = "VEditWindow";

            try
            {
                M_Spel.VEditWindow(Sequence, Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VEditWindow(string Sequence, string Object, Form Parent)
        {
            string fun = "VEditWindow";

            try
            {
                M_Spel.VEditWindow(Sequence, Object, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, SpelVisionProps PropCode, out bool Value)
        {
            string fun = "VGet";

            Value = false;
            try
            {
                M_Spel.VGet(Sequence, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, SpelVisionProps PropCode, out double Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, SpelVisionProps PropCode, out float Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, SpelVisionProps PropCode, out int Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, SpelVisionProps PropCode, out string Value)
        {
            string fun = "VGet";

            Value = "";
            try
            {
                M_Spel.VGet(Sequence, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, out bool Value)
        {
            string fun = "VGet";

            Value = false;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, out double Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, out float Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, out int Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, out string Value)
        {
            string fun = "VGet";

            Value = "";
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, out System.Drawing.Color Value)
        {
            string fun = "VGet";

            Value = System.Drawing.Color.Red;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, int Result, out bool Value)
        {
            string fun = "VGet";

            Value = false;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, Result, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, int Result, out double Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, Result, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, int Result, out float Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, Result, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, int Result, out int Value)
        {
            string fun = "VGet";

            Value = 0;
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, Result, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGet(string Sequence, string Object, SpelVisionProps PropCode, int Result, out string Value)
        {
            string fun = "VGet";

            Value = "";
            try
            {
                M_Spel.VGet(Sequence, Object, PropCode, Result, out Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetCameraXYU(string Sequence, string Object, int Result, out bool Found, out float X, out float Y, out float U)
        {
            string fun = "VGetCameraXYU";

            Found = false;
            X = 0; 
            Y = 0;
            U = 0;
            try
            {
                M_Spel.VGetCameraXYU(Sequence, Object, Result, out Found, out X, out Y, out U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetEdgeCameraXYU(string Sequence, string Object, int Result, out bool Found, out float X, out float Y, out float U)
        {
            string fun = "VGetEdgeCameraXYU";

            Found = false;
            X = 0;
            Y = 0;
            U = 0;
            try
            {
                M_Spel.VGetEdgeCameraXYU(Sequence, Object, Result, out Found, out X, out Y, out U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetEdgePixelXYU(string Sequence, string Object, int Result, out bool Found, out float X, out float Y, out float U)
        {
            string fun = "VGetEdgePixelXYU";

            Found = false;
            X = 0;
            Y = 0;
            U = 0;
            try
            {
                M_Spel.VGetEdgePixelXYU(Sequence, Object, Result, out Found, out X, out Y, out U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetEdgeRobotXYU(string Sequence, string Object, int Result, out bool Found, out float X, out float Y, out float U)
        {
            string fun = "VGetEdgeRobotXYU";

            Found = false;
            X = 0;
            Y = 0;
            U = 0;
            try
            {
                M_Spel.VGetEdgeRobotXYU(Sequence, Object, Result, out Found, out X, out Y, out U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetExtrema(string Sequence, string Object, int Result, out float MinX, out float MaxX, out float MinY, out float MaxY)
        {
            string fun = "VGetExtrema";

            MinX = 0;
            MaxX = 0;
            MinY = 0;
            MaxY = 0;
            try
            {
                M_Spel.VGetExtrema(Sequence, Object, Result, out MinX, out MaxX, out MinY, out MaxY);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetModelWin(string Sequence, string Object, out int Left, out int Top, out int Width, out int Height)
        {
            string fun = "VGetModelWin";

            Left = 0;
            Top = 0;
            Width = 0;
            Height = 0;
            try
            {
                M_Spel.VGetModelWin(Sequence, Object, out Left, out Top, out Width, out Height);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetPixelToCamera(string Calibration, float PixelX, float PixelY, float Angle, out float CameraX, out float CameraY, out float CameraU)
        {
            string fun = "VGetPixelToCamera";

            CameraX = 0;
            CameraY = 0;
            CameraU = 0;
            try
            {
                M_Spel.VGetPixelToCamera(Calibration, PixelX, PixelY, Angle, out CameraX, out CameraY, out CameraU);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetPixelToRobot(string Calibration, float PixelX, float PixelY, float Angle, out float RobotX, out float RobotY, out float RobotU)
        {
            string fun = "VGetPixelToRobot";

            RobotX = 0;
            RobotY = 0;
            RobotU = 0;
            try
            {
                M_Spel.VGetPixelToRobot(Calibration, PixelX, PixelY, Angle, out RobotX, out RobotY, out RobotU);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetPixelXYU(string Sequence, string Object, int Result, out bool Found, out float X, out float Y, out float U)
        {
            string fun = "VGetPixelXYU";

            Found = false;
            X = 0;
            Y = 0;
            U = 0;
            try
            {
                M_Spel.VGetPixelXYU(Sequence, Object, Result, out Found, out X, out Y, out U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetRobotPlacePos(string Sequence, string Object, int Result, out bool Found, out SpelPoint Point)
        {
            string fun = "VGetRobotPlacePos";

            Found = false;
            Point = null;
            try
            {
                M_Spel.VGetRobotPlacePos(Sequence, Object, Result, out Found, out Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetRobotPlaceTargetPos(string Sequence, string Object, out SpelPoint Point)
        {
            string fun = "VGetRobotPlaceTargetPos";

            Point = null;
            try
            {
                M_Spel.VGetRobotPlaceTargetPos(Sequence, Object, out Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetRobotToolXYU(string Sequence, string Object, int Result, out bool Found, out float X, out float Y, out float U)
        {
            string fun = "VGetRobotToolXYU";

            Found = false;
            X = 0;
            Y = 0;
            U = 0;
            try
            {
                M_Spel.VGetRobotToolXYU(Sequence, Object, Result, out Found, out X, out Y, out U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetRobotXYU(string Sequence, string Object, int Result, out bool Found, out float X, out float Y, out float U)
        {
            string fun = "VGetRobotXYU";

            Found = false;
            X = 0;
            Y = 0;
            U = 0;
            try
            {
                M_Spel.VGetRobotXYU(Sequence, Object, Result, out Found, out X, out Y, out U);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGetSearchWin(string Sequence, string Object, out int Left, out int Top, out int Width, out int Height)
        {
            string fun = "VGetSearchWin";

            Left = 0;
            Top = 0;
            Width = 0;
            Height = 0;
            try
            {
                M_Spel.VGetSearchWin(Sequence, Object, out Left, out Top, out Width, out Height);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGoCenter(string Sequence, int LocalNumber, double TargetTolerance)
        {
            string fun = "VGoCenter";

            try
            {
                M_Spel.VGoCenter(Sequence, LocalNumber, TargetTolerance);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGoCenter(string Sequence, int LocalNumber, double TargetTolerance, Form Parent)
        {
            string fun = "VGoCenter";

            try
            {
                M_Spel.VGoCenter(Sequence, LocalNumber, TargetTolerance, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGoCenter(string Sequence, int LocalNumber, double TargetTolerance, int RobotSpeed, int RobotAccel)
        {
            string fun = "VGoCenter";

            try
            {
                M_Spel.VGoCenter(Sequence, LocalNumber, TargetTolerance, RobotSpeed, RobotAccel);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VGoCenter(string Sequence, int LocalNumber, double TargetTolerance, int RobotSpeed, int RobotAccel, Form Parent)
        {
            string fun = "VGoCenter";

            try
            {
                M_Spel.VGoCenter(Sequence, LocalNumber, TargetTolerance, RobotSpeed, RobotAccel, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VLoad()
        {
            string fun = "VLoad";

            try
            {
                M_Spel.VLoad();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VLoadModel(string Sequence, string Object, string Path)
        {
            string fun = "VLoadModel";

            try
            {
                M_Spel.VLoadModel(Sequence, Object, Path);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VRun(string Sequence)
        {
            string fun = "VRun";

            try
            {
                M_Spel.VRun(Sequence);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSave()
        {
            string fun = "VSave";

            try
            {
                M_Spel.VSave();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSaveImage(string Sequence, string Path)
        {
            string fun = "VSaveImage";

            try
            {
                M_Spel.VSaveImage(Sequence, Path);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSaveImage(string Sequence, string Path, bool WithGraphics)
        {
            string fun = "VSaveImage";

            try
            {
                M_Spel.VSaveImage(Sequence, Path, WithGraphics);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSaveModel(string Sequence, string Object, string Path)
        {
            string fun = "VSaveModel";

            try
            {
                M_Spel.VSaveModel(Sequence, Object, Path);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, SpelVisionProps PropCode, bool Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, SpelVisionProps PropCode, double Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, SpelVisionProps PropCode, float Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, SpelVisionProps PropCode, int Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, SpelVisionProps PropCode, string Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, string Object, SpelVisionProps PropCode, bool Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, Object, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, string Object, SpelVisionProps PropCode, double Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, Object, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, string Object, SpelVisionProps PropCode, float Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, Object, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, string Object, SpelVisionProps PropCode, int Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, Object, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, string Object, SpelVisionProps PropCode, string Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, Object, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSet(string Sequence, string Object, SpelVisionProps PropCode, System.Drawing.Color Value)
        {
            string fun = "VSet";

            try
            {
                M_Spel.VSet(Sequence, Object, PropCode, Value);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSetModelWin(string Sequence, string Object, int Left, int Top, int Width, int Height)
        {
            string fun = "VSetModelWin";

            try
            {
                M_Spel.VSetModelWin(Sequence, Object, Left, Top, Width, Height);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSetRobotPlaceTargetPos(string Sequence, string Object, SpelPoint Point)
        {
            string fun = "VSetRobotPlaceTargetPos";

            try
            {
                M_Spel.VSetRobotPlaceTargetPos(Sequence, Object, Point);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VSetSearchWin(string Sequence, string Object, int Left, int Top, int Width, int Height)
        {
            string fun = "VSetSearchWin";

            try
            {
                M_Spel.VSetSearchWin(Sequence, Object, Left, Top, Width, Height);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VShowModel(string Sequence, string Object)
        {
            string fun = "VShowModel";

            try
            {
                M_Spel.VShowModel(Sequence, Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VShowModel(string Sequence, string Object, Form Parent)
        {
            string fun = "VShowModel";

            try
            {
                M_Spel.VShowModel(Sequence, Object, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VShowSequence(string Sequence)
        {
            string fun = "VShowSequence";

            try
            {
                M_Spel.VShowSequence(Sequence);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VStatsReset(string Sequence)
        {
            string fun = "VStatsReset";

            try
            {
                M_Spel.VStatsReset(Sequence);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VStatsResetAll()
        {
            string fun = "VStatsResetAll";

            try
            {
                M_Spel.VStatsResetAll();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VStatsSave()
        {
            string fun = "VStatsSave";

            try
            {
                M_Spel.VStatsSave();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VStatsShow(string Sequence)
        {
            string fun = "VStatsShow";

            try
            {
                M_Spel.VStatsShow(Sequence);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VStatsShow(string Sequence, Form Parent)
        {
            string fun = "VStatsShow";

            try
            {
                M_Spel.VStatsShow(Sequence, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VTeach(string Sequence, string Object, out int Status)
        {
            string fun = "VTeach";

            Status = 0;
            try
            {
                M_Spel.VTeach(Sequence, Object, out Status);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VTeach(string Sequence, string Object, bool AddSample, bool KeepDontCares, out int Status)
        {
            string fun = "VTeach";

            Status = 0;
            try
            {
                M_Spel.VTeach(Sequence, Object, AddSample, KeepDontCares, out Status);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VTrain(string Sequence)
        {
            string fun = "VTrain";

            try
            {
                M_Spel.VTrain(Sequence);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VTrain(string Sequence, int Flags)
        {
            string fun = "VTrain";

            try
            {
                M_Spel.VTrain(Sequence, Flags);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VTrain(string Sequence, string Object)
        {
            string fun = "VTrain";

            try
            {
                M_Spel.VTrain(Sequence, Object);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VTrain(string Sequence, string Object, int Flags)
        {
            string fun = "VTrain";

            try
            {
                M_Spel.VTrain(Sequence, Object, Flags);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void VTrain(string Sequence, string Object, int Flags, Form Parent)
        {
            string fun = "VTrain";

            try
            {
                M_Spel.VTrain(Sequence, Object, Flags, Parent);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region W
        public void WaitCommandComplete()
        {
            string fun = "WaitCommandComplete";

            try
            {
                M_Spel.WaitCommandComplete();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void WaitMem(int BitNumber, bool Condition, float Timeout)
        {
            string fun = "WaitMem";

            try
            {
                M_Spel.WaitMem(BitNumber, Condition, Timeout);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void WaitMem(string Label, bool Condition, float Timeout)
        {
            string fun = "WaitMem";

            try
            {
                M_Spel.WaitMem(Label, Condition, Timeout);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void WaitSw(int BitNumber, bool Condition, float Timeout)
        {
            string fun = "WaitSw";

            try
            {
                M_Spel.WaitSw(BitNumber, Condition, Timeout);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void WaitSw(string Label, bool Condition, float Timeout)
        {
            string fun = "WaitSw";

            try
            {
                M_Spel.WaitSw(Label, Condition, Timeout);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public SpelTaskState WaitTaskDone(int TaskNumber)
        {
            SpelTaskState result = SpelTaskState.Aborted;
            string fun = "WaitTaskDone";

            try
            {
                result = M_Spel.WaitTaskDone(TaskNumber);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public SpelTaskState WaitTaskDone(string TaskName)
        {
            SpelTaskState result = SpelTaskState.Aborted;
            string fun = "WaitTaskDone";

            try
            {
                result = M_Spel.WaitTaskDone(TaskName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Weight(float PayloadWeight, float ArmLength)
        {
            string fun = "Weight";

            try
            {
                M_Spel.Weight(PayloadWeight, ArmLength);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Weight(float PayloadWeight, SpelAxis Axis)
        {
            string fun = "Weight";

            try
            {
                M_Spel.Weight(PayloadWeight, Axis);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region X
        public void Xqt(string FuncName)
        {
            string fun = "Xqt";

            try
            {
                M_Spel.Xqt(FuncName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Xqt(int TaskNumber, string FuncName)
        {
            string fun = "Xqt";

            try
            {
                M_Spel.Xqt(TaskNumber, FuncName);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Xqt(string FuncName, SpelTaskType TaskType)
        {
            string fun = "Xqt";

            try
            {
                M_Spel.Xqt(FuncName, TaskType);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void Xqt(int TaskNumber, string FuncName, SpelTaskType TaskType)
        {
            string fun = "Xqt";

            try
            {
                M_Spel.Xqt(TaskNumber, FuncName, TaskType);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void XYLim(float XLowerLimit, float XUpperLimit, float YLowerLimit, float YUpperLimit)
        {
            string fun = "XYLim";

            try
            {
                M_Spel.XYLim(XLowerLimit, XUpperLimit, YLowerLimit, YUpperLimit);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void XYLim(float XLowerLimit, float XUpperLimit, float YLowerLimit, float YUpperLimit, float ZLowerLimit, float ZUpperLimit)
        {
            string fun = "XYLim";

            try
            {
                M_Spel.XYLim(XLowerLimit, XUpperLimit, YLowerLimit, YUpperLimit, ZLowerLimit, ZUpperLimit);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void XYLimClr()
        {
            string fun = "XYLimClr";

            try
            {
                M_Spel.XYLimClr();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public void XYLimDef()
        {
            string fun = "XYLimDef";

            try
            {
                M_Spel.XYLimDef();
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion

        #region Y
        #endregion

        #region Z
        #endregion

        #region Other
        public void Set_Speed_Factor(int p2p_speed)
        {
            string cmd = "";

            cmd = string.Format("SpeedFactor {0:d}", p2p_speed);
            ExecuteCommand(cmd);
        }
        public void Set_Speed(int p2p_speed)
        {
            Speed(p2p_speed);
        }
        public int Get_Speed()
        {
            int result = 0;
            result = GetSpeed(0);
            return result;
        }

        public void Set_SpeedR(int p2p_speed)
        {
            SpeedR(p2p_speed);
        }
        public int Get_SpeedR()
        {
            int result = 0;

            result = 0;// M_Spel.GetSpeed(0);
            return result;
        }

        public void Set_SpeedS(float p2p_speed)
        {
            SpeedS(p2p_speed);
        }
        public float Get_SpeedS()
        {
            int result = 0;

            result = 0;
            return result;
        }

        public string Get_Label(int no)
        {
            // 取得指定點編號中定義的點標籤
            string result = "";
            string fun = "Get_Label";

            try
            {
                result = PLabel(no);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Set_Label(int no, string label)
        {
            // 設定指定點編號中定義的點標籤
            string fun = "Set_Label";

            try
            {
                M_Spel.PLabel(no, label);
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        public bool Get_Status(ref TRobot_Status status)
        {
            bool result = true;

            for (int i = 0; i < 3; i++)
                if (!Stat(i, ref status.Data[i])) result = false;
            return result;
        }
        public void Set_Accel(int accel, int decel)
        {
            Accel(accel, decel);
        }
        public void Set_AccelR(float accel, float decel)
        {
            AccelR(accel, decel);
        }
        public void Set_AccelS(float accel, float decel)
        {
            AccelS(accel, decel);
        }
        public bool Set_Project_Name(string project_name)
        {
            bool result = false;
            string fun = "Set_Project_Name";

            try
            {
                M_Spel.Project = project_name;
                result = true;
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
            return result;
        }
        public void Set_OperationMode(SpelOperationMode mode)
        {
            string fun = "Set_OperationMode";

            try
            {
                M_Spel.OperationMode = mode;
            }
            catch (SpelException ex)
            {
                Log_Add(fun, ex.Message, emLog_Type.Error);
            }
        }
        #endregion
    }

    public class TRobot_Status
    {
        public int[] Data = new int[3];

        #region Data0
        public int Curr_prog //工作 1~16 為執行中(Xqt)或處於 Halt 狀態
        {
            get
            {
                return 0;
            }
        }
        public bool Running //工作執行中
        {
            get
            {
                return Get_Bit(Data, 0, 16);
            }
        }
        public bool Paused //暫停狀態
        {
            get
            {
                return Get_Bit(Data, 0, 17);
            }
        }
        public bool Error //錯誤狀態
        {
            get
            {
                return Get_Bit(Data, 0, 18);
            }
        }
        public bool Teach_Mode //TEACH 模式
        {
            get
            {
                return Get_Bit(Data, 0, 19);
            }
        }
        public bool EStop //緊急停止狀態
        {
            get
            {
                return Get_Bit(Data, 0, 20);
            }
        }
        public bool Power_Low //低功率模式(Power Low)
        {
            get
            {
                return Get_Bit(Data, 0, 21);
            }
        }
        public bool Safe_Door //安全門輸入為「開」
        {
            get
            {
                return Get_Bit(Data, 0, 22);
            }
        }
        public bool Enabled //Enable 開關為「開」
        {
            get
            {
                return Get_Bit(Data, 0, 23);
            }
        }
        public bool Space0_24 //未定義
        {
            get
            {
                return Get_Bit(Data, 0, 24);
            }
        }
        public bool Space0_25 //未定義
        {
            get
            {
                return Get_Bit(Data, 0, 25);
            }
        }
        public bool Test_Mode //測試模式
        {
            get
            {
                return Get_Bit(Data, 0, 26);
            }
        }
        public bool Space0_27 //T2 模式狀態
        {
            get
            {
                return Get_Bit(Data, 0, 27);
            }
        }
        public bool Space0_28 //未定義
        {
            get
            {
                return Get_Bit(Data, 0, 28);
            }
        }
        public bool Space0_29 //未定義
        {
            get
            {
                return Get_Bit(Data, 0, 29);
            }
        }
        public bool Space0_30 //未定義
        {
            get
            {
                return Get_Bit(Data, 0, 30);
            }
        }
        public bool Space0_31 //未定義
        {
            get
            {
                return Get_Bit(Data, 0, 31);
            }
        }
        #endregion

        #region Data1
        public bool Space1_00 //因 Jump...Sense 陳述式的條件成立而停於目標坐標上方的歷程記錄。(若執行下一個 Jump 陳述式，則刪除此歷程記錄。)
        {
            get
            {
                return Get_Bit(Data, 1, 0);
            }
        }
        public bool Space1_01 //因 Go/Jump/Move...Till 陳述式的條件成立而在動作途中停止的歷程記錄。(若執行下一個 Go/Jump/Move...Till 陳述式，則刪除該歷程記錄。)
        {
            get
            {
                return Get_Bit(Data, 1, 1);
            }
        }
        public bool Space1_02 //未定義
        {
            get
            {
                return Get_Bit(Data, 1, 2);
            }
        }
        public bool Space1_03 //因 Trap 陳述式的條件成立而在動作途中停止的歷程記錄
        {
            get
            {
                return Get_Bit(Data, 1, 3);
            }
        }
        public bool Motor_On //Motor On 狀態
        {
            get
            {
                return Get_Bit(Data, 1, 4);
            }
        }
        public bool At_Home //目前位於 Home 位置
        {
            get
            {
                return Get_Bit(Data, 1, 5);
            }
        }
        public bool Power_Low2 //低功率狀態
        {
            get
            {
                return Get_Bit(Data, 1, 6);
            }
        }
        public bool Space1_07 //未定義
        {
            get
            {
                return Get_Bit(Data, 1, 7);
            }
        }
        public bool J4_On //第4關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 8);
            }
        }
        public bool J3_On //第3關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 9);
            }
        }
        public bool J2_On //第2關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 10);
            }
        }
        public bool J1_On //第1關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 11);
            }
        }
        public bool J6_On //第6關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 12);
            }
        }
        public bool J5_On //第5關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 13);
            }
        }
        public bool JT_On //第T關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 14);
            }
        }
        public bool JS_On //第S關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 15);
            }
        }
        public bool J7_On //第7關節勵磁中
        {
            get
            {
                return Get_Bit(Data, 1, 16);
            }
        }

        //17-31 未定義
        #endregion

        #region Data2
        //00-15 &H1-&H8000 工作 17~32 為執行中(Xqt)或處於 Halt 狀態
        #endregion

        private bool Get_Bit(int[] data, int word_no, int bit_no)
        {
            bool result = false;

            if (word_no < data.Length && bit_no < 32)
                result = Get_Bit(data[word_no], bit_no);
            return result;
        }
        private static bool Get_Bit(int idata, int bit_no)
        {
            bool result = false;
            int flag;

            if (bit_no >= 0 && bit_no < 32)
            {
                flag = 0x0001;
                flag = flag << bit_no;
                if ((idata & flag) == flag) result = true;
                else result = false;
            }
            return result;
        }
    }
}
