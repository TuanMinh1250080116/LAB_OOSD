namespace QuanLyDuLich.Forms
{
    partial class FrmLuongKhaoSat
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabLuong = new System.Windows.Forms.TabPage();
            this.lblThang = new System.Windows.Forms.Label();
            this.numThang = new System.Windows.Forms.NumericUpDown();
            this.lblNam = new System.Windows.Forms.Label();
            this.numNam = new System.Windows.Forms.NumericUpDown();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.lblCongThuc = new System.Windows.Forms.Label();
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.lblTongLuong = new System.Windows.Forms.Label();
            this.tabKhaoSat = new System.Windows.Forms.TabPage();
            this.dgvKhaoSat = new System.Windows.Forms.DataGridView();
            this.grpGhiNhan = new System.Windows.Forms.GroupBox();
            this.lblMuc = new System.Windows.Forms.Label();
            this.numMuc = new System.Windows.Forms.NumericUpDown();
            this.lblGopY = new System.Windows.Forms.Label();
            this.txtGopY = new System.Windows.Forms.TextBox();
            this.btnGhiNhan = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabLuong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.tabKhaoSat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhaoSat)).BeginInit();
            this.grpGhiNhan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMuc)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabLuong);
            this.tabMain.Controls.Add(this.tabKhaoSat);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(1076, 596);
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // tabLuong
            // 
            this.tabLuong.Controls.Add(this.lblThang);
            this.tabLuong.Controls.Add(this.numThang);
            this.tabLuong.Controls.Add(this.lblNam);
            this.tabLuong.Controls.Add(this.numNam);
            this.tabLuong.Controls.Add(this.btnTinhLuong);
            this.tabLuong.Controls.Add(this.lblCongThuc);
            this.tabLuong.Controls.Add(this.dgvLuong);
            this.tabLuong.Controls.Add(this.lblTongLuong);
            this.tabLuong.Name = "tabLuong";
            this.tabLuong.Text = "Bảng lương nhân viên";
            this.tabLuong.UseVisualStyleBackColor = true;
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Location = new System.Drawing.Point(15, 20);
            this.lblThang.Name = "lblThang";
            this.lblThang.Text = "Tháng";
            // 
            // numThang
            // 
            this.numThang.Location = new System.Drawing.Point(75, 17);
            this.numThang.Name = "numThang";
            this.numThang.Size = new System.Drawing.Size(60, 25);
            this.numThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            this.numThang.Value = new decimal(new int[] { 9, 0, 0, 0 });
            this.numThang.TabIndex = 3;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(150, 20);
            this.lblNam.Name = "lblNam";
            this.lblNam.Text = "Năm";
            // 
            // numNam
            // 
            this.numNam.Location = new System.Drawing.Point(200, 17);
            this.numNam.Name = "numNam";
            this.numNam.Size = new System.Drawing.Size(80, 25);
            this.numNam.Minimum = new decimal(new int[] { 2020, 0, 0, 0 });
            this.numNam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            this.numNam.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            this.numNam.TabIndex = 5;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Location = new System.Drawing.Point(300, 13);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Size = new System.Drawing.Size(140, 32);
            this.btnTinhLuong.TabIndex = 6;
            this.btnTinhLuong.Text = "Tính lương";
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // lblCongThuc
            // 
            this.lblCongThuc.AutoSize = true;
            this.lblCongThuc.Location = new System.Drawing.Point(460, 20);
            this.lblCongThuc.Name = "lblCongThuc";
            this.lblCongThuc.ForeColor = System.Drawing.Color.DimGray;
            this.lblCongThuc.Text = "Lương = lương căn bản + lương các tour kết thúc trong tháng";
            // 
            // dgvLuong
            // 
            this.dgvLuong.Location = new System.Drawing.Point(15, 55);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.Size = new System.Drawing.Size(1040, 460);
            this.dgvLuong.AllowUserToAddRows = false;
            this.dgvLuong.AllowUserToDeleteRows = false;
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLuong.MultiSelect = false;
            this.dgvLuong.RowHeadersVisible = false;
            this.dgvLuong.ReadOnly = true;
            this.dgvLuong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLuong.TabIndex = 8;
            // 
            // lblTongLuong
            // 
            this.lblTongLuong.AutoSize = true;
            this.lblTongLuong.Location = new System.Drawing.Point(15, 525);
            this.lblTongLuong.Name = "lblTongLuong";
            this.lblTongLuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(78)))), ((int)(((byte)(121)))));
            this.lblTongLuong.Text = "Tổng quỹ lương: 0 đ";
            // 
            // tabKhaoSat
            // 
            this.tabKhaoSat.Controls.Add(this.dgvKhaoSat);
            this.tabKhaoSat.Controls.Add(this.grpGhiNhan);
            this.tabKhaoSat.Name = "tabKhaoSat";
            this.tabKhaoSat.Text = "Phiếu khảo sát sau tour";
            this.tabKhaoSat.UseVisualStyleBackColor = true;
            // 
            // dgvKhaoSat
            // 
            this.dgvKhaoSat.Location = new System.Drawing.Point(15, 15);
            this.dgvKhaoSat.Name = "dgvKhaoSat";
            this.dgvKhaoSat.Size = new System.Drawing.Size(1040, 420);
            this.dgvKhaoSat.AllowUserToAddRows = false;
            this.dgvKhaoSat.AllowUserToDeleteRows = false;
            this.dgvKhaoSat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhaoSat.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKhaoSat.MultiSelect = false;
            this.dgvKhaoSat.RowHeadersVisible = false;
            this.dgvKhaoSat.ReadOnly = true;
            this.dgvKhaoSat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhaoSat.TabIndex = 11;
            // 
            // grpGhiNhan
            // 
            this.grpGhiNhan.Controls.Add(this.lblMuc);
            this.grpGhiNhan.Controls.Add(this.numMuc);
            this.grpGhiNhan.Controls.Add(this.lblGopY);
            this.grpGhiNhan.Controls.Add(this.txtGopY);
            this.grpGhiNhan.Controls.Add(this.btnGhiNhan);
            this.grpGhiNhan.Location = new System.Drawing.Point(15, 445);
            this.grpGhiNhan.Name = "grpGhiNhan";
            this.grpGhiNhan.Size = new System.Drawing.Size(1040, 105);
            this.grpGhiNhan.Text = "Ghi nhận phản hồi của khách cho phiếu đang chọn";
            // 
            // lblMuc
            // 
            this.lblMuc.AutoSize = true;
            this.lblMuc.Location = new System.Drawing.Point(15, 32);
            this.lblMuc.Name = "lblMuc";
            this.lblMuc.Text = "Mức hài lòng (1–5)";
            // 
            // numMuc
            // 
            this.numMuc.Location = new System.Drawing.Point(160, 29);
            this.numMuc.Name = "numMuc";
            this.numMuc.Size = new System.Drawing.Size(60, 25);
            this.numMuc.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMuc.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            this.numMuc.Value = new decimal(new int[] { 5, 0, 0, 0 });
            this.numMuc.TabIndex = 14;
            // 
            // lblGopY
            // 
            this.lblGopY.AutoSize = true;
            this.lblGopY.Location = new System.Drawing.Point(240, 32);
            this.lblGopY.Name = "lblGopY";
            this.lblGopY.Text = "Góp ý";
            // 
            // txtGopY
            // 
            this.txtGopY.Location = new System.Drawing.Point(300, 29);
            this.txtGopY.Name = "txtGopY";
            this.txtGopY.Size = new System.Drawing.Size(560, 25);
            this.txtGopY.MaxLength = 1000;
            this.txtGopY.TabIndex = 16;
            // 
            // btnGhiNhan
            // 
            this.btnGhiNhan.Location = new System.Drawing.Point(875, 25);
            this.btnGhiNhan.Name = "btnGhiNhan";
            this.btnGhiNhan.Size = new System.Drawing.Size(150, 32);
            this.btnGhiNhan.TabIndex = 17;
            this.btnGhiNhan.Text = "Ghi nhận";
            this.btnGhiNhan.Click += new System.EventHandler(this.btnGhiNhan_Click);
            // 
            // FrmLuongKhaoSat
            // 
            this.ClientSize = new System.Drawing.Size(1100, 620);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLuongKhaoSat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bảng lương và phiếu khảo sát";
            this.Load += new System.EventHandler(this.FrmLuongKhaoSat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhaoSat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMuc)).EndInit();
            this.grpGhiNhan.ResumeLayout(false);
            this.grpGhiNhan.PerformLayout();
            this.tabKhaoSat.ResumeLayout(false);
            this.tabKhaoSat.PerformLayout();
            this.tabLuong.ResumeLayout(false);
            this.tabLuong.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabLuong;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.NumericUpDown numThang;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.NumericUpDown numNam;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.Label lblCongThuc;
        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.Label lblTongLuong;
        private System.Windows.Forms.TabPage tabKhaoSat;
        private System.Windows.Forms.DataGridView dgvKhaoSat;
        private System.Windows.Forms.GroupBox grpGhiNhan;
        private System.Windows.Forms.Label lblMuc;
        private System.Windows.Forms.NumericUpDown numMuc;
        private System.Windows.Forms.Label lblGopY;
        private System.Windows.Forms.TextBox txtGopY;
        private System.Windows.Forms.Button btnGhiNhan;
    }
}
