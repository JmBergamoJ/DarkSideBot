using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace DarkSideBot.Preconditions
{
    public class InVoiceChannel : PreconditionAttribute
    {
        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            return Task.FromResult((context.User as IGuildUser)?.VoiceChannel is null
                ? PreconditionResult.FromError("You must be in a voice channel before invoking this command")
                : PreconditionResult.FromSuccess());
        }
    }
}
