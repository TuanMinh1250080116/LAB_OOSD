using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    /// <summary>Thống kê theo khoảng thời gian cho người quản lý.</summary>
    public class ThongKeService
    {
        private static SqlParameter[] Khoang(DateTime tu, DateTime den)
        {
            return new[]
            {
                new SqlParameter("@tu", SqlDbType.Date) { Value = tu.Date },
                new SqlParameter("@den", SqlDbType.Date) { Value = den.Date }
            };
        }

        /// <summary>Tổng hợp: số phiếu đặt, số hóa đơn, doanh thu phòng/dịch vụ, tiền đền bù, đã thanh toán.</summary>
        public DataTable TongHop(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT
                (SELECT COUNT(*) FROM PhieuDatPhong WHERE NgayLap >= @tu AND NgayLap < DATEADD(day, 1, @den))          AS SoPhieuDat,
                (SELECT COUNT(*) FROM PhieuDatPhong WHERE TrangThai = N'Đang ở')                          AS DangO,
                (SELECT COUNT(*) FROM PhieuDatPhong WHERE TrangThai = N'No-show'
                                                      AND NgayLap >= @tu AND NgayLap < DATEADD(day, 1, @den))          AS NoShow,
                (SELECT COUNT(*) FROM HoaDon WHERE NgayLap >= @tu AND NgayLap < DATEADD(day, 1, @den))                 AS SoHoaDon,
                (SELECT ISNULL(SUM(TienPhong), 0) FROM HoaDon WHERE NgayLap >= @tu AND NgayLap < DATEADD(day, 1, @den))   AS TienPhong,
                (SELECT ISNULL(SUM(TienDichVu), 0) FROM HoaDon WHERE NgayLap >= @tu AND NgayLap < DATEADD(day, 1, @den))  AS TienDichVu,
                (SELECT ISNULL(SUM(TongTien), 0) FROM PhieuDenBu WHERE NgayLap >= @tu AND NgayLap < DATEADD(day, 1, @den)) AS TienDenBu,
                (SELECT ISNULL(SUM(SoTien), 0) FROM ThanhToan
                  WHERE NgayThanhToan >= @tu AND NgayThanhToan < DATEADD(day, 1, @den))                                AS DaThanhToan", Khoang(tu, den));
        }

        /// <summary>Dịch vụ được sử dụng trong khoảng thời gian.</summary>
        public DataTable ThongKeDichVu(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT d.MaDV, d.TenDV, d.DonViTinh, SUM(c.SoLuong) AS SoLuong, SUM(c.ThanhTien) AS ThanhTien
                              FROM PhieuSuDungDV h
                              JOIN ChiTietPhieuSuDungDV c ON c.SoPhieuSDDV = h.SoPhieuSDDV
                              JOIN DichVu d ON d.MaDV = c.MaDV
                              WHERE h.NgaySuDung >= @tu AND h.NgaySuDung < DATEADD(day, 1, @den)
                              GROUP BY d.MaDV, d.TenDV, d.DonViTinh
                              ORDER BY SUM(c.ThanhTien) DESC", Khoang(tu, den));
        }

        /// <summary>Công suất phòng: số lượt đặt và doanh thu theo từng phòng.</summary>
        public DataTable ThongKePhong(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT p.SoPhong, k.TenKhuVuc, p.TrangThai,
                                     COUNT(c.SoPhieuDat) AS SoLuot,
                                     ISNULL(SUM(c.DonGiaApDung), 0) AS DoanhThu
                              FROM Phong p
                              JOIN KhuVuc k ON k.MaKhuVuc = p.MaKhuVuc
                              LEFT JOIN ChiTietDatPhong c ON c.SoPhong = p.SoPhong
                              LEFT JOIN PhieuDatPhong d ON d.SoPhieuDat = c.SoPhieuDat
                                   AND d.NgayLap >= @tu AND d.NgayLap < DATEADD(day, 1, @den)
                                   AND d.TrangThai <> N'Hủy'
                              GROUP BY p.SoPhong, k.TenKhuVuc, p.TrangThai
                              ORDER BY p.SoPhong", Khoang(tu, den));
        }

        /// <summary>Hóa đơn trong kỳ kèm số tiền đã thanh toán và còn lại.</summary>
        public DataTable ThongKeHoaDon(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT h.SoHoaDon, h.SoPhieuDat, k.HoTen, h.NgayLap, h.TongTien, h.TrangThai,
                                     ISNULL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon = h.SoHoaDon), 0) AS TongDaThanhToan,
                                     h.TongTien - ISNULL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon = h.SoHoaDon), 0) AS ConLai
                              FROM HoaDon h
                              JOIN PhieuDatPhong d ON d.SoPhieuDat = h.SoPhieuDat
                              JOIN KhachHang k ON k.MaKhach = d.MaKhach
                              WHERE h.NgayLap >= @tu AND h.NgayLap < DATEADD(day, 1, @den)
                              ORDER BY h.NgayLap DESC", Khoang(tu, den));
        }
    }
}
