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
    public delegate void CapNhatThongTinHandler(string maHangHoa, string tenHangHoa, string tenChatLieu, string soLuong, string donGiaNhap, string donGiaBan, string ghiChu);
    public partial class FormSua : Form
    {
        //public event Action<string, string, string, string, string, string, string> CapNhatThongTin;
        public event CapNhatThongTinHandler CapNhatThongTin;
        public FormSua(string maHangHoa, string tenHangHoa, string tenChatLieu, string soLuong, string donGiaNhap, string donGiaBan, string ghiChu)
        {
            InitializeComponent();
            txtMahang.Text = maHangHoa;
            txtTenhang.Text = tenHangHoa;
            txtTenchatlieu.Text = tenChatLieu;
            txtSoluong.Text = soLuong;
            txtDongianhap.Text = donGiaNhap;
            txtDongiaban.Text = donGiaBan;
            txtGhichu.Text = ghiChu;
        }

        private void FormSua_Load(object sender, EventArgs e)
        {

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            // Lấy giá trị đã chỉnh sửa từ các thành phần của form
            string updatedMahang = txtMahang.Text;
            string updatedTenhang = txtTenhang.Text;
            string updatedTenchatlieu = txtTenchatlieu.Text;
            string updatedSoluong = txtSoluong.Text;
            string updatedDongianhap = txtDongianhap.Text;
            string updatedDongiaban = txtDongiaban.Text;
            string updatedGhichu = txtGhichu.Text;

            // Gọi sự kiện CapNhatThongTin để truyền dữ liệu đã chỉnh sửa về MainForm
            if (CapNhatThongTin != null)
            {
                CapNhatThongTin(updatedMahang, updatedTenhang, updatedTenchatlieu, updatedSoluong, updatedDongianhap, updatedDongiaban, updatedGhichu);
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
