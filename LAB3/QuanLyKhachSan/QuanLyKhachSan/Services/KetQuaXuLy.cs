using System;
using System.Data.SqlClient;

namespace QuanLyKhachSan.Services
{
    /// <summary>Kết quả trả về thống nhất từ tầng Service cho Form.</summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong { get; private set; }
        public string ThongBao { get; private set; }
        public object DuLieu { get; private set; }

        public static KetQuaXuLy Ok(string thongBao, object duLieu = null)
        {
            return new KetQuaXuLy { ThanhCong = true, ThongBao = thongBao, DuLieu = duLieu };
        }

        public static KetQuaXuLy Fail(string thongBao)
        {
            return new KetQuaXuLy { ThanhCong = false, ThongBao = thongBao };
        }

        /// <summary>Đổi lỗi SQL Server thành câu thông báo tiếng Việt, không hiện lỗi thô lên Form.</summary>
        public static KetQuaXuLy TuLoi(Exception ex, string khiTrungKhoa = null)
        {
            SqlException sql = ex as SqlException;
            if (sql != null)
            {
                if (sql.Number == 2627 || sql.Number == 2601)
                    return Fail(khiTrungKhoa ?? "Dữ liệu đã tồn tại (trùng khóa chính hoặc ràng buộc duy nhất).");
                if (sql.Number == 547)
                {
                    string msg = sql.Message ?? "";
                    if (msg.IndexOf("FOREIGN KEY", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (msg.IndexOf("DELETE", StringComparison.OrdinalIgnoreCase) >= 0
                            || msg.IndexOf("UPDATE", StringComparison.OrdinalIgnoreCase) >= 0)
                            return Fail("Dữ liệu đang được sử dụng ở nơi khác nên không thể xóa.");
                        return Fail("Dữ liệu tham chiếu không tồn tại, vui lòng chọn lại.");
                    }
                    return Fail("Dữ liệu không thỏa ràng buộc của cơ sở dữ liệu: " + TenRangBuoc(msg));
                }
                if (sql.Number == 515) return Fail("Vui lòng nhập đầy đủ các thông tin bắt buộc.");
                if (sql.Number == 18456) return Fail("Sai tài khoản đăng nhập SQL Server trong chuỗi kết nối (App.config).");
                if (sql.Number == 4060) return Fail("Không tìm thấy cơ sở dữ liệu. Kiểm tra App.config.");
                if (sql.Number == 2 || sql.Number == 53 || sql.Number == -1 || sql.Number == 11001 || sql.Number == 40)
                    return Fail("Không kết nối được SQL Server. Kiểm tra dịch vụ SQL Server, tên instance và App.config.");
            }
            return Fail("Có lỗi xảy ra: " + ex.Message);
        }

        private static string TenRangBuoc(string message)
        {
            int a = message.IndexOf('"');
            int b = a >= 0 ? message.IndexOf('"', a + 1) : -1;
            return a >= 0 && b > a ? message.Substring(a + 1, b - a - 1) : message;
        }
    }
}
