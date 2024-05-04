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
using WindowsFormsApplication1.Class;

namespace WindowsFormsApplication1
{
    public partial class FormNhanVien2 : Form
    {
        private BindingSource formDataSource;
        public FormNhanVien2(BindingSource dataSource)
        {
            InitializeComponent();
         

            formDataSource = dataSource;
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", formDataSource, Dungchung.dt.Columns[0].ColumnName,
            true, DataSourceUpdateMode.OnPropertyChanged);


            txtTenNV.DataBindings.Add("Text", formDataSource, Dungchung.dt.Columns[0].ColumnName,
            true, DataSourceUpdateMode.OnPropertyChanged);

            txtNgaySinh.DataBindings.Add("Text", formDataSource, Dungchung.dt.Columns[0].ColumnName,
            true, DataSourceUpdateMode.OnPropertyChanged);

            txtGioiTinh.DataBindings.Add("Text", formDataSource, Dungchung.dt.Columns[0].ColumnName,
            true, DataSourceUpdateMode.OnPropertyChanged);

            txtDiaChi.DataBindings.Add("Text", formDataSource, Dungchung.dt.Columns[0].ColumnName,
            true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
