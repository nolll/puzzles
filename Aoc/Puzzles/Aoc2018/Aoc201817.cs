using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Reservoir Research")]
public class Aoc201817 : AocPuzzle
{
    private const char SourceTile = '+';
    private const char WallTile = '#';
    private const char EmptyTile = '.';
    private const char RunningWaterTile = '|';
    private const char RestingWaterTile = '~';
    
    [Puzzle("670e4fda6254e4ae79cdf1065fba7c51")]
    public int Part1(string input)
    {
        var (totalWaterTileCount, _) = Solve(input);
        return totalWaterTileCount;
    }

    [Puzzle("c188fe62ee29321d37a6c8cee549a1db")]
    public int Part2(string input)
    {
        var (_, retainedWaterTileCount) = Solve(input);
        return retainedWaterTileCount;
    }

    public (int, int) Solve(string input)
    {
        var limits = new Limits();
        var source = new Coord(500, 0);
        var grid = BuildGrid(input, limits, source);
        var openCoords = new HashSet<Coord> { new(source.X, source.Y) };
        while (openCoords.Count != 0)
        {
            var current = openCoords.First();
            grid.MoveTo(current);
            var valueBelow = grid.ReadValueAt(grid.Coord.X, grid.Coord.Y + 1);
            if (valueBelow is WallTile or RestingWaterTile)
            {
                openCoords.Remove(current);
                openCoords.Add(new Coord(grid.Coord.X, grid.Coord.Y - 1));
                continue;
            }

            while (true)
            {
                grid.MoveDown();
                if (IsAtBottom(grid, limits))
                {
                    openCoords.Remove(current);
                    break;
                }

                var value = grid.ReadValue();
                if (value is WallTile or RestingWaterTile)
                {
                    grid.MoveUp();
                    var canFlowRight = TryFlowRight(grid, openCoords);
                    var canFlowLeft = TryFlowLeft(grid, openCoords);
                    var isBlockedRight = !canFlowRight;
                    var isBlockedLeft = !canFlowLeft;

                    if (isBlockedLeft && isBlockedRight)
                    {
                        while (true)
                        {
                            grid.MoveRight();
                            if (grid.ReadValue() == WallTile)
                                break;

                            grid.WriteValue(RestingWaterTile);
                        }

                        break;
                    }

                    openCoords.Remove(current);
                    break;
                }

                if (value == EmptyTile)
                    grid.WriteValue(RunningWaterTile);
            }
        }

        var distanceFromSourceToMinY = limits.YMin - source.Y - 1;
        var totalWaterTileCount = grid.Values.Count(o => o is RestingWaterTile or RunningWaterTile) - distanceFromSourceToMinY;
        var retainedWaterTileCount = grid.Values.Count(o => o == RestingWaterTile);

        return (totalWaterTileCount, retainedWaterTileCount);
    }

    private Grid<char> BuildGrid(string input, Limits limits, Coord source)
    {
        var grid = new Grid<char>(1, 1, EmptyTile);
        grid.MoveTo(source);
        grid.WriteValue(SourceTile);

        var rows = input.Split(LineBreaks.Single);

        foreach (var row in rows)
        {
            var dim = row[0];
            var (val, min, max) = Numbers.IntsFromString(row);
            if (dim == 'x')
            {
                for (var y = min; y <= max; y++)
                    WriteWall(grid, limits, val, y);
            }
            else
            {
                for (var x = min; x <= max; x++)
                    WriteWall(grid, limits, x, val);
            }
        }

        return grid;
    }

    private static void WriteWall(Grid<char> grid, Limits limits, int x, int y)
    {
        grid.MoveTo(x, y);
        grid.WriteValue(WallTile);
        limits.Set(y);
    }

    private static bool TryFlowRight(Grid<char> grid, HashSet<Coord> openCoords) => 
        TryFlow(() => grid.MoveRight(), grid, openCoords);

    private static bool TryFlowLeft(Grid<char> grid, HashSet<Coord> openCoords) => 
        TryFlow(() => grid.MoveLeft(), grid, openCoords);

    private static bool TryFlow(Func<bool> move, Grid<char> grid, HashSet<Coord> openCoords)
    {
        while (true)
        {
            move();
            var value = grid.ReadValue();
            
            if (value == WallTile)
                return false;

            if (value is not (EmptyTile or RunningWaterTile))
                continue;
            
            if (value == EmptyTile)
                grid.WriteValue(RunningWaterTile);

            var coordBelow = grid.Coord.Down();
            var valueBelow = grid.ReadValueAt(coordBelow);
            if (valueBelow is not (EmptyTile or RunningWaterTile))
                continue;
                
            openCoords.Add(grid.Coord);
            return true;
        }
    }

    private static bool IsAtBottom(Grid<char> grid, Limits limits) => grid.Coord.Y > limits.YMax;

    private class Limits
    {
        public int YMin { get; private set; } = int.MaxValue;
        public int YMax { get; private set; } = int.MinValue;

        public void Set(int y)
        {
            if (y < YMin)
                YMin = y;
            if (y > YMax)
                YMax = y;
        }
    }
}