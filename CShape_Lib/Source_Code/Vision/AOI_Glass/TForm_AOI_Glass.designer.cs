namespace EFC.Vision.Halcon
{
    partial class TForm_AOI_Glass
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
            this.TabColtrol1 = new System.Windows.Forms.TabControl();
            this.TP_Space = new System.Windows.Forms.TabPage();
            this.B_Next = new System.Windows.Forms.Button();
            this.TP_Step1 = new System.Windows.Forms.TabPage();
            this.B_Select_Sample_Image = new System.Windows.Forms.Button();
            this.B_Sample_Image = new System.Windows.Forms.Button();
            this.E_Sample_Image_File = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.TP_Step2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_Sigma1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Sigma2 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.E_Edit_Find_Region = new System.Windows.Forms.Button();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_Small = new System.Windows.Forms.CheckBox();
            this.CB_Big = new System.Windows.Forms.CheckBox();
            this.RB_Display3 = new System.Windows.Forms.RadioButton();
            this.RB_Display1 = new System.Windows.Forms.RadioButton();
            this.RB_Display2 = new System.Windows.Forms.RadioButton();
            this.B_Big_Param = new System.Windows.Forms.Button();
            this.B_Small_Param = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.TP_Step4 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.TabColtrol1.SuspendLayout();
            this.TP_Space.SuspendLayout();
            this.TP_Step1.SuspendLayout();
            this.TP_Step2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TP_Step3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TP_Step4.SuspendLayout();
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
            this.panel6.Controls.Add(this.TabColtrol1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(212, 59);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 603);
            this.panel6.TabIndex = 3;
            // 
            // TabColtrol1
            // 
            this.TabColtrol1.Controls.Add(this.TP_Space);
            this.TabColtrol1.Controls.Add(this.TP_Step1);
            this.TabColtrol1.Controls.Add(this.TP_Step2);
            this.TabColtrol1.Controls.Add(this.TP_Step3);
            this.TabColtrol1.Controls.Add(this.TP_Step4);
            this.TabColtrol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabColtrol1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TabColtrol1.Location = new System.Drawing.Point(0, 0);
            this.TabColtrol1.Margin = new System.Windows.Forms.Padding(2);
            this.TabColtrol1.Name = "TabColtrol1";
            this.TabColtrol1.SelectedIndex = 0;
            this.TabColtrol1.Size = new System.Drawing.Size(375, 603);
            this.TabColtrol1.TabIndex = 2;
            // 
            // TP_Space
            // 
            this.TP_Space.Controls.Add(this.B_Next);
            this.TP_Space.Location = new System.Drawing.Point(4, 24);
            this.TP_Space.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Space.Name = "TP_Space";
            this.TP_Space.Padding = new System.Windows.Forms.Padding(2);
            this.TP_Space.Size = new System.Drawing.Size(367, 575);
            this.TP_Space.TabIndex = 0;
            this.TP_Space.Text = "空白";
            this.TP_Space.UseVisualStyleBackColor = true;
            this.TP_Space.Enter += new System.EventHandler(this.TP_Space_Enter);
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
            // TP_Step1
            // 
            this.TP_Step1.Controls.Add(this.B_Select_Sample_Image);
            this.TP_Step1.Controls.Add(this.B_Sample_Image);
            this.TP_Step1.Controls.Add(this.E_Sample_Image_File);
            this.TP_Step1.Controls.Add(this.button2);
            this.TP_Step1.Location = new System.Drawing.Point(4, 24);
            this.TP_Step1.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step1.Name = "TP_Step1";
            this.TP_Step1.Padding = new System.Windows.Forms.Padding(2);
            this.TP_Step1.Size = new System.Drawing.Size(367, 575);
            this.TP_Step1.TabIndex = 1;
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Step1_Enter);
            // 
            // B_Select_Sample_Image
            // 
            this.B_Select_Sample_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Sample_Image.Location = new System.Drawing.Point(242, 110);
            this.B_Select_Sample_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Sample_Image.Name = "B_Select_Sample_Image";
            this.B_Select_Sample_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Sample_Image.TabIndex = 30;
            this.B_Select_Sample_Image.Text = "...";
            this.B_Select_Sample_Image.UseVisualStyleBackColor = true;
            this.B_Select_Sample_Image.Click += new System.EventHandler(this.B_Select_Trans_Image_Click);
            // 
            // B_Sample_Image
            // 
            this.B_Sample_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image.Location = new System.Drawing.Point(24, 56);
            this.B_Sample_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Sample_Image.Name = "B_Sample_Image";
            this.B_Sample_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Sample_Image.TabIndex = 26;
            this.B_Sample_Image.Text = "Sample Image";
            this.B_Sample_Image.UseVisualStyleBackColor = true;
            this.B_Sample_Image.Click += new System.EventHandler(this.B_Trans_Image_Click);
            // 
            // E_Sample_Image_File
            // 
            this.E_Sample_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Sample_Image_File.Location = new System.Drawing.Point(24, 110);
            this.E_Sample_Image_File.Margin = new System.Windows.Forms.Padding(2);
            this.E_Sample_Image_File.Name = "E_Sample_Image_File";
            this.E_Sample_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Sample_Image_File.TabIndex = 29;
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
            // TP_Step2
            // 
            this.TP_Step2.Controls.Add(this.label4);
            this.TP_Step2.Controls.Add(this.comboBox1);
            this.TP_Step2.Controls.Add(this.tabControl1);
            this.TP_Step2.Controls.Add(this.label1);
            this.TP_Step2.Controls.Add(this.button3);
            this.TP_Step2.Controls.Add(this.E_Edit_Find_Region);
            this.TP_Step2.Location = new System.Drawing.Point(4, 24);
            this.TP_Step2.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Size = new System.Drawing.Size(367, 575);
            this.TP_Step2.TabIndex = 2;
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Step2_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "Filter Type";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Gauss"});
            this.comboBox1.Location = new System.Drawing.Point(23, 156);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 22);
            this.comboBox1.TabIndex = 27;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(24, 184);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(300, 195);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(292, 167);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gauss";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.E_Sigma1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_Sigma2);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 101);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // E_Sigma1
            // 
            this.E_Sigma1.Location = new System.Drawing.Point(97, 27);
            this.E_Sigma1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.E_Sigma1.Name = "E_Sigma1";
            this.E_Sigma1.Size = new System.Drawing.Size(53, 24);
            this.E_Sigma1.TabIndex = 3;
            this.E_Sigma1.Text = "10";
            this.E_Sigma1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sigma1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sigma1";
            // 
            // E_Sigma2
            // 
            this.E_Sigma2.Location = new System.Drawing.Point(97, 62);
            this.E_Sigma2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.E_Sigma2.Name = "E_Sigma2";
            this.E_Sigma2.Size = new System.Drawing.Size(53, 24);
            this.E_Sigma2.TabIndex = 5;
            this.E_Sigma2.Text = "3";
            this.E_Sigma2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(292, 167);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(20, 91);
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
            // E_Edit_Find_Region
            // 
            this.E_Edit_Find_Region.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_Edit_Find_Region.Location = new System.Drawing.Point(24, 20);
            this.E_Edit_Find_Region.Margin = new System.Windows.Forms.Padding(2);
            this.E_Edit_Find_Region.Name = "E_Edit_Find_Region";
            this.E_Edit_Find_Region.Size = new System.Drawing.Size(93, 54);
            this.E_Edit_Find_Region.TabIndex = 24;
            this.E_Edit_Find_Region.Text = "編輯搜尋區域";
            this.E_Edit_Find_Region.UseVisualStyleBackColor = false;
            this.E_Edit_Find_Region.Click += new System.EventHandler(this.E_Edit_Find_Region_Click);
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.groupBox2);
            this.TP_Step3.Controls.Add(this.B_Big_Param);
            this.TP_Step3.Controls.Add(this.B_Small_Param);
            this.TP_Step3.Controls.Add(this.button6);
            this.TP_Step3.Location = new System.Drawing.Point(4, 24);
            this.TP_Step3.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(367, 575);
            this.TP_Step3.TabIndex = 4;
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            this.TP_Step3.Enter += new System.EventHandler(this.TP_Step3_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CB_Small);
            this.groupBox2.Controls.Add(this.CB_Big);
            this.groupBox2.Controls.Add(this.RB_Display3);
            this.groupBox2.Controls.Add(this.RB_Display1);
            this.groupBox2.Controls.Add(this.RB_Display2);
            this.groupBox2.Location = new System.Drawing.Point(15, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 203);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Display";
            // 
            // CB_Small
            // 
            this.CB_Small.AutoSize = true;
            this.CB_Small.Checked = true;
            this.CB_Small.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Small.Location = new System.Drawing.Point(9, 169);
            this.CB_Small.Name = "CB_Small";
            this.CB_Small.Size = new System.Drawing.Size(62, 18);
            this.CB_Small.TabIndex = 5;
            this.CB_Small.Text = "Small";
            this.CB_Small.UseVisualStyleBackColor = true;
            this.CB_Small.Click += new System.EventHandler(this.RB_Display1_Click);
            // 
            // CB_Big
            // 
            this.CB_Big.AutoSize = true;
            this.CB_Big.Checked = true;
            this.CB_Big.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Big.Location = new System.Drawing.Point(12, 136);
            this.CB_Big.Name = "CB_Big";
            this.CB_Big.Size = new System.Drawing.Size(49, 18);
            this.CB_Big.TabIndex = 4;
            this.CB_Big.Text = "Big";
            this.CB_Big.UseVisualStyleBackColor = true;
            this.CB_Big.Click += new System.EventHandler(this.RB_Display1_Click);
            // 
            // RB_Display3
            // 
            this.RB_Display3.AutoSize = true;
            this.RB_Display3.Location = new System.Drawing.Point(12, 99);
            this.RB_Display3.Name = "RB_Display3";
            this.RB_Display3.Size = new System.Drawing.Size(112, 18);
            this.RB_Display3.TabIndex = 3;
            this.RB_Display3.Text = "Defect_Image";
            this.RB_Display3.UseVisualStyleBackColor = true;
            this.RB_Display3.Click += new System.EventHandler(this.RB_Display1_Click);
            // 
            // RB_Display1
            // 
            this.RB_Display1.AutoSize = true;
            this.RB_Display1.Checked = true;
            this.RB_Display1.Location = new System.Drawing.Point(12, 26);
            this.RB_Display1.Name = "RB_Display1";
            this.RB_Display1.Size = new System.Drawing.Size(71, 18);
            this.RB_Display1.TabIndex = 1;
            this.RB_Display1.TabStop = true;
            this.RB_Display1.Text = "Sample";
            this.RB_Display1.UseVisualStyleBackColor = true;
            this.RB_Display1.Click += new System.EventHandler(this.RB_Display1_Click);
            // 
            // RB_Display2
            // 
            this.RB_Display2.AutoSize = true;
            this.RB_Display2.Location = new System.Drawing.Point(12, 64);
            this.RB_Display2.Name = "RB_Display2";
            this.RB_Display2.Size = new System.Drawing.Size(60, 18);
            this.RB_Display2.TabIndex = 0;
            this.RB_Display2.Text = "Filter";
            this.RB_Display2.UseVisualStyleBackColor = true;
            this.RB_Display2.Click += new System.EventHandler(this.RB_Display1_Click);
            // 
            // B_Big_Param
            // 
            this.B_Big_Param.BackColor = System.Drawing.Color.LightSteelBlue;
            this.B_Big_Param.Location = new System.Drawing.Point(15, 15);
            this.B_Big_Param.Margin = new System.Windows.Forms.Padding(2);
            this.B_Big_Param.Name = "B_Big_Param";
            this.B_Big_Param.Size = new System.Drawing.Size(144, 54);
            this.B_Big_Param.TabIndex = 34;
            this.B_Big_Param.Text = "Big Defect參數";
            this.B_Big_Param.UseVisualStyleBackColor = false;
            this.B_Big_Param.Click += new System.EventHandler(this.B_Big_Param_Click);
            // 
            // B_Small_Param
            // 
            this.B_Small_Param.BackColor = System.Drawing.Color.LightSteelBlue;
            this.B_Small_Param.Location = new System.Drawing.Point(15, 73);
            this.B_Small_Param.Margin = new System.Windows.Forms.Padding(2);
            this.B_Small_Param.Name = "B_Small_Param";
            this.B_Small_Param.Size = new System.Drawing.Size(144, 54);
            this.B_Small_Param.TabIndex = 36;
            this.B_Small_Param.Text = "Small Defect參數";
            this.B_Small_Param.UseVisualStyleBackColor = false;
            this.B_Small_Param.Click += new System.EventHandler(this.B_Small_Param_Click);
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
            // TP_Step4
            // 
            this.TP_Step4.Controls.Add(this.button7);
            this.TP_Step4.Location = new System.Drawing.Point(4, 24);
            this.TP_Step4.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step4.Name = "TP_Step4";
            this.TP_Step4.Size = new System.Drawing.Size(367, 575);
            this.TP_Step4.TabIndex = 3;
            this.TP_Step4.Text = "Step4";
            this.TP_Step4.UseVisualStyleBackColor = true;
            this.TP_Step4.Enter += new System.EventHandler(this.TP_Step4_Enter);
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
            // TForm_AOI_Glass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 662);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_AOI_Glass";
            this.Text = "Form_Find_Mothed_1";
            this.Shown += new System.EventHandler(this.Form_Find_Barcode1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.TabColtrol1.ResumeLayout(false);
            this.TP_Space.ResumeLayout(false);
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step1.PerformLayout();
            this.TP_Step2.ResumeLayout(false);
            this.TP_Step2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TP_Step3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TP_Step4.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl TabColtrol1;
        private System.Windows.Forms.TabPage TP_Space;
        private System.Windows.Forms.TabPage TP_Step1;
        private System.Windows.Forms.TabPage TP_Step2;
        private System.Windows.Forms.TabPage TP_Step4;
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Button B_Big_Param;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button E_Edit_Find_Region;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Sigma1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Sigma2;
        private System.Windows.Forms.Button B_Select_Sample_Image;
        private System.Windows.Forms.Button B_Sample_Image;
        private System.Windows.Forms.TextBox E_Sample_Image_File;
        private System.Windows.Forms.Button B_Small_Param;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CB_Small;
        private System.Windows.Forms.CheckBox CB_Big;
        private System.Windows.Forms.RadioButton RB_Display3;
        private System.Windows.Forms.RadioButton RB_Display1;
        private System.Windows.Forms.RadioButton RB_Display2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}