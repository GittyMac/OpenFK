using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace OpenFK.OFK.Common
{
    static class LogManager
    {
        public static RichTextBox generalLogs;
        public static RichTextBox fileLogs;
        public static RichTextBox incomingLogs;
        public static RichTextBox outgoingLogs;
        public static Dictionary<string, RichTextBox> CLogger;
        public static Dictionary<string, RichTextBox> networkLogs;
        public static RichTextBox staticStorageLogs;

        private static void AppendLine(RichTextBox richTextBox, string message)
        {
            if (Globals.IsDebug)
            {
                try
                {
                    richTextBox.AppendText("\n" + message);
                }
                catch
                {
                    Debug.WriteLine($"[{richTextBox.Name}] {message}");
                }
            }
        }

        public static void LogGeneral(string message)
        {
            AppendLine(generalLogs, message);
        }

        public static void LogFile(string message)
        {
            AppendLine(fileLogs, message);
            LogGeneral($"[File] {message}");
        }

        public static void LogIncoming(string message)
        {
            AppendLine(incomingLogs, message);
            LogGeneral($"[Incoming] {message}");
        }

        public static void LogOutgoing(string message)
        {
            AppendLine(outgoingLogs, message);
            LogGeneral($"[Outgoing] {message}");
        }

        public static void LogLog(string message, string level)
        {
            message = $"[{level}] {message}";
            AppendLine(CLogger[level], message);
            AppendLine(CLogger["all"], message);
        }

        public static void LogNetwork(string message, string method)
        {
            message = $"[{method}] {message}";
            AppendLine(networkLogs[method], message);
            AppendLine(networkLogs["All"], message);
            LogGeneral($"[Network] {message}");
        }

        //TODO: implement table view to keep track of values like the localstorage viewer in devtools
        public static void LogStaticStorageSet(string key, string oldValue, string newValue)
        {
            string message = $"[Set] {key} = {oldValue} --> {newValue}";
            AppendLine(staticStorageLogs, message);
        }

        public static void LogStaticStorageGet(string key, string value, string defaultValue)
        {
            string message = $"[Get] {key} = {value} || {defaultValue}";
            AppendLine(staticStorageLogs, message);
        }

        public static void LogStaticStorageDelete(string key, string oldValue)
        {
            string message = $"[Delete] {key} = {oldValue}";
            AppendLine(staticStorageLogs, message);
        }
    }
}
