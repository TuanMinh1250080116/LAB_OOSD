namespace QuanLyKhachSan.Forms
{
    partial class FrmDichVu
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
            this.grpGhi = new System.Windows.Forms.GroupBox();
            this.lblLuot = new System.Windows.Forms.Label();
            this.cboLuot = new System.Windows.Forms.ComboBox();
            this.lblPhongTxt = new System.Windows.Forms.Label();
            this.txtPhong = new System.Windows.Forms.TextBox();
            this.lblNgay = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDV = new System.Windows.Forms.Label();
            this.cboDV = new System.Windows.Forms.ComboBox();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.lblSL = new System.Windows.Forms.Label();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.lblNVDV = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnGhi = new System.Windows.Forms.Button();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.lblLichSu = new System.Windows.Forms.Label();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.lblTong = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpGhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // grpGhi
            // 
            this.grpGhi.Controls.Add(this.lblLuot);
            this.grpGhi.Controls.Add(this.cboLuot);
            this.grpGhi.Controls.Add(this.lblPhongTxt);
            this.grpGhi.Controls.Add(this.txtPhong);
            this.grpGhi.Controls.Add(this.lblNgay);
            this.grpGhi.Controls.Add(this.dtNgay);
            this.grpGhi.Controls.Add(this.lblDV);
            this.grpGhi.Controls.Add(this.cboDV);
            this.grpGhi.Controls.Add(this.lblDonGia);
            this.grpGhi.Controls.Add(this.txtDonGia);
            this.grpGhi.Controls.Add(this.lblSL);
            this.grpGhi.Controls.Add(this.numSL);
            this.grpGhi.Controls.Add(this.lblNVDV);
            this.grpGhi.Controls.Add(this.cboNV);
            this.grpGhi.Location = new System.Drawing.Point(12, 12);
            this.grpGhi.Name = "grpGhi";
            this.grpGhi.Size = new System.Drawing.Size(876, 130);
            this.grpGhi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpGhi.Text = "Ghi nhận dịch vụ";
            // 
            // lblLuot
            // 
            this.lblLuot.AutoSize = true;
            this.lblLuot.Location = new System.Drawing.Point(14, 30);
            this.lblLuot.Name = "lblLuot";
            this.lblLuot.Text = "Lượt đang ở";
            // 
            // cboLuot
            // 
            this.cboLuot.Location = new System.Drawing.Point(110, 26);
            this.cboLuot.Name = "cboLuot";
            this.cboLuot.Size = new System.Drawing.Size(330, 25);
            this.cboLuot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLuot.TabIndex = 2;
            this.cboLuot.SelectedIndexChanged += new System.EventHandler(this.cboLuot_SelectedIndexChanged);
            // 
            // lblPhongTxt
            // 
            this.lblPhongTxt.AutoSize = true;
            this.lblPhongTxt.Location = new System.Drawing.Point(456, 30);
            this.lblPhongTxt.Name = "lblPhongTxt";
            this.lblPhongTxt.Text = "Phòng";
            // 
            // txtPhong
            // 
            this.txtPhong.Location = new System.Drawing.Point(506, 26);
            this.txtPhong.Name = "txtPhong";
            this.txtPhong.Size = new System.Drawing.Size(90, 25);
            this.txtPhong.ReadOnly = true;
            this.txtPhong.TabIndex = 4;
            // 
            // lblNgay
            // 
            this.lblNgay.AutoSize = true;
            this.lblNgay.Location = new System.Drawing.Point(620, 30);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Text = "Ngày sử dụng";
            // 
            // dtNgay
            // 
            this.dtNgay.Location = new System.Drawing.Point(714, 26);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(140, 25);
            this.dtNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgay.CustomFormat = "dd/MM/yyyy";
            this.dtNgay.TabIndex = 6;
            // 
            // lblDV
            // 
            this.lblDV.AutoSize = true;
            this.lblDV.Location = new System.Drawing.Point(14, 68);
            this.lblDV.Name = "lblDV";
            this.lblDV.Text = "Dịch vụ";
            // 
            // cboDV
            // 
            this.cboDV.Location = new System.Drawing.Point(110, 64);
            this.cboDV.Name = "cboDV";
            this.cboDV.Size = new System.Drawing.Size(220, 25);
            this.cboDV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDV.TabIndex = 8;
            this.cboDV.SelectedIndexChanged += new System.EventHandler(this.cboDV_SelectedIndexChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.AutoSize = true;
            this.lblDonGia.Location = new System.Drawing.Point(344, 68);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Text = "Đơn giá";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(400, 64);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(110, 25);
            this.txtDonGia.ReadOnly = true;
            this.txtDonGia.TabIndex = 10;
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Location = new System.Drawing.Point(528, 68);
            this.lblSL.Name = "lblSL";
            this.lblSL.Text = "Số lượng";
            // 
            // numSL
            // 
            this.numSL.Location = new System.Drawing.Point(594, 64);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(70, 25);
            this.numSL.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.numSL.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.TabIndex = 12;
            // 
            // lblNVDV
            // 
            this.lblNVDV.AutoSize = true;
            this.lblNVDV.Location = new System.Drawing.Point(676, 68);
            this.lblNVDV.Name = "lblNVDV";
            this.lblNVDV.Text = "NV";
            // 
            // cboNV
            // 
            this.cboNV.Location = new System.Drawing.Point(706, 64);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(148, 25);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.TabIndex = 14;
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(700, 150);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(188, 32);
            this.btnGhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGhi.TabIndex = 15;
            this.btnGhi.Text = "Ghi nhận dịch vụ";
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Location = new System.Drawing.Point(12, 156);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(660, 22);
            this.lblGhiChu.ForeColor = System.Drawing.Color.DimGray;
            this.lblGhiChu.Text = "Cùng một dịch vụ dùng nhiều lần trong ngày sẽ được cộng dồn vào phiếu của ngày đó.";
            // 
            // lblLichSu
            // 
            this.lblLichSu.AutoSize = true;
            this.lblLichSu.Location = new System.Drawing.Point(12, 190);
            this.lblLichSu.Name = "lblLichSu";
            this.lblLichSu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLichSu.Text = "Lịch sử dịch vụ của lượt lưu trú";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.Location = new System.Drawing.Point(12, 214);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.Size = new System.Drawing.Size(876, 232);
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.RowHeadersVisible = false;
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLichSu.TabIndex = 18;
            // 
            // lblTong
            // 
            this.lblTong.Location = new System.Drawing.Point(12, 452);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(600, 24);
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTong.Text = "";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(788, 452);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.TabIndex = 20;
            this.btnDong.Text = "Đóng";
            // 
            // FrmDichVu
            // 
            this.CancelButton = this.btnDong;
            this.ClientSize = new System.Drawing.Size(900, 520);
            this.Controls.Add(this.grpGhi);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.lblLichSu);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmDichVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ghi nhận dịch vụ sử dụng";
            this.AutoScroll = true;
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDichVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.grpGhi.ResumeLayout(false);
            this.grpGhi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpGhi;
        private System.Windows.Forms.Label lblLuot;
        private System.Windows.Forms.ComboBox cboLuot;
        private System.Windows.Forms.Label lblPhongTxt;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.Label lblNgay;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label lblDV;
        private System.Windows.Forms.ComboBox cboDV;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Label lblNVDV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Label lblLichSu;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.Button btnDong;
    }
}
