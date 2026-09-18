using System;
using System.Drawing;
using System.Windows.Forms;

namespace ThuVienForm.Views
{
    public partial class FrmDocTrucTuyen : Form
    {
        private int _tongSoTrang;

        public FrmDocTrucTuyen(string tuaDe, int tongSoTrang = 320)
        {
            InitializeComponent();
            this.Text = $"Đọc trực tuyến – {tuaDe}";
            _tongSoTrang = tongSoTrang;
            lblTongSoTrang.Text = $"/ {_tongSoTrang}";
            nudTrang.Maximum = _tongSoTrang;
        }

        private void FrmDocTrucTuyen_Load(object sender, EventArgs e)
        {
            cboThuPhong.SelectedIndex = 2; // Chọn mặc định 100%
            nudTrang.Value = 15; // Set theo mockup
            CapNhatTrangThaiNut();
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            if (nudTrang.Value > 1) nudTrang.Value--;
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            if (nudTrang.Value < nudTrang.Maximum) nudTrang.Value++;
        }

        private void nudTrang_ValueChanged(object sender, EventArgs e)
        {
            CapNhatTrangThaiNut();
            lblNoiDungGiaLap.Text = $"Nội dung trang {nudTrang.Value} hiển thị tại đây\n(trình xem PDF / EPUB)";
        }

        private void CapNhatTrangThaiNut()
        {
            btnTruoc.Enabled = nudTrang.Value > 1;
            btnSau.Enabled = nudTrang.Value < nudTrang.Maximum;
        }

        private void btnTaiXuong_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuyển hướng sang màn hình Kiểm tra mã thẻ (UC04)...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
