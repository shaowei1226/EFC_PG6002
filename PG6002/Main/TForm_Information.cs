using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;   //FileVersionInfo  顯示版本用
using System.Reflection;    //Assembly 顯示版本用

namespace Main
{
    public partial class TForm_Information : Form
    {
        public TForm_Information()
        {
            InitializeComponent();
        }

        private void TForm_Information_Load(object sender, EventArgs e)
        {
            //由專案-> TMain屬性-> 應用程式*-> 組件資訊內修改版本
            textBox7.Text ="V" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion.ToString();
        }
    }
}
