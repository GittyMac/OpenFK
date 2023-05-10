using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
                if(CalculateMD5(Directory.GetCurrentDirectory() + @"\Flash.ocx") == "0c8fbd12f40dcd5a1975b671f9989900" ||
                   CalculateMD5(Directory.GetCurrentDirectory() + @"\Flash.ocx") == "28642aa6626e42701677a1f3822306b0")
                {
                    if (MessageBox.Show("The current Flash.ocx is a buggy version! It causes several problems in the game. Do you want to fetch a compatible OCX?", "OpenFK", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        File.WriteAllText(Directory.GetCurrentDirectory() + @"\FetchOCX.bat", Properties.Resources.FetchOCX);
                        ProcessStartInfo fetchocx = new ProcessStartInfo(Directory.GetCurrentDirectory() + @"\FetchOCX.bat");
                        fetchocx.UseShellExecute = false;
                        var ocxprocess = Process.Start(fetchocx);
                        ocxprocess.WaitForExit();
                        File.Delete(Directory.GetCurrentDirectory() + @"\FetchOCX.bat");
                        Application.Restart();
                    }
                    else
                    {
                        try
                        {
                            Application.Run(new Form1(args));
                        }
                        catch
                        {
                            MessageBox.Show("There was an error starting the game! This could happen because of a 64 bit OCX running on a 32 bit OpenFK.", "OpenFK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    try
                    {
                        Application.Run(new Form1(args));
                    }
                    catch
                    {
                        MessageBox.Show("There was an error starting the game! This could happen because of a 64 bit OCX running on a 32 bit OpenFK.", "OpenFK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        static string CalculateMD5(string filename) //Generates the MD5 hash.
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename)) 
                {
                    var hash = md5.ComputeHash(stream); //Computes the MD5 hash of the swf.
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant(); //Converts the hash to a readable string to compare.
                }
            }
        }
    }
}
