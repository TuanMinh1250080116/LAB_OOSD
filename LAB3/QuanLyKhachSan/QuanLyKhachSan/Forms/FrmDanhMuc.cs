using System;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Quản lý dữ liệu nền: khu vực, nhân viên, loại tiện nghi, dịch vụ, quy định đền bù.</summary>
    public partial class FrmDanhMuc : Form
    {
        private readonly DanhMucService _svc = new DanhMucService();

        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            cboNVVaiTro.Items.AddRange(new object[] { "Lễ tân", "Quản lý", "Kỹ thuật", "Buồng phòng" });
            cboNVVaiTro.SelectedIndex = 0;
            NapTatCa();
        }

        private void NapTatCa()
        {
            try
            {
                GridHelper.HienThi(dgvKhu, _svc.LayKhuVuc(), "MaKhuVuc", "Mã khu vực", "TenKhuVuc", "*Tên khu vực");
                GridHelper.HienThi(dgvNV, _svc.LayNhanVien(), "MaNV", "Mã NV", "HoTen", "*Họ tên",
                                   "VaiTro", "Vai trò", "SoDienThoai", "Điện thoại");
                GridHelper.HienThi(dgvLoaiTN, _svc.LayLoaiTienNghi(), "MaLoaiTN", "Mã loại", "TenLoaiTN", "*Tên loại tiện nghi");
                GridHelper.HienThi(dgvDV, _svc.LayDichVu(), "MaDV", "Mã DV", "TenDV", "*Tên dịch vụ",
                                   "DonViTinh", "ĐVT", "DonGia", "Đơn giá");
                GridHelper.HienThi(dgvQD, _svc.LayQuyDinhDenBu(), "MaQuyDinh", "Mã quy định", "TenLoaiTN", "*Loại tiện nghi",
                                   "MucDoThietHai", "*Mức độ thiệt hại", "MucDenBu", "Mức đền bù");
                GridHelper.NapCombo(cboQDLoai, _svc.LayLoaiTienNghi(), "TenLoaiTN", "MaLoaiTN");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void XuLy(KetQuaXuLy kq, params Control[] xoaTrang)
        {
            GridHelper.ThongBao(this, kq);
            if (!kq.ThanhCong) return;
            foreach (Control c in xoaTrang)
            {
                TextBox t = c as TextBox;
                if (t != null) t.Clear();
                NumericUpDown n = c as NumericUpDown;
                if (n != null) n.Value = 0;
            }
            NapTatCa();
        }

        private void btnThemKhu_Click(object sender, EventArgs e)
        {
            XuLy(_svc.ThemKhuVuc(txtKhuMa.Text, txtKhuTen.Text), txtKhuMa, txtKhuTen);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            XuLy(_svc.ThemNhanVien(txtNVMa.Text, txtNVTen.Text, cboNVVaiTro.Text, txtNVSDT.Text),
                 txtNVMa, txtNVTen, txtNVSDT);
        }

        private void btnThemLoaiTN_Click(object sender, EventArgs e)
        {
            XuLy(_svc.ThemLoaiTienNghi(txtLoaiMa.Text, txtLoaiTen.Text), txtLoaiMa, txtLoaiTen);
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            XuLy(_svc.ThemDichVu(txtDVMa.Text, txtDVTen.Text, txtDVDVT.Text, numDVGia.Value),
                 txtDVMa, txtDVTen, txtDVDVT, numDVGia);
        }

        private void btnThemQD_Click(object sender, EventArgs e)
        {
            XuLy(_svc.ThemQuyDinhDenBu(txtQDMa.Text, GridHelper.GiaTri(cboQDLoai), txtQDMucDo.Text, numQDTien.Value),
                 txtQDMa, txtQDMucDo, numQDTien);
        }
    }
}
