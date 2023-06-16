namespace Client
{
    partial class ChangePasswordForm
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
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_DoiMatKhau = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tbx_Username
            // 
            this.tbx_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbx_Username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_Username.Location = new System.Drawing.Point(138, 59);
            this.tbx_Username.Multiline = true;
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(184, 28);
            this.tbx_Username.TabIndex = 3;
            // 
            // tbx_Password
            // 
            this.tbx_Password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbx_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_Password.Location = new System.Drawing.Point(138, 111);
            this.tbx_Password.Multiline = true;
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(184, 28);
            this.tbx_Password.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Alpine KT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Alpine KT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Alpine KT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 47);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đổi password";
            // 
            // btn_DoiMatKhau
            // 
            this.btn_DoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_DoiMatKhau.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btn_DoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btn_DoiMatKhau.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btn_DoiMatKhau.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btn_DoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DoiMatKhau.Font = new System.Drawing.Font("UTM Alpine KT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoiMatKhau.ForeColor = System.Drawing.Color.Black;
            this.btn_DoiMatKhau.Location = new System.Drawing.Point(114, 158);
            this.btn_DoiMatKhau.Name = "btn_DoiMatKhau";
            this.btn_DoiMatKhau.Size = new System.Drawing.Size(174, 33);
            this.btn_DoiMatKhau.TabIndex = 5;
            this.btn_DoiMatKhau.Text = "Dùng Để Đăng Nhập";
            this.btn_DoiMatKhau.UseVisualStyleBackColor = false;
            this.btn_DoiMatKhau.Click += new System.EventHandler(this.btn_DoiMatKhau_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(138, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 1);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(138, 139);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 1);
            this.panel2.TabIndex = 6;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(425, 203);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_DoiMatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.tbx_Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "changePasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_DoiMatKhau;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}