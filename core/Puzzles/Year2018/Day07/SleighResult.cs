namespace Core.Puzzles.Year2018.Day07;

public class SleighResult
{
    public string Order { get; }
    public int Time { get; }

    public SleighResult(string order, int time)
    {
        Order = order;
        Time = time;
    }
}