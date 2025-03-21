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
        var ship = new MatrixAddress(0, 0);
        var coords = SortByDistance(Parse(input), ship);
        var result = coords.Last().ManhattanDistanceTo(ship) - coords.First().ManhattanDistanceTo(ship);
        return new PuzzleResult(result, "8970c66cc5feb9663d03802a881d2305");
    }

    public PuzzleResult Part2(string input)
    {
        var ship = new MatrixAddress(0, 0);
        var coords = SortByDistance(Parse(input), ship);
        var closest = coords.First();
        coords = SortByDistance(coords.Skip(1), closest);
        var result = closest.ManhattanDistanceTo(coords.First());
        return new PuzzleResult(result, "9b3a3aaa26debdeb546daa2dcd3f0873");
    }

    public PuzzleResult Part3(string input)
    {
        var current = new MatrixAddress(0, 0);
        var coords = Parse(input);

        var total = 0;

        while (coords.Count > 0)
        {
            coords = SortByDistance(coords, current);

            var next = coords.First();
            total += current.ManhattanDistanceTo(next);
            current = next;
            coords = coords.Skip(1).ToList();
        }
        
        return new PuzzleResult(total, "9f7fe9e9b27c388197a28609ca587687");
    }

    private static List<MatrixAddress> SortByDistance(IEnumerable<MatrixAddress> coords, MatrixAddress current) =>
        coords
            .OrderBy(o => o.ManhattanDistanceTo(current))
            .ThenBy(o => o.X)
            .ThenBy(o => o.Y)
            .ToList();

    private static List<MatrixAddress> Parse(string input) => input.Split(LineBreaks.Single)
        .Select(Numbers.IntsFromString)
        .Select(o => new MatrixAddress(o.First(), o.Last()))
        .ToList();
}