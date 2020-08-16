using Newtonsoft.Json;
using System.Net;

namespace DarkSide.Web.Base.WebClientBase
{
    public class DarkSideWebClientHandler
    {
        public T Get<T>(string url, JsonSerializerSettings jsonSettings = null)
        {
            using var webClient = new WebClient();
            var obj = webClient.DownloadString(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(obj, jsonSettings);
        }
    }
}
