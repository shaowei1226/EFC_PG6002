namespace Main
{
    partial class TForm_Select_Recipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Select_Recipe));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.Tray");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("1.外型");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("2.Mark參數");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("3.尺寸限制");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("4.補正量");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("2.PCB", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Home");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Tray_取料");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Plasma_取料");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Plasma_放料");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("ACF_放料");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("ACF_取料");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("PCB_Load");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("PCB_Unload");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("NG");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Teach");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Robot", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("1.壓合參數");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("2.位置參數");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("3.ACF貼附", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("4.機械參數");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("5.Plasma");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode6,
            treeNode17,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Tool_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PM_Used = new System.Windows.Forms.ToolStripMenuItem();
            this.PM_Golden = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TV_Menu = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.B_Update_Tree = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Space = new System.Windows.Forms.TabPage();
            this.TP_Tray = new System.Windows.Forms.TabPage();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label104 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.E_Tray_Num_X = new System.Windows.Forms.TextBox();
            this.E_Tray_Pitch_X = new System.Windows.Forms.TextBox();
            this.E_Tray_Start_X = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.E_Tray_Num_Y = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.E_Tray_Pitch_Y = new System.Windows.Forms.TextBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.E_Tray_Start_Y = new System.Windows.Forms.TextBox();
            this.label102 = new System.Windows.Forms.Label();
            this.TP_Size = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.E_Panel_Z = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.E_Panel_Y = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.E_Panel_X = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.TP_COF_Mark = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.B_E_COF_Mark_R_Edit = new System.Windows.Forms.Button();
            this.B_E_COF_Mark_R_Light = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.B_E_COF_Mark_L_Edit = new System.Windows.Forms.Button();
            this.B_E_COF_Mark_L_Light = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.E_COF_Mark_R_Y = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.E_COF_Mark_R_X = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.E_COF_Mark_L_Y = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.E_COF_Mark_L_X = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.TP_Limit = new System.Windows.Forms.TabPage();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.CB_Limit_Length_SW = new System.Windows.Forms.CheckBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.E_Limit_Length_Max = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.E_Limit_Length_Min = new System.Windows.Forms.TextBox();
            this.TP_Ofs = new System.Windows.Forms.TabPage();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.E_Ofs_Q = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.E_Ofs_Y = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.E_Ofs_X = new System.Windows.Forms.TextBox();
            this.TP_ACF_Bond = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label60 = new System.Windows.Forms.Label();
            this.E_ACF_Press3 = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.E_ACF_Press2 = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_ACF_SW = new System.Windows.Forms.CheckBox();
            this.E_ACF_Press1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.E_ACF_Temp_Dn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.E_ACF_Temp_Up = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.E_ACF_Time = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TP_ACF_Pos = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.DG_ACF_Pos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel12 = new System.Windows.Forms.Panel();
            this.B_ACF_Pos_Move_Dn = new System.Windows.Forms.Button();
            this.B_ACF_Pos_Move_Up = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.E_ACF_Row_No = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.E_Check_Pitch = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.E_ACF_Length = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.B_ACF_Check_L_Copy = new System.Windows.Forms.Button();
            this.label86 = new System.Windows.Forms.Label();
            this.CB_ACF_Pos_Count = new System.Windows.Forms.ComboBox();
            this.TP_MS_Param = new System.Windows.Forms.TabPage();
            this.B_Edit_MS_Param = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DG_Robot_Pos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.點位敘述 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.B_Robot_Pos_Get = new System.Windows.Forms.Button();
            this.B_Robot_Pos_Move_Dn = new System.Windows.Forms.Button();
            this.B_Robot_Pos_Move_Up = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.speedbox = new System.Windows.Forms.TextBox();
            this.BTN_setspeed = new System.Windows.Forms.Button();
            this.CB_Robot_Pos_Start_No = new System.Windows.Forms.TextBox();
            this.B_Robot_Manager = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.B_Robot_Pos_Write = new System.Windows.Forms.Button();
            this.B_Robot_Pos_Read = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.CB_Robot_Pos_Count = new System.Windows.Forms.ComboBox();
            this.Plasma = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_Plasma_Clean_Count = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.E_Plasma_Clean_Speed = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LB_Tree_Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Recipe_Code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Recipe_Info = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Recipe_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Plasma_Clean_Speed = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.B_Save_As = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Tray.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.TP_Size.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.TP_COF_Mark.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.TP_Limit.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.TP_Ofs.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.TP_ACF_Bond.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.TP_ACF_Pos.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_ACF_Pos)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.TP_MS_Param.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Robot_Pos)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.Plasma.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Plasma_Clean_Speed.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "019.bmp");
            this.imageList1.Images.SetKeyName(1, "No-02.bmp");
            this.imageList1.Images.SetKeyName(2, "Yes-01.bmp");
            // 
            // Tool_ImageList
            // 
            this.Tool_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Tool_ImageList.ImageStream")));
            this.Tool_ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.Tool_ImageList.Images.SetKeyName(0, "magic_wand.bmp");
            this.Tool_ImageList.Images.SetKeyName(1, "button_cross.bmp");
            this.Tool_ImageList.Images.SetKeyName(2, "hard_drive_download.bmp");
            this.Tool_ImageList.Images.SetKeyName(3, "hard_drive_upload.bmp");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PM_Used,
            this.PM_Golden});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // PM_Used
            // 
            this.PM_Used.Name = "PM_Used";
            this.PM_Used.Size = new System.Drawing.Size(116, 22);
            this.PM_Used.Text = "Used";
            // 
            // PM_Golden
            // 
            this.PM_Golden.Name = "PM_Golden";
            this.PM_Golden.Size = new System.Drawing.Size(116, 22);
            this.PM_Golden.Text = "Golden";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1434, 700);
            this.splitContainer1.SplitterDistance = 1307;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 137);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel5);
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel2.Controls.Add(this.panel8);
            this.splitContainer2.Size = new System.Drawing.Size(1307, 563);
            this.splitContainer2.SplitterDistance = 321;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TV_Menu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 55);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(321, 508);
            this.panel5.TabIndex = 2;
            // 
            // TV_Menu
            // 
            this.TV_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Menu.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TV_Menu.ImageIndex = 0;
            this.TV_Menu.ImageList = this.imageList1;
            this.TV_Menu.Indent = 32;
            this.TV_Menu.ItemHeight = 32;
            this.TV_Menu.Location = new System.Drawing.Point(0, 0);
            this.TV_Menu.Margin = new System.Windows.Forms.Padding(2);
            this.TV_Menu.Name = "TV_Menu";
            treeNode1.Name = "Tray";
            treeNode1.Text = "1.Tray";
            treeNode2.Name = "Size";
            treeNode2.Text = "1.外型";
            treeNode3.Name = "Model";
            treeNode3.Text = "2.Mark參數";
            treeNode4.Name = "Limit";
            treeNode4.Text = "3.尺寸限制";
            treeNode5.Name = "Ofs";
            treeNode5.Text = "4.補正量";
            treeNode6.Name = "PCB";
            treeNode6.Text = "2.PCB";
            treeNode7.Name = "Robot_Home";
            treeNode7.Text = "Home";
            treeNode8.Name = "Robot_Tray";
            treeNode8.Text = "Tray_取料";
            treeNode9.Name = "Plasma_Load";
            treeNode9.Text = "Plasma_取料";
            treeNode10.Name = "Plasma_Unload";
            treeNode10.Text = "Plasma_放料";
            treeNode11.Name = "ACF_Load";
            treeNode11.Text = "ACF_放料";
            treeNode12.Name = "ACF_Unload";
            treeNode12.Text = "ACF_取料";
            treeNode13.Name = "PCB_Load";
            treeNode13.Text = "PCB_Load";
            treeNode14.Name = "PCB_Unload";
            treeNode14.Text = "PCB_Unload";
            treeNode15.Name = "NG";
            treeNode15.Text = "NG";
            treeNode16.Name = "Teach";
            treeNode16.Text = "Teach";
            treeNode17.Name = "Robot";
            treeNode17.Text = "Robot";
            treeNode18.Name = "Bond";
            treeNode18.Text = "1.壓合參數";
            treeNode19.Name = "Pos";
            treeNode19.Text = "2.位置參數";
            treeNode20.Name = "ACF";
            treeNode20.Text = "3.ACF貼附";
            treeNode21.Name = "MS_Param";
            treeNode21.Text = "4.機械參數";
            treeNode22.Name = "Plasma";
            treeNode22.Text = "5.Plasma";
            treeNode23.Name = "Root";
            treeNode23.Text = "Root";
            this.TV_Menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23});
            this.TV_Menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TV_Menu.SelectedImageIndex = 0;
            this.TV_Menu.ShowNodeToolTips = true;
            this.TV_Menu.Size = new System.Drawing.Size(321, 508);
            this.TV_Menu.TabIndex = 1;
            this.TV_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Menu_AfterSelect_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.B_Update_Tree);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 55);
            this.panel4.TabIndex = 1;
            // 
            // B_Update_Tree
            // 
            this.B_Update_Tree.BackColor = System.Drawing.Color.LimeGreen;
            this.B_Update_Tree.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Update_Tree.Location = new System.Drawing.Point(46, 7);
            this.B_Update_Tree.Margin = new System.Windows.Forms.Padding(2);
            this.B_Update_Tree.Name = "B_Update_Tree";
            this.B_Update_Tree.Size = new System.Drawing.Size(148, 42);
            this.B_Update_Tree.TabIndex = 0;
            this.B_Update_Tree.Text = "更新狀態";
            this.B_Update_Tree.UseVisualStyleBackColor = false;
            this.B_Update_Tree.Click += new System.EventHandler(this.B_Update_Tree_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Space);
            this.tabControl1.Controls.Add(this.TP_Tray);
            this.tabControl1.Controls.Add(this.TP_Size);
            this.tabControl1.Controls.Add(this.TP_COF_Mark);
            this.tabControl1.Controls.Add(this.TP_Limit);
            this.tabControl1.Controls.Add(this.TP_Ofs);
            this.tabControl1.Controls.Add(this.TP_ACF_Bond);
            this.tabControl1.Controls.Add(this.TP_ACF_Pos);
            this.tabControl1.Controls.Add(this.TP_MS_Param);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.Plasma);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.ItemSize = new System.Drawing.Size(72, 0);
            this.tabControl1.Location = new System.Drawing.Point(0, 57);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(983, 506);
            this.tabControl1.TabIndex = 2;
            // 
            // TP_Space
            // 
            this.TP_Space.Location = new System.Drawing.Point(4, 24);
            this.TP_Space.Name = "TP_Space";
            this.TP_Space.Size = new System.Drawing.Size(975, 478);
            this.TP_Space.TabIndex = 21;
            this.TP_Space.Text = "空白";
            this.TP_Space.UseVisualStyleBackColor = true;
            // 
            // TP_Tray
            // 
            this.TP_Tray.Controls.Add(this.groupBox21);
            this.TP_Tray.Location = new System.Drawing.Point(4, 24);
            this.TP_Tray.Name = "TP_Tray";
            this.TP_Tray.Size = new System.Drawing.Size(975, 478);
            this.TP_Tray.TabIndex = 48;
            this.TP_Tray.Text = "Tray";
            this.TP_Tray.UseVisualStyleBackColor = true;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label104);
            this.groupBox21.Controls.Add(this.label103);
            this.groupBox21.Controls.Add(this.E_Tray_Num_X);
            this.groupBox21.Controls.Add(this.E_Tray_Pitch_X);
            this.groupBox21.Controls.Add(this.E_Tray_Start_X);
            this.groupBox21.Controls.Add(this.label87);
            this.groupBox21.Controls.Add(this.E_Tray_Num_Y);
            this.groupBox21.Controls.Add(this.label93);
            this.groupBox21.Controls.Add(this.label95);
            this.groupBox21.Controls.Add(this.E_Tray_Pitch_Y);
            this.groupBox21.Controls.Add(this.label96);
            this.groupBox21.Controls.Add(this.label101);
            this.groupBox21.Controls.Add(this.E_Tray_Start_Y);
            this.groupBox21.Controls.Add(this.label102);
            this.groupBox21.Location = new System.Drawing.Point(22, 19);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(306, 145);
            this.groupBox21.TabIndex = 4;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "[ 外觀尺寸 ]";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(210, 20);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(17, 14);
            this.label104.TabIndex = 19;
            this.label104.Text = "Y";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(125, 20);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(17, 14);
            this.label103.TabIndex = 18;
            this.label103.Text = "X";
            // 
            // E_Tray_Num_X
            // 
            this.E_Tray_Num_X.Location = new System.Drawing.Point(93, 98);
            this.E_Tray_Num_X.Name = "E_Tray_Num_X";
            this.E_Tray_Num_X.Size = new System.Drawing.Size(76, 24);
            this.E_Tray_Num_X.TabIndex = 17;
            this.E_Tray_Num_X.Text = "123";
            this.E_Tray_Num_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.E_Tray_Num_X.TextChanged += new System.EventHandler(this.E_Tray_Num_X_TextChanged);
            // 
            // E_Tray_Pitch_X
            // 
            this.E_Tray_Pitch_X.Location = new System.Drawing.Point(93, 68);
            this.E_Tray_Pitch_X.Name = "E_Tray_Pitch_X";
            this.E_Tray_Pitch_X.Size = new System.Drawing.Size(76, 24);
            this.E_Tray_Pitch_X.TabIndex = 16;
            this.E_Tray_Pitch_X.Text = "123.456";
            this.E_Tray_Pitch_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Tray_Start_X
            // 
            this.E_Tray_Start_X.Location = new System.Drawing.Point(93, 38);
            this.E_Tray_Start_X.Name = "E_Tray_Start_X";
            this.E_Tray_Start_X.Size = new System.Drawing.Size(76, 24);
            this.E_Tray_Start_X.TabIndex = 15;
            this.E_Tray_Start_X.Text = "123.456";
            this.E_Tray_Start_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(269, 103);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(25, 14);
            this.label87.TabIndex = 14;
            this.label87.Text = "PC";
            // 
            // E_Tray_Num_Y
            // 
            this.E_Tray_Num_Y.Location = new System.Drawing.Point(187, 98);
            this.E_Tray_Num_Y.Name = "E_Tray_Num_Y";
            this.E_Tray_Num_Y.Size = new System.Drawing.Size(76, 24);
            this.E_Tray_Num_Y.TabIndex = 12;
            this.E_Tray_Num_Y.Text = "123";
            this.E_Tray_Num_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(20, 103);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(37, 14);
            this.label93.TabIndex = 13;
            this.label93.Text = "數量";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(269, 73);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(29, 14);
            this.label95.TabIndex = 11;
            this.label95.Text = "mm";
            // 
            // E_Tray_Pitch_Y
            // 
            this.E_Tray_Pitch_Y.Location = new System.Drawing.Point(187, 68);
            this.E_Tray_Pitch_Y.Name = "E_Tray_Pitch_Y";
            this.E_Tray_Pitch_Y.Size = new System.Drawing.Size(76, 24);
            this.E_Tray_Pitch_Y.TabIndex = 9;
            this.E_Tray_Pitch_Y.Text = "123.456";
            this.E_Tray_Pitch_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(20, 73);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(37, 14);
            this.label96.TabIndex = 10;
            this.label96.Text = "間距";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(269, 43);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(29, 14);
            this.label101.TabIndex = 8;
            this.label101.Text = "mm";
            // 
            // E_Tray_Start_Y
            // 
            this.E_Tray_Start_Y.Location = new System.Drawing.Point(187, 38);
            this.E_Tray_Start_Y.Name = "E_Tray_Start_Y";
            this.E_Tray_Start_Y.Size = new System.Drawing.Size(76, 24);
            this.E_Tray_Start_Y.TabIndex = 6;
            this.E_Tray_Start_Y.Text = "123.456";
            this.E_Tray_Start_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(20, 43);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(67, 14);
            this.label102.TabIndex = 7;
            this.label102.Text = "起始位置";
            // 
            // TP_Size
            // 
            this.TP_Size.Controls.Add(this.groupBox5);
            this.TP_Size.Location = new System.Drawing.Point(4, 24);
            this.TP_Size.Name = "TP_Size";
            this.TP_Size.Size = new System.Drawing.Size(975, 478);
            this.TP_Size.TabIndex = 47;
            this.TP_Size.Text = "外型尺寸";
            this.TP_Size.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.E_Panel_Z);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.E_Panel_Y);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.E_Panel_X);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Location = new System.Drawing.Point(19, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(186, 126);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "[ 外觀尺寸 ]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(140, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "mm";
            // 
            // E_Panel_Z
            // 
            this.E_Panel_Z.Location = new System.Drawing.Point(58, 87);
            this.E_Panel_Z.Name = "E_Panel_Z";
            this.E_Panel_Z.Size = new System.Drawing.Size(76, 24);
            this.E_Panel_Z.TabIndex = 12;
            this.E_Panel_Z.Text = "123.456";
            this.E_Panel_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "Z";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(140, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "mm";
            // 
            // E_Panel_Y
            // 
            this.E_Panel_Y.Location = new System.Drawing.Point(58, 57);
            this.E_Panel_Y.Name = "E_Panel_Y";
            this.E_Panel_Y.Size = new System.Drawing.Size(76, 24);
            this.E_Panel_Y.TabIndex = 9;
            this.E_Panel_Y.Text = "123.456";
            this.E_Panel_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 14);
            this.label9.TabIndex = 10;
            this.label9.Text = "Y";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(140, 28);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 14);
            this.label23.TabIndex = 8;
            this.label23.Text = "mm";
            // 
            // E_Panel_X
            // 
            this.E_Panel_X.Location = new System.Drawing.Point(58, 26);
            this.E_Panel_X.Name = "E_Panel_X";
            this.E_Panel_X.Size = new System.Drawing.Size(76, 24);
            this.E_Panel_X.TabIndex = 6;
            this.E_Panel_X.Text = "123.456";
            this.E_Panel_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(20, 28);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 14);
            this.label24.TabIndex = 7;
            this.label24.Text = "X";
            // 
            // TP_COF_Mark
            // 
            this.TP_COF_Mark.Controls.Add(this.groupBox15);
            this.TP_COF_Mark.Controls.Add(this.groupBox9);
            this.TP_COF_Mark.Controls.Add(this.groupBox6);
            this.TP_COF_Mark.Controls.Add(this.groupBox4);
            this.TP_COF_Mark.Location = new System.Drawing.Point(4, 24);
            this.TP_COF_Mark.Name = "TP_COF_Mark";
            this.TP_COF_Mark.Size = new System.Drawing.Size(975, 478);
            this.TP_COF_Mark.TabIndex = 37;
            this.TP_COF_Mark.Text = "COF_Mark";
            this.TP_COF_Mark.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.B_E_COF_Mark_R_Edit);
            this.groupBox15.Controls.Add(this.B_E_COF_Mark_R_Light);
            this.groupBox15.Location = new System.Drawing.Point(207, 117);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(174, 121);
            this.groupBox15.TabIndex = 20;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "[ 右Mark ]";
            // 
            // B_E_COF_Mark_R_Edit
            // 
            this.B_E_COF_Mark_R_Edit.BackColor = System.Drawing.Color.LimeGreen;
            this.B_E_COF_Mark_R_Edit.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_E_COF_Mark_R_Edit.Location = new System.Drawing.Point(25, 22);
            this.B_E_COF_Mark_R_Edit.Margin = new System.Windows.Forms.Padding(2);
            this.B_E_COF_Mark_R_Edit.Name = "B_E_COF_Mark_R_Edit";
            this.B_E_COF_Mark_R_Edit.Size = new System.Drawing.Size(144, 42);
            this.B_E_COF_Mark_R_Edit.TabIndex = 17;
            this.B_E_COF_Mark_R_Edit.Text = "編輯標靶";
            this.B_E_COF_Mark_R_Edit.UseVisualStyleBackColor = false;
            this.B_E_COF_Mark_R_Edit.Click += new System.EventHandler(this.B_E_COF_Mark_R_Edit_Click);
            // 
            // B_E_COF_Mark_R_Light
            // 
            this.B_E_COF_Mark_R_Light.BackColor = System.Drawing.Color.LimeGreen;
            this.B_E_COF_Mark_R_Light.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_E_COF_Mark_R_Light.Location = new System.Drawing.Point(25, 68);
            this.B_E_COF_Mark_R_Light.Margin = new System.Windows.Forms.Padding(2);
            this.B_E_COF_Mark_R_Light.Name = "B_E_COF_Mark_R_Light";
            this.B_E_COF_Mark_R_Light.Size = new System.Drawing.Size(144, 42);
            this.B_E_COF_Mark_R_Light.TabIndex = 18;
            this.B_E_COF_Mark_R_Light.Text = "設定光源";
            this.B_E_COF_Mark_R_Light.UseVisualStyleBackColor = false;
            this.B_E_COF_Mark_R_Light.Click += new System.EventHandler(this.B_E_COF_Mark_R_Light_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.B_E_COF_Mark_L_Edit);
            this.groupBox9.Controls.Add(this.B_E_COF_Mark_L_Light);
            this.groupBox9.Location = new System.Drawing.Point(18, 117);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(174, 121);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "[ 左Mark ]";
            // 
            // B_E_COF_Mark_L_Edit
            // 
            this.B_E_COF_Mark_L_Edit.BackColor = System.Drawing.Color.LimeGreen;
            this.B_E_COF_Mark_L_Edit.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_E_COF_Mark_L_Edit.Location = new System.Drawing.Point(14, 22);
            this.B_E_COF_Mark_L_Edit.Margin = new System.Windows.Forms.Padding(2);
            this.B_E_COF_Mark_L_Edit.Name = "B_E_COF_Mark_L_Edit";
            this.B_E_COF_Mark_L_Edit.Size = new System.Drawing.Size(140, 42);
            this.B_E_COF_Mark_L_Edit.TabIndex = 15;
            this.B_E_COF_Mark_L_Edit.Text = "編輯標靶";
            this.B_E_COF_Mark_L_Edit.UseVisualStyleBackColor = false;
            this.B_E_COF_Mark_L_Edit.Click += new System.EventHandler(this.B_E_COF_Mark_L_Edit_Click);
            // 
            // B_E_COF_Mark_L_Light
            // 
            this.B_E_COF_Mark_L_Light.BackColor = System.Drawing.Color.LimeGreen;
            this.B_E_COF_Mark_L_Light.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_E_COF_Mark_L_Light.Location = new System.Drawing.Point(14, 68);
            this.B_E_COF_Mark_L_Light.Margin = new System.Windows.Forms.Padding(2);
            this.B_E_COF_Mark_L_Light.Name = "B_E_COF_Mark_L_Light";
            this.B_E_COF_Mark_L_Light.Size = new System.Drawing.Size(140, 42);
            this.B_E_COF_Mark_L_Light.TabIndex = 16;
            this.B_E_COF_Mark_L_Light.Text = "設定光源";
            this.B_E_COF_Mark_L_Light.UseVisualStyleBackColor = false;
            this.B_E_COF_Mark_L_Light.Click += new System.EventHandler(this.B_E_COF_Mark_L_Light_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.E_COF_Mark_R_Y);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.E_COF_Mark_R_X);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Location = new System.Drawing.Point(207, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(174, 89);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "[ 右Mark位置 ]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(140, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 14);
            this.label17.TabIndex = 11;
            this.label17.Text = "mm";
            // 
            // E_COF_Mark_R_Y
            // 
            this.E_COF_Mark_R_Y.Location = new System.Drawing.Point(58, 57);
            this.E_COF_Mark_R_Y.Name = "E_COF_Mark_R_Y";
            this.E_COF_Mark_R_Y.Size = new System.Drawing.Size(76, 24);
            this.E_COF_Mark_R_Y.TabIndex = 9;
            this.E_COF_Mark_R_Y.Text = "123.456";
            this.E_COF_Mark_R_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(22, 60);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 14);
            this.label18.TabIndex = 10;
            this.label18.Text = "Y";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(140, 28);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 14);
            this.label31.TabIndex = 8;
            this.label31.Text = "mm";
            // 
            // E_COF_Mark_R_X
            // 
            this.E_COF_Mark_R_X.Location = new System.Drawing.Point(58, 26);
            this.E_COF_Mark_R_X.Name = "E_COF_Mark_R_X";
            this.E_COF_Mark_R_X.Size = new System.Drawing.Size(76, 24);
            this.E_COF_Mark_R_X.TabIndex = 6;
            this.E_COF_Mark_R_X.Text = "123.456";
            this.E_COF_Mark_R_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(22, 28);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(17, 14);
            this.label32.TabIndex = 7;
            this.label32.Text = "X";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.E_COF_Mark_L_Y);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.E_COF_Mark_L_X);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Location = new System.Drawing.Point(18, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(174, 89);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[ 左Mark位置 ]";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(140, 60);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 14);
            this.label27.TabIndex = 11;
            this.label27.Text = "mm";
            // 
            // E_COF_Mark_L_Y
            // 
            this.E_COF_Mark_L_Y.Location = new System.Drawing.Point(58, 57);
            this.E_COF_Mark_L_Y.Name = "E_COF_Mark_L_Y";
            this.E_COF_Mark_L_Y.Size = new System.Drawing.Size(76, 24);
            this.E_COF_Mark_L_Y.TabIndex = 9;
            this.E_COF_Mark_L_Y.Text = "123.456";
            this.E_COF_Mark_L_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(22, 60);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 14);
            this.label28.TabIndex = 10;
            this.label28.Text = "Y";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(140, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 14);
            this.label29.TabIndex = 8;
            this.label29.Text = "mm";
            // 
            // E_COF_Mark_L_X
            // 
            this.E_COF_Mark_L_X.Location = new System.Drawing.Point(58, 26);
            this.E_COF_Mark_L_X.Name = "E_COF_Mark_L_X";
            this.E_COF_Mark_L_X.Size = new System.Drawing.Size(76, 24);
            this.E_COF_Mark_L_X.TabIndex = 6;
            this.E_COF_Mark_L_X.Text = "123.456";
            this.E_COF_Mark_L_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(22, 28);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 14);
            this.label30.TabIndex = 7;
            this.label30.Text = "X";
            // 
            // TP_Limit
            // 
            this.TP_Limit.Controls.Add(this.groupBox24);
            this.TP_Limit.Location = new System.Drawing.Point(4, 24);
            this.TP_Limit.Name = "TP_Limit";
            this.TP_Limit.Size = new System.Drawing.Size(975, 478);
            this.TP_Limit.TabIndex = 41;
            this.TP_Limit.Text = "Limit";
            this.TP_Limit.UseVisualStyleBackColor = true;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.CB_Limit_Length_SW);
            this.groupBox24.Controls.Add(this.label89);
            this.groupBox24.Controls.Add(this.label90);
            this.groupBox24.Controls.Add(this.E_Limit_Length_Max);
            this.groupBox24.Controls.Add(this.label91);
            this.groupBox24.Controls.Add(this.E_Limit_Length_Min);
            this.groupBox24.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox24.Location = new System.Drawing.Point(16, 18);
            this.groupBox24.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox24.Size = new System.Drawing.Size(328, 91);
            this.groupBox24.TabIndex = 44;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "[ 尺寸限制 ]";
            // 
            // CB_Limit_Length_SW
            // 
            this.CB_Limit_Length_SW.AutoSize = true;
            this.CB_Limit_Length_SW.Location = new System.Drawing.Point(216, 0);
            this.CB_Limit_Length_SW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CB_Limit_Length_SW.Name = "CB_Limit_Length_SW";
            this.CB_Limit_Length_SW.Size = new System.Drawing.Size(78, 18);
            this.CB_Limit_Length_SW.TabIndex = 31;
            this.CB_Limit_Length_SW.Text = "Enabled";
            this.CB_Limit_Length_SW.UseVisualStyleBackColor = true;
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(244, 25);
            this.label89.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(35, 14);
            this.label89.TabIndex = 8;
            this.label89.Text = "Max";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(49, 25);
            this.label90.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(33, 14);
            this.label90.TabIndex = 7;
            this.label90.Text = "Min";
            // 
            // E_Limit_Length_Max
            // 
            this.E_Limit_Length_Max.Location = new System.Drawing.Point(216, 46);
            this.E_Limit_Length_Max.Margin = new System.Windows.Forms.Padding(4);
            this.E_Limit_Length_Max.Name = "E_Limit_Length_Max";
            this.E_Limit_Length_Max.Size = new System.Drawing.Size(93, 24);
            this.E_Limit_Length_Max.TabIndex = 6;
            this.E_Limit_Length_Max.Text = "123.456";
            this.E_Limit_Length_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(115, 50);
            this.label91.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(79, 14);
            this.label91.TabIndex = 1;
            this.label91.Text = "<= 長度 <=";
            // 
            // E_Limit_Length_Min
            // 
            this.E_Limit_Length_Min.Location = new System.Drawing.Point(19, 46);
            this.E_Limit_Length_Min.Margin = new System.Windows.Forms.Padding(4);
            this.E_Limit_Length_Min.Name = "E_Limit_Length_Min";
            this.E_Limit_Length_Min.Size = new System.Drawing.Size(93, 24);
            this.E_Limit_Length_Min.TabIndex = 0;
            this.E_Limit_Length_Min.Text = "123.456";
            this.E_Limit_Length_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_Ofs
            // 
            this.TP_Ofs.Controls.Add(this.groupBox27);
            this.TP_Ofs.Location = new System.Drawing.Point(4, 24);
            this.TP_Ofs.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Ofs.Name = "TP_Ofs";
            this.TP_Ofs.Size = new System.Drawing.Size(975, 478);
            this.TP_Ofs.TabIndex = 29;
            this.TP_Ofs.Text = "Ofs";
            this.TP_Ofs.UseVisualStyleBackColor = true;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.label74);
            this.groupBox27.Controls.Add(this.label75);
            this.groupBox27.Controls.Add(this.E_Ofs_Q);
            this.groupBox27.Controls.Add(this.label76);
            this.groupBox27.Controls.Add(this.label77);
            this.groupBox27.Controls.Add(this.E_Ofs_Y);
            this.groupBox27.Controls.Add(this.label78);
            this.groupBox27.Controls.Add(this.label79);
            this.groupBox27.Controls.Add(this.E_Ofs_X);
            this.groupBox27.Location = new System.Drawing.Point(18, 17);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(190, 113);
            this.groupBox27.TabIndex = 41;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "[ 補正量 ]";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(144, 86);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(22, 14);
            this.label74.TabIndex = 17;
            this.label74.Text = "度";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(9, 86);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(27, 14);
            this.label75.TabIndex = 15;
            this.label75.Text = "DQ";
            // 
            // E_Ofs_Q
            // 
            this.E_Ofs_Q.Location = new System.Drawing.Point(67, 83);
            this.E_Ofs_Q.Name = "E_Ofs_Q";
            this.E_Ofs_Q.Size = new System.Drawing.Size(71, 24);
            this.E_Ofs_Q.TabIndex = 14;
            this.E_Ofs_Q.Text = "123.456";
            this.E_Ofs_Q.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(144, 57);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(29, 14);
            this.label76.TabIndex = 13;
            this.label76.Text = "mm";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(9, 57);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(27, 14);
            this.label77.TabIndex = 11;
            this.label77.Text = "DY";
            // 
            // E_Ofs_Y
            // 
            this.E_Ofs_Y.Location = new System.Drawing.Point(67, 54);
            this.E_Ofs_Y.Name = "E_Ofs_Y";
            this.E_Ofs_Y.Size = new System.Drawing.Size(71, 24);
            this.E_Ofs_Y.TabIndex = 10;
            this.E_Ofs_Y.Text = "123.456";
            this.E_Ofs_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(144, 26);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(29, 14);
            this.label78.TabIndex = 9;
            this.label78.Text = "mm";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(9, 26);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(27, 14);
            this.label79.TabIndex = 1;
            this.label79.Text = "DX";
            // 
            // E_Ofs_X
            // 
            this.E_Ofs_X.Location = new System.Drawing.Point(67, 23);
            this.E_Ofs_X.Name = "E_Ofs_X";
            this.E_Ofs_X.Size = new System.Drawing.Size(71, 24);
            this.E_Ofs_X.TabIndex = 0;
            this.E_Ofs_X.Text = "123.456";
            this.E_Ofs_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_ACF_Bond
            // 
            this.TP_ACF_Bond.Controls.Add(this.button3);
            this.TP_ACF_Bond.Controls.Add(this.groupBox2);
            this.TP_ACF_Bond.Controls.Add(this.groupBox8);
            this.TP_ACF_Bond.Location = new System.Drawing.Point(4, 24);
            this.TP_ACF_Bond.Name = "TP_ACF_Bond";
            this.TP_ACF_Bond.Size = new System.Drawing.Size(975, 478);
            this.TP_ACF_Bond.TabIndex = 46;
            this.TP_ACF_Bond.Text = "ACF壓合參數";
            this.TP_ACF_Bond.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LimeGreen;
            this.button3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(163, 312);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 42);
            this.button3.TabIndex = 17;
            this.button3.Text = "更新";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Update_Param);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label60);
            this.groupBox2.Controls.Add(this.E_ACF_Press3);
            this.groupBox2.Controls.Add(this.label61);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.E_ACF_Press2);
            this.groupBox2.Controls.Add(this.label59);
            this.groupBox2.Controls.Add(this.label35);
            this.groupBox2.Controls.Add(this.label37);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.CB_ACF_SW);
            this.groupBox2.Controls.Add(this.E_ACF_Press1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.E_ACF_Temp_Dn);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.E_ACF_Temp_Up);
            this.groupBox2.Controls.Add(this.label48);
            this.groupBox2.Location = new System.Drawing.Point(19, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(283, 225);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ 壓刀 ]";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(218, 194);
            this.label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(32, 14);
            this.label60.TabIndex = 42;
            this.label60.Text = "KPa";
            // 
            // E_ACF_Press3
            // 
            this.E_ACF_Press3.Enabled = false;
            this.E_ACF_Press3.Location = new System.Drawing.Point(144, 191);
            this.E_ACF_Press3.Margin = new System.Windows.Forms.Padding(4);
            this.E_ACF_Press3.Name = "E_ACF_Press3";
            this.E_ACF_Press3.Size = new System.Drawing.Size(66, 24);
            this.E_ACF_Press3.TabIndex = 40;
            this.E_ACF_Press3.Text = "123";
            this.E_ACF_Press3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(19, 196);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(77, 14);
            this.label61.TabIndex = 41;
            this.label61.Text = "壓力(錶頭)";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(218, 162);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(25, 14);
            this.label58.TabIndex = 39;
            this.label58.Text = "Kg";
            // 
            // E_ACF_Press2
            // 
            this.E_ACF_Press2.Enabled = false;
            this.E_ACF_Press2.Location = new System.Drawing.Point(144, 159);
            this.E_ACF_Press2.Margin = new System.Windows.Forms.Padding(4);
            this.E_ACF_Press2.Name = "E_ACF_Press2";
            this.E_ACF_Press2.Size = new System.Drawing.Size(66, 24);
            this.E_ACF_Press2.TabIndex = 37;
            this.E_ACF_Press2.Text = "123";
            this.E_ACF_Press2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(19, 164);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(77, 14);
            this.label59.TabIndex = 38;
            this.label59.Text = "壓力(實測)";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(218, 130);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(62, 14);
            this.label35.TabIndex = 36;
            this.label35.Text = "(0-4096)";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(218, 98);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(22, 14);
            this.label37.TabIndex = 35;
            this.label37.Text = "度";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(218, 66);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(22, 14);
            this.label38.TabIndex = 34;
            this.label38.Text = "度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 33;
            this.label10.Text = "動作開關";
            // 
            // CB_ACF_SW
            // 
            this.CB_ACF_SW.AutoSize = true;
            this.CB_ACF_SW.Location = new System.Drawing.Point(165, 41);
            this.CB_ACF_SW.Margin = new System.Windows.Forms.Padding(4);
            this.CB_ACF_SW.Name = "CB_ACF_SW";
            this.CB_ACF_SW.Size = new System.Drawing.Size(15, 14);
            this.CB_ACF_SW.TabIndex = 31;
            this.CB_ACF_SW.UseVisualStyleBackColor = true;
            this.CB_ACF_SW.Visible = false;
            // 
            // E_ACF_Press1
            // 
            this.E_ACF_Press1.Location = new System.Drawing.Point(144, 127);
            this.E_ACF_Press1.Margin = new System.Windows.Forms.Padding(4);
            this.E_ACF_Press1.Name = "E_ACF_Press1";
            this.E_ACF_Press1.Size = new System.Drawing.Size(66, 24);
            this.E_ACF_Press1.TabIndex = 24;
            this.E_ACF_Press1.Text = "123";
            this.E_ACF_Press1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 132);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 14);
            this.label11.TabIndex = 25;
            this.label11.Text = "壓著壓力";
            // 
            // E_ACF_Temp_Dn
            // 
            this.E_ACF_Temp_Dn.Location = new System.Drawing.Point(144, 95);
            this.E_ACF_Temp_Dn.Margin = new System.Windows.Forms.Padding(4);
            this.E_ACF_Temp_Dn.Name = "E_ACF_Temp_Dn";
            this.E_ACF_Temp_Dn.Size = new System.Drawing.Size(66, 24);
            this.E_ACF_Temp_Dn.TabIndex = 17;
            this.E_ACF_Temp_Dn.Text = "123";
            this.E_ACF_Temp_Dn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 100);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 14);
            this.label12.TabIndex = 18;
            this.label12.Text = "下壓刀溫度";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(149, 17);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(37, 14);
            this.label46.TabIndex = 6;
            this.label46.Text = "No.1";
            this.label46.Visible = false;
            // 
            // E_ACF_Temp_Up
            // 
            this.E_ACF_Temp_Up.Location = new System.Drawing.Point(144, 63);
            this.E_ACF_Temp_Up.Margin = new System.Windows.Forms.Padding(4);
            this.E_ACF_Temp_Up.Name = "E_ACF_Temp_Up";
            this.E_ACF_Temp_Up.Size = new System.Drawing.Size(66, 24);
            this.E_ACF_Temp_Up.TabIndex = 4;
            this.E_ACF_Temp_Up.Text = "123";
            this.E_ACF_Temp_Up.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(19, 68);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(82, 14);
            this.label48.TabIndex = 5;
            this.label48.Text = "上壓刀溫度";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label13);
            this.groupBox8.Controls.Add(this.E_ACF_Time);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Location = new System.Drawing.Point(19, 248);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(283, 58);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "[ 壓著時間 ]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(218, 30);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 14);
            this.label13.TabIndex = 28;
            this.label13.Text = "Sec";
            // 
            // E_ACF_Time
            // 
            this.E_ACF_Time.Location = new System.Drawing.Point(144, 25);
            this.E_ACF_Time.Margin = new System.Windows.Forms.Padding(4);
            this.E_ACF_Time.Name = "E_ACF_Time";
            this.E_ACF_Time.Size = new System.Drawing.Size(66, 24);
            this.E_ACF_Time.TabIndex = 26;
            this.E_ACF_Time.Text = "12.3";
            this.E_ACF_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 30);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 14);
            this.label14.TabIndex = 27;
            this.label14.Text = "壓著時間";
            // 
            // TP_ACF_Pos
            // 
            this.TP_ACF_Pos.Controls.Add(this.panel6);
            this.TP_ACF_Pos.Location = new System.Drawing.Point(4, 24);
            this.TP_ACF_Pos.Name = "TP_ACF_Pos";
            this.TP_ACF_Pos.Size = new System.Drawing.Size(975, 478);
            this.TP_ACF_Pos.TabIndex = 45;
            this.TP_ACF_Pos.Text = "ACF位置";
            this.TP_ACF_Pos.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel13);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(975, 478);
            this.panel6.TabIndex = 5;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel7);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(0, 98);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(975, 380);
            this.panel11.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.DG_ACF_Pos);
            this.panel7.Controls.Add(this.panel12);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(975, 345);
            this.panel7.TabIndex = 3;
            // 
            // DG_ACF_Pos
            // 
            this.DG_ACF_Pos.AllowUserToAddRows = false;
            this.DG_ACF_Pos.AllowUserToDeleteRows = false;
            this.DG_ACF_Pos.AllowUserToResizeColumns = false;
            this.DG_ACF_Pos.AllowUserToResizeRows = false;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_ACF_Pos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.DG_ACF_Pos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_ACF_Pos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.Column2,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column10,
            this.Column9,
            this.Column8,
            this.Column3,
            this.Column4});
            this.DG_ACF_Pos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_ACF_Pos.Location = new System.Drawing.Point(0, 0);
            this.DG_ACF_Pos.Name = "DG_ACF_Pos";
            this.DG_ACF_Pos.RowTemplate.Height = 24;
            this.DG_ACF_Pos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_ACF_Pos.Size = new System.Drawing.Size(893, 345);
            this.DG_ACF_Pos.TabIndex = 2;
            this.DG_ACF_Pos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_ACF_Pos_CellContentClick);
            this.DG_ACF_Pos.SelectionChanged += new System.EventHandler(this.DG_ACF_Pos_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle42.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle42;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 60F;
            this.dataGridViewTextBoxColumn3.HeaderText = "貼附X";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 60F;
            this.dataGridViewTextBoxColumn4.HeaderText = "貼附Y";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 60F;
            this.Column1.HeaderText = "B_Ofs_X";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 60F;
            this.Column2.HeaderText = "B_Ofs_Y";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 60;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 60F;
            this.Column6.HeaderText = "B_Ofs_Q";
            this.Column6.Name = "Column6";
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 60;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "C_Ofs_X";
            this.Column5.Name = "Column5";
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "C_Ofs_Y";
            this.Column7.Name = "Column7";
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column7.Width = 60;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "C_Ofs_Q";
            this.Column10.Name = "Column10";
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column10.Width = 60;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 60F;
            this.Column9.HeaderText = "檢查1參數";
            this.Column9.Name = "Column9";
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.Width = 60;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 60F;
            this.Column8.HeaderText = "檢查2參數";
            this.Column8.Name = "Column8";
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column8.Width = 60;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 60F;
            this.Column3.HeaderText = "檢查1光源";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 60F;
            this.Column4.HeaderText = "檢查2光源";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.Width = 60;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.OliveDrab;
            this.panel12.Controls.Add(this.B_ACF_Pos_Move_Dn);
            this.panel12.Controls.Add(this.B_ACF_Pos_Move_Up);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel12.Location = new System.Drawing.Point(893, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(82, 345);
            this.panel12.TabIndex = 5;
            // 
            // B_ACF_Pos_Move_Dn
            // 
            this.B_ACF_Pos_Move_Dn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_ACF_Pos_Move_Dn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_ACF_Pos_Move_Dn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_ACF_Pos_Move_Dn.Location = new System.Drawing.Point(7, 79);
            this.B_ACF_Pos_Move_Dn.Margin = new System.Windows.Forms.Padding(4);
            this.B_ACF_Pos_Move_Dn.Name = "B_ACF_Pos_Move_Dn";
            this.B_ACF_Pos_Move_Dn.Size = new System.Drawing.Size(66, 64);
            this.B_ACF_Pos_Move_Dn.TabIndex = 28;
            this.B_ACF_Pos_Move_Dn.Text = "下移";
            this.B_ACF_Pos_Move_Dn.UseVisualStyleBackColor = false;
            this.B_ACF_Pos_Move_Dn.Click += new System.EventHandler(this.B_ACF_Pos_Move_Dn_Click);
            // 
            // B_ACF_Pos_Move_Up
            // 
            this.B_ACF_Pos_Move_Up.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_ACF_Pos_Move_Up.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_ACF_Pos_Move_Up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_ACF_Pos_Move_Up.Location = new System.Drawing.Point(7, 7);
            this.B_ACF_Pos_Move_Up.Margin = new System.Windows.Forms.Padding(4);
            this.B_ACF_Pos_Move_Up.Name = "B_ACF_Pos_Move_Up";
            this.B_ACF_Pos_Move_Up.Size = new System.Drawing.Size(66, 64);
            this.B_ACF_Pos_Move_Up.TabIndex = 27;
            this.B_ACF_Pos_Move_Up.Text = "上移";
            this.B_ACF_Pos_Move_Up.UseVisualStyleBackColor = false;
            this.B_ACF_Pos_Move_Up.Click += new System.EventHandler(this.B_ACF_Pos_Move_Up_Click);
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Beige;
            this.panel13.Controls.Add(this.E_ACF_Row_No);
            this.panel13.Controls.Add(this.label19);
            this.panel13.Controls.Add(this.label15);
            this.panel13.Controls.Add(this.E_Check_Pitch);
            this.panel13.Controls.Add(this.label16);
            this.panel13.Controls.Add(this.label54);
            this.panel13.Controls.Add(this.E_ACF_Length);
            this.panel13.Controls.Add(this.label55);
            this.panel13.Controls.Add(this.B_ACF_Check_L_Copy);
            this.panel13.Controls.Add(this.label86);
            this.panel13.Controls.Add(this.CB_ACF_Pos_Count);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(975, 98);
            this.panel13.TabIndex = 3;
            // 
            // E_ACF_Row_No
            // 
            this.E_ACF_Row_No.Location = new System.Drawing.Point(400, 19);
            this.E_ACF_Row_No.Name = "E_ACF_Row_No";
            this.E_ACF_Row_No.ReadOnly = true;
            this.E_ACF_Row_No.Size = new System.Drawing.Size(50, 24);
            this.E_ACF_Row_No.TabIndex = 50;
            this.E_ACF_Row_No.Text = "123";
            this.E_ACF_Row_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(367, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 14);
            this.label19.TabIndex = 51;
            this.label19.Text = "從:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(199, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 14);
            this.label15.TabIndex = 49;
            this.label15.Text = "mm";
            // 
            // E_Check_Pitch
            // 
            this.E_Check_Pitch.Location = new System.Drawing.Point(117, 67);
            this.E_Check_Pitch.Name = "E_Check_Pitch";
            this.E_Check_Pitch.Size = new System.Drawing.Size(76, 24);
            this.E_Check_Pitch.TabIndex = 47;
            this.E_Check_Pitch.Text = "123.456";
            this.E_Check_Pitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 14);
            this.label16.TabIndex = 48;
            this.label16.Text = "ACF檢查間距";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(199, 42);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(29, 14);
            this.label54.TabIndex = 46;
            this.label54.Text = "mm";
            // 
            // E_ACF_Length
            // 
            this.E_ACF_Length.Location = new System.Drawing.Point(117, 37);
            this.E_ACF_Length.Name = "E_ACF_Length";
            this.E_ACF_Length.Size = new System.Drawing.Size(76, 24);
            this.E_ACF_Length.TabIndex = 44;
            this.E_ACF_Length.Text = "123.456";
            this.E_ACF_Length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(16, 42);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(95, 14);
            this.label55.TabIndex = 45;
            this.label55.Text = "ACF貼附長度";
            // 
            // B_ACF_Check_L_Copy
            // 
            this.B_ACF_Check_L_Copy.BackColor = System.Drawing.Color.Olive;
            this.B_ACF_Check_L_Copy.Location = new System.Drawing.Point(363, 49);
            this.B_ACF_Check_L_Copy.Name = "B_ACF_Check_L_Copy";
            this.B_ACF_Check_L_Copy.Size = new System.Drawing.Size(199, 42);
            this.B_ACF_Check_L_Copy.TabIndex = 43;
            this.B_ACF_Check_L_Copy.Text = "複製到其他位置(Copy)";
            this.B_ACF_Check_L_Copy.UseVisualStyleBackColor = false;
            this.B_ACF_Check_L_Copy.Click += new System.EventHandler(this.B_ACF_Check_L_Copy_Click);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(16, 12);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(65, 14);
            this.label86.TabIndex = 1;
            this.label86.Text = "COF數量";
            // 
            // CB_ACF_Pos_Count
            // 
            this.CB_ACF_Pos_Count.FormattingEnabled = true;
            this.CB_ACF_Pos_Count.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.CB_ACF_Pos_Count.Location = new System.Drawing.Point(117, 9);
            this.CB_ACF_Pos_Count.Name = "CB_ACF_Pos_Count";
            this.CB_ACF_Pos_Count.Size = new System.Drawing.Size(76, 22);
            this.CB_ACF_Pos_Count.TabIndex = 0;
            this.CB_ACF_Pos_Count.Text = "1";
            this.CB_ACF_Pos_Count.SelectedIndexChanged += new System.EventHandler(this.CB_ACF_Pos_Count_SelectedIndexChanged);
            // 
            // TP_MS_Param
            // 
            this.TP_MS_Param.Controls.Add(this.B_Edit_MS_Param);
            this.TP_MS_Param.Location = new System.Drawing.Point(4, 24);
            this.TP_MS_Param.Name = "TP_MS_Param";
            this.TP_MS_Param.Size = new System.Drawing.Size(975, 478);
            this.TP_MS_Param.TabIndex = 31;
            this.TP_MS_Param.Text = "機械參數";
            this.TP_MS_Param.UseVisualStyleBackColor = true;
            // 
            // B_Edit_MS_Param
            // 
            this.B_Edit_MS_Param.Location = new System.Drawing.Point(20, 16);
            this.B_Edit_MS_Param.Name = "B_Edit_MS_Param";
            this.B_Edit_MS_Param.Size = new System.Drawing.Size(186, 97);
            this.B_Edit_MS_Param.TabIndex = 2;
            this.B_Edit_MS_Param.Text = "編輯機械參數";
            this.B_Edit_MS_Param.UseVisualStyleBackColor = true;
            this.B_Edit_MS_Param.Click += new System.EventHandler(this.B_Edit_MS_Param_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DG_Robot_Pos);
            this.tabPage1.Controls.Add(this.panel10);
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(975, 478);
            this.tabPage1.TabIndex = 49;
            this.tabPage1.Text = "Robot";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DG_Robot_Pos
            // 
            this.DG_Robot_Pos.AllowUserToAddRows = false;
            this.DG_Robot_Pos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_Robot_Pos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
            this.DG_Robot_Pos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Robot_Pos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.Column11,
            this.Column12,
            this.點位敘述});
            this.DG_Robot_Pos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Robot_Pos.Location = new System.Drawing.Point(3, 72);
            this.DG_Robot_Pos.Name = "DG_Robot_Pos";
            this.DG_Robot_Pos.RowTemplate.Height = 24;
            this.DG_Robot_Pos.Size = new System.Drawing.Size(887, 403);
            this.DG_Robot_Pos.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewTextBoxColumn2.HeaderText = "No";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Local";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridViewTextBoxColumn6.HeaderText = "速度";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridViewTextBoxColumn7.HeaderText = "X";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn7.Width = 70;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridViewTextBoxColumn8.HeaderText = "Y";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 70;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridViewTextBoxColumn9.HeaderText = "Z";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 70;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridViewTextBoxColumn10.HeaderText = "U";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Width = 70;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridViewTextBoxColumn11.HeaderText = "V";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn11.Width = 70;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle37;
            this.dataGridViewTextBoxColumn12.HeaderText = "W";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 70;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewCellStyle38.BackColor = System.Drawing.Color.Gray;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle38;
            this.dataGridViewTextBoxColumn13.HeaderText = "Elbow";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn13.Width = 60;
            // 
            // Column11
            // 
            dataGridViewCellStyle39.BackColor = System.Drawing.Color.Gray;
            this.Column11.DefaultCellStyle = dataGridViewCellStyle39;
            this.Column11.HeaderText = "Hand";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column11.Width = 60;
            // 
            // Column12
            // 
            dataGridViewCellStyle40.BackColor = System.Drawing.Color.Gray;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle40;
            this.Column12.HeaderText = "Wrist";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column12.Width = 60;
            // 
            // 點位敘述
            // 
            this.點位敘述.HeaderText = "點位敘述";
            this.點位敘述.Name = "點位敘述";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.OliveDrab;
            this.panel10.Controls.Add(this.B_Robot_Pos_Get);
            this.panel10.Controls.Add(this.B_Robot_Pos_Move_Dn);
            this.panel10.Controls.Add(this.B_Robot_Pos_Move_Up);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(890, 72);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(82, 403);
            this.panel10.TabIndex = 8;
            // 
            // B_Robot_Pos_Get
            // 
            this.B_Robot_Pos_Get.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Robot_Pos_Get.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Robot_Pos_Get.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Robot_Pos_Get.Location = new System.Drawing.Point(7, 151);
            this.B_Robot_Pos_Get.Margin = new System.Windows.Forms.Padding(4);
            this.B_Robot_Pos_Get.Name = "B_Robot_Pos_Get";
            this.B_Robot_Pos_Get.Size = new System.Drawing.Size(66, 64);
            this.B_Robot_Pos_Get.TabIndex = 29;
            this.B_Robot_Pos_Get.Text = "取得";
            this.B_Robot_Pos_Get.UseVisualStyleBackColor = false;
            this.B_Robot_Pos_Get.Click += new System.EventHandler(this.B_Robot_Pos_Get_Click);
            // 
            // B_Robot_Pos_Move_Dn
            // 
            this.B_Robot_Pos_Move_Dn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Robot_Pos_Move_Dn.Enabled = false;
            this.B_Robot_Pos_Move_Dn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Robot_Pos_Move_Dn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Robot_Pos_Move_Dn.Location = new System.Drawing.Point(7, 79);
            this.B_Robot_Pos_Move_Dn.Margin = new System.Windows.Forms.Padding(4);
            this.B_Robot_Pos_Move_Dn.Name = "B_Robot_Pos_Move_Dn";
            this.B_Robot_Pos_Move_Dn.Size = new System.Drawing.Size(66, 64);
            this.B_Robot_Pos_Move_Dn.TabIndex = 28;
            this.B_Robot_Pos_Move_Dn.Text = "下移";
            this.B_Robot_Pos_Move_Dn.UseVisualStyleBackColor = false;
            this.B_Robot_Pos_Move_Dn.Visible = false;
            this.B_Robot_Pos_Move_Dn.Click += new System.EventHandler(this.B_Robot_Pos_Move_Dn_Click);
            // 
            // B_Robot_Pos_Move_Up
            // 
            this.B_Robot_Pos_Move_Up.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Robot_Pos_Move_Up.Enabled = false;
            this.B_Robot_Pos_Move_Up.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Robot_Pos_Move_Up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Robot_Pos_Move_Up.Location = new System.Drawing.Point(7, 7);
            this.B_Robot_Pos_Move_Up.Margin = new System.Windows.Forms.Padding(4);
            this.B_Robot_Pos_Move_Up.Name = "B_Robot_Pos_Move_Up";
            this.B_Robot_Pos_Move_Up.Size = new System.Drawing.Size(66, 64);
            this.B_Robot_Pos_Move_Up.TabIndex = 27;
            this.B_Robot_Pos_Move_Up.Text = "上移";
            this.B_Robot_Pos_Move_Up.UseVisualStyleBackColor = false;
            this.B_Robot_Pos_Move_Up.Visible = false;
            this.B_Robot_Pos_Move_Up.Click += new System.EventHandler(this.B_Robot_Pos_Move_Up_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Beige;
            this.panel9.Controls.Add(this.speedbox);
            this.panel9.Controls.Add(this.BTN_setspeed);
            this.panel9.Controls.Add(this.CB_Robot_Pos_Start_No);
            this.panel9.Controls.Add(this.B_Robot_Manager);
            this.panel9.Controls.Add(this.label20);
            this.panel9.Controls.Add(this.B_Robot_Pos_Write);
            this.panel9.Controls.Add(this.B_Robot_Pos_Read);
            this.panel9.Controls.Add(this.label21);
            this.panel9.Controls.Add(this.CB_Robot_Pos_Count);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Margin = new System.Windows.Forms.Padding(2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(969, 69);
            this.panel9.TabIndex = 6;
            // 
            // speedbox
            // 
            this.speedbox.Location = new System.Drawing.Point(429, 2);
            this.speedbox.Name = "speedbox";
            this.speedbox.Size = new System.Drawing.Size(95, 24);
            this.speedbox.TabIndex = 77;
            this.speedbox.TextChanged += new System.EventHandler(this.speedbox_TextChanged);
            // 
            // BTN_setspeed
            // 
            this.BTN_setspeed.BackColor = System.Drawing.Color.Red;
            this.BTN_setspeed.Location = new System.Drawing.Point(429, 33);
            this.BTN_setspeed.Name = "BTN_setspeed";
            this.BTN_setspeed.Size = new System.Drawing.Size(95, 36);
            this.BTN_setspeed.TabIndex = 76;
            this.BTN_setspeed.Text = "Set_Speed";
            this.BTN_setspeed.UseVisualStyleBackColor = false;
            this.BTN_setspeed.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CB_Robot_Pos_Start_No
            // 
            this.CB_Robot_Pos_Start_No.Location = new System.Drawing.Point(87, 37);
            this.CB_Robot_Pos_Start_No.Name = "CB_Robot_Pos_Start_No";
            this.CB_Robot_Pos_Start_No.Size = new System.Drawing.Size(65, 24);
            this.CB_Robot_Pos_Start_No.TabIndex = 75;
            // 
            // B_Robot_Manager
            // 
            this.B_Robot_Manager.BackColor = System.Drawing.SystemColors.Control;
            this.B_Robot_Manager.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Robot_Manager.Location = new System.Drawing.Point(531, 0);
            this.B_Robot_Manager.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.B_Robot_Manager.Name = "B_Robot_Manager";
            this.B_Robot_Manager.Size = new System.Drawing.Size(118, 69);
            this.B_Robot_Manager.TabIndex = 71;
            this.B_Robot_Manager.Text = "Robot_Manager";
            this.B_Robot_Manager.UseVisualStyleBackColor = false;
            this.B_Robot_Manager.Click += new System.EventHandler(this.B_Robot_Manager_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 14);
            this.label20.TabIndex = 74;
            this.label20.Text = "起始編號";
            // 
            // B_Robot_Pos_Write
            // 
            this.B_Robot_Pos_Write.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Robot_Pos_Write.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Robot_Pos_Write.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Robot_Pos_Write.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Robot_Pos_Write.Location = new System.Drawing.Point(649, 0);
            this.B_Robot_Pos_Write.Margin = new System.Windows.Forms.Padding(4);
            this.B_Robot_Pos_Write.Name = "B_Robot_Pos_Write";
            this.B_Robot_Pos_Write.Size = new System.Drawing.Size(160, 69);
            this.B_Robot_Pos_Write.TabIndex = 73;
            this.B_Robot_Pos_Write.Text = "Save Robot資料";
            this.B_Robot_Pos_Write.UseVisualStyleBackColor = false;
            this.B_Robot_Pos_Write.Click += new System.EventHandler(this.B_Robot_Pos_Write_Click);
            // 
            // B_Robot_Pos_Read
            // 
            this.B_Robot_Pos_Read.BackColor = System.Drawing.Color.LightSeaGreen;
            this.B_Robot_Pos_Read.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Robot_Pos_Read.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Robot_Pos_Read.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Robot_Pos_Read.Location = new System.Drawing.Point(809, 0);
            this.B_Robot_Pos_Read.Margin = new System.Windows.Forms.Padding(4);
            this.B_Robot_Pos_Read.Name = "B_Robot_Pos_Read";
            this.B_Robot_Pos_Read.Size = new System.Drawing.Size(160, 69);
            this.B_Robot_Pos_Read.TabIndex = 31;
            this.B_Robot_Pos_Read.Text = "Read Robot資料";
            this.B_Robot_Pos_Read.UseVisualStyleBackColor = false;
            this.B_Robot_Pos_Read.Click += new System.EventHandler(this.B_Robot_Pos_Read_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(16, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 14);
            this.label21.TabIndex = 1;
            this.label21.Text = "位置數量";
            // 
            // CB_Robot_Pos_Count
            // 
            this.CB_Robot_Pos_Count.Enabled = false;
            this.CB_Robot_Pos_Count.FormattingEnabled = true;
            this.CB_Robot_Pos_Count.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.CB_Robot_Pos_Count.Location = new System.Drawing.Point(87, 9);
            this.CB_Robot_Pos_Count.Name = "CB_Robot_Pos_Count";
            this.CB_Robot_Pos_Count.Size = new System.Drawing.Size(65, 22);
            this.CB_Robot_Pos_Count.TabIndex = 0;
            this.CB_Robot_Pos_Count.Text = "1";
            // 
            // Plasma
            // 
            this.Plasma.Controls.Add(this.groupBox1);
            this.Plasma.Location = new System.Drawing.Point(4, 24);
            this.Plasma.Name = "Plasma";
            this.Plasma.Padding = new System.Windows.Forms.Padding(3);
            this.Plasma.Size = new System.Drawing.Size(975, 478);
            this.Plasma.TabIndex = 50;
            this.Plasma.Text = "Plasma";
            this.Plasma.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.E_Plasma_Clean_Count);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.E_Plasma_Clean_Speed);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Location = new System.Drawing.Point(32, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Plasma載台 ]";
            // 
            // E_Plasma_Clean_Count
            // 
            this.E_Plasma_Clean_Count.Location = new System.Drawing.Point(93, 57);
            this.E_Plasma_Clean_Count.Name = "E_Plasma_Clean_Count";
            this.E_Plasma_Clean_Count.Size = new System.Drawing.Size(76, 24);
            this.E_Plasma_Clean_Count.TabIndex = 9;
            this.E_Plasma_Clean_Count.Text = "123.456";
            this.E_Plasma_Clean_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(20, 60);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 14);
            this.label33.TabIndex = 10;
            this.label33.Text = "清潔次數";
            // 
            // E_Plasma_Clean_Speed
            // 
            this.E_Plasma_Clean_Speed.Location = new System.Drawing.Point(93, 23);
            this.E_Plasma_Clean_Speed.Name = "E_Plasma_Clean_Speed";
            this.E_Plasma_Clean_Speed.Size = new System.Drawing.Size(76, 24);
            this.E_Plasma_Clean_Speed.TabIndex = 6;
            this.E_Plasma_Clean_Speed.Text = "123.456";
            this.E_Plasma_Clean_Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(20, 28);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(67, 14);
            this.label36.TabIndex = 7;
            this.label36.Text = "清潔速度";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Silver;
            this.panel8.Controls.Add(this.LB_Tree_Name);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(983, 57);
            this.panel8.TabIndex = 31;
            // 
            // LB_Tree_Name
            // 
            this.LB_Tree_Name.AutoSize = true;
            this.LB_Tree_Name.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LB_Tree_Name.Location = new System.Drawing.Point(19, 16);
            this.LB_Tree_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LB_Tree_Name.Name = "LB_Tree_Name";
            this.LB_Tree_Name.Size = new System.Drawing.Size(66, 27);
            this.LB_Tree_Name.TabIndex = 27;
            this.LB_Tree_Name.Text = "Root";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Plasma_Clean_Speed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1307, 137);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Peru;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.E_Recipe_Code);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.E_Recipe_Info);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.E_Recipe_Name);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1307, 73);
            this.panel3.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(27, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Code";
            // 
            // E_Recipe_Code
            // 
            this.E_Recipe_Code.BackColor = System.Drawing.SystemColors.Window;
            this.E_Recipe_Code.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Code.ForeColor = System.Drawing.SystemColors.WindowText;
            this.E_Recipe_Code.Location = new System.Drawing.Point(17, 36);
            this.E_Recipe_Code.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Code.Name = "E_Recipe_Code";
            this.E_Recipe_Code.Size = new System.Drawing.Size(72, 33);
            this.E_Recipe_Code.TabIndex = 6;
            this.E_Recipe_Code.Text = "0000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(92, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(308, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "說明";
            // 
            // E_Recipe_Info
            // 
            this.E_Recipe_Info.BackColor = System.Drawing.SystemColors.Window;
            this.E_Recipe_Info.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Info.ForeColor = System.Drawing.SystemColors.WindowText;
            this.E_Recipe_Info.Location = new System.Drawing.Point(302, 36);
            this.E_Recipe_Info.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Info.Name = "E_Recipe_Info";
            this.E_Recipe_Info.Size = new System.Drawing.Size(354, 33);
            this.E_Recipe_Info.TabIndex = 3;
            this.E_Recipe_Info.Text = "說明";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(279, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "/";
            // 
            // E_Recipe_Name
            // 
            this.E_Recipe_Name.BackColor = System.Drawing.Color.Gray;
            this.E_Recipe_Name.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Recipe_Name.ForeColor = System.Drawing.Color.White;
            this.E_Recipe_Name.Location = new System.Drawing.Point(116, 36);
            this.E_Recipe_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_Recipe_Name.Name = "E_Recipe_Name";
            this.E_Recipe_Name.ReadOnly = true;
            this.E_Recipe_Name.Size = new System.Drawing.Size(160, 33);
            this.E_Recipe_Name.TabIndex = 1;
            this.E_Recipe_Name.Text = "Recipe_Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(128, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipe Name";
            // 
            // Plasma_Clean_Speed
            // 
            this.Plasma_Clean_Speed.BackColor = System.Drawing.Color.LightGreen;
            this.Plasma_Clean_Speed.Controls.Add(this.B_Open);
            this.Plasma_Clean_Speed.Controls.Add(this.B_Save_As);
            this.Plasma_Clean_Speed.Controls.Add(this.B_Cancel);
            this.Plasma_Clean_Speed.Controls.Add(this.B_Apply);
            this.Plasma_Clean_Speed.Dock = System.Windows.Forms.DockStyle.Top;
            this.Plasma_Clean_Speed.Location = new System.Drawing.Point(0, 0);
            this.Plasma_Clean_Speed.Margin = new System.Windows.Forms.Padding(2);
            this.Plasma_Clean_Speed.Name = "Plasma_Clean_Speed";
            this.Plasma_Clean_Speed.Size = new System.Drawing.Size(1307, 64);
            this.Plasma_Clean_Speed.TabIndex = 2;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.ImageIndex = 3;
            this.B_Open.ImageList = this.Tool_ImageList;
            this.B_Open.Location = new System.Drawing.Point(360, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(120, 64);
            this.B_Open.TabIndex = 10;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.UseVisualStyleBackColor = false;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // B_Save_As
            // 
            this.B_Save_As.BackColor = System.Drawing.Color.White;
            this.B_Save_As.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save_As.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save_As.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save_As.ImageIndex = 2;
            this.B_Save_As.ImageList = this.Tool_ImageList;
            this.B_Save_As.Location = new System.Drawing.Point(240, 0);
            this.B_Save_As.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save_As.Name = "B_Save_As";
            this.B_Save_As.Size = new System.Drawing.Size(120, 64);
            this.B_Save_As.TabIndex = 9;
            this.B_Save_As.Text = "另存檔案";
            this.B_Save_As.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Save_As.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Save_As.UseVisualStyleBackColor = false;
            this.B_Save_As.Click += new System.EventHandler(this.B_Save_As_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageIndex = 1;
            this.B_Cancel.ImageList = this.Tool_ImageList;
            this.B_Cancel.Location = new System.Drawing.Point(120, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(120, 64);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.White;
            this.B_Apply.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.ImageIndex = 0;
            this.B_Apply.ImageList = this.Tool_ImageList;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(120, 64);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(124, 700);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tFrame_JJS_HW1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(116, 670);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "影像";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(3, 3);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = false;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(110, 664);
            this.tFrame_JJS_HW1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(116, 670);
            this.tabPage3.TabIndex = 1;
            // 
            // TForm_Select_Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 700);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Select_Recipe";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.TForm_Select_Recipe_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Tray.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.TP_Size.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.TP_COF_Mark.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.TP_Limit.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.TP_Ofs.ResumeLayout(false);
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.TP_ACF_Bond.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.TP_ACF_Pos.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_ACF_Pos)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.TP_MS_Param.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Robot_Pos)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.Plasma.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.Plasma_Clean_Speed.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Plasma_Clean_Speed;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Recipe_Info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Recipe_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save_As;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem PM_Used;
        private System.Windows.Forms.ToolStripMenuItem PM_Golden;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button B_Update_Tree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Space;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox E_Recipe_Code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList Tool_ImageList;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage TP_Ofs;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.TextBox E_Ofs_Q;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.TextBox E_Ofs_Y;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TextBox E_Ofs_X;
        private System.Windows.Forms.TabPage TP_MS_Param;
        private System.Windows.Forms.Button B_Edit_MS_Param;
        private EFC.Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW1;
        
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox E_COF_Mark_R_Y;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox E_COF_Mark_R_X;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox E_COF_Mark_L_Y;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox E_COF_Mark_L_X;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TabPage TP_COF_Mark;
        private System.Windows.Forms.Button B_E_COF_Mark_R_Light;
        private System.Windows.Forms.Button B_E_COF_Mark_L_Light;
        private System.Windows.Forms.Button B_E_COF_Mark_L_Edit;
        private System.Windows.Forms.Button B_E_COF_Mark_R_Edit;
        private System.Windows.Forms.TabPage TP_Limit;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.CheckBox CB_Limit_Length_SW;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.TextBox E_Limit_Length_Max;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox E_Limit_Length_Min;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TabPage TP_ACF_Pos;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.ComboBox CB_ACF_Pos_Count;
        private System.Windows.Forms.TabPage TP_Size;
        private System.Windows.Forms.TabPage TP_ACF_Bond;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox E_Panel_Z;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox E_Panel_Y;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox E_Panel_X;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox E_ACF_Press3;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox E_ACF_Press2;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox CB_ACF_SW;
        private System.Windows.Forms.TextBox E_ACF_Press1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox E_ACF_Temp_Dn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox E_ACF_Temp_Up;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox E_ACF_Time;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage TP_Tray;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.TextBox E_Tray_Num_X;
        private System.Windows.Forms.TextBox E_Tray_Pitch_X;
        private System.Windows.Forms.TextBox E_Tray_Start_X;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.TextBox E_Tray_Num_Y;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.TextBox E_Tray_Pitch_Y;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.TextBox E_Tray_Start_Y;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button B_ACF_Check_L_Copy;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView DG_ACF_Pos;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button B_ACF_Pos_Move_Dn;
        private System.Windows.Forms.Button B_ACF_Pos_Move_Up;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox E_ACF_Length;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox E_Check_Pitch;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewButtonColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn Column8;
        private System.Windows.Forms.DataGridViewButtonColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label LB_Tree_Name;
        private System.Windows.Forms.TextBox E_ACF_Row_No;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TreeView TV_Menu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DG_Robot_Pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn 點位敘述;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button B_Robot_Pos_Get;
        private System.Windows.Forms.Button B_Robot_Pos_Move_Dn;
        private System.Windows.Forms.Button B_Robot_Pos_Move_Up;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button B_Robot_Manager;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button B_Robot_Pos_Write;
        private System.Windows.Forms.Button B_Robot_Pos_Read;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox CB_Robot_Pos_Count;
        private System.Windows.Forms.TextBox CB_Robot_Pos_Start_No;
        private System.Windows.Forms.TabPage Plasma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Plasma_Clean_Count;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox E_Plasma_Clean_Speed;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button BTN_setspeed;
        private System.Windows.Forms.TextBox speedbox;
    }
}