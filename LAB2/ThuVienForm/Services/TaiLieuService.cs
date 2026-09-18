using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ThuVienForm.Models;

namespace ThuVienForm.Services
{
    public class TaiLieuService
    {
        private readonly string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyThuVienTrucTuyen;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<TaiLieuDto> TimKiemTaiLieu(string tuKhoa)
        {
            var list = new List<TaiLieuDto>();
            string query = @"
                SELECT ds.MaDauSach, ds.TuaDe, tl.TenTheLoai, ds.LoaiTaiLieu, ds.SoBanKhaDung, ds.TrangThai,
                       ISNULL(ds.NamXuatBan, 0), ISNULL(ds.ISBN, 'N/A'), ISNULL(nxb.TenNXB, 'N/A'), ds.TongSoBan,
                       ISNULL((SELECT TOP 1 tg.TenTacGia FROM DauSach_TacGia dtg JOIN TacGia tg ON dtg.MaTacGia = tg.MaTacGia WHERE dtg.MaDauSach = ds.MaDauSach), 'Đang cập nhật') as TacGia
                FROM DauSach ds
                LEFT JOIN TheLoai tl ON ds.MaTheLoai = tl.MaTheLoai
                LEFT JOIN NhaXuatBan nxb ON ds.MaNXB = nxb.MaNXB
                WHERE ds.TuaDe LIKE @tuKhoa OR ds.ISBN LIKE @tuKhoa";

            try {
                using var conn = new SqlConnection(_connectionString);
                using var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa.Trim() + "%");
                
                conn.Open();
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    list.Add(new TaiLieuDto {
                        MaDauSach = reader.GetInt32(0),
                        TuaDe = reader.GetString(1),
                        TheLoai = reader.IsDBNull(2) ? "Chưa phân loại" : reader.GetString(2),
                        LoaiTaiLieu = reader.GetString(3) == "SachIn" ? "Bản in" : (reader.GetString(3) == "SachDienTu" ? "PDF/EPUB" : "Cả hai"),
                        SoBanKhaDung = reader.GetInt32(4),
                        TrangThai = reader.GetString(5),
                        NamXuatBan = reader.GetInt32(6),
                        ISBN = reader.GetString(7),
                        TenNXB = reader.GetString(8),
                        TongSoBan = reader.GetInt32(9),
                        TacGia = reader.GetString(10)
                    });
                }
            } catch (Exception ex) { System.Windows.Forms.MessageBox.Show("Lỗi truy vấn: " + ex.Message); }
            return list;
        }
    }
}
