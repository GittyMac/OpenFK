using AxShockwaveFlashObjects;
using OpenFK.OFK.Common;
using OpenFK.OFK.Core;
using OpenFK.OFK.Net;
using OpenFK.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace OpenFK
{

    // ===================================
    // Game Form
    // OpenFK's Primary Container
    // ===================================

    public partial class GameForm : Form
    {
        //Rich Presence Data


        public GameForm(string[] args)
        {
            InitializeComponent();
            if (args.Contains("/debug"))
            {
                Globals.IsDebug = true;
                DebugForm debug = new DebugForm();
                debug.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\Main.swf"))
            {
                MessageBox.Show("Could not find Main.swf!", "OpenFK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (Settings.Default.RPC == true)
            {
                RichPresenceManager.InitRPC();
            }

            AS2Container.Quality = Settings.Default.Quality;
            AS2Container.Quality2 = "High";
            AS2Container.ScaleMode = Settings.Default.ScaleMode;
            AS2Container.Movie = Directory.GetCurrentDirectory() + @"\Main.swf";
            AS2Container.Play();
            LogManager.LogGeneral("[AS2Container] Main.swf is Loaded");
            AS2Container.FSCommand += new _IShockwaveFlashEvents_FSCommandEventHandler(flashPlayer_FSCommand); //This sets up the FSCommand handler, which CCommunicator likes to use a lot.

            try
            {
                AS3Container.Quality = Settings.Default.Quality;
                AS3Container.Quality2 = "High";
                AS3Container.ScaleMode = Settings.Default.ScaleMode;
                AS3Container.Movie = Directory.GetCurrentDirectory() + @"\MainAS3.swf";
                LogManager.LogGeneral("[AS3Container] MainAS3.swf is Loaded");
                AS3Container.FSCommand += new _IShockwaveFlashEvents_FSCommandEventHandler(flashPlayerAS3_FSCommand);
                AS3Container.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(flashPlayerAS3_FlashCall);
            }
            catch
            {
                LogManager.LogGeneral("[AS3Container] AS3 Failed to Load! Potentially an older version.");
            }

            //Globals
            Globals.GameForm = this;
            Globals.AS2Container = AS2Container;
            Globals.AS3Container = AS3Container;

            BittyManager.InitBitty();
        }

        private void flashPlayerAS3_FSCommand(object sender, _IShockwaveFlashEvents_FSCommandEvent e)
        {
            string[] commandsList;

            try
            {
                commandsList = CommandParser.ParseReceivedMessage(e.args);
            }
            catch
            {
                LogManager.LogGeneral($"[AS3] [SendMsg] [Error] Failed to parse message! - {e.args}");
                return;
            }

            foreach (string command in commandsList)
            {
                string[] commandInfo = CommandParser.ParseCommand(command);
                if (commandInfo[0] != "log" || commandInfo[0] != "staticstorage")
                {
                    LogManager.LogIncoming("[AS3] [SendMsg] " + e.args);
                }
                switch (commandInfo[0])
                {
                    case "save_jpeg":
                        FileManager.SaveJPEG(commandInfo[1], commandInfo[2], commandInfo[3]);
                        break;
                    case "as3_transit":
                        SetVar(command); //Sends the AS3 command to AS2.
                        break;
                }
            }
        }

        private void flashPlayerAS3_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
        {
            string[] commandsList;

            try
            {
                commandsList = CommandParser.ParseReceivedMessage(e.request);
            }
            catch
            {
                LogManager.LogGeneral($"[AS3] [FlashCall] [Error] Failed to parse message! - {e.request}");
                return;
            }

            foreach (string command in commandsList)
            {
                string[] commandInfo = CommandParser.ParseCommand(command);
                if (commandInfo[0] != "log" || commandInfo[0] != "staticstorage")
                {
                    LogManager.LogIncoming("[AS3] [SendMsg] " + e.request);
                }
                switch (commandInfo[0])
                {
                    case "as3_loaded":
                        SetVar(@"<?xml version=""1.0"" encoding=""UTF - 8""?><commands><as3_loaded id=""1"" path=""MainAS3.swf"" result=""0"" err="""" /></commands>");
                        break;
                }
            }
        }

        void flashPlayer_FSCommand(object sender, _IShockwaveFlashEvents_FSCommandEvent e)
        {
            string[] commandsList;

            try
            {
                commandsList = CommandParser.ParseReceivedMessage(e.args);
            }
            catch
            {
                LogManager.LogGeneral($"[AS2] [SendMsg] [Error] Failed to parse message! - {e.args}");
                return;
            }

            foreach (string command in commandsList)
            {
                string[] commandInfo = CommandParser.ParseCommand(command);
                if (commandInfo[0] != "log" && commandInfo[0] != "staticstorage")
                {
                    LogManager.LogIncoming("[AS2] [SendMsg] " + e.args);
                }

                switch (commandInfo[0])
                {
                    // ----------------------------- FileManager ---------------------------- \\
                    case "load":
                        SetVar(FileManager.LoadFile(commandInfo[1], commandInfo[2]));
                        break;
                    case "save":
                        FileManager.SaveFile(commandInfo[1], commandInfo[2], command);
                        break;
                    case "createuser":
                        FileManager.CreateUser(commandInfo[1], commandInfo[2], commandInfo[3], commandInfo[4], commandInfo[5]);
                        break;

                    // ----------------------------- HttpManager ---------------------------- \\
                    case "netcommands":
                        LogManager.LogNetwork("Netcommand called.", "NetCommand");

                        string tnurl = "";
                        if (e.args.Contains("<save_level "))
                        {
                            XmlDocument request = new XmlDocument();
                            request.LoadXml(e.args);
                            XmlNodeList xnList = request.SelectNodes("/netcommands/save_level");
                            foreach (XmlNode xn in xnList)
                            {
                                tnurl = xn.Attributes["tnurl"].Value;
                            }

                            using (var client = new WebClient())
                            {
                                client.UploadFile(HttpManager.UGHost + "/" + tnurl, "PUT", Directory.GetCurrentDirectory() + @"\" + tnurl);
                            }
                        }

                        if (Settings.Default.IsOnline)
                        {
                            //Sends the result of the POST request. It's usually a command for the game to handle.
                            SetVar(HttpManager.HTTPPost(command, HttpManager.GXHost).ToString());
                        }
                        break;

                    // ---------------------------- UpdateManager --------------------------- \\
                    case "checkupdate":
                        UpdateManager.CheckUpdate();
                        break;
                    case "loadupdate":
                        UpdateManager.LoadUpdate();
                        break;

                    // ------------------------------ LogManager ---------------------------- \\
                    case "log":
                        var log = new XmlDocument();
                        log.LoadXml(e.args);
                        var node = log.SelectSingleNode("/log");
                        string message = node.InnerText;
                        LogManager.LogLog(message, commandInfo[1]);
                        break;
                    case "staticstorage":
                        string key = WebUtility.UrlDecode(commandInfo[3]);

                        switch (commandInfo[4])
                        {
                            case "get":
                                string value = WebUtility.UrlDecode(commandInfo[1]);
                                string defaultValue = WebUtility.UrlDecode(commandInfo[2]);
                                LogManager.LogStaticStorageGet(key, value, defaultValue);
                                break;

                            case "set":
                                string oldValue = WebUtility.UrlDecode(commandInfo[2]);
                                string newValue = WebUtility.UrlDecode(commandInfo[1]);
                                LogManager.LogStaticStorageSet(key, oldValue, newValue);
                                break;

                            case "delete":
                                string original = WebUtility.UrlDecode(commandInfo[2]);
                                LogManager.LogStaticStorageDelete(key, original);
                                break;
                        }
                        break;

                    // ------------------------------ GameForm  ----------------------------- \\
                    case "radicaclose":
                        RadicaClose();
                        break;
                    case "fullscreen":
                        if (commandInfo[1] == "1") //Fullscreen Mode
                        {
                            this.FormBorderStyle = FormBorderStyle.None;
                            this.WindowState = FormWindowState.Maximized;
                        }
                        else if (commandInfo[1] == "0") //Window Mode
                        {
                            this.FormBorderStyle = FormBorderStyle.Sizable;
                        }
                        break;
                    case "loaded":
                        SetVar(@"<bitybyte id=""FFFFFFF000000000"" />");
                        break;
                    case "as3_load":
                        AS3Container.Play();
                        AS2Container.SendToBack();
                        SetVar(@"<getstaticdata />");
                        SetVar(@"<getgamedata />");
                        SetVar(@"<getugsettings />");
                        break;
                    case "as3_close":
                        SetVar(@"<leavegame />");
                        AS3Container.SendToBack();
                        AS3Container.Stop();
                        break;
                    case "as3_setcurrentid":
                        //The game unescapes this string. "<commands><setid id="0" /></commands>" is the string. Unsure if it does anything, but it does not give a failure.
                        AS3Container.CallFunction(@"<invoke name=""WrapperCall"" returntype=""xml""><arguments><string>setid</string><string>%3c%63%6f%6d%6d%61%6e%64%73%3e%3c%73%65%74%69%64%20%69%64%3d%22%30%22%20%2f%3e%3c%2f%63%6f%6d%6d%61%6e%64%73%3e</string><string>%3c%63%6f%6d%6d%61%6e%64%73%3e%3c%73%65%74%69%64%20%69%64%3d%22%30%22%20%2f%3e%3c%2f%63%6f%6d%6d%61%6e%64%73%3e</string></arguments></invoke>");
                        AS3Container.SendToBack();
                        Directory.Delete(Directory.GetCurrentDirectory() + @"\misc\tmp\", true); //Deletes the temporary folder used for the results.
                        break;
                    case "checktrunkupdate":
                        SetVar(@"<checktrunkupdate result=""0"" reason=""Everything is up to date."" />");
                        break;
                    case "readytorecieve":
                        break;
                    default:
                        LogManager.LogGeneral($"[AS2] [SendMsg] Unhandled command! - {command}");
                        break;
                }
            }

        }

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                SetVar(@"<radicaclose />");
            }
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                DisposeElements();
                Application.Exit();
            }
        }

        public void RadicaClose()
        {
            LogManager.LogGeneral("[OpenFK] Radicaclose was called");
            DisposeElements();
            StartUpdate();
            Application.Exit();
        }

        void DisposeElements()
        {
            if (Settings.Default.RPC == true)
            {
                RichPresenceManager.Client.Dispose();
            }
            if (Settings.Default.USBSupport == true)
            {
                try
                {
                    Process process = Process.GetProcessesByName("MegaByte")[0];
                    process.Kill();
                }
                catch
                {
                    StartUpdate();
                    Application.Exit();
                }
            }
            if (Settings.Default.customF == true)
            {
                try
                {
                    Process process = Process.GetProcessesByName("FunkeySelectorGUI")[0];
                    process.Kill();
                }
                catch
                {
                    StartUpdate();
                    Application.Exit();
                }
            }
        }

        void StartUpdate()
        {
            if (Globals.WasUpdated)
            {
                ProcessStartInfo updatescript = new ProcessStartInfo(Directory.GetCurrentDirectory() + @"\tmpdl\OpenFK.exe");
                updatescript.Arguments = "/update";
                updatescript.WorkingDirectory = Directory.GetCurrentDirectory() + @"\tmpdl";
                updatescript.UseShellExecute = false;
                Process.Start(updatescript);
            }
        }

        public void SetVar(string msg)
        {
            LogManager.LogOutgoing("[SetVar/Return] Returned Message - " + msg);
            AS2Container.SetVariable("msg", msg);
        }

        const int WM_COPYDATA = 0x004A;

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }

        //Receives the Bitty Code from MegaByte and FSGUI.
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_COPYDATA)
            {
                COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));

                // Convert lpData to a string
                byte[] buffer = new byte[cds.cbData];
                Marshal.Copy(cds.lpData, buffer, 0, buffer.Length);
                string receivedData = Encoding.ASCII.GetString(buffer);

                LogManager.LogGeneral($"[Bitty] USB Bitty - {receivedData}");
                BittyManager.SetBitty(receivedData, true);
            }
            base.WndProc(ref m);
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '`')
            {
                BittyManager.ShowGUI();
            }
        }
    }
}
