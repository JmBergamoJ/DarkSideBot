using DarkSide.Models.Steam;
using DarkSide.Web.Base.WebClientBase;

namespace DarkSide.Steam
{
    public class SteamAPIHandler : DarkSideWebClientHandler
    {
        public SteamConvertData GetProfile(string query) => Get<SteamConvertData>(SteamUrls.SteamUrls.QueryUser(query));
    }
}
