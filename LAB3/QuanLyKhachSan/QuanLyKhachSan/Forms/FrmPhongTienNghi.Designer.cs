namespace QuanLyKhachSan.Forms
{
    partial class FrmPhongTienNghi
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
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.lblPhongSo = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblPhongKhu = new System.Windows.Forms.Label();
            this.cboKhu = new System.Windows.Forms.ComboBox();
            this.lblPhongMax = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.lblPhongGia = new System.Windows.Forms.Label();
            this.numGia = new System.Windows.Forms.NumericUpDown();
            this.btnThemPhong = new System.Windows.Forms.Button();
            this.btnCapNhatGia = new System.Windows.Forms.Button();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.tabTienNghi = new System.Windows.Forms.TabPage();
            this.lblTNMa = new System.Windows.Forms.Label();
            this.txtMaTN = new System.Windows.Forms.TextBox();
            this.lblTNLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblTNSTT = new System.Windows.Forms.Label();
            this.numSTT = new System.Windows.Forms.NumericUpDown();
            this.lblTNTinhTrang = new System.Windows.Forms.Label();
            this.txtTinhTrang = new System.Windows.Forms.TextBox();
            this.lblTNGhiChu = new System.Windows.Forms.Label();
            this.btnThemTN = new System.Windows.Forms.Button();
            this.dgvTN = new System.Windows.Forms.DataGridView();
            this.tabLapDat = new System.Windows.Forms.TabPage();
            this.lblLDTN = new System.Windows.Forms.Label();
            this.cboTN = new System.Windows.Forms.ComboBox();
            this.lblLDPhong = new System.Windows.Forms.Label();
            this.cboPhongLD = new System.Windows.Forms.ComboBox();
            this.lblLDNgay = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblLDTinhTrang = new System.Windows.Forms.Label();
            this.txtTTLD = new System.Windows.Forms.TextBox();
            this.lblLDNV = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.lblLDGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnLapDat = new System.Windows.Forms.Button();
            this.lblLDQuyDinh = new System.Windows.Forms.Label();
            this.dgvLD = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.tabTienNghi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).BeginInit();
            this.tabLapDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabPhong);
            this.tabs.Controls.Add(this.tabTienNghi);
            this.tabs.Controls.Add(this.tabLapDat);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(916, 516);
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.lblPhongSo);
            this.tabPhong.Controls.Add(this.txtPhong);
            this.tabPhong.Controls.Add(this.lblPhongKhu);
            this.tabPhong.Controls.Add(this.cboKhu);
            this.tabPhong.Controls.Add(this.lblPhongMax);
            this.tabPhong.Controls.Add(this.numMax);
            this.tabPhong.Controls.Add(this.lblPhongGia);
            this.tabPhong.Controls.Add(this.numGia);
            this.tabPhong.Controls.Add(this.btnThemPhong);
            this.tabPhong.Controls.Add(this.btnCapNhatGia);
            this.tabPhong.Controls.Add(this.dgvPhong);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Size = new System.Drawing.Size(908, 486);
            this.tabPhong.Text = "Phòng";
            this.tabPhong.UseVisualStyleBackColor = true;
            // 
            // lblPhongSo
            // 
            this.lblPhongSo.AutoSize = true;
            this.lblPhongSo.Location = new System.Drawing.Point(16, 20);
            this.lblPhongSo.Name = "lblPhongSo";
            this.lblPhongSo.Text = "Số phòng";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(90, 16);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(110, 25);
            this.txtPhong.MaxLength = 20;
            this.txtPhong.TabIndex = 3;
            // 
            // lblPhongKhu
            // 
            this.lblPhongKhu.AutoSize = true;
            this.lblPhongKhu.Location = new System.Drawing.Point(216, 20);
            this.lblPhongKhu.Name = "lblPhongKhu";
            this.lblPhongKhu.Text = "Khu vực";
            // 
            // cboKhu
            // 
            this.cboKhu.Location = new System.Drawing.Point(280, 16);
            this.cboKhu.Name = "cboKhu";
            this.cboKhu.Size = new System.Drawing.Size(160, 25);
            this.cboKhu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhu.TabIndex = 5;
            // 
            // lblPhongMax
            // 
            this.lblPhongMax.AutoSize = true;
            this.lblPhongMax.Location = new System.Drawing.Point(456, 20);
            this.lblPhongMax.Name = "lblPhongMax";
            this.lblPhongMax.Text = "Số người tối đa";
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(566, 16);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(70, 25);
            this.numMax.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMax.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            this.numMax.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.numMax.TabIndex = 7;
            // 
            // lblPhongGia
            // 
            this.lblPhongGia.AutoSize = true;
            this.lblPhongGia.Location = new System.Drawing.Point(650, 20);
            this.lblPhongGia.Name = "lblPhongGia";
            this.lblPhongGia.Text = "Đơn giá/ngày";
            // 
            // numGia
            // 
            this.numGia.Location = new System.Drawing.Point(744, 16);
            this.numGia.Name = "numGia";
            this.numGia.Size = new System.Drawing.Size(140, 25);
            this.numGia.ThousandsSeparator = true;
            this.numGia.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numGia.TabIndex = 9;
            // 
            // btnThemPhong
            // 
            this.btnThemPhong.Location = new System.Drawing.Point(660, 54);
            this.btnThemPhong.Name = "btnThemPhong";
            this.btnThemPhong.Size = new System.Drawing.Size(110, 29);
            this.btnThemPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemPhong.TabIndex = 10;
            this.btnThemPhong.Text = "Thêm phòng";
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            // 
            // btnCapNhatGia
            // 
            this.btnCapNhatGia.Location = new System.Drawing.Point(776, 54);
            this.btnCapNhatGia.Name = "btnCapNhatGia";
            this.btnCapNhatGia.Size = new System.Drawing.Size(108, 29);
            this.btnCapNhatGia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhatGia.TabIndex = 11;
            this.btnCapNhatGia.Text = "Đổi đơn giá";
            this.btnCapNhatGia.Click += new System.EventHandler(this.btnCapNhatGia_Click);
            // 
            // dgvPhong
            // 
            this.dgvPhong.Location = new System.Drawing.Point(16, 92);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.Size = new System.Drawing.Size(876, 380);
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhong.TabIndex = 12;
            this.dgvPhong.SelectionChanged += new System.EventHandler(this.dgvPhong_SelectionChanged);
            // 
            // tabTienNghi
            // 
            this.tabTienNghi.Controls.Add(this.lblTNMa);
            this.tabTienNghi.Controls.Add(this.txtMaTN);
            this.tabTienNghi.Controls.Add(this.lblTNLoai);
            this.tabTienNghi.Controls.Add(this.cboLoai);
            this.tabTienNghi.Controls.Add(this.lblTNSTT);
            this.tabTienNghi.Controls.Add(this.numSTT);
            this.tabTienNghi.Controls.Add(this.lblTNTinhTrang);
            this.tabTienNghi.Controls.Add(this.txtTinhTrang);
            this.tabTienNghi.Controls.Add(this.lblTNGhiChu);
            this.tabTienNghi.Controls.Add(this.btnThemTN);
            this.tabTienNghi.Controls.Add(this.dgvTN);
            this.tabTienNghi.Name = "tabTienNghi";
            this.tabTienNghi.Size = new System.Drawing.Size(908, 486);
            this.tabTienNghi.Text = "Tiện nghi";
            this.tabTienNghi.UseVisualStyleBackColor = true;
            // 
            // lblTNMa
            // 
            this.lblTNMa.AutoSize = true;
            this.lblTNMa.Location = new System.Drawing.Point(16, 20);
            this.lblTNMa.Name = "lblTNMa";
            this.lblTNMa.Text = "Mã tiện nghi";
            // 
            // txtMaTN
            // 
            this.txtMaTN.Location = new System.Drawing.Point(116, 16);
            this.txtMaTN.Name = "txtMaTN";
            this.txtMaTN.Size = new System.Drawing.Size(120, 25);
            this.txtMaTN.MaxLength = 30;
            this.txtMaTN.TabIndex = 15;
            // 
            // lblTNLoai
            // 
            this.lblTNLoai.AutoSize = true;
            this.lblTNLoai.Location = new System.Drawing.Point(254, 20);
            this.lblTNLoai.Name = "lblTNLoai";
            this.lblTNLoai.Text = "Loại";
            // 
            // cboLoai
            // 
            this.cboLoai.Location = new System.Drawing.Point(300, 16);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(160, 25);
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.TabIndex = 17;
            // 
            // lblTNSTT
            // 
            this.lblTNSTT.AutoSize = true;
            this.lblTNSTT.Location = new System.Drawing.Point(476, 20);
            this.lblTNSTT.Name = "lblTNSTT";
            this.lblTNSTT.Text = "Số thứ tự";
            // 
            // numSTT
            // 
            this.numSTT.Location = new System.Drawing.Point(546, 16);
            this.numSTT.Name = "numSTT";
            this.numSTT.Size = new System.Drawing.Size(70, 25);
            this.numSTT.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSTT.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numSTT.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSTT.TabIndex = 19;
            // 
            // lblTNTinhTrang
            // 
            this.lblTNTinhTrang.AutoSize = true;
            this.lblTNTinhTrang.Location = new System.Drawing.Point(630, 20);
            this.lblTNTinhTrang.Name = "lblTNTinhTrang";
            this.lblTNTinhTrang.Text = "Tình trạng";
            // 
            // txtTinhTrang
            // 
            this.txtTinhTrang.Location = new System.Drawing.Point(710, 16);
            this.txtTinhTrang.Name = "txtTinhTrang";
            this.txtTinhTrang.Size = new System.Drawing.Size(174, 25);
            this.txtTinhTrang.MaxLength = 100;
            this.txtTinhTrang.TabIndex = 21;
            // 
            // lblTNGhiChu
            // 
            this.lblTNGhiChu.AutoSize = true;
            this.lblTNGhiChu.Location = new System.Drawing.Point(16, 58);
            this.lblTNGhiChu.Name = "lblTNGhiChu";
            this.lblTNGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblTNGhiChu.Text = "Số thứ tự không trùng trong cùng một loại tiện nghi.";
            // 
            // btnThemTN
            // 
            this.btnThemTN.Location = new System.Drawing.Point(774, 54);
            this.btnThemTN.Name = "btnThemTN";
            this.btnThemTN.Size = new System.Drawing.Size(110, 29);
            this.btnThemTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemTN.TabIndex = 23;
            this.btnThemTN.Text = "Thêm";
            this.btnThemTN.Click += new System.EventHandler(this.btnThemTN_Click);
            // 
            // dgvTN
            // 
            this.dgvTN.Location = new System.Drawing.Point(16, 92);
            this.dgvTN.Name = "dgvTN";
            this.dgvTN.Size = new System.Drawing.Size(876, 380);
            this.dgvTN.AllowUserToAddRows = false;
            this.dgvTN.AllowUserToDeleteRows = false;
            this.dgvTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTN.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTN.MultiSelect = false;
            this.dgvTN.RowHeadersVisible = false;
            this.dgvTN.ReadOnly = true;
            this.dgvTN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTN.TabIndex = 24;
            // 
            // tabLapDat
            // 
            this.tabLapDat.Controls.Add(this.lblLDTN);
            this.tabLapDat.Controls.Add(this.cboTN);
            this.tabLapDat.Controls.Add(this.lblLDPhong);
            this.tabLapDat.Controls.Add(this.cboPhongLD);
            this.tabLapDat.Controls.Add(this.lblLDNgay);
            this.tabLapDat.Controls.Add(this.dtNgay);
            this.tabLapDat.Controls.Add(this.lblLDTinhTrang);
            this.tabLapDat.Controls.Add(this.txtTTLD);
            this.tabLapDat.Controls.Add(this.lblLDNV);
            this.tabLapDat.Controls.Add(this.cboNV);
            this.tabLapDat.Controls.Add(this.lblLDGhiChu);
            this.tabLapDat.Controls.Add(this.txtGhiChu);
            this.tabLapDat.Controls.Add(this.btnLapDat);
            this.tabLapDat.Controls.Add(this.lblLDQuyDinh);
            this.tabLapDat.Controls.Add(this.dgvLD);
            this.tabLapDat.Name = "tabLapDat";
            this.tabLapDat.Size = new System.Drawing.Size(908, 486);
            this.tabLapDat.Text = "Lắp đặt / luân chuyển";
            this.tabLapDat.UseVisualStyleBackColor = true;
            // 
            // lblLDTN
            // 
            this.lblLDTN.AutoSize = true;
            this.lblLDTN.Location = new System.Drawing.Point(16, 20);
            this.lblLDTN.Name = "lblLDTN";
            this.lblLDTN.Text = "Tiện nghi";
            // 
            // cboTN
            // 
            this.cboTN.Location = new System.Drawing.Point(90, 16);
            this.cboTN.Name = "cboTN";
            this.cboTN.Size = new System.Drawing.Size(140, 25);
            this.cboTN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTN.TabIndex = 27;
            // 
            // lblLDPhong
            // 
            this.lblLDPhong.AutoSize = true;
            this.lblLDPhong.Location = new System.Drawing.Point(248, 20);
            this.lblLDPhong.Name = "lblLDPhong";
            this.lblLDPhong.Text = "Phòng";
            // 
            // cboPhongLD
            // 
            this.cboPhongLD.Location = new System.Drawing.Point(300, 16);
            this.cboPhongLD.Name = "cboPhongLD";
            this.cboPhongLD.Size = new System.Drawing.Size(120, 25);
            this.cboPhongLD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongLD.TabIndex = 29;
            // 
            // lblLDNgay
            // 
            this.lblLDNgay.AutoSize = true;
            this.lblLDNgay.Location = new System.Drawing.Point(438, 20);
            this.lblLDNgay.Name = "lblLDNgay";
            this.lblLDNgay.Text = "Ngày lắp";
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(504, 16);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(130, 25);
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.CustomFormat = "dd/MM/yyyy";
            this.dtNgay.TabIndex = 31;
            // 
            // lblLDTinhTrang
            // 
            this.lblLDTinhTrang.AutoSize = true;
            this.lblLDTinhTrang.Location = new System.Drawing.Point(650, 20);
            this.lblLDTinhTrang.Name = "lblLDTinhTrang";
            this.lblLDTinhTrang.Text = "Tình trạng";
            // 
            // txtTTLD
            // 
            this.txtTTLD.Location = new System.Drawing.Point(730, 16);
            this.txtTTLD.Name = "txtTTLD";
            this.txtTTLD.Size = new System.Drawing.Size(154, 25);
            this.txtTTLD.MaxLength = 100;
            this.txtTTLD.TabIndex = 33;
            // 
            // lblLDNV
            // 
            this.lblLDNV.AutoSize = true;
            this.lblLDNV.Location = new System.Drawing.Point(16, 58);
            this.lblLDNV.Name = "lblLDNV";
            this.lblLDNV.Text = "Nhân viên";
            // 
            // cboNV
            // 
            this.cboNV.Location = new System.Drawing.Point(90, 54);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(140, 25);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.TabIndex = 35;
            // 
            // lblLDGhiChu
            // 
            this.lblLDGhiChu.AutoSize = true;
            this.lblLDGhiChu.Location = new System.Drawing.Point(248, 58);
            this.lblLDGhiChu.Name = "lblLDGhiChu";
            this.lblLDGhiChu.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(300, 54);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(330, 25);
            this.txtGhiChu.MaxLength = 250;
            this.txtGhiChu.TabIndex = 37;
            // 
            // btnLapDat
            // 
            this.btnLapDat.Location = new System.Drawing.Point(774, 52);
            this.btnLapDat.Name = "btnLapDat";
            this.btnLapDat.Size = new System.Drawing.Size(110, 29);
            this.btnLapDat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLapDat.TabIndex = 38;
            this.btnLapDat.Text = "Lập phiếu";
            this.btnLapDat.Click += new System.EventHandler(this.btnLapDat_Click);
            // 
            // lblLDQuyDinh
            // 
            this.lblLDQuyDinh.AutoSize = true;
            this.lblLDQuyDinh.Location = new System.Drawing.Point(16, 92);
            this.lblLDQuyDinh.Name = "lblLDQuyDinh";
            this.lblLDQuyDinh.ForeColor = System.Drawing.Color.DimGray;
            this.lblLDQuyDinh.Text = "Một thiết bị chỉ được lắp cho một phòng trong cùng một ngày.";
            // 
            // dgvLD
            // 
            this.dgvLD.Location = new System.Drawing.Point(16, 118);
            this.dgvLD.Name = "dgvLD";
            this.dgvLD.Size = new System.Drawing.Size(876, 354);
            this.dgvLD.AllowUserToAddRows = false;
            this.dgvLD.AllowUserToDeleteRows = false;
            this.dgvLD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLD.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLD.MultiSelect = false;
            this.dgvLD.RowHeadersVisible = false;
            this.dgvLD.ReadOnly = true;
            this.dgvLD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLD.TabIndex = 40;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(828, 536);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.TabIndex = 41;
            this.btnDong.Text = "Đóng";
            // 
            // FrmPhongTienNghi
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(940, 580);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmPhongTienNghi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phòng - Tiện nghi - Phiếu lắp đặt";
            this.AutoScroll = true;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPhongTienNghi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLD)).EndInit();
            this.tabLapDat.ResumeLayout(false);
            this.tabLapDat.PerformLayout();
            this.tabTienNghi.ResumeLayout(false);
            this.tabTienNghi.PerformLayout();
            this.tabPhong.ResumeLayout(false);
            this.tabPhong.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.Label lblPhongSo;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblPhongKhu;
        private System.Windows.Forms.ComboBox cboKhu;
        private System.Windows.Forms.Label lblPhongMax;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label lblPhongGia;
        private System.Windows.Forms.NumericUpDown numGia;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.Button btnCapNhatGia;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.TabPage tabTienNghi;
        private System.Windows.Forms.Label lblTNMa;
        private System.Windows.Forms.TextBox txtMaTN;
        private System.Windows.Forms.Label lblTNLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblTNSTT;
        private System.Windows.Forms.NumericUpDown numSTT;
        private System.Windows.Forms.Label lblTNTinhTrang;
        private System.Windows.Forms.TextBox txtTinhTrang;
        private System.Windows.Forms.Label lblTNGhiChu;
        private System.Windows.Forms.Button btnThemTN;
        private System.Windows.Forms.DataGridView dgvTN;
        private System.Windows.Forms.TabPage tabLapDat;
        private System.Windows.Forms.Label lblLDTN;
        private System.Windows.Forms.ComboBox cboTN;
        private System.Windows.Forms.Label lblLDPhong;
        private System.Windows.Forms.ComboBox cboPhongLD;
        private System.Windows.Forms.Label lblLDNgay;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label lblLDTinhTrang;
        private System.Windows.Forms.TextBox txtTTLD;
        private System.Windows.Forms.Label lblLDNV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Label lblLDGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnLapDat;
        private System.Windows.Forms.Label lblLDQuyDinh;
        private System.Windows.Forms.DataGridView dgvLD;
        private System.Windows.Forms.Button btnDong;
    }
}
