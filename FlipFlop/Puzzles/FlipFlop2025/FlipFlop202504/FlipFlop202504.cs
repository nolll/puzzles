using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.FlipFlop.Puzzles.FlipFlop2025.FlipFlop202504;

[Name("Beach cleanup")]
public class FlipFlop202504 : FlipFlopPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var coords = ParseCoords(input).ToList();
        var distance = GetTotalDistance(coords, ManhattanDistanceBetween);
        
        return new PuzzleResult(distance, "6a12a1e4bd346aae239fb0db99946862");
    }

    public PuzzleResult Part2(string input)
    {
        var coords = ParseCoords(input).ToList();
        var distance = GetTotalDistance(coords, ShortcutDistanceBetween);
        
        return new PuzzleResult(distance, "fc0b902be6ab40fa1e0f7ab2b914f25c");
    }

    public PuzzleResult Part3(string input)
    {
        var coords = ParseCoords(input).ToList();
        var start = coords.First();
        coords = coords.OrderBy(o => o.ManhattanDistanceTo(start)).ToList();
        var distance = GetTotalDistance(coords, ShortcutDistanceBetween);
        
        return new PuzzleResult(distance, "856f25ae0316989620812f8a89518d48");
    }
    
    private static int ManhattanDistanceBetween(Coord a, Coord b) => a.ManhattanDistanceTo(b);
    
    private static int ShortcutDistanceBetween(Coord a, Coord b) => 
        a.ManhattanDistanceTo(b) - Math.Min(Math.Abs(a.X - b.X), Math.Abs(a.Y - b.Y));

    private static int GetTotalDistance(List<Coord> coords, Func<Coord, Coord, int> distanceFunc)
    {
        var distance = 0;
        foreach (var (a, b) in coords.Zip(coords.Skip(1)))
        {
            distance += distanceFunc(a, b);
        }

        return distance;
    }

    private static IEnumerable<Coord> ParseCoords(string input)
    {
        yield return new Coord(0, 0);
        foreach (var line in input.Split(LineBreaks.Single))
        {
            var (x, y) = Numbers.IntsFromString(line);
            yield return new Coord(x, y);
        }
    }
}