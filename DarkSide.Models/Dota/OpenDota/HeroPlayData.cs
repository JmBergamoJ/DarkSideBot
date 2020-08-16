using Newtonsoft.Json;

namespace DarkSide.Models.Dota.OpenDota
{
    /// <summary>
    /// Hero Play Data Model from OpenDota
    /// </summary>
    public class HeroPlayData
    {
        /// <summary>
        /// Hero ID
        /// </summary>
        [JsonProperty("hero_id")]
        public long HeroId { get; set; }

        /// <summary>
        /// Last time played - in seconds
        /// </summary>
        [JsonProperty("last_played")]
        public long LastPlayed { get; set; }

        /// <summary>
        /// Games with this Hero
        /// </summary>
        [JsonProperty("games")]
        public long Games { get; set; }

        /// <summary>
        /// Wins with this Hero
        /// </summary>
        [JsonProperty("win")]
        public long Win { get; set; }

        /// <summary>
        /// Games played with Hero in the same Team
        /// </summary>
        [JsonProperty("with_games")]
        public long WithGames { get; set; }

        /// <summary>
        /// Games won with Hero in the same Team
        /// </summary>
        [JsonProperty("with_win")]
        public long WithWin { get; set; }

        /// <summary>
        /// Games played with Hero in opposite Team
        /// </summary>
        [JsonProperty("against_games")]
        public long AgainstGames { get; set; }

        /// <summary>
        /// Games won with Hero in opposite Team
        /// </summary>
        [JsonProperty("against_win")]
        public long AgainstWin { get; set; }
    }
}
