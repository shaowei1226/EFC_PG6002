using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO.Ports; 
using System.Timers;
using System.Runtime.InteropServices;
using EFC.Tool;
using EFC.Camera;

namespace EFC.Light
{
    public class TLight_Base
    {
        public int Max_Value = 63;
        public TLight_Channel_List Channels = new TLight_Channel_List();

        public int Channel_Count
        {
            get
            {
                return Channels.Count;
            }
            set
            {
                Channels.Count = value;
                for(int i=0; i<Channels.Count; i++)
                {
                    Channels[i].Light = this;
                }
            }
        }
        public TLight_Base()
        {

        }
        virtual public bool Set_Light(int channel, int value)
        {
            return true;
        }
        

        public int Get_Channel(int channel)
        {
            int result = channel;
            if (channel < 0) result = 0;
            if (channel >= Channel_Count) result = Channel_Count - 1;
            return result;
        }
        public int Get_Value(int value)
        {
            int result = value;
            if (value < 0) result = 0;
            if (value >= Max_Value) result = Max_Value;
            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TLight_Channel_List
    //-----------------------------------------------------------------------------------------------------
    public class TLight_Channel_List : TBase_Class
    {
        public TLight_Channel[] Items = new TLight_Channel[0];

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count;

                old_count = Items.Length;
                Array.Resize(ref Items, value);
                if (value > old_count)
                {
                    for (int i = old_count; i < value; i++)
                        Items[i] = new TLight_Channel();
                }
            }
        }
        public TLight_Channel this[int index]
        {
            get
            {
                TLight_Channel result = null;
                if (index >= 0 && index < Items.Length)
                {
                    result = Items[index];
                }
                return result;
            }
            set
            {
                TLight_Channel data = this[index];

                if (data != null)
                {
                    data.Set(value);
                }
            }
        }
        public TLight_Channel this[string name]
        {
            get
            {
                int index = Get_Index(name);
                return this[index];
            }
            set
            {
                int index = Get_Index(name);
                TLight_Channel data = this[index];

                if (data != null)
                {
                    data.Set(value);
                }
            }
        }
        public TLight_Channel_List()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TLight_Channel_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TLight_Channel_List && dis_base is TLight_Channel_List)
            {
                TLight_Channel_List sor = (TLight_Channel_List)sor_base;
                TLight_Channel_List dis = (TLight_Channel_List)dis_base;

                dis.Count = sor.Count;
                for (int i = 0; i < dis.Items.Length; i++) dis.Items[i].Set(sor.Items[i]);
            }
        }

        public void Set_Default()
        {
            for (int i = 0; i < Items.Length; i++) Items[i].Set_Default();
        }
        public bool Set_Param(TCamera_Base camera)
        {
            bool result = false;
            TForm_Set_Light form = new TForm_Set_Light(camera, this);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Set(form.Param);
                result = true;
            }
            return result;
        }
        public void Set_Data(TLight_Base light, string[] name, int[] value, int[] id, int[] big, int[] small)
        {
            Set_light(light);
            Set_Name(name);
            Set_Value(value);
            Set_ID(id);
            Set_Big_Change(big);
            Set_Small_Change(small);
        }
        public void Set_Data(TLight_Base[] light, string[] name, int[] value, int[] id)
        {
            Set_light(light);
            Set_Name(name);
            Set_Value(value);
            Set_ID(id);
        }
        public void Set_light(TLight_Base light)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                Items[i].Light = light;
            }
        }
        public void Set_light(TLight_Base[] light)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < light.Length) Items[i].Light = light[i];
            }
        }
        public void Set_Name(string[] name)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < name.Length) Items[i].Name = name[i];
            }
        }
        public void Set_Value(int[] value)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < value.Length) Items[i].Value = value[i];
            }
        }
        public void Set_ID(int[] id)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < id.Length) Items[i].ID = id[i];
            }
        }
        public void Set_Big_Change(int[] big)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < big.Length) Items[i].Big_Change = big[i];
            }
        }
        public void Set_Small_Change(int[] small)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < small.Length) Items[i].Small_Change = small[i];
            }
        }
        public void Get_Value(ref int[] value)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < value.Length) value[i] = Items[i].Value;
            }
        }
        public void Add(TLight_Channel data)
        {
            int no = Count;
            Count++;
            Items[no].Set(data);
        }
        public void Add(TLight_Base light, string name, int id, int value, int big_change = 10, int small_change = 1)
        {
            Add(new TLight_Channel(light, name, id, value, big_change, small_change));
        }
        public void Add(TLight_Base light, string name, int id, int value)
        {
            Add(new TLight_Channel(light, name, id, value));
        }
        public void Add(TLight_Base light, string name, int id)
        {
            Add(new TLight_Channel(light, name, id));
        }
        public int Get_Index(string name)
        {
            int result = -1;

            for (int i = 0; i < Items.Length; i++)
            {
                if (name == Items[i].Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TLight_Channel
    //-----------------------------------------------------------------------------------------------------
    public class TLight_Channel : TBase_Class
    {
        public TLight_Base Light = null;
        public string Name;
        public int Value;
        public int ID;
        public int Big_Change = 10;
        public int Small_Change = 1;

        public int Max
        {
            get
            {
                int result = 0;

                if (Light != null)
                {
                    result = Light.Max_Value + Big_Change - 1;
                }
                return result;
            }
        }
        public TLight_Channel()
        {

        }
        public TLight_Channel(TLight_Base light, string name, int id)
        {
            Light = light;
            Name = name;
            ID = id;
        }
        public TLight_Channel(TLight_Base light, string name, int id, int value)
        {
            Set(light, name, id, value);
        }
        public TLight_Channel(TLight_Base light, string name, int id, int value, int big_change = 10, int small_change = 1)
        {
            Set(light, name, id, value, big_change = 10, small_change = 1);
        }
        override public TBase_Class New_Class()
        {
            return new TLight_Channel();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TLight_Channel && dis_base is TLight_Channel)
            {
                TLight_Channel sor = (TLight_Channel)sor_base;
                TLight_Channel dis = (TLight_Channel)dis_base;

                dis.Light = sor.Light;
                dis.Name = sor.Name;
                dis.Value = sor.Value;
                dis.ID = sor.ID;
                dis.Big_Change = sor.Big_Change;
                dis.Small_Change = sor.Small_Change;
            }
        }
        public void Set_Default()
        {
            Name = "預留";
            Value = 0;
            ID = 0;
            Big_Change = 10;
            Small_Change = 1;
        }
        public void Set(TLight_Base light, string name, int id, int value, int big_change = 10, int small_change = 1)
        {
            Light = light;
            Name = name;
            ID = id;
            Big_Change = big_change;
            Small_Change = small_change;
            Value = value;
        }
        public void Set(TLight_Base light, string name, int id, int value)
        {
            Light = light;
            Name = name;
            ID = id;
            Value = value;
        }
        public void Set(TLight_Base light, string name, int id)
        {
            Light = light;
            Name = name;
            ID = id;
        }
        public void Set_Light()
        {
            if (Light != null)
                Light.Set_Light(ID, Value);
        }
    }
}
