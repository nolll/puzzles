using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.IpFirewall
{
    public class FirewallRules
    {
        private readonly string _input;

        public FirewallRules(string input)
        {
            _input = input;
        }

        public long? GetLowestUnblockedIp(long upperbound)
        {
            var blockedRanges = PuzzleInputReader.Read(_input).Select(ParseIpRange).OrderBy(o => o.Start).ToArray();
            long ip = 0;
            while (true)
            {
                var range = blockedRanges.FirstOrDefault(o => o.IsInRange(ip));
                if (range == null)
                    break;
                ip = range.End + 1;
            }

            return ip;
        }

        private IpRange ParseIpRange(string s)
        {
            var parts = s.Split('-');
            return new IpRange(long.Parse(parts[0]), long.Parse(parts[1]));
        }
    }
}