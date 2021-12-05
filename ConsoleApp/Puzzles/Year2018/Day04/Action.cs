using System;

namespace ConsoleApp.Puzzles.Year2018.Day04
{
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
}