# LAB 06 - Quản lý hồ sơ bệnh án

Họ tên: **Trần Tuấn Minh**  
MSSV: **1250080116**

Bài 5: Quản lý hồ sơ bệnh án của bệnh nhân. Em làm ứng dụng Windows Forms bằng C# và lưu dữ liệu trong SQL Server Express LocalDB trên máy.

## Các tệp chính

- `QuanLyBenhAn_SQLServer.sql`: tạo database `QuanLyBenhAn`, 16 bảng, 12 sequence, trigger và dữ liệu mẫu. Chạy lại không xóa dữ liệu đã có.
- `QuanLyBenhAn/QuanLyBenhAn.sln`: mã nguồn ứng dụng WinForms (.NET Framework 4.7.2).
- `BaoCao_LAB06_QuanLyBenhAn.docx`: báo cáo của bài lab.
- `ketqua_kiemthu_sqlserver.txt`: kết quả kiểm thử trên SQL Server Express LocalDB.
- `QuanLyBenhAn.sql`: bản script Oracle cũ, chỉ giữ để tham khảo; ứng dụng hiện dùng SQL Server.

## Cách chạy với SQL Server Express LocalDB

1. Máy cần có SQL Server Express LocalDB (`MSSQLLocalDB`) và Visual Studio với .NET Framework 4.7.2 Developer Pack. Instance này đã có trên máy em.
2. Mở PowerShell trong thư mục `LAB6` và chạy:
   ```powershell
   sqlcmd -S '(localdb)\MSSQLLocalDB' -E -b -f 65001 -i .\QuanLyBenhAn_SQLServer.sql
   ```
   Lệnh dùng Windows Authentication và tạo database `QuanLyBenhAn`. Chỉ chạy với tài khoản có quyền tạo database. Nếu đã có database cùng tên, hãy kiểm tra dữ liệu trước khi chạy script.
3. Mở `QuanLyBenhAn/QuanLyBenhAn.sln` trong Visual Studio, chọn **Build** rồi **Start**. Chuỗi kết nối nằm ở `QuanLyBenhAn/QuanLyBenhAn/App.config`, dùng `(localdb)\MSSQLLocalDB` và Windows Authentication. Nếu dùng instance SQL Server Express tên `SQLEXPRESS`, đổi `Data Source` thành `.\SQLEXPRESS`.

## Thử các chức năng

1. Ở tab **Tra cứu hồ sơ**, nhập `HS0001` để xem dữ liệu mẫu.
2. Vào **Đăng ký & cấp hồ sơ** để thêm bệnh nhân, thu lệ phí và cấp mã hồ sơ. Có thể thu phí năm tiếp theo cho hồ sơ cũ.
3. Dùng **Đặt lịch hẹn** rồi **Khám bệnh** để tạo lượt khám. Khám định kỳ cần đã đóng phí của năm đó và chỉ được đặt một lịch mỗi quý.
4. Ở **Xét nghiệm**, tạo chỉ định và nhập kết quả. Sau đó có thể **Lập toa thuốc**, **Thanh toán & xuất viện** và ghi **Phản ứng thuốc**.
5. Quay lại **Tra cứu hồ sơ** để xem lịch sử khám, toa thuốc, xét nghiệm và phản ứng thuốc.

Các mã mẫu có sẵn: `HS0001`, `BS01`, `XN01`, `T01`.

## Ghi chú

`MainForm.cs` là giao diện, `ClinicService.cs` xử lý nghiệp vụ và `Db.cs` kết nối SQL Server. Mỗi bệnh nhân có một hồ sơ; một hồ sơ có nhiều lượt khám. Bài làm chưa có đăng nhập, phân quyền và màn hình sửa danh mục thuốc/bác sĩ.

Có thể chạy kiểm thử nghiệp vụ bằng `QuanLyBenhAn.exe /kiemthu ketqua.txt` sau khi tạo database. Lệnh này thêm dữ liệu thử vào database, nên chỉ chạy trên database dùng để thử. Nếu cần chuỗi kết nối riêng, đặt biến môi trường `LAB06_CONNECTION` trước khi chạy.

Em đã build bản Release và chạy kiểm thử trên LocalDB của máy: **18/18 ca đạt**. Log nằm trong `ketqua_kiemthu_sqlserver.txt`. Ảnh giao diện trong báo cáo được chụp từ bản Oracle trước khi chuyển cơ sở dữ liệu; kết quả kiểm thử hiện tại là kết quả SQL Server.
