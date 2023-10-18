using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isFirstOpen;

            Mutex mutex = new Mutex(false, Application.ProductName, out isFirstOpen);

            if (isFirstOpen)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    Application.Run(new TForm_Main());
                }
                catch (Exception ex)
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(@"D:\\EFC.log", true))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyy/MM/dd") + "," +
                                     DateTime.Now.ToString("HH:mm:ss") +
                                     ",TargetSite:" + ex.TargetSite.Name +
                                     ", Message:" + ex.Message +
                                     ",Source:" + ex.Source +
                                     ",StackTrace:" + ex.StackTrace);
                    }
                }
            }
            else
            {
                MessageBox.Show("重複開啟!");
            }

            mutex.Dispose();
        }
    }
}
