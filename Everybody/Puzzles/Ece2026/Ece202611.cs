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
            var prevPortal = i - 1;
            if (prevPortal < 0)
                prevPortal = portals.Length - 1;
            
            var nextPortal = i + 1;
            if (nextPortal == portals.Length)
                nextPortal = 0;

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

    [Puzzle("")]
    public int Part2(string input)
    {
        return 0;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
}