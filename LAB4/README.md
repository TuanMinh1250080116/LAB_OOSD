# LAB 4 - e-SHOPPING

**Sinh viên:** Trần Tuấn Minh - 1250080116

Bài này dùng `LAB4.docx` làm bản thiết kế và `Eshopping.sql` làm dữ liệu. Ứng dụng trong `EShopping.WinForms` là Windows Forms trên .NET 9, kết nối SQL Server LocalDB `(localdb)\MSSQLLocalDB` tới database `EShopping_LAB4`.

## Các giao diện đã làm

| Hình trong báo cáo | Màn hình | Nội dung |
| --- | --- | --- |
| UI01 | Tra cứu sản phẩm | Nhóm, từ khóa, sản phẩm, giá; tìm và xem chi tiết từ database |
| UI02 | Giỏ hàng | Mã sản phẩm, số lượng, đơn giá, thành tiền; hiển thị giỏ mẫu và tính tổng |
| UI03 | Đăng ký và đăng nhập | Họ tên, email, tên đăng nhập, mật khẩu |
| UI04 | Đặt hàng | Người nhận, địa chỉ, tỉnh, loại phiếu, phí giao; tính phí bằng hàm SQL |
| UI05 | Thanh toán | Loại thẻ, thông tin thẻ, tổng thanh toán |
| UI06 | Tra cứu đơn hàng | Mã đơn, ngày đặt, trạng thái, tổng trị giá; tìm và xem chi tiết đơn mẫu |

Đây là bài **thiết kế giao diện**. Các nút tạo tài khoản, thay đổi giỏ, thêm hàng và xác nhận thanh toán được hiển thị nhưng vô hiệu hóa. Ứng dụng chỉ đọc dữ liệu, tính phí giao và chuyển giữa các màn hình; không tạo đơn hay thu tiền. Ô thông tin thẻ chỉ để minh họa, không nhập dữ liệu thẻ thật.

## Chuẩn bị database

Cần có .NET SDK 9, SQL Server LocalDB và `sqlcmd`. Chạy PowerShell từ thư mục `LAB4`:

```powershell
SqlLocalDB start MSSQLLocalDB
sqlcmd -S '(localdb)\MSSQLLocalDB' -E -Q "CREATE DATABASE EShopping_LAB4"
sqlcmd -b -I -S '(localdb)\MSSQLLocalDB' -E -d EShopping_LAB4 -i .\Eshopping.sql -f 65001
```

Chỉ tạo database nếu chưa có. `Eshopping.sql` xóa rồi tạo lại 18 bảng cùng dữ liệu mẫu **trong database được chọn**; chạy lại sẽ mất dữ liệu đã có trong database đó. Trên máy thực hiện bài, database `EShopping_LAB4` đã được tạo và nạp thành công: 5 nhóm, 16 sản phẩm, 2 khách hàng, 2 đơn và 12 mức phí giao.

## Chạy ứng dụng

```powershell
dotnet restore .\EShopping.WinForms\EShopping.WinForms.csproj
dotnet run --project .\EShopping.WinForms\EShopping.WinForms.csproj
```

Có thể mở `EShopping.WinForms.csproj` bằng Visual Studio và chạy F5. Chuỗi kết nối nằm trong `ShopRepository.cs` nếu muốn dùng tên instance hoặc database khác. Khi chưa kết nối được LocalDB, giao diện sẽ hiện thông báo lỗi kèm chi tiết.
