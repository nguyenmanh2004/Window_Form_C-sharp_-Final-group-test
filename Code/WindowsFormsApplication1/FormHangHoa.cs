using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using WindowsFormsApplication1.Class;
namespace WindowsFormsApplication1
{
    public partial class FormHangHoa : Form
    {
        private SqlDataAdapter da;
        private DataTable dt;

        public FormHangHoa()
        {
            InitializeComponent();
        }
        private void KhoiTao_DuLieu()
        {

            Dungchung.KetNoi();
            dt = new DataTable();
            da = new SqlDataAdapter("SELECT * FROM tblHang", Dungchung.cnn);
            da.Fill(dt);

            dgvHang.DataSource = dt;
            dgvHang.Columns[0].HeaderText = "Mã Hàng";
            dgvHang.Columns[1].HeaderText = "Tên Hàng";
            dgvHang.Columns[2].HeaderText = "Mã chất liệu";
            dgvHang.Columns[3].HeaderText = "Số lượng";
            dgvHang.Columns[4].HeaderText = "Đơn giá nhập";
            dgvHang.Columns[5].HeaderText = "Đơn giá bán";
            dgvHang.Columns[6].HeaderText = "Ghi chú";
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void FormHangHoa_Load(object sender, EventArgs e)
        {
            KhoiTao_DuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow newRow = dt.NewRow();
            dt.Rows.Add(newRow);
            newRow["Mahang"] = txtMahang.Text;
            newRow["TenHang"] = txtTenhang.Text;
            newRow["Tenchatlieu"] = txtTenchatlieu.Text;
            newRow["Soluong"] = txtSoluong.Text;
            newRow["Dongianhap"] = txtDongianhap.Text;
            newRow["Dongiaban"] = txtDongiaban.Text;
            newRow["Ghichu"] = txtGhichu.Text;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHang.SelectedRows.Count > 0)
            {
                dgvHang.Rows.Remove(dgvHang.SelectedRows[0]);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dt);
                MessageBox.Show("Lưu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            //DataTable tbl = new DataTable();
            //tbl = Dungchung.dt.GetChanges();
            ////Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            //if (tbl == null)
            //    MessageBox.Show("Dữ liệu chưa thay đổi");
            //else
            //{
            //    Dungchung.cmb = new SqlCommandBuilder(Dungchung.da);
            //    Dungchung.da.Update(Dungchung.dt);
            //    MessageBox.Show("Có " + tbl.Rows.Count + " dòng đã được cập nhật");
        //}
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            
        }

        private void bs_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            
        }
    }
}
