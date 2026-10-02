-- =====================================================================
-- LAB 04 – Hệ thống cửa hàng online e-SHOPPING
-- Thực hiện: Trần Tuấn Minh
-- Script SQL Server (T-SQL): 18 bảng, 7 sequence, 1 hàm, 1 trigger, 2 view và dữ liệu mẫu.
-- Script chạy lại được nhiều lần (tự xóa đối tượng cũ trước khi tạo).
-- =====================================================================

-- ---------------------------------------------------------------- 0. Xóa đối tượng cũ
DROP TABLE IF EXISTS NhatKyEmail;
DROP TABLE IF EXISTS NhatKyThanhToan;
DROP TABLE IF EXISTS ChiTietDonHang;
DROP TABLE IF EXISTS DonDatHang;
DROP TABLE IF EXISTS TheTinDung;
DROP TABLE IF EXISTS LoaiThe;
DROP TABLE IF EXISTS BangPhiGiaoHang;
DROP TABLE IF EXISTS TinhThanh;
DROP TABLE IF EXISTS KhuVucGiaoHang;
DROP TABLE IF EXISTS LoaiPhieuDatHang;
DROP TABLE IF EXISTS ChiTietGioHang;
DROP TABLE IF EXISTS GioHang;
DROP TABLE IF EXISTS NhanVien;
DROP TABLE IF EXISTS KhachHang;
DROP TABLE IF EXISTS ThongSoKyThuat;
DROP TABLE IF EXISTS HinhAnhSanPham;
DROP TABLE IF EXISTS SanPham;
DROP TABLE IF EXISTS NhomSanPham;
GO

DROP SEQUENCE IF EXISTS SEQ_KhachHang;
DROP SEQUENCE IF EXISTS SEQ_GioHang;
DROP SEQUENCE IF EXISTS SEQ_DonHang;
DROP SEQUENCE IF EXISTS SEQ_The;
DROP SEQUENCE IF EXISTS SEQ_NhatKyTT;
DROP SEQUENCE IF EXISTS SEQ_Email;
DROP SEQUENCE IF EXISTS SEQ_HinhAnh;
GO

DROP VIEW IF EXISTS V_SanPham;
DROP VIEW IF EXISTS V_DonHang;
DROP FUNCTION IF EXISTS FN_TinhPhiGiao;
GO

-- ---------------------------------------------------------------- 1. Sản phẩm
CREATE TABLE NhomSanPham (
  MaNhom      VARCHAR(10)   CONSTRAINT PK_NhomSanPham PRIMARY KEY,
  TenNhom     NVARCHAR(100) NOT NULL CONSTRAINT UQ_NhomSanPham_Ten UNIQUE,
  MoTa        NVARCHAR(300)
);
GO

CREATE TABLE SanPham (
  MaSP        VARCHAR(20)   CONSTRAINT PK_SanPham PRIMARY KEY,
  TenSP       NVARCHAR(200) NOT NULL,
  MaNhom      VARCHAR(10)   NOT NULL CONSTRAINT FK_SanPham_Nhom REFERENCES NhomSanPham(MaNhom),
  NhaSanXuat  NVARCHAR(100) NOT NULL,
  MoTa        NVARCHAR(MAX),
  GiaBan      BIGINT        NOT NULL CONSTRAINT CK_SanPham_Gia CHECK (GiaBan > 0),
  TinhTrang   NVARCHAR(20)  DEFAULT N'Còn hàng' NOT NULL
              CONSTRAINT CK_SanPham_TinhTrang CHECK (TinhTrang IN (N'Còn hàng', N'Hết hàng')),
  NgayCapNhat DATETIME      DEFAULT GETDATE() NOT NULL
);
GO

CREATE TABLE HinhAnhSanPham (
  MaHinh      INT           CONSTRAINT PK_HinhAnhSanPham PRIMARY KEY,
  MaSP        VARCHAR(20)   NOT NULL CONSTRAINT FK_HinhAnh_SanPham REFERENCES SanPham(MaSP) ON DELETE CASCADE,
  DuongDan    VARCHAR(300)  NOT NULL,
  ThuTu       INT           DEFAULT 1 NOT NULL,
  CONSTRAINT UQ_HinhAnh_ThuTu UNIQUE (MaSP, ThuTu)
);
GO

CREATE TABLE ThongSoKyThuat (
  MaSP        VARCHAR(20)   CONSTRAINT FK_ThongSo_SanPham REFERENCES SanPham(MaSP) ON DELETE CASCADE,
  TenThongSo  NVARCHAR(100),
  GiaTri      NVARCHAR(300) NOT NULL,
  CONSTRAINT PK_ThongSoKyThuat PRIMARY KEY (MaSP, TenThongSo)
);
GO

-- ---------------------------------------------------------------- 2. Tài khoản
CREATE TABLE KhachHang (
  MaKH        VARCHAR(10)   CONSTRAINT PK_KhachHang PRIMARY KEY,
  HoTen       NVARCHAR(100) NOT NULL,
  NgaySinh    DATETIME      NOT NULL,
  SoGiayTo    VARCHAR(20)   NOT NULL CONSTRAINT UQ_KhachHang_GiayTo UNIQUE,
  DiaChi      NVARCHAR(250) NOT NULL,
  DienThoai   VARCHAR(15)   NOT NULL CONSTRAINT CK_KhachHang_DT CHECK (DienThoai NOT LIKE '%[^0-9+]%'),
  TenDangNhap VARCHAR(50)   NOT NULL CONSTRAINT UQ_KhachHang_TenDN UNIQUE,
  MatKhauHash VARCHAR(64)   NOT NULL,
  Salt        VARCHAR(32)   NOT NULL,
  Email       VARCHAR(100)  CONSTRAINT CK_KhachHang_Email CHECK (Email IS NULL OR Email LIKE '%_@__%.__%'),
  NgayDangKy  DATETIME      DEFAULT GETDATE() NOT NULL,
  TrangThai   NVARCHAR(20)  DEFAULT N'Hoạt động' NOT NULL
              CONSTRAINT CK_KhachHang_TrangThai CHECK (TrangThai IN (N'Hoạt động', N'Bị khóa'))
);
GO

CREATE TABLE NhanVien (
  MaNV        VARCHAR(10)   CONSTRAINT PK_NhanVien PRIMARY KEY,
  HoTen       NVARCHAR(100) NOT NULL,
  TenDangNhap VARCHAR(50)   NOT NULL CONSTRAINT UQ_NhanVien_TenDN UNIQUE,
  MatKhauHash VARCHAR(64)   NOT NULL,
  Salt        VARCHAR(32)   NOT NULL,
  VaiTro      NVARCHAR(30)  DEFAULT N'Nhân viên bán hàng' NOT NULL
);
GO

-- ---------------------------------------------------------------- 3. Giỏ hàng
CREATE TABLE GioHang (
  MaGioHang   INT           CONSTRAINT PK_GioHang PRIMARY KEY,
  MaKH        VARCHAR(10)   CONSTRAINT FK_GioHang_KhachHang REFERENCES KhachHang(MaKH),
  NgayTao     DATETIME      DEFAULT GETDATE() NOT NULL,
  TrangThai   NVARCHAR(30)  DEFAULT N'Đang mua' NOT NULL
              CONSTRAINT CK_GioHang_TrangThai CHECK (TrangThai IN (N'Đang mua', N'Đã chuyển thành đơn'))
);
GO

-- Mỗi khách chỉ có một giỏ đang mua (dùng Filtered Index của SQL Server)
CREATE UNIQUE INDEX UX_GioHang_DangMua ON GioHang (MaKH) WHERE TrangThai = N'Đang mua';
GO

CREATE TABLE ChiTietGioHang (
  MaGioHang   INT           CONSTRAINT FK_CTGH_GioHang REFERENCES GioHang(MaGioHang) ON DELETE CASCADE,
  MaSP        VARCHAR(20)   CONSTRAINT FK_CTGH_SanPham REFERENCES SanPham(MaSP),
  SoLuong     INT           NOT NULL CONSTRAINT CK_CTGH_SoLuong CHECK (SoLuong BETWEEN 1 AND 99),
  NgayThem    DATETIME      DEFAULT GETDATE() NOT NULL,
  CONSTRAINT PK_ChiTietGioHang PRIMARY KEY (MaGioHang, MaSP)
);
GO

-- ---------------------------------------------------------------- 4. Giao hàng
CREATE TABLE LoaiPhieuDatHang (
  MaLoaiPhieu   VARCHAR(10)   CONSTRAINT PK_LoaiPhieuDatHang PRIMARY KEY,
  TenLoai       NVARCHAR(60)  NOT NULL,
  SoGioXuLy     INT           NOT NULL CONSTRAINT CK_LoaiPhieu_Gio CHECK (SoGioXuLy > 0),
  NguongMienPhi BIGINT        CONSTRAINT CK_LoaiPhieu_Nguong CHECK (NguongMienPhi IS NULL OR NguongMienPhi >= 0)
);
GO

CREATE TABLE KhuVucGiaoHang (
  MaKhuVuc    VARCHAR(10)   CONSTRAINT PK_KhuVucGiaoHang PRIMARY KEY,
  TenKhuVuc   NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE TinhThanh (
  MaTinh      VARCHAR(10)   CONSTRAINT PK_TinhThanh PRIMARY KEY,
  TenTinh     NVARCHAR(100) NOT NULL CONSTRAINT UQ_TinhThanh_Ten UNIQUE,
  MaKhuVuc    VARCHAR(10)   NOT NULL CONSTRAINT FK_TinhThanh_KhuVuc REFERENCES KhuVucGiaoHang(MaKhuVuc)
);
GO

CREATE TABLE BangPhiGiaoHang (
  MaKhuVuc    VARCHAR(10)   CONSTRAINT FK_BangPhi_KhuVuc REFERENCES KhuVucGiaoHang(MaKhuVuc),
  MaLoaiPhieu VARCHAR(10)   CONSTRAINT FK_BangPhi_LoaiPhieu REFERENCES LoaiPhieuDatHang(MaLoaiPhieu),
  PhiGiao     BIGINT        NOT NULL CONSTRAINT CK_BangPhi_Phi CHECK (PhiGiao >= 0),
  CONSTRAINT PK_BangPhiGiaoHang PRIMARY KEY (MaKhuVuc, MaLoaiPhieu)
);
GO

-- ---------------------------------------------------------------- 5. Thanh toán
CREATE TABLE LoaiThe (
  MaLoaiThe     VARCHAR(10)   CONSTRAINT PK_LoaiThe PRIMARY KEY,
  TenLoaiThe    NVARCHAR(50)  NOT NULL,
  DoDaiSoThe    INT           NOT NULL CONSTRAINT CK_LoaiThe_DoDai CHECK (DoDaiSoThe IN (15, 16)),
  DoDaiCSV      INT           NOT NULL CONSTRAINT CK_LoaiThe_CSV CHECK (DoDaiCSV IN (3, 4)),
  LePhiGiaoDich BIGINT        DEFAULT 0 NOT NULL CONSTRAINT CK_LoaiThe_LePhi CHECK (LePhiGiaoDich >= 0)
);
GO

-- Không lưu số thẻ đầy đủ và mã CSV (chuẩn PCI-DSS): chỉ lưu số đã che và token do cổng thanh toán cấp.
CREATE TABLE TheTinDung (
  MaThe          INT            CONSTRAINT PK_TheTinDung PRIMARY KEY,
  MaKH           VARCHAR(10)    NOT NULL CONSTRAINT FK_The_KhachHang REFERENCES KhachHang(MaKH),
  MaLoaiThe      VARCHAR(10)    NOT NULL CONSTRAINT FK_The_LoaiThe REFERENCES LoaiThe(MaLoaiThe),
  SoTheAn        VARCHAR(25)    NOT NULL,
  ThangHetHan    INT            NOT NULL CONSTRAINT CK_The_Thang CHECK (ThangHetHan BETWEEN 1 AND 12),
  NamHetHan      INT            NOT NULL,
  TenChuThe      NVARCHAR(100)  NOT NULL,
  TokenThanhToan VARCHAR(64)    NOT NULL CONSTRAINT UQ_The_Token UNIQUE
);
GO

-- ---------------------------------------------------------------- 6. Đơn đặt hàng
CREATE TABLE DonDatHang (
  SoDonHang     VARCHAR(12)    CONSTRAINT PK_DonDatHang PRIMARY KEY,
  MaKH          VARCHAR(10)    NOT NULL CONSTRAINT FK_Don_KhachHang REFERENCES KhachHang(MaKH),
  MaLoaiPhieu   VARCHAR(10)    NOT NULL CONSTRAINT FK_Don_LoaiPhieu REFERENCES LoaiPhieuDatHang(MaLoaiPhieu),
  ThoiDiemDat   DATETIME       DEFAULT GETDATE() NOT NULL,
  TenNguoiNhan  NVARCHAR(100)  NOT NULL,
  DiaChiNhan    NVARCHAR(250)  NOT NULL,
  MaTinh        VARCHAR(10)    NOT NULL CONSTRAINT FK_Don_TinhThanh REFERENCES TinhThanh(MaTinh),
  DienThoaiNhan VARCHAR(15)    NOT NULL,
  TongTienHang  BIGINT         NOT NULL CONSTRAINT CK_Don_TienHang CHECK (TongTienHang > 0),
  PhiGiaoHang   BIGINT         DEFAULT 0 NOT NULL CONSTRAINT CK_Don_PhiGiao CHECK (PhiGiaoHang >= 0),
  LePhiThe      BIGINT         DEFAULT 0 NOT NULL CONSTRAINT CK_Don_LePhi CHECK (LePhiThe >= 0),
  TongTriGia    AS             (TongTienHang + PhiGiaoHang + LePhiThe),
  MaThe         INT            NOT NULL CONSTRAINT FK_Don_The REFERENCES TheTinDung(MaThe),
  MaGiaoDich    VARCHAR(40)    NOT NULL CONSTRAINT UQ_Don_GiaoDich UNIQUE,
  TrangThai     NVARCHAR(20)   DEFAULT N'Chờ xử lý' NOT NULL
                CONSTRAINT CK_Don_TrangThai CHECK (TrangThai IN (N'Chờ xử lý', N'Đang xử lý', N'Đang giao', N'Đã giao', N'Đã hủy')),
  DaGuiEmail    CHAR(1)        DEFAULT 'N' NOT NULL CONSTRAINT CK_Don_Email CHECK (DaGuiEmail IN ('Y', 'N'))
);
GO

CREATE TABLE ChiTietDonHang (
  SoDonHang   VARCHAR(12)   CONSTRAINT FK_CTDH_Don REFERENCES DonDatHang(SoDonHang) ON DELETE CASCADE,
  MaSP        VARCHAR(20)   CONSTRAINT FK_CTDH_SanPham REFERENCES SanPham(MaSP),
  SoLuong     INT           NOT NULL CONSTRAINT CK_CTDH_SoLuong CHECK (SoLuong > 0),
  DonGia      BIGINT        NOT NULL CONSTRAINT CK_CTDH_DonGia CHECK (DonGia > 0),
  ThanhTien   AS            (SoLuong * DonGia),
  CONSTRAINT PK_ChiTietDonHang PRIMARY KEY (SoDonHang, MaSP)
);
GO

CREATE TABLE NhatKyThanhToan (
  MaNhatKy    INT            CONSTRAINT PK_NhatKyThanhToan PRIMARY KEY,
  MaKH        VARCHAR(10)    NOT NULL CONSTRAINT FK_NKTT_KhachHang REFERENCES KhachHang(MaKH),
  MaLoaiThe   VARCHAR(10)    NOT NULL CONSTRAINT FK_NKTT_LoaiThe REFERENCES LoaiThe(MaLoaiThe),
  SoTheAn     VARCHAR(25)    NOT NULL,
  SoTien      BIGINT         NOT NULL,
  KetQua      NVARCHAR(20)   NOT NULL CONSTRAINT CK_NKTT_KetQua CHECK (KetQua IN (N'Chấp thuận', N'Từ chối', N'Hoàn tiền')),
  MaGiaoDich  VARCHAR(40),
  LyDo        NVARCHAR(200),
  ThoiDiem    DATETIME       DEFAULT GETDATE() NOT NULL
);
GO

CREATE TABLE NhatKyEmail (
  MaEmail     INT            CONSTRAINT PK_NhatKyEmail PRIMARY KEY,
  SoDonHang   VARCHAR(12)    NOT NULL CONSTRAINT FK_Email_Don REFERENCES DonDatHang(SoDonHang) ON DELETE CASCADE,
  DiaChiEmail VARCHAR(100)   NOT NULL,
  TieuDe      NVARCHAR(200)  NOT NULL,
  NoiDung     NVARCHAR(MAX),
  ThoiDiemGui DATETIME       DEFAULT GETDATE() NOT NULL
);
GO

CREATE INDEX IX_SanPham_Nhom ON SanPham(MaNhom);
CREATE INDEX IX_Don_KhachHang ON DonDatHang(MaKH, ThoiDiemDat);
CREATE INDEX IX_Don_TrangThai ON DonDatHang(TrangThai);
GO

-- ---------------------------------------------------------------- 7. Sequence
CREATE SEQUENCE SEQ_KhachHang START WITH 100;
CREATE SEQUENCE SEQ_GioHang   START WITH 100;
CREATE SEQUENCE SEQ_DonHang   START WITH 100;
CREATE SEQUENCE SEQ_The       START WITH 100;
CREATE SEQUENCE SEQ_NhatKyTT  START WITH 100;
CREATE SEQUENCE SEQ_Email     START WITH 100;
CREATE SEQUENCE SEQ_HinhAnh   START WITH 100;
GO

-- ---------------------------------------------------------------- 8. Hàm, trigger, view
-- BR06 + BR07: phí giao theo khu vực của tỉnh nhận và loại phiếu; miễn phí khi tổng tiền hàng đạt ngưỡng.
CREATE FUNCTION FN_TinhPhiGiao (
  @p_MaTinh       VARCHAR(10),
  @p_MaLoaiPhieu  VARCHAR(10),
  @p_TongTienHang BIGINT
) 
RETURNS BIGINT
AS
BEGIN
  DECLARE @v_Phi BIGINT;
  DECLARE @v_Nguong BIGINT;

  SELECT @v_Phi = b.PhiGiao, @v_Nguong = l.NguongMienPhi
  FROM TinhThanh t
  JOIN BangPhiGiaoHang b ON b.MaKhuVuc = t.MaKhuVuc
  JOIN LoaiPhieuDatHang l ON l.MaLoaiPhieu = b.MaLoaiPhieu
  WHERE t.MaTinh = @p_MaTinh AND b.MaLoaiPhieu = @p_MaLoaiPhieu;

  IF @v_Phi IS NULL 
    RETURN -1; -- Lỗi: Chưa có biểu phí

  IF @v_Nguong IS NOT NULL AND @p_TongTienHang >= @v_Nguong 
  BEGIN
    RETURN 0;
  END

  RETURN @v_Phi;
END;
GO

-- Giá bán / tình trạng do HTQLSP đồng bộ sang: ghi lại thời điểm cập nhật.
CREATE TRIGGER TRG_SanPham_CapNhat
ON SanPham
AFTER UPDATE
AS
BEGIN
  IF NOT UPDATE(NgayCapNhat)
  BEGIN
      UPDATE s
      SET NgayCapNhat = GETDATE()
      FROM SanPham s
      JOIN inserted i ON s.MaSP = i.MaSP;
  END
END;
GO

CREATE VIEW V_SanPham AS
SELECT s.MaSP, s.TenSP, s.MaNhom, n.TenNhom, s.NhaSanXuat, s.MoTa, s.GiaBan, s.TinhTrang, s.NgayCapNhat
  FROM SanPham s JOIN NhomSanPham n ON n.MaNhom = s.MaNhom;
GO

CREATE VIEW V_DonHang AS
SELECT d.SoDonHang, d.ThoiDiemDat, d.MaKH, k.HoTen, l.TenLoai, d.TenNguoiNhan, d.DiaChiNhan, t.TenTinh,
       d.DienThoaiNhan, d.TongTienHang, d.PhiGiaoHang, d.LePhiThe, d.TongTriGia, th.SoTheAn, d.MaGiaoDich,
       d.TrangThai, d.DaGuiEmail
  FROM DonDatHang d
  JOIN KhachHang k ON k.MaKH = d.MaKH
  JOIN LoaiPhieuDatHang l ON l.MaLoaiPhieu = d.MaLoaiPhieu
  JOIN TinhThanh t ON t.MaTinh = d.MaTinh
  JOIN TheTinDung th ON th.MaThe = d.MaThe;
GO

-- ---------------------------------------------------------------- 9. Dữ liệu mẫu
INSERT INTO NhomSanPham VALUES ('MCH',  N'Máy chụp hình kỹ thuật số', N'Máy ảnh compact, mirrorless, DSLR');
INSERT INTO NhomSanPham VALUES ('DOCHOI', N'Đồ chơi', N'Đồ chơi trẻ em, mô hình, xếp hình');
INSERT INTO NhomSanPham VALUES ('GIADUNG', N'Thiết bị điện gia dụng', N'Nồi cơm, máy xay, máy lọc không khí');
INSERT INTO NhomSanPham VALUES ('MAYTINH', N'Thiết bị máy tính', N'Laptop, chuột, bàn phím, màn hình');
INSERT INTO NhomSanPham VALUES ('QUATANG', N'Quà tặng Giáng Sinh', N'Hộp quà, thiệp, đồ trang trí Noel');
GO

INSERT INTO SanPham (MaSP, TenSP, MaNhom, NhaSanXuat, MoTa, GiaBan, TinhTrang) VALUES
 ('SP001', N'Máy ảnh Canon EOS R50 kèm lens 18-45', 'MCH', N'Canon', N'Máy ảnh mirrorless nhỏ gọn cho người mới, quay 4K, lấy nét Dual Pixel.', 18990000, N'Còn hàng'),
 ('SP002', N'Máy ảnh Sony ZV-1 II', 'MCH', N'Sony', N'Máy ảnh compact dành cho vlog, ống kính góc rộng 18-50mm.', 19490000, N'Còn hàng'),
 ('SP003', N'Máy ảnh Fujifilm Instax Mini 12', 'MCH', N'Fujifilm', N'Máy chụp lấy liền, nhiều màu pastel, quà tặng phổ biến.', 1890000, N'Còn hàng'),
 ('SP004', N'Máy ảnh Nikon Z fc', 'MCH', N'Nikon', N'Thiết kế cổ điển, cảm biến APS-C 20.9MP.', 21990000, N'Hết hàng'),
 ('SP005', N'Bộ xếp hình LEGO Ngôi nhà Giáng Sinh', 'DOCHOI', N'LEGO', N'Bộ 1.200 chi tiết, phù hợp từ 12 tuổi.', 2490000, N'Còn hàng'),
 ('SP006', N'Gấu bông Teddy 80cm', 'DOCHOI', N'Teddy Home', N'Gấu bông lông mịn, an toàn cho trẻ nhỏ.', 450000, N'Còn hàng'),
 ('SP007', N'Xe điều khiển địa hình 1:16', 'DOCHOI', N'Hot Wheels', N'Pin sạc, tốc độ 25 km/h, điều khiển 2.4GHz.', 890000, N'Còn hàng'),
 ('SP008', N'Nồi cơm điện tử Cuckoo 1.8L', 'GIADUNG', N'Cuckoo', N'Lòng nồi chống dính, 12 chế độ nấu.', 2790000, N'Còn hàng'),
 ('SP009', N'Máy lọc không khí Xiaomi 4 Lite', 'GIADUNG', N'Xiaomi', N'Lọc HEPA H13, phòng 43 m2, điều khiển qua app.', 2990000, N'Còn hàng'),
 ('SP010', N'Máy xay sinh tố Philips HR2223', 'GIADUNG', N'Philips', N'Công suất 700W, cối 1.5L, lưỡi dao ProBlend.', 1290000, N'Còn hàng'),
 ('SP011', N'Laptop ASUS Vivobook 15 OLED', 'MAYTINH', N'ASUS', N'Core i5-13500H, RAM 16GB, SSD 512GB, màn OLED 15.6".', 17490000, N'Còn hàng'),
 ('SP012', N'Chuột không dây Logitech MX Master 3S', 'MAYTINH', N'Logitech', N'Cảm biến 8K DPI, sạc USB-C, kết nối 3 thiết bị.', 2290000, N'Còn hàng'),
 ('SP013', N'Bàn phím cơ Keychron K2 V2', 'MAYTINH', N'Keychron', N'Layout 75%, switch Gateron Brown, Bluetooth.', 1890000, N'Còn hàng'),
 ('SP014', N'Màn hình Dell UltraSharp U2424H', 'MAYTINH', N'Dell', N'24 inch IPS, 120Hz, chuẩn màu sRGB 100%.', 5590000, N'Hết hàng'),
 ('SP015', N'Hộp quà Giáng Sinh cao cấp', 'QUATANG', N'ABC Gift', N'Hộp gỗ kèm rượu vang, socola và thiệp Noel.', 1150000, N'Còn hàng'),
 ('SP016', N'Cây thông Noel 1m8 kèm đèn LED', 'QUATANG', N'ABC Gift', N'Cây thông nhựa cao cấp, 300 bóng LED nhiều chế độ.', 990000, N'Còn hàng');
GO

-- Mỗi sản phẩm hai ảnh minh họa (thư mục Images đi kèm ứng dụng)
INSERT INTO HinhAnhSanPham (MaHinh, MaSP, DuongDan, ThuTu)
SELECT NEXT VALUE FOR SEQ_HinhAnh, MaSP, 'Images/' + MaSP + '_1.png', 1 FROM SanPham;
INSERT INTO HinhAnhSanPham (MaHinh, MaSP, DuongDan, ThuTu)
SELECT NEXT VALUE FOR SEQ_HinhAnh, MaSP, 'Images/' + MaSP + '_2.png', 2 FROM SanPham;
GO

INSERT INTO ThongSoKyThuat VALUES ('SP001', N'Cảm biến', N'APS-C 24.2MP');
INSERT INTO ThongSoKyThuat VALUES ('SP001', N'Quay phim', N'4K 30p');
INSERT INTO ThongSoKyThuat VALUES ('SP001', N'Trọng lượng', N'375 g');
INSERT INTO ThongSoKyThuat VALUES ('SP002', N'Cảm biến', N'1 inch 20.1MP');
INSERT INTO ThongSoKyThuat VALUES ('SP002', N'Ống kính', N'18-50mm f/1.8-4');
INSERT INTO ThongSoKyThuat VALUES ('SP003', N'Loại phim', N'Instax Mini');
INSERT INTO ThongSoKyThuat VALUES ('SP003', N'Pin', N'2 pin AA');
INSERT INTO ThongSoKyThuat VALUES ('SP004', N'Cảm biến', N'APS-C 20.9MP');
INSERT INTO ThongSoKyThuat VALUES ('SP005', N'Số chi tiết', N'1.200');
INSERT INTO ThongSoKyThuat VALUES ('SP005', N'Độ tuổi', N'12+');
INSERT INTO ThongSoKyThuat VALUES ('SP006', N'Kích thước', N'80 cm');
INSERT INTO ThongSoKyThuat VALUES ('SP007', N'Tỉ lệ', N'1:16');
INSERT INTO ThongSoKyThuat VALUES ('SP007', N'Thời gian chơi', N'25 phút / lần sạc');
INSERT INTO ThongSoKyThuat VALUES ('SP008', N'Dung tích', N'1.8 lít');
INSERT INTO ThongSoKyThuat VALUES ('SP008', N'Công suất', N'860 W');
INSERT INTO ThongSoKyThuat VALUES ('SP009', N'Màng lọc', N'HEPA H13');
INSERT INTO ThongSoKyThuat VALUES ('SP009', N'Diện tích', N'43 m2');
INSERT INTO ThongSoKyThuat VALUES ('SP010', N'Công suất', N'700 W');
INSERT INTO ThongSoKyThuat VALUES ('SP011', N'CPU', N'Intel Core i5-13500H');
INSERT INTO ThongSoKyThuat VALUES ('SP011', N'RAM', N'16 GB DDR4');
INSERT INTO ThongSoKyThuat VALUES ('SP011', N'Màn hình', N'15.6 inch OLED 2.8K');
INSERT INTO ThongSoKyThuat VALUES ('SP012', N'DPI', N'200 - 8000');
INSERT INTO ThongSoKyThuat VALUES ('SP013', N'Switch', N'Gateron Brown');
INSERT INTO ThongSoKyThuat VALUES ('SP014', N'Tần số quét', N'120 Hz');
INSERT INTO ThongSoKyThuat VALUES ('SP015', N'Gồm', N'Rượu vang, socola, thiệp');
INSERT INTO ThongSoKyThuat VALUES ('SP016', N'Chiều cao', N'1,8 m');
GO

-- Mật khẩu mẫu của mọi tài khoản: Eshop@123  (SHA-256 của Salt + MatKhau)
INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, SoGiayTo, DiaChi, DienThoai, TenDangNhap, MatKhauHash, Salt, Email, NgayDangKy)
VALUES ('KH001', N'Nguyễn Văn An', '1998-05-12', '079098001234', N'12 Lê Lợi, Quận 1', '0901234567', 'an.nv',
        'E96812255D4E348BA5BCF24BA1E07D4230B61AF2B23467415C510754C06F1184', 'A1B2C3D4E5F60718', 'an.nv@example.com', '2026-09-01');
INSERT INTO KhachHang (MaKH, HoTen, NgaySinh, SoGiayTo, DiaChi, DienThoai, TenDangNhap, MatKhauHash, Salt, Email, NgayDangKy)
VALUES ('KH002', N'Trần Thị Bình', '2000-11-20', 'C1234567', N'45 Trần Phú, Hải Châu', '0912345678', 'binh.tt',
        'AFBE3E31325C00EF0D6F0A96046EF44C267473A79635390D52765F58CB9C602B', '9F8E7D6C5B4A3921', NULL, '2026-09-15');
GO

INSERT INTO NhanVien VALUES ('NV001', N'Lê Quản Trị', 'admin',
        'E52ABE9028138C8630B6219257167D39A793C7935B84DC32B83331AA94131446', '0A1B2C3D4E5F6071', N'Quản trị');
INSERT INTO NhanVien VALUES ('NV002', N'Phạm Bán Hàng', 'banhang',
        'A7206C3BD79FA862689836B929D4CFE288B97B5B1AC2A716480B2AA216510CF9', '7766554433221100', N'Nhân viên bán hàng');
GO

INSERT INTO LoaiPhieuDatHang VALUES ('THUONG',   N'Phiếu đặt hàng thường', 72, 1000000);
INSERT INTO LoaiPhieuDatHang VALUES ('CPN',      N'Chuyển phát nhanh', 24, 1000000);
INSERT INTO LoaiPhieuDatHang VALUES ('CPN_NGAY', N'Chuyển phát nhanh trong ngày', 6, 5000000);
GO

INSERT INTO KhuVucGiaoHang VALUES ('NOITHANH', N'Nội thành TP.HCM');
INSERT INTO KhuVucGiaoHang VALUES ('MIENNAM', N'Các tỉnh miền Nam');
INSERT INTO KhuVucGiaoHang VALUES ('MIENTRUNG', N'Các tỉnh miền Trung');
INSERT INTO KhuVucGiaoHang VALUES ('MIENBAC', N'Các tỉnh miền Bắc');
GO

INSERT INTO TinhThanh VALUES ('HCM', N'TP. Hồ Chí Minh', 'NOITHANH');
INSERT INTO TinhThanh VALUES ('BD',  N'Bình Dương', 'MIENNAM');
INSERT INTO TinhThanh VALUES ('DN',  N'Đồng Nai', 'MIENNAM');
INSERT INTO TinhThanh VALUES ('CT',  N'Cần Thơ', 'MIENNAM');
INSERT INTO TinhThanh VALUES ('DNG', N'Đà Nẵng', 'MIENTRUNG');
INSERT INTO TinhThanh VALUES ('HUE', N'Huế', 'MIENTRUNG');
INSERT INTO TinhThanh VALUES ('HN',  N'Hà Nội', 'MIENBAC');
INSERT INTO TinhThanh VALUES ('HP',  N'Hải Phòng', 'MIENBAC');
GO

INSERT INTO BangPhiGiaoHang VALUES ('NOITHANH',  'THUONG',    20000);
INSERT INTO BangPhiGiaoHang VALUES ('NOITHANH',  'CPN',       35000);
INSERT INTO BangPhiGiaoHang VALUES ('NOITHANH',  'CPN_NGAY',  60000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENNAM',   'THUONG',    30000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENNAM',   'CPN',       50000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENNAM',   'CPN_NGAY',  90000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENTRUNG', 'THUONG',    40000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENTRUNG', 'CPN',       70000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENTRUNG', 'CPN_NGAY', 150000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENBAC',   'THUONG',    45000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENBAC',   'CPN',       80000);
INSERT INTO BangPhiGiaoHang VALUES ('MIENBAC',   'CPN_NGAY', 180000);
GO

INSERT INTO LoaiThe VALUES ('VISA',     N'VISA', 16, 3, 5000);
INSERT INTO LoaiThe VALUES ('MASTER',   N'MasterCard', 16, 3, 5000);
INSERT INTO LoaiThe VALUES ('DISCOVER', N'Discover', 16, 3, 8000);
INSERT INTO LoaiThe VALUES ('AMEX',     N'American Express', 15, 4, 12000);
GO

-- Thẻ đã dùng của khách mẫu (chỉ lưu số đã che + token)
INSERT INTO TheTinDung VALUES (1, 'KH001', 'VISA', '**** **** **** 1111', 12, 2028, N'NGUYEN VAN AN', 'TOK-VISA-KH001-0001');
INSERT INTO TheTinDung VALUES (2, 'KH002', 'AMEX', '**** ****** *0005', 6, 2029, N'TRAN THI BINH', 'TOK-AMEX-KH002-0001');
GO

-- Hai đơn hàng mẫu ở các trạng thái khác nhau
INSERT INTO DonDatHang (SoDonHang, MaKH, MaLoaiPhieu, ThoiDiemDat, TenNguoiNhan, DiaChiNhan, MaTinh, DienThoaiNhan,
                        TongTienHang, PhiGiaoHang, LePhiThe, MaThe, MaGiaoDich, TrangThai, DaGuiEmail)
VALUES ('DH000001', 'KH001', 'CPN', '2026-09-20 10:15:00', N'Nguyễn Thị Hoa', N'88 Nguyễn Huệ, Phú Hội', 'HUE', '0987654321',
        2940000, 0, 5000, 1, 'GD20260920101500A1', N'Đã giao', 'Y');
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000001', 'SP003', 1, 1890000);
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000001', 'SP006', 1, 450000);
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000001', 'SP016', 1, 600000);

INSERT INTO DonDatHang (SoDonHang, MaKH, MaLoaiPhieu, ThoiDiemDat, TenNguoiNhan, DiaChiNhan, MaTinh, DienThoaiNhan,
                        TongTienHang, PhiGiaoHang, LePhiThe, MaThe, MaGiaoDich, TrangThai, DaGuiEmail)
VALUES ('DH000002', 'KH002', 'THUONG', '2026-09-28 20:40:00', N'Trần Thị Bình', N'45 Trần Phú, Hải Châu', 'DNG', '0912345678',
        890000, 40000, 12000, 2, 'GD20260928204000B2', N'Chờ xử lý', 'N');
INSERT INTO ChiTietDonHang (SoDonHang, MaSP, SoLuong, DonGia) VALUES ('DH000002', 'SP007', 1, 890000);
GO

INSERT INTO NhatKyThanhToan VALUES (1, 'KH001', 'VISA', '**** **** **** 1111', 2945000, N'Chấp thuận', 'GD20260920101500A1', NULL, '2026-09-20 10:15:00');
INSERT INTO NhatKyThanhToan VALUES (2, 'KH002', 'VISA', '**** **** **** 0002', 942000, N'Từ chối', NULL, N'Thẻ không đủ khả năng thanh toán', '2026-09-28 20:38:00');
INSERT INTO NhatKyThanhToan VALUES (3, 'KH002', 'AMEX', '**** ****** *0005', 942000, N'Chấp thuận', 'GD20260928204000B2', NULL, '2026-09-28 20:40:00');
GO

INSERT INTO NhatKyEmail VALUES (1, 'DH000001', 'an.nv@example.com', N'[e-SHOPPING] Xác nhận đơn hàng DH000001',
        N'Cảm ơn quý khách đã đặt hàng tại e-SHOPPING. Đơn hàng DH000001 gồm 3 sản phẩm, tổng trị giá 2.945.000 đ.', '2026-09-20 10:15:05');
GO

-- Giỏ hàng đang mua của khách KH001
INSERT INTO GioHang (MaGioHang, MaKH, NgayTao) VALUES (1, 'KH001', DATEADD(day, -1, GETDATE()));
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES (1, 'SP012', 1);
INSERT INTO ChiTietGioHang (MaGioHang, MaSP, SoLuong) VALUES (1, 'SP015', 2);
GO

-- ---------------------------------------------------------------- 10. Kiểm tra nhanh
SELECT 'NhomSanPham' AS Bang, COUNT(*) AS SoDong FROM NhomSanPham
UNION ALL SELECT 'SanPham', COUNT(*) FROM SanPham
UNION ALL SELECT 'HinhAnhSanPham', COUNT(*) FROM HinhAnhSanPham
UNION ALL SELECT 'KhachHang', COUNT(*) FROM KhachHang
UNION ALL SELECT 'DonDatHang', COUNT(*) FROM DonDatHang
UNION ALL SELECT 'BangPhiGiaoHang', COUNT(*) FROM BangPhiGiaoHang;
GO

SELECT dbo.FN_TinhPhiGiao('HN', 'CPN', 800000)  AS Phi_HN_CPN_800k,
       dbo.FN_TinhPhiGiao('HN', 'CPN', 1200000) AS Phi_HN_CPN_1tr2,
       dbo.FN_TinhPhiGiao('HN', 'CPN_NGAY', 1200000) AS Phi_HN_NGAY_1tr2,
       dbo.FN_TinhPhiGiao('HN', 'CPN_NGAY', 5000000) AS Phi_HN_NGAY_5tr;
GO