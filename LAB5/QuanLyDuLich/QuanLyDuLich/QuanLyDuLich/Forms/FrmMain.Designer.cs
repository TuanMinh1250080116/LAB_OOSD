namespace QuanLyDuLich.Forms
{
    partial class FrmMain
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
            this.lblMoTa = new System.Windows.Forms.Label();
            this.flpChucNang = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTour = new System.Windows.Forms.Button();
            this.btnPhieuDoan = new System.Windows.Forms.Button();
            this.btnBanVe = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.btnLuong = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.stsBar = new System.Windows.Forms.StatusStrip();
            this.lblKetNoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.flpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(696, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "CÔNG TY DU LỊCH VĂN HÓA VIỆT TP.HCM";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(12, 62);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(696, 22);
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMoTa.ForeColor = System.Drawing.Color.DimGray;
            this.lblMoTa.Text = "Quản lý tour, đăng ký du lịch, phân công hướng dẫn viên";
            // 
            // flpChucNang
            // 
            this.flpChucNang.Controls.Add(this.btnTour);
            this.flpChucNang.Controls.Add(this.btnPhieuDoan);
            this.flpChucNang.Controls.Add(this.btnBanVe);
            this.flpChucNang.Controls.Add(this.btnPhanCong);
            this.flpChucNang.Controls.Add(this.btnLuong);
            this.flpChucNang.Controls.Add(this.btnThoat);
            this.flpChucNang.Location = new System.Drawing.Point(100, 105);
            this.flpChucNang.Name = "flpChucNang";
            this.flpChucNang.Size = new System.Drawing.Size(520, 320);
            // 
            // btnTour
            // 
            this.btnTour.Location = new System.Drawing.Point(0, 0);
            this.btnTour.Name = "btnTour";
            this.btnTour.Size = new System.Drawing.Size(240, 56);
            this.btnTour.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnTour.TabIndex = 3;
            this.btnTour.Text = "Quản lý tour";
            this.btnTour.Click += new System.EventHandler(this.btnTour_Click);
            // 
            // btnPhieuDoan
            // 
            this.btnPhieuDoan.Location = new System.Drawing.Point(0, 0);
            this.btnPhieuDoan.Name = "btnPhieuDoan";
            this.btnPhieuDoan.Size = new System.Drawing.Size(240, 56);
            this.btnPhieuDoan.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnPhieuDoan.TabIndex = 4;
            this.btnPhieuDoan.Text = "Đăng ký theo đoàn";
            this.btnPhieuDoan.Click += new System.EventHandler(this.btnPhieuDoan_Click);
            // 
            // btnBanVe
            // 
            this.btnBanVe.Location = new System.Drawing.Point(0, 0);
            this.btnBanVe.Name = "btnBanVe";
            this.btnBanVe.Size = new System.Drawing.Size(240, 56);
            this.btnBanVe.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnBanVe.TabIndex = 5;
            this.btnBanVe.Text = "Chuyến đi && bán vé khách lẻ";
            this.btnBanVe.Click += new System.EventHandler(this.btnBanVe_Click);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.Location = new System.Drawing.Point(0, 0);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(240, 56);
            this.btnPhanCong.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnPhanCong.TabIndex = 6;
            this.btnPhanCong.Text = "Phân công hướng dẫn viên";
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // btnLuong
            // 
            this.btnLuong.Location = new System.Drawing.Point(0, 0);
            this.btnLuong.Name = "btnLuong";
            this.btnLuong.Size = new System.Drawing.Size(240, 56);
            this.btnLuong.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnLuong.TabIndex = 7;
            this.btnLuong.Text = "Lương && khảo sát";
            this.btnLuong.Click += new System.EventHandler(this.btnLuong_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(0, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(240, 56);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // stsBar
            // 
            this.stsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblKetNoi });
            this.stsBar.Location = new System.Drawing.Point(0, 448);
            this.stsBar.Name = "stsBar";
            this.stsBar.Size = new System.Drawing.Size(720, 22);
            // 
            // lblKetNoi
            // 
            this.lblKetNoi.Name = "lblKetNoi";
            this.lblKetNoi.Text = "Đang kiểm tra kết nối Oracle...";
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(720, 470);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.flpChucNang);
            this.Controls.Add(this.stsBar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Văn Hóa Việt Travel – Quản lý công ty du lịch";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.flpChucNang.ResumeLayout(false);
            this.flpChucNang.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.FlowLayoutPanel flpChucNang;
        private System.Windows.Forms.Button btnTour;
        private System.Windows.Forms.Button btnPhieuDoan;
        private System.Windows.Forms.Button btnBanVe;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnLuong;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.StatusStrip stsBar;
        private System.Windows.Forms.ToolStripStatusLabel lblKetNoi;
    }
}
