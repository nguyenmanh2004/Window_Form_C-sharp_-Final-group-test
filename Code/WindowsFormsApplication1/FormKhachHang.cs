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
namespace WindowsFormsApplication1
{
    public partial class FormKhachHang : Form
    {
      
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKhach.Enabled = false;
            btnLuu.Enabled = false;
          
            LoadDataGridView();
            //KetNoi();
            Loaddata();
            //Dong_TextBox(); 
        }
        private void LoadDataGridView()
        {
            string connectionString = "Data Source=SQL5113.site4now.net,1433;Initial Catalog=db_aa8167_nguyenmanh1203;User Id=db_aa8167_nguyenmanh1203_admin;Password=phucdeptrai123;"; // Thay thế "your_connection_string" bằng chuỗi kết nối của bạn
            string sql = "SELECT * FROM tblKhach";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvKhachHang.DataSource = dataTable;
            }

            dgvKhachHang.Columns[0].HeaderText = "Mã khách";
            dgvKhachHang.Columns[1].HeaderText = "Tên khách";
            dgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns[3].HeaderText = "Điện thoại";
            dgvKhachHang.Columns[0].Width = 100;
            dgvKhachHang.Columns[1].Width = 150;
            dgvKhachHang.Columns[2].Width = 150;
            dgvKhachHang.Columns[3].Width = 150;
            dgvKhachHang.AllowUserToAddRows = false;
            dgvKhachHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void Loaddata()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from tblKhach";
                cmd.CommandTimeout = 60;
               // cmd.Connection = cnn;
                SqlDataReader rs;
                rs = cmd.ExecuteReader();
                //dgvKhachHang.Items.Clear();
                while (rs.Read())
                {
                    ListViewItem item = new ListViewItem(rs.GetValue(0).ToString());
                    item.SubItems.Add(rs.GetValue(1).ToString());
                    item.SubItems.Add(rs.GetValue(2).ToString());
                    item.SubItems.Add(rs.GetValue(3).ToString());
                    //LVData.Items.Add(item);
                }
                rs.Close();

                //ListViewItem item2 = LVData.Items[0];
                //FrmKhachHang.Text = item2.SubItems[0].Text;
                //TxtTenKH.Text = item2.SubItems[1].Text;
                //TxtDiachi.Text = item2.SubItems[2].Text;
                //TxtSoDT.Text = item2.SubItems[3].Text;
            }
            catch (Exception)
            {

            }
        } 

    }
}
