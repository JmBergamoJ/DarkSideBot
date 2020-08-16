using DarkSide.Strings;
using DarkSide.Strings.ResourceNames;
using DarkSide.Strings.Resources.Commands;
using DarkSide.Strings.Resources.General;
using DarkSide.Strings.Utils;
using DarkSide.Utils.Attributes;
using DarkSideBot.Attributes;
using DarkSideBot.Preconditions;
using Discord;
using Discord.Addons.Interactive;
using Discord.Commands;
using SharpLink;
using SharpLink.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSideBot.Modules
{
    /// <summary>
    /// Music Module. Commands for Music Streaming on voice channel.
    /// </summary>
    [InVoiceChannel, LocalizedName(ModuleResourceNames.Music)]
    public class Music : InteractiveBase
    {
        private readonly LavalinkManager _lavalinkManager;

        /// <summary>
        /// Public ctor
        /// </summary>
        /// <param name="lavalinkManager">The Lavaling Manager for Injection</param>
        public Music(LavalinkManager lavalinkManager) => _lavalinkManager = lavalinkManager;

        /// <summary>
        /// Seek Command. Seeks a time on a song currently playing.
        /// </summary>
        /// <param name="position">Position in the song in seconds</param>
        /// <returns>Replies with track change to time set or error message.</returns>
        [LocalizedCommand(CommandResourceNames.Seek)]
        [LocalizedSummary(SummaryResourceNames.Seek)]
        public async Task SeekTask(int position)
        {
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ??
                         await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            Console.WriteLine(
                $"{General.TRACK_IS_SEEKABLE}: {player.CurrentTrack.IsSeekable}{Environment.NewLine}" +
                $"{General.NOW_AT}: {TimeSpan.FromMilliseconds(player.CurrentPosition)}" +
                $"/{TimeSpan.FromMilliseconds(player.CurrentTrack.Length.Milliseconds)}");
            if (player.CurrentTrack.IsSeekable)
            {
                await player.SeekAsync(position * 1000);
                await ReplyAsync(Emojis.BallotBoxWithCheck);
            }
            else
                await ReplyAndDeleteAsync($"{Emojis.NoEntry} {General.CANNOT_SEEK_TRACK}");
        }

        /// <summary>
        /// Volume command. Sets the streaming volume for channel
        /// </summary>
        /// <param name="value">Value between 0 - 150</param>
        /// <returns>Volume change or current volume</returns>
        [LocalizedCommand(CommandResourceNames.Volume, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Volume)]
        public async Task VolumeTask(uint value = 98450)
        {
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            if (value == 98450)
                return;

            await player.SetVolumeAsync(value);
            await ReplyAsync($"{General.VOLUME_NOW_SET} {value}/150");
        }

        /// <summary>
        /// Pause Command. Pauses the current song. can be Resumed After.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Pause, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Pause)]
        public async Task PauseTask()
        {
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            await player.PauseAsync();
            await ReplyAsync(General.TRACK_PAUSED);
        }

        /// <summary>
        /// Resume Command. Resumes a previously paused track.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Resume, RunMode = RunMode.Async)]
        [LocalizedAlias(AliasResourceNames.Resume)]
        [LocalizedSummary(SummaryResourceNames.Resume)]
        public async Task ResumeTask()
        {
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            if (player.Playing)
                await ReplyAsync($"{General.TRACK_ALTREADY_PLAYING} " + player.CurrentTrack.Title);
            else
            {
                await player.ResumeAsync();
                await ReplyAsync($"{General.TRACK_RESUMED} {player.CurrentTrack.Title}");
            }
        }

        /// <summary>
        /// Now Playing command. Show the currently playing song.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.NowPlaying, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.NowPlaying)]
        public async Task NowPlayingTask()
        {
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            System.Collections.Generic.List<LavalinkTrack> playList = Context.Guild.Id.PlayList();
            var returnString = $"{General.NOW_PLAYING}: {player.CurrentTrack.Title}";
            if (playList.Any())
                returnString += $"{Environment.NewLine}{General.UP_NEXT}: {playList[0].Title}";

            Embed build = new EmbedBuilder
            {
                Title = General.NOW_PLAYING,
                Description = returnString,
                Color = new Color(213, 0, 249)
            }.Build();
            await ReplyAsync(string.Empty, false, build);
        }

        /// <summary>
        /// Clear Command. Clears the Current Queue.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Clear)]
        [LocalizedSummary(SummaryResourceNames.Clear)]
        public async Task ClearTask()
        {
            Context.Guild.Id.PopAll();
            await ReplyAsync(General.QUEUE_CLEARED);
        }

        /// <summary>
        /// Stops the Current Track.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Stop, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Stop)]
        public async Task StopTask()
        {
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            await player.StopAsync();
            await ReplyAsync($"{Emojis.Check} {General.TRACK_STOPPED_PLAYING.GetFormattedString(Commands.HELP)}");
        }

        /// <summary>
        /// Disconnect command. Makes the bot leave the voice channel. Useful for fixing any streaming problems.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Disconnect, RunMode = RunMode.Async)]
        public async Task LeaveTask()
        {
            if (_lavalinkManager.GetPlayer(Context.Guild.Id).Playing)
                await StopTask();

            await _lavalinkManager.LeaveAsync(Context.Guild.Id);
        }

        /// <summary>
        /// Queue Command. Shows up to 10 items in the current queue
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Queue, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Queue)]
        public async Task QueueTask()
        {
            var returnString = string.Empty;
            System.Collections.Generic.List<LavalinkTrack> currentPlaylist = Context.Guild.Id.PlayList();
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            if (!currentPlaylist.Any() && !player.Playing)
                await ReplyAsync(General.TRACK_QUEUE_EMPTY);
            else
            {
                if (player.Playing)
                    returnString += $"👉 [{player.CurrentTrack.Title}]({player.CurrentTrack.Url}) **{player.CurrentTrack.Length}**{Environment.NewLine}";

                for (var i = 0; i < Math.Min(currentPlaylist.Count, 10); i++)
                    returnString += $"**{i + 1}**. [{currentPlaylist[i].Title}]({currentPlaylist[i].Url}) **{currentPlaylist[i].Length}**{Environment.NewLine}";

                Embed build = new EmbedBuilder
                {
                    Title = General.CURRENT_QUEUE,
                    Description = returnString,
                    Color = new Color(213, 0, 249),
                    Footer = new EmbedFooterBuilder
                    {
                        Text = General.TRACKS_IN_QUEUE.GetFormattedString(currentPlaylist.Count.ToString())
                    }
                }.Build();

                await ReplyAsync(string.Empty, false, build);
            }
        }

        /// <summary>
        /// Skips the current song.
        /// </summary>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Skip, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Skip)]
        public async Task SkipTask()
        {
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            IUserMessage final = await ReplyAsync($"{Emojis.Hourglass} {General.SEARCHING}");
            try
            {
                LavalinkTrack track = Context.Guild.Id.PopTrack();
                Embed playing = new EmbedBuilder
                {
                    Title = General.NOW_PLAYING,
                    Description = track.Title,
                    Color = new Color(213, 0, 249)
                }.Build();

                await player.StopAsync();
                await player.PlayAsync(track);
                await final.ModifyAsync(x =>
                {
                    x.Embed = playing;
                    x.Content = null;
                });
            }
            catch (Exception)
            {
                if (player.Playing)
                    await player.StopAsync();

                await final.ModifyAsync(x => x.Content = General.TRACK_QUEUE_EMPTY);
            }

            Embed build = new EmbedBuilder
            {
                Title = General.WARNING,
                Description = General.BROKEN_COMMAND_WARNING,
                Color = new Color(213, 0, 249)
            }.Build();
            await ReplyAndDeleteAsync(string.Empty, false, build, TimeSpan.FromSeconds(6));
        }

        /// <summary>
        /// Play Command. Seaches for a song, then adds it to the queue. Can do searches on Youtube and SoundCloud.
        /// </summary>
        /// <param name="query">Query or URL to the song.</param>
        /// <returns></returns>
        [LocalizedCommand(CommandResourceNames.Play, RunMode = RunMode.Async)]
        [LocalizedSummary(SummaryResourceNames.Play)]
        public async Task PlayTask([Remainder] string query)
        {
            var result = Uri.TryCreate(query, UriKind.Absolute, out Uri uriResult);
            var identifier = result || query.Contains("ytsearch:") || query.Contains("scsearch") ? uriResult.ToString() : $"ytsearch:{query}";

            IUserMessage responseMessage = await ReplyAsync($"{Emojis.Hourglass} {General.SEARCHING}");
            LavalinkPlayer player = _lavalinkManager.GetPlayer(Context.Guild.Id) ?? await _lavalinkManager.JoinAsync((Context.User as IGuildUser)?.VoiceChannel);
            LoadTracksResponse response = await _lavalinkManager.GetTracksAsync(identifier);

            if (response.LoadType == LoadType.LoadFailed)
            {
                await responseMessage.ModifyAsync(x =>
                {
                    x.Content = null;
                    x.Embed = new EmbedBuilder
                    {
                        Title = General.FAILED_TO_LOAD_RESPONSE,
                        Description = General.URL_NOT_PLAYABLE,
                        Color = new Color(213, 0, 249),
                        Footer = new EmbedFooterBuilder
                        {
                            Text = General.SPECIFIC_SEARCHES_STRING.GetFormattedString(new string[] { "YouTube", "ytsearch", Commands.PLAY })
                        }
                    }.Build();
                });
                return;
            }

            if (response.LoadType == LoadType.NoMatches)
            {
                await responseMessage.ModifyAsync(x =>
                {
                    x.Content = null;
                    x.Embed = new EmbedBuilder
                    {
                        Title = General.FAILED_TO_LOAD_RESPONSE,
                        Description = General.TRACK_NOT_FOUND,
                        Color = new Color(213, 0, 249),
                        Footer = new EmbedFooterBuilder
                        {
                            Text = General.SPECIFIC_SEARCHES_STRING.GetFormattedString(new string[] { "SoundCloud", "scsearch", Commands.PLAY })
                        }
                    }.Build();
                });
                return;
            }

            var allTracks = response.Tracks.ToList();

            List<LavalinkTrack> tracks = response.LoadType == LoadType.PlaylistLoaded ? allTracks : allTracks.Take(Math.Min(10, allTracks.Count)).ToList();

            if (response.LoadType == LoadType.PlaylistLoaded)
            {
                foreach (LavalinkTrack track in tracks)
                    Context.Guild.Id.PushTrack(track);

                if (!player.Playing)
                {
                    LavalinkTrack lavalinkTrack = Context.Guild.Id.PopTrack();
                    await player.PlayAsync(lavalinkTrack);
                    await responseMessage.ModifyAsync(x =>
                    {
                        x.Embed = new EmbedBuilder
                        {
                            Description = $"{Emojis.PointRight} **{lavalinkTrack.Title}** {Environment.NewLine} {General.ADDED_X_TRACKS_TO_QUEUE.GetFormattedString(tracks.Count.ToString()) }",
                            Color = new Color(213, 0, 249),
                            Title = General.NOW_PLAYING
                        }.Build();
                        x.Content = null;
                    });
                }
                else
                {
                    await responseMessage.ModifyAsync(x =>
                    {
                        x.Embed = null;
                        x.Content = $"{General.ADDED_X_TRACKS_TO_QUEUE.GetFormattedString(tracks.Count.ToString()) }";
                    });
                }
            }
            else
            {
                var good = 1;
                if (tracks.Count != 1)
                {
                    var my = string.Empty;
                    for (var i = 0; i < tracks.Count; i++)
                        my += $"{i + 1}. [{tracks[i].Title}]({tracks[i].Url})  **{General.DURATION}: {tracks[i].Length}**{Environment.NewLine}";

                    Embed build = new EmbedBuilder
                    {
                        Title = General.MAKE_YOUR_CHOICE,
                        Description = my,
                        Color = new Color(213, 0, 249)
                    }.Build();

                    await responseMessage.ModifyAsync(x =>
                    {
                        x.Content = null;
                        x.Embed = build;
                    });

                    Discord.WebSocket.SocketMessage reply = await NextMessageAsync();
                    if (!int.TryParse(reply.Content, out good) || good > tracks.Count)
                    {
                        await responseMessage.ModifyAsync(x =>
                        {
                            x.Embed = null;
                            x.Content = General.INVALID_RESPONSE;
                        });
                        return;
                    }
                }

                LavalinkTrack track = tracks[good - 1];
                Context.Guild.Id.PushTrack(track);

                if (!player.Playing)
                {
                    LavalinkTrack lavalinkTrack = Context.Guild.Id.PopTrack();
                    await player.PlayAsync(lavalinkTrack);
                    await responseMessage.ModifyAsync(x =>
                    {
                        x.Embed = null;
                        x.Content = $"{Emojis.Check} {General.PLAYING_NOW.GetFormattedString(lavalinkTrack.Title)}";
                    });
                }
                else
                {
                    await responseMessage.ModifyAsync(x =>
                    {
                        x.Embed = null;
                        x.Content = $"{Emojis.Check} {General.ADDED_TRACK_TO_QUEUE.GetFormattedString(track.Title)}";
                    });
                }
            }
        }
    }
}
