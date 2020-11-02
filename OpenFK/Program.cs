using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OpenFK
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Contains("/config"))
            {
                Application.Run(new ConfigForm());
            }
            else if (File.Exists(Directory.GetCurrentDirectory() + @"\Flash.ocx"))
            {
                Application.Run(new Form1());
            }else MessageBox.Show("Flash.ocx is not found!", "OpenFK", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
