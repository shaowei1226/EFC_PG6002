namespace Main
{
     partial class TForm_Data_View
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.說明 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_ASCII = new System.Windows.Forms.RadioButton();
            this.RB_Hex = new System.Windows.Forms.RadioButton();
            this.RB_Dec = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Unsigned = new System.Windows.Forms.CheckBox();
            this.RB_32Bit = new System.Windows.Forms.RadioButton();
            this.RB_16Bit = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.CB15 = new System.Windows.Forms.CheckBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.CB14 = new System.Windows.Forms.CheckBox();
            this.CB13 = new System.Windows.Forms.CheckBox();
            this.CB12 = new System.Windows.Forms.CheckBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.CB11 = new System.Windows.Forms.CheckBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.CB10 = new System.Windows.Forms.CheckBox();
            this.Label09 = new System.Windows.Forms.Label();
            this.CB09 = new System.Windows.Forms.CheckBox();
            this.Label08 = new System.Windows.Forms.Label();
            this.CB08 = new System.Windows.Forms.CheckBox();
            this.Label07 = new System.Windows.Forms.Label();
            this.Label06 = new System.Windows.Forms.Label();
            this.Label04 = new System.Windows.Forms.Label();
            this.CB07 = new System.Windows.Forms.CheckBox();
            this.Label05 = new System.Windows.Forms.Label();
            this.CB06 = new System.Windows.Forms.CheckBox();
            this.CB05 = new System.Windows.Forms.CheckBox();
            this.CB04 = new System.Windows.Forms.CheckBox();
            this.Label03 = new System.Windows.Forms.Label();
            this.CB03 = new System.Windows.Forms.CheckBox();
            this.Label02 = new System.Windows.Forms.Label();
            this.CB02 = new System.Windows.Forms.CheckBox();
            this.Label01 = new System.Windows.Forms.Label();
            this.CB01 = new System.Windows.Forms.CheckBox();
            this.Label00 = new System.Windows.Forms.Label();
            this.CB00 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 894);
            this.panel2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.說明});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(705, 794);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NO";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "FEDC--BA98--7654--3210";
            this.Column2.Name = "Column2";
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Value";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // 說明
            // 
            this.說明.HeaderText = "說明";
            this.說明.Name = "說明";
            this.說明.Width = 350;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(705, 100);
            this.panel4.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_ASCII);
            this.groupBox2.Controls.Add(this.RB_Hex);
            this.groupBox2.Controls.Add(this.RB_Dec);
            this.groupBox2.Location = new System.Drawing.Point(279, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(425, 78);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // RB_ASCII
            // 
            this.RB_ASCII.AutoSize = true;
            this.RB_ASCII.Location = new System.Drawing.Point(285, 37);
            this.RB_ASCII.Margin = new System.Windows.Forms.Padding(6);
            this.RB_ASCII.Name = "RB_ASCII";
            this.RB_ASCII.Size = new System.Drawing.Size(61, 22);
            this.RB_ASCII.TabIndex = 3;
            this.RB_ASCII.TabStop = true;
            this.RB_ASCII.Text = "ASCII";
            this.RB_ASCII.UseVisualStyleBackColor = true;
            // 
            // RB_Hex
            // 
            this.RB_Hex.AutoSize = true;
            this.RB_Hex.Location = new System.Drawing.Point(138, 37);
            this.RB_Hex.Margin = new System.Windows.Forms.Padding(6);
            this.RB_Hex.Name = "RB_Hex";
            this.RB_Hex.Size = new System.Drawing.Size(97, 22);
            this.RB_Hex.TabIndex = 2;
            this.RB_Hex.TabStop = true;
            this.RB_Hex.Text = "十六進位";
            this.RB_Hex.UseVisualStyleBackColor = true;
            this.RB_Hex.CheckedChanged += new System.EventHandler(this.RB_Hex_CheckedChanged);
            // 
            // RB_Dec
            // 
            this.RB_Dec.AutoSize = true;
            this.RB_Dec.Checked = true;
            this.RB_Dec.Location = new System.Drawing.Point(12, 38);
            this.RB_Dec.Margin = new System.Windows.Forms.Padding(6);
            this.RB_Dec.Name = "RB_Dec";
            this.RB_Dec.Size = new System.Drawing.Size(80, 22);
            this.RB_Dec.TabIndex = 1;
            this.RB_Dec.TabStop = true;
            this.RB_Dec.Text = "十進位";
            this.RB_Dec.UseVisualStyleBackColor = true;
            this.RB_Dec.CheckedChanged += new System.EventHandler(this.RB_Dec_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_Unsigned);
            this.groupBox1.Controls.Add(this.RB_32Bit);
            this.groupBox1.Controls.Add(this.RB_16Bit);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(252, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料型別";
            // 
            // CB_Unsigned
            // 
            this.CB_Unsigned.AutoSize = true;
            this.CB_Unsigned.Checked = true;
            this.CB_Unsigned.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Unsigned.Location = new System.Drawing.Point(134, 1);
            this.CB_Unsigned.Margin = new System.Windows.Forms.Padding(6);
            this.CB_Unsigned.Name = "CB_Unsigned";
            this.CB_Unsigned.Size = new System.Drawing.Size(48, 22);
            this.CB_Unsigned.TabIndex = 5;
            this.CB_Unsigned.Text = "+/-";
            this.CB_Unsigned.UseVisualStyleBackColor = true;
            // 
            // RB_32Bit
            // 
            this.RB_32Bit.AutoSize = true;
            this.RB_32Bit.Location = new System.Drawing.Point(158, 38);
            this.RB_32Bit.Margin = new System.Windows.Forms.Padding(6);
            this.RB_32Bit.Name = "RB_32Bit";
            this.RB_32Bit.Size = new System.Drawing.Size(60, 22);
            this.RB_32Bit.TabIndex = 3;
            this.RB_32Bit.Text = "32Bit";
            this.RB_32Bit.UseVisualStyleBackColor = true;
            this.RB_32Bit.CheckedChanged += new System.EventHandler(this.RB_32Bit_CheckedChanged);
            // 
            // RB_16Bit
            // 
            this.RB_16Bit.AutoSize = true;
            this.RB_16Bit.Checked = true;
            this.RB_16Bit.Location = new System.Drawing.Point(24, 38);
            this.RB_16Bit.Margin = new System.Windows.Forms.Padding(6);
            this.RB_16Bit.Name = "RB_16Bit";
            this.RB_16Bit.Size = new System.Drawing.Size(60, 22);
            this.RB_16Bit.TabIndex = 2;
            this.RB_16Bit.TabStop = true;
            this.RB_16Bit.Text = "16Bit";
            this.RB_16Bit.UseVisualStyleBackColor = true;
            this.RB_16Bit.CheckedChanged += new System.EventHandler(this.RB_16Bit_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(705, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 894);
            this.panel1.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Label15);
            this.groupBox3.Controls.Add(this.Label14);
            this.groupBox3.Controls.Add(this.Label12);
            this.groupBox3.Controls.Add(this.CB15);
            this.groupBox3.Controls.Add(this.Label13);
            this.groupBox3.Controls.Add(this.CB14);
            this.groupBox3.Controls.Add(this.CB13);
            this.groupBox3.Controls.Add(this.CB12);
            this.groupBox3.Controls.Add(this.Label11);
            this.groupBox3.Controls.Add(this.CB11);
            this.groupBox3.Controls.Add(this.Label10);
            this.groupBox3.Controls.Add(this.CB10);
            this.groupBox3.Controls.Add(this.Label09);
            this.groupBox3.Controls.Add(this.CB09);
            this.groupBox3.Controls.Add(this.Label08);
            this.groupBox3.Controls.Add(this.CB08);
            this.groupBox3.Controls.Add(this.Label07);
            this.groupBox3.Controls.Add(this.Label06);
            this.groupBox3.Controls.Add(this.Label04);
            this.groupBox3.Controls.Add(this.CB07);
            this.groupBox3.Controls.Add(this.Label05);
            this.groupBox3.Controls.Add(this.CB06);
            this.groupBox3.Controls.Add(this.CB05);
            this.groupBox3.Controls.Add(this.CB04);
            this.groupBox3.Controls.Add(this.Label03);
            this.groupBox3.Controls.Add(this.CB03);
            this.groupBox3.Controls.Add(this.Label02);
            this.groupBox3.Controls.Add(this.CB02);
            this.groupBox3.Controls.Add(this.Label01);
            this.groupBox3.Controls.Add(this.CB01);
            this.groupBox3.Controls.Add(this.Label00);
            this.groupBox3.Controls.Add(this.CB00);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(17, 100);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(488, 565);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(56, 526);
            this.Label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(51, 20);
            this.Label15.TabIndex = 33;
            this.Label15.Text = "預留";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(56, 493);
            this.Label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(51, 20);
            this.Label14.TabIndex = 32;
            this.Label14.Text = "預留";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(56, 430);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(51, 20);
            this.Label12.TabIndex = 31;
            this.Label12.Text = "預留";
            // 
            // CB15
            // 
            this.CB15.AutoSize = true;
            this.CB15.Location = new System.Drawing.Point(8, 525);
            this.CB15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB15.Name = "CB15";
            this.CB15.Size = new System.Drawing.Size(58, 24);
            this.CB15.TabIndex = 30;
            this.CB15.Text = "15-";
            this.CB15.UseVisualStyleBackColor = true;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(56, 462);
            this.Label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(51, 20);
            this.Label13.TabIndex = 29;
            this.Label13.Text = "預留";
            // 
            // CB14
            // 
            this.CB14.AutoSize = true;
            this.CB14.Location = new System.Drawing.Point(8, 493);
            this.CB14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB14.Name = "CB14";
            this.CB14.Size = new System.Drawing.Size(58, 24);
            this.CB14.TabIndex = 28;
            this.CB14.Text = "14-";
            this.CB14.UseVisualStyleBackColor = true;
            // 
            // CB13
            // 
            this.CB13.AutoSize = true;
            this.CB13.Location = new System.Drawing.Point(8, 461);
            this.CB13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB13.Name = "CB13";
            this.CB13.Size = new System.Drawing.Size(58, 24);
            this.CB13.TabIndex = 27;
            this.CB13.Text = "13-";
            this.CB13.UseVisualStyleBackColor = true;
            // 
            // CB12
            // 
            this.CB12.AutoSize = true;
            this.CB12.Location = new System.Drawing.Point(8, 428);
            this.CB12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB12.Name = "CB12";
            this.CB12.Size = new System.Drawing.Size(58, 24);
            this.CB12.TabIndex = 26;
            this.CB12.Text = "12-";
            this.CB12.UseVisualStyleBackColor = true;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(56, 398);
            this.Label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(51, 20);
            this.Label11.TabIndex = 25;
            this.Label11.Text = "預留";
            // 
            // CB11
            // 
            this.CB11.AutoSize = true;
            this.CB11.Location = new System.Drawing.Point(8, 397);
            this.CB11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB11.Name = "CB11";
            this.CB11.Size = new System.Drawing.Size(58, 24);
            this.CB11.TabIndex = 24;
            this.CB11.Text = "11-";
            this.CB11.UseVisualStyleBackColor = true;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(56, 366);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(51, 20);
            this.Label10.TabIndex = 23;
            this.Label10.Text = "預留";
            // 
            // CB10
            // 
            this.CB10.AutoSize = true;
            this.CB10.Location = new System.Drawing.Point(8, 365);
            this.CB10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB10.Name = "CB10";
            this.CB10.Size = new System.Drawing.Size(58, 24);
            this.CB10.TabIndex = 22;
            this.CB10.Text = "10-";
            this.CB10.UseVisualStyleBackColor = true;
            // 
            // Label09
            // 
            this.Label09.AutoSize = true;
            this.Label09.Location = new System.Drawing.Point(56, 332);
            this.Label09.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label09.Name = "Label09";
            this.Label09.Size = new System.Drawing.Size(51, 20);
            this.Label09.TabIndex = 21;
            this.Label09.Text = "預留";
            // 
            // CB09
            // 
            this.CB09.AutoSize = true;
            this.CB09.Location = new System.Drawing.Point(8, 331);
            this.CB09.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB09.Name = "CB09";
            this.CB09.Size = new System.Drawing.Size(58, 24);
            this.CB09.TabIndex = 20;
            this.CB09.Text = "09-";
            this.CB09.UseVisualStyleBackColor = true;
            // 
            // Label08
            // 
            this.Label08.AutoSize = true;
            this.Label08.Location = new System.Drawing.Point(56, 302);
            this.Label08.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label08.Name = "Label08";
            this.Label08.Size = new System.Drawing.Size(51, 20);
            this.Label08.TabIndex = 19;
            this.Label08.Text = "預留";
            // 
            // CB08
            // 
            this.CB08.AutoSize = true;
            this.CB08.Location = new System.Drawing.Point(8, 300);
            this.CB08.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB08.Name = "CB08";
            this.CB08.Size = new System.Drawing.Size(58, 24);
            this.CB08.TabIndex = 18;
            this.CB08.Text = "08-";
            this.CB08.UseVisualStyleBackColor = true;
            // 
            // Label07
            // 
            this.Label07.AutoSize = true;
            this.Label07.Location = new System.Drawing.Point(56, 252);
            this.Label07.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label07.Name = "Label07";
            this.Label07.Size = new System.Drawing.Size(51, 20);
            this.Label07.TabIndex = 17;
            this.Label07.Text = "預留";
            // 
            // Label06
            // 
            this.Label06.AutoSize = true;
            this.Label06.Location = new System.Drawing.Point(56, 219);
            this.Label06.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label06.Name = "Label06";
            this.Label06.Size = new System.Drawing.Size(51, 20);
            this.Label06.TabIndex = 16;
            this.Label06.Text = "預留";
            // 
            // Label04
            // 
            this.Label04.AutoSize = true;
            this.Label04.Location = new System.Drawing.Point(56, 156);
            this.Label04.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label04.Name = "Label04";
            this.Label04.Size = new System.Drawing.Size(51, 20);
            this.Label04.TabIndex = 15;
            this.Label04.Text = "預留";
            // 
            // CB07
            // 
            this.CB07.AutoSize = true;
            this.CB07.Location = new System.Drawing.Point(8, 251);
            this.CB07.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB07.Name = "CB07";
            this.CB07.Size = new System.Drawing.Size(58, 24);
            this.CB07.TabIndex = 14;
            this.CB07.Text = "07-";
            this.CB07.UseVisualStyleBackColor = true;
            // 
            // Label05
            // 
            this.Label05.AutoSize = true;
            this.Label05.Location = new System.Drawing.Point(56, 188);
            this.Label05.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label05.Name = "Label05";
            this.Label05.Size = new System.Drawing.Size(51, 20);
            this.Label05.TabIndex = 13;
            this.Label05.Text = "預留";
            // 
            // CB06
            // 
            this.CB06.AutoSize = true;
            this.CB06.Location = new System.Drawing.Point(8, 219);
            this.CB06.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB06.Name = "CB06";
            this.CB06.Size = new System.Drawing.Size(58, 24);
            this.CB06.TabIndex = 12;
            this.CB06.Text = "06-";
            this.CB06.UseVisualStyleBackColor = true;
            // 
            // CB05
            // 
            this.CB05.AutoSize = true;
            this.CB05.Location = new System.Drawing.Point(8, 187);
            this.CB05.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB05.Name = "CB05";
            this.CB05.Size = new System.Drawing.Size(58, 24);
            this.CB05.TabIndex = 10;
            this.CB05.Text = "05-";
            this.CB05.UseVisualStyleBackColor = true;
            // 
            // CB04
            // 
            this.CB04.AutoSize = true;
            this.CB04.Location = new System.Drawing.Point(8, 154);
            this.CB04.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB04.Name = "CB04";
            this.CB04.Size = new System.Drawing.Size(58, 24);
            this.CB04.TabIndex = 8;
            this.CB04.Text = "04-";
            this.CB04.UseVisualStyleBackColor = true;
            // 
            // Label03
            // 
            this.Label03.AutoSize = true;
            this.Label03.Location = new System.Drawing.Point(56, 124);
            this.Label03.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label03.Name = "Label03";
            this.Label03.Size = new System.Drawing.Size(51, 20);
            this.Label03.TabIndex = 7;
            this.Label03.Text = "預留";
            // 
            // CB03
            // 
            this.CB03.AutoSize = true;
            this.CB03.Location = new System.Drawing.Point(8, 122);
            this.CB03.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB03.Name = "CB03";
            this.CB03.Size = new System.Drawing.Size(58, 24);
            this.CB03.TabIndex = 6;
            this.CB03.Text = "03-";
            this.CB03.UseVisualStyleBackColor = true;
            // 
            // Label02
            // 
            this.Label02.AutoSize = true;
            this.Label02.Location = new System.Drawing.Point(56, 92);
            this.Label02.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label02.Name = "Label02";
            this.Label02.Size = new System.Drawing.Size(51, 20);
            this.Label02.TabIndex = 5;
            this.Label02.Text = "預留";
            // 
            // CB02
            // 
            this.CB02.AutoSize = true;
            this.CB02.Location = new System.Drawing.Point(8, 91);
            this.CB02.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB02.Name = "CB02";
            this.CB02.Size = new System.Drawing.Size(58, 24);
            this.CB02.TabIndex = 4;
            this.CB02.Text = "02-";
            this.CB02.UseVisualStyleBackColor = true;
            // 
            // Label01
            // 
            this.Label01.AutoSize = true;
            this.Label01.Location = new System.Drawing.Point(56, 58);
            this.Label01.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label01.Name = "Label01";
            this.Label01.Size = new System.Drawing.Size(51, 20);
            this.Label01.TabIndex = 3;
            this.Label01.Text = "預留";
            // 
            // CB01
            // 
            this.CB01.AutoSize = true;
            this.CB01.Location = new System.Drawing.Point(8, 57);
            this.CB01.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB01.Name = "CB01";
            this.CB01.Size = new System.Drawing.Size(58, 24);
            this.CB01.TabIndex = 2;
            this.CB01.Text = "01-";
            this.CB01.UseVisualStyleBackColor = true;
            // 
            // Label00
            // 
            this.Label00.AutoSize = true;
            this.Label00.Location = new System.Drawing.Point(56, 28);
            this.Label00.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label00.Name = "Label00";
            this.Label00.Size = new System.Drawing.Size(51, 20);
            this.Label00.TabIndex = 1;
            this.Label00.Text = "預留";
            // 
            // CB00
            // 
            this.CB00.AutoSize = true;
            this.CB00.Location = new System.Drawing.Point(8, 26);
            this.CB00.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CB00.Name = "CB00";
            this.CB00.Size = new System.Drawing.Size(58, 24);
            this.CB00.TabIndex = 0;
            this.CB00.Text = "00-";
            this.CB00.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 49);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "寫入";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TForm_Data_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 894);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TForm_Data_View";
            this.Text = "TForm_Data_View";
            this.Shown += new System.EventHandler(this.TForm_Data_View_Shown);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.Panel panel2;
          private System.Windows.Forms.DataGridView dataGridView1;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
          private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
          private System.Windows.Forms.DataGridViewTextBoxColumn 說明;
          private System.Windows.Forms.Panel panel4;
          private System.Windows.Forms.GroupBox groupBox2;
          private System.Windows.Forms.RadioButton RB_ASCII;
          private System.Windows.Forms.RadioButton RB_Hex;
          private System.Windows.Forms.RadioButton RB_Dec;
          private System.Windows.Forms.GroupBox groupBox1;
          private System.Windows.Forms.CheckBox CB_Unsigned;
          private System.Windows.Forms.RadioButton RB_32Bit;
          private System.Windows.Forms.RadioButton RB_16Bit;
          private System.Windows.Forms.Panel panel1;
          internal System.Windows.Forms.GroupBox groupBox3;
          internal System.Windows.Forms.Label Label15;
          internal System.Windows.Forms.Label Label14;
          internal System.Windows.Forms.Label Label12;
          internal System.Windows.Forms.CheckBox CB15;
          internal System.Windows.Forms.Label Label13;
          internal System.Windows.Forms.CheckBox CB14;
          internal System.Windows.Forms.CheckBox CB13;
          internal System.Windows.Forms.CheckBox CB12;
          internal System.Windows.Forms.Label Label11;
          internal System.Windows.Forms.CheckBox CB11;
          internal System.Windows.Forms.Label Label10;
          internal System.Windows.Forms.CheckBox CB10;
          internal System.Windows.Forms.Label Label09;
          internal System.Windows.Forms.CheckBox CB09;
          internal System.Windows.Forms.Label Label08;
          internal System.Windows.Forms.CheckBox CB08;
          internal System.Windows.Forms.Label Label07;
          internal System.Windows.Forms.Label Label06;
          internal System.Windows.Forms.Label Label04;
          internal System.Windows.Forms.CheckBox CB07;
          internal System.Windows.Forms.Label Label05;
          internal System.Windows.Forms.CheckBox CB06;
          internal System.Windows.Forms.CheckBox CB05;
          internal System.Windows.Forms.CheckBox CB04;
          internal System.Windows.Forms.Label Label03;
          internal System.Windows.Forms.CheckBox CB03;
          internal System.Windows.Forms.Label Label02;
          internal System.Windows.Forms.CheckBox CB02;
          internal System.Windows.Forms.Label Label01;
          internal System.Windows.Forms.CheckBox CB01;
          internal System.Windows.Forms.Label Label00;
          internal System.Windows.Forms.CheckBox CB00;
          private System.Windows.Forms.Button button1;
          private System.Windows.Forms.Timer timer1;
     }
}