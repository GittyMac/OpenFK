using OpenFK.OFK.Common;
using OpenFK.OFK.Net;
using OpenFK.Properties;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace OpenFK.OFK.Core
{
    static class FileManager
    {
        // ===================================
        // File Manager
        // Handles the modification/access of RDF files.
        // ===================================

        static XmlDocument UserData;

        /// <summary>
        /// Loads a specified data file and sends the contents to Flash.
        /// </summary>
        /// <param name="section">The file name to load.</param>
        /// <param name="name">The profile directory the file is located in.</param>
        public static string LoadFile(string section, string name)
        {
            LogManager.LogFile($"[Load] {name}/{section}");
            Encoding iso_8859_1 = Encoding.GetEncoding("iso-8859-1");
            string response;
            string filedata;
            try
            {
                if (Settings.Default.RDF == true)
                {
                    byte[] RDFData = File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\data\" + name + @"\" + section + ".rdf");
                    filedata = RDFManager.DecodeRDF(iso_8859_1.GetString(RDFData));
                }
                else filedata = File.ReadAllText(Directory.GetCurrentDirectory() + @"\data\" + name + @"\" + section + ".xml");
                response = @"<commands><load section=""" + section + @""" name=""" + name + @""" result=""0"" reason="""">" + filedata + @"</load></commands>";

                switch (section) 
                {
                    case "funkeys":
                        RichPresenceManager.BittyData = new XmlDocument();
                        RichPresenceManager.BittyData.LoadXml(filedata);
                        break;
                    case "users":
                        UserData = new XmlDocument();
                        UserData.LoadXml(filedata);
                        break;
                    case "config":
                        XmlDocument configData = new XmlDocument();
                        configData.LoadXml(filedata);

                        if (Settings.Default.IsOnline)
                        {
                            XmlAttribute host = (XmlAttribute)configData.SelectSingleNode("/settings/host/@value");
                            host.Value = Settings.Default.HTTPHost1;

                            XmlAttribute host1 = (XmlAttribute)configData.SelectSingleNode("/settings/host1/@value");
                            host1.Value = Settings.Default.HTTPHost2;

                            XmlAttribute tcpHost = (XmlAttribute)configData.SelectSingleNode("/settings/arkone_host/@value");
                            tcpHost.Value = Settings.Default.TCPHost;

                            XmlAttribute tcpPort = (XmlAttribute)configData.SelectSingleNode("/settings/arkone_port/@value");
                            tcpPort.Value = Settings.Default.TCPPort;

                            filedata = configData.OuterXml;
                            response = @"<commands><load section=""" + section + @""" name=""" + name + @""" result=""0"" reason="""">" + filedata + @"</load></commands>";
                        }

                        XmlNodeList xnList1 = configData.SelectNodes("/settings/host");
                        foreach (XmlNode xn in xnList1)
                        {
                            HttpManager.GXHost = xn.Attributes["value"].Value;
                        }

                        XmlNodeList xnList2 = configData.SelectNodes("/settings/host1");
                        foreach (XmlNode xn in xnList2)
                        {
                            HttpManager.UGHost = xn.Attributes["value"].Value;
                        }

                        XmlNodeList xnList3 = configData.SelectNodes("/settings/store");
                        foreach (XmlNode xn in xnList3)
                        {
                            HttpManager.FileStore = xn.Attributes["value"].Value;
                        }

                        XmlNodeList xnList4 = configData.SelectNodes("/settings/trunkstore");
                        foreach (XmlNode xn in xnList4)
                        {
                            HttpManager.TrunkStore = xn.Attributes["value"].Value;
                        }
                        break;

                    case "city":
                        RichPresenceManager.ChangeLocation("Funkeystown");
                        break;
                    case "lava":
                        RichPresenceManager.ChangeLocation("Magma Gorge");
                        break;
                    case "space":
                        RichPresenceManager.ChangeLocation("Laputta Station");
                        break;
                    case "underwater":
                        RichPresenceManager.ChangeLocation("Kelpy Basin");
                        break;
                    case "island":
                        RichPresenceManager.ChangeLocation("Funkiki Island");
                        break;
                    case "racer":
                        RichPresenceManager.ChangeLocation("Royalton Racing Complex");
                        break;
                    case "night":
                        RichPresenceManager.ChangeLocation("Nightmare Rift");
                        break;
                    case "day":
                        RichPresenceManager.ChangeLocation("Daydream Oasis");
                        break;
                    case "realm":
                        RichPresenceManager.ChangeLocation("Hidden Realm");
                        break;
                    case "ssl":
                        RichPresenceManager.ChangeLocation("Angus Manor");
                        break;
                    case "green":
                        RichPresenceManager.ChangeLocation("Paradox Green");
                        break;
                }

            }
            catch
            {
                //UGLevels requires an error to proceed.
                response = @"<commands><load section=""" + section + @""" name=""" + name + @""" result=""1"" reason=""Error loading file!"" /></commands>";
            }
            LogManager.LogFile($"[Load] [Success] {name}/{section}");
            return response.ToString();
        }

        /// <summary>
        /// Saves the contents inside of the command to a specified data file.
        /// </summary>
        /// <param name="section">The file name to save.</param>
        /// <param name="name">The profile directory used to save in.</param>
        /// <param name="data">The raw command that will be used as the output.</param>
        public static void SaveFile(string section, string name, string data)
        {
            LogManager.LogFile($"[Save] {name}/{section}");

            XDocument args = XDocument.Parse(data);

            XElement firstChild = args.Root.Elements().First();

            XDocument output = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                                                firstChild);

            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\" + name))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\" + name);
            }
            if (Settings.Default.RDF == true)
            {
                Encoding iso_8859_1 = Encoding.GetEncoding("iso-8859-1");
                byte[] RDFData = iso_8859_1.GetBytes(output.ToString());
                File.WriteAllBytes(Directory.GetCurrentDirectory() + @"\data\" + name + @"\" + section + ".rdf", iso_8859_1.GetBytes(RDFManager.EncodeXML(iso_8859_1.GetString(RDFData))));
            }
            else File.WriteAllText(Directory.GetCurrentDirectory() + @"\data\" + name + @"\" + section + ".xml", output.ToString()); //saves
            LogManager.LogFile($"[Save] [Success] {name}/{section}");
        }

        /// <summary>
        /// Deletes a specified file. Only used for UG thumbnails.
        /// </summary>
        public static void DeleteFile(string path) 
        {
            LogManager.LogFile($"[Delete] {path}");
            File.Delete(Directory.GetCurrentDirectory() + @"\" + path);
        }

        /// <summary>
        /// Saves a Base64 encoded JPEG file to a specified location.
        /// </summary>
        /// <param name="idfrom">The AS3 ID that is requesting the save.</param>
        /// <param name="str">The Base64 encoded JPEG data.</param>
        /// <param name="name">The location to save the JPEG.</param>
        public static void SaveJPEG(string idfrom, string str, string name)
        {
            var bytes = Convert.FromBase64String(str);
            Directory.CreateDirectory(Path.GetDirectoryName(Directory.GetCurrentDirectory() + @"\" + name));
            using (var jpegToSave = new FileStream(Directory.GetCurrentDirectory() + @"\" + name, FileMode.Create))
            {
                jpegToSave.Write(bytes, 0, bytes.Length);
                jpegToSave.Flush();
            }
            Globals.AS3Container.CallFunction(@"<invoke name=""WrapperCall"" returntype=""xml""><arguments><string>save_jpeg</string><string>0</string><string></string></arguments></invoke>");
        }

        /// <summary>
        /// Creates a user account in older versions by adding the user's entry in users.rdf.
        /// </summary>
        public static void CreateUser(string hinta, string hintq, string savepassword, string password, string name)
        {
            LogManager.LogFile("[Load] File Requested - system/users");
            LoadFile("users", "system");
            string userString = UserData.OuterXml;
            string data2send = userString.Replace("</users>", "") + @"<user gname=""" + name + @""" hinta=""" + hinta + @""" hintq=""" + hintq + @""" savepassword=""" + savepassword + @""" password=""" + password + @""" name=""" + name + @""" /></users>";
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data\" + "system"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data\" + "system");
            }
            if (Settings.Default.RDF == true)
            {
                Encoding iso_8859_1 = Encoding.GetEncoding("iso-8859-1");
                byte[] RDFData = iso_8859_1.GetBytes(data2send.ToString());
                File.WriteAllBytes(Directory.GetCurrentDirectory() + @"\data\" + "system" + @"\" + "users" + ".rdf", iso_8859_1.GetBytes(RDFManager.EncodeXML(iso_8859_1.GetString(RDFData))));
            }
            else File.WriteAllText(Directory.GetCurrentDirectory() + @"\data\" + "system" + @"\" + "users" + ".xml", data2send.ToString());
            LogManager.LogFile("[UserAdd] [Success] " + name);
        }
    }
}
