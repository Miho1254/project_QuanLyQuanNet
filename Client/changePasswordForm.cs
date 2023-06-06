using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class changePasswordForm : Form
    {
        public changePasswordForm(string username)
        {
            InitializeComponent();
            //Lấy dữ liệu Username của người dùng từ SQL
            //Gán dữ liệu vào tbx_Username
            tbx_Username.Text = username;
        }

        private void changePasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void tbx_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ textbox
            string newPassword = tbx_Password.Text;
            if (newPassword.Length == 0)
            {
                MessageBox.Show("Gà ác vậy?");
                return;
            }

            // Thực hiện việc thay đổi mật khẩu trong SQL
            // ... Code xử lý thay đổi mật khẩu trong SQL ...
            MessageBox.Show("Đổi mật khẩu thành công!");
            this.Close();
        }
    }
}
