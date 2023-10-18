using System;
using System.Runtime.InteropServices;


namespace AD_LINK
{
    public delegate void CallBack(IntPtr BufferAddress, ushort PortNo);

    class Angelo
    {
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Close(ushort PortNo);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Initial(ushort PortNo);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Software_Reset(ushort PortNo);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Read_Serial(ushort CardNo, ref uint HighByte, ref uint LowByte);


        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_Image_Config(ushort PortNo, byte ConfigIndex, byte Value);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Get_Image_Config(ushort PortNo, byte ConfigIndex, ref byte Value);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_Color_Format(ushort PortNo, byte ColorFormat);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Get_Color_Format(ushort PortNo, ref byte ColorFormat);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_Video_Format(ushort PortNo, byte VideoFormat);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Get_Video_Format(ushort PortNo, ref byte VideoFormat);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_Image_Geometric(ushort PortNo, uint X_Offset, uint Y_Offset, uint X_Active, uint Y_Active, double X_Scale, double Y_Scale);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Capture_Start(ushort PortNo, uint CaptureNo);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Capture_Stop(ushort PortNo);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Select_Channel(ushort PortNo, ushort Multiplex);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Capture_Config(ushort PortNo, uint Start_Field);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Sync_Grab(ushort PortNo, ref uint Start_Address, ref uint Width, ref uint Height, ref uint Size_Byte);



        // Category: GPIO & EPROM
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_GPIO_Sts(ushort PortNo, byte Status);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Get_GPIO_Sts(ushort PortNo, ref byte Status);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Write_EEPROM(ushort CardNo, byte Address, byte Value);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Read_EEPROM(ushort CardNo, byte Address, ref byte Value);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_GPIO_Int_Logic(ushort PortNo, ushort Logic);

        //cPci RTV24 only
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_LED_Sts(ushort PortNo, byte Status);

        // Category: Callback & Thread
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_Callback(ushort PortNo, CallBack CallBackProc);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_Int_Event(ushort PortNo, ref IntPtr hEvent);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Get_Int_Status(ushort PortNo, ref uint IntStatus);


        // Category: Watch dog
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Set_WDT(ushort CardNo, ushort Enable, ushort Interval);

        // Category: Software Trigger
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Trigger_Config(ushort PortNo, ushort Interval);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Trigger_Start(ushort CardNo, ushort Multiplex);

        // Category: Frame Buffer
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Get_Frame(ushort PortNo, ref uint Start_Address, ref uint Width, ref uint Height, ref uint Size_Byte);
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Save_File(ushort PortNo, string FileName, byte FileFormat, int nQuality);//modify 05/06/03, add the nQuality, only for jpeg
        [DllImport("AngeloRTV.dll")]
        public static extern short AngeloRTV_Copy_Frame(ushort PortNo, ref byte Dest_Address, uint Size_Byte);


    }
}