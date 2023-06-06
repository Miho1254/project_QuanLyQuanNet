using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Server;

namespace Client
{
    public partial class LoginBox : Form
    {
        private Client_Login_Form _mainForm;

        public LoginBox(Client_Login_Form mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private bool CheckLogin(string username, string password)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect("192.168.1.7", 8080);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error!");
                    return false;
                }

                Console.WriteLine("Kết nối thành công tới máy trạm!");

                EventData eventData = new EventData { Type = EventType.Login };
                eventData.Data["Username"] = username;
                eventData.Data["Password"] = password;

                string jsonData = JsonConvert.SerializeObject(eventData);

                //Gửi data sang Server
                byte[] data = Encoding.ASCII.GetBytes(jsonData);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                //Nhận data lại từ Server
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                MessageBox.Show("Đã nhận data");

                //Giải mã dữ liệu
                EventData responseEventData = JsonConvert.DeserializeObject<EventData>(responseJsonData);
                bool isAuthenticated = (bool)responseEventData.Data["IsAuthenticated"];

                //Đóng kết nối và trả về true / false
                client.Close();

                return isAuthenticated;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (CheckLogin(tbx_Username.Text, tbx_Password.Text))
            {
                this.Hide();
                _mainForm.Hide();

                UserServiceMenu userServiceMenu = new UserServiceMenu(tbx_Username.Text);
                userServiceMenu.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                tbx_Password.Text = "";
            }
        }
    }
}