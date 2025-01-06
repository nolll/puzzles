using System.Collections;
using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;
using Pzl.Tools.Queues;

namespace Pzl.Everybody.Puzzles.Everybody13;

[Name("Never Gonna Let You Down")]
public class Everybody13 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var start = matrix.FindAddresses('S').First();
        matrix.WriteValueAt(start, '0');
        var target = matrix.FindAddresses('E').First();
        matrix.WriteValueAt(target, '0');
        var inputs = new List<Graph.Input>();
        var q = new Queue<MatrixAddress>();
        var seen = new HashSet<MatrixAddress>();
        q.Enqueue(start);
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            var currentLevel = int.Parse(matrix.ReadValueAt(current).ToString());
            seen.Add(current);
            var nbrs = matrix.OrthogonalAdjacentCoordsTo(current);
            foreach (var nbr in nbrs)
            {
                if (seen.Contains(nbr))
                    continue;

                var v = matrix.ReadValueAt(nbr);
                if (v == '#')
                    continue;

                var nbrLevel = int.Parse(v.ToString());
                var cost = GetCost(currentLevel, nbrLevel);
                inputs.Add(new Graph.Input(current.Id, nbr.Id, cost + 1));
                inputs.Add(new Graph.Input(nbr.Id, current.Id, cost + 1));
                q.Enqueue(nbr);
            }
        }
        
        var lowestCost = Graph.GetLowestCost(inputs, start.Id, target.Id);
        
        return new PuzzleResult(lowestCost, "cc8e51053c4445ee974c4672602452ae");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }

    public int GetCost(int a, int b)
    {
        var large = Math.Max(a, b);
        var small = Math.Min(a, b);
        var diff = large - small;
        if (diff > 5)
            diff = 10 - diff;

        return diff;
    }
}