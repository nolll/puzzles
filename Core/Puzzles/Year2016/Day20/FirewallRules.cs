using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2016.Day20
{
    public class FirewallRules
    {
        private readonly string _input;

        public FirewallRules(string input)
        {
            _input = input;
        }

        public long? GetLowestUnblockedIp()
        {
            var blockedRanges = PuzzleInputReader.ReadLines(_input).Select(ParseIpRange).OrderBy(o => o.Start).ToArray();
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

        public long GetAllowedIpCount(long upperbound)
        {
            var rangesWithoutOverlaps = new List<IpRange>();
            var blockedRanges = PuzzleInputReader.ReadLines(_input).Select(ParseIpRange).ToList();
            while (blockedRanges.Any())
            {
                var range = blockedRanges.First();
                var others = blockedRanges.Skip(1);

                var overlapping = others.FirstOrDefault(o => o.IsOverlapping(range));
                if (overlapping != null)
                {
                    var min = Math.Min(range.Start, overlapping.Start);
                    var max = Math.Max(range.End, overlapping.End);
                    var newRange = new IpRange(min, max);
                    blockedRanges.Remove(overlapping);
                    blockedRanges.Add(newRange);
                }
                else
                {
                    rangesWithoutOverlaps.Add(range);
                }

                blockedRanges.RemoveAt(0);
            }

            return upperbound + 1 - rangesWithoutOverlaps.Sum(o => o.Length);
        }

        private IpRange ParseIpRange(string s)
        {
            var parts = s.Split('-');
            return new IpRange(long.Parse(parts[0]), long.Parse(parts[1]));
        }
    }
}