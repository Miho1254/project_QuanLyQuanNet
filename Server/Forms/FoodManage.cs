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
    public partial class FoodManage : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public FoodManage()
        {
            InitializeComponent();
        }

        private void FoodManage_Load(object sender, EventArgs e)
        {
            LoadFoodData();
            // Đăng ký sự kiện CellContentClick của DataGridView
            datagridview_DoAn.CellContentClick += DataGridView_CellContentClick;
        }

        // Phương thức để tải dữ liệu đồ ăn từ CSDL và hiển thị lên DataGridView
        private void LoadFoodData()
        {
            // Truy vấn SELECT để lấy dữ liệu đồ ăn từ CSDL
            string selectQuery = "SELECT * FROM ThucAn";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                DataTable foodTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(foodTable);
                    datagridview_DoAn.DataSource = foodTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Phương thức để tạo số duy nhất cho mã đồ ăn
        private string GenerateUniqueNumber()
        {
            // Lấy số duy nhất lớn nhất hiện có trong cơ sở dữ liệu
            string maxNumber = GetMaxUniqueNumberFromDatabase();

            // Tạo số ngẫu nhiên không trùng với các số hiện có
            Random random = new Random();
            string uniqueNumber = "";

            do
            {
                uniqueNumber = "TA" + random.Next(10000, 99999).ToString("D5"); // Tạo số 5 chữ số
            } while (uniqueNumber == maxNumber);

            return uniqueNumber;
        }

        // Phương thức để lấy số duy nhất lớn nhất từ CSDL
        private string GetMaxUniqueNumberFromDatabase()
        {
            // Truy vấn SELECT để lấy số duy nhất lớn nhất từ CSDL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(MaThucAn, 3, LEN(MaThucAn)) AS INT)) FROM ThucAn WHERE MaThucAn LIKE 'TA[0-9][0-9][0-9][0-9][0-9]'";

                SqlCommand command = new SqlCommand(query, connection);
                object result = command.ExecuteScalar();

                if (result != DBNull.Value)
                {
                    int maxNumber = Convert.ToInt32(result);
                    return "TA" + (maxNumber + 1).ToString("D5");
                }
                else
                {
                    return "TA00001"; // Nếu không có số hiện có, bắt đầu bằng "TA00001"
                }
            }
        }

        // Xử lý sự kiện khi người dùng nhấn nút "Tạo đồ ăn"
        private void btn_TaoDoAn_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox
            string tenThucAn = tbx_DoAn.Text;
            decimal giaTien = decimal.Parse(tbx_GiaTien.Text);
            string moTa = tbx_MoTa.Text;
            string maThucAn = GenerateUniqueNumber();

            // Tạo truy vấn INSERT để tạo đồ ăn mới trong CSDL
            string insertQuery = $"INSERT INTO ThucAn (MaThucAn, TenThucAn, GiaTien, MoTa) VALUES ('{maThucAn}', '{tenThucAn}', {giaTien}, '{moTa}')";

            // Thực hiện truy vấn INSERT vào CSDL
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(insertQuery, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã tạo đồ ăn mới thành công! Mã đồ ăn: " + maThucAn, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadFoodData(); // Gọi hàm để tải lại dữ liệu đồ ăn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện khi người dùng nhấp vào cột "Xóa" của DataGridView
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridview_DoAn.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                string selectedFoodId = datagridview_DoAn.Rows[e.RowIndex].Cells["MaThucAn"].Value.ToString();
                DeleteFood(selectedFoodId);
            }
        }

        // Xử lý sự kiện khi người dùng nhấn nút "Xóa đồ ăn"
        private void btn_XoaDoAn_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn hàng nào trên DataGridView chưa
            if (datagridview_DoAn.SelectedRows.Count > 0)
            {
                string selectedFoodId = datagridview_DoAn.SelectedRows[0].Cells["MaThucAn"].Value.ToString();
                DeleteFood(selectedFoodId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một đồ ăn để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Phương thức để xoá một đồ ăn từ CSDL
        private void DeleteFood(string foodId)
        {
            // Tạo truy vấn DELETE để xoá món khỏi CSDL
            string deleteQuery = $"DELETE FROM ThucAn WHERE MaThucAn = @SelectedFoodId";

            // Thực hiện truy vấn DELETE vào CSDL
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@SelectedFoodId", foodId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã xoá đồ ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadFoodData(); // Gọi hàm để tải lại dữ liệu đồ ăn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
