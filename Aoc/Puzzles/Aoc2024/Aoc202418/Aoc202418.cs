using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202418;

[Name("RAM Run")]
public class Aoc202418 : AocPuzzle
{
    private const int Size = 71;
    private const int Steps = 1024;
    private const char EmptySpace = '.';
    private const char Wall = '#';

    public PuzzleResult Part1(string input)
    {
        var res = Part1(input, Steps, Size, Size);
        
        return new PuzzleResult(res, "4cfa9a7af37f61d855606a891023473a");
    }
    
    public PuzzleResult Part2(string input)
    {
        var res = Part2(input, Size, Size);
        
        return new PuzzleResult(res, "5cc0c24dab0cf72c881e5a427edc0e1b");
    }
    
    public int Part1(string input, int steps, int width, int height)
    {
        var coords = input.Split(LineBreaks.Single)
            .Select(Numbers.IntsFromString)
            .Select(o => new Coord(o[0], o[1]))
            .Take(steps);

        var grid = new Grid<char>(width, height, EmptySpace);
        foreach (var coord in coords)
        {
            grid.WriteValueAt(coord, Wall);
        }

        var start = new Coord(0, 0);
        var end = new Coord(grid.XMax, grid.YMax);

        return PathFinder.ShortestPathTo(grid, start, end).Count;
    }

    public string Part2(string input, int width, int height)
    {
        var coords = input.Split(LineBreaks.Single)
            .Select(Numbers.IntsFromString)
            .Select(o => new Coord(o[0], o[1]))
            .ToArray();

        var grid = new Grid<char>(width, height, EmptySpace);
        var start = new Coord(0, 0);
        var end = new Coord(grid.XMax, grid.YMax);

        var lo = 0;
        var hi = coords.Length - 1;
        while (lo < hi)
        {
            var mid = (lo + hi) / 2;
            if (CanReachExit(grid, start, end, coords, mid + 1))
                lo = mid + 1;
            else
                hi = mid;
        }

        return coords[lo].Id;
    }

    private static bool CanReachExit(Grid<char> grid,
        Coord start,
        Coord end,
        Coord[] coords,
        int n)
    {
        var m = grid.Clone();

        for (var i = 0; i < n; i++)
        {
            m.WriteValueAt(coords[i], Wall);
        }
        
        var r = PathFinder.ShortestPathTo(m, start, end);
        return r.Count != 0;
    }
}