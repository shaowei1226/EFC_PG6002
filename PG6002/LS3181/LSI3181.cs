using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Timers;

namespace XiZhi
{
    public class LSI3181
    {
        public const short LSI3181_CARD_ID_MAX = 15;
        public const short LSI3181_IN_POINT_MAX = 7;
        public const short LSI3181_OUT_POINT_MAX = 7;
        public const short I_PORT0 = 0;

        public const short O_PORT0 = 1;

        ////////// Error Code ///////////////////////
        public const short JSDRV_NO_ERROR = 0;

        ///************ Driver Error ***************/
        public const short JSDRV_READ_DATA_ERROR = 1;
        public const short JSDRV_INIT_ERROR = 2;

        ///************ Device Error ***************/
        public const short DEVICE_IO_ERROR = 100;
        public const short JSDRV_NO_CARD = 101;
        public const short JSDRV_DUPLICATE_ID = 102;
        public const short JSDRV_ID_ERROR = 103;
        public const short JSDRV_PAR_ERROR = 104;

        ///************ User Parameter Error ********/
        public const short JSDIO_ID_ERROR = 300;
        public const short JSDIO_PORT_ERROR = 301;
        public const short JSDIO_IN_POINT_ERROR = 302;
        public const short JSDIO_OUT_POINT_ERROR = 303;
        ///********************************************/
        public const short JSLSI_ID_ERROR = 300;
        public const short JSLSI_COUNTER_MODE_ERROR = 301;
        public const short JSLSI_TIMER_CONSTANT_ERROR = 302;
        public const short JSLSI_CI_MODE_ERROR = 303;
        public const short JSLSI_MULTIPLE_RATE_ERROR = 304;
        public const short JSLSI_POINT_ERROR = 305;
        public const short JSLSI_CO_ERROR = 306;
        public const short JSLSI_HOME_MODE_ERROR = 307;
        public const short JSLSI_COMPARE_MODE_ERROR = 308;
        public const short JSLSI_POLARITY_ERROR = 309;

        public const short JSLSI_INCREMENT_ERROR = 311;
        public const short JSLSI_COMPARE_OUT_MODE_ERROR = 312;
        public const short JSLSI_FIFO_FULL_ERROR = 313;
        public const short JSLSI_FIFO_EMPTY_ERROR = 314;
        public const short JSLSI_FIFO_ERROR = 315;
        public const short JSLSI_THRESHOLD_ERROR = 316;
        public const short JSLSI_COUNTER_ERROR = 317;
        public const short JSLSI_IRQ_MK_ERROR = 318;
        public const short JSLSI_DRIVER_NOT_SUPPORT = 400;

        ////-----------------------------------------------
        public const short PORT_ERROR = 500;
        public const short DEBOUNCE_MODE_ERROR = 501;
        public const short INDEX_ERROR = 502;
        public const short SOURCE_ERROR = 503;



        public const short LOCK_RELEE = 0;
        public const short LOCKED = 1;
        public const short CARD_LOCKED_OVER = 2;



        //************* card open/close******************************************************/
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_initial();
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_close();
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_info(byte CardID, ref  ushort IO_address, ref  ushort TC_address);

        //--------------------------DIO--------------------------------------------------------
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_port_polarity_set(byte CardID, byte port, byte polarity);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_port_polarity_read(byte CardID, byte port, ref byte polarity);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

        public static extern int LSI3181_debounce_time_set(byte CardID, byte debounce_time);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_debounce_time_read(byte CardID, ref byte debounce_time);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_port_set(byte CardID, byte port, byte data);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_port_read(byte CardID, byte port, ref byte data);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_point_set(byte CardID, byte port, byte point, byte state);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_point_read(byte CardID, byte port, byte point, ref byte state);

        //----------------------------TC-------------------------------------------------------
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_timer_set(byte CardID, uint time_constant);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_timer_start(byte CardID);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_timer_stop(byte CardID);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_TC_set(byte CardID, byte index, uint data);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_TC_read(byte CardID, byte index, ref uint data);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CIO_polarity_set(byte CardID, ushort polarity);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CIO_polarity_read(byte CardID, ref ushort polarity);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CIO_read(byte CardID, ref byte CIO_state);		//20081013
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CI_mode_set(byte CardID, byte in_mode, byte debounce_time, byte multiple_rate);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CI_mode_read(byte CardID, ref byte in_mode, ref byte debounce_time, ref byte multiple_rate);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CO_mode_set(byte CardID, byte out_mode, byte gate, ushort out_width);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CO_mode_read(byte CardID, ref byte out_mode, ref byte gate, ref ushort out_width);


        //-------------------homing & Compare-----------------------------------------------------------
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_HOMING_mode_set(byte CardID, byte homing_mode, ushort z_count, byte single_cont);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_HOMING_mode_read(byte CardID, ref byte homing_mode, ref ushort z_count, ref byte single_cont);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_mode_set(byte CardID, byte compare_mode);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_mode_read(byte CardID, ref byte compare_mode);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_counter_set(byte CardID, int counter_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_counter_read(byte CardID, ref int counter_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_value_set(byte CardID, int compare_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_value_read(byte CardID, ref int compare_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_increment_set(byte CardID, int increment_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_increment_read(byte CardID, ref int increment_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_FIFO_set(byte CardID, int[] FIFO_data, byte rel_abs, ushort size);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_FIFO_threshold_set(byte CardID, ushort threshold_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_FIFO_threshold_read(byte CardID, ref ushort threshold_value);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_FIFO_unused_read(byte CardID, ref ushort unused_count);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_FIFO_clear(byte CardID);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_counter_start(byte CardID, byte mode);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_counter_stop(byte CardID);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_counter_mode_read(byte CardID, ref byte mode);
        //-------------------------------------------------------------------------------------------------
        //-------------------Compare out trigger ----------------------------------------------------------//20090313
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_segment_control_read(byte CardID, byte index, ref byte control);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_segment_control_write(byte CardID, byte index, byte control);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_cmp_segment_read(byte CardID, byte index, ref uint start, ref uint stop);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_cmp_segment_write(byte CardID, byte index, uint start, uint stop);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_mask_off_read(byte CardID, ref byte attribute);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_mask_off_write(byte CardID, byte attribute);

        //-------------------Compare offset-----------------------------------------------------------------------------

        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_set(byte CardID, byte channel, Int16 offset);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_read(byte CardID, byte channel, ref Int16 offset);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_out_width_set(byte CardID, byte channel, UInt16 out_width);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_out_width_read(byte CardID, byte channel, ref UInt16 out_width);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_mask_set(byte CardID, byte make);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_mask_read(byte CardID, ref byte make);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_output_set(byte CardID, byte data);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_output_read(byte CardID, ref byte data);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_output_point_set(byte CardID, byte point, byte state);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_offset_output_point_read(byte CardID, byte point, ref byte state);

        //--------------------Interrupt--------------------------------------------------------
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_IRQ_mask_set(byte CardID, byte source, byte mask);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_IRQ_mask_read(byte CardID, byte source, ref byte mask);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

        public static extern int LSI3181_IRQ_process_link(byte CardID, IRQ_Process lpIRQ_Process);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_IRQ_enable(byte CardID, ref uint phEvent);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_IRQ_disable(byte CardID);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_IRQ_status_read(byte CardID, byte source, ref byte Event_Status);

        //----------------------------security--------------------------------------------------
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_password_set(byte CardID, ushort[] Password);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_password_change(byte CardID, ushort[] OldPassword, ushort[] Password);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_password_clear(byte CardID, ushort[] Password);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_security_unlock(byte CardID, ushort[] Password);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_security_status_read(byte CardID, ref byte lock_status, ref byte security_enable);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_password_set_default(byte CardID);

        //------------------------------------------------------------------------------------------
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_CO_read(byte CardID, ref byte compare_out);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_toggle_preset(byte CardID, byte preset);

        //------------------------------------------------------------------------------------------
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_CMP_OUT_set(byte CardID, byte polarity, byte out_mode, UInt16 out_width);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_CMP_OUT_read(byte CardID, ref byte polarity, ref byte out_mode, ref UInt16 out_width);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_GATE_enable(byte CardID, byte polarity);
        [DllImport("LSI3181_64.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int LSI3181_compare_GATE_disable(byte CardID);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void IRQ_Process(byte CardID);
    }
    //-------------------------------------------------------------------------- 
    public enum emLSI_COUNTER { STOP = 0, RUN = 1, CMP = 2 }
    public enum emLSI_COMPARE_MODE { SINGLE = 0, FIFO = 1, AUTO_INC = 2 }
    public enum emLSI_INPUT_MODE { AB = 0, CW_CCW = 1, CLOCK_DIR = 2 }
    public enum emLSI_DEBOUNCE_TIME { T512K = 0, T1M = 1, T2M = 2, T4M = 3, T8M = 4, T10M = 5, T16M = 6 }
    public enum emLSI_MULTIPLE_RATE { X4 = 0, X2 = 1, X1 = 2 }
    public enum emLSI_CMP_OUT { LOW = 0, HI = 1 }
    public enum emLSI_OUT_MODE { NO_USED = 0, PULSE = 1, LEVEL = 2, TOGGLE = 3 }
    public enum emLSI_PORT_TYPE { IN_PUT = 0, OUT_PUT = 1 }
    public enum emLSI_Debounce_MODE { NO_DEBOUNCE = 0, F_100_HZ, F_200_HZ, F_1K_HZ } ;
    public enum emLSI_FIFO_Rel_Abs { Rel = 0, Abs = 1 } ;

    public enum emLSI_IRQ_Source { IO_BLOCK = 0, T_C_BLOCK};
    //-------------------------------------------------------------------------- 
    #region byte struct
    //byte struct 
    [StructLayout(LayoutKind.Explicit, Size = 1)]
    public struct st_Byte
    {
        [FieldOffset(0)]
        public byte Value; 
        //bit
        [FieldOffset(0)]
        private byte bit00;
        [FieldOffset(0)]
        private byte bit01;
        [FieldOffset(0)]
        private byte bit02;
        [FieldOffset(0)]
        private byte bit03;
        [FieldOffset(0)]
        private byte bit04;
        [FieldOffset(0)]
        private byte bit05;
        [FieldOffset(0)]
        private byte bit06;
        [FieldOffset(0)]
        private byte bit07;
        //Bit
        public byte Bit00
        {
            set
            {
                if (value == 1)
                    bit00 = (byte)(bit00 | 0x01);
                if (value == 0)
                    bit00 = (byte)(bit00 & 0xFE);
            }
            get
            {
                if ((bit00 & 0x01) == 0x01)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit01
        {
            set
            {
                if (value == 1)
                    bit01 = (byte)(bit01 | 0x02);
                if (value == 0)
                    bit01 = (byte)(bit01 & 0xFD);
            }
            get
            {
                if ((bit01 & 0x02) == 0x02)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit02
        {
            set
            {
                if (value == 1)
                    bit02 = (byte)(bit02 | 0x04);
                if (value == 0)
                    bit02 = (byte)(bit02 & 0xFB);
            }
            get
            {
                if ((bit02 & 0x04) == 0x04)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit03
        {
            set
            {
                if (value == 1)
                    bit03 = (byte)(bit03 | 0x08);
                if (value == 0)
                    bit03 = (byte)(bit03 & 0xF7);
            }
            get
            {
                if ((bit03 & 0x08) == 0x08)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit04
        {
            set
            {
                if (value == 1)
                    bit04 = (byte)(bit04 | 0x10);
                if (value == 0)
                    bit04 = (byte)(bit04 & 0xEF);
            }
            get
            {
                if ((bit04 & 0x10) == 0x10)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit05
        {
            set
            {
                if (value == 1)
                    bit05 = (byte)(bit05 | 0x20);
                if (value == 0)
                    bit05 = (byte)(bit05 & 0xDF);
            }
            get
            {
                if ((bit05 & 0x20) == 0x20)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit06
        {
            set
            {
                if (value == 1)
                    bit06 = (byte)(bit06 | 0x40);
                if (value == 0)
                    bit06 = (byte)(bit06 & 0xBF);
            }
            get
            {
                if ((bit06 & 0x40) == 0x40)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit07
        {
            set
            {
                if (value == 1)
                    bit07 = (byte)(bit07 | 0x80);
                if (value == 0)
                    bit07 = (byte)(bit07 & 0x7F);
            }
            get
            {
                if ((bit07 & 0x80) == 0x80)
                    return 1;
                else
                    return 0;
            }
        }        
    }
    #endregion  

    #region ushort struct
    //byte struct 
    [StructLayout(LayoutKind.Explicit, Size = 2)]
    public struct st_UShort
    {
        [FieldOffset(0)]
        public ushort Value;
        //bit
        [FieldOffset(0)]
        private byte bit00;
        [FieldOffset(0)]
        private byte bit01;
        [FieldOffset(0)]
        private byte bit02;
        [FieldOffset(0)]
        private byte bit03;
        [FieldOffset(0)]
        private byte bit04;
        [FieldOffset(0)]
        private byte bit05;
        [FieldOffset(0)]
        private byte bit06;
        [FieldOffset(0)]
        private byte bit07;
        [FieldOffset(1)]
        private byte bit08;
        [FieldOffset(1)]
        private byte bit09;
        [FieldOffset(1)]
        private byte bit0a;
        [FieldOffset(1)]
        private byte bit0b;
        [FieldOffset(1)]
        private byte bit0c;
        [FieldOffset(1)]
        private byte bit0d;
        [FieldOffset(1)]
        private byte bit0e;
        [FieldOffset(1)]
        private byte bit0f;
        //Bit
        public byte Bit00
        {
            set
            {
                if (value == 1)
                    bit00 = (byte)(bit00 | 0x01);
                if (value == 0)
                    bit00 = (byte)(bit00 & 0xFE);
            }
            get
            {
                if ((bit00 & 0x01) == 0x01)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit01
        {
            set
            {
                if (value == 1)
                    bit01 = (byte)(bit01 | 0x02);
                if (value == 0)
                    bit01 = (byte)(bit01 & 0xFD);
            }
            get
            {
                if ((bit01 & 0x02) == 0x02)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit02
        {
            set
            {
                if (value == 1)
                    bit02 = (byte)(bit02 | 0x04);
                if (value == 0)
                    bit02 = (byte)(bit02 & 0xFB);
            }
            get
            {
                if ((bit02 & 0x04) == 0x04)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit03
        {
            set
            {
                if (value == 1)
                    bit03 = (byte)(bit03 | 0x08);
                if (value == 0)
                    bit03 = (byte)(bit03 & 0xF7);
            }
            get
            {
                if ((bit03 & 0x08) == 0x08)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit04
        {
            set
            {
                if (value == 1)
                    bit04 = (byte)(bit04 | 0x10);
                if (value == 0)
                    bit04 = (byte)(bit04 & 0xEF);
            }
            get
            {
                if ((bit04 & 0x10) == 0x10)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit05
        {
            set
            {
                if (value == 1)
                    bit05 = (byte)(bit05 | 0x20);
                if (value == 0)
                    bit05 = (byte)(bit05 & 0xDF);
            }
            get
            {
                if ((bit05 & 0x20) == 0x20)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit06
        {
            set
            {
                if (value == 1)
                    bit06 = (byte)(bit06 | 0x40);
                if (value == 0)
                    bit06 = (byte)(bit06 & 0xBF);
            }
            get
            {
                if ((bit06 & 0x40) == 0x40)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit07
        {
            set
            {
                if (value == 1)
                    bit07 = (byte)(bit07 | 0x80);
                if (value == 0)
                    bit07 = (byte)(bit07 & 0x7F);
            }
            get
            {
                if ((bit07 & 0x80) == 0x80)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit08
        {
            set
            {
                if (value == 1)
                    bit08 = (byte)(bit08 | 0x01);
                if (value == 0)
                    bit08 = (byte)(bit08 & 0xFE);
            }
            get
            {
                if ((bit08 & 0x01) == 0x01)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit09
        {
            set
            {
                if (value == 1)
                    bit09 = (byte)(bit09 | 0x02);
                if (value == 0)
                    bit09 = (byte)(bit09 & 0xFD);
            }
            get
            {
                if ((bit09 & 0x02) == 0x02)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit10
        {
            set
            {
                if (value == 1)
                    bit0a = (byte)(bit0a | 0x04);
                if (value == 0)
                    bit0a = (byte)(bit0a & 0xFB);
            }
            get
            {
                if ((bit0a & 0x04) == 0x04)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit11
        {
            set
            {
                if (value == 1)
                    bit0b = (byte)(bit0b | 0x08);
                if (value == 0)
                    bit0b = (byte)(bit0b & 0xF7);
            }
            get
            {
                if ((bit0b & 0x08) == 0x08)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit12
        {
            set
            {
                if (value == 1)
                    bit0c = (byte)(bit0c | 0x10);
                if (value == 0)
                    bit0c = (byte)(bit0c & 0xEF);
            }
            get
            {
                if ((bit0c & 0x10) == 0x10)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit13
        {
            set
            {
                if (value == 1)
                    bit0d = (byte)(bit0d | 0x20);
                if (value == 0)
                    bit0d = (byte)(bit0d & 0xDF);
            }
            get
            {
                if ((bit0d & 0x20) == 0x20)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit14
        {
            set
            {
                if (value == 1)
                    bit0e = (byte)(bit0e | 0x40);
                if (value == 0)
                    bit0e = (byte)(bit0e & 0xBF);
            }
            get
            {
                if ((bit0e & 0x40) == 0x40)
                    return 1;
                else
                    return 0;
            }
        }
        public byte Bit15
        {
            set
            {
                if (value == 1)
                    bit0f = (byte)(bit0f | 0x80);
                if (value == 0)
                    bit0f = (byte)(bit0f & 0x7F);
            }
            get
            {
                if ((bit0f & 0x80) == 0x80)
                    return 1;
                else
                    return 0;
            }
        }
    }
    #endregion  

    //--------------------------------------------------------------------------------------------------------------------------------------
    public struct Mask_Data
    {
        public bool Enabled;
        public short Offset_Compare;
        public ushort Pulse_Width;
    }
    //-------------------------------------------------------------------------- 
    public class TLSI_3181_Data
    {
        public byte Card_ID;
        public byte Debounce_Time;
        public byte CI_Mode, CI_DeBounce_Time, CI_Multiple_Rate;
        public byte Compare_Mode;
        public byte CMP_Out_Polarity, CMP_Mode, CMP_Gate;
        public byte Homing_Mode, Homing_Continuous_Count;
        public byte Compare_Mask;
        public byte Compare_Out;

        public st_Byte IRQ_IO_Mask, IRQ_T_C_Mask;
        public st_Byte IRQ_IO_Status, IRQ_T_C_Status;
        public st_Byte Input_Polarity, Output_Polarity;
        public st_Byte Input_Port, Output_Port;
        public st_Byte Input_Point, Output_Point;
        public st_Byte CIO_State;
     
        public st_UShort IRQ_Status;
        public st_UShort CIO_Polarity_State;

        public ushort Homing_Z_Count;
        public ushort FIFO_Unused_Count;
        public ushort Duty_Cycle;
        public ushort FIFO_Threshold_Value;
                    
        public int Set_Current_Value;
        public int Set_Compare_Value;
        public int Current_Value;
        public int Compare_Value;      
        public int Increment_Value;
        public int test;
    }
    //-------------------------------------------------------------------------- 
}
