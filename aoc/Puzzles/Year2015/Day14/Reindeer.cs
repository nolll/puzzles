using System;

namespace Aoc.Puzzles.Year2015.Day14;

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