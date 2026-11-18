using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Shardorithm")]
public class Ece202614 : EverybodyEventPuzzle
{
    [Puzzle("f8edf60eba791291edc0affdd3910b97")]
    public int Part1(string input) => GetConnections(GridBuilder.BuildCharGrid(input)).Count;

    [Puzzle("0b589d358ccecbb82fa7c6ed5e03e436")]
    public long Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var connections = GetConnections(grid);
        var pieces = GetPieces(grid, connections);
        var edges = GetEdges(pieces);

        return Kruskal.MinimumSpanningTree(edges);
    }

    [Puzzle("2e5850e43aa94847d8c59a183b2625eb")]
    public long Part3(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var connections = GetConnections(grid);
        var pieces = GetPieces(grid, connections);
        var edges = GetEdges(pieces);

        var names = grid.Values.Distinct().Select(o => o.ToString()).ToList();
        var best = long.MaxValue;
        for (var i = 0; i < names.Count; i++)
        {
            var a = names[i];
            for (var j = i + 1; j < names.Count; j++)
            {
                var b = names[j];
                if (a == b)
                    continue;

                var modifiedEdges = ModifyEdges(edges, [a, b]).ToList();
                best = Math.Min(best, Kruskal.MinimumSpanningTree(modifiedEdges));
            }
        }

        return best;
    }

    private IEnumerable<GraphEdge> ModifyEdges(List<GraphEdge> edges, HashSet<string> free) =>
        edges.Select(edge => free.Contains(edge.From) || free.Contains(edge.To)
            ? edge with { Cost = 0 }
            : edge);

    private static List<GraphEdge> GetEdges(Dictionary<char, List<char>> pieces)
    {
        var edges = new List<GraphEdge>();
        foreach (var piece in pieces)
        {
            var groups = piece.Value.GroupBy(o => o);
            foreach (var group in groups)
            {
                edges.Add(new GraphEdge(piece.Key.ToString(), group.Key.ToString(), group.Count()));
            }
        }

        return edges;
    }

    private static Dictionary<char, List<char>> GetPieces(Grid<char> grid, Dictionary<string, (char, char)> connections)
    {
        var values = grid.Values.Distinct().ToList();
        var pieces = grid.Values.Distinct().ToDictionary(k => k, _ => new List<char>());
        pieces.Add('.', []);
        var names = values.ToHashSet();

        foreach (var connection in connections)
        {
            var (a, b) = connection.Value;
            var ida = names.Contains(a) ? a : '.';
            var idb = names.Contains(b) ? b : '.';

            pieces[ida].Add(idb);
            pieces[idb].Add(ida);
        }

        return pieces;
    }

    private static Dictionary<string, (char, char)> GetConnections(Grid<char> grid)
    {
        var bindings = new Dictionary<string, (char, char)>();
        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            foreach (var dir in GridDirection.Orthogonal)
            {
                var other = coord.Direction(dir);
                var otherV = grid.IsOutOfRange(other)
                    ? '.'
                    : grid.ReadValueAt(other);

                if (otherV == v)
                    continue;

                var ordered = new List<Coord>
                {
                    coord,
                    other
                }.OrderBy(o => o.Y).ThenBy(o => o.X).ToList();
                var id = string.Join("|", ordered[0].Id, ordered[1].Id);
                bindings.TryAdd(id, (v, otherV));
            }
        }

        return bindings;
    }
}