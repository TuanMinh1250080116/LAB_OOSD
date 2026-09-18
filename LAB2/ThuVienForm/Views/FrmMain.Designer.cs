namespace ThuVienForm.Views
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblXinChao = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.btnTinhTrang = new System.Windows.Forms.Button();
            this.btnDuyetYeuCau = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.btnNhatKy = new System.Windows.Forms.Button();
            this.btnDeXuat = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            
            // Tiêu đề
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(16, 68, 115);
            this.lblTieuDe.Location = new System.Drawing.Point(260, 40);
            this.lblTieuDe.Text = "HỆ THỐNG THƯ VIỆN TRỰC TUYẾN";
            
            // Lời chào
            this.lblXinChao.AutoSize = true;
            this.lblXinChao.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblXinChao.ForeColor = System.Drawing.Color.DimGray;
            this.lblXinChao.Location = new System.Drawing.Point(350, 80);
            this.lblXinChao.Text = "Xin chào: [Tên người dùng] ([Vai trò])";
            
            // Định dạng chung cho các nút
            int btnWidth = 260;
            int btnHeight = 45;
            int col1_X = 150;
            int col2_X = 470;
            
            // Hàng 1
            this.btnTimKiem.Location = new System.Drawing.Point(col1_X, 130);
            this.btnTimKiem.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnTimKiem.Text = "Tìm kiếm tài liệu";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            
            this.btnDanhMuc.Location = new System.Drawing.Point(col2_X, 130);
            this.btnDanhMuc.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnDanhMuc.Text = "Danh mục tài liệu";
            
            // Hàng 2
            this.btnLapPhieu.Location = new System.Drawing.Point(col1_X, 190);
            this.btnLapPhieu.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            
            this.btnTraSach.Location = new System.Drawing.Point(col2_X, 190);
            this.btnTraSach.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnTraSach.Text = "Tiếp nhận trả sách";
            
            // Hàng 3
            this.btnTinhTrang.Location = new System.Drawing.Point(col1_X, 250);
            this.btnTinhTrang.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnTinhTrang.Text = "Tình trạng mượn";
            
            this.btnDuyetYeuCau.Location = new System.Drawing.Point(col2_X, 250);
            this.btnDuyetYeuCau.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnDuyetYeuCau.Text = "Duyệt yêu cầu đặt mua";
            
            // Hàng 4
            this.btnBaoCao.Location = new System.Drawing.Point(col1_X, 310);
            this.btnBaoCao.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnBaoCao.Text = "Báo cáo – thống kê";
            
            this.btnNhatKy.Location = new System.Drawing.Point(col2_X, 310);
            this.btnNhatKy.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnNhatKy.Text = "Nhật ký nhắc hạn trả";
            
            // Hàng 5
            this.btnDeXuat.Location = new System.Drawing.Point(col1_X, 370);
            this.btnDeXuat.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnDeXuat.Text = "Đề xuất đặt mua";
            
            this.btnDangXuat.Location = new System.Drawing.Point(col2_X, 370);
            this.btnDangXuat.Size = new System.Drawing.Size(btnWidth, btnHeight);
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            
            // Footer
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 35;
            this.lblFooter.AutoSize = true;
            this.lblFooter.Location = new System.Drawing.Point(10, 10);
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Text = "Độc giả chỉ thấy: Tìm kiếm tài liệu, Đề xuất đặt mua, Theo dõi yêu cầu, Đăng xuất.";
            this.pnlFooter.Controls.Add(this.lblFooter);
            
            // Form Config
            this.ClientSize = new System.Drawing.Size(880, 500);
            this.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblXinChao);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.btnLapPhieu);
            this.Controls.Add(this.btnTraSach);
            this.Controls.Add(this.btnTinhTrang);
            this.Controls.Add(this.btnDuyetYeuCau);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.btnNhatKy);
            this.Controls.Add(this.btnDeXuat);
            this.Controls.Add(this.btnDangXuat);
            this.Name = "FrmMain";
            this.Text = "Thư viện trực tuyến";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblXinChao;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Button btnTinhTrang;
        private System.Windows.Forms.Button btnDuyetYeuCau;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnNhatKy;
        private System.Windows.Forms.Button btnDeXuat;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}
