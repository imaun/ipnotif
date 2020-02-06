using Newtonsoft.Json;

namespace IpNotif.Core.Models {
    public class Crypto {
        [JsonProperty("is-crypto-node")]
        public bool Is_crypto_node { get; set; }
        [JsonProperty("crypto-insights")]
        public object crypto_insights { get; set; }
    }
}
