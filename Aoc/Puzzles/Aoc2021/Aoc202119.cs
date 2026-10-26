using Pzl.Common;
using Pzl.Tools.Grids.Grids3D;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Beacon Scanner")]
public class Aoc202119 : AocPuzzle
{
    [Puzzle("a6668fd005e7ebda4e124253eea1e56e")]
    public int Part1(string input) => GetResult(input).BeaconCount;

    [Puzzle("ce2bc05651a369b5171388ec7e4f2438")]
    public int Part2(string input) => GetResult(input).MaxDistance;

    public BeaconSystemResult GetResult(string input)
    {
        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single))
            .ToList();
        var scanners = groups.Select(ParseScanner).ToList();

        var baseScanner = scanners.First();
        var otherScanners = scanners.Skip(1).ToList();

        var scannerLocations = new List<Coord3D>();

        while (otherScanners.Count != 0)
        {
            foreach (var otherScanner in otherScanners)
            {
                var found = baseScanner.FindMatchingRotation(otherScanner.BeaconCoords);
                if (found == null)
                    continue;

                scannerLocations.Add(found.Value.scannerCoord);

                foreach (var relCoord in found.Value.beaconCoords)
                {
                    baseScanner.AddCoord(new Coord3D(
                        found.Value.scannerCoord.X - relCoord.X,
                        found.Value.scannerCoord.Y - relCoord.Y,
                        found.Value.scannerCoord.Z - relCoord.Z));
                }

                otherScanners = [.. otherScanners.Where(o => o.Id != otherScanner.Id)];
                break;
            }
        }

        var maxDistance = 0;
        foreach (var a in scannerLocations)
        {
            foreach (var b in scannerLocations)
            {
                if (a.Id == b.Id)
                    continue;

                var distance = a.ManhattanDistanceTo(b);
                if (distance > maxDistance)
                    maxDistance = distance;
            }
        }

        return new BeaconSystemResult(baseScanner.BeaconCoords.Count, maxDistance);
    }

    private static BeaconScanner ParseScanner(string[] lines)
    {
        var id = int.Parse(lines.First().Split(' ')[2]);
        var beaconCoords = lines.Skip(1).Select(ParseCoord).ToHashSet();
        return new BeaconScanner(id, beaconCoords);
    }

    private static Coord3D ParseCoord(string s)
    {
        var (x, y, z) = Numbers.IntsFromString(s);
        return new Coord3D(x, y, z);
    }

    private class BeaconScanner(int id, HashSet<Coord3D> beaconCoords)
    {
        public int Id { get; } = id;
        public HashSet<Coord3D> BeaconCoords { get; } = beaconCoords;

        public (Coord3D scannerCoord, List<Coord3D> beaconCoords)? FindMatchingRotation(HashSet<Coord3D> otherCoords)
        {
            var transforms = new List<Func<Coord3D, Coord3D>>
            {
                coord => new Coord3D(coord.X, coord.Y, coord.Z),
                coord => new Coord3D(coord.Z, coord.X, coord.Y),
                coord => new Coord3D(coord.Y, coord.Z, coord.X),
                coord => new Coord3D(coord.X, coord.Z, coord.Y),
                coord => new Coord3D(coord.Z, coord.Y, coord.X),
                coord => new Coord3D(coord.Y, coord.X, coord.Z),
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
                    var compareCoords = new List<Coord3D>();
                    foreach (var otherCoord in otherCoords)
                    {
                        var transformedCoord = transform(otherCoord);
                        var x = transformedCoord.X * rotation.x;
                        var y = transformedCoord.Y * rotation.y;
                        var z = transformedCoord.Z * rotation.z;
                        compareCoords.Add(new Coord3D(x, y, z));
                    }

                    var scannerPositions = new Dictionary<Coord3D, int>();
                    foreach (var coord in BeaconCoords)
                    {
                        foreach (var compareCoord in compareCoords)
                        {
                            var scannerPosition = new Coord3D(
                                coord.X + compareCoord.X,
                                coord.Y + compareCoord.Y,
                                coord.Z + compareCoord.Z);
                            scannerPositions.TryAdd(scannerPosition, 0);
                            scannerPositions[scannerPosition]++;
                        }
                    }

                    var maxFound = scannerPositions.Values.Max();
                    if (maxFound < 12)
                        continue;

                    var sPos = scannerPositions.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                    return (sPos, compareCoords);
                }
            }

            return null;
        }

        public void AddCoord(Coord3D newCoord) => BeaconCoords.Add(newCoord);
    }

    public record BeaconSystemResult(int BeaconCount, int MaxDistance);
}