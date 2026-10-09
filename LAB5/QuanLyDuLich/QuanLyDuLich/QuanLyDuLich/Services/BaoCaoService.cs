using System;
using System.Data;
using QuanLyDuLich.Data;

namespace QuanLyDuLich.Services
{
    /// <summary>UC12 Tính lương nhân viên và UC10 Ghi nhận phiếu khảo sát.</summary>
    public class BaoCaoService
    {
        /// <summary>Lương tháng = lương căn bản + tổng lương các tour kết thúc trong tháng (view V_LuongTourThang).</summary>
        public DataTable BangLuong(int thang, int nam)
        {
            return Db.Query(@"SELECT n.MaNV, n.HoTen, n.LuongCanBan, NVL(v.SoTour, 0) AS SoTour,
                                     NVL(v.TongLuongTour, 0) AS LuongTour,
                                     n.LuongCanBan + NVL(v.TongLuongTour, 0) AS TongLuong
                                FROM NhanVien n
                                LEFT JOIN V_LuongTourThang v ON v.MaNV = n.MaNV AND v.Thang = :Thang AND v.Nam = :Nam
                               WHERE n.DangLamViec = 'Y'
                               ORDER BY n.MaNV", Db.P("Thang", thang), Db.P("Nam", nam));
        }

        public DataTable LayKhaoSat()
        {
            return Db.Query(@"SELECT k.MaKhaoSat, NVL2(k.SoPhieu, 'Đoàn', 'Khách lẻ') AS Loai,
                                     NVL(k.SoPhieu, k.SoVe) AS MaPhieu,
                                     NVL(kd.TenCoQuan, kl.HoTen) AS Khach, t.TenTour, k.NgayGui, k.MucHaiLong, k.GopY
                                FROM PhieuKhaoSat k
                                LEFT JOIN PhieuDangKyDoan p ON p.SoPhieu = k.SoPhieu
                                LEFT JOIN KhachDoan kd ON kd.MaKD = p.MaKD
                                LEFT JOIN VeChuyen v ON v.SoVe = k.SoVe
                                LEFT JOIN KhachLe kl ON kl.MaKL = v.MaKL
                                LEFT JOIN ChuyenDi c ON c.MaChuyen = v.MaChuyen
                                LEFT JOIN Tour t ON t.MaTour = NVL(p.MaTour, c.MaTour)
                               ORDER BY k.NgayGui DESC, k.MaKhaoSat DESC");
        }

        public KetQua GhiNhanKhaoSat(int maKhaoSat, int mucHaiLong, string gopY)
        {
            if (mucHaiLong < 1 || mucHaiLong > 5) return KetQua.Loi("Mức hài lòng từ 1 đến 5.");
            try
            {
                Db.Execute("UPDATE PhieuKhaoSat SET MucHaiLong = :Muc, GopY = :GopY WHERE MaKhaoSat = :Ma",
                           Db.P("Muc", mucHaiLong), Db.P("GopY", string.IsNullOrWhiteSpace(gopY) ? null : gopY.Trim()),
                           Db.P("Ma", maKhaoSat));
                return KetQua.Dat("Đã ghi nhận phản hồi của khách.");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }
    }
}
