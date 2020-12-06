using System;
using Core.IpFirewall;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day20 : Day2016
    {
        public Day20() : base(20)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var rules = new FirewallRules(FileInput);
            var ip = rules.GetLowestUnblockedIp();
            Console.WriteLine($"Lowest unblocked ip: {ip}");

            WritePartTitle();
            var ipCount = rules.GetAllowedIpCount(Upperbound);
            Console.WriteLine($"Number of allowed ips: {ipCount}");
        }

        private const long Upperbound = 4_294_967_295;
    }
}