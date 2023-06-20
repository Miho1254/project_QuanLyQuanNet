using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer;

        public event Action<ClientHandler, string> DataReceived;

        public ClientHandler(TcpClient client)
        {
            // Khởi tạo đối tượng ClientHandler với TcpClient đã được kết nối
            this.client = client;
            stream = client.GetStream();
            buffer = new byte[1024];
        }

        public void Start()
        {
            // Bắt đầu đợi dữ liệu từ client
            WaitForData();
        }

        private void WaitForData()
        {
            // Bắt đầu đọc dữ liệu từ NetworkStream
            stream.BeginRead(buffer, 0, buffer.Length, OnDataReceived, null);
        }

        private void OnDataReceived(IAsyncResult ar)
        {
            try
            {
                // Kết thúc đọc dữ liệu từ NetworkStream và trả về số byte đã đọc được
                int bytesRead = stream.EndRead(ar);

                if (bytesRead > 0)
                {
                    // Chuyển đổi dữ liệu nhận được từ mảng byte thành chuỗi
                    string jsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Kích hoạt sự kiện DataReceived và truyền dữ liệu nhận được và đối tượng ClientHandler tương ứng
                    DataReceived?.Invoke(this, jsonData);
                }

                // Tiếp tục đợi dữ liệu mới từ client
                WaitForData();
            }
            catch (Exception)
            {
                // Xử lý ngoại lệ (ví dụ: máy khách đã ngắt kết nối)
            }
        }

        public void SendResponse(string jsonData)
        {
            // Chuyển đổi chuỗi dữ liệu thành mảng byte
            byte[] data = Encoding.ASCII.GetBytes(jsonData);

            // Gửi dữ liệu trả về cho client thông qua NetworkStream
            stream.Write(data, 0, data.Length);
        }
    }
}