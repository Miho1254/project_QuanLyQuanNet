namespace Server
{
    partial class CreateUserAccount
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
            this.btn_Tao = new System.Windows.Forms.Button();
            this.lbl_SoDu = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_SoDu = new System.Windows.Forms.TextBox();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Tao
            // 
            this.btn_Tao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_Tao.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Tao.FlatAppearance.BorderSize = 0;
            this.btn_Tao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Tao.Font = new System.Drawing.Font("UTM Seagull", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Tao.Location = new System.Drawing.Point(183, 190);
            this.btn_Tao.Name = "btn_Tao";
            this.btn_Tao.Size = new System.Drawing.Size(174, 36);
            this.btn_Tao.TabIndex = 13;
            this.btn_Tao.Text = "Tạo Tài Khoản";
            this.btn_Tao.UseVisualStyleBackColor = false;
            this.btn_Tao.Click += new System.EventHandler(this.btn_Tao_Click);
            // 
            // lbl_SoDu
            // 
            this.lbl_SoDu.AutoSize = true;
            this.lbl_SoDu.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SoDu.Font = new System.Drawing.Font("UTM Seagull", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SoDu.Location = new System.Drawing.Point(42, 133);
            this.lbl_SoDu.Name = "lbl_SoDu";
            this.lbl_SoDu.Size = new System.Drawing.Size(100, 34);
            this.lbl_SoDu.TabIndex = 9;
            this.lbl_SoDu.Text = "surplus";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Username.Font = new System.Drawing.Font("UTM Seagull", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.Location = new System.Drawing.Point(41, 52);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(130, 34);
            this.lbl_Username.TabIndex = 10;
            this.lbl_Username.Text = "Username";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Password.Font = new System.Drawing.Font("UTM Seagull", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.Location = new System.Drawing.Point(42, 94);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(125, 34);
            this.lbl_Password.TabIndex = 11;
            this.lbl_Password.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("UTM Alpine KT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 44);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tạo Tài Khoản";
            // 
            // tbx_SoDu
            // 
            this.tbx_SoDu.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SoDu.Location = new System.Drawing.Point(173, 141);
            this.tbx_SoDu.Multiline = true;
            this.tbx_SoDu.Name = "tbx_SoDu";
            this.tbx_SoDu.Size = new System.Drawing.Size(235, 25);
            this.tbx_SoDu.TabIndex = 6;
            // 
            // tbx_Password
            // 
            this.tbx_Password.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Password.Location = new System.Drawing.Point(173, 99);
            this.tbx_Password.Multiline = true;
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(235, 25);
            this.tbx_Password.TabIndex = 7;
            // 
            // tbx_Username
            // 
            this.tbx_Username.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Username.Location = new System.Drawing.Point(173, 56);
            this.tbx_Username.Multiline = true;
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(235, 25);
            this.tbx_Username.TabIndex = 8;
            // 
            // CreateUserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Server.Properties.Resources._322581382_899905131026462_1076981564075758256_n;
            this.ClientSize = new System.Drawing.Size(535, 247);
            this.Controls.Add(this.btn_Tao);
            this.Controls.Add(this.lbl_SoDu);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_SoDu);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.tbx_Username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CreateUserAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateUserAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Tao;
        private System.Windows.Forms.Label lbl_SoDu;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_SoDu;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.TextBox tbx_Username;
    }
}