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
            this.Hide();
            FoodManage foodManageForm = new FoodManage();
            foodManageForm.FormClosed += (s, args) => this.Show();
            foodManageForm.Show();
        }

        private void btn_QuanLyMayTram_Click(object sender, EventArgs e)
        {
            this.Hide();
            ComputerManage computerManageForm = new ComputerManage();
            computerManageForm.FormClosed += (s, args) => this.Show();
            computerManageForm.Show();
        }

        private void btn_NhanSu_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeManage employeeManageForm = new EmployeeManage();
            employeeManageForm.FormClosed += (s, args) => this.Show();
            employeeManageForm.Show();
        }

        private void btn_QuanLyHoaDon_Click(object sender, EventArgs e)
        {
            this.Hide();
            InvoiceManage invoiceManage = new InvoiceManage();
            invoiceManage.FormClosed += (s, args) => this.Show();
            invoiceManage.Show();
        }
    }
}
