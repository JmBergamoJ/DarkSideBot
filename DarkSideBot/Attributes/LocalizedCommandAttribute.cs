using DarkSide.Strings.Resources.Commands;
using Discord.Commands;

namespace DarkSideBot.Attributes
{
    public class LocalizedCommandAttribute : CommandAttribute
    {
        public LocalizedCommandAttribute(string ResourceString) : base(Commands.ResourceManager.GetString(ResourceString))
        {
        }
    }
}
