using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLyBenhAn
{
    internal static class KiemThu
    {
        private static readonly List<string> Lines = new List<string>();
        private static int passed, total;

        private static void Check(string name, Action action)
        {
            total++;
            try { action(); passed++; Lines.Add("ĐẠT | " + name); }
            catch (Exception ex) { Lines.Add("LỖI | " + name + " | " + ex.Message); }
        }

        private static void Reject(string name, Action action)
        {
            total++;
            try { action(); Lines.Add("LỖI | " + name + " | thao tác sai vẫn được chấp nhận"); }
            catch (ArgumentException) { passed++; Lines.Add("ĐẠT | " + name); }
            catch (InvalidOperationException) { passed++; Lines.Add("ĐẠT | " + name); }
        }

        internal static void Run(string file)
        {
            try
            {
                string record=null, appointment=null, visit=null, order=null, prescription=null;
                Check("Kết nối SQL Server",()=> { if(Convert.ToInt32(Db.Scalar("SELECT 1"))!=1) throw new Exception("Kết nối lỗi"); });
                Check("Dữ liệu mẫu có HS0001",()=> { if(ClinicService.Search("HS0001").Rows.Count!=1) throw new Exception("Không thấy hồ sơ mẫu"); });
                Reject("Đăng ký điện thoại sai",()=>ClinicService.Register("Kiểm thử","TP.HCM",DateTime.Today.AddYears(-20),"abc",null,300000));
                Check("Đăng ký tạo hồ sơ và phí năm",()=> {record=ClinicService.Register("Bệnh nhân kiểm thử","TP.HCM",DateTime.Today.AddYears(-30),"0909876543",null,300000); if(ClinicService.Search(record).Rows.Count!=1) throw new Exception("Thiếu hồ sơ");});
                Reject("Gia hạn trùng năm bị từ chối",()=>ClinicService.RenewFee(record,300000));
                Check("Đặt lịch định kỳ quý này",()=>appointment=ClinicService.Appointment(record,"BS01",DateTime.Now.AddDays(2),true));
                Reject("Lịch định kỳ thứ hai trong quý bị từ chối",()=>ClinicService.Appointment(record,"BS01",DateTime.Now.AddDays(3),true));
                Check("Tiếp nhận lịch tạo lượt khám định kỳ",()=>visit=ClinicService.StartVisit(record,"BS01",appointment));
                Check("Ghi triệu chứng",()=>ClinicService.Symptom(visit,"Đau đầu",37.5m,"120/80","Theo dõi"));
                Check("Lập chỉ định xét nghiệm",()=>order=ClinicService.OrderTest(visit,"BS01","XN01"));
                Reject("Không kê toa khi còn xét nghiệm chờ",()=>ClinicService.Prescribe(visit,"BS01","T01",10,"1 viên/ngày",5,"Sau ăn"));
                Check("Trả kết quả xét nghiệm",()=>ClinicService.TestResult(order,"Chỉ số trong giới hạn tham chiếu"));
                Reject("Bác sĩ khác không được kê toa",()=>ClinicService.Prescribe(visit,"BS02","T01",10,"1 viên/ngày",5,"Sau ăn"));
                Check("Bác sĩ phụ trách ký toa",()=>prescription=ClinicService.Prescribe(visit,"BS01","T01",10,"1 viên/ngày",5,"Sau ăn"));
                Reject("Khám định kỳ không thu viện phí",()=>ClinicService.Finish(visit,50000,"Ổn định"));
                Check("Hoàn tất miễn phí và lưu lịch sử",()=> {ClinicService.Finish(visit,0,"Ổn định"); if(ClinicService.History(record).Rows.Count!=1) throw new Exception("Thiếu lượt khám");});
                Check("Tra cứu toa và xét nghiệm",()=> {if(ClinicService.PrescriptionHistory(record).Rows.Count!=1 || ClinicService.TestHistory(record).Rows.Count!=1) throw new Exception("Thiếu lịch sử");});
                Check("Ghi nhận và tra cứu phản ứng thuốc",()=> {ClinicService.AdverseReaction(record,"T01","Buồn nôn","NHE"); if(ClinicService.ReactionHistory(record).Rows.Count!=1) throw new Exception("Thiếu phản ứng");});
                Lines.Insert(0,string.Format("KẾT QUẢ: {0}/{1} ca đạt",passed,total));
                Lines.Add("Hồ sơ kiểm thử: " + record + "; lịch: " + appointment + "; lượt khám: " + visit + "; toa: " + prescription);
            }
            catch(Exception ex) { Lines.Insert(0,"LỖI CHẠY KỊCH BẢN: " + ex); }
            finally { File.WriteAllLines(file,Lines,new UTF8Encoding(true)); }
        }
    }
}
