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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserBalance));
            this.lbl_dangNhap = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tbx_SoDu = new System.Windows.Forms.TextBox();
            this.tbx_Username = new System.Windows.Forms.TextBox();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_dangNhap
            // 
            this.lbl_dangNhap.AutoSize = true;
            this.lbl_dangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lbl_dangNhap.Font = new System.Drawing.Font("UTM Silk Script", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dangNhap.ForeColor = System.Drawing.Color.Black;
            this.lbl_dangNhap.Location = new System.Drawing.Point(118, 13);
            this.lbl_dangNhap.Name = "lbl_dangNhap";
            this.lbl_dangNhap.Size = new System.Drawing.Size(279, 42);
            this.lbl_dangNhap.TabIndex = 9;
            this.lbl_dangNhap.Text = "Nạp Tiền Tài Khoản";
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(183)))), ((int)(((byte)(253)))));
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("UTM Alpine KT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.ForeColor = System.Drawing.Color.Black;
            this.btn_Add.Location = new System.Drawing.Point(188, 183);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(150, 42);
            this.btn_Add.TabIndex = 22;
            this.btn_Add.Text = "Nạp Tiền";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // tbx_SoDu
            // 
            this.tbx_SoDu.Font = new System.Drawing.Font("UTM Seagull", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_SoDu.Location = new System.Drawing.Point(188, 128);
            this.tbx_SoDu.Multiline = true;
            this.tbx_SoDu.Name = "tbx_SoDu";
            this.tbx_SoDu.Size = new System.Drawing.Size(236, 33);
            this.tbx_SoDu.TabIndex = 21;
            // 
            // tbx_Username
            // 
            this.tbx_Username.Font = new System.Drawing.Font("UTM Seagull", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Username.Location = new System.Drawing.Point(188, 75);
            this.tbx_Username.Multiline = true;
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(236, 33);
            this.tbx_Username.TabIndex = 20;
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Password.Font = new System.Drawing.Font("UTM Alpine KT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Password.ForeColor = System.Drawing.Color.Black;
            this.lbl_Password.Location = new System.Drawing.Point(43, 128);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(129, 44);
            this.lbl_Password.TabIndex = 18;
            this.lbl_Password.Text = "Nạp Tiền";
            // 
            // lbl_Username
            // 
            this.lbl_Username.AutoSize = true;
            this.lbl_Username.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Username.Font = new System.Drawing.Font("UTM Alpine KT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Username.ForeColor = System.Drawing.Color.Black;
            this.lbl_Username.Location = new System.Drawing.Point(43, 75);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(134, 44);
            this.lbl_Username.TabIndex = 19;
            this.lbl_Username.Text = "Username";
            // 
            // AddUserBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(183)))), ((int)(((byte)(253)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(528, 252);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.tbx_SoDu);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.lbl_dangNhap);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddUserBalance";
            this.Text = "AddUserBalance";
            this.Load += new System.EventHandler(this.AddUserBalance_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_dangNhap;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox tbx_SoDu;
        private System.Windows.Forms.TextBox tbx_Username;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_Username;
    }
}