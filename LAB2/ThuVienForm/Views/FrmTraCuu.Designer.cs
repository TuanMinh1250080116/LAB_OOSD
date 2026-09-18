namespace ThuVienForm.Views
{
    partial class FrmTraCuu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTuKhoa = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXoaLoc = new System.Windows.Forms.Button();
            this.lblLoai = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.lblChuDe = new System.Windows.Forms.Label();
            this.cboChuDe = new System.Windows.Forms.ComboBox();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lblNam = new System.Windows.Forms.Label();
            this.nudNam = new System.Windows.Forms.NumericUpDown();
            this.lblDinhDang = new System.Windows.Forms.Label();
            this.chkBanIn = new System.Windows.Forms.CheckBox();
            this.chkPDF = new System.Windows.Forms.CheckBox();
            this.chkEPUB = new System.Windows.Forms.CheckBox();
            
            this.gbKetQua = new System.Windows.Forms.GroupBox();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.colBia = new System.Windows.Forms.DataGridViewImageColumn();
            this.colTieuDe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTacGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDinhDang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTruoc = new System.Windows.Forms.Button();
            this.lblTrang = new System.Windows.Forms.Label();
            this.btnSau = new System.Windows.Forms.Button();
            
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.picBia = new System.Windows.Forms.PictureBox();
            this.lblChiTiet = new System.Windows.Forms.Label();
            this.btnDocOnline = new System.Windows.Forms.Button();
            this.btnTaiXuong = new System.Windows.Forms.Button();
            this.btnDangKyMuon = new System.Windows.Forms.Button();
            
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            
            this.gbTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNam)).BeginInit();
            this.gbKetQua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBia)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.chkEPUB);
            this.gbTimKiem.Controls.Add(this.chkPDF);
            this.gbTimKiem.Controls.Add(this.chkBanIn);
            this.gbTimKiem.Controls.Add(this.lblDinhDang);
            this.gbTimKiem.Controls.Add(this.nudNam);
            this.gbTimKiem.Controls.Add(this.lblNam);
            this.gbTimKiem.Controls.Add(this.txtTacGia);
            this.gbTimKiem.Controls.Add(this.lblTacGia);
            this.gbTimKiem.Controls.Add(this.cboChuDe);
            this.gbTimKiem.Controls.Add(this.lblChuDe);
            this.gbTimKiem.Controls.Add(this.cboLoai);
            this.gbTimKiem.Controls.Add(this.lblLoai);
            this.gbTimKiem.Controls.Add(this.btnXoaLoc);
            this.gbTimKiem.Controls.Add(this.btnTimKiem);
            this.gbTimKiem.Controls.Add(this.txtTuKhoa);
            this.gbTimKiem.Controls.Add(this.lblTuKhoa);
            this.gbTimKiem.Location = new System.Drawing.Point(12, 12);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(960, 110);
            this.gbTimKiem.Text = "Tìm kiếm";
            
            this.lblTuKhoa.AutoSize = true;
            this.lblTuKhoa.Location = new System.Drawing.Point(20, 30);
            this.lblTuKhoa.Text = "Từ khóa";
            
            this.txtTuKhoa.Location = new System.Drawing.Point(90, 27);
            this.txtTuKhoa.Size = new System.Drawing.Size(480, 23);
            this.txtTuKhoa.PlaceholderText = "Tên sách, tác giả, ISBN...";
            
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(218, 233, 245);
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(590, 26);
            this.btnTimKiem.Size = new System.Drawing.Size(120, 27);
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            
            this.btnXoaLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaLoc.Location = new System.Drawing.Point(720, 26);
            this.btnXoaLoc.Size = new System.Drawing.Size(120, 27);
            this.btnXoaLoc.Text = "Xóa lọc";
            this.btnXoaLoc.Click += new System.EventHandler(this.btnXoaLoc_Click);
            
            this.lblLoai.AutoSize = true;
            this.lblLoai.Location = new System.Drawing.Point(20, 70);
            this.lblLoai.Text = "Loại";
            
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.Items.AddRange(new object[] { "Tất cả", "Sách giáo trình", "Sách tham khảo" });
            this.cboLoai.Location = new System.Drawing.Point(90, 67);
            this.cboLoai.Size = new System.Drawing.Size(120, 23);
            this.cboLoai.Text = "Tất cả";
            
            this.lblChuDe.AutoSize = true;
            this.lblChuDe.Location = new System.Drawing.Point(230, 70);
            this.lblChuDe.Text = "Chủ đề";
            
            this.cboChuDe.FormattingEnabled = true;
            this.cboChuDe.Items.AddRange(new object[] { "Tất cả", "Công nghệ thông tin", "Kinh tế" });
            this.cboChuDe.Location = new System.Drawing.Point(280, 67);
            this.cboChuDe.Size = new System.Drawing.Size(140, 23);
            this.cboChuDe.Text = "Tất cả";
            
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(440, 70);
            this.lblTacGia.Text = "Tác giả";
            
            this.txtTacGia.Location = new System.Drawing.Point(490, 67);
            this.txtTacGia.Size = new System.Drawing.Size(140, 23);
            
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(650, 70);
            this.lblNam.Text = "Năm XB";
            
            this.nudNam.Location = new System.Drawing.Point(705, 67);
            this.nudNam.Maximum = new decimal(new int[] { 2030, 0, 0, 0 });
            this.nudNam.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            this.nudNam.Size = new System.Drawing.Size(60, 23);
            this.nudNam.Value = new decimal(new int[] { 2020, 0, 0, 0 });
            
            this.lblDinhDang.AutoSize = true;
            this.lblDinhDang.Location = new System.Drawing.Point(780, 70);
            this.lblDinhDang.Text = "Định dạng";
            
            this.chkBanIn.AutoSize = true;
            this.chkBanIn.Checked = true;
            this.chkBanIn.Location = new System.Drawing.Point(850, 69);
            this.chkBanIn.Text = "Bản in";
            
            this.chkPDF.AutoSize = true;
            this.chkPDF.Checked = true;
            this.chkPDF.Location = new System.Drawing.Point(910, 69);
            this.chkPDF.Text = "PDF";
            
            this.chkEPUB.AutoSize = true;
            this.chkEPUB.Checked = true;
            this.chkEPUB.Location = new System.Drawing.Point(960, 69);
            this.chkEPUB.Text = "EPUB";

            // 
            // gbKetQua
            // 
            this.gbKetQua.Controls.Add(this.btnSau);
            this.gbKetQua.Controls.Add(this.lblTrang);
            this.gbKetQua.Controls.Add(this.btnTruoc);
            this.gbKetQua.Controls.Add(this.dgvKetQua);
            this.gbKetQua.Location = new System.Drawing.Point(12, 135);
            this.gbKetQua.Name = "gbKetQua";
            this.gbKetQua.Size = new System.Drawing.Size(730, 400);
            this.gbKetQua.Text = "Tìm thấy 0 kết quả";

            this.btnDocOnline.Click += new System.EventHandler(this.btnDocOnline_Click);

            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.BackgroundColor = System.Drawing.Color.White;
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBia, this.colTieuDe, this.colTacGia, this.colNam, this.colDinhDang, this.colTinhTrang});
            this.dgvKetQua.Location = new System.Drawing.Point(10, 25);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.RowHeadersVisible = false;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(710, 320);
            this.dgvKetQua.SelectionChanged += new System.EventHandler(this.dgvKetQua_SelectionChanged);
            
            this.colBia.HeaderText = "Bìa";
            this.colBia.Width = 40;
            this.colTieuDe.DataPropertyName = "TuaDe";
            this.colTieuDe.HeaderText = "Tiêu đề";
            this.colTieuDe.Width = 240;
            this.colTacGia.DataPropertyName = "TacGia";
            this.colTacGia.HeaderText = "Tác giả";
            this.colTacGia.Width = 140;
            this.colNam.DataPropertyName = "NamXuatBan";
            this.colNam.HeaderText = "Năm";
            this.colNam.Width = 60;
            this.colDinhDang.DataPropertyName = "LoaiTaiLieu";
            this.colDinhDang.HeaderText = "Định dạng";
            this.colDinhDang.Width = 90;
            this.colTinhTrang.DataPropertyName = "TrangThai";
            this.colTinhTrang.HeaderText = "Tình trạng";
            this.colTinhTrang.Width = 120;
            
            this.btnTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTruoc.Location = new System.Drawing.Point(10, 360);
            this.btnTruoc.Size = new System.Drawing.Size(90, 27);
            this.btnTruoc.Text = "« Trước";
            
            this.lblTrang.AutoSize = true;
            this.lblTrang.Location = new System.Drawing.Point(135, 365);
            this.lblTrang.Text = "Trang 1 / 1";
            
            this.btnSau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSau.Location = new System.Drawing.Point(225, 360);
            this.btnSau.Size = new System.Drawing.Size(90, 27);
            this.btnSau.Text = "Sau »";

            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.btnDangKyMuon);
            this.gbChiTiet.Controls.Add(this.btnTaiXuong);
            this.gbChiTiet.Controls.Add(this.btnDocOnline);
            this.gbChiTiet.Controls.Add(this.lblChiTiet);
            this.gbChiTiet.Controls.Add(this.picBia);
            this.gbChiTiet.Location = new System.Drawing.Point(750, 135);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(260, 400);
            this.gbChiTiet.Text = "Chi tiết tài liệu";
            
            this.picBia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBia.Location = new System.Drawing.Point(30, 30);
            this.picBia.Size = new System.Drawing.Size(200, 100);
            
            this.lblChiTiet.Location = new System.Drawing.Point(20, 145);
            this.lblChiTiet.Size = new System.Drawing.Size(220, 160);
            this.lblChiTiet.Text = "Vui lòng chọn tài liệu...";
            
            this.btnDocOnline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDocOnline.Location = new System.Drawing.Point(20, 305);
            this.btnDocOnline.Size = new System.Drawing.Size(220, 27);
            this.btnDocOnline.Text = "Đọc trực tuyến";
            
            this.btnTaiXuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaiXuong.Location = new System.Drawing.Point(20, 335);
            this.btnTaiXuong.Size = new System.Drawing.Size(220, 27);
            this.btnTaiXuong.Text = "Tải xuống";
            
            this.btnDangKyMuon.BackColor = System.Drawing.Color.FromArgb(218, 233, 245);
            this.btnDangKyMuon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKyMuon.Location = new System.Drawing.Point(20, 365);
            this.btnDangKyMuon.Size = new System.Drawing.Size(220, 27);
            this.btnDangKyMuon.Text = "Đăng ký mượn";

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Height = 30;
            this.lblFooter.AutoSize = true;
            this.lblFooter.ForeColor = System.Drawing.Color.DimGray;
            this.lblFooter.Location = new System.Drawing.Point(10, 7);
            this.lblFooter.Text = "Không cần đăng nhập để tìm kiếm và đọc trực tuyến (FR01-FR03).";
            this.pnlFooter.Controls.Add(this.lblFooter);

            // 
            // FrmTraCuu
            // 
            this.BackColor = System.Drawing.Color.FromArgb(244, 245, 247);
            this.ClientSize = new System.Drawing.Size(1024, 580);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.gbChiTiet);
            this.Controls.Add(this.gbKetQua);
            this.Controls.Add(this.gbTimKiem);
            this.Name = "FrmTraCuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm tài liệu";
            this.Load += new System.EventHandler(this.FrmTraCuu_Load);
            
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNam)).EndInit();
            this.gbKetQua.ResumeLayout(false);
            this.gbKetQua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.gbChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBia)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.Label lblTuKhoa;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXoaLoc;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label lblChuDe;
        private System.Windows.Forms.ComboBox cboChuDe;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown nudNam;
        private System.Windows.Forms.Label lblDinhDang;
        private System.Windows.Forms.CheckBox chkBanIn;
        private System.Windows.Forms.CheckBox chkPDF;
        private System.Windows.Forms.CheckBox chkEPUB;
        private System.Windows.Forms.GroupBox gbKetQua;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewImageColumn colBia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTieuDe;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTacGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDinhDang;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTrang;
        private System.Windows.Forms.Button btnTruoc;
        private System.Windows.Forms.Label lblTrang;
        private System.Windows.Forms.Button btnSau;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.PictureBox picBia;
        private System.Windows.Forms.Label lblChiTiet;
        private System.Windows.Forms.Button btnDocOnline;
        private System.Windows.Forms.Button btnTaiXuong;
        private System.Windows.Forms.Button btnDangKyMuon;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
    }
}
