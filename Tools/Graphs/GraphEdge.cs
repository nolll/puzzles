using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Tools.Graphs;

public record GraphEdge(string From, string To, int Cost = 1);

public static class GraphEdgeBuilder
{
    public static IEnumerable<GraphEdge> GetEdges(Grid<char> grid, Func<Grid<char>, Coord, IEnumerable<Coord>>? neighborFunc = null)
    {
        var getNeighbors = neighborFunc ?? GetNeighbors;

        foreach (var coord in grid.Coords)
        {
            foreach (var adj in getNeighbors(grid, coord))
            {
                yield return new GraphEdge(coord.Id, adj.Id);
            }
        }
    }

    private static IEnumerable<Coord> GetNeighbors(Grid<char> grid, Coord coord) =>
        grid.OrthogonalAdjacentCoordsTo(coord).Where(o => grid.ReadValueAt(o) == '.');
}