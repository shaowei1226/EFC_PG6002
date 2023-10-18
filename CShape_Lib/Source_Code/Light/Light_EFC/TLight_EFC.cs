using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO.Ports; 
using System.Timers;
using System.Runtime.InteropServices;
using EFC.Tool;
using EFC.Light;


namespace EFC.Light.EFC
{
    public class TLight_EFC : TLight_Base 
    {
        public TBase_SerialPort COM = new TBase_SerialPort();
        public bool Buzy = false;

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
        public TLight_EFC()
        {
            Channel_Count = 16;
            Max_Value = 63;
            COM.Setting("1,9600,N,8,1");
            COM.Read_Timer.Interval = 200;
        }
        override public bool Set_Light(int in_channel, int in_value)
        {
            bool result = false;
            string no_str, value_str;
            String send_str;
            int channel = 0;
            int value = 0;

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            Channels[channel].Value = value;
            Wait_Ready();
            if (COM.IsOpen)
            {
                Buzy = true;
                no_str = String_Tool.IntToHexStr(channel, 2);
                value_str = String_Tool.IntToHexStr(value, 2);
                send_str = ":" + no_str + value_str + ";";
                COM.Write(send_str);
                Buzy = false;
                result = true;
            }
            return result;
        }
        public void Wait_Ready()
        {
            while (Buzy) { };
        }
    }
}
