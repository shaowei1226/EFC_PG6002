using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EFC.Tool;
using EFC.INI;
using EFC.CAD;
using HalconDotNet;


namespace EFC.Vision.Halcon
{
    public enum emForm_Type { Region, Image, All }
    public enum emCommand_Mode { None, Modify, Insert }
    public partial class TForm_Halcon_Tool : Form
    {
        public TTool_Values         Org_Tool_Values = new TTool_Values();
        public TTool_Values         Run_Tool_Values = new TTool_Values();
        public static int           Cmd_Max_Count = 10;
        public TCommand_Define      Param = new TCommand_Define();
        public TCommand_manager     CMD_Manager = new TCommand_manager();
        public stRect_Double        Part = new stRect_Double();

        public emForm_Type          Form_Type = emForm_Type.All;
        public HRegion              Select_Region = null;

        public bool                 On_Setting = false;
        public TCommand_Define      Commend_Define = null;
        public stCMD_Component[]    Comp_In = new stCMD_Component[Cmd_Max_Count];
        public stCMD_Component[]    Comp_Out = new stCMD_Component[Cmd_Max_Count];
        public ArrayList            Org_Command_List = new ArrayList();
        public emCommand_Mode       Command_Mode = emCommand_Mode.Insert;
        public TFrame_JJS_HW        JJS_HW = null;
        public string               Last_Type = "";
        public string               Last_Name = "";
        public string               Sort_String = "";
        public bool                 Init_Combo = false;

        public TForm_Halcon_Tool()
        {
            InitializeComponent();
            JJS_HW = tFrame_JJS_HW1;
            Part.Set_Data(0, 0, 640, 480);
            PageControl_Tool.Tab_Page_Hide(tabControl1);
            Init_Value_Obj();
            Init_Cmd_Obj();
        }
        private void TForm_Region_Tool_Shown(object sender, EventArgs e)
        {

            Reset_Program();
            Set_Value_Type_List();
            Set_Disp_Image_Value_Name_List();
            if (CB_Value_Type.Items.Count > 0) CB_Value_Type.SelectedIndex = 0;

            WindowState = FormWindowState.Maximized;
            
            splitContainer1.SplitterDistance = 700;
            splitContainer3.SplitterDistance = 300;
            splitContainer1.Refresh();
            JJS_HW.HW_Buf_Set_Size(Part.X1, Part.Y1, Part.X2, Part.Y2);
            JJS_HW.SetPart(Part.X1, Part.Y1, Part.X2, Part.Y2);

            HW_SetColored(JJS_HW.HW_Buf);
            HW_SetDraw(JJS_HW.HW_Buf);
            //if (Org_Tool_Values.Values_Image_Count > 0) JJS_HW.HW_Buf.HalconWindow.DispObj(Org_Tool_Values.Values_Image[0].Value);
            //if (Org_Tool_Values.Values_Region_Count > 0) JJS_HW.HW_Buf.HalconWindow.DispObj(Org_Tool_Values.Values_Region[0].Value);
            JJS_HW.Copy_HW();
        }
        private void splitContainer2_Resize(object sender, EventArgs e)
        {
        }
        public void Init_Value_Obj()
        {
            DataGridView dg;

            dg = DG_In_Value;
            dg.Columns.Clear();
            dg.Columns.Add("No", "No");
            dg.Columns.Add(Get_Value_Type_ComboBox_List());
            dg.Columns.Add("Name", "Name");
            dg.Columns.Add("Disp_String", "Disp_String");
            dg.Columns.Add("Default", "Default");
            dg.Columns[0].Width = 40;
            dg.Columns[1].Width = 200;
            dg.Columns[2].Width = 160;
            dg.Columns[3].Width = 160;
            dg.Columns[4].Width = 160;

            dg = DG_Out_Value;
            dg.Columns.Clear();
            dg.Columns.Add("No", "No");
            dg.Columns.Add(Get_Value_Type_ComboBox_List());
            dg.Columns.Add("Name", "Name");
            dg.Columns.Add("Disp_String", "Disp_String");
            dg.Columns.Add("Default", "Default");
            dg.Columns[0].Width = 40;
            dg.Columns[1].Width = 200;
            dg.Columns[2].Width = 160;
            dg.Columns[3].Width = 160;
            dg.Columns[4].Width = 160;
        }
        public DataGridViewComboBoxColumn Get_Value_Type_ComboBox_List()
        {
            DataGridViewComboBoxColumn result = new DataGridViewComboBoxColumn();
            ArrayList list = new ArrayList();

            result.HeaderText = "Type";
            result.Name = "cmb";
            list = Halcon_Tool.Get_Value_Type_List();
            result.MaxDropDownItems = list.Count;
            for (int i = 0; i < list.Count; i++)
                result.Items.Add(list[i].ToString());
            return result;
        }
        public void Init_Cmd_Obj()
        {
            int height = 40;
            int name_width = 204;
            int info_width = 100;

            Set_Cmd_List();
            Set_Mode(emCommand_Mode.None);

            for (int i = 0; i < Cmd_Max_Count; i++)
            {
                //in
                Comp_In[i].L_Name = new Label();
                Comp_In[i].L_Info = new Label();
                Comp_In[i].CB_Value = new ComboBox();
                P_Cmd_In.Controls.Add(Comp_In[i].L_Name);
                P_Cmd_In.Controls.Add(Comp_In[i].L_Info);
                P_Cmd_In.Controls.Add(Comp_In[i].CB_Value);

                Comp_In[i].L_Name.AutoSize = false;
                Comp_In[i].L_Name.Font = new System.Drawing.Font(P_Cmd_In.Font.Name, 14, P_Cmd_In.Font.Style);
                Comp_In[i].L_Name.TextAlign = ContentAlignment.MiddleRight;
                Comp_In[i].L_Name.Size = new System.Drawing.Size(name_width, height - 4);

                Comp_In[i].L_Info.AutoSize = false;
                Comp_In[i].L_Info.Font = new System.Drawing.Font(P_Cmd_In.Font.Name, 14, P_Cmd_In.Font.Style);
                Comp_In[i].L_Info.TextAlign = ContentAlignment.MiddleLeft;
                Comp_In[i].L_Info.Size = new System.Drawing.Size(info_width, height - 4);

                Comp_In[i].CB_Value.Font = new System.Drawing.Font(P_Cmd_In.Font.Name, 14, P_Cmd_In.Font.Style);



                //out
                Comp_Out[i].L_Name = new Label();
                Comp_Out[i].L_Info = new Label();
                Comp_Out[i].CB_Value = new ComboBox();
                P_Cmd_Out.Controls.Add(Comp_Out[i].L_Name);
                P_Cmd_Out.Controls.Add(Comp_Out[i].L_Info);
                P_Cmd_Out.Controls.Add(Comp_Out[i].CB_Value);


                Comp_Out[i].L_Name.AutoSize = false;
                Comp_Out[i].L_Name.Font = new System.Drawing.Font(P_Cmd_Out.Font.Name, 14, P_Cmd_Out.Font.Style);
                Comp_Out[i].L_Name.TextAlign = ContentAlignment.MiddleRight;
                Comp_Out[i].L_Name.Size = new System.Drawing.Size(name_width, height - 4);
               
                Comp_Out[i].L_Info.AutoSize = false;
                Comp_Out[i].L_Info.Font = new System.Drawing.Font(P_Cmd_Out.Font.Name, 14, P_Cmd_Out.Font.Style);
                Comp_Out[i].L_Info.TextAlign = ContentAlignment.MiddleLeft;
                Comp_Out[i].L_Info.Size = new System.Drawing.Size(info_width, height - 4);
                  
                Comp_Out[i].CB_Value.Font = new System.Drawing.Font(P_Cmd_Out.Font.Name, 14, P_Cmd_Out.Font.Style);
            }
            Init_Combo = true;
        }
        public void Set_Cmd_Obj_Pos()
        {
            Set_Cmd_Obj_Pos(P_Cmd_In, Comp_In);
            Set_Cmd_Obj_Pos(P_Cmd_Out, Comp_Out);
        }
        public void Set_Cmd_Obj_Pos(Panel pl, stCMD_Component[] comp)
        {
            int x = 0, y = 0;
            int height = 40;

            for (int i = 0; i < Cmd_Max_Count; i++)
            {
                x = 4;
                y = 12 + i * height;
                comp[i].L_Name.Left = x;
                comp[i].L_Name.Top = y;

                comp[i].L_Info.Left = pl.Width - comp[i].L_Info.Width - 8;
                comp[i].L_Info.Top = y;

                comp[i].CB_Value.Size = new System.Drawing.Size(comp[i].L_Info.Left - comp[i].L_Name.Right - 16, height - 4);
                comp[i].CB_Value.Left = comp[i].L_Name.Right + 8;
                comp[i].CB_Value.Top = y;
            }
        }
        public void Set_Part(HImage image)
        {
            int w, h;

            if (TJJS_Vision.Is_Not_Empty(image))
            {
                image.GetImageSize(out w, out h);
                Part.Set_Data(0, 0, w, h);
            }
        }
        public void Set_Param(TCommand_Define param)
        {
            Param = param.Copy();

            On_Setting = true;
            E_Command_Name.Text = Param.Name;
            Set_Values_Grid(DG_In_Value, Param.In.Values);
            Set_Values_Grid(DG_Out_Value, Param.Out.Values);

            Set_Program_List();
            CMD_Manager.Register_All_Command();
            CMD_Manager.Delete_User_Command();
            CMD_Manager.Register_User_Command(Param.User_Cmd_List);
            Org_Command_List = CMD_Manager.Get_Command_List();
            Set_Cmd_List();
            Set_User_Commands_List();
            On_Setting = false;
        }
        public void Set_Values_Grid(DataGridView dg, TCommand_Value[] values)
        {
            dg.RowCount = values.Length;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] != null)
                {
                    dg.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dg.Rows[i].Cells[1].Value = Halcon_Tool.Get_Value_Type_String(values[i].Type);
                    dg.Rows[i].Cells[2].Value = values[i].Name;
                    dg.Rows[i].Cells[3].Value = values[i].Disp_String;
                    dg.Rows[i].Cells[4].Value = values[i].Default_Value;
                }
            }
        }
        public void Set_Program_List()
        {
            LB_Program_Edit.Items.Clear();
            for (int i = 0; i < Param.Programs_List.Count; i++)
            {
                LB_Program_Edit.Items.Add(Param.Programs_List[i].ToString());
            }
            Set_Run_Index_List();
            Set_Program_List_No(0);
            Set_Run_Index(0);
        }
        public void Set_Cmd_List()
        {
            ArrayList list = new ArrayList();
            string old_str;

            old_str = CB_Command.Text;
            CB_Command.Items.Clear();
            for (int i = 0; i < Org_Command_List.Count; i++)
            {
                if (Org_Command_List[i].ToString().IndexOf(Sort_String) >= 0)
                    CB_Command.Items.Add(Org_Command_List[i].ToString());
            }
            CB_Command.SelectedIndex = -1;
            CB_Command.Text = old_str;
        }
        public void Set_User_Commands_List()
        {
            ArrayList list = new ArrayList();
            int old_no = -1;

            old_no = LB_User_Commands_List.SelectedIndex;
            LB_User_Commands_List.Items.Clear();
            for (int i = 0; i < Param.User_Cmd_List_Count; i++)
            {
                LB_User_Commands_List.Items.Add(Param.User_Cmd_List[i].Name);
            }
            if (old_no < 0) old_no = 0;
            if (old_no > LB_User_Commands_List.Items.Count - 1) old_no = LB_User_Commands_List.Items.Count - 1;
            LB_User_Commands_List.SelectedIndex = old_no;
        }
        public void Update_Param()
        {
            Param.Name = E_Command_Name.Text;
            Update_Param_Values_Grid();
            Param.Programs_List.Clear();
            for(int i=0; i<LB_Program_Edit.Items.Count; i++)
            {
                Param.Programs_List.Add(LB_Program_Edit.Items[i].ToString());
            }
        }
        public string Get_Grid_String(DataGridView dg, int no)
        {
            string result = "";
            if (dg != null && no < dg.RowCount)
            {
                result = dg.Rows[no].Cells[1].Value + "," +
                         dg.Rows[no].Cells[2].Value + "," +
                         dg.Rows[no].Cells[3].Value + "," +
                         "" + "," +
                         dg.Rows[no].Cells[4].Value;
            }
            return result;
        }
        public void Update_Param_Values_Grid()
        {

            for (int i = 0; i < Param.In.Values_Count; i++)
            {
                Param.In.Values[i].Set_Data(Get_Grid_String(DG_In_Value, i));
            }

            for (int i = 0; i < Param.Out.Values_Count; i++)
            {
                Param.Out.Values[i].Set_Data(Get_Grid_String(DG_Out_Value, i));
            }
        }
        public void Set_Program_List_No(int no)
        {
            if (no >= 0 && no < LB_Program_Edit.Items.Count)
            {
                LB_Program_Edit.SelectedIndex = no;
            }
        }
        public void Set_Run_Index_List()
        {
            int no = -1;
            
            no = LB_Run_Index.SelectedIndex;
            if (LB_Run_Index.Items.Count < LB_Program_Edit.Items.Count + 1)
            {
                while (LB_Run_Index.Items.Count < LB_Program_Edit.Items.Count + 1)
                {
                    LB_Run_Index.Items.Add("-");
                }
            }
            else if (LB_Run_Index.Items.Count > LB_Program_Edit.Items.Count + 1)
            {
                while(LB_Run_Index.Items.Count > LB_Program_Edit.Items.Count + 1)
                {
                    LB_Run_Index.Items.Remove(LB_Run_Index.Items[LB_Run_Index.Items.Count-1]);
                }
            }
            if (no < 0) no = 0;
            if (no >= LB_Run_Index.Items.Count) no = LB_Run_Index.Items.Count - 1;
            LB_Run_Index.SelectedIndex = no;
        }
        public void Set_Run_Index(int no)
        {
            if (no < 0) no = 0;
            if (no > LB_Run_Index.Items.Count - 1) no = LB_Run_Index.Items.Count - 1;
   
            LB_Run_Index.SelectedIndex = no;
            Set_Program_List_No(no);
        }
        public void Set_Value_Type_List()
        {
            ArrayList list = new ArrayList();

            CB_Value_Type.Items.Clear();
            list = Run_Tool_Values.Get_Vlaue_Type_List();
            for (int i = 0; i < list.Count; i++ )
            {
                CB_Value_Type.Items.Add(list[i].ToString());
            }
            if (list.Count > 0) CB_Value_Type.SelectedIndex = 0;
        }
        public void Set_Value_Name_List(string type)
        {
            ArrayList list = new ArrayList();

            CB_Value_Name.Items.Clear();
            list = Run_Tool_Values.Get_Value_Name_List(type);
            for (int i = 0; i < list.Count; i++)
            {
                CB_Value_Name.Items.Add(list[i].ToString());
            }
            if (list.Count > 0) CB_Value_Name.SelectedIndex = 0;
        }
        public void Set_Disp_Image_Value_Name_List()
        {
            ArrayList list = new ArrayList();

            CB_Disp_Image_Name.Items.Clear();
            list = Run_Tool_Values.Get_Value_Name_List(emValue_Type.Image);
            for (int i = 0; i < list.Count; i++)
            {
                CB_Disp_Image_Name.Items.Add(list[i].ToString());
            }
            if (list.Count > 0) CB_Disp_Image_Name.SelectedIndex = 0;
        }
        public void Set_Mode(emCommand_Mode mode)
        {
            if (Command_Mode != mode)
            {
                Command_Mode = mode;
                switch (mode)
                {
                    case emCommand_Mode.None:
                        PageControl_Tool.Tab_Page_Select(tabControl1, "空白");
                        CB_Command.Text = "";
                        B_Add.Visible = true;
                        B_Insert.Visible = false;
                        B_OverWrite.Visible = false;
                        break;

                    case emCommand_Mode.Modify:
                        PageControl_Tool.Tab_Page_Select(tabControl1, "Value");
                        B_Add.Visible = false;
                        B_OverWrite.Visible = true;
                        B_Insert.Visible = false;
                        break;

                    case emCommand_Mode.Insert:
                        PageControl_Tool.Tab_Page_Select(tabControl1, "Value");
                        B_Add.Visible = true;
                        B_OverWrite.Visible = false;
                        B_Insert.Visible = true;
                        break;
                }
                Sort_String = "";
            }
        }
        public TCommand_Define Get_Command_Data()
        {
            TCommand_Define result = null;

            result = CMD_Manager.Get_Command(CB_Command.Text);
            if (result != null)
            {
                for(int i=0; i<result.In.Values_Count; i++)
                {
                    result.In.Values[i].Value = Comp_In[i].CB_Value.Text;
                }
                for (int i = 0; i < result.Out.Values_Count; i++)
                {
                    result.Out.Values[i].Value = Comp_Out[i].CB_Value.Text;
                }
            }
            return result;
        }
        public void Set_Command_Define(string cmd_str, emCommand_Mode mode)
        {
            string[] list = null;
            TCommand_Define cmd = null;

            Halcon_Tool.Break_String(cmd_str, ref list);
            if (list.Length > 0)
            {
                cmd = CMD_Manager.Get_Command(list[0]);
                if (cmd != null)
                {
                    cmd.Set_Data(list);
                    CB_Command.Text = list[0].ToString();
                    Set_Command_Define(cmd, mode);
                    Set_Mode(mode);
                }
            }
            else
            {
                PageControl_Tool.Tab_Page_Select(tabControl1, "空白");
            }
        }
        public void Set_Command_Define(TCommand_Define cmd, emCommand_Mode mode)
        {
            if (cmd != null)
            {
                PageControl_Tool.Tab_Page_Select(tabControl1, "Value");
                Set_Command_Define_In(cmd.In, mode, P_Cmd_In, Comp_In);
                Set_Command_Define_Out(cmd.Out, mode, P_Cmd_Out, Comp_Out);
            }
            else
            {
                PageControl_Tool.Tab_Page_Select(tabControl1, "空白");
            }
        }
        public void Set_Command_Define(TCommand_Values_List values_List, emCommand_Mode mode, Panel pl, stCMD_Component[] comp)
        {
            int count = 0;
            TTool_Values tmp_tool_value = new TTool_Values();
            ArrayList combo_list = null;

            count = values_List.Values_Count;
            tmp_tool_value = Set_Program_No(LB_Program_Edit.SelectedIndex);

            if (count > 0) pl.Height = comp[count - 1].L_Name.Bottom + 10;
            else pl.Height = 50;

            for (int i = 0; i < Cmd_Max_Count; i++)
            {
                if (i < count)
                {
                    comp[i].L_Name.Visible = true;
                    comp[i].L_Info.Visible = true;
                    comp[i].CB_Value.Visible = true;
                    comp[i].L_Name.Text = values_List.Values[i].Disp_String;
                    comp[i].L_Info.Text = Get_Type_String(values_List.Values[i].Type);
                    comp[i].CB_Value.Text = values_List.Values[i].Value;

                    combo_list = tmp_tool_value.Get_Value_Name_List(values_List.Values[i].Type);

                    if (values_List.Values[i].Combo_List != null) combo_list = ArrayList_Tool.Add(combo_list, values_List.Values[i].Combo_List);
                    Set_ComboBox(comp[i].CB_Value, combo_list);
                }
                else
                {
                    comp[i].L_Name.Visible = false;
                    comp[i].L_Info.Visible = false;
                    comp[i].CB_Value.Visible = false;
                }
            }
        }
        public void Set_Command_Define_In(TCommand_Values_List values_List, emCommand_Mode mode, Panel pl, stCMD_Component[] comp)
        {
            Set_Command_Define(values_List, mode, pl, comp);
            for (int i = 0; i < values_List.Values_Count; i++)
            {
                if (mode == emCommand_Mode.Insert)
                {
                    if (values_List.Values[i].Default_Value != "")
                        comp[i].CB_Value.Text = values_List.Values[i].Default_Value;
                    else if (comp[i].CB_Value.Items.Count > 0)
                        comp[i].CB_Value.Text = comp[i].CB_Value.Items[comp[i].CB_Value.Items.Count - 1].ToString();
                }
            }
        }
        public void Set_Command_Define_Out(TCommand_Values_List values_List, emCommand_Mode mode, Panel pl, stCMD_Component[] comp)
        {
            TTool_Values tmp_tool_value = new TTool_Values();
            string default_name = "";

            Set_Command_Define(values_List, mode, pl, comp);
            for (int i = 0; i < values_List.Values_Count; i++)
            {
                default_name = Halcon_Tool.Get_Value_Type_String(values_List.Values[i].Type);
                if (mode == emCommand_Mode.Insert)
                {
                    comp[i].CB_Value.Text = Get_Default_Name(comp[i].CB_Value, default_name);
                }
            }
        }
        public string Get_Default_Name(ComboBox cb, string default_name)
        {
            string result = "";
            int no = 1;
            int pos = -1;

            if (cb != null && cb.Items.Count > 0)
            {
                while (true)
                {
                    result = default_name + no.ToString();
                    pos = cb.Items.IndexOf(result);
                    if (pos < 0) break;
                    no++;
                }
            }
            else result = default_name + no.ToString();

            return result;
        }
        public string Get_Type_String(emValue_Type type)
        {
            string result = "";

            switch (type)
            {
                case emValue_Type.Region:  result = "Region"; break;
                case emValue_Type.Image:   result = "Image"; break;
                case emValue_Type.String:  result = "String"; break;
                case emValue_Type.Integer: result = "Integer"; break;
                case emValue_Type.Double:  result = "Double"; break;
            }
            return result;
        }
        public void Set_ComboBox(ComboBox combo_box, ArrayList items)
        {
            combo_box.Items.Clear();
            if (items != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    combo_box.Items.Add(items[i].ToString());
                }
            }
        }
        public void Reset_Program()
        {
            Set_Run_Index(0);
            Run_Tool_Values = Org_Tool_Values.Copy();
        }
        public ArrayList Get_Program_List(int program_no)
        {
            ArrayList result = new ArrayList();
            int end = 0;

            end = program_no;
            if (end > LB_Program_Edit.Items.Count) end = LB_Program_Edit.Items.Count;
            result.Clear();
            for (int i = 0; i <= end; i++)
            {
                result.Add(LB_Program_Edit.Items[i].ToString());
            }
            return result;
        }
        public TTool_Values Set_Program_No(int program_no)
        {
            TTool_Values result = new TTool_Values();

            result = Org_Tool_Values.Copy();
            CMD_Manager.Get_Tool_Values(Get_Program_List(program_no), ref result);
            return result;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Update_Param();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        private void B_Add_Click(object sender, EventArgs e)
        {
            TCommand_Define cmd = null;
            int no = -1;

            cmd = Get_Command_Data();
            if (cmd != null)
            {
                LB_Program_Edit.Items.Add(cmd.ToString());

                no = LB_Program_Edit.Items.Count - 1;
                LB_Program_Edit.SelectedIndex = no;
                Set_Mode(emCommand_Mode.None);
                Set_Run_Index_List();
            }
        }
        private void B_Insert_Click(object sender, EventArgs e)
        {
            int no = 0-1;
            TCommand_Define cmd = null;

            no = LB_Program_Edit.SelectedIndex;
            cmd = Get_Command_Data();
            if (cmd != null)
            {
                if (no < LB_Program_Edit.Items.Count && no >= 0)
                    LB_Program_Edit.Items.Insert(no + 1, cmd.ToString());
                else
                    LB_Program_Edit.Items.Add(cmd.ToString());

                no++;
                LB_Program_Edit.SelectedIndex = no;
                Set_Mode(emCommand_Mode.None);
                Set_Run_Index_List();
            }
        }
        private void B_OverWrite_Click(object sender, EventArgs e)
        {
            int no = 0;
            TCommand_Define cmd = null;

            no = LB_Program_Edit.SelectedIndex;
            cmd = Get_Command_Data();
            if (no >= 0 && cmd != null)
            {
                LB_Program_Edit.Items[no] = cmd.ToString();
                Set_Mode(emCommand_Mode.None);
            }
        }
        private void B_Delete_Click(object sender, EventArgs e)
        {
            int no = 0;

            no = LB_Program_Edit.SelectedIndex;
            if (no >= 0)
            {
                LB_Program_Edit.Items.Remove(LB_Program_Edit.Items[no]);
                if (no < LB_Program_Edit.Items.Count)
                    LB_Program_Edit.SelectedIndex = no;
                else
                {
                    no--;
                    if (no >= 0) LB_Program_Edit.SelectedIndex = no;
                }
                Set_Mode(emCommand_Mode.None);
                Set_Run_Index_List();
            }
        }
        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Set_Mode(emCommand_Mode.None);
        }
        private void LB_Program_List_Click(object sender, EventArgs e)
        {
        }
        private void LB_Program_List_DoubleClick(object sender, EventArgs e)
        {
            if (LB_Program_Edit.SelectedIndex >= 0)
            {
                Set_Command_Define(LB_Program_Edit.Items[LB_Program_Edit.SelectedIndex].ToString(), emCommand_Mode.Modify);
            }
        }
        private void CB_Command_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Command_Define(CB_Command.Text, emCommand_Mode.Insert);
        }
        private void CB_Command_DropDown(object sender, EventArgs e)
        {
            Set_Cmd_List();
        }
        public TCommand_Value Get_Program_Result_Value(string program_List_str)
        {
            TCommand_Value result = null;
            TCommand_Define cmd = null;

            cmd = CMD_Manager.Get_Command(program_List_str);
            if (cmd != null)
            {
                cmd.Set_Data(program_List_str);
                result = cmd.Out.Values[cmd.Out.Values_Count - 1];
            }
            return result;
        }
        public bool Run_Program_Next()
        {
            bool result = false;
            string program = "";
            TCommand_Value value = null;
            int program_no = 0;

            program_no = LB_Run_Index.SelectedIndex;
            if (program_no >= 0 && program_no < LB_Program_Edit.Items.Count)
            {
                program = LB_Program_Edit.Items[program_no].ToString();
                result = CMD_Manager.Execute(program, ref Run_Tool_Values, Param);
                Set_Run_Index(program_no + 1);
            }
            if (result)
            {
                value = Get_Program_Result_Value(program);
                if (value != null)
                {
                    Last_Type = Halcon_Tool.Get_Value_Type_String(value.Type);
                    Last_Name = value.Value;
                    Disp_Result();
                }
            }
            return result;
        }
        public bool Run_Program_To_No(int no)
        {
            bool result = false;
 
            while (LB_Run_Index.SelectedIndex <= no && LB_Run_Index.SelectedIndex < LB_Program_Edit.Items.Count)
            {
                result = Run_Program_Next();
                if (!result) break;
            }
            return result;
        }
        public void Disp_Result()
        {
            HImage tmp_image = null;

            if (CB_Clear_Windows.Checked) JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            HW_SetColored(JJS_HW.HW_Buf);
            HW_SetDraw(JJS_HW.HW_Buf);
            HW_Set_Line_Width(JJS_HW.HW_Buf);
            if (CB_Disp_Image.Checked)
            {
                tmp_image = Run_Tool_Values.Get_Value_Image(CB_Disp_Image_Name.Text);
                if (TJJS_Vision.Is_Not_Empty(tmp_image))
                    JJS_HW.HW_Buf.HalconWindow.DispObj(tmp_image);
            }
           
            Disp_Result(JJS_HW.HW_Buf, Run_Tool_Values, Last_Type, Last_Name);
            JJS_HW.Copy_HW();
        }
        public void Disp_Result(HWindowControl hw, TTool_Values tool_values, string last_program)
        {
            TCommand_Define cmd = null;
            TCommand_Value value = null;
            string[] program_list = null;

            Halcon_Tool.Break_String(last_program, ref program_list);
            if (program_list.Length > 0)
            {
                cmd = CMD_Manager.Get_Command(program_list[0].ToString());
                if (cmd != null)
                {
                    cmd.Set_Data(program_list);
                    value = cmd.Out.Values[cmd.Out.Values_Count - 1];
                    Disp_Result(hw, tool_values, Halcon_Tool.Get_Value_Type_String(value.Type), value.Name);
                }
            }
        }
        public void Disp_Result(HWindowControl hw, TTool_Values tool_values, string type, string name)
        {
            switch (type)
            {
                case "Region":
                    TTool_Value_Region value_region = null;

                    value_region = (TTool_Value_Region)tool_values.Get_Value(emValue_Type.Region, name);
                    if (value_region != null)
                    {
                        hw.HalconWindow.DispObj(value_region.Value);
                        Select_Region = value_region.Value;
                    }
                    else 
                        Select_Region = null;
                    break;

                case "Image":
                    TTool_Value_Image value_image = null;

                    value_image = (TTool_Value_Image)tool_values.Get_Value(emValue_Type.Image, name);
                    if (value_image != null) hw.HalconWindow.DispObj(value_image.Value);
                    break;
            }
        }
        private void B_Program_Next_Click(object sender, EventArgs e)
        {
            Run_Program_Next();
            Set_Value_Name_List(CB_Value_Type.Text);
        }
        private void B_Program_Run_Click(object sender, EventArgs e)
        {
            Run_Program_To_No(LB_Program_Edit.Items.Count);
            Set_Value_Name_List(CB_Value_Type.Text);
        }
        private void B_Program_Reset_Click(object sender, EventArgs e)
        {
            Reset_Program();
            Set_Value_Name_List(CB_Value_Type.Text);
        }
        private void B_Program_Comment_Click(object sender, EventArgs e)
        {
            int no = -1;
            string str;

            no = LB_Program_Edit.SelectedIndex;
            if (no >= 0)
            {
                str = LB_Program_Edit.Items[no].ToString();
                if (!Halcon_Tool.Is_Comment(str))
                    LB_Program_Edit.Items[no] = "@" + str;
            }
        }
        private void B_Program_ReComment_Click(object sender, EventArgs e)
        {
            int no = -1;
            string str;

            no = LB_Program_Edit.SelectedIndex;
            if (no >= 0)
            {
                str = LB_Program_Edit.Items[no].ToString();
                if (Halcon_Tool.Is_Comment(str))
                {
                    str = str.Replace("@", "");
                    LB_Program_Edit.Items[no] = str;
                }
            }
        }
        private void B_Program_Up_Click(object sender, EventArgs e)
        {
            int no = -1;
            string str;

            no = LB_Program_Edit.SelectedIndex;
            if (no >= 1 && no < LB_Program_Edit.Items.Count)
            {
                str = LB_Program_Edit.Items[no].ToString();
                LB_Program_Edit.Items[no] = LB_Program_Edit.Items[no - 1];
                LB_Program_Edit.Items[no - 1] = str;
                LB_Program_Edit.SelectedIndex = no - 1;
            }
        }
        private void B_Program_Dn_Click(object sender, EventArgs e)
        {
            int no = -1;
            string str;

            no = LB_Program_Edit.SelectedIndex;
            if (no >= 0 && no < LB_Program_Edit.Items.Count - 1)
            {
                str = LB_Program_Edit.Items[no].ToString();
                LB_Program_Edit.Items[no] = LB_Program_Edit.Items[no + 1];
                LB_Program_Edit.Items[no + 1] = str;
                LB_Program_Edit.SelectedIndex = no + 1;
            }
        }
        private void B_Program_Edit_Click(object sender, EventArgs e)
        {
            int no = -1;
            int cmd_no = -1;
            string program_list = "";


            no = LB_Program_Edit.SelectedIndex;
            if (no >= 0)
            {
                program_list = LB_Program_Edit.Items[no].ToString();
                if (!Halcon_Tool.Is_Comment(program_list))
                {
                    Update_Param();
                    cmd_no = Param.Get_User_Cmd_List_No(Halcon_Tool.Get_Program_Name(program_list));
                    if (cmd_no >= 0 && Param.User_Cmd_List[cmd_no].User_Define)
                    {
                        Param.User_Cmd_List[cmd_no].Set_Data(program_list);
                        TForm_Halcon_Tool form = new TForm_Halcon_Tool();
                        form.Part = Part;
                        form.Set_Param(Param.User_Cmd_List[cmd_no]);
                        form.Org_Tool_Values.Add_In(Param.User_Cmd_List[cmd_no], Run_Tool_Values);
                        form.Org_Tool_Values.Add(Param.User_Cmd_List[cmd_no].Out);

                        if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (form.Param.Name == Param.User_Cmd_List[cmd_no].Name)
                            {
                                Param.User_Cmd_List[cmd_no] = form.Param.Copy();
                                Set_Param(Param);
                            }
                            else MessageBox.Show("函數名稱不能修改。", "錯誤", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }
        
        
        private void B_Disp_Obj_Click(object sender, EventArgs e)
        {
            Last_Type = CB_Value_Type.Text;
            Last_Name = CB_Value_Name.Text;
            Disp_Result();
        }
        private void B_Clear_Disp_Obj_Click(object sender, EventArgs e)
        {
            Last_Type = CB_Value_Type.Text;
            Last_Name = CB_Value_Name.Text;
            JJS_HW.HW_Buf.HalconWindow.ClearWindow();
            Disp_Result();
        }
        private void CB_Value_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Set_Value_Name_List(CB_Value_Type.Text);
        }
        public void Set_Colored(int no)
        {
            TSM_Color_3.Checked = false;
            TSM_Color_6.Checked = false;
            TSM_Color_12.Checked = false;
            switch (no)
            {
                case 3: TSM_Color_3.Checked = true; break;
                case 6: TSM_Color_6.Checked = true; break;
                case 12: TSM_Color_12.Checked = true; break;
                default: TSM_Color_12.Checked = true; break;
            }
            HW_SetColored(JJS_HW.HW_Buf);
        }
        public void Set_Draw(string mode)
        {
            TSM_Draw_Fill.Checked = false;
            TSM_Draw_Margin.Checked = false;
            switch (mode)
            {
                case "fill": TSM_Draw_Fill.Checked = true; break;
                case "margin": TSM_Draw_Margin.Checked = true; break;
                default: TSM_Draw_Fill.Checked = true; break;
            }
            HW_SetDraw(JJS_HW.HW_Buf);
        }
        public void Set_Line_Width(int width)
        {
            if (width >= 1 && width <= 5)
            {
                TSM_Line_Width_1.Checked = false;
                TSM_Line_Width_2.Checked = false;
                TSM_Line_Width_3.Checked = false;
                TSM_Line_Width_4.Checked = false;
                TSM_Line_Width_5.Checked = false;
                switch (width)
                {
                    case 1: TSM_Line_Width_1.Checked = true; break;
                    case 2: TSM_Line_Width_2.Checked = true; break;
                    case 3: TSM_Line_Width_3.Checked = true; break;
                    case 4: TSM_Line_Width_4.Checked = true; break;
                    case 5: TSM_Line_Width_5.Checked = true; break;
                    default: TSM_Line_Width_1.Checked = true; break;
                }
                HW_Set_Line_Width(JJS_HW.HW_Buf);
            }
        }
        public void HW_SetColored(HWindowControl hw)
        {
            if (TSM_Color_3.Checked) hw.HalconWindow.SetColored(3);
            if (TSM_Color_6.Checked) hw.HalconWindow.SetColored(6);
            if (TSM_Color_12.Checked) hw.HalconWindow.SetColored(12);
        }
        public void HW_SetDraw(HWindowControl hw)
        {
            if (TSM_Draw_Fill.Checked) hw.HalconWindow.SetDraw("fill");
            if (TSM_Draw_Margin.Checked) hw.HalconWindow.SetDraw("margin");
        }
        public void HW_Set_Line_Width(HWindowControl hw)
        {
            if (TSM_Line_Width_1.Checked) hw.HalconWindow.SetLineWidth(1);
            if (TSM_Line_Width_2.Checked) hw.HalconWindow.SetLineWidth(2);
            if (TSM_Line_Width_3.Checked) hw.HalconWindow.SetLineWidth(3);
            if (TSM_Line_Width_4.Checked) hw.HalconWindow.SetLineWidth(4);
            if (TSM_Line_Width_5.Checked) hw.HalconWindow.SetLineWidth(5);
        }
        private void TSM_Color_3_Click(object sender, EventArgs e)
        {
            Set_Colored(3);
            Disp_Result();
        }
        private void TSM_Color_6_Click(object sender, EventArgs e)
        {
            Set_Colored(6);
            Disp_Result();
        }
        private void TSM_Color_12_Click(object sender, EventArgs e)
        {
            Set_Colored(12);
            Disp_Result();
        }
        private void TSM_Draw_Fill_Click(object sender, EventArgs e)
        {
            Set_Draw("fill");
            Disp_Result();
        }
        private void TSM_Draw_Margin_Click(object sender, EventArgs e)
        {
            Set_Draw("margin");
            Disp_Result();
        }
        private void TSM_Line_Width_1_Click(object sender, EventArgs e)
        {
            Set_Line_Width(1);
            Disp_Result();
        }
        private void TSM_Line_Width_2_Click(object sender, EventArgs e)
        {
            Set_Line_Width(2);
            Disp_Result();
        }
        private void TSM_Line_Width_3_Click(object sender, EventArgs e)
        {
            Set_Line_Width(3);
            Disp_Result();
        }
        private void TSM_Line_Width_4_Click(object sender, EventArgs e)
        {
            Set_Line_Width(4);
            Disp_Result();
        }
        private void TSM_Line_Width_5_Click(object sender, EventArgs e)
        {
            Set_Line_Width(5);
            Disp_Result();
        }
        private void B_Get_Region_Info_Click(object sender, EventArgs e)
        {
            double col, row;
            HRegion tmp_region = new HRegion();
            TJJS_XML_File ini = new TJJS_XML_File();
            stRegion_Info region_info = new stRegion_Info();

            if (Select_Region != null)
            {
                B_Get_Region_Info.BackColor = Color.Black;
                TV_Region_Info.Nodes.Clear();
                JJS_HW.Mode = emJJS_HW_Mode.emJJS_HW_None;
                JJS_HW.HW.Focus();
                JJS_HW.HW.HalconWindow.DrawPoint(out row, out col);
                tmp_region = Select_Region.SelectRegionPoint((int)Math.Round(row, 0), (int)Math.Round(col, 0));
                if (tmp_region.CountObj() == 1)
                {
                    region_info = TJJS_Vision.Get_Region_Info(tmp_region);
                    region_info.Write(ini, "Default");
                    TJJS_XML_Tool.Display_TreeView(TV_Region_Info, ini);
                    TV_Region_Info.ExpandAll();
                }
                B_Get_Region_Info.BackColor = Color.Transparent;
            }
        }
        public bool Edit_User_Command(ref TCommand_Define cmd)
        {
            bool result = false;
            TForm_User_Define form = new TForm_User_Define();

            form.Set_Param(cmd);
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cmd = form.Param.Copy();
                result = true;
            }
            return result;
        }
        private void B_User_Cmd_Export_Click(object sender, EventArgs e)
        {
            THalcon_Tool_File dmc_file = new THalcon_Tool_File();
            TCommand_Define select_cmd = null;
            int no = LB_User_Commands_List.SelectedIndex;
            string filename = "";
            int cmd_no = -1;

            if (no >= 0)
            {
                select_cmd = Param.User_Cmd_List[no];
                //OpenFileDialog dialog = new OpenFileDialog();
                //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filename = "d:\\database\\database.udc";
                    //filename = dialog.FileName;
                    dmc_file.Read(filename);
                    cmd_no = dmc_file.CMD.Get_User_Cmd_List_No(select_cmd.Name);
                    if (cmd_no < 0)
                    {
                        dmc_file.CMD.Add_User_Cmd_List(select_cmd);
                        dmc_file.Write(filename);
                    }
                    else
                    {
                        if (MessageBox.Show("選取名稱已重複??", "錯誤", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            dmc_file.CMD.User_Cmd_List[cmd_no] = select_cmd.Copy();
                            dmc_file.Write(filename);
                        }
                    }
                }
            }
        }
        private void B_User_Cmd_Inport_Click(object sender, EventArgs e)
        {
            TForm_Inport_CMD form = new TForm_Inport_CMD();
            OpenFileDialog dialog = new OpenFileDialog();
            TCommand_Define tmp_cmd = null;
            string filename = "";

            //dialog.Filter = "User Difine Command files (*.UDC)|*.UDC";
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = "d:\\database\\database.udc";
                form.Set_Param(filename);
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    for (int i = 0; i < form.Select_CMD.User_Cmd_List_Count; i++)
                    {
                        tmp_cmd = form.Select_CMD.User_Cmd_List[i];
                        if (CMD_Manager.Get_Command(tmp_cmd.Name) == null)
                        {
                            Param.Add_User_Cmd_List(tmp_cmd);
                        }
                        else
                            MessageBox.Show("函數名稱重複，無法新增。", "錯誤", MessageBoxButtons.OK);
                    }
                    Set_Param(Param);
                }
            }
        }
        private void B_User_Cmd_Add_Click(object sender, EventArgs e)
        {
            TCommand_Define tmp_cmd = new TCommand_Define();

            if (Edit_User_Command(ref tmp_cmd))
            {
                Update_Param();
                if (CMD_Manager.Get_Command(tmp_cmd.Name) == null)
                {
                    Param.Add_User_Cmd_List(tmp_cmd);
                    Set_Param(Param);
                }
                else
                    MessageBox.Show("函數名稱重複，無法新增。", "錯誤", MessageBoxButtons.OK);
            }
        }
        private void B_User_Cmd_Del_Click(object sender, EventArgs e)
        {
            int no = LB_User_Commands_List.SelectedIndex;

            if (no >= 0)
            {
                Update_Param();
                Param.Del_User_Cmd_List(no);
                Set_Param(Param);
            }
        }
        public void Edit_User_Command(int no)
        {
            if (no >= 0 && no < Param.User_Cmd_List_Count)
            {
                Update_Param();

                TForm_Halcon_Tool form = new TForm_Halcon_Tool();
                form.Set_Param(Param.User_Cmd_List[no]);
                form.Org_Tool_Values.Add(Param.User_Cmd_List[no].Out);
                form.Org_Tool_Values.Add(Param.User_Cmd_List[no].In);

                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (form.Param.Name == Param.User_Cmd_List[no].Name)
                    {
                        Param.User_Cmd_List[no] = form.Param.Copy();
                        Set_Param(Param);
                    }
                    else MessageBox.Show("函數名稱不能修改。", "錯誤", MessageBoxButtons.OK);
                }
            }
        }
        private void LB_User_Commands_List_DoubleClick(object sender, EventArgs e)
        {
            Edit_User_Command(LB_User_Commands_List.SelectedIndex);
        }
        private void CB_Command_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Sort_String = CB_Command.Text;
        }
        private void panel7_Resize(object sender, EventArgs e)
        {
            if (Init_Combo) Set_Cmd_Obj_Pos();
        }


        public void Swap_Value(ref TCommand_Value in1, ref TCommand_Value in2)
        {
            TCommand_Value tmp = new TCommand_Value();

            tmp = in1.Copy();
            in1 = in2.Copy();
            in2 = tmp.Copy();
        }
        private void B_In_Values_Up_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_In_Value;
            if (dg.SelectedRows.Count >= 0 && Param.In.Values_Count > 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no > 0)
                {
                    Update_Param();
                    Swap_Value(ref Param.In.Values[no], ref Param.In.Values[no - 1]);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no - 1].Cells[0];
                }
            }
        }
        private void B_In_Values_Dn_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_In_Value;
            if (dg.SelectedRows.Count >= 0 && Param.In.Values_Count > 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no < Param.In.Values_Count - 1)
                {
                    Update_Param();
                    Swap_Value(ref Param.In.Values[no], ref Param.In.Values[no + 1]);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no + 1].Cells[0];
                }
            }
        }
        private void B_In_Values_Add_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;

            dg = DG_In_Value;
            Update_Param();
            Param.In.Values_Count++;
            Set_Param(Param);
            dg.CurrentCell = dg.Rows[Param.In.Values_Count - 1].Cells[0];
        }
        private void B_In_Values_Del_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_In_Value;
            if (dg.SelectedRows.Count >= 0 && Param.In.Values_Count > 0)
            {
                Update_Param();
                no = dg.SelectedCells[0].RowIndex;
                for (int i = no; i < Param.In.Values_Count - 1; i++)
                {
                    Param.In.Values[i] = Param.In.Values[i + 1];
                }
                Param.In.Values_Count--;
                Set_Param(Param);

                if (no < Param.In.Values_Count - 1) dg.CurrentCell = dg.Rows[no].Cells[0];
                else if (Param.In.Values_Count > 0) dg.CurrentCell = dg.Rows[Param.In.Values_Count - 1].Cells[0];
            }
        }
        private void B_Out_Values_Up_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_Out_Value;
            if (dg.SelectedRows.Count >= 0 && Param.Out.Values_Count > 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no > 0)
                {
                    Update_Param();
                    Swap_Value(ref Param.Out.Values[no], ref Param.Out.Values[no - 1]);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no - 1].Cells[0];
                }
            }
        }
        private void B_Out_Values_Dn_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_Out_Value;
            if (dg.SelectedRows.Count >= 0 && Param.Out.Values_Count > 0)
            {
                no = dg.SelectedCells[0].RowIndex;
                if (no < Param.Out.Values_Count - 1)
                {
                    Update_Param();
                    Swap_Value(ref Param.Out.Values[no], ref Param.Out.Values[no + 1]);
                    Set_Param(Param);
                    dg.CurrentCell = dg.Rows[no + 1].Cells[0];
                }
            }
        }
        private void B_Out_Values_Add_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;

            dg = DG_Out_Value;
            Update_Param();
            Param.Out.Values_Count++;
            Set_Param(Param);
            dg.CurrentCell = dg.Rows[Param.Out.Values_Count - 1].Cells[0];
        }
        private void B_Out_Values_Del_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            int no = -1;

            dg = DG_Out_Value;
            if (dg.SelectedRows.Count >= 0 && Param.Out.Values_Count > 0)
            {
                Update_Param();
                no = dg.SelectedCells[0].RowIndex;
                for (int i = no; i < Param.Out.Values_Count - 1; i++)
                {
                    Param.Out.Values[i] = Param.Out.Values[i + 1];
                }
                Param.Out.Values_Count--;
                Set_Param(Param);

                if (no < Param.Out.Values_Count - 1) dg.CurrentCell = dg.Rows[no].Cells[0];
                else if (Param.Out.Values_Count > 0) dg.CurrentCell = dg.Rows[Param.Out.Values_Count - 1].Cells[0];
            }
        }
        private void B_Save_Click(object sender, EventArgs e)
        {
            switch (Last_Type)
            {
                case "Region":
                    TTool_Value_Region value_region = null;

                    value_region = (TTool_Value_Region)Run_Tool_Values.Get_Value(emValue_Type.Region, Last_Name);
                    if (value_region != null)
                    {
                    }
                    else
                        Select_Region = null;
                    break;

                case "Image":
                    TTool_Value_Image value_image = null;

                    value_image = (TTool_Value_Image)Run_Tool_Values.Get_Value(emValue_Type.Image, Last_Name);
                    if (value_image != null)
                    {
                        SaveFileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "bmp files (*.bmp)|*.bmp";
                        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            value_image.Value.WriteImage("bmp", 0, dialog.FileName);
                        }
                    }
                    break;
            }
        }

    }
    public struct stCMD_Component
    {
        public Label L_Name;
        public Label L_Info;
        public ComboBox CB_Value;
    }
    //-----------------------------------------------------------------------------------------
    //--Halcon_Tool
    //-----------------------------------------------------------------------------------------
    public enum emValue_Type { Region, Image, String, Integer, Double }
    public delegate bool evExecute_Event(string[] param_list, ref TTool_Values tool_values);

    public class Halcon_Tool
    {
        public static TTool_Value_Base Create_Value(emValue_Type type)
        {
            TTool_Value_Base result = null;
            switch (type)
            {
                case emValue_Type.Region: result = new TTool_Value_Region(); break;
                case emValue_Type.Image: result = new TTool_Value_Image(); break;
                case emValue_Type.String: result = new TTool_Value_String(); break;
                case emValue_Type.Integer: result = new TTool_Value_Integer(); break;
                case emValue_Type.Double: result = new TTool_Value_Double(); break;
            }
            return result;
        }
        public static ArrayList Get_Value_Type_List()
        {
            ArrayList result = new ArrayList();

            result.Add(emValue_Type.Region);
            result.Add(emValue_Type.Image);
            result.Add(emValue_Type.String);
            result.Add(emValue_Type.Integer);
            result.Add(emValue_Type.Double);
            return result;
        }
        public static string Get_Value_Type_String(emValue_Type type)
        {
            string result = "";

            switch (type)
            {
                case emValue_Type.Region: result = "Region"; break;
                case emValue_Type.Image: result = "Image"; break;
                case emValue_Type.String: result = "String"; break;
                case emValue_Type.Integer: result = "Integer"; break;
                case emValue_Type.Double: result = "Double"; break;
            }
            return result;
        }
        public static emValue_Type Get_Value_Type(string type_str)
        {
            emValue_Type result = emValue_Type.String;

            switch (type_str)
            {
                case "Region": result = emValue_Type.Region; break;
                case "Image": result = emValue_Type.Image; break;
                case "String": result = emValue_Type.String; break;
                case "Integer": result = emValue_Type.Integer; break;
                case "Double": result = emValue_Type.Double; break;
            }
            return result;
        }
        public static string Get_Program_Name(string program_list_str)
        {
            string result = "";
            string[] tmp_list = null;

            Break_String(program_list_str, ref tmp_list);
            if (tmp_list.Length > 0) result = tmp_list[0];
            return result;
        }
        public static void Break_String(string program_list_str, ref ArrayList result)
        {
            String_Tool.Break_String(program_list_str, ",", ref result);
        }
        public static void Break_String(string program_list_str,ref string[] result)
        {
            String_Tool.Break_String(program_list_str, ",", ref result);
        }
        public static bool Is_Variable(string value)
        {
            bool result = false;
            char[] chars;

            if (value != "" && value != null)
            {
                chars = value.ToCharArray();
                if (chars[0] >= '0' && chars[0] <= '9') result = false;
                else if (chars[0] == '\'') result = false;
                else result = true;
            }
            return result;
        }
        public static bool Is_Comment(string program_list)
        {
            bool result = true;

            if (program_list != "" && program_list != null)
            {
                char[] chars = program_list.ToCharArray();
                if (chars[0] == '@') result = true;
                else result = false;
            }
            return result;
        }
    }
    public class THalcon_Tool_File
    {
        public string                 Default_Path,
                                      Default_FileName,
                                      FileName,
                                      Info;
        public TCommand_Define        CMD = new TCommand_Define(); 


        public THalcon_Tool_File()
        {
            Default_Path = "";
            Default_FileName = "";
            FileName = "";
            Info = "";
            Set_Default();
        }
        public void Set_Default()
        {
            CMD.Set_Default();
        }
        public THalcon_Tool_File Copy()
        {
            THalcon_Tool_File result = new THalcon_Tool_File();

            result.Default_Path = Default_Path;
            result.Default_FileName = Default_FileName;
            result.FileName = FileName;
            result.Info = Info;

            result.CMD = CMD.Copy();
            return result;
        }
        public bool Read(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            result = false;
            if (filename == "") filename = Default_Path + Default_FileName;
            if (System.IO.File.Exists(filename))
            {
                FileName = filename;
                ini = new TJJS_XML_File(FileName);
                result = Read(ini, section);
                //ini.UpdateFile();
            };
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;

            if (ini != null && section != "")
            {
                tmp_section = section;
                Info = ini.ReadString(tmp_section, "Info", "");

                CMD.Read(ini, tmp_section);
            }
            return true;
        }
        public bool Write(string filename = "", string section = "Default")
        {
            bool result;
            TJJS_XML_File ini;

            if (filename == "") filename = Default_Path + Default_FileName;
            FileName = filename;
            ini = new TJJS_XML_File(FileName);
            result = Write(ini, section);
            ini.Save_File();
            return result;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Info", Info);

                CMD.Write(ini, tmp_section);
            }
            return true;
        }
    }
    //-----------------------------------------------------------------------------------------
    //--Halcon_Tool
    //-----------------------------------------------------------------------------------------
    public class TCommand_manager
    {
        public TCommand_Define[] Commands = new TCommand_Define[0];

        public int Commands_Count
        {
            get
            {
                return Commands.Length;
            }
            set
            {
                int old_count = Commands.Length;
                Array.Resize(ref Commands, value);
                for (int i = old_count; i < value; i++)
                    Commands[i] = new TCommand_Define();
            }
        }
        public TCommand_manager()
        {
        }
        public bool Execute(TCommand_Define cmd, ref TTool_Values tool_values)
        {
            bool result = true;
            string program_str;

            for (int i = 0; i < cmd.Programs_List.Count; i++ )
            {
                program_str = cmd.Programs_List[i].ToString();
                if (!Halcon_Tool.Is_Comment(program_str))
                {
                    result = Execute(program_str, ref tool_values, cmd);
                    if (!result) break;
                }
            }
            return result;
        }
        public bool Execute(string program_list, ref TTool_Values tool_values, TCommand_Define user_cmd)
        {
            bool result = true;
            string[] command_list = null;
            TCommand_Define default_cmd = null;
            string cmd_str = "";

            if (!Halcon_Tool.Is_Comment(program_list))
            {
                Halcon_Tool.Break_String(program_list, ref command_list);
                default_cmd = Get_Command(program_list);
                if (default_cmd != null)
                {
                    if (!default_cmd.User_Define)
                    {
                        if (default_cmd.Execute != null) default_cmd.Execute(command_list, ref tool_values);
                    }
                    else
                    {
                        TCommand_Define sub_cmd = null;

                        sub_cmd = user_cmd.Get_User_Cmd_List(default_cmd.Name);
                        if (sub_cmd != null)
                        {
                            sub_cmd.Set_Data(command_list);
                            TTool_Values tmp_tool_values = new TTool_Values();
                            tmp_tool_values.Add_In(sub_cmd, tool_values);
                            tmp_tool_values.Add(sub_cmd.Out);

                            TCommand_manager tmp_manager = new TCommand_manager();
                            tmp_manager.Register_All_Command();
                            tmp_manager.Register_User_Command(sub_cmd.User_Cmd_List);

                            result = tmp_manager.Execute(sub_cmd, ref tmp_tool_values);

                            tool_values.Add_Out(sub_cmd, tmp_tool_values);
                        }
                    }
                }
            }
            return result;
        }
        public void Register_All_Command()
        {
            Register_Region_Command();
            Register_Image_Command();
        }
        public void Register_Region_Command()
        {
            Register_Command(Get_Define_Select_Shape());
            Register_Command(Get_Define_Difference());
            Register_Command(Get_Define_Intersection());
            Register_Command(Get_Define_Connection());
            Register_Command(Get_Define_Union1());
            Register_Command(Get_Define_Union2());
            Register_Command(Get_Define_Dilation_Circle());
            Register_Command(Get_Define_Dilation_Rectangle());
            Register_Command(Get_Define_Erosion_Circle());
            Register_Command(Get_Define_Erosion_Rectangle());
        }
        public void Register_Image_Command()
        {
            Register_Command(Get_Define_Abs_Image());
            Register_Command(Get_Define_Add_Image());
            Register_Command(Get_Define_Div_Image());
            Register_Command(Get_Define_Dots_Image());
            Register_Command(Get_Define_Invert_Image());
            Register_Command(Get_Define_Max_Image());
            Register_Command(Get_Define_Mean_Image());
            Register_Command(Get_Define_Min_Image());
            Register_Command(Get_Define_Mult_Image());
            Register_Command(Get_Define_Reduce_Domain());
            Register_Command(Get_Define_Scale_Image());
            Register_Command(Get_Define_Sqrt_Image());
            Register_Command(Get_Define_Sub_Image());
            Register_Command(Get_Define_Sub_Image_EFC());
            Register_Command(Get_Define_Emphasize());
            Register_Command(Get_Define_Illuminate());
            Register_Command(Get_Define_Threshold());
            Register_Command(Get_Define_Gen_Image_Proto());
            Register_Command(Get_Define_Lut_Trans());
        }
        public void Register_User_Command(TCommand_Define[] User_Commands)
        {
            ArrayList list = new ArrayList();

            Delete_User_Command();
            for (int i = 0; i < User_Commands.Length; i++)
            {
                TCommand_Define cmd = new TCommand_Define();
                cmd.Name = User_Commands[i].Name;
                cmd.User_Define = true;
                for (int j = 0; j < User_Commands[i].In.Values_Count; j++)
                {
                    cmd.In.Add(User_Commands[i].In.Values[j]);
                }
                for (int j = 0; j < User_Commands[i].Out.Values_Count; j++)
                {
                    cmd.Out.Add(User_Commands[i].Out.Values[j]);
                }
                Register_Command(cmd);
            }
        }
        public bool Register_Command(TCommand_Define cmd)
        {
            bool result = false;

            if (Get_Command(cmd.Name) == null)
            {
                Commands_Count++;
                Commands[Commands_Count - 1] = cmd.Copy();
                result = true;
            }
            return result;
        }
        public TCommand_Define Get_Command(string program_list_str)
        {
            TCommand_Define result = null;
            string cmd_str = "";

            cmd_str = Halcon_Tool.Get_Program_Name(program_list_str);
            for (int i = 0; i < Commands_Count; i++)
            {
                if (cmd_str == Commands[i].Name)
                {
                    result = new TCommand_Define();
                    result = Commands[i].Copy();
                    break;
                }
            }
            return result;
        }
        public void Delete_User_Command()
        {
            TCommand_Define[] tmp_commands = new TCommand_Define[Commands_Count];
            int no = 0;

            for(int i=0; i<Commands_Count; i++)
            {
                if (!Commands[i].User_Define)
                {
                    tmp_commands[no] = Commands[i];
                    no++;
                }
            }
            Array.Resize(ref tmp_commands, no);
            Commands = tmp_commands;
        }

        public TCommand_Define Get_Define_Select_Shape()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "select_shape";
            result.User_Define = false;
            result.Execute += Execute_Select_Shape;
            result.In.Add(emValue_Type.Region, "In_Region", "In_Region", "", "", null);
            result.In.Add(emValue_Type.String, "Features", "Features", "", "'area'", Get_List_Feature());
            result.In.Add(emValue_Type.String, "Operation", "Operation", "", "'and'", Get_List_Operation());
            result.In.Add(emValue_Type.Double, "Min", "Min", "", "1", null);
            result.In.Add(emValue_Type.Double, "Max", "Max", "", "100", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Select_Shape(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HRegion in_obj = null;
            TTool_Value_Region out_obj = null;
            string features = "";
            string operation = "";
            double min = 0, max = 0;

            if (param_list.Length == 7 && param_list[0] == "select_shape")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                features = tool_values.Get_Value_String(param_list[2]);
                operation = tool_values.Get_Value_String(param_list[3]);
                min = tool_values.Get_Value_Double(param_list[4]);
                max = tool_values.Get_Value_Double(param_list[5]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[6]);
                if (in_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in_obj.SelectShape(features, operation, min, max);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Difference()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "difference";
            result.Execute += Execute_Difference;
            result.In.Add(emValue_Type.Region, "Region1", "Region1", "", "", null);
            result.In.Add(emValue_Type.Region, "Region2", "Region2", "", "", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Difference(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            HRegion sub_obj = null;
            TTool_Value_Region out_obj = null;

            if (param_list.Length == 4 && param_list[0] == "difference")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                sub_obj = tool_values.Get_Value_Region(param_list[2]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[3]);
                if (in_obj != null && out_obj != null && sub_obj != null)
                {
                    try
                    {
                        out_obj.Value = in_obj.Difference(sub_obj);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Intersection()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "intersection";
            result.Execute += Execute_Intersection;
            result.In.Add(emValue_Type.Region, "Region1", "Region1", "", "", null);
            result.In.Add(emValue_Type.Region, "Region2", "Region2", "", "", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Intersection(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            HRegion sub_obj = null;
            TTool_Value_Region out_obj = null;

            if (param_list.Length == 4 && param_list[0] == "intersection")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                sub_obj = tool_values.Get_Value_Region(param_list[2]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[3]);
                if (in_obj != null && out_obj != null && sub_obj != null)
                {
                    try
                    {
                        out_obj.Value = in_obj.Intersection(sub_obj);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Connection()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "connection";
            result.Execute += Execute_Connection;
            result.In.Add(emValue_Type.Region, "In_Region", "In_Region", "", "", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Connection(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            TTool_Value_Region out_obj = null;

            if (param_list.Length == 3 && param_list[0] == "connection")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[2], null);
                if (in_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in_obj.Connection();
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Union1()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "union1";
            result.Execute += Execute_Union1;
            result.In.Add(emValue_Type.Region, "In_Region", "In_Region", "", "", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Union1(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            TTool_Value_Region out_obj = null;

            if (param_list.Length == 3 && param_list[0] == "union1")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[2]);
                if (in_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in_obj.Union1();
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Union2()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "union2";
            result.Execute += Execute_Union2;
            result.In.Add(emValue_Type.Region, "Region1", "Region1", "", "", null);
            result.In.Add(emValue_Type.Region, "Region2", "Region2", "", "", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Union2(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            HRegion sub_obj = null;
            TTool_Value_Region out_obj = null;

            if (param_list.Length == 4 && param_list[0] == "union2")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1].ToString());
                sub_obj = tool_values.Get_Value_Region(param_list[2].ToString());
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[3]);
                if (in_obj != null && out_obj != null && sub_obj != null)
                {
                    try
                    {
                        out_obj.Value = in_obj.Union2(sub_obj);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Dilation_Circle()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "dilation_circle";
            result.Execute += Execute_Dilation_Circle;
            result.In.Add(emValue_Type.Region, "Region", "Region", "", "", null);
            result.In.Add(emValue_Type.Double, "Radius", "Radius", "", "3.5", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Dilation_Circle(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            TTool_Value_Region out_obj = null;
            double radius = 1;

            if (param_list.Length == 4 && param_list[0] == "dilation_circle")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                radius = tool_values.Get_Value_Double(param_list[2]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[3]);
                if (in_obj != null && out_obj != null && radius > 0)
                {
                    try
                    {
                        out_obj.Value = in_obj.DilationCircle(radius);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Dilation_Rectangle()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "dilation_rectangle";
            result.Execute += Execute_Dilation_Rectangle;
            result.In.Add(emValue_Type.Region, "Region", "Region", "", "", null);
            result.In.Add(emValue_Type.Integer, "Width", "Width", "", "11", null);
            result.In.Add(emValue_Type.Integer, "Height", "Height", "", "11", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Dilation_Rectangle(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            TTool_Value_Region out_obj = null;
            int width = 1;
            int height = 1;

            if (param_list.Length == 4 && param_list[0] == "dilation_rectangle")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                width = Convert.ToInt32(param_list[2]);
                height = Convert.ToInt32(param_list[3]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[4]);
                if (in_obj != null && out_obj != null && width > 0 && height > 0)
                {
                    try
                    {
                        out_obj.Value = in_obj.DilationRectangle1(width, height);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Erosion_Circle()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "erosion_circle";
            result.Execute += Execute_Erosion_Circle;
            result.In.Add(emValue_Type.Region, "Region", "Region", "", "", null);
            result.In.Add(emValue_Type.Double, "Radius", "Radius", "", "3.5", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Erosion_Circle(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            TTool_Value_Region out_obj = null;
            double radius = 1;

            if (param_list.Length == 4 && param_list[0] == "erosion_circle")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                radius = tool_values.Get_Value_Double(param_list[2]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[3]);
                if (in_obj != null && out_obj != null && radius > 0)
                {
                    try
                    {
                        out_obj.Value = in_obj.ErosionCircle(radius);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;

        }

        public TCommand_Define Get_Define_Erosion_Rectangle()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "erosion_rectangle";
            result.Execute += Execute_Erosion_Rectangle;
            result.In.Add(emValue_Type.Region, "Region", "Region", "", "", null);
            result.In.Add(emValue_Type.Integer, "Width", "Width", "", "11", null);
            result.In.Add(emValue_Type.Integer, "Height", "Height", "", "11", null);
            result.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
            return result;
        }
        private bool Execute_Erosion_Rectangle(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;
            HRegion in_obj = null;
            TTool_Value_Region out_obj = null;
            int width = 1;
            int height = 1;

            if (param_list.Length == 4 && param_list[0] == "erosion_rectangle")
            {
                in_obj = tool_values.Get_Value_Region(param_list[1]);
                width = tool_values.Get_Value_Integer(param_list[2]);
                height = tool_values.Get_Value_Integer(param_list[3]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[4]);
                if (in_obj != null && out_obj != null && width > 0 && height > 0)
                {
                    try
                    {
                        out_obj.Value = in_obj.ErosionRectangle1(width, height);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }


        public TCommand_Define Get_Define_Abs_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "abs_image";
            result.Execute += Execute_Abs_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Abs_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;

            if (param_list.Length == 3 && param_list[0] == "abs_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[2]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.AbsImage();
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Add_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "add_image";
            result.Execute += Execute_Add_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Image, "Image2", "Image2", "", "", null);
            result.In.Add(emValue_Type.Double, "Mult", "Mult", "", "0.5", null);
            result.In.Add(emValue_Type.Double, "Add", "Add", "", "0.0", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Add_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            TTool_Value_Image out_obj = null;
            double mult = 0.5;
            double add = 0;

            if (param_list.Length == 6 && param_list[0] == "add_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                mult = tool_values.Get_Value_Double(param_list[3]);
                add = tool_values.Get_Value_Double(param_list[4]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.AddImage(in2_obj, mult, add);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Div_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "div_image";
            result.Execute += Execute_Div_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Image, "Image2", "Image2", "", "", null);
            result.In.Add(emValue_Type.Double, "Mult", "Mult", "", "255.0", null);
            result.In.Add(emValue_Type.Double, "Add", "Add", "", "0.0", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Div_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            TTool_Value_Image out_obj = null;
            double mult = 0.5;
            double add = 0;

            if (param_list.Length == 6 && param_list[0] == "div_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                mult = tool_values.Get_Value_Double(param_list[3]);
                add = tool_values.Get_Value_Double(param_list[4]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.AddImage(in2_obj, mult, add);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Dots_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "dots_image";
            result.Execute += Execute_Dots_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Integer, "Diameter", "Diameter", "", "5", null);
            result.In.Add(emValue_Type.String, "Filter Type", "Filter Type", "", "'light'", Get_List_Dots_FilterType());
            result.In.Add(emValue_Type.Integer, "Pixel Shift", "Pixel Shift", "", "0", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Dots_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;
            int diameter = 5;
            string filter_type = "light";
            int pixel_shift = 0;

            if (param_list.Length == 6 && param_list[0] == "dots_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                diameter = tool_values.Get_Value_Integer(param_list[2]);
                filter_type = tool_values.Get_Value_String(param_list[3]);
                pixel_shift = tool_values.Get_Value_Integer(param_list[4]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.DotsImage(diameter, filter_type, pixel_shift);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Invert_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "invert_image";
            result.Execute += Execute_Invert_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Invert_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;

            if (param_list.Length == 3 && param_list[0] == "invert_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1].ToString());
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[2]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.InvertImage();
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Max_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "max_image";
            result.Execute += Execute_Max_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Image, "Image2", "Image2", "", "", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Max_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            TTool_Value_Image out_obj = null;

            if (param_list.Length == 4 && param_list[0] == "max_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[3]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.MaxImage(in2_obj);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Mean_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "mean_image";
            result.Execute += Execute_Mean_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Integer, "Mask Width", "Mask Width", "", "9", null);
            result.In.Add(emValue_Type.Integer, "Mask Height", "Mask Height", "", "9", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Mean_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;
            int mask_width = 9;
            int mask_height = 9;

            if (param_list.Length == 5 && param_list[0] == "mean_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                mask_width = tool_values.Get_Value_Integer(param_list[2]);
                mask_height = tool_values.Get_Value_Integer(param_list[3]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[4]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.MeanImage(mask_width, mask_height);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Min_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "min_image";
            result.Execute += Execute_Min_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Image, "Image2", "Image2", "", "", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Min_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            TTool_Value_Image out_obj = null;

            if (param_list.Length == 4 && param_list[0] == "min_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[3]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.MinImage(in2_obj);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Mult_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "mult_image";
            result.Execute += Execute_Mult_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Image, "Image2", "Image2", "", "", null);
            result.In.Add(emValue_Type.Double, "Mult", "Mult", "", "0.005", null);
            result.In.Add(emValue_Type.Double, "Add", "Add", "", "0", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Mult_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            TTool_Value_Image out_obj = null;
            double mult = 0.005;
            double add = 0;

            if (param_list.Length == 6 && param_list[0] == "mult_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                mult = tool_values.Get_Value_Double(param_list[3]);
                add = tool_values.Get_Value_Double(param_list[4]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.MultImage(in2_obj, mult, add);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Reduce_Domain()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "reduce_domain";
            result.Execute += Execute_Reduce_Domain;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Region, "Region1", "Region1", "", "", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Reduce_Domain(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HRegion in2_obj = null;
            TTool_Value_Image out_obj = null;

            if (param_list.Length == 4 && param_list[0] == "reduce_domain")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Region(param_list[2]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[3]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.ReduceDomain(in2_obj);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Scale_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "scale_image";
            result.Execute += Execute_Scale_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Image, "Image2", "Image2", "", "", null);
            result.In.Add(emValue_Type.Double, "Mult", "Mult", "", "0.01", null);
            result.In.Add(emValue_Type.Double, "Add", "Add", "", "0", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Scale_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            TTool_Value_Image out_obj = null;
            double mult = 0.01;
            double add = 0;

            if (param_list.Length == 6 && param_list[0] == "scale_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                mult = tool_values.Get_Value_Double(param_list[1]);
                add = tool_values.Get_Value_Double(param_list[1]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.MultImage(in2_obj, mult, add);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Sqrt_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "sqrt_image";
            result.Execute += Execute_Sqrt_Image;
            result.In.Add(emValue_Type.Image, "Result Image", "Image1", "", "", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Sqrt_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;

            if (param_list.Length == 3 && param_list[0] == "sqrt_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[2]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.SqrtImage();
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Sub_Image()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "sub_image";
            result.Execute += Execute_Sub_Image;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Image, "Image2", "Image2", "", "", null);
            result.In.Add(emValue_Type.Double, "Mult", "Mult", "", "1", null);
            result.In.Add(emValue_Type.Double, "Add", "Add", "", "128", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Sub_Image(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            TTool_Value_Image out_obj = null;
            double mult = 0.5;
            double add = 0;

            if (param_list.Length == 6 && param_list[0] == "sub_image")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                mult = tool_values.Get_Value_Double(param_list[3]);
                add = tool_values.Get_Value_Double(param_list[4]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.SubImage(in2_obj, mult, add);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Sub_Image_EFC()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "sub_image_efc";
            result.Execute += Execute_Sub_Image_EFC;
            result.In.Add(emValue_Type.Image, "Image Min", "Image Min", "", "", null);
            result.In.Add(emValue_Type.Image, "Image Max", "Image Max", "", "", null);
            result.In.Add(emValue_Type.Image, "Image Sample", "Image Sample", "", "", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Sub_Image_EFC(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            HImage in2_obj = null;
            HImage in3_obj = null;
            TTool_Value_Image out_obj = null;

            if (param_list.Length == 5 && param_list[0] == "sub_image_efc")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                in2_obj = tool_values.Get_Value_Image(param_list[2]);
                in3_obj = tool_values.Get_Value_Image(param_list[3]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[4]);
                if (in1_obj != null && in2_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = TJJS_Vision.Sub_Image_EFC(in1_obj, in2_obj, in3_obj);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Emphasize()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "emphasize";
            result.Execute += Execute_Emphasize;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Integer, "Mask Width", "Mask Width", "", "7", null);
            result.In.Add(emValue_Type.Integer, "Mask Height", "Mask Height", "", "7", null);
            result.In.Add(emValue_Type.Double, "Factor", "Factor", "", "1", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Emphasize(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;
            int mask_width = 7;
            int mask_height = 7;
            double factor = 1;

            if (param_list.Length == 6 && param_list[0] == "emphasize")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                mask_width = tool_values.Get_Value_Integer(param_list[2]);
                mask_height = tool_values.Get_Value_Integer(param_list[3]);
                factor = tool_values.Get_Value_Double(param_list[4].ToString());
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.Emphasize(mask_width, mask_height, factor);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Illuminate()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "illuminate";
            result.Execute += Execute_Illuminate;
            result.In.Add(emValue_Type.Image, "Image1", "Image1", "", "", null);
            result.In.Add(emValue_Type.Integer, "Mask Width", "Mask Width", "", "7", null);
            result.In.Add(emValue_Type.Integer, "Mask Height", "Mask Height", "", "7", null);
            result.In.Add(emValue_Type.Double, "Factor", "Factor", "", "1", null);
            result.Out.Add(emValue_Type.Image, "Result Image", "Result Image", "", "", null);
            return result;
        }
        private bool Execute_Illuminate(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;
            int mask_width = 7;
            int mask_height = 7;
            double factor = 1;

            if (param_list.Length == 6 && param_list[0] == "illuminate")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                mask_width = tool_values.Get_Value_Integer(param_list[2]);
                mask_height = tool_values.Get_Value_Integer(param_list[3]);
                factor = tool_values.Get_Value_Double(param_list[4]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[5]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.Illuminate(mask_width, mask_height, factor);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Threshold()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "threshold";
            result.Execute += Execute_Threshold;
            result.In.Add(emValue_Type.Image, "In Image", "In Image", "", "", null);
            result.In.Add(emValue_Type.Double, "Min", "Min", "", "128.0", null);
            result.In.Add(emValue_Type.Double, "Max", "Max", "", "255.0", null);
            result.Out.Add(emValue_Type.Region, "Out Region", "Out Region", "", "", null);
            return result;
        }
        private bool Execute_Threshold(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Region out_obj = null;
            double min = 128.0;
            double max = 255.0;

            if (param_list.Length == 5 && param_list[0] == "threshold")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                min = tool_values.Get_Value_Double(param_list[2]);
                max = tool_values.Get_Value_Double(param_list[3]);
                out_obj = (TTool_Value_Region)tool_values.Add_Region(param_list[4]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.Threshold(min, max);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Gen_Image_Proto()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "gen_image_proto";
            result.Execute += Execute_Gen_Image_Proto;
            result.In.Add(emValue_Type.Image, "In Image", "In Image", "", "", null);
            result.In.Add(emValue_Type.Double, "Gray", "Gray", "", "128.0", null);
            result.Out.Add(emValue_Type.Image, "Out Image", "Out Image", "", "", null);
            return result;
        }
        private bool Execute_Gen_Image_Proto(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;
            double gray = 128.0;

            if (param_list.Length == 4 && param_list[0] == "gen_image_proto")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                gray = tool_values.Get_Value_Double(param_list[2]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[3]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.GenImageProto(gray);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }

        public TCommand_Define Get_Define_Lut_Trans()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = "lut_trans";
            result.Execute += Execute_Lut_Trans;
            result.In.Add(emValue_Type.Image, "In Image", "In Image", "", "", null);
            result.In.Add(emValue_Type.String, "Lut", "Lut", "", "255|255", null);
            result.Out.Add(emValue_Type.Image, "Out Image", "Out Image", "", "", null);
            return result;
        }
        private bool Execute_Lut_Trans(string[] param_list, ref TTool_Values tool_values)
        {
            bool result = false;

            HImage in1_obj = null;
            TTool_Value_Image out_obj = null;
            HTuple lut = new HTuple();

            if (param_list.Length == 4 && param_list[0] == "lut_trans")
            {
                in1_obj = tool_values.Get_Value_Image(param_list[1]);
                lut = Get_Gray_Lut(param_list[2]);
                out_obj = (TTool_Value_Image)tool_values.Add_Image(param_list[3]);
                if (in1_obj != null && out_obj != null)
                {
                    try
                    {
                        out_obj.Value = in1_obj.LutTrans(lut);
                        result = true;
                    }
                    catch { };
                }
            }
            return result;
        }
        private HTuple Get_Gray_Lut(string str)
        {
            HTuple result = new HTuple();
            string[] lut_str = new string[0];
            int sor_s = 0, sor_e = 0;
            int dis_s = 0, dis_e = 0;
            int sor_gray = 0;
            double dis_gray = 0;
            double d_gray = 1.0;
            int no = 0;

            String_Tool.Break_String(str, "|", ref lut_str);
            int[] lut_sor = new int[lut_str.Length / 2];
            int[] lut_dis = new int[lut_str.Length / 2];

            for (int i = 0; i < lut_str.Length / 2; i++)
            {
                lut_sor[i] = Convert.ToInt32(lut_str[i * 2 + 0]);
                lut_dis[i] = Convert.ToInt32(lut_str[i * 2 + 1]);
            }

            sor_e = lut_sor[0];
            dis_e = lut_dis[0];
            while(sor_gray <= 255)
            {
                if (sor_gray > sor_e)
                {
                    no++;
                    if (no >= lut_sor.Length) break;
                    sor_s = sor_e;
                    dis_s = dis_e;
                    sor_e = lut_sor[no];
                    dis_e = lut_dis[no];
                }
                d_gray = (double)(dis_e - dis_s) / (sor_e - sor_s);
                dis_gray = Math.Round(dis_s + d_gray * (sor_gray - sor_s), 0);
                result.Append((int)dis_gray);
                sor_gray++;
            }
            return result;
        }


        public bool Get_Tool_Values(ArrayList list, ref TTool_Values tool_values)
        {
            return Get_Tool_Values(ArrayList_Tool.To_Strings(list), ref tool_values);
        }
        public bool Get_Tool_Values(string[] program_list, ref TTool_Values tool_values)
        {
            bool result = true;
            string[] command_list = null;
            TCommand_Define cmd_define = null;
            string cmd_str = "";
            TCommand_Value value = null;

            for (int i = 0; i < program_list.Length; i++)
            {
                Halcon_Tool.Break_String(program_list[i].ToString(), ref command_list);
                if (command_list.Length > 0)
                {
                    cmd_str = command_list[0].ToString();
                    cmd_define = Get_Command(cmd_str);
                    if (cmd_define != null)
                    {
                        cmd_define.Set_Data(command_list);
                        for (int j = 0; j < cmd_define.Out.Values_Count; j++)
                        {
                            value = cmd_define.Out.Values[j];
                            if (Halcon_Tool.Is_Variable(value.Value))
                            {
                                switch (value.Type)
                                {
                                    case emValue_Type.Region: tool_values.Add_Region(value.Value); break;
                                    case emValue_Type.Image: tool_values.Add_Image(value.Value); break;
                                    case emValue_Type.String: tool_values.Add_String(value.Value); break;
                                    case emValue_Type.Integer: tool_values.Add_Integer(value.Value); break;
                                    case emValue_Type.Double: tool_values.Add_Double(value.Value); break;
                                }
                            }
                        }
                    }
                }
                else result = false;
                if (!result) break;
            }
            return result;
        }
        public  ArrayList Get_Command_List()
        {
            ArrayList result = new ArrayList();

            for (int i = 0; i < Commands.Length; i++) result.Add(Commands[i].Name);
            return result;
        }

        public ArrayList Get_List_Feature()
        {
            ArrayList result = new ArrayList();
            ArrayList_Tool.Set_String(ref result, new string[]{
                "'area'",
                "'row'",
                "'column'",
                "'width'",
                "'height'",
                "'row1'",
                "'column1'",
                "'row2'",
                "'column2'",
                "'circularity'",
                "'compactness'",
                "'contlength'",
                "'convexity'",
                "'rectangularity'",
                "'ra'",
                "'rb'",
                "'phi'",
                "'anisometry'",
                "'bulkiness'",
                "'struct_factor'",
                "'outer_radius'",
                "'inner_radius'",
                "'inner_width'",
                "'inner_height'",
                "'dist_mean'",
                "'dist_deviation'",
                "'roundness'",
                "'num_sides'",
                "'connect_num'",
                "'holes_num'",
                "'area_holes'",
                "'max_diameter'",
                "'orientation'",
                "'euler_number'",
                "'rect2_phi'",
                "'rect2_len1'",
                "'rect2_len2'"});

            return result;
        }
        public ArrayList Get_List_Operation()
        {
            ArrayList result = new ArrayList();
            ArrayList_Tool.Set_String(ref result, new string[] { "'and'", "'or'" });
            return result;
        }
        public ArrayList Get_List_Dots_FilterType()
        {
            ArrayList result = new ArrayList();
            ArrayList_Tool.Set_String(ref result, new string[] { "'all'", "'dark'", "'light'" });
            return result;
        }
    }
    public class TCommand_Define
    {
        public string                  Name = "Default";
        public bool                    User_Define = false;
        public TCommand_Values_List    In = new TCommand_Values_List();
        public TCommand_Values_List    Out = new TCommand_Values_List();
        public ArrayList               Programs_List = new ArrayList();
        public TCommand_Define[]       User_Cmd_List = new TCommand_Define[0];
        public evExecute_Event         Execute = null;


        public int User_Cmd_List_Count
        {
            get
            {
                return User_Cmd_List.Length;
            }
            set
            {
                int old_count = User_Cmd_List.Length;
                Array.Resize(ref User_Cmd_List, value);
                for (int i = old_count; i < value; i++) User_Cmd_List[i] = new TCommand_Define();
            }
        }
        public int Cmd_Str_Count
        {
            get
            {
                return In.Values_Count + Out.Values_Count + 1;
            }
        }
        public TCommand_Define()
        {
            Set_Default();
        }
        public void Set_Default()
        {
            Name = "Default";
            User_Define = false;
            In.Set_Default();
            Out.Set_Default();
            Programs_List.Clear();
            User_Cmd_List_Count = 0;
            Execute = null;
        }
        public TCommand_Define Copy()
        {
            TCommand_Define result = new TCommand_Define();

            result.Name = Name;
            result.User_Define = User_Define;
            result.In = In.Copy();
            result.Out = Out.Copy();
            result.Programs_List = Programs_List;

            result.User_Cmd_List_Count = User_Cmd_List_Count;
            for (int i = 0; i < User_Cmd_List_Count; i++) result.User_Cmd_List[i] = User_Cmd_List[i].Copy();
            result.Execute = Execute;
            return result;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            int count = 0;
            string tmp_str = "";
            string[] list = null;

            if (ini != null && section != "")
            {
                tmp_section = section;
                Name = ini.ReadString(tmp_section, "Name", "");

                In.Values_Count = ini.ReadInteger(tmp_section, "In_Value_Count", 0);
                for (int i = 0; i < In.Values_Count; i++)
                {
                    In.Values[i].Set_Data(ini.ReadString(tmp_section, "In_Value" + (i + 1).ToString(), ""));
                }

                Out.Values_Count = ini.ReadInteger(tmp_section, "Out_Value_Count", 0);
                for (int i = 0; i < Out.Values_Count; i++)
                {
                    Out.Values[i].Set_Data(ini.ReadString(tmp_section, "Out_Value" + (i + 1).ToString(), ""));
                }

                Programs_List.Clear();
                count = ini.ReadInteger(tmp_section, "Programs_List_Count", 0);
                for (int i = 0; i < count; i++)
                {
                    tmp_str = ini.ReadString(tmp_section, "Programs" + (i + 1).ToString(), "");
                    Programs_List.Add(tmp_str);
                }

                User_Cmd_List_Count = ini.ReadInteger(tmp_section, "User_Cmd_List_Count", 0);
                for (int i = 0; i < User_Cmd_List_Count; i++)
                {
                    User_Cmd_List[i].Read(ini, tmp_section + "/User_Command" + (i + 1).ToString());
                    User_Cmd_List[i].User_Define = true;
                }
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            string tmp_section;
            if (ini != null && section != "")
            {
                tmp_section = section;
                ini.WriteString(tmp_section, "Name", Name);

                ini.WriteInteger(tmp_section, "In_Value_Count", In.Values_Count);
                for (int i = 0; i < In.Values_Count; i++)
                {
                    ini.WriteString(tmp_section, "In_Value" + (i + 1).ToString(), In.Values[i].ToString());
                }

                ini.WriteInteger(tmp_section, "Out_Value_Count", Out.Values_Count);
                for (int i = 0; i < Out.Values_Count; i++)
                {
                    ini.WriteString(tmp_section, "Out_Value" + (i + 1).ToString(), Out.Values[i].ToString());
                }

                ini.WriteInteger(tmp_section, "Programs_List_Count", Programs_List.Count);
                for (int i = 0; i < Programs_List.Count; i++)
                {
                    ini.WriteString(tmp_section, "Programs" + (i + 1).ToString(), Programs_List[i].ToString());
                }

                ini.WriteInteger(tmp_section, "User_Cmd_List_Count", User_Cmd_List_Count);
                for (int i = 0; i < User_Cmd_List_Count; i++)
                {
                    User_Cmd_List[i].Write(ini, tmp_section + "/User_Command" + (i + 1).ToString());
                }
            }
            return true;
        }
        public TCommand_Define Get_User_Cmd_List(string name)
        {
            TCommand_Define result = null;

            for (int i = 0; i < User_Cmd_List_Count; i++)
            {
                if (name == User_Cmd_List[i].Name)
                {
                    result = new TCommand_Define();
                    result = User_Cmd_List[i].Copy();
                    break;
                }
            }
            return result;
        }
        public int Get_User_Cmd_List_No(string name)
        {
            int result = -1;

            for (int i = 0; i < User_Cmd_List_Count; i++)
            {
                if (name == User_Cmd_List[i].Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";

            result = Name;
            for (int i = 0; i < In.Values_Count; i++)
            {
                result = result + "," + In.Values[i].Value;
            }
            for (int i = 0; i < Out.Values_Count; i++)
            {
                result = result + "," + Out.Values[i].Value;
            }
            return result;
        }
        public bool Set_Data(string program_list_str)
        {
            bool result = false;
            string[] list = null;

            Halcon_Tool.Break_String(program_list_str,ref list);
            result = Set_Data(list);
            return result;
        }
        public bool Set_Data(ArrayList list)
        {
            bool result = false;
            ArrayList in_list = new ArrayList();
            ArrayList out_list = new ArrayList();

            if (list.Count == Cmd_Str_Count && list[0].ToString() == Name)
            {
                in_list = ArrayList_Tool.Sub_String(list, 1, In.Values_Count);
                out_list = ArrayList_Tool.Sub_String(list, In.Values_Count + 1, Out.Values_Count);
                if (In.Set_Values(in_list) && Out.Set_Values(out_list)) result = true;
            }
            return result;
        }
        public bool Set_Data(string[] strings)
        {
            bool result = false;
            string[] in_list = new string[In.Values_Count];
            string[] out_list = new string[Out.Values_Count];

            if (strings.Length == Cmd_Str_Count && strings[0] == Name)
            {
                for (int i = 0; i < In.Values_Count; i++) in_list[i] = strings[i + 1];
                for (int i = 0; i < Out.Values_Count; i++) out_list[i] = strings[i + In.Values_Count + 1];
                if (In.Set_Values(in_list) && Out.Set_Values(out_list)) result = true;
            }
            return result;
        }
        public void Add_User_Cmd_List(TCommand_Define cmd)
        {
            User_Cmd_List_Count++;
            User_Cmd_List[User_Cmd_List_Count - 1] = cmd.Copy();
        }
        public void Del_User_Cmd_List(int no)
        {
            if (no >= 0 && no < User_Cmd_List_Count)
            {
                for (int i = no; i < User_Cmd_List_Count - 1; i++)
                {
                    User_Cmd_List[i] = User_Cmd_List[i + 1].Copy();
                }
                User_Cmd_List_Count--;
            }
        }
    }
    public class TCommand_Values_List
    {
        public TCommand_Value[] Values = new TCommand_Value[0];

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
                for (int i = old_count; i < value; i++) Values[i] = new TCommand_Value();
            }
        }
        public TCommand_Values_List()
        {
            Set_Default();
        }
        public void Set_Default()
        {
            Values_Count = 0;
        }
        public TCommand_Values_List Copy()
        {
            TCommand_Values_List result = new TCommand_Values_List();

            result.Values_Count = Values_Count;
            for (int i = 0; i < Values_Count; i++) result.Values[i] = Values[i].Copy();
            return result;
        }
        public int Find_Index(TCommand_Value value)
        {
            int result = -1;

            for (int i = 0; i < Values_Count; i++)
            {
                if (value.Name == Values[i].Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Add()
        {
            Values_Count++;
        }
        public void Add(TCommand_Value value)
        {
            if (Find_Index(value) < 0)
            {
                Values_Count++;
                Values[Values_Count - 1] = value.Copy();
            }
        }
        public void Add(emValue_Type type, string name, string disp_string, string value, string default_value, ArrayList combo_list = null)
        {
            Add(new TCommand_Value(type, name, disp_string, value, default_value, combo_list));
        }
        public void Del()
        {
            Del(Values_Count - 1);
        }
        public void Del(int no)
        {
            if (no >= 0 && no < Values_Count)
            {
                for (int i = no; i < Values_Count - 1; i++)
                {
                    Values[i] = Values[i + 1].Copy();
                }
                Values_Count--;
            }
        }
        public bool Set_Values(ArrayList values)
        {
            bool result = true;

            if (values != null && values.Count >= Values_Count)
            {
                for (int i = 0; i < Values_Count; i++)
                {
                    Values[i].Value = values[i].ToString();
                }
            }
            else result = false;
            return result;
        }
        public bool Set_Values(string[] values)
        {
            bool result = true;

            if (values.Length == Values_Count)
            {
                for (int i = 0; i < Values_Count; i++)
                {
                    Values[i].Value = values[i];
                }
            }
            else result = false;
            return result;
        }
        public void Swap_Value(ref TCommand_Value in1, ref TCommand_Value in2)
        {
            TCommand_Value tmp = new TCommand_Value();

            tmp = in1.Copy();
            in1 = in2.Copy();
            in2 = tmp.Copy();
        }
        public void Move_Up(int no)
        {
            if (no >= 1 && no < Values_Count)
            {
                Swap_Value(ref Values[no], ref Values[no - 1]);
            }
        }
        public void Move_Dn(int no)
        {
            if (no >= 0 && no < Values_Count - 1)
            {
                Swap_Value(ref Values[no], ref Values[no + 1]);
            }
        }
    }
    public class TCommand_Value
    {
        public emValue_Type Type;
        public string Name;
        public string Disp_String;
        public string Value;
        public string Default_Value;
        public ArrayList Combo_List = null;

        public TCommand_Value()
        {
            Set_Default();
        }
        public TCommand_Value(emValue_Type type, string name, string disp_string, string value, string default_value, ArrayList combo_list = null)
        {
            Set_Data(type, name, disp_string, value, default_value, combo_list);
        }
        public void Set_Default()
        {
            Type = emValue_Type.String;
            Name = "Default";
            Disp_String = "Disp_String";
            Value = "";
            Default_Value = "Default_Value";
            Combo_List = null;
        }
        public TCommand_Value Copy()
        {
            TCommand_Value result = new TCommand_Value();

            result.Type = Type;
            result.Name = Name;
            result.Disp_String = Disp_String;
            result.Value = Value;
            result.Default_Value = Default_Value;
            //result.In_Data = In_Data;
            result.Combo_List = Combo_List;
            return result;
        }
        public override string ToString()
        {
            string result = "";

            result = string.Format("{0:s},{1:s},{2:s},{3:s},{4:s}",
                                   Halcon_Tool.Get_Value_Type_String(Type), Name, Disp_String, Value, Default_Value);
            return result;
        }
        public void Set_Data(string str)
        {
            string[] list = null;

            Halcon_Tool.Break_String(str, ref list);
            if (list.Length == 5)
            {
                Type = Halcon_Tool.Get_Value_Type(list[0]);
                Name = list[1];
                Disp_String = list[2];
                Value = list[3];
                Default_Value = list[4];
            }
        }
        public void Set_Data(emValue_Type type, string name, string disp_string, string value, string default_value, ArrayList combo_list = null)
        {
            Type = type;
            Name = name;
            Disp_String = disp_string;
            Value = value;
            Default_Value = default_value;
            Combo_List = combo_list;
        }
    }
    //-----------------------------------------------------------------------------------------
    //--Halcon_Tool
    //-----------------------------------------------------------------------------------------
    public class TTool_Values
    {
        public TTool_Value_Region[] Values_Region = new TTool_Value_Region[0];
        public TTool_Value_Image[] Values_Image = new TTool_Value_Image[0];
        public TTool_Value_String[] Values_String = new TTool_Value_String[0];
        public TTool_Value_Integer[] Values_Integer = new TTool_Value_Integer[0];
        public TTool_Value_Double[] Values_Double = new TTool_Value_Double[0];

        public int Values_Region_Count
        {
            get
            {
                return Values_Region.Length;
            }
            set
            {
                int old_count = Values_Region.Length;
                Array.Resize(ref Values_Region, value);
                for(int i=old_count; i<value; i++)
                {
                    Values_Region[i] = new TTool_Value_Region();
                }
            }
        }
        public int Values_Image_Count
        {
            get
            {
                return Values_Image.Length;
            }
            set
            {
                int old_count = Values_Image.Length;
                Array.Resize(ref Values_Image, value);
                for (int i = old_count; i < value; i++)
                {
                    Values_Image[i] = new TTool_Value_Image();
                }
            }
        }
        public int Values_String_Count
        {
            get
            {
                return Values_String.Length;
            }
            set
            {
                int old_count = Values_String.Length;
                Array.Resize(ref Values_String, value);
                for (int i = old_count; i < value; i++)
                {
                    Values_String[i] = new TTool_Value_String();
                }
            }
        }
        public int Values_Integer_Count
        {
            get
            {
                return Values_Integer.Length;
            }
            set
            {
                int old_count = Values_Integer.Length;
                Array.Resize(ref Values_Integer, value);
                for (int i = old_count; i < value; i++)
                {
                    Values_Integer[i] = new TTool_Value_Integer();
                }
            }
        }
        public int Values_Double_Count
        {
            get
            {
                return Values_Double.Length;
            }
            set
            {
                int old_count = Values_Double.Length;
                Array.Resize(ref Values_Double, value);
                for (int i = old_count; i < value; i++)
                {
                    Values_Double[i] = new TTool_Value_Double();
                }
            }
        }
        public TTool_Values()
        {

        }
        public TTool_Values Copy()
        {
            TTool_Values result = new TTool_Values();

            result.Values_Region_Count = Values_Region_Count;
            for (int i = 0; i < Values_Region_Count; i++) result.Values_Region[i] = Values_Region[i].Copy();

            result.Values_Image_Count = Values_Image_Count;
            for (int i = 0; i < Values_Image_Count; i++) result.Values_Image[i] = Values_Image[i].Copy();

            result.Values_String_Count = Values_String_Count;
            for (int i = 0; i < Values_String_Count; i++) result.Values_String[i] = Values_String[i].Copy();

            result.Values_Integer_Count = Values_Integer_Count;
            for (int i = 0; i < Values_Integer_Count; i++) result.Values_Integer[i] = Values_Integer[i].Copy();

            result.Values_Double_Count = Values_Double_Count;
            for (int i = 0; i < Values_Double_Count; i++) result.Values_Double[i] = Values_Double[i].Copy();
            return result;
        }
        public void Reset()
        {
            Values_Region_Count = 0;
            Values_Image_Count = 0;
        }

        public ArrayList Get_Vlaue_Type_List()
        {
            ArrayList result = new ArrayList();

            result.Add("Region");
            result.Add("Image");
            result.Add("String");
            result.Add("Integer");
            result.Add("Double");
            return result;
        }
        public ArrayList Get_Value_Name_List(emValue_Type type)
        {
            ArrayList result = new ArrayList();

            result = Get_Value_Name_List(Halcon_Tool.Get_Value_Type_String(type));
            return result;
        }
        public ArrayList Get_Value_Name_List(string value_type)
        {
            ArrayList result = new ArrayList();

            switch (value_type)
            {
                case "Region": 
                    for (int i = 0; i < Values_Region_Count; i++ ) result.Add(Values_Region[i].Name);
                    break;

                case "Image":
                    for (int i = 0; i < Values_Image_Count; i++) result.Add(Values_Image[i].Name);
                    break;

                case "String":
                    for (int i = 0; i < Values_String_Count; i++) result.Add(Values_String[i].Name);
                    break;

                case "Integer":
                    for (int i = 0; i < Values_Integer_Count; i++) result.Add(Values_Integer[i].Name);
                    break;

                case "Double":
                    for (int i = 0; i < Values_Double_Count; i++) result.Add(Values_Double[i].Name);
                    break;
            }
            return result;
        }
        public int Find_Index(emValue_Type type, string name)
        {
            int result = -1;

            switch (type)
            {
                case emValue_Type.Region:
                    for (int i = 0; i < Values_Region_Count; i++)
                    {
                        if (name == Values_Region[i].Name) { result = i; break; }
                    }
                    break;

                case emValue_Type.Image:
                    for (int i = 0; i < Values_Image_Count; i++)
                    {
                        if (name == Values_Image[i].Name) { result = i; break; }
                    }
                    break;

                case emValue_Type.String:
                    for (int i = 0; i < Values_String_Count; i++)
                    {
                        if (name == Values_String[i].Name) { result = i; break; }
                    }
                    break;

                case emValue_Type.Integer:
                    for (int i = 0; i < Values_Integer_Count; i++)
                    {
                        if (name == Values_Integer[i].Name) { result = i; break; }
                    }
                    break;

                case emValue_Type.Double:
                    for (int i = 0; i < Values_Double_Count; i++)
                    {
                        if (name == Values_Double[i].Name) { result = i; break; }
                    }
                    break;
            }
            return result;
        }
        public TTool_Value_Base Get_Value(emValue_Type type, string name)
        {
            TTool_Value_Base result = null;
            int no = -1;

            if (Halcon_Tool.Is_Variable(name))
            {
                no = Find_Index(type, name);
                if (no >= 0)
                {
                    switch (type)
                    {
                        case emValue_Type.Region: result = Values_Region[no]; break;
                        case emValue_Type.Image: result = Values_Image[no]; break;
                        case emValue_Type.String: result = Values_String[no]; break;
                        case emValue_Type.Integer: result = Values_Integer[no]; break;
                        case emValue_Type.Double: result = Values_Double[no]; break;
                    }
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
        public HRegion Get_Value_Region(string name)
        {
            HRegion result = null;
            TTool_Value_Region obj;

            obj = (TTool_Value_Region)Get_Value(emValue_Type.Region, name);
            if (obj != null) result = obj.Value;
            return result;
        }
        public HImage Get_Value_Image(string name)
        {
            HImage result = null;
            TTool_Value_Image obj;

            obj = (TTool_Value_Image)Get_Value(emValue_Type.Image, name);
            if (obj != null) result = obj.Value;
            return result;
        }
        public string Get_Value_String(string name)
        {
            string result = "";
            TTool_Value_String obj;

            obj = (TTool_Value_String)Get_Value(emValue_Type.String, name);
            if (obj != null) result = obj.Value;
            return result;
        }
        public int Get_Value_Integer(string name)
        {
            int result = 0;
            TTool_Value_Integer obj;

            obj = (TTool_Value_Integer)Get_Value(emValue_Type.Integer, name);
            if (obj != null) result = obj.Value;
            return result;
        }
        public double Get_Value_Double(string name)
        {
            double result = 0.0;
            TTool_Value_Double obj;

            obj = (TTool_Value_Double)Get_Value(emValue_Type.Double, name);
            if (obj != null) result = obj.Value;
            return result;
        }
        public void Add_Name(TCommand_Values_List values_List)
        {
            for (int i = 0; i < values_List.Values_Count; i++ )
            {
                Add(values_List.Values[i].Type, values_List.Values[i].Name);
            }
        }
        public void Add_Value(TCommand_Values_List values_List)
        {
            for (int i = 0; i < values_List.Values_Count; i++)
            {
                Add(values_List.Values[i].Type, values_List.Values[i].Value);
            }
        }
        public void Add(TCommand_Values_List values_list)
        {
            for (int i = 0; i < values_list.Values_Count; i++)
            {
                Add(values_list.Values[i].Type, values_list.Values[i].Name);
            }
        }
        public void Add_In(TCommand_Define cmd, TTool_Values sor)
        {
            int no = -1;
            emValue_Type type;
            string sor_name, dis_name;

            for (int i = 0; i < cmd.In.Values_Count; i++)
            {
                type = cmd.In.Values[i].Type;
                sor_name = cmd.In.Values[i].Value;
                dis_name = cmd.In.Values[i].Name;
                if (Halcon_Tool.Is_Variable(sor_name)) 
                {
                    no = sor.Find_Index(type, sor_name);
                    if (no >= 0)
                    {
                        switch (type)
                        {
                            case emValue_Type.Region: Add_Region(dis_name, sor.Values_Region[no].Value); break;
                            case emValue_Type.Image: Add_Image(dis_name, sor.Values_Image[no].Value); break;
                            case emValue_Type.String: Add_String(dis_name, sor.Values_String[no].Value); break;
                            case emValue_Type.Integer: Add_Integer(dis_name, sor.Values_Integer[no].Value); break;
                            case emValue_Type.Double: Add_Double(dis_name, sor.Values_Double[no].Value); break;
                        }
                    }
                    else
                    {
                        switch (type)
                        {
                            case emValue_Type.Region: Add_Region(dis_name); break;
                            case emValue_Type.Image: Add_Image(dis_name); break;
                            case emValue_Type.String: Add_String(dis_name); break;
                            case emValue_Type.Integer: Add_Integer(dis_name); break;
                            case emValue_Type.Double: Add_Double(dis_name); break;
                        }
                    }
                }
                else
                {
                    switch (type)
                    {
                        case emValue_Type.String: Add_String(dis_name, sor_name); break;

                        case emValue_Type.Integer:
                            int data_i = 0;
                            try { data_i = Convert.ToInt32(sor_name); } catch { };
                            Add_Integer(dis_name, data_i); 
                            break;

                        case emValue_Type.Double: 
                            double data_d = 0;
                            try { data_d = Convert.ToDouble( sor_name); } catch { };
                            Add_Double(dis_name, data_d); 
                            break;
                    }
                }
            }
        }
        public void Add_Out(TCommand_Define cmd, TTool_Values sor)
        {
            int no;
            emValue_Type type;
            string sor_name, dis_name;

            for (int i = 0; i < cmd.Out.Values_Count; i++)
            {
                type = cmd.Out.Values[i].Type;
                sor_name = cmd.Out.Values[i].Name;
                dis_name = cmd.Out.Values[i].Value;
                if (Halcon_Tool.Is_Variable(sor_name))
                {
                    no = sor.Find_Index(type, sor_name);
                    if (no >= 0)
                    {
                        if (Halcon_Tool.Is_Variable(dis_name))
                        {
                            switch (type)
                            {
                                case emValue_Type.Region: Add_Region(dis_name, sor.Values_Region[no].Value); break;
                                case emValue_Type.Image: Add_Image(dis_name, sor.Values_Image[no].Value); break;
                                case emValue_Type.String: Add_String(dis_name, sor.Values_String[no].Value); break;
                                case emValue_Type.Integer: Add_Integer(dis_name, sor.Values_Integer[no].Value); break;
                                case emValue_Type.Double: Add_Double(dis_name, sor.Values_Double[no].Value); break;
                            }
                        }
                    }
                    else
                    {
                        switch (type)
                        {
                            case emValue_Type.Region: Add_Region(dis_name); break;
                            case emValue_Type.Image: Add_Image(dis_name); break;
                            case emValue_Type.String: Add_String(dis_name); break;
                            case emValue_Type.Integer: Add_Integer(dis_name); break;
                            case emValue_Type.Double: Add_Double(dis_name); break;
                        }
                    }
                }
                else
                {
                    switch (type)
                    {
                        case emValue_Type.String:  Add_String(dis_name, sor_name); break;
                        case emValue_Type.Integer: 
                            int data_i = 0;
                            try { data_i = Convert.ToInt32(sor_name); } catch { };
                            Add_Integer(dis_name, data_i); 
                            break;

                        case emValue_Type.Double:  
                            double data_d = 0;
                            try { data_d = Convert.ToDouble( sor_name); } catch { };
                            Add_Double(dis_name, data_d); 
                            break;
                    }
                }

            }
        }
        public TTool_Value_Base Add(emValue_Type type, string name)
        {
            TTool_Value_Base result = null;

            switch (type)
            {
                case emValue_Type.Region: result = Add_Region(name); break;
                case emValue_Type.Image: result = Add_Image(name); break;
                case emValue_Type.String: result = Add_String(name, ""); break;
                case emValue_Type.Integer: result = Add_Integer(name, 0); break;
                case emValue_Type.Double: result = Add_Double(name, 0.0); break;
            }
            return result;
        }
        public TTool_Value_Base Add(string name, HRegion region)
        {
            return Add_Region(name, region);
        }
        public TTool_Value_Base Add(string name, HImage image)
        {
            return Add_Image(name, image);
        }
        public TTool_Value_Base Add(string name, string value)
        {
            return Add_String(name, value);
        }
        public TTool_Value_Base Add(string name, int value)
        {
            return Add_Integer(name, value);
        }
        public TTool_Value_Base Add(string name, double value)
        {
            return Add_Double(name, value);
        }
        public TTool_Value_Base Add_Region(string name, HRegion region=null)
        {
            TTool_Value_Base result = null;
            int no = -1;

            no = Find_Index(emValue_Type.Region, name);
            if (no < 0)
            {
                no = Values_Region_Count;
                Values_Region_Count++;
            };

            Values_Region[no].Name = name;
            if (region != null) Values_Region[no].Value = region.Clone();
            result = Values_Region[no];
            return result;
        }
        public TTool_Value_Base Add_Image(string name, HImage image=null)
        {
            TTool_Value_Base result = null;
            int no = -1;

            no = Find_Index(emValue_Type.Image, name);
            if (no < 0)
            {
                no = Values_Image_Count;
                Values_Image_Count++;
            };

            Values_Image[no].Name = name;
            if (TJJS_Vision.Is_Not_Empty(image)) Values_Image[no].Value = image.Clone();
            result = Values_Image[no];
            return result;
        }
        public TTool_Value_Base Add_String(string name, string value="")
        {
            TTool_Value_Base result = null;
            int no = -1;

            no = Find_Index(emValue_Type.String, name);
            if (no < 0)
            {
                no = Values_String_Count;
                Values_String_Count++;
            };

            Values_String[no].Name = name;
            Values_String[no].Value = value;
            result = Values_String[no];
            return result;
        }
        public TTool_Value_Base Add_Integer(string name, int value=0)
        {
            TTool_Value_Base result = null;
            int no = -1;

            no = Find_Index(emValue_Type.Integer, name);
            if (no < 0)
            {
                no = Values_Integer_Count;
                Values_Integer_Count++;
            };

            Values_Integer[no].Name = name;
            Values_Integer[no].Value = value;
            result = Values_Integer[no];
            return result;
        }
        public TTool_Value_Base Add_Double(string name, double value=0.0)
        {
            TTool_Value_Base result = null;
            int no = -1;

            no = Find_Index(emValue_Type.Double, name);
            if (no < 0)
            {
                no = Values_Double_Count;
                Values_Double_Count++;
            };

            Values_Double[no].Name = name;
            Values_Double[no].Value = value;
            result = Values_Double[no];
            return result;
        }
        public bool Set_Region(int no, HRegion region)
        {
            bool result = false;

            if (no >= 0 && no < Values_Region_Count && region != null)
            {
                if (TJJS_Vision.Is_Not_Empty(region))
                {
                    Values_Region[no].Value = region.Clone();
                    result = true;
                }
            }
            return result;
        }
        public bool Set_Image(int no, HImage image)
        {
            bool result = false;

            if (no >= 0 && no < Values_Image_Count && image != null)
            {
                if (TJJS_Vision.Is_Not_Empty(image))
                {
                    Values_Image[no].Value = image.Clone();
                    result = true;
                }
            }
            return result;
        }
        public bool Set_String(int no, string value)
        {
            bool result = false;

            if (no >= 0 && no < Values_String_Count)
            {
                Values_String[no].Value = value;
                result = true;
            }
            return result;
        }
        public bool Set_Integer(int no, int value)
        {
            bool result = false;
            if (no >= 0 && no < Values_Integer_Count)
            {
                Values_Integer[no].Value = value;
                result = true;
            }
            return result;
        }
        public bool Set_Double(int no, double value)
        {
            bool result = false;
            if (no >= 0 && no < Values_Double_Count)
            {
                Values_Double[no].Value = value;
                result = true;
            }
            return result;
        }
        public bool Set_Region(string name, HRegion region)
        {
            bool result = false;

            result = Set_Region(Find_Index(emValue_Type.Region, name), region);
            return result;
        }
        public bool Set_Image(string name, HImage image)
        {
            bool result = false;

            result = Set_Image(Find_Index(emValue_Type.Image, name), image);
            return result;
        }
        public bool Set_String(string name, string value)
        {
            bool result = false;

            result = Set_String(Find_Index(emValue_Type.String, name), value);
            return result;
        }
        public bool Set_Integer(string name, int value)
        {
            bool result = false;

            result = Set_Integer(Find_Index(emValue_Type.Integer, name), value);
            return result;
        }
        public bool Set_Double(string name, double value)
        {
            bool result = false;

            result = Set_Double(Find_Index(emValue_Type.Double, name), value);
            return result;
        }
    }
    public class TTool_Value_Base
    {
        public string           Name = "";
        public emValue_Type     Value_Type = emValue_Type.String;

        public TTool_Value_Base()
        {
        }
    }
    public class TTool_Value_Region : TTool_Value_Base
    {
        public HRegion Value = new HRegion();

        public TTool_Value_Region()
        {
            Value_Type = emValue_Type.Region;
            Value.GenEmptyRegion();
        }
        public TTool_Value_Region Copy()
        {
            TTool_Value_Region result = new TTool_Value_Region();

            result.Name = Name;
            result.Value_Type = Value_Type;
            result.Value = Value.Clone();
            return result;
        }
    }
    public class TTool_Value_Image : TTool_Value_Base
    {
        public HImage Value = new HImage();

        public TTool_Value_Image()
        {
            Value_Type = emValue_Type.Image;
            Value.GenEmptyObj();
        }
        public TTool_Value_Image Copy()
        {
            TTool_Value_Image result = new TTool_Value_Image();

            result.Name = Name;
            result.Value_Type = Value_Type;
            result.Value = Value.Clone();
            return result;
        }
    }
    public class TTool_Value_String : TTool_Value_Base
    {
        public string Value = "";

        public TTool_Value_String()
        {
            Value_Type = emValue_Type.String;
            Value = "";
        }
        public TTool_Value_String Copy()
        {
            TTool_Value_String result = new TTool_Value_String();

            result.Name = Name;
            result.Value_Type = Value_Type;
            result.Value = Value;
            return result;
        }
    }
    public class TTool_Value_Integer : TTool_Value_Base
    {
        public int Value = 0;

        public TTool_Value_Integer()
        {
            Value_Type = emValue_Type.Integer;
            Value = 0;
        }
        public TTool_Value_Integer Copy()
        {
            TTool_Value_Integer result = new TTool_Value_Integer();

            result.Name = Name;
            result.Value_Type = Value_Type;
            result.Value = Value;
            return result;
        }
    }
    public class TTool_Value_Double : TTool_Value_Base
    {
        public double Value = 0.0;

        public TTool_Value_Double()
        {
            Value_Type = emValue_Type.Double;
            Value = 0.0;
        }
        public TTool_Value_Double Copy()
        {
            TTool_Value_Double result = new TTool_Value_Double();

            result.Name = Name;
            result.Value_Type = Value_Type;
            result.Value = Value;
            return result;
        }
    }
}
