namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201807;

public class SleighWorker
{
    public SleighStep? Task { get; set; }
    public int TimeLeft { get; set; }
    public bool IsIdle => TimeLeft == 0 && Task == null;
    public bool IsFinished => TimeLeft == 0 && Task != null;
    public bool IsWorking => Task != null;

    public void DecreaseTime()
    {
        if (TimeLeft > 0)
            TimeLeft -= 1;
    }
}