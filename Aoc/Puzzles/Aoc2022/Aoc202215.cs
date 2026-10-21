using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Beacon Exclusion Zone")]
public class Aoc202215 : AocPuzzle
{
    private const int Part1Row = 2_000_000;
    private const int Part2Size = 4_000_000;

    [Puzzle("f81ea7aff75f183d6afc5816570af244")]
    public int Part1(string input, int y = Part1Row)
    {
        var lines = input.Split(LineBreaks.Single).Where(o => o.Length > 0);
        var pairs = lines.Select(ParsePair).ToList();

        var beacons = pairs.Select(o => o.beacon).ToList();
        var beaconDistances = new Dictionary<Coord, int>();
        foreach (var (sensor, beacon) in pairs)
        {
            var distance = sensor.ManhattanDistanceTo(beacon);
            beaconDistances.Add(sensor, distance);
        }

        var minx = pairs.Select(o => Math.Min(o.sensor.X, o.beacon.X) - beaconDistances[o.sensor]).Min();
        var maxx = pairs.Select(o => Math.Max(o.sensor.X, o.beacon.X) + beaconDistances[o.sensor]).Max();

        // todo: Use the same solution as for part 2. Get intervals for y here
        var count = 0;
        for (var x = minx; x <= maxx; x++)
        {
            var current = new Coord(x, y);

            if (beacons.Contains(current))
                continue;

            if (!beaconDistances.All(kv => kv.Value < current.ManhattanDistanceTo(kv.Key)))
                count++;
        }

        return count;
    }

    [Puzzle("b4c412a68efd49876d6777a8ea4baea1")]
    public long Part2(string input, int size = Part2Size)
    {
        var lines = input.Split(LineBreaks.Single).Where(o => o.Length > 0);
        var pairs = lines.Select(ParsePair).ToList();

        var beaconDistances = new Dictionary<Coord, int>();
        foreach (var (sensor, beacon) in pairs)
        {
            var distance = sensor.ManhattanDistanceTo(beacon);
            beaconDistances.Add(sensor, distance);
        }

        for (var y = 0; y < size; y++)
        {
            var intervals = GetIntervalsForRow(y, 0, size, beaconDistances);
            if (intervals.Count <= 1)
                continue;

            var x = intervals.First().End + 1;
            return (long)x * Part2Size + y;
        }

        return 0;
    }

    private static List<Interval> GetIntervalsForRow(int row, int minX, int maxX, Dictionary<Coord, int> beaconDistances)
    {
        var intervals = new List<Interval>();

        foreach (var (coord, beaconDistance) in beaconDistances)
        {
            var sensorY = coord.Y;
            var overlap = beaconDistance - Math.Abs(sensorY - row);
            if (overlap <= 0)
                continue;

            var sensorX = coord.X;
            var start = Math.Max(sensorX - overlap, minX);
            var end = Math.Min(sensorX + overlap, maxX);
            intervals.Add(new Interval(start, end));
        }

        return MergeIntervals(intervals);
    }

    private static (Coord sensor, Coord beacon) ParsePair(string input)
    {
        var (sx, sy, bx, by) = Numbers.IntsFromString(input);
        return (new Coord(sx, sy), new Coord(bx, by));
    }

    [DebuggerDisplay("{Start},{End}")]
    public class Interval(int start, int end)
    {
        public int Start { get; } = start;
        public int End { get; set; } = end;
    }

    public static List<Interval> MergeIntervals(List<Interval> intervals)
    {
        if (intervals.Count <= 0)
            return [];

        var arr = intervals.OrderBy(o => o.Start).ThenBy(o => o.End).ToArray();
        var stack = new Stack<Interval>();
        stack.Push(arr[0]);

        for (var i = 1; i < arr.Length; i++)
        {
            var top = stack.Peek();

            if (top.End < arr[i].Start)
                stack.Push(arr[i]);

            else if (top.End < arr[i].End)
            {
                top.End = arr[i].End;
                stack.Pop();
                stack.Push(top);
            }
        }

        var mergedIntervals = new List<Interval>();
        while (stack.Count != 0) 
            mergedIntervals.Add(stack.Pop());

        return [.. mergedIntervals.OrderBy(o => o.Start).ThenBy(o => o.End)];
    }
}