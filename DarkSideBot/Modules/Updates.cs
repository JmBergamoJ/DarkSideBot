using DarkSide.Models.Bot;
using DarkSide.Strings;
using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.Commands;
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
    /// Updates Module. Can register a Text Channel to receive Dota Updates.
    /// </summary>
    [LocalizedName(ModuleResourceNames.Updates), RequireUserPermission(GuildPermission.Administrator)]
    public class Updates : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Register a text channel to receive dota updates
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Patches)]
        [LocalizedSummary(SummaryResourceNames.Patches)]
        public async Task PatchesTask()
        {
            var data = new SendData
            {
                GuildId = Context.Guild.Id,
                ChannelId = Context.Channel.Id
            };

            if (UpdateReceivers.Patches.Contains(data))
            {
                await ReplyAsync(General.ALREADY_SENDING_UPDATES.GetFormattedString(new string[] { Context.Guild.GetTextChannel(data.ChannelId)?.Name, Commands.NO_PATCHES }));
                return;
            }

            UpdateReceivers.Append(data);
            await ReplyAsync($"{General.I_WILL_SEND_UPDATES_IN_THE_CHANNEL} {Emojis.BallotBoxWithCheck}");
        }

        /// <summary>
        /// Removes Channel from Dota Update Subscription
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.NoPatches)]
        [LocalizedSummary(SummaryResourceNames.NoPatches)]
        [LocalizedAlias(AliasResourceNames.NoPatches)]
        public async Task NoPatchesTask()
        {
            UpdateReceivers.Remove(Context.Guild.Id);
            await ReplyAsync($"{General.NO_PATCHES_MESSAGE} {Emojis.ManFrowning}");
        }
    }
}
