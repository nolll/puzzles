using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.Common.Strings;

namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202215;

public class BeaconZone
{
    public int Part1(string input, int y, bool print)
    {
        var lines = InputReader.ReadLines(input, false);
        var pairs = lines.Select(ParsePair).ToList();

        var beacons = pairs.Select(o => o.beacon).ToList();
        var beaconDistances = new Dictionary<MatrixAddress, int>();
        foreach (var (sensor, beacon) in pairs)
        {
            var distance = sensor.ManhattanDistanceTo(beacon);
            beaconDistances.Add(sensor, distance);
        }

        var minx = pairs.Select(o => Math.Min(o.sensor.X, o.beacon.X) - beaconDistances[o.sensor]).Min();
        var maxx = pairs.Select(o => Math.Max(o.sensor.X, o.beacon.X) + beaconDistances[o.sensor]).Max();

        // todo: Use the same solution as for day 2. Get intervals for y here

        var count = 0;
        for (var x = minx; x <= maxx; x++)
        {
            var current = new MatrixAddress(x, y);

            if (beacons.Contains(current))
            {
                continue;
            }

            var canContainBeacon = true;
            foreach (var kv in beaconDistances)
            {
                var distanceToSensor = current.ManhattanDistanceTo(kv.Key);
                if (distanceToSensor <= kv.Value)
                    canContainBeacon = false;
            }

            if (!canContainBeacon)
                count++;
        }

        return count;
    }

    public long Part2(string input, int size)
    {
        var lines = InputReader.ReadLines(input, false);
        var pairs = lines.Select(ParsePair).ToList();

        var beaconDistances = new Dictionary<MatrixAddress, int>();
        foreach (var (sensor, beacon) in pairs)
        {
            var distance = sensor.ManhattanDistanceTo(beacon);
            beaconDistances.Add(sensor, distance);
        }

        for (var y = 0; y < size; y++)
        {
            var intervals = GetIntervalsForRow(y, 0, size, beaconDistances);
            if (intervals.Count > 1)
            {
                var x = intervals.First().End + 1;
                return (long)x * 4_000_000 + y;
            }
        }

        return 0;
    }

    private static List<Interval> GetIntervalsForRow(int row, int minX, int maxX, Dictionary<MatrixAddress, int> beaconDistances)
    {
        var intervals = new List<Interval>();

        foreach (var bd in beaconDistances)
        {
            var beaconDistance = bd.Value;
            var sensorY = bd.Key.Y;
            var overlap = beaconDistance - Math.Abs(sensorY - row);
            if (overlap > 0)
            {
                var sensorX = bd.Key.X;
                var start = Math.Max(sensorX - overlap, minX);
                var end = Math.Min(sensorX + overlap, maxX);
                intervals.Add(new Interval(start, end));
            }
        }

        return IntervalMerger.MergeIntervals(intervals);
    }

    private (MatrixAddress sensor, MatrixAddress beacon) ParsePair(string input)
    {
        var parts = input.Split(':');
        var sensorPart = parts[0].Trim();
        var beaconPart = parts[1].Trim();
        parts = sensorPart.Split(' ');
        var sensorX = int.Parse(parts[2].Split('=')[1].Trim(','));
        var sensorY = int.Parse(parts[3].Split('=')[1]);
        parts = beaconPart.Split(' ');
        var beaconX = int.Parse(parts[4].Split('=')[1].Trim(','));
        var beaconY = int.Parse(parts[5].Split('=')[1]);
        return (new MatrixAddress(sensorX, sensorY), new MatrixAddress(beaconX, beaconY));
    }
}