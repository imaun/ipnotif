using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Security {
        [JsonProperty("is-crawler")]
        public bool IsCrawler { get; set; }

        [JsonProperty("is-proxy")]
        public bool IsProxy { get; set; }

        [JsonProperty("is-tor")]
        public bool IsTor { get; set; }

        [JsonProperty("tor-insights")]
        public object TorInsights { get; set; }

        [JsonProperty("proxy-insights")]
        public object ProxyInsights { get; set; }

        [JsonProperty("crawler-insights")]
        public object CrawlerInsights { get; set; }
    }
}
