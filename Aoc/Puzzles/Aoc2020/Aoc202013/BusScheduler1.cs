using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202013;

public class BusScheduler1
{
    private readonly int _earliestMinute;
    private readonly List<int> _busDepartureMinutes;

    public BusScheduler1(string input)
    {
        var rows = InputReader.ReadLines(input);
        _earliestMinute = int.Parse(rows[0]);
        _busDepartureMinutes = rows[1].Split(',').Where(o => o != "x").Select(int.Parse).ToList();
    }

    public int GetBusValue()
    {
        var buses = _busDepartureMinutes.Select(o => new Bus(o, o - _earliestMinute % o)).ToList();
        var bestBus = buses.OrderBy(o => o.Delay).First();
        return bestBus.Id * bestBus.Delay;
    }

    private class Bus
    {
        public int Id { get; }
        public int Delay { get; }

        public Bus(int id, int delay)
        {
            Id = id;
            Delay = delay;
        }
    }
}