using System.Data;
using Microsoft.Data.SqlClient;

namespace CuaHangNuocGiaiKhat.WinForms;

internal sealed class StoreRepository
{
    private const string ConnectionString =
        "Server=(localdb)\\MSSQLLocalDB;Database=LAB8_NuocGiaiKhat;Integrated Security=true;TrustServerCertificate=true;";

    private DataTable Query(string sql, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(ConnectionString);
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters);
        using var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public DataTable Suppliers() => Query("SELECT MaNCU, TenNCU FROM NhaCungUng ORDER BY MaNCU");
    public DataTable Types() => Query("SELECT MaLoai, TenLoai FROM LoaiNGK ORDER BY MaLoai");
    public DataTable Customers() => Query("SELECT MaKH, HoTen, LoaiKhach FROM KhachHang ORDER BY MaKH");
    public DataTable PurchaseOrders() => Query("SELECT MaDDH FROM DonDatHang ORDER BY MaDDH");
    public DataTable Invoices() => Query("SELECT MaHD FROM HoaDon ORDER BY MaHD");
    public DataTable Appointments() => Query("SELECT MaPH, TrangThai FROM PhieuHen ORDER BY MaPH");

    public DataTable Catalog(string group, string keyword)
    {
        var sql = group switch
        {
            "Nhà cung ứng" => "SELECT MaNCU AS Ma, TenNCU AS Ten, DiaChi, DienThoai FROM NhaCungUng",
            "Loại nước" => "SELECT l.MaLoai AS Ma, l.TenLoai AS Ten, l.MaNCU, n.TenNCU FROM LoaiNGK l JOIN NhaCungUng n ON n.MaNCU=l.MaNCU",
            "Khách hàng" => "SELECT MaKH AS Ma, HoTen AS Ten, LoaiKhach, DiaChi, DienThoai FROM KhachHang",
            "Nhân viên" => "SELECT MaNV AS Ma, HoTen AS Ten FROM NhanVien",
            _ => "SELECT g.MaNGK AS Ma, g.TenNGK AS Ten, g.DonViTinh, g.MaLoai, l.TenLoai FROM NuocGiaiKhat g JOIN LoaiNGK l ON l.MaLoai=g.MaLoai"
        };
        return Query($"SELECT * FROM ({sql}) AS x WHERE @term = N'' OR Ma LIKE '%' + @term + '%' OR Ten LIKE N'%' + @term + N'%' ORDER BY Ma",
            new SqlParameter("@term", keyword));
    }

    public DataTable PurchaseLines(string order) => Query(
        "SELECT c.MaNGK, g.TenNGK, c.SoLuongDat FROM CTDonDatHang c " +
        "JOIN NuocGiaiKhat g ON g.MaNGK=c.MaNGK WHERE c.MaDDH=@order ORDER BY c.MaNGK",
        new SqlParameter("@order", order));

    public DataTable ReceiptLines(string order) => Query(
        "SELECT c.MaNGK, g.TenNGK, c.SoLuongDat, COALESCE(r.DaNhan,0) AS DaNhan, " +
        "c.SoLuongDat-COALESCE(r.DaNhan,0) AS ConNhan FROM CTDonDatHang c " +
        "JOIN NuocGiaiKhat g ON g.MaNGK=c.MaNGK " +
        "OUTER APPLY (SELECT SUM(x.SoLuongGiao) AS DaNhan FROM CTPhieuGiaoHang x " +
        "WHERE x.MaDDH=c.MaDDH AND x.MaNGK=c.MaNGK) r WHERE c.MaDDH=@order ORDER BY c.MaNGK",
        new SqlParameter("@order", order));

    public int ReceiptRounds(string order) => Convert.ToInt32(Query(
        "SELECT COUNT(*) AS SoDot FROM PhieuGiaoHang WHERE MaDDH=@order",
        new SqlParameter("@order", order)).Rows[0][0]);

    public DataTable InvoiceLines(string invoice) => Query(
        "SELECT c.MaNGK, g.TenNGK, c.SoLuongMua, c.DonGiaBan, c.SoLuongGiaoNgay, " +
        "c.SoLuongMua-c.SoLuongGiaoNgay AS ConGiao, t.SoLuongTon " +
        "FROM CTHoaDon c JOIN NuocGiaiKhat g ON g.MaNGK=c.MaNGK " +
        "JOIN V_TonKho t ON t.MaNGK=c.MaNGK WHERE c.MaHD=@invoice ORDER BY c.MaNGK",
        new SqlParameter("@invoice", invoice));

    public DataTable DebtForInvoice(string invoice) => Query(
        "SELECT h.MaHD, k.MaKH, k.HoTen, k.LoaiKhach, h.TongTien, h.SoTienDaTra, h.ConNo " +
        "FROM V_HoaDonTong h JOIN KhachHang k ON k.MaKH=h.MaKH WHERE h.MaHD=@invoice",
        new SqlParameter("@invoice", invoice));

    public DataTable Search(string kind, DateTime from, DateTime to, string term, string status)
    {
        var sql = kind switch
        {
            "Phiếu hẹn" => "SELECT p.MaPH AS Ma, p.NgayHen AS Ngay, h.MaKH AS Khach, p.TrangThai, " +
                "SUM(c.SoLuongHen) AS SoLuong FROM PhieuHen p JOIN HoaDon h ON h.MaHD=p.MaHD " +
                "JOIN CTPhieuHen c ON c.MaPH=p.MaPH WHERE p.NgayHen BETWEEN @from AND @to " +
                "AND (@term='' OR p.MaPH=@term OR h.MaKH=@term) " +
                "AND (@status='' OR p.TrangThai=@status) GROUP BY p.MaPH,p.NgayHen,h.MaKH,p.TrangThai ORDER BY p.NgayHen",
            "Phiếu ghi nợ" => "SELECT n.MaPGN AS Ma, n.NgayLap AS Ngay, h.MaKH AS Khach, " +
                "n.SoTienNo, n.NgayDuKienTra FROM PhieuGhiNo n JOIN HoaDon h ON h.MaHD=n.MaHD " +
                "WHERE n.NgayLap BETWEEN @from AND @to AND (@term='' OR n.MaPGN=@term OR h.MaKH=@term) ORDER BY n.NgayLap",
            "Nhập hàng" => "SELECT p.MaPGH AS Ma, p.NgayGiao AS Ngay, p.MaDDH, " +
                "p.SoTienPhaiTra FROM PhieuGiaoHang p WHERE p.NgayGiao BETWEEN @from AND @to " +
                "AND (@term='' OR p.MaPGH=@term OR p.MaDDH=@term) ORDER BY p.NgayGiao",
            "Tồn kho" => "SELECT MaNGK AS Ma, TenNGK, DonViTinh, SoLuongTon " +
                "FROM V_TonKho WHERE @term='' OR MaNGK=@term ORDER BY MaNGK",
            _ => "SELECT h.MaHD AS Ma, h.NgayLap AS Ngay, h.MaKH AS Khach, h.TongTien, " +
                "h.SoTienDaTra, h.ConNo FROM V_HoaDonTong h WHERE h.NgayLap BETWEEN @from AND @to " +
                "AND (@term='' OR h.MaHD=@term OR h.MaKH=@term) ORDER BY h.NgayLap"
        };
        return Query(sql, new SqlParameter("@from", from.Date), new SqlParameter("@to", to.Date),
            new SqlParameter("@term", term), new SqlParameter("@status", status));
    }
}
