using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202520;

[Name("Dream in Triangles")]
public class Ece202520 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var count = 0;

        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v != 'T')
                continue;

            var left = new Coord(coord.X - 1, coord.Y);
            if (!grid.IsOutOfRange(left) && grid.ReadValueAt(left) == 'T') 
                count++;

            var below = new Coord(coord.X, coord.Y + 1);
            if (!grid.IsOutOfRange(below) && grid.ReadValueAt(below) == 'T')
            {
                if (coord.X % 2 != 0 && coord.Y % 2 == 0) count++;
                if (coord.X % 2 == 0 && coord.Y % 2 != 0) count++;
            }
        }
        
        return new PuzzleResult(count, "d8ee6b0475f3971b598eab03bf31bed4");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var edges = new HashSet<GraphEdge>();
        var start = grid.FindAddresses('S').First();
        var end = grid.FindAddresses('E').First();
        grid.WriteValueAt(start, 'T');
        grid.WriteValueAt(end, 'T');

        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v != 'T')
                continue;

            var left = new Coord(coord.X - 1, coord.Y);
            if (!grid.IsOutOfRange(left) && grid.ReadValueAt(left) == 'T')
            {
                edges.Add(new GraphEdge(coord.Id, left.Id));
                edges.Add(new GraphEdge(left.Id, coord.Id));
            }

            var below = new Coord(coord.X, coord.Y + 1);
            if (!grid.IsOutOfRange(below) && grid.ReadValueAt(below) == 'T')
            {
                if (coord.X % 2 != 0 && coord.Y % 2 == 0 || coord.X % 2 == 0 && coord.Y % 2 != 0)
                {
                    edges.Add(new GraphEdge(coord.Id, below.Id));
                    edges.Add(new GraphEdge(below.Id, coord.Id));
                }
            }
        }

        var cost = Dijkstra.BestCost(edges.ToList(), start.Id, end.Id);
        
        return new PuzzleResult(cost);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}