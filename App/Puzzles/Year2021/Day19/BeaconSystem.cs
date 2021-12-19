using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;
using App.Common.Strings;

namespace App.Puzzles.Year2021.Day19;

public class BeaconSystem
{
    public int GetBeaconCount(string input)
    {
        var groups = PuzzleInputReader.ReadLineGroups(input);
        var scanners = groups.Select(ParseScanner).ToList();

        var baseScanner = scanners.First();
        var otherScanners = scanners.Skip(1).ToList();

        while (otherScanners.Any())
        {
            foreach (var otherScanner in otherScanners)
            {
                var found = baseScanner.FindMatchingRotation(otherScanner.BeaconCoords);
                if (found != null)
                {
                    foreach (var otherCoord in otherScanner.BeaconCoords)
                    {
                        var xNew = otherCoord.X - found.Value.scannerCoord.X;
                        var yNew = otherCoord.Y - found.Value.scannerCoord.Y;
                        var zNew = otherCoord.Z - found.Value.scannerCoord.Z;
                        var newCoord = new Matrix3DAddress(xNew, yNew, zNew);
                        baseScanner.AddCoord(newCoord);
                    }
                }
            }
            
        }

        var matrix = new Matrix3D<char>();

        return 0;
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
        var directions = new List<(int x, int y, int z)>
        {
            (1, 1, 1),
            (1, 1, -1),
            (1, -1, -1),
            (-1, -1, -1),
            (-1, -1, 1),
            (-1, 1, 1)
        };

        var rotations = new List<(int x, int y)>
        {
            (1, 1),
            (1, -1),
            (-1, -1),
            (-1, 1),
        };

        foreach (var direction in directions)
        {
            foreach (var rotation in rotations)
            {
                var compareCoords = new List<Matrix3DAddress>();
                foreach (var otherCoord in otherCoords)
                {
                    var x = otherCoord.X * direction.x * rotation.x;
                    var y = otherCoord.Y * direction.y * rotation.y;
                    var z = otherCoord.Z * direction.z;
                    compareCoords.Add(new Matrix3DAddress(x, y, z));
                }

                var scannerPositions = new Dictionary<Matrix3DAddress, int>();
                foreach (var coord in BeaconCoords)
                {
                    foreach (var compareCoord in compareCoords)
                    {
                        var xRel = coord.X - compareCoord.X;
                        var yRel = coord.Y - compareCoord.Y;
                        var zRel = coord.Z - compareCoord.Z;
                        var scannerPosition = new Matrix3DAddress(xRel, yRel, zRel);
                        if (!scannerPositions.ContainsKey(scannerPosition))
                            scannerPositions[scannerPosition] = 0;
                        scannerPositions[scannerPosition]++;
                    }
                }

                if (scannerPositions.Values.Max() >= 12)
                {
                    var max = scannerPositions.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                    return new(max, compareCoords);
                }
            }
        }
        
        return null;
    }

    public void AddCoord(Matrix3DAddress newCoord)
    {
        if(!BeaconCoords.Contains(newCoord))
            BeaconCoords.Add(newCoord);
    }
}