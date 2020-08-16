using DarkSide.Strings;
using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.Commands;
using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using Discord;
using Discord.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Help Module. for information on other Modules and Commands.
    /// </summary>
    [LocalizedName(ModuleResourceNames.Help)]
    public class Help : ModuleBase
    {
        private readonly CommandService _commands;

        /// <summary>
        /// Default Ctor.
        /// </summary>
        /// <param name="service">Command Service for injection</param>
        public Help(CommandService service) => _commands = service;

        /// <summary>
        /// Help Commands. goes through modules and lists commands. Gets help on Modules or Commands if specified
        /// </summary>
        /// <param name="commandOrModule">Module or Command for help.</param>
        /// <returns>Replies with help on modules / commands or error message.</returns>
        [LocalizedCommand(CommandResourceNames.Help, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Help)]
        public async Task HelpAsync([Remainder] string commandOrModule = null)
        {
            if (commandOrModule != null)
            {
                await DetailedHelpAsync(commandOrModule.ToLower());
                return;
            }

            var builder = new EmbedBuilder();
            {
                builder.WithColor(new Color(87, 222, 127));
                builder.WithTitle(General.COMMAND_LIST_GREETING.GetFormattedString(Context.User.Username));
                builder.WithFooter(f => f.WithText(General.COMMAND_LIST_HELP_STRING));
            }

            //Loop Through every module
            foreach (ModuleInfo module in _commands.Modules.OrderBy(x => x.Name))
            {
                string fieldValue = null;

                // Looping through every command in the module
                foreach (CommandInfo cmd in module.Commands.OrderBy(x => x.Name))
                {
                    // Basic report to log missed summaries
                    if (string.IsNullOrWhiteSpace(cmd.Summary))
                        Console.WriteLine(General.NO_SUMMARY.GetFormattedString(cmd.Name));

                    if (!module.Name.ToLower().Equals(Commands.HELP) && !module.Name.ToLower().Equals(Commands.PING))
                    {
                        PreconditionResult result = await cmd.CheckPreconditionsAsync(Context);
                        if (result.IsSuccess)
                            fieldValue += $"'{cmd.Aliases.First()}', ";
                    }
                }

                if (string.IsNullOrWhiteSpace(fieldValue))
                    continue;

                // FieldValue could be empty when the precondition is false.
                fieldValue = fieldValue[0..^2];
                builder.AddField(
                    x =>
                    {
                        x.Name = $"{Environment.NewLine}{Emojis.ArrowForward} {module.Name}";
                        x.Value = $"{fieldValue}";
                        x.IsInline = false;
                    });
            }

            await ReplyAsync(string.Empty, false, builder.Build());
            await ReplyAsync(string.Empty, false, new EmbedBuilder
            {
                Description = General.CREATOR_SUPPORT_STRING
            }.Build());
        }

        /// <summary>
        /// Gets detailed help on a command
        /// </summary>
        /// <param name="command">Command to get help</param>
        /// <returns>Command help Info or error message</returns>
        private async Task DetailedHelpAsync([Remainder] string command)
        {
            var moduleFound = _commands.Modules.Select(mod => mod.Name.ToLower()).ToList().Contains(command);
            if (moduleFound)
            {
                await DetailedModuleHelpAsync(command);
                return;
            }

            // 'command' isn't a module. Now checking if it is a command
            SearchResult result = _commands.Search(Context, command);
            if (!result.IsSuccess)
            {
                await ReplyAsync($"{General.COULD_NOT_FIND_COMMAND.GetFormattedString(command)} {Emojis.NoEntry}");
                return;
            }

            var builder = new EmbedBuilder
            {
                Color = new Color(87, 222, 127)
            };

            foreach (CommandInfo cmd in result.Commands.Select(match => match.Command))
            {
                builder.AddField(
                    x =>
                    {
                        x.Name = General.HELP_ON_COMMAND.GetFormattedString(command);
                        var temp = General.NONE_STRING;
                        if (cmd.Aliases.Count != 1)
                        {
                            temp = string.Join(", ", cmd.Aliases);
                        }

                        x.Value = $"**{General.ALIASES}**: {temp}";
                        temp = "```" + Config.Bot.PrefixDictionary[Context.Guild.Id] + command;
                        if (cmd.Parameters.Count != 0)
                        {
                            temp += " " + string.Join(
                                        " ",
                                        cmd.Parameters.Select(
                                            p => p.IsOptional
                                                ? "<" + (p.Summary?.Length > 1 ? p.Summary ?? string.Empty : p.Name) + ">"
                                                : "[" + (p.Summary?.Length > 1 ? p.Summary ?? string.Empty : p.Name) + "]"));
                        }

                        temp += "```";
                        x.Value += $"{Environment.NewLine}**{General.USAGE_STRING}**: {temp}{Environment.NewLine}**{General.SUMMARY}**: {cmd.Summary}";

                        x.IsInline = false;
                    });
            }

            builder.WithFooter(General.DETAILED_HELP_FOOTER);

            await ReplyAsync(string.Empty, false, builder.Build());
        }

        /// <summary>
        /// Gets detailed help on a Module
        /// </summary>
        /// <param name="module">Module to get help</param>
        /// <returns>Module help Info or error message</returns>
        private async Task DetailedModuleHelpAsync(string module)
        {
            ModuleInfo first = _commands.Modules.First(mod => mod.Name.ToLower() == module);
            var embed = new EmbedBuilder
            {
                Title = General.COMMANDS_UNDER_MODULE.GetFormattedString(module.ToUpper()),
                Description = string.Empty,
                Color = new Color(87, 222, 127)
            };
            embed.WithFooter(General.COMMAND_LIST_HELP_STRING);
            foreach (CommandInfo cmds in first.Commands)
                embed.Description += $"{cmds.Name}, ";

            embed.Description = embed.Description[0..^2];
            await ReplyAsync(string.Empty, false, embed.Build());
        }
    }
}
