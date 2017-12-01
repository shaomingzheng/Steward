using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ICH.Core.Net
{
    public static class DnsHelper
    {
        /// <summary>
        /// 获取本地的IP地址
        /// </summary>
        /// <param name="ipv4">是否ipv4</param>
        /// <returns></returns>
        public static async Task<string> GetIpAddressAsync(bool ipv4 = true)
        {
            var hostEntry = await Dns.GetHostEntryAsync(Dns.GetHostName());
            IPAddress ipaddress;
            if (ipv4)
            {
                ipaddress = (from ip in hostEntry.AddressList where 
                             !IPAddress.IsLoopback(ip) && ip.AddressFamily == AddressFamily.InterNetwork
                             select ip)
                             .FirstOrDefault() ;
            }
            else
            {
                ipaddress = (from ip in hostEntry.AddressList where
                             !IPAddress.IsLoopback(ip) && ip.AddressFamily == AddressFamily.InterNetworkV6
                             select ip)
                             .FirstOrDefault();
            }
            return ipaddress != null ? ipaddress.ToString() : string.Empty;
        }
    }
}
