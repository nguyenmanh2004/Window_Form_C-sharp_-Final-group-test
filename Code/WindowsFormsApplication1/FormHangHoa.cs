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
        
        public FormHangHoa()
        {
            InitializeComponent();
            
        }
        private void KhoiTao_DuLieu()
        {

            Dungchung.KetNoi();
            Dungchung.dt = new DataTable();
            Dungchung.da = new SqlDataAdapter("SELECT * FROM tblHang", Dungchung.cnn);
            Dungchung.da.Fill(Dungchung.dt);
            dgvHang.DataSource = Dungchung.dt;

            dgvHang.Columns[0].HeaderText = "Mã Hàng";
            dgvHang.Columns[1].HeaderText = "Tên Hàng";
            dgvHang.Columns[2].HeaderText = "Tên chất liệu";
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
            DataRow newRow = Dungchung.dt.NewRow();
            Dungchung.dt.Rows.Add(newRow);
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
            
            DataTable tbl = new DataTable();
            tbl = Dungchung.dt.GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                Dungchung.cmb = new SqlCommandBuilder(Dungchung.da);
                //Dungchung.cmb = new SqlCommandBuilder(Dungchung.da);
                Dungchung.da.Update(Dungchung.dt);
                MessageBox.Show("Có " + tbl.Rows.Count +
               " dòng đã được cập nhật");
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimkiem.Text.Trim().ToLower(); // Lấy từ khóa tìm kiếm từ TextBox (txtTimKiem); chuyển sang chữ thường

            // Duyệt qua các dòng trong DataGridView và tìm kiếm dữ liệu
            foreach (DataGridViewRow row in dgvHang.Rows)
            {
                // Kiểm tra từng ô trong mỗi dòng để tìm kiếm từ khóa
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(tuKhoa))
                    {
                        // Tìm thấy từ khóa trong ô, chọn dòng và thoát khỏi vòng lặp
                        row.Selected = true;
                        dgvHang.CurrentCell = cell;
                        return;
                    }
                }
            }

            // Nếu không tìm thấy từ khóa, hiển thị thông báo
            MessageBox.Show("Không tìm thấy kết quả nào phù hợp.", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            
        }

        private void bs_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem đã chọn một dòng trong DataGridView chưa
            if (dgvHang.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow selectedRow = dgvHang.SelectedRows[0];

                // Lấy dữ liệu từ dòng được chọn để truyền cho form chỉnh sửa
                string maHangHoa = selectedRow.Cells["Mahang"].Value.ToString();
                string tenHangHoa = selectedRow.Cells["Tenhang"].Value.ToString();
                string tenChatLieu = selectedRow.Cells["Tenchatlieu"].Value.ToString();
                string soLuong = selectedRow.Cells["Soluong"].Value.ToString();
                string donGiaNhap = selectedRow.Cells["Dongianhap"].Value.ToString();
                string donGiaBan = selectedRow.Cells["Dongiaban"].Value.ToString();
                string ghiChu = selectedRow.Cells["Ghichu"].Value.ToString();
                // Lấy các thông tin khác nếu cần

                // Tạo một instance của form chỉnh sửa và truyền dữ liệu
                FormSua suaForm = new FormSua(maHangHoa, tenHangHoa, tenChatLieu, soLuong, donGiaNhap, donGiaBan, ghiChu);

                // Xử lý sự kiện cập nhật sau khi form chỉnh sửa được đóng
                suaForm.CapNhatThongTin += (updatedMahang, updatedTenhang, updatedTenchatlieu, updatedSoluong, updatedDongianhap, updatedDongiaban, updatedGhichu) =>
                {
                    // Cập nhật dữ liệu trong DataGridView sau khi chỉnh sửa
                    selectedRow.Cells["Mahang"].Value = updatedMahang;
                    selectedRow.Cells["Tenhang"].Value = updatedTenhang;
                    selectedRow.Cells["Tenchatlieu"].Value = updatedTenchatlieu;
                    selectedRow.Cells["Soluong"].Value = updatedSoluong;
                    selectedRow.Cells["Dongianhap"].Value = updatedDongianhap;
                    selectedRow.Cells["Dongiaban"].Value = updatedDongiaban;
                    selectedRow.Cells["Ghichu"].Value = updatedGhichu;
                    // Cập nhật các thông tin khác nếu cần
                };

                // Hiển thị form chỉnh sửa
                suaForm.ShowDialog();
            }
        }
        
    }
}
