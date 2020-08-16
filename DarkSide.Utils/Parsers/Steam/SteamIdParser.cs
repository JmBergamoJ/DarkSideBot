using DarkSide.Models.Steam;
using Newtonsoft.Json;
using System.Net;

namespace DarkSide.Utils.Parsers.Steam
{
    public static class SteamIdParser
    {
        public static SteamConvertData Parse(this string query)
        {
            string url = $"https://steamid.venner.io/raw.php?input={query}";
            using WebClient client = new WebClient();
            string json = client.DownloadString(url);
            SteamConvertData obj = JsonConvert.DeserializeObject<SteamConvertData>(json);
            return obj;
        }

        public static long Steam32Parse(this string query)
        {
            string url = $"https://steamid.venner.io/raw.php?input={query}";
            using WebClient client = new WebClient();
            string json = client.DownloadString(url);
            SteamConvertData obj = JsonConvert.DeserializeObject<SteamConvertData>(json);
            return obj.Uid;
        }

        public static long Steam64Parse(this string query)
        {
            string url = $"https://steamid.venner.io/raw.php?input={query}";
            using WebClient client = new WebClient();
            string json = client.DownloadString(url);
            SteamConvertData obj = JsonConvert.DeserializeObject<SteamConvertData>(json);
            return obj.Steamid64;
        }
    }
}
