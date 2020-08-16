using DarkSide.Models.Bot;
using DarkSideBot.Modules;
using Discord;
using Discord.WebSocket;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace DarkSideBot
{
    internal class Program
    {
        private static DiscordSocketClient _client;
        private SuperHandler _handler;

        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

            HourTimespan.Interval = 60 * 60 * 1000;
            var timer = new System.Timers.Timer(HourTimespan.Interval) { Enabled = true };
            timer.Elapsed += Timer_Elapsed;

            new Program().StartAsync().GetAwaiter().GetResult();
        }

        private static async void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(e.ToString());
            Console.ResetColor();

            if (_client.GetGuild(480857253092524032).GetChannel(495978647635623937) is ITextChannel important)
            {
                await important.SendMessageAsync(e.ToString());
            }
        }

        private static async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                foreach (System.Collections.Generic.KeyValuePair<long, System.Collections.Generic.List<SendData>> pair in TrackedAccounts.TrackDictionary)
                {
                    var final = Dota.LastMatch($"[U:1:{pair.Key}]", out var lastHour);
                    if (pair.Value is null || !lastHour)
                    {
                        continue;
                    }

                    foreach (SendData data in pair.Value)
                    {
                        if (!(_client.GetGuild(data.GuildId)?.GetChannel(data.ChannelId) is ITextChannel myChannel))
                        {
                            continue;
                        }

                        await myChannel.SendMessageAsync(final);
                    }
                }
            }
            catch (Exception g)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(g);
                Console.ResetColor();
            }
        }

        private async Task StartAsync()
        {

            var locale = new CultureInfo(Config.Bot.Locale ?? "en-US");

            Thread.CurrentThread.CurrentCulture = locale;
            Thread.CurrentThread.CurrentUICulture = locale;
            var botToken = Config.Bot.Token;

            if (string.IsNullOrEmpty(botToken))
            {
                Console.WriteLine("No Token detected.");
                return;
            }

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _handler = new SuperHandler(_client);
            await _handler.InitializeAsync();

            await _client.LoginAsync(TokenType.Bot, botToken);
            await _client.StartAsync();
            await _client.SetGameAsync("Music", null, ActivityType.Playing);
            await ConsoleRead();
            await Task.Delay(-1);
        }

        private async Task ConsoleRead()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                if (input.ToLower() == "announce")
                {
                    Console.WriteLine("What do you want to send?");
                    var what = Console.ReadLine();
                    foreach (SocketGuild clientGuild in _client.Guilds)
                    {
                        try
                        {
                            await clientGuild.DefaultChannel.SendMessageAsync(what);
                            Console.WriteLine(
                                $"Sent to {clientGuild.Name}@{clientGuild.DefaultChannel.Name} successfully.");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Could not send to {clientGuild.Name}.");
                        }
                    }
                }
                else if (input.ToLower() == "dm")
                {
                    for (var i = 0; i < _client.Guilds.Count; i++)
                    {
                        Console.WriteLine(i + 1 + _client.Guilds.ElementAt(i).Name);
                    }

                    var to = int.Parse(Console.ReadLine());
                    SocketGuild guild = _client.Guilds.ElementAt(to - 1);
                    Console.WriteLine($"{guild.Name}'s channel ID please: ");
                    var id = ulong.Parse(Console.ReadLine());
                    SocketTextChannel chanel = guild.GetTextChannel(id);
                    Console.WriteLine("What do u want to send");
                    var text = Console.ReadLine();
                    await chanel.SendMessageAsync(text);
                }

                await Task.CompletedTask;
            }

            // ReSharper disable once FunctionNeverReturns
        }
    }
}