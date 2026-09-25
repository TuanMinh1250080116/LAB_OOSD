using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    /// <summary>Một dòng tiện nghi bị hư hỏng/mất khi trả phòng.</summary>
    public class DenBuItem
    {
        public string MaTienNghi { get; set; }
        public string TenLoaiTN { get; set; }
        public string MucDoThietHai { get; set; }
        public decimal SoTien { get; set; }
    }

    /// <summary>Kiểm tra tiện nghi, đền bù, hóa đơn, thanh toán và hoàn tất trả phòng.</summary>
    public class TraPhongService
    {
        public DataTable LayPhieuDangO()
        {
            return Db.Query(@"SELECT d.SoPhieuDat, k.HoTen, d.NgayNhanThucTe, d.NgayTraDuKien
                              FROM PhieuDatPhong d JOIN KhachHang k ON k.MaKhach = d.MaKhach
                              WHERE d.TrangThai = N'Đang ở' ORDER BY d.SoPhieuDat");
        }

        public DataTable LayPhongTheoPhieu(string soPhieuDat)
        {
            return Db.Query(@"SELECT c.SoPhong, c.SoNguoi, c.DonGiaApDung
                              FROM ChiTietDatPhong c WHERE c.SoPhieuDat = @s ORDER BY c.SoPhong",
                            new SqlParameter("@s", soPhieuDat ?? ""));
        }

        /// <summary>Tiện nghi đang lắp ở phòng (theo phiếu lắp đặt gần nhất của từng thiết bị).</summary>
        public DataTable LayTienNghiPhong(string soPhong)
        {
            return Db.Query(@"SELECT t.MaTienNghi, l.TenLoaiTN, t.TinhTrangHienTai, d.NgayLap
                              FROM PhieuLapDat d
                              JOIN TienNghi t ON t.MaTienNghi = d.MaTienNghi
                              JOIN LoaiTienNghi l ON l.MaLoaiTN = t.MaLoaiTN
                              WHERE d.SoPhong = @p
                                AND d.NgayLap = (SELECT MAX(x.NgayLap) FROM PhieuLapDat x WHERE x.MaTienNghi = d.MaTienNghi)
                              ORDER BY t.MaTienNghi",
                            new SqlParameter("@p", soPhong ?? ""));
        }

        public DataTable LayHoaDon()
        {
            return Db.Query(@"SELECT h.SoHoaDon, h.SoPhieuDat, h.NgayLap, h.SoNgayTinhTien, h.TienPhong, h.TienDichVu,
                                     h.TongTien, h.TrangThai,
                                     ISNULL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon = h.SoHoaDon), 0) AS TongDaThanhToan
                              FROM HoaDon h ORDER BY h.NgayLap DESC");
        }

        public DataTable LayThanhToan(string soHoaDon)
        {
            return Db.Query(@"SELECT MaThanhToan, NgayThanhToan, HinhThuc, SoTien FROM ThanhToan
                              WHERE SoHoaDon = @h ORDER BY NgayThanhToan",
                            new SqlParameter("@h", soHoaDon ?? ""));
        }

        /// <summary>BR08: lập phiếu đền bù theo từng tiện nghi và mức độ thiệt hại.</summary>
        public KetQuaXuLy LapPhieuDenBu(string soPhieuDat, string soPhong, DateTime ngay, string maNV, IList<DenBuItem> danhSach)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat) || string.IsNullOrWhiteSpace(soPhong) || string.IsNullOrWhiteSpace(maNV))
                return KetQuaXuLy.Fail("Chưa chọn đủ phiếu đặt, phòng và nhân viên lập phiếu.");
            if (danhSach == null || danhSach.Count == 0)
                return KetQuaXuLy.Fail("Chưa có tiện nghi nào trong danh sách đền bù.");
            decimal tong = 0;
            foreach (DenBuItem x in danhSach)
            {
                if (string.IsNullOrWhiteSpace(x.MucDoThietHai))
                    return KetQuaXuLy.Fail("Tiện nghi " + x.MaTienNghi + " chưa ghi mức độ thiệt hại.");
                if (x.SoTien < 0) return KetQuaXuLy.Fail("Số tiền đền bù không được âm.");
                tong += x.SoTien;
            }
            string so = Db.SinhMa("SEQ_PhieuDenBu", "DB", 5);
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, @"INSERT INTO PhieuDenBu(SoPhieuDenBu, SoPhieuDat, SoPhong, NgayLap, MaNV, TongTien)
                                         VALUES (@so, @s, @p, @ngay, @nv, @tong)",
                               new SqlParameter("@so", so), new SqlParameter("@s", soPhieuDat),
                               new SqlParameter("@p", soPhong),
                               new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay },
                               new SqlParameter("@nv", maNV), new SqlParameter("@tong", tong));
                    foreach (DenBuItem x in danhSach)
                    {
                        Db.Execute(cn, tx, @"INSERT INTO ChiTietPhieuDenBu(SoPhieuDenBu, MaTienNghi, MucDoThietHai, SoTien)
                                             VALUES (@so, @tn, @muc, @tien)",
                                   new SqlParameter("@so", so), new SqlParameter("@tn", x.MaTienNghi),
                                   new SqlParameter("@muc", x.MucDoThietHai), new SqlParameter("@tien", x.SoTien));
                        Db.Execute(cn, tx, "UPDATE TienNghi SET TinhTrangHienTai = @muc WHERE MaTienNghi = @tn",
                                   new SqlParameter("@muc", x.MucDoThietHai), new SqlParameter("@tn", x.MaTienNghi));
                    }
                });
                return KetQuaXuLy.Ok("Đã lập phiếu đền bù " + so + ", tổng tiền " + tong.ToString("#,##0") + " đ.", so);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Mỗi tiện nghi chỉ được ghi một dòng trong cùng phiếu đền bù.");
            }
        }

        /// <summary>BR09: hóa đơn gồm tiền phòng (đơn giá đã chốt x số ngày) và tiền dịch vụ.</summary>
        public KetQuaXuLy LapHoaDon(string soPhieuDat, DateTime ngay, string maNV, int soNgay)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat) || string.IsNullOrWhiteSpace(maNV))
                return KetQuaXuLy.Fail("Chưa chọn phiếu đặt phòng hoặc nhân viên lập hóa đơn.");
            if (soNgay <= 0) return KetQuaXuLy.Fail("Số ngày tính tiền phải lớn hơn 0.");
            try
            {
                object daCo = Db.Scalar("SELECT SoHoaDon FROM HoaDon WHERE SoPhieuDat = @s",
                                        new SqlParameter("@s", soPhieuDat));
                if (daCo != null && daCo != DBNull.Value)
                    return KetQuaXuLy.Fail("Phiếu đặt phòng này đã có hóa đơn " + daCo + ".");

                decimal tienPhong = Convert.ToDecimal(Db.Scalar(
                    "SELECT ISNULL(SUM(DonGiaApDung), 0) FROM ChiTietDatPhong WHERE SoPhieuDat = @s",
                    new SqlParameter("@s", soPhieuDat))) * soNgay;
                decimal tienDV = Convert.ToDecimal(Db.Scalar(
                    @"SELECT ISNULL(SUM(c.ThanhTien), 0) FROM PhieuSuDungDV h
                      JOIN ChiTietPhieuSuDungDV c ON c.SoPhieuSDDV = h.SoPhieuSDDV
                      WHERE h.SoPhieuDat = @s", new SqlParameter("@s", soPhieuDat)));

                string so = Db.SinhMa("SEQ_HoaDon", "HD", 5);
                Db.Execute(@"INSERT INTO HoaDon(SoHoaDon, SoPhieuDat, NgayLap, MaNV, SoNgayTinhTien, TienPhong, TienDichVu, TrangThai)
                             VALUES (@so, @s, @ngay, @nv, @songay, @phong, @dv, N'Chưa thanh toán')",
                           new SqlParameter("@so", so), new SqlParameter("@s", soPhieuDat),
                           new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay },
                           new SqlParameter("@nv", maNV), new SqlParameter("@songay", soNgay),
                           new SqlParameter("@phong", tienPhong), new SqlParameter("@dv", tienDV));
                return KetQuaXuLy.Ok(string.Format("Đã lập hóa đơn {0}: tiền phòng {1:#,##0} đ + dịch vụ {2:#,##0} đ = {3:#,##0} đ. "
                                                   + "Số ngày tính tiền do nhân viên xác nhận.",
                                                   so, tienPhong, tienDV, tienPhong + tienDV), so);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>BR10: một hóa đơn có thể thanh toán nhiều lần, nhiều hình thức, không vượt tổng tiền.</summary>
        public KetQuaXuLy ThanhToan(string soHoaDon, DateTime ngay, string hinhThuc, decimal soTien)
        {
            if (string.IsNullOrWhiteSpace(soHoaDon) || string.IsNullOrWhiteSpace(hinhThuc))
                return KetQuaXuLy.Fail("Chưa chọn hóa đơn hoặc hình thức thanh toán.");
            if (soTien <= 0) return KetQuaXuLy.Fail("Số tiền thanh toán phải lớn hơn 0.");
            try
            {
                string thongBao = "";
                Db.Transaction((cn, tx) =>
                {
                    object o = Db.Scalar(cn, tx, "SELECT TongTien FROM HoaDon WHERE SoHoaDon = @h",
                                         new SqlParameter("@h", soHoaDon));
                    if (o == null || o == DBNull.Value) throw new InvalidOperationException("Không tìm thấy hóa đơn.");
                    decimal tong = Convert.ToDecimal(o);
                    decimal da = Convert.ToDecimal(Db.Scalar(cn, tx,
                        "SELECT ISNULL(SUM(SoTien), 0) FROM ThanhToan WHERE SoHoaDon = @h",
                        new SqlParameter("@h", soHoaDon)));
                    if (da + soTien > tong)
                        throw new InvalidOperationException(string.Format("Số tiền vượt phần còn phải trả ({0:#,##0} đ).", tong - da));

                    Db.Execute(cn, tx, @"INSERT INTO ThanhToan(MaThanhToan, SoHoaDon, NgayThanhToan, HinhThuc, SoTien)
                                         VALUES (@ma, @h, @ngay, @ht, @tien)",
                               new SqlParameter("@ma", Db.SinhMa("SEQ_ThanhToan", "TT", 5)),
                               new SqlParameter("@h", soHoaDon),
                               new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay },
                               new SqlParameter("@ht", hinhThuc), new SqlParameter("@tien", soTien));

                    if (da + soTien == tong)
                    {
                        Db.Execute(cn, tx, "UPDATE HoaDon SET TrangThai = N'Đã thanh toán' WHERE SoHoaDon = @h",
                                   new SqlParameter("@h", soHoaDon));
                        thongBao = "Đã ghi nhận thanh toán bằng " + hinhThuc + ". Hóa đơn đã thanh toán đủ.";
                    }
                    else
                    {
                        thongBao = string.Format("Đã ghi nhận thanh toán bằng {0}. Còn lại {1:#,##0} đ.",
                                                 hinhThuc, tong - da - soTien);
                    }
                });
                return KetQuaXuLy.Ok(thongBao);
            }
            catch (InvalidOperationException ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>Hoàn tất trả phòng: chỉ khi hóa đơn đã thanh toán đủ.</summary>
        public KetQuaXuLy TraPhong(string soPhieuDat, DateTime ngayTra)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat)) return KetQuaXuLy.Fail("Chưa chọn phiếu đặt phòng.");
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    object tt = Db.Scalar(cn, tx, "SELECT TrangThai FROM HoaDon WHERE SoPhieuDat = @s",
                                          new SqlParameter("@s", soPhieuDat));
                    if (tt == null || tt == DBNull.Value) throw new InvalidOperationException("Chưa lập hóa đơn cho phiếu đặt phòng này.");
                    if (Convert.ToString(tt) != "Đã thanh toán") throw new InvalidOperationException("Hóa đơn chưa thanh toán đủ.");

                    int n = Db.Execute(cn, tx, @"UPDATE PhieuDatPhong SET TrangThai = N'Đã trả', NgayTraThucTe = @ngay
                                                 WHERE SoPhieuDat = @s AND TrangThai = N'Đang ở'",
                                       new SqlParameter("@ngay", SqlDbType.Date) { Value = ngayTra },
                                       new SqlParameter("@s", soPhieuDat));
                    if (n == 0) throw new InvalidOperationException("Phiếu không ở trạng thái Đang ở.");
                    Db.Execute(cn, tx, @"UPDATE Phong SET TrangThai = N'Trống'
                                         WHERE SoPhong IN (SELECT SoPhong FROM ChiTietDatPhong WHERE SoPhieuDat = @s)",
                               new SqlParameter("@s", soPhieuDat));
                });
                return KetQuaXuLy.Ok("Đã hoàn tất trả phòng và giải phóng phòng.");
            }
            catch (InvalidOperationException ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }
    }
}
