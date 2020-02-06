using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Device {
        [JsonProperty("brand")]
        public string Brand { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("family")]
        public string Family { get; set; }
    }
}
