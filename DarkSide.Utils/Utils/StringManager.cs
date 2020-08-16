using System;

namespace DarkSide.Utils.Utils
{
    public static class StringManager
    {
        public static string GetFormattedString(this string message, string[] stringParams)
        {
            return string.Format(message, stringParams);
        }

        public static string GetFormattedString(this string message, string stringParam)
        {
            return GetFormattedString(message, new string[] { stringParam });
        }

        public static string[] GetStringAsArray(this string value, char separator)
        {
            return value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
