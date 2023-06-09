using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Food_Order_Server : Form
    {
        public Food_Order_Server(string username, string foodName)
        {
            InitializeComponent();

            // Format chuỗi thông báo và đẩy vào text box
            string message = string.Format("[{0}]: đã yêu cầu 1 {1}", username, foodName);
            tbx_Food.AppendText(message + "\n");
        }
    }
}
