using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles;

[Name("Largest product in a grid")]
public class Euler011 : EulerPuzzle
{
    [Puzzle("7dc8a53ba7f75787b1ab0d03ba571c17")]
    public long Solve(string input) => FindLargestSum(BuildGrid(input));

    public int FindLargestSum(Grid<int> grid)
    {
        var largestSum = 0;
        var deltas = GridDirection.All.Select(o => o.Delta).ToList();

        foreach (var coord in grid.Coords)
        {
            foreach (var delta in deltas)
            {
                largestSum = Math.Max(largestSum, GetProduct(grid, coord, delta));
            }
        }

        return largestSum;
    }

    private int GetProduct(Grid<int> grid, Coord coord, Coord delta)
    {
        var sum = 1;
        for (var i = 0; i < 4; i++)
        {
            var checkCoord = new Coord(coord.X + delta.X * i, coord.Y + delta.Y * i);
            if (grid.IsOutOfRange(checkCoord))
                return 0;

            sum *= grid.ReadValueAt(checkCoord);
        }

        return sum;
    }

    private static Grid<int> BuildGrid(string input)
    {
        var grid = new Grid<int>();
        var rows = input.Trim().Split(LineBreaks.Single);
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var items = row.Split(" ");
            foreach (var item in items)
            {
                var trimmed = item.TrimStart('0');
                var num = trimmed.Length > 0
                    ? int.Parse(trimmed)
                    : 0;
                grid.WriteValueAt(x, y, num);
                x += 1;
            }

            y += 1;
        }

        return grid;
    }
}