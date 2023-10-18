using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;       //  For Dll Import
using System.Threading;
using EFC.Tool;
using EFC.INI;
using EFC.Instrument.Modbus;


namespace EFC.Instrument.Omron
{
    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------
    public class TE5CC_T : TModbus_Station_Base
    {
        public TE5CC_T(int station_no)
            : base(station_no)
        {
        }
        override public TModbus_Param Get_Param_W2(ArrayList param_list)
        {
            TModbus_Param result = null;
            string param_name = "";
            string in_param_name = List_To_String(param_list);

            param_name = (string)param_list[0];
            if (param_list.Count == 1)
            {
                switch (param_name)
                {
                    case "現在值": result = new TModbus_Param(in_param_name, 0x2000, 0, emData_Size.Int16); break;
                    case "狀態": result = new TModbus_Param(in_param_name, 0x2001, 0, emData_Size.Int16); break;
                    case "設定值": result = new TModbus_Param(in_param_name, 0x2002, 0, emData_Size.Int16); break;
                    case "使用程式編號": result = new TModbus_Param(in_param_name, 0x2608, 0, emData_Size.Int16); break;
                    case "程式時間單位": result = new TModbus_Param(in_param_name, 0x2D1A, 0, emData_Size.Int16); break;
                    case "使用段數": result = new TModbus_Param(in_param_name, 0x3801, 0, emData_Size.Int16); break;
                }
            }
            else
            {
                switch (param_name)
                {
                    case "PID": result = Get_Param_PID_W2(param_list); break;
                    case "程式": result = Get_Param_Program_W2(param_list); break;
                }
            }
            return result;
        }
        override public TModbus_Param Get_Param_W4(ArrayList param_list)
        {
            TModbus_Param result = null;
            string param_name = "";
            string in_param_name = List_To_String(param_list);

            param_name = (string)param_list[0];
            if (param_list.Count == 1)
            {
                switch (param_name)
                {
                    case "現在值": result = new TModbus_Param(in_param_name, 0x0000, 0, emData_Size.Int32); break;
                    case "狀態": result = new TModbus_Param(in_param_name, 0x0002, 0, emData_Size.Int32); break;
                    case "設定值": result = new TModbus_Param(in_param_name, 0x0004, 0, emData_Size.Int32); break;
                    case "使用程式編號": result = new TModbus_Param(in_param_name, 0x0610, 0, emData_Size.Int32); break;
                    case "程式時間單位": result = new TModbus_Param(in_param_name, 0x0D34, 0, emData_Size.Int32); break;
                    case "使用段數": result = new TModbus_Param(in_param_name, 0x1802, 0, emData_Size.Int32); break;
                }
            }
            else
            {
                switch (param_name)
                {
                    case "PID": result = Get_Param_PID_W4(param_list); break;
                    case "程式": result = Get_Param_Program_W4(param_list); break;
                }
            }
            return result;
        }


        public bool Read_PID_Data(ref TE5CCT_PID data, int pid_no)
        {
            bool result = false;
            Int32[] get_data_int32 = null;
            int count = 0x10;

            string param_name = string.Format("PID/{0:d}/比例帶", pid_no);
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                byte[] get_data = Read_Byte(param.Addr, count * 2);
                if (get_data != null) get_data_int32 = Modbus_Tool.Byte_To_Int32(get_data);

                if (get_data_int32.Length == count)
                {
                    data.Proportion = get_data_int32[0];
                    data.Integral = get_data_int32[1];
                    data.Differential = get_data_int32[2];
                    data.Limit_Up = get_data_int32[3];
                    data.Limit_Dn = get_data_int32[4];
                    data.Auto_Limit_Up = get_data_int32[5];
                    data.LBA_Time = get_data_int32[7];
                    data.Proportion_Cool = get_data_int32[8];
                    data.Integral_Cool = get_data_int32[9];
                    data.Differential_Cool = get_data_int32[10];
                    data.Bad_Area = get_data_int32[11];
                    data.Reset_Value = get_data_int32[12];
                }
            }
            return result;
        }
        public bool Write_PID_Data(TE5CCT_PID data, int pid_no)
        {
            bool result = false;
            Int32[] get_data_int32 = null;
            int count = 0x10;

            string param_name = string.Format("PID/{0:d}/比例帶", pid_no);
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                get_data_int32 = new Int32[count];

                get_data_int32[0] = data.Proportion;
                get_data_int32[1] = data.Integral;
                get_data_int32[2] = data.Differential;
                get_data_int32[3] = data.Limit_Up;
                get_data_int32[4] = data.Limit_Dn;
                get_data_int32[5] = data.Auto_Limit_Up;
                get_data_int32[7] = data.LBA_Time;
                get_data_int32[8] = data.Proportion_Cool;
                get_data_int32[9] = data.Integral_Cool;
                get_data_int32[10] = data.Differential_Cool;
                get_data_int32[11] = data.Bad_Area;
                get_data_int32[12] = data.Reset_Value;

                byte[] data_byte = Modbus_Tool.Int32_To_Byte(get_data_int32, get_data_int32.Length);
                result = Write_Byte(param.Addr, count * 2, data_byte);
            }
            return result;
        }
        public bool Read_Segment_Data(ref TE5CCT_Segment data, int program_no, int segment_no)
        {
            bool result = false;
            byte[] get_data = null;
            Int32[] get_data_int32 = null;
            int count = 0x0004;

            string param_name = string.Format("程式/{0:d}/區段/{1:d}/格式", program_no, segment_no);
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                get_data = Read_Byte(param.Addr, count * 2);
                if (get_data != null) get_data_int32 = Modbus_Tool.Byte_To_Int32(get_data);

                if (get_data_int32 != null && get_data_int32.Length == count)
                {
                    data.Type = get_data_int32[0];
                    data.Temp = get_data_int32[1];
                    data.Rate = get_data_int32[2];
                    data.Time = get_data_int32[3];
                }
            }
            return result;
        }
        public bool Write_Segment_Data(TE5CCT_Segment data, int program_no, int segment_no)
        {
            bool result = false;
            Int32[] get_data_int32 = null;
            int count = 0x0004;

            string param_name = string.Format("程式/{0:d}/區段/{1:d}/格式", program_no, segment_no);
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                get_data_int32 = new Int32[count];
                get_data_int32[0] = data.Type;
                get_data_int32[1] = data.Temp;
                get_data_int32[2] = data.Rate;
                get_data_int32[3] = data.Time;

                byte[] data_byte = Modbus_Tool.Int32_To_Byte(get_data_int32, get_data_int32.Length);
                result = Write_Byte(param.Addr, count * 2, data_byte);
            }
            return result;
        }
        public bool Read_Program_Data(ref TE5CCT_Program data, int program_no)
        {
            bool result = false;
            byte[] get_data = null;
            Int32[] get_data_int32 = null;
            int count = 0x80;

            string param_name = string.Format("程式/{0:d}/區段/{1:d}/格式", program_no, 0);
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                get_data = Read_Byte(param.Addr, count * 2);
                if (get_data != null) get_data_int32 = Modbus_Tool.Byte_To_Int32(get_data);

                if (get_data_int32 != null && get_data_int32.Length == count)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        data.Segment[i].Type = get_data_int32[i * 4 + 0];
                        data.Segment[i].Temp = get_data_int32[i * 4 + 1];
                        data.Segment[i].Rate = get_data_int32[i * 4 + 2];
                        data.Segment[i].Time = Time_Hex_To_Int(get_data_int32[i * 4 + 3]);
                    }
                    result = true;
                }
                else
                    Modbus.Log_Add("Read_Program_Data error");
            }
            return result;
        }
        public bool Write_Program_Data(TE5CCT_Program data, int program_no)
        {
            bool result = false;
            Int32[] get_data_int32 = null;
            int count = 0x80;

            string param_name = string.Format("程式/{0:d}/區段/{1:d}/格式", program_no, 0);
            TModbus_Param param = Get_Param(param_name, emData_Size.Int32);
            if (param != null)
            {
                get_data_int32 = new Int32[count];
                for (int i = 0; i < 32; i++)
                {
                    get_data_int32[i * 4 + 0] = data.Segment[i].Type;
                    get_data_int32[i * 4 + 1] = data.Segment[i].Temp;
                    get_data_int32[i * 4 + 2] = data.Segment[i].Rate;
                    get_data_int32[i * 4 + 3] = Time_Int_To_Hex(data.Segment[i].Time);
                }

                byte[] data_byte = Modbus_Tool.Int32_To_Byte(get_data_int32, get_data_int32.Length);
                result = Write_Byte(param.Addr, count * 2, data_byte);
            }
            return result;
        }


        private TModbus_Param Get_Param_PID_W2(ArrayList param_list)
        {
            TModbus_Param result = null;
            int base_addr = 0;
            int pid_no = 0;
            string param_name = "";
            string in_param_name = List_To_String(param_list);

            if (param_list.Count >= 3)
            {
                pid_no = Convert.ToInt32((string)param_list[1]);
                param_name = (string)param_list[2];
            }

            if (pid_no >= 0 && pid_no <= 7)
            {
                base_addr = 0x3500 + 0x0010 * pid_no;
                switch (param_name)
                {
                    case "比例帶": result = new TModbus_Param(in_param_name, base_addr + 0x0000, 0, emData_Size.Int16); break;
                    case "積分時間": result = new TModbus_Param(in_param_name, base_addr + 0x0001, 0, emData_Size.Int16); break;
                    case "微分時間": result = new TModbus_Param(in_param_name, base_addr + 0x0002, 0, emData_Size.Int16); break;
                    case "上限": result = new TModbus_Param(in_param_name, base_addr + 0x0003, 0, emData_Size.Int16); break;
                    case "下限": result = new TModbus_Param(in_param_name, base_addr + 0x0004, 0, emData_Size.Int16); break;
                    case "自動選擇上限": result = new TModbus_Param(in_param_name, base_addr + 0x0005, 0, emData_Size.Int16); break;
                    case "LBA檢測時間": result = new TModbus_Param(in_param_name, base_addr + 0x0007, 0, emData_Size.Int16); break;
                    case "比例帶-冷卻": result = new TModbus_Param(in_param_name, base_addr + 0x0008, 0, emData_Size.Int16); break;
                    case "積分時間-冷卻": result = new TModbus_Param(in_param_name, base_addr + 0x0009, 0, emData_Size.Int16); break;
                    case "微分時間-冷卻": result = new TModbus_Param(in_param_name, base_addr + 0x000A, 0, emData_Size.Int16); break;
                    case "死區": result = new TModbus_Param(in_param_name, base_addr + 0x000B, 0, emData_Size.Int16); break;
                    case "手動復歸值": result = new TModbus_Param(in_param_name, base_addr + 0x000C, 0, emData_Size.Int16); break;
                }
            }
            return result;
        }
        private TModbus_Param Get_Param_PID_W4(ArrayList param_list)
        {
            TModbus_Param result = null;
            int base_addr = 0;
            int pid_no = 0;
            string param_name = "";
            string in_param_name = List_To_String(param_list);

            if (param_list.Count >= 3)
            {
                pid_no = Convert.ToInt32((string)param_list[1]);
                param_name = (string)param_list[2];
            }

            if (pid_no >= 0 && pid_no <= 7)
            {
                base_addr = 0x1500 + 0x0020 * pid_no;
                switch (param_name)
                {
                    case "比例帶": result = new TModbus_Param(in_param_name, base_addr + 0x0000, 0, emData_Size.Int32); break;
                    case "積分時間": result = new TModbus_Param(in_param_name, base_addr + 0x0002, 0, emData_Size.Int32); break;
                    case "微分時間": result = new TModbus_Param(in_param_name, base_addr + 0x0004, 0, emData_Size.Int32); break;
                    case "上限": result = new TModbus_Param(in_param_name, base_addr + 0x0006, 0, emData_Size.Int32); break;
                    case "下限": result = new TModbus_Param(in_param_name, base_addr + 0x0008, 0, emData_Size.Int32); break;
                    case "自動選擇上限": result = new TModbus_Param(in_param_name, base_addr + 0x000A, 0, emData_Size.Int32); break;
                    case "LBA檢測時間": result = new TModbus_Param(in_param_name, base_addr + 0x000E, 0, emData_Size.Int32); break;
                    case "比例帶-冷卻": result = new TModbus_Param(in_param_name, base_addr + 0x0010, 0, emData_Size.Int32); break;
                    case "積分時間-冷卻": result = new TModbus_Param(in_param_name, base_addr + 0x0012, 0, emData_Size.Int32); break;
                    case "微分時間-冷卻": result = new TModbus_Param(in_param_name, base_addr + 0x0014, 0, emData_Size.Int32); break;
                    case "死區": result = new TModbus_Param(in_param_name, base_addr + 0x0016, 0, emData_Size.Int32); break;
                    case "手動復歸值": result = new TModbus_Param(in_param_name, base_addr + 0x0018, 0, emData_Size.Int32); break;
                }
            }
            return result;
        }
        private TModbus_Param Get_Param_Program_W2(ArrayList param_list)
        {
            TModbus_Param result = null;
            int base_addr = 0;
            int program_no = 0;
            int section_no = 0;
            string param_name1 = "";
            string param_name2 = "";
            string in_param_name = List_To_String(param_list);

            if (param_list.Count >= 5)
            {
                program_no = Convert.ToInt32((string)param_list[1]);
                param_name1 = (string)param_list[2];
                section_no = Convert.ToInt32((string)param_list[3]);
                param_name2 = (string)param_list[4];
            }
            if (program_no >= 0 && program_no <= 7 && param_name1 == "區段" && section_no >= 0 && section_no <= 31)
            {
                base_addr = 0x3900 + 0x0080 * program_no + 0x004 * section_no;
                switch (param_name2)
                {
                    case "格式": result = new TModbus_Param(in_param_name, base_addr + 0x0000, 0, emData_Size.Int16); break;
                    case "溫度": result = new TModbus_Param(in_param_name, base_addr + 0x0001, 0, emData_Size.Int16); break;
                    case "斜率": result = new TModbus_Param(in_param_name, base_addr + 0x0002, 0, emData_Size.Int16); break;
                    case "時間": result = new TModbus_Param(in_param_name, base_addr + 0x0003, 0, emData_Size.Int16); break;
                }
            }
            return result;
        }
        private TModbus_Param Get_Param_Program_W4(ArrayList param_list)
        {
            TModbus_Param result = null;
            int base_addr = 0;
            int program_no = 0;
            int section_no = 0;
            string param_name1 = "";
            string param_name2 = "";
            string in_param_name = List_To_String(param_list);

            if (param_list.Count >= 5)
            {
                program_no = Convert.ToInt32((string)param_list[1]);
                param_name1 = (string)param_list[2];
                section_no = Convert.ToInt32((string)param_list[3]);
                param_name2 = (string)param_list[4];
            }
            if (program_no >= 0 && program_no <= 7 && param_name1 == "區段" && section_no >= 0 && section_no <= 31)
            {
                base_addr = 0x1900 + 0x0100 * program_no + 0x008 * section_no;
                switch (param_name2)
                {
                    case "格式": result = new TModbus_Param(in_param_name, base_addr + 0x0000, 0, emData_Size.Int32); break;
                    case "溫度": result = new TModbus_Param(in_param_name, base_addr + 0x0002, 0, emData_Size.Int32); break;
                    case "斜率": result = new TModbus_Param(in_param_name, base_addr + 0x0004, 0, emData_Size.Int32); break;
                    case "時間": result = new TModbus_Param(in_param_name, base_addr + 0x0006, 0, emData_Size.Int32); break;
                }
            }
            return result;
        }
        private int Time_Int_To_Hex(int value)
        {
            int result = 0;
            int mm = value / 60;
            int ss = value % 60;
            string time = String_Tool.IntToTenStr(mm, 2) + String_Tool.IntToTenStr(ss, 2);
            result = String_Tool.HexStrToInt(time);
            return result;
        }
        private int Time_Hex_To_Int(int value)
        {
            int result = 0;
            string time = String_Tool.IntToHexStr(value, 4);
            int mm = String_Tool.TenStrToInt(time.Substring(0, 2));
            int ss = String_Tool.TenStrToInt(time.Substring(2, 2));
            result = mm * 60 + ss;
            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // 
    //-----------------------------------------------------------------------------------------------------   
    public class TE5CC : TModbus_Station_Base
    {
        public TE5CC(int station_no)
            : base(station_no)
        {
        }
        override public TModbus_Param Get_Param_W2(ArrayList param_list)
        {
            TModbus_Param result = null;
            string param_name = "";
            string in_param_name = List_To_String(param_list);

            param_name = (string)param_list[0];
            if (param_list.Count == 1)
            {
                switch (param_name)
                {
                    case "現在值": result = new TModbus_Param(in_param_name, 0x2000, 0, emData_Size.Int16); break;
                    case "狀態": result = new TModbus_Param(in_param_name, 0x2001, 0, emData_Size.Int16); break;
                    case "設定值": result = new TModbus_Param(in_param_name, 0x2002, 0, emData_Size.Int16); break;
                }
            }
            return result;
        }
        override public TModbus_Param Get_Param_W4(ArrayList param_list)
        {
            TModbus_Param result = null;
            string param_name = "";
            string in_param_name = List_To_String(param_list);

            param_name = (string)param_list[0];
            if (param_list.Count == 1)
            {
                switch (param_name)
                {
                    case "現在值": result = new TModbus_Param(in_param_name, 0x0000, 0, emData_Size.Int32); break;
                    case "狀態": result = new TModbus_Param(in_param_name, 0x0002, 0, emData_Size.Int32); break;
                    case "設定值": result = new TModbus_Param(in_param_name, 0x0004, 0, emData_Size.Int32); break;
                }
            }
            return result;
        }
    }

    public class TE5CCT_PID
    {
        public Int32 Proportion;
        public Int32 Integral;
        public Int32 Differential;
        public Int32 Limit_Up;
        public Int32 Limit_Dn;
        public Int32 Auto_Limit_Up;
        public Int32 LBA_Time;
        public Int32 Proportion_Cool;
        public Int32 Integral_Cool;
        public Int32 Differential_Cool;
        public Int32 Bad_Area;
        public Int32 Reset_Value;
    }
    public class TE5CCT_Program : TBase_Class, ITBase_Ini
    {
        public string FileName;
        public string Info;
        public string Default_Path;
        public string Default_FileName;

        public TE5CCT_Segment[] Segment = new TE5CCT_Segment[32];


        private int inSegment_Count = 1;

        public int Segment_Count
        {
            get
            {
                return inSegment_Count;
            }
            set
            {
                inSegment_Count = value;
                if (inSegment_Count < 1) inSegment_Count = 1;
                if (inSegment_Count > 32) inSegment_Count = 32;
            }
        }
        public TE5CCT_Program()
        {
            for (int i = 0; i < Segment.Length; i++) Segment[i] = new TE5CCT_Segment();
        }
        override public TBase_Class New_Class()
        {
            return new TE5CCT_Program();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TE5CCT_Program && dis_base is TE5CCT_Program)
            {
                TE5CCT_Program sor = (TE5CCT_Program)sor_base;
                TE5CCT_Program dis = (TE5CCT_Program)dis_base;

                dis.Segment_Count = sor.Segment_Count;
                for (int i = 0; i < sor.Segment.Length; i++) dis.Segment[i].Set(sor.Segment[i]);
            }
        }
        public void Set_Default()
        {
            Segment_Count = 1;
            for (int i = 0; i < Segment.Length; i++) Segment[i].Set_Default();
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result = true;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Write(ini, section);
            ini.Save_File();

            return result;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            Segment_Count = ini.ReadInteger(section, "Segment_Count", 1);
            for (int i = 0; i < Segment.Length; i++) Segment[i].Read(ini, section + "/Segment" + (i + 1).ToString());

            Read_Other_File();
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            ini.WriteInteger(section, "Segment_Count", Segment_Count);
            for (int i = 0; i < Segment.Length; i++) Segment[i].Write(ini, section + "/Segment" + (i + 1).ToString());


            Write_Other_File();
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TE5CCT_Program new_value, ref bool flag)
        {
            //log.Add("---------------------Recipe 差異---------------------");
            for (int i = 0; i < Segment.Length; i++)
                Segment[i].Log_Diff(log, section + "/Segment" + (i + 1).ToString(), new_value.Segment[i], ref flag);

            //log.Add("---------------------Recipe 差異---------------------");
        }
    }
    public class TE5CCT_Segment : TBase_Class, ITBase_Ini
    {
        public string FileName;
        public string Info;
        public string Default_Path;
        public string Default_FileName;
        
        public Int32 Type = 0;
        public Int32 Temp = 0;
        public Int32 Rate = 0;
        public Int32 Time = 0;

        override public TBase_Class New_Class()
        {
            return new TE5CCT_Segment();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TE5CCT_Segment && dis_base is TE5CCT_Segment)
            {
                TE5CCT_Segment sor = (TE5CCT_Segment)sor_base;
                TE5CCT_Segment dis = (TE5CCT_Segment)dis_base;

                dis.Type = sor.Type;
                dis.Temp = sor.Temp;
                dis.Rate = sor.Rate;
                dis.Time = sor.Time;
            }
        }
        public void Set_Default()
        {
            Type = 0;
            Temp = 0;
            Rate = 0;
            Time = 0;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result = true;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = Default_Path + Default_FileName;
            else
                FileName = filename;
            ini = new TJJS_XML_File(FileName);
            Write(ini, section);
            ini.Save_File();

            return result;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            Type = ini.ReadInteger(section ,"Type", 0);
            Temp = ini.ReadInteger(section, "Temp", 0);
            Rate = ini.ReadInteger(section, "Rate", 0);
            Time = ini.ReadInteger(section, "Time", 0);
            Read_Other_File();
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            ini.WriteInteger(section ,"Type", Type);
            ini.WriteInteger(section, "Temp", Temp);
            ini.WriteInteger(section, "Rate", Rate);
            ini.WriteInteger(section, "Time", Time);
            Write_Other_File();
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TE5CCT_Segment new_value, ref bool flag)
        {
            //log.Add("---------------------Recipe 差異---------------------");

            log.Log_Diff(section + "/Type", Type, new_value.Type, ref flag);
            log.Log_Diff(section + "/Temp", Temp, new_value.Temp, ref flag);
            log.Log_Diff(section + "/Rate", Rate, new_value.Rate, ref flag);
            log.Log_Diff(section + "/Time", Time, new_value.Time, ref flag);

            //log.Add("---------------------Recipe 差異---------------------");
        }
    }
}
