namespace ThuVienForm.Views
{
    partial class FrmDocTrucTuyen
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.lblTrang = new System.Windows.Forms.Label();
            this.nudTrang = new System.Windows.Forms.NumericUpDown();
            this.lblTongSoTrang = new System.Windows.Forms.Label();
            this.btnSau = new System.Windows.Forms.Button();
            this.lblThuPhong = new System.Windows.Forms.Label();
            this.cboThuPhong = new System.Windows.Forms.ComboBox();
            this.btnTaiXuong = new System.Windows.Forms.Button();
            
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.lblNoiDungGiaLap = new System.Windows.Forms.Label();
            
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrang)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlTop (Thanh công cụ phía trên)
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.pnlTop.Controls.Add(this.btnTruoc);
            this.pnlTop.Controls.Add(this.lblTrang);
            this.pnlTop.Controls.Add(this.nudTrang);
            this.pnlTop.Controls.Add(this.lblTongSoTrang);
            this.pnlTop.Controls.Add(this.btnSau);
            this.pnlTop.Controls.Add(this.lblThuPhong);
            this.pnlTop.Controls.Add(this.cboThuPhong);
            this.pnlTop.Controls.Add(this.btnTaiXuong);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Height = 50;
            
            // Các control trong pnlTop
            this.btnTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruoc.Location = new System.Drawing.Point(20, 10);
            this.btnTruoc.Size = new System.Drawing.Size(90, 28);
            this.btnTruoc.Text = "◄ Trước";
            this.btnTruoc.Click += new System.EventHandler(this.btnTruoc_Click);
            
            this.lblTrang.AutoSize = true;
            this.lblTrang.Location = new System.Drawing.Point(140, 16);
            this.lblTrang.Text = "Trang";
            
            this.nudTrang.Location = new System.Drawing.Point(185, 13);
            this.nudTrang.Size = new System.Drawing.Size(70, 23);
            this.nudTrang.Minimum = 1;
            this.nudTrang.ValueChanged += new System.EventHandler(this.nudTrang_ValueChanged);
            
            this.lblTongSoTrang.AutoSize = true;
            this.lblTongSoTrang.Location = new System.Drawing.Point(265, 16);
            this.lblTongSoTrang.Text = "/ 320";
            
            this.btnSau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSau.Location = new System.Drawing.Point(325, 10);
            this.btnSau.Size = new System.Drawing.Size(90, 28);
            this.btnSau.Text = "Sau ►";
            this.btnSau.Click += new System.EventHandler(this.btnSau_Click);
            
            this.lblThuPhong.AutoSize = true;
            this.lblThuPhong.Location = new System.Drawing.Point(460, 16);
            this.lblThuPhong.Text = "Thu phóng";
            
            this.cboThuPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThuPhong.Items.AddRange(new object[] { "50%", "75%", "100%", "125%", "150%", "200%" });
            this.cboThuPhong.Location = new System.Drawing.Point(540, 13);
            this.cboThuPhong.Size = new System.Drawing.Size(100, 23);
            
            this.btnTaiXuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiXuong.Location = new System.Drawing.Point(680, 10);
            this.btnTaiXuong.Size = new System.Drawing.Size(150, 28);
            this.btnTaiXuong.Text = "Tải xuống";
            this.btnTaiXuong.Click += new System.EventHandler(this.btnTaiXuong_Click);

            // 
            // pnlCenter (Vùng xem tài liệu)
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.White;
            this.pnlCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCenter.Controls.Add(this.lblNoiDungGiaLap);
            this.pnlCenter.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
            this.pnlCenter.Location = new System.Drawing.Point(100, 60);
            this.pnlCenter.Size = new System.Drawing.Size(750, 480);
            
            // Nội dung giả lập
            this.lblNoiDungGiaLap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoiDungGiaLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoiDungGiaLap.ForeColor = System.Drawing.Color.DarkGray;
            this.lblNoiDungGiaLap.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNoiDungGiaLap.Text = "Nội dung trang sách hiển thị tại đây\n(trình xem PDF / EPUB)";

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 30;
            this.lblFooter.AutoSize = true;
            this.lblFooter.ForeColor = System.Drawing.Color.DimGray;
            this.lblFooter.Location = new System.Drawing.Point(10, 7);
            this.lblFooter.Text = "Đọc trực tuyến không yêu cầu mã thẻ. Nút Tải xuống sẽ mở màn hình kiểm tra mã thẻ.";
            this.pnlFooter.Controls.Add(this.lblFooter);

            // 
            // FrmDocTrucTuyen
            // 
            this.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlFooter);
            this.Name = "FrmDocTrucTuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmDocTrucTuyen_Load);
            
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTrang)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Label lblTrang;
        private System.Windows.Forms.NumericUpDown nudTrang;
        private System.Windows.Forms.Label lblTongSoTrang;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.Label lblThuPhong;
        private System.Windows.Forms.ComboBox cboThuPhong;
        private System.Windows.Forms.Button btnTaiXuong;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Label lblNoiDungGiaLap;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}
