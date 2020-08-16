using DarkSide.Strings.Utils;
using Discord.Commands;

namespace DarkSideBot.Attributes
{
    public class LocalizedAliasAttribute : AliasAttribute
    {
        public LocalizedAliasAttribute(string AliasResourceName) : base(DarkSide.Strings.Resources.Aliases.Aliases.ResourceManager.GetString(AliasResourceName).GetAsStringArray(';'))
        {
        }
    }
}
