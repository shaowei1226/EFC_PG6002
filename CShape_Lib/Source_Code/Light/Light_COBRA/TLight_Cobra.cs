using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using EFC.Light;

namespace EFC.Light.Cobra
{
    /// <summary>
    /// Cobra Flex 的燈光控制，透過設定IP跟Port，TCP連線的方式控制
    /// <param>使用Connect進行連線，使用connected檢察連線狀態</param>
    /// <param>透過TurnLightOn/Off控制燈的開關</param>
    /// </summary>
    public class TLight_Cobra : TLight_Base
    {
        private bool FEnabled;
        //public string sIP ;
        TcpClient TCPConn = new TcpClient();
        private string host;
        private int port;
        private bool isLightOn = false;
        private const int MaxGLI = 200;


        public string Host
        {
            get 
            { 
                return host; 
            } 
        }
        public int Port
        { 
            get
            { 
                return port; 
            } 
        }
        public bool Connected 
        { 
            get 
            { 
                return TCPConn.Connected; 
            } 
        }
        public bool IsLightOn 
        { 
            get 
            { 
                return isLightOn; 
            } 
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
                            Connect();
                        else
                            Disconnect();
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
        public TLight_Cobra(string h = "10.0.0.10", int p = 1000)
        {
            host = h;
            port = p;
            Max_Value = 100;
            Channel_Count = 1;
        }
        override public bool Set_Light(int in_channel, int in_value)
        {
            bool result = false;
            int channel = 0;
            int value = 0;

            channel = Get_Channel(in_channel);
            value = Get_Value(in_value);
            Value[channel] = value;

            try
            {
                string msg = "GLI=" + value.ToString() + "\r";  // 設定光亮度的指令
                var NS = TCPConn.GetStream();
                var buffer = Encoding.GetEncoding("Big5").GetBytes(msg);
                NS.Write(buffer, 0, buffer.Length);
            }
            catch (Exception)
            {
                result = true;
            }


            return result;
        }

        private bool Connect()
        {
            try
            {
                TCPConn.Connect(Host, Port);
                if (Connected)
                {   //預設一開始是關燈狀態
                    TurnLightOff();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Connected;
        }
        private void Disconnect()
        {
            try
            {
                TCPConn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void TurnLightOn(int volume = 50)
        {
            volume = volume < 0 ? 0 : volume > 100 ? 100 : volume;

            try
            {
                int correspondGLI = (int)((float)volume / 100 * MaxGLI);
                SetLightGLI(correspondGLI);
                if (correspondGLI != 0)
                {
                    isLightOn = true;
                }
                else
                {
                    isLightOn = false;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Turn On Light Failed.");
            }

        }
        public void TurnLightOff()
        {
            try
            {
                SetLightGLI(0);
                isLightOn = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Turn Off Light Failed.");
            }
        }
        private void SetLightGLI(int value)
        {
            string msg = "GLI=" + value.ToString() + "\r";  // 設定光亮度的指令
            var NS = TCPConn.GetStream();
            var buffer = Encoding.GetEncoding("Big5").GetBytes(msg);
            NS.Write(buffer, 0, buffer.Length);
        }

    }
}
