using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal static class Program
    {
       

        [STAThread]
        private static void Main()
        {
            if (!IsSqlServerRunning())
            {
                StartSqlServer();
            }

            // Khởi động socket trong một Task không đồng bộ
            Task socketTask = Task.Run(() =>
            {
                SocketServer socket = new SocketServer();
                socket.Start(ConfigurationManager.AppSettings["ServerIP"], Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]), false);
                Console.WriteLine("Đã khởi tạo socket");
            });

            // Hiển thị form Admin_Login
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Admin_Login adminLogin = new Admin_Login();
            Application.Run(adminLogin);

            // Đợi socketTask hoàn thành
            socketTask.Wait();

            // Khởi tạo máy chủ SQL LocalDB
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
        }

        private static bool IsSqlServerRunning()
        {
            Process[] processes = Process.GetProcessesByName("sqlservr");
            return processes.Length > 0;
        }

        private static void StartSqlServer()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Thực hiện các tác vụ khởi chạy máy chủ SQL nếu cần thiết
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi kết nối tới SQL Server: " + ex.Message);
                }
            }
        }
    }
}
