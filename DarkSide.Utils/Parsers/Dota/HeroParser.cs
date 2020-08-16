using DarkSide.Models.Dota;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DarkSide.Utils.Parsers.Dota
{
    public static class HeroParser
    {
        private static string HeroName(this int heroId)
        {
            var json = File.ReadAllText("Resources\\Dota\\Heroes.json");
            List<Hero> obj = JsonConvert.DeserializeObject<List<Hero>>(json);
            Hero hero = obj.First(x => x.Id == heroId);
            return hero.LocalizedName;
        }

        public static string HeroName(this long? heroId) => HeroName((int)heroId);
        public static string HeroName(this long heroId) => HeroName((int)heroId);
    }
}
