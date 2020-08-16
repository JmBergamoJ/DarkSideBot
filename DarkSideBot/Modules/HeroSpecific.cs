using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using Discord.Commands;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Hero Specific Module. Commands on Specific DotA Heroes.
    /// </summary>
    [LocalizedName(ModuleResourceNames.HeroSpecific)]
    public class HeroSpecific : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Hero Talents Command. Gets Hero Talents.
        /// </summary>
        /// <param name="hero">Hero to get Talents</param>
        /// <returns>Talents Info or Error Message</returns>
        [LocalizedCommand(CommandResourceNames.Talents)]
        [LocalizedAlias(AliasResourceNames.Talents)]
        [LocalizedSummary(SummaryResourceNames.Talents)]
        public async Task HeroTalentTask([LocalizedSummary(SummaryResourceNames.HeroNameFirstLetters)] [Remainder] string hero)
        {
            var data = File.ReadAllText("Resources\\Dota\\Talents.txt");

            System.Globalization.CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;

            hero = textInfo.ToTitleCase(hero);
            var lines = data.Split("\n").ToList();
            var pattern = $"dline\" id=\"{hero.Split(" ").First()}";
            var regex = new Regex(pattern);
            var ind = lines.IndexOf(lines.First(x => regex.IsMatch(x)));
            var newList = lines.Skip(ind).Where(x => x.Contains(@"<td width=""280"">")).Take(8).ToList();
            var i = 5;
            var temp = string.Empty;
            var j = 0;
            var returnMessage = $"```";
            foreach (var s in newList)
            {
                var regexResult = s.Replace(@"<td width=""280"">", "");
                regexResult = Regex.Replace(regexResult, @".+<b>(.+)</b>.+", "$1");
                regexResult = regexResult.Replace("\n", "");
                regexResult = regexResult.Trim();
                if (j % 2 == 0)
                    temp = regexResult;
                else
                    returnMessage +=$"{i-- * 5,-2} => {temp.Truncate(25),-25} | {regexResult.Truncate(25),25}{Environment.NewLine}";
                
                j++;
            }

            returnMessage += "```";
            await ReplyAsync(returnMessage);
        }
    }
}
