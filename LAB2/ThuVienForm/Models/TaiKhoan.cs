namespace ThuVienForm.Models
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MaVaiTro { get; set; } = string.Empty;
        public bool TrangThai { get; set; }
    }

    public static class UserSession
    {
        public static TaiKhoan? CurrentUser { get; set; }
    }
}
