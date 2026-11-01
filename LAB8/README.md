# LAB 8 - Cửa hàng nước giải khát

**Sinh viên:** Trần Tuấn Minh  
**MSSV:** 1250080116

## Công nghệ

- Windows Forms trên .NET 9.
- SQL Server LocalDB, instance `(localdb)\MSSQLLocalDB`.
- T-SQL trong `CuaHangNuocGiaiKhat.sql`; ứng dụng dùng `Microsoft.Data.SqlClient` để đọc dữ liệu.

## Đã làm

- Tạo database `LAB8_NuocGiaiKhat` với 14 bảng theo mục 5.2 của `LAB8.docx`, khóa chính, khóa ngoại, CHECK và UNIQUE. Hai view `V_TonKho`, `V_HoaDonTong` tính tồn và tiền hóa đơn từ dữ liệu chứng từ.
- Nạp dữ liệu mẫu theo ví dụ trong báo cáo: DDH001 đặt 100 lon, PGH001 nhận 80, HD001 bán 100 và giao ngay 80, PH001 hẹn 20, PGN001 ghi nợ ban đầu 600.000 đồng.
- Tạo 6 màn hình WinForms theo F01–F06: danh mục, lập đơn đặt hàng, tiếp nhận hàng, bán/giao hẹn, ghi nợ, tra cứu/thống kê.
- Đọc danh mục, dòng đơn, lượng đã nhận/còn nhận, tồn kho, tổng hóa đơn và danh sách tra cứu trực tiếp từ LocalDB.

Giống phạm vi bài WinForms LAB4, đây là **phần giao diện và dữ liệu minh họa**. Các nút thêm, lưu, xóa, xác nhận giao và in được đặt đúng màn hình nhưng vô hiệu hóa. Chưa có xử lý ghi chứng từ hay giao dịch nghiệp vụ. Các ràng buộc liên chứng từ như tối đa 3 đợt nhập, không nhận vượt đơn, không giao âm tồn cần được kiểm tra trong dịch vụ giao dịch nếu triển khai phần xử lý sau này; các CHECK/FK trong SQL không tự bảo đảm toàn bộ các quy tắc đó.

## Cách chạy

Mở PowerShell ở thư mục `LAB8`, bảo đảm đã cài .NET SDK 9, SQL Server LocalDB và `sqlcmd`:

```powershell
SqlLocalDB start MSSQLLocalDB
sqlcmd -b -I -S '(localdb)\MSSQLLocalDB' -E -i .\CuaHangNuocGiaiKhat.sql -f 65001
dotnet restore .\CuaHangNuocGiaiKhat.WinForms\CuaHangNuocGiaiKhat.WinForms.csproj
dotnet run --project .\CuaHangNuocGiaiKhat.WinForms\CuaHangNuocGiaiKhat.WinForms.csproj
```

Script chỉ tạo database và dữ liệu mẫu nếu chưa có, nên có thể chạy lại mà không xóa dữ liệu. Chuỗi kết nối nằm trong `CuaHangNuocGiaiKhat.WinForms/StoreRepository.cs`.
