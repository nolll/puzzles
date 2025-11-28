using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.HashSets;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202519;

[Name("Flappy Quack")]
public class Ece202519 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input), "0e9f546a10105800c2c014d1d8205cc2");
    public PuzzleResult Part2(string input) => new(Solve(input), "42fd601e0fc19354f8ef71fe2e4d3564");
    public PuzzleResult Part3(string input) => new(Solve(input), "ef0c8788bb5ab3f59c9942f9beea54f0");

    private static int Solve(string input)
    {
        var numberLists = input.Split(LineBreaks.Single).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToList();
        var wallsWithHoles = numberLists.Select(o => o[0]).Distinct().ToDictionary(k => k, _ => new List<Coord>());
        
        foreach (var list in numberLists)
        {
            var x = list[0];
            var holeStart = list[1];
            var holeLength = list[2];

            for (var y = 0; y < holeLength; y++)
            {
                wallsWithHoles[x].Add(new Coord(x, holeStart + y));
            }
        }
        
        wallsWithHoles.Add(0, [new Coord(0, 0)]);

        var walls = wallsWithHoles.Keys.Order().ToList();
        
        HashSet<Coord> startPoints = [new(0, 0)];
        var edges = new List<GraphEdge>();
        foreach (var (wa, wb) in walls.Zip(walls.Skip(1)))
        {
            var xdistance = wb - wa;
            var targetHoles = wallsWithHoles[wb];
            var newStartPoints = new HashSet<Coord>();
            
            foreach (var startPoint in startPoints)
            {
                var maxReachY = startPoint.Y + xdistance;
                var minReachY = startPoint.Y - xdistance;
                var targets = targetHoles.Where(o => o.Y >= minReachY && o.Y <= maxReachY && o.Y % 2 == o.X % 2).ToList();

                foreach (var target in targets)
                {
                    edges.Add(new GraphEdge(startPoint.Id, target.Id, CalculateCost(startPoint, target)));
                }
                
                newStartPoints.AddRange(targets);
            }

            startPoints = newStartPoints;
        }

        var lastWallTargets = startPoints;
        
        return Dijkstra.BestCost(edges, new Coord(0, 0).Id, lastWallTargets.Select(o => o.Id).ToList());
    }

    private static int CalculateCost(Coord from, Coord to)
    {
        var dx = to.X - from.X;
        var dy = to.Y - from.Y;
        var diff = dx - dy;
        return dx - diff / 2;
    }
}