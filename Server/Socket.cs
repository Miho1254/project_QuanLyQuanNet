using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Server
{
    public enum EventType
    {
        Login,          // Sự kiện đăng nhập
        Message,        // Sự kiện tin nhắn
        MessageResponse,// Sự kiện phản hồi tin nhắn
        Order,          // Sự kiện đơn đặt hàng
        LoginResponse,  // Sự kiện phản hồi đăng nhập
        PasswordChange, // Sự kiện đổi password từ Client
        PasswordChangeResponse, // Sự kiện phản hồi đổi mật khẩu
        Food_Get_Request, // Sự kiện lấy dữ liệu đồ ăn
        Food_GetResponse, // Sự kiện trả dữ liệu đồ ăn
        // Thêm các loại sự kiện khác nếu cần
    }

    public class SocketServer
    {
        private TcpListener listener;
        private SemaphoreSlim semaphore;

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

            // Số lượng luồng tối đa
            int maxThreads = 10;
            // Khởi tạo Semaphore với số lượng luồng tối đa
            semaphore = new SemaphoreSlim(maxThreads, maxThreads);

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Máy con đã kết nối!");

                // Sử dụng Semaphore để kiểm soát số lượng luồng
                semaphore.Wait();

                // Tạo một luồng mới để xử lý kết nối từ máy khách
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }

        }

        private void HandleClient(TcpClient client)
        {
            // Tạo một đối tượng ClientHandler cho máy khách
            ClientHandler clientHandler = new ClientHandler(client);
            clientHandler.DataReceived += HandleDataReceived;

            clientHandler.Start();

            // Giải phóng Semaphore sau khi hoàn thành xử lý
            semaphore.Release();
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
                    case EventType.Food_Get_Request:
                        HandleFoodRequest(clientHandler, eventData);
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
                Console.WriteLine(ex);
                // Xử lý ngoại lệ và ghi log lỗi nếu cần
            }
        }

        private void HandleFoodRequest(ClientHandler clientHandler, EventData eventData)
        {
            // Gọi phương thức GetFoodData để lấy danh sách IFood từ cơ sở dữ liệu
            List<IFood> foodData = GetFoodData();

            // Chuyển đổi danh sách IFood thành mảng IFood[]
            IFood[] foodArray = foodData.ToArray();

            // Tạo đối tượng EventData để chứa dữ liệu phản hồi
            EventData responseEventData = new EventData { Type = EventType.Food_GetResponse };
            responseEventData.Data["FoodData"] = foodArray;

            // Nén thành JSON và chuyển về client
            string responseJsonData = JsonConvert.SerializeObject(responseEventData, Formatting.None, new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.Default,
            });
            responseJsonData = Encoding.UTF8.GetString(Encoding.Default.GetBytes(responseJsonData));
            clientHandler.SendResponse(responseJsonData);
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
            Console.WriteLine("Running");

            if (eventData.Data.TryGetValue("Message", out object messageObj) && eventData.Data.TryGetValue("Username", out object usernameObj))
            {
                Console.WriteLine("Running HandleMessageRequest");
                string message = messageObj?.ToString();
                string username = usernameObj?.ToString();

                // Xử lý tin nhắn từ client
                Console.WriteLine("Nhận được tin nhắn từ client: " + message);
                AdminContact_Server from = new AdminContact_Server(username, message);
                from.ShowDialog();

                // Gửi phản hồi cho client
                EventData responseEventData = new EventData { Type = EventType.MessageResponse };
                responseEventData.Data["Response"] = "Success";
                string responseJsonData = JsonConvert.SerializeObject(responseEventData);
                clientHandler.SendResponse(responseJsonData);

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

        public List<IFood> GetFoodData()
        {
            List<IFood> foodData = new List<IFood>();
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            // Kết nối và truy vấn SQL Server để lấy dữ liệu đồ ăn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ThucAn", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Đọc dữ liệu từ SqlDataReader và thêm vào danh sách foodData
                            string id = reader.GetString(0);
                            string name = reader.GetString(1);
                            string note = reader.IsDBNull(2) ? null : reader.GetString(2);
                            double? price = reader.IsDBNull(4) ? null : (double?)reader.GetDouble(4);

                            Food food = new Food(id, name, (double)price, note);
                            foodData.Add(food);
                        }
                    }
                }
            }

            return foodData;
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

    public interface IFood
    {
        string Id { get; }
        string Name { get; }
        double Price { get; }
        string Note { get; }
    }

    public class Food : IFood
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Note { get; set; }

        public Food(string id, string name, double price, string note)
        {
            Id = id;
            Name = name;
            Price = price;
            Note = note;
        }
    }

    public class Food_Data_Request
    {
        public IFood[] FoodDataRequest(string jsonData)
        {
            try
            {
                var jArray = JArray.Parse(jsonData);
                var foodArray = jArray.Select(item => item.ToObject<Food>() as IFood).ToArray();
                return foodArray;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi chuyển đổi dữ liệu từ JSON: " + ex.Message);
                return null; // Or handle the error according to your logic
            }
        }
    }
}