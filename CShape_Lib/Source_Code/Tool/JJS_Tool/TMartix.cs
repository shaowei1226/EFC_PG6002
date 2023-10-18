using System;
using System.Collections.Generic;
using System.Text;

namespace EFC.Tool
{
    public class TMatrix
    {

        //私用變數
        public double[] Data = new double[0];
        private int Col_Count = 0, Row_Count = 0;


        public int Row
        {
            get { return Row_Count; }
        }
        public int Col
        {
            get { return Col_Count; }
        }
        public int Data_Count
        {
            get
            {
                return Data.Length;
            }
            set
            {
                int old_count = Data.Length;
                Array.Resize(ref Data, value);
            }
        }
        // unit = true, 單位矩陣
        public TMatrix(int row, int col, bool unit = false)
        {
            Set(row, col, unit);
        }
        public TMatrix(int row, int col, double[] data)
        {
            Set(row, col, data);
        }
        public TMatrix(TMatrix m)
        {
            Set(m.Row, m.Col, m.Data);
        }
        public void Set(int row, int col, bool unit = false)
        {
            Col_Count = col;
            Row_Count = row;
            Data_Count = Col_Count * Row_Count;
        }
        public void Set(int row, int col, double[] data)
        {
            Set(row, col, false);
            for (int i = 0; i < Data_Count; i++) if (i < data.Length) Data[i] = data[i];
        }
        public TMatrix Copy()
        {
            TMatrix result = new TMatrix(Row, Col, Data);
            return result;
        }
        public void Copy(ref TMatrix in_data)
        {
            in_data.Set(Row, Col, Data);
        }
        private bool Is_Empty()
        {
            return (Col <= 0 || Row <= 0);
        }

        public double this[int row, int col]
        {
            get
            {
                return Data[row * Col_Count + col];
            }
            set
            {
                Data[row * Col_Count + col] = value;
            }
        }
        public static TMatrix operator +(TMatrix lhs, TMatrix rhs)
        {
            TMatrix result = new TMatrix(lhs.Row, lhs.Col);

            if (lhs.Row != rhs.Row)    //異常
            {
                System.Exception e = new Exception("相加的兩個矩陣的行數不等");
                throw e;
            }
            if (lhs.Col != rhs.Col)    //異常
            {
                System.Exception e = new Exception("相加的兩個矩陣的列數不等");
                throw e;
            }

            for (int i = 0; i < lhs.Data_Count; i++)
            {
                result.Data[i] = lhs.Data[i] + rhs.Data[i];
            }
            return result;
        }
        public static TMatrix operator -(TMatrix lhs, TMatrix rhs)
        {
            TMatrix result = new TMatrix(lhs.Row, lhs.Col);

            if (lhs.Row != rhs.Row)    //異常
            {
                System.Exception e = new Exception("相加的兩個矩陣的行數不等");
                throw e;
            }
            if (lhs.Col != rhs.Col)    //異常
            {
                System.Exception e = new Exception("相加的兩個矩陣的列數不等");
                throw e;
            }

            for (int i = 0; i < lhs.Data_Count; i++)
            {
                result.Data[i] = lhs.Data[i] - rhs.Data[i];
            }
            return result;
        }
        public static TMatrix operator *(TMatrix lhs, TMatrix rhs)
        {
            TMatrix result = new TMatrix(lhs.Row, rhs.Col);
            double temp;

            if (lhs.Col != rhs.Row)    //異常
            {
                System.Exception e = new Exception("相乘的兩個矩陣的行列數不匹配");
                throw e;
            }
            for (int i = 0; i < lhs.Row; i++)
            {
                for (int j = 0; j < rhs.Col; j++)
                {
                    temp = 0;
                    for (int k = 0; k < lhs.Col; k++)
                    {
                        temp += lhs[i, k] * rhs[k, j];
                    }
                    result[i, j] = temp;
                }
            }
            return result;
        }
        public static TMatrix operator /(TMatrix lhs, TMatrix rhs)
        {
            return lhs * rhs.Inverse();
        }
        public static TMatrix operator *( TMatrix m, double value)
        {
            TMatrix result = new TMatrix(m.Row, m.Col, m.Data);
            for (int i = 0; i < result.Data_Count; i++)
            {
                result.Data[i] = result.Data[i] * value;
            }
            return result;
        }
        public static TMatrix operator /(TMatrix m, double value)
        {
            TMatrix result = new TMatrix(m.Row, m.Col, m.Data);
            for (int i = 0; i < result.Data_Count; i++)
            {
                result.Data[i] = result.Data[i] / value;
            }
            return result;
        }

        //伴隨矩陣
        //
        //    +-   -+ *
        //    |  T  |
        //    +-   -+
        public TMatrix Adj()
        {
            TMatrix result = null;
            TMatrix sub_m;
            double dim_sub = 0;
            bool line_single = true;
            bool single = true;

            if (Row == Col)
            {
                result = new TMatrix(Row, Col);

                for (int row = 0; row < Row; row++)
                {
                    single = line_single;
                    for (int col = 0; col < Col; col++)
                    {
                        sub_m = Sub(row, col);
                        dim_sub = sub_m.Determinant();
                        if (!single) dim_sub = -dim_sub;
                        result[col, row] = dim_sub;
                        single = !single;
                    }

                    line_single = !line_single;
                }
            }
            else
            {
                //異常,非方陣異常,非方陣
                System.Exception e = new Exception("求逆的矩陣不是方陣");
                throw e;
            }
            return result;
        }
        //逆矩陣
        //
        //    +-   -+ -1
        //    |  T  |
        //    +-   -+
        public TMatrix Inverse()
        {
            TMatrix result = null;
            TMatrix adj_m;

            
            if (Row == Col)    
            {
                result = new TMatrix(Row, Col);

                adj_m = Adj();
                result = adj_m / Determinant();
            }
            else
            {
                //異常,非方陣異常,非方陣
                System.Exception e = new Exception("求逆的矩陣不是方陣");
                throw e;
            }
            return result;
        }
        public TMatrix Sub(int row_index, int col_index)
        {
            TMatrix result = new TMatrix(Row-1, Col-1);
            int row_no, col_no;

            row_no = 0;
            for (int row = 0; row < Row; row++)
            {
                if (row != row_index)
                {
                    col_no = 0;
                    for (int col = 0; col < Col; col++)
                    {
                        if (col != col_index)
                        {
                            result[row_no, col_no] = this[row, col];
                            col_no++;
                        }
                    }
                    row_no++;
                }
            }
            return result;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    s += string.Format("{0} ", this[i, j]);
                }
                s += "\r\n";
            }
            return s;
        }
        
        //矩陣行列式
        //
        //    |     |
        //    |  T  |
        //    I     |
        public double Determinant()
        {
            double result = 0;
            double sum1 = 0, sum2 = 0, line_sum = 0;
            int tmp_row, tmp_col;
            
            if (Row == Col)
            {
                if (Row == 1)
                {
                    result = this[0, 0];
                }
                else
                {
                    sum1 = 0;
                    for (int j = 0; j < Col; j++)
                    {
                        tmp_row = 0;
                        tmp_col = j;
                        line_sum = 1;
                        for (int i = 0; i < Row; i++)
                        {
                            double dd = this[tmp_row, tmp_col];
                            line_sum = line_sum * this[tmp_row, tmp_col];
                            tmp_row = tmp_row + 1;
                            tmp_col = tmp_col + 1;
                            if (tmp_row > Row - 1) tmp_row = 0;
                            if (tmp_col > Col - 1) tmp_col = 0;
                        }
                        sum1 = sum1 + line_sum;
                        if (Col == 2) break;
                    }

                    sum2 = 0;
                    for (int j = Col - 1; j >= 0; j--)
                    {
                        tmp_row = 0;
                        tmp_col = j;
                        line_sum = 1;
                        for (int i = 0; i < Row; i++)
                        {
                            line_sum = line_sum * this[tmp_row, tmp_col];
                            tmp_row = tmp_row + 1;
                            tmp_col = tmp_col - 1;
                            if (tmp_row > Row - 1) tmp_row = 0;
                            if (tmp_col < 0) tmp_col = Col - 1;
                        }
                        sum2 = sum2 + line_sum;
                        if (Col == 2) break;
                    }
                    result = sum1 - sum2;
                }
            }
            else
            {
                //異常,非方陣異常,非方陣

                //throw Exception.
            }
            return result;
        }
    }
}