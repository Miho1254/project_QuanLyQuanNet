namespace Server
{
    partial class AddUserBalance
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
            this.btn_Dangnhap = new System.Windows.Forms.Button();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_dangNhap = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Dangnhap
            // 
            this.btn_Dangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Dangnhap.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btn_Dangnhap.FlatAppearance.BorderSize = 0;
            this.btn_Dangnhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btn_Dangnhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btn_Dangnhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Dangnhap.Font = new System.Drawing.Font("Century", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dangnhap.ForeColor = System.Drawing.Color.Black;
            this.btn_Dangnhap.Location = new System.Drawing.Point(175, 188);
            this.btn_Dangnhap.Name = "btn_Dangnhap";
            this.btn_Dangnhap.Size = new System.Drawing.Size(166, 42);
            this.btn_Dangnhap.TabIndex = 12;
            this.btn_Dangnhap.Text = "Nạp Tiền";
            this.btn_Dangnhap.UseVisualStyleBackColor = false;
            // 
            // tbx_Password
            // 
            this.tbx_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Password.Location = new System.Drawing.Point(191, 126);
            this.tbx_Password.Multiline = true;
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(236, 33);
            this.tbx_Password.TabIndex = 11;
            // 
            // tbx_Username
            // 
            this.tbx_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Username.Location = new System.Drawing.Point(191, 73);
            this.tbx_Username.Multiline = true;
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(236, 33);
            this.tbx_Username.TabIndex = 10;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Password.Font = new System.Drawing.Font("Century", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.Location = new System.Drawing.Point(29, 126);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(143, 33);
            this.lbl_Password.TabIndex = 7;
            this.lbl_Password.Text = "Nạp Tiền";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Username.Font = new System.Drawing.Font("Century", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.Location = new System.Drawing.Point(29, 73);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(154, 33);
            this.lbl_Username.TabIndex = 8;
            this.lbl_Username.Text = "Username";
            // 
            // lbl_dangNhap
            // 
            this.lbl_dangNhap.AutoSize = true;
            this.lbl_dangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lbl_dangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dangNhap.Location = new System.Drawing.Point(118, 19);
            this.lbl_dangNhap.Name = "lbl_dangNhap";
            this.lbl_dangNhap.Size = new System.Drawing.Size(272, 31);
            this.lbl_dangNhap.TabIndex = 9;
            this.lbl_dangNhap.Text = "Nạp Tiền Tài Khoản";
            this.lbl_dangNhap.Click += new System.EventHandler(this.lbl_dangNhap_Click);
            // 
            // AddUserBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(528, 252);
            this.Controls.Add(this.btn_Dangnhap);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.lbl_dangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddUserBalance";
            this.Text = "AddUserBalance";
            this.Load += new System.EventHandler(this.AddUserBalance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Dangnhap;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_dangNhap;
    }
}