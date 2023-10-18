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
    public delegate void evComRead_Code(object sender, string code);
    public class TBase_Reader : TBase_SerialPort
    {
        public string Read_Code = "";
        public evComRead_Code On_Read_Code = null;
        public TBase_Reader()
        {
            Set_Default();
        }

        virtual public void Set_Default()
        {
            //base.Set_Default();
			Setting("1,9600,N,8,1");
        }

        override public void in_On_Read(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = Recive_Byte();
            if (Check_Data(data))
            {
                Read_Code = Get_Code(data);
                if (On_Read_Code != null) On_Read_Code(this, Read_Code);
            }
        }
        virtual public bool Check_Data(byte[] data)
        {
            return false;
        }
        virtual public string Get_Code(byte[] data)
        {
            return "";
        }
    }
}
