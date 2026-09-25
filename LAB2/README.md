# HỆ THỐNG THƯ VIỆN TRỰC TUYẾN (WinForms .NET 9)

Hệ thống Quản lý và Tra cứu Thư viện Trực tuyến được xây dựng bằng Windows Forms trên nền tảng .NET 9 và Microsoft SQL Server, áp dụng kiến trúc phân lớp hướng đối tượng (OOSD).

---

## 1. Yêu cầu hệ thống (Prerequisites)

* **Hệ điều hành:** Windows 10 / Windows 11.
* **Môi trường phát triển:** [Visual Studio 2022](https://visualstudio.microsoft.com/) (phiên bản 17.12 trở lên có hỗ trợ .NET 9) hoặc [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0).
* **Workload Visual Studio cần cài:** `.NET Desktop Development`.
* **Hệ quản trị CSDL:** SQL Server LocalDB (`MSSQLLocalDB`) hoặc SQL Server Express / Developer.

---

## 2. Cấu trúc dự án

```text
LAB_OOSD/
├── LAB1/                      # Tài liệu phân tích và đặc tả yêu cầu
├── LAB2/
│   ├── script_db_thuvien.sql.txt  # Kịch bản tạo bảng & dữ liệu mẫu CSDL
│   └── ThuVienForm/
│       ├── Models/            # Các lớp thực thể (TaiKhoan, TaiLieuDto,...)
│       ├── Services/          # Tầng xử lý nghiệp vụ (AuthService, TaiLieuService,...)
│       ├── Views/             # Giao diện người dùng WinForms
│       │   ├── FrmDangNhap.cs         # Màn hình đăng nhập
│       │   ├── FrmMain.cs             # Trang chủ điều hướng phân quyền
│       │   ├── FrmTraCuu.cs          # Tìm kiếm & tra cứu tài liệu
│       │   └── FrmDocTrucTuyen.cs     # Trình xem tài liệu trực tuyến (giả lập)
│       ├── Program.cs         # Điểm khởi chạy ứng dụng
│       └── ThuVienForm.csproj # File cấu hình dự án & thư viện
└── .gitignore                 # Cấu hình bỏ qua file biên dịch rác
