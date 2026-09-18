using System;
using System.Windows.Forms;
using ThuVienForm.Views;

namespace ThuVienForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmDangNhap());
        }
    }
}
