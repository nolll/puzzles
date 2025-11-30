using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.HashSets;
using Pzl.Tools.Lists;
using Spectre.Console;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202517;

[Name("Deadline-Driven Development")]
public class Ece202517 : EverybodyEventPuzzle
{
    private const string RightSet = "right";
    private const string LeftSet = "left";

    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var volcano = grid.Coords.First(o => grid.ReadValueAt(o) == '@');

        var sum = CountDestroyed(grid, volcano, 10);
        
        return new PuzzleResult(sum, "058525ed0b94d59517e415b1660aa68a");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var volcano = grid.Coords.First(o => grid.ReadValueAt(o) == '@');
        var best = 0;
        var bestRadius = 0;
        var acc = 0;
        var r = 1;

        while (r * 2 + 1 < grid.Width && r * 2 + 1 < grid.Height)
        {
            var count = CountDestroyed(grid, volcano, r) - acc;
            if (count > best)
            {
                best = count;
                bestRadius = r;
            }

            acc += count;
            r++;
        }
        
        return new PuzzleResult(best * bestRadius, "5d4764c0cfb73f6caa5342ac5cbce4db");
    }

    public PuzzleResult Part3(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var radius = 1;
        var start = grid.FindAddresses('S').First();
        var volcano = grid.FindAddresses('@').First();
        var centerX = grid.Width / 2;
        var centerY = grid.Height / 2;
        grid.WriteValueAt(start, '0');

        var allCoords = grid.Coords.Where(o => !o.Equals(volcano)).ToList();
        var allCenterCoords = grid.Coords.Where(o => o.X == centerX && o.Y > centerY).ToList();
        
        while (true)
        {
            var r = radius;
            var availableSeconds = (r + 1) * 30;

            var rightMinX = centerX - r;
            var leftMaxX = centerX + r;
            var centerCoords = allCenterCoords.Where(o => !IsDestroyed(volcano, o, r)).ToHashSet();
            var currentCoords = allCoords.Where(o => !IsDestroyed(volcano, o, r)).ToHashSet();

            var edges = new List<GraphEdge>();
            
            foreach (var coord in currentCoords)
            {
                var v = grid.ReadValueAt(coord);
                var c = int.Parse(v.ToString());
            
                if (centerCoords.Contains(coord))
                {
                    edges.Add(new GraphEdge(GetId(RightSet, coord), GetId(LeftSet, coord), 0));
                    edges.Add(new GraphEdge(GetId(LeftSet, coord), GetId(RightSet, coord), 0));
                }

                var adj = grid.OrthogonalAdjacentCoordsTo(coord).Where(o => currentCoords.Contains(o));
                foreach (var a in adj)
                {
                    var ac = int.Parse(grid.ReadValueAt(a).ToString());
                    if(a.X <= leftMaxX)
                    {
                        edges.Add(new GraphEdge(GetId(LeftSet, coord), GetId(LeftSet, a), ac));
                        edges.Add(new GraphEdge(GetId(LeftSet, a), GetId(LeftSet, coord), c));
                    }
                    
                    if(a.X >= rightMinX)
                    {
                        edges.Add(new GraphEdge(GetId(RightSet, coord), GetId(RightSet, a), ac));
                        edges.Add(new GraphEdge(GetId(RightSet, a), GetId(RightSet, coord), c));
                    }
                }
            }

            var result = Dijkstra.BestPath(edges, GetId(RightSet, start), GetId(LeftSet, start));
            
            if (result.Cost < availableSeconds)
                return new PuzzleResult(result.Cost * r, "6efa9d887ba005740c281c0027064b53");

            radius++;
        }
    }

    private static string GetId(string set, Coord coord) => $"{set}-{coord.Id}";
    private static bool IsDestroyed(Coord v, Coord c, int r) => (v.X - c.X) * (v.X - c.X) + (v.Y - c.Y) * (v.Y - c.Y) <= r * r;
    
    private static int CountDestroyed(Grid<char> grid, Coord volcano, int r) => 
        grid.Coords.Where(o => o != volcano && IsDestroyed(volcano, o, r)).Select(o => int.Parse(grid.ReadValueAt(o).ToString())).Sum();
}