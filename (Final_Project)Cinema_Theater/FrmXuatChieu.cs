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
    public partial class FrmXuatChieu : Form
    {
        BindingSource showtimeList = new BindingSource();
        public FrmXuatChieu()
        {
            InitializeComponent();
        }
        // Khởi tạo kết nối trong constructor
        SQLCONNECTION connDB = new SQLCONNECTION();
        SQLCONNECTION adp = new SQLCONNECTION();
        SQLCONNECTION table = new SQLCONNECTION();
        SQLCONNECTION dta = new SQLCONNECTION();
        private void FrmXuatChieu_Load(object sender, EventArgs e)
        {
            DtpGioChieu.ValueChanged += DtpGioChieu_ValueChanged;
            //Tạo lệnh sql để hiển thị thông tin của bảng LichChieu gồm idLichChieu, GioChieu, idPhongChieu, GiaVe, TrangThai, TenPhim
            //Dựa vào idPhim có ở trong bảng LichChieu để lấy tên phim từ bảng Phim
            string sql = "Select LichChieu.idLichChieu, GioChieu, PhongChieu.TenPhong, GiaVe, TenPhim from LichChieu, PhongChieu, Phim where LichChieu.idPhongChieu = PhongChieu.idPhongChieu and LichChieu.idPhim = Phim.idPhim";
            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //Trả kết quả về DsXuatChieu
            SqlDataAdapter adp = new SqlDataAdapter(sql, connDB.conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            DsXuatChieu.DataSource = table;
            LoadDataForPhongChieu();
            LoadDataForTenPhim();
            connDB.conn.Close();
        }

        private void DsXuatChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check that the clicked row index is valid
            {
                LoadDataForPhongChieu();
                LoadDataForTenPhim();
                //Lấy giá trị của hàng được chọn
                int index = e.RowIndex;
                TxtIDLC.Text = DsXuatChieu.Rows[index].Cells[0].Value.ToString();
                DtpGioChieu.Text = DsXuatChieu.Rows[index].Cells[1].Value.ToString();
                CbPhongChieu.Text = DsXuatChieu.Rows[index].Cells[2].Value.ToString();
                TxtGiaVe.Text = DsXuatChieu.Rows[index].Cells[3].Value.ToString();
                CbTenPhim.Text = DsXuatChieu.Rows[index].Cells[4].Value.ToString();
            }
        }

        //Hàm lấy giá trị cho combobox PhongChieu
        private void LoadDataForPhongChieu()
        {
            //Tạo lệnh sql để hiển thị thông tin của bảng PhongChieu gồm idPhongChieu, TenPhong, SoGhe, TrangThai
            string sql = "Select * from PhongChieu";
            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //Trả kết quả về CbPhongChieu
            SqlDataAdapter adp = new SqlDataAdapter(sql, connDB.conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            CbPhongChieu.DataSource = table;
            CbPhongChieu.DisplayMember = "TenPhong";
            CbPhongChieu.ValueMember = "idPhongChieu";
            connDB.conn.Close();
        }
        //Hàm lấy giá trị cho combobox TenPhim
        private void LoadDataForTenPhim()
        {
            // Lấy phần ngày (date) của NgayKhoiChieu và NgayKetThuc của từng phim để tạo khoảng thời gian phù hợp
            string sql = "SELECT * FROM Phim " +
                         "WHERE '" + DtpGioChieu.Value.ToString("yyyy-MM-dd") + "' BETWEEN NgayKhoiChieu AND NgayKetThuc";

            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }

            //Trả kết quả về CbTenPhim
            SqlDataAdapter adp = new SqlDataAdapter(sql, connDB.conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            CbTenPhim.DataSource = table;
            CbTenPhim.DisplayMember = "TenPhim";
            CbTenPhim.ValueMember = "idPhim";
            connDB.conn.Close();
        }

        private void DtpGioChieu_ValueChanged(object sender, EventArgs e)
        {
            LblNgayChieu.Text = DtpGioChieu.Value.ToShortDateString();

            // Gọi lại hàm LoadDataForTenPhim để cập nhật dữ liệu cho ComboBox CbTenPhim
            LoadDataForTenPhim();
        }

        private void ToolTripSearch_Click(object sender, EventArgs e)
        {
            // Tạo lệnh để lấy thông tin từ TxtSearch để tìm kiếm thông tin trong bảng LichChieu
            string sql = "Select LichChieu.idLichChieu, GioChieu, PhongChieu.TenPhong, GiaVe, TenPhim from LichChieu, PhongChieu, Phim where LichChieu.idPhongChieu = PhongChieu.idPhongChieu and LichChieu.idPhim = Phim.idPhim and TenPhim like N'%" + TxtSearch.Text + "%'";
            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //Trả kết quả về DsXuatChieu
            SqlDataAdapter adp = new SqlDataAdapter(sql, connDB.conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            DsXuatChieu.DataSource = table;
            // nếu không tìm thấy thông báo không tìm thấy VÀ load lại dữ liệu
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy");
                FrmXuatChieu_Load(sender, e);
            }

            //nếu TxtSearch rỗng thì load lại dữ liệu
            if (TxtSearch.Text == "")
            {
                FrmXuatChieu_Load(sender, e);
            }
            connDB.conn.Close();
        }

        private void toolStripThem_Click(object sender, EventArgs e)
        {
            //NẾU CHƯA NHẬP ĐỦ THÔNG TIN THÌ HIỂN THỊ THÔNG BÁO 
            if (TxtIDLC.Text == "" || DtpGioChieu.Text == "" || CbPhongChieu.Text == "" || TxtGiaVe.Text == "" || CbTenPhim.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                return;
            }
            string gioChieu = DtpGioChieu.Value.ToString("yyyy-MM-dd HH:mm:ss");

            //hiện thông báo nếu trùng idLichChieu
            string sqlCheck = "Select * from LichChieu where idLichChieu = '" + TxtIDLC.Text + "'";
            //Tạo lệnh sql để thêm thông tin vào bảng LichChieu
            string sql = "Insert into LichChieu(idLichChieu, GioChieu, idPhongChieu, GiaVe, idPhim) values ('" + TxtIDLC.Text + "', '" + gioChieu + "', '" + CbPhongChieu.SelectedValue + "', '" + TxtGiaVe.Text + "', '" + CbTenPhim.SelectedValue + "')";
            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //Kiểm tra cú pháp của idLichChieu là LC và số không tính số lượng số đằng sau LC
            if (TxtIDLC.Text.Substring(0, 2) != "LC" || TxtIDLC.Text.Substring(2).Any(char.IsLetter))
            {
                MessageBox.Show("Mã Lịch Chiếu phải bắt đầu bằng 'LC' và theo sau là số");
                return;
            }
            //Kiểm tra idLichChieu đã tồn tại chưa
            SqlCommand cmdCheck = new SqlCommand(sqlCheck, connDB.conn);
            SqlDataReader dta = cmdCheck.ExecuteReader();
            if (dta.Read() == true)
            {
                MessageBox.Show("Mã Lịch Chiếu đã tồn tại");
                return;
            }
            connDB.conn.Close();
            connDB.conn.Open();
            //Thực thi lệnh sql
            SqlCommand cmd = new SqlCommand(sql, connDB.conn);
            cmd.ExecuteNonQuery();
            //Hiển thị thông báo
            MessageBox.Show("Thêm thành công");
            //Load lại dữ liệu
            FrmXuatChieu_Load(sender, e);
            connDB.conn.Close();
        }

        private void CbPhongChieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //truyền data cột PhongChieu vào CbPhongChieu
            CbPhongChieu.ValueMember = "idPhongChieu";
            CbPhongChieu.DisplayMember = "TenPhong";
        }

        private void toolStripSua_Click(object sender, EventArgs e)
        {

            //NẾU THÔNG TIN GIỐNG BAN ĐẦU THÌ HIỂN THỊ THÔNG BÁO
            if (TxtIDLC.Text == "" || DtpGioChieu.Text == "" || CbPhongChieu.Text == "" || TxtGiaVe.Text == "" || CbTenPhim.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin cần sửa");
                return;
            }
            string gioChieu = DtpGioChieu.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //Tạo lệnh sql để sửa thông tin trong bảng LichChieu
            string sql = "Update LichChieu set GioChieu = '" + gioChieu + "', idPhongChieu = '" + CbPhongChieu.SelectedValue + "', GiaVe = '" + TxtGiaVe.Text + "', idPhim = '" + CbTenPhim.SelectedValue + "' where idLichChieu = '" + TxtIDLC.Text + "'";
            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //Thực thi lệnh sql
            SqlCommand cmd = new SqlCommand(sql, connDB.conn);
            cmd.ExecuteNonQuery();
            //Hiển thị thông báo
            MessageBox.Show("Sửa thành công");
            //Load lại dữ liệu
            FrmXuatChieu_Load(sender, e);
            connDB.conn.Close();
        }

        private void toolStripXoa_Click(object sender, EventArgs e)
        {
            //NẾU CHƯA CHỌN THÔNG TIN CẦN XÓA THÌ HIỂN THỊ THÔNG BÁO
            if (TxtIDLC.Text == "" || DtpGioChieu.Text == "" || CbPhongChieu.Text == "" || TxtGiaVe.Text == "" || CbTenPhim.Text == "")
            {
                MessageBox.Show("Vui lòng chọn thông tin cần xóa");
                return;
            }
            //Tạo lệnh sql để xóa thông tin trong bảng LichChieu
            string sql = "Delete from LichChieu where idLichChieu = '" + TxtIDLC.Text + "'";
            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //Thực thi lệnh sql
            SqlCommand cmd = new SqlCommand(sql, connDB.conn);
            cmd.ExecuteNonQuery();
            //Hiển thị thông báo
            MessageBox.Show("Xóa thành công");
            //Load lại dữ liệu
            FrmXuatChieu_Load(sender, e);
            connDB.conn.Close();
        }

        private void CbTenPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            //truyền data cột TenPhim vào CbTenPhim
            CbTenPhim.ValueMember = "idPhim";
            CbTenPhim.DisplayMember = "TenPhim";
        }

        private void DsXuatChieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}