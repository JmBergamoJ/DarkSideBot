using System;

namespace DarkSide.Utils.Parsers.Dota
{
    public static class RankParser
    {
        public static Rank ParseMedal(this int id)
        {
            if (Enum.IsDefined(typeof(Rank), id - 1))
            {
                return (Rank)(id - 1);
            }
            else
            {
                return Rank.Unknown;
            }
        }
    }

    public enum Rank
    {
        Unknown,
        Herald,
        Guardian,
        Crusader,
        Archon,
        Legend,
        Ancient,
        Divine,
        Immortal
    }
}
