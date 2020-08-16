using DarkSide.Strings.Resources.Summaries;
using Discord.Commands;
using System;

namespace DarkSideBot.Attributes
{
    /// <summary>
    /// Attribute for a Localized Summary String.
    /// </summary>
    public class LocalizedSummaryAttribute : SummaryAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ResourceManagerString">String Resource for Localization</param>
        public LocalizedSummaryAttribute(string ResourceManagerString) : base(Summaries.ResourceManager.GetString(ResourceManagerString)) { }
    }
}
