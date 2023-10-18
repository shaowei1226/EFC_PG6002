namespace EFC.Vision.Halcon
{
    partial class TForm_ACF_Check
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Space = new System.Windows.Forms.TabPage();
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.E_Base_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Base_Image = new System.Windows.Forms.Button();
            this.B_Select_Trans_Image = new System.Windows.Forms.Button();
            this.B_Trans_Image = new System.Windows.Forms.Button();
            this.E_Trans_Image_File = new System.Windows.Forms.TextBox();
            this.TP_Step1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.E_Std_Ofs = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.B_Save_To_OK_Image = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.TP_Step2 = new System.Windows.Forms.TabPage();
            this.E_Edit_Find_Region = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_Edit_Model_Param = new System.Windows.Forms.Button();
            this.CB_Used_Align_Image = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.TP_Step4 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.TP_Step5 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LB_Process = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.TP_Step6 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.B_Copy_Base = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Space.SuspendLayout();
            this.TP_Step1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.TP_Step2.SuspendLayout();
            this.TP_Step3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TP_Step4.SuspendLayout();
            this.TP_Step5.SuspendLayout();
            this.TP_Step6.SuspendLayout();
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
            this.panel6.Location = new System.Drawing.Point(0, 59);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 603);
            this.panel6.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Space);
            this.tabControl1.Controls.Add(this.TP_Step1);
            this.tabControl1.Controls.Add(this.TP_Step2);
            this.tabControl1.Controls.Add(this.TP_Step3);
            this.tabControl1.Controls.Add(this.TP_Step4);
            this.tabControl1.Controls.Add(this.TP_Step5);
            this.tabControl1.Controls.Add(this.TP_Step6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 603);
            this.tabControl1.TabIndex = 2;
            // 
            // TP_Space
            // 
            this.TP_Space.Controls.Add(this.B_Copy_Base);
            this.TP_Space.Controls.Add(this.B_Next);
            this.TP_Space.Controls.Add(this.B_Base_Image);
            this.TP_Space.Controls.Add(this.E_Base_Image_File);
            this.TP_Space.Controls.Add(this.B_Select_Base_Image);
            this.TP_Space.Controls.Add(this.B_Select_Trans_Image);
            this.TP_Space.Controls.Add(this.B_Trans_Image);
            this.TP_Space.Controls.Add(this.E_Trans_Image_File);
            this.TP_Space.Location = new System.Drawing.Point(4, 24);
            this.TP_Space.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Space.Name = "TP_Space";
            this.TP_Space.Padding = new System.Windows.Forms.Padding(2);
            this.TP_Space.Size = new System.Drawing.Size(367, 575);
            this.TP_Space.TabIndex = 0;
            this.TP_Space.Tag = "0";
            this.TP_Space.Text = "空白";
            this.TP_Space.UseVisualStyleBackColor = true;
            this.TP_Space.Enter += new System.EventHandler(this.TP_Space_Enter);
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(270, 4);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(93, 36);
            this.B_Next.TabIndex = 18;
            this.B_Next.Text = "下一步 =>";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(16, 48);
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
            this.E_Base_Image_File.Location = new System.Drawing.Point(16, 101);
            this.E_Base_Image_File.Margin = new System.Windows.Forms.Padding(2);
            this.E_Base_Image_File.Name = "E_Base_Image_File";
            this.E_Base_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Base_Image_File.TabIndex = 27;
            this.E_Base_Image_File.TextChanged += new System.EventHandler(this.E_Base_Image_File_TextChanged);
            // 
            // B_Select_Base_Image
            // 
            this.B_Select_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_Image.Location = new System.Drawing.Point(234, 101);
            this.B_Select_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Base_Image.Name = "B_Select_Base_Image";
            this.B_Select_Base_Image.Size = new System.Drawing.Size(41, 25);
            this.B_Select_Base_Image.TabIndex = 28;
            this.B_Select_Base_Image.Text = "...";
            this.B_Select_Base_Image.UseVisualStyleBackColor = true;
            this.B_Select_Base_Image.Click += new System.EventHandler(this.B_Select_Base_Image_Click);
            // 
            // B_Select_Trans_Image
            // 
            this.B_Select_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Trans_Image.Location = new System.Drawing.Point(234, 200);
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
            this.B_Trans_Image.Location = new System.Drawing.Point(16, 147);
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
            this.E_Trans_Image_File.Location = new System.Drawing.Point(16, 200);
            this.E_Trans_Image_File.Margin = new System.Windows.Forms.Padding(2);
            this.E_Trans_Image_File.Name = "E_Trans_Image_File";
            this.E_Trans_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Trans_Image_File.TabIndex = 29;
            // 
            // TP_Step1
            // 
            this.TP_Step1.Controls.Add(this.groupBox2);
            this.TP_Step1.Controls.Add(this.B_Save_To_OK_Image);
            this.TP_Step1.Controls.Add(this.label3);
            this.TP_Step1.Controls.Add(this.button13);
            this.TP_Step1.Location = new System.Drawing.Point(4, 24);
            this.TP_Step1.Name = "TP_Step1";
            this.TP_Step1.Size = new System.Drawing.Size(367, 575);
            this.TP_Step1.TabIndex = 6;
            this.TP_Step1.Tag = "1";
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Space_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.E_Std_Ofs);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Location = new System.Drawing.Point(22, 111);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(198, 138);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 32;
            this.label2.Text = "Std Ofs";
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button11.Location = new System.Drawing.Point(18, 53);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(162, 54);
            this.button11.TabIndex = 35;
            this.button11.Text = "計算Golden影像";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // E_Std_Ofs
            // 
            this.E_Std_Ofs.Location = new System.Drawing.Point(103, 21);
            this.E_Std_Ofs.Name = "E_Std_Ofs";
            this.E_Std_Ofs.Size = new System.Drawing.Size(41, 24);
            this.E_Std_Ofs.TabIndex = 31;
            this.E_Std_Ofs.Text = "1.0";
            this.E_Std_Ofs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 111);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(162, 16);
            this.progressBar1.TabIndex = 36;
            // 
            // B_Save_To_OK_Image
            // 
            this.B_Save_To_OK_Image.BackColor = System.Drawing.SystemColors.Control;
            this.B_Save_To_OK_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save_To_OK_Image.Location = new System.Drawing.Point(22, 60);
            this.B_Save_To_OK_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save_To_OK_Image.Name = "B_Save_To_OK_Image";
            this.B_Save_To_OK_Image.Size = new System.Drawing.Size(198, 44);
            this.B_Save_To_OK_Image.TabIndex = 39;
            this.B_Save_To_OK_Image.Text = "Copy to OK Image";
            this.B_Save_To_OK_Image.UseVisualStyleBackColor = false;
            this.B_Save_To_OK_Image.Click += new System.EventHandler(this.B_Save_To_OK_Image_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(18, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 22);
            this.label3.TabIndex = 38;
            this.label3.Text = "生成標準檔案";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Orange;
            this.button13.Location = new System.Drawing.Point(270, 4);
            this.button13.Margin = new System.Windows.Forms.Padding(2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(93, 36);
            this.button13.TabIndex = 37;
            this.button13.Text = "下一步 =>";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step2
            // 
            this.TP_Step2.Controls.Add(this.E_Edit_Find_Region);
            this.TP_Step2.Controls.Add(this.button2);
            this.TP_Step2.Location = new System.Drawing.Point(4, 24);
            this.TP_Step2.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Padding = new System.Windows.Forms.Padding(2);
            this.TP_Step2.Size = new System.Drawing.Size(367, 575);
            this.TP_Step2.TabIndex = 1;
            this.TP_Step2.Tag = "2";
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Space_Enter);
            // 
            // E_Edit_Find_Region
            // 
            this.E_Edit_Find_Region.BackColor = System.Drawing.Color.LightSteelBlue;
            this.E_Edit_Find_Region.Location = new System.Drawing.Point(21, 39);
            this.E_Edit_Find_Region.Margin = new System.Windows.Forms.Padding(2);
            this.E_Edit_Find_Region.Name = "E_Edit_Find_Region";
            this.E_Edit_Find_Region.Size = new System.Drawing.Size(147, 69);
            this.E_Edit_Find_Region.TabIndex = 24;
            this.E_Edit_Find_Region.Text = "編輯檢查區域";
            this.E_Edit_Find_Region.UseVisualStyleBackColor = false;
            this.E_Edit_Find_Region.Click += new System.EventHandler(this.E_Edit_Find_Region_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(270, 4);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 20;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.groupBox1);
            this.TP_Step3.Controls.Add(this.button12);
            this.TP_Step3.Location = new System.Drawing.Point(4, 24);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(367, 575);
            this.TP_Step3.TabIndex = 5;
            this.TP_Step3.Tag = "3";
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            this.TP_Step3.Enter += new System.EventHandler(this.TP_Space_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B_Edit_Model_Param);
            this.groupBox1.Controls.Add(this.CB_Used_Align_Image);
            this.groupBox1.Location = new System.Drawing.Point(8, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 89);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 影像教正參數 ]";
            // 
            // B_Edit_Model_Param
            // 
            this.B_Edit_Model_Param.BackColor = System.Drawing.Color.LightSteelBlue;
            this.B_Edit_Model_Param.Location = new System.Drawing.Point(19, 22);
            this.B_Edit_Model_Param.Margin = new System.Windows.Forms.Padding(2);
            this.B_Edit_Model_Param.Name = "B_Edit_Model_Param";
            this.B_Edit_Model_Param.Size = new System.Drawing.Size(188, 54);
            this.B_Edit_Model_Param.TabIndex = 22;
            this.B_Edit_Model_Param.Text = "編輯校正參數";
            this.B_Edit_Model_Param.UseVisualStyleBackColor = false;
            this.B_Edit_Model_Param.Click += new System.EventHandler(this.B_Edit_Model_Param_Click);
            // 
            // CB_Used_Align_Image
            // 
            this.CB_Used_Align_Image.AutoSize = true;
            this.CB_Used_Align_Image.Location = new System.Drawing.Point(137, 0);
            this.CB_Used_Align_Image.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Used_Align_Image.Name = "CB_Used_Align_Image";
            this.CB_Used_Align_Image.Size = new System.Drawing.Size(86, 18);
            this.CB_Used_Align_Image.TabIndex = 23;
            this.CB_Used_Align_Image.Text = "使用校正";
            this.CB_Used_Align_Image.UseVisualStyleBackColor = true;
            this.CB_Used_Align_Image.CheckedChanged += new System.EventHandler(this.CB_Used_Find_Model_CheckedChanged);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Orange;
            this.button12.Location = new System.Drawing.Point(270, 4);
            this.button12.Margin = new System.Windows.Forms.Padding(2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(93, 36);
            this.button12.TabIndex = 24;
            this.button12.Text = "下一步 =>";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step4
            // 
            this.TP_Step4.Controls.Add(this.label1);
            this.TP_Step4.Controls.Add(this.button3);
            this.TP_Step4.Location = new System.Drawing.Point(4, 24);
            this.TP_Step4.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step4.Name = "TP_Step4";
            this.TP_Step4.Size = new System.Drawing.Size(367, 575);
            this.TP_Step4.TabIndex = 2;
            this.TP_Step4.Tag = "4";
            this.TP_Step4.Text = "Step4";
            this.TP_Step4.UseVisualStyleBackColor = true;
            this.TP_Step4.Enter += new System.EventHandler(this.TP_Space_Enter);
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
            this.button3.Location = new System.Drawing.Point(270, 4);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 36);
            this.button3.TabIndex = 21;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step5
            // 
            this.TP_Step5.Controls.Add(this.button10);
            this.TP_Step5.Controls.Add(this.button9);
            this.TP_Step5.Controls.Add(this.button5);
            this.TP_Step5.Controls.Add(this.button8);
            this.TP_Step5.Controls.Add(this.button4);
            this.TP_Step5.Controls.Add(this.label4);
            this.TP_Step5.Controls.Add(this.button1);
            this.TP_Step5.Controls.Add(this.LB_Process);
            this.TP_Step5.Controls.Add(this.button6);
            this.TP_Step5.Location = new System.Drawing.Point(4, 24);
            this.TP_Step5.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step5.Name = "TP_Step5";
            this.TP_Step5.Size = new System.Drawing.Size(367, 575);
            this.TP_Step5.TabIndex = 4;
            this.TP_Step5.Tag = "5";
            this.TP_Step5.Text = "Step5";
            this.TP_Step5.UseVisualStyleBackColor = true;
            this.TP_Step5.Enter += new System.EventHandler(this.TP_Space_Enter);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button10.Location = new System.Drawing.Point(15, 134);
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
            this.button9.Location = new System.Drawing.Point(15, 170);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(140, 32);
            this.button9.TabIndex = 40;
            this.button9.Text = "Result Image";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button5.Location = new System.Drawing.Point(15, 81);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(140, 32);
            this.button5.TabIndex = 39;
            this.button5.Text = "Max Image";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button8.Location = new System.Drawing.Point(15, 45);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(140, 32);
            this.button8.TabIndex = 38;
            this.button8.Text = "Min Image";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(15, 9);
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
            this.label4.Location = new System.Drawing.Point(16, 222);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 22);
            this.label4.TabIndex = 35;
            this.label4.Text = "影像過濾條件";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Location = new System.Drawing.Point(218, 206);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 46);
            this.button1.TabIndex = 34;
            this.button1.Text = "編輯影像過濾條件";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LB_Process
            // 
            this.LB_Process.FormattingEnabled = true;
            this.LB_Process.ItemHeight = 14;
            this.LB_Process.Location = new System.Drawing.Point(15, 255);
            this.LB_Process.Margin = new System.Windows.Forms.Padding(2);
            this.LB_Process.Name = "LB_Process";
            this.LB_Process.Size = new System.Drawing.Size(344, 494);
            this.LB_Process.TabIndex = 33;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Orange;
            this.button6.Location = new System.Drawing.Point(270, 4);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 36);
            this.button6.TabIndex = 21;
            this.button6.Text = "下一步 =>";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step6
            // 
            this.TP_Step6.Controls.Add(this.button7);
            this.TP_Step6.Location = new System.Drawing.Point(4, 24);
            this.TP_Step6.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step6.Name = "TP_Step6";
            this.TP_Step6.Size = new System.Drawing.Size(367, 575);
            this.TP_Step6.TabIndex = 3;
            this.TP_Step6.Tag = "6";
            this.TP_Step6.Text = "Step6";
            this.TP_Step6.UseVisualStyleBackColor = true;
            this.TP_Step6.Enter += new System.EventHandler(this.TP_Space_Enter);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Lime;
            this.button7.Location = new System.Drawing.Point(270, 4);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 36);
            this.button7.TabIndex = 25;
            this.button7.Text = "完成";
            this.button7.UseVisualStyleBackColor = false;
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
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(375, 59);
            this.tFrame_JJS_HW1.Margin = new System.Windows.Forms.Padding(2);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = true;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(516, 603);
            this.tFrame_JJS_HW1.TabIndex = 4;
            // 
            // B_Copy_Base
            // 
            this.B_Copy_Base.BackColor = System.Drawing.SystemColors.Control;
            this.B_Copy_Base.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Copy_Base.Location = new System.Drawing.Point(16, 241);
            this.B_Copy_Base.Margin = new System.Windows.Forms.Padding(2);
            this.B_Copy_Base.Name = "B_Copy_Base";
            this.B_Copy_Base.Size = new System.Drawing.Size(208, 44);
            this.B_Copy_Base.TabIndex = 40;
            this.B_Copy_Base.Text = "Copy Base";
            this.B_Copy_Base.UseVisualStyleBackColor = false;
            this.B_Copy_Base.Click += new System.EventHandler(this.B_Copy_Base_Click);
            // 
            // TForm_ACF_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 662);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_ACF_Check";
            this.Text = "Form_Find_Mothed_1";
            this.Shown += new System.EventHandler(this.Form_Find_Barcode1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Space.ResumeLayout(false);
            this.TP_Space.PerformLayout();
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TP_Step2.ResumeLayout(false);
            this.TP_Step3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TP_Step4.ResumeLayout(false);
            this.TP_Step4.PerformLayout();
            this.TP_Step5.ResumeLayout(false);
            this.TP_Step5.PerformLayout();
            this.TP_Step6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Space;
        private System.Windows.Forms.TabPage TP_Step2;
        private System.Windows.Forms.TabPage TP_Step4;
        private System.Windows.Forms.TabPage TP_Step6;
        private System.Windows.Forms.TabPage TP_Step5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button B_Next;
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Std_Ofs;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage TP_Step1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button B_Save_To_OK_Image;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Copy_Base;
    }
}