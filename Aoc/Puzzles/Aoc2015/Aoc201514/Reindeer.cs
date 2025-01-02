namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201514;

public class Reindeer
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

    public int DistanceAfter(in int seconds)
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