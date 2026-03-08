using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201620;

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