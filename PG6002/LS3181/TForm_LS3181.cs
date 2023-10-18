using System;
using System.IO;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XiZhi;

namespace LS3181
{
    public partial class TForm_LS3181 : Form
    {

        public int Status;
        public TLSI_3181_Data Status_Data = new TLSI_3181_Data();
        public int IRQ_Count;
        TextBox[] E_Offset_Compare = new TextBox[8];
        TextBox[] E_Pulse_Width = new TextBox[8];
        CheckBox[] CB_State_Check = new CheckBox[8];
        CheckBox[] CB_Mask_Check = new CheckBox[8];
        TextBox[] E_Segment_Start = new TextBox[3];
        TextBox[] E_Segment_Stop = new TextBox[3];
        ComboBox[] CB_Segment_Control = new ComboBox[3];
        CheckBox[] CB_Input_Polarity = new CheckBox[8];
        CheckBox[] CB_Output_Polarity = new CheckBox[8];
        CheckBox[] CB_Input = new CheckBox[8];
        CheckBox[] CB_Output = new CheckBox[8];


        public TForm_LS3181()
        {
            InitializeComponent();
            Component_Link();
            tabControl1.TabPages.Remove(tabPage6);
        }
        private void Form_LS3181_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            CB_Card_ID.Items.Add(Status_Data.Card_ID);
            CB_Card_ID.SelectedIndex = 0;
        }
        public void Component_Link()
        {

            E_Offset_Compare[0] = E_OffsetCompare_0;
            E_Offset_Compare[1] = E_OffsetCompare_1;
            E_Offset_Compare[2] = E_OffsetCompare_2;
            E_Offset_Compare[3] = E_OffsetCompare_3;
            E_Offset_Compare[4] = E_OffsetCompare_4;
            E_Offset_Compare[5] = E_OffsetCompare_5;
            E_Offset_Compare[6] = E_OffsetCompare_6;
            E_Offset_Compare[7] = E_OffsetCompare_7;

            E_Pulse_Width[0] = E_PulseWidth_0;
            E_Pulse_Width[1] = E_PulseWidth_1;
            E_Pulse_Width[2] = E_PulseWidth_2;
            E_Pulse_Width[3] = E_PulseWidth_3;
            E_Pulse_Width[4] = E_PulseWidth_4;
            E_Pulse_Width[5] = E_PulseWidth_5;
            E_Pulse_Width[6] = E_PulseWidth_6;
            E_Pulse_Width[7] = E_PulseWidth_7;

            CB_State_Check[0] = State_CheckBox_0;
            CB_State_Check[1] = State_CheckBox_1;
            CB_State_Check[2] = State_CheckBox_2;
            CB_State_Check[3] = State_CheckBox_3;
            CB_State_Check[4] = State_CheckBox_4;
            CB_State_Check[5] = State_CheckBox_5;
            CB_State_Check[6] = State_CheckBox_6;
            CB_State_Check[7] = State_CheckBox_7;

            CB_Mask_Check[0] = Mask_CheckBox_0;
            CB_Mask_Check[1] = Mask_CheckBox_1;
            CB_Mask_Check[2] = Mask_CheckBox_2;
            CB_Mask_Check[3] = Mask_CheckBox_3;
            CB_Mask_Check[4] = Mask_CheckBox_4;
            CB_Mask_Check[5] = Mask_CheckBox_5;
            CB_Mask_Check[6] = Mask_CheckBox_6;
            CB_Mask_Check[7] = Mask_CheckBox_7;

            CB_Segment_Control[0] = Control_ComboBox_0;
            CB_Segment_Control[1] = Control_ComboBox_1;
            CB_Segment_Control[2] = Control_ComboBox_2;

            E_Segment_Start[0] = Start_TextBox_0;
            E_Segment_Start[1] = Start_TextBox_1;
            E_Segment_Start[2] = Start_TextBox_2;

            E_Segment_Stop[0] = Stop_TextBox_0;
            E_Segment_Stop[1] = Stop_TextBox_1;
            E_Segment_Stop[2] = Stop_TextBox_2;

            //IO
            CB_Input_Polarity[0] = CB_IN00_Polarity;
            CB_Input_Polarity[1] = CB_IN01_Polarity;
            CB_Input_Polarity[2] = CB_IN02_Polarity;
            CB_Input_Polarity[3] = CB_IN03_Polarity;
            CB_Input_Polarity[4] = CB_IN04_Polarity;
            CB_Input_Polarity[5] = CB_IN05_Polarity;
            CB_Input_Polarity[6] = CB_IN06_Polarity;
            CB_Input_Polarity[7] = CB_IN07_Polarity;

            CB_Output_Polarity[0] = CB_OUT00_Polarity;
            CB_Output_Polarity[1] = CB_OUT01_Polarity;
            CB_Output_Polarity[2] = CB_OUT02_Polarity;
            CB_Output_Polarity[3] = CB_OUT03_Polarity;
            CB_Output_Polarity[4] = CB_OUT04_Polarity;
            CB_Output_Polarity[5] = CB_OUT05_Polarity;
            CB_Output_Polarity[6] = CB_OUT06_Polarity;
            CB_Output_Polarity[7] = CB_OUT07_Polarity;

            CB_Input[0] = CB_IN00;
            CB_Input[1] = CB_IN01;
            CB_Input[2] = CB_IN02;
            CB_Input[3] = CB_IN03;
            CB_Input[4] = CB_IN04;
            CB_Input[5] = CB_IN05;
            CB_Input[6] = CB_IN06;
            CB_Input[7] = CB_IN07;

            CB_Output[0] = CB_OUT00;
            CB_Output[1] = CB_OUT01;
            CB_Output[2] = CB_OUT02;
            CB_Output[3] = CB_OUT03;
            CB_Output[4] = CB_OUT04;
            CB_Output[5] = CB_OUT05;
            CB_Output[6] = CB_OUT06;
            CB_Output[7] = CB_OUT07;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LSI3181.LSI3181_counter_read(0, ref Status_Data.Current_Value);
            LSI3181.LSI3181_compare_value_read(0, ref Status_Data.Compare_Value);
            Base_Set_Param();
            //CompareAction();
            //Compare_Set_Param();
            //IRQ_Set_Param();
            //Extension_Set_Param();
            //Segment_Set_Param();
            //IO_Set_Param();
            //Read_TC_Time();
        }
        private void Base_Set_Param()
        {
            CB_Debounce.SelectedIndex = Status_Data.Debounce_Time;
            //  base page
            E_Compare_Value.Text = Status_Data.Compare_Value.ToString();
            E_Current_Value.Text = Status_Data.Current_Value.ToString();
            CB_A_Phase.Checked = Convert.ToBoolean(Status_Data.CIO_State.Bit00);
            CB_B_Phase.Checked = Convert.ToBoolean(Status_Data.CIO_State.Bit01);
            CB_Z_Phase.Checked = Convert.ToBoolean(Status_Data.CIO_State.Bit02);
            CB_Home_IN.Checked = Convert.ToBoolean(Status_Data.CIO_State.Bit03);
            CB_CLR_IN.Checked = Convert.ToBoolean(Status_Data.CIO_State.Bit04);
            CB_Zero_Toggle.Checked = Convert.ToBoolean(Status_Data.CIO_State.Bit05);
            E_FIFO_Unused_Value.Text = Status_Data.FIFO_Unused_Count.ToString();
            CB_CMP_Out.Checked = Convert.ToBoolean(Status_Data.Compare_Out);
            if (Status_Data.Input_Point.Bit00 == 1)
                CB_Input_IN00.Checked = true;
            else
                CB_Input_IN00.Checked = false;
        }
        private void Compare_Set_Param()
        {
            //encode input
            CB_Compare_Mode.SelectedIndex = Status_Data.Compare_Mode;
            E_Increment_Value.Text = Status_Data.Increment_Value.ToString();
            CB_A_Phase_Polarity.Checked = Convert.ToBoolean(Status_Data.CIO_Polarity_State.Bit00);
            CB_B_Phase_Polarity.Checked = Convert.ToBoolean(Status_Data.CIO_Polarity_State.Bit01);
            CB_Z_Phase_Polarity.Checked = Convert.ToBoolean(Status_Data.CIO_Polarity_State.Bit02);
            CB_Encode_Input_Mode.SelectedIndex = Status_Data.CI_Mode;
            CB_Encode_Debounce.SelectedIndex = Status_Data.CI_DeBounce_Time;
            CB_Encode_Multiple_Rate.SelectedIndex = Status_Data.CI_Multiple_Rate;
            // CMP OUT
            CB_Gate_Enabled.Checked = Convert.ToBoolean(Status_Data.CMP_Gate);
            CB_Gate_Polarity.Checked = Convert.ToBoolean(Status_Data.Input_Polarity.Bit00);
            CB_CMP_Out_Polarity.Checked = Convert.ToBoolean(Status_Data.CIO_Polarity_State.Bit07);
            CB_CMP_Mode.SelectedIndex = Status_Data.CMP_Mode;
            E_Duty_Cycle.Text = Status_Data.Duty_Cycle.ToString();
            //homing
            CB_Home_Polarity.Checked = Convert.ToBoolean(Status_Data.CIO_Polarity_State.Bit03);
            CB_CLR_IN_Polarity.Checked = Convert.ToBoolean(Status_Data.CIO_Polarity_State.Bit04);
            CB_Continuous_Mode.Checked = Convert.ToBoolean(Status_Data.Homing_Continuous_Count);
            CB_HomingMode.SelectedIndex = Status_Data.Homing_Mode;
            E_Continuous_Count.Text = Status_Data.Homing_Z_Count.ToString();
            //set value
            E_Current_Value.Text = Status_Data.Set_Current_Value.ToString();
            E_Compare_Value.Text = Status_Data.Set_Compare_Value.ToString();
        }
        private void IRQ_Set_Param()
        {
            //IRQ 
            CB_IN00_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit00);
            CB_IN01_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit01);
            CB_IN02_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit02);
            CB_IN03_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit03);
            CB_IN04_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit04);
            CB_IN05_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit05);
            CB_IN06_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit06);
            CB_IN07_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_IO_Mask.Bit07);

            CB_FIFO_Threadload_Empty_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_T_C_Mask.Bit00);
            CB_FIFO_Full_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_T_C_Mask.Bit01);
            CB_FIFO_Empty_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_T_C_Mask.Bit02);
            CB_Compare_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_T_C_Mask.Bit03);
            CB_Timer_IRQ_Mask.Checked = Convert.ToBoolean(Status_Data.IRQ_T_C_Mask.Bit04);

            //CBL_IRQ_Status.SetItemCheckState(0, CheckState.Indeterminate);
        }
        private void Extension_Set_Param()
        {                                    
            //extension
            byte state=0;
            Int16  offset=0;
            UInt16 out_width = 0;
            int tet;
            for(byte i=0;i<7;i++)
            {
                tet = 2 ^ i;
                if ((Status_Data.Compare_Mask & (byte)Math.Pow(2, i) / (byte)Math.Pow(2, i)) == 1) 
                {
                    CB_Mask_Check[i].Checked = true;
                }
                else
                    CB_Mask_Check[i].Checked = false;

                Status = LSI3181.LSI3181_compare_offset_read(Status_Data.Card_ID, i, ref offset);
                if (offset < 0)
                    E_Offset_Compare[i].Text = (65536 + offset).ToString();
                else
                    E_Offset_Compare[i].Text = offset.ToString();

                Status = LSI3181.LSI3181_compare_offset_out_width_read(Status_Data.Card_ID,i,ref out_width);                  
                E_Pulse_Width[i].Text = out_width.ToString();

                Status = LSI3181.LSI3181_compare_offset_output_point_read(Status_Data.Card_ID, i, ref state);
                if(state == 1)
                {
                    CB_State_Check[i].Checked = true;
                }
                else
                    CB_State_Check[i].Checked = false;
            }

        }
        private void Segment_Set_Param()
        {
            //segment
            uint start_32 = 0, stop_32 = 0;
            byte seg_value = 0;
            for(byte i=0; i<2; i++)
            {
                Status = LSI3181.LSI3181_segment_control_read(Status_Data.Card_ID, i, ref seg_value);
                CB_Segment_Control[i].SelectedIndex = seg_value;
                Status = LSI3181.LSI3181_cmp_segment_read(Status_Data.Card_ID,i, ref start_32, ref stop_32);
                E_Segment_Start[i].Text = start_32.ToString();
                E_Segment_Stop[i].Text = stop_32.ToString();
            }

            Status = LSI3181.LSI3181_mask_off_read(Status_Data.Card_ID, ref seg_value);
            Mask_ComboBox.SelectedIndex = seg_value;        
        }           
        private void IO_Set_Param()
        {
            byte state = 0, state2 = 0;

            for(byte point=0; point<8; point++)
            {
                Status = LSI3181.LSI3181_point_read(Status_Data.Card_ID, (byte)XiZhi.emLSI_PORT_TYPE.IN_PUT, point, ref state);
                CB_Input[point].CheckState = (CheckState) state;
                Status = LSI3181.LSI3181_point_read(Status_Data.Card_ID, (byte)XiZhi.emLSI_PORT_TYPE.OUT_PUT, point, ref state);
                CB_Output[point].CheckState = (CheckState)state;               
            }

            Status = LSI3181.LSI3181_port_polarity_read(Status_Data.Card_ID, (byte)XiZhi.emLSI_PORT_TYPE.IN_PUT, ref state);
            Status = LSI3181.LSI3181_port_polarity_read(Status_Data.Card_ID, (byte)XiZhi.emLSI_PORT_TYPE.OUT_PUT, ref state2);

            state = 255;

            for(byte i=0; i<8; i++)
            {
                CB_Input_Polarity[i].CheckState = (CheckState) ((state >> i) & 1);

                CB_Output_Polarity[i].CheckState = (CheckState) ((state2 >> i) & 1);
            }            
        }        
        private void CB_Compare_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != 2)
                E_Increment_Value.Enabled = false;
            else
                E_Increment_Value.Enabled = true;
        }
        private void B_Increment_Value_Set_Click(object sender, EventArgs e)
        {
            Status = XiZhi.LSI3181.LSI3181_compare_increment_set(Status_Data.Card_ID, Convert.ToInt32(E_Increment_Value.Text));
        }
        private void B_Encode_Input_Set_Click(object sender, EventArgs e)
        {
            Status = XiZhi.LSI3181.LSI3181_CI_mode_set(Status_Data.Card_ID, Convert.ToByte(CB_Encode_Input_Mode.SelectedIndex), 
                Convert.ToByte(CB_Encode_Debounce.SelectedIndex), Convert.ToByte(CB_Encode_Multiple_Rate.SelectedIndex));
        }
        private void B_CMP_Out_Set_Click(object sender, EventArgs e)
        {
            Status = XiZhi.LSI3181.LSI3181_compare_CMP_OUT_set(Status_Data.Card_ID, Convert.ToByte(CB_CMP_Out_Polarity.Checked), 
               (byte) CB_CMP_Mode.SelectedIndex, Convert.ToUInt16(E_Duty_Cycle.Text));
        }
        private void B_FIFO_Clear_Click(object sender, EventArgs e)
        {
            Status = XiZhi.LSI3181.LSI3181_compare_FIFO_clear(Status_Data.Card_ID);
        }
        private void B_FIFO_File_Set_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_diglog = new OpenFileDialog();
            StreamReader f_stream;
            open_diglog.Title = "Select fifo data file (*.txt)";
            open_diglog.Filter = "text(*.txt)|*.*";
            open_diglog.FileName = "*.txt";
            int[] file_data = new int[1024];
            int file_num = 0;
            string line; 
   
            if(open_diglog.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    if(open_diglog.FileName != null)
                    {                       
                        using(f_stream = new StreamReader(open_diglog.FileName))
                        {
                           while((line = f_stream.ReadLine()) != null)
                           {
                               file_data[file_num] = Convert.ToInt32(line);
                               file_num++;

                           }

                        }
                        Status =  XiZhi.LSI3181.LSI3181_compare_FIFO_set(Status_Data.Card_ID, file_data, (byte)CB_FIFO_Position_Mode.SelectedIndex, (ushort) file_num);
                    }


                }
                catch(Exception ex)
                {

                }

            }                 
        }
        private void B_FIFO_Apply_Click(object sender, EventArgs e)
        {
            int[] file_data = new int[1024];
            file_data[0] = Convert.ToInt32(E_FIFO_Data.Text );

            Status = XiZhi.LSI3181.LSI3181_compare_FIFO_set(Status_Data.Card_ID,file_data,(byte)CB_FIFO_Position_Mode.SelectedIndex, (ushort) 1);
            Status = XiZhi.LSI3181.LSI3181_compare_FIFO_threshold_set(Status_Data.Card_ID, Convert.ToUInt16(E_FIFO_Threshold_Value.Text));           
        }
        private void B_FIFO_IRQ_Req_Click(object sender, EventArgs e)
        {

        }
        private void B_Homing_Set_Click(object sender, EventArgs e)
        {
            byte mode = 0,single_count=0;
            ushort z_count=0;
            single_count = Convert.ToByte(CB_Continuous_Mode.Checked);
            mode = (byte)CB_HomingMode.SelectedIndex;
            z_count = Convert.ToUInt16(E_Continuous_Count.Text);

            Status = XiZhi.LSI3181.LSI3181_HOMING_mode_set(Status_Data.Card_ID, mode, z_count, single_count);

        }
        private void B_Set_Current_Value_Click(object sender, EventArgs e)
        {
            int value = Convert.ToInt32( E_Set_Current_Value.Text);
            Status = XiZhi.LSI3181.LSI3181_counter_set(Status_Data.Card_ID, value);
        }
        private void B_Set_Compare_Value_Click(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(E_Set_Compare_Value.Text);
            Status = XiZhi.LSI3181.LSI3181_compare_value_set(Status_Data.Card_ID, value);
        }
        private void B_IRQ_OK_Click(object sender, EventArgs e)
        {
            IRQ_Count = 0;
        }
        private void B_Apply_Click(object sender, EventArgs e)
        {
            Status_Data.IRQ_IO_Mask.Bit00 = Convert.ToByte(CB_IN00_IRQ_Mask.Checked);
            Status_Data.IRQ_IO_Mask.Bit01 = Convert.ToByte(CB_IN01_IRQ_Mask.Checked);
            Status_Data.IRQ_IO_Mask.Bit02 = Convert.ToByte(CB_IN02_IRQ_Mask.Checked);
            Status_Data.IRQ_IO_Mask.Bit03 = Convert.ToByte(CB_IN03_IRQ_Mask.Checked);
            Status_Data.IRQ_IO_Mask.Bit04 = Convert.ToByte(CB_IN04_IRQ_Mask.Checked);
            Status_Data.IRQ_IO_Mask.Bit05 = Convert.ToByte(CB_IN05_IRQ_Mask.Checked);
            Status_Data.IRQ_IO_Mask.Bit06 = Convert.ToByte(CB_IN06_IRQ_Mask.Checked);
            Status_Data.IRQ_IO_Mask.Bit07 = Convert.ToByte(CB_IN07_IRQ_Mask.Checked);
            Status = LSI3181.LSI3181_IRQ_mask_set(Status_Data.Card_ID, (byte)XiZhi.emLSI_IRQ_Source.IO_BLOCK, Status_Data.IRQ_IO_Mask.Value);

            Status_Data.IRQ_T_C_Mask.Bit00 = Convert.ToByte(CB_FIFO_Threadload_Empty_IRQ_Mask.Checked);
            Status_Data.IRQ_T_C_Mask.Bit01 = Convert.ToByte(CB_FIFO_Full_IRQ_Mask.Checked);
            Status_Data.IRQ_T_C_Mask.Bit02 = Convert.ToByte(CB_FIFO_Empty_IRQ_Mask.Checked);
            Status_Data.IRQ_T_C_Mask.Bit03 = Convert.ToByte(CB_Compare_IRQ_Mask.Checked);
            Status_Data.IRQ_T_C_Mask.Bit04 = Convert.ToByte(CB_Timer_IRQ_Mask.Checked);
            Status = LSI3181.LSI3181_IRQ_mask_set(Status_Data.Card_ID, (byte)XiZhi.emLSI_IRQ_Source.T_C_BLOCK, Status_Data.IRQ_T_C_Mask.Value);
        }
        public void IRQ_Status_Read()
        {
            CBL_IRQ_Status.SetItemCheckState(0, (CheckState)Status_Data.IRQ_IO_Status.Bit00);
            CBL_IRQ_Status.SetItemCheckState(1, (CheckState)Status_Data.IRQ_IO_Status.Bit01);
            CBL_IRQ_Status.SetItemCheckState(2, (CheckState)Status_Data.IRQ_IO_Status.Bit02);
            CBL_IRQ_Status.SetItemCheckState(3, (CheckState)Status_Data.IRQ_IO_Status.Bit03);
            CBL_IRQ_Status.SetItemCheckState(4, (CheckState)Status_Data.IRQ_IO_Status.Bit04);
            CBL_IRQ_Status.SetItemCheckState(5, (CheckState)Status_Data.IRQ_IO_Status.Bit05);
            CBL_IRQ_Status.SetItemCheckState(6, (CheckState)Status_Data.IRQ_IO_Status.Bit06);
            CBL_IRQ_Status.SetItemCheckState(7, (CheckState)Status_Data.IRQ_IO_Status.Bit07);             

            CBL_IRQ_Status.SetItemCheckState(8,  (CheckState)Status_Data.IRQ_T_C_Status.Bit00);
            CBL_IRQ_Status.SetItemCheckState(9,  (CheckState)Status_Data.IRQ_T_C_Status.Bit01);
            CBL_IRQ_Status.SetItemCheckState(10, (CheckState)Status_Data.IRQ_T_C_Status.Bit02);
            CBL_IRQ_Status.SetItemCheckState(11, (CheckState)Status_Data.IRQ_T_C_Status.Bit03);
            CBL_IRQ_Status.SetItemCheckState(12, (CheckState)Status_Data.IRQ_T_C_Status.Bit04);
        }
        public void IRQ_Count_Display()
        {
            L_IRQ_Count.Text = L_IRQ_Count.Text + String.Format(" {0}", IRQ_Count);
        }
        private void B_IRQ_Cancel_Click(object sender, EventArgs e)
        {

        }
        private void B_Extension_OK_Click(object sender, EventArgs e)
        {
            B_Extension_Apply_Click(sender, e);
        }
        private void B_Extension_Apply_Click(object sender, EventArgs e)
        {
            int offset = 0, out_width = 0;
            byte state = 0, mask = 0, mask_tmp = 0;
            for (byte i = 0; i < 8; i++ )
            {
                if (Convert.ToInt16(E_Offset_Compare[i].Text) > 32767)
                    offset = Convert.ToInt16(E_Offset_Compare[i].Text) - 65536;

                Status = LSI3181.LSI3181_compare_offset_set(Status_Data.Card_ID, i, (short)offset);

                out_width = Convert.ToInt16(E_Pulse_Width[i].Text);

                Status = LSI3181.LSI3181_compare_offset_out_width_set(Status_Data.Card_ID, i, (ushort)out_width);

                if (CB_State_Check[i].Checked == true)
                    state = 1;
                else
                    state = 0;

                Status = LSI3181.LSI3181_compare_offset_output_point_set(Status_Data.Card_ID, i, state);

                if (CB_Mask_Check[i].Checked == true)
                    mask_tmp = 1;
                else
                    mask_tmp = 0;

                mask = (byte)(mask + mask_tmp * (2 ^ i));           

            }
            Status = LSI3181.LSI3181_compare_offset_mask_set(Status_Data.Card_ID, mask);
        }
        private void Apply_Button_Click(object sender, EventArgs e)
        {
            for(int i=0; i<2; i++)
            {
                Status = LSI3181.LSI3181_segment_control_write(Status_Data.Card_ID, (byte)i, (byte)CB_Segment_Control[i].SelectedIndex);
                Status = LSI3181.LSI3181_cmp_segment_write(Status_Data.Card_ID, (byte)i,
                     Convert.ToUInt16(E_Segment_Start[i].Text), Convert.ToUInt16(E_Segment_Stop[i].Text));
            }
        }
        private void Read_TC_Time()
        {
            uint data = 0;
            Status = LSI3181.LSI3181_TC_read(Status_Data.Card_ID, 2, ref data);
            CurrentCounter_Label.Text = data.ToString();
        }
        private void CurrentValue_Button_Click(object sender, EventArgs e)
        {
            Status = LSI3181.LSI3181_timer_set(Status_Data.Card_ID, Convert.ToUInt16(CurrentValue_TextBox.Text));
        }
        private void CurrentValueClean_Button_Click(object sender, EventArgs e)
        {
            Status = LSI3181.LSI3181_timer_set(Status_Data.Card_ID, 0);
            Status = LSI3181.LSI3181_timer_stop(Status_Data.Card_ID);

        }
        private void ShowTimerIrqMask_Button_Click(object sender, EventArgs e)
        {

        }
        private void Start_Button_Click(object sender, EventArgs e)
        {
            Status = LSI3181.LSI3181_timer_start(Status_Data.Card_ID);
        }
        private void Stop_Button_Click(object sender, EventArgs e)
        {
            Status = LSI3181.LSI3181_timer_stop(Status_Data.Card_ID);
        }
        private void CurrentValue_TextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurrentPeriod_Label.Text = "T=" + String.Format("{0:0.0000}", ((Convert.ToDouble(CurrentValue_TextBox.Text) + 1) * 0.000001)) + "S";
            }
            catch(Exception ex)
            {
                
            }           
        }
        private void CompareAction()
        {
            byte mode = 0;

            if(CB_Encode_Input_Mode.SelectedIndex == 0)
            {
                CB_Encode_Multiple_Rate.Enabled = true;
            }
            else
                CB_Encode_Multiple_Rate.Enabled = false;

            if(CB_CMP_Mode.SelectedIndex == 1)
            {
                E_Duty_Cycle.Enabled = true;
            }
            else
                E_Duty_Cycle.Enabled = false;
 
            if(CB_HomingMode.SelectedIndex == 6 || CB_HomingMode.SelectedIndex == 7)
            {
                E_Continuous_Count.Enabled = true;
            }
            else
                E_Continuous_Count.Enabled = false;
            
            Status = LSI3181.LSI3181_counter_mode_read(Convert.ToByte( CB_Card_ID.Text), ref mode);

            if(mode == 0)
            {
                Status = LSI3181.LSI3181_counter_start(Convert.ToByte(CB_Card_ID.Text), 1);
            }
        }

        private void B_FIFO_Clear_Click_1(object sender, EventArgs e)
        {

        }

        private void B_FIFO_File_Set_Click_1(object sender, EventArgs e)
        {

        }
    }
}
