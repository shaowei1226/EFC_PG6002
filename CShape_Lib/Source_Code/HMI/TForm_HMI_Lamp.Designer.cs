namespace EFC.HMI
{
    partial class TForm_HMI_Lamp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_HMI_Lamp));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.E_Status_Picture_Index = new System.Windows.Forms.TextBox();
            this.B_Image_Name = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_Bonder_Shape = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_Light_Bit_Count = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.E_Light_Device = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tFrame_Status1 = new EFC.HMI.TFrame_Status();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(421, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(447, 494);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.E_Status_Picture_Index);
            this.tabPage1.Controls.Add(this.B_Image_Name);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.CB_Bonder_Shape);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(439, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "開關功能";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // E_Status_Picture_Index
            // 
            this.E_Status_Picture_Index.Enabled = false;
            this.E_Status_Picture_Index.Location = new System.Drawing.Point(127, 189);
            this.E_Status_Picture_Index.Name = "E_Status_Picture_Index";
            this.E_Status_Picture_Index.Size = new System.Drawing.Size(131, 31);
            this.E_Status_Picture_Index.TabIndex = 20;
            this.E_Status_Picture_Index.Text = "0";
            // 
            // B_Image_Name
            // 
            this.B_Image_Name.Location = new System.Drawing.Point(264, 189);
            this.B_Image_Name.Name = "B_Image_Name";
            this.B_Image_Name.Size = new System.Drawing.Size(42, 29);
            this.B_Image_Name.TabIndex = 19;
            this.B_Image_Name.Text = "...";
            this.B_Image_Name.UseVisualStyleBackColor = true;
            this.B_Image_Name.Click += new System.EventHandler(this.B_Image_Name_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 193);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "按鈕圖庫";
            // 
            // CB_Bonder_Shape
            // 
            this.CB_Bonder_Shape.FormattingEnabled = true;
            this.CB_Bonder_Shape.Items.AddRange(new object[] {
            "Button_Style",
            "Round_Stype",
            "Ellipse_Style",
            "Image_Style"});
            this.CB_Bonder_Shape.Location = new System.Drawing.Point(127, 155);
            this.CB_Bonder_Shape.Name = "CB_Bonder_Shape";
            this.CB_Bonder_Shape.Size = new System.Drawing.Size(179, 28);
            this.CB_Bonder_Shape.TabIndex = 17;
            this.CB_Bonder_Shape.Text = "Button_Style";
            this.CB_Bonder_Shape.SelectedValueChanged += new System.EventHandler(this.CB_Bonder_Shape_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CB_Light_Bit_Count);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.E_Light_Device);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(18, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(289, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "[指示燈]";
            // 
            // CB_Light_Bit_Count
            // 
            this.CB_Light_Bit_Count.FormattingEnabled = true;
            this.CB_Light_Bit_Count.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CB_Light_Bit_Count.Location = new System.Drawing.Point(159, 69);
            this.CB_Light_Bit_Count.Name = "CB_Light_Bit_Count";
            this.CB_Light_Bit_Count.Size = new System.Drawing.Size(102, 28);
            this.CB_Light_Bit_Count.TabIndex = 5;
            this.CB_Light_Bit_Count.Text = "1";
            this.CB_Light_Bit_Count.TextChanged += new System.EventHandler(this.CB_Light_Bit_Count_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 69);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "狀態位元數";
            // 
            // E_Light_Device
            // 
            this.E_Light_Device.Location = new System.Drawing.Point(159, 32);
            this.E_Light_Device.Name = "E_Light_Device";
            this.E_Light_Device.Size = new System.Drawing.Size(100, 31);
            this.E_Light_Device.TabIndex = 1;
            this.E_Light_Device.Text = "X00000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "PLC位置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "按鈕式樣";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 574);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 96);
            this.panel1.TabIndex = 7;
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(880, 64);
            this.panel2.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "paragraph_400px_1157280_easyicon.net.png");
            this.imageList1.Images.SetKeyName(1, "paragraph_400px_1157284_easyicon.net.png");
            this.imageList1.Images.SetKeyName(2, "paragraph_400px_1157279_easyicon.net.png");
            // 
            // tFrame_Status1
            // 
            this.tFrame_Status1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tFrame_Status1.Location = new System.Drawing.Point(4, 71);
            this.tFrame_Status1.Margin = new System.Windows.Forms.Padding(4);
            this.tFrame_Status1.Name = "tFrame_Status1";
            this.tFrame_Status1.Size = new System.Drawing.Size(411, 497);
            this.tFrame_Status1.TabIndex = 8;
            // 
            // TForm_HMI_Lamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 670);
            this.Controls.Add(this.tFrame_Status1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TForm_HMI_Lamp";
            this.Text = "TForm_HMI_Button";
            this.Shown += new System.EventHandler(this.TForm_HMI_Lamp_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CB_Light_Bit_Count;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox E_Light_Device;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox CB_Bonder_Shape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_Image_Name;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox E_Status_Picture_Index;
        private TFrame_Status tFrame_Status1;
    }
}