using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Dashboard : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu được lấy từ cấu hình ứng dụng
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        // Biến để lưu thông tin chức vụ của người dùng
        private string userRole;

        public Dashboard(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            // Kiểm tra chức vụ của người dùng để xem có quyền truy cập vào chức năng này không
            if (userRole == "THUNGAN" || userRole == "QUANLY")
            {
                // Mở form tạo tài khoản người dùng và truyền form Dashboard vào constructor của form CreateUserAccount
                CreateUserAccount createUserAccountForm = new CreateUserAccount(this);
                createUserAccountForm.Show();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu người dùng không có quyền truy cập
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_themgio_Click(object sender, EventArgs e)
        {
            // Kiểm tra chức vụ của người dùng để xem có quyền truy cập vào chức năng này không
            if (userRole == "THUNGAN" || userRole == "QUANLY")
            {
                // Mở form thêm số dư vào tài khoản người dùng
                AddUserBalance addUserBalanceForm = new AddUserBalance(this);
                addUserBalanceForm.Show();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu người dùng không có quyền truy cập
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadKhachHangData()
        {
            // Kết nối đến cơ sở dữ liệu và truy vấn dữ liệu khách hàng
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM KhachHang";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu khách hàng trong DataGridView
                    dgvKhachHang.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ và hiển thị thông báo lỗi
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateDataGridViewKhachHang()
        {
            // Cập nhật lại dữ liệu khách hàng trong DataGridView
            LoadKhachHangData();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu khách hàng khi form được tải
            LoadKhachHangData();
        }

        private void btn_quanly_Click(object sender, EventArgs e)
        {
            // Kiểm tra chức vụ của người dùng để xem có quyền truy cập vào chức năng này không
            if (userRole == "QUANLY")
            {
                // Mở form Dashboard của quản trị viên
                Admin_Dashboard adminDashboard = new Admin_Dashboard();
                adminDashboard.Show();
            }
            else
            {
                // Hiển thị thông báo lỗi nếu người dùng không có quyền truy cập
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
