using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace EFC.Instrument.Inficon
{
    //
    //Inficon 氦檢儀
    //
    public class TInficon
    {
        private string             End_Code;
        public SerialPort          Comm = null;
        public System.Timers.Timer Timer = new System.Timers.Timer();
        public float               Value;

        public TInficon()
        {
            Comm = new SerialPort();
            End_Code = "\x0D\x0A";
            Comm.BaudRate = 19200;
            Comm.Parity = System.IO.Ports.Parity.None;
            Comm.StopBits = System.IO.Ports.StopBits.One;
            Comm.DataBits = 8;
            Comm.ReadTimeout = 5000;
            Comm.WriteTimeout = 5000;
            Timer.Interval = 100;
            Timer.Elapsed += On_Time;
            Timer.Enabled = true;
        }
        public bool Connect
        {
            get
            {
                return Comm.IsOpen;
            }
        }
        //設定COM 編號
        public bool Set_ComPort(String ComPort)
        {
            bool bResult = false;
            try
            {
                Comm.PortName = ComPort;
                Comm.Open();
                bResult = true;
            }
            catch
            {
                bResult = false;
            }
            return bResult;
        }
        //發送指令(有傳回值)
        public void On_Time(object sender, EventArgs e)
        {
            Timer.Enabled = false;
            if (Connect)
            {
                Read(ref Value);
            }
            Timer.Enabled = true;
        }
        public bool Send_Command(string command, ref string sResult)
        {
            StringBuilder Read_Str = new StringBuilder();
            char[] tmp = new char[500];
            bool bResult = false;
            command += End_Code;
            try
            {
                Comm.Write(command);
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
                        Comm.Read(tmp, count, 1);
                        if (tmp[count] == 0x0D)
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
            sResult = sResult.Trim();

            if (sResult == null || sResult == "")
            {
                bResult = false;
            }

            return bResult;
        }
        public bool Read(ref string value)
        {
            bool result = false;
            string cmd = "";

            cmd = "*read?";
            result = Send_Command(cmd, ref value);

            return result;
        }
        public bool Read(ref float value)
        {
            bool result = false;
            string read_str = "";

            try
            {
                result = Read(ref read_str);
                value = Convert.ToSingle(read_str);
            }
            catch
            {
            }
            return result;
        }
    }
}
