namespace EFC.Vision.Halcon
{
    partial class TFrame_Create_NCC_Param
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Metric = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_AngleStep = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_AngleExtent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_AngleStart = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_NumLevels = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.groupBox1.Controls.Add(this.CB_Metric);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CB_AngleStep);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CB_AngleExtent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CB_AngleStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CB_NumLevels);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(15, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(308, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 標靶新建參數 ]";
            // 
            // CB_Metric
            // 
            this.CB_Metric.FormattingEnabled = true;
            this.CB_Metric.Items.AddRange(new object[] {
            "use_polarity",
            "ignore_global_polarity",
            "ignore_local_polarity"});
            this.CB_Metric.Location = new System.Drawing.Point(165, 139);
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
            this.label10.Location = new System.Drawing.Point(8, 142);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 18;
            this.label10.Text = "Metric";
            // 
            // CB_AngleStep
            // 
            this.CB_AngleStep.FormattingEnabled = true;
            this.CB_AngleStep.Items.AddRange(new object[] {
            "0",
            "0.0175",
            "0.0349",
            "0.0524",
            "0.0698",
            "0.0873"});
            this.CB_AngleStep.Location = new System.Drawing.Point(165, 111);
            this.CB_AngleStep.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_AngleStep.Name = "CB_AngleStep";
            this.CB_AngleStep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_AngleStep.Size = new System.Drawing.Size(128, 22);
            this.CB_AngleStep.TabIndex = 7;
            this.CB_AngleStep.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "間格搜尋角度";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "NumLevels";
            // 
            // TFrame_Create_NCC_Param
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TFrame_Create_NCC_Param";
            this.Size = new System.Drawing.Size(341, 203);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox CB_NumLevels;
        public System.Windows.Forms.ComboBox CB_Metric;
        public System.Windows.Forms.ComboBox CB_AngleStep;
        public System.Windows.Forms.ComboBox CB_AngleExtent;
        public System.Windows.Forms.ComboBox CB_AngleStart;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

    }
}