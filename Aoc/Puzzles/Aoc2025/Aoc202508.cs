using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids3D;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025;

[Name("Playground")]
public class Aoc202508 : AocPuzzle
{
    [Puzzle("9d41b63fae3576e9a5715332340db926")]
    public long Part1(string input) => Part1(input, 1000);

    public long Part1(string input, int pairCount)
    {
        var coords = ParseCoords(input);
        var distances = CalculateDistances(coords);
        var edges = new List<GraphEdge>();
        foreach (var d in distances.Take(pairCount)) 
            edges.AddRange(CreateEdges(d.from, d.to));
        
        var nodes = Graph.GetNodes(edges);
        var groups = Graph.GetConnectedComponents(nodes).Select(o => o.Values);
        
        groups = [.. groups.OrderByDescending(o => o.Count)];
        var top3 = groups.Take(3).ToList();
        return top3[0].Count * top3[1].Count * top3[2].Count;
    }
    
    [Puzzle("c56dc2d8144124824b8b8cdb4b49d868")]
    public int? Part2(string input)
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
                return d.from.X * d.to.X;
            }
        }
        
        return null;
    }

    private static List<Coord3D> ParseCoords(string input) => [.. input.Split(LineBreaks.Single).Select(ParseCoord)];

    private static Coord3D ParseCoord(string s)
    {
        var (x, y, z) = Numbers.IntsFromString(s);
        return new Coord3D(x, y, z);
    }

    private List<(Coord3D from, Coord3D to, double distance)> CalculateDistances(List<Coord3D> coords)
    {
        var distances = new List<(Coord3D from, Coord3D to, double distance)>();
        for (var i = 0; i < coords.Count - 1; i++)
        {
            for (var j = i + 1; j < coords.Count; j++)
            {
                distances.Add((coords[i], coords[j], coords[i].EuclideanDistanceTo(coords[j])));
            }
        }

        return distances.OrderBy(o => o.distance).ToList();
    }

    private static IEnumerable<GraphEdge> CreateEdges(Coord3D a, Coord3D b)
    {
        yield return new GraphEdge(a.Id, b.Id);
        yield return new GraphEdge(b.Id, a.Id);
    }
}