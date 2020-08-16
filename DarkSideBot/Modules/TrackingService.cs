using DarkSide.Models.Bot;
using DarkSide.Steam;
using DarkSide.Strings;
using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using Discord;
using Discord.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Tracking Module. For Tracking User Matches
    /// </summary>
    [LocalizedName(ModuleResourceNames.TrackingService)]
    public class TrackingService : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Untracks a User on the Guild.
        /// </summary>
        /// <param name="steamId">User to Untrack</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Untrack)]
        [LocalizedSummary(SummaryResourceNames.Untrack)]
        public async Task UnTrackTask(string steamId)
        {
            var steam = new SteamAPIHandler();
            DarkSide.Models.Steam.SteamConvertData steamProfile = steam.GetProfile(steamId);

            UserGuildRelation.UserGuildRelationDictionary.TryAdd(Context.User.Id, new Dictionary<ulong, List<long>>());
            Dictionary<ulong, List<long>> temp = UserGuildRelation.UserGuildRelationDictionary[Context.User.Id];
            temp.TryAdd(Context.Guild.Id, new List<long>());
            if (temp[Context.Guild.Id].Contains(steamProfile.Uid))
            {
                temp[Context.Guild.Id].Remove(steamProfile.Uid);
                TrackedAccounts.TrackDictionary.TryAdd(steamProfile.Uid, new List<SendData>());
                List<SendData> p = TrackedAccounts.TrackDictionary[steamProfile.Uid];
                p.RemoveAll(x => x.GuildId == Context.Guild.Id);
                UserGuildRelation.Save();
                TrackedAccounts.Save();
                await ReplyAsync(General.SUCCESSFULLY_REMOVED_FROM_TRACKING_LIST.GetFormattedString(new string[] { steamProfile.Name, steamId }));
            }
            else
            {
                await ReplyAsync(General.YOU_HAVE_NOT_TRACKED_USER.GetFormattedString(new string[] { steamProfile.Name, steamId }));
                UserGuildRelation.Save();
            }
        }

        /// <summary>
        /// Tracks a User on a Server
        /// </summary>
        /// <param name="steamId">User to Track</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Track)]
        [LocalizedSummary(SummaryResourceNames.Track)]
        public async Task TrackTask(string steamId)
        {
            var steam = new SteamAPIHandler();
            DarkSide.Models.Steam.SteamConvertData steamProfile = steam.GetProfile(steamId);
            var steam32 = steamProfile.Uid;

            if (!Context.User.IsPro())
            {
                if (UserGuildRelation.UserGuildRelationDictionary.ContainsKey(Context.User.Id))
                {
                    Dictionary<ulong, List<long>> temp = UserGuildRelation.UserGuildRelationDictionary[Context.User.Id];
                    temp.TryAdd(Context.Guild.Id, new List<long>());

                    foreach (KeyValuePair<ulong, List<long>> pair in temp)
                    {
                        if (pair.Key == Context.Guild.Id)
                        {
                            if (pair.Value.Any())
                            {
                                steamProfile = steam.GetProfile(pair.Value.First().ToString());
                                await ReplyAsync(General.ALREADY_TRACKING_USER_NO_PRO_STATUS.GetFormattedString(new string[] { steamProfile.Name, steamProfile.Uid.ToString() }));
                                return;
                            }

                            pair.Value.Add(steam32);
                            break;
                        }
                    }
                }
                else
                {
                    var temp = new Dictionary<ulong, List<long>> { { Context.Guild.Id, new List<long> { steam32 } } };
                    UserGuildRelation.UserGuildRelationDictionary.Add(Context.User.Id, temp);
                }
            }

            if (TrackedAccounts.TrackDictionary.ContainsKey(steam32))
            {
                List<SendData> temp = TrackedAccounts.TrackDictionary[steam32];
                foreach (SendData data in temp)
                {
                    if (data.GuildId != Context.Guild.Id)
                    {
                        continue;
                    }

                    await ReplyAsync(General.SOMEONE_ALREADY_TRACKING_IN_CHANNEL.GetFormattedString(new string[] { steamProfile.Name, steam32.ToString(), ((ITextChannel)Context.Client.GetChannel(data.ChannelId)).Mention }));
                    if (!Context.User.IsPro())
                        UserGuildRelation.UserGuildRelationDictionary[Context.User.Id][Context.Guild.Id].Remove(steam32);

                    UserGuildRelation.Save();
                    TrackedAccounts.Save();
                    return;
                }

                // Steam Account ain't be tracking in here
                temp.Add(new SendData
                {
                    ChannelId = Context.Channel.Id,
                    GuildId = Context.Guild.Id
                });

                TrackedAccounts.TrackDictionary[steam32] = temp;
            }
            else
            {
                var temp = new List<SendData>
                {
                    new SendData
                    {
                        GuildId = Context.Guild.Id,
                        ChannelId = Context.Channel.Id
                    }
                };
                TrackedAccounts.TrackDictionary.Add(steam32, temp);
            }

            TrackedAccounts.Save();
            UserGuildRelation.Save();
            await ReplyAsync($"{General.WILL_BE_POSTING_USER_MATCHES_EVERY_HOUR.GetFormattedString(new string[] { steamProfile.Name, steam32.ToString() })} {Emojis.Check}");
        }
    }
}
