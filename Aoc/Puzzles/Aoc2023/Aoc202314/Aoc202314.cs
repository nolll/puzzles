using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202314;

[Name("Parabolic Reflector Dish")]
public class Aoc202314(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var result = RollNorth(input);

        return new PuzzleResult(result, "38c4a3857389e8b424b86782b940d736");
    }

    protected override PuzzleResult RunPart2()
    {
        var result = RunManyCycles(input);
        
        return new PuzzleResult(result, "bc4f573f0b32490dec258ffe95e3b88b");
    }

    public static int RunManyCycles(string s)
    {
        const int iterations = 1_000_000_000;
        var seen = new Dictionary<string, int>();
        var list = new List<string>();
        var matrix = MatrixBuilder.BuildCharMatrix(s);

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
                matrix = MatrixBuilder.BuildCharMatrix(list[target]);
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
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        MoveNorth(matrix);
        var roundRocks = matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O').ToList();
        var sum = roundRocks.Sum(o => matrix.Height - o.Y);

        return sum;
    }

    private static void MoveNorth(Matrix<char> matrix)
    {
        var roundRocks = matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O')
            .OrderBy(o => o.Y).ThenBy(o => o.X)
            .ToList();

        foreach (var roundRock in roundRocks)
        {
            matrix.MoveTo(roundRock);

            while (CanMoveNorth(matrix))
            {
                matrix.WriteValue('.');
                matrix.MoveUp();
                matrix.WriteValue('O');
            }
        }
    }

    private static void MoveEast(Matrix<char> matrix)
    {
        var roundRocks = matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O')
            .OrderByDescending(o => o.X).ThenBy(o => o.Y)
            .ToList();

        foreach (var roundRock in roundRocks)
        {
            matrix.MoveTo(roundRock);

            while (CanMoveEast(matrix))
            {
                matrix.WriteValue('.');
                matrix.MoveRight();
                matrix.WriteValue('O');
            }
        }
    }

    private static void MoveSouth(Matrix<char> matrix)
    {
        var roundRocks = matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O')
            .OrderByDescending(o => o.Y).ThenBy(o => o.X)
            .ToList();

        foreach (var roundRock in roundRocks)
        {
            matrix.MoveTo(roundRock);

            while (CanMoveSouth(matrix))
            {
                matrix.WriteValue('.');
                matrix.MoveDown();
                matrix.WriteValue('O');
            }
        }
    }

    private static void MoveWest(Matrix<char> matrix)
    {
        var roundRocks = matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O')
            .OrderBy(o => o.Y).ThenBy(o => o.X)
            .ToList();

        foreach (var roundRock in roundRocks)
        {
            matrix.MoveTo(roundRock);

            while (CanMoveWest(matrix))
            {
                matrix.WriteValue('.');
                matrix.MoveLeft();
                matrix.WriteValue('O');
            }
        }
    }

    public static Matrix<char> RunCycle(string s, int iterations)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(s);
        RunCycle(matrix, iterations);
        return matrix;
    }

    public static void RunCycle(Matrix<char> matrix, int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            RunCycle(matrix);
        }
    }

    public static void RunCycle(Matrix<char> matrix)
    {
        MoveNorth(matrix);
        MoveWest(matrix);
        MoveSouth(matrix);
        MoveEast(matrix);
    }

    private static bool CanMoveNorth(Matrix<char> matrix)
    {
        if (matrix.IsAtTop)
            return false;

        var northValue = matrix.ReadValueAt(matrix.Address.X, matrix.Address.Y - 1);
        if (northValue is '#' or 'O')
            return false;

        return true;
    }

    private static bool CanMoveEast(Matrix<char> matrix)
    {
        if (matrix.IsAtRightEdge)
            return false;

        var eastValue = matrix.ReadValueAt(matrix.Address.X + 1, matrix.Address.Y);
        if (eastValue is '#' or 'O')
            return false;

        return true;
    }

    private static bool CanMoveSouth(Matrix<char> matrix)
    {
        if (matrix.IsAtBottom)
            return false;

        var southValue = matrix.ReadValueAt(matrix.Address.X, matrix.Address.Y + 1);
        if (southValue is '#' or 'O')
            return false;

        return true;
    }

    private static bool CanMoveWest(Matrix<char> matrix)
    {
        if (matrix.IsAtLeftEdge)
            return false;

        var westValue = matrix.ReadValueAt(matrix.Address.X - 1, matrix.Address.Y);
        if (westValue is '#' or 'O')
            return false;

        return true;
    }
}