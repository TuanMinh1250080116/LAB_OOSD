using System;
using System.Drawing;
using System.Windows.Forms;
using ThuVienForm.Services;
using ThuVienForm.Models;

namespace ThuVienForm.Views
{
    public partial class FrmTraCuu : Form
    {
        private readonly TaiLieuService _taiLieuService;

        public FrmTraCuu()
        {
            InitializeComponent();
            _taiLieuService = new TaiLieuService();
            dgvKetQua.AutoGenerateColumns = false;
        }

        private void FrmTraCuu_Load(object sender, EventArgs e)
        {
            HienThiKetQua("");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            HienThiKetQua(txtTuKhoa.Text);
        }

        private void btnXoaLoc_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            txtTacGia.Clear();
            cboLoai.SelectedIndex = -1;
            cboChuDe.SelectedIndex = -1;
            chkBanIn.Checked = true;
            chkPDF.Checked = true;
            chkEPUB.Checked = true;
            HienThiKetQua("");
        }

        private void HienThiKetQua(string tuKhoa)
        {
            var ketQua = _taiLieuService.TimKiemTaiLieu(tuKhoa);
            dgvKetQua.DataSource = ketQua;
            gbKetQua.Text = $"Tìm thấy {ketQua.Count} kết quả";
            
            if(ketQua.Count == 0) lblChiTiet.Text = "Vui lòng chọn một tài liệu để xem chi tiết.";
        }

        private void dgvKetQua_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKetQua.CurrentRow != null && dgvKetQua.CurrentRow.DataBoundItem is TaiLieuDto tl)
            {
                lblChiTiet.Text = $"Tiêu đề: {tl.TuaDe}\n\n" +
                                  $"Tác giả: {tl.TacGia}\n\n" +
                                  $"ISBN: {tl.ISBN}\n\n" +
                                  $"NXB: {tl.TenNXB}\n\n" +
                                  $"Năm: {tl.NamXuatBan}\n\n" +
                                  $"Chủ đề: {tl.TheLoai}\n\n" +
                                  $"Số bản còn: {tl.SoBanKhaDung} / {tl.TongSoBan}";

                // Kiểm tra loại tài liệu để vô hiệu hóa/bật các nút
                bool laSachDienTu = tl.LoaiTaiLieu.Contains("PDF") || tl.LoaiTaiLieu.Contains("EPUB");
                bool laSachIn = tl.LoaiTaiLieu.Contains("Bản in") || tl.LoaiTaiLieu.Contains("Cả hai");

                btnDocOnline.Enabled = laSachDienTu;
                btnTaiXuong.Enabled = laSachDienTu;
                btnDangKyMuon.Enabled = laSachIn && tl.SoBanKhaDung > 0;
            }
        }
        private void btnDocOnline_Click(object sender, EventArgs e)
        {
            if (dgvKetQua.CurrentRow != null && dgvKetQua.CurrentRow.DataBoundItem is TaiLieuDto tl)
            {
                // Truyền tên tựa đề sách sang form đọc trực tuyến
                var frmDoc = new FrmDocTrucTuyen(tl.TuaDe);
                frmDoc.ShowDialog();
            }
        }
    }
}
