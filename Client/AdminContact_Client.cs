using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class AdminContact_Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer = new byte[1024];
        public AdminContact_Client()
        {
            InitializeComponent();
        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            // Gửi tin nhắn đến máy chủ
            string message = tbx_User_Message.Text;
            SendMessage(message);
            // Hiển thị tin nhắn trong khung conversation
            // Xóa nội dung trong textbox
            tbx_User_Message.Clear();
        }
        private void SendMessage(string message)
        {
            // TODO: Gửi tin nhắn đến máy chủ
        }
    }
}
