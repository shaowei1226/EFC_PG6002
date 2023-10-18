namespace EFC.HMI
{
    partial class TForm_HMI_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_HMI_Edit));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Flag_Hide_Disp = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_Num_Data_Type2 = new System.Windows.Forms.RadioButton();
            this.RB_Num_Data_Type1 = new System.Windows.Forms.RadioButton();
            this.CB_Flag_Round = new System.Windows.Forms.CheckBox();
            this.CB_Flag_Signed = new System.Windows.Forms.CheckBox();
            this.CB_Flag_F_Zero = new System.Windows.Forms.CheckBox();
            this.CB_Dot_Num = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_All_Num = new System.Windows.Forms.ComboBox();
            this.E_Device = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.RB_Lock_Type2 = new System.Windows.Forms.RadioButton();
            this.RB_Lock_Type1 = new System.Windows.Forms.RadioButton();
            this.CB_Lock_Switch = new System.Windows.Forms.CheckBox();
            this.E_Lock_Device = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.E_Disp = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.B_Status_Font_Color = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.B_Status_Font = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.B_Status_Color = new System.Windows.Forms.Button();
            this.B_Status_Picture = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.B_Text_Align3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_Text_Align2 = new System.Windows.Forms.Button();
            this.B_Text_Align1 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.RB_Data_Type1 = new System.Windows.Forms.RadioButton();
            this.RB_Data_Type2 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_Sting_Num = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(317, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 488);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(431, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "開關功能";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.tabControl2);
            this.groupBox1.Controls.Add(this.E_Device);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(417, 418);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[開關]";
            // 
            // CB_Flag_Hide_Disp
            // 
            this.CB_Flag_Hide_Disp.AutoSize = true;
            this.CB_Flag_Hide_Disp.Location = new System.Drawing.Point(189, 202);
            this.CB_Flag_Hide_Disp.Name = "CB_Flag_Hide_Disp";
            this.CB_Flag_Hide_Disp.Size = new System.Drawing.Size(136, 24);
            this.CB_Flag_Hide_Disp.TabIndex = 15;
            this.CB_Flag_Hide_Disp.Text = "隱藏輸入值";
            this.CB_Flag_Hide_Disp.UseVisualStyleBackColor = true;
            this.CB_Flag_Hide_Disp.Click += new System.EventHandler(this.CB_Flag_F_Zero_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_Num_Data_Type2);
            this.groupBox2.Controls.Add(this.RB_Num_Data_Type1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 73);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[資料型態]";
            // 
            // RB_Num_Data_Type2
            // 
            this.RB_Num_Data_Type2.AutoSize = true;
            this.RB_Num_Data_Type2.Location = new System.Drawing.Point(183, 30);
            this.RB_Num_Data_Type2.Name = "RB_Num_Data_Type2";
            this.RB_Num_Data_Type2.Size = new System.Drawing.Size(80, 24);
            this.RB_Num_Data_Type2.TabIndex = 1;
            this.RB_Num_Data_Type2.TabStop = true;
            this.RB_Num_Data_Type2.Text = "32bits";
            this.RB_Num_Data_Type2.UseVisualStyleBackColor = true;
            // 
            // RB_Num_Data_Type1
            // 
            this.RB_Num_Data_Type1.AutoSize = true;
            this.RB_Num_Data_Type1.Location = new System.Drawing.Point(18, 30);
            this.RB_Num_Data_Type1.Name = "RB_Num_Data_Type1";
            this.RB_Num_Data_Type1.Size = new System.Drawing.Size(84, 24);
            this.RB_Num_Data_Type1.TabIndex = 0;
            this.RB_Num_Data_Type1.TabStop = true;
            this.RB_Num_Data_Type1.Text = "16Bits";
            this.RB_Num_Data_Type1.UseVisualStyleBackColor = true;
            // 
            // CB_Flag_Round
            // 
            this.CB_Flag_Round.AutoSize = true;
            this.CB_Flag_Round.Location = new System.Drawing.Point(189, 172);
            this.CB_Flag_Round.Name = "CB_Flag_Round";
            this.CB_Flag_Round.Size = new System.Drawing.Size(115, 24);
            this.CB_Flag_Round.TabIndex = 13;
            this.CB_Flag_Round.Text = "四捨五入";
            this.CB_Flag_Round.UseVisualStyleBackColor = true;
            this.CB_Flag_Round.Click += new System.EventHandler(this.CB_Flag_F_Zero_Click);
            // 
            // CB_Flag_Signed
            // 
            this.CB_Flag_Signed.AutoSize = true;
            this.CB_Flag_Signed.Location = new System.Drawing.Point(12, 202);
            this.CB_Flag_Signed.Name = "CB_Flag_Signed";
            this.CB_Flag_Signed.Size = new System.Drawing.Size(104, 24);
            this.CB_Flag_Signed.TabIndex = 12;
            this.CB_Flag_Signed.Text = "+/- 符號";
            this.CB_Flag_Signed.UseVisualStyleBackColor = true;
            this.CB_Flag_Signed.Click += new System.EventHandler(this.CB_Flag_F_Zero_Click);
            // 
            // CB_Flag_F_Zero
            // 
            this.CB_Flag_F_Zero.AutoSize = true;
            this.CB_Flag_F_Zero.Location = new System.Drawing.Point(12, 172);
            this.CB_Flag_F_Zero.Name = "CB_Flag_F_Zero";
            this.CB_Flag_F_Zero.Size = new System.Drawing.Size(115, 24);
            this.CB_Flag_F_Zero.TabIndex = 9;
            this.CB_Flag_F_Zero.Text = "前零顯示";
            this.CB_Flag_F_Zero.UseVisualStyleBackColor = true;
            this.CB_Flag_F_Zero.Click += new System.EventHandler(this.CB_Flag_F_Zero_Click);
            // 
            // CB_Dot_Num
            // 
            this.CB_Dot_Num.FormattingEnabled = true;
            this.CB_Dot_Num.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.CB_Dot_Num.Location = new System.Drawing.Point(150, 116);
            this.CB_Dot_Num.Name = "CB_Dot_Num";
            this.CB_Dot_Num.Size = new System.Drawing.Size(60, 28);
            this.CB_Dot_Num.TabIndex = 8;
            this.CB_Dot_Num.Text = "0";
            this.CB_Dot_Num.TextChanged += new System.EventHandler(this.CB_Dot_Num_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "小數位數";
            // 
            // CB_All_Num
            // 
            this.CB_All_Num.FormattingEnabled = true;
            this.CB_All_Num.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.CB_All_Num.Location = new System.Drawing.Point(150, 86);
            this.CB_All_Num.Name = "CB_All_Num";
            this.CB_All_Num.Size = new System.Drawing.Size(60, 28);
            this.CB_All_Num.TabIndex = 6;
            this.CB_All_Num.Text = "6";
            this.CB_All_Num.TextChanged += new System.EventHandler(this.CB_All_Num_TextChanged);
            // 
            // E_Device
            // 
            this.E_Device.Location = new System.Drawing.Point(140, 37);
            this.E_Device.Name = "E_Device";
            this.E_Device.Size = new System.Drawing.Size(119, 31);
            this.E_Device.TabIndex = 1;
            this.E_Device.Text = "X0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLC位置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "全部顯示位數";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 454);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "開關共用";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.CB_Lock_Switch);
            this.groupBox3.Controls.Add(this.E_Lock_Device);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(398, 188);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[互鎖功能]";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.RB_Lock_Type2);
            this.groupBox4.Controls.Add(this.RB_Lock_Type1);
            this.groupBox4.Location = new System.Drawing.Point(26, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(345, 73);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "[觸發條件]";
            // 
            // RB_Lock_Type2
            // 
            this.RB_Lock_Type2.AutoSize = true;
            this.RB_Lock_Type2.Location = new System.Drawing.Point(183, 30);
            this.RB_Lock_Type2.Name = "RB_Lock_Type2";
            this.RB_Lock_Type2.Size = new System.Drawing.Size(130, 24);
            this.RB_Lock_Type2.TabIndex = 1;
            this.RB_Lock_Type2.TabStop = true;
            this.RB_Lock_Type2.Text = "當OFF允用";
            this.RB_Lock_Type2.UseVisualStyleBackColor = true;
            // 
            // RB_Lock_Type1
            // 
            this.RB_Lock_Type1.AutoSize = true;
            this.RB_Lock_Type1.Location = new System.Drawing.Point(18, 30);
            this.RB_Lock_Type1.Name = "RB_Lock_Type1";
            this.RB_Lock_Type1.Size = new System.Drawing.Size(123, 24);
            this.RB_Lock_Type1.TabIndex = 0;
            this.RB_Lock_Type1.TabStop = true;
            this.RB_Lock_Type1.Text = "當ON允用";
            this.RB_Lock_Type1.UseVisualStyleBackColor = true;
            // 
            // CB_Lock_Switch
            // 
            this.CB_Lock_Switch.AutoSize = true;
            this.CB_Lock_Switch.BackColor = System.Drawing.Color.White;
            this.CB_Lock_Switch.Location = new System.Drawing.Point(252, 0);
            this.CB_Lock_Switch.Name = "CB_Lock_Switch";
            this.CB_Lock_Switch.Size = new System.Drawing.Size(115, 24);
            this.CB_Lock_Switch.TabIndex = 4;
            this.CB_Lock_Switch.Text = "功能開關";
            this.CB_Lock_Switch.UseVisualStyleBackColor = false;
            // 
            // E_Lock_Device
            // 
            this.E_Lock_Device.Location = new System.Drawing.Point(252, 41);
            this.E_Lock_Device.Name = "E_Lock_Device";
            this.E_Lock_Device.Size = new System.Drawing.Size(119, 31);
            this.E_Lock_Device.TabIndex = 1;
            this.E_Lock_Device.Text = "D1000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "PLC位置";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 526);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(768, 100);
            this.panel1.TabIndex = 8;
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
            this.panel2.Controls.Add(this.E_Disp);
            this.panel2.Location = new System.Drawing.Point(12, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 222);
            this.panel2.TabIndex = 9;
            // 
            // E_Disp
            // 
            this.E_Disp.Location = new System.Drawing.Point(15, 16);
            this.E_Disp.Name = "E_Disp";
            this.E_Disp.Size = new System.Drawing.Size(100, 31);
            this.E_Disp.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.B_Status_Font_Color);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.B_Status_Font);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.B_Status_Color);
            this.groupBox5.Controls.Add(this.B_Status_Picture);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(12, 327);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(298, 181);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "[外觀]";
            // 
            // B_Status_Font_Color
            // 
            this.B_Status_Font_Color.Location = new System.Drawing.Point(116, 99);
            this.B_Status_Font_Color.Name = "B_Status_Font_Color";
            this.B_Status_Font_Color.Size = new System.Drawing.Size(154, 29);
            this.B_Status_Font_Color.TabIndex = 14;
            this.B_Status_Font_Color.UseVisualStyleBackColor = true;
            this.B_Status_Font_Color.Click += new System.EventHandler(this.B_Status_Font_Color_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "文字顏色";
            // 
            // B_Status_Font
            // 
            this.B_Status_Font.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Status_Font.Location = new System.Drawing.Point(116, 30);
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
            this.label3.Location = new System.Drawing.Point(16, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "字型";
            // 
            // B_Status_Color
            // 
            this.B_Status_Color.Location = new System.Drawing.Point(116, 134);
            this.B_Status_Color.Name = "B_Status_Color";
            this.B_Status_Color.Size = new System.Drawing.Size(154, 29);
            this.B_Status_Color.TabIndex = 9;
            this.B_Status_Color.UseVisualStyleBackColor = true;
            this.B_Status_Color.Click += new System.EventHandler(this.B_Status_Color_Click);
            // 
            // B_Status_Picture
            // 
            this.B_Status_Picture.Location = new System.Drawing.Point(116, 64);
            this.B_Status_Picture.Name = "B_Status_Picture";
            this.B_Status_Picture.Size = new System.Drawing.Size(154, 29);
            this.B_Status_Picture.TabIndex = 8;
            this.B_Status_Picture.Text = "...";
            this.B_Status_Picture.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "按鈕顏色";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 65);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "按鈕圖片";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.B_Text_Align3);
            this.groupBox6.Controls.Add(this.B_Text_Align2);
            this.groupBox6.Controls.Add(this.B_Text_Align1);
            this.groupBox6.Location = new System.Drawing.Point(12, 255);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(293, 66);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            // 
            // B_Text_Align3
            // 
            this.B_Text_Align3.ImageIndex = 2;
            this.B_Text_Align3.ImageList = this.imageList1;
            this.B_Text_Align3.Location = new System.Drawing.Point(116, 21);
            this.B_Text_Align3.Name = "B_Text_Align3";
            this.B_Text_Align3.Size = new System.Drawing.Size(42, 39);
            this.B_Text_Align3.TabIndex = 2;
            this.B_Text_Align3.UseVisualStyleBackColor = true;
            this.B_Text_Align3.Click += new System.EventHandler(this.B_Text_Align3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "paragraph_400px_1157280_easyicon.net.png");
            this.imageList1.Images.SetKeyName(1, "paragraph_400px_1157284_easyicon.net.png");
            this.imageList1.Images.SetKeyName(2, "paragraph_400px_1157279_easyicon.net.png");
            // 
            // B_Text_Align2
            // 
            this.B_Text_Align2.ImageIndex = 1;
            this.B_Text_Align2.ImageList = this.imageList1;
            this.B_Text_Align2.Location = new System.Drawing.Point(68, 21);
            this.B_Text_Align2.Name = "B_Text_Align2";
            this.B_Text_Align2.Size = new System.Drawing.Size(42, 39);
            this.B_Text_Align2.TabIndex = 1;
            this.B_Text_Align2.UseVisualStyleBackColor = true;
            this.B_Text_Align2.Click += new System.EventHandler(this.B_Text_Align2_Click);
            // 
            // B_Text_Align1
            // 
            this.B_Text_Align1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.B_Text_Align1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_Text_Align1.ImageIndex = 0;
            this.B_Text_Align1.ImageList = this.imageList1;
            this.B_Text_Align1.Location = new System.Drawing.Point(20, 21);
            this.B_Text_Align1.Name = "B_Text_Align1";
            this.B_Text_Align1.Size = new System.Drawing.Size(42, 39);
            this.B_Text_Align1.TabIndex = 0;
            this.B_Text_Align1.UseVisualStyleBackColor = false;
            this.B_Text_Align1.Click += new System.EventHandler(this.B_Text_Align1_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(27, 149);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(374, 273);
            this.tabControl2.TabIndex = 16;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.CB_Dot_Num);
            this.tabPage3.Controls.Add(this.CB_Flag_Hide_Disp);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.CB_Flag_F_Zero);
            this.tabPage3.Controls.Add(this.CB_All_Num);
            this.tabPage3.Controls.Add(this.CB_Flag_Round);
            this.tabPage3.Controls.Add(this.CB_Flag_Signed);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(366, 239);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "數值";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.CB_Sting_Num);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(366, 239);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "文字";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.RB_Data_Type2);
            this.groupBox7.Controls.Add(this.RB_Data_Type1);
            this.groupBox7.Location = new System.Drawing.Point(27, 74);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(370, 69);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            // 
            // RB_Data_Type1
            // 
            this.RB_Data_Type1.AutoSize = true;
            this.RB_Data_Type1.Location = new System.Drawing.Point(16, 29);
            this.RB_Data_Type1.Name = "RB_Data_Type1";
            this.RB_Data_Type1.Size = new System.Drawing.Size(72, 24);
            this.RB_Data_Type1.TabIndex = 1;
            this.RB_Data_Type1.TabStop = true;
            this.RB_Data_Type1.Text = "數值";
            this.RB_Data_Type1.UseVisualStyleBackColor = true;
            this.RB_Data_Type1.CheckedChanged += new System.EventHandler(this.RB_Data_Type1_CheckedChanged);
            // 
            // RB_Data_Type2
            // 
            this.RB_Data_Type2.AutoSize = true;
            this.RB_Data_Type2.Location = new System.Drawing.Point(133, 30);
            this.RB_Data_Type2.Name = "RB_Data_Type2";
            this.RB_Data_Type2.Size = new System.Drawing.Size(72, 24);
            this.RB_Data_Type2.TabIndex = 2;
            this.RB_Data_Type2.TabStop = true;
            this.RB_Data_Type2.Text = "文字";
            this.RB_Data_Type2.UseVisualStyleBackColor = true;
            this.RB_Data_Type2.CheckedChanged += new System.EventHandler(this.RB_Data_Type2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "最大字數";
            // 
            // CB_Sting_Num
            // 
            this.CB_Sting_Num.FormattingEnabled = true;
            this.CB_Sting_Num.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8",
            "10",
            "20",
            "40"});
            this.CB_Sting_Num.Location = new System.Drawing.Point(129, 23);
            this.CB_Sting_Num.Name = "CB_Sting_Num";
            this.CB_Sting_Num.Size = new System.Drawing.Size(121, 28);
            this.CB_Sting_Num.TabIndex = 3;
            this.CB_Sting_Num.Text = "10";
            // 
            // TForm_HMI_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 626);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_HMI_Edit";
            this.Text = "TForm_HMI_Edit";
            this.Shown += new System.EventHandler(this.TForm_HMI_Edit_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton RB_Lock_Type2;
        private System.Windows.Forms.RadioButton RB_Lock_Type1;
        private System.Windows.Forms.CheckBox CB_Lock_Switch;
        private System.Windows.Forms.TextBox E_Lock_Device;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.CheckBox CB_Flag_Hide_Disp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_Num_Data_Type2;
        private System.Windows.Forms.RadioButton RB_Num_Data_Type1;
        private System.Windows.Forms.CheckBox CB_Flag_Round;
        private System.Windows.Forms.CheckBox CB_Flag_Signed;
        private System.Windows.Forms.CheckBox CB_Flag_F_Zero;
        private System.Windows.Forms.ComboBox CB_Dot_Num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_All_Num;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox E_Disp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button B_Status_Font_Color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button B_Status_Font;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_Status_Color;
        private System.Windows.Forms.Button B_Status_Picture;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button B_Text_Align3;
        private System.Windows.Forms.Button B_Text_Align2;
        private System.Windows.Forms.Button B_Text_Align1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton RB_Data_Type2;
        private System.Windows.Forms.RadioButton RB_Data_Type1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox CB_Sting_Num;
        private System.Windows.Forms.Label label7;
    }
}