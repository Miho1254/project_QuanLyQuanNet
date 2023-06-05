# Client

## Form Đăng nhập (Client)
Đây là Phần hiển thị đầu tiên khi máy khởi động lên (Điều kiện là máy đã được inject script để auto start)

### Đặc điểm

- Tên Form: `Client_Login_Form`
- Kích thước Form: `Full màn hình`
- Tiêu đề Form: `Không có tiêu đề`

### Các phần tử giao diện

Form bao gồm các phần tử sau:

1. `bg_Client_Login_Image` = Ảnh background của Client_Login_Form
2. `btn_Exit_Demo` = Nút này dùng để exit demo (Thoát khỏi Form đăng nhập) [Nằm góc trái trên cùng]

### Các hành động

- Khi người dùng ấn vào 1 nút bất kỳ hoặc là 1 click chuột thì nó sẽ hiện Form `LoginBox` lên.
- Khi người dùng ấn vào nút exit Demo thì ẩn LoginBox và Client_Login_Form

### Mã ví dụ
```csharp
    //Chứa form LoginBox
    private LoginBox _loginBox;

    public Client_Login_Form()
    {
        InitializeComponent();
        //tắt viền Form, làm Form tra tràn viền
        this.FormBorderStyle = none;
        //tắt phần nút điều hướng
        this.ControlBox = false;
        //đặt Form text thành 1 giá trị rỗng
        this.Text = "";
        //Form cha full màn hình
        this.WindowState = Maximized
        //Đặt màu nền và các thuộc tính khác của Form theo ý thích.
    }

    //sự kiện này chạy khi người dùng click nút bất kỳ
    private void Client_Login_Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space) // Kiểm tra phím bấm, ví dụ nhấn phím Space
        {
            LoginBox loginBox = new LoginBox(this); // Tạo một instance của Form đăng nhập sau đó truyền tham số là chính cái class này
            _loginBox = loginBox; 
            _loginBox.ShowDialog(); // Hiển thị Form đăng nhập dưới dạng dialog
        }
    }

    //sự kiện này chạy khi người dùng click chuột bất kỳ
    private void Client_Login_Form_MouseClick(object sender, MouseEventArgs e)
    {
        LoginBox loginBox = new LoginBox(this); // Tạo một instance của Form đăng nhập sau đó truyền tham số là chính cái class này
        _loginBox = loginBox; 
        _loginBox.ShowDialog(); // Hiển thị Form đăng nhập dưới dạng dialog
    }
    
    //Sự kiện khi nút Exit_Demo được bấm: Thì this.Hide() để ẩn Form lớn và kiểm tra nếu _loginBox có giá trị là null thì khỏi cần ẩn form nhỏ
    //Nhưng nếu _loginBox ko phải null (Nghĩa là đã được khởi động) thì bằng cách: _loginBox.Hide();
    
    //
    //--
    //Phần này dùng để tránh việc người dùng glitch và thoát khỏi Form đăng nhập truy cập vào windows
    //--
    //Biến _hookHandle được sử dụng để lưu trữ tham chiếu đến hook đã cài đặt để theo dõi sự kiện bàn phím.
    private IntPtr _hookHandle;

    //Sự kiện này chạy khi Form được load
    private void Client_Login_Form_Load(object sender, EventArgs e)
    {
        //SetHook được gọi để cài đặt hook và HookCallback được truyền làm tham số.
        _hookHandle = SetHook(HookCallback);
    }

    //Sự kiên này chạy khi Form bị đóng (Bất kể là lý do gì)
    private void Client_Login_Form_FormClosing(object sender, FormClosingEventArgs e)
    {
        //Huỷ Hook bàn phím
        UnhookWindowsHookEx(_hookHandle);
    }

    private IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        //Lấy tham chiếu đến module hiện tại
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            // Cài đặt hook bàn phím và trả về tham chiếu đến hook đã cài đặt
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            if (FormIsVisible())
            {
                // Ngăn chặn xử lý sự kiện bàn phím và chuột
                // Nếu Form đăng nhập đang hiển thị, ngăn chặn xử lý sự kiện bàn phím và chuột
                return (IntPtr)1;
            }
        }

        // Chuyển sự kiện bàn phím tới hook tiếp theo hoặc gửi nó tới ứng dụng mục tiêu
        return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
    }

    private bool FormIsVisible()
    {
        // Kiểm tra xem Form đăng nhập có đang hiển thị và không thu nhỏ không
        return this.Visible && this.WindowState != FormWindowState.Minimized;
    }

    // Các hằng số và khai báo hàm Hook
    private const int WH_KEYBOARD_LL = 13;

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

```

## Form Login box (Client)
Đây là Phần hiển thị đầu tiên khi máy khởi động lên (Điều kiện là máy đã được inject script để auto start)

### Đặc điểm

- Tên Form: `LoginBox`
- Kích thước Form: `425 x 203`
- Tiêu đề Form: `Đăng nhập`
- Icon: Tuỳ ý
- Fixed
### Các phần tử giao diện

Form bao gồm các phần tử sau:

1. `btn_Login` = Button này dùng để đăng nhập 
2. `lbl_Username` = Hiển thị là `Username: `
3. `lbl_Password` = Hiển thị là `Password: `
4. `tbx_Username` = Text box chứa tên đăng nhập.
5. `tbx_Password` = Text box chứa mật khẩu.

### Các hành động

- Khi người dùng ấn vào nút Đăng nhập thì chạy sự kiện kiểm tra tài khoản và mật khẩu

### Mã ví dụ
```csharp
    private Client_Login_Form _mainForm;

    public PopupForm(Client_Login_Form mainForm)
    {
        InitializeComponent();
        _mainForm = mainForm; // Lưu tham chiếu của Form lớn
        //tắt chức năng co giãn của Form
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
    }

    //1 cái sự kiện nút "btn_Login" được ấn, sau đó chạy hàm checkLogin()
    //Nếu trả về checkLogin() trả về true thì ẩn cái Form này và Form cha bằng cách
    // this.Hide();
    // _mainForm.hide();
    //Nếu như trả về false thì hiện messageBox báo rằng là username hoặc password sai, sau đó set tbx_Password thành ""
    
    private bool checkLogin(string username, string password)
    {
        //Hiện tại thì nếu username là admin và password là admin thì cho vào (return true)
        //Nếu như mà ko phải thì trả về là false.
        //sau này mình sẽ kết nối với database sau.
    }
```
