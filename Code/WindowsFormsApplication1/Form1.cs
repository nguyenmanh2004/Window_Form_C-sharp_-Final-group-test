using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
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
    }
}
