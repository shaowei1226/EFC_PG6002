using System;
using System.Collections; //ArrayList
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.PLC;
using EFC.Tool;

namespace Main
{
     public enum enData_Bytes { Byte16, Byte32 };
     public enum enData_Type { Dec, Hex, ASCII };

     public partial class TForm_Data_View : Form
     {
          private ushort[] Data = null;
          private int Count = 0;
          private string Start_Code;

          private enData_Bytes Data_Byte;
          private enData_Type Data_Type;
          private bool Unsigned_Flag = true;

          private DataTable Table = new DataTable();
          public CheckBox[] CB = new CheckBox[16];
          private Label[] L_Info = new Label[16];
          private ArrayList CSV_Info = new ArrayList();
          public TForm_Data_View()
          {
               InitializeComponent();
               CB[0] = CB00;
               CB[1] = CB01;
               CB[2] = CB02;
               CB[3] = CB03;
               CB[4] = CB04;
               CB[5] = CB05;
               CB[6] = CB06;
               CB[7] = CB07;
               CB[8] = CB08;
               CB[9] = CB09;
               CB[10] = CB10;
               CB[11] = CB11;
               CB[12] = CB12;
               CB[13] = CB13;
               CB[14] = CB14;
               CB[15] = CB15;

               L_Info[0] = Label00;
               L_Info[1] = Label01;
               L_Info[2] = Label02;
               L_Info[3] = Label03;
               L_Info[4] = Label04;
               L_Info[5] = Label05;
               L_Info[6] = Label06;
               L_Info[7] = Label07;
               L_Info[8] = Label08;
               L_Info[9] = Label09;
               L_Info[10] = Label10;
               L_Info[11] = Label11;
               L_Info[12] = Label12;
               L_Info[13] = Label13;
               L_Info[14] = Label14;
               L_Info[15] = Label15;
          }

          public void Set_Param(TPLC_Base_Data data, string csv_file)
          {
               Set_Param(data.Start_Code, data.Data, data.Count, csv_file);
          }
          public void Set_Param(string start_code, ushort[] data, int count, string csv_file)
          {
               Start_Code = start_code;
               Data = data;
               Count = count;
               Read_CSV_File(csv_file);
               dataGridView1.RowCount = Count + 1;
          }
          private void TForm_Data_View_Shown(object sender, EventArgs e)
          {
               timer1.Enabled = true;
          }
          public void Read_CSV_File(string filename)
          {
               //設定檔案格式
               if (System.IO.File.Exists(filename))
               {
                    ArrayList_Tool.LoadFromFile(ref CSV_Info, filename);
                    if (CSV_Info.Count > 1) CSV_Info.Remove(CSV_Info[0]);
               }
          }
          public string Get_CSV_Info(int no)
          {
               string result = "";
               ArrayList tmp_list = new ArrayList();

               if (no < CSV_Info.Count)
               {
                    String_Tool.Break_String(CSV_Info[no].ToString(), ",", ref tmp_list);
                    if (tmp_list.Count >= 2) result = tmp_list[1].ToString();
               }
               return result;
          }
          public string[] Get_CSV_Sub_Info(int no)
          {
               string[] result = new string[0];
               ArrayList tmp_list = new ArrayList();

               if (no < CSV_Info.Count)
               {
                    String_Tool.Break_String(CSV_Info[no].ToString(), ",", ref tmp_list);
                    if (tmp_list.Count >= 2)
                    {
                         Array.Resize(ref result, tmp_list.Count - 2);
                         for (int i = 2; i < tmp_list.Count; i++)
                         {
                              result[i - 2] = tmp_list[i].ToString();
                         }
                    }
               }
               return result;
          }
          private void Get_Data_Type(out enData_Bytes data_byte, out enData_Type data_type, out bool unsigned_flag)
          {
               data_byte = enData_Bytes.Byte16;
               if (RB_16Bit.Checked) data_byte = enData_Bytes.Byte16;
               if (RB_32Bit.Checked) data_byte = enData_Bytes.Byte32;

               data_type = enData_Type.Dec;
               if (RB_Dec.Checked) data_type = enData_Type.Dec;
               if (RB_Hex.Checked) data_type = enData_Type.Hex;
               if (RB_ASCII.Checked) data_type = enData_Type.ASCII;
               unsigned_flag = CB_Unsigned.Checked;
          }
          public void Update_Grid()
          {
               string bit_str = "aa";
               string info_str = "info";
               string no_str = "aa";
               string value_str = "aa";

               if (Data != null && Count > 0)
               {
                    Get_Data_Type(out Data_Byte, out Data_Type, out Unsigned_Flag);
                    //設定DataTable
                    for (int i = 0; i < Count; i++)
                    {
                         no_str = Start_Code + "+" + String_Tool.IntToStr_A(i, emJJS_DataType.emJJS_dtTen, 4);
                         bit_str = Get_Bit_String(i);
                         if (Data_Byte == enData_Bytes.Byte16)
                              value_str = Get_Value_Str(i);
                         else if (Data_Byte == enData_Bytes.Byte32)
                         {
                              if (i % 2 == 0) value_str = Get_Value_Str(i);
                              else value_str = "";
                         }

                         info_str = Get_CSV_Info(i);

                         dataGridView1.Rows[i].Cells[0].Value = no_str;
                         dataGridView1.Rows[i].Cells[1].Value = bit_str;
                         dataGridView1.Rows[i].Cells[2].Value = value_str;
                         dataGridView1.Rows[i].Cells[3].Value = info_str;
                    }
                    //更新Row 資料
                    Update_Grid_Row();
               }
          }
          public void Update_Grid_Row()
          {
               int no = -1;

               if (Data != null && Count > 0)
               {
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                         no = dataGridView1.SelectedCells[0].RowIndex;
                         string[] info = Get_CSV_Sub_Info(no);
                         Set_Bit_Data(no, info);
                    }
               }
          }
          public string Get_Bit_String(int no)
          {
               string result = "";
               string tmp_str = "";

               tmp_str = String_Tool.IntToStr_A(PLC_Data_Tool.Get_Word(Data, no), emJJS_DataType.emJJS_DtBin, 16);
               char[] chars = tmp_str.ToCharArray();
               for (int i = 0; i < tmp_str.Length; i++)
               {
                    result = result + chars[i];
                    if ((i + 1) % 4 == 0 && (i + 1) < tmp_str.Length) result = result + "--";
               }
               return result;
          }
          public string Get_Value_Str(int no)
          {
               string result = "";
               int data = 0;
               UInt16 udata_16 = 0;
               UInt32 udata_32 = 0;

               switch (Data_Byte)
               {
                    case enData_Bytes.Byte16:
                         data = PLC_Data_Tool.Get_Word(Data, no);
                         udata_16 = (UInt16)data;
                         switch (Data_Type)
                         {
                              case enData_Type.Dec:
                                   if (Unsigned_Flag)
                                        result = Convert.ToString(data);
                                   else
                                        result = Convert.ToString(udata_16);
                                   break;

                              case enData_Type.Hex:
                                   result = String_Tool.IntToStr_A(udata_16, emJJS_DataType.emJJS_dtHex, 4);
                                   break;

                              case enData_Type.ASCII:
                                   byte[] bytes = BitConverter.GetBytes(data);
                                   result = "" + (char)bytes[0] + (char)bytes[1];
                                   break;
                         }
                         break;

                    case enData_Bytes.Byte32:
                         data = PLC_Data_Tool.Get_DWord(Data, no);
                         udata_32 = (UInt32)data;
                         switch (Data_Type)
                         {
                              case enData_Type.Dec:
                                   if (Unsigned_Flag)
                                        result = Convert.ToString(data);
                                   else
                                        result = Convert.ToString(udata_32);
                                   break;

                              case enData_Type.Hex:
                                   Convert.ToString(69, 16);
                                   result = String_Tool.IntToStr_A(udata_32, emJJS_DataType.emJJS_dtHex, 8);
                                   break;

                              case enData_Type.ASCII:
                                   byte[] bytes = BitConverter.GetBytes(data);
                                   result = "" + (char)bytes[0] + (char)bytes[1] + (char)bytes[2] + (char)bytes[3];
                                   break;
                         }
                         break;

               }
               return result;
          }
          public void Set_Bit_Data(int word_no, string[] info = null)
          {
               for (int i = 0; i < CB.Length; i++)
               {
                    CB[i].Checked = PLC_Data_Tool.Get_Bit(Data, word_no, i);
                    if (i < info.Length) L_Info[i].Text = info[i];
                    else L_Info[i].Text = "";
               }
          }
          public void Get_Bit_Data(int word_no)
          {
               for (int i = 0; i < CB.Length; i++)
               {
                    PLC_Data_Tool.Set_Bit(Data, word_no, i, CB[i].Checked);
               }
          }
          bool ConvertIntToByteArray(UInt32 m, ref byte[] arry)
          {
               if (arry == null) return false;
               if (arry.Length < 4) return false;

               arry[0] = (byte)(m & 0xFF);
               arry[1] = (byte)((m & 0xFF00) >> 8);
               arry[2] = (byte)((m & 0xFF0000) >> 16);
               arry[3] = (byte)((m >> 24) & 0xFF);

               return true;
          }
          public void Show_Col_Name(int col_index)
          {
               ////設定TBit8_Frame
               //Bit8_Frame[0].LB[0].Text = Convert.ToString(table.Rows[col_index].ItemArray[2]);      //bit00
               //Bit8_Frame[0].LB[1].Text = Convert.ToString(table.Rows[col_index].ItemArray[3]);      //bit01
               //Bit8_Frame[0].LB[2].Text = Convert.ToString(table.Rows[col_index].ItemArray[4]);      //bit02
               //Bit8_Frame[0].LB[3].Text = Convert.ToString(table.Rows[col_index].ItemArray[5]);      //bit03
               //Bit8_Frame[0].LB[4].Text = Convert.ToString(table.Rows[col_index].ItemArray[6]);      //bit04
               //Bit8_Frame[0].LB[5].Text = Convert.ToString(table.Rows[col_index].ItemArray[7]);      //bit05
               //Bit8_Frame[0].LB[6].Text = Convert.ToString(table.Rows[col_index].ItemArray[8]);      //bit06
               //Bit8_Frame[0].LB[7].Text = Convert.ToString(table.Rows[col_index].ItemArray[9]);      //bit07

               //Bit8_Frame[1].LB[0].Text = Convert.ToString(table.Rows[col_index].ItemArray[10]);     //bit08
               //Bit8_Frame[1].LB[1].Text = Convert.ToString(table.Rows[col_index].ItemArray[11]);     //bit09
               //Bit8_Frame[1].LB[2].Text = Convert.ToString(table.Rows[col_index].ItemArray[12]);     //bit10
               //Bit8_Frame[1].LB[3].Text = Convert.ToString(table.Rows[col_index].ItemArray[13]);     //bit11
               //Bit8_Frame[1].LB[4].Text = Convert.ToString(table.Rows[col_index].ItemArray[14]);     //bit12
               //Bit8_Frame[1].LB[5].Text = Convert.ToString(table.Rows[col_index].ItemArray[15]);     //bit13
               //Bit8_Frame[1].LB[6].Text = Convert.ToString(table.Rows[col_index].ItemArray[16]);     //bit14
               //Bit8_Frame[1].LB[7].Text = Convert.ToString(table.Rows[col_index].ItemArray[17]);     //bit15         
          }
          private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
               Update_Grid_Row();
          }
          private void RB_16Bit_CheckedChanged(object sender, EventArgs e)
          {
               Update_Grid();
          }
          private void RB_32Bit_CheckedChanged(object sender, EventArgs e)
          {
               Update_Grid();
          }
          private void RB_Dec_CheckedChanged(object sender, EventArgs e)
          {
               Update_Grid();
          }
          private void RB_Hex_CheckedChanged(object sender, EventArgs e)
          {
               Update_Grid();
          }
          private void dataGridView1_SelectionChanged(object sender, EventArgs e)
          {
               Update_Grid_Row();
          }
          private void timer1_Tick(object sender, EventArgs e)
          {
               timer1.Enabled = false;
               Update_Grid();
               timer1.Enabled = true;
          }
     }
}
