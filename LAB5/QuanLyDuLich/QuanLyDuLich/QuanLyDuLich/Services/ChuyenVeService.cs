using System;
using System.Data;
using QuanLyDuLich.Data;

namespace QuanLyDuLich.Services
{
    public class KhachLeDto
    {
        public string HoTen, SoGiayTo, DienThoai, DiaChi;
    }

    public class VeDto
    {
        public string MaChuyen, MaKL, MaDiemBan, MaDiemDon;
        public int SoNguoi;
    }

    /// <summary>UC03 Lập lịch chuyến, UC05 Bán vé chuyến cho khách lẻ, UC08 cập nhật tình trạng chuyến.</summary>
    public class ChuyenVeService
    {
        public const int SoNguoiToiDaKhachLe = 12;

        public DataTable LayChuyen()
        {
            return Db.Query(@"SELECT c.MaChuyen, t.TenTour, c.NgayDi, c.NgayVe, c.SoChoToiDa,
                                     NVL(SUM(CASE WHEN v.TrangThai = 'Đã thanh toán' THEN v.SoNguoi END), 0) AS DaBan,
                                     c.SoChoToiDa - NVL(SUM(CASE WHEN v.TrangThai = 'Đã thanh toán' THEN v.SoNguoi END), 0) AS ConLai,
                                     t.DonGia, c.TrangThai,
                                     (SELECT MAX(n.HoTen) FROM PhanCong pc JOIN NhanVien n ON n.MaNV = pc.MaNV
                                       WHERE pc.MaChuyen = c.MaChuyen) AS HuongDanVien
                                FROM ChuyenDi c
                                JOIN Tour t ON t.MaTour = c.MaTour
                                LEFT JOIN VeChuyen v ON v.MaChuyen = c.MaChuyen
                               GROUP BY c.MaChuyen, t.TenTour, c.NgayDi, c.NgayVe, c.SoChoToiDa, t.DonGia, c.TrangThai
                               ORDER BY c.NgayDi DESC");
        }

        public DataTable LayVe(string maChuyen)
        {
            return Db.Query(@"SELECT v.SoVe, k.HoTen, k.DienThoai, v.SoNguoi, v.ThanhTien, b.TenDiemBan, d.TenDiemDon,
                                     v.NgayMua, v.TrangThai
                                FROM VeChuyen v
                                JOIN KhachLe k ON k.MaKL = v.MaKL
                                JOIN DiemBanVe b ON b.MaDiemBan = v.MaDiemBan
                                JOIN DiemDon d ON d.MaDiemDon = v.MaDiemDon
                               WHERE v.MaChuyen = :Ma ORDER BY v.SoVe", Db.P("Ma", maChuyen));
        }

        public DataTable LayDiemBan()
        {
            return Db.Query("SELECT MaDiemBan, TenDiemBan || ' – ' || DiaChi AS HienThi FROM DiemBanVe ORDER BY MaDiemBan");
        }

        public DataTable LayDiemDon()
        {
            return Db.Query("SELECT MaDiemDon, TenDiemDon || ' – ' || DiaChi AS HienThi FROM DiemDon ORDER BY MaDiemDon");
        }

        public DataRow TimKhachLe(string soGiayTo)
        {
            DataTable t = Db.Query("SELECT MaKL, HoTen, SoGiayTo, DienThoai, DiaChi FROM KhachLe WHERE SoGiayTo = :GT",
                                   Db.P("GT", (soGiayTo ?? "").Trim()));
            return t.Rows.Count > 0 ? t.Rows[0] : null;
        }

        public KetQua ThemChuyen(string maTour, DateTime ngayDi, int soCho)
        {
            if (string.IsNullOrEmpty(maTour)) return KetQua.Loi("Chưa chọn tour.");
            if (ngayDi.Date <= DateTime.Today) return KetQua.Loi("Ngày đi của chuyến phải sau hôm nay.");
            try
            {
                string ma = Db.SinhMa("SEQ_CHUYEN", "CH", 3);
                Db.Execute(@"INSERT INTO ChuyenDi (MaChuyen, MaTour, NgayDi, NgayVe, SoChoToiDa)
                             SELECT :Ma, MaTour, :NgayDi, :NgayDi + SoNgay - 1, :SoCho FROM Tour WHERE MaTour = :Tour",
                    Db.P("Ma", ma), Db.P("NgayDi", ngayDi.Date), Db.P("SoCho", soCho), Db.P("Tour", maTour));
                return KetQua.Dat("Đã lập lịch chuyến " + ma + ".", ma);
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        /// <summary>Bán vé: (khách lẻ mới) + vé trong một transaction; trigger tính tiền và chặn quá số chỗ.</summary>
        public KetQua BanVe(VeDto v, KhachLeDto khachMoi)
        {
            if (string.IsNullOrEmpty(v.MaChuyen)) return KetQua.Loi("Chưa chọn chuyến.");
            if (v.SoNguoi < 1 || v.SoNguoi > SoNguoiToiDaKhachLe)
                return KetQua.Loi("Khách lẻ đăng ký 1–12 người; trên 12 người hãy lập phiếu theo đoàn.");
            if (string.IsNullOrEmpty(v.MaDiemBan) || string.IsNullOrEmpty(v.MaDiemDon)) return KetQua.Loi("Chưa chọn điểm bán / điểm đón.");
            if (khachMoi != null)
            {
                if (string.IsNullOrWhiteSpace(khachMoi.SoGiayTo)) return KetQua.Loi("Chưa nhập CMND/CCCD.");
                if (string.IsNullOrWhiteSpace(khachMoi.HoTen)) return KetQua.Loi("Chưa nhập họ tên khách.");
                if (!System.Text.RegularExpressions.Regex.IsMatch(khachMoi.DienThoai ?? "", "^[0-9]{9,15}$"))
                    return KetQua.Loi("Điện thoại chỉ gồm 9–15 chữ số.");
            }
            else if (string.IsNullOrEmpty(v.MaKL)) return KetQua.Loi("Chưa có thông tin khách.");
            try
            {
                object conLai = Db.Scalar(@"SELECT c.SoChoToiDa - NVL((SELECT SUM(SoNguoi) FROM VeChuyen
                                             WHERE MaChuyen = c.MaChuyen AND TrangThai = 'Đã thanh toán'), 0)
                                             FROM ChuyenDi c WHERE c.MaChuyen = :Ma", Db.P("Ma", v.MaChuyen));
                if (conLai != null && Convert.ToInt32(conLai) < v.SoNguoi)
                    return KetQua.Loi("Chuyến chỉ còn " + conLai + " chỗ.");
                string soVe = Db.SinhMa("SEQ_VE", "VE", 6);
                Db.Transaction((cn, tx) =>
                {
                    if (khachMoi != null)
                    {
                        v.MaKL = Db.SinhMa("SEQ_KHACHLE", "KL", 3);
                        Db.Execute(cn, tx, @"INSERT INTO KhachLe (MaKL, HoTen, SoGiayTo, DienThoai, DiaChi)
                                             VALUES (:Ma, :Ten, :GT, :DT, :DC)",
                            Db.P("Ma", v.MaKL), Db.P("Ten", khachMoi.HoTen.Trim()), Db.P("GT", khachMoi.SoGiayTo.Trim()),
                            Db.P("DT", khachMoi.DienThoai.Trim()),
                            Db.P("DC", string.IsNullOrWhiteSpace(khachMoi.DiaChi) ? null : khachMoi.DiaChi.Trim()));
                    }
                    // DonGia, ThanhTien do trigger TRG_Ve_TinhTien gán; 0 chỉ là giá trị giữ chỗ
                    Db.Execute(cn, tx, @"INSERT INTO VeChuyen (SoVe, MaChuyen, MaKL, MaDiemBan, MaDiemDon, SoNguoi, DonGia, ThanhTien)
                                         VALUES (:So, :Chuyen, :KL, :Ban, :Don, :SoNguoi, 0, 0)",
                        Db.P("So", soVe), Db.P("Chuyen", v.MaChuyen), Db.P("KL", v.MaKL), Db.P("Ban", v.MaDiemBan),
                        Db.P("Don", v.MaDiemDon), Db.P("SoNguoi", v.SoNguoi));
                });
                object tien = Db.Scalar("SELECT ThanhTien FROM VeChuyen WHERE SoVe = :So", Db.P("So", soVe));
                return KetQua.Dat("Đã bán vé " + soVe + " – " + v.SoNguoi + " người, thành tiền " +
                                  Convert.ToDecimal(tien).ToString("#,##0") + " đ.", soVe);
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        public KetQua HuyVe(string soVe)
        {
            try
            {
                int n = Db.Execute(@"UPDATE VeChuyen SET TrangThai = 'Đã hủy'
                                      WHERE SoVe = :So AND TrangThai = 'Đã thanh toán'
                                        AND MaChuyen IN (SELECT MaChuyen FROM ChuyenDi WHERE TrangThai = 'Mở bán')",
                                   Db.P("So", soVe));
                return n > 0 ? KetQua.Dat("Đã hủy vé " + soVe + ".") : KetQua.Loi("Chỉ hủy được vé chưa hủy của chuyến đang mở bán.");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        /// <summary>Mở bán → Đang đi (cần 1 HDV) → Kết thúc (gửi khảo sát cho từng vé); Mở bán → Hủy.</summary>
        public KetQua ChuyenTrangThai(string maChuyen, string trangThaiMoi)
        {
            try
            {
                DataTable c = Db.Query("SELECT TrangThai FROM ChuyenDi WHERE MaChuyen = :Ma", Db.P("Ma", maChuyen));
                if (c.Rows.Count == 0) return KetQua.Loi("Không tìm thấy chuyến " + maChuyen);
                string cu = Convert.ToString(c.Rows[0]["TrangThai"]);
                bool hopLe = (cu == "Mở bán" && (trangThaiMoi == "Đang đi" || trangThaiMoi == "Hủy"))
                             || (cu == "Đang đi" && trangThaiMoi == "Kết thúc");
                if (!hopLe) return KetQua.Loi("Không thể chuyển chuyến từ \"" + cu + "\" sang \"" + trangThaiMoi + "\".");
                if (trangThaiMoi == "Đang đi" &&
                    Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM PhanCong WHERE MaChuyen = :Ma", Db.P("Ma", maChuyen))) == 0)
                    return KetQua.Loi("Chuyến chưa được phân công nhân viên hướng dẫn.");
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, "UPDATE ChuyenDi SET TrangThai = :TT WHERE MaChuyen = :Ma",
                               Db.P("TT", trangThaiMoi), Db.P("Ma", maChuyen));
                    if (trangThaiMoi == "Kết thúc")
                        Db.Execute(cn, tx, @"INSERT INTO PhieuKhaoSat (MaKhaoSat, SoVe, NgayGui)
                                             SELECT SEQ_KHAOSAT.NEXTVAL, v.SoVe, SYSDATE FROM VeChuyen v
                                              WHERE v.MaChuyen = :Ma AND v.TrangThai = 'Đã thanh toán'
                                                AND NOT EXISTS (SELECT 1 FROM PhieuKhaoSat k WHERE k.SoVe = v.SoVe)",
                                   Db.P("Ma", maChuyen));
                });
                return KetQua.Dat("Chuyến " + maChuyen + " chuyển sang \"" + trangThaiMoi + "\"" +
                                  (trangThaiMoi == "Kết thúc" ? "; đã gửi phiếu khảo sát cho khách." : "."));
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }
    }
}
