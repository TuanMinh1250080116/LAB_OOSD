using System;
using System.Windows.Forms;
using QuanLyDuLich.Data;

namespace QuanLyDuLich.Forms
{
    /// <summary>Màn hình chính: kiểm tra kết nối Oracle và mở các chức năng.</summary>
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            bool ok = false;
            try
            {
                object soTour = Db.Scalar("SELECT COUNT(*) FROM Tour");
                object user = Db.Scalar("SELECT USER FROM dual");
                lblKetNoi.Text = "Đã kết nối Oracle – user " + user + " – " + soTour + " tour";
                ok = true;
            }
            catch (Exception ex)
            {
                lblKetNoi.Text = "Chưa kết nối được Oracle";
                GridHelper.LoiHeThong(this, ex);
            }
            foreach (Control c in flpChucNang.Controls) c.Enabled = ok || c == btnThoat;
        }

        private void MoForm(Form f)
        {
            using (f) f.ShowDialog(this);
        }

        private void btnTour_Click(object sender, EventArgs e)
        {
            MoForm(new FrmTour());
        }

        private void btnPhieuDoan_Click(object sender, EventArgs e)
        {
            MoForm(new FrmPhieuDoan());
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            MoForm(new FrmBanVe());
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            MoForm(new FrmPhanCong());
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            MoForm(new FrmLuongKhaoSat());
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
