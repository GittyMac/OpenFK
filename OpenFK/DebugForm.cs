using OpenFK.OFK.Common;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OpenFK
{
    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();

            LogManager.generalLogs = generalLogs;
            LogManager.fileLogs = fileLogs;
            LogManager.incomingLogs = incomingLogs;
            LogManager.outgoingLogs = outgoingLogs;

            LogManager.CLogger = new Dictionary<string, RichTextBox>
            {
                { "all", CLoggerAll },
                { "trace", CLoggerTrace },
                { "debug", CLoggerDebug },
                { "info", CLoggerInfo },
                { "warning", CLoggerWarning },
                { "error", CLoggerError },
                { "fatal", CLoggerFatal }
            };

            LogManager.networkLogs = new Dictionary<string, RichTextBox>
            {
                { "All", NetworkAllLogs },
                { "GET", NetworkGetLogs },
                { "POST", NetworkPostLogs },
                { "NetCommand", NetworkCommandLogs }
            };

            LogManager.staticStorageLogs = staticStorageLogs;
        }
    }
}
