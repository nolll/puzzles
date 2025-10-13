using System.Collections;
using System.Runtime.Serialization;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2024.Aoc202412;

[Name("Garden Groups")]
public class Aoc202412 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var totalPrice = 0;
        
        while (true)
        {
            var coord = grid.Coords.FirstOrDefault(o => grid.ReadValueAt(o) != '.');
            if (coord is null)
                break;

            var v = grid.ReadValueAt(coord);
            var queue = new Queue<Coord>();
            queue.Enqueue(coord);
            var set = new HashSet<Coord>();
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                if(!set.Add(c))
                    continue;

                var neighbors = grid.OrthogonalAdjacentCoordsTo(c).Where(o => grid.ReadValueAt(o) == v);
                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }

            var fenceCount = 0;
            var landCount = 0;
            foreach (var c in set)
            {
                var neighbors = grid.OrthogonalAdjacentCoordsTo(c).Where(o => grid.ReadValueAt(o) == v);
                fenceCount += 4 - neighbors.Count();
                landCount += 1;
            }

            foreach (var c in set)
            {
                grid.WriteValueAt(c, '.');
            }
            
            totalPrice += landCount * fenceCount;
        }
        
        return new PuzzleResult(totalPrice, "4aa3d13909317089109521b0f29d1226");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input, '.');
        var totalPrice = 0;
        
        while (true)
        {
            var coord = grid.Coords.FirstOrDefault(o => grid.ReadValueAt(o) != '.');
            if (coord is null)
                break;

            var v = grid.ReadValueAt(coord);
            var queue = new Queue<Coord>();
            queue.Enqueue(coord);
            var set = new HashSet<Coord>();
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                if(!set.Add(c))
                    continue;

                var neighbors = grid.OrthogonalAdjacentCoordsTo(c).Where(o => grid.ReadValueAt(o) == v);
                foreach (var neighbor in neighbors) 
                    queue.Enqueue(neighbor);
            }
            
            var plantGrid = new Grid<char>(grid.Width + 1, grid.Height + 1, '.');
            foreach (var c in set) 
                plantGrid.WriteValueAt(c, v);

            var width = plantGrid.Width;
            var height = plantGrid.Height;
            var fenceCount = 0;
            var lastRow = new int[width];
            for (var y = 0; y < height; y++)
            {
                var row = new int[width];
                for (var x = 0; x < width; x++) 
                    row[x] = plantGrid.ReadValueAt(x, y) == v ? 1 : 0;

                var diff = new int[width];
                for (var x = 0; x < width; x++) 
                    diff[x] = row[x] - lastRow[x];

                var f = 0;
                var lastDiff = 0;
                for (var x = 0; x < width; x++)
                {
                    if (diff[x] != lastDiff && diff[x] != 0) 
                        f++;

                    lastDiff = diff[x];
                }

                fenceCount += f;
                lastRow = row;
            }
            
            var lastCol = new int[height];
            for (var x = 0; x < width; x++)
            {
                var col = new int[height];
                for (var y = 0; y < height; y++) 
                    col[y] = plantGrid.ReadValueAt(x, y) == v ? 1 : 0;

                var diff = new int[height];
                for (var y = 0; y < height; y++) 
                    diff[y] = col[y] - lastCol[y];

                var f = 0;
                var lastDiff = 0;
                for (var y = 0; y < height; y++)
                {
                    if (diff[y] != lastDiff && diff[y] != 0) 
                        f++;
                    
                    lastDiff = diff[y];
                }

                fenceCount += f;
                lastCol = col;
            }
            
            foreach (var c in set) 
                grid.WriteValueAt(c, '.');
            
            var price = set.Count * fenceCount;
            totalPrice += price;
        }
        
        return new PuzzleResult(totalPrice, "95703fce5b68137cec2afe8da4553cf6");
    }
}