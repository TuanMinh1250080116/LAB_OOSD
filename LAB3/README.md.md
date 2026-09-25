# Bài 3 - Hệ thống quản lý khách sạn

Tài liệu mô tả phần cơ sở dữ liệu và ứng dụng đã xây dựng cho đề bài 3.

## 1. Phạm vi

Hệ thống phục vụ một khách sạn, bao gồm:

- quản lý phòng và tiện nghi trong phòng
- đặt phòng, nhận phòng, khai báo người lưu trú
- ghi nhận dịch vụ khách sử dụng trong thời gian ở
- trả phòng: kiểm tra tiện nghi, đền bù nếu hư hỏng, lập hóa đơn và thu tiền
- thống kê cho người quản lý

## 2. Thiết kế cơ sở dữ liệu

Cơ sở dữ liệu đặt trên Oracle 19c, chạy bằng user KHACHSAN.

Nhóm danh mục: NhanVien, KhuVuc, Phong, LoaiTienNghi, TienNghi, DichVu, QuyDinhDenBu.
Nhóm nghiệp vụ: KhachHang, PhieuDatPhong, ChiTietDatPhong, NguoiLuuTru, PhieuLapDat,
PhieuSuDungDV, ChiTietPhieuSuDungDV, PhieuDenBu, ChiTietPhieuDenBu, HoaDon, ThanhToan.

Tổng cộng 18 bảng trong file QuanLyKhachSan.sql.

Một vài điểm khác so với mô hình gốc trong đề:

| Chỗ thay đổi | Lý do |
|---|---|
| Thêm cột DonGiaApDung cho ChiTietDatPhong | giữ nguyên đơn giá tại thời điểm đặt, đổi giá phòng sau này không ảnh hưởng phiếu cũ |
| Tách bảng ThanhToan ra khỏi HoaDon | một hóa đơn có thể thu nhiều lần, nhiều hình thức khác nhau |
| ThanhTien và TongTien để máy tự tính | tránh trường hợp số lượng đổi mà thành tiền quên cập nhật |
| Bảng NguoiLuuTru riêng | một phòng có thể ở nhiều người, phải khai báo đủ CCCD từng người |

Các bảng không nằm trong yêu cầu của đề được để riêng ở QuanLyKhachSan_MoRong.sql, gồm
TaiKhoan, LichSuGiaPhong, GiaoDichCoc, PhieuKiemTraTienNghi, ChiTietKiemTraTienNghi.
Tách ra như vậy để phần nộp bài vẫn đúng đề, còn sau này muốn phát triển thêm thì đã có sẵn.

## 3. Quy tắc nghiệp vụ được cài đặt

- Số thứ tự của tiện nghi không trùng nhau trong cùng một loại.
- Trong một ngày, một thiết bị chỉ được lắp cho một phòng.
- Số người của mỗi phòng trong phiếu đặt không vượt sức chứa của phòng đó.
- Một phòng không được xuất hiện trong hai phiếu đặt có khoảng ngày chồng lên nhau.
- Số người lưu trú khai báo không vượt số người đã đăng ký cho phòng.
- Dịch vụ dùng nhiều lần trong cùng một ngày thì cộng dồn vào phiếu của ngày hôm đó.
- Mỗi phiếu đặt chỉ có một hóa đơn.
- Tổng các lần thanh toán không vượt tổng tiền hóa đơn; đủ tiền thì hóa đơn chuyển sang
  trạng thái đã thanh toán.
- Chỉ được hoàn tất trả phòng khi hóa đơn đã thanh toán đủ.

Các quy tắc này được đặt ở tầng service của ứng dụng, đồng thời có ràng buộc tương ứng
trong cơ sở dữ liệu để dữ liệu vẫn đúng kể cả khi thao tác trực tiếp bằng SQL.

## 4. Ứng dụng

Viết bằng WinForms, .NET Framework 4.7.2, kết nối Oracle qua ODP.NET Managed.
Chia làm ba tầng: Forms gọi Services, Services gọi lớp Db trong thư mục Data.

Danh sách màn hình:

- FrmMain: màn hình chính, mở ra là kiểm tra kết nối cơ sở dữ liệu luôn
- FrmDanhMuc: khu vực, nhân viên, loại tiện nghi, dịch vụ, quy định đền bù
- FrmPhongTienNghi: phòng, tiện nghi, phiếu lắp đặt
- FrmDatPhong: khách hàng, lập phiếu đặt, nhận phòng, người lưu trú
- FrmDichVu: ghi nhận dịch vụ sử dụng
- FrmTraPhong: đền bù, hóa đơn, thanh toán, trả phòng
- FrmThongKe: thống kê theo khoảng thời gian

Ảnh chụp màn hình khi chạy thật nằm trong thư mục assets.

## 5. Chạy thử

Tạo user KHACHSAN, cấp quyền CONNECT và RESOURCE, sau đó chạy hai file sql theo thứ tự
QuanLyKhachSan.sql rồi tới QuanLyKhachSan_MoRong.sql. Nhớ đặt NLS_LANG là
AMERICAN_AMERICA.AL32UTF8 trước khi chạy, không thì tiếng Việt bị lỗi font.

Chuỗi kết nối nằm trong App.config. File này không đưa lên git vì có mật khẩu, thay vào đó
có App.config.example để copy ra rồi tự điền.

## 6. Hạn chế

Phần đăng nhập và phân quyền mới dừng ở mức thiết kế bảng, chưa làm giao diện.
Chức năng sửa và xóa danh mục chưa có. Thống kê mới xuất được tệp CSV.
