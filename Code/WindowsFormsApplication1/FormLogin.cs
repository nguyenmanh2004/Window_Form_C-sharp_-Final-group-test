using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
                

                
                try
                {
                    // ket noi sql
                    string connectionstring;
                    SqlConnection cnn = new SqlConnection();
                    connectionstring = "Data Source=SQL5113.site4now.net,1433;Initial Catalog=db_aa8167_nguyenmanh1203;User Id=db_aa8167_nguyenmanh1203_admin;Password=phucdeptrai123;";
                    cnn.ConnectionString = connectionstring;
                    cnn.Open();
                    string message = string.Format("Đăng nhập thành công!");
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    cnn.Close();
                    FormMain formMain = new FormMain();
                    formMain.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("loi ke noi" + ex.Message);
                }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
