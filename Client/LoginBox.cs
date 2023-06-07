using System;
using System.Configuration;
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private bool CheckLogin(string username, string password)
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

                EventData eventData = new EventData { Type = EventType.Login };
                eventData.Data["Username"] = username;
                eventData.Data["Password"] = password;

                string jsonData = JsonConvert.SerializeObject(eventData);

                byte[] data = Encoding.ASCII.GetBytes(jsonData);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string responseJsonData = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                EventData responseEventData = JsonConvert.DeserializeObject<EventData>(responseJsonData);
                bool isAuthenticated = (bool)responseEventData.Data["IsAuthenticated"];

                client.Close();

                return isAuthenticated;
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = tbx_Username.Text.Trim();
            string password = tbx_Password.Text;

            if (CheckLogin(username, password))
            {
                Hide();
                _mainForm.Hide();

                UserServiceMenu userServiceMenu = new UserServiceMenu(username);
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