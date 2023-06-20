using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Food_Order : Form
    {
        private string sessionUsername;

        public Food_Order(string username)
        {
            sessionUsername = username;
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Thêm cột
            datagrid_Food.Columns.Add("ID", "Mã món");
            datagrid_Food.Columns.Add("Name", "Tên món");
            datagrid_Food.Columns.Add("Price", "Giá tiền");
            datagrid_Food.Columns.Add("Note", "Mô tả");

            // Set the auto-size mode of columns to fill
            foreach (DataGridViewColumn column in datagrid_Food.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Enable auto-sizing of columns
            datagrid_Food.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Khi người dùng ấn vào 1 ô thì tự động select toàn bộ hàng thay vì chỉ 1 ô
            datagrid_Food.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Fetch dữ liệu từ server
            FoodDataRequest();
        }

        private void Food_Order_Load(object sender, EventArgs e)
        {

        }

        private bool FoodDataRequest()
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ConfigurationManager.AppSettings["ServerIP"], Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]));
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi kết nối đến server!");
                    return false;
                }

                Console.WriteLine("Kết nối thành công tới máy trạm!");

                EventData eventData = new EventData { Type = EventType.Food_Get_Request };
                eventData.Data["Username"] = sessionUsername;

                // Mã hoá thành dạng Json
                string jsonData = JsonConvert.SerializeObject(eventData);

                // Gửi yêu cầu đến server
                byte[] data = Encoding.ASCII.GetBytes(jsonData);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                // Đọc phản hồi từ server
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJsonData = Encoding.Default.GetString(buffer, 0, bytesRead);
                Console.Write(responseJsonData);

                // Chuyển chuỗi JSON thành đối tượng EventData
                EventData responseData;
                try
                {
                    responseData = JsonConvert.DeserializeObject<EventData>(responseJsonData, new JsonSerializerSettings
                    {
                        CheckAdditionalContent = true
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi chuyển đổi dữ liệu từ JSON: " + ex.Message);
                    return false; // Hoặc xử lý lỗi theo logic của bạn
                }

                // Kiểm tra loại sự kiện phản hồi từ server
                if (responseData.Type == EventType.Food_GetResponse)
                {
                    // Lấy danh sách đồ ăn từ dữ liệu phản hồi
                    if (responseData.Data.TryGetValue("FoodData", out object foodDataObj) && foodDataObj is JArray foodArrayJson)
                    {
                        List<Food> foodArray = new List<Food>();
                        foreach (JToken foodJson in foodArrayJson)
                        {
                            Food food = foodJson.ToObject<Food>();
                            foodArray.Add(food);
                        }

                        // Xóa dữ liệu cũ trong DataGridView
                        datagrid_Food.Rows.Clear();

                        // Thêm dữ liệu mới từ danh sách đồ ăn vào DataGridView
                        foreach (Food food in foodArray)
                        {
                            datagrid_Food.Rows.Add(food.Id, food.Name, food.Price, food.Note);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Lỗi khi lấy dữ liệu đồ ăn từ phản hồi!");
                        return false; // Hoặc xử lý lỗi theo logic của bạn
                    }
                }
                else
                {
                    Console.WriteLine("Phản hồi từ server không đúng loại sự kiện!");
                    return false; // Hoặc xử lý lỗi theo logic của bạn
                }

                client.Close();

                return true; // Hoặc giá trị phù hợp tùy vào logic của bạn
            }
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (datagrid_Food.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một món để gửi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy hàng được chọn đầu tiên
            DataGridViewRow selectedRow = datagrid_Food.SelectedRows[0];

            // Trích xuất dữ liệu từ hàng được chọn
            string foodId = selectedRow.Cells["ID"].Value.ToString();
            string foodName = selectedRow.Cells["Name"].Value.ToString();
            string foodPrice = selectedRow.Cells["Price"].Value.ToString();
            string foodNote = selectedRow.Cells["Note"].Value.ToString();

            bool isSuccess = OrderFood(foodId);

            if (isSuccess)
            {
                MessageBox.Show("Đặt món thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình truyền dữ liệu tới máy chủ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool OrderFood(string foodID)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ConfigurationManager.AppSettings["ServerIP"], Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]));
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi kết nối đến server!");
                    return false;
                }

                Console.WriteLine("Kết nối thành công tới máy trạm!");

                EventData eventData = new EventData { Type = EventType.Order };
                eventData.Data["ID"] = foodID;
                eventData.Data["Username"] = sessionUsername;

                string jsonData = JsonConvert.SerializeObject(eventData);

                byte[] data = Encoding.ASCII.GetBytes(jsonData);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                EventData responseEventData = JsonConvert.DeserializeObject<EventData>(responseJsonData);
                bool isSuccess = (bool)responseEventData.Data["IsSuccess"];

                client.Close();

                return isSuccess;
            }
        }
    }
}

