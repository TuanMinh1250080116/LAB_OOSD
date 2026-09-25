namespace QuanLyKhachSan.Forms
{
    partial class FrmDatPhong
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
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabKhach = new System.Windows.Forms.TabPage();
            this.lblKHTen = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblKHCMND = new System.Windows.Forms.Label();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.lblKHQT = new System.Windows.Forms.Label();
            this.txtQT = new System.Windows.Forms.TextBox();
            this.lblKHSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnThemKhach = new System.Windows.Forms.Button();
            this.dgvKhach = new System.Windows.Forms.DataGridView();
            this.tabDat = new System.Windows.Forms.TabPage();
            this.lblDPKhach = new System.Windows.Forms.Label();
            this.cboKhach = new System.Windows.Forms.ComboBox();
            this.lblDPNV = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblDPKenh = new System.Windows.Forms.Label();
            this.cboKenh = new System.Windows.Forms.ComboBox();
            this.lblDPCoc = new System.Windows.Forms.Label();
            this.numCoc = new System.Windows.Forms.NumericUpDown();
            this.lblDPNhan = new System.Windows.Forms.Label();
            this.dtNhan = new System.Windows.Forms.DateTimePicker();
            this.lblDPTra = new System.Windows.Forms.Label();
            this.dtTra = new System.Windows.Forms.DateTimePicker();
            this.lblDPGoiY = new System.Windows.Forms.Label();
            this.lblDPPhongTrong = new System.Windows.Forms.Label();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.lblDPSoNguoi = new System.Windows.Forms.Label();
            this.numSoNguoi = new System.Windows.Forms.NumericUpDown();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.btnBoPhong = new System.Windows.Forms.Button();
            this.lblDPPhongChon = new System.Windows.Forms.Label();
            this.dgvChon = new System.Windows.Forms.DataGridView();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.tabNhan = new System.Windows.Forms.TabPage();
            this.lblNPPhieu = new System.Windows.Forms.Label();
            this.txtPhieuChon = new System.Windows.Forms.TextBox();
            this.lblNPTrangThai = new System.Windows.Forms.Label();
            this.btnNhanPhong = new System.Windows.Forms.Button();
            this.btnNoShow = new System.Windows.Forms.Button();
            this.lblNPChiTiet = new System.Windows.Forms.Label();
            this.dgvCT = new System.Windows.Forms.DataGridView();
            this.lblNPDanhSach = new System.Windows.Forms.Label();
            this.dgvNguoi = new System.Windows.Forms.DataGridView();
            this.grpNguoi = new System.Windows.Forms.GroupBox();
            this.lblNLTPhong = new System.Windows.Forms.Label();
            this.txtNguoiPhong = new System.Windows.Forms.TextBox();
            this.lblNLTTen = new System.Windows.Forms.Label();
            this.txtNguoiTen = new System.Windows.Forms.TextBox();
            this.lblNLTCMND = new System.Windows.Forms.Label();
            this.txtNguoiCMND = new System.Windows.Forms.TextBox();
            this.lblNLTQT = new System.Windows.Forms.Label();
            this.txtNguoiQT = new System.Windows.Forms.TextBox();
            this.btnThemNguoi = new System.Windows.Forms.Button();
            this.lblNLTGhiChu = new System.Windows.Forms.Label();
            this.lblNPPhieuDat = new System.Windows.Forms.Label();
            this.dgvPhieuNhan = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabKhach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).BeginInit();
            this.tabDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.tabNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoi)).BeginInit();
            this.grpNguoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhan)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabKhach);
            this.tabs.Controls.Add(this.tabDat);
            this.tabs.Controls.Add(this.tabNhan);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(996, 556);
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // tabKhach
            // 
            this.tabKhach.Controls.Add(this.lblKHTen);
            this.tabKhach.Controls.Add(this.txtTenKH);
            this.tabKhach.Controls.Add(this.lblKHCMND);
            this.tabKhach.Controls.Add(this.txtCMND);
            this.tabKhach.Controls.Add(this.lblKHQT);
            this.tabKhach.Controls.Add(this.txtQT);
            this.tabKhach.Controls.Add(this.lblKHSDT);
            this.tabKhach.Controls.Add(this.txtSDT);
            this.tabKhach.Controls.Add(this.btnThemKhach);
            this.tabKhach.Controls.Add(this.dgvKhach);
            this.tabKhach.Name = "tabKhach";
            this.tabKhach.Size = new System.Drawing.Size(988, 526);
            this.tabKhach.Text = "Khách hàng";
            this.tabKhach.UseVisualStyleBackColor = true;
            // 
            // lblKHTen
            // 
            this.lblKHTen.AutoSize = true;
            this.lblKHTen.Location = new System.Drawing.Point(16, 20);
            this.lblKHTen.Name = "lblKHTen";
            this.lblKHTen.Text = "Họ tên";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(90, 16);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(200, 25);
            this.txtTenKH.MaxLength = 120;
            this.txtTenKH.TabIndex = 3;
            // 
            // lblKHCMND
            // 
            this.lblKHCMND.AutoSize = true;
            this.lblKHCMND.Location = new System.Drawing.Point(306, 20);
            this.lblKHCMND.Name = "lblKHCMND";
            this.lblKHCMND.Text = "CCCD";
            // 
            // txtCMND
            // 
            this.txtCMND.Location = new System.Drawing.Point(366, 16);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(160, 25);
            this.txtCMND.MaxLength = 30;
            this.txtCMND.TabIndex = 5;
            // 
            // lblKHQT
            // 
            this.lblKHQT.AutoSize = true;
            this.lblKHQT.Location = new System.Drawing.Point(542, 20);
            this.lblKHQT.Name = "lblKHQT";
            this.lblKHQT.Text = "Quốc tịch";
            // 
            // txtQT
            // 
            this.txtQT.Location = new System.Drawing.Point(616, 16);
            this.txtQT.Name = "txtQT";
            this.txtQT.Size = new System.Drawing.Size(140, 25);
            this.txtQT.MaxLength = 80;
            this.txtQT.TabIndex = 7;
            // 
            // lblKHSDT
            // 
            this.lblKHSDT.AutoSize = true;
            this.lblKHSDT.Location = new System.Drawing.Point(772, 20);
            this.lblKHSDT.Name = "lblKHSDT";
            this.lblKHSDT.Text = "SĐT";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(812, 16);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(120, 25);
            this.txtSDT.MaxLength = 20;
            this.txtSDT.TabIndex = 9;
            // 
            // btnThemKhach
            // 
            this.btnThemKhach.Location = new System.Drawing.Point(822, 54);
            this.btnThemKhach.Name = "btnThemKhach";
            this.btnThemKhach.Size = new System.Drawing.Size(110, 29);
            this.btnThemKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemKhach.TabIndex = 10;
            this.btnThemKhach.Text = "Thêm khách";
            this.btnThemKhach.Click += new System.EventHandler(this.btnThemKhach_Click);
            // 
            // dgvKhach
            // 
            this.dgvKhach.Location = new System.Drawing.Point(16, 92);
            this.dgvKhach.Name = "dgvKhach";
            this.dgvKhach.Size = new System.Drawing.Size(956, 420);
            this.dgvKhach.AllowUserToAddRows = false;
            this.dgvKhach.AllowUserToDeleteRows = false;
            this.dgvKhach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhach.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKhach.MultiSelect = false;
            this.dgvKhach.RowHeadersVisible = false;
            this.dgvKhach.ReadOnly = true;
            this.dgvKhach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhach.TabIndex = 11;
            // 
            // tabDat
            // 
            this.tabDat.Controls.Add(this.lblDPKhach);
            this.tabDat.Controls.Add(this.cboKhach);
            this.tabDat.Controls.Add(this.lblDPNV);
            this.tabDat.Controls.Add(this.cboNV);
            this.tabDat.Controls.Add(this.lblDPKenh);
            this.tabDat.Controls.Add(this.cboKenh);
            this.tabDat.Controls.Add(this.lblDPCoc);
            this.tabDat.Controls.Add(this.numCoc);
            this.tabDat.Controls.Add(this.lblDPNhan);
            this.tabDat.Controls.Add(this.dtNhan);
            this.tabDat.Controls.Add(this.lblDPTra);
            this.tabDat.Controls.Add(this.dtTra);
            this.tabDat.Controls.Add(this.lblDPGoiY);
            this.tabDat.Controls.Add(this.lblDPPhongTrong);
            this.tabDat.Controls.Add(this.dgvPhong);
            this.tabDat.Controls.Add(this.lblDPSoNguoi);
            this.tabDat.Controls.Add(this.numSoNguoi);
            this.tabDat.Controls.Add(this.btnThemPhong);
            this.tabDat.Controls.Add(this.btnBoPhong);
            this.tabDat.Controls.Add(this.lblDPPhongChon);
            this.tabDat.Controls.Add(this.dgvChon);
            this.tabDat.Controls.Add(this.btnLapPhieu);
            this.tabDat.Controls.Add(this.dgvPhieu);
            this.tabDat.Name = "tabDat";
            this.tabDat.Size = new System.Drawing.Size(988, 526);
            this.tabDat.Text = "Đặt phòng";
            this.tabDat.UseVisualStyleBackColor = true;
            // 
            // lblDPKhach
            // 
            this.lblDPKhach.AutoSize = true;
            this.lblDPKhach.Location = new System.Drawing.Point(16, 18);
            this.lblDPKhach.Name = "lblDPKhach";
            this.lblDPKhach.Text = "Khách";
            // 
            // cboKhach
            // 
            this.cboKhach.Location = new System.Drawing.Point(80, 14);
            this.cboKhach.Name = "cboKhach";
            this.cboKhach.Size = new System.Drawing.Size(200, 25);
            this.cboKhach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhach.TabIndex = 14;
            // 
            // lblDPNV
            // 
            this.lblDPNV.AutoSize = true;
            this.lblDPNV.Location = new System.Drawing.Point(296, 18);
            this.lblDPNV.Name = "lblDPNV";
            this.lblDPNV.Text = "Lễ tân";
            // 
            // cboNV
            // 
            this.cboNV.Location = new System.Drawing.Point(350, 14);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(160, 25);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.TabIndex = 16;
            // 
            // lblDPKenh
            // 
            this.lblDPKenh.AutoSize = true;
            this.lblDPKenh.Location = new System.Drawing.Point(526, 18);
            this.lblDPKenh.Name = "lblDPKenh";
            this.lblDPKenh.Text = "Kênh đặt";
            // 
            // cboKenh
            // 
            this.cboKenh.Location = new System.Drawing.Point(592, 14);
            this.cboKenh.Name = "cboKenh";
            this.cboKenh.Size = new System.Drawing.Size(130, 25);
            this.cboKenh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKenh.TabIndex = 18;
            // 
            // lblDPCoc
            // 
            this.lblDPCoc.AutoSize = true;
            this.lblDPCoc.Location = new System.Drawing.Point(740, 18);
            this.lblDPCoc.Name = "lblDPCoc";
            this.lblDPCoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDPCoc.Text = "Tiền cọc";
            // 
            // numCoc
            // 
            this.numCoc.Location = new System.Drawing.Point(806, 14);
            this.numCoc.Name = "numCoc";
            this.numCoc.Size = new System.Drawing.Size(160, 25);
            this.numCoc.ThousandsSeparator = true;
            this.numCoc.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numCoc.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numCoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numCoc.TabIndex = 20;
            // 
            // lblDPNhan
            // 
            this.lblDPNhan.AutoSize = true;
            this.lblDPNhan.Location = new System.Drawing.Point(16, 54);
            this.lblDPNhan.Name = "lblDPNhan";
            this.lblDPNhan.Text = "Ngày nhận";
            // 
            // dtNhan
            // 
            this.dtNhan.Location = new System.Drawing.Point(90, 50);
            this.dtNhan.Name = "dtNhan";
            this.dtNhan.Size = new System.Drawing.Size(130, 25);
            this.dtNhan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNhan.CustomFormat = "dd/MM/yyyy";
            this.dtNhan.TabIndex = 22;
            this.dtNhan.ValueChanged += new System.EventHandler(this.dtNgay_ValueChanged);
            // 
            // lblDPTra
            // 
            this.lblDPTra.AutoSize = true;
            this.lblDPTra.Location = new System.Drawing.Point(236, 54);
            this.lblDPTra.Name = "lblDPTra";
            this.lblDPTra.Text = "Ngày trả dự kiến";
            // 
            // dtTra
            // 
            this.dtTra.Location = new System.Drawing.Point(350, 50);
            this.dtTra.Name = "dtTra";
            this.dtTra.Size = new System.Drawing.Size(130, 25);
            this.dtTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTra.CustomFormat = "dd/MM/yyyy";
            this.dtTra.TabIndex = 24;
            this.dtTra.ValueChanged += new System.EventHandler(this.dtNgay_ValueChanged);
            // 
            // lblDPGoiY
            // 
            this.lblDPGoiY.AutoSize = true;
            this.lblDPGoiY.Location = new System.Drawing.Point(502, 54);
            this.lblDPGoiY.Name = "lblDPGoiY";
            this.lblDPGoiY.ForeColor = System.Drawing.Color.DimGray;
            this.lblDPGoiY.Text = "Danh sách bên trái chỉ hiện phòng còn trống trong khoảng ngày này.";
            // 
            // lblDPPhongTrong
            // 
            this.lblDPPhongTrong.AutoSize = true;
            this.lblDPPhongTrong.Location = new System.Drawing.Point(16, 86);
            this.lblDPPhongTrong.Name = "lblDPPhongTrong";
            this.lblDPPhongTrong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDPPhongTrong.Text = "Phòng còn trống";
            // 
            // dgvPhong
            // 
            this.dgvPhong.Location = new System.Drawing.Point(16, 110);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.Size = new System.Drawing.Size(480, 280);
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPhong.TabIndex = 27;
            // 
            // lblDPSoNguoi
            // 
            this.lblDPSoNguoi.AutoSize = true;
            this.lblDPSoNguoi.Location = new System.Drawing.Point(16, 398);
            this.lblDPSoNguoi.Name = "lblDPSoNguoi";
            this.lblDPSoNguoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDPSoNguoi.Text = "Số người";
            // 
            // numSoNguoi
            // 
            this.numSoNguoi.Location = new System.Drawing.Point(84, 394);
            this.numSoNguoi.Name = "numSoNguoi";
            this.numSoNguoi.Size = new System.Drawing.Size(70, 25);
            this.numSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNguoi.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNguoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numSoNguoi.TabIndex = 29;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(170, 392);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(130, 29);
            this.btnThemPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemPhong.TabIndex = 30;
            this.btnThemPhong.Text = "Thêm vào phiếu";
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // btnBoPhong
            // 
            this.btnBoPhong.Location = new System.Drawing.Point(306, 392);
            this.btnBoPhong.Name = "btnBoPhong";
            this.btnBoPhong.Size = new System.Drawing.Size(120, 29);
            this.btnBoPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBoPhong.TabIndex = 31;
            this.btnBoPhong.Text = "Bỏ phòng";
            this.btnBoPhong.Click += new System.EventHandler(this.btnBoPhong_Click);
            // 
            // lblDPPhongChon
            // 
            this.lblDPPhongChon.AutoSize = true;
            this.lblDPPhongChon.Location = new System.Drawing.Point(512, 86);
            this.lblDPPhongChon.Name = "lblDPPhongChon";
            this.lblDPPhongChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDPPhongChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDPPhongChon.Text = "Phòng đã chọn";
            // 
            // dgvChon
            // 
            this.dgvChon.Location = new System.Drawing.Point(512, 110);
            this.dgvChon.Name = "dgvChon";
            this.dgvChon.Size = new System.Drawing.Size(460, 280);
            this.dgvChon.AllowUserToAddRows = false;
            this.dgvChon.AllowUserToDeleteRows = false;
            this.dgvChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChon.MultiSelect = false;
            this.dgvChon.RowHeadersVisible = false;
            this.dgvChon.ReadOnly = true;
            this.dgvChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChon.TabIndex = 33;
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(822, 392);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(150, 32);
            this.btnLapPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLapPhieu.TabIndex = 34;
            this.btnLapPhieu.Text = "Lập phiếu đặt";
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // dgvPhieu
            // 
            this.dgvPhieu.Location = new System.Drawing.Point(16, 432);
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.Size = new System.Drawing.Size(956, 80);
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.RowHeadersVisible = false;
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieu.TabIndex = 35;
            this.dgvPhieu.SelectionChanged += new System.EventHandler(this.dgvPhieu_SelectionChanged);
            // 
            // tabNhan
            // 
            this.tabNhan.Controls.Add(this.lblNPPhieu);
            this.tabNhan.Controls.Add(this.txtPhieuChon);
            this.tabNhan.Controls.Add(this.lblNPTrangThai);
            this.tabNhan.Controls.Add(this.btnNhanPhong);
            this.tabNhan.Controls.Add(this.btnNoShow);
            this.tabNhan.Controls.Add(this.lblNPChiTiet);
            this.tabNhan.Controls.Add(this.dgvCT);
            this.tabNhan.Controls.Add(this.lblNPDanhSach);
            this.tabNhan.Controls.Add(this.dgvNguoi);
            this.tabNhan.Controls.Add(this.grpNguoi);
            this.tabNhan.Controls.Add(this.lblNPPhieuDat);
            this.tabNhan.Controls.Add(this.dgvPhieuNhan);
            this.tabNhan.Name = "tabNhan";
            this.tabNhan.Size = new System.Drawing.Size(988, 526);
            this.tabNhan.Text = "Nhận phòng / Người lưu trú";
            this.tabNhan.UseVisualStyleBackColor = true;
            // 
            // lblNPPhieu
            // 
            this.lblNPPhieu.AutoSize = true;
            this.lblNPPhieu.Location = new System.Drawing.Point(16, 20);
            this.lblNPPhieu.Name = "lblNPPhieu";
            this.lblNPPhieu.Text = "Phiếu đặt";
            // 
            // txtPhieuChon
            // 
            this.txtPhieuChon.Location = new System.Drawing.Point(90, 16);
            this.txtPhieuChon.Name = "txtPhieuChon";
            this.txtPhieuChon.Size = new System.Drawing.Size(130, 25);
            this.txtPhieuChon.ReadOnly = true;
            this.txtPhieuChon.TabIndex = 38;
            // 
            // lblNPTrangThai
            // 
            this.lblNPTrangThai.Location = new System.Drawing.Point(236, 20);
            this.lblNPTrangThai.Name = "lblNPTrangThai";
            this.lblNPTrangThai.Size = new System.Drawing.Size(400, 22);
            this.lblNPTrangThai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblNPTrangThai.Text = "";
            // 
            // btnNhanPhong
            // 
            this.btnNhanPhong.Location = new System.Drawing.Point(664, 14);
            this.btnNhanPhong.Name = "btnNhanPhong";
            this.btnNhanPhong.Size = new System.Drawing.Size(140, 30);
            this.btnNhanPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNhanPhong.TabIndex = 40;
            this.btnNhanPhong.Text = "Nhận phòng";
            this.btnNhanPhong.Click += new System.EventHandler(this.btnNhanPhong_Click);
            // 
            // btnNoShow
            // 
            this.btnNoShow.Location = new System.Drawing.Point(812, 14);
            this.btnNoShow.Name = "btnNoShow";
            this.btnNoShow.Size = new System.Drawing.Size(160, 30);
            this.btnNoShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNoShow.TabIndex = 41;
            this.btnNoShow.Text = "Đánh dấu No-show";
            this.btnNoShow.Click += new System.EventHandler(this.btnNoShow_Click);
            // 
            // lblNPChiTiet
            // 
            this.lblNPChiTiet.AutoSize = true;
            this.lblNPChiTiet.Location = new System.Drawing.Point(16, 56);
            this.lblNPChiTiet.Name = "lblNPChiTiet";
            this.lblNPChiTiet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNPChiTiet.Text = "Phòng trong phiếu";
            // 
            // dgvCT
            // 
            this.dgvCT.Location = new System.Drawing.Point(16, 80);
            this.dgvCT.Name = "dgvCT";
            this.dgvCT.Size = new System.Drawing.Size(470, 164);
            this.dgvCT.AllowUserToAddRows = false;
            this.dgvCT.AllowUserToDeleteRows = false;
            this.dgvCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCT.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCT.MultiSelect = false;
            this.dgvCT.RowHeadersVisible = false;
            this.dgvCT.ReadOnly = true;
            this.dgvCT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCT.TabIndex = 43;
            this.dgvCT.SelectionChanged += new System.EventHandler(this.dgvCT_SelectionChanged);
            // 
            // lblNPDanhSach
            // 
            this.lblNPDanhSach.AutoSize = true;
            this.lblNPDanhSach.Location = new System.Drawing.Point(502, 56);
            this.lblNPDanhSach.Name = "lblNPDanhSach";
            this.lblNPDanhSach.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNPDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNPDanhSach.Text = "Người lưu trú đã ghi nhận";
            // 
            // dgvNguoi
            // 
            this.dgvNguoi.Location = new System.Drawing.Point(502, 80);
            this.dgvNguoi.Name = "dgvNguoi";
            this.dgvNguoi.Size = new System.Drawing.Size(470, 164);
            this.dgvNguoi.AllowUserToAddRows = false;
            this.dgvNguoi.AllowUserToDeleteRows = false;
            this.dgvNguoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNguoi.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNguoi.MultiSelect = false;
            this.dgvNguoi.RowHeadersVisible = false;
            this.dgvNguoi.ReadOnly = true;
            this.dgvNguoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNguoi.TabIndex = 45;
            // 
            // grpNguoi
            // 
            this.grpNguoi.Controls.Add(this.lblNLTPhong);
            this.grpNguoi.Controls.Add(this.txtNguoiPhong);
            this.grpNguoi.Controls.Add(this.lblNLTTen);
            this.grpNguoi.Controls.Add(this.txtNguoiTen);
            this.grpNguoi.Controls.Add(this.lblNLTCMND);
            this.grpNguoi.Controls.Add(this.txtNguoiCMND);
            this.grpNguoi.Controls.Add(this.lblNLTQT);
            this.grpNguoi.Controls.Add(this.txtNguoiQT);
            this.grpNguoi.Controls.Add(this.btnThemNguoi);
            this.grpNguoi.Controls.Add(this.lblNLTGhiChu);
            this.grpNguoi.Location = new System.Drawing.Point(16, 256);
            this.grpNguoi.Name = "grpNguoi";
            this.grpNguoi.Size = new System.Drawing.Size(956, 120);
            this.grpNguoi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNguoi.Text = "Thêm người lưu trú";
            // 
            // lblNLTPhong
            // 
            this.lblNLTPhong.AutoSize = true;
            this.lblNLTPhong.Location = new System.Drawing.Point(14, 30);
            this.lblNLTPhong.Name = "lblNLTPhong";
            this.lblNLTPhong.Text = "Phòng";
            // 
            // txtNguoiPhong
            // 
            this.txtNguoiPhong.Location = new System.Drawing.Point(70, 26);
            this.txtNguoiPhong.Name = "txtNguoiPhong";
            this.txtNguoiPhong.Size = new System.Drawing.Size(90, 25);
            this.txtNguoiPhong.ReadOnly = true;
            this.txtNguoiPhong.TabIndex = 48;
            // 
            // lblNLTTen
            // 
            this.lblNLTTen.AutoSize = true;
            this.lblNLTTen.Location = new System.Drawing.Point(176, 30);
            this.lblNLTTen.Name = "lblNLTTen";
            this.lblNLTTen.Text = "Họ tên";
            // 
            // txtNguoiTen
            // 
            this.txtNguoiTen.Location = new System.Drawing.Point(232, 26);
            this.txtNguoiTen.Name = "txtNguoiTen";
            this.txtNguoiTen.Size = new System.Drawing.Size(190, 25);
            this.txtNguoiTen.MaxLength = 120;
            this.txtNguoiTen.TabIndex = 50;
            // 
            // lblNLTCMND
            // 
            this.lblNLTCMND.AutoSize = true;
            this.lblNLTCMND.Location = new System.Drawing.Point(438, 30);
            this.lblNLTCMND.Name = "lblNLTCMND";
            this.lblNLTCMND.Text = "CCCD";
            // 
            // txtNguoiCMND
            // 
            this.txtNguoiCMND.Location = new System.Drawing.Point(490, 26);
            this.txtNguoiCMND.Name = "txtNguoiCMND";
            this.txtNguoiCMND.Size = new System.Drawing.Size(150, 25);
            this.txtNguoiCMND.MaxLength = 30;
            this.txtNguoiCMND.TabIndex = 52;
            // 
            // lblNLTQT
            // 
            this.lblNLTQT.AutoSize = true;
            this.lblNLTQT.Location = new System.Drawing.Point(656, 30);
            this.lblNLTQT.Name = "lblNLTQT";
            this.lblNLTQT.Text = "Quốc tịch";
            // 
            // txtNguoiQT
            // 
            this.txtNguoiQT.Location = new System.Drawing.Point(726, 26);
            this.txtNguoiQT.Name = "txtNguoiQT";
            this.txtNguoiQT.Size = new System.Drawing.Size(120, 25);
            this.txtNguoiQT.MaxLength = 80;
            this.txtNguoiQT.TabIndex = 54;
            // 
            // btnThemNguoi
            // 
            this.btnThemNguoi.Location = new System.Drawing.Point(856, 24);
            this.btnThemNguoi.Name = "btnThemNguoi";
            this.btnThemNguoi.Size = new System.Drawing.Size(90, 29);
            this.btnThemNguoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNguoi.TabIndex = 55;
            this.btnThemNguoi.Text = "Thêm";
            this.btnThemNguoi.Click += new System.EventHandler(this.btnThemNguoi_Click);
            // 
            // lblNLTGhiChu
            // 
            this.lblNLTGhiChu.AutoSize = true;
            this.lblNLTGhiChu.Location = new System.Drawing.Point(14, 70);
            this.lblNLTGhiChu.Name = "lblNLTGhiChu";
            this.lblNLTGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblNLTGhiChu.Text = "Số người lưu trú không vượt quá số người đã đăng ký cho phòng.";
            // 
            // lblNPPhieuDat
            // 
            this.lblNPPhieuDat.AutoSize = true;
            this.lblNPPhieuDat.Location = new System.Drawing.Point(16, 386);
            this.lblNPPhieuDat.Name = "lblNPPhieuDat";
            this.lblNPPhieuDat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNPPhieuDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNPPhieuDat.Text = "Phiếu đặt phòng";
            // 
            // dgvPhieuNhan
            // 
            this.dgvPhieuNhan.Location = new System.Drawing.Point(16, 408);
            this.dgvPhieuNhan.Name = "dgvPhieuNhan";
            this.dgvPhieuNhan.Size = new System.Drawing.Size(956, 104);
            this.dgvPhieuNhan.AllowUserToAddRows = false;
            this.dgvPhieuNhan.AllowUserToDeleteRows = false;
            this.dgvPhieuNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhieuNhan.MultiSelect = false;
            this.dgvPhieuNhan.RowHeadersVisible = false;
            this.dgvPhieuNhan.ReadOnly = true;
            this.dgvPhieuNhan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuNhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieuNhan.TabIndex = 58;
            this.dgvPhieuNhan.SelectionChanged += new System.EventHandler(this.dgvPhieuNhan_SelectionChanged);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(908, 576);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.TabIndex = 59;
            this.btnDong.Text = "Đóng";
            // 
            // FrmDatPhong
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1020, 620);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmDatPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Khách hàng - Đặt phòng - Nhận phòng";
            this.AutoScroll = true;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDatPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhan)).EndInit();
            this.grpNguoi.ResumeLayout(false);
            this.grpNguoi.PerformLayout();
            this.tabNhan.ResumeLayout(false);
            this.tabNhan.PerformLayout();
            this.tabDat.ResumeLayout(false);
            this.tabDat.PerformLayout();
            this.tabKhach.ResumeLayout(false);
            this.tabKhach.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabKhach;
        private System.Windows.Forms.Label lblKHTen;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblKHCMND;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblKHQT;
        private System.Windows.Forms.TextBox txtQT;
        private System.Windows.Forms.Label lblKHSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnThemKhach;
        private System.Windows.Forms.DataGridView dgvKhach;
        private System.Windows.Forms.TabPage tabDat;
        private System.Windows.Forms.Label lblDPKhach;
        private System.Windows.Forms.ComboBox cboKhach;
        private System.Windows.Forms.Label lblDPNV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblDPKenh;
        private System.Windows.Forms.ComboBox cboKenh;
        private System.Windows.Forms.Label lblDPCoc;
        private System.Windows.Forms.NumericUpDown numCoc;
        private System.Windows.Forms.Label lblDPNhan;
        private System.Windows.Forms.DateTimePicker dtNhan;
        private System.Windows.Forms.Label lblDPTra;
        private System.Windows.Forms.DateTimePicker dtTra;
        private System.Windows.Forms.Label lblDPGoiY;
        private System.Windows.Forms.Label lblDPPhongTrong;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.Label lblDPSoNguoi;
        private System.Windows.Forms.NumericUpDown numSoNguoi;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnBoPhong;
        private System.Windows.Forms.Label lblDPPhongChon;
        private System.Windows.Forms.DataGridView dgvChon;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.TabPage tabNhan;
        private System.Windows.Forms.Label lblNPPhieu;
        private System.Windows.Forms.TextBox txtPhieuChon;
        private System.Windows.Forms.Label lblNPTrangThai;
        private System.Windows.Forms.Button btnNhanPhong;
        private System.Windows.Forms.Button btnNoShow;
        private System.Windows.Forms.Label lblNPChiTiet;
        private System.Windows.Forms.DataGridView dgvCT;
        private System.Windows.Forms.Label lblNPDanhSach;
        private System.Windows.Forms.DataGridView dgvNguoi;
        private System.Windows.Forms.GroupBox grpNguoi;
        private System.Windows.Forms.Label lblNLTPhong;
        private System.Windows.Forms.TextBox txtNguoiPhong;
        private System.Windows.Forms.Label lblNLTTen;
        private System.Windows.Forms.TextBox txtNguoiTen;
        private System.Windows.Forms.Label lblNLTCMND;
        private System.Windows.Forms.TextBox txtNguoiCMND;
        private System.Windows.Forms.Label lblNLTQT;
        private System.Windows.Forms.TextBox txtNguoiQT;
        private System.Windows.Forms.Button btnThemNguoi;
        private System.Windows.Forms.Label lblNLTGhiChu;
        private System.Windows.Forms.Label lblNPPhieuDat;
        private System.Windows.Forms.DataGridView dgvPhieuNhan;
        private System.Windows.Forms.Button btnDong;
    }
}
