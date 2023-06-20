using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace Server
{
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

        private void Admin_Dashboard_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btn_quanlyDoan_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nút "Quản lý Đồ ăn" được nhấn

            this.Hide(); // Ẩn form hiện tại
            FoodManage foodManageForm = new FoodManage(); // Tạo mới một instance của form FoodManage
            foodManageForm.FormClosed += (s, args) => this.Show(); // Khi form FoodManage được đóng, hiển thị lại form Admin_Dashboard
            foodManageForm.Show(); // Hiển thị form FoodManage
        }

        private void btn_QuanLyMayTram_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nút "Quản lý Máy trạm" được nhấn

            this.Hide(); // Ẩn form hiện tại
            ComputerManage computerManageForm = new ComputerManage(); // Tạo mới một instance của form ComputerManage
            computerManageForm.FormClosed += (s, args) => this.Show(); // Khi form ComputerManage được đóng, hiển thị lại form Admin_Dashboard
            computerManageForm.Show(); // Hiển thị form ComputerManage
        }

        private void btn_NhanSu_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nút "Nhân sự" được nhấn

            this.Hide(); // Ẩn form hiện tại
            EmployeeManage employeeManageForm = new EmployeeManage(); // Tạo mới một instance của form EmployeeManage
            employeeManageForm.FormClosed += (s, args) => this.Show(); // Khi form EmployeeManage được đóng, hiển thị lại form Admin_Dashboard
            employeeManageForm.Show(); // Hiển thị form EmployeeManage
        }

        private void btn_QuanLyHoaDon_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nút "Quản lý Hóa đơn" được nhấn

            this.Hide(); // Ẩn form hiện tại
            InvoiceManage invoiceManage = new InvoiceManage(); // Tạo mới một instance của form InvoiceManage
            invoiceManage.FormClosed += (s, args) => this.Show(); // Khi form InvoiceManage được đóng, hiển thị lại form Admin_Dashboard
            invoiceManage.Show(); // Hiển thị form InvoiceManage
        }
    }
}
