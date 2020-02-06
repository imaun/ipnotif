using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Country {
        [JsonProperty("is-metric")]
        public bool IsMetric { get; set; }

        [JsonProperty("is-in-europe")]
        public bool IsInEurope { get; set; }

        [JsonProperty("region-geo-id")]
        public object RegionGeoId { get; set; }

        [JsonProperty("continent-geo-id")]
        public long ContinentGeoId { get; set; }

        [JsonProperty("country-geo-id")]
        public long CountryGeoId { get; set; }

        [JsonProperty("region-code")]
        public object RegionCode { get; set; }

        [JsonProperty("region-name")]
        public object RegionName { get; set; }

        [JsonProperty("continent-code")]
        public string ContinentCode { get; set; }

        [JsonProperty("continent-name")]
        public string ContinentName { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }

        [JsonProperty("country-name")]
        public string CountryName { get; set; }

        [JsonProperty("country-two-letter-iso-code")]
        public string CountryTwoLetterIsoCode { get; set; }

        [JsonProperty("country-iso-code")]
        public string CountryIsoCode { get; set; }
    }
}
