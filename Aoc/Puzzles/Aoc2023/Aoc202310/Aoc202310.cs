using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2023.Aoc202310;

[Name("Pipe Maze")]
public class Aoc202310 : AocPuzzle
{
    public PuzzleResult RunPart1(string input) => 
        new(FarthestPoint(input), "7307413d1efe2d8b5a4994a204a50a86");

    public PuzzleResult RunPart2(string input) => 
        new(EnclosedTileCount(input), "59413d1f83d3d395818ceddd09c64bbf");

    public static int FarthestPoint(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var startPoint = matrix.Coords.First(o => matrix.ReadValueAt(o) == 'S');
        var startPointChar = GetStartPointChar(matrix, startPoint);
        matrix.WriteValueAt(startPoint, startPointChar);
        var loop = GetLoop(matrix, startPoint);

        return loop.Count / 2;
    }

    private static char GetStartPointChar(Matrix<char> matrix, Coord startPoint)
    {
        var (x, y) = startPoint;
        var top = matrix.ReadValueAt(new Coord(x, y - 1));
        var right = matrix.ReadValueAt(new Coord(x + 1, y));
        var bottom = matrix.ReadValueAt(new Coord(x, y + 1));
        var left = matrix.ReadValueAt(new Coord(x - 1, y));

        var enterFromTop = top is 'F' or '|' or '7';
        var enterFromRight = right is 'J' or '-' or '7';
        var enterFromBottom = bottom is 'J' or '|' or 'L';
        var enterFromLeft = left is 'F' or '-' or 'L';

        if (enterFromTop && enterFromRight)
            return 'L';
        if (enterFromRight && enterFromBottom)
            return 'F';
        if (enterFromBottom && enterFromLeft)
            return '7';
        if (enterFromLeft && enterFromTop)
            return 'J';
        if (enterFromTop && enterFromBottom)
            return '|';
        return '-';
    }

    public static int EnclosedTileCount(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var startPoint = matrix.Coords.First(o => matrix.ReadValueAt(o) == 'S');
        var startPointChar = GetStartPointChar(matrix, startPoint);
        matrix.WriteValueAt(startPoint, startPointChar);
        var loopPath = GetLoop(matrix, startPoint).ToHashSet();
        var otherCoords = matrix.Coords.Where(o => !loopPath.Contains(o)).ToList();

        foreach (var otherCoord in otherCoords)
        {
            matrix.WriteValueAt(otherCoord, '.');
        }

        var enlargedMatrix = EnlargeMatrix(matrix);
        var target = new Coord(enlargedMatrix.XMax, enlargedMatrix.YMax);
        var queue = new Queue<Coord>();
        queue.Enqueue(target);
        var seen = new HashSet<Coord>();
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            seen.Add(current);
            if (enlargedMatrix.ReadValueAt(current) != '.')
                continue; 

            enlargedMatrix.WriteValueAt(current, 'O');
            var adjacent = enlargedMatrix.OrthogonalAdjacentCoordsTo(current);
            foreach (var a in adjacent)
            {
                if (!seen.Contains(a))
                {
                    queue.Enqueue(a);
                }
            }
        }

        return otherCoords.Count(o => enlargedMatrix.ReadValueAt(o.X * 2 + 1, o.Y * 2 + 1) == '.');
    }

    private static List<Coord> GetLoop(Matrix<char> matrix, Coord startPoint)
    {
        var currentPoint = startPoint;

        var stepCount = 0;
        var seen = new HashSet<Coord>();
        var loop = new List<Coord>();
        while (!seen.Contains(currentPoint) && stepCount < 100000)
        {
            var connections = FindConnections(matrix, currentPoint);
            seen.Add(currentPoint);
            loop.Add(currentPoint);
            var nextPoint = connections.FirstOrDefault(o => !seen.Contains(o));
            if (nextPoint is null)
                break;
            currentPoint = nextPoint;
            stepCount++;
        }

        return loop;
    }

    private static IEnumerable<Coord> FindConnections(Matrix<char> matrix, Coord currentPoint)
    {
        var currentPipePart = matrix.ReadValueAt(currentPoint);

        var (x, y) = currentPoint;
        var top = new Coord(x, y - 1);
        var right = new Coord(x + 1, y);
        var bottom = new Coord(x, y + 1);
        var left = new Coord(x - 1, y);

        return currentPipePart switch
        {
            '-' => [right, left],
            '|' => [top, bottom],
            '7' => [bottom, left],
            'J' => [top, left],
            'L' => [top, right],
            'F' => [right, bottom],
            _ => [right, bottom]
        };
    }

    public static Matrix<char> EnlargeMatrix(Matrix<char> matrix)
    {
        var enlarged = new Matrix<char>(matrix.Width * 2 + 2, matrix.Height * 2 + 2, '.');
        foreach (var coord in matrix.Coords)
        {
            var x = coord.X * 2 + 1;
            var y = coord.Y * 2 + 1;
            var v = matrix.ReadValueAt(coord);
            var downValue = v is '|' or 'F' or '7'
                ? '|'
                : '.';
            var rightValue = v is '-' or 'F' or 'L'
                ? '-'
                : '.';
            enlarged.WriteValueAt(x, y, v);
            enlarged.WriteValueAt(x + 1, y, rightValue);
            enlarged.WriteValueAt(x, y + 1, downValue);
            enlarged.WriteValueAt(x + 1, y + 1, '.');
        }

        return enlarged;
    }
}