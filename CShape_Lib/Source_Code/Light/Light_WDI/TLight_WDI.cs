using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO.Ports; 
//using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;
using EFC.Tool;


namespace EFC.Light.WDI
{
    public class TLight_WDI : TLight_Base
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
        public TLight_WDI()
        {
            Channel_Count = 1;
            Max_Value = 1023;
            COM.Setting("1,9600,N,8,1");
            COM.ReadTimeout = 200;
        }
        override public bool Set_Light(int in_channel, int in_value)
        {
            bool result = false;
            byte[] read = new byte[1000];
            byte[] send = new byte[] { 0x61, 0x00, 0x00 };
            byte[] light_byte;
            int channel = 0;
            int value = 0;

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            Value[channel] = value;

            light_byte = BitConverter.GetBytes((short)value);
            send[1] = light_byte[1];
            send[2] = light_byte[0];
            Write(send, 0, send.Length);
            Read(read, 0, 1000);
            result = true;
            return result;
        }

        public void Stop()
        {
            byte[] read = new byte[1000];
            byte[] send = new byte[] { 0x75, 0xEE };

            Write(send, 0, send.Length);
            Read(read, 0, 1000);

        }
        public void Start()
        {
            byte[] read = new byte[1000];
            byte[] send = new byte[] { 0x75, 0xAA };

            Write(send, 0, send.Length);
            Read(read, 0, 1000);
        }
        public void Set_DC_Mode()
        {
            byte[] read = new byte[1000];
            byte[] send = new byte[] { 0x72, 0x35 };

            Write(send, 0, send.Length);
            Read(read, 0, 1000);
        }
        public bool Set_DC_Light(int in_channel, int in_value)
        {
            Stop();
            Start();
            Set_DC_Mode();

            return Set_Light(in_channel, in_value);
        }
        public void Read(byte[] buffer, int offset, int count)
        {
            try
            {
                COM.Read(buffer, offset, count);
            }
            catch 
            {
            };

        }
        public void Write(byte[] buffer, int offset, int count)
        {
            try
            {
                COM.Write(buffer, offset, count);
            }
            catch 
            {
            };

        }
    }
}
