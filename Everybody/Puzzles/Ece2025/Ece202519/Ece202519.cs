using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202519;

[Name("Flappy Quack")]
public class Ece202519 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var numberLists = input.Split(LineBreaks.Single).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToList();
        var maxHeight = numberLists.Max(o => o[1] + o[2]);
        var gridHeight = maxHeight + 1;

        var grid = new Grid<char>(1, gridHeight, '.');
        grid.MoveTo(0, 0);

        foreach (var numberlist in numberLists)
        {
            var x = numberlist[0];

            grid.MoveTo(x, 0);
            grid.WriteValue('#');
            while (grid.Coord.Y < grid.YMax)
            {
                grid.MoveDown();
                grid.WriteValue('#');
            }
        }
        
        foreach (var numberlist in numberLists)
        {
            var x = numberlist[0];
            var passageStart = numberlist[1];
            var passageHeight = numberlist[2] - 1;

            grid.MoveTo(x, passageStart);
            grid.WriteValue('.');
            
            for (var _ = 0; _ < passageHeight; _++)
            {
                grid.MoveDown();
                grid.WriteValue('.');
            }
        }

        var targets = grid.Coords.Where(o => o.X == grid.XMax && grid.ReadValueAt(o) == '.');
        
        var edges = new List<GraphEdge>();
        foreach (var coord in grid.Coords)
        {
            var val = grid.ReadValueAt(coord);
            if (val == '#')
                continue;

            var up = new Coord(coord.X + 1, coord.Y + 1);
            var down = new Coord(coord.X + 1, coord.Y - 1);

            if (!grid.IsOutOfRange(up) && grid.ReadValueAt(up) == '.')
            {
                edges.Add(new GraphEdge(coord.Id, up.Id, 1));
            }
            
            if (!grid.IsOutOfRange(down) && grid.ReadValueAt(down) == '.')
            {
                edges.Add(new GraphEdge(coord.Id, down.Id, 0));
            }
        }
        
        var cost = Dijkstra.BestCost(edges, new Coord(0, 0).Id, targets.Select(o => o.Id).ToList());

        //var flippedGrid = grid.FlipVertical();
        //Console.WriteLine(flippedGrid.Print());
        
        return new PuzzleResult(cost, "0e9f546a10105800c2c014d1d8205cc2");
    }

    public PuzzleResult Part2(string input)
    {
        var numberLists = input.Split(LineBreaks.Single).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToList();
        var maxHeight = numberLists.Max(o => o[1] + o[2]);
        var gridHeight = maxHeight + 1;

        var grid = new Grid<char>(1, gridHeight, '.');
        grid.MoveTo(0, 0);

        foreach (var numberlist in numberLists)
        {
            var x = numberlist[0];

            grid.MoveTo(x, 0);
            grid.WriteValue('#');
            while (grid.Coord.Y < grid.YMax)
            {
                grid.MoveDown();
                grid.WriteValue('#');
            }
        }
        
        foreach (var numberlist in numberLists)
        {
            var x = numberlist[0];
            var passageStart = numberlist[1];
            var passageHeight = numberlist[2] - 1;

            grid.MoveTo(x, passageStart);
            grid.WriteValue('.');
            
            for (var _ = 0; _ < passageHeight; _++)
            {
                grid.MoveDown();
                grid.WriteValue('.');
            }
        }

        var targets = grid.Coords.Where(o => o.X == grid.XMax && grid.ReadValueAt(o) == '.');
        
        var edges = new List<GraphEdge>();
        foreach (var coord in grid.Coords)
        {
            var val = grid.ReadValueAt(coord);
            if (val == '#')
                continue;
        
            var up = new Coord(coord.X + 1, coord.Y + 1);
            var down = new Coord(coord.X + 1, coord.Y - 1);
        
            if (!grid.IsOutOfRange(up) && grid.ReadValueAt(up) == '.')
            {
                edges.Add(new GraphEdge(coord.Id, up.Id, 1));
            }
            
            if (!grid.IsOutOfRange(down) && grid.ReadValueAt(down) == '.')
            {
                edges.Add(new GraphEdge(coord.Id, down.Id, 0));
            }
        }
        
        var cost = Dijkstra.BestCost(edges, new Coord(0, 0).Id, targets.Select(o => o.Id).ToList());

        // var flippedGrid = grid.FlipVertical();
        // Console.WriteLine(flippedGrid.Print());
        
        return new PuzzleResult(cost, "42fd601e0fc19354f8ef71fe2e4d3564");
    }

    public PuzzleResult Part3(string input)
    {
        var numberLists = input.Split(LineBreaks.Single).Select(o => o.Split(',').Select(int.Parse).ToArray()).ToList();
        var maxHeight = numberLists.Max(o => o[1] + o[2]);
        var gridHeight = maxHeight + 1;

        var grid = new Grid<char>(1, gridHeight, '.');
        grid.MoveTo(0, 0);

        foreach (var numberlist in numberLists)
        {
            var x = numberlist[0];

            grid.MoveTo(x, 0);
            grid.WriteValue('#');
            while (grid.Coord.Y < grid.YMax)
            {
                grid.MoveDown();
                grid.WriteValue('#');
            }
        }
        
        foreach (var numberlist in numberLists)
        {
            var x = numberlist[0];
            var passageStart = numberlist[1];
            var passageHeight = numberlist[2] - 1;

            grid.MoveTo(x, passageStart);
            grid.WriteValue('.');
            
            for (var _ = 0; _ < passageHeight; _++)
            {
                grid.MoveDown();
                grid.WriteValue('.');
            }
        }

        var targets = grid.Coords.Where(o => o.X == grid.XMax && grid.ReadValueAt(o) == '.');
        
        var edges = new List<GraphEdge>();
        foreach (var coord in grid.Coords)
        {
            var val = grid.ReadValueAt(coord);
            if (val == '#')
                continue;
        
            var up = new Coord(coord.X + 1, coord.Y + 1);
            var down = new Coord(coord.X + 1, coord.Y - 1);
        
            if (!grid.IsOutOfRange(up) && grid.ReadValueAt(up) == '.')
            {
                edges.Add(new GraphEdge(coord.Id, up.Id, 1));
            }
            
            if (!grid.IsOutOfRange(down) && grid.ReadValueAt(down) == '.')
            {
                edges.Add(new GraphEdge(coord.Id, down.Id, 0));
            }
        }
        
        var cost = Dijkstra.BestCost(edges, new Coord(0, 0).Id, targets.Select(o => o.Id).ToList());

        // var flippedGrid = grid.FlipVertical();
        // Console.WriteLine(flippedGrid.Print());
        
        return new PuzzleResult(cost);
    }
}