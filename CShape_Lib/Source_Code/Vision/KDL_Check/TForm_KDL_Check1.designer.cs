namespace EFC.Vision.Halcon
{
    partial class TForm_KDL_Check1
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.B_Next = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.B_Param_Update = new System.Windows.Forms.Button();
            this.E_Std_Ofs = new System.Windows.Forms.TextBox();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.E_Base_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Trans_Image = new System.Windows.Forms.Button();
            this.B_Trans_Image = new System.Windows.Forms.Button();
            this.E_Trans_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Base_Image = new System.Windows.Forms.Button();
            this.E_Edit_Find_Region = new System.Windows.Forms.Button();
            this.CB_Used_Align_Image = new System.Windows.Forms.CheckBox();
            this.B_Edit_Model_Param = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LB_Process = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(891, 59);
            this.panel1.TabIndex = 1;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.Image = global::EFC.Vision.Halcon.Properties.Resources.hard_drive_upload;
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.Location = new System.Drawing.Point(360, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(120, 59);
            this.B_Open.TabIndex = 8;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Open.UseVisualStyleBackColor = false;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // B_Save
            // 
            this.B_Save.BackColor = System.Drawing.Color.White;
            this.B_Save.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save.Image = global::EFC.Vision.Halcon.Properties.Resources.hard_drive_download;
            this.B_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save.Location = new System.Drawing.Point(240, 0);
            this.B_Save.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(120, 59);
            this.B_Save.TabIndex = 7;
            this.B_Save.Text = "另存檔案";
            this.B_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Save.UseVisualStyleBackColor = false;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.Image = global::EFC.Vision.Halcon.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(120, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(120, 59);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
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
            this.B_Apply.Size = new System.Drawing.Size(120, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(212, 59);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 603);
            this.panel6.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 603);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_Next);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(367, 575);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "空白";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(187, 5);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(93, 36);
            this.B_Next.TabIndex = 18;
            this.B_Next.Text = "下一步 =>";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.B_Base_Image);
            this.tabPage2.Controls.Add(this.E_Base_Image_File);
            this.tabPage2.Controls.Add(this.B_Select_Trans_Image);
            this.tabPage2.Controls.Add(this.B_Trans_Image);
            this.tabPage2.Controls.Add(this.E_Trans_Image_File);
            this.tabPage2.Controls.Add(this.B_Select_Base_Image);
            this.tabPage2.Controls.Add(this.E_Edit_Find_Region);
            this.tabPage2.Controls.Add(this.CB_Used_Align_Image);
            this.tabPage2.Controls.Add(this.B_Edit_Model_Param);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(367, 575);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step1";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.B_Param_Update);
            this.groupBox1.Controls.Add(this.E_Std_Ofs);
            this.groupBox1.Location = new System.Drawing.Point(172, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 79);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "Std Ofs";
            // 
            // B_Param_Update
            // 
            this.B_Param_Update.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Param_Update.Location = new System.Drawing.Point(15, 46);
            this.B_Param_Update.Margin = new System.Windows.Forms.Padding(2);
            this.B_Param_Update.Name = "B_Param_Update";
            this.B_Param_Update.Size = new System.Drawing.Size(98, 25);
            this.B_Param_Update.TabIndex = 33;
            this.B_Param_Update.Text = "Update";
            this.B_Param_Update.UseVisualStyleBackColor = true;
            this.B_Param_Update.Click += new System.EventHandler(this.B_Param_Update_Click);
            // 
            // E_Std_Ofs
            // 
            this.E_Std_Ofs.Location = new System.Drawing.Point(72, 17);
            this.E_Std_Ofs.Name = "E_Std_Ofs";
            this.E_Std_Ofs.Size = new System.Drawing.Size(41, 24);
            this.E_Std_Ofs.TabIndex = 31;
            this.E_Std_Ofs.Text = "1.0";
            this.E_Std_Ofs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(14, 49);
            this.B_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Base_Image.TabIndex = 25;
            this.B_Base_Image.Text = "Base Image";
            this.B_Base_Image.UseVisualStyleBackColor = true;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // E_Base_Image_File
            // 
            this.E_Base_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Image_File.Location = new System.Drawing.Point(14, 102);
            this.E_Base_Image_File.Margin = new System.Windows.Forms.Padding(2);
            this.E_Base_Image_File.Name = "E_Base_Image_File";
            this.E_Base_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Base_Image_File.TabIndex = 27;
            // 
            // B_Select_Trans_Image
            // 
            this.B_Select_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Trans_Image.Location = new System.Drawing.Point(232, 209);
            this.B_Select_Trans_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Trans_Image.Name = "B_Select_Trans_Image";
            this.B_Select_Trans_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Trans_Image.TabIndex = 30;
            this.B_Select_Trans_Image.Text = "...";
            this.B_Select_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Select_Trans_Image.Click += new System.EventHandler(this.B_Select_Trans_Image_Click);
            // 
            // B_Trans_Image
            // 
            this.B_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Trans_Image.Location = new System.Drawing.Point(14, 155);
            this.B_Trans_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Trans_Image.Name = "B_Trans_Image";
            this.B_Trans_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Trans_Image.TabIndex = 26;
            this.B_Trans_Image.Text = "Trans Image";
            this.B_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Trans_Image.Click += new System.EventHandler(this.B_Trans_Image_Click);
            // 
            // E_Trans_Image_File
            // 
            this.E_Trans_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Trans_Image_File.Location = new System.Drawing.Point(14, 209);
            this.E_Trans_Image_File.Margin = new System.Windows.Forms.Padding(2);
            this.E_Trans_Image_File.Name = "E_Trans_Image_File";
            this.E_Trans_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Trans_Image_File.TabIndex = 29;
            // 
            // B_Select_Base_Image
            // 
            this.B_Select_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_Image.Location = new System.Drawing.Point(232, 102);
            this.B_Select_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Base_Image.Name = "B_Select_Base_Image";
            this.B_Select_Base_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Base_Image.TabIndex = 28;
            this.B_Select_Base_Image.Text = "...";
            this.B_Select_Base_Image.UseVisualStyleBackColor = true;
            this.B_Select_Base_Image.Click += new System.EventHandler(this.B_Select_Base_Image_Click);
            // 
            // E_Edit_Find_Region
            // 
            this.E_Edit_Find_Region.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_Edit_Find_Region.Location = new System.Drawing.Point(14, 380);
            this.E_Edit_Find_Region.Margin = new System.Windows.Forms.Padding(2);
            this.E_Edit_Find_Region.Name = "E_Edit_Find_Region";
            this.E_Edit_Find_Region.Size = new System.Drawing.Size(93, 54);
            this.E_Edit_Find_Region.TabIndex = 24;
            this.E_Edit_Find_Region.Text = "編輯搜尋區域";
            this.E_Edit_Find_Region.UseVisualStyleBackColor = false;
            this.E_Edit_Find_Region.Click += new System.EventHandler(this.E_Edit_Find_Region_Click);
            // 
            // CB_Used_Align_Image
            // 
            this.CB_Used_Align_Image.AutoSize = true;
            this.CB_Used_Align_Image.Location = new System.Drawing.Point(14, 268);
            this.CB_Used_Align_Image.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Used_Align_Image.Name = "CB_Used_Align_Image";
            this.CB_Used_Align_Image.Size = new System.Drawing.Size(116, 18);
            this.CB_Used_Align_Image.TabIndex = 23;
            this.CB_Used_Align_Image.Text = "使用校正參數";
            this.CB_Used_Align_Image.UseVisualStyleBackColor = true;
            this.CB_Used_Align_Image.CheckedChanged += new System.EventHandler(this.CB_Used_Find_Model_CheckedChanged);
            // 
            // B_Edit_Model_Param
            // 
            this.B_Edit_Model_Param.BackColor = System.Drawing.Color.LightSteelBlue;
            this.B_Edit_Model_Param.Location = new System.Drawing.Point(14, 296);
            this.B_Edit_Model_Param.Margin = new System.Windows.Forms.Padding(2);
            this.B_Edit_Model_Param.Name = "B_Edit_Model_Param";
            this.B_Edit_Model_Param.Size = new System.Drawing.Size(93, 54);
            this.B_Edit_Model_Param.TabIndex = 22;
            this.B_Edit_Model_Param.Text = "編輯校正參數";
            this.B_Edit_Model_Param.UseVisualStyleBackColor = false;
            this.B_Edit_Model_Param.Click += new System.EventHandler(this.B_Edit_Model_Param_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(187, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 20;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(367, 575);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step2";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(21, 76);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "顯示校正後影像是否正常";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(187, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 36);
            this.button3.TabIndex = 21;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button10);
            this.tabPage5.Controls.Add(this.button9);
            this.tabPage5.Controls.Add(this.button4);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.LB_Process);
            this.tabPage5.Controls.Add(this.button6);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(367, 575);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Step3";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Enter += new System.EventHandler(this.tabPage5_Enter);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button10.Location = new System.Drawing.Point(15, 104);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(140, 32);
            this.button10.TabIndex = 41;
            this.button10.Text = "Sample Image";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button9.Location = new System.Drawing.Point(15, 140);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 32);
            this.button9.TabIndex = 40;
            this.button9.Text = "Result Image";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(15, 68);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 32);
            this.button4.TabIndex = 36;
            this.button4.Text = "Base Image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(11, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 22);
            this.label4.TabIndex = 35;
            this.label4.Text = "影像過濾條件";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Location = new System.Drawing.Point(15, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 54);
            this.button1.TabIndex = 34;
            this.button1.Text = "編輯標靶參數";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LB_Process
            // 
            this.LB_Process.FormattingEnabled = true;
            this.LB_Process.ItemHeight = 14;
            this.LB_Process.Location = new System.Drawing.Point(15, 207);
            this.LB_Process.Margin = new System.Windows.Forms.Padding(2);
            this.LB_Process.Name = "LB_Process";
            this.LB_Process.Size = new System.Drawing.Size(344, 466);
            this.LB_Process.TabIndex = 33;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Orange;
            this.button6.Location = new System.Drawing.Point(187, 5);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 36);
            this.button6.TabIndex = 21;
            this.button6.Text = "下一步 =>";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(367, 575);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step4";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Enter += new System.EventHandler(this.tabPage4_Enter);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Lime;
            this.button7.Location = new System.Drawing.Point(187, 5);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 36);
            this.button7.TabIndex = 25;
            this.button7.Text = "完成";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 59);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(212, 603);
            this.panel5.TabIndex = 2;
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
            this.treeView1.Size = new System.Drawing.Size(212, 603);
            this.treeView1.TabIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "標靶檔(*.mod)|*.mod";
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(587, 59);
            this.tFrame_JJS_HW1.Margin = new System.Windows.Forms.Padding(2);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(304, 603);
            this.tFrame_JJS_HW1.TabIndex = 4;
            // 
            // TForm_KDL_Check1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 662);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_KDL_Check1";
            this.Text = "Form_Find_Mothed_1";
            this.Shown += new System.EventHandler(this.Form_Find_Barcode1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Button B_Edit_Model_Param;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox LB_Process;
        private System.Windows.Forms.CheckBox CB_Used_Align_Image;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button E_Edit_Find_Region;
        private System.Windows.Forms.Button B_Base_Image;
        private System.Windows.Forms.TextBox E_Base_Image_File;
        private System.Windows.Forms.Button B_Select_Trans_Image;
        private System.Windows.Forms.Button B_Trans_Image;
        private System.Windows.Forms.TextBox E_Trans_Image_File;
        private System.Windows.Forms.Button B_Select_Base_Image;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Std_Ofs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Param_Update;
    }
}