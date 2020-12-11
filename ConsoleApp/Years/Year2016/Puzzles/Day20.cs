using System;
using Core.IpFirewall;

namespace ConsoleApp.Years.Year2016.Puzzles
{
    public class Day20 : Day2016
    {
        public Day20() : base(20)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var rules = new FirewallRules(FileInput);
            var ip = rules.GetLowestUnblockedIp();
            return new PuzzleResult($"Lowest unblocked ip: {ip}");
        }

        public override PuzzleResult RunPart2()
        {
            var rules = new FirewallRules(FileInput);
            var ipCount = rules.GetAllowedIpCount(Upperbound);
            return new PuzzleResult($"Number of allowed ips: {ipCount}");
        }

        private const long Upperbound = 4_294_967_295;
    }
}