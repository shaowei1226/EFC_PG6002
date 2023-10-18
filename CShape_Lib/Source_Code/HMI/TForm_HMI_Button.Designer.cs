namespace EFC.HMI
{
    partial class TForm_HMI_Button
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_E_Switch_Type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Switch_Device = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.E_Image_Name = new System.Windows.Forms.TextBox();
            this.B_Image_Name = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_Bonder_Shape = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_Light_Switch = new System.Windows.Forms.CheckBox();
            this.E_Light_Device = new System.Windows.Forms.TextBox();
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
            this.tFrame_Status1 = new EFC.HMI.TFrame_Status();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_E_Switch_Type);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Switch_Device);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(289, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[開關]";
            // 
            // CB_E_Switch_Type
            // 
            this.CB_E_Switch_Type.FormattingEnabled = true;
            this.CB_E_Switch_Type.Items.AddRange(new object[] {
            "Bit 設定(ON)",
            "Bit 清除(OFF)",
            "Bit 按鈕",
            "Bit 反向"});
            this.CB_E_Switch_Type.Location = new System.Drawing.Point(140, 86);
            this.CB_E_Switch_Type.Name = "CB_E_Switch_Type";
            this.CB_E_Switch_Type.Size = new System.Drawing.Size(121, 28);
            this.CB_E_Switch_Type.TabIndex = 3;
            this.CB_E_Switch_Type.Text = "Bit 按鈕";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "動作模式";
            // 
            // E_Switch_Device
            // 
            this.E_Switch_Device.Location = new System.Drawing.Point(140, 37);
            this.E_Switch_Device.Name = "E_Switch_Device";
            this.E_Switch_Device.Size = new System.Drawing.Size(119, 31);
            this.E_Switch_Device.TabIndex = 1;
            this.E_Switch_Device.Text = "X0000";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(421, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 494);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.E_Image_Name);
            this.tabPage1.Controls.Add(this.B_Image_Name);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.CB_Bonder_Shape);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "開關功能";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // E_Image_Name
            // 
            this.E_Image_Name.Enabled = false;
            this.E_Image_Name.Location = new System.Drawing.Point(116, 288);
            this.E_Image_Name.Name = "E_Image_Name";
            this.E_Image_Name.Size = new System.Drawing.Size(131, 31);
            this.E_Image_Name.TabIndex = 22;
            this.E_Image_Name.Text = "0";
            // 
            // B_Image_Name
            // 
            this.B_Image_Name.Location = new System.Drawing.Point(253, 288);
            this.B_Image_Name.Name = "B_Image_Name";
            this.B_Image_Name.Size = new System.Drawing.Size(43, 29);
            this.B_Image_Name.TabIndex = 21;
            this.B_Image_Name.Text = "...";
            this.B_Image_Name.UseVisualStyleBackColor = true;
            this.B_Image_Name.Click += new System.EventHandler(this.B_Image_Name_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 292);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "按鈕圖庫";
            // 
            // CB_Bonder_Shape
            // 
            this.CB_Bonder_Shape.FormattingEnabled = true;
            this.CB_Bonder_Shape.Items.AddRange(new object[] {
            "Button_Style",
            "Ellipse_Style",
            "Image_Style"});
            this.CB_Bonder_Shape.Location = new System.Drawing.Point(117, 254);
            this.CB_Bonder_Shape.Name = "CB_Bonder_Shape";
            this.CB_Bonder_Shape.Size = new System.Drawing.Size(179, 28);
            this.CB_Bonder_Shape.TabIndex = 19;
            this.CB_Bonder_Shape.Text = "按鈕形狀";
            this.CB_Bonder_Shape.SelectedValueChanged += new System.EventHandler(this.CB_Bonder_Shape_SelectedValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 257);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "按鈕式樣";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CB_Light_Switch);
            this.groupBox2.Controls.Add(this.E_Light_Device);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(7, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(289, 76);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[指示燈]";
            // 
            // CB_Light_Switch
            // 
            this.CB_Light_Switch.AutoSize = true;
            this.CB_Light_Switch.BackColor = System.Drawing.Color.White;
            this.CB_Light_Switch.Location = new System.Drawing.Point(137, 0);
            this.CB_Light_Switch.Name = "CB_Light_Switch";
            this.CB_Light_Switch.Size = new System.Drawing.Size(136, 24);
            this.CB_Light_Switch.TabIndex = 2;
            this.CB_Light_Switch.Text = "指示燈功能";
            this.CB_Light_Switch.UseVisualStyleBackColor = false;
            // 
            // E_Light_Device
            // 
            this.E_Light_Device.Location = new System.Drawing.Point(140, 32);
            this.E_Light_Device.Name = "E_Light_Device";
            this.E_Light_Device.Size = new System.Drawing.Size(119, 31);
            this.E_Light_Device.TabIndex = 1;
            this.E_Light_Device.Text = "D1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "PLC位置";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(431, 460);
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
            this.RB_Lock_Type2.Text = "當OFF允用";
            this.RB_Lock_Type2.UseVisualStyleBackColor = true;
            // 
            // RB_Lock_Type1
            // 
            this.RB_Lock_Type1.AutoSize = true;
            this.RB_Lock_Type1.Checked = true;
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
            this.E_Lock_Device.Location = new System.Drawing.Point(248, 41);
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
            this.panel1.Location = new System.Drawing.Point(0, 574);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 96);
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
            this.panel2.Size = new System.Drawing.Size(880, 64);
            this.panel2.TabIndex = 2;
            // 
            // tFrame_Status1
            // 
            this.tFrame_Status1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Status1.Location = new System.Drawing.Point(3, 70);
            this.tFrame_Status1.Margin = new System.Windows.Forms.Padding(4);
            this.tFrame_Status1.Name = "tFrame_Status1";
            this.tFrame_Status1.Size = new System.Drawing.Size(411, 497);
            this.tFrame_Status1.TabIndex = 8;
            // 
            // TForm_HMI_Button
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 670);
            this.Controls.Add(this.tFrame_Status1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_HMI_Button";
            this.Text = "TForm_HMI_Button";
            this.Shown += new System.EventHandler(this.TForm_HMI_Button_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_E_Switch_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Switch_Device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CB_Light_Switch;
        private System.Windows.Forms.TextBox E_Light_Device;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox CB_Bonder_Shape;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button B_Image_Name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox E_Image_Name;
        private TFrame_Status tFrame_Status1;
    }
}