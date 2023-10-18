using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace EFC.Reader
{
    public class TSoyal_RFID_Reader : TBase_Reader
    {
        public TSoyal_RFID_Reader()
        {
            Log_Source = "TSoyal_RFID_Reader";
        }

        override public void Set_Default()
        {
            Setting("1,9600,N,8,1");
            ReadTimeout = 200;
            DataReceived += in_On_Read;
        }

        // 範例: 7E 0A 00 03 01 E4 66 82 D8 02 27 D1
        // byte 00 = 7E               => Head
        // byte 01 = 0A               => Length
        // byte 02 = 00               => FIX
        // byte 03 = 03               => Data Echo
        // byte 04 = 01               => Node
        // byte 05-08 = E4 66 82 D8   => UID
        // byte 09 = 02               => S50 1K
        // byte 10 = 27               => XOR
        // byte 11 = D1               => Check Sum
        override public bool Check_Data(byte[] data)
        {
            bool result = true;

            if (data.Length >= 12)
            {
                byte[] sum_byte = Get_Sum(data, 2, 11);
                if (data[0] != 0x7E) result = false;
                if (data[1] != 0x0A) result = false;
                if (data[11] != sum_byte[0]) result = false;
            }
            else
            {
                result = false;
            }

            return result;
        }
        public byte[] Get_Sum(byte[] data, int start, int end)
        {
            byte[] result = null;
            int check_sum = 0;

            for (int i = start; i < end; i++)
                check_sum = check_sum + data[i];

            result = BitConverter.GetBytes(check_sum);
            return result;
        }
        override public string Get_Code(byte[] data)
        {
            string result = "";
            byte[] code_data = new byte[4];
            UInt32 UID;

            string str = Byte_To_Hex(data, data.Length);

            code_data[0] = data[8];
            code_data[1] = data[7];
            code_data[2] = data[6];
            code_data[3] = data[5];
            UID = BitConverter.ToUInt32(code_data, 0);
            result = UID.ToString("");
            Log_Add("Get_Code", "ID=" + result);

            return result;
        }
    }
}
