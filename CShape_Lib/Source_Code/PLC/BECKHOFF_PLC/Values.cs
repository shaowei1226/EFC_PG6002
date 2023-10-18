using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace EFC.PLC.BECKHOFF
{
    public enum emValue_Type { None, Bool, Byte, Real, LReal };

    //-----------------------------------------------------------------------------------------------------
    // BECKHOFF 資料結構 
    // 
    // 
    //-----------------------------------------------------------------------------------------------------
    abstract public class TBECKHOFF_Struct_Base
    {
        public string Name = "";

        public TBECKHOFF_Struct_Base()
        {
            Set_Default();
        }
        abstract public TBECKHOFF_Struct_Base New_Class();
        abstract public void Copy(TBECKHOFF_Struct_Base sor_base, TBECKHOFF_Struct_Base dis_base);
        abstract public void Set_Default();
        abstract public int Sizeof();
        abstract public void Read(BinaryReader reader);
        abstract public void Write(BinaryWriter writer);


        public void Copy(TBECKHOFF_Struct_Base dis)
        {
            Copy(this, dis);
        }
        public TBECKHOFF_Struct_Base Copy()
        {
            TBECKHOFF_Struct_Base result = New_Class();
            Copy(this, result);
            return result;
        }
        public void Set(TBECKHOFF_Struct_Base sor)
        {
            Copy(sor, this);
        }
        public void Read_Space_Byte(BinaryReader reader, int count)
        {
            int read_count = 0;
            read_count = (int)reader.BaseStream.Position % count;
            if (read_count != 0) read_count = count - read_count;
            for (int i = 0; i < read_count; i++) reader.ReadByte();
        }
        public void Write_Space_Byte(BinaryWriter writer, int count)
        {
            byte space = 0;
            int read_count = 0;
            read_count = (int)writer.BaseStream.Position % count;
            if (read_count != 0) read_count = count - read_count;
            for (int i = 0; i < read_count; i++) writer.Write(space);
        }
    }
    abstract public class TValue_Base
    {
        public string Name = "";
        public emValue_Type Value_Type = emValue_Type.None;


        public TValue_Base()
        {
            Set_Default();
        }
        abstract public TValue_Base New_Class();
        abstract public void Copy(TValue_Base sor_base, TValue_Base dis_base);
        abstract public void Set_Default();


        public void Copy(TValue_Base dis)
        {
            Copy(this, dis);
        }
        public TValue_Base Copy()
        {
            TValue_Base result = New_Class();
            Copy(this, result);
            return result;
        }
        public void Set(TValue_Base sor)
        {
            Copy(sor, this);
        }
    }



}
