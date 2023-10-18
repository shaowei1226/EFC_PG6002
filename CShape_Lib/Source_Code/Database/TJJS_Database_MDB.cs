using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EFC.Database
{
    public class TJJS_Database_MDB
    {
        public string Database = "";
        public string Table_Name = "";
        public OleDbConnection Connection = new OleDbConnection();
        public DataTable Table = null;
        public bool On_Open = false;

        public TJJS_Database_MDB()
        {

        }
        public DataTable Get_DataTable(string table_name)
        {
            DataTable result = null;
            string sql = "select * from " + table_name;

            if (Connection != null)
            {
                result = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(sql, Connection);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                result = ds.Tables[0];
            }
            return result;
        }
        public bool Open()
        {
            bool result = false;
            if (Database != "" && Table_Name != "" && !On_Open)
            {
                if (System.IO.File.Exists(Database))
                {
                    Connection.ConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Database);
                    if (Connection.State == ConnectionState.Open) Connection.Close();
                    Connection.Open();
                    Table = Get_DataTable(Table_Name);
                    if (Table != null) On_Open = true;
                }
            }
            return result;
        }
        public void Close()
        {
            Connection.Close();
            On_Open = false;
        }
        public DataTableReader Get_Data(string field_name, string value, bool to_upper = false)
        {
            DataTableReader result = null;
            DataTableReader reader = null;
            string cmp_value = "";
            string field_value = "";

            if (to_upper) cmp_value = value.ToUpper();
            else cmp_value = value;
            if (On_Open)
            {
                reader = Table.CreateDataReader();
                while (reader.Read())
                {
                    field_value = reader[field_name].ToString();
                    if (to_upper) field_value = field_value.ToUpper();
                    if (field_value == cmp_value)
                    {
                        result = reader;
                        break;
                    }
                }
            }

            return result;
        }
        public string[] Get_Field_List(string field_name)
        {
            string[] result = new string[1000];
            int count = 0;
            DataTableReader reader = null;
            string field_value = "";

            if (On_Open)
            {
                reader = Table.CreateDataReader();
                while (reader.Read())
                {
                    field_value = reader[field_name].ToString();
                    result[count] = field_value;
                    count++;
                }
            }

            Array.Resize(ref result, count);
            return result;
        }
        public void Display(ref System.Windows.Forms.DataGridView grid)
        {
            if (On_Open)
            {
                grid.Rows.Clear();
                grid.ColumnCount = Table.Columns.Count;

                for (int i = 0; i < grid.ColumnCount; i++)
                    grid.Columns[i].HeaderText = Table.Columns[i].ToString();

                grid.RowCount = Table.Rows.Count;
                for (int i = 0; i < grid.RowCount; i++)
                {
                    for (int j = 0; j < grid.ColumnCount; j++)
                    {
                        grid.Rows[i].Cells[j].Value = Table.Rows[i][j].ToString();
                    }
                }
            }
        }
        public void Update(System.Windows.Forms.DataGridView grid, int key = 0)
        {
            string sql_str = "";
            string tmp_str = "";
            OleDbCommand cmd = new OleDbCommand();
            bool flag = true;

            if (On_Open)
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    sql_str = string.Format("update {0:s} set ", Table_Name);
                    tmp_str = "";
                    flag = true;
                    for (int j = 0; j < grid.Rows[i].Cells.Count; j++)
                    {
                        if (j != key)
                        {
                            if (Table.Columns[j].DataType == typeof(string))
                                tmp_str = string.Format("{0:s}='{1:s}'", Table.Columns[j].ToString(), grid.Rows[i].Cells[j].Value);
                            else
                            {
                                if (grid.Rows[i].Cells[j].Value == "") grid.Rows[i].Cells[j].Value = "0";
                                tmp_str = string.Format("{0:s}={1:s}", Table.Columns[j].ToString(), grid.Rows[i].Cells[j].Value);
                            }

                            if (flag)
                                sql_str = sql_str + " " + tmp_str;
                            else
                                sql_str = sql_str + " , " + tmp_str;

                            flag = false;
                        }
                    }

                    tmp_str = string.Format(" where {0:s}={1:s}", Table.Columns[key].ToString(), Table.Rows[i][key].ToString());
                    sql_str = sql_str + tmp_str;

                    cmd.Connection = Connection;
                    cmd.CommandText = sql_str;
                    cmd.ExecuteNonQuery();
                }
                Update();
            }
        }
        public void Update()
        {
            Connection.Close();
            Connection.Open();
            Table = Get_DataTable(Table_Name);
        }
    }
    public class TJJS_Database_MySQL
    {
        public string Database = "";
        public string Table_Name = "";
        public SqlConnection Connection = new SqlConnection();
        public DataTable Table = null;
        public bool On_Open = false;

        public TJJS_Database_MySQL()
        {

        }
        public DataTable Get_DataTable(string table_name)
        {
            DataTable result = null;
            string sql = "select * from " + table_name;

            if (Connection != null)
            {
                result = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, Connection);
                DataSet ds = new DataSet();
                ds.Clear();
                da.Fill(ds);
                result = ds.Tables[0];
            }
            return result;
        }
        public bool Open()
        {
            bool result = false;
            if (Database != "" && Table_Name != "" && !On_Open)
            {
                if (System.IO.File.Exists(Database))
                {
                    Connection.ConnectionString = string.Format("server={0:s};uid={1:s};pwd={2:s};database={3:s}",
                         "127,0,0,1","","");
                    if (Connection.State == ConnectionState.Open) Connection.Close();
                    Connection.Open();
                    Table = Get_DataTable(Table_Name);
                    if (Table != null) On_Open = true;
                }
            }
            return result;
        }
        public void Close()
        {
            Connection.Close();
            On_Open = false;
        }
        public DataTableReader Get_Data(string field_name, string value, bool to_upper = false)
        {
            DataTableReader result = null;
            DataTableReader reader = null;
            string cmp_value = "";
            string field_value = "";

            if (to_upper) cmp_value = value.ToUpper();
            else cmp_value = value;
            if (On_Open)
            {
                reader = Table.CreateDataReader();
                while (reader.Read())
                {
                    field_value = reader[field_name].ToString();
                    if (to_upper) field_value = field_value.ToUpper();
                    if (field_value == cmp_value)
                    {
                        result = reader;
                        break;
                    }
                }
            }

            return result;
        }
        public string[] Get_Field_List(string field_name)
        {
            string[] result = new string[1000];
            int count = 0;
            DataTableReader reader = null;
            string field_value = "";

            if (On_Open)
            {
                reader = Table.CreateDataReader();
                while (reader.Read())
                {
                    field_value = reader[field_name].ToString();
                    result[count] = field_value;
                    count++;
                }
            }

            Array.Resize(ref result, count);
            return result;
        }
        public void Display(ref System.Windows.Forms.DataGridView grid)
        {
            if (On_Open)
            {
                grid.Rows.Clear();
                grid.ColumnCount = Table.Columns.Count;

                for (int i = 0; i < grid.ColumnCount; i++)
                    grid.Columns[i].HeaderText = Table.Columns[i].ToString();

                grid.RowCount = Table.Rows.Count;
                for (int i = 0; i < grid.RowCount; i++)
                {
                    for (int j = 0; j < grid.ColumnCount; j++)
                    {
                        grid.Rows[i].Cells[j].Value = Table.Rows[i][j].ToString();
                    }
                }
            }
        }
        public void Update(System.Windows.Forms.DataGridView grid, int key = 0)
        {
            string sql_str = "";
            string tmp_str = "";
            SqlCommand cmd = new SqlCommand();
            bool flag = true;

            if (On_Open)
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    sql_str = string.Format("update {0:s} set ", Table_Name);
                    tmp_str = "";
                    flag = true;
                    for (int j = 0; j < grid.Rows[i].Cells.Count; j++)
                    {
                        if (j != key)
                        {
                            if (Table.Columns[j].DataType == typeof(string))
                                tmp_str = string.Format("{0:s}='{1:s}'", Table.Columns[j].ToString(), grid.Rows[i].Cells[j].Value);
                            else
                            {
                                if (grid.Rows[i].Cells[j].Value == "") grid.Rows[i].Cells[j].Value = "0";
                                tmp_str = string.Format("{0:s}={1:s}", Table.Columns[j].ToString(), grid.Rows[i].Cells[j].Value);
                            }

                            if (flag)
                                sql_str = sql_str + " " + tmp_str;
                            else
                                sql_str = sql_str + " , " + tmp_str;

                            flag = false;
                        }
                    }

                    tmp_str = string.Format(" where {0:s}={1:s}", Table.Columns[key].ToString(), Table.Rows[i][key].ToString());
                    sql_str = sql_str + tmp_str;

                    cmd.Connection = Connection;
                    cmd.CommandText = sql_str;
                    cmd.ExecuteNonQuery();
                }
                Update();
            }
        }
        public void Update()
        {
            Connection.Close();
            Connection.Open();
            Table = Get_DataTable(Table_Name);
        }
    }
}
