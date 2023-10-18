namespace EFC.Vision.Halcon
{
    partial class TForm_Align_Image_XYQ
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Step0 = new System.Windows.Forms.TabPage();
            this.B_Next1 = new System.Windows.Forms.Button();
            this.TP_Step1 = new System.Windows.Forms.TabPage();
            this.B_Next2 = new System.Windows.Forms.Button();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.E_Base_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Trans_Image = new System.Windows.Forms.Button();
            this.B_Trans_Image = new System.Windows.Forms.Button();
            this.E_Trans_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Base_Image = new System.Windows.Forms.Button();
            this.TP_Step2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RB_Align_Mode1 = new System.Windows.Forms.RadioButton();
            this.RB_Align_Mode3 = new System.Windows.Forms.RadioButton();
            this.RB_Align_Mode2 = new System.Windows.Forms.RadioButton();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.TP_Mark1 = new System.Windows.Forms.TabPage();
            this.tFrame_Select_Model1 = new EFC.Vision.Halcon.TFrame_Select_Model();
            this.B_Select_Rect1 = new System.Windows.Forms.Button();
            this.TP_Mark2 = new System.Windows.Forms.TabPage();
            this.tFrame_Select_Model2 = new EFC.Vision.Halcon.TFrame_Select_Model();
            this.B_Select_Rect2 = new System.Windows.Forms.Button();
            this.B_Next3 = new System.Windows.Forms.Button();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RB_Step3_Image2 = new System.Windows.Forms.RadioButton();
            this.RB_Step3_Image1 = new System.Windows.Forms.RadioButton();
            this.B_Next4 = new System.Windows.Forms.Button();
            this.TP_Step5 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_Step4_Image3 = new System.Windows.Forms.RadioButton();
            this.RB_Step4_Image2 = new System.Windows.Forms.RadioButton();
            this.RB_Step4_Image1 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Step0.SuspendLayout();
            this.TP_Step1.SuspendLayout();
            this.TP_Step2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.TP_Mark1.SuspendLayout();
            this.TP_Mark2.SuspendLayout();
            this.TP_Step3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TP_Step5.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 59);
            this.panel1.TabIndex = 3;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.Image = global::EFC.Vision.Halcon.Properties.Resources.hard_drive_upload;
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.Location = new System.Drawing.Point(291, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(97, 59);
            this.B_Open.TabIndex = 8;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Open.UseVisualStyleBackColor = false;
            this.B_Open.Visible = false;
            // 
            // B_Save
            // 
            this.B_Save.BackColor = System.Drawing.Color.White;
            this.B_Save.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save.Image = global::EFC.Vision.Halcon.Properties.Resources.hard_drive_download;
            this.B_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save.Location = new System.Drawing.Point(194, 0);
            this.B_Save.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(97, 59);
            this.B_Save.TabIndex = 7;
            this.B_Save.Text = "另存檔案";
            this.B_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Save.UseVisualStyleBackColor = false;
            this.B_Save.Visible = false;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.Image = global::EFC.Vision.Halcon.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(97, 59);
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
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(375, 630);
            this.panel3.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Step0);
            this.tabControl1.Controls.Add(this.TP_Step1);
            this.tabControl1.Controls.Add(this.TP_Step2);
            this.tabControl1.Controls.Add(this.TP_Step3);
            this.tabControl1.Controls.Add(this.TP_Step5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 630);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // TP_Step0
            // 
            this.TP_Step0.Controls.Add(this.B_Next1);
            this.TP_Step0.Location = new System.Drawing.Point(4, 24);
            this.TP_Step0.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step0.Name = "TP_Step0";
            this.TP_Step0.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step0.Size = new System.Drawing.Size(367, 602);
            this.TP_Step0.TabIndex = 0;
            this.TP_Step0.Text = "空白";
            this.TP_Step0.UseVisualStyleBackColor = true;
            this.TP_Step0.Enter += new System.EventHandler(this.TP_Step0_Enter);
            // 
            // B_Next1
            // 
            this.B_Next1.BackColor = System.Drawing.Color.Orange;
            this.B_Next1.Location = new System.Drawing.Point(216, 13);
            this.B_Next1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next1.Name = "B_Next1";
            this.B_Next1.Size = new System.Drawing.Size(93, 36);
            this.B_Next1.TabIndex = 17;
            this.B_Next1.Text = "下一步 =>";
            this.B_Next1.UseVisualStyleBackColor = false;
            this.B_Next1.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step1
            // 
            this.TP_Step1.Controls.Add(this.B_Next2);
            this.TP_Step1.Controls.Add(this.B_Base_Image);
            this.TP_Step1.Controls.Add(this.E_Base_Image_File);
            this.TP_Step1.Controls.Add(this.B_Select_Trans_Image);
            this.TP_Step1.Controls.Add(this.B_Trans_Image);
            this.TP_Step1.Controls.Add(this.E_Trans_Image_File);
            this.TP_Step1.Controls.Add(this.B_Select_Base_Image);
            this.TP_Step1.Location = new System.Drawing.Point(4, 24);
            this.TP_Step1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step1.Name = "TP_Step1";
            this.TP_Step1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step1.Size = new System.Drawing.Size(367, 602);
            this.TP_Step1.TabIndex = 1;
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Step1_Enter);
            // 
            // B_Next2
            // 
            this.B_Next2.BackColor = System.Drawing.Color.Orange;
            this.B_Next2.Location = new System.Drawing.Point(216, 13);
            this.B_Next2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next2.Name = "B_Next2";
            this.B_Next2.Size = new System.Drawing.Size(93, 36);
            this.B_Next2.TabIndex = 17;
            this.B_Next2.Text = "下一步 =>";
            this.B_Next2.UseVisualStyleBackColor = false;
            this.B_Next2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(20, 61);
            this.B_Base_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Base_Image.TabIndex = 0;
            this.B_Base_Image.Text = "Base Image";
            this.B_Base_Image.UseVisualStyleBackColor = true;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // E_Base_Image_File
            // 
            this.E_Base_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Image_File.Location = new System.Drawing.Point(20, 114);
            this.E_Base_Image_File.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Base_Image_File.Name = "E_Base_Image_File";
            this.E_Base_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Base_Image_File.TabIndex = 3;
            // 
            // B_Select_Trans_Image
            // 
            this.B_Select_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Trans_Image.Location = new System.Drawing.Point(238, 221);
            this.B_Select_Trans_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Trans_Image.Name = "B_Select_Trans_Image";
            this.B_Select_Trans_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Trans_Image.TabIndex = 6;
            this.B_Select_Trans_Image.Text = "...";
            this.B_Select_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Select_Trans_Image.Click += new System.EventHandler(this.B_Select_Trans_Image_Click);
            // 
            // B_Trans_Image
            // 
            this.B_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Trans_Image.Location = new System.Drawing.Point(20, 167);
            this.B_Trans_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Trans_Image.Name = "B_Trans_Image";
            this.B_Trans_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Trans_Image.TabIndex = 1;
            this.B_Trans_Image.Text = "Sample Image";
            this.B_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Trans_Image.Click += new System.EventHandler(this.B_Trans_Image_Click);
            // 
            // E_Trans_Image_File
            // 
            this.E_Trans_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Trans_Image_File.Location = new System.Drawing.Point(20, 221);
            this.E_Trans_Image_File.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Trans_Image_File.Name = "E_Trans_Image_File";
            this.E_Trans_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Trans_Image_File.TabIndex = 5;
            // 
            // B_Select_Base_Image
            // 
            this.B_Select_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_Image.Location = new System.Drawing.Point(238, 114);
            this.B_Select_Base_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Base_Image.Name = "B_Select_Base_Image";
            this.B_Select_Base_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Base_Image.TabIndex = 4;
            this.B_Select_Base_Image.Text = "...";
            this.B_Select_Base_Image.UseVisualStyleBackColor = true;
            this.B_Select_Base_Image.Click += new System.EventHandler(this.B_Select_Base_Image_Click);
            // 
            // TP_Step2
            // 
            this.TP_Step2.Controls.Add(this.groupBox4);
            this.TP_Step2.Controls.Add(this.tabControl2);
            this.TP_Step2.Controls.Add(this.B_Next3);
            this.TP_Step2.Location = new System.Drawing.Point(4, 24);
            this.TP_Step2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Size = new System.Drawing.Size(367, 602);
            this.TP_Step2.TabIndex = 4;
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Step2_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RB_Align_Mode1);
            this.groupBox4.Controls.Add(this.RB_Align_Mode3);
            this.groupBox4.Controls.Add(this.RB_Align_Mode2);
            this.groupBox4.Location = new System.Drawing.Point(16, 9);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox4.Size = new System.Drawing.Size(150, 99);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[ 定位方式 ]";
            // 
            // RB_Align_Mode1
            // 
            this.RB_Align_Mode1.AutoSize = true;
            this.RB_Align_Mode1.Location = new System.Drawing.Point(14, 22);
            this.RB_Align_Mode1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RB_Align_Mode1.Name = "RB_Align_Mode1";
            this.RB_Align_Mode1.Size = new System.Drawing.Size(40, 18);
            this.RB_Align_Mode1.TabIndex = 2;
            this.RB_Align_Mode1.TabStop = true;
            this.RB_Align_Mode1.Text = "無";
            this.RB_Align_Mode1.UseVisualStyleBackColor = true;
            this.RB_Align_Mode1.Click += new System.EventHandler(this.RB_Align_Mode1_Click);
            // 
            // RB_Align_Mode3
            // 
            this.RB_Align_Mode3.AutoSize = true;
            this.RB_Align_Mode3.Location = new System.Drawing.Point(14, 75);
            this.RB_Align_Mode3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RB_Align_Mode3.Name = "RB_Align_Mode3";
            this.RB_Align_Mode3.Size = new System.Drawing.Size(85, 18);
            this.RB_Align_Mode3.TabIndex = 1;
            this.RB_Align_Mode3.TabStop = true;
            this.RB_Align_Mode3.Text = "雙點定位";
            this.RB_Align_Mode3.UseVisualStyleBackColor = true;
            this.RB_Align_Mode3.Click += new System.EventHandler(this.RB_Align_Mode3_Click);
            // 
            // RB_Align_Mode2
            // 
            this.RB_Align_Mode2.AutoSize = true;
            this.RB_Align_Mode2.Location = new System.Drawing.Point(14, 47);
            this.RB_Align_Mode2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RB_Align_Mode2.Name = "RB_Align_Mode2";
            this.RB_Align_Mode2.Size = new System.Drawing.Size(85, 18);
            this.RB_Align_Mode2.TabIndex = 0;
            this.RB_Align_Mode2.TabStop = true;
            this.RB_Align_Mode2.Text = "單點定位";
            this.RB_Align_Mode2.UseVisualStyleBackColor = true;
            this.RB_Align_Mode2.Click += new System.EventHandler(this.RB_Align_Mode2_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.TP_Mark1);
            this.tabControl2.Controls.Add(this.TP_Mark2);
            this.tabControl2.Location = new System.Drawing.Point(16, 126);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(339, 476);
            this.tabControl2.TabIndex = 27;
            // 
            // TP_Mark1
            // 
            this.TP_Mark1.Controls.Add(this.tFrame_Select_Model1);
            this.TP_Mark1.Controls.Add(this.B_Select_Rect1);
            this.TP_Mark1.Location = new System.Drawing.Point(4, 24);
            this.TP_Mark1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Mark1.Name = "TP_Mark1";
            this.TP_Mark1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Mark1.Size = new System.Drawing.Size(331, 448);
            this.TP_Mark1.TabIndex = 0;
            this.TP_Mark1.Text = "標靶1";
            this.TP_Mark1.UseVisualStyleBackColor = true;
            // 
            // tFrame_Select_Model1
            // 
            this.tFrame_Select_Model1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model1.Location = new System.Drawing.Point(10, 64);
            this.tFrame_Select_Model1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tFrame_Select_Model1.Name = "tFrame_Select_Model1";
            this.tFrame_Select_Model1.Size = new System.Drawing.Size(315, 368);
            this.tFrame_Select_Model1.TabIndex = 27;
            // 
            // B_Select_Rect1
            // 
            this.B_Select_Rect1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Rect1.Location = new System.Drawing.Point(13, 18);
            this.B_Select_Rect1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Rect1.Name = "B_Select_Rect1";
            this.B_Select_Rect1.Size = new System.Drawing.Size(100, 41);
            this.B_Select_Rect1.TabIndex = 26;
            this.B_Select_Rect1.Text = "編輯參數";
            this.B_Select_Rect1.UseVisualStyleBackColor = true;
            this.B_Select_Rect1.Click += new System.EventHandler(this.B_Select_Rect1_Click_1);
            // 
            // TP_Mark2
            // 
            this.TP_Mark2.Controls.Add(this.tFrame_Select_Model2);
            this.TP_Mark2.Controls.Add(this.B_Select_Rect2);
            this.TP_Mark2.Location = new System.Drawing.Point(4, 24);
            this.TP_Mark2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Mark2.Name = "TP_Mark2";
            this.TP_Mark2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Mark2.Size = new System.Drawing.Size(331, 448);
            this.TP_Mark2.TabIndex = 1;
            this.TP_Mark2.Text = "標靶2";
            this.TP_Mark2.UseVisualStyleBackColor = true;
            // 
            // tFrame_Select_Model2
            // 
            this.tFrame_Select_Model2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model2.Location = new System.Drawing.Point(10, 64);
            this.tFrame_Select_Model2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tFrame_Select_Model2.Name = "tFrame_Select_Model2";
            this.tFrame_Select_Model2.Size = new System.Drawing.Size(315, 368);
            this.tFrame_Select_Model2.TabIndex = 29;
            // 
            // B_Select_Rect2
            // 
            this.B_Select_Rect2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Rect2.Location = new System.Drawing.Point(13, 18);
            this.B_Select_Rect2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Rect2.Name = "B_Select_Rect2";
            this.B_Select_Rect2.Size = new System.Drawing.Size(100, 41);
            this.B_Select_Rect2.TabIndex = 28;
            this.B_Select_Rect2.Text = "編輯參數";
            this.B_Select_Rect2.UseVisualStyleBackColor = true;
            this.B_Select_Rect2.Click += new System.EventHandler(this.B_Select_Rect2_Click);
            // 
            // B_Next3
            // 
            this.B_Next3.BackColor = System.Drawing.Color.Orange;
            this.B_Next3.Location = new System.Drawing.Point(216, 13);
            this.B_Next3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next3.Name = "B_Next3";
            this.B_Next3.Size = new System.Drawing.Size(93, 36);
            this.B_Next3.TabIndex = 18;
            this.B_Next3.Text = "下一步 =>";
            this.B_Next3.UseVisualStyleBackColor = false;
            this.B_Next3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.groupBox1);
            this.TP_Step3.Controls.Add(this.B_Next4);
            this.TP_Step3.Location = new System.Drawing.Point(4, 24);
            this.TP_Step3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(367, 602);
            this.TP_Step3.TabIndex = 2;
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            this.TP_Step3.Enter += new System.EventHandler(this.TP_Step3_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RB_Step3_Image2);
            this.groupBox1.Controls.Add(this.RB_Step3_Image1);
            this.groupBox1.Location = new System.Drawing.Point(21, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 87);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "顯示來源";
            // 
            // RB_Step3_Image2
            // 
            this.RB_Step3_Image2.AutoSize = true;
            this.RB_Step3_Image2.Location = new System.Drawing.Point(6, 47);
            this.RB_Step3_Image2.Name = "RB_Step3_Image2";
            this.RB_Step3_Image2.Size = new System.Drawing.Size(114, 18);
            this.RB_Step3_Image2.TabIndex = 1;
            this.RB_Step3_Image2.Text = "Sample Image";
            this.RB_Step3_Image2.UseVisualStyleBackColor = true;
            this.RB_Step3_Image2.CheckedChanged += new System.EventHandler(this.RB_Step3_Image1_CheckedChanged);
            // 
            // RB_Step3_Image1
            // 
            this.RB_Step3_Image1.AutoSize = true;
            this.RB_Step3_Image1.Checked = true;
            this.RB_Step3_Image1.Location = new System.Drawing.Point(6, 23);
            this.RB_Step3_Image1.Name = "RB_Step3_Image1";
            this.RB_Step3_Image1.Size = new System.Drawing.Size(98, 18);
            this.RB_Step3_Image1.TabIndex = 0;
            this.RB_Step3_Image1.TabStop = true;
            this.RB_Step3_Image1.Text = "Base Image";
            this.RB_Step3_Image1.UseVisualStyleBackColor = true;
            this.RB_Step3_Image1.CheckedChanged += new System.EventHandler(this.RB_Step3_Image1_CheckedChanged);
            // 
            // B_Next4
            // 
            this.B_Next4.BackColor = System.Drawing.Color.Orange;
            this.B_Next4.Location = new System.Drawing.Point(216, 13);
            this.B_Next4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next4.Name = "B_Next4";
            this.B_Next4.Size = new System.Drawing.Size(93, 36);
            this.B_Next4.TabIndex = 16;
            this.B_Next4.Text = "下一步 =>";
            this.B_Next4.UseVisualStyleBackColor = false;
            this.B_Next4.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step5
            // 
            this.TP_Step5.Controls.Add(this.groupBox2);
            this.TP_Step5.Controls.Add(this.button5);
            this.TP_Step5.Location = new System.Drawing.Point(4, 24);
            this.TP_Step5.Name = "TP_Step5";
            this.TP_Step5.Size = new System.Drawing.Size(367, 602);
            this.TP_Step5.TabIndex = 6;
            this.TP_Step5.Text = "Step4";
            this.TP_Step5.UseVisualStyleBackColor = true;
            this.TP_Step5.Enter += new System.EventHandler(this.TP_Step4_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_Step4_Image3);
            this.groupBox2.Controls.Add(this.RB_Step4_Image2);
            this.groupBox2.Controls.Add(this.RB_Step4_Image1);
            this.groupBox2.Location = new System.Drawing.Point(29, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 100);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "顯示來源";
            // 
            // RB_Step4_Image3
            // 
            this.RB_Step4_Image3.AutoSize = true;
            this.RB_Step4_Image3.Checked = true;
            this.RB_Step4_Image3.Location = new System.Drawing.Point(6, 71);
            this.RB_Step4_Image3.Name = "RB_Step4_Image3";
            this.RB_Step4_Image3.Size = new System.Drawing.Size(109, 18);
            this.RB_Step4_Image3.TabIndex = 2;
            this.RB_Step4_Image3.TabStop = true;
            this.RB_Step4_Image3.Text = "Result Image";
            this.RB_Step4_Image3.UseVisualStyleBackColor = true;
            this.RB_Step4_Image3.CheckedChanged += new System.EventHandler(this.RB_Step4_Image1_CheckedChanged);
            // 
            // RB_Step4_Image2
            // 
            this.RB_Step4_Image2.AutoSize = true;
            this.RB_Step4_Image2.Location = new System.Drawing.Point(6, 47);
            this.RB_Step4_Image2.Name = "RB_Step4_Image2";
            this.RB_Step4_Image2.Size = new System.Drawing.Size(114, 18);
            this.RB_Step4_Image2.TabIndex = 1;
            this.RB_Step4_Image2.Text = "Sample Image";
            this.RB_Step4_Image2.UseVisualStyleBackColor = true;
            this.RB_Step4_Image2.CheckedChanged += new System.EventHandler(this.RB_Step4_Image1_CheckedChanged);
            // 
            // RB_Step4_Image1
            // 
            this.RB_Step4_Image1.AutoSize = true;
            this.RB_Step4_Image1.Location = new System.Drawing.Point(6, 23);
            this.RB_Step4_Image1.Name = "RB_Step4_Image1";
            this.RB_Step4_Image1.Size = new System.Drawing.Size(98, 18);
            this.RB_Step4_Image1.TabIndex = 0;
            this.RB_Step4_Image1.Text = "Base Image";
            this.RB_Step4_Image1.UseVisualStyleBackColor = true;
            this.RB_Step4_Image1.CheckedChanged += new System.EventHandler(this.RB_Step4_Image1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lime;
            this.button5.Location = new System.Drawing.Point(216, 13);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 36);
            this.button5.TabIndex = 22;
            this.button5.Text = "完成";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(375, 59);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = true;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(472, 630);
            this.tFrame_JJS_HW1.TabIndex = 6;
            // 
            // TForm_Align_Image_XYQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 689);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "TForm_Align_Image_XYQ";
            this.Text = "TForm_Align_Mothed2";
            this.Shown += new System.EventHandler(this.TForm_Align_Mothed2_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Step0.ResumeLayout(false);
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step1.PerformLayout();
            this.TP_Step2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.TP_Mark1.ResumeLayout(false);
            this.TP_Mark2.ResumeLayout(false);
            this.TP_Step3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TP_Step5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Step0;
        private System.Windows.Forms.Button B_Next1;
        private System.Windows.Forms.TabPage TP_Step1;
        private System.Windows.Forms.Button B_Next2;
        private System.Windows.Forms.Button B_Base_Image;
        private System.Windows.Forms.TextBox E_Base_Image_File;
        private System.Windows.Forms.Button B_Select_Trans_Image;
        private System.Windows.Forms.Button B_Trans_Image;
        private System.Windows.Forms.TextBox E_Trans_Image_File;
        private System.Windows.Forms.Button B_Select_Base_Image;
        private System.Windows.Forms.TabPage TP_Step2;
        private System.Windows.Forms.Button B_Next3;
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.Button B_Next4;
        private System.Windows.Forms.Button B_Select_Rect1;
        private System.Windows.Forms.TabPage TP_Step5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RB_Align_Mode3;
        private System.Windows.Forms.RadioButton RB_Align_Mode2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage TP_Mark1;
        private System.Windows.Forms.TabPage TP_Mark2;
        private System.Windows.Forms.Button B_Select_Rect2;
        private System.Windows.Forms.Button button5;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RB_Step3_Image2;
        private System.Windows.Forms.RadioButton RB_Step3_Image1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_Step4_Image3;
        private System.Windows.Forms.RadioButton RB_Step4_Image2;
        private System.Windows.Forms.RadioButton RB_Step4_Image1;
        private TFrame_Select_Model tFrame_Select_Model1;
        private TFrame_Select_Model tFrame_Select_Model2;
        private System.Windows.Forms.RadioButton RB_Align_Mode1;
    }
}