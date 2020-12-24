using AxShockwaveFlashObjects;
using DiscordRPC;
using OpenFK.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace OpenFK
{

    // ===================================
    //  ____                   ______ _  __
    // / __ \                 |  ____| |/ /
    //| |  | |_ __   ___ _ __ | |__  | ' / 
    //| |  | | '_ \ / _ \ '_ \|  __| |  <  
    //| |__| | |_) |  __/ | | | |    | . \ 
    // \____/| .__/ \___|_| |_|_|    |_|\_\
    //       | |                           
    //       |_|                       
    // ===================================

    public partial class Form1 : Form
    {
        //Online Data
        public string Host; //Host
        public string Host2; //Host2
        public string Store; //FilestoreV2 (For updates)
        public string TStore; //Trunk

        //Rich Presence Data
        public string currentBitty;
        public string currentBittyName;
        public string currentWorld;
        public string currentActivity;

        //Debug Flags
        public bool DebugMB;
        public bool DebugOnline;

        //MegaByte Data
        private System.Windows.Forms.Timer bittyTimer; //Timer to check connected bitty.

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        const int PROCESS_WM_READ = 0x0010;

        public string bittyID; //Current bitty connected.


        //Items
        public XmlDocument bittyData;
        public DiscordRpcClient client;
        private FileSystemWatcher watcher;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Checks if the main SWF exists
            if(!File.Exists(Directory.GetCurrentDirectory() + @"\Main.swf"))
            {
                MessageBox.Show("Could not find Main.swf!", "OpenFK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            //End of Main.SWF check

            //RP Initialize
            if (Settings.Default.RPC == true)
            {
                client = new DiscordRpcClient("CLIENTID"); //Redacted client ID.
                client.Initialize();
                setRP("Main Menu", "At the main menu", "fffffff0", "U.B.");
            }
            //End of RP Initialize

            //Flash initialization
            AS2Container.Quality = Settings.Default.Quality;
            AS2Container.ScaleMode = Settings.Default.ScaleMode;
            AS2Container.Movie = Directory.GetCurrentDirectory() + @"\Main.swf"; //Sets Main.swf as the Flash Movie to Play.
            AS2Container.Play(); //Plays Main.swf
            Debug.WriteLine("Main.swf is Loaded");
            AS2Container.FSCommand += new _IShockwaveFlashEvents_FSCommandEventHandler(flashPlayer_FSCommand); //This sets up the FSCommand handler, which CCommunicator likes to use a lot.

            AS3Container.Quality = Settings.Default.Quality;
            AS3Container.ScaleMode = Settings.Default.ScaleMode;
            AS3Container.Movie = Directory.GetCurrentDirectory() + @"\MainAS3.swf"; //Sets MainAS3.swf as the Flash Movie to Play.
            Debug.WriteLine("MainAS3.swf is Loaded");
            AS3Container.FlashCall += new _IShockwaveFlashEvents_FlashCallEventHandler(flashPlayerAS3_FlashCall);
            //End of Flash initialization

            //customF Initialization
            if (Settings.Default.customF == true) //If using no USB
            {
                this.watcher = new FileSystemWatcher();
                watcher.Path = Directory.GetCurrentDirectory();
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                watcher.Filter = "customF.txt";
                watcher.Changed += OnChanged;
                watcher.SynchronizingObject = AS2Container;
                watcher.EnableRaisingEvents = true;
            }
            //End of customF Initialization

            //USB Initialization

            if (Settings.Default.USBSupport == true)
            {
                Process MBRun = new Process();
                ProcessStartInfo MBData = new ProcessStartInfo();
                MBData.FileName = Directory.GetParent(Directory.GetCurrentDirectory()) + @"\MegaByte\" + "MegaByte.exe";
                MBData.Arguments = "-MBRun -MBDebug";
                MBData.UseShellExecute = false;
                MBData.WindowStyle = ProcessWindowStyle.Minimized;
                MBRun.StartInfo = MBData;
                MBRun.Start();
                InitTimer();
            }

            //End of USB Initialization
        }

        //
        //USB READING
        //
        public void InitTimer()
        {
            bittyTimer = new System.Windows.Forms.Timer();
            bittyTimer.Tick += new EventHandler(bittyT_Tick);
            bittyTimer.Interval = 1000;
            bittyTimer.Start();
        }

        private void bittyT_Tick(object sender, EventArgs e)
        {
            try
            {
                Process process = Process.GetProcessesByName("MegaByte")[0]; //Get the process
                int bytesRead = 0;
                IntPtr processHandle = OpenProcess(PROCESS_WM_READ, false, process.Id);
                byte[] buffer = new byte[4]; //BittyID is 4 bytes

                //This reads the memory to fetch the current bittyID
                ReadProcessMemory((int)processHandle, 0x0049F020, buffer, buffer.Length, ref bytesRead); //With address
                Int32 baseValue = BitConverter.ToInt32(buffer, 0);

                Int32 firstAddress = baseValue + 0xF88; //With pointer
                ReadProcessMemory((int)processHandle, firstAddress, buffer, buffer.Length, ref bytesRead);
                Int32 firstValue = BitConverter.ToInt32(buffer, 0);

                ReadProcessMemory((int)processHandle, firstValue, buffer, buffer.Length, ref bytesRead);

                //Converts bytes to BittyID
                int bittyIDInt = BitConverter.ToInt32(buffer, 0);
                string s = bittyIDInt.ToString("X").PadLeft(8, '0');
                if (s == "00000000") //If no bitty is connected.
                {
                    s = "FFFFFFF0";
                }
                if (s != bittyID) //If it's still the same, it won't repeat the actions
                {
                    Debug.WriteLine("BittyID - " + s);
                    bittyID = s;
                    setBitty(s);
                }
            }
            catch
            {

            }
        }
        //
        //END OF USB READING
        //


        private void flashPlayerAS3_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
        {
            Debug.WriteLine("NEW AS3 CALL!" + " - " + e.request);
            if(e.request.Contains("<as3_loaded "))
            {
                setVar(@"<?xml version=""1.0"" encoding=""UTF - 8""?><commands><as3_loaded id=""1"" path=""MainAS3.swf"" result=""0"" err="""" /></commands>");
            }
        }

        //
        //CUSTOMF
        //
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            try //Runs a loop to keep reading until the file is not being saved.
            {
                setBitty(File.ReadAllText(Directory.GetCurrentDirectory() + @"\customF.txt").Remove(0, 14));
            }
            catch
            {
                OnChanged(sender, e);
            }
        }

        //
        //FSCOMMAND HANDLER
        //

        void flashPlayer_FSCommand(object sender, _IShockwaveFlashEvents_FSCommandEvent e) //FSCommand Handler
        {
            Debug.WriteLine("NEW COMMAND!" + " - " + e.command + " " + e.args);

            //
            // XML LOAD COMMANDS
            //

            if (e.args.Contains("<load ")) //load
            {
                //XML PARSING
                string filename; //section
                string foldername; //name
                XmlDocument request = new XmlDocument(); //e.args to xml
                request.LoadXml(e.args);
                XmlNodeList xnList = request.SelectNodes("/commands/load"); //filters xml to the load info
                foreach (XmlNode xn in xnList) //fetches the information to load
                {
                    //XML LOADING
                    filename = xn.Attributes["section"].Value;
                    foldername = xn.Attributes["name"].Value;
                    Debug.WriteLine("RDF Request: Section - {0} Name - {1}", filename, foldername);
                    loadFile(filename, foldername);

                    //Server Data
                    //TO BE IMPLEMENTED!!!
                    if (e.args.Contains("config"))
                    {

                    }

                    //Rich Prescense
                    if (Settings.Default.RPC == true)
                    {
                        if (e.args.Contains(@"=""city"""))
                        {
                            setRP("Exploring", "Funkeystown", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""lava"""))
                        {
                            setRP("Exploring", "Magma Gorge", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""space"""))
                        {
                            setRP("Exploring", "Laputta Station", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""underwater"""))
                        {
                            setRP("Exploring", "Kelpy Basin", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""island"""))
                        {
                            setRP("Exploring", "Funkiki Island", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""racer"""))
                        {
                            setRP("Exploring", "Royalton Racing Complex", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""night"""))
                        {
                            setRP("Exploring", "Nightmare Rift", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""day"""))
                        {
                            setRP("Exploring", "Daydream Oasis", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""realm"""))
                        {
                            setRP("Exploring", "Hidden Realm", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""ssl"""))
                        {
                            setRP("Exploring", "Angus Manor", currentBitty, currentBittyName);
                        }
                        else if (e.args.Contains(@"=""green"""))
                        {
                            setRP("Exploring", "Paradox Green", currentBitty, currentBittyName);
                        }
                    }
                }
            }

            //
            // END OF XML LOAD COMMANDS
            //

            //
            //LOADED
            //
            if(e.args.Contains("<loaded ")){

                //BityByte
                if (Settings.Default.customF == true) //If using no USB
                {
                    setVar(@"<bitybyte id=""FFFFFFF000000000"" />");
                }
            }
            
            //
            //END OF LOADED
            //

            //
            // XML SAVE COMMANDS
            //

            if (e.args.Contains("<save "))
            {
                //XML PARSING

                string filename; //section
                string foldername; //name
                XmlDocument request = new XmlDocument(); //e.args to xml
                request.LoadXml(e.args);
                XmlNodeList xnList = request.SelectNodes("/commands/save"); //filters xml to the load info;
                foreach (XmlNode xn in xnList) //fetches the information to load
                {
                    filename = xn.Attributes["section"].Value;
                    foldername = xn.Attributes["name"].Value;
                    Debug.WriteLine("RDF Request: Section - {0} Name - {1}", filename, foldername); //debug output

                    XDocument args = XDocument.Parse(e.args);

                    var save = args.Root.Element("save"); //Removing save element
                    save.Remove();
                    args.Root.Add(save.Elements());

                    XElement firstChild = args.Root.Elements().First(); //Removing commands element
                    XDocument output = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                                                     firstChild);

                    if(!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\" + foldername))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\" + foldername);
                    }
                    if (Settings.Default.RDF == true)
                    {
                        Encoding iso_8859_1 = Encoding.GetEncoding("iso-8859-1");
                        byte[] RDFData = iso_8859_1.GetBytes(output.ToString());
                        File.WriteAllBytes(Directory.GetCurrentDirectory() + @"\data\" + foldername + @"\" + filename + ".rdf", iso_8859_1.GetBytes(RDFTool.encode(iso_8859_1.GetString(RDFData))));
                    }
                    else File.WriteAllText(Directory.GetCurrentDirectory() + @"\data\" + foldername + @"\" + filename + ".xml", output.ToString()); //saves
                }
            }

            //
            // END OF XML SAVE COMMANDS
            //

            //
            // AS3 LOADING
            //

            if(e.args.Contains("<as3_load "))
            {
                //TODO - Fully load AS3 Files
                AS3Container.Play();
                AS2Container.SendToBack();
                setVar(@"<as3_transit idfrom=""%d"" xml=""%s"" />");
            }

            //
            // EMD OF AS3 LOADING
            //

            //
            // CLOSE COMMAND
            //

            if (e.args.Contains("radicaclose")) //Exit
            {
                if (Settings.Default.RPC == true)
                {
                    client.Dispose(); //Disposes RP
                }
                if(Settings.Default.USBSupport == true)
                {
                    Process process = Process.GetProcessesByName("MegaByte")[0];
                    process.Kill();
                }
                Application.Exit(); //Closes OpenFK
                Debug.WriteLine("radicaclose called, goodbye!"); //Debug output
            }

            //
            //END OF CLOSE COMMAND
            //

            //
            //FULLSCREEN COMMAND
            //

            if (e.args.Contains("fullscreen")) //Fullscreen
            {

                //PARSE OF XML DATA

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(e.args.ToString());
                var nodeList = doc.SelectNodes("commands");
                string commandLimited = "";
                foreach (XmlNode node in nodeList)
                {
                    Debug.WriteLine(node.InnerXml);
                    commandLimited = node.InnerXml;
                }
                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(commandLimited);
                XmlElement root = doc2.DocumentElement;
                string name = root.GetAttribute("state"); //Fullscreen status

                //AFTER PARSE

                if (name == "1") //Fullscreen Mode
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (name == "0") //Window Mode
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }

            //
            //END OF FULLSCREEN COMMAND
            //

            //
            //HTTP NETCOMMANDS
            //

            //HTTP POST (CRIB SAVING + POSTCARDS)
            if (e.args.Contains("<netcommands"))
            {
                Debug.WriteLine("NETCOMMAND!");
                if (DebugOnline == true)
                {
                    AS2Container.SetVariable("msg", HTTPPost(e.args, Host).ToString()); //Sends the result of the POST request. It's usually a command for the game to handle.
                }
            }

            //UPDATE CHECKS (Not standard netcommands)
            if (e.args.Contains("checkupdate"))
            {
                Debug.WriteLine("UPDATE - Requested!");
            }

            //
            //END OF HTTP NETCOMMANDS
            //

            //
            //FSGUI
            //

            if (e.args.Contains("<fsgui ")) //fsgui
            {
                //Open FSGUI
            }

            //
            //END OF FSGUI
            //
        }

        //
        //END OF FSCOMMAND HANDLER
        //

        //
        //CLOSE BUTTON
        //

        void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            if (e.CloseReason == CloseReason.UserClosing) //If user clicked the close button
            {
                AS2Container.SetVariable("msg", @"<radicaclose />");
            }
            if (e.CloseReason == CloseReason.WindowsShutDown) //If windows is shutting down
            {
                if (Settings.Default.RPC == true)
                {
                    client.Dispose(); //Disposes RP
                }
                if (Settings.Default.USBSupport == true)
                {
                    Process process = Process.GetProcessesByName("MegaByte")[0];
                    process.Kill();
                }
                Application.Exit(); //Closes OpenFK
            }
        }

        //
        //END OF CLOSE BUTTON
        //

        //
        //FILE LOADING
        //

        public void loadFile(string file, string folder)
        {
            Encoding iso_8859_1 = Encoding.GetEncoding("iso-8859-1");
            string index = "";
            string filedata = "";
            if (Settings.Default.RDF == true)
            {
                byte[] RDFData = File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\data\" + folder + @"\" + file + ".rdf");
                filedata = RDFTool.decode(iso_8859_1.GetString(RDFData));
            }
            else filedata = File.ReadAllText(Directory.GetCurrentDirectory() + @"\data\" + folder + @"\" + file + ".xml"); //Puts XML file to string
            index = @"<commands><load section=""" + file + @""" name=""" + folder + @""" result=""0"" reason="""">" + filedata + @"</load></commands>";

            if(file == "funkeys")
            {
                bittyData = new XmlDocument();
                bittyData.LoadXml(filedata);
            }

            setVar(index.ToString()); //Sends XML data to the game
            Debug.WriteLine("RDF - Sent " + file); //Debug Output
        }

        //
        //END OF FILE LOADING
        //

        //
        //SET FLASH VARIABLE
        //

        public void setVar(string msg)
        {
            AS2Container.SetVariable("msg", msg); //Sends message (msg) to the game
        }

        //
        //END OF SET FLASH VARIABLE
        //

        //
        //RICH PRESENCE
        //

        void setRP(string title, string info, string bittyID, string bittyName)
        {
            currentWorld = title;
            currentActivity = info;
            currentBitty = bittyID;
            currentBittyName = bittyName;
            client.SetPresence(new RichPresence()
            {
                Details = info,
                State = title,
                Assets = new Assets()
                {
                    LargeImageKey = bittyID,
                    LargeImageText = bittyName
                }
            });
        }

        //
        //END OF RICH PRESENCE
        //

        //
        //SET BITTY
        //

        void setBitty(string bittyID)
        {
            setVar(@"<bitybyte id=""" + bittyID + "00000000" + @""" />");
            currentBitty = bittyID.ToLower();
            if (Settings.Default.RPC == true)
            {
                try
                {
                    XmlNodeList nodes = bittyData.SelectNodes("//funkey[@id='" + bittyID + "']");
                    foreach (XmlNode xn in nodes)
                    {
                        currentBittyName = xn.Attributes["name"].Value;
                    }
                    setRP(currentWorld, currentActivity, currentBitty, currentBittyName);
                }
                catch
                {

                }
            }
        }

        //
        //END OF SET BITTY
        //

        //
        //POST REQUESTS
        //
        public string HTTPPost(string info, string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            var data = Encoding.ASCII.GetBytes(info);
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
        //
        //END OF POST REQUESTS
        //
    }
}
