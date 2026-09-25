using System;
using System.Data;
using System.Data.SqlClient;
using QuanLyKhachSan.Data;

namespace QuanLyKhachSan.Services
{
    /// <summary>Phòng, tiện nghi và phiếu lắp đặt / luân chuyển thiết bị.</summary>
    public class PhongTienNghiService
    {
        public DataTable LayPhong()
        {
            return Db.Query(@"SELECT p.SoPhong, p.MaKhuVuc, k.TenKhuVuc, p.SoNguoiToiDa, p.DonGiaNgay, p.TrangThai
                              FROM Phong p JOIN KhuVuc k ON p.MaKhuVuc = k.MaKhuVuc
                              ORDER BY p.SoPhong");
        }

        public DataTable LayTienNghi()
        {
            return Db.Query(@"SELECT t.MaTienNghi, t.MaLoaiTN, l.TenLoaiTN, t.SoThuTu, t.TinhTrangHienTai
                              FROM TienNghi t JOIN LoaiTienNghi l ON t.MaLoaiTN = l.MaLoaiTN
                              ORDER BY t.MaLoaiTN, t.SoThuTu");
        }

        public DataTable LayPhieuLapDat()
        {
            return Db.Query(@"SELECT d.SoPhieuLapDat, d.MaTienNghi, l.TenLoaiTN, d.SoPhong, d.NgayLap,
                                     d.TinhTrang, d.MaNV, n.HoTen, d.GhiChu
                              FROM PhieuLapDat d
                              JOIN TienNghi t ON t.MaTienNghi = d.MaTienNghi
                              JOIN LoaiTienNghi l ON l.MaLoaiTN = t.MaLoaiTN
                              JOIN NhanVien n ON n.MaNV = d.MaNV
                              ORDER BY d.NgayLap DESC, d.SoPhieuLapDat DESC");
        }

        public KetQuaXuLy ThemPhong(string soPhong, string maKhuVuc, int sucChua, decimal donGia)
        {
            if (string.IsNullOrWhiteSpace(soPhong) || string.IsNullOrWhiteSpace(maKhuVuc))
                return KetQuaXuLy.Fail("Số phòng và khu vực không được để trống.");
            if (sucChua <= 0) return KetQuaXuLy.Fail("Số người tối đa phải lớn hơn 0.");
            if (donGia < 0) return KetQuaXuLy.Fail("Đơn giá theo ngày không được âm.");
            try
            {
                Db.Execute(@"INSERT INTO Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai)
                             VALUES (@p, @k, @sc, @g, N'Trống')",
                           new SqlParameter("@p", soPhong.Trim().ToUpperInvariant()), new SqlParameter("@k", maKhuVuc),
                           new SqlParameter("@sc", sucChua), new SqlParameter("@g", donGia));
                return KetQuaXuLy.Ok("Đã thêm phòng.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Số phòng này đã tồn tại.");
            }
        }

        public KetQuaXuLy CapNhatDonGia(string soPhong, decimal donGia)
        {
            if (donGia < 0) return KetQuaXuLy.Fail("Đơn giá không được âm.");
            try
            {
                int n = Db.Execute("UPDATE Phong SET DonGiaNgay = @g WHERE SoPhong = @p",
                                   new SqlParameter("@g", donGia), new SqlParameter("@p", soPhong));
                return n > 0 ? KetQuaXuLy.Ok("Đã cập nhật đơn giá phòng. Các phiếu đặt đã lập vẫn giữ đơn giá cũ.")
                             : KetQuaXuLy.Fail("Không tìm thấy phòng.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex);
            }
        }

        /// <summary>BR03: số thứ tự phân biệt trong cùng loại tiện nghi.</summary>
        public KetQuaXuLy ThemTienNghi(string ma, string maLoaiTN, int soThuTu, string tinhTrang)
        {
            if (string.IsNullOrWhiteSpace(ma) || string.IsNullOrWhiteSpace(maLoaiTN))
                return KetQuaXuLy.Fail("Mã tiện nghi và loại tiện nghi không được để trống.");
            if (soThuTu <= 0) return KetQuaXuLy.Fail("Số thứ tự phải lớn hơn 0.");
            try
            {
                Db.Execute(@"INSERT INTO TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai)
                             VALUES (@ma, @loai, @stt, @tt)",
                           new SqlParameter("@ma", ma.Trim().ToUpperInvariant()), new SqlParameter("@loai", maLoaiTN),
                           new SqlParameter("@stt", soThuTu),
                           new SqlParameter("@tt", string.IsNullOrWhiteSpace(tinhTrang) ? (object)DBNull.Value : tinhTrang.Trim()));
                return KetQuaXuLy.Ok("Đã thêm tiện nghi.");
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Mã tiện nghi đã tồn tại hoặc số thứ tự này đã có trong cùng loại tiện nghi.");
            }
        }

        /// <summary>BR04: trong một ngày một thiết bị chỉ được trang bị cho một phòng.</summary>
        public KetQuaXuLy LapPhieuLapDat(string maTienNghi, string soPhong, DateTime ngay, string tinhTrang,
                                         string maNV, string ghiChu)
        {
            if (string.IsNullOrWhiteSpace(maTienNghi) || string.IsNullOrWhiteSpace(soPhong) || string.IsNullOrWhiteSpace(maNV))
                return KetQuaXuLy.Fail("Chưa chọn đủ tiện nghi, phòng và nhân viên lập phiếu.");
            if (string.IsNullOrWhiteSpace(tinhTrang)) return KetQuaXuLy.Fail("Chưa nhập tình trạng thiết bị.");
            string so = Db.SinhMa("SEQ_PhieuLapDat", "LD", 5);
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, @"INSERT INTO PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu)
                                         VALUES (@so, @tn, @p, @ngay, @tt, @nv, @gc)",
                               new SqlParameter("@so", so), new SqlParameter("@tn", maTienNghi),
                               new SqlParameter("@p", soPhong),
                               new SqlParameter("@ngay", SqlDbType.Date) { Value = ngay.Date },
                               new SqlParameter("@tt", tinhTrang.Trim()), new SqlParameter("@nv", maNV),
                               new SqlParameter("@gc", string.IsNullOrWhiteSpace(ghiChu) ? (object)DBNull.Value : ghiChu.Trim()));
                    Db.Execute(cn, tx, "UPDATE TienNghi SET TinhTrangHienTai = @tt WHERE MaTienNghi = @ma",
                               new SqlParameter("@tt", tinhTrang.Trim()), new SqlParameter("@ma", maTienNghi));
                });
                return KetQuaXuLy.Ok("Đã lập phiếu lắp đặt " + so + ".", so);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.TuLoi(ex, "Thiết bị này đã được lắp cho một phòng khác trong ngày đã chọn.");
            }
        }
    }
}
