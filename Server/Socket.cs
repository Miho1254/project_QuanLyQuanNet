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
        OrderResponse, // Sự kiện phản hồi đơn đặt hàng
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
            if (eventData.Data.TryGetValue("ID", out object foodID) && eventData.Data.TryGetValue("Username", out object usernameObj))
            {
                string foodId = foodID.ToString();
                string username = usernameObj.ToString();

                bool orderSuccess = OrderFood(foodId, username);
                string foodName = GetFoodNameById(foodId);

                // Hiển thị dialog cảnh báo người dùng đặt đồ ăn
                Food_Order_Server form = new Food_Order_Server(username, foodName);
                form.Enabled = true; // Đặt Enabled property là true
                form.ShowDialog();

                EventData responseEventData = new EventData { Type = EventType.OrderResponse };
                responseEventData.Data["IsSuccess"] = orderSuccess;

                string responseJsonData = JsonConvert.SerializeObject(responseEventData);
                clientHandler.SendResponse(responseJsonData);
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

        private bool OrderFood(string foodId, string username)
        {
            // Kết nối cơ sở dữ liệu
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Truy vấn cơ sở dữ liệu để lấy thông tin món ăn (tên và giá)
                string query = "SELECT TenThucAn, GiaTien FROM ThucAn WHERE MaThucAn = @foodId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@foodId", foodId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string foodName = reader.GetString(0);
                            decimal foodPrice = reader.GetDecimal(1);

                            // Tạo mã đơn hàng
                            string orderId = GenerateOrderId();

                            // Lấy thông tin khách hàng từ cơ sở dữ liệu
                            string customerID = GetCustomerIdByUsername(username);

                            if (customerID != null)
                            {
                                // Tính tổng tiền đơn hàng
                                decimal totalPrice = foodPrice;

                                // Thêm đơn hàng vào cơ sở dữ liệu
                                bool orderSuccess = InsertOrderToDatabase(orderId, customerID, totalPrice);

                                if (orderSuccess)
                                {
                                    // Thực hiện các thao tác khác cần thiết, ví dụ: gửi thông báo, cập nhật giao diện, ...
                                    return true; // Đặt món ăn thành công
                                }
                            }
                        }
                    }
                }
            }

            return false; // Đặt món ăn không thành công
        }

        private string GenerateOrderId()
        {
            // Tạo một số ngẫu nhiên trong khoảng từ 1000 đến 9999
            Random random = new Random();
            int randomNumber = random.Next(1000, 10000);

            // Kết hợp số ngẫu nhiên vào chuỗi "DH" để tạo mã đơn hàng
            string orderId = "DH" + randomNumber.ToString();

            return orderId;
        }

        private string GetCustomerIdByUsername(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MaKhachHang FROM KhachHang WHERE Username = @username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString(); // Trả về ID của khách hàng
                    }
                }
            }

            return null; // Không tìm thấy khách hàng
        }

        private string GetFoodNameById(string foodID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT TenThucAn FROM ThucAn WHERE MaThucAn  = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", foodID);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return result.ToString(); // Trả về ID của khách hàng
                    }
                }
            }

            return null; // Không tìm thấy khách hàng
        }

        private bool InsertOrderToDatabase(string orderId, string customerId, decimal totalPrice)
        {
            // Kết nối cơ sở dữ liệu và thêm đơn hàng vào bảng DonHang
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO DonHang (MaDonHang, MaKhachHang, TongTien) VALUES (@orderId, @customerId, @totalPrice)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderId", orderId);
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@totalPrice", totalPrice);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Trả về true nếu thêm đơn hàng thành công
                }
            }
        }

        private List<IFood> GetFoodData()
        {
            List<IFood> foodDataList = new List<IFood>();

            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT MaThucAn, TenThucAn, GiaTien, MoTa FROM ThucAn";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string foodId = reader.GetString(0);
                            string foodName = reader.GetString(1);
                            decimal foodPrice = reader.GetDecimal(2);
                            string note = reader.IsDBNull(3) ? "Không có" : reader.GetString(3);

                            IFood foodData = new Food(foodId, foodName, foodPrice, note);
                            foodDataList.Add(foodData);
                        }
                    }
                }
            }

            return foodDataList;
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
        decimal Price { get; }
        string Note { get; }
    }

    public class Food : IFood
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Note { get; set; }

        public Food(string id, string name, decimal price, string note)
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