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
        public static int           Cmd_Max_Count = 16;
        public TCommand_Define      Param = new TCommand_Define();
        public Command_Manager      CMD_Manager = new Command_Manager();
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
            JJS_HW.Init();
            Part.Set_Data(0, 0, 640, 480);
            PageControl_Tool.Tab_Page_Hide(tabControl1);
            LB_Program_Edit.Width = 2000;
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

            ////Param.Read(ini, tmp_section + "/Image_Pre_Process");
            //Param.In.Add(emValue_Type.Image, "In_Sample", "In_Sample", "", "", null);
            //Param.In.Add(emValue_Type.Image, "In_Golden_Min", "In_Golden_Min", "", "", null);
            //Param.In.Add(emValue_Type.Image, "In_Golden_Max", "In_Golden_Max", "", "", null);
            //Param.In.Add(emValue_Type.Image, "In_Golden_Avg", "In_Golden_Avg", "", "", null);
            //Param.In.Add(emValue_Type.Image, "In_Golden_Std", "In_Golden_Std", "", "", null);
            //Param.Out.Add(emValue_Type.Image, "Out_Image_Light", "Out_Image_Light", "", "", null);
            //Param.Out.Add(emValue_Type.Image, "Out_Image_Dark", "Out_Image_Dark", "", "", null);


            ////Param.Read(ini, tmp_section + "/Region_Process");
            //Param.In.Add(emValue_Type.Image, "In_Image_Light", "In_Image_Light", "", "", null);
            //Param.In.Add(emValue_Type.Image, "In_Image_Dark", "In_Image_Dark", "", "", null);
            //Param.In.Add(emValue_Type.Region, "In_Region", "In_Region", "", "", null);
            //Param.Out.Add(emValue_Type.Region, "Out_Region", "Out_Region", "", "", null);
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
            list = Value_Type.Get_List();
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

            if (JJS_Vision.Is_Not_Empty(image))
            {
                image.GetImageSize(out w, out h);
                Part.Set_Data(0, 0, w, h);
            }
        }
        public void Set_Param(TCommand_Define param)
        {
            Param.Set(param);
            Org_Tool_Values.Add_Value(param.In);
            Org_Tool_Values.Add_Value(param.Out);

            On_Setting = true;
            E_Password1.Text = Param.Password;
            E_Password2.Text = Param.Password;

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
                    dg.Rows[i].Cells[1].Value = Value_Type.Type_To_String(values[i].Type);
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
                    comp[i].L_Info.Text = Value_Type.Type_To_String(values_List.Values[i].Type); 
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
                default_name = Value_Type.Type_To_String(values_List.Values[i].Type);
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
            Run_Tool_Values.Set(Org_Tool_Values);
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
                    Last_Type = Value_Type.Type_To_String(value.Type);
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
                if (JJS_Vision.Is_Not_Empty(tmp_image))
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
                    Disp_Result(hw, tool_values, Value_Type.Type_To_String(value.Type), value.Name);
                }
            }
        }
        public void Disp_Result(HWindowControl hw, TTool_Values tool_values, string type, string name)
        {
            switch (type)
            {
                case "Region":
                    TTool_Value_Region value_region = null;

                    value_region = tool_values.Get_Tool_Value_Region(name);
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

                    value_image = tool_values.Get_Tool_Value_Image(name);
                    if (value_image != null && JJS_Vision.Is_Not_Empty(value_image.Value)) hw.HalconWindow.DispObj(value_image.Value);
                    break;

                case "XLD":
                    TTool_Value_XLD value_xld = null;

                    value_xld = tool_values.Get_Tool_Value_XLD(name);
                    if (value_xld != null && JJS_Vision.Is_Not_Empty(value_xld.Value)) hw.HalconWindow.DispObj(value_xld.Value);
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
            TCommand_Define cmd = null;

            no = LB_Program_Edit.SelectedIndex;
            if (no >= 0)
            {
                program_list = LB_Program_Edit.Items[no].ToString();
                if (!Halcon_Tool.Is_Comment(program_list))
                {
                    Update_Param();
                    cmd_no = Param.Get_User_Cmd_List_No(Halcon_Tool.Get_Program_Name(program_list));
                    if (cmd_no >= 0)
                    {
                        cmd = Param.User_Cmd_List[cmd_no];
                        if (cmd_no >= 0 && cmd.User_Define)
                        {
                            cmd.Set_Data(program_list);
                            Edit_User_Command(ref cmd);
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
                JJS_HW.Mode = emJJS_HW_Mode.None;
                JJS_HW.HW.Focus();
                JJS_HW.HW.HalconWindow.DrawPoint(out row, out col);
                tmp_region = Select_Region.SelectRegionPoint((int)Math.Round(row, 0), (int)Math.Round(col, 0));
                if (tmp_region.CountObj() == 1)
                {
                    region_info = JJS_Vision.Get_Region_Info(tmp_region);
                    region_info.Write(ini, "Default");
                    TJJS_XML_Tool.Display_TreeView(TV_Region_Info, ini);
                    TV_Region_Info.ExpandAll();
                }
                B_Get_Region_Info.BackColor = Color.Transparent;
            }
        }
        public bool Edit_User_Define(ref TCommand_Define cmd)
        {
            bool result = false;
            if (cmd.Password == "" || Input_Password.Check(cmd.Password))
            {
                TForm_User_Define form = new TForm_User_Define();

                form.Set_Param(cmd);
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    cmd.Set(form.Param);
                    result = true;
                }
            }
            return result;
        }
        public void Edit_User_Command(ref TCommand_Define cmd)
        {
            if (cmd.Password == "" || Input_Password.Check(cmd.Password))
            {
                TForm_Halcon_Tool form = new TForm_Halcon_Tool();
                form.Part = Part;
                form.Org_Tool_Values.Add_Value(cmd.In);
                form.Org_Tool_Values.Add_Value(cmd.Out);
                form.Org_Tool_Values.Set_Value_In(cmd.In, Run_Tool_Values);                
                form.Set_Param(cmd);
               
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (form.Param.Name == cmd.Name)
                    {
                        cmd.Set(form.Param);
                        Set_Param(Param);
                    }
                    else MessageBox.Show("函數名稱不能修改。", "錯誤", MessageBoxButtons.OK);
                }
            }
        }
        private void B_User_Cmd_New_Click(object sender, EventArgs e)
        {
            THalcon_Tool_File CMD_File = new THalcon_Tool_File();
            SaveFileDialog dialog = new SaveFileDialog();
            TCommand_Define select_cmd = null;
            string file_name = "";

            int no = LB_User_Commands_List.SelectedIndex;
            if (no >= 0)
            {
                select_cmd = Param.User_Cmd_List[no];
                dialog.Filter = "User Difine Command files (*.UDC)|*.UDC";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    file_name = dialog.FileName;
                    CMD_File.Read(file_name);
                    if (CMD_File.CMD.Get_User_Cmd_List(select_cmd.Name) == null)
                    {
                        CMD_File.CMD.Add_User_Cmd_List(select_cmd);
                        CMD_File.Write(file_name);
                    }
                    else
                        MessageBox.Show("函數名稱重複，無法。", "錯誤", MessageBoxButtons.OK);
                }
            }
        }
        private void B_User_Cmd_Export_Click(object sender, EventArgs e)
        {
            THalcon_Tool_File CMD_File = new THalcon_Tool_File();
            OpenFileDialog dialog = new OpenFileDialog();
            TCommand_Define select_cmd = null;
            string file_name = "";

            int no = LB_User_Commands_List.SelectedIndex;
            if (no >= 0)
            {
                select_cmd = Param.User_Cmd_List[no];
                dialog.Filter = "User Difine Command files (*.UDC)|*.UDC";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    file_name = dialog.FileName;
                    CMD_File.Read(file_name);
                    if(CMD_File.CMD.Get_User_Cmd_List(select_cmd.Name) == null)
                    {
                        CMD_File.CMD.Add_User_Cmd_List(select_cmd);
                        CMD_File.Write(file_name);
                    }
                    else
                        MessageBox.Show("函數名稱重複，無法。", "錯誤", MessageBoxButtons.OK);
                }
            }
        }
        private void B_User_Cmd_Inport_Click(object sender, EventArgs e)
        {
            TForm_Inport_CMD form = new TForm_Inport_CMD();
            OpenFileDialog dialog = new OpenFileDialog();
            TCommand_Define tmp_cmd = null;

            dialog.Filter = "User Difine Command files (*.UDC)|*.UDC";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                form.Set_Param(dialog.FileName);
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
            TCommand_Define cmd = null;
            string cmd_name = "Default";

            if (Input_CMD_Name.Input(ref cmd_name))
            {
                if (CMD_Manager.Get_Command(cmd_name) == null)
                {
                    cmd = new TCommand_Define();
                    cmd.Name = cmd_name;
                    Param.Add_User_Cmd_List(cmd);
                    Edit_User_Command(ref cmd);
                }
                else
                    MessageBox.Show("函數名稱重複，無法新增。", "錯誤", MessageBoxButtons.OK);
                Set_Param(Param);
            }
        }
        private void B_User_Cmd_Edit_Click(object sender, EventArgs e)
        {
            int no = LB_User_Commands_List.SelectedIndex;
            TCommand_Define cmd = null;

            if (no >= 0)
            {
                Update_Param();
                cmd = Param.User_Cmd_List[no];
                if (Edit_User_Define(ref cmd))
                {
                    Set_Param(Param);
                }
            }
        }
        private void B_User_Cmd_Edit_Name_Click(object sender, EventArgs e)
        {
            int no = LB_User_Commands_List.SelectedIndex;
            TCommand_Define cmd = null;
            string cmd_name = "";

            if (no >= 0)
            {
                Update_Param();
                cmd = Param.User_Cmd_List[no];
                if (cmd.Password == "" || Input_Password.Check(cmd.Password))
                {
                    cmd_name = cmd.Name;
                    if (Input_CMD_Name.Input(ref cmd_name))
                    {
                        if (cmd_name != cmd.Name)
                        {
                            if (CMD_Manager.Get_Command(cmd_name) == null)
                            {
                                cmd.Name = cmd_name;
                                Set_Param(Param);
                            }
                            else
                                MessageBox.Show("函數名稱重複，無法新增。", "錯誤", MessageBoxButtons.OK);
                            Set_Param(Param);
                        }
                    }
                }
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
        private void LB_User_Commands_List_DoubleClick(object sender, EventArgs e)
        {
            int no = 0;
            TCommand_Define cmd = null;

            no = LB_User_Commands_List.SelectedIndex;
            if (no >= 0 && no < Param.User_Cmd_List_Count)
            {
                Update_Param();
                cmd = Param.User_Cmd_List[no];
                Edit_User_Command(ref cmd);
            }
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


        public void Swap_Value(TCommand_Value in1, TCommand_Value in2)
        {
            TCommand_Value tmp = new TCommand_Value();

            tmp.Set(in1);
            in1.Set(in2);
            in2.Set(tmp);
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
                    Swap_Value(Param.In.Values[no], Param.In.Values[no - 1]);
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
                    Swap_Value(Param.In.Values[no], Param.In.Values[no + 1]);
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
            Param.In.Values[Param.In.Values_Count - 1].Name = "Default" + Param.In.Values_Count.ToString();
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
                    Swap_Value(Param.Out.Values[no], Param.Out.Values[no - 1]);
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
                    Swap_Value(Param.Out.Values[no], Param.Out.Values[no + 1]);
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
            Param.Out.Values[Param.Out.Values_Count - 1].Name = "Default" + Param.Out.Values_Count.ToString();
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

                    value_region = (TTool_Value_Region)Run_Tool_Values.Get_Base_Value(emValue_Type.Region, Last_Name);
                    if (value_region != null)
                    {
                    }
                    else
                        Select_Region = null;
                    break;

                case "Image":
                    TTool_Value_Image value_image = null;

                    value_image = (TTool_Value_Image)Run_Tool_Values.Get_Base_Value(emValue_Type.Image, Last_Name);
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
        private void tFrame_JJS_HW1_JJS_HW_Reflash(TFrame_JJS_HW jjs_hw)
        {
            Disp_Result();
        }
        private void B_Change_Password_Click(object sender, EventArgs e)
        {
            if (E_Password1.Text == E_Password2.Text)
            {
                Param.Password = E_Password1.Text;
            }
        }
    }
    public struct stCMD_Component
    {
        public Label L_Name;
        public Label L_Info;
        public ComboBox CB_Value;
    }
}
