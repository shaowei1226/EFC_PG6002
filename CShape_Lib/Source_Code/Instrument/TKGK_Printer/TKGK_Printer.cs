using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace EFC.Instrument.KGK
{
    public class TKGK_Printer
    {
        private string StartCode = "\x02";
        private string EndCode = "\x03";
        public SerialPort COM = new SerialPort();
        public bool FEnabled = false;

        public TKGK_Printer()
        {
            Setting("1,19200,N,8,1");
            COM.ReadTimeout = 1000;
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
                return FEnabled;
            }
        }
        public void Setting(string setting_str)
        {
            //傳入字串格式 ("Port,BaudRate,Parity,ByteSize,StopBit")
            //例:1,9600,N,8,1
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
        public bool Write_Code(string cmd)
        {
            bool bresult = false;
            bool bTimeOut = false;
            string sztmp="";
            if (COM.IsOpen)
            {
                if (COM.BytesToRead != 0)
                {
                    COM.ReadExisting();
                }
                int iLen = cmd.Length;
                string szLen = iLen.ToString("000");
                //string str = StartCode + "SMM001:::01:0::" + szLen + ":1" + cmd + ":" + EndCode;
                string str = StartCode + "STM:1:1::3" + cmd + ":" + EndCode;
                try
                {
                    COM.Write(str);
                    sztmp = COM.ReadTo("\x06");
                }
                catch
                {
                    bTimeOut = true;
                }
                if (sztmp.Length == 0 && !bTimeOut)
                {
                    bresult = true;
                }
                else
                {
                    bresult = false;
                }
            }
            return bresult;
        }
    }
}
