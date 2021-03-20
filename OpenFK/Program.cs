using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (File.Exists(Directory.GetCurrentDirectory() + @"\update.bat"))
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\update.bat");
            }
            if (args.Contains("/config"))
            {
                Application.Run(new ConfigForm());
            }
            else if (File.Exists(Directory.GetCurrentDirectory() + @"\Flash.ocx"))
            {
                try
                {
                    Application.Run(new Form1());
                }
                catch
                {
                    MessageBox.Show("There was an error starting the game! This could happen because of a 64 bit OCX running on a 32 bit OpenFK.", "OpenFK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if (MessageBox.Show("Flash.ocx is not found! Do you want to fetch a compatible OCX?", "OpenFK", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\FetchOCX.bat", Properties.Resources.FetchOCX);
                ProcessStartInfo fetchocx = new ProcessStartInfo(Directory.GetCurrentDirectory() + @"\FetchOCX.bat");
                fetchocx.UseShellExecute = false;
                var ocxprocess = Process.Start(fetchocx);
                ocxprocess.WaitForExit();
                File.Delete(Directory.GetCurrentDirectory() + @"\FetchOCX.bat");
                Application.Restart();
            }
        }
    }
}
