using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023;

[Name("Wait For It")]
public class Aoc202306 : AocPuzzle
{
    [Puzzle("7eb8c120d057c526ef2c425f6db9493c")]
    public long Part1(string input)
    {
        var (first, last) = input.Split(LineBreaks.Single);
        var times = Numbers.IntsFromString(first);
        var distances = Numbers.IntsFromString(last);
        return times.Zip(distances, (t, d) => BoatRace(t, d)).Aggregate(1L, (total, race) => total * race);
    }

    [Puzzle("365c29b8564f3c2e47e2bcfca7b191de")]
    public long Part2(string input)
    {
        var (first, last) = input.Split(LineBreaks.Single);
        var time = long.Parse(string.Concat(Numbers.DigitsFromString(first)));
        var targetDistance = long.Parse(string.Concat(Numbers.DigitsFromString(last)));
        return BoatRace(time, targetDistance);
    }

    private static long BoatRace(long time, long targetDistance)
    {
        var count = 0;
        for (var charge = 0; charge < time; charge++)
        {
            if ((time - charge) * charge > targetDistance)
                count++;
        }

        return count;
    }
}