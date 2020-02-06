using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpNotif.Core;
using IpNotif.Core.Exts;
using IpNotif.Core.Models;

namespace IpNotif {
    class Program {
        static void Main(string[] args) {

            List<string> inputAddresses = new List<string>();
            if(args != null && args.Any()) {
                foreach(var arg in args) {
                    inputAddresses.Add(arg);
                }
            }

            Console.WriteLine("____________IpNotif v0.0.1________________________________");
            Console.WriteLine("____________Get information about any IP address__________");
            Console.WriteLine("____Run without any argument to show your public IP information.");
            Console.WriteLine("____Pass as many public IP addresses or host names as arguments, seperated by space, and IpNotif will give you their informations.");
            Console.WriteLine();

            using (var client = new IpNotifClient()) {

                if(inputAddresses.Any()) {
                    foreach(var ip in inputAddresses) {

                        if(ip.ToUpper() == "LOCAL" || ip.ToUpper() == "LOCALHOST") {

                            var ipV4List = LocalIpAddressProvider.GetV4StringList();
                            if(ipV4List != null && ipV4List.Any())
                                Console.WriteLine(ipV4List.ToDisplay("__________IPv4 addresses :"));

                            var ipV6List = LocalIpAddressProvider.GetV6StringList();
                            if (ipV6List != null && ipV6List.Any())
                                Console.WriteLine(ipV6List.ToDisplay("__________IPv6 addresses :"));

                            continue;
                        }

                        if(char.IsLetter(ip.FirstOrDefault())) {
                            try {
                                var hostIp = HostIpFinder.GetIp(ip);
                                var tskGetHostIpInfo = Task.Run(() => client.GetIpInfo(hostIp));
                                tskGetHostIpInfo.Wait();
                                Console.WriteLine(tskGetHostIpInfo.Result
                                    .ToDisplay($"__________Get IP info for '{ip}'"));
                            }
                            catch {
                                Console.WriteLine($"________Error get info for host '{ip}' failed.");
                            }
                            continue;
                        }

                        try
                        {
                            var tskGetIpInfo = Task.Run(() => client.GetIpInfo(ip));
                            tskGetIpInfo.Wait();
                            Console.WriteLine(tskGetIpInfo.Result.ToDisplay());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Error : {e.GetBaseException().Message}");
                        }
                        
                    }
                }
                else {

                    try
                    {
                        Task<IpResult> tskMyIp = Task.Run(() => client.GetMyIp());
                        tskMyIp.Wait();
                        Console.Write(tskMyIp.Result.ToDisplay("____________Your IP info"));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"____________Your IP info");
                        Console.WriteLine($"Your IP is : {ExternalIpProvider.GetExternalIPAddress()}");
                    }
                }
            }

            Console.WriteLine("IpNotif v0.0.1 - press any key to exit...");
            Console.Read();
        }

        
    }
}
