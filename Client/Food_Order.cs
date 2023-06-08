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
using Server;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Food_Order : Form
    {

        public Food_Order()
        {
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
        }

        private void Food_Order_Load(object sender, EventArgs e)
        {
        }

        private bool OrderFood(string username, string order)
        {

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ConfigurationManager.AppSettings["DatabaseServerIP"], Convert.ToInt32(ConfigurationManager.AppSettings["DatabaseServerPort"]));
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi kết nối đến server cơ sở dữ liệu!");
                    return false;
                }

                Console.WriteLine("Kết nối thành công tới máy trạm!");

                // Tạo sự kiện order
                EventData eventData = new EventData { Type = EventType.Order };
                eventData.Data["Username"] = username;
                eventData.Data["Order"] = order;

                // Chuyển đổi thành chuỗi JSON
                string jsonData = JsonConvert.SerializeObject(eventData);

                //Gửi order lên máy chủ
                byte[] data = Encoding.ASCII.GetBytes(jsonData);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                // Đọc phản hồi từ máy chủ
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                // Chuyển đổi phản hồi thành sự kiện
                EventData responseEventData = JsonConvert.DeserializeObject<EventData>(responseJsonData);
                bool isAuthenticated = (bool)responseEventData.Data["IsAuthenticated"];

                client.Close();

                return isAuthenticated;


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

            // Lấy hàng được chọn
            DataGridViewRow selectedRow = datagrid_Food.SelectedRows[0];

            // Trích xuất dữ liệu từ hàng được chọn
            string foodId = selectedRow.Cells["ID"].Value.ToString();
            string foodName = selectedRow.Cells["Name"].Value.ToString();
            string foodPrice = selectedRow.Cells["Price"].Value.ToString();
            string foodNote = selectedRow.Cells["Note"].Value.ToString();
            // Khởi tạo danh sách foodItems
         //   List<FoodItem> foodItems = new List<FoodItem>();

            // Lấy dữ liệu từ cơ sở dữ liệu hoặc nguồn dữ liệu khác
            // và thêm vào danh sách foodItems

            // Hiển thị dữ liệu lên DataGridView
          /*  foreach (var foodItem in foodItems)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(datagrid_Food);
                row.Cells[0].Value = foodItem.ID;
                row.Cells[1].Value = foodItem.Name;
                row.Cells[2].Value = foodItem.Price;
                row.Cells[3].Value = foodItem.Note;
                datagrid_Food.Rows.Add(row);
            }

            */
            // Hiển thị thông báo thành công
            MessageBox.Show("Món đã được đặt thành công!");
            Close();
        }


    }
}

