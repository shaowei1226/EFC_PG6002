using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EFC.Tool
{
    public partial class TForm_Message : Form
    {
        public int Auto_Hide_Time = 100;

        public int Value
        {
            get
            {
                return progressBar1.Value;
            }
            set
            {
                if (value >= 0 && value <= progressBar1.Maximum)
                    progressBar1.Value = value;
            }
        }
        public int Max_Value
        {
            get
            {
                return progressBar1.Maximum;
            }
            set
            {
                if (value != progressBar1.Maximum)
                    progressBar1.Maximum = value;
            }
        }
        public string Schedule_Str
        {
            get
            {
                string result;
                double rate = progressBar1.Value * 100 / progressBar1.Maximum;
                result = string.Format("{0:f0}%", rate);
                return result;
            }
        }
        public string Title
        {
            set
            {
                Text = value;
            }
        }
        public string Caption
        {
            set
            {
                B_Main_Caption.Text = value;
            }
        }
        public string Process_Text
        {
            set
            {
                L_Sub_Caption.Text = value;
            }
        }


        public TForm_Message()
        {
            InitializeComponent();
            PageControl_Tool.Tab_Page_Hide(tabControl1);
            tabControl1.Height = 74;
        }
        public void Show(string caption, string title = "", int auto_hide_time = 0)
        {
            Clear();
            Title = title;
            Caption = caption;
            Auto_Hide_Time = auto_hide_time;
            Show();
            Application.DoEvents();
        }
        public void End()
        {
            if (Auto_Hide_Time > 0)
            {
                timer1.Interval = Auto_Hide_Time;
                timer1.Enabled = true;
            }

            PageControl_Tool.Tab_Page_Select(tabControl1, "關閉");
            while (Visible)
            {
                Application.DoEvents();
            }
        }
        public void Set_Process(int value, int max_value, string process_text)
        {
            string tmp_str = process_text + string.Format("({0:d}/{1:d})", value, max_value);

            Application.DoEvents();
            Value = value;
            Max_Value = max_value;
            
            Add_Message(tmp_str);
            Process_Text = tmp_str;
            E_Schedule.Text = Schedule_Str;
        }
        public void Set_Caption(string caption)
        {
            Caption = caption;
            Application.DoEvents();
        }
        public void Add_Message(string msg)
        {
            Application.DoEvents();
            listBox1.Items.Insert(0, msg);
        }




        private void Clear()
        {
            timer1.Enabled = false;
            Text = "";
            Caption = "";
            listBox1.Items.Clear();
            Process_Text = "";
            E_Schedule.Text = "";
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            PageControl_Tool.Tab_Page_Select(tabControl1, "進度");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Hide();
        }
        private void TForm_Message_Shown(object sender, EventArgs e)
        {
        }
        private void B_Close_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void TForm_Message_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }

    static public class TEFC_Message
    {
        static TForm_Message Show_Form = new TForm_Message();

        static public void Show(string caption, string title = "", int auto_hide_time = 0)
        {
            Show_Form.Show(caption, title, auto_hide_time);
        }
        static public void End()
        {
            Show_Form.End();
        }
        static public void Set_Caption(string caption)
        {
            Show_Form.Set_Caption(caption);
        }
        static public void Set_Process(int value, int max_value, string process_text)
        {
            Show_Form.Set_Process(value, max_value, process_text);
        }
        static public void Add_Message(string msg)
        {
            Show_Form.Add_Message(msg);
        }
    }
}
