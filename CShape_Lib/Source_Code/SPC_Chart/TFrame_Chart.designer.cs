namespace EFC.SPC_Chart
{
    partial class TFrame_Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TFrame_Chart));
            this.panel1 = new System.Windows.Forms.Panel();
            this.SPC_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.B_Y_Shift_Dn = new System.Windows.Forms.Button();
            this.B_Y_Shift_Up = new System.Windows.Forms.Button();
            this.B_Y_Zoom_Out = new System.Windows.Forms.Button();
            this.B_Y_Zoom_In = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CB_SPC_Name = new System.Windows.Forms.ComboBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.E_Avg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.E_Center = new System.Windows.Forms.TextBox();
            this.E_Value = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.E_Dn_Limit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.E_Up_Limit = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.L_Info = new System.Windows.Forms.Label();
            this.B_X_Shift_Right = new System.Windows.Forms.Button();
            this.B_X_Shift_Left = new System.Windows.Forms.Button();
            this.B_X_Zoom_Out = new System.Windows.Forms.Button();
            this.B_X_Zoom_In = new System.Windows.Forms.Button();
            this.B_Zoom_Fit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPC_Chart)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.SPC_Chart);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 191);
            this.panel1.TabIndex = 0;
            // 
            // SPC_Chart
            // 
            this.SPC_Chart.BackColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.LabelStyle.Format = "#,##0.###";
            chartArea2.Name = "Data1";
            this.SPC_Chart.ChartAreas.Add(chartArea2);
            this.SPC_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.SPC_Chart.Legends.Add(legend2);
            this.SPC_Chart.Location = new System.Drawing.Point(0, 47);
            this.SPC_Chart.Margin = new System.Windows.Forms.Padding(2);
            this.SPC_Chart.Name = "SPC_Chart";
            series5.ChartArea = "Data1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.Name = "Data1";
            series6.BorderWidth = 3;
            series6.ChartArea = "Data1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Up_Limit";
            series7.BorderWidth = 3;
            series7.ChartArea = "Data1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Dn_Limit";
            series8.BorderWidth = 3;
            series8.ChartArea = "Data1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Center";
            this.SPC_Chart.Series.Add(series5);
            this.SPC_Chart.Series.Add(series6);
            this.SPC_Chart.Series.Add(series7);
            this.SPC_Chart.Series.Add(series8);
            this.SPC_Chart.Size = new System.Drawing.Size(775, 118);
            this.SPC_Chart.TabIndex = 7;
            this.SPC_Chart.Text = "chart1";
            this.SPC_Chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.B_Y_Shift_Dn);
            this.panel3.Controls.Add(this.B_Y_Shift_Up);
            this.panel3.Controls.Add(this.B_Y_Zoom_Out);
            this.panel3.Controls.Add(this.B_Y_Zoom_In);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(775, 47);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(24, 118);
            this.panel3.TabIndex = 3;
            // 
            // B_Y_Shift_Dn
            // 
            this.B_Y_Shift_Dn.Dock = System.Windows.Forms.DockStyle.Top;
            this.B_Y_Shift_Dn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Y_Shift_Dn.ImageKey = "Down_64x64.png";
            this.B_Y_Shift_Dn.ImageList = this.imageList1;
            this.B_Y_Shift_Dn.Location = new System.Drawing.Point(0, 72);
            this.B_Y_Shift_Dn.Margin = new System.Windows.Forms.Padding(2);
            this.B_Y_Shift_Dn.Name = "B_Y_Shift_Dn";
            this.B_Y_Shift_Dn.Size = new System.Drawing.Size(24, 24);
            this.B_Y_Shift_Dn.TabIndex = 4;
            this.toolTip1.SetToolTip(this.B_Y_Shift_Dn, "下移");
            this.B_Y_Shift_Dn.UseVisualStyleBackColor = true;
            this.B_Y_Shift_Dn.Click += new System.EventHandler(this.B_Y_Shift_Dn_Click);
            // 
            // B_Y_Shift_Up
            // 
            this.B_Y_Shift_Up.Dock = System.Windows.Forms.DockStyle.Top;
            this.B_Y_Shift_Up.ImageKey = "Up_64x64.png";
            this.B_Y_Shift_Up.ImageList = this.imageList1;
            this.B_Y_Shift_Up.Location = new System.Drawing.Point(0, 48);
            this.B_Y_Shift_Up.Margin = new System.Windows.Forms.Padding(2);
            this.B_Y_Shift_Up.Name = "B_Y_Shift_Up";
            this.B_Y_Shift_Up.Size = new System.Drawing.Size(24, 24);
            this.B_Y_Shift_Up.TabIndex = 3;
            this.toolTip1.SetToolTip(this.B_Y_Shift_Up, "上移");
            this.B_Y_Shift_Up.UseVisualStyleBackColor = true;
            this.B_Y_Shift_Up.Click += new System.EventHandler(this.B_Y_Shift_Up_Click);
            // 
            // B_Y_Zoom_Out
            // 
            this.B_Y_Zoom_Out.Dock = System.Windows.Forms.DockStyle.Top;
            this.B_Y_Zoom_Out.ImageKey = "Zoom_Out2_64x64.png";
            this.B_Y_Zoom_Out.ImageList = this.imageList1;
            this.B_Y_Zoom_Out.Location = new System.Drawing.Point(0, 24);
            this.B_Y_Zoom_Out.Margin = new System.Windows.Forms.Padding(2);
            this.B_Y_Zoom_Out.Name = "B_Y_Zoom_Out";
            this.B_Y_Zoom_Out.Size = new System.Drawing.Size(24, 24);
            this.B_Y_Zoom_Out.TabIndex = 2;
            this.toolTip1.SetToolTip(this.B_Y_Zoom_Out, "縮小");
            this.B_Y_Zoom_Out.UseVisualStyleBackColor = true;
            this.B_Y_Zoom_Out.Click += new System.EventHandler(this.B_Y_Zoom_Out_Click);
            // 
            // B_Y_Zoom_In
            // 
            this.B_Y_Zoom_In.Dock = System.Windows.Forms.DockStyle.Top;
            this.B_Y_Zoom_In.ImageKey = "Zoom_In2_64x64.png";
            this.B_Y_Zoom_In.ImageList = this.imageList1;
            this.B_Y_Zoom_In.Location = new System.Drawing.Point(0, 0);
            this.B_Y_Zoom_In.Margin = new System.Windows.Forms.Padding(2);
            this.B_Y_Zoom_In.Name = "B_Y_Zoom_In";
            this.B_Y_Zoom_In.Size = new System.Drawing.Size(24, 24);
            this.B_Y_Zoom_In.TabIndex = 1;
            this.toolTip1.SetToolTip(this.B_Y_Zoom_In, "放大");
            this.B_Y_Zoom_In.UseVisualStyleBackColor = true;
            this.B_Y_Zoom_In.Click += new System.EventHandler(this.B_Y_Zoom_In_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.CB_SPC_Name);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(799, 47);
            this.panel4.TabIndex = 2;
            // 
            // CB_SPC_Name
            // 
            this.CB_SPC_Name.FormattingEnabled = true;
            this.CB_SPC_Name.Location = new System.Drawing.Point(12, 10);
            this.CB_SPC_Name.Name = "CB_SPC_Name";
            this.CB_SPC_Name.Size = new System.Drawing.Size(177, 31);
            this.CB_SPC_Name.TabIndex = 7;
            this.CB_SPC_Name.SelectedIndexChanged += new System.EventHandler(this.CB_SPC_Name_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.E_Avg);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.E_Center);
            this.panel5.Controls.Add(this.E_Value);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.E_Dn_Limit);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.E_Up_Limit);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel5.Location = new System.Drawing.Point(223, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(576, 47);
            this.panel5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(344, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "平均值";
            // 
            // E_Avg
            // 
            this.E_Avg.Enabled = false;
            this.E_Avg.Location = new System.Drawing.Point(395, 14);
            this.E_Avg.Margin = new System.Windows.Forms.Padding(2);
            this.E_Avg.Name = "E_Avg";
            this.E_Avg.Size = new System.Drawing.Size(62, 28);
            this.E_Avg.TabIndex = 11;
            this.E_Avg.Text = "123.456";
            this.E_Avg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "現在值";
            // 
            // E_Center
            // 
            this.E_Center.Enabled = false;
            this.E_Center.Location = new System.Drawing.Point(156, 14);
            this.E_Center.Margin = new System.Windows.Forms.Padding(2);
            this.E_Center.Name = "E_Center";
            this.E_Center.Size = new System.Drawing.Size(62, 28);
            this.E_Center.TabIndex = 9;
            this.E_Center.Text = "123.456";
            this.E_Center.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // E_Value
            // 
            this.E_Value.Enabled = false;
            this.E_Value.Location = new System.Drawing.Point(512, 14);
            this.E_Value.Margin = new System.Windows.Forms.Padding(2);
            this.E_Value.Name = "E_Value";
            this.E_Value.Size = new System.Drawing.Size(62, 28);
            this.E_Value.TabIndex = 5;
            this.E_Value.Text = "123.456";
            this.E_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(118, 18);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "中心";
            // 
            // E_Dn_Limit
            // 
            this.E_Dn_Limit.Enabled = false;
            this.E_Dn_Limit.Location = new System.Drawing.Point(269, 14);
            this.E_Dn_Limit.Margin = new System.Windows.Forms.Padding(2);
            this.E_Dn_Limit.Name = "E_Dn_Limit";
            this.E_Dn_Limit.Size = new System.Drawing.Size(62, 28);
            this.E_Dn_Limit.TabIndex = 7;
            this.E_Dn_Limit.Text = "123.456";
            this.E_Dn_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "下限";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "上限";
            // 
            // E_Up_Limit
            // 
            this.E_Up_Limit.Enabled = false;
            this.E_Up_Limit.Location = new System.Drawing.Point(40, 14);
            this.E_Up_Limit.Margin = new System.Windows.Forms.Padding(2);
            this.E_Up_Limit.Name = "E_Up_Limit";
            this.E_Up_Limit.Size = new System.Drawing.Size(62, 28);
            this.E_Up_Limit.TabIndex = 5;
            this.E_Up_Limit.Text = "123.456";
            this.E_Up_Limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.B_X_Shift_Right);
            this.panel2.Controls.Add(this.B_X_Shift_Left);
            this.panel2.Controls.Add(this.B_X_Zoom_Out);
            this.panel2.Controls.Add(this.B_X_Zoom_In);
            this.panel2.Controls.Add(this.B_Zoom_Fit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel2.Location = new System.Drawing.Point(0, 165);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 26);
            this.panel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.L_Info);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(639, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(160, 26);
            this.panel6.TabIndex = 5;
            // 
            // L_Info
            // 
            this.L_Info.AutoSize = true;
            this.L_Info.Font = new System.Drawing.Font("新細明體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.L_Info.Location = new System.Drawing.Point(13, 7);
            this.L_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_Info.Name = "L_Info";
            this.L_Info.Size = new System.Drawing.Size(182, 17);
            this.L_Info.TabIndex = 1;
            this.L_Info.Text = "X=123.456, Y=123.456";
            // 
            // B_X_Shift_Right
            // 
            this.B_X_Shift_Right.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_X_Shift_Right.ImageKey = "Right_64x64.png";
            this.B_X_Shift_Right.ImageList = this.imageList1;
            this.B_X_Shift_Right.Location = new System.Drawing.Point(96, 0);
            this.B_X_Shift_Right.Margin = new System.Windows.Forms.Padding(2);
            this.B_X_Shift_Right.Name = "B_X_Shift_Right";
            this.B_X_Shift_Right.Size = new System.Drawing.Size(24, 26);
            this.B_X_Shift_Right.TabIndex = 4;
            this.toolTip1.SetToolTip(this.B_X_Shift_Right, "右移");
            this.B_X_Shift_Right.UseVisualStyleBackColor = true;
            this.B_X_Shift_Right.Click += new System.EventHandler(this.B_X_Shift_Right_Click);
            // 
            // B_X_Shift_Left
            // 
            this.B_X_Shift_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_X_Shift_Left.ImageKey = "Left_64x64.png";
            this.B_X_Shift_Left.ImageList = this.imageList1;
            this.B_X_Shift_Left.Location = new System.Drawing.Point(72, 0);
            this.B_X_Shift_Left.Margin = new System.Windows.Forms.Padding(2);
            this.B_X_Shift_Left.Name = "B_X_Shift_Left";
            this.B_X_Shift_Left.Size = new System.Drawing.Size(24, 26);
            this.B_X_Shift_Left.TabIndex = 3;
            this.toolTip1.SetToolTip(this.B_X_Shift_Left, "左移");
            this.B_X_Shift_Left.UseVisualStyleBackColor = true;
            this.B_X_Shift_Left.Click += new System.EventHandler(this.B_X_Shift_Left_Click);
            // 
            // B_X_Zoom_Out
            // 
            this.B_X_Zoom_Out.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_X_Zoom_Out.ImageKey = "Zoom_Out2_64x64.png";
            this.B_X_Zoom_Out.ImageList = this.imageList1;
            this.B_X_Zoom_Out.Location = new System.Drawing.Point(48, 0);
            this.B_X_Zoom_Out.Margin = new System.Windows.Forms.Padding(2);
            this.B_X_Zoom_Out.Name = "B_X_Zoom_Out";
            this.B_X_Zoom_Out.Size = new System.Drawing.Size(24, 26);
            this.B_X_Zoom_Out.TabIndex = 2;
            this.toolTip1.SetToolTip(this.B_X_Zoom_Out, "縮小");
            this.B_X_Zoom_Out.UseVisualStyleBackColor = true;
            this.B_X_Zoom_Out.Click += new System.EventHandler(this.B_X_Zoom_Out_Click);
            // 
            // B_X_Zoom_In
            // 
            this.B_X_Zoom_In.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_X_Zoom_In.ImageKey = "Zoom_In2_64x64.png";
            this.B_X_Zoom_In.ImageList = this.imageList1;
            this.B_X_Zoom_In.Location = new System.Drawing.Point(24, 0);
            this.B_X_Zoom_In.Margin = new System.Windows.Forms.Padding(2);
            this.B_X_Zoom_In.Name = "B_X_Zoom_In";
            this.B_X_Zoom_In.Size = new System.Drawing.Size(24, 26);
            this.B_X_Zoom_In.TabIndex = 1;
            this.toolTip1.SetToolTip(this.B_X_Zoom_In, "放大");
            this.B_X_Zoom_In.UseVisualStyleBackColor = true;
            this.B_X_Zoom_In.Click += new System.EventHandler(this.B_X_Zoom_In_Click);
            // 
            // B_Zoom_Fit
            // 
            this.B_Zoom_Fit.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Zoom_Fit.ImageKey = "four_arrows_64x64.png";
            this.B_Zoom_Fit.ImageList = this.imageList1;
            this.B_Zoom_Fit.Location = new System.Drawing.Point(0, 0);
            this.B_Zoom_Fit.Margin = new System.Windows.Forms.Padding(2);
            this.B_Zoom_Fit.Name = "B_Zoom_Fit";
            this.B_Zoom_Fit.Size = new System.Drawing.Size(24, 26);
            this.B_Zoom_Fit.TabIndex = 0;
            this.toolTip1.SetToolTip(this.B_Zoom_Fit, "放到最佳大小");
            this.B_Zoom_Fit.UseVisualStyleBackColor = true;
            this.B_Zoom_Fit.Click += new System.EventHandler(this.B_Zoom_Fit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Down_64x64.png");
            this.imageList1.Images.SetKeyName(1, "Left_64x64.png");
            this.imageList1.Images.SetKeyName(2, "Right_64x64.png");
            this.imageList1.Images.SetKeyName(3, "Up_64x64.png");
            this.imageList1.Images.SetKeyName(4, "Zoom_In2_64x64.png");
            this.imageList1.Images.SetKeyName(5, "Zoom_Out2_64x64.png");
            this.imageList1.Images.SetKeyName(6, "four_arrows_64x64.png");
            // 
            // TFrame_Chart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TFrame_Chart";
            this.Size = new System.Drawing.Size(819, 207);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPC_Chart)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button B_Y_Shift_Dn;
        private System.Windows.Forms.Button B_Y_Shift_Up;
        private System.Windows.Forms.Button B_Y_Zoom_Out;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button B_X_Shift_Right;
        private System.Windows.Forms.Button B_X_Shift_Left;
        private System.Windows.Forms.Button B_X_Zoom_Out;
        private System.Windows.Forms.Button B_X_Zoom_In;
        private System.Windows.Forms.Button B_Zoom_Fit;
        private System.Windows.Forms.Button B_Y_Zoom_In;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox E_Value;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox E_Dn_Limit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox E_Up_Limit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox E_Center;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart SPC_Chart;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label L_Info;
        private System.Windows.Forms.ComboBox CB_SPC_Name;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox E_Avg;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
