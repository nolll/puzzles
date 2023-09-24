using System;

namespace Aoc.Puzzles.Aoc2018.Day04;

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