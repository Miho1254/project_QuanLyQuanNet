namespace Server
{
    partial class Food_Order_Server
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
            this.tbx_Food = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbx_Food
            // 
            this.tbx_Food.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbx_Food.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Food.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Food.Location = new System.Drawing.Point(0, 0);
            this.tbx_Food.Multiline = true;
            this.tbx_Food.Name = "tbx_Food";
            this.tbx_Food.ReadOnly = true;
            this.tbx_Food.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbx_Food.Size = new System.Drawing.Size(581, 340);
            this.tbx_Food.TabIndex = 0;
            // 
            // Food_Order_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 340);
            this.Controls.Add(this.tbx_Food);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Food_Order_Server";
            this.Text = "AdminContact_Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_Food;
    }
}