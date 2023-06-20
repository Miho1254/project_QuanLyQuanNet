using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class AdminContact_Server : Form
    {
        private string username;
        private string message;
        public AdminContact_Server(string username, string message)
        {
            InitializeComponent();
            this.message = message;
            this.username = username;
        }

        private void AdminContact_Server_Load(object sender, EventArgs e)
        {
            // Hiển thị tin nhắn trong khung conversation
            string formattedMessage = $"{username}: {message}";
            tbx_Main_Conversation.AppendText(formattedMessage + Environment.NewLine);
        }
    }
}
