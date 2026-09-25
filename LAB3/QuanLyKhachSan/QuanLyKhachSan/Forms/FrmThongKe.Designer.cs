namespace QuanLyKhachSan.Forms
{
    partial class FrmThongKe
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
            this.lblTu = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.lblTenSoPhieuDat = new System.Windows.Forms.Label();
            this.lblSoPhieuDat = new System.Windows.Forms.Label();
            this.lblTenDangO = new System.Windows.Forms.Label();
            this.lblDangO = new System.Windows.Forms.Label();
            this.lblTenSoHoaDon = new System.Windows.Forms.Label();
            this.lblSoHoaDon = new System.Windows.Forms.Label();
            this.lblTenTienPhong = new System.Windows.Forms.Label();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.lblTenTienDichVu = new System.Windows.Forms.Label();
            this.lblTienDichVu = new System.Windows.Forms.Label();
            this.lblTenDaThanhToan = new System.Windows.Forms.Label();
            this.lblDaThanhToan = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.tabHoaDon = new System.Windows.Forms.TabPage();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.tabPhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.tabHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTu
            // 
            this.lblTu.AutoSize = true;
            this.lblTu.Location = new System.Drawing.Point(12, 18);
            this.lblTu.Name = "lblTu";
            this.lblTu.Text = "Từ ngày";
            // 
            // dtTu
            // 
            this.dtTu.Location = new System.Drawing.Point(80, 14);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(130, 25);
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            this.dtTu.TabIndex = 1;
            // 
            // lblDen
            // 
            this.lblDen.AutoSize = true;
            this.lblDen.Location = new System.Drawing.Point(226, 18);
            this.lblDen.Name = "lblDen";
            this.lblDen.Text = "Đến ngày";
            // 
            // dtDen
            // 
            this.dtDen.Location = new System.Drawing.Point(300, 14);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(130, 25);
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            this.dtDen.TabIndex = 3;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(450, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 30);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXuat
            // 
            this.btnXuat.Location = new System.Drawing.Point(556, 12);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(150, 30);
            this.btnXuat.TabIndex = 5;
            this.btnXuat.Text = "Xuất Excel (CSV)";
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // lblThongBao
            // 
            this.lblThongBao.Location = new System.Drawing.Point(716, 18);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(324, 22);
            this.lblThongBao.ForeColor = System.Drawing.Color.DimGray;
            this.lblThongBao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongBao.Text = "";
            // 
            // lblTenSoPhieuDat
            // 
            this.lblTenSoPhieuDat.Location = new System.Drawing.Point(12, 56);
            this.lblTenSoPhieuDat.Name = "lblTenSoPhieuDat";
            this.lblTenSoPhieuDat.Size = new System.Drawing.Size(162, 22);
            this.lblTenSoPhieuDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenSoPhieuDat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenSoPhieuDat.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenSoPhieuDat.Text = "Phiếu đặt";
            // 
            // lblSoPhieuDat
            // 
            this.lblSoPhieuDat.Location = new System.Drawing.Point(12, 78);
            this.lblSoPhieuDat.Name = "lblSoPhieuDat";
            this.lblSoPhieuDat.Size = new System.Drawing.Size(162, 42);
            this.lblSoPhieuDat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoPhieuDat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSoPhieuDat.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSoPhieuDat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblSoPhieuDat.Text = "0";
            // 
            // lblTenDangO
            // 
            this.lblTenDangO.Location = new System.Drawing.Point(182, 56);
            this.lblTenDangO.Name = "lblTenDangO";
            this.lblTenDangO.Size = new System.Drawing.Size(162, 22);
            this.lblTenDangO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenDangO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenDangO.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenDangO.Text = "Đang ở";
            // 
            // lblDangO
            // 
            this.lblDangO.Location = new System.Drawing.Point(182, 78);
            this.lblDangO.Name = "lblDangO";
            this.lblDangO.Size = new System.Drawing.Size(162, 42);
            this.lblDangO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDangO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDangO.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDangO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDangO.Text = "0";
            // 
            // lblTenSoHoaDon
            // 
            this.lblTenSoHoaDon.Location = new System.Drawing.Point(352, 56);
            this.lblTenSoHoaDon.Name = "lblTenSoHoaDon";
            this.lblTenSoHoaDon.Size = new System.Drawing.Size(162, 22);
            this.lblTenSoHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenSoHoaDon.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenSoHoaDon.Text = "Hóa đơn";
            // 
            // lblSoHoaDon
            // 
            this.lblSoHoaDon.Location = new System.Drawing.Point(352, 78);
            this.lblSoHoaDon.Name = "lblSoHoaDon";
            this.lblSoHoaDon.Size = new System.Drawing.Size(162, 42);
            this.lblSoHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSoHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblSoHoaDon.Text = "0";
            // 
            // lblTenTienPhong
            // 
            this.lblTenTienPhong.Location = new System.Drawing.Point(522, 56);
            this.lblTenTienPhong.Name = "lblTenTienPhong";
            this.lblTenTienPhong.Size = new System.Drawing.Size(162, 22);
            this.lblTenTienPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenTienPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenTienPhong.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenTienPhong.Text = "Tiền phòng";
            // 
            // lblTienPhong
            // 
            this.lblTienPhong.Location = new System.Drawing.Point(522, 78);
            this.lblTienPhong.Name = "lblTienPhong";
            this.lblTienPhong.Size = new System.Drawing.Size(162, 42);
            this.lblTienPhong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTienPhong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTienPhong.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTienPhong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTienPhong.Text = "0";
            // 
            // lblTenTienDichVu
            // 
            this.lblTenTienDichVu.Location = new System.Drawing.Point(692, 56);
            this.lblTenTienDichVu.Name = "lblTenTienDichVu";
            this.lblTenTienDichVu.Size = new System.Drawing.Size(162, 22);
            this.lblTenTienDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenTienDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenTienDichVu.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenTienDichVu.Text = "Tiền dịch vụ";
            // 
            // lblTienDichVu
            // 
            this.lblTienDichVu.Location = new System.Drawing.Point(692, 78);
            this.lblTienDichVu.Name = "lblTienDichVu";
            this.lblTienDichVu.Size = new System.Drawing.Size(162, 42);
            this.lblTienDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTienDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTienDichVu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTienDichVu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTienDichVu.Text = "0";
            // 
            // lblTenDaThanhToan
            // 
            this.lblTenDaThanhToan.Location = new System.Drawing.Point(862, 56);
            this.lblTenDaThanhToan.Name = "lblTenDaThanhToan";
            this.lblTenDaThanhToan.Size = new System.Drawing.Size(162, 22);
            this.lblTenDaThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTenDaThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTenDaThanhToan.ForeColor = System.Drawing.Color.DimGray;
            this.lblTenDaThanhToan.Text = "Đã thu";
            // 
            // lblDaThanhToan
            // 
            this.lblDaThanhToan.Location = new System.Drawing.Point(862, 78);
            this.lblDaThanhToan.Name = "lblDaThanhToan";
            this.lblDaThanhToan.Size = new System.Drawing.Size(162, 42);
            this.lblDaThanhToan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDaThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDaThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDaThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDaThanhToan.Text = "0";
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabDichVu);
            this.tabs.Controls.Add(this.tabPhong);
            this.tabs.Controls.Add(this.tabHoaDon);
            this.tabs.Location = new System.Drawing.Point(12, 132);
            this.tabs.Name = "tabs";
            this.tabs.Size = new System.Drawing.Size(1028, 434);
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // tabDichVu
            // 
            this.tabDichVu.Controls.Add(this.dgvDichVu);
            this.tabDichVu.Name = "tabDichVu";
            this.tabDichVu.Size = new System.Drawing.Size(1020, 400);
            this.tabDichVu.Text = "Dịch vụ sử dụng";
            this.tabDichVu.UseVisualStyleBackColor = true;
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.Location = new System.Drawing.Point(6, 6);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.Size = new System.Drawing.Size(1008, 388);
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDichVu.MultiSelect = false;
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDichVu.TabIndex = 21;
            // 
            // tabPhong
            // 
            this.tabPhong.Controls.Add(this.dgvPhong);
            this.tabPhong.Name = "tabPhong";
            this.tabPhong.Size = new System.Drawing.Size(1020, 400);
            this.tabPhong.Text = "Công suất phòng";
            this.tabPhong.UseVisualStyleBackColor = true;
            // 
            // dgvPhong
            // 
            this.dgvPhong.Location = new System.Drawing.Point(6, 6);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.Size = new System.Drawing.Size(1008, 388);
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AllowUserToDeleteRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPhong.MultiSelect = false;
            this.dgvPhong.RowHeadersVisible = false;
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhong.TabIndex = 23;
            // 
            // tabHoaDon
            // 
            this.tabHoaDon.Controls.Add(this.dgvHoaDon);
            this.tabHoaDon.Name = "tabHoaDon";
            this.tabHoaDon.Size = new System.Drawing.Size(1020, 400);
            this.tabHoaDon.Text = "Hóa đơn";
            this.tabHoaDon.UseVisualStyleBackColor = true;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.Location = new System.Drawing.Point(6, 6);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.Size = new System.Drawing.Size(1008, 388);
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDon.TabIndex = 25;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(940, 570);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 26);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.TabIndex = 26;
            this.btnDong.Text = "Đóng";
            // 
            // FrmThongKe
            // 
            this.AcceptButton = this.btnXem;
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(1052, 600);
            this.Controls.Add(this.lblTu);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.lblDen);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.lblThongBao);
            this.Controls.Add(this.lblTenSoPhieuDat);
            this.Controls.Add(this.lblSoPhieuDat);
            this.Controls.Add(this.lblTenDangO);
            this.Controls.Add(this.lblDangO);
            this.Controls.Add(this.lblTenSoHoaDon);
            this.Controls.Add(this.lblSoHoaDon);
            this.Controls.Add(this.lblTenTienPhong);
            this.Controls.Add(this.lblTienPhong);
            this.Controls.Add(this.lblTenTienDichVu);
            this.Controls.Add(this.lblTienDichVu);
            this.Controls.Add(this.lblTenDaThanhToan);
            this.Controls.Add(this.lblDaThanhToan);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thống kê";
            this.AutoScroll = true;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.tabHoaDon.ResumeLayout(false);
            this.tabHoaDon.PerformLayout();
            this.tabPhong.ResumeLayout(false);
            this.tabPhong.PerformLayout();
            this.tabDichVu.ResumeLayout(false);
            this.tabDichVu.PerformLayout();
            this.tabs.ResumeLayout(false);
            this.tabs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTu;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.Label lblTenSoPhieuDat;
        private System.Windows.Forms.Label lblSoPhieuDat;
        private System.Windows.Forms.Label lblTenDangO;
        private System.Windows.Forms.Label lblDangO;
        private System.Windows.Forms.Label lblTenSoHoaDon;
        private System.Windows.Forms.Label lblSoHoaDon;
        private System.Windows.Forms.Label lblTenTienPhong;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.Label lblTenTienDichVu;
        private System.Windows.Forms.Label lblTienDichVu;
        private System.Windows.Forms.Label lblTenDaThanhToan;
        private System.Windows.Forms.Label lblDaThanhToan;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.TabPage tabPhong;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.TabPage tabHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnDong;
    }
}
