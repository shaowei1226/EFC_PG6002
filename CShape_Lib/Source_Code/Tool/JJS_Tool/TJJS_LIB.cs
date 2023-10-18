using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;


namespace EFC.Tool
{
    public enum emJJS_DataType { emNone = 0, emJJS_DtBin = 2, emJJS_DtEight = 8, emJJS_dtTen = 10, emJJS_dtHex = 16 };
    //-----------------------------------------------------------------------------------------------------
    //基礎物件型別
    //-----------------------------------------------------------------------------------------------------
    abstract public class TBase_Class
    {
        abstract public TBase_Class New_Class();
        abstract public void Copy(TBase_Class sor_base, TBase_Class dis_base);
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

        static public unsafe IntPtr memcpy(void* dest, void* src, int count)
        {
            return Dll_Methods.dll_memcpy(dest, src, count);
        }
        static public void memcpy(char[] dst, ref char[] src, int count)
        {
            int cp_count;

            if (count < dst.Length) cp_count = count;
            else cp_count = dst.Length;
            for (int i = 0; i < cp_count; i++)
            {
                dst[i] = src[i];
            }
        }
        static public UInt16 Int16_To_UInt16(Int16 iData)
        {
            UInt16 result = 0;

            int itmp = 0;
            if (iData >= 0) itmp = iData;
            else itmp = iData * -1 + 32767;

            result = Convert.ToUInt16(itmp);
            return result;
        }
        static public bool Get_Bit(byte idata, int bit_no)
        {
            bool result = false;
            int flag;

            if (bit_no >= 0 && bit_no < 8)
            {
                flag = 0x0001;
                flag = flag << bit_no;
                if ((idata & flag) == flag) result = true;
                else result = false;
            }
            return result;
        }
        static public bool Get_Bit(int idata, int bit_no)
        {
            bool result = false;
            int flag;

            if (bit_no >= 0 && bit_no < 16)
            {
                flag = 0x0001;
                flag = flag << bit_no;
                if ((idata & flag) == flag) result = true;
                else result = false;
            }
            return result;
        }
        static public void Set_Bit(ref byte idata, int bit_no, bool bdata)
        {
            int tmp_data = idata;

            if (bit_no >= 0 && bit_no < 8)
            {
                Set_Bit(ref tmp_data, bit_no, bdata);
                idata = (byte)tmp_data;
            }
        }
        static public void Set_Bit(ref int idata, int bit_no, bool bdata)
        {
            int flag1, flag2;

            if (bit_no >= 0 && bit_no < 16)
            {
                flag1 = 0x0001;
                flag1 = flag1 << bit_no;
                flag2 = flag1 ^ 0xFFFF;
                if (bdata) idata = (idata & flag2) | flag1;
                else idata = (idata & flag2);
            }
        }
        static public IntPtr ByteToIntPtr(byte[] in_data)
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
        static public int Get_Max_Int(double value)
        {
            int result = 0;
            result = (int)value;

            if (result != value)
            {
                if (value > 0)
                    result = result + 1;
                else
                    result = result - 1;
            }
            return result;
        }
        static public void Sleep(int milliseconds)
        {
            SpinWait.SpinUntil(() => false, milliseconds);
        }
        static public bool Is_Timeout(DateTime time, double timeout_time)
        {
            bool result = false;

            if (Sub_Time(time, DateTime.Now) > timeout_time) result = true;
            return result;
        }
        static public double Sub_Time(DateTime s_time, DateTime e_time)
        {
            double result = 0;

            TimeSpan tt = e_time - s_time;
            result = tt.TotalMilliseconds;
            return result;
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public static class IntPtr_Tool
    {
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dis, IntPtr sor, uint count);

        public static void Copy(IntPtr sor, IntPtr dis, int count)
        {
            CopyMemory(dis, sor, (uint)count);
        }
        public static void Copy(IntPtr sor, int sor_index, IntPtr dis, int dis_index, int count)
        {
            Copy(IntPtr.Add(sor,sor_index), IntPtr.Add(dis,dis_index), count);
        }
        public static IntPtr Byte_To_IntPtr(byte[] in_data)
        {
            IntPtr result = Marshal.UnsafeAddrOfPinnedArrayElement(in_data, 0);
            return result;
        }
        public static byte[] IntPtr_To_Byte(IntPtr in_data, int len)
        {
            byte[] result = new byte[len];
            Marshal.Copy(in_data, result, 0, len);
            return result;
        }

    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
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

        public static bool StrToBool(string str)
        {
            bool result = false;
            string tmp_str = str.ToUpper();

            if (tmp_str == "0" || tmp_str == "FALSE") result = false;
            else result = true;

            return result;
        }
        public static int StrToInt(string str)
        {
            int result = 0;

            try
            {
                result = Convert.ToInt32(str);
            }
            catch { }
            return result;
        }
        public static double StrToDouble(string str)
        {
            double result = 0;

            try
            {
                result = Convert.ToDouble(str);
            }
            catch { }
            return result;
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

        public static string[] Break_String(string str, string brk_str)
        {
            string[] result = null;
            Break_String(str, brk_str, ref result);
            return result;
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
        public static int Get_Num(string str)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(Get_Num_Char(str));
            }
            catch { };
            return result;
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
        public static string Get_Name(string name_str, string brk_str, int index)
        {
            string result = "";
            ArrayList list = new ArrayList();

            String_Tool.Break_String(name_str, brk_str, ref list);
            if (index < list.Count)
            {
                result = list[index].ToString();
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
        public static int Indexof(byte[] data, string str)
        {
            int result = -1;
            bool flag;
            byte[] end_code = null;

            end_code = Encoding.GetEncoding("Big5").GetBytes(str);
            for (int i = 0; i < data.Length - end_code.Length + 1; i++)
            {
                flag = true;
                for (int j = 0; j < end_code.Length; j++)
                {
                    if (data[i + j] != end_code[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public static class File_Path_Tool
    {
        public static string Get_Path(string full_file_name)
        {
            string result = "";
            result = System.IO.Path.GetDirectoryName(full_file_name);
            if (result.Substring(result.Length - 1, 1) != "\\") result = result + "\\";
            return result;
        }
        public static string Get_FileName(string full_file_name)
        {
            string result = "";
            result = System.IO.Path.GetFileName(full_file_name);
            return result;
        }
        public static string Get_FileName_Name(string full_file_name)
        {
            string result = "";
            result = System.IO.Path.GetFileNameWithoutExtension(full_file_name);
            return result;
        }
        public static string Get_FileName_Ext(string full_file_name)
        {
            string result = "";
            result = System.IO.Path.GetExtension(full_file_name);
            result = result.Replace(".", "");
            return result;
        }

        public static void CreateDirectory(string full_file_name)
        {
            string path = Get_Path(full_file_name);
            if (!System.IO.Directory.Exists(path)) 
                System.IO.Directory.CreateDirectory(path);
        }
        public static ArrayList Get_Dir_List(string sor_dir)
        {
            ArrayList result = new ArrayList();

            try
            {
                List<string> dirs = new List<string>(System.IO.Directory.EnumerateDirectories(sor_dir));
                foreach (string dir in dirs)
                {
                    result.Add(dir);
                }
            }
            catch { };
            return result;
        }
        public static ArrayList Get_Dir_List(string sor_dir, string check_file_name)
        {
            ArrayList result = new ArrayList();
            ArrayList tmp_list = new ArrayList();
            string full_file_name, path;

            tmp_list = Get_Dir_List(sor_dir);
            for (int i = 0; i < tmp_list.Count; i++)
            {
                path = tmp_list[i].ToString();
                if (check_file_name != "")
                {
                    full_file_name = path + "\\" + check_file_name;
                    if (System.IO.File.Exists(full_file_name))
                        result.Add(path);
                }
                else
                {
                    result.Add(path);
                }
            }
            return result;
        }
        public static ArrayList Get_Files_List(string sor_dir)
        {
            ArrayList result = new ArrayList();

            try
            {
                List<string> dirs = new List<string>(System.IO.Directory.EnumerateFiles(sor_dir));
                foreach (string dir in dirs)
                {
                    result.Add(dir);
                }
            }
            catch { };
            return result;

        }
        public static ArrayList Get_Files_List(string sor_dir, string check_ext)
        {
            ArrayList result = new ArrayList();
            ArrayList tmp_list = new ArrayList();
            string full_file_name, ext;

            tmp_list = Get_Files_List(sor_dir);
            for (int i = 0; i < tmp_list.Count; i++)
            {
                full_file_name = tmp_list[i].ToString();
                ext = Get_FileName_Ext(full_file_name).ToUpper();
                if (ext == check_ext.ToUpper())
                    result.Add(full_file_name);
            }
            return result;
        }
       
    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public static class PLC_Data_Tool
    {
        public static bool Get_Bit(ushort[] data, int word_no, int bit_no)
        {
            bool result = false;
            if (word_no < data.Length && bit_no < 16)
                result = JJS_LIB.Get_Bit(data[word_no], bit_no);
            return result;
        }
        public static int Get_Word(ushort[] data, int word_no)
        {
            int result = 0;

            if (word_no < data.Length)
                result = (int)data[word_no];
            return result;
        }
        public static double Get_Word(ushort[] data, int word_no, int dot_num)
        {
            double result;
            result = Get_Word(data, word_no) / Math.Pow(10, dot_num);
            return result;
        }
        public static int Get_DWord(ushort[] data, int word_no)
        {
            int result = 0;
            if (word_no < data.Length)
                result = data[word_no] + (data[word_no + 1] << 16);
            return result;
        }
        public static double Get_DWord(ushort[] data, int word_no, int dot_num)
        {
            double result = 0.0;
            result = Get_DWord(data, word_no) / Math.Pow(10, dot_num);
            return result;
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
        public static void Set_Word(ushort[] data, int word_no, int value)
        {
            data[word_no] = (ushort)value;
        }
        public static void Set_Word(ushort[] data, int word_no, int dot_num, double value)
        {
            Set_Word(data, word_no, (int) Math.Round(value * Math.Pow(10, dot_num), 0));
        }
        public static void Set_DWord(ushort[] data, int word_no, int value)
        {
            if (word_no + 1 < data.Length)
            {
                data[word_no + 1] = (ushort)(value >> 16);
                data[word_no] = (ushort)(value & 0x0000ffff);
            }
        }
        public static void Set_DWord(ushort[] data, int word_no, int dot_num, double value)
        {
            Set_DWord(data, word_no, (int) Math.Round(value * Math.Pow(10, dot_num), 0));
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
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public static class Byte_Tool
    {
        #region Get Data
        public static bool Get_Bit(byte[] data, int word_no, int bit_no)
        {
            bool result = false;
            if (word_no < data.Length && bit_no < 8)
                result = JJS_LIB.Get_Bit(data[word_no], bit_no);
            return result;
        }

        public static byte Get_Byte(byte[] data, int index)
        {
            byte result = data[index];
            return result;
        }
        public static Int16 Get_Int16(byte[] data, int index)
        {
            Int16 result = 0;
            int len = sizeof(Int16);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToInt16(tmp2, 0);
            return result;
        }
        public static Int32 Get_Int32(byte[] data, int index)
        {
            Int32 result = 0;
            int len = sizeof(Int32);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToInt32(tmp2, 0);
            return result;
        }
        public static Int64 Get_Int64(byte[] data, int index)
        {
            Int64 result = 0;
            int len = sizeof(Int64);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToInt64(tmp2, 0);
            return result;
        }
        public static double Get_Int16(byte[] data, int index, int dot_num)
        {
            double result = 0;
            result = Get_Int16(data, index) / Math.Pow(10, dot_num);
            return result;
        }
        public static double Get_Int32(byte[] data, int index, int dot_num)
        {
            double result = 0;
            result = Get_Int32(data, index) / Math.Pow(10, dot_num);
            return result;
        }
        public static double Get_Int64(byte[] data, int index, int dot_num)
        {
            double result = 0;
            result = Get_Int64(data, index) / Math.Pow(10, dot_num);
            return result;
        }
        
        public static UInt16 Get_UInt16(byte[] data, int index)
        {
            UInt16 result = 0;
            int len = sizeof(UInt16);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToUInt16(tmp2, 0);
            return result;
        }
        public static UInt32 Get_UInt32(byte[] data, int index)
        {
            UInt32 result = 0;
            int len = sizeof(UInt32);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToUInt32(tmp2, 0);
            return result;
        }
        public static UInt64 Get_UInt64(byte[] data, int index)
        {
            UInt64 result = 0;
            int len = sizeof(UInt64);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToUInt64(tmp2, 0);
            return result;
        }
        public static double Get_UInt16(byte[] data, int index, int dot_num)
        {
            double result = 0;
            result = Get_UInt16(data, index) / Math.Pow(10, dot_num);
            return result;
        }
        public static double Get_UInt32(byte[] data, int index, int dot_num)
        {
            double result = 0;
            result = Get_UInt32(data, index) / Math.Pow(10, dot_num);
            return result;
        }
        public static double Get_UInt64(byte[] data, int index, int dot_num)
        {
            double result = 0;
            result = Get_UInt64(data, index) / Math.Pow(10, dot_num);
            return result;
        }
        
        public static float Get_Float(byte[] data, int index)
        {
            float result = 0;
            int len = sizeof(float);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToSingle(tmp2, 0);
            return result;
        }
        public static double Get_Double(byte[] data, int index)
        {
            double result = 0;
            int len = sizeof(double);
            byte[] tmp1 = new byte[8];
            byte[] tmp2 = new byte[8];

            tmp1 = Swap_Byte(data, index, len);
            Array.Copy(tmp1, 0, tmp2, 0, len);
            result = BitConverter.ToDouble(tmp2, 0);
            return result;
        }

        public static string Get_String(ushort[] data, int index, int len)
        {
            string result = "";
            byte[] tmp = new byte[len];

            Array.Copy(data, index, tmp, 0, len);
            result = BitConverter.ToString(tmp);
            return result;
        }
        #endregion

        #region Set Data
        public static void Set_Bit(byte[] data, int word_no, int bit_no, bool value)
        {
            byte data_int;

            if (word_no < data.Length && bit_no < 8)
            {
                data_int = data[word_no];
                JJS_LIB.Set_Bit(ref data_int, bit_no, value);
                data[word_no] = (byte)data_int;
            }
        }

        public static void Set_Int16(byte[] data, int index, Int16 value)
        {
            byte[] tmp;
            int len = sizeof(Int16);
            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }
        public static void Set_Int32(byte[] data, int index, Int32 value)
        {
            byte[] tmp;
            int len = sizeof(Int32);

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }
        public static void Set_Int64(byte[] data, int index, Int64 value)
        {
            byte[] tmp;
            int len = sizeof(Int64);

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }

        public static void Set_UInt16(byte[] data, int index, UInt16 value)
        {
            byte[] tmp;
            int len = sizeof(UInt16);

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }
        public static void Set_UInt32(byte[] data, int index, UInt32 value)
        {
            byte[] tmp;
            int len = sizeof(UInt32);

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }
        public static void Set_UInt64(byte[] data, int index, UInt64 value)
        {
            byte[] tmp;
            int len = sizeof(UInt64);

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }

        public static void Set_Float(byte[] data, int index, float value)
        {
            byte[] tmp;
            int len = sizeof(float);

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }
        public static void Set_Double(byte[] data, int index, double value)
        {
            byte[] tmp;
            int len = sizeof(double);

            tmp = Swap_Byte(BitConverter.GetBytes(value), 0, len);
            Array.Copy(tmp, 0, data, index, len);
        }

        public static void Set_String(ushort[] data, int index, int len, string value)
        {
            int write_len = 0;

            if (value.Length < len) write_len = value.Length;
            else write_len = len;
            char[] str_data = value.ToCharArray();
            Array.Copy(str_data, 0, data, index, write_len);
        }
        #endregion

        #region Other
        public static byte[] Get_Byte(byte[] data, int index, int len)
        {
            byte[] result = new byte[len];
            Array.Copy(data, index, result, 0, len);
            return result;
        }
        public static byte[] Swap_Byte(byte[] data)
        {
            byte[] result = Swap_Byte(data, 0, data.Length);
            return result;
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
        public static byte[] Get_Byte(Int16 value)
        {
            byte[] result = BitConverter.GetBytes(value);
            return result;
        }
        public static byte[] Get_Byte(Int32 value)
        {
            byte[] result = BitConverter.GetBytes(value);
            return result;
        }
        public static byte[] Get_Byte(Int64 value)
        {
            byte[] result = BitConverter.GetBytes(value);
            return result;
        }
        public static byte[] Get_Byte(UInt16 value)
        {
            byte[] result = BitConverter.GetBytes(value);
            return result;
        }
        public static byte[] Get_Byte(UInt32 value)
        {
            byte[] result = BitConverter.GetBytes(value);
            return result;
        }
        public static byte[] Get_Byte(UInt64 value)
        {
            byte[] result = BitConverter.GetBytes(value);
            return result;
        }
        public static byte[] Get_Byte(ushort[] value)
        {
            byte[] result = new byte[value.Length * 2];
            byte[] tmp_byte = null;
            int index = 0;

            for (int i = 0; i < value.Length; i++)
            {
                tmp_byte = Get_Byte(value[i]);
                Array.Copy(tmp_byte, 0, result, index, tmp_byte.Length);
                index = index + tmp_byte.Length;
            }
            return result;
        }
        public static byte[] Get_Byte(short[] value)
        {
            byte[] result = new byte[value.Length * 2];
            byte[] tmp_byte = null;
            int index = 0;

            for (int i = 0; i < value.Length; i++)
            {
                tmp_byte = Get_Byte(value[i]);
                Array.Copy(tmp_byte, 0, result, index, tmp_byte.Length);
                index = index + tmp_byte.Length;
            }
            return result;
        }
        #endregion
    }
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
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
        public static void Add_Node_Name(TreeNode node, string name_list, bool over_flag = true)
        {
            ArrayList list = new ArrayList();
            TreeNode tmp_node = node;
            string name = "";

            String_Tool.Break_String(name_list, "\\", ref list);
            for (int i = 0; i < list.Count; i++)
            {
                name = list[i].ToString();
                TreeNode check_node = Get_Sub_Node_Name(tmp_node, name);
                if (!over_flag || check_node == null)
                    tmp_node = tmp_node.Nodes.Add(name, name, 0, 0);
                else
                    tmp_node = check_node;
            }
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
        public static ArrayList New_ArrayList(string[] list)
        {
            ArrayList result = new ArrayList();
            Set_String(ref result, list);
            return result;
        }
        public static void LoadFromFile(ref ArrayList str_list, string filename)
        {
            string line;

            str_list.Clear();
            if (System.IO.File.Exists(filename))
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(filename, System.Text.Encoding.Default);

                string code = sr.CurrentEncoding.BodyName;
                while ((line = sr.ReadLine()) != null)
                {
                    str_list.Add( line);
                }
                sr.Close();
            }
        }
        public static void SaveToFile(ArrayList str_list, string filename)
        {
            if (System.IO.File.Exists(filename)) System.IO.File.Delete(filename);
            for (int i = 0; i < str_list.Count; i++)
                System.IO.File.AppendAllText(filename, str_list[i].ToString() + "\r\n"); 
        }
        public static void Set_String(ref ArrayList list, string[] strings)
        {
            list.Clear();
            for (int i = 0; i < strings.Length; i++)
            {
                list.Add(strings[i]);
            }
        }
        public static ArrayList Sub_String(ArrayList list, int start_index)
        {
            ArrayList result = new ArrayList();
            int end = 0;

            end = list.Count;
            if (end > list.Count) end = list.Count;
            for (int i = start_index; i < end; i++)
            {
                result.Add(list[i]);
            }
            return result;
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
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public class TJJS_Value_List : TBase_Class
    {
        public TJJS_Value[] Items = new TJJS_Value[0];

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count;

                old_count = Items.Length;
                Array.Resize(ref Items, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Items[i] = new TJJS_Value();
                }
            }
        }
        public TJJS_Value_List()
        {
        }
        override public TBase_Class New_Class()
        {
            return new TJJS_Value_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_Value_List && dis_base is TJJS_Value_List)
            {
                TJJS_Value_List sor = (TJJS_Value_List)sor_base;
                TJJS_Value_List dis = (TJJS_Value_List)dis_base;

                dis.Count = sor.Count;
                for (int i = 0; i < sor.Count; i++) dis.Items[i].Set(sor.Items[i]);
            }
        }

        public void Set_Default()
        {
            Count = 0;
        }
        public void Reset()
        {
            Set_Default();
        }
        public void Clear()
        {
            Set_Default();
        }
        public TJJS_Value this[int index]
        {
            get
            {
                TJJS_Value result = null;
                if (index >= 0 && index < Items.Length) result = Items[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    Items[index].Set(value);
                }
            }
        }
        public TJJS_Value this[string name]
        {
            get
            {
                return Get_Value(name);
            }
            set
            {
                TJJS_Value get_value = Get_Value(name);
                if (get_value != null) get_value.Set(value);
            }
        }
        public int IndexOf(string name)
        {
            int result = -1;
            TJJS_Value tmp_obj = null;

            for (int i = 0; i < Items.Length; i++)
            {
                tmp_obj = Items[i];
                if (name == tmp_obj.Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public int IndexOf(TJJS_Value value)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == value)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Add(TJJS_Value value)
        {
            int no = 0;

            no = IndexOf(value.Name);
            if (no < 0)
            {
                no = Count;
                Count++;
            }
            Items[no].Set(value);
        }
        public void Add(string name, object value)
        {
            Add(new TJJS_Value(name, value));
        }
        public void Add_Bool(string name, bool value)
        {
            Add(new TJJS_Value(name, value));
        }
        public void Add_Bool(string name, string value)
        {
            Add(new TJJS_Value(name, String_Tool.StrToBool(value)));
        }
        public void Add_Int(string name, int value)
        {
            Add(new TJJS_Value(name, value));
        }
        public void Add_Int(string name, string value)
        {
            Add(new TJJS_Value(name, String_Tool.StrToBool(value)));
        }
        public void Add_Double(string name, double value)
        {
            Add(new TJJS_Value(name, value));
        }
        public void Add_Double(string name, string value)
        {
            Add(new TJJS_Value(name, String_Tool.StrToBool(value)));
        }
        public void Add_String(string name, string value)
        {
            Add(new TJJS_Value(name, value));
        }

        public void Remove(TJJS_Value value)
        {
            RemoveAt(IndexOf(value));
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Items.Length)
            {
                for (int i = index; i < Items.Length - 1; i++)
                {
                    Items[i] = Items[i + 1];
                }
                Array.Resize(ref Items, Count - 1);
            }
        }
        public void RemoveAt(string name)
        {
            RemoveAt(IndexOf(name));
        }

 
        public TJJS_Value Get_Value(string name)
        {
            TJJS_Value result = null;
            int index = IndexOf(name);
            if (index >= 0 && index < Count) result = Items[index];
            return result;
        }
        public bool Get_Value_Bool(string name)
        {
            bool result = false;
            TJJS_Value data = this[name];
            if (data != null) result = data.Get_Value_Bool();
            return result;
        }
        public int Get_Value_Int(string name)
        {
            int result = 0;
            TJJS_Value data = this[name];
            if (data != null) result = data.Get_Value_Int();
            return result;
        }
        public double Get_Value_Double(string name)
        {
            double result = 0.0;
            TJJS_Value data = this[name];
            if (data != null) result = data.Get_Value_Double();
            return result;
        }
        public string Get_Value_String(string name)
        {
            string result = "";
            TJJS_Value data = this[name];
            if (data != null) result = data.Get_Value_String();
            return result;
        }
        public string To_String()
        {
            string result = "";
            for (int i = 0; i < Count; i++)
            {
                if (result == "") result = this[i].To_String();
                else result = result + this[i].To_String();
            }
            return result;
        }

    }
    public class TJJS_Value : TBase_Class
    {
        public string Name;
        public object Value;

        public TJJS_Value()
        {

        }
        public TJJS_Value(string name, object value)
        {
            Name = name;
            Value = value;
        }
        override public TBase_Class New_Class()
        {
            return new TJJS_Value();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_Value && dis_base is TJJS_Value)
            {
                TJJS_Value sor = (TJJS_Value)sor_base;
                TJJS_Value dis = (TJJS_Value)dis_base;

                dis.Name = sor.Name;
                dis.Value = sor.Value;
            }
        }
        public string To_String()
        {
            string result = "";
            string type_str = "";

            type_str = Value.GetType().ToString();
            switch (type_str)
            {
                case "System.String":
                    result = string.Format("{0:s}={1:s} ,", Name, Value);
                    break;

                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                    result = string.Format("{0:s}={1:d} ,", Name, Value);
                    break;

                case "System.Double":
                case "System.Single":
                    result = string.Format("{0:s}={1:f3} ,", Name, Value);
                    break;

                default:
                    base.ToString();
                    break;
            }
            return result;
        }
        public void Set_Value(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public void Set_Value_Bool(bool value)
        {
            Value = value;
        }
        public void Set_Value_Bool(string value)
        {
            Set_Value_Bool(String_Tool.StrToBool(value));
        }
        public void Set_Value_Int(int value)
        {
            Value = value;
        }
        public void Set_Value_Int(string value)
        {
            Set_Value_Int(String_Tool.StrToInt(value));
        }
        public void Set_Value_Double(double value)
        {
            Value = value;
        }
        public void Set_Value_Double(string value)
        {
            Set_Value_Double(String_Tool.StrToDouble(value));
        }
        public void Set_Value_String(string value)
        {
            Value = value;
        }
        public bool Get_Value_Bool()
        {
            bool result = false;
            if (Value is bool) result = (bool)Value;
            return result;
        }
        public int Get_Value_Int()
        {
            int result = 0;
            if (Value is int) result = (int)Value;
            return result;
        }
        public double Get_Value_Double()
        {
            double result = 0;
            if (Value is double) result = (double)Value;
            if (Value is int) result = (int)Value;
            return result;
        }
        public string Get_Value_String()
        {
            string result = "";
            if (Value is string) result = (string)Value;
            return result;
        }

    }

    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public class TSort_Data
    {
        public int Index;
        public double Value;

        public TSort_Data(int index, double value)
        {
            Index = index;
            Value = value;
        }
    }
    public class TSort_Data_Compare : IComparer
    {
        public int Compare(object x, object y)
        {
            int result = 0;

            TSort_Data obj1 = (TSort_Data)x;
            TSort_Data obj2 = (TSort_Data)y;

            if (obj1.Value == obj2.Value) result = 0;
            if (obj1.Value < obj2.Value) result = -1;
            if (obj1.Value > obj2.Value) result = 1;
            return result;
        }
    }
    public class TEFC_Tree_Node
    {
        public string Name;
        public string Info;
        public TEFC_Tree_Node[] Items = new TEFC_Tree_Node[0];


        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count;

                old_count = Items.Length;
                Array.Resize(ref Items, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Items[i] = new TEFC_Tree_Node();
                }
            }
        }
        public TEFC_Tree_Node()
        {

        }
        public TEFC_Tree_Node(string name, string info = "")
        {
            Name = name;
            Info = info;
        }
        public TEFC_Tree_Node this[int index]
        {
            get
            {
                if (index >= 0 && index < Count) return Items[index];
                else return null;
            }
            set
            {
                if (index >= 0 && index < Count) Items[index] = value;
            }
        }
        public TEFC_Tree_Node this[string name]
        {
            get
            {
                int index = Indexof(name);
                if (index >= 0 && index < Count) return Items[index];
                else return null;
            }
            set
            {
                int index = Indexof(name);
                if (index >= 0 && index < Count) Items[index] = value;
            }
        }
        public int Indexof(string name)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (name == Items[i].Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public void Add(TEFC_Tree_Node item)
        {
            Count++;
            Items[Count - 1] = item;
        }
        public void Add(string name, string info = "")
        {
            Count++;
            Items[Count - 1] = new TEFC_Tree_Node(name, info);
        }
        public void Add(string[] name, string info = "")
        {
            for (int i = 0; i < name.Length; i++)
            {
                Count++;
                Items[Count - 1] = new TEFC_Tree_Node(name[i], info);
            }
        }
        public string[] Get_List()
        {
            string[] result = new string[Items.Length];
            for (int i = 0; i < Items.Length; i++)
            {
                result[i] = Items[i].Name;
            }
            return result;
        }
    }
    public class Animate_Image
    {
        private Control Owner = null;
        private Image in_Image = null;
        private FrameDimension Frame_Dimension = null;
        private bool Can_Animate = false;
        private int Frame_Count = 1;
        private int Current_Frame = 0;
        private bool in_Playing = false;

        public bool Playing
        {
            get
            {
                return in_Playing;
            }
            set
            {
                if (value) Play();
                else Stop();
            }
        }
        public Animate_Image(Control owner, Image img)
        {
            Set_Image(owner, img);
        }
        public void Set_Image(Control owner, Image img)
        {
            Owner = owner;
            in_Image = img;

            lock (in_Image)
            {
                Can_Animate = ImageAnimator.CanAnimate(in_Image);
                if (Can_Animate)
                {
                    Guid[] guid = in_Image.FrameDimensionsList;
                    Frame_Dimension = new FrameDimension(guid[0]);
                    Frame_Count = in_Image.GetFrameCount(Frame_Dimension);
                }
            }
        }
        public void Play()
        {
            if (Can_Animate)
            {
                if (!in_Playing)
                {
                    lock (in_Image)
                    {
                        ImageAnimator.Animate(in_Image, new EventHandler(FrameChanged));
                        in_Playing = true;
                    }
                }
            }
        }
        public void Stop()
        {
            if (Can_Animate)
            {
                lock (in_Image)
                {
                    ImageAnimator.StopAnimate(in_Image, new EventHandler(FrameChanged));
                    in_Playing = false;
                }
            }
        }
        public void Reset()
        {
            if (Can_Animate)
            {
                ImageAnimator.StopAnimate(in_Image, new EventHandler(FrameChanged));
                lock (in_Image)
                {
                    in_Image.SelectActiveFrame(Frame_Dimension, 0);
                    Current_Frame = 0;
                }
            }
        }
        private void FrameChanged(object sender, EventArgs e)
        {
            Current_Frame++;
            if (Current_Frame >= Frame_Count) Current_Frame = 0;

            lock (in_Image)
            {
                in_Image.SelectActiveFrame(Frame_Dimension, Current_Frame);
                if (Owner != null) Owner.Invalidate();
            }
        }
    }   

}