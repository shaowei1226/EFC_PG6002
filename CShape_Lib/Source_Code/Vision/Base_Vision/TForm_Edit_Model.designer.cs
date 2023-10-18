namespace EFC.Vision.Halcon
{
    partial class TForm_Edit_Model
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Edit_Model));
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Undo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.B_Scale_Zoom_Fit = new System.Windows.Forms.Button();
            this.B_Scale_Zoom_Out = new System.Windows.Forms.Button();
            this.B_Scale_Zoom_In = new System.Windows.Forms.Button();
            this.B_Set_Default = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.HW = new HalconDotNet.HWindowControl();
            this.B_Union = new System.Windows.Forms.Button();
            this.B_Segment = new System.Windows.Forms.Button();
            this.B_Cut_Rect = new System.Windows.Forms.Button();
            this.B_Remove_Point = new System.Windows.Forms.Button();
            this.B_Remove_Rect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.B_Add_Line = new System.Windows.Forms.Button();
            this.B_Center = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_ScaleMax = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CB_Metric = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_ScaleMin = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_AngleExtent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_AngleStart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_NumLevels = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Undo);
            this.panel1.Controls.Add(this.B_Scale_Zoom_Fit);
            this.panel1.Controls.Add(this.B_Scale_Zoom_Out);
            this.panel1.Controls.Add(this.B_Scale_Zoom_In);
            this.panel1.Controls.Add(this.B_Set_Default);
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 59);
            this.panel1.TabIndex = 3;
            // 
            // B_Undo
            // 
            this.B_Undo.BackColor = System.Drawing.Color.LightGreen;
            this.B_Undo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Undo.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Undo.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Undo.ImageIndex = 4;
            this.B_Undo.ImageList = this.imageList1;
            this.B_Undo.Location = new System.Drawing.Point(422, 0);
            this.B_Undo.Margin = new System.Windows.Forms.Padding(2);
            this.B_Undo.Name = "B_Undo";
            this.B_Undo.Size = new System.Drawing.Size(58, 59);
            this.B_Undo.TabIndex = 10;
            this.B_Undo.UseVisualStyleBackColor = false;
            this.B_Undo.Click += new System.EventHandler(this.B_Undo_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "wizard_64x64.png");
            this.imageList1.Images.SetKeyName(1, "Zoom_in_64x64.png");
            this.imageList1.Images.SetKeyName(2, "Zoom_out_64x64.png");
            this.imageList1.Images.SetKeyName(3, "zoom_ext_64x64.png");
            this.imageList1.Images.SetKeyName(4, "undo_64x64.png");
            this.imageList1.Images.SetKeyName(5, "Cursor_Select_64x64.png");
            this.imageList1.Images.SetKeyName(6, "cross_hair_64x64.png");
            this.imageList1.Images.SetKeyName(7, "Cut_Rect_64x64.png");
            this.imageList1.Images.SetKeyName(8, "break_64x64.png");
            this.imageList1.Images.SetKeyName(9, "union_64x64.png");
            this.imageList1.Images.SetKeyName(10, "magic_wand.png");
            this.imageList1.Images.SetKeyName(11, "button_cross.png");
            // 
            // B_Scale_Zoom_Fit
            // 
            this.B_Scale_Zoom_Fit.BackColor = System.Drawing.Color.LightGreen;
            this.B_Scale_Zoom_Fit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Scale_Zoom_Fit.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Scale_Zoom_Fit.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Scale_Zoom_Fit.ImageIndex = 3;
            this.B_Scale_Zoom_Fit.ImageList = this.imageList1;
            this.B_Scale_Zoom_Fit.Location = new System.Drawing.Point(364, 0);
            this.B_Scale_Zoom_Fit.Margin = new System.Windows.Forms.Padding(2);
            this.B_Scale_Zoom_Fit.Name = "B_Scale_Zoom_Fit";
            this.B_Scale_Zoom_Fit.Size = new System.Drawing.Size(58, 59);
            this.B_Scale_Zoom_Fit.TabIndex = 9;
            this.B_Scale_Zoom_Fit.UseVisualStyleBackColor = false;
            this.B_Scale_Zoom_Fit.Click += new System.EventHandler(this.B_Scale_Zoom_Fit_Click);
            // 
            // B_Scale_Zoom_Out
            // 
            this.B_Scale_Zoom_Out.BackColor = System.Drawing.Color.LightGreen;
            this.B_Scale_Zoom_Out.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Scale_Zoom_Out.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Scale_Zoom_Out.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Scale_Zoom_Out.ImageIndex = 2;
            this.B_Scale_Zoom_Out.ImageList = this.imageList1;
            this.B_Scale_Zoom_Out.Location = new System.Drawing.Point(306, 0);
            this.B_Scale_Zoom_Out.Margin = new System.Windows.Forms.Padding(2);
            this.B_Scale_Zoom_Out.Name = "B_Scale_Zoom_Out";
            this.B_Scale_Zoom_Out.Size = new System.Drawing.Size(58, 59);
            this.B_Scale_Zoom_Out.TabIndex = 8;
            this.B_Scale_Zoom_Out.UseVisualStyleBackColor = false;
            this.B_Scale_Zoom_Out.Click += new System.EventHandler(this.B_Scale_Zoom_Out_Click);
            // 
            // B_Scale_Zoom_In
            // 
            this.B_Scale_Zoom_In.BackColor = System.Drawing.Color.LightGreen;
            this.B_Scale_Zoom_In.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Scale_Zoom_In.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Scale_Zoom_In.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Scale_Zoom_In.ImageIndex = 1;
            this.B_Scale_Zoom_In.ImageList = this.imageList1;
            this.B_Scale_Zoom_In.Location = new System.Drawing.Point(248, 0);
            this.B_Scale_Zoom_In.Margin = new System.Windows.Forms.Padding(2);
            this.B_Scale_Zoom_In.Name = "B_Scale_Zoom_In";
            this.B_Scale_Zoom_In.Size = new System.Drawing.Size(58, 59);
            this.B_Scale_Zoom_In.TabIndex = 7;
            this.B_Scale_Zoom_In.UseVisualStyleBackColor = false;
            this.B_Scale_Zoom_In.Click += new System.EventHandler(this.B_Scale_Zoom_In_Click);
            // 
            // B_Set_Default
            // 
            this.B_Set_Default.BackColor = System.Drawing.Color.LightGreen;
            this.B_Set_Default.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Set_Default.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Set_Default.ImageIndex = 0;
            this.B_Set_Default.ImageList = this.imageList1;
            this.B_Set_Default.Location = new System.Drawing.Point(192, 0);
            this.B_Set_Default.Margin = new System.Windows.Forms.Padding(2);
            this.B_Set_Default.Name = "B_Set_Default";
            this.B_Set_Default.Size = new System.Drawing.Size(56, 59);
            this.B_Set_Default.TabIndex = 0;
            this.B_Set_Default.UseVisualStyleBackColor = false;
            this.B_Set_Default.Click += new System.EventHandler(this.B_Set_Default_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageIndex = 11;
            this.B_Cancel.ImageList = this.imageList1;
            this.B_Cancel.Location = new System.Drawing.Point(96, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(96, 59);
            this.B_Cancel.TabIndex = 6;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cancel.UseVisualStyleBackColor = false;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Apply
            // 
            this.B_Apply.BackColor = System.Drawing.Color.White;
            this.B_Apply.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Apply.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Apply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Apply.ImageIndex = 10;
            this.B_Apply.ImageList = this.imageList1;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(96, 59);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.HW);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(342, 59);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 541);
            this.panel3.TabIndex = 5;
            // 
            // HW
            // 
            this.HW.BackColor = System.Drawing.Color.Black;
            this.HW.BorderColor = System.Drawing.Color.Black;
            this.HW.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.HW.Location = new System.Drawing.Point(11, 12);
            this.HW.Margin = new System.Windows.Forms.Padding(2);
            this.HW.Name = "HW";
            this.HW.Size = new System.Drawing.Size(272, 235);
            this.HW.TabIndex = 4;
            this.HW.WindowSize = new System.Drawing.Size(272, 235);
            this.HW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HW_MouseDown);
            this.HW.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HW_MouseMove);
            // 
            // B_Union
            // 
            this.B_Union.BackColor = System.Drawing.Color.LightGray;
            this.B_Union.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Union.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Union.ImageIndex = 9;
            this.B_Union.ImageList = this.imageList1;
            this.B_Union.Location = new System.Drawing.Point(145, 158);
            this.B_Union.Margin = new System.Windows.Forms.Padding(2);
            this.B_Union.Name = "B_Union";
            this.B_Union.Size = new System.Drawing.Size(120, 68);
            this.B_Union.TabIndex = 4;
            this.B_Union.Text = "連接線段";
            this.B_Union.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Union.UseVisualStyleBackColor = false;
            this.B_Union.Click += new System.EventHandler(this.B_Union_Click);
            // 
            // B_Segment
            // 
            this.B_Segment.BackColor = System.Drawing.Color.LightGray;
            this.B_Segment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Segment.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Segment.ImageIndex = 8;
            this.B_Segment.ImageList = this.imageList1;
            this.B_Segment.Location = new System.Drawing.Point(7, 158);
            this.B_Segment.Margin = new System.Windows.Forms.Padding(2);
            this.B_Segment.Name = "B_Segment";
            this.B_Segment.Size = new System.Drawing.Size(120, 68);
            this.B_Segment.TabIndex = 3;
            this.B_Segment.Text = "打斷線斷";
            this.B_Segment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Segment.UseVisualStyleBackColor = false;
            this.B_Segment.Click += new System.EventHandler(this.B_Segment_Click);
            // 
            // B_Cut_Rect
            // 
            this.B_Cut_Rect.BackColor = System.Drawing.Color.LightGray;
            this.B_Cut_Rect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Cut_Rect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cut_Rect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cut_Rect.ImageIndex = 7;
            this.B_Cut_Rect.ImageList = this.imageList1;
            this.B_Cut_Rect.Location = new System.Drawing.Point(7, 86);
            this.B_Cut_Rect.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cut_Rect.Name = "B_Cut_Rect";
            this.B_Cut_Rect.Size = new System.Drawing.Size(120, 68);
            this.B_Cut_Rect.TabIndex = 5;
            this.B_Cut_Rect.Text = "裁切區域";
            this.B_Cut_Rect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Cut_Rect.UseVisualStyleBackColor = false;
            this.B_Cut_Rect.Click += new System.EventHandler(this.B_Cut_Rect_Click);
            // 
            // B_Remove_Point
            // 
            this.B_Remove_Point.BackColor = System.Drawing.Color.LightGray;
            this.B_Remove_Point.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.B_Remove_Point.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Remove_Point.ImageIndex = 6;
            this.B_Remove_Point.ImageList = this.imageList1;
            this.B_Remove_Point.Location = new System.Drawing.Point(145, 14);
            this.B_Remove_Point.Margin = new System.Windows.Forms.Padding(2);
            this.B_Remove_Point.Name = "B_Remove_Point";
            this.B_Remove_Point.Size = new System.Drawing.Size(120, 68);
            this.B_Remove_Point.TabIndex = 2;
            this.B_Remove_Point.Text = "刪除選取";
            this.B_Remove_Point.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Remove_Point.UseVisualStyleBackColor = false;
            this.B_Remove_Point.Click += new System.EventHandler(this.B_Remove_Point_Click);
            // 
            // B_Remove_Rect
            // 
            this.B_Remove_Rect.BackColor = System.Drawing.Color.LightGray;
            this.B_Remove_Rect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Remove_Rect.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Remove_Rect.ImageIndex = 5;
            this.B_Remove_Rect.ImageList = this.imageList1;
            this.B_Remove_Rect.Location = new System.Drawing.Point(7, 14);
            this.B_Remove_Rect.Margin = new System.Windows.Forms.Padding(2);
            this.B_Remove_Rect.Name = "B_Remove_Rect";
            this.B_Remove_Rect.Size = new System.Drawing.Size(120, 68);
            this.B_Remove_Rect.TabIndex = 1;
            this.B_Remove_Rect.Text = "刪除區域";
            this.B_Remove_Rect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Remove_Rect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Remove_Rect.UseVisualStyleBackColor = false;
            this.B_Remove_Rect.Click += new System.EventHandler(this.B_Remove_Rect_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 541);
            this.panel2.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(342, 495);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tabPage1.Controls.Add(this.B_Add_Line);
            this.tabPage1.Controls.Add(this.B_Remove_Rect);
            this.tabPage1.Controls.Add(this.B_Center);
            this.tabPage1.Controls.Add(this.B_Cut_Rect);
            this.tabPage1.Controls.Add(this.B_Remove_Point);
            this.tabPage1.Controls.Add(this.B_Union);
            this.tabPage1.Controls.Add(this.B_Segment);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(334, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工具";
            // 
            // B_Add_Line
            // 
            this.B_Add_Line.BackColor = System.Drawing.Color.LightGray;
            this.B_Add_Line.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.B_Add_Line.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Add_Line.ImageIndex = 8;
            this.B_Add_Line.ImageList = this.imageList1;
            this.B_Add_Line.Location = new System.Drawing.Point(7, 249);
            this.B_Add_Line.Margin = new System.Windows.Forms.Padding(2);
            this.B_Add_Line.Name = "B_Add_Line";
            this.B_Add_Line.Size = new System.Drawing.Size(120, 68);
            this.B_Add_Line.TabIndex = 8;
            this.B_Add_Line.Text = "增加線段";
            this.B_Add_Line.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Add_Line.UseVisualStyleBackColor = false;
            this.B_Add_Line.Click += new System.EventHandler(this.B_Add_Line_Click);
            // 
            // B_Center
            // 
            this.B_Center.BackColor = System.Drawing.Color.LightGray;
            this.B_Center.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.B_Center.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Center.ImageIndex = 6;
            this.B_Center.ImageList = this.imageList1;
            this.B_Center.Location = new System.Drawing.Point(145, 249);
            this.B_Center.Margin = new System.Windows.Forms.Padding(2);
            this.B_Center.Name = "B_Center";
            this.B_Center.Size = new System.Drawing.Size(120, 68);
            this.B_Center.TabIndex = 7;
            this.B_Center.Text = "設定中心";
            this.B_Center.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Center.UseVisualStyleBackColor = false;
            this.B_Center.Click += new System.EventHandler(this.B_Center_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(334, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "參數";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkCyan;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 46);
            this.panel4.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "編輯工具";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.CB_ScaleMax);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.CB_Metric);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CB_ScaleMin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CB_AngleExtent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CB_AngleStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CB_NumLevels);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(9, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(308, 202);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 標靶新建參數 ]";
            // 
            // CB_ScaleMax
            // 
            this.CB_ScaleMax.FormattingEnabled = true;
            this.CB_ScaleMax.Items.AddRange(new object[] {
            "1",
            "1.1",
            "1.2",
            "1.3",
            "1.4",
            "1.5"});
            this.CB_ScaleMax.Location = new System.Drawing.Point(165, 139);
            this.CB_ScaleMax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_ScaleMax.Name = "CB_ScaleMax";
            this.CB_ScaleMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_ScaleMax.Size = new System.Drawing.Size(128, 22);
            this.CB_ScaleMax.TabIndex = 21;
            this.CB_ScaleMax.Text = "1.1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 143);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 14);
            this.label11.TabIndex = 20;
            this.label11.Text = "Scale Max";
            // 
            // CB_Metric
            // 
            this.CB_Metric.FormattingEnabled = true;
            this.CB_Metric.Items.AddRange(new object[] {
            "use_polarity",
            "ignore_global_polarity",
            "ignore_local_polarity"});
            this.CB_Metric.Location = new System.Drawing.Point(165, 167);
            this.CB_Metric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_Metric.Name = "CB_Metric";
            this.CB_Metric.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_Metric.Size = new System.Drawing.Size(128, 22);
            this.CB_Metric.TabIndex = 19;
            this.CB_Metric.Text = "use_polarity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 18;
            this.label10.Text = "Metric";
            // 
            // CB_ScaleMin
            // 
            this.CB_ScaleMin.FormattingEnabled = true;
            this.CB_ScaleMin.Items.AddRange(new object[] {
            "1",
            "0.9",
            "0.8",
            "0.7",
            "0.6",
            "0.5"});
            this.CB_ScaleMin.Location = new System.Drawing.Point(165, 111);
            this.CB_ScaleMin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_ScaleMin.Name = "CB_ScaleMin";
            this.CB_ScaleMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_ScaleMin.Size = new System.Drawing.Size(128, 22);
            this.CB_ScaleMin.TabIndex = 13;
            this.CB_ScaleMin.Text = "0.9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "Scale Min";
            // 
            // CB_AngleExtent
            // 
            this.CB_AngleExtent.FormattingEnabled = true;
            this.CB_AngleExtent.Items.AddRange(new object[] {
            "0",
            "0.2",
            "0.39",
            "0.79",
            "1.57",
            "3.14"});
            this.CB_AngleExtent.Location = new System.Drawing.Point(165, 83);
            this.CB_AngleExtent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_AngleExtent.Name = "CB_AngleExtent";
            this.CB_AngleExtent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_AngleExtent.Size = new System.Drawing.Size(128, 22);
            this.CB_AngleExtent.TabIndex = 5;
            this.CB_AngleExtent.Text = "0.39";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "搜尋角度";
            // 
            // CB_AngleStart
            // 
            this.CB_AngleStart.FormattingEnabled = true;
            this.CB_AngleStart.Items.AddRange(new object[] {
            "0",
            "-0.2",
            "-0.39",
            "-0.79",
            "-1.57",
            "-3.14"});
            this.CB_AngleStart.Location = new System.Drawing.Point(165, 55);
            this.CB_AngleStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_AngleStart.Name = "CB_AngleStart";
            this.CB_AngleStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_AngleStart.Size = new System.Drawing.Size(128, 22);
            this.CB_AngleStart.TabIndex = 3;
            this.CB_AngleStart.Text = "-0.2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "起始角度";
            // 
            // CB_NumLevels
            // 
            this.CB_NumLevels.FormattingEnabled = true;
            this.CB_NumLevels.Items.AddRange(new object[] {
            "0",
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
            this.CB_NumLevels.Location = new System.Drawing.Point(165, 27);
            this.CB_NumLevels.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_NumLevels.Name = "CB_NumLevels";
            this.CB_NumLevels.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_NumLevels.Size = new System.Drawing.Size(128, 22);
            this.CB_NumLevels.TabIndex = 1;
            this.CB_NumLevels.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 31);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "NumLevels";
            // 
            // TForm_Edit_Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 600);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_Edit_Model";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.TForm_Edit_Model_Shown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button B_Set_Default;
        private System.Windows.Forms.Button B_Scale_Zoom_Out;
        private System.Windows.Forms.Button B_Scale_Zoom_In;
        private System.Windows.Forms.Button B_Remove_Point;
        private System.Windows.Forms.Button B_Remove_Rect;
        private System.Windows.Forms.Button B_Union;
        private System.Windows.Forms.Button B_Segment;
        private System.Windows.Forms.Button B_Cut_Rect;
        private System.Windows.Forms.Button B_Scale_Zoom_Fit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Undo;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button B_Center;
        public HalconDotNet.HWindowControl HW;
        private System.Windows.Forms.Button B_Add_Line;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox CB_ScaleMax;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox CB_Metric;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox CB_ScaleMin;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox CB_AngleExtent;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox CB_AngleStart;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox CB_NumLevels;
        private System.Windows.Forms.Label label12;

    }
}