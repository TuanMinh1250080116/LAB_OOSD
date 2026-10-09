using System;
using System.Data;
using System.Windows.Forms;
using QuanLyDuLich.Services;

namespace QuanLyDuLich.Forms
{
    /// <summary>UC03 Lập lịch chuyến, UC05 Bán vé chuyến cho khách lẻ, UC08 cập nhật tình trạng chuyến.</summary>
    public partial class FrmBanVe : Form
    {
        private readonly ChuyenVeService _sv = new ChuyenVeService();
        private string _maKL;   // khách lẻ đã có trong hệ thống (null = khách mới)

        public FrmBanVe()
        {
            InitializeComponent();
        }

        private void FrmBanVe_Load(object sender, EventArgs e)
        {
            dtpNgayDiLich.Value = DateTime.Today.AddDays(30);
            try
            {
                GridHelper.NapCombo(cboTourLich, new TourService().LayDanhSach(true), "HienThi", "MaTour");
                GridHelper.NapCombo(cboDiemBan, _sv.LayDiemBan(), "HienThi", "MaDiemBan");
                GridHelper.NapCombo(cboDiemDon, _sv.LayDiemDon(), "HienThi", "MaDiemDon");
                NapChuyen(null);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapChuyen(string chon)
        {
            GridHelper.HienThi(dgvChuyen, _sv.LayChuyen(), "MaChuyen", "Mã chuyến", "TenTour", "*Tour", "NgayDi", "Ngày đi",
                               "NgayVe", "Ngày về", "SoChoToiDa", "Chỗ", "DaBan", "Bán", "ConLai", "Còn",
                               "DonGia", "Giá vé", "TrangThai", "Trạng thái", "HuongDanVien", "Hướng dẫn viên");
            GridHelper.ChonDong(dgvChuyen, "MaChuyen", chon);
            HienThiChuyen();
        }

        private DataRowView ChuyenChon()
        {
            return GridHelper.DongChon(dgvChuyen);
        }

        private void dgvChuyen_SelectionChanged(object sender, EventArgs e)
        {
            HienThiChuyen();
        }

        private void HienThiChuyen()
        {
            DataRowView r = ChuyenChon();
            if (r == null) return;
            string ma = Convert.ToString(r["MaChuyen"]);
            string tt = Convert.ToString(r["TrangThai"]);
            lblChuyenChon.Text = ma + " – " + tt + " – còn " + r["ConLai"] + " chỗ";
            btnBanVe.Enabled = tt == "Mở bán";
            btnBatDau.Enabled = tt == "Mở bán";
            btnHuyChuyen.Enabled = tt == "Mở bán";
            btnKetThuc.Enabled = tt == "Đang đi";
            numSoNguoi_ValueChanged(null, null);
            try
            {
                GridHelper.HienThi(dgvVe, _sv.LayVe(ma), "SoVe", "Số vé", "HoTen", "*Khách", "SoNguoi", "Số người",
                                   "ThanhTien", "Thành tiền", "TenDiemDon", "Điểm đón", "TrangThai", "Trạng thái");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void numSoNguoi_ValueChanged(object sender, EventArgs e)
        {
            DataRowView r = ChuyenChon();
            decimal gia = r == null ? 0 : Convert.ToDecimal(r["DonGia"]);
            lblThanhTien.Text = "Thành tiền: " + (gia * numSoNguoi.Value).ToString("#,##0") + " đ";
        }

        private void btnTimKhach_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow k = _sv.TimKhachLe(txtSoGiayTo.Text);
                _maKL = k == null ? null : Convert.ToString(k["MaKL"]);
                lblKhachCu.Text = k == null ? "Khách mới" : "Khách " + _maKL;
                txtHoTen.Text = k == null ? "" : Convert.ToString(k["HoTen"]);
                txtDienThoai.Text = k == null ? "" : Convert.ToString(k["DienThoai"]);
                txtDiaChi.Text = k == null ? "" : Convert.ToString(k["DiaChi"]);
                foreach (TextBox t in new[] { txtHoTen, txtDienThoai, txtDiaChi }) t.ReadOnly = k != null;
                (k == null ? txtHoTen : (Control)btnBanVe).Focus();
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            DataRowView r = ChuyenChon();
            if (r == null) return;
            if (_maKL == null && lblKhachCu.Text.Length == 0)
            {
                MessageBox.Show(this, "Nhập CMND/CCCD rồi bấm \"Tìm khách\" trước khi bán vé.", "Thông báo");
                return;
            }
            KhachLeDto moi = _maKL != null ? null : new KhachLeDto
            {
                SoGiayTo = txtSoGiayTo.Text, HoTen = txtHoTen.Text, DienThoai = txtDienThoai.Text.Trim(), DiaChi = txtDiaChi.Text
            };
            string ma = Convert.ToString(r["MaChuyen"]);
            KetQua kq = _sv.BanVe(new VeDto
            {
                MaChuyen = ma, MaKL = _maKL, MaDiemBan = GridHelper.GiaTri(cboDiemBan),
                MaDiemDon = GridHelper.GiaTri(cboDiemDon), SoNguoi = (int)numSoNguoi.Value
            }, moi);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            _maKL = null;
            lblKhachCu.Text = "";
            foreach (TextBox t in new[] { txtSoGiayTo, txtHoTen, txtDienThoai, txtDiaChi })
            {
                t.Clear();
                t.ReadOnly = false;
            }
            numSoNguoi.Value = 1;
            NapChuyen(ma);
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            DataRowView v = GridHelper.DongChon(dgvVe);
            DataRowView c = ChuyenChon();
            if (v == null || c == null) return;
            string so = Convert.ToString(v["SoVe"]);
            if (!GridHelper.XacNhan(this, "Hủy vé " + so + "?")) return;
            GridHelper.ThongBao(this, _sv.HuyVe(so));
            NapChuyen(Convert.ToString(c["MaChuyen"]));
        }

        private void btnThemChuyen_Click(object sender, EventArgs e)
        {
            KetQua kq = _sv.ThemChuyen(GridHelper.GiaTri(cboTourLich), dtpNgayDiLich.Value, (int)numSoCho.Value);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) NapChuyen(kq.Ma);
        }

        private void DoiTrangThai(string moi)
        {
            DataRowView r = ChuyenChon();
            if (r == null) return;
            string ma = Convert.ToString(r["MaChuyen"]);
            GridHelper.ThongBao(this, _sv.ChuyenTrangThai(ma, moi));
            NapChuyen(ma);
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            DoiTrangThai("Đang đi");
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DoiTrangThai("Kết thúc");
        }

        private void btnHuyChuyen_Click(object sender, EventArgs e)
        {
            if (GridHelper.XacNhan(this, "Hủy chuyến đang chọn?")) DoiTrangThai("Hủy");
        }
    }
}
