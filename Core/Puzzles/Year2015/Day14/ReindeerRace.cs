using System.Collections.Generic;
using System.Linq;
using Core.Common.Strings;

namespace Core.Puzzles.Year2015.Day14
{
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

        private int GetWinningScore(IList<Reindeer> reindeers, int time)
        {
            for (var i = 1; i <= time; i++)
            {
                var distances = new List<(int distance, Reindeer reindeer)>();
                foreach (var reindeer in reindeers)
                {
                    distances.Add((reindeer.DistanceAfter(i), reindeer));
                }

                var ordered = distances.OrderByDescending(o => o.distance).ToList();
                var maxValue = ordered.First().distance;
                var leaders = ordered.Where(o => o.distance == maxValue).Select(o => o.reindeer);

                foreach (var leader in leaders)
                {
                    leader.IncreaseScore();
                }
            }
            return reindeers.Max(o => o.Score);
        }

        private IList<Reindeer> ParseReindeers(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            return rows.Select(ParseReindeer).ToList();
        }

        private Reindeer ParseReindeer(string str)
        {
            var parts = str.Split(' ');
            var name = parts[0];
            var speed = int.Parse(parts[3]);
            var flyTime = int.Parse(parts[6]);
            var restTime = int.Parse(parts[13]);

            return new Reindeer(name, speed, flyTime, restTime);
        }
    }
}