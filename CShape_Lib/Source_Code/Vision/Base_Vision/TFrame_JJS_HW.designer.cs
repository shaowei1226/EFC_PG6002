namespace EFC.Vision.Halcon
{
    partial class TFrame_JJS_HW
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFrame_JJS_HW));
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_System = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_Wheel = new System.Windows.Forms.Button();
            this.B_Move = new System.Windows.Forms.Button();
            this.B_Space1 = new System.Windows.Forms.Button();
            this.B_Zoom_X1 = new System.Windows.Forms.Button();
            this.B_Fit = new System.Windows.Forms.Button();
            this.B_Zoom_X10 = new System.Windows.Forms.Button();
            this.B_Zoom_Window = new System.Windows.Forms.Button();
            this.B_Zoom_Out = new System.Windows.Forms.Button();
            this.B_Zoom_In = new System.Windows.Forms.Button();
            this.B_None = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Disp_Panel = new System.Windows.Forms.Panel();
            this.HW = new HalconDotNet.HWindowControl();
            this.HW_Buf = new HalconDotNet.HWindowControl();
            this.ScrollBar_H = new System.Windows.Forms.VScrollBar();
            this.ScrollBar_V = new System.Windows.Forms.HScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TStatus_01 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TStatus_02 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TStatus_03 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TStatus_04 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TStatus_05 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TStatus_06 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Disp_Panel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SaddleBrown;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.B_System);
            this.panel1.Controls.Add(this.B_Wheel);
            this.panel1.Controls.Add(this.B_Move);
            this.panel1.Controls.Add(this.B_Space1);
            this.panel1.Controls.Add(this.B_Zoom_X1);
            this.panel1.Controls.Add(this.B_Fit);
            this.panel1.Controls.Add(this.B_Zoom_X10);
            this.panel1.Controls.Add(this.B_Zoom_Window);
            this.panel1.Controls.Add(this.B_Zoom_Out);
            this.panel1.Controls.Add(this.B_Zoom_In);
            this.panel1.Controls.Add(this.B_None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 54);
            this.panel1.TabIndex = 1;
            // 
            // B_System
            // 
            this.B_System.BackColor = System.Drawing.Color.DimGray;
            this.B_System.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_System.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_System.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_System.ImageList = this.imageList1;
            this.B_System.Location = new System.Drawing.Point(535, 0);
            this.B_System.Name = "B_System";
            this.B_System.Size = new System.Drawing.Size(50, 50);
            this.B_System.TabIndex = 11;
            this.toolTip1.SetToolTip(this.B_System, "None");
            this.B_System.UseVisualStyleBackColor = false;
            this.B_System.Click += new System.EventHandler(this.B_System_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "111.bmp");
            this.imageList1.Images.SetKeyName(1, "Hand2.bmp");
            this.imageList1.Images.SetKeyName(2, "62.bmp");
            this.imageList1.Images.SetKeyName(3, "63.bmp");
            this.imageList1.Images.SetKeyName(4, "205.bmp");
            this.imageList1.Images.SetKeyName(5, "088.bmp");
            this.imageList1.Images.SetKeyName(6, "206.bmp");
            this.imageList1.Images.SetKeyName(7, "wheel.bmp");
            this.imageList1.Images.SetKeyName(8, "Select_64x64.png");
            // 
            // B_Wheel
            // 
            this.B_Wheel.BackColor = System.Drawing.Color.DimGray;
            this.B_Wheel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Wheel.ImageIndex = 7;
            this.B_Wheel.ImageList = this.imageList1;
            this.B_Wheel.Location = new System.Drawing.Point(413, 0);
            this.B_Wheel.Name = "B_Wheel";
            this.B_Wheel.Size = new System.Drawing.Size(50, 50);
            this.B_Wheel.TabIndex = 7;
            this.toolTip1.SetToolTip(this.B_Wheel, "Zoom Wheel");
            this.B_Wheel.UseVisualStyleBackColor = false;
            this.B_Wheel.Click += new System.EventHandler(this.B_Wheel_Click);
            // 
            // B_Move
            // 
            this.B_Move.BackColor = System.Drawing.Color.DimGray;
            this.B_Move.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_Move.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Move.ImageIndex = 1;
            this.B_Move.ImageList = this.imageList1;
            this.B_Move.Location = new System.Drawing.Point(363, 0);
            this.B_Move.Name = "B_Move";
            this.B_Move.Size = new System.Drawing.Size(50, 50);
            this.B_Move.TabIndex = 1;
            this.toolTip1.SetToolTip(this.B_Move, "Move");
            this.B_Move.UseVisualStyleBackColor = false;
            this.B_Move.Click += new System.EventHandler(this.B_Move_Click);
            // 
            // B_Space1
            // 
            this.B_Space1.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Space1.Location = new System.Drawing.Point(350, 0);
            this.B_Space1.Name = "B_Space1";
            this.B_Space1.Size = new System.Drawing.Size(13, 50);
            this.B_Space1.TabIndex = 10;
            this.B_Space1.UseVisualStyleBackColor = true;
            // 
            // B_Zoom_X1
            // 
            this.B_Zoom_X1.BackColor = System.Drawing.Color.DimGray;
            this.B_Zoom_X1.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Zoom_X1.ImageIndex = 6;
            this.B_Zoom_X1.ImageList = this.imageList1;
            this.B_Zoom_X1.Location = new System.Drawing.Point(300, 0);
            this.B_Zoom_X1.Name = "B_Zoom_X1";
            this.B_Zoom_X1.Size = new System.Drawing.Size(50, 50);
            this.B_Zoom_X1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.B_Zoom_X1, "Zoom X1");
            this.B_Zoom_X1.UseVisualStyleBackColor = false;
            this.B_Zoom_X1.Click += new System.EventHandler(this.B_Zoom_X1_Click);
            // 
            // B_Fit
            // 
            this.B_Fit.BackColor = System.Drawing.Color.DimGray;
            this.B_Fit.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Fit.ImageIndex = 4;
            this.B_Fit.ImageList = this.imageList1;
            this.B_Fit.Location = new System.Drawing.Point(250, 0);
            this.B_Fit.Name = "B_Fit";
            this.B_Fit.Size = new System.Drawing.Size(50, 50);
            this.B_Fit.TabIndex = 4;
            this.toolTip1.SetToolTip(this.B_Fit, "Zoom Fit");
            this.B_Fit.UseVisualStyleBackColor = false;
            this.B_Fit.Click += new System.EventHandler(this.B_Fit_Click);
            // 
            // B_Zoom_X10
            // 
            this.B_Zoom_X10.BackColor = System.Drawing.Color.DimGray;
            this.B_Zoom_X10.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Zoom_X10.ImageIndex = 5;
            this.B_Zoom_X10.ImageList = this.imageList1;
            this.B_Zoom_X10.Location = new System.Drawing.Point(200, 0);
            this.B_Zoom_X10.Name = "B_Zoom_X10";
            this.B_Zoom_X10.Size = new System.Drawing.Size(50, 50);
            this.B_Zoom_X10.TabIndex = 5;
            this.toolTip1.SetToolTip(this.B_Zoom_X10, "Zoom X10");
            this.B_Zoom_X10.UseVisualStyleBackColor = false;
            this.B_Zoom_X10.Click += new System.EventHandler(this.B_Zoom_X10_Click);
            // 
            // B_Zoom_Window
            // 
            this.B_Zoom_Window.BackColor = System.Drawing.Color.DimGray;
            this.B_Zoom_Window.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Zoom_Window.ImageIndex = 8;
            this.B_Zoom_Window.ImageList = this.imageList1;
            this.B_Zoom_Window.Location = new System.Drawing.Point(150, 0);
            this.B_Zoom_Window.Name = "B_Zoom_Window";
            this.B_Zoom_Window.Size = new System.Drawing.Size(50, 50);
            this.B_Zoom_Window.TabIndex = 9;
            this.toolTip1.SetToolTip(this.B_Zoom_Window, "Zoom Windows");
            this.B_Zoom_Window.UseVisualStyleBackColor = false;
            this.B_Zoom_Window.Click += new System.EventHandler(this.B_Zoom_Window_Click);
            // 
            // B_Zoom_Out
            // 
            this.B_Zoom_Out.BackColor = System.Drawing.Color.DimGray;
            this.B_Zoom_Out.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Zoom_Out.ImageIndex = 3;
            this.B_Zoom_Out.ImageList = this.imageList1;
            this.B_Zoom_Out.Location = new System.Drawing.Point(100, 0);
            this.B_Zoom_Out.Name = "B_Zoom_Out";
            this.B_Zoom_Out.Size = new System.Drawing.Size(50, 50);
            this.B_Zoom_Out.TabIndex = 3;
            this.toolTip1.SetToolTip(this.B_Zoom_Out, "Zoom Out");
            this.B_Zoom_Out.UseVisualStyleBackColor = false;
            this.B_Zoom_Out.Click += new System.EventHandler(this.B_Zoom_Out_Click);
            // 
            // B_Zoom_In
            // 
            this.B_Zoom_In.BackColor = System.Drawing.Color.DimGray;
            this.B_Zoom_In.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Zoom_In.ImageIndex = 2;
            this.B_Zoom_In.ImageList = this.imageList1;
            this.B_Zoom_In.Location = new System.Drawing.Point(50, 0);
            this.B_Zoom_In.Name = "B_Zoom_In";
            this.B_Zoom_In.Size = new System.Drawing.Size(50, 50);
            this.B_Zoom_In.TabIndex = 2;
            this.toolTip1.SetToolTip(this.B_Zoom_In, "Zoom In");
            this.B_Zoom_In.UseVisualStyleBackColor = false;
            this.B_Zoom_In.Click += new System.EventHandler(this.B_Zoom_In_Click);
            // 
            // B_None
            // 
            this.B_None.BackColor = System.Drawing.Color.DimGray;
            this.B_None.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_None.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_None.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.B_None.ImageList = this.imageList1;
            this.B_None.Location = new System.Drawing.Point(0, 0);
            this.B_None.Name = "B_None";
            this.B_None.Size = new System.Drawing.Size(50, 50);
            this.B_None.TabIndex = 8;
            this.toolTip1.SetToolTip(this.B_None, "None");
            this.B_None.UseVisualStyleBackColor = false;
            this.B_None.Click += new System.EventHandler(this.B_None_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Disp_Panel);
            this.panel2.Controls.Add(this.ScrollBar_H);
            this.panel2.Controls.Add(this.ScrollBar_V);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 383);
            this.panel2.TabIndex = 2;
            // 
            // Disp_Panel
            // 
            this.Disp_Panel.Controls.Add(this.HW);
            this.Disp_Panel.Controls.Add(this.HW_Buf);
            this.Disp_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Disp_Panel.Location = new System.Drawing.Point(0, 0);
            this.Disp_Panel.Name = "Disp_Panel";
            this.Disp_Panel.Size = new System.Drawing.Size(564, 358);
            this.Disp_Panel.TabIndex = 6;
            this.Disp_Panel.Resize += new System.EventHandler(this.Disp_Panel_Resize);
            // 
            // HW
            // 
            this.HW.BackColor = System.Drawing.Color.Black;
            this.HW.BorderColor = System.Drawing.Color.Black;
            this.HW.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.HW.Location = new System.Drawing.Point(20, 20);
            this.HW.Name = "HW";
            this.HW.Size = new System.Drawing.Size(41, 38);
            this.HW.TabIndex = 3;
            this.HW.WindowSize = new System.Drawing.Size(41, 38);
            this.HW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HW_KeyDown);
            this.HW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HW_KeyPress);
            this.HW.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HW_KeyUp);
            this.HW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HW_MouseDown);
            this.HW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HW_MouseMove);
            this.HW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HW_MouseUp);
            // 
            // HW_Buf
            // 
            this.HW_Buf.BackColor = System.Drawing.Color.Black;
            this.HW_Buf.BorderColor = System.Drawing.Color.Black;
            this.HW_Buf.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.HW_Buf.Location = new System.Drawing.Point(67, 20);
            this.HW_Buf.Name = "HW_Buf";
            this.HW_Buf.Size = new System.Drawing.Size(45, 38);
            this.HW_Buf.TabIndex = 2;
            this.HW_Buf.Visible = false;
            this.HW_Buf.WindowSize = new System.Drawing.Size(45, 38);
            // 
            // ScrollBar_H
            // 
            this.ScrollBar_H.Dock = System.Windows.Forms.DockStyle.Right;
            this.ScrollBar_H.Location = new System.Drawing.Point(564, 0);
            this.ScrollBar_H.Name = "ScrollBar_H";
            this.ScrollBar_H.Size = new System.Drawing.Size(21, 358);
            this.ScrollBar_H.TabIndex = 5;
            this.ScrollBar_H.ValueChanged += new System.EventHandler(this.ScrollBar_H_ValueChanged);
            // 
            // ScrollBar_V
            // 
            this.ScrollBar_V.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScrollBar_V.Location = new System.Drawing.Point(0, 358);
            this.ScrollBar_V.Name = "ScrollBar_V";
            this.ScrollBar_V.Size = new System.Drawing.Size(585, 21);
            this.ScrollBar_V.TabIndex = 4;
            this.ScrollBar_V.ValueChanged += new System.EventHandler(this.ScrollBar_V_ValueChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Green;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TStatus_01,
            this.TStatus_02,
            this.TStatus_03,
            this.TStatus_04,
            this.TStatus_05,
            this.TStatus_06});
            this.statusStrip1.Location = new System.Drawing.Point(0, 437);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(589, 40);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "WY=123";
            // 
            // TStatus_01
            // 
            this.TStatus_01.AutoSize = false;
            this.TStatus_01.Name = "TStatus_01";
            this.TStatus_01.Size = new System.Drawing.Size(100, 35);
            this.TStatus_01.Text = "X=0.000";
            this.TStatus_01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TStatus_02
            // 
            this.TStatus_02.AutoSize = false;
            this.TStatus_02.Name = "TStatus_02";
            this.TStatus_02.Size = new System.Drawing.Size(100, 35);
            this.TStatus_02.Text = "Y=0.000";
            this.TStatus_02.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TStatus_03
            // 
            this.TStatus_03.Name = "TStatus_03";
            this.TStatus_03.Size = new System.Drawing.Size(48, 35);
            this.TStatus_03.Text = "WX=123";
            this.TStatus_03.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TStatus_04
            // 
            this.TStatus_04.Name = "TStatus_04";
            this.TStatus_04.Size = new System.Drawing.Size(48, 35);
            this.TStatus_04.Text = "WY=123";
            this.TStatus_04.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TStatus_05
            // 
            this.TStatus_05.Name = "TStatus_05";
            this.TStatus_05.Size = new System.Drawing.Size(104, 35);
            this.TStatus_05.Text = "toolStripStatusLabel1";
            // 
            // TStatus_06
            // 
            this.TStatus_06.Name = "TStatus_06";
            this.TStatus_06.Size = new System.Drawing.Size(104, 35);
            this.TStatus_06.Text = "toolStripStatusLabel2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TFrame_JJS_HW
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "TFrame_JJS_HW";
            this.Size = new System.Drawing.Size(589, 477);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.Disp_Panel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Wheel;
        private System.Windows.Forms.Button B_Zoom_X1;
        private System.Windows.Forms.Button B_Zoom_X10;
        private System.Windows.Forms.Button B_Fit;
        private System.Windows.Forms.Button B_Zoom_Out;
        private System.Windows.Forms.Button B_Zoom_In;
        private System.Windows.Forms.Button B_Move;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TStatus_01;
        private System.Windows.Forms.ToolStripStatusLabel TStatus_02;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel TStatus_03;
        private System.Windows.Forms.ToolStripStatusLabel TStatus_04;
        private System.Windows.Forms.Button B_None;
        public System.Windows.Forms.Panel panel2;
        public HalconDotNet.HWindowControl HW_Buf;
        public HalconDotNet.HWindowControl HW;
        private System.Windows.Forms.Panel Disp_Panel;
        private System.Windows.Forms.VScrollBar ScrollBar_H;
        private System.Windows.Forms.HScrollBar ScrollBar_V;
        private System.Windows.Forms.ToolStripStatusLabel TStatus_05;
        private System.Windows.Forms.ToolStripStatusLabel TStatus_06;
        private System.Windows.Forms.Button B_Zoom_Window;
        private System.Windows.Forms.Button B_Space1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button B_System;

    }
}