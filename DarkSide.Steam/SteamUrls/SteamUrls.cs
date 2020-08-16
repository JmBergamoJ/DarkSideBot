namespace DarkSide.Steam.SteamUrls
{
    public static class SteamUrls
    {
        private static readonly string BASE_URL = "https://steamid.venner.io";
        private static readonly string RAW_M = "raw.php";
        private static readonly string INPUT_P = "input";

        public static string QueryUser(string query) => $"{BASE_URL}/{RAW_M}?{INPUT_P}={query}";
    }
}
