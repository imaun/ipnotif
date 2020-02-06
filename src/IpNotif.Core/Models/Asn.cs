using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Asn {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("organization")]
        public string Organization { get; set; }

        [JsonProperty("asn")]
        public string AsnAsn { get; set; }
    }
}
