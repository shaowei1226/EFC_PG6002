using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using EFC.Tool;


namespace EFC.SECS
{
    public enum emHSMS_Type
    {
        List, Bin, Bool, ASCII, JIS_8, WChar,
        Int8, Int16, Int32, Int64, Float32, Float64, UInt8, UInt16, UInt32, UInt64
    }
    public enum emControl_Message
    { Select_Req, Select_Rsp, LinkTest_Req, LinkTest_Rsp, Separate_Req }
    public enum emHSMS_Rule_Mode { Active_Client, Passive_Server }
    
    //---------------------------------------------------------------------------
     public delegate void evSECS_SxFx_Event(TSxFx sf);
    //---------------------------------------------------------------------------
    //---------------------------------------------------------------------------
    public class THSMS_Header
    {
        public byte[] Data = new byte[10];

        public THSMS_Header()
        {

        }
        public THSMS_Header Copy()
        {
            THSMS_Header result = new THSMS_Header();
            Array.Copy(Data, 0, result.Data, 0, Data.Length);
            return result;
        }
        private bool Get_Bit(byte data, int bit_no)
        {
            bool result;
            int flag;

            flag = 0x0001;
            flag = flag << bit_no;
            if ((data & flag) == flag) result = true;
            else result = false;
            return result;
        }
        private void Set_Bit(ref byte data, int bit_no, bool value)
        {
            int flag1, flag2;

            flag1 = 0x01;
            flag1 = flag1 << bit_no;
            flag2 = flag1 ^ 0xFF;
            if (value) data = (byte)((data & flag2) | flag1);
            else data = (byte)(data & flag2);
        }
        public void Set_Data(byte[] data, int index)
        {
            if (data.Length >= 10 + index)
                Array.Copy(data, index, Data, 0, 10);
        }
        public bool R_Bit
        {
            get
            {
                return Get_Bit(Data[0], 7);
            }
            set
            {
                Set_Bit(ref Data[0], 7, value);
            }
        }
        public bool W_Bit
        {
            get
            {
                return Get_Bit(Data[2], 7);
            }
            set
            {
                Set_Bit(ref Data[2], 7, value);
            }
        }
        public bool E_Bit
        {
            get
            {
                return Get_Bit(Data[4], 7);
            }
            set
            {
                Set_Bit(ref Data[4], 7, value);
            }
        }
        public int Device_ID
        {
            get
            {
                int result;
                result = (Data[0] & 0x7F) * 256 + Data[1];
                return result;
            }
            set
            {
                Data[0] = (byte)((Data[0] & 0x80) | (value & 0x7FFF) >> 8);
                Data[1] = (byte)(value & 0x00FF);
            }
        }
        public int Stream_ID
        {
            get
            {
                int result;
                result = (Data[2] & 0x7F);
                return result;
            }
            set
            {
                Data[2] = (byte)((Data[2] & 0x80) | (value & 0x7F));
            }
        }
        public int Function_ID
        {
            get
            {
                return Data[3];
            }
            set
            {
                Data[3] = (byte)value;
            }
        }
        public int Block_No
        {
            get
            {
                int result;
                result = (Data[4] & 0x7F) * 256 + Data[5];
                return result;
            }
            set
            {
                Data[4] = (byte)((Data[4] & 0x80) | (value & 0x7FFF) >> 8);
                Data[5] = (byte)(value & 0x00FF);
            }
        }
        public int System_No
        {
            get
            {
                int result;
                result = Data[6] * 256 + Data[7];
                return result;
            }
            set
            {
                Data[6] = (byte)(value >> 8);
                Data[7] = (byte)(value & 0x00FF);
            }
        }
    }
    //---------------------------------------------------------------------------
    public class THSMS_Message
    {
        public byte[] Data = new byte[0];

        public THSMS_Message()
        {

        }
        public THSMS_Message Copy()
        {
            THSMS_Message result = new THSMS_Message();

            return result;
        }
        public void Init()
        {
        }
        public void Free()
        {
        }
        public int CheckData(byte[] data, int len)
        {
            int block_len = 0;

            if (len < 14) return -1;                      //檢查長度(1) 資料長度不足
            
            block_len = (int)Byte_Tool.Get_Int64(data, 0, 4);
            if (block_len + 4 != len) return -2;          //檢查長度(2) Block Len 錯誤
            return 0;
        }
        public bool Set_Data(byte[] data, int len)
        {
            bool result = false;

            if (CheckData(data, len) == 0)
            {
                Array.Resize(ref Data, len);
                Array.Copy(data, 0, Data, 0, len);
                result = true;
            }
            return result;
        }
        public THSMS_Header Get_Header()
        {
            THSMS_Header result = new THSMS_Header();
            result.Set_Data(Data, 4);
            return result;
        }
        public void Set_Header(THSMS_Header header)
        {
            Array.Copy(header.Data, 0, Data, 4, 10);
        }
        public byte[] Get_Body()
        {
            byte[] result = new byte[Data.Length - 14];

            Array.Copy(Data, 14, result, 0, Data.Length - 14);
            return result;
        }
        public void WriteStrings(ref ArrayList list)
        {
             string tmp;
             int i;

             list.Clear();
             tmp = "";
             i=0;
             if (Data.Length > 0)
             {
                 do
                 {
                     tmp += String_Tool.IntToHexStr(Data[i], 2) + " ";
                     if (i == 3 || i == 13 || (i - 13) % 30 == 0)
                     {
                         list.Add(tmp);
                         tmp = "";
                     }
                     i++;
                 } while (i < Data.Length);
                 if (tmp != "") list.Add(tmp);
             }
        }
    }
    //---------------------------------------------------------------------------
    public class TSxFx_Node_Data
    {
        public byte[] Data = new byte[8];
        public emHSMS_Type Type = emHSMS_Type.List;
        public bool Fix_Count;
        private int FData_Count;
        public int Data_Max_Count
        {
            get
            {
                return Data.Length;
            }
            set
            {
                int old_count;

                if (value != Data.Length && value > 8)
                {
                    old_count = Data.Length;
                    Array.Resize(ref Data, value);
                    for (int i = old_count; i < value; i++) Data[i] = 0x00;
                }
            }
        }
        public int Data_Count
        {
            get
            {
                return FData_Count;
            }
            set
            {
                FData_Count = value;
                if (FData_Count > Data_Max_Count)
                    Data_Max_Count = FData_Count;
            }
        }
        public emHSMS_Type Get_Type(byte ch)
        {
            emHSMS_Type result = emHSMS_Type.List;
            switch (ch)
            {
                case 0x00: result = emHSMS_Type.List; break;
                case 0x20: result = emHSMS_Type.Bin; break;
                case 0x24: result = emHSMS_Type.Bool; break;
                case 0x40: result = emHSMS_Type.ASCII; break;
                case 0x44: result = emHSMS_Type.JIS_8; break;
                case 0x48: result = emHSMS_Type.WChar; break;

                case 0x64: result = emHSMS_Type.Int8; break;
                case 0x68: result = emHSMS_Type.Int16; break;
                case 0x70: result = emHSMS_Type.Int32; break;
                case 0x60: result = emHSMS_Type.Int64; break;

                case 0x90: result = emHSMS_Type.Float32; break;
                case 0x80: result = emHSMS_Type.Float64; break;

                case 0xA4: result = emHSMS_Type.UInt8; break;
                case 0xA8: result = emHSMS_Type.UInt16; break;
                case 0xB0: result = emHSMS_Type.UInt32; break;
                case 0xA0: result = emHSMS_Type.UInt64; break;
            }
            return result;
        }
        public byte Get_Type_Code()
        {
            byte result = 0x00;
            switch (Type)
            {
                case emHSMS_Type.List: result = 0x00; break;
                case emHSMS_Type.Bin: result = 0x20; break;
                case emHSMS_Type.Bool: result = 0x24; break;
                case emHSMS_Type.ASCII: result = 0x40; break;
                case emHSMS_Type.JIS_8: result = 0x44; break;
                case emHSMS_Type.WChar: result = 0x48; break;

                case emHSMS_Type.Int8: result = 0x64; break;
                case emHSMS_Type.Int16: result = 0x68; break;
                case emHSMS_Type.Int32: result = 0x70; break;
                case emHSMS_Type.Int64: result = 0x60; break;

                case emHSMS_Type.Float32: result = 0x90; break;
                case emHSMS_Type.Float64: result = 0x80; break;

                case emHSMS_Type.UInt8: result = 0xA4; break;
                case emHSMS_Type.UInt16: result = 0xA8; break;
                case emHSMS_Type.UInt32: result = 0xB0; break;
                case emHSMS_Type.UInt64: result = 0xA0; break;
            }
            return result;
        }
        public string Get_Type_Str()
        {
            string result = "";
            switch (Type)
            {
                case emHSMS_Type.List: result = "L"; break;
                case emHSMS_Type.Bin: result = "B"; break;
                case emHSMS_Type.ASCII: result = "A"; break;
                case emHSMS_Type.JIS_8: result = "J"; break;
                case emHSMS_Type.WChar: result = "WA"; break;
                case emHSMS_Type.Bool: result = "Bool"; break;

                case emHSMS_Type.Int8: result = "I1"; break;
                case emHSMS_Type.Int16: result = "I2"; break;
                case emHSMS_Type.Int32: result = "I3"; break;
                case emHSMS_Type.Int64: result = "I4"; break;

                case emHSMS_Type.Float32: result = "F4"; break;
                case emHSMS_Type.Float64: result = "F8"; break;

                case emHSMS_Type.UInt8: result = "U1"; break;
                case emHSMS_Type.UInt16: result = "U2"; break;
                case emHSMS_Type.UInt32: result = "U3"; break;
                case emHSMS_Type.UInt64: result = "U4"; break;
            }
            return result;
        }
        public void Set_Type_Str(string type_str)
        {

            switch (type_str)
            {
                case "L": Type = emHSMS_Type.List; break;
                case "B": Type = emHSMS_Type.Bin; break;
                case "A": Type = emHSMS_Type.ASCII; break;
                case "J": Type = emHSMS_Type.JIS_8; break;
                case "WA": Type = emHSMS_Type.WChar; break;
                case "Bool": Type = emHSMS_Type.Bool; break;

                case "I1": Type = emHSMS_Type.Int8; break;
                case "I2": Type = emHSMS_Type.Int16; break;
                case "I3": Type = emHSMS_Type.Int32; break;
                case "I4": Type = emHSMS_Type.Int64; break;

                case "F4": Type = emHSMS_Type.Float32; break;
                case "F8": Type = emHSMS_Type.Float64; break;

                case "U1": Type = emHSMS_Type.UInt8; break;
                case "U2": Type = emHSMS_Type.UInt16; break;
                case "U3": Type = emHSMS_Type.UInt32; break;
                case "U4": Type = emHSMS_Type.UInt64; break;
            }
        }



        public TSxFx_Node_Data()
        {
            Init();
        }
        public void Init()
        {
            FData_Count = 0;
            Data_Max_Count = 8;
            Fix_Count = false;
        }
        public TSxFx_Node_Data Copy()
        {
            TSxFx_Node_Data result = new TSxFx_Node_Data();

            Array.Resize(ref result.Data, Data.Length);
            Array.Copy(Data, 0, result.Data, 0, Data.Length);
            result.Type = Type;
            result.Fix_Count = Fix_Count;
            result.FData_Count = FData_Count;
            return result;
        }
        public void Set_Data(byte[] data, int index, int len)
        {
            Data_Max_Count = len;
            if (data.Length >= index + len)
            {
                if (Data.Length >= len)
                    Array.Copy(data, index, Data, 0, len);
            }
        }
        public string Data_WChar
        {
            get
            {
                return Data_String;
            }
            set
            {
                Data_String = value;
            }
        }
        public string Data_JIS8
        {
            get
            {
                return Data_String;
            }
            set
            {
                Data_String = value;
            }
        }
        public string Data_String
        {
            get
            {
                string result = "";
                for (int i = 0; i < FData_Count; i++)
                    result = result + (char)Data[i];
                return result;
            }
            set
            {
                int len;
                char[] chs;

                chs = value.ToCharArray();
                len = value.Length;
                if (len > FData_Count) len = FData_Count;
                for (int i = 0; i < len; i++) Data[i] = (byte)chs[i];
                if (len < FData_Count)
                {
                    for (int i = len; i < FData_Count; i++) Data[i] = 0x20;
                }
            }
        }
        public byte Data_Int8
        {
            get
            {
                return Data[0];
            }
            set
            {
                Data[0] = value;
            }
        }
        public Int16 Data_Int16
        {
            get
            {
                Int16 result;
                result = BitConverter.ToInt16(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(Int16));
            }
        }
        public Int32 Data_Int32
        {
            get
            {
                Int32 result;
                result = BitConverter.ToInt32(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(Int32));
            }
        }
        public Int64 Data_Int64
        {
            get
            {
                Int64 result;
                result = BitConverter.ToInt64(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(Int64));
            }
        }
        public byte Data_UInt8
        {
            get
            {
                return Data[0];
            }
            set
            {
                Data[0] = value;
            }
        }
        public UInt16 Data_UInt16
        {
            get
            {
                UInt16 result;
                result = BitConverter.ToUInt16(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(UInt16));
            }
        }
        public UInt32 Data_UInt32
        {
            get
            {
                UInt32 result;
                result = BitConverter.ToUInt32(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(UInt32));
            }
        }
        public UInt64 Data_UInt64
        {
            get
            {
                UInt64 result;
                result = BitConverter.ToUInt64(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(UInt64));
            }
        }
        public float Data_Float32
        {
            get
            {
                float result;
                result = (float)BitConverter.ToSingle(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(float));
            }
        }
        public double Data_Float64
        {
            get
            {
                double result;
                result = BitConverter.ToDouble(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(double));
            }
        }
        public bool Data_Bool
        {
            get
            {
                bool result;
                result = BitConverter.ToBoolean(Data, 0);
                return result;
            }
            set
            {
                Array.Copy(BitConverter.GetBytes(value), 0, Data, 0, sizeof(bool));
            }
        }
        public int Get_Count()
        {
            int result = 0;
            switch (Type)
            {
                case emHSMS_Type.List: result = 0; break;
                case emHSMS_Type.Bin: result = 1; break;
                case emHSMS_Type.Bool: result = 1; break;
                case emHSMS_Type.ASCII: result = FData_Count; break;
                case emHSMS_Type.JIS_8: result = FData_Count; break;
                case emHSMS_Type.WChar: result = FData_Count; break;

                case emHSMS_Type.Int8: result = 1; break;
                case emHSMS_Type.Int16: result = 2; break;
                case emHSMS_Type.Int32: result = 4; break;
                case emHSMS_Type.Int64: result = 8; break;

                case emHSMS_Type.Float32: result = 4; break;
                case emHSMS_Type.Float64: result = 8; break;

                case emHSMS_Type.UInt8: result = 1; break;
                case emHSMS_Type.UInt16: result = 2; break;
                case emHSMS_Type.UInt32: result = 4; break;
                case emHSMS_Type.UInt64: result = 8; break;
            }
            return result;
        }
        public string Get_Data_String()
        {
            string result = "";
            switch (Type)
            {
                case emHSMS_Type.ASCII: result = Data_String; break;
                case emHSMS_Type.JIS_8: result = Data_JIS8; break;
                case emHSMS_Type.WChar: result = Data_WChar; break;

                case emHSMS_Type.Bin: result = String_Tool.IntToHexStr(Data_Int8, 2); break;

                case emHSMS_Type.Int8:  result = Data_Int8.ToString(); break;
                case emHSMS_Type.Int16: result = Data_Int16.ToString(); break;
                case emHSMS_Type.Int32: result = Data_Int32.ToString(); break;
                case emHSMS_Type.Int64: result = Data_Int64.ToString(); break;

                case emHSMS_Type.UInt8:  result = Data_UInt8.ToString(); break;
                case emHSMS_Type.UInt16: result = Data_UInt16.ToString(); break;
                case emHSMS_Type.UInt32: result = Data_UInt32.ToString(); break;
                case emHSMS_Type.UInt64: result = Data_UInt64.ToString(); break;

                case emHSMS_Type.Float32: result = Data_Float32.ToString(); break;
                case emHSMS_Type.Float64: result = Data_Float64.ToString(); break;

                case emHSMS_Type.Bool:
                    if (Data_Bool) result = "1";
                    else result = "0";
                    break;

                case emHSMS_Type.List:
                default:
                    break;
            }
            return result;
        }
        public void Set_Data_String(string data_str)
        {
            switch (Type)
            {
                case emHSMS_Type.ASCII:
                case emHSMS_Type.JIS_8:
                case emHSMS_Type.WChar:
                    Data_String = data_str;
                    break;

                case emHSMS_Type.Bin: Data_Int8 = (byte)String_Tool.HexStrToInt("0x" + data_str); break;

                case emHSMS_Type.Int8:  Data_Int8  = Convert.ToByte(data_str);  break;
                case emHSMS_Type.Int16: Data_Int16 = Convert.ToInt16(data_str); break;
                case emHSMS_Type.Int32: Data_Int32 = Convert.ToInt32(data_str); break;
                case emHSMS_Type.Int64: Data_Int64 = Convert.ToInt64(data_str); break;

                case emHSMS_Type.UInt8: Data_UInt8   = Convert.ToByte(data_str);   break;
                case emHSMS_Type.UInt16: Data_UInt16 = Convert.ToUInt16(data_str); break;
                case emHSMS_Type.UInt32: Data_UInt32 = Convert.ToUInt32(data_str); break;
                case emHSMS_Type.UInt64: Data_UInt64 = Convert.ToUInt64(data_str); break;

                case emHSMS_Type.Float32: Data_Float32 = Convert.ToSingle(data_str); break;
                case emHSMS_Type.Float64: Data_Float64 = Convert.ToDouble(data_str); break;

                case emHSMS_Type.Bool:
                    if (data_str.ToCharArray()[0] == '0') Data_Bool = false;
                    else Data_Bool = true;
                    break;

                case emHSMS_Type.List:
                default:
                    break;
            }
        }
        public bool Set_Data_Byte(byte[] data, ref int index, ref int sub_count)
        {
            byte type_ch = 0x00;
            int count_byte = 0;
            int count = 0;

            if ((index + 1) > data.Length) return false;
            type_ch = (byte)(data[index] & 0xFC);
            count_byte = data[index] & 0x03;
            index = index + 1;
            count = Byte_Tool.Get_Int32(data, index, count_byte);
            if ((index + count) > data.Length) return false;
            index = index + count_byte;

            sub_count = 0;
            Type = Get_Type(type_ch);
            switch (Type)
            {
                case emHSMS_Type.List: sub_count = count; count = 0; break;

                case emHSMS_Type.Bin:
                case emHSMS_Type.ASCII:
                case emHSMS_Type.JIS_8:
                case emHSMS_Type.WChar:
                    Data_Count = count;
                    Set_Data(data, index, count);
                    break;

                case emHSMS_Type.Int8:  Data_Int8 = data[index]; break;
                case emHSMS_Type.Int16: Data_Int16 = Byte_Tool.Get_Int16(data, index, count); break;
                case emHSMS_Type.Int32: Data_Int32 = Byte_Tool.Get_Int32(data, index, count); break;
                case emHSMS_Type.Int64: Data_Int64 = Byte_Tool.Get_Int64(data, index, count); break;

                case emHSMS_Type.UInt8:  Data_UInt8 = data[index]; break;
                case emHSMS_Type.UInt16: Data_UInt16 = Byte_Tool.Get_UInt16(data, index, count); break;
                case emHSMS_Type.UInt32: Data_UInt32 = Byte_Tool.Get_UInt32(data, index, count); break;
                case emHSMS_Type.UInt64: Data_UInt64 = Byte_Tool.Get_UInt64(data, index, count); break;

                case emHSMS_Type.Float32: Data_Float32 = Byte_Tool.Get_Float(data, index, count); break;
                case emHSMS_Type.Float64: Data_Float64 = Byte_Tool.Get_Double(data, index, count); break;

                case emHSMS_Type.Bool:
                    if (data[index] != 0x00) Data_Bool = true;
                    else Data_Bool = false;
                    break;

                default: break;
            }
            index = index + count;
            Fix_Count = true;
            return true;
        }
    }
    //---------------------------------------------------------------------------
    public class TSxFx_Node
    {
        public string            Name;
        public string            Note;
        public TSxFx_Node_Data   Data = new TSxFx_Node_Data();
        public TSxFx_Node[]      SubNode = new TSxFx_Node[0];
 
        public int SubNode_Count
        {
            get
            {
                return SubNode.Length;
            }
            set
            {
                int old_count;

                old_count = SubNode.Length;
                Array.Resize(ref SubNode, value);
                for (int i = old_count; i < value; i++)
                    SubNode[i] = new TSxFx_Node();
            }
        }
        private void Break_Name_List(string name_list, ref string name, ref string sub_name_list)
        {
            int pos;

            pos = name_list.IndexOf("/");
            if (pos >= 0)
            {
                name = name_list.Substring(0, pos);
                sub_name_list = name_list.Substring(pos + 1);
            }
            else
            {
                name = name_list;
                sub_name_list = "";
            }
        }
        private void Break_Str(string in_s, out string type_str, out string count_str, out string name_str, out string data_str, out string note_str)
        {
            string in_str;
            int pos, pos1, pos2;

            in_str = in_s;
            type_str = "";
            count_str = "";
            name_str = "";
            data_str = "";
            note_str = "";

            // get type
            pos = in_str.IndexOf("[");
            if (pos >= 0)
            {
                type_str = in_str.Substring(0, pos);
                type_str = type_str.TrimStart().TrimEnd();
                in_str = in_str.Substring(pos);
            }

            // get count
            pos1 = in_str.IndexOf("[");
            pos2 = in_str.IndexOf("]");
            if (pos1 >= 0 && pos2 >= 0 && pos2 > pos1)
            {
                count_str = in_str.Substring(pos1 + 1, pos2 - pos1 - 1);
                in_str = in_str.Substring(pos2 + 1);
            }

            // get name
            pos1 = in_str.IndexOf("<");
            pos2 = in_str.IndexOf(">");
            if (pos1 >= 0 && pos2 >= 0 && pos2 > pos1)
            {
                name_str = in_str.Substring(pos1 + 1, pos2 - pos1 - 1);
                in_str = in_str.Substring(pos2 + 1);
            }

            // get note
            pos = in_str.IndexOf(";");
            if (pos >= 0)
            {
                note_str = in_str.Substring(pos + 1);
                in_str = in_str.Substring(0, pos - 1);
            }

            // get data
            data_str = in_str;
        }
        public int Get_Data_Count()
        {
            int result = 0;

            if (Data.Type == emHSMS_Type.List) result = SubNode.Length;
            else result = Data.Get_Count();
            return result;
        }




        public TSxFx_Node()
        {
            Init();
        }
        public void Init()
        {
            Name = "";
            Data.Type = emHSMS_Type.List;
            SubNode_Count = 0;
            Data.Fix_Count = false;
            Data.Data_Max_Count = 0;
        }
        public void Free()
        {
            Init();
        }
        public void Copy(TSxFx_Node sor, TSxFx_Node dis)
        {
            dis.Name = sor.Name;
            dis.Note = sor.Note;
            dis.Data = sor.Data.Copy();
            dis.SubNode_Count = sor.SubNode_Count;
            for (int i = 0; i < sor.SubNode.Length; i++)
            {
                dis.SubNode[i].Set(sor.SubNode[i]);
            }
        }
        public void Copy(TSxFx_Node dis)
        {
            Copy(this, dis);
        }
        public TSxFx_Node Copy()
        {
            TSxFx_Node result = new TSxFx_Node();
            Copy(this, result);
            return result;
        }
        public void Set(TSxFx_Node sor)
        {
            Copy(sor, this);
        }

        public TSxFx_Node Get_Node(string name_list)
        {
            TSxFx_Node result = null;
            string name = "", sub_name_list = "";

            Break_Name_List(name_list, ref name, ref sub_name_list);
            if (Name == name)
            {
                if (sub_name_list == "")
                    result = this;
                else
                {
                    for (int i = 0; i < SubNode.Length; i++ )
                    {
                        result = SubNode[i].Get_Node(sub_name_list);
                        if (result != null) break;
                    }
                }
            }
            return result;
       }
        public bool Same(TSxFx_Node node)
        {
            //判定Type是否相等
            if (Data.Type != node.Data.Type) return false;
            if (Data.Type != emHSMS_Type.List)
            {
                //判定 Count 是否相等
                if (Data.Fix_Count && node.Data.Fix_Count &&
                    Data.Data_Max_Count != node.Data.Data_Max_Count) return false;
            }
            else
            {
                if (Data.Fix_Count && node.Data.Fix_Count)
                {
                    //判定 Count 是否相等
                    if (SubNode.Length != node.SubNode.Length) return false;

                    for (int i = 0; i < SubNode.Length; i++)
                        if (!SubNode[i].Same(node.SubNode[i])) return false;
                }
                else
                {
                    if (SubNode.Length > 0)
                        if (!SubNode[0].Same(node.SubNode[0])) return false;
                }
            }
            return true;
        }
        public bool Copy_Data(TSxFx_Node node, bool copy_name, bool copy_note, bool copy_value)
        {
            if (!Same(node)) return false;

            if (copy_name) Name = node.Name;
            if (copy_note) Note = node.Note;
            if (copy_value) Data = node.Data.Copy();
            if (Data.Type == emHSMS_Type.List)
            {
                for (int i = 0; i < SubNode.Length; i++)
                    SubNode[i].Copy_Data(node.SubNode[i], copy_name, copy_note, copy_value);
            }
            return true;
        }
        public bool Add_SubNode(TSxFx_Node node)
        {
            return Append_SubNode(SubNode.Length, node);
        }
        public bool Append_SubNode(int index, TSxFx_Node node)
        {
            int no;

            if (Data.Type == emHSMS_Type.List)
            {
                no = SubNode.Length;
                SubNode_Count = SubNode_Count + 1;
                SubNode[no].Set(node);
                SubNode_Move(no, index);
                return true;
            };

            return false;
        }
        public bool Delete_SubNode(int index)
        {
            //TSxFx_Node* new_item;
            //
            //if (index < FSubNode_Count && FSubNode_Count > 0)
            //{
            //    new_item = SubNode[index];
            //    for (int i = index; i < FSubNode_Count - 1; i++)
            //        SubNode[i] = SubNode[i + 1];
            //
            //    SubNode[FSubNode_Count - 1] = new_item;
            //    new_item->Free();
            //    FSubNode_Count--;
            //    return true;
            //};
            return false;
        }
        public void SubNode_MoveUp(int index)
        {
            SubNode_Move(index, index-1);
        }
        public void SubNode_MoveDn(int index)
        {
            SubNode_Move(index, index + 1);
        }
        public void SubNode_Move(int src, int dest)
        {
            TSxFx_Node tmp;

            if (src >= 0 && dest >= 0 && dest < SubNode.Length && src < SubNode.Length && dest != src)
            {
                tmp = SubNode[dest];
                SubNode[src] = SubNode[dest];
                SubNode[dest] = tmp;
            }
        }
        public bool Read_From_StringFile(string filename)
        {
            bool result;
            ArrayList str_list = new ArrayList();
            ArrayList_Tool.LoadFromFile(ref str_list, filename);
            result = Read_From_String(str_list);
            return result;
        }
        public bool Read_From_String(ArrayList str_list)
        {
            int line_no;

            Free();
            Init();
            line_no = 0;
            return Read_N_Strings(str_list, ref line_no);
        }
        public bool Read_From_Char(byte[] data, ref int index)
        {
            TSxFx_Node_Data node_data = new TSxFx_Node_Data();
            int sub_count = 0;

            if (!node_data.Set_Data_Byte(data, ref index, ref sub_count)) return false;
            Data = node_data.Copy();

            switch (Data.Type)
            {
                case emHSMS_Type.List:
                    for (int i = 0; i < sub_count; i++)
                    {
                        TSxFx_Node node = new TSxFx_Node();
                        if (!node.Read_From_Char(data, ref index)) return false;
                        Add_SubNode(node);
                    }
                    break;
            }
            return true;
        }
        public bool Read_N_Strings(ArrayList str_list, ref int index)
        {
            bool result = false;
            int count = 0;
            char[] chs;
            string tmp_str;
            string tmp, type_str, count_str, name_str, data_str, note_str;

            tmp = "";
            do
            {
                if (index < str_list.Count)
                {
                    tmp_str = str_list[index].ToString().TrimStart();
                    if (tmp_str != "")
                    {
                        chs = tmp_str.ToCharArray();
                        if (chs[0] != '@') tmp = tmp_str;
                    }
                }
                index++;
            }
            while (tmp == "" && index < str_list.Count);

            if (tmp != "")
            {
                Break_Str(tmp, out type_str, out count_str, out name_str, out data_str, out note_str);
                if (true)
                {
                    Data.Set_Type_Str(type_str);
                    Name = name_str;

                    if (count_str.ToCharArray()[0] == '?')
                    {
                        Data.Fix_Count = false;
                        count_str = count_str.Substring(1, count_str.Length - 1);
                    }
                    else Data.Fix_Count = true;


                    count = Convert.ToInt32(count_str);
                    Data.Data_Count = count;
                    Data.Set_Data_String(data_str);
                    Note =  note_str;
                    result = true;

                    switch (Data.Type)
                    {
                        case emHSMS_Type.List:
                            for (int i = 0; i < count; i++)
                            {
                                TSxFx_Node node = new TSxFx_Node();
                                if (!node.Read_N_Strings(str_list, ref index)) return false;
                                Add_SubNode(node);
                                result = true;
                            }
                            break;
                    }
                }
            }
            return result;
        }
        public bool Write_To_StringFile(string filename, bool w_name, bool w_note)
        {
            ArrayList str_list = new ArrayList();

            Write_To_String(str_list, w_name, w_note);
            ArrayList_Tool.SaveToFile(str_list, filename);
            return true;
        }
        public bool Write_To_String(ArrayList str_list, bool w_name, bool w_note)
        {
            int line_no = 0;
 
            Write_N_Strings(ref str_list, line_no, w_name, w_note);
            return true;
        }
        public bool Write_To_Char(byte[] msg, ref int index)
        {
            int count, total;
            byte count_byte;


            total = msg.Length;
            count = Get_Data_Count();
            if (count < 0xff) count_byte = 1;
            else if (count < 0xffff) count_byte = 2;
            else count_byte = 3;
            if ((index + 1 + count_byte) > msg.Length) return false;
            msg[index] = (byte)(Data.Get_Type_Code() + count_byte);
            index = index + 1;

            Byte_Tool.Set_Int(msg, index, count_byte, count);
            index = index + count_byte;
            if ((index + count) > total) return false;
            switch (Data.Type)
            {
                case emHSMS_Type.List:
                    for (int i = 0; i < SubNode_Count; i++)
                        if (!SubNode[i].Write_To_Char(msg, ref index))
                            return false;
                    break;

                case emHSMS_Type.ASCII:
                case emHSMS_Type.JIS_8:
                case emHSMS_Type.WChar:
                    Array.Copy(Data.Data, 0, msg, index, count);
                    index = index + count;
                    break;

                case emHSMS_Type.Bin:
                    Array.Copy(Data.Data, 0, msg, index, count);
                    index = index + count;
                    break;

                case emHSMS_Type.Int8:
                case emHSMS_Type.Int16:
                case emHSMS_Type.Int32:
                case emHSMS_Type.Int64:
                    Byte_Tool.Set_Int(msg, index, count, Data.Data_Int64);
                    index = index + count;
                    break;

                case emHSMS_Type.UInt8:
                case emHSMS_Type.UInt16:
                case emHSMS_Type.UInt32:
                case emHSMS_Type.UInt64:
                    Byte_Tool.Set_UInt(msg, index, count, Data.Data_UInt64);
                    index = index + count;
                    break;

                case emHSMS_Type.Float32:
                    Byte_Tool.Set_Double(msg, index, count, Data.Data_Float64);
                    index = index + count;
                    break;

                case emHSMS_Type.Float64:
                    Byte_Tool.Set_Double(msg, index, count, Data.Data_Float64);
                    index = index + count;
                    break;

                case emHSMS_Type.Bool:
                    if (Data.Data_Bool) msg[index] = 0xFF;
                    else msg[index] = 0x00;
                    index = index + count;
                    break;
            }
            return true;
        }
        public string Get_Node_String(int level, bool w_name, bool w_note)
        {
            string result = "";
            int count;
            int len;
            string tmp, space_str = "";
            string type_str = "", count_str = "", name_str = "", data_str = "", note_str = "";

            space_str = String_Tool.StringOfChar(' ', level * 2);
            type_str = Data.Get_Type_Str();
            count = Get_Data_Count();
            if (Data.Fix_Count) count_str = "[" + count.ToString() + "]";
            else count_str = "[?" + count.ToString() + "]";

            if (Name != "" && w_name) name_str = "<" + Name + ">";
            else name_str = "";

            data_str = Data.Get_Data_String();
            if (Data.Type == emHSMS_Type.ASCII)
                data_str = "\"" + data_str + "\"";

            tmp = space_str + type_str + count_str + name_str + data_str;
            if (Note != "" && w_note)
            {
                len = (int)(tmp.Length / 40 + 1) * 40;
                note_str = String_Tool.StringOfChar(' ', len - tmp.Length) + ";" + Note;
            }
            else note_str = "";
            result = tmp + note_str;
            return result;
        }
        public void Write_N_Strings(ref ArrayList str_list, int level, bool w_name, bool w_note)
        {
            str_list.Add(Get_Node_String(level, w_name, w_note));

            switch (Data.Type)
            {
                case emHSMS_Type.List:
                    for (int i = 0; i < SubNode.Length; i++)
                        SubNode[i].Write_N_Strings(ref str_list, level + 1, w_name, w_note);
                    break;
            }
        }
    }
    //---------------------------------------------------------------------------
    public class TSxFx
    {
        public string            SF_Note;
        public string            Name;
        public int               Device,     
                                 Stream,
                                 Function,
                                 System_No;
        public bool              W_Bit;
        public bool              R_Bit; 
        public TSxFx_Node        Root_Node = new TSxFx_Node();
        public bool              Empty;

        public string SF_Name
        {
            get
            {
                string result;

                result = string.Format("S{0:d3}F{1:d3}", Stream, Function);
                return result;
            }
        }
        public TSxFx()
        {
            Init();
        }
        public void Init()
        {
            SF_Note = "";
            Name = "";
            Device = 1;
            Stream = 0;
            Function = 0;
            System_No = 0;
            W_Bit = false;
            R_Bit = false;
            Root_Node.Init();
            Empty = true;
        }
        public void Copy(TSxFx sor, TSxFx dis)
        {
            dis.SF_Note = sor.SF_Note;
            dis.Name = sor.Name;
            dis.Device = sor.Device;
            dis.Stream = sor.Stream;
            dis.Function = sor.Function;
            dis.System_No = sor.System_No;
            dis.R_Bit = sor.R_Bit;
            dis.W_Bit = sor.W_Bit;
            dis.Root_Node.Set(sor.Root_Node);
            dis.Empty = sor.Empty;
        }
        public void Copy(TSxFx dis)
        {
            Copy(this, dis);
        }
        public TSxFx Copy()
        {
            TSxFx result = new TSxFx();
            Copy(this, result);
            return result;
        }
        public void Set(TSxFx sor)
        {
            Copy(sor, this);
        }

        public bool Same(TSxFx in_sxfx)
        {
            if (!Root_Node.Same(in_sxfx.Root_Node)) return false;
            return true;
        }
        public bool Read_From_StringFile(string filename)
        {
            bool result = true;
            ArrayList str_list = new ArrayList();

            ArrayList_Tool.LoadFromFile(ref str_list, filename);
            result = Read_From_String(str_list);
            return result;
        }
        public bool Read_From_String(ArrayList str_list)
        {
            bool result = true;
            string tmp, tmp_str;
            int byte_no;
            int pos_s, pos_f, pos_n;

            tmp = "";
            byte_no = 0;
            Init();
            do
            {
                if (byte_no < str_list.Count)
                {
                    tmp = str_list[byte_no].ToString().TrimStart();
                    if (tmp.ToCharArray()[0] != '@') break;
                    else byte_no++;

                    pos_s = tmp.IndexOf("S");
                    pos_f = tmp.IndexOf("F");
                    pos_n = tmp.IndexOf(";");
                    if (pos_s > 0 && pos_f > 0 && pos_f > pos_s)
                    {
                        tmp_str = tmp.Substring(pos_s + 1, pos_f - pos_s - 1);
                        Stream = Convert.ToInt32(tmp_str);
                        tmp_str = tmp.Substring(pos_f + 1, pos_n - pos_f - 1);
                        Function = Convert.ToInt32(tmp_str);
                        SF_Note = tmp.Substring(pos_n + 1);
                    }
                }
            }
            while (tmp == "" && byte_no < str_list.Count);

            result = Root_Node.Read_N_Strings(str_list, ref byte_no);
            Empty = !result;
            return result;
        }
        public bool Read_From_Message(THSMS_Message msg)
        {
            bool result = true;
            int byte_no;
            byte[] body;
            THSMS_Header header = new THSMS_Header();
            
            Init();
            header = msg.Get_Header();
            Device = header.Device_ID;
            Stream = header.Stream_ID;
            Function = header.Function_ID;
            System_No = header.System_No;
            R_Bit = header.R_Bit;
            W_Bit = header.W_Bit;
            byte_no = 0;
            body = msg.Get_Body();
            if (body.Length > 0)
            {
                result = Root_Node.Read_From_Char(body, ref byte_no);
                Empty = !result;
            }
            else
            {
                Empty = true;
                result = true;
            }
            return result;
        }
        public bool Read_From_Char(byte[] data, int size)
        {
            bool result = false;
            THSMS_Message msg = new THSMS_Message();

            if (msg.Set_Data(data, size))
            {
                result = Read_From_Message(msg);
            }
            return result;

        }
        public bool Write_To_StringFile(string filename, bool w_name, bool w_note)
        {
            ArrayList str_list = new ArrayList();

            Write_To_String(ref str_list, w_name, w_note);
            ArrayList_Tool.SaveToFile(str_list, filename);
            return true;
        }
        public bool Write_To_String(ref ArrayList str_list, bool w_name, bool w_note)
        {
            string tmp;
            
            tmp = "@" + SF_Name;
            if (SF_Note != "") tmp += ";" + SF_Note;
            str_list.Add(tmp);
            if (!Empty) Root_Node.Write_N_Strings(ref str_list, 0, w_name, w_note);
            return true;
        }
        public bool Write_To_Message(ref THSMS_Message msg)
        {
            bool result = false;
            int byte_no;
            byte[] tmp_data = new byte[10000];
            THSMS_Header header = new THSMS_Header();

            byte_no = 14;
            if (!Empty)
                result = Root_Node.Write_To_Char(tmp_data, ref byte_no);

            Byte_Tool.Set_Int(tmp_data, 0, 4, byte_no - 4);
            if (msg.Set_Data(tmp_data, byte_no))
            {
                header = msg.Get_Header();
                header.Device_ID = Device;
                header.Stream_ID = Stream;
                header.Function_ID = Function;
                header.System_No = System_No;
                header.Block_No = 0;
                header.R_Bit = R_Bit;
                header.W_Bit = W_Bit;
                header.E_Bit = true;
                msg.Set_Header(header);
                result = true;
            }
            return result;
        }
        private void Add_Node(System.Windows.Forms.TreeNode tree_node, TSxFx_Node sf_node)
        {
            string tmp_str = "";
            System.Windows.Forms.TreeNode tree_sub_node;

            switch (sf_node.Data.Type)
            {
                case emHSMS_Type.List:
                    tmp_str = string.Format("{0:s}[{1:d}]<{2:s}>{3:s};{4:s}",
                                        sf_node.Data.Get_Type_Str(), sf_node.Get_Data_Count(),
                                        sf_node.Name, sf_node.Data.Get_Data_String(), sf_node.Note);
                    break;
                case emHSMS_Type.ASCII:
                case emHSMS_Type.JIS_8:
                case emHSMS_Type.WChar:
                    tmp_str = string.Format("{0:s}[{1:d}]<{2:s}>\"{3:s}\";{4:s}",
                                        sf_node.Data.Get_Type_Str(), sf_node.Get_Data_Count(),
                                        sf_node.Name, sf_node.Data.Get_Data_String(), sf_node.Note);
                    break;

                case emHSMS_Type.Bool:
                case emHSMS_Type.Bin:
                case emHSMS_Type.Int8:
                case emHSMS_Type.Int16:
                case emHSMS_Type.Int32:
                case emHSMS_Type.Int64:
                case emHSMS_Type.UInt8:
                case emHSMS_Type.UInt16:
                case emHSMS_Type.UInt32:
                case emHSMS_Type.UInt64:
                    tmp_str = string.Format("{0:s}[{1:d}]<{2:s}>{3:s};{4:s}",
                                        sf_node.Data.Get_Type_Str(), sf_node.Get_Data_Count(),
                                        sf_node.Name, sf_node.Data.Get_Data_String(), sf_node.Note);
                    break;

                case emHSMS_Type.Float32:
                case emHSMS_Type.Float64:
                    tmp_str = string.Format("{0:s}[{1:d}]<{2:s}>{3:s};{4:s}",
                                        sf_node.Data.Get_Type_Str(), sf_node.Get_Data_Count(),
                                        sf_node.Name, sf_node.Data.Get_Data_String(), sf_node.Note);
                    break;
            }
            tree_sub_node = tree_node.Nodes.Add(tmp_str);
            for (int i = 0; i < sf_node.SubNode.Length; i++ )
            {
                Add_Node(tree_sub_node, sf_node.SubNode[i]);
            }
        }
        public void Get_Tree(System.Windows.Forms.TreeView tree)
        {
            System.Windows.Forms.TreeNode tree_node;

            tree.Nodes.Clear();
            tree_node = tree.Nodes.Add("Root");
            if (!Empty) Add_Node(tree_node, Root_Node);      
        }
    }
    //---------------------------------------------------------------------------
    public class TSECS_Param
    {
        public int                 T3,
                                   T5,
                                   T6,
                                   T7,
                                   T8,
                                   T9;
        public emHSMS_Rule_Mode    Rule_Mode;
        public string              Local_IP,
                                   Remote_IP;
        public int                 Local_Port,
                                   Remote_Port;    
        public int                 Device;

        public TSECS_Param()
        {
            Rule_Mode = emHSMS_Rule_Mode.Passive_Server;
            T3 = 45 * 1000;
            T5 = 15 * 1000;
            T6 = 30 * 1000;
            T7 = 30 * 1000;
            T8 = 10 * 1000;
            T9 = 60 * 1000;
        }
        public TSECS_Param Copy()
        {
            TSECS_Param result = new TSECS_Param();
            result.T3 = T3;
            result.T5 = T5;
            result.T6 = T6;
            result.T7 = T7;
            result.T8 = T8;
            result.T9 = T9;
            result.Rule_Mode = Rule_Mode;
            result.Local_IP = Local_IP;
            result.Remote_IP = Remote_IP;
            result.Local_Port = Local_Port;
            result.Remote_Port = Remote_Port;
            result.Device = Device;
            return result;
        }
    }
    //---------------------------------------------------------------------------
    public class TSECS_Log_Item
    {
        public byte[] Data;
        public TSxFx SxFx = new TSxFx();
        public bool Send;
        public bool Error;
        public string Message;
        public System.DateTime Time = new DateTime();

        public void Set_Data(byte[] data, int len, bool send, bool error, string msg_str)
        {
            Array.Resize(ref Data, len);
            Array.Copy(data, 0, Data, 0, len);
            Send = send;
            Error = error;
            Message = msg_str;
            Time = System.DateTime.Now;
        }
    }
    public class TSECS_Log
    {
        public int Count;
        public bool Change_Flag;
        public TSECS_Log_Item[] Item = new TSECS_Log_Item[0];

        public void Add(byte[] data, int len, bool send, bool error, string msg_str)
        {
            int no;
            no = Item.Length;
            Array.Resize(ref Item, no + 1);
            Item[no] = new TSECS_Log_Item();
            Item[no].Set_Data(data, len, send, error, msg_str);
        }
    }
    //---------------------------------------------------------------------------
    public class TSECS
    {
        private System.Timers.Timer  T3 = new System.Timers.Timer();                  //T3 -> 等待回應 SxFx TimeOut
        private System.Timers.Timer  T5 = new System.Timers.Timer();                  //T5 -> TCP/IP 斷線重新連線時間,Client用
        private System.Timers.Timer  T6 = new System.Timers.Timer();                  //T6
        private System.Timers.Timer  T7 = new System.Timers.Timer();                  //T7 -> 發送 Select Req 回應Timeout 重新發送
        private System.Timers.Timer  T8 = new System.Timers.Timer();                  //T8 -> 發送大筆資料等待Timeout 重新發送
        private System.Timers.Timer  T9 = new System.Timers.Timer();                  //T9
        private System.Timers.Timer  Timer_Link_Req = new System.Timers.Timer();      //間隔發送 Link Req

        public TJJS_CLientSockect    ClientSocket = new TJJS_CLientSockect();
        public TJJS_ServerSockect    ServerSocket = new TJJS_ServerSockect();
        public TJJS_Socket           Connect_Socket = null;    
      
        public TSxFx[]               Database = new TSxFx[0];
        public TSECS_Param           Param = new TSECS_Param();
        public bool                  Select_Flag,
                                     LinkTest_Flag,
                                     Remote_Flag;
        public  Int32                In_System_Bytes,
                                     Out_System_Bytes;          
        public TLog                  Log = new TLog();
        public TSECS_Log             SECS_Log = new TSECS_Log();
        public bool                  Log_SECS,
                                     Log_SECS_Name,
                                     Log_SECS_Note,
                                     Log_HSMS,
                                     Log_Busy;
        public byte[]                In_Buffer = new byte[1000000];
        public int                   In_Len = 0;

        public evSECS_SxFx_Event     On_Before_Send_SxFx = null;
        public evSECS_SxFx_Event     On_Affter_Recive_SxFx = null;

        private int Database_Count
        {
            get
            {
                return Database.Length;
            }
            set
            {
                int old_count;

                old_count = Database.Length;
                Array.Resize(ref Database, value);
                for(int i=old_count; i<value; i++)
                {
                    Database[i] = new TSxFx();
                }
            }
        }
        private void Close_Connect_Flag()
        {
            Connect_Socket = null;
            Select_Flag = false;
            LinkTest_Flag = false;
            Remote_Flag = false;
        }                
        private void ClientSocketConnect(TJJS_Socket s_socket)
        {
            Log_Add("Client Socket Connect.");
            Connect_Socket = s_socket;
            Send_Control_Message(emControl_Message.Select_Req, ++Out_System_Bytes);
            if (Param.Rule_Mode == emHSMS_Rule_Mode.Active_Client) Timer_Link_Req.Enabled = true;
        }
        private void ClientSocketDisconnect(TJJS_Socket s_socket)
        {
            Log_Add("Client Socket Disconnect.");
            Close_Connect_Flag();
            Timer_Link_Req.Enabled = false;
        }
        private void ClientSocketError(TJJS_Socket s_socket, SocketException e)
        {
            Log_Add("Client Connect Error.");
            //ErrorCode = 0;
            Close_Connect_Flag();
        }
        private void ServerSocketClientConnect(TJJS_Socket s_socket)
        {
            Log_Add("Server Socket Client Connect.");
            Connect_Socket = s_socket;
        }
        private void ServerSocketClientDisconnect(TJJS_Socket s_socket)
        {
            Log_Add("Server Socket Client Disconnect.");
            Connect_Socket = null;
            Close_Connect_Flag();
        }
        private void ServerSocketClientError(TJJS_Socket s_socket, SocketException e)
        {
            Log_Add("Server Socket Client Error.");
            //ErrorCode = 0;
            Close_Connect_Flag();
        }
        private void Recive_Data(TJJS_Socket s_socket)
        {
            byte[] buffer;

            buffer = s_socket.Recive_Byte(10000);
            Log_Add("[Recive Data]." + buffer.Length.ToString());
            if (buffer.Length + In_Len >= 1000000)
            {
                Log_Add("Over Recive Buffer Size.");
                In_Len = 0;
            }
            else
            {
                Array.Copy(buffer, 0, In_Buffer, In_Len, buffer.Length);
                In_Len = In_Len + buffer.Length;
            }
        }
        private void Socket_Read(TJJS_Socket s_socket)
        {
            int block_size;
            bool ok_data;
    
            Recive_Data(s_socket);
            while(In_Len >= 14)  //確定資料夠長
            {
                block_size = (int)Byte_Tool.Get_Int64(In_Buffer, 0, 4) + 4;
                if (block_size <= In_Len)
                {
                    ok_data = Check_Control_Message();
                  
                    if (!ok_data) 
                        ok_data = Check_SxFx(block_size);
                    
                    if (!ok_data)
                    {
                        // Error Data
                        Log_Busy = true;
                        Log.Add(String_Tool.StringOfChar('-', 80));
                        Log.Add("[Recv.]Error Data.");
                        if (Log_HSMS) Log_Bin_Data(In_Buffer, block_size);
                        Log_Busy = false;

                        Delete_Buffer_Data(block_size);
                    }
                }
                else
                {
                    // Error Block Size
                    while (Log_Busy) { };
                    Log_Busy = true;
                    Log.Add(String_Tool.StringOfChar('-', 80));
                    Log.Add("[Recv.]Error Block Size.");
                    if (Log_HSMS) Log_Bin_Data(In_Buffer, In_Len);
                    Log_Busy = false;

                    Delete_Buffer_Data(In_Len);
                }
            }
        }
        private bool Check_Control_Message()
        {
            bool result = false;
            emControl_Message ctr_msg = emControl_Message.Select_Req;
            byte[] tmp_data = new byte[14];

            if (Is_Control_Message(In_Buffer, ref ctr_msg))
            {
                Array.Copy(In_Buffer, 0, tmp_data, 0, 14);
                Recive_Control_Message(ctr_msg, tmp_data);
                Delete_Buffer_Data(14);
                result = true;
            }
            return result;
        }
        private bool Check_SxFx(int block_size)
        {
            bool result = false;
            TSxFx sf = new TSxFx();

            if (sf.Read_From_Char(In_Buffer, block_size))
            {
                Copy_DataBase(ref sf);
                Recive_SxFx(sf, In_Buffer, block_size);
                Delete_Buffer_Data(block_size);
                result = true;
            }
            return result;

        }
        private void On_T3_TimeOut(object sender, EventArgs e)
        {
        }
        private void On_T5_TimeOut(object sender, EventArgs e)
        {
            T5.Enabled = false;
            Active = true;
        }
        private void On_T6_TimeOut(object sender, EventArgs e)
        {
             //  Timer_Not_Select->Enabled = false;
             //  Send_Select_Req(++Out_System_Bytes);
             //  Timer_Not_Select->Enabled = true;
        }
        private void On_T7_TimeOut(object sender, EventArgs e)
        {
        }
        private void On_T8_TimeOut(object sender, EventArgs e)
        {
        }
        private void On_T9_TimeOut(object sender, EventArgs e)
        {
        }
        private void On_Timer_Link_Req_TimeOut(object sender, EventArgs e)
        {
            Timer_Link_Req.Enabled = false;
            Send_Control_Message(emControl_Message.Select_Req, ++Out_System_Bytes);
            if (Param.Rule_Mode == emHSMS_Rule_Mode.Active_Client) Timer_Link_Req.Enabled = true;
        }


        private void Log_Add(string str)
        {
            while (Log_Busy) { };
            Log_Busy = true;
            Log.Add(str);
            Log_Busy = false;
        }
        private void Log_Bin_Data(byte[] data, int len)
        {
            ArrayList tmp_list = new ArrayList();
            string tmp = "";
            int no = 0;

            do
            {
                tmp += String_Tool.IntToHexStr(data[no], 2) + " ";
                if (no == 3 || no == 13 || (no - 13) % 30 == 0)
                {
                    tmp_list.Add(tmp);
                    tmp = "";
                }
                no++;
            } while (no < len);
            if (tmp != "") tmp_list.Add(tmp);

            for (int i = 0; i < tmp_list.Count; i++)
            {
                Log.Add(tmp_list[i].ToString());
            }
        }
        private void Log_SxFx_Data(TSxFx sf)
        {
            ArrayList tmp_list = new ArrayList();

            sf.Write_To_String(ref tmp_list, Log_SECS_Name, Log_SECS_Note);
            for (int i = 0; i < tmp_list.Count; i++)
            {
                Log.Add(tmp_list[i].ToString());
            }
        }
        private void Delete_Buffer_Data(int size)
        {
            int new_size;

            new_size = In_Len - size;
            if (new_size >= 0)
            {
                Array.Copy(In_Buffer, size, In_Buffer, 0, new_size);
                In_Len = new_size;
            }
        }
        private byte[] Get_Control_Message(emControl_Message type, int system_no)
        {
            byte[] result = new byte[14];

            Byte_Tool.Set_Int(result, 0, 4, 10);
            Byte_Tool.Set_Int(result, 4, 2, 0xffff);
            switch (type)
            {
                case emControl_Message.Select_Req:   Byte_Tool.Set_Int(result, 6, 4, 0x01); break;
                case emControl_Message.Select_Rsp:   Byte_Tool.Set_Int(result, 6, 4, 0x02); break;
                case emControl_Message.LinkTest_Req: Byte_Tool.Set_Int(result, 6, 4, 0x05); break;
                case emControl_Message.LinkTest_Rsp: Byte_Tool.Set_Int(result, 6, 4, 0x06); break;
                case emControl_Message.Separate_Req: Byte_Tool.Set_Int(result, 6, 4, 0x09); break;
            }

            Byte_Tool.Set_Int(result, 10, 4, system_no);
            return result;
        }
        private string Get_Control_Message_Str(emControl_Message type)
        {
            string result = "";

            switch (type)
            {
                case emControl_Message.Select_Req:   result = "Select Request";      break;
                case emControl_Message.Select_Rsp:   result = "Select Responses";    break;
                case emControl_Message.LinkTest_Req: result = "Link Test Request";   break;
                case emControl_Message.LinkTest_Rsp: result = "Link Test Responses"; break;
                case emControl_Message.Separate_Req: result = "Separate Request";    break;
            }
            return result;
        }
        private bool Is_Control_Message(byte[] data, ref emControl_Message type)
        {
            bool result = false;
            UInt32 kind_no;

            if (In_Len < 14) return false;                                    //data size error
            if (Byte_Tool.Get_UInt32(data, 0, 4) != 0x0a) return false;       //block size error
            if (Byte_Tool.Get_UInt16(data, 4, 2) != 0xffff) return false;    //key error
            kind_no = Byte_Tool.Get_UInt32(data, 6, 4);
            switch(kind_no)
            {
                case 0x01: type = emControl_Message.Select_Req;   result = true; break;
                case 0x02: type = emControl_Message.Select_Rsp;   result = true; break;
                case 0x05: type = emControl_Message.LinkTest_Req; result = true; break;
                case 0x06: type = emControl_Message.LinkTest_Rsp; result = true; break;
                case 0x09: type = emControl_Message.Separate_Req; result = true; break;
            }
            return result;
        }



        public bool Active
        {
            get
            {
                switch (Param.Rule_Mode)
                {
                    case emHSMS_Rule_Mode.Active_Client:
                        if (ClientSocket.Active && Select_Flag)
                            return true;
                        break;
                    case emHSMS_Rule_Mode.Passive_Server:
                        if (ServerSocket.Active && Select_Flag)
                            return true;
                        break;
                }
                return false;
            }
            set
            {
                if (value)
                {
                    T3.Interval = Param.T3 * 1000;
                    T5.Interval = Param.T5 * 1000;
                    T7.Interval = Param.T7 * 1000;
                    T8.Interval = Param.T8 * 1000;
                    T9.Interval = Param.T9 * 1000;
                    Timer_Link_Req.Interval = Param.T9 * 1000;
                    T3.Enabled = true;
                    T5.Enabled = true;
                    T7.Enabled = true;
                    T8.Enabled = true;
                    T9.Enabled = true;
                    
                    switch (Param.Rule_Mode)
                    {
                        case emHSMS_Rule_Mode.Active_Client:
                            ClientSocket.Host = Param.Remote_IP;
                            ClientSocket.Port = Param.Remote_Port;
                            ClientSocket.Active = true;
                            break;

                        case emHSMS_Rule_Mode.Passive_Server:
                            ServerSocket.Port = Param.Remote_Port;
                            ServerSocket.Active = true;
                            break;
                    }
                }
                else
                {
                    Close_Connect_Flag();
                    ClientSocket.Active = false;
                    ServerSocket.Active = false;
                }

            }
        }                         
        public TSECS()
        {
            SECS_Log.Count = 0;
            Log_SECS = true;
            Log_SECS_Name = true;
            Log_SECS_Note = true;
            Log_HSMS = false;
            Log_Busy = false;

            In_Len = 0;
            In_System_Bytes = 0;
            Out_System_Bytes = 0;

            ClientSocket.OnConnect = ClientSocketConnect;
            ClientSocket.OnDisconnect = ClientSocketDisconnect;
            ClientSocket.OnError = ClientSocketError;
            ClientSocket.OnRead = Socket_Read;
            ClientSocket.Active = false;

            ServerSocket.OnClientConnect = ServerSocketClientConnect;
            ServerSocket.OnClientDisconnect = ServerSocketClientDisconnect;
            ServerSocket.OnError = ServerSocketClientError;
            ServerSocket.OnClientRead = Socket_Read;
            ServerSocket.Active = false;


            T3.Elapsed += On_T3_TimeOut;
            T5.Elapsed += On_T5_TimeOut;
            T6.Elapsed += On_T6_TimeOut;
            T7.Elapsed += On_T7_TimeOut;
            T8.Elapsed += On_T8_TimeOut;
            T9.Elapsed += On_T9_TimeOut;
            Timer_Link_Req.Elapsed += On_Timer_Link_Req_TimeOut;
            Close_Connect_Flag();
        }
        public void LoadDataBase(string database_path)
        {
            string[] files;
            string ext;
            int no = 0;

            files = System.IO.Directory.GetFiles(database_path);
            Database_Count = files.Length;
            for (int i=0; i<files.Length; i++)
            {
                ext = System.IO.Path.GetExtension(files[i]);
                if (ext == ".TXT")
                {
                    Database[no].Read_From_StringFile(files[i]);
                    Database[no].Name = System.IO.Path.GetFileName(files[i]);
                    Database[no].Device = 01;
                    Database[no].W_Bit = false;
                    no++;
                }
            }
            Database_Count = no;
        }
        public bool Get_DataBase(int s,int f,ref TSxFx out_sf)
        {
            bool result = false;
             
            for (int i=0;i<Database.Length;i++)
            {
                if (Database[i].Stream == s && Database[i].Function == f)
                {
                    out_sf = Database[i];
                    result = true;
                    break;
                }
            }
            return result;
        }
        public void Copy_DataBase(ref TSxFx sf)
        {
            TSxFx base_sf = new TSxFx();
            if (Get_DataBase(sf.Stream, sf.Function, ref base_sf))
            {
                sf.SF_Note = base_sf.SF_Note;
                sf.Root_Node.Copy_Data(base_sf.Root_Node, true, true, false);
            }
        }
        public void Send_Control_Message(emControl_Message type, int system_no)
        {
            byte[] send_data;

            send_data = Get_Control_Message(type, system_no);
            Connect_Socket.Send_Byte(send_data);

            while (Log_Busy) { };
            Log_Busy = true;
            Log.Add(String_Tool.StringOfChar('-', 80));
            Log.Add("[SEND]" + Get_Control_Message_Str(type));
            if (Log_HSMS) Log_Bin_Data(send_data, send_data.Length);
            Log_Busy = false;
        }
        public void Recive_Control_Message(emControl_Message type, byte[] data)
        {
            int system_no = 0;

            while (Log_Busy) { };
            Log_Busy = true;
            Log.Add(String_Tool.StringOfChar('-', 80));
            Log.Add("[RECV]" + Get_Control_Message_Str(type));
            if (Log_HSMS) Log_Bin_Data(data, data.Length);
            Log_Busy = false;

            system_no = Byte_Tool.Get_Int32(data, 10, 4);
            switch (type)
            {
                case emControl_Message.Select_Req:
                    Send_Control_Message(emControl_Message.Select_Rsp, system_no);
                    Select_Flag = true;
                    break;

                case emControl_Message.Select_Rsp:
                    Select_Flag = true;
                    break;

                case emControl_Message.LinkTest_Req:
                    Send_Control_Message(emControl_Message.LinkTest_Rsp, system_no);
                    LinkTest_Flag = true;
                    break;

                case emControl_Message.LinkTest_Rsp:
                    LinkTest_Flag = true;
                    break;

                case emControl_Message.Separate_Req:
                    break;
            }
        }
        public void Send_SxFx(TSxFx sf)
        {
            Send_SxFx(sf, ++Out_System_Bytes);
        }
        public void Send_SxFx(TSxFx sf, int system_no)
        {
            THSMS_Message msg = new THSMS_Message();

            if (sf != null)
            {
                TSxFx send_sf = new TSxFx();
                send_sf.Set(sf);
                Copy_DataBase(ref send_sf);
                if (On_Before_Send_SxFx != null) On_Before_Send_SxFx(send_sf);

                send_sf.Write_To_Message(ref msg);
                Connect_Socket.Send_Byte(msg.Data);

                while (Log_Busy) { };
                Log_Busy = true;
                Log.Add(String_Tool.StringOfChar('-', 80));
                Log.Add("[SEND]");
                if (Log_SECS)
                {
                    Log_SxFx_Data(sf);
                }
                if (Log_HSMS)
                {
                    Log.Add(String_Tool.StringOfChar('-', 80));
                    Log_Bin_Data(msg.Data, msg.Data.Length);
                }
                Log_Busy = false;
            }
        }
        public void Recive_SxFx(TSxFx sf, byte[] data, int len)
        {
            while (Log_Busy) { };
            Log_Busy = true;
            Log.Add(String_Tool.StringOfChar('-', 80));
            Log.Add("[RECV]");
            if (Log_SECS)
            {
                Log_SxFx_Data(sf);
            }
            if (Log_HSMS)
            {
                Log.Add(String_Tool.StringOfChar('-', 80));
                Log_Bin_Data(data, len);
            }
            Log_Busy = false;

            if (On_Affter_Recive_SxFx != null) On_Affter_Recive_SxFx(sf);

        }
        public TSxFx Get_SxFx(int s, int f)
        {
            TSxFx result = null;

            for(int i=0; i<Database.Length; i++)
            {
                if (Database[i].Stream == s && Database[i].Function == f)
                {
                    result = new TSxFx();
                    result.Set(Database[i]);
                    break;
                }
            }
            return result;
        }
        //  void                  Add_Send_Event(int s,int f,bool reply,int event_index,TSxFx *reply_sf);
        //  void                  Add_Recive_Event(int s,int f,bool reply,int event_index,TSxFx *reply_sf);
        //  void                  Add_Host_Event(int s,int f,bool reply,int event_index,TSxFx *reply_sf);
    }
}
