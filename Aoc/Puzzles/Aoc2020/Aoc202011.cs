using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Seating System")]
public class Aoc202011 : AocPuzzle
{
    private const char Floor = '.';
    private const char OccupiedChair = '#';
    private const char EmptyChair = 'L';
    
    [Puzzle("808ef3d15c0093a702b0f3d80b8108fe")]
    public int Part1(string input) => Solve(input, GetAdjacentSeatsPart1, GetSeatStatusPart1);

    [Puzzle("7f305c2d3f92fba8601b1e43706ebc6c")]
    public int Part2(string input) => Solve(input, GetAdjacentSeatsPart2, GetSeatStatusPart2);

    private static int Solve(string input, Func<Grid<char>, IList<char>> getAdjacentSeats, Func<char, int, char> getSeatStatus)
    {
        var prevCount = 0;
        var currentCount = -1;
        var grid = GridBuilder.BuildCharGrid(input);
        while (prevCount != currentCount)
        {
            prevCount = currentCount;
            grid = RunOnce(grid, getAdjacentSeats, getSeatStatus);
            currentCount = grid.Values.Count(o => o == OccupiedChair);
        }

        return currentCount;
    }

    private static Grid<char> RunOnce(Grid<char> grid, Func<Grid<char>, IList<char>> getAdjacentSeats, Func<char, int, char> getSeatStatus)
    {
        var newGrid = grid.Clone();

        foreach (var coord in grid.Coords)
        {
            grid.MoveTo(coord);
            var currentValue = grid.ReadValue();
            var adjacentValues = getAdjacentSeats(grid);
            var neighborCount = adjacentValues.Count(o => o == OccupiedChair);
            var newValue = getSeatStatus(currentValue, neighborCount);

            newGrid.MoveTo(coord);
            newGrid.WriteValue(newValue);
        }

        return newGrid;
    }

    private static IList<char> GetAdjacentSeatsPart1(Grid<char> grid) => grid.AllAdjacentValues;

    private static IList<char> GetAdjacentSeatsPart2(Grid<char> grid)
    {
        var pos = grid.Coord;
        var values = new List<char?>
        {
            GetVisible(grid, TryMoveUp, pos),
            GetVisible(grid, TryMoveUpRight, pos),
            GetVisible(grid, TryMoveRight, pos),
            GetVisible(grid, TryMoveRightDown, pos),
            GetVisible(grid, TryMoveDown, pos),
            GetVisible(grid, TryMoveDownLeft, pos),
            GetVisible(grid, TryMoveLeft, pos),
            GetVisible(grid, TryMoveLeftUp, pos),
        };

        grid.MoveTo(pos);

        return values.Where(o => o != null).Cast<char>().ToList();
    }

    private static char GetSeatStatusPart1(char currentValue, int neighborCount) => currentValue switch
    {
        EmptyChair when neighborCount == 0 => OccupiedChair,
        OccupiedChair when neighborCount >= 4 => EmptyChair,
        _ => currentValue
    };

    private static char GetSeatStatusPart2(char currentValue, int neighborCount) => currentValue switch
    {
        EmptyChair when neighborCount == 0 => OccupiedChair,
        OccupiedChair when neighborCount >= 5 => EmptyChair,
        _ => currentValue
    };

    private static char? GetVisible(Grid<char> grid, Func<Grid<char>, int, bool> func, Coord pos)
    {
        grid.MoveTo(pos);
        while (func(grid, 1))
        {
            var v = grid.ReadValue();
            if (v != Floor)
                return v;
        }

        return null;
    }

    private static bool TryMoveUp(Grid<char> grid, int steps) => grid.TryMoveUp(steps);
    private static bool TryMoveUpRight(Grid<char> grid, int steps) => grid.TryMoveUp(steps) && grid.TryMoveRight(steps);
    private static bool TryMoveRight(Grid<char> grid, int steps) => grid.TryMoveRight(steps);
    private static bool TryMoveRightDown(Grid<char> grid, int steps) => grid.TryMoveRight(steps) && grid.TryMoveDown(steps);
    private static bool TryMoveDown(Grid<char> grid, int steps) => grid.TryMoveDown(steps);
    private static bool TryMoveDownLeft(Grid<char> grid, int steps) => grid.TryMoveDown(steps) && grid.TryMoveLeft(steps);
    private static bool TryMoveLeft(Grid<char> grid, int steps) => grid.TryMoveLeft(steps);
    private static bool TryMoveLeftUp(Grid<char> grid, int steps) => grid.TryMoveLeft(steps) && grid.TryMoveUp(steps);
}