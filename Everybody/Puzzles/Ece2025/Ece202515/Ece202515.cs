using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202515;

[Name("Definitely Not a Maze")]
public class Ece202515 : EverybodyEventPuzzle
{
    private const int MaxDistance = 3;
    
    public PuzzleResult Part1(string input) => new(Solve(input), "4a1a3b7a0e4af4aaf4c4f9e0b95430d4");
    public PuzzleResult Part2(string input) => new(Solve(input), "c9e63859efb2156d5906e433e50285d0");
    public PuzzleResult Part3(string input) => new(Solve(input), "f5a3b1e436cc12fdbacea6f28f381b67");

    public static int Solve(string input)
    {
        var instructions = input.Split(',');
        var grid = new Grid<char>(1, 1, '.');
        grid.WriteValue('S');
        grid.TurnTo(GridDirection.Up);
        List<Coord> corners = [grid.Coord];
        
        foreach (var instruction in instructions)
        {
            var direction = instruction.First();
            var distance = int.Parse(instruction[1..]);
            if (direction == 'L')
                grid.TurnLeft();
            else
                grid.TurnRight();
            grid.MoveForward(distance);
            grid.WriteValue('#');
            
            corners.Add(grid.Coord);
        }
        
        var offsetX = -grid.XMin;
        var offsetY = -grid.YMin;
        corners = corners.Select(o => new Coord(o.X + offsetX, o.Y + offsetY)).ToList();

        var xmap = new Dictionary<int, int>();
        var xCosts = new Dictionary<(int, int), int>();
        var xValues = corners.Select(o => o.X).Distinct().Order().ToArray();
        var currentx = xValues.First();
        xmap.Add(currentx, currentx);
        foreach (var (x1, x2) in xValues.Zip(xValues.Skip(1)))
        {
            if(xmap.ContainsKey(x2))
                continue;
            
            var distance = x2 - x1;
            var needsShortening = distance > MaxDistance;
            if (needsShortening)
            {
                var cost = distance - MaxDistance + 1;
                xCosts.TryAdd((currentx + 1, currentx + 2), cost);
                xCosts.TryAdd((currentx + 2, currentx + 1), cost);
                currentx += MaxDistance;
            }
            else
            {
                currentx += distance;
            }
            
            xmap.TryAdd(x2, currentx);
        }

        var ymap = new Dictionary<int, int>();
        var yCosts = new Dictionary<(int, int), int>();
        var yValues = corners.Select(o => o.Y).Distinct().Order().ToArray();
        var currenty = yValues.First();
        ymap.Add(currenty, currenty);
        foreach (var (y1, y2) in yValues.Zip(yValues.Skip(1)))
        {
            if (ymap.ContainsKey(y2))
                continue;
            
            var distance = y2 - y1;
            var needsShortening = distance > MaxDistance;
            if (needsShortening)
            {
                var cost = distance - MaxDistance + 1;
                yCosts.TryAdd((currenty + 1, currenty + 2), cost);
                yCosts.TryAdd((currenty + 2, currenty + 1), cost);
                currenty += MaxDistance;
            }
            else
            {
                currenty += distance;
            }
               
            ymap.TryAdd(y2, currenty);
        }

        for (var i = 0; i < corners.Count; i++)
        {
            corners[i] = new Coord(xmap[corners[i].X], ymap[corners[i].Y]);
        }

        var smallGrid = new Grid<char>(corners.Max(o => o.X) + 1, corners.Max(o => o.Y) + 1, '.');

        smallGrid.MoveTo(corners.First());
        foreach (var corner in corners.Skip(1))
        {
            var cx = smallGrid.Coord.X;
            var cy = smallGrid.Coord.Y;
            var sx = Math.Min(cx, corner.X);
            var sy = Math.Min(cy, corner.Y);
            var tx = Math.Max(cx, corner.X);
            var ty = Math.Max(cy, corner.Y);
            for (var y = sy; y <= ty; y++)
            {
                for (var x = sx; x <= tx; x++)
                {
                    smallGrid.MoveTo(x, y);
                    smallGrid.WriteValue('#');
                }
            }

            smallGrid.MoveTo(corner);
        }

        var startPoint = corners.First();
        var endPoint = corners.Last();
        
        smallGrid.WriteValueAt(startPoint, '.');
        smallGrid.WriteValueAt(endPoint, '.');
        
        var edges = new List<GraphEdge>();
        foreach (var coord in smallGrid.Coords)
        {
            if (smallGrid.ReadValueAt(coord) == '#')
                continue;
            
            var adj = smallGrid.OrthogonalAdjacentCoordsTo(coord).Where(o => smallGrid.ReadValueAt(o) != '#');
            foreach (var ac in adj)
            {
                var cost = 1;
                if (xCosts.ContainsKey((coord.X, ac.X)))
                    cost += xCosts[(coord.X, ac.X)] - 1;
                if (yCosts.ContainsKey((coord.Y, ac.Y)))
                    cost += yCosts[(coord.Y, ac.Y)] - 1;
                
                edges.Add(new GraphEdge(coord.Id, ac.Id, cost));
            }
        }
        
        return Dijkstra.BestCost(edges, startPoint.Id, endPoint.Id);
    }
}