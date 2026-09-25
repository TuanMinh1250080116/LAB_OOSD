using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    /// <summary>Một dòng phòng được chọn khi lập phiếu đặt.</summary>
    public class PhongDatItem
    {
        public string SoPhong { get; set; }
        public int SoNguoi { get; set; }
        public decimal DonGiaNgay { get; set; }
    }

    /// <summary>Khách hàng, phiếu đặt phòng, người lưu trú, nhận phòng.</summary>
    public class DatPhongService
    {
        public DataTable LayKhachHang()
        {
            return Db.Query("SELECT MaKhach, HoTen, SoCMND, QuocTich, SoDienThoai FROM KhachHang ORDER BY MaKhach");
        }

        public DataTable LayPhong()
        {
            return Db.Query(@"SELECT p.SoPhong, k.TenKhuVuc, p.SoNguoiToiDa, p.DonGiaNgay, p.TrangThai
                              FROM Phong p JOIN KhuVuc k ON p.MaKhuVuc = k.MaKhuVuc ORDER BY p.SoPhong");
        }

        public DataTable LayPhieuDat()
        {
            return Db.Query(@"SELECT d.SoPhieuDat, d.MaKhach, k.HoTen, d.NgayLap, d.NgayNhan, d.NgayTraDuKien,
                                     d.TienCoc, d.KenhDat, d.TrangThai
                              FROM PhieuDatPhong d JOIN KhachHang k ON d.MaKhach = k.MaKhach
                              ORDER BY d.NgayLap DESC");
        }

        public DataTable LayChiTiet(string soPhieuDat)
        {
            return Db.Query(@"SELECT c.SoPhong, c.SoNguoi, c.DonGiaApDung, p.SoNguoiToiDa
                              FROM ChiTietDatPhong c JOIN Phong p ON c.SoPhong = p.SoPhong
                              WHERE c.SoPhieuDat = @s ORDER BY c.SoPhong",
                            new SqlParameter("@s", soPhieuDat ?? ""));
        }

        public DataTable LayNguoiLuuTru(string soPhieuDat)
        {
            return Db.Query(@"SELECT MaNguoiLT, SoPhong, HoTen, SoCMND, QuocTich FROM NguoiLuuTru
                              WHERE SoPhieuDat = @s ORDER BY SoPhong, MaNguoiLT",
                            new SqlParameter("@s", soPhieuDat ?? ""));
        }

        public KetQuaXuLy ThemKhachHang(string hoTen, string cmnd, string quocTich, string sdt)
        {
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(cmnd) || string.IsNullOrWhiteSpace(quocTich))
                return KetQuaXuLy.Fail("Họ tên, CCCD và quốc tịch của khách là bắt buộc.");
            string ma = Db.SinhMa("SEQ_KhachHang", "KH", 5);
            try
            {
                Db.Execute(@"INSERT INTO KhachHang(MaKhach, HoTen, SoCMND, QuocTich, SoDienThoai)
                             VALUES (@ma, @ten, @cmnd, @qt, @sdt)",
                           new SqlParameter("@ma", ma), new SqlParameter("@ten", hoTen.Trim()),
                           new SqlParameter("@cmnd", cmnd.Trim()), new SqlParameter("@qt", quocTich.Trim()),
                           new SqlParameter("@sdt", string.IsNullOrWhiteSpace(sdt) ? (object)DBNull.Value : sdt.Trim()));
                return KetQuaXuLy.Ok("Đã thêm khách hàng " + ma + ".", ma);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Số CCCD này đã có trong danh sách khách hàng.");
            }
        }

        /// <summary>Phòng có lịch chồng lấn với phiếu Đã đặt / Đang ở hay không.</summary>
        public bool PhongTrungLich(string soPhong, DateTime nhan, DateTime tra, string boQuaPhieu = null)
        {
            object o = Db.Scalar(@"SELECT COUNT(*)
                                   FROM ChiTietDatPhong c JOIN PhieuDatPhong d ON d.SoPhieuDat = c.SoPhieuDat
                                   WHERE c.SoPhong = @p
                                     AND d.TrangThai IN (N'Đã đặt', N'Đang ở')
                                     AND (@bq IS NULL OR d.SoPhieuDat <> @bq)
                                     AND d.NgayNhan <= @tra AND d.NgayTraDuKien >= @nhan",
                                 new SqlParameter("@p", soPhong),
                                 new SqlParameter("@bq", (object)boQuaPhieu ?? DBNull.Value),
                                 new SqlParameter("@tra", SqlDbType.Date) { Value = tra.Date },
                                 new SqlParameter("@nhan", SqlDbType.Date) { Value = nhan.Date });
            return Convert.ToInt32(o) > 0;
        }

        /// <summary>Phòng còn trống trong khoảng ngày (dùng cho lưới chọn phòng).</summary>
        public DataTable LayPhongTrong(DateTime nhan, DateTime tra)
        {
            return Db.Query(@"SELECT p.SoPhong, k.TenKhuVuc, p.SoNguoiToiDa, p.DonGiaNgay, p.TrangThai
                              FROM Phong p JOIN KhuVuc k ON p.MaKhuVuc = k.MaKhuVuc
                              WHERE p.TrangThai <> N'Bảo trì'
                                AND NOT EXISTS (SELECT 1 FROM ChiTietDatPhong c
                                                JOIN PhieuDatPhong d ON d.SoPhieuDat = c.SoPhieuDat
                                                WHERE c.SoPhong = p.SoPhong
                                                  AND d.TrangThai IN (N'Đã đặt', N'Đang ở')
                                                  AND d.NgayNhan <= @tra AND d.NgayTraDuKien >= @nhan)
                              ORDER BY p.SoPhong",
                            new SqlParameter("@tra", SqlDbType.Date) { Value = tra.Date },
                            new SqlParameter("@nhan", SqlDbType.Date) { Value = nhan.Date });
        }

        /// <summary>BR05: lập phiếu đặt gồm phòng, ngày nhận, ngày trả dự kiến và tiền cọc.</summary>
        public KetQuaXuLy TaoDatPhong(string maKhach, string maNVLeTan, DateTime ngayLap, DateTime nhan, DateTime tra,
                                      decimal tienCoc, string kenhDat, IList<PhongDatItem> danhSach)
        {
            if (string.IsNullOrWhiteSpace(maKhach) || string.IsNullOrWhiteSpace(maNVLeTan))
                return KetQuaXuLy.Fail("Chưa chọn khách hàng hoặc nhân viên lễ tân.");
            if (danhSach == null || danhSach.Count == 0)
                return KetQuaXuLy.Fail("Chưa chọn phòng nào cho phiếu đặt.");
            if (tra.Date < nhan.Date)
                return KetQuaXuLy.Fail("Ngày trả dự kiến không được trước ngày nhận.");
            if (tienCoc < 0) return KetQuaXuLy.Fail("Tiền cọc không được âm.");

            foreach (PhongDatItem x in danhSach)
            {
                object sucChua = Db.Scalar("SELECT SoNguoiToiDa FROM Phong WHERE SoPhong = @p",
                                           new SqlParameter("@p", x.SoPhong));
                if (sucChua == null) return KetQuaXuLy.Fail("Không tìm thấy phòng " + x.SoPhong + ".");
                if (x.SoNguoi <= 0 || x.SoNguoi > Convert.ToInt32(sucChua))
                    return KetQuaXuLy.Fail("Số người của phòng " + x.SoPhong + " vượt sức chứa (" + sucChua + " người).");
                if (PhongTrungLich(x.SoPhong, nhan, tra))
                    return KetQuaXuLy.Fail("Phòng " + x.SoPhong + " đã có phiếu đặt trùng khoảng ngày này.");
            }

            string so = Db.SinhMa("SEQ_PhieuDat", "DP", 5);
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, @"INSERT INTO PhieuDatPhong(SoPhieuDat, MaKhach, MaNVLeTan, NgayLap, NgayNhan,
                                                                   NgayTraDuKien, TienCoc, KenhDat, TrangThai)
                                         VALUES (@so, @kh, @nv, @lap, @nhan, @tra, @coc, @kenh, N'Đã đặt')",
                               new SqlParameter("@so", so), new SqlParameter("@kh", maKhach),
                               new SqlParameter("@nv", maNVLeTan),
                               new SqlParameter("@lap", SqlDbType.Date) { Value = ngayLap },
                               new SqlParameter("@nhan", SqlDbType.Date) { Value = nhan.Date },
                               new SqlParameter("@tra", SqlDbType.Date) { Value = tra.Date },
                               new SqlParameter("@coc", tienCoc), new SqlParameter("@kenh", kenhDat));
                    foreach (PhongDatItem x in danhSach)
                    {
                        Db.Execute(cn, tx, @"INSERT INTO ChiTietDatPhong(SoPhieuDat, SoPhong, SoNguoi, DonGiaApDung)
                                             SELECT @so, @p, @n, DonGiaNgay FROM Phong WHERE SoPhong = @p",
                                   new SqlParameter("@so", so), new SqlParameter("@p", x.SoPhong),
                                   new SqlParameter("@n", x.SoNguoi));
                        Db.Execute(cn, tx, "UPDATE Phong SET TrangThai = N'Đã đặt' WHERE SoPhong = @p AND TrangThai = N'Trống'",
                                   new SqlParameter("@p", x.SoPhong));
                    }
                });
                return KetQuaXuLy.Ok("Đã lập phiếu đặt phòng " + so + ".", so);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>BR06: ghi họ tên, CCCD, quốc tịch của người lưu trú; không vượt số người đã đăng ký.</summary>
        public KetQuaXuLy ThemNguoiLuuTru(string soPhieuDat, string soPhong, string hoTen, string cmnd, string quocTich)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat) || string.IsNullOrWhiteSpace(soPhong)
                || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(cmnd) || string.IsNullOrWhiteSpace(quocTich))
                return KetQuaXuLy.Fail("Thông tin người lưu trú chưa đầy đủ.");
            try
            {
                object max = Db.Scalar("SELECT SoNguoi FROM ChiTietDatPhong WHERE SoPhieuDat = @s AND SoPhong = @p",
                                       new SqlParameter("@s", soPhieuDat), new SqlParameter("@p", soPhong));
                if (max == null) return KetQuaXuLy.Fail("Phòng này không thuộc phiếu đặt đã chọn.");
                object dem = Db.Scalar("SELECT COUNT(*) FROM NguoiLuuTru WHERE SoPhieuDat = @s AND SoPhong = @p",
                                       new SqlParameter("@s", soPhieuDat), new SqlParameter("@p", soPhong));
                if (Convert.ToInt32(dem) >= Convert.ToInt32(max))
                    return KetQuaXuLy.Fail("Đã đủ số người đăng ký cho phòng này.");
                Db.Execute(@"INSERT INTO NguoiLuuTru(SoPhieuDat, SoPhong, HoTen, SoCMND, QuocTich)
                             VALUES (@s, @p, @ten, @cmnd, @qt)",
                           new SqlParameter("@s", soPhieuDat), new SqlParameter("@p", soPhong),
                           new SqlParameter("@ten", hoTen.Trim()), new SqlParameter("@cmnd", cmnd.Trim()),
                           new SqlParameter("@qt", quocTich.Trim()));
                return KetQuaXuLy.Ok("Đã thêm người lưu trú.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        public KetQuaXuLy NhanPhong(string soPhieuDat, DateTime thucTe)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat)) return KetQuaXuLy.Fail("Chưa chọn phiếu đặt phòng.");
            try
            {
                int n = 0;
                Db.Transaction((cn, tx) =>
                {
                    n = Db.Execute(cn, tx, @"UPDATE PhieuDatPhong SET TrangThai = N'Đang ở', NgayNhanThucTe = @ngay
                                             WHERE SoPhieuDat = @s AND TrangThai = N'Đã đặt'",
                                   new SqlParameter("@ngay", SqlDbType.Date) { Value = thucTe },
                                   new SqlParameter("@s", soPhieuDat));
                    if (n == 0) throw new InvalidOperationException("Phiếu không ở trạng thái Đã đặt nên không thể nhận phòng.");
                    Db.Execute(cn, tx, @"UPDATE Phong SET TrangThai = N'Đang ở'
                                         WHERE SoPhong IN (SELECT SoPhong FROM ChiTietDatPhong WHERE SoPhieuDat = @s)",
                               new SqlParameter("@s", soPhieuDat));
                });
                return KetQuaXuLy.Ok("Đã nhận phòng.");
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

        /// <summary>Khách không đến nhận phòng; nhân viên xác nhận vì đề không nêu mốc thời gian tự động.</summary>
        public KetQuaXuLy DanhDauNoShow(string soPhieuDat)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat)) return KetQuaXuLy.Fail("Chưa chọn phiếu đặt phòng.");
            try
            {
                int n = 0;
                Db.Transaction((cn, tx) =>
                {
                    n = Db.Execute(cn, tx, "UPDATE PhieuDatPhong SET TrangThai = N'No-show' WHERE SoPhieuDat = @s AND TrangThai = N'Đã đặt'",
                                   new SqlParameter("@s", soPhieuDat));
                    if (n == 0) throw new InvalidOperationException("Chỉ phiếu đang ở trạng thái Đã đặt mới đánh dấu No-show được.");
                    Db.Execute(cn, tx, @"UPDATE Phong SET TrangThai = N'Trống'
                                         WHERE SoPhong IN (SELECT SoPhong FROM ChiTietDatPhong WHERE SoPhieuDat = @s)",
                               new SqlParameter("@s", soPhieuDat));
                });
                return KetQuaXuLy.Ok("Đã đánh dấu khách không nhận phòng và giải phóng phòng.");
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
