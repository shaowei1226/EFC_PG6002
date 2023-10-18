using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

using EFC.Tool;
using EFC.INI;
using EFC.Camera;
using EFC.Light;
using EFC.Vision.Halcon;
using EFC.CAD;
using EFC.Robot.Epson;



namespace Main
{
    public enum emGrab_Mode { M1_2P, M2_4P, M3_8P };
    public enum emBase_Point { P1, P2, P3, P4, L1_Mid, L2_Mid, L3_Mid, L4_Mid, Center };
    public enum emBase_Angle { L1, L2, L3, L4, L1_L2, L2_L3, L3_L4, L1_L4 };
    public enum emSupply_Mode { None, Punch, Tray };
    

    public partial class TForm_Select_Recipe : Form
    {
        public string                     Log_Source = "TForm_Select_Recipe";
        public string                     Default_Path,
                                          Default_FileName;
        public TRecipe                    Param = new TRecipe();
        public bool                       On_Setting = false;
        public bool                       On_Setting_Panel = false;
        public TRecipe_Tray               Tray = null;
        public TOfs                       Ofs = null;
        public TLimit                     Limit = null;
        public TEpson_Robot               Robot = null;
        public int RB_S = 0;
        public TRecipe_Robot_Pos_List     Robot_Pos = null;
        public TRecipe_Robot1_Pos         Step = null;
        public TForm_Select_Recipe(TRecipe param)
        {
            InitializeComponent();

            Set_Param(param);
        }
        private void TForm_Select_Recipe_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            TV_Menu.TopNode.Expand();
            PageControl_Tool.Tab_Page_Hide(tabControl1);
            tFrame_JJS_HW1.Only_Window = true;

           
        }
        public void Log_Add(string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            TPub.Log.Add(Log_Source, fun, msg_str, type);
        }
        private void Set_Param(TRecipe param)
        {
            Param.Set(param);
            Set_Param();
        }

        private void Set_Param()
        {
            On_Setting = true;
            E_Recipe_Code.Text = Param.Recipe_Code.ToString("0000");
            E_Recipe_Name.Text = Param.Recipe_Name;
            E_Recipe_Info.Text = Param.Info;
      
            Set_Param_Tray();
            Set_Param_PCB();
            Set_Param_ACF();
            Set_Param_Ofs();
            Set_Param_Plasma();
            //Set_Param_RB_Start_no;
            Set_Param_Robot_Pos_Grid();
            Set_Param_Limit();
            On_Setting = false;
        }

        private void Set_Param_Robot_Pos_Grid()
        {
            DataGridView dg = DG_Robot_Pos;
            

            if (Robot_Pos != null)
            {
                CB_Robot_Pos_Count.Text = Robot_Pos.Count.ToString();
                CB_Robot_Pos_Start_No.Text = Robot_Pos.Start_No.ToString();
                dg.RowCount = Robot_Pos.Count;
                for (int i = 0; i < dg.RowCount; i++)
                {
                    Set_Param_Robot_Pos_Grid_Pos(dg, Robot_Pos.Items[i], i);
                }
            }
        }
        private void Set_Param_Robot_Pos_Grid_Pos(DataGridView dg, TRecipe_Robot_Pos pos, int pos_no)
        {
            dg.Rows[pos_no].Cells[0].Value = string.Format("{0:d}", pos.Pos.No);
            dg.Rows[pos_no].Cells[1].Value = string.Format("{0:d}", pos.Pos.Local);
            dg.Rows[pos_no].Cells[2].Value = string.Format("{0:f0}", pos.Speed);
            dg.Rows[pos_no].Cells[3].Value = string.Format("{0:f3}", pos.Pos.X);
            dg.Rows[pos_no].Cells[4].Value = string.Format("{0:f3}", pos.Pos.Y);
            dg.Rows[pos_no].Cells[5].Value = string.Format("{0:f3}", pos.Pos.Z);
            dg.Rows[pos_no].Cells[6].Value = string.Format("{0:f3}", pos.Pos.U);
            dg.Rows[pos_no].Cells[7].Value = string.Format("{0:f3}", pos.Pos.V);
            dg.Rows[pos_no].Cells[8].Value = string.Format("{0:f3}", pos.Pos.W);
            dg.Rows[pos_no].Cells[9].Value = string.Format("{0:s}", pos.Pos.Elbow.ToString());
            dg.Rows[pos_no].Cells[10].Value = string.Format("{0:s}", pos.Pos.Hand.ToString());
            dg.Rows[pos_no].Cells[11].Value = string.Format("{0:s}", pos.Pos.Wrist.ToString());
            dg.Rows[pos_no].Cells[12].Value = string.Format("{0:s}", pos.Pos.Description.ToString());
        }


        private void Set_Param_Tray()
        {
            if (Tray != null)
            {
                E_Tray_Start_X.Text = Tray.Start_X.ToString("0.000");
                E_Tray_Start_Y.Text = Tray.Start_Y.ToString("0.000");
                E_Tray_Pitch_X.Text = Tray.Pitch_X.ToString("0.000");
                E_Tray_Pitch_Y.Text = Tray.Pitch_Y.ToString("0.000");
                E_Tray_Num_X.Text = Tray.Num_X.ToString();
                E_Tray_Num_Y.Text = Tray.Num_Y.ToString();
            }
        }
        private void Set_Param_PCB()
        {
            Set_Param_PCB_Size();
            Set_Param_PCB_Mark();
        }
        private void Set_Param_Plasma()
         {
          Set_Param_Plasma_Clean();

         }
        private void Set_Param_Plasma_Clean()
        {
            E_Plasma_Clean_Speed.Text = Param.Plasma.Clean_Speed.ToString("0.000");
            E_Plasma_Clean_Count.Text = Param.Plasma.Clean_Count.ToString("0");
        }
        private void Set_Param_PCB_Size()
        {
            E_Panel_X.Text = Param.PCB.X.ToString("0.000");
            E_Panel_Y.Text = Param.PCB.Y.ToString("0.000");
            E_Panel_Z.Text = Param.PCB.Z.ToString("0.000");
        }
        private void Set_Param_PCB_Mark()
        {
            TRecipe_Mark mark = Param.PCB.Mark;

            if (mark != null)
            {
                E_COF_Mark_L_X.Text = mark.L_Mark_X.ToString("0.000");
                E_COF_Mark_L_Y.Text = mark.L_Mark_Y.ToString("0.000");
                E_COF_Mark_R_X.Text = mark.R_Mark_X.ToString("0.000");
                E_COF_Mark_R_Y.Text = mark.R_Mark_Y.ToString("0.000");
            }
        }

        private void Set_Param_ACF()
        {
            Set_Param_ACF_Bond();
            Set_Param_ACF_Pos_Grid();
        }
        private void Set_Param_ACF_Bond()
        {
            TRecipe_ACF_Bond_Param bond = Param.ACF.Bond;
            double tmp = 0;

            if (bond != null)
            {
                E_ACF_Temp_Up.Text = bond.Up_Temp[0].ToString("0");
                E_ACF_Temp_Dn.Text = bond.Dn_Temp[0].ToString("0");

                E_ACF_Press1.Text = bond.Pressure.ToString("0");

                tmp = bond.Pressure / 4096 * 10;
                E_ACF_Press2.Text = tmp.ToString("0.00");

                tmp = bond.Pressure / 4096 * 10;
                E_ACF_Press3.Text = tmp.ToString("0.00");

                E_ACF_Time.Text = bond.Time.ToString("0.0");
               // E_ACF_Press1.Text = bond.Pressure.ToString("0");
               //// E_ACF_Press2.Text = bond.Pressure1.ToString("0.0");
               // E_ACF_Press3.Text = bond.Pressure2.ToString("0.0");

               // E_ACF_Time.Text = bond.Time.ToString("0.0");
            }
        }
        private void Set_Param_ACF_Pos_Grid()
        {
            DataGridView dg = DG_ACF_Pos;
            TRecipe_PCB_Pos_List pos_list = Param.ACF.Pos_List;

            if (pos_list != null)
            {
                E_ACF_Length.Text = pos_list.ACF_Length.ToString("0.000");
                E_Check_Pitch.Text = pos_list.Check_Pitch.ToString("0.000");
                CB_ACF_Pos_Count.Text = pos_list.Count.ToString();
                dg.RowCount = pos_list.Count;
                for (int i = 0; i < dg.RowCount; i++)
                {
                    Set_Param_ACF_Pos_Grid_Pos(dg, pos_list.Items[i], i);
                }
            }
        }
        private void Set_Param_ACF_Pos_Grid_Pos(DataGridView dg, TRecipe_PCB_Pos pos, int pos_no)
        {
            dg.Rows[pos_no].Cells[00].Value = string.Format("{0:d}", pos_no + 1);
            dg.Rows[pos_no].Cells[01].Value = string.Format("{0:f3}", pos.X);
            dg.Rows[pos_no].Cells[02].Value = string.Format("{0:f3}", pos.Y);
            dg.Rows[pos_no].Cells[03].Value = string.Format("{0:f3}", pos.B_Ofs_X);
            dg.Rows[pos_no].Cells[04].Value = string.Format("{0:f3}", pos.B_Ofs_Y);
            dg.Rows[pos_no].Cells[05].Value = string.Format("{0:f3}", pos.B_Ofs_Q);
            dg.Rows[pos_no].Cells[06].Value = string.Format("{0:f3}", pos.C_Ofs_X);
            dg.Rows[pos_no].Cells[07].Value = string.Format("{0:f3}", pos.C_Ofs_Y);
            dg.Rows[pos_no].Cells[08].Value = string.Format("{0:f3}", pos.C_Ofs_Q);
            dg.Rows[pos_no].Cells[09].Value = "1參數";
            dg.Rows[pos_no].Cells[10].Value = "2參數";
            dg.Rows[pos_no].Cells[11].Value = "1光源";
            dg.Rows[pos_no].Cells[12].Value = "2光源";
        }


        private void Set_Param_Ofs()
        {
            if (Ofs != null)
            {
                E_Ofs_X.Text = Ofs.X.ToString("0.000");
                E_Ofs_Y.Text = Ofs.Y.ToString("0.000");
                E_Ofs_Q.Text = Ofs.Q.ToString("0.000");
            }
        }
        private void Set_Param_Limit()
        {
            if (Limit != null)
            {
                CB_Limit_Length_SW.Checked = Limit.SW;
                E_Limit_Length_Min.Text = Limit.Min.ToString("0.000");
                E_Limit_Length_Max.Text = Limit.Max.ToString("0.000");
            }
        }


        private void Update_Param()
        {
            Param.Recipe_Code = Convert.ToInt32(E_Recipe_Code.Text);
            Param.Info = E_Recipe_Info.Text;

            Update_Param_Tray();
            Update_Param_PCB();
            Update_Param_ACF();
            Update_Param_Ofs();
            Update_Param_Limit();
            Update_Param_Robot_Pos_Grid();
            Update_Param_Plasma();
            Param.Update();
        }
        private void Update_Param_Robot_Pos_Grid()
        {
            int sss;
            try
            {
                DataGridView dg = DG_Robot_Pos;
                Robot_Pos.Start_No = int.Parse(CB_Robot_Pos_Start_No.Text);
                if (Robot_Pos != null)
                {
                    for (int i = 0; i < dg.RowCount; i++)
                    {
                        Update_Param_Robot_Pos_Grid_Pos(dg, Robot_Pos.Items[i], i);
                    }
                }
            }
            catch { };
        }
        private void Update_Param_Robot_Pos_Grid_Pos(DataGridView dg, TRecipe_Robot_Pos pos, int pos_no)
        {
            try
            {
                //pos.Local = Convert.ToInt32(dg.Rows[pos_no].Cells[1].Value);
                pos.Speed = Convert.ToDouble(dg.Rows[pos_no].Cells[2].Value);
                pos.Pos.X = Convert.ToSingle(dg.Rows[pos_no].Cells[3].Value);
                pos.Pos.Y = Convert.ToSingle(dg.Rows[pos_no].Cells[4].Value);
                pos.Pos.Z = Convert.ToSingle(dg.Rows[pos_no].Cells[5].Value);
                pos.Pos.U = Convert.ToSingle(dg.Rows[pos_no].Cells[6].Value);
                pos.Pos.V = Convert.ToSingle(dg.Rows[pos_no].Cells[7].Value);
                pos.Pos.W = Convert.ToSingle(dg.Rows[pos_no].Cells[8].Value);
                pos.Pos.Elbow_Str = Convert.ToString(dg.Rows[pos_no].Cells[9].Value);
                pos.Pos.Hand_Str = Convert.ToString(dg.Rows[pos_no].Cells[10].Value);
                pos.Pos.Wrist_Str = Convert.ToString(dg.Rows[pos_no].Cells[11].Value);

                pos.Pos.Description = Convert.ToString(dg.Rows[pos_no].Cells[12].Value);
            }
            catch { };
        }


        private void Update_Param_Tray()
        {
            try
            {
                if (Tray != null)
                {
                    Tray.Start_X = Convert.ToDouble(E_Tray_Start_X.Text);
                    Tray.Start_Y = Convert.ToDouble(E_Tray_Start_Y.Text);
                    Tray.Pitch_X = Convert.ToDouble(E_Tray_Pitch_X.Text);
                    Tray.Pitch_Y = Convert.ToDouble(E_Tray_Pitch_Y.Text);
                    Tray.Num_X = Convert.ToInt32(E_Tray_Num_X.Text);
                    Tray.Num_Y = Convert.ToInt32(E_Tray_Num_Y.Text);
                }
            }
            catch { };
        }
        private void Update_Param_PCB()
        {
            Update_Param_PCB_Size();
            Update_Param_PCB_Mark();
        }
        private void Update_Param_Plasma()
        {
            Update_Plasma();
        }
        private void Update_Param_PCB_Size()
        {
            try
            {
                Param.PCB.X = Convert.ToDouble(E_Panel_X.Text);
                Param.PCB.Y = Convert.ToDouble(E_Panel_Y.Text);
                Param.PCB.Z = Convert.ToDouble(E_Panel_Z.Text);
            }
            catch { };
        }
        private void Update_Plasma()
        {
            try
            {
                Param.Plasma.Clean_Speed = Convert.ToDouble(E_Plasma_Clean_Speed.Text);
                Param.Plasma.Clean_Count = Convert.ToInt32(E_Plasma_Clean_Count.Text);
            }
            catch { };
        }
        public void Update_Param_PCB_Mark()
        {
            TRecipe_Mark mark = Param.PCB.Mark;

            if (mark != null)
            {
                try
                {
                    mark.L_Mark_X = Convert.ToDouble(E_COF_Mark_L_X.Text);
                    mark.L_Mark_Y = Convert.ToDouble(E_COF_Mark_L_Y.Text);
                    mark.R_Mark_X = Convert.ToDouble(E_COF_Mark_R_X.Text);
                    mark.R_Mark_Y = Convert.ToDouble(E_COF_Mark_R_Y.Text);
                }
                catch { }
            }
        }

        private void Update_Param_ACF()
        {
            Update_Param_ACF_Bond();
            Update_Param_ACF_Pos_Grid();
        }
        private void Update_Param_ACF_Bond()
        {
            TRecipe_ACF_Bond_Param bond = Param.ACF.Bond;

            if (bond != null)
            {
                try
                {
                    bond.Up_Temp[0] = Convert.ToDouble(E_ACF_Temp_Up.Text);
                    bond.Dn_Temp[0] = Convert.ToDouble(E_ACF_Temp_Dn.Text);

                    bond.Pressure = Convert.ToDouble(E_ACF_Press1.Text);
                    bond.Time = Convert.ToDouble(E_ACF_Time.Text);
                }
                catch { }
            }
        }
        private void Update_Param_ACF_Pos_Grid()
        {
            TRecipe_PCB_Pos_List pos_list = Param.ACF.Pos_List;

            try
            {
                DataGridView dg = DG_ACF_Pos;

                if (pos_list != null)
                {
                    pos_list.ACF_Length = Convert.ToDouble(E_ACF_Length.Text);
                    pos_list.Check_Pitch = Convert.ToDouble(E_Check_Pitch.Text);
                    for (int i = 0; i < dg.RowCount; i++)
                    {
                        Update_Param_ACF_Pos_Grid_Pos(dg, pos_list.Items[i], i);
                    }
                }
            }
            catch { };
        }
        private void Update_Param_ACF_Pos_Grid_Pos(DataGridView dg, TRecipe_PCB_Pos pos, int pos_no)
        {
            try
            {
                pos.X                = Convert.ToDouble(dg.Rows[pos_no].Cells[1].Value);
                pos.Y                = Convert.ToDouble(dg.Rows[pos_no].Cells[2].Value);
                pos.B_Ofs_X          = Convert.ToDouble(dg.Rows[pos_no].Cells[3].Value);
                pos.B_Ofs_Y          = Convert.ToDouble(dg.Rows[pos_no].Cells[4].Value);
                pos.B_Ofs_Q          = Convert.ToDouble(dg.Rows[pos_no].Cells[5].Value);
                pos.C_Ofs_X          = Convert.ToDouble(dg.Rows[pos_no].Cells[6].Value);
                pos.C_Ofs_Y          = Convert.ToDouble(dg.Rows[pos_no].Cells[7].Value);
                pos.C_Ofs_Q          = Convert.ToDouble(dg.Rows[pos_no].Cells[8].Value);
            }
            catch { };
        }
        public TJJS_Point Get_Tray_Pos(int no)
        {
            TJJS_Point result = new TJJS_Point();
            int no_x = 0, no_y = 0;

            Get_Tray_XY_No(no, out no_x, out no_y);
            result.X = no_x * int.Parse(E_Tray_Pitch_X.Text);
            result.Y = no_y * int.Parse(E_Tray_Pitch_Y.Text);
            return result;
        }
        public void Get_Tray_XY_No(int no, out int no_x, out int no_y)
        {
            no_x = 0;
            no_y = 0;
            no_x = no % int.Parse(E_Tray_Num_X.Text);
            no_y = no / int.Parse(E_Tray_Num_Y.Text);
        }
        private void Update_Param_Ofs()
        {
            if (Ofs != null)
            {
                try
                {
                    Ofs.X = Convert.ToDouble(E_Ofs_X.Text);
                    Ofs.Y = Convert.ToDouble(E_Ofs_Y.Text);
                    Ofs.Q = Convert.ToDouble(E_Ofs_Q.Text);
                }
                catch { }
            }
        }
        private void Update_Param_Limit()
        {
            if (Limit != null)
            {
                Limit.SW = CB_Limit_Length_SW.Checked;
                Limit.Min = Convert.ToDouble(E_Limit_Length_Min.Text);
                Limit.Max = Convert.ToDouble(E_Limit_Length_Max.Text);
            }
        }


        private void B_Apply_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("確定要套用設定並儲存檔案??", "套用生產設定", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Update_Param();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Save_As_Click(object sender, EventArgs e)
        {
            string fun = "B_Save_As_Click";
            TForm_Select_Path form = new TForm_Select_Path();
            string old_recipe_id;

            form.Default_Path = Param.Default_Path;
            form.Dialog_Type = "SaveDialog";
            form.Check_File = "produce.xml";
            form.Path_Name = Param.Recipe_Name;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("確定要套用設定並儲存檔案??", "另存生產設定", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    TEFC_Message.Show("儲存檔案", "", 500);
                    Update_Param();
                    old_recipe_id = Param.Recipe_Name;
                    Param.Recipe_Name = form.Path_Name;
                    Param.SaveAs(old_recipe_id);
                    Log_Add(fun, "儲存生產參數" + Param.Default_Path + Param.Recipe_Name);
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    TEFC_Message.End();
                }
            }
        }
        private void B_Open_Click(object sender, EventArgs e)
        {
            string fun = "B_Open_Click";
            TForm_Select_Path form = new TForm_Select_Path();
            TRecipe new_param = new TRecipe();

            form.Default_Path = Param.Default_Path;
            form.Check_File = "produce.xml";
            form.Path_Name = Param.Recipe_Name;
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (MessageBox.Show("確定要開啟檔案，套用設定??", "開啟生產設定", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    TEFC_Message.Show("開啟檔案", "", 500);
                    new_param.Default_Path = Param.Default_Path;
                    new_param.Read(new_param.Default_Path + form.Path_Name + "\\produce.xml");
                    Set_Param(new_param);
                    E_Recipe_Name.Text = Param.Recipe_Name;
                    Log_Add(fun, "開啟生產參數" + Param.Default_Path + Param.Recipe_Name);
                    TEFC_Message.End();
                }
            }
        }


        private int Get_Grid_Select_Row(DataGridView dg)
        {
            int result = -1;
            int[] select = Get_Grid_Select_Rows(dg);

            if (select.Length > 0) result = select[0];
            return result;
        }
        private int[] Get_Grid_Select_Rows(DataGridView dg)
        {
            int[] result = new int[0];
            ArrayList list = new ArrayList();
            int no = 0;
            bool select = false;

            for (int i = 0; i < dg.SelectedCells.Count; i++)
            {
                no = dg.SelectedCells[i].RowIndex;
                select = false;
                for (int j = 0; j < list.Count; j++)
                {
                    if ((int)list[j] == no)
                    {
                        select = true;
                        break;
                    }
                }
                if (!select) list.Add(no);
            }
            list.Sort();

            Array.Resize(ref result, list.Count);
            for (int i = 0; i < list.Count; i++) result[i] = (int)list[i];

            return result;
        }
        private void Set_Grid_Select_Row(DataGridView dg, int no)
        {
            if (no >= 0)
            {
                for (int i = 0; i < dg.Rows.Count; i++) dg.Rows[i].Selected = false;
                if (no < dg.Rows.Count) dg.Rows[no].Selected = true;
                else if (dg.Rows.Count > 0) dg.Rows[dg.Rows.Count - 1].Selected = true;
            }
        }
        private void B_Edit_MS_Param_Click(object sender, EventArgs e)
        {
            Param.MS_Param.Set_Param();
        }

        private void B_E_COF_Mark_L_Edit_Click(object sender, EventArgs e)
        {
           Model_Edit(ref Param.PCB.Mark.L);
        }
        private void B_E_COF_Mark_R_Edit_Click(object sender, EventArgs e)
        {
            Model_Edit(ref Param.PCB.Mark.R);
        }
        private void B_E_COF_Mark_L_Light_Click(object sender, EventArgs e)
        {
            Model_Light_Edit(ref Param.PCB.Mark.L);
        }
        private void B_E_COF_Mark_R_Light_Click(object sender, EventArgs e)
        {
            Model_Light_Edit(ref Param.PCB.Mark.R);
        }


        private emModel Get_Model(TRecipe_Model model)
        {
            emModel result = emModel.None;

            if (model == Param.PCB.Mark.L) result = emModel.PCB_L;
            if (model == Param.PCB.Mark.R) result = emModel.PCB_R;
            return result;
        }
        private void Model_Edit(ref TRecipe_Model model)
        {
            emModel emModel = emModel.None;

            if (model != null)
            {
                Update_Param();
                emModel = Get_Model(model);
                TCamera_Base camera = TPub.Get_Camera(emModel);
                HImage image = camera.Get_HImage();
                model.Model.Set_Param(image);
                Param.Update();
            }
        }
        private void Model_Light_Edit(ref TRecipe_Model model)
        {
            TCamera_Base camera = null;
            TLight_Channel_List light_channels = new TLight_Channel_List();
            int[] light_value = null;
            emModel emModel = emModel.None;

            if (model != null)
            {
                Update_Param();
                emModel = Get_Model(model);
                camera = TPub.Get_Camera(emModel);
                light_value = model.Light;
                light_channels = TPub.Get_Light_Channels(emModel);
                light_channels.Set_Value(light_value);
                if (light_channels.Set_Param(camera))
                {
                    light_channels.Get_Value(ref light_value);
                }
            }
        }
        private void CB_ACF_Pos_Count_SelectedIndexChanged(object sender, EventArgs e)
        {
            TRecipe_PCB_Pos_List pos_list = Param.ACF.Pos_List;

            if (pos_list != null)
            {
                if (!On_Setting)
                {
                    try
                    {
                        Update_Param();
                        pos_list.Count = Convert.ToInt32(CB_ACF_Pos_Count.Text);
                        Set_Param();
                    }
                    catch { }
                }
            }
        }
        private void B_Update_Param(object sender, EventArgs e)
        {
            Update_Param();
            Set_Param();
        }
        private void B_ACF_Pos_Move_Up_Click(object sender, EventArgs e)
        {
            int no = Get_Grid_Select_Row(DG_ACF_Pos);
            
            Update_Param();
            Param.ACF.Pos_List.Move_Up(no);
            if (no > 0) Set_Grid_Select_Row(DG_ACF_Pos, no - 1);
            Set_Param();
        }
        private void B_ACF_Pos_Move_Dn_Click(object sender, EventArgs e)
        {
            int no = Get_Grid_Select_Row(DG_ACF_Pos);

            Update_Param();
            Param.ACF.Pos_List.Move_Dn(no);
            if (no < DG_ACF_Pos.RowCount) Set_Grid_Select_Row(DG_ACF_Pos, no + 1);
            Set_Param();
        }

        #region ACF Check 1
        private void B_ACF_Check_L_Copy_Click(object sender, EventArgs e)
        {
            TRecipe_PCB_Pos base_check = new TRecipe_PCB_Pos();
            TRecipe_ACF_Check tmp_check = null;
            int pos_no = Get_Grid_Select_Row(DG_ACF_Pos);

            if (pos_no >= 0 && pos_no < Param.ACF.Pos_List.Count)
            {
                if (MessageBox.Show("確定要複製到其他位置??", "複製參數", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    base_check.Set(Param.ACF.Pos_List[pos_no]);
                    for (int i = 0; i < Param.ACF.Pos_List.Count; i++)
                    {
                        for (int j = 0; j < Param.ACF.Pos_List[i].Check.Length; j++)
                        {
                            tmp_check = Param.ACF.Pos_List[i].Check[j];
                            tmp_check.Param.Copy_Param(base_check.Check[j].Param);
                            for (int k = 0; k < tmp_check.Light.Length; k++) tmp_check.Light[k] = base_check.Check[j].Light[k];
                        }
                    }
                }
            }
        }
        private void DG_ACF_Pos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_no = 0;
            int col_no = 0;

            row_no = e.RowIndex;
            col_no = e.ColumnIndex;
            if (col_no == 9) Edit_Check1_Param(row_no);
            if (col_no == 10) Edit_Check2_Param(row_no);
            if (col_no == 11) Edit_Check1_Light(row_no);
            if (col_no == 12) Edit_Check2_Light(row_no);
        }
        public void Edit_Check1_Param(int pos_no)
        {
            emModel em_model = emModel.ACF_Check1;
            TCamera_Base camera = null;
            HImage in_image = null;
            int check_no = 0;
            TFind_ACF_Check_Param acf_check = null;

            Update_Param();
            camera = TPub.Get_Camera(em_model);
            in_image = camera.Get_HImage();
            acf_check = Param.ACF.Pos_List[pos_no].Check[check_no].Param;
            if (acf_check.Set_Param(in_image))
            {
            }
        }
        public void Edit_Check2_Param(int pos_no)
        {
            emModel em_model = emModel.ACF_Check2;
            TCamera_Base camera = null;
            HImage in_image = null;
            int check_no = 1;
            TFind_ACF_Check_Param acf_check = null;

            Update_Param();
            camera = TPub.Get_Camera(em_model);
            in_image = camera.Get_HImage();
            acf_check = Param.ACF.Pos_List[pos_no].Check[check_no].Param;
            if (acf_check.Set_Param(in_image))
            {
            }
        }
        public void Edit_Check1_Light(int pos_no)
        {
            TCamera_Base camera = null;
            TLight_Channel_List light_channels = new TLight_Channel_List();
            int[] light_value = null;
            emModel em_model = emModel.ACF_Check1;
            int check_no = 0;

            Update_Param();
            camera = TPub.Get_Camera(em_model);
            light_value = Param.ACF.Pos_List[pos_no].Check[check_no].Light;
            light_channels = TPub.Get_Light_Channels(em_model);
            light_channels.Set_Value(light_value);
            if (light_channels.Set_Param(camera))
            {
                light_channels.Get_Value(ref light_value);
            }
        }
        public void Edit_Check2_Light(int pos_no)
        {
            TCamera_Base camera = null;
            TLight_Channel_List light_channels = new TLight_Channel_List();
            int[] light_value = null;
            emModel em_model = emModel.ACF_Check2;
            int check_no = 1;

            Update_Param();
            camera = TPub.Get_Camera(em_model);
            light_value = Param.ACF.Pos_List[pos_no].Check[check_no].Light;
            light_channels = TPub.Get_Light_Channels(em_model);
            light_channels.Set_Value(light_value);
            if (light_channels.Set_Param(camera))
            {
                light_channels.Get_Value(ref light_value);
            }
        }
        #endregion

        private void E_Tray_Num_X_TextChanged(object sender, EventArgs e)
        {

        }

        private void DG_ACF_Pos_SelectionChanged(object sender, EventArgs e)
        {
            int no = Get_Grid_Select_Row(DG_ACF_Pos);
            E_ACF_Row_No.Text = (no + 1).ToString();
        }
        private void Set_Robot_Pos(bool flag)
        {
            DG_Robot_Pos.ReadOnly = !flag;
            B_Robot_Pos_Get.Enabled = flag;
        }

        private void TV_Menu_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeNode node = null;
            string[] node_full_text_list = null;
            string node_full_name;
            string node_full_text;
            TFind_ACF_Check_Result check_result = null;

            Update_Param();
            node = TV_Menu.SelectedNode;
            node_full_name = TreeView_Tool.Get_Node_Full_Name(node);
            node_full_text = TreeView_Tool.Get_Node_Full_Text(node);
            node_full_text_list = String_Tool.Break_String(node_full_text, "\\");

            Ofs = null;
            Limit = null;
            LB_Tree_Name.Text = node_full_text;
            PageControl_Tool.Tab_Page_Select(tabControl1, "空白");
            switch (node_full_name)
            {
                #region Tray
                //-----------------------------------------------------------------------------------
                //-- \\Tray
                //-----------------------------------------------------------------------------------
                case "\\Tray":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Tray");
                    Tray = Param.PCB_Tray;
                    break;
                #endregion

                #region PCB
                //-----------------------------------------------------------------------------------
                //-- \\PCB\\Size
                //-----------------------------------------------------------------------------------
                case "\\PCB\\Size":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "外型尺寸");
                    break;

                //-----------------------------------------------------------------------------------
                //-- \\PCB\\Model
                //-----------------------------------------------------------------------------------
                case "\\PCB\\Model":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "COF_Mark");
                    break;

                //-----------------------------------------------------------------------------------
                //-- \\PCB\\Limit
                //-----------------------------------------------------------------------------------
                case "\\PCB\\Limit":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Limit");
                    Limit = Param.PCB.Mark.Limit;
                    break;

                //-----------------------------------------------------------------------------------
                //-- \\PCB\\Ofs
                //-----------------------------------------------------------------------------------
                case "\\PCB\\Ofs":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Ofs");
                    Ofs = Param.PCB.Ofs;
                    break;
                #endregion

                #region Robot
                #region Plasma
                case "\\Robot\\Robot_Home":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_Home.List_Home;
                    RB_S = 1;
                    Set_Robot_Pos(true);
                    break;
                case "\\Robot\\Robot_Tray":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_Tray.List_Load;
                    RB_S = 2;
                    Set_Robot_Pos(true);
                    break;
                case "\\Robot\\Plasma_Load":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_Plasma.List_Load;
                    Set_Robot_Pos(true);
                    RB_S = 3;
                    break;
                case "\\Robot\\Plasma_Unload":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_Plasma.List_Unload;
                    Set_Robot_Pos(true);
                    RB_S = 4;
                    break;

                #endregion

                #region ACF

                case "\\Robot\\ACF_Load":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_ACF.List_Load;
                    Set_Robot_Pos(true);
                    RB_S = 5;
                    break;

                case "\\Robot\\ACF_Unload":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_ACF.List_Unload;
                    Set_Robot_Pos(true);
                    RB_S = 6;
                    break;
                #endregion

                #region PCB

                case "\\Robot\\PCB_Load":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_PCB.List_Load;
                    Set_Robot_Pos(true);
                    RB_S = 7;

                    break;

                case "\\Robot\\PCB_Unload":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_PCB.List_Unload;
                    Set_Robot_Pos(true);
                    RB_S = 8;
                    break;
                #endregion

                #region NG

                case "\\Robot\\NG":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_NG.List_NG;
                 
                    Set_Robot_Pos(true);
                    RB_S = 9;
                    break;
                #endregion

                #region Teach
                case "\\Robot\\Teach":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Robot");
                    Robot = TPub.Robot1;
                    Robot_Pos = Param.Robot.Robot_Teach.List_Teach;
                 
                    Set_Robot_Pos(true);
                    RB_S = 10;
                    break;
                #endregion

                #endregion

                #region ACF
                //-----------------------------------------------------------------------------------
                //-- \\ACF\\Bond
                //-----------------------------------------------------------------------------------
                case "\\ACF\\Bond":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "ACF壓合參數");
                    break;

                //-----------------------------------------------------------------------------------
                //-- \\ACF\\Pos
                //-----------------------------------------------------------------------------------
                case "\\ACF\\Pos":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "ACF位置");
                    break;

                //-----------------------------------------------------------------------------------
                //-- \\ACF\\Other
                //-----------------------------------------------------------------------------------
                case "\\ACF\\Other":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "ACF其他");
                    break;
                #endregion

                #region 機械參數
                //-----------------------------------------------------------------------------------
                //-- \\MS_Param
                //-----------------------------------------------------------------------------------
                case "\\MS_Param":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "機械參數");
                    break;
                #endregion

                #region Plasama
                //-----------------------------------------------------------------------------------
         
                //-----------------------------------------------------------------------------------
                case "\\Plasma":
                    PageControl_Tool.Tab_Page_Select(tabControl1, "Plasma");
                    break;
                #endregion

            }
            Set_Param();
        }

        private void B_Update_Tree_Click(object sender, EventArgs e)
        {

        }

        private void B_Robot_Manager_Click(object sender, EventArgs e)
        {
            if (Robot != null)
            {
                Robot.Show_Dialog_Robot_Manager(this);
            }
        }

        private void B_Robot_Pos_Write_Click(object sender, EventArgs e)
        {
            if (Robot_Pos != null)
            {
                if (MessageBox.Show("確定要儲存Robot資料??", "儲存Robot", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Update_Param();
                    Robot_Save_Pos(Robot, Robot_Pos);
                    Robot.Save_Points();
                    Set_Param();
                    MessageBox.Show("確定要儲存Robot資料完成", "儲存Robot", MessageBoxButtons.OK);
                }
            }
        }

        private void B_Robot_Pos_Read_Click(object sender, EventArgs e)
        {
            if (Robot_Pos != null)
            {
                if (MessageBox.Show("確定要讀取Robot資料??", "讀取Robot", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    Update_Param();
                    Robot_Read_Pos(Robot,ref Robot_Pos);
                    Param.Update();
                    Set_Param();
                    MessageBox.Show("確定要讀取Robot資料完成", "讀取Robot", MessageBoxButtons.OK);
                }
            }
        }
        private void Robot_Read_Pos(TEpson_Robot robot ,ref TRecipe_Robot_Pos_List pos_list)
        {
            TEFC_SpelPoint point = new TEFC_SpelPoint();
            for (int i = 0; i < pos_list.Count; i++)
            {
                point = robot.Get_Point(pos_list.Start_No + i);
                if (point != null)
                {
                    point.No = pos_list[i].Pos.No;
                    pos_list[i].Pos.Set_Data(point);
                }
            }
        }
        private void Robot_Save_Pos(TEpson_Robot robot, TRecipe_Robot_Pos_List pos_list)
        {
            TEFC_SpelPoint point = new TEFC_SpelPoint();

            for (int i = 0; i < pos_list.Count; i++)
            {
                point.Set(pos_list[i]);
                point.No = pos_list.Start_No + i;
                robot.Set_Point(point);
            }
        }

        private void B_Robot_Pos_Get_Click(object sender, EventArgs e)
        {
            DataGridView dg = DG_Robot_Pos;
            int no = Get_Grid_Select_Row(dg);
            TRecipe_Robot_Pos pos = null;

            Update_Param();
            pos = Robot_Pos.Items[no];
            if (Robot == TPub.Robot1)
            {
                pos.Pos.Set_Data(TPub.Robot1.Now_Pos);
            }
            Set_Param();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // 要执行的多个命令
        //    string commands = "cd C:/test/script && python backupzip.py";

        //    // 创建一个进程启动信息对象
        //    ProcessStartInfo psi = new ProcessStartInfo
        //    {
        //        FileName = "cmd.exe",               // 指定要运行的程序
        //        Arguments = "/C " + commands,       // 要执行的多个命令
        //        RedirectStandardOutput = true,      // 启用标准输出重定向，以便我们可以获取命令输出
        //        UseShellExecute = false,            // 不使用系统外壳启动程序
        //        CreateNoWindow = false               // 不创建窗口显示程序
        //    };

        //    // 创建一个进程对象
        //    Process process = new Process { StartInfo = psi };

        //    // 启动进程
        //    process.Start();

        //    // 获取标准输出流，用于获取命令的输出
        //    string output = process.StandardOutput.ReadToEnd();

        //    // 等待进程结束
        //    process.WaitForExit();

        //    // 输出命令的输出
        //    MessageBox.Show(output, "Command Output");
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            TRecipe_Robot_Pos base_speed = new TRecipe_Robot_Pos();
            TRecipe_Robot1_Pos tmp_speed = null;
            DataGridView dg = DG_Robot_Pos;
            int pos_no = Get_Grid_Select_Row(DG_Robot_Pos);

            if (pos_no >= 0)
            {
                if (MessageBox.Show("確定要複製到其他位置??", "複製參數", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    #region Speed
                    switch (RB_S)
                    {
                        case 1:
                            for (int i = 0; i < Param.Robot.Robot_Home.List_Home.Count; i++)
                            {
                                Param.Robot.Robot_Home.List_Home.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                        case 2:
                            for (int i = 0; i < Param.Robot.Robot_Tray.List_Load.Count;i++ )
                            {
                                Param.Robot.Robot_Tray.List_Load.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();   
                            }
                                break;
                        case 3:
                                for (int i = 0; i < Param.Robot.Robot_Plasma.List_Load.Count; i++)
                                {
                                    Param.Robot.Robot_Plasma.List_Load.Items[i].Speed = double.Parse(speedbox.Text);
                                    Set_Param();
                                }
                            break;
                        case 4:
                            for (int i = 0; i < Param.Robot.Robot_Plasma.List_Unload.Count; i++)
                            {
                                Param.Robot.Robot_Plasma.List_Unload.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                        case 5:
                            for (int i = 0; i < Param.Robot.Robot_ACF.List_Load.Count; i++)
                            {
                                Param.Robot.Robot_ACF.List_Load.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                        case 6:
                            for (int i = 0; i < Param.Robot.Robot_ACF.List_Unload.Count; i++)
                            {
                                Param.Robot.Robot_ACF.List_Unload.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                        case 7:
                            for (int i = 0; i < Param.Robot.Robot_PCB.List_Load.Count; i++)
                            {
                                Param.Robot.Robot_PCB.List_Load.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                        case 8:
                            for (int i = 0; i < Param.Robot.Robot_PCB.List_Unload.Count; i++)
                            {
                                Param.Robot.Robot_PCB.List_Unload.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                        case 9:
                            for (int i = 0; i < Param.Robot.Robot_NG.List_NG.Count; i++)
                            {
                                Param.Robot.Robot_NG.List_NG.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                        case 10:
                            for (int i = 0; i < Param.Robot.Robot_Teach.List_Teach.Count; i++)
                            {
                                Param.Robot.Robot_Teach.List_Teach.Items[i].Speed = double.Parse(speedbox.Text);
                                Set_Param();
                            }
                            break;
                   
                    }
 #endregion

                }
            }
           
        }

        private void speedbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void B_Robot_Pos_Move_Up_Click(object sender, EventArgs e)
        {

        }

        private void B_Robot_Pos_Move_Dn_Click(object sender, EventArgs e)
        {

        }

    }


    //-----------------------------------------------------------------------------------------------------
    // TRecipe
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe : TBase_Class
    {
        public string                  In_Default_Path;
        public string                  Recipe_Name,
                                       Default_FileName,
                                       FileName,
                                       Info;

        public int                     Recipe_Code;
        public TRecipe_Tray            PCB_Tray = new TRecipe_Tray();
        public TRecipe_PCB             PCB = new TRecipe_PCB();
        public TRecipe_Plasma          Plasma = new TRecipe_Plasma();
        public TRecipe_Robot           Robot = new TRecipe_Robot();

        public TRecipe_ACF             ACF = new TRecipe_ACF();
        public TMS_Param               MS_Param = new TMS_Param();


        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe()
        {
            MS_Param.On_Update += MS_Param_Update;
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe && dis_base is TRecipe)
            {
                TRecipe sor = (TRecipe)sor_base;
                TRecipe dis = (TRecipe)dis_base;

                dis.Recipe_Name = sor.Recipe_Name;
                dis.Default_FileName = sor.Default_FileName;
                dis.Default_Path = sor.Default_Path;
                dis.FileName = sor.FileName;
                dis.Robot = sor.Robot;
                dis.Info = sor.Info;
                dis.Recipe_Code = sor.Recipe_Code;
                

                TEFC_Message.Add_Message("[Recipe]Copy PCB_Tray");
                dis.PCB_Tray.Set(sor.PCB_Tray);

                TEFC_Message.Add_Message("[Recipe]Copy PCB");
                dis.PCB.Set(sor.PCB);

                TEFC_Message.Add_Message("[Recipe]Copy ACF");
                dis.ACF.Set(sor.ACF);

                TEFC_Message.Add_Message("[Recipe]Copy MS_Param");
                dis.MS_Param.Set(sor.MS_Param);

                TEFC_Message.Add_Message("[Recipe]Cope Plasma");
                dis.Plasma.Set(sor.Plasma);
            }
        }


        public void Set_Default()
        {
            Recipe_Name = "Default";
            Default_FileName = "produce.xml";
            Info = "";
            Recipe_Code = 0;
            PCB_Tray.Set_Default();
            PCB.Set_Default();
            ACF.Set_Default();
            Robot.Set_Default();
            MS_Param_Set_Default();
            Plasma.Set_Default();
        }
        public void MS_Param_Set_Default()
        {
            string section = "";

            MS_Param.Clear();
            #region ACF載台
            #region X
            section = "ACF載台/X";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "入料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取像位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "壓合位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "檢查位置", "", true, true, MS_Param_Value_Get);
            #endregion

            #region Z
            section = "ACF載台/Z";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "入料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取像位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "壓合位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "檢查位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region Q
            section = "ACF載台/Q";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "入料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取像位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "壓合位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "檢查位置", "", true, true, MS_Param_Value_Get);

            #endregion
            #endregion

            #region ACF壓合
            #region Y
            section = "ACF壓合/Y";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取像位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "壓合位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "檢查位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "維修位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region CCD_Y
            section = "ACF壓合/CCD_Y";
            MS_Param.Add_Value_Double(section, "取像位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "檢查位置", "", true, true, MS_Param_Value_Get);
            #endregion

            #endregion

            #region ACF拉帶
            section = "ACF拉帶/Y";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "貼附位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "切刀位置", "", true, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "切刀至壓刀距離", "", false, false, MS_Param_Value_Get);
            #endregion

            #region Plasma
            section = "Plasma/Y";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "入料位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "掃碼位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "起始位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "終點位置", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, false, MS_Param_Value_Get);
            #endregion

            #region PCB_LD
            #region 供料Z
            section = "PCB_LD/供料Z";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "供料位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "供料完成位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "CV位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "對位位置", "", false, true, MS_Param_Value_Get);
            #endregion

            #region 收料Z
            section = "PCB_LD/收料Z";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "收料位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "收料完成位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "CV位置", "", false, true, MS_Param_Value_Get);
           
            #endregion

            #region 搬送X
            section = "PCB_LD/搬送X";
            MS_Param.Add_Value_Double(section, "等待", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "取料位置", "", false, true, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "出料位置", "", false, true, MS_Param_Value_Get);
           

            #endregion
            #endregion

            #region Robot/取Tray
            section = "Robot_取Tray";
            MS_Param.Add_Value_Double(section, "X", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Y", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Q", "", false, false, MS_Param_Value_Get);
            #endregion

            #region 基準位置
            #region 基準位置/取像
            section = "基準位置/取像";
            MS_Param.Add_Value_Double(section, "X", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Y", "", false, false, MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Q", "", false, false, MS_Param_Value_Get);
            #endregion

            #region 基準位置/貼附
            section = "基準位置/貼附";
            MS_Param.Add_Value_Double(section, "X", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Y", MS_Param_Value_Get);
            MS_Param.Add_Value_Double(section, "Q", MS_Param_Value_Get);
            #endregion
            #endregion
        }
        public void MS_Param_Value_Get(TMS_Info_Section section, TMS_Info_Value value)
        {
            double tmp_value = 0;
            string name = section.Name + "/" + value.Name;

            switch (name)
            {
                #region 基準位置
                #region 基準位置/取像
                case "基準位置/取像/X":
                    tmp_value = TPub.PLC.PLC_In.Pos_PCB_Table_X + PCB.Mark.R_Mark_Y; 
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/取像/Y":
                    tmp_value = TPub.PLC.PLC_In.Pos_PCB_Table_Y - PCB.Mark.R_Mark_X;
                    value.Value = tmp_value.ToString("0.000");
                    break;
                #endregion

                #region 基準位置/貼附
                case "基準位置/貼附/X":
                    tmp_value = TPub.PLC.PLC_In.Pos_PCB_Table_X + ACF.Pos_List[0].Y - ACF.Pos_List[0].B_Ofs_X - TPub.PLC.PLC_In.PCB_DX; 
                    value.Value = tmp_value.ToString("0.000");
                    break;

                case "基準位置/貼附/Y":
                    tmp_value = TPub.PLC.PLC_In.Pos_PCB_Table_Y - ACF.Pos_List[0].X - ACF.Pos_List[0].B_Ofs_Y - ACF.Pos_List.ACF_Length / 2 - TPub.PLC.PLC_In.PCB_DY; 
                    value.Value = tmp_value.ToString("0.000");
                    break;
                #endregion


                #endregion

                #region Plasma
                case "Plasma/Y/起始位置":
                    tmp_value = TPub.PLC.PLC_In.AP;
                    value.Value = tmp_value.ToString("0.000");
                    break;
                case "Plasma/Y/終點位置":
                    tmp_value = TPub.PLC.PLC_In.AP + PCB.X;
                    value.Value = tmp_value.ToString("0.000");
                    break;
                #endregion
            }
        }
        public void MS_Param_Update(TMS_Param ms_param)
        {
            string section = "";
            double base_value = 0;
            double value = 0;
            string info = "";

            #region ACF載台
            #region X
            section = "ACF載台/X";
            base_value = ms_param.Get_Value_Double("基準位置/取像", "X");
            value = base_value - PCB.Mark.R_Mark_Y;
            info = string.Format("基準_取像X({0:f3}) - R_Mark_X({1:f3})", base_value, PCB.Mark.R_Mark_Y);
            ms_param.Set_Value_Info(section, "取像位置", value, info);         
  

            #endregion

            #region Q
            section = "ACF載台/Q";
            //value = ms_param.Get_Value_Double("基準位置/取像", "Q");
            //ms_param.Set_Value_Double(section, "取像位置", value);

            base_value = ms_param.Get_Value_Double("基準位置/取像", "Q");
            value = base_value;
            info = string.Format("基準_取像Q({0:f3})", base_value);
            ms_param.Set_Value_Info(section, "取像位置", value, info);

            base_value = ms_param.Get_Value_Double("基準位置/貼附", "Q");
            value = base_value + PCB.Ofs.Q;
            info = string.Format("基準_貼附Q({0:f3}) + Ofs.Q({1:f3})", base_value, PCB.Ofs.Q);
            ms_param.Set_Value_Info(section, "壓合位置", value, info);
            ms_param.Set_Value_Info(section, "檢查位置", value, info);     

            #endregion
            #endregion

            #region ACF壓合
            #region Y
            section = "ACF壓合/Y";


            base_value = ms_param.Get_Value_Double("基準位置/取像", "Y");
            value = base_value + PCB.Mark.R_Mark_X;
            info = string.Format("基準_取像Y({0:f3})+R_Mark_X({1:f3})", base_value, PCB.Mark.R_Mark_X);
            ms_param.Set_Value_Info(section, "取像位置", value, info);


            //value = ms_param.Get_Value_Double("基準位置/取像", "Y") + PCB.Mark.R_Mark_X;
            //ms_param.Set_Value_Double(section, "取像位置", value);
            #endregion

            #region CCD_Y
            section = "ACF壓合/CCD_Y";

            base_value = PCB.Mark.L_Mark_X - PCB.Mark.R_Mark_X;
            value = base_value;
            info = string.Format("L_Mark_X ({0:f3})+R_Mark_X({1:f3})", PCB.Mark.L_Mark_X, PCB.Mark.R_Mark_X);
            ms_param.Set_Value_Info(section, "取像位置", value, info);

            //value = PCB.Mark.L_Mark_X - PCB.Mark.R_Mark_X;
            //ms_param.Set_Value_Double(section, "取像位置", value);


            value = ACF.Pos_List.Check_Pitch;
            ms_param.Set_Value_Double(section, "檢查位置", value);
            #endregion
            #endregion

            #region ACF拉帶
            section = "ACF拉帶/Y";

            value = ACF.Pos_List.ACF_Length - ms_param.Get_Value_Double("ACF拉帶/Y", "切刀至壓刀距離");
            ms_param.Set_Value_Double(section, "貼附位置", value);

            value = ACF.Pos_List.ACF_Length;
            ms_param.Set_Value_Double(section, "切刀位置", value);
            #endregion
        }


        public void Set_Default_Path(string path)
        {
            string tmp_path = "";
            In_Default_Path = path;

            tmp_path = Get_Recipe_Path();
            Robot.Default_Path = tmp_path + "Robot\\";
            PCB_Tray.Default_Path = tmp_path + "PCB_Tray\\";
            PCB.Default_Path = tmp_path + "PCB\\";
            ACF.Default_Path = tmp_path + "ACF\\";
            Plasma.Default_Path = tmp_path + "Plasma\\";
        }
        public string Get_Recipe_Path()
        {
            string result;
            result = In_Default_Path + Recipe_Name + "\\";
            return result;
        }
        public string Get_Recipe_Name(string file_name)
        {
            string result;

            result = System.IO.Path.GetDirectoryName(file_name);
            result = System.IO.Path.GetFileName(result);
            return result;                     
        }
        public bool SaveAs(string sor_recipe_id)
        {
            bool result = true;

            //Recipe_Name = sor_recipe_id;
            Write();
            return result;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "")
                FileName = In_Default_Path + Recipe_Name + "\\" + Default_FileName;
            else
                FileName = filename;
            Recipe_Name = Get_Recipe_Name(FileName);
            Set_Default_Path(In_Default_Path);
            ini = new TJJS_XML_File(FileName);
            result = Read(ini, section);
            return result;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "")
                FileName = In_Default_Path + Recipe_Name + "\\" + Default_FileName;
            else
                FileName = filename;
            Recipe_Name = Get_Recipe_Name(FileName);
            Set_Default_Path(In_Default_Path);
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();

            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Info = ini.ReadString(section, "Info", Info);
                Recipe_Code = ini.ReadInteger(section, "Recipe_Code", Recipe_Code);

                TEFC_Message.Add_Message("[Recipe]Read PCB_Tray");
                PCB_Tray.Read(ini, section + "/PCB_Tray");

                TEFC_Message.Add_Message("[Recipe]Read PCB");
                PCB.Read(ini, section + "/PCB");

                TEFC_Message.Add_Message("[Recipe]Read ACF");
                ACF.Read(ini, section + "/ACF");

                TEFC_Message.Add_Message("[Recipe]Read MS_Param");
                MS_Param.Read(ini, section + "/MS_Param");

                TEFC_Message.Add_Message("[Recipe]Read Plasma");
                Plasma.Read(ini, section + "/Plasma");


                Robot.Read(ini, section + "/Robot");
                Update();
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "Info", Info);
                ini.WriteInteger(section, "Recipe_Code", Recipe_Code);

                TEFC_Message.Add_Message("[Recipe]Write PCB_Tray");
                PCB_Tray.Write(ini, section + "/PCB_Tray");

                TEFC_Message.Add_Message("[Recipe]Write PCB");
                PCB.Write(ini, section + "/PCB");

                TEFC_Message.Add_Message("[Recipe]Write ACF");
                ACF.Write(ini, section + "/ACF");

                TEFC_Message.Add_Message("[Recipe]Write MS_Param");
                MS_Param.Write(ini, section + "/MS_Param");

                TEFC_Message.Add_Message("[Recipe]Read Plasma");
                Plasma.Write(ini, section + "/Plasma");

                Robot.Write(ini, section + "/Robot");

                Update();
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe new_value, ref bool flag)
        {
            log.Add("---------------------Recipe 差異---------------------");
            PCB_Tray.Log_Diff(log, section + "/PCB_Tray", new_value.PCB_Tray, ref flag);
            PCB.Log_Diff(log, section + "/PCB", new_value.PCB, ref flag);
            ACF.Log_Diff(log, section + "/ACF", new_value.ACF, ref flag);
            //Robot.Log_Diff(log, section + "/Robot", new_value.Robot, ref flag);
            MS_Param.Log_Diff(log, section + "/MS_Param", new_value.MS_Param, ref flag);
            log.Add("---------------------Recipe 差異---------------------");
        }
        public void Update()
        {
            MS_Param_Update(MS_Param);
        }
        public int Max_Num(double data1, double data2)
        {
            int result = 0;
            int num = 0;

            result =  (int)(data1 / data2);
            if (result * data2 < data1) result = result + 1;
            return result;
        }
    }
    public class TRecipe_Mark : TBase_Class
    {
        public string In_Default_Path = "";
        public double L_Mark_X = 0;
        public double L_Mark_Y = 0;
        public double R_Mark_X = 0;
        public double R_Mark_Y = 0;
        public TRecipe_Model L = new TRecipe_Model();
        public TRecipe_Model R = new TRecipe_Model();
        public TLimit Limit = new TLimit();


        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Mark()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Mark();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Mark && dis_base is TRecipe_Mark)
            {
                TRecipe_Mark sor = (TRecipe_Mark)sor_base;
                TRecipe_Mark dis = (TRecipe_Mark)dis_base;

                dis.L_Mark_X = sor.L_Mark_X;
                dis.L_Mark_Y = sor.L_Mark_Y;
                dis.R_Mark_X = sor.R_Mark_X;
                dis.R_Mark_Y = sor.R_Mark_Y;
                dis.L.Set(sor.L);
                dis.R.Set(sor.R);
                dis.Limit.Set(sor.Limit);
            }
        }

        public void Set_Default()
        {
            L_Mark_X = 0;
            L_Mark_Y = 0;
            R_Mark_X = 0;
            R_Mark_Y = 0;
            L.Set_Default();
            R.Set_Default();
            Limit.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            L.Default_Path = In_Default_Path + "L\\";
            R.Default_Path = In_Default_Path + "R\\";
            Limit.Default_Path = In_Default_Path + "Limit\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                L_Mark_X = ini.ReadFloat(section, "L_Mark_X", L_Mark_X);
                L_Mark_Y = ini.ReadFloat(section, "L_Mark_Y", L_Mark_Y);
                R_Mark_X = ini.ReadFloat(section, "R_Mark_X", R_Mark_X);
                R_Mark_Y = ini.ReadFloat(section, "R_Mark_Y", R_Mark_Y);
                L.Read(ini, section + "/L");
                R.Read(ini, section + "/R");
                Limit.Read(ini, section + "/Limit");
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "L_Mark_X", L_Mark_X);
                ini.WriteFloat(section, "L_Mark_Y", L_Mark_Y);
                ini.WriteFloat(section, "R_Mark_X", R_Mark_X);
                ini.WriteFloat(section, "R_Mark_Y", R_Mark_Y);
                L.Write(ini, section + "/L");
                R.Write(ini, section + "/R");
                Limit.Write(ini, section + "/Limit");
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_Mark new_value, ref bool flag)
        {
            log.Log_Diff(section + "/L_Mark_X", L_Mark_X, new_value.L_Mark_X, ref flag);
            log.Log_Diff(section + "/L_Mark_Y", L_Mark_Y, new_value.L_Mark_Y, ref flag);
            log.Log_Diff(section + "/R_Mark_X", R_Mark_X, new_value.R_Mark_X, ref flag);
            log.Log_Diff(section + "/R_Mark_Y", R_Mark_Y, new_value.R_Mark_Y, ref flag);
            L.Log_Diff(log, section + "/L", new_value.L, ref flag);
            R.Log_Diff(log, section + "/R", new_value.R, ref flag);
            Limit.Log_Diff(log, section + "/Limit", new_value.Limit, ref flag);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_PCB
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_PCB : TBase_Class
    {
        public string In_Default_Path = "";
        public double X;
        public double Y;
        public double Z;
        public TRecipe_Mark Mark = new TRecipe_Mark();
        public TOfs Ofs = new TOfs();

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_PCB()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_PCB();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_PCB && dis_base is TRecipe_PCB)
            {
                TRecipe_PCB sor = (TRecipe_PCB)sor_base;
                TRecipe_PCB dis = (TRecipe_PCB)dis_base;

                dis.X = sor.X;
                dis.Y = sor.Y;
                dis.Z = sor.Z;
                dis.Mark.Set(sor.Mark);
                dis.Ofs.Set(sor.Ofs);
            }
        }

        public void Set_Default()
        {
            X = 0.0;
            Y = 0.0;
            Z = 0.0;
            Mark.Set_Default();
            Ofs.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Mark.Default_Path = In_Default_Path + "Mark\\";
            Ofs.Default_Path = In_Default_Path + "Ofs\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                X = ini.ReadFloat(section, "X", X);
                Y = ini.ReadFloat(section, "Y", Y);
                Z = ini.ReadFloat(section, "Z", Z);

                Mark.Read(ini, section + "/Mark");
                Ofs.Read(ini, section + "/Ofs");
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "X", X);
                ini.WriteFloat(section, "Y", Y);
                ini.WriteFloat(section, "Z", Z);

                Mark.Write(ini, section + "/Mark");
                Ofs.Write(ini, section + "/Ofs");
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_PCB new_value, ref bool flag)
        {
            log.Log_Diff(section + "/X", X, new_value.X, ref flag);
            log.Log_Diff(section + "/Y", Y, new_value.Y, ref flag);
            log.Log_Diff(section + "/Z", Z, new_value.Z, ref flag);

            Mark.Log_Diff(log, section + "/Mark", new_value.Mark, ref flag);
            Ofs.Log_Diff(log, section + "/Ofs", new_value.Ofs, ref flag);
        }
    }


    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Robot
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Robot : TBase_Class
    {
        public string In_Default_Path = "";
        public TRecipe_Robot1_Pos Robot_Home = new TRecipe_Robot1_Pos();
        public TRecipe_Robot1_Pos Robot_Plasma = new TRecipe_Robot1_Pos();
        public TRecipe_Robot1_Pos Robot_ACF = new TRecipe_Robot1_Pos();
        public TRecipe_Robot1_Pos Robot_PCB = new TRecipe_Robot1_Pos();
        public TRecipe_Robot1_Pos Robot_Tray = new TRecipe_Robot1_Pos();
        public TRecipe_Robot1_Pos Robot_NG = new TRecipe_Robot1_Pos();
        public TRecipe_Robot1_Pos Robot_Teach = new TRecipe_Robot1_Pos();
      
        public TRecipe_Robot_Pos_List Pos_List = new TRecipe_Robot_Pos_List();

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Robot()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Robot();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Robot && dis_base is TRecipe_Robot)
            {
                TRecipe_Robot sor = (TRecipe_Robot)sor_base;
                TRecipe_Robot dis = (TRecipe_Robot)dis_base;

                dis.Robot_Home = sor.Robot_Home;
                dis.Robot_Plasma = sor.Robot_Plasma;
                dis.Robot_ACF = sor.Robot_ACF;
                dis.Robot_Tray = sor.Robot_Tray;
                dis.Robot_PCB = sor.Robot_PCB;
                dis.Robot_NG = sor.Robot_NG;
                dis.Robot_Teach = sor.Robot_Teach;
            }
        }

        public void Set_Default()
        {
            Robot_Home.Set_Default();
            Robot_Plasma.Set_Default();
            Robot_ACF.Set_Default();
            Robot_Tray.Set_Default();
            Robot_PCB.Set_Default();
            Robot_NG.Set_Default();
            Robot_Teach.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Robot_Home.Default_Path = In_Default_Path + "Home";
            Robot_Plasma.Default_Path = In_Default_Path + "Plasma\\";
            Robot_ACF.Default_Path = In_Default_Path + "ACF\\";
            Robot_Tray.Default_Path = In_Default_Path + "Tray\\";
            Robot_PCB.Default_Path = In_Default_Path + "PCB\\";
            Robot_NG.Default_Path = In_Default_Path + "NG\\";
            Robot_Teach.Default_Path = In_Default_Path + "Teach\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Robot_Home.Read(ini, section + "/Home");
                Robot_Plasma.Read(ini, section + "/Plasma");
                Robot_ACF.Read(ini, section + "/ACF");
                Robot_Tray.Read(ini, section + "/Tray");
                Robot_PCB.Read(ini, section + "/PCB");
                Robot_NG.Read(ini, section + "/NG");
                Robot_Teach.Read(ini, section + "/Teach");
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Robot_Home.Write(ini, section + "/Home");
                Robot_Plasma.Write(ini, section + "/Plasma");
                Robot_ACF.Write(ini, section + "/ACF");
                Robot_Tray.Write(ini, section + "/Tray");
                Robot_PCB.Write(ini, section + "/PCB");
                Robot_NG.Write(ini, section + "/NG");
                Robot_Teach.Write(ini, section + "/Teach");

            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_PCB new_value, ref bool flag)
        {
           // Mark.Log_Diff(log, section + "/Mark", new_value.Mark, ref flag);
          //  Ofs.Log_Diff(log, section + "/Ofs", new_value.Ofs, ref flag);
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Plasma
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Plasma : TBase_Class
    {
        public string In_Default_Path = "";
        public double Clean_Speed;
        public int Clean_Count;

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Plasma()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Plasma();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Plasma && dis_base is TRecipe_Plasma)
            {
                TRecipe_Plasma sor = (TRecipe_Plasma)sor_base;
                TRecipe_Plasma dis = (TRecipe_Plasma)dis_base;

                dis.Clean_Speed = sor.Clean_Speed;
                dis.Clean_Count = sor.Clean_Count;

            }
        }

        public void Set_Default()
        {
          
            Clean_Speed = 10.0;
            Clean_Count = 1;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {

                Clean_Speed = ini.ReadFloat(section, "Clean_Speed", Clean_Speed);
                Clean_Count = ini.ReadInteger(section, "Clean_Count", Clean_Count);
  
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
               ini.WriteFloat(section, "Clean_Speed", Clean_Speed);
               ini.WriteInteger(section, "Clean_Count", Clean_Count);


            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_PCB new_value, ref bool flag)
        {
            // Mark.Log_Diff(log, section + "/Mark", new_value.Mark, ref flag);
            //  Ofs.Log_Diff(log, section + "/Ofs", new_value.Ofs, ref flag);
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // TRecipe_ACF
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_ACF : TBase_Class
    {
        public string In_Default_Path = "";
        public TRecipe_ACF_Bond_Param Bond = new TRecipe_ACF_Bond_Param();
        public TRecipe_PCB_Pos_List Pos_List = new TRecipe_PCB_Pos_List();

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_ACF()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_ACF();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_ACF && dis_base is TRecipe_ACF)
            {
                TRecipe_ACF sor = (TRecipe_ACF)sor_base;
                TRecipe_ACF dis = (TRecipe_ACF)dis_base;

                dis.Bond.Set(sor.Bond);
                dis.Pos_List.Set(sor.Pos_List);
            }
        }

        public void Set_Default()
        {
            Bond.Set_Default();
            Pos_List.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Bond.Default_Path = In_Default_Path + "Bond\\";
            Pos_List.Default_Path = In_Default_Path + "Pos_List\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Bond.Read(ini, section + "/Bond");
                Pos_List.Read(ini, section + "/Pos_List");
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Bond.Write(ini, section + "/Bond");
                Pos_List.Write(ini, section + "/Pos_List");
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_ACF new_value, ref bool flag)
        {
            Bond.Log_Diff(log, section + "/Bond", new_value.Bond, ref flag);
            Pos_List.Log_Diff(log, section + "/Pos_List", new_value.Pos_List, ref flag);
        }
    }
    public class TRecipe_PCB_Pos_List : TBase_Class
    {
        public string In_Default_Path = "";

        public double Pitch = 0;
        public TRecipe_PCB_Pos[] Items = new TRecipe_PCB_Pos[0];
        public TLimit Limit = new TLimit();
        public double ACF_Length = 0;
        public double Check_Pitch = 0;

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count = Items.Length;
                Array.Resize(ref Items, value);
                for (int i = old_count; i < value; i++)
                {
                    Items[i] = new TRecipe_PCB_Pos();
                    Items[i].Set_Default_Path(In_Default_Path + "Pos" + (i + 1).ToString() + "\\");
                }
            }
        }
        public TRecipe_PCB_Pos this[int index]
        {
            get
            {
                TRecipe_PCB_Pos result = null;

                if (index >= 0 && index < Count)
                {
                    result = Items[index];
                }
                return result;
            }
        }
        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_PCB_Pos_List()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_PCB_Pos_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_PCB_Pos_List && dis_base is TRecipe_PCB_Pos_List)
            {
                TRecipe_PCB_Pos_List sor = (TRecipe_PCB_Pos_List)sor_base;
                TRecipe_PCB_Pos_List dis = (TRecipe_PCB_Pos_List)dis_base;

                dis.Pitch = sor.Pitch;
                dis.Count = sor.Count;
                for (int i = 0; i < dis.Count; i++) dis.Items[i].Set(sor.Items[i]);
                dis.Limit.Set(sor.Limit);
                dis.ACF_Length = sor.ACF_Length;
                dis.Check_Pitch = sor.Check_Pitch;
            }
        }

        public void Set_Default()
        {
            Pitch = 0;
            for (int i = 0; i < Count; i++) Items[i].Set_Default();
            Limit.Set_Default();
            ACF_Length = 10;
            Check_Pitch = 10;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            for (int i = 0; i < Count; i++) Items[i].Set_Default_Path(In_Default_Path + "Pos" + (i + 1).ToString() + "\\");
            Limit.Default_Path = In_Default_Path + "Limit\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Pitch = ini.ReadFloat(section, "Pitch", Pitch);

                Count = ini.ReadInteger(section, "Count", Count);
                for (int i = 0; i < Count; i++) Items[i].Read(ini, section + "/Items" + (i + 1).ToString());

                Limit.Read(ini, section + "/Limit");
                ACF_Length = ini.ReadFloat(section, "ACF_Length", ACF_Length);
                Check_Pitch = ini.ReadFloat(section, "Check_Pitch", Check_Pitch);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Pitch", Pitch);

                ini.WriteInteger(section, "Count", Count);
                for (int i = 0; i < Count; i++) Items[i].Write(ini, section + "/Items" + (i + 1).ToString());

                Limit.Write(ini, section + "/Limit");
                ini.WriteFloat(section, "ACF_Length", ACF_Length);
                ini.WriteFloat(section, "Check_Pitch", Check_Pitch);
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_PCB_Pos_List new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Pitch", Pitch, new_value.Pitch, ref flag);

            log.Log_Diff(section + "/Count", Count, new_value.Count, ref flag);
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < new_value.Count) Items[i].Log_Diff(log, section + "/Items" + (i + 1).ToString(), new_value.Items[i], ref flag);
            }

            Limit.Log_Diff(log, section + "/Limit", new_value.Limit, ref flag);
            log.Log_Diff(section + "/ACF_Length", ACF_Length, new_value.ACF_Length, ref flag);
            log.Log_Diff(section + "/Check_Pitch", Check_Pitch, new_value.Check_Pitch, ref flag);
        }


        public void Clear()
        {
            Count = 0;
        }
        public void Add(TRecipe_PCB_Pos data)
        {
            int no = Count;
            Count++;
            Items[no].Set(data);
        }
        public void Delete(int no)
        {
            if (no >= 0 && no < Count)
            {
                for (int i = no; i < Count - 1; i++)
                {
                    Items[i] = Items[i + 1];
                }
                Count = Count - 1;
            }
        }
        public void Move_Up(int no)
        {
            Swap(no, no - 1);
        }
        public void Move_Dn(int no)
        {
            Swap(no, no + 1);
        }


        private void Swap(int no1, int no2)
        {
            TRecipe_PCB_Pos temp;
            if (no1 >= 0 && no1 < Count && no2 >= 0 && no2 < Count)
            {
                temp = Items[no1];
                Items[no1] = Items[no2];
                Items[no2] = temp;
            }
        }
    }
    public class TRecipe_PCB_Pos : TBase_Class
    {
        public string In_Default_Path = "";

        public double X = 0;
        public double Y = 0;
        public double B_Ofs_X = 0;
        public double B_Ofs_Y = 0;
        public double B_Ofs_Q = 0;
        public double C_Ofs_X = 0;
        public double C_Ofs_Y = 0;
        public double C_Ofs_Q = 0;
        public TRecipe_ACF_Check[] Check = new TRecipe_ACF_Check[2];

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_PCB_Pos()
        {
            for (int i = 0; i < Check.Length; i++) Check[i] = new TRecipe_ACF_Check();
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_PCB_Pos();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_PCB_Pos && dis_base is TRecipe_PCB_Pos)
            {
                TRecipe_PCB_Pos sor = (TRecipe_PCB_Pos)sor_base;
                TRecipe_PCB_Pos dis = (TRecipe_PCB_Pos)dis_base;

                dis.X = sor.X;
                dis.Y = sor.Y;
                dis.B_Ofs_X = sor.B_Ofs_X;
                dis.B_Ofs_Y = sor.B_Ofs_Y;
                dis.B_Ofs_Q = sor.B_Ofs_Q;
                dis.C_Ofs_X = sor.C_Ofs_X;
                dis.C_Ofs_Y = sor.C_Ofs_Y;
                dis.C_Ofs_Q = sor.C_Ofs_Q;
              
                for (int i = 0; i < dis.Check.Length; i++) dis.Check[i].Set(sor.Check[i]);
            }
        }

        public void Set_Default()
        {
            X = 100.0;
            Y = 100.0;
            B_Ofs_X = 0.0;
            B_Ofs_Y = 0.0;
            B_Ofs_Q = 0.0;
            C_Ofs_X = 0.0;
            C_Ofs_Y = 0.0;
            C_Ofs_Q = 0.0;
            for (int i = 0; i < Check.Length; i++) Check[i].Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            for (int i = 0; i < Check.Length; i++) Check[i].Default_Path = In_Default_Path + "Check" + (i + 1).ToString() + "\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Set_Default_Path(In_Default_Path);
                X = ini.ReadFloat(section, "X", X);
                Y = ini.ReadFloat(section, "Y", Y);
                B_Ofs_X = ini.ReadFloat(section, "B_Ofs_X", B_Ofs_X);
                B_Ofs_Y = ini.ReadFloat(section, "B_Ofs_Y", B_Ofs_Y);
                B_Ofs_Q = ini.ReadFloat(section, "B_Ofs_Q", B_Ofs_Q);
                C_Ofs_X = ini.ReadFloat(section, "C_Ofs_X", C_Ofs_X);
                C_Ofs_Y = ini.ReadFloat(section, "C_Ofs_Y", C_Ofs_Y);
                C_Ofs_Q = ini.ReadFloat(section, "C_Ofs_Q", C_Ofs_Q);

                for (int i = 0; i < Check.Length; i++) Check[i].Read(ini, section + "/Check" + (i + 1).ToString());
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "X", X);
                ini.WriteFloat(section, "Y", Y);
                ini.WriteFloat(section, "B_Ofs_X", B_Ofs_X);
                ini.WriteFloat(section, "B_Ofs_Y", B_Ofs_Y);
                ini.WriteFloat(section, "B_Ofs_Q", B_Ofs_Q);
                ini.WriteFloat(section, "C_Ofs_X", C_Ofs_X);
                ini.WriteFloat(section, "C_Ofs_Y", C_Ofs_Y);
                ini.WriteFloat(section, "C_Ofs_Q", C_Ofs_Q);
                for (int i = 0; i < Check.Length; i++) Check[i].Write(ini, section + "/Check" + (i + 1).ToString());
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_PCB_Pos new_value, ref bool flag)
        {
            log.Log_Diff(section + "/X", X, new_value.X, ref flag);
            log.Log_Diff(section + "/Y", Y, new_value.Y, ref flag);
            log.Log_Diff(section + "/B_Ofs_X", B_Ofs_X, new_value.B_Ofs_X, ref flag);
            log.Log_Diff(section + "/B_Ofs_Y", B_Ofs_Y, new_value.B_Ofs_Y, ref flag);
            log.Log_Diff(section + "/B_Ofs_Q", B_Ofs_Y, new_value.B_Ofs_Q, ref flag);
            log.Log_Diff(section + "/C_Ofs_X", C_Ofs_X, new_value.C_Ofs_X, ref flag);
            log.Log_Diff(section + "/C_Ofs_Y", C_Ofs_Y, new_value.C_Ofs_Y, ref flag);
            log.Log_Diff(section + "/C_Ofs_Q", C_Ofs_Y, new_value.C_Ofs_Q, ref flag);

            for (int i = 0; i < Check.Length; i++) Check[i].Log_Diff(log, section + "/Check" + (i + 1).ToString(), new_value.Check[i], ref flag);
        }
    }
    public class TRecipe_ACF_Check : TBase_Class
    {
        public string In_Default_Path = "";
        public double Check_X = 0;
        public double Check_Y = 0;
        public TFind_ACF_Check_Param Param = new TFind_ACF_Check_Param();
        public int[] Light = new int[4];

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_ACF_Check()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_ACF_Check();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_ACF_Check && dis_base is TRecipe_ACF_Check)
            {
                TRecipe_ACF_Check sor = (TRecipe_ACF_Check)sor_base;
                TRecipe_ACF_Check dis = (TRecipe_ACF_Check)dis_base;

                dis.Check_X = sor.Check_X;
                dis.Check_Y = sor.Check_Y;
                
                dis.Param.Set(sor.Param);
                for (int i = 0; i < dis.Light.Length; i++) dis.Light[i] = sor.Light[i];
            }
        }

        public void Set_Default()
        {
            Check_X = 5;
            Check_Y = 5.0;
            Param.Set_Default();
            for (int i = 0; i < Light.Length; i++) Light[i] = 0;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Param.Default_Path = In_Default_Path + "Check\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Set_Default_Path(In_Default_Path);
                Check_X = ini.ReadFloat(section, "Check_X", Check_X);
                Check_Y = ini.ReadFloat(section, "Check_Y", Check_Y);

                Param.Read(ini, section + "/Param");
                for (int i = 0; i < Light.Length; i++) Light[i] = ini.ReadInteger(section, "Light" + (i + 1).ToString(), Light[i]);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Check_X", Check_X);
                ini.WriteFloat(section, "Check_Y", Check_Y);

                Param.Write(ini, section + "/Param");
                for (int i = 0; i < Light.Length; i++) ini.WriteInteger(section, "Light" + (i + 1).ToString(), Light[i]);
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_ACF_Check new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Check_X", Check_X, new_value.Check_X, ref flag);
            log.Log_Diff(section + "/Check_Y", Check_Y, new_value.Check_Y, ref flag);

            Param.Log_Diff(log, section + "/Param", new_value.Param, ref flag);
            for (int i = 0; i < Light.Length; i++) log.Log_Diff(section + "/Light" + (i + 1).ToString(), Light[i], new_value.Light[i], ref flag);
        }
    }
    public class TRecipe_ACF_Bond_Param : TBase_Class
    {
        public string In_Default_Path = "";
        public double Pressure;  //比例閥單位
        public double Time;
        public double[] Up_Temp = new double[1];
        public double[] Dn_Temp = new double[1];


        public double Pressure2 //比例閥-錶頭單位
        {
            get
            {
                return Pressure / 4096 * 10;
            }
        }
        public double Pressure3 //實測壓力
        {
            get
            {
                return Pressure / 4096 * 10;
            }
        }
        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_ACF_Bond_Param()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_ACF_Bond_Param();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_ACF_Bond_Param && dis_base is TRecipe_ACF_Bond_Param)
            {
                TRecipe_ACF_Bond_Param sor = (TRecipe_ACF_Bond_Param)sor_base;
                TRecipe_ACF_Bond_Param dis = (TRecipe_ACF_Bond_Param)dis_base;

                dis.Pressure = sor.Pressure;
                dis.Time = sor.Time;
                for (int i = 0; i < dis.Up_Temp.Length; i++) dis.Up_Temp[i] = sor.Up_Temp[i];
                for (int i = 0; i < dis.Dn_Temp.Length; i++) dis.Dn_Temp[i] = sor.Dn_Temp[i];
            }
        }

        public void Set_Default()
        {
            Pressure = 10.0;
            Time = 1.0;
            for (int i = 0; i < Up_Temp.Length; i++) Up_Temp[i] = 0;
            for (int i = 0; i < Dn_Temp.Length; i++) Up_Temp[i] = 0;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Pressure = ini.ReadFloat(section, "Pressure", Pressure);
                Time = ini.ReadFloat(section, "Time", Time);
                for (int i = 0; i < Up_Temp.Length; i++) Up_Temp[i] = ini.ReadFloat(section, "Up_Temp" + (i + 1).ToString(), Up_Temp[i]);
                for (int i = 0; i < Dn_Temp.Length; i++) Dn_Temp[i] = ini.ReadFloat(section, "Dn_Temp" + (i + 1).ToString(), Dn_Temp[i]);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Pressure", Pressure);
                ini.WriteFloat(section, "Time", Time);
                for (int i = 0; i < Up_Temp.Length; i++) ini.WriteFloat(section, "Up_Temp" + (i + 1).ToString(), Up_Temp[i]);
                for (int i = 0; i < Dn_Temp.Length; i++) ini.WriteFloat(section, "Dn_Temp" + (i + 1).ToString(), Dn_Temp[i]);
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe_ACF_Bond_Param new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Pressure", Pressure, new_value.Pressure, ref flag);
            log.Log_Diff(section + "/Time", Time, new_value.Time, ref flag);
            for (int i = 0; i < Up_Temp.Length; i++) log.Log_Diff(section + "/Up_Temp" + (i + 1).ToString(), Up_Temp[i], new_value.Up_Temp[i], ref flag);
            for (int i = 0; i < Dn_Temp.Length; i++) log.Log_Diff(section + "/Dn_Temp" + (i + 1).ToString(), Dn_Temp[i], new_value.Dn_Temp[i], ref flag);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Model
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Model : TBase_Class
    {
        public string In_Default_Path = "";
        public TFind_Mothed_1_Param Model = new TFind_Mothed_1_Param();
        public int[] Light = new int[0];

        public int Light_Count
        {
            get
            {
                return Light.Length;
            }
            set
            {
                Array.Resize(ref Light, value);
            }
        }
        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Model()
        {
            Light_Count = 8;
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Model();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Model && dis_base is TRecipe_Model)
            {
                TRecipe_Model sor = (TRecipe_Model)sor_base;
                TRecipe_Model dis = (TRecipe_Model)dis_base;

                dis.Model.Set(sor.Model);
                dis.Light_Count = sor.Light_Count;
                for(int i=0; i<Light_Count; i++)dis.Light[i] = sor.Light[i];
            }
        }

        public void Set_Default()
        {
            Model.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Model.Default_Path = In_Default_Path + "Model\\";
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Model.Read(ini, section + "/Model");

                for (int i = 0; i < Light_Count; i++) Light[i] = ini.ReadInteger(section, "Light" + (i + 1).ToString(), Light[i]);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Model.Write(ini, section + "/Model");

                for (int i = 0; i < Light_Count; i++) ini.WriteInteger(section, "Light" + (i + 1).ToString(), Light[i]);
            }
        }


        public void Log_Diff(TLog log, string section, TRecipe_Model new_value, ref bool flag)
        {
            Model.Log_Diff(log, section + "/Model", new_value.Model, ref flag);

            Log_Diff(log, section + "/Light", Light, new_value.Light, ref flag);
        }
        public void Log_Diff(TLog log, string section, int[] old_value, int[] new_value, ref bool flag)
        {
            if (old_value.Length != new_value.Length) log.Log_Diff(section + "_Count", old_value.Length, new_value.Length, ref flag);
            for (int i = 0; i < old_value.Length; i++)
            {
                if (i < new_value.Length)
                    log.Log_Diff(section + (i + 1).ToString(), old_value[i], new_value[i], ref flag);
            }
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Grab_Pos_Model
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Grab_Pos_Model : TBase_Class
    {
        public string In_Default_Path = "";

        public bool SW = false;
        public int Model_Mode = 0;
        public TFind_Mothed_1_Param Model = new TFind_Mothed_1_Param();
        public int[] Light = new int[2];

        public TBase_Param Param
        {
            get
            {
                TBase_Param result = null;

                switch (Model_Mode)
                {
                    case 0: result = Model; break;
                }
                return result;
            }
        }
        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Grab_Pos_Model()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Grab_Pos_Model();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Grab_Pos_Model && dis_base is TRecipe_Grab_Pos_Model)
            {
                TRecipe_Grab_Pos_Model sor = (TRecipe_Grab_Pos_Model)sor_base;
                TRecipe_Grab_Pos_Model dis = (TRecipe_Grab_Pos_Model)dis_base;

                dis.SW = sor.SW;
                dis.Model_Mode = sor.Model_Mode;
                dis.Model.Set(sor.Model);
                for (int i = 0; i < sor.Light.Length; i++) dis.Light[i] = sor.Light[i];
            }
        }

        public void Set_Default()
        {
            SW = true;
            Model_Mode = 0;
            Model.Set_Default();
            for (int i = 0; i < Light.Length; i++) Light[i] = 0;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
            Model.Set_Default_Path(In_Default_Path + "Model\\");
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Set_Default_Path(In_Default_Path);
                Model_Mode = ini.ReadInteger(section, "Model_Mode", Model_Mode);
                Model.Read(ini, section + "/Model");
                for (int i = 0; i < Light.Length; i++) Light[i] = ini.ReadInteger(section, "Light" + (i + 1).ToString(), Light[i]);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteInteger(section, "Model_Mode", Model_Mode);
                Model.Write(ini, section + "/Model");
                for (int i = 0; i < Light.Length; i++) ini.WriteInteger(section, "Light" + (i + 1).ToString(), Light[i]);
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_Grab_Pos_Model new_value, ref bool flag)
        {
            log.Log_Diff(section + "/SW", SW, new_value.SW, ref flag);
            log.Log_Diff(section + "/Model_Mode", Model_Mode, new_value.Model_Mode, ref flag);
            Model.Log_Diff(log, section + "/Model", new_value.Model, ref flag);

            for (int i = 0; i < Light.Length; i++)
            {
                if (i < new_value.Light.Length) log.Log_Diff(section + "/Light" + (i + 1).ToString(), Light[i], new_value.Light[i], ref flag);
            }
        }
        public bool Set_Param(HImage image)
        {
            bool result = false;
            switch (Model_Mode)
            {
                case 0: result = Model.Set_Param(image); break;
            }
            return result;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Robot_Pos_List
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Robot_Pos_List : TBase_Class
    {
        public int Start_No = 0;
        public TRecipe_Robot_Pos[] Items = new TRecipe_Robot_Pos[0];

        public int Count
        {
            get
            {
                return Items.Length;
            }
            set
            {
                int old_count = Items.Length;
                Array.Resize(ref Items, value);
                for (int i = old_count; i < value; i++)
                {
                    Items[i] = new TRecipe_Robot_Pos();
                }
                Update();
            }
        }
        public TRecipe_Robot_Pos this[int index]
        {
            get
            {
                TRecipe_Robot_Pos result = null;

                if (index >= 0 && index < Count)
                {
                    result = Items[index];
                }
                return result;
            }
        }
        public TRecipe_Robot_Pos_List()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Robot_Pos_List();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Robot_Pos_List && dis_base is TRecipe_Robot_Pos_List)
            {
                TRecipe_Robot_Pos_List sor = (TRecipe_Robot_Pos_List)sor_base;
                TRecipe_Robot_Pos_List dis = (TRecipe_Robot_Pos_List)dis_base;

                dis.Start_No = sor.Start_No;
                dis.Count = sor.Count;
                for (int i = 0; i < dis.Count; i++) dis.Items[i].Set(sor.Items[i]);
            }
        }

        public void Set_Default()
        {
            Start_No = 10;
            Count = 0;
            for (int i = 0; i < Count; i++) Items[i].Set_Default();
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
               Start_No = ini.ReadInteger(section, "Start_No", Start_No);
              //  Start_No = ini.ReadString(section, "Start_No", Start_No);
                for (int i = 0; i < Count; i++)
                    Items[i].Read(ini, section + "/Items" + (i + 1).ToString());
                Update();
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Update();
                ini.WriteInteger(section, "Start_No", Start_No);
               // ini.WriteString(section, "Start_No", Start_No);
                for (int i = 0; i < Count; i++)
                    Items[i].Write(ini, section + "/Items" + (i + 1).ToString());
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_Robot_Pos_List new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Start_No", Start_No, new_value.Start_No, ref flag);
            log.Log_Diff(section + "/Count", Count, new_value.Count, ref flag);
            for (int i = 0; i < Items.Length; i++)
            {
                if (i < new_value.Count)
                    Items[i].Log_Diff(log, section + "/Items" + (i + 1).ToString(), new_value.Items[i], ref flag);
            }
        }
        public void Update()
        {
            for (int i = 0; i < Items.Length; i++) Items[i].Pos.No = Start_No + i;
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Robot_Pos
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Robot_Pos : TBase_Class
    {
        public string In_Default_Path = "";
        public double Speed = 0;
        public TEFC_SpelPoint Pos = new TEFC_SpelPoint();

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Robot_Pos()
        {

        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Robot_Pos();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Robot_Pos && dis_base is TRecipe_Robot_Pos)
            {
                TRecipe_Robot_Pos sor = (TRecipe_Robot_Pos)sor_base;
                TRecipe_Robot_Pos dis = (TRecipe_Robot_Pos)dis_base;

                dis.In_Default_Path = sor.In_Default_Path;
                dis.Speed = sor.Speed;
                dis.Pos.Set(sor.Pos);
            }
        }

        public void Set_Default()
        {
            Speed = 100;
            Pos.Set_Default();
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Speed = ini.ReadFloat(section, "Speed", Speed);
                //Pos.Label = ini.ReadString(section, "Label", Pos.Label);
                //Pos.No = ini.ReadInteger(section, "No", Pos.No);
                Pos.Local = ini.ReadInteger(section, "Local", Pos.Local);
                Pos.X = ini.ReadFloat(section, "X", Pos.X);
                Pos.Y = ini.ReadFloat(section, "Y", Pos.Y);
                Pos.Z = ini.ReadFloat(section, "Z", Pos.Z);
                Pos.U = ini.ReadFloat(section, "U", Pos.U);
                Pos.V = ini.ReadFloat(section, "V", Pos.V);
                Pos.W = ini.ReadFloat(section, "W", Pos.W);
                Pos.R = ini.ReadFloat(section, "R", Pos.R);
                Pos.S = ini.ReadFloat(section, "S", Pos.S);
                Pos.T = ini.ReadFloat(section, "T", Pos.T);
                Pos.J1Angle = ini.ReadFloat(section, "J1Angle", Pos.J1Angle);
                Pos.J1Flag = ini.ReadInteger(section, "J1Flag", Pos.J1Flag);
                Pos.J2Flag = ini.ReadInteger(section, "J2Flag", Pos.J2Flag);
                Pos.J4Angle = ini.ReadFloat(section, "J4Angle", Pos.J4Angle);
                Pos.J4Flag = ini.ReadInteger(section, "J4Flag", Pos.J4Flag);
                Pos.J6Flag = ini.ReadInteger(section, "J6Flag", Pos.J6Flag);
                Pos.Elbow_Str = ini.ReadString(section, "Elbow", Pos.Elbow_Str);
                Pos.Hand_Str = ini.ReadString(section, "Hand", Pos.Hand_Str);
                Pos.Wrist_Str = ini.ReadString(section, "Wrist", Pos.Wrist_Str);

                Pos.Description = ini.ReadString(section, "Description", Pos.Description);
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "Speed", Speed);
                //ini.WriteString(section, "Label", Pos.Label);
                //ini.WriteInteger(section, "No", Pos.No);
                ini.WriteInteger(section, "Local", Pos.Local);
                ini.WriteFloat(section, "X", Pos.X);
                ini.WriteFloat(section, "Y", Pos.Y);
                ini.WriteFloat(section, "Z", Pos.Z);
                ini.WriteFloat(section, "U", Pos.U);
                ini.WriteFloat(section, "V", Pos.V);
                ini.WriteFloat(section, "W", Pos.W);
                ini.WriteFloat(section, "R", Pos.R);
                ini.WriteFloat(section, "S", Pos.S);
                ini.WriteFloat(section, "T", Pos.T);
                ini.WriteFloat(section, "J1Angle", Pos.J1Angle);
                ini.WriteInteger(section, "J1Flag", Pos.J1Flag);
                ini.WriteInteger(section, "J2Flag", Pos.J2Flag);
                ini.WriteFloat(section, "J4Angle", Pos.J4Angle);
                ini.WriteInteger(section, "J4Flag", Pos.J4Flag);
                ini.WriteInteger(section, "J6Flag", Pos.J6Flag);
                ini.WriteString(section, "Elbow", Pos.Elbow_Str);
                ini.WriteString(section, "Hand", Pos.Hand_Str);
                ini.WriteString(section, "Wrist", Pos.Wrist_Str);

                ini.WriteString(section, "Description", Pos.Description);
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_Robot_Pos new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Speed", Speed, new_value.Speed, ref flag);
            log.Log_Diff(section + "/Label", Pos.Label, new_value.Pos.Label, ref flag);
            log.Log_Diff(section + "/No", Pos.No, new_value.Pos.No, ref flag);
            log.Log_Diff(section + "/Local", Pos.Local, new_value.Pos.Local, ref flag);

            log.Log_Diff(section + "/X", Pos.X, new_value.Pos.X, ref flag);
            log.Log_Diff(section + "/Y", Pos.Y, new_value.Pos.Y, ref flag);
            log.Log_Diff(section + "/Z", Pos.Z, new_value.Pos.Z, ref flag);
            log.Log_Diff(section + "/U", Pos.U, new_value.Pos.U, ref flag);
            log.Log_Diff(section + "/V", Pos.V, new_value.Pos.V, ref flag);
            log.Log_Diff(section + "/W", Pos.W, new_value.Pos.W, ref flag);
            log.Log_Diff(section + "/R", Pos.R, new_value.Pos.R, ref flag);
            log.Log_Diff(section + "/S", Pos.S, new_value.Pos.S, ref flag);
            log.Log_Diff(section + "/T", Pos.T, new_value.Pos.T, ref flag);

            log.Log_Diff(section + "/J1Angle", Pos.J1Angle, new_value.Pos.J1Angle, ref flag);
            log.Log_Diff(section + "/J1Flag", Pos.J1Flag, new_value.Pos.J1Flag, ref flag);
            log.Log_Diff(section + "/J2Flag", Pos.J2Flag, new_value.Pos.J2Flag, ref flag);
            log.Log_Diff(section + "/J4Angle", Pos.J4Angle, new_value.Pos.J4Angle, ref flag);
            log.Log_Diff(section + "/J4Flag", Pos.J4Flag, new_value.Pos.J4Flag, ref flag);
            log.Log_Diff(section + "/J6Flag", Pos.J6Flag, new_value.Pos.J6Flag, ref flag);

            log.Log_Diff(section + "/Elbow", Pos.Elbow_Str, new_value.Pos.Elbow_Str, ref flag);
            log.Log_Diff(section + "/Hand", Pos.Hand_Str, new_value.Pos.Hand_Str, ref flag);
            log.Log_Diff(section + "/Wrist", Pos.Wrist_Str, new_value.Pos.Wrist_Str, ref flag);

            log.Log_Diff(section + "/Description", Pos.Description, new_value.Pos.Description, ref flag);
        }
    }
    //-----------------------------------------------------------------------------------------------------
    // TRecipe_Robot1_Pos
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Robot1_Pos : TBase_Class//設定Count,起始No
    {
        public string In_Default_Path = "";

        public TRecipe_Robot_Pos_List List_Home = new TRecipe_Robot_Pos_List();
        //public TRecipe_Robot_Pos_List List_ACF_Load = new TRecipe_Robot_Pos_List();
        //public TRecipe_Robot_Pos_List List_Tray_Load = new TRecipe_Robot_Pos_List();
        //public TRecipe_Robot_Pos_List List_PCB_Load = new TRecipe_Robot_Pos_List();
        //public TRecipe_Robot_Pos_List List_Plasma_Load = new TRecipe_Robot_Pos_List();
        //public TRecipe_Robot_Pos_List List_ACF_unload = new TRecipe_Robot_Pos_List();
        //public TRecipe_Robot_Pos_List List_PCB_unload = new TRecipe_Robot_Pos_List();
        //public TRecipe_Robot_Pos_List List_Plasma_unload = new TRecipe_Robot_Pos_List();
       
    

        public TRecipe_Robot_Pos_List List_Load = new TRecipe_Robot_Pos_List();
        public TRecipe_Robot_Pos_List List_Align = new TRecipe_Robot_Pos_List();
        public TRecipe_Robot_Pos_List List_Unload = new TRecipe_Robot_Pos_List();
        public TRecipe_Robot_Pos_List List_NG = new TRecipe_Robot_Pos_List();
        public TRecipe_Robot_Pos_List List_Teach = new TRecipe_Robot_Pos_List();


        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Robot1_Pos()
        {
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Robot1_Pos();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Robot1_Pos && dis_base is TRecipe_Robot1_Pos)
            {
                TRecipe_Robot1_Pos sor = (TRecipe_Robot1_Pos)sor_base;
                TRecipe_Robot1_Pos dis = (TRecipe_Robot1_Pos)dis_base;

                dis.List_Home.Set(sor.List_Home);
                dis.List_Load.Set(sor.List_Load);
                dis.List_Align.Set(sor.List_Align);
                dis.List_Unload.Set(sor.List_Unload);
                dis.List_NG.Set(sor.List_NG);
                dis.List_Teach.Set(sor.List_Teach);
            }
        }

        public void Set_Default()
        {
            List_Home.Start_No = 5;
            List_Load.Start_No = 100;
            List_Align.Start_No = 110;
            List_Unload.Start_No = 120;
            List_NG.Start_No = 60;
            List_Teach.Start_No = 70;

            List_Home.Count = 1;
            List_Load.Count = 10;
            List_Align.Count = 10;
            List_Unload.Count = 10;
            List_NG.Count = 10;
            List_Teach.Count = 10;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        public void Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                List_Home.Read(ini, section + "/List_Home");
                List_Load.Read(ini, section + "/List_Load");
                List_Align.Read(ini, section + "/List_Align");
                List_Unload.Read(ini, section + "/List_Unload");
                List_NG.Read(ini, section + "/List_NG");
                List_Teach.Read(ini, section + "/List_Teach");
            }
        }
        public void Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                List_Home.Write(ini, section + "/List_Home");
                List_Load.Write(ini, section + "/List_Load");
                List_Align.Write(ini, section + "/List_Align");
                List_Unload.Write(ini, section + "/List_Unload");
                List_NG.Write(ini, section + "/List_NG");
                List_Teach.Write(ini, section + "/List_Teach");
            }
        }
        public void Log_Diff(TLog log, string section, TRecipe_Robot1_Pos new_value, ref bool flag)
        {
            List_Home.Log_Diff(log, section + "/List_Home", new_value.List_Home, ref flag);
            List_Load.Log_Diff(log, section + "/List_Load", new_value.List_Load, ref flag);
            List_Align.Log_Diff(log, section + "/List_Align", new_value.List_Align, ref flag);
            List_Unload.Log_Diff(log, section + "/List_Unload", new_value.List_Unload, ref flag);
            List_Unload.Log_Diff(log, section + "/List_NG", new_value.List_NG, ref flag);
            List_Teach.Log_Diff(log, section + "/List_Teach", new_value.List_Teach, ref flag);
        }
        public void Update()
        {
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TOfs
    //-----------------------------------------------------------------------------------------------------
    public class TOfs : TBase_Class
    {
        public string In_Default_Path;
        public double X,
                      Y,
                      Q;

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TOfs()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TOfs();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TOfs && dis_base is TOfs)
            {
                TOfs sor = (TOfs)sor_base;
                TOfs dis = (TOfs)dis_base;
                dis.X = sor.X;
                dis.Y = sor.Y;
                dis.Q = sor.Q;
            }
        }


        public void Set_Default()
        {
            X = 0;
            Y = 0;
            Q = 0;
        }
        public void Set_Default_Path(string path)
        {
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                X = ini.ReadFloat(section, "X", 0.0);
                Y = ini.ReadFloat(section, "Y", 0.0);
                Q = ini.ReadFloat(section, "Q", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteFloat(section, "X", X);
                ini.WriteFloat(section, "Y", Y);
                ini.WriteFloat(section, "Q", Q);
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TOfs new_value, ref bool flag)
        {
            log.Log_Diff(section + "/X", X, new_value.X, ref flag);
            log.Log_Diff(section + "/Y", Y, new_value.Y, ref flag);
            log.Log_Diff(section + "/Q", Q, new_value.Q, ref flag);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TLimit
    //-----------------------------------------------------------------------------------------------------
    public class TLimit : TBase_Class
    {
        public string In_Default_Path;
        public bool SW;
        public double Min,
                      Max;

        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TLimit()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TLimit();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TLimit && dis_base is TLimit)
            {
                TLimit sor = (TLimit)sor_base;
                TLimit dis = (TLimit)dis_base;

                dis.SW = sor.SW;
                dis.Min = sor.Min;
                dis.Max = sor.Max;
            }
        }


        
        public void Set_Default()
        {
            SW = false;
            Min = 0;
            Max = 0;
        }
        public void Set_Default_Path(string path)
        {
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                SW = ini.ReadBool(section, "Enabled", false);
                Min = ini.ReadFloat(section, "Min", 0.0);
                Max = ini.ReadFloat(section, "Max", 0.0);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteBool(section, "Enabled", SW);
                ini.WriteFloat(section, "Min", Min);
                ini.WriteFloat(section, "Max", Max);
            }
            return true;
        }
        public void Read_Other_File()
        {
        }
        public void Write_Other_File()
        {
        }
        public void Log_Diff(TLog log, string section, TLimit new_value, ref bool flag)
        {
            log.Log_Diff(section + "/SW", SW, new_value.SW, ref flag);
            log.Log_Diff(section + "/Min", Min, new_value.Min, ref flag);
            log.Log_Diff(section + "/Max", Max, new_value.Max, ref flag);
        }
    }

    //-----------------------------------------------------------------------------------------------------
    // TRecipe_ACF_Check_Pos_List
    //-----------------------------------------------------------------------------------------------------
    public class TRecipe_Tray : TBase_Class
    {
        public string In_Default_Path = "";
        public double Start_X = 0;
        public double Start_Y = 0;
        public double Pitch_X = 0;
        public double Pitch_Y = 0;
        public double Pitch_Z = 0;
        public int Num_X = 1;
        public int Num_Y = 1;
        public int Num_Z = 1;
        public string Default_Path
        {
            get
            {
                return In_Default_Path;
            }
            set
            {
                Set_Default_Path(value);
            }
        }
        public TRecipe_Tray()
        {
            Set_Default();
        }
        override public TBase_Class New_Class()
        {
            return new TRecipe_Tray();
        }
        override public void Copy(TBase_Class sor_base, TBase_Class dis_base)
        {
            if (sor_base is TRecipe_Tray && dis_base is TRecipe_Tray)
            {
                TRecipe_Tray sor = (TRecipe_Tray)sor_base;
                TRecipe_Tray dis = (TRecipe_Tray)dis_base;

                dis.Start_X = sor.Start_X;
                dis.Start_Y = sor.Start_Y;
                dis.Pitch_X = sor.Pitch_X;
                dis.Pitch_Y = sor.Pitch_Y;
                dis.Num_X = sor.Num_X;
                dis.Num_Y = sor.Num_Y;
            }
        }

        public void Set_Default()
        {
            Start_X = 0.0;
            Start_Y = 0.0;
            Pitch_X = 10.0;
            Pitch_Y = 10.0;
            Num_X = 10;
            Num_Y = 10;
        }
        public void Set_Default_Path(string path)
        {
            In_Default_Path = path;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                Start_X = ini.ReadFloat(section, "Start_X", Start_X);
                Start_Y = ini.ReadFloat(section, "Start_Y", Start_Y);
                Pitch_X = ini.ReadFloat(section, "Pitch_X", Pitch_X);
                Pitch_Y = ini.ReadFloat(section, "Pitch_Y", Pitch_Y);
                Num_X = ini.ReadInteger(section, "Num_X", Num_X);
                Num_Y = ini.ReadInteger(section, "Num_Y", Num_Y);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                if (Num_X < 1) Num_X = 1;
                if (Num_Y < 1) Num_Y = 1;
                ini.WriteFloat(section, "Start_X", Start_X);
                ini.WriteFloat(section, "Start_Y", Start_Y);
                ini.WriteFloat(section, "Pitch_X", Pitch_X);
                ini.WriteFloat(section, "Pitch_Y", Pitch_Y);
                ini.WriteInteger(section, "Num_X", Num_X);
                ini.WriteInteger(section, "Num_Y", Num_Y);
            }
            return true;
        }
        public void Log_Diff(TLog log, string section, TRecipe_Tray new_value, ref bool flag)
        {
            log.Log_Diff(section + "/Start_X", Start_X, new_value.Start_X, ref flag);
            log.Log_Diff(section + "/Start_Y", Start_Y, new_value.Start_Y, ref flag);
            log.Log_Diff(section + "/Pitch_X", Pitch_X, new_value.Pitch_X, ref flag);
            log.Log_Diff(section + "/Pitch_Y", Pitch_Y, new_value.Pitch_Y, ref flag);
            log.Log_Diff(section + "/Num_X", Num_X, new_value.Num_X, ref flag);
            log.Log_Diff(section + "/Num_Y", Num_Y, new_value.Num_Y, ref flag);
        }
        public TJJS_Point Get_Tray_Pos(int no)
        {
            TJJS_Point result = new TJJS_Point();
            int no_x = 0, no_y = 0;

            Get_Tray_XY_No(no, out no_x, out no_y);
            result.X = no_x * Pitch_X;
            result.Y = no_y * Pitch_Y;
            return result;
        }
        public void Get_Tray_XY_No(int no, out int no_x, out int no_y)
        {
            no_x = 0;
            no_y = 0;
            no_x = no % Num_X;
            no_y = no / Num_X;
        }
    }

}
