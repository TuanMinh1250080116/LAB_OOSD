using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Phòng, tiện nghi và phiếu lắp đặt / luân chuyển thiết bị.</summary>
    public partial class FrmPhongTienNghi : Form
    {
        private readonly PhongTienNghiService _svc = new PhongTienNghiService();
        private readonly DanhMucService _dm = new DanhMucService();

        public FrmPhongTienNghi()
        {
            InitializeComponent();
        }

        private void FrmPhongTienNghi_Load(object sender, EventArgs e)
        {
            try
            {
                GridHelper.NapCombo(cboKhu, _dm.LayKhuVuc(), "TenKhuVuc", "MaKhuVuc");
                GridHelper.NapCombo(cboLoai, _dm.LayLoaiTienNghi(), "TenLoaiTN", "MaLoaiTN");
                GridHelper.NapCombo(cboNV, _dm.LayNhanVien(), "HoTen", "MaNV");
                dtNgay.Value = DateTime.Today;
                NapTatCa();
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapTatCa()
        {
            DataTable phong = _svc.LayPhong();
            GridHelper.HienThi(dgvPhong, phong, "SoPhong", "Số phòng", "TenKhuVuc", "*Khu vực",
                               "SoNguoiToiDa", "Số người tối đa", "DonGiaNgay", "Đơn giá/ngày", "TrangThai", "Trạng thái");
            DataTable tienNghi = _svc.LayTienNghi();
            GridHelper.HienThi(dgvTN, tienNghi, "MaTienNghi", "Mã tiện nghi", "TenLoaiTN", "*Loại tiện nghi",
                               "SoThuTu", "Số thứ tự", "TinhTrangHienTai", "*Tình trạng hiện tại");
            GridHelper.HienThi(dgvLD, _svc.LayPhieuLapDat(), "SoPhieuLapDat", "Số phiếu", "MaTienNghi", "Tiện nghi",
                               "TenLoaiTN", "*Loại", "SoPhong", "Phòng", "NgayLap", "Ngày lắp",
                               "TinhTrang", "*Tình trạng", "HoTen", "*Nhân viên", "GhiChu", "*Ghi chú");

            // Combo chọn phòng / tiện nghi cho phiếu lắp đặt dùng lại đúng dữ liệu vừa đọc.
            GridHelper.NapCombo(cboPhongLD, phong.Copy(), "SoPhong", "SoPhong");
            GridHelper.NapCombo(cboTN, tienNghi.Copy(), "MaTienNghi", "MaTienNghi");
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvPhong);
            if (r == null) return;
            txtPhong.Text = Convert.ToString(r["SoPhong"]);
            numMax.Value = Convert.ToInt32(r["SoNguoiToiDa"]);
            numGia.Value = Convert.ToDecimal(r["DonGiaNgay"]);
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _svc.ThemPhong(txtPhong.Text, GridHelper.GiaTri(cboKhu), (int)numMax.Value, numGia.Value);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) { txtPhong.Clear(); NapTatCa(); }
        }

        private void btnCapNhatGia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhong.Text))
            {
                MessageBox.Show(this, "Chọn một phòng trong danh sách trước khi đổi đơn giá.", "Thông báo");
                return;
            }
            KetQuaXuLy kq = _svc.CapNhatDonGia(txtPhong.Text.Trim(), numGia.Value);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) NapTatCa();
        }

        private void btnThemTN_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _svc.ThemTienNghi(txtMaTN.Text, GridHelper.GiaTri(cboLoai), (int)numSTT.Value, txtTinhTrang.Text);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) { txtMaTN.Clear(); txtTinhTrang.Clear(); NapTatCa(); }
        }

        private void btnLapDat_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _svc.LapPhieuLapDat(GridHelper.GiaTri(cboTN), GridHelper.GiaTri(cboPhongLD),
                                                dtNgay.Value, txtTTLD.Text, GridHelper.GiaTri(cboNV), txtGhiChu.Text);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) { txtGhiChu.Clear(); NapTatCa(); }
        }
    }
}
