using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202214;

public class FallingSand
{
    private readonly Coord _sandSource = new(500, 0);

    public int Part1(string input)
    {
        var matrix = BuildMatrix(input, 1);

        matrix.MoveTo(_sandSource);
        while (matrix.ReadValueAt(_sandSource) == '.')
        {
            var currentSand = _sandSource;

            while (TryMove(matrix, currentSand, out var newSand))
            {
                currentSand = newSand;

                if (currentSand.Y == matrix.Height - 1)
                    break;
            }

            if (currentSand.Y == matrix.Height - 1)
                break;

            matrix.WriteValueAt(currentSand, 'o');
        }

        return matrix.Values.Count(o => o == 'o');
    }

    public int Part2(string input)
    {
        var matrix = BuildMatrix(input, 2);

        matrix.MoveTo(_sandSource);
        while (matrix.ReadValueAt(_sandSource) == '.')
        {
            var currentSand = _sandSource;
            while (TryMove(matrix, currentSand, out var newSand))
            {
                currentSand = newSand;
            }

            matrix.WriteValueAt(currentSand, 'o');
        }

        return matrix.Values.Count(o => o == 'o');
    }

    private static Matrix<char> BuildMatrix(string input, int part)
    {
        var matrix = new Matrix<char>(1, 1, '.');
        var lines = StringReader.ReadLines(input, false);

        var coordLists = lines.Select(o => o.Split(" -> "));
        foreach (var coordList in coordLists)
        {
            var coords = new List<Coord>();
            foreach (var coord in coordList)
            {
                var parts = coord.Split(',');
                var x = int.Parse(parts[0]);
                var y = int.Parse(parts[1]);
                coords.Add(new Coord(x, y));
            }

            for (var i = 1; i < coords.Count; i++)
            {
                var a = coords[i - 1];
                var b = coords[i];

                var minX = Math.Min(a.X, b.X);
                var minY = Math.Min(a.Y, b.Y);
                var maxX = Math.Max(a.X, b.X);
                var maxY = Math.Max(a.Y, b.Y);
                
                if (a.X == b.X)
                {
                    var x = a.X;
                    for (var y = minY; y <= maxY; y++)
                    {
                        matrix.MoveTo(x, y);
                        matrix.WriteValueAt(x, y, '#');
                    }
                }
                else
                {
                    var y = a.Y;
                    for (var x = minX; x <= maxX; x++)
                    {
                        matrix.MoveTo(x, y);
                        matrix.WriteValueAt(x, y, '#');
                    }
                }
            }
        }

        if (part == 1)
        {
            matrix.ExtendRight();
        }

        if (part == 2)
        {
            matrix.ExtendRight(matrix.Width);
            matrix.ExtendDown(2);
            var sy = matrix.Height - 1;
            for (var x = 0; x < matrix.Width; x++)
            {
                matrix.WriteValueAt(x, sy, '#');
            }
        }

        return matrix;
    }

    private static bool TryMove(Matrix<char> matrix, Coord currentSand, out Coord newSand)
    {
        var down = new Coord(currentSand.X, currentSand.Y + 1);
        matrix.MoveTo(down);

        if (matrix.ReadValueAt(down) == '.')
        {
            newSand = down;
            return true;
        }

        var downLeft = new Coord(down.X - 1, down.Y);
        matrix.MoveTo(downLeft);
        if (matrix.ReadValueAt(downLeft) == '.')
        {
            newSand = downLeft;
            return true;
        }

        var downRight = new Coord(down.X + 1, down.Y);
        matrix.MoveTo(downRight);
        if (matrix.ReadValueAt(downRight) == '.')
        {
            newSand = downRight;
            return true;
        }

        newSand = currentSand;
        return false;
    }
}