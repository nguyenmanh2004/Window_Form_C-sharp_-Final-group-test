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
    public partial class FrmKhachHang : Form
    {
        SqlConnection cnn = new SqlConnection();
        int TrangThai = 0; //=1 là thêm; =2 là sửa 
        public FrmKhachHang()
        {
            InitializeComponent();
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            KetNoi();
            Loaddata();
            Dong_TextBox(); 
        }
         private void KetNoi() 
        { 
            string connectionstring; 
            try 
            {
                connectionstring = "server=SQL5113.site4now.net,1433;Initial Catalog=db_aa8167_nguyenmanh1203;User Id=db_aa8167_nguyenmanh1203_admin;Password=phucdeptrai123; "; 
                cnn.ConnectionString = connectionstring; 
 
                cnn.Open(); 
              //  MessageBox.Show("ket noi thanh cong"); 
 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show("loi ke noi" + ex.Message); 
            } 


        }

         private void Loaddata()
         {
             try
             {
                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = "select * from tblKhach";
                 cmd.CommandTimeout = 60;
                 cmd.Connection = cnn;
                 SqlDataReader rs;
                 rs = cmd.ExecuteReader();
                 LVData.Items.Clear();
                 while (rs.Read())
                 {
                     ListViewItem item = new ListViewItem(rs.GetValue(0).ToString());
                     item.SubItems.Add(rs.GetValue(1).ToString());
                     item.SubItems.Add(rs.GetValue(2).ToString());
                     item.SubItems.Add(rs.GetValue(3).ToString());
                     LVData.Items.Add(item);
                 }
                 rs.Close();

                 ListViewItem item2 = LVData.Items[0];
                 txtMaKH.Text = item2.SubItems[0].Text;
                 txtTenKH.Text = item2.SubItems[1].Text;
                 txtDiachi.Text = item2.SubItems[2].Text;
                 txtSoDT.Text = item2.SubItems[3].Text;
             }
             catch (Exception)
             {

             }
         }
             
             private void Them() 
        { 
            string s; 
            SqlCommand cmd = new SqlCommand(); 
            try 
            { 
 
                s = "insert into tblKhach (MaKhach, TenKhach, DiaChi, DienThoai) "; 
                s += " values(@makh,@tenkh,@dckh,@dtkh)"; 
                cmd.Connection = cnn; 
                cmd.CommandType = CommandType.Text; 
                cmd.CommandText = s; 
                cmd.Parameters.Add("@makh", SqlDbType.Float).Value = float.Parse(txtMaKH.Text); 
                cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = txtTenKH.Text; 
                cmd.Parameters.Add("@dckh", SqlDbType.NVarChar).Value = txtDiachi.Text; 
                cmd.Parameters.Add("@dtkh", SqlDbType.NVarChar).Value = txtSoDT.Text; 
                cmd.CommandTimeout = 60; 
                cmd.ExecuteNonQuery(); 
                MessageBox.Show("thanh cong"); 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show("loi them du lieu" + ex.Message); 
            } 
            Loaddata(); 
        
         }

             private void Sua()
             {
                 string s;
                 SqlCommand cmd = new SqlCommand();
                 try
                 {
                     s = "update tblKhach set TenKhach = @tenkh, DiaChi = @dckh, DienThoai =@dtkh where MaKhach = @makh ";
                     cmd.Connection = cnn;
                     cmd.CommandType = CommandType.Text;
                     cmd.CommandText = s;
                     cmd.Parameters.Add("@makh", SqlDbType.NVarChar).Value = txtMaKH.Text;
                     cmd.Parameters.Add("@tenkh", SqlDbType.NVarChar).Value = txtTenKH.Text;
                     cmd.Parameters.Add("@dckh", SqlDbType.NVarChar).Value = txtDiachi.Text;
                     cmd.Parameters.Add("@dtkh", SqlDbType.NVarChar).Value = txtSoDT.Text;
                     cmd.CommandTimeout = 60;
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("sửa dữ liệu thành công");
                     Loaddata();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("loi cap nhat du lieu" + ex.Message);
                 }
             }
        private void Xoa() 
        { 
            string s; 
            SqlCommand cmd = new SqlCommand(); 
            try 
            { 
                s = "delete from tblKhach where MaKhach = @makh"; 
                cmd.Connection = cnn; 
                cmd.CommandType = CommandType.Text; 
                cmd.CommandText = s; 
                cmd.Parameters.Add("@makh", SqlDbType.Float).Value = float.Parse(txtMaKH.Text); 
                cmd.CommandTimeout = 60; 
                cmd.ExecuteNonQuery(); 
                MessageBox.Show("xóa dữ liệu thành công "); 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show("loi xoa du lieu" + ex.Message); 
            } 
            Loaddata(); 
        }
        private void Dong_TextBox()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = false;
            }
        }
        private void Mo_TextBox()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = true;
            }
        }
        private void Xoa_Textbox()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
             string s; 
            SqlCommand cmd = new SqlCommand(); 
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tblKhach"; 
            cmd.CommandTimeout = 60; 
            cmd.Connection = cnn; 
            SqlDataReader rs; 
            rs = cmd.ExecuteReader(); 
            int i; 
            i = rs.FieldCount; 
            s = rs.GetDataTypeName(1).ToString() + " - " + rs.GetName(1) + " = \n"; 
            s = ""; 
            for (i = 0; i < rs.FieldCount; i++) 
                s += "   " + rs.GetName(i); 
            s += "\n"; 
            while (rs.Read()) 
            { 
                for (i = 0; i < rs.FieldCount; i++) 
                    s += "   " + rs.GetValue(i); 
                s += "\n"; 
            } 
            MessageBox.Show(s); 
            rs.Close(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TrangThai == 1)
            {
                Them();
                Dong_TextBox();
            }
            else if (TrangThai == 2)
            {
                Sua();
                Dong_TextBox();
            }
            else
                MessageBox.Show("Chưa thêm và chưa sửa"); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Xoa_Textbox();
            Mo_TextBox();
            TrangThai = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mo_TextBox();
            TrangThai = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Xoa(); 
        }

        private void FrmKhachHang_Leave(object sender, EventArgs e)
        {
            cnn.Close(); 
        }

        private void LVData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LVData.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                ListViewItem item = LVData.SelectedItems[0];
                txtMaKH.Text = item.SubItems[0].Text;
                txtTenKH.Text = item.SubItems[1].Text;
                txtDiachi.Text = item.SubItems[2].Text;
                txtSoDT.Text = item.SubItems[3].Text;
            }
        } 


    }
}
