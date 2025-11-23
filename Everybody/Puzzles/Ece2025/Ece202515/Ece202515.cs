using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202515;

[Name("Definitely Not a Maze")]
public class Ece202515 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var instructions = input.Split(',');
        var grid = new Grid<char>(1, 1, '.');
        grid.WriteValue('S');
        grid.TurnTo(GridDirection.Up);
        
        foreach (var instruction in instructions)
        {
            var direction = instruction.First();
            var distance = int.Parse(instruction[1..]);
            if (direction == 'L')
                grid.TurnLeft();
            else
                grid.TurnRight();
            for (var _ = 0; _ < distance; _++)
            {
                grid.MoveForward();
                grid.WriteValue('#');
            }
        }
        
        var startPoint = grid.Coords.First(o => grid.ReadValueAt(o) == 'S');
        var endPoint = grid.Coord;
        grid.WriteValueAt(startPoint, '.');
        grid.WriteValueAt(endPoint, '.');
        
        var edges = new List<GraphEdge>();
        foreach (var coord in grid.Coords)
        {
            if (grid.ReadValueAt(coord) == '#')
                continue;
            
            var adj = grid.OrthogonalAdjacentCoordsTo(coord).Where(o => grid.ReadValueAt(o) != '#');
            foreach (var ac in adj)
            {
                edges.Add(new GraphEdge(ac.Id, coord.Id));
                edges.Add(new GraphEdge(coord.Id, ac.Id));
            }
        }
        var cost = Dijkstra.BestCost(edges, startPoint.Id, endPoint.Id);
        
        return new PuzzleResult(cost, "4a1a3b7a0e4af4aaf4c4f9e0b95430d4");
    }

    // public PuzzleResult Part2(string input)
    // {
    //     var instructions = input.Split(',');
    //     var grid = new Grid<char>(1, 1, '.');
    //     grid.WriteValue('S');
    //     grid.TurnTo(GridDirection.Up);
    //     grid.ExtendDown();
    //     
    //     foreach (var instruction in instructions)
    //     {
    //         var direction = instruction.First();
    //         var distance = int.Parse(instruction[1..]);
    //         if (direction == 'L')
    //             grid.TurnLeft();
    //         else
    //             grid.TurnRight();
    //         for (var _ = 0; _ < distance; _++)
    //         {
    //             grid.MoveForward();
    //             grid.WriteValue('#');
    //         }
    //     }
    //
    //     var startPoint = grid.Coords.First(o => grid.ReadValueAt(o) == 'S');
    //     grid.WriteValueAt(startPoint, '.');
    //     var endPoint = grid.Coord;
    //
    //     var path = PathFinder.ShortestPathTo(grid, startPoint, endPoint);
    //     
    //     return new PuzzleResult(path.Count(), "c9e63859efb2156d5906e433e50285d0");
    // }
    
    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(Part2And3(input), "c9e63859efb2156d5906e433e50285d0");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(Part2And3(input));
    }
    
    public int Part2And3(string input)
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
        
        var refStartPoint = grid.Coords.First(o => grid.ReadValueAt(o) == 'S');
        var refEndPoint = grid.Coord;
        grid = grid.Slice(new Coord(grid.XMin, grid.YMin), new Coord(grid.XMax, grid.YMax));
        var startPoint = grid.Coords.First(o => grid.ReadValueAt(o) == 'S');
        var offsetX = startPoint.X - refStartPoint.X;
        var offsetY = startPoint.Y - refStartPoint.Y;
        var endPoint = new Coord(refEndPoint.X + offsetX, refEndPoint.Y + offsetY);
        corners = corners.Select(o => new Coord(o.X + offsetX, o.Y + offsetY)).ToList();
        
        grid.WriteValueAt(startPoint, '.');
        grid.WriteValueAt(endPoint, '.');

        var xmap = new Dictionary<int, int>();
        var xCosts = new Dictionary<(int, int), int>();
        var xValues = corners.Select(o => o.X).Distinct().Order().ToArray();
        var nx = 0;
        foreach (var x in xValues)
        {
            if (!xmap.TryAdd(x, nx))
                continue;
            nx += 3;
        }

        foreach (var (x1, x2) in xValues.Zip(xValues.Skip(1)))
        {
            var a = x1 + 1;
            var b = x2 - 1;
            var diff = b - a;
            xCosts.TryAdd((a, a + 1), diff);
            xCosts.TryAdd((b, b - 1), diff);
        }
        
        var ymap = new Dictionary<int, int>();
        var yCosts = new Dictionary<(int, int), int>();
        var yValues = corners.Select(o => o.Y).Distinct().Order().ToArray();
        var ny = 0;
        foreach (var y in yValues)
        {
            if (!ymap.TryAdd(y, ny))
                continue;
            ny += 3;
        }
        
        foreach (var (y1, y2) in yValues.Zip(yValues.Skip(1)))
        {
            var a = y1 + 1;
            var b = y2 - 1;
            var diff = b - a;
            yCosts.TryAdd((a, a + 1), diff);
            yCosts.TryAdd((b, b - 1), diff);
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

        startPoint = corners.First();
        endPoint = corners.Last();
        
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
                var cost = 0;
                if (xCosts.ContainsKey((coord.X, ac.X)))
                    cost += xCosts[(coord.X, ac.X)];
                if (yCosts.ContainsKey((coord.Y, ac.Y)))
                    cost += yCosts[(coord.Y, ac.Y)];
                if (cost == 0)
                    cost = 1;

                edges.Add(new GraphEdge(ac.Id, coord.Id, cost));
                edges.Add(new GraphEdge(coord.Id, ac.Id, cost));
            }
        }
        
        return Dijkstra.BestCost(edges, startPoint.Id, endPoint.Id);
    }
}