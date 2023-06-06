using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Client
{
    public partial class Client_Login_Form : Form
    {
        private LoginBox _loginBox; // Form đăng nhập
        private IntPtr _hookHandle; // Tham chiếu đến hook đã cài đặt để theo dõi sự kiện bàn phím

        public Client_Login_Form()
        {
            InitializeComponent();
            this.Shown += Client_Login_Form_Shown; // Gắn kết sự kiện Shown của Form
            this.FormClosing += Client_Login_Form_FormClosing; // Gắn kết sự kiện FormClosing của Form
            _hookHandle = SetHook(HookCallback); // Cài đặt hook bàn phím
        }

        // Xử lý sự kiện khi Form được hiển thị lên màn hình
        private void Client_Login_Form_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; // Đặt kích thước cửa sổ Form là Maximized
            this.MaximizeBox = false; // Vô hiệu hóa nút Maximize
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Đặt kiểu khung cửa sổ là FixedSingle
            this.StartPosition = FormStartPosition.CenterScreen; // Đặt vị trí xuất hiện của Form là CenterScreen
        }

        // Xử lý sự kiện khi Form đóng
        private void Client_Login_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnhookWindowsHookEx(_hookHandle); // Gỡ bỏ hook bàn phím
        }

        // Xử lý sự kiện khi người dùng nhấn nút "Exit Demo"
        private void btn_Exit_Demo_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn Form chính
            _loginBox?.Hide(); // Ẩn Form đăng nhập (nếu có)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_loginBox == null || !_loginBox.Visible)
            {
                _loginBox = new LoginBox(this); // Tạo một instance mới của Form đăng nhập
                _loginBox.ShowDialog(); // Hiển thị Form đăng nhập dưới dạng dialog
            }
        }

        // Cài đặt hook để theo dõi sự kiện bàn phím
        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        // Callback của hook bàn phím
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && FormIsVisible())
            {
                if (wParam == (IntPtr)WM_LBUTTONDOWN || wParam == (IntPtr)WM_RBUTTONDOWN || wParam == (IntPtr)WM_MBUTTONDOWN)
                {
                    if (_loginBox == null || !_loginBox.Visible)
                    {
                        _loginBox = new LoginBox(this); // Tạo một instance mới của Form đăng nhập
                        _loginBox.ShowDialog(); // Hiển thị Form đăng nhập dưới dạng dialog
                    }
                }
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        // Kiểm tra xem Form có đang hiển thị không
        private bool FormIsVisible()
        {
            return this.Visible && this.WindowState != FormWindowState.Minimized;
        }

        // Hằng số WH_KEYBOARD_LL, đại diện cho loại hook bàn phím
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_LBUTTONDOWN = 0x0201; // Mouse left button down
        private const int WM_RBUTTONDOWN = 0x0204; // Mouse right button down
        private const int WM_MBUTTONDOWN = 0x0207; // Mouse middle button down

        // Delegate của phương thức HookCallback
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Import các hàm từ DLL user32.dll và kernel32.dll để sử dụng hook bàn phím
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
