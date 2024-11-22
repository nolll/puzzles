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

    private static void MoveNorth(Matrix<char> matrix) =>
        Move(matrix, c => c.OrderBy(o => o.Y).ThenBy(o => o.X), CanMoveNorth, m => m.MoveUp());

    private static void MoveEast(Matrix<char> matrix) =>
        Move(matrix, c => c.OrderByDescending(o => o.X).ThenBy(o => o.Y), CanMoveEast, m => m.MoveRight());

    private static void MoveSouth(Matrix<char> matrix) =>
        Move(matrix, c => c.OrderByDescending(o => o.Y).ThenBy(o => o.X), CanMoveSouth, m => m.MoveDown());

    private static void MoveWest(Matrix<char> matrix) =>
        Move(matrix, c => c.OrderBy(o => o.Y).ThenBy(o => o.X), CanMoveWest, m => m.MoveLeft());

    private static void Move(
        Matrix<char> matrix, 
        Func<IEnumerable<MatrixAddress>, IEnumerable<MatrixAddress>> order, 
        Func<Matrix<char>, bool> canMove, 
        Action<Matrix<char>> move)
    {
        var roundRocks = order(matrix.Coords.Where(o => matrix.ReadValueAt(o) == 'O'));

        foreach (var roundRock in roundRocks)
        {
            matrix.MoveTo(roundRock);

            while (canMove(matrix))
            {
                matrix.WriteValue('.');
                move(matrix);
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

    private static void RunCycle(Matrix<char> matrix, int iterations)
    {
        for (var i = 0; i < iterations; i++)
        {
            RunCycle(matrix);
        }
    }

    private static void RunCycle(Matrix<char> matrix)
    {
        MoveNorth(matrix);
        MoveWest(matrix);
        MoveSouth(matrix);
        MoveEast(matrix);
    }

    private static bool CanMoveNorth(Matrix<char> matrix) =>
        CanMove(() => matrix.IsAtTopEdge, () => matrix.ReadValueAt(matrix.Address.X, matrix.Address.Y - 1));

    private static bool CanMoveEast(Matrix<char> matrix) =>
        CanMove(() => matrix.IsAtRightEdge, () => matrix.ReadValueAt(matrix.Address.X + 1, matrix.Address.Y));

    private static bool CanMoveSouth(Matrix<char> matrix) =>
        CanMove(() => matrix.IsAtBottomEdge, () => matrix.ReadValueAt(matrix.Address.X, matrix.Address.Y + 1));

    private static bool CanMoveWest(Matrix<char> matrix) => 
        CanMove(() => matrix.IsAtLeftEdge, () => matrix.ReadValueAt(matrix.Address.X - 1, matrix.Address.Y));

    private static bool CanMove(Func<bool> isAtEdge, Func<char> readValue)
    {
        if (isAtEdge())
            return false;

        return readValue() is not ('#' or 'O');
    }
}