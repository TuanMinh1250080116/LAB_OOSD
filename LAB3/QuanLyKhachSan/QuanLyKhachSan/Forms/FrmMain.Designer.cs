namespace QuanLyKhachSan.Forms
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
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnTraPhong = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.stsBar = new System.Windows.Forms.StatusStrip();
            this.lblTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
            this.flpChucNang.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(696, 36);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Location = new System.Drawing.Point(12, 66);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(696, 22);
            this.lblMoTa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMoTa.ForeColor = System.Drawing.Color.DimGray;
            this.lblMoTa.Text = "Chọn chức năng cần làm việc";
            // 
            // flpChucNang
            // 
            this.flpChucNang.Controls.Add(this.btnDanhMuc);
            this.flpChucNang.Controls.Add(this.btnPhong);
            this.flpChucNang.Controls.Add(this.btnDatPhong);
            this.flpChucNang.Controls.Add(this.btnDichVu);
            this.flpChucNang.Controls.Add(this.btnTraPhong);
            this.flpChucNang.Controls.Add(this.btnThongKe);
            this.flpChucNang.Controls.Add(this.btnThoat);
            this.flpChucNang.Location = new System.Drawing.Point(100, 100);
            this.flpChucNang.Name = "flpChucNang";
            this.flpChucNang.Size = new System.Drawing.Size(520, 320);
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Location = new System.Drawing.Point(0, 0);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(240, 46);
            this.btnDanhMuc.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDanhMuc.TabIndex = 3;
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnPhong
            // 
            this.btnPhong.Location = new System.Drawing.Point(0, 0);
            this.btnPhong.Name = "btnPhong";
            this.btnPhong.Size = new System.Drawing.Size(240, 46);
            this.btnPhong.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnPhong.TabIndex = 4;
            this.btnPhong.Text = "Phòng - Tiện nghi";
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);
            // 
            // btnDatPhong
            // 
            this.btnDatPhong.Location = new System.Drawing.Point(0, 0);
            this.btnDatPhong.Name = "btnDatPhong";
            this.btnDatPhong.Size = new System.Drawing.Size(240, 46);
            this.btnDatPhong.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDatPhong.TabIndex = 5;
            this.btnDatPhong.Text = "Đặt / Nhận phòng";
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            // 
            // btnDichVu
            // 
            this.btnDichVu.Location = new System.Drawing.Point(0, 0);
            this.btnDichVu.Name = "btnDichVu";
            this.btnDichVu.Size = new System.Drawing.Size(240, 46);
            this.btnDichVu.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnDichVu.TabIndex = 6;
            this.btnDichVu.Text = "Sử dụng dịch vụ";
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            // 
            // btnTraPhong
            // 
            this.btnTraPhong.Location = new System.Drawing.Point(0, 0);
            this.btnTraPhong.Name = "btnTraPhong";
            this.btnTraPhong.Size = new System.Drawing.Size(240, 46);
            this.btnTraPhong.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnTraPhong.TabIndex = 7;
            this.btnTraPhong.Text = "Trả phòng - Thanh toán";
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(0, 0);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(240, 46);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(0, 0);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(240, 46);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.btnThoat.TabIndex = 9;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // stsBar
            // 
            this.stsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblTrangThai });
            this.stsBar.Location = new System.Drawing.Point(0, 448);
            this.stsBar.Name = "stsBar";
            this.stsBar.Size = new System.Drawing.Size(720, 22);
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Text = "Sẵn sàng";
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
            this.Text = "Hệ thống quản lý khách sạn";
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
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnPhong;
        private System.Windows.Forms.Button btnDatPhong;
        private System.Windows.Forms.Button btnDichVu;
        private System.Windows.Forms.Button btnTraPhong;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.StatusStrip stsBar;
        private System.Windows.Forms.ToolStripStatusLabel lblTrangThai;
    }
}
