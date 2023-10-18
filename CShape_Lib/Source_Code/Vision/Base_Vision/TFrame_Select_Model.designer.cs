namespace EFC.Vision.Halcon
{
    partial class TFrame_Select_Model
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.HW = new HalconDotNet.HWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Edit = new System.Windows.Forms.Button();
            this.B_Select_File = new System.Windows.Forms.Button();
            this.E_File_Name = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Model_File(*.mod)|*.mod";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 350);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.HW);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 293);
            this.panel2.TabIndex = 3;
            // 
            // HW
            // 
            this.HW.BackColor = System.Drawing.Color.Black;
            this.HW.BorderColor = System.Drawing.Color.Black;
            this.HW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HW.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.HW.Location = new System.Drawing.Point(0, 0);
            this.HW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.HW.Name = "HW";
            this.HW.Size = new System.Drawing.Size(300, 293);
            this.HW.TabIndex = 1;
            this.HW.WindowSize = new System.Drawing.Size(300, 293);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.B_Edit);
            this.panel1.Controls.Add(this.B_Select_File);
            this.panel1.Controls.Add(this.E_File_Name);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 57);
            this.panel1.TabIndex = 2;
            // 
            // B_Edit
            // 
            this.B_Edit.Location = new System.Drawing.Point(180, 9);
            this.B_Edit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.B_Edit.Name = "B_Edit";
            this.B_Edit.Size = new System.Drawing.Size(54, 42);
            this.B_Edit.TabIndex = 2;
            this.B_Edit.Text = "編輯";
            this.B_Edit.UseVisualStyleBackColor = true;
            this.B_Edit.Click += new System.EventHandler(this.button1_Click);
            // 
            // B_Select_File
            // 
            this.B_Select_File.Location = new System.Drawing.Point(242, 9);
            this.B_Select_File.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.B_Select_File.Name = "B_Select_File";
            this.B_Select_File.Size = new System.Drawing.Size(54, 42);
            this.B_Select_File.TabIndex = 1;
            this.B_Select_File.Text = "選取";
            this.B_Select_File.UseVisualStyleBackColor = true;
            this.B_Select_File.Click += new System.EventHandler(this.B_Select_File_Click);
            // 
            // E_File_Name
            // 
            this.E_File_Name.Location = new System.Drawing.Point(15, 15);
            this.E_File_Name.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.E_File_Name.Name = "E_File_Name";
            this.E_File_Name.Size = new System.Drawing.Size(157, 28);
            this.E_File_Name.TabIndex = 0;
            // 
            // TFrame_Select_Model
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TFrame_Select_Model";
            this.Size = new System.Drawing.Size(315, 368);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private HalconDotNet.HWindowControl HW;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox E_File_Name;
        public System.Windows.Forms.Button B_Select_File;
        public System.Windows.Forms.Button B_Edit;
    }
}
