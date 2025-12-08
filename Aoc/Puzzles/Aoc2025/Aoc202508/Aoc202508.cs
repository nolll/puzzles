using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202508;

[Name("Playground")]
public class Aoc202508 : AocPuzzle
{
    public PuzzleResult Part1(string input) => new(Part1(input, 1000), "9d41b63fae3576e9a5715332340db926");

    public long Part1(string input, int pairCount)
    {
        var coords = ParseCoords(input);
        var distances = CalculateDistances(coords);
        var edges = new List<GraphEdge>();
        foreach (var d in distances.Take(pairCount)) 
            edges.AddRange(CreateEdges(d.from, d.to));
        
        var nodes = Graph.GetNodes(edges);
        var groups = Graph.GetConnectedComponents(nodes).Select(o => o.Values);
        
        groups = groups.OrderByDescending(o => o.Count).ToList();
        var top3 = groups.Take(3).ToList();
        return top3[0].Count * top3[1].Count * top3[2].Count;
    }
    
    public PuzzleResult Part2(string input)
    {
        var coords = ParseCoords(input);
        var distances = CalculateDistances(coords);
        var edges = new List<GraphEdge>();
        foreach (var d in distances)
        {
            edges.AddRange(CreateEdges(d.from, d.to));
            var nodes = Graph.GetNodes(edges);
            var groups = Graph.GetConnectedComponents(nodes).Select(o => o.Values).ToList();
            if (groups.Count == 1 && groups.First().Count == coords.Count)
            {
                return new(d.from.X * d.to.X, "c56dc2d8144124824b8b8cdb4b49d868");
            }
        }
        
        return PuzzleResult.Empty;
    }

    private static List<Coord3d> ParseCoords(string input) => input.Split(LineBreaks.Single)
        .Select(o => o.Split(',').Select(int.Parse).ToArray())
        .Select(o => new Coord3d(o[0], o[1], o[2])).ToList();

    private List<(Coord3d from, Coord3d to, double distance)> CalculateDistances(List<Coord3d> coords)
    {
        var distances = new List<(Coord3d from, Coord3d to, double distance)>();
        for (var i = 0; i < coords.Count - 1; i++)
        {
            for (var j = i + 1; j < coords.Count; j++)
            {
                distances.Add((coords[i], coords[j], coords[i].EuclideanDistanceTo(coords[j])));
            }
        }

        return distances.OrderBy(o => o.distance).ToList();
    }

    private static IEnumerable<GraphEdge> CreateEdges(Coord3d a, Coord3d b)
    {
        yield return new GraphEdge(a.Id, b.Id);
        yield return new GraphEdge(b.Id, a.Id);
    }
}