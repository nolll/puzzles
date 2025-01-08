using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Everybody15;

[IsSlow]
[Comment("Generates graph over and over again")]
[Name("From the Herbalist's Diary")]
public class Everybody15 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = new MatrixAddress(input.Split(LineBreaks.Single).First().IndexOf('.'), 0);
        var targets = matrix.FindAddresses('H');
        var inputs = GetInputs(matrix).ToList();

        var cost = Graph.GetLowestCost(inputs, start.Id, targets.Select(o => o.Id).ToList()) * 2;
        
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
        var inputs = GetInputs(matrix).ToList();

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

                var cost = Graph.GetLowestCost(inputs, a, b);
                costs.TryAdd((a, b), cost);
                costs.TryAdd((b, a), cost);
            }
        }

        var bestCost = int.MaxValue;
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

    private List<int> GetTotalCosts(
        int cost,
        string currentId,
        Dictionary<char, List<string>> herbCoords,
        List<char> remainingHerbs,
        Dictionary<(string, string), int> segmentCosts)
    {
        if (remainingHerbs.Count == 0)
            return [cost];
        
        var nextHerb = remainingHerbs.First();
        var ids = herbCoords[nextHerb];
        var costs = new List<int>();
        foreach (var id in ids)
        {
            var nextCost = segmentCosts[(currentId, id)];
            costs.AddRange(GetTotalCosts(cost + nextCost, id, herbCoords, remainingHerbs.Skip(1).ToList(), segmentCosts));
        }
        return costs;
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
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

    private static IEnumerable<Graph.Input> GetInputs(Matrix<char> matrix)
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
                
                yield return new Graph.Input(coord.Id, nbr.Id);
                yield return new Graph.Input(nbr.Id, coord.Id);
            }
        }
    }
}