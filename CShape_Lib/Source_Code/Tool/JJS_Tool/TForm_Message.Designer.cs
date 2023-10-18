namespace EFC.Tool
{
    partial class TForm_Message
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.B_Main_Caption = new System.Windows.Forms.Button();
            this.B_Close = new System.Windows.Forms.Button();
            this.E_Schedule = new System.Windows.Forms.TextBox();
            this.L_Sub_Caption = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // B_Main_Caption
            // 
            this.B_Main_Caption.Dock = System.Windows.Forms.DockStyle.Top;
            this.B_Main_Caption.Font = new System.Drawing.Font("新細明體", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Main_Caption.Location = new System.Drawing.Point(0, 0);
            this.B_Main_Caption.Name = "B_Main_Caption";
            this.B_Main_Caption.Size = new System.Drawing.Size(585, 62);
            this.B_Main_Caption.TabIndex = 1;
            this.B_Main_Caption.Text = "B_Main_Caption";
            this.B_Main_Caption.UseVisualStyleBackColor = true;
            // 
            // B_Close
            // 
            this.B_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.B_Close.Location = new System.Drawing.Point(3, 3);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(571, 68);
            this.B_Close.TabIndex = 8;
            this.B_Close.Text = "關閉";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // E_Schedule
            // 
            this.E_Schedule.Enabled = false;
            this.E_Schedule.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Schedule.Location = new System.Drawing.Point(11, 4);
            this.E_Schedule.Name = "E_Schedule";
            this.E_Schedule.Size = new System.Drawing.Size(51, 33);
            this.E_Schedule.TabIndex = 7;
            this.E_Schedule.Text = "99%";
            this.E_Schedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // L_Sub_Caption
            // 
            this.L_Sub_Caption.AutoSize = true;
            this.L_Sub_Caption.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L_Sub_Caption.Location = new System.Drawing.Point(6, 3);
            this.L_Sub_Caption.Name = "L_Sub_Caption";
            this.L_Sub_Caption.Size = new System.Drawing.Size(164, 24);
            this.L_Sub_Caption.TabIndex = 3;
            this.L_Sub_Caption.Text = "L_Sub_Caption";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 46);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(571, 25);
            this.progressBar1.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 348);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 104);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.L_Sub_Caption);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "進度";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.E_Schedule);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(505, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 43);
            this.panel1.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.B_Close);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(577, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "關閉";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 62);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(585, 286);
            this.listBox1.TabIndex = 10;
            // 
            // TForm_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 452);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.B_Main_Caption);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_Message";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caption";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.TForm_Message_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Main_Caption;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.TextBox E_Schedule;
        private System.Windows.Forms.Label L_Sub_Caption;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;

    }
}