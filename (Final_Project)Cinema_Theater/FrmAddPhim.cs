using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Final_Project_Cinema_Theater
{
    public partial class FrmAddPhim : Form
    {
        public SqlConnection conn;
        public SqlCommand cmd;
        public SqlDataReader dta;
        public DataTable dt;
        public FrmAddPhim()
        {
            InitializeComponent();
        }
        // Khởi tạo kết nối trong constructor
        SQLCONNECTION connDB = new SQLCONNECTION();

        private void DsPhim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmAddPhim_Load(object sender, EventArgs e)
        {
            string sql = @"SELECT 
                    Phim.idPhim, 
                    Phim.TenPhim, 
                    Phim.Mota, 
                    Phim.ThoiLuong, 
                    Phim.NgayKhoiChieu, 
                    Phim.NgayKetThuc, 
                    Phim.QuocGiaSanXuat, 
                    Phim.DaoDien, 
                    Phim.NamSX, 
                    Phim.ApPhich, 
                    Phim.DinhDangPhim,
                    STUFF((SELECT ', ' + TheLoai.TenTheLoai
                           FROM PhanLoaiPhim
                           INNER JOIN TheLoai ON PhanLoaiPhim.idTheLoai = TheLoai.idTheLoai
                           WHERE PhanLoaiPhim.idPhim = Phim.idPhim
                           FOR XML PATH('')), 1, 2, '') AS TenTheLoai,
                    STUFF((SELECT ', ' + TheLoai.Mota
                           FROM PhanLoaiPhim
                           INNER JOIN TheLoai ON PhanLoaiPhim.idTheLoai = TheLoai.idTheLoai
                           WHERE PhanLoaiPhim.idPhim = Phim.idPhim
                           FOR XML PATH('')), 1, 2, '') AS MoTaTheLoai
                FROM 
                    Phim;";

            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //truyền dữ liệu vào DsPhim
            SqlDataAdapter adp = new SqlDataAdapter(sql, connDB.conn);
            DataTable table = new DataTable();
            adp.Fill(table);
            DsPhim.DataSource = table;
            // Đóng kết nối
            connDB.conn.Close();
        }

        private void DsPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            // Lấy dòng được chọn và hiển thị thông tin phim
            int row = e.RowIndex;
            //Lấy thông tin từ dsPhim lên các textbox và combobox và picturebox
            TxtIDP.Text = DsPhim.Rows[row].Cells[0].Value.ToString();
            TxtTenP.Text = DsPhim.Rows[row].Cells[1].Value.ToString();
            TxtMoTa.Text = DsPhim.Rows[row].Cells[2].Value.ToString();
            TxtThoiLuong.Text = DsPhim.Rows[row].Cells[3].Value.ToString();
            if (DsPhim.Rows[row].Cells[4].Value != DBNull.Value)
            {
                DtpNgayKhoiChieu.Value = Convert.ToDateTime(DsPhim.Rows[row].Cells[4].Value);
            }
            //DtpNgayKhoiChieu.Value = Convert.ToDateTime(DsPhim.Rows[row].Cells[4].Value);
            if (DsPhim.Rows[row].Cells[5].Value != DBNull.Value)
            {
                DtpNgayKetThuc.Value = Convert.ToDateTime(DsPhim.Rows[row].Cells[5].Value);
            }
            //DtpNgayKetThuc.Value = Convert.ToDateTime(DsPhim.Rows[row].Cells[5].Value);
            TxtQuocGia.Text = DsPhim.Rows[row].Cells[6].Value.ToString();
            TxtDaoDien.Text = DsPhim.Rows[row].Cells[7].Value.ToString();
            TxtNamSX.Text = DsPhim.Rows[row].Cells[8].Value.ToString();
            //Truyền ảnh từ cột 9 vào picturebox
            if (DsPhim.Rows[row].Cells[9].Value != DBNull.Value)
            {
                byte[] img = (byte[])DsPhim.Rows[row].Cells[9].Value;
                PbApPhich.Image = Image.FromStream(new System.IO.MemoryStream(img));
            }
            else
            {
                PbApPhich.Image = null;
            }
            //Truyền dữ liệu từ cột 10 vào combobox DinhDangPhim
            CboDinhDangPhim.Text = DsPhim.Rows[row].Cells[10].Value.ToString();


            // Lấy danh sách thể loại của phim từ cột TenTheLoai (cột 10)
            string[] theloai = DsPhim.Rows[row].Cells[11].Value.ToString().Split(',');

            foreach (Control control in GrbTheLoai.Controls)
            {
                if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false; // Đặt trạng thái unchecked mặc định

                    foreach (string genre in theloai)
                    {
                        if (checkBox.Text.Trim().ToLower() == genre.Trim().ToLower())
                        {
                            checkBox.Checked = true; // Nếu thể loại của checkbox trùng với thể loại của phim, chọn checkbox
                            break; // Thoát khỏi vòng lặp khi đã tìm thấy
                        }
                    }
                }
            }
        }

        private void CboDinhDangPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cho chọn giá trị đầu tiên là 2D
            if (CboDinhDangPhim.SelectedIndex == 0)
            {
                CboDinhDangPhim.Text = "2D";
            }
            else
            {
                CboDinhDangPhim.Text = "3D";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // Cập nhật phim
            // Lấy thông tin từ các textbox và combobox
            string idPhim = TxtIDP.Text;
            string tenPhim = TxtTenP.Text;
            string moTa = TxtMoTa.Text;
            string thoiLuong = TxtThoiLuong.Text;
            DateTime ngayKhoiChieu = DtpNgayKhoiChieu.Value;
            DateTime ngayKetThuc = DtpNgayKetThuc.Value;
            string quocGiaSanXuat = TxtQuocGia.Text;
            string daoDien = TxtDaoDien.Text;
            string namSX = TxtNamSX.Text;
            string dinhDangPhim = CboDinhDangPhim.Text;
            

            // Lấy danh sách thể loại từ các checkbox
            List<string> theLoai = new List<string>();
            foreach (Control control in GrbTheLoai.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    theLoai.Add(checkBox.Text);
                }
            }

            // Thực hiện cập nhật phim vào cơ sở dữ liệu
            string sql = @"UPDATE Phim SET 
                        TenPhim = @tenPhim, 
                        Mota = @moTa, 
                        ThoiLuong = @thoiLuong, 
                        NgayKhoiChieu = @ngayKhoiChieu, 
                        NgayKetThuc = @ngayKetThuc, 
                        QuocGiaSanXuat = @quocGiaSanXuat, 
                        DaoDien = @daoDien, 
                        NamSX = @namSX, 
                        ApPhich = @apPhich, 
                        DinhDangPhim = @dinhDangPhim 
                    WHERE idPhim = @idPhim";


            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                //Kiểm tra nhập đủ thông tin
                if (string.IsNullOrWhiteSpace(tenPhim) || string.IsNullOrWhiteSpace(moTa) || string.IsNullOrWhiteSpace(thoiLuong) ||
                    string.IsNullOrWhiteSpace(quocGiaSanXuat) || string.IsNullOrWhiteSpace(daoDien) || string.IsNullOrWhiteSpace(namSX) ||
                    string.IsNullOrWhiteSpace(dinhDangPhim) || PbApPhich.Image == null || theLoai.Count == 0)
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Ngăn không cho cập nhật phim
                }
                else if (!IsProductionYearBeforeReleaseYear(namSX, ngayKhoiChieu))
                {
                    MessageBox.Show("Năm sản xuất không thể sớm hơn năm khởi chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Ngăn không cho cập nhật phim
                }
                else if (!IsReleaseDateBeforeEndDate(ngayKhoiChieu, ngayKetThuc))
                {
                    MessageBox.Show("Ngày khởi chiếu không thể sớm hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Ngăn không cho cập nhật phim
                }
                //Kiểm tra id có tồn tại chưa
                else if (!IsIDExists(idPhim))
                {
                    MessageBox.Show("ID phim không tồn tại. Vui lòng chọn ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Ngăn không cho cập nhật phim
                }
                cmd.Parameters.AddWithValue("@tenPhim", tenPhim);
                cmd.Parameters.AddWithValue("@moTa", moTa);
                cmd.Parameters.AddWithValue("@thoiLuong", thoiLuong);
                cmd.Parameters.AddWithValue("@ngayKhoiChieu", ngayKhoiChieu);
                cmd.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);
                cmd.Parameters.AddWithValue("@quocGiaSanXuat", quocGiaSanXuat);
                cmd.Parameters.AddWithValue("@daoDien", daoDien);
                cmd.Parameters.AddWithValue("@namSX", namSX);
                cmd.Parameters.AddWithValue("@dinhDangPhim", dinhDangPhim);
                cmd.Parameters.AddWithValue("@idPhim", idPhim);
                // Cập nhật áp phích
                MemoryStream ms = new MemoryStream();
                PbApPhich.Image.Save(ms, PbApPhich.Image.RawFormat);
                byte[] apPhichBytes = ms.ToArray();
                SqlParameter apPhichParam = new SqlParameter("@apPhich", SqlDbType.Image);
                apPhichParam.Value = apPhichBytes;
                cmd.Parameters.Add(apPhichParam);

                connDB.conn.Open();
                cmd.ExecuteNonQuery();
                connDB.conn.Close();
            }

            // Xóa thể loại của phim trong bảng PhanLoaiPhim
            string deleteGenreSql = @"DELETE FROM PhanLoaiPhim WHERE idPhim = @idPhim";
            using (SqlCommand cmd = new SqlCommand(deleteGenreSql, connDB.conn))
            {
                cmd.Parameters.AddWithValue("@idPhim", idPhim);

                connDB.conn.Open();
                cmd.ExecuteNonQuery();
                connDB.conn.Close();
            }

            // Thêm lại thể loại của phim vào bảng PhanLoaiPhim
            foreach (string genre in theLoai)
            {
                string genreId = GetGenreId(genre); // Hàm GetGenreId là hàm tự định nghĩa để lấy id của thể loại từ tên thể loại
                string insertGenreSql = @"INSERT INTO PhanLoaiPhim (idPhim, idTheLoai) VALUES (@idPhim, @idTheLoai)";
                using (SqlCommand cmd = new SqlCommand(insertGenreSql, connDB.conn))
                {
                    cmd.Parameters.AddWithValue("@idPhim", idPhim);
                    cmd.Parameters.AddWithValue("@idTheLoai", genreId);

                    connDB.conn.Open();
                    cmd.ExecuteNonQuery();
                    connDB.conn.Close();
                }
            }

            // Hiển thị thông báo thành công
            MessageBox.Show("Cập nhật phim thành công!");
            // Load lại dsphim
            FrmAddPhim_Load(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Chọn ảnh từ máy tính
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PbApPhich.Image = new Bitmap(ofd.FileName);
            }
        }
        //Hàm kiểm tra id đã tồn tại chưa
        private bool IsIDExists(string idPhim)
        {
            string sql = "SELECT COUNT(*) FROM Phim WHERE idPhim = @idPhim";
            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                cmd.Parameters.AddWithValue("@idPhim", idPhim);
                connDB.conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                connDB.conn.Close();
                return count > 0;
            }
        }
        //Hàm kiểm tra tên phim đã tồn tại chưa
        private bool IsPhimExists(string tenPhim)
        {
            string sql = "SELECT COUNT(*) FROM Phim WHERE TenPhim = @tenPhim";
            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                cmd.Parameters.AddWithValue("@tenPhim", tenPhim);
                connDB.conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                connDB.conn.Close();
                return count > 0;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Thêm phim mới
            // Lấy thông tin từ các textbox và combobox
            string idPhim = TxtIDP.Text;
            string tenPhim = TxtTenP.Text;
            string moTa = TxtMoTa.Text;
            string thoiLuong = TxtThoiLuong.Text;
            DateTime ngayKhoiChieu = DtpNgayKhoiChieu.Value;
            DateTime ngayKetThuc = DtpNgayKetThuc.Value;
            string quocGiaSanXuat = TxtQuocGia.Text;
            string daoDien = TxtDaoDien.Text;
            string namSX = TxtNamSX.Text;
            string dinhDangPhim = CboDinhDangPhim.Text;

            // Lấy danh sách thể loại từ các checkbox
            List<string> theLoai = new List<string>();
            foreach (Control control in GrbTheLoai.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    theLoai.Add(checkBox.Text);
                }
            }
            // Kiểm tra ID phim đã tồn tại chưa
            if (IsIDExists(idPhim))
            {
                MessageBox.Show("ID phim đã tôn tại. Vui lòng chọn ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngăn không cho thêm phim
            }

            // Kiểm tra tên phim đã tồn tại chưa
            else if (IsPhimExists(tenPhim))
            {
                MessageBox.Show("Tên phim đã tồn tại. Vui lòng chọn tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngăn không cho thêm phim
            }

            // Kiểm tra nhập đủ thông tin
            if (string.IsNullOrWhiteSpace(tenPhim) || string.IsNullOrWhiteSpace(moTa) || string.IsNullOrWhiteSpace(thoiLuong) ||
                string.IsNullOrWhiteSpace(quocGiaSanXuat) || string.IsNullOrWhiteSpace(daoDien) || string.IsNullOrWhiteSpace(namSX) ||
                string.IsNullOrWhiteSpace(dinhDangPhim) || PbApPhich.Image == null || theLoai.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngăn không cho thêm phim
            }
            else if (!IsProductionYearBeforeReleaseYear(namSX, ngayKhoiChieu))
            {
                MessageBox.Show("Năm sản xuất không thể sớm hơn năm khởi chiếu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngăn không cho cập nhật phim
            }
            else if (!IsReleaseDateBeforeEndDate(ngayKhoiChieu, ngayKetThuc))
            {
                MessageBox.Show("Ngày khởi chiếu không thể sớm hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngăn không cho cập nhật phim
            }

            // Thực hiện thêm phim mới vào cơ sở dữ liệu thêm áp phich
            string sql = @"INSERT INTO Phim (idPhim, TenPhim, Mota, ThoiLuong, NgayKhoiChieu, NgayKetThuc, QuocGiaSanXuat, DaoDien, NamSX, ApPhich, DinhDangPhim)
        VALUES (@idPhim, @tenPhim, @moTa, @thoiLuong, @ngayKhoiChieu, @ngayKetThuc, @quocGiaSanXuat, @daoDien, @namSX, @apPhich, @dinhDangPhim)";

            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                cmd.Parameters.AddWithValue("@idPhim", idPhim);
                cmd.Parameters.AddWithValue("@tenPhim", tenPhim);
                cmd.Parameters.AddWithValue("@moTa", moTa);
                cmd.Parameters.AddWithValue("@thoiLuong", thoiLuong);
                cmd.Parameters.AddWithValue("@ngayKhoiChieu", ngayKhoiChieu);
                cmd.Parameters.AddWithValue("@ngayKetThuc", ngayKetThuc);
                cmd.Parameters.AddWithValue("@quocGiaSanXuat", quocGiaSanXuat);
                cmd.Parameters.AddWithValue("@daoDien", daoDien);
                cmd.Parameters.AddWithValue("@namSX", namSX);

                // Thêm áp phích
                MemoryStream ms = new MemoryStream();
                PbApPhich.Image.Save(ms, PbApPhich.Image.RawFormat);
                byte[] apPhichBytes = ms.ToArray();
                SqlParameter apPhichParam = new SqlParameter("@apPhich", SqlDbType.Image);
                apPhichParam.Value = apPhichBytes;
                cmd.Parameters.Add(apPhichParam);

                cmd.Parameters.AddWithValue("@dinhDangPhim", dinhDangPhim);

                connDB.conn.Open();
                cmd.ExecuteNonQuery();
                connDB.conn.Close();
            }

            // Thêm thể loại của phim vào bảng PhanLoaiPhim
            foreach (string genre in theLoai)
            {
                string genreId = GetGenreId(genre); // Hàm GetGenreId là hàm tự định nghĩa để lấy id của thể loại từ tên thể loại
                string insertGenreSql = @"INSERT INTO PhanLoaiPhim (idPhim, idTheLoai) VALUES (@idPhim, @idTheLoai)";
                using (SqlCommand cmd = new SqlCommand(insertGenreSql, connDB.conn))
                {
                    cmd.Parameters.AddWithValue("@idPhim", idPhim);
                    cmd.Parameters.AddWithValue("@idTheLoai", genreId);

                    connDB.conn.Open();
                    cmd.ExecuteNonQuery();
                    connDB.conn.Close();
                }
            }

            // Hiển thị thông báo thành công
            MessageBox.Show("Thêm phim mới thành công!");
            //load lại dsphim
            FrmAddPhim_Load(sender, e);
        }

        private bool IsProductionYearBeforeReleaseYear(string productionYear, DateTime releaseYear)
        {
            int productionYearInt;
            if (!int.TryParse(productionYear, out productionYearInt))
            {
                MessageBox.Show("Vui lòng nhập năm sản xuất hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime productionYearDate = new DateTime(productionYearInt, 1, 1);
            return productionYearDate < releaseYear;
        }
        //Hàm kiểm tra ngày khởi chiếu có sớm hơn ngày kết thúc không
        private bool IsReleaseDateBeforeEndDate(DateTime releaseDate, DateTime endDate)
        {
            return releaseDate < endDate;
        }

        private string GetGenreId(string genre)
        {
            // Hàm này để lấy id của thể loại từ tên thể loại
            // Bạn cần tự định nghĩa hàm này dựa trên cách lấy id từ cơ sở dữ liệu của bạn
            // Ví dụ:
            string sql = "SELECT idTheLoai FROM TheLoai WHERE TenTheLoai = @genre";
            using (SqlCommand cmd = new SqlCommand(sql, connDB.conn))
            {
                cmd.Parameters.AddWithValue("@genre", genre);
                connDB.conn.Open();
                string genreId = cmd.ExecuteScalar().ToString();
                connDB.conn.Close();
                return genreId;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // Lấy ID của phim cần xóa từ TextBox ID của phim
            string idPhim = TxtIDP.Text;

            //Hỏi xác nhận xóa phim
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phim này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return; // Ngăn không cho xóa phim
            }
            if (result == DialogResult.Yes)
            {
                // Xóa phim khỏi bảng LichChieu
                string deleteLichChieuSql = "DELETE FROM LichChieu WHERE idPhim = @idPhim";
                using (SqlCommand deleteLichChieuCmd = new SqlCommand(deleteLichChieuSql, connDB.conn))
                {
                    deleteLichChieuCmd.Parameters.AddWithValue("@idPhim", idPhim);
                    connDB.conn.Open();
                    deleteLichChieuCmd.ExecuteNonQuery();
                    connDB.conn.Close();
                }

                // Xóa phim khỏi bảng PhanLoaiPhim
                string deletePhanLoaiSql = "DELETE FROM PhanLoaiPhim WHERE idPhim = @idPhim";
                using (SqlCommand deletePhanLoaiCmd = new SqlCommand(deletePhanLoaiSql, connDB.conn))
                {
                    deletePhanLoaiCmd.Parameters.AddWithValue("@idPhim", idPhim);
                    connDB.conn.Open();
                    deletePhanLoaiCmd.ExecuteNonQuery();
                    connDB.conn.Close();
                }

                // Xóa phim khỏi bảng Phim
                string deletePhimSql = "DELETE FROM Phim WHERE idPhim = @idPhim";
                using (SqlCommand deletePhimCmd = new SqlCommand(deletePhimSql, connDB.conn))
                {
                    deletePhimCmd.Parameters.AddWithValue("@idPhim", idPhim);
                    connDB.conn.Open();
                    deletePhimCmd.ExecuteNonQuery();
                    connDB.conn.Close();
                }
            }

            // Hiển thị thông báo thành công
            MessageBox.Show("Đã xóa phim khỏi cơ sở dữ liệu!");
            // Load lại dsphim
            FrmAddPhim_Load(sender, e);
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string sql = @"
                SELECT 
                    Phim.idPhim, 
                    Phim.TenPhim, 
                    Phim.Mota, 
                    Phim.ThoiLuong, 
                    Phim.NgayKhoiChieu, 
                    Phim.NgayKetThuc, 
                    Phim.QuocGiaSanXuat, 
                    Phim.DaoDien, 
                    Phim.NamSX, 
                    Phim.ApPhich, 
                    Phim.DinhDangPhim,
                    STUFF((SELECT ', ' + TheLoai.TenTheLoai
                           FROM PhanLoaiPhim
                           INNER JOIN TheLoai ON PhanLoaiPhim.idTheLoai = TheLoai.idTheLoai
                           WHERE PhanLoaiPhim.idPhim = Phim.idPhim
                           FOR XML PATH('')), 1, 2, '') AS TenTheLoai
                FROM 
                    Phim
                WHERE 
                    Phim.TenPhim LIKE @tenPhim OR 
                    Phim.QuocGiaSanXuat LIKE @tenPhim OR 
                    Phim.DaoDien LIKE @tenPhim OR 
                    Phim.NamSX LIKE @tenPhim OR 
                    Phim.DinhDangPhim LIKE @tenPhim
            ";

            string tenPhim = TxtTim.Text;

            // Kiểm tra kết nối đã mở chưa, nếu chưa thì mở
            if (connDB.conn.State == ConnectionState.Closed)
            {
                connDB.conn.Open();
            }
            //truyền dữ liệu vào DsPhim
            SqlDataAdapter adp = new SqlDataAdapter(sql, connDB.conn);
            adp.SelectCommand.Parameters.AddWithValue("@tenPhim", "%" + tenPhim + "%");
            DataTable table = new DataTable();
            adp.Fill(table);
            DsPhim.DataSource = table;
            // Đóng kết nối
            connDB.conn.Close();
        }

        private void TxtTim_TextChanged(object sender, EventArgs e)
        {
            //Nếu textbox tìm kiếm rỗng thì load lại dsphim
            if (TxtTim.Text == "")
            {
                FrmAddPhim_Load(sender, e);
            }
        }
    }
}
