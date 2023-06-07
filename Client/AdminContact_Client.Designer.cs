namespace Client
{
    partial class AdminContact_Client
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.tbx_User_Message = new System.Windows.Forms.TextBox();
            this.tbx_Main_Conversation = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Send);
            this.groupBox1.Controls.Add(this.tbx_User_Message);
            this.groupBox1.Controls.Add(this.tbx_Main_Conversation);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(952, 708);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gửi Đến SerVer";
            // 
            // btn_Send
            // 
            this.btn_Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_Send.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Send.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Send.FlatAppearance.BorderSize = 0;
            this.btn_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Send.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Send.Location = new System.Drawing.Point(868, 654);
            this.btn_Send.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(80, 50);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Gửi";
            this.btn_Send.UseVisualStyleBackColor = false;
            // 
            // tbx_User_Message
            // 
            this.tbx_User_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbx_User_Message.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbx_User_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_User_Message.Location = new System.Drawing.Point(4, 654);
            this.tbx_User_Message.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_User_Message.Multiline = true;
            this.tbx_User_Message.Name = "tbx_User_Message";
            this.tbx_User_Message.Size = new System.Drawing.Size(865, 50);
            this.tbx_User_Message.TabIndex = 0;
            // 
            // tbx_Main_Conversation
            // 
            this.tbx_Main_Conversation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbx_Main_Conversation.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbx_Main_Conversation.Location = new System.Drawing.Point(4, 19);
            this.tbx_Main_Conversation.Margin = new System.Windows.Forms.Padding(4);
            this.tbx_Main_Conversation.Multiline = true;
            this.tbx_Main_Conversation.Name = "tbx_Main_Conversation";
            this.tbx_Main_Conversation.ReadOnly = true;
            this.tbx_Main_Conversation.Size = new System.Drawing.Size(944, 635);
            this.tbx_Main_Conversation.TabIndex = 0;
            this.tbx_Main_Conversation.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // AdminContact_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 708);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AdminContact_Client";
            this.Text = "AdminContact_Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_User_Message;
        private System.Windows.Forms.TextBox tbx_Main_Conversation;
        private System.Windows.Forms.Button btn_Send;
    }
}