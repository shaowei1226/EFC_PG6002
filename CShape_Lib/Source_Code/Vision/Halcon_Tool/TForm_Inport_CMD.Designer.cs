namespace EFC.Vision.Halcon
{
    partial class TForm_Inport_CMD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Inport_CMD));
            this.panel34 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel34.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel34
            // 
            this.panel34.BackColor = System.Drawing.Color.LightGreen;
            this.panel34.Controls.Add(this.button1);
            this.panel34.Controls.Add(this.button2);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel34.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel34.Location = new System.Drawing.Point(0, 0);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(379, 74);
            this.panel34.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Image = global::EFC.Vision.Halcon.Properties.Resources.button_cross;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(129, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 74);
            this.button1.TabIndex = 10;
            this.button1.Text = "取消";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Image = global::EFC.Vision.Halcon.Properties.Resources.magic_wand;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 74);
            this.button2.TabIndex = 9;
            this.button2.Text = "套用";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "undo_64x64.png");
            this.imageList1.Images.SetKeyName(1, "play_64x64.png");
            this.imageList1.Images.SetKeyName(2, "Next_64x64.png");
            this.imageList1.Images.SetKeyName(3, "Stop_64x64.png");
            this.imageList1.Images.SetKeyName(4, "Add.png");
            this.imageList1.Images.SetKeyName(5, "Del.png");
            this.imageList1.Images.SetKeyName(6, "Up_64x64.png");
            this.imageList1.Images.SetKeyName(7, "Down_64x64.png");
            this.imageList1.Images.SetKeyName(8, "add_64x64.png");
            this.imageList1.Images.SetKeyName(9, "cancel_64x64.png");
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Items.AddRange(new object[] {
            "aa"});
            this.listBox1.Location = new System.Drawing.Point(0, 74);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(379, 400);
            this.listBox1.TabIndex = 15;
            // 
            // TForm_Inport_CMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 474);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel34);
            this.Name = "TForm_Inport_CMD";
            this.Text = "TForm_Inport_CMD";
            this.panel34.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox listBox1;
    }
}