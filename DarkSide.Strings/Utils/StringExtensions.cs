using System;

namespace DarkSide.Strings.Utils
{
    public static class StringExtensions
    {
        public static string GetFormattedString(this string message, string[] stringParams) => string.Format(message, stringParams);

        public static string GetFormattedString(this string message, string stringParam) => GetFormattedString(message, new string[] { stringParam });

        public static string[] GetAsStringArray(this string value, char separator) => value.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
    }
}
