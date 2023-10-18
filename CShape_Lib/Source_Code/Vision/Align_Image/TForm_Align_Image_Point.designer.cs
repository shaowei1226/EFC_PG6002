namespace EFC.Vision.Halcon
{
    partial class TForm_Align_Image_Point
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
            this.B_Select_Trans_Image = new System.Windows.Forms.Button();
            this.E_Trans_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Base_Image = new System.Windows.Forms.Button();
            this.E_Base_Image_File = new System.Windows.Forms.TextBox();
            this.B_Trans_Image = new System.Windows.Forms.Button();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.B_Set_Default = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.B_Create_Region = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_Trans_Image = new System.Windows.Forms.RadioButton();
            this.RB_Base_Image = new System.Windows.Forms.RadioButton();
            this.B_Update = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Point_Num = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Alpha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.E_Sigma_Smooth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Sigma_Grad = new System.Windows.Forms.TextBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RB_Match_Trans_Image = new System.Windows.Forms.RadioButton();
            this.RB_Match_Base_Image = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CB_Rand_Seed = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CB_Distance_Threshold = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CB_Estimation_Method = new System.Windows.Forms.ComboBox();
            this.CB_Match_Threshold = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CB_Rotation = new System.Windows.Forms.ComboBox();
            this.CB_Col_Tolerance = new System.Windows.Forms.ComboBox();
            this.CB_Row_Tolerance = new System.Windows.Forms.ComboBox();
            this.CB_Col_Move = new System.Windows.Forms.ComboBox();
            this.CB_Row_Move = new System.Windows.Forms.ComboBox();
            this.CB_Mask_Size = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_Get_Match_Method = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.RB_Step5_Image3 = new System.Windows.Forms.RadioButton();
            this.RB_Step5_Image2 = new System.Windows.Forms.RadioButton();
            this.RB_Step5_Image1 = new System.Windows.Forms.RadioButton();
            this.button5 = new System.Windows.Forms.Button();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(842, 59);
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
            this.B_Save.Margin = new System.Windows.Forms.Padding(2);
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
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
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
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // B_Select_Trans_Image
            // 
            this.B_Select_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Trans_Image.Location = new System.Drawing.Point(238, 221);
            this.B_Select_Trans_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Trans_Image.Name = "B_Select_Trans_Image";
            this.B_Select_Trans_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Trans_Image.TabIndex = 6;
            this.B_Select_Trans_Image.Text = "...";
            this.B_Select_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Select_Trans_Image.Click += new System.EventHandler(this.B_Select_Trans_Image_Click);
            // 
            // E_Trans_Image_File
            // 
            this.E_Trans_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Trans_Image_File.Location = new System.Drawing.Point(20, 221);
            this.E_Trans_Image_File.Margin = new System.Windows.Forms.Padding(2);
            this.E_Trans_Image_File.Name = "E_Trans_Image_File";
            this.E_Trans_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Trans_Image_File.TabIndex = 5;
            // 
            // B_Select_Base_Image
            // 
            this.B_Select_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_Image.Location = new System.Drawing.Point(238, 114);
            this.B_Select_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Base_Image.Name = "B_Select_Base_Image";
            this.B_Select_Base_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Base_Image.TabIndex = 4;
            this.B_Select_Base_Image.Text = "...";
            this.B_Select_Base_Image.UseVisualStyleBackColor = true;
            this.B_Select_Base_Image.Click += new System.EventHandler(this.B_Select_Base_Image_Click);
            // 
            // E_Base_Image_File
            // 
            this.E_Base_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Image_File.Location = new System.Drawing.Point(20, 114);
            this.E_Base_Image_File.Margin = new System.Windows.Forms.Padding(2);
            this.E_Base_Image_File.Name = "E_Base_Image_File";
            this.E_Base_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Base_Image_File.TabIndex = 3;
            // 
            // B_Trans_Image
            // 
            this.B_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Trans_Image.Location = new System.Drawing.Point(20, 167);
            this.B_Trans_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Trans_Image.Name = "B_Trans_Image";
            this.B_Trans_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Trans_Image.TabIndex = 1;
            this.B_Trans_Image.Text = "Sample Image";
            this.B_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Trans_Image.Click += new System.EventHandler(this.B_Trans_Image_Click);
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(20, 61);
            this.B_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(140, 49);
            this.B_Base_Image.TabIndex = 0;
            this.B_Base_Image.Text = "Base Image";
            this.B_Base_Image.UseVisualStyleBackColor = true;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 540);
            this.panel3.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(388, 540);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_Set_Default);
            this.tabPage1.Controls.Add(this.B_Next);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(380, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "空白";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // B_Set_Default
            // 
            this.B_Set_Default.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Set_Default.Location = new System.Drawing.Point(50, 72);
            this.B_Set_Default.Margin = new System.Windows.Forms.Padding(2);
            this.B_Set_Default.Name = "B_Set_Default";
            this.B_Set_Default.Size = new System.Drawing.Size(140, 49);
            this.B_Set_Default.TabIndex = 18;
            this.B_Set_Default.Text = "Set Default";
            this.B_Set_Default.UseVisualStyleBackColor = true;
            this.B_Set_Default.Click += new System.EventHandler(this.B_Set_Default_Click);
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(187, 5);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(93, 36);
            this.B_Next.TabIndex = 17;
            this.B_Next.Text = "下一步 =>";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.B_Base_Image);
            this.tabPage2.Controls.Add(this.E_Base_Image_File);
            this.tabPage2.Controls.Add(this.B_Select_Trans_Image);
            this.tabPage2.Controls.Add(this.B_Trans_Image);
            this.tabPage2.Controls.Add(this.E_Trans_Image_File);
            this.tabPage2.Controls.Add(this.B_Select_Base_Image);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(380, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step1";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(187, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 17;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.B_Create_Region);
            this.tabPage5.Controls.Add(this.button3);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(380, 512);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Step2";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Enter += new System.EventHandler(this.tabPage5_Enter);
            // 
            // B_Create_Region
            // 
            this.B_Create_Region.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Create_Region.Location = new System.Drawing.Point(24, 56);
            this.B_Create_Region.Margin = new System.Windows.Forms.Padding(2);
            this.B_Create_Region.Name = "B_Create_Region";
            this.B_Create_Region.Size = new System.Drawing.Size(122, 47);
            this.B_Create_Region.TabIndex = 20;
            this.B_Create_Region.Text = "Create Region";
            this.B_Create_Region.UseVisualStyleBackColor = true;
            this.B_Create_Region.Click += new System.EventHandler(this.B_Create_Region_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(187, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 36);
            this.button3.TabIndex = 18;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.B_Update);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(380, 512);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step3";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_Trans_Image);
            this.groupBox2.Controls.Add(this.RB_Base_Image);
            this.groupBox2.Location = new System.Drawing.Point(19, 191);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(220, 62);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "顯示結果";
            // 
            // RB_Trans_Image
            // 
            this.RB_Trans_Image.AutoSize = true;
            this.RB_Trans_Image.Location = new System.Drawing.Point(115, 30);
            this.RB_Trans_Image.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Trans_Image.Name = "RB_Trans_Image";
            this.RB_Trans_Image.Size = new System.Drawing.Size(103, 18);
            this.RB_Trans_Image.TabIndex = 1;
            this.RB_Trans_Image.Text = "Trans Image";
            this.RB_Trans_Image.UseVisualStyleBackColor = true;
            this.RB_Trans_Image.CheckedChanged += new System.EventHandler(this.RB_Trans_Image_CheckedChanged);
            // 
            // RB_Base_Image
            // 
            this.RB_Base_Image.AutoSize = true;
            this.RB_Base_Image.Checked = true;
            this.RB_Base_Image.Location = new System.Drawing.Point(14, 30);
            this.RB_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Base_Image.Name = "RB_Base_Image";
            this.RB_Base_Image.Size = new System.Drawing.Size(98, 18);
            this.RB_Base_Image.TabIndex = 0;
            this.RB_Base_Image.TabStop = true;
            this.RB_Base_Image.Text = "Base Image";
            this.RB_Base_Image.UseVisualStyleBackColor = true;
            this.RB_Base_Image.CheckedChanged += new System.EventHandler(this.RB_Base_Image_CheckedChanged);
            // 
            // B_Update
            // 
            this.B_Update.Location = new System.Drawing.Point(90, 5);
            this.B_Update.Margin = new System.Windows.Forms.Padding(2);
            this.B_Update.Name = "B_Update";
            this.B_Update.Size = new System.Drawing.Size(93, 36);
            this.B_Update.TabIndex = 17;
            this.B_Update.Text = "更新";
            this.B_Update.UseVisualStyleBackColor = true;
            this.B_Update.Click += new System.EventHandler(this.B_Update_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Orange;
            this.button4.Location = new System.Drawing.Point(187, 5);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 36);
            this.button4.TabIndex = 16;
            this.button4.Text = "下一步 =>";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_Point_Num);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Alpha);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.E_Sigma_Smooth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.E_Sigma_Grad);
            this.groupBox1.Location = new System.Drawing.Point(19, 50);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(220, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Point 參數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Point Number";
            // 
            // E_Point_Num
            // 
            this.E_Point_Num.Location = new System.Drawing.Point(143, 103);
            this.E_Point_Num.Margin = new System.Windows.Forms.Padding(2);
            this.E_Point_Num.Name = "E_Point_Num";
            this.E_Point_Num.Size = new System.Drawing.Size(62, 24);
            this.E_Point_Num.TabIndex = 9;
            this.E_Point_Num.Text = "1000";
            this.E_Point_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 6;
            this.label2.Text = "Alpha";
            // 
            // E_Alpha
            // 
            this.E_Alpha.Location = new System.Drawing.Point(143, 76);
            this.E_Alpha.Margin = new System.Windows.Forms.Padding(2);
            this.E_Alpha.Name = "E_Alpha";
            this.E_Alpha.Size = new System.Drawing.Size(62, 24);
            this.E_Alpha.TabIndex = 7;
            this.E_Alpha.Text = "0.08";
            this.E_Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sigma Smooth";
            // 
            // E_Sigma_Smooth
            // 
            this.E_Sigma_Smooth.Location = new System.Drawing.Point(143, 49);
            this.E_Sigma_Smooth.Margin = new System.Windows.Forms.Padding(2);
            this.E_Sigma_Smooth.Name = "E_Sigma_Smooth";
            this.E_Sigma_Smooth.Size = new System.Drawing.Size(62, 24);
            this.E_Sigma_Smooth.TabIndex = 5;
            this.E_Sigma_Smooth.Text = "2";
            this.E_Sigma_Smooth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 14);
            this.label5.TabIndex = 2;
            this.label5.Text = "Sigma Grad";
            // 
            // E_Sigma_Grad
            // 
            this.E_Sigma_Grad.Location = new System.Drawing.Point(143, 22);
            this.E_Sigma_Grad.Margin = new System.Windows.Forms.Padding(2);
            this.E_Sigma_Grad.Name = "E_Sigma_Grad";
            this.E_Sigma_Grad.Size = new System.Drawing.Size(62, 24);
            this.E_Sigma_Grad.TabIndex = 3;
            this.E_Sigma_Grad.Text = "0.7";
            this.E_Sigma_Grad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Controls.Add(this.groupBox4);
            this.tabPage6.Controls.Add(this.button10);
            this.tabPage6.Controls.Add(this.button9);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(380, 512);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Step4";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.Enter += new System.EventHandler(this.tabPage6_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RB_Match_Trans_Image);
            this.groupBox3.Controls.Add(this.RB_Match_Base_Image);
            this.groupBox3.Location = new System.Drawing.Point(67, 393);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(220, 62);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "顯示結果";
            // 
            // RB_Match_Trans_Image
            // 
            this.RB_Match_Trans_Image.AutoSize = true;
            this.RB_Match_Trans_Image.Location = new System.Drawing.Point(115, 30);
            this.RB_Match_Trans_Image.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Match_Trans_Image.Name = "RB_Match_Trans_Image";
            this.RB_Match_Trans_Image.Size = new System.Drawing.Size(103, 18);
            this.RB_Match_Trans_Image.TabIndex = 1;
            this.RB_Match_Trans_Image.Text = "Trans Image";
            this.RB_Match_Trans_Image.UseVisualStyleBackColor = true;
            this.RB_Match_Trans_Image.CheckedChanged += new System.EventHandler(this.RB_Match_Trans_Image_CheckedChanged);
            // 
            // RB_Match_Base_Image
            // 
            this.RB_Match_Base_Image.AutoSize = true;
            this.RB_Match_Base_Image.Checked = true;
            this.RB_Match_Base_Image.Location = new System.Drawing.Point(14, 30);
            this.RB_Match_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Match_Base_Image.Name = "RB_Match_Base_Image";
            this.RB_Match_Base_Image.Size = new System.Drawing.Size(98, 18);
            this.RB_Match_Base_Image.TabIndex = 0;
            this.RB_Match_Base_Image.TabStop = true;
            this.RB_Match_Base_Image.Text = "Base Image";
            this.RB_Match_Base_Image.UseVisualStyleBackColor = true;
            this.RB_Match_Base_Image.CheckedChanged += new System.EventHandler(this.RB_Match_Base_Image_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CB_Rand_Seed);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.CB_Distance_Threshold);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.CB_Estimation_Method);
            this.groupBox4.Controls.Add(this.CB_Match_Threshold);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.CB_Rotation);
            this.groupBox4.Controls.Add(this.CB_Col_Tolerance);
            this.groupBox4.Controls.Add(this.CB_Row_Tolerance);
            this.groupBox4.Controls.Add(this.CB_Col_Move);
            this.groupBox4.Controls.Add(this.CB_Row_Move);
            this.groupBox4.Controls.Add(this.CB_Mask_Size);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.CB_Get_Match_Method);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(14, 45);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(273, 335);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Find Match 參數";
            // 
            // CB_Rand_Seed
            // 
            this.CB_Rand_Seed.FormattingEnabled = true;
            this.CB_Rand_Seed.Items.AddRange(new object[] {
            "0",
            "1",
            "3",
            "5",
            "7",
            "9",
            "11"});
            this.CB_Rand_Seed.Location = new System.Drawing.Point(207, 299);
            this.CB_Rand_Seed.Name = "CB_Rand_Seed";
            this.CB_Rand_Seed.Size = new System.Drawing.Size(59, 22);
            this.CB_Rand_Seed.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 302);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 14);
            this.label15.TabIndex = 29;
            this.label15.Text = "Rand Seed";
            // 
            // CB_Distance_Threshold
            // 
            this.CB_Distance_Threshold.FormattingEnabled = true;
            this.CB_Distance_Threshold.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.5",
            "0.7",
            "1.0"});
            this.CB_Distance_Threshold.Location = new System.Drawing.Point(207, 271);
            this.CB_Distance_Threshold.Name = "CB_Distance_Threshold";
            this.CB_Distance_Threshold.Size = new System.Drawing.Size(59, 22);
            this.CB_Distance_Threshold.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 274);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(131, 14);
            this.label14.TabIndex = 27;
            this.label14.Text = "Distance Threshold";
            // 
            // CB_Estimation_Method
            // 
            this.CB_Estimation_Method.FormattingEnabled = true;
            this.CB_Estimation_Method.Items.AddRange(new object[] {
            "gold_standard",
            "normalized_dlt"});
            this.CB_Estimation_Method.Location = new System.Drawing.Point(151, 243);
            this.CB_Estimation_Method.Name = "CB_Estimation_Method";
            this.CB_Estimation_Method.Size = new System.Drawing.Size(115, 22);
            this.CB_Estimation_Method.TabIndex = 26;
            // 
            // CB_Match_Threshold
            // 
            this.CB_Match_Threshold.FormattingEnabled = true;
            this.CB_Match_Threshold.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.CB_Match_Threshold.Location = new System.Drawing.Point(207, 216);
            this.CB_Match_Threshold.Name = "CB_Match_Threshold";
            this.CB_Match_Threshold.Size = new System.Drawing.Size(59, 22);
            this.CB_Match_Threshold.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 247);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 14);
            this.label13.TabIndex = 25;
            this.label13.Text = "Estimation Method";
            // 
            // CB_Rotation
            // 
            this.CB_Rotation.FormattingEnabled = true;
            this.CB_Rotation.Items.AddRange(new object[] {
            "0.0",
            "0.79",
            "1.57",
            "3.14"});
            this.CB_Rotation.Location = new System.Drawing.Point(207, 188);
            this.CB_Rotation.Name = "CB_Rotation";
            this.CB_Rotation.Size = new System.Drawing.Size(59, 22);
            this.CB_Rotation.TabIndex = 23;
            // 
            // CB_Col_Tolerance
            // 
            this.CB_Col_Tolerance.FormattingEnabled = true;
            this.CB_Col_Tolerance.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512"});
            this.CB_Col_Tolerance.Location = new System.Drawing.Point(207, 160);
            this.CB_Col_Tolerance.Name = "CB_Col_Tolerance";
            this.CB_Col_Tolerance.Size = new System.Drawing.Size(59, 22);
            this.CB_Col_Tolerance.TabIndex = 22;
            // 
            // CB_Row_Tolerance
            // 
            this.CB_Row_Tolerance.FormattingEnabled = true;
            this.CB_Row_Tolerance.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512"});
            this.CB_Row_Tolerance.Location = new System.Drawing.Point(207, 132);
            this.CB_Row_Tolerance.Name = "CB_Row_Tolerance";
            this.CB_Row_Tolerance.Size = new System.Drawing.Size(59, 22);
            this.CB_Row_Tolerance.TabIndex = 21;
            // 
            // CB_Col_Move
            // 
            this.CB_Col_Move.FormattingEnabled = true;
            this.CB_Col_Move.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "50",
            "100",
            "200",
            "500"});
            this.CB_Col_Move.Location = new System.Drawing.Point(207, 104);
            this.CB_Col_Move.Name = "CB_Col_Move";
            this.CB_Col_Move.Size = new System.Drawing.Size(59, 22);
            this.CB_Col_Move.TabIndex = 20;
            // 
            // CB_Row_Move
            // 
            this.CB_Row_Move.FormattingEnabled = true;
            this.CB_Row_Move.Items.AddRange(new object[] {
            "0",
            "10",
            "20",
            "50",
            "100",
            "200",
            "500"});
            this.CB_Row_Move.Location = new System.Drawing.Point(207, 77);
            this.CB_Row_Move.Name = "CB_Row_Move";
            this.CB_Row_Move.Size = new System.Drawing.Size(59, 22);
            this.CB_Row_Move.TabIndex = 19;
            // 
            // CB_Mask_Size
            // 
            this.CB_Mask_Size.FormattingEnabled = true;
            this.CB_Mask_Size.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "50",
            "70",
            "90"});
            this.CB_Mask_Size.Location = new System.Drawing.Point(207, 49);
            this.CB_Mask_Size.Name = "CB_Mask_Size";
            this.CB_Mask_Size.Size = new System.Drawing.Size(59, 22);
            this.CB_Mask_Size.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 218);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 14);
            this.label12.TabIndex = 17;
            this.label12.Text = "Match Threshold";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 190);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 15;
            this.label11.Text = "Rotation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 162);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "Col Tolerance";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 134);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 14);
            this.label10.TabIndex = 11;
            this.label10.Text = "Row Tolerance";
            // 
            // CB_Get_Match_Method
            // 
            this.CB_Get_Match_Method.FormattingEnabled = true;
            this.CB_Get_Match_Method.Items.AddRange(new object[] {
            "ssd",
            "sad",
            "ncc"});
            this.CB_Get_Match_Method.Location = new System.Drawing.Point(207, 21);
            this.CB_Get_Match_Method.Name = "CB_Get_Match_Method";
            this.CB_Get_Match_Method.Size = new System.Drawing.Size(59, 22);
            this.CB_Get_Match_Method.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Col Move";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 79);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Row Move";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Mask Size";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 14);
            this.label8.TabIndex = 2;
            this.label8.Text = "Gray Match Method";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(90, 5);
            this.button10.Margin = new System.Windows.Forms.Padding(2);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(93, 36);
            this.button10.TabIndex = 18;
            this.button10.Text = "更新";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Orange;
            this.button9.Location = new System.Drawing.Point(187, 5);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(93, 36);
            this.button9.TabIndex = 17;
            this.button9.Text = "下一步 =>";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(380, 512);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step5";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Enter += new System.EventHandler(this.tabPage4_Enter);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.RB_Step5_Image3);
            this.groupBox5.Controls.Add(this.RB_Step5_Image2);
            this.groupBox5.Controls.Add(this.RB_Step5_Image1);
            this.groupBox5.Location = new System.Drawing.Point(28, 57);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(172, 100);
            this.groupBox5.TabIndex = 27;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "顯示來源";
            // 
            // RB_Step5_Image3
            // 
            this.RB_Step5_Image3.AutoSize = true;
            this.RB_Step5_Image3.Checked = true;
            this.RB_Step5_Image3.Location = new System.Drawing.Point(6, 71);
            this.RB_Step5_Image3.Name = "RB_Step5_Image3";
            this.RB_Step5_Image3.Size = new System.Drawing.Size(109, 18);
            this.RB_Step5_Image3.TabIndex = 2;
            this.RB_Step5_Image3.TabStop = true;
            this.RB_Step5_Image3.Text = "Result Image";
            this.RB_Step5_Image3.UseVisualStyleBackColor = true;
            this.RB_Step5_Image3.CheckedChanged += new System.EventHandler(this.RB_Step5_Image1_CheckedChanged);
            // 
            // RB_Step5_Image2
            // 
            this.RB_Step5_Image2.AutoSize = true;
            this.RB_Step5_Image2.Location = new System.Drawing.Point(6, 47);
            this.RB_Step5_Image2.Name = "RB_Step5_Image2";
            this.RB_Step5_Image2.Size = new System.Drawing.Size(114, 18);
            this.RB_Step5_Image2.TabIndex = 1;
            this.RB_Step5_Image2.Text = "Sample Image";
            this.RB_Step5_Image2.UseVisualStyleBackColor = true;
            this.RB_Step5_Image2.CheckedChanged += new System.EventHandler(this.RB_Step5_Image1_CheckedChanged);
            // 
            // RB_Step5_Image1
            // 
            this.RB_Step5_Image1.AutoSize = true;
            this.RB_Step5_Image1.Location = new System.Drawing.Point(6, 23);
            this.RB_Step5_Image1.Name = "RB_Step5_Image1";
            this.RB_Step5_Image1.Size = new System.Drawing.Size(98, 18);
            this.RB_Step5_Image1.TabIndex = 0;
            this.RB_Step5_Image1.Text = "Base Image";
            this.RB_Step5_Image1.UseVisualStyleBackColor = true;
            this.RB_Step5_Image1.CheckedChanged += new System.EventHandler(this.RB_Step5_Image1_CheckedChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lime;
            this.button5.Location = new System.Drawing.Point(187, 5);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 36);
            this.button5.TabIndex = 18;
            this.button5.Text = "完成";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(388, 59);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(454, 540);
            this.tFrame_JJS_HW1.TabIndex = 5;
            // 
            // TForm_Align_Image_Point
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 599);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Align_Image_Point";
            this.Text = "TForm_Align_Mothed";
            this.Shown += new System.EventHandler(this.TForm_Align_Mothed_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Button B_Select_Base_Image;
        private System.Windows.Forms.TextBox E_Base_Image_File;
        private System.Windows.Forms.Button B_Trans_Image;
        private System.Windows.Forms.Button B_Base_Image;
        private System.Windows.Forms.Button B_Select_Trans_Image;
        private System.Windows.Forms.TextBox E_Trans_Image_File;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Point_Num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Alpha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox E_Sigma_Smooth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox E_Sigma_Grad;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button B_Update;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_Trans_Image;
        private System.Windows.Forms.RadioButton RB_Base_Image;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button B_Create_Region;
        private System.Windows.Forms.Button B_Set_Default;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ComboBox CB_Rand_Seed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CB_Distance_Threshold;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox CB_Estimation_Method;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox CB_Match_Threshold;
        private System.Windows.Forms.ComboBox CB_Rotation;
        private System.Windows.Forms.ComboBox CB_Col_Tolerance;
        private System.Windows.Forms.ComboBox CB_Row_Tolerance;
        private System.Windows.Forms.ComboBox CB_Col_Move;
        private System.Windows.Forms.ComboBox CB_Row_Move;
        private System.Windows.Forms.ComboBox CB_Mask_Size;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CB_Get_Match_Method;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RB_Match_Trans_Image;
        private System.Windows.Forms.RadioButton RB_Match_Base_Image;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton RB_Step5_Image3;
        private System.Windows.Forms.RadioButton RB_Step5_Image2;
        private System.Windows.Forms.RadioButton RB_Step5_Image1;
    }
}