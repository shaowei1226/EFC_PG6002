namespace EFC.Vision.Halcon
{
    partial class TForm_Select_Area
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
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RB_Margin = new System.Windows.Forms.RadioButton();
            this.RB_Fill = new System.Windows.Forms.RadioButton();
            this.B_Max = new System.Windows.Forms.Button();
            this.B_Clear = new System.Windows.Forms.Button();
            this.B_Move = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Mode = new System.Windows.Forms.ComboBox();
            this.B_Select = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB_Delete = new System.Windows.Forms.RadioButton();
            this.RB_Add = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 59);
            this.panel1.TabIndex = 2;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.Image = global::EFC.Vision.Halcon.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(101, 59);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.B_Apply.Size = new System.Drawing.Size(97, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tFrame_JJS_HW1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 554);
            this.panel2.TabIndex = 3;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(198, 0);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(596, 554);
            this.tFrame_JJS_HW1.TabIndex = 3;
            this.tFrame_JJS_HW1.JJS_HW_Reflash += new EFC.Vision.Halcon.evReflash(this.tFrame_JJS_HW1_JJS_HW_Reflash);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.B_Max);
            this.panel3.Controls.Add(this.B_Clear);
            this.panel3.Controls.Add(this.B_Move);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 554);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RB_Margin);
            this.groupBox3.Controls.Add(this.RB_Fill);
            this.groupBox3.Location = new System.Drawing.Point(22, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(150, 47);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "[ Display Mode ]";
            // 
            // RB_Margin
            // 
            this.RB_Margin.AutoSize = true;
            this.RB_Margin.Checked = true;
            this.RB_Margin.Location = new System.Drawing.Point(75, 21);
            this.RB_Margin.Name = "RB_Margin";
            this.RB_Margin.Size = new System.Drawing.Size(57, 16);
            this.RB_Margin.TabIndex = 3;
            this.RB_Margin.TabStop = true;
            this.RB_Margin.Text = "Margin";
            this.RB_Margin.UseVisualStyleBackColor = true;
            this.RB_Margin.CheckedChanged += new System.EventHandler(this.RB_Margin_CheckedChanged);
            // 
            // RB_Fill
            // 
            this.RB_Fill.AutoSize = true;
            this.RB_Fill.Location = new System.Drawing.Point(16, 21);
            this.RB_Fill.Name = "RB_Fill";
            this.RB_Fill.Size = new System.Drawing.Size(38, 16);
            this.RB_Fill.TabIndex = 2;
            this.RB_Fill.Text = "Fill";
            this.RB_Fill.UseVisualStyleBackColor = true;
            this.RB_Fill.CheckedChanged += new System.EventHandler(this.RB_Fill_CheckedChanged);
            // 
            // B_Max
            // 
            this.B_Max.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Max.Location = new System.Drawing.Point(36, 437);
            this.B_Max.Margin = new System.Windows.Forms.Padding(2);
            this.B_Max.Name = "B_Max";
            this.B_Max.Size = new System.Drawing.Size(122, 55);
            this.B_Max.TabIndex = 7;
            this.B_Max.Text = "最大範圍";
            this.B_Max.UseVisualStyleBackColor = true;
            this.B_Max.Click += new System.EventHandler(this.B_Max_Click);
            // 
            // B_Clear
            // 
            this.B_Clear.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Clear.Location = new System.Drawing.Point(36, 14);
            this.B_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(122, 53);
            this.B_Clear.TabIndex = 4;
            this.B_Clear.Text = "清除範圍";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // B_Move
            // 
            this.B_Move.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Move.Location = new System.Drawing.Point(36, 361);
            this.B_Move.Margin = new System.Windows.Forms.Padding(2);
            this.B_Move.Name = "B_Move";
            this.B_Move.Size = new System.Drawing.Size(122, 55);
            this.B_Move.TabIndex = 6;
            this.B_Move.Text = "移動範圍";
            this.B_Move.UseVisualStyleBackColor = true;
            this.B_Move.Click += new System.EventHandler(this.B_Move_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_Mode);
            this.groupBox1.Controls.Add(this.B_Select);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(22, 124);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(150, 224);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // CB_Mode
            // 
            this.CB_Mode.FormattingEnabled = true;
            this.CB_Mode.Items.AddRange(new object[] {
            "Rectangle1",
            "Rectangle2",
            "Circle",
            "DrawEllipse",
            "Polygon",
            "Threshold"});
            this.CB_Mode.Location = new System.Drawing.Point(16, 122);
            this.CB_Mode.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Mode.Name = "CB_Mode";
            this.CB_Mode.Size = new System.Drawing.Size(123, 20);
            this.CB_Mode.TabIndex = 6;
            this.CB_Mode.Text = "Rectangle1";
            // 
            // B_Select
            // 
            this.B_Select.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Select.Location = new System.Drawing.Point(16, 157);
            this.B_Select.Margin = new System.Windows.Forms.Padding(2);
            this.B_Select.Name = "B_Select";
            this.B_Select.Size = new System.Drawing.Size(122, 55);
            this.B_Select.TabIndex = 5;
            this.B_Select.Text = "選取範圍";
            this.B_Select.UseVisualStyleBackColor = true;
            this.B_Select.Click += new System.EventHandler(this.B_Select_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RB_Delete);
            this.groupBox2.Controls.Add(this.RB_Add);
            this.groupBox2.Location = new System.Drawing.Point(16, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(122, 96);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // RB_Delete
            // 
            this.RB_Delete.AutoSize = true;
            this.RB_Delete.Location = new System.Drawing.Point(17, 63);
            this.RB_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Delete.Name = "RB_Delete";
            this.RB_Delete.Size = new System.Drawing.Size(71, 16);
            this.RB_Delete.TabIndex = 1;
            this.RB_Delete.TabStop = true;
            this.RB_Delete.Text = "刪減區域";
            this.RB_Delete.UseVisualStyleBackColor = true;
            // 
            // RB_Add
            // 
            this.RB_Add.AutoSize = true;
            this.RB_Add.Checked = true;
            this.RB_Add.Location = new System.Drawing.Point(18, 29);
            this.RB_Add.Margin = new System.Windows.Forms.Padding(2);
            this.RB_Add.Name = "RB_Add";
            this.RB_Add.Size = new System.Drawing.Size(71, 16);
            this.RB_Add.TabIndex = 0;
            this.RB_Add.TabStop = true;
            this.RB_Add.Text = "增加區域";
            this.RB_Add.UseVisualStyleBackColor = true;
            // 
            // TForm_Select_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 613);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Select_Area";
            this.Text = "TForm_Select_Area";
            this.Shown += new System.EventHandler(this.TForm_Select_Area_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_Max;
        private System.Windows.Forms.Button B_Move;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Select;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB_Delete;
        private System.Windows.Forms.RadioButton RB_Add;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.ComboBox CB_Mode;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RB_Margin;
        private System.Windows.Forms.RadioButton RB_Fill;
        private TFrame_JJS_HW tFrame_JJS_HW1;

    }
}