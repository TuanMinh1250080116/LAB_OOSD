using System;
using System.Collections.Generic;
using System.Data;
using QuanLyDuLich.Data;

namespace QuanLyDuLich.Services
{
    public class KhachDoanDto
    {
        public string TenCoQuan, DiaChi, DienThoai, NguoiDaiDien, Email;
    }

    public class PhieuDoanDto
    {
        public string MaKD, MaTour, DiaDiemDon;
        public DateTime NgayDi;
        public int SoNguoi;
        public bool CoBaoHiem;
        public decimal TienCoc;
    }

    public class NguoiDiCungDto
    {
        public string HoTen, SoGiayTo;
        public DateTime NgaySinh;
    }

    /// <summary>UC04 Lập phiếu đăng ký theo đoàn và UC08/UC11 chuyển trạng thái phiếu (đi, kết thúc, hủy, thanh toán).</summary>
    public class PhieuDoanService
    {
        public const int SoNguoiToiThieuDoan = 13;     // khách đi trên 12 người là khách theo đoàn
        public const decimal TyLeCocToiThieu = 0.3m;   // quyết định triển khai: cọc ít nhất 30% kinh phí

        public DataTable LayKhachDoan()
        {
            return Db.Query(@"SELECT MaKD, TenCoQuan, DiaChi, DienThoai, NguoiDaiDien, Email,
                                     MaKD || ' - ' || TenCoQuan AS HienThi
                                FROM KhachDoan ORDER BY TenCoQuan");
        }

        public DataTable LayDanhSachPhieu()
        {
            return Db.Query(@"SELECT p.SoPhieu, k.TenCoQuan, t.TenTour, p.NgayDi, p.NgayVe, p.SoNguoi,
                                     DECODE(p.CoBaoHiem, 'Y', 'Có', 'Không') AS BaoHiem,
                                     (SELECT COUNT(*) FROM NguoiDiCung n WHERE n.SoPhieu = p.SoPhieu) AS SoNguoiDS,
                                     (SELECT COUNT(*) FROM PhanCong c WHERE c.SoPhieu = p.SoPhieu) AS SoHDV,
                                     p.TongKinhPhi, p.TienCoc, p.TrangThai, p.CoBaoHiem
                                FROM PhieuDangKyDoan p
                                JOIN KhachDoan k ON k.MaKD = p.MaKD
                                JOIN Tour t ON t.MaTour = p.MaTour
                               ORDER BY p.NgayDi DESC");
        }

        public DataTable LayNguoiDiCung(string soPhieu)
        {
            return Db.Query("SELECT STT, HoTen, NgaySinh, SoGiayTo FROM NguoiDiCung WHERE SoPhieu = :So ORDER BY STT",
                            Db.P("So", soPhieu));
        }

        public decimal TinhKinhPhi(string maTour, int soNguoi)
        {
            object gia = Db.Scalar("SELECT DonGia FROM Tour WHERE MaTour = :Ma", Db.P("Ma", maTour));
            return gia == null ? 0 : Convert.ToDecimal(gia) * soNguoi;
        }

        /// <summary>Kiểm tra quy tắc nghiệp vụ của phiếu đoàn; trả về null nếu hợp lệ.</summary>
        public string KiemTra(PhieuDoanDto p, KhachDoanDto khachMoi, List<NguoiDiCungDto> ds, decimal tongKinhPhi)
        {
            if (khachMoi == null && string.IsNullOrEmpty(p.MaKD)) return "Chưa chọn khách đoàn.";
            if (khachMoi != null)
            {
                if (string.IsNullOrWhiteSpace(khachMoi.TenCoQuan)) return "Chưa nhập tên cơ quan / đại diện gia đình.";
                if (string.IsNullOrWhiteSpace(khachMoi.DiaChi)) return "Chưa nhập địa chỉ cơ quan.";
                if (!System.Text.RegularExpressions.Regex.IsMatch(khachMoi.DienThoai ?? "", "^[0-9]{9,15}$"))
                    return "Điện thoại chỉ gồm 9–15 chữ số.";
                if (string.IsNullOrWhiteSpace(khachMoi.NguoiDaiDien)) return "Chưa nhập người đại diện.";
            }
            if (string.IsNullOrEmpty(p.MaTour)) return "Chưa chọn tour.";
            if (p.SoNguoi < SoNguoiToiThieuDoan) return "Khách theo đoàn phải trên 12 người; dưới đó hãy bán vé theo chuyến.";
            if (p.NgayDi.Date <= DateTime.Today) return "Ngày đi phải sau ngày lập phiếu.";
            if (string.IsNullOrWhiteSpace(p.DiaDiemDon)) return "Chưa nhập địa điểm đón đoàn.";
            if (p.TienCoc < Math.Round(tongKinhPhi * TyLeCocToiThieu, 0))
                return "Tiền đặt cọc tối thiểu 30% kinh phí: " + Math.Round(tongKinhPhi * TyLeCocToiThieu, 0).ToString("#,##0") + " đ.";
            if (p.TienCoc > tongKinhPhi) return "Tiền đặt cọc không được vượt tổng kinh phí.";
            if (ds.Count > p.SoNguoi) return "Danh sách người đi cùng nhiều hơn số người đăng ký.";
            if (p.CoBaoHiem && ds.Count != p.SoNguoi)
                return "Đoàn mua bảo hiểm phải kèm danh sách đủ " + p.SoNguoi + " người (hiện có " + ds.Count + ").";
            foreach (NguoiDiCungDto n in ds)
                if (string.IsNullOrWhiteSpace(n.HoTen)) return "Có người đi cùng chưa nhập họ tên.";
            return null;
        }

        /// <summary>Lập phiếu trong một transaction: (khách đoàn mới) + phiếu + danh sách người đi cùng.</summary>
        public KetQua LapPhieu(PhieuDoanDto p, KhachDoanDto khachMoi, List<NguoiDiCungDto> ds)
        {
            try
            {
                decimal tong = TinhKinhPhi(p.MaTour, p.SoNguoi);
                string loi = KiemTra(p, khachMoi, ds, tong);
                if (loi != null) return KetQua.Loi(loi);
                string soPhieu = Db.SinhMa("SEQ_PHIEU", "PD", 6);
                Db.Transaction((cn, tx) =>
                {
                    if (khachMoi != null)
                    {
                        p.MaKD = Db.SinhMa("SEQ_KHACHDOAN", "KD", 3);
                        Db.Execute(cn, tx, @"INSERT INTO KhachDoan (MaKD, TenCoQuan, DiaChi, DienThoai, NguoiDaiDien, Email)
                                             VALUES (:Ma, :Ten, :DC, :DT, :DD, :Email)",
                            Db.P("Ma", p.MaKD), Db.P("Ten", khachMoi.TenCoQuan.Trim()), Db.P("DC", khachMoi.DiaChi.Trim()),
                            Db.P("DT", khachMoi.DienThoai.Trim()), Db.P("DD", khachMoi.NguoiDaiDien.Trim()),
                            Db.P("Email", string.IsNullOrWhiteSpace(khachMoi.Email) ? null : khachMoi.Email.Trim()));
                    }
                    // NgayVe, TongKinhPhi do trigger TRG_Phieu_TinhToan tính lại theo tour
                    Db.Execute(cn, tx, @"INSERT INTO PhieuDangKyDoan (SoPhieu, MaKD, MaTour, NgayLap, NgayDi, NgayVe, SoNguoi,
                                                DiaDiemDon, CoBaoHiem, TongKinhPhi, TienCoc)
                                         VALUES (:So, :KD, :Tour, TRUNC(SYSDATE), :NgayDi, :NgayDi, :SoNguoi,
                                                 :Don, :BH, NULL, :Coc)",
                        Db.P("So", soPhieu), Db.P("KD", p.MaKD), Db.P("Tour", p.MaTour), Db.P("NgayDi", p.NgayDi.Date),
                        Db.P("SoNguoi", p.SoNguoi), Db.P("Don", p.DiaDiemDon.Trim()), Db.P("BH", p.CoBaoHiem ? "Y" : "N"),
                        Db.P("Coc", p.TienCoc));
                    GhiDanhSach(cn, tx, soPhieu, ds);
                });
                return KetQua.Dat("Đã lập phiếu " + soPhieu + " – tổng kinh phí " + tong.ToString("#,##0") +
                                  " đ, đã đặt cọc " + p.TienCoc.ToString("#,##0") + " đ.", soPhieu);
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        /// <summary>Thay toàn bộ danh sách người đi cùng của phiếu (chỉ khi phiếu chưa khởi hành).</summary>
        public KetQua LuuDanhSach(string soPhieu, List<NguoiDiCungDto> ds)
        {
            try
            {
                DataTable p = Db.Query("SELECT SoNguoi, TrangThai FROM PhieuDangKyDoan WHERE SoPhieu = :So", Db.P("So", soPhieu));
                if (p.Rows.Count == 0) return KetQua.Loi("Không tìm thấy phiếu " + soPhieu);
                if (Convert.ToString(p.Rows[0]["TrangThai"]) != "Đã đặt cọc")
                    return KetQua.Loi("Chỉ sửa danh sách khi phiếu còn ở trạng thái \"Đã đặt cọc\".");
                if (ds.Count > Convert.ToInt32(p.Rows[0]["SoNguoi"])) return KetQua.Loi("Danh sách nhiều hơn số người đăng ký.");
                foreach (NguoiDiCungDto n in ds)
                    if (string.IsNullOrWhiteSpace(n.HoTen)) return KetQua.Loi("Có người đi cùng chưa nhập họ tên.");
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, "DELETE FROM NguoiDiCung WHERE SoPhieu = :So", Db.P("So", soPhieu));
                    GhiDanhSach(cn, tx, soPhieu, ds);
                });
                return KetQua.Dat("Đã lưu " + ds.Count + " người đi cùng cho phiếu " + soPhieu + ".");
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }

        private static void GhiDanhSach(Oracle.ManagedDataAccess.Client.OracleConnection cn,
                                        Oracle.ManagedDataAccess.Client.OracleTransaction tx, string soPhieu,
                                        List<NguoiDiCungDto> ds)
        {
            for (int i = 0; i < ds.Count; i++)
                Db.Execute(cn, tx, @"INSERT INTO NguoiDiCung (SoPhieu, STT, HoTen, NgaySinh, SoGiayTo)
                                     VALUES (:So, :Stt, :Ten, :NS, :GT)",
                    Db.P("So", soPhieu), Db.P("Stt", i + 1), Db.P("Ten", ds[i].HoTen.Trim()), Db.P("NS", ds[i].NgaySinh.Date),
                    Db.P("GT", string.IsNullOrWhiteSpace(ds[i].SoGiayTo) ? null : ds[i].SoGiayTo.Trim()));
        }

        /// <summary>
        /// Chuyển trạng thái theo biểu đồ trạng thái phiếu; trigger TRG_Phieu_TrangThai kiểm tra lần cuối.
        /// Kết thúc tour thì tự gửi phiếu khảo sát cho đoàn.
        /// </summary>
        public KetQua ChuyenTrangThai(string soPhieu, string trangThaiMoi)
        {
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, "UPDATE PhieuDangKyDoan SET TrangThai = :TT WHERE SoPhieu = :So",
                               Db.P("TT", trangThaiMoi), Db.P("So", soPhieu));
                    if (trangThaiMoi == "Chờ thanh toán")
                        Db.Execute(cn, tx, @"INSERT INTO PhieuKhaoSat (MaKhaoSat, SoPhieu, NgayGui)
                                             SELECT SEQ_KHAOSAT.NEXTVAL, :So, SYSDATE FROM dual
                                              WHERE NOT EXISTS (SELECT 1 FROM PhieuKhaoSat WHERE SoPhieu = :So)",
                                   Db.P("So", soPhieu));
                });
                return KetQua.Dat("Phiếu " + soPhieu + " chuyển sang \"" + trangThaiMoi + "\"" +
                                  (trangThaiMoi == "Chờ thanh toán" ? "; đã gửi phiếu khảo sát cho đoàn." : "."));
            }
            catch (Exception ex)
            {
                return KetQua.TuLoi(ex);
            }
        }
    }
}
