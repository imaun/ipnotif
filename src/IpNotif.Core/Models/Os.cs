using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Os {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }
    }
}
