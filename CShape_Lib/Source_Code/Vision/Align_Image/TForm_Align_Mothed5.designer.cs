namespace EFC.Vision.Halcon
{
    partial class TForm_Align_Mothed5
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
            this.B_Set_Default = new System.Windows.Forms.Button();
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
            this.B_Create_Model = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LB_Model = new System.Windows.Forms.ListBox();
            this.tFrame_Select_Model1 = new EFC.Vision.Halcon.TFrame_Select_Model();
            this.B_Next3 = new System.Windows.Forms.Button();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.B_Base_Image_Find = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TP_Step4 = new System.Windows.Forms.TabPage();
            this.B_Sample_Image_Find = new System.Windows.Forms.Button();
            this.B_Next4 = new System.Windows.Forms.Button();
            this.TP_Step5 = new System.Windows.Forms.TabPage();
            this.B_Result_Image = new System.Windows.Forms.Button();
            this.B_Sample_Image2 = new System.Windows.Forms.Button();
            this.B_Base_Image2 = new System.Windows.Forms.Button();
            this.B_Finish = new System.Windows.Forms.Button();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Step0.SuspendLayout();
            this.TP_Step1.SuspendLayout();
            this.TP_Step2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TP_Step3.SuspendLayout();
            this.TP_Step4.SuspendLayout();
            this.TP_Step5.SuspendLayout();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 74);
            this.panel1.TabIndex = 3;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.Image = global::EFC.Vision.Halcon.Properties.Resources.hard_drive_upload;
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.Location = new System.Drawing.Point(387, 0);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(129, 74);
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
            this.B_Save.Location = new System.Drawing.Point(258, 0);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(129, 74);
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
            this.B_Cancel.Location = new System.Drawing.Point(129, 0);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(129, 74);
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
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(129, 74);
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
            this.panel3.Location = new System.Drawing.Point(0, 74);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(501, 738);
            this.panel3.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Step0);
            this.tabControl1.Controls.Add(this.TP_Step1);
            this.tabControl1.Controls.Add(this.TP_Step2);
            this.tabControl1.Controls.Add(this.TP_Step3);
            this.tabControl1.Controls.Add(this.TP_Step4);
            this.tabControl1.Controls.Add(this.TP_Step5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(501, 738);
            this.tabControl1.TabIndex = 0;
            // 
            // TP_Step0
            // 
            this.TP_Step0.Controls.Add(this.B_Set_Default);
            this.TP_Step0.Controls.Add(this.B_Next1);
            this.TP_Step0.Location = new System.Drawing.Point(4, 27);
            this.TP_Step0.Name = "TP_Step0";
            this.TP_Step0.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Step0.Size = new System.Drawing.Size(493, 707);
            this.TP_Step0.TabIndex = 0;
            this.TP_Step0.Text = "空白";
            this.TP_Step0.UseVisualStyleBackColor = true;
            this.TP_Step0.Enter += new System.EventHandler(this.TP_Step0_Enter);
            // 
            // B_Set_Default
            // 
            this.B_Set_Default.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Set_Default.Location = new System.Drawing.Point(65, 118);
            this.B_Set_Default.Name = "B_Set_Default";
            this.B_Set_Default.Size = new System.Drawing.Size(187, 61);
            this.B_Set_Default.TabIndex = 18;
            this.B_Set_Default.Text = "Set Default";
            this.B_Set_Default.UseVisualStyleBackColor = true;
            this.B_Set_Default.Click += new System.EventHandler(this.B_Set_Default_Click);
            // 
            // B_Next1
            // 
            this.B_Next1.BackColor = System.Drawing.Color.Orange;
            this.B_Next1.Location = new System.Drawing.Point(360, 12);
            this.B_Next1.Name = "B_Next1";
            this.B_Next1.Size = new System.Drawing.Size(124, 45);
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
            this.TP_Step1.Location = new System.Drawing.Point(4, 27);
            this.TP_Step1.Name = "TP_Step1";
            this.TP_Step1.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Step1.Size = new System.Drawing.Size(493, 707);
            this.TP_Step1.TabIndex = 1;
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Step1_Enter);
            // 
            // B_Next2
            // 
            this.B_Next2.BackColor = System.Drawing.Color.Orange;
            this.B_Next2.Location = new System.Drawing.Point(360, 12);
            this.B_Next2.Name = "B_Next2";
            this.B_Next2.Size = new System.Drawing.Size(124, 45);
            this.B_Next2.TabIndex = 17;
            this.B_Next2.Text = "下一步 =>";
            this.B_Next2.UseVisualStyleBackColor = false;
            this.B_Next2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(27, 76);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(187, 61);
            this.B_Base_Image.TabIndex = 0;
            this.B_Base_Image.Text = "Base Image";
            this.B_Base_Image.UseVisualStyleBackColor = true;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // E_Base_Image_File
            // 
            this.E_Base_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Image_File.Location = new System.Drawing.Point(27, 143);
            this.E_Base_Image_File.Name = "E_Base_Image_File";
            this.E_Base_Image_File.Size = new System.Drawing.Size(276, 31);
            this.E_Base_Image_File.TabIndex = 3;
            // 
            // B_Select_Trans_Image
            // 
            this.B_Select_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Trans_Image.Location = new System.Drawing.Point(317, 276);
            this.B_Select_Trans_Image.Name = "B_Select_Trans_Image";
            this.B_Select_Trans_Image.Size = new System.Drawing.Size(55, 31);
            this.B_Select_Trans_Image.TabIndex = 6;
            this.B_Select_Trans_Image.Text = "...";
            this.B_Select_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Select_Trans_Image.Click += new System.EventHandler(this.B_Select_Trans_Image_Click);
            // 
            // B_Trans_Image
            // 
            this.B_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Trans_Image.Location = new System.Drawing.Point(27, 209);
            this.B_Trans_Image.Name = "B_Trans_Image";
            this.B_Trans_Image.Size = new System.Drawing.Size(187, 61);
            this.B_Trans_Image.TabIndex = 1;
            this.B_Trans_Image.Text = "Trans Image";
            this.B_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Trans_Image.Click += new System.EventHandler(this.B_Trans_Image_Click);
            // 
            // E_Trans_Image_File
            // 
            this.E_Trans_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Trans_Image_File.Location = new System.Drawing.Point(27, 276);
            this.E_Trans_Image_File.Name = "E_Trans_Image_File";
            this.E_Trans_Image_File.Size = new System.Drawing.Size(276, 31);
            this.E_Trans_Image_File.TabIndex = 5;
            // 
            // B_Select_Base_Image
            // 
            this.B_Select_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_Image.Location = new System.Drawing.Point(317, 143);
            this.B_Select_Base_Image.Name = "B_Select_Base_Image";
            this.B_Select_Base_Image.Size = new System.Drawing.Size(55, 31);
            this.B_Select_Base_Image.TabIndex = 4;
            this.B_Select_Base_Image.Text = "...";
            this.B_Select_Base_Image.UseVisualStyleBackColor = true;
            this.B_Select_Base_Image.Click += new System.EventHandler(this.B_Select_Base_Image_Click);
            // 
            // TP_Step2
            // 
            this.TP_Step2.Controls.Add(this.B_Create_Model);
            this.TP_Step2.Controls.Add(this.groupBox1);
            this.TP_Step2.Controls.Add(this.tFrame_Select_Model1);
            this.TP_Step2.Controls.Add(this.B_Next3);
            this.TP_Step2.Location = new System.Drawing.Point(4, 27);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Size = new System.Drawing.Size(493, 707);
            this.TP_Step2.TabIndex = 4;
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Step2_Enter);
            // 
            // B_Create_Model
            // 
            this.B_Create_Model.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Create_Model.Location = new System.Drawing.Point(332, 320);
            this.B_Create_Model.Name = "B_Create_Model";
            this.B_Create_Model.Size = new System.Drawing.Size(126, 61);
            this.B_Create_Model.TabIndex = 21;
            this.B_Create_Model.Text = "Create";
            this.B_Create_Model.UseVisualStyleBackColor = true;
            this.B_Create_Model.Click += new System.EventHandler(this.B_Create_Model_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LB_Model);
            this.groupBox1.Location = new System.Drawing.Point(31, 397);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 302);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Model ]";
            // 
            // LB_Model
            // 
            this.LB_Model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_Model.FormattingEnabled = true;
            this.LB_Model.ItemHeight = 17;
            this.LB_Model.Location = new System.Drawing.Point(3, 24);
            this.LB_Model.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LB_Model.Name = "LB_Model";
            this.LB_Model.Size = new System.Drawing.Size(424, 275);
            this.LB_Model.TabIndex = 32;
            this.LB_Model.SelectedIndexChanged += new System.EventHandler(this.LB_Auto_Focus_SelectedIndexChanged);
            // 
            // tFrame_Select_Model1
            // 
            this.tFrame_Select_Model1.Enabled = false;
            this.tFrame_Select_Model1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model1.Location = new System.Drawing.Point(19, 23);
            this.tFrame_Select_Model1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tFrame_Select_Model1.Name = "tFrame_Select_Model1";
            this.tFrame_Select_Model1.Size = new System.Drawing.Size(315, 368);
            this.tFrame_Select_Model1.TabIndex = 19;
            // 
            // B_Next3
            // 
            this.B_Next3.BackColor = System.Drawing.Color.Orange;
            this.B_Next3.Location = new System.Drawing.Point(360, 12);
            this.B_Next3.Name = "B_Next3";
            this.B_Next3.Size = new System.Drawing.Size(124, 45);
            this.B_Next3.TabIndex = 18;
            this.B_Next3.Text = "下一步 =>";
            this.B_Next3.UseVisualStyleBackColor = false;
            this.B_Next3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.B_Base_Image_Find);
            this.TP_Step3.Controls.Add(this.button2);
            this.TP_Step3.Location = new System.Drawing.Point(4, 27);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(493, 707);
            this.TP_Step3.TabIndex = 7;
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            this.TP_Step3.Enter += new System.EventHandler(this.TP_Step3_Enter);
            // 
            // B_Base_Image_Find
            // 
            this.B_Base_Image_Find.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image_Find.Location = new System.Drawing.Point(36, 62);
            this.B_Base_Image_Find.Name = "B_Base_Image_Find";
            this.B_Base_Image_Find.Size = new System.Drawing.Size(237, 87);
            this.B_Base_Image_Find.TabIndex = 22;
            this.B_Base_Image_Find.Text = "Base Image Find";
            this.B_Base_Image_Find.UseVisualStyleBackColor = true;
            this.B_Base_Image_Find.Click += new System.EventHandler(this.B_Base_Image_Find_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(360, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 45);
            this.button2.TabIndex = 19;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step4
            // 
            this.TP_Step4.Controls.Add(this.B_Sample_Image_Find);
            this.TP_Step4.Controls.Add(this.B_Next4);
            this.TP_Step4.Location = new System.Drawing.Point(4, 27);
            this.TP_Step4.Name = "TP_Step4";
            this.TP_Step4.Size = new System.Drawing.Size(493, 707);
            this.TP_Step4.TabIndex = 2;
            this.TP_Step4.Text = "Step4";
            this.TP_Step4.UseVisualStyleBackColor = true;
            this.TP_Step4.Enter += new System.EventHandler(this.TP_Step4_Enter);
            // 
            // B_Sample_Image_Find
            // 
            this.B_Sample_Image_Find.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image_Find.Location = new System.Drawing.Point(36, 62);
            this.B_Sample_Image_Find.Name = "B_Sample_Image_Find";
            this.B_Sample_Image_Find.Size = new System.Drawing.Size(237, 87);
            this.B_Sample_Image_Find.TabIndex = 23;
            this.B_Sample_Image_Find.Text = "Sample Image Find";
            this.B_Sample_Image_Find.UseVisualStyleBackColor = true;
            this.B_Sample_Image_Find.Click += new System.EventHandler(this.B_Sample_Image_Find_Click);
            // 
            // B_Next4
            // 
            this.B_Next4.BackColor = System.Drawing.Color.Orange;
            this.B_Next4.Location = new System.Drawing.Point(360, 12);
            this.B_Next4.Name = "B_Next4";
            this.B_Next4.Size = new System.Drawing.Size(124, 45);
            this.B_Next4.TabIndex = 16;
            this.B_Next4.Text = "下一步 =>";
            this.B_Next4.UseVisualStyleBackColor = false;
            this.B_Next4.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step5
            // 
            this.TP_Step5.Controls.Add(this.B_Result_Image);
            this.TP_Step5.Controls.Add(this.B_Sample_Image2);
            this.TP_Step5.Controls.Add(this.B_Base_Image2);
            this.TP_Step5.Controls.Add(this.B_Finish);
            this.TP_Step5.Location = new System.Drawing.Point(4, 27);
            this.TP_Step5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TP_Step5.Name = "TP_Step5";
            this.TP_Step5.Size = new System.Drawing.Size(493, 707);
            this.TP_Step5.TabIndex = 6;
            this.TP_Step5.Text = "Step5";
            this.TP_Step5.UseVisualStyleBackColor = true;
            this.TP_Step5.Enter += new System.EventHandler(this.TP_Step5_Enter);
            // 
            // B_Result_Image
            // 
            this.B_Result_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Result_Image.Location = new System.Drawing.Point(35, 217);
            this.B_Result_Image.Name = "B_Result_Image";
            this.B_Result_Image.Size = new System.Drawing.Size(187, 61);
            this.B_Result_Image.TabIndex = 25;
            this.B_Result_Image.Text = "Result Image";
            this.B_Result_Image.UseVisualStyleBackColor = true;
            this.B_Result_Image.Click += new System.EventHandler(this.B_Result_Image_Click);
            // 
            // B_Sample_Image2
            // 
            this.B_Sample_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image2.Location = new System.Drawing.Point(35, 127);
            this.B_Sample_Image2.Name = "B_Sample_Image2";
            this.B_Sample_Image2.Size = new System.Drawing.Size(187, 61);
            this.B_Sample_Image2.TabIndex = 24;
            this.B_Sample_Image2.Text = "Trans Image";
            this.B_Sample_Image2.UseVisualStyleBackColor = true;
            this.B_Sample_Image2.Click += new System.EventHandler(this.B_Sample_Image2_Click);
            // 
            // B_Base_Image2
            // 
            this.B_Base_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image2.Location = new System.Drawing.Point(35, 41);
            this.B_Base_Image2.Name = "B_Base_Image2";
            this.B_Base_Image2.Size = new System.Drawing.Size(187, 61);
            this.B_Base_Image2.TabIndex = 23;
            this.B_Base_Image2.Text = "Base Image";
            this.B_Base_Image2.UseVisualStyleBackColor = true;
            this.B_Base_Image2.Click += new System.EventHandler(this.B_Base_Image2_Click);
            // 
            // B_Finish
            // 
            this.B_Finish.BackColor = System.Drawing.Color.Lime;
            this.B_Finish.Location = new System.Drawing.Point(360, 12);
            this.B_Finish.Name = "B_Finish";
            this.B_Finish.Size = new System.Drawing.Size(124, 45);
            this.B_Finish.TabIndex = 22;
            this.B_Finish.Text = "完成";
            this.B_Finish.UseVisualStyleBackColor = false;
            this.B_Finish.Click += new System.EventHandler(this.B_Finish_Click);
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(501, 74);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(628, 738);
            this.tFrame_JJS_HW1.TabIndex = 6;
            // 
            // TForm_Align_Mothed5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 812);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TForm_Align_Mothed5";
            this.Text = "TForm_Align_Mothed4";
            this.Shown += new System.EventHandler(this.TForm_Align_Mothed4_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Step0.ResumeLayout(false);
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step1.PerformLayout();
            this.TP_Step2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.TP_Step3.ResumeLayout(false);
            this.TP_Step4.ResumeLayout(false);
            this.TP_Step5.ResumeLayout(false);
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
        private System.Windows.Forms.Button B_Set_Default;
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
        private System.Windows.Forms.TabPage TP_Step4;
        private System.Windows.Forms.Button B_Next4;
        private System.Windows.Forms.TabPage TP_Step5;
        private System.Windows.Forms.Button B_Result_Image;
        private System.Windows.Forms.Button B_Sample_Image2;
        private System.Windows.Forms.Button B_Base_Image2;
        private System.Windows.Forms.Button B_Finish;
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private TFrame_Select_Model tFrame_Select_Model1;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.ListBox LB_Model;
        private System.Windows.Forms.Button B_Create_Model;
        private System.Windows.Forms.Button B_Base_Image_Find;
        private System.Windows.Forms.Button B_Sample_Image_Find;
    }
}