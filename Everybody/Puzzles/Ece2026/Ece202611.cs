using System.ComponentModel;
using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Portalignment")]
public class Ece202611 : EverybodyEventPuzzle
{
    [Puzzle("d3ecb33fe754cdce3362d8d1cf61380e")]
    public int Part1(string input)
    {
        var (portalCountInput, lineInput) = input.Split(LineBreaks.Double);
        var portalCount = Numbers.IntsFromString(portalCountInput).First();
        var portals = Enumerable.Range(1, portalCount).Select(o => o.ToString()).ToArray();

        var edges = new List<GraphEdge>();
        for (var i = 0; i < portals.Length; i++)
        {
            var prevPortal = (i + portals.Length - 1) % portals.Length;
            var nextPortal = (i + 1) % portals.Length;

            edges.Add(new GraphEdge(portals[i], portals[prevPortal]));
            edges.Add(new GraphEdge(portals[i], portals[nextPortal]));
        }

        var initialCost = 0;
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;
                initialCost += Dijkstra.BestCost(edges, portal, otherPortal);
            }
        }

        foreach (var line in lineInput.Split(LineBreaks.Single))
        {
            var (p1, p2) = Numbers.IntsFromString(line);
            edges.Add(new GraphEdge(p1.ToString(), p2.ToString()));
            edges.Add(new GraphEdge(p2.ToString(), p1.ToString()));
        }
        
        var optimizedCost = 0;
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;
                optimizedCost += Dijkstra.BestCost(edges, portal, otherPortal);
            }
        }
        
        return initialCost - optimizedCost;
    }

    [Puzzle("f7bff835c155360310f09f273cac0299")]
    public int Part2(string input)
    { 
        var (portalCountInput, lineInput) = input.Split(LineBreaks.Double);
        var portalCount = Numbers.IntsFromString(portalCountInput).First();
        var portals = Enumerable.Range(1, portalCount).Select(o => o.ToString()).ToArray();
        
        var edges = new List<GraphEdge>();
        for (var i = 0; i < portals.Length; i++)
        {
            var prevPortal1 = (i + portals.Length - 1) % portals.Length;
            var prevPortal2 = (i + portals.Length - 2) % portals.Length;
            var prevPortal3 = (i + portals.Length - 3) % portals.Length;
            var nextPortal1 = (i + 1) % portals.Length;
            var nextPortal2 = (i + 2) % portals.Length;
            var nextPortal3 = (i + 3) % portals.Length;

            edges.Add(new GraphEdge(portals[i], portals[prevPortal1]));
            edges.Add(new GraphEdge(portals[i], portals[prevPortal2]));
            edges.Add(new GraphEdge(portals[i], portals[prevPortal3]));
            edges.Add(new GraphEdge(portals[i], portals[nextPortal1]));
            edges.Add(new GraphEdge(portals[i], portals[nextPortal2]));
            edges.Add(new GraphEdge(portals[i], portals[nextPortal3]));
        }

        var initialCost = 0;
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;
                initialCost += Dijkstra.BestCost(edges, portal, otherPortal);
            }
        }

        foreach (var line in lineInput.Split(LineBreaks.Single))
        {
            var (p1, p2) = Numbers.IntsFromString(line);
            edges.Add(new GraphEdge(p1.ToString(), p2.ToString()));
            edges.Add(new GraphEdge(p2.ToString(), p1.ToString()));
        }

        var existingConnections = edges.Select(o => (o.From, o.To)).ToHashSet();
        var possibleConnections = new HashSet<(string, string)>();
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;

                if (!existingConnections.Contains((portal, otherPortal)) && !possibleConnections.Contains((otherPortal, otherPortal)))
                    possibleConnections.Add((portal, otherPortal));
            }
        }

        var best = int.MaxValue;
        foreach (var possibleConnection in possibleConnections)
        {
            var optimizedCost = 0;
            var newEdges = edges.ToList();
            newEdges.Add(new GraphEdge(possibleConnection.Item1, possibleConnection.Item2));
            newEdges.Add(new GraphEdge(possibleConnection.Item2, possibleConnection.Item1));
            foreach (var portal in portals)
            {
                foreach (var otherPortal in portals)
                {
                    if (otherPortal == portal)
                        continue;
                    var c = Dijkstra.BestCost(newEdges, portal, otherPortal);
                    optimizedCost += c;
                }
            }

            best = Math.Min(best, optimizedCost);
        }
        
        return initialCost - best;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
}