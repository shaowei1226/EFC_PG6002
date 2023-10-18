namespace EFC.HMI
{
    partial class TFrame_ImageList
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
            this.PB_Bitmap = new System.Windows.Forms.PictureBox();
            this.L_Bitmap_Name = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Bitmap)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Bitmap
            // 
            this.PB_Bitmap.BackColor = System.Drawing.SystemColors.Window;
            this.PB_Bitmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PB_Bitmap.Location = new System.Drawing.Point(8, 8);
            this.PB_Bitmap.Margin = new System.Windows.Forms.Padding(4);
            this.PB_Bitmap.Name = "PB_Bitmap";
            this.PB_Bitmap.Size = new System.Drawing.Size(160, 160);
            this.PB_Bitmap.TabIndex = 0;
            this.PB_Bitmap.TabStop = false;
            // 
            // L_Bitmap_Name
            // 
            this.L_Bitmap_Name.AutoSize = true;
            this.L_Bitmap_Name.Location = new System.Drawing.Point(4, 172);
            this.L_Bitmap_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Bitmap_Name.Name = "L_Bitmap_Name";
            this.L_Bitmap_Name.Size = new System.Drawing.Size(59, 20);
            this.L_Bitmap_Name.TabIndex = 1;
            this.L_Bitmap_Name.Text = "label1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TFrame_Image_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.L_Bitmap_Name);
            this.Controls.Add(this.PB_Bitmap);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TFrame_Image_List";
            this.Size = new System.Drawing.Size(178, 200);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Bitmap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.PictureBox PB_Bitmap;
        private System.Windows.Forms.Label L_Bitmap_Name;
    }
}
