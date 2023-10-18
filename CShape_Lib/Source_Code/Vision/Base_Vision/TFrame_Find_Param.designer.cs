namespace EFC.Vision.Halcon
{
    partial class TFrame_Find_Param
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
            this.CB_Greediness = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CB_ScaleMax = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CB_SubPixel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.CB_NumMatches = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CB_ScaleMin = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CB_MaxOverlap = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_MinScore = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.Controls.Add(this.CB_Greediness);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CB_ScaleMax);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.CB_SubPixel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.CB_NumMatches);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.CB_ScaleMin);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CB_MaxOverlap);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CB_MinScore);
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
            this.groupBox1.Size = new System.Drawing.Size(308, 385);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 標靶搜尋參數 ]";
            // 
            // CB_Greediness
            // 
            this.CB_Greediness.FormattingEnabled = true;
            this.CB_Greediness.Items.AddRange(new object[] {
            "0",
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1"});
            this.CB_Greediness.Location = new System.Drawing.Point(165, 273);
            this.CB_Greediness.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_Greediness.Name = "CB_Greediness";
            this.CB_Greediness.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_Greediness.Size = new System.Drawing.Size(128, 25);
            this.CB_Greediness.TabIndex = 23;
            this.CB_Greediness.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 277);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Greediness";
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
            this.CB_ScaleMax.Location = new System.Drawing.Point(165, 238);
            this.CB_ScaleMax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_ScaleMax.Name = "CB_ScaleMax";
            this.CB_ScaleMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_ScaleMax.Size = new System.Drawing.Size(128, 25);
            this.CB_ScaleMax.TabIndex = 21;
            this.CB_ScaleMax.Text = "1.1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 241);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Scale Max";
            // 
            // CB_SubPixel
            // 
            this.CB_SubPixel.FormattingEnabled = true;
            this.CB_SubPixel.Items.AddRange(new object[] {
            "none",
            "interpolation",
            "least_squares",
            "least_squares_high",
            "least_squares_very_high"});
            this.CB_SubPixel.Location = new System.Drawing.Point(165, 343);
            this.CB_SubPixel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_SubPixel.Name = "CB_SubPixel";
            this.CB_SubPixel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_SubPixel.Size = new System.Drawing.Size(128, 25);
            this.CB_SubPixel.TabIndex = 17;
            this.CB_SubPixel.Text = "none";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 347);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "次像素";
            // 
            // CB_NumMatches
            // 
            this.CB_NumMatches.FormattingEnabled = true;
            this.CB_NumMatches.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "20",
            "30"});
            this.CB_NumMatches.Location = new System.Drawing.Point(165, 308);
            this.CB_NumMatches.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_NumMatches.Name = "CB_NumMatches";
            this.CB_NumMatches.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_NumMatches.Size = new System.Drawing.Size(128, 25);
            this.CB_NumMatches.TabIndex = 15;
            this.CB_NumMatches.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 312);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "搜尋數量";
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
            this.CB_ScaleMin.Location = new System.Drawing.Point(165, 203);
            this.CB_ScaleMin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_ScaleMin.Name = "CB_ScaleMin";
            this.CB_ScaleMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_ScaleMin.Size = new System.Drawing.Size(128, 25);
            this.CB_ScaleMin.TabIndex = 13;
            this.CB_ScaleMin.Text = "0.9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 206);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Scale Min";
            // 
            // CB_MaxOverlap
            // 
            this.CB_MaxOverlap.FormattingEnabled = true;
            this.CB_MaxOverlap.Items.AddRange(new object[] {
            "0",
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1"});
            this.CB_MaxOverlap.Location = new System.Drawing.Point(165, 168);
            this.CB_MaxOverlap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_MaxOverlap.Name = "CB_MaxOverlap";
            this.CB_MaxOverlap.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_MaxOverlap.Size = new System.Drawing.Size(128, 25);
            this.CB_MaxOverlap.TabIndex = 9;
            this.CB_MaxOverlap.Text = "0.7";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "最大殘缺量";
            // 
            // CB_MinScore
            // 
            this.CB_MinScore.FormattingEnabled = true;
            this.CB_MinScore.Items.AddRange(new object[] {
            "0",
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1"});
            this.CB_MinScore.Location = new System.Drawing.Point(165, 133);
            this.CB_MinScore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_MinScore.Name = "CB_MinScore";
            this.CB_MinScore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_MinScore.Size = new System.Drawing.Size(128, 25);
            this.CB_MinScore.TabIndex = 7;
            this.CB_MinScore.Text = "0.7";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "最小相似度";
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
            this.CB_AngleExtent.Location = new System.Drawing.Point(165, 97);
            this.CB_AngleExtent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_AngleExtent.Name = "CB_AngleExtent";
            this.CB_AngleExtent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_AngleExtent.Size = new System.Drawing.Size(128, 25);
            this.CB_AngleExtent.TabIndex = 5;
            this.CB_AngleExtent.Text = "0.39";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
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
            this.CB_AngleStart.Location = new System.Drawing.Point(165, 62);
            this.CB_AngleStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CB_AngleStart.Name = "CB_AngleStart";
            this.CB_AngleStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CB_AngleStart.Size = new System.Drawing.Size(128, 25);
            this.CB_AngleStart.TabIndex = 3;
            this.CB_AngleStart.Text = "-0.2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
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
            this.CB_NumLevels.Size = new System.Drawing.Size(128, 25);
            this.CB_NumLevels.TabIndex = 1;
            this.CB_NumLevels.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "NumLevels";
            // 
            // TFrame_Find_Param
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "TFrame_Find_Param";
            this.Size = new System.Drawing.Size(336, 410);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox CB_ScaleMax;
        public System.Windows.Forms.ComboBox CB_SubPixel;
        public System.Windows.Forms.ComboBox CB_NumMatches;
        public System.Windows.Forms.ComboBox CB_ScaleMin;
        public System.Windows.Forms.ComboBox CB_MaxOverlap;
        public System.Windows.Forms.ComboBox CB_MinScore;
        public System.Windows.Forms.ComboBox CB_AngleExtent;
        public System.Windows.Forms.ComboBox CB_AngleStart;
        public System.Windows.Forms.ComboBox CB_NumLevels;
        public System.Windows.Forms.ComboBox CB_Greediness;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;

    }
}
