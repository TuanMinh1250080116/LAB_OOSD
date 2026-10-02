# LAB 04 – Hệ thống cửa hàng online e-SHOPPING

**Thực hiện:** Trần Tuấn Minh

Dự án thực hiện phân tích, thiết kế hướng đối tượng và triển khai cho đề tài `Bai_9_GOC` (hệ thống cửa hàng ABC bán hàng online mùa Giáng Sinh). Hệ thống sử dụng CSDL Oracle và ứng dụng WinForms kết nối trực tiếp vào CSDL này.

## 1. Cấu trúc thư mục và tập tin

* `BaoCao_LAB04_EShopping.docx`: Báo cáo dự án bao gồm tóm tắt yêu cầu (FR/NFR), tác nhân, quy tắc nghiệp vụ, quyết định triển khai, các sơ đồ UML (use case, phân rã, đặc tả, lớp phân tích/chi tiết, trạng thái, tuần tự), ERD, script SQL, thiết kế giao diện và kết quả kiểm thử.


* `EShopping.sql`: Script khởi tạo Oracle DDL/DML gồm 18 bảng, 7 sequence, hàm `FN_TinhPhiGiao`, các trigger, 2 view và dữ liệu mẫu.


* `EShopping/`: Source code ứng dụng WinForms (.NET Framework 4.7.2, ODP.NET Managed) chứa 8 form, thiết kế theo kiến trúc 4 layer: Forms, Services, Gateways và Data.


* `plantuml/`: Chứa mã nguồn `.puml` và ảnh render PNG của 13 sơ đồ (được ignore khỏi git).


* `_build/`: Các script tự động sinh sơ đồ, form, project và báo cáo (được ignore khỏi git).



## 2. Hướng dẫn triển khai (Deployment)

1. Khởi động các dịch vụ: `OracleServiceORCL` và `OracleOraDB19Home1TNSListener`.


2. Đăng nhập bằng tài khoản DBA để cấp quyền và tạo user:
```sql
CREATE USER ESHOP IDENTIFIED BY <mật_khẩu> DEFAULT TABLESPACE USERS QUOTA UNLIMITED ON USERS;
GRANT CONNECT, RESOURCE, CREATE VIEW, CREATE PROCEDURE, CREATE TRIGGER, CREATE SEQUENCE TO ESHOP;

```


3. Thực thi script SQL (cần set `NLS_LANG` để tránh lỗi encoding tiếng Việt):
```bash
set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
sqlplus ESHOP/<mật_khẩu>@localhost:1521/ORCL @EShopping.sql

```


4. Copy file `EShopping/EShopping/App.config.example` thành `App.config`, cấu hình mật khẩu cho user `ESHOP` (file `App.config` không đẩy lên git).


5. Mở file solution `EShopping/EShopping.sln` bằng Visual Studio 2022 và nhấn F5 để chạy ứng dụng.



## 3. Dữ liệu và môi trường kiểm thử (Testing)

* **Tài khoản hệ thống** (Mật khẩu mặc định: `Eshop@123`):
* User khách hàng: `an.nv`, `binh.tt`.


* User nhân viên: `admin`, `banhang`.




* **Cổng thanh toán giả lập**:
* VISA `4111 1111 1111 1111`: Giao dịch Accept (được chấp thuận).


* VISA `4000 0000 0000 0002`: Giao dịch Deny (bị từ chối do không đủ khả năng thanh toán).


* AmEx: `3782 822463 10005`.




* **Mail Server Local**: Email xác nhận hệ thống gửi đi được dump dưới dạng file `.eml` tại thư mục `bin\Debug\MailPickup`.


* **Command Line Interface (CLI)**:
* Chạy test tự động: `EShopping.exe /kiemthu ketqua.txt` (Thực thi 26 test case end-to-end trên CSDL, sau đó tự động clean up dữ liệu thử).


* Chụp ảnh màn hình: `EShopping.exe /chupanh <thư_mục>` (Tự động capture các form phục vụ làm báo cáo).