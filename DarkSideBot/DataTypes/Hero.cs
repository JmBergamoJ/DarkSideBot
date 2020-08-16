using Newtonsoft.Json;

namespace DarkSideBot.DataTypes
{
    public class Hero
    {
        [JsonProperty("id")] 
        public long Id { get; set; }

        [JsonProperty("name")] 
        public string Name { get; set; }

        [JsonProperty("localized_name")] 
        public string LocalizedName { get; set; }
    }
}
