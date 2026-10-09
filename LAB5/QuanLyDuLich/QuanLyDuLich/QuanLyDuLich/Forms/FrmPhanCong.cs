using System;
using System.Data;
using System.Windows.Forms;
using QuanLyDuLich.Services;

namespace QuanLyDuLich.Forms
{
    /// <summary>UC07 Phân công nhân viên hướng dẫn theo đoàn hoặc theo chuyến, không chồng chéo lịch.</summary>
    public partial class FrmPhanCong : Form
    {
        private readonly PhanCongService _sv = new PhanCongService();

        public FrmPhanCong()
        {
            InitializeComponent();
        }

        private void FrmPhanCong_Load(object sender, EventArgs e)
        {
            NapDanhSach(null);
        }

        private void NapDanhSach(string chon)
        {
            try
            {
                GridHelper.HienThi(dgvCanPhanCong, _sv.LayDoanVaChuyenCanPhanCong(), "Loai", "Loại", "Ma", "Mã",
                                   "TenTour", "*Tour", "Khach", "*Khách", "NgayDi", "Ngày đi", "NgayVe", "Ngày về",
                                   "SoKhach", "Số khách", "SoHDV", "Số HDV");
                GridHelper.ChonDong(dgvCanPhanCong, "Ma", chon);
                HienThiChon();
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvCanPhanCong_SelectionChanged(object sender, EventArgs e)
        {
            HienThiChon();
        }

        private void HienThiChon()
        {
            DataRowView r = GridHelper.DongChon(dgvCanPhanCong);
            if (r == null) return;
            bool doan = Convert.ToString(r["Loai"]) == "Đoàn";
            string ma = Convert.ToString(r["Ma"]);
            int soKhach = Convert.ToInt32(r["SoKhach"]), soHDV = Convert.ToInt32(r["SoHDV"]);
            int goiY = doan ? Math.Max(1, (soKhach + PhanCongService.SoKhachMoiHDV - 1) / PhanCongService.SoKhachMoiHDV) : 1;
            lblGoiY.Text = ma + ": " + soKhach + " khách, đã có " + soHDV + " HDV, gợi ý " + goiY + " HDV" +
                           (doan ? " (1 HDV / 25 khách)" : " (chuyến khách lẻ chỉ 1 HDV)");
            try
            {
                GridHelper.HienThi(dgvNhanVien, _sv.LayNhanVienRanh(Convert.ToDateTime(r["NgayDi"]), Convert.ToDateTime(r["NgayVe"])),
                                   "MaNV", "Mã NV", "HoTen", "*Họ tên", "DienThoai", "Điện thoại", "SoTourThangNay", "Tour tháng này");
                GridHelper.HienThi(dgvDaPhanCong, _sv.LayDaPhanCong(doan ? ma : null, doan ? null : ma), "MaNV", "Mã NV",
                                   "HoTen", "*Họ tên", "NgayBatDau", "Từ ngày", "NgayKetThuc", "Đến ngày", "LuongTour", "Lương tour");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvCanPhanCong);
            DataRowView nv = GridHelper.DongChon(dgvNhanVien);
            if (r == null || nv == null)
            {
                MessageBox.Show(this, "Chọn một đoàn/chuyến và một nhân viên rảnh.", "Thông báo");
                return;
            }
            string ma = Convert.ToString(r["Ma"]);
            bool doan = Convert.ToString(r["Loai"]) == "Đoàn";
            KetQua kq = _sv.PhanCong(Convert.ToString(nv["MaNV"]), doan ? ma : null, doan ? null : ma);
            GridHelper.ThongBao(this, kq);
            NapDanhSach(ma);
        }

        private void btnHuyPhanCong_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvCanPhanCong);
            DataRowView pc = GridHelper.DongChon(dgvDaPhanCong);
            if (r == null || pc == null) return;
            if (!GridHelper.XacNhan(this, "Hủy phân công " + pc["HoTen"] + "?")) return;
            GridHelper.ThongBao(this, _sv.HuyPhanCong(Convert.ToInt32(pc["MaPhanCong"])));
            NapDanhSach(Convert.ToString(r["Ma"]));
        }
    }
}
