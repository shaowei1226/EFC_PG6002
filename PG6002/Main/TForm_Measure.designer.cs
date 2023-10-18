namespace EFC.Measure
{
    partial class TForm_Measure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Measure));
            this.CB_CCD_ID = new System.Windows.Forms.ComboBox();
            this.B_P3_Angle = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_P3_Dist = new System.Windows.Forms.Button();
            this.B_P2_Dist = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.panel5 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Clear = new System.Windows.Forms.Button();
            this.B_P1_Point = new System.Windows.Forms.Button();
            this.B_P3_Circle = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_CCD_ID
            // 
            this.CB_CCD_ID.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CB_CCD_ID.FormattingEnabled = true;
            this.CB_CCD_ID.Items.AddRange(new object[] {
            "CCD1",
            "CCD2",
            "CCD3"});
            this.CB_CCD_ID.Location = new System.Drawing.Point(13, 10);
            this.CB_CCD_ID.Margin = new System.Windows.Forms.Padding(2);
            this.CB_CCD_ID.Name = "CB_CCD_ID";
            this.CB_CCD_ID.Size = new System.Drawing.Size(173, 30);
            this.CB_CCD_ID.TabIndex = 28;
            this.CB_CCD_ID.Text = "CCD1";
            this.CB_CCD_ID.SelectedIndexChanged += new System.EventHandler(this.CB_CCD_ID_SelectedIndexChanged);
            // 
            // B_P3_Angle
            // 
            this.B_P3_Angle.BackColor = System.Drawing.Color.White;
            this.B_P3_Angle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_P3_Angle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_P3_Angle.ImageIndex = 2;
            this.B_P3_Angle.ImageList = this.imageList1;
            this.B_P3_Angle.Location = new System.Drawing.Point(219, 7);
            this.B_P3_Angle.Margin = new System.Windows.Forms.Padding(2);
            this.B_P3_Angle.Name = "B_P3_Angle";
            this.B_P3_Angle.Size = new System.Drawing.Size(48, 48);
            this.B_P3_Angle.TabIndex = 9;
            this.B_P3_Angle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_P3_Angle.UseVisualStyleBackColor = false;
            this.B_P3_Angle.Click += new System.EventHandler(this.button4_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Dist.bmp");
            this.imageList1.Images.SetKeyName(1, "Mid_Dist.bmp");
            this.imageList1.Images.SetKeyName(2, "Angle.bmp");
            this.imageList1.Images.SetKeyName(3, "Circle.bmp");
            this.imageList1.Images.SetKeyName(4, "Point.PNG");
            // 
            // B_P3_Dist
            // 
            this.B_P3_Dist.BackColor = System.Drawing.Color.White;
            this.B_P3_Dist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_P3_Dist.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_P3_Dist.ImageIndex = 1;
            this.B_P3_Dist.ImageList = this.imageList1;
            this.B_P3_Dist.Location = new System.Drawing.Point(167, 7);
            this.B_P3_Dist.Margin = new System.Windows.Forms.Padding(2);
            this.B_P3_Dist.Name = "B_P3_Dist";
            this.B_P3_Dist.Size = new System.Drawing.Size(48, 48);
            this.B_P3_Dist.TabIndex = 8;
            this.B_P3_Dist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_P3_Dist.UseVisualStyleBackColor = false;
            this.B_P3_Dist.Click += new System.EventHandler(this.button3_Click);
            // 
            // B_P2_Dist
            // 
            this.B_P2_Dist.BackColor = System.Drawing.Color.White;
            this.B_P2_Dist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_P2_Dist.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_P2_Dist.ImageIndex = 0;
            this.B_P2_Dist.ImageList = this.imageList1;
            this.B_P2_Dist.Location = new System.Drawing.Point(115, 7);
            this.B_P2_Dist.Margin = new System.Windows.Forms.Padding(2);
            this.B_P2_Dist.Name = "B_P2_Dist";
            this.B_P2_Dist.Size = new System.Drawing.Size(48, 48);
            this.B_P2_Dist.TabIndex = 7;
            this.B_P2_Dist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_P2_Dist.UseVisualStyleBackColor = false;
            this.B_P2_Dist.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(11, 7);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "取消";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(804, 586);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tFrame_JJS_HW1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(496, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 586);
            this.panel3.TabIndex = 7;
            // 
            // tFrame_JJS_HW1
            // 
            this.tFrame_JJS_HW1.Disp_Scale = 1D;
            this.tFrame_JJS_HW1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFrame_JJS_HW1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_JJS_HW1.Location = new System.Drawing.Point(0, 0);
            this.tFrame_JJS_HW1.Name = "tFrame_JJS_HW1";
            this.tFrame_JJS_HW1.Only_Window = true;
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(308, 586);
            this.tFrame_JJS_HW1.TabIndex = 2;
            this.tFrame_JJS_HW1.JJS_HW_MouseDown += new System.Windows.Forms.MouseEventHandler(this.tFrame_JJS_HW1_JJS_HW_MouseDown);
            this.tFrame_JJS_HW1.JJS_HW_MouseMove += new System.Windows.Forms.MouseEventHandler(this.tFrame_JJS_HW1_JJS_HW_MouseMove);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.listBox1);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(496, 586);
            this.panel5.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(0, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(496, 473);
            this.listBox1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 113);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.B_P3_Dist);
            this.panel1.Controls.Add(this.B_Clear);
            this.panel1.Controls.Add(this.B_P1_Point);
            this.panel1.Controls.Add(this.B_P2_Dist);
            this.panel1.Controls.Add(this.B_P3_Circle);
            this.panel1.Controls.Add(this.B_P3_Angle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 63);
            this.panel1.TabIndex = 32;
            // 
            // B_Clear
            // 
            this.B_Clear.BackColor = System.Drawing.Color.DarkGray;
            this.B_Clear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Clear.Location = new System.Drawing.Point(382, 4);
            this.B_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(109, 51);
            this.B_Clear.TabIndex = 31;
            this.B_Clear.Text = "清除";
            this.B_Clear.UseVisualStyleBackColor = false;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // B_P1_Point
            // 
            this.B_P1_Point.BackColor = System.Drawing.Color.White;
            this.B_P1_Point.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_P1_Point.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_P1_Point.ImageIndex = 4;
            this.B_P1_Point.ImageList = this.imageList1;
            this.B_P1_Point.Location = new System.Drawing.Point(63, 7);
            this.B_P1_Point.Margin = new System.Windows.Forms.Padding(2);
            this.B_P1_Point.Name = "B_P1_Point";
            this.B_P1_Point.Size = new System.Drawing.Size(48, 48);
            this.B_P1_Point.TabIndex = 30;
            this.B_P1_Point.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_P1_Point.UseVisualStyleBackColor = false;
            this.B_P1_Point.Click += new System.EventHandler(this.B_P1_Click);
            // 
            // B_P3_Circle
            // 
            this.B_P3_Circle.BackColor = System.Drawing.Color.White;
            this.B_P3_Circle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_P3_Circle.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_P3_Circle.ImageIndex = 3;
            this.B_P3_Circle.ImageList = this.imageList1;
            this.B_P3_Circle.Location = new System.Drawing.Point(271, 7);
            this.B_P3_Circle.Margin = new System.Windows.Forms.Padding(2);
            this.B_P3_Circle.Name = "B_P3_Circle";
            this.B_P3_Circle.Size = new System.Drawing.Size(48, 48);
            this.B_P3_Circle.TabIndex = 29;
            this.B_P3_Circle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_P3_Circle.UseVisualStyleBackColor = false;
            this.B_P3_Circle.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.CB_CCD_ID);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(496, 49);
            this.panel6.TabIndex = 33;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TForm_Measure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 586);
            this.Controls.Add(this.panel4);
            this.Name = "TForm_Measure";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TForm_Measure_FormClosed);
            this.Shown += new System.EventHandler(this.TForm_Measure_Shown);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_CCD_ID;
        private System.Windows.Forms.Button B_P3_Angle;
        private System.Windows.Forms.Button B_P3_Dist;
        private System.Windows.Forms.Button B_P2_Dist;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private EFC.Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_P3_Circle;
        private System.Windows.Forms.Button B_P1_Point;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
    }
}