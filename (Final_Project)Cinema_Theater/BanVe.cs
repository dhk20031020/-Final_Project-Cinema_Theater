using datve11;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Final_Project_Cinema_Theater
{
    public partial class BanVe : Form
    {
        //Dùng class SQLCONNECTION để kết nối database
        SQLCONNECTION connDB = new SQLCONNECTION();
        SQLCONNECTION cmd = new SQLCONNECTION();
        SQLCONNECTION dta = new SQLCONNECTION();
        SQLCONNECTION dt = new SQLCONNECTION();
        public BanVe()
        {
            InitializeComponent();
        }

        //Thêm một property để lưu idLichChieu
        private string selectedLichChieuID;
        // Biến để lưu trữ ngày chiếu
        private string selectedNgayChieu;

        public string SelectedLichChieuID
        {
            get { return selectedLichChieuID; }
            set { selectedLichChieuID = value; }
        }

        //Hàm đọc ApPhich từ database trùng với tên phim
        private void LoadApPhich(string tenPhim)
        {
            connDB.conn.Open();
            string sql = "SELECT * FROM Phim WHERE TenPhim = N'" + tenPhim + "'";
            cmd.cmd = new SqlCommand(sql, connDB.conn);
            SqlDataReader dta = cmd.cmd.ExecuteReader();
            while (dta.Read())
            {
                //Hiển thị ảnh phim lên PictureBox
                object apPhichObj = dta["ApPhich"];
                if (apPhichObj != DBNull.Value)
                {
                    byte[] img = (byte[])apPhichObj;
                    using (MemoryStream ms = new MemoryStream(img))
                    {
                        PicPoster.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    PicPoster.Image = null;
                }
            }
            connDB.conn.Close();
        }

        private void LoadMota()
        {
            //Truyền MoTa phim theo tên phim được chọn
            connDB.conn.Open();
            string sql = "SELECT * FROM Phim WHERE TenPhim = N'" + CboDsPhim.SelectedItem.ToString() + "'";
            cmd.cmd = new SqlCommand(sql, connDB.conn);
            SqlDataReader dta = cmd.cmd.ExecuteReader();
            while (dta.Read())
            {
                TxtMota.Text = dta["MoTa"].ToString();
            }
            connDB.conn.Close();
        }


        private void BanVe_Load(object sender, EventArgs e)
        {
            //Load Phim từ bảng Phim vào combobox
            connDB.conn.Open();
            string sql = "SELECT * FROM Phim";
            cmd.cmd = new SqlCommand(sql, connDB.conn);
            SqlDataReader dta = cmd.cmd.ExecuteReader();
            while (dta.Read())
            {
                CboDsPhim.Items.Add(dta["TenPhim"].ToString());
            }
            connDB.conn.Close();
        }

        private void CboDsPhim_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load ảnh phim từ database lên PictureBox
            LoadApPhich(CboDsPhim.SelectedItem.ToString());
            //Load Mô tả phim từ database lên TextBox
            LoadMota();
            PanelGoiY.Visible = false;
            // Xóa các button cũ trong PanelLichChieu
            PanelNgay.Controls.Clear();
            PanelLichChieu.Controls.Clear();

            //Load GioChieu từ bảng LichChieu vào panel theo Phim được chọn và theo dạng là các button có text là Ngày chiếu của cái phim đó
            connDB.conn.Open();
            string sql = "SELECT * FROM LichChieu WHERE idPhim = (SELECT idPhim FROM Phim WHERE TenPhim = N'" + CboDsPhim.SelectedItem.ToString() + "')";
            cmd.cmd = new SqlCommand(sql, connDB.conn);
            SqlDataReader dta = cmd.cmd.ExecuteReader();

            //Chỉ lấy ngày chiếu không lấy giờ chiếu
            List<Button> buttons = new List<Button>(); // Danh sách các button

            while (dta.Read())
            {
                Button btn = new Button();
                btn.Text = ((DateTime)dta["GioChieu"]).ToString("dd-MM-yyyy");
                btn.Width = 100;
                btn.Height = 50;
                btn.Click += Btn_Click;
                btn.BackColor = Color.LawnGreen;
                //Nếu ngày chiếu đã tồn tại trong danh sách thì không thêm vào danh sách
                if (!buttons.Exists(x => x.Text == btn.Text))
                {
                    buttons.Add(btn);
                }
            }

            // Thêm tất cả các button vào PanelNgay
            foreach (Button btn in buttons)
            {
                PanelNgay.Controls.Add(btn);
            }
            connDB.conn.Close();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Panelshow.Visible = true;
            // Xóa tất cả các control hiện có trong PanelLichChieu
            PanelLichChieu.Controls.Clear();

            // Lấy thông tin từ button được click
            Button clickedButton = (Button)sender;
            string ngayChieu = clickedButton.Text;
            // Lưu trữ ngày chiếu được chọn
            selectedNgayChieu = ngayChieu;
            // Thực hiện các thao tác cần thiết khi button được click
            MessageBox.Show("Đã chọn ngày chiếu: " + ngayChieu);

            // Chọn hiển thị nút của các lịch chiếu của ngày đó theo phim được chọn lên PanelLichChieu
            connDB.conn.Open();
            DateTime gioChieuDate = DateTime.ParseExact(ngayChieu, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            string sql = $"SELECT * FROM LichChieu WHERE idPhim = (SELECT idPhim FROM Phim WHERE TenPhim = N'{CboDsPhim.SelectedItem.ToString()}') AND GioChieu >= '{gioChieuDate.ToString("yyyy-MM-dd 00:00:00")}' AND GioChieu < '{gioChieuDate.AddDays(1).ToString("yyyy-MM-dd 00:00:00")}'";

            cmd.cmd = new SqlCommand(sql, connDB.conn);
            SqlDataReader dta = cmd.cmd.ExecuteReader();
            List<Button> buttons = new List<Button>(); // Danh sách các button
            while (dta.Read())
            {
                Button btn = new Button();
                btn.Text = ((DateTime)dta["GioChieu"]).ToString("HH:mm");
                btn.Width = 100;
                btn.Height = 50;
                btn.Click += Btn_Click1;
                buttons.Add(btn);
            }
            // Thêm tất cả các button vào PanelLichChieu
            foreach (Button btn in buttons)
            {
                PanelLichChieu.Controls.Add(btn);
            }
            connDB.conn.Close();
        }

        private void Btn_Click1(object sender, EventArgs e)
        {
            // Lấy thông tin từ button được click
            Button clickedButton = (Button)sender;
            string gioChieu = clickedButton.Text;

            // Ghép ngày chiếu và giờ chiếu thành một chuỗi có định dạng "dd-MM-yyyy HH:mm"
            string gioChieuFormatted = $"{selectedNgayChieu} {gioChieu}";

            // Hiển thị thông báo khi chọn giờ chiếu và ngày chiếu của phim gì
            MessageBox.Show("Đã chọn giờ chiếu: " + gioChieuFormatted + " của phim " + CboDsPhim.SelectedItem.ToString());

            // Lấy idLichChieu tương ứng với giờ chiếu được chọn
            string idLichChieu = GetIdLichChieu(CboDsPhim.SelectedItem.ToString(), gioChieuFormatted);

            // Tạo một thể hiện mới của FrmBanVe
            FrmBanVe frmBanVe = new FrmBanVe(idLichChieu);

            // Truyền tên phim và idLichChieu vào FrmBanVe
            frmBanVe.SetMovieTitle(CboDsPhim.SelectedItem.ToString(),gioChieuFormatted);

            // Hiển thị FrmBanVe và ẩn form hiện tại
            frmBanVe.Show();
            frmBanVe.MdiParent = this.MdiParent;
            this.Hide();
        }

        private string GetIdLichChieu(string tenPhim, string gioChieu)
        {
            string idLichChieu = ""; // Khởi tạo idLichChieu ban đầu
            connDB.conn.Open();

            // Chuyển đổi ngày và giờ từ chuỗi thành đối tượng DateTime
            DateTime gioChieuDate = DateTime.ParseExact(gioChieu, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);

            // Thực hiện truy vấn với chuỗi ngày và giờ đã được chuyển đổi thành định dạng phù hợp
            string sql = $"SELECT idLichChieu FROM LichChieu WHERE idPhim = (SELECT idPhim FROM Phim WHERE TenPhim = N'{tenPhim}') AND GioChieu = @GioChieu";
            cmd.cmd = new SqlCommand(sql, connDB.conn);
            cmd.cmd.Parameters.AddWithValue("@GioChieu", gioChieuDate.ToString("yyyy-MM-dd HH:mm:ss"));
            SqlDataReader dta = cmd.cmd.ExecuteReader();
            if (dta.Read())
            {
                idLichChieu = dta["idLichChieu"].ToString(); // Lấy idLichChieu từ kết quả truy vấn
            }
            return idLichChieu;
        }
    }
}
