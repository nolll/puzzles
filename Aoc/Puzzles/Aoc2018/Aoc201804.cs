using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Repose Record")]
public class Aoc201804 : AocPuzzle
{
    [Puzzle("5eac1b2a363e9607b7231acb68a5d38b")]
    public int Part1(string input) => new GuardSleepPuzzle(input).StrategyOneScore;

    [Puzzle("8b909b46ebe2d7587152380781205c23")]
    public int Part2(string input) => new GuardSleepPuzzle(input).StrategyTwoScore;

    public class GuardSleepPuzzle
    {
        public int StrategyOneGuardId { get; }
        public int StrategyOneMinute { get; }
        public int StrategyOneScore => StrategyOneGuardId * StrategyOneMinute;

        public int StrategyTwoGuardId { get; }
        public int StrategyTwoMinute { get; }
        public int StrategyTwoScore => StrategyTwoGuardId * StrategyTwoMinute;

        public GuardSleepPuzzle(string eventsString)
        {
            var events = GuardEventReader.Read(eventsString);
            var nights = GetNights(events);
            StrategyOneGuardId = GetStrategyOneGuardId(nights);
            StrategyOneMinute = GetStrategyOneMinute(nights, StrategyOneGuardId);

            var strategyTwoGuard = GetStrategyTwoGuard(nights);
            StrategyTwoGuardId = strategyTwoGuard.GuardId;
            StrategyTwoMinute = strategyTwoGuard.MostSleptMinute;
        }

        private Guard GetStrategyTwoGuard(List<GuardNight> nights)
        {
            var guardIds = nights.Select(o => o.GuardId).Distinct();
            var guards = new List<Guard>();
            foreach (var guardId in guardIds)
            {
                var guardNights = nights.Where(o => o.GuardId == guardId).ToList();
                var guard = new Guard(guardId, guardNights);
                guards.Add(guard);
            }

            return guards.OrderByDescending(o => o.MostSleptMinuteCount).First();
        }

        private List<GuardNight> GetNights(List<GuardEvent> events)
        {
            var nights = new List<GuardNight>();
            GuardNight? guardNight = null;
            foreach (var e in events)
            {
                var regex = new Regex(@"^Guard #(\d+).+$");
                var match = regex.Match(e.Action);
                if (match.Success)
                {
                    var id = int.Parse(match.Groups[1].Value);
                    guardNight = new GuardNight(id);
                    nights.Add(guardNight);
                }
                else
                {
                    var actionType = e.Action == "falls asleep" ? ActionType.FallAsleep : ActionType.WakeUp;
                    var action = new Action(e.Timestamp, actionType);
                    guardNight!.AddAction(action);
                }
            }

            return nights;
        }

        private static int GetStrategyOneGuardId(List<GuardNight> nights)
        {
            var orderedNights = nights.OrderBy(o => o.GuardId);
            var guardIds = orderedNights.Select(o => o.GuardId).Distinct();
            var guardIdWithMostSleep = 0;
            var mostSleepMinutes = 0;
            foreach (var id in guardIds)
            {
                var guardNights = nights.Where(o => o.GuardId == id);
                var sleepMinutes = guardNights.Sum(o => o.TimeAsleep);
                if (sleepMinutes > mostSleepMinutes)
                {
                    guardIdWithMostSleep = id;
                    mostSleepMinutes = sleepMinutes;
                }
            }

            return guardIdWithMostSleep;
        }

        private static int GetStrategyOneMinute(List<GuardNight> nights, int sleepiestGuardId)
        {
            var sleepiestMinute = 0;
            var highestSleepCount = 0;
            var guardNights = nights.Where(o => o.GuardId == sleepiestGuardId).ToList();
            for (var i = 0; i < 60; i++)
            {
                var minuteSleepCount = guardNights.Count(o => o.MinuteStates[i] == GuardState.Asleep);

                if (minuteSleepCount > highestSleepCount)
                {
                    sleepiestMinute = i;
                    highestSleepCount = minuteSleepCount;
                }
            }

            return sleepiestMinute;
        }
    }

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
    
    public class Guard
    {
        public int GuardId { get; }
        public int[] MinuteSleepCounts { get; }

        public Guard(int guardId, List<GuardNight> nights)
        {
            GuardId = guardId;
            MinuteSleepCounts = new int[60];

            foreach (var night in nights)
            {
                for (var i = 0; i < night.MinuteStates.Length; i++)
                {
                    if (night.MinuteStates[i] == GuardState.Asleep)
                        MinuteSleepCounts[i]++;
                }
            }
        }

        public int MostSleptMinuteCount => MinuteSleepCounts[MostSleptMinute];

        public int MostSleptMinute
        {
            get
            {
                var mostSleptMinuteCount = 0;
                var mostSleptMinute = 0;
                for (var i = 0; i < MinuteSleepCounts.Length; i++)
                {
                    if (MinuteSleepCounts[i] > mostSleptMinuteCount)
                    {
                        mostSleptMinuteCount = MinuteSleepCounts[i];
                        mostSleptMinute = i;
                    }
                }

                return mostSleptMinute;
            }
        }
    }
    
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
    
    public enum ActionType
    {
        FallAsleep,
        WakeUp
    }
    
    public static class GuardEventReader
    {
        private static readonly Regex GuardEventRegex = new(@"^\[(.+)\] (.+)$");
        
        public static List<GuardEvent> Read(string str) => 
            str.Split(LineBreaks.Single).Select(ConvertToGuardEvent).OrderBy(o => o.Timestamp).ToList();

        private static GuardEvent ConvertToGuardEvent(string str)
        {
            var match = GuardEventRegex.Match(str);
            var timestamp = GetTimeValue(match.Groups[1]);
            var action = match.Groups[2].Value;
            return new GuardEvent(timestamp, action);
        }

        private static DateTime GetTimeValue(Group matchGroup) => DateTime.Parse(matchGroup.Value);
    }
    
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
    
    public enum GuardState
    {
        Awake,
        Asleep
    }
}