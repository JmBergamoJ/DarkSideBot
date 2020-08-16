namespace DarkSide.OpenDota
{
    public static class OpenDotaUrls
    {

        private const string BASE_URL = "https://api.opendota.com";
        private const string API_I = "api";
        private const string PLAYERS_C = "players";
        private const string MATCHES_C = "matches";
        private const string TEAMS_C = "teams";
        private const string RECENT_MATCHES_E = "recentMatches";
        private const string RANKINGS_E = "rankings";
        private const string WINLOSS_E = "wl";
        private const string HEROES_E = "heroes";
        private static readonly string PLAYERS_URL = $@"{BASE_URL}/{API_I}/{PLAYERS_C}";
        private static readonly string MATCHES_URL = $@"{BASE_URL}/{API_I}/{MATCHES_C}";
        private static readonly string TEAMS_URL = $"{BASE_URL}/{API_I}/{TEAMS_C}";

        public static string RecentMatches(long userID) => $@"{PLAYERS_URL}/{userID}/{RECENT_MATCHES_E}";

        public static string PlayerProfile(long userID) => $"{PLAYERS_URL}/{userID}";

        public static string HeroRankings(long userID) => $"{PLAYERS_URL}/{userID}/{RANKINGS_E}";

        public static string MatchData(long matchID) => $"{MATCHES_URL}/{matchID}";

        public static string WinLoss(long userID) => $"{PLAYERS_URL}/{userID}/{WINLOSS_E}";

        public static string Teams() => TEAMS_URL;

        public static string TeamMatches(long TeamID) => $"{TEAMS_URL}/{TeamID}/{MATCHES_C}";

        public static string HeroPlayData(long userID) => Heroes(userID);

        public static string TeamPlayers(long TeamID) => $"{TEAMS_URL}/{TeamID}/{PLAYERS_C}";

        public static string Heroes(long userID) => $"{PLAYERS_URL}/{userID}/{HEROES_E}";
    }
}
