using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Ghi nhận dịch vụ khách sử dụng trong thời gian lưu trú.</summary>
    public partial class FrmDichVu : Form
    {
        private readonly DichVuService _svc = new DichVuService();
        private readonly DanhMucService _dm = new DanhMucService();

        public FrmDichVu()
        {
            InitializeComponent();
        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            try
            {
                dtNgay.Value = DateTime.Today;
                GridHelper.NapCombo(cboNV, _dm.LayNhanVien(), "HoTen", "MaNV");
                GridHelper.NapCombo(cboDV, _svc.LayDichVu(), "TenDV", "MaDV");
                DataTable luot = _svc.LayLuotDangO();
                GridHelper.NapCombo(cboLuot, luot, "MoTa", "SoPhieuDat");
                if (luot.Rows.Count == 0)
                {
                    lblTong.Text = "Hiện không có lượt lưu trú nào đang ở.";
                    btnGhi.Enabled = false;
                }
                cboDV_SelectedIndexChanged(null, EventArgs.Empty);
                cboLuot_SelectedIndexChanged(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private DataRowView LuotChon()
        {
            return cboLuot.SelectedItem as DataRowView;
        }

        private void cboLuot_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView r = LuotChon();
            if (r == null) return;
            txtPhong.Text = Convert.ToString(r["SoPhong"]);
            NapLichSu();
        }

        private void cboDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView r = cboDV.SelectedItem as DataRowView;
            if (r != null) txtDonGia.Text = Convert.ToDecimal(r["DonGia"]).ToString("#,##0");
        }

        private void NapLichSu()
        {
            try
            {
                DataTable t = _svc.LayLichSu(GridHelper.GiaTri(cboLuot), txtPhong.Text);
                GridHelper.HienThi(dgvLichSu, t, "SoPhieuSDDV", "Số phiếu", "NgaySuDung", "Ngày sử dụng",
                                   "TenDV", "*Dịch vụ", "SoLuong", "Số lượng", "DonGia", "Đơn giá", "ThanhTien", "Thành tiền");
                decimal tong = 0;
                foreach (DataRow d in t.Rows) tong += Convert.ToDecimal(d["ThanhTien"]);
                lblTong.Text = string.Format("Tổng tiền dịch vụ của lượt lưu trú: {0:#,##0} đ", tong);
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            DataRowView r = LuotChon();
            if (r == null)
            {
                MessageBox.Show(this, "Chưa chọn lượt lưu trú.", "Thông báo");
                return;
            }
            KetQuaXuLy kq = _svc.GhiNhan(Convert.ToString(r["SoPhieuDat"]), Convert.ToString(r["SoPhong"]),
                                         dtNgay.Value, GridHelper.GiaTri(cboNV), GridHelper.GiaTri(cboDV),
                                         (int)numSL.Value);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong) NapLichSu();
        }
    }
}
