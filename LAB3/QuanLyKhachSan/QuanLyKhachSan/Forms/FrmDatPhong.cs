using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Khách hàng, lập phiếu đặt phòng, nhận phòng và ghi người lưu trú.</summary>
    public partial class FrmDatPhong : Form
    {
        private readonly DatPhongService _svc = new DatPhongService();
        private readonly DanhMucService _dm = new DanhMucService();
        private readonly DataTable _chon = new DataTable();
        private string _phieuChon = "";

        public FrmDatPhong()
        {
            InitializeComponent();
            _chon.Columns.Add("SoPhong", typeof(string));
            _chon.Columns.Add("SoNguoi", typeof(int));
            _chon.Columns.Add("DonGiaNgay", typeof(decimal));
        }

        private void FrmDatPhong_Load(object sender, EventArgs e)
        {
            try
            {
                cboKenh.Items.AddRange(new object[] { "Trực tiếp", "Điện thoại", "Website" });
                cboKenh.SelectedIndex = 0;
                GridHelper.NapCombo(cboNV, _dm.LayNhanVien(), "HoTen", "MaNV");
                dtNhan.Value = DateTime.Today;
                dtTra.Value = DateTime.Today.AddDays(1);
                NapKhach();
                NapPhongTrong();
                NapPhieu();
                GridHelper.HienThi(dgvChon, _chon, "SoPhong", "Số phòng", "SoNguoi", "Số người", "DonGiaNgay", "Đơn giá/ngày");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapKhach()
        {
            DataTable kh = _svc.LayKhachHang();
            GridHelper.HienThi(dgvKhach, kh, "MaKhach", "Mã khách", "HoTen", "*Họ tên", "SoCMND", "CCCD",
                               "QuocTich", "Quốc tịch", "SoDienThoai", "Điện thoại");
            DataTable cbo = kh.Copy();
            foreach (DataRow r in cbo.Rows) r["HoTen"] = r["MaKhach"] + " - " + r["HoTen"];
            GridHelper.NapCombo(cboKhach, cbo, "HoTen", "MaKhach");
        }

        private void NapPhongTrong()
        {
            GridHelper.HienThi(dgvPhong, _svc.LayPhongTrong(dtNhan.Value, dtTra.Value),
                               "SoPhong", "Số phòng", "TenKhuVuc", "*Khu vực", "SoNguoiToiDa", "Tối đa",
                               "DonGiaNgay", "Đơn giá/ngày");
        }

        private void NapPhieu()
        {
            DataTable p = _svc.LayPhieuDat();
            GridHelper.HienThi(dgvPhieu, p, "SoPhieuDat", "Số phiếu", "HoTen", "*Khách hàng", "NgayNhan", "Ngày nhận",
                               "NgayTraDuKien", "Ngày trả dự kiến", "TienCoc", "Tiền cọc", "KenhDat", "Kênh đặt",
                               "TrangThai", "Trạng thái");
            GridHelper.HienThi(dgvPhieuNhan, p.Copy(), "SoPhieuDat", "Số phiếu", "HoTen", "*Khách hàng",
                               "NgayNhan", "Ngày nhận", "NgayTraDuKien", "Ngày trả dự kiến", "TrangThai", "Trạng thái");
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabs.SelectedTab == tabNhan) NapPhieu();
        }

        private void dtNgay_ValueChanged(object sender, EventArgs e)
        {
            if (!IsHandleCreated) return;
            try { NapPhongTrong(); }
            catch (Exception ex) { GridHelper.LoiHeThong(this, ex); }
        }

        // ------------------------------------------------------------ Khách hàng
        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _svc.ThemKhachHang(txtTenKH.Text, txtCMND.Text, txtQT.Text, txtSDT.Text);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            txtTenKH.Clear(); txtCMND.Clear(); txtQT.Clear(); txtSDT.Clear();
            NapKhach();
        }

        // ------------------------------------------------------------ Đặt phòng
        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvPhong);
            if (r == null)
            {
                MessageBox.Show(this, "Chọn một phòng trong danh sách phòng còn trống.", "Thông báo");
                return;
            }
            string soPhong = Convert.ToString(r["SoPhong"]);
            foreach (DataRow d in _chon.Rows)
                if (Convert.ToString(d["SoPhong"]) == soPhong)
                {
                    MessageBox.Show(this, "Phòng " + soPhong + " đã có trong phiếu.", "Thông báo");
                    return;
                }
            int toiDa = Convert.ToInt32(r["SoNguoiToiDa"]);
            if (numSoNguoi.Value > toiDa)
            {
                MessageBox.Show(this, "Phòng " + soPhong + " chỉ chứa tối đa " + toiDa + " người.", "Thông báo");
                return;
            }
            _chon.Rows.Add(soPhong, (int)numSoNguoi.Value, Convert.ToDecimal(r["DonGiaNgay"]));
        }

        private void btnBoPhong_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvChon);
            if (r != null) r.Delete();
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            List<PhongDatItem> ds = new List<PhongDatItem>();
            foreach (DataRow d in _chon.Rows)
                ds.Add(new PhongDatItem
                {
                    SoPhong = Convert.ToString(d["SoPhong"]),
                    SoNguoi = Convert.ToInt32(d["SoNguoi"]),
                    DonGiaNgay = Convert.ToDecimal(d["DonGiaNgay"])
                });

            KetQuaXuLy kq = _svc.TaoDatPhong(GridHelper.GiaTri(cboKhach), GridHelper.GiaTri(cboNV), DateTime.Now,
                                             dtNhan.Value, dtTra.Value, numCoc.Value, cboKenh.Text, ds);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            _chon.Rows.Clear();
            numCoc.Value = 0;
            NapPhongTrong();
            NapPhieu();
        }

        private void dgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvPhieu);
            if (r != null) _phieuChon = Convert.ToString(r["SoPhieuDat"]);
        }

        // ------------------------------------------------------------ Nhận phòng
        private void dgvPhieuNhan_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvPhieuNhan);
            if (r == null) return;
            _phieuChon = Convert.ToString(r["SoPhieuDat"]);
            txtPhieuChon.Text = _phieuChon;
            lblNPTrangThai.Text = "Trạng thái: " + Convert.ToString(r["TrangThai"]);
            NapChiTiet();
        }

        private void NapChiTiet()
        {
            try
            {
                GridHelper.HienThi(dgvCT, _svc.LayChiTiet(_phieuChon), "SoPhong", "Số phòng", "SoNguoi", "Số người",
                                   "SoNguoiToiDa", "Tối đa", "DonGiaApDung", "Đơn giá áp dụng");
                GridHelper.HienThi(dgvNguoi, _svc.LayNguoiLuuTru(_phieuChon), "SoPhong", "Phòng", "HoTen", "*Họ tên",
                                   "SoCMND", "CCCD", "QuocTich", "Quốc tịch");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void dgvCT_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvCT);
            if (r != null) txtNguoiPhong.Text = Convert.ToString(r["SoPhong"]);
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _svc.NhanPhong(_phieuChon, DateTime.Now);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) { NapPhieu(); NapChiTiet(); }
        }

        private void btnNoShow_Click(object sender, EventArgs e)
        {
            if (!GridHelper.XacNhan(this, "Đánh dấu khách không đến nhận phòng và giải phóng phòng?")) return;
            KetQuaXuLy kq = _svc.DanhDauNoShow(_phieuChon);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) NapPhieu();
        }

        private void btnThemNguoi_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _svc.ThemNguoiLuuTru(_phieuChon, txtNguoiPhong.Text, txtNguoiTen.Text,
                                                 txtNguoiCMND.Text, txtNguoiQT.Text);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            txtNguoiTen.Clear(); txtNguoiCMND.Clear(); txtNguoiQT.Clear();
            NapChiTiet();
        }
    }
}
