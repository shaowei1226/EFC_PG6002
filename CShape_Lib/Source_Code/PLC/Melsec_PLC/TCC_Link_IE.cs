using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace EFC.PLC.Melsec
{
    public static class emCC_Link_Device_Type
    {
        //資料參考sh081035engn.pdf 52頁
        //目前先列常用的
        static public int X =  1;
        static public int Y =  2;
        static public int L =  3;
        static public int M =  4;
        static public int SM = 5;
        static public int D = 13;
        static public int B = 23;
        static public int W = 24;
    };

    public class TCC_Link
    {
        public int Handle = 0;       //連結的通道Channel 程式參數叫path
        public int Netno = 1;
        public bool ConnectState = false;
        public TCC_Link_Stations Stations = new TCC_Link_Stations();

        public TCC_Link()
        {
        }
        public void Connect()
        {
            int ErrorCode;
            ConnectState = false;
            if ((ErrorCode = CC_Link_IE_Dll.mdOpen(151, 0, ref Handle)) == 0) //中間參數0為Mode尚未有詳細說明,須注意
            {
                ConnectState = true;
                Update();
            };
        }
        public void Close()
        {
            ConnectState = false;
            CC_Link_IE_Dll.mdClose(Handle);
            Update();
        }
        private void Update()
        {
            for (int i = 0; i < Stations.Count; i++)
                Stations[i].Handle = Handle;
        }
    }
    public class TCC_Link_Stations
    {
        public TCC_Link_Base_Station[] Stations = new TCC_Link_Base_Station[0];

        public int Count
        {
            get
            {
                return Stations.Length;
            }
            set
            {
                int old_count = Stations.Length;
                Array.Resize(ref Stations, value);
            }
        }
        public TCC_Link_Base_Station this[int index]
        {
            get
            {
                TCC_Link_Base_Station result = null;

                if (index >= 0 && index < Count) result = Stations[index];
                return result;
            }
        }
        public TCC_Link_Base_Station Last_Station
        {
            get
            {
                return this[Count - 1];
            }
        }
        public void Add_Station(TCC_Link_Base_Station station)
        {
            station.LB_Start_No = Get_LB_Start_No();
            station.LW_Start_No = Get_LW_Start_No();
            Count++;
            Stations[Count - 1] = station;
        }
        public int Get_LB_Start_No()
        {
            int result = 0;

            if (Last_Station != null)
                result = Last_Station.LB_Start_No + Last_Station.LB_Count;
            return result;
        }
        public int Get_LW_Start_No()
        {
            int result = 0;

            if (Last_Station != null)
                result = Last_Station.LW_Start_No + Last_Station.LW_Count;
            return result;
        }
    }
    public class TCC_Link_Base_Station
    {
        public int Handle = 0;
        public int Station_No = 0xFF;
        public bool[] LB = new bool[0];
        public ushort[] LW = new ushort[0];
        public int LB_Start_No = 0x00;
        public int LW_Start_No = 0x00;

        public int LB_Count
        {
            get
            {
                return LB.Length;
            }
            set
            {
                Array.Resize(ref LB, value);
            }
        }
        public int LW_Count
        {
            get
            {
                return LW.Length;
            }
            set
            {
                Array.Resize(ref LW, value);
            }
        }
        public TCC_Link_Base_Station()
        {
        }
        public TCC_Link_Base_Station(int lb_count, int lw_count)
        {
            LB_Count = lb_count;
            LW_Count = lw_count;
        }

        public bool Read_LB()
        {
            bool result = false;
            int error_code = 0;

            error_code = CC_Link_IE_Dll.mdReceiveEx(Handle, 0, Station_No, emCC_Link_Device_Type.B, LB_Start_No, ref LB);
            if (error_code == 0) result = true;
            return result;
        }
        public bool Read_LW()
        {
            bool result = false;
            int error_code = 0;

            error_code = CC_Link_IE_Dll.mdReceiveEx(Handle, 0, Station_No, emCC_Link_Device_Type.W, LW_Start_No, ref LW);
            if (error_code == 0) result = true;
            return result;
        }
        public bool Write_LB()
        {
            bool result = false;
            int error_code = 0;

            error_code = CC_Link_IE_Dll.mdSendEx(Handle, 0, Station_No, emCC_Link_Device_Type.B, LB_Start_No, LB);
            if (error_code == 0) result = true;
            return result;
        }
        public bool Write_LW()
        {
            bool result = false;
            int error_code = 0;

            error_code = CC_Link_IE_Dll.mdSendEx(Handle, 0, Station_No, emCC_Link_Device_Type.W, LW_Start_No, LW);
            if (error_code == 0) result = true;
            return result;
        }
    }
}
