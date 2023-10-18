using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;
using EFC.Camera;

namespace EFC.Light
{
    public partial class TFrame_Set_Light : UserControl
    {
        public TLight_Channel Param = new TLight_Channel();


        public int Light_Value
        {
            get
            {
                return SB_Light.Value;
            }
            set
            {
                SB_Light.Value = value;
                Param.Value = value;
            }
        }
        public TFrame_Set_Light()
        {
            InitializeComponent();
        }
        public void Set_Param(TLight_Channel param)
        {
            Param.Set(param);
            Set_Param();
        }
        public void Set_Param()
        {
            L_Name.Text = Param.Name;
            SB_Light.LargeChange = Param.Big_Change;
            SB_Light.Maximum = Param.Max;
            SB_Light.SmallChange = Param.Small_Change;
            SB_Light.Value = Param.Value;
        }
        public void Update_Param()
        {
            Param.Value = SB_Light.Value;
        }
        private void B_Set_Light_Click(object sender, EventArgs e)
        {
            Apply_Light();
        }
        private void SB_Light_ValueChanged(object sender, EventArgs e)
        {
            E_Light.Text = SB_Light.Value.ToString();
        }
        private void E_Light_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int value = Convert.ToInt32(E_Light.Text);
                if (value > Param.Max) value = Param.Max;
                SB_Light.Value = value;
            }
        }
        private void E_Light_Leave(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(E_Light.Text);
            if (value > Param.Max) value = Param.Max;
            SB_Light.Value = value;
        }
        public void Set(TLight_Channel data)
        {
            Param.Set(data);
            Set_Param();
        }
        public void Set(TLight_Base light, string name, int id, int value, int big_change = 10, int small_change = 1)
        {
            Param.Set(light, name, id, value, big_change, small_change);
            Set_Param();
        }
        public void Apply_Light()
        {
            if (Param.Light != null) Param.Light.Set_Light(Param.ID, SB_Light.Value);
        }
    }
}
