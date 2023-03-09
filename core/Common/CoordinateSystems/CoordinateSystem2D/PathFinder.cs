using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Core.Common.CoordinateSystems.CoordinateSystem2D;

public static class PathFinder
{
    public static int StepCountTo(Matrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = GetCoordCounts(matrix, from, to);
        var goal = coordCounts.FirstOrDefault(o => o.X == to.X && o.Y == to.Y);
        return goal?.Count ?? 0;
    }

    public static int CachedStepCountTo(Matrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        return CachedStepCountTo(matrix, new List<MatrixAddress>{ from }, to);
    }

    public static int CachedStepCountTo(Matrix<char> matrix, IList<MatrixAddress> from, MatrixAddress to)
    {
        var coordCounts = CachedGetCoordCounts(matrix, from, to);
        var goal = coordCounts.FirstOrDefault(o => o.X == to.X && o.Y == to.Y);
        return goal?.Count ?? 0;
    }

    public static IList<MatrixAddress> ShortestPathTo(Matrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = GetCoordCounts(matrix, from, to);
        var pathMatrix = new Matrix<int>(matrix.Width, matrix.Height, -1);
        foreach (var coordCount in coordCounts)
        {
            pathMatrix.MoveTo(coordCount.X, coordCount.Y);
            pathMatrix.WriteValue(coordCount.Count);
        }

        var path = new List<MatrixAddress>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            pathMatrix.MoveTo(currentAddress);
            var adjacentCoords = pathMatrix.PerpendicularAdjacentCoords
                .Where(o => pathMatrix.ReadValueAt(o) > -1)
                .OrderBy(o => pathMatrix.ReadValueAt(o))
                .ThenBy(o => o.Y)
                .ThenBy(o => o.X)
                .ToList();
            var bestAddress = adjacentCoords.FirstOrDefault();
            if (bestAddress == null)
                break;
            currentAddress = new MatrixAddress(bestAddress.X, bestAddress.Y);
            path.Add(currentAddress);
        }

        return path;
    }

    public static IList<MatrixAddress> CachedShortestPathTo(Matrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = CachedGetCoordCounts(matrix, new List<MatrixAddress>{ from }, to);
        var pathMatrix = new Matrix<int>(matrix.Width, matrix.Height, -1);
        foreach (var coordCount in coordCounts)
        {
            pathMatrix.MoveTo(coordCount.X, coordCount.Y);
            pathMatrix.WriteValue(coordCount.Count);
        }

        var path = new List<MatrixAddress>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            pathMatrix.MoveTo(currentAddress);
            var adjacentCoords = pathMatrix.PerpendicularAdjacentCoords
                .Where(o => pathMatrix.ReadValueAt(o) > -1)
                .OrderBy(o => pathMatrix.ReadValueAt(o))
                .ThenBy(o => o.Y)
                .ThenBy(o => o.X)
                .ToList();
            var bestAddress = adjacentCoords.FirstOrDefault();
            if (bestAddress == null)
                break;
            currentAddress = new MatrixAddress(bestAddress.X, bestAddress.Y);
            path.Add(currentAddress);
        }

        return path;
    }

    private static IList<CoordCount> GetCoordCounts(Matrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        var queue = new List<CoordCount> { new(to.X, to.Y, 0) };
        var index = 0;
        while (index < queue.Count && !queue.Any(o => o.X == from.X && o.Y == from.Y))
        {
            var next = queue[index];
            matrix.MoveTo(next.X, next.Y);
            var adjacentCoords = matrix.PerpendicularAdjacentCoords
                .Where(o => matrix.ReadValueAt(o) == '.' && !queue.Any(q => q.X == o.X && q.Y == o.Y))
                .ToList();
            var newCoordCounts = adjacentCoords.Select(o => new CoordCount(o.X, o.Y, next.Count + 1));
            queue.AddRange(newCoordCounts);
            index++;
        }

        return queue;
    }

    private static IList<CoordCount> CachedGetCoordCounts(Matrix<char> matrix, IList<MatrixAddress> from, MatrixAddress to)
    {
        var seen = from.ToDictionary(k => k, v => 0);
        var queue = from.ToList();
        var index = 0;
        while (index < queue.Count && !seen.ContainsKey(to))
        {
            var next = queue[index];
            var count = seen[next];
            matrix.MoveTo(next.X, next.Y);
            var adjacentCoords = matrix.PerpendicularAdjacentCoords
                .Where(o => matrix.ReadValueAt(o) == '.' && !seen.ContainsKey(o))
                .ToList();
            queue.AddRange(adjacentCoords);
            foreach (var adjacentCoord in adjacentCoords)
                seen[adjacentCoord] = count + 1;
            index++;
        }

        return queue.Select(o => new CoordCount(o, seen[o])).ToList();
    }
}

[DebuggerDisplay("{X},{Y},{Count}")]
public class CoordCount
{
    public int X { get; }
    public int Y { get; }
    public int Count { get; }

    public CoordCount(int x, int y, int count)
    {
        X = x;
        Y = y;
        Count = count;
    }

    public CoordCount(MatrixAddress coord, int count)
    {
        X = coord.X;
        Y = coord.Y;
        Count = count;
    }
}