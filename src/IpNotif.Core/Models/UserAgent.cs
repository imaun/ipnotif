using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class UserAgent {
        [JsonProperty("os")]
        public Os Os { get; set; }

        [JsonProperty("device")]
        public Device Device { get; set; }

        [JsonProperty("engine-version")]
        public string EngineVersion { get; set; }

        [JsonProperty("engine")]
        public string Engine { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("family")]
        public string Family { get; set; }

        
    }
}
