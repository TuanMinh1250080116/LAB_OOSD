-- LAB 06 - CSDL cho SQL Server Express.
-- Chay bang sqlcmd -S "(localdb)\MSSQLLocalDB" -E -b -f 65001 -i QuanLyBenhAn_SQLServer.sql
-- Script chi tao bang con thieu, khong xoa du lieu da co.
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO
IF DB_ID(N'QuanLyBenhAn') IS NULL CREATE DATABASE QuanLyBenhAn;
GO
USE QuanLyBenhAn;
GO

IF OBJECT_ID(N'dbo.BenhNhan', N'U') IS NULL
CREATE TABLE dbo.BenhNhan (
  MaBN varchar(12) PRIMARY KEY, HoTen nvarchar(100) NOT NULL,
  DiaChi nvarchar(250) NOT NULL, NgaySinh date NOT NULL,
  DienThoai varchar(15) NOT NULL, Anh3x4 varchar(500) NULL,
  CONSTRAINT CK_BN_DT CHECK (LEN(DienThoai) BETWEEN 9 AND 15 AND DienThoai NOT LIKE '%[^0-9]%')
);
IF OBJECT_ID(N'dbo.PhieuDangKy', N'U') IS NULL
CREATE TABLE dbo.PhieuDangKy (
  MaDK varchar(12) PRIMARY KEY, MaBN varchar(12) NOT NULL REFERENCES dbo.BenhNhan(MaBN),
  NgayDangKy datetime2 NOT NULL DEFAULT GETDATE(), NamApDung int NOT NULL,
  TrangThai varchar(15) NOT NULL DEFAULT 'CHO_THU' CHECK (TrangThai IN ('CHO_THU','DA_THU')),
  CONSTRAINT UQ_DK_BN_NAM UNIQUE (MaBN, NamApDung)
);
IF OBJECT_ID(N'dbo.PhiThu', N'U') IS NULL
CREATE TABLE dbo.PhiThu (
  MaThu varchar(12) PRIMARY KEY, MaDK varchar(12) NOT NULL UNIQUE REFERENCES dbo.PhieuDangKy(MaDK),
  SoTien decimal(12,0) NOT NULL CHECK (SoTien > 0), NgayThu datetime2 NOT NULL DEFAULT GETDATE(),
  LoaiPhi varchar(15) NOT NULL DEFAULT 'HANG_NAM' CHECK (LoaiPhi = 'HANG_NAM')
);
IF OBJECT_ID(N'dbo.HoSoBenhAn', N'U') IS NULL
CREATE TABLE dbo.HoSoBenhAn (
  MaHS varchar(12) PRIMARY KEY, MaBN varchar(12) NOT NULL UNIQUE REFERENCES dbo.BenhNhan(MaBN),
  NgayCap datetime2 NOT NULL DEFAULT GETDATE(),
  TrangThai varchar(15) NOT NULL DEFAULT 'HOAT_DONG' CHECK (TrangThai IN ('HOAT_DONG','NGUNG'))
);
IF OBJECT_ID(N'dbo.Khoa', N'U') IS NULL
CREATE TABLE dbo.Khoa (MaKhoa varchar(10) PRIMARY KEY, TenKhoa nvarchar(100) NOT NULL UNIQUE);
IF OBJECT_ID(N'dbo.BacSi', N'U') IS NULL
CREATE TABLE dbo.BacSi (
  MaBS varchar(10) PRIMARY KEY, HoTen nvarchar(100) NOT NULL,
  MaKhoa varchar(10) NOT NULL REFERENCES dbo.Khoa(MaKhoa)
);
IF OBJECT_ID(N'dbo.LichHen', N'U') IS NULL
CREATE TABLE dbo.LichHen (
  MaHen varchar(12) PRIMARY KEY, MaHS varchar(12) NOT NULL REFERENCES dbo.HoSoBenhAn(MaHS),
  MaBS varchar(10) NULL REFERENCES dbo.BacSi(MaBS), ThoiGian datetime2 NOT NULL,
  LoaiKham varchar(15) NOT NULL CHECK (LoaiKham IN ('DIEU_TRI','DINH_KY')),
  TrangThai varchar(15) NOT NULL DEFAULT 'DA_HEN' CHECK (TrangThai IN ('DA_HEN','DA_DEN','HUY')),
  CONSTRAINT UQ_HEN_BS_GIO UNIQUE (MaBS, ThoiGian)
);
IF OBJECT_ID(N'dbo.LuotKham', N'U') IS NULL
CREATE TABLE dbo.LuotKham (
  MaKham varchar(12) PRIMARY KEY, MaHS varchar(12) NOT NULL REFERENCES dbo.HoSoBenhAn(MaHS),
  MaHen varchar(12) NULL REFERENCES dbo.LichHen(MaHen),
  MaBS varchar(10) NOT NULL REFERENCES dbo.BacSi(MaBS),
  MaKhoa varchar(10) NOT NULL REFERENCES dbo.Khoa(MaKhoa), NgayGio datetime2 NOT NULL DEFAULT GETDATE(),
  LoaiKham varchar(15) NOT NULL CHECK (LoaiKham IN ('DIEU_TRI','DINH_KY')),
  ChanDoan nvarchar(500) NULL, KetLuan nvarchar(1000) NULL,
  TrangThai varchar(20) NOT NULL DEFAULT 'DANG_KHAM'
    CHECK (TrangThai IN ('DANG_KHAM','CHO_XET_NGHIEM','CHO_TOA','CHO_THANH_TOAN','HOAN_TAT')),
  NgayXuatVien datetime2 NULL, VienPhi decimal(12,0) NOT NULL DEFAULT 0 CHECK (VienPhi >= 0),
  DaThanhToan char(1) NOT NULL DEFAULT 'N' CHECK (DaThanhToan IN ('Y','N')),
  CONSTRAINT CK_KHAM_HOANTAT CHECK (TrangThai <> 'HOAN_TAT' OR (NgayXuatVien IS NOT NULL AND DaThanhToan = 'Y'))
);
IF OBJECT_ID(N'dbo.TrieuChung', N'U') IS NULL
CREATE TABLE dbo.TrieuChung (
  MaTrieuChung varchar(12) PRIMARY KEY, MaKham varchar(12) NOT NULL REFERENCES dbo.LuotKham(MaKham),
  MoTa nvarchar(300) NOT NULL, ThanNhiet decimal(4,1) NULL, HuyetAp varchar(20) NULL
);
IF OBJECT_ID(N'dbo.LoaiXetNghiem', N'U') IS NULL
CREATE TABLE dbo.LoaiXetNghiem (MaXN varchar(10) PRIMARY KEY, TenXN nvarchar(100) NOT NULL UNIQUE);
IF OBJECT_ID(N'dbo.ChiDinhXetNghiem', N'U') IS NULL
CREATE TABLE dbo.ChiDinhXetNghiem (
  MaCD varchar(12) PRIMARY KEY, MaKham varchar(12) NOT NULL REFERENCES dbo.LuotKham(MaKham),
  MaXN varchar(10) NOT NULL REFERENCES dbo.LoaiXetNghiem(MaXN),
  MaBS varchar(10) NOT NULL REFERENCES dbo.BacSi(MaBS),
  NgayChiDinh datetime2 NOT NULL DEFAULT GETDATE(),
  TrangThai varchar(15) NOT NULL DEFAULT 'CHO_KQ' CHECK (TrangThai IN ('CHO_KQ','DA_CO_KQ'))
);
IF OBJECT_ID(N'dbo.KetQuaXetNghiem', N'U') IS NULL
CREATE TABLE dbo.KetQuaXetNghiem (
  MaKQ varchar(12) PRIMARY KEY, MaCD varchar(12) NOT NULL UNIQUE REFERENCES dbo.ChiDinhXetNghiem(MaCD),
  KetQua nvarchar(1000) NOT NULL, NgayCoKQ datetime2 NOT NULL DEFAULT GETDATE()
);
IF OBJECT_ID(N'dbo.Thuoc', N'U') IS NULL
CREATE TABLE dbo.Thuoc (
  MaThuoc varchar(10) PRIMARY KEY, TenThuoc nvarchar(100) NOT NULL,
  DonVi nvarchar(30) NOT NULL, HuongDan nvarchar(250) NULL
);
IF OBJECT_ID(N'dbo.ToaThuoc', N'U') IS NULL
CREATE TABLE dbo.ToaThuoc (
  MaToa varchar(12) PRIMARY KEY, MaKham varchar(12) NOT NULL UNIQUE REFERENCES dbo.LuotKham(MaKham),
  MaBS varchar(10) NOT NULL REFERENCES dbo.BacSi(MaBS), NgayKe datetime2 NOT NULL DEFAULT GETDATE(),
  LoiDan nvarchar(500) NULL, TrangThai varchar(15) NOT NULL DEFAULT 'NHAP'
    CHECK (TrangThai IN ('NHAP','DA_KY'))
);
IF OBJECT_ID(N'dbo.ChiTietToa', N'U') IS NULL
CREATE TABLE dbo.ChiTietToa (
  MaCT varchar(12) PRIMARY KEY, MaToa varchar(12) NOT NULL REFERENCES dbo.ToaThuoc(MaToa),
  MaThuoc varchar(10) NOT NULL REFERENCES dbo.Thuoc(MaThuoc),
  SoLuong int NOT NULL CHECK (SoLuong > 0), LieuDung nvarchar(150) NOT NULL,
  SoNgay int NOT NULL CHECK (SoNgay > 0), CONSTRAINT UQ_CT_THUOC UNIQUE (MaToa, MaThuoc)
);
IF OBJECT_ID(N'dbo.PhanUngThuoc', N'U') IS NULL
CREATE TABLE dbo.PhanUngThuoc (
  MaPU varchar(12) PRIMARY KEY, MaHS varchar(12) NOT NULL REFERENCES dbo.HoSoBenhAn(MaHS),
  MaThuoc varchar(10) NOT NULL REFERENCES dbo.Thuoc(MaThuoc),
  NgayGhiNhan datetime2 NOT NULL DEFAULT GETDATE(), MoTa nvarchar(500) NOT NULL,
  MucDo varchar(15) NOT NULL CHECK (MucDo IN ('NHE','VUA','NANG'))
);
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UQ_LUOTKHAM_MAHEN' AND object_id = OBJECT_ID(N'dbo.LuotKham'))
  CREATE UNIQUE INDEX UQ_LUOTKHAM_MAHEN ON dbo.LuotKham(MaHen) WHERE MaHen IS NOT NULL;
GO

IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_BN') EXEC('CREATE SEQUENCE dbo.SEQ_BN START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_DK') EXEC('CREATE SEQUENCE dbo.SEQ_DK START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_HS') EXEC('CREATE SEQUENCE dbo.SEQ_HS START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_THU') EXEC('CREATE SEQUENCE dbo.SEQ_THU START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_HEN') EXEC('CREATE SEQUENCE dbo.SEQ_HEN START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_KHAM') EXEC('CREATE SEQUENCE dbo.SEQ_KHAM START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_TRIEU') EXEC('CREATE SEQUENCE dbo.SEQ_TRIEU START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_CD') EXEC('CREATE SEQUENCE dbo.SEQ_CD START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_KQ') EXEC('CREATE SEQUENCE dbo.SEQ_KQ START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_TOA') EXEC('CREATE SEQUENCE dbo.SEQ_TOA START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_CT') EXEC('CREATE SEQUENCE dbo.SEQ_CT START WITH 10 INCREMENT BY 1');
IF NOT EXISTS (SELECT 1 FROM sys.sequences WHERE name = 'SEQ_PU') EXEC('CREATE SEQUENCE dbo.SEQ_PU START WITH 10 INCREMENT BY 1');
GO

CREATE OR ALTER TRIGGER dbo.TRG_THU_DANGKY ON dbo.PhiThu AFTER INSERT AS
BEGIN
  SET NOCOUNT ON;
  UPDATE d SET TrangThai = 'DA_THU'
  FROM dbo.PhieuDangKy d JOIN inserted i ON i.MaDK = d.MaDK;
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Khoa WHERE MaKhoa = 'K01') INSERT dbo.Khoa VALUES ('K01', N'Nội tổng quát');
IF NOT EXISTS (SELECT 1 FROM dbo.Khoa WHERE MaKhoa = 'K02') INSERT dbo.Khoa VALUES ('K02', N'Tim mạch');
IF NOT EXISTS (SELECT 1 FROM dbo.BacSi WHERE MaBS = 'BS01') INSERT dbo.BacSi VALUES ('BS01', N'Nguyễn Minh An', 'K01');
IF NOT EXISTS (SELECT 1 FROM dbo.BacSi WHERE MaBS = 'BS02') INSERT dbo.BacSi VALUES ('BS02', N'Trần Thị Bình', 'K02');
IF NOT EXISTS (SELECT 1 FROM dbo.LoaiXetNghiem WHERE MaXN = 'XN01') INSERT dbo.LoaiXetNghiem VALUES ('XN01', N'Công thức máu');
IF NOT EXISTS (SELECT 1 FROM dbo.LoaiXetNghiem WHERE MaXN = 'XN02') INSERT dbo.LoaiXetNghiem VALUES ('XN02', N'Đường huyết');
IF NOT EXISTS (SELECT 1 FROM dbo.Thuoc WHERE MaThuoc = 'T01') INSERT dbo.Thuoc VALUES ('T01', N'Paracetamol 500mg', N'viên', N'Uống sau ăn');
IF NOT EXISTS (SELECT 1 FROM dbo.Thuoc WHERE MaThuoc = 'T02') INSERT dbo.Thuoc VALUES ('T02', N'Vitamin C 500mg', N'viên', N'Uống sau ăn');
IF NOT EXISTS (SELECT 1 FROM dbo.BenhNhan WHERE MaBN = 'BN0001')
  INSERT dbo.BenhNhan VALUES ('BN0001', N'Nguyễn Văn Minh', N'Quận 1, TP.HCM', DATEFROMPARTS(1990,5,12), '0901234567', NULL);
IF NOT EXISTS (SELECT 1 FROM dbo.PhieuDangKy WHERE MaDK = 'DK0001')
  INSERT dbo.PhieuDangKy (MaDK, MaBN, NamApDung) VALUES ('DK0001', 'BN0001', YEAR(GETDATE()));
IF NOT EXISTS (SELECT 1 FROM dbo.PhiThu WHERE MaThu = 'TH0001')
  INSERT dbo.PhiThu (MaThu, MaDK, SoTien) VALUES ('TH0001', 'DK0001', 300000);
IF NOT EXISTS (SELECT 1 FROM dbo.HoSoBenhAn WHERE MaHS = 'HS0001')
  INSERT dbo.HoSoBenhAn (MaHS, MaBN) VALUES ('HS0001', 'BN0001');
PRINT N'Đã tạo hoặc kiểm tra CSDL QuanLyBenhAn và dữ liệu mẫu.';
