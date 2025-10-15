using System.Diagnostics;

namespace Pzl.Tools.Grids.Grids2d;

public static class PathFinder
{
    public static IEnumerable<Coord> ShortestPathTo(
        Grid<char> grid, 
        Coord from, 
        Coord to,
        Func<Grid<char>, Coord, IEnumerable<Coord>>? neighborFunc = null)
    {
        var coordSet = GetCoordCounts(grid, from, to, neighborFunc ?? GetNeighbors).ToDictionary(o => o.Coord, o => o.Count);

        var path = new List<Coord>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            var bestAddress = grid.OrthogonalAdjacentCoordsTo(currentAddress)
                .Where(o => coordSet.ContainsKey(o))
                .OrderBy(o => coordSet[o])
                .ThenBy(o => o.Y)
                .ThenBy(o => o.X)
                .FirstOrDefault();
            
            if (bestAddress == null)
                break;

            currentAddress = bestAddress;
            path.Add(bestAddress);
        }

        return path;
    }

    private static IList<CoordCount> GetCoordCounts(
        Grid<char> grid, 
        Coord from, 
        Coord to, 
        Func<Grid<char>, Coord, IEnumerable<Coord>> neighborFunc)
    {
        var queue = new List<CoordCount> { new(to, 0) };
        var seen = new HashSet<Coord> { to };
        var index = 0;
        while (index < queue.Count && !seen.Contains(from))
        {
            var next = queue[index];
            var nextCount = next.Count + 1;
            var adjacentCoords = neighborFunc(grid, next.Coord).Where(o => !seen.Contains(o));
            foreach (var adj in adjacentCoords)
            {
                var cc = new CoordCount(adj, nextCount);
                queue.Add(cc);
                seen.Add(adj);
            }
            index++;
        }

        return queue;
    }

    private static IEnumerable<Coord> GetNeighbors(Grid<char> grid, Coord coord) => 
        grid.OrthogonalAdjacentCoordsTo(coord).Where(o => grid.ReadValueAt(o) == '.');
}

[DebuggerDisplay("{Coord.X},{Coord.Y},{Count}")]
public class CoordCount(Coord coord, int count)
{
    public int Count { get; } = count;
    public Coord Coord { get; } = coord;
}