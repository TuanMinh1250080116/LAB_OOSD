using System;
using System.Windows.Forms;
using ThuVienForm.Models;

namespace ThuVienForm.Views
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (UserSession.CurrentUser != null)
            {
                // Dịch mã vai trò sang tiếng Việt
                string vaiTro = "Độc giả";
                if (UserSession.CurrentUser.MaVaiTro == "THU_THU") vaiTro = "Thủ thư";
                else if (UserSession.CurrentUser.MaVaiTro == "ADMIN") vaiTro = "Quản trị viên";

                // Hiển thị lời chào căn giữa
                lblXinChao.Text = $"Xin chào: {UserSession.CurrentUser.HoTen} ({vaiTro})";
                lblXinChao.Left = (this.ClientSize.Width - lblXinChao.Width) / 2;

                // Xử lý phân quyền: Độc giả chỉ thấy Tìm kiếm, Đề xuất, Đăng xuất
                if (UserSession.CurrentUser.MaVaiTro == "DOC_GIA")
                {
                    btnDanhMuc.Visible = false;
                    btnLapPhieu.Visible = false;
                    btnTraSach.Visible = false;
                    btnTinhTrang.Visible = false;
                    btnDuyetYeuCau.Visible = false;
                    btnBaoCao.Visible = false;
                    btnNhatKy.Visible = false;
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            var frm = new FrmTraCuu();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            UserSession.CurrentUser = null;
            this.Close(); // Đóng form chính, quay lại form đăng nhập
        }
    }
}
