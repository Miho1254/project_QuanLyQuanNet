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
    public partial class AddUserBalance : Form
    {
        private Dashboard dashboardForm; // Instance của form Dashboard

        public AddUserBalance(Dashboard dashboardForm)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;
        }
        private void AddUserBalance_Load(object sender, EventArgs e)
        {

        }

        

        private bool IsUsernameExists(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM KhachHang WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private bool AddBalanceToUserAccount(string username, float gioChoi)
        {
            string query = "UPDATE KhachHang SET GioChoi += @GioChoi WHERE Username = @Username";

            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@GioChoi", gioChoi);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thực hiện truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

      
        private void btn_Add_Click(object sender, EventArgs e)
        {
            string username = tbx_Username.Text;
            string soDuText = tbx_SoDu.Text;

            // Kiểm tra xem tên người dùng đã tồn tại hay chưa
            if (!IsUsernameExists(username))
            {
                MessageBox.Show("Tên người dùng không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra giá trị số dư hợp lệ
            if (!int.TryParse(soDuText, out int soDu))
            {
                MessageBox.Show("Số dư không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float gioChoi = soDu / 10000.0f; // Chuyển đổi số dư thành giờ chơi

            // Thêm số dư vào tài khoản người dùng
            if (AddBalanceToUserAccount(username, gioChoi))
            {
                MessageBox.Show("Thêm số dư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbx_SoDu.Text = ""; // Đặt lại giá trị của số dư thành rỗng
                dashboardForm.UpdateDataGridViewKhachHang(); // Cập nhật DataGridView thông qua phương thức trong form Dashboard
            }
            else
            {
                MessageBox.Show("Thêm số dư thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
