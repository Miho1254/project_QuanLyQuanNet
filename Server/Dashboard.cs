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
        string connectionString = ConfigurationManager.ConnectionStrings["Server.Properties.Settings.CSDL_Server_QuanNetConnectionString"].ConnectionString;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_taikhoan_Click(object sender, EventArgs e)
        {
            // Mở form tạo tài khoản người dùng và truyền this (form Dashboard) vào constructor của form CreateUserAccount
            CreateUserAccount createUserAccountForm = new CreateUserAccount(this);
            createUserAccountForm.Show();
        }

        private void btn_themgio_Click(object sender, EventArgs e)
        {
            // Mở form thêm số dư vào tài khoản người dùng
            AddUserBalance addUserBalanceForm = new AddUserBalance(this);
            addUserBalanceForm.Show();
        }

        private void LoadKhachHangData()
        {
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

                    dgvKhachHang.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void UpdateDataGridViewKhachHang()
        {
            LoadKhachHangData();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadKhachHangData();
        }

       
    }
}
