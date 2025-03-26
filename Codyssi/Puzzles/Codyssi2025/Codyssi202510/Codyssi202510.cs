using FluentAssertions;
using Pzl.Common;
using Pzl.Tools.CoordinateSystems.CoordinateSystem2D;
using Pzl.Tools.Graphs;
using Pzl.Tools.Queues;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202510;

[Name("")]
public class Codyssi202510 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var data = input.Split(LineBreaks.Single)
            .Select(o => o.Replace(" ", "").ToCharArray().Select(p => int.Parse(p.ToString())).ToArray())
            .ToArray();

        var hmin = int.MaxValue;
        var vmin = int.MaxValue;

        for (var i = 0; i < data.Length; i++)
        {
            var hsum = 0;
            var vsum = 0;
            for (var j = 0; j < data[i].Length; j++)
            {
                hsum += data[i][j];
                vsum += data[j][i];
            }

            hmin = Math.Min(hsum, hmin);
            vmin = Math.Min(vsum, vmin);
        }

        var min = Math.Min(hmin, vmin);
        
        return new PuzzleResult(min, "1e10a803d525ec160795a9bed9161106");
    }

    public PuzzleResult Part2(string input)
    {
        var cost = RunPart2And3(input, new MatrixAddress(14, 14));
        
        return new PuzzleResult(cost, "8e0e2fd983585eea7c17bb92929d6c32");
    }

    public PuzzleResult Part3(string input)
    {
        var cost = RunPart2And3(input);
        
        return new PuzzleResult(cost, "ef05794a9a4d22520dd94a67775c2c15");
    }
    
    public int RunPart2And3(string input, MatrixAddress? target = null)
    {
        var grid = MatrixBuilder.BuildIntMatrixFromNonSeparated(input.Replace(" ", ""));
        var edges = new List<GraphEdge>();
        var queue = new Queue<MatrixAddress>();
        var start = new MatrixAddress(0, 0);
        var end = target ?? new MatrixAddress(grid.XMax, grid.YMax);
        var startCost = grid.ReadValueAt(start);
        queue.Enqueue(start);
        var seen = new HashSet<string>();
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var next = grid.OrthogonalAdjacentCoordsTo(current).Where(o => o.X > current.X || o.Y > current.Y);
            foreach (var n in next)
            {
                edges.Add(new GraphEdge(current.Id, n.Id, grid.ReadValueAt(n)));
                if (!seen.Add(n.Id))
                    continue;

                queue.Enqueue(n);
            }
        }

        return Dijkstra.BestCost(edges, start.Id, end.Id) + startCost;
    }
}