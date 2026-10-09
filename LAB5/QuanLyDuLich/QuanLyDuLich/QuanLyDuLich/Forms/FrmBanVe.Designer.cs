namespace QuanLyDuLich.Forms
{
    partial class FrmBanVe
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
            this.dgvChuyen = new System.Windows.Forms.DataGridView();
            this.grpLich = new System.Windows.Forms.GroupBox();
            this.lblTourLich = new System.Windows.Forms.Label();
            this.cboTourLich = new System.Windows.Forms.ComboBox();
            this.lblNgayDiLich = new System.Windows.Forms.Label();
            this.dtpNgayDiLich = new System.Windows.Forms.DateTimePicker();
            this.lblSoCho = new System.Windows.Forms.Label();
            this.numSoCho = new System.Windows.Forms.NumericUpDown();
            this.btnThemChuyen = new System.Windows.Forms.Button();
            this.grpTT = new System.Windows.Forms.GroupBox();
            this.lblChuyenChon = new System.Windows.Forms.Label();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.btnHuyChuyen = new System.Windows.Forms.Button();
            this.grpBan = new System.Windows.Forms.GroupBox();
            this.lblSoGiayTo = new System.Windows.Forms.Label();
            this.txtSoGiayTo = new System.Windows.Forms.TextBox();
            this.btnTimKhach = new System.Windows.Forms.Button();
            this.lblKhachCu = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblDiemBan = new System.Windows.Forms.Label();
            this.cboDiemBan = new System.Windows.Forms.ComboBox();
            this.lblDiemDon = new System.Windows.Forms.Label();
            this.cboDiemDon = new System.Windows.Forms.ComboBox();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.numSoNguoi = new System.Windows.Forms.NumericUpDown();
            this.lblThanhTien = new System.Windows.Forms.Label();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.lblVe = new System.Windows.Forms.Label();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.btnHuyVe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyen)).BeginInit();
            this.grpLich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoCho)).BeginInit();
            this.grpTT.SuspendLayout();
            this.grpBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
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
            this.lblTitle.Text = "CHUYẾN ĐI KHÁCH LẺ VÀ BÁN VÉ (1 – 12 người)";
            // 
            // dgvChuyen
            // 
            this.dgvChuyen.Location = new System.Drawing.Point(12, 50);
            this.dgvChuyen.Name = "dgvChuyen";
            this.dgvChuyen.Size = new System.Drawing.Size(760, 300);
            this.dgvChuyen.AllowUserToAddRows = false;
            this.dgvChuyen.AllowUserToDeleteRows = false;
            this.dgvChuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChuyen.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvChuyen.MultiSelect = false;
            this.dgvChuyen.RowHeadersVisible = false;
            this.dgvChuyen.ReadOnly = true;
            this.dgvChuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChuyen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChuyen.TabIndex = 1;
            this.dgvChuyen.SelectionChanged += new System.EventHandler(this.dgvChuyen_SelectionChanged);
            // 
            // grpLich
            // 
            this.grpLich.Controls.Add(this.lblTourLich);
            this.grpLich.Controls.Add(this.cboTourLich);
            this.grpLich.Controls.Add(this.lblNgayDiLich);
            this.grpLich.Controls.Add(this.dtpNgayDiLich);
            this.grpLich.Controls.Add(this.lblSoCho);
            this.grpLich.Controls.Add(this.numSoCho);
            this.grpLich.Controls.Add(this.btnThemChuyen);
            this.grpLich.Location = new System.Drawing.Point(784, 46);
            this.grpLich.Name = "grpLich";
            this.grpLich.Size = new System.Drawing.Size(384, 160);
            this.grpLich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLich.Text = "Lập lịch chuyến mới";
            // 
            // lblTourLich
            // 
            this.lblTourLich.AutoSize = true;
            this.lblTourLich.Location = new System.Drawing.Point(12, 30);
            this.lblTourLich.Name = "lblTourLich";
            this.lblTourLich.Text = "Tour";
            // 
            // cboTourLich
            // 
            this.cboTourLich.Location = new System.Drawing.Point(100, 27);
            this.cboTourLich.Name = "cboTourLich";
            this.cboTourLich.Size = new System.Drawing.Size(270, 25);
            this.cboTourLich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTourLich.TabIndex = 4;
            // 
            // lblNgayDiLich
            // 
            this.lblNgayDiLich.AutoSize = true;
            this.lblNgayDiLich.Location = new System.Drawing.Point(12, 64);
            this.lblNgayDiLich.Name = "lblNgayDiLich";
            this.lblNgayDiLich.Text = "Ngày đi";
            // 
            // dtpNgayDiLich
            // 
            this.dtpNgayDiLich.Location = new System.Drawing.Point(100, 61);
            this.dtpNgayDiLich.Name = "dtpNgayDiLich";
            this.dtpNgayDiLich.Size = new System.Drawing.Size(130, 25);
            this.dtpNgayDiLich.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDiLich.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDiLich.TabIndex = 6;
            // 
            // lblSoCho
            // 
            this.lblSoCho.AutoSize = true;
            this.lblSoCho.Location = new System.Drawing.Point(12, 98);
            this.lblSoCho.Name = "lblSoCho";
            this.lblSoCho.Text = "Số chỗ";
            // 
            // numSoCho
            // 
            this.numSoCho.Location = new System.Drawing.Point(100, 95);
            this.numSoCho.Name = "numSoCho";
            this.numSoCho.Size = new System.Drawing.Size(80, 25);
            this.numSoCho.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoCho.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            this.numSoCho.Value = new decimal(new int[] { 30, 0, 0, 0 });
            this.numSoCho.TabIndex = 8;
            // 
            // btnThemChuyen
            // 
            this.btnThemChuyen.Location = new System.Drawing.Point(230, 112);
            this.btnThemChuyen.Name = "btnThemChuyen";
            this.btnThemChuyen.Size = new System.Drawing.Size(140, 32);
            this.btnThemChuyen.TabIndex = 9;
            this.btnThemChuyen.Text = "Thêm chuyến";
            this.btnThemChuyen.Click += new System.EventHandler(this.btnThemChuyen_Click);
            // 
            // grpTT
            // 
            this.grpTT.Controls.Add(this.lblChuyenChon);
            this.grpTT.Controls.Add(this.btnBatDau);
            this.grpTT.Controls.Add(this.btnKetThuc);
            this.grpTT.Controls.Add(this.btnHuyChuyen);
            this.grpTT.Location = new System.Drawing.Point(784, 212);
            this.grpTT.Name = "grpTT";
            this.grpTT.Size = new System.Drawing.Size(384, 138);
            this.grpTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTT.Text = "Tình trạng chuyến đang chọn";
            // 
            // lblChuyenChon
            // 
            this.lblChuyenChon.Location = new System.Drawing.Point(12, 28);
            this.lblChuyenChon.Name = "lblChuyenChon";
            this.lblChuyenChon.Size = new System.Drawing.Size(360, 40);
            this.lblChuyenChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChuyenChon.Text = "Chưa chọn chuyến";
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(12, 86);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(115, 32);
            this.btnBatDau.TabIndex = 12;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(134, 86);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(115, 32);
            this.btnKetThuc.TabIndex = 13;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // btnHuyChuyen
            // 
            this.btnHuyChuyen.Location = new System.Drawing.Point(256, 86);
            this.btnHuyChuyen.Name = "btnHuyChuyen";
            this.btnHuyChuyen.Size = new System.Drawing.Size(115, 32);
            this.btnHuyChuyen.TabIndex = 14;
            this.btnHuyChuyen.Text = "Hủy chuyến";
            this.btnHuyChuyen.Click += new System.EventHandler(this.btnHuyChuyen_Click);
            // 
            // grpBan
            // 
            this.grpBan.Controls.Add(this.lblSoGiayTo);
            this.grpBan.Controls.Add(this.txtSoGiayTo);
            this.grpBan.Controls.Add(this.btnTimKhach);
            this.grpBan.Controls.Add(this.lblKhachCu);
            this.grpBan.Controls.Add(this.lblHoTen);
            this.grpBan.Controls.Add(this.txtHoTen);
            this.grpBan.Controls.Add(this.lblDienThoai);
            this.grpBan.Controls.Add(this.txtDienThoai);
            this.grpBan.Controls.Add(this.lblDiaChi);
            this.grpBan.Controls.Add(this.txtDiaChi);
            this.grpBan.Controls.Add(this.lblDiemBan);
            this.grpBan.Controls.Add(this.cboDiemBan);
            this.grpBan.Controls.Add(this.lblDiemDon);
            this.grpBan.Controls.Add(this.cboDiemDon);
            this.grpBan.Controls.Add(this.lblSoNguoi);
            this.grpBan.Controls.Add(this.numSoNguoi);
            this.grpBan.Controls.Add(this.lblThanhTien);
            this.grpBan.Controls.Add(this.btnBanVe);
            this.grpBan.Location = new System.Drawing.Point(12, 360);
            this.grpBan.Name = "grpBan";
            this.grpBan.Size = new System.Drawing.Size(560, 330);
            this.grpBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBan.Text = "Bán vé cho khách lẻ";
            // 
            // lblSoGiayTo
            // 
            this.lblSoGiayTo.AutoSize = true;
            this.lblSoGiayTo.Location = new System.Drawing.Point(15, 32);
            this.lblSoGiayTo.Name = "lblSoGiayTo";
            this.lblSoGiayTo.Text = "CMND / CCCD";
            // 
            // txtSoGiayTo
            // 
            this.txtSoGiayTo.Location = new System.Drawing.Point(130, 29);
            this.txtSoGiayTo.Name = "txtSoGiayTo";
            this.txtSoGiayTo.Size = new System.Drawing.Size(180, 25);
            this.txtSoGiayTo.MaxLength = 20;
            this.txtSoGiayTo.TabIndex = 17;
            // 
            // btnTimKhach
            // 
            this.btnTimKhach.Location = new System.Drawing.Point(320, 26);
            this.btnTimKhach.Name = "btnTimKhach";
            this.btnTimKhach.Size = new System.Drawing.Size(100, 32);
            this.btnTimKhach.TabIndex = 18;
            this.btnTimKhach.Text = "Tìm khách";
            this.btnTimKhach.Click += new System.EventHandler(this.btnTimKhach_Click);
            // 
            // lblKhachCu
            // 
            this.lblKhachCu.Location = new System.Drawing.Point(430, 32);
            this.lblKhachCu.Name = "lblKhachCu";
            this.lblKhachCu.Size = new System.Drawing.Size(120, 22);
            this.lblKhachCu.ForeColor = System.Drawing.Color.DimGray;
            this.lblKhachCu.Text = "";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 66);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(130, 63);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(410, 25);
            this.txtHoTen.MaxLength = 100;
            this.txtHoTen.TabIndex = 21;
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Location = new System.Drawing.Point(15, 100);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Text = "Điện thoại";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(130, 97);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(180, 25);
            this.txtDienThoai.MaxLength = 15;
            this.txtDienThoai.TabIndex = 23;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(15, 134);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(130, 131);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(410, 25);
            this.txtDiaChi.MaxLength = 300;
            this.txtDiaChi.TabIndex = 25;
            // 
            // lblDiemBan
            // 
            this.lblDiemBan.AutoSize = true;
            this.lblDiemBan.Location = new System.Drawing.Point(15, 168);
            this.lblDiemBan.Name = "lblDiemBan";
            this.lblDiemBan.Text = "Điểm bán vé";
            // 
            // cboDiemBan
            // 
            this.cboDiemBan.Location = new System.Drawing.Point(130, 165);
            this.cboDiemBan.Name = "cboDiemBan";
            this.cboDiemBan.Size = new System.Drawing.Size(410, 25);
            this.cboDiemBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiemBan.TabIndex = 27;
            // 
            // lblDiemDon
            // 
            this.lblDiemDon.AutoSize = true;
            this.lblDiemDon.Location = new System.Drawing.Point(15, 202);
            this.lblDiemDon.Name = "lblDiemDon";
            this.lblDiemDon.Text = "Điểm đón";
            // 
            // cboDiemDon
            // 
            this.cboDiemDon.Location = new System.Drawing.Point(130, 199);
            this.cboDiemDon.Name = "cboDiemDon";
            this.cboDiemDon.Size = new System.Drawing.Size(410, 25);
            this.cboDiemDon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiemDon.TabIndex = 29;
            // 
            // lblSoNguoi
            // 
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Location = new System.Drawing.Point(15, 236);
            this.lblSoNguoi.Name = "lblSoNguoi";
            this.lblSoNguoi.Text = "Số người";
            // 
            // numSoNguoi
            // 
            this.numSoNguoi.Location = new System.Drawing.Point(130, 233);
            this.numSoNguoi.Name = "numSoNguoi";
            this.numSoNguoi.Size = new System.Drawing.Size(70, 25);
            this.numSoNguoi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNguoi.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numSoNguoi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNguoi.TabIndex = 31;
            this.numSoNguoi.ValueChanged += new System.EventHandler(this.numSoNguoi_ValueChanged);
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.AutoSize = true;
            this.lblThanhTien.Location = new System.Drawing.Point(220, 236);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblThanhTien.Text = "Thành tiền: 0 đ";
            // 
            // btnBanVe
            // 
            this.btnBanVe.Location = new System.Drawing.Point(130, 276);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(160, 38);
            this.btnBanVe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBanVe.TabIndex = 33;
            this.btnBanVe.Text = "Bán vé";
            this.btnBanVe.Click += new System.EventHandler(this.btnBanVe_Click);
            // 
            // lblVe
            // 
            this.lblVe.AutoSize = true;
            this.lblVe.Location = new System.Drawing.Point(590, 364);
            this.lblVe.Name = "lblVe";
            this.lblVe.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVe.Text = "Vé đã bán của chuyến đang chọn";
            // 
            // dgvVe
            // 
            this.dgvVe.Location = new System.Drawing.Point(590, 388);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.Size = new System.Drawing.Size(578, 260);
            this.dgvVe.AllowUserToAddRows = false;
            this.dgvVe.AllowUserToDeleteRows = false;
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVe.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvVe.MultiSelect = false;
            this.dgvVe.RowHeadersVisible = false;
            this.dgvVe.ReadOnly = true;
            this.dgvVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVe.TabIndex = 35;
            // 
            // btnHuyVe
            // 
            this.btnHuyVe.Location = new System.Drawing.Point(1048, 656);
            this.btnHuyVe.Name = "btnHuyVe";
            this.btnHuyVe.Size = new System.Drawing.Size(120, 32);
            this.btnHuyVe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyVe.TabIndex = 36;
            this.btnHuyVe.Text = "Hủy vé";
            this.btnHuyVe.Click += new System.EventHandler(this.btnHuyVe_Click);
            // 
            // FrmBanVe
            // 
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvChuyen);
            this.Controls.Add(this.grpLich);
            this.Controls.Add(this.grpTT);
            this.Controls.Add(this.grpBan);
            this.Controls.Add(this.lblVe);
            this.Controls.Add(this.dgvVe);
            this.Controls.Add(this.btnHuyVe);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmBanVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chuyến đi và bán vé cho khách lẻ";
            this.MinimumSize = new System.Drawing.Size(1196, 739);
            this.Load += new System.EventHandler(this.FrmBanVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoCho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNguoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.grpBan.ResumeLayout(false);
            this.grpBan.PerformLayout();
            this.grpTT.ResumeLayout(false);
            this.grpTT.PerformLayout();
            this.grpLich.ResumeLayout(false);
            this.grpLich.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvChuyen;
        private System.Windows.Forms.GroupBox grpLich;
        private System.Windows.Forms.Label lblTourLich;
        private System.Windows.Forms.ComboBox cboTourLich;
        private System.Windows.Forms.Label lblNgayDiLich;
        private System.Windows.Forms.DateTimePicker dtpNgayDiLich;
        private System.Windows.Forms.Label lblSoCho;
        private System.Windows.Forms.NumericUpDown numSoCho;
        private System.Windows.Forms.Button btnThemChuyen;
        private System.Windows.Forms.GroupBox grpTT;
        private System.Windows.Forms.Label lblChuyenChon;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Button btnHuyChuyen;
        private System.Windows.Forms.GroupBox grpBan;
        private System.Windows.Forms.Label lblSoGiayTo;
        private System.Windows.Forms.TextBox txtSoGiayTo;
        private System.Windows.Forms.Button btnTimKhach;
        private System.Windows.Forms.Label lblKhachCu;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblDiemBan;
        private System.Windows.Forms.ComboBox cboDiemBan;
        private System.Windows.Forms.Label lblDiemDon;
        private System.Windows.Forms.ComboBox cboDiemDon;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.NumericUpDown numSoNguoi;
        private System.Windows.Forms.Label lblThanhTien;
        private System.Windows.Forms.Button btnBanVe;
        private System.Windows.Forms.Label lblVe;
        private System.Windows.Forms.DataGridView dgvVe;
        private System.Windows.Forms.Button btnHuyVe;
    }
}
