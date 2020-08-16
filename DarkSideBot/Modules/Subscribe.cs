using DarkSide.Steam;
using DarkSide.Strings;
using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.Commands;
using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Subscription Module. for User Definition, Steam Account Linking, etc.
    /// </summary>
    [LocalizedName(ModuleResourceNames.Subscribe)]
    public class Subscribe : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Looks up User Profile
        /// </summary>
        /// <param name="userMention">User Profile</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.WhoIs, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.WhoIs)]
        public async Task WhoIsTask(SocketGuildUser userMention)
        {
            if (LinkedAccounts.UserDictionary.ContainsKey(userMention.Id))
            {
                var steam = new SteamAPIHandler();
                DarkSide.Models.Steam.SteamConvertData steamProfile = steam.GetProfile($"[U:1:{LinkedAccounts.UserDictionary[Context.User.Id]}]");
                var reply = $"{General.I_KNOW_USER_AS_STEAM_NAME.GetFormattedString(new string[] { userMention.Username, steamProfile.Name })}(http://steamcommunity.com/profiles/{steamProfile.Steamid64}) {Emojis.SmilingFace}";
                await ReplyAsync(string.Empty, false, new EmbedBuilder
                {
                    Description = reply
                }.Build());

            }
            else
                await ReplyAsync(General.I_DONT_KNOW_USER.GetFormattedString(new string[] { userMention.Username, userMention.Nickname, $"{Config.Bot.PrefixDictionary[Context.Guild.Id]}{Commands.I_AM}" }));
        }

        /// <summary>
        /// Asks the Bot Who Are You.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.WhoAmI, RunMode = RunMode.Async)]
        [LocalizedAlias(AliasResourceNames.WhoAmI)]
        [LocalizedSummary(SummaryResourceNames.WhoAmI)]
        public async Task WhoTask()
        {
            if (LinkedAccounts.UserDictionary.ContainsKey(Context.User.Id))
            {
                var steam = new SteamAPIHandler();
                DarkSide.Models.Steam.SteamConvertData steamProfile = steam.GetProfile($"[U:1:{LinkedAccounts.UserDictionary[Context.User.Id]}]");
                var reply = $"{General.NICE_TO_MEET_USER.GetFormattedString(steamProfile.Name)} (http://steamcommunity.com/profiles/{steamProfile.Steamid64}) {Emojis.SmilingFace}";
                await ReplyAsync(string.Empty, false, new EmbedBuilder
                {
                    Description = reply
                }.Build());
            }
            else
                await ReplyAsync(General.NEVER_MET_BEFORE.GetFormattedString(Commands.I_AM));
        }

        /// <summary>
        /// Main Subscription Command. Links a Steam Account with your Discord User.
        /// </summary>
        /// <param name="account">Account Name</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.IAm, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.IAm)]
        [LocalizedAlias(AliasResourceNames.IAm)]
        public async Task SubscribeTask(string account)
        {
            var steam = new SteamAPIHandler();
            DarkSide.Models.Steam.SteamConvertData steamProfile = steam.GetProfile(account);

            string reply;
            if (LinkedAccounts.UserDictionary.TryAdd(Context.User.Id, steamProfile.Uid))
            {
                reply = $"{General.NOW_I_KNOW_YOU.GetFormattedString(steamProfile.Name)}(http://steamcommunity.com/profiles/{steamProfile.Steamid64}) {Emojis.SmilingFace}";
                LinkedAccounts.Save();
            }
            else
                reply = $"{General.I_ALREADY_KNOW_YOU_AS.GetFormattedString(steamProfile.Name)}(http://steamcommunity.com/profiles/{steamProfile.Steamid64}) {Emojis.FrowningFace}";

            var embed = new EmbedBuilder { Description = reply };
            await ReplyAsync(string.Empty, false, embed.Build());
        }

        /// <summary>
        /// Removes the link between your Steam Account and your Discord User.
        /// </summary>
        /// <param name="accountId">Account to remove.</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.IAmNot, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.IAmNot)]
        public async Task UnSubscribeTask(string accountId)
        {
            if (LinkedAccounts.UserDictionary.ContainsKey(Context.User.Id))
            {
                var steam = new SteamAPIHandler();
                DarkSide.Models.Steam.SteamConvertData steamProfile = steam.GetProfile(accountId);
                if (LinkedAccounts.UserDictionary[Context.User.Id] == steamProfile.Uid)
                {
                    LinkedAccounts.UserDictionary.Remove(Context.User.Id);
                    LinkedAccounts.Save();
                    await ReplyAsync(General.YOU_ARE_NO_LONGER_USER.GetFormattedString(accountId));
                }
                else
                    await ReplyAsync(General.YOU_WERE_NEVER_USER.GetFormattedString(accountId));
            }
            else
                await ReplyAsync(General.NEVER_MET_BEFORE.GetFormattedString(Commands.I_AM));
        }
    }
}
