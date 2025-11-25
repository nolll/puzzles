using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202517;

[Name("Deadline-Driven Development")]
public class Ece202517 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);

        var sum = CountDestroyed(grid, 10);
        
        return new PuzzleResult(sum, "058525ed0b94d59517e415b1660aa68a");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var best = 0;
        var bestRadius = 0;
        var acc = 0;
        var r = 1;

        while (r * 2 + 1 < grid.Width && r * 2 + 1 < grid.Height)
        {
            var count = CountDestroyed(grid, r) - acc;
            if (count > best)
            {
                best = count;
                bestRadius = r;
            }

            acc += count;
            r++;
        }
        
        return new PuzzleResult(best * bestRadius, "5d4764c0cfb73f6caa5342ac5cbce4db");
    }

    private int CountDestroyed(Grid<char> grid, int r)
    {
        var sum = 0;
        var v = grid.Coords.First(o => grid.ReadValueAt(o) == '@');
        foreach (var c in grid.Coords)
        {
            if(c == v)
                continue;
            
            if ((v.X - c.X) * (v.X - c.X) + (v.Y - c.Y) * (v.Y - c.Y) > r * r)
            {
                continue;
            }

            sum += int.Parse(grid.ReadValueAt(c).ToString());
        }

        return sum;
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}