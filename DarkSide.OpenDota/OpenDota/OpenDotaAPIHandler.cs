using DarkSide.Models.Dota.OpenDota;
using DarkSide.Steam;
using DarkSide.Web.Base.WebClientBase;
using System.Collections.Generic;

namespace DarkSide.OpenDota
{
    public class OpenDotaAPIHandler : DarkSideWebClientHandler
    {
        public List<RecentMatches> GetRecentMatches(long userID) => Get<List<RecentMatches>>(OpenDotaUrls.RecentMatches(userID));
        public List<RecentMatches> GetRecentMatches(string userID)
        {
            Models.Steam.SteamConvertData steamProfile = new SteamAPIHandler().GetProfile(userID);
            return GetRecentMatches(steamProfile.Uid);
        }

        public IndividualMatchData GetMatchData(long matchID) => Get<IndividualMatchData>(OpenDotaUrls.MatchData(matchID), Converter.Settings);

        public PlayerProfile GetPlayerProfile(long userID) => Get<PlayerProfile>(OpenDotaUrls.PlayerProfile(userID));
        public PlayerProfile GetPlayerProfile(string userID)
        {
            Models.Steam.SteamConvertData steamProfile = new SteamAPIHandler().GetProfile(userID);
            return GetPlayerProfile(steamProfile.Uid);
        }

        public List<HeroRankings> GetHeroRankings(long userID) => Get<List<HeroRankings>>(OpenDotaUrls.HeroRankings(userID));

        public List<Teams> GetTeams() => Get<List<Teams>>(OpenDotaUrls.Teams());

        public dynamic GetWinLoss(long UserID) => Get<dynamic>(OpenDotaUrls.WinLoss(UserID));

        public List<HeroPlayData> GetHeroPlayData(long UserID) => Get<List<HeroPlayData>>(OpenDotaUrls.HeroPlayData(UserID));

        public List<ProTeamMatch> GetTeamMatches(long TeamID) => Get<List<ProTeamMatch>>(OpenDotaUrls.TeamMatches(TeamID));

        public List<ProTeamPlayers> GetTeamPlayers(long TeamID) => Get<List<ProTeamPlayers>>(OpenDotaUrls.TeamPlayers(TeamID));
    }
}
