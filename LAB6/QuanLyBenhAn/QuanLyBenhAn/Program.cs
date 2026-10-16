using System;
using System.Windows.Forms;

namespace QuanLyBenhAn
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length>=2 && args[0]=="/chupanh")
            {
                MainForm.CaptureScreens(args[1],true);
                return;
            }
            if(args.Length>=2 && args[0]=="/chupanhdb")
            {
                MainForm.CaptureScreens(args[1],false);
                return;
            }
            if(args.Length>=2 && args[0]=="/kiemthu")
            {
                KiemThu.Run(args[1]);
                return;
            }
            Application.Run(new MainForm());
        }
    }
}
