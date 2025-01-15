using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody15;

[IsSlow]
[Comment("Needs shortcuts")]
[Name("From the Herbalist's Diary")]
public class Everybody15 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = new MatrixAddress(input.Split(LineBreaks.Single).First().IndexOf('.'), 0);
        var targets = matrix.FindAddresses('H');
        var inputs = GetEdges(matrix).ToList();

        var cost = Dijkstra.BestCost(inputs, start.Id, targets.Select(o => o.Id).ToList()) * 2;
        
        return new PuzzleResult(cost, "4d832f8cc35ae0da374a91187caa538b");
    }

    public PuzzleResult Part2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = new MatrixAddress(input.Split(LineBreaks.Single).First().IndexOf('.'), 0);
        var herbCoords = GetHerbCoords(matrix);
        herbCoords.Add('S', [start.Id]);
        var allHerbCoords = herbCoords.Values.SelectMany(o => o).ToList();
        var herbTypes = herbCoords.Keys.ToList();
        var herbCombinations = PermutationGenerator.GetPermutations(herbTypes).Select(o => (List<char>)[..o, 'S']);
        var inputs = GetEdges(matrix).ToList();
        var nodes = Graph.GetNodes(inputs);

        var costs = new Dictionary<(string, string), int>();
        foreach (var a in allHerbCoords)
        {
            foreach (var b in allHerbCoords)
            {
                if(costs.ContainsKey((a, b)))
                    continue;
                
                if (a == b)
                {
                    costs.Add((a, b), 0);
                    continue;
                }

                var cost = Dijkstra.BestCost(nodes, a, b);
                costs.TryAdd((a, b), cost);
                costs.TryAdd((b, a), cost);
            }
        }

        var bestCost = long.MaxValue;
        foreach (var combination in herbCombinations)
        {
            var totalCosts = GetTotalCosts(0, start.Id, herbCoords, combination, costs);
            var bestTotalCost = totalCosts.Min();
            if (bestTotalCost < bestCost)
            {
                bestCost = bestTotalCost;
            }
        }
        
        return new PuzzleResult(bestCost, "88139015cfdd3b0563287eff1d2229c1");
    }
    
    public PuzzleResult Part3(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = new MatrixAddress(input.Split(LineBreaks.Single).First().IndexOf('.'), 0);
        var herbCoords = GetHerbCoords(matrix);
        herbCoords.Add('S', [start.Id]);
        var allHerbCoords = herbCoords.Values.SelectMany(o => o).ToList();
        var herbTypes = herbCoords.Keys.ToList();
        List<List<char>> herbCombinations = [['G', 'H', 'I', 'J', 'K', 'E', 'D', 'C', 'B', 'A', 'R', 'Q', 'P', 'O', 'N', 'S']];
        var inputs = GetEdges(matrix).ToList();
        var nodes = Graph.GetNodes(inputs);

        var costs = new Dictionary<(string, string), int>();
        foreach (var (ida, idb) in herbTypes.Zip(herbTypes.Skip(1)))
        {
            var lista = herbCoords[ida];
            var listb = herbCoords[idb];
            
            foreach (var a in lista)
            {
                foreach (var b in listb)
                {
                    if(costs.ContainsKey((a, b)))
                        continue;
                
                    if (a == b)
                    {
                        costs.Add((a, b), 0);
                        continue;
                    }

                    var cost = Dijkstra.BestCost(nodes, a, b);
                    costs.TryAdd((a, b), cost);
                    costs.TryAdd((b, a), cost);
                }
            }
        }

        var bestCost = long.MaxValue;
        foreach (var combination in herbCombinations)
        {
            var totalCosts = GetTotalCosts(0, start.Id, herbCoords, combination, costs);
            var bestTotalCost = totalCosts.Min();
            if (bestTotalCost < bestCost)
            {
                bestCost = bestTotalCost;
            }
        }
        
        return new PuzzleResult(bestCost);
    }

    private List<long> GetTotalCosts(
        int cost,
        string currentId,
        Dictionary<char, List<string>> herbCoords,
        List<char> remainingHerbs,
        Dictionary<(string, string), int> segmentCosts)
    {
        if (remainingHerbs.Count == 0)
        {
            //Console.WriteLine($"{currentId}: {cost}");
            return [cost];
        }

        var nextHerb = remainingHerbs.First();
        var ids = herbCoords[nextHerb];
        var costs = new List<long>();
        foreach (var id in ids)
        {
            var nextCost = segmentCosts[(currentId, id)];
            costs.Add(GetTotalCosts(cost + nextCost, id, herbCoords, remainingHerbs.Skip(1).ToList(), segmentCosts).Min());
        }
        return costs;
    }
    
    private static Dictionary<char, List<string>> GetHerbCoords(Matrix<char> matrix)
    {
        var coords = new Dictionary<char, List<string>>();
        foreach (var coord in matrix.Coords)
        {
            var v = matrix.ReadValueAt(coord);
            if (v is '#' or '.' or '~')
                continue;

            if (!coords.ContainsKey(v))
                coords[v] = [];
            
            coords[v].Add(coord.Id);
        }

        return coords;
    }

    private static IEnumerable<GraphEdge> GetEdges(Matrix<char> matrix)
    {
        foreach (var coord in matrix.Coords)
        {
            var v = matrix.ReadValueAt(coord);
            if (v is '#' or '~')
                continue;

            foreach (var nbr in matrix.OrthogonalAdjacentCoordsTo(coord))
            {
                var nv = matrix.ReadValueAt(nbr);
                if (nv is '#' or '~')
                    continue;
                
                yield return new GraphEdge(coord.Id, nbr.Id);
                yield return new GraphEdge(nbr.Id, coord.Id);
            }
        }
    }
}