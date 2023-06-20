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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class Admin_Login : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public Admin_Login()
        {
            InitializeComponent();

            this.AcceptButton = btn_Dangnhap; // Thiết lập nút "Enter" để đăng nhập
        }

        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            string username = tbx_Username.Text;
            string password = tbx_Password.Text;

            // Kiểm tra xác thực đăng nhập của người dùng
            bool isAuthenticated = ValidateAdminLogin(username, password);

            if (isAuthenticated)
            {
                // Đăng nhập thành công, lấy thông tin chức vụ
                string role = GetAdminRole(username);

                // Chuyển sang form Dashboard
                OpenDashboardForm(role);
            }
            else
            {
                // Hiển thị thông báo lỗi đăng nhập không thành công
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm kiểm tra xác thực đăng nhập của người dùng
        private bool ValidateAdminLogin(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Username, Password FROM NhanVien WHERE Username = @Username AND Password = @Password";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                object result = command.ExecuteScalar();
                bool loginSuccessful = (result != null);

                return loginSuccessful;
            }
        }

        // Hàm lấy thông tin chức vụ của người dùng
        private string GetAdminRole(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ChucVu FROM NhanVien WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                string role = command.ExecuteScalar()?.ToString();

                return role;
            }
        }

        // Hàm mở form Dashboard sau khi đăng nhập thành công
        private void OpenDashboardForm(string role)
        {
            // Hiển thị thông báo thành công
            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Chuyển sang form Dashboard và truyền chức vụ (role)
            this.Hide();
            Dashboard dashboard = new Dashboard(role);
            dashboard.FormClosed += (s, args) => this.Show();
            dashboard.Show();
        }
    }
}
