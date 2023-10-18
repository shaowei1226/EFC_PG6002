using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using EFC.Tool;
using EFC.Camera;
using EFC.Vision.Halcon;


namespace EFC.Light
{
    public partial class TForm_Set_Light : Form
    {
        public int Disp_Count = 6;
        public TLight_Channel_List Param = new TLight_Channel_List();
        public TFrame_Set_Light[] Frame_Light = new TFrame_Set_Light[6];
        public TCamera_Base Camera = null;
        public bool Old_Camera_Grab_Life; 


        public TForm_Set_Light()
        {
            InitializeComponent();
            Param.Count = 6;

            Frame_Light[0] = tFrame_Set_Light1;
            Frame_Light[1] = tFrame_Set_Light2;
            Frame_Light[2] = tFrame_Set_Light3;
            Frame_Light[3] = tFrame_Set_Light4;
            Frame_Light[4] = tFrame_Set_Light5;
            Frame_Light[5] = tFrame_Set_Light6;
        }
        public TForm_Set_Light(TCamera_Base camera, TLight_Channel_List items)
        {
            InitializeComponent();
            Param.Count = 6;

            Frame_Light[0] = tFrame_Set_Light1;
            Frame_Light[1] = tFrame_Set_Light2;
            Frame_Light[2] = tFrame_Set_Light3;
            Frame_Light[3] = tFrame_Set_Light4;
            Frame_Light[4] = tFrame_Set_Light5;
            Frame_Light[5] = tFrame_Set_Light6;

            Camera = camera;
            Param.Set(items);
        }
        private void TForm_Set_Light_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            for (int i = 0; i < Frame_Light.Length; i++)
            {
                if (i < Param.Count) Frame_Light[i].Set(Param[i]);
            }
            if (Camera != null) 
            {
                Old_Camera_Grab_Life = Camera.OnLife;
                Camera.Grab_Life();
            }
            for (int i = Param.Count; i < Frame_Light.Length; i++) Frame_Light[i].Visible = false;
            Set_Light_All();
        }
        private void TForm_Set_Light_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            if (Camera != null)
            {
                if (!Old_Camera_Grab_Life) Camera.Grab_Stop();
            }
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Frame_Light.Length; i++)
            {
                if (i < Param.Count) Param[i].Value = Frame_Light[i].Light_Value;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        public void Refalsh_Camera1()
        {
            HImage image = new HImage();
            string tmp_str;
            double scale;
            

            if (Camera != null)
            {
                Camera.Get_HImage(ref image);
                scale = Camera.Image_Width / 640;
                try
                {
                    tFrame_JJS_HW1.SetPart(image);
                    tFrame_JJS_HW1.HW_Buf.HalconWindow.DispObj(image);
                    tmp_str = Camera.Name;
                    JJS_Vision.Display_String(tFrame_JJS_HW1.HW_Buf, tmp_str, 10, 10, 30, scale, "blue");
                    JJS_Vision.Display_Hairline(tFrame_JJS_HW1.HW_Buf, (double)Camera.Image_Width / 2, Camera.Image_Height / 2, Camera.Image_Width, 0, "red");
                    tFrame_JJS_HW1.Copy_HW();
                    Camera.Refalsh = false;
                }
                catch
                {

                }
            }
        }
        public void Set_Light_All()
        {
            for (int i = 0; i < Param.Count; i++) Frame_Light[i].Apply_Light();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Refalsh_Camera1();
        }
    }
}
