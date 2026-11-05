using ioT_JIG_PC;
using System;
using System.Windows.Forms;

namespace IoT_JIG_PC
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}