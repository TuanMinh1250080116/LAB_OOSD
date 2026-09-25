using System;
using System.Windows.Forms;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Màn hình chính: điều hướng tới các chức năng của hệ thống.</summary>
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // Thử kết nối ngay khi mở để người dùng biết sớm nếu SQL Server chưa chạy.
            try
            {
                object ten = Db.Scalar("SELECT TOP 1 HoTen FROM NhanVien");
                lblTrangThai.Text = "Đã kết nối SQL Server (QuanLyKhachSan) – nhân viên mẫu: " + Convert.ToString(ten);
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Chưa kết nối được cơ sở dữ liệu.";
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void Mo(Form f)
        {
            using (f) f.ShowDialog(this);
        }

        private void btnDanhMuc_Click(object sender, EventArgs e) { Mo(new FrmDanhMuc()); }
        private void btnPhong_Click(object sender, EventArgs e) { Mo(new FrmPhongTienNghi()); }
        private void btnDatPhong_Click(object sender, EventArgs e) { Mo(new FrmDatPhong()); }
        private void btnDichVu_Click(object sender, EventArgs e) { Mo(new FrmDichVu()); }
        private void btnTraPhong_Click(object sender, EventArgs e) { Mo(new FrmTraPhong()); }
        private void btnThongKe_Click(object sender, EventArgs e) { Mo(new FrmThongKe()); }
        private void btnThoat_Click(object sender, EventArgs e) { Close(); }
    }
}
