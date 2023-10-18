namespace EFC.HMI
{
    partial class TForm_HMI_Alarm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CB_Active_Mode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CB_Light_Bit_Count = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.E_Light_Device = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_Column4_Width = new System.Windows.Forms.TextBox();
            this.E_Column3_Width = new System.Windows.Forms.TextBox();
            this.E_Column2_Width = new System.Windows.Forms.TextBox();
            this.E_Column1_Width = new System.Windows.Forms.TextBox();
            this.CB_Column4_SW = new System.Windows.Forms.CheckBox();
            this.CB_Column3_SW = new System.Windows.Forms.CheckBox();
            this.CB_Column2_SW = new System.Windows.Forms.CheckBox();
            this.CB_Column1_SW = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.B_Status_Font_Color = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.B_Status_Font = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.B_Status_Color = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DG_Grid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(317, 267);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 291);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 261);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "開關功能";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CB_Active_Mode);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(18, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 70);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ 格式 ]";
            // 
            // CB_Active_Mode
            // 
            this.CB_Active_Mode.FormattingEnabled = true;
            this.CB_Active_Mode.Items.AddRange(new object[] {
            "動作",
            "歷史",
            "紀錄",
            "記數"});
            this.CB_Active_Mode.Location = new System.Drawing.Point(201, 30);
            this.CB_Active_Mode.Name = "CB_Active_Mode";
            this.CB_Active_Mode.Size = new System.Drawing.Size(100, 24);
            this.CB_Active_Mode.TabIndex = 12;
            this.CB_Active_Mode.Text = "動作";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "顯示模式";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.CB_Light_Bit_Count);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.E_Light_Device);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(18, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(348, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[指示燈]";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "D",
            "R"});
            this.comboBox1.Location = new System.Drawing.Point(160, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(52, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "D";
            // 
            // CB_Light_Bit_Count
            // 
            this.CB_Light_Bit_Count.FormattingEnabled = true;
            this.CB_Light_Bit_Count.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CB_Light_Bit_Count.Location = new System.Drawing.Point(233, 69);
            this.CB_Light_Bit_Count.Name = "CB_Light_Bit_Count";
            this.CB_Light_Bit_Count.Size = new System.Drawing.Size(68, 24);
            this.CB_Light_Bit_Count.TabIndex = 5;
            this.CB_Light_Bit_Count.Text = "1";
            this.CB_Light_Bit_Count.TextChanged += new System.EventHandler(this.CB_Light_Bit_Count_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "狀態位元數";
            // 
            // E_Light_Device
            // 
            this.E_Light_Device.Location = new System.Drawing.Point(218, 32);
            this.E_Light_Device.Name = "E_Light_Device";
            this.E_Light_Device.Size = new System.Drawing.Size(83, 27);
            this.E_Light_Device.TabIndex = 1;
            this.E_Light_Device.Text = "X00000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "PLC位置";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(431, 261);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "訊息欄位";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.E_Column4_Width);
            this.groupBox1.Controls.Add(this.E_Column3_Width);
            this.groupBox1.Controls.Add(this.E_Column2_Width);
            this.groupBox1.Controls.Add(this.E_Column1_Width);
            this.groupBox1.Controls.Add(this.CB_Column4_SW);
            this.groupBox1.Controls.Add(this.CB_Column3_SW);
            this.groupBox1.Controls.Add(this.CB_Column2_SW);
            this.groupBox1.Controls.Add(this.CB_Column1_SW);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 186);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 訊息欄位 ]";
            // 
            // E_Column4_Width
            // 
            this.E_Column4_Width.Location = new System.Drawing.Point(201, 139);
            this.E_Column4_Width.Name = "E_Column4_Width";
            this.E_Column4_Width.Size = new System.Drawing.Size(100, 27);
            this.E_Column4_Width.TabIndex = 8;
            this.E_Column4_Width.Text = "100";
            this.E_Column4_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Column3_Width
            // 
            this.E_Column3_Width.Location = new System.Drawing.Point(201, 102);
            this.E_Column3_Width.Name = "E_Column3_Width";
            this.E_Column3_Width.Size = new System.Drawing.Size(100, 27);
            this.E_Column3_Width.TabIndex = 7;
            this.E_Column3_Width.Text = "100";
            this.E_Column3_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Column2_Width
            // 
            this.E_Column2_Width.Location = new System.Drawing.Point(201, 65);
            this.E_Column2_Width.Name = "E_Column2_Width";
            this.E_Column2_Width.Size = new System.Drawing.Size(100, 27);
            this.E_Column2_Width.TabIndex = 6;
            this.E_Column2_Width.Text = "100";
            this.E_Column2_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Column1_Width
            // 
            this.E_Column1_Width.Location = new System.Drawing.Point(201, 28);
            this.E_Column1_Width.Name = "E_Column1_Width";
            this.E_Column1_Width.Size = new System.Drawing.Size(100, 27);
            this.E_Column1_Width.TabIndex = 5;
            this.E_Column1_Width.Text = "100";
            this.E_Column1_Width.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CB_Column4_SW
            // 
            this.CB_Column4_SW.AutoSize = true;
            this.CB_Column4_SW.Location = new System.Drawing.Point(15, 141);
            this.CB_Column4_SW.Name = "CB_Column4_SW";
            this.CB_Column4_SW.Size = new System.Drawing.Size(95, 20);
            this.CB_Column4_SW.TabIndex = 3;
            this.CB_Column4_SW.Text = "發生次數";
            this.CB_Column4_SW.UseVisualStyleBackColor = true;
            // 
            // CB_Column3_SW
            // 
            this.CB_Column3_SW.AutoSize = true;
            this.CB_Column3_SW.Location = new System.Drawing.Point(15, 104);
            this.CB_Column3_SW.Name = "CB_Column3_SW";
            this.CB_Column3_SW.Size = new System.Drawing.Size(95, 20);
            this.CB_Column3_SW.TabIndex = 2;
            this.CB_Column3_SW.Text = "解除時間";
            this.CB_Column3_SW.UseVisualStyleBackColor = true;
            // 
            // CB_Column2_SW
            // 
            this.CB_Column2_SW.AutoSize = true;
            this.CB_Column2_SW.Location = new System.Drawing.Point(15, 67);
            this.CB_Column2_SW.Name = "CB_Column2_SW";
            this.CB_Column2_SW.Size = new System.Drawing.Size(95, 20);
            this.CB_Column2_SW.TabIndex = 1;
            this.CB_Column2_SW.Text = "發生時間";
            this.CB_Column2_SW.UseVisualStyleBackColor = true;
            // 
            // CB_Column1_SW
            // 
            this.CB_Column1_SW.AutoSize = true;
            this.CB_Column1_SW.Location = new System.Drawing.Point(15, 30);
            this.CB_Column1_SW.Name = "CB_Column1_SW";
            this.CB_Column1_SW.Size = new System.Drawing.Size(61, 20);
            this.CB_Column1_SW.TabIndex = 0;
            this.CB_Column1_SW.Text = "訊息";
            this.CB_Column1_SW.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 104);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "按鈕顏色";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.B_Status_Font_Color);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.B_Status_Font);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.B_Status_Color);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(12, 267);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(298, 287);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "[外觀]";
            // 
            // B_Status_Font_Color
            // 
            this.B_Status_Font_Color.Location = new System.Drawing.Point(111, 65);
            this.B_Status_Font_Color.Name = "B_Status_Font_Color";
            this.B_Status_Font_Color.Size = new System.Drawing.Size(154, 29);
            this.B_Status_Font_Color.TabIndex = 14;
            this.B_Status_Font_Color.UseVisualStyleBackColor = true;
            this.B_Status_Font_Color.Click += new System.EventHandler(this.B_Status_Font_Color_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "文字顏色";
            // 
            // B_Status_Font
            // 
            this.B_Status_Font.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Status_Font.Location = new System.Drawing.Point(111, 30);
            this.B_Status_Font.Name = "B_Status_Font";
            this.B_Status_Font.Size = new System.Drawing.Size(154, 29);
            this.B_Status_Font.TabIndex = 12;
            this.B_Status_Font.Text = "...";
            this.B_Status_Font.UseVisualStyleBackColor = true;
            this.B_Status_Font.Click += new System.EventHandler(this.B_Status_Font_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "字型";
            // 
            // B_Status_Color
            // 
            this.B_Status_Color.Location = new System.Drawing.Point(111, 100);
            this.B_Status_Color.Name = "B_Status_Color";
            this.B_Status_Color.Size = new System.Drawing.Size(154, 29);
            this.B_Status_Color.TabIndex = 9;
            this.B_Status_Color.UseVisualStyleBackColor = true;
            this.B_Status_Color.Click += new System.EventHandler(this.B_Status_Color_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 570);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 100);
            this.panel1.TabIndex = 7;
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(425, 26);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(135, 49);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Apply
            // 
            this.B_Apply.Location = new System.Drawing.Point(170, 26);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(135, 49);
            this.B_Apply.TabIndex = 0;
            this.B_Apply.Text = "確定";
            this.B_Apply.UseVisualStyleBackColor = true;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(771, 64);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.DG_Grid);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(771, 184);
            this.panel3.TabIndex = 9;
            // 
            // DG_Grid
            // 
            this.DG_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Grid.Location = new System.Drawing.Point(0, 0);
            this.DG_Grid.Name = "DG_Grid";
            this.DG_Grid.RowTemplate.Height = 27;
            this.DG_Grid.Size = new System.Drawing.Size(771, 184);
            this.DG_Grid.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(111, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 29);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TForm_HMI_Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 670);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_HMI_Alarm";
            this.Text = "TForm_HMI_Button";
            this.Shown += new System.EventHandler(this.TForm_HMI_Button_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CB_Light_Bit_Count;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox E_Light_Device;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_Status_Color;
        private System.Windows.Forms.Button B_Status_Font;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_Status_Font_Color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DG_Grid;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CB_Active_Mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Column4_Width;
        private System.Windows.Forms.TextBox E_Column3_Width;
        private System.Windows.Forms.TextBox E_Column2_Width;
        private System.Windows.Forms.TextBox E_Column1_Width;
        private System.Windows.Forms.CheckBox CB_Column4_SW;
        private System.Windows.Forms.CheckBox CB_Column3_SW;
        private System.Windows.Forms.CheckBox CB_Column2_SW;
        private System.Windows.Forms.CheckBox CB_Column1_SW;
        private System.Windows.Forms.Button button1;
    }
}