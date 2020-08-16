using NeoSmart.Unicode;
using System.Linq;

namespace DarkSide.Strings
{
    public static class Emojis
    {
        public static string BallotBoxWithCheck => Emoji.BallotBoxWithCheck.ToString();
        public static string NoEntry => Emoji.NoEntry.ToString();
        public static string Check => Emoji.HeavyCheckMark.ToString();
        public static string Hourglass => Emoji.Hourglass.ToString();
        public static string PointRight => Emoji.BackhandIndexPointingRight.ToString();
        public static string ConfettiBall => Emoji.ConfettiBall.ToString();
        public static string ThinkingFace => Emoji.ConfusedFace.ToString();
        public static string RestInPeace => Emoji.Coffin.ToString();
        public static string SmilingFace => Emoji.SmilingFace.ToString();
        public static string FrowningFace => Emoji.FrowningFace.ToString();
        public static string ManFrowning => Emoji.PersonFrowning.ToString();
        public static string ArrowForward => Emoji.RightArrow.ToString();

        public static string GetEmoji(string EmojiName) => Emoji.All.FirstOrDefault(e => e.Name.ToUpper() == EmojiName.Trim().ToUpper()).ToString();
    }
}
