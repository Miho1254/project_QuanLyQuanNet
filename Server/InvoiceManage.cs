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
using System.IO;

namespace Server
{
    public partial class InvoiceManage : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public InvoiceManage()
        {
            InitializeComponent();
        }

        private void InvoiceManage_Load(object sender, EventArgs e)
        {
            LoadInvoiceData();
            // Đăng ký sự kiện CellContentClick của DataGridView
            datagridview_HoaDon.CellContentClick += DataGridView_CellContentClick;
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridview_HoaDon.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                int selectedInvoiceId = Convert.ToInt32(datagridview_HoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value);
                DeleteInvoice(selectedInvoiceId);
            }
        }
        private void btn_XuatHoaDon_Click(object sender, EventArgs e)
        {
            string maDonHang = tbx_MaDonHang.Text;

            if (!string.IsNullOrEmpty(maDonHang))
            {
                // Kiểm tra xem mã đơn hàng có tồn tại trong CSDL hay không
                bool isValidDonHang = CheckDonHangExistence(maDonHang);

                if (isValidDonHang)
                {
                    CreateInvoiceFromDonHang(maDonHang);
                }
                else
                {
                    MessageBox.Show("Mã đơn hàng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã đơn hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool CheckDonHangExistence(string maDonHang)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DonHang WHERE MaDonHang = @MaDonHang";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MaDonHang", maDonHang);

                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        private void CreateInvoiceFromDonHang(string maDonHang)
        {
            // Lấy thông tin đơn hàng từ CSDL
            string selectQuery = "SELECT * FROM DonHang WHERE MaDonHang = @MaDonHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@MaDonHang", maDonHang);
                DataTable donHangTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(donHangTable);

                    if (donHangTable.Rows.Count > 0)
                    {
                        DataRow donHangRow = donHangTable.Rows[0];
                        string maHoaDon = maDonHang;
                        string ngayTao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string maKhachHang = donHangRow["MaKhachHang"].ToString();
                        decimal tongTien = Convert.ToDecimal(donHangRow["TongTien"]);

                        // Tạo truy vấn INSERT để tạo hoá đơn mới trong CSDL
                        string insertQuery = "INSERT INTO HoaDon (MaHoaDon, NgayTao, MaKhachHang, TongTien) " +
                            "VALUES (@MaHoaDon, @NgayTao, @MaKhachHang, @TongTien)";

                        // Thực hiện truy vấn INSERT vào CSDL
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                            command.Parameters.AddWithValue("@NgayTao", ngayTao);
                            command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                            command.Parameters.AddWithValue("@TongTien", tongTien);

                            command.ExecuteNonQuery();

                            MessageBox.Show("Đã tạo hoá đơn mới thành công! Mã hoá đơn: " + maHoaDon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadInvoiceData(); // Gọi hàm để tải lại dữ liệu hoá đơn
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy đơn hàng có mã: " + maDonHang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_XoaHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn hàng nào trên DataGridView chưa
            if (datagridview_HoaDon.SelectedRows.Count > 0)
            {
                // Lấy ID của hoá đơn được chọn từ cột "MaHoaDon" trên DataGridView
                int selectedInvoiceId = Convert.ToInt32(datagridview_HoaDon.SelectedRows[0].Cells["MaHoaDon"].Value);
                DeleteInvoice(selectedInvoiceId);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hoá đơn để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void DeleteInvoice(int invoiceId)
        {
            // Tạo truy vấn DELETE để xoá hoá đơn khỏi CSDL
            string deleteQuery = "DELETE FROM HoaDon WHERE MaHoaDon = @SelectedInvoiceId";

            // Thực hiện truy vấn DELETE vào CSDL
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@SelectedInvoiceId", invoiceId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã xoá hoá đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadInvoiceData(); // Gọi hàm để tải lại dữ liệu hoá đơn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XuatRaExcel_Click(object sender, EventArgs e)
        {
           
        }
  
        private void LoadInvoiceData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM HoaDon";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable invoiceTable = new DataTable();

                dataAdapter.Fill(invoiceTable);
                datagridview_HoaDon.DataSource = invoiceTable;
            }
        }

    }
}
