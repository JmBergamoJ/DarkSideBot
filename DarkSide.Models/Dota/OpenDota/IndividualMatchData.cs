namespace DarkSide.Models.Dota.OpenDota
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public partial class IndividualMatchData
    {
        [JsonProperty("match_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? MatchId { get; set; }

        [JsonProperty("barracks_status_dire", NullValueHandling = NullValueHandling.Ignore)]
        public long? BarracksStatusDire { get; set; }

        [JsonProperty("barracks_status_radiant", NullValueHandling = NullValueHandling.Ignore)]
        public long? BarracksStatusRadiant { get; set; }

        [JsonProperty("chat", NullValueHandling = NullValueHandling.Ignore)]
        public Chat[] Chat { get; set; }

        [JsonProperty("cluster", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cluster { get; set; }

        [JsonProperty("cosmetics", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Cosmetics { get; set; }

        [JsonProperty("dire_score", NullValueHandling = NullValueHandling.Ignore)]
        public long? DireScore { get; set; }

        [JsonProperty("dire_team_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? DireTeamId { get; set; }

        [JsonProperty("draft_timings", NullValueHandling = NullValueHandling.Ignore)]
        public DraftTiming[] DraftTimings { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? Duration { get; set; }

        [JsonProperty("engine", NullValueHandling = NullValueHandling.Ignore)]
        public long? Engine { get; set; }

        [JsonProperty("first_blood_time", NullValueHandling = NullValueHandling.Ignore)]
        public long? FirstBloodTime { get; set; }

        [JsonProperty("game_mode", NullValueHandling = NullValueHandling.Ignore)]
        public long? GameMode { get; set; }

        [JsonProperty("human_players", NullValueHandling = NullValueHandling.Ignore)]
        public long? HumanPlayers { get; set; }

        [JsonProperty("leagueid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Leagueid { get; set; }

        [JsonProperty("lobby_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? LobbyType { get; set; }

        [JsonProperty("match_seq_num", NullValueHandling = NullValueHandling.Ignore)]
        public long? MatchSeqNum { get; set; }

        [JsonProperty("negative_votes", NullValueHandling = NullValueHandling.Ignore)]
        public long? NegativeVotes { get; set; }

        [JsonProperty("objectives", NullValueHandling = NullValueHandling.Ignore)]
        public Objective[] Objectives { get; set; }

        [JsonProperty("picks_bans", NullValueHandling = NullValueHandling.Ignore)]
        public PicksBan[] PicksBans { get; set; }

        [JsonProperty("positive_votes", NullValueHandling = NullValueHandling.Ignore)]
        public long? PositiveVotes { get; set; }

        [JsonProperty("radiant_gold_adv", NullValueHandling = NullValueHandling.Ignore)]
        public long[] RadiantGoldAdv { get; set; }

        [JsonProperty("radiant_score", NullValueHandling = NullValueHandling.Ignore)]
        public long? RadiantScore { get; set; }

        [JsonProperty("radiant_team_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? RadiantTeamId { get; set; }

        [JsonProperty("radiant_win", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RadiantWin { get; set; }

        [JsonProperty("radiant_xp_adv", NullValueHandling = NullValueHandling.Ignore)]
        public long[] RadiantXpAdv { get; set; }

        [JsonProperty("skill")]
        public dynamic Skill { get; set; }

        [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartTime { get; set; }

        [JsonProperty("teamfights", NullValueHandling = NullValueHandling.Ignore)]
        public Teamfight[] Teamfights { get; set; }

        [JsonProperty("tower_status_dire", NullValueHandling = NullValueHandling.Ignore)]
        public long? TowerStatusDire { get; set; }

        [JsonProperty("tower_status_radiant", NullValueHandling = NullValueHandling.Ignore)]
        public long? TowerStatusRadiant { get; set; }

        [JsonProperty("version", NullValueHandling = NullValueHandling.Ignore)]
        public long? Version { get; set; }

        [JsonProperty("replay_salt", NullValueHandling = NullValueHandling.Ignore)]
        public long? ReplaySalt { get; set; }

        [JsonProperty("series_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? SeriesId { get; set; }

        [JsonProperty("series_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? SeriesType { get; set; }

        [JsonProperty("league", NullValueHandling = NullValueHandling.Ignore)]
        public League League { get; set; }

        [JsonProperty("radiant_team", NullValueHandling = NullValueHandling.Ignore)]
        public Team RadiantTeam { get; set; }

        [JsonProperty("dire_team", NullValueHandling = NullValueHandling.Ignore)]
        public Team DireTeam { get; set; }

        [JsonProperty("players", NullValueHandling = NullValueHandling.Ignore)]
        public IndividualMatchDataPlayer[] Players { get; set; }

        [JsonProperty("patch", NullValueHandling = NullValueHandling.Ignore)]
        public long? Patch { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public long? Region { get; set; }

        [JsonProperty("all_word_counts", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> AllWordCounts { get; set; }

        [JsonProperty("my_word_counts", NullValueHandling = NullValueHandling.Ignore)]
        public MyWordCounts MyWordCounts { get; set; }

        [JsonProperty("comeback", NullValueHandling = NullValueHandling.Ignore)]
        public long? Comeback { get; set; }

        [JsonProperty("stomp", NullValueHandling = NullValueHandling.Ignore)]
        public long? Stomp { get; set; }

        [JsonProperty("replay_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ReplayUrl { get; set; }
    }

    public partial class Chat
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public ChatType? Type { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? Slot { get; set; }

        [JsonProperty("player_slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerSlot { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }
    }

    public partial class Team
    {
        [JsonProperty("team_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? TeamId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
        public string Tag { get; set; }

        [JsonProperty("logo_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri LogoUrl { get; set; }
    }

    public partial class DraftTiming
    {
        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public long? Order { get; set; }

        [JsonProperty("pick", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Pick { get; set; }

        [JsonProperty("active_team", NullValueHandling = NullValueHandling.Ignore)]
        public long? ActiveTeam { get; set; }

        [JsonProperty("hero_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? HeroId { get; set; }

        [JsonProperty("player_slot")]
        public long? PlayerSlot { get; set; }

        [JsonProperty("extra_time", NullValueHandling = NullValueHandling.Ignore)]
        public long? ExtraTime { get; set; }

        [JsonProperty("total_time_taken", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalTimeTaken { get; set; }
    }

    public partial class League
    {
        [JsonProperty("leagueid", NullValueHandling = NullValueHandling.Ignore)]
        public long? Leagueid { get; set; }

        [JsonProperty("ticket")]
        public dynamic Ticket { get; set; }

        [JsonProperty("banner")]
        public dynamic Banner { get; set; }

        [JsonProperty("tier", NullValueHandling = NullValueHandling.Ignore)]
        public string Tier { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class MyWordCounts
    {
    }

    public partial class Objective
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public ObjectiveType? Type { get; set; }

        [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? Slot { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public Key? Key { get; set; }

        [JsonProperty("player_slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerSlot { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public long? Team { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }
    }

    public partial class PicksBan
    {
        [JsonProperty("is_pick", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPick { get; set; }

        [JsonProperty("hero_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? HeroId { get; set; }

        [JsonProperty("team", NullValueHandling = NullValueHandling.Ignore)]
        public long? Team { get; set; }

        [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
        public long? Order { get; set; }

        [JsonProperty("ord", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ord { get; set; }

        [JsonProperty("match_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? MatchId { get; set; }
    }

    public partial class IndividualMatchDataPlayer
    {
        [JsonProperty("match_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? MatchId { get; set; }

        [JsonProperty("player_slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerSlot { get; set; }

        [JsonProperty("ability_targets", NullValueHandling = NullValueHandling.Ignore)]
        public AbilityTargets AbilityTargets { get; set; }

        [JsonProperty("ability_upgrades_arr", NullValueHandling = NullValueHandling.Ignore)]
        public long[] AbilityUpgradesArr { get; set; }

        [JsonProperty("ability_uses", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> AbilityUses { get; set; }

        [JsonProperty("account_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? AccountId { get; set; }

        [JsonProperty("actions", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Actions { get; set; }

        [JsonProperty("additional_units")]
        public dynamic AdditionalUnits { get; set; }

        [JsonProperty("assists", NullValueHandling = NullValueHandling.Ignore)]
        public long? Assists { get; set; }

        [JsonProperty("backpack_0", NullValueHandling = NullValueHandling.Ignore)]
        public long? Backpack0 { get; set; }

        [JsonProperty("backpack_1", NullValueHandling = NullValueHandling.Ignore)]
        public long? Backpack1 { get; set; }

        [JsonProperty("backpack_2", NullValueHandling = NullValueHandling.Ignore)]
        public long? Backpack2 { get; set; }

        [JsonProperty("backpack_3")]
        public dynamic Backpack3 { get; set; }

        [JsonProperty("buyback_log", NullValueHandling = NullValueHandling.Ignore)]
        public BuybackLog[] BuybackLog { get; set; }

        [JsonProperty("camps_stacked", NullValueHandling = NullValueHandling.Ignore)]
        public long? CampsStacked { get; set; }

        [JsonProperty("connection_log", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic[] ConnectionLog { get; set; }

        [JsonProperty("creeps_stacked", NullValueHandling = NullValueHandling.Ignore)]
        public long? CreepsStacked { get; set; }

        [JsonProperty("damage", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Damage { get; set; }

        [JsonProperty("damage_inflictor", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> DamageInflictor { get; set; }

        [JsonProperty("damage_inflictor_received", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> DamageInflictorReceived { get; set; }

        [JsonProperty("damage_taken", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> DamageTaken { get; set; }

        [JsonProperty("damage_targets", NullValueHandling = NullValueHandling.Ignore)]
        public DamageTargets DamageTargets { get; set; }

        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public long? Deaths { get; set; }

        [JsonProperty("denies", NullValueHandling = NullValueHandling.Ignore)]
        public long? Denies { get; set; }

        [JsonProperty("dn_t", NullValueHandling = NullValueHandling.Ignore)]
        public long[] DnT { get; set; }

        [JsonProperty("firstblood_claimed", NullValueHandling = NullValueHandling.Ignore)]
        public long? FirstbloodClaimed { get; set; }

        [JsonProperty("gold", NullValueHandling = NullValueHandling.Ignore)]
        public long? Gold { get; set; }

        [JsonProperty("gold_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? GoldPerMin { get; set; }

        [JsonProperty("gold_reasons", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> GoldReasons { get; set; }

        [JsonProperty("gold_spent", NullValueHandling = NullValueHandling.Ignore)]
        public long? GoldSpent { get; set; }

        [JsonProperty("gold_t", NullValueHandling = NullValueHandling.Ignore)]
        public long[] GoldT { get; set; }

        [JsonProperty("hero_damage", NullValueHandling = NullValueHandling.Ignore)]
        public long? HeroDamage { get; set; }

        [JsonProperty("hero_healing", NullValueHandling = NullValueHandling.Ignore)]
        public long? HeroHealing { get; set; }

        [JsonProperty("hero_hits", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> HeroHits { get; set; }

        [JsonProperty("hero_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? HeroId { get; set; }

        [JsonProperty("item_0", NullValueHandling = NullValueHandling.Ignore)]
        public long? Item0 { get; set; }

        [JsonProperty("item_1", NullValueHandling = NullValueHandling.Ignore)]
        public long? Item1 { get; set; }

        [JsonProperty("item_2", NullValueHandling = NullValueHandling.Ignore)]
        public long? Item2 { get; set; }

        [JsonProperty("item_3", NullValueHandling = NullValueHandling.Ignore)]
        public long? Item3 { get; set; }

        [JsonProperty("item_4", NullValueHandling = NullValueHandling.Ignore)]
        public long? Item4 { get; set; }

        [JsonProperty("item_5", NullValueHandling = NullValueHandling.Ignore)]
        public long? Item5 { get; set; }

        [JsonProperty("item_neutral", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemNeutral { get; set; }

        [JsonProperty("item_uses", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> ItemUses { get; set; }

        [JsonProperty("kill_streaks", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> KillStreaks { get; set; }

        [JsonProperty("killed", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Killed { get; set; }

        [JsonProperty("killed_by", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> KilledBy { get; set; }

        [JsonProperty("kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? Kills { get; set; }

        [JsonProperty("kills_log", NullValueHandling = NullValueHandling.Ignore)]
        public KillsLogElement[] KillsLog { get; set; }

        [JsonProperty("lane_pos", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Dictionary<string, long>> LanePos { get; set; }

        [JsonProperty("last_hits", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastHits { get; set; }

        [JsonProperty("leaver_status", NullValueHandling = NullValueHandling.Ignore)]
        public long? LeaverStatus { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public long? Level { get; set; }

        [JsonProperty("lh_t", NullValueHandling = NullValueHandling.Ignore)]
        public long[] LhT { get; set; }

        [JsonProperty("life_state", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> LifeState { get; set; }

        [JsonProperty("max_hero_hit", NullValueHandling = NullValueHandling.Ignore)]
        public MaxHeroHit MaxHeroHit { get; set; }

        [JsonProperty("multi_kills", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> MultiKills { get; set; }

        [JsonProperty("obs", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Dictionary<string, long>> Obs { get; set; }

        [JsonProperty("obs_left_log", NullValueHandling = NullValueHandling.Ignore)]
        public ObsLeftLogElement[] ObsLeftLog { get; set; }

        [JsonProperty("obs_log", NullValueHandling = NullValueHandling.Ignore)]
        public ObsLeftLogElement[] ObsLog { get; set; }

        [JsonProperty("obs_placed", NullValueHandling = NullValueHandling.Ignore)]
        public long? ObsPlaced { get; set; }

        [JsonProperty("party_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? PartyId { get; set; }

        [JsonProperty("party_size", NullValueHandling = NullValueHandling.Ignore)]
        public long? PartySize { get; set; }

        [JsonProperty("performance_others")]
        public dynamic PerformanceOthers { get; set; }

        [JsonProperty("permanent_buffs")]
        public PermanentBuff[] PermanentBuffs { get; set; }

        [JsonProperty("pings", NullValueHandling = NullValueHandling.Ignore)]
        public long? Pings { get; set; }

        [JsonProperty("pred_vict", NullValueHandling = NullValueHandling.Ignore)]
        public bool? PredVict { get; set; }

        [JsonProperty("purchase", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Purchase { get; set; }

        [JsonProperty("purchase_log", NullValueHandling = NullValueHandling.Ignore)]
        public KillsLogElement[] PurchaseLog { get; set; }

        [JsonProperty("randomed", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Randomed { get; set; }

        [JsonProperty("repicked")]
        public dynamic Repicked { get; set; }

        [JsonProperty("roshans_killed", NullValueHandling = NullValueHandling.Ignore)]
        public long? RoshansKilled { get; set; }

        [JsonProperty("rune_pickups", NullValueHandling = NullValueHandling.Ignore)]
        public long? RunePickups { get; set; }

        [JsonProperty("runes", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Runes { get; set; }

        [JsonProperty("runes_log", NullValueHandling = NullValueHandling.Ignore)]
        public RunesLog[] RunesLog { get; set; }

        [JsonProperty("sen", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Dictionary<string, long>> Sen { get; set; }

        [JsonProperty("sen_left_log", NullValueHandling = NullValueHandling.Ignore)]
        public ObsLeftLogElement[] SenLeftLog { get; set; }

        [JsonProperty("sen_log", NullValueHandling = NullValueHandling.Ignore)]
        public ObsLeftLogElement[] SenLog { get; set; }

        [JsonProperty("sen_placed", NullValueHandling = NullValueHandling.Ignore)]
        public long? SenPlaced { get; set; }

        [JsonProperty("stuns", NullValueHandling = NullValueHandling.Ignore)]
        public double? Stuns { get; set; }

        [JsonProperty("teamfight_participation", NullValueHandling = NullValueHandling.Ignore)]
        public double? TeamfightParticipation { get; set; }

        [JsonProperty("times", NullValueHandling = NullValueHandling.Ignore)]
        public long[] Times { get; set; }

        [JsonProperty("tower_damage", NullValueHandling = NullValueHandling.Ignore)]
        public long? TowerDamage { get; set; }

        [JsonProperty("towers_killed", NullValueHandling = NullValueHandling.Ignore)]
        public long? TowersKilled { get; set; }

        [JsonProperty("xp_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? XpPerMin { get; set; }

        [JsonProperty("xp_reasons", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> XpReasons { get; set; }

        [JsonProperty("xp_t", NullValueHandling = NullValueHandling.Ignore)]
        public long[] XpT { get; set; }

        [JsonProperty("personaname", NullValueHandling = NullValueHandling.Ignore)]
        public string Personaname { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("last_login")]
        public DateTimeOffset? LastLogin { get; set; }

        [JsonProperty("radiant_win", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RadiantWin { get; set; }

        [JsonProperty("start_time", NullValueHandling = NullValueHandling.Ignore)]
        public long? StartTime { get; set; }

        [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
        public long? Duration { get; set; }

        [JsonProperty("cluster", NullValueHandling = NullValueHandling.Ignore)]
        public long? Cluster { get; set; }

        [JsonProperty("lobby_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? LobbyType { get; set; }

        [JsonProperty("game_mode", NullValueHandling = NullValueHandling.Ignore)]
        public long? GameMode { get; set; }

        [JsonProperty("is_contributor", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsContributor { get; set; }

        [JsonProperty("patch", NullValueHandling = NullValueHandling.Ignore)]
        public long? Patch { get; set; }

        [JsonProperty("region", NullValueHandling = NullValueHandling.Ignore)]
        public long? Region { get; set; }

        [JsonProperty("isRadiant", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRadiant { get; set; }

        [JsonProperty("win", NullValueHandling = NullValueHandling.Ignore)]
        public long? Win { get; set; }

        [JsonProperty("lose", NullValueHandling = NullValueHandling.Ignore)]
        public long? Lose { get; set; }

        [JsonProperty("total_gold", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalGold { get; set; }

        [JsonProperty("total_xp", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalXp { get; set; }

        [JsonProperty("kda", NullValueHandling = NullValueHandling.Ignore)]
        public long? Kda { get; set; }

        [JsonProperty("abandons", NullValueHandling = NullValueHandling.Ignore)]
        public long? Abandons { get; set; }

        [JsonProperty("neutral_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? NeutralKills { get; set; }

        [JsonProperty("tower_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? TowerKills { get; set; }

        [JsonProperty("courier_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? CourierKills { get; set; }

        [JsonProperty("lane_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? LaneKills { get; set; }

        [JsonProperty("hero_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? HeroKills { get; set; }

        [JsonProperty("observer_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? ObserverKills { get; set; }

        [JsonProperty("sentry_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? SentryKills { get; set; }

        [JsonProperty("roshan_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? RoshanKills { get; set; }

        [JsonProperty("necronomicon_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? NecronomiconKills { get; set; }

        [JsonProperty("ancient_kills", NullValueHandling = NullValueHandling.Ignore)]
        public long? AncientKills { get; set; }

        [JsonProperty("buyback_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? BuybackCount { get; set; }

        [JsonProperty("observer_uses", NullValueHandling = NullValueHandling.Ignore)]
        public long? ObserverUses { get; set; }

        [JsonProperty("sentry_uses", NullValueHandling = NullValueHandling.Ignore)]
        public long? SentryUses { get; set; }

        [JsonProperty("lane_efficiency", NullValueHandling = NullValueHandling.Ignore)]
        public double? LaneEfficiency { get; set; }

        [JsonProperty("lane_efficiency_pct", NullValueHandling = NullValueHandling.Ignore)]
        public long? LaneEfficiencyPct { get; set; }

        [JsonProperty("lane", NullValueHandling = NullValueHandling.Ignore)]
        public long? Lane { get; set; }

        [JsonProperty("lane_role", NullValueHandling = NullValueHandling.Ignore)]
        public long? LaneRole { get; set; }

        [JsonProperty("is_roaming", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRoaming { get; set; }

        [JsonProperty("purchase_time", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> PurchaseTime { get; set; }

        [JsonProperty("first_purchase_time", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> FirstPurchaseTime { get; set; }

        [JsonProperty("item_win", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> ItemWin { get; set; }

        [JsonProperty("item_usage", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> ItemUsage { get; set; }

        [JsonProperty("purchase_ward_observer", NullValueHandling = NullValueHandling.Ignore)]
        public long? PurchaseWardObserver { get; set; }

        [JsonProperty("purchase_ward_sentry", NullValueHandling = NullValueHandling.Ignore)]
        public long? PurchaseWardSentry { get; set; }

        [JsonProperty("purchase_tpscroll", NullValueHandling = NullValueHandling.Ignore)]
        public long? PurchaseTpscroll { get; set; }

        [JsonProperty("actions_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public long? ActionsPerMin { get; set; }

        [JsonProperty("life_state_dead", NullValueHandling = NullValueHandling.Ignore)]
        public long? LifeStateDead { get; set; }

        [JsonProperty("rank_tier", NullValueHandling = NullValueHandling.Ignore)]
        public long? RankTier { get; set; }

        [JsonProperty("cosmetics", NullValueHandling = NullValueHandling.Ignore)]
        public Cosmetic[] Cosmetics { get; set; }

        [JsonProperty("benchmarks", NullValueHandling = NullValueHandling.Ignore)]
        public Benchmarks Benchmarks { get; set; }

        [JsonProperty("kills_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public double? KillsPerMin { get; set; }
    }

    public partial class AbilityTargets
    {
        [JsonProperty("magnataur_shockwave", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave MagnataurShockwave { get; set; }

        [JsonProperty("magnataur_empower", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurEmpower MagnataurEmpower { get; set; }

        [JsonProperty("spectre_spectral_dagger", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave SpectreSpectralDagger { get; set; }

        [JsonProperty("terrorblade_sunder", NullValueHandling = NullValueHandling.Ignore)]
        public AbilityTargetsTerrorbladeSunder TerrorbladeSunder { get; set; }

        [JsonProperty("tiny_toss", NullValueHandling = NullValueHandling.Ignore)]
        public TinyToss TinyToss { get; set; }

        [JsonProperty("tiny_toss_tree", NullValueHandling = NullValueHandling.Ignore)]
        public TinyTossTree TinyTossTree { get; set; }

        [JsonProperty("warlock_fatal_bonds", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds WarlockFatalBonds { get; set; }

        [JsonProperty("warlock_shadow_word", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave WarlockShadowWord { get; set; }

        [JsonProperty("furion_sprout", NullValueHandling = NullValueHandling.Ignore)]
        public FurionSprout FurionSprout { get; set; }
    }

    public partial class FurionSprout
    {
        [JsonProperty("npc_dota_hero_puck", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroPuck { get; set; }

        [JsonProperty("npc_dota_hero_spectre", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroSpectre { get; set; }

        [JsonProperty("npc_dota_hero_magnataur", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroMagnataur { get; set; }

        [JsonProperty("npc_dota_hero_furion", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroFurion { get; set; }

        [JsonProperty("npc_dota_hero_elder_titan", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroElderTitan { get; set; }
    }

    public partial class MagnataurEmpower
    {
        [JsonProperty("npc_dota_hero_spectre", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroSpectre { get; set; }

        [JsonProperty("npc_dota_hero_magnataur", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroMagnataur { get; set; }
    }

    public partial class MagnataurShockwave
    {
        [JsonProperty("npc_dota_hero_furion", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroFurion { get; set; }

        [JsonProperty("npc_dota_hero_tiny", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTiny { get; set; }

        [JsonProperty("npc_dota_hero_terrorblade", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTerrorblade { get; set; }

        [JsonProperty("npc_dota_hero_pangolier", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroPangolier { get; set; }

        [JsonProperty("npc_dota_hero_warlock", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroWarlock { get; set; }

        [JsonProperty("npc_dota_hero_venomancer", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroVenomancer { get; set; }

        [JsonProperty("npc_dota_hero_spectre", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroSpectre { get; set; }
    }

    public partial class AbilityTargetsTerrorbladeSunder
    {
        [JsonProperty("npc_dota_hero_warlock", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroWarlock { get; set; }
    }

    public partial class TinyToss
    {
        [JsonProperty("npc_dota_hero_puck", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroPuck { get; set; }

        [JsonProperty("npc_dota_hero_magnataur", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroMagnataur { get; set; }

        [JsonProperty("npc_dota_hero_elder_titan", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroElderTitan { get; set; }

        [JsonProperty("npc_dota_hero_spectre", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroSpectre { get; set; }

        [JsonProperty("npc_dota_hero_venomancer", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroVenomancer { get; set; }

        [JsonProperty("npc_dota_hero_pangolier", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroPangolier { get; set; }

        [JsonProperty("npc_dota_hero_terrorblade", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTerrorblade { get; set; }

        [JsonProperty("npc_dota_hero_warlock", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroWarlock { get; set; }

        [JsonProperty("npc_dota_hero_furion", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroFurion { get; set; }
    }

    public partial class TinyTossTree
    {
        [JsonProperty("npc_dota_hero_elder_titan", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroElderTitan { get; set; }
    }

    public partial class WarlockFatalBonds
    {
        [JsonProperty("npc_dota_hero_venomancer", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroVenomancer { get; set; }

        [JsonProperty("npc_dota_hero_elder_titan", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroElderTitan { get; set; }

        [JsonProperty("npc_dota_hero_spectre", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroSpectre { get; set; }

        [JsonProperty("npc_dota_hero_puck", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroPuck { get; set; }

        [JsonProperty("npc_dota_hero_magnataur", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroMagnataur { get; set; }
    }

    public partial class Benchmarks
    {
        [JsonProperty("gold_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> GoldPerMin { get; set; }

        [JsonProperty("xp_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> XpPerMin { get; set; }

        [JsonProperty("kills_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> KillsPerMin { get; set; }

        [JsonProperty("last_hits_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> LastHitsPerMin { get; set; }

        [JsonProperty("hero_damage_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> HeroDamagePerMin { get; set; }

        [JsonProperty("hero_healing_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> HeroHealingPerMin { get; set; }

        [JsonProperty("tower_damage", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> TowerDamage { get; set; }

        [JsonProperty("stuns_per_min", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> StunsPerMin { get; set; }

        [JsonProperty("lhten", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> Lhten { get; set; }
    }

    public partial class BuybackLog
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? Slot { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("player_slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerSlot { get; set; }
    }

    public partial class Cosmetic
    {
        [JsonProperty("item_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("prefab", NullValueHandling = NullValueHandling.Ignore)]
        public Prefab? Prefab { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("image_inventory", NullValueHandling = NullValueHandling.Ignore)]
        public string ImageInventory { get; set; }

        [JsonProperty("image_path", NullValueHandling = NullValueHandling.Ignore)]
        public string ImagePath { get; set; }

        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }

        [JsonProperty("item_name", NullValueHandling = NullValueHandling.Ignore)]
        public string ItemName { get; set; }

        [JsonProperty("item_rarity")]
        public string ItemRarity { get; set; }

        [JsonProperty("item_type_name")]
        public string ItemTypeName { get; set; }

        [JsonProperty("used_by_heroes")]
        public string UsedByHeroes { get; set; }
    }

    public partial class DamageTargets
    {
        [JsonProperty("magnataur_skewer", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave MagnataurSkewer { get; set; }

        [JsonProperty("null", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> Null { get; set; }

        [JsonProperty("magnataur_shockwave", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave MagnataurShockwave { get; set; }

        [JsonProperty("magnataur_empower", NullValueHandling = NullValueHandling.Ignore)]
        public Magnataur MagnataurEmpower { get; set; }

        [JsonProperty("magnataur_reverse_polarity", NullValueHandling = NullValueHandling.Ignore)]
        public Magnataur MagnataurReversePolarity { get; set; }

        [JsonProperty("spectre_spectral_dagger", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave SpectreSpectralDagger { get; set; }

        [JsonProperty("spectre_dispersion", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave SpectreDispersion { get; set; }

        [JsonProperty("spectre_desolate", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave SpectreDesolate { get; set; }

        [JsonProperty("puck_illusory_orb", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave PuckIllusoryOrb { get; set; }

        [JsonProperty("puck_waning_rift", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave PuckWaningRift { get; set; }

        [JsonProperty("puck_dream_coil", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave PuckDreamCoil { get; set; }

        [JsonProperty("venomancer_poison_sting", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave VenomancerPoisonSting { get; set; }

        [JsonProperty("venomancer_venomous_gale", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave VenomancerVenomousGale { get; set; }

        [JsonProperty("urn_of_shadows", NullValueHandling = NullValueHandling.Ignore)]
        public UrnOfShadows UrnOfShadows { get; set; }

        [JsonProperty("venomancer_poison_nova", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave VenomancerPoisonNova { get; set; }

        [JsonProperty("spirit_vessel", NullValueHandling = NullValueHandling.Ignore)]
        public SpiritVessel SpiritVessel { get; set; }

        [JsonProperty("elder_titan_ancestral_spirit", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave ElderTitanAncestralSpirit { get; set; }

        [JsonProperty("elder_titan_echo_stomp", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave ElderTitanEchoStomp { get; set; }

        [JsonProperty("elder_titan_earth_splitter", NullValueHandling = NullValueHandling.Ignore)]
        public MagnataurShockwave ElderTitanEarthSplitter { get; set; }

        [JsonProperty("terrorblade_sunder", NullValueHandling = NullValueHandling.Ignore)]
        public DamageTargetsTerrorbladeSunder TerrorbladeSunder { get; set; }

        [JsonProperty("tiny_tree_grab", NullValueHandling = NullValueHandling.Ignore)]
        public TinyT TinyTreeGrab { get; set; }

        [JsonProperty("tiny_toss_tree", NullValueHandling = NullValueHandling.Ignore)]
        public TinyT TinyTossTree { get; set; }

        [JsonProperty("tiny_avalanche", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds TinyAvalanche { get; set; }

        [JsonProperty("tiny_toss", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds TinyToss { get; set; }

        [JsonProperty("warlock_fatal_bonds", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds WarlockFatalBonds { get; set; }

        [JsonProperty("warlock_shadow_word", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockShadowWord WarlockShadowWord { get; set; }

        [JsonProperty("warlock_golem_flaming_fists", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds WarlockGolemFlamingFists { get; set; }

        [JsonProperty("warlock_golem_permanent_immolation", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds WarlockGolemPermanentImmolation { get; set; }

        [JsonProperty("furion_wrath_of_nature", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds FurionWrathOfNature { get; set; }

        [JsonProperty("orchid", NullValueHandling = NullValueHandling.Ignore)]
        public Orchid Orchid { get; set; }

        [JsonProperty("orb_of_venom", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds OrbOfVenom { get; set; }

        [JsonProperty("pangolier_swashbuckle", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds PangolierSwashbuckle { get; set; }

        [JsonProperty("pangolier_gyroshell", NullValueHandling = NullValueHandling.Ignore)]
        public WarlockFatalBonds PangolierGyroshell { get; set; }

        [JsonProperty("dragon_scale", NullValueHandling = NullValueHandling.Ignore)]
        public FurionSprout DragonScale { get; set; }

        [JsonProperty("pangolier_shield_crash", NullValueHandling = NullValueHandling.Ignore)]
        public FurionSprout PangolierShieldCrash { get; set; }
    }

    public partial class Magnataur
    {
        [JsonProperty("npc_dota_hero_furion", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroFurion { get; set; }

        [JsonProperty("npc_dota_hero_tiny", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTiny { get; set; }

        [JsonProperty("npc_dota_hero_terrorblade", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTerrorblade { get; set; }
    }

    public partial class Orchid
    {
        [JsonProperty("npc_dota_hero_magnataur", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroMagnataur { get; set; }
    }

    public partial class SpiritVessel
    {
        [JsonProperty("npc_dota_hero_tiny", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTiny { get; set; }

        [JsonProperty("npc_dota_hero_terrorblade", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTerrorblade { get; set; }
    }

    public partial class DamageTargetsTerrorbladeSunder
    {
        [JsonProperty("npc_dota_hero_terrorblade", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroTerrorblade { get; set; }
    }

    public partial class TinyT
    {
        [JsonProperty("npc_dota_hero_puck", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroPuck { get; set; }
    }

    public partial class UrnOfShadows
    {
        [JsonProperty("npc_dota_hero_pangolier", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroPangolier { get; set; }
    }

    public partial class WarlockShadowWord
    {
        [JsonProperty("npc_dota_hero_venomancer", NullValueHandling = NullValueHandling.Ignore)]
        public long? NpcDotaHeroVenomancer { get; set; }
    }

    public partial class KillsLogElement
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }
    }

    public partial class MaxHeroHit
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public MaxHeroHitType? Type { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Max { get; set; }

        [JsonProperty("inflictor")]
        public string Inflictor { get; set; }

        [JsonProperty("unit", NullValueHandling = NullValueHandling.Ignore)]
        public string Unit { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public long? Value { get; set; }

        [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? Slot { get; set; }

        [JsonProperty("player_slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerSlot { get; set; }
    }

    public partial class ObsLeftLogElement
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public ObsLeftLogType? Type { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty("slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? Slot { get; set; }

        [JsonProperty("attackername", NullValueHandling = NullValueHandling.Ignore)]
        public string Attackername { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
        public long? X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
        public long? Y { get; set; }

        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public long? Z { get; set; }

        [JsonProperty("entityleft", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Entityleft { get; set; }

        [JsonProperty("ehandle", NullValueHandling = NullValueHandling.Ignore)]
        public long? Ehandle { get; set; }

        [JsonProperty("player_slot", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlayerSlot { get; set; }
    }

    public partial class PermanentBuff
    {
        [JsonProperty("permanent_buff", NullValueHandling = NullValueHandling.Ignore)]
        public long? PermanentBuffPermanentBuff { get; set; }

        [JsonProperty("stack_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? StackCount { get; set; }
    }

    public partial class RunesLog
    {
        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public long? Time { get; set; }

        [JsonProperty("key", NullValueHandling = NullValueHandling.Ignore)]
        public long? Key { get; set; }
    }

    public partial class Teamfight
    {
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public long? Start { get; set; }

        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public long? End { get; set; }

        [JsonProperty("last_death", NullValueHandling = NullValueHandling.Ignore)]
        public long? LastDeath { get; set; }

        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public long? Deaths { get; set; }

        [JsonProperty("players", NullValueHandling = NullValueHandling.Ignore)]
        public TeamfightPlayer[] Players { get; set; }
    }

    public partial class TeamfightPlayer
    {
        [JsonProperty("deaths_pos", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Dictionary<string, long>> DeathsPos { get; set; }

        [JsonProperty("ability_uses", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> AbilityUses { get; set; }

        [JsonProperty("ability_targets", NullValueHandling = NullValueHandling.Ignore)]
        public MyWordCounts AbilityTargets { get; set; }

        [JsonProperty("item_uses", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, long> ItemUses { get; set; }

        [JsonProperty("killed", NullValueHandling = NullValueHandling.Ignore)]
        public TinyToss Killed { get; set; }

        [JsonProperty("deaths", NullValueHandling = NullValueHandling.Ignore)]
        public long? Deaths { get; set; }

        [JsonProperty("buybacks", NullValueHandling = NullValueHandling.Ignore)]
        public long? Buybacks { get; set; }

        [JsonProperty("damage", NullValueHandling = NullValueHandling.Ignore)]
        public long? Damage { get; set; }

        [JsonProperty("healing", NullValueHandling = NullValueHandling.Ignore)]
        public long? Healing { get; set; }

        [JsonProperty("gold_delta", NullValueHandling = NullValueHandling.Ignore)]
        public long? GoldDelta { get; set; }

        [JsonProperty("xp_delta", NullValueHandling = NullValueHandling.Ignore)]
        public long? XpDelta { get; set; }

        [JsonProperty("xp_start", NullValueHandling = NullValueHandling.Ignore)]
        public long? XpStart { get; set; }

        [JsonProperty("xp_end", NullValueHandling = NullValueHandling.Ignore)]
        public long? XpEnd { get; set; }
    }

    public enum ChatType { Chat, Chatwheel };

    public enum ObjectiveType { BuildingKill, ChatMessageAegis, ChatMessageCourierLost, ChatMessageFirstblood, ChatMessageRoshanKill };

    public enum Prefab { Courier, Taunt, Tool, Ward, Wearable };

    public enum MaxHeroHitType { MaxHeroHit };

    public enum ObsLeftLogType { ObsLeftLog, ObsLog, SenLeftLog, SenLog };

    public partial struct Key
    {
        public long? Integer;
        public string String;

        public static implicit operator Key(long Integer) => new Key { Integer = Integer };
        public static implicit operator Key(string String) => new Key { String = String };
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ChatTypeConverter.Singleton,
                KeyConverter.Singleton,
                ObjectiveTypeConverter.Singleton,
                PrefabConverter.Singleton,
                MaxHeroHitTypeConverter.Singleton,
                ObsLeftLogTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ChatTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ChatType) || t == typeof(ChatType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "chat" => ChatType.Chat,
                "chatwheel" => ChatType.Chatwheel,
                _ => ChatType.Chat,
            };
            throw new Exception("Cannot unmarshal type ChatType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ChatType)untypedValue;
            switch (value)
            {
                case ChatType.Chat:
                    serializer.Serialize(writer, "chat");
                    return;
                case ChatType.Chatwheel:
                    serializer.Serialize(writer, "chatwheel");
                    return;
            }
            throw new Exception("Cannot marshal type ChatType");
        }

        public static readonly ChatTypeConverter Singleton = new ChatTypeConverter();
    }

    internal class KeyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Key) || t == typeof(Key?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Key { Integer = integerValue };
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Key { String = stringValue };
            }
            throw new Exception("Cannot unmarshal type Key");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Key)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            throw new Exception("Cannot marshal type Key");
        }

        public static readonly KeyConverter Singleton = new KeyConverter();
    }

    internal class ObjectiveTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ObjectiveType) || t == typeof(ObjectiveType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "CHAT_MESSAGE_AEGIS" => ObjectiveType.ChatMessageAegis,
                "CHAT_MESSAGE_COURIER_LOST" => ObjectiveType.ChatMessageCourierLost,
                "CHAT_MESSAGE_FIRSTBLOOD" => ObjectiveType.ChatMessageFirstblood,
                "CHAT_MESSAGE_ROSHAN_KILL" => ObjectiveType.ChatMessageRoshanKill,
                "building_kill" => ObjectiveType.BuildingKill,
                _ => throw new Exception("Cannot unmarshal type ObjectiveType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ObjectiveType)untypedValue;
            switch (value)
            {
                case ObjectiveType.ChatMessageAegis:
                    serializer.Serialize(writer, "CHAT_MESSAGE_AEGIS");
                    return;
                case ObjectiveType.ChatMessageCourierLost:
                    serializer.Serialize(writer, "CHAT_MESSAGE_COURIER_LOST");
                    return;
                case ObjectiveType.ChatMessageFirstblood:
                    serializer.Serialize(writer, "CHAT_MESSAGE_FIRSTBLOOD");
                    return;
                case ObjectiveType.ChatMessageRoshanKill:
                    serializer.Serialize(writer, "CHAT_MESSAGE_ROSHAN_KILL");
                    return;
                case ObjectiveType.BuildingKill:
                    serializer.Serialize(writer, "building_kill");
                    return;
            }
            throw new Exception("Cannot marshal type ObjectiveType");
        }

        public static readonly ObjectiveTypeConverter Singleton = new ObjectiveTypeConverter();
    }

    internal class PrefabConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Prefab) || t == typeof(Prefab?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "courier" => Prefab.Courier,
                "taunt" => Prefab.Taunt,
                "tool" => Prefab.Tool,
                "ward" => Prefab.Ward,
                "wearable" => Prefab.Wearable,
                _ => throw new Exception("Cannot unmarshal type Prefab"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Prefab)untypedValue;
            switch (value)
            {
                case Prefab.Courier:
                    serializer.Serialize(writer, "courier");
                    return;
                case Prefab.Taunt:
                    serializer.Serialize(writer, "taunt");
                    return;
                case Prefab.Tool:
                    serializer.Serialize(writer, "tool");
                    return;
                case Prefab.Ward:
                    serializer.Serialize(writer, "ward");
                    return;
                case Prefab.Wearable:
                    serializer.Serialize(writer, "wearable");
                    return;
            }
            throw new Exception("Cannot marshal type Prefab");
        }

        public static readonly PrefabConverter Singleton = new PrefabConverter();
    }

    internal class MaxHeroHitTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MaxHeroHitType) || t == typeof(MaxHeroHitType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "max_hero_hit")
            {
                return MaxHeroHitType.MaxHeroHit;
            }
            throw new Exception("Cannot unmarshal type MaxHeroHitType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MaxHeroHitType)untypedValue;
            if (value == MaxHeroHitType.MaxHeroHit)
            {
                serializer.Serialize(writer, "max_hero_hit");
                return;
            }
            throw new Exception("Cannot marshal type MaxHeroHitType");
        }

        public static readonly MaxHeroHitTypeConverter Singleton = new MaxHeroHitTypeConverter();
    }

    internal class ObsLeftLogTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ObsLeftLogType) || t == typeof(ObsLeftLogType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "obs_left_log" => ObsLeftLogType.ObsLeftLog,
                "obs_log" => ObsLeftLogType.ObsLog,
                "sen_left_log" => ObsLeftLogType.SenLeftLog,
                "sen_log" => ObsLeftLogType.SenLog,
                _ => throw new Exception("Cannot unmarshal type ObsLeftLogType"),
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ObsLeftLogType)untypedValue;
            switch (value)
            {
                case ObsLeftLogType.ObsLeftLog:
                    serializer.Serialize(writer, "obs_left_log");
                    return;
                case ObsLeftLogType.ObsLog:
                    serializer.Serialize(writer, "obs_log");
                    return;
                case ObsLeftLogType.SenLeftLog:
                    serializer.Serialize(writer, "sen_left_log");
                    return;
                case ObsLeftLogType.SenLog:
                    serializer.Serialize(writer, "sen_log");
                    return;
            }
            throw new Exception("Cannot marshal type ObsLeftLogType");
        }

        public static readonly ObsLeftLogTypeConverter Singleton = new ObsLeftLogTypeConverter();
    }
}
