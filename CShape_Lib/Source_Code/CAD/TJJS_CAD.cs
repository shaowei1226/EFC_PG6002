using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Tool;

namespace EFC.CAD
{
    public struct stRect_Double
    {
        public double             X1,
                                  Y1,
                                  X2,
                                  Y2;
        public stRect_Double(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        public double Width()
        {
            return Math.Abs(X2 - X1);
        }
        public double Height()
        {
            return Math.Abs(Y2 - Y1);
        }
        public TJJS_Point Center()
        {
            TJJS_Point result = new TJJS_Point();

            result.X = (X1 + X2) / 2;
            result.Y = (Y1 + Y2) / 2;
            return result;
        }
        public void Set_Data(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        public bool InSide(double circle_r, double x, double y)
        {
            bool result = false;
            double r;

            r = x * x + y * y;
            if (r < circle_r * circle_r) result = true;

            return result;
        }
        public bool InSide(double circle_r)
        {
            bool result = false;

            if (InSide(circle_r, X1, Y1) && InSide(circle_r, X1, Y2) &&
               InSide(circle_r, X2, Y1) && InSide(circle_r, X2, Y2)) result = true;
            else result = false;

            return result;
        }
        public bool InSide(double x, double y)
        {
            bool result = false;

            if (x >= X1 && x <= X2 && y >= Y1 && y <= Y2) result = true;
            else result = false;

            return result;
        }
        public bool InSide(stRect_Double rect)
        {
            bool result = false;

            if (InSide(rect.X1, rect.Y1) && InSide(rect.X1, rect.Y2) &&
                InSide(rect.X2, rect.Y1) && InSide(rect.X2, rect.Y2)) result = true;
            else result = false;

            return result;
        }
        public void Swap(ref double a, ref double b)
        {
            double tmp;

            tmp = a;
            a = b;
            b = tmp;
        }
        public void Sort()
        {
            if (X1 > X2) Swap(ref X1, ref X2);
            if (Y1 > Y2) Swap(ref Y1, ref Y2);
        }
        public stRect_Double Rotate()
        {
            stRect_Double result = new stRect_Double();

            result.X1 = Y1;
            result.Y1 = X1;
            result.X2 = Y2;
            result.Y2 = X2;
            return result;
        }
        public int Float_To_Int(double in_v)
        {
            int result = 0;

            if (in_v > 0) result = (int)(in_v + 0.5);
            else result = (int)(in_v - 0.5);

            return result;
        }
        public void Get_IntRect(ref stRect_Double rect)
        {
            rect.X1 = Float_To_Int(X1);
            rect.Y1 = Float_To_Int(Y1);
            rect.X2 = Float_To_Int(X2);
            rect.Y2 = Float_To_Int(Y2);
        }
        public stRect_Double Offset(double in_v)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = X1 - in_v;
            result.Y1 = Y1 - in_v;
            result.X2 = X2 + in_v;
            result.Y2 = Y2 + in_v;
            return result;

        }
        public stRect_Double Offset(double ofs_x, double ofs_y)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = X1 - ofs_x;
            result.Y1 = Y1 - ofs_y;
            result.X2 = X2 + ofs_x;
            result.Y2 = Y2 + ofs_y;
            return result;
        }
        public stRect_Double Offset(TJJS_Point p)
        {
            return Offset(p.X, p.Y);
        }
        public stRect_Double To_Square()
        {
            stRect_Double result = new stRect_Double();
            double dx, dy;

            dx = X2 - X1;
            dy = Y2 - Y1;
            if (dx > dy)
            {
                result = this.Offset(0, (dx - dy) / 2);
            }
            else
            {
                result = this.Offset((dy - dx) / 2, 0);
            };

            return result;
        }
        public stRect_Double Round(int digits)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = Math.Round(X1, digits);
            result.Y1 = Math.Round(Y1, digits);
            result.X2 = Math.Round(X2, digits);
            result.Y2 = Math.Round(Y2, digits);
            return result;
        }
        public static stRect_Double operator +(stRect_Double lobj, double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 + robj;
            result.Y1 = lobj.Y1 + robj;
            result.X2 = lobj.X2 + robj;
            result.Y2 = lobj.Y2 + robj;
            return result;
        }
        public static stRect_Double operator +(stRect_Double lobj, TJJS_Point robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 + robj.X;
            result.Y1 = lobj.Y1 + robj.Y;
            result.X2 = lobj.X2 + robj.X;
            result.Y2 = lobj.Y2 + robj.Y;
            return result;
        }
        public static stRect_Double operator +(stRect_Double lobj, stRect_Double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 + robj.X1;
            result.Y1 = lobj.Y1 + robj.Y1;
            result.X2 = lobj.X2 + robj.X2;
            result.Y2 = lobj.Y2 + robj.Y2;
            return result;
        }
        public static stRect_Double operator -(stRect_Double lobj, double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 - robj;
            result.Y1 = lobj.Y1 - robj;
            result.X2 = lobj.X2 - robj;
            result.Y2 = lobj.Y2 - robj;
            return result;
        }
        public static stRect_Double operator -(stRect_Double lobj, TJJS_Point robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 - robj.X;
            result.Y1 = lobj.Y1 - robj.Y;
            result.X2 = lobj.X2 - robj.X;
            result.Y2 = lobj.Y2 - robj.Y;
            return result;
        }
        public static stRect_Double operator -(stRect_Double lobj, stRect_Double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 - robj.X1;
            result.Y1 = lobj.Y1 - robj.Y1;
            result.X2 = lobj.X2 - robj.X2;
            result.Y2 = lobj.Y2 - robj.Y2;
            return result;
        }
        public static stRect_Double operator *(stRect_Double lobj, double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 * robj;
            result.Y1 = lobj.Y1 * robj;
            result.X2 = lobj.X2 * robj;
            result.Y2 = lobj.Y2 * robj;
            return result;
        }
        public static stRect_Double operator *(stRect_Double lobj, TJJS_Point robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 * robj.X;
            result.Y1 = lobj.Y1 * robj.Y;
            result.X2 = lobj.X2 * robj.X;
            result.Y2 = lobj.Y2 * robj.Y;
            return result;
        }
        public static stRect_Double operator *(stRect_Double lobj, stRect_Double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 * robj.X1;
            result.Y1 = lobj.Y1 * robj.Y1;
            result.X2 = lobj.X2 * robj.X2;
            result.Y2 = lobj.Y2 * robj.Y2;
            return result;
        }
        public static stRect_Double operator /(stRect_Double lobj, double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 / robj;
            result.Y1 = lobj.Y1 / robj;
            result.X2 = lobj.X2 / robj;
            result.Y2 = lobj.Y2 / robj;
            return result;
        }
        public static stRect_Double operator /(stRect_Double lobj, TJJS_Point robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 / robj.X;
            result.Y1 = lobj.Y1 / robj.Y;
            result.X2 = lobj.X2 / robj.X;
            result.Y2 = lobj.Y2 / robj.Y;
            return result;

        }
        public static stRect_Double operator /(stRect_Double lobj, stRect_Double robj)
        {
            stRect_Double result = new stRect_Double();

            result.X1 = lobj.X1 / robj.X1;
            result.Y1 = lobj.Y1 / robj.Y1;
            result.X2 = lobj.X2 / robj.X2;
            result.Y2 = lobj.Y2 / robj.Y2;
            return result;
        }
    }
    public class TJJS_Unit_V
    {
        private double Fi;
        private double Fj;
        private TJJS_Angle FAngle = new TJJS_Angle();

        public double i
        {
            get { return Fi; }
        }
        public double j
        {
            get { return Fj; }
        }
        public TJJS_Angle Angle
        {
            get { return FAngle; }
        }

        public TJJS_Unit_V()
        {
            Set(1, 0);
        }
        public TJJS_Unit_V Copy()
        {
            TJJS_Unit_V result = new TJJS_Unit_V();

            result.Fi = Fi;
            result.Fj = Fj;
            result.FAngle = FAngle.Copy();
            return result;
        }
        public void Set(double i, double j)
        {
            double tmp;

            tmp = Math.Sqrt(Math.Pow(i, 2) + Math.Pow(j, 2));
            if (tmp != 0)
            {
                Fi = i / tmp;
                if (Fi == 0)
                {
                    Fi = 0.00000001;
                }
                Fj = j / tmp;
                FAngle.r = Math.Atan2(Fj, Fi);
            }
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(TJJS_Unit_V v1, TJJS_Unit_V v2)
        {
            bool result;
            if (v1.Fi == v2.Fi && v1.Fj == v2.Fj)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool operator !=(TJJS_Unit_V v1, TJJS_Unit_V v2)
        {
            bool result;
            if (v1.Fi == v2.Fi && v1.Fj == v2.Fj)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            return result;
        }
        //判斷兩向量是否垂直
        public static bool operator ^(TJJS_Unit_V v1, TJJS_Unit_V v2)
        {
            bool result;

            if (v1.Fi != -v2.Fj && v1.Fj != v2.Fi)
            {
                result = true;
            }
            else if (v1.Fi != v2.Fj && v1.Fj != -v2.Fi)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public TJJS_Unit_V Rotate(double ang)        //ang=0~360度
        {
            TJJS_Unit_V result = new TJJS_Unit_V();
            TJJS_Point tmp = new TJJS_Point();

            tmp.Set(i, j);
            tmp = tmp.Rotate(0, 0, ang);
            result.Set(tmp.X, tmp.Y);
            return result;
        }
    }
    public class TJJS_Angle
    {
        //私用變數
        private double FAngle_d;
        private double FAngle_r;

        public TJJS_Angle()
        {
            d = 0;
        }
        public TJJS_Angle(double deg)
        {
            d = deg;
        }
        public TJJS_Angle Copy()
        {
            TJJS_Angle result = new TJJS_Angle();

            result.FAngle_d = FAngle_d;
            result.FAngle_r = FAngle_r;
            return result;
        }
        public double d //度(0~360)
        {
            set
            {
                double limit;
                int a;

                limit = 360;
                a = Convert.ToInt16(value / limit);
                FAngle_d = value - a * limit;
                FAngle_r = FAngle_d * Math.PI / 180;
            }
            get
            {
                return FAngle_d;
            }
        }
        public double r //經度(0~2pi)
        {
            set
            {
                double limit;
                int a;
                limit = 2 * Math.PI;
                a = Convert.ToInt16(value / limit);
                FAngle_r = value - a * limit;
                FAngle_d = FAngle_r * 180 / Math.PI;
            }
            get
            {
                return FAngle_r;
            }
        }
    }
    public class TJJS_Point : TBase_Class
    {
        //私用變數
        public double X;
        public double Y;

        public TJJS_Point()
        {
            X = 0.0;
            Y = 0.0;
        }
        public TJJS_Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public void Set(double x, double y)
        {
            X = x;
            Y = y;
        }
        override public TBase_Class New_Class()
        {
            return new TJJS_Point();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_Point && dis_base is TJJS_Point)
            {
                TJJS_Point sor = (TJJS_Point)sor_base;
                TJJS_Point dis = (TJJS_Point)dis_base;

                dis.X = sor.X;
                dis.Y = sor.Y;
            }
        }
        public static TJJS_Point operator +(TJJS_Point p1, TJJS_Point p2)
        {
            TJJS_Point result = new TJJS_Point();
            result.Set(p1.X + p2.X, p1.Y + p2.Y);
            return result;
        }
        public static TJJS_Point operator -(TJJS_Point p1, TJJS_Point p2)
        {
            TJJS_Point result = new TJJS_Point();
            result.Set(p1.X - p2.X, p1.Y - p2.Y);
            return result;
        }
        public static TJJS_Point operator *(TJJS_Point p1, TJJS_Point p2)
        {
            TJJS_Point result = new TJJS_Point();
            result.Set(p1.X * p2.X, p1.Y * p2.Y);
            return result;
        }
        public static TJJS_Point operator *(TJJS_Point p1, double scale)
        {
            TJJS_Point result = new TJJS_Point();
            result.Set(p1.X * scale, p1.Y * scale);
            return result;
        }
        public static TJJS_Point operator /(TJJS_Point p1, TJJS_Point p2)
        {
            TJJS_Point result = new TJJS_Point();
            if (p2.X == 0 || p2.Y == 0) //異常
            {
                Exception e = new Exception("分母為零");
                throw e;
            }
            result.Set(p1.X / p2.X, p1.Y / p2.Y);
            return result;
        }
        public static TJJS_Point operator /(TJJS_Point p1, double scale)
        {
            TJJS_Point result = new TJJS_Point();
            if (scale == 0)                                //異常
            {
                Exception e = new Exception("分母為零");
                throw e;
            }
            result.Set(p1.X / scale, p1.Y / scale);
            return result;
        }
        public TJJS_Point Rotate(double ang)  //ang = 0~360度
        {
            return Rotate(new TJJS_Point(0,0), ang);
        }
        public TJJS_Point Rotate(TJJS_Point center, double ang)  //ang = 0~360度
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point tmp = new TJJS_Point();
            TJJS_Angle A = new TJJS_Angle();
            A.d = ang;
            tmp = this - center;
            TMatrix MM = new TMatrix(2, 2, new double[] { Math.Cos(A.r), -Math.Sin(A.r), Math.Sin(A.r), Math.Cos(A.r) });
            TMatrix D = new TMatrix(2, 1, new double[] { tmp.X, tmp.Y });
            TMatrix Ans = new TMatrix(2, 1);
            Ans = MM * D;
            tmp.Set(Ans[0, 0], Ans[1, 0]);
            result = tmp + center;
            return result;
        }
        public TJJS_Point Rotate(double Inx, double Iny, double ang)  //ang = 0~360度
        {
            TJJS_Point result = new TJJS_Point();
            TJJS_Point center = new TJJS_Point();
            center.Set(Inx, Iny);
            result = this.Rotate(center, ang);
            return result;
        }
        public TJJS_Point Mirror(TJJS_Line Inl)
        {
            TJJS_Point tmp = new TJJS_Point();
            tmp = Inl.Perpendicular(this);
            return Rotate(tmp, 180);
        }
        public double Dist(TJJS_Point Inp)
        {
            TJJS_Point tmp = new TJJS_Point();
            tmp = Inp - this;
            return Math.Sqrt(tmp.X * tmp.X + tmp.Y * tmp.Y);
        }
        public TJJS_Point Move(TJJS_Point Inp)
        {
            TJJS_Point result = new TJJS_Point();
            result = this + Inp;
            return result;
        }
        public TJJS_Point Move(TJJS_Point In_from, TJJS_Point In_to)
        {
            return Move(In_to - In_from);
        }
        public TJJS_Point Round(int digits)
        {
            TJJS_Point result = new TJJS_Point();

            result.X = Math.Round(X, digits);
            result.Y = Math.Round(Y, digits);
            return result;
        }
    }
    public class TJJS_Line : TBase_Class
    {
        private TJJS_Unit_V FV = new TJJS_Unit_V();
        private TJJS_Point FOver = new TJJS_Point();
        private TJJS_Point FStart = new TJJS_Point();
        private TJJS_Point FEnd = new TJJS_Point();
        private bool FHas_Start;
        private bool FHas_End;

        public TJJS_Line()
        {

        }
        public TJJS_Line(TJJS_Point start, TJJS_Point end, bool has_start = true, bool has_end = true)
        {
            Set(start, end, has_start, has_end);
        }
        public TJJS_Line(double x1, double y1, double x2, double y2, bool has_start = true, bool has_end = true)
        {
            Set(x1, y1, x2, y2, has_start, has_end);
        }
        public TJJS_Line(TJJS_Point over, TJJS_Unit_V v)
        {
            Set(over, v);
        }
        override public TBase_Class New_Class()
        {
            return new TJJS_Line();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_Line && dis_base is TJJS_Line)
            {
                TJJS_Line sor = (TJJS_Line)sor_base;
                TJJS_Line dis = (TJJS_Line)dis_base;

                dis.FV = sor.FV.Copy();
                sor.FOver.Copy(dis.FOver);
                sor.FStart.Copy(dis.FStart);
                sor.FEnd.Copy(dis.FEnd);
                dis.FHas_Start = sor.Has_Start;
                dis.FHas_End = sor.Has_End;
            }
        }
        public TJJS_Unit_V V
        {
            get { return FV; }
            set { FV = value; }
        }
        public TJJS_Point Over
        {
            get { return FOver; }
            set
            {
                TJJS_Point tmp = new TJJS_Point();
                tmp = value - FOver;
                FOver = FOver + tmp;
                FStart = FStart + tmp;
                FEnd = FEnd + tmp;
            }
        }
        public TJJS_Point Start
        {
            get { return FStart; }
            set
            {
                value.Copy(FStart);
                FStart.Copy(FOver);
                FHas_Start = true;
                if (FHas_End)
                {
                    FV.Set(FEnd.X - FStart.X, FEnd.Y - FStart.Y);
                }
            }
        }
        public TJJS_Point End
        {
            get { return FEnd; }
            set
            {
                if (FHas_Start)
                {
                    value.Copy(FEnd);
                    FHas_End = true;
                    FV.Set(FEnd.X - FStart.X, FEnd.Y - FStart.Y);
                }
                else
                {
                    value.Copy(Start);
                }
            }
        }
        public TJJS_Point Mid
        {
            get
            {
                TJJS_Point result = new TJJS_Point();

                if (FHas_Start && FHas_End)
                {
                    result = (FStart + FEnd) / 2;
                }
                else
                {
                    Exception e = new Exception("線段起點&終點有數值未設定");
                    throw e;
                }
                return result;
            }
        }
        public bool Has_Start
        {
            get { return FHas_Start; }
        }
        public bool Has_End
        {
            get { return FHas_End; }
        }
        public void Set(TJJS_Point start, TJJS_Point end, bool has_start = true, bool has_end = true)
        {
            TJJS_Point tmp;

            tmp = end - start;
            start.Copy(FStart);
            end.Copy(FEnd);
            start.Copy(FOver);
            FV.Set(tmp.X, tmp.Y);
            FHas_Start = has_start;
            FHas_End = has_end;
        }
        public void Set(double x1, double y1, double x2, double y2, bool has_start = true, bool has_end = true)
        {
            TJJS_Point start = new TJJS_Point();
            TJJS_Point end = new TJJS_Point();

            start.Set(x1, y1);
            end.Set(x2, y2);
            Set(start, end, has_start, has_end);
        }
        public void Set(TJJS_Point over, TJJS_Unit_V v)
        {
            FV = v;
            over.Copy(FOver);
            FStart = new TJJS_Point();
            FEnd = new TJJS_Point();
            FHas_Start = false;
            FHas_End = false;
        }
        public static TJJS_Line operator *(TJJS_Line l1, double scale)
        {
            TJJS_Line result = new TJJS_Line();
            result.Set(l1.Start * scale, l1.End * scale, l1.Has_Start, l1.FHas_End);
            return result;
        }
        public static TJJS_Line operator /(TJJS_Line l1, double scale)
        {
            TJJS_Line result = new TJJS_Line();
            result.Set(l1.Start / scale, l1.End / scale, l1.Has_Start, l1.FHas_End);
            return result;
        }
        public TJJS_Line Rotate(TJJS_Point center, double ang)
        {
            TJJS_Line result = new TJJS_Line();

            result.FV = V.Rotate(ang);
            result.FOver = Over.Rotate(center, ang);
            result.FStart = Start.Rotate(center, ang);
            result.FEnd = End.Rotate(center, ang);
            result.FHas_Start = Has_Start;
            result.FHas_End = Has_End;
            return result;
        }
        public TJJS_Line Rotate(double x, double y, double ang)
        {
            TJJS_Point center = new TJJS_Point();
            center.Set(x, y);
            return Rotate(center, ang);
        }
        public TJJS_Line Rotate(double ang)
        {
            return Rotate(0, 0, ang);
        }
        public double Dist(TJJS_Point Inp)
        {
            TJJS_Line tmp = new TJJS_Line();
            TJJS_Point pp = new TJJS_Point();
            double result;

            Copy(tmp);
            tmp = tmp.Rotate(90);
            Inp.Copy(tmp.Over);
            pp = Intersect(tmp);
            result = Inp.Dist(pp);
            return result;
        }
        public double Length()
        {
            double result;
            if (FHas_Start && FHas_End)
            {
                result = FStart.Dist(FEnd);
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public TJJS_Point Intersect(TJJS_Line l)
        {
            //Line1, Line2 交點
            double a1, b1, c1, a2, b2, c2;
            TJJS_Point result = new TJJS_Point();

            a1 = -FV.j;
            b1 = FV.i;
            c1 = a1 * FOver.X + b1 * FOver.Y;
            a2 = -l.V.j;
            b2 = l.V.i;
            c2 = a2 * l.Over.X + b2 * l.Over.Y;

            TMatrix MM = new TMatrix(2, 2, new double[] { a1, b1, a2, b2 });
            TMatrix C = new TMatrix(2, 1, new double[] { c1, c2 });
            TMatrix Ans = new TMatrix(2, 1);
            Ans = MM.Inverse() * C;
            result.Set(Ans[0, 0], Ans[1, 0]);
            return result;
        }
        public TJJS_Point Perpendicular(TJJS_Point p)
        {
            //通過 P1 垂直 Line1 交點
            TJJS_Line l = new TJJS_Line();
            l.Set(p, FV.Rotate(90));
            return Intersect(l);
        }
        public TJJS_Line Move(TJJS_Point p)
        {
            TJJS_Line result = new TJJS_Line();
            Copy(result);
            result.FOver = result.FOver + p;
            result.FStart = result.FStart + p;
            result.FEnd = result.FEnd + p;
            return result;
        }
        public TJJS_Line Move(TJJS_Point from, TJJS_Point to)
        {
            return Move(to - from);
        }
    }

    public class TJJS_Circle : TBase_Class
    {
        private double FR;
        private TJJS_Point FCenter = new TJJS_Point();

        public double R
        {
            get { return FR; }
            set { FR = value; }
        }
        public double D
        {
            get
            {
                return (FR * 2);
            }
            set
            {
                FR = value / 2;
            }
        }
        public TJJS_Point Center
        {
            get
            {
                return FCenter;
            }
            set
            {
                value.Copy(FCenter);
            }
        }

        public TJJS_Circle()
        {
            FR = 1;
            FCenter.Set(0, 0);
        }
        public TJJS_Circle(TJJS_Point p1, double r)
        {
            Set(p1, r);
        }
        public TJJS_Circle(TJJS_Point p1, TJJS_Point p2)
        {
            Set(p1, p2);
        }
        public TJJS_Circle(TJJS_Point p1, TJJS_Point p2, TJJS_Point p3)
        {
            Set(p1, p2, p3);
        }
        override public TBase_Class New_Class()
        {
            return new TJJS_Circle();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TJJS_Circle && dis_base is TJJS_Circle)
            {
                TJJS_Circle sor = (TJJS_Circle)sor_base;
                TJJS_Circle dis = (TJJS_Circle)dis_base;
                dis.FR = FR;
                sor.FCenter.Copy(dis.FCenter);
            }
        }
        //圓心+半徑 定圓
        public void Set(TJJS_Point center, double r)
        {
            center.Copy(FCenter);
            FR = r;
        }
        //2點 定圓
        public void Set(TJJS_Point p1, TJJS_Point p2)
        {
            FCenter = (p1 + p2) / 2;
            FR = p1.Dist(p2) / 2;
        }
        //3點 定圓
        public void Set(TJJS_Point p1, TJJS_Point p2, TJJS_Point p3)
        {
            TJJS_Line l1 = new TJJS_Line();
            TJJS_Line l2 = new TJJS_Line();
            TJJS_Line l3 = new TJJS_Line();
            TJJS_Line l4 = new TJJS_Line();
            TJJS_Point Mp1 = new TJJS_Point();
            TJJS_Point Mp2 = new TJJS_Point();

            l1.Set(p1, p2);
            l2.Set(p2, p3);
            l1.Mid.Copy(Mp1);
            l2.Mid.Copy(Mp2);

            l3.Set(l1.Mid, l1.V.Rotate(90));
            l4.Set(l2.Mid, l2.V.Rotate(90));
            FCenter = l3.Intersect(l4);
            FR = FCenter.Dist(p1);
        }
        //2點+夾角 定圓
        public void Set(TJJS_Point p1, TJJS_Point p2, double a)
        {
            TJJS_Line l1 = new TJJS_Line();
            TJJS_Line l2 = new TJJS_Line();
            TJJS_Line l3 = new TJJS_Line();

            l1.Set(p1, p2);
            l2.Set(p1, l1.V.Rotate(90 - a / 2));
            l3.Set(p2, l1.V.Rotate(90 + a / 2));
            FCenter = l2.Intersect(l3);
            FR = FCenter.Dist(p1);
        }
    }
    public class TJJS_Point_3D
    {
        //私用變數
        public double X;
        public double Y;
        public double Z;

        public TJJS_Point_3D()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public TJJS_Point_3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public void Set(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public TJJS_Point_3D Copy()
        {
            TJJS_Point_3D result = new TJJS_Point_3D();

            Copy(ref result);
            return result;
        }
        public void Copy(ref TJJS_Point_3D in_p)
        {
            in_p.X = X;
            in_p.Y = Y;
            in_p.Z = Z;
        }
        public static TJJS_Point_3D operator +(TJJS_Point_3D p1, TJJS_Point_3D p2)
        {
            TJJS_Point_3D result = new TJJS_Point_3D();
            result.Set(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
            return result;
        }
        public static TJJS_Point_3D operator -(TJJS_Point_3D p1, TJJS_Point_3D p2)
        {
            TJJS_Point_3D result = new TJJS_Point_3D();
            result.Set(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
            return result;
        }
        public static TJJS_Point_3D operator *(TJJS_Point_3D p1, TJJS_Point_3D p2)
        {
            TJJS_Point_3D result = new TJJS_Point_3D();
            result.Set(p1.X * p2.X, p1.Y * p2.Y, p1.Z * p2.Z);
            return result;
        }
        public static TJJS_Point_3D operator *(TJJS_Point_3D p1, double scale)
        {
            TJJS_Point_3D result = new TJJS_Point_3D();
            result.Set(p1.X * scale, p1.Y * scale, p1.Z * scale);
            return result;
        }
        public static TJJS_Point_3D operator /(TJJS_Point_3D p1, TJJS_Point_3D p2)
        {
            TJJS_Point_3D result = new TJJS_Point_3D();
            if (p2.X == 0 || p2.Y == 0 || p2.Z == 0) //異常
            {
                Exception e = new Exception("分母為零");
                throw e;
            }
            result.Set(p1.X / p2.X, p1.Y / p2.Y, p1.Z / p2.Z);
            return result;
        }
        public static TJJS_Point_3D operator /(TJJS_Point_3D p1, double scale)
        {
            TJJS_Point_3D result = new TJJS_Point_3D();
            if (scale == 0)                                //異常
            {
                Exception e = new Exception("分母為零");
                throw e;
            }
            result.Set(p1.X / scale, p1.Y / scale, p1.Z / scale);
            return result;
        }
        public TJJS_Point_3D Move(TJJS_Point_3D Inp)
        {
            TJJS_Point_3D result = new TJJS_Point_3D();
            result = this + Inp;
            return result;
        }
        public TJJS_Point_3D Move(TJJS_Point_3D Infrom, TJJS_Point_3D Into)
        {
            return Move(Into - Infrom);
        }
    }
    public class TJJS_Face
    {
        public double A = 1, B = 1, C = 1, D = 1;

        //最小平方誤差法求平面度
        // aX + bY +cZ + d = 0
        public TJJS_Face()
        {
            A = 1;
            B = 1;
            C = 1;
            D = 1;
        }
        public TJJS_Face(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public TJJS_Face(TJJS_Point_3D[] point, int mode = 0)
        {
            Set(point, mode);
        }
        public TJJS_Face Copy()
        {
            TJJS_Face result = new TJJS_Face();

            Copy(ref result);
            return result;
        }
        public void Copy(ref TJJS_Face result)
        {
            result.A = A;
            result.B = B;
            result.C = C;
            result.D = D;
        }
        public bool Set(TJJS_Point_3D[] point, int mode = 0)
        {
            // aX + bY +cZ + d = 0
            // Z = a1 * X  + a2 * Y + a3

            bool result = false;
            double a1 = 0, a2 = 0, a3 = 0;
            result = Get_Face_Mode1(point, ref a1, ref a2, ref a3);
            if (result)
            {
                A = a1;
                B = a2;
                C = -1;
                D = a3;
            }
            return result;
        }
        public bool Get_Face_Mode1(TJJS_Point_3D[] point, ref double a1, ref double a2, ref double a3)
        {
            bool result = false;

            //最小平方誤差法求平面度 公式
            // Z = a1 * X  + a2 * Y + a3
            //  +--        --+   +--  --+   +--  --+
            //  |  XX XY  X  |   |  a1  |   |  XZ  |
            //  |  XY YY  Y  | X |  a2  | = |  YZ  | 
            //  |   X  Y  n  |   |  a3  |   |   Z  |
            //  +--        --+   +--  --+   +--  --+
            //
            //   +--     --+   +--  --+   +--        --+ -1     +--  --+
            //   |  1 0 0  |   |  a1  |   |  XX XY  X  |        |  XZ  |
            //   |  0 1 0  | X |  a2  | = |  XY YY  Y  |     X  |  YZ  | 
            //   |  0 0 1  |   |  a3  |   |   X  Y  n  |        |   Z  |
            //   +--     --+   +--  --+   +--        --+        +--  --+
            try
            {
                double x = 0, y = 0, xx = 0, yy = 0, xy = 0, n = 0;
                double xz = 0, yz = 0, z = 0;
                n = point.Length;
                for (int i = 0; i < point.Length; i++)
                {
                    x = x + point[i].X;
                    y = y + point[i].Y;
                    z = z + point[i].Z;

                    xx = xx + point[i].X * point[i].X;
                    yy = yy + point[i].Y * point[i].Y;
                    xy = xy + point[i].X * point[i].Y;

                    xz = xz + point[i].X * point[i].Z;
                    yz = yz + point[i].Y * point[i].Z;
                }
                TMatrix m1 = new TMatrix(3, 3, new double[] { xx, xy, x, xy, yy, y, x, y, n });
                TMatrix m2 = new TMatrix(3, 1, new double[] { xz, yz, z });
                TMatrix m_inv;
                TMatrix tmp;

                m_inv = m1.Inverse();
                tmp = m_inv * m2;

                a1 = tmp[0, 0];
                a2 = tmp[1, 0];
                a3 = tmp[2, 0];
                result = true;
            }
            catch
            {

            }
            return result;
        }
        public double Get_Pos_Ofs(TJJS_Point_3D point)
        {
            double result = 0;
            result = A * point.X + B * point.Y + C * point.Z + D;
            return result;
        }
        public double[] Get_Pos_Ofs(TJJS_Point_3D[] point)
        {
            double[] result = new double[point.Length];
            for (int i = 0; i < point.Length; i++) result[i] = Get_Pos_Ofs(point[i]);
            return result;
        }
        public double Dist(TJJS_Point_3D point)
        {
            double result = 0;
            //result = Math.Abs(A * point.X + B * point.Y + C * point.Z) /
            result = (A * point.X + B * point.Y + C * point.Z + D) /
                     Math.Sqrt(A * A + B * B + C * C);
            return result;
        }
        public double[] Dist(TJJS_Point_3D[] point)
        {
            double[] result = new double[point.Length];

            for (int i = 0; i < point.Length; i++ )
                result[i] = Dist(point[i]);
            return result;
        }
        public double Dist_Max_Min(TJJS_Point_3D[] point)
        {
            double result = 0;
            double[] point_dist;
            double min, max;

            point_dist = Dist(point);
            min = point_dist.Min();
            max = point_dist.Max();
            result = max - min;
            return result;
        }
        public double Dist_Average(TJJS_Point_3D[] point)
        {
            double result = 0;
            double[] point_dist;

            point_dist = Dist(point);
            result = point_dist.Average();
            return result;
        }
    }
}
