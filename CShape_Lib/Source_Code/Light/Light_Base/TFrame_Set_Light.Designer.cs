namespace EFC.Light
{
     partial class TFrame_Set_Light
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
            this.SB_Light = new System.Windows.Forms.HScrollBar();
            this.L_Name = new System.Windows.Forms.Label();
            this.B_Set_Light = new System.Windows.Forms.Button();
            this.E_Light = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SB_Light
            // 
            this.SB_Light.Location = new System.Drawing.Point(8, 26);
            this.SB_Light.Maximum = 72;
            this.SB_Light.Name = "SB_Light";
            this.SB_Light.Size = new System.Drawing.Size(129, 24);
            this.SB_Light.TabIndex = 27;
            this.SB_Light.ValueChanged += new System.EventHandler(this.SB_Light_ValueChanged);
            // 
            // L_Name
            // 
            this.L_Name.AutoSize = true;
            this.L_Name.Location = new System.Drawing.Point(4, 4);
            this.L_Name.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Name.Name = "L_Name";
            this.L_Name.Size = new System.Drawing.Size(59, 16);
            this.L_Name.TabIndex = 30;
            this.L_Name.Text = "同軸光";
            // 
            // B_Set_Light
            // 
            this.B_Set_Light.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Set_Light.Location = new System.Drawing.Point(193, 26);
            this.B_Set_Light.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.B_Set_Light.Name = "B_Set_Light";
            this.B_Set_Light.Size = new System.Drawing.Size(59, 27);
            this.B_Set_Light.TabIndex = 28;
            this.B_Set_Light.Text = "Set";
            this.B_Set_Light.UseVisualStyleBackColor = true;
            this.B_Set_Light.Click += new System.EventHandler(this.B_Set_Light_Click);
            // 
            // E_Light
            // 
            this.E_Light.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Light.Location = new System.Drawing.Point(142, 26);
            this.E_Light.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.E_Light.Name = "E_Light";
            this.E_Light.Size = new System.Drawing.Size(41, 27);
            this.E_Light.TabIndex = 29;
            this.E_Light.Text = "0";
            this.E_Light.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.E_Light.KeyDown += new System.Windows.Forms.KeyEventHandler(this.E_Light_KeyDown);
            this.E_Light.Leave += new System.EventHandler(this.E_Light_Leave);
            // 
            // TFrame_Set_Light
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.B_Set_Light);
            this.Controls.Add(this.SB_Light);
            this.Controls.Add(this.E_Light);
            this.Controls.Add(this.L_Name);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "TFrame_Set_Light";
            this.Size = new System.Drawing.Size(260, 55);
            this.ResumeLayout(false);
            this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.HScrollBar SB_Light;
          public System.Windows.Forms.Label L_Name;
          private System.Windows.Forms.Button B_Set_Light;
          private System.Windows.Forms.TextBox E_Light;
     }
}
