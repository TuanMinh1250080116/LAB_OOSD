using System.Data;
using Microsoft.Data.SqlClient;

namespace EShopping.WinForms;

internal sealed class ShopRepository
{
    private const string ConnectionString =
        "Server=(localdb)\\MSSQLLocalDB;Database=EShopping_LAB4;Integrated Security=true;TrustServerCertificate=true;";

    public DataTable Query(string sql, params SqlParameter[] parameters)
    {
        using var connection = new SqlConnection(ConnectionString);
        using var command = new SqlCommand(sql, connection);
        command.Parameters.AddRange(parameters);
        using var adapter = new SqlDataAdapter(command);
        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }

    public DataTable Products(string category, string keyword) => Query(
        "SELECT MaSP, TenSP, TenNhom, GiaBan, TinhTrang, NhaSanXuat, MoTa " +
        "FROM V_SanPham WHERE (@category = '' OR MaNhom = @category) " +
        "AND (@keyword = N'' OR TenSP LIKE N'%' + @keyword + N'%') ORDER BY MaSP",
        new SqlParameter("@category", category), new SqlParameter("@keyword", keyword));

    public DataTable Categories() => Query("SELECT MaNhom, TenNhom FROM NhomSanPham ORDER BY TenNhom");

    public DataTable Cart() => Query(
        "SELECT c.MaSP, s.TenSP, c.SoLuong, s.GiaBan AS DonGia, " +
        "CAST(c.SoLuong AS BIGINT) * s.GiaBan AS ThanhTien " +
        "FROM ChiTietGioHang c JOIN SanPham s ON s.MaSP = c.MaSP " +
        "WHERE c.MaGioHang = 1 ORDER BY c.MaSP");

    public DataTable Cities() => Query("SELECT MaTinh, TenTinh FROM TinhThanh ORDER BY TenTinh");

    public DataTable DeliveryTypes() => Query("SELECT MaLoaiPhieu, TenLoai FROM LoaiPhieuDatHang ORDER BY MaLoaiPhieu");

    public DataTable CardTypes() => Query("SELECT MaLoaiThe, TenLoaiThe FROM LoaiThe ORDER BY TenLoaiThe");

    public DataTable Orders(string orderCode) => Query(
        "SELECT SoDonHang, ThoiDiemDat, TrangThai, TongTriGia, HoTen, TenNguoiNhan, TenTinh, DiaChiNhan " +
        "FROM V_DonHang WHERE (@code = '' OR SoDonHang = @code) ORDER BY ThoiDiemDat DESC",
        new SqlParameter("@code", orderCode));

    public DataTable OrderLines(string orderCode) => Query(
        "SELECT c.MaSP, s.TenSP, c.SoLuong, c.DonGia, c.ThanhTien " +
        "FROM ChiTietDonHang c JOIN SanPham s ON s.MaSP = c.MaSP WHERE c.SoDonHang = @code",
        new SqlParameter("@code", orderCode));

    public long DeliveryFee(string city, string deliveryType, long subtotal)
    {
        var table = Query("SELECT dbo.FN_TinhPhiGiao(@city, @type, @subtotal) AS PhiGiao",
            new SqlParameter("@city", city), new SqlParameter("@type", deliveryType),
            new SqlParameter("@subtotal", subtotal));
        return Convert.ToInt64(table.Rows[0][0]);
    }
}
