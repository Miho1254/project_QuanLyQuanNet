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

## Form Thao tác người dùng (Client)

### Đặc điểm

- Tên Form: `UserServiceMenu`
- Kích thước Form: `189 x 585`
- Tiêu đề Form: Không có
- Icon (trong thanh taskbar): tính sau 
- Không cho người dùng kéo, co giãn
- Không cho người dùng di chuyển vị trí
- Ẩn vào thanh taskbar (sẽ xử lý sau) [Backend]

### Các phần tử giao diện

Form bao gồm các phần tử sau:

1. `cbx_NgonNgu` = 1 cái combobox set cứng ở phần tiếng Việt và Read-Only = true
2. `lbl_NgonNgu` =  Hiển thị là `ngôn ngữ: `
3. `tbx_TongThanhToan` = 1 cái textbox set thành readonly và set dữ liệu bên trong là `0`
4. `lbl_TongThanhToan` = Hiển thị là `Tổng thanh toán: `
5. `lbl_ConLai` = Hiển thị là `Còn lại: `
6. `tbx_GioChoiConLai` = Hiển thị giờ chơi còn lại (Công thức: Tiền chơi còn lại / Số tiền 1 giờ)
7. `tbx_TienChoiConLai` = Hiển thị tiền còn lại
8. `lbl_PhiDichVu` = Hiển thị `Phí dịch vụ(VNĐ): `
9. `tbx_PhiDichVu` = Hiển thị cứng là `0`
10. `btn_DangXuat` = Button này dùng để Đăng xuất 
11. `btn_DatDoAn` = Button này hiện ra 1 Form mới để Đặt đồ ăn
12. `btn_DoiMatKhau` = Button này hiện ra 1 Form mới để Đổi mật khẩu
13. `btn_GiaoTiep` = Button này hiện ra 1 Form mới để nói chuyện với Server

### Các hành động
- Khi người dùng nhấn vào nút "Đăng xuất", sẽ chạy sự kiện đăng xuất.
- Khi người dùng nhấn vào nút "Đặt đồ ăn", sẽ mở một Form mới để cho phép đặt đồ ăn.
- Khi người dùng nhấn vào nút "Đổi mật khẩu", sẽ mở một Form mới để cho phép đổi mật khẩu.
- Khi người dùng nhấn vào nút "Giao tiếp", sẽ mở một Form mới để cho phép nói chuyện với Server.

### Code mẫu
```csharp
        public UserServiceMenu()
        {
            InitializeComponent();
            cbx_NgonNgu.SelectedIndex = 0; // Chọn tiếng Việt mặc định
            tbx_TongThanhToan.Text = "0";
            tbx_PhiDichVu.Text = "0";
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện đăng xuất
            MessageBox.Show("Đăng xuất thành công!");
            Application.Exit();
        }

        private void btn_DatDoAn_Click(object sender, EventArgs e)
        {
            // Mở Form mới để đặt đồ ăn
            var orderFoodForm = new OrderFoodForm();
            //chưa code
            orderFoodForm.ShowDialog();
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            // Mở Form mới để đổi mật khẩu
            var changePasswordForm = new ChangePasswordForm();
            changePasswordForm.ShowDialog();
        }

        private void btn_GiaoTiep_Click(object sender, EventArgs e)
        {
            // Mở Form mới để nói chuyện với Server
            var communicationForm = new CommunicationForm();
            //chưa code
            communicationForm.ShowDialog();
        }
```

## Form Đổi password của người dùng (Client)

### Đặc điểm

- Tên Form: `changePasswordForm`
- Kích thước Form: `425 x 203`
- Tiêu đề Form: `Đổi password`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí

### Các phần tử giao diện

Form bao gồm các phần tử sau:
1. `btn_DoiMatkhau` = Button này dùng để đăng nhập 
2. `lbl_Username` = Hiển thị là `Username: `
3. `lbl_Password` = Hiển thị là `Password: `
4. `tbx_Username` = Text box hiển thị tên đăng nhập của người dùng và set thành Read-Only trong Property.
5. `tbx_Password` = Text box chứa mật khẩu.

### Các hành động
- Khi người dùng nhấn vào nút Đổi mật khẩu thị lấy dữ liệu từ 2 tbx và sau đó thay đổi pass trong sql

### Code mẫu
```csharp
        public ChangePasswordForm(string username)
        {
            InitializeComponent();
            //Lấy dữ liệu Username của người dùng từ SQL
            //Gán dữ liệu vào tbx_Username
            tbx_Username.Text = username;
        }

        private void btn_DoiMatkhau_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ textbox
            string newPassword = tbx_Password.Text;

            // Thực hiện việc thay đổi mật khẩu trong SQL
            // ... Code xử lý thay đổi mật khẩu trong SQL ...

            MessageBox.Show("Đổi mật khẩu thành công!");
            this.Close();
        }
```

## Form Liên hệ Admin (Client)

### Đặc điểm

- Tên Form: `AdminContact_Client`
- Kích thước Form: `730 x 614`
- Tiêu đề Form: `Liên hệ Admin`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí

### Các phần tử giao diện

Form bao gồm các phần tử sau:
1. `tbx_Main_Conversation` = Multi Line kéo dài đến gần hết form 
4. `tbx_User_Message` = Text box để người dùng ghi dữ liệu
5. `btn_Send` = Button để gửi văn bản trong `tbx_User_Message`

### Các hành động
- Khi người dùng nhấn vào nút Gửi thì sẽ chạy script để gửi tin nhắn đến máy chủ và hiện tin nhắn lên `tbx_Main_Conversation`.

### Code mẫu
```csharp
    public partial class AdminContact_Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private byte[] buffer = new byte[1024];

        public AdminContact_Client()
        {
            InitializeComponent();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            // Gửi tin nhắn đến máy chủ
            string message = tbx_User_Message.Text;
            SendMessage(message);

            // Hiển thị tin nhắn trong khung conversation

            // Xóa nội dung trong textbox
            tbx_User_Message.Clear();
        }

        private void SendMessage(string message)
        {
            // TODO: Gửi tin nhắn đến máy chủ
        }
    }
```

## Form Popup tin nhắn từ người dùng (Server)

### Đặc điểm

- Tên Form: `AdminContact_Server`
- Kích thước Form: `quên bà nó rồi`
- Tiêu đề Form: `AdminContact_Server`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí

### Các phần tử giao diện

Form bao gồm các phần tử sau:
1. `tbx_Main_Conversation` = Multi Line kéo dài đến gần hết form 

### Các hành động
- Không có  

### Code mẫu
```csharp
```

## Form Đặt đồ ăn (Client)

### Đặc điểm

- Tên Form: `Food_Order`
- Kích thước Form: `885 x 565`
- Tiêu đề Form: `Đặt đồ ăn`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí

### Các phần tử giao diện

Form bao gồm các phần tử sau:
1. `tbx_SL` = textbox chứa dữ liệu số lượng
4. `datagrid_Food` = Datagridview chứa dữ liệu đồ ăn bao gồm (ID món, Tên món, giá, ghi chú)
5. `btn_send` = Button để gửi món đã đặt

### Các hành động
- Khi người dùng nhấn vào nút Gửi thì sẽ chạy script để gửi món đã order lên socket và xử lý bên server  

### Code mẫu
```csharp
    // Lấy dữ liệu từ các textbox
    string quantity = tbx_SL.Text;
    
    // Lấy dữ liệu từ DataGridView (ID món được chọn)
    string selectedId = "";
    if (datagrid_Food.SelectedRows.Count > 0)
    {
        DataGridViewRow selectedRow = datagrid_Food.SelectedRows[0];
        selectedId = selectedRow.Cells["ID"].Value.ToString();
    }

    // Gửi dữ liệu lên server và xử lý logic tương ứng
    // ...

    // Hiển thị thông báo thành công
    MessageBox.Show("Món đã được đặt thành công!");
```

## Form Popup đồ ăn (Server)

### Đặc điểm

- Tên Form: `Food_Order_Server`
- Kích thước Form: `nhỏ 1 tí`
- Tiêu đề Form: `AdminContact_Server`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí

### Các phần tử giao diện

Form bao gồm các phần tử sau:
làm sao để hiển thị đc món người dùng đặt là được

### Các hành động
- Không có  

### Code mẫu
```csharp
```

## Form Login (Server)

### Đặc điểm 
- Tên Form: `Admin_Login`
- Kích thước Form: `To`
- Tiêu đề Form: `Admin_Login`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí
- Bớt wibu lại tí.

### Các phần tử giao diện

Phần tử giống với Form đăng nhập bên user

### Các hành động
- Khi người dùng đăng nhập thì xử lý SQL kiểm tra nếu tài khoản đúng thì cho vào và mở form quản lý
- Nếu người dùng sai pass thì hiện popup báo lỗi lên
- Nếu người dùng nhập tk là "admin" và pass là "admin" thì cho vào.

### Code mẫu
```csharp
public Admin_Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            
            //Xử lý CSDL bên SQL
            //Xác thực tài khoản
            // Kiểm tra tài khoản và mật khẩu
            if ()
            {
                // Đăng nhập thành công, mở Form quản lý
                QuanLyForm quanLyForm = new QuanLyForm();
                quanLyForm.Show();
                this.Hide();
            }
            else
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
```

## Form Dashboard (Server)

### Đặc điểm 
- Tên Form: `Dashboard`
- Kích thước Form: `1208 x 913`
- Tiêu đề Form: `Admin_Login`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí
- Bớt wibu lại tí.

### Các phần tử giao diện

- 1 Button tele đến form tạo tài khoản người dùng
- 1 Datagridview trỏ về table KhachHang
- 1 Button dùng để tele đến form add số dư vào tài khoản người dùng
- 1 Button tele đến form của Quản lý

### Các hành động
- Khi người dùng ấn vào button tạo tài khoản người dùng thì tele đến form tạo tài khoản người dùng
- Khi người dùng ấn vào button tạo add số dư vào tài khoản người dùng thì hiển thị form add số dư
- Khi người dùng ấn vào button truy cập form quản lý thì kiểm tra dữ liệu người dùng trong mục nhân sự, nếu có chucvu là QUANLY thì mở form, còn không thì báo lỗi không đủ quyền hạn.

### Code mẫu
```csharp
```

## Form tạo tài khoản người dùng (Server)

### Đặc điểm 
- Tên Form: `CreateUserAccount`
- Kích thước Form: `nhỏ`
- Tiêu đề Form: `CreateUserAccount`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí
- Bớt wibu lại tí.

### Các phần tử giao diện

- 1 tbx_Username
- 1 lbl_Username
- 1 tbx_Password
- 1 lbl_Password
- 1 tbx_SoDu (số dư khởi tạo tài khoản)
- 1 lbl_SoDu
- 1 btn_Tao = tạo tài khoản
### Các hành động
- Khi người dùng ấn vào button tạo tài khoản thì insert dữ liệu vào sql (Kiểm tra nếu đã tồn tại username trùng thì báo lỗi) và set tbx_Username và tbx_Password và tbx_SoDu thành ""
### Code mẫu
```csharp
```

## Form thêm số dư (Server)

### Đặc điểm 
- Tên Form: `AddUserBalance`
- Kích thước Form: `nhỏ`
- Tiêu đề Form: `AddUserBalance`
- Icon: Để đại 
- Không cho người dùng kéo, co giãn
- Cho phép người dùng di chuyển vị trí
- Bớt wibu lại tí.

### Các phần tử giao diện

- 1 tbx_Username
- 1 lbl_Username
- 1 tbx_SoDu (số dư cần add)
- 1 lbl_SoDu
- 1 btn_Add = thêm số dư
### Các hành động
- Khi người dùng ấn vào button tạo tài khoản thì insert dữ liệu vào sql (Nếu không tồn tại username đó thì báo lỗi) và set tbx_Username tbx_SoDu thành ""
### Code mẫu
```csharp
```
