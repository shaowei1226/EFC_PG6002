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

namespace Main
{
    public class TPLC_CMD_Thread
    {
        private Thread Main_Thread = null;
        private PLC_Thread_List Thread_List = new PLC_Thread_List();
        private TLog in_Log = null;
        public string Log_Source = "TPLC_CMD_Thread";

        private bool Terminate = false;
        private bool Thread_ON = false;
        private double in_Scan_Time;
        private System.Diagnostics.Stopwatch Watch = new System.Diagnostics.Stopwatch();

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
        public TPLC_CMD_Thread()
        {
            Main_Thread = new Thread(Thread_Start);
        }
        public void Dispose()
        {
            Stop();
        }
        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Log_Source, fun, msg_str, type);
        }
        public void Start()
        {
            Main_Thread.Start();
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
            while (!Terminate)
            {
                Thread_ON = true;
                Watch.Reset();
                Watch.Start();

                TPub.PLC.PLC_Out.On_Line = !TPub.PLC.PLC_Out.On_Line;

                Thread_List.Remove_Stop_Thread(); //關掉工作完成的執行序
                Thread_Add(TPub.PLC.PLC_In.Set_Light_All_OFF_Req, TPub.PLC.PLC_Out.Set_Light_All_OFF, "Set_Light_All_OFF", Set_Light_All_OFF);

                #region PCB
                Thread_Add(TPub.PLC.PLC_In.PCB_L_Set_Light_Req, TPub.PLC.PLC_Out.PCB_L_Set_Light, "PCB_L_Set_Light", PCB_L_Set_Light);
                Thread_Add(TPub.PLC.PLC_In.PCB_L_Grab_Req, TPub.PLC.PLC_Out.PCB_L_Grab, "PCB_L_Grab", PCB_L_Grab);
                Thread_Add(TPub.PLC.PLC_In.PCB_L_MU_Grab_Req, TPub.PLC.PLC_Out.PCB_L_MU_Grab, "PCB_L_MU_Grab", PCB_L_MU_Grab);
                Thread_Add(TPub.PLC.PLC_In.PCB_R_Set_Light_Req, TPub.PLC.PLC_Out.PCB_R_Set_Light, "PCB_R_Set_Light", PCB_R_Set_Light);
                Thread_Add(TPub.PLC.PLC_In.PCB_R_Grab_Req, TPub.PLC.PLC_Out.PCB_R_Grab, "PCB_R_Grab", PCB_R_Grab);
                Thread_Add(TPub.PLC.PLC_In.PCB_R_MU_Grab_Req, TPub.PLC.PLC_Out.PCB_R_MU_Grab, "PCB_R_MU_Grab", PCB_R_MU_Grab);
                Thread_Add(TPub.PLC.PLC_In.PCB_Cal_Req, TPub.PLC.PLC_Out.PCB_Cal, "PCB_Cal", PCB_Cal);

                Thread_Add(TPub.PLC.PLC_In.PCB_Check1_Set_Light_Req, TPub.PLC.PLC_Out.PCB_Check1_Set_Light, "PCB_Check1_Set_Light", PCB_Check1_Set_Light);
                Thread_Add(TPub.PLC.PLC_In.PCB_Check1_Check_Req, TPub.PLC.PLC_Out.PCB_Check1_Check, "PCB_Check1_Check", PCB_Check1_Check);

                Thread_Add(TPub.PLC.PLC_In.PCB_Check2_Set_Light_Req, TPub.PLC.PLC_Out.PCB_Check2_Set_Light, "PCB_Check2_Set_Light", PCB_Check2_Set_Light);
                Thread_Add(TPub.PLC.PLC_In.PCB_Check2_Check_Req, TPub.PLC.PLC_Out.PCB_Check2_Check, "PCB_Check2_Check", PCB_Check2_Check);
                #endregion

                #region Robot1
                Thread_Add(TPub.PLC.PLC_In.Robot1_Program_Run_Req, TPub.PLC.PLC_Out.Robot1_Program_Run, "Robot1_Program_Run", Robot1_Program_Run);
                Thread_Add(TPub.PLC.PLC_In.Robot1_Program_Stop_Req, TPub.PLC.PLC_Out.Robot1_Program_Stop, "Robot1_Program_Stop", Robot1_Program_Stop);
                Thread_Add(TPub.PLC.PLC_In.Robot1_Error_Reset_Req, TPub.PLC.PLC_Out.Robot1_Error_Reset, "Robot1_Error_Reset", Robot1_Error_Reset);
                Thread_Add(TPub.PLC.PLC_In.Robot1_Loop_Run_Req, TPub.PLC.PLC_Out.Robot1_Loop_Run, "Robot1_Loop_Run", Robot1_Loop_Run);
                #endregion

                Watch.Stop();
                in_Scan_Time = Watch.Elapsed.TotalMilliseconds;
                Thread.Sleep(100);
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


        public void Set_Light_All_OFF(string name, PLC_Thread thread)
        {
            string fun = "Set_Light_All_OFF";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));
            //TPub.Set_Light_All_OFF();
            TPub.PLC.PLC_Out.Set_Light_All_OFF.Finish = true;
        }

        #region PCB
        public void PCB_L_Set_Light(string name,PLC_Thread thread)
        {
            string fun = "PCB_L_Set_Light";
            emModel model = emModel.PCB_L;
            emModel model2 = emModel.PCB_R;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));

            TPub.PLC.PLC_Out.PCB_L_Set_Light.OK = TPub.Set_Light(model);
            TPub.PLC.PLC_Out.PCB_R_Set_Light.OK = TPub.Set_Light(model2);

            TPub.PLC.PLC_Out.PCB_L_Set_Light.Finish = true;
            TPub.PLC.PLC_Out.PCB_R_Set_Light.Finish = true;

        }
        public void PCB_L_Grab(string name,PLC_Thread thread)
        {
            string fun = "PCB_L_Grab";
            emModel model = emModel.PCB_L;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));

            TPub.PLC.PLC_Out.PCB_L_Grab.OK = TPub.Find(model);
            TPub.PLC.PLC_Out.PCB_L_Grab.Finish = true;
        }
        public void PCB_L_MU_Grab(string name, PLC_Thread thread)
        {
            string fun = "PCB_L_MU_Grab";
            emModel model = emModel.PCB_L;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));

            TPub.MU_Select(model);
        }
        public void PCB_R_Set_Light(string name, PLC_Thread thread)
        {
            string fun = "PCB_R_Set_Light";
            emModel model = emModel.PCB_R;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in", name));

            TPub.PLC.PLC_Out.PCB_R_Set_Light.OK = TPub.Set_Light(model);
            TPub.PLC.PLC_Out.PCB_R_Set_Light.Finish = true;
        }
        public void PCB_R_Grab(string name, PLC_Thread thread)
        {
            string fun = "PCB_R_Grab";
            emModel model = emModel.PCB_R;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in", name));

            TPub.PLC.PLC_Out.PCB_R_Grab.OK = TPub.Find(model);
            TPub.PLC.PLC_Out.PCB_R_Grab.Finish = true;
        }
        public void PCB_R_MU_Grab(string name, PLC_Thread thread)
        {
            string fun = "PCB_R_MU_Grab";
            emModel model = emModel.PCB_R;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));
            TPub.MU_Select(model);
        }
        public void PCB_Cal(string name, PLC_Thread thread)
        {
            string fun = "PCB_Cal";

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));
            TPub.PLC.PLC_Out.PCB_Cal.OK = TPub.Cal_PCB();
            TPub.PLC.PLC_Out.PCB_Cal.Finish = true;
        }

        public void PCB_Check1_Set_Light(string name, PLC_Thread thread)
        {
            string fun = "PCB_Check1_Set_Light";
            emModel model = emModel.ACF_Check1;
            emModel model2 = emModel.ACF_Check2;

            int no = TPub.PLC.PLC_In.ACF_Check_No;


            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));

            TPub.PLC.PLC_Out.PCB_Check1_Set_Light.OK = TPub.Set_Light(model, no);
            TPub.PLC.PLC_Out.PCB_Check1_Set_Light.Finish = true;
            TPub.PLC.PLC_Out.PCB_Check2_Set_Light.OK = TPub.Set_Light(model2, no);
            TPub.PLC.PLC_Out.PCB_Check2_Set_Light.Finish = true;
        }
        public void PCB_Check1_Check(string name, PLC_Thread thread)
        {
            string fun = "PCB_Check1_Check";
            int no = TPub.PLC.PLC_In.ACF_Check_No - 1;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));
            TPub.PLC.PLC_Out.PCB_Check1_Check.OK = TPub.Cal_ACF_Check_1(no);
            TPub.PLC.PLC_Out.PCB_Check1_Check.Finish = true;
        }
        public void PCB_Check2_Set_Light(string name, PLC_Thread thread)
        {
            string fun = "PCB_Check2_Set_Light";
            emModel model = emModel.ACF_Check2;
            int no = TPub.PLC.PLC_In.ACF_Check_No;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));

            TPub.PLC.PLC_Out.PCB_Check2_Set_Light.OK = TPub.Set_Light(model, no);
            TPub.PLC.PLC_Out.PCB_Check2_Set_Light.Finish = true;
        }
        public void PCB_Check2_Check(string name, PLC_Thread thread)
        {
            string fun = "PCB_Check2_Check";
            int no = TPub.PLC.PLC_In.ACF_Check_No - 1;

            Log_Add(fun, string.Format("[PLC] Thread Name={0:s} in.", name));
            TPub.PLC.PLC_Out.PCB_Check2_Check.OK = TPub.Cal_ACF_Check_2(no);
            TPub.PLC.PLC_Out.PCB_Check2_Check.Finish = true;
        }
        #endregion

        #region Robot1
        public void Robot1_Program_Run(string thread_name, PLC_Thread thread)
        {
            string fun = "Robot1_Program_Run";

            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} in.", thread_name));

            TPub.PLC.PLC_Out.Robot1_Program_Run.OK = TPub.Robot1_Program_Run();
            TPub.PLC.PLC_Out.Robot1_Program_Run.Finish = true;

            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} Out.", thread_name));
        }
        public void Robot1_Program_Stop(string thread_name, PLC_Thread thread)
        {
            string fun = "Robot1_Program_Stop";

            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Robot1_Program_Stop.OK = TPub.Robot1_Program_Stop();
            TPub.PLC.PLC_Out.Robot1_Program_Stop.Finish = true;
            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} Out.", thread_name));
        }
        public void Robot1_Error_Reset(string thread_name, PLC_Thread thread)
        {
            string fun = "Robot1_Error_Reset";

            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} in.", thread_name));
            TPub.PLC.PLC_Out.Robot1_Error_Reset.OK = TPub.Robot1_Program_Reset();
            TPub.PLC.PLC_Out.Robot1_Error_Reset.Finish = true;
            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} Out.", thread_name));
        }
        public void Robot1_Loop_Run(string thread_name, PLC_Thread thread)
        {
            string fun = "Robot1_Loop_Run";

            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} in.", thread_name));
            Log_Add(fun, string.Format("Robot1_Loop_Run type={0:d}, step={1:d}", TPub.PLC.PLC_In.Robot1_Loop_Run_Type, TPub.PLC.PLC_In.Robot1_Loop_Run_Step));
            //TPub.PLC.PLC_Out.Robot1_Loop_Run.OK = TPub.Robot1_Program_Run;
            Log_Add(fun, string.Format("[PLC] Thread Name= {0:s} Out.", thread_name));
        }
        #endregion

     }

}
