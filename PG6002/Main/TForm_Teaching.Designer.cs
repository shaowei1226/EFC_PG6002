namespace Main
{
     partial class TForm_Teaching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Teaching));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("1.編輯標靶(Setting Model)");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("2.校驗(Teahing)");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("3.校驗資訊(Teach_message)");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("1.PCB", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.Tool_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.B_Save_As = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.TC_Main_01 = new System.Windows.Forms.TabControl();
            this.TP_Space = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.B_Model_L_Edit = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.E_CCD_Ofs_Y = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.E_CCD_Ofs_X = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.E_Q_TX = new System.Windows.Forms.TextBox();
            this.E_Q_TY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Q_CCD_Y = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.E_Q1_Col = new System.Windows.Forms.TextBox();
            this.E_Q2_Row = new System.Windows.Forms.TextBox();
            this.E_Q2_Col = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.E_Q2_Pos = new System.Windows.Forms.TextBox();
            this.B_Q2 = new System.Windows.Forms.Button();
            this.E_Q1_Pos = new System.Windows.Forms.TextBox();
            this.E_Q1_Row = new System.Windows.Forms.TextBox();
            this.B_Q1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.E_Cal_Data_Center_Y = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.E_Cal_Data_Center_X = new System.Windows.Forms.TextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.L_Tree_Info = new System.Windows.Forms.Label();
            this.TV_Menu = new System.Windows.Forms.TreeView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tFrame_Display1 = new Main.TFrame_Display();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.TC_Main_01.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Open);
            this.panel1.Controls.Add(this.B_Save_As);
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1466, 64);
            this.panel1.TabIndex = 48;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.ImageIndex = 3;
            this.B_Open.ImageList = this.Tool_ImageList;
            this.B_Open.Location = new System.Drawing.Point(420, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(140, 64);
            this.B_Open.TabIndex = 16;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.UseVisualStyleBackColor = false;
            this.B_Open.Visible = false;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
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
            // B_Save_As
            // 
            this.B_Save_As.BackColor = System.Drawing.Color.White;
            this.B_Save_As.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save_As.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Save_As.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save_As.ImageIndex = 2;
            this.B_Save_As.ImageList = this.Tool_ImageList;
            this.B_Save_As.Location = new System.Drawing.Point(280, 0);
            this.B_Save_As.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.B_Save_As.Name = "B_Save_As";
            this.B_Save_As.Size = new System.Drawing.Size(140, 64);
            this.B_Save_As.TabIndex = 15;
            this.B_Save_As.Text = "另存檔案";
            this.B_Save_As.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Save_As.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Save_As.UseVisualStyleBackColor = false;
            this.B_Save_As.Visible = false;
            this.B_Save_As.Click += new System.EventHandler(this.B_Save_As_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageIndex = 1;
            this.B_Cancel.ImageList = this.Tool_ImageList;
            this.B_Cancel.Location = new System.Drawing.Point(140, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(140, 64);
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
            this.B_Apply.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.ImageIndex = 0;
            this.B_Apply.ImageList = this.Tool_ImageList;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(140, 64);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.TV_Menu);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(792, 586);
            this.panel2.TabIndex = 49;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TC_Main_01);
            this.panel5.Controls.Add(this.panel15);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(300, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(492, 586);
            this.panel5.TabIndex = 54;
            // 
            // TC_Main_01
            // 
            this.TC_Main_01.Controls.Add(this.TP_Space);
            this.TC_Main_01.Controls.Add(this.tabPage4);
            this.TC_Main_01.Controls.Add(this.tabPage2);
            this.TC_Main_01.Controls.Add(this.tabPage3);
            this.TC_Main_01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC_Main_01.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TC_Main_01.Location = new System.Drawing.Point(0, 69);
            this.TC_Main_01.Margin = new System.Windows.Forms.Padding(4);
            this.TC_Main_01.Name = "TC_Main_01";
            this.TC_Main_01.SelectedIndex = 0;
            this.TC_Main_01.Size = new System.Drawing.Size(492, 517);
            this.TC_Main_01.TabIndex = 19;
            // 
            // TP_Space
            // 
            this.TP_Space.BackColor = System.Drawing.Color.White;
            this.TP_Space.Location = new System.Drawing.Point(4, 26);
            this.TP_Space.Margin = new System.Windows.Forms.Padding(4);
            this.TP_Space.Name = "TP_Space";
            this.TP_Space.Size = new System.Drawing.Size(484, 487);
            this.TP_Space.TabIndex = 11;
            this.TP_Space.Text = "空白";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(484, 487);
            this.tabPage4.TabIndex = 14;
            this.tabPage4.Text = "編輯標靶";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.B_Model_L_Edit);
            this.groupBox2.Location = new System.Drawing.Point(26, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(250, 94);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ 標靶 ]";
            // 
            // B_Model_L_Edit
            // 
            this.B_Model_L_Edit.BackColor = System.Drawing.Color.Transparent;
            this.B_Model_L_Edit.Location = new System.Drawing.Point(30, 25);
            this.B_Model_L_Edit.Margin = new System.Windows.Forms.Padding(4);
            this.B_Model_L_Edit.Name = "B_Model_L_Edit";
            this.B_Model_L_Edit.Size = new System.Drawing.Size(190, 60);
            this.B_Model_L_Edit.TabIndex = 18;
            this.B_Model_L_Edit.Text = "編輯標靶(Setting Model)";
            this.B_Model_L_Edit.UseVisualStyleBackColor = false;
            this.B_Model_L_Edit.Click += new System.EventHandler(this.B_Model_L_Edit_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(484, 487);
            this.tabPage2.TabIndex = 12;
            this.tabPage2.Text = "校驗";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.E_CCD_Ofs_Y);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.E_CCD_Ofs_X);
            this.groupBox1.Location = new System.Drawing.Point(11, 243);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(175, 103);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ CCD Ofs ]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 67);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "Y";
            // 
            // E_CCD_Ofs_Y
            // 
            this.E_CCD_Ofs_Y.BackColor = System.Drawing.SystemColors.Window;
            this.E_CCD_Ofs_Y.Enabled = false;
            this.E_CCD_Ofs_Y.Location = new System.Drawing.Point(66, 60);
            this.E_CCD_Ofs_Y.Margin = new System.Windows.Forms.Padding(4);
            this.E_CCD_Ofs_Y.Name = "E_CCD_Ofs_Y";
            this.E_CCD_Ofs_Y.Size = new System.Drawing.Size(88, 27);
            this.E_CCD_Ofs_Y.TabIndex = 14;
            this.E_CCD_Ofs_Y.Text = "0.000";
            this.E_CCD_Ofs_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "X";
            // 
            // E_CCD_Ofs_X
            // 
            this.E_CCD_Ofs_X.BackColor = System.Drawing.SystemColors.Window;
            this.E_CCD_Ofs_X.Enabled = false;
            this.E_CCD_Ofs_X.Location = new System.Drawing.Point(66, 25);
            this.E_CCD_Ofs_X.Margin = new System.Windows.Forms.Padding(4);
            this.E_CCD_Ofs_X.Name = "E_CCD_Ofs_X";
            this.E_CCD_Ofs_X.Size = new System.Drawing.Size(88, 27);
            this.E_CCD_Ofs_X.TabIndex = 12;
            this.E_CCD_Ofs_X.Text = "0.000";
            this.E_CCD_Ofs_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.E_Q_TX);
            this.groupBox3.Controls.Add(this.E_Q_TY);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.E_Q_CCD_Y);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(10, 148);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(316, 89);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ Base Pos ]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "載台X";
            // 
            // E_Q_TX
            // 
            this.E_Q_TX.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q_TX.Enabled = false;
            this.E_Q_TX.Location = new System.Drawing.Point(16, 50);
            this.E_Q_TX.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q_TX.Name = "E_Q_TX";
            this.E_Q_TX.Size = new System.Drawing.Size(88, 27);
            this.E_Q_TX.TabIndex = 12;
            this.E_Q_TX.Text = "0.000";
            this.E_Q_TX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Q_TY
            // 
            this.E_Q_TY.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q_TY.Enabled = false;
            this.E_Q_TY.Location = new System.Drawing.Point(111, 50);
            this.E_Q_TY.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q_TY.Name = "E_Q_TY";
            this.E_Q_TY.Size = new System.Drawing.Size(88, 27);
            this.E_Q_TY.TabIndex = 14;
            this.E_Q_TY.Text = "0.000";
            this.E_Q_TY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(121, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "載台Y";
            // 
            // E_Q_CCD_Y
            // 
            this.E_Q_CCD_Y.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q_CCD_Y.Enabled = false;
            this.E_Q_CCD_Y.Location = new System.Drawing.Point(209, 50);
            this.E_Q_CCD_Y.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q_CCD_Y.Name = "E_Q_CCD_Y";
            this.E_Q_CCD_Y.Size = new System.Drawing.Size(88, 27);
            this.E_Q_CCD_Y.TabIndex = 16;
            this.E_Q_CCD_Y.Text = "0.000";
            this.E_Q_CCD_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "CCD Y";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.E_Q1_Col);
            this.groupBox4.Controls.Add(this.E_Q2_Row);
            this.groupBox4.Controls.Add(this.E_Q2_Col);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.E_Q2_Pos);
            this.groupBox4.Controls.Add(this.B_Q2);
            this.groupBox4.Controls.Add(this.E_Q1_Pos);
            this.groupBox4.Controls.Add(this.E_Q1_Row);
            this.groupBox4.Controls.Add(this.B_Q1);
            this.groupBox4.Location = new System.Drawing.Point(10, 8);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(456, 135);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[ 鏡頭 ]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(299, 21);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 16);
            this.label14.TabIndex = 14;
            this.label14.Text = "Pos";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(201, 21);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 16);
            this.label15.TabIndex = 13;
            this.label15.Text = "Row";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(109, 21);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 16);
            this.label16.TabIndex = 12;
            this.label16.Text = "Col";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 52);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Q(-)";
            // 
            // E_Q1_Col
            // 
            this.E_Q1_Col.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q1_Col.Enabled = false;
            this.E_Q1_Col.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.E_Q1_Col.Location = new System.Drawing.Point(86, 47);
            this.E_Q1_Col.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q1_Col.Name = "E_Q1_Col";
            this.E_Q1_Col.Size = new System.Drawing.Size(88, 27);
            this.E_Q1_Col.TabIndex = 1;
            this.E_Q1_Col.Text = "0.000";
            this.E_Q1_Col.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Q2_Row
            // 
            this.E_Q2_Row.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q2_Row.Enabled = false;
            this.E_Q2_Row.Location = new System.Drawing.Point(181, 79);
            this.E_Q2_Row.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q2_Row.Name = "E_Q2_Row";
            this.E_Q2_Row.Size = new System.Drawing.Size(88, 27);
            this.E_Q2_Row.TabIndex = 10;
            this.E_Q2_Row.Text = "0.000";
            this.E_Q2_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Q2_Col
            // 
            this.E_Q2_Col.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q2_Col.Enabled = false;
            this.E_Q2_Col.Location = new System.Drawing.Point(86, 79);
            this.E_Q2_Col.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q2_Col.Name = "E_Q2_Col";
            this.E_Q2_Col.Size = new System.Drawing.Size(88, 27);
            this.E_Q2_Col.TabIndex = 8;
            this.E_Q2_Col.Text = "0.000";
            this.E_Q2_Col.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 84);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Q(+)";
            // 
            // E_Q2_Pos
            // 
            this.E_Q2_Pos.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q2_Pos.Enabled = false;
            this.E_Q2_Pos.Location = new System.Drawing.Point(279, 79);
            this.E_Q2_Pos.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q2_Pos.Name = "E_Q2_Pos";
            this.E_Q2_Pos.Size = new System.Drawing.Size(88, 27);
            this.E_Q2_Pos.TabIndex = 11;
            this.E_Q2_Pos.Text = "0.000";
            this.E_Q2_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B_Q2
            // 
            this.B_Q2.Location = new System.Drawing.Point(375, 79);
            this.B_Q2.Margin = new System.Windows.Forms.Padding(4);
            this.B_Q2.Name = "B_Q2";
            this.B_Q2.Size = new System.Drawing.Size(61, 47);
            this.B_Q2.TabIndex = 7;
            this.B_Q2.Text = "Q+";
            this.B_Q2.UseVisualStyleBackColor = true;
            this.B_Q2.Click += new System.EventHandler(this.B_Q2_Click);
            // 
            // E_Q1_Pos
            // 
            this.E_Q1_Pos.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q1_Pos.Enabled = false;
            this.E_Q1_Pos.Location = new System.Drawing.Point(279, 47);
            this.E_Q1_Pos.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q1_Pos.Name = "E_Q1_Pos";
            this.E_Q1_Pos.Size = new System.Drawing.Size(88, 27);
            this.E_Q1_Pos.TabIndex = 6;
            this.E_Q1_Pos.Text = "0.000";
            this.E_Q1_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Q1_Row
            // 
            this.E_Q1_Row.BackColor = System.Drawing.SystemColors.Window;
            this.E_Q1_Row.Enabled = false;
            this.E_Q1_Row.Location = new System.Drawing.Point(181, 47);
            this.E_Q1_Row.Margin = new System.Windows.Forms.Padding(4);
            this.E_Q1_Row.Name = "E_Q1_Row";
            this.E_Q1_Row.Size = new System.Drawing.Size(88, 27);
            this.E_Q1_Row.TabIndex = 4;
            this.E_Q1_Row.Text = "0.000";
            this.E_Q1_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B_Q1
            // 
            this.B_Q1.Location = new System.Drawing.Point(375, 27);
            this.B_Q1.Margin = new System.Windows.Forms.Padding(4);
            this.B_Q1.Name = "B_Q1";
            this.B_Q1.Size = new System.Drawing.Size(61, 47);
            this.B_Q1.TabIndex = 6;
            this.B_Q1.Text = "Q-";
            this.B_Q1.UseVisualStyleBackColor = true;
            this.B_Q1.Click += new System.EventHandler(this.B_Q1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(484, 487);
            this.tabPage3.TabIndex = 13;
            this.tabPage3.Text = "校驗資訊";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.textBox22);
            this.groupBox5.Controls.Add(this.E_Cal_Data_Center_Y);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.E_Cal_Data_Center_X);
            this.groupBox5.Location = new System.Drawing.Point(6, 5);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.groupBox5.Size = new System.Drawing.Size(462, 127);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "[圓心資訊]";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Silver;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(211, 86);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(241, 27);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "計算出來之旋轉中心Y";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 90);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "Center Y";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(230, 25);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(92, 16);
            this.label30.TabIndex = 7;
            this.label30.Text = "說          明";
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.Silver;
            this.textBox22.Enabled = false;
            this.textBox22.Location = new System.Drawing.Point(211, 50);
            this.textBox22.Margin = new System.Windows.Forms.Padding(4);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(241, 27);
            this.textBox22.TabIndex = 6;
            this.textBox22.Text = "計算出來之旋轉中心X";
            // 
            // E_Cal_Data_Center_Y
            // 
            this.E_Cal_Data_Center_Y.BackColor = System.Drawing.Color.Silver;
            this.E_Cal_Data_Center_Y.Enabled = false;
            this.E_Cal_Data_Center_Y.Location = new System.Drawing.Point(110, 86);
            this.E_Cal_Data_Center_Y.Margin = new System.Windows.Forms.Padding(4);
            this.E_Cal_Data_Center_Y.Name = "E_Cal_Data_Center_Y";
            this.E_Cal_Data_Center_Y.Size = new System.Drawing.Size(92, 27);
            this.E_Cal_Data_Center_Y.TabIndex = 4;
            this.E_Cal_Data_Center_Y.Text = "123.456";
            this.E_Cal_Data_Center_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Center X";
            // 
            // E_Cal_Data_Center_X
            // 
            this.E_Cal_Data_Center_X.BackColor = System.Drawing.Color.Silver;
            this.E_Cal_Data_Center_X.Enabled = false;
            this.E_Cal_Data_Center_X.Location = new System.Drawing.Point(110, 50);
            this.E_Cal_Data_Center_X.Margin = new System.Windows.Forms.Padding(4);
            this.E_Cal_Data_Center_X.Name = "E_Cal_Data_Center_X";
            this.E_Cal_Data_Center_X.Size = new System.Drawing.Size(91, 27);
            this.E_Cal_Data_Center_X.TabIndex = 1;
            this.E_Cal_Data_Center_X.Text = "123.456";
            this.E_Cal_Data_Center_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.Moccasin;
            this.panel15.Controls.Add(this.L_Tree_Info);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(492, 69);
            this.panel15.TabIndex = 50;
            // 
            // L_Tree_Info
            // 
            this.L_Tree_Info.AutoSize = true;
            this.L_Tree_Info.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_Tree_Info.Location = new System.Drawing.Point(1, 13);
            this.L_Tree_Info.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.L_Tree_Info.Name = "L_Tree_Info";
            this.L_Tree_Info.Size = new System.Drawing.Size(87, 42);
            this.L_Tree_Info.TabIndex = 0;
            this.L_Tree_Info.Text = "Root";
            // 
            // TV_Menu
            // 
            this.TV_Menu.BackColor = System.Drawing.Color.White;
            this.TV_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.TV_Menu.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TV_Menu.Indent = 32;
            this.TV_Menu.ItemHeight = 32;
            this.TV_Menu.Location = new System.Drawing.Point(0, 0);
            this.TV_Menu.Margin = new System.Windows.Forms.Padding(4);
            this.TV_Menu.Name = "TV_Menu";
            treeNode1.Name = "Edit_Model";
            treeNode1.Text = "1.編輯標靶(Setting Model)";
            treeNode2.Name = "Teach";
            treeNode2.Text = "2.校驗(Teahing)";
            treeNode3.Name = "Result";
            treeNode3.Text = "3.校驗資訊(Teach_message)";
            treeNode4.Name = "PCB";
            treeNode4.Text = "1.PCB";
            treeNode5.Name = "Root";
            treeNode5.Text = "Root";
            this.TV_Menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.TV_Menu.Size = new System.Drawing.Size(300, 586);
            this.TV_Menu.TabIndex = 10;
            this.TV_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Menu_AfterSelect);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tFrame_Display1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(792, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(674, 586);
            this.panel4.TabIndex = 53;
            // 
            // tFrame_Display1
            // 
            this.tFrame_Display1.BackColor = System.Drawing.Color.DimGray;
            this.tFrame_Display1.Disp_Enabled = false;
            this.tFrame_Display1.Location = new System.Drawing.Point(28, 34);
            this.tFrame_Display1.Margin = new System.Windows.Forms.Padding(2);
            this.tFrame_Display1.Name = "tFrame_Display1";
            this.tFrame_Display1.Size = new System.Drawing.Size(214, 201);
            this.tFrame_Display1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1466, 586);
            this.panel3.TabIndex = 54;
            // 
            // TForm_Teaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 650);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_Teaching";
            this.Text = "TForm_Teaching";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TForm_Teaching_FormClosed);
            this.Load += new System.EventHandler(this.TForm_Teaching_Load);
            this.Shown += new System.EventHandler(this.TForm_Teaching_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.TC_Main_01.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.Button B_Cancel;
          private System.Windows.Forms.Button B_Apply;
          private System.Windows.Forms.Panel panel2;
          private System.Windows.Forms.TreeView TV_Menu;
          private System.Windows.Forms.Panel panel15;
          private System.Windows.Forms.Label L_Tree_Info;
          private System.Windows.Forms.TabControl TC_Main_01;
          private System.Windows.Forms.TabPage TP_Space;
          private System.Windows.Forms.Panel panel4;
          private System.Windows.Forms.TabPage tabPage2;
          private System.Windows.Forms.TabPage tabPage3;
          private System.Windows.Forms.Button B_Open;
          private System.Windows.Forms.Button B_Save_As;
          private System.Windows.Forms.Button B_Q2;
          private System.Windows.Forms.Button B_Q1;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.TextBox E_Q_CCD_Y;
          private System.Windows.Forms.Label label5;
          private System.Windows.Forms.TextBox E_Q_TY;
          private System.Windows.Forms.Label label4;
          private System.Windows.Forms.TextBox E_Q_TX;
          private System.Windows.Forms.TextBox E_Q2_Pos;
          private System.Windows.Forms.TextBox E_Q2_Row;
          private System.Windows.Forms.Label label6;
          private System.Windows.Forms.TextBox E_Q2_Col;
          private System.Windows.Forms.TextBox E_Q1_Pos;
          private System.Windows.Forms.TextBox E_Q1_Row;
          private System.Windows.Forms.Label label10;
          private System.Windows.Forms.TextBox E_Q1_Col;
          private System.Windows.Forms.Button B_Model_L_Edit;
          private System.Windows.Forms.GroupBox groupBox5;
          private System.Windows.Forms.Label label30;
          private System.Windows.Forms.TextBox textBox22;
          private System.Windows.Forms.TextBox E_Cal_Data_Center_Y;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.TextBox E_Cal_Data_Center_X;
          private System.Windows.Forms.GroupBox groupBox4;
          private System.Windows.Forms.Label label14;
          private System.Windows.Forms.Label label15;
          private System.Windows.Forms.Label label16;
          private System.Windows.Forms.GroupBox groupBox3;
          private System.Windows.Forms.TabPage tabPage4;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.Label label8;
          private System.Windows.Forms.TextBox E_CCD_Ofs_Y;
          private System.Windows.Forms.Label label7;
          private System.Windows.Forms.TextBox E_CCD_Ofs_X;
          private System.Windows.Forms.ImageList Tool_ImageList;
          private System.Windows.Forms.Panel panel5;
          private System.Windows.Forms.Panel panel3;
          private System.Windows.Forms.GroupBox groupBox2;
          private System.Windows.Forms.TextBox textBox2;
          private System.Windows.Forms.Label label12;
          private TFrame_Display tFrame_Display1;
     }
}