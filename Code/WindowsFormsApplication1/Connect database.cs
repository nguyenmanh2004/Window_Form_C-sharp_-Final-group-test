using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Odbc;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Connect_database : Form
    {
        public string Serv;
        public string Dat;
        public Connect_database()
        {
            InitializeComponent();
        }

        private void Connect_database_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // ket noi sql
                string connectionstring;
                SqlConnection cnn = new SqlConnection();
                connectionstring = "Data Source=" + txtserver.Text;
                connectionstring += ";Initial Catalog=" + txtdatabase.Text;
                connectionstring += ";User Id=" + txtuser.Text;
                connectionstring += ";Password=" + txtpass.Text;
               
                cnn.ConnectionString = connectionstring;
                cnn.Open();
                MessageBox.Show("ket noi thanh cong");
                cnn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("loi ke noi" + ex.Message);
            }
        }
    }
}
