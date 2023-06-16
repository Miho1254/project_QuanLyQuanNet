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
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public Admin_Login()
        {
            InitializeComponent();

            this.AcceptButton = btn_Dangnhap;
        }

        private void btn_Dangnhap_Click(object sender, EventArgs e)
        {
            string username = tbx_Username.Text;
            string password = tbx_Password.Text;


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
                // Hiển thị thông báo lỗi
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
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

        private void OpenDashboardForm(string role)
        {
            // Đăng nhập thành công, hiển thị thông báo thành công
            MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Chuyển sang form Dashboard và truyền chức vụ (role)
            this.Hide();
            Dashboard dashboard = new Dashboard(role);
            dashboard.FormClosed += (s, args) => this.Show();
            dashboard.Show();
        }

        private void tbx_Username_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}

