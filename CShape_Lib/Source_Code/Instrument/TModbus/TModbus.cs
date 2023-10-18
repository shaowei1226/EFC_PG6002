using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using EFC.Tool;

namespace EFC.Instrument.Modbus
{
    public enum emData_Size { Int16, Int32 }
    public class TBase_SerialPort
    {
        public SerialPort COM = new SerialPort();
        public TLog Log = null;
        public bool Log_Flag = true;
        public bool Log_HEX_Flag = true;


        private bool FEnabled;



        public TBase_SerialPort()
        {
            Setting("1,38400,N,8,1");
            COM.ReadTimeout = 200;
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
        public void Log_Add(string msg)
        {
            if (Log != null) Log.Add(msg);
        }
        public string Get_Hex_String(string str)
        {
            string result = "";
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                result = result + String_Tool.IntToHexStr(chars[i], 2) + " ";
            }
            return result;
        }
        public string Get_Hex_String(byte[] data)
        {
            string result = "";
            for (int i = 0; i < data.Length; i++)
            {
                result = result + String_Tool.IntToHexStr(data[i], 2) + " ";
            }
            return result;
        }
        public string Byte_To_String(byte[] data)
        {
            string result = "";

            for (int i = 0; i < data.Length; i++)
                result = result + (char)data[i];
            return result;
        }

        public byte[] COM_Read_Byte()
        {
            byte[] result = new byte[1000];
            int count = 0;
            int loop_count = 0;
            Thread.Sleep(200);
            while ((count = COM.Read(result, 0, result.Length)) == 0 && loop_count < 100)
            {
                loop_count++;
                Thread.Sleep(1);
            }
            Array.Resize(ref result, count);
            if (Log_Flag)
            {
                Log_Add("[TBase_SerialPort] Read Count = " + result.Length.ToString());
                if (Log_HEX_Flag) Log_Add("[TBase_SerialPort] Read = " + Get_Hex_String(result));
            }
            return result;
        }
        public void COM_Write_Byte(byte[] data)
        {
            COM.Write(data, 0, data.Length);
            if (Log_Flag)
            {
                Log_Add("[TBase_SerialPort] Send Count = " + data.Length.ToString());
                if (Log_HEX_Flag) Log_Add("[TBase_SerialPort] Send = " + Get_Hex_String(data));
            }
        }
    }

    public static class Modbus_Tool
    {
        static public int Byte_Add(byte add_data, byte[] sor, int sor_index)
        {
            int result = 0;
            sor[sor_index] = add_data;
            result = sor_index + 1;
            return result;
        }
        static public int Byte_Add(Int16 add_data, byte[] sor, int sor_index)
        {
            int result = 0;
            result = Byte_Add(Modbus_Tool.Get_Byte_Int(add_data), sor, sor_index);
            return result;
        }
        static public int Byte_Add(byte[] add_data, byte[] sor, int sor_index)
        {
            int result = 0;
            result = Byte_Add(add_data, add_data.Length, sor, sor_index);
            return result;
        }
        static public int Byte_Add(byte[] add_data, int add_len, byte[] sor, int sor_index)
        {
            int result = 0;
            Array.Copy(add_data, 0, sor, sor_index, add_len);
            result = sor_index + add_len;
            return result;
        }
        static public byte[] Get_CRC_16(Byte[] data)
        {
            return Get_CRC_16(data, 0, data.Length);
        }
        static public byte[] Get_CRC_16(Byte[] data, int start, int end)
        {
            byte[] result = new byte[2];
            UInt16 crc = 0xFFFF;

            for (int pos = start; pos < end; pos++)
            {
                crc ^= (UInt16)data[pos];          // 取出第一個byte與crc XOR

                for (int i = 8; i != 0; i--)
                {    // 巡檢每個bit  
                    if ((crc & 0x0001) != 0)
                    {      // 如果 LSB = 1   
                        crc >>= 1;                    // 右移1bit 並且 XOR 0xA001  
                        crc ^= 0xA001;
                    }
                    else                            // 如果 LSB != 1  
                        crc >>= 1;                    // 右移1bit
                }
            }

            result = BitConverter.GetBytes(crc);
            return result;
        }
        static public bool Check_CRC(byte[] check_byte)
        {
            bool result = false;
            byte[] crc = null;
            int len = check_byte.Length;

            if (len >= 4)
            {
                crc = Get_CRC_16(check_byte, 0, len - 2);
                if (crc[0] == check_byte[len - 2] && crc[1] == check_byte[len - 1]) result = true;
            }
            return result;
        }
        static public byte[] Swap_Byte(byte[] data)
        {
            byte[] result = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[data.Length - i - 1] = data[i];
            }
            return result;
        }
        static public byte[] Get_Byte_Int(int data)
        {
            byte[] result = BitConverter.GetBytes((UInt16)data);
            result = Swap_Byte(result);
            return result;
        }
        static public Int16 Byte_To_Int16(byte[] data, int ofs)
        {
            Int16 result = 0;
            byte[] tmp_byte = null;
            int data_size = 2;

            if (data.Length >= ofs + data_size)
            {
                tmp_byte = new byte[data_size];
                Array.Copy(data, ofs, tmp_byte, 0, data_size);
                tmp_byte = Swap_Byte(tmp_byte);
                result = BitConverter.ToInt16(tmp_byte, 0);
            }
            return result;
        }
        static public Int32 Byte_To_Int32(byte[] data, int ofs)
        {
            Int32 result = 0;
            byte[] tmp_byte = null;
            int data_size = 4;

            if (data.Length >= ofs + data_size)
            {
                tmp_byte = new byte[data_size];
                Array.Copy(data, ofs, tmp_byte, 0, data_size);
                tmp_byte = Swap_Byte(tmp_byte);
                result = BitConverter.ToInt32(tmp_byte, 0);
            }
            return result;
        }
        static public Int16[] Byte_To_Int16(byte[] data)
        {
            int count = data.Length / 2;
            Int16[] result = new Int16[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Byte_To_Int16(data, i * 2);
            }
            return result;
        }
        static public Int32[] Byte_To_Int32(byte[] data)
        {
            int count = data.Length / 4;
            Int32[] result = new Int32[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = Byte_To_Int32(data, i * 4);
            }
            return result;
        }
        static public byte[] Int16_To_Byte(Int16 value)
        {
            return Swap_Byte(BitConverter.GetBytes(value));
        }
        static public byte[] Int32_To_Byte(Int32 value)
        {
            return Swap_Byte(BitConverter.GetBytes(value));
        }
        static public byte[] Int16_To_Byte(Int16[] value, int count)
        {
            int data_size = 2;
            byte[] result = new byte[count * data_size];

            for (int i = 0; i < count; i++)
            {
                Array.Copy(Swap_Byte(BitConverter.GetBytes(value[i])), 0, result, i * data_size, data_size);
            }
            return result;
        }
        static public byte[] Int32_To_Byte(Int32[] value, int count)
        {
            int data_size = 4;
            byte[] result = new byte[count * data_size];

            for (int i = 0; i < count; i++)
            {
                Array.Copy(Swap_Byte(BitConverter.GetBytes(value[i])), 0, result, i * data_size, data_size);
            }
            return result;
        }
    }
    public class TModbus_Param  
    {
        public string Param_Name = "";
        public emData_Size Type = emData_Size.Int16;
        public int Addr = -1;
        public int Value;


        public TModbus_Param()
        {
        }
        public TModbus_Param(string param_name, int addr, int value, emData_Size type = emData_Size.Int16)
        {
            Set(param_name, addr, value, type);
        }
        public void Set(string param_name, int addr, int value, emData_Size type = emData_Size.Int16)
        {
            Param_Name = param_name;
            Addr = addr;
            Value = value;
            Type = type;
        }
        public void Set(TModbus_Param sor)
        {
            Copy(sor, this);
        }
        public void Copy(TModbus_Param sor, TModbus_Param dis)
        {
            dis.Param_Name = sor.Param_Name;
            dis.Type = sor.Type;
            dis.Addr = sor.Addr;
            dis.Value = sor.Value;
        }
        public void Copy(ref TModbus_Param dis)
        {
            Copy(this, dis);
        }
        public TModbus_Param Copy()
        {
            TModbus_Param result = new TModbus_Param();
            Copy(this, result);
            return result;
        }
    }
    public class TModbus_Param_List : CollectionBase
    {
        public TModbus_Param_List()
        {

        }
        public TModbus_Param this[int index]
        {
            get
            {
                TModbus_Param result = null;
                if (index >= 0 && index < List.Count) result = (TModbus_Param)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    List[index] = value.Copy();
                }
            }
        }
        public int IndexOf(TModbus_Param member)
        {
            return this.List.IndexOf(member);
        }
        public void Add(TModbus_Param member)
        {
            TModbus_Param tmp = member.Copy();
            if (IndexOf(member) < 0)
            {
                List.Add(tmp);
            }
        }
        public void Add(string param_name, int addr, int value, emData_Size type = emData_Size.Int16)
        {
            Add(new TModbus_Param(param_name, addr, value, type));
        }
        public void Remove(TModbus_Param member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }
        public void Copy(TModbus_Param_List sor, TModbus_Param_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.Add(sor[i]);
        }
        public void Copy(TModbus_Param_List dis)
        {
            Copy(this, dis);
        }
        public TModbus_Param_List Copy()
        {
            TModbus_Param_List result = new TModbus_Param_List();
            Copy(this, result);
            return result;
        }
        public void Set(TModbus_Param_List sor)
        {
            Copy(sor, this);
        }
    }
    public class TModbus_Base : TBase_SerialPort
    {
        public TModbus_Station_Base[] Station = new TModbus_Station_Base[0];

        public int Station_Count
        {
            get
            {
                return Station.Length;
            }
            set
            {
                Array.Resize(ref Station, value);
            }
        }
        public TModbus_Base()
        {
            Setting("1,38400,E,8,1");
            COM.ReadTimeout = 200;
            COM.Handshake = Handshake.None;

            // 在 XON/XOFF 軟體交握和 Request to Send/Clear to Send (RTS/CTS) 硬體交握，
            // 以及數據機通訊期間，通常啟用 Data Terminal Ready (DTR)。
            COM.DtrEnable = true;
            COM.RtsEnable = true;
        }
        public void Add_Station(TModbus_Station_Base station)
        {
            Station_Count++;
            Station[Station_Count - 1] = station;
            Station[Station_Count - 1].Modbus = this;
        }
        public byte[] Read_Byte(int station, int addr, int count)
        {
            byte[] result = new byte[1000];
            int get_count = 0;
            int tmp_addr = addr;
            int read_count = 0;
            int start_index = 0;
            byte[] send_byte = null;
            byte[] read_byte = null;
            byte[] check_byte = null;
            byte[] get_byte = null;

            while (start_index < count)
            {
                read_count = count - start_index;
                if (read_count > 100) read_count = 100;
                tmp_addr = addr + start_index;

                send_byte = Get_Read_Byte(station, 0x03, tmp_addr, read_count);
                COM_Write_Byte(send_byte);
                read_byte = COM_Read_Byte();
                check_byte = Get_Check_Byte(read_byte, send_byte);
                if (check_byte != null && Read_Decode(check_byte))
                {
                    get_byte = Get_Data_Byte(check_byte);
                    get_count = Modbus_Tool.Byte_Add(get_byte, result, get_count);
                    start_index = start_index + read_count;
                }
                else 
                    break;
            }

            if (get_count == 0) result = null;
            else Array.Resize(ref result, get_count);
            return result;
        }
        public bool Read_Int16(int station, int addr, ref Int16 value)
        {
            bool result = false;
            byte[] get_data_byte = Read_Byte(station, addr, 1);
            if (get_data_byte != null && get_data_byte.Length >= 2)
            {
                value = Modbus_Tool.Byte_To_Int16(get_data_byte, 0);
                result = true;
            }
            return result;
        }
        public bool Read_Int32(int station, int addr, ref Int32 value)
        {
            bool result = false;
            byte[] get_data_byte = Read_Byte(station, addr, 2);
            if (get_data_byte != null && get_data_byte.Length >= 4)
            {
                value = Modbus_Tool.Byte_To_Int32(get_data_byte, 0);
                result = true;
            }
            return result;
        }
        public Int16[] Read_Int16(int station, int addr, int count)
        {
            Int16[] result = null;
            byte[] get_data_byte = Read_Byte(station, addr, count);

            if (get_data_byte != null && get_data_byte.Length >= count * 2)
            {
                result = new Int16[count];
                for (int i = 0; i < count; i++)
                {
                    result[i] = Modbus_Tool.Byte_To_Int16(get_data_byte, i * 2);
                }
            }
            return result;
        }
        public Int32[] Read_Int32(int station, int addr, int count)
        {
            Int32[] result = null;
            byte[] get_data_byte = Read_Byte(station, addr, count);
            if (get_data_byte != null && get_data_byte.Length >= count * 4)
            {
                result = new Int32[count];
                for (int i = 0; i < count; i++)
                {
                    result[i] = Modbus_Tool.Byte_To_Int16(get_data_byte, i * 4);
                }
            }
            return result;
        }
        public bool Read_Param(int station, ref TModbus_Param param)
        {
            bool result = false;
            if (param != null)
            {
                if (param.Type == emData_Size.Int16)
                {
                    Int16 value_16 = 0;
                    result = Read_Int16(station, param.Addr, ref value_16);
                    if (result) param.Value = value_16;
                }

                if (param.Type == emData_Size.Int32)
                {
                    Int32 value_32 = 0;
                    result = Read_Int32(station, param.Addr, ref value_32);
                    if (result) param.Value = value_32;
                }
            }
            return result;
        }


        public bool Write_Byte(int station, int addr, int count, byte[] data_byte)
        {
            bool result = false;
            int tmp_addr = addr;
            int read_count = 0;
            int start_index = 0;
            byte[] send_byte = null;
            byte[] read_byte = null;
            byte[] check_byte = null;
            byte[] tmp_data_byte = null;

            while (start_index < count)
            {
                read_count = count - start_index;
                if (read_count > 100) read_count = 100;
                tmp_addr = addr + start_index;
                tmp_data_byte = new byte[read_count * 2];
                Array.Copy(data_byte, start_index * 2, tmp_data_byte, 0, read_count * 2);

                send_byte = Get_Write_Byte(station, 0x10, tmp_addr, read_count, tmp_data_byte);
                COM_Write_Byte(send_byte);
                read_byte = COM_Read_Byte();
                check_byte = Get_Check_Byte(read_byte, send_byte);
                if (check_byte != null && Write_Decode(check_byte))
                {
                    start_index = start_index + read_count;
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        public bool Write_Int16(int station, int addr, Int16 data)
        {
            bool result = false;
            byte[] data_byte = Modbus_Tool.Int16_To_Byte(data);

            result = Write_Byte(station, addr, 1, data_byte);
            return result;
        }
        public bool Write_Int32(int station, int addr, Int32 data)
        {
            bool result = false;
            byte[] data_byte = Modbus_Tool.Int32_To_Byte(data);

            result = Write_Byte(station, addr, 2, data_byte);
            return result;
        }
        public bool Write_Int16(int station, int addr, int count, Int16[] data)
        {
            bool result = false;
            byte[] data_byte = Modbus_Tool.Int16_To_Byte(data, count);

            result = Write_Byte(station, addr, count, data_byte);
            return result;
        }
        public bool Write_Int32(int station, int addr, int count, Int32[] data)
        {
            bool result = false;
            byte[] data_byte = Modbus_Tool.Int32_To_Byte(data, count);

            result = Write_Byte(station, addr, count * 2, data_byte);
            return result;
        }
        public bool Write_Param(int station, TModbus_Param param)
        {
            bool result = false;
            if (param != null)
            {
                if (param.Type == emData_Size.Int16)
                {
                    result = Write_Int16(station, param.Addr, (Int16)param.Value);
                }
                if (param.Type == emData_Size.Int32)
                {
                    result = Write_Int32(station, param.Addr, param.Value);
                }
            }
            return result;
        }




        public byte[] Get_Read_Byte(int station, int fun, int addr, int count)
        {
            byte[] result = new byte[1000];
            int len = 0;

            len = Modbus_Tool.Byte_Add((byte)station, result, len);
            len = Modbus_Tool.Byte_Add((byte)fun, result, len);
            len = Modbus_Tool.Byte_Add((Int16)addr, result, len);
            len = Modbus_Tool.Byte_Add((Int16)count, result, len);
            len = Modbus_Tool.Byte_Add(Modbus_Tool.Get_CRC_16(result, 0, len), result, len);
            Array.Resize(ref result, len);
            return result;
        }
        public byte[] Get_Write_Byte(int station, int fun, int addr, int count, byte[] data_byte)
        {
            byte[] result = new byte[1000];
            int len = 0;

            len = Modbus_Tool.Byte_Add((byte)station, result, len);
            len = Modbus_Tool.Byte_Add((byte)fun, result, len);
            len = Modbus_Tool.Byte_Add((Int16)addr, result, len);
            len = Modbus_Tool.Byte_Add((Int16)count, result, len);
            len = Modbus_Tool.Byte_Add((byte)data_byte.Length, result, len);
            len = Modbus_Tool.Byte_Add(data_byte, result, len);
            len = Modbus_Tool.Byte_Add(Modbus_Tool.Get_CRC_16(result, 0, len), result, len);
            Array.Resize(ref result, len);
            return result;
        }
        public byte[] Get_Check_Byte(byte[] read_byte, byte[] send_byte)
        {
            byte[] result = null;
            int len = read_byte.Length - send_byte.Length;
            if (len > 0)
            {
                result = new byte[len];
                Array.Copy(read_byte, send_byte.Length, result, 0, len);
            }
            return result;
        }
        public byte[] Get_Data_Byte(byte[] read_byte)
        {
            byte[] result = null;
            int len = read_byte.Length;
            int get_len = 0;

            if (len > 4)
            {
                get_len = read_byte[2];
                if (len >= get_len + 4)
                {
                    result = new byte[get_len];
                    Array.Copy(read_byte, 3, result, 0, get_len);
                }
            }
            return result;
        }
          

        public bool Read_Decode(byte[] check_byte)
        {
            bool result = false;

            if (check_byte.Length >= 4 && Modbus_Tool.Check_CRC(check_byte))
            {
                if (check_byte[1] == 0x90)
                {
                    Log_Add("Write Error");
                }
                else result = true;
            }
            return result;
        }
        public bool Write_Decode(byte[] check_byte)
        {
            bool result = false;

            if (check_byte.Length >= 4 && Modbus_Tool.Check_CRC(check_byte))
            {
                if (check_byte[1] == 0x90)
                {
                    Log_Add("Write Error");
                }
                else result = true;
            }
            return result;
        }


    }
    public class TModbus_Station_Base
    {
        public int Station_No = 1;
        public TModbus_Base Modbus = null;

        public TModbus_Station_Base(int station_no)
        {
            Station_No = station_no;
        }
        public byte[] Read_Byte(int addr, int count)
        {
            return Modbus.Read_Byte(Station_No, addr, count);
        }
        public bool Read_Int16(int addr, ref Int16 value)
        {
            return Modbus.Read_Int16(Station_No, addr, ref value);
        }
        public bool Read_Int32(int addr, ref Int32 value)
        {
            return Modbus.Read_Int32(Station_No, addr, ref value);
        }
        public Int16[] Read_Int16(int addr, int count)
        {
            return Modbus.Read_Int16(Station_No, addr, count);
        }
        public Int32[] Read_Int32(int addr, int count)
        {
            return Modbus.Read_Int32(Station_No, addr, count);
        }
        public bool Read_Int16(string param_name, ref Int16 value)
        {
            bool result = false;
            TModbus_Param param = Get_Param(param_name, emData_Size.Int16);
            if (param != null)
            {
                result = Read_Param(ref param);
                value = (Int16)param.Value;
            }
            return result;
        }
        public bool Read_Int32(string param_name, ref Int32 value)
        {
            bool result = false;
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                result = Read_Param(ref param);
                value = param.Value;
            }
            return result;
        }
        public bool Read_Param(ref TModbus_Param param)
        {
            return Modbus.Read_Param(Station_No, ref param);
        }


        public bool Write_Byte(int addr, int count, byte[] data_byte)
        {
            return Modbus.Write_Byte(Station_No, addr, count, data_byte);
        }
        public bool Write_Int16(int addr, Int16 data)
        {
            return Modbus.Write_Int16(Station_No, addr, data);
        }
        public bool Write_Int32(int addr, Int32 data)
        {
            return Modbus.Write_Int32(Station_No, addr, data);
        }
        public bool Write_Int16(int addr, int count, Int16[] data)
        {
            return Modbus.Write_Int16(Station_No, addr, count, data);
        }
        public bool Write_Int32(int addr, int count, Int32[] data)
        {
            return Modbus.Write_Int32(Station_No, addr, count, data);
        }
        public bool WriteInt16(string param_name, Int16 value)
        {
            bool result = false;
            TModbus_Param param = Get_Param(param_name, emData_Size.Int16);
            if (param != null)
            {
                param.Value = value;
                result = Write_Param(param);
            }
            return result;
        }
        public bool Write_Int32(string param_name, Int32 value)
        {
            bool result = false;
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                param.Value = value;
                result = Write_Param(param);
            }
            return result;
        }
        public bool Write_Param(TModbus_Param param)
        {
            return Modbus.Write_Param(Station_No, param);
        }


        public TModbus_Param Get_Param(string param_name, emData_Size type = emData_Size.Int16)
        {
            TModbus_Param result = new TModbus_Param();
            ArrayList list = new ArrayList();

            String_Tool.Break_String(param_name, "/", ref list);
            if (type == emData_Size.Int16) result = Get_Param_W2(list);
            if (type == emData_Size.Int32) result = Get_Param_W4(list);
            return result;
        }
        virtual public TModbus_Param Get_Param_W2(ArrayList param_list)
        {
            return null;
        }
        virtual public TModbus_Param Get_Param_W4(ArrayList param_list)
        {
            return null;
        }

        public string List_To_String(ArrayList param_list)
        {
            string result = "";

            for (int i = 0; i < param_list.Count; i++)
            {
                if (result != "")
                    result = result + "/" + (string)param_list[i];
                else
                    result = (string)param_list[i];
            }
            return result;
        }
    }
}
