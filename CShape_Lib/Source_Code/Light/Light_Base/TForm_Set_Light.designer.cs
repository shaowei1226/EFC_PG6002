namespace EFC.Light
{
    partial class TForm_Set_Light
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_Set_Light));
            this.panel2 = new System.Windows.Forms.Panel();
            this.B_Open = new System.Windows.Forms.Button();
            this.Tool_ImageList = new System.Windows.Forms.ImageList(this.components);
            this.B_Save_As = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tFrame_Set_Light5 = new EFC.Light.TFrame_Set_Light();
            this.tFrame_Set_Light4 = new EFC.Light.TFrame_Set_Light();
            this.tFrame_Set_Light3 = new EFC.Light.TFrame_Set_Light();
            this.tFrame_Set_Light2 = new EFC.Light.TFrame_Set_Light();
            this.tFrame_Set_Light1 = new EFC.Light.TFrame_Set_Light();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tFrame_JJS_HW1 = new EFC.Vision.Halcon.TFrame_JJS_HW();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tFrame_Set_Light6 = new EFC.Light.TFrame_Set_Light();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGreen;
            this.panel2.Controls.Add(this.B_Open);
            this.panel2.Controls.Add(this.B_Save_As);
            this.panel2.Controls.Add(this.B_Cancel);
            this.panel2.Controls.Add(this.B_Apply);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1035, 64);
            this.panel2.TabIndex = 3;
            // 
            // B_Open
            // 
            this.B_Open.BackColor = System.Drawing.Color.White;
            this.B_Open.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Open.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Open.ImageIndex = 3;
            this.B_Open.ImageList = this.Tool_ImageList;
            this.B_Open.Location = new System.Drawing.Point(368, 0);
            this.B_Open.Margin = new System.Windows.Forms.Padding(2);
            this.B_Open.Name = "B_Open";
            this.B_Open.Size = new System.Drawing.Size(120, 64);
            this.B_Open.TabIndex = 10;
            this.B_Open.Text = "開啟";
            this.B_Open.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Open.UseVisualStyleBackColor = false;
            this.B_Open.Visible = false;
            // 
            // Tool_ImageList
            // 
            this.Tool_ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Tool_ImageList.ImageStream")));
            this.Tool_ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.Tool_ImageList.Images.SetKeyName(0, "magic_wand.bmp");
            this.Tool_ImageList.Images.SetKeyName(1, "button_cross.bmp");
            this.Tool_ImageList.Images.SetKeyName(2, "hard_drive_download.bmp");
            this.Tool_ImageList.Images.SetKeyName(3, "hard_drive_upload.bmp");
            // 
            // B_Save_As
            // 
            this.B_Save_As.BackColor = System.Drawing.Color.White;
            this.B_Save_As.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Save_As.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Save_As.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Save_As.ImageIndex = 2;
            this.B_Save_As.ImageList = this.Tool_ImageList;
            this.B_Save_As.Location = new System.Drawing.Point(248, 0);
            this.B_Save_As.Margin = new System.Windows.Forms.Padding(2);
            this.B_Save_As.Name = "B_Save_As";
            this.B_Save_As.Size = new System.Drawing.Size(120, 64);
            this.B_Save_As.TabIndex = 9;
            this.B_Save_As.Text = "另存檔案";
            this.B_Save_As.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Save_As.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.B_Save_As.UseVisualStyleBackColor = false;
            this.B_Save_As.Visible = false;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageIndex = 1;
            this.B_Cancel.ImageList = this.Tool_ImageList;
            this.B_Cancel.Location = new System.Drawing.Point(120, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(128, 64);
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
            this.B_Apply.ImageIndex = 0;
            this.B_Apply.ImageList = this.Tool_ImageList;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(120, 64);
            this.B_Apply.TabIndex = 5;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 519);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.BurlyWood;
            this.panel4.Controls.Add(this.tFrame_Set_Light6);
            this.panel4.Controls.Add(this.tFrame_Set_Light5);
            this.panel4.Controls.Add(this.tFrame_Set_Light4);
            this.panel4.Controls.Add(this.tFrame_Set_Light3);
            this.panel4.Controls.Add(this.tFrame_Set_Light2);
            this.panel4.Controls.Add(this.tFrame_Set_Light1);
            this.panel4.Location = new System.Drawing.Point(12, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(292, 394);
            this.panel4.TabIndex = 1;
            // 
            // tFrame_Set_Light5
            // 
            this.tFrame_Set_Light5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light5.Light_Value = 0;
            this.tFrame_Set_Light5.Location = new System.Drawing.Point(17, 265);
            this.tFrame_Set_Light5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tFrame_Set_Light5.Name = "tFrame_Set_Light5";
            this.tFrame_Set_Light5.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light5.TabIndex = 4;
            // 
            // tFrame_Set_Light4
            // 
            this.tFrame_Set_Light4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light4.Light_Value = 0;
            this.tFrame_Set_Light4.Location = new System.Drawing.Point(17, 202);
            this.tFrame_Set_Light4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tFrame_Set_Light4.Name = "tFrame_Set_Light4";
            this.tFrame_Set_Light4.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light4.TabIndex = 3;
            // 
            // tFrame_Set_Light3
            // 
            this.tFrame_Set_Light3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light3.Light_Value = 0;
            this.tFrame_Set_Light3.Location = new System.Drawing.Point(17, 139);
            this.tFrame_Set_Light3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tFrame_Set_Light3.Name = "tFrame_Set_Light3";
            this.tFrame_Set_Light3.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light3.TabIndex = 2;
            // 
            // tFrame_Set_Light2
            // 
            this.tFrame_Set_Light2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light2.Light_Value = 0;
            this.tFrame_Set_Light2.Location = new System.Drawing.Point(17, 76);
            this.tFrame_Set_Light2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tFrame_Set_Light2.Name = "tFrame_Set_Light2";
            this.tFrame_Set_Light2.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light2.TabIndex = 1;
            // 
            // tFrame_Set_Light1
            // 
            this.tFrame_Set_Light1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light1.Light_Value = 0;
            this.tFrame_Set_Light1.Location = new System.Drawing.Point(17, 13);
            this.tFrame_Set_Light1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tFrame_Set_Light1.Name = "tFrame_Set_Light1";
            this.tFrame_Set_Light1.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tFrame_JJS_HW1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(367, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(668, 519);
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
            this.tFrame_JJS_HW1.Size = new System.Drawing.Size(668, 519);
            this.tFrame_JJS_HW1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tFrame_Set_Light6
            // 
            this.tFrame_Set_Light6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Set_Light6.Light_Value = 0;
            this.tFrame_Set_Light6.Location = new System.Drawing.Point(17, 328);
            this.tFrame_Set_Light6.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tFrame_Set_Light6.Name = "tFrame_Set_Light6";
            this.tFrame_Set_Light6.Size = new System.Drawing.Size(260, 55);
            this.tFrame_Set_Light6.TabIndex = 5;
            // 
            // TForm_Set_Light
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 583);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "TForm_Set_Light";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TForm_Set_Light_FormClosed);
            this.Shown += new System.EventHandler(this.TForm_Set_Light_Shown);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_Open;
        private System.Windows.Forms.Button B_Save_As;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private TFrame_Set_Light tFrame_Set_Light5;
        private TFrame_Set_Light tFrame_Set_Light4;
        private TFrame_Set_Light tFrame_Set_Light3;
        private TFrame_Set_Light tFrame_Set_Light2;
        private TFrame_Set_Light tFrame_Set_Light1;
        private System.Windows.Forms.ImageList Tool_ImageList;
        private Vision.Halcon.TFrame_JJS_HW tFrame_JJS_HW1;
        private TFrame_Set_Light tFrame_Set_Light6;
    }
}