using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202504;

[Name("Printing Department")]
public class Aoc202504 : AocPuzzle
{
    private const char Roll = '@';

    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var count = grid.Coords.Count(o => grid.ReadValueAt(o) == Roll && grid.AllAdjacentValuesTo(o).Count(r => r == Roll) < 4);
        
        return new PuzzleResult(count, "4da6779dc3e7cebb5219ce6536767d75");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var lastCount = 0;
        var coords = grid.FindAddresses(Roll).ToHashSet();
        var adjacentCache = coords.ToDictionary(o => o, o => grid.AllAdjacentCoordsTo(o).ToList());

        while (coords.Count != lastCount)
        {
            lastCount = coords.Count;
            foreach (var coord in coords.Where(o => adjacentCache[o].Count(r => coords.Contains(r)) < 4))
            {
                coords.Remove(coord);
            }
        }

        return new PuzzleResult(adjacentCache.Count - coords.Count, "b5c22cfe2a53283e5f093ac4f07fd1db");
    }
}