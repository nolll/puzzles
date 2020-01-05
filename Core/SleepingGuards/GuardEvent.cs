using System;

namespace Core.SleepingGuards
{
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
}