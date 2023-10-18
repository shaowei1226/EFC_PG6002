using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using EFC.Tool;

namespace EFC.Light.LVS
{
    public class TLight_LVS : TLight_Base
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
        public TLight_LVS()
        {
            Channel_Count = 1;
            Max_Value = 100;
            COM.Setting("1,19200,N,8,1");
            COM.ReadTimeout = 200;
            COM.WriteTimeout = 200;
        }
        override public bool Set_Light(int in_channel, int in_value)
        {
            bool result = false;
            string send_str, light_value;
            int channel = 0;
            int value = 0;

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            Value[channel] = value;
            if (COM.IsOpen)
            {
                light_value = String_Tool.IntToStr_A(value, emJJS_DataType.emJJS_dtTen, 3);
                send_str = ":" + "00LB" + light_value + "\r\n";
                COM.Write(send_str);
                result = true;
            }

            return result;
        }
    }


    public class TLight_LVS_HPLS : TLight_Base
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
        public TLight_LVS_HPLS()
        {
            Channel_Count = 1;
            Max_Value = 4095;
            COM.Setting("1,9600,N,8,1");
            COM.ReadTimeout = 200;
            COM.WriteTimeout = 200;
        }
        override public bool Set_Light(int in_channel, int in_value)
        {
            bool result = false;
            string send_str, light_value;
            int channel = 0;
            int value = 0;

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            if (COM.IsOpen)
            {
                light_value = String_Tool.IntToStr_A(value, emJJS_DataType.emJJS_dtTen, 4);
                send_str = "\x02" + "B" + light_value + "\x03";
                COM.Write(send_str);
                result = true;
            }

            return result;
        }
    }
}
