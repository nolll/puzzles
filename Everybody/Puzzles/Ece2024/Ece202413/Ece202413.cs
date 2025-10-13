using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202413;

[Name("Never Gonna Let You Down")]
public class Ece202413 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = Solve(input);
        return new PuzzleResult(result, "cc8e51053c4445ee974c4672602452ae");
    }

    public PuzzleResult Part2(string input)
    {
        var result = Solve(input);
        return new PuzzleResult(result, "a66cce437d7531d58ae98d0084ae5e9d");
    }

    public PuzzleResult Part3(string input)
    {
        var result = Solve(input);
        return new PuzzleResult(result, "3bebcd17eed852e6918bf8d5eae753cb");
    }
    
    private int Solve(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(start, '0');
        var targets = matrix.FindAddresses('S');
        foreach (var target in targets)
        {
            matrix.WriteValueAt(target, '0');
        }
        var edges = new List<GraphEdge>();
        foreach (var current in matrix.Coords)
        {
            var cv = matrix.ReadValueAt(current);
            if (cv is '#' or ' ')
                continue;
            
            var currentLevel = int.Parse(matrix.ReadValueAt(current).ToString());
            var nbrs = matrix.OrthogonalAdjacentCoordsTo(current);
            foreach (var nbr in nbrs)
            {
                var nv = matrix.ReadValueAt(nbr);
                if (nv == '#')
                    continue;

                var nbrLevel = int.Parse(nv.ToString());
                var cost = GetCost(currentLevel, nbrLevel);
                edges.Add(new GraphEdge(current.Id, nbr.Id, cost + 1));
            }
        }
        
        return Dijkstra.BestCost(edges, start.Id, targets.Select(o => o.Id).ToList());
    }

    public static int GetCost(int a, int b)
    {
        var diff = Math.Max(a, b) - Math.Min(a, b);
        if (diff > 5)
            diff = 10 - diff;

        return diff;
    }
}