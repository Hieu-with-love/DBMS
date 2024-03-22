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
using System.Data;

namespace CallFunctionsFromCSharp
{
    public partial class Form1 : Form
    {
        string connStr = @"Data Source=LAPTOP-VT7S57G2\SQLEXPRESS;Initial Catalog=Libary;Integrated Security=True";
        string sqlQuery;
        public Form1()
        {
            InitializeComponent();
            ConnectToDatabase();
            //getLuongTBByPB();
            //getTongLuongNhanVienTheoDuAn();
            //getTongLuongTheoTungPB();
            //getTienThuongChoNV();
            //getSoDATheoPB();
            //getInfoNV();
        }
        public void ConnectToDatabase()
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                sqlQuery = "SELECT * FROM CuonSach";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                DataTable dtMain = new DataTable();
                dtMain.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dtMain;
            }
        }
        public void getLuongTBByPB()
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.TinhTongLuongTB(@mapb)", conn);
                var param1 = "A01";
                cmd.Parameters.AddWithValue("@mapb", param1);
                decimal salary = (decimal)cmd.ExecuteScalar();
                Console.WriteLine($"Trung bình lương của các nhân viên trong phòng ban {param1} là {salary}");
            }
        }
        public void getTongLuongNhanVienTheoDuAn()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.TinhTongLuongTheoDA(@manv,@maDA)", conn);
                var param1 = "NV000001";
                var param2 = "DA01";
                cmd.Parameters.AddWithValue("@manv", param1);
                cmd.Parameters.AddWithValue("@maDA", param2);
                decimal totalSalary = (decimal)cmd.ExecuteScalar();
                Console.WriteLine($"Tổng lương nhân viên {param1} theo dự án {param2} là {totalSalary}");
            }
        }
        public void getTongLuongTheoTungPB()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TinhTongLuongTBTungPB()", conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dt;
            }
        }
        public void getTienThuongChoNV()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TinhTienThuongChoNV()", conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dt;
            }
        }
        public void getSoDATheoPB()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.TinhTongSoDATheoPB()", conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dt;
            }
        }
        public void getInfoNV()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.getInfoNhanVien()", conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dt;
            }
        }
        

        private void btnDel_Click(object sender, EventArgs e)
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    sqlQuery = "DELETE Muon WHERE ma_CuonSach=@ma_CuonSach";
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    cmd.Parameters.AddWithValue("@ma_CuonSach", "CS004");
                    if (cmd.ExecuteNonQuery() > 0)
                        MessageBox.Show("Deleted successful !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete fail\n" + ex.Message);
                }
            }
            ConnectToDatabase();
        }
    }
}
