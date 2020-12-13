using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.BusSchedule
{
    public class BusScheduler2
    {
        private int _earliestMinute;
        private readonly List<string> _busDepartureMinutes;

        public BusScheduler2(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            _earliestMinute = int.Parse(rows[0]);
            _busDepartureMinutes = rows[1].Split(',').ToList();
        }

        public long GetContestMinute()
        {
            var buses = new List<BusMinute>();
            for (var i = 0; i < _busDepartureMinutes.Count; i++)
            {
                var busStr = _busDepartureMinutes[i];
                if (busStr != "x")
                {
                    buses.Add(new BusMinute(long.Parse(busStr), i));
                }
            }

            buses = buses.OrderByDescending(o => o.Bus).ToList();
            var startBus = buses.First();
            var increment = startBus.Bus;
            var time = increment - startBus.Delay;
            var busCount = 1;

            while (busCount <= buses.Count)
            {
                var currentBuses = buses.Take(busCount).ToList();
                while (!FoundAllMatches(currentBuses, time))
                    time += increment;

                increment = currentBuses.Select(t => t.Bus).Aggregate(MathTools.Lcm);
                busCount++;
            }

            return time;
        }

        private bool FoundAllMatches(List<BusMinute> currentBuses, long time)
        {
            return currentBuses.All(t => (time + t.Delay) % t.Bus == 0);
        }

        private class BusMinute
        {
            public long Bus { get; }
            public long Delay { get; }

            public BusMinute(long bus, long delay)
            {
                Bus = bus;
                Delay = delay;
            }
        }
    }
}