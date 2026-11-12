using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Graphs;
using Pzl.Tools.HashSets;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Portalignment")]
[IsSlow]
[Comment("20s for part 3. My bfs is too slow")]
public class Ece202611 : EverybodyEventPuzzle
{
    [Puzzle("d3ecb33fe754cdce3362d8d1cf61380e")]
    public int Part1(string input)
    {
        var (portalCountInput, lineInput) = input.Split(LineBreaks.Double);
        var portalCount = Numbers.IntsFromString(portalCountInput).First();
        var portals = Enumerable.Range(1, portalCount).Select(o => o.ToString()).ToArray();
        var neighbors = GetInitialNeighbors(portals, 1);
        var initialCost = GetBestCost(portals, neighbors);
        AddExtraNeighbors(neighbors, lineInput);
        
        var optimizedCost = 0;
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;
                optimizedCost += Bfs.BestCost(neighbors, portal, otherPortal);
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
        var neighbors = GetInitialNeighbors(portals, 3);
        var initialCost = GetBestCost(portals, neighbors);
        AddExtraNeighbors(neighbors, lineInput);
        
        var possibleConnections = new HashSet<(string, string)>();
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;
                
                possibleConnections.Add((portal, otherPortal));
            }
        }

        var best = int.MaxValue;
        foreach (var possibleConnection in possibleConnections)
        {
            var optimizedCost = 0;
            var newNeighbors = neighbors.ToDictionary(o => o.Key, o => o.Value.ToHashSet());
            newNeighbors[possibleConnection.Item1].Add(possibleConnection.Item2);
            newNeighbors[possibleConnection.Item2].Add(possibleConnection.Item1);
            foreach (var portal in portals)
            {
                foreach (var otherPortal in portals)
                {
                    if (otherPortal == portal)
                        continue;
                    var c = Bfs.BestCost(newNeighbors, portal, otherPortal);
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
        var neighbors = GetInitialNeighbors(portals, 3);
        var initialCost = GetBestCost(portals, neighbors);
        AddExtraNeighbors(neighbors, lineInput);

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
                var newNeighbors = neighbors.ToDictionary(o => o.Key, o => o.Value.ToHashSet());
                
                foreach (var pair in crystalPosition)
                {
                    newNeighbors[pair[0]].Add(pair[1]);
                    newNeighbors[pair[1]].Add(pair[0]);
                }
                
                var optimizedCost = GetBestCost(portals, newNeighbors);
                best = Math.Min(best, optimizedCost);
            }
        }
        
        return initialCost - best;
    }
    
    private static int GetBestCost(string[] portals, Dictionary<string, HashSet<string>> neighbors)
    {
        var initialCost = 0;
        foreach (var portal in portals)
        {
            foreach (var otherPortal in portals)
            {
                if (otherPortal == portal)
                    continue;
                initialCost += Bfs.BestCost(neighbors, portal, otherPortal);
            }
        }

        return initialCost;
    }
    
    private static Dictionary<string, HashSet<string>> GetInitialNeighbors(string[] portals, int maxDistance)
    {
        var neighbors = new Dictionary<string, HashSet<string>>();
        for (var i = 0; i < portals.Length; i++)
        {
            neighbors[portals[i]] = [];
            for (var steps = 1; steps <= maxDistance; steps++)
            {
                var prevPortal = (i + portals.Length - steps) % portals.Length;
                var nextPortal = (i + steps) % portals.Length;

                neighbors[portals[i]].AddRange([
                    portals[prevPortal],
                    portals[nextPortal]
                ]);
            }
        }

        return neighbors;
    }
    
    private static void AddExtraNeighbors(Dictionary<string, HashSet<string>> neighbors, string input)
    {
        foreach (var line in input.Split(LineBreaks.Single))
        {
            var (p1, p2) = Numbers.IntsFromString(line);
            neighbors[p1.ToString()].Add(p2.ToString());
            neighbors[p2.ToString()].Add(p1.ToString());
        }
    }
}