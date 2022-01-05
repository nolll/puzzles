using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems;

namespace Core.Puzzles.Year2019.Day17;

public class ScaffoldIntersectionFinder
{
    private readonly Matrix<char> _matrix;

    public ScaffoldIntersectionFinder(string input)
    {
        _matrix = BuildMatrix(input);
    }

    public int GetSumOfAlignmentParameters()
    {
        var intersections = GetIntersections().ToList();
        var sum = intersections.Sum(o => o.X * o.Y);
        return sum;
    }

    private IEnumerable<MatrixAddress> GetIntersections()
    {
        var intersections = new List<MatrixAddress>();

        for (var x = 0; x < _matrix.Width; x++)
        {
            for (var y = 0; y < _matrix.Height; y++)
            {
                if (IsIntersection(x, y))
                    intersections.Add(new MatrixAddress(x, y));
            }
        }

        return intersections;
    }

    private char? GetValueAt(int x, int y)
    {
        if (_matrix.IsOutOfRange(new MatrixAddress(x, y)))
            return null;
        return _matrix.ReadValueAt(x, y);
    }

    private bool IsIntersection(int x, int y)
    {
        var v = GetValueAt(x, y);
        if (v == '.')
            return false;

        v = GetValueAt(x, y - 1);
        if (v == '.')
            return false;

        v = GetValueAt(x + 1, y);
        if (v == '.')
            return false;

        v = GetValueAt(x, y + 1);
        if (v == '.')
            return false;

        v = GetValueAt(x - 1, y);
        if (v == '.')
            return false;

        return true;
    }

    private Matrix<char> BuildMatrix(string map)
    {
        var matrix = new Matrix<char>();
        var rows = map.Trim().Split('\n');
        var y = 0;
        foreach (var row in rows)
        {
            var x = 0;
            var chars = row.Trim().ToCharArray();
            foreach (var c in chars)
            {
                matrix.MoveTo(x, y);
                matrix.WriteValue(c);
                x += 1;
            }

            y += 1;
        }

        return matrix;
    }
}