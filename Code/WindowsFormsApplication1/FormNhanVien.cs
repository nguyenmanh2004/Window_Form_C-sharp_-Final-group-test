using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Data.Odbc;
using System.Data.OleDb;
using WindowsFormsApplication1.Class;

namespace WindowsFormsApplication1
{
    public partial class FormNhanVien : Form
    {

        SqlConnection cnn = new SqlConnection();
        SqlDataAdapter daCha;
        SqlDataAdapter daCon;
        DataTable dt = new DataTable();
        SqlCommand cmdCha;
        SqlCommand cmdCon;
        SqlCommandBuilder cmb;
        BindingSource bs1 = new BindingSource();
        DataSet ds;
        SqlCommandBuilder cb;

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
            Datquanhe("MaNhanVien", "TenNhanVien");
            cb = new SqlCommandBuilder(daCon);
            BuocCacDieuKhien();
        }
        private void Datquanhe(string bangchinh, string bangphu)
        {
            cmdCha = new SqlCommand("select * from " + bangchinh, cnn);
            daCha = new SqlDataAdapter(cmdCha);
            cmdCon = new SqlCommand("select * from " + bangphu, cnn);
            daCon = new SqlDataAdapter(cmdCon);
            ds = new DataSet();
            daCha.Fill(ds, bangchinh);
            daCon.Fill(ds, bangphu);
        }
        private void BuocCacDieuKhien()
        {
            // Gán nguồn dữ liệu cho DataGridView
            bs.DataSource = ds.Tables["NhanVien"];
            dgvNhanVien.DataSource = bs;
            txtMaNV.DataBindings.Add("Text", ds, "Khuvuc.MaNV");
            txtTenNV.DataBindings.Add("Text", ds, "Khuvuc.TenNV");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = ds.Tables["NhanVien"].GetChanges();
            //Nếu có sự thay đổi sẽ phát sinh các lệnh cập nhật
            if (tbl == null)
                MessageBox.Show("Dữ liệu chưa thay đổi");
            else
            {
                cmb = new SqlCommandBuilder(daCon);
                daCon.Update(ds, "NhanVien");
                MessageBox.Show("Có " + tbl.Rows.Count + " dòng đã được cập nhật");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormNhanVien2 Nv = new FormNhanVien2(bs);
            Nv.Show();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            ds.Tables[1].DefaultView.RowFilter = "MaNV='" + txtMaNV.Text + "'";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
