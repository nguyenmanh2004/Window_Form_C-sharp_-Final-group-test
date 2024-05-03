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
    public static class Dungchung
    {

        public static SqlConnection cnn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataTable dt = new DataTable();
        public static SqlDataAdapter daKhachHang;
        public static DataTable dtKhachHang = new DataTable();
        public static SqlDataAdapter daNhanvien;
        public static DataTable dtNhanvien = new DataTable();
        public static SqlDataAdapter daHang;
        public static DataTable dtHang = new DataTable();
        public static SqlCommand cmd;
        public static SqlCommandBuilder cmb;
        public static void KetNoi()
        {
            string connectionstring;
            try
            {
                connectionstring = "server=SQL5113.site4now.net";
                connectionstring += ";database='db_aa8167_nguyenmanh1203'";
                connectionstring += ";User Id=db_aa8167_nguyenmanh1203_admin";
                connectionstring += ";Password=phucdeptrai123";
                //connectionstring += ";integrated security=true";
                Dungchung.cnn.ConnectionString = connectionstring;
                //Dungchung.cnn.Open();
                //MessageBox.Show("ket noi thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("loi ke noi" + ex.Message);
            }


        }
    }
}

