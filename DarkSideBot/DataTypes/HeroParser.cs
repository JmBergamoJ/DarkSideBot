using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DarkSideBot.DataTypes
{
    internal static class HeroParser
    {
        private static string HeroName(this int heroId)
        {
            var json = File.ReadAllText("Resources\\Dota\\Heroes.json");
            var obj = JsonConvert.DeserializeObject<List<Hero>>(json);
            var hero = obj.First(x => x.Id == heroId);
            return hero.LocalizedName;
        }

        public static string HeroName(this long heroId)
        {
            return HeroName((int)heroId);
        }
    }
}
