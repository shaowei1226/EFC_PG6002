namespace EFC.Vision.Halcon
{
    partial class TForm_Input_CMD_Name
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
            this.E_CMD_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_Apply = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // E_CMD_Name
            // 
            this.E_CMD_Name.Location = new System.Drawing.Point(83, 32);
            this.E_CMD_Name.Name = "E_CMD_Name";
            this.E_CMD_Name.Size = new System.Drawing.Size(338, 33);
            this.E_CMD_Name.TabIndex = 5;
            this.E_CMD_Name.Text = "0000-0001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "名稱";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_CMD_Name);
            this.groupBox1.Location = new System.Drawing.Point(26, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 76);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.Blue;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.ForeColor = System.Drawing.Color.White;
            this.B_Apply.Location = new System.Drawing.Point(53, 146);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(144, 59);
            this.B_Apply.TabIndex = 13;
            this.B_Apply.Text = "確定";
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.Blue;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ForeColor = System.Drawing.Color.White;
            this.B_Cancel.Location = new System.Drawing.Point(272, 146);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(144, 59);
            this.B_Cancel.TabIndex = 14;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(128, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "[請輸入密碼]";
            // 
            // TForm_Input_CMD_Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 212);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Apply);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "TForm_Input_CMD_Name";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TForm_Input_CMD_Name";
            this.Shown += new System.EventHandler(this.TForm_Uset_Edit_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Button B_Cancel;
        public System.Windows.Forms.TextBox E_CMD_Name;
        private System.Windows.Forms.Label label1;
    }
}