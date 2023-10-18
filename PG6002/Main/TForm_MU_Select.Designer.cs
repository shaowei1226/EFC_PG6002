namespace Main
{
    partial class TForm_MU_Select
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Used_ToolBar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.B_Used_ToolBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 530);
            this.panel1.TabIndex = 4;
            // 
            // B_Used_ToolBar
            // 
            this.B_Used_ToolBar.BackColor = System.Drawing.Color.OliveDrab;
            this.B_Used_ToolBar.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Used_ToolBar.Location = new System.Drawing.Point(28, 26);
            this.B_Used_ToolBar.Name = "B_Used_ToolBar";
            this.B_Used_ToolBar.Size = new System.Drawing.Size(134, 58);
            this.B_Used_ToolBar.TabIndex = 0;
            this.B_Used_ToolBar.Text = "使用工具列";
            this.B_Used_ToolBar.UseVisualStyleBackColor = false;
            this.B_Used_ToolBar.Click += new System.EventHandler(this.B_Select_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tFrame_JJS_HW1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(208, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(585, 530);
            this.panel3.TabIndex = 5;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(0, 0);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = true;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(585, 530);
            this.tFrame_JJS_HW1.TabIndex = 0;
            this.tFrame_JJS_HW1.JJS_HW_MouseDown += new System.Windows.Forms.MouseEventHandler(this.tFrame_JJS_HW1_JJS_HW_MouseDown);
            this.tFrame_JJS_HW1.JJS_HW_MouseMove += new System.Windows.Forms.MouseEventHandler(this.tFrame_JJS_HW1_JJS_HW_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TForm_MU_Select
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 530);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "TForm_MU_Select";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TForm_MU_Select_FormClosed);
            this.Shown += new System.EventHandler(this.TForm_MU_Select_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer1;
        private EFC.Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Button B_Used_ToolBar;
    }
}