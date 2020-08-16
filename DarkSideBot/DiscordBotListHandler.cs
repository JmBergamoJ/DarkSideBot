using Discord.WebSocket;
using DiscordBotsList.Api;
using System.Threading.Tasks;

namespace DarkSideBot
{
    /// <summary>
    /// Handler for DiscordBotList. Currently Unused.
    /// </summary>
    public class DiscordBotListHandler
    {
        private readonly AuthDiscordBotListApi _authDiscordBotListApi;
        private readonly DiscordSocketClient _client;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="botId">Bot ID within Discord Bot List</param>
        /// <param name="botDblToken">DiscordBotList Token</param>
        /// <param name="client">Discord Client.</param>
        public DiscordBotListHandler(ulong botId, string botDblToken, DiscordSocketClient client)
        {
            _authDiscordBotListApi = new AuthDiscordBotListApi(botId, botDblToken);
            _client = client;
        }

        /// <summary>
        /// Updates current Guild count on DBL.
        /// </summary>
        /// <returns></returns>
        public async Task UpdateAsync()
        {
            await _authDiscordBotListApi.GetMeAsync().Result.UpdateStatsAsync(_client.Guilds.Count);
        }
    }
}
