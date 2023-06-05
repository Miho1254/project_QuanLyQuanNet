using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_QuanLyQuanNet
{
    public partial class Client_Login_Form : Form
    {
        public Client_Login_Form()
        {
            InitializeComponent();
           
        }

        private void Client_Login_Form_Load(object sender, EventArgs e)
        {
            // Mở rộng form để điền vào toàn bộ màn hình
            this.WindowState = FormWindowState.Maximized;

            // (Tuỳ chọn) Vô hiệu hóa nút phóng to màn hình
            this.MaximizeBox = false;

            // (Tuỳ chọn) Không cho phép thay đổi kích thước form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            // Không cho phép di chuyển form
            this.StartPosition = FormStartPosition.CenterScreen;

            // Xử lý sự kiện di chuột để không cho phép di chuyển form
            this.MouseDown += new MouseEventHandler(Client_Login_Form_Load);
            this.MouseMove += new MouseEventHandler(Client_Login_Form_Load);
        }
    }
}
