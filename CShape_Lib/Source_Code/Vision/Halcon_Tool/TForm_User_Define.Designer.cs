namespace EFC.Vision.Halcon
{
    partial class TForm_User_Define
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_User_Define));
            this.panel2 = new System.Windows.Forms.Panel();
            this.E_Command_Name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.P_Cmd_In = new System.Windows.Forms.Panel();
            this.DG_In_Value = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.B_In_Values_Up = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_In_Values_Dn = new System.Windows.Forms.Button();
            this.B_In_Values_Add = new System.Windows.Forms.Button();
            this.B_In_Values_Del = new System.Windows.Forms.Button();
            this.P_Cmd_Out = new System.Windows.Forms.Panel();
            this.DG_Out_Value = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.B_Out_Values_Up = new System.Windows.Forms.Button();
            this.B_Out_Values_Dn = new System.Windows.Forms.Button();
            this.B_Out_Values_Add = new System.Windows.Forms.Button();
            this.B_Out_Values_Del = new System.Windows.Forms.Button();
            this.panel36 = new System.Windows.Forms.Panel();
            this.B_Apply = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.P_Space = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.P_Cmd_In.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_In_Value)).BeginInit();
            this.panel3.SuspendLayout();
            this.P_Cmd_Out.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Out_Value)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.E_Command_Name);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 81);
            this.panel2.TabIndex = 12;
            // 
            // E_Command_Name
            // 
            this.E_Command_Name.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Command_Name.Location = new System.Drawing.Point(167, 18);
            this.E_Command_Name.Name = "E_Command_Name";
            this.E_Command_Name.Size = new System.Drawing.Size(564, 40);
            this.E_Command_Name.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(24, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 28);
            this.label5.TabIndex = 5;
            this.label5.Text = "Command:";
            // 
            // P_Cmd_In
            // 
            this.P_Cmd_In.BackColor = System.Drawing.Color.Silver;
            this.P_Cmd_In.Controls.Add(this.DG_In_Value);
            this.P_Cmd_In.Controls.Add(this.panel3);
            this.P_Cmd_In.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_Cmd_In.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.P_Cmd_In.Location = new System.Drawing.Point(0, 0);
            this.P_Cmd_In.Margin = new System.Windows.Forms.Padding(4);
            this.P_Cmd_In.Name = "P_Cmd_In";
            this.P_Cmd_In.Size = new System.Drawing.Size(743, 310);
            this.P_Cmd_In.TabIndex = 13;
            // 
            // DG_In_Value
            // 
            this.DG_In_Value.AllowUserToAddRows = false;
            this.DG_In_Value.AllowUserToDeleteRows = false;
            this.DG_In_Value.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_In_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_In_Value.Location = new System.Drawing.Point(0, 52);
            this.DG_In_Value.Name = "DG_In_Value";
            this.DG_In_Value.RowTemplate.Height = 27;
            this.DG_In_Value.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_In_Value.Size = new System.Drawing.Size(743, 258);
            this.DG_In_Value.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Peru;
            this.panel3.Controls.Add(this.B_In_Values_Up);
            this.panel3.Controls.Add(this.B_In_Values_Dn);
            this.panel3.Controls.Add(this.B_In_Values_Add);
            this.panel3.Controls.Add(this.B_In_Values_Del);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 52);
            this.panel3.TabIndex = 5;
            // 
            // B_In_Values_Up
            // 
            this.B_In_Values_Up.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_In_Values_Up.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_In_Values_Up.ImageIndex = 0;
            this.B_In_Values_Up.ImageList = this.imageList1;
            this.B_In_Values_Up.Location = new System.Drawing.Point(535, 0);
            this.B_In_Values_Up.Name = "B_In_Values_Up";
            this.B_In_Values_Up.Size = new System.Drawing.Size(52, 52);
            this.B_In_Values_Up.TabIndex = 3;
            this.B_In_Values_Up.UseVisualStyleBackColor = true;
            this.B_In_Values_Up.Click += new System.EventHandler(this.B_In_Values_Up_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Up_64x64.png");
            this.imageList1.Images.SetKeyName(1, "Down_64x64.png");
            this.imageList1.Images.SetKeyName(2, "Add.png");
            this.imageList1.Images.SetKeyName(3, "Del.png");
            // 
            // B_In_Values_Dn
            // 
            this.B_In_Values_Dn.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_In_Values_Dn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_In_Values_Dn.ImageIndex = 1;
            this.B_In_Values_Dn.ImageList = this.imageList1;
            this.B_In_Values_Dn.Location = new System.Drawing.Point(587, 0);
            this.B_In_Values_Dn.Name = "B_In_Values_Dn";
            this.B_In_Values_Dn.Size = new System.Drawing.Size(52, 52);
            this.B_In_Values_Dn.TabIndex = 4;
            this.B_In_Values_Dn.UseVisualStyleBackColor = true;
            this.B_In_Values_Dn.Click += new System.EventHandler(this.B_In_Values_Dn_Click);
            // 
            // B_In_Values_Add
            // 
            this.B_In_Values_Add.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_In_Values_Add.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_In_Values_Add.ImageIndex = 2;
            this.B_In_Values_Add.ImageList = this.imageList1;
            this.B_In_Values_Add.Location = new System.Drawing.Point(639, 0);
            this.B_In_Values_Add.Name = "B_In_Values_Add";
            this.B_In_Values_Add.Size = new System.Drawing.Size(52, 52);
            this.B_In_Values_Add.TabIndex = 0;
            this.B_In_Values_Add.UseVisualStyleBackColor = true;
            this.B_In_Values_Add.Click += new System.EventHandler(this.B_In_Values_Add_Click);
            // 
            // B_In_Values_Del
            // 
            this.B_In_Values_Del.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_In_Values_Del.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_In_Values_Del.ImageIndex = 3;
            this.B_In_Values_Del.ImageList = this.imageList1;
            this.B_In_Values_Del.Location = new System.Drawing.Point(691, 0);
            this.B_In_Values_Del.Name = "B_In_Values_Del";
            this.B_In_Values_Del.Size = new System.Drawing.Size(52, 52);
            this.B_In_Values_Del.TabIndex = 2;
            this.B_In_Values_Del.UseVisualStyleBackColor = true;
            this.B_In_Values_Del.Click += new System.EventHandler(this.B_In_Values_Del_Click);
            // 
            // P_Cmd_Out
            // 
            this.P_Cmd_Out.BackColor = System.Drawing.Color.Silver;
            this.P_Cmd_Out.Controls.Add(this.DG_Out_Value);
            this.P_Cmd_Out.Controls.Add(this.panel4);
            this.P_Cmd_Out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Cmd_Out.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.P_Cmd_Out.Location = new System.Drawing.Point(0, 320);
            this.P_Cmd_Out.Margin = new System.Windows.Forms.Padding(4);
            this.P_Cmd_Out.Name = "P_Cmd_Out";
            this.P_Cmd_Out.Size = new System.Drawing.Size(743, 328);
            this.P_Cmd_Out.TabIndex = 15;
            // 
            // DG_Out_Value
            // 
            this.DG_Out_Value.AllowUserToAddRows = false;
            this.DG_Out_Value.AllowUserToDeleteRows = false;
            this.DG_Out_Value.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Out_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_Out_Value.Location = new System.Drawing.Point(0, 52);
            this.DG_Out_Value.Name = "DG_Out_Value";
            this.DG_Out_Value.RowTemplate.Height = 27;
            this.DG_Out_Value.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_Out_Value.Size = new System.Drawing.Size(743, 276);
            this.DG_Out_Value.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Peru;
            this.panel4.Controls.Add(this.B_Out_Values_Up);
            this.panel4.Controls.Add(this.B_Out_Values_Dn);
            this.panel4.Controls.Add(this.B_Out_Values_Add);
            this.panel4.Controls.Add(this.B_Out_Values_Del);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(743, 52);
            this.panel4.TabIndex = 6;
            // 
            // B_Out_Values_Up
            // 
            this.B_Out_Values_Up.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Out_Values_Up.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Out_Values_Up.ImageIndex = 0;
            this.B_Out_Values_Up.ImageList = this.imageList1;
            this.B_Out_Values_Up.Location = new System.Drawing.Point(535, 0);
            this.B_Out_Values_Up.Name = "B_Out_Values_Up";
            this.B_Out_Values_Up.Size = new System.Drawing.Size(52, 52);
            this.B_Out_Values_Up.TabIndex = 3;
            this.B_Out_Values_Up.UseVisualStyleBackColor = true;
            this.B_Out_Values_Up.Click += new System.EventHandler(this.B_Out_Values_Up_Click);
            // 
            // B_Out_Values_Dn
            // 
            this.B_Out_Values_Dn.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Out_Values_Dn.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Out_Values_Dn.ImageIndex = 1;
            this.B_Out_Values_Dn.ImageList = this.imageList1;
            this.B_Out_Values_Dn.Location = new System.Drawing.Point(587, 0);
            this.B_Out_Values_Dn.Name = "B_Out_Values_Dn";
            this.B_Out_Values_Dn.Size = new System.Drawing.Size(52, 52);
            this.B_Out_Values_Dn.TabIndex = 4;
            this.B_Out_Values_Dn.UseVisualStyleBackColor = true;
            this.B_Out_Values_Dn.Click += new System.EventHandler(this.B_Out_Values_Dn_Click);
            // 
            // B_Out_Values_Add
            // 
            this.B_Out_Values_Add.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Out_Values_Add.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Out_Values_Add.ImageIndex = 2;
            this.B_Out_Values_Add.ImageList = this.imageList1;
            this.B_Out_Values_Add.Location = new System.Drawing.Point(639, 0);
            this.B_Out_Values_Add.Name = "B_Out_Values_Add";
            this.B_Out_Values_Add.Size = new System.Drawing.Size(52, 52);
            this.B_Out_Values_Add.TabIndex = 0;
            this.B_Out_Values_Add.UseVisualStyleBackColor = true;
            this.B_Out_Values_Add.Click += new System.EventHandler(this.B_Out_Values_Add_Click);
            // 
            // B_Out_Values_Del
            // 
            this.B_Out_Values_Del.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Out_Values_Del.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Out_Values_Del.ImageIndex = 3;
            this.B_Out_Values_Del.ImageList = this.imageList1;
            this.B_Out_Values_Del.Location = new System.Drawing.Point(691, 0);
            this.B_Out_Values_Del.Name = "B_Out_Values_Del";
            this.B_Out_Values_Del.Size = new System.Drawing.Size(52, 52);
            this.B_Out_Values_Del.TabIndex = 2;
            this.B_Out_Values_Del.UseVisualStyleBackColor = true;
            this.B_Out_Values_Del.Click += new System.EventHandler(this.B_Out_Values_Del_Click);
            // 
            // panel36
            // 
            this.panel36.BackColor = System.Drawing.Color.DimGray;
            this.panel36.Controls.Add(this.B_Apply);
            this.panel36.Controls.Add(this.B_Cancel);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel36.Location = new System.Drawing.Point(0, 729);
            this.panel36.Margin = new System.Windows.Forms.Padding(4);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(743, 81);
            this.panel36.TabIndex = 16;
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.White;
            this.B_Apply.Location = new System.Drawing.Point(5, 18);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(4);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(94, 45);
            this.B_Apply.TabIndex = 12;
            this.B_Apply.Text = "套用";
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Location = new System.Drawing.Point(107, 18);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(94, 45);
            this.B_Cancel.TabIndex = 9;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.P_Cmd_Out);
            this.panel1.Controls.Add(this.P_Space);
            this.panel1.Controls.Add(this.P_Cmd_In);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 648);
            this.panel1.TabIndex = 17;
            // 
            // P_Space
            // 
            this.P_Space.BackColor = System.Drawing.Color.Black;
            this.P_Space.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_Space.Location = new System.Drawing.Point(0, 310);
            this.P_Space.Margin = new System.Windows.Forms.Padding(4);
            this.P_Space.Name = "P_Space";
            this.P_Space.Size = new System.Drawing.Size(743, 10);
            this.P_Space.TabIndex = 15;
            // 
            // TForm_User_Define
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 810);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel36);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_User_Define";
            this.Text = "TForm_User_Define";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.P_Cmd_In.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_In_Value)).EndInit();
            this.panel3.ResumeLayout(false);
            this.P_Cmd_Out.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_Out_Value)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel36.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel P_Cmd_In;
        private System.Windows.Forms.Panel P_Cmd_Out;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel P_Space;
        private System.Windows.Forms.Button B_In_Values_Add;
        private System.Windows.Forms.Button B_In_Values_Del;
        private System.Windows.Forms.DataGridView DG_In_Value;
        private System.Windows.Forms.Button B_In_Values_Dn;
        private System.Windows.Forms.Button B_In_Values_Up;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DG_Out_Value;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button B_Out_Values_Up;
        private System.Windows.Forms.Button B_Out_Values_Dn;
        private System.Windows.Forms.Button B_Out_Values_Add;
        private System.Windows.Forms.Button B_Out_Values_Del;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox E_Command_Name;
    }
}