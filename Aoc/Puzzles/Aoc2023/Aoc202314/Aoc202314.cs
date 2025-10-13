using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202314;

[Name("Parabolic Reflector Dish")]
public class Aoc202314 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var result = RollNorth(input);

        return new PuzzleResult(result, "38c4a3857389e8b424b86782b940d736");
    }

    public PuzzleResult RunPart2(string input)
    {
        var result = RunManyCycles(input);
        
        return new PuzzleResult(result, "bc4f573f0b32490dec258ffe95e3b88b");
    }

    public static int RunManyCycles(string s)
    {
        const int iterations = 1_000_000_000;
        var seen = new Dictionary<string, int>();
        var list = new List<string>();
        var matrix = GridBuilder.BuildCharGrid(s);

        for (var i = 0; i < iterations; i++)
        {
            RunCycle(matrix);
            var print = matrix.Print();
            if (seen.TryGetValue(print, out var lastSeen))
            {
                var repeatLength = i - lastSeen;
                var largeTarget = lastSeen;
                while (largeTarget < iterations)
                {
                    largeTarget += repeatLength;
                }

                var diff = largeTarget - iterations + 1;
                var target = i - diff;
                matrix = GridBuilder.BuildCharGrid(list[target]);
                break;
            }

            seen.Add(print, i);
            list.Add(print);
        }

        var roundRocks = matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O').ToList();
        var sum = roundRocks.Sum(o => matrix.Height - o.Y);
        return sum;
    }

    public static int RollNorth(string s)
    {
        var matrix = GridBuilder.BuildCharGrid(s);
        MoveNorth(matrix);
        var roundRocks = matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O').ToList();
        var sum = roundRocks.Sum(o => matrix.Height - o.Y);

        return sum;
    }

    private static void MoveNorth(Grid<char> grid) =>
        Move(grid, c => c.OrderBy(o => o.Y).ThenBy(o => o.X), CanMoveNorth, m => m.MoveUp());

    private static void MoveEast(Grid<char> grid) =>
        Move(grid, c => c.OrderByDescending(o => o.X).ThenBy(o => o.Y), CanMoveEast, m => m.MoveRight());

    private static void MoveSouth(Grid<char> grid) =>
        Move(grid, c => c.OrderByDescending(o => o.Y).ThenBy(o => o.X), CanMoveSouth, m => m.MoveDown());

    private static void MoveWest(Grid<char> grid) =>
        Move(grid, c => c.OrderBy(o => o.Y).ThenBy(o => o.X), CanMoveWest, m => m.MoveLeft());

    private static void Move(
        Grid<char> grid, 
        Func<IEnumerable<Coord>, IEnumerable<Coord>> order, 
        Func<Grid<char>, bool> canMove, 
        Action<Grid<char>> move)
    {
        var roundRocks = order(grid.Coords.Where(o => grid.ReadValueAt(o) == 'O'));

        foreach (var roundRock in roundRocks)
        {
            grid.MoveTo(roundRock);

            while (canMove(grid))
            {
                grid.WriteValue('.');
                move(grid);
                grid.WriteValue('O');
            }
        }
    }

    public static Grid<char> RunCycle(string s, int iterations)
    {
        var matrix = GridBuilder.BuildCharGrid(s);
        RunCycle(matrix, iterations);
        return matrix;
    }

    private static void RunCycle(Grid<char> grid, int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            RunCycle(grid);
        }
    }

    private static void RunCycle(Grid<char> grid)
    {
        MoveNorth(grid);
        MoveWest(grid);
        MoveSouth(grid);
        MoveEast(grid);
    }

    private static bool CanMoveNorth(Grid<char> grid) =>
        CanMove(() => grid.IsAtTopEdge, () => grid.ReadValueAt(grid.Address.X, grid.Address.Y - 1));

    private static bool CanMoveEast(Grid<char> grid) =>
        CanMove(() => grid.IsAtRightEdge, () => grid.ReadValueAt(grid.Address.X + 1, grid.Address.Y));

    private static bool CanMoveSouth(Grid<char> grid) =>
        CanMove(() => grid.IsAtBottomEdge, () => grid.ReadValueAt(grid.Address.X, grid.Address.Y + 1));

    private static bool CanMoveWest(Grid<char> grid) => 
        CanMove(() => grid.IsAtLeftEdge, () => grid.ReadValueAt(grid.Address.X - 1, grid.Address.Y));

    private static bool CanMove(Func<bool> isAtEdge, Func<char> readValue)
    {
        if (isAtEdge())
            return false;

        return readValue() is not ('#' or 'O');
    }
}