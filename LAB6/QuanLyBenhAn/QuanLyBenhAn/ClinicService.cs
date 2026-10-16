using System;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBenhAn
{
    internal static class ClinicService
    {
        internal static string Register(string name, string address, DateTime birthday, string phone, string photo, decimal fee)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(address) || !System.Text.RegularExpressions.Regex.IsMatch(phone, "^[0-9]{9,15}$"))
                throw new ArgumentException("Cần họ tên, địa chỉ và số điện thoại 9–15 chữ số.");
            if (birthday.Date >= DateTime.Today || fee <= 0) throw new ArgumentException("Ngày sinh hoặc lệ phí không hợp lệ.");
            return Db.Atomic((cn, tx) =>
            {
                string bn = Db.Id(cn, tx, "SEQ_BN", "BN"), dk = Db.Id(cn, tx, "SEQ_DK", "DK");
                string hs = Db.Id(cn, tx, "SEQ_HS", "HS"), thu = Db.Id(cn, tx, "SEQ_THU", "TH");
                Db.Exec(cn, tx, "INSERT INTO BenhNhan VALUES(@bn,@name,@addr,@birth,@phone,@photo)",
                    Db.P("bn",bn),Db.P("name",name),Db.P("addr",address),Db.P("birth",birthday.Date),Db.P("phone",phone),Db.P("photo",photo));
                Db.Exec(cn, tx, "INSERT INTO PhieuDangKy(MaDK,MaBN,NamApDung) VALUES(@dk,@bn,@year)",
                    Db.P("dk",dk),Db.P("bn",bn),Db.P("year",DateTime.Today.Year));
                Db.Exec(cn, tx, "INSERT INTO PhiThu(MaThu,MaDK,SoTien) VALUES(@thu,@dk,@fee)",
                    Db.P("thu",thu),Db.P("dk",dk),Db.P("fee",fee));
                Db.Exec(cn, tx, "INSERT INTO HoSoBenhAn(MaHS,MaBN) VALUES(@hs,@bn)",Db.P("hs",hs),Db.P("bn",bn));
                return hs;
            });
        }

        internal static string RenewFee(string record, decimal fee)
        {
            if (fee<=0) throw new ArgumentException("Lệ phí phải lớn hơn 0.");
            return Db.Atomic((cn,tx)=>
            {
                CheckRecord(cn,tx,record,false);
                string patient;
                using(var cmd=Db.Command(cn,tx,"SELECT MaBN FROM HoSoBenhAn WHERE MaHS=@hs",Db.P("hs",record)))
                    patient=cmd.ExecuteScalar().ToString();
                using(var cmd=Db.Command(cn,tx,"SELECT COUNT(*) FROM PhieuDangKy WHERE MaBN=@bn AND NamApDung=@year",
                    Db.P("bn",patient),Db.P("year",DateTime.Today.Year)))
                    if(Convert.ToInt32(cmd.ExecuteScalar())>0) throw new InvalidOperationException("Năm hiện tại đã có phiếu đăng ký phí.");
                string registration=Db.Id(cn,tx,"SEQ_DK","DK");
                string receipt=Db.Id(cn,tx,"SEQ_THU","TH");
                Db.Exec(cn,tx,"INSERT INTO PhieuDangKy(MaDK,MaBN,NamApDung) VALUES(@dk,@bn,@year)",
                    Db.P("dk",registration),Db.P("bn",patient),Db.P("year",DateTime.Today.Year));
                Db.Exec(cn,tx,"INSERT INTO PhiThu(MaThu,MaDK,SoTien) VALUES(@thu,@dk,@fee)",
                    Db.P("thu",receipt),Db.P("dk",registration),Db.P("fee",fee));
                return receipt;
            });
        }

        internal static DataTable Search(string keyword)
        {
            return Db.Query(@"SELECT h.MaHS, b.MaBN, b.HoTen, b.NgaySinh, b.DienThoai, b.DiaChi, h.TrangThai
                FROM HoSoBenhAn h JOIN BenhNhan b ON b.MaBN=h.MaBN
                WHERE UPPER(h.MaHS) LIKE UPPER(@q) OR UPPER(b.HoTen) LIKE UPPER(@q) OR b.DienThoai LIKE @q
                ORDER BY h.MaHS",Db.P("q","%" + keyword.Trim() + "%"));
        }

        internal static DataTable History(string record)
        {
            return Db.Query(@"SELECT k.MaKham,k.NgayGio,k.LoaiKham,bs.HoTen AS BacSi,kh.TenKhoa,k.ChanDoan,
                k.KetLuan,k.TrangThai,k.VienPhi FROM LuotKham k JOIN BacSi bs ON k.MaBS=bs.MaBS
                JOIN Khoa kh ON k.MaKhoa=kh.MaKhoa WHERE k.MaHS=@hs ORDER BY k.NgayGio DESC",Db.P("hs",record));
        }

        internal static DataTable PrescriptionHistory(string record)
        {
            return Db.Query(@"SELECT k.MaKham,t.MaToa,t.NgayKe,bs.HoTen AS BacSi,th.TenThuoc,
                c.SoLuong,th.DonVi,c.LieuDung,c.SoNgay,t.LoiDan
                FROM LuotKham k JOIN ToaThuoc t ON t.MaKham=k.MaKham
                JOIN BacSi bs ON bs.MaBS=t.MaBS JOIN ChiTietToa c ON c.MaToa=t.MaToa
                JOIN Thuoc th ON th.MaThuoc=c.MaThuoc WHERE k.MaHS=@hs ORDER BY t.NgayKe DESC",Db.P("hs",record));
        }

        internal static DataTable TestHistory(string record)
        {
            return Db.Query(@"SELECT k.MaKham,c.MaCD,x.TenXN,c.NgayChiDinh,r.KetQua,r.NgayCoKQ
                FROM LuotKham k JOIN ChiDinhXetNghiem c ON c.MaKham=k.MaKham
                JOIN LoaiXetNghiem x ON x.MaXN=c.MaXN
                LEFT JOIN KetQuaXetNghiem r ON r.MaCD=c.MaCD
                WHERE k.MaHS=@hs ORDER BY c.NgayChiDinh DESC",Db.P("hs",record));
        }

        internal static DataTable ReactionHistory(string record)
        {
            return Db.Query(@"SELECT p.MaPU,p.NgayGhiNhan,t.TenThuoc,p.MoTa,p.MucDo
                FROM PhanUngThuoc p JOIN Thuoc t ON t.MaThuoc=p.MaThuoc
                WHERE p.MaHS=@hs ORDER BY p.NgayGhiNhan DESC",Db.P("hs",record));
        }

        internal static string Appointment(string record, string doctor, DateTime time, bool periodic)
        {
            if (time <= DateTime.Now) throw new ArgumentException("Lịch hẹn phải ở tương lai.");
            return Db.Atomic((cn, tx) =>
            {
                CheckRecord(cn,tx,record,periodic,time.Year);
                if (periodic)
                {
                    int quarter = (time.Month-1)/3;
                    using (var cmd = Db.Command(cn,tx,@"SELECT COUNT(*) FROM LichHen WHERE MaHS=@hs AND LoaiKham='DINH_KY'
                        AND TrangThai<>'HUY' AND YEAR(ThoiGian)=@year
                        AND (MONTH(ThoiGian)-1)/3=@quarter",
                        Db.P("hs",record),Db.P("year",time.Year),Db.P("quarter",quarter)))
                        if (Convert.ToInt32(cmd.ExecuteScalar())>0) throw new InvalidOperationException("Quý này đã có lịch khám định kỳ.");
                }
                string id=Db.Id(cn,tx,"SEQ_HEN","LH");
                Db.Exec(cn,tx,@"INSERT INTO LichHen(MaHen,MaHS,MaBS,ThoiGian,LoaiKham)
                    VALUES(@id,@hs,@bs,@time,@type)",Db.P("id",id),Db.P("hs",record),Db.P("bs",doctor),
                    Db.P("time",time),Db.P("type",periodic?"DINH_KY":"DIEU_TRI"));
                return id;
            });
        }

        private static void CheckRecord(SqlConnection cn, SqlTransaction tx, string record, bool periodic, int year=0)
        {
            using (var cmd=Db.Command(cn,tx,"SELECT COUNT(*) FROM HoSoBenhAn WHERE MaHS=@hs AND TrangThai='HOAT_DONG'",Db.P("hs",record)))
                if (Convert.ToInt32(cmd.ExecuteScalar())==0) throw new InvalidOperationException("Không có hồ sơ đang hoạt động.");
            if (periodic)
                using (var cmd=Db.Command(cn,tx,@"SELECT COUNT(*) FROM PhieuDangKy d JOIN HoSoBenhAn h ON h.MaBN=d.MaBN
                    WHERE h.MaHS=@hs AND d.NamApDung=@year AND d.TrangThai='DA_THU'",Db.P("hs",record),Db.P("year",year)))
                    if (Convert.ToInt32(cmd.ExecuteScalar())==0) throw new InvalidOperationException("Chưa đóng lệ phí quản lý của năm hiện tại.");
        }

        internal static string StartVisit(string record, string doctor, string appointment)
        {
            return Db.Atomic((cn,tx)=>
            {
                CheckRecord(cn,tx,record,false);
                string type="DIEU_TRI";
                if (!string.IsNullOrWhiteSpace(appointment))
                {
                    using(var cmd=Db.Command(cn,tx,@"SELECT LoaiKham FROM LichHen WHERE MaHen=@hen AND MaHS=@hs
                        AND MaBS=@bs AND TrangThai='DA_HEN'",Db.P("hen",appointment),Db.P("hs",record),Db.P("bs",doctor)))
                    { var value=cmd.ExecuteScalar(); if(value==null) throw new InvalidOperationException("Lịch hẹn không hợp lệ."); type=value.ToString(); }
                    Db.Exec(cn,tx,"UPDATE LichHen SET TrangThai='DA_DEN' WHERE MaHen=@hen",Db.P("hen",appointment));
                }
                string id=Db.Id(cn,tx,"SEQ_KHAM","LK");
                Db.Exec(cn,tx,@"INSERT INTO LuotKham(MaKham,MaHS,MaHen,MaBS,MaKhoa,LoaiKham)
                    SELECT @id,@hs,@hen,b.MaBS,b.MaKhoa,@type FROM BacSi b WHERE b.MaBS=@bs",
                    Db.P("id",id),Db.P("hs",record),Db.P("hen",string.IsNullOrWhiteSpace(appointment)?null:appointment),
                    Db.P("type",type),Db.P("bs",doctor));
                return id;
            });
        }

        internal static void Symptom(string visit, string description, decimal? temp, string pressure, string diagnosis)
        {
            if(string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Cần mô tả triệu chứng hoặc kết quả khám.");
            Db.Atomic((cn,tx)=>
            {
                AssertVisit(cn,tx,visit,"DANG_KHAM");
                Db.Exec(cn,tx,"INSERT INTO TrieuChung VALUES(@id,@visit,@description,@temp,@pressure)",
                    Db.P("id",Db.Id(cn,tx,"SEQ_TRIEU","TC")),Db.P("visit",visit),Db.P("description",description),
                    Db.P("temp",temp),Db.P("pressure",pressure));
                Db.Exec(cn,tx,"UPDATE LuotKham SET ChanDoan=@diagnosis WHERE MaKham=@visit",Db.P("diagnosis",diagnosis),Db.P("visit",visit));
                return 0;
            });
        }

        private static void AssertVisit(SqlConnection cn,SqlTransaction tx,string visit,params string[] allowed)
        {
            using(var cmd=Db.Command(cn,tx,"SELECT TrangThai FROM LuotKham WITH (UPDLOCK) WHERE MaKham=@visit",Db.P("visit",visit)))
            { var value=cmd.ExecuteScalar(); if(value==null || Array.IndexOf(allowed,value.ToString())<0)
                throw new InvalidOperationException("Trạng thái lượt khám không cho phép thao tác này."); }
        }

        internal static string OrderTest(string visit,string doctor,string test)
        {
            return Db.Atomic((cn,tx)=>
            {
                AssertVisit(cn,tx,visit,"DANG_KHAM","CHO_XET_NGHIEM");
                string id=Db.Id(cn,tx,"SEQ_CD","CD");
                Db.Exec(cn,tx,"INSERT INTO ChiDinhXetNghiem(MaCD,MaKham,MaXN,MaBS) VALUES(@id,@visit,@test,@bs)",
                    Db.P("id",id),Db.P("visit",visit),Db.P("test",test),Db.P("bs",doctor));
                Db.Exec(cn,tx,"UPDATE LuotKham SET TrangThai='CHO_XET_NGHIEM' WHERE MaKham=@visit",Db.P("visit",visit));
                return id;
            });
        }

        internal static string TestResult(string order,string result)
        {
            if(string.IsNullOrWhiteSpace(result)) throw new ArgumentException("Kết quả xét nghiệm không được trống.");
            return Db.Atomic((cn,tx)=>
            {
                string visit;
                using(var cmd=Db.Command(cn,tx,"SELECT MaKham FROM ChiDinhXetNghiem WITH (UPDLOCK) WHERE MaCD=@orderId AND TrangThai='CHO_KQ'",Db.P("orderId",order)))
                { var value=cmd.ExecuteScalar(); if(value==null) throw new InvalidOperationException("Chỉ định đã có kết quả hoặc không tồn tại."); visit=value.ToString(); }
                string id=Db.Id(cn,tx,"SEQ_KQ","KQ");
                Db.Exec(cn,tx,"INSERT INTO KetQuaXetNghiem(MaKQ,MaCD,KetQua) VALUES(@id,@orderId,@result)",Db.P("id",id),Db.P("orderId",order),Db.P("result",result));
                Db.Exec(cn,tx,"UPDATE ChiDinhXetNghiem SET TrangThai='DA_CO_KQ' WHERE MaCD=@orderId",Db.P("orderId",order));
                Db.Exec(cn,tx,@"UPDATE LuotKham SET TrangThai='CHO_TOA' WHERE MaKham=@visit AND NOT EXISTS
                    (SELECT 1 FROM ChiDinhXetNghiem WHERE MaKham=@visit AND TrangThai='CHO_KQ')",Db.P("visit",visit));
                return id;
            });
        }

        internal static string Prescribe(string visit,string doctor,string drug,int quantity,string dosage,int days,string advice)
        {
            if(quantity<=0 || days<=0 || string.IsNullOrWhiteSpace(dosage)) throw new ArgumentException("Số lượng, số ngày và liều dùng phải hợp lệ.");
            return Db.Atomic((cn,tx)=>
            {
                AssertVisit(cn,tx,visit,"DANG_KHAM","CHO_TOA");
                using(var cmd=Db.Command(cn,tx,"SELECT COUNT(*) FROM LuotKham WHERE MaKham=@visit AND MaBS=@bs",Db.P("visit",visit),Db.P("bs",doctor)))
                    if(Convert.ToInt32(cmd.ExecuteScalar())==0) throw new InvalidOperationException("Chỉ bác sĩ phụ trách lượt khám được kê toa.");
                using(var cmd=Db.Command(cn,tx,"SELECT COUNT(*) FROM ChiDinhXetNghiem WHERE MaKham=@visit AND TrangThai='CHO_KQ'",Db.P("visit",visit)))
                    if(Convert.ToInt32(cmd.ExecuteScalar())>0) throw new InvalidOperationException("Còn xét nghiệm chưa có kết quả.");
                string id=Db.Id(cn,tx,"SEQ_TOA","TO");
                Db.Exec(cn,tx,"INSERT INTO ToaThuoc(MaToa,MaKham,MaBS,LoiDan,TrangThai) VALUES(@id,@visit,@bs,@advice,'DA_KY')",
                    Db.P("id",id),Db.P("visit",visit),Db.P("bs",doctor),Db.P("advice",advice));
                Db.Exec(cn,tx,"INSERT INTO ChiTietToa VALUES(@id,@toa,@drug,@quantity,@dosage,@days)",
                    Db.P("id",Db.Id(cn,tx,"SEQ_CT","CT")),Db.P("toa",id),Db.P("drug",drug),
                    Db.P("quantity",quantity),Db.P("dosage",dosage),Db.P("days",days));
                Db.Exec(cn,tx,"UPDATE LuotKham SET TrangThai='CHO_THANH_TOAN' WHERE MaKham=@visit",Db.P("visit",visit));
                return id;
            });
        }

        internal static void Finish(string visit,decimal fee,string conclusion)
        {
            if(fee<0) throw new ArgumentException("Viện phí không thể âm.");
            Db.Atomic((cn,tx)=>
            {
                AssertVisit(cn,tx,visit,"DANG_KHAM","CHO_TOA","CHO_THANH_TOAN");
                using(var cmd=Db.Command(cn,tx,"SELECT COUNT(*) FROM ChiDinhXetNghiem WHERE MaKham=@visit AND TrangThai='CHO_KQ'",Db.P("visit",visit)))
                    if(Convert.ToInt32(cmd.ExecuteScalar())>0) throw new InvalidOperationException("Chưa hoàn tất xét nghiệm.");
                using(var cmd=Db.Command(cn,tx,"SELECT LoaiKham FROM LuotKham WHERE MaKham=@visit",Db.P("visit",visit)))
                    if(cmd.ExecuteScalar().ToString()=="DINH_KY" && fee!=0) throw new InvalidOperationException("Khám định kỳ trong quyền lợi phải miễn phí.");
                Db.Exec(cn,tx,@"UPDATE LuotKham SET VienPhi=@fee,KetLuan=@conclusion,DaThanhToan='Y',
                    NgayXuatVien=GETDATE(),TrangThai='HOAN_TAT' WHERE MaKham=@visit",
                    Db.P("fee",fee),Db.P("conclusion",conclusion),Db.P("visit",visit));
                return 0;
            });
        }

        internal static string AdverseReaction(string record,string drug,string description,string severity)
        {
            if(string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Cần mô tả phản ứng phụ.");
            return Db.Atomic((cn,tx)=>
            {
                CheckRecord(cn,tx,record,false);
                string id=Db.Id(cn,tx,"SEQ_PU","PU");
                Db.Exec(cn,tx,"INSERT INTO PhanUngThuoc(MaPU,MaHS,MaThuoc,MoTa,MucDo) VALUES(@id,@hs,@drug,@description,@severity)",
                    Db.P("id",id),Db.P("hs",record),Db.P("drug",drug),Db.P("description",description),Db.P("severity",severity));
                return id;
            });
        }
    }
}
