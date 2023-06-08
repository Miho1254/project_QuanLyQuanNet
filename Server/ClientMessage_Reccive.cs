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
    public partial class ClientMessage_Reccive : Form
    {
        private string message;
        private string username;
        public ClientMessage_Reccive(string username,string message)
        {
            InitializeComponent();
            this.message = message;
            this.username = username;
        }

        private void ClientMessage_Reccive_Load(object sender, EventArgs e)
        {
            DisplayMessage(username, message, true);        
        }

        private void DisplayMessage(string username, string message, bool isHighlighted)
        {
            string formattedMessage = "[" + username + "]: " + message;

            // Tạo màu và font tùy thuộc vào giá trị isHighlighted
            Color usernameColor = isHighlighted ? Color.Purple : Color.Red;
            Font usernameFont = new Font(tbx_Main_Conversation.Font, FontStyle.Bold);

            // Thiết lập màu và font cho toàn bộ văn bản trong TextBox
            tbx_Main_Conversation.ForeColor = usernameColor;
            tbx_Main_Conversation.Font = usernameFont;

            // Thêm tin nhắn vào TextBox
            tbx_Main_Conversation.AppendText(formattedMessage + "\n");

            // Đặt lại màu và font mặc định
            tbx_Main_Conversation.ForeColor = DefaultForeColor;
            tbx_Main_Conversation.Font = DefaultFont;
        }
    }
}
