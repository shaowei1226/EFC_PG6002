using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace EFC.Tool
{
    public enum emJJS_DataType { emNone = 0, emJJS_DtBin = 2, emJJS_DtEight = 8, emJJS_dtTen = 10, emJJS_dtHex = 16 };
    //-----------------------------------------------------------------------------------------------------
    //基礎物件型別
    //-----------------------------------------------------------------------------------------------------
    abstract public class TBase_Class
    {
        abstract public TBase_Class New_Class();
        abstract public void Copy(TBase_Class sor, TBase_Class dis);
        public void Copy(TBase_Class dis)
        {
            Copy(this, dis);
        }
        public TBase_Class Copy()
        {
            TBase_Class result = New_Class();
            Copy(this, result);
            return result;
        }
        public void Set(TBase_Class sor)
        {
            Copy(sor, this);
        }
    }


    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public static class JJS_LIB
    {
        [StructLayout(LayoutKind.Sequential)]
        class Dll_Methods
        {
            private Dll_Methods()
            {
            }

            [DllImport("msvcrt.dll", EntryPoint = "memcpy", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe IntPtr dll_memcpy(void* dest, void* src, int count);
        }

        public static unsafe IntPtr memcpy(void* dest, void* src, int count)
        {
            return Dll_Methods.dll_memcpy(dest, src, count);
        }
        public static void memcpy(char[] dst, ref char[] src, int count)
        {
            int cp_count;

            if (count < dst.Length) cp_count = count;
            else cp_count = dst.Length;
            for (int i = 0; i < cp_count; i++)
            {
                dst[i] = src[i];
            }
        }
        public static UInt16 Int16_To_UInt16(Int16 iData)
        {
            UInt16 result = 0;

            int itmp = 0;
            if (iData >= 0) itmp = iData;
            else itmp = iData * -1 + 32767;

            result = Convert.ToUInt16(itmp);
            return result;
        }
        public static bool Get_Bit(int idata, int bit_no)
        {
            bool result;
            int flag;

            flag = 0x0001;
            flag = flag << bit_no;
            if ((idata & flag) == flag) result = true;
            else result = false;
            return result;
        }
        public static void Set_Bit(ref int idata, int bit_no, bool bdata)
        {
            int flag1, flag2;

            flag1 = 0x0001;
            flag1 = flag1 << bit_no;
            flag2 = flag1 ^ 0xFFFF;
            if (bdata) idata = (idata & flag2) | flag1;
            else idata = (idata & flag2);
        }
        public static IntPtr ByteToIntPtr(byte[] in_data)
        {
            IntPtr result;
            unsafe
            {
                fixed (byte* p = in_data)
                {
                    result = (IntPtr)p;
                }
            }
            return result;
        }
    }
    public static class String_Tool
    {
        public static string IntToStr_A(int value, emJJS_DataType type, uint CharNum = 0)
        {
            String Result = "";
            char[] Char_Index = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            uint Count = 0;
            int tmp, data_size;

            tmp = value;
            switch (type)
            {
                case emJJS_DataType.emJJS_DtBin: data_size = 2; break;
                case emJJS_DataType.emJJS_DtEight: data_size = 8; break;
                case emJJS_DataType.emJJS_dtTen: data_size = 10; break;
                case emJJS_DataType.emJJS_dtHex: data_size = 16; break;
                default: data_size = 10; break;
            }
            while (true)
            {
                Result = Char_Index[tmp % data_size].ToString() + Result;
                tmp = tmp / data_size;
                Count++;
                if ((CharNum == 0) && (tmp == 0))
                {
                    break;
                }
                if ((CharNum != 0) && (Count >= CharNum))
                {
                    break;
                }
            }
            return Result;
        }
        public static string IntToStr_A(uint value, emJJS_DataType type, uint CharNum = 0)
        {
            String Result = "";
            char[] Char_Index = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            uint Count = 0;
            uint tmp, data_size;

            tmp = value;
            switch (type)
            {
                case emJJS_DataType.emJJS_DtBin: data_size = 2; break;
                case emJJS_DataType.emJJS_DtEight: data_size = 8; break;
                case emJJS_DataType.emJJS_dtTen: data_size = 10; break;
                case emJJS_DataType.emJJS_dtHex: data_size = 16; break;
                default: data_size = 10; break;
            }
            while (true)
            {
                Result = Char_Index[tmp % data_size].ToString() + Result;
                tmp = tmp / data_size;
                Count++;
                if ((CharNum == 0) && (tmp == 0))
                {
                    break;
                }
                if ((CharNum != 0) && (Count >= CharNum))
                {
                    break;
                }
            }
            return Result;
        }
        public static string IntToTenStr(int value, uint CharNum = 0)
        {
            return IntToStr_A(value, emJJS_DataType.emJJS_dtTen, CharNum);
        }
        public static string IntToBinStr(int value, uint CharNum = 0)
        {
            return IntToStr_A(value, emJJS_DataType.emJJS_DtBin, CharNum);
        }
        public static string IntToEightStr(int value, uint CharNum = 0)
        {
            return IntToStr_A(value, emJJS_DataType.emJJS_DtEight, CharNum);
        }
        public static string IntToHexStr(int value, uint CharNum = 0)
        {
            return IntToStr_A(value, emJJS_DataType.emJJS_dtHex, CharNum);
        }


        private static int StrToInt_A(string str, emJJS_DataType type)
        {
            int result = 0;
            char[] Char_Index = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            bool minus_flag = false;
            bool data_flag = false;
            int data_size;
            int i, j;

            switch (type)
            {
                case emJJS_DataType.emJJS_DtBin: data_size = 2; break;
                case emJJS_DataType.emJJS_DtEight: data_size = 8; break;
                case emJJS_DataType.emJJS_dtTen: data_size = 10; break;
                case emJJS_DataType.emJJS_dtHex: data_size = 16; break;
                default: data_size = 10; break;
            }

            //開始轉換字串
            str = str.ToUpper();
            for (i = 0; i < str.Length; i++)
            {
                //判斷第一個字元是否為"負號"
                if (!data_flag && !minus_flag && str[i] == '-')
                {
                    minus_flag = true;
                    data_flag = true;
                }
                else
                {
                    //判斷當前字元是Char_Index中的哪一個
                    for (j = 0; j < data_size; j++)
                        if (str[i] == Char_Index[j]) break;

                    if (j < data_size)
                    {
                        data_flag = true;
                        result = result * data_size + j;
                    }
                    else
                    {
                        result = 0;
                        break;
                    }
                }
            }
            if (minus_flag)
            {
                result = -result;
            }
            return result;
        }
        public static int TenStrToInt(string str)
        {
            return StrToInt_A(str, emJJS_DataType.emJJS_dtTen);
        }
        public static int BinStrToInt(string str)
        {
            return StrToInt_A(str, emJJS_DataType.emJJS_DtBin);
        }
        public static int EightStrToInt(string str)
        {
            return StrToInt_A(str, emJJS_DataType.emJJS_DtEight);
        }
        public static int HexStrToInt(string str)
        {
            return StrToInt_A(str, emJJS_DataType.emJJS_dtHex);
        }

        public static void Break_String(string str, string brk_str, ref ArrayList list)
        {
            string tmp_str;
            int pos;
            bool flag = true;

            list.Clear();
            tmp_str = str.Trim();
            if (tmp_str == "") flag = false;
            while (flag)
            {
                pos = tmp_str.IndexOf(brk_str);
                if (pos >= 0)
                {
                    list.Add(tmp_str.Substring(0, pos - brk_str.Length + 1));
                    tmp_str = tmp_str.Substring(pos + brk_str.Length);
                }
                else
                {
                    list.Add(tmp_str);
                    tmp_str = "";
                    flag = false;
                }
            }
        }
        public static void Break_String(string str, string brk_str, ref string[] strings)
        {
            ArrayList list = new ArrayList();
            Break_String(str, brk_str, ref list);
            strings = ArrayList_Tool.To_Strings(list);
        }
        public static string Get_Num_Char(string str)
        {
            string result = "";
            char[] str_char;

            str_char = str.ToCharArray();
            for (int i = 0; i < str_char.Length; i++)
            {
                if (str_char[i] >= '0' && str_char[i] <= '9')
                    result = result + str_char[i];
            }
            return result;
        }
        public static string Cut_Num_Char(string str)
        {
            string result = "";
            char[] str_char;

            str_char = str.ToCharArray();
            for (int i = 0; i < str_char.Length; i++)
            {
                if (str_char[i] < '0' || str_char[i] > '9')
                    result = result + str_char[i];
            }
            return result;
        }
        public static int Get_Name_No(string name_str, string brk_str, int index)
        {
            int result = 0;
            ArrayList list = new ArrayList();

            String_Tool.Break_String(name_str, brk_str, ref list);
            if (index < list.Count)
            {
                result = Convert.ToInt32(String_Tool.Get_Num_Char(list[index].ToString())) - 1;
            }
            return result;
        }
        
        public static string StringOfChar(char ch, int count)
        {
            string result = "";

            for (int i = 0; i < count; i++)
                result = result + ch;
            return result;
        }
        public static ArrayList Get_Dir_List(string sor_dir, string find_file_name)
        {
            ArrayList result = new ArrayList();
            string file_name, path_name;

            try
            {
                List<string> dirs = new List<string>(System.IO.Directory.EnumerateDirectories(sor_dir));
                foreach (string dir in dirs)
                {
                    path_name = System.IO.Path.GetFileName(dir);
                    if (find_file_name != "")
                    {
                        file_name = dir + "\\" + find_file_name;
                        if (System.IO.File.Exists(file_name))
                            result.Add(path_name);
                    }
                    else
                        result.Add(path_name);
                }
            }
            catch
            {

            }
            return result;
        }
        public static ArrayList Get_Files_List(string sor_dir, string ext_str)
        {
            ArrayList result = new ArrayList();
            string file_name, ext_name, sor_ext_name;

            try
            {
                sor_ext_name = System.IO.Path.GetExtension(ext_str).ToUpper();
                List<string> full_filname_list = new List<string>(System.IO.Directory.EnumerateFileSystemEntries(sor_dir));
                foreach (string full_file_name in full_filname_list)
                {
                    file_name = System.IO.Path.GetFileName(full_file_name);
                    ext_name = System.IO.Path.GetExtension(full_file_name).ToUpper();
                    if (ext_name == sor_ext_name)
                        result.Add(full_file_name);
                }
            }
            catch
            {
            }
            return result;
        }


        public static string[] String_Copy(string[] in_string_list)
        {
            string[] result = new string[in_string_list.Length];

            Array.Copy(in_string_list, 0, result, 0, in_string_list.Length);
            return result;
        }
        public static bool String_Cmp(string str1, string str2,  bool flag_upper = false)
        {
            bool result = false;

            if (flag_upper)
            {
                result = (str1.ToUpper() == str2.ToUpper());
            }
            else
            {
                result = (str1 == str2);
            }
            return result;
        }
        public static string[] String_Get_Inside(string[] in_string_list, string[] base_string_list, bool flag_upper = false)
        {
            string[] result = new string[in_string_list.Length];
            int count = 0;

            for (int i = 0; i < in_string_list.Length; i++)
            {
                for (int j = 0; j < base_string_list.Length; j++)
                {
                    if (String_Cmp(in_string_list[i], base_string_list[j], flag_upper))
                    {
                        result[count] = in_string_list[i];
                        count++;
                        break;
                    }
                }
            }
            Array.Resize(ref result, count);
            return result;
        }
        public static string[] String_Get_Outside(string[] in_string_list, string[] base_string_list, bool flag_upper = false)
        {
            string[] result = new string[in_string_list.Length];
            int count = 0;
            bool flag = true;

            for (int i = 0; i < in_string_list.Length; i++)
            {
                flag = true;
                for (int j = 0; j < base_string_list.Length; j++)
                {
                    if (String_Cmp(in_string_list[i], base_string_list[j], flag_upper))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result[count] = in_string_list[i];
                    count++;
                }
            }
            Array.Resize(ref result, count);
            return result;
        }
        public static void String_Add(ref string[] in_string_list, string add_str)
        {
            int len;

            len = in_string_list.Length;
            Array.Resize(ref in_string_list, len + 1);
            in_string_list[len] = add_str;
        }
        public static void String_Del(ref string[] in_string_list, int no)
        {
            if (no >= 0 && no < in_string_list.Length)
            {
                for(int i=no; i<in_string_list.Length-1; i++)
                {
                    in_string_list[i] = in_string_list[i+1];
                }
            }
            Array.Resize(ref in_string_list, in_string_list.Length - 1);
        }
        public static void String_Del(ref string[] in_string_list, string cmp_str, bool flag_upper = false)
        {
            int no = -1;

            no = String_IndexOf(in_string_list, cmp_str, flag_upper);
            if (no >= 0) String_Del(ref in_string_list, no);
        }
        public static int String_IndexOf(string[] in_string_list, string cmp_str, bool flag_upper = false)
        {
            int result = -1;

            for (int i = 0; i < in_string_list.Length; i++)
            {
                if (String_Cmp(in_string_list[i], cmp_str, flag_upper))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
    public static class PLC_Data_Tool
    {
        public static bool Get_Bit(ushort[] data, int word_no, int bit_no)
        {
            bool result = false;
            if (word_no < data.Length && bit_no < 16)
                result = JJS_LIB.Get_Bit(data[word_no], bit_no);
            return result;
        }
        public static void Set_Bit(ushort[] data, int word_no, int bit_no, bool value)
        {
            int data_int;

            if (word_no < data.Length && bit_no < 16)
            {
                data_int = data[word_no];
                JJS_LIB.Set_Bit(ref data_int, bit_no, value);
                data[word_no] = (ushort)data_int;
            }
        }
        public static int Get_Word(ushort[] data, int word_no)
        {
            int result;

            result = (int)data[word_no];
            return result;
        }
        public static void Set_Word(ushort[] data, int word_no, int value)
        {
            data[word_no] = (ushort)value;
        }
        public static double Get_Word(ushort[] data, int word_no, int dot_num)
        {
            double result;
            result = Get_Word(data, word_no) / Math.Pow(10, dot_num);
            return result;
        }
        public static void Set_Word(ushort[] data, int word_no, int dot_num, double value)
        {
            Set_Word(data, word_no, (int) Math.Round(value * Math.Pow(10, dot_num), 0));
        }

        public static int Get_DWord(ushort[] data, int word_no)
        {
            int result = 0;
            if (word_no < data.Length)
                result = data[word_no] + (data[word_no + 1] << 16);
            return result;
        }
        public static void Set_DWord(ushort[] data, int word_no, int value)
        {
            if (word_no + 1 < data.Length)
            {
                data[word_no + 1] = (ushort)(value >> 16);
                data[word_no] = (ushort)(value & 0x0000ffff);
            }
        }
        public static double Get_DWord(ushort[] data, int word_no, int dot_num)
        {
            double result = 0.0;
            result = Get_DWord(data, word_no) / Math.Pow(10, dot_num);
            return result;
        }
        public static void Set_DWord(ushort[] data, int word_no, int dot_num, double value)
        {
            Set_DWord(data, word_no, (int) Math.Round(value * Math.Pow(10, dot_num), 0));
        }
        public static string Get_String(ushort[] data, int word_no, int len)
        {
            string result = "";
            char[] tmp_str_ch = new char[len * 2];
            byte[] us_byte;

            if (word_no + len < data.Length)
            {
                for (int i = 0; i < len; i++)
                {
                    us_byte = BitConverter.GetBytes(data[word_no + i]);
                    Array.Copy(us_byte, 0, tmp_str_ch, i * 2, 2);
                }
                for (int i = 0; i < tmp_str_ch.Length; i++) if (tmp_str_ch[i] == 0x00) tmp_str_ch[i] = ' ';

                result = new string(tmp_str_ch);
            }
            return result;
        }
        public static void Set_String(ushort[] data, int word_no, int len, string str)
        {
            char[] tmp_str_ch;
            char[] put_str_ch = new char[len * 2];
            int tmp_len;
            byte d1, d2;


            if (word_no + len < data.Length)
            {
                if (str != null && str != "")
                {
                    tmp_str_ch = str.ToCharArray();
                    tmp_len = str.Length;
                    if (tmp_len > put_str_ch.Length) tmp_len = put_str_ch.Length;

                    for (int i = 0; i < put_str_ch.Length; i++) put_str_ch[i] = ' ';
                    Array.Copy(tmp_str_ch, 0, put_str_ch, 0, tmp_len);
                    for (int i = 0; i < len; i++)
                    {
                        d1 = (byte)put_str_ch[i * 2];
                        d2 = (byte)put_str_ch[i * 2 + 1];
                        data[word_no + i] = (ushort)(d1 | (d2 << 8));
                    }
                }
            }
        }
        public static float Get_Float(ushort[] data, int word_no)
        {
            float result;
            byte[] us_byte = new byte[16];
            byte[] tmp_byte;

            if (word_no + 1 < data.Length)
            {
                for (int i = 0; i < 2; i++)
                {
                    tmp_byte = BitConverter.GetBytes(data[word_no + i]);
                    us_byte[i * 2 + 0] = tmp_byte[0];
                    us_byte[i * 2 + 1] = tmp_byte[1];
                }
            }

            result = BitConverter.ToSingle(us_byte, 0);
            return result;
        }
        public static void Set_Float(ushort[] data, int word_no, float value)
        {
            byte[] tmp_data = BitConverter.GetBytes(value);
            if (word_no + 1 < data.Length)
            {
                data[word_no] = (ushort)(tmp_data[0] | (tmp_data[1] << 8));
                data[word_no + 1] = (ushort)(tmp_data[2] | (tmp_data[3] << 8));
            }
        }
        public static double Get_Double(ushort[] data, int word_no)
        {
            double result;
            byte[] us_byte = new byte[16];
            byte[] tmp_byte;

            if (word_no + 3 < data.Length)
            {
                for (int i = 0; i < 4; i++)
                {
                    tmp_byte = BitConverter.GetBytes(data[word_no + i]);
                    us_byte[i * 2 + 0] = tmp_byte[0];
                    us_byte[i * 2 + 1] = tmp_byte[1];
                }
            }

            result = BitConverter.ToDouble(us_byte, 0);
            return result;
        }
        public static void Set_Double(ushort[] data, int word_no, double value)
        {
            byte[] tmp_data = BitConverter.GetBytes(value);
            if (word_no + 3 < data.Length)
            {
                data[word_no] = (ushort)(tmp_data[0] | (tmp_data[1] << 8));
                data[word_no + 1] = (ushort)(tmp_data[2] | (tmp_data[3] << 8));
                data[word_no + 2] = (ushort)(tmp_data[4] | (tmp_data[5] << 8));
                data[word_no + 3] = (ushort)(tmp_data[6] | (tmp_data[7] << 8));
            }
        }
    }
    public static class Byte_Tool
    {
        public static Int16 Get_Int16(byte[] data, int index, int len)
        {
            Int16 result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToInt16(tmp2, 0);
            return result;
        }
        public static Int32 Get_Int32(byte[] data, int index, int len)
        {
            Int32 result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToInt32(tmp2, 0);
            return result;
        }
        public static Int64 Get_Int64(byte[] data, int index, int len)
        {
            Int64 result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToInt64(tmp2, 0);
            return result;
        }
        public static UInt16 Get_UInt16(byte[] data, int index, int len)
        {
            UInt16 result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToUInt16(tmp2, 0);
            return result;
        }
        public static UInt32 Get_UInt32(byte[] data, int index, int len)
        {
            UInt32 result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToUInt32(tmp2, 0);
            return result;
        }
        public static UInt64 Get_UInt64(byte[] data, int index, int len)
        {
            UInt64 result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToUInt64(tmp2, 0);
            return result;
        }
        public static float Get_Float(byte[] data, int index, int len)
        {
            float result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToSingle(tmp2, 0);
            return result;
        }
        public static double Get_Double(byte[] data, int index, int len)
        {
            double result = 0;
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToDouble(tmp2, 0);
            return result;
        }
        public static void Set_Int(byte[] data, int index, int len, Int64 value)
        {
            byte[] tmp;

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, sizeof(Int64));
            Array.Copy(tmp, sizeof(Int64) - len, data, index, len);
        }
        public static void Set_UInt(byte[] data, int index, int len, UInt64 value)
        {
            byte[] tmp;

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, sizeof(UInt64));
            Array.Copy(tmp, sizeof(Int64) - len, data, index, len);
        }
        public static void Set_Double(byte[] data, int index, int len, double value)
        {
            byte[] tmp;

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, sizeof(double));
            Array.Copy(tmp, sizeof(Int64) - len, data, index, len);
        }
        public static byte[] Swap_Byte(byte[] data, int index, int len)
        {
            byte[] result = new byte[len];

            if (data.Length >= index + len)
            {
                for (int i = 0; i < len; i++) result[i] = data[index + len - i - 1];
            }
            return result;
        }
    }
    public static class PageControl_Tool
    {
        public static void Tab_Page_Select(System.Windows.Forms.TabControl tab_control, string name)
        {
            for (int i = 0; i < tab_control.TabCount; i++)
            {
                if (tab_control.TabPages[i].Text == name)
                {
                    tab_control.SelectedIndex = i;
                    break;
                }
            }
        }
        public static void Tab_Page_Hide(System.Windows.Forms.TabControl tab_control)
        {
            tab_control.Appearance = TabAppearance.Buttons;
            tab_control.SizeMode = TabSizeMode.Fixed;
            tab_control.ItemSize = new System.Drawing.Size(0, 1);
        }
    }
    public static class TreeView_Tool
    {
        public static void Get_Node_Name_List(TreeNode node, ref ArrayList list)
        {
            TreeNode tmp_node;
            ArrayList tmp_list = new ArrayList();

            tmp_node = node;
            while (tmp_node != null)
            {
                tmp_list.Add(tmp_node.Name);
                tmp_node = tmp_node.Parent;
            }

            list.Clear();
            for (int i = tmp_list.Count - 2; i >= 0; i--)
            {
                list.Add(tmp_list[i]);
            }
        }
        public static void Get_Node_Text_List(TreeNode node, ref ArrayList list)
        {
            TreeNode tmp_node;
            ArrayList tmp_list = new ArrayList();

            tmp_node = node;
            while (tmp_node != null)
            {
                tmp_list.Add(tmp_node.Text);
                tmp_node = tmp_node.Parent;
            }

            list.Clear();
            for (int i = tmp_list.Count - 2; i >= 0; i--)
            {
                list.Add(tmp_list[i]);
            }
        }
        public static string Get_Node_Full_Name(TreeNode node)
        {
            string result = "";
            ArrayList list = new ArrayList();
            Get_Node_Name_List(node, ref list);
            foreach (string str in list)
            {
                result = result + "\\" + str;
            }
            return result;
        }
        public static string Get_Node_Full_Text(TreeNode node)
        {
            string result = "";
            ArrayList list = new ArrayList();
            Get_Node_Text_List(node, ref list);
            foreach (string str in list)
            {
                result = result + "\\" + str;
            }
            return result;
        }
        public static TreeNode Get_Sub_Node_Text(TreeNode node, string name)
        {
            TreeNode result = null;
            TreeNode tmp_node;

            tmp_node = node.FirstNode;
            while (tmp_node != null)
            {
                if (tmp_node.Text == name)
                {
                    result = tmp_node;
                    break;
                }
                tmp_node = tmp_node.NextNode;
            }
            return result;
        }
        public static TreeNode Get_Sub_Node_Name(TreeNode node, string name)
        {
            TreeNode result = null;
            TreeNode tmp_node;

            tmp_node = node.FirstNode;
            while (tmp_node != null)
            {
                if (tmp_node.Name == name)
                {
                    result = tmp_node;
                    break;
                }
                tmp_node = tmp_node.NextNode;
            }
            return result;
        }
        public static TreeNode Find_Node_Text(TreeView tree, string name_list)
        {
            TreeNode result = null;
            ArrayList list = new ArrayList();

            String_Tool.Break_String(name_list, "\\", ref list);
            result = tree.Nodes[0];
            for (int i = 0; i < list.Count; i++)
            {
                result = Get_Sub_Node_Text(result, list[i].ToString());
                if (result == null) break;
            }
            return result;
        }
        public static TreeNode Find_Node_Name(TreeView tree, string name_list)
        {
            TreeNode result = null;
            ArrayList list = new ArrayList();

            String_Tool.Break_String(name_list, "\\", ref list);
            result = tree.Nodes[0];
            for (int i = 0; i < list.Count; i++)
            {
                result = Get_Sub_Node_Name(result, list[i].ToString());
                if (result == null) break;
            }
            return result;
        }
    }
    public static class Form_Tool
    {
        public static void Set_Button_Face(System.Windows.Forms.Button button, bool flag, Color on_color, Color off_color)
        {
            if (flag) button.BackColor = on_color;
            else button.BackColor = off_color;
        }
        public static void Set_Panel_Face(System.Windows.Forms.Panel panel, bool flag, Color on_color, Color off_color)
        {
            if (flag) panel.BackColor = on_color;
            else panel.BackColor = off_color;
        }
    }
    public static class ArrayList_Tool
    {
        public static void LoadFromFile(ref ArrayList str_list, string filename)
        {
            string line;

            str_list.Clear();
            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(filename, System.Text.Encoding.Default);
                while ((line = sr.ReadLine()) != null)
                {
                    str_list.Add(line);
                }
            }
        }
        public static void SaveToFile(ArrayList str_list, string filename)
        {
            str_list.Clear();
            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
                for (int i = 0; i < str_list.Count; i++)
                    sw.WriteLine(str_list[i].ToString());
            }
        }
        public static void Set_String(ref ArrayList list, string[] strings)
        {
            list.Clear();
            for (int i = 0; i < strings.Length; i++)
            {
                list.Add(strings[i]);
            }
        }
        public static ArrayList Sub_String(ArrayList list, int start_index, int len)
        {
            ArrayList result = new ArrayList();
            int end = 0;

            end = start_index + len;
            if (end > list.Count) end = list.Count;
            for (int i = start_index; i < end; i++)
            {
                result.Add(list[i]);
            }
            return result;
        }
        public static ArrayList Add(ArrayList list1, ArrayList list2)
        {
            ArrayList result = new ArrayList();

            for (int i = 0; i < list1.Count; i++)
            {
                result.Add(list1[i]);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                result.Add(list2[i]);
            }
            return result;
        }
        public static string[] To_Strings(ArrayList list)
        {
            string[] result = new string[list.Count];

            for (int i = 0; i < list.Count; i++) result[i] = list[i].ToString();
            return result;
        }
    }
}