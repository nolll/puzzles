using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Hex Ed")]
public class Aoc201711 : AocPuzzle
{
    [Puzzle("b7c04ecac2d0150916a741834019f8ec")]
    public int Part1(string input)
    {
        var (end, _) = Solve(input);
        return end;
    }

    [Puzzle("f67800158ae4e032d3f2c498107dafa8")]
    public int Part2(string input)
    {
        var (_, max) = Solve(input);
        return max;
    }

    private (int, int) Solve(string input)
    {
        var grid = new Grid<int>();
        grid.TurnTo(GridDirection.Up);

        var directions = input.Split(',');
        var maxDistance = 0;
        var currentDistance = 0;

        foreach (var direction in directions)
        {
            Move(grid, direction);
            currentDistance = GetDistance(grid);
            if (currentDistance > maxDistance)
                maxDistance = currentDistance;
        }

        return (currentDistance, maxDistance);
    }

    private int GetDistance(Grid<int> grid)
    {
        var x = grid.Coord.X;
        var y = grid.Coord.Y;
        var xStart = grid.StartCoord.X;
        var yStart = grid.StartCoord.Y;
        var xMax = Math.Max(xStart, x);
        var xMin = Math.Min(xStart, x);
        var yMax = Math.Max(yStart, y);
        var yMin = Math.Min(yStart, y);
        var xDistance = xMax - xMin;
        var yDistance = yMax - yMin;
        var distance = 0;

        while (xDistance > 0 && yDistance > 0)
        {
            xDistance--;
            yDistance--;
            distance++;
        }

        while (xDistance > 0)
        {
            xDistance--;
            distance++;
        }

        while (yDistance > 0)
        {
            yDistance--;
            yDistance--;
            distance++;
        }

        return distance;
    }

    private static void Move(Grid<int> grid, string direction) => GetMoveFunc(direction)(grid);

    private static Action<Grid<int>> GetMoveFunc(string direction) => direction switch
    {
        "n" => MoveNorth,
        "ne" => MoveNorthEast,
        "se" => MoveSouthEast,
        "s" => MoveSouth,
        "sw" => MoveSouthWest,
        "nw" => MoveNorthWest,
        _ => throw new NotImplementedException($"direction {direction} not implemented")
    };

    private static void MoveNorth(Grid<int> grid)
    {
        grid.MoveUp();
        grid.MoveUp();
    }

    private static void MoveNorthEast(Grid<int> grid)
    {
        grid.MoveRight();
        grid.MoveUp();
    }

    private static void MoveSouthEast(Grid<int> grid)
    {
        grid.MoveRight();
        grid.MoveDown();
    }

    private static void MoveSouth(Grid<int> grid)
    {
        grid.MoveDown();
        grid.MoveDown();
    }

    private static void MoveSouthWest(Grid<int> grid)
    {
        grid.MoveLeft();
        grid.MoveDown();
    }

    private static void MoveNorthWest(Grid<int> grid)
    {
        grid.MoveLeft();
        grid.MoveUp();
    }
}