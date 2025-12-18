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
        var lines = input.Split(LineBreaks.Single);
        var coords = new List<Coord>();
        coords.Add(new Coord(0, 0));
        foreach (var line in lines)
        {
            var (x, y) = Numbers.IntsFromString(line);
            coords.Add(new Coord(x, y));
        }
        
        var distance = 0;
        foreach (var (a, b) in coords.Zip(coords.Skip(1)))
        {
            distance += a.ManhattanDistanceTo(b);
        }
        
        return new PuzzleResult(distance, "6a12a1e4bd346aae239fb0db99946862");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var coords = new List<Coord>();
        coords.Add(new Coord(0, 0));
        foreach (var line in lines)
        {
            var (x, y) = Numbers.IntsFromString(line);
            coords.Add(new Coord(x, y));
        }
        
        var distance = 0;
        foreach (var (a, b) in coords.Zip(coords.Skip(1)))
        {
            var xdiff = Math.Abs(a.X - b.X);
            var ydiff = Math.Abs(a.Y - b.Y);
            
            distance += a.ManhattanDistanceTo(b) - Math.Min(xdiff, ydiff);
        }
        
        return new PuzzleResult(distance, "fc0b902be6ab40fa1e0f7ab2b914f25c");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var start = new Coord(0, 0);
        var coords = new List<Coord>();
        coords.Add(start);
        foreach (var line in lines)
        {
            var (x, y) = Numbers.IntsFromString(line);
            coords.Add(new Coord(x, y));
        }

        coords = coords.OrderBy(o => o.ManhattanDistanceTo(start)).ToList();
        
        var distance = 0;
        foreach (var (a, b) in coords.Zip(coords.Skip(1)))
        {
            var xdiff = Math.Abs(a.X - b.X);
            var ydiff = Math.Abs(a.Y - b.Y);
            
            distance += a.ManhattanDistanceTo(b) - Math.Min(xdiff, ydiff);
        }
        
        return new PuzzleResult(distance, "856f25ae0316989620812f8a89518d48");
    }
}