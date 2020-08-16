namespace DarkSide.Models.Bot
{
    /// <summary>
    /// Model for sending data for Update Receivers and tracked accounts.
    /// </summary>
    public class SendData
    {
        /// <summary>
        /// Guild ID
        /// </summary>
        public ulong GuildId { get; set; }

        /// <summary>
        /// Channel ID
        /// </summary>
        public ulong ChannelId { get; set; }
    }
}
