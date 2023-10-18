namespace EFC.Vision.Halcon
{
    partial class TForm_Halcon_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Halcon_System));
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_Apply = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TP_Base = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Draw = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Colored = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Line_Width = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TP_Base.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 64);
            this.panel1.TabIndex = 4;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageIndex = 1;
            this.B_Cancel.ImageList = this.imageList1;
            this.B_Cancel.Location = new System.Drawing.Point(122, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(122, 64);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "magic_wand.png");
            this.imageList1.Images.SetKeyName(1, "button_cross.png");
            this.imageList1.Images.SetKeyName(2, "hard_drive_download.png");
            this.imageList1.Images.SetKeyName(3, "hard_drive_upload.png");
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.White;
            this.B_Apply.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.ImageIndex = 0;
            this.B_Apply.ImageList = this.imageList1;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(122, 64);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TP_Base);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 64);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(335, 249);
            this.tabControl1.TabIndex = 5;
            // 
            // TP_Base
            // 
            this.TP_Base.BackColor = System.Drawing.Color.White;
            this.TP_Base.Controls.Add(this.groupBox1);
            this.TP_Base.Location = new System.Drawing.Point(4, 24);
            this.TP_Base.Margin = new System.Windows.Forms.Padding(2);
            this.TP_Base.Name = "TP_Base";
            this.TP_Base.Padding = new System.Windows.Forms.Padding(2);
            this.TP_Base.Size = new System.Drawing.Size(327, 221);
            this.TP_Base.TabIndex = 0;
            this.TP_Base.Text = "基本參數";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CB_Draw);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CB_Colored);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CB_Line_Width);
            this.groupBox1.Location = new System.Drawing.Point(10, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(192, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 環境設定 ]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Draw";
            // 
            // CB_Draw
            // 
            this.CB_Draw.FormattingEnabled = true;
            this.CB_Draw.Items.AddRange(new object[] {
            "fill",
            "margin"});
            this.CB_Draw.Location = new System.Drawing.Point(109, 74);
            this.CB_Draw.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_Draw.Name = "CB_Draw";
            this.CB_Draw.Size = new System.Drawing.Size(75, 22);
            this.CB_Draw.TabIndex = 4;
            this.CB_Draw.Text = "margin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "顏色";
            // 
            // CB_Colored
            // 
            this.CB_Colored.FormattingEnabled = true;
            this.CB_Colored.Items.AddRange(new object[] {
            "3",
            "6",
            "12"});
            this.CB_Colored.Location = new System.Drawing.Point(109, 48);
            this.CB_Colored.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_Colored.Name = "CB_Colored";
            this.CB_Colored.Size = new System.Drawing.Size(75, 22);
            this.CB_Colored.TabIndex = 2;
            this.CB_Colored.Text = "12";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "線寬";
            // 
            // CB_Line_Width
            // 
            this.CB_Line_Width.FormattingEnabled = true;
            this.CB_Line_Width.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.CB_Line_Width.Location = new System.Drawing.Point(109, 22);
            this.CB_Line_Width.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_Line_Width.Name = "CB_Line_Width";
            this.CB_Line_Width.Size = new System.Drawing.Size(75, 22);
            this.CB_Line_Width.TabIndex = 0;
            this.CB_Line_Width.Text = "1";
            // 
            // TForm_Halcon_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 313);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TForm_Halcon_System";
            this.Text = "TForm_Halcon_System";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TP_Base.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TP_Base;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Draw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_Colored;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Line_Width;
    }
}