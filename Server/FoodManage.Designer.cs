namespace Server
{
    partial class FoodManage
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
            this.datagridview_DoAn = new System.Windows.Forms.DataGridView();
            this.gbx_TaoDoAn = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_XoaDoAn = new System.Windows.Forms.Button();
            this.btn_TaoDoAn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_TenDoAn = new System.Windows.Forms.Label();
            this.tbx_MoTa = new System.Windows.Forms.TextBox();
            this.tbx_DoAn = new System.Windows.Forms.TextBox();
            this.tbx_GiaTien = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_DoAn)).BeginInit();
            this.gbx_TaoDoAn.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridview_DoAn
            // 
            this.datagridview_DoAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridview_DoAn.BackgroundColor = System.Drawing.Color.White;
            this.datagridview_DoAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_DoAn.Location = new System.Drawing.Point(253, 150);
            this.datagridview_DoAn.Margin = new System.Windows.Forms.Padding(4);
            this.datagridview_DoAn.Name = "datagridview_DoAn";
            this.datagridview_DoAn.RowHeadersWidth = 51;
            this.datagridview_DoAn.Size = new System.Drawing.Size(855, 641);
            this.datagridview_DoAn.TabIndex = 0;
            // 
            // gbx_TaoDoAn
            // 
            this.gbx_TaoDoAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_TaoDoAn.Controls.Add(this.panel1);
            this.gbx_TaoDoAn.Controls.Add(this.btn_TaoDoAn);
            this.gbx_TaoDoAn.Controls.Add(this.label3);
            this.gbx_TaoDoAn.Controls.Add(this.label2);
            this.gbx_TaoDoAn.Controls.Add(this.tbx_TenDoAn);
            this.gbx_TaoDoAn.Controls.Add(this.tbx_MoTa);
            this.gbx_TaoDoAn.Controls.Add(this.tbx_DoAn);
            this.gbx_TaoDoAn.Controls.Add(this.tbx_GiaTien);
            this.gbx_TaoDoAn.Location = new System.Drawing.Point(4, 0);
            this.gbx_TaoDoAn.Margin = new System.Windows.Forms.Padding(4);
            this.gbx_TaoDoAn.Name = "gbx_TaoDoAn";
            this.gbx_TaoDoAn.Padding = new System.Windows.Forms.Padding(4);
            this.gbx_TaoDoAn.Size = new System.Drawing.Size(1104, 153);
            this.gbx_TaoDoAn.TabIndex = 1;
            this.gbx_TaoDoAn.TabStop = false;
            this.gbx_TaoDoAn.Text = "Tạo Đồ Ăn";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_XoaDoAn);
            this.panel1.Location = new System.Drawing.Point(956, 90);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 44);
            this.panel1.TabIndex = 3;
            // 
            // btn_XoaDoAn
            // 
            this.btn_XoaDoAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_XoaDoAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_XoaDoAn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XoaDoAn.FlatAppearance.BorderSize = 0;
            this.btn_XoaDoAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaDoAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaDoAn.Location = new System.Drawing.Point(0, 0);
            this.btn_XoaDoAn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_XoaDoAn.Name = "btn_XoaDoAn";
            this.btn_XoaDoAn.Size = new System.Drawing.Size(109, 44);
            this.btn_XoaDoAn.TabIndex = 14;
            this.btn_XoaDoAn.Text = "Xóa";
            this.btn_XoaDoAn.UseVisualStyleBackColor = false;
            this.btn_XoaDoAn.Click += new System.EventHandler(this.btn_XoaDoAn_Click);
            // 
            // btn_TaoDoAn
            // 
            this.btn_TaoDoAn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_TaoDoAn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_TaoDoAn.FlatAppearance.BorderSize = 0;
            this.btn_TaoDoAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TaoDoAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaoDoAn.Location = new System.Drawing.Point(668, 90);
            this.btn_TaoDoAn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TaoDoAn.Name = "btn_TaoDoAn";
            this.btn_TaoDoAn.Size = new System.Drawing.Size(248, 44);
            this.btn_TaoDoAn.TabIndex = 14;
            this.btn_TaoDoAn.Text = "Thêm Đồ Ăn";
            this.btn_TaoDoAn.UseVisualStyleBackColor = false;
            this.btn_TaoDoAn.Click += new System.EventHandler(this.btn_TaoDoAn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(568, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giá Tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mô Tả";
            // 
            // tbx_TenDoAn
            // 
            this.tbx_TenDoAn.AutoSize = true;
            this.tbx_TenDoAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TenDoAn.Location = new System.Drawing.Point(29, 32);
            this.tbx_TenDoAn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbx_TenDoAn.Name = "tbx_TenDoAn";
            this.tbx_TenDoAn.Size = new System.Drawing.Size(180, 39);
            this.tbx_TenDoAn.TabIndex = 1;
            this.tbx_TenDoAn.Text = "Tên Đồ Ăn";
            // 
            // tbx_MoTa
            // 
            this.tbx_MoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_MoTa.Location = new System.Drawing.Point(228, 96);
            this.tbx_MoTa.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_MoTa.Multiline = true;
            this.tbx_MoTa.Name = "tbx_MoTa";
            this.tbx_MoTa.Size = new System.Drawing.Size(304, 37);
            this.tbx_MoTa.TabIndex = 0;
            // 
            // tbx_DoAn
            // 
            this.tbx_DoAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_DoAn.Location = new System.Drawing.Point(228, 33);
            this.tbx_DoAn.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_DoAn.Multiline = true;
            this.tbx_DoAn.Name = "tbx_DoAn";
            this.tbx_DoAn.Size = new System.Drawing.Size(304, 37);
            this.tbx_DoAn.TabIndex = 0;
            // 
            // tbx_GiaTien
            // 
            this.tbx_GiaTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_GiaTien.Location = new System.Drawing.Point(731, 33);
            this.tbx_GiaTien.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_GiaTien.Multiline = true;
            this.tbx_GiaTien.Name = "tbx_GiaTien";
            this.tbx_GiaTien.Size = new System.Drawing.Size(267, 38);
            this.tbx_GiaTien.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Server.Properties.Resources._337201839_748223423418798_8953680672966568511_n;
            this.pictureBox1.Location = new System.Drawing.Point(4, 150);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 649);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FoodManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1109, 793);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbx_TaoDoAn);
            this.Controls.Add(this.datagridview_DoAn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FoodManage";
            this.Text = "FoodManage";
            this.Load += new System.EventHandler(this.FoodManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_DoAn)).EndInit();
            this.gbx_TaoDoAn.ResumeLayout(false);
            this.gbx_TaoDoAn.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridview_DoAn;
        private System.Windows.Forms.GroupBox gbx_TaoDoAn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tbx_TenDoAn;
        private System.Windows.Forms.TextBox tbx_MoTa;
        private System.Windows.Forms.TextBox tbx_DoAn;
        private System.Windows.Forms.TextBox tbx_GiaTien;
        private System.Windows.Forms.Button btn_TaoDoAn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_XoaDoAn;
    }
}