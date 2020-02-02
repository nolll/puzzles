using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ReindeerOlympics
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
            var rows = PuzzleInputReader.Read(input);
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

    public class Reindeer
    {
        private readonly int _period;

        public string Name { get; }
        public int Speed { get; }
        public int FlyTime { get; }
        public int RestTime { get; }
        public int Score { get; private set; }

        public Reindeer(string name, in int speed, in int flyTime, in int restTime)
        {
            Name = name;
            Speed = speed;
            FlyTime = flyTime;
            RestTime = restTime;
            Score = 0;
            _period = FlyTime + RestTime;
        }

        public void IncreaseScore()
        {
            Score += 1;
        }

        public int DistanceAfter(in int seconds)
        {
            var completedPeriods = (int)Math.Floor((decimal)seconds / _period);
            var secondsInCurrentPeriod = seconds % _period;
            var flySecondsInCurrentPeriod = secondsInCurrentPeriod > FlyTime
                ? FlyTime
                : secondsInCurrentPeriod;

            var totalFlySeconds = completedPeriods * FlyTime + flySecondsInCurrentPeriod;
            return totalFlySeconds * Speed;
        }
    }
}