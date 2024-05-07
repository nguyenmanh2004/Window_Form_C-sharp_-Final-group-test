using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1.Class
{
    public  class Dungchung
    {

        public static SqlConnection cnn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataTable dt = new DataTable();
        public static SqlCommand cmd;
        public static SqlCommandBuilder cmb;
        public static void KetNoi()
        {
            try
            {
                string connectionstring = "Data Source=SQL5113.site4now.net,1433;Initial Catalog=db_aa8167_nguyenmanh1203;User Id=db_aa8167_nguyenmanh1203_admin;Password=phucdeptrai123;";
                Dungchung.cnn.ConnectionString = connectionstring;
                Dungchung.cnn.Open();
                MessageBox.Show("Kết nối thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}

