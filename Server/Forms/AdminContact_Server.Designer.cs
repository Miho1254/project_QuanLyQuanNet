namespace Server
{
    partial class AdminContact_Server
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
            this.tbx_Main_Conversation = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbx_Main_Conversation);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 368);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gửi Đến SerVer";
            // 
            // tbx_Main_Conversation
            // 
            this.tbx_Main_Conversation.BackColor = System.Drawing.Color.White;
            this.tbx_Main_Conversation.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbx_Main_Conversation.Location = new System.Drawing.Point(3, 16);
            this.tbx_Main_Conversation.Multiline = true;
            this.tbx_Main_Conversation.Name = "tbx_Main_Conversation";
            this.tbx_Main_Conversation.ReadOnly = true;
            this.tbx_Main_Conversation.Size = new System.Drawing.Size(269, 352);
            this.tbx_Main_Conversation.TabIndex = 0;
            // 
            // AdminContact_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 368);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminContact_Server";
            this.Text = "AdminContact_Server";
            this.Load += new System.EventHandler(this.AdminContact_Server_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_Main_Conversation;
    }
}