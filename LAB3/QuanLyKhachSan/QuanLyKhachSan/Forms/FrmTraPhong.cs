using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Kiểm tra tiện nghi, lập phiếu đền bù, lập hóa đơn, thanh toán và trả phòng.</summary>
    public partial class FrmTraPhong : Form
    {
        private readonly TraPhongService _svc = new TraPhongService();
        private readonly DanhMucService _dm = new DanhMucService();
        private readonly DataTable _denBu = new DataTable();

        public FrmTraPhong()
        {
            InitializeComponent();
            _denBu.Columns.Add("MaTienNghi", typeof(string));
            _denBu.Columns.Add("TenLoaiTN", typeof(string));
            _denBu.Columns.Add("MucDoThietHai", typeof(string));
            _denBu.Columns.Add("SoTien", typeof(decimal));
        }

        private void FrmTraPhong_Load(object sender, EventArgs e)
        {
            try
            {
                cboHT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" });
                cboHT.SelectedIndex = 0;
                DataTable nv = _dm.LayNhanVien();
                GridHelper.NapCombo(cboNV, nv, "HoTen", "MaNV");
                GridHelper.NapCombo(cboNV2, nv.Copy(), "HoTen", "MaNV");

                DataTable qd = _dm.LayQuyDinhDenBu();
                List<string> mucDo = new List<string>();
                foreach (DataRow r in qd.Rows)
                {
                    string m = Convert.ToString(r["MucDoThietHai"]);
                    if (!mucDo.Contains(m)) mucDo.Add(m);
                }
                cboMucDo.Items.AddRange(mucDo.ToArray());

                GridHelper.HienThi(dgvDBChon, _denBu, "MaTienNghi", "Tiện nghi", "TenLoaiTN", "*Loại",
                                   "MucDoThietHai", "*Mức độ", "SoTien", "Số tiền");
                NapPhieuDangO();
                NapHoaDon();
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapPhieuDangO()
        {
            DataTable t = _svc.LayPhieuDangO();
            foreach (DataRow r in t.Rows) r["HoTen"] = r["SoPhieuDat"] + " - " + r["HoTen"];
            GridHelper.NapCombo(cboDat, t, "HoTen", "SoPhieuDat");
            if (t.Rows.Count == 0)
            {
                lblTienTam.Text = "Hiện không có lượt lưu trú nào đang ở.";
                btnTraPhong.Enabled = false;
            }
            cboDat_SelectedIndexChanged(null, EventArgs.Empty);
        }

        private void NapHoaDon()
        {
            GridHelper.HienThi(dgvHD, _svc.LayHoaDon(), "SoHoaDon", "Số hóa đơn", "SoPhieuDat", "Phiếu đặt",
                               "NgayLap", "Ngày lập", "SoNgayTinhTien", "Số ngày", "TienPhong", "Tiền phòng",
                               "TienDichVu", "Tiền dịch vụ", "TongTien", "Tổng tiền",
                               "TongDaThanhToan", "Đã thanh toán", "TrangThai", "*Trạng thái");
        }

        private string PhieuChon()
        {
            return GridHelper.GiaTri(cboDat);
        }

        private void cboDat_SelectedIndexChanged(object sender, EventArgs e)
        {
            string phieu = PhieuChon();
            if (string.IsNullOrEmpty(phieu)) return;
            try
            {
                GridHelper.HienThi(dgvPhong, _svc.LayPhongTheoPhieu(phieu), "SoPhong", "Phòng",
                                   "SoNguoi", "Số người", "DonGiaApDung", "Đơn giá");
                _denBu.Rows.Clear();
                TinhTamTinh();
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void TinhTamTinh()
        {
            decimal tienPhongNgay = 0;
            DataTable p = dgvPhong.DataSource as DataTable;
            if (p != null) foreach (DataRow r in p.Rows) tienPhongNgay += Convert.ToDecimal(r["DonGiaApDung"]);
            lblTienTam.Text = string.Format("Đơn giá phòng đã chốt: {0:#,##0} đ/ngày." + Environment.NewLine
                                            + "Tiền phòng tạm tính {1} ngày: {2:#,##0} đ." + Environment.NewLine
                                            + "Tiền dịch vụ sẽ được cộng khi lập hóa đơn.",
                                            tienPhongNgay, (int)numSoNgay.Value, tienPhongNgay * numSoNgay.Value);
        }

        private void dgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvPhong);
            if (r == null) return;
            txtPhong.Text = Convert.ToString(r["SoPhong"]);
            try
            {
                GridHelper.HienThi(dgvTN, _svc.LayTienNghiPhong(txtPhong.Text), "MaTienNghi", "Mã tiện nghi",
                                   "TenLoaiTN", "*Loại", "TinhTrangHienTai", "*Tình trạng");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void cboMucDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvTN);
            if (r == null || cboMucDo.Text.Length == 0) return;
            try
            {
                decimal? muc = _dm.LayMucDenBu(Convert.ToString(r["MaTienNghi"]), cboMucDo.Text);
                if (muc.HasValue) numDenBu.Value = muc.Value;
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void btnThemDB_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvTN);
            if (r == null)
            {
                MessageBox.Show(this, "Chọn tiện nghi bị hư hỏng/mất trong danh sách bên trái.", "Thông báo");
                return;
            }
            string ma = Convert.ToString(r["MaTienNghi"]);
            foreach (DataRow d in _denBu.Rows)
                if (Convert.ToString(d["MaTienNghi"]) == ma)
                {
                    MessageBox.Show(this, "Tiện nghi " + ma + " đã có trong danh sách đền bù.", "Thông báo");
                    return;
                }
            if (cboMucDo.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Nhập hoặc chọn mức độ thiệt hại.", "Thông báo");
                return;
            }
            _denBu.Rows.Add(ma, Convert.ToString(r["TenLoaiTN"]), cboMucDo.Text.Trim(), numDenBu.Value);
        }

        private void btnBoDB_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvDBChon);
            if (r != null) r.Delete();
        }

        private void btnLapDB_Click(object sender, EventArgs e)
        {
            List<DenBuItem> ds = new List<DenBuItem>();
            foreach (DataRow d in _denBu.Rows)
                ds.Add(new DenBuItem
                {
                    MaTienNghi = Convert.ToString(d["MaTienNghi"]),
                    TenLoaiTN = Convert.ToString(d["TenLoaiTN"]),
                    MucDoThietHai = Convert.ToString(d["MucDoThietHai"]),
                    SoTien = Convert.ToDecimal(d["SoTien"])
                });
            KetQuaXuLy kq = _svc.LapPhieuDenBu(PhieuChon(), txtPhong.Text, DateTime.Now, GridHelper.GiaTri(cboNV), ds);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            _denBu.Rows.Clear();
            dgvPhong_SelectionChanged(null, EventArgs.Empty);
        }

        private void btnLapHD_Click(object sender, EventArgs e)
        {
            KetQuaXuLy kq = _svc.LapHoaDon(PhieuChon(), DateTime.Now, GridHelper.GiaTri(cboNV2), (int)numSoNgay.Value);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) NapHoaDon();
        }

        private void dgvHD_SelectionChanged(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvHD);
            if (r == null) return;
            txtHDChon.Text = Convert.ToString(r["SoHoaDon"]);
            decimal conLai = Convert.ToDecimal(r["TongTien"]) - Convert.ToDecimal(r["TongDaThanhToan"]);
            numTienTT.Value = conLai > 0 ? conLai : 0;
            try
            {
                GridHelper.HienThi(dgvTT, _svc.LayThanhToan(txtHDChon.Text), "MaThanhToan", "Mã giao dịch",
                                   "NgayThanhToan", "Ngày thanh toán", "HinhThuc", "*Hình thức", "SoTien", "Số tiền");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void GhiThanhToan(decimal soTien)
        {
            KetQuaXuLy kq = _svc.ThanhToan(txtHDChon.Text, DateTime.Now, cboHT.Text, soTien);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            NapHoaDon();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            GhiThanhToan(numTienTT.Value);
        }

        private void btnTraHet_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvHD);
            if (r == null)
            {
                MessageBox.Show(this, "Chọn hóa đơn trong danh sách.", "Thông báo");
                return;
            }
            decimal conLai = Convert.ToDecimal(r["TongTien"]) - Convert.ToDecimal(r["TongDaThanhToan"]);
            if (conLai <= 0)
            {
                MessageBox.Show(this, "Hóa đơn này đã thanh toán đủ.", "Thông báo");
                return;
            }
            GhiThanhToan(conLai);
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (!GridHelper.XacNhan(this, "Hoàn tất trả phòng cho phiếu " + PhieuChon() + "?")) return;
            KetQuaXuLy kq = _svc.TraPhong(PhieuChon(), DateTime.Now);
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            NapPhieuDangO();
            NapHoaDon();
        }
    }
}
