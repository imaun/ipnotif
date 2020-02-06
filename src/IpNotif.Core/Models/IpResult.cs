using System;
using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class IpResult {

        public IpResult() {
            CreateDateTime = DateTime.UtcNow;
        }

        public string JsonContent { get; set; }

        public DateTime CreateDateTime { get; set; }

        [JsonProperty("status-code")]
        public long StatusCode { get; set; }

        [JsonProperty("geo")]
        public Geo Geo { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("asn")]
        public Asn Asn { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        [JsonProperty("timezone")]
        public Timezone Timezone { get; set; }

        [JsonProperty("security")]
        public Security Security { get; set; }

        [JsonProperty("crypto")]
        public object Crypto { get; set; }

        [JsonProperty("user-agent")]
        public object UserAgent { get; set; }

        [JsonProperty("execution-time")]
        public string ExecutionTime { get; set; }

        [JsonProperty("error")]
        public object Error { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("ip-type")]
        public string IpType { get; set; }

        [JsonProperty("requester-ip")]
        public string RequesterIp { get; set; }

        [JsonProperty("ip")]
        public string Ip { get; set; }
    }
}
