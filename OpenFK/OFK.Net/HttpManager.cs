using OpenFK.OFK.Common;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace OpenFK.OFK.Net
{
    static class HttpManager
    {
        // ===================================
        // HTTP Manager
        // Handles anything to do with Galaxy and HTTP.
        // ===================================

        /// <summary> 
        /// The hostname for the Galaxy server. 
        /// </summary>
        public static string GXHost;

        /// <summary> 
        /// The hostname for the UGC (Funkey Tools) server. 
        /// </summary>
        public static string UGHost;

        /// <summary> 
        /// The address to the remote game files. Used for updates. 
        /// </summary>
        public static string FileStore;

        /// <summary> 
        /// The address to the trunk files. Used for Funkey Trunk updates. 
        /// </summary>
        public static string TrunkStore;

        /// <summary> 
        /// Sends a NetCommand to the Galaxy/UG server via POST.
        /// </summary>
        /// <returns>
        /// A string containing the server's response command that will be sent back to Flash.
        /// </returns>
        public static string HTTPPost(string info, string uri)
        {
            LogManager.LogNetwork($"{uri} {info}", "POST");

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

            string tnurl = "";

            //TODO - Simplify these get_CATEGORY thumbnail requests as they are all the same.
            if (responseString.Contains("<get_level "))
            {
                XmlDocument xRequest = new XmlDocument(); //e.args to xml
                xRequest.LoadXml(responseString);
                XmlNodeList xnList = xRequest.SelectNodes("/get_level/level"); //filters xml to the load info
                foreach (XmlNode xn in xnList)
                {
                    if (xn.Attributes.GetNamedItem("tnurl") != null)
                    {
                        tnurl = xn.Attributes["tnurl"].Value;
                    }
                }

                if (tnurl != "")
                {
                    using (var client = new System.Net.WebClient())
                    {
                        client.DownloadFile(UGHost + "/" + tnurl, Directory.GetCurrentDirectory() + @"\" + tnurl);
                    }
                }
            }
            else if (responseString.Contains("<get_top "))
            {
                XmlDocument xRequest = new XmlDocument(); //e.args to xml
                xRequest.LoadXml(responseString);
                XmlNodeList xnList = xRequest.SelectNodes("/get_top/levels/level"); //filters xml to the load info
                foreach (XmlNode xn in xnList)
                {
                    if (xn.Attributes.GetNamedItem("tnurl") != null)
                    {
                        tnurl = xn.Attributes["tnurl"].Value;
                    }
                    if (tnurl != "")
                    {
                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(UGHost + "/" + tnurl, Directory.GetCurrentDirectory() + @"\" + tnurl);
                        }
                    }
                }
            }
            else if (responseString.Contains("<get_sh_levels "))
            {
                XmlDocument xRequest = new XmlDocument(); //e.args to xml
                xRequest.LoadXml(responseString);
                XmlNodeList xnList = xRequest.SelectNodes("/get_sh_levels/levels/level"); //filters xml to the load info
                foreach (XmlNode xn in xnList)
                {
                    if (xn.Attributes.GetNamedItem("tnurl") != null)
                    {
                        tnurl = xn.Attributes["tnurl"].Value;
                    }
                    if (tnurl != "")
                    {
                        using (var client = new System.Net.WebClient())
                        {
                            client.DownloadFile(UGHost + "/" + tnurl, Directory.GetCurrentDirectory() + @"\" + tnurl);
                        }
                    }
                }
            }

            return responseString;
        }

        /// <summary> 
        /// Retrieves a plain text file from an external server.
        /// </summary>
        /// <returns>
        /// A string containing the file's contents.
        /// </returns>
        public static string HTTPGet(string uri)
        {
            LogManager.LogNetwork(uri, "GET");

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
