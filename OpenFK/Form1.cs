using AxShockwaveFlashObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace OpenFK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axShockwaveFlash1.Movie = Directory.GetCurrentDirectory() + @"\Main.swf"; //Sets Main.swf as the Flash Movie to Play.
            axShockwaveFlash1.Play(); //Plays Main.swf
            Debug.WriteLine("Main.swf is Loaded");
            axShockwaveFlash1.FSCommand += new _IShockwaveFlashEvents_FSCommandEventHandler(flashPlayer_FSCommand); //This sets up the FSCommand handler, which CCommunicator likes to use a lot.
        }
        void flashPlayer_FSCommand(object sender, _IShockwaveFlashEvents_FSCommandEvent e) //FSCommand Handler
        {
            Debug.WriteLine("NEW COMMAND!" + " - " + e.command + " " + e.args);
            if (e.args.Contains("<load ")) //RDF loading
            {
                //Removes Commands section
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(e.args.ToString());
                var nodeList = doc.SelectNodes("commands");
                string commandLimited = "";
                foreach (XmlNode node in nodeList)
                {
                    Console.WriteLine(node.InnerXml);
                    commandLimited = node.InnerXml;
                }
                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(commandLimited);
                XmlElement root = doc2.DocumentElement;
                //Checks filename.
                string name = root.GetAttribute("section");
                //Gets filename
                string index = File.ReadAllText(@"C:\Users\Lako\Documents\UB Funkeys\RadicaGame\data\system\" + name + ".xml");
                Debug.WriteLine("RDF - Sent " + name + ".xml");
                //Sends filename to the game
                axShockwaveFlash1.SetVariable("msg", index.ToString());
            }
            if (e.args.Contains("<save")) //Save
            {
                //Removes the Commands Section
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(e.args.ToString());
                var nodeList = doc.SelectNodes("commands");
                string commandLimited = "";
                foreach (XmlNode node in nodeList)
                {
                    Console.WriteLine(node.InnerXml);
                    commandLimited = node.InnerXml;
                }
                //Removes the Save section
                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(commandLimited);
                XmlElement root = doc2.DocumentElement;
                //Gets the filename to save.
                string name = root.GetAttribute("section");
                var nodeList2 = doc.SelectNodes("save");
                string commandLimited2 = "";
                foreach (XmlNode node in nodeList2)
                {
                    Console.WriteLine(node.InnerXml);
                    commandLimited2 = node.InnerXml;
                }
                XmlDocument doc3 = new XmlDocument();
                doc3.LoadXml(commandLimited2);
                //Saves XML
                File.WriteAllText(@"C:\Users\Lako\Documents\UB Funkeys\RadicaGame\data\system\" + name + ".xml", commandLimited2);
                Debug.WriteLine("RDF - Saved " + name + ".xml");
                axShockwaveFlash1.SetVariable("msg", @"<save name=""system"" section=""" + name + @""" result=""0"" />");
            }
            if (e.args.Contains("radicaclose")) //Exit
            {
                Application.Exit();
                Debug.WriteLine("radicaclose called, goodbye!");
            }
            if (e.args.Contains("fullscreen")) //Fullscreen
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(e.args.ToString());
                var nodeList = doc.SelectNodes("commands");
                string commandLimited = "";
                foreach (XmlNode node in nodeList)
                {
                    Console.WriteLine(node.InnerXml);
                    commandLimited = node.InnerXml;
                }
                XmlDocument doc2 = new XmlDocument();
                doc2.LoadXml(commandLimited);
                var nodeList2 = doc2.SelectNodes("state");
                XmlElement root = doc2.DocumentElement;
                String name = root.GetAttribute("state");
                if(name == "1")
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }
        void Form_FormClosing(object sender, FormClosingEventArgs e) //Exit button
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                axShockwaveFlash1.SetVariable("msg", @"<radicaclose />");
            }
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                Application.Exit();
            }
        }
    }
}
