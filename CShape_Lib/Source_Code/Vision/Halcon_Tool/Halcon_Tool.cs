using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;
using EFC.INI;


namespace EFC.Vision.Halcon
{
    public delegate bool evExecute_Event(string[] param_list, ref TTool_Values tool_values);

    //-----------------------------------------------------------------------------------------
    //--Halcon_Tool
    //-----------------------------------------------------------------------------------------
    public class Halcon_Tool
    {
        public static string Get_Program_Name(string program_list_str)
        {
            string result = "";
            string[] tmp_list = null;

            Break_String(program_list_str, ref tmp_list);
            if (tmp_list.Length > 0) result = tmp_list[0];
            return result;
        }
        public static void Break_String(string program_list_str, ref ArrayList result)
        {
            String_Tool.Break_String(program_list_str, ",", ref result);
        }
        public static void Break_String(string program_list_str, ref string[] result)
        {
            String_Tool.Break_String(program_list_str, ",", ref result);
        }
        public static bool Is_Variable(string value)
        {
            bool result = false;
            char[] chars;

            if (value != "" && value != null)
            {
                chars = value.ToCharArray();
                if (chars[0] >= '0' && chars[0] <= '9') result = false;
                else if (chars[0] == '\'') result = false;
                else result = true;
            }
            return result;
        }
        public static bool Is_Comment(string program_list)
        {
            bool result = true;

            if (program_list != "" && program_list != null)
            {
                char[] chars = program_list.ToCharArray();
                if (chars[0] == '@') result = true;
                else result = false;
            }
            return result;
        }
    }
    public class THalcon_Tool_File
    {
        public string Default_Path,
                                      Default_FileName,
                                      FileName,
                                      Info;
        public TCommand_Define CMD = new TCommand_Define();


        public THalcon_Tool_File()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        public void Set_Default()
        {
            CMD.Set_Default();
        }
        public THalcon_Tool_File Copy()
        {
            THalcon_Tool_File result = new THalcon_Tool_File();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;

            result.CMD.Set(CMD);
            return result;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = Default_Path + Default_FileName;
            if (System.IO.File.Exists(filename))
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                result = Read(ini, section);
                //ini.UpdateFile();
            };
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;

            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                CMD.Read(ini, tmp_section);
            }
            return true;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "") filename = Default_Path + Default_FileName;
            FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();
            return result;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);

                CMD.Write(ini, tmp_section);
            }
            return true;
        }
    }

}
