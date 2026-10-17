using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Shuttle Search")]
public class Aoc202013 : AocPuzzle
{
    [Puzzle("22dea96fc3fe7cf98d5ae3e3a29c196a")]
    public long Part1(string input)
    {
        var (row1, row2) = input.Split(LineBreaks.Single);
        var earliestMinute = int.Parse(row1);
        var bestBus = Numbers.LongsFromString(row2).Select(o => new Bus(o, o - earliestMinute % o)).MinBy(o => o.Delay)!;
        return bestBus.Id * bestBus.Delay;
    }

    [Puzzle("3b77da892f95806bf7e9daa18ede02a0")]
    public long Part2(string input)
    {
        var busDepartureMinutes = input.Split(LineBreaks.Single)[1].Split(',').ToList();
        var buses = new List<Bus>();
        for (var i = 0; i < busDepartureMinutes.Count; i++)
        {
            var busStr = busDepartureMinutes[i];
            if (busStr != "x")
                buses.Add(new Bus(long.Parse(busStr), i));
        }

        buses = [.. buses.OrderByDescending(o => o.Id)];
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

    private static bool IsMatching(IEnumerable<Bus> currentBuses, long time) => currentBuses.All(o => IsMatching(o, time));
    private static bool IsMatching(Bus bus, long time) => (time + bus.Delay) % bus.Id == 0;
    
    private record Bus(long Id, long Delay);
}