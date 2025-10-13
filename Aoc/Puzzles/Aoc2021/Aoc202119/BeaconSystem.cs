using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202119;

public class BeaconSystem
{
    public BeaconSystemResult GetResult(string input)
    {
        var groups = StringReader.ReadLineGroups(input);
        var scanners = groups.Select(ParseScanner).ToList();

        var baseScanner = scanners.First();
        var otherScanners = scanners.Skip(1).ToList();

        var scannerLocations = new List<Coord3d>();

        while (otherScanners.Any())
        {
            foreach (var otherScanner in otherScanners)
            {
                var found = baseScanner.FindMatchingRotation(otherScanner.BeaconCoords);
                if (found == null)
                    continue;
                
                scannerLocations.Add(found.Value.scannerCoord);

                foreach (var relCoord in found.Value.beaconCoords)
                {
                    baseScanner.AddCoord(new Coord3d(
                        found.Value.scannerCoord.X - relCoord.X,
                        found.Value.scannerCoord.Y - relCoord.Y,
                        found.Value.scannerCoord.Z - relCoord.Z));
                }

                otherScanners = otherScanners.Where(o => o.Id != otherScanner.Id).ToList();
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

    private static BeaconScanner ParseScanner(IList<string> lines)
    {
        var id = int.Parse(lines.First().Split(' ')[2]);
        var beaconCoords = lines.Skip(1).Select(ParseCoord).ToHashSet();
        return new BeaconScanner(id, beaconCoords);
    }

    private static Coord3d ParseCoord(string s)
    {
        var numbers = s.Split(',').Select(int.Parse).ToArray();
        return new Coord3d(numbers[0], numbers[1], numbers[2]);
    }
}

public record BeaconSystemResult(int BeaconCount, int MaxDistance);

internal class BeaconScanner(int id, HashSet<Coord3d> beaconCoords)
{
    public int Id { get; } = id;
    public HashSet<Coord3d> BeaconCoords { get; } = beaconCoords;

    public (Coord3d scannerCoord, List<Coord3d> beaconCoords)? FindMatchingRotation(HashSet<Coord3d> otherCoords)
    {
        var transforms = new List<Func<Coord3d, Coord3d>>
        {
            coord => new Coord3d(coord.X, coord.Y, coord.Z),
            coord => new Coord3d(coord.Z, coord.X, coord.Y),
            coord => new Coord3d(coord.Y, coord.Z, coord.X),
            coord => new Coord3d(coord.X, coord.Z, coord.Y),
            coord => new Coord3d(coord.Z, coord.Y, coord.X),
            coord => new Coord3d(coord.Y, coord.X, coord.Z),
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
                var compareCoords = new List<Coord3d>();
                foreach (var otherCoord in otherCoords)
                {
                    var transformedCoord = transform(otherCoord);
                    var x = transformedCoord.X * rotation.x;
                    var y = transformedCoord.Y * rotation.y;
                    var z = transformedCoord.Z * rotation.z;
                    compareCoords.Add(new Coord3d(x, y, z));
                }

                var scannerPositions = new Dictionary<Coord3d, int>();
                foreach (var coord in BeaconCoords)
                {
                    foreach (var compareCoord in compareCoords)
                    {
                        var scannerPosition = new Coord3d(
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

    public void AddCoord(Coord3d newCoord)
    {
        BeaconCoords.Add(newCoord);
    }
}