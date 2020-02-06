using System;
using System.Net;
using System.Net.Http;
using System.Globalization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using IpNotif.Core.Models;

namespace IpNotif.Core {
    public class IpNotifClient: IDisposable {
        private const string __BASE_URL = "https://api.smartip.io/";
        private const string __API_KEY = "d51872ff-a0d6-4a4e-8331-cd4b62ab7c21";

        private readonly HttpClient _httpClient;

        public IpNotifClient() {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            _httpClient = new HttpClient();
        }

        public async Task<IpResult> GetMyIp() {
            var url = $"{__BASE_URL}?api_key={__API_KEY}";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            IpResult result = json.ToIpResult();
            result.JsonContent = json;
            return result;
        }

        public async Task<IpResult> GetIpInfo(string ipAddress) {
            var url = $"{__BASE_URL}{ipAddress}?api_key={__API_KEY}";
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            IpResult result = json.ToIpResult();
            result.JsonContent = json;
            return result;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    _httpClient.Dispose();
                }
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~IpNotifClient()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

    public static class Deserialize {
        public static IpResult ToIpResult(this string content) 
            => JsonConvert.DeserializeObject<IpResult>(content, Converter.Settings);
    }

    internal static class Converter {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }
}
