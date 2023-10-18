using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EFC.Tool;
using EFC.CAD;
using EFC.Robot.Epson;
//230816
namespace Main
{
    public enum emRobot1_Loop { None, Home, Tray_Load, Plasma_Load,Plasma_Unload,ACF_Load,ACF_Unload,PCB_Load,PCB_Unload, NG , Teach };

    public class TRobot1_Program : TRobot_Program_Base
    {
        #region 參數
        public TEFC_SpelPoint Now_Pos = new TEFC_SpelPoint();
        public double Safe_Pos_XY = 500;
        public TRobot1_IO_In IO_In = new TRobot1_IO_In();
        public TRobot1_IO_Out IO_Out = new TRobot1_IO_Out();
        public TMove_Pos Pos_Home = new TMove_Pos();  
        public TMove_Pos_List Pos_List_Tray_Load = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_Plasma_Load = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_Plasma_Unload = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_ACF_Load = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_ACF_Unload = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_PCB_Load = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_PCB_Unload = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_NG = new TMove_Pos_List();
        public TMove_Pos_List Pos_List_Teach = new TMove_Pos_List();
        //    public TMove_Pos_List Pos_List_Home = new TMove_Pos_List();

        #endregion

        #region Main
        public TRobot1_Program(TEpson_Robot robot)
        {
            Robot = robot;
            Init();
        }
        public void Dispose()
        {
            Program_Stop();
        }
        override protected void Init()
        {

        }

        override public void Program_Init()
        {
            //Robot馬達電源啟動、選擇高功率
            Robot.Motors_On = true;
            Robot.Power_High = true;

            // 設置整體速度
            Set_Speed_Factor(TPub.PLC.PLC_In.Robot1_Speed);//PLC給

            // 設置速度,加速度
            Set_Speed(Robot_Speed);
            Robot.Set_Accel(Program_Acc, Program_Acc);//
            Robot.Set_Accel_R(Program_Acc_R, Program_Acc_R);//
            Robot.Set_Accel_S(Program_Acc_S, Program_Acc_S);//
           
        }
        override public void Program_Main()
        {
            Update_Pos();

            if (IO_In.Loop_Run_Req && !IO_Out.Loop_Running && !IO_Out.Loop_Run_Finish)
            {
                Run_Loop_Step();
            }
            else if (!IO_In.Loop_Run_Req && (IO_Out.Loop_Running || IO_Out.Loop_Run_Finish || IO_Out.Loop_Run_OK))
            {
                IO_Out.Loop_Running = false;
                IO_Out.Loop_Run_Finish = false;
                IO_Out.Loop_Run_OK = false;
                IO_Out.Loop_Run_Type = emRobot1_Loop.None;
                IO_Out.Loop_Run_Step = 0;
            }
        }
        override public void Program_IO_In()
        {
            Now_Pos.Set(Robot.Get_Point_Here());//手臂取得現在位置
            Set_Speed_Factor(TPub.PLC.PLC_In.Robot1_Speed, false);

            
            IO_In.Loop_Run_Req = TPub.PLC.PLC_In.Robot1_Loop_Run_Req;
            IO_In.Loop_Run_Step = TPub.PLC.PLC_In.Robot1_Loop_Run_Step;
            IO_In.Loop_Run_Type = Get_emRobot_Loop(TPub.PLC.PLC_In.Robot1_Loop_Run_Type);
            IO_In.Loop_Run_Tray_No = TPub.PLC.PLC_In.Robot1_Loop_Run_Tray_No;
            IO_In.Loop_Run_Tray_Z_No = TPub.PLC.PLC_In.Robot1_Loop_Run_Tray_Z_No;


            IO_In.Align_Ofs_X = TPub.PLC.PLC_In.PCB_DX;////待驗證
            IO_In.Align_Ofs_Y = TPub.PLC.PLC_In.PCB_DY;////待驗證
            IO_In.Align_Ofs_Q = TPub.PLC.PLC_In.PCB_DQ;////待驗證
          
        }
        override public void Program_IO_Out()
        {

            TPub.PLC.PLC_Out.Robot1_Loop_Run.Finish = IO_Out.Loop_Run_Finish;
            TPub.PLC.PLC_Out.Robot1_Loop_Run.OK = IO_Out.Loop_Run_OK;

            TPub.PLC.PLC_Out.Robot1_On_Home = Get_On_Pos_Home();

            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_Tray_Load.Length; i++)
            {

                TPub.PLC.PLC_Out.Robot1_On_Pos_Tray_Load[i] = Get_On_Pos_Tray_Load(i);
                TPub.PLC.PLC_Out.RB_Type = 2;
               if (Get_On_Pos_Tray_Load(i)==true)
               {
                   TPub.PLC.PLC_Out.RB_Step = i;
               }

         
            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_Plasma_Load.Length; i++)
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_Plasma_Load[i] = Get_On_Pos_Plasma_Load(i);
                TPub.PLC.PLC_Out.RB_Type = 3;
              
            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_Plasma_Unload.Length; i++)
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_Plasma_Unload[i] = Get_On_Pos_Plasma_Unload(i);
                TPub.PLC.PLC_Out.RB_Type = 4;
                
            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_ACF_Load.Length; i++)
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_ACF_Load[i] = Get_On_Pos_ACF_Load(i);

                TPub.PLC.PLC_Out.RB_Type = 5;

            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_ACF_Unload.Length; i++)
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_ACF_Unload[i] = Get_On_Pos_ACF_Unload(i);
                TPub.PLC.PLC_Out.RB_Type = 6;
     
            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_PCB_Load.Length; i++)
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_PCB_Load[i] = Get_On_Pos_PCB_Load(i);
                TPub.PLC.PLC_Out.RB_Type = 7;
            
  
            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_PCB_Unload.Length; i++)
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_PCB_Unload[i] = Get_On_Pos_PCB_Unload(i);
                TPub.PLC.PLC_Out.RB_Type = 8;
               

            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_NG.Length; i++) 
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_NG[i] = Get_On_Pos_NG(i);
                TPub.PLC.PLC_Out.RB_Type = 9;
                

            }
            for (int i = 0; i < TPub.PLC.PLC_Out.Robot1_On_Pos_Teach.Length; i++)
            {
                TPub.PLC.PLC_Out.Robot1_On_Pos_Teach[i] = Get_On_Pos_Teach(i);
                TPub.PLC.PLC_Out.RB_Type = 10;
               
            }


            TPub.PLC.PLC_Out.Robot1_Speed = Program_Speed_Factor;
            TPub.PLC.PLC_Out.Robot1_Loop_Run_Step = IO_Out.Loop_Run_Step;
            TPub.PLC.PLC_Out.Robot1_Loop_Run_Tray_No = IO_Out.Loop_Run_Tray_No;
         
        }

        public bool Get_On_Pos_Home()
        {
            bool result = false;

            result = Pos_Home.On_Pos && Program_Running;
 
            return result;
        }
        public bool Get_On_Pos_Tray_Load(int no)
        {

           // bool result = false;
            //result = Pos_List_Tray_Load[no].On_Pos;
            return Get_On_Pos(Pos_List_Tray_Load, no);

        }
        public bool Get_On_Pos_Plasma_Load(int no)
        {

            return Get_On_Pos(Pos_List_Plasma_Load, no);

        }
        public bool Get_On_Pos_Plasma_Unload(int no)
        {
            return Get_On_Pos(Pos_List_Plasma_Unload, no);
        }
        public bool Get_On_Pos_ACF_Load(int no)
        {
            return Get_On_Pos(Pos_List_ACF_Load, no);
          
        }
        public bool Get_On_Pos_ACF_Unload(int no)
        {
            return Get_On_Pos(Pos_List_ACF_Unload, no);
           
        }
        public bool Get_On_Pos_PCB_Load(int no)
        {
            return Get_On_Pos(Pos_List_PCB_Load, no);
        }
        public bool Get_On_Pos_PCB_Unload(int no)
        {
            return Get_On_Pos(Pos_List_PCB_Unload, no);
        }
        public bool Get_On_Pos_NG(int no)
        {
            return Get_On_Pos(Pos_List_NG, no);
        }
        public bool Get_On_Pos_Teach(int no)
        {
            return Get_On_Pos(Pos_List_Teach, no);
        }
        #endregion

        #region private
        #region Update_Pos
        private void Update_Pos()
        {
            Update_Pos_Home();
            Update_Pos_Tray_Load();
            Update_Pos_Plasma_Load();
            Update_Pos_Plasma_Unload();
            Update_Pos_ACF_Load();
            Update_Pos_ACF_Unload();
            Update_Pos_PCB_Load();
            Update_Pos_PCB_Unload();
            Update_Pos_NG();
            Update_Pos_Teach();

            Update_On_Pos();
            Update_Can_Move();
        }
        private void Update_Pos_Home()
        {
            Pos_Home.Pos.Set(TPub.Recipe.Robot.Robot_Home.List_Home[0].Pos);
  
        }
        private void Update_Pos_Tray_Load()
        {

            Set_Data(ref Pos_List_Tray_Load, TPub.Recipe.Robot.Robot_Tray.List_Load);
            TJJS_Point tray_ofs = new TJJS_Point();
            tray_ofs = TPub.Recipe.PCB_Tray.Get_Tray_Pos(IO_Out.Loop_Run_Tray_No);

            for (int i = 1; i < Pos_List_Tray_Load.Count; i++)
            {

                
                Pos_List_Tray_Load[i].Pos.Add_Ofs(TPub.PLC.PLC_In.Keyence_return_X, TPub.PLC.PLC_In.Keyence_return_Y, TPub.PLC.PLC_In.Keyence_return_Q);
          
            }
            
            #endregion

        #region 設定Tray Z 位置
            //TEFC_SpelPoint pos_b = null;
            //TEFC_SpelPoint pos_z = null;

            //pos_b = Pos_List_Tray_Load[3].Pos;
            //pos_z = Pos_List_Tray_Load[4].Pos;
            //pos_z.Set_Data(pos_b);
            //if (IO_In.Loop_Run_Tray_Z_No >= 0)
            //{
            //    pos_z.Z = pos_b.Z - IO_In.Loop_Run_Tray_Z_No;
            //}
            #endregion
        }
        private void Update_Pos_Plasma_Load()
        {
            Set_Data(ref Pos_List_Plasma_Load, TPub.Recipe.Robot.Robot_Plasma.List_Load);
            #region 設定 Ofs
            //double ofs_q = 0;
            //TJJS_Point p_sor = new TJJS_Point();
            //TJJS_Point p_tmp = new TJJS_Point();

            //p_sor.X = IO_In.Align_Ofs_X;
            //p_sor.Y = IO_In.Align_Ofs_Y;
            //ofs_q = IO_In.Align_Ofs_Q;

            //p_tmp = p_sor.Rotate(0);
            //for (int i = 1; i < Pos_List_Plasma_Load.Count; i++)
            //    Pos_List_Plasma_Load[i].Pos.Add_Ofs(p_tmp.X, p_tmp.Y, ofs_q);
            #endregion
        }
        private void Update_Pos_Plasma_Unload()
        {
            Set_Data(ref Pos_List_Plasma_Unload, TPub.Recipe.Robot.Robot_Plasma.List_Unload);
            #region 設定 Ofs
            //double ofs_q = 0;
            //TJJS_Point p_sor = new TJJS_Point();
            //TJJS_Point p_tmp = new TJJS_Point();

            //p_sor.X = IO_In.Align_Ofs_X;
            //p_sor.Y = IO_In.Align_Ofs_Y;
            //ofs_q = IO_In.Align_Ofs_Q;

            //p_tmp = p_sor.Rotate(90);
            //for (int i = 1; i < Pos_List_Plasma_Unload.Count; i++)
            //    Pos_List_Plasma_Unload[i].Pos.Add_Ofs(p_tmp.X, p_tmp.Y, ofs_q);
            #endregion
        }
        private void Update_Pos_ACF_Load()
        {
         
            Set_Data(ref Pos_List_ACF_Load, TPub.Recipe.Robot.Robot_ACF.List_Load);
          
            #region 設定 Ofs
            //double ofs_q = 0;
            //TJJS_Point p_sor = new TJJS_Point();
            //TJJS_Point p_tmp = new TJJS_Point();

            //p_sor.X = IO_In.Align_Ofs_X;
            //p_sor.Y = IO_In.Align_Ofs_Y;
            //ofs_q = IO_In.Align_Ofs_Q;

            //p_tmp = p_sor.Rotate(0);
            //for (int i = 1; i < Pos_List_ACF_Load.Count; i++)
            //    Pos_List_ACF_Load[i].Pos.Add_Ofs(p_tmp.X, p_tmp.Y, ofs_q);
            #endregion
        }
        private void Update_Pos_ACF_Unload()
        {
          
            Set_Data(ref Pos_List_ACF_Unload, TPub.Recipe.Robot.Robot_ACF.List_Unload);
            
            #region ofs
            TJJS_Point tray_ofs = new TJJS_Point();

            tray_ofs = TPub.Recipe.PCB_Tray.Get_Tray_Pos(IO_Out.Loop_Run_Tray_No);

            for (int i = 1; i < Pos_List_ACF_Unload.Count; i++)
            {


                Pos_List_ACF_Unload[i].Pos.Add_Ofs(TPub.PLC.PLC_In.PCB_Out_Ofs_X, TPub.PLC.PLC_In.PCB_Out_Ofs_Y, TPub.PLC.PLC_In.PCB_Out_Ofs_Q);

            }
            #endregion
     
        }
        private void Update_Pos_PCB_Load()
        {

            Set_Data(ref Pos_List_PCB_Load, TPub.Recipe.Robot.Robot_PCB.List_Load);
       
            #region 設定 Ofs
            //double ofs_q = 0;
            //TJJS_Point p_sor = new TJJS_Point();
            //TJJS_Point p_tmp = new TJJS_Point();

            //p_sor.X = IO_In.Align_Ofs_X;
            //p_sor.Y = IO_In.Align_Ofs_Y;
            //ofs_q = IO_In.Align_Ofs_Q;

            //p_tmp = p_sor.Rotate(0);
            //for (int i = 1; i < Pos_List_PCB_Load.Count; i++)
            //    Pos_List_PCB_Load[i].Pos.Add_Ofs(p_tmp.X, p_tmp.Y, ofs_q);
            #endregion
        }
        private void Update_Pos_PCB_Unload()
        {

            Set_Data(ref Pos_List_PCB_Unload, TPub.Recipe.Robot.Robot_PCB.List_Unload);

            #region 設定 Ofs
            //double ofs_q = 0;
            //TJJS_Point p_sor = new TJJS_Point();
            //TJJS_Point p_tmp = new TJJS_Point();

            //p_sor.X = IO_In.Align_Ofs_X;
            //p_sor.Y = IO_In.Align_Ofs_Y;
            //ofs_q = IO_In.Align_Ofs_Q;

            //p_tmp = p_sor.Rotate(90);
            //for (int i = 1; i < Pos_List_PCB_Unload.Count; i++)
            //    Pos_List_PCB_Unload[i].Pos.Add_Ofs(p_tmp.X, p_tmp.Y, ofs_q);
            #endregion
        }
        private void Update_Pos_NG()
        {

            Set_Data(ref Pos_List_NG, TPub.Recipe.Robot.Robot_NG.List_NG);

        }
        private void Update_Pos_Teach()
        {
            Set_Data(ref Pos_List_Teach, TPub.Recipe.Robot.Robot_Teach.List_Teach);
        }
        #endregion

        #region Update_On_Pos
        private void Update_On_Pos()
        {
            Update_On_Pos_Home();
            Update_On_Pos_Tray_Load();
            Update_On_Pos_Plasma_Load();
            Update_On_Pos_Plasma_Unload();
            Update_On_Pos_ACF_Load();
            Update_On_Pos_ACF_Unload();
            Update_On_Pos_PCB_Load();
            Update_On_Pos_PCB_Unload();
            Update_On_Pos_NG();
            Update_On_Pos_Teach();
        }
        private void Update_On_Pos_Home()
        {
            double ofs = 0.01;

            Pos_Home.On_Pos = Epson_Robot_Tool.Equal(Now_Pos, Pos_Home.Pos, ofs);
        }
        private void Update_On_Pos_Tray_Load()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_Tray_Load;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }       
        }
        private void Update_On_Pos_Plasma_Load()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_Plasma_Load;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        private void Update_On_Pos_Plasma_Unload()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_Plasma_Unload;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        private void Update_On_Pos_ACF_Load()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_ACF_Load;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        private void Update_On_Pos_ACF_Unload()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_ACF_Unload;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        private void Update_On_Pos_PCB_Load()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_PCB_Load;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        private void Update_On_Pos_PCB_Unload()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_PCB_Unload;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        private void Update_On_Pos_NG()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_NG;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        private void Update_On_Pos_Teach()
        {
            TMove_Pos_List pos_list = null;
            double ofs = 0.01;

            pos_list = Pos_List_Teach;
            for (int i = 0; i < pos_list.Count; i++)
            {
                pos_list[i].On_Pos = Epson_Robot_Tool.Equal(Now_Pos, pos_list[i].Pos, ofs);
            }
        }
        #endregion

        #region Update_Can_Move
        private void Update_Can_Move()
        {
            Pos_Home.Can_Move = true;

            Update_Can_Move_Tray_Load();

            Update_Can_Move_Plasma_Load();
            Update_Can_Move_Plasma_Unload();
            Update_Can_Move_ACF_Load();
            Update_Can_Move_ACF_Unload();
            Update_Can_Move_PCB_Load();
            Update_Can_Move_PCB_Unload();
            Update_Can_Move_NG();
            Update_Can_Move_Teach();
        }
        private void Update_Can_Move_Tray_Load()
        {
            TMove_Pos_List pos_list = Pos_List_Tray_Load;
            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;
            

         //   if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 2)
        //    {
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos||pos_list_PCB_D[0].On_Pos||pos_list_ACF_D[0].On_Pos||pos_list_NG[0].On_Pos||pos_list_Plasma_D[0].On_Pos||pos_list_Plasma_UD[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
          //  }
         
        }
        private void Update_Can_Move_Plasma_Load()
        {
            TMove_Pos_List pos_list = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;
            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;

        //    if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 3)
        //    {       
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos || pos_list_PCB_D[0].On_Pos || pos_list_ACF_D[0].On_Pos || pos_list_NG[0].On_Pos || pos_list_Plasma_D[0].On_Pos || pos_list_Plasma_UD[0].On_Pos||pos_list_Tray_D[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
         //   }

        }
        private void Update_Can_Move_Plasma_Unload()
        {
            TMove_Pos_List pos_list = Pos_List_Plasma_Unload;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;

            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            

        //    if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 4)
         //   {
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos || pos_list[9].On_Pos||pos_list_Tray_D[0].On_Pos||pos_list_ACF_D[0].On_Pos||pos_list_ACF_UD[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
        //    }

        }
        private void Update_Can_Move_ACF_Load()
        {
            TMove_Pos_List pos_list = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;
            
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;
         //   if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 5)
         //   {

                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos || pos_list[9].On_Pos||pos_list_Plasma_UD[0].On_Pos||pos_list_ACF_UD[0].On_Pos||pos_list_Plasma_D[0].On_Pos||pos_list_Plasma_UD[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);

         //   }

        }
        private void Update_Can_Move_ACF_Unload()
        {
            TMove_Pos_List pos_list = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;

            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;
        ////   if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 6)
         //   {
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos || pos_list[9].On_Pos||pos_list_ACF_D[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
          //  }

        }
        private void Update_Can_Move_PCB_Load()
        {
            TMove_Pos_List pos_list = Pos_List_PCB_Load;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;

            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;

         //   if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 7)
         //   {
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos || pos_list[9].On_Pos||pos_list_ACF_D[0].On_Pos||pos_list_ACF_UD[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
         //   }

        }
        private void Update_Can_Move_PCB_Unload()
        {
            TMove_Pos_List pos_list = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;

            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;
        //    if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 8)
        //    {
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos || pos_list[9].On_Pos||pos_list_PCB_D[0].On_Pos||pos_list_ACF_D[0].On_Pos||pos_list_ACF_UD[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
         //   }

        }
        private void Update_Can_Move_NG()
        {
            TMove_Pos_List pos_list = Pos_List_NG;
            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;

            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;


         //   if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 9)
         //   {
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos||pos_list[9].On_Pos||pos_list_ACF_D[0].On_Pos||pos_list_ACF_UD[0].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
           // }

        }
        private void Update_Can_Move_Teach()
        {
            TMove_Pos_List pos_list = Pos_List_Teach;
            TMove_Pos_List pos_list_PCB_D = Pos_List_PCB_Load;
            TMove_Pos_List Pos_list_PCB_UD = Pos_List_PCB_Unload;
            TMove_Pos_List pos_list_ACF_D = Pos_List_ACF_Load;
            TMove_Pos_List pos_list_ACF_UD = Pos_List_ACF_Unload;
            TMove_Pos_List pos_list_NG = Pos_List_NG;
            TMove_Pos_List pos_list_Plasma_D = Pos_List_Plasma_Load;
            TMove_Pos_List pos_list_Plasma_UD = Pos_List_Plasma_Unload;
            TMove_Pos_List pos_list_Tray_D = Pos_List_Tray_Load;

         //   if (TPub.PLC.PLC_In.Robot1_Loop_Run_Type == 10)
         //   {
                pos_list[0].Can_Move = (Robot_Can_Run_Go(Now_Pos) || pos_list[1].On_Pos || pos_list[9].On_Pos);
                pos_list[1].Can_Move = (pos_list[0].On_Pos || pos_list[2].On_Pos);
                pos_list[2].Can_Move = (pos_list[1].On_Pos || pos_list[3].On_Pos);
                pos_list[3].Can_Move = (pos_list[2].On_Pos || pos_list[4].On_Pos);
                pos_list[4].Can_Move = (pos_list[3].On_Pos || pos_list[5].On_Pos);
                pos_list[5].Can_Move = (pos_list[4].On_Pos || pos_list[6].On_Pos);
                pos_list[6].Can_Move = (pos_list[5].On_Pos || pos_list[7].On_Pos);
                pos_list[7].Can_Move = (pos_list[6].On_Pos || pos_list[8].On_Pos);
                pos_list[8].Can_Move = (pos_list[7].On_Pos || pos_list[9].On_Pos);
                pos_list[9].Can_Move = (pos_list[8].On_Pos);
        //    }
        }

        #endregion

        #region Other
        private void Set_Speed_Factor(int in_speed, bool force = true)
        {
            if (in_speed != inProgram_Speed_Factor || force)
            {
                inProgram_Speed_Factor = in_speed;
                if (inProgram_Speed_Factor < 1) inProgram_Speed_Factor = 1;
                if (inProgram_Speed_Factor > 100) inProgram_Speed_Factor = 100;
                Robot.Set_Speed_Factor(inProgram_Speed_Factor);
            }
        }
        private void Set_Speed(double in_speed, bool force = true)
        {
            double speed = 0;

            if (in_speed != Robot_Speed || force)
            {
                Robot_Speed = (int)in_speed;
                if (Robot_Speed < 1) Robot_Speed = 1;
                if (Robot_Speed > 100) Robot_Speed = 100;

                speed = Program_Speed * Robot_Speed / 100;
                Robot.Set_Speed(speed);

                speed = Program_Speed_R * Robot_Speed / 100;
                Robot.Set_SpeedR(speed);

                speed = Program_Speed_S * Robot_Speed / 100;
                Robot.Set_SpeedS(speed);
            }
        }
        private void Run_Loop_Step()
        {
            string fun = "Run_Loop_Step";

            Log_Add(fun, string.Format("[Run_Loop_Step] PG_Run_Loop_Type={0:s} PG_Run_Pos={1:d} Tray_No={2:d} Tray_Z_No={3:d}.",
                         IO_In.Loop_Run_Type.ToString(), IO_In.Loop_Run_Step, IO_In.Loop_Run_Tray_No,IO_In.Loop_Run_Tray_Z_No));

            IO_Out.Loop_Run_Type = IO_In.Loop_Run_Type;
            IO_Out.Loop_Run_Step = IO_In.Loop_Run_Step;
            IO_Out.Loop_Run_Tray_No = IO_In.Loop_Run_Tray_No;
            IO_Out.Loop_Run_Tray_Z_No = IO_In.Loop_Run_Tray_Z_No;
            
       
            Update_Pos();

            IO_Out.Loop_Running = true;
            switch (IO_Out.Loop_Run_Type)
            {
                case emRobot1_Loop.Home:
                    IO_Out.Loop_Run_OK = Run_Home();//原程式
                   // IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);//1002新增_TRY
                    TPub.PLC.PLC_Out.RB_Type = 1;
                    break;
               
                case emRobot1_Loop.Tray_Load:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 2;
                    break;
                case emRobot1_Loop.Plasma_Load:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 3;
                    break;
                case emRobot1_Loop.Plasma_Unload:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 4;
                    break;
                case emRobot1_Loop.ACF_Load:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 5;
                    break;
                case emRobot1_Loop.ACF_Unload:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 6;
                    break;
                case emRobot1_Loop.PCB_Load:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 7;
                    break;
                case emRobot1_Loop.PCB_Unload:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 8;
                    break;
                case emRobot1_Loop.NG:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 9;
                    break;
                case emRobot1_Loop.Teach:
                    IO_Out.Loop_Run_OK = Run_Station(IO_Out.Loop_Run_Type, IO_Out.Loop_Run_Step);
                    TPub.PLC.PLC_Out.RB_Type = 10;
                    break;

                    break;
            }
    
            IO_Out.Loop_Running = false;
            IO_Out.Loop_Run_Finish = true;
        }
        private bool Run_Home()
        {
            bool result = false;
            TMove_Pos point_home = null;
            TEFC_SpelPoint point_tmp = new TEFC_SpelPoint();
            int home_speed = 25;

            point_home = Pos_Home;
            if (point_home != null)
            {
                if (!Robot_Can_Run_Go(Now_Pos))
                {
                    #region Z軸移動到安全位置
                    Now_Pos.Set(Robot.Get_Point_Here());
                    if (Now_Pos.Z != point_home.Pos.Z)
                    {
                        point_tmp.Set(Now_Pos);
                        point_tmp.Z = point_home.Pos.Z;
                        Set_Speed(home_speed);
                        Robot.Move(point_tmp);
                    }
                    #endregion

                    #region X軸移動到安全位置
                    Now_Pos.Set(Robot.Get_Point_Here());
                    point_tmp.Set(Now_Pos);
                    if (Now_Pos.X > Safe_Pos_XY)
                    {
                        point_tmp.X = Safe_Pos_XY;
                        Set_Speed(home_speed);
                        Robot.Move(point_tmp);
                    }
                    else if (Now_Pos.X < -Safe_Pos_XY)
                    {
                        point_tmp.X = -Safe_Pos_XY;
                        Set_Speed(home_speed);
                        Robot.Move(point_tmp);
                    }
                    #endregion

                    #region Y軸移動到安全位置
                    Now_Pos.Set(Robot.Get_Point_Here());
                    point_tmp.Set(Now_Pos);
                    if (Now_Pos.Y > Safe_Pos_XY)
                    {
                        point_tmp.Y = Safe_Pos_XY;
                        Set_Speed(home_speed);
                        Robot.Move(point_tmp);
                    }
                      else if (Now_Pos.Y < -Safe_Pos_XY)
                    {
                        point_tmp.Y = -Safe_Pos_XY;
                        Set_Speed(home_speed);
                        Robot.Move(point_tmp);
                    }
                    #endregion
                }

                #region 移動到安全位置
                Set_Speed(point_home.Speed);
                Robot.Go(point_home.Pos);
                result = true;
                #endregion
            }
            return result;
        }
        private bool Run_Station(emRobot1_Loop station, int step)
        {
            bool result = false;
            string fun = "Run_Station";
            TMove_Pos m_pos = null;
            bool can_go = false;

            m_pos = Get_Move_Pos(station, step);
            if (m_pos != null)
            {
                can_go = (step == 0 && Robot_Can_Run_Go(Robot.Now_Pos));
                if (m_pos.Can_Move)
                {
                    Set_Speed(m_pos.Speed);
                    if(can_go)
                        Robot.Go(m_pos.Pos); 
                    else
                       Robot.Go(m_pos.Pos); //1002_新增_TRY
                       // Robot.Move(m_pos.Pos);//原程式
                    result = true;
                }
                else
                    Log_Add(fun, "目前位置無法驅動", emLog_Type.Warning);
            }
            else
            {
                Log_Add(fun, "驅動位置不存在", emLog_Type.Warning);
            }
            return result;
        }

        private TMove_Pos_List Get_Move_Pos_List(emRobot1_Loop station)
        {
            TMove_Pos_List result = null;

            switch (station)
            {
            
                case emRobot1_Loop.Tray_Load: result = Pos_List_Tray_Load; break;
                case emRobot1_Loop.Plasma_Load: result = Pos_List_Plasma_Load; break;
                case emRobot1_Loop.Plasma_Unload: result = Pos_List_Plasma_Unload; break;
                case emRobot1_Loop.ACF_Load: result = Pos_List_ACF_Load; break;
                case emRobot1_Loop.ACF_Unload: result = Pos_List_ACF_Unload; break;
                case emRobot1_Loop.PCB_Load: result = Pos_List_PCB_Load; break;
                case emRobot1_Loop.PCB_Unload: result = Pos_List_PCB_Unload; break;
                case emRobot1_Loop.NG: result = Pos_List_NG; break;
                case emRobot1_Loop.Teach: result = Pos_List_Teach; break;
            }
            return result;
        }
        private TMove_Pos Get_Move_Pos(emRobot1_Loop station, int pos)
        {
            TMove_Pos result = null;
            TMove_Pos_List pos_list = null;

            pos_list = Get_Move_Pos_List(station);
            if (pos_list != null) result = pos_list[pos];
            return result;
        }
        private bool Robot_Can_Run_Go(TEFC_SpelPoint point)
        {
            bool result = false;

         //   if (point.X > -Safe_Pos_XY && point.X < Safe_Pos_XY && point.Y > -Safe_Pos_XY && point.Y < Safe_Pos_XY) //1002註解
                result = true;//強制true
            return result;
        }
        private emRobot1_Loop Get_emRobot_Loop(int type)
        {
            emRobot1_Loop result = emRobot1_Loop.None;

            switch (type)
            {
                case 1: result = emRobot1_Loop.Home; break;
                case 2: result = emRobot1_Loop.Tray_Load; break;
                case 3: result = emRobot1_Loop.Plasma_Load; break;
                case 4: result = emRobot1_Loop.Plasma_Unload; break;
                case 5: result = emRobot1_Loop.ACF_Load; break;
                case 6: result = emRobot1_Loop.ACF_Unload; break;
                case 7: result = emRobot1_Loop.PCB_Load; break;
                case 8: result = emRobot1_Loop.PCB_Unload; break;
                case 9: result = emRobot1_Loop.NG; break;
                case 10: result = emRobot1_Loop.Teach; break;

            }
            return result;
        }
        private bool Get_On_Pos(TMove_Pos_List pos_list, int no)
        {
            bool result = false;
      


            if (no >= 0 && no < pos_list.Count)
            {
                result = pos_list[no].On_Pos && Program_Running;
                
            }
            
            return result;
           
        }
        protected void Set_Data(ref TMove_Pos_List move_list, TRecipe_Robot_Pos_List pos_list)
        {
            move_list.Count = pos_list.Count;
            for (int i = 0; i < move_list.Count; i++)
            {
                move_list[i].Speed = pos_list[i].Speed;
                move_list[i].Pos.Set(pos_list[i].Pos);
            }
        }
        #endregion

    }
    public class TRobot1_IO_In
    {
        public bool Loop_Run_Req = false;
        public emRobot1_Loop Loop_Run_Type = emRobot1_Loop.None;
        public int Loop_Run_Step = 0;
        public int Loop_Run_Tray_No = 0;
        public int Loop_Run_Tray_Z_No = 0;

        public double Align_Ofs_X = 0;
        public double Align_Ofs_Y = 0;
        public double Align_Ofs_Q = 0;
    }
    public class TRobot1_IO_Out
    {
        public emRobot1_Loop Loop_Run_Type = emRobot1_Loop.None;
        public int Loop_Run_Step = 0;
        public int Loop_Run_Tray_No = 0;
        public int Loop_Run_Tray_Z_No = 0;

        public bool Loop_Running = false;
        public bool Loop_Run_Finish = false;
        public bool Loop_Run_OK = false;
    }
}
