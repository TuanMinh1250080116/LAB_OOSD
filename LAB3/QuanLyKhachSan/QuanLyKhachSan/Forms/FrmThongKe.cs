using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Thống kê theo khoảng thời gian: công suất phòng, dịch vụ, doanh thu.</summary>
    public partial class FrmThongKe : Form
    {
        private readonly ThongKeService _svc = new ThongKeService();

        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            dtTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtDen.Value = DateTime.Today;
            btnXem_Click(null, EventArgs.Empty);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtDen.Value.Date < dtTu.Value.Date)
            {
                MessageBox.Show(this, "Ngày kết thúc không được trước ngày bắt đầu.", "Thông báo");
                return;
            }
            try
            {
                DataTable t = _svc.TongHop(dtTu.Value, dtDen.Value);
                if (t.Rows.Count > 0)
                {
                    DataRow r = t.Rows[0];
                    lblSoPhieuDat.Text = Convert.ToString(r["SoPhieuDat"]);
                    lblDangO.Text = Convert.ToString(r["DangO"]);
                    lblSoHoaDon.Text = Convert.ToString(r["SoHoaDon"]);
                    lblTienPhong.Text = Convert.ToDecimal(r["TienPhong"]).ToString("#,##0");
                    lblTienDichVu.Text = Convert.ToDecimal(r["TienDichVu"]).ToString("#,##0");
                    lblDaThanhToan.Text = Convert.ToDecimal(r["DaThanhToan"]).ToString("#,##0");
                    lblThongBao.Text = string.Format("No-show: {0} phiếu – Tiền đền bù: {1:#,##0} đ",
                                                     r["NoShow"], Convert.ToDecimal(r["TienDenBu"]));
                }

                GridHelper.HienThi(dgvDichVu, _svc.ThongKeDichVu(dtTu.Value, dtDen.Value),
                                   "MaDV", "Mã DV", "TenDV", "*Tên dịch vụ", "DonViTinh", "ĐVT",
                                   "SoLuong", "Số lượng", "ThanhTien", "Thành tiền");
                GridHelper.HienThi(dgvPhong, _svc.ThongKePhong(dtTu.Value, dtDen.Value),
                                   "SoPhong", "Số phòng", "TenKhuVuc", "*Khu vực", "TrangThai", "Trạng thái",
                                   "SoLuot", "Số lượt đặt", "DoanhThu", "Doanh thu");
                GridHelper.HienThi(dgvHoaDon, _svc.ThongKeHoaDon(dtTu.Value, dtDen.Value),
                                   "SoHoaDon", "Số hóa đơn", "SoPhieuDat", "Phiếu đặt", "HoTen", "*Khách hàng",
                                   "NgayLap", "Ngày lập", "TongTien", "Tổng tiền",
                                   "TongDaThanhToan", "Đã thanh toán", "ConLai", "Còn lại", "TrangThai", "*Trạng thái");
            }
            catch (Exception ex)
            {
                GridHelper.LoiHeThong(this, ex);
            }
        }

        private DataGridView LuoiHienTai()
        {
            if (tabs.SelectedTab == tabDichVu) return dgvDichVu;
            if (tabs.SelectedTab == tabPhong) return dgvPhong;
            return dgvHoaDon;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            DataGridView dgv = LuoiHienTai();
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show(this, "Bảng đang trống, chưa có dữ liệu để xuất.", "Thông báo");
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Tệp CSV (*.csv)|*.csv";
                sfd.FileName = "ThongKe_" + dtTu.Value.ToString("yyyyMMdd") + "_" + dtDen.Value.ToString("yyyyMMdd") + ".csv";
                if (sfd.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataGridViewColumn c in dgv.Columns)
                        if (c.Visible) sb.Append('"').Append(c.HeaderText).Append("\";");
                    sb.AppendLine();
                    foreach (DataGridViewRow r in dgv.Rows)
                    {
                        foreach (DataGridViewColumn c in dgv.Columns)
                            if (c.Visible) sb.Append('"').Append(Convert.ToString(r.Cells[c.Index].Value)).Append("\";");
                        sb.AppendLine();
                    }
                    // UTF-8 kèm BOM để Excel mở đúng tiếng Việt.
                    File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));
                    MessageBox.Show(this, "Đã xuất tệp " + sfd.FileName, "Thông báo");
                }
                catch (Exception ex)
                {
                    GridHelper.LoiHeThong(this, ex);
                }
            }
        }
    }
}
