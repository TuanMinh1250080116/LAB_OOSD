-- =====================================================================
-- HỆ THỐNG QUẢN LÝ KHÁCH SẠN – SQL SERVER
-- Phiên bản chuyển đổi từ script Oracle 19c sang T-SQL.
-- Chạy file này trước file QuanLyKhachSan_MoRong_SQLServer.sql.
-- Mặc định sử dụng schema dbo.
-- =====================================================================

SET NOCOUNT ON;
SET XACT_ABORT ON;
GO

PRINT N'[1/4] XÓA OBJECT CŨ...';
GO

-- Xóa bảng theo thứ tự ngược phụ thuộc khóa ngoại.
DROP TABLE IF EXISTS dbo.ThanhToan;
DROP TABLE IF EXISTS dbo.HoaDon;
DROP TABLE IF EXISTS dbo.ChiTietPhieuDenBu;
DROP TABLE IF EXISTS dbo.PhieuDenBu;
DROP TABLE IF EXISTS dbo.QuyDinhDenBu;
DROP TABLE IF EXISTS dbo.ChiTietPhieuSuDungDV;
DROP TABLE IF EXISTS dbo.PhieuSuDungDV;
DROP TABLE IF EXISTS dbo.DichVu;
DROP TABLE IF EXISTS dbo.NguoiLuuTru;
DROP TABLE IF EXISTS dbo.ChiTietDatPhong;
DROP TABLE IF EXISTS dbo.PhieuDatPhong;
DROP TABLE IF EXISTS dbo.KhachHang;
DROP TABLE IF EXISTS dbo.PhieuLapDat;
DROP TABLE IF EXISTS dbo.TienNghi;
DROP TABLE IF EXISTS dbo.LoaiTienNghi;
DROP TABLE IF EXISTS dbo.Phong;
DROP TABLE IF EXISTS dbo.KhuVuc;
DROP TABLE IF EXISTS dbo.NhanVien;

-- Xóa sequence cũ.
DROP SEQUENCE IF EXISTS dbo.SEQ_KhachHang;
DROP SEQUENCE IF EXISTS dbo.SEQ_PhieuLapDat;
DROP SEQUENCE IF EXISTS dbo.SEQ_PhieuDat;
DROP SEQUENCE IF EXISTS dbo.SEQ_PhieuSDDV;
DROP SEQUENCE IF EXISTS dbo.SEQ_PhieuDenBu;
DROP SEQUENCE IF EXISTS dbo.SEQ_HoaDon;
DROP SEQUENCE IF EXISTS dbo.SEQ_ThanhToan;
GO

PRINT N'[2/4] TẠO BẢNG...';
GO

-- =====================================================================

-- 1. DANH MỤC NỀN

-- =====================================================================

CREATE TABLE dbo.NhanVien (

    MaNV        VARCHAR(20)   NOT NULL,

    HoTen       NVARCHAR(120) NOT NULL,

    VaiTro      NVARCHAR(50)  NOT NULL,

    SoDienThoai VARCHAR(20),

    CONSTRAINT PK_NhanVien PRIMARY KEY (MaNV)

);

CREATE TABLE dbo.KhuVuc (

    MaKhuVuc  VARCHAR(20)   NOT NULL,

    TenKhuVuc NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_KhuVuc PRIMARY KEY (MaKhuVuc),

    CONSTRAINT UQ_KhuVuc_Ten UNIQUE (TenKhuVuc)

);

-- BR01, BR02: phòng thuộc một khu vực, có sức chứa và đơn giá theo ngày

CREATE TABLE dbo.Phong (

    SoPhong      VARCHAR(20)  NOT NULL,

    MaKhuVuc     VARCHAR(20)  NOT NULL,

    SoNguoiToiDa INT    NOT NULL,

    DonGiaNgay   DECIMAL(18,2)  NOT NULL,

    TrangThai    NVARCHAR(30) DEFAULT N'Trống' NOT NULL,

    CONSTRAINT PK_Phong PRIMARY KEY (SoPhong),

    CONSTRAINT FK_Phong_KhuVuc FOREIGN KEY (MaKhuVuc) REFERENCES dbo.KhuVuc(MaKhuVuc),

    CONSTRAINT CK_Phong_SucChua CHECK (SoNguoiToiDa > 0),

    CONSTRAINT CK_Phong_DonGia CHECK (DonGiaNgay >= 0),

    CONSTRAINT CK_Phong_TrangThai CHECK (TrangThai IN (N'Trống', N'Đã đặt', N'Đang ở', N'Bảo trì'))

);

CREATE TABLE dbo.LoaiTienNghi (

    MaLoaiTN  VARCHAR(20)   NOT NULL,

    TenLoaiTN NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_LoaiTienNghi PRIMARY KEY (MaLoaiTN),

    CONSTRAINT UQ_LoaiTN_Ten UNIQUE (TenLoaiTN)

);

-- BR03: số thứ tự phân biệt trong cùng loại tiện nghi

CREATE TABLE dbo.TienNghi (

    MaTienNghi       VARCHAR(30)   NOT NULL,

    MaLoaiTN         VARCHAR(20)   NOT NULL,

    SoThuTu          INT     NOT NULL,

    TinhTrangHienTai NVARCHAR(100),

    CONSTRAINT PK_TienNghi PRIMARY KEY (MaTienNghi),

    CONSTRAINT UQ_TienNghi_Loai_STT UNIQUE (MaLoaiTN, SoThuTu),

    CONSTRAINT FK_TienNghi_Loai FOREIGN KEY (MaLoaiTN) REFERENCES dbo.LoaiTienNghi(MaLoaiTN),

    CONSTRAINT CK_TienNghi_STT CHECK (SoThuTu > 0)

);

-- BR04: trong một ngày một thiết bị chỉ được trang bị cho một phòng

CREATE TABLE dbo.PhieuLapDat (

    SoPhieuLapDat VARCHAR(30)   NOT NULL,

    MaTienNghi    VARCHAR(30)   NOT NULL,

    SoPhong       VARCHAR(20)   NOT NULL,

    NgayLap       DATETIME2(0)           NOT NULL,

    TinhTrang     NVARCHAR(100) NOT NULL,

    MaNV          VARCHAR(20)   NOT NULL,

    GhiChu        NVARCHAR(250),

    CONSTRAINT PK_PhieuLapDat PRIMARY KEY (SoPhieuLapDat),

    CONSTRAINT UQ_PhieuLapDat_ThietBi_Ngay UNIQUE (MaTienNghi, NgayLap),

    CONSTRAINT FK_PhieuLapDat_TienNghi FOREIGN KEY (MaTienNghi) REFERENCES dbo.TienNghi(MaTienNghi),

    CONSTRAINT FK_PhieuLapDat_Phong FOREIGN KEY (SoPhong) REFERENCES dbo.Phong(SoPhong),

    CONSTRAINT FK_PhieuLapDat_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)

);

CREATE TABLE dbo.DichVu (

    MaDV      VARCHAR(20)   NOT NULL,

    TenDV     NVARCHAR(120) NOT NULL,

    DonViTinh NVARCHAR(40)  NOT NULL,

    DonGia    DECIMAL(18,2)   NOT NULL,

    CONSTRAINT PK_DichVu PRIMARY KEY (MaDV),

    CONSTRAINT CK_DichVu_DonGia CHECK (DonGia >= 0)

);

-- =====================================================================

-- 2. ĐẶT / NHẬN PHÒNG

-- =====================================================================

CREATE TABLE dbo.KhachHang (

    MaKhach     VARCHAR(20)   NOT NULL,

    HoTen       NVARCHAR(120) NOT NULL,

    SoCMND      VARCHAR(30)   NOT NULL,

    QuocTich    NVARCHAR(80)  NOT NULL,

    SoDienThoai VARCHAR(20),

    CONSTRAINT PK_KhachHang PRIMARY KEY (MaKhach),

    CONSTRAINT UQ_KhachHang_CMND UNIQUE (SoCMND)

);

-- BR05: phiếu đặt ghi phòng, ngày nhận, ngày trả dự kiến và tiền cọc

CREATE TABLE dbo.PhieuDatPhong (

    SoPhieuDat      VARCHAR(30)  NOT NULL,

    MaKhach         VARCHAR(20)  NOT NULL,

    MaNVLeTan       VARCHAR(20)  NOT NULL,

    NgayLap         DATETIME2(0)          NOT NULL,

    NgayNhan        DATETIME2(0)          NOT NULL,

    NgayTraDuKien   DATETIME2(0)          NOT NULL,

    TienCoc         DECIMAL(18,2)  DEFAULT 0 NOT NULL,

    KenhDat         NVARCHAR(20) NOT NULL,

    TrangThai       NVARCHAR(30) DEFAULT N'Đã đặt' NOT NULL,

    NgayNhanThucTe  DATETIME2(0),

    NgayTraThucTe   DATETIME2(0),

    CONSTRAINT PK_PhieuDatPhong PRIMARY KEY (SoPhieuDat),

    CONSTRAINT FK_PhieuDat_Khach FOREIGN KEY (MaKhach) REFERENCES dbo.KhachHang(MaKhach),

    CONSTRAINT FK_PhieuDat_NV FOREIGN KEY (MaNVLeTan) REFERENCES dbo.NhanVien(MaNV),

    CONSTRAINT CK_PhieuDat_Coc CHECK (TienCoc >= 0),

    CONSTRAINT CK_PhieuDat_Ngay CHECK (NgayTraDuKien >= NgayNhan),

    CONSTRAINT CK_PhieuDat_Kenh CHECK (KenhDat IN (N'Điện thoại', N'Website', N'Trực tiếp')),

    CONSTRAINT CK_PhieuDat_TrangThai CHECK (TrangThai IN (N'Đã đặt', N'Đang ở', N'Đã trả', N'No-show', N'Hủy'))

);

-- DonGiaApDung: bổ sung so với đề. Đề tính tiền phòng theo đơn giá hiện hành nên nếu

-- khách sạn đổi giá thì hóa đơn cũ sai; cột này chốt đơn giá tại thời điểm lập phiếu đặt.

CREATE TABLE dbo.ChiTietDatPhong (

    SoPhieuDat   VARCHAR(30) NOT NULL,

    SoPhong      VARCHAR(20) NOT NULL,

    SoNguoi      INT   NOT NULL,

    DonGiaApDung DECIMAL(18,2) NOT NULL,

    CONSTRAINT PK_ChiTietDatPhong PRIMARY KEY (SoPhieuDat, SoPhong),

    CONSTRAINT FK_CTDat_Phieu FOREIGN KEY (SoPhieuDat) REFERENCES dbo.PhieuDatPhong(SoPhieuDat),

    CONSTRAINT FK_CTDat_Phong FOREIGN KEY (SoPhong) REFERENCES dbo.Phong(SoPhong),

    CONSTRAINT CK_CTDat_SoNguoi CHECK (SoNguoi > 0),

    CONSTRAINT CK_CTDat_DonGia CHECK (DonGiaApDung >= 0)

);

-- BR06: ghi họ tên, CCCD và quốc tịch của người lưu trú

CREATE TABLE dbo.NguoiLuuTru (

    MaNguoiLT  INT IDENTITY(1,1),

    SoPhieuDat VARCHAR(30)   NOT NULL,

    SoPhong    VARCHAR(20)   NOT NULL,

    HoTen      NVARCHAR(120) NOT NULL,

    SoCMND     VARCHAR(30)   NOT NULL,

    QuocTich   NVARCHAR(80)  NOT NULL,

    CONSTRAINT PK_NguoiLuuTru PRIMARY KEY (MaNguoiLT),

    CONSTRAINT FK_NguoiLT_CTDat FOREIGN KEY (SoPhieuDat, SoPhong)

        REFERENCES dbo.ChiTietDatPhong(SoPhieuDat, SoPhong)

);

-- =====================================================================

-- 3. DỊCH VỤ

-- BR07: cùng một dịch vụ dùng nhiều lần trong ngày được cộng dồn

-- =====================================================================

CREATE TABLE dbo.PhieuSuDungDV (

    SoPhieuSDDV VARCHAR(30) NOT NULL,

    SoPhieuDat  VARCHAR(30) NOT NULL,

    SoPhong     VARCHAR(20) NOT NULL,

    NgaySuDung  DATETIME2(0)         NOT NULL,

    MaNV        VARCHAR(20) NOT NULL,

    CONSTRAINT PK_PhieuSuDungDV PRIMARY KEY (SoPhieuSDDV),

    CONSTRAINT UQ_PhieuSDDV_PhongNgay UNIQUE (SoPhieuDat, SoPhong, NgaySuDung),

    CONSTRAINT FK_PhieuSDDV_CTDat FOREIGN KEY (SoPhieuDat, SoPhong)

        REFERENCES dbo.ChiTietDatPhong(SoPhieuDat, SoPhong),

    CONSTRAINT FK_PhieuSDDV_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV)

);

CREATE TABLE dbo.ChiTietPhieuSuDungDV (

    SoPhieuSDDV VARCHAR(30) NOT NULL,

    MaDV        VARCHAR(20) NOT NULL,

    SoLuong     INT   NOT NULL,

    DonGia      DECIMAL(18,2) NOT NULL,

    ThanhTien   AS (SoLuong * DonGia),

    CONSTRAINT PK_CTSDDV PRIMARY KEY (SoPhieuSDDV, MaDV),

    CONSTRAINT FK_CTSDDV_Phieu FOREIGN KEY (SoPhieuSDDV) REFERENCES dbo.PhieuSuDungDV(SoPhieuSDDV),

    CONSTRAINT FK_CTSDDV_DV FOREIGN KEY (MaDV) REFERENCES dbo.DichVu(MaDV),

    CONSTRAINT CK_CTSDDV_SoLuong CHECK (SoLuong > 0),

    CONSTRAINT CK_CTSDDV_DonGia CHECK (DonGia >= 0)

);

-- =====================================================================

-- 4. ĐỀN BÙ – HÓA ĐƠN – THANH TOÁN

-- =====================================================================

CREATE TABLE dbo.QuyDinhDenBu (

    MaQuyDinh     VARCHAR(30)  NOT NULL,

    MaLoaiTN      VARCHAR(20)  NOT NULL,

    MucDoThietHai NVARCHAR(80) NOT NULL,

    MucDenBu      DECIMAL(18,2)  NOT NULL,

    CONSTRAINT PK_QuyDinhDenBu PRIMARY KEY (MaQuyDinh),

    CONSTRAINT UQ_QDDB_Loai_MucDo UNIQUE (MaLoaiTN, MucDoThietHai),

    CONSTRAINT FK_QDDB_Loai FOREIGN KEY (MaLoaiTN) REFERENCES dbo.LoaiTienNghi(MaLoaiTN),

    CONSTRAINT CK_QDDB_Muc CHECK (MucDenBu >= 0)

);

-- BR08: hư hỏng/mất mát thì lập phiếu đền bù theo tiện nghi và mức độ thiệt hại

CREATE TABLE dbo.PhieuDenBu (

    SoPhieuDenBu VARCHAR(30) NOT NULL,

    SoPhieuDat   VARCHAR(30) NOT NULL,

    SoPhong      VARCHAR(20) NOT NULL,

    NgayLap      DATETIME2(0)         NOT NULL,

    MaNV         VARCHAR(20) NOT NULL,

    TongTien     DECIMAL(18,2) DEFAULT 0 NOT NULL,

    CONSTRAINT PK_PhieuDenBu PRIMARY KEY (SoPhieuDenBu),

    CONSTRAINT FK_PhieuDB_CTDat FOREIGN KEY (SoPhieuDat, SoPhong)

        REFERENCES dbo.ChiTietDatPhong(SoPhieuDat, SoPhong),

    CONSTRAINT FK_PhieuDB_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),

    CONSTRAINT CK_PhieuDB_Tong CHECK (TongTien >= 0)

);

CREATE TABLE dbo.ChiTietPhieuDenBu (

    SoPhieuDenBu  VARCHAR(30)  NOT NULL,

    MaTienNghi    VARCHAR(30)  NOT NULL,

    MucDoThietHai NVARCHAR(80) NOT NULL,

    SoTien        DECIMAL(18,2)  NOT NULL,

    CONSTRAINT PK_CTDenBu PRIMARY KEY (SoPhieuDenBu, MaTienNghi),

    CONSTRAINT FK_CTDB_Phieu FOREIGN KEY (SoPhieuDenBu) REFERENCES dbo.PhieuDenBu(SoPhieuDenBu),

    CONSTRAINT FK_CTDB_TienNghi FOREIGN KEY (MaTienNghi) REFERENCES dbo.TienNghi(MaTienNghi),

    CONSTRAINT CK_CTDB_SoTien CHECK (SoTien >= 0)

);

-- BR09: hóa đơn gồm tiền thuê phòng và tiền sử dụng dịch vụ

CREATE TABLE dbo.HoaDon (

    SoHoaDon       VARCHAR(30)  NOT NULL,

    SoPhieuDat     VARCHAR(30)  NOT NULL,

    NgayLap        DATETIME2(0)          NOT NULL,

    MaNV           VARCHAR(20)  NOT NULL,

    SoNgayTinhTien INT    NOT NULL,

    TienPhong      DECIMAL(18,2)  NOT NULL,

    TienDichVu     DECIMAL(18,2)  NOT NULL,

    TongTien       AS (TienPhong + TienDichVu),

    TrangThai      NVARCHAR(30) DEFAULT N'Chưa thanh toán' NOT NULL,

    CONSTRAINT PK_HoaDon PRIMARY KEY (SoHoaDon),

    CONSTRAINT UQ_HoaDon_PhieuDat UNIQUE (SoPhieuDat),

    CONSTRAINT FK_HoaDon_PhieuDat FOREIGN KEY (SoPhieuDat) REFERENCES dbo.PhieuDatPhong(SoPhieuDat),

    CONSTRAINT FK_HoaDon_NV FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),

    CONSTRAINT CK_HoaDon_SoNgay CHECK (SoNgayTinhTien > 0),

    CONSTRAINT CK_HoaDon_TienPhong CHECK (TienPhong >= 0),

    CONSTRAINT CK_HoaDon_TienDV CHECK (TienDichVu >= 0),

    CONSTRAINT CK_HoaDon_TrangThai CHECK (TrangThai IN (N'Chưa thanh toán', N'Đã thanh toán'))

);

-- BR10: thanh toán bằng tiền mặt, chuyển khoản, thẻ hoặc ví điện tử (một hóa đơn nhiều giao dịch)

CREATE TABLE dbo.ThanhToan (

    MaThanhToan   VARCHAR(30)  NOT NULL,

    SoHoaDon      VARCHAR(30)  NOT NULL,

    NgayThanhToan DATETIME2(0)          NOT NULL,

    HinhThuc      NVARCHAR(30) NOT NULL,

    SoTien        DECIMAL(18,2)  NOT NULL,

    CONSTRAINT PK_ThanhToan PRIMARY KEY (MaThanhToan),

    CONSTRAINT FK_ThanhToan_HoaDon FOREIGN KEY (SoHoaDon) REFERENCES dbo.HoaDon(SoHoaDon),

    CONSTRAINT CK_ThanhToan_SoTien CHECK (SoTien > 0),

    CONSTRAINT CK_ThanhToan_HinhThuc CHECK (HinhThuc IN (N'Tiền mặt', N'Chuyển khoản', N'Thẻ', N'Ví điện tử'))

);

-- =====================================================================

-- 5. CHỈ MỤC VÀ SEQUENCE SINH MÃ PHIẾU

-- =====================================================================

CREATE INDEX IX_PhieuDatPhong_Ngay ON dbo.PhieuDatPhong(NgayNhan, NgayTraDuKien, TrangThai);

CREATE INDEX IX_CTDat_Phong ON dbo.ChiTietDatPhong(SoPhong, SoPhieuDat);

-- (SoPhieuDat, SoPhong, NgaySuDung) đã có chỉ mục do ràng buộc UQ_PhieuSDDV_PhongNgay tạo ra

CREATE INDEX IX_PhieuLapDat_Phong ON dbo.PhieuLapDat(SoPhong, NgayLap);

CREATE INDEX IX_ThanhToan_HoaDon ON dbo.ThanhToan(SoHoaDon);

-- Đề để nhân viên tự gõ số phiếu; dùng SEQUENCE của SQL Server để tránh trùng mã.

CREATE SEQUENCE dbo.SEQ_KhachHang AS BIGINT START WITH 100 INCREMENT BY 1 NO CACHE;

CREATE SEQUENCE dbo.SEQ_PhieuLapDat AS BIGINT START WITH 100 INCREMENT BY 1 NO CACHE;

CREATE SEQUENCE dbo.SEQ_PhieuDat AS BIGINT START WITH 100 INCREMENT BY 1 NO CACHE;

CREATE SEQUENCE dbo.SEQ_PhieuSDDV AS BIGINT START WITH 100 INCREMENT BY 1 NO CACHE;

CREATE SEQUENCE dbo.SEQ_PhieuDenBu AS BIGINT START WITH 100 INCREMENT BY 1 NO CACHE;

CREATE SEQUENCE dbo.SEQ_HoaDon AS BIGINT START WITH 100 INCREMENT BY 1 NO CACHE;

CREATE SEQUENCE dbo.SEQ_ThanhToan AS BIGINT START WITH 100 INCREMENT BY 1 NO CACHE;

PRINT N'[3/4] DỮ LIỆU MẪU...';

INSERT INTO dbo.NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV01', N'Nguyễn Thu Hà', N'Lễ tân', '0901000001');

INSERT INTO dbo.NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV02', N'Trần Minh An', N'Phục vụ phòng', '0901000002');

INSERT INTO dbo.NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV03', N'Lê Hoàng Nam', N'Thanh toán', '0901000003');

INSERT INTO dbo.NhanVien(MaNV, HoTen, VaiTro, SoDienThoai) VALUES ('NV04', N'Phạm Quỳnh Chi', N'Quản lý', '0901000004');

INSERT INTO dbo.KhuVuc(MaKhuVuc, TenKhuVuc) VALUES ('A', N'Khu A');

INSERT INTO dbo.KhuVuc(MaKhuVuc, TenKhuVuc) VALUES ('B', N'Khu B');

INSERT INTO dbo.Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('A101', 'A', 2, 600000, N'Trống');

INSERT INTO dbo.Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('A102', 'A', 3, 800000, N'Trống');

INSERT INTO dbo.Phong(SoPhong, MaKhuVuc, SoNguoiToiDa, DonGiaNgay, TrangThai) VALUES ('B201', 'B', 4, 1200000, N'Trống');

INSERT INTO dbo.LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('TV', N'Ti vi');

INSERT INTO dbo.LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('TL', N'Tủ lạnh');

INSERT INTO dbo.LoaiTienNghi(MaLoaiTN, TenLoaiTN) VALUES ('DT', N'Điện thoại');

INSERT INTO dbo.TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TV01', 'TV', 1, N'Tốt');

INSERT INTO dbo.TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TV02', 'TV', 2, N'Tốt');

INSERT INTO dbo.TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('TL01', 'TL', 1, N'Tốt');

INSERT INTO dbo.TienNghi(MaTienNghi, MaLoaiTN, SoThuTu, TinhTrangHienTai) VALUES ('DT01', 'DT', 1, N'Tốt');

INSERT INTO dbo.DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV01', N'Ăn sáng', N'Suất', 120000);

INSERT INTO dbo.DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV02', N'Tắm hơi', N'Lượt', 250000);

INSERT INTO dbo.DichVu(MaDV, TenDV, DonViTinh, DonGia) VALUES ('DV03', N'Karaoke', N'Giờ', 300000);

INSERT INTO dbo.QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD01', 'TV', N'Hư hỏng nhẹ', 500000);

INSERT INTO dbo.QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD02', 'TV', N'Mất', 5000000);

INSERT INTO dbo.QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD03', 'TL', N'Hư hỏng nhẹ', 400000);

INSERT INTO dbo.QuyDinhDenBu(MaQuyDinh, MaLoaiTN, MucDoThietHai, MucDenBu) VALUES ('QD04', 'TL', N'Mất', 4000000);

INSERT INTO dbo.KhachHang(MaKhach, HoTen, SoCMND, QuocTich, SoDienThoai)

VALUES ('KH001', N'Nguyễn Văn A', '079201000111', N'Việt Nam', '0912000001');

INSERT INTO dbo.KhachHang(MaKhach, HoTen, SoCMND, QuocTich, SoDienThoai)

VALUES ('KH002', N'Trần Thị B', '079201000222', N'Việt Nam', '0912000002');

-- Tiện nghi đang lắp cho các phòng mẫu

INSERT INTO dbo.PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu)

VALUES ('LD001', 'TV01', 'A101', DATEADD(DAY, -30, CAST(GETDATE() AS date)), N'Tốt', 'NV02', NULL);

INSERT INTO dbo.PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu)

VALUES ('LD002', 'TL01', 'A101', DATEADD(DAY, -30, CAST(GETDATE() AS date)), N'Tốt', 'NV02', NULL);

INSERT INTO dbo.PhieuLapDat(SoPhieuLapDat, MaTienNghi, SoPhong, NgayLap, TinhTrang, MaNV, GhiChu)

VALUES ('LD003', 'TV02', 'B201', DATEADD(DAY, -20, CAST(GETDATE() AS date)), N'Tốt', 'NV02', NULL);

-- Một lượt đang ở để thử nghiệp vụ dịch vụ / trả phòng

INSERT INTO dbo.PhieuDatPhong(SoPhieuDat, MaKhach, MaNVLeTan, NgayLap, NgayNhan, NgayTraDuKien,

                          TienCoc, KenhDat, TrangThai, NgayNhanThucTe)

VALUES ('DP001', 'KH001', 'NV01', DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, -2, CAST(GETDATE() AS date)), DATEADD(DAY, 1, CAST(GETDATE() AS date)),

        500000, N'Website', N'Đang ở', DATEADD(DAY, -2, GETDATE()));

INSERT INTO dbo.ChiTietDatPhong(SoPhieuDat, SoPhong, SoNguoi, DonGiaApDung) VALUES ('DP001', 'A101', 2, 600000);

INSERT INTO dbo.NguoiLuuTru(SoPhieuDat, SoPhong, HoTen, SoCMND, QuocTich)

VALUES ('DP001', 'A101', N'Nguyễn Văn A', '079201000111', N'Việt Nam');

UPDATE dbo.Phong SET TrangThai = N'Đang ở' WHERE SoPhong = 'A101';

INSERT INTO dbo.PhieuSuDungDV(SoPhieuSDDV, SoPhieuDat, SoPhong, NgaySuDung, MaNV)

VALUES ('SD001', 'DP001', 'A101', DATEADD(DAY, -1, CAST(GETDATE() AS date)), 'NV02');

INSERT INTO dbo.ChiTietPhieuSuDungDV(SoPhieuSDDV, MaDV, SoLuong, DonGia) VALUES ('SD001', 'DV01', 2, 120000);

-- SQL Server chạy autocommit mặc định; không cần COMMIT khi không mở transaction.

PRINT N'[4/4] KIỂM TRA...';

SELECT [name] AS table_name FROM sys.tables WHERE schema_id = SCHEMA_ID('dbo') ORDER BY [name];

SELECT COUNT(*) AS SoBang FROM sys.tables WHERE schema_id = SCHEMA_ID('dbo');

SELECT SoPhong, TrangThai FROM dbo.Phong ORDER BY SoPhong;

SELECT SoPhieuDat, TrangThai FROM dbo.PhieuDatPhong;

PRINT N'HOÀN TẤT SCRIPT CHÍNH.';
