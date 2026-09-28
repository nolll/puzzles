using Pzl.Common;
using Pzl.Tools.Maths;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Shuttle Search")]
public class Aoc202013 : AocPuzzle
{
    [Puzzle("22dea96fc3fe7cf98d5ae3e3a29c196a")]
    public int Part1(string input) => new BusScheduler1(input).GetBusValue();

    [Puzzle("3b77da892f95806bf7e9daa18ede02a0")]
    public long Part2(string input) => new BusScheduler2(input).GetContestMinute();
    
    public class BusScheduler1
    {
        private readonly int _earliestMinute;
        private readonly List<int> _busDepartureMinutes;

        public BusScheduler1(string input)
        {
            var rows = input.Split(LineBreaks.Single);
            _earliestMinute = int.Parse(rows[0]);
            _busDepartureMinutes = rows[1].Split(',').Where(o => o != "x").Select(int.Parse).ToList();
        }

        public int GetBusValue()
        {
            var buses = _busDepartureMinutes.Select(o => new Bus(o, o - _earliestMinute % o)).ToList();
            var bestBus = buses.OrderBy(o => o.Delay).First();
            return bestBus.Id * bestBus.Delay;
        }

        private record Bus(int Id, int Delay);
    }
    
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
}