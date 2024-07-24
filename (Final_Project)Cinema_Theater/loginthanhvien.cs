using _Final_Project_Cinema_Theater;
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

namespace datve11
{
    public partial class loginthanhvien : Form
    {
        public loginthanhvien()
        {
            InitializeComponent();
        }
        SQLCONNECTION connDB = new SQLCONNECTION();

        private void btndki_Click(object sender, EventArgs e)
        {
            FrmInfoKhachHang f = new FrmInfoKhachHang();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        public int DiemTichLuy { get; set; }

        // Sự kiện Click của button Xác nhận
        private void btnxacnhan_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem HoTen và SDT có tồn tại trong database hay không
            string sql = "SELECT * FROM KhachHang WHERE HoTen = @HoTen AND SDT = @SDT";

            using (SqlConnection connection = new SqlConnection(connDB.conn.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@HoTen", txthoten.Text);
                command.Parameters.AddWithValue("@SDT", txtsdt.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string hoTen = reader["HoTen"].ToString();
                    int diemTichLuy = Convert.ToInt32(reader["DiemTichLuy"]);

                    // Nếu tồn tại, chuyển dữ liệu sang form FrmBanVe
                    FrmBanVe f = FrmBanVe.Instance; // Lấy instance hiện có của FrmBanVe
                    f.HotenLabel = hoTen; // Gán giá trị hoTen cho thuộc tính HotenLabel của FrmBanVe
                    f.DiemTichLuy = diemTichLuy; // Gán giá trị diemTichLuy cho thuộc tính DiemTichLuy của FrmBanVe
                    f.Show(); // Hiển thị form FrmBanVe
                    this.Hide(); // Ẩn form hiện tại
                }
                else
                {
                    MessageBox.Show("Tên hoặc số điện thoại không tồn tại");
                }
            }
        }
    }
}
