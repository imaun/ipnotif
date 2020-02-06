using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Location {
        [JsonProperty("metro-code")]
        public object MetroCode { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("zip-code")]
        public object ZipCode { get; set; }

        [JsonProperty("city")]
        public object City { get; set; }
    }
}
