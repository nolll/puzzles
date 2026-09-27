using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("Firewall Rules")]
public class Aoc201620 : AocPuzzle
{
    private const long Upperbound = 4_294_967_295;
    
    [Puzzle("42063a29b0e82221aa3b4cc217180990")]
    public long Part1(string input) => new FirewallRules(input).GetLowestUnblockedIp() ?? 0;

    [Puzzle("38db809093eca7ea30cbfbd9e031ac13")]
    public long Part2(string input) => new FirewallRules(input).GetAllowedIpCount(Upperbound);
    
    public class FirewallRules(string input)
    {
        public long? GetLowestUnblockedIp()
        {
            var blockedRanges = input.Split(LineBreaks.Single).Select(ParseIpRange).OrderBy(o => o.Start).ToArray();
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
            var blockedRanges = input.Split(LineBreaks.Single).Select(ParseIpRange).ToList();
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

        private static IpRange ParseIpRange(string s)
        {
            var parts = s.Split('-');
            return new IpRange(long.Parse(parts[0]), long.Parse(parts[1]));
        }
    }
    
    public class IpRange
    {
        public long Start { get; }
        public long End { get; }
        public long Length => End - Start + 1;
        
        public IpRange(long start, long end)
        {
            Start = start;
            End = end;
        }

        public bool IsInRange(long ip)
        {
            return ip >= Start && ip <= End;
        }

        public bool IsOverlapping(IpRange other)
        {
            return Start < other.End && other.Start < End;
        }

        protected bool Equals(IpRange other)
        {
            return Start == other.Start && End == other.End;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Start, End);
        }
    }
}