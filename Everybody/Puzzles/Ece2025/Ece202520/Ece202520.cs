using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202520;

[Name("Dream in Triangles")]
public class Ece202520 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var count = 0;

        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v != 'T')
                continue;

            var left = new Coord(coord.X - 1, coord.Y);
            if (!grid.IsOutOfRange(left) && grid.ReadValueAt(left) == 'T') 
                count++;

            var below = new Coord(coord.X, coord.Y + 1);
            if (!grid.IsOutOfRange(below) && grid.ReadValueAt(below) == 'T')
            {
                if (coord.X % 2 != 0 && coord.Y % 2 == 0) count++;
                if (coord.X % 2 == 0 && coord.Y % 2 != 0) count++;
            }
        }
        
        return new PuzzleResult(count, "d8ee6b0475f3971b598eab03bf31bed4");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}