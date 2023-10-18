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
using System.Runtime.InteropServices;
using HalconDotNet;
using EFC.Tool;
using EFC.INI;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public HImage Image_Send = new HImage();
        public HImage Image_Recive = new HImage();
        public TSocket_Data_Image Data = new TSocket_Data_Image();
        public TJJS_ServerSockect Server = new TJJS_ServerSockect();
        public TJJS_CLientSockect Client = new TJJS_CLientSockect();
        public TLog Log = new TLog();
        public int recive_count = 0;
        public int Send_Count = 0;
        public byte[] Recive_Data = new byte[0];

        public Form1()
        {
            InitializeComponent();

            Log.Default_Path = "e:\\";
            Log.Enabled = true;

            Server.Host = "127.0.0.1";
            Server.Port = 5050;
            Server.On_JJS_Read += On_Client_Read;
            Server.OnClientConnect += On_Client_Connect;
            Server.Active = true;

            Client.Host = "127.0.0.1";
            Client.Port = 5050;
            Client.Active = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();

            dialog.Filter = "JPG File|*.jpg|BMP File|*.bmp";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image_Send.ReadImage(dialog.FileName);
                Draw_Image(hWindowControl1, Image_Send);
                Send_Count = 50;
                timer2.Enabled = true;
            }
        }
        public void Draw_Image(HWindowControl hw, HImage image)
        {
            int w, h;
            if (image != null)
            {
                image.GetImageSize(out w, out h);
                hw.HalconWindow.SetPart(0, 0, h, w);
                hw.HalconWindow.DispObj(image);
            }
        }
        public bool Get_Data_Image(ref byte[] sor, bool delete_error)
        {
            bool result = false;
            TSocket_Data_Image recive = new TSocket_Data_Image();
            int total = 0;

            total = recive.Get_Total_Len(sor);
            if (recive.Is_Ok_Data(sor))
            {
                if (recive.Set_Data_Byte(sor))
                {
                    Log.Add("Get Image");
                    //Draw_Image(hWindowControl2, recive.Image);
                    Server.Sockets[0].Data_Byte_Delete(ref sor, total);
                    result = true;
                }
                else
                {
                    if (delete_error)
                    {
                        Log.Add("Delete Error Data.");
                        Server.Sockets[0].Data_Byte_Delete(ref sor, total);
                    }
                }
            };
            return result;
        }
        public void On_Client_Read(TJJS_Socket s_socket)
        {
            byte[] recive_data ;

            recive_data = s_socket.Recive_Byte(-1);
            s_socket.Data_Byte_Add(ref Recive_Data, recive_data, recive_data.Length);
        }
        public void On_Client_Connect(TJJS_Socket s_socket) 
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int error_count = 0;
            bool get_flag = false;
            bool delete_error = false;

            timer1.Enabled = false;
            Log.Display_List(listBox1);

            while (Recive_Data.Length > 0)
            {
                if (error_count >= 100) delete_error = true;
                else delete_error = false;

                get_flag = Get_Data_Image(ref Recive_Data, delete_error);
                if (get_flag) error_count = 0;
                else error_count++;
            }
            timer1.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            if (Image_Send != null)
            {
                Data.Image = Image_Send;
                byte[] data = Data.Get_Data_Byte();
                Client.Send_Byte(data);
            }
            Send_Count--;
            if (Send_Count > 0) timer2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] data2 = new byte[10000];
            data2 = Server.Sockets[0].Recive_Byte(10000);
            Log.Add("Data = " + data2.Length.ToString());
        }

    }
    public class TSocket_Data_Base
    {
        public byte Start_Code;
        public byte End_Code;
        
        public TSocket_Data_Base()
        {
            Start_Code = (byte)'@';
            End_Code = (byte)';';
        }
    }
    public class TSocket_Data_Image : TSocket_Data_Base
    {
        public int Hand_Size;
        public HImage Image = null;

        public int Image_Data_Count
        {
            get
            {
                int w, h;

                if (Image != null)
                {
                    Image.GetImageSize(out w, out h);
                    return w * h;
                }
                else
                return 0;
            }
        }
        public TSocket_Data_Image()
        {
            Hand_Size = sizeof(int) * 3;
            Image = null;
        }
        public int Total_Size()
        {
            int result = 0;

            result = Hand_Size + Image_Data_Count + 2;
            return result;
        }
        public bool Is_Ok_Data(byte[] sor)
        {
            bool result = false;
            byte start_code = 0, end_code = 0;
            int total = 0;
            start_code = sor[0];
            total = Get_Total_Len(sor);
            if (sor.Length >= total && total > 0) end_code = sor[total - 1];
            if (start_code == Start_Code && sor.Length >= total && end_code == End_Code)
            {
                result = true;
            }
            return result;
        }
        public int Get_Total_Len(byte[] sor)
        {
            int result;
            result = BitConverter.ToInt32(sor, 1);
            return result;
        }
        public byte Get_End_Code(byte[] sor)
        {
            byte result = 0;
            int total =0;

            total = Get_Total_Len(sor);
            if (sor.Length >= total) result = sor[total - 1];
            return result;
        }
        public byte[] Get_Data_Byte()
        {
            byte[] result = new byte[Total_Size()];
            int no = 0;

            no = Get_Data_Byte_Start(ref result, no);
            no = Get_Data_Byte_Hand(ref result, no);
            no = Get_Data_Byte_Image(ref result, no);
            Get_Data_Byte_End(ref result, no);
            return result;
        }
        public int Get_Data_Byte_Start(ref byte[] sor, int no)
        {
            sor[no] = Start_Code;
            return no + 1;
        }
        public int Get_Data_Byte_End(ref byte[] sor, int no)
        {
            sor[no] = End_Code;
            return no + 1;
        }
        public int Get_Data_Byte_Hand(ref byte[] sor, int no)
        {
            int total = 0, w = 0, h = 0;

            total = Total_Size();
            if (Image != null) Image.GetImageSize(out w, out h);
            Array.Copy(BitConverter.GetBytes(total), 0, sor, no, sizeof(int));
            Array.Copy(BitConverter.GetBytes(w), 0, sor, no + sizeof(int), sizeof(int));
            Array.Copy(BitConverter.GetBytes(h), 0, sor, no + sizeof(int) * 2, sizeof(int));
            return (no + sizeof(int) * 3);
        }
        public int Get_Data_Byte_Image(ref byte[] sor, int no)
        {
            int result;
            int w, h;
            string type;
            IntPtr image_ptr;

            if (Image != null)
            {
                image_ptr = Image.GetImagePointer1(out type, out w, out h);
                Marshal.Copy(image_ptr, sor, no, w * h);
                result = no + w * h;
            }
            else
            {
                result = no;
            }
            return result;
        }
        public bool Set_Data_Byte(byte[] sor)
        {
            bool result = false;
            int no = 0;
            int total = 0, w = 0, h = 0;
            byte start_code, end_code;
            if (Is_Ok_Data(sor))
            {
                start_code = sor[no];
                no = no + 1;
                total = BitConverter.ToInt32(sor, no);
                no = no + sizeof(int);
                w = BitConverter.ToInt32(sor, no);
                no = no + sizeof(int);
                h = BitConverter.ToInt32(sor, no);
                no = no + sizeof(int);

                no = Set_Data_Byte_Image(sor, no, w, h);
                end_code = sor[no];
                result = true;
            }
            return result;
        }
        public int Set_Data_Byte_Image(byte[] sor, int no, int w, int h)
        {
            IntPtr image_ptr;

            unsafe
            {
                fixed (byte* p = sor)
                {
                    image_ptr = (IntPtr)p + no;
                }
                Image = new HImage();
                Image.GenImage1("byte", w, h, image_ptr);
            }
            return no + w * h;
        }
    }
}
