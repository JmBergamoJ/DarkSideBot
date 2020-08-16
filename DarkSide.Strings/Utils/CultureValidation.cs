using System.Globalization;

namespace DarkSide.Strings.Utils
{
    public class CultureValidation
    {
        public static bool IsValidCultureName(string cultureName)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo culture in cultures)
            {
                if (culture.Name.ToUpper() == cultureName.ToUpper())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
