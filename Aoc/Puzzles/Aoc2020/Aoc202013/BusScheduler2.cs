using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202013;

public class BusScheduler2(string input)
{
    private readonly List<string> _busDepartureMinutes = input.Split(LineBreaks.Single)[1].Split(',').ToList();

    public long GetContestMinute()
    {
        var buses = new List<Bus>();
        for (var i = 0; i < _busDepartureMinutes.Count; i++)
        {
            var busStr = _busDepartureMinutes[i];
            if (busStr != "x") 
                buses.Add(new Bus(long.Parse(busStr), i));
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

    private static bool IsMatching(IEnumerable<Bus> currentBuses, long time) =>
        currentBuses.All(o => IsMatching(o, time));

    private static bool IsMatching(Bus bus, long time) => (time + bus.Delay) % bus.Id == 0;

    private record Bus(long Id, long Delay);
}