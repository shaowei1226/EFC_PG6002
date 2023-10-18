namespace EFC.Vision.Halcon
{
    partial class TForm_Find_Natch_1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("@.選取舊標靶");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("1.設定建立標靶參數");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("2.選取範圍");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("@.建立新標靶", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Step 1.建立標靶", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Step 2.設定搜尋參數");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Step 3.設定搜尋範圍");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Step 4.測試標靶");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("步驟", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Space = new System.Windows.Forms.TabPage();
            this.B_Next1 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.B_Update1 = new System.Windows.Forms.Button();
            this.B_Next2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SB_Threshold_Max = new System.Windows.Forms.HScrollBar();
            this.E_Threshold_Max = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SB_Threshold_Min = new System.Windows.Forms.HScrollBar();
            this.E_Threshold_Min = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.E_Wafer_Circularity_Max = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.E_Wafer_Circularity_Min = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.E_Erosion_Circle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Dilation_Circle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.E_Wafer_Circle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.TV_Region_Info = new System.Windows.Forms.TreeView();
            this.B_Get_Region_Info = new System.Windows.Forms.Button();
            this.CB_Natch_Filter = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.E_Natch_Erosion_Circle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Natch_Compactness_Max = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.E_Natch_Compactness_Min = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.E_Natch_Area_Max = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.E_Natch_Area_Min = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.B_Finish = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Space.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Open);
            this.panel1.Controls.Add(this.B_Save);
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 59);
            this.panel1.TabIndex = 2;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.Image = global::EFC.Vision.Halcon.Properties.Resources.hard_drive_upload;
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.Location = new System.Drawing.Point(291, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(97, 59);
            this.B_Open.TabIndex = 8;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.UseVisualStyleBackColor = false;
            // 
            // B_Save
            // 
            this.B_Save.BackColor = System.Drawing.Color.White;
            this.B_Save.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save.Image = global::EFC.Vision.Halcon.Properties.Resources.hard_drive_download;
            this.B_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save.Location = new System.Drawing.Point(194, 0);
            this.B_Save.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(97, 59);
            this.B_Save.TabIndex = 7;
            this.B_Save.Text = "儲存";
            this.B_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Save.UseVisualStyleBackColor = false;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.Image = global::EFC.Vision.Halcon.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(97, 59);
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
            this.B_Apply.Image = global::EFC.Vision.Halcon.Properties.Resources.magic_wand;
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1235, 528);
            this.panel2.TabIndex = 3;
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
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tFrame_JJS_HW1);
            this.splitContainer1.Size = new System.Drawing.Size(1235, 528);
            this.splitContainer1.SplitterDistance = 733;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(215, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(518, 528);
            this.panel4.TabIndex = 3;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TV_Region_Info);
            this.splitContainer2.Panel2.Controls.Add(this.B_Get_Region_Info);
            this.splitContainer2.Size = new System.Drawing.Size(518, 528);
            this.splitContainer2.SplitterDistance = 362;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Space);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(518, 362);
            this.tabControl1.TabIndex = 2;
            // 
            // TP_Space
            // 
            this.TP_Space.Controls.Add(this.B_Next1);
            this.TP_Space.Location = new System.Drawing.Point(4, 24);
            this.TP_Space.Name = "TP_Space";
            this.TP_Space.Size = new System.Drawing.Size(510, 334);
            this.TP_Space.TabIndex = 7;
            this.TP_Space.Text = "空白";
            this.TP_Space.UseVisualStyleBackColor = true;
            // 
            // B_Next1
            // 
            this.B_Next1.BackColor = System.Drawing.Color.Orange;
            this.B_Next1.Location = new System.Drawing.Point(284, 16);
            this.B_Next1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next1.Name = "B_Next1";
            this.B_Next1.Size = new System.Drawing.Size(93, 36);
            this.B_Next1.TabIndex = 20;
            this.B_Next1.Text = "下一步 =>";
            this.B_Next1.UseVisualStyleBackColor = false;
            this.B_Next1.Click += new System.EventHandler(this.B_Next1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_Update1);
            this.tabPage1.Controls.Add(this.B_Next2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(510, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Step1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
            // 
            // B_Update1
            // 
            this.B_Update1.BackColor = System.Drawing.Color.GreenYellow;
            this.B_Update1.Location = new System.Drawing.Point(215, 111);
            this.B_Update1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Update1.Name = "B_Update1";
            this.B_Update1.Size = new System.Drawing.Size(93, 36);
            this.B_Update1.TabIndex = 20;
            this.B_Update1.Text = "更新";
            this.B_Update1.UseVisualStyleBackColor = false;
            this.B_Update1.Click += new System.EventHandler(this.B_Update_Click);
            // 
            // B_Next2
            // 
            this.B_Next2.BackColor = System.Drawing.Color.Orange;
            this.B_Next2.Location = new System.Drawing.Point(339, 5);
            this.B_Next2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next2.Name = "B_Next2";
            this.B_Next2.Size = new System.Drawing.Size(93, 36);
            this.B_Next2.TabIndex = 19;
            this.B_Next2.Text = "下一步 =>";
            this.B_Next2.UseVisualStyleBackColor = false;
            this.B_Next2.Click += new System.EventHandler(this.B_Next1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SB_Threshold_Max);
            this.groupBox1.Controls.Add(this.E_Threshold_Max);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.SB_Threshold_Min);
            this.groupBox1.Controls.Add(this.E_Threshold_Min);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(293, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "參數";
            // 
            // SB_Threshold_Max
            // 
            this.SB_Threshold_Max.Location = new System.Drawing.Point(134, 52);
            this.SB_Threshold_Max.Maximum = 264;
            this.SB_Threshold_Max.Name = "SB_Threshold_Max";
            this.SB_Threshold_Max.Size = new System.Drawing.Size(92, 21);
            this.SB_Threshold_Max.TabIndex = 5;
            this.SB_Threshold_Max.ValueChanged += new System.EventHandler(this.SB_Threshold_Max_ValueChanged);
            // 
            // E_Threshold_Max
            // 
            this.E_Threshold_Max.Location = new System.Drawing.Point(236, 49);
            this.E_Threshold_Max.Margin = new System.Windows.Forms.Padding(2);
            this.E_Threshold_Max.Name = "E_Threshold_Max";
            this.E_Threshold_Max.Size = new System.Drawing.Size(39, 24);
            this.E_Threshold_Max.TabIndex = 4;
            this.E_Threshold_Max.Text = "255";
            this.E_Threshold_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Threshold Max";
            // 
            // SB_Threshold_Min
            // 
            this.SB_Threshold_Min.Location = new System.Drawing.Point(134, 20);
            this.SB_Threshold_Min.Maximum = 264;
            this.SB_Threshold_Min.Name = "SB_Threshold_Min";
            this.SB_Threshold_Min.Size = new System.Drawing.Size(92, 21);
            this.SB_Threshold_Min.TabIndex = 2;
            this.SB_Threshold_Min.ValueChanged += new System.EventHandler(this.SB_Threshold_Min_ValueChanged);
            // 
            // E_Threshold_Min
            // 
            this.E_Threshold_Min.Location = new System.Drawing.Point(236, 18);
            this.E_Threshold_Min.Margin = new System.Windows.Forms.Padding(2);
            this.E_Threshold_Min.Name = "E_Threshold_Min";
            this.E_Threshold_Min.Size = new System.Drawing.Size(39, 24);
            this.E_Threshold_Min.TabIndex = 1;
            this.E_Threshold_Min.Text = "255";
            this.E_Threshold_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Threshold Min";
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.groupBox5);
            this.tabPage7.Controls.Add(this.button6);
            this.tabPage7.Controls.Add(this.button2);
            this.tabPage7.Controls.Add(this.groupBox2);
            this.tabPage7.Location = new System.Drawing.Point(4, 24);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(510, 334);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Step2";
            this.tabPage7.UseVisualStyleBackColor = true;
            this.tabPage7.Enter += new System.EventHandler(this.tabPage7_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.E_Wafer_Circularity_Max);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.E_Wafer_Circularity_Min);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(12, 106);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(240, 89);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "參數";
            // 
            // E_Wafer_Circularity_Max
            // 
            this.E_Wafer_Circularity_Max.Location = new System.Drawing.Point(189, 53);
            this.E_Wafer_Circularity_Max.Margin = new System.Windows.Forms.Padding(2);
            this.E_Wafer_Circularity_Max.Name = "E_Wafer_Circularity_Max";
            this.E_Wafer_Circularity_Max.Size = new System.Drawing.Size(36, 24);
            this.E_Wafer_Circularity_Max.TabIndex = 4;
            this.E_Wafer_Circularity_Max.Text = "0.5";
            this.E_Wafer_Circularity_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 58);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "Wafer Circularity Max";
            // 
            // E_Wafer_Circularity_Min
            // 
            this.E_Wafer_Circularity_Min.Location = new System.Drawing.Point(187, 22);
            this.E_Wafer_Circularity_Min.Margin = new System.Windows.Forms.Padding(2);
            this.E_Wafer_Circularity_Min.Name = "E_Wafer_Circularity_Min";
            this.E_Wafer_Circularity_Min.Size = new System.Drawing.Size(38, 24);
            this.E_Wafer_Circularity_Min.TabIndex = 1;
            this.E_Wafer_Circularity_Min.Text = "0.5";
            this.E_Wafer_Circularity_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "Wafer Circularity Min";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.GreenYellow;
            this.button6.Location = new System.Drawing.Point(159, 200);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 36);
            this.button6.TabIndex = 21;
            this.button6.Text = "更新";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.B_Update_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(316, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 20;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.E_Erosion_Circle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.E_Dilation_Circle);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(240, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "參數";
            // 
            // E_Erosion_Circle
            // 
            this.E_Erosion_Circle.Location = new System.Drawing.Point(186, 54);
            this.E_Erosion_Circle.Margin = new System.Windows.Forms.Padding(2);
            this.E_Erosion_Circle.Name = "E_Erosion_Circle";
            this.E_Erosion_Circle.Size = new System.Drawing.Size(39, 24);
            this.E_Erosion_Circle.TabIndex = 4;
            this.E_Erosion_Circle.Text = "255";
            this.E_Erosion_Circle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Erosion Circle";
            // 
            // E_Dilation_Circle
            // 
            this.E_Dilation_Circle.Location = new System.Drawing.Point(186, 23);
            this.E_Dilation_Circle.Margin = new System.Windows.Forms.Padding(2);
            this.E_Dilation_Circle.Name = "E_Dilation_Circle";
            this.E_Dilation_Circle.Size = new System.Drawing.Size(39, 24);
            this.E_Dilation_Circle.TabIndex = 1;
            this.E_Dilation_Circle.Text = "255";
            this.E_Dilation_Circle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dilation Circle";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(510, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step3";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(166, 78);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 36);
            this.button1.TabIndex = 25;
            this.button1.Text = "更新";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.B_Update_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.E_Wafer_Circle);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Location = new System.Drawing.Point(19, 15);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(240, 58);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "參數";
            // 
            // E_Wafer_Circle
            // 
            this.E_Wafer_Circle.Location = new System.Drawing.Point(159, 22);
            this.E_Wafer_Circle.Margin = new System.Windows.Forms.Padding(2);
            this.E_Wafer_Circle.Name = "E_Wafer_Circle";
            this.E_Wafer_Circle.Size = new System.Drawing.Size(66, 24);
            this.E_Wafer_Circle.TabIndex = 1;
            this.E_Wafer_Circle.Text = "300";
            this.E_Wafer_Circle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 26);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "Wafer Circle";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(332, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 36);
            this.button3.TabIndex = 20;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.CB_Natch_Filter);
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(510, 334);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step4";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Enter += new System.EventHandler(this.tabPage4_Enter);
            // 
            // TV_Region_Info
            // 
            this.TV_Region_Info.Location = new System.Drawing.Point(21, 45);
            this.TV_Region_Info.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TV_Region_Info.Name = "TV_Region_Info";
            this.TV_Region_Info.Size = new System.Drawing.Size(255, 283);
            this.TV_Region_Info.TabIndex = 29;
            // 
            // B_Get_Region_Info
            // 
            this.B_Get_Region_Info.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Get_Region_Info.Location = new System.Drawing.Point(21, 15);
            this.B_Get_Region_Info.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Get_Region_Info.Name = "B_Get_Region_Info";
            this.B_Get_Region_Info.Size = new System.Drawing.Size(86, 26);
            this.B_Get_Region_Info.TabIndex = 28;
            this.B_Get_Region_Info.Text = "取得資訊";
            this.B_Get_Region_Info.UseVisualStyleBackColor = true;
            this.B_Get_Region_Info.Click += new System.EventHandler(this.B_Get_Region_Info_Click);
            // 
            // CB_Natch_Filter
            // 
            this.CB_Natch_Filter.AutoSize = true;
            this.CB_Natch_Filter.Location = new System.Drawing.Point(17, 20);
            this.CB_Natch_Filter.Name = "CB_Natch_Filter";
            this.CB_Natch_Filter.Size = new System.Drawing.Size(89, 18);
            this.CB_Natch_Filter.TabIndex = 27;
            this.CB_Natch_Filter.Text = "CB_Filter";
            this.CB_Natch_Filter.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.GreenYellow;
            this.button7.Location = new System.Drawing.Point(160, 244);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 36);
            this.button7.TabIndex = 26;
            this.button7.Text = "更新";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.B_Update_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Orange;
            this.button4.Location = new System.Drawing.Point(346, 17);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 36);
            this.button4.TabIndex = 20;
            this.button4.Text = "下一步 =>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.B_Next1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.E_Natch_Erosion_Circle);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.E_Natch_Compactness_Max);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.E_Natch_Compactness_Min);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.E_Natch_Area_Max);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.E_Natch_Area_Min);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(15, 50);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(238, 189);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "參數";
            // 
            // E_Natch_Erosion_Circle
            // 
            this.E_Natch_Erosion_Circle.Location = new System.Drawing.Point(174, 21);
            this.E_Natch_Erosion_Circle.Margin = new System.Windows.Forms.Padding(2);
            this.E_Natch_Erosion_Circle.Name = "E_Natch_Erosion_Circle";
            this.E_Natch_Erosion_Circle.Size = new System.Drawing.Size(50, 24);
            this.E_Natch_Erosion_Circle.TabIndex = 10;
            this.E_Natch_Erosion_Circle.Text = "1.0";
            this.E_Natch_Erosion_Circle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Erosion Circle";
            // 
            // E_Natch_Compactness_Max
            // 
            this.E_Natch_Compactness_Max.Location = new System.Drawing.Point(174, 145);
            this.E_Natch_Compactness_Max.Margin = new System.Windows.Forms.Padding(2);
            this.E_Natch_Compactness_Max.Name = "E_Natch_Compactness_Max";
            this.E_Natch_Compactness_Max.Size = new System.Drawing.Size(50, 24);
            this.E_Natch_Compactness_Max.TabIndex = 8;
            this.E_Natch_Compactness_Max.Text = "0.01";
            this.E_Natch_Compactness_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 148);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 14);
            this.label9.TabIndex = 7;
            this.label9.Text = "Compactness Max";
            // 
            // E_Natch_Compactness_Min
            // 
            this.E_Natch_Compactness_Min.Location = new System.Drawing.Point(174, 114);
            this.E_Natch_Compactness_Min.Margin = new System.Windows.Forms.Padding(2);
            this.E_Natch_Compactness_Min.Name = "E_Natch_Compactness_Min";
            this.E_Natch_Compactness_Min.Size = new System.Drawing.Size(50, 24);
            this.E_Natch_Compactness_Min.TabIndex = 6;
            this.E_Natch_Compactness_Min.Text = "0.01";
            this.E_Natch_Compactness_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 117);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 14);
            this.label10.TabIndex = 5;
            this.label10.Text = "Compactness Min";
            // 
            // E_Natch_Area_Max
            // 
            this.E_Natch_Area_Max.Location = new System.Drawing.Point(174, 80);
            this.E_Natch_Area_Max.Margin = new System.Windows.Forms.Padding(2);
            this.E_Natch_Area_Max.Name = "E_Natch_Area_Max";
            this.E_Natch_Area_Max.Size = new System.Drawing.Size(50, 24);
            this.E_Natch_Area_Max.TabIndex = 4;
            this.E_Natch_Area_Max.Text = "255";
            this.E_Natch_Area_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 83);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 14);
            this.label7.TabIndex = 3;
            this.label7.Text = "Area Max";
            // 
            // E_Natch_Area_Min
            // 
            this.E_Natch_Area_Min.Location = new System.Drawing.Point(174, 49);
            this.E_Natch_Area_Min.Margin = new System.Windows.Forms.Padding(2);
            this.E_Natch_Area_Min.Name = "E_Natch_Area_Min";
            this.E_Natch_Area_Min.Size = new System.Drawing.Size(50, 24);
            this.E_Natch_Area_Min.TabIndex = 1;
            this.E_Natch_Area_Min.Text = "255";
            this.E_Natch_Area_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "Area Min";
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button5);
            this.tabPage6.Controls.Add(this.B_Finish);
            this.tabPage6.Controls.Add(this.button11);
            this.tabPage6.Controls.Add(this.button10);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(510, 334);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Step5";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.Enter += new System.EventHandler(this.tabPage6_Enter);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orange;
            this.button5.Location = new System.Drawing.Point(317, 12);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 36);
            this.button5.TabIndex = 20;
            this.button5.Text = "下一步 =>";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // B_Finish
            // 
            this.B_Finish.BackColor = System.Drawing.Color.Green;
            this.B_Finish.Location = new System.Drawing.Point(22, 140);
            this.B_Finish.Margin = new System.Windows.Forms.Padding(2);
            this.B_Finish.Name = "B_Finish";
            this.B_Finish.Size = new System.Drawing.Size(83, 36);
            this.B_Finish.TabIndex = 6;
            this.B_Finish.Text = "完成";
            this.B_Finish.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(22, 78);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(83, 36);
            this.button11.TabIndex = 5;
            this.button11.Text = "測試標靶";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(22, 22);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(83, 36);
            this.button10.TabIndex = 4;
            this.button10.Text = "單一取像";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 528);
            this.panel3.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.treeView1.Indent = 24;
            this.treeView1.ItemHeight = 32;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "@.選取舊標靶";
            treeNode2.Name = "Node2";
            treeNode2.Text = "1.設定建立標靶參數";
            treeNode3.Name = "Node4";
            treeNode3.Text = "2.選取範圍";
            treeNode4.Name = "Node3";
            treeNode4.Text = "@.建立新標靶";
            treeNode5.Name = "Node7";
            treeNode5.Text = "Step 1.建立標靶";
            treeNode6.Name = "Node6";
            treeNode6.Text = "Step 2.設定搜尋參數";
            treeNode7.Name = "Node5";
            treeNode7.Text = "Step 3.設定搜尋範圍";
            treeNode8.Name = "Node8";
            treeNode8.Text = "Step 4.測試標靶";
            treeNode9.Name = "Node0";
            treeNode9.Text = "步驟";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(215, 528);
            this.treeView1.TabIndex = 2;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(0, 0);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(499, 528);
            this.tFrame_JJS_HW1.TabIndex = 0;
            // 
            // TForm_Find_Natch_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 587);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Find_Natch_1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.TForm_Find_Natch_1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Space.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button B_Finish;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.HScrollBar SB_Threshold_Max;
        private System.Windows.Forms.TextBox E_Threshold_Max;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar SB_Threshold_Min;
        private System.Windows.Forms.TextBox E_Threshold_Min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox E_Erosion_Circle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Dilation_Circle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox E_Natch_Compactness_Max;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox E_Natch_Compactness_Min;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox E_Natch_Area_Max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox E_Natch_Area_Min;
        private System.Windows.Forms.Label label8;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Button B_Next2;
        private System.Windows.Forms.TabPage TP_Space;
        private System.Windows.Forms.Button B_Next1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button B_Update1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox E_Wafer_Circularity_Max;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox E_Wafer_Circularity_Min;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox E_Wafer_Circle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox CB_Natch_Filter;
        private System.Windows.Forms.TreeView TV_Region_Info;
        private System.Windows.Forms.Button B_Get_Region_Info;
        private System.Windows.Forms.TextBox E_Natch_Erosion_Circle;
        private System.Windows.Forms.Label label5;
    }
}