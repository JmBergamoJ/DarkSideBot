using DarkSide.Models.Bot;
using DarkSide.Models.Dota.OpenDota;
using DarkSide.OpenDota;
using DarkSide.Steam;
using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.Commands;
using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSide.Utils.Parsers.Dota;
using DarkSideBot.Attributes;
using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Dota Module for Profle Tracking, Team / Match Stats
    /// </summary>
    [LocalizedName(ModuleResourceNames.DotaStuff)]
    public class Dota : ModuleBase<SocketCommandContext>
    {
        /// <summary>
        /// Last Match command. Uses User Steam ID or Account ID parameter to get the User's Last Match.
        /// </summary>
        /// <param name="accountId">Account ID for Search</param>
        /// <returns>Data from last match or error message.</returns>
        [LocalizedCommand(CommandResourceNames.LastMatch)]
        [LocalizedSummary(SummaryResourceNames.LastMatch)]
        public async Task LasTask(string accountId = null)
        {
            if (accountId is null)
            {
                if (LinkedAccounts.UserDictionary.TryGetValue(Context.User.Id, out var longSteamId))
                {
                    accountId = $"[U:1:{longSteamId}]";
                }
                else
                {
                    await ReplyAsync(General.I_DONT_KNOW_YOU);
                    throw new ArgumentNullException(nameof(accountId));
                }
            }

            await ReplyAsync(LastMatch(accountId, out _));
        }

        /// <summary>
        /// Last Match command. Uses User Steam ID or Account ID parameter to get the User's Last Match.
        /// </summary>
        /// <param name="accountId">Account ID for Search</param>
        /// <param name="lastHour">If this match is from the last Hour. Used for broadcasting match to tracking users.</param>
        /// <returns>Data from last match or error message.</returns>
        public static string LastMatch(string accountId, out bool lastHour)
        {
            var OpenDota = new OpenDotaAPIHandler();
            var Steam = new SteamAPIHandler();
            DarkSide.Models.Steam.SteamConvertData steamProfile = Steam.GetProfile(accountId);
            System.Collections.Generic.List<RecentMatches> recentMatches = OpenDota.GetRecentMatches(steamProfile.Uid);
            if (!recentMatches.Any())
            {
                lastHour = false;
                return General.HAVE_NOT_PLAYED_DOTA_OR_PROFILE_PRIVATE;
            }

            RecentMatches last = recentMatches.First();
            var timeNow = DateTimeOffset.FromUnixTimeSeconds((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
            DateTimeOffset completedTime = DateTimeOffset.FromUnixTimeSeconds(last.StartTime).Add(TimeSpan.FromSeconds(last.Duration));
            var myTimeSpan = TimeSpan.FromMilliseconds(HourTimespan.Interval);
            TimeSpan difference = timeNow - completedTime;
            lastHour = difference < myTimeSpan;

            var final = General.MATCH_DATA_STRING.GetFormattedString(new string[] { steamProfile.Name, MatchDataGiver(last.MatchId) });
            return final;
        }

        /// <summary>
        /// Profile command. Uses User Steam ID or Account ID parameter to get the User's Profile.
        /// </summary>
        /// <param name="accountId">Account ID for Search</param>
        /// <returns>Profile Data or error message.</returns>
        [LocalizedCommand(CommandResourceNames.Profile, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Profile)]
        public async Task ProfileTask(string accountId = null)
        {
            if (accountId is null)
            {
                if (LinkedAccounts.UserDictionary.TryGetValue(Context.User.Id, out var longSteamId))
                {
                    accountId = $"[U:1:{longSteamId}]";
                }
                else
                {
                    await ReplyAsync(General.I_DONT_KNOW_YOU);
                    throw new ArgumentNullException(nameof(accountId));
                }
            }

            var openDota = new OpenDotaAPIHandler();
            var steam = new SteamAPIHandler();
            DarkSide.Models.Steam.SteamConvertData steamProfile = steam.GetProfile(accountId);
            PlayerProfile player = openDota.GetPlayerProfile(steamProfile.Uid);

            var embed = new EmbedBuilder();
            embed.WithAuthor(player.Profile.Personaname ?? General.UNKNOWN, player.Profile.Avatar, player.Profile.Profileurl);

            var openDotoUrl = $"https://www.opendota.com/players/{player.Profile.AccountId}";
            var dotaBuffUrl = $"https://www.dotabuff.com/players/{player.Profile.AccountId}";
            if (player.RankTier != null)
            {
                embed.AddField(General.MEDAL, ((int)(player.RankTier / 10)).ParseMedal() + " " + player.RankTier % 10, true);
            }

            dynamic winLose = openDota.GetWinLoss(steamProfile.Uid);
            dynamic win = winLose.win;
            dynamic lose = winLose.lose;
            embed.AddField(General.WIN_LOSS, $"{win}/{lose} ({win * 100 / (win + lose)}%)", true);

            System.Collections.Generic.List<HeroRankings> heroRankings = openDota.GetHeroRankings(steamProfile.Uid);

            var sorted = heroRankings.OrderByDescending(x => x.Score).Take(5).Aggregate(string.Empty, (current, rankings) => current + rankings.HeroId.HeroName() + $"{Environment.NewLine}");

            var file = File.ReadAllText("Resources\\Dota\\Medals.json");
            var medal = JObject.Parse(file);
            embed.ThumbnailUrl = (player.RankTier != null ? medal[(player.RankTier).ToString()].ToString() : string.Empty);

            System.Collections.Generic.List<RecentMatches> recentMatches = openDota.GetRecentMatches(steamProfile.Uid);

            if (!recentMatches.Any())
            {
                embed.AddField(string.Empty, General.NEVER_PLAYED_DOTA);
            }

            var time = DateTimeOffset.FromUnixTimeSeconds(recentMatches.First().StartTime);

            embed.AddField(General.LAST_PLAYED, General.LAST_PLAYED_STRING.GetFormattedString(time.DateTime.ToString()), true);
            embed.AddField(General.DETAILED_STATS, General.DETAILED_STATS_STRING.GetFormattedString(new string[] { openDotoUrl, Environment.NewLine, dotaBuffUrl }), true);
            embed.AddField(General.MOST_SUCCESS_HEROES, sorted, true);

            var r = new Random();
            embed.Color = new Color(r.Next(255), r.Next(255), r.Next(255));
            await ReplyAsync(string.Empty, false, embed.Build());
        }

        /// <summary>
        /// Match command. Searches for a Match with MatchID
        /// </summary>
        /// <param name="matchId">Match ID for Search</param>
        /// <returns>Match Data or error message.</returns>
        [LocalizedCommand(CommandResourceNames.Match, RunMode = RunMode.Async)]
        [LocalizedAlias(AliasResourceNames.Match)]
        [LocalizedSummary(SummaryResourceNames.Match)]
        public async Task MatchTask(long matchId)
        {
            var returnString = MatchDataGiver(matchId);
            await ReplyAsync(returnString);
        }

        /// <summary>
        /// Searches for a Match with MatchID
        /// </summary>
        /// <param name="matchId">Match ID for Search</param>
        /// <returns>Match Data or error message.</returns>
        private static string MatchDataGiver(long matchId)
        {
            var openDota = new OpenDotaAPIHandler();

            IndividualMatchData matchData = openDota.GetMatchData(matchId);
            string returnMessage;

            returnMessage = "```" +
                 General.PLAYER_NAME.PadRight(20) +
                 General.HERO_NAME.PadRight(20) +
                 General.KILLS.PadRight(7) +
                 General.DEATH.PadRight(7) +
                 General.ASSIST.PadRight(7) +
                 General.XPM.PadRight(6) +
                 General.GPM.PadRight(6) + Environment.NewLine;

            for (var i = 0; i < 73; i++)
                returnMessage += "_";

            returnMessage += Environment.NewLine;
            foreach (IndividualMatchDataPlayer dataPlayer in matchData.Players)
            {
                returnMessage += (dataPlayer.Personaname ?? General.UNKNOWN).Truncate(15).PadRight(20) +
                      dataPlayer.HeroId.HeroName().PadRight(20) +
                      dataPlayer.Kills.ToString().PadRight(7) +
                      dataPlayer.Deaths.ToString().PadRight(7) +
                      dataPlayer.Assists.ToString().PadRight(7) +
                      dataPlayer.XpPerMin.ToString().PadRight(6) +
                      dataPlayer.GoldPerMin.ToString().PadRight(6) +
                      Environment.NewLine;
            }

            returnMessage += "```";

            return returnMessage;
        }

        /// <summary>
        /// Recent Matches command. Uses User Steam ID or Account ID parameter to get the User's Last 10 Matches.
        /// </summary>
        /// <param name="accountId">Account ID for Search</param>
        /// <returns>Data from last 10 matches or error message.</returns>
        [LocalizedCommand(CommandResourceNames.RecentMatches, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.RecentMatches)]
        public async Task RecentMatchesTask(string accountId = null)
        {
            if (accountId is null)
            {
                if (LinkedAccounts.UserDictionary.TryGetValue(Context.User.Id, out var longSteamId))
                {
                    accountId = $"[U:1:{longSteamId}]";
                }
                else
                {
                    await ReplyAsync(General.I_DONT_KNOW_YOU);
                    throw new ArgumentNullException(nameof(accountId));
                }
            }

            var openDota = new OpenDotaAPIHandler();
            System.Collections.Generic.List<RecentMatches> recentMatches = openDota.GetRecentMatches(accountId);

            var returnMessage = $"```{General.HERO_NAME.PadRight(20, ' ') + General.KILLS.PadRight(8, ' ') + General.DEATH.PadRight(8, ' ') + General.ASSIST.PadRight(8, ' ') + General.XPM.PadRight(8, ' ') + General.GPM.PadRight(8, ' ') + General.MATCH_ID_STRING.PadRight(8, ' ')}";
            for (var i = 1; i <= 67; i++)
                returnMessage += "_";

            returnMessage += Environment.NewLine;
            foreach (RecentMatches match in recentMatches)
            {
                returnMessage += match.HeroId.HeroName().PadRight(20, ' ')
                      + match.Kills.ToString().PadRight(8, ' ')
                      + match.Deaths.ToString().PadRight(8, ' ')
                      + match.Assists.ToString().PadRight(8, ' ')
                      + match.XpPerMin.ToString().PadRight(8, ' ')
                      + match.GoldPerMin.ToString().PadRight(8, ' ')
                      + match.MatchId
                      + Environment.NewLine;
            }

            returnMessage += "```"; ;
            await ReplyAsync(returnMessage);
        }

        /// <summary>
        /// Top Teams Command. Searches for the top 15 Teams.
        /// </summary>
        /// <returns>Top 15 Teams</returns>
        [LocalizedCommand(CommandResourceNames.TopTeams, RunMode = RunMode.Async)]
        [LocalizedAlias(AliasResourceNames.TopTeams)]
        [LocalizedSummary(SummaryResourceNames.TopTeams)]
        public async Task ProTeamsTask()
        {
            var openDota = new OpenDotaAPIHandler();
            System.Collections.Generic.List<Teams> teams = openDota.GetTeams();
            System.Collections.Generic.IEnumerable<Teams> sorted = teams.OrderByDescending(x => x.Rating).Take(15);

            var returnMessage = $"```{General.TEAM_NAME.PadRight(20, ' ') + General.WINS.PadRight(10, ' ') + General.LOSSES.PadRight(10, ' ') + General.TEAM_ID_STRING}{Environment.NewLine}";
            for (var i = 0; i <= 50; i++)
                returnMessage += "_";

            returnMessage += Environment.NewLine;
            returnMessage = sorted.Aggregate(returnMessage, (current, team) => current + team.Name.PadRight(20, ' ') + team.Wins.ToString().PadRight(10, ' ') + team.Losses.ToString().PadRight(10, ' ') + team.TeamId + Environment.NewLine);
            returnMessage += "```";
            await ReplyAsync(returnMessage);
        }

        /// <summary>
        /// Hero Ranking Command. Uses User Steam ID or Account ID parameter to get the User's Best Heroes.
        /// </summary>
        /// <param name="accountId">Account ID for Search</param>
        /// <returns>Top 15 Heroes or error message</returns>
        [LocalizedCommand(CommandResourceNames.HeroRanking, RunMode = RunMode.Async)]
        [LocalizedAlias(AliasResourceNames.HeroRanking)]
        [LocalizedSummary(SummaryResourceNames.HeroRanking)]
        public async Task HeroRankingTask(string accountId = null)
        {
            if (accountId is null)
            {
                if (LinkedAccounts.UserDictionary.TryGetValue(Context.User.Id, out var longSteamId))
                {
                    accountId = $"[U:1:{longSteamId}]";
                }
                else
                {
                    await ReplyAsync(General.I_DONT_KNOW_YOU);
                    throw new ArgumentNullException(nameof(accountId));
                }
            }

            var steam = new SteamAPIHandler();
            var openDota = new OpenDotaAPIHandler();
            DarkSide.Models.Steam.SteamConvertData profile = steam.GetProfile(accountId);
            System.Collections.Generic.List<HeroRankings> heroRanking = openDota.GetHeroRankings(profile.Uid);
            System.Collections.Generic.IEnumerable<HeroRankings> sortedHeroRank = heroRanking.OrderByDescending(x => x.Score).Take(15);
            System.Collections.Generic.List<HeroPlayData> heroPlayData = openDota.GetHeroPlayData(profile.Uid);

            if (!heroPlayData.Any())
                return;

            var returnMessage = $"```{General.HERO_NAME.PadRight(20, ' ') + General.TOTAL.PadRight(10, ' ') + General.WINS.PadRight(10, ' ') + General.LOSSES.PadRight(10, ' ') + General.LAST_PLAYED}{Environment.NewLine}";
            for (var i = 1; i <= 70; i++)
                returnMessage += "_";

            returnMessage += Environment.NewLine;
            foreach (HeroRankings heroRankings in sortedHeroRank)
            {
                HeroPlayData heroData = heroPlayData.First(x => x.HeroId == heroRankings.HeroId);
                var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(heroData.LastPlayed).ToLocalTime();
                returnMessage += heroRankings.HeroId.HeroName().PadRight(20, ' ') +
                      heroData.Games.ToString().PadRight(10, ' ') +
                      heroData.Win.ToString().PadRight(10, ' ') +
                      (heroData.Games - heroData.Win).ToString().PadRight(10, ' ') +
                      dtDateTime + $"{Environment.NewLine}";
            }
            returnMessage += "```";

            await ReplyAsync(returnMessage);
        }

        /// <summary>
        /// Team Search Command. Searches for a team with it's ID or Name.
        /// </summary>
        /// <param name="queryOrTeamId">Query for Search. Team ID or Team Name</param>
        /// <returns>Team Data or Error Message</returns>
        [LocalizedCommand(CommandResourceNames.Team, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Team)]
        public async Task TeamSearchTask([LocalizedSummary(SummaryResourceNames.TeamNameOrID)] [Remainder]string queryOrTeamId)
        {
            Teams team = TeamSearch(queryOrTeamId);
            if (team != null)
            {
                var r = new Random();
                var embed = new EmbedBuilder
                {
                    ThumbnailUrl = team.LogoUrl.ToString(),
                    Color = new Color(r.Next(255), r.Next(255), r.Next(255))
                };
                embed.AddField(General.TEAM_NAME, team.Name);
                embed.AddField(General.WINS, team.Wins, true);
                embed.AddField(General.LOSSES, team.Losses, true);
                embed.AddField(General.LAST_MATCH, DateTimeOffset.FromUnixTimeSeconds(team.LastMatchTime).DateTime, true);
                embed.AddField(General.RATING, team.Rating, true);
                embed.AddField(General.PLAYERS, $"'{Config.Bot.PrefixDictionary[Context.Guild.Id]}{Commands.TEAM_PLAYERS} {queryOrTeamId.Replace("'", "\\'")}'", true);
                embed.AddField(General.MATCHES, $"'{Config.Bot.PrefixDictionary[Context.Guild.Id]}{Commands.TEAM_MATCHES} {queryOrTeamId}'", true);

                await ReplyAsync(string.Empty, embed: embed.Build());
            }
            else
                await ReplyAsync(General.COULD_NOT_FIND_TEAM);
        }

        private static Teams TeamSearch(string queryOrTeamId)
        {
            var openDota = new OpenDotaAPIHandler();
            Teams team = openDota.GetTeams().FirstOrDefault(t =>
            {
                return (t.TeamId == (long.TryParse(queryOrTeamId, out var res) ? res : long.MinValue)
                || t.Tag.Contains(queryOrTeamId, StringComparison.OrdinalIgnoreCase)
                || t.Name.Contains(queryOrTeamId, StringComparison.OrdinalIgnoreCase));
            });
            return team;
        }

        /// <summary>
        /// Pro Team Matches Command. Searches for the last 10 Matches of a Team.
        /// </summary>
        /// <param name="queryOrTeamId">Team Name or Team ID</param>
        /// <returns>Team Matches or Error Message</returns>
        [LocalizedCommand(CommandResourceNames.TeamMatches, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.TeamMatches)]
        public async Task ProTeamMatches([LocalizedSummary(SummaryResourceNames.TeamNameOrID)] [Remainder] string queryOrTeamId)
        {
            var openDota = new OpenDotaAPIHandler();
            Teams team = TeamSearch(queryOrTeamId);

            if (team is null)
            {
                await ReplyAsync(General.COULD_NOT_FIND_TEAM);
                return;
            }

            System.Collections.Generic.List<ProTeamMatch> teamMatches = openDota.GetTeamMatches(team.TeamId);
            var returnMessage = $"**{team.Name}**{Environment.NewLine}```{General.LEAGUE_NAME.PadRight(25) + General.VERSUS.PadRight(20) + General.STATUS.PadRight(8) + General.MATCH_ID_STRING.PadRight(15)}";
            returnMessage += Environment.NewLine + (returnMessage.Length - 3 - team.Name.Length).Times('_');

            returnMessage = teamMatches.Aggregate(returnMessage,
                (current, obj) =>
                    current + Environment.NewLine +
                    obj.LeagueName.Truncate(25).PadRight(25) +
                    obj.OpposingTeamName.Truncate(20).PadRight(20) +
                    (obj.RadiantWin == obj.Radiant ? General.WIN_PAST : General.LOSE_PAST).PadRight(8) +
                    obj.MatchId.ToString().PadRight(15));

            returnMessage += "```";
            await ReplyAsync(returnMessage);
        }

        /// <summary>
        /// Pro Team Players Command. Searches for the Players of a Pro Team.
        /// </summary>
        /// <param name="queryOrTeamId">Team Name or Team ID</param>
        /// <returns>Team Playeys Info or Error Message</returns>
        [LocalizedCommand(CommandResourceNames.TeamPlayers, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.TeamPlayers)]
        public async Task ProTeamPlayers([LocalizedSummary(SummaryResourceNames.TeamNameOrID)] [Remainder] string queryOrTeamId)
        {
            Teams team = TeamSearch(queryOrTeamId);
            if (team is null)
            {
                await ReplyAsync(General.COULD_NOT_FIND_TEAM);
                return;
            }

            var openDota = new OpenDotaAPIHandler();
            System.Collections.Generic.IEnumerable<ProTeamPlayers> teamPlayers = openDota.GetTeamPlayers(team.TeamId).Take(15);
            var returnMessage = $"**{team.Name}**{Environment.NewLine}```{General.TEAM_NAME.PadRight(20) + General.TOTAL.PadRight(17) + General.WINS.PadRight(12) + General.CURRENT_MEMBER}";
            returnMessage += Environment.NewLine + (returnMessage.Length - 3 - team.Name.Length).Times('_');

            returnMessage = teamPlayers.OrderBy(x => x.IsCurrentTeamMember == false).Aggregate(returnMessage,
                (current, obj) => current + $"{Environment.NewLine}" + (obj.Name ?? General.UNKNOWN).PadRight(20) + obj.GamesPlayed.ToString().PadRight(17) +
                                  obj.Wins.ToString().PadRight(12) +
                                  (obj.IsCurrentTeamMember ?? false ? General.YES : General.NO));

            returnMessage += "```";
            await ReplyAsync(returnMessage);
        }
    }
}
