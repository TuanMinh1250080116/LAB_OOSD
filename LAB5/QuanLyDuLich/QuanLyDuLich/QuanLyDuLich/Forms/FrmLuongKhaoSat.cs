using System;
using System.Data;
using System.Windows.Forms;
using QuanLyDuLich.Services;

namespace QuanLyDuLich.Forms
{
    /// <summary>UC12 Tính lương nhân viên theo tháng và UC10 Ghi nhận phiếu khảo sát sau tour.</summary>
    public partial class FrmLuongKhaoSat : Form
    {
        private readonly BaoCaoService _sv = new BaoCaoService();

        public FrmLuongKhaoSat()
        {
            InitializeComponent();
        }

        private void FrmLuongKhaoSat_Load(object sender, EventArgs e)
        {
            DateTime thangTruoc = DateTime.Today.AddMonths(-1);
            numThang.Value = thangTruoc.Month;
            numNam.Value = thangTruoc.Year;
            btnTinhLuong_Click(null, null);
            NapKhaoSat();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable t = _sv.BangLuong((int)numThang.Value, (int)numNam.Value);
                GridHelper.HienThi(dgvLuong, t, "MaNV", "Mã NV", "HoTen", "*Họ tên", "LuongCanBan", "Lương căn bản",
                                   "SoTour", "Số tour", "LuongTour", "Lương theo tour", "TongLuong", "Tổng lương");
                object tong = t.Compute("SUM(TongLuong)", "");
                lblTongLuong.Text = "Tổng quỹ lương tháng " + numThang.Value + "/" + numNam.Value + ": " +
                                    (tong == DBNull.Value ? 0 : Convert.ToDecimal(tong)).ToString("#,##0") + " đ";
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void NapKhaoSat()
        {
            try
            {
                GridHelper.HienThi(dgvKhaoSat, _sv.LayKhaoSat(), "MaKhaoSat", "Mã", "Loai", "Loại", "MaPhieu", "Phiếu / vé",
                                   "Khach", "*Khách", "TenTour", "*Tour", "NgayGui", "Ngày gửi", "MucHaiLong", "Mức hài lòng",
                                   "GopY", "*Góp ý");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private void btnGhiNhan_Click(object sender, EventArgs e)
        {
            DataRowView r = GridHelper.DongChon(dgvKhaoSat);
            if (r == null) return;
            KetQua kq = _sv.GhiNhanKhaoSat(Convert.ToInt32(r["MaKhaoSat"]), (int)numMuc.Value, txtGopY.Text);
            GridHelper.ThongBao(this, kq);
            if (kq.ThanhCong)
            {
                txtGopY.Clear();
                NapKhaoSat();
            }
        }
    }
}
