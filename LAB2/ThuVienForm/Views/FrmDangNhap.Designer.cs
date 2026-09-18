namespace ThuVienForm.Views
{
    partial class FrmDangNhap
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.lblMatKhau = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(16, 68, 115);
            this.lblTitle.Location = new System.Drawing.Point(210, 45);
            this.lblTitle.Text = "ĐĂNG NHẬP";
            
            this.lblTenDangNhap.Location = new System.Drawing.Point(70, 112);
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            this.lblTenDangNhap.AutoSize = true;
            this.txtTenDangNhap.Location = new System.Drawing.Point(205, 109);
            this.txtTenDangNhap.Size = new System.Drawing.Size(250, 25);
            
            this.lblMatKhau.Location = new System.Drawing.Point(70, 155);
            this.lblMatKhau.Text = "Mật khẩu";
            this.lblMatKhau.AutoSize = true;
            this.txtMatKhau.Location = new System.Drawing.Point(205, 152);
            this.txtMatKhau.Size = new System.Drawing.Size(250, 25);
            this.txtMatKhau.UseSystemPasswordChar = true;
            
            this.btnDangNhap.Location = new System.Drawing.Point(205, 200);
            this.btnDangNhap.Size = new System.Drawing.Size(120, 36);
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            
            this.ClientSize = new System.Drawing.Size(550, 320);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblTenDangNhap);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.btnDangNhap);
            this.Name = "FrmDangNhap";
            this.Text = "Thư viện trực tuyến";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.Label lblMatKhau;
    }
}
