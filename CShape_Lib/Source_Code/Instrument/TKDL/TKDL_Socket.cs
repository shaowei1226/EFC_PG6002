using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using EFC.Tool;


namespace EFC.Instrument.KDL
{
    public class TKDL_Socket
    {
        //私域變數
        private string               Start_Code;
        private string               Cut_Code;
        private string               End_Code;
        private int                  CIM_No;

        public TJJS_CLientSockect    Socket = new TJJS_CLientSockect();
        public TLog                  Log = new TLog();

        public TKDL_Socket()
        {
            Start_Code = "\x02";
            Cut_Code = "\x09";
            End_Code = "\x03";

            Socket.Host = "192.168.99.0";
            Socket.Port = 5000;
          
            CIM_No = 0;
            Log.Enabled = false;
            Socket.OnConnect += On_Connect;
            Socket.OnDisconnect += On_DisConnect;
            Socket.OnRead += On_Read;
        }
        public void On_Connect(TJJS_Socket s_socket)
        {

        }
        public void On_DisConnect(TJJS_Socket s_socket)
        {

        }
        public void On_Read(TJJS_Socket s_socket)
        {
            //string read_str = "";
            //read_str = Socket.Recive_String();
        }


        public bool Send_Command(string szCommand)
        {
            bool result = false ;
            string read_str = "";
            int pos = 0;

            Log.Add("Send=" + szCommand);
            if (Socket.Active)
            {
                Socket.Send_String(szCommand);
                

                read_str = Socket.Recive_String("\x03");
                Log.Add("Recive=" + read_str);

                pos = read_str.IndexOf("OK");
                if (pos >= 0)
                {
                    CIM_No++;
                    if (CIM_No > 999) CIM_No = 1;
                    result = true;
                }
            }
            else
            {
                Log.Add("Socket not connect.");
                result = false;
            }
            return result;
        }
        public bool Send_Data(TKDL_Data data)
        {
            string send_str;
            send_str = Start_Code + 
                       data.Bardcode + Cut_Code +
                       CIM_No + Cut_Code +
                       data.Send_Str + Cut_Code + 
                       End_Code;

            return Send_Command(send_str);
        }
        public bool Check_Barcode(string str)
        {
            bool result = false;
            return result;
        }
    }
    public class TKDL_Data
    {
        public String      Send_Str = "";
        public string      Start_Code;
        public string      Cut_Code;
        public string      End_Code;
        public string      Bardcode = "";


        public TKDL_Data()
        {
            Start_Code = "\x02";
            Cut_Code = "\x09";
            End_Code = "\x03";
        }
        public void Add_Data(string cmd, string data)
        {
            if (Send_Str != "") Send_Str = Send_Str + Cut_Code;
            Send_Str = Send_Str + cmd + Cut_Code + data;
        }
        public void Add_Data(string cmd, int data, string format = "")
        {
            Add_Data(cmd, data.ToString(format));
        }
        public void Add_Data(string cmd, double data, string format = "0.000")
        {
            Add_Data(cmd, data.ToString(format));
        }
        public void Add_Data(string cmd, bool data)
        {
            if (data) Add_Data(cmd, "1");
            else Add_Data(cmd, "0");
        }
    }
}
