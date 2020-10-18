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
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public string Host; //Host
        public string Host2; //Host2
        public string Store; //FilestoreV2 (For updates)
        public string TStore; //Trunk
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
                setRP("Main Menu", "At the main menu");
            }
            //End of RP Initialize

            //Flash initialization
            AS2Container.Movie = Directory.GetCurrentDirectory() + @"\Main.swf"; //Sets Main.swf as the Flash Movie to Play.
            AS2Container.Play(); //Plays Main.swf
            Debug.WriteLine("Main.swf is Loaded");
            AS2Container.FSCommand += new _IShockwaveFlashEvents_FSCommandEventHandler(flashPlayer_FSCommand); //This sets up the FSCommand handler, which CCommunicator likes to use a lot.
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
                watcher.EnableRaisingEvents = true;
            }
            //End of customF Initialization
        }

        //
        //CUSTOMF
        //
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Thread.Sleep(500);
            setVar(@"<bitybyte id=""" + File.ReadAllText(Directory.GetCurrentDirectory() + @"\customF.txt").Remove(0, 14) + "00000000" + @""" />");
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

                    //BityByte
                    if (Settings.Default.customF == true) //If using no USB
                    {
                        if (e.args.Contains("trunk_main"))
                        {
                            setVar(@"<bitybyte id=""FFFFFFF000000000"" />");
                        }
                    }

                    //Rich Prescense
                    if (Settings.Default.RPC == true)
                    {
                        if (e.args.Contains(@"=""city"""))
                        {
                            setRP("Exploring", "Funkeystown");
                        }
                        else if (e.args.Contains(@"=""lava"""))
                        {
                            setRP("Exploring", "Magma Gorge");
                        }
                        else if (e.args.Contains(@"=""space"""))
                        {
                            setRP("Exploring", "Laputta Station");
                        }
                        else if (e.args.Contains(@"=""underwater"""))
                        {
                            setRP("Exploring", "Kelpy Basin");
                        }
                        else if (e.args.Contains(@"=""island"""))
                        {
                            setRP("Exploring", "Funkiki Island");
                        }
                        else if (e.args.Contains(@"=""racer"""))
                        {
                            setRP("Exploring", "Royalton Racing Complex");
                        }
                        else if (e.args.Contains(@"=""night"""))
                        {
                            setRP("Exploring", "Nightmare Rift");
                        }
                        else if (e.args.Contains(@"=""day"""))
                        {
                            setRP("Exploring", "Daydream Oasis");
                        }
                        else if (e.args.Contains(@"=""realm"""))
                        {
                            setRP("Exploring", "Hidden Realm");
                        }
                        else if (e.args.Contains(@"=""ssl"""))
                        {
                            setRP("Exploring", "Angus Manor");
                        }
                        else if (e.args.Contains(@"=""green"""))
                        {
                            setRP("Exploring", "Paradox Green");
                        }
                    }
                }
            }

            //
            // END OF XML LOAD COMMANDS
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
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\data\" + foldername + @"\" + filename + ".xml", output.ToString()); //saves
                }
            }

            //
            // END OF XML SAVE COMMANDS
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
                //AS2Container.SetVariable("msg", HTTPPost(e.args, Host).ToString()); //Sends the result of the POST request. It's usually a command for the game to handle.
            }

            //UPDATE CHECKS (Not standard netcommands)
            if (e.args.Contains("checkupdate"))
            {
                Debug.WriteLine("UPDATE - Requested!");
            }

            //
            //END OF HTTP NETCOMMANDS
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
            string index = @"<commands><load section=""" + file + @""" name=""" + folder + @""" result=""0"" reason="""">" + File.ReadAllText(Directory.GetCurrentDirectory() + @"\data\"+ folder + @"\" + file + ".xml") + @"</load></commands>"; //Puts XML file to string
            setVar(index.ToString()); //Sends XML data to the game
            Debug.WriteLine("RDF - Sent " + file + ".xml"); //Debug Output
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

        void setRP(string title, string info)
        {
            client.SetPresence(new RichPresence()
            {
                Details = info,
                State = title,
            });
        }

        //
        //END OF RICH PRESENCE
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
