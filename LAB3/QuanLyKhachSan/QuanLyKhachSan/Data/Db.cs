using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace QuanLyKhachSan.Data
{
    /// <summary>
    /// Lớp truy cập dữ liệu dùng chung cho hệ thống khách sạn
    /// (ADO.NET - SQL Server).
    /// </summary>
    public static class Db
    {
        // Dùng khi App.config chưa khai báo chuỗi kết nối.
        // Windows Authentication.
        private const string MacDinh =
          @"Server=(localdb)\MSSQLLocalDB;Database=QuanLyKhachSan;Trusted_Connection=True;TrustServerCertificate=True;";

        /*
         * SQL Server thường giữ nguyên tên cột theo khai báo,
         * nhưng vẫn giữ phần chuẩn hóa này để tương thích với code cũ.
         */
        private const string TenCotChuan =
            "ChiTietDatPhong ChiTietPhieuDenBu ChiTietPhieuSuDungDV ConLai DichVu DoanhThu DonGia DonGiaApDung " +
            "DonGiaNgay DonViTinh GhiChu HinhThuc HoTen HoaDon KenhDat KhachHang KhuVuc LoaiTienNghi MaDV MaKhach " +
            "MaKhuVuc MaLoaiTN MaNV MaNVLeTan MaNguoiLT MaQuyDinh MaThanhToan MaTienNghi MucDenBu MucDoThietHai NgayLap " +
            "NgayNhan NgayNhanThucTe NgaySuDung NgayThanhToan NgayTraDuKien NgayTraThucTe NguoiLuuTru NhanVien " +
            "PhieuDatPhong PhieuDenBu PhieuLapDat PhieuSuDungDV QuocTich QuyDinhDenBu SoBang SoCMND SoDienThoai SoHoaDon " +
            "SoLuong SoLuot SoNgayTinhTien SoNguoi SoNguoiToiDa SoPhieuDat SoPhieuDenBu SoPhieuLapDat SoPhieuSDDV " +
            "SoPhong SoThuTu SoTien TenDV TenKhuVuc TenLoaiTN ThanhTien ThanhToan TienCoc TienDichVu TienNghi TienPhong " +
            "TinhTrang TinhTrangHienTai TongDaThanhToan TongTien TrangThai VaiTro";

        private static readonly Regex _dinhDanh =
            new Regex(
                @"\b[A-Za-z_][A-Za-z0-9_]*\b",
                RegexOptions.Compiled
            );

        private static readonly Dictionary<string, string> _tenChuan =
            TaoTuDien(TenCotChuan);

        private static string _connectionString;

        /// <summary>
        /// Chuỗi kết nối tới SQL Server.
        /// Ưu tiên lấy từ App.config.
        /// Nếu không có thì dùng chuỗi mặc định.
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    ConnectionStringSettings cs =
                        ConfigurationManager
                            .ConnectionStrings["QuanLyKhachSanDb"];

                    _connectionString =
                        cs != null
                            ? cs.ConnectionString
                            : MacDinh;
                }

                return _connectionString;
            }

            set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// Mở kết nối SQL Server.
        /// </summary>
        public static SqlConnection OpenConnection()
        {
            SqlConnection cn =
                new SqlConnection(ConnectionString);

            cn.Open();

            return cn;
        }

        /// <summary>
        /// Tạo SqlCommand.
        ///
        /// SQL Server sử dụng tham số dạng:
        /// @MaKhach
        /// @SoPhong
        /// @NgayNhan
        ///
        /// thay vì Oracle:
        /// :MaKhach
        /// :SoPhong
        /// </summary>
        private static SqlCommand TaoLenh(
            SqlConnection cn,
            string sql,
            SqlParameter[] parameters)
        {
            SqlCommand cmd =
                new SqlCommand(sql, cn);

            if (parameters != null &&
                parameters.Length > 0)
            {
                cmd.Parameters.AddRange(parameters);
            }

            return cmd;
        }

        /// <summary>
        /// Chạy SELECT và trả về DataTable.
        /// </summary>
        public static DataTable Query(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection cn = OpenConnection())
            using (SqlCommand cmd =
                   TaoLenh(cn, sql, parameters))
            using (SqlDataAdapter da =
                   new SqlDataAdapter(cmd))
            {
                DataTable table =
                    new DataTable();

                da.Fill(table);

                ChuanHoaTenCot(table, sql);

                return table;
            }
        }

        /// <summary>
        /// Chạy INSERT / UPDATE / DELETE.
        /// Trả về số dòng bị ảnh hưởng.
        /// </summary>
        public static int Execute(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection cn =
                   OpenConnection())
            using (SqlCommand cmd =
                   TaoLenh(cn, sql, parameters))
            {
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Chạy câu SQL trả về đúng một giá trị.
        ///
        /// Ví dụ:
        /// SELECT COUNT(*) FROM Phong
        /// </summary>
        public static object Scalar(
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlConnection cn =
                   OpenConnection())
            using (SqlCommand cmd =
                   TaoLenh(cn, sql, parameters))
            {
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Sinh mã từ SQL Server Sequence.
        ///
        /// Ví dụ:
        /// SinhMa("SEQ_PhieuDat", "DP", 5)
        ///
        /// nếu sequence trả 123:
        /// DP00123
        /// </summary>
        public static string SinhMa(
            string sequence,
            string tienTo,
            int soChuSo)
        {
            /*
             * Oracle cũ:
             *
             * SELECT SEQ_PhieuDat.NEXTVAL
             * FROM dual
             *
             * SQL Server:
             *
             * SELECT NEXT VALUE FOR SEQ_PhieuDat
             */
            if (string.IsNullOrWhiteSpace(sequence))
            {
                throw new ArgumentException(
                    "Tên sequence không được để trống.",
                    nameof(sequence)
                );
            }

            /*
             * sequence là tên object nên không thể truyền bằng
             * SqlParameter.
             *
             * Vì vậy kiểm tra chỉ cho phép:
             * chữ cái, chữ số và dấu _.
             *
             * Tránh SQL Injection.
             */
            if (!Regex.IsMatch(
                    sequence,
                    @"^[A-Za-z_][A-Za-z0-9_]*$"))
            {
                throw new ArgumentException(
                    "Tên sequence không hợp lệ.",
                    nameof(sequence)
                );
            }

            object o =
                Scalar(
                    "SELECT NEXT VALUE FOR " +
                    sequence
                );

            long so =
                Convert.ToInt64(o);

            return tienTo +
                   so.ToString(
                       new string('0', soChuSo)
                   );
        }

        /// <summary>
        /// Chạy nhiều thao tác trong cùng một transaction.
        ///
        /// Nếu toàn bộ thành công:
        /// COMMIT
        ///
        /// Nếu có lỗi:
        /// ROLLBACK
        /// </summary>
        public static void Transaction(
            Action<SqlConnection, SqlTransaction>
                congViec)
        {
            using (SqlConnection cn =
                   OpenConnection())
            using (SqlTransaction tx =
                   cn.BeginTransaction())
            {
                try
                {
                    congViec(cn, tx);

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();

                    throw;
                }
            }
        }

        /// <summary>
        /// INSERT / UPDATE / DELETE
        /// bên trong Transaction(...).
        /// </summary>
        public static int Execute(
            SqlConnection cn,
            SqlTransaction tx,
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlCommand cmd =
                   TaoLenh(cn, sql, parameters))
            {
                cmd.Transaction = tx;

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Query một giá trị
        /// bên trong Transaction(...).
        /// </summary>
        public static object Scalar(
            SqlConnection cn,
            SqlTransaction tx,
            string sql,
            params SqlParameter[] parameters)
        {
            using (SqlCommand cmd =
                   TaoLenh(cn, sql, parameters))
            {
                cmd.Transaction = tx;

                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Gọi Stored Procedure SQL Server.
        ///
        /// Procedure có thể trả về một hoặc nhiều
        /// SELECT result set.
        ///
        /// Các result set sẽ được SqlDataAdapter
        /// đưa vào DataSet.
        /// </summary>
        public static DataSet ExecProc(
            string name,
            params SqlParameter[] parameters)
        {
            using (SqlConnection cn =
                   OpenConnection())
            using (SqlCommand cmd =
                   new SqlCommand(name, cn))
            using (SqlDataAdapter da =
                   new SqlDataAdapter(cmd))
            {
                cmd.CommandType =
                    CommandType.StoredProcedure;

                if (parameters != null &&
                    parameters.Length > 0)
                {
                    cmd.Parameters
                        .AddRange(parameters);
                }

                DataSet ds =
                    new DataSet();

                da.Fill(ds);

                foreach (DataTable table
                         in ds.Tables)
                {
                    ChuanHoaTenCot(
                        table,
                        null
                    );
                }

                return ds;
            }
        }

        /// <summary>
        /// Lấy result set cuối cùng
        /// của Stored Procedure.
        /// </summary>
        public static DataTable ExecProcLast(
            string name,
            params SqlParameter[] parameters)
        {
            DataSet ds =
                ExecProc(
                    name,
                    parameters
                );

            if (ds.Tables.Count > 0)
            {
                return ds.Tables[
                    ds.Tables.Count - 1
                ];
            }

            return new DataTable();
        }

        /// <summary>
        /// Chuẩn hóa tên cột để tương thích
        /// với code cũ.
        ///
        /// Với SQL Server phần này thường
        /// không còn thực sự cần thiết vì
        /// SQL Server giữ nguyên tên cột.
        /// </summary>
        private static void ChuanHoaTenCot(
            DataTable table,
            string sql)
        {
            Dictionary<string, string>
                trongCau =
                    sql == null
                        ? null
                        : TaoTuDien(sql);

            foreach (DataColumn c
                     in table.Columns)
            {
                string ten;

                if (trongCau != null &&
                    trongCau.TryGetValue(
                        c.ColumnName,
                        out ten))
                {
                    c.ColumnName = ten;
                }
                else if (
                    _tenChuan.TryGetValue(
                        c.ColumnName,
                        out ten))
                {
                    c.ColumnName = ten;
                }
            }
        }

        /// <summary>
        /// Tạo dictionary tên định danh chuẩn.
        /// </summary>
        private static Dictionary<string, string>
            TaoTuDien(string text)
        {
            Dictionary<string, string> d =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase
                );

            foreach (Match m
                     in _dinhDanh.Matches(text))
            {
                string w =
                    m.Value;

                /*
                 * Chỉ nhận tên dạng PascalCase /
                 * camelCase có cả chữ hoa và
                 * chữ thường.
                 */
                if (w.ToUpperInvariant() != w &&
                    w.ToLowerInvariant() != w &&
                    !d.ContainsKey(w))
                {
                    d[w] = w;
                }
            }

            return d;
        }
    }
}