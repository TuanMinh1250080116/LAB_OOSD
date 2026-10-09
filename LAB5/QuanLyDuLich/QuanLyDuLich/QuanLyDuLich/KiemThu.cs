using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using QuanLyDuLich.Data;
using QuanLyDuLich.Forms;
using QuanLyDuLich.Services;

namespace QuanLyDuLich
{
    /// <summary>Kịch bản kiểm thử nghiệp vụ trên CSDL thật (tự dọn dữ liệu thử) và chụp ảnh form cho báo cáo.</summary>
    internal static class KiemThu
    {
        private static readonly StringBuilder _log = new StringBuilder();
        private static int _dat, _tong;

        private static void Ghi(string ma, string moTa, bool dat, string chiTiet)
        {
            _tong++;
            if (dat) _dat++;
            _log.AppendLine(string.Format("[{0}] {1} {2} -> {3}", dat ? "PASS" : "FAIL", ma, moTa, chiTiet));
        }

        /// <summary>Ca kiểm thử mong đợi bị từ chối: đạt khi kết quả thất bại.</summary>
        private static void TuChoi(string ma, string moTa, KetQua kq)
        {
            Ghi(ma, moTa, !kq.ThanhCong, kq.ThongDiep);
        }

        private static void ChapNhan(string ma, string moTa, KetQua kq)
        {
            Ghi(ma, moTa, kq.ThanhCong, kq.ThongDiep);
        }

        private static List<NguoiDiCungDto> DanhSach(int n)
        {
            List<NguoiDiCungDto> ds = new List<NguoiDiCungDto>();
            for (int i = 1; i <= n; i++)
                ds.Add(new NguoiDiCungDto { HoTen = "Thành viên thử " + i, NgaySinh = new DateTime(1990, 1, i % 28 + 1) });
            return ds;
        }

        public static int ChayKichBan(string file)
        {
            PhieuDoanService pd = new PhieuDoanService();
            ChuyenVeService cv = new ChuyenVeService();
            PhanCongService pc = new PhanCongService();
            TourService ts = new TourService();
            BaoCaoService bc = new BaoCaoService();
            string soPhieu = null, maKD = null, maChuyen = null, soVe = null, maKL = null;
            try
            {
                Ghi("KT01", "Kết nối Oracle", true, "user " + Db.Scalar("SELECT USER FROM dual"));

                // ---- Tour
                TuChoi("KT02", "Thêm tour có số đêm không hợp lệ (3 ngày 0 đêm)", ts.Luu(new TourDto
                {
                    MaTour = "TTEST", TenTour = "Tour thử", SoNgay = 3, SoDem = 0, DonGia = 1000000, MaPTVe = "MB"
                }, true));

                // ---- Phiếu đoàn
                DateTime ngayDi = DateTime.Today.AddDays(60);
                KhachDoanDto kd = new KhachDoanDto
                {
                    TenCoQuan = "Công ty Kiểm Thử", DiaChi = "1 Đường Thử, Quận 1", DienThoai = "0281234567", NguoiDaiDien = "Người Thử"
                };
                PhieuDoanDto p = new PhieuDoanDto
                {
                    MaTour = "T002", NgayDi = ngayDi, SoNguoi = 12, DiaDiemDon = "1 Đường Thử", CoBaoHiem = false, TienCoc = 20000000
                };
                TuChoi("KT03", "Lập phiếu đoàn chỉ 12 người", pd.LapPhieu(p, kd, new List<NguoiDiCungDto>()));
                p.SoNguoi = 15;
                p.NgayDi = DateTime.Today;
                TuChoi("KT04", "Lập phiếu đoàn với ngày đi = ngày lập", pd.LapPhieu(p, kd, new List<NguoiDiCungDto>()));
                p.NgayDi = ngayDi;
                p.TienCoc = 1000000;
                TuChoi("KT05", "Lập phiếu đoàn với tiền cọc dưới 30%", pd.LapPhieu(p, kd, new List<NguoiDiCungDto>()));
                p.TienCoc = 15000000;
                p.CoBaoHiem = true;
                TuChoi("KT06", "Đoàn mua bảo hiểm nhưng danh sách chỉ 10/15 người", pd.LapPhieu(p, kd, DanhSach(10)));
                KetQua kq = pd.LapPhieu(p, kd, DanhSach(15));
                soPhieu = kq.Ma;
                ChapNhan("KT07", "Lập phiếu đoàn 15 người, khách mới, bảo hiểm đủ danh sách", kq);
                if (soPhieu != null)
                {
                    DataRow r = Db.Query("SELECT MaKD, NgayVe, TongKinhPhi, TrangThai FROM PhieuDangKyDoan WHERE SoPhieu = :So",
                                         Db.P("So", soPhieu)).Rows[0];
                    maKD = Convert.ToString(r["MaKD"]);
                    bool dung = Convert.ToDateTime(r["NgayVe"]) == ngayDi.AddDays(3) && Convert.ToDecimal(r["TongKinhPhi"]) == 15 * 3290000m
                                && Convert.ToString(r["TrangThai"]) == "Đã đặt cọc";
                    Ghi("KT08", "Trigger tính ngày về và tổng kinh phí", dung,
                        "ngày về " + Convert.ToDateTime(r["NgayVe"]).ToString("dd/MM/yyyy") + ", kinh phí " +
                        Convert.ToDecimal(r["TongKinhPhi"]).ToString("#,##0") + ", " + r["TrangThai"]);
                }
                TuChoi("KT09", "Bắt đầu tour khi đoàn chưa có hướng dẫn viên", pd.ChuyenTrangThai(soPhieu, "Đang đi"));

                // ---- Phân công
                ChapNhan("KT10", "Phân công NV06 cho đoàn", pc.PhanCong("NV06", soPhieu, null));
                kq = cv.ThemChuyen("T001", ngayDi.AddDays(1), 20);
                maChuyen = kq.Ma;
                ChapNhan("KT11", "Lập lịch chuyến khách lẻ trùng thời gian với đoàn", kq);
                TuChoi("KT12", "Phân công NV06 cho chuyến trùng lịch (chồng chéo)", pc.PhanCong("NV06", null, maChuyen));
                ChapNhan("KT13", "Phân công NV03 cho chuyến", pc.PhanCong("NV03", null, maChuyen));
                TuChoi("KT14", "Phân công thêm NV02 cho cùng chuyến khách lẻ", pc.PhanCong("NV02", null, maChuyen));
                DataTable ranh = pc.LayNhanVienRanh(ngayDi, ngayDi.AddDays(3));
                Ghi("KT15", "NV06 không còn trong danh sách nhân viên rảnh", ranh.Select("MaNV = 'NV06'").Length == 0,
                    ranh.Rows.Count + " nhân viên rảnh");

                // ---- Vòng đời phiếu
                TuChoi("KT16", "Thanh toán khi đoàn chưa đi (sai trạng thái)", pd.ChuyenTrangThai(soPhieu, "Đã thanh toán"));
                ChapNhan("KT17", "Bắt đầu tour", pd.ChuyenTrangThai(soPhieu, "Đang đi"));
                TuChoi("KT18", "Hủy mất cọc khi đoàn đang đi", pd.ChuyenTrangThai(soPhieu, "Hủy - mất cọc"));
                ChapNhan("KT19", "Kết thúc tour, gửi phiếu khảo sát", pd.ChuyenTrangThai(soPhieu, "Chờ thanh toán"));
                Ghi("KT20", "Đã tạo phiếu khảo sát cho đoàn",
                    Convert.ToInt32(Db.Scalar("SELECT COUNT(*) FROM PhieuKhaoSat WHERE SoPhieu = :So", Db.P("So", soPhieu))) == 1,
                    "1 phiếu khảo sát");
                ChapNhan("KT21", "Thanh toán kinh phí đoàn", pd.ChuyenTrangThai(soPhieu, "Đã thanh toán"));

                // ---- Bán vé khách lẻ (chuyến CH006 còn 2 chỗ)
                KhachLeDto kl = new KhachLeDto { HoTen = "Khách Lẻ Thử", SoGiayTo = "KT0000000001", DienThoai = "0909999999" };
                VeDto ve = new VeDto { MaChuyen = "CH006", MaDiemBan = "DB01", MaDiemDon = "DD01", SoNguoi = 13 };
                TuChoi("KT22", "Bán vé khách lẻ 13 người", cv.BanVe(ve, kl));
                ve.SoNguoi = 3;
                TuChoi("KT23", "Bán vé vượt số chỗ còn lại của chuyến", cv.BanVe(ve, kl));
                ve.SoNguoi = 2;
                kq = cv.BanVe(ve, kl);
                soVe = kq.Ma;
                ChapNhan("KT24", "Bán vé 2 người cho khách lẻ mới", kq);
                if (soVe != null)
                {
                    DataRow v = Db.Query("SELECT MaKL, ThanhTien FROM VeChuyen WHERE SoVe = :So", Db.P("So", soVe)).Rows[0];
                    maKL = Convert.ToString(v["MaKL"]);
                    Ghi("KT25", "Trigger tính thành tiền vé = 2 x 1.590.000", Convert.ToDecimal(v["ThanhTien"]) == 3180000m,
                        Convert.ToDecimal(v["ThanhTien"]).ToString("#,##0") + " đ");
                }
                TuChoi("KT26", "Bắt đầu chuyến CH004 chưa có hướng dẫn viên", cv.ChuyenTrangThai("CH004", "Đang đi"));

                // ---- Lương, khảo sát
                DataRow l = bc.BangLuong(9, 2026).Select("MaNV = 'NV01'")[0];
                Ghi("KT27", "Lương tháng 9/2026 của NV01 = 8.000.000 + 2.100.000",
                    Convert.ToDecimal(l["TongLuong"]) == 10100000m, Convert.ToDecimal(l["TongLuong"]).ToString("#,##0") + " đ");
                ChapNhan("KT28", "Ghi nhận phiếu khảo sát", bc.GhiNhanKhaoSat(3, 4, "Kiểm thử"));
                DataTable can = pc.LayDoanVaChuyenCanPhanCong();
                Ghi("KT29", "Danh sách đoàn và chuyến chờ phân công", can.Select("Ma = 'PD000003'").Length == 1 &&
                    can.Select("Ma = 'CH005'").Length == 1, can.Rows.Count + " đoàn/chuyến");
                Ghi("KT30", "Danh sách phiếu khảo sát", bc.LayKhaoSat().Rows.Count >= 3, bc.LayKhaoSat().Rows.Count + " phiếu");
            }
            catch (Exception ex)
            {
                Ghi("LOI", "Ngoại lệ không mong đợi", false, ex.ToString());
            }
            finally
            {
                DonDep(soPhieu, maKD, maChuyen, soVe, maKL);
            }
            _log.AppendLine(string.Format("KẾT QUẢ: {0}/{1} ca kiểm thử đạt", _dat, _tong));
            File.WriteAllText(file, _log.ToString(), Encoding.UTF8);
            return _dat == _tong ? 0 : 1;
        }

        private static void DonDep(string soPhieu, string maKD, string maChuyen, string soVe, string maKL)
        {
            try
            {
                Db.Transaction((cn, tx) =>
                {
                    Db.Execute(cn, tx, "UPDATE PhieuKhaoSat SET MucHaiLong = NULL, GopY = NULL WHERE MaKhaoSat = 3");
                    Db.Execute(cn, tx, "DELETE FROM PhieuKhaoSat WHERE SoPhieu = :So OR SoVe = :Ve", Db.P("So", soPhieu), Db.P("Ve", soVe));
                    Db.Execute(cn, tx, "DELETE FROM PhanCong WHERE SoPhieu = :So OR MaChuyen = :Ch", Db.P("So", soPhieu), Db.P("Ch", maChuyen));
                    Db.Execute(cn, tx, "DELETE FROM PhieuDangKyDoan WHERE SoPhieu = :So", Db.P("So", soPhieu));
                    Db.Execute(cn, tx, "DELETE FROM KhachDoan WHERE MaKD = :Ma", Db.P("Ma", maKD));
                    Db.Execute(cn, tx, "DELETE FROM VeChuyen WHERE SoVe = :Ve", Db.P("Ve", soVe));
                    Db.Execute(cn, tx, "DELETE FROM KhachLe WHERE MaKL = :Ma", Db.P("Ma", maKL));
                    Db.Execute(cn, tx, "DELETE FROM ChuyenDi WHERE MaChuyen = :Ch", Db.P("Ch", maChuyen));
                });
                _log.AppendLine("Đã dọn dữ liệu thử.");
            }
            catch (Exception ex)
            {
                _log.AppendLine("Lỗi khi dọn dữ liệu thử: " + ex.Message);
            }
        }

        public static int ChupAnh(string thuMuc)
        {
            Directory.CreateDirectory(thuMuc);
            List<string> loi = new List<string>();
            Action<string, Func<Form>, Action<Form>> chup = (ten, tao, chuanBi) =>
            {
                try
                {
                    using (Form f = tao())
                    {
                        f.StartPosition = FormStartPosition.Manual;
                        f.Location = new Point(40, 40);
                        f.ShowInTaskbar = false;
                        f.Show();
                        Application.DoEvents();
                        if (chuanBi != null) chuanBi(f);
                        Application.DoEvents();
                        using (Bitmap bmp = new Bitmap(f.Width, f.Height))
                        {
                            f.DrawToBitmap(bmp, new Rectangle(0, 0, f.Width, f.Height));
                            bmp.Save(Path.Combine(thuMuc, ten + ".png"), ImageFormat.Png);
                        }
                        f.Close();
                    }
                }
                catch (Exception ex)
                {
                    loi.Add(ten + ": " + ex.Message);
                }
            };
            Func<Form, string, Control> tim = (f, ten) => f.Controls.Find(ten, true)[0];
            Action<Form, string, string, string> chonDong = (f, luoi, cot, giaTri) =>
                GridHelper.ChonDong((DataGridView)tim(f, luoi), cot, giaTri);

            chup("FrmMain", () => new FrmMain(), null);
            chup("FrmTour", () => new FrmTour(), f => chonDong(f, "dgvTour", "MaTour", "T004"));
            chup("FrmPhieuDoan", () => new FrmPhieuDoan(), f =>
            {
                chonDong(f, "dgvPhieu", "SoPhieu", "PD000003");
                tim(f, "txtDiaDiemDon").Text = "12 Lý Thường Kiệt, Quận 10";
            });
            chup("FrmBanVe", () => new FrmBanVe(), f =>
            {
                chonDong(f, "dgvChuyen", "MaChuyen", "CH003");
                tim(f, "txtSoGiayTo").Text = "079200003333";
                ((Button)tim(f, "btnTimKhach")).PerformClick();
                ((NumericUpDown)tim(f, "numSoNguoi")).Value = 3;
            });
            chup("FrmPhanCong", () => new FrmPhanCong(), f => chonDong(f, "dgvCanPhanCong", "Ma", "PD000002"));
            chup("FrmLuong", () => new FrmLuongKhaoSat(), null);
            chup("FrmKhaoSat", () => new FrmLuongKhaoSat(), f => ((TabControl)tim(f, "tabMain")).SelectedIndex = 1);
            File.WriteAllLines(Path.Combine(thuMuc, "_loi.txt"), loi);
            return loi.Count == 0 ? 0 : 1;
        }
    }
}
