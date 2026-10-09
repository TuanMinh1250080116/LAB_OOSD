using System;
using Oracle.ManagedDataAccess.Client;

namespace QuanLyDuLich.Services
{
    /// <summary>Kết quả một thao tác nghiệp vụ: thành công/thất bại, thông điệp cho người dùng và mã vừa sinh (nếu có).</summary>
    public class KetQua
    {
        public bool ThanhCong { get; private set; }
        public string ThongDiep { get; private set; }
        public string Ma { get; private set; }

        public static KetQua Dat(string thongDiep, string ma = null)
        {
            return new KetQua { ThanhCong = true, ThongDiep = thongDiep, Ma = ma };
        }

        public static KetQua Loi(string thongDiep)
        {
            return new KetQua { ThanhCong = false, ThongDiep = thongDiep };
        }

        /// <summary>Đổi lỗi Oracle (trigger, ràng buộc) thành câu tiếng Việt dễ hiểu.</summary>
        public static KetQua TuLoi(Exception ex)
        {
            OracleException o = ex as OracleException;
            if (o == null) return Loi("Lỗi: " + ex.Message);
            string m = o.Message;
            switch (o.Number)
            {
                case 20010: return Loi("Không thể chuyển trạng thái phiếu theo cách này (sai quy trình đăng ký – thực hiện tour).");
                case 20011: return Loi("Đoàn chưa được phân công nhân viên hướng dẫn nên chưa thể bắt đầu tour.");
                case 20012: return Loi("Đoàn có mua bảo hiểm: danh sách người cùng đi phải đủ bằng số người đăng ký.");
                case 20020: return Loi("Chuyến này không còn mở bán.");
                case 20021: return Loi("Chuyến không còn đủ chỗ trống cho số người này.");
                case 20030: return Loi("Nhân viên đã có lịch phân công trùng thời gian (không được chồng chéo lịch).");
                case 1: return Loi("Dữ liệu bị trùng: " + TenRangBuoc(m));
                case 2291: return Loi("Dữ liệu tham chiếu không tồn tại: " + TenRangBuoc(m));
                case 2292: return Loi("Không xóa được vì dữ liệu đang được sử dụng: " + TenRangBuoc(m));
                case 2290: return Loi("Dữ liệu vi phạm ràng buộc kiểm tra: " + TenRangBuoc(m));
                case 12541:
                case 12514:
                case 1017: return Loi("Không kết nối được Oracle: " + m);
            }
            return Loi("Lỗi Oracle: " + m);
        }

        private static string TenRangBuoc(string m)
        {
            int a = m.IndexOf('('), b = m.IndexOf(')');
            return a >= 0 && b > a ? m.Substring(a + 1, b - a - 1) : m;
        }
    }
}
