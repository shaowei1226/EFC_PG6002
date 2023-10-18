namespace EFC.Vision.Halcon
{
    partial class TForm_Find_ACF_Check
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Find_ACF_Check));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RB_Sor_Sample_Image = new System.Windows.Forms.RadioButton();
            this.RB_Sor_Base_Image = new System.Windows.Forms.RadioButton();
            this.B_Open = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Space = new System.Windows.Forms.TabPage();
            this.B_Select_Base_File = new System.Windows.Forms.Button();
            this.E_Base_Image_File_Name = new System.Windows.Forms.TextBox();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.B_Save_To_Base = new System.Windows.Forms.Button();
            this.B_Select_Sample_File = new System.Windows.Forms.Button();
            this.E_Sample_Image_File_Name = new System.Windows.Forms.TextBox();
            this.B_Sample_Image = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.TP_Step1 = new System.Windows.Forms.TabPage();
            this.B_Edit_Region = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TP_Step2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Max_Gray = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Min_Gray = new System.Windows.Forms.TextBox();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.B_Finish = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Space.SuspendLayout();
            this.TP_Step1.SuspendLayout();
            this.TP_Step2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TP_Step3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.B_Open);
            this.panel1.Controls.Add(this.B_Save);
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 64);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RB_Sor_Sample_Image);
            this.groupBox1.Controls.Add(this.RB_Sor_Base_Image);
            this.groupBox1.Location = new System.Drawing.Point(493, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 56);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 來源影像 ]";
            // 
            // RB_Sor_Sample_Image
            // 
            this.RB_Sor_Sample_Image.AutoSize = true;
            this.RB_Sor_Sample_Image.Checked = true;
            this.RB_Sor_Sample_Image.Location = new System.Drawing.Point(103, 26);
            this.RB_Sor_Sample_Image.Name = "RB_Sor_Sample_Image";
            this.RB_Sor_Sample_Image.Size = new System.Drawing.Size(78, 20);
            this.RB_Sor_Sample_Image.TabIndex = 1;
            this.RB_Sor_Sample_Image.TabStop = true;
            this.RB_Sor_Sample_Image.Text = "Sample";
            this.RB_Sor_Sample_Image.UseVisualStyleBackColor = true;
            this.RB_Sor_Sample_Image.CheckedChanged += new System.EventHandler(this.RB_Sor_Sample_Image_CheckedChanged);
            // 
            // RB_Sor_Base_Image
            // 
            this.RB_Sor_Base_Image.AutoSize = true;
            this.RB_Sor_Base_Image.Location = new System.Drawing.Point(17, 26);
            this.RB_Sor_Base_Image.Name = "RB_Sor_Base_Image";
            this.RB_Sor_Base_Image.Size = new System.Drawing.Size(60, 20);
            this.RB_Sor_Base_Image.TabIndex = 0;
            this.RB_Sor_Base_Image.Text = "Base";
            this.RB_Sor_Base_Image.UseVisualStyleBackColor = true;
            this.RB_Sor_Base_Image.CheckedChanged += new System.EventHandler(this.RB_Sor_Base_Image_CheckedChanged);
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.ImageIndex = 3;
            this.B_Open.ImageList = this.imageList1;
            this.B_Open.Location = new System.Drawing.Point(366, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(122, 64);
            this.B_Open.TabIndex = 8;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Open.UseVisualStyleBackColor = false;
            this.B_Open.Click += new System.EventHandler(this.B_Open_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "magic_wand.png");
            this.imageList1.Images.SetKeyName(1, "button_cross.png");
            this.imageList1.Images.SetKeyName(2, "hard_drive_download.png");
            this.imageList1.Images.SetKeyName(3, "hard_drive_upload.png");
            // 
            // B_Save
            // 
            this.B_Save.BackColor = System.Drawing.Color.White;
            this.B_Save.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save.ImageIndex = 2;
            this.B_Save.ImageList = this.imageList1;
            this.B_Save.Location = new System.Drawing.Point(244, 0);
            this.B_Save.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(122, 64);
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
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageKey = "button_cross.png";
            this.B_Cancel.ImageList = this.imageList1;
            this.B_Cancel.Location = new System.Drawing.Point(122, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(122, 64);
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
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.ImageIndex = 0;
            this.B_Apply.ImageList = this.imageList1;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(122, 64);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tabControl1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 64);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(437, 653);
            this.panel6.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Space);
            this.tabControl1.Controls.Add(this.TP_Step1);
            this.tabControl1.Controls.Add(this.TP_Step2);
            this.tabControl1.Controls.Add(this.TP_Step3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 653);
            this.tabControl1.TabIndex = 2;
            // 
            // TP_Space
            // 
            this.TP_Space.Controls.Add(this.B_Select_Base_File);
            this.TP_Space.Controls.Add(this.E_Base_Image_File_Name);
            this.TP_Space.Controls.Add(this.B_Base_Image);
            this.TP_Space.Controls.Add(this.B_Save_To_Base);
            this.TP_Space.Controls.Add(this.B_Select_Sample_File);
            this.TP_Space.Controls.Add(this.E_Sample_Image_File_Name);
            this.TP_Space.Controls.Add(this.B_Sample_Image);
            this.TP_Space.Controls.Add(this.B_Next);
            this.TP_Space.Location = new System.Drawing.Point(4, 24);
            this.TP_Space.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Space.Name = "TP_Space";
            this.TP_Space.Padding = new System.Windows.Forms.Padding(2);
            this.TP_Space.Size = new System.Drawing.Size(429, 625);
            this.TP_Space.TabIndex = 0;
            this.TP_Space.Text = "空白";
            this.TP_Space.UseVisualStyleBackColor = true;
            this.TP_Space.Enter += new System.EventHandler(this.TP_Space_Enter);
            // 
            // B_Select_Base_File
            // 
            this.B_Select_Base_File.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_File.Location = new System.Drawing.Point(224, 95);
            this.B_Select_Base_File.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Base_File.Name = "B_Select_Base_File";
            this.B_Select_Base_File.Size = new System.Drawing.Size(42, 23);
            this.B_Select_Base_File.TabIndex = 42;
            this.B_Select_Base_File.Text = "...";
            this.B_Select_Base_File.UseVisualStyleBackColor = true;
            this.B_Select_Base_File.Click += new System.EventHandler(this.B_Select_Base_File_Click);
            // 
            // E_Base_Image_File_Name
            // 
            this.E_Base_Image_File_Name.Enabled = false;
            this.E_Base_Image_File_Name.Location = new System.Drawing.Point(19, 94);
            this.E_Base_Image_File_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_Base_Image_File_Name.Name = "E_Base_Image_File_Name";
            this.E_Base_Image_File_Name.Size = new System.Drawing.Size(201, 24);
            this.E_Base_Image_File_Name.TabIndex = 41;
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.BackColor = System.Drawing.Color.Transparent;
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(19, 46);
            this.B_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(161, 44);
            this.B_Base_Image.TabIndex = 40;
            this.B_Base_Image.Text = "Base影像";
            this.B_Base_Image.UseVisualStyleBackColor = false;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // B_Save_To_Base
            // 
            this.B_Save_To_Base.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save_To_Base.Location = new System.Drawing.Point(184, 145);
            this.B_Save_To_Base.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save_To_Base.Name = "B_Save_To_Base";
            this.B_Save_To_Base.Size = new System.Drawing.Size(82, 44);
            this.B_Save_To_Base.TabIndex = 39;
            this.B_Save_To_Base.Text = "Save";
            this.B_Save_To_Base.UseVisualStyleBackColor = true;
            this.B_Save_To_Base.Click += new System.EventHandler(this.B_Save_To_Base_Click);
            // 
            // B_Select_Sample_File
            // 
            this.B_Select_Sample_File.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Sample_File.Location = new System.Drawing.Point(224, 195);
            this.B_Select_Sample_File.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Sample_File.Name = "B_Select_Sample_File";
            this.B_Select_Sample_File.Size = new System.Drawing.Size(42, 23);
            this.B_Select_Sample_File.TabIndex = 24;
            this.B_Select_Sample_File.Text = "...";
            this.B_Select_Sample_File.UseVisualStyleBackColor = true;
            this.B_Select_Sample_File.Click += new System.EventHandler(this.B_Select_Sample_File_Click);
            // 
            // E_Sample_Image_File_Name
            // 
            this.E_Sample_Image_File_Name.Enabled = false;
            this.E_Sample_Image_File_Name.Location = new System.Drawing.Point(19, 194);
            this.E_Sample_Image_File_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_Sample_Image_File_Name.Name = "E_Sample_Image_File_Name";
            this.E_Sample_Image_File_Name.Size = new System.Drawing.Size(201, 24);
            this.E_Sample_Image_File_Name.TabIndex = 23;
            // 
            // B_Sample_Image
            // 
            this.B_Sample_Image.BackColor = System.Drawing.Color.Transparent;
            this.B_Sample_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image.Location = new System.Drawing.Point(19, 146);
            this.B_Sample_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Sample_Image.Name = "B_Sample_Image";
            this.B_Sample_Image.Size = new System.Drawing.Size(161, 44);
            this.B_Sample_Image.TabIndex = 19;
            this.B_Sample_Image.Text = "Sample影像";
            this.B_Sample_Image.UseVisualStyleBackColor = false;
            this.B_Sample_Image.Click += new System.EventHandler(this.B_Sample_Image_Click);
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(317, 8);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(108, 39);
            this.B_Next.TabIndex = 18;
            this.B_Next.Text = "下一步 =>";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step1
            // 
            this.TP_Step1.Controls.Add(this.B_Edit_Region);
            this.TP_Step1.Controls.Add(this.button2);
            this.TP_Step1.Location = new System.Drawing.Point(4, 24);
            this.TP_Step1.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step1.Name = "TP_Step1";
            this.TP_Step1.Padding = new System.Windows.Forms.Padding(2);
            this.TP_Step1.Size = new System.Drawing.Size(429, 625);
            this.TP_Step1.TabIndex = 1;
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Step1_Enter);
            // 
            // B_Edit_Region
            // 
            this.B_Edit_Region.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Edit_Region.Location = new System.Drawing.Point(22, 16);
            this.B_Edit_Region.Margin = new System.Windows.Forms.Padding(2);
            this.B_Edit_Region.Name = "B_Edit_Region";
            this.B_Edit_Region.Size = new System.Drawing.Size(161, 44);
            this.B_Edit_Region.TabIndex = 27;
            this.B_Edit_Region.Text = "檢查區域";
            this.B_Edit_Region.UseVisualStyleBackColor = true;
            this.B_Edit_Region.Click += new System.EventHandler(this.B_Edit_Region_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(317, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 39);
            this.button2.TabIndex = 20;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TP_Step2
            // 
            this.TP_Step2.Controls.Add(this.panel2);
            this.TP_Step2.Location = new System.Drawing.Point(4, 24);
            this.TP_Step2.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Size = new System.Drawing.Size(429, 625);
            this.TP_Step2.TabIndex = 2;
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Step2_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 142);
            this.panel2.TabIndex = 29;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(317, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 39);
            this.button3.TabIndex = 21;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.E_Max_Gray);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.E_Min_Gray);
            this.groupBox3.Location = new System.Drawing.Point(17, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 87);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ 暗瑕疵參數 ]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 28;
            this.label2.Text = "Max_Gray";
            // 
            // E_Max_Gray
            // 
            this.E_Max_Gray.Location = new System.Drawing.Point(110, 53);
            this.E_Max_Gray.Name = "E_Max_Gray";
            this.E_Max_Gray.Size = new System.Drawing.Size(68, 24);
            this.E_Max_Gray.TabIndex = 29;
            this.E_Max_Gray.Text = "123";
            this.E_Max_Gray.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Min_Gray";
            // 
            // E_Min_Gray
            // 
            this.E_Min_Gray.Location = new System.Drawing.Point(110, 23);
            this.E_Min_Gray.Name = "E_Min_Gray";
            this.E_Min_Gray.Size = new System.Drawing.Size(68, 24);
            this.E_Min_Gray.TabIndex = 27;
            this.E_Min_Gray.Text = "123";
            this.E_Min_Gray.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.B_Finish);
            this.TP_Step3.Location = new System.Drawing.Point(4, 24);
            this.TP_Step3.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(429, 625);
            this.TP_Step3.TabIndex = 5;
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            this.TP_Step3.Enter += new System.EventHandler(this.TP_Step3_Enter);
            // 
            // B_Finish
            // 
            this.B_Finish.BackColor = System.Drawing.Color.Lime;
            this.B_Finish.Location = new System.Drawing.Point(317, 8);
            this.B_Finish.Margin = new System.Windows.Forms.Padding(2);
            this.B_Finish.Name = "B_Finish";
            this.B_Finish.Size = new System.Drawing.Size(108, 39);
            this.B_Finish.TabIndex = 19;
            this.B_Finish.Text = "完成";
            this.B_Finish.UseVisualStyleBackColor = false;
            this.B_Finish.Click += new System.EventHandler(this.B_Finish_Click);
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
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(437, 64);
            this.tFrame_JJS_HW1.Margin = new System.Windows.Forms.Padding(2);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = true;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(602, 653);
            this.tFrame_JJS_HW1.TabIndex = 4;
            // 
            // TForm_Find_ACF_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 717);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Find_ACF_Check";
            this.Text = "Form_Find_Mothed_1";
            this.Shown += new System.EventHandler(this.Form_Find_Mothed_1_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Space.ResumeLayout(false);
            this.TP_Space.PerformLayout();
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.TP_Step3.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage TP_Step1;
        private System.Windows.Forms.TabPage TP_Step2;
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button B_Finish;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button B_Sample_Image;
        private System.Windows.Forms.Button B_Select_Sample_File;
        private System.Windows.Forms.TextBox E_Sample_Image_File_Name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button B_Edit_Region;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Max_Gray;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Min_Gray;
        private System.Windows.Forms.Button B_Save_To_Base;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RB_Sor_Sample_Image;
        private System.Windows.Forms.RadioButton RB_Sor_Base_Image;
        private System.Windows.Forms.Button B_Select_Base_File;
        private System.Windows.Forms.TextBox E_Base_Image_File_Name;
        private System.Windows.Forms.Button B_Base_Image;
    }
}