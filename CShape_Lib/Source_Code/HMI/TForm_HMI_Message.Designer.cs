namespace EFC.HMI
{
    partial class TForm_HMI_Message
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_HMI_Message));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.B_Status_Font = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.E_Msg_Count = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.E_Device = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.B_Status_Font_Color = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.B_Status_Color = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.B_Text_Align3 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_Text_Align2 = new System.Windows.Forms.Button();
            this.B_Text_Align1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.E_Disp = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(730, 432);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(722, 402);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "開關功能";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.B_Status_Font);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(7, 145);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(278, 82);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "[外觀]";
            // 
            // B_Status_Font
            // 
            this.B_Status_Font.Font = new System.Drawing.Font("新細明體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Status_Font.Location = new System.Drawing.Point(81, 30);
            this.B_Status_Font.Name = "B_Status_Font";
            this.B_Status_Font.Size = new System.Drawing.Size(189, 29);
            this.B_Status_Font.TabIndex = 12;
            this.B_Status_Font.Text = "...";
            this.B_Status_Font.UseVisualStyleBackColor = true;
            this.B_Status_Font.Click += new System.EventHandler(this.B_Status_Font_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "字型";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.E_Msg_Count);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.E_Device);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(278, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[開關]";
            // 
            // E_Msg_Count
            // 
            this.E_Msg_Count.Location = new System.Drawing.Point(210, 74);
            this.E_Msg_Count.Name = "E_Msg_Count";
            this.E_Msg_Count.Size = new System.Drawing.Size(49, 27);
            this.E_Msg_Count.TabIndex = 3;
            this.E_Msg_Count.Text = "16";
            this.E_Msg_Count.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.E_Msg_Count.TextChanged += new System.EventHandler(this.E_Msg_Count_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "訊息數量";
            // 
            // E_Device
            // 
            this.E_Device.Location = new System.Drawing.Point(140, 37);
            this.E_Device.Name = "E_Device";
            this.E_Device.Size = new System.Drawing.Size(119, 27);
            this.E_Device.TabIndex = 1;
            this.E_Device.Text = "X0000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "PLC位置";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(722, 402);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "訊息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 80);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(722, 322);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No.";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Message";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 500;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(722, 80);
            this.panel3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 29);
            this.button1.TabIndex = 13;
            this.button1.Text = "All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.B_Status_Font_Color);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.B_Status_Color);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(174, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 66);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // B_Status_Font_Color
            // 
            this.B_Status_Font_Color.Location = new System.Drawing.Point(107, 20);
            this.B_Status_Font_Color.Name = "B_Status_Font_Color";
            this.B_Status_Font_Color.Size = new System.Drawing.Size(34, 29);
            this.B_Status_Font_Color.TabIndex = 14;
            this.B_Status_Font_Color.UseVisualStyleBackColor = true;
            this.B_Status_Font_Color.Click += new System.EventHandler(this.B_Status_Font_Color_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "文字顏色";
            // 
            // B_Status_Color
            // 
            this.B_Status_Color.Location = new System.Drawing.Point(261, 20);
            this.B_Status_Color.Name = "B_Status_Color";
            this.B_Status_Color.Size = new System.Drawing.Size(35, 29);
            this.B_Status_Color.TabIndex = 9;
            this.B_Status_Color.UseVisualStyleBackColor = true;
            this.B_Status_Color.Click += new System.EventHandler(this.B_Status_Color_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(161, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "背景顏色";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.B_Text_Align3);
            this.groupBox6.Controls.Add(this.B_Text_Align2);
            this.groupBox6.Controls.Add(this.B_Text_Align1);
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(158, 66);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            // 
            // B_Text_Align3
            // 
            this.B_Text_Align3.ImageIndex = 2;
            this.B_Text_Align3.ImageList = this.imageList1;
            this.B_Text_Align3.Location = new System.Drawing.Point(105, 21);
            this.B_Text_Align3.Name = "B_Text_Align3";
            this.B_Text_Align3.Size = new System.Drawing.Size(42, 39);
            this.B_Text_Align3.TabIndex = 2;
            this.B_Text_Align3.UseVisualStyleBackColor = true;
            this.B_Text_Align3.Click += new System.EventHandler(this.B_Text_Align3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "paragraph_400px_1157280_easyicon.net.png");
            this.imageList1.Images.SetKeyName(1, "paragraph_400px_1157284_easyicon.net.png");
            this.imageList1.Images.SetKeyName(2, "paragraph_400px_1157279_easyicon.net.png");
            // 
            // B_Text_Align2
            // 
            this.B_Text_Align2.ImageIndex = 1;
            this.B_Text_Align2.ImageList = this.imageList1;
            this.B_Text_Align2.Location = new System.Drawing.Point(57, 21);
            this.B_Text_Align2.Name = "B_Text_Align2";
            this.B_Text_Align2.Size = new System.Drawing.Size(42, 39);
            this.B_Text_Align2.TabIndex = 1;
            this.B_Text_Align2.UseVisualStyleBackColor = true;
            this.B_Text_Align2.Click += new System.EventHandler(this.B_Text_Align2_Click);
            // 
            // B_Text_Align1
            // 
            this.B_Text_Align1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.B_Text_Align1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.B_Text_Align1.ImageIndex = 0;
            this.B_Text_Align1.ImageList = this.imageList1;
            this.B_Text_Align1.Location = new System.Drawing.Point(9, 21);
            this.B_Text_Align1.Name = "B_Text_Align1";
            this.B_Text_Align1.Size = new System.Drawing.Size(42, 39);
            this.B_Text_Align1.TabIndex = 0;
            this.B_Text_Align1.UseVisualStyleBackColor = false;
            this.B_Text_Align1.Click += new System.EventHandler(this.B_Text_Align1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 526);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 100);
            this.panel1.TabIndex = 8;
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
            this.panel2.Controls.Add(this.E_Disp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 82);
            this.panel2.TabIndex = 9;
            // 
            // E_Disp
            // 
            this.E_Disp.Location = new System.Drawing.Point(8, 8);
            this.E_Disp.Name = "E_Disp";
            this.E_Disp.Size = new System.Drawing.Size(100, 27);
            this.E_Disp.TabIndex = 0;
            // 
            // TForm_HMI_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 626);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_HMI_Message";
            this.Text = "TForm_HMI_Edit";
            this.Shown += new System.EventHandler(this.TForm_HMI_Edit_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox E_Device;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox E_Disp;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button B_Status_Font_Color;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button B_Status_Font;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_Status_Color;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button B_Text_Align3;
        private System.Windows.Forms.Button B_Text_Align2;
        private System.Windows.Forms.Button B_Text_Align1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox E_Msg_Count;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}