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

namespace _Final_Project_Cinema_Theater
{
    public partial class FrmQLRapPhim : Form
    {
        public FrmQLRapPhim()
        {
            InitializeComponent();
            isCheckedOpen();
            // Khởi tạo kết nối trong constructor
        }
        // Tạo kết nối với database thông qua class SQLCONNECTION
        SQLCONNECTION connDB = new SQLCONNECTION();
        
        public void isCheckedOpen()
        {
            // Ensure any existing DataReader is closed before proceeding
            if (connDB.conn.State != ConnectionState.Closed)
                connDB.conn.Close();

            // Open a new connection
            if (connDB.conn.State != ConnectionState.Open)
                connDB.conn.Open();
        }


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void InfoPhongChieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmQLRapPhim_Load(object sender, EventArgs e)
        {
            isCheckedOpen();

            //Thông tin admin
            string sql1 = "SELECT * FROM NhanVien WHERE idNV = 'NV00'";
            SqlCommand cmd = new SqlCommand(sql1, connDB.conn);
            SqlDataReader dta = cmd.ExecuteReader();
            if (dta.Read() == true)
            {
                //Dùng label để hiển thị thông tin admin
                LbTen.Text = dta["HoTen"].ToString();
                LbDiaChi.Text = dta["DiaChi"].ToString();
                LbCCCD.Text = dta["CCCD"].ToString();
                //Chỉ hiển thị ngày sinh không hiển thị giờ
                LbNgaySinh.Text = dta["NgaySinh"].ToString().Split(' ')[0];
                LbSDT.Text = dta["SDT"].ToString();
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mở form thông tin nhân viên
            FrmInfoNhanVien f = new FrmInfoNhanVien();
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mở form thông tin khách hàng
            FrmInfoKhachHang f = new FrmInfoKhachHang();
            f.Show();
        }

        private void thêmPhimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mở form phim
            FrmAddPhim f = new FrmAddPhim();
            f.Show();
        }

        private void thêmXuấtChiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mở form xuất chiếu
            FrmXuatChieu f = new FrmXuatChieu();
            f.Show();
        }

        private void doanhThuPhimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mở form doanh thu
            FrmDoanhThu f = new FrmDoanhThu();
            f.Show();
        }

        //Hàm đổi màu nút khi click của 4 nút phòng chiếu
        public void ChangeColorButton(Button btn)
        {
            // Đặt màu xám cho tất cả các nút
            BtnPhong4.BackColor = Color.BlueViolet;
            BtnPhong1.BackColor = Color.BlueViolet;
            BtnPhong2.BackColor = Color.BlueViolet;
            BtnPhong3.BackColor = Color.BlueViolet;

            // Đặt màu đỏ cho nút được click
            btn.BackColor = Color.Red;
        }


        private void BtnPhong2_Click(object sender, EventArgs e)
        {
            isCheckedOpen();
            // Hiển thị thông tin ở bảng Ve và bảng LichChieu thông qua idLichChieu. Và idLichChieu = LC01
            string sql = @"SELECT Ve.TienBanVe, Ve.idNV, Ve.MaGheNgoi, LichChieu.TrangThai, Phim.TenPhim
                FROM Ve
                INNER JOIN LichChieu ON Ve.idLichChieu = LichChieu.idLichChieu
                INNER JOIN Phim ON LichChieu.idPhim = Phim.idPhim
                WHERE Ve.idLichChieu = 'LC01'";
            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                using (SqlDataAdapter dta = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dta.Fill(dt);
                    InfoPhongChieu.DataSource = dt;
                }
            }
            ChangeColorButton(BtnPhong1);
        }

        private void BtnPhong3_Click(object sender, EventArgs e)
        {
            isCheckedOpen();
            string sql = @"SELECT Ve.TienBanVe, Ve.idNV, Ve.MaGheNgoi, LichChieu.TrangThai, Phim.TenPhim
                FROM Ve
                INNER JOIN LichChieu ON Ve.idLichChieu = LichChieu.idLichChieu
                INNER JOIN Phim ON LichChieu.idPhim = Phim.idPhim
                WHERE Ve.idLichChieu = 'LC02'";
            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                using (SqlDataAdapter dta = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dta.Fill(dt);
                    InfoPhongChieu.DataSource = dt;
                }
            }
            ChangeColorButton(BtnPhong2);
        }

        private void BtnPhong4_Click(object sender, EventArgs e)
        {
            isCheckedOpen();
            string sql = @"SELECT Ve.TienBanVe, Ve.idNV, Ve.MaGheNgoi, LichChieu.TrangThai, Phim.TenPhim
                FROM Ve
                INNER JOIN LichChieu ON Ve.idLichChieu = LichChieu.idLichChieu
                INNER JOIN Phim ON LichChieu.idPhim = Phim.idPhim
                WHERE Ve.idLichChieu = 'LC03'";
            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                using (SqlDataAdapter dta = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dta.Fill(dt);
                    InfoPhongChieu.DataSource = dt;
                }
            }
            ChangeColorButton(BtnPhong3);
        }

        private void BtnPhong4_Click_1(object sender, EventArgs e)
        {
            isCheckedOpen();
            string sql = @"SELECT Ve.TienBanVe, Ve.idNV, Ve.MaGheNgoi, LichChieu.TrangThai, Phim.TenPhim
                FROM Ve
                INNER JOIN LichChieu ON Ve.idLichChieu = LichChieu.idLichChieu
                INNER JOIN Phim ON LichChieu.idPhim = Phim.idPhim
                WHERE Ve.idLichChieu = 'LC04'";
            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                using (SqlDataAdapter dta = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    dta.Fill(dt);
                    InfoPhongChieu.DataSource = dt;
                }
            }
            ChangeColorButton(BtnPhong4);
        }

        private void LbCCCD_Click(object sender, EventArgs e)
        {

        }
    }
}

