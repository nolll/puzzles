namespace App.Puzzles.Year2018.Day04
{
    public class GuardNight
    {
        private int _currentMinute;
        private GuardState _currentState = GuardState.Awake;
        public GuardState[] MinuteStates { get; }
        public int GuardId { get; }

        public GuardNight(int guardId)
        {
            GuardId = guardId;
            MinuteStates = new GuardState[60];
        }

        public void AddAction(Action action)
        {
            var actionMinute = action.Timestamp.Minute;
            for (; _currentMinute < actionMinute; _currentMinute++)
            {
                MinuteStates[_currentMinute] = _currentState;
            }

            _currentState = action.EventType == ActionType.FallAsleep ? GuardState.Asleep : GuardState.Awake;
        }

        public int TimeAsleep
        {
            get
            {
                var asleepCount = 0;
                for (var i = 0; i < MinuteStates.Length; i++)
                {
                    if (MinuteStates[i] == GuardState.Asleep)
                        asleepCount++;
                }

                return asleepCount;
            }
        }
    }
}