using Newtonsoft.Json;
using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private byte[] buffer = new byte[1024];
        private string username;
        public AdminContact_Client(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private bool SendMessage(string message, string username)
        {
            string serverIP = ConfigurationManager.AppSettings["ServerIP"]; // Địa chỉ IP của máy chủ
            int serverPort = Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]); // Cổng của máy chủ

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(serverIP, serverPort);
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi kết nối đến server!");
                    return false;
                }

                Console.WriteLine("Kết nối thành công tới Server ở event Msg");

                // Tạo sự kiện tin nhắn
                EventData eventData = new EventData { Type = EventType.Message };
                eventData.Data["Message"] = message;
                eventData.Data["Username"] = message;

                // Chuyển đổi thành chuỗi JSON
                string jsonData = JsonConvert.SerializeObject(eventData);

                // Gửi tin nhắn đến máy chủ
                byte[] data = Encoding.ASCII.GetBytes(jsonData);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                // Đọc phản hồi từ máy chủ
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                // Chuyển đổi phản hồi thành sự kiện
                EventData responseEventData = JsonConvert.DeserializeObject<EventData>(responseJsonData);

                // Xử lý phản hồi từ máy chủ
                if (responseEventData.Type == EventType.MessageResponse)
                {
                    string responseMessage = responseEventData.Data["Response"].ToString();
                    Console.WriteLine("Phản hồi từ máy chủ: " + responseMessage);
                    if (responseMessage == "Success")
                    {
                        client.Close();
                        return true;
                    }
                    else
                    {
                        client.Close();
                        return false;
                    }
                }

                client.Close();
            }

            // Default return value in case all code paths fail to return
            return false;
        }

        private void btn_Send_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine("Clicked");

            // Gửi tin nhắn đến máy chủ
            string message = tbx_User_Message.Text;
            bool isSuccess = SendMessage(message, username);

            //Hiển thị tin nhắn trong khung conversation
            string formattedMessage = $"{username}: {message}";
            tbx_Main_Conversation.AppendText(formattedMessage + Environment.NewLine);

            // Xóa nội dung trong textbox 
            tbx_User_Message.Clear();
        }
    }

}
