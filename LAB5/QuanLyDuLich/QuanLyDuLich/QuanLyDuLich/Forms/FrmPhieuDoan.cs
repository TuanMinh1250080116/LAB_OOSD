using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QuanLyDuLich.Services;

namespace QuanLyDuLich.Forms
{
    /// <summary>UC04 Lập phiếu đăng ký theo đoàn; UC08/UC11 bắt đầu, kết thúc, hủy (mất cọc), thanh toán.</summary>
    public partial class FrmPhieuDoan : Form
    {
        private readonly PhieuDoanService _sv = new PhieuDoanService();
        private readonly TourService _tour = new TourService();
        private bool _dangNap;
        private string _dsCuaPhieu;   // null: lưới người đi cùng đang dùng cho phiếu mới

        public FrmPhieuDoan()
        {
            InitializeComponent();
            Shown += (s, e) => { _dangNap = true; dgvPhieu.ClearSelection(); _dangNap = false; };
        }

        private void FrmPhieuDoan_Load(object sender, EventArgs e)
        {
            dgvNguoiDiCung.Columns.Add("HoTen", "Họ tên");
            dgvNguoiDiCung.Columns.Add("NgaySinh", "Ngày sinh (dd/MM/yyyy)");
            dgvNguoiDiCung.Columns.Add("SoGiayTo", "CMND / CCCD");
            dgvNguoiDiCung.Columns[0].FillWeight = 180;
            dgvNguoiDiCung.ColumnHeadersHeight = 30;
            dgvNguoiDiCung.RowsAdded += (s, a) => DemDong();
            dgvNguoiDiCung.RowsRemoved += (s, a) => DemDong();
            dtpNgayDi.Value = DateTime.Today.AddDays(14);
            cboKhachDoan.SelectedIndexChanged += (s, a) => { if (!chkKhachMoi.Checked) HienThiKhach(); };
            try
            {
                NapKhachDoan(null);
                GridHelper.NapCombo(cboTour, _tour.LayDanhSach(true), "HienThi", "MaTour");
                NapPhieu(null);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
            chkKhachMoi_CheckedChanged(null, null);
            chkBaoHiem_CheckedChanged(null, null);
            TinhLai(null, null);
        }

        private void NapKhachDoan(string chon)
        {
            GridHelper.NapCombo(cboKhachDoan, _sv.LayKhachDoan(), "HienThi", "MaKD");
            if (chon != null) cboKhachDoan.SelectedValue = chon;
        }

        private void NapPhieu(string chon)
        {
            _dangNap = true;
            GridHelper.HienThi(dgvPhieu, _sv.LayDanhSachPhieu(), "SoPhieu", "Số phiếu", "TenCoQuan", "*Khách đoàn",
                               "TenTour", "*Tour", "NgayDi", "Ngày đi", "NgayVe", "Ngày về", "SoNguoi", "Số người",
                               "BaoHiem", "Bảo hiểm", "SoNguoiDS", "DS đi cùng", "SoHDV", "HDV", "TongKinhPhi", "Kinh phí",
                               "TienCoc", "Đã cọc", "TrangThai", "Trạng thái");
            dgvPhieu.ClearSelection();
            _dangNap = false;
            GridHelper.ChonDong(dgvPhieu, "SoPhieu", chon);
        }

        private void DemDong()
        {
            int n = 0;
            foreach (DataGridViewRow r in dgvNguoiDiCung.Rows) if (!r.IsNewRow) n++;
            lblSoDong.Text = n + " người" + (_dsCuaPhieu == null ? " – cho phiếu mới" : " – của phiếu " + _dsCuaPhieu);
        }

        private void chkKhachMoi_CheckedChanged(object sender, EventArgs e)
        {
            bool moi = chkKhachMoi.Checked;
            cboKhachDoan.Enabled = !moi;
            foreach (TextBox t in new[] { txtTenCoQuan, txtDiaChi, txtDienThoai, txtNguoiDaiDien, txtEmail })
            {
                t.ReadOnly = !moi;
                if (moi) t.Clear();
            }
            if (!moi) HienThiKhach();
        }

        private void HienThiKhach()
        {
            DataRowView r = cboKhachDoan.SelectedItem as DataRowView;
            if (r == null) return;
            txtTenCoQuan.Text = Convert.ToString(r["TenCoQuan"]);
            txtDiaChi.Text = Convert.ToString(r["DiaChi"]);
            txtDienThoai.Text = Convert.ToString(r["DienThoai"]);
            txtNguoiDaiDien.Text = Convert.ToString(r["NguoiDaiDien"]);
            txtEmail.Text = Convert.ToString(r["Email"]);
            if (txtDiaDiemDon.Text.Length == 0) txtDiaDiemDon.Text = txtDiaChi.Text;
        }

        /// <summary>Tính lại ngày về, tổng kinh phí và tiền cọc gợi ý (30%) mỗi khi đổi tour / ngày đi / số người.</summary>
        private void TinhLai(object sender, EventArgs e)
        {
            DataRowView t = cboTour.SelectedItem as DataRowView;
            if (t == null) return;
            int soNgay = Convert.ToInt32(t["SoNgay"]);
            lblNgayVe.Text = "Ngày về: " + dtpNgayDi.Value.AddDays(soNgay - 1).ToString("dd/MM/yyyy");
            decimal tong = Convert.ToDecimal(t["DonGia"]) * numSoNguoi.Value;
            lblTongKinhPhi.Text = tong.ToString("#,##0") + " đ";
            decimal coc = Math.Ceiling(tong * PhieuDoanService.TyLeCocToiThieu / 1000000m) * 1000000m;
            numTienCoc.Value = Math.Min(numTienCoc.Maximum, Math.Min(coc, tong));
        }

        private void chkBaoHiem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBaoHiem.Checked)
            {
                _dsCuaPhieu = null;
                dgvNguoiDiCung.Rows.Clear();
            }
            DemDong();
        }

        private List<NguoiDiCungDto> DocDanhSach(out string loi)
        {
            loi = null;
            List<NguoiDiCungDto> ds = new List<NguoiDiCungDto>();
            dgvNguoiDiCung.EndEdit();
            foreach (DataGridViewRow r in dgvNguoiDiCung.Rows)
            {
                if (r.IsNewRow) continue;
                string ten = Convert.ToString(r.Cells["HoTen"].Value).Trim();
                string ns = Convert.ToString(r.Cells["NgaySinh"].Value).Trim();
                if (ten.Length == 0 && ns.Length == 0) continue;
                DateTime ngay;
                if (!DateTime.TryParseExact(ns, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay)
                    || ngay > DateTime.Today)
                {
                    loi = "Dòng " + (r.Index + 1) + ": ngày sinh không hợp lệ (dd/MM/yyyy).";
                    return ds;
                }
                ds.Add(new NguoiDiCungDto { HoTen = ten, NgaySinh = ngay, SoGiayTo = Convert.ToString(r.Cells["SoGiayTo"].Value) });
            }
            return ds;
        }

        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            if (_dsCuaPhieu != null && chkBaoHiem.Checked)
            {
                MessageBox.Show(this, "Danh sách đang hiển thị thuộc phiếu " + _dsCuaPhieu +
                                ". Bỏ chọn rồi chọn lại \"Mua bảo hiểm\" để nhập danh sách cho phiếu mới.", "Thông báo");
                return;
            }
            string loi = null;
            List<NguoiDiCungDto> ds = _dsCuaPhieu == null ? DocDanhSach(out loi) : new List<NguoiDiCungDto>();
            if (loi != null)
            {
                MessageBox.Show(this, loi, "Thông báo");
                return;
            }
            KhachDoanDto moi = !chkKhachMoi.Checked ? null : new KhachDoanDto
            {
                TenCoQuan = txtTenCoQuan.Text, DiaChi = txtDiaChi.Text, DienThoai = txtDienThoai.Text.Trim(),
                NguoiDaiDien = txtNguoiDaiDien.Text, Email = txtEmail.Text
            };
            KetQua kq = _sv.LapPhieu(new PhieuDoanDto
            {
                MaKD = chkKhachMoi.Checked ? null : GridHelper.GiaTri(cboKhachDoan), MaTour = GridHelper.GiaTri(cboTour),
                NgayDi = dtpNgayDi.Value.Date, SoNguoi = (int)numSoNguoi.Value, DiaDiemDon = txtDiaDiemDon.Text,
                CoBaoHiem = chkBaoHiem.Checked, TienCoc = numTienCoc.Value
            }, moi, ds);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            if (chkKhachMoi.Checked)
            {
                chkKhachMoi.Checked = false;
                NapKhachDoan(null);
            }
            dgvNguoiDiCung.Rows.Clear();
            NapPhieu(kq.Ma);
        }

        private string PhieuChon()
        {
            DataRowView r = GridHelper.DongChon(dgvPhieu);
            return r == null ? null : Convert.ToString(r["SoPhieu"]);
        }

        private void dgvPhieu_SelectionChanged(object sender, EventArgs e)
        {
            if (_dangNap) return;
            DataRowView r = GridHelper.DongChon(dgvPhieu);
            if (r == null) return;
            _dsCuaPhieu = Convert.ToString(r["SoPhieu"]);
            lblTrangThai.Text = _dsCuaPhieu + ": " + r["TrangThai"];
            try
            {
                dgvNguoiDiCung.Rows.Clear();
                foreach (DataRow n in _sv.LayNguoiDiCung(_dsCuaPhieu).Rows)
                    dgvNguoiDiCung.Rows.Add(n["HoTen"], Convert.ToDateTime(n["NgaySinh"]).ToString("dd/MM/yyyy"), n["SoGiayTo"]);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
            DemDong();
        }

        private void btnLuuDS_Click(object sender, EventArgs e)
        {
            if (_dsCuaPhieu == null)
            {
                MessageBox.Show(this, "Chọn một phiếu ở danh sách bên dưới trước.", "Thông báo");
                return;
            }
            string loi;
            List<NguoiDiCungDto> ds = DocDanhSach(out loi);
            if (loi != null)
            {
                MessageBox.Show(this, loi, "Thông báo");
                return;
            }
            string so = _dsCuaPhieu;
            GridHelper.ThongBao(this, _sv.LuuDanhSach(so, ds));
            NapPhieu(so);
        }

        private void DoiTrangThai(string moi, string hoi)
        {
            string so = PhieuChon();
            if (so == null) return;
            if (hoi != null && !GridHelper.XacNhan(this, hoi.Replace("{0}", so))) return;
            GridHelper.ThongBao(this, _sv.ChuyenTrangThai(so, moi));
            NapPhieu(so);
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            DoiTrangThai("Đang đi", null);
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DoiTrangThai("Chờ thanh toán", "Đoàn {0} đã về TP.HCM? Kết thúc tour và gửi phiếu khảo sát.");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DoiTrangThai("Hủy - mất cọc", "Đoàn {0} không đi: hủy phiếu, công ty giữ tiền cọc?");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvPhieu);
            if (r == null) return;
            decimal conLai = Convert.ToDecimal(r["TongKinhPhi"]) - Convert.ToDecimal(r["TienCoc"]);
            DoiTrangThai("Đã thanh toán", "Thu kinh phí còn lại " + conLai.ToString("#,##0") + " đ của đoàn {0}?");
        }
    }
}
