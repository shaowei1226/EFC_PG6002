namespace EFC.User_Manager
{
    partial class TForm_Change_Password
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
            this.label1 = new System.Windows.Forms.Label();
            this.E_ID = new System.Windows.Forms.TextBox();
            this.E_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Password1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Password2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_Apply = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "識別碼( ID )";
            // 
            // E_ID
            // 
            this.E_ID.Enabled = false;
            this.E_ID.Location = new System.Drawing.Point(268, 39);
            this.E_ID.Name = "E_ID";
            this.E_ID.Size = new System.Drawing.Size(338, 40);
            this.E_ID.TabIndex = 1;
            this.E_ID.Text = "0000-0001";
            // 
            // E_Name
            // 
            this.E_Name.Enabled = false;
            this.E_Name.Location = new System.Drawing.Point(268, 85);
            this.E_Name.Name = "E_Name";
            this.E_Name.Size = new System.Drawing.Size(338, 40);
            this.E_Name.TabIndex = 3;
            this.E_Name.Text = "Operator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "名稱(Name)";
            // 
            // E_Password1
            // 
            this.E_Password1.Location = new System.Drawing.Point(268, 131);
            this.E_Password1.Name = "E_Password1";
            this.E_Password1.Size = new System.Drawing.Size(338, 40);
            this.E_Password1.TabIndex = 5;
            this.E_Password1.Text = "0000-0001";
            this.E_Password1.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "密碼(Password)";
            // 
            // E_Password2
            // 
            this.E_Password2.Location = new System.Drawing.Point(268, 177);
            this.E_Password2.Name = "E_Password2";
            this.E_Password2.Size = new System.Drawing.Size(338, 40);
            this.E_Password2.TabIndex = 7;
            this.E_Password2.Text = "0000-0001";
            this.E_Password2.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "確認(Password)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.E_ID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Name);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_Password2);
            this.groupBox1.Controls.Add(this.E_Password1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 234);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 資訊 ]";
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.Blue;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.Location = new System.Drawing.Point(94, 262);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(194, 59);
            this.B_Apply.TabIndex = 13;
            this.B_Apply.Text = "確定";
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.Blue;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.Location = new System.Drawing.Point(374, 262);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(194, 59);
            this.B_Cancel.TabIndex = 14;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // TForm_Change_Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 330);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Apply);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "TForm_Change_Password";
            this.Text = "TForm_Uset_Edit2";
            this.Shown += new System.EventHandler(this.TForm_Uset_Edit_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Button B_Cancel;
        public System.Windows.Forms.TextBox E_ID;
        public System.Windows.Forms.TextBox E_Name;
        public System.Windows.Forms.TextBox E_Password1;
        public System.Windows.Forms.TextBox E_Password2;
    }
}