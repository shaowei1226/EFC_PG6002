namespace EFC.User_Manager
{
    partial class TForm_User_Table_Edit
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.C_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.B_Add = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_RFID_Add = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.B_Edit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.C_Index,
            this.C_ID,
            this.C_Name,
            this.C_Password,
            this.C_Level});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1050, 372);
            this.dataGridView1.TabIndex = 0;
            // 
            // C_Index
            // 
            this.C_Index.HeaderText = "Index";
            this.C_Index.Name = "C_Index";
            // 
            // C_ID
            // 
            this.C_ID.HeaderText = "ID";
            this.C_ID.Name = "C_ID";
            // 
            // C_Name
            // 
            this.C_Name.HeaderText = "Name";
            this.C_Name.Name = "C_Name";
            // 
            // C_Password
            // 
            this.C_Password.HeaderText = "Password";
            this.C_Password.Name = "C_Password";
            // 
            // C_Level
            // 
            this.C_Level.HeaderText = "Level";
            this.C_Level.Name = "C_Level";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.B_Edit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(859, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 372);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B_Add);
            this.groupBox1.Controls.Add(this.B_RFID_Add);
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 132);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "新增";
            // 
            // B_Add
            // 
            this.B_Add.ImageList = this.imageList1;
            this.B_Add.Location = new System.Drawing.Point(16, 26);
            this.B_Add.Name = "B_Add";
            this.B_Add.Size = new System.Drawing.Size(128, 42);
            this.B_Add.TabIndex = 4;
            this.B_Add.Text = "一般使用者";
            this.B_Add.UseVisualStyleBackColor = true;
            this.B_Add.Click += new System.EventHandler(this.B_Add_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // B_RFID_Add
            // 
            this.B_RFID_Add.ImageList = this.imageList1;
            this.B_RFID_Add.Location = new System.Drawing.Point(16, 74);
            this.B_RFID_Add.Name = "B_RFID_Add";
            this.B_RFID_Add.Size = new System.Drawing.Size(128, 42);
            this.B_RFID_Add.TabIndex = 3;
            this.B_RFID_Add.Text = "RFID新增";
            this.B_RFID_Add.UseVisualStyleBackColor = true;
            this.B_RFID_Add.Click += new System.EventHandler(this.B_RFID_Add_Click);
            // 
            // button4
            // 
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(32, 200);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 42);
            this.button4.TabIndex = 2;
            this.button4.Text = "刪除";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // B_Edit
            // 
            this.B_Edit.ImageList = this.imageList1;
            this.B_Edit.Location = new System.Drawing.Point(32, 152);
            this.B_Edit.Name = "B_Edit";
            this.B_Edit.Size = new System.Drawing.Size(128, 42);
            this.B_Edit.TabIndex = 0;
            this.B_Edit.Text = "編輯";
            this.B_Edit.UseVisualStyleBackColor = true;
            this.B_Edit.Click += new System.EventHandler(this.B_Edit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1050, 372);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.B_Cancel);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 372);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1050, 88);
            this.panel3.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(239, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 59);
            this.button1.TabIndex = 12;
            this.button1.Text = "儲存離開";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1050, 372);
            this.panel4.TabIndex = 4;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ForeColor = System.Drawing.Color.White;
            this.B_Cancel.Location = new System.Drawing.Point(496, 17);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(227, 59);
            this.B_Cancel.TabIndex = 13;
            this.B_Cancel.Text = "放棄離開";
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // TForm_User_Table_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 460);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_User_Table_Edit";
            this.Text = "TForm_User_Edit";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn C_Level;
        private System.Windows.Forms.Button B_Edit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button B_RFID_Add;
        private System.Windows.Forms.Button B_Add;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button B_Cancel;
    }
}