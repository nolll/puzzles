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
        
        var possiblePairs = GetAllPossiblePairs(portals);

        var best = int.MaxValue;
        foreach (var pair in possiblePairs)
        {
            var addedTo1 = neighbors[pair.Item1].Add(pair.Item2);
            var addedTo2 = neighbors[pair.Item2].Add(pair.Item1);
            var optimizedCost = GetBestCost(portals, neighbors);
            best = Math.Min(best, optimizedCost);
            
            if(addedTo1)
                neighbors[pair.Item1].Remove(pair.Item2);
            if(addedTo2)
                neighbors[pair.Item2].Remove(pair.Item1);
        }
        
        return initialCost - best;
    }

    private static HashSet<(string, string)> GetAllPossiblePairs(string[] portals)
    {
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

        return possibleConnections;
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

        var possibleCrystalPositions = GetPossibleCrystalPositions(portals);

        var best = int.MaxValue;
        
        foreach (var crystalPositions in possibleCrystalPositions)
        {
            foreach (var crystalPosition in crystalPositions)
            {
                foreach (var pair in crystalPosition)
                {
                    neighbors[pair[0]].Add(pair[1]);
                    neighbors[pair[1]].Add(pair[0]);
                }
                
                var optimizedCost = GetBestCost(portals, neighbors);
                best = Math.Min(best, optimizedCost);
                
                foreach (var pair in crystalPosition)
                {
                    neighbors[pair[0]].Remove(pair[1]);
                    neighbors[pair[1]].Remove(pair[0]);
                }
            }
        }
        
        return initialCost - best;
    }

    private static List<List<List<List<string>>>> GetPossibleCrystalPositions(string[] portals)
    {
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
            allIndexes.Add(baseIndexes.Select(index => index + i).ToList());
        }
        
        var possibleCrystalPositions = new List<List<List<List<string>>>>();
        foreach (var indexes in allIndexes)
        {
            var crystalPortals = indexes.Select(index => portals[index]).ToList();

            var portalPairs = CombinationGenerator.GetGroupsOfSize(crystalPortals, 2).ToList();
            possibleCrystalPositions.Add(portalPairs);
        }

        return possibleCrystalPositions;
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