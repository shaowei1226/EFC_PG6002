using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS232_Musashi
{
    public class TPos
    {
        public double X;
        public double Y;
        public double Q;
        public double Z;
    }

    public class TBPos
    {
        public bool X;
        public bool Y;
        public bool Q;
        public bool Z;
    }

    public class TInj_Point_Struct
    {
        public double Inj_X;
        public double Inj_Y;
        public double Inj_Z;
        public double Inj_Speed;
        public bool Inj_Apply;
        public int Inj_Channel;
        public bool Inj_End;
        public bool Inj_UV;
        public double Inj_End_Ahead_Time;
    }

    public class TPosition_Data_Struct
    {
        public double Start_Base_Pitch;
        public double Start_X_Pitch;
        public double Start_Width_Pitch;
        public double End_X_Pitch;
        public double End_UV_Pitch;
        public double Move_Speed;
        public double UV_Speed;
        public double Delay_Pitch1;
        public double Delay_Pitch2;
        public double End_Ahead_Time;
    }

    public class TSide_Data
    {
        public class TPanel
        {

            public TPos Ofs_XYQ;               //Panel放置偏移量
            public TPos Inj_Pos_XY;            //載台塗膠位置XY
        }

        public class TInj
        {
            public int Count;                  //目前使用數量
            public TInj_Point_Struct[] Point = new TInj_Point_Struct[100];
            public TPosition_Data_Struct Position_Data = new TPosition_Data_Struct();
        }

        public class TLimit
        {
            public TBPos[] Flag = new TBPos[2];        //是否開啟限制        0:上限  1:下限
            public TPos[] Ofs = new TPos[2];           //限制參數            0:上限  1:下限
        }

        public class TCal_Limit
        {
            public bool Flag;                  //是否開啟限制
            public TPos[] Ofs = new TPos[2];   //0:上限 1:下限
        }


        public TPos Talbe_Ofs_XY;                       //載台塗膠偏移量
        public TPanel Panel = new TPanel();             //面板
        public TInj[] Inj = new TInj[2];                //膠針 0:垂直 1:水平
        public TPos Bonder;                             //壓合補正
        public TLimit[] Limit = new TLimit[2];          //限制條件 0:載台 1:手臂
        public TCal_Limit Cal_Limit = new TCal_Limit(); //計算載台修正量
        public int Musashi_Channel;                     //塗膠時頻道
    }

    public class Inj_Param
    {
        
    }
}
