namespace Main
{
    partial class TForm_MS_Param
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TForm_MS_Param));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Root");
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel11 = new System.Windows.Forms.Panel();
            this.TV_Menu = new System.Windows.Forms.TreeView();
            this.panel13 = new System.Windows.Forms.Panel();
            this.B_Update_Tree = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C_Get_Pos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.B_Write = new System.Windows.Forms.Button();
            this.E_Item_List_Name = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Apply = new System.Windows.Forms.Button();
            this.panel11.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "magic_wand.bmp");
            this.imageList2.Images.SetKeyName(1, "button_cross.bmp");
            this.imageList2.Images.SetKeyName(2, "hard_drive_download.bmp");
            this.imageList2.Images.SetKeyName(3, "hard_drive_upload.bmp");
            this.imageList2.Images.SetKeyName(4, "photo_camera.png");
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.TV_Menu);
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 64);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(430, 543);
            this.panel11.TabIndex = 8;
            // 
            // TV_Menu
            // 
            this.TV_Menu.BackColor = System.Drawing.Color.White;
            this.TV_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TV_Menu.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TV_Menu.Indent = 32;
            this.TV_Menu.ItemHeight = 32;
            this.TV_Menu.Location = new System.Drawing.Point(0, 59);
            this.TV_Menu.Name = "TV_Menu";
            treeNode1.Name = "Root";
            treeNode1.Text = "Root";
            this.TV_Menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.TV_Menu.Size = new System.Drawing.Size(430, 484);
            this.TV_Menu.TabIndex = 8;
            this.TV_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_Menu_AfterSelect);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.B_Update_Tree);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Margin = new System.Windows.Forms.Padding(2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(430, 59);
            this.panel13.TabIndex = 2;
            // 
            // B_Update_Tree
            // 
            this.B_Update_Tree.BackColor = System.Drawing.Color.LimeGreen;
            this.B_Update_Tree.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Update_Tree.Location = new System.Drawing.Point(46, 7);
            this.B_Update_Tree.Margin = new System.Windows.Forms.Padding(2);
            this.B_Update_Tree.Name = "B_Update_Tree";
            this.B_Update_Tree.Size = new System.Drawing.Size(148, 42);
            this.B_Update_Tree.TabIndex = 0;
            this.B_Update_Tree.Text = "更新狀態";
            this.B_Update_Tree.UseVisualStyleBackColor = false;
            this.B_Update_Tree.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel2.Location = new System.Drawing.Point(430, 64);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 543);
            this.panel2.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3,
            this.C_Get_Pos});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 57);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1000, 486);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "名稱";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 250;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "值";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "型別";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "說明";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 400;
            // 
            // C_Get_Pos
            // 
            this.C_Get_Pos.HeaderText = "位置";
            this.C_Get_Pos.Name = "C_Get_Pos";
            this.C_Get_Pos.ReadOnly = true;
            this.C_Get_Pos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleVioletRed;
            this.panel3.Controls.Add(this.B_Write);
            this.panel3.Controls.Add(this.E_Item_List_Name);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 57);
            this.panel3.TabIndex = 30;
            // 
            // B_Write
            // 
            this.B_Write.Dock = System.Windows.Forms.DockStyle.Right;
            this.B_Write.Location = new System.Drawing.Point(876, 0);
            this.B_Write.Margin = new System.Windows.Forms.Padding(2);
            this.B_Write.Name = "B_Write";
            this.B_Write.Size = new System.Drawing.Size(124, 57);
            this.B_Write.TabIndex = 32;
            this.B_Write.Text = "空白";
            this.B_Write.UseVisualStyleBackColor = true;
            this.B_Write.Click += new System.EventHandler(this.B_Write_Click);
            // 
            // E_Item_List_Name
            // 
            this.E_Item_List_Name.AutoSize = true;
            this.E_Item_List_Name.Font = new System.Drawing.Font("新細明體", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.E_Item_List_Name.Location = new System.Drawing.Point(19, 16);
            this.E_Item_List_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.E_Item_List_Name.Name = "E_Item_List_Name";
            this.E_Item_List_Name.Size = new System.Drawing.Size(143, 27);
            this.E_Item_List_Name.TabIndex = 27;
            this.E_Item_List_Name.Text = "取料位置X";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGreen;
            this.panel1.Controls.Add(this.B_Cancel);
            this.panel1.Controls.Add(this.B_Apply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1430, 64);
            this.panel1.TabIndex = 7;
            // 
            // B_Cancel
            // 
            this.B_Cancel.BackColor = System.Drawing.Color.White;
            this.B_Cancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.B_Cancel.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cancel.ImageKey = "button_cross.bmp";
            this.B_Cancel.ImageList = this.imageList2;
            this.B_Cancel.Location = new System.Drawing.Point(97, 0);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(97, 64);
            this.B_Cancel.TabIndex = 8;
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
            this.B_Apply.ImageKey = "magic_wand.bmp";
            this.B_Apply.ImageList = this.imageList2;
            this.B_Apply.Location = new System.Drawing.Point(0, 0);
            this.B_Apply.Margin = new System.Windows.Forms.Padding(2);
            this.B_Apply.Name = "B_Apply";
            this.B_Apply.Size = new System.Drawing.Size(97, 64);
            this.B_Apply.TabIndex = 7;
            this.B_Apply.Text = "套用";
            this.B_Apply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Apply.UseVisualStyleBackColor = false;
            this.B_Apply.Click += new System.EventHandler(this.B_Apply_Click);
            // 
            // TForm_MS_Param
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1430, 607);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TForm_MS_Param";
            this.Text = "TForm_MS_Param";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel11.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TreeView TV_Menu;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button B_Update_Tree;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label E_Item_List_Name;
        private System.Windows.Forms.Button B_Write;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Apply;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewButtonColumn C_Get_Pos;
    }
}