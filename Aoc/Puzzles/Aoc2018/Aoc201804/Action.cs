namespace Puzzles.Aoc.Puzzles.Aoc2018.Aoc201804;

public class Action
{
    public DateTime Timestamp { get; }
    public ActionType EventType { get; }

    public Action(DateTime timestamp, ActionType eventType)
    {
        Timestamp = timestamp;
        EventType = eventType;
    }
}