using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using SharpLink;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DarkSideBot
{
    /// <summary>
    /// Handles everything related to Client and Commands
    /// </summary>
    internal class SuperHandler
    {
        private readonly DiscordSocketClient _client;
        private CommandService _command;
        private IServiceProvider _services;
        private readonly DiscordBotListHandler _discordBotListHandler;
        private LavalinkManager _lavalinkManager;

        public SuperHandler(DiscordSocketClient client) => _client = client;

        public async Task InitializeAsync()
        {
            _command = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _lavalinkManager = new LavalinkManager(_client, new LavalinkManagerConfig
            {
                WebSocketHost = "localhost",
                WebSocketPort = 2333,
                RESTHost = "localhost",
                RESTPort = 2333,
                Authorization = "youshallnotpass",
                TotalShards = 1,
                LogSeverity = LogSeverity.Verbose,
            });

            //_discordBotListHandler = new DiscordBotListHandler(/*your channel ID*/, Config.Bot.DblToken, _client);

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_command)
                .AddSingleton<InteractiveService>()
                .AddSingleton(_lavalinkManager)
                .BuildServiceProvider();

            await _command.AddModulesAsync(Assembly.GetEntryAssembly(), _services);

            _client.Ready += Ready;
            _client.MessageReceived += HandleCommandAsync;
            _client.JoinedGuild += JoinAsync;
            //_client.LeftGuild += LeftAsync;
            _client.Log += Log;
            _lavalinkManager.Log += Log;
            _lavalinkManager.TrackEnd += TrackEnd;

        }

        private async Task TrackEnd(LavalinkPlayer player, LavalinkTrack track, string type)
        {
            if (type == "STOPPED")
            {
                return;
            }

            try
            {
                if (player.VoiceChannel.Guild.Id.PlayList().Any())
                {
                    await _client.GetGuild(player.VoiceChannel.Guild.Id).DefaultChannel.SendMessageAsync($"{General.NOW_PLAYING} - {player.VoiceChannel.Guild.Id.PlayList()[0].Title}");
                }
                await player.PlayAsync(player.VoiceChannel.Guild.Id.PopTrack());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private Task Log(LogMessage log)
        {
            Console.WriteLine(log);
            return Task.CompletedTask;
        }

        private async Task Ready() => await _lavalinkManager.StartAsync();//await _discordBotListHandler.UpdateAsync();

        //private async Task LeftAsync(SocketGuild Guild)
        //{
        //    //await _discordBotListHandler.UpdateAsync();
        //    if (!(_client.GetGuild(/*Some Management Guild*/).GetChannel(/*Some Management Channel*/) is ITextChannel channel)) 
        //        return;
        //    await channel.SendMessageAsync($"I just left {Guild.Name}");
        //}

        private async Task JoinAsync(SocketGuild arg)
        {
            //await _discordBotListHandler.UpdateAsync();
            //if (!(_client.GetGuild(/*Some Management Guild*/).GetChannel(/*Some Management Channel*/) is ITextChannel channel))
            //    return;

            #region Prefix Management
            if (!Config.Bot.PrefixDictionary.ContainsKey(arg.Id))
            {
                Config.Bot.PrefixDictionary.Add(arg.Id, "$");
                await Task.Run(Config.Save);
            }
            #endregion

            //await channel.SendMessageAsync($"I just joined {arg.Name}");
        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            if (!(s is SocketUserMessage msg))
            {
                return;
            }

            var context = new SocketCommandContext(_client, msg);
            var argPos = 0;

            #region Dota Update

            //var embed = s.Embeds.FirstOrDefault();
            //if (s.Channel.Id == 437635625567649804 && s.Author.IsWebhook)
            //{
            //    if (embed?.Author?.Name.StartsWith("Dota") == true)
            //    {
            //        await BroadcastUpdate(embed);
            //    }
            //}

            #endregion

            if (s.Author.IsBot)
            {
                return;
            }

            #region Command Management
            if (msg.HasStringPrefix(Config.Bot.PrefixDictionary[context.Guild.Id], ref argPos) ||
                msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                using (context.Channel.EnterTypingState())
                {
                    try
                    {
                        IResult result = await _command.ExecuteAsync(context, argPos, _services);
                        if (!result.IsSuccess)
                        {
                            Console.WriteLine(result.ErrorReason + $" at {context.Guild.Name}");
                            switch (result.Error)
                            {
                                case CommandError.UnknownCommand:
                                    {
                                        //Emote guildEmote = Emote.Parse(Emojis.NoEntry);
                                        //await msg.AddReactionAsync(guildEmote);
                                        break;
                                    }
                                case CommandError.BadArgCount:
                                    {
                                        await context.Channel.SendMessageAsync(General.BAD_ARGUMENT_MESSAGE);
                                        break;
                                    }
                                case CommandError.UnmetPrecondition:
                                    {
                                        await context.Channel.SendMessageAsync(General.UNMET_PRECONDITION_MESSAGE.GetFormattedString(result.ErrorReason));
                                        break;
                                    }
                                default:
                                    {
                                        await context.Channel.SendMessageAsync(result.Error.ToString());
                                        break;
                                    }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();
                    }
                }
            }
            #endregion
        }

        private async Task BroadcastUpdate(Embed embed)
        {
            foreach (DarkSide.Models.Bot.SendData data in UpdateReceivers.Patches)
            {
                await _client.GetGuild(data.GuildId).GetTextChannel(data.ChannelId).SendMessageAsync(embed: embed);
            }
        }
    }
}
