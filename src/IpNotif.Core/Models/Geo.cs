using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Geo {
        [JsonProperty("is-metric")]
        public bool IsMetric { get; set; }

        [JsonProperty("is-in-europe")]
        public bool IsInEurope { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("country-geo-id")]
        public long CountryGeoId { get; set; }

        [JsonProperty("zip-code")]
        public object ZipCode { get; set; }

        [JsonProperty("city")]
        public object City { get; set; }

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

        [JsonProperty("country-iso-code")]
        public string CountryIsoCode { get; set; }
    }
}
