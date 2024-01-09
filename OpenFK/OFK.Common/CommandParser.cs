using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace OpenFK.OFK.Common
{
    static class CommandParser
    {
        /// <summary>
        /// Breaks each message into their own XML string.
        /// </summary>
        /// <returns>
        /// A string array with each raw command in the message.
        /// </returns>
        public static string[] ParseReceivedMessage(string xmlCommand)
        {
            List<string> commandsList = new List<string>();

            xmlCommand = xmlCommand.Replace("\0", string.Empty);

            XDocument breakableXMLMessage = XDocument.Parse(xmlCommand);
            XElement commandRoot = breakableXMLMessage.Root;
            if(commandRoot.Name.LocalName != "commands") 
            {
                commandsList.Add(xmlCommand);
                return commandsList.ToArray();
            }

            foreach (var comElement in breakableXMLMessage.Descendants("commands").Elements())
            {
                commandsList.Add(comElement.ToString());
            }

            return commandsList.ToArray();
        }

        /// <summary>
        /// Parses the command's parameters and descendants.
        /// </summary>
        /// <returns>
        /// A string array with the first element being the command name, and the subsequent elements being the parameters, then descendants.
        /// </returns>
        public static string[] ParseCommand(string command)
        {
            List<string> commandInfo = new List<string>();

            XDocument commandXML = XDocument.Parse(command);
            XElement commandRoot = commandXML.Root;

            commandInfo.Add(commandRoot.Name.LocalName);

            var attrNames = (
               from a in commandRoot.Attributes()
               select a.Value
            );

            foreach (string value in attrNames)
            {
                commandInfo.Add(value);
            }

            //Allows parsing of descendant elements.
            foreach (XElement element in commandRoot.Descendants())
            {
                var desAttrNames = (
                    from a in element.Attributes()
                    select a.Value
                );

                foreach (string value in desAttrNames)
                {
                    commandInfo.Add(value);
                }
            }

            return commandInfo.ToArray();
        }
    }
}
