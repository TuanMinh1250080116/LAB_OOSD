using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    /// <summary>Dữ liệu nền: khu vực, nhân viên, loại tiện nghi, dịch vụ, quy định đền bù.</summary>
    public class DanhMucService
    {
        public DataTable LayKhuVuc()
        {
            return Db.Query("SELECT MaKhuVuc, TenKhuVuc FROM KhuVuc ORDER BY MaKhuVuc");
        }

        public DataTable LayNhanVien()
        {
            return Db.Query("SELECT MaNV, HoTen, VaiTro, SoDienThoai FROM NhanVien ORDER BY MaNV");
        }

        public DataTable LayLoaiTienNghi()
        {
            return Db.Query("SELECT MaLoaiTN, TenLoaiTN FROM LoaiTienNghi ORDER BY MaLoaiTN");
        }

        public DataTable LayDichVu()
        {
            return Db.Query("SELECT MaDV, TenDV, DonViTinh, DonGia FROM DichVu ORDER BY MaDV");
        }

        public DataTable LayQuyDinhDenBu()
        {
            return Db.Query(@"SELECT q.MaQuyDinh, q.MaLoaiTN, l.TenLoaiTN, q.MucDoThietHai, q.MucDenBu
                              FROM QuyDinhDenBu q JOIN LoaiTienNghi l ON q.MaLoaiTN = l.MaLoaiTN
                              ORDER BY q.MaQuyDinh");
        }

        public KetQuaXuLy ThemKhuVuc(string ma, string ten)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                return KetQuaXuLy.Fail("Mã khu vực và tên khu vực không được để trống.");
            try
            {
                Db.Execute("INSERT INTO KhuVuc(MaKhuVuc, TenKhuVuc) VALUES (@ma, @ten)",
                           new SqlParameter("@ma", ma.Trim().ToUpperInvariant()), new SqlParameter("@ten", ten.Trim()));
                return KetQuaXuLy.Ok("Đã thêm khu vực.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Mã khu vực hoặc tên khu vực đã tồn tại.");
            }
        }

        public KetQuaXuLy ThemNhanVien(string ma, string hoTen, string vaiTro, string sdt)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(vaiTro))
                return KetQuaXuLy.Fail("Thông tin nhân viên chưa đầy đủ (mã, họ tên, vai trò).");
            try
            {
                Db.Execute("INSERT INTO NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES (@ma, @ten, @vt, @sdt)",
                           new SqlParameter("@ma", ma.Trim().ToUpperInvariant()), new SqlParameter("@ten", hoTen.Trim()),
                           new SqlParameter("@vt", vaiTro.Trim()),
                           new SqlParameter("@sdt", string.IsNullOrWhiteSpace(sdt) ? (object)DBNull.Value : sdt.Trim()));
                return KetQuaXuLy.Ok("Đã thêm nhân viên.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Mã nhân viên đã tồn tại.");
            }
        }

        public KetQuaXuLy ThemLoaiTienNghi(string ma, string ten)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten))
                return KetQuaXuLy.Fail("Thông tin loại tiện nghi chưa đủ.");
            try
            {
                Db.Execute("INSERT INTO LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES (@ma, @ten)",
                           new SqlParameter("@ma", ma.Trim().ToUpperInvariant()), new SqlParameter("@ten", ten.Trim()));
                return KetQuaXuLy.Ok("Đã thêm loại tiện nghi.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Mã loại hoặc tên loại tiện nghi đã tồn tại.");
            }
        }

        public KetQuaXuLy ThemDichVu(string ma, string ten, string donViTinh, decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(donViTinh))
                return KetQuaXuLy.Fail("Thông tin dịch vụ chưa đủ.");
            if (donGia < 0) return KetQuaXuLy.Fail("Đơn giá dịch vụ không được âm.");
            try
            {
                Db.Execute("INSERT INTO DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES (@ma, @ten, @dvt, @gia)",
                           new SqlParameter("@ma", ma.Trim().ToUpperInvariant()), new SqlParameter("@ten", ten.Trim()),
                           new SqlParameter("@dvt", donViTinh.Trim()), new SqlParameter("@gia", donGia));
                return KetQuaXuLy.Ok("Đã thêm dịch vụ.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Mã dịch vụ đã tồn tại.");
            }
        }

        public KetQuaXuLy ThemQuyDinhDenBu(string ma, string maLoaiTN, string mucDo, decimal mucDenBu)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(maLoaiTN) || string.IsNullOrWhiteSpace(mucDo))
                return KetQuaXuLy.Fail("Quy định đền bù chưa đủ thông tin.");
            if (mucDenBu < 0) return KetQuaXuLy.Fail("Mức đền bù không được âm.");
            try
            {
                Db.Execute(@"INSERT INTO QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu)
                             VALUES (@ma, @loai, @muc, @tien)",
                           new SqlParameter("@ma", ma.Trim().ToUpperInvariant()), new SqlParameter("@loai", maLoaiTN),
                           new SqlParameter("@muc", mucDo.Trim()), new SqlParameter("@tien", mucDenBu));
                return KetQuaXuLy.Ok("Đã thêm quy định đền bù.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Loại tiện nghi này đã có quy định cho mức độ thiệt hại vừa nhập.");
            }
        }

        /// <summary>Mức đền bù theo loại tiện nghi và mức độ thiệt hại (dùng ở màn hình trả phòng).</summary>
        public decimal? LayMucDenBu(string maTienNghi, string mucDo)
        {
            object o = Db.Scalar(@"SELECT q.MucDenBu FROM QuyDinhDenBu q
                                   JOIN TienNghi t ON t.MaLoaiTN = q.MaLoaiTN
                                   WHERE t.MaTienNghi = @tn AND UPPER(q.MucDoThietHai) = UPPER(@muc)",
                                 new SqlParameter("@tn", maTienNghi), new SqlParameter("@muc", mucDo ?? ""));
            return o == null || o == DBNull.Value ? (decimal?)null : Convert.ToDecimal(o);
        }
    }
}
