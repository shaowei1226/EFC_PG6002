using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using EFC.Tool;


namespace EFC.Reader 
{
    public class TJDI_RFID_Reader : TBase_Reader
    {
        public TJDI_RFID_Reader()
        {
        }

        override public void Set_Default()
        {
            Setting("1,19200,N,8,1");
            ReadTimeout = 200;
            DataReceived += in_On_Read;
        }
        override public bool Check_Data(byte[] data)
        {
            bool result = false;
            int check_sum = Get_Check_Sum(data, 0, data.Length - 1);
            if (check_sum == data[data.Length - 1]) result = true;

            return result;
        }
        public int Get_Check_Sum(byte[] data, int start, int end)
        {
            int result = 0; 
            for (int i = 0; i < data.Length - 1; i++)
            {
                result = result ^ data[i];
            }
            return result;
        }
        override public string Get_Code(byte[] data)
        {
            string result = "";

            for (int i = 0; i < data.Length - 1; i++)
            {
                result = result + String_Tool.IntToHexStr(data[i], 2);
            }
            return result;
        }
    }
}
