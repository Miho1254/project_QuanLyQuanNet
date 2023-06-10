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
using Newtonsoft.Json;

namespace Server
{
    public partial class CreateUserAccount : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        private Dashboard dashboardForm; // Instance của form Dashboard

        public CreateUserAccount(Dashboard dashboardForm)
        {
            InitializeComponent();
            this.dashboardForm = dashboardForm;
        }

        private void btn_Tao_Click(object sender, EventArgs e)
        {
            string username = tbx_Username.Text;
            string password = tbx_Password.Text;
            string gioChoi = tbx_SoDu.Text;

            // Tạo số duy nhất ngẫu nhiên
            string uniqueNumber = GenerateUniqueNumber();

            // Tạo MaKhachHang bằng cách kết hợp tiền tố "KH" và số duy nhất
            string maKhachHang = "KH" + uniqueNumber;

            // Kiểm tra xem tên người dùng đã tồn tại hay chưa
            if (IsUsernameExists(username))
            {
                MessageBox.Show("Tên người dùng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm dữ liệu vào cơ sở dữ liệu
            InsertUserAccount(maKhachHang, username, password, gioChoi);

            // Cập nhật DataGridView thông qua phương thức trong form Dashboard
            dashboardForm.UpdateDataGridViewKhachHang();

            // Đặt lại các trường nhập liệu
            tbx_Username.Text = "";
            tbx_Password.Text = "";
            tbx_SoDu.Text = "";

            MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateUniqueNumber()
        {
            // Lấy số duy nhất lớn nhất hiện có trong cơ sở dữ liệu
            string maxNumber = GetMaxUniqueNumberFromDatabase();

            // Tạo số ngẫu nhiên không trùng với các số hiện có
            Random random = new Random();
            string uniqueNumber = "";

            do
            {
                uniqueNumber = random.Next(10000, 99999).ToString("D5"); // Tạo số 5 chữ số
            } while (uniqueNumber == maxNumber);

            return uniqueNumber;
        }

        private string GetMaxUniqueNumberFromDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(MaKhachHang, 3, LEN(MaKhachHang)) AS INT)) FROM KhachHang WHERE MaKhachHang LIKE 'KH[0-9][0-9][0-9][0-9][0-9]'";

                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    int maxNumber = Convert.ToInt32(result);
                    return (maxNumber + 1).ToString("D5");
                }
                else
                {
                    return "00000"; // Nếu không có số hiện có, bắt đầu bằng "00000"
                }
            }
        }

        private bool IsUsernameExists(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM KhachHang WHERE Username = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void InsertUserAccount(string maKhachHang, string username, string password, string gioChoi)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tạo một transaction để thực hiện cả việc thêm tài khoản và cập nhật mật khẩu
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    string insertQuery = "INSERT INTO KhachHang (MaKhachHang, Username, Password, GioChoi) VALUES (@MaKhachHang, @Username, @Password, @GioChoi)";

                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction);
                    insertCommand.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    insertCommand.Parameters.AddWithValue("@Username", username);
                    insertCommand.Parameters.AddWithValue("@Password", password);

                    // Chuyển đổi số dư sang giờ chơi
                    if (int.TryParse(gioChoi, out int soDu))
                    {
                        float gioChoiValue = soDu / 10000.0f; // Chia cho 10000 để chuyển đổi sang giờ chơi
                        insertCommand.Parameters.AddWithValue("@GioChoi", gioChoiValue);
                    }
                    else
                    {
                        // Xử lý giá trị số dư không hợp lệ
                        MessageBox.Show("Số dư không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    insertCommand.ExecuteNonQuery();

                    // Cập nhật mật khẩu
                    string newPassword = tbx_Password.Text; // Lấy mật khẩu mới từ textbox
                    string updateQuery = "UPDATE KhachHang SET Password = @NewPassword WHERE MaKhachHang = @MaKhachHang";

                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction);
                    updateCommand.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    updateCommand.Parameters.AddWithValue("@NewPassword", newPassword);

                    updateCommand.ExecuteNonQuery();

                    // Hoàn thành transaction
                    transaction.Commit();

                    Console.WriteLine("Tạo tài khoản và cập nhật mật khẩu thành công.");
                    

                }
                catch (Exception ex)
                {
                    // Xảy ra lỗi, rollback transaction
                    transaction.Rollback();
                    Console.WriteLine("Không thể tạo tài khoản và cập nhật mật khẩu: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối sau khi thực hiện xong
                    connection.Close();
                }
            }
        }
        private void CreateUserAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Lấy các thông tin tài khoản từ các trường nhập liệu
            string username = tbx_Username.Text;
            string password = tbx_Password.Text;
            string gioChoi = tbx_SoDu.Text;

            // Tạo số duy nhất ngẫu nhiên
            string uniqueNumber = GenerateUniqueNumber();

            // Tạo MaKhachHang bằng cách kết hợp tiền tố "KH" và số duy nhất
            string maKhachHang = "KH" + uniqueNumber;

            // Kiểm tra xem tên người dùng đã tồn tại hay chưa
            if (IsUsernameExists(username))
            {
                MessageBox.Show("Tên người dùng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thêm dữ liệu vào cơ sở dữ liệu
            InsertUserAccount(maKhachHang, username, password, gioChoi);

            // Cập nhật DataGridView thông qua phương thức trong form Dashboard
            dashboardForm.UpdateDataGridViewKhachHang();

            // Hiển thị thông báo thành công
            MessageBox.Show("Tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




    }

}


    
