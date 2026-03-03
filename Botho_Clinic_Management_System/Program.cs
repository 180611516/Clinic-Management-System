using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Botho_Clinic_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Handle application exit
            Application.ApplicationExit += (sender, e) => {
                Process.GetCurrentProcess().Kill();
            };

            Application.Run(new frmLogin());
        }
    }
}