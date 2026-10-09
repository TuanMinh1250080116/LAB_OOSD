using System;
using System.Data;
using System.Windows.Forms;
using QuanLyDuLich.Services;

namespace QuanLyDuLich.Forms
{
    /// <summary>UC02 Quản lý tour: thông tin tour, nơi dừng chân và điểm tham quan.</summary>
    public partial class FrmTour : Form
    {
        private readonly TourService _sv = new TourService();

        public FrmTour()
        {
            InitializeComponent();
        }

        private void FrmTour_Load(object sender, EventArgs e)
        {
            try
            {
                GridHelper.NapCombo(cboPTVe, _sv.LayPhuongTien(), "TenPT", "MaPT");
                GridHelper.NapCombo(cboPT, _sv.LayPhuongTien(), "TenPT", "MaPT");
                GridHelper.NapCombo(cboDiaDanh, _sv.LayDiaDanh(), "TenDiaDanh", "MaDiaDanh");
                cboLoaiKS.Items.AddRange(new object[] { "2 sao", "3 sao", "4 sao", "5 sao" });
                cboLoaiKS.SelectedIndex = 1;
                cboLoaiKS.Enabled = false;
                NapTour(null);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapTour(string chon)
        {
            GridHelper.HienThi(dgvTour, _sv.LayDanhSach(false), "MaTour", "Mã", "TenTour", "*Tên tour", "SoNgay", "Ngày",
                               "SoDem", "Đêm", "DonGia", "Đơn giá", "TenPT", "Về bằng", "DangKinhDoanh", "KD");
            GridHelper.ChonDong(dgvTour, "MaTour", chon);
            HienThiChiTiet();
        }

        private string MaChon()
        {
            DataRowView r = GridHelper.DongChon(dgvTour);
            return r == null ? null : Convert.ToString(r["MaTour"]);
        }

        private void dgvTour_SelectionChanged(object sender, EventArgs e)
        {
            HienThiChiTiet();
        }

        private void HienThiChiTiet()
        {
            DataRowView r = GridHelper.DongChon(dgvTour);
            if (r == null) return;
            txtMaTour.Text = Convert.ToString(r["MaTour"]);
            txtMaTour.ReadOnly = true;
            txtTenTour.Text = Convert.ToString(r["TenTour"]);
            numSoNgay.Value = Convert.ToDecimal(r["SoNgay"]);
            numSoDem.Value = Convert.ToDecimal(r["SoDem"]);
            numDonGia.Value = Convert.ToDecimal(r["DonGia"]);
            cboPTVe.SelectedValue = Convert.ToString(r["MaPTVe"]);
            chkDangKD.Checked = Convert.ToString(r["DangKinhDoanh"]) == "Y";
            txtMoTa.Text = Convert.ToString(r["MoTa"]);
            NapChiTiet(Convert.ToString(r["MaTour"]));
        }

        private void NapChiTiet(string ma)
        {
            try
            {
                GridHelper.HienThi(dgvNoiDungChan, _sv.LayNoiDungChan(ma), "ThuTu", "Thứ tự", "TenDiaDanh", "*Nơi dừng chân",
                                   "TenPT", "Đi bằng", "DoiPT", "Đổi PT", "NoiAn", "Nơi ăn", "KhachSan", "Khách sạn");
                GridHelper.HienThi(dgvDiemThamQuan, _sv.LayDiemThamQuan(ma), "TenDTQ", "*Điểm tham quan", "DiaDiem",
                                   "Địa điểm", "YNghia", "*Ý nghĩa");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private TourDto DocForm()
        {
            return new TourDto
            {
                MaTour = txtMaTour.Text.Trim(), TenTour = txtTenTour.Text.Trim(), SoNgay = (int)numSoNgay.Value,
                SoDem = (int)numSoDem.Value, DonGia = numDonGia.Value, MaPTVe = GridHelper.GiaTri(cboPTVe),
                MoTa = txtMoTa.Text.Trim(), DangKinhDoanh = chkDangKD.Checked
            };
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            dgvTour.ClearSelection();
            txtMaTour.ReadOnly = false;
            txtMaTour.Clear();
            txtTenTour.Clear();
            txtMoTa.Clear();
            numSoNgay.Value = 3;
            numSoDem.Value = 2;
            numDonGia.Value = 0;
            chkDangKD.Checked = true;
            txtMaTour.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            KetQua kq = _sv.Luu(DocForm(), true);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) NapTour(kq.Ma);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            KetQua kq = _sv.Luu(DocForm(), false);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) NapTour(kq.Ma);
        }

        private void btnNgung_Click(object sender, EventArgs e)
        {
            string ma = MaChon();
            if (ma == null || !GridHelper.XacNhan(this, "Ngừng kinh doanh tour " + ma + "?")) return;
            GridHelper.ThongBao(this, _sv.NgungKinhDoanh(ma));
            NapTour(ma);
        }

        private void chkKhachSan_CheckedChanged(object sender, EventArgs e)
        {
            cboLoaiKS.Enabled = chkKhachSan.Checked;
        }

        private void btnThemNDC_Click(object sender, EventArgs e)
        {
            string ma = MaChon();
            if (ma == null) return;
            KetQua kq = _sv.ThemNoiDungChan(new NoiDungChanDto
            {
                MaTour = ma, MaDiaDanh = GridHelper.GiaTri(cboDiaDanh), MaPT = GridHelper.GiaTri(cboPT),
                DoiPhuongTien = chkDoiPT.Checked, CoNoiAn = chkNoiAn.Checked, CoKhachSan = chkKhachSan.Checked,
                LoaiKhachSan = chkKhachSan.Checked ? cboLoaiKS.SelectedIndex + 2 : (int?)null
            });
            if (!kq.ThanhCong) GridHelper.ThongBao(this, kq);
            NapChiTiet(ma);
        }

        private void btnXoaNDC_Click(object sender, EventArgs e)
        {
            string ma = MaChon();
            if (ma == null) return;
            KetQua kq = _sv.XoaNoiDungChanCuoi(ma);
            if (!kq.ThanhCong) GridHelper.ThongBao(this, kq);
            NapChiTiet(ma);
        }
    }
}
