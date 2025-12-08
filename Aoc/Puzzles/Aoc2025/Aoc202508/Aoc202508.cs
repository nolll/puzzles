using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids3d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202508;

[Name("Playground")]
public class Aoc202508 : AocPuzzle
{
    public PuzzleResult Part1(string input) => new(Part1(input, 1000), "9d41b63fae3576e9a5715332340db926");

    public PuzzleResult Part2(string input) => new(Part2(input, 1000), "c56dc2d8144124824b8b8cdb4b49d868");

    public long Part1(string input, int pairCount)
    {
        var lines = input.Split(LineBreaks.Single);
        var coords = lines.Select(line => line.Split(',').Select(int.Parse).ToArray()).Select(o => new Coord3d(o[0], o[1], o[2])).ToList();

        var distances = new List<(Coord3d from, Coord3d to, double distance)>();
        var edges = new List<GraphEdge>();
        for (var i = 0; i < coords.Count - 1; i++)
        {
            for (var j = i + 1; j < coords.Count; j++)
            {
                distances.Add((coords[i], coords[j], coords[i].EuclideanDistanceTo(coords[j])));
            }
        }

        distances = distances.OrderBy(o => o.distance).ToList();

        foreach (var d in distances.Take(pairCount))
        {
            edges.Add(new GraphEdge(d.from.Id, d.to.Id));
            edges.Add(new GraphEdge(d.to.Id, d.from.Id));
        }
        
        var nodes = Graph.GetNodes(edges);
        var groups = Graph.GetConnectedComponents(nodes).Select(o => o.Values);
        
        groups = groups.OrderByDescending(o => o.Count).ToList();
        var top3 = groups.Take(3).ToList();
        return top3[0].Count * top3[1].Count * top3[2].Count;
    }
    
    public long Part2(string input, int startAt)
    {
        var lines = input.Split(LineBreaks.Single);
        var coords = lines.Select(line => line.Split(',').Select(int.Parse).ToArray()).Select(o => new Coord3d(o[0], o[1], o[2])).ToList();

        var distances = new List<(Coord3d from, Coord3d to, double distance)>();
        var edges = new List<GraphEdge>();
        for (var i = 0; i < coords.Count - 1; i++)
        {
            for (var j = i + 1; j < coords.Count; j++)
            {
                distances.Add((coords[i], coords[j], coords[i].EuclideanDistanceTo(coords[j])));
            }
        }

        distances = distances.OrderBy(o => o.distance).ToList();
        var firstBatch = distances.Take(startAt);
        var theRest = distances.Skip(startAt);

        foreach (var d in firstBatch)
        {
            edges.Add(new GraphEdge(d.from.Id, d.to.Id));
            edges.Add(new GraphEdge(d.to.Id, d.from.Id));
        }

        foreach (var d in theRest)
        {
            edges.Add(new GraphEdge(d.from.Id, d.to.Id));
            edges.Add(new GraphEdge(d.to.Id, d.from.Id));
            var nodes = Graph.GetNodes(edges);
            var groups = Graph.GetConnectedComponents(nodes).Select(o => o.Values).ToList();
            if (groups.Count == 1 && groups.First().Count == coords.Count)
            {
                return d.from.X * d.to.X;
            }
        }

        return 0;
    }
}