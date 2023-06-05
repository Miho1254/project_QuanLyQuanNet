namespace project_QuanLyQuanNet
{
    partial class LoginBox
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_dangNhap = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::project_QuanLyQuanNet.Properties.Resources.f40034382f5325739c15a68ebd13bde0a7fd7224_s2_n2_y1;
            this.pictureBox1.Location = new System.Drawing.Point(248, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbx_Username
            // 
            this.tbx_Username.Location = new System.Drawing.Point(109, 46);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(133, 20);
            this.tbx_Username.TabIndex = 2;
            // 
            // tbx_Password
            // 
            this.tbx_Password.Location = new System.Drawing.Point(109, 89);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(133, 20);
            this.tbx_Password.TabIndex = 2;
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.Location = new System.Drawing.Point(11, 43);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(92, 21);
            this.lbl_Username.TabIndex = 3;
            this.lbl_Username.Text = "Username:";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.Location = new System.Drawing.Point(12, 89);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(91, 20);
            this.lbl_Password.TabIndex = 3;
            this.lbl_Password.Text = "Password:";
            // 
            // lbl_dangNhap
            // 
            this.lbl_dangNhap.AutoSize = true;
            this.lbl_dangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lbl_dangNhap.Font = new System.Drawing.Font("Century Gothic", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dangNhap.Location = new System.Drawing.Point(95, 9);
            this.lbl_dangNhap.Name = "lbl_dangNhap";
            this.lbl_dangNhap.Size = new System.Drawing.Size(114, 23);
            this.lbl_dangNhap.TabIndex = 3;
            this.lbl_dangNhap.Text = "Đăng Nhập";
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Login.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(153, 127);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(89, 25);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Đăng Nhập";
            this.btn_Login.UseVisualStyleBackColor = false;
            // 
            // LoginBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(409, 164);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_dangNhap);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_dangNhap;
        private System.Windows.Forms.Button btn_Login;
    }
}