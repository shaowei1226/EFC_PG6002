using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using EFC.Tool;

namespace EFC.Instrument.Chroma
{
    public class TChroma
    {
        private bool FEnabled = false;
        private string Command, End_Code, Read_Code;
        private SerialPort COM = new SerialPort();

        public TChroma()
        {
            Command = "";
            End_Code = "\x0D\x0A";
            Setting("1,19200,N,8,1");
            COM.ReadTimeout =2000;
            COM.WriteTimeout = 2000;
        }
        //設定COM 編號
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

        public bool Set_BUS()
        {
            bool bResult = false;
            
            Command = "TRIGger:SOURce BUS";
            Send_Command(Command);

            Command = "TRIGger:SOURce?";
            if (Send_Command(Command,ref Read_Code))
            {
               if(Read_Code == "BUS")
               {
                   bResult = true;
               }
            }
            Read_Code = "";

            return bResult;
        }

        /// <summary>
        /// 設置採樣頻率
        /// </summary>
        /// <param name="iSpeed"></param>
        /// <returns></returns>
        public bool Set_Speed(int iSpeed)
        {
            bool bResult = false;
            string sSpeed;
            switch(iSpeed)
            {
                case 0:  sSpeed = "FAST";   break;
                case 1:  sSpeed = "MEDIum"; break;
                case 2:  sSpeed = "SLOW";   break;
                default: sSpeed = "SLOW";   break;
            }

            Command = "SENse:SPEEd " + sSpeed;
            Send_Command(Command);

            Command = "SENse:SPEEd?";
            if (Send_Command(Command, ref Read_Code))
            {
                Read_Code = Read_Code.Trim();
                sSpeed = sSpeed.Substring(0, 4);
                if (Read_Code == sSpeed)
                {
                    bResult = true;
                }
            }
            return bResult;
        }

        public bool TRIG(ref double value)
        {
            bool result = false;

            Command = "*TRG";
            if (Send_Command(Command,ref Read_Code))
            {
                try
                {
                    value = Convert.ToDouble(Read_Code);
                    result = true;
                } 
                catch
                {

                }
            }
           return result;
        }

        //發送指令
        public void Send_Command(string command)
        {
            try
            {
                command += End_Code;
                COM.Write(command);
            }
            catch
            {

            }
        }

        //發送指令(有傳回值)
        public bool Send_Command(string command,ref string sResult)
        {
            StringBuilder Read_Str = new StringBuilder();
            char[] tmp = new char[500];
            bool bResult = false;
            command += End_Code;
            try
            {
                COM.Write(command);
                bResult = true;
            }
            catch
            {
                bResult = false;
            }

            #region 讀取結果
            if (bResult)
            {
                bool bRead = true;
                bResult = false;
                int count = 0;
                try
                {
                    while (bRead)
                    {
                        COM.Read(tmp, count, 1);
                        if (tmp[count] == 0x0A)
                        {
                            bResult = true;
                            break;
                        }
                        else
                        {
                            Read_Str.Append(tmp[count]);
                        }
                        count++;
                    }
                }
                catch
                {
                    bRead = false;
                }
            }
            #endregion

            sResult = Read_Str.ToString();
            int pos = sResult.IndexOf("\r");
            if (pos > 0)
            {
                sResult = sResult.Substring(0, pos);
            }
            Read_Code = sResult;
            if (sResult == null)
            {
                bResult = false;
            }

            return bResult;
        }
    }
}
