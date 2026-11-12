using Pzl.Tools.Graphs;

namespace Pzl.Tools.Grids.Grids2d;

public static class GridExtensions
{
    public static void Deconstruct(this Coord coord, out int x, out int y)
    {
        x = coord.X;
        y = coord.Y;
    }
    
    public static IEnumerable<GraphEdge> GetEdges(this Grid<char> grid, Func<Grid<char>, Coord, IEnumerable<Coord>>? neighborFunc = null)
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
    
    public static Dictionary<string, HashSet<string>> GetNeighbors(this Grid<char> grid, Func<Grid<char>, Coord, IEnumerable<Coord>>? neighborFunc = null)
    {
        var getNeighbors = neighborFunc ?? GetNeighbors;

        var dictionary = new Dictionary<string, HashSet<string>>();
        foreach (var coord in grid.Coords)
        {
            dictionary.Add(coord.Id, []);
            foreach (var adj in getNeighbors(grid, coord))
            {
                dictionary[coord.Id].Add(adj.Id);
            }
        }

        return dictionary;
    }

    private static IEnumerable<Coord> GetNeighbors(Grid<char> grid, Coord coord) =>
        grid.OrthogonalAdjacentCoordsTo(coord).Where(o => grid.ReadValueAt(o) == '.');
}