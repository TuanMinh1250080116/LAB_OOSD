<p align="center">
  <b>TRƯỜNG ĐẠI HỌC TÀI NGUYÊN VÀ MÔI TRƯỜNG TP.HCM (HCMUNRE)</b><br/>
  Thực hành Phương pháp phát triển phần mềm hướng đối tượng
</p>

# Bài 6: Quản lý công ty du lịch (bản 3)

## Giới thiệu

* Bài thực hành số 6 của môn Phân tích thiết kế hướng đối tượng.
* Bản này trình bày đúng theo mẫu bài làm của đề: trả lời lần lượt **Câu 1 → Câu 6**, sau đó mới tới phần mở rộng
  (trạng thái, lớp chi tiết, ERD, ràng buộc) và phần cài đặt.
* Sơ đồ vẽ bằng PlantUML theo màu kiểu StarUML (đề yêu cầu StarUML nhưng em dùng PlantUML để sinh ảnh cho nhanh).
* Báo cáo chi tiết xem trong file `BaoCao_QuanLyDuLich_PhienBan3.docx`.

### Sinh viên thực hiện

| **STT** | **MSSV** | **Họ và tên** |
|---|---|---|
| 1 | 1250080116 | Trần Tuấn Minh |

## Điểm riêng của bản này

| Phần | Cách làm |
|---|---|
| Use case tổng quát | Chia theo 4 phân hệ: Tour, Bán hàng, Điều hành, Kế toán |
| Câu 4 | Dùng tổng quát hóa use case: *Đăng ký tour* → *theo đoàn* / *theo chuyến* |
| Câu 5 | Activity chia theo giai đoạn (partition), có vòng lặp chọn lại chuyến |
| Câu 6 | System Sequence Diagram (hệ thống là hộp đen) + sequence kết thúc tour |
| Trạng thái | ChuyenDi (có entry/do) và Tour |
| Thiết kế | Sơ đồ thành phần / triển khai + lớp chi tiết mô-đun bán vé |
| ERD | Ký hiệu Chen, có thực thể yếu `NGUOI_DI_CUNG` |

## Chạy thử project

### Yêu cầu
* Visual Studio 2022
* .NET Framework 4.7.2
* Oracle Database 19c + ODP.NET Managed (`Oracle.ManagedDataAccess`)

### Bước 1: Khởi tạo database
* Tạo user `DULICH` rồi chạy file `../QuanLyDuLich.sql` (đặt `NLS_LANG=AMERICAN_AMERICA.AL32UTF8` trước khi chạy).

### Bước 2: Cấu hình kết nối
* Sao chép `App.config.example` thành `App.config`, sửa `Password=` cho đúng.

### Bước 3: Chạy chương trình
* Mở `../QuanLyDuLich/QuanLyDuLich.sln` trong Visual Studio
* Nhấn F5. Màn hình chính báo "Đã kết nối Oracle" là thành công.

## Kết quả kiểm thử
Chạy `QuanLyDuLich.exe /kiemthu ketqua.txt`: 30/30 ca đạt (gồm cả các ca phải bị từ chối như đoàn 12 người,
cọc dưới 30%, bán vượt số chỗ, phân công trùng lịch).
