using System;

namespace App.Puzzles.Year2018.Day04;

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