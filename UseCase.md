![Sơ đồ Use Case](https://media.discordapp.net/attachments/1113708189742018611/1114589028902240336/UseCase.jpg?width=934&height=670)
# Client-side

## Đăng nhập

### Tên use case
Đăng nhập vào hệ thống

### Mô tả
Người dùng có thể đăng nhập vào hệ thống Quản Lý Phòng Net bằng tài khoản của mình.

### Actor
Người dùng

### ĐK Kích hoạt
Người dùng muốn truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người dùng đã có tài khoản người dùng.

### Hậu điều kiện
Người dùng đã đăng nhập thành công và được chuyển đến giao diện chính của hệ thống.

### Luồng sự kiện chính
1. Người dùng truy cập vào giao diện đăng nhập của hệ thống.
2. Người dùng nhập tên người dùng và mật khẩu của mình.
3. Người dùng nhấn nút "Đăng nhập".
4. Hệ thống xác thực thông tin đăng nhập và kiểm tra tính hợp lệ.
5. Nếu thông tin đăng nhập hợp lệ, người dùng được đăng nhập thành công và chuyển đến giao diện chính của hệ thống.
6. Nếu thông tin đăng nhập không hợp lệ, hệ thống hiển thị thông báo lỗi và yêu cầu người dùng nhập lại thông tin.

### Luồng sự kiện phụ
- Người dùng có thể sử dụng chức năng "Quên mật khẩu" nếu không nhớ mật khẩu của mình.

## Sử dụng giờ chơi

### Tên use case
Sử dụng giờ chơi trong phòng net

### Mô tả
Người dùng có thể sử dụng giờ chơi trong phòng net và theo dõi thời gian sử dụng của mình.

### Actor
Người dùng

### ĐK Kích hoạt
Người dùng muốn chơi game trong phòng net.

### Tiền điều kiện
Người dùng đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người dùng đã kết thúc thời gian sử dụng giờ chơi.

### Luồng sự kiện chính
1. Người dùng truy cập vào giao diện chọn giờ chơi trong hệ thống.
2. Người dùng chọn thời gian chơi và các dịch vụ đi kèm (nếu có).
3. Người dùng xác nhận và tiến hành thanh toán (nếu áp dụng).
4. Hệ thống ghi nhận thời gian bắt đầu sử dụng giờ chơi.
5. Người dùng bắt đầu chơi game trong phòng net.
6. Hệ thống theo dõi thời gian sử dụng và hiển thị thông tin cho người dùng (ví dụ: thời gian còn lại, thông báo kết thúc).
7. Khi thời gian sử dụng kết thúc, hệ thống tự động kết thúc phiên chơi của người dùng.

### Luồng sự kiện phụ
- Người dùng có thể mua thêm thời gian chơi trong quá trình sử dụng nếu muốn chơi tiếp.
- Người dùng có thể kết thúc sớm phiên chơi và thoát khỏi phòng net.

## Tra cứu thông tin tài khoản

### Tên use case
Tra cứu thông tin tài khoản người dùng

### Mô tả
Người dùng có thể tra cứu thông tin tài khoản của mình trong hệ thống Quản Lý Phòng Net.

### Actor
Người dùng

### ĐK Kích hoạt
Người dùng muốn xem thông tin tài khoản cá nhân.

### Tiền điều kiện
Người dùng đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người dùng đã xem thông tin tài khoản cá nhân.

### Luồng sự kiện chính
1. Người dùng truy cập vào giao diện tra cứu thông tin tài khoản.
2. Người dùng nhập thông tin cần tra cứu (ví dụ: tên người dùng, số điện thoại).
3. Người dùng nhấn nút "Tra cứu".
4. Hệ thống tìm kiếm và hiển thị thông tin tài khoản tương ứng với thông tin nhập vào.

### Luồng sự kiện phụ
- Nếu không tìm thấy thông tin tài khoản, hệ thống sẽ hiển thị thông báo không có kết quả tương ứng.

## Yêu cầu trợ giúp

### Tên use case
Yêu cầu trợ giúp từ người quản lý phòng net

### Mô tả
Người dùng có thể yêu cầu trợ giúp từ người quản lý phòng net trong trường hợp cần hỗ trợ hoặc gặp vấn đề.

### Actor
Người dùng

### ĐK Kích hoạt
Người dùng gặp vấn đề hoặc cần hỗ trợ từ người quản lý.

### Tiền điều kiện
Người dùng đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý phòng net đã nhận được yêu cầu trợ giúp từ người dùng.

### Luồng sự kiện chính
1. Người dùng truy cập vào giao diện yêu cầu trợ giúp.
2. Người dùng mô tả vấn đề hoặc yêu cầu trợ giúp cụ thể.
3. Người dùng gửi yêu cầu trợ giúp.
4. Hệ thống gửi thông báo yêu cầu trợ giúp cho người quản lý phòng net.

### Luồng sự kiện phụ
- Người dùng có thể nhận được phản hồi hoặc hướng dẫn từ người quản lý phòng net sau khi gửi yêu cầu trợ giúp.

## Đổi mật khẩu

### Tên use case
Đổi mật khẩu tài khoản người dùng

### Mô tả
Người dùng có thể thay đổi mật khẩu tài khoản của mình trong hệ thống Quản Lý Phòng Net.

### Actor
Người dùng

### ĐK Kích hoạt
Người dùng muốn thay đổi mật khẩu tài khoản.

### Tiền điều kiện
Người dùng đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người dùng đã thay đổi mật khẩu thành công.

### Luồng sự kiện chính
1. Người dùng truy cập vào giao diện thay đổi mật khẩu.
2. Người dùng nhập mật khẩu cũ và mật khẩu mới.
3. Người dùng xác nhận và tiến hành thay đổi mật khẩu.
4. Hệ thống kiểm tra tính hợp lệ của mật khẩu cũ và thay đổi mật khẩu thành công.

### Luồng sự kiện phụ
- Nếu mật khẩu cũ không hợp lệ, hệ thống sẽ hiển thị thông báo lỗi và yêu cầu người dùng nhập lại.

## Đặt đồ ăn

### Tên use case
Đặt đồ ăn trong phòng net

### Mô tả
Người dùng có thể đặt đồ ăn từ quầy phục vụ trong phòng net.

### Actor
Người dùng

### ĐK Kích hoạt
Người dùng muốn đặt đồ ăn trong quá trình sử dụng phòng net.

### Tiền điều kiện
Người dùng đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người dùng đã đặt đồ ăn thành công.

### Luồng sự kiện chính
1. Người dùng truy cập vào giao diện đặt đồ ăn.
2. Người dùng chọn các món ăn và số lượng cần đặt.
3. Người dùng xác nhận và tiến hành đặt đồ ăn.
4. Hệ thống ghi nhận đơn đặt hàng của người dùng và hiển thị thông báo thành công.

### Luồng sự kiện phụ
- Người dùng có thể xem lại danh sách đơn hàng đã đặt và cập nhật thông tin đơn hàng nếu cần.

## Đăng xuất

### Tên use case
Đăng xuất khỏi hệ thống

### Mô tả
Người dùng có thể đăng xuất khỏi hệ thống Quản Lý Phòng Net.

### Actor
Người dùng

### ĐK Kích hoạt
Người dùng muốn thoát khỏi hệ thống.

### Tiền điều kiện
Người dùng đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người dùng đã đăng xuất thành công.

### Luồng sự kiện chính
1. Người dùng truy cập vào giao diện đăng xuất.
2. Người dùng xác nhận đăng xuất.
3. Hệ thống xử lý yêu cầu đăng xuất và chuyển người dùng đến giao diện đăng nhập.

### Luồng sự kiện phụ
- Người dùng có thể tiếp tục đăng nhập lại sau khi đăng xuất.

# Server Management

## Đăng ký tài khoản người dùng

### Tên use case
Đăng ký tài khoản người dùng trong phòng net

### Mô tả
Người quản lý phòng net và thu ngân có thể đăng ký tài khoản người dùng cho khách hàng.

### Actor
Quản lý
Thu Ngân

### ĐK Kích hoạt
Người quản lý hoặc Thu ngân truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người quản lý hoặc Thu ngân đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý hoặc Thu ngân đã đăng ký tài khoản người dùng thành công.

### Luồng sự kiện chính
1. Người quản lý hoặc Thu ngân truy cập vào giao diện đăng ký tài khoản người dùng.
2. Người quản lý hoặc Thu ngân nhập thông tin người dùng.
3. Người quản lý hoặc Thu ngân tạo tài khoản người dùng và cung cấp thông tin đăng nhập cho khách hàng.

## General Management

### Tên use case
Quản lý chung của quán net

### Mô tả
Người quản lý quán net có quyền quản lý chung các hoạt động trong quán net.

### Actor
Người quản lý

### ĐK Kích hoạt
Người quản lý truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người quản lý đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý đã thực hiện các hoạt động quản lý thành công.

### Luồng sự kiện chính
1. Người quản lý truy cập vào giao diện quản lý chung.
2. Người quản lý có thể thực hiện các hoạt động như quản lý đồ ăn, quản lý hóa đơn, quản lý nhân sự, quản lý máy trạm, v.v.

## Quản lý Đồ ăn

### Tên use case
Quản lý đồ ăn trong quán net

### Mô tả
Người quản lý có thể thêm, xóa và chỉnh sửa thông tin về các món ăn trong quán net.

### Actor
Người quản lý

### ĐK Kích hoạt
Người quản lý truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người quản lý đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý đã thực hiện các hoạt động quản lý đồ ăn thành công.

### Luồng sự kiện chính
1. Người quản lý truy cập vào giao diện quản lý đồ ăn.
2. Người quản lý có thể thêm món ăn mới, xóa món ăn và chỉnh sửa thông tin món ăn.

## Quản lý hóa đơn

### Tên use case
Quản lý hóa đơn trong quán net

### Mô tả
Người quản lý có thể xem và xuất hóa đơn của các giao dịch trong quán net.

### Actor
Người quản lý

### ĐK Kích hoạt
Người quản lý truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người quản lý đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý đã thực hiện các hoạt động quản lý hóa đơn thành công.

### Luồng sự kiện chính
1. Người quản lý truy cập vào giao diện quản lý hóa đơn.
2. Người quản lý có thể xem danh sách hóa đơn, tìm kiếm hóa đơn theo các tiêu chí, và xuất hóa đơn ra định dạng PDF hoặc XLXS.

## Quản lý nhân sự

### Tên use case
Quản lý nhân sự trong quán net

### Mô tả
Người quản lý có thể thêm, xóa và chỉnh sửa thông tin về nhân sự trong quán net.

### Actor
Người quản lý

### ĐK Kích hoạt
Người quản lý truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người quản lý đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý đã thực hiện các hoạt động quản lý nhân sự thành công.

### Luồng sự kiện chính
1. Người quản lý truy cập vào giao diện quản lý nhân sự.
2. Người quản lý có thể thêm nhân sự mới, xóa nhân sự và chỉnh sửa thông tin nhân sự.

## Quản lý máy trạm

### Tên use case
Quản lý máy trạm trong quán net

### Mô tả
Người quản lý có thể thêm, xóa và chỉnh sửa thông tin về máy trạm trong quán net.

### Actor
Người quản lý

### ĐK Kích hoạt
Người quản lý truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người quản lý đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý đã thực hiện các hoạt động quản lý máy trạm thành công.

### Luồng sự kiện chính
1. Người quản lý truy cập vào giao diện quản lý máy trạm.
2. Người quản lý có thể thêm máy trạm mới, xóa máy trạm và chỉnh sửa thông tin máy trạm.

## Xuất hóa đơn ra PDF, XLXS

### Tên use case
Xuất hóa đơn ra định dạng PDF, XLXS

### Mô tả
Người quản lý có thể xuất hóa đơn ra định dạng PDF hoặc XLXS để lưu trữ hoặc in ấn.

### Actor
Người quản lý

### ĐK Kích hoạt
Người quản lý truy cập vào hệ thống Quản Lý Phòng Net.

### Tiền điều kiện
Người quản lý đã đăng nhập vào hệ thống Quản Lý Phòng Net.

### Hậu điều kiện
Người quản lý đã thực hiện xuất hóa đơn thành công.

### Luồng sự kiện chính
1. Người quản lý truy cập vào giao diện quản lý hóa đơn.
2. Người quản lý chọn hóa đơn cần xuất ra định dạng PDF hoặc XLXS.
3. Người quản lý thực hiện xuất hóa đơn ra định dạng PDF hoặc XLXS.


