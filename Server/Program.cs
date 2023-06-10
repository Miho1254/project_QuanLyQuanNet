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
        private static Mutex mutex = new Mutex(true, "{YourUniqueMutexName}");

        [STAThread]
        private static void Main()
        {
            if (!IsSqlServerRunning())
            {
                StartSqlServer();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           

            // Chạy vòng lặp sự kiện của ứng dụng
            Application.Run (new InvoiceManage());
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
