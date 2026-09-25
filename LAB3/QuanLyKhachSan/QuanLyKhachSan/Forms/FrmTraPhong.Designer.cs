namespace QuanLyKhachSan.Forms
{
    partial class FrmTraPhong
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
            this.lblDat = new System.Windows.Forms.Label();
            this.cboDat = new System.Windows.Forms.ComboBox();
            this.lblPhongChon = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.btnTraPhong = new System.Windows.Forms.Button();
            this.grpTienNghi = new System.Windows.Forms.GroupBox();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.dgvTN = new System.Windows.Forms.DataGridView();
            this.grpDenBu = new System.Windows.Forms.GroupBox();
            this.lblMucDo = new System.Windows.Forms.Label();
            this.cboMucDo = new System.Windows.Forms.ComboBox();
            this.lblSoTienDB = new System.Windows.Forms.Label();
            this.numDenBu = new System.Windows.Forms.NumericUpDown();
            this.btnThemDB = new System.Windows.Forms.Button();
            this.dgvDBChon = new System.Windows.Forms.DataGridView();
            this.lblNVDB = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnBoDB = new System.Windows.Forms.Button();
            this.btnLapDB = new System.Windows.Forms.Button();
            this.grpHoaDon = new System.Windows.Forms.GroupBox();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.numSoNgay = new System.Windows.Forms.NumericUpDown();
            this.lblNVHD = new System.Windows.Forms.Label();
            this.cboNV2 = new System.Windows.Forms.ComboBox();
            this.btnLapHD = new System.Windows.Forms.Button();
            this.lblTienTam = new System.Windows.Forms.Label();
            this.grpThanhToan = new System.Windows.Forms.GroupBox();
            this.lblHDChon = new System.Windows.Forms.Label();
            this.txtHDChon = new System.Windows.Forms.TextBox();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.cboHT = new System.Windows.Forms.ComboBox();
            this.lblSoTienTT = new System.Windows.Forms.Label();
            this.numTienTT = new System.Windows.Forms.NumericUpDown();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnTraHet = new System.Windows.Forms.Button();
            this.lblHoaDon = new System.Windows.Forms.Label();
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.lblLichSuTT = new System.Windows.Forms.Label();
            this.dgvTT = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpTienNghi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).BeginInit();
            this.grpDenBu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDenBu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBChon)).BeginInit();
            this.grpHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).BeginInit();
            this.grpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTienTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTT)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDat
            // 
            this.lblDat.AutoSize = true;
            this.lblDat.Location = new System.Drawing.Point(12, 18);
            this.lblDat.Name = "lblDat";
            this.lblDat.Text = "Lượt đang ở";
            // 
            // cboDat
            // 
            this.cboDat.Location = new System.Drawing.Point(100, 14);
            this.cboDat.Name = "cboDat";
            this.cboDat.Size = new System.Drawing.Size(300, 25);
            this.cboDat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDat.TabIndex = 1;
            this.cboDat.SelectedIndexChanged += new System.EventHandler(this.cboDat_SelectedIndexChanged);
            // 
            // lblPhongChon
            // 
            this.lblPhongChon.AutoSize = true;
            this.lblPhongChon.Location = new System.Drawing.Point(420, 18);
            this.lblPhongChon.Name = "lblPhongChon";
            this.lblPhongChon.Text = "Phòng";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(470, 14);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(100, 25);
            this.txtPhong.ReadOnly = true;
            this.txtPhong.TabIndex = 3;
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.Location = new System.Drawing.Point(880, 12);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(168, 30);
            this.btnTraPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTraPhong.TabIndex = 4;
            this.btnTraPhong.Text = "Hoàn tất trả phòng";
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);
            // 
            // grpTienNghi
            // 
            this.grpTienNghi.Controls.Add(this.dgvPhong);
            this.grpTienNghi.Controls.Add(this.dgvTN);
            this.grpTienNghi.Location = new System.Drawing.Point(12, 48);
            this.grpTienNghi.Name = "grpTienNghi";
            this.grpTienNghi.Size = new System.Drawing.Size(520, 214);
            this.grpTienNghi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.grpTienNghi.Text = "Kiểm tra phòng và tiện nghi";
            // 
            // dgvPhong
            // 
            this.dgvPhong.Location = new System.Drawing.Point(12, 24);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.Size = new System.Drawing.Size(240, 186);
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.TabIndex = 6;
            this.dgvPhong.SelectionChanged += new System.EventHandler(this.dgvPhong_SelectionChanged);
            // 
            // dgvTN
            // 
            this.dgvTN.Location = new System.Drawing.Point(262, 24);
            this.dgvTN.Name = "dgvTN";
            this.dgvTN.Size = new System.Drawing.Size(246, 186);
            this.dgvTN.AllowUserToAddRows = false;
            this.dgvTN.AllowUserToDeleteRows = false;
            this.dgvTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTN.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTN.MultiSelect = false;
            this.dgvTN.RowHeadersVisible = false;
            this.dgvTN.ReadOnly = true;
            this.dgvTN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTN.TabIndex = 7;
            // 
            // grpDenBu
            // 
            this.grpDenBu.Controls.Add(this.lblMucDo);
            this.grpDenBu.Controls.Add(this.cboMucDo);
            this.grpDenBu.Controls.Add(this.lblSoTienDB);
            this.grpDenBu.Controls.Add(this.numDenBu);
            this.grpDenBu.Controls.Add(this.btnThemDB);
            this.grpDenBu.Controls.Add(this.dgvDBChon);
            this.grpDenBu.Controls.Add(this.lblNVDB);
            this.grpDenBu.Controls.Add(this.cboNV);
            this.grpDenBu.Controls.Add(this.btnBoDB);
            this.grpDenBu.Controls.Add(this.btnLapDB);
            this.grpDenBu.Location = new System.Drawing.Point(540, 48);
            this.grpDenBu.Name = "grpDenBu";
            this.grpDenBu.Size = new System.Drawing.Size(508, 214);
            this.grpDenBu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDenBu.Text = "Phiếu đền bù";
            // 
            // lblMucDo
            // 
            this.lblMucDo.AutoSize = true;
            this.lblMucDo.Location = new System.Drawing.Point(12, 28);
            this.lblMucDo.Name = "lblMucDo";
            this.lblMucDo.Text = "Mức độ";
            // 
            // cboMucDo
            // 
            this.cboMucDo.Location = new System.Drawing.Point(78, 24);
            this.cboMucDo.Name = "cboMucDo";
            this.cboMucDo.Size = new System.Drawing.Size(150, 25);
            this.cboMucDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboMucDo.TabIndex = 10;
            this.cboMucDo.SelectedIndexChanged += new System.EventHandler(this.cboMucDo_SelectedIndexChanged);
            // 
            // lblSoTienDB
            // 
            this.lblSoTienDB.AutoSize = true;
            this.lblSoTienDB.Location = new System.Drawing.Point(240, 28);
            this.lblSoTienDB.Name = "lblSoTienDB";
            this.lblSoTienDB.Text = "Số tiền";
            // 
            // numDenBu
            // 
            this.numDenBu.Location = new System.Drawing.Point(296, 24);
            this.numDenBu.Name = "numDenBu";
            this.numDenBu.Size = new System.Drawing.Size(120, 25);
            this.numDenBu.ThousandsSeparator = true;
            this.numDenBu.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDenBu.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numDenBu.TabIndex = 12;
            // 
            // btnThemDB
            // 
            this.btnThemDB.Location = new System.Drawing.Point(422, 22);
            this.btnThemDB.Name = "btnThemDB";
            this.btnThemDB.Size = new System.Drawing.Size(74, 29);
            this.btnThemDB.TabIndex = 13;
            this.btnThemDB.Text = "Thêm";
            this.btnThemDB.Click += new System.EventHandler(this.btnThemDB_Click);
            // 
            // dgvDBChon
            // 
            this.dgvDBChon.Location = new System.Drawing.Point(12, 60);
            this.dgvDBChon.Name = "dgvDBChon";
            this.dgvDBChon.Size = new System.Drawing.Size(484, 116);
            this.dgvDBChon.AllowUserToAddRows = false;
            this.dgvDBChon.AllowUserToDeleteRows = false;
            this.dgvDBChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDBChon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDBChon.MultiSelect = false;
            this.dgvDBChon.RowHeadersVisible = false;
            this.dgvDBChon.ReadOnly = false;
            this.dgvDBChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDBChon.TabIndex = 14;
            // 
            // lblNVDB
            // 
            this.lblNVDB.AutoSize = true;
            this.lblNVDB.Location = new System.Drawing.Point(12, 188);
            this.lblNVDB.Name = "lblNVDB";
            this.lblNVDB.Text = "Nhân viên";
            // 
            // cboNV
            // 
            this.cboNV.Location = new System.Drawing.Point(84, 184);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(160, 25);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.TabIndex = 16;
            // 
            // btnBoDB
            // 
            this.btnBoDB.Location = new System.Drawing.Point(256, 182);
            this.btnBoDB.Name = "btnBoDB";
            this.btnBoDB.Size = new System.Drawing.Size(110, 29);
            this.btnBoDB.TabIndex = 17;
            this.btnBoDB.Text = "Bỏ dòng";
            this.btnBoDB.Click += new System.EventHandler(this.btnBoDB_Click);
            // 
            // btnLapDB
            // 
            this.btnLapDB.Location = new System.Drawing.Point(372, 182);
            this.btnLapDB.Name = "btnLapDB";
            this.btnLapDB.Size = new System.Drawing.Size(124, 29);
            this.btnLapDB.TabIndex = 18;
            this.btnLapDB.Text = "Lập phiếu";
            this.btnLapDB.Click += new System.EventHandler(this.btnLapDB_Click);
            // 
            // grpHoaDon
            // 
            this.grpHoaDon.Controls.Add(this.lblSoNgay);
            this.grpHoaDon.Controls.Add(this.numSoNgay);
            this.grpHoaDon.Controls.Add(this.lblNVHD);
            this.grpHoaDon.Controls.Add(this.cboNV2);
            this.grpHoaDon.Controls.Add(this.btnLapHD);
            this.grpHoaDon.Controls.Add(this.lblTienTam);
            this.grpHoaDon.Location = new System.Drawing.Point(12, 270);
            this.grpHoaDon.Name = "grpHoaDon";
            this.grpHoaDon.Size = new System.Drawing.Size(520, 120);
            this.grpHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.grpHoaDon.Text = "Hóa đơn";
            // 
            // lblSoNgay
            // 
            this.lblSoNgay.AutoSize = true;
            this.lblSoNgay.Location = new System.Drawing.Point(12, 28);
            this.lblSoNgay.Name = "lblSoNgay";
            this.lblSoNgay.Text = "Số ngày tính tiền";
            // 
            // numSoNgay
            // 
            this.numSoNgay.Location = new System.Drawing.Point(132, 24);
            this.numSoNgay.Name = "numSoNgay";
            this.numSoNgay.Size = new System.Drawing.Size(70, 25);
            this.numSoNgay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNgay.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            this.numSoNgay.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNgay.TabIndex = 21;
            // 
            // lblNVHD
            // 
            this.lblNVHD.AutoSize = true;
            this.lblNVHD.Location = new System.Drawing.Point(220, 28);
            this.lblNVHD.Name = "lblNVHD";
            this.lblNVHD.Text = "Nhân viên";
            // 
            // cboNV2
            // 
            this.cboNV2.Location = new System.Drawing.Point(292, 24);
            this.cboNV2.Name = "cboNV2";
            this.cboNV2.Size = new System.Drawing.Size(150, 25);
            this.cboNV2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV2.TabIndex = 23;
            // 
            // btnLapHD
            // 
            this.btnLapHD.Location = new System.Drawing.Point(452, 22);
            this.btnLapHD.Name = "btnLapHD";
            this.btnLapHD.Size = new System.Drawing.Size(56, 29);
            this.btnLapHD.TabIndex = 24;
            this.btnLapHD.Text = "Lập";
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);
            // 
            // lblTienTam
            // 
            this.lblTienTam.Location = new System.Drawing.Point(12, 58);
            this.lblTienTam.Name = "lblTienTam";
            this.lblTienTam.Size = new System.Drawing.Size(496, 60);
            this.lblTienTam.ForeColor = System.Drawing.Color.DimGray;
            this.lblTienTam.Text = "";
            // 
            // grpThanhToan
            // 
            this.grpThanhToan.Controls.Add(this.lblHDChon);
            this.grpThanhToan.Controls.Add(this.txtHDChon);
            this.grpThanhToan.Controls.Add(this.lblHinhThuc);
            this.grpThanhToan.Controls.Add(this.cboHT);
            this.grpThanhToan.Controls.Add(this.lblSoTienTT);
            this.grpThanhToan.Controls.Add(this.numTienTT);
            this.grpThanhToan.Controls.Add(this.btnThanhToan);
            this.grpThanhToan.Controls.Add(this.btnTraHet);
            this.grpThanhToan.Location = new System.Drawing.Point(540, 270);
            this.grpThanhToan.Name = "grpThanhToan";
            this.grpThanhToan.Size = new System.Drawing.Size(508, 120);
            this.grpThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpThanhToan.Text = "Thanh toán";
            // 
            // lblHDChon
            // 
            this.lblHDChon.AutoSize = true;
            this.lblHDChon.Location = new System.Drawing.Point(12, 28);
            this.lblHDChon.Name = "lblHDChon";
            this.lblHDChon.Text = "Hóa đơn";
            // 
            // txtHDChon
            // 
            this.txtHDChon.Location = new System.Drawing.Point(82, 24);
            this.txtHDChon.Name = "txtHDChon";
            this.txtHDChon.Size = new System.Drawing.Size(120, 25);
            this.txtHDChon.ReadOnly = true;
            this.txtHDChon.TabIndex = 28;
            // 
            // lblHinhThuc
            // 
            this.lblHinhThuc.AutoSize = true;
            this.lblHinhThuc.Location = new System.Drawing.Point(214, 28);
            this.lblHinhThuc.Name = "lblHinhThuc";
            this.lblHinhThuc.Text = "Hình thức";
            // 
            // cboHT
            // 
            this.cboHT.Location = new System.Drawing.Point(286, 24);
            this.cboHT.Name = "cboHT";
            this.cboHT.Size = new System.Drawing.Size(150, 25);
            this.cboHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHT.TabIndex = 30;
            // 
            // lblSoTienTT
            // 
            this.lblSoTienTT.AutoSize = true;
            this.lblSoTienTT.Location = new System.Drawing.Point(12, 64);
            this.lblSoTienTT.Name = "lblSoTienTT";
            this.lblSoTienTT.Text = "Số tiền";
            // 
            // numTienTT
            // 
            this.numTienTT.Location = new System.Drawing.Point(82, 60);
            this.numTienTT.Name = "numTienTT";
            this.numTienTT.Size = new System.Drawing.Size(160, 25);
            this.numTienTT.ThousandsSeparator = true;
            this.numTienTT.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numTienTT.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numTienTT.TabIndex = 32;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(256, 58);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(130, 29);
            this.btnThanhToan.TabIndex = 33;
            this.btnThanhToan.Text = "Ghi thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnTraHet
            // 
            this.btnTraHet.Location = new System.Drawing.Point(392, 58);
            this.btnTraHet.Name = "btnTraHet";
            this.btnTraHet.Size = new System.Drawing.Size(104, 29);
            this.btnTraHet.TabIndex = 34;
            this.btnTraHet.Text = "Trả hết";
            this.btnTraHet.Click += new System.EventHandler(this.btnTraHet_Click);
            // 
            // lblHoaDon
            // 
            this.lblHoaDon.AutoSize = true;
            this.lblHoaDon.Location = new System.Drawing.Point(12, 396);
            this.lblHoaDon.Name = "lblHoaDon";
            this.lblHoaDon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHoaDon.Text = "Hóa đơn";
            // 
            // dgvHD
            // 
            this.dgvHD.Location = new System.Drawing.Point(12, 418);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.Size = new System.Drawing.Size(1036, 86);
            this.dgvHD.AllowUserToAddRows = false;
            this.dgvHD.AllowUserToDeleteRows = false;
            this.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHD.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHD.MultiSelect = false;
            this.dgvHD.RowHeadersVisible = false;
            this.dgvHD.ReadOnly = true;
            this.dgvHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHD.TabIndex = 36;
            this.dgvHD.SelectionChanged += new System.EventHandler(this.dgvHD_SelectionChanged);
            // 
            // lblLichSuTT
            // 
            this.lblLichSuTT.Location = new System.Drawing.Point(12, 510);
            this.lblLichSuTT.Name = "lblLichSuTT";
            this.lblLichSuTT.Size = new System.Drawing.Size(400, 22);
            this.lblLichSuTT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLichSuTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLichSuTT.Text = "Giao dịch thanh toán của hóa đơn đang chọn";
            // 
            // dgvTT
            // 
            this.dgvTT.Location = new System.Drawing.Point(12, 532);
            this.dgvTT.Name = "dgvTT";
            this.dgvTT.Size = new System.Drawing.Size(930, 72);
            this.dgvTT.AllowUserToAddRows = false;
            this.dgvTT.AllowUserToDeleteRows = false;
            this.dgvTT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTT.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTT.MultiSelect = false;
            this.dgvTT.RowHeadersVisible = false;
            this.dgvTT.ReadOnly = true;
            this.dgvTT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTT.TabIndex = 38;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(948, 576);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 28);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.TabIndex = 39;
            this.btnDong.Text = "Đóng";
            // 
            // FrmTraPhong
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1060, 618);
            this.Controls.Add(this.lblDat);
            this.Controls.Add(this.cboDat);
            this.Controls.Add(this.lblPhongChon);
            this.Controls.Add(this.txtPhong);
            this.Controls.Add(this.btnTraPhong);
            this.Controls.Add(this.grpTienNghi);
            this.Controls.Add(this.grpDenBu);
            this.Controls.Add(this.grpHoaDon);
            this.Controls.Add(this.grpThanhToan);
            this.Controls.Add(this.lblHoaDon);
            this.Controls.Add(this.dgvHD);
            this.Controls.Add(this.lblLichSuTT);
            this.Controls.Add(this.dgvTT);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmTraPhong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Trả phòng - Đền bù - Hóa đơn - Thanh toán";
            this.AutoScroll = true;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTraPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDenBu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDBChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTienTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTT)).EndInit();
            this.grpThanhToan.ResumeLayout(false);
            this.grpThanhToan.PerformLayout();
            this.grpHoaDon.ResumeLayout(false);
            this.grpHoaDon.PerformLayout();
            this.grpDenBu.ResumeLayout(false);
            this.grpDenBu.PerformLayout();
            this.grpTienNghi.ResumeLayout(false);
            this.grpTienNghi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDat;
        private System.Windows.Forms.ComboBox cboDat;
        private System.Windows.Forms.Label lblPhongChon;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Button btnTraPhong;
        private System.Windows.Forms.GroupBox grpTienNghi;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.DataGridView dgvTN;
        private System.Windows.Forms.GroupBox grpDenBu;
        private System.Windows.Forms.Label lblMucDo;
        private System.Windows.Forms.ComboBox cboMucDo;
        private System.Windows.Forms.Label lblSoTienDB;
        private System.Windows.Forms.NumericUpDown numDenBu;
        private System.Windows.Forms.Button btnThemDB;
        private System.Windows.Forms.DataGridView dgvDBChon;
        private System.Windows.Forms.Label lblNVDB;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnBoDB;
        private System.Windows.Forms.Button btnLapDB;
        private System.Windows.Forms.GroupBox grpHoaDon;
        private System.Windows.Forms.Label lblSoNgay;
        private System.Windows.Forms.NumericUpDown numSoNgay;
        private System.Windows.Forms.Label lblNVHD;
        private System.Windows.Forms.ComboBox cboNV2;
        private System.Windows.Forms.Button btnLapHD;
        private System.Windows.Forms.Label lblTienTam;
        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.Label lblHDChon;
        private System.Windows.Forms.TextBox txtHDChon;
        private System.Windows.Forms.Label lblHinhThuc;
        private System.Windows.Forms.ComboBox cboHT;
        private System.Windows.Forms.Label lblSoTienTT;
        private System.Windows.Forms.NumericUpDown numTienTT;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnTraHet;
        private System.Windows.Forms.Label lblHoaDon;
        private System.Windows.Forms.DataGridView dgvHD;
        private System.Windows.Forms.Label lblLichSuTT;
        private System.Windows.Forms.DataGridView dgvTT;
        private System.Windows.Forms.Button btnDong;
    }
}
