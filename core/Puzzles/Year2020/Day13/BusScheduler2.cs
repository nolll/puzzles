using System.Collections.Generic;
using System.Linq;
using Core.Common.Maths;
using Core.Common.Strings;

namespace Core.Puzzles.Year2020.Day13;

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
        var buses = new List<Bus>();
        for (var i = 0; i < _busDepartureMinutes.Count; i++)
        {
            var busStr = _busDepartureMinutes[i];
            if (busStr != "x")
            {
                buses.Add(new Bus(long.Parse(busStr), i));
            }
        }

        buses = buses.OrderByDescending(o => o.Id).ToList();
        var startBus = buses.First();
        var increment = startBus.Id;
        var time = increment - startBus.Delay;
        var busCount = 1;

        while (busCount <= buses.Count)
        {
            var currentBuses = buses.Take(busCount).ToList();
            while (!IsMatching(currentBuses, time))
                time += increment;

            increment = currentBuses.Select(t => t.Id).Aggregate(MathTools.Lcm);
            busCount++;
        }

        return time;
    }

    private static bool IsMatching(IEnumerable<Bus> currentBuses, long time)
    {
        return currentBuses.All(o => IsMatching(o, time));
    }

    private static bool IsMatching(Bus bus, long time)
    {
        return (time + bus.Delay) % bus.Id == 0;
    }

    private class Bus
    {
        public long Id { get; }
        public long Delay { get; }

        public Bus(long id, long delay)
        {
            Id = id;
            Delay = delay;
        }
    }
}