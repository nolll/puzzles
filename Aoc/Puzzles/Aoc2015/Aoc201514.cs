using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Reindeer Olympics")]
public class Aoc201514 : AocPuzzle
{
    [Puzzle("730cd532676e91e7ec7210ec497bba1d")]
    public int Part1(string input) => GetWinningDistance(input, 2503);

    [Puzzle("d78ca8ddf15b143efbebe5519ac2abf1")]
    public int Part2(string input) => GetWinningScore(input, 2503);
    
    public int GetWinningDistance(string input, int time) => 
        ParseReindeers(input).Max(o => o.DistanceAfter(time));

    public int GetWinningScore(string input, int time) =>
        GetWinningScore(ParseReindeers(input), time);
    
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
        input.Split(LineBreaks.Single).Select(ParseReindeer).ToList();

    private static Reindeer ParseReindeer(string str)
    {
        var (speed, flyTime, restTime) = Numbers.IntsFromString(str);

        return new Reindeer(speed, flyTime, restTime);
    }

    private class Reindeer
    {
        private readonly int _period;
        private readonly int _speed;
        private readonly int _flyTime;

        public int Score { get; private set; }

        public Reindeer(int speed, int flyTime, int restTime)
        {
            _speed = speed;
            _flyTime = flyTime;
            _period = _flyTime + restTime;
        }

        public void IncreaseScore() => Score += 1;

        public int DistanceAfter(int seconds)
        {
            var completedPeriods = (int)Math.Floor((decimal)seconds / _period);
            var secondsInCurrentPeriod = seconds % _period;
            var flySecondsInCurrentPeriod = secondsInCurrentPeriod > _flyTime
                ? _flyTime
                : secondsInCurrentPeriod;

            var totalFlySeconds = completedPeriods * _flyTime + flySecondsInCurrentPeriod;
            return totalFlySeconds * _speed;
        }
    }
}