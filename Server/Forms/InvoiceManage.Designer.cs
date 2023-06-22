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
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.gbx_TaoHoaDon = new System.Windows.Forms.GroupBox();
            this.tbx_MaDonHang = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btn_XuatHoaDon = new System.Windows.Forms.Button();
            this.tbx_TenDoAn = new System.Windows.Forms.Label();
            this.datagridview_HoaDon = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_XuatRaExcel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_XoaHoaDon = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbx_TaoHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_HoaDon)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.gbx_TaoHoaDon.Location = new System.Drawing.Point(2, -2);
            this.gbx_TaoHoaDon.Name = "gbx_TaoHoaDon";
            this.gbx_TaoHoaDon.Size = new System.Drawing.Size(828, 66);
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
            this.tbx_MaDonHang.Location = new System.Drawing.Point(211, 21);
            this.tbx_MaDonHang.MaxLength = 32767;
            this.tbx_MaDonHang.MinimumSize = new System.Drawing.Size(1, 1);
            this.tbx_MaDonHang.Modified = false;
            this.tbx_MaDonHang.Multiline = false;
            this.tbx_MaDonHang.Name = "tbx_MaDonHang";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tbx_MaDonHang.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tbx_MaDonHang.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tbx_MaDonHang.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tbx_MaDonHang.OnIdleState = stateProperties4;
            this.tbx_MaDonHang.Padding = new System.Windows.Forms.Padding(3);
            this.tbx_MaDonHang.PasswordChar = '\0';
            this.tbx_MaDonHang.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tbx_MaDonHang.PlaceholderText = "Tìm Mã Hóa đơn .....";
            this.tbx_MaDonHang.ReadOnly = false;
            this.tbx_MaDonHang.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbx_MaDonHang.SelectedText = "";
            this.tbx_MaDonHang.SelectionLength = 0;
            this.tbx_MaDonHang.SelectionStart = 0;
            this.tbx_MaDonHang.ShortcutsEnabled = true;
            this.tbx_MaDonHang.Size = new System.Drawing.Size(338, 34);
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
            this.btn_XuatHoaDon.Font = new System.Drawing.Font("UTM Seagull", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XuatHoaDon.Location = new System.Drawing.Point(570, 23);
            this.btn_XuatHoaDon.Name = "btn_XuatHoaDon";
            this.btn_XuatHoaDon.Size = new System.Drawing.Size(136, 31);
            this.btn_XuatHoaDon.TabIndex = 14;
            this.btn_XuatHoaDon.Text = "Xuất Hóa Đơn";
            this.btn_XuatHoaDon.UseVisualStyleBackColor = false;
            this.btn_XuatHoaDon.Click += new System.EventHandler(this.btn_XuatHoaDon_Click);
            // 
            // tbx_TenDoAn
            // 
            this.tbx_TenDoAn.AutoSize = true;
            this.tbx_TenDoAn.Font = new System.Drawing.Font("UTM Alpine KT", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_TenDoAn.Location = new System.Drawing.Point(33, 18);
            this.tbx_TenDoAn.Name = "tbx_TenDoAn";
            this.tbx_TenDoAn.Size = new System.Drawing.Size(173, 44);
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
            this.datagridview_HoaDon.Location = new System.Drawing.Point(193, 70);
            this.datagridview_HoaDon.Name = "datagridview_HoaDon";
            this.datagridview_HoaDon.RowHeadersWidth = 51;
            this.datagridview_HoaDon.Size = new System.Drawing.Size(641, 551);
            this.datagridview_HoaDon.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_XuatRaExcel);
            this.panel1.Location = new System.Drawing.Point(700, 579);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 27);
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
            this.btn_XuatRaExcel.Name = "btn_XuatRaExcel";
            this.btn_XuatRaExcel.Size = new System.Drawing.Size(120, 27);
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
            this.panel2.Location = new System.Drawing.Point(607, 579);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(73, 27);
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
            this.btn_XoaHoaDon.Name = "btn_XoaHoaDon";
            this.btn_XoaHoaDon.Size = new System.Drawing.Size(73, 27);
            this.btn_XoaHoaDon.TabIndex = 14;
            this.btn_XoaHoaDon.Text = "Xóa";
            this.btn_XoaHoaDon.UseVisualStyleBackColor = false;
            this.btn_XoaHoaDon.Click += new System.EventHandler(this.btn_XoaHoaDon_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Server.Properties.Resources._337201839_748223423418798_8953680672966568511_n;
            this.pictureBox1.Location = new System.Drawing.Point(2, 70);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 551);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // InvoiceManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(832, 609);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbx_TaoHoaDon);
            this.Controls.Add(this.datagridview_HoaDon);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimizeBox = false;
            this.Name = "InvoiceManage";
            this.Text = "InvoiceManage";
            this.Load += new System.EventHandler(this.InvoiceManage_Load);
            this.gbx_TaoHoaDon.ResumeLayout(false);
            this.gbx_TaoHoaDon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview_HoaDon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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