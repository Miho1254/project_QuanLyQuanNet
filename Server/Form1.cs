using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi Form1 được tải
        private async void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = true;

            // Lấy chuỗi kết nối đến cơ sở dữ liệu từ file cấu hình
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối tới SQL Server: " + ex.Message);
                }
            }

            // Sử dụng Task để lắng nghe từ socket trong một luồng riêng tránh việc đóng băng giao diện.
            await Task.Run(() =>
            {
                // Khởi tạo và bắt đầu máy chủ socket
                SocketServer socket = new SocketServer();
                socket.Start(ConfigurationManager.AppSettings["ServerIP"], Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]), false);
            });
        }
    }
}
