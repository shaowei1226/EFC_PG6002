using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using EFC.INI;
using EFC.Tool;


namespace EFC.File_Manager
{
    public static class File_Manager
    {
        public static TLog Log = null;
        public static string Log_Source = "File_Manager";

        public static ArrayList Paths = new ArrayList();
        public static ArrayList Files = new ArrayList();
        public static bool Auto_Delete_File = false;
        public static int Days = 10;
        public static bool On_Delete_File = false;
        public static string Date_Str = "";


        public static bool Date_Change
        {
            get
            {
                bool result = false;
                if (Get_Date_Str(DateTime.Now) != Date_Str) result = true;
                return result;
            }
        }
        public static void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Log_Source, fun, "[File_Manager]" + msg_str, type);
        }


        public static void Delete()
        {
            if (Auto_Delete_File && !On_Delete_File && Date_Change)
            {
                Log_Add("Delete", "[File_Manager] Delete Start.");
                On_Delete_File = true;
                for (int i = 0; i < Paths.Count; i++)
                {
                    Delete_Path(Paths[i].ToString(), Days);
                }

                ArrayList list = new ArrayList();
                for (int i = 0; i < Files.Count; i++)
                {
                    String_Tool.Break_String(Files[i].ToString(), ",", ref list);
                    Delete_Files(list[0].ToString(), list[1].ToString(), Days);
                }
                Date_Str = Get_Date_Str(DateTime.Now);
                On_Delete_File = false;
                Log_Add("Delete", "[File_Manager] Delete Finish.");
            }
        }
        public static void Add_Path(string path)
        {
            Paths.Add(path);
        }
        public static void Add_Files(string path, string ext)
        {
            Files.Add(path + "," + ext);
        }
        public static void Delete_Path(string path, int days)
        {
            string del_path = "";

            DirectoryInfo[] dir_info = Get_Dir_Info_List(path);
            for (int i = 0; i < dir_info.Length; i++)
            {
               TimeSpan ofs_days  =  DateTime.Now - dir_info[i].LastWriteTime;
               if (ofs_days.Days >= days)
               {
                   del_path = dir_info[i].FullName;
                   Log_Add("Delete_Path", string.Format("Delete Path={0:s} Days={1:d}", del_path, ofs_days.Days));
                   System.IO.Directory.Delete(del_path, true);
               }
            }
        }
        public static void Delete_Files(string path, string ext, int days)
        {
            string del_file = "";

            FileInfo[] file_info = Get_Files_Info_List(path, ext);
            for (int i = 0; i < file_info.Length; i++)
            {
                TimeSpan ofs_days = DateTime.Now - file_info[i].LastWriteTime;
                if (ofs_days.Days >= days)
                {
                    del_file = file_info[i].FullName;
                    Log_Add("Delete_Files", string.Format("Delete File={0:s} Days={1:d}", del_file, ofs_days.Days));
                    System.IO.File.Delete(del_file);
                }
            }
        }


        private static string Get_Date_Str(DateTime date)
        {
            string result = "";

            result = date.ToString("yyyy-MM-dd");
            return result;
        }

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
        public static DirectoryInfo[] Get_Dir_Info_List(string sor_dir)
        {
            DirectoryInfo[] result = Get_Dir_Info_List(Get_Dir_List(sor_dir));
            return result;
        }
        public static DirectoryInfo[] Get_Dir_Info_List(string sor_dir, string check_file_name)
        {
            DirectoryInfo[] result = Get_Dir_Info_List(Get_Dir_List(sor_dir, check_file_name));
            return result;
        }
        public static DirectoryInfo[] Get_Dir_Info_List(ArrayList dir_list)
        {
            DirectoryInfo[] result = new DirectoryInfo[0];

            Array.Resize(ref result, dir_list.Count);
            for (int i = 0; i < dir_list.Count; i++)
            {
                result[i] = new DirectoryInfo((string)dir_list[i]);
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
        public static FileInfo[] Get_Files_Info_List(string sor_dir)
        {
            FileInfo[] result = Get_Files_Info_List(Get_Files_List(sor_dir));
            return result;
        }
        public static FileInfo[] Get_Files_Info_List(string sor_dir, string check_ext)
        {
            FileInfo[] result = Get_Files_Info_List(Get_Files_List(sor_dir, check_ext));
            return result;
        }
        public static FileInfo[] Get_Files_Info_List(ArrayList file_list)
        {
            FileInfo[] result = new FileInfo[0];

            Array.Resize(ref result, file_list.Count);
            for (int i = 0; i < file_list.Count; i++)
            {
                result[i] = new FileInfo((string)file_list[i]);
            }

            return result;
        }
    }
}
