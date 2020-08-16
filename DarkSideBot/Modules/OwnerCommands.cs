using DarkSide.Strings;
using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Owner commands. Commands only for the Bot Owner
    /// </summary>
    [RequireOwner, LocalizedName(ModuleResourceNames.OwnerCommands)]
    public class OwnerCommands : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Downloads the Database. Very Bad.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.GiveDataBase)]
        [LocalizedSummary(SummaryResourceNames.GiveDataBase)]
        public async Task GiveDatabaseTask()
        {
            IUserMessage msg = await ReplyAsync("Loading Database");
            ZipFile.CreateFromDirectory(@"Resources", @"Resources.zip", CompressionLevel.Optimal, true);
            await Context.Channel.SendFileAsync("Resources.zip");
            File.Delete("Resources.zip");
            await msg.DeleteAsync();
        }

        /// <summary>
        /// Makes a user a "Pro" User. requires mention
        /// </summary>
        /// <param name="socketUser">User</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.MakePro)]
        [LocalizedSummary(SummaryResourceNames.MakePro)]
        public async Task ProTask(SocketUser socketUser)
        {
            var result = socketUser.MakePro();
            if (result)
                await ReplyAsync($"{General.PRO_STATUS_GRANTED.GetFormattedString(socketUser.Username)} {Emojis.ConfettiBall}");
            else
                await ReplyAsync($"{General.PRO_STATUS_ALREADY_GRANTED.GetFormattedString(socketUser.Username)} {Emojis.ThinkingFace}");
        }

        /// <summary>
        /// Revokes a "Pro" Status grantes to a User
        /// </summary>
        /// <param name="socketUser">User</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.RemovePro)]
        [LocalizedSummary(SummaryResourceNames.RemovePro)]
        public async Task RemoveProTask(SocketUser socketUser)
        {
            var result = socketUser.RemovePro();
            if (result)
                await ReplyAsync($"{General.PRO_STATUS_REMOVED.GetFormattedString(socketUser.Username)} {Emojis.RestInPeace}");
            else
                await ReplyAsync($"{General.PRO_STATUS_NEVER_GRANTED.GetFormattedString(socketUser.Username)} {Emojis.ThinkingFace}");
        }

        /// <summary>
        /// Gets the Bots Stats, like Uptime, memory usage, total servers and users.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.BotStats)]
        [LocalizedSummary(SummaryResourceNames.BotStats)]
        public async Task BotMainStats()
        {
            TimeSpan time = DateTime.Now - Process.GetCurrentProcess().StartTime;
            var upTime = $"{General.BOT_UP_FOR}:{Environment.NewLine}" +
                $"{(time.Days > 0 ? time.Days.ToString() : string.Empty)} {(time.Days > 0 ? General.DAY_S : string.Empty)} " +
                $"{(time.Hours > 0 ? time.Hours.ToString() : string.Empty)} {(time.Hours > 0 ? General.HOUR_S : string.Empty)} " +
                $"{(time.Minutes > 0 ? time.Minutes.ToString() : string.Empty)} {(time.Minutes > 0 ? General.MINUTE_S : string.Empty)} " +
                $"{(time.Seconds > 0 ? time.Seconds.ToString() : string.Empty)} {(time.Seconds > 0 ? General.SECOND_S : string.Empty)}";

            var process = Process.GetCurrentProcess();
            var mem = process.PrivateMemorySize64;
            var memory = mem / 1024 / 1024;
            var totalUsers = Context.Client.Guilds.Sum(guild => guild.MemberCount);

            var builder = new EmbedBuilder();
            builder.WithTitle(General.BOT_STATS);
            builder.WithDescription(General.BOT_STATS_DESCR);
            builder.WithThumbnailUrl(Context.User.GetAvatarUrl(ImageFormat.Auto, 64));
            builder.WithColor(new Color(0x00ff00));
            builder.AddField($"{General.PING}:", $"```fix{Environment.NewLine}{Context.Client.Latency}ms```", true);
            builder.AddField($"{General.TOTAL_SERVERS}:", $"```fix{Environment.NewLine}{Context.Client.Guilds.Count} {General.TOTAL_SERVERS}```", true);
            builder.AddField($"{General.TOTAL_USERS}:", $"```fix{Environment.NewLine}{totalUsers} {General.TOTAL_USERS}```", true);
            builder.WithTimestamp(DateTimeOffset.UtcNow.UtcDateTime);
            builder.WithFooter(
                x =>
                {
                    x.WithText($"{General.BOT_STATS} | {General.REQUESTED_BY} {Context.User.Username}");
                    x.WithIconUrl(Context.User.GetAvatarUrl());
                });
            builder.AddField($"{General.MEMORY_USAGE}:", $"```fix{Environment.NewLine}{memory}Mb```", true);
            builder.AddField($"{General.UP_TIME}:", $"```prolog{Environment.NewLine}{upTime}```", true);

            await ReplyAsync(string.Empty, false, builder.Build());
        }

        /// <summary>
        /// Change the bots Locale.
        /// <para>Checks if new locale is valid. Requires restart.</para>
        /// </summary>
        /// <param name="NewLocale">New Locale for Change.
        /// </param>
        /// <returns>Replies with Current locale and if changing the locale, the new locale.</returns>
        [LocalizedCommand(CommandResourceNames.Locale), LocalizedSummary(SummaryResourceNames.Locale)]
        public async Task LocaleTask(string NewLocale = null)
        {
            await ReplyAsync(General.CURRENT_LOCALE.GetFormattedString(Thread.CurrentThread.CurrentCulture.Name));
            if (!NewLocale.IsNullOrEmpty())
            {
                if (CultureValidation.IsValidCultureName(NewLocale))
                {
                    Config.Bot.Locale = NewLocale;
                    Config.Save();
                    await ReplyAsync(General.LOCALE_CHANGED.GetFormattedString(NewLocale));
                }
                else
                {
                    await ReplyAsync(General.LOCALE_NOT_FOUND.GetFormattedString(NewLocale));
                }
            }
        }
    }
}
