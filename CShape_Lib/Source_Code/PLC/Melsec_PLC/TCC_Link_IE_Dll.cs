using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using EFC.Tool;

namespace EFC.PLC.Melsec
{
    public static class CC_Link_IE_Dll
    {
        #region Dll 連結

        [DllImport("MDFUNC32.dll")]
        public static extern short mdOpen(short Chan, short Mode, ref int Path);

        [DllImport("MDFUNC32.dll")]
        public static extern short mdClose(int Path);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdSend(int Path, short Stno, short Devtyp, short devno, ref short size, ref short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdReceive(int Path, short Stno, short Devtyp, short devno, ref short size, ref short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdDevSet(int Path, short Stno, short Devtyp, short devno);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdDevRst(int Path, short Stno, short Devtyp, short devno);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdRandW(int Path, short Stno, ref short dev, ref short buf, short bufsiz);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdRandR(int Path, short Stno, ref short dev, ref short buf, short bufsiz);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdControl(int Path, short Stno, short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdTypeRead(int Path, short Stno, ref short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdBdLedRead(int Path, short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdBdModRead(int Path, short Mode);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdBdModSet(int Path, short Mode);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdBdRst(int Path);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdBdSwRead(int Path, ref short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdBdVerRead(int Path, ref short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdInit(int Path);
        [DllImport("MDFUNC32.dll")]
        public static extern short mdWaitBdEvent(int Path, ref short eventno, int timeout, ref short signaledno, ref short details);
        


        [DllImport("MDFUNC32.dll")]
        public static extern int mdSendEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref byte buf);
        public static int mdSendEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref byte[] buf)
        {
            int result = 0;
            unsafe
            {
                result = mdSendEx(Path, Netno, Stno, Devtyp, devno, ref size, ref buf[0]);
            }
            return result;
        }
        public static int mdSendEx(int Path, int Netno, int Stno, int Devtyp, int devno, byte[] buf)
        {
            int result = 0;
            int size = 0;

            size = buf.Length;
            result = mdSendEx(Path, Netno, Stno, Devtyp, devno, ref size, ref buf);
            return result;
        }
        public static int mdSendEx(int Path, int Netno, int Stno, int Devtyp, int devno, bool[] buf)
        {
            int result = 0;
            int size = 0;

            byte[] tmp_byte = Convert_To_Byte(buf);
            size = tmp_byte.Length;
            result = mdSendEx(Path, Netno, Stno, Devtyp, devno, ref size, ref tmp_byte);
            return result;
        }
        public static int mdSendEx(int Path, int Netno, int Stno, int Devtyp, int devno, ushort[] buf)
        {
            int result = 0;
            int size = 0;

            byte[] tmp_byte = Convert_To_Byte(buf);
            size = tmp_byte.Length;
            result = mdSendEx(Path, Netno, Stno, Devtyp, devno, ref size, ref tmp_byte);
            return result;
        }


        [DllImport("MDFUNC32.dll")]
        public static extern int mdReceiveEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref byte buf);
        public static int mdReceiveEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref byte[] buf)
        {
            int result = 0;
            unsafe
            {
                result = mdReceiveEx(Path, Netno, Stno, Devtyp, devno, ref size, ref buf[0]);
            }
            return result;
        }
        public static int mdReceiveEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref byte[] buf)
        {
            int result = 0;
            int size = 0;
            byte[] tmp_byte = new byte[buf.Length * 2];
            size = tmp_byte.Length;

            result = mdReceiveEx(Path, Netno, Stno, Devtyp, devno, ref size, ref tmp_byte);
            if (result == 0)
            {
                ushort[] tmp_ushort = Convert_To_UShort(tmp_byte);
                if (tmp_ushort.Length == buf.Length)
                    Array.Copy(tmp_ushort, 0, buf, 0, tmp_ushort.Length);
            }
            return result;
        }
        public static int mdReceiveEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref bool[] buf)
        {
            int result = 0;
            int size = 0;
            byte[] tmp_byte = new byte[buf.Length / 8];
            size = tmp_byte.Length;

            result = mdReceiveEx(Path, Netno, Stno, Devtyp, devno, ref size, ref tmp_byte);
            if (result == 0)
            {
                bool[] tmp_bool = Convert_To_Bool(tmp_byte);
                if (tmp_bool.Length == buf.Length)
                    Array.Copy(tmp_bool, 0, buf, 0, tmp_bool.Length);
            }
            return result;
        }
        public static int mdReceiveEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref ushort[] buf)
        {
            int result = 0;
            int size = 0;
            byte[] tmp_byte = new byte[buf.Length * 2];
            size = tmp_byte.Length;

            result = mdReceiveEx(Path, Netno, Stno, Devtyp, devno, ref size, ref tmp_byte);
            if (result == 0)
            {
                ushort[] tmp_ushort = Convert_To_UShort(tmp_byte);
                if (tmp_ushort.Length == buf.Length)
                    Array.Copy(tmp_ushort, 0, buf, 0, tmp_ushort.Length);
            }
            return result;
        }



        [DllImport("MDFUNC32.dll")]
        public static extern int mdDevSetEx(int Path, int Netno, int Stno, int Devtyp, int devno);
        [DllImport("MDFUNC32.dll")]
        public static extern int mdDevRstEx(int Path, int Netno, int Stno, int Devtyp, int devno);
        [DllImport("MDFUNC32.dll")]
        public static extern int mdRandWEx(int Path, int Netno, int Stno, ref int dev, ref short buf, int bufsiz);
        [DllImport("MDFUNC32.dll")]
        public static extern int mdRandREx(int Path, int Netno, int Stno, ref int dev, ref short buf, int bufsiz);
        [DllImport("MDFUNC32.dll")]
        public static extern int mdRemBufWriteEx(int Path, int Netno, int Stno, int Offset, ref int size, ref short data);
        [DllImport("MDFUNC32.dll")]
        public static extern int mdRemBufReadEx(int Path, int Netno, int Stno, int Offset, ref int size, ref short data);
        #endregion

        public static byte[] Convert_To_Byte(bool[] in_data)
        {
            int out_count = in_data.Length / 8;
            byte[] result = new byte[out_count];
            int word_no = 0;
            int bit_no = 0;

            for (int i = 0; i < in_data.Length; i++)
            {
                word_no = i / 8;
                bit_no = i % 8;

                if (word_no < result.Length)
                    JJS_LIB.Set_Bit(ref result[word_no], bit_no, in_data[i]);
            }
            return result;
        }
        public static byte[] Convert_To_Byte(ushort[] in_data)
        {
            byte[] result = new byte[in_data.Length * 2];

            for (int i = 0; i < in_data.Length; i++)
            {
                byte[] tmp_byte = BitConverter.GetBytes(in_data[i]);
                result[i * 2 + 0] = tmp_byte[0];
                result[i * 2 + 1] = tmp_byte[1];
            }
            return result;
        }
        public static bool[] Convert_To_Bool(byte[] in_data)
        {
            bool[] result = new bool[in_data.Length * 8];
            int word_no = 0;
            int bit_no = 0;

            for (int i = 0; i < result.Length; i++)
            {
                word_no = i / 8;
                bit_no = i % 8;

                if (word_no < in_data.Length)
                    result[i] = JJS_LIB.Get_Bit(in_data[word_no], bit_no);
            }
            return result;
        }
        public static ushort[] Convert_To_UShort(byte[] in_data)
        {
            ushort[] result = new ushort[in_data.Length / 2];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = BitConverter.ToUInt16(in_data, i * 2);
            }
            return result;
        }

        public static void Copy(bool[] sor, ref bool[] dis)
        {
            for (int i = 0; i < sor.Length; i++)
            {
                if (i < dis.Length) dis[i] = sor[i];
            }
        }
        public static void Copy(ushort[] sor, ref ushort[] dis)
        {
            for (int i = 0; i < sor.Length; i++)
            {
                if (i < dis.Length) dis[i] = sor[i];
            }
        }
        public static void Copy(short[] sor, ref short[] dis)
        {
            for (int i = 0; i < sor.Length; i++)
            {
                if (i < dis.Length) dis[i] = sor[i];
            }
        }
        public static void Copy(short[] sor, int sor_index, ushort[] dis, int dis_index, int length)
        {
            for(int i=sor_index; i<sor_index + length; i++)
            {
                if (i < sor.Length && i < dis.Length)
                {
                    byte[] s = BitConverter.GetBytes(sor[i]);
                    dis[i] = BitConverter.ToUInt16(s, 0);
                }
            }
        }
        public static void Copy(ushort[] sor, int sor_index, short[] dis, int dis_index, int length)
        {
            for (int i = sor_index; i < sor_index + length; i++)
            {
                if (i < sor.Length && i < dis.Length)
                {
                    byte[] s = BitConverter.GetBytes(sor[i]);
                    dis[i] = BitConverter.ToInt16(s, 0);
                }
            }
        }

    }
}
