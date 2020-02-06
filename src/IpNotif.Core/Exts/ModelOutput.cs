using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IpNotif.Core.Models;

namespace IpNotif.Core.Exts {
    public static class ModelOutput {

        public static string ToDisplay(this IpResult model, string header = "") {
            var sb = new StringBuilder();
            sb.AppendLine(header);
            try {
                sb.AppendLine($"Get info for IP : {model.Ip}");
                sb.AppendLine("--------------------------------------------------------");
                sb.AppendLine($"host : {model.Hostname}");
                sb.AppendLine($"ip : {model.Ip}");
                sb.AppendLine($"ip-type : {model.IpType}");
                sb.AppendLine($"requester-ip : {model.RequesterIp}");
                sb.AppendLine($"Status code : {model.StatusCode}");

                if (model.Asn != null) {
                    sb.AppendLine("********** ISP info :");
                    sb.AppendLine($"name : {model.Asn.Name}");
                    sb.AppendLine($"type : {model.Asn.Type}");
                    sb.AppendLine($"domain : {model.Asn.Domain}");
                    sb.AppendLine($"organization : {model.Asn.Organization}");
                }

                if (model.Geo != null) {
                    sb.AppendLine("********** GEO info :");
                    sb.AppendLine($"continent-code : {model.Geo.ContinentCode}");
                    sb.AppendLine($"continent-name : {model.Geo.ContinentName}");
                    sb.AppendLine($"country : {model.Country.ContinentName}");
                    sb.AppendLine($"country iso : {model.Country.CountryIsoCode}");
                    sb.AppendLine($"zip-code : {model.Geo.ZipCode}");
                    sb.AppendLine($"capital : {model.Country.Capital}");
                    sb.AppendLine($"is-metric : {model.Geo.IsMetric}");
                    sb.AppendLine($"longitude : {model.Geo.Longitude}");
                    sb.AppendLine($"latitude : {model.Geo.Latitude}");
                    sb.AppendLine($"country-geo-id : {model.Geo.CountryGeoId}");
                }

                if (model.Timezone != null) {
                    sb.AppendLine("********** Timezone :");
                    sb.AppendLine($"{model.Timezone.IanaName}");
                    sb.AppendLine($"name : {model.Timezone.MicrosoftName}");
                    sb.AppendLine($"day-light-saving : {model.Timezone.IsDaylightSaving}");
                }

                if (model.Security != null) {
                    sb.AppendLine("********** Security :");
                    sb.AppendLine($"is-crawler : {model.Security.IsCrawler}");
                    sb.AppendLine($"is-tor : {model.Security.IsTor}");
                    sb.AppendLine($"is-proxy : {model.Security.IsProxy}");
                }

                sb.AppendLine(Environment.NewLine);
            }
            catch {
                sb.AppendLine($"_____________Error : cannot parse info.");
            }
            return sb.ToString();

        }

        public static void ToFile(this IpResult model, string path) {
            if (model == null)
                throw new ArgumentNullException("The model is null.");

            using (var writer = new StreamWriter(path, append: true, encoding: Encoding.UTF8)) {
                writer.Write(model.ToDisplay());
                writer.Flush();
                writer.Close();
            }
        }


        public static string ToDisplay(this List<string> model, string header = "") {
            var sb = new StringBuilder();
            sb.AppendLine(header);
            try {
                int i = 1;
                foreach (var ip in model) {
                    sb.AppendLine($"{i}-{ip}");
                }
            }
            catch {
                sb.AppendLine("______________Error : Cannot get local ip addresses.");
            }
            return sb.ToString();
        }

    }
}
