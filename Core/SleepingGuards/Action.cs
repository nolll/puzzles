using System;

namespace Core.SleepingGuards
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