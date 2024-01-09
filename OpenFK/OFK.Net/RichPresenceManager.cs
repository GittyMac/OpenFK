using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenFK.OFK.Net
{
    static class RichPresenceManager
    {
        // ===================================
        // Rich Presence Manager
        // Handles Discord Rich Presence.
        // ===================================

        public static DiscordRpcClient Client;
        public static XmlDocument BittyData;
        public static string CurrentBitty;
        public static string CurrentBittyName;
        public static string CurrentWorld;
        public static string CurrentActivity;

        public static void InitRPC() 
        {
            Client = new DiscordRpcClient("506150783893504001");
            Client.Initialize();
            SetRP("Main Menu", "At the main menu", "fffffff0", "U.B.");
        }

        public static void SetRP(string title, string info, string bittyID, string bittyName)
        {
            CurrentWorld = title;
            CurrentActivity = info;
            CurrentBitty = bittyID;
            CurrentBittyName = bittyName;
            Client.SetPresence(new RichPresence()
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

        public static void ChangeLocation(string location) 
        {
            if (Properties.Settings.Default.RPC)
            {
                SetRP("Exploring", location, CurrentBitty, CurrentBittyName);
            }
        }
    }
}
