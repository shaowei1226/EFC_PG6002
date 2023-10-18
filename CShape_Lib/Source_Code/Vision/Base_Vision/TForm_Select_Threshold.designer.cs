namespace EFC.Vision.Halcon
{
    partial class TForm_Select_Threshold
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SB_Threshold_Max = new System.Windows.Forms.HScrollBar();
            this.E_Threshold_Max = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SB_Threshold_Min = new System.Windows.Forms.HScrollBar();
            this.E_Threshold_Min = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 74);
            this.panel1.TabIndex = 3;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.Image = global::EFC.Vision.Halcon.Properties.Resources.button_cross;
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.Location = new System.Drawing.Point(129, 0);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(135, 74);
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
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(129, 74);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 710);
            this.panel3.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SB_Threshold_Max);
            this.groupBox3.Controls.Add(this.E_Threshold_Max);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.SB_Threshold_Min);
            this.groupBox3.Controls.Add(this.E_Threshold_Min);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(14, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 190);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "參數";
            // 
            // SB_Threshold_Max
            // 
            this.SB_Threshold_Max.Location = new System.Drawing.Point(23, 145);
            this.SB_Threshold_Max.Maximum = 264;
            this.SB_Threshold_Max.Name = "SB_Threshold_Max";
            this.SB_Threshold_Max.Size = new System.Drawing.Size(122, 21);
            this.SB_Threshold_Max.TabIndex = 5;
            this.SB_Threshold_Max.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SB_Threshold_Max_Scroll);
            // 
            // E_Threshold_Max
            // 
            this.E_Threshold_Max.Location = new System.Drawing.Point(171, 139);
            this.E_Threshold_Max.Name = "E_Threshold_Max";
            this.E_Threshold_Max.Size = new System.Drawing.Size(51, 24);
            this.E_Threshold_Max.TabIndex = 4;
            this.E_Threshold_Max.Text = "255";
            this.E_Threshold_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.E_Threshold_Max.TextChanged += new System.EventHandler(this.E_Threshold_Max_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Threshold Max";
            // 
            // SB_Threshold_Min
            // 
            this.SB_Threshold_Min.Location = new System.Drawing.Point(23, 64);
            this.SB_Threshold_Min.Maximum = 264;
            this.SB_Threshold_Min.Name = "SB_Threshold_Min";
            this.SB_Threshold_Min.Size = new System.Drawing.Size(122, 21);
            this.SB_Threshold_Min.TabIndex = 2;
            this.SB_Threshold_Min.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SB_Threshold_Min_Scroll);
            // 
            // E_Threshold_Min
            // 
            this.E_Threshold_Min.Location = new System.Drawing.Point(171, 56);
            this.E_Threshold_Min.Name = "E_Threshold_Min";
            this.E_Threshold_Min.Size = new System.Drawing.Size(51, 24);
            this.E_Threshold_Min.TabIndex = 1;
            this.E_Threshold_Min.Text = "255";
            this.E_Threshold_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.E_Threshold_Min.TextChanged += new System.EventHandler(this.E_Threshold_Min_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Threshold Min";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tFrame_JJS_HW1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1135, 710);
            this.panel2.TabIndex = 4;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(264, 0);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(871, 710);
            this.tFrame_JJS_HW1.TabIndex = 4;
            this.tFrame_JJS_HW1.JJS_HW_Reflash += new EFC.Vision.Halcon.evReflash(this.tFrame_JJS_HW1_JJS_HW_Reflash);
            // 
            // TForm_Select_Threshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 784);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TForm_Select_Threshold";
            this.Text = "TForm_Select_Threshold";
            this.Shown += new System.EventHandler(this.TForm_Select_Threshold_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.HScrollBar SB_Threshold_Max;
        private System.Windows.Forms.TextBox E_Threshold_Max;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar SB_Threshold_Min;
        private System.Windows.Forms.TextBox E_Threshold_Min;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private TFrame_JJS_HW tFrame_JJS_HW1;
    }
}