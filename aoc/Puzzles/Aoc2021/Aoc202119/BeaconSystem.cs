using System;
using System.Collections.Generic;
using System.Linq;
using Common.CoordinateSystems.CoordinateSystem3D;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2021.Day19;

public class BeaconSystem
{
    public BeaconSystemResult GetResult(string input)
    {
        var groups = PuzzleInputReader.ReadLineGroups(input);
        var scanners = groups.Select(ParseScanner).ToList();

        var baseScanner = scanners.First();
        var otherScanners = scanners.Skip(1).ToList();

        var scannerLocations = new List<Matrix3DAddress>();

        while (otherScanners.Any())
        {
            foreach (var otherScanner in otherScanners)
            {
                var found = baseScanner.FindMatchingRotation(otherScanner.BeaconCoords);
                if (found != null)
                {
                    scannerLocations.Add(found.Value.scannerCoord);

                    foreach (var relCoord in found.Value.beaconCoords)
                    {
                        var xNew = found.Value.scannerCoord.X - relCoord.X;
                        var yNew = found.Value.scannerCoord.Y - relCoord.Y;
                        var zNew = found.Value.scannerCoord.Z - relCoord.Z;
                        var newCoord = new Matrix3DAddress(xNew, yNew, zNew);
                        baseScanner.AddCoord(newCoord);
                    }

                    otherScanners = otherScanners.Where(o => o.Id != otherScanner.Id).ToList();
                    break;
                }
            }
        }

        var maxDistance = 0;
        foreach (var a in scannerLocations)
        {
            foreach (var b in scannerLocations)
            {
                if (a.Id != b.Id)
                {
                    var distance = a.ManhattanDistanceTo(b);
                    if (distance > maxDistance)
                        maxDistance = distance;
                }
            }
        }

        return new BeaconSystemResult(baseScanner.BeaconCoords.Count, maxDistance);
    }

    private BeaconScanner ParseScanner(IList<string> lines)
    {
        var id = int.Parse(lines.First().Split(' ')[2]);
        var beaconCoords = lines.Skip(1).Select(ParseCoord).ToList();
        return new BeaconScanner(id, beaconCoords);
    }

    private Matrix3DAddress ParseCoord(string s)
    {
        var numbers = s.Split(',').Select(int.Parse).ToArray();
        return new Matrix3DAddress(numbers[0], numbers[1], numbers[2]);
    }
}

public class BeaconSystemResult
{
    public int BeaconCount { get; }
    public int MaxDistance { get; }

    public BeaconSystemResult(int beaconCount, int maxDistance)
    {
        BeaconCount = beaconCount;
        MaxDistance = maxDistance;
    }
}

internal class BeaconScanner
{
    public int Id { get; }
    public List<Matrix3DAddress> BeaconCoords { get; }

    public BeaconScanner(int id, List<Matrix3DAddress> beaconCoords)
    {
        Id = id;
        BeaconCoords = beaconCoords;
    }

    public (Matrix3DAddress scannerCoord, List<Matrix3DAddress> beaconCoords)? FindMatchingRotation(List<Matrix3DAddress> otherCoords)
    {
        var transforms = new List<Func<Matrix3DAddress, Matrix3DAddress>>
        {
            coord => new Matrix3DAddress(coord.X, coord.Y, coord.Z),
            coord => new Matrix3DAddress(coord.Z, coord.X, coord.Y),
            coord => new Matrix3DAddress(coord.Y, coord.Z, coord.X),
            coord => new Matrix3DAddress(coord.X, coord.Z, coord.Y),
            coord => new Matrix3DAddress(coord.Z, coord.Y, coord.X),
            coord => new Matrix3DAddress(coord.Y, coord.X, coord.Z),
        };
        
        var rotations = new List<(int x, int y, int z)>
        {
            (1, 1, 1),
            (1, 1, -1),
            (1, -1, 1),
            (-1, 1, 1),
            (1, -1, -1),
            (-1, -1, 1),
            (-1, 1, -1),
            (-1, -1, -1),
        };

        foreach (var transform in transforms)
        {
            foreach (var rotation in rotations)
            {
                var compareCoords = new List<Matrix3DAddress>();
                foreach (var otherCoord in otherCoords)
                {
                    var transformedCoord = transform(otherCoord);
                    var x = transformedCoord.X * rotation.x;
                    var y = transformedCoord.Y * rotation.y;
                    var z = transformedCoord.Z * rotation.z;
                    compareCoords.Add(new Matrix3DAddress(x, y, z));
                }

                var scannerPositions = new Dictionary<Matrix3DAddress, int>();
                foreach (var coord in BeaconCoords)
                {
                    foreach (var compareCoord in compareCoords)
                    {
                        var xRel = coord.X + compareCoord.X;
                        var yRel = coord.Y + compareCoord.Y;
                        var zRel = coord.Z + compareCoord.Z;
                        
                        var scannerPosition = new Matrix3DAddress(xRel, yRel, zRel);
                        if (!scannerPositions.ContainsKey(scannerPosition))
                            scannerPositions[scannerPosition] = 0;
                        scannerPositions[scannerPosition]++;
                    }
                }

                var maxFound = scannerPositions.Values.Max();
                if (maxFound >= 12)
                {
                    var sPos = scannerPositions.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                    return new(sPos, compareCoords);
                }
            }
        }

        return null;
    }

    public void AddCoord(Matrix3DAddress newCoord)
    {
        if (!BeaconCoords.Contains(newCoord))
            BeaconCoords.Add(newCoord);
    }
}