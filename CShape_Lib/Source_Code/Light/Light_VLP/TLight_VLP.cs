using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using EFC.Tool;
using EFC.Light;

namespace EFC.Light.VLP
{
    public class TLight_VLP : TLight_Base
    {
        public TBase_SerialPort COM = new TBase_SerialPort();

        public bool Enabled
        {
            get
            {
                return COM.Enabled;
            }
            set
            {
                COM.Enabled = value;
            }
        }
        public TLight_VLP()
        {
            Max_Value = 255;
            Channel_Count = 4;
            COM.Setting("1,38400,N,8,1");
            COM.ReadTimeout = 200;
            COM.WriteTimeout = 200;
        }
        override public bool Set_Light(int in_channel, int in_value)
        {
            bool result = false;
            string cmd = "";
            string read_str = "";
            int channel = 0;
            int value = 0;

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            Value[channel] = value;
            cmd = "@" + channel.ToString("00") + "F" + value.ToString("000") + "00";
            result = Write(cmd, ref read_str);

            Set_ON(channel);
            return result;
        }

        public bool Set_ON(int in_channel)
        {
            bool result = false;
            string cmd = "";
            string read_str = "";
            int channel = 0;

            channel = Get_Channel(in_channel);
            cmd = "@" + channel.ToString("00") + "L1" + "00";
            result = Write(cmd, ref read_str);

            return result;
        }
        public bool Set_OFF(int in_channel)
        {
            bool result = false;
            string cmd = "";
            string read_str = "";
            int channel = 0;

            channel = Get_Channel(in_channel);

            cmd = "@" + channel.ToString("00") + "L0" + "00";
            result = Write(cmd, ref read_str);

            return result;
        }

        private string CheckSum(string str)
        {
            string result = "";
            char[] chs = str.ToCharArray();
            int sum = 0;

            for (int i = 0; i < chs.Length; i++)
            {
                sum = sum + chs[i];
            }
            result = String_Tool.IntToHexStr(sum, 2);

            return result;
        }
        private bool Write(string cmd, ref string read_str)
        {
            bool result = false;
            string send_str = "";

            if (COM.IsOpen)
            {
                send_str = cmd + CheckSum(cmd) + "\r\n";
                COM.Write(send_str);
                JJS_LIB.Sleep(200);
                result = Read(ref read_str);
            }
            return result;
        }
        private bool Read(ref string read_str)
        {
            bool result = false;


            read_str = COM.ReadExisting();
            result = true;
            return result;
        }
         
    }

    public class TLight_VLP_Model : TLight_Base
    {
        public TBase_SerialPort COM = new TBase_SerialPort();
        private int Strobe_Value_Min = 0;
        private int Strobe_Value_Max = 255;
        public string CR = "\x0D";
        public string LF = "\x0A";
        private string in_Model = "";


        public bool Enabled
        {
            get
            {
                return COM.Enabled;
            }
            set
            {
                COM.Enabled = value;
            }
        }
        public string Model
        {
            get
            {
                return in_Model;
            }
            set
            {
                Set_Model(value);
            }
        }
        public TLight_VLP_Model()
        {
            Channel_Count = 4;
            Max_Value = 255;
            Set_Default();
            Set_Model("VLP_2430-3");
        }
        override public bool Set_Light(int ch_no, int value)
        {
            bool result = false;

            Set_Value(ch_no, value);
            Set_ON_OFF(ch_no, true);
            result = true;
            return result;
        }

        public TLight_VLP_Model(int com_port)
        {
            Set_Default();
            COM.Set_Com_Port(com_port);
        }
        public void Set_Default()
        {
            COM.Setting("1,38400,N,8,1");
        }
        public void Set_Model(string model)
        {
            switch (model)
            {
                case "VLP_2430-2": Channel_Count = 2; break;
                case "VLP_2430-3": Channel_Count = 3; break;
                case "VLP_2430-4": Channel_Count = 4; break;
                case "VLP_2460-4": Channel_Count = 4; break;
                case "VLP_2430-2e": Channel_Count = 2; break;
                case "VLP_2430-3e": Channel_Count = 3; break;
                case "VLP_2430-4e": Channel_Count = 4; break;
                case "VLP_2460-4e": Channel_Count = 4; break;
            }
            in_Model = model;
        }

        public void Set_Light_Strobe_Mode(int ch_no, int value, int strobe_time)
        {
            Set_ON_OFF(ch_no, false);
            Set_Value(ch_no, value);
            Set_Strobe_Mode(ch_no, strobe_time);
            Set_ON_OFF(ch_no, true);
        }
        public void Set_Strobe_Mode(int in_channel, int in_value)
        {
            string cmd_str = "";
            string read_str = "";
            int channel = 0;
            int strobe_value = 0;

            channel = Get_Channel(in_channel);
            strobe_value = Get_Strobe_Value(in_value);


            cmd_str = "@" + channel.ToString("00") + "S" + strobe_value.ToString("00") + "00";
            cmd_str = cmd_str + Get_Sum(cmd_str) + CR + LF;

            COM.Log_Add(cmd_str);

            COM.WriteLine(cmd_str);
            //COM.Write(COM.Write_Data, 0, COM.Write_Count);
            JJS_LIB.Sleep(10);
            read_str = COM.ReadLine();

            COM.Log_Add(read_str);

        }
        public void Set_Value(int in_channel, int in_value)
        {
            string cmd_str = "";
            string read_str = "";
            int channel = 0;
            int value = 0;

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            Value[channel] = value;


            cmd_str = "@" + channel.ToString("00") + "F0" + value.ToString("00") + "00";
            cmd_str = cmd_str + Get_Sum(cmd_str) + CR + LF;

            COM.Log_Add(cmd_str);

            COM.WriteLine(cmd_str);
            //COM.Write(COM.Write_Data, 0, COM.Write_Count);
            JJS_LIB.Sleep(10);
            read_str = COM.ReadLine();

            COM.Log_Add(read_str);
        }
        public void Set_ON_OFF(int in_channel, bool status)
        {
            string cmd_str = "";
            string read_str = "";
            int channel = 0;

            channel = Get_Channel(in_channel);

            string flag = status ? "1" : "0";
            cmd_str = "@" + channel.ToString("00") + "L" + flag + "00";
            cmd_str = cmd_str + Get_Sum(cmd_str) + CR + LF;

            COM.Log_Add(cmd_str);

            COM.WriteLine(cmd_str);
            //COM.Write(COM.Write_Data, 0, COM.Write_Count);
            JJS_LIB.Sleep(10);
            read_str = COM.ReadLine();

            COM.Log_Add(read_str);

        }


        private string Get_Sum(string cmd)
        {
            string result = "";
            byte[] btyes = new byte[1000];
            int check_sum = 0;

            COM.String_To_Byte(cmd, ref btyes, 0);
            for (int i = 0; i < cmd.Length; i++)
                check_sum = check_sum + btyes[i];

            result = String_Tool.IntToHexStr(check_sum, 2);
            return result;
        }
        public int Get_Strobe_Value(int value)
        {
            int result = 0;
            if (value < Strobe_Value_Min) result = Strobe_Value_Min;
            if (value >= Strobe_Value_Max) result = Strobe_Value_Max;
            return result;
        }
    }
}
