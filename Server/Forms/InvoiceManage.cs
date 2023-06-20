using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace Server
{
    public partial class InvoiceManage : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public InvoiceManage()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện khi Form InvoiceManage được tải
        private void InvoiceManage_Load(object sender, EventArgs e)
        {
            LoadInvoiceData();
            // Đăng ký sự kiện CellContentClick của DataGridView
            datagridview_HoaDon.CellContentClick += DataGridView_CellContentClick;
        }

        // Xử lý sự kiện CellContentClick của DataGridView
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridview_HoaDon.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                // Lấy MaHoaDon của hàng được chọn trong DataGridView
                int selectedInvoiceId = Convert.ToInt32(datagridview_HoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value);
                DeleteInvoice(selectedInvoiceId);
            }
        }

        // Xử lý sự kiện khi nút "Xuất hóa đơn" được nhấn
        private void btn_XuatHoaDon_Click(object sender, EventArgs e)
        {
            string keyword = tbx_MaDonHang.Text;

            // Tạo truy vấn SELECT để tìm kiếm hóa đơn dựa trên mã đơn hàng
            string selectQuery = "SELECT * FROM HoaDon WHERE MaDonHang LIKE @Keyword OR MaNhanVien LIKE @Keyword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    datagridview_HoaDon.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xóa hóa đơn dựa trên MaDonHang
        private void DeleteInvoice(int invoiceId)
        {
            string deleteQuery = "DELETE FROM HoaDon WHERE MaDonHang = @MaDonHang";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@MaDonHang", invoiceId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadInvoiceData();
        }

        // Tải dữ liệu hóa đơn lên DataGridView
        private void LoadInvoiceData()
        {
            string selectQuery = "SELECT * FROM HoaDon";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);
                DataTable invoiceTable = new DataTable();

                try
                {
                    connection.Open();
                    dataAdapter.Fill(invoiceTable);
                    datagridview_HoaDon.DataSource = invoiceTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xử lý sự kiện khi nút "Xóa hóa đơn" được nhấn
        private void btn_XoaHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn hàng nào trên DataGridView chưa
            if (datagridview_HoaDon.SelectedRows.Count > 0)
            {
                // Lấy MaDonHang của hóa đơn được chọn từ cột "MaDonHang" trên DataGridView
                if (datagridview_HoaDon.SelectedRows[0].Cells["MaDonHang"].Value != null)
                {
                    string selectedInvoiceIdString = datagridview_HoaDon.SelectedRows[0].Cells["MaDonHang"].Value.ToString();

                    if (int.TryParse(selectedInvoiceIdString, out int selectedInvoiceId))
                    {
                        DeleteInvoice(selectedInvoiceId);
                    }
                    else
                    {
                        MessageBox.Show("Giá trị không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Không có giá trị được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Xử lý sự kiện khi nút "Xuất ra Excel" được nhấn
        private void btn_XuatRaExcel_Click(object sender, EventArgs e)
        {
            if (datagridview_HoaDon.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("HoaDon");
                        int rowCount = datagridview_HoaDon.Rows.Count;
                        int columnCount = datagridview_HoaDon.Columns.Count;

                        // Đổ dữ liệu từ DataGridView vào Excel
                        for (int row = 1; row <= rowCount; row++)
                        {
                            for (int column = 1; column <= columnCount; column++)
                            {
                                if (row == 1)
                                {
                                    worksheet.Cells[row, column].Value = datagridview_HoaDon.Columns[column - 1].HeaderText;
                                }

                                worksheet.Cells[row + 1, column].Value = datagridview_HoaDon.Rows[row - 1].Cells[column - 1].Value?.ToString();
                            }
                        }

                        FileInfo excelFile = new FileInfo(filePath);
                        excelPackage.SaveAs(excelFile);
                    }

                    MessageBox.Show("Xuất file Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
