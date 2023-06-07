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
        LoginResponse,  // Sự kiện phản hồi đăng nhập
        PasswordChange, // Sự kiện đổi password từ Client
        PasswordChangeResponse, // Sự kiện phản hồi đổi mật khẩu
        // Thêm các loại sự kiện khác nếu cần
    }

    public class SocketServer
    {
        private TcpListener listener;

        public SocketServer()
        {

        }

        public void Start(string ipAddress, int port, bool autocheckIP = false)
        {
            // Nếu autocheckIP = true, lấy địa chỉ IP tự động
            if (autocheckIP)
            {
                ipAddress = GetLocalIPAddress();
            }

            listener = new TcpListener(IPAddress.Parse(ipAddress), port);
            Console.WriteLine("Socket đã được khởi tạo với địa chỉ IP: " + ipAddress);

            // Bắt đầu lắng nghe kết nối đến
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
                    case EventType.PasswordChange:
                        HandlePasswordChangeRequest(clientHandler, eventData);
                        break;
                    // ...
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

        private void HandlePasswordChangeRequest(ClientHandler clientHandler, EventData eventData)
        {
            if (eventData.Data.TryGetValue("Username", out object usernameObj) &&
                eventData.Data.TryGetValue("NewPassword", out object newPasswordObj))
            {
                string username = usernameObj?.ToString();
                string newPassword = newPasswordObj?.ToString();

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(newPassword))
                {
                    bool passwordChanged = ChangePassword(username, newPassword);

                    EventData responseEventData = new EventData { Type = EventType.PasswordChangeResponse };
                    responseEventData.Data["PasswordChanged"] = passwordChanged;

                    string responseJsonData = JsonConvert.SerializeObject(responseEventData);

                    clientHandler.SendResponse(responseJsonData);
                    return;
                }
            }

            // Xử lý lỗi đổi mật khẩu nếu cần
        }

        private bool ChangePassword(string username, string newPassword)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện cập nhật mật khẩu
                string updateQuery = "UPDATE KhachHang SET Password = @NewPassword WHERE Username = @Username";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@Username", username);
                updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Mật khẩu đã được thay đổi.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Không thể thay đổi mật khẩu.");
                    return false;
                }
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

        static string GetLocalIPAddress()
        {
            // Lấy tất cả các địa chỉ IP của máy tính
            IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());

            // Lọc và trả về địa chỉ IP LAN (IPv4)
            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(address))
                {
                    return address.ToString();
                }
            }

            throw new Exception("Không tìm thấy địa chỉ IP LAN trên máy tính.");
        }
    }
}