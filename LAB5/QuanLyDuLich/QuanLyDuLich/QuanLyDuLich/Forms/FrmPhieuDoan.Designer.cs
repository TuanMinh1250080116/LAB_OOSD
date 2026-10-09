namespace QuanLyDuLich.Forms
{
    partial class FrmPhieuDoan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpKhach = new System.Windows.Forms.GroupBox();
            this.lblKhachDoan = new System.Windows.Forms.Label();
            this.cboKhachDoan = new System.Windows.Forms.ComboBox();
            this.chkKhachMoi = new System.Windows.Forms.CheckBox();
            this.lblTenCoQuan = new System.Windows.Forms.Label();
            this.txtTenCoQuan = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblNguoiDaiDien = new System.Windows.Forms.Label();
            this.txtNguoiDaiDien = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grpPhieu = new System.Windows.Forms.GroupBox();
            this.lblTour = new System.Windows.Forms.Label();
            this.cboTour = new System.Windows.Forms.ComboBox();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.dtpNgayDi = new System.Windows.Forms.DateTimePicker();
            this.lblNgayVe = new System.Windows.Forms.Label();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.numSoNguoi = new System.Windows.Forms.NumericUpDown();
            this.chkBaoHiem = new System.Windows.Forms.CheckBox();
            this.lblDiemDon = new System.Windows.Forms.Label();
            this.txtDiaDiemDon = new System.Windows.Forms.TextBox();
            this.lblTong = new System.Windows.Forms.Label();
            this.lblTongKinhPhi = new System.Windows.Forms.Label();
            this.lblCoc = new System.Windows.Forms.Label();
            this.numTienCoc = new System.Windows.Forms.NumericUpDown();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.lblNguoiDiCung = new System.Windows.Forms.Label();
            this.dgvNguoiDiCung = new System.Windows.Forms.DataGridView();
            this.lblSoDong = new System.Windows.Forms.Label();
            this.btnLuuDS = new System.Windows.Forms.Button();
            this.lblDS = new System.Windows.Forms.Label();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.grpKhach.SuspendLayout();
            this.grpPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienCoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDiCung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1156, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Text = "PHIẾU ĐĂNG KÝ TOUR THEO ĐOÀN (trên 12 người)";
            // 
            // grpKhach
            // 
            this.grpKhach.Controls.Add(this.lblKhachDoan);
            this.grpKhach.Controls.Add(this.cboKhachDoan);
            this.grpKhach.Controls.Add(this.chkKhachMoi);
            this.grpKhach.Controls.Add(this.lblTenCoQuan);
            this.grpKhach.Controls.Add(this.txtTenCoQuan);
            this.grpKhach.Controls.Add(this.lblDiaChi);
            this.grpKhach.Controls.Add(this.txtDiaChi);
            this.grpKhach.Controls.Add(this.lblDienThoai);
            this.grpKhach.Controls.Add(this.txtDienThoai);
            this.grpKhach.Controls.Add(this.lblNguoiDaiDien);
            this.grpKhach.Controls.Add(this.txtNguoiDaiDien);
            this.grpKhach.Controls.Add(this.lblEmail);
            this.grpKhach.Controls.Add(this.txtEmail);
            this.grpKhach.Location = new System.Drawing.Point(12, 48);
            this.grpKhach.Name = "grpKhach";
            this.grpKhach.Size = new System.Drawing.Size(560, 196);
            this.grpKhach.Text = "Khách theo đoàn";
            // 
            // lblKhachDoan
            // 
            this.lblKhachDoan.AutoSize = true;
            this.lblKhachDoan.Location = new System.Drawing.Point(15, 30);
            this.lblKhachDoan.Name = "lblKhachDoan";
            this.lblKhachDoan.Text = "Khách đoàn";
            // 
            // cboKhachDoan
            // 
            this.cboKhachDoan.Location = new System.Drawing.Point(140, 27);
            this.cboKhachDoan.Name = "cboKhachDoan";
            this.cboKhachDoan.Size = new System.Drawing.Size(300, 25);
            this.cboKhachDoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhachDoan.TabIndex = 3;
            // 
            // chkKhachMoi
            // 
            this.chkKhachMoi.AutoSize = true;
            this.chkKhachMoi.Location = new System.Drawing.Point(450, 29);
            this.chkKhachMoi.Name = "chkKhachMoi";
            this.chkKhachMoi.TabIndex = 4;
            this.chkKhachMoi.Text = "Khách mới";
            this.chkKhachMoi.CheckedChanged += new System.EventHandler(this.chkKhachMoi_CheckedChanged);
            // 
            // lblTenCoQuan
            // 
            this.lblTenCoQuan.AutoSize = true;
            this.lblTenCoQuan.Location = new System.Drawing.Point(15, 64);
            this.lblTenCoQuan.Name = "lblTenCoQuan";
            this.lblTenCoQuan.Text = "Cơ quan / gia đình";
            // 
            // txtTenCoQuan
            // 
            this.txtTenCoQuan.Location = new System.Drawing.Point(140, 61);
            this.txtTenCoQuan.Name = "txtTenCoQuan";
            this.txtTenCoQuan.Size = new System.Drawing.Size(400, 25);
            this.txtTenCoQuan.MaxLength = 200;
            this.txtTenCoQuan.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 98);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(140, 95);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(400, 25);
            this.txtDiaChi.MaxLength = 300;
            this.txtDiaChi.TabIndex = 8;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(15, 132);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Text = "Điện thoại";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(140, 129);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(150, 25);
            this.txtDienThoai.MaxLength = 15;
            this.txtDienThoai.TabIndex = 10;
            // 
            // lblNguoiDaiDien
            // 
            this.lblNguoiDaiDien.AutoSize = true;
            this.lblNguoiDaiDien.Location = new System.Drawing.Point(300, 132);
            this.lblNguoiDaiDien.Name = "lblNguoiDaiDien";
            this.lblNguoiDaiDien.Text = "Đại diện";
            // 
            // txtNguoiDaiDien
            // 
            this.txtNguoiDaiDien.Location = new System.Drawing.Point(370, 129);
            this.txtNguoiDaiDien.Name = "txtNguoiDaiDien";
            this.txtNguoiDaiDien.Size = new System.Drawing.Size(170, 25);
            this.txtNguoiDaiDien.MaxLength = 100;
            this.txtNguoiDaiDien.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(15, 164);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 161);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 25);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.TabIndex = 14;
            // 
            // grpPhieu
            // 
            this.grpPhieu.Controls.Add(this.lblTour);
            this.grpPhieu.Controls.Add(this.cboTour);
            this.grpPhieu.Controls.Add(this.lblNgayDi);
            this.grpPhieu.Controls.Add(this.dtpNgayDi);
            this.grpPhieu.Controls.Add(this.lblNgayVe);
            this.grpPhieu.Controls.Add(this.lblSoNguoi);
            this.grpPhieu.Controls.Add(this.numSoNguoi);
            this.grpPhieu.Controls.Add(this.chkBaoHiem);
            this.grpPhieu.Controls.Add(this.lblDiemDon);
            this.grpPhieu.Controls.Add(this.txtDiaDiemDon);
            this.grpPhieu.Controls.Add(this.lblTong);
            this.grpPhieu.Controls.Add(this.lblTongKinhPhi);
            this.grpPhieu.Controls.Add(this.lblCoc);
            this.grpPhieu.Controls.Add(this.numTienCoc);
            this.grpPhieu.Controls.Add(this.btnLapPhieu);
            this.grpPhieu.Location = new System.Drawing.Point(12, 250);
            this.grpPhieu.Name = "grpPhieu";
            this.grpPhieu.Size = new System.Drawing.Size(560, 230);
            this.grpPhieu.Text = "Thông tin đăng ký";
            // 
            // lblTour
            // 
            this.lblTour.AutoSize = true;
            this.lblTour.Location = new System.Drawing.Point(15, 30);
            this.lblTour.Name = "lblTour";
            this.lblTour.Text = "Tour";
            // 
            // cboTour
            // 
            this.cboTour.Location = new System.Drawing.Point(140, 27);
            this.cboTour.Name = "cboTour";
            this.cboTour.Size = new System.Drawing.Size(400, 25);
            this.cboTour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTour.TabIndex = 17;
            this.cboTour.SelectedIndexChanged += new System.EventHandler(this.TinhLai);
            // 
            // lblNgayDi
            // 
            this.lblNgayDi.AutoSize = true;
            this.lblNgayDi.Location = new System.Drawing.Point(15, 64);
            this.lblNgayDi.Name = "lblNgayDi";
            this.lblNgayDi.Text = "Ngày đi";
            // 
            // dtpNgayDi
            // 
            this.dtpNgayDi.Location = new System.Drawing.Point(140, 61);
            this.dtpNgayDi.Name = "dtpNgayDi";
            this.dtpNgayDi.Size = new System.Drawing.Size(130, 25);
            this.dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDi.TabIndex = 19;
            this.dtpNgayDi.ValueChanged += new System.EventHandler(this.TinhLai);
            // 
            // lblNgayVe
            // 
            this.lblNgayVe.AutoSize = true;
            this.lblNgayVe.Location = new System.Drawing.Point(290, 64);
            this.lblNgayVe.Name = "lblNgayVe";
            this.lblNgayVe.ForeColor = System.Drawing.Color.DimGray;
            this.lblNgayVe.Text = "Ngày về: --";
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Location = new System.Drawing.Point(15, 98);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Text = "Số người";
            // 
            // numSoNguoi
            // 
            this.numSoNguoi.Location = new System.Drawing.Point(140, 95);
            this.numSoNguoi.Name = "numSoNguoi";
            this.numSoNguoi.Size = new System.Drawing.Size(90, 25);
            this.numSoNguoi.Minimum = new decimal(new int[] { 13, 0, 0, 0 });
            this.numSoNguoi.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            this.numSoNguoi.Value = new decimal(new int[] { 20, 0, 0, 0 });
            this.numSoNguoi.TabIndex = 22;
            this.numSoNguoi.ValueChanged += new System.EventHandler(this.TinhLai);
            // 
            // chkBaoHiem
            // 
            this.chkBaoHiem.AutoSize = true;
            this.chkBaoHiem.Location = new System.Drawing.Point(290, 97);
            this.chkBaoHiem.Name = "chkBaoHiem";
            this.chkBaoHiem.TabIndex = 23;
            this.chkBaoHiem.Text = "Mua bảo hiểm (kèm danh sách)";
            this.chkBaoHiem.CheckedChanged += new System.EventHandler(this.chkBaoHiem_CheckedChanged);
            // 
            // lblDiemDon
            // 
            this.lblDiemDon.AutoSize = true;
            this.lblDiemDon.Location = new System.Drawing.Point(15, 132);
            this.lblDiemDon.Name = "lblDiemDon";
            this.lblDiemDon.Text = "Địa điểm đón";
            // 
            // txtDiaDiemDon
            // 
            this.txtDiaDiemDon.Location = new System.Drawing.Point(140, 129);
            this.txtDiaDiemDon.Name = "txtDiaDiemDon";
            this.txtDiaDiemDon.Size = new System.Drawing.Size(400, 25);
            this.txtDiaDiemDon.MaxLength = 300;
            this.txtDiaDiemDon.TabIndex = 25;
            // 
            // lblTong
            // 
            this.lblTong.AutoSize = true;
            this.lblTong.Location = new System.Drawing.Point(15, 166);
            this.lblTong.Name = "lblTong";
            this.lblTong.Text = "Tổng kinh phí";
            // 
            // lblTongKinhPhi
            // 
            this.lblTongKinhPhi.AutoSize = true;
            this.lblTongKinhPhi.Location = new System.Drawing.Point(140, 166);
            this.lblTongKinhPhi.Name = "lblTongKinhPhi";
            this.lblTongKinhPhi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTongKinhPhi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTongKinhPhi.Text = "0 đ";
            // 
            // lblCoc
            // 
            this.lblCoc.AutoSize = true;
            this.lblCoc.Location = new System.Drawing.Point(15, 198);
            this.lblCoc.Name = "lblCoc";
            this.lblCoc.Text = "Tiền đặt cọc";
            // 
            // numTienCoc
            // 
            this.numTienCoc.Location = new System.Drawing.Point(140, 195);
            this.numTienCoc.Name = "numTienCoc";
            this.numTienCoc.Size = new System.Drawing.Size(150, 25);
            this.numTienCoc.ThousandsSeparator = true;
            this.numTienCoc.Increment = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numTienCoc.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numTienCoc.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            this.numTienCoc.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.numTienCoc.TabIndex = 29;
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(400, 186);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(140, 36);
            this.btnLapPhieu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLapPhieu.TabIndex = 30;
            this.btnLapPhieu.Text = "Lập phiếu";
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // lblNguoiDiCung
            // 
            this.lblNguoiDiCung.AutoSize = true;
            this.lblNguoiDiCung.Location = new System.Drawing.Point(590, 52);
            this.lblNguoiDiCung.Name = "lblNguoiDiCung";
            this.lblNguoiDiCung.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNguoiDiCung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblNguoiDiCung.Text = "Danh sách người đi cùng (bắt buộc khi mua bảo hiểm)";
            // 
            // dgvNguoiDiCung
            // 
            this.dgvNguoiDiCung.Location = new System.Drawing.Point(590, 76);
            this.dgvNguoiDiCung.Name = "dgvNguoiDiCung";
            this.dgvNguoiDiCung.Size = new System.Drawing.Size(578, 360);
            this.dgvNguoiDiCung.AllowUserToAddRows = true;
            this.dgvNguoiDiCung.AllowUserToDeleteRows = true;
            this.dgvNguoiDiCung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoiDiCung.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNguoiDiCung.MultiSelect = false;
            this.dgvNguoiDiCung.RowHeadersVisible = false;
            this.dgvNguoiDiCung.ReadOnly = false;
            this.dgvNguoiDiCung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoiDiCung.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvNguoiDiCung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNguoiDiCung.TabIndex = 32;
            // 
            // lblSoDong
            // 
            this.lblSoDong.AutoSize = true;
            this.lblSoDong.Location = new System.Drawing.Point(590, 444);
            this.lblSoDong.Name = "lblSoDong";
            this.lblSoDong.ForeColor = System.Drawing.Color.DimGray;
            this.lblSoDong.Text = "0 người";
            // 
            // btnLuuDS
            // 
            this.btnLuuDS.Location = new System.Drawing.Point(948, 440);
            this.btnLuuDS.Name = "btnLuuDS";
            this.btnLuuDS.Size = new System.Drawing.Size(220, 32);
            this.btnLuuDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuDS.TabIndex = 34;
            this.btnLuuDS.Text = "Lưu DS cho phiếu đang chọn";
            this.btnLuuDS.Click += new System.EventHandler(this.btnLuuDS_Click);
            // 
            // lblDS
            // 
            this.lblDS.AutoSize = true;
            this.lblDS.Location = new System.Drawing.Point(12, 490);
            this.lblDS.Name = "lblDS";
            this.lblDS.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDS.Text = "Các phiếu đăng ký theo đoàn";
            // 
            // dgvPhieu
            // 
            this.dgvPhieu.Location = new System.Drawing.Point(12, 514);
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.Size = new System.Drawing.Size(1156, 158);
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.RowHeadersVisible = false;
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieu.TabIndex = 36;
            this.dgvPhieu.SelectionChanged += new System.EventHandler(this.dgvPhieu_SelectionChanged);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(12, 680);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(140, 32);
            this.btnBatDau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBatDau.TabIndex = 37;
            this.btnBatDau.Text = "Bắt đầu tour";
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(160, 680);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(140, 32);
            this.btnKetThuc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKetThuc.TabIndex = 38;
            this.btnKetThuc.Text = "Kết thúc tour";
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(308, 680);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(160, 32);
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHuy.TabIndex = 39;
            this.btnHuy.Text = "Hủy (mất cọc)";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(476, 680);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(180, 32);
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThanhToan.TabIndex = 40;
            this.btnThanhToan.Text = "Thanh toán kinh phí";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Location = new System.Drawing.Point(670, 686);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(498, 22);
            this.lblTrangThai.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTrangThai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrangThai.Text = "";
            // 
            // FrmPhieuDoan
            // 
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpKhach);
            this.Controls.Add(this.grpPhieu);
            this.Controls.Add(this.lblNguoiDiCung);
            this.Controls.Add(this.dgvNguoiDiCung);
            this.Controls.Add(this.lblSoDong);
            this.Controls.Add(this.btnLuuDS);
            this.Controls.Add(this.lblDS);
            this.Controls.Add(this.dgvPhieu);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.lblTrangThai);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmPhieuDoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lập phiếu đăng ký tour theo đoàn";
            this.MinimumSize = new System.Drawing.Size(1196, 759);
            this.Load += new System.EventHandler(this.FrmPhieuDoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienCoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDiCung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            this.grpKhach.ResumeLayout(false);
            this.grpKhach.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpKhach;
        private System.Windows.Forms.Label lblKhachDoan;
        private System.Windows.Forms.ComboBox cboKhachDoan;
        private System.Windows.Forms.CheckBox chkKhachMoi;
        private System.Windows.Forms.Label lblTenCoQuan;
        private System.Windows.Forms.TextBox txtTenCoQuan;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblNguoiDaiDien;
        private System.Windows.Forms.TextBox txtNguoiDaiDien;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox grpPhieu;
        private System.Windows.Forms.Label lblTour;
        private System.Windows.Forms.ComboBox cboTour;
        private System.Windows.Forms.Label lblNgayDi;
        private System.Windows.Forms.DateTimePicker dtpNgayDi;
        private System.Windows.Forms.Label lblNgayVe;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.NumericUpDown numSoNguoi;
        private System.Windows.Forms.CheckBox chkBaoHiem;
        private System.Windows.Forms.Label lblDiemDon;
        private System.Windows.Forms.TextBox txtDiaDiemDon;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Label lblTongKinhPhi;
        private System.Windows.Forms.Label lblCoc;
        private System.Windows.Forms.NumericUpDown numTienCoc;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Label lblNguoiDiCung;
        private System.Windows.Forms.DataGridView dgvNguoiDiCung;
        private System.Windows.Forms.Label lblSoDong;
        private System.Windows.Forms.Button btnLuuDS;
        private System.Windows.Forms.Label lblDS;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTrangThai;
    }
}
