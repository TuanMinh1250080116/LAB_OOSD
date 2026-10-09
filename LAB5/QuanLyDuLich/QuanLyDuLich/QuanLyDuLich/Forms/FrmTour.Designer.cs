namespace QuanLyDuLich.Forms
{
    partial class FrmTour
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
            this.dgvTour = new System.Windows.Forms.DataGridView();
            this.grpTour = new System.Windows.Forms.GroupBox();
            this.lblMaTour = new System.Windows.Forms.Label();
            this.txtMaTour = new System.Windows.Forms.TextBox();
            this.lblTenTour = new System.Windows.Forms.Label();
            this.txtTenTour = new System.Windows.Forms.TextBox();
            this.lblSoNgay = new System.Windows.Forms.Label();
            this.numSoNgay = new System.Windows.Forms.NumericUpDown();
            this.lblSoDem = new System.Windows.Forms.Label();
            this.numSoDem = new System.Windows.Forms.NumericUpDown();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.lblPTVe = new System.Windows.Forms.Label();
            this.cboPTVe = new System.Windows.Forms.ComboBox();
            this.chkDangKD = new System.Windows.Forms.CheckBox();
            this.lblMoTaTour = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.btnMoi = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnNgung = new System.Windows.Forms.Button();
            this.lblNDC = new System.Windows.Forms.Label();
            this.dgvNoiDungChan = new System.Windows.Forms.DataGridView();
            this.grpNDC = new System.Windows.Forms.GroupBox();
            this.cboDiaDanh = new System.Windows.Forms.ComboBox();
            this.cboPT = new System.Windows.Forms.ComboBox();
            this.chkDoiPT = new System.Windows.Forms.CheckBox();
            this.chkNoiAn = new System.Windows.Forms.CheckBox();
            this.chkKhachSan = new System.Windows.Forms.CheckBox();
            this.cboLoaiKS = new System.Windows.Forms.ComboBox();
            this.btnThemNDC = new System.Windows.Forms.Button();
            this.btnXoaNDC = new System.Windows.Forms.Button();
            this.lblDTQ = new System.Windows.Forms.Label();
            this.dgvDiemThamQuan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).BeginInit();
            this.grpTour.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoiDungChan)).BeginInit();
            this.grpNDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemThamQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1076, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Text = "QUẢN LÝ TOUR DU LỊCH";
            // 
            // dgvTour
            // 
            this.dgvTour.Location = new System.Drawing.Point(12, 50);
            this.dgvTour.Name = "dgvTour";
            this.dgvTour.Size = new System.Drawing.Size(615, 300);
            this.dgvTour.AllowUserToAddRows = false;
            this.dgvTour.AllowUserToDeleteRows = false;
            this.dgvTour.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTour.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTour.MultiSelect = false;
            this.dgvTour.RowHeadersVisible = false;
            this.dgvTour.ReadOnly = true;
            this.dgvTour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTour.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTour.TabIndex = 1;
            this.dgvTour.SelectionChanged += new System.EventHandler(this.dgvTour_SelectionChanged);
            // 
            // grpTour
            // 
            this.grpTour.Controls.Add(this.lblMaTour);
            this.grpTour.Controls.Add(this.txtMaTour);
            this.grpTour.Controls.Add(this.lblTenTour);
            this.grpTour.Controls.Add(this.txtTenTour);
            this.grpTour.Controls.Add(this.lblSoNgay);
            this.grpTour.Controls.Add(this.numSoNgay);
            this.grpTour.Controls.Add(this.lblSoDem);
            this.grpTour.Controls.Add(this.numSoDem);
            this.grpTour.Controls.Add(this.lblDonGia);
            this.grpTour.Controls.Add(this.numDonGia);
            this.grpTour.Controls.Add(this.lblPTVe);
            this.grpTour.Controls.Add(this.cboPTVe);
            this.grpTour.Controls.Add(this.chkDangKD);
            this.grpTour.Controls.Add(this.lblMoTaTour);
            this.grpTour.Controls.Add(this.txtMoTa);
            this.grpTour.Controls.Add(this.btnMoi);
            this.grpTour.Controls.Add(this.btnThem);
            this.grpTour.Controls.Add(this.btnSua);
            this.grpTour.Controls.Add(this.btnNgung);
            this.grpTour.Location = new System.Drawing.Point(640, 46);
            this.grpTour.Name = "grpTour";
            this.grpTour.Size = new System.Drawing.Size(448, 304);
            this.grpTour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTour.Text = "Thông tin tour";
            // 
            // lblMaTour
            // 
            this.lblMaTour.AutoSize = true;
            this.lblMaTour.Location = new System.Drawing.Point(15, 30);
            this.lblMaTour.Name = "lblMaTour";
            this.lblMaTour.Text = "Mã tour";
            // 
            // txtMaTour
            // 
            this.txtMaTour.Location = new System.Drawing.Point(130, 27);
            this.txtMaTour.Name = "txtMaTour";
            this.txtMaTour.Size = new System.Drawing.Size(120, 25);
            this.txtMaTour.MaxLength = 10;
            this.txtMaTour.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaTour.TabIndex = 4;
            // 
            // lblTenTour
            // 
            this.lblTenTour.AutoSize = true;
            this.lblTenTour.Location = new System.Drawing.Point(15, 64);
            this.lblTenTour.Name = "lblTenTour";
            this.lblTenTour.Text = "Tên tour";
            // 
            // txtTenTour
            // 
            this.txtTenTour.Location = new System.Drawing.Point(130, 61);
            this.txtTenTour.Name = "txtTenTour";
            this.txtTenTour.Size = new System.Drawing.Size(300, 25);
            this.txtTenTour.MaxLength = 200;
            this.txtTenTour.TabIndex = 6;
            // 
            // lblSoNgay
            // 
            this.lblSoNgay.AutoSize = true;
            this.lblSoNgay.Location = new System.Drawing.Point(15, 98);
            this.lblSoNgay.Name = "lblSoNgay";
            this.lblSoNgay.Text = "Số ngày";
            // 
            // numSoNgay
            // 
            this.numSoNgay.Location = new System.Drawing.Point(130, 95);
            this.numSoNgay.Name = "numSoNgay";
            this.numSoNgay.Size = new System.Drawing.Size(70, 25);
            this.numSoNgay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSoNgay.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numSoNgay.Value = new decimal(new int[] { 3, 0, 0, 0 });
            this.numSoNgay.TabIndex = 8;
            // 
            // lblSoDem
            // 
            this.lblSoDem.AutoSize = true;
            this.lblSoDem.Location = new System.Drawing.Point(225, 98);
            this.lblSoDem.Name = "lblSoDem";
            this.lblSoDem.Text = "Số đêm";
            // 
            // numSoDem
            // 
            this.numSoDem.Location = new System.Drawing.Point(300, 95);
            this.numSoDem.Name = "numSoDem";
            this.numSoDem.Size = new System.Drawing.Size(70, 25);
            this.numSoDem.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numSoDem.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numSoDem.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.numSoDem.TabIndex = 10;
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(15, 132);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Text = "Đơn giá / khách";
            // 
            // numDonGia
            // 
            this.numDonGia.Location = new System.Drawing.Point(130, 129);
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.Size = new System.Drawing.Size(150, 25);
            this.numDonGia.ThousandsSeparator = true;
            this.numDonGia.Increment = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numDonGia.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDonGia.Maximum = new decimal(new int[] { 200000000, 0, 0, 0 });
            this.numDonGia.Value = new decimal(new int[] { 0, 0, 0, 0 });
            this.numDonGia.TabIndex = 12;
            // 
            // lblPTVe
            // 
            this.lblPTVe.AutoSize = true;
            this.lblPTVe.Location = new System.Drawing.Point(15, 166);
            this.lblPTVe.Name = "lblPTVe";
            this.lblPTVe.Text = "Về TP.HCM bằng";
            // 
            // cboPTVe
            // 
            this.cboPTVe.Location = new System.Drawing.Point(130, 163);
            this.cboPTVe.Name = "cboPTVe";
            this.cboPTVe.Size = new System.Drawing.Size(180, 25);
            this.cboPTVe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPTVe.TabIndex = 14;
            // 
            // chkDangKD
            // 
            this.chkDangKD.AutoSize = true;
            this.chkDangKD.Location = new System.Drawing.Point(130, 198);
            this.chkDangKD.Name = "chkDangKD";
            this.chkDangKD.Checked = true;
            this.chkDangKD.TabIndex = 15;
            this.chkDangKD.Text = "Đang kinh doanh";
            // 
            // lblMoTaTour
            // 
            this.lblMoTaTour.AutoSize = true;
            this.lblMoTaTour.Location = new System.Drawing.Point(15, 230);
            this.lblMoTaTour.Name = "lblMoTaTour";
            this.lblMoTaTour.Text = "Mô tả";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(130, 227);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(300, 25);
            this.txtMoTa.MaxLength = 1000;
            this.txtMoTa.TabIndex = 17;
            // 
            // btnMoi
            // 
            this.btnMoi.Location = new System.Drawing.Point(15, 262);
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(100, 32);
            this.btnMoi.TabIndex = 18;
            this.btnMoi.Text = "Làm mới";
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(122, 262);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 32);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(229, 262);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 32);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Lưu sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnNgung
            // 
            this.btnNgung.Location = new System.Drawing.Point(336, 262);
            this.btnNgung.Name = "btnNgung";
            this.btnNgung.Size = new System.Drawing.Size(100, 32);
            this.btnNgung.TabIndex = 21;
            this.btnNgung.Text = "Ngừng KD";
            this.btnNgung.Click += new System.EventHandler(this.btnNgung_Click);
            // 
            // lblNDC
            // 
            this.lblNDC.AutoSize = true;
            this.lblNDC.Location = new System.Drawing.Point(12, 360);
            this.lblNDC.Name = "lblNDC";
            this.lblNDC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNDC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblNDC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNDC.Text = "Nơi dừng chân (theo thứ tự lộ trình, xuất phát từ TP.HCM)";
            // 
            // dgvNoiDungChan
            // 
            this.dgvNoiDungChan.Location = new System.Drawing.Point(12, 384);
            this.dgvNoiDungChan.Name = "dgvNoiDungChan";
            this.dgvNoiDungChan.Size = new System.Drawing.Size(615, 186);
            this.dgvNoiDungChan.AllowUserToAddRows = false;
            this.dgvNoiDungChan.AllowUserToDeleteRows = false;
            this.dgvNoiDungChan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNoiDungChan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNoiDungChan.MultiSelect = false;
            this.dgvNoiDungChan.RowHeadersVisible = false;
            this.dgvNoiDungChan.ReadOnly = true;
            this.dgvNoiDungChan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNoiDungChan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNoiDungChan.TabIndex = 23;
            // 
            // grpNDC
            // 
            this.grpNDC.Controls.Add(this.cboDiaDanh);
            this.grpNDC.Controls.Add(this.cboPT);
            this.grpNDC.Controls.Add(this.chkDoiPT);
            this.grpNDC.Controls.Add(this.chkNoiAn);
            this.grpNDC.Controls.Add(this.chkKhachSan);
            this.grpNDC.Controls.Add(this.cboLoaiKS);
            this.grpNDC.Controls.Add(this.btnThemNDC);
            this.grpNDC.Controls.Add(this.btnXoaNDC);
            this.grpNDC.Location = new System.Drawing.Point(12, 576);
            this.grpNDC.Name = "grpNDC";
            this.grpNDC.Size = new System.Drawing.Size(615, 76);
            this.grpNDC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpNDC.Text = "Thêm nơi dừng chân";
            // 
            // cboDiaDanh
            // 
            this.cboDiaDanh.Location = new System.Drawing.Point(10, 28);
            this.cboDiaDanh.Name = "cboDiaDanh";
            this.cboDiaDanh.Size = new System.Drawing.Size(130, 25);
            this.cboDiaDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiaDanh.TabIndex = 25;
            // 
            // cboPT
            // 
            this.cboPT.Location = new System.Drawing.Point(146, 28);
            this.cboPT.Name = "cboPT";
            this.cboPT.Size = new System.Drawing.Size(110, 25);
            this.cboPT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPT.TabIndex = 26;
            // 
            // chkDoiPT
            // 
            this.chkDoiPT.AutoSize = true;
            this.chkDoiPT.Location = new System.Drawing.Point(262, 18);
            this.chkDoiPT.Name = "chkDoiPT";
            this.chkDoiPT.TabIndex = 27;
            this.chkDoiPT.Text = "Đổi PT";
            // 
            // chkNoiAn
            // 
            this.chkNoiAn.AutoSize = true;
            this.chkNoiAn.Location = new System.Drawing.Point(262, 44);
            this.chkNoiAn.Name = "chkNoiAn";
            this.chkNoiAn.TabIndex = 28;
            this.chkNoiAn.Text = "Nơi ăn";
            // 
            // chkKhachSan
            // 
            this.chkKhachSan.AutoSize = true;
            this.chkKhachSan.Location = new System.Drawing.Point(340, 18);
            this.chkKhachSan.Name = "chkKhachSan";
            this.chkKhachSan.TabIndex = 29;
            this.chkKhachSan.Text = "Khách sạn";
            this.chkKhachSan.CheckedChanged += new System.EventHandler(this.chkKhachSan_CheckedChanged);
            // 
            // cboLoaiKS
            // 
            this.cboLoaiKS.Location = new System.Drawing.Point(340, 42);
            this.cboLoaiKS.Name = "cboLoaiKS";
            this.cboLoaiKS.Size = new System.Drawing.Size(80, 25);
            this.cboLoaiKS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiKS.TabIndex = 30;
            // 
            // btnThemNDC
            // 
            this.btnThemNDC.Location = new System.Drawing.Point(430, 26);
            this.btnThemNDC.Name = "btnThemNDC";
            this.btnThemNDC.Size = new System.Drawing.Size(80, 32);
            this.btnThemNDC.TabIndex = 31;
            this.btnThemNDC.Text = "Thêm";
            this.btnThemNDC.Click += new System.EventHandler(this.btnThemNDC_Click);
            // 
            // btnXoaNDC
            // 
            this.btnXoaNDC.Location = new System.Drawing.Point(516, 26);
            this.btnXoaNDC.Name = "btnXoaNDC";
            this.btnXoaNDC.Size = new System.Drawing.Size(90, 32);
            this.btnXoaNDC.TabIndex = 32;
            this.btnXoaNDC.Text = "Xóa cuối";
            this.btnXoaNDC.Click += new System.EventHandler(this.btnXoaNDC_Click);
            // 
            // lblDTQ
            // 
            this.lblDTQ.AutoSize = true;
            this.lblDTQ.Location = new System.Drawing.Point(640, 360);
            this.lblDTQ.Name = "lblDTQ";
            this.lblDTQ.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDTQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDTQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDTQ.Text = "Điểm tham quan của tour";
            // 
            // dgvDiemThamQuan
            // 
            this.dgvDiemThamQuan.Location = new System.Drawing.Point(640, 384);
            this.dgvDiemThamQuan.Name = "dgvDiemThamQuan";
            this.dgvDiemThamQuan.Size = new System.Drawing.Size(448, 268);
            this.dgvDiemThamQuan.AllowUserToAddRows = false;
            this.dgvDiemThamQuan.AllowUserToDeleteRows = false;
            this.dgvDiemThamQuan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDiemThamQuan.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDiemThamQuan.MultiSelect = false;
            this.dgvDiemThamQuan.RowHeadersVisible = false;
            this.dgvDiemThamQuan.ReadOnly = true;
            this.dgvDiemThamQuan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDiemThamQuan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDiemThamQuan.TabIndex = 34;
            // 
            // FrmTour
            // 
            this.ClientSize = new System.Drawing.Size(1100, 660);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvTour);
            this.Controls.Add(this.grpTour);
            this.Controls.Add(this.lblNDC);
            this.Controls.Add(this.dgvNoiDungChan);
            this.Controls.Add(this.grpNDC);
            this.Controls.Add(this.lblDTQ);
            this.Controls.Add(this.dgvDiemThamQuan);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmTour";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý tour du lịch";
            this.MinimumSize = new System.Drawing.Size(1116, 699);
            this.Load += new System.EventHandler(this.FrmTour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNoiDungChan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiemThamQuan)).EndInit();
            this.grpNDC.ResumeLayout(false);
            this.grpNDC.PerformLayout();
            this.grpTour.ResumeLayout(false);
            this.grpTour.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvTour;
        private System.Windows.Forms.GroupBox grpTour;
        private System.Windows.Forms.Label lblMaTour;
        private System.Windows.Forms.TextBox txtMaTour;
        private System.Windows.Forms.Label lblTenTour;
        private System.Windows.Forms.TextBox txtTenTour;
        private System.Windows.Forms.Label lblSoNgay;
        private System.Windows.Forms.NumericUpDown numSoNgay;
        private System.Windows.Forms.Label lblSoDem;
        private System.Windows.Forms.NumericUpDown numSoDem;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.Label lblPTVe;
        private System.Windows.Forms.ComboBox cboPTVe;
        private System.Windows.Forms.CheckBox chkDangKD;
        private System.Windows.Forms.Label lblMoTaTour;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Button btnMoi;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnNgung;
        private System.Windows.Forms.Label lblNDC;
        private System.Windows.Forms.DataGridView dgvNoiDungChan;
        private System.Windows.Forms.GroupBox grpNDC;
        private System.Windows.Forms.ComboBox cboDiaDanh;
        private System.Windows.Forms.ComboBox cboPT;
        private System.Windows.Forms.CheckBox chkDoiPT;
        private System.Windows.Forms.CheckBox chkNoiAn;
        private System.Windows.Forms.CheckBox chkKhachSan;
        private System.Windows.Forms.ComboBox cboLoaiKS;
        private System.Windows.Forms.Button btnThemNDC;
        private System.Windows.Forms.Button btnXoaNDC;
        private System.Windows.Forms.Label lblDTQ;
        private System.Windows.Forms.DataGridView dgvDiemThamQuan;
    }
}
