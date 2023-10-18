namespace EFC.User_Manager
{
    partial class TForm_RFID_Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.E_Password1 = new System.Windows.Forms.TextBox();
            this.L_Change_Password = new System.Windows.Forms.Label();
            this.L_User_Manager = new System.Windows.Forms.Label();
            this.B_Login = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.E_User_ID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_User_Name = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(11, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "名稱(Name)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(11, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "密碼(Password)";
            // 
            // E_Password1
            // 
            this.E_Password1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Password1.Location = new System.Drawing.Point(258, 109);
            this.E_Password1.Name = "E_Password1";
            this.E_Password1.Size = new System.Drawing.Size(221, 35);
            this.E_Password1.TabIndex = 4;
            this.E_Password1.UseSystemPasswordChar = true;
            // 
            // L_Change_Password
            // 
            this.L_Change_Password.AutoSize = true;
            this.L_Change_Password.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L_Change_Password.ForeColor = System.Drawing.Color.Blue;
            this.L_Change_Password.Location = new System.Drawing.Point(42, 399);
            this.L_Change_Password.Name = "L_Change_Password";
            this.L_Change_Password.Size = new System.Drawing.Size(111, 20);
            this.L_Change_Password.TabIndex = 5;
            this.L_Change_Password.Text = "密碼變更...";
            this.L_Change_Password.Click += new System.EventHandler(this.L_Change_Password_Click);
            // 
            // L_User_Manager
            // 
            this.L_User_Manager.AutoSize = true;
            this.L_User_Manager.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L_User_Manager.ForeColor = System.Drawing.Color.Blue;
            this.L_User_Manager.Location = new System.Drawing.Point(42, 431);
            this.L_User_Manager.Name = "L_User_Manager";
            this.L_User_Manager.Size = new System.Drawing.Size(132, 20);
            this.L_User_Manager.TabIndex = 7;
            this.L_User_Manager.Text = "使用者管理...";
            this.L_User_Manager.Click += new System.EventHandler(this.L_User_Manager_Click);
            // 
            // B_Login
            // 
            this.B_Login.BackColor = System.Drawing.Color.Blue;
            this.B_Login.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Login.Location = new System.Drawing.Point(371, 410);
            this.B_Login.Name = "B_Login";
            this.B_Login.Size = new System.Drawing.Size(137, 56);
            this.B_Login.TabIndex = 9;
            this.B_Login.Text = "登入";
            this.B_Login.UseVisualStyleBackColor = false;
            this.B_Login.Click += new System.EventHandler(this.B_Login_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::EFC.User_Manager.Properties.Resources.Login_Mark;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(169, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 203);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(46, 497);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(462, 59);
            this.button1.TabIndex = 11;
            this.button1.Text = "Close Windows";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(11, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(193, 33);
            this.label6.TabIndex = 12;
            this.label6.Text = "識別碼( ID )";
            // 
            // E_User_ID
            // 
            this.E_User_ID.Enabled = false;
            this.E_User_ID.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_User_ID.Location = new System.Drawing.Point(258, 27);
            this.E_User_ID.Name = "E_User_ID";
            this.E_User_ID.Size = new System.Drawing.Size(221, 35);
            this.E_User_ID.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.E_User_Name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.E_User_ID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Password1);
            this.groupBox1.Location = new System.Drawing.Point(29, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 159);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // E_User_Name
            // 
            this.E_User_Name.Enabled = false;
            this.E_User_Name.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_User_Name.Location = new System.Drawing.Point(258, 68);
            this.E_User_Name.Name = "E_User_Name";
            this.E_User_Name.Size = new System.Drawing.Size(221, 35);
            this.E_User_Name.TabIndex = 16;
            // 
            // TForm_RFID_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 567);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.B_Login);
            this.Controls.Add(this.L_User_Manager);
            this.Controls.Add(this.L_Change_Password);
            this.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TForm_RFID_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TForm_RFID_Login";
            this.Shown += new System.EventHandler(this.TForm_Password_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox E_Password1;
        private System.Windows.Forms.Label L_Change_Password;
        private System.Windows.Forms.Label L_User_Manager;
        private System.Windows.Forms.Button B_Login;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox E_User_ID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_User_Name;
    }
}