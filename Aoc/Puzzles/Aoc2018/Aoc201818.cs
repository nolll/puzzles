using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Settlers of The North Pole")]
public class Aoc201818 : AocPuzzle
{
    [Puzzle("005b4c9579d6ddb74c9a713c7859b558")]
    public int Part1(string input) => Solve(input, 10);

    [Puzzle("8ca0e3bcb9441bd0e9d01aa29a11a817")]
    public int Part2(string input) => Solve(input, 1_000_000_000);

    private const char Open = '.';
    private const char Wood = '|';
    private const char Lumber = '#';

    public int Solve(string input, int minutes)
    {
        var foundPeriod = false;
        var grid = GridBuilder.BuildCharGrid(input);
        var earlierLayouts = new List<string> { grid.Print() };
        for (var i = 0; i < minutes; i++)
        {
            grid = GetNextIteration(grid);

            if (foundPeriod)
                continue;

            var print = grid.Print();
            var earlierIndex = earlierLayouts.IndexOf(print);
            if (earlierIndex != -1)
            {
                foundPeriod = true;
                var period = i - earlierIndex + 1;
                while (i < minutes) 
                    i += period;

                i -= period;
            }

            earlierLayouts.Add(print);
        }

        var lumberCount = grid.Values.Count(o => o == Lumber);
        var woodCount = grid.Values.Count(o => o == Wood);
        return lumberCount * woodCount;
    }

    private static Grid<char> GetNextIteration(Grid<char> grid)
    {
        var newGrid = new Grid<char>();
        foreach (var coord in grid.Coords)
        {
            newGrid.WriteValueAt(coord, GetNewValue(grid, coord));
        }

        return newGrid;
    }

    private static char GetNewValue(Grid<char> grid, Coord coord)
    {
        var adjacent = grid.AllAdjacentValuesTo(coord);
        var currentValue = grid.ReadValueAt(coord);
        return currentValue switch
        {
            Open => adjacent.Count(o => o == Wood) >= 3 ? Wood : currentValue,
            Wood => adjacent.Count(o => o == Lumber) >= 3 ? Lumber : currentValue,
            Lumber => adjacent.Any(o => o == Lumber) && adjacent.Any(o => o == Wood) ? Lumber : Open,
            _ => Open
        };
    }
}