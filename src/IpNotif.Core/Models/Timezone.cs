using System;
using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Timezone {
        [JsonProperty("is-daylight-saving")]
        public bool IsDaylightSaving { get; set; }

        [JsonProperty("gmt-offset")]
        public long GmtOffset { get; set; }

        [JsonProperty("date-time")]
        public DateTimeOffset DateTime { get; set; }

        [JsonProperty("microsoft-name")]
        public string MicrosoftName { get; set; }

        [JsonProperty("iana-name")]
        public string IanaName { get; set; }
    }
}
