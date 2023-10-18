using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace EFC.Printer.CAB
{
    public class TCAB_Printer
    {
        public TJJS_CLientSockect Socket = new TJJS_CLientSockect();
        public System.Timers.Timer Read_Timer = new System.Timers.Timer();
        public TLog Log = new TLog();
        public string Esc_Str = "\x1B";
        public string LF_Str = "\x0A";
        public string CR_Str = "\x0D";
        public bool On_Lock = false;
        public bool Read_Timeout = false;

        public TCAB_Printer()
        {
            Socket.Host = "192.168.0.120";
            Socket.Port = 9100;

            Read_Timer.Enabled = false;
            Read_Timer.Interval = 1000;
            Read_Timer.Elapsed += On_Read_Timeout;
        }
        public void On_Read_Timeout(object sender, EventArgs e)
        {
            Read_Timer.Enabled = false;
            Read_Timeout = true;
        }
        public string Read()
        {
            string result = "";

            result = Socket.Recive_String();
            Log.Add(result);
            return result;
        }
        public bool Write(string write_str, ref string recive_str)
        {
            bool result = true;

            while (On_Lock) { };
            Read_Timeout = false;
            On_Lock = true;
            Socket.Send_String(write_str);
            Read_Timer.Enabled = true;
            while (!Read_Timeout)
            {
                if (Socket.Buf_Length > 0)
                {
                    recive_str = Read();
                    break;
                }
            }
            Read_Timer.Enabled = false;
            On_Lock = false;
            return result;
        }
        public bool Write_File(string filename)
        {
            bool result = true;
            ArrayList list = new ArrayList();
            string send_str = "";
            string read_str = "";

            if (System.IO.File.Exists(filename))
            {
                List_Tool.LoadFromFile(ref list, filename);
                for (int i = 0; i < list.Count; i++)
                {
                    send_str = send_str + list[i].ToString() + CR_Str;
                }
                result = Write(send_str, ref read_str);
            }
            return result;
        }
        public bool Get_Status(ref stCAB_Printer_Status status)
        {
            bool result = true;
            string send_str = "";
            string read_str = "";

            send_str = Esc_Str + "s";
            Write(send_str, ref read_str);
            status.Decode(read_str);
            return result;
        }
    }
    public struct stCAB_Printer_Status
    {
        public string Ch_On_Line;
        public string Ch_Error_Msg;
        public string Ch_Amount;
        public string Ch_Interpreter_Active;

        public bool On_Line;
        public string Error_Msg;
        public bool Interpreter_Active;
        public bool On_Error;

        public void Decode(string str)
        {
            if (str.Length >= 9)
            {
                Ch_On_Line = str.Substring(0, 1);
                Ch_Error_Msg = str.Substring(1, 1);
                Ch_Amount = str.Substring(2, 6);
                Ch_Interpreter_Active = str.Substring(6, 1);

                On_Line = Get_On_Line(Ch_On_Line);
                Error_Msg = Get_Error_String(Ch_Error_Msg);
                if (Ch_Error_Msg == "-") On_Error = false;
                else On_Error = true;
                Interpreter_Active = Get_Interpreter_Active(Ch_Interpreter_Active);
            }
        }
        public string Get_Error_String(string ch_str)
        {
            string result = "";

            switch (ch_str)
            {
                //case "-": result = "No error."; break;                   
                case "a": result = "Applicator in upper position."; break;
                case "b": result = "Applicator in lower position."; break;
                case "c": result = "Vacuum plate is empty."; break;
                case "d": result = "Label not deposited."; break;
                case "e": result = "Host stop/error."; break;
                case "f": result = "Reflective sensor blocked/scanresult negative."; break;
                case "g": result = "90 error."; break;
                case "h": result = "0 error."; break;
                case "i": result = "Table not in front position."; break;
                case "j": result = "Table not in rear position."; break;
                case "k": result = "Hand liftet."; break;
                case "l": result = "Hand down."; break;

                case "B": result = "Protocol error."; break;
                case "C": result = "Memory card error."; break;
                case "D": result = "Printhand open."; break;
                case "E": result = "Synchronization error(Nn label found)."; break;
                case "F": result = "Out of Ribbon."; break;

                case "H": result = "Heating voltage problem."; break;

                case "M": result = "Cutter jammed."; break;
                case "N": result = "Label material too thick(cutter)."; break;
                case "O": result = "Out of memory."; break;
                case "P": result = "Out of paper."; break;

                case "S": result = "Ribbon saver malfunction."; break;
                case "V": result = "Input buffer overflow."; break;
                case "W": result = "Print head over heated."; break;
                case "X": result = "External I/O error."; break;
                case "Z": result = "Printhead damaged."; break;

                case "n": result = "Network error."; break;
                case "u": result = "USB error."; break;
            }
            return result;
        }
        public bool Get_On_Line(string ch_str)
        {
            bool result = false;

            switch (ch_str)
            {
                case "Y": result = true; break;
                case "N": result = false; break;
            }
            return result;
        }
        public bool Get_Interpreter_Active(string ch_str)
        {
            bool result = false;

            switch (ch_str)
            {
                case "Y": result = true; break;
                case "N": result = false; break;
            }
            return result;
        }
    }
}
