namespace EFC.Vision.Halcon
{
    partial class TForm_Align_Mothed2
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
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19});
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Step0 = new System.Windows.Forms.TabPage();
            this.B_Set_Default = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.TP_Step1 = new System.Windows.Forms.TabPage();
            this.B_Next2 = new System.Windows.Forms.Button();
            this.B_Base_Image = new System.Windows.Forms.Button();
            this.E_Base_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Trans_Image = new System.Windows.Forms.Button();
            this.B_Trans_Image = new System.Windows.Forms.Button();
            this.E_Trans_Image_File = new System.Windows.Forms.TextBox();
            this.B_Select_Base_Image = new System.Windows.Forms.Button();
            this.TP_Step2 = new System.Windows.Forms.TabPage();
            this.tFrame_Select_Model1 = new EFC.Vision.Halcon.TFrame_Select_Model();
            this.button2 = new System.Windows.Forms.Button();
            this.B_Edit_Param = new System.Windows.Forms.Button();
            this.TP_Step3 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.B_Base_Image_Find = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.E_Base_Center_Col = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Base_Center_Row = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.E_Find_Region_Row = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.E_Find_Region_Col = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Base_Find_Row = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.E_Base_Find_Col = new System.Windows.Forms.TextBox();
            this.TP_Step4 = new System.Windows.Forms.TabPage();
            this.B_Sample_Image_Find = new System.Windows.Forms.Button();
            this.TP_Step5 = new System.Windows.Forms.TabPage();
            this.B_Result_Image = new System.Windows.Forms.Button();
            this.B_Sample_Image2 = new System.Windows.Forms.Button();
            this.B_Base_Image2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Step0.SuspendLayout();
            this.TP_Step1.SuspendLayout();
            this.TP_Step2.SuspendLayout();
            this.TP_Step3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 64);
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
            this.B_Open.Size = new System.Drawing.Size(97, 64);
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
            this.B_Save.Size = new System.Drawing.Size(97, 64);
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
            this.B_Cancel.Size = new System.Drawing.Size(97, 64);
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
            this.B_Apply.Size = new System.Drawing.Size(97, 64);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 849);
            this.panel2.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.treeView1.Name = "treeView1";
            treeNode16.Name = "Node1";
            treeNode16.Text = "Node1";
            treeNode17.Name = "Node2";
            treeNode17.Text = "Node2";
            treeNode18.Name = "Node3";
            treeNode18.Text = "Node3";
            treeNode19.Name = "Node4";
            treeNode19.Text = "Node4";
            treeNode20.Name = "Node0";
            treeNode20.Text = "Node0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20});
            this.treeView1.Size = new System.Drawing.Size(212, 849);
            this.treeView1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(212, 64);
            this.panel3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 849);
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
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 849);
            this.tabControl1.TabIndex = 0;
            // 
            // TP_Step0
            // 
            this.TP_Step0.Controls.Add(this.B_Set_Default);
            this.TP_Step0.Controls.Add(this.B_Next);
            this.TP_Step0.Location = new System.Drawing.Point(4, 24);
            this.TP_Step0.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step0.Name = "TP_Step0";
            this.TP_Step0.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step0.Size = new System.Drawing.Size(368, 821);
            this.TP_Step0.TabIndex = 0;
            this.TP_Step0.Text = "空白";
            this.TP_Step0.UseVisualStyleBackColor = true;
            this.TP_Step0.Enter += new System.EventHandler(this.TP_Step0_Enter);
            // 
            // B_Set_Default
            // 
            this.B_Set_Default.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Set_Default.Location = new System.Drawing.Point(49, 102);
            this.B_Set_Default.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Set_Default.Name = "B_Set_Default";
            this.B_Set_Default.Size = new System.Drawing.Size(140, 53);
            this.B_Set_Default.TabIndex = 18;
            this.B_Set_Default.Text = "Set Default";
            this.B_Set_Default.UseVisualStyleBackColor = true;
            this.B_Set_Default.Click += new System.EventHandler(this.B_Set_Default_Click);
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(187, 5);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(93, 39);
            this.B_Next.TabIndex = 17;
            this.B_Next.Text = "下一步 =>";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
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
            this.TP_Step1.Name = "TP_Step1";
            this.TP_Step1.Size = new System.Drawing.Size(368, 821);
            this.TP_Step1.TabIndex = 5;
            this.TP_Step1.Text = "Step1";
            this.TP_Step1.UseVisualStyleBackColor = true;
            this.TP_Step1.Enter += new System.EventHandler(this.TP_Step1_Enter);
            // 
            // B_Next2
            // 
            this.B_Next2.BackColor = System.Drawing.Color.Orange;
            this.B_Next2.Location = new System.Drawing.Point(254, 14);
            this.B_Next2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next2.Name = "B_Next2";
            this.B_Next2.Size = new System.Drawing.Size(93, 39);
            this.B_Next2.TabIndex = 18;
            this.B_Next2.Text = "下一步 =>";
            this.B_Next2.UseVisualStyleBackColor = false;
            this.B_Next2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Base_Image
            // 
            this.B_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image.Location = new System.Drawing.Point(16, 41);
            this.B_Base_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Base_Image.Name = "B_Base_Image";
            this.B_Base_Image.Size = new System.Drawing.Size(140, 53);
            this.B_Base_Image.TabIndex = 7;
            this.B_Base_Image.Text = "Base Image";
            this.B_Base_Image.UseVisualStyleBackColor = true;
            this.B_Base_Image.Click += new System.EventHandler(this.B_Base_Image_Click);
            // 
            // E_Base_Image_File
            // 
            this.E_Base_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Image_File.Location = new System.Drawing.Point(16, 99);
            this.E_Base_Image_File.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Base_Image_File.Name = "E_Base_Image_File";
            this.E_Base_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Base_Image_File.TabIndex = 9;
            // 
            // B_Select_Trans_Image
            // 
            this.B_Select_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Trans_Image.Location = new System.Drawing.Point(234, 214);
            this.B_Select_Trans_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Trans_Image.Name = "B_Select_Trans_Image";
            this.B_Select_Trans_Image.Size = new System.Drawing.Size(41, 27);
            this.B_Select_Trans_Image.TabIndex = 12;
            this.B_Select_Trans_Image.Text = "...";
            this.B_Select_Trans_Image.UseVisualStyleBackColor = true;
            // 
            // B_Trans_Image
            // 
            this.B_Trans_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Trans_Image.Location = new System.Drawing.Point(16, 156);
            this.B_Trans_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Trans_Image.Name = "B_Trans_Image";
            this.B_Trans_Image.Size = new System.Drawing.Size(140, 53);
            this.B_Trans_Image.TabIndex = 8;
            this.B_Trans_Image.Text = "Trans Image";
            this.B_Trans_Image.UseVisualStyleBackColor = true;
            this.B_Trans_Image.Click += new System.EventHandler(this.B_Trans_Image_Click);
            // 
            // E_Trans_Image_File
            // 
            this.E_Trans_Image_File.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Trans_Image_File.Location = new System.Drawing.Point(16, 214);
            this.E_Trans_Image_File.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Trans_Image_File.Name = "E_Trans_Image_File";
            this.E_Trans_Image_File.Size = new System.Drawing.Size(208, 27);
            this.E_Trans_Image_File.TabIndex = 11;
            // 
            // B_Select_Base_Image
            // 
            this.B_Select_Base_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Base_Image.Location = new System.Drawing.Point(234, 99);
            this.B_Select_Base_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Select_Base_Image.Name = "B_Select_Base_Image";
            this.B_Select_Base_Image.Size = new System.Drawing.Size(41, 27);
            this.B_Select_Base_Image.TabIndex = 10;
            this.B_Select_Base_Image.Text = "...";
            this.B_Select_Base_Image.UseVisualStyleBackColor = true;
            // 
            // TP_Step2
            // 
            this.TP_Step2.Controls.Add(this.tFrame_Select_Model1);
            this.TP_Step2.Controls.Add(this.button2);
            this.TP_Step2.Controls.Add(this.B_Edit_Param);
            this.TP_Step2.Location = new System.Drawing.Point(4, 24);
            this.TP_Step2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step2.Name = "TP_Step2";
            this.TP_Step2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step2.Size = new System.Drawing.Size(368, 821);
            this.TP_Step2.TabIndex = 1;
            this.TP_Step2.Text = "Step2";
            this.TP_Step2.UseVisualStyleBackColor = true;
            this.TP_Step2.Enter += new System.EventHandler(this.TP_Step2_Enter);
            // 
            // tFrame_Select_Model1
            // 
            this.tFrame_Select_Model1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model1.Location = new System.Drawing.Point(20, 78);
            this.tFrame_Select_Model1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tFrame_Select_Model1.Name = "tFrame_Select_Model1";
            this.tFrame_Select_Model1.Size = new System.Drawing.Size(315, 368);
            this.tFrame_Select_Model1.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(187, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 39);
            this.button2.TabIndex = 17;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Edit_Param
            // 
            this.B_Edit_Param.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Edit_Param.Location = new System.Drawing.Point(20, 16);
            this.B_Edit_Param.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Edit_Param.Name = "B_Edit_Param";
            this.B_Edit_Param.Size = new System.Drawing.Size(100, 44);
            this.B_Edit_Param.TabIndex = 24;
            this.B_Edit_Param.Text = "編輯參數";
            this.B_Edit_Param.UseVisualStyleBackColor = true;
            this.B_Edit_Param.Click += new System.EventHandler(this.B_Edit_Param_Click);
            // 
            // TP_Step3
            // 
            this.TP_Step3.Controls.Add(this.button1);
            this.TP_Step3.Controls.Add(this.B_Base_Image_Find);
            this.TP_Step3.Controls.Add(this.groupBox3);
            this.TP_Step3.Controls.Add(this.groupBox2);
            this.TP_Step3.Controls.Add(this.groupBox1);
            this.TP_Step3.Location = new System.Drawing.Point(4, 24);
            this.TP_Step3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TP_Step3.Name = "TP_Step3";
            this.TP_Step3.Size = new System.Drawing.Size(368, 821);
            this.TP_Step3.TabIndex = 4;
            this.TP_Step3.Text = "Step3";
            this.TP_Step3.UseVisualStyleBackColor = true;
            this.TP_Step3.Enter += new System.EventHandler(this.TP_Step3_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Location = new System.Drawing.Point(227, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 39);
            this.button1.TabIndex = 57;
            this.button1.Text = "下一步 =>";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Base_Image_Find
            // 
            this.B_Base_Image_Find.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image_Find.Location = new System.Drawing.Point(21, 68);
            this.B_Base_Image_Find.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Base_Image_Find.Name = "B_Base_Image_Find";
            this.B_Base_Image_Find.Size = new System.Drawing.Size(178, 75);
            this.B_Base_Image_Find.TabIndex = 56;
            this.B_Base_Image_Find.Text = "Base Image Find";
            this.B_Base_Image_Find.UseVisualStyleBackColor = true;
            this.B_Base_Image_Find.Click += new System.EventHandler(this.B_Base_Image_Find_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.E_Base_Center_Col);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.E_Base_Center_Row);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(21, 396);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(261, 83);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ Base Info ]";
            // 
            // E_Base_Center_Col
            // 
            this.E_Base_Center_Col.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Center_Col.Location = new System.Drawing.Point(161, 23);
            this.E_Base_Center_Col.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Base_Center_Col.Name = "E_Base_Center_Col";
            this.E_Base_Center_Col.Size = new System.Drawing.Size(68, 23);
            this.E_Base_Center_Col.TabIndex = 45;
            this.E_Base_Center_Col.Text = "123.4567";
            this.E_Base_Center_Col.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 14);
            this.label2.TabIndex = 46;
            this.label2.Text = "Base Col";
            // 
            // E_Base_Center_Row
            // 
            this.E_Base_Center_Row.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Center_Row.Location = new System.Drawing.Point(161, 52);
            this.E_Base_Center_Row.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Base_Center_Row.Name = "E_Base_Center_Row";
            this.E_Base_Center_Row.Size = new System.Drawing.Size(68, 23);
            this.E_Base_Center_Row.TabIndex = 47;
            this.E_Base_Center_Row.Text = "123.4567";
            this.E_Base_Center_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 48;
            this.label1.Text = "Base Row";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.E_Find_Region_Row);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.E_Find_Region_Col);
            this.groupBox2.Location = new System.Drawing.Point(21, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 85);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[ Find Region ]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 14);
            this.label9.TabIndex = 48;
            this.label9.Text = "Region  Row";
            // 
            // E_Find_Region_Row
            // 
            this.E_Find_Region_Row.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Find_Region_Row.Location = new System.Drawing.Point(161, 52);
            this.E_Find_Region_Row.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Find_Region_Row.Name = "E_Find_Region_Row";
            this.E_Find_Region_Row.Size = new System.Drawing.Size(68, 23);
            this.E_Find_Region_Row.TabIndex = 47;
            this.E_Find_Region_Row.Text = "123.4567";
            this.E_Find_Region_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 14);
            this.label10.TabIndex = 46;
            this.label10.Text = "Region Col";
            // 
            // E_Find_Region_Col
            // 
            this.E_Find_Region_Col.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Find_Region_Col.Location = new System.Drawing.Point(161, 23);
            this.E_Find_Region_Col.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Find_Region_Col.Name = "E_Find_Region_Col";
            this.E_Find_Region_Col.Size = new System.Drawing.Size(68, 23);
            this.E_Find_Region_Col.TabIndex = 45;
            this.E_Find_Region_Col.Text = "123.4567";
            this.E_Find_Region_Col.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_Base_Find_Row);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.E_Base_Find_Col);
            this.groupBox1.Location = new System.Drawing.Point(21, 485);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 85);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ Find Info ]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 14);
            this.label3.TabIndex = 52;
            this.label3.Text = "Base Find Row";
            // 
            // E_Base_Find_Row
            // 
            this.E_Base_Find_Row.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Find_Row.Location = new System.Drawing.Point(161, 52);
            this.E_Base_Find_Row.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Base_Find_Row.Name = "E_Base_Find_Row";
            this.E_Base_Find_Row.Size = new System.Drawing.Size(68, 23);
            this.E_Base_Find_Row.TabIndex = 51;
            this.E_Base_Find_Row.Text = "123.4567";
            this.E_Base_Find_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 14);
            this.label4.TabIndex = 50;
            this.label4.Text = "Base Find Col";
            // 
            // E_Base_Find_Col
            // 
            this.E_Base_Find_Col.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Base_Find_Col.Location = new System.Drawing.Point(161, 23);
            this.E_Base_Find_Col.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Base_Find_Col.Name = "E_Base_Find_Col";
            this.E_Base_Find_Col.Size = new System.Drawing.Size(68, 23);
            this.E_Base_Find_Col.TabIndex = 49;
            this.E_Base_Find_Col.Text = "123.4567";
            this.E_Base_Find_Col.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TP_Step4
            // 
            this.TP_Step4.Controls.Add(this.button3);
            this.TP_Step4.Controls.Add(this.B_Sample_Image_Find);
            this.TP_Step4.Location = new System.Drawing.Point(4, 24);
            this.TP_Step4.Name = "TP_Step4";
            this.TP_Step4.Size = new System.Drawing.Size(368, 821);
            this.TP_Step4.TabIndex = 6;
            this.TP_Step4.Text = "Step4";
            this.TP_Step4.UseVisualStyleBackColor = true;
            this.TP_Step4.Enter += new System.EventHandler(this.TP_Step4_Enter);
            // 
            // B_Sample_Image_Find
            // 
            this.B_Sample_Image_Find.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image_Find.Location = new System.Drawing.Point(25, 44);
            this.B_Sample_Image_Find.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Sample_Image_Find.Name = "B_Sample_Image_Find";
            this.B_Sample_Image_Find.Size = new System.Drawing.Size(178, 75);
            this.B_Sample_Image_Find.TabIndex = 24;
            this.B_Sample_Image_Find.Text = "Sample Image Find";
            this.B_Sample_Image_Find.UseVisualStyleBackColor = true;
            this.B_Sample_Image_Find.Click += new System.EventHandler(this.B_Sample_Image_Find_Click);
            // 
            // TP_Step5
            // 
            this.TP_Step5.Controls.Add(this.B_Result_Image);
            this.TP_Step5.Controls.Add(this.B_Sample_Image2);
            this.TP_Step5.Controls.Add(this.B_Base_Image2);
            this.TP_Step5.Controls.Add(this.button5);
            this.TP_Step5.Location = new System.Drawing.Point(4, 24);
            this.TP_Step5.Name = "TP_Step5";
            this.TP_Step5.Size = new System.Drawing.Size(368, 821);
            this.TP_Step5.TabIndex = 7;
            this.TP_Step5.Text = "Step5";
            this.TP_Step5.UseVisualStyleBackColor = true;
            this.TP_Step5.Enter += new System.EventHandler(this.TP_Step5_Enter);
            // 
            // B_Result_Image
            // 
            this.B_Result_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Result_Image.Location = new System.Drawing.Point(32, 181);
            this.B_Result_Image.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Result_Image.Name = "B_Result_Image";
            this.B_Result_Image.Size = new System.Drawing.Size(140, 53);
            this.B_Result_Image.TabIndex = 28;
            this.B_Result_Image.Text = "Result Image";
            this.B_Result_Image.UseVisualStyleBackColor = true;
            this.B_Result_Image.Click += new System.EventHandler(this.B_Result_Image_Click);
            // 
            // B_Sample_Image2
            // 
            this.B_Sample_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Sample_Image2.Location = new System.Drawing.Point(32, 103);
            this.B_Sample_Image2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Sample_Image2.Name = "B_Sample_Image2";
            this.B_Sample_Image2.Size = new System.Drawing.Size(140, 53);
            this.B_Sample_Image2.TabIndex = 27;
            this.B_Sample_Image2.Text = "Trans Image";
            this.B_Sample_Image2.UseVisualStyleBackColor = true;
            this.B_Sample_Image2.Click += new System.EventHandler(this.B_Sample_Image2_Click);
            // 
            // B_Base_Image2
            // 
            this.B_Base_Image2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Base_Image2.Location = new System.Drawing.Point(32, 29);
            this.B_Base_Image2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Base_Image2.Name = "B_Base_Image2";
            this.B_Base_Image2.Size = new System.Drawing.Size(140, 53);
            this.B_Base_Image2.TabIndex = 26;
            this.B_Base_Image2.Text = "Base Image";
            this.B_Base_Image2.UseVisualStyleBackColor = true;
            this.B_Base_Image2.Click += new System.EventHandler(this.B_Base_Image2_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lime;
            this.button5.Location = new System.Drawing.Point(259, 29);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 39);
            this.button5.TabIndex = 18;
            this.button5.Text = "完成";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(588, 64);
            this.tFrame_JJS_HW1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(259, 849);
            this.tFrame_JJS_HW1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(244, 20);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 39);
            this.button3.TabIndex = 58;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // TForm_Align_Mothed2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 913);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "TForm_Align_Mothed2";
            this.Text = "TForm_Align_Mothed2";
            this.Shown += new System.EventHandler(this.TForm_Align_Mothed2_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Step0.ResumeLayout(false);
            this.TP_Step1.ResumeLayout(false);
            this.TP_Step1.PerformLayout();
            this.TP_Step2.ResumeLayout(false);
            this.TP_Step3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Step0;
        private System.Windows.Forms.Button B_Set_Default;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.TabPage TP_Step2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage TP_Step3;
        private System.Windows.Forms.Button button5;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private TFrame_Select_Model tFrame_Select_Model1;
        private System.Windows.Forms.Button B_Edit_Param;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox E_Base_Center_Row;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Base_Center_Col;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Base_Find_Row;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox E_Base_Find_Col;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox E_Find_Region_Row;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox E_Find_Region_Col;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage TP_Step1;
        private System.Windows.Forms.TabPage TP_Step4;
        private System.Windows.Forms.Button B_Base_Image;
        private System.Windows.Forms.TextBox E_Base_Image_File;
        private System.Windows.Forms.Button B_Select_Trans_Image;
        private System.Windows.Forms.Button B_Trans_Image;
        private System.Windows.Forms.TextBox E_Trans_Image_File;
        private System.Windows.Forms.Button B_Select_Base_Image;
        private System.Windows.Forms.Button B_Next2;
        private System.Windows.Forms.Button B_Base_Image_Find;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button B_Sample_Image_Find;
        private System.Windows.Forms.TabPage TP_Step5;
        private System.Windows.Forms.Button B_Result_Image;
        private System.Windows.Forms.Button B_Sample_Image2;
        private System.Windows.Forms.Button B_Base_Image2;
        private System.Windows.Forms.Button button3;
    }
}