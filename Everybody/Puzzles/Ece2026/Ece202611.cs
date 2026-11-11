using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Graphs;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Portalignment")]
[IsSlow]
[NeedsRewrite]
[Comment("15s for part 2, 91s for part 3. Can also use a rewrite")]
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
                initialCost += Bfs.BestCost(edges, portal, otherPortal);
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
                optimizedCost += Bfs.BestCost(edges, portal, otherPortal);
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
                initialCost += Bfs.BestCost(edges, portal, otherPortal);
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
                    var c = Bfs.BestCost(newEdges, portal, otherPortal);
                    optimizedCost += c;
                }
            }

            best = Math.Min(best, optimizedCost);
        }
        
        return initialCost - best;
    }
    
    [Puzzle("65a616a7074699be9b38af930546c7a9")]
    public int Part3(string input)
    {
        var (portalCountInput, lineInput) = input.Split(LineBreaks.Double);
        var portalCount = Numbers.IntsFromString(portalCountInput).First();
        var portals = Enumerable.Range(1, portalCount).Select(o => o.ToString()).ToArray();
        
        var edges = GetInitialEdges(portals);
        var initialCost = GetBestCost(portals, edges);
        edges = [.. edges, .. GetExtraEdges(lineInput)];

        const int rotationCount = 8;
        var baseIndexes = new List<int>();
        var rotationLength = portals.Length / rotationCount;
        for (var startPortal = 0; startPortal < rotationCount; startPortal++)
        {
            baseIndexes.Add(startPortal * rotationLength);
        }

        var allIndexes = new List<List<int>>();
        for (var i = 0; i < rotationLength; i++)
        {
            var list = new List<int>();
            foreach (var index in baseIndexes)
            {
                list.Add(index + i);
            }
            allIndexes.Add(list);
        }
        
        var possibleCrystalPositions = new List<List<List<List<string>>>>();
        foreach (var indexes in allIndexes)
        {
            var crystalPortals = new List<string>();
            foreach (var index in indexes)
            {
                crystalPortals.Add(portals[index]);
            }
            
            var portalPairs = CombinationGenerator.GetGroupsOfSize(crystalPortals, 2).ToList();
            possibleCrystalPositions.Add(portalPairs);
        }

        var best = int.MaxValue;

        foreach (var crystalPositions in possibleCrystalPositions)
        {
            foreach (var crystalPosition in crystalPositions)
            {
                var newEdges = edges.ToList();
                
                foreach (var pair in crystalPosition)
                {
                    newEdges.Add(new GraphEdge(pair[0], pair[1]));
                    newEdges.Add(new GraphEdge(pair[1], pair[0]));
                }
                
                var optimizedCost = GetBestCost(portals, newEdges);
                best = Math.Min(best, optimizedCost);
            }
        }
        
        return initialCost - best;
    }

    private static int GetBestCost(string[] portals, List<GraphEdge> edges)
    {
        var initialCost = 0;
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;
                initialCost += Bfs.BestCost(edges, portal, otherPortal);
            }
        }

        return initialCost;
    }

    private static List<GraphEdge> GetInitialEdges(string[] portals)
    {
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

        return edges;
    }

    private static List<GraphEdge> GetExtraEdges(string input)
    {
        var edges = new List<GraphEdge>();
        foreach (var line in input.Split(LineBreaks.Single))
        {
            var (p1, p2) = Numbers.IntsFromString(line);
            edges.Add(new GraphEdge(p1.ToString(), p2.ToString()));
            edges.Add(new GraphEdge(p2.ToString(), p1.ToString()));
        }

        return edges;
    }
}