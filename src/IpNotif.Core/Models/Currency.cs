using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Currency {
        [JsonProperty("native-name")]
        public string NativeName { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }
    }
}
