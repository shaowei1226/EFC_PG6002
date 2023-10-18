namespace EFC.User_Manager
{
    partial class TForm_Uset_Edit
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
            this.label1 = new System.Windows.Forms.Label();
            this.E_ID = new System.Windows.Forms.TextBox();
            this.E_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Password1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.E_Password2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.E_Info = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Level = new System.Windows.Forms.ComboBox();
            this.B_Apply = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CB_Type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_Display = new System.Windows.Forms.ComboBox();
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
            this.E_ID.Location = new System.Drawing.Point(268, 39);
            this.E_ID.Name = "E_ID";
            this.E_ID.Size = new System.Drawing.Size(338, 40);
            this.E_ID.TabIndex = 1;
            this.E_ID.Text = "0000-0001";
            // 
            // E_Name
            // 
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "權限(Level)";
            // 
            // E_Info
            // 
            this.E_Info.Location = new System.Drawing.Point(268, 349);
            this.E_Info.Name = "E_Info";
            this.E_Info.Size = new System.Drawing.Size(338, 40);
            this.E_Info.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 28);
            this.label6.TabIndex = 10;
            this.label6.Text = "描述(Info)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_Display);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CB_Type);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CB_Level);
            this.groupBox1.Controls.Add(this.E_ID);
            this.groupBox1.Controls.Add(this.E_Info);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Name);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.E_Password2);
            this.groupBox1.Controls.Add(this.E_Password1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 404);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 資訊 ]";
            // 
            // CB_Level
            // 
            this.CB_Level.FormattingEnabled = true;
            this.CB_Level.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.CB_Level.Location = new System.Drawing.Point(268, 226);
            this.CB_Level.Name = "CB_Level";
            this.CB_Level.Size = new System.Drawing.Size(108, 35);
            this.CB_Level.TabIndex = 12;
            this.CB_Level.Text = "0";
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.Blue;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.Location = new System.Drawing.Point(99, 431);
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
            this.B_Cancel.Location = new System.Drawing.Point(379, 431);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(194, 59);
            this.B_Cancel.TabIndex = 14;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CB_Type
            // 
            this.CB_Type.FormattingEnabled = true;
            this.CB_Type.Items.AddRange(new object[] {
            "User",
            "RFID"});
            this.CB_Type.Location = new System.Drawing.Point(268, 267);
            this.CB_Type.Name = "CB_Type";
            this.CB_Type.Size = new System.Drawing.Size(108, 35);
            this.CB_Type.TabIndex = 14;
            this.CB_Type.Text = "User";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 28);
            this.label7.TabIndex = 13;
            this.label7.Text = "種類(Type)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(178, 28);
            this.label8.TabIndex = 15;
            this.label8.Text = "顯示(Display)";
            // 
            // CB_Display
            // 
            this.CB_Display.FormattingEnabled = true;
            this.CB_Display.Items.AddRange(new object[] {
            "false",
            "true"});
            this.CB_Display.Location = new System.Drawing.Point(268, 308);
            this.CB_Display.Name = "CB_Display";
            this.CB_Display.Size = new System.Drawing.Size(108, 35);
            this.CB_Display.TabIndex = 16;
            this.CB_Display.Text = "true";
            // 
            // TForm_Uset_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 501);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Apply);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "TForm_Uset_Edit";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Button B_Cancel;
        public System.Windows.Forms.TextBox E_ID;
        public System.Windows.Forms.TextBox E_Name;
        public System.Windows.Forms.TextBox E_Password1;
        public System.Windows.Forms.TextBox E_Password2;
        public System.Windows.Forms.TextBox E_Info;
        public System.Windows.Forms.ComboBox CB_Level;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ComboBox CB_Display;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox CB_Type;
        private System.Windows.Forms.Label label7;
    }
}