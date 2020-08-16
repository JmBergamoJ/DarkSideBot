using SharpLink;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DarkSideBot
{
    /// <summary>
    /// Queue Manager for Lavalink.
    /// </summary>
    public static class QueueManager
    {
        private static readonly Dictionary<ulong, Queue<LavalinkTrack>> Queue = new Dictionary<ulong, Queue<LavalinkTrack>>();

        /// <summary>
        /// Adds a track to the Queue
        /// </summary>
        /// <param name="guildId">Guild ID</param>
        /// <param name="track">Track to Add</param>
        /// <returns></returns>
        public static string PushTrack(this ulong guildId, LavalinkTrack track)
        {
            Queue.TryAdd(guildId, new Queue<LavalinkTrack>());
            Queue[guildId].Enqueue(track);
            return "Successfully added to queue.";
        }

        /// <summary>
        /// Removes a Track from a Queue
        /// </summary>
        /// <param name="guildId">Guild ID</param>
        /// <returns></returns>
        public static LavalinkTrack PopTrack(this ulong guildId)
        {
            Queue.TryAdd(guildId, new Queue<LavalinkTrack>());
            if (!Queue[guildId].Any())
                throw new InvalidOperationException("Queue empty");

            return Queue[guildId].Dequeue();
        }

        /// <summary>
        /// Clears a Queue for a Guild.
        /// </summary>
        /// <param name="guildId">Guild ID</param>
        public static void PopAll(this ulong guildId)
        {
            Queue.TryAdd(guildId, new Queue<LavalinkTrack>());
            Queue[guildId].Clear();
        }

        /// <summary>
        /// Gets the current playlist for the Guild
        /// </summary>
        /// <param name="guildId">Guild ID</param>
        /// <returns></returns>
        public static List<LavalinkTrack> PlayList(this ulong guildId)
        {
            Queue.TryAdd(guildId, new Queue<LavalinkTrack>());
            return Queue[guildId].ToList();
        }
    }
}
