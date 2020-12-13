using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.BusSchedule
{
    public class BusScheduler1
    {
        private readonly int _earliestMinute;
        private readonly List<int> _busDepartureMinutes;

        public BusScheduler1(string input)
        {
            var rows = PuzzleInputReader.ReadLines(input);
            _earliestMinute = int.Parse(rows[0]);
            _busDepartureMinutes = rows[1].Split(',').Where(o => o != "x").Select(int.Parse).ToList();
        }

        public int GetBusValue()
        {
            var buses = _busDepartureMinutes.Select(o => new BusMinute(o, o - _earliestMinute % o)).ToList();
            var bestBus = buses.OrderBy(o => o.WaitMinutes).First();
            return bestBus.Bus * bestBus.WaitMinutes;
        }

        private class BusMinute
        {
            public int Bus { get; }
            public int WaitMinutes { get; }

            public BusMinute(int bus, int waitMinutes)
            {
                Bus = bus;
                WaitMinutes = waitMinutes;
            }
        }
    }
}