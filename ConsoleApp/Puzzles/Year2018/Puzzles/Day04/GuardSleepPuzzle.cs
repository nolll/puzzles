using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp.Puzzles.Year2018.Puzzles.Day04
{
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

            return guards.OrderByDescending(o => o.MostSleptMinuteCount).FirstOrDefault();
        }

        private List<GuardNight> GetNights(List<GuardEvent> events)
        {
            var nights = new List<GuardNight>();
            GuardNight guardNight = null;
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
                    guardNight.AddAction(action);
                }
            }
            return nights;
        }

        private int GetStrategyOneGuardId(List<GuardNight> nights)
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

        private int GetStrategyOneMinute(List<GuardNight> nights, int sleepiestGuardId)
        {
            var sleepiestMinute = 0;
            var highestSleepCount = 0;
            var guardNights = nights.Where(o => o.GuardId == sleepiestGuardId).ToList();
            for (int i = 0; i < 60; i++)
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
}