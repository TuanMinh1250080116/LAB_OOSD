using System;
using System.Data;
using QuanLyDuLich.Data;

namespace QuanLyDuLich.Services
{
    /// <summary>UC07 Phân công nhân viên hướng dẫn theo đoàn hoặc theo chuyến, không chồng chéo lịch.</summary>
    public class PhanCongService
    {
        public const int SoKhachMoiHDV = 25;   // quyết định triển khai: gợi ý 1 HDV cho mỗi 25 khách đoàn

        /// <summary>Đoàn ("Đã đặt cọc") và chuyến ("Mở bán") chưa khởi hành, cùng số HDV đã có.</summary>
        public DataTable LayDoanVaChuyenCanPhanCong()
        {
            return Db.Query(@"SELECT 'Đoàn' AS Loai, p.SoPhieu AS Ma, t.TenTour, k.TenCoQuan AS Khach, p.NgayDi, p.NgayVe,
                                     p.SoNguoi AS SoKhach,
                                     (SELECT COUNT(*) FROM PhanCong c WHERE c.SoPhieu = p.SoPhieu) AS SoHDV
                                FROM PhieuDangKyDoan p
                                JOIN Tour t ON t.MaTour = p.MaTour
                                JOIN KhachDoan k ON k.MaKD = p.MaKD
                               WHERE p.TrangThai = 'Đã đặt cọc'
                              UNION ALL
                              SELECT 'Chuyến', c.MaChuyen, t.TenTour, N'Khách lẻ', c.NgayDi, c.NgayVe,
                                     NVL((SELECT SUM(v.SoNguoi) FROM VeChuyen v
                                           WHERE v.MaChuyen = c.MaChuyen AND v.TrangThai = 'Đã thanh toán'), 0),
                                     (SELECT COUNT(*) FROM PhanCong pc WHERE pc.MaChuyen = c.MaChuyen)
                                FROM ChuyenDi c JOIN Tour t ON t.MaTour = c.MaTour
                               WHERE c.TrangThai = 'Mở bán'
                               ORDER BY 5");
        }

        /// <summary>Nhân viên đang làm việc và không có phân công nào giao với khoảng [tu, den].</summary>
        public DataTable LayNhanVienRanh(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT n.MaNV, n.HoTen, n.DienThoai,
                                     (SELECT COUNT(*) FROM PhanCong c WHERE c.MaNV = n.MaNV
                                         AND c.NgayBatDau >= TRUNC(SYSDATE, 'MM')) AS SoTourThangNay
                                FROM NhanVien n
                               WHERE n.DangLamViec = 'Y'
                                 AND NOT EXISTS (SELECT 1 FROM PhanCong c WHERE c.MaNV = n.MaNV
                                                    AND c.NgayBatDau <= :Den AND :Tu <= c.NgayKetThuc)
                               ORDER BY 4, n.MaNV", Db.P("Tu", tu.Date), Db.P("Den", den.Date));
        }

        public DataTable LayDaPhanCong(string soPhieu, string maChuyen)
        {
            return Db.Query(@"SELECT c.MaPhanCong, c.MaNV, n.HoTen, n.DienThoai, c.NgayBatDau, c.NgayKetThuc, c.LuongTour
                                FROM PhanCong c JOIN NhanVien n ON n.MaNV = c.MaNV
                               WHERE c.SoPhieu = :So OR c.MaChuyen = :Chuyen
                               ORDER BY c.MaPhanCong", Db.P("So", soPhieu), Db.P("Chuyen", maChuyen));
        }

        /// <summary>
        /// Phân công một nhân viên. Chuyến khách lẻ chỉ một nhân viên (UQ_PC_Chuyen);
        /// trùng lịch bị trigger TRG_PhanCong_ChongCheo chặn.
        /// </summary>
        public KetQua PhanCong(string maNV, string soPhieu, string maChuyen)
        {
            if (string.IsNullOrEmpty(maNV)) return KetQua.Loi("Chưa chọn nhân viên.");
            if (string.IsNullOrEmpty(soPhieu) == string.IsNullOrEmpty(maChuyen)) return KetQua.Loi("Chọn một đoàn hoặc một chuyến.");
            try
            {
                if (maChuyen != null &&
                    Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM PhanCong WHERE MaChuyen = :Ma", Db.P("Ma", maChuyen))) > 0)
                    return KetQua.Loi("Mỗi chuyến khách lẻ chỉ được phân công một nhân viên.");
                Db.Execute(@"INSERT INTO PhanCong (MaPhanCong, MaNV, SoPhieu, MaChuyen, NgayBatDau, NgayKetThuc, LuongTour)
                             VALUES (SEQ_PHANCONG.NEXTVAL, :NV, :So, :Chuyen, SYSDATE, SYSDATE, NULL)",
                    Db.P("NV", maNV), Db.P("So", soPhieu), Db.P("Chuyen", maChuyen));
                return KetQua.Dat("Đã phân công " + maNV + " cho " + (soPhieu ?? maChuyen) + ".");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        public KetQua HuyPhanCong(int maPhanCong)
        {
            try
            {
                int n = Db.Execute(@"DELETE FROM PhanCong c WHERE c.MaPhanCong = :Ma
                                        AND (c.SoPhieu IN (SELECT SoPhieu FROM PhieuDangKyDoan WHERE TrangThai = 'Đã đặt cọc')
                                          OR c.MaChuyen IN (SELECT MaChuyen FROM ChuyenDi WHERE TrangThai = 'Mở bán'))",
                                   Db.P("Ma", maPhanCong));
                return n > 0 ? KetQua.Dat("Đã hủy phân công.") : KetQua.Loi("Chỉ hủy được phân công của đoàn / chuyến chưa khởi hành.");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }
    }
}
