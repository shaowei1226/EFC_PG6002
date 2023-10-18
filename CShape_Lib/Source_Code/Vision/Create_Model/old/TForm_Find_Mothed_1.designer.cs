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
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("@.選取舊標靶");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("1.設定建立標靶參數");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("2.選取範圍");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("@.建立新標靶", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Step 1.建立標靶", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Step 2.設定搜尋參數");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Step 3.設定搜尋範圍");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Step 4.測試標靶");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("步驟", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
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
            this.tFrame_Create_Param1 = new EFC.Vision.Halcon.TFrame_Create_Param();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tFrame_Select_Model1 = new EFC.Vision.Halcon.TFrame_Select_Model();
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(891, 59);
            this.panel1.TabIndex = 1;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.Image = global::Find_Model.Properties.Resources.hard_drive_upload;
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.Location = new System.Drawing.Point(291, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(97, 59);
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
            this.B_Save.Image = global::Find_Model.Properties.Resources.hard_drive_download;
            this.B_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save.Location = new System.Drawing.Point(194, 0);
            this.B_Save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(97, 59);
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
            this.B_Cancel.Image = global::Find_Model.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.B_Apply.Image = global::Find_Model.Properties.Resources.magic_wand;
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
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
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 603);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_Next);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(367, 575);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "空白";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(160, 26);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(93, 36);
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
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(367, 575);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step1";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // tFrame_Create_Param1
            // 
            this.tFrame_Create_Param1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Create_Param1.Location = new System.Drawing.Point(13, 46);
            this.tFrame_Create_Param1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tFrame_Create_Param1.Name = "tFrame_Create_Param1";
            this.tFrame_Create_Param1.Size = new System.Drawing.Size(335, 439);
            this.tFrame_Create_Param1.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(187, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 20;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tFrame_Select_Model1);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.CB_Auto_Select_Region);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.B_Select_Rect);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(367, 575);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step2";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // tFrame_Select_Model1
            // 
            this.tFrame_Select_Model1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Select_Model1.Location = new System.Drawing.Point(20, 46);
            this.tFrame_Select_Model1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tFrame_Select_Model1.Name = "tFrame_Select_Model1";
            this.tFrame_Select_Model1.Size = new System.Drawing.Size(319, 294);
            this.tFrame_Select_Model1.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.groupBox2.Controls.Add(this.E_Ofs_Y);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.E_Ofs_X);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(128, 371);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(139, 80);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "參數";
            // 
            // E_Ofs_Y
            // 
            this.E_Ofs_Y.Location = new System.Drawing.Point(64, 49);
            this.E_Ofs_Y.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Ofs_Y.Name = "E_Ofs_Y";
            this.E_Ofs_Y.Size = new System.Drawing.Size(65, 24);
            this.E_Ofs_Y.TabIndex = 7;
            this.E_Ofs_Y.Text = "1234.567";
            this.E_Ofs_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 50);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ofs Y";
            // 
            // E_Ofs_X
            // 
            this.E_Ofs_X.Location = new System.Drawing.Point(64, 22);
            this.E_Ofs_X.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Ofs_X.Name = "E_Ofs_X";
            this.E_Ofs_X.Size = new System.Drawing.Size(65, 24);
            this.E_Ofs_X.TabIndex = 5;
            this.E_Ofs_X.Text = "1234.567";
            this.E_Ofs_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 24);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ofs X";
            // 
            // CB_Auto_Select_Region
            // 
            this.CB_Auto_Select_Region.AutoSize = true;
            this.CB_Auto_Select_Region.Checked = true;
            this.CB_Auto_Select_Region.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Auto_Select_Region.Location = new System.Drawing.Point(128, 350);
            this.CB_Auto_Select_Region.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CB_Auto_Select_Region.Name = "CB_Auto_Select_Region";
            this.CB_Auto_Select_Region.Size = new System.Drawing.Size(152, 18);
            this.CB_Auto_Select_Region.TabIndex = 22;
            this.CB_Auto_Select_Region.Text = "Auto Select Region";
            this.CB_Auto_Select_Region.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(187, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 36);
            this.button3.TabIndex = 21;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Select_Rect
            // 
            this.B_Select_Rect.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select_Rect.Location = new System.Drawing.Point(16, 350);
            this.B_Select_Rect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Select_Rect.Name = "B_Select_Rect";
            this.B_Select_Rect.Size = new System.Drawing.Size(100, 41);
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
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(367, 575);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Step3";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Enter += new System.EventHandler(this.tabPage5_Enter);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Orange;
            this.button6.Location = new System.Drawing.Point(187, 5);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 36);
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
            this.groupBox1.Location = new System.Drawing.Point(19, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(212, 138);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選取範圍";
            // 
            // E_Rect_Col2
            // 
            this.E_Rect_Col2.Location = new System.Drawing.Point(95, 103);
            this.E_Rect_Col2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Rect_Col2.Name = "E_Rect_Col2";
            this.E_Rect_Col2.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Col2.TabIndex = 7;
            this.E_Rect_Col2.Text = "1234.567";
            this.E_Rect_Col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Col2";
            // 
            // E_Rect_Row2
            // 
            this.E_Rect_Row2.Location = new System.Drawing.Point(95, 76);
            this.E_Rect_Row2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Rect_Row2.Name = "E_Rect_Row2";
            this.E_Rect_Row2.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Row2.TabIndex = 5;
            this.E_Rect_Row2.Text = "1234.567";
            this.E_Rect_Row2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Row2";
            // 
            // E_Rect_Col1
            // 
            this.E_Rect_Col1.Location = new System.Drawing.Point(95, 49);
            this.E_Rect_Col1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Rect_Col1.Name = "E_Rect_Col1";
            this.E_Rect_Col1.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Col1.TabIndex = 3;
            this.E_Rect_Col1.Text = "1234.567";
            this.E_Rect_Col1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Col1";
            // 
            // E_Rect_Row1
            // 
            this.E_Rect_Row1.Location = new System.Drawing.Point(95, 22);
            this.E_Rect_Row1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.E_Rect_Row1.Name = "E_Rect_Row1";
            this.E_Rect_Row1.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Row1.TabIndex = 1;
            this.E_Rect_Row1.Text = "1234.567";
            this.E_Rect_Row1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Row1";
            // 
            // B_Rect_Max
            // 
            this.B_Rect_Max.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Max.Location = new System.Drawing.Point(19, 317);
            this.B_Rect_Max.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Rect_Max.Name = "B_Rect_Max";
            this.B_Rect_Max.Size = new System.Drawing.Size(100, 41);
            this.B_Rect_Max.TabIndex = 5;
            this.B_Rect_Max.Text = "最大範圍";
            this.B_Rect_Max.UseVisualStyleBackColor = true;
            this.B_Rect_Max.Click += new System.EventHandler(this.B_Rect_Max_Click);
            // 
            // B_Rect_Edit
            // 
            this.B_Rect_Edit.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Edit.Location = new System.Drawing.Point(19, 264);
            this.B_Rect_Edit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Rect_Edit.Name = "B_Rect_Edit";
            this.B_Rect_Edit.Size = new System.Drawing.Size(100, 41);
            this.B_Rect_Edit.TabIndex = 4;
            this.B_Rect_Edit.Text = "編輯範圍";
            this.B_Rect_Edit.UseVisualStyleBackColor = true;
            this.B_Rect_Edit.Click += new System.EventHandler(this.B_Rect_Edit_Click);
            // 
            // B_Rect_Select
            // 
            this.B_Rect_Select.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Select.Location = new System.Drawing.Point(19, 206);
            this.B_Rect_Select.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.B_Rect_Select.Name = "B_Rect_Select";
            this.B_Rect_Select.Size = new System.Drawing.Size(100, 41);
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
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(367, 575);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step4";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Enter += new System.EventHandler(this.tabPage4_Enter);
            // 
            // tFrame_Find_Param1
            // 
            this.tFrame_Find_Param1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Find_Param1.Location = new System.Drawing.Point(15, 46);
            this.tFrame_Find_Param1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.tFrame_Find_Param1.Name = "tFrame_Find_Param1";
            this.tFrame_Find_Param1.Size = new System.Drawing.Size(320, 410);
            this.tFrame_Find_Param1.TabIndex = 22;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orange;
            this.button5.Location = new System.Drawing.Point(187, 5);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(93, 36);
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
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(367, 575);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Step5";
            this.tabPage6.UseVisualStyleBackColor = true;
            this.tabPage6.Enter += new System.EventHandler(this.tabPage6_Enter);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Lime;
            this.button7.Location = new System.Drawing.Point(187, 5);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(93, 36);
            this.button7.TabIndex = 19;
            this.button7.Text = "完成";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(34, 54);
            this.button11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(100, 41);
            this.button11.TabIndex = 5;
            this.button11.Text = "測試標靶";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeView1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 59);
            this.panel5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            treeNode10.Name = "Node1";
            treeNode10.Text = "@.選取舊標靶";
            treeNode11.Name = "Node2";
            treeNode11.Text = "1.設定建立標靶參數";
            treeNode12.Name = "Node4";
            treeNode12.Text = "2.選取範圍";
            treeNode13.Name = "Node3";
            treeNode13.Text = "@.建立新標靶";
            treeNode14.Name = "Node7";
            treeNode14.Text = "Step 1.建立標靶";
            treeNode15.Name = "Node6";
            treeNode15.Text = "Step 2.設定搜尋參數";
            treeNode16.Name = "Node5";
            treeNode16.Text = "Step 3.設定搜尋範圍";
            treeNode17.Name = "Node8";
            treeNode17.Text = "Step 4.測試標靶";
            treeNode18.Name = "Node0";
            treeNode18.Text = "步驟";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18});
            this.treeView1.Size = new System.Drawing.Size(212, 603);
            this.treeView1.TabIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "標靶檔(*.mod)|*.mod";
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(587, 59);
            this.tFrame_JJS_HW1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(304, 603);
            this.tFrame_JJS_HW1.TabIndex = 4;
            // 
            // TForm_Find_Mothed_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 662);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TForm_Find_Mothed_1";
            this.Text = "Form_Find_Mothed_1";
            this.Shown += new System.EventHandler(this.Form_Find_Mothed_1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel5;
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
        private TFrame_Create_Param tFrame_Create_Param1;
        private TFrame_Select_Model tFrame_Select_Model1;
        private TFrame_Find_Param tFrame_Find_Param1;
        private TFrame_JJS_HW tFrame_JJS_HW1;
    }
}