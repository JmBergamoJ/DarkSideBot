using System;

namespace DarkSideBot.DataTypes
{
    internal static class RankParser
    {
        public static Rank ParseMedal(this int id)
        {
            if (Enum.IsDefined(typeof(Rank), id - 1))
                return (Rank)(id - 1);
            else
                return Rank.Unknown;
        }
    }

    internal enum Rank
    {
        Herald,
        Guardian,
        Crusader,
        Archon,
        Legend,
        Ancient,
        Divine,
        Immortal,
        Unknown
    }
}
