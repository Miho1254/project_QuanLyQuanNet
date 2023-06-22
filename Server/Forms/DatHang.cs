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
    public partial class DatHang : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public DatHang()
        {
            InitializeComponent();
        }

        private void btn_XuatHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào đã được chọn hay không
            if (datagridview_HoaDon.SelectedRows.Count > 0)
            {
                // Lặp qua các dòng đã được chọn
                foreach (DataGridViewRow row in datagridview_HoaDon.SelectedRows)
                {
                    string maDonHang = row.Cells["MaDonHang"].Value.ToString();
                    string maNhanVien = row.Cells["MaNhanVien"].Value.ToString();

                    // Thêm hóa đơn vào cơ sở dữ liệu
                    InsertHoaDon(maDonHang, maNhanVien);
                }

                MessageBox.Show("Đã xuất hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm thêm hóa đơn vào cơ sở dữ liệu
        private void InsertHoaDon(string maDonHang, string maNhanVien)
        {
            string insertQuery = "INSERT INTO HoaDon (MaDonHang, MaNhanVien) VALUES (@MaDonHang, @MaNhanVien)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@MaDonHang", maDonHang);
                command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cSDL_Server_QuanNetDataSet.ChiTietDonHang' table. You can move, or remove it, as needed.
            this.chiTietDonHangTableAdapter.Fill(this.cSDL_Server_QuanNetDataSet.ChiTietDonHang);
            LoadInvoiceData();

            // Set the auto-size mode of columns to fill
            foreach (DataGridViewColumn column in datagridview_HoaDon.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Enable auto-sizing of columns
            datagridview_HoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Khi người dùng ấn vào 1 ô thì tự động select toàn bộ hàng thay vì chỉ 1 ô
            datagridview_HoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        // Tải dữ liệu hóa đơn lên DataGridView
        private void LoadInvoiceData()
        {
            string selectQuery = "SELECT * FROM ChiTietDonHang";
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
    }
}
