using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202504;

[Name("")]
public class Aoc202504 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var count = 0;
        foreach (var coord in grid.Coords)
        {
            var cv = grid.ReadValueAt(coord);
            if (cv != '@') continue;
            if (grid.AllAdjacentValuesTo(coord).Count(o => o == '@') < 4)
                count++;
        }
        
        return new PuzzleResult(count, "4da6779dc3e7cebb5219ce6536767d75");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var removed = 0;
        var count = 0;
        var coords = grid.FindAddresses('@').ToHashSet();
        var adjacent = new Dictionary<Coord, List<Coord>>();
        foreach (var coord in coords)
        {
            adjacent.Add(coord, grid.AllAdjacentCoordsTo(coord).ToList());
        }
        
        while (true)
        {
            if (coords.Count == count)
                break;

            count = coords.Count;
            
            foreach (var coord in coords)
            {
                var cv = grid.ReadValueAt(coord);
                if (cv != '@') continue;
                if (adjacent[coord].Select(o => grid.ReadValueAt(o)).Count(o => o == '@') >= 4) continue;
                grid.WriteValueAt(coord, '.');
                coords.Remove(coord);
                removed++;
                break;
            }
        }

        return new PuzzleResult(removed, "b5c22cfe2a53283e5f093ac4f07fd1db");
    }
}