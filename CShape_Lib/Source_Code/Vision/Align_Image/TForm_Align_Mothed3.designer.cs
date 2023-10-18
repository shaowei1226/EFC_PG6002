namespace EFC.Vision.Halcon
{
    partial class TForm_Align_Mothed3
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
            this.CB_Align_Angle = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RB_Align_Mode2 = new System.Windows.Forms.RadioButton();
            this.RB_Align_Mode1 = new System.Windows.Forms.RadioButton();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.B_Select_Rect1 = new System.Windows.Forms.Button();
            this.tFrame_Select_Model1 = new EFC.Vision.Halcon.TFrame_Select_Model();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.B_Select_Rect2 = new System.Windows.Forms.Button();
            this.tFrame_Select_Model2 = new EFC.Vision.Halcon.TFrame_Select_Model();
            this.B_Next3 = new System.Windows.Forms.Button();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.B_Next4 = new System.Windows.Forms.Button();
            this.TP_Step4 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.B_Next5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.TP_Step5 = new System.Windows.Forms.TabPage();
            this.B_Result_Image = new System.Windows.Forms.Button();
            this.B_Sample_Image2 = new System.Windows.Forms.Button();
            this.B_Base_Image2 = new System.Windows.Forms.Button();
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
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(442, 738);
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
            this.tabControl1.Size = new System.Drawing.Size(442, 738);
            this.tabControl1.TabIndex = 0;
            // 
            // TP_Step0
            // 
            this.TP_Step0.Controls.Add(this.B_Set_Default);
            this.TP_Step0.Controls.Add(this.B_Next1);
            this.TP_Step0.Location = new System.Drawing.Point(4, 27);
            this.TP_Step0.Name = "TP_Step0";
            this.TP_Step0.Padding = new System.Windows.Forms.Padding(3);
            this.TP_Step0.Size = new System.Drawing.Size(434, 707);
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
            this.B_Next1.Location = new System.Drawing.Point(288, 16);
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
            this.TP_Step1.Size = new System.Drawing.Size(434, 707);
            this.TP_Step1.TabIndex = 1;
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Step1_Enter);
            // 
            // B_Next2
            // 
            this.B_Next2.BackColor = System.Drawing.Color.Orange;
            this.B_Next2.Location = new System.Drawing.Point(288, 16);
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
            this.TP_Step2.Controls.Add(this.CB_Align_Angle);
            this.TP_Step2.Controls.Add(this.groupBox4);
            this.TP_Step2.Controls.Add(this.tabControl2);
            this.TP_Step2.Controls.Add(this.B_Next3);
            this.TP_Step2.Location = new System.Drawing.Point(4, 27);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Size = new System.Drawing.Size(434, 707);
            this.TP_Step2.TabIndex = 4;
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Step2_Enter);
            // 
            // CB_Align_Angle
            // 
            this.CB_Align_Angle.AutoSize = true;
            this.CB_Align_Angle.Location = new System.Drawing.Point(43, 119);
            this.CB_Align_Angle.Name = "CB_Align_Angle";
            this.CB_Align_Angle.Size = new System.Drawing.Size(102, 21);
            this.CB_Align_Angle.TabIndex = 29;
            this.CB_Align_Angle.Text = "角度定位";
            this.CB_Align_Angle.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RB_Align_Mode2);
            this.groupBox4.Controls.Add(this.RB_Align_Mode1);
            this.groupBox4.Location = new System.Drawing.Point(22, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 89);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[ 定位方式 ]";
            // 
            // RB_Align_Mode2
            // 
            this.RB_Align_Mode2.AutoSize = true;
            this.RB_Align_Mode2.Location = new System.Drawing.Point(21, 56);
            this.RB_Align_Mode2.Name = "RB_Align_Mode2";
            this.RB_Align_Mode2.Size = new System.Drawing.Size(101, 21);
            this.RB_Align_Mode2.TabIndex = 1;
            this.RB_Align_Mode2.TabStop = true;
            this.RB_Align_Mode2.Text = "雙點定位";
            this.RB_Align_Mode2.UseVisualStyleBackColor = true;
            // 
            // RB_Align_Mode1
            // 
            this.RB_Align_Mode1.AutoSize = true;
            this.RB_Align_Mode1.Location = new System.Drawing.Point(21, 29);
            this.RB_Align_Mode1.Name = "RB_Align_Mode1";
            this.RB_Align_Mode1.Size = new System.Drawing.Size(101, 21);
            this.RB_Align_Mode1.TabIndex = 0;
            this.RB_Align_Mode1.TabStop = true;
            this.RB_Align_Mode1.Text = "單點定位";
            this.RB_Align_Mode1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Location = new System.Drawing.Point(22, 167);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(406, 554);
            this.tabControl2.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_Select_Rect1);
            this.tabPage1.Controls.Add(this.tFrame_Select_Model1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(398, 523);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "標靶1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // B_Select_Rect1
            // 
            this.B_Select_Rect1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Rect1.Location = new System.Drawing.Point(17, 22);
            this.B_Select_Rect1.Name = "B_Select_Rect1";
            this.B_Select_Rect1.Size = new System.Drawing.Size(133, 51);
            this.B_Select_Rect1.TabIndex = 26;
            this.B_Select_Rect1.Text = "編輯參數";
            this.B_Select_Rect1.UseVisualStyleBackColor = true;
            this.B_Select_Rect1.Click += new System.EventHandler(this.B_Select_Rect1_Click_1);
            // 
            // tFrame_Select_Model1
            // 
            this.tFrame_Select_Model1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model1.Location = new System.Drawing.Point(17, 79);
            this.tFrame_Select_Model1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tFrame_Select_Model1.Name = "tFrame_Select_Model1";
            this.tFrame_Select_Model1.Size = new System.Drawing.Size(344, 393);
            this.tFrame_Select_Model1.TabIndex = 25;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.B_Select_Rect2);
            this.tabPage2.Controls.Add(this.tFrame_Select_Model2);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(398, 523);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "標靶2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // B_Select_Rect2
            // 
            this.B_Select_Rect2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Rect2.Location = new System.Drawing.Point(17, 23);
            this.B_Select_Rect2.Name = "B_Select_Rect2";
            this.B_Select_Rect2.Size = new System.Drawing.Size(133, 51);
            this.B_Select_Rect2.TabIndex = 28;
            this.B_Select_Rect2.Text = "編輯參數";
            this.B_Select_Rect2.UseVisualStyleBackColor = true;
            this.B_Select_Rect2.Click += new System.EventHandler(this.B_Select_Rect2_Click);
            // 
            // tFrame_Select_Model2
            // 
            this.tFrame_Select_Model2.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model2.Location = new System.Drawing.Point(17, 80);
            this.tFrame_Select_Model2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tFrame_Select_Model2.Name = "tFrame_Select_Model2";
            this.tFrame_Select_Model2.Size = new System.Drawing.Size(344, 393);
            this.tFrame_Select_Model2.TabIndex = 27;
            // 
            // B_Next3
            // 
            this.B_Next3.BackColor = System.Drawing.Color.Orange;
            this.B_Next3.Location = new System.Drawing.Point(288, 16);
            this.B_Next3.Name = "B_Next3";
            this.B_Next3.Size = new System.Drawing.Size(124, 45);
            this.B_Next3.TabIndex = 18;
            this.B_Next3.Text = "下一步 =>";
            this.B_Next3.UseVisualStyleBackColor = false;
            this.B_Next3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.button1);
            this.TP_Step3.Controls.Add(this.button7);
            this.TP_Step3.Controls.Add(this.B_Next4);
            this.TP_Step3.Location = new System.Drawing.Point(4, 27);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(434, 707);
            this.TP_Step3.TabIndex = 2;
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            this.TP_Step3.Enter += new System.EventHandler(this.TP_Step3_Enter);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(42, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 61);
            this.button1.TabIndex = 19;
            this.button1.Text = "Base Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(158, 18);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(124, 45);
            this.button7.TabIndex = 18;
            this.button7.Text = "更新";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // B_Next4
            // 
            this.B_Next4.BackColor = System.Drawing.Color.Orange;
            this.B_Next4.Location = new System.Drawing.Point(288, 16);
            this.B_Next4.Name = "B_Next4";
            this.B_Next4.Size = new System.Drawing.Size(124, 45);
            this.B_Next4.TabIndex = 16;
            this.B_Next4.Text = "下一步 =>";
            this.B_Next4.UseVisualStyleBackColor = false;
            this.B_Next4.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step4
            // 
            this.TP_Step4.Controls.Add(this.button3);
            this.TP_Step4.Controls.Add(this.B_Next5);
            this.TP_Step4.Controls.Add(this.button8);
            this.TP_Step4.Location = new System.Drawing.Point(4, 27);
            this.TP_Step4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TP_Step4.Name = "TP_Step4";
            this.TP_Step4.Size = new System.Drawing.Size(434, 707);
            this.TP_Step4.TabIndex = 5;
            this.TP_Step4.Text = "Step4";
            this.TP_Step4.UseVisualStyleBackColor = true;
            this.TP_Step4.Enter += new System.EventHandler(this.TP_Step4_Enter);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(40, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 61);
            this.button3.TabIndex = 21;
            this.button3.Text = "Trans Image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // B_Next5
            // 
            this.B_Next5.BackColor = System.Drawing.Color.Orange;
            this.B_Next5.Location = new System.Drawing.Point(288, 16);
            this.B_Next5.Name = "B_Next5";
            this.B_Next5.Size = new System.Drawing.Size(124, 45);
            this.B_Next5.TabIndex = 20;
            this.B_Next5.Text = "下一步 =>";
            this.B_Next5.UseVisualStyleBackColor = false;
            this.B_Next5.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(158, 17);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(124, 45);
            this.button8.TabIndex = 19;
            this.button8.Text = "更新";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // TP_Step5
            // 
            this.TP_Step5.Controls.Add(this.B_Result_Image);
            this.TP_Step5.Controls.Add(this.B_Sample_Image2);
            this.TP_Step5.Controls.Add(this.B_Base_Image2);
            this.TP_Step5.Controls.Add(this.button5);
            this.TP_Step5.Location = new System.Drawing.Point(4, 27);
            this.TP_Step5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TP_Step5.Name = "TP_Step5";
            this.TP_Step5.Size = new System.Drawing.Size(434, 707);
            this.TP_Step5.TabIndex = 6;
            this.TP_Step5.Text = "Step5";
            this.TP_Step5.UseVisualStyleBackColor = true;
            this.TP_Step5.Enter += new System.EventHandler(this.TP_Step5_Enter);
            // 
            // B_Result_Image
            // 
            this.B_Result_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Result_Image.Location = new System.Drawing.Point(35, 267);
            this.B_Result_Image.Name = "B_Result_Image";
            this.B_Result_Image.Size = new System.Drawing.Size(187, 61);
            this.B_Result_Image.TabIndex = 25;
            this.B_Result_Image.Text = "Result Image";
            this.B_Result_Image.UseVisualStyleBackColor = true;
            this.B_Result_Image.Click += new System.EventHandler(this.B_Result_Image_Click_1);
            // 
            // B_Sample_Image2
            // 
            this.B_Sample_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image2.Location = new System.Drawing.Point(35, 177);
            this.B_Sample_Image2.Name = "B_Sample_Image2";
            this.B_Sample_Image2.Size = new System.Drawing.Size(187, 61);
            this.B_Sample_Image2.TabIndex = 24;
            this.B_Sample_Image2.Text = "Trans Image";
            this.B_Sample_Image2.UseVisualStyleBackColor = true;
            this.B_Sample_Image2.Click += new System.EventHandler(this.B_Sample_Image2_Click_1);
            // 
            // B_Base_Image2
            // 
            this.B_Base_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image2.Location = new System.Drawing.Point(35, 91);
            this.B_Base_Image2.Name = "B_Base_Image2";
            this.B_Base_Image2.Size = new System.Drawing.Size(187, 61);
            this.B_Base_Image2.TabIndex = 23;
            this.B_Base_Image2.Text = "Base Image";
            this.B_Base_Image2.UseVisualStyleBackColor = true;
            this.B_Base_Image2.Click += new System.EventHandler(this.B_Base_Image2_Click_1);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lime;
            this.button5.Location = new System.Drawing.Point(288, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 45);
            this.button5.TabIndex = 22;
            this.button5.Text = "完成";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(442, 74);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(687, 738);
            this.tFrame_JJS_HW1.TabIndex = 6;
            // 
            // TForm_Align_Mothed3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 812);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TForm_Align_Mothed3";
            this.Text = "TForm_Align_Mothed2";
            this.Shown += new System.EventHandler(this.TForm_Align_Mothed2_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Step0.ResumeLayout(false);
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step1.PerformLayout();
            this.TP_Step2.ResumeLayout(false);
            this.TP_Step2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.Button B_Next4;
        private EFC.Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW1;
        private EFC.Vision.Halcon.TFrame_Select_Model tFrame_Select_Model1;
        private System.Windows.Forms.Button B_Select_Rect1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabPage TP_Step4;
        private System.Windows.Forms.Button B_Next5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TabPage TP_Step5;
        private System.Windows.Forms.CheckBox CB_Align_Angle;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RB_Align_Mode2;
        private System.Windows.Forms.RadioButton RB_Align_Mode1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button B_Select_Rect2;
        private TFrame_Select_Model tFrame_Select_Model2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button B_Result_Image;
        private System.Windows.Forms.Button B_Sample_Image2;
        private System.Windows.Forms.Button B_Base_Image2;
        private System.Windows.Forms.Button button5;
    }
}