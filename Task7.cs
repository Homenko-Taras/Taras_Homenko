using System;

namespace IpConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an unsigned 32 bit integer:");
            string input = Console.ReadLine();
            uint ip = Convert.ToUInt32(input);
            string ipString = intToIp(ip);
            Console.WriteLine("IPv4 address: " + ipString);
        }
        static string intToIp(uint ip)
        {
            return string.Format("{0}.{1}.{2}.{3}", (ip >> 24) & 0xff, (ip >> 16) & 0xff, (ip >> 8) & 0xff, ip & 0xff);
        }
    }
}