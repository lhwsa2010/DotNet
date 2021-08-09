using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DotNet.Tool
{
    /// <summary>
    /// Localhost
    /// </summary>
    public class Localhost
    {
        /// <summary>
        /// Get host available ip.
        /// </summary>
        /// <returns></returns>
        public static IPAddress GetIP()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in ipHostInfo.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip;
            }
            return ipHostInfo.AddressList.FirstOrDefault();
        }
    }
}
