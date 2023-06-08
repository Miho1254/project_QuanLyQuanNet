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

        private async void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = true;

            //Khởi tạo máy chủ SQL LocalDB
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;
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

            //Khi bạn đặt mã xử lý socket trong sự kiện Form1_Load, nó sẽ chạy trên luồng chính (UI thread) của ứng dụng.
            //Do đó, việc lắng nghe liên tục từ socket sẽ gây ra trạng thái loading và làm đóng băng giao diện người dùng.
            //Sử dụng Task để lắng nghe từ socket trong một luồng riêng tránh việc đóng băng giao diện.
            await Task.Run(() =>
            {
                SocketServer socket = new SocketServer();
                socket.Start(ConfigurationManager.AppSettings["ServerIP"], Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]), false);
            });
        }
    }
}
