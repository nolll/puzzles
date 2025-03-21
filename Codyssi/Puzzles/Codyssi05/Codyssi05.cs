using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi05;

[Name("Patron Islands")]
public class Codyssi05 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var ship = new MatrixAddress(0, 0);
        var coords = lines.Select(Numbers.IntsFromString).Select(o => new MatrixAddress(o.First(), o.Last()));
        var distances = coords.Select(o => o.ManhattanDistanceTo(ship)).ToList();
        var result = distances.Max() - distances.Min();
        return new PuzzleResult(result, "8970c66cc5feb9663d03802a881d2305");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var ship = new MatrixAddress(0, 0);
        var coords = lines.Select(Numbers.IntsFromString)
            .Select(o => new MatrixAddress(o.First(), o.Last()))
            .OrderBy(o => o.ManhattanDistanceTo(ship))
            .ThenBy(o => o.X)
            .ThenBy(o => o.Y)
            .ToList();
        var closest = coords.First();
        coords = coords.Skip(1)
            .OrderBy(o => o.ManhattanDistanceTo(closest))
            .ThenBy(o => o.X)
            .ThenBy(o => o.Y)
            .ToList();
        var result = closest.ManhattanDistanceTo(coords.First());
        return new PuzzleResult(result, "9b3a3aaa26debdeb546daa2dcd3f0873");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var current = new MatrixAddress(0, 0);
        var coords = lines.Select(Numbers.IntsFromString)
            .Select(o => new MatrixAddress(o.First(), o.Last()))
            .ToList();

        var total = 0;

        while (coords.Count > 0)
        {
            coords = coords
                .OrderBy(o => o.ManhattanDistanceTo(current))
                .ThenBy(o => o.X)
                .ThenBy(o => o.Y)
                .ToList();

            var next = coords.First();
            total += current.ManhattanDistanceTo(next);
            current = next;
            coords = coords.Skip(1).ToList();
        }
        
        return new PuzzleResult(total, "9f7fe9e9b27c388197a28609ca587687");
    }
}