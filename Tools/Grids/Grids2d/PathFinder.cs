using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids2d;

public static class PathFinder
{
    public static IList<Coord> ShortestPathTo(
        Grid<char> grid, 
        Coord from, 
        Coord to,
        Func<Grid<char>, Coord, List<Coord>>? neighborFunc = null)
    {
        var coordCounts = GetCoordCounts(grid, from, to, neighborFunc ?? GetNeighbors);
        var pathGrid = new Grid<int>(grid.Width, grid.Height, -1);
        foreach (var coordCount in coordCounts)
        {
            pathGrid.MoveTo(coordCount.X, coordCount.Y);
            pathGrid.WriteValue(coordCount.Count);
        }

        var path = new List<Coord>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            pathGrid.MoveTo(currentAddress);
            var adjacentCoords = pathGrid.OrthogonalAdjacentCoords
                .Where(o => pathGrid.ReadValueAt(o) > -1)
                .OrderBy(o => pathGrid.ReadValueAt(o))
                .ThenBy(o => o.Y)
                .ThenBy(o => o.X)
                .ToList();
            var bestAddress = adjacentCoords.FirstOrDefault();
            if (bestAddress == null)
                break;
            currentAddress = new Coord(bestAddress.X, bestAddress.Y);
            path.Add(currentAddress);
        }

        return path;
    }

    private static IList<CoordCount> GetCoordCounts(
        Grid<char> grid, 
        Coord from, 
        Coord to, 
        Func<Grid<char>, Coord, List<Coord>> neighborFunc)
    {
        var queue = new List<CoordCount> { new(to.X, to.Y, 0) };
        var seen = new HashSet<Coord> { to };
        var index = 0;
        while (index < queue.Count && !seen.Contains(from))
        {
            var next = queue[index];
            grid.MoveTo(next.X, next.Y);
            var adjacentCoords = neighborFunc(grid, grid.Coord).Where(o => !seen.Contains(o)).ToList();
            var newCoordCounts = adjacentCoords.Select(o => new CoordCount(o, next.Count + 1)).ToList();
            queue.AddRange(newCoordCounts);
            foreach (var coordCount in newCoordCounts)
            {
                seen.Add(coordCount.Coord);
            }
            index++;
        }

        return queue;
    }

    private static List<Coord> GetNeighbors(Grid<char> grid, Coord coord) => 
        grid.OrthogonalAdjacentCoords.Where(o => grid.ReadValueAt(o) == '.').ToList();
}

[DebuggerDisplay("{X},{Y},{Count}")]
public class CoordCount
{
    public int X { get; }
    public int Y { get; }
    public int Count { get; }
    public Coord Coord { get; } = new(0, 0);

    public CoordCount(int x, int y, int count)
    {
        X = x;
        Y = y;
        Count = count;
    }

    public CoordCount(Coord coord, int count)
    {
        X = coord.X;
        Y = coord.Y;
        Coord = coord;
        Count = count;
    }
}