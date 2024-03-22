using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ConnectDatabase
{
    public partial class Form1 : Form
    {
        string connStr = @"Data Source=LAPTOP-VT7S57G2\SQLEXPRESS;Initial Catalog=Libary;Integrated Security=True";
        string sql;
        public Form1()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                sql = "SELECT * FROM CuonSach";
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dtMain = new DataTable();
                dtMain.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dtMain;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
            //getThongTinDocGia();
            //getThongTinDauSach();
            //getThongTinNguoiLonDangMuon();
            //getThongTinNguoiLonQuaHan();
        }

        public void getThongTinDocGia()
        {
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Gọi stored procedure
                SqlCommand cmd = new SqlCommand("sp_ThongTinDocGia", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtTTDG = new DataTable();
                dtTTDG.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dtTTDG;
            }
        }
        public void getThongTinDauSach()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ThongTinDauSach", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtTTDS = new DataTable();
                dtTTDS.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dtTTDS;
            }
        }
        public void getThongTinNguoiLonDangMuon()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ThongTinNguoiLonDangMuon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtTTNLDM = new DataTable();
                dtTTNLDM.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dtTTNLDM;
            }
        }
        public void getThongTinNguoiLonQuaHan()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("sp_ThongTinNguoiLonQuaHan", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dtTTNLQH = new DataTable();
                dtTTNLQH.Load(cmd.ExecuteReader());
                dgvMain.DataSource = dtTTNLQH;
            }
        }
        public void updateStateOfCuonSach()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    sql = "exec sp_settriggerorder tg_delMuon First DELETE";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    if (cmd.ExecuteNonQuery() > 0)
                        Console.WriteLine("Trigger duoc kich hoat thang cong");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Xay ra loi!\n" + ex.Message);
                }
            }
        }
        private void UpdDauSachKhiCuonSachUpdated()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    sql = "exec sp_settriggerorder tg_updCuonSach Second UPDATE";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex){
                    MessageBox.Show("Xảy ra lỗi\n" + ex.Message);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    sql = "DELETE Muon WHERE ma_CuonSach=@ma_CuonSach";
                    SqlCommand cmd = new SqlCommand(sql, conn);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    sql = "UPDATE DauSach SET "
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update fail!\n" + ex.Message);
                }
            }
        }
    }
}
