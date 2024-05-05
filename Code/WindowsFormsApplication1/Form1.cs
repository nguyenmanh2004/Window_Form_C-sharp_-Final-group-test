using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        FormHangHoa formHangHoa = new FormHangHoa(); // Tạo một thể hiện của lớp FormHangHoa
        int x = 0;
        public FormMain()
        {
            InitializeComponent();
            formHangHoa = new FormHangHoa();
        }


        private void label2_Click(object sender, EventArgs e) { }

        private void tsmiKhachhang_Click(object sender, EventArgs e)

        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormKhachHang formKhachHang = new FormKhachHang();
            formKhachHang.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormHangHoa formHangHoa = new FormHangHoa();
            formHangHoa.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNhanVien formNhanVien = new FormNhanVien();
            formNhanVien.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            label1.Hide();
            label2.Hide();
            button1.Hide();
            button2.Hide();
            button3.Hide();
            label3.Show();
            pictureBox2.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x++;
            if (x == 5)
            {
                pictureBox1.Show();
                label1.Show();
                label2.Show();
                button1.Show();
                button2.Show();
                button3.Show();
                label3.Hide();
                pictureBox2.Hide();
                timer1.Stop();
            }
        }
    }
}
