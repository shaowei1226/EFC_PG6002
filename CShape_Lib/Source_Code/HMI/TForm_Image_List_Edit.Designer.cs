namespace EFC.HMI
{
    partial class TForm_Image_List_Edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Image_List_Edit));
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MI_Load_Path = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.B_Image_Add_Range = new System.Windows.Forms.Button();
            this.B_Image_Clear = new System.Windows.Forms.Button();
            this.B_Image_Del = new System.Windows.Forms.Button();
            this.B_Image_Add = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.B_Image_Up = new System.Windows.Forms.Button();
            this.B_Image_Dn = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 559);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 100);
            this.panel1.TabIndex = 8;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 81);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(793, 19);
            this.progressBar1.TabIndex = 2;
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(427, 15);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(135, 49);
            this.B_Cancel.TabIndex = 1;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Apply
            // 
            this.B_Apply.Location = new System.Drawing.Point(172, 15);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(135, 49);
            this.B_Apply.TabIndex = 0;
            this.B_Apply.Text = "確定";
            this.B_Apply.UseVisualStyleBackColor = true;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Load_Path});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(793, 27);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MI_Load_Path
            // 
            this.MI_Load_Path.Name = "MI_Load_Path";
            this.MI_Load_Path.Size = new System.Drawing.Size(81, 23);
            this.MI_Load_Path.Text = "載入路徑";
            this.MI_Load_Path.Click += new System.EventHandler(this.MI_Load_Path_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.B_Image_Dn);
            this.panel2.Controls.Add(this.B_Image_Up);
            this.panel2.Controls.Add(this.B_Image_Add_Range);
            this.panel2.Controls.Add(this.B_Image_Clear);
            this.panel2.Controls.Add(this.B_Image_Del);
            this.panel2.Controls.Add(this.B_Image_Add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 532);
            this.panel2.TabIndex = 12;
            // 
            // B_Image_Add_Range
            // 
            this.B_Image_Add_Range.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Image_Add_Range.ImageKey = "images_625px_1143012_easyicon.net.png";
            this.B_Image_Add_Range.ImageList = this.imageList1;
            this.B_Image_Add_Range.Location = new System.Drawing.Point(12, 245);
            this.B_Image_Add_Range.Name = "B_Image_Add_Range";
            this.B_Image_Add_Range.Size = new System.Drawing.Size(75, 71);
            this.B_Image_Add_Range.TabIndex = 3;
            this.B_Image_Add_Range.UseVisualStyleBackColor = true;
            this.B_Image_Add_Range.Click += new System.EventHandler(this.B_Image_Add_Range_Click);
            // 
            // B_Image_Clear
            // 
            this.B_Image_Clear.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Image_Clear.ImageKey = "trash_625px_1143011_easyicon.net.png";
            this.B_Image_Clear.ImageList = this.imageList1;
            this.B_Image_Clear.Location = new System.Drawing.Point(12, 168);
            this.B_Image_Clear.Name = "B_Image_Clear";
            this.B_Image_Clear.Size = new System.Drawing.Size(75, 71);
            this.B_Image_Clear.TabIndex = 2;
            this.B_Image_Clear.UseVisualStyleBackColor = true;
            this.B_Image_Clear.Click += new System.EventHandler(this.B_Image_Clear_Click);
            // 
            // B_Image_Del
            // 
            this.B_Image_Del.ImageIndex = 5;
            this.B_Image_Del.ImageList = this.imageList1;
            this.B_Image_Del.Location = new System.Drawing.Point(12, 91);
            this.B_Image_Del.Name = "B_Image_Del";
            this.B_Image_Del.Size = new System.Drawing.Size(75, 71);
            this.B_Image_Del.TabIndex = 1;
            this.B_Image_Del.UseVisualStyleBackColor = true;
            this.B_Image_Del.Click += new System.EventHandler(this.B_Image_Del_Click);
            // 
            // B_Image_Add
            // 
            this.B_Image_Add.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Image_Add.ImageKey = "Zoom_In2_64x64.png";
            this.B_Image_Add.ImageList = this.imageList1;
            this.B_Image_Add.Location = new System.Drawing.Point(12, 14);
            this.B_Image_Add.Name = "B_Image_Add";
            this.B_Image_Add.Size = new System.Drawing.Size(75, 71);
            this.B_Image_Add.TabIndex = 0;
            this.B_Image_Add.UseVisualStyleBackColor = true;
            this.B_Image_Add.Click += new System.EventHandler(this.B_Image_Add_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(97, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(696, 532);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // B_Image_Up
            // 
            this.B_Image_Up.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Image_Up.ImageKey = "Up_64x64.png";
            this.B_Image_Up.ImageList = this.imageList1;
            this.B_Image_Up.Location = new System.Drawing.Point(12, 322);
            this.B_Image_Up.Name = "B_Image_Up";
            this.B_Image_Up.Size = new System.Drawing.Size(75, 71);
            this.B_Image_Up.TabIndex = 4;
            this.B_Image_Up.UseVisualStyleBackColor = true;
            this.B_Image_Up.Click += new System.EventHandler(this.B_Image_Up_Click);
            // 
            // B_Image_Dn
            // 
            this.B_Image_Dn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Image_Dn.ImageKey = "Down_64x64.png";
            this.B_Image_Dn.ImageList = this.imageList1;
            this.B_Image_Dn.Location = new System.Drawing.Point(12, 399);
            this.B_Image_Dn.Name = "B_Image_Dn";
            this.B_Image_Dn.Size = new System.Drawing.Size(75, 71);
            this.B_Image_Dn.TabIndex = 5;
            this.B_Image_Dn.UseVisualStyleBackColor = true;
            this.B_Image_Dn.Click += new System.EventHandler(this.B_Image_Dn_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Up_64x64.png");
            this.imageList1.Images.SetKeyName(1, "Down_64x64.png");
            this.imageList1.Images.SetKeyName(2, "Left_64x64.png");
            this.imageList1.Images.SetKeyName(3, "Right_64x64.png");
            this.imageList1.Images.SetKeyName(4, "Zoom_In2_64x64.png");
            this.imageList1.Images.SetKeyName(5, "Zoom_Out2_64x64.png");
            this.imageList1.Images.SetKeyName(6, "trash_625px_1143011_easyicon.net.png");
            this.imageList1.Images.SetKeyName(7, "images_625px_1143012_easyicon.net.png");
            this.imageList1.Images.SetKeyName(8, "paragraph_400px_1157279_easyicon.net.png");
            this.imageList1.Images.SetKeyName(9, "paragraph_400px_1157280_easyicon.net.png");
            this.imageList1.Images.SetKeyName(10, "paragraph_400px_1157284_easyicon.net.png");
            // 
            // TForm_Image_List_Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 659);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_Image_List_Edit";
            this.Text = "TForm_Image_List";
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MI_Load_Path;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_Image_Add_Range;
        private System.Windows.Forms.Button B_Image_Clear;
        private System.Windows.Forms.Button B_Image_Del;
        private System.Windows.Forms.Button B_Image_Add;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button B_Image_Dn;
        private System.Windows.Forms.Button B_Image_Up;
        private System.Windows.Forms.ImageList imageList1;
    }
}