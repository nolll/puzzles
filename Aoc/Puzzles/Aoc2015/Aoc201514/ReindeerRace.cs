using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201514;

public class ReindeerRace
{
    public int WinningDistance { get; }
    public int WinningScore { get; }

    public ReindeerRace(string input, int time)
    {
        var reindeers = ParseReindeers(input);

        WinningDistance = reindeers.Max(o => o.DistanceAfter(time));
        WinningScore = GetWinningScore(reindeers, time);
    }

    private static int GetWinningScore(IList<Reindeer> reindeers, int time)
    {
        for (var i = 1; i <= time; i++)
        {
            var distances = reindeers.Select(reindeer => (distance: reindeer.DistanceAfter(i), reindeer))
                .OrderByDescending(o => o.distance)
                .ToList();
            var maxValue = distances.First().distance;
            var leaders = distances.Where(o => o.distance == maxValue).Select(o => o.reindeer);

            foreach (var leader in leaders)
            {
                leader.IncreaseScore();
            }
        }
        return reindeers.Max(o => o.Score);
    }

    private static IList<Reindeer> ParseReindeers(string input) => 
        StringReader.ReadLines(input).Select(ParseReindeer).ToList();

    private static Reindeer ParseReindeer(string str)
    {
        var ints = Numbers.IntsFromString(str);
        var speed = ints[0];
        var flyTime = ints[1];
        var restTime = ints[2];

        return new Reindeer(speed, flyTime, restTime);
    }
}