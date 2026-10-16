using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyBenhAn
{
    public sealed class MainForm : Form
    {
        private readonly TabControl tabs = new TabControl();
        private readonly Label status = new Label();
        private readonly DataGridView grid = new DataGridView();
        private readonly TextBox search = new TextBox();
        private readonly TextBox historyId = new TextBox();

        public MainForm(bool offline=false)
        {
            Text = "LAB 06 – Quản lý hồ sơ bệnh án";
            Size = new Size(1120, 760); MinimumSize = new Size(900, 620);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 10);
            tabs.Dock = DockStyle.Fill; Controls.Add(tabs);
            status.Dock = DockStyle.Bottom; status.Height = 30; status.BackColor = Color.FromArgb(224,238,244);
            status.Padding = new Padding(12,5,0,0); status.Text = "Sẵn sàng"; Controls.Add(status);
            BuildRegister(); BuildRecords(); BuildAppointment(); BuildVisit(); BuildTests(); BuildPrescription(); BuildFinish(); BuildReaction();
            if (!offline) Shown += (s,e) => Safe(() => { Db.Scalar("SELECT 1"); status.Text="Đã kết nối SQL Server – QuanLyBenhAn"; RefreshRecords(); });
            else status.Text="Ảnh minh họa giao diện – chưa kết nối SQL Server";
        }

        internal static void CaptureScreens(string directory,bool offline)
        {
            System.IO.Directory.CreateDirectory(directory);
            using(var form=new MainForm(offline))
            {
                form.Show();
                Application.DoEvents();
                int[] pages={0,1,2,3,4,5,6,7};
                string[] names={"DangKy","TraCuu","LichHen","KhamBenh","XetNghiem","LapToa","XuatVien","PhanUng"};
                for(int i=0;i<pages.Length;i++)
                {
                    form.tabs.SelectedIndex=pages[i];
                    Application.DoEvents();
                    using(var bitmap=new Bitmap(form.Width,form.Height))
                    {
                        form.DrawToBitmap(bitmap,new Rectangle(Point.Empty,bitmap.Size));
                        bitmap.Save(System.IO.Path.Combine(directory,names[i]+".png"));
                    }
                }
                if(!offline)
                {
                    string record=Convert.ToString(Db.Scalar("SELECT MaHS FROM HoSoBenhAn ORDER BY LENGTH(MaHS) DESC, MaHS DESC FETCH FIRST 1 ROW ONLY"));
                    using(var history=new Form {Text="Lịch sử điều trị – "+record,Size=new Size(1000,550),StartPosition=FormStartPosition.CenterScreen})
                    {
                        var details=new TabControl {Dock=DockStyle.Fill};history.Controls.Add(details);
                        AddHistoryTab(details,"Lượt khám",ClinicService.History(record));
                        AddHistoryTab(details,"Toa thuốc",ClinicService.PrescriptionHistory(record));
                        AddHistoryTab(details,"Xét nghiệm",ClinicService.TestHistory(record));
                        AddHistoryTab(details,"Phản ứng thuốc",ClinicService.ReactionHistory(record));
                        history.Show();Application.DoEvents();
                        using(var bitmap=new Bitmap(history.Width,history.Height))
                        {
                            history.DrawToBitmap(bitmap,new Rectangle(Point.Empty,bitmap.Size));
                            bitmap.Save(System.IO.Path.Combine(directory,"LichSu.png"));
                        }
                        history.Close();
                    }
                }
                form.Close();
            }
        }

        private TabPage Page(string title)
        {
            var page = new TabPage(title) { AutoScroll = true, BackColor = Color.White };
            tabs.TabPages.Add(page); return page;
        }
        private int Row(TabPage page, int y, string label, Control input)
        {
            var l = new Label { Text=label, Left=25, Top=y+5, Width=195, Height=28 };
            input.Left=225; input.Top=y; input.Width=330; input.Height=30;
            page.Controls.Add(l); page.Controls.Add(input); return y+42;
        }
        private TextBox TextBox(string value="") { return new TextBox { Text=value }; }
        private ComboBox Combo(string sql,string display,string key)
        {
            var box = new ComboBox { DropDownStyle=ComboBoxStyle.DropDownList };
            box.DropDown += (s,e) => Safe(() => { string old=box.SelectedValue==null?null:box.SelectedValue.ToString();
                box.DataSource=Db.Query(sql); box.DisplayMember=display; box.ValueMember=key;
                if(old!=null) box.SelectedValue=old; });
            return box;
        }
        private Button Action(TabPage page,int y,string title,Action action)
        {
            var button=new Button {Text=title,Left=225,Top=y,Width=210,Height=38,BackColor=Color.FromArgb(22,107,142),ForeColor=Color.White,FlatStyle=FlatStyle.Flat};
            button.Click += (s,e) => Safe(action); page.Controls.Add(button); return button;
        }
        private void Safe(Action action)
        {
            try { action(); }
            catch(Exception ex) { status.Text="Lỗi: " + ex.Message; MessageBox.Show(ex.Message,"Không thực hiện được",MessageBoxButtons.OK,MessageBoxIcon.Warning); }
        }
        private void Done(string message) { status.Text=message; MessageBox.Show(message,"Thành công",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        private static string Selected(ComboBox box) { if(box.SelectedValue==null) throw new ArgumentException("Chọn một giá trị trong danh sách."); return box.SelectedValue.ToString(); }
        private void BuildRegister()
        {
            var p=Page("Đăng ký & cấp hồ sơ"); int y=25;
            var name=TextBox(); y=Row(p,y,"Họ tên bệnh nhân",name);
            var address=TextBox(); y=Row(p,y,"Địa chỉ",address);
            var birthday=new DateTimePicker { Format=DateTimePickerFormat.Short,Value=DateTime.Today.AddYears(-25) }; y=Row(p,y,"Ngày sinh",birthday);
            var phone=TextBox(); y=Row(p,y,"Điện thoại",phone);
            var photo=TextBox(); y=Row(p,y,"Đường dẫn ảnh 3×4",photo);
            var fee=new NumericUpDown {Minimum=1,Maximum=100000000,Value=300000,Increment=50000}; y=Row(p,y,"Lệ phí quản lý năm",fee);
            Action(p,y+10,"Thu phí và cấp hồ sơ",()=> { string id=ClinicService.Register(name.Text,address.Text,birthday.Value,phone.Text,photo.Text,fee.Value); Done("Đã cấp hồ sơ: "+id); RefreshRecords(); });
            y+=78;
            var renewal=new Label{Text="Gia hạn lệ phí năm cho hồ sơ đã có",Left=25,Top=y,Width=500,Font=new Font(Font,FontStyle.Bold)};p.Controls.Add(renewal);
            y+=32;var existing=TextBox();y=Row(p,y,"Mã hồ sơ",existing);
            Action(p,y,"Thu lệ phí năm hiện tại",()=>Done("Mã phiếu thu: "+ClinicService.RenewFee(existing.Text.Trim(),fee.Value)));
        }
        private void BuildRecords()
        {
            var p=Page("Tra cứu hồ sơ"); search.Left=25;search.Top=25;search.Width=360;search.PlaceholderTextCompat();p.Controls.Add(search);
            var find=Action(p,21,"Tìm theo mã/tên/SĐT",RefreshRecords);find.Left=400;
            grid.Left=25;grid.Top=78;grid.Width=1020;grid.Height=270;grid.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right;
            grid.ReadOnly=true;grid.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;grid.SelectionMode=DataGridViewSelectionMode.FullRowSelect;p.Controls.Add(grid);
            var label=new Label{Text="Mã hồ sơ để xem diễn biến bệnh và lịch sử điều trị",Left=25,Top=367,Width=510};p.Controls.Add(label);
            historyId.Left=25;historyId.Top=395;historyId.Width=200;p.Controls.Add(historyId);
            var history=Action(p,392,"Xem lịch sử điều trị",()=> {
                string id=historyId.Text.Trim();
                var view=new Form {Text="Lịch sử – "+id,Size=new Size(1000,550),StartPosition=FormStartPosition.CenterParent};
                var detail=new TabControl {Dock=DockStyle.Fill};view.Controls.Add(detail);
                AddHistoryTab(detail,"Lượt khám",ClinicService.History(id));
                AddHistoryTab(detail,"Toa thuốc",ClinicService.PrescriptionHistory(id));
                AddHistoryTab(detail,"Xét nghiệm",ClinicService.TestHistory(id));
                AddHistoryTab(detail,"Phản ứng thuốc",ClinicService.ReactionHistory(id));
                view.ShowDialog(this); });history.Left=240;
            grid.SelectionChanged += (s,e) => {if(grid.CurrentRow!=null && grid.CurrentRow.Cells.Count>0) historyId.Text=Convert.ToString(grid.CurrentRow.Cells[0].Value);};
        }
        private static void AddHistoryTab(TabControl tabs,string title,DataTable data)
        {
            var page=new TabPage(title);
            var grid=new DataGridView{Dock=DockStyle.Fill,DataSource=data,ReadOnly=true,
                AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill};
            page.Controls.Add(grid);tabs.TabPages.Add(page);
        }
        private void RefreshRecords() { grid.DataSource=ClinicService.Search(search.Text); status.Text="Đã tải danh sách hồ sơ"; }
        private void BuildAppointment()
        {
            var p=Page("Đặt lịch hẹn");int y=25;
            var record=TextBox("HS0001");y=Row(p,y,"Mã hồ sơ",record);
            var doctor=Combo("SELECT MaBS,HoTen FROM BacSi ORDER BY MaBS","HOTEN","MABS");y=Row(p,y,"Bác sĩ",doctor);
            var time=new DateTimePicker{Format=DateTimePickerFormat.Custom,CustomFormat="dd/MM/yyyy HH:mm",Value=DateTime.Now.AddDays(1),ShowUpDown=true};y=Row(p,y,"Ngày giờ hẹn",time);
            var periodic=new CheckBox{Text="Khám định kỳ theo quý (miễn phí)",AutoSize=true};periodic.Left=225;periodic.Top=y;p.Controls.Add(periodic);
            Action(p,y+45,"Lưu lịch hẹn",()=>Done("Mã lịch hẹn: "+ClinicService.Appointment(record.Text.Trim(),Selected(doctor),time.Value,periodic.Checked)));
        }
        private void BuildVisit()
        {
            var p=Page("Khám bệnh");int y=25;
            var record=TextBox("HS0001");y=Row(p,y,"Mã hồ sơ",record);
            var doctor=Combo("SELECT MaBS,HoTen FROM BacSi ORDER BY MaBS","HOTEN","MABS");y=Row(p,y,"Bác sĩ",doctor);
            var appointment=TextBox();y=Row(p,y,"Mã lịch hẹn (nếu có)",appointment);
            Action(p,y,"Bắt đầu lượt khám",()=>Done("Mã lượt khám: "+ClinicService.StartVisit(record.Text.Trim(),Selected(doctor),appointment.Text.Trim())));
            y+=60;var visit=TextBox();y=Row(p,y,"Mã lượt khám",visit);
            var description=TextBox();y=Row(p,y,"Triệu chứng / ghi nhận",description);
            var temperature=new NumericUpDown{Minimum=30,Maximum=45,DecimalPlaces=1,Increment=0.1M,Value=37};y=Row(p,y,"Thân nhiệt (°C)",temperature);
            var pressure=TextBox();y=Row(p,y,"Huyết áp",pressure);
            var diagnosis=TextBox();y=Row(p,y,"Chẩn đoán",diagnosis);
            Action(p,y,"Lưu ghi nhận khám",()=> { ClinicService.Symptom(visit.Text.Trim(),description.Text,temperature.Value,pressure.Text,diagnosis.Text);Done("Đã cập nhật lượt khám "+visit.Text); });
        }
        private void BuildTests()
        {
            var p=Page("Xét nghiệm");int y=25;
            var visit=TextBox();y=Row(p,y,"Mã lượt khám",visit);
            var doctor=Combo("SELECT MaBS,HoTen FROM BacSi ORDER BY MaBS","HOTEN","MABS");y=Row(p,y,"Bác sĩ chỉ định",doctor);
            var test=Combo("SELECT MaXN,TenXN FROM LoaiXetNghiem ORDER BY MaXN","TENXN","MAXN");y=Row(p,y,"Loại xét nghiệm",test);
            Action(p,y,"Lập chỉ định",()=>Done("Mã chỉ định: "+ClinicService.OrderTest(visit.Text.Trim(),Selected(doctor),Selected(test))));
            y+=70;var order=TextBox();y=Row(p,y,"Mã chỉ định",order);
            var result=TextBox();y=Row(p,y,"Kết quả xét nghiệm",result);
            Action(p,y,"Lưu kết quả",()=>Done("Mã kết quả: "+ClinicService.TestResult(order.Text.Trim(),result.Text)));
        }
        private void BuildPrescription()
        {
            var p=Page("Lập toa thuốc");int y=25;
            var visit=TextBox();y=Row(p,y,"Mã lượt khám",visit);
            var doctor=Combo("SELECT MaBS,HoTen FROM BacSi ORDER BY MaBS","HOTEN","MABS");y=Row(p,y,"Bác sĩ kê toa",doctor);
            var drug=Combo("SELECT MaThuoc,TenThuoc FROM Thuoc ORDER BY MaThuoc","TENTHUOC","MATHUOC");y=Row(p,y,"Thuốc",drug);
            var quantity=new NumericUpDown{Minimum=1,Maximum=10000,Value=10};y=Row(p,y,"Số lượng",quantity);
            var dosage=TextBox("1 viên x 2 lần/ngày");y=Row(p,y,"Liều dùng",dosage);
            var days=new NumericUpDown{Minimum=1,Maximum=365,Value=5};y=Row(p,y,"Số ngày",days);
            var advice=TextBox();y=Row(p,y,"Lời dặn",advice);
            Action(p,y,"Ký và lưu toa",()=>Done("Mã toa thuốc: "+ClinicService.Prescribe(visit.Text.Trim(),Selected(doctor),Selected(drug),(int)quantity.Value,dosage.Text,(int)days.Value,advice.Text)));
        }
        private void BuildFinish()
        {
            var p=Page("Thanh toán & xuất viện");int y=25;
            var visit=TextBox();y=Row(p,y,"Mã lượt khám",visit);
            var fee=new NumericUpDown{Minimum=0,Maximum=1000000000,Increment=50000};y=Row(p,y,"Viện phí (0 nếu định kỳ)",fee);
            var conclusion=TextBox();y=Row(p,y,"Kết luận điều trị",conclusion);
            Action(p,y,"Xác nhận thanh toán & lưu hồ sơ",()=> {ClinicService.Finish(visit.Text.Trim(),fee.Value,conclusion.Text);Done("Lượt khám đã hoàn tất: "+visit.Text);});
        }
        private void BuildReaction()
        {
            var p=Page("Phản ứng thuốc");int y=25;
            var record=TextBox("HS0001");y=Row(p,y,"Mã hồ sơ",record);
            var drug=Combo("SELECT MaThuoc,TenThuoc FROM Thuoc ORDER BY MaThuoc","TENTHUOC","MATHUOC");y=Row(p,y,"Thuốc",drug);
            var description=TextBox();y=Row(p,y,"Mô tả phản ứng",description);
            var severity=new ComboBox{DropDownStyle=ComboBoxStyle.DropDownList};severity.Items.AddRange(new object[]{"NHE","VUA","NANG"});severity.SelectedIndex=0;y=Row(p,y,"Mức độ",severity);
            Action(p,y,"Ghi nhận phản ứng",()=>Done("Mã phản ứng: "+ClinicService.AdverseReaction(record.Text.Trim(),Selected(drug),description.Text,severity.Text)));
        }
    }

    internal static class TextBoxExtensions
    {
        internal static void PlaceholderTextCompat(this TextBox box) { box.Text=""; }
    }
}
