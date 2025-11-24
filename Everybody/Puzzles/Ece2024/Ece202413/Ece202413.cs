using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202413;

[Name("Never Gonna Let You Down")]
public class Ece202413 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input), "cc8e51053c4445ee974c4672602452ae");
    public PuzzleResult Part2(string input) => new(Solve(input), "a66cce437d7531d58ae98d0084ae5e9d");
    public PuzzleResult Part3(string input) => new(Solve(input), "3bebcd17eed852e6918bf8d5eae753cb");

    private static int Solve(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var start = grid.FindAddresses('E').First();
        grid.WriteValueAt(start, '0');
        var targets = grid.FindAddresses('S');
        foreach (var target in targets)
        {
            grid.WriteValueAt(target, '0');
        }
        var edges = new List<GraphEdge>();
        foreach (var current in grid.Coords)
        {
            var cv = grid.ReadValueAt(current);
            if (cv is '#' or ' ')
                continue;
            
            var currentLevel = int.Parse(grid.ReadValueAt(current).ToString());
            var nbrs = grid.OrthogonalAdjacentCoordsTo(current);
            foreach (var nbr in nbrs)
            {
                var nv = grid.ReadValueAt(nbr);
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