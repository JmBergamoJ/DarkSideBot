using Newtonsoft.Json;

namespace DarkSide.Models.Dota.OpenDota
{
    /// <summary>
    /// Hero Ranking Data Model from OpenDota
    /// </summary>
    public class HeroRankings
    {
        /// <summary>
        /// Hero ID
        /// </summary>
        [JsonProperty("hero_id")]
        public long HeroId { get; set; }

        /// <summary>
        /// Hero Score
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }

        /// <summary>
        /// Hero Rank Percentage 
        /// </summary>
        [JsonProperty("percent_rank")]
        public double PercentRank { get; set; }

        /// <summary>
        /// Hero Card
        /// </summary>
        [JsonProperty("card")]
        public long Card { get; set; }
    }
}
