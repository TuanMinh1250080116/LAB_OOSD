namespace QuanLyKhachSan.Forms
{
    partial class FrmDanhMuc
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
            this.tabKhuVuc = new System.Windows.Forms.TabPage();
            this.lblKhuMa = new System.Windows.Forms.Label();
            this.txtKhuMa = new System.Windows.Forms.TextBox();
            this.lblKhuTen = new System.Windows.Forms.Label();
            this.txtKhuTen = new System.Windows.Forms.TextBox();
            this.btnThemKhu = new System.Windows.Forms.Button();
            this.dgvKhu = new System.Windows.Forms.DataGridView();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.lblNVMa = new System.Windows.Forms.Label();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.lblNVTen = new System.Windows.Forms.Label();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.lblNVVaiTro = new System.Windows.Forms.Label();
            this.cboNVVaiTro = new System.Windows.Forms.ComboBox();
            this.lblNVSDT = new System.Windows.Forms.Label();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.tabLoaiTN = new System.Windows.Forms.TabPage();
            this.lblLoaiMa = new System.Windows.Forms.Label();
            this.txtLoaiMa = new System.Windows.Forms.TextBox();
            this.lblLoaiTen = new System.Windows.Forms.Label();
            this.txtLoaiTen = new System.Windows.Forms.TextBox();
            this.btnThemLoaiTN = new System.Windows.Forms.Button();
            this.dgvLoaiTN = new System.Windows.Forms.DataGridView();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.lblDVMa = new System.Windows.Forms.Label();
            this.txtDVMa = new System.Windows.Forms.TextBox();
            this.lblDVTen = new System.Windows.Forms.Label();
            this.txtDVTen = new System.Windows.Forms.TextBox();
            this.lblDVDVT = new System.Windows.Forms.Label();
            this.txtDVDVT = new System.Windows.Forms.TextBox();
            this.lblDVGia = new System.Windows.Forms.Label();
            this.numDVGia = new System.Windows.Forms.NumericUpDown();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.dgvDV = new System.Windows.Forms.DataGridView();
            this.tabQuyDinh = new System.Windows.Forms.TabPage();
            this.lblQDMa = new System.Windows.Forms.Label();
            this.txtQDMa = new System.Windows.Forms.TextBox();
            this.lblQDLoai = new System.Windows.Forms.Label();
            this.cboQDLoai = new System.Windows.Forms.ComboBox();
            this.lblQDMucDo = new System.Windows.Forms.Label();
            this.txtQDMucDo = new System.Windows.Forms.TextBox();
            this.lblQDTien = new System.Windows.Forms.Label();
            this.numQDTien = new System.Windows.Forms.NumericUpDown();
            this.btnThemQD = new System.Windows.Forms.Button();
            this.dgvQD = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabKhuVuc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).BeginInit();
            this.tabNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabLoaiTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).BeginInit();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).BeginInit();
            this.tabQuyDinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).BeginInit();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabKhuVuc);
            this.tabs.Controls.Add(this.tabNhanVien);
            this.tabs.Controls.Add(this.tabLoaiTN);
            this.tabs.Controls.Add(this.tabDichVu);
            this.tabs.Controls.Add(this.tabQuyDinh);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(876, 496);
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // tabKhuVuc
            // 
            this.tabKhuVuc.Controls.Add(this.lblKhuMa);
            this.tabKhuVuc.Controls.Add(this.txtKhuMa);
            this.tabKhuVuc.Controls.Add(this.lblKhuTen);
            this.tabKhuVuc.Controls.Add(this.txtKhuTen);
            this.tabKhuVuc.Controls.Add(this.btnThemKhu);
            this.tabKhuVuc.Controls.Add(this.dgvKhu);
            this.tabKhuVuc.Name = "tabKhuVuc";
            this.tabKhuVuc.Size = new System.Drawing.Size(868, 466);
            this.tabKhuVuc.Text = "Khu vực";
            this.tabKhuVuc.UseVisualStyleBackColor = true;
            // 
            // lblKhuMa
            // 
            this.lblKhuMa.AutoSize = true;
            this.lblKhuMa.Location = new System.Drawing.Point(16, 20);
            this.lblKhuMa.Name = "lblKhuMa";
            this.lblKhuMa.Text = "Mã khu vực";
            // 
            // txtKhuMa
            // 
            this.txtKhuMa.Location = new System.Drawing.Point(110, 16);
            this.txtKhuMa.Name = "txtKhuMa";
            this.txtKhuMa.Size = new System.Drawing.Size(120, 25);
            this.txtKhuMa.MaxLength = 20;
            this.txtKhuMa.TabIndex = 3;
            // 
            // lblKhuTen
            // 
            this.lblKhuTen.AutoSize = true;
            this.lblKhuTen.Location = new System.Drawing.Point(250, 20);
            this.lblKhuTen.Name = "lblKhuTen";
            this.lblKhuTen.Text = "Tên khu vực";
            // 
            // txtKhuTen
            // 
            this.txtKhuTen.Location = new System.Drawing.Point(340, 16);
            this.txtKhuTen.Name = "txtKhuTen";
            this.txtKhuTen.Size = new System.Drawing.Size(260, 25);
            this.txtKhuTen.MaxLength = 100;
            this.txtKhuTen.TabIndex = 5;
            // 
            // btnThemKhu
            // 
            this.btnThemKhu.Location = new System.Drawing.Point(620, 14);
            this.btnThemKhu.Name = "btnThemKhu";
            this.btnThemKhu.Size = new System.Drawing.Size(110, 29);
            this.btnThemKhu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemKhu.TabIndex = 6;
            this.btnThemKhu.Text = "Thêm";
            this.btnThemKhu.Click += new System.EventHandler(this.btnThemKhu_Click);
            // 
            // dgvKhu
            // 
            this.dgvKhu.Location = new System.Drawing.Point(16, 56);
            this.dgvKhu.Name = "dgvKhu";
            this.dgvKhu.Size = new System.Drawing.Size(836, 394);
            this.dgvKhu.AllowUserToAddRows = false;
            this.dgvKhu.AllowUserToDeleteRows = false;
            this.dgvKhu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKhu.MultiSelect = false;
            this.dgvKhu.RowHeadersVisible = false;
            this.dgvKhu.ReadOnly = true;
            this.dgvKhu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKhu.TabIndex = 7;
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.lblNVMa);
            this.tabNhanVien.Controls.Add(this.txtNVMa);
            this.tabNhanVien.Controls.Add(this.lblNVTen);
            this.tabNhanVien.Controls.Add(this.txtNVTen);
            this.tabNhanVien.Controls.Add(this.lblNVVaiTro);
            this.tabNhanVien.Controls.Add(this.cboNVVaiTro);
            this.tabNhanVien.Controls.Add(this.lblNVSDT);
            this.tabNhanVien.Controls.Add(this.txtNVSDT);
            this.tabNhanVien.Controls.Add(this.btnThemNV);
            this.tabNhanVien.Controls.Add(this.dgvNV);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Size = new System.Drawing.Size(868, 466);
            this.tabNhanVien.Text = "Nhân viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // lblNVMa
            // 
            this.lblNVMa.AutoSize = true;
            this.lblNVMa.Location = new System.Drawing.Point(16, 20);
            this.lblNVMa.Name = "lblNVMa";
            this.lblNVMa.Text = "Mã NV";
            // 
            // txtNVMa
            // 
            this.txtNVMa.Location = new System.Drawing.Point(80, 16);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(90, 25);
            this.txtNVMa.MaxLength = 20;
            this.txtNVMa.TabIndex = 10;
            // 
            // lblNVTen
            // 
            this.lblNVTen.AutoSize = true;
            this.lblNVTen.Location = new System.Drawing.Point(186, 20);
            this.lblNVTen.Name = "lblNVTen";
            this.lblNVTen.Text = "Họ tên";
            // 
            // txtNVTen
            // 
            this.txtNVTen.Location = new System.Drawing.Point(240, 16);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(190, 25);
            this.txtNVTen.MaxLength = 120;
            this.txtNVTen.TabIndex = 12;
            // 
            // lblNVVaiTro
            // 
            this.lblNVVaiTro.AutoSize = true;
            this.lblNVVaiTro.Location = new System.Drawing.Point(444, 20);
            this.lblNVVaiTro.Name = "lblNVVaiTro";
            this.lblNVVaiTro.Text = "Vai trò";
            // 
            // cboNVVaiTro
            // 
            this.cboNVVaiTro.Location = new System.Drawing.Point(500, 16);
            this.cboNVVaiTro.Name = "cboNVVaiTro";
            this.cboNVVaiTro.Size = new System.Drawing.Size(150, 25);
            this.cboNVVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNVVaiTro.TabIndex = 14;
            // 
            // lblNVSDT
            // 
            this.lblNVSDT.AutoSize = true;
            this.lblNVSDT.Location = new System.Drawing.Point(664, 20);
            this.lblNVSDT.Name = "lblNVSDT";
            this.lblNVSDT.Text = "SĐT";
            // 
            // txtNVSDT
            // 
            this.txtNVSDT.Location = new System.Drawing.Point(700, 16);
            this.txtNVSDT.Name = "txtNVSDT";
            this.txtNVSDT.Size = new System.Drawing.Size(110, 25);
            this.txtNVSDT.MaxLength = 20;
            this.txtNVSDT.TabIndex = 16;
            // 
            // btnThemNV
            // 
            this.btnThemNV.Location = new System.Drawing.Point(742, 52);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(110, 29);
            this.btnThemNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNV.TabIndex = 17;
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // dgvNV
            // 
            this.dgvNV.Location = new System.Drawing.Point(16, 92);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.Size = new System.Drawing.Size(836, 358);
            this.dgvNV.AllowUserToAddRows = false;
            this.dgvNV.AllowUserToDeleteRows = false;
            this.dgvNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNV.MultiSelect = false;
            this.dgvNV.RowHeadersVisible = false;
            this.dgvNV.ReadOnly = true;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNV.TabIndex = 18;
            // 
            // tabLoaiTN
            // 
            this.tabLoaiTN.Controls.Add(this.lblLoaiMa);
            this.tabLoaiTN.Controls.Add(this.txtLoaiMa);
            this.tabLoaiTN.Controls.Add(this.lblLoaiTen);
            this.tabLoaiTN.Controls.Add(this.txtLoaiTen);
            this.tabLoaiTN.Controls.Add(this.btnThemLoaiTN);
            this.tabLoaiTN.Controls.Add(this.dgvLoaiTN);
            this.tabLoaiTN.Name = "tabLoaiTN";
            this.tabLoaiTN.Size = new System.Drawing.Size(868, 466);
            this.tabLoaiTN.Text = "Loại tiện nghi";
            this.tabLoaiTN.UseVisualStyleBackColor = true;
            // 
            // lblLoaiMa
            // 
            this.lblLoaiMa.AutoSize = true;
            this.lblLoaiMa.Location = new System.Drawing.Point(16, 20);
            this.lblLoaiMa.Name = "lblLoaiMa";
            this.lblLoaiMa.Text = "Mã loại";
            // 
            // txtLoaiMa
            // 
            this.txtLoaiMa.Location = new System.Drawing.Point(100, 16);
            this.txtLoaiMa.Name = "txtLoaiMa";
            this.txtLoaiMa.Size = new System.Drawing.Size(120, 25);
            this.txtLoaiMa.MaxLength = 20;
            this.txtLoaiMa.TabIndex = 21;
            // 
            // lblLoaiTen
            // 
            this.lblLoaiTen.AutoSize = true;
            this.lblLoaiTen.Location = new System.Drawing.Point(240, 20);
            this.lblLoaiTen.Name = "lblLoaiTen";
            this.lblLoaiTen.Text = "Tên loại tiện nghi";
            // 
            // txtLoaiTen
            // 
            this.txtLoaiTen.Location = new System.Drawing.Point(380, 16);
            this.txtLoaiTen.Name = "txtLoaiTen";
            this.txtLoaiTen.Size = new System.Drawing.Size(240, 25);
            this.txtLoaiTen.MaxLength = 100;
            this.txtLoaiTen.TabIndex = 23;
            // 
            // btnThemLoaiTN
            // 
            this.btnThemLoaiTN.Location = new System.Drawing.Point(640, 14);
            this.btnThemLoaiTN.Name = "btnThemLoaiTN";
            this.btnThemLoaiTN.Size = new System.Drawing.Size(110, 29);
            this.btnThemLoaiTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemLoaiTN.TabIndex = 24;
            this.btnThemLoaiTN.Text = "Thêm";
            this.btnThemLoaiTN.Click += new System.EventHandler(this.btnThemLoaiTN_Click);
            // 
            // dgvLoaiTN
            // 
            this.dgvLoaiTN.Location = new System.Drawing.Point(16, 56);
            this.dgvLoaiTN.Name = "dgvLoaiTN";
            this.dgvLoaiTN.Size = new System.Drawing.Size(836, 394);
            this.dgvLoaiTN.AllowUserToAddRows = false;
            this.dgvLoaiTN.AllowUserToDeleteRows = false;
            this.dgvLoaiTN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoaiTN.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLoaiTN.MultiSelect = false;
            this.dgvLoaiTN.RowHeadersVisible = false;
            this.dgvLoaiTN.ReadOnly = true;
            this.dgvLoaiTN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiTN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoaiTN.TabIndex = 25;
            // 
            // tabDichVu
            // 
            this.tabDichVu.Controls.Add(this.lblDVMa);
            this.tabDichVu.Controls.Add(this.txtDVMa);
            this.tabDichVu.Controls.Add(this.lblDVTen);
            this.tabDichVu.Controls.Add(this.txtDVTen);
            this.tabDichVu.Controls.Add(this.lblDVDVT);
            this.tabDichVu.Controls.Add(this.txtDVDVT);
            this.tabDichVu.Controls.Add(this.lblDVGia);
            this.tabDichVu.Controls.Add(this.numDVGia);
            this.tabDichVu.Controls.Add(this.btnThemDV);
            this.tabDichVu.Controls.Add(this.dgvDV);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Size = new System.Drawing.Size(868, 466);
            this.tabDichVu.Text = "Dịch vụ";
            this.tabDichVu.UseVisualStyleBackColor = true;
            // 
            // lblDVMa
            // 
            this.lblDVMa.AutoSize = true;
            this.lblDVMa.Location = new System.Drawing.Point(16, 20);
            this.lblDVMa.Name = "lblDVMa";
            this.lblDVMa.Text = "Mã DV";
            // 
            // txtDVMa
            // 
            this.txtDVMa.Location = new System.Drawing.Point(80, 16);
            this.txtDVMa.Name = "txtDVMa";
            this.txtDVMa.Size = new System.Drawing.Size(90, 25);
            this.txtDVMa.MaxLength = 20;
            this.txtDVMa.TabIndex = 28;
            // 
            // lblDVTen
            // 
            this.lblDVTen.AutoSize = true;
            this.lblDVTen.Location = new System.Drawing.Point(186, 20);
            this.lblDVTen.Name = "lblDVTen";
            this.lblDVTen.Text = "Tên dịch vụ";
            // 
            // txtDVTen
            // 
            this.txtDVTen.Location = new System.Drawing.Point(270, 16);
            this.txtDVTen.Name = "txtDVTen";
            this.txtDVTen.Size = new System.Drawing.Size(200, 25);
            this.txtDVTen.MaxLength = 120;
            this.txtDVTen.TabIndex = 30;
            // 
            // lblDVDVT
            // 
            this.lblDVDVT.AutoSize = true;
            this.lblDVDVT.Location = new System.Drawing.Point(484, 20);
            this.lblDVDVT.Name = "lblDVDVT";
            this.lblDVDVT.Text = "ĐVT";
            // 
            // txtDVDVT
            // 
            this.txtDVDVT.Location = new System.Drawing.Point(524, 16);
            this.txtDVDVT.Name = "txtDVDVT";
            this.txtDVDVT.Size = new System.Drawing.Size(90, 25);
            this.txtDVDVT.MaxLength = 40;
            this.txtDVDVT.TabIndex = 32;
            // 
            // lblDVGia
            // 
            this.lblDVGia.AutoSize = true;
            this.lblDVGia.Location = new System.Drawing.Point(628, 20);
            this.lblDVGia.Name = "lblDVGia";
            this.lblDVGia.Text = "Đơn giá";
            // 
            // numDVGia
            // 
            this.numDVGia.Location = new System.Drawing.Point(690, 16);
            this.numDVGia.Name = "numDVGia";
            this.numDVGia.Size = new System.Drawing.Size(130, 25);
            this.numDVGia.ThousandsSeparator = true;
            this.numDVGia.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDVGia.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            this.numDVGia.TabIndex = 34;
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(742, 52);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(110, 29);
            this.btnThemDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemDV.TabIndex = 35;
            this.btnThemDV.Text = "Thêm";
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // dgvDV
            // 
            this.dgvDV.Location = new System.Drawing.Point(16, 92);
            this.dgvDV.Name = "dgvDV";
            this.dgvDV.Size = new System.Drawing.Size(836, 358);
            this.dgvDV.AllowUserToAddRows = false;
            this.dgvDV.AllowUserToDeleteRows = false;
            this.dgvDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDV.MultiSelect = false;
            this.dgvDV.RowHeadersVisible = false;
            this.dgvDV.ReadOnly = true;
            this.dgvDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDV.TabIndex = 36;
            // 
            // tabQuyDinh
            // 
            this.tabQuyDinh.Controls.Add(this.lblQDMa);
            this.tabQuyDinh.Controls.Add(this.txtQDMa);
            this.tabQuyDinh.Controls.Add(this.lblQDLoai);
            this.tabQuyDinh.Controls.Add(this.cboQDLoai);
            this.tabQuyDinh.Controls.Add(this.lblQDMucDo);
            this.tabQuyDinh.Controls.Add(this.txtQDMucDo);
            this.tabQuyDinh.Controls.Add(this.lblQDTien);
            this.tabQuyDinh.Controls.Add(this.numQDTien);
            this.tabQuyDinh.Controls.Add(this.btnThemQD);
            this.tabQuyDinh.Controls.Add(this.dgvQD);
            this.tabQuyDinh.Name = "tabQuyDinh";
            this.tabQuyDinh.Size = new System.Drawing.Size(868, 466);
            this.tabQuyDinh.Text = "Quy định đền bù";
            this.tabQuyDinh.UseVisualStyleBackColor = true;
            // 
            // lblQDMa
            // 
            this.lblQDMa.AutoSize = true;
            this.lblQDMa.Location = new System.Drawing.Point(16, 20);
            this.lblQDMa.Name = "lblQDMa";
            this.lblQDMa.Text = "Mã quy định";
            // 
            // txtQDMa
            // 
            this.txtQDMa.Location = new System.Drawing.Point(110, 16);
            this.txtQDMa.Name = "txtQDMa";
            this.txtQDMa.Size = new System.Drawing.Size(110, 25);
            this.txtQDMa.MaxLength = 30;
            this.txtQDMa.TabIndex = 39;
            // 
            // lblQDLoai
            // 
            this.lblQDLoai.AutoSize = true;
            this.lblQDLoai.Location = new System.Drawing.Point(236, 20);
            this.lblQDLoai.Name = "lblQDLoai";
            this.lblQDLoai.Text = "Loại tiện nghi";
            // 
            // cboQDLoai
            // 
            this.cboQDLoai.Location = new System.Drawing.Point(340, 16);
            this.cboQDLoai.Name = "cboQDLoai";
            this.cboQDLoai.Size = new System.Drawing.Size(170, 25);
            this.cboQDLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQDLoai.TabIndex = 41;
            // 
            // lblQDMucDo
            // 
            this.lblQDMucDo.AutoSize = true;
            this.lblQDMucDo.Location = new System.Drawing.Point(524, 20);
            this.lblQDMucDo.Name = "lblQDMucDo";
            this.lblQDMucDo.Text = "Mức độ thiệt hại";
            // 
            // txtQDMucDo
            // 
            this.txtQDMucDo.Location = new System.Drawing.Point(640, 16);
            this.txtQDMucDo.Name = "txtQDMucDo";
            this.txtQDMucDo.Size = new System.Drawing.Size(180, 25);
            this.txtQDMucDo.MaxLength = 80;
            this.txtQDMucDo.TabIndex = 43;
            // 
            // lblQDTien
            // 
            this.lblQDTien.AutoSize = true;
            this.lblQDTien.Location = new System.Drawing.Point(16, 58);
            this.lblQDTien.Name = "lblQDTien";
            this.lblQDTien.Text = "Mức đền bù";
            // 
            // numQDTien
            // 
            this.numQDTien.Location = new System.Drawing.Point(110, 54);
            this.numQDTien.Name = "numQDTien";
            this.numQDTien.Size = new System.Drawing.Size(150, 25);
            this.numQDTien.ThousandsSeparator = true;
            this.numQDTien.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numQDTien.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numQDTien.TabIndex = 45;
            // 
            // btnThemQD
            // 
            this.btnThemQD.Location = new System.Drawing.Point(742, 52);
            this.btnThemQD.Name = "btnThemQD";
            this.btnThemQD.Size = new System.Drawing.Size(110, 29);
            this.btnThemQD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemQD.TabIndex = 46;
            this.btnThemQD.Text = "Thêm";
            this.btnThemQD.Click += new System.EventHandler(this.btnThemQD_Click);
            // 
            // dgvQD
            // 
            this.dgvQD.Location = new System.Drawing.Point(16, 92);
            this.dgvQD.Name = "dgvQD";
            this.dgvQD.Size = new System.Drawing.Size(836, 358);
            this.dgvQD.AllowUserToAddRows = false;
            this.dgvQD.AllowUserToDeleteRows = false;
            this.dgvQD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQD.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvQD.MultiSelect = false;
            this.dgvQD.RowHeadersVisible = false;
            this.dgvQD.ReadOnly = true;
            this.dgvQD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQD.TabIndex = 47;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(788, 516);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.TabIndex = 48;
            this.btnDong.Text = "Đóng";
            // 
            // FrmDanhMuc
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục nền";
            this.AutoScroll = true;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDVGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQDTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQD)).EndInit();
            this.tabQuyDinh.ResumeLayout(false);
            this.tabQuyDinh.PerformLayout();
            this.tabDichVu.ResumeLayout(false);
            this.tabDichVu.PerformLayout();
            this.tabLoaiTN.ResumeLayout(false);
            this.tabLoaiTN.PerformLayout();
            this.tabNhanVien.ResumeLayout(false);
            this.tabNhanVien.PerformLayout();
            this.tabKhuVuc.ResumeLayout(false);
            this.tabKhuVuc.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabKhuVuc;
        private System.Windows.Forms.Label lblKhuMa;
        private System.Windows.Forms.TextBox txtKhuMa;
        private System.Windows.Forms.Label lblKhuTen;
        private System.Windows.Forms.TextBox txtKhuTen;
        private System.Windows.Forms.Button btnThemKhu;
        private System.Windows.Forms.DataGridView dgvKhu;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.Label lblNVMa;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.Label lblNVTen;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.Label lblNVVaiTro;
        private System.Windows.Forms.ComboBox cboNVVaiTro;
        private System.Windows.Forms.Label lblNVSDT;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.TabPage tabLoaiTN;
        private System.Windows.Forms.Label lblLoaiMa;
        private System.Windows.Forms.TextBox txtLoaiMa;
        private System.Windows.Forms.Label lblLoaiTen;
        private System.Windows.Forms.TextBox txtLoaiTen;
        private System.Windows.Forms.Button btnThemLoaiTN;
        private System.Windows.Forms.DataGridView dgvLoaiTN;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.Label lblDVMa;
        private System.Windows.Forms.TextBox txtDVMa;
        private System.Windows.Forms.Label lblDVTen;
        private System.Windows.Forms.TextBox txtDVTen;
        private System.Windows.Forms.Label lblDVDVT;
        private System.Windows.Forms.TextBox txtDVDVT;
        private System.Windows.Forms.Label lblDVGia;
        private System.Windows.Forms.NumericUpDown numDVGia;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.DataGridView dgvDV;
        private System.Windows.Forms.TabPage tabQuyDinh;
        private System.Windows.Forms.Label lblQDMa;
        private System.Windows.Forms.TextBox txtQDMa;
        private System.Windows.Forms.Label lblQDLoai;
        private System.Windows.Forms.ComboBox cboQDLoai;
        private System.Windows.Forms.Label lblQDMucDo;
        private System.Windows.Forms.TextBox txtQDMucDo;
        private System.Windows.Forms.Label lblQDTien;
        private System.Windows.Forms.NumericUpDown numQDTien;
        private System.Windows.Forms.Button btnThemQD;
        private System.Windows.Forms.DataGridView dgvQD;
        private System.Windows.Forms.Button btnDong;
    }
}
