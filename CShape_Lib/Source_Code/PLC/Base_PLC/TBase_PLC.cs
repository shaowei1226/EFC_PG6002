using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EFC.Tool;
using System.Windows.Forms;


namespace EFC.PLC
{
    public enum emDevice_Type { emNone = 0, emBit, emWord};
    public enum emDevice_Num_Type { emNone = 0, emBin = 2, emEight = 8, emTen = 10, emHex = 16 };
    public enum emDevice_Info_Type { emNone = 0, emBit, emWord };
    public delegate void evPLC_Thread_Run(string name, PLC_Thread thread);
    public delegate void evPLC_No_Thread_Run(string thread_name);

    abstract public class TBase_PLC
    {
        public TBase_Device_Tool           Device_Tool = null;
        public string                      PLC_Name = "";
        public bool                        Terminate = false;
        public TPLC_Command_List           Command_List = new TPLC_Command_List();
        public TLog                        Log = null;

        protected bool                     FBusy = false;

        protected System.Timers.Timer      Reconnect_Timer = new System.Timers.Timer();
        protected bool                     in_Auto_Reconnect = true;

        protected bool                     FOn_TimeOut = false;
        protected System.Timers.Timer      Timout_Timer = new System.Timers.Timer();

        protected Thread                   in_Thread = null;
        protected int                      Write_Count = 0;
        protected byte[]                   Write_Buffer = new byte[40000];
        protected int                      Read_Count = 0;
        protected byte[]                   Read_Buffer = new byte[40000];


        public TBase_PLC()
        {
            FBusy = false;
            FOn_TimeOut = false;

            in_Thread = new Thread(Execute);
            in_Thread.IsBackground = true;
            in_Thread.Start();

            //Reconnect_Timer
            Reconnect_Timer.Enabled = false;
            Reconnect_Timer.Interval = 5000;
            Reconnect_Timer.Elapsed += On_Reconnect_PLC;

            //Timer1
            Timout_Timer.Enabled = false;
            Timout_Timer.Interval = 500;
            Timout_Timer.Elapsed += On_TimeOut;

        }
        public bool Connect
        {
            get
            {
                return Get_Connect();
            }
            set
            {
                Set_Connect(value);
            }
        }
        public bool Auto_Reconnect
        {
            get
            {
                return in_Auto_Reconnect;
            }
            set
            {
                in_Auto_Reconnect = value;
            }
        }
        public double Reconnect_Time
        {
            get
            {
                return Reconnect_Timer.Interval;
            }
            set
            {
                Reconnect_Timer.Interval = value;
            }
        }
        public double Timeout_Time
        {
            get
            {
                return Timout_Timer.Interval;
            }
            set
            {
                Timout_Timer.Interval = value;
            }
        }
        public void Execute()
        {
            bool old_connect = Connect;

            while (!Terminate)
            {
                if (Command_List.Count > 0)
                {
                    if (!Command_List.Lock)
                    {
                        Run_Command(Command_List[0]);
                        Command_List.RemoveAt(0);
                    }
                }

                if (!old_connect && Connect) Log_Add("[Base_PLC] Connect.");
                if (old_connect && !Connect) Log_Add("[Base_PLC] Disconnect.");
 
                if (!Connect && !Reconnect_Timer.Enabled && in_Auto_Reconnect) Reconnect_Timer.Enabled = true;
                if (Reconnect_Timer.Enabled && Connect) Reconnect_Timer.Enabled = false;

                old_connect = Connect;
                System.Threading.Thread.Sleep(1);
            }
        }
        private void On_TimeOut(object sender, EventArgs e)
        {
            Timout_Timer.Enabled = false;
            FOn_TimeOut = true;
        }
        private void On_Reconnect_PLC(object sender, EventArgs e)
        {
            Reconnect_Timer.Enabled = false;
            Log_Add("[Base_PLC] 嘗試重新連線 PLC.");
            Connect = true;
            Thread.Sleep(1000);
        }
        public void Log_Add(string msg)
        {
            if (Log != null && Log.Enabled) Log.Add(msg);
        }
        public void Log_Add(byte[] data, int data_len)
        {
            Log_Add(Byte_To_String(data, data_len));
        }
        public void Log_Add(string str, byte[] data, int data_len)
        {
            Log_Add(str + Byte_To_String(data, data_len));
        }
        public string Byte_To_String(byte[] data, int data_len)
        {
            string result = "";

            for (int i = 0; i < data_len; i++)
            {
                if (result != "") result = result + " ";
                result = result + String_Tool.IntToHexStr(data[i], 2);
            }

            return result;
        }

        public bool PLC_Read_Byte(ref byte[] data, ref int data_len)
        {
            bool result = Read_Byte(ref data, ref data_len);
            Log_Add("Read=", data, data_len);
            return result;
        }
        public bool PLC_Write_Byte(byte[] data, int data_len)
        {
            Log_Add("Write=",data, data_len);
            bool result = Write_Byte(data, data_len);
            return result;
        }
        public bool PLC_Read_String(ref string data)
        {
            bool result = Read_String(ref data);
            Log_Add("Read=" + data);
            return result;
        }
        public bool PLC_Write_String(string data)
        {
            Log_Add("Write=" + data);
            bool result = Write_String(data);
            return result;
        }
        abstract public bool Read_Byte(ref byte[] data, ref int data_len);
        abstract public bool Write_Byte(byte[] data, int data_len);
        abstract public bool Read_String(ref string str);
        abstract public bool Write_String(string str);


        protected void Reset(ref byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++) buffer[i] = 0;
        }
        protected void Run_Command(TPLC_Command cmd)
        {
            Reset(ref Write_Buffer);
            Reset(ref Read_Buffer);
            if (cmd != null)
            {
                switch (cmd.Command)
                {
                    case "Read_Bit": Run_Command_Read_Bit(cmd); break;
                    case "Write_Bit": Run_Command_Write_Bit(cmd); break;
                    case "Read_Byte": Run_Command_Read_Byte(cmd); break;
                    case "Write_Byte": Run_Command_Write_Byte(cmd); break;
                    case "Random_Read_Byte": Run_Command_Random_Read_Byte(cmd); break;
                    case "Random_Write_Byte": Run_Command_Random_Write_Byte(cmd); break;
                    case "Random_Read_Bit": Run_Command_Random_Read_Bit(cmd); break;
                    case "Random_Write_Bit": Run_Command_Random_Write_Bit(cmd); break;
                }
            }
        }
        private bool Add_Command(TPLC_Command cmd)
        {
            while (FBusy) { Thread.Sleep(1); };
            FBusy = true;
            Command_List.Add(cmd);
            while (!cmd.Finish) { Thread.Sleep(1); };
            FBusy = false;
            return cmd.Result;
        }
        



        virtual public void Bool_To_Byte(bool[] in_data, int in_index, ref byte[] out_data, int out_index, int count)
        {
            int byte_no, bit_no;
            byte tmp_byte;

            for (int i = 0; i < count; i++)
            {
                byte_no = i / 2;
                bit_no = i % 2;
                tmp_byte = out_data[byte_no + out_index];
                if (bit_no == 0 && in_data[i + in_index])
                    tmp_byte = (byte)(tmp_byte | 0x10);
                else
                    tmp_byte = (byte)(tmp_byte & 0xEF);

                if (bit_no == 1 && in_data[i + in_index])
                    tmp_byte = (byte)(tmp_byte | 0x01);
                else
                    tmp_byte = (byte)(tmp_byte & 0xFE);

                out_data[byte_no + out_index] = tmp_byte;

            }
        }
        virtual public void Byte_To_Bool(byte[] in_data, int in_index, ref bool[] out_data, int out_index, int count)
        {
            int byte_no, bit_no;

            for (int i = 0; i < count; i++)
            {
                byte_no = i / 2;
                bit_no = i % 2;
                if (bit_no == 0) out_data[i + out_index] = ((in_data[byte_no + in_index] & 0xF0) == 0x10);
                if (bit_no == 1) out_data[i + out_index] = ((in_data[byte_no + in_index] & 0x0F) == 0x01);
            }
        }
        virtual public void UShort_To_Byte(ushort[] in_data, int in_index, ref byte[] out_data, int out_index, int ushort_count)
        {
            for (int i = 0; i < ushort_count; i++)
            {
                Array.Copy(BitConverter.GetBytes(in_data[i + in_index]), 0, out_data, i * 2 + out_index, 2);
            }
        }
        virtual public void Byte_To_UShort(byte[] in_data, int in_index, ref ushort[] out_data, int out_index, int ushort_count)
        {
            if (in_data.Length >= (in_index + ushort_count))
            {
                for (int i = 0; i < ushort_count; i++)
                {
                    out_data[i + out_index] = BitConverter.ToUInt16(in_data, i * 2 + in_index);
                }
            }
        }


        public bool Read_Bit(string start_code, ref bool read_data)
        {
            bool result = false;
            bool[] tmp_data = new bool[1];
            
            result = Read_Bit(start_code, ref tmp_data, 1);
            read_data = tmp_data[0];
            return result;
        }
        public bool Read_Bit(string start_code, ref bool[] read_data, int in_count)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Read_Bit";
            cmd.Set_Param(start_code, in_count);
            cmd.Set_Data(read_data);

            result = Add_Command(cmd);
            if (result) cmd.Get_Data(ref read_data);
            return result;
        }
        public bool Write_Bit(string start_code, bool write_data)
        {
            bool result = false;
            bool[] tmp_data = new bool[1];

            tmp_data[0] = write_data;
            result = Write_Bit(start_code, tmp_data, 1);
            return result;
        }
        public bool Write_Bit(string start_code, bool[] write_data, int in_count)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Write_Bit";
            cmd.Set_Param(start_code, in_count);
            cmd.Set_Data(write_data);

            result = Add_Command(cmd);
            return result;
        }
        public bool Read_Byte(string start_code, ref ushort read_data)
        {
            bool result = false;
            ushort[] tmp_data = new ushort[1];

            result = Read_Byte(start_code, ref tmp_data, 1);
            read_data = tmp_data[0];
            return result;
        }
        public bool Read_Byte(string start_code, ref ushort[] read_data, int in_count)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Read_Byte";
            cmd.Set_Param(start_code, in_count);
            cmd.Set_Data(read_data);

            result = Add_Command(cmd);
            if (result) cmd.Get_Data(ref read_data);
            return result;
        }
        public bool Read_Byte(TPLC_Base_Data data)
        {
            bool result = true;

            result = Read_Byte(data.Start_Code, ref data.Data, data.Count);
            return result;
        }
        public bool Write_Byte(string start_code, ushort write_data)
        {
            bool result = false;
            ushort[] tmp_data = new ushort[1];

            tmp_data[0] = write_data;
            result = Write_Byte(start_code, tmp_data, 1);
            return result;
        }
        public bool Write_Byte(string start_code, ushort[] write_data, int in_count)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Write_Byte";
            cmd.Set_Param(start_code, in_count);
            cmd.Set_Data(write_data);

            result = Add_Command(cmd);
            return result;
        }
        public bool Write_Byte(TPLC_Base_Data data)
        {
            bool result = true;

            result = Write_Byte(data.Start_Code, data.Data, data.Count);
            return result;
        }
        public bool Random_Read_Byte(string[] device_list, ref ushort[] read_data)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Random_Read_Byte";
            cmd.Set_Param(device_list);
            cmd.Set_Data(read_data);

            result = Add_Command(cmd);
            if (result) cmd.Get_Data(ref read_data);
            return result;
        }
        public bool Random_Write_Byte(string[] device_list, ushort[] write_data)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Random_Write_Byte";
            cmd.Set_Param(device_list);
            cmd.Set_Data(write_data);

            result = Add_Command(cmd);
            return result;
        }
        public bool Random_Read_Bit(string[] device_list, ref bool[] read_data)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Random_Read_Bit";
            cmd.Set_Param(device_list);
            cmd.Set_Data(read_data);

            result = Add_Command(cmd);
            if (result) cmd.Get_Data(ref read_data);
            return result;
        }
        public bool Random_Write_Bit(string[] device_list, bool[] write_data)
        {
            bool result = false;
            TPLC_Command cmd = new TPLC_Command();

            cmd.Command = "Random_Write_Bit";
            cmd.Set_Param(device_list);
            cmd.Set_Data(write_data);

            result = Add_Command(cmd);
            return result;
        }
        public bool Read_Device_List(ref TBase_Device_List list)
        {
            bool result = true;
            string[] device_list = new string[0];
            ushort[] read_byte = new ushort[0];
            bool[] read_bit = new bool[0];

            list.Get_List_Word(ref device_list, ref read_byte);
            if (device_list.Length > 0)
            {
                if (!Random_Read_Byte(device_list, ref read_byte)) result = false;
                else
                {
                    list.Set_List_Word(device_list, read_byte);
                }
            }

            list.Get_List_Bit(ref device_list, ref read_bit);
            if (device_list.Length > 0)
            {
                for (int i = 0; i < device_list.Length; i++)
                {
                    bool[] tmp_data = new bool[16];
                    if (Read_Bit((string)device_list[i], ref tmp_data, 1))
                    {
                        read_bit[i] = tmp_data[0];
                    }
                    else result = false;

                }
                if (result) list.Set_List_Bit(device_list, read_bit);
            }

            return result;
        }
        public bool Write_Device_List(TBase_Device_List list)
        {
            bool result = true;
            string[] device_list = new string[0];
            ushort[] write_byte = new ushort[0];
            bool[] write_bit = new bool[0];

            list.Get_List_Word(ref device_list, ref write_byte);
            if (!Random_Write_Byte(device_list, write_byte)) result = false;

            list.Get_List_Bit(ref device_list, ref write_bit);
            if (!Random_Write_Bit(device_list, write_bit)) result = false;

            return result;
        }


        abstract protected bool Get_Connect();
        abstract protected void Set_Connect(bool value);
        abstract protected void Run_Command_Read_Bit(TPLC_Command cmd);
        abstract protected void Run_Command_Write_Bit(TPLC_Command cmd);
        abstract protected void Run_Command_Read_Byte(TPLC_Command cmd);
        abstract protected void Run_Command_Write_Byte(TPLC_Command cmd);
        abstract protected void Run_Command_Random_Read_Byte(TPLC_Command cmd);
        abstract protected void Run_Command_Random_Write_Byte(TPLC_Command cmd);
        abstract protected void Run_Command_Random_Read_Bit(TPLC_Command cmd);
        abstract protected void Run_Command_Random_Write_Bit(TPLC_Command cmd);
    }
    public class TBase_PLC_Req
    {
        public bool Req = false;
        public bool OK = false;
        public bool Finish = false;
        public bool Runing = false;

        public TBase_PLC_Req()
        { 
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //PLC 命令資料結構
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Command : TBase_Class
    {
        public string Command = "";
        public ArrayList Param = new ArrayList();
        public bool Finish = false;
        public bool Result = false;
        public ArrayList Data = new ArrayList();

        public TPLC_Command()
        {

        }
        public TPLC_Command(string cmd, ArrayList param, ArrayList data)
        {
            Reset();
            Set(cmd, param, data);
        }
        override public TBase_Class New_Class()
        {
            return new TPLC_Command();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TPLC_Command && dis_base is TPLC_Command)
            {
                TPLC_Command sor = (TPLC_Command)sor_base;
                TPLC_Command dis = (TPLC_Command)dis_base;

                dis.Command = sor.Command;
                dis.Param = (ArrayList)sor.Param.Clone();
                dis.Finish = sor.Finish;
                dis.Result = sor.Result;
                dis.Data = sor.Data;
            }
        }

        public void Set(string cmd, ArrayList param, ArrayList data)
        {
            Command = cmd;
            Param = (ArrayList)param.Clone();
            Data = (ArrayList)data.Clone();
        }
        public void Reset()
        {
            Finish = false;
            Result = false;
        }


        public bool Get_Param(ref string[] param)
        {
            bool result = false;
            if (Param.Count >= 1)
            {
                ArrayList_To_String(Param, ref param);
                result = true;
            }
            return result;
        }
        public bool Get_Param(ref string start_code, ref int count)
        {
            bool result = false;
            if (Param.Count >= 2)
            {
                start_code = (string)Param[0];
                count = (int)Param[1];
                result = true;
            }
            return result;
        }
        public void Set_Param(string[] param)
        {
            String_To_ArrayList(param, ref Param);
        }
        public void Set_Param(string start_code, int count)
        {
            Param.Clear();
            Param.Add(start_code);
            Param.Add(count);
        }

        public void Set_Data(bool[] data)
        {
            Bool_To_ArrayList(data, ref Data);
        }
        public void Set_Data(ushort[] data)
        {
            Ushort_To_ArrayList(data, ref Data);
        }
        public bool Get_Data(ref bool[] data)
        {
            bool result = false;

            ArrayList_To_Bool(Data, ref data);
            result = true;
            return result;
        }
        public bool Get_Data(ref ushort[] data)
        {
            bool result = false;

            ArrayList_To_Ushort(Data, ref data);
            result = true;
            return result;
        }

        protected void ArrayList_To_Bool(ArrayList list, ref bool[] data, bool resize = true)
        {
            if (resize) Array.Resize(ref data, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                if (i < data.Length)
                    data[i] = (bool)list[i];
            }
        }
        protected void ArrayList_To_Ushort(ArrayList list, ref ushort[] data, bool resize = true)
        {
            if (resize) Array.Resize(ref data, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                if (i < data.Length)
                    data[i] = (ushort)list[i];
            }
        }
        protected void ArrayList_To_String(ArrayList list, ref string[] data, bool resize = true)
        {
            if (resize) Array.Resize(ref data, list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                if (i < data.Length)
                    data[i] = (string)list[i];
            }
        }


        protected void Bool_To_ArrayList(bool[] data, ref ArrayList list, bool resize = true)
        {
            if (resize) list.Clear();
            for (int i = 0; i < data.Length; i++)
            {
                if (resize)
                {
                    list.Add(data[i]);
                }
                else if (i < list.Count)
                {
                    list[i] = data[i];
                }
            }
        }
        protected void Ushort_To_ArrayList(ushort[] data, ref ArrayList list, bool resize = true)
        {
            if (resize) list.Clear();
            for (int i = 0; i < data.Length; i++)
            {
                if (resize)
                {
                    list.Add(data[i]);
                }
                else if (i < list.Count)
                {
                    list[i] = data[i];
                }
            }
        }
        protected void String_To_ArrayList(string[] data, ref ArrayList list, bool resize = true)
        {
            if (resize) list.Clear();
            for (int i = 0; i < data.Length; i++)
            {
                if (resize)
                {
                    list.Add(data[i]);
                }
                else if (i < list.Count)
                {
                    list[i] = data[i];
                }
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //PLC 命令資料串列
    //-----------------------------------------------------------------------------------------------------
    public class TPLC_Command_List 
    {
        public bool Lock = false;
        private TPLC_Command[] List = new TPLC_Command[0];

        public int Count
        {
            get
            {
                return List.Length;
            }
            set
            {
                int old_count;

                old_count = List.Length;
                Array.Resize(ref List, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        List[i] = new TPLC_Command();
                }
            }
        }
        public TPLC_Command_List()
        {

        }
        public TPLC_Command this[int index]
        {
            get
            {
                TPLC_Command result = null;
                if (index >= 0 && index < Count) result = (TPLC_Command)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    List[index] = value;
                }
            }
        }
        public void Add(TPLC_Command cmd)
        {
            Wait_On_Lock();
            Lock = true;
            Count++;
            if (cmd != null) List[Count-1] = cmd;
            Lock = false;
        }
        public void RemoveAt(int no)
        {
            if (no >= 0 && no < Count)
            {
                Wait_On_Lock();
                Lock = true;
                for (int i = no; i < Count - 1; i++)
                {
                    List[i] = List[i + 1];
                }
                Count--;
                Lock = false;
            }
        }
        public void Wait_On_Lock()
        {
            while (Lock) { System.Windows.Forms.Application.DoEvents(); Thread.Sleep(1); };
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號相關功能
    //-----------------------------------------------------------------------------------------------------
    public class TBase_Device_Tool
    {
        public ArrayList Code_List_Bit = new ArrayList();
        public ArrayList Code_List_Word = new ArrayList();
        public ArrayList Code_List_All = new ArrayList();
        public int Device_Code_Count = 6;

        public TBase_Device_Tool()
        {

        }
        public bool Is_Code(string code)
        {
            bool result = false;

            if (Code_List_All.IndexOf(code.ToUpper()) >= 0) result = true;
            return result;
        }
        public bool Is_Code_Bit(string code)
        {
            bool result = false;

            if (Code_List_Bit.IndexOf(code.ToUpper()) >= 0) result = true;
            return result;
        }
        public bool Is_Code_Word(string code)
        {
            bool result = false;

            if (Code_List_Word.IndexOf(code.ToUpper()) >= 0) result = true;
            return result;
        }

        public int Str_To_Int(string device_num_str, emDevice_Num_Type type = emDevice_Num_Type.emTen)
        {
            int result = 0;
            try
            {
                switch (type)
                {
                    case emDevice_Num_Type.emBin: result = String_Tool.BinStrToInt(device_num_str); break;
                    case emDevice_Num_Type.emEight: result = String_Tool.EightStrToInt(device_num_str); break;
                    case emDevice_Num_Type.emTen: result = Convert.ToInt32(device_num_str); break;
                    case emDevice_Num_Type.emHex: result = String_Tool.HexStrToInt(device_num_str); break;
                }
            }
            catch{}
            return result;
        }
        public string Int_To_Str(int num, emDevice_Num_Type type = emDevice_Num_Type.emTen)
        {
            string result = "";
            uint count = (uint)Device_Code_Count;

            switch (type)
            {
                case emDevice_Num_Type.emBin: result = String_Tool.IntToBinStr(num, count); break;
                case emDevice_Num_Type.emEight: result = String_Tool.IntToEightStr(num, count); break;
                case emDevice_Num_Type.emTen: result = String_Tool.IntToTenStr(num, count); break;
                case emDevice_Num_Type.emHex: result = String_Tool.IntToHexStr(num, count); break;
            }
            return result;
        }
        public string Generate_Device(string device)
        {
            return Generate_Device(device, 0);
        }
        public string Generate_Device(string device, int ofs)
        {
            string result = "";
            string code = "";
            int num = 0;

            if (Break_Device(device, ref code, ref num))
            {
                result = Generate_Device_Code(code, num + ofs);
            }
            return result;
        }
        public string Generate_Device_Code(string code, int num)
        {
            string result = "";

            result = code + Int_To_Str(num, Get_Device_Num_Type(code));
            return result;
        }


        virtual public emDevice_Type Get_Device_Type(string device)
        {
            return emDevice_Type.emNone;
        }
        virtual public emDevice_Num_Type Get_Device_Num_Type(string device)
        {
            return emDevice_Num_Type.emNone;
        }
        virtual public bool Break_Device(string device, ref string code, ref int num)
        {
            return false;
        }
        virtual public TBase_Device_Info New_Device()
        {
            return null;
        }
        virtual public TBase_Device_List New_Device_List()
        {
            return null;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號儲存結構
    //-----------------------------------------------------------------------------------------------------
    public abstract class TBase_Device_Info
    {
        public TBase_Device_Tool Device_Tool = null;
        protected string in_Code = "X";
        protected int in_Number = 0;
        protected emDevice_Info_Type in_Info_Type = emDevice_Info_Type.emNone;
        protected emDevice_Num_Type in_Device_Num_Type = emDevice_Num_Type.emNone;
        protected int in_Dot_Num = 0;
        public ushort[] Data = new ushort[0];


        public TBase_Device_Info()
        {
        }
        public TBase_Device_Info(string device)
        {
            Set(device);
        }
        public TBase_Device_Info(string device, emDevice_Info_Type type)
        {
            Set(device, type);
        }
        public TBase_Device_Info(string code, int number, emDevice_Info_Type type)
        {
            Set(code, number, type);
        }
    
        public void Set(emDevice_Info_Type info_type)
        {
            Info_Type = info_type;
        }
        public void Set(string device)
        {
            Set_Device_Name(device);
        }
        public void Set(string device, emDevice_Info_Type type)
        {
            Set_Device_Name(device, type);
        }
        public void Set(string code, int number, emDevice_Info_Type type)
        {
            Info_Type = type;
            Code = code;
            in_Number = number;
        }

        public TBase_Device_Info Copy()
        {
            TBase_Device_Info result = Device_Tool.New_Device();
            Copy(this, ref result);
            return result;
        }
        public void Copy(ref TBase_Device_Info dis)
        {
            Copy(this, ref dis);
        }
        public void Copy(TBase_Device_Info sor, ref TBase_Device_Info dis)
        {
            dis.Device_Tool = sor.Device_Tool;
            dis.in_Code = sor.in_Code;
            dis.in_Number = sor.in_Number;
            dis.in_Info_Type = sor.in_Info_Type;
            dis.in_Device_Num_Type = sor.in_Device_Num_Type;
            dis.Data_Count = sor.Data_Count;
            for (int i = 0; i < sor.Data.Length; i++) dis.Data[i] = sor.Data[i];
        }


        public emDevice_Info_Type Info_Type
        {
            get
            {
                return in_Info_Type;
            }
            set
            {
                in_Info_Type = value;
                switch (in_Info_Type)
                {
                    case emDevice_Info_Type.emBit: Data_Count = 1; break;
                    case emDevice_Info_Type.emWord: Data_Count = 1; break;
                }
            }
        }
        public string Code
        {
            get
            {
                return in_Code;
            }
            set
            {
                if (Device_Tool.Is_Code(value))
                {
                    in_Code = value;
                    in_Device_Num_Type = Device_Tool.Get_Device_Num_Type(in_Code);
                }
            }
        }
        public int Number
        {
            get
            {
                return in_Number;
            }
            set
            {
                in_Number = value;
            }
        }
        public int Data_Count
        {
            get
            {
                return Data.Length;
            }
            set
            {
                int old_count = Data.Length;
                Array.Resize(ref Data, value);
                for (int i = old_count; i < value; i++)
                {
                    //Data[i] = new ushort;
                }
            }
        }
        public string Device_Name
        {
            get
            {
                return Get_Device_Name();
            }
            set
            {
                Set_Device_Name(value);
            }
        }
        public bool Bit
        {
            get
            {
                return Get_Bit();
            }
            set
            {
                Set_Bit(value);
            }
        }
        public int Word
        {
            get
            {
                return Get_Word();
            }
            set
            {
                Set_Word(value);
            }
        }
        public double Double_Word
        {
            get
            {
                return Get_Word(in_Dot_Num);
            }
            set
            {
                Set_Word(in_Dot_Num, value);
            }
        }

        public string Get_Device_Name()
        {
            string result = "";
            result = Device_Tool.Generate_Device_Code(in_Code, in_Number);
            return result;
        }
        public void Set_Device_Name(string device)
        {
            string code = "";
            int number = 0;
            if (Device_Tool.Break_Device(device, ref code, ref number))
            {
                Code = code;
                in_Number = number;
                if (Device_Tool.Is_Code_Bit(Code)) Info_Type = emDevice_Info_Type.emBit;
                if (Device_Tool.Is_Code_Word(Code)) Info_Type = emDevice_Info_Type.emWord;
            }
        }
        public void Set_Device_Name(string device, emDevice_Info_Type info_type)
        {
            string code = "";
            int number = 0;
            if (Device_Tool.Break_Device(device, ref code, ref number))
            {
                Code = code;
                in_Number = number;
                Info_Type = info_type;
            }
        }
        public void Set_Bit(bool value)
        {
            switch (in_Info_Type)
            {
                case emDevice_Info_Type.emNone: break;
                case emDevice_Info_Type.emBit: PLC_Data_Tool.Set_Bit(Data, 0, 0, value); break;
                case emDevice_Info_Type.emWord: PLC_Data_Tool.Set_Bit(Data, 0, 0, value); break;
            }
        }
        public void Set_Word(int value)
        {
            switch (in_Info_Type)
            {
                case emDevice_Info_Type.emNone: break;
                case emDevice_Info_Type.emBit: break;
                case emDevice_Info_Type.emWord: PLC_Data_Tool.Set_Word(Data, 0, value); break;
            }
        }
        public void Set_Word(int dot_num, double value)
        {
            in_Dot_Num = dot_num;
            switch (in_Info_Type)
            {
                case emDevice_Info_Type.emNone: break;
                case emDevice_Info_Type.emBit: break;
                case emDevice_Info_Type.emWord: PLC_Data_Tool.Set_Word(Data, 0, dot_num, value); break;
            }
        }

        public bool Get_Bit()
        {
            bool result = false;
            
            switch (in_Info_Type)
            {
                case emDevice_Info_Type.emNone: break;
                case emDevice_Info_Type.emBit: result = PLC_Data_Tool.Get_Bit(Data, 0, 0); break;
                case emDevice_Info_Type.emWord: result = PLC_Data_Tool.Get_Bit(Data, 0, 0); break;
            }
            return result;
        }
        public int Get_Word()
        {
            int result = 0;
            switch (in_Info_Type)
            {
                case emDevice_Info_Type.emNone: break;
                case emDevice_Info_Type.emBit: break;
                case emDevice_Info_Type.emWord: result = PLC_Data_Tool.Get_Word(Data, 0); break;
            }
            return result;
        }
        public double Get_Word(int dot_num)
        {
            double result = 0;
            switch (in_Info_Type)
            {
                case emDevice_Info_Type.emNone: break;
                case emDevice_Info_Type.emBit: break;
                case emDevice_Info_Type.emWord: result = PLC_Data_Tool.Get_Word(Data, 0, dot_num); break;
            }
            return result;
        }
     }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 符號串列儲存結構
    //-----------------------------------------------------------------------------------------------------
    public abstract class TBase_Device_List
    {
        public TBase_Device_Info[] Devices = new TBase_Device_Info[0];
        public TBase_Device_Tool Device_Tool = null;

        public TBase_Device_List()
        {

        }
        public void Copy(TBase_Device_List sor, TBase_Device_List dis)
        {
            dis.Devices_Count = sor.Devices_Count;
            for (int i = 0; i < sor.Devices_Count; i++) dis.Devices[i] = sor.Devices[i].Copy();
            dis.Device_Tool = sor.Device_Tool;
        }
        public void Copy(TBase_Device_List dis)
        {
            Copy(this, dis);
        }
        public TBase_Device_List Copy()
        {
            TBase_Device_List result = Device_Tool.New_Device_List();
            Copy(this, result);
            return result;
        }
        public int Devices_Count
        {
            get
            {
                return Devices.Length;
            }
            set
            {
                int old_count;

                old_count = Devices.Length;
                Array.Resize(ref Devices, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Devices[i] = Device_Tool.New_Device();
                }
            }
        }
        public void Clear()
        {
            Array.Resize(ref Devices, 0);
        }
        public int Get_Device_Index(string device_name)
        {
            int result = -1;

            TBase_Device_Info tmp_device = Device_Tool.New_Device();
            tmp_device.Set(device_name);
            for (int i = 0; i < Devices_Count; i++)
            {
                if (tmp_device.Device_Name == Devices[i].Device_Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public TBase_Device_Info Get_Device(string device_name)
        {
            return Get_Device(device_name, 0);
        }
        public TBase_Device_Info Get_Device(string device_name, int ofs)
        {
            TBase_Device_Info result = null;
            int no;

            no = Get_Device_Index(Device_Tool.Generate_Device(device_name, ofs));
            if (no >= 0) result = Devices[no];
            return result;
        }
        public void Add(TBase_Device_Info device)
        {
            int index = -1;

            index = Get_Device_Index(device.Device_Name);
            if (index >= 0)
            {
                Devices[index] = device.Copy();
            }
            else
            {
                Devices_Count = Devices_Count + 1;
                Devices[Devices_Count - 1] = device.Copy();
            }
        }
        public void Add(string device_name)
        {
            TBase_Device_Info device = Device_Tool.New_Device();
            device.Set(device_name);
            Add(device);
        }
        public void Add_Bit(string device_name, bool value = false)
        {
            TBase_Device_Info device = Device_Tool.New_Device();

            device.Set(device_name, emDevice_Info_Type.emBit);
            device.Set_Bit(value);
            Add(device);
        }
        public void Add_Word(string device_name, int value = 0)
        {
            TBase_Device_Info device = Device_Tool.New_Device();

            device.Set(device_name, emDevice_Info_Type.emWord);
            device.Set_Word(value);
            Add(device);
        }
        public void Add_Word(string device_name, int dot_num, double value)
        {
            TBase_Device_Info device = Device_Tool.New_Device();

            device.Set(device_name, emDevice_Info_Type.emWord);
            device.Set_Word(dot_num, value);
            Add(device);
        }
        public void Add_DWord(string device_name, int value = 0)
        {
            TBase_Device_Info device = Device_Tool.New_Device();
            ushort[] data = new ushort[4];

            PLC_Data_Tool.Set_DWord(data, 0, value);

            device.Set(device_name, emDevice_Info_Type.emWord);
            device.Set_Word(PLC_Data_Tool.Get_Word(data, 0));
            Add(device);

            device.Set(Device_Tool.Generate_Device(device_name, 1), emDevice_Info_Type.emWord);
            device.Set_Word(PLC_Data_Tool.Get_Word(data, 1));
            Add(device);
        }
        public void Add_DWord(string device_name, int dot_num, double value)
        {
            int new_value = (int)(Math.Round(value * Math.Pow(10, dot_num)));
            Add_DWord(device_name, new_value);
        }
        public void Add(TBase_Device_List list)
        {
            for (int i = 0; i < list.Devices_Count; i++) Add(list.Devices[i]);
        }
        public void Delete(int index)
        {
            if (index < Devices_Count)
            {
                for (int i = index; i < Devices_Count - 1; i++)
                {
                    Devices[i] = Devices[i + 1].Copy();
                }
                Devices_Count = Devices_Count - 1;
            }
        }
        public void Delete(string device_name)
        {
            Delete(Get_Device_Index(device_name));
        }

        public bool[] Get_Data_Bit_List(string device_name, int count)
        {
            bool[] result = null;
            bool flag = true;

            TBase_Device_Info[] device = new TBase_Device_Info[count];
            for (int i = 0; i < count; i++)
            {
                device[i] = Get_Device(device_name, i);
                if (device[i] == null) flag = false;
            }

            if (flag)
            {
                result = new bool[count];
                for (int i = 0; i < count; i++) result[i] = device[i].Get_Bit();
            }
            return result;
        }
        public bool Get_Data_Bit(string device_name)
        {
            bool result = false;
            bool[] data_b = Get_Data_Bit_List(device_name, 1);
            if (data_b != null) result = data_b[0];
            return result;
        }

        public ushort[] Get_Data_Word_List(string device_name, int count)
        {
            ushort[] result = null;
            bool flag = true;

            TBase_Device_Info[] device = new TBase_Device_Info[count];
            for (int i = 0; i < count; i++)
            {
                device[i] = Get_Device(device_name, i);
                if (device[i] == null) flag = false;
            }

            if (flag)
            {
                result = new ushort[count];
                for (int i = 0; i < count; i++) result[i] = device[i].Data[0];
            }
            return result;
        }
        public int Get_Data_Word(string device_name)
        {
            int result = 0;
            ushort[] data_w = Get_Data_Word_List(device_name, 1);
            if (data_w != null) result = PLC_Data_Tool.Get_Word(data_w, 0);
            return result;
        }
        public double Get_Data_Word(string device_name, int dot_num)
        {
            double result = 0.0;
            ushort[] data_w = Get_Data_Word_List(device_name, 1);
            if (data_w != null) result = PLC_Data_Tool.Get_Word(data_w, 0, dot_num);
            return result;
        }
        public int Get_Data_DWord(string device_name)
        {
            int result = 0;
            ushort[] data_w = Get_Data_Word_List(device_name, 2);
            if (data_w != null) result = PLC_Data_Tool.Get_DWord(data_w, 0);
            return result;
        }
        public double Get_Data_DWord(string device_name, int dot_num)
        {
            double result = 0.0;
            ushort[] data_w = Get_Data_Word_List(device_name, 2);
            if (data_w != null) result = PLC_Data_Tool.Get_DWord(data_w, 0, dot_num);
            return result;
        }
        public string Get_Data_String(string device_name, int count)
        {
            string result = "";
            ushort[] data_w = Get_Data_Word_List(device_name, count);
            if (data_w != null) result = PLC_Data_Tool.Get_String(data_w, 0, count);
            return result;
        }


        public TBase_Device_List Get_List_Word()
        {
            TBase_Device_List result = Device_Tool.New_Device_List();

            for (int i = 0; i < Devices_Count; i++)
            {
                if (Devices[i].Info_Type == emDevice_Info_Type.emWord) result.Add(Devices[i]);
            }
            return result;
        }
        public void Get_List_Word(ref string[] device_name, ref ushort[] data_byte)
        {
            TBase_Device_List list = Get_List_Word();
            Array.Resize(ref device_name, list.Devices_Count);
            Array.Resize(ref data_byte, list.Devices_Count);
            for (int i = 0; i < list.Devices_Count; i++)
            {
                device_name[i] = list.Devices[i].Device_Name;
                data_byte[i] = list.Devices[i].Data[0];
            }
        }
        public TBase_Device_List Get_List_Bit()
        {
            TBase_Device_List result = Device_Tool.New_Device_List();

            for (int i = 0; i < Devices_Count; i++)
            {
                if (Devices[i].Info_Type == emDevice_Info_Type.emBit) result.Add(Devices[i]);
            }
            return result;
        }
        public void Get_List_Bit(ref string[] device_name, ref bool[] data_bit)
        {
            TBase_Device_List list = Get_List_Bit();
            Array.Resize(ref device_name, list.Devices_Count);
            Array.Resize(ref data_bit, list.Devices_Count);
            for (int i = 0; i < list.Devices_Count; i++)
            {
                device_name[i] = list.Devices[i].Device_Name;
                data_bit[i] = list.Devices[i].Bit;
            }
        }
        public void Set_List_Word(string[] device_name, ushort[] data_byte)
        {
            TBase_Device_Info device = null;

            for (int i = 0; i < device_name.Length; i++)
            {
                device = Get_Device(device_name[i]);
                if (device != null && device.Info_Type == emDevice_Info_Type.emWord && i < data_byte.Length)
                    device.Set_Word(data_byte[i]);
            }
        }
        public void Set_List_Word(ushort[] data)
        {
            TBase_Device_Info device = null;
            TBase_Device_List list = Get_List_Word();

            for (int i = 0; i < list.Devices_Count; i++)
            {
                device = Get_Device(list.Devices[i].Device_Name);
                if (device != null && i < data.Length)
                {
                    device.Set_Word(data[i]);
                }
            }
        }
        public void Set_List_Bit(string[] device_name, bool[] data_bit)
        {
            TBase_Device_Info device = null;
            TBase_Device_List list = Get_List_Bit();

            for (int i = 0; i < device_name.Length; i++)
            {
                device = Get_Device(device_name[i]);
                if (device != null && device.Info_Type == emDevice_Info_Type.emBit && i < data_bit.Length)
                    device.Set_Bit(data_bit[i]);
            }
        }
        public void Set_List_Bit( bool[] data_bit)
        {
            TBase_Device_Info device = null;
            TBase_Device_List list = Get_List_Bit();

            for (int i = 0; i < list.Devices_Count; i++)
            {
                device = Get_Device(list.Devices[i].Device_Name);
                if (device != null && i < data_bit.Length)
                {
                    device.Set_Bit(data_bit[i]);
                }
            }
        }

        public void Sort()
        {
            for (int i = 0; i < Devices_Count - 1; i++)
            {
                for (int j = i + 1; j < Devices_Count; j++)
                {
                    if (string.Compare(Devices[i].Device_Name, Devices[j].Device_Name, true) > 0)
                        Swap_Device(ref Devices[j], ref Devices[i]);
                }
            }
        }


        #region 私用方法
        //--------------------------------------------------------------------------------
        //-- 私用方法
        //--------------------------------------------------------------------------------
        private void Swap_Device(ref TBase_Device_Info device1, ref TBase_Device_Info device2)
        {
            TBase_Device_Info tmp = null;
            tmp = device1.Copy();
            device1 = device2.Copy();
            device2 = tmp.Copy();
        }
        #endregion
    }



    //-----------------------------------------------------------------------------------------------------
    //處理 PLC 執行緒管理
    //-----------------------------------------------------------------------------------------------------
    public class PLC_Thread
    {
        public string Name = "";
        public TJJS_Value_List Param = new TJJS_Value_List();
        private Thread In_Thread = null;
        private bool in_Running = false;
        private evPLC_Thread_Run Run_Fun = null;

        public PLC_Thread(string name, evPLC_Thread_Run run_fun, TJJS_Value_List param)
        {
            Name = name;
            Run_Fun = run_fun;
            Param.Set(param);
            Start();
        }
        public void Start()
        {
            In_Thread = new Thread(Thread_Start);
            In_Thread.Start();
        }
        public void Stop()
        {
            while (Running)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        private void Thread_Start()
        {
            in_Running = true;
            if (Run_Fun != null) Run_Fun(Name, this);
            in_Running = false;
        }
        public bool Running
        {
            get
            {
                return in_Running;
            }
        }
    }
    public class PLC_Thread_List : CollectionBase
    {
        public PLC_Thread_List()
        {

        }
        public PLC_Thread this[int index]
        {
            get
            {
                PLC_Thread result = null;
                if (index >= 0 && index < List.Count) result = (PLC_Thread)List[index];
                return result;
            }
        }
        public PLC_Thread this[string name]
        {
            get
            {
                return this[IndexOf_Name(name)];
            }
        }
        public int IndexOf(PLC_Thread member)
        {
            return this.List.IndexOf(member);
        }
        public int IndexOf_Name(string name)
        {
            int result = -1;
            PLC_Thread tmp_obj = null;
            for (int i = 0; i < List.Count; i++)
            {
                tmp_obj = (PLC_Thread)List[i];
                if (name == tmp_obj.Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Add(PLC_Thread member)
        {
            this.List.Add(member);
        }
        public void Remove(PLC_Thread member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }
        public void Remove(string name)
        {
            RemoveAt(IndexOf_Name(name));
        }
        public void End_Thread(object obj)
        {

        }
        public void Stop()
        {
            for (int i = 0; i < List.Count; i++)
            {
                PLC_Thread obj = (PLC_Thread)List[i];
                obj.Stop();
            }
        }
        public void Remove_Stop_Thread()
        {
            PLC_Thread obj = null;
            int no = 0;

            while (no < List.Count)
            {
                obj = (PLC_Thread)List[no];
                if (!obj.Running)
                {
                    RemoveAt(no);
                }
                else
                {
                    no++;
                }
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    //處理 PLC In / Out / Recipe 資料結構
    //-----------------------------------------------------------------------------------------------------
    abstract public class TPLC_Base_Data
    {
        public ushort[] Data = new ushort[0];
        public string Start_Code = "";
        public bool Read_Reflash = false;
        public bool Write_Reflash = false;
        private int in_Count = 100;

        public int Max_Count
        {
            get
            {
                return Data.Length;
            }
            set
            {
                Array.Resize(ref Data, value);
            }
        }
        public int Count
        {
            get
            {
                return in_Count;
            }
            set
            {
                in_Count = value;
                if (in_Count > Data.Length) in_Count = Data.Length;
            }
        }
        public TPLC_Base_Data()
        {
            Max_Count = 5000;
        }
        public void Reset()
        {
            Read_Reflash = false;
            Write_Reflash = false;
        }
        abstract public void Update();
    }
}
