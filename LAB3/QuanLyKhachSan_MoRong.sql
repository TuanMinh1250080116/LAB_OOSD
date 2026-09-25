-- =====================================================================
-- MODULE MỞ RỘNG – SQL SERVER
-- KHÔNG THUỘC PHẠM VI ĐỀ BÀI 3
-- Chạy SAU QuanLyKhachSan_SQLServer.sql.
-- Mặc định sử dụng schema dbo.
-- =====================================================================

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

-- Xóa các bảng mở rộng theo thứ tự ngược phụ thuộc khóa ngoại.
DROP TABLE IF EXISTS dbo.ChiTietKiemTraTienNghi;
DROP TABLE IF EXISTS dbo.PhieuKiemTraTienNghi;
DROP TABLE IF EXISTS dbo.GiaoDichCoc;
DROP TABLE IF EXISTS dbo.LichSuGiaPhong;
DROP TABLE IF EXISTS dbo.TaiKhoan;
GO

-- ---------------------------------------------------------------------
-- Module 1: Đăng nhập và phân quyền
-- Đề chỉ nói nhân viên thao tác trên hệ thống, không yêu cầu đăng nhập.
-- Khi cần phân quyền theo vai trò (lễ tân, phục vụ, thanh toán, quản lý)
-- thì dùng bảng này thay vì mở tất cả chức năng cho mọi người.
-- ---------------------------------------------------------------------
CREATE TABLE dbo.TaiKhoan (
    TenDangNhap      VARCHAR(50)  NOT NULL,
    MaNV             VARCHAR(20)  NOT NULL,
    MatKhauHash      VARBINARY(32)       NOT NULL,
    MatKhauSalt      VARBINARY(16)       NOT NULL,
    TrangThai        VARCHAR(10)  DEFAULT 'HoatDong' NOT NULL,
    SoLanSaiLienTiep SMALLINT     DEFAULT 0 NOT NULL,
    LanDangNhapCuoi  DATETIME2(0),
    CONSTRAINT PK_TaiKhoan PRIMARY KEY (TenDangNhap),
    CONSTRAINT UQ_TaiKhoan_NV UNIQUE (MaNV),
    CONSTRAINT FK_TaiKhoan_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT CK_TaiKhoan_TrangThai CHECK (TrangThai IN ('HoatDong', 'TamKhoa'))
);

-- ---------------------------------------------------------------------
-- Module 2: Lịch sử giá phòng (giá theo mùa / theo đợt)
-- Hiện tại Phong.DonGiaNgay là giá hiện hành và ChiTietDatPhong.DonGiaApDung
-- đã chốt giá lúc đặt, nên module này chỉ cần khi khách sạn muốn quản lý
-- bảng giá theo thời gian và tra lại lịch sử thay đổi.
-- ---------------------------------------------------------------------
CREATE TABLE dbo.LichSuGiaPhong (
    Id         INT IDENTITY(1,1),
    SoPhong    VARCHAR(20) NOT NULL,
    TuNgay     DATETIME2(0)         NOT NULL,
    DenNgay    DATETIME2(0),
    DonGiaNgay DECIMAL(18,2) NOT NULL,
    CONSTRAINT PK_LichSuGiaPhong PRIMARY KEY (Id),
    CONSTRAINT FK_LSGia_Phong FOREIGN KEY (SoPhong) REFERENCES dbo.Phong(SoPhong),
    CONSTRAINT CK_LSGia_Ngay CHECK (DenNgay IS NULL OR DenNgay >= TuNgay),
    CONSTRAINT CK_LSGia_DonGia CHECK (DonGiaNgay >= 0)
);

-- ---------------------------------------------------------------------
-- Module 3: Giao dịch tiền cọc
-- Đề chỉ ghi số tiền cọc trên phiếu đặt, không nói cách hoàn/trừ cọc.
-- Bảng này để theo dõi thu cọc, trừ cọc vào hóa đơn và hoàn cọc khi trả phòng.
-- ---------------------------------------------------------------------
CREATE TABLE dbo.GiaoDichCoc (
    Id         INT IDENTITY(1,1),
    SoPhieuDat VARCHAR(30)  NOT NULL,
    NgayGD     DATETIME2(0)          NOT NULL,
    LoaiGD     NVARCHAR(20) NOT NULL,
    SoTien     DECIMAL(18,2)  NOT NULL,
    GhiChu     NVARCHAR(250),
    CONSTRAINT PK_GiaoDichCoc PRIMARY KEY (Id),
    CONSTRAINT FK_GDCoc_PhieuDat FOREIGN KEY (SoPhieuDat) REFERENCES dbo.PhieuDatPhong(SoPhieuDat),
    CONSTRAINT CK_GDCoc_Loai CHECK (LoaiGD IN (N'Thu cọc', N'Trừ vào hóa đơn', N'Hoàn cọc', N'Mất cọc')),
    CONSTRAINT CK_GDCoc_SoTien CHECK (SoTien > 0)
);

-- ---------------------------------------------------------------------
-- Module 4: Biên bản kiểm tra tiện nghi khi trả phòng
-- Hiện tại chỉ lưu khi có hư hỏng (PhieuDenBu). Module này lưu cả các lần
-- kiểm tra không phát sinh đền bù, phục vụ đối chiếu tài sản sau này.
-- ---------------------------------------------------------------------
CREATE TABLE dbo.PhieuKiemTraTienNghi (
    SoPhieuKT  VARCHAR(30) NOT NULL,
    SoPhieuDat VARCHAR(30) NOT NULL,
    SoPhong    VARCHAR(20) NOT NULL,
    NgayKiemTra DATETIME2(0)        NOT NULL,
    MaNV       VARCHAR(20) NOT NULL,
    KetLuan    NVARCHAR(250),
    CONSTRAINT PK_PhieuKiemTra PRIMARY KEY (SoPhieuKT),
    CONSTRAINT FK_PhieuKT_CTDat FOREIGN KEY (SoPhieuDat, SoPhong)
        REFERENCES dbo.ChiTietDatPhong(SoPhieuDat, SoPhong),
    CONSTRAINT FK_PhieuKT_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)
);

CREATE TABLE dbo.ChiTietKiemTraTienNghi (
    SoPhieuKT  VARCHAR(30)  NOT NULL,
    MaTienNghi VARCHAR(30)  NOT NULL,
    TinhTrang  NVARCHAR(100) NOT NULL,
    CoHuHong   BIT     DEFAULT 0 NOT NULL,
    CONSTRAINT PK_CTKiemTra PRIMARY KEY (SoPhieuKT, MaTienNghi),
    CONSTRAINT FK_CTKT_Phieu FOREIGN KEY (SoPhieuKT) REFERENCES dbo.PhieuKiemTraTienNghi(SoPhieuKT),
    CONSTRAINT FK_CTKT_TienNghi FOREIGN KEY (MaTienNghi) REFERENCES dbo.TienNghi(MaTienNghi),
    CONSTRAINT CK_CTKT_CoHuHong CHECK (CoHuHong IN (0, 1))
);

-- SQL Server chạy autocommit mặc định; không cần COMMIT khi không mở transaction.

SELECT [name] AS table_name
FROM sys.tables
WHERE schema_id = SCHEMA_ID('dbo')
  AND [name] IN ('TaiKhoan','LichSuGiaPhong','GiaoDichCoc','PhieuKiemTraTienNghi','ChiTietKiemTraTienNghi')
ORDER BY [name];
