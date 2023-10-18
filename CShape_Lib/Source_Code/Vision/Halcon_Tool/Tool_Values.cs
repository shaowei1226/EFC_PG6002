using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;
using EFC.Tool;

namespace EFC.Vision.Halcon
{
    public enum emValue_Type { None, 
                               Region, Image, XLD, ShapeModel, HomMat2D, Measure, Matrix, HTuple,
                               String, Integer, Double}

    public static class Value_Type
    {
        public static ArrayList Get_List()
        {
            ArrayList result = new ArrayList();

            result.Add(emValue_Type.Region);
            result.Add(emValue_Type.Image);
            result.Add(emValue_Type.XLD);
            result.Add(emValue_Type.ShapeModel);
            result.Add(emValue_Type.HomMat2D);
            result.Add(emValue_Type.Measure);
            result.Add(emValue_Type.Matrix);
            result.Add(emValue_Type.HTuple);

            result.Add(emValue_Type.String);
            result.Add(emValue_Type.Integer);
            result.Add(emValue_Type.Double);
            return result;
        }
        public static string Type_To_String(emValue_Type type)
        {
            string result = "";

            switch (type)
            {
                case emValue_Type.Region: result = "Region"; break;
                case emValue_Type.Image: result = "Image"; break;
                case emValue_Type.XLD: result = "XLD"; break;
                case emValue_Type.ShapeModel: result = "ShapeModel"; break;
                case emValue_Type.HomMat2D: result = "HomMat2D"; break;
                case emValue_Type.Measure: result = "Measure"; break;
                case emValue_Type.Matrix: result = "Matrix"; break;
                case emValue_Type.HTuple: result = "HTuple"; break;

                case emValue_Type.String: result = "String"; break;
                case emValue_Type.Integer: result = "Integer"; break;
                case emValue_Type.Double: result = "Double"; break;
            }
            return result;
        }
        public static emValue_Type String_To_Type(string type_str)
        {
            emValue_Type result = emValue_Type.String;

            switch (type_str)
            {
                case "Region":   result = emValue_Type.Region; break;
                case "Image":    result = emValue_Type.Image; break;
                case "XLD":      result = emValue_Type.XLD; break;
                case "HomMat2D": result = emValue_Type.HomMat2D; break;
                case "Measure":  result = emValue_Type.Measure; break;
                case "Matrix":   result = emValue_Type.Matrix; break;
                case "HTuple":   result = emValue_Type.HTuple; break;

                case "String":   result = emValue_Type.String; break;
                case "Integer":  result = emValue_Type.Integer; break;
                case "Double":   result = emValue_Type.Double; break;
            }
            return result;
        }
        public static TTool_Value_Base Create_Value(emValue_Type type)
        {
            TTool_Value_Base result = null;
            switch (type)
            {
                case emValue_Type.Region:     result = new TTool_Value_Region(); break;
                case emValue_Type.Image:      result = new TTool_Value_Image(); break;
                case emValue_Type.XLD:        result = new TTool_Value_Image(); break;
                case emValue_Type.ShapeModel: result = new TTool_Value_ShapeModel(); break;
                case emValue_Type.HomMat2D:   result = new TTool_Value_HomMat2D(); break;
                case emValue_Type.Measure:    result = new TTool_Value_Measure(); break;
                case emValue_Type.Matrix:     result = new TTool_Value_Matrix(); break;
                case emValue_Type.HTuple:     result = new TTool_Value_HTuple(); break;
               
                case emValue_Type.String:     result = new TTool_Value_String(); break;
                case emValue_Type.Integer:    result = new TTool_Value_Integer(); break;
                case emValue_Type.Double:     result = new TTool_Value_Double(); break;
            }
            return result;
        }
        public static TTool_Value_Base Create_Value(string type_str)
        {
            return Create_Value(String_To_Type(type_str));
        }
        public static TTool_Value_Base New_Tool_Value(string name, emValue_Type type)
        {
            TTool_Value_Base result = null;
            switch (type)
            {
                case emValue_Type.Region: result = new TTool_Value_Region(name); break;
                case emValue_Type.Image: result = new TTool_Value_Image(name); break;
                case emValue_Type.XLD: result = new TTool_Value_XLD(name); break;
                case emValue_Type.ShapeModel: result = new TTool_Value_ShapeModel(name); break;
                case emValue_Type.HomMat2D: result = new TTool_Value_HomMat2D(name); break;
                case emValue_Type.Measure: result = new TTool_Value_Measure(name); break;
                case emValue_Type.Matrix: result = new TTool_Value_Matrix(name); break;
                case emValue_Type.HTuple: result = new TTool_Value_HTuple(name); break;

                case emValue_Type.String: result = new TTool_Value_String(name); break;
                case emValue_Type.Integer: result = new TTool_Value_Integer(name); break;
                case emValue_Type.Double: result = new TTool_Value_Double(name); break;
            }
            return result;
        }
    }   

    //-----------------------------------------------------------------------------------------
    //-- TTool_Value_Base
    //-----------------------------------------------------------------------------------------
    abstract public class TTool_Value_Base
    {
        public string Name = "";
        public emValue_Type Value_Type = emValue_Type.String;


        public TTool_Value_Base()
        {
            Set_Default();
        }
        abstract public TTool_Value_Base New_Class();
        abstract public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base);
        abstract public void Set_Default();


        public void Copy(TTool_Value_Base dis)
        {
            Copy(this, dis);
        }
        public TTool_Value_Base Copy()
        {
            TTool_Value_Base result = New_Class();
            Copy(this, result);
            return result;
        }
        public void Set(TTool_Value_Base sor)
        {
            Copy(sor, this);
        }
    }
    public class TTool_Values_Base 
    {
        public TTool_Value_Base[] Values = new TTool_Value_Base[0];
        public emValue_Type Type = emValue_Type.String;

        public int Values_Count
        {
            get
            {
                return Values.Length;
            }
            set
            {
                int old_count = Values.Length;
                Array.Resize(ref Values, value);
                for (int i = old_count; i < value; i++)
                {
                    Add_New_Obj(ref Values[i]);
                }
            }
        }
        public TTool_Values_Base()
        {

        }
        public void Reset()
        {
            Values_Count = 0;
        }
        public virtual void Add_New_Obj(ref TTool_Value_Base in_obj)
        {

        }
        public ArrayList Get_Value_Name_List()
        {
            ArrayList result = new ArrayList();

            for (int i = 0; i < Values_Count; i++) result.Add(Values[i].Name);
            return result;
        }
        public int Find_Index(string name)
        {
            int result = -1;

            for (int i = 0; i < Values_Count; i++)
            {
                if (name == Values[i].Name) { result = i; break; }
            }
            return result;
        }
        public TTool_Value_Base Get_Base_Value(string name)
        {
            TTool_Value_Base result = null;
            int no = -1;

            if (Halcon_Tool.Is_Variable(name))
            {
                no = Find_Index(name);
                if (no >= 0) result = Values[no];
            }
            return result;
        }
    }


    //-----------------------------------------------------------------------------------------
    //-- TTool_Value
    //-----------------------------------------------------------------------------------------

    public class TTool_Value_Region : TTool_Value_Base
    {
        public HRegion Value = new HRegion();

        public TTool_Value_Region()
        {
            Set_Default();
        }
        public TTool_Value_Region(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_Region(string name, HRegion value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_Region();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_Region && dis_base is TTool_Value_Region)
            {
                TTool_Value_Region sor = (TTool_Value_Region)sor_base;
                TTool_Value_Region dis = (TTool_Value_Region)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                JJS_Vision.Copy_Obj(sor.Value, ref dis.Value);
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.Region;
            Value.GenEmptyRegion();
        }

        public void Set_Value(string name, HRegion value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HRegion value)
        {
            if (value != null) Value = value.Clone();
            else value = null;
        }
    }

    public class TTool_Value_Image : TTool_Value_Base
    {
        public HImage Value = new HImage();

        public TTool_Value_Image()
        {
            Set_Default();
        }
        public TTool_Value_Image(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_Image(string name, HImage value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_Image();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_Image && dis_base is TTool_Value_Image)
            {
                TTool_Value_Image sor = (TTool_Value_Image)sor_base;
                TTool_Value_Image dis = (TTool_Value_Image)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                JJS_Vision.Copy_Obj(sor.Value, ref dis.Value);
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.Image;
            Value.GenEmptyObj();
        }

        public void Set_Value(string name, HImage value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HImage value)
        {
            JJS_Vision.Copy_Obj(value ,ref Value);
        }
    }

    public class TTool_Value_XLD : TTool_Value_Base
    {
        public HXLD Value = new HXLD();

        public TTool_Value_XLD()
        {
            Set_Default();
        }
        public TTool_Value_XLD(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_XLD(string name, HXLD value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_XLD();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_XLD && dis_base is TTool_Value_XLD)
            {
                TTool_Value_XLD sor = (TTool_Value_XLD)sor_base;
                TTool_Value_XLD dis = (TTool_Value_XLD)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value.Clone();
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.XLD;
            Value.GenEmptyObj();
        }

        public void Set_Value(string name, HXLD value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HXLD value)
        {
            if (value != null) Value = value.Clone();
            else value = null;
        }
    }

    public class TTool_Value_ShapeModel : TTool_Value_Base
    {
        public HShapeModel Value = new HShapeModel();

        public TTool_Value_ShapeModel()
        {
            Set_Default();
        }
        public TTool_Value_ShapeModel(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_ShapeModel(string name, HShapeModel value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_ShapeModel();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_ShapeModel && dis_base is TTool_Value_ShapeModel)
            {
                TTool_Value_ShapeModel sor = (TTool_Value_ShapeModel)sor_base;
                TTool_Value_ShapeModel dis = (TTool_Value_ShapeModel)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value.Clone();
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.ShapeModel;
            //Value.GenEmptyObj();
        }

        public void Set_Value(string name, HShapeModel value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HShapeModel value)
        {
            if (value != null) Value = value.Clone();
            else value = null;
        }
    }

    public class TTool_Value_HomMat2D : TTool_Value_Base
    {
        public HHomMat2D Value = new HHomMat2D();

        public TTool_Value_HomMat2D()
        {
            Set_Default();
        }
        public TTool_Value_HomMat2D(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_HomMat2D(string name, HHomMat2D value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_HomMat2D();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_HomMat2D && dis_base is TTool_Value_HomMat2D)
            {
                TTool_Value_HomMat2D sor = (TTool_Value_HomMat2D)sor_base;
                TTool_Value_HomMat2D dis = (TTool_Value_HomMat2D)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value.Clone();
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.HomMat2D;
            //Value.GenEmptyObj();
        }

        public void Set_Value(string name, HHomMat2D value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HHomMat2D value)
        {
            if (value != null) Value = value.Clone();
            else value = null;
        }
    }

    public class TTool_Value_Measure : TTool_Value_Base
    {
        public HMeasure Value = new HMeasure();

        public TTool_Value_Measure()
        {
            Set_Default();
        }
        public TTool_Value_Measure(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_Measure(string name, HMeasure value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_Measure();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_Measure && dis_base is TTool_Value_Measure)
            {
                TTool_Value_Measure sor = (TTool_Value_Measure)sor_base;
                TTool_Value_Measure dis = (TTool_Value_Measure)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value.Clone();
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.Measure;
            //Value.GenEmptyObj();
        }

        public void Set_Value(string name, HMeasure value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HMeasure value)
        {
            if (value != null) Value = value.Clone();
            else value = null;
        }
    }

    public class TTool_Value_Matrix : TTool_Value_Base
    {
        public HMatrix Value = new HMatrix();

        public TTool_Value_Matrix()
        {
            Set_Default();
        }
        public TTool_Value_Matrix(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_Matrix(string name, HMatrix value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_Matrix();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_Matrix && dis_base is TTool_Value_Matrix)
            {
                TTool_Value_Matrix sor = (TTool_Value_Matrix)sor_base;
                TTool_Value_Matrix dis = (TTool_Value_Matrix)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value.Clone();
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.Matrix;
            //Value.GenEmptyObj();
        }

        public void Set_Value(string name, HMatrix value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HMatrix value)
        {
            if (value != null) Value = value.Clone();
            else value = null;
        }
    }

    public class TTool_Value_HTuple : TTool_Value_Base
    {
        public HTuple Value = new HTuple();

        public TTool_Value_HTuple()
        {
            Set_Default();
        }
        public TTool_Value_HTuple(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_HTuple(string name, HTuple value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_HTuple();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_HTuple && dis_base is TTool_Value_HTuple)
            {
                TTool_Value_HTuple sor = (TTool_Value_HTuple)sor_base;
                TTool_Value_HTuple dis = (TTool_Value_HTuple)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value.Clone();
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.HTuple;
            Value = 0.0;
        }

        public void Set_Value(string name, HTuple value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(HTuple value)
        {
            if (value != null) Value = value.Clone();
            else value = null;
        }
    }

    public class TTool_Value_String : TTool_Value_Base
    {
        public string Value = "";

        public TTool_Value_String()
        {
            Set_Default();
        }
        public TTool_Value_String(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_String(string name, string value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_String();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_String && dis_base is TTool_Value_String)
            {
                TTool_Value_String sor = (TTool_Value_String)sor_base;
                TTool_Value_String dis = (TTool_Value_String)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value;
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.String;
            Value = "";
        }

        public void Set_Value(string name, string value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(string value)
        {
            Value = value;
        }
    }

    public class TTool_Value_Integer : TTool_Value_Base
    {
        public int Value = 0;

        public TTool_Value_Integer()
        {
            Set_Default();
        }
        public TTool_Value_Integer(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_Integer(string name, int value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_Integer();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_Integer && dis_base is TTool_Value_Integer)
            {
                TTool_Value_Integer sor = (TTool_Value_Integer)sor_base;
                TTool_Value_Integer dis = (TTool_Value_Integer)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value;
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.Integer;
            Value = 0;
        }

        public void Set_Value(string name, int value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(int value)
        {
            Value = value;
        }
    }

    public class TTool_Value_Double : TTool_Value_Base
    {
        public double Value = 0.0;

        public TTool_Value_Double()
        {
            Set_Default();
        }
        public TTool_Value_Double(string name)
        {
            Set_Default();
            Name = name;
        }
        public TTool_Value_Double(string name, double value)
        {
            Set_Default();
            Name = name;
            Set_Value(value);
        }
        override public TTool_Value_Base New_Class()
        {
            return new TTool_Value_Double();
        }
        override public void Copy(TTool_Value_Base sor_base, TTool_Value_Base dis_base)
        {
            if (sor_base is TTool_Value_Double && dis_base is TTool_Value_Double)
            {
                TTool_Value_Double sor = (TTool_Value_Double)sor_base;
                TTool_Value_Double dis = (TTool_Value_Double)dis_base;
                dis.Name = sor.Name;
                dis.Value_Type = sor.Value_Type;
                dis.Value = sor.Value;
            }
        }
        override public void Set_Default()
        {
            Value_Type = emValue_Type.Double;
            Value = 0.0;
        }

        public void Set_Value(string name, double value)
        {
            Name = name;
            Set_Value(value);
        }
        public void Set_Value(double value)
        {
            Value = value;
        }
    }

    //-----------------------------------------------------------------------------------------
    //-- TTool_Values
    //-----------------------------------------------------------------------------------------
    public class TTool_Values : CollectionBase
    {
        public TTool_Values()
        {
        }

        public TTool_Value_Base this[int index]
        {
            get
            {
                TTool_Value_Base result = null;
                if (index >= 0 && index < Count) result = (TTool_Value_Base)List[index];
                return result;
            }
            set
            {
                TTool_Value_Base item = this[index];
                if (item != null) item.Set(value);
            }
        }
        public TTool_Value_Base this[string name]
        {
            get
            {
                return this[Find_Index(name)];
            }
            set
            {
                TTool_Value_Base item = this[Find_Index(name)];
                if (item != null) item.Set(value);
            }
        }
        public int Find_Index(string name)
        {
            int result = -1;
            TTool_Value_Base item = null;

            for (int i = 0; i < Count; i++)
            {
                item = (TTool_Value_Base)List[i];
                if (name == item.Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Copy(TTool_Values sor, TTool_Values dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++)
            {
                dis.Add_Value(sor[i].Copy());
            }
        }
        public void Copy(TTool_Values dis)
        {
            Copy(this, dis);
        }
        public TTool_Values Copy()
        {
            TTool_Values result = new TTool_Values();
            Copy(this, result);
            return result;
        }
        public void Set(TTool_Values sor)
        {
            Copy(sor, this);
        }


        public void Reset()
        {
            List.Clear();
        }
        public virtual void Add_New_Obj(ref TTool_Value_Base in_obj)
        {

        }
        public TTool_Values Get_Values(emValue_Type type)
        {
            TTool_Values result = new TTool_Values();

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Value_Type == type) result.Add_Value(this[i]);
            }
            return result;
        }
        public ArrayList Get_Name_List()
        {
            ArrayList result = new ArrayList();

            for (int i = 0; i < Count; i++) result.Add(this[i].Name);
            return result;
        }
        public ArrayList Get_Vlaue_Type_List()
        {
            ArrayList result = Value_Type.Get_List();
            return result;
        }
        public ArrayList Get_Value_Name_List(emValue_Type type)
        {
            ArrayList result = new ArrayList();
            TTool_Values tmp_values = null;

            switch (type)
            {
                case emValue_Type.Region: tmp_values = Get_Values(emValue_Type.Region); break;
                case emValue_Type.Image: tmp_values = Get_Values(emValue_Type.Image); break;
                case emValue_Type.XLD: tmp_values = Get_Values(emValue_Type.XLD); break;
                case emValue_Type.ShapeModel: tmp_values = Get_Values(emValue_Type.ShapeModel); break;
                case emValue_Type.HomMat2D: tmp_values = Get_Values(emValue_Type.HomMat2D); break;
                case emValue_Type.Measure: tmp_values = Get_Values(emValue_Type.Measure); break;
                case emValue_Type.Matrix: tmp_values = Get_Values(emValue_Type.Matrix); break;
                case emValue_Type.HTuple: tmp_values = Get_Values(emValue_Type.HTuple); break;

                case emValue_Type.String: tmp_values = Get_Values(emValue_Type.String); break;
                case emValue_Type.Integer: tmp_values = Get_Values(emValue_Type.Integer); break;
                case emValue_Type.Double: tmp_values = Get_Values(emValue_Type.Double); break;
            }

            if (tmp_values != null)
                result = tmp_values.Get_Name_List();
            return result;
        }
        public ArrayList Get_Value_Name_List(string value_type)
        {
            return Get_Value_Name_List(Value_Type.String_To_Type(value_type));
        }
        public TTool_Value_Base Get_Base_Value(emValue_Type type, string name)
        {
            TTool_Value_Base result = null;

            if (Halcon_Tool.Is_Variable(name))
            {
                switch (type)
                {
                    case emValue_Type.Region: result = new TTool_Value_Region(name); break;
                    case emValue_Type.Image: result = new TTool_Value_Image(name); break;
                    case emValue_Type.XLD: result = new TTool_Value_XLD(name); break;
                    case emValue_Type.ShapeModel: result = new TTool_Value_ShapeModel(name); break;
                    case emValue_Type.HomMat2D: result = new TTool_Value_HomMat2D(name); break;
                    case emValue_Type.Measure: result = new TTool_Value_Measure(name); break;
                    case emValue_Type.Matrix: result = new TTool_Value_Matrix(name); break;
                    case emValue_Type.HTuple: result = new TTool_Value_HTuple(name); break;

                    case emValue_Type.String: result = new TTool_Value_String(name); break;
                    case emValue_Type.Integer: result = new TTool_Value_Integer(name); break;
                    case emValue_Type.Double: result = new TTool_Value_Double(name); break;
                }
            }
            else
            {
                switch (type)
                {
                    case emValue_Type.String:
                        TTool_Value_String tmp_value_s = new TTool_Value_String();
                        tmp_value_s.Value = name.Substring(1, name.Length - 2);
                        result = tmp_value_s;
                        break;

                    case emValue_Type.Integer:
                        TTool_Value_Integer tmp_value_i = new TTool_Value_Integer();
                        tmp_value_i.Value = Convert.ToInt32(name);
                        result = tmp_value_i;
                        break;

                    case emValue_Type.Double:
                        TTool_Value_Double tmp_value_d = new TTool_Value_Double();
                        tmp_value_d.Value = Convert.ToDouble(name);
                        result = tmp_value_d;
                        break;
                }

            }
            return result;
        }


        public TTool_Value_Base Get_Tool_Value(string name)
        {
            return this[name];
        }
        public TTool_Value_Base Get_Tool_Value(string name, emValue_Type type)
        {
            TTool_Value_Base result = null;
            TTool_Value_Base get_value = this[name];

            if (get_value != null && get_value.Value_Type == type) result = get_value;
            return result;
        }
        public TTool_Value_Region Get_Tool_Value_Region(string name)
        {
            return (TTool_Value_Region)Get_Tool_Value(name, emValue_Type.Region);
        }
        public TTool_Value_Image Get_Tool_Value_Image(string name)
        {
            return (TTool_Value_Image)Get_Tool_Value(name, emValue_Type.Image);
        }
        public TTool_Value_XLD Get_Tool_Value_XLD(string name)
        {
            return (TTool_Value_XLD)Get_Tool_Value(name, emValue_Type.XLD);
        }
        public TTool_Value_ShapeModel Get_Tool_Value_ShapeModel(string name)
        {
            return (TTool_Value_ShapeModel)Get_Tool_Value(name, emValue_Type.ShapeModel);
        }
        public TTool_Value_HomMat2D Get_Tool_Value_HomMat2D(string name)
        {
            return (TTool_Value_HomMat2D)Get_Tool_Value(name, emValue_Type.HomMat2D);
        }
        public TTool_Value_Measure Get_Tool_Value_Measure(string name)
        {
            return (TTool_Value_Measure)Get_Tool_Value(name, emValue_Type.Measure);
        }
        public TTool_Value_Matrix Get_Tool_Value_Matrix(string name)
        {
            return (TTool_Value_Matrix)Get_Tool_Value(name, emValue_Type.Matrix);
        }
        public TTool_Value_HTuple Get_Tool_Value_HTuple(string name)
        {
            return (TTool_Value_HTuple)Get_Tool_Value(name, emValue_Type.HTuple);
        }
        public TTool_Value_String Get_Tool_Value_String(string name)
        {
            return (TTool_Value_String)Get_Tool_Value(name, emValue_Type.String);
        }
        public TTool_Value_Integer Get_Tool_Value_Integer(string name)
        {
            return (TTool_Value_Integer)Get_Tool_Value(name, emValue_Type.Integer);
        }
        public TTool_Value_Double Get_Tool_Value_Double(string name)
        {
            return (TTool_Value_Double)Get_Tool_Value(name, emValue_Type.Double);
        }

        public HRegion Get_Value_Region(string name)
        {
            HRegion result = null;
            TTool_Value_Region get_value = Get_Tool_Value_Region(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public HImage Get_Value_Image(string name)
        {
            HImage result = null;
            TTool_Value_Image get_value = Get_Tool_Value_Image(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public HXLD Get_Value_XLD(string name)
        {
            HXLD result = null;
            TTool_Value_XLD get_value = Get_Tool_Value_XLD(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public HShapeModel Get_Value_ShapeModel(string name)
        {
            HShapeModel result = null;
            TTool_Value_ShapeModel get_value = Get_Tool_Value_ShapeModel(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public HHomMat2D Get_Value_HomMat2D(string name)
        {
            HHomMat2D result = null;
            TTool_Value_HomMat2D get_value = Get_Tool_Value_HomMat2D(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public HMeasure Get_Value_Measure(string name)
        {
            HMeasure result = null;
            TTool_Value_Measure get_value = Get_Tool_Value_Measure(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public HMatrix Get_Value_Matrix(string name)
        {
            HMatrix result = null;
            TTool_Value_Matrix get_value = Get_Tool_Value_Matrix(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public HTuple Get_Value_HTuple(string name)
        {
            HTuple result = null;
            TTool_Value_HTuple get_value = Get_Tool_Value_HTuple(name);
            if (get_value != null) result = get_value.Value;
            return result;
        }
        public string Get_Value_String(string name)
        {
            string result = "";
            if (Halcon_Tool.Is_Variable(name))
            {
                TTool_Value_String get_value = Get_Tool_Value_String(name);
                if (get_value != null) result = get_value.Value;
            }
            else
            {
                result = name.Replace("'", "");
            }
            return result;
        }
        public int Get_Value_Integer(string name)
        {
            int result = 0;
            if (Halcon_Tool.Is_Variable(name))
            {
                TTool_Value_Integer get_value = Get_Tool_Value_Integer(name);
                if (get_value != null) result = get_value.Value;
            }
            else
            {
                result = Convert.ToInt32(name);
            }
            return result;
        }
        public double Get_Value_Double(string name)
        {
            double result = 0;
            if (Halcon_Tool.Is_Variable(name))
            {
                TTool_Value_Double get_value = Get_Tool_Value_Double(name);
                if (get_value != null) result = get_value.Value;
            }
            else
            {
                result = Convert.ToDouble(name);
            }
            return result;
        }


        public bool Set_Value(TTool_Value_Base in_value)
        {
            bool result = false;

            if (in_value != null)
            {
                switch (in_value.Value_Type)
                {
                    case emValue_Type.Region: result = Set_Region(in_value.Name, ((TTool_Value_Region)in_value).Value); break;
                    case emValue_Type.Image: result = Set_Image(in_value.Name, ((TTool_Value_Image)in_value).Value); break;
                    case emValue_Type.XLD: result = Set_XLD(in_value.Name, ((TTool_Value_XLD)in_value).Value); break;
                    case emValue_Type.ShapeModel: result = Set_ShapeModel(in_value.Name, ((TTool_Value_ShapeModel)in_value).Value); break;
                    case emValue_Type.HomMat2D: result = Set_HomMat2D(in_value.Name, ((TTool_Value_HomMat2D)in_value).Value); break;
                    case emValue_Type.Measure: result = Set_Measure(in_value.Name, ((TTool_Value_Measure)in_value).Value); break;
                    case emValue_Type.Matrix: result = Set_Matrix(in_value.Name, ((TTool_Value_Matrix)in_value).Value); break;
                    case emValue_Type.HTuple: result = Set_HTuple(in_value.Name, ((TTool_Value_HTuple)in_value).Value); break;

                    case emValue_Type.String: result = Set_String(in_value.Name, ((TTool_Value_String)in_value).Value); break;
                    case emValue_Type.Integer: result = Set_Integer(in_value.Name, ((TTool_Value_Integer)in_value).Value); break;
                    case emValue_Type.Double: result = Set_Double(in_value.Name, ((TTool_Value_Double)in_value).Value); break;
                }
            }
            return result;
        }
        public void Set_Value_In(TCommand_Values_List cmd_values, TTool_Values in_values)
        {
            TTool_Value_Base get_value = null;
            TTool_Value_Base new_value = null;

            for (int i = 0; i < cmd_values.Values_Count; i++)
            {
                if (Halcon_Tool.Is_Variable(cmd_values.Values[i].Value))
                {

                    get_value = in_values.Get_Tool_Value(cmd_values.Values[i].Value, cmd_values.Values[i].Type);
                    if (get_value != null)
                    {
                        new_value = get_value.Copy();
                        new_value.Name = cmd_values.Values[i].Name;
                        Set_Value(new_value);
                    }
                }
                else
                {
                    switch(cmd_values.Values[i].Type)
                    {
                        case emValue_Type.String:
                            try
                            {
                                string value_s = cmd_values.Values[i].Value;
                                new_value = new TTool_Value_String(cmd_values.Values[i].Name, value_s);
                            }
                            catch { };
                            break;

                        case emValue_Type.Integer:
                            try
                            {       
                                int value_i =  Convert.ToInt32(cmd_values.Values[i].Value);
                                new_value = new TTool_Value_Integer(cmd_values.Values[i].Name, value_i);
                            }
                            catch
                            { };
                           break;

                        case emValue_Type.Double:
                            try
                            {
                                double value_d = Convert.ToDouble(cmd_values.Values[i].Value);
                                new_value = new TTool_Value_Double(cmd_values.Values[i].Name, value_d);
                            }
                            catch
                            { };
                            break;

                    }
                    Set_Value(new_value);
                }
            }
        }
        public void Set_Value_Out(TCommand_Values_List cmd_values, TTool_Values in_values)
        {
            TTool_Value_Base get_value = null;
            TTool_Value_Base new_value = null;

            for (int i = 0; i < cmd_values.Values_Count; i++)
            {
                get_value = in_values.Get_Tool_Value(cmd_values.Values[i].Name, cmd_values.Values[i].Type);
                if (get_value != null)
                {
                    new_value = get_value.Copy();
                    new_value.Name = cmd_values.Values[i].Value;
                    Set_Value(new_value);
                }
            }
        }
        public bool Set_Region(string name, HRegion value)
        {
            bool result = false;
            TTool_Value_Region get_value = Get_Tool_Value_Region(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_Image(string name, HImage value)
        {
            bool result = false;
            TTool_Value_Image get_value = Get_Tool_Value_Image(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_XLD(string name, HXLD value)
        {
            bool result = false;
            TTool_Value_XLD get_value = Get_Tool_Value_XLD(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_ShapeModel(string name, HShapeModel value)
        {
            bool result = false;
            TTool_Value_ShapeModel get_value = Get_Tool_Value_ShapeModel(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_HomMat2D(string name, HHomMat2D value)
        {
            bool result = false;
            TTool_Value_HomMat2D get_value = Get_Tool_Value_HomMat2D(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_Measure(string name, HMeasure value)
        {
            bool result = false;
            TTool_Value_Measure get_value = Get_Tool_Value_Measure(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_Matrix(string name, HMatrix value)
        {
            bool result = false;
            TTool_Value_Matrix get_value = Get_Tool_Value_Matrix(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_HTuple(string name, HTuple value)
        {
            bool result = false;
            TTool_Value_HTuple get_value = Get_Tool_Value_HTuple(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_String(string name, string value)
        {
            bool result = false;
            TTool_Value_String get_value = Get_Tool_Value_String(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_Integer(string name, int value)
        {
            bool result = false;
            TTool_Value_Integer get_value = Get_Tool_Value_Integer(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }
        public bool Set_Double(string name, double value)
        {
            bool result = false;
            TTool_Value_Double get_value = Get_Tool_Value_Double(name);
            if (get_value != null)
            {
                get_value.Set_Value(value);
                result = true;
            }
            return result;
        }


        public void Add_Value(TTool_Values in_values)
        {
            for (int i = 0; i < in_values.Count; i++)
            {
                Add_Value(in_values[i].Copy());
            }
        }
        public void Add_Value(TCommand_Values_List cmd_values)
        {
            TTool_Value_Base new_value = null;

            for (int i = 0; i < cmd_values.Values_Count; i++)
            {
                new_value = Value_Type.New_Tool_Value(cmd_values.Values[i].Name, cmd_values.Values[i].Type);
                Add_Value(new_value);
            }
        }
        public void Add_Value_Out(TCommand_Values_List cmd_values)
        {
            TTool_Value_Base new_value = null;

            for (int i = 0; i < cmd_values.Values_Count; i++)
            {
                new_value = Value_Type.New_Tool_Value(cmd_values.Values[i].Value, cmd_values.Values[i].Type);
                Add_Value(new_value);
            }
        }
        public void Add_Value(TCommand_Define cmd)
        {
            Add_Value(cmd.In);
            Add_Value(cmd.Out);
        }
        public void Add_Value(TCommand_Values_List cmd_values, TTool_Values in_values)
        {
            TTool_Value_Base new_value = null;

            for (int i = 0; i < cmd_values.Values_Count; i++)
            {
                new_value = in_values.Get_Tool_Value(cmd_values.Values[i].Value, cmd_values.Values[i].Type);
                if (new_value != null)
                {
                    Add_Value(new_value.Copy());
                }
            }
        }
        public TTool_Value_Base Add_Value(TTool_Value_Base value)
        {
            TTool_Value_Base result = null;

            if (value != null)
            {
                TTool_Value_Base get_value = Get_Tool_Value(value.Name, value.Value_Type);
                if (get_value != null)
                {
                    result = get_value;
                }
                else
                {
                    List.Add(value);
                    result = value;
                }
            }
            return result;
        }
        public TTool_Value_Base Add_Value(string name, emValue_Type type)
        {
            TTool_Value_Base new_value = Value_Type.New_Tool_Value(name, type);
            return Add_Value(new_value);
        }
        public TTool_Value_Region Add_Region(string name)
        {
            return (TTool_Value_Region)Add_Value(name, emValue_Type.Region);
        }
        public TTool_Value_Image Add_Image(string name)
        {
            return (TTool_Value_Image)Add_Value(name, emValue_Type.Image);
        }
        public TTool_Value_XLD Add_XLD(string name)
        {
            return (TTool_Value_XLD)Add_Value(name, emValue_Type.XLD);
        }
        public TTool_Value_ShapeModel Add_ShapeModel(string name)
        {
            return (TTool_Value_ShapeModel)Add_Value(name, emValue_Type.ShapeModel);
        }
        public TTool_Value_HomMat2D Add_HomMat2D(string name)
        {
            return (TTool_Value_HomMat2D)Add_Value(name, emValue_Type.HomMat2D);
        }
        public TTool_Value_Measure Add_Measure(string name)
        {
            return (TTool_Value_Measure)Add_Value(name, emValue_Type.Measure);
        }
        public TTool_Value_Matrix Add_Matrix(string name)
        {
            return (TTool_Value_Matrix)Add_Value(name, emValue_Type.Matrix);
        }
        public TTool_Value_HTuple Add_HTuple(string name)
        {
            return (TTool_Value_HTuple)Add_Value(name, emValue_Type.HTuple);
        }
        public TTool_Value_String Add_String(string name)
        {
            return (TTool_Value_String)Add_Value(name, emValue_Type.String);
        }
        public TTool_Value_Integer Add_Integer(string name)
        {
            return (TTool_Value_Integer)Add_Value(name, emValue_Type.Integer);
        }
        public TTool_Value_Double Add_Double(string name)
        {
            return (TTool_Value_Double)Add_Value(name, emValue_Type.Double);
        }

    }


}
