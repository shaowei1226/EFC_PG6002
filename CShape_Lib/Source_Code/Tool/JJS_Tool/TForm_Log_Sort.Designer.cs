namespace EFC.Tool
{
    partial class TForm_Log_Sort
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
            this.CB_Sort_Fun = new System.Windows.Forms.ComboBox();
            this.CB_Sort_Source = new System.Windows.Forms.ComboBox();
            this.CB_Sort_Type = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.B_Apply = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Clear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B_Clear);
            this.groupBox1.Controls.Add(this.CB_Sort_Fun);
            this.groupBox1.Controls.Add(this.CB_Sort_Source);
            this.groupBox1.Controls.Add(this.CB_Sort_Type);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 127);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "過濾條件";
            // 
            // CB_Sort_Fun
            // 
            this.CB_Sort_Fun.FormattingEnabled = true;
            this.CB_Sort_Fun.Location = new System.Drawing.Point(95, 94);
            this.CB_Sort_Fun.Name = "CB_Sort_Fun";
            this.CB_Sort_Fun.Size = new System.Drawing.Size(339, 24);
            this.CB_Sort_Fun.TabIndex = 9;
            // 
            // CB_Sort_Source
            // 
            this.CB_Sort_Source.FormattingEnabled = true;
            this.CB_Sort_Source.Location = new System.Drawing.Point(95, 61);
            this.CB_Sort_Source.Name = "CB_Sort_Source";
            this.CB_Sort_Source.Size = new System.Drawing.Size(339, 24);
            this.CB_Sort_Source.TabIndex = 8;
            // 
            // CB_Sort_Type
            // 
            this.CB_Sort_Type.FormattingEnabled = true;
            this.CB_Sort_Type.Location = new System.Drawing.Point(95, 26);
            this.CB_Sort_Type.Name = "CB_Sort_Type";
            this.CB_Sort_Type.Size = new System.Drawing.Size(121, 24);
            this.CB_Sort_Type.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 16);
            this.label17.TabIndex = 5;
            this.label17.Text = "功能";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 16);
            this.label15.TabIndex = 1;
            this.label15.Text = "種類";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(42, 16);
            this.label16.TabIndex = 3;
            this.label16.Text = "來源";
            // 
            // B_Apply
            // 
            this.B_Apply.Location = new System.Drawing.Point(58, 145);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(127, 60);
            this.B_Apply.TabIndex = 6;
            this.B_Apply.Text = "套用";
            this.B_Apply.UseVisualStyleBackColor = true;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(254, 145);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(127, 60);
            this.B_Cancel.TabIndex = 8;
            this.B_Cancel.Text = "套用";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(327, 18);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(107, 29);
            this.B_Clear.TabIndex = 10;
            this.B_Clear.Text = "清除";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // TForm_Log_Sort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 215);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Apply);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "TForm_Log_Sort";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form_Log_Sort_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_Sort_Type;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.ComboBox CB_Sort_Fun;
        private System.Windows.Forms.ComboBox CB_Sort_Source;
        private System.Windows.Forms.Button B_Clear;
    }
}