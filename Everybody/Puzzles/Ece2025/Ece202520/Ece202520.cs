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
                var colIsOdd = coord.X % 2 != 0;
                var rowIsEven = coord.Y % 2 == 0;
                var rowIsOdd = coord.Y % 2 != 0;
                var colIsEven = coord.X % 2 == 0;
                if (colIsOdd && rowIsEven || colIsEven && rowIsOdd)
                {
                    edges.Add(new GraphEdge(coord.Id, below.Id));
                    edges.Add(new GraphEdge(below.Id, coord.Id));
                }
            }
        }

        var cost = Dijkstra.BestCost(edges.ToList(), start.Id, end.Id);
        
        return new PuzzleResult(cost, "2564cba88ff81fc3fa2632c3749d06e5");
    }

    public PuzzleResult Part3(string input)
    {
        var grid1 = GridBuilder.BuildCharGrid(input);
        var start = grid1.FindAddresses('S').First();
        grid1.WriteValueAt(start, 'T');

        var grid2 = Rotate(grid1);
        var grid3 = Rotate(grid2);
        
        var end1 = grid1.FindAddresses('E').First();
        var end2 = grid2.FindAddresses('E').First();
        var end3 = grid3.FindAddresses('E').First();
        grid1.WriteValueAt(end1, 'T');
        grid2.WriteValueAt(end2, 'T');
        grid3.WriteValueAt(end3, 'T');

        var edges = new HashSet<GraphEdge>();
        Grid<char>[] grids = [grid1, grid2, grid3];

        for (var i = 0; i < grids.Length; i++)
        {
            var nextIndex = (i + 1) % grids.Length;
            var thisGrid = grids[i];
            var nextGrid = grids[nextIndex];
            
            foreach (var coord in thisGrid.Coords)
            {
                var v = thisGrid.ReadValueAt(coord);
                if (v != 'T')
                    continue;
                
                var colIsEven = coord.X % 2 == 0;
                var rowIsEven = coord.Y % 2 == 0;
                var canMoveUp = !colIsEven && !rowIsEven || colIsEven && rowIsEven;
                var canMoveDown = !colIsEven && rowIsEven || colIsEven && !rowIsEven;
                
                if (!nextGrid.IsOutOfRange(coord) && nextGrid.ReadValueAt(coord) == 'T')
                {
                    edges.Add(new GraphEdge(GetId(i, coord), GetId(nextIndex, coord)));
                }

                var left = new Coord(coord.X - 1, coord.Y);
                if (!nextGrid.IsOutOfRange(left) && nextGrid.ReadValueAt(left) == 'T')
                {
                    edges.Add(new GraphEdge(GetId(i, coord), GetId(nextIndex, left)));
                }
                
                var right = new Coord(coord.X + 1, coord.Y);
                if (!nextGrid.IsOutOfRange(right) && nextGrid.ReadValueAt(right) == 'T')
                {
                    edges.Add(new GraphEdge(GetId(i, coord), GetId(nextIndex, right)));
                }
                
                if (canMoveUp)
                {
                    var up = new Coord(coord.X, coord.Y - 1);
                    if (!nextGrid.IsOutOfRange(up) && nextGrid.ReadValueAt(up) == 'T')
                    {
                        edges.Add(new GraphEdge(GetId(i, coord), GetId(nextIndex, up)));
                    }   
                }
                
                if (canMoveDown)
                {
                    var down = new Coord(coord.X, coord.Y + 1);
                    if (!nextGrid.IsOutOfRange(down) && nextGrid.ReadValueAt(down) == 'T')
                    {
                        edges.Add(new GraphEdge(GetId(i, coord), GetId(nextIndex, down)));
                    }
                }
            }
        }

        List<string> targets = [GetId(0, end1), GetId(1, end2), GetId(2, end3)]; 
        var cost = Dijkstra.BestCost(edges.ToList(), GetId(0, start), targets);
        
        return new PuzzleResult(cost, "20c605f31a1458e47d7cc3a1cc7d8971");
    }

    private string GetId(int gridIndex, Coord coord) => $"{gridIndex}-{coord.Id}";
    
    public Grid<char> Rotate(Grid<char> orig)
    {
        var rotated = new Grid<char>(orig.Width, orig.Height, '.');
        var current = orig.Coords.First(o => o.Y == orig.YMax && orig.ReadValueAt(o) != '.');
        var ny = 0;
        
        while (current.Y >= 0)
        {
            var nx = ny;
            orig.MoveTo(current);
            rotated.WriteValueAt(nx, ny, orig.ReadValue());
        
            while (nx < rotated.XMax && orig.ReadValueAt(new Coord(nx + 1, ny)) != '.')
            {
                orig.MoveUp();
                nx++;
                rotated.WriteValueAt(nx, ny, orig.ReadValue());
                orig.MoveLeft();
                nx++;
                rotated.WriteValueAt(nx, ny, orig.ReadValue());
            }

            ny++;
            current = new Coord(current.X + 1, current.Y - 1);
        }
        
        return rotated;
    }
}