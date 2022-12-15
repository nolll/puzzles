using System;
using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;
using Core.Common.Strings;

namespace Core.Puzzles.Year2022.Day15;

public class BeaconZone
{
    public int Part1(string input, int y, bool print)
    {
        var lines = PuzzleInputReader.ReadLines(input, false);
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

        if (print)
            Print(pairs);

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

    private void Print(List<(MatrixAddress sensor, MatrixAddress beacon)> pairs)
    {
        var matrix = new QuickDynamicMatrix<char>(defaultValue: '.');

        foreach (var (signal, beacon) in pairs)
        {
            matrix.MoveTo(signal);
            matrix.WriteValueAt(signal, 'S');
            matrix.MoveTo(beacon);
            matrix.WriteValueAt(beacon, 'B');
        }

        Console.WriteLine(matrix.Print());
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