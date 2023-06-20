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
using Bunifu.Framework.UI;

namespace Server
{
    public partial class EmployeeManage : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public EmployeeManage()
        {
            InitializeComponent();
        }

        private void EmployeeManage_Load(object sender, EventArgs e)
        {
            LoadEmployeeData(); // Tải dữ liệu nhân viên lên DataGridView
            LoadPositions(); // Tải danh sách chức vụ lên ComboBox
        }

        private void LoadEmployeeData()
        {
            // Truy vấn SELECT để lấy dữ liệu từ bảng NhanVien
            string selectQuery = "SELECT * FROM NhanVien";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                DataTable employeeTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(employeeTable);
                    dataGridView_NhanVien.DataSource = employeeTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPositions()
        {
            // Tạo danh sách chứa các chức vụ và giá trị tương ứng
            Dictionary<string, string> positions = new Dictionary<string, string>
            {
                { "QUANLY", "Quản lý" },
                { "THUNGAN", "Thu ngân" }
            };

            // Thiết lập hiển thị và giá trị cho ComboBox
            cbx_ChucVu.DisplayMember = "Value";
            cbx_ChucVu.ValueMember = "Key";
            cbx_ChucVu.DataSource = new BindingSource(positions, null);
        }

        private void btn_TaoNhanVien_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox và ComboBox
            string tenNhanVien = tbx_TenNhanVien.Text;
            string chucVu = cbx_ChucVu.SelectedValue.ToString();
            string sdt = tbx_SDT.Text;
            string username = tbx_Username.Text;
            string password = tbx_Password.Text;

            // Tạo mã nhân viên ngẫu nhiên
            string maNhanVien = GenerateUniqueNumber();

            // Tạo truy vấn INSERT để tạo nhân viên mới trong CSDL
            string insertQuery = $"INSERT INTO NhanVien (MaNhanVien, HoTen, SDT, ChucVu, Username, Password) VALUES ('{maNhanVien}', '{tenNhanVien}', '{sdt}', '{chucVu}', '{username}', '{password}')";

            // Thực hiện truy vấn INSERT vào CSDL
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã tạo nhân viên mới thành công! Mã nhân viên: " + maNhanVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadEmployeeData(); // Gọi hàm để tải lại dữ liệu nhân viên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XoaNhanVien_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn hàng nào trên DataGridView chưa
            if (dataGridView_NhanVien.SelectedRows.Count > 0)
            {
                string selectedEmployeeId = dataGridView_NhanVien.SelectedRows[0].Cells["MaNhanVien"].Value.ToString();
                DeleteEmployee(selectedEmployeeId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteEmployee(string employeeId)
        {
            // Tạo truy vấn DELETE để xoá nhân viên khỏi CSDL
            string deleteQuery = $"DELETE FROM NhanVien WHERE MaNhanVien = @SelectedEmployeeId";

            // Thực hiện truy vấn DELETE vào CSDL
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@SelectedEmployeeId", employeeId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã xoá nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadEmployeeData(); // Gọi hàm để tải lại dữ liệu nhân viên
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                uniqueNumber = "NV" + random.Next(10000, 99999).ToString("D5"); // Tạo số 5 chữ số
            } while (uniqueNumber == maxNumber);

            return uniqueNumber;
        }

        private string GetMaxUniqueNumberFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(MaNhanVien, 3, LEN(MaNhanVien)) AS INT)) FROM NhanVien WHERE MaNhanVien LIKE 'NV[0-9][0-9][0-9][0-9][0-9]'";

                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    int maxNumber = Convert.ToInt32(result);
                    return "NV" + (maxNumber + 1).ToString("D5");
                }
                else
                {
                    return "NV00001"; // Nếu không có số hiện có, bắt đầu bằng "NV00001"
                }
            }

        }

        private void btn_TimNhanVien_Click(object sender, EventArgs e)
        {
            string keyword = tbx_TimNhanVien.Text;

            // Tạo truy vấn SELECT để tìm kiếm nhân viên dựa trên tên nhân viên, chức vụ, hoặc SDT
            string selectQuery = "SELECT * FROM NhanVien " +
                                 "WHERE MaNhanVien LIKE @Keyword OR HoTen LIKE @Keyword OR ChucVu LIKE @Keyword OR SDT LIKE @Keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView_NhanVien.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
