using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenFK.OFK.Common
{
    static class LogManager
    {
        public static RichTextBox debugLogText;
        public static void LogToForm(string logElement) 
        {
            if(debugLogText != null) 
            {
                try
                {
                    debugLogText.AppendText("\n" + logElement);
                }
                catch
                {
                    Debug.WriteLine(logElement);
                }
            }
        }
    }
}
