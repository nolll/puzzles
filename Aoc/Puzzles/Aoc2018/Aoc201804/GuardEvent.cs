namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201804;

public class GuardEvent
{
    public DateTime Timestamp { get; }
    public string Action { get; }

    public GuardEvent(DateTime timestamp, string action)
    {
        Timestamp = timestamp;
        Action = action;
    }
}