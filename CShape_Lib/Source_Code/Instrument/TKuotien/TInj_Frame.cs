using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDefine;
using TParameter_Struct;

namespace RS232_Musashi
{
    public partial class TInj_Frame : UserControl
    {
        public class TObj1_Struct
        {
            public DataGridView SG = new DataGridView();
            public System.Windows.Forms.DataGridViewCheckBoxColumn CB_Apply = new DataGridViewCheckBoxColumn();
            public System.Windows.Forms.DataGridViewCheckBoxColumn CB_End = new DataGridViewCheckBoxColumn();
            public System.Windows.Forms.DataGridViewCheckBoxColumn CB_UV = new DataGridViewCheckBoxColumn();

            public TObj1_Struct()
            {
            }
        }

        private int Get_Tag(int no)
        {
            int num = 0;

            switch (no)
            {
                //只允許填入數字(含正負號及小數)
                case 0:
                case 1:
                case 2:
                case 3: num = 0; break;
                //只允許填入數字，範圍1.000~300.000
                case 7: num = 1; break;
                //只允許填入N、Y
                //case 4: num = 2; break;
                //只允許填入整數
                case 5: num = 3; break;
                //註解提醒用，不影響任何參數
                case 6: num = 4; break;
                //只允許填入A、B、G、S
                case 8: num = 5; break;

                default: num = 0; break;
            }

            return num;
        }
        private void SetValidaCellColumns(DataGridViewColumnCollection columns, int no, int value, string str, int tag, bool visible, int format, int alignment)
        {
            //寬度
            columns[no].Width = value;
            //標頭文字
            columns[no].HeaderText = str;
            //Tag
            columns[no].HeaderCell.Tag = tag;
            //對齊方式
            columns[no].HeaderCell.Style.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            columns[no].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            //顯示或隱藏
            columns[no].Visible = visible;
            //Cell表格
            //字型格式
            columns[no].DefaultCellStyle.Font = new Font("Arial", (float)10, FontStyle.Bold, GraphicsUnit.Point, (byte)1, false);
            //字串格式
            switch (alignment)
            {
                case 0: columns[no].DefaultCellStyle.Format = ""; break;
                case 1: columns[no].DefaultCellStyle.Format = "N1"; break;
                case 2: columns[no].DefaultCellStyle.Format = "N2"; break;
                case 3: columns[no].DefaultCellStyle.Format = "N3"; break;
                case 4: columns[no].DefaultCellStyle.Format = "N4"; break;
                default: columns[no].DefaultCellStyle.Format = ""; break;
            }

            //對齊方式
            switch (alignment)
            {
                case 0: columns[no].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft; break;
                case 1: columns[no].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; break;
                case 2: columns[no].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; break;
                default: columns[no].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight; break;
            }
        }
        private void SetGetButtonPosition(DataGridView dgView, int no, int count, System.Windows.Forms.Button but)
        {
            int w = 0;
            for (int i = 0; i < no; i++)
            {
                if (dgView.Columns[i].Visible)
                {
                    w += dgView.Columns[i].Width;
                }
            }

            but.Left = dgView.Location.X + dgView.Rows[0].HeaderCell.DataGridView.RowHeadersWidth + w + 4;
            w = 0;
            for (int i = 0; i < count; i++)
            {
                w += dgView.Columns[no + i].Width;
            }
            but.Width = w - 4;
        }

        int itmp = 0;

        public TObj1_Struct[] Inj_Obj = new TObj1_Struct[2]; //0:垂直, 1:水平

        public TSide_Data mParameter = new TSide_Data();

        public TInj_Frame()
        {
            InitializeComponent();

            Inj_Obj[0] = new TObj1_Struct();
            Inj_Obj[1] = new TObj1_Struct();

            Inj_Obj[0].SG = dataGridView1;
            Inj_Obj[1].SG = dataGridView2;

            for (int i = 0; i < 2; i++)
            {
                //背景顏色
                Inj_Obj[i].SG.ColumnHeadersDefaultCellStyle.BackColor = Color.Olive;
                Inj_Obj[i].SG.EnableHeadersVisualStyles = false;//只有上面那一行還不夠，還要加上這一行
                //固定高度
                Inj_Obj[i].SG.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;//要有這一行
                Inj_Obj[i].SG.ColumnHeadersHeight = 35;
                //自動高度
                //this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;//要有這一行
                //文字太長，自動折行
                //this.dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;//(資料內容)
                //this.dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;//(標題列)
                itmp = 0;
                Inj_Obj[i].SG.ColumnCount = 3;
                Inj_Obj[i].SG.RowHeadersWidth = 70;
                //SetValidaCellColumns(Inj_Obj[i].SG.Columns, itmp, 35, "NO.", Get_Tag(itmp++), true, 0, 2);
                SetValidaCellColumns(Inj_Obj[i].SG.Columns, itmp, 70, "X", Get_Tag(itmp++), true, 2, 2);
                //SetValidaCellColumns(Inj_Obj[i].SG.Columns, itmp, 70, "Y", Get_Tag(itmp++), false, 2, 2);
                SetValidaCellColumns(Inj_Obj[i].SG.Columns, itmp, 70, "Z", Get_Tag(itmp++), true, 2, 2);
                SetValidaCellColumns(Inj_Obj[i].SG.Columns, itmp, 70, "Speed", Get_Tag(itmp++), true, 2, 2);
                //SetValidaCellColumns(Inj_Obj[i].SG.Columns, itmp, 70, "End_Ahead_Time", Get_Tag(itmp++), true, 3, 2);
                //Inj_Obj[i].SG.Columns[itmp].DefaultCellStyle.BackColor = Color.Red;

                Inj_Obj[i].CB_Apply.HeaderText = "Apply";
                Inj_Obj[i].CB_Apply.Name = "Apply";
                Inj_Obj[i].CB_Apply.Width = 55;
                Inj_Obj[i].CB_Apply.ReadOnly = false;

                Inj_Obj[i].SG.Columns.Insert(itmp++, Inj_Obj[i].CB_Apply);

                Inj_Obj[i].CB_End.HeaderText = "End";
                Inj_Obj[i].CB_End.Name = "End";
                Inj_Obj[i].CB_End.Width = 45;
                Inj_Obj[i].CB_End.ReadOnly = false;

                Inj_Obj[i].SG.Columns.Insert(itmp++, Inj_Obj[i].CB_End);

                Inj_Obj[i].CB_UV.HeaderText = "UV";
                Inj_Obj[i].CB_UV.Name = "UV";
                Inj_Obj[i].CB_UV.Width = 35;
                Inj_Obj[i].CB_UV.ReadOnly = false;

                Inj_Obj[i].SG.Columns.Insert(itmp++, Inj_Obj[i].CB_UV);

                for (int j = 0; j < Inj_Obj[i].SG.ColumnCount; j++)
                {
                    Inj_Obj[i].SG.Columns[j].DefaultCellStyle.NullValue = null;
                }
                //自動調整欄寬模式      自動填滿
                //this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                //自動調整行高模式      自動與調整行高
                //this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                Inj_Obj[i].SG.RowCount = 1;


            }
        }

        public void Get_Frame_Param()
        {
            Inj_Obj[0].SG = dataGridView1;
            Inj_Obj[1].SG = dataGridView2;

            //載台塗膠偏移量位置XY
            mParameter.Talbe_Ofs_XY.X = Convert.ToDouble(E_Table_Ofs_X.Text);
            mParameter.Talbe_Ofs_XY.Y = Convert.ToDouble(E_Table_Ofs_Y.Text);
            //取像偏移量
            mParameter.Panel.Ofs_XYQ.X = Convert.ToDouble(E_Panel_Ofs_X.Text);
            mParameter.Panel.Ofs_XYQ.Y = Convert.ToDouble(E_Panel_Ofs_Y.Text);
            mParameter.Panel.Ofs_XYQ.Q = Convert.ToDouble(E_Panel_Ofs_Q.Text);
            mParameter.Panel.Ofs_XYQ.Z = Convert.ToDouble(E_Panel_Ofs_Z.Text);
            //補正量
            mParameter.Bonder.X = Convert.ToDouble(E_Bonder_Ofs_X.Text);
            mParameter.Bonder.Y = Convert.ToDouble(E_Bonder_Ofs_Y.Text);
            mParameter.Bonder.Q = Convert.ToDouble(E_Bonder_Ofs_Q.Text);
            //Limit Bool
            mParameter.Limit[0].Flag[0].X = CB_Panel_Limit_Up_X.Checked;
            mParameter.Limit[0].Flag[0].Y = CB_Panel_Limit_Up_Y.Checked;
            mParameter.Limit[0].Flag[0].Q = CB_Panel_Limit_Up_Q.Checked;
            mParameter.Limit[0].Flag[1].X = CB_Panel_Limit_Dn_X.Checked;
            mParameter.Limit[0].Flag[1].Y = CB_Panel_Limit_Dn_Y.Checked;
            mParameter.Limit[0].Flag[1].Q = CB_Panel_Limit_Dn_Q.Checked;
            mParameter.Limit[1].Flag[0].X = CB_Arm_Limit_Up_X.Checked;
            mParameter.Limit[1].Flag[0].Y = CB_Arm_Limit_Up_Y.Checked;
            mParameter.Limit[1].Flag[0].Z = CB_Arm_Limit_Up_Z.Checked;
            mParameter.Limit[1].Flag[1].X = CB_Arm_Limit_Dn_X.Checked;
            mParameter.Limit[1].Flag[1].Y = CB_Arm_Limit_Dn_Y.Checked;
            mParameter.Limit[1].Flag[1].Z = CB_Arm_Limit_Dn_Z.Checked;
            //Limit Double
            mParameter.Limit[0].Ofs[0].X = Convert.ToDouble(E_Panel_Limit_Up_X.Text);
            mParameter.Limit[0].Ofs[0].Y = Convert.ToDouble(E_Panel_Limit_Up_Y.Text);
            mParameter.Limit[0].Ofs[0].Q = Convert.ToDouble(E_Panel_Limit_Up_Q.Text);
            mParameter.Limit[0].Ofs[1].X = Convert.ToDouble(E_Panel_Limit_Dn_X.Text);
            mParameter.Limit[0].Ofs[1].Y = Convert.ToDouble(E_Panel_Limit_Dn_Y.Text);
            mParameter.Limit[0].Ofs[1].Q = Convert.ToDouble(E_Panel_Limit_Dn_Q.Text);
            mParameter.Limit[1].Ofs[0].X = Convert.ToDouble(E_Arm_Limit_Up_X.Text);
            mParameter.Limit[1].Ofs[0].Y = Convert.ToDouble(E_Arm_Limit_Up_Y.Text);
            mParameter.Limit[1].Ofs[0].Z = Convert.ToDouble(E_Arm_Limit_Up_Z.Text);
            mParameter.Limit[1].Ofs[1].X = Convert.ToDouble(E_Arm_Limit_Dn_X.Text);
            mParameter.Limit[1].Ofs[1].Y = Convert.ToDouble(E_Arm_Limit_Dn_Y.Text);
            mParameter.Limit[1].Ofs[1].Z = Convert.ToDouble(E_Arm_Limit_Dn_Z.Text);
            //Cal Limit
            //mParameter.Cal_Limit.Flag = CB_Cal_Limit.Checked;
            mParameter.Cal_Limit.Flag = true;
            mParameter.Cal_Limit.Ofs[0].X = Convert.ToDouble(E_Cal_Limit_Up_X.Text);
            mParameter.Cal_Limit.Ofs[0].Y = Convert.ToDouble(E_Cal_Limit_Up_Y.Text);
            mParameter.Cal_Limit.Ofs[0].Q = Convert.ToDouble(E_Cal_Limit_Up_Q.Text);
            mParameter.Cal_Limit.Ofs[1].X = Convert.ToDouble(E_Cal_Limit_Dn_X.Text);
            mParameter.Cal_Limit.Ofs[1].Y = Convert.ToDouble(E_Cal_Limit_Dn_Y.Text);
            mParameter.Cal_Limit.Ofs[1].Q = Convert.ToDouble(E_Cal_Limit_Dn_Q.Text);
            //塗膠相對位置
            //垂直
            mParameter.Inj[0].Position_Data.Start_Base_Pitch = Convert.ToDouble(E_Verters_Start_Base_Pitch.Text);
            mParameter.Inj[0].Position_Data.Start_X_Pitch = Convert.ToDouble(E_Verters_Start_X_Pitch.Text);
            mParameter.Inj[0].Position_Data.Start_Width_Pitch = Convert.ToDouble(E_Verters_Start_Width_Pitch.Text);
            mParameter.Inj[0].Position_Data.End_X_Pitch = Convert.ToDouble(E_Verters_End_X_Pitch.Text);
            mParameter.Inj[0].Position_Data.End_UV_Pitch = Convert.ToDouble(E_Verters_End_UV_Pitch.Text);
            mParameter.Inj[0].Position_Data.Move_Speed = Convert.ToDouble(E_Verters_Speed.Text);
            mParameter.Inj[0].Position_Data.UV_Speed = Convert.ToDouble(E_Verters_Speed2.Text);
            mParameter.Inj[0].Position_Data.Delay_Pitch1 = Convert.ToDouble(E_Verters_Delay_Pitch1.Text);
            mParameter.Inj[0].Position_Data.Delay_Pitch2 = Convert.ToDouble(E_Verters_Delay_Pitch2.Text);
            mParameter.Inj[0].Position_Data.End_Ahead_Time = Convert.ToDouble(E_Verters_End_Ahead_Time.Text);
            //水平
            mParameter.Inj[1].Position_Data.Start_Width_Pitch = Convert.ToDouble(E_Horzers_Start_Base_Pitch.Text);
            mParameter.Inj[1].Position_Data.Start_X_Pitch = Convert.ToDouble(E_Horzers_Start_X_Pitch.Text);
            mParameter.Inj[1].Position_Data.Start_Width_Pitch = Convert.ToDouble(E_Horzers_Start_Width_Pitch.Text);
            mParameter.Inj[1].Position_Data.End_X_Pitch = Convert.ToDouble(E_Horzers_End_X_Pitch.Text);
            mParameter.Inj[1].Position_Data.End_UV_Pitch = Convert.ToDouble(E_Horzers_End_UV_Pitch.Text);
            mParameter.Inj[1].Position_Data.Move_Speed = Convert.ToDouble(E_Horzers_Speed.Text);
            mParameter.Inj[1].Position_Data.UV_Speed = Convert.ToDouble(E_Horzers_Speed2.Text);
            mParameter.Inj[1].Position_Data.Delay_Pitch1 = Convert.ToDouble(E_Horzers_Delay_Pitch1.Text);
            mParameter.Inj[1].Position_Data.Delay_Pitch2 = Convert.ToDouble(E_Horzers_Delay_Pitch2.Text);
            mParameter.Inj[1].Position_Data.End_Ahead_Time = Convert.ToDouble(E_Horzers_End_Ahead_Time.Text);
            //塗膠路徑
            for (int i = 0; i < 2; i++)
            {
                //if (Inj_Obj[i].SG.RowCount > 1)
                //    Inj_Obj[i].SG.RowCount = 1;

                

                for (int j = 0; j < 100; j++)
                {
                    itmp = 0;
                    mParameter.Inj[i].Point[j].Inj_X = Convert.ToDouble(Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value);
                    //mParameter.Inj[i].Point[j].Inj_Y = Convert.ToDouble(Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value);
                    mParameter.Inj[i].Point[j].Inj_Z = Convert.ToDouble(Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value);
                    mParameter.Inj[i].Point[j].Inj_Speed = Convert.ToDouble(Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value);
                    //mParameter.Inj[i].Point[j].Inj_End_Ahead_Time = Convert.ToInt16(Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value);

                    DataGridViewCheckBoxCell SGcheck = new DataGridViewCheckBoxCell();

                    SGcheck = (DataGridViewCheckBoxCell)Inj_Obj[i].SG.Rows[j].Cells[itmp++];
                    mParameter.Inj[i].Point[j].Inj_Apply = Convert.ToBoolean(SGcheck.Value);

                    SGcheck = (DataGridViewCheckBoxCell)Inj_Obj[i].SG.Rows[j].Cells[itmp++];
                    mParameter.Inj[i].Point[j].Inj_End = Convert.ToBoolean(SGcheck.Value);

                    SGcheck = (DataGridViewCheckBoxCell)Inj_Obj[i].SG.Rows[j].Cells[itmp++];
                    mParameter.Inj[i].Point[j].Inj_UV = Convert.ToBoolean(SGcheck.Value);

                }
            }

            mParameter.Musashi_Channel = Convert.ToInt16(E_Masashi_Channel.Text);
        }

        public void Set_Frame_Param()
        {
            //載台塗膠偏移量位置XY
            E_Table_Ofs_X.Text = mParameter.Talbe_Ofs_XY.X.ToString("0.00");
            E_Table_Ofs_Y.Text = mParameter.Talbe_Ofs_XY.Y.ToString("0.00");
            //取像偏移量
            E_Panel_Ofs_X.Text = mParameter.Panel.Ofs_XYQ.X.ToString("0.00");
            E_Panel_Ofs_Y.Text = mParameter.Panel.Ofs_XYQ.Y.ToString("0.00");
            E_Panel_Ofs_Q.Text = mParameter.Panel.Ofs_XYQ.Q.ToString("0.00");
            E_Panel_Ofs_Z.Text = mParameter.Panel.Ofs_XYQ.Z.ToString("0.00");
            //補正量
            E_Bonder_Ofs_X.Text = mParameter.Bonder.X.ToString("0.00");
            E_Bonder_Ofs_Y.Text = mParameter.Bonder.Y.ToString("0.00");
            E_Bonder_Ofs_Q.Text = mParameter.Bonder.Q.ToString("0.00");
            //Limit Bool
            CB_Panel_Limit_Up_X.Checked = mParameter.Limit[0].Flag[0].X;
            CB_Panel_Limit_Up_Y.Checked = mParameter.Limit[0].Flag[0].Y;
            CB_Panel_Limit_Up_Q.Checked = mParameter.Limit[0].Flag[0].Q;
            CB_Panel_Limit_Dn_X.Checked = mParameter.Limit[0].Flag[1].X;
            CB_Panel_Limit_Dn_Y.Checked = mParameter.Limit[0].Flag[1].Y;
            CB_Panel_Limit_Dn_Q.Checked = mParameter.Limit[0].Flag[1].Q;
            CB_Arm_Limit_Up_X.Checked = mParameter.Limit[1].Flag[0].X;
            CB_Arm_Limit_Up_Y.Checked = mParameter.Limit[1].Flag[0].Y;
            CB_Arm_Limit_Up_Z.Checked = mParameter.Limit[1].Flag[0].Z;
            CB_Arm_Limit_Dn_X.Checked = mParameter.Limit[1].Flag[1].X;
            CB_Arm_Limit_Dn_Y.Checked = mParameter.Limit[1].Flag[1].Y;
            CB_Arm_Limit_Dn_Z.Checked = mParameter.Limit[1].Flag[1].Z;
            //Limit Double
            E_Panel_Limit_Up_X.Text = mParameter.Limit[0].Ofs[0].X.ToString("0.00");
            E_Panel_Limit_Up_Y.Text = mParameter.Limit[0].Ofs[0].Y.ToString("0.00");
            E_Panel_Limit_Up_Q.Text = mParameter.Limit[0].Ofs[0].Q.ToString("0.00");
            E_Panel_Limit_Dn_X.Text = mParameter.Limit[0].Ofs[1].X.ToString("0.00");
            E_Panel_Limit_Dn_Y.Text = mParameter.Limit[0].Ofs[1].Y.ToString("0.00");
            E_Panel_Limit_Dn_Q.Text = mParameter.Limit[0].Ofs[1].Q.ToString("0.00");
            E_Arm_Limit_Up_X.Text = mParameter.Limit[1].Ofs[0].X.ToString("0.00");
            E_Arm_Limit_Up_Y.Text = mParameter.Limit[1].Ofs[0].Y.ToString("0.00");
            E_Arm_Limit_Up_Z.Text = mParameter.Limit[1].Ofs[0].Z.ToString("0.00");
            E_Arm_Limit_Dn_X.Text = mParameter.Limit[1].Ofs[1].X.ToString("0.00");
            E_Arm_Limit_Dn_Y.Text = mParameter.Limit[1].Ofs[1].Y.ToString("0.00");
            E_Arm_Limit_Dn_Z.Text = mParameter.Limit[1].Ofs[1].Z.ToString("0.00");
            //Cal Limit
            //CB_Cal_Limit.Checked = mParameter.Cal_Limit.Flag;
            CB_Cal_Limit.Checked = true;
            E_Cal_Limit_Up_X.Text = mParameter.Cal_Limit.Ofs[0].X.ToString("0.00");
            E_Cal_Limit_Up_Y.Text = mParameter.Cal_Limit.Ofs[0].Y.ToString("0.00");
            E_Cal_Limit_Up_Q.Text = mParameter.Cal_Limit.Ofs[0].Q.ToString("0.00");
            E_Cal_Limit_Dn_X.Text = mParameter.Cal_Limit.Ofs[1].X.ToString("0.00");
            E_Cal_Limit_Dn_Y.Text = mParameter.Cal_Limit.Ofs[1].Y.ToString("0.00");
            E_Cal_Limit_Dn_Q.Text = mParameter.Cal_Limit.Ofs[1].Q.ToString("0.00");
            //塗膠相對位置
            //垂直
            E_Verters_Start_Base_Pitch.Text = mParameter.Inj[0].Position_Data.Start_Base_Pitch.ToString("0.00");
            E_Verters_Start_X_Pitch.Text = mParameter.Inj[0].Position_Data.Start_X_Pitch.ToString("0.00");
            E_Verters_Start_Width_Pitch.Text = mParameter.Inj[0].Position_Data.Start_Width_Pitch.ToString("0.00");
            E_Verters_End_X_Pitch.Text = mParameter.Inj[0].Position_Data.End_X_Pitch.ToString("0.00");
            E_Verters_End_UV_Pitch.Text = mParameter.Inj[0].Position_Data.End_UV_Pitch.ToString("0.00");
            E_Verters_Speed.Text = mParameter.Inj[0].Position_Data.Move_Speed.ToString("0.00");
            E_Verters_Speed2.Text = mParameter.Inj[0].Position_Data.UV_Speed.ToString("0.00");
            E_Verters_Delay_Pitch1.Text = mParameter.Inj[0].Position_Data.Delay_Pitch1.ToString("0.00");
            E_Verters_Delay_Pitch2.Text = mParameter.Inj[0].Position_Data.Delay_Pitch2.ToString("0.00");
            E_Verters_End_Ahead_Time.Text = mParameter.Inj[0].Position_Data.End_Ahead_Time.ToString("0.00");
            //水平
            E_Horzers_Start_Base_Pitch.Text = mParameter.Inj[1].Position_Data.Start_Base_Pitch.ToString("0.00");
            E_Horzers_Start_X_Pitch.Text = mParameter.Inj[1].Position_Data.Start_X_Pitch.ToString("0.00");
            E_Horzers_Start_Width_Pitch.Text = mParameter.Inj[1].Position_Data.Start_Width_Pitch.ToString("0.00");
            E_Horzers_End_X_Pitch.Text = mParameter.Inj[1].Position_Data.End_X_Pitch.ToString("0.00");
            E_Horzers_End_UV_Pitch.Text = mParameter.Inj[1].Position_Data.End_UV_Pitch.ToString("0.00");
            E_Horzers_Speed.Text = mParameter.Inj[1].Position_Data.Move_Speed.ToString("0.00");
            E_Horzers_Speed2.Text = mParameter.Inj[1].Position_Data.UV_Speed.ToString("0.00");
            E_Horzers_Delay_Pitch1.Text = mParameter.Inj[1].Position_Data.Delay_Pitch1.ToString("0.00");
            E_Horzers_Delay_Pitch2.Text = mParameter.Inj[1].Position_Data.Delay_Pitch2.ToString("0.00");
            E_Horzers_End_Ahead_Time.Text = mParameter.Inj[1].Position_Data.End_Ahead_Time.ToString("0.00");
            //塗膠路徑
            for (int i = 0; i < 2; i++)
            {
                //if (Inj_Obj[i].SG.RowCount > 1)
                    Inj_Obj[i].SG.RowCount = 100;
                for (int j = 0; j < 100; j++)
                {
                    itmp = 0;
                    Inj_Obj[i].SG.Rows[j].HeaderCell.Value = Convert.ToString("No." + (j + 1));
                    Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_X.ToString("0.00");
                    //Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_Y.ToString("0.0");
                    Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_Z.ToString("0.00");
                    Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_Speed.ToString("0.00");
                    //Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_End_Ahead_Time.ToString("0");

                    Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_Apply;

                    Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_End;

                    Inj_Obj[i].SG.Rows[j].Cells[itmp++].Value = mParameter.Inj[i].Point[j].Inj_UV;
                }
            }

            dataGridView1 = Inj_Obj[0].SG;
            dataGridView2 = Inj_Obj[1].SG;

            E_Masashi_Channel.Text = mParameter.Musashi_Channel.ToString();
        }

        private void B_Verters_Cal_Path_Click(object sender, EventArgs e)
        {


            string tmp_str;
            TInj_Point_Struct tmp_inj = new TInj_Point_Struct();

            itmp = 0;

            itmp = itmp++;
            tmp_inj.Inj_X = 0.00;
            Inj_Obj[0].SG.Rows[1].Cells[itmp].Value = tmp_inj.Inj_X.ToString();

            tmp_inj.Inj_X = Convert.ToDouble(E_Verters_Start_Base_Pitch.Text)   
                          + Convert.ToDouble(E_Verters_Start_X_Pitch.Text);
            Inj_Obj[0].SG.Rows[2].Cells[itmp].Value = tmp_inj.Inj_X.ToString();

            tmp_inj.Inj_X = Convert.ToDouble(E_Verters_Start_X_Pitch.Text)              //起始
                          + Convert.ToDouble(E_Verters_Delay_Pitch1.Text)               //延遲
                          + Convert.ToDouble(E_Verters_Start_Width_Pitch.Text)          //產品尺寸
                          - Convert.ToDouble(E_Verters_Delay_Pitch2.Text)               //早收
                          + Convert.ToDouble(E_Horzers_End_X_Pitch);                    //結束
            Inj_Obj[0].SG.Rows[3].Cells[itmp].Value = tmp_inj.Inj_X.ToString();

            tmp_inj.Inj_X = Convert.ToDouble(E_Verters_Start_X_Pitch.Text) 
                          + Convert.ToDouble(E_Verters_Delay_Pitch1.Text) 
                          + Convert.ToDouble(E_Verters_Start_Width_Pitch.Text) 
                          + Convert.ToDouble(E_Verters_End_X_Pitch.Text) 
                          - Convert.ToDouble(E_Verters_Delay_Pitch2.Text) 
                          + Convert.ToDouble(E_Verters_End_UV_Pitch.Text);
            Inj_Obj[0].SG.Rows[4].Cells[itmp].Value = tmp_inj.Inj_X.ToString();
            
        }

        private void B_Horzers_Cal_Path_Click(object sender, EventArgs e)
        {
            string tmp_str;
            TInj_Point_Struct tmp_inj = new TInj_Point_Struct();

            itmp = 0;

            //塗膠起始點(下壓刀最左邊位置)
            itmp = itmp + 1;
            tmp_inj.Inj_X = 0.00;
            Inj_Obj[1].SG.Rows[1].Cells[itmp].Value = tmp_inj.Inj_X;

            //塗膠位置 = 基準點 + 起始點 + 延塗
            tmp_inj.Inj_X = Convert.ToDouble(E_Horzers_Start_Base_Pitch.Text)  
                          + Convert.ToDouble(E_Horzers_Start_X_Pitch.Text);
            Inj_Obj[1].SG.Rows[2].Cells[itmp].Value = tmp_inj.Inj_X.ToString();

            //塗膠位置 = 起始點 + 產品尺寸 - 早收 + 結束點
            tmp_inj.Inj_X = Convert.ToDouble(E_Horzers_Start_X_Pitch.Text)
                          + Convert.ToDouble(E_Horzers_Delay_Pitch1.Text)
                          + Convert.ToDouble(E_Horzers_Start_Width_Pitch.Text)
                          - Convert.ToDouble(E_Horzers_Delay_Pitch2.Text)
                          + Convert.ToDouble(E_Horzers_End_X_Pitch.Text);
            Inj_Obj[1].SG.Rows[3].Cells[itmp].Value = tmp_inj.Inj_X.ToString();

            tmp_inj.Inj_X = Convert.ToDouble(E_Horzers_Start_X_Pitch.Text)
                          + Convert.ToDouble(E_Horzers_Delay_Pitch1.Text)
                          + Convert.ToDouble(E_Horzers_Start_Width_Pitch.Text)
                          + Convert.ToDouble(E_Horzers_End_X_Pitch.Text)
                          - Convert.ToDouble(E_Horzers_Delay_Pitch2.Text)
                          + Convert.ToDouble(E_Horzers_End_UV_Pitch.Text);
            Inj_Obj[1].SG.Rows[4].Cells[itmp].Value = tmp_inj.Inj_X.ToString();

        }
        
    }
}
