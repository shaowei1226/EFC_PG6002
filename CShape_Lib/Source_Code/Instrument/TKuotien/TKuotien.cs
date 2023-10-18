using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;
using System.Threading;
using EFC.Tool;

namespace EFC.Instrument.Kuotien
{
    //Lowcell 電子秤
    public class TKuotien
    {
        public bool Terminate = false;
        public bool Lock = false;
        public double Current_Valus = 0.0;
        public Thread Thread = null;
        public SerialPort COM = null;

        private bool FEnabled;

        public TKuotien()
        {
            COM = new SerialPort();

            Setting("1,9600,E,7,1");
            COM.ReadTimeout = 500;
            Thread = new Thread(new ThreadStart(Execute));
            Thread.Start();
        }
        public bool Enabled
        {
            set
            {
                try
                {
                    if (FEnabled != value)
                    {
                        FEnabled = value;
                        if (FEnabled)
                            COM.Open();
                        else
                            COM.Close();
                    }
                }
                catch
                {

                }
            }
            get
            {
                FEnabled = COM.IsOpen;
                return FEnabled;
            }
        }
        //傳入字串格式 ("Port,BaudRate,Parity,ByteSize,StopBit")
        //例:1,9600,N,8,1
        public void Setting(string setting_str)
        {
            ArrayList list = new ArrayList();
            String_Tool.Break_String(setting_str.ToUpper(), ",", ref list);

            if (list.Count == 5)
            {
                try
                {
                    //1.設定Com Port
                    COM.PortName = "COM" + list[0].ToString();

                    //2.設定BaudRate 9600 19200 38400 115200 128000
                    switch (list[1].ToString())
                    {
                        case "2400": COM.BaudRate = 2400; break;
                        case "4800": COM.BaudRate = 4800; break;
                        case "9600": COM.BaudRate = 9600; break;
                        case "14400": COM.BaudRate = 14400; break;
                        case "19200": COM.BaudRate = 19200; break;
                        case "38400": COM.BaudRate = 38400; break;
                        case "56000": COM.BaudRate = 56000; break;
                        case "115200": COM.BaudRate = 115200; break;
                        case "128000": COM.BaudRate = 128000; break;
                        default: COM.BaudRate = 9600; break;
                    }

                    //3.設定Parity
                    switch (list[2].ToString())
                    {
                        case "N": COM.Parity = System.IO.Ports.Parity.None; break;
                        case "O": COM.Parity = System.IO.Ports.Parity.Odd; break;
                        case "E": COM.Parity = System.IO.Ports.Parity.Even; break;
                        default: COM.Parity = System.IO.Ports.Parity.None; break;
                    }

                    //4.設定ByteSize
                    switch (list[3].ToString())
                    {
                        case "7": COM.DataBits = 7; break;
                        case "8": COM.DataBits = 8; break;
                        default: COM.DataBits = 8; break;
                    }

                    //5.設定StopBit
                    switch (list[3].ToString())
                    {
                        case "N": COM.StopBits = System.IO.Ports.StopBits.None; break;
                        case "1": COM.StopBits = System.IO.Ports.StopBits.One; break;
                        case "2": COM.StopBits = System.IO.Ports.StopBits.Two; break;
                        default: COM.StopBits = System.IO.Ports.StopBits.One; break;
                    }
                }
                catch
                {
                }
            }
        }
        public void Set_ComPort(String port_name)
        {
            COM.PortName = port_name;
        }
        public void Set_ComPort(int port_no)
        {
            string com = "COM" + Convert.ToInt16(port_no);
            COM.PortName = com;
        }
        public bool Write(string str)
        {
            bool result = false;
            string send_str;
            send_str = str + "\x0D" + "\x0A";

            try
            {
                COM.Write(send_str);
                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }
        public string Read()
        {
            string inbuff = "";
            string str;

            try
            {
                inbuff = COM.ReadLine();
            }catch{};

            if (inbuff.Length > 0)
            {
                str = inbuff.Substring(inbuff.IndexOf(",") + 1, inbuff.Length - inbuff.IndexOf(",") - 1);
                str = str.Substring(str.IndexOf(",") + 1, str.Length - str.IndexOf(",") - 1);
                str = str.Substring(0, str.Length - 3).Trim();
                inbuff = str;
            }

            return inbuff;
        }
        public void Execute()
        {
            while (!Terminate)
            {
                if (Enabled)
                {
                    Lock = true;
                    Write("R01");
                    Thread.Sleep(200);
                    try
                    {
                        Current_Valus = Convert.ToDouble(Read());
                    }
                    catch { };
                    Lock = false;
                }
                Thread.Sleep(200);
            }
        }
    }
}
