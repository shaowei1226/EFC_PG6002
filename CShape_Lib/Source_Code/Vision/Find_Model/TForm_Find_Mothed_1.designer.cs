namespace EFC.Vision.Halcon
{
    partial class TForm_Find_Mothed_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Find_Mothed_1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RB_Sor_Sample_Image = new System.Windows.Forms.RadioButton();
            this.RB_Sor_Base_Image = new System.Windows.Forms.RadioButton();
            this.B_Open = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.B_Save_Base_Image = new System.Windows.Forms.Button();
            this.B_Select_Base_File = new System.Windows.Forms.Button();
            this.E_Base_Image_File_Name = new System.Windows.Forms.TextBox();
            this.B_Select_Sample_File = new System.Windows.Forms.Button();
            this.E_Sample_Image_File_Name = new System.Windows.Forms.TextBox();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.B_Sample_Image = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tFrame_Create_Param1 = new EFC.Vision.Halcon.TFrame_Create_Param();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tFrame_Select_Model1 = new EFC.Vision.Halcon.TFrame_Select_Model();
            this.B_Select_Center = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.E_Ofs_Y = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Ofs_X = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_Auto_Select_Region = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.B_Select_Rect = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_Rect_Col2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.E_Rect_Row2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Rect_Col1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Rect_Row1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Rect_Max = new System.Windows.Forms.Button();
            this.B_Rect_Edit = new System.Windows.Forms.Button();
            this.B_Rect_Select = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tFrame_Find_Param1 = new EFC.Vision.Halcon.TFrame_Find_Param();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.groupBox3);
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RB_Sor_Sample_Image);
            this.groupBox3.Controls.Add(this.RB_Sor_Base_Image);
            this.groupBox3.Location = new System.Drawing.Point(493, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(202, 56);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ 來源影像 ]";
            // 
            // RB_Sor_Sample_Image
            // 
            this.RB_Sor_Sample_Image.AutoSize = true;
            this.RB_Sor_Sample_Image.Location = new System.Drawing.Point(103, 26);
            this.RB_Sor_Sample_Image.Name = "RB_Sor_Sample_Image";
            this.RB_Sor_Sample_Image.Size = new System.Drawing.Size(78, 20);
            this.RB_Sor_Sample_Image.TabIndex = 1;
            this.RB_Sor_Sample_Image.Text = "Sample";
            this.RB_Sor_Sample_Image.UseVisualStyleBackColor = true;
            this.RB_Sor_Sample_Image.CheckedChanged += new System.EventHandler(this.RB_Sor_Sample_Image_CheckedChanged);
            // 
            // RB_Sor_Base_Image
            // 
            this.RB_Sor_Base_Image.AutoSize = true;
            this.RB_Sor_Base_Image.Checked = true;
            this.RB_Sor_Base_Image.Location = new System.Drawing.Point(17, 26);
            this.RB_Sor_Base_Image.Name = "RB_Sor_Base_Image";
            this.RB_Sor_Base_Image.Size = new System.Drawing.Size(60, 20);
            this.RB_Sor_Base_Image.TabIndex = 0;
            this.RB_Sor_Base_Image.TabStop = true;
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
            this.B_Apply.Click += new System.EventHandler(this.button6_Click);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 653);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_Save_Base_Image);
            this.tabPage1.Controls.Add(this.B_Select_Base_File);
            this.tabPage1.Controls.Add(this.E_Base_Image_File_Name);
            this.tabPage1.Controls.Add(this.B_Select_Sample_File);
            this.tabPage1.Controls.Add(this.E_Sample_Image_File_Name);
            this.tabPage1.Controls.Add(this.B_Base_Image);
            this.tabPage1.Controls.Add(this.B_Sample_Image);
            this.tabPage1.Controls.Add(this.B_Next);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(429, 625);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "空白";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // B_Save_Base_Image
            // 
            this.B_Save_Base_Image.BackColor = System.Drawing.SystemColors.Control;
            this.B_Save_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save_Base_Image.Location = new System.Drawing.Point(172, 152);
            this.B_Save_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save_Base_Image.Name = "B_Save_Base_Image";
            this.B_Save_Base_Image.Size = new System.Drawing.Size(82, 44);
            this.B_Save_Base_Image.TabIndex = 27;
            this.B_Save_Base_Image.Text = "Save";
            this.B_Save_Base_Image.UseVisualStyleBackColor = false;
            this.B_Save_Base_Image.Click += new System.EventHandler(this.B_Save_Base_Image_Click);
            // 
            // B_Select_Base_File
            // 
            this.B_Select_Base_File.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_File.Location = new System.Drawing.Point(212, 111);
            this.B_Select_Base_File.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Base_File.Name = "B_Select_Base_File";
            this.B_Select_Base_File.Size = new System.Drawing.Size(42, 23);
            this.B_Select_Base_File.TabIndex = 26;
            this.B_Select_Base_File.Text = "...";
            this.B_Select_Base_File.UseVisualStyleBackColor = true;
            this.B_Select_Base_File.Click += new System.EventHandler(this.B_Select_Base_File_Click);
            // 
            // E_Base_Image_File_Name
            // 
            this.E_Base_Image_File_Name.Enabled = false;
            this.E_Base_Image_File_Name.Location = new System.Drawing.Point(7, 110);
            this.E_Base_Image_File_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_Base_Image_File_Name.Name = "E_Base_Image_File_Name";
            this.E_Base_Image_File_Name.Size = new System.Drawing.Size(201, 24);
            this.E_Base_Image_File_Name.TabIndex = 25;
            // 
            // B_Select_Sample_File
            // 
            this.B_Select_Sample_File.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Sample_File.Location = new System.Drawing.Point(212, 201);
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
            this.E_Sample_Image_File_Name.Location = new System.Drawing.Point(7, 200);
            this.E_Sample_Image_File_Name.Margin = new System.Windows.Forms.Padding(2);
            this.E_Sample_Image_File_Name.Name = "E_Sample_Image_File_Name";
            this.E_Sample_Image_File_Name.Size = new System.Drawing.Size(201, 24);
            this.E_Sample_Image_File_Name.TabIndex = 23;
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.BackColor = System.Drawing.Color.PaleTurquoise;
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(7, 62);
            this.B_Base_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(161, 44);
            this.B_Base_Image.TabIndex = 20;
            this.B_Base_Image.Text = "Base影像";
            this.B_Base_Image.UseVisualStyleBackColor = false;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // B_Sample_Image
            // 
            this.B_Sample_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image.Location = new System.Drawing.Point(7, 152);
            this.B_Sample_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Sample_Image.Name = "B_Sample_Image";
            this.B_Sample_Image.Size = new System.Drawing.Size(161, 44);
            this.B_Sample_Image.TabIndex = 19;
            this.B_Sample_Image.Text = "Sample影像";
            this.B_Sample_Image.UseVisualStyleBackColor = true;
            this.B_Sample_Image.Click += new System.EventHandler(this.B_Sample_Image_Click);
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(218, 5);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(108, 39);
            this.B_Next.TabIndex = 18;
            this.B_Next.Text = "下一步 =>";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tFrame_Create_Param1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(429, 625);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step1";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // tFrame_Create_Param1
            // 
            this.tFrame_Create_Param1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Create_Param1.Location = new System.Drawing.Point(7, 50);
            this.tFrame_Create_Param1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tFrame_Create_Param1.Name = "tFrame_Create_Param1";
            this.tFrame_Create_Param1.Size = new System.Drawing.Size(398, 482);
            this.tFrame_Create_Param1.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(218, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 39);
            this.button2.TabIndex = 20;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tFrame_Select_Model1);
            this.tabPage3.Controls.Add(this.B_Select_Center);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.CB_Auto_Select_Region);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.B_Select_Rect);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(429, 625);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step2";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // tFrame_Select_Model1
            // 
            this.tFrame_Select_Model1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model1.Location = new System.Drawing.Point(11, 49);
            this.tFrame_Select_Model1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tFrame_Select_Model1.Name = "tFrame_Select_Model1";
            this.tFrame_Select_Model1.Size = new System.Drawing.Size(315, 368);
            this.tFrame_Select_Model1.TabIndex = 26;
            // 
            // B_Select_Center
            // 
            this.B_Select_Center.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Center.Location = new System.Drawing.Point(25, 487);
            this.B_Select_Center.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Center.Name = "B_Select_Center";
            this.B_Select_Center.Size = new System.Drawing.Size(117, 44);
            this.B_Select_Center.TabIndex = 25;
            this.B_Select_Center.Text = "設定中心";
            this.B_Select_Center.UseVisualStyleBackColor = true;
            this.B_Select_Center.Click += new System.EventHandler(this.B_Select_Center_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.groupBox2.Controls.Add(this.E_Ofs_Y);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.E_Ofs_X);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(155, 448);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(162, 87);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "參數";
            // 
            // E_Ofs_Y
            // 
            this.E_Ofs_Y.Location = new System.Drawing.Point(75, 53);
            this.E_Ofs_Y.Margin = new System.Windows.Forms.Padding(2);
            this.E_Ofs_Y.Name = "E_Ofs_Y";
            this.E_Ofs_Y.Size = new System.Drawing.Size(75, 24);
            this.E_Ofs_Y.TabIndex = 7;
            this.E_Ofs_Y.Text = "1234.567";
            this.E_Ofs_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ofs Y";
            // 
            // E_Ofs_X
            // 
            this.E_Ofs_X.Location = new System.Drawing.Point(75, 24);
            this.E_Ofs_X.Margin = new System.Windows.Forms.Padding(2);
            this.E_Ofs_X.Name = "E_Ofs_X";
            this.E_Ofs_X.Size = new System.Drawing.Size(75, 24);
            this.E_Ofs_X.TabIndex = 5;
            this.E_Ofs_X.Text = "1234.567";
            this.E_Ofs_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ofs X";
            // 
            // CB_Auto_Select_Region
            // 
            this.CB_Auto_Select_Region.AutoSize = true;
            this.CB_Auto_Select_Region.Location = new System.Drawing.Point(155, 425);
            this.CB_Auto_Select_Region.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Auto_Select_Region.Name = "CB_Auto_Select_Region";
            this.CB_Auto_Select_Region.Size = new System.Drawing.Size(152, 18);
            this.CB_Auto_Select_Region.TabIndex = 22;
            this.CB_Auto_Select_Region.Text = "Auto Select Region";
            this.CB_Auto_Select_Region.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(218, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 39);
            this.button3.TabIndex = 21;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Select_Rect
            // 
            this.B_Select_Rect.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Rect.Location = new System.Drawing.Point(25, 425);
            this.B_Select_Rect.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select_Rect.Name = "B_Select_Rect";
            this.B_Select_Rect.Size = new System.Drawing.Size(117, 44);
            this.B_Select_Rect.TabIndex = 4;
            this.B_Select_Rect.Text = "選取區域";
            this.B_Select_Rect.UseVisualStyleBackColor = true;
            this.B_Select_Rect.Click += new System.EventHandler(this.B_Select_Rect_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button6);
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.B_Rect_Max);
            this.tabPage5.Controls.Add(this.B_Rect_Edit);
            this.tabPage5.Controls.Add(this.B_Rect_Select);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(429, 625);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Step3";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Enter += new System.EventHandler(this.tabPage5_Enter);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Orange;
            this.button6.Location = new System.Drawing.Point(218, 5);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 39);
            this.button6.TabIndex = 21;
            this.button6.Text = "下一步 =>";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.groupBox1.Controls.Add(this.E_Rect_Col2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.E_Rect_Row2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_Rect_Col1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Rect_Row1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(22, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(247, 150);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選取範圍";
            // 
            // E_Rect_Col2
            // 
            this.E_Rect_Col2.Location = new System.Drawing.Point(111, 112);
            this.E_Rect_Col2.Margin = new System.Windows.Forms.Padding(2);
            this.E_Rect_Col2.Name = "E_Rect_Col2";
            this.E_Rect_Col2.Size = new System.Drawing.Size(88, 24);
            this.E_Rect_Col2.TabIndex = 7;
            this.E_Rect_Col2.Text = "1234.5";
            this.E_Rect_Col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 115);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Col2";
            // 
            // E_Rect_Row2
            // 
            this.E_Rect_Row2.Location = new System.Drawing.Point(111, 82);
            this.E_Rect_Row2.Margin = new System.Windows.Forms.Padding(2);
            this.E_Rect_Row2.Name = "E_Rect_Row2";
            this.E_Rect_Row2.Size = new System.Drawing.Size(88, 24);
            this.E_Rect_Row2.TabIndex = 5;
            this.E_Rect_Row2.Text = "1234.5";
            this.E_Rect_Row2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Row2";
            // 
            // E_Rect_Col1
            // 
            this.E_Rect_Col1.Location = new System.Drawing.Point(111, 53);
            this.E_Rect_Col1.Margin = new System.Windows.Forms.Padding(2);
            this.E_Rect_Col1.Name = "E_Rect_Col1";
            this.E_Rect_Col1.Size = new System.Drawing.Size(88, 24);
            this.E_Rect_Col1.TabIndex = 3;
            this.E_Rect_Col1.Text = "1234.5";
            this.E_Rect_Col1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Col1";
            // 
            // E_Rect_Row1
            // 
            this.E_Rect_Row1.Location = new System.Drawing.Point(111, 24);
            this.E_Rect_Row1.Margin = new System.Windows.Forms.Padding(2);
            this.E_Rect_Row1.Name = "E_Rect_Row1";
            this.E_Rect_Row1.Size = new System.Drawing.Size(88, 24);
            this.E_Rect_Row1.TabIndex = 1;
            this.E_Rect_Row1.Text = "1234.5";
            this.E_Rect_Row1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Row1";
            // 
            // B_Rect_Max
            // 
            this.B_Rect_Max.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Max.Location = new System.Drawing.Point(22, 343);
            this.B_Rect_Max.Margin = new System.Windows.Forms.Padding(2);
            this.B_Rect_Max.Name = "B_Rect_Max";
            this.B_Rect_Max.Size = new System.Drawing.Size(117, 44);
            this.B_Rect_Max.TabIndex = 5;
            this.B_Rect_Max.Text = "最大範圍";
            this.B_Rect_Max.UseVisualStyleBackColor = true;
            this.B_Rect_Max.Click += new System.EventHandler(this.B_Rect_Max_Click);
            // 
            // B_Rect_Edit
            // 
            this.B_Rect_Edit.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Edit.Location = new System.Drawing.Point(22, 286);
            this.B_Rect_Edit.Margin = new System.Windows.Forms.Padding(2);
            this.B_Rect_Edit.Name = "B_Rect_Edit";
            this.B_Rect_Edit.Size = new System.Drawing.Size(117, 44);
            this.B_Rect_Edit.TabIndex = 4;
            this.B_Rect_Edit.Text = "編輯範圍";
            this.B_Rect_Edit.UseVisualStyleBackColor = true;
            this.B_Rect_Edit.Click += new System.EventHandler(this.B_Rect_Edit_Click);
            // 
            // B_Rect_Select
            // 
            this.B_Rect_Select.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Select.Location = new System.Drawing.Point(22, 223);
            this.B_Rect_Select.Margin = new System.Windows.Forms.Padding(2);
            this.B_Rect_Select.Name = "B_Rect_Select";
            this.B_Rect_Select.Size = new System.Drawing.Size(117, 44);
            this.B_Rect_Select.TabIndex = 3;
            this.B_Rect_Select.Text = "選取範圍";
            this.B_Rect_Select.UseVisualStyleBackColor = true;
            this.B_Rect_Select.Click += new System.EventHandler(this.B_Rect_Select_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tFrame_Find_Param1);
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(429, 625);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step4";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Enter += new System.EventHandler(this.tabPage4_Enter);
            // 
            // tFrame_Find_Param1
            // 
            this.tFrame_Find_Param1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Find_Param1.Location = new System.Drawing.Point(5, 50);
            this.tFrame_Find_Param1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.tFrame_Find_Param1.Name = "tFrame_Find_Param1";
            this.tFrame_Find_Param1.Size = new System.Drawing.Size(392, 444);
            this.tFrame_Find_Param1.TabIndex = 22;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orange;
            this.button5.Location = new System.Drawing.Point(218, 5);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 39);
            this.button5.TabIndex = 21;
            this.button5.Text = "下一步 =>";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button7);
            this.tabPage6.Controls.Add(this.button11);
            this.tabPage6.Location = new System.Drawing.Point(4, 24);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(429, 625);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Step5";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.Enter += new System.EventHandler(this.tabPage6_Enter);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Lime;
            this.button7.Location = new System.Drawing.Point(218, 5);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(108, 39);
            this.button7.TabIndex = 19;
            this.button7.Text = "完成";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(40, 59);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(117, 44);
            this.button11.TabIndex = 5;
            this.button11.Text = "測試標靶";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
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
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(602, 653);
            this.tFrame_JJS_HW1.TabIndex = 4;
            // 
            // TForm_Find_Mothed_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 717);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Find_Mothed_1";
            this.Text = "Form_Find_Mothed_1";
            this.Shown += new System.EventHandler(this.Form_Find_Mothed_1_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Rect_Col2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox E_Rect_Row2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Rect_Col1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Rect_Row1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Rect_Max;
        private System.Windows.Forms.Button B_Rect_Edit;
        private System.Windows.Forms.Button B_Rect_Select;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button B_Select_Rect;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox E_Ofs_Y;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox E_Ofs_X;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox CB_Auto_Select_Region;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Button B_Select_Center;
        private TFrame_Create_Param tFrame_Create_Param1;
        private TFrame_Find_Param tFrame_Find_Param1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button B_Sample_Image;
        private System.Windows.Forms.Button B_Base_Image;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RB_Sor_Sample_Image;
        private System.Windows.Forms.RadioButton RB_Sor_Base_Image;
        private System.Windows.Forms.Button B_Select_Sample_File;
        private System.Windows.Forms.TextBox E_Sample_Image_File_Name;
        private System.Windows.Forms.Button B_Select_Base_File;
        private System.Windows.Forms.TextBox E_Base_Image_File_Name;
        private System.Windows.Forms.Button B_Save_Base_Image;
        private TFrame_Select_Model tFrame_Select_Model1;
    }
}