using System;
using System.Data;
using System.Windows.Forms;
using QuanLyKhachSan.Services;

namespace QuanLyKhachSan.Forms
{
    /// <summary>Tiện ích dùng chung: hiển thị lưới, lấy dòng đang chọn, thông báo kết quả.</summary>
    internal static class GridHelper
    {
        private static readonly string[] CotTien = { "DonGia", "DonGiaNgay", "DonGiaApDung", "ThanhTien", "TienCoc",
                                                     "TienPhong", "TienDichVu", "TongTien", "SoTien", "MucDenBu",
                                                     "TongDaThanhToan", "ConLai", "DoanhThu", "TienDenBu", "DaThanhToan" };

        /// <summary>cot: các cặp "TenCot", "Tiêu đề"; cột không liệt kê sẽ bị ẩn. Tiêu đề mở đầu bằng "*" là cột rộng.</summary>
        public static void HienThi(DataGridView dgv, DataTable data, params string[] cot)
        {
            dgv.DataSource = data;
            // Tiêu đề cột cao hơn mặc định để không cắt dấu tiếng Việt.
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 30;
            dgv.RowTemplate.Height = 24;
            foreach (DataGridViewColumn c in dgv.Columns) c.Visible = false;
            for (int i = 0; i + 1 < cot.Length; i += 2)
            {
                if (!dgv.Columns.Contains(cot[i])) continue;
                DataGridViewColumn c = dgv.Columns[cot[i]];
                c.HeaderText = cot[i + 1].TrimStart('*');
                c.FillWeight = cot[i + 1].StartsWith("*") ? 200 : 100;
                c.DisplayIndex = i / 2;
                c.Visible = true;
                Type t = data.Columns[cot[i]].DataType;
                if (t == typeof(DateTime))
                    c.DefaultCellStyle.Format = cot[i].StartsWith("Ngay") && !cot[i].EndsWith("ThucTe") ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm";
                else if (Array.IndexOf(CotTien, cot[i]) >= 0)
                {
                    c.DefaultCellStyle.Format = "#,##0";
                    c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        /// <summary>Dòng đang chọn (ưu tiên SelectedRows vì CurrentRow có thể chưa kịp cập nhật).</summary>
        public static DataRowView DongChon(DataGridView dgv)
        {
            DataGridViewRow row = dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0] : dgv.CurrentRow;
            return row == null ? null : row.DataBoundItem as DataRowView;
        }

        public static void ThongBao(IWin32Window owner, KetQuaXuLy kq, string tieuDe = "Thông báo")
        {
            MessageBox.Show(owner, kq.ThongBao, tieuDe, MessageBoxButtons.OK,
                            kq.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        public static void LoiHeThong(IWin32Window owner, Exception ex)
        {
            MessageBox.Show(owner, KetQuaXuLy.TuLoi(ex).ThongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool XacNhan(IWin32Window owner, string cauHoi)
        {
            return MessageBox.Show(owner, cauHoi, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>Nạp ComboBox từ DataTable.</summary>
        public static void NapCombo(ComboBox cbo, DataTable data, string hienThi, string giaTri)
        {
            cbo.DataSource = data;
            cbo.DisplayMember = hienThi;
            cbo.ValueMember = giaTri;
            cbo.SelectedIndex = data.Rows.Count > 0 ? 0 : -1;
        }

        public static string GiaTri(ComboBox cbo)
        {
            return cbo.SelectedValue == null ? "" : Convert.ToString(cbo.SelectedValue);
        }
    }
}
