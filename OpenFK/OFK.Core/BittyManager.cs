using Microsoft.Win32;
using OpenFK.OFK.Net;
using OpenFK.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

namespace OpenFK.OFK.Core
{
    static class BittyManager
    {
        // ===================================
        // Bitty Manager
        // Handles the Bitty transmission via both MegaByte and customF.
        // ===================================

        private static FileSystemWatcher BittyWatcher;
        private static string BittyID;

        //For MegaByte's config.
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hwnd, StringBuilder lpClassName, int nMaxCount);

        //FSGUI Focusing
        private const int SW_SHOWNORMAL = 1;
        private const int SW_MINIMIZE = 6;
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public static void InitBitty()
        {
            //customF Initialization
            if (Settings.Default.customF == true)
            {
                BittyWatcher = new FileSystemWatcher();
                BittyWatcher.Path = Directory.GetCurrentDirectory();
                BittyWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                BittyWatcher.Filter = "customF.txt";
                BittyWatcher.Changed += OnChanged;
                BittyWatcher.SynchronizingObject = Globals.AS2Container;
                BittyWatcher.EnableRaisingEvents = true;

                if (File.Exists(Directory.GetCurrentDirectory() + @"\FunkeySelectorGUI.exe"))
                {
                    Process.Start(Directory.GetCurrentDirectory() + @"\FunkeySelectorGUI.exe", "-MBRun");
                    Thread.Sleep(500);
                    ShowGUI();
                }
            }

            if (Settings.Default.USBSupport == true)
            {
                //WinForms uses a randomized class name, so we fill in Config.ini with OpenFK's info.
                var className = new StringBuilder(256);
                GetClassName(Globals.GameForm.Handle, className, className.Capacity);

                string configFile = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\Config.ini";
                string[] configLines = File.ReadAllLines(configFile);
                configLines[11] = @"ClassName=""" + className.ToString() + @"""";
                configLines[12] = @"WindowName=""OpenFK""";
                File.WriteAllLines(configFile, configLines);

                var key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers", true);
                if (key == null)
                    throw new InvalidOperationException(@"Cannot open registry key HKCU\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers.");
                using (key)
                    key.SetValue(Directory.GetParent(Directory.GetCurrentDirectory()) + @"\MegaByte\" + "MegaByte.exe", "VISTASP2");
                Process MBRun = new Process();
                ProcessStartInfo MBData = new ProcessStartInfo();
                MBData.FileName = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\MegaByte\" + "MegaByte.exe";
                if (Globals.IsDebug) 
                    MBData.Arguments = "-MBRun -MBDebug";
                else 
                    MBData.Arguments = "-MBRun";
                
                MBData.UseShellExecute = false;
                MBData.WindowStyle = ProcessWindowStyle.Minimized;
                MBRun.StartInfo = MBData;
                MBRun.Start();
            }
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            try //Runs a loop to keep reading until the file is not being saved.
            {
                SetBitty(File.ReadAllText(Directory.GetCurrentDirectory() + @"\customF.txt").Remove(0, 14), false);
            }
            catch
            {
                OnChanged(sender, e);
            }
        }

        public static void SetBitty(string localBittyID, bool isMB)
        {
            if (BittyID != localBittyID)
            {
                if (isMB)
                {
                    string mbBitty = Regex.Replace(localBittyID, @"[^\w\d]", "");
                    Globals.GameForm.SetVar(@$"<bitybyte id=""{mbBitty}"" />");
                }
                else
                {
                    Globals.GameForm.SetVar(@$"<bitybyte id=""{localBittyID}00000000"" />");
                }
                BittyID = localBittyID;

                RichPresenceManager.CurrentBitty = localBittyID.ToLower();
                if (Settings.Default.RPC == true)
                {
                    try
                    {
                        XmlNodeList nodes = RichPresenceManager.BittyData.SelectNodes("//funkey[@id='" + localBittyID + "']");
                        foreach (XmlNode xn in nodes)
                        {
                            RichPresenceManager.CurrentBittyName = xn.Attributes["name"].Value;
                        }
                        RichPresenceManager.SetRP(RichPresenceManager.CurrentWorld, RichPresenceManager.CurrentActivity, RichPresenceManager.CurrentBitty, RichPresenceManager.CurrentBittyName);
                    }
                    catch
                    {

                    }
                }
            }
        }

        public static void ShowGUI() 
        {
            //TODO - There's an issue with opening anything other than the primary form.
            try
            {
                IntPtr hwnd = FindWindowByCaption(IntPtr.Zero, "FunkeySelectorGUI");
                if (IsIconic(hwnd)) 
                {
                    ShowWindow(hwnd, SW_SHOWNORMAL);
                    int gameFormCenterX = Globals.GameForm.Location.X + 50;
                    int gameFormCenterY = Globals.GameForm.Location.Y + 50;
                    SetWindowPos(hwnd, IntPtr.Zero, gameFormCenterX, gameFormCenterY, gameFormCenterX, gameFormCenterY, SWP_NOSIZE | SWP_NOZORDER);
                }
                else 
                {
                    ShowWindow(hwnd, SW_MINIMIZE);
                }
            }
            catch {  }
        }
    }
}
