using Discord.Commands;
using System;

namespace DarkSide.Utils.Attributes
{
    /// <summary>
    /// Marks the public name of a command, module, or parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class LocalizedNameAttribute : NameAttribute
    {
        /// <summary>
        /// Marks the public name of a command, module, or parameter with the provided name.
        /// </summary>
        /// <param name="provider">Localization Provider</param>
        /// <param name="key">The public name of the object.</param>     
        public LocalizedNameAttribute(string key) : base(Strings.Resources.Modules.Modules.ResourceManager.GetString(key))
        {
        }
    }
}
