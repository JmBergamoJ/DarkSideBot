using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DarkSideBot
{
    internal static class Config
    {
        public static BotConfig Bot;

        static Config()
        {
            if (!Directory.Exists("Resources"))
            {
                Directory.CreateDirectory("Resources");
            }

            if (File.Exists("Resources/Config.json"))
            {
                Bot = JsonConvert.DeserializeObject<BotConfig>(File.ReadAllText("Resources/Config.json"));
            }
            else
            {
                Bot = new BotConfig
                {
                    Token = null,
                    Locale = "en-US",
                    DevToken = null,
                    PrefixDictionary = new Dictionary<ulong, string>(),
                    DblToken = null
                };
                Save();
            }
        }

        public static void Save()
        {
            var json = JsonConvert.SerializeObject(Bot, Formatting.Indented);
            File.WriteAllText("Resources/Config.json", json);
        }

        public struct BotConfig
        {
            public string Token { get; set; }
            public string DevToken { get; set; }
            public Dictionary<ulong, string> PrefixDictionary { get; set; }
            public string DblToken { get; set; }
            public string Locale { get; set; }
        }
    }
}
