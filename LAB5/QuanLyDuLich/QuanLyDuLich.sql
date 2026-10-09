-- =====================================================================
-- LAB 05 – Quản lý công ty du lịch Văn Hóa Việt TP.HCM
-- Script Oracle 19c: 17 bảng, 7 sequence, 6 trigger, 1 view và dữ liệu mẫu.
-- Chạy bằng user DULICH (xem README.md):
--   set NLS_LANG=AMERICAN_AMERICA.AL32UTF8
--   sqlplus DULICH/<mật_khẩu>@localhost:1521/ORCL @QuanLyDuLich.sql
-- Script chạy lại được nhiều lần (tự xóa đối tượng cũ trước khi tạo).
-- =====================================================================
SET DEFINE OFF
SET SERVEROUTPUT ON

-- ---------------------------------------------------------------- 0. Xóa đối tượng cũ
BEGIN
  FOR t IN (SELECT table_name FROM user_tables WHERE table_name IN (
              'PHIEUKHAOSAT','PHANCONG','NHANVIEN','VECHUYEN','KHACHLE','CHUYENDI','DIEMDON','DIEMBANVE',
              'NGUOIDICUNG','PHIEUDANGKYDOAN','KHACHDOAN','TOUR_DIEMTHAMQUAN','DIEMTHAMQUAN','NOIDUNGCHAN',
              'TOUR','DIADANH','PHUONGTIEN')) LOOP
    EXECUTE IMMEDIATE 'DROP TABLE ' || t.table_name || ' CASCADE CONSTRAINTS PURGE';
  END LOOP;
  FOR s IN (SELECT sequence_name FROM user_sequences WHERE sequence_name IN (
              'SEQ_PHIEU','SEQ_VE','SEQ_CHUYEN','SEQ_KHACHDOAN','SEQ_KHACHLE','SEQ_PHANCONG','SEQ_KHAOSAT')) LOOP
    EXECUTE IMMEDIATE 'DROP SEQUENCE ' || s.sequence_name;
  END LOOP;
END;
/

-- ---------------------------------------------------------------- 1. Danh mục tour
CREATE TABLE PhuongTien (
  MaPT        VARCHAR2(10)   CONSTRAINT PK_PhuongTien PRIMARY KEY,
  TenPT       NVARCHAR2(50)  NOT NULL CONSTRAINT UQ_PhuongTien_Ten UNIQUE
);

CREATE TABLE DiaDanh (
  MaDiaDanh   VARCHAR2(10)   CONSTRAINT PK_DiaDanh PRIMARY KEY,
  TenDiaDanh  NVARCHAR2(100) NOT NULL CONSTRAINT UQ_DiaDanh_Ten UNIQUE
);

-- Mọi tour xuất phát và kết thúc tại TP.HCM; MaPTVe = phương tiện từ nơi dừng chân cuối về TP.HCM
CREATE TABLE Tour (
  MaTour      VARCHAR2(10)   CONSTRAINT PK_Tour PRIMARY KEY,
  TenTour     NVARCHAR2(200) NOT NULL,
  SoNgay      NUMBER(2)      NOT NULL CONSTRAINT CK_Tour_SoNgay CHECK (SoNgay BETWEEN 1 AND 30),
  SoDem       NUMBER(2)      NOT NULL,
  DonGia      NUMBER(12)     NOT NULL CONSTRAINT CK_Tour_DonGia CHECK (DonGia > 0),
  MaPTVe      VARCHAR2(10)   NOT NULL CONSTRAINT FK_Tour_PTVe REFERENCES PhuongTien(MaPT),
  MoTa        NVARCHAR2(1000),
  DangKinhDoanh CHAR(1)      DEFAULT 'Y' NOT NULL CONSTRAINT CK_Tour_KinhDoanh CHECK (DangKinhDoanh IN ('Y','N')),
  CONSTRAINT CK_Tour_SoDem CHECK (SoDem BETWEEN SoNgay - 1 AND SoNgay)
);

-- Nơi dừng chân thứ ThuTu của tour; MaPT = phương tiện đi tới nơi này từ nơi trước đó
CREATE TABLE NoiDungChan (
  MaTour       VARCHAR2(10)  CONSTRAINT FK_NDC_Tour REFERENCES Tour(MaTour) ON DELETE CASCADE,
  ThuTu        NUMBER(2)     CONSTRAINT CK_NDC_ThuTu CHECK (ThuTu >= 1),
  MaDiaDanh    VARCHAR2(10)  NOT NULL CONSTRAINT FK_NDC_DiaDanh REFERENCES DiaDanh(MaDiaDanh),
  MaPT         VARCHAR2(10)  NOT NULL CONSTRAINT FK_NDC_PhuongTien REFERENCES PhuongTien(MaPT),
  DoiPhuongTien CHAR(1)      DEFAULT 'N' NOT NULL CONSTRAINT CK_NDC_DoiPT CHECK (DoiPhuongTien IN ('Y','N')),
  CoNoiAn      CHAR(1)       DEFAULT 'N' NOT NULL CONSTRAINT CK_NDC_NoiAn CHECK (CoNoiAn IN ('Y','N')),
  CoKhachSan   CHAR(1)       DEFAULT 'N' NOT NULL CONSTRAINT CK_NDC_KhachSan CHECK (CoKhachSan IN ('Y','N')),
  LoaiKhachSan NUMBER(1),
  CONSTRAINT PK_NoiDungChan PRIMARY KEY (MaTour, ThuTu),
  CONSTRAINT CK_NDC_LoaiKS CHECK ((CoKhachSan = 'N' AND LoaiKhachSan IS NULL)
                               OR (CoKhachSan = 'Y' AND LoaiKhachSan BETWEEN 2 AND 5))
);

CREATE TABLE DiemThamQuan (
  MaDTQ       VARCHAR2(10)   CONSTRAINT PK_DiemThamQuan PRIMARY KEY,
  TenDTQ      NVARCHAR2(150) NOT NULL,
  DiaDiem     NVARCHAR2(200) NOT NULL,
  NoiDung     NVARCHAR2(1000),
  YNghia      NVARCHAR2(1000)
);

CREATE TABLE Tour_DiemThamQuan (
  MaTour      VARCHAR2(10)   CONSTRAINT FK_TDTQ_Tour REFERENCES Tour(MaTour) ON DELETE CASCADE,
  MaDTQ       VARCHAR2(10)   CONSTRAINT FK_TDTQ_DTQ REFERENCES DiemThamQuan(MaDTQ),
  CONSTRAINT PK_Tour_DiemThamQuan PRIMARY KEY (MaTour, MaDTQ)
);

-- ---------------------------------------------------------------- 2. Khách theo đoàn (> 12 người)
CREATE TABLE KhachDoan (
  MaKD         VARCHAR2(10)  CONSTRAINT PK_KhachDoan PRIMARY KEY,
  TenCoQuan    NVARCHAR2(200) NOT NULL,           -- tên cơ quan hoặc tên đại diện gia đình
  DiaChi       NVARCHAR2(300) NOT NULL,
  DienThoai    VARCHAR2(15)  NOT NULL CONSTRAINT CK_KhachDoan_DT CHECK (REGEXP_LIKE(DienThoai, '^[0-9]{9,15}$')),
  NguoiDaiDien NVARCHAR2(100) NOT NULL,
  Email        VARCHAR2(100)
);

CREATE TABLE PhieuDangKyDoan (
  SoPhieu     VARCHAR2(12)   CONSTRAINT PK_PhieuDangKyDoan PRIMARY KEY,
  MaKD        VARCHAR2(10)   NOT NULL CONSTRAINT FK_Phieu_KhachDoan REFERENCES KhachDoan(MaKD),
  MaTour      VARCHAR2(10)   NOT NULL CONSTRAINT FK_Phieu_Tour REFERENCES Tour(MaTour),
  NgayLap     DATE           DEFAULT TRUNC(SYSDATE) NOT NULL,
  NgayDi      DATE           NOT NULL,
  NgayVe      DATE           NOT NULL,
  SoNguoi     NUMBER(4)      NOT NULL CONSTRAINT CK_Phieu_SoNguoi CHECK (SoNguoi > 12),
  DiaDiemDon  NVARCHAR2(300) NOT NULL,
  CoBaoHiem   CHAR(1)        DEFAULT 'N' NOT NULL CONSTRAINT CK_Phieu_BaoHiem CHECK (CoBaoHiem IN ('Y','N')),
  TongKinhPhi NUMBER(14)     NOT NULL,
  TienCoc     NUMBER(14)     NOT NULL,
  TrangThai   NVARCHAR2(20)  DEFAULT N'Đã đặt cọc' NOT NULL
              CONSTRAINT CK_Phieu_TrangThai CHECK (TrangThai IN
                (N'Đã đặt cọc', N'Đang đi', N'Chờ thanh toán', N'Đã thanh toán', N'Hủy - mất cọc')),
  NgayThanhToan DATE,
  CONSTRAINT CK_Phieu_Ngay CHECK (NgayVe >= NgayDi AND NgayDi > NgayLap),
  CONSTRAINT CK_Phieu_Coc CHECK (TienCoc > 0 AND TienCoc <= TongKinhPhi)
);

-- Danh sách người cùng đi: bắt buộc khi đoàn mua bảo hiểm
CREATE TABLE NguoiDiCung (
  SoPhieu     VARCHAR2(12)   CONSTRAINT FK_NDCung_Phieu REFERENCES PhieuDangKyDoan(SoPhieu) ON DELETE CASCADE,
  STT         NUMBER(4),
  HoTen       NVARCHAR2(100) NOT NULL,
  NgaySinh    DATE           NOT NULL,
  SoGiayTo    VARCHAR2(20),
  CONSTRAINT PK_NguoiDiCung PRIMARY KEY (SoPhieu, STT)
);

-- ---------------------------------------------------------------- 3. Khách lẻ đi theo chuyến (1..12 người)
CREATE TABLE DiemBanVe (
  MaDiemBan   VARCHAR2(10)   CONSTRAINT PK_DiemBanVe PRIMARY KEY,
  TenDiemBan  NVARCHAR2(100) NOT NULL,
  DiaChi      NVARCHAR2(300) NOT NULL
);

CREATE TABLE DiemDon (
  MaDiemDon   VARCHAR2(10)   CONSTRAINT PK_DiemDon PRIMARY KEY,
  TenDiemDon  NVARCHAR2(100) NOT NULL,
  DiaChi      NVARCHAR2(300) NOT NULL
);

CREATE TABLE ChuyenDi (
  MaChuyen    VARCHAR2(12)   CONSTRAINT PK_ChuyenDi PRIMARY KEY,
  MaTour      VARCHAR2(10)   NOT NULL CONSTRAINT FK_Chuyen_Tour REFERENCES Tour(MaTour),
  NgayDi      DATE           NOT NULL,
  NgayVe      DATE           NOT NULL,
  SoChoToiDa  NUMBER(3)      NOT NULL CONSTRAINT CK_Chuyen_SoCho CHECK (SoChoToiDa BETWEEN 1 AND 200),
  TrangThai   NVARCHAR2(20)  DEFAULT N'Mở bán' NOT NULL
              CONSTRAINT CK_Chuyen_TrangThai CHECK (TrangThai IN (N'Mở bán', N'Đang đi', N'Kết thúc', N'Hủy')),
  CONSTRAINT CK_Chuyen_Ngay CHECK (NgayVe >= NgayDi),
  CONSTRAINT UQ_Chuyen_Lich UNIQUE (MaTour, NgayDi)
);

CREATE TABLE KhachLe (
  MaKL        VARCHAR2(10)   CONSTRAINT PK_KhachLe PRIMARY KEY,
  HoTen       NVARCHAR2(100) NOT NULL,
  SoGiayTo    VARCHAR2(20)   NOT NULL CONSTRAINT UQ_KhachLe_GiayTo UNIQUE,
  DienThoai   VARCHAR2(15)   NOT NULL CONSTRAINT CK_KhachLe_DT CHECK (REGEXP_LIKE(DienThoai, '^[0-9]{9,15}$')),
  DiaChi      NVARCHAR2(300)
);

CREATE TABLE VeChuyen (
  SoVe        VARCHAR2(12)   CONSTRAINT PK_VeChuyen PRIMARY KEY,
  MaChuyen    VARCHAR2(12)   NOT NULL CONSTRAINT FK_Ve_Chuyen REFERENCES ChuyenDi(MaChuyen),
  MaKL        VARCHAR2(10)   NOT NULL CONSTRAINT FK_Ve_KhachLe REFERENCES KhachLe(MaKL),
  MaDiemBan   VARCHAR2(10)   NOT NULL CONSTRAINT FK_Ve_DiemBan REFERENCES DiemBanVe(MaDiemBan),
  MaDiemDon   VARCHAR2(10)   NOT NULL CONSTRAINT FK_Ve_DiemDon REFERENCES DiemDon(MaDiemDon),
  SoNguoi     NUMBER(2)      NOT NULL CONSTRAINT CK_Ve_SoNguoi CHECK (SoNguoi BETWEEN 1 AND 12),
  DonGia      NUMBER(12)     NOT NULL,
  ThanhTien   NUMBER(14)     NOT NULL,
  NgayMua     DATE           DEFAULT SYSDATE NOT NULL,
  TrangThai   NVARCHAR2(20)  DEFAULT N'Đã thanh toán' NOT NULL
              CONSTRAINT CK_Ve_TrangThai CHECK (TrangThai IN (N'Đã thanh toán', N'Đã hủy')),
  CONSTRAINT CK_Ve_ThanhTien CHECK (ThanhTien = SoNguoi * DonGia)
);

-- ---------------------------------------------------------------- 4. Nhân viên hướng dẫn và phân công
CREATE TABLE NhanVien (
  MaNV        VARCHAR2(10)   CONSTRAINT PK_NhanVien PRIMARY KEY,
  HoTen       NVARCHAR2(100) NOT NULL,
  DienThoai   VARCHAR2(15)   NOT NULL,
  LuongCanBan NUMBER(12)     NOT NULL CONSTRAINT CK_NV_Luong CHECK (LuongCanBan > 0),
  DangLamViec CHAR(1)        DEFAULT 'Y' NOT NULL CONSTRAINT CK_NV_LamViec CHECK (DangLamViec IN ('Y','N'))
);

-- Mỗi dòng phân công đúng một trong hai: một phiếu đoàn HOẶC một chuyến khách lẻ
CREATE TABLE PhanCong (
  MaPhanCong  NUMBER         CONSTRAINT PK_PhanCong PRIMARY KEY,
  MaNV        VARCHAR2(10)   NOT NULL CONSTRAINT FK_PC_NhanVien REFERENCES NhanVien(MaNV),
  SoPhieu     VARCHAR2(12)   CONSTRAINT FK_PC_Phieu REFERENCES PhieuDangKyDoan(SoPhieu),
  MaChuyen    VARCHAR2(12)   CONSTRAINT FK_PC_Chuyen REFERENCES ChuyenDi(MaChuyen),
  NgayBatDau  DATE           NOT NULL,
  NgayKetThuc DATE           NOT NULL,
  LuongTour   NUMBER(12)     NOT NULL CONSTRAINT CK_PC_LuongTour CHECK (LuongTour >= 0),
  CONSTRAINT CK_PC_MotLoai CHECK ((SoPhieu IS NOT NULL AND MaChuyen IS NULL) OR (SoPhieu IS NULL AND MaChuyen IS NOT NULL)),
  CONSTRAINT UQ_PC_Chuyen UNIQUE (MaChuyen)           -- mỗi chuyến khách lẻ chỉ một nhân viên
);
-- Một nhân viên không được phân công hai lần cho cùng một đoàn. Không dùng UNIQUE (MaNV, SoPhieu) vì Oracle
-- coi các dòng (MaNV, NULL) là trùng nhau -> chặn nhầm nhân viên dẫn nhiều chuyến khách lẻ.
CREATE UNIQUE INDEX UX_PC_NV_Phieu ON PhanCong (CASE WHEN SoPhieu IS NOT NULL THEN MaNV END, SoPhieu);

-- Phiếu khảo sát gửi sau khi kết thúc tour: cho một phiếu đoàn HOẶC một vé khách lẻ
CREATE TABLE PhieuKhaoSat (
  MaKhaoSat   NUMBER         CONSTRAINT PK_PhieuKhaoSat PRIMARY KEY,
  SoPhieu     VARCHAR2(12)   CONSTRAINT FK_KS_Phieu REFERENCES PhieuDangKyDoan(SoPhieu),
  SoVe        VARCHAR2(12)   CONSTRAINT FK_KS_Ve REFERENCES VeChuyen(SoVe),
  NgayGui     DATE           DEFAULT SYSDATE NOT NULL,
  MucHaiLong  NUMBER(1)      CONSTRAINT CK_KS_MucHaiLong CHECK (MucHaiLong BETWEEN 1 AND 5),
  GopY        NVARCHAR2(1000),
  CONSTRAINT CK_KS_MotLoai CHECK ((SoPhieu IS NOT NULL AND SoVe IS NULL) OR (SoPhieu IS NULL AND SoVe IS NOT NULL)),
  CONSTRAINT UQ_KS_Phieu UNIQUE (SoPhieu),
  CONSTRAINT UQ_KS_Ve UNIQUE (SoVe)
);

CREATE SEQUENCE SEQ_PHIEU START WITH 100;
CREATE SEQUENCE SEQ_VE START WITH 100;
CREATE SEQUENCE SEQ_CHUYEN START WITH 100;
CREATE SEQUENCE SEQ_KHACHDOAN START WITH 100;
CREATE SEQUENCE SEQ_KHACHLE START WITH 100;
CREATE SEQUENCE SEQ_PHANCONG START WITH 100;
CREATE SEQUENCE SEQ_KHAOSAT START WITH 100;

-- ---------------------------------------------------------------- 5. Trigger nghiệp vụ
-- (a) Phiếu đoàn: ngày về = ngày đi + số ngày - 1, tổng kinh phí = số người x đơn giá tour
CREATE OR REPLACE TRIGGER TRG_Phieu_TinhToan
BEFORE INSERT ON PhieuDangKyDoan
FOR EACH ROW
DECLARE
  v_ngay Tour.SoNgay%TYPE;
  v_gia  Tour.DonGia%TYPE;
BEGIN
  SELECT SoNgay, DonGia INTO v_ngay, v_gia FROM Tour WHERE MaTour = :NEW.MaTour;
  :NEW.NgayVe := :NEW.NgayDi + v_ngay - 1;
  IF :NEW.TongKinhPhi IS NULL THEN
    :NEW.TongKinhPhi := :NEW.SoNguoi * v_gia;
  END IF;
END;
/

-- (b) Chuyển trạng thái phiếu đoàn đúng biểu đồ trạng thái
CREATE OR REPLACE TRIGGER TRG_Phieu_TrangThai
BEFORE UPDATE OF TrangThai ON PhieuDangKyDoan
FOR EACH ROW
DECLARE
  v_dem NUMBER;
BEGIN
  IF :OLD.TrangThai = :NEW.TrangThai THEN
    RETURN;
  END IF;
  IF NOT ((:OLD.TrangThai = N'Đã đặt cọc'     AND :NEW.TrangThai IN (N'Đang đi', N'Hủy - mất cọc'))
       OR (:OLD.TrangThai = N'Đang đi'        AND :NEW.TrangThai = N'Chờ thanh toán')
       OR (:OLD.TrangThai = N'Chờ thanh toán' AND :NEW.TrangThai = N'Đã thanh toán')) THEN
    RAISE_APPLICATION_ERROR(-20010, 'Khong the chuyen phieu tu "' || :OLD.TrangThai || '" sang "' || :NEW.TrangThai || '"');
  END IF;
  IF :NEW.TrangThai = N'Đang đi' THEN
    SELECT COUNT(*) INTO v_dem FROM PhanCong WHERE SoPhieu = :NEW.SoPhieu;
    IF v_dem = 0 THEN
      RAISE_APPLICATION_ERROR(-20011, 'Doan chua duoc phan cong nhan vien huong dan');
    END IF;
    IF :NEW.CoBaoHiem = 'Y' THEN
      SELECT COUNT(*) INTO v_dem FROM NguoiDiCung WHERE SoPhieu = :NEW.SoPhieu;
      IF v_dem <> :NEW.SoNguoi THEN
        RAISE_APPLICATION_ERROR(-20012, 'Doan mua bao hiem: danh sach nguoi cung di phai du ' || :NEW.SoNguoi || ' nguoi');
      END IF;
    END IF;
  END IF;
  IF :NEW.TrangThai = N'Đã thanh toán' THEN
    :NEW.NgayThanhToan := TRUNC(SYSDATE);
  END IF;
END;
/

-- (c) Vé khách lẻ: lấy đơn giá tour, tính thành tiền; chỉ bán khi chuyến đang mở bán
CREATE OR REPLACE TRIGGER TRG_Ve_TinhTien
BEFORE INSERT ON VeChuyen
FOR EACH ROW
DECLARE
  v_gia Tour.DonGia%TYPE;
  v_tt  ChuyenDi.TrangThai%TYPE;
BEGIN
  SELECT t.DonGia, c.TrangThai INTO v_gia, v_tt
    FROM ChuyenDi c JOIN Tour t ON t.MaTour = c.MaTour WHERE c.MaChuyen = :NEW.MaChuyen;
  IF v_tt <> N'Mở bán' THEN
    RAISE_APPLICATION_ERROR(-20020, 'Chuyen ' || :NEW.MaChuyen || ' khong con mo ban');
  END IF;
  :NEW.DonGia := v_gia;
  :NEW.ThanhTien := :NEW.SoNguoi * v_gia;
END;
/

-- (d) Không bán quá số chỗ của chuyến (trigger mức câu lệnh nên được đọc lại bảng VeChuyen)
CREATE OR REPLACE TRIGGER TRG_Ve_SoCho
AFTER INSERT OR UPDATE ON VeChuyen
DECLARE
  v_ma ChuyenDi.MaChuyen%TYPE;
BEGIN
  SELECT MAX(c.MaChuyen) INTO v_ma
    FROM ChuyenDi c
   WHERE c.SoChoToiDa < (SELECT NVL(SUM(v.SoNguoi), 0) FROM VeChuyen v
                          WHERE v.MaChuyen = c.MaChuyen AND v.TrangThai = N'Đã thanh toán');
  IF v_ma IS NOT NULL THEN
    RAISE_APPLICATION_ERROR(-20021, 'Chuyen ' || v_ma || ' khong du cho trong');
  END IF;
END;
/

-- (e) Phân công: lấy ngày bắt đầu/kết thúc từ phiếu hoặc chuyến; lương tour = 300.000 đ x số ngày
CREATE OR REPLACE TRIGGER TRG_PhanCong_Ngay
BEFORE INSERT ON PhanCong
FOR EACH ROW
BEGIN
  IF :NEW.SoPhieu IS NOT NULL THEN
    SELECT NgayDi, NgayVe INTO :NEW.NgayBatDau, :NEW.NgayKetThuc FROM PhieuDangKyDoan WHERE SoPhieu = :NEW.SoPhieu;
  ELSE
    SELECT NgayDi, NgayVe INTO :NEW.NgayBatDau, :NEW.NgayKetThuc FROM ChuyenDi WHERE MaChuyen = :NEW.MaChuyen;
  END IF;
  IF :NEW.LuongTour IS NULL THEN
    :NEW.LuongTour := 300000 * (:NEW.NgayKetThuc - :NEW.NgayBatDau + 1);
  END IF;
END;
/

-- (f) Lịch phân công của một nhân viên không được chồng chéo
CREATE OR REPLACE TRIGGER TRG_PhanCong_ChongCheo
AFTER INSERT OR UPDATE ON PhanCong
DECLARE
  v_nv NhanVien.MaNV%TYPE;
BEGIN
  SELECT MAX(a.MaNV) INTO v_nv
    FROM PhanCong a JOIN PhanCong b
      ON a.MaNV = b.MaNV AND a.MaPhanCong < b.MaPhanCong
     AND a.NgayBatDau <= b.NgayKetThuc AND b.NgayBatDau <= a.NgayKetThuc;
  IF v_nv IS NOT NULL THEN
    RAISE_APPLICATION_ERROR(-20030, 'Nhan vien ' || v_nv || ' bi trung lich phan cong');
  END IF;
END;
/

-- ---------------------------------------------------------------- 6. View lương tour theo tháng
-- Lương tháng = lương căn bản + tổng lương các tour kết thúc trong tháng (bỏ phiếu đoàn bị hủy, chuyến bị hủy)
CREATE OR REPLACE VIEW V_LuongTourThang AS
SELECT pc.MaNV,
       EXTRACT(YEAR FROM pc.NgayKetThuc)  AS Nam,
       EXTRACT(MONTH FROM pc.NgayKetThuc) AS Thang,
       COUNT(*)                           AS SoTour,
       SUM(pc.LuongTour)                  AS TongLuongTour
  FROM PhanCong pc
  LEFT JOIN PhieuDangKyDoan p ON p.SoPhieu = pc.SoPhieu
  LEFT JOIN ChuyenDi c ON c.MaChuyen = pc.MaChuyen
 WHERE NVL(p.TrangThai, N'x') <> N'Hủy - mất cọc' AND NVL(c.TrangThai, N'x') <> N'Hủy'
 GROUP BY pc.MaNV, EXTRACT(YEAR FROM pc.NgayKetThuc), EXTRACT(MONTH FROM pc.NgayKetThuc);

-- ---------------------------------------------------------------- 7. Dữ liệu mẫu
INSERT INTO PhuongTien VALUES ('MB', N'Máy bay');
INSERT INTO PhuongTien VALUES ('XD', N'Xe đò');
INSERT INTO PhuongTien VALUES ('TH', N'Tàu hỏa');
INSERT INTO PhuongTien VALUES ('XK', N'Xe khách du lịch');
INSERT INTO PhuongTien VALUES ('TC', N'Tàu cao tốc');

INSERT INTO DiaDanh VALUES ('HCM', N'TP. Hồ Chí Minh');
INSERT INTO DiaDanh VALUES ('DL',  N'Đà Lạt');
INSERT INTO DiaDanh VALUES ('NT',  N'Nha Trang');
INSERT INTO DiaDanh VALUES ('PQ',  N'Phú Quốc');
INSERT INTO DiaDanh VALUES ('HN',  N'Hà Nội');
INSERT INTO DiaDanh VALUES ('HL',  N'Hạ Long');
INSERT INTO DiaDanh VALUES ('CT',  N'Cần Thơ');
INSERT INTO DiaDanh VALUES ('CD',  N'Châu Đốc');
INSERT INTO DiaDanh VALUES ('HUE', N'Huế');
INSERT INTO DiaDanh VALUES ('DN',  N'Đà Nẵng');

INSERT INTO Tour VALUES ('T001', N'Đà Lạt – Thành phố ngàn hoa', 3, 2, 2490000, 'XK', N'Tham quan Đà Lạt bằng xe giường nằm', 'Y');
INSERT INTO Tour VALUES ('T002', N'Nha Trang – Biển xanh', 4, 3, 3290000, 'TH', N'Đi tàu hỏa SE, nghỉ khách sạn 4 sao', 'Y');
INSERT INTO Tour VALUES ('T003', N'Phú Quốc – Đảo ngọc', 3, 2, 5490000, 'MB', N'Bay khứ hồi, nghỉ resort 5 sao', 'Y');
INSERT INTO Tour VALUES ('T004', N'Hà Nội – Hạ Long', 5, 4, 7990000, 'MB', N'Bay ra Hà Nội, xe đi Hạ Long, ngủ du thuyền', 'Y');
INSERT INTO Tour VALUES ('T005', N'Miền Tây sông nước', 2, 1, 1590000, 'XK', N'Cần Thơ – Châu Đốc', 'Y');
INSERT INTO Tour VALUES ('T006', N'Huế – Đà Nẵng – Hội An', 4, 3, 6490000, 'MB', N'Di sản miền Trung', 'Y');

-- (MaTour, ThuTu, MaDiaDanh, MaPT, DoiPT, CoNoiAn, CoKhachSan, LoaiKS)
INSERT INTO NoiDungChan VALUES ('T001', 1, 'DL',  'XK', 'N', 'Y', 'Y', 3);
INSERT INTO NoiDungChan VALUES ('T002', 1, 'NT',  'TH', 'N', 'Y', 'Y', 4);
INSERT INTO NoiDungChan VALUES ('T003', 1, 'PQ',  'MB', 'N', 'Y', 'Y', 5);
INSERT INTO NoiDungChan VALUES ('T004', 1, 'HN',  'MB', 'Y', 'Y', 'Y', 4);
INSERT INTO NoiDungChan VALUES ('T004', 2, 'HL',  'XD', 'Y', 'Y', 'Y', 5);
INSERT INTO NoiDungChan VALUES ('T004', 3, 'HN',  'XD', 'Y', 'Y', 'N', NULL);
INSERT INTO NoiDungChan VALUES ('T005', 1, 'CT',  'XK', 'N', 'Y', 'Y', 3);
INSERT INTO NoiDungChan VALUES ('T005', 2, 'CD',  'XK', 'N', 'Y', 'N', NULL);
INSERT INTO NoiDungChan VALUES ('T006', 1, 'HUE', 'MB', 'Y', 'Y', 'Y', 4);
INSERT INTO NoiDungChan VALUES ('T006', 2, 'DN',  'TH', 'Y', 'Y', 'Y', 4);

INSERT INTO DiemThamQuan VALUES ('DTQ01', N'Thung lũng Tình Yêu', N'Đà Lạt', N'Hồ Đa Thiện, đồi thông', N'Danh lam thắng cảnh');
INSERT INTO DiemThamQuan VALUES ('DTQ02', N'Dinh Bảo Đại', N'Đà Lạt', N'Dinh thự vua Bảo Đại', N'Di tích lịch sử');
INSERT INTO DiemThamQuan VALUES ('DTQ03', N'Tháp Bà Ponagar', N'Nha Trang', N'Quần thể tháp Chăm', N'Di tích kiến trúc – nghệ thuật quốc gia');
INSERT INTO DiemThamQuan VALUES ('DTQ04', N'Nhà tù Phú Quốc', N'Phú Quốc', N'Khu di tích nhà tù Cây Dừa', N'Di tích lịch sử quốc gia đặc biệt');
INSERT INTO DiemThamQuan VALUES ('DTQ05', N'Vịnh Hạ Long', N'Quảng Ninh', N'Du thuyền trên vịnh', N'Di sản thiên nhiên thế giới');
INSERT INTO DiemThamQuan VALUES ('DTQ06', N'Lăng Chủ tịch Hồ Chí Minh', N'Hà Nội', N'Viếng lăng Bác', N'Di tích lịch sử');
INSERT INTO DiemThamQuan VALUES ('DTQ07', N'Chợ nổi Cái Răng', N'Cần Thơ', N'Chợ trên sông', N'Văn hóa sông nước');
INSERT INTO DiemThamQuan VALUES ('DTQ08', N'Miếu Bà Chúa Xứ', N'Châu Đốc', N'Núi Sam', N'Di tích tín ngưỡng');
INSERT INTO DiemThamQuan VALUES ('DTQ09', N'Đại Nội Huế', N'Huế', N'Hoàng thành triều Nguyễn', N'Di sản văn hóa thế giới');
INSERT INTO DiemThamQuan VALUES ('DTQ10', N'Phố cổ Hội An', N'Quảng Nam', N'Phố cổ, chùa Cầu', N'Di sản văn hóa thế giới');

INSERT INTO Tour_DiemThamQuan VALUES ('T001', 'DTQ01');
INSERT INTO Tour_DiemThamQuan VALUES ('T001', 'DTQ02');
INSERT INTO Tour_DiemThamQuan VALUES ('T002', 'DTQ03');
INSERT INTO Tour_DiemThamQuan VALUES ('T003', 'DTQ04');
INSERT INTO Tour_DiemThamQuan VALUES ('T004', 'DTQ05');
INSERT INTO Tour_DiemThamQuan VALUES ('T004', 'DTQ06');
INSERT INTO Tour_DiemThamQuan VALUES ('T005', 'DTQ07');
INSERT INTO Tour_DiemThamQuan VALUES ('T005', 'DTQ08');
INSERT INTO Tour_DiemThamQuan VALUES ('T006', 'DTQ09');
INSERT INTO Tour_DiemThamQuan VALUES ('T006', 'DTQ10');

INSERT INTO KhachDoan VALUES ('KD001', N'Công ty TNHH Phần mềm Sao Việt', N'12 Lý Thường Kiệt, Quận 10', '02838123456', N'Trần Văn Hùng', 'hr@saoviet.vn');
INSERT INTO KhachDoan VALUES ('KD002', N'Trường THPT Nguyễn Du', N'45 Nguyễn Văn Cừ, Quận 5', '02839234567', N'Lê Thị Mai', NULL);
INSERT INTO KhachDoan VALUES ('KD003', N'Gia đình ông Phạm Quốc Bảo', N'88 Võ Văn Tần, Quận 3', '0909123456', N'Phạm Quốc Bảo', 'bao.pq@gmail.com');

INSERT INTO NhanVien VALUES ('NV01', N'Nguyễn Thanh Tâm', '0901000001', 8000000, 'Y');
INSERT INTO NhanVien VALUES ('NV02', N'Lê Hoàng Phúc', '0901000002', 8500000, 'Y');
INSERT INTO NhanVien VALUES ('NV03', N'Trần Ngọc Ánh', '0901000003', 7500000, 'Y');
INSERT INTO NhanVien VALUES ('NV04', N'Võ Minh Khang', '0901000004', 7500000, 'Y');
INSERT INTO NhanVien VALUES ('NV05', N'Đặng Thu Hà', '0901000005', 9000000, 'Y');
INSERT INTO NhanVien VALUES ('NV06', N'Huỳnh Gia Bảo', '0901000006', 7000000, 'Y');

INSERT INTO DiemBanVe VALUES ('DB01', N'Văn phòng chính', N'190 Pasteur, Quận 3');
INSERT INTO DiemBanVe VALUES ('DB02', N'Điểm bán Thủ Đức', N'15 Võ Văn Ngân, TP. Thủ Đức');
INSERT INTO DiemBanVe VALUES ('DB03', N'Điểm bán Gò Vấp', N'300 Quang Trung, Gò Vấp');
INSERT INTO DiemDon VALUES ('DD01', N'Nhà văn hóa Thanh Niên', N'4 Phạm Ngọc Thạch, Quận 1');
INSERT INTO DiemDon VALUES ('DD02', N'Ngã tư Thủ Đức', N'Xa lộ Hà Nội, TP. Thủ Đức');
INSERT INTO DiemDon VALUES ('DD03', N'Sân bay Tân Sơn Nhất', N'Ga quốc nội, Tân Bình');

-- Chuyến khách lẻ: đã đi tháng 9 và mở bán tháng 10–11/2026
INSERT INTO ChuyenDi VALUES ('CH001', 'T001', DATE '2026-09-11', DATE '2026-09-13', 30, N'Kết thúc');
INSERT INTO ChuyenDi VALUES ('CH002', 'T005', DATE '2026-09-19', DATE '2026-09-20', 30, N'Kết thúc');
INSERT INTO ChuyenDi VALUES ('CH003', 'T001', DATE '2026-10-23', DATE '2026-10-25', 30, N'Mở bán');
INSERT INTO ChuyenDi VALUES ('CH004', 'T002', DATE '2026-10-30', DATE '2026-11-02', 25, N'Mở bán');
INSERT INTO ChuyenDi VALUES ('CH005', 'T003', DATE '2026-11-06', DATE '2026-11-08', 20, N'Mở bán');
INSERT INTO ChuyenDi VALUES ('CH006', 'T005', DATE '2026-11-14', DATE '2026-11-15', 12, N'Mở bán');

INSERT INTO KhachLe VALUES ('KL001', N'Nguyễn Minh Anh', '079200001111', '0912000001', N'Quận 1');
INSERT INTO KhachLe VALUES ('KL002', N'Bùi Thị Lan', '079200002222', '0912000002', N'Thủ Đức');
INSERT INTO KhachLe VALUES ('KL003', N'Trương Quốc Việt', '079200003333', '0912000003', N'Gò Vấp');
INSERT INTO KhachLe VALUES ('KL004', N'Phan Thảo Nhi', '079200004444', '0912000004', N'Bình Thạnh');

-- Vé tháng 9 bán trước khi chuyến kết thúc: tạm mở bán để trigger (c) chấp nhận
UPDATE ChuyenDi SET TrangThai = N'Mở bán' WHERE MaChuyen IN ('CH001','CH002');
INSERT INTO VeChuyen (SoVe, MaChuyen, MaKL, MaDiemBan, MaDiemDon, SoNguoi, NgayMua) VALUES ('VE000001', 'CH001', 'KL001', 'DB01', 'DD01', 2, DATE '2026-09-01');
INSERT INTO VeChuyen (SoVe, MaChuyen, MaKL, MaDiemBan, MaDiemDon, SoNguoi, NgayMua) VALUES ('VE000002', 'CH001', 'KL002', 'DB02', 'DD02', 4, DATE '2026-09-03');
INSERT INTO VeChuyen (SoVe, MaChuyen, MaKL, MaDiemBan, MaDiemDon, SoNguoi, NgayMua) VALUES ('VE000003', 'CH002', 'KL003', 'DB03', 'DD01', 3, DATE '2026-09-10');
INSERT INTO VeChuyen (SoVe, MaChuyen, MaKL, MaDiemBan, MaDiemDon, SoNguoi, NgayMua) VALUES ('VE000004', 'CH003', 'KL004', 'DB01', 'DD01', 2, DATE '2026-10-05');
INSERT INTO VeChuyen (SoVe, MaChuyen, MaKL, MaDiemBan, MaDiemDon, SoNguoi, NgayMua) VALUES ('VE000005', 'CH003', 'KL001', 'DB02', 'DD02', 5, DATE '2026-10-06');
INSERT INTO VeChuyen (SoVe, MaChuyen, MaKL, MaDiemBan, MaDiemDon, SoNguoi, NgayMua) VALUES ('VE000006', 'CH006', 'KL002', 'DB03', 'DD01', 10, DATE '2026-10-07');
UPDATE ChuyenDi SET TrangThai = N'Kết thúc' WHERE MaChuyen IN ('CH001','CH002');

-- Phiếu đoàn (NgayVe/TongKinhPhi do trigger (a) tính)
INSERT INTO PhieuDangKyDoan (SoPhieu, MaKD, MaTour, NgayLap, NgayDi, NgayVe, SoNguoi, DiaDiemDon, CoBaoHiem, TongKinhPhi, TienCoc)
  VALUES ('PD000001', 'KD001', 'T002', DATE '2026-08-20', DATE '2026-09-04', DATE '2026-09-04', 35, N'12 Lý Thường Kiệt, Quận 10', 'N', NULL, 30000000);
INSERT INTO PhieuDangKyDoan (SoPhieu, MaKD, MaTour, NgayLap, NgayDi, NgayVe, SoNguoi, DiaDiemDon, CoBaoHiem, TongKinhPhi, TienCoc)
  VALUES ('PD000002', 'KD002', 'T005', DATE '2026-10-01', DATE '2026-10-24', DATE '2026-10-24', 40, N'Cổng trường THPT Nguyễn Du', 'N', NULL, 20000000);
INSERT INTO PhieuDangKyDoan (SoPhieu, MaKD, MaTour, NgayLap, NgayDi, NgayVe, SoNguoi, DiaDiemDon, CoBaoHiem, TongKinhPhi, TienCoc)
  VALUES ('PD000003', 'KD003', 'T003', DATE '2026-10-02', DATE '2026-11-20', DATE '2026-11-20', 14, N'88 Võ Văn Tần, Quận 3', 'Y', NULL, 25000000);
INSERT INTO NguoiDiCung VALUES ('PD000003', 1,  N'Phạm Quốc Bảo',   DATE '1975-03-12', '079075000001');
INSERT INTO NguoiDiCung VALUES ('PD000003', 2,  N'Nguyễn Thị Hạnh', DATE '1978-07-01', '079178000002');
INSERT INTO NguoiDiCung VALUES ('PD000003', 3,  N'Phạm Gia Huy',    DATE '2003-05-20', '079203000003');
INSERT INTO NguoiDiCung VALUES ('PD000003', 4,  N'Phạm Ngọc Hân',   DATE '2008-09-09', NULL);

-- Phân công (ngày và lương tour do trigger (e) tính)
INSERT INTO PhanCong (MaPhanCong, MaNV, SoPhieu, MaChuyen, NgayBatDau, NgayKetThuc, LuongTour) VALUES (1, 'NV01', 'PD000001', NULL, SYSDATE, SYSDATE, NULL);
INSERT INTO PhanCong (MaPhanCong, MaNV, SoPhieu, MaChuyen, NgayBatDau, NgayKetThuc, LuongTour) VALUES (2, 'NV02', 'PD000001', NULL, SYSDATE, SYSDATE, NULL);
INSERT INTO PhanCong (MaPhanCong, MaNV, SoPhieu, MaChuyen, NgayBatDau, NgayKetThuc, LuongTour) VALUES (3, 'NV01', NULL, 'CH001', SYSDATE, SYSDATE, NULL);
INSERT INTO PhanCong (MaPhanCong, MaNV, SoPhieu, MaChuyen, NgayBatDau, NgayKetThuc, LuongTour) VALUES (4, 'NV03', NULL, 'CH002', SYSDATE, SYSDATE, NULL);
INSERT INTO PhanCong (MaPhanCong, MaNV, SoPhieu, MaChuyen, NgayBatDau, NgayKetThuc, LuongTour) VALUES (5, 'NV04', 'PD000002', NULL, SYSDATE, SYSDATE, NULL);
INSERT INTO PhanCong (MaPhanCong, MaNV, SoPhieu, MaChuyen, NgayBatDau, NgayKetThuc, LuongTour) VALUES (6, 'NV05', NULL, 'CH003', SYSDATE, SYSDATE, NULL);

-- Phiếu PD000001 đã đi xong và thanh toán (đi qua đủ các trạng thái)
UPDATE PhieuDangKyDoan SET TrangThai = N'Đang đi' WHERE SoPhieu = 'PD000001';
UPDATE PhieuDangKyDoan SET TrangThai = N'Chờ thanh toán' WHERE SoPhieu = 'PD000001';
UPDATE PhieuDangKyDoan SET TrangThai = N'Đã thanh toán' WHERE SoPhieu = 'PD000001';
UPDATE PhieuDangKyDoan SET NgayThanhToan = DATE '2026-09-10' WHERE SoPhieu = 'PD000001';

INSERT INTO PhieuKhaoSat VALUES (1, 'PD000001', NULL, DATE '2026-09-09', 5, N'Hướng dẫn viên nhiệt tình, khách sạn sạch đẹp');
INSERT INTO PhieuKhaoSat VALUES (2, NULL, 'VE000001', DATE '2026-09-14', 4, N'Xe hơi chật, nên đổi xe 45 chỗ');
INSERT INTO PhieuKhaoSat VALUES (3, NULL, 'VE000003', DATE '2026-09-21', NULL, NULL);

COMMIT;

PROMPT ===== Kiem tra so dong =====
SELECT 'Tour' AS Bang, COUNT(*) AS SoDong FROM Tour
UNION ALL SELECT 'NoiDungChan', COUNT(*) FROM NoiDungChan
UNION ALL SELECT 'ChuyenDi', COUNT(*) FROM ChuyenDi
UNION ALL SELECT 'VeChuyen', COUNT(*) FROM VeChuyen
UNION ALL SELECT 'PhieuDangKyDoan', COUNT(*) FROM PhieuDangKyDoan
UNION ALL SELECT 'PhanCong', COUNT(*) FROM PhanCong
UNION ALL SELECT 'PhieuKhaoSat', COUNT(*) FROM PhieuKhaoSat;
