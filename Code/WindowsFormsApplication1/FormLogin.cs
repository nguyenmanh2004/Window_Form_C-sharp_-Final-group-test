using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApplication1
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void txtmk_TextChanged(object sender, EventArgs e)
        {
            txtmk.PasswordChar = '*';
            if (string.IsNullOrWhiteSpace(txtmk.Text))
            {
                x.SetError(txtmk, "Nhập mật khẩu");
            }
            else
            {
                x.SetError(txtmk, ""); // Xóa thông báo lỗi nếu nội dung hợp lệ
            }
        }

        private void txttk_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txttk.Text))
            {
                x.SetError(txttk, "Nhập tài khoản");
            }
            else
            {
                x.SetError(txttk, ""); // Xóa thông báo lỗi nếu nội dung hợp lệ
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtmk.Text) && !string.IsNullOrWhiteSpace(txttk.Text))
            {
                string message = string.Format("Đăng nhập thành công!\nTài khoản là: {0}\nMật khẩu là: {1}", txttk.Text, txtmk.Text);
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                Connect_database formConnectDatabase = new Connect_database();
                formConnectDatabase.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
