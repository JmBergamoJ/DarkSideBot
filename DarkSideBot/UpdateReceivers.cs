﻿using DarkSide.Models.Bot;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DarkSideBot
{
    public static class UpdateReceivers
    {
        private const string Path = "Resources/PatchList";
        public static readonly List<SendData> Patches;

        static UpdateReceivers()
        {
            if (File.Exists(Path))
            {
                var data = File.ReadAllText(Path);
                Patches = JsonConvert.DeserializeObject<List<SendData>>(data);
            }
            else
            {
                Patches = new List<SendData>();
                Save();
            }
        }

        private static void Save()
        {
            var obj = JsonConvert.SerializeObject(Patches);
            File.WriteAllText(Path, obj);
        }

        public static void Append(SendData data)
        {
            Patches.Add(data);
            Save();
        }

        public static void Remove(ulong guildId)
        {
            var does = false;
            SendData sendData = null;
            foreach (SendData data in Patches)
            {
                if (data.GuildId == guildId)
                {
                    does = true;
                    sendData = data;
                }
            }

            if (does)
            {
                Patches.Remove(sendData);
            }

            Save();
        }
    }
}
