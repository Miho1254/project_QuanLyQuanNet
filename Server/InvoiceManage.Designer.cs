namespace Server
{
    partial class InvoiceManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceManage));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.gbx_TaoHoaDon = new System.Windows.Forms.GroupBox();
            this.tbx_MaDonHang = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btn_XuatHoaDon = new System.Windows.Forms.Button();
            this.tbx_TenDoAn = new System.Windows.Forms.Label();
            this.datagridview_HoaDon = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_XuatRaExcel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_XoaHoaDon = new System.Windows.Forms.Button();
            this.gbx_TaoHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_HoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_TaoHoaDon
            // 
            this.gbx_TaoHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_TaoHoaDon.Controls.Add(this.tbx_MaDonHang);
            this.gbx_TaoHoaDon.Controls.Add(this.btn_XuatHoaDon);
            this.gbx_TaoHoaDon.Controls.Add(this.tbx_TenDoAn);
            this.gbx_TaoHoaDon.Location = new System.Drawing.Point(3, -2);
            this.gbx_TaoHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx_TaoHoaDon.Name = "gbx_TaoHoaDon";
            this.gbx_TaoHoaDon.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbx_TaoHoaDon.Size = new System.Drawing.Size(1104, 81);
            this.gbx_TaoHoaDon.TabIndex = 5;
            this.gbx_TaoHoaDon.TabStop = false;
            this.gbx_TaoHoaDon.Text = "Tạo Hóa Đơn";
            // 
            // tbx_MaDonHang
            // 
            this.tbx_MaDonHang.AcceptsReturn = false;
            this.tbx_MaDonHang.AcceptsTab = false;
            this.tbx_MaDonHang.AnimationSpeed = 200;
            this.tbx_MaDonHang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tbx_MaDonHang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tbx_MaDonHang.BackColor = System.Drawing.Color.Transparent;
            this.tbx_MaDonHang.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbx_MaDonHang.BackgroundImage")));
            this.tbx_MaDonHang.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.tbx_MaDonHang.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tbx_MaDonHang.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.tbx_MaDonHang.BorderColorIdle = System.Drawing.Color.Silver;
            this.tbx_MaDonHang.BorderRadius = 10;
            this.tbx_MaDonHang.BorderThickness = 1;
            this.tbx_MaDonHang.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tbx_MaDonHang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_MaDonHang.DefaultFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_MaDonHang.DefaultText = "";
            this.tbx_MaDonHang.FillColor = System.Drawing.Color.White;
            this.tbx_MaDonHang.HideSelection = true;
            this.tbx_MaDonHang.IconLeft = global::Server.Properties.Resources.search_property_26px;
            this.tbx_MaDonHang.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_MaDonHang.IconPadding = 10;
            this.tbx_MaDonHang.IconRight = null;
            this.tbx_MaDonHang.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.tbx_MaDonHang.Lines = new string[0];
            this.tbx_MaDonHang.Location = new System.Drawing.Point(281, 28);
            this.tbx_MaDonHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_MaDonHang.MaxLength = 32767;
            this.tbx_MaDonHang.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_MaDonHang.Modified = false;
            this.tbx_MaDonHang.Multiline = false;
            this.tbx_MaDonHang.Name = "tbx_MaDonHang";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tbx_MaDonHang.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbx_MaDonHang.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tbx_MaDonHang.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tbx_MaDonHang.OnIdleState = stateProperties8;
            this.tbx_MaDonHang.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbx_MaDonHang.PasswordChar = '\0';
            this.tbx_MaDonHang.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbx_MaDonHang.PlaceholderText = "Tìm Mã Hóa đơn .....";
            this.tbx_MaDonHang.ReadOnly = false;
            this.tbx_MaDonHang.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbx_MaDonHang.SelectedText = "";
            this.tbx_MaDonHang.SelectionLength = 0;
            this.tbx_MaDonHang.SelectionStart = 0;
            this.tbx_MaDonHang.ShortcutsEnabled = true;
            this.tbx_MaDonHang.Size = new System.Drawing.Size(451, 42);
            this.tbx_MaDonHang.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.tbx_MaDonHang.TabIndex = 15;
            this.tbx_MaDonHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_MaDonHang.TextMarginBottom = 0;
            this.tbx_MaDonHang.TextMarginLeft = 10;
            this.tbx_MaDonHang.TextMarginTop = 0;
            this.tbx_MaDonHang.TextPlaceholder = "Tìm Mã Hóa đơn .....";
            this.tbx_MaDonHang.UseSystemPasswordChar = false;
            this.tbx_MaDonHang.WordWrap = true;
            // 
            // btn_XuatHoaDon
            // 
            this.btn_XuatHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_XuatHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XuatHoaDon.FlatAppearance.BorderSize = 0;
            this.btn_XuatHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XuatHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatHoaDon.Location = new System.Drawing.Point(765, 32);
            this.btn_XuatHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_XuatHoaDon.Name = "btn_XuatHoaDon";
            this.btn_XuatHoaDon.Size = new System.Drawing.Size(181, 38);
            this.btn_XuatHoaDon.TabIndex = 14;
            this.btn_XuatHoaDon.Text = "Xuất Hóa Đơn";
            this.btn_XuatHoaDon.UseVisualStyleBackColor = false;
            this.btn_XuatHoaDon.Click += new System.EventHandler(this.btn_XuatHoaDon_Click);
            // 
            // tbx_TenDoAn
            // 
            this.tbx_TenDoAn.AutoSize = true;
            this.tbx_TenDoAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TenDoAn.Location = new System.Drawing.Point(13, 28);
            this.tbx_TenDoAn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbx_TenDoAn.Name = "tbx_TenDoAn";
            this.tbx_TenDoAn.Size = new System.Drawing.Size(220, 39);
            this.tbx_TenDoAn.TabIndex = 1;
            this.tbx_TenDoAn.Text = "Tên Hóa Đơn";
            // 
            // datagridview_HoaDon
            // 
            this.datagridview_HoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridview_HoaDon.BackgroundColor = System.Drawing.Color.White;
            this.datagridview_HoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview_HoaDon.Location = new System.Drawing.Point(257, 86);
            this.datagridview_HoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.datagridview_HoaDon.Name = "datagridview_HoaDon";
            this.datagridview_HoaDon.RowHeadersWidth = 51;
            this.datagridview_HoaDon.Size = new System.Drawing.Size(855, 678);
            this.datagridview_HoaDon.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Server.Properties.Resources._337201839_748223423418798_8953680672966568511_n;
            this.pictureBox1.Location = new System.Drawing.Point(3, 86);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 678);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_XuatRaExcel);
            this.panel1.Location = new System.Drawing.Point(933, 713);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 33);
            this.panel1.TabIndex = 8;
            // 
            // btn_XuatRaExcel
            // 
            this.btn_XuatRaExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_XuatRaExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_XuatRaExcel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XuatRaExcel.FlatAppearance.BorderSize = 0;
            this.btn_XuatRaExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XuatRaExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatRaExcel.Location = new System.Drawing.Point(0, 0);
            this.btn_XuatRaExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_XuatRaExcel.Name = "btn_XuatRaExcel";
            this.btn_XuatRaExcel.Size = new System.Drawing.Size(160, 33);
            this.btn_XuatRaExcel.TabIndex = 14;
            this.btn_XuatRaExcel.Text = "Xuất Ra Excel";
            this.btn_XuatRaExcel.UseVisualStyleBackColor = false;
            this.btn_XuatRaExcel.Click += new System.EventHandler(this.btn_XuatRaExcel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_XoaHoaDon);
            this.panel2.Location = new System.Drawing.Point(809, 713);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(97, 33);
            this.panel2.TabIndex = 8;
            // 
            // btn_XoaHoaDon
            // 
            this.btn_XoaHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_XoaHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_XoaHoaDon.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_XoaHoaDon.FlatAppearance.BorderSize = 0;
            this.btn_XoaHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_XoaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XoaHoaDon.Location = new System.Drawing.Point(0, 0);
            this.btn_XoaHoaDon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_XoaHoaDon.Name = "btn_XoaHoaDon";
            this.btn_XoaHoaDon.Size = new System.Drawing.Size(97, 33);
            this.btn_XoaHoaDon.TabIndex = 14;
            this.btn_XoaHoaDon.Text = "Xóa";
            this.btn_XoaHoaDon.UseVisualStyleBackColor = false;
            this.btn_XoaHoaDon.Click += new System.EventHandler(this.btn_XoaHoaDon_Click);
            // 
            // InvoiceManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1109, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbx_TaoHoaDon);
            this.Controls.Add(this.datagridview_HoaDon);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InvoiceManage";
            this.Text = "InvoiceManage";
            this.Load += new System.EventHandler(this.InvoiceManage_Load);
            this.gbx_TaoHoaDon.ResumeLayout(false);
            this.gbx_TaoHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_HoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_TaoHoaDon;
        private System.Windows.Forms.Button btn_XuatHoaDon;
        private System.Windows.Forms.Label tbx_TenDoAn;
        private System.Windows.Forms.DataGridView datagridview_HoaDon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuTextBox tbx_MaDonHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_XuatRaExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_XoaHoaDon;
    }
}