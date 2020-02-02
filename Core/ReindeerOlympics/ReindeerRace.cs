using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ReindeerOlympics
{
    public class ReindeerRace
    {
        public int WinningDistance { get; }

        public ReindeerRace(string input, int time)
        {
            var reindeers = ParseReindeers(input);

            WinningDistance = reindeers.Max(o => o.DistanceAfter(time));
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
        public string Name { get; }
        public int Speed { get; }
        public int FlyTime { get; }
        public int RestTime { get; }

        private int Period => FlyTime + RestTime;

        public Reindeer(string name, in int speed, in int flyTime, in int restTime)
        {
            Name = name;
            Speed = speed;
            FlyTime = flyTime;
            RestTime = restTime;
        }

        public int DistanceAfter(in int seconds)
        {
            var completedPeriods = (int)Math.Floor((decimal)seconds / Period);
            var secondsInCurrentPeriod = seconds % Period;
            var flySecondsInCurrentPeriod = secondsInCurrentPeriod > FlyTime
                ? FlyTime
                : secondsInCurrentPeriod;

            var totalFlySeconds = completedPeriods * FlyTime + flySecondsInCurrentPeriod;
            return totalFlySeconds * Speed;
        }
    }
}