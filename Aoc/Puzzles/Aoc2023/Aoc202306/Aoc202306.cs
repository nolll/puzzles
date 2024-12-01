using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202306;

[Name("Wait For It")]
public class Aoc202306 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = BoatRace1(input);

        return new PuzzleResult(result, "7eb8c120d057c526ef2c425f6db9493c");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = BoatRace2(input);

        return new PuzzleResult(result, "365c29b8564f3c2e47e2bcfca7b191de");
    }

    public static long BoatRace1(string input)
    {
        var lines = StringReader.ReadLines(input);
        var times = lines.First().Split(":").Last().Split(' ').Where(o => o.Length > 0).Select(int.Parse).ToList();
        var distances = lines.Last().Split(":").Last().Split(' ').Where(o => o.Length > 0).Select(int.Parse).ToList();

        var total = 1L;
        for (var raceIndex = 0; raceIndex < times.Count; raceIndex++)
        {
            var time = times[raceIndex];
            var targetDistance = distances[raceIndex];
            
            total *= BoatRace(time, targetDistance);
        }

        return total;
    }

    public static long BoatRace2(string input)
    {
        var lines = StringReader.ReadLines(input);
        var time = long.Parse(string.Join("", lines.First().Split(":").Last().Split(' ').Where(o => o.Length > 0)));
        var targetDistance = long.Parse(string.Join("", lines.Last().Split(":").Last().Split(' ').Where(o => o.Length > 0)));

        return BoatRace(time, targetDistance);
    }

    private static long BoatRace(long time, long targetDistance)
    {
        var count = 0L;
        for (var charge = 0; charge < time; charge++)
        {
            var travelTime = time - charge;
            var distance = travelTime * charge;
            if (distance > targetDistance)
                count++;
        }

        return count;
    }
}