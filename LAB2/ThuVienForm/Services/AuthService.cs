using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Data.SqlClient;
using ThuVienForm.Models;

namespace ThuVienForm.Services
{
    public class AuthService
    {
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyThuVienTrucTuyen;Trusted_Connection=True;TrustServerCertificate=True;";

        public string HashPassword(string password)
        {
            using var md5 = MD5.Create();
            return Convert.ToHexString(md5.ComputeHash(Encoding.UTF8.GetBytes(password))).ToLower();
        }

        public (bool Success, string Message, TaiKhoan? User) Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return (false, "Vui lòng nhập đủ thông tin.", null);
            
            string query = "SELECT MaTaiKhoan, TenDangNhap, HoTen, Email, MaVaiTro, TrangThai FROM TaiKhoan WHERE TenDangNhap = @u AND MatKhauHash = @p";
            
            try {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username.Trim());
                cmd.Parameters.AddWithValue("@p", HashPassword(password));
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read()) {
                    if (!reader.GetBoolean(5)) return (false, "Tài khoản bị khóa.", null);
                    return (true, "Thành công!", new TaiKhoan {
                        MaTaiKhoan = reader.GetInt32(0), TenDangNhap = reader.GetString(1), HoTen = reader.GetString(2), Email = reader.GetString(3), MaVaiTro = reader.GetString(4), TrangThai = reader.GetBoolean(5)
                    });
                }
                return (false, "Sai tài khoản hoặc mật khẩu.", null);
            } catch (Exception ex) { return (false, "Lỗi DB: " + ex.Message, null); }
        }
    }
}
