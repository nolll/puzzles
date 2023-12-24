using System.Diagnostics;

namespace Pzl.Tools.CoordinateSystems.CoordinateSystem2D;

public static class PathFinder
{
    public static int CachedStepCountTo(Matrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = CachedGetCoordCounts(matrix, new List<MatrixAddress> { from }, to);
        var goal = coordCounts.FirstOrDefault(o => o.X == to.X && o.Y == to.Y);
        return goal?.Count ?? 0;
    }

    public static IList<MatrixAddress> ShortestPathTo(
        Matrix<char> matrix, 
        MatrixAddress from, 
        MatrixAddress to,
        Func<Matrix<char>, MatrixAddress, List<MatrixAddress>>? neighborFunc = null)
    {
        var coordCounts = GetCoordCounts(matrix, from, to, neighborFunc ?? GetNeighbors);
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
            var adjacentCoords = pathMatrix.OrthogonalAdjacentCoords
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

    public static IList<MatrixAddress> LongestPathTo(
        Matrix<char> matrix,
        MatrixAddress from,
        MatrixAddress to,
        Func<Matrix<char>, MatrixAddress, List<MatrixAddress>>? neighborFunc = null)
    {
        var coordCounts = GetCoordCounts(matrix, from, to, neighborFunc ?? GetNeighbors);
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
            var adjacentCoords = pathMatrix.OrthogonalAdjacentCoords
                .Where(o => pathMatrix.ReadValueAt(o) > -1)
                .OrderByDescending(pathMatrix.ReadValueAt)
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

    private static IList<CoordCount> GetCoordCounts(
        Matrix<char> matrix, 
        MatrixAddress from, 
        MatrixAddress to, 
        Func<Matrix<char>, MatrixAddress, List<MatrixAddress>> neighborFunc)
    {
        var queue = new List<CoordCount> { new(to.X, to.Y, 0) };
        var seen = new HashSet<(int, int)> { to.Tuple };
        var index = 0;
        while (index < queue.Count && !seen.Contains(from.Tuple))
        {
            var next = queue[index];
            matrix.MoveTo(next.X, next.Y);
            var adjacentCoords = neighborFunc(matrix, matrix.Address).Where(o => !seen.Contains(o.Tuple)).ToList();
            var newCoordCounts = adjacentCoords.Select(o => new CoordCount(o, next.Count + 1)).ToList();
            queue.AddRange(newCoordCounts);
            foreach (var coordCount in newCoordCounts)
            {
                seen.Add(coordCount.Coord.Tuple);
            }
            index++;
        }

        return queue;
    }

    private static List<MatrixAddress> GetNeighbors(Matrix<char> matrix, MatrixAddress coord) => 
        matrix.OrthogonalAdjacentCoords.Where(o => matrix.ReadValueAt(o) == '.').ToList();

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
            var adjacentCoords = matrix.OrthogonalAdjacentCoords
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
    public MatrixAddress Coord { get; } = new(0, 0);

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
        Coord = coord;
        Count = count;
    }
}