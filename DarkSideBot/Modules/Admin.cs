using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Admin Module - Commands for Guild Admins
    /// </summary>
    [LocalizedName(ModuleResourceNames.Admin), RequireUserPermission(GuildPermission.Administrator)]
    public class Admin : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Change or check current prefix on Guild
        /// </summary>
        /// <param name="newPrefix">New Prefix for change</param>
        /// <returns>Replies with current prefix or new prefix confirmation</returns>
        [LocalizedCommand(CommandResourceNames.Prefix), LocalizedSummary(SummaryResourceNames.Prefix)]
        public async Task PrefixTask(string newPrefix = null)
        {
            if (string.IsNullOrEmpty(newPrefix))
            {
                await base.ReplyAsync(General.CURRENT_PREFIX_MESSAGE.GetFormattedString(Config.Bot.PrefixDictionary[Context.Guild.Id]));
            }
            else
            {
                Config.Bot.PrefixDictionary[Context.Guild.Id] = newPrefix;
                Config.Save();
                await ReplyAsync(General.NEW_PREFIX_MESSAGE.GetFormattedString(newPrefix));
            }
        }
    }
}
