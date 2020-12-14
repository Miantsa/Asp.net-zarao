using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace Desktop_zarao
{
    static class IpClasse
    {
        private static String Ip { get; set; }
        public static String GetIp() {
            IPHostEntry IpEntry = Dns.GetHostEntry(Environment.MachineName);
            foreach (var ip in IpEntry.AddressList) { 
                if(ip.AddressFamily==AddressFamily.InterNetwork){
                    Ip=ip.ToString();
                    return Ip;
                }
            }
            return null;
        }
    }
}
