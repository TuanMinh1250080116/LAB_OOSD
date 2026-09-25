using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    /// <summary>Ghi nhận dịch vụ khách sử dụng trong thời gian lưu trú.</summary>
    public class DichVuService
    {
        /// <summary>Các lượt đang ở kèm phòng (một dòng cho mỗi phòng của phiếu).</summary>
        public DataTable LayLuotDangO()
        {
            return Db.Query(@"SELECT d.SoPhieuDat, c.SoPhong, k.HoTen,
                                     d.SoPhieuDat + ' - ' + c.SoPhong + ' - ' + k.HoTen AS MoTa
                              FROM PhieuDatPhong d
                              JOIN ChiTietDatPhong c ON c.SoPhieuDat = d.SoPhieuDat
                              JOIN KhachHang k ON k.MaKhach = d.MaKhach
                              WHERE d.TrangThai = N'Đang ở'
                              ORDER BY d.SoPhieuDat, c.SoPhong");
        }

        public DataTable LayDichVu()
        {
            return Db.Query("SELECT MaDV, TenDV, DonViTinh, DonGia FROM DichVu ORDER BY MaDV");
        }

        /// <summary>Lịch sử dịch vụ của một lượt lưu trú.</summary>
        public DataTable LayLichSu(string soPhieuDat, string soPhong)
        {
            return Db.Query(@"SELECT h.SoPhieuSDDV, h.SoPhong, h.NgaySuDung, d.TenDV, c.SoLuong, c.DonGia, c.ThanhTien
                              FROM PhieuSuDungDV h
                              JOIN ChiTietPhieuSuDungDV c ON c.SoPhieuSDDV = h.SoPhieuSDDV
                              JOIN DichVu d ON d.MaDV = c.MaDV
                              WHERE h.SoPhieuDat = @s AND (@p IS NULL OR h.SoPhong = @p)
                              ORDER BY h.NgaySuDung DESC, d.TenDV",
                            new SqlParameter("@s", soPhieuDat ?? ""),
                            new SqlParameter("@p", string.IsNullOrEmpty(soPhong) ? (object)DBNull.Value : soPhong));
        }

        /// <summary>
        /// BR07: mỗi phòng/ngày một phiếu; cùng một dịch vụ dùng nhiều lần trong ngày thì cộng dồn số lượng.
        /// </summary>
        public KetQuaXuLy GhiNhan(string soPhieuDat, string soPhong, DateTime ngay, string maNV, string maDV, int soLuong)
        {
            if (string.IsNullOrWhiteSpace(soPhieuDat) || string.IsNullOrWhiteSpace(soPhong)
                || string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(maDV))
                return KetQuaXuLy.Fail("Chưa chọn đủ lượt lưu trú, dịch vụ và nhân viên.");
            if (soLuong <= 0) return KetQuaXuLy.Fail("Số lượng phải lớn hơn 0.");
            try
            {
                object trangThai = Db.Scalar("SELECT TrangThai FROM PhieuDatPhong WHERE SoPhieuDat = @s",
                                             new SqlParameter("@s", soPhieuDat));
                if (trangThai == null) return KetQuaXuLy.Fail("Không tìm thấy phiếu đặt phòng.");
                if (Convert.ToString(trangThai) != "Đang ở")
                    return KetQuaXuLy.Fail("Chỉ ghi nhận dịch vụ cho lượt đang ở.");

                object gia = Db.Scalar("SELECT DonGia FROM DichVu WHERE MaDV = @d", new SqlParameter("@d", maDV));
                if (gia == null) return KetQuaXuLy.Fail("Không tìm thấy dịch vụ.");
                decimal donGia = Convert.ToDecimal(gia);
                bool congDon = false;

                Db.Transaction((cn, tx) =>
                {
                    object o = Db.Scalar(cn, tx, @"SELECT SoPhieuSDDV FROM PhieuSuDungDV
                                                   WHERE SoPhieuDat = @s AND SoPhong = @p AND NgaySuDung = @ngay",
                                         new SqlParameter("@s", soPhieuDat), new SqlParameter("@p", soPhong),
                                         new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay.Date });
                    string soPhieu;
                    if (o == null || o == DBNull.Value)
                    {
                        soPhieu = Db.SinhMa("SEQ_PhieuSDDV", "SD", 5);
                        Db.Execute(cn, tx, @"INSERT INTO PhieuSuDungDV(SoPhieuSDDV, SoPhieuDat, SoPhong, NgaySuDung, MaNV)
                                             VALUES (@so, @s, @p, @ngay, @nv)",
                                   new SqlParameter("@so", soPhieu), new SqlParameter("@s", soPhieuDat),
                                   new SqlParameter("@p", soPhong),
                                   new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay.Date },
                                   new SqlParameter("@nv", maNV));
                    }
                    else
                    {
                        soPhieu = Convert.ToString(o);
                    }

                    int n = Db.Execute(cn, tx, @"UPDATE ChiTietPhieuSuDungDV SET SoLuong = SoLuong + @sl, DonGia = @gia
                                                 WHERE SoPhieuSDDV = @so AND MaDV = @dv",
                                       new SqlParameter("@sl", soLuong), new SqlParameter("@gia", donGia),
                                       new SqlParameter("@so", soPhieu), new SqlParameter("@dv", maDV));
                    congDon = n > 0;
                    if (!congDon)
                        Db.Execute(cn, tx, @"INSERT INTO ChiTietPhieuSuDungDV(SoPhieuSDDV, MaDV, SoLuong, DonGia)
                                             VALUES (@so, @dv, @sl, @gia)",
                                   new SqlParameter("@so", soPhieu), new SqlParameter("@dv", maDV),
                                   new SqlParameter("@sl", soLuong), new SqlParameter("@gia", donGia));
                });
                return KetQuaXuLy.Ok(congDon
                    ? "Dịch vụ này đã dùng trong ngày nên số lượng được cộng dồn vào phiếu cũ."
                    : "Đã ghi nhận dịch vụ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }
    }
}
