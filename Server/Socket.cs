using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System;

namespace Server
{
    public enum EventType
    {
        Login,          // Sự kiện đăng nhập
        Message,        // Sự kiện tin nhắn
        Order,          // Sự kiện đơn đặt hàng
        LoginResponse   // Sự kiện phản hồi đăng nhập
        // Thêm các loại sự kiện khác nếu cần
    }

    public class SocketServer
    {
        private TcpListener listener;

        public SocketServer()
        {

        }

        public void Start(string ipAddress, int port)
        {
            listener = new TcpListener(IPAddress.Parse(ipAddress), port);
            listener.Start();
            Console.WriteLine("Đang lắng nghe kết nối đến...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Máy con đã kết nối!");

                ClientHandler clientHandler = new ClientHandler(client);
                clientHandler.DataReceived += HandleDataReceived;

                clientHandler.Start();
            }
        }

        private void HandleDataReceived(ClientHandler clientHandler, string jsonData)
        {
            Console.WriteLine(jsonData);
            try
            {
                EventData eventData = JsonConvert.DeserializeObject<EventData>(jsonData);

                switch (eventData.Type)
                {
                    case EventType.Login:
                        HandleLoginRequest(clientHandler, eventData);
                        break;

                    case EventType.Message:
                        HandleMessageRequest(clientHandler, eventData);
                        break;

                    case EventType.Order:
                        HandleOrderRequest(clientHandler, eventData);
                        break;

                    // Xử lý các loại sự kiện khác

                    default:
                        // Loại sự kiện không được hỗ trợ
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xử lý dữ liệu từ máy con: " + ex.Message);
                // Xử lý ngoại lệ và ghi log lỗi nếu cần
            }
        }

        private void HandleLoginRequest(ClientHandler clientHandler, EventData eventData)
        {
            if (eventData.Data.TryGetValue("Username", out object usernameObj) && eventData.Data.TryGetValue("Password", out object passwordObj))
            {
                string username = usernameObj?.ToString();
                string password = passwordObj?.ToString();

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    bool isAuthenticated = ValidateLogin(username, password);

                    EventData responseEventData = new EventData { Type = EventType.LoginResponse };
                    responseEventData.Data["IsAuthenticated"] = isAuthenticated;

                    string responseJsonData = JsonConvert.SerializeObject(responseEventData);

                    clientHandler.SendResponse(responseJsonData);
                    return;
                }
            }

            // Xử lý lỗi đăng nhập nếu cần
        }

        private void HandleMessageRequest(ClientHandler clientHandler, EventData eventData)
        {
            if (eventData.Data.TryGetValue("Message", out object messageObj))
            {
                string message = messageObj?.ToString();
                // Xử lý tin nhắn
            }
        }

        private void HandleOrderRequest(ClientHandler clientHandler, EventData eventData)
        {
            if (eventData.Data.TryGetValue("Food", out object foodObj) && eventData.Data.TryGetValue("Quantity", out object quantityObj))
            {
                string food = foodObj?.ToString();
                int quantity = quantityObj is int intValue ? intValue : 0;
                // Xử lý đơn đặt hàng
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Username, Password FROM KhachHang WHERE Username = @Username AND Password = @Password";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = command.ExecuteReader();

                bool loginSuccessful = reader.HasRows;

                reader.Close();

                return loginSuccessful;
            }
        }
    }
}