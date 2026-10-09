using System;
using System.Data;
using QuanLyDuLich.Data;

namespace QuanLyDuLich.Services
{
    public class TourDto
    {
        public string MaTour, TenTour, MaPTVe, MoTa;
        public int SoNgay, SoDem;
        public decimal DonGia;
        public bool DangKinhDoanh;
    }

    public class NoiDungChanDto
    {
        public string MaTour, MaDiaDanh, MaPT;
        public bool DoiPhuongTien, CoNoiAn, CoKhachSan;
        public int? LoaiKhachSan;
    }

    /// <summary>UC02 Quản lý tour: tour, nơi dừng chân, điểm tham quan.</summary>
    public class TourService
    {
        public DataTable LayDanhSach(bool chiDangKinhDoanh)
        {
            return Db.Query(@"SELECT t.MaTour, t.TenTour, t.SoNgay, t.SoDem, t.DonGia, t.MaPTVe, pt.TenPT,
                                     t.MoTa, t.DangKinhDoanh,
                                     t.TenTour || ' (' || t.SoNgay || 'N' || t.SoDem || 'Đ)' AS HienThi
                                FROM Tour t JOIN PhuongTien pt ON pt.MaPT = t.MaPTVe
                               WHERE (:Chi = 'N' OR t.DangKinhDoanh = 'Y')
                               ORDER BY t.MaTour", Db.P("Chi", chiDangKinhDoanh ? "Y" : "N"));
        }

        public DataTable LayPhuongTien()
        {
            return Db.Query("SELECT MaPT, TenPT FROM PhuongTien ORDER BY TenPT");
        }

        public DataTable LayDiaDanh()
        {
            return Db.Query("SELECT MaDiaDanh, TenDiaDanh FROM DiaDanh ORDER BY TenDiaDanh");
        }

        /// <summary>Kiểm tra quy tắc tour trước khi ghi: mã, tên, số ngày / số đêm, đơn giá.</summary>
        public string KiemTra(TourDto t)
        {
            if (string.IsNullOrWhiteSpace(t.MaTour)) return "Chưa nhập mã tour.";
            if (string.IsNullOrWhiteSpace(t.TenTour)) return "Chưa nhập tên tour.";
            if (t.SoDem < t.SoNgay - 1 || t.SoDem > t.SoNgay) return "Số đêm phải bằng số ngày hoặc số ngày - 1.";
            if (t.DonGia <= 0) return "Đơn giá phải lớn hơn 0.";
            if (string.IsNullOrEmpty(t.MaPTVe)) return "Chưa chọn phương tiện về TP.HCM.";
            return null;
        }

        public KetQua Luu(TourDto t, bool laThem)
        {
            string loi = KiemTra(t);
            if (loi != null) return KetQua.Loi(loi);
            try
            {
                string sql = laThem
                    ? @"INSERT INTO Tour (MaTour, TenTour, SoNgay, SoDem, DonGia, MaPTVe, MoTa, DangKinhDoanh)
                        VALUES (:Ma, :Ten, :SoNgay, :SoDem, :DonGia, :PT, :MoTa, :KD)"
                    : @"UPDATE Tour SET TenTour = :Ten, SoNgay = :SoNgay, SoDem = :SoDem, DonGia = :DonGia,
                               MaPTVe = :PT, MoTa = :MoTa, DangKinhDoanh = :KD WHERE MaTour = :Ma";
                int n = Db.Execute(sql, Db.P("Ma", t.MaTour.Trim()), Db.P("Ten", t.TenTour.Trim()),
                    Db.P("SoNgay", t.SoNgay), Db.P("SoDem", t.SoDem), Db.P("DonGia", t.DonGia), Db.P("PT", t.MaPTVe),
                    Db.P("MoTa", t.MoTa), Db.P("KD", t.DangKinhDoanh ? "Y" : "N"));
                if (n == 0) return KetQua.Loi("Không tìm thấy tour " + t.MaTour);
                return KetQua.Dat((laThem ? "Đã thêm tour " : "Đã cập nhật tour ") + t.MaTour, t.MaTour);
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        /// <summary>Không xóa tour đã có khách đăng ký, chỉ ngừng kinh doanh.</summary>
        public KetQua NgungKinhDoanh(string maTour)
        {
            try
            {
                Db.Execute("UPDATE Tour SET DangKinhDoanh = 'N' WHERE MaTour = :Ma", Db.P("Ma", maTour));
                return KetQua.Dat("Tour " + maTour + " đã ngừng kinh doanh.");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        public DataTable LayNoiDungChan(string maTour)
        {
            return Db.Query(@"SELECT n.ThuTu, d.TenDiaDanh, p.TenPT,
                                     DECODE(n.DoiPhuongTien, 'Y', 'Có', 'Không') AS DoiPT,
                                     DECODE(n.CoNoiAn, 'Y', 'Có', 'Không') AS NoiAn,
                                     DECODE(n.CoKhachSan, 'Y', n.LoaiKhachSan || ' sao', 'Không') AS KhachSan
                                FROM NoiDungChan n
                                JOIN DiaDanh d ON d.MaDiaDanh = n.MaDiaDanh
                                JOIN PhuongTien p ON p.MaPT = n.MaPT
                               WHERE n.MaTour = :Ma ORDER BY n.ThuTu", Db.P("Ma", maTour));
        }

        public KetQua ThemNoiDungChan(NoiDungChanDto n)
        {
            if (n.CoKhachSan && (n.LoaiKhachSan == null || n.LoaiKhachSan < 2 || n.LoaiKhachSan > 5))
                return KetQua.Loi("Loại khách sạn phải từ 2 đến 5 sao.");
            try
            {
                Db.Execute(@"INSERT INTO NoiDungChan (MaTour, ThuTu, MaDiaDanh, MaPT, DoiPhuongTien, CoNoiAn, CoKhachSan, LoaiKhachSan)
                             SELECT :Ma, NVL(MAX(ThuTu), 0) + 1, :DD, :PT, :Doi, :An, :KS, :Loai
                               FROM NoiDungChan WHERE MaTour = :Ma",
                    Db.P("Ma", n.MaTour), Db.P("DD", n.MaDiaDanh), Db.P("PT", n.MaPT),
                    Db.P("Doi", n.DoiPhuongTien ? "Y" : "N"), Db.P("An", n.CoNoiAn ? "Y" : "N"),
                    Db.P("KS", n.CoKhachSan ? "Y" : "N"), Db.P("Loai", n.CoKhachSan ? (object)n.LoaiKhachSan : null));
                return KetQua.Dat("Đã thêm nơi dừng chân.");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        public KetQua XoaNoiDungChanCuoi(string maTour)
        {
            try
            {
                int n = Db.Execute(@"DELETE FROM NoiDungChan WHERE MaTour = :Ma
                                        AND ThuTu = (SELECT MAX(ThuTu) FROM NoiDungChan WHERE MaTour = :Ma)", Db.P("Ma", maTour));
                return n > 0 ? KetQua.Dat("Đã xóa nơi dừng chân cuối.") : KetQua.Loi("Tour chưa có nơi dừng chân.");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        public DataTable LayDiemThamQuan(string maTour)
        {
            return Db.Query(@"SELECT d.MaDTQ, d.TenDTQ, d.DiaDiem, d.YNghia
                                FROM Tour_DiemThamQuan td JOIN DiemThamQuan d ON d.MaDTQ = td.MaDTQ
                               WHERE td.MaTour = :Ma ORDER BY d.MaDTQ", Db.P("Ma", maTour));
        }
    }
}
