using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public static class CC_LinK_IE_Dll
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
        public static extern int mdSendEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref short buf);
        [DllImport("MDFUNC32.dll")]
        public static extern int mdReceiveEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref short buf);
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
    }
}
