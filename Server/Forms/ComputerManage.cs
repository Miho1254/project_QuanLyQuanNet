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
    public partial class ComputerManage : Form
    {
        // Chuỗi kết nối tới cơ sở dữ liệu
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public ComputerManage()
        {
            InitializeComponent();
        }

        private void ComputerManage_Load(object sender, EventArgs e)
        {
            // Sự kiện xảy ra khi form được tải lên
            // Gọi phương thức để tải dữ liệu máy tính
            LoadComputerData();
        }

        private void btn_TaoMayTinh_Click(object sender, EventArgs e)
        {
            // Sự kiện xảy ra khi nhấn nút "Tạo máy tính"
            string maMayTinh = "MAY" + tbx_IDMayTinh.Text;
            string ipMayTinh = tbx_IPMayTinh.Text;

            if (!string.IsNullOrEmpty(tbx_IDMayTinh.Text) && !string.IsNullOrEmpty(ipMayTinh))
            {
                // Kiểm tra xem ID máy tính có chứa ký tự không phải số hay không
                if (!int.TryParse(tbx_IDMayTinh.Text, out _))
                {
                    MessageBox.Show("ID máy tính phải là một số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo truy vấn INSERT để tạo máy tính mới trong CSDL
                string insertQuery = "INSERT INTO MayTinh (MaMayTinh, IP) " +
                    "VALUES (@MaMayTinh, @IP)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(insertQuery, connection);
                        command.Parameters.AddWithValue("@MaMayTinh", maMayTinh);
                        command.Parameters.AddWithValue("@IP", ipMayTinh);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Đã tạo máy tính mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Gọi phương thức để tải lại dữ liệu máy tính
                        LoadComputerData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin máy tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_XoaMayTinh_Click(object sender, EventArgs e)
        {
            // Sự kiện xảy ra khi nhấn nút "Xóa máy tính"
            // Kiểm tra xem đã chọn hàng nào trên DataGridView chưa
            if (datagridview_MayTinh.SelectedRows.Count > 0)
            {
                // Lấy mã máy tính được chọn từ cột "MaMayTinh" trên DataGridView
                string selectedComputerId = datagridview_MayTinh.SelectedRows[0].Cells["MaMayTinh"].Value.ToString();

                // Gọi phương thức để xoá máy tính
                DeleteComputer(selectedComputerId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một máy tính để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteComputer(string computerId)
        {
            // Phương thức để xoá máy tính từ CSDL
            // Tạo truy vấn DELETE để xoá máy tính từ CSDL
            string deleteQuery = "DELETE FROM MayTinh WHERE MaMayTinh = @MaMayTinh";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@MaMayTinh", computerId);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Đã xoá máy tính thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Gọi phương thức để tải lại dữ liệu máy tính
                    LoadComputerData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadComputerData()
        {
            // Phương thức để tải dữ liệu máy tính từ CSDL và hiển thị lên DataGridView
            // Tạo truy vấn SELECT để lấy dữ liệu máy tính từ CSDL
            string selectQuery = "SELECT MaMayTinh, IP FROM MayTinh";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    datagridview_MayTinh.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Timmaytinh_Click(object sender, EventArgs e)
        {
            // Sự kiện xảy ra khi nhấn nút "Tìm máy tính"
            string keyword = tbx_TimMayTinh.Text;

            // Tạo truy vấn SELECT để tìm kiếm máy tính dựa trên tên máy hoặc ID máy
            string selectQuery = "SELECT MaMayTinh, IP FROM MayTinh " +
                                 "WHERE MaMayTinh LIKE @Keyword OR IP LIKE @Keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    datagridview_MayTinh.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
