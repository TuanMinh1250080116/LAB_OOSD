namespace QuanLyDuLich.Forms
{
    partial class FrmPhanCong
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
            this.lblCan = new System.Windows.Forms.Label();
            this.dgvCanPhanCong = new System.Windows.Forms.DataGridView();
            this.lblRanh = new System.Windows.Forms.Label();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.lblDaPC = new System.Windows.Forms.Label();
            this.dgvDaPhanCong = new System.Windows.Forms.DataGridView();
            this.btnHuyPhanCong = new System.Windows.Forms.Button();
            this.lblGoiY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanPhanCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1126, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Text = "PHÂN CÔNG NHÂN VIÊN HƯỚNG DẪN DU LỊCH";
            // 
            // lblCan
            // 
            this.lblCan.AutoSize = true;
            this.lblCan.Location = new System.Drawing.Point(12, 50);
            this.lblCan.Name = "lblCan";
            this.lblCan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblCan.Text = "Đoàn và chuyến chưa khởi hành (chọn một dòng)";
            // 
            // dgvCanPhanCong
            // 
            this.dgvCanPhanCong.Location = new System.Drawing.Point(12, 74);
            this.dgvCanPhanCong.Name = "dgvCanPhanCong";
            this.dgvCanPhanCong.Size = new System.Drawing.Size(1126, 230);
            this.dgvCanPhanCong.AllowUserToAddRows = false;
            this.dgvCanPhanCong.AllowUserToDeleteRows = false;
            this.dgvCanPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCanPhanCong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCanPhanCong.MultiSelect = false;
            this.dgvCanPhanCong.RowHeadersVisible = false;
            this.dgvCanPhanCong.ReadOnly = true;
            this.dgvCanPhanCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCanPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCanPhanCong.TabIndex = 2;
            this.dgvCanPhanCong.SelectionChanged += new System.EventHandler(this.dgvCanPhanCong_SelectionChanged);
            // 
            // lblRanh
            // 
            this.lblRanh.AutoSize = true;
            this.lblRanh.Location = new System.Drawing.Point(12, 316);
            this.lblRanh.Name = "lblRanh";
            this.lblRanh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRanh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblRanh.Text = "Nhân viên rảnh trong khoảng ngày của đoàn / chuyến";
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.Location = new System.Drawing.Point(12, 340);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.Size = new System.Drawing.Size(540, 282);
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhanVien.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvNhanVien.TabIndex = 4;
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(12, 632);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(200, 32);
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPhanCong.TabIndex = 5;
            this.btnPhanCong.Text = "Phân công >>";
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // lblDaPC
            // 
            this.lblDaPC.AutoSize = true;
            this.lblDaPC.Location = new System.Drawing.Point(570, 316);
            this.lblDaPC.Name = "lblDaPC";
            this.lblDaPC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDaPC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblDaPC.Text = "Nhân viên đã phân công";
            // 
            // dgvDaPhanCong
            // 
            this.dgvDaPhanCong.Location = new System.Drawing.Point(570, 340);
            this.dgvDaPhanCong.Name = "dgvDaPhanCong";
            this.dgvDaPhanCong.Size = new System.Drawing.Size(568, 282);
            this.dgvDaPhanCong.AllowUserToAddRows = false;
            this.dgvDaPhanCong.AllowUserToDeleteRows = false;
            this.dgvDaPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDaPhanCong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDaPhanCong.MultiSelect = false;
            this.dgvDaPhanCong.RowHeadersVisible = false;
            this.dgvDaPhanCong.ReadOnly = true;
            this.dgvDaPhanCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDaPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDaPhanCong.TabIndex = 7;
            // 
            // btnHuyPhanCong
            // 
            this.btnHuyPhanCong.Location = new System.Drawing.Point(938, 632);
            this.btnHuyPhanCong.Name = "btnHuyPhanCong";
            this.btnHuyPhanCong.Size = new System.Drawing.Size(200, 32);
            this.btnHuyPhanCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyPhanCong.TabIndex = 8;
            this.btnHuyPhanCong.Text = "Hủy phân công";
            this.btnHuyPhanCong.Click += new System.EventHandler(this.btnHuyPhanCong_Click);
            // 
            // lblGoiY
            // 
            this.lblGoiY.Location = new System.Drawing.Point(230, 638);
            this.lblGoiY.Name = "lblGoiY";
            this.lblGoiY.Size = new System.Drawing.Size(690, 22);
            this.lblGoiY.ForeColor = System.Drawing.Color.DimGray;
            this.lblGoiY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGoiY.Text = "";
            // 
            // FrmPhanCong
            // 
            this.ClientSize = new System.Drawing.Size(1150, 680);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblCan);
            this.Controls.Add(this.dgvCanPhanCong);
            this.Controls.Add(this.lblRanh);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.btnPhanCong);
            this.Controls.Add(this.lblDaPC);
            this.Controls.Add(this.dgvDaPhanCong);
            this.Controls.Add(this.btnHuyPhanCong);
            this.Controls.Add(this.lblGoiY);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "FrmPhanCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân công nhân viên hướng dẫn";
            this.MinimumSize = new System.Drawing.Size(1166, 719);
            this.Load += new System.EventHandler(this.FrmPhanCong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanPhanCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDaPhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCan;
        private System.Windows.Forms.DataGridView dgvCanPhanCong;
        private System.Windows.Forms.Label lblRanh;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Label lblDaPC;
        private System.Windows.Forms.DataGridView dgvDaPhanCong;
        private System.Windows.Forms.Button btnHuyPhanCong;
        private System.Windows.Forms.Label lblGoiY;
    }
}
