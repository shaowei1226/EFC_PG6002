namespace EFC.Vision.Halcon
{
    partial class TForm_Find_Edge_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Find_Edge_1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.B_Used_In_Image = new System.Windows.Forms.Button();
            this.B_Used_Sor_Image = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_Rect_Len2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.E_Rect_Len1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.E_Rect_Phi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Rect_Col = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Rect_Row = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Rect_Select = new System.Windows.Forms.Button();
            this.B_Rect_Edit = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.E_Point_Count = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Transition = new System.Windows.Forms.Label();
            this.CB_Select = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_Sigma = new System.Windows.Forms.ComboBox();
            this.CB_Transition = new System.Windows.Forms.ComboBox();
            this.CB_Threshold = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.B_Get_Point = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CB_Disp_Line = new System.Windows.Forms.CheckBox();
            this.CB_Disp_Point = new System.Windows.Forms.CheckBox();
            this.B_Finish = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1008, 64);
            this.panel1.TabIndex = 1;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.Image = global::Find_Edge.Properties.Resources.hard_drive_upload;
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.Location = new System.Drawing.Point(366, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(122, 64);
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
            this.B_Save.Image = global::Find_Edge.Properties.Resources.hard_drive_download;
            this.B_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save.Location = new System.Drawing.Point(244, 0);
            this.B_Save.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.B_Cancel.Image = global::Find_Edge.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(122, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.B_Apply.Image = global::Find_Edge.Properties.Resources.magic_wand;
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.panel6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(375, 599);
            this.panel6.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(375, 599);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.B_Used_In_Image);
            this.tabPage1.Controls.Add(this.B_Used_Sor_Image);
            this.tabPage1.Controls.Add(this.B_Next);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(367, 571);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "空白";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // B_Used_In_Image
            // 
            this.B_Used_In_Image.BackColor = System.Drawing.Color.PaleTurquoise;
            this.B_Used_In_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Used_In_Image.Location = new System.Drawing.Point(21, 82);
            this.B_Used_In_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Used_In_Image.Name = "B_Used_In_Image";
            this.B_Used_In_Image.Size = new System.Drawing.Size(161, 44);
            this.B_Used_In_Image.TabIndex = 22;
            this.B_Used_In_Image.Text = "使用來源影像";
            this.B_Used_In_Image.UseVisualStyleBackColor = false;
            this.B_Used_In_Image.Click += new System.EventHandler(this.B_Used_In_Image_Click);
            // 
            // B_Used_Sor_Image
            // 
            this.B_Used_Sor_Image.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Used_Sor_Image.Location = new System.Drawing.Point(21, 130);
            this.B_Used_Sor_Image.Margin = new System.Windows.Forms.Padding(2);
            this.B_Used_Sor_Image.Name = "B_Used_Sor_Image";
            this.B_Used_Sor_Image.Size = new System.Drawing.Size(161, 44);
            this.B_Used_Sor_Image.TabIndex = 21;
            this.B_Used_Sor_Image.Text = "使用原始影像";
            this.B_Used_Sor_Image.UseVisualStyleBackColor = true;
            this.B_Used_Sor_Image.Click += new System.EventHandler(this.B_Used_Sor_Image_Click);
            // 
            // B_Next
            // 
            this.B_Next.BackColor = System.Drawing.Color.Orange;
            this.B_Next.Location = new System.Drawing.Point(160, 27);
            this.B_Next.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(93, 36);
            this.B_Next.TabIndex = 18;
            this.B_Next.Text = "下一步 =>";
            this.B_Next.UseVisualStyleBackColor = false;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.B_Rect_Select);
            this.tabPage2.Controls.Add(this.B_Rect_Edit);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(367, 571);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step1";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Location = new System.Drawing.Point(187, 5);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 20;
            this.button2.Text = "下一步 =>";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.groupBox1.Controls.Add(this.E_Rect_Len2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.E_Rect_Len1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.E_Rect_Phi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_Rect_Col);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Rect_Row);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(20, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(185, 179);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選取範圍";
            // 
            // E_Rect_Len2
            // 
            this.E_Rect_Len2.Location = new System.Drawing.Point(95, 141);
            this.E_Rect_Len2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Rect_Len2.Name = "E_Rect_Len2";
            this.E_Rect_Len2.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Len2.TabIndex = 9;
            this.E_Rect_Len2.Text = "1234.567";
            this.E_Rect_Len2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 143);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "Len2";
            // 
            // E_Rect_Len1
            // 
            this.E_Rect_Len1.Location = new System.Drawing.Point(95, 111);
            this.E_Rect_Len1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Rect_Len1.Name = "E_Rect_Len1";
            this.E_Rect_Len1.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Len1.TabIndex = 7;
            this.E_Rect_Len1.Text = "1234.567";
            this.E_Rect_Len1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Len1";
            // 
            // E_Rect_Phi
            // 
            this.E_Rect_Phi.Location = new System.Drawing.Point(95, 81);
            this.E_Rect_Phi.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Rect_Phi.Name = "E_Rect_Phi";
            this.E_Rect_Phi.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Phi.TabIndex = 5;
            this.E_Rect_Phi.Text = "1234.567";
            this.E_Rect_Phi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Phi";
            // 
            // E_Rect_Col
            // 
            this.E_Rect_Col.Location = new System.Drawing.Point(95, 51);
            this.E_Rect_Col.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Rect_Col.Name = "E_Rect_Col";
            this.E_Rect_Col.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Col.TabIndex = 3;
            this.E_Rect_Col.Text = "1234.567";
            this.E_Rect_Col.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Col1";
            // 
            // E_Rect_Row
            // 
            this.E_Rect_Row.Location = new System.Drawing.Point(95, 21);
            this.E_Rect_Row.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.E_Rect_Row.Name = "E_Rect_Row";
            this.E_Rect_Row.Size = new System.Drawing.Size(76, 24);
            this.E_Rect_Row.TabIndex = 1;
            this.E_Rect_Row.Text = "1234.567";
            this.E_Rect_Row.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // B_Rect_Select
            // 
            this.B_Rect_Select.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Select.Location = new System.Drawing.Point(20, 241);
            this.B_Rect_Select.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Rect_Select.Name = "B_Rect_Select";
            this.B_Rect_Select.Size = new System.Drawing.Size(100, 41);
            this.B_Rect_Select.TabIndex = 3;
            this.B_Rect_Select.Text = "選取範圍";
            this.B_Rect_Select.UseVisualStyleBackColor = true;
            this.B_Rect_Select.Click += new System.EventHandler(this.B_Rect_Select_Click);
            // 
            // B_Rect_Edit
            // 
            this.B_Rect_Edit.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Rect_Edit.Location = new System.Drawing.Point(20, 298);
            this.B_Rect_Edit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Rect_Edit.Name = "B_Rect_Edit";
            this.B_Rect_Edit.Size = new System.Drawing.Size(100, 41);
            this.B_Rect_Edit.TabIndex = 4;
            this.B_Rect_Edit.Text = "編輯範圍";
            this.B_Rect_Edit.UseVisualStyleBackColor = true;
            this.B_Rect_Edit.Click += new System.EventHandler(this.B_Rect_Edit_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.B_Get_Point);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(367, 571);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step2";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Enter += new System.EventHandler(this.tabPage3_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.E_Point_Count);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Transition);
            this.groupBox2.Controls.Add(this.CB_Select);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.CB_Sigma);
            this.groupBox2.Controls.Add(this.CB_Transition);
            this.groupBox2.Controls.Add(this.CB_Threshold);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(20, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(185, 176);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 14);
            this.label9.TabIndex = 32;
            this.label9.Text = "Count";
            // 
            // E_Point_Count
            // 
            this.E_Point_Count.Location = new System.Drawing.Point(94, 135);
            this.E_Point_Count.Name = "E_Point_Count";
            this.E_Point_Count.Size = new System.Drawing.Size(75, 24);
            this.E_Point_Count.TabIndex = 31;
            this.E_Point_Count.Text = "20";
            this.E_Point_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 14);
            this.label8.TabIndex = 30;
            this.label8.Text = "Select";
            // 
            // Transition
            // 
            this.Transition.AutoSize = true;
            this.Transition.Location = new System.Drawing.Point(14, 82);
            this.Transition.Name = "Transition";
            this.Transition.Size = new System.Drawing.Size(73, 14);
            this.Transition.TabIndex = 29;
            this.Transition.Text = "Transition";
            // 
            // CB_Select
            // 
            this.CB_Select.FormattingEnabled = true;
            this.CB_Select.Items.AddRange(new object[] {
            "first",
            "last",
            "all"});
            this.CB_Select.Location = new System.Drawing.Point(94, 107);
            this.CB_Select.Name = "CB_Select";
            this.CB_Select.Size = new System.Drawing.Size(75, 22);
            this.CB_Select.TabIndex = 24;
            this.CB_Select.Text = "first";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "Threshold";
            // 
            // CB_Sigma
            // 
            this.CB_Sigma.FormattingEnabled = true;
            this.CB_Sigma.Items.AddRange(new object[] {
            "0.4",
            "0.6",
            "0.8",
            "1",
            "1.5",
            "2",
            "3",
            "4",
            "5",
            "7"});
            this.CB_Sigma.Location = new System.Drawing.Point(94, 23);
            this.CB_Sigma.Name = "CB_Sigma";
            this.CB_Sigma.Size = new System.Drawing.Size(75, 22);
            this.CB_Sigma.TabIndex = 26;
            this.CB_Sigma.Text = "1";
            // 
            // CB_Transition
            // 
            this.CB_Transition.FormattingEnabled = true;
            this.CB_Transition.Items.AddRange(new object[] {
            "positive",
            "negative",
            "all"});
            this.CB_Transition.Location = new System.Drawing.Point(94, 79);
            this.CB_Transition.Name = "CB_Transition";
            this.CB_Transition.Size = new System.Drawing.Size(75, 22);
            this.CB_Transition.TabIndex = 23;
            this.CB_Transition.Text = "all";
            // 
            // CB_Threshold
            // 
            this.CB_Threshold.FormattingEnabled = true;
            this.CB_Threshold.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "30",
            "40",
            "50",
            "60",
            "70",
            "90",
            "110"});
            this.CB_Threshold.Location = new System.Drawing.Point(94, 51);
            this.CB_Threshold.Name = "CB_Threshold";
            this.CB_Threshold.Size = new System.Drawing.Size(75, 22);
            this.CB_Threshold.TabIndex = 25;
            this.CB_Threshold.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 14);
            this.label5.TabIndex = 27;
            this.label5.Text = "Sigma";
            // 
            // B_Get_Point
            // 
            this.B_Get_Point.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Get_Point.Location = new System.Drawing.Point(105, 264);
            this.B_Get_Point.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Get_Point.Name = "B_Get_Point";
            this.B_Get_Point.Size = new System.Drawing.Size(100, 41);
            this.B_Get_Point.TabIndex = 22;
            this.B_Get_Point.Text = "尋找點";
            this.B_Get_Point.UseVisualStyleBackColor = true;
            this.B_Get_Point.Click += new System.EventHandler(this.B_Get_Point_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Orange;
            this.button3.Location = new System.Drawing.Point(187, 5);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 36);
            this.button3.TabIndex = 21;
            this.button3.Text = "下一步 =>";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.B_Finish);
            this.tabPage5.Controls.Add(this.button4);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(367, 571);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Step3";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Enter += new System.EventHandler(this.tabPage5_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CB_Disp_Line);
            this.groupBox3.Controls.Add(this.CB_Disp_Point);
            this.groupBox3.Location = new System.Drawing.Point(31, 102);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(150, 84);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ 顯示參數 ]";
            // 
            // CB_Disp_Line
            // 
            this.CB_Disp_Line.AutoSize = true;
            this.CB_Disp_Line.Checked = true;
            this.CB_Disp_Line.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Disp_Line.Location = new System.Drawing.Point(19, 54);
            this.CB_Disp_Line.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Disp_Line.Name = "CB_Disp_Line";
            this.CB_Disp_Line.Size = new System.Drawing.Size(106, 18);
            this.CB_Disp_Line.TabIndex = 1;
            this.CB_Disp_Line.Text = "顯示搜尋-線";
            this.CB_Disp_Line.UseVisualStyleBackColor = true;
            // 
            // CB_Disp_Point
            // 
            this.CB_Disp_Point.AutoSize = true;
            this.CB_Disp_Point.Location = new System.Drawing.Point(19, 26);
            this.CB_Disp_Point.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Disp_Point.Name = "CB_Disp_Point";
            this.CB_Disp_Point.Size = new System.Drawing.Size(106, 18);
            this.CB_Disp_Point.TabIndex = 0;
            this.CB_Disp_Point.Text = "顯示搜尋-點";
            this.CB_Disp_Point.UseVisualStyleBackColor = true;
            // 
            // B_Finish
            // 
            this.B_Finish.BackColor = System.Drawing.Color.Lime;
            this.B_Finish.Location = new System.Drawing.Point(187, 5);
            this.B_Finish.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.B_Finish.Name = "B_Finish";
            this.B_Finish.Size = new System.Drawing.Size(93, 36);
            this.B_Finish.TabIndex = 24;
            this.B_Finish.Text = "完成";
            this.B_Finish.UseVisualStyleBackColor = false;
            this.B_Finish.Click += new System.EventHandler(this.B_Finish_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button4.Location = new System.Drawing.Point(31, 34);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 41);
            this.button4.TabIndex = 23;
            this.button4.Text = "搜尋結果";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(375, 64);
            this.tFrame_JJS_HW1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(633, 599);
            this.tFrame_JJS_HW1.TabIndex = 4;
            this.tFrame_JJS_HW1.JJS_HW_Reflash += new EFC.Vision.Halcon.evReflash(this.tFrame_JJS_HW1_JJS_HW_Reflash);
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
            // TForm_Find_Edge_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 663);
            this.Controls.Add(this.tFrame_JJS_HW1);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "TForm_Find_Edge_1";
            this.Text = "Form_Find_Mothed_1";
            this.Shown += new System.EventHandler(this.Form_Find_Edge_1_Shown);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Rect_Len1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox E_Rect_Phi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox E_Rect_Col;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Rect_Row;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Rect_Edit;
        private System.Windows.Forms.Button B_Rect_Select;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Button B_Get_Point;
        private System.Windows.Forms.ComboBox CB_Transition;
        private System.Windows.Forms.ComboBox CB_Select;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label Transition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CB_Sigma;
        private System.Windows.Forms.ComboBox CB_Threshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox E_Rect_Len2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox E_Point_Count;
        private System.Windows.Forms.Button B_Finish;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CB_Disp_Line;
        private System.Windows.Forms.CheckBox CB_Disp_Point;
        private System.Windows.Forms.Button B_Used_In_Image;
        private System.Windows.Forms.Button B_Used_Sor_Image;
        private System.Windows.Forms.ImageList imageList1;
    }
}