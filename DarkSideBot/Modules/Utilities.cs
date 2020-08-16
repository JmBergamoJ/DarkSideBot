using DarkSide.Strings.ResourceNames;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Utilities Module. Useful commands.
    /// </summary>
    [LocalizedName(ModuleResourceNames.Utilities)]
    public class Utilities : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Ping Command. Checks current latency
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Ping, RunMode = RunMode.Async)]
        [LocalizedAlias(AliasResourceNames.Ping)]
        [LocalizedSummary(SummaryResourceNames.Ping)]
        public async Task LatencyAsyncTask()
        {
            IUserMessage message;
            Stopwatch stopwatch;
            var heartbeat = Context.Client.Latency;

            var tcs = new TaskCompletionSource<long>();
            var timeout = Task.Delay(TimeSpan.FromSeconds(30));

            Task TestMessageAsync(SocketMessage arg)
            {
                if (arg.Id != message?.Id)
                    return Task.CompletedTask;

                tcs.SetResult(stopwatch.ElapsedMilliseconds);
                return Task.CompletedTask;
            }

            stopwatch = Stopwatch.StartNew();
            message = await ReplyAsync($"```Hearbeat: {heartbeat}ms: init: ---, rtt: ---```");
            var init = stopwatch.ElapsedMilliseconds;

            Context.Client.MessageReceived += TestMessageAsync;
            Task task = await Task.WhenAny(tcs.Task, timeout);
            Context.Client.MessageReceived -= TestMessageAsync;
            stopwatch.Stop();

            if (task == timeout)
                await message.ModifyAsync(x => x.Content = $"```Heartbeat: {heartbeat}ms, init: {init}ms, rtt: timed out```");
            else
            {
                var rtt = await tcs.Task;
                await message.ModifyAsync(x => x.Content = $"```Heartbeat: {heartbeat}ms, init: {init}ms, rtt: {rtt}ms```");
            }
        }

        /// <summary>
        /// Sends invite links in the chat.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Invite)]
        [LocalizedSummary(SummaryResourceNames.Invite)]
        public async Task Invite()
        {
            System.Collections.Generic.IReadOnlyCollection<Discord.Rest.RestInviteMetadata> invites = await Context.Guild.GetInvitesAsync();
            Discord.Rest.RestInviteMetadata invite = invites.FirstOrDefault(i => i.GuildId == Context.Guild.Id);
            var embed = new EmbedBuilder
            {
                Description = $"1. [Invite]({invite.Url}){Environment.NewLine}"
            };
            await ReplyAsync(string.Empty, embed: embed.Build());
        }
    }
}
