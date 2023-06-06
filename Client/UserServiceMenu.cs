using Server;
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
    public partial class UserServiceMenu : Form
    {
        private string SessionUserName;
        public UserServiceMenu(string username)
        {
            InitializeComponent();
            //set thanh service luôn nằm bên phải của màn hình
            this.StartPosition = FormStartPosition.Manual;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(screenWidth - this.Width, 0);

            //set cứng các thuộc tính
            tbx_TongThanhToan.Text = "0";
            tbx_PhiDichVu.Text = "0";

            //gán dữ liệu của SessionUser lấy từ loginBox
            SessionUserName = username;
        }

        private void UserServiceMenu_Load(object sender, EventArgs e)
        {

        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện đăng xuất
            MessageBox.Show("Đăng xuất thành công!");
            Application.Exit();
        }

        private void btn_DatDoAn_Click(object sender, EventArgs e)
        {
           //Tạm thời chưa code, đợi form Đặt Đồ Ăn
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            // Mở Form mới để đổi mật khẩu
            changePasswordForm form = new changePasswordForm(SessionUserName);

            // Hiển thị form đổi mật khẩu
            form.ShowDialog();
        }

        private void btn_GiaoTiep_Click(object sender, EventArgs e)
        {
            //Chưa code vì chưa có form
        }

        private void tbx_GioChoiConLai_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
