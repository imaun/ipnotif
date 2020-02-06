using System.Linq;
using System.Net;

namespace IpNotif.Core {
    public static class HostIpFinder {
        public static string GetIp(string host) {
            var entry = Dns.GetHostEntry(host)
                .AddressList
                .First(addr => addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
            return entry.ToString();
        }
    }
}
