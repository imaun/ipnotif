using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace IpNotif.Core {
    public static class LocalIpAddressProvider {

        public static List<IPAddress> GetV4List() {
            var result = new List<IPAddress>();
            NetworkInterface.GetAllNetworkInterfaces().ToList().ForEach(ni => {
                if (ni.GetIPProperties().GatewayAddresses.FirstOrDefault() != null) {
                    ni.GetIPProperties().UnicastAddresses.ToList().ForEach(ua => {
                        if (ua.Address.AddressFamily == AddressFamily.InterNetwork) 
                            result.Add(ua.Address);
                    });
                }
            });
            return result
                .Distinct()
                .ToList();
        }

        public static List<string> GetV4StringList() {
            var ipList = GetV4List();
            if(ipList.Any()) {
                return ipList.Select(x => x.ToString()).ToList();
            }
            return null;
        }

        public static List<IPAddress> GetV6List() {
            var result = new List<IPAddress>();
            NetworkInterface.GetAllNetworkInterfaces().ToList().ForEach(ni => {
                if (ni.GetIPProperties().GatewayAddresses.FirstOrDefault() != null) {
                    ni.GetIPProperties().UnicastAddresses.ToList().ForEach(ua => {
                        if (ua.Address.AddressFamily == AddressFamily.InterNetworkV6) 
                            result.Add(ua.Address);
                    });
                }
            });

            return result
                .Distinct()
                .ToList();
        }
        public static List<string> GetV6StringList() {
            var ipList = GetV6List();
            if (ipList.Any()) {
                return ipList.Select(x => x.ToString()).ToList();
            }
            return null;
        }

    }
}
