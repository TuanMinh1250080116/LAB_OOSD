using System;
using System.Windows.Forms;
using ThuVienForm.Services;
using ThuVienForm.Models;

namespace ThuVienForm.Views
{
    public partial class FrmDangNhap : Form
    {
        private readonly AuthService _authService;
        public FrmDangNhap() { InitializeComponent(); _authService = new AuthService(); }
        
        private void btnDangNhap_Click(object sender, EventArgs e) {
            var res = _authService.Authenticate(txtTenDangNhap.Text, txtMatKhau.Text);
            if (!res.Success) { 
                MessageBox.Show(res.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return; 
            }
            
            // Đăng nhập thành công -> Lưu session
            UserSession.CurrentUser = res.User;
            
            // Ẩn form đăng nhập và mở màn hình chính
            this.Hide();
            var frmMain = new FrmMain();
            frmMain.ShowDialog();
            
            // Khi form chính đóng (đăng xuất), hiện lại form đăng nhập và xóa ô mật khẩu
            this.Show();
            txtMatKhau.Clear();
            txtTenDangNhap.Focus();
        }

        
        private void lnkTraCuu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmTraCuu = new FrmTraCuu();
            this.Hide();
            frmTraCuu.ShowDialog();
            this.Show();
        }
    }
}
