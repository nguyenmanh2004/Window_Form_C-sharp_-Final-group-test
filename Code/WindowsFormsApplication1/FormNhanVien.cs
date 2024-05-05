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
using System.Data.SqlTypes;
using System.Configuration;

using WindowsFormsApplication1.Class;

namespace WindowsFormsApplication1
{
    public partial class FormNhanVien : Form
    {
        SqlConnection cnn = new SqlConnection("Data Source=SQL5113.site4now.net,1433;Initial Catalog=db_aa8167_nguyenmanh1203;User Id=db_aa8167_nguyenmanh1203_admin;Password=phucdeptrai123;");
        SqlDataAdapter daCha;
        SqlDataAdapter daCon;
        DataTable dt = new DataTable();
        SqlCommand cmdCha;
        SqlCommand cmdCon;
        SqlCommandBuilder cmb;
        BindingSource bs1 = new BindingSource();
        DataSet ds;
        SqlCommandBuilder cb;
        Dungchung dc = new Dungchung();
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void bs_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate
           && e.Exception == null)
            {
                e.Binding.BindingManagerBase.EndCurrentEdit();
            }

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            Dungchung.KetNoi();
            Datquanhe( "MaNhanVien");
           
            BuocCacDieuKhien();
           
        }
        private void Datquanhe( string bangphu)
        {
            cmdCha = new SqlCommand("select * from tblNhanVien" , cnn);
            daCha = new SqlDataAdapter(cmdCha);
            
            ds = new DataSet();
            daCha.Fill(ds, "tblNhanVien");
            
        }
        private void BuocCacDieuKhien()
        {
            // Gán nguồn dữ liệu cho DataGridView
            bs1.DataSource = ds.Tables["tblNhanVien"];
            dgvNhanVien.DataSource = bs1;
           //txtMaNV.DataBindings.Add("Text", ds, "tblNhanVien.MaNhanVien");
            //txtTenNV.DataBindings.Add("Text", ds, "Khuvuc.TenNV");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = ds.Tables["tblNhanVien"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                cmb = new SqlCommandBuilder(daCha);
                daCha.Update(ds, "tblNhanVien");
                MessageBox.Show("Có " + tbl.Rows.Count + " dòng đã được cập nhật");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormNhanVien2 Nv = new FormNhanVien2(bs1);
            Nv.Show();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[1].DefaultView.RowFilter = "MaNhanVien='" + txtMaNV.Text + "'";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
