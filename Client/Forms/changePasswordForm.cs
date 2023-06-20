using Newtonsoft.Json;
using Server;
using System;
using System.Configuration;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ChangePasswordForm : Form
    {
        private const int MinLength = 6;
        private string sessionUserName;

        public ChangePasswordForm(string username)
        {
            InitializeComponent();
            sessionUserName = username;
            tbx_Username.Text = username;
        }

        private void btn_DoiMatKhau_Click(object sender, EventArgs e)
        {
            string newPassword = tbx_Password.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!");
                return;
            }

            if (newPassword.Length < MinLength)
            {
                MessageBox.Show($"Mật khẩu mới phải có ít nhất {MinLength} ký tự!");
                return;
            }

            bool passwordChanged = ChangePassword(sessionUserName, newPassword);

            if (passwordChanged)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!");
            }

            Close();
        }

        //Xử lý việc truyền dữ liệu đến server
        private bool ChangePassword(string username, string newPassword)
        {
            using (TcpClient client = new TcpClient())
            {
                try
                {
                    client.Connect(ConfigurationManager.AppSettings["ServerIP"], Convert.ToInt32(ConfigurationManager.AppSettings["ServerPort"]));
                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi kết nối đến server!");
                    return false;
                }

                Console.WriteLine("Kết nối thành công tới máy trạm!");

                EventData eventData = new EventData { Type = EventType.PasswordChange };
                eventData.Data["Username"] = username;
                eventData.Data["NewPassword"] = newPassword;

                string jsonData = JsonConvert.SerializeObject(eventData);

                byte[] data = Encoding.ASCII.GetBytes(jsonData);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                EventData responseEventData = JsonConvert.DeserializeObject<EventData>(responseJsonData);
                bool passwordChanged = (bool)responseEventData.Data["PasswordChanged"];

                client.Close();

                return passwordChanged;
            }
        }
    }
}