using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_QuanLyQuanNet
{
    public partial class LoginBox : Form
    {
        private Client_Login_Form _mainForm;

        public LoginBox(Client_Login_Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm; // Lưu tham chiếu của Form lớn
            //tắt chức năng co giãn của Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }

        private bool checkLogin(string username, string password)
        {
            //Hiện tại thì nếu username là admin và password là admin thì cho vào (return true)
            if (username == "admin" && password == "admin")  //Nếu như mà ko phải thì trả về là false.
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // Chạy hàm checkLogin() và kiểm tra kết quả
            if (checkLogin(tbx_Username.Text,tbx_Password.Text))
            {
                // Nếu checkLogin() trả về true, ẩn Form hiện tại và Form cha
                this.Hide();
                _mainForm.Hide();
            }
            else
            {
                // Nếu checkLogin() trả về false, hiển thị MessageBox thông báo sai tài khoản hoặc mật khẩu
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");

                // Đặt giá trị của tbx_Password thành chuỗi rỗng
                tbx_Password.Text = "";
            }
        }
    }
}
