using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202512;

[Name("One Spark to Burn Them All")]
public class Ece202512 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var grid = GridBuilder.BuildIntGridFromNonSeparated(input);
        var seen = Destroy(grid, new Coord(grid.XMin, grid.YMin));
        
        return new PuzzleResult(seen.Count, "f81b4b34e7f317b195c2bfb97a67f3de");
    }

    public PuzzleResult Part2(string input)
    {
        var grid = GridBuilder.BuildIntGridFromNonSeparated(input);
        var seen = Destroy(grid, new Coord(grid.XMin, grid.YMin));
        seen.UnionWith(Destroy(grid, new Coord(grid.XMax, grid.YMax)));
        
        return new PuzzleResult(seen.Count, "12da343d20059e681858ba5ec807ec10");
    }

    public PuzzleResult Part3(string input)
    {
        var grid = GridBuilder.BuildIntGridFromNonSeparated(input);
        var allResults = FindAll(grid).ToList();
        var total = new HashSet<Coord>();
    
        foreach (var _ in Enumerable.Range(0, 3)) 
            total.UnionWith(allResults.MaxBy(o => o.Except(total).Count())!);
        
        return new PuzzleResult(total.Count, "757124c4b4c1a7a826289c980216e1ed");
    }

    private static IEnumerable<HashSet<Coord>> FindAll(Grid<int> grid) => 
        grid.Coords.Where(o => grid.ReadValueAt(o) > 2).ToList().Select(coord => Destroy(grid, coord, true));
    
    private static HashSet<Coord> Destroy(Grid<int> grid, Coord start, bool excludeZero = false)
    {
        var queue = new Queue<Coord>();
        queue.Enqueue(start);
        var seen = new HashSet<Coord>();
        
        while (queue.Count > 0)
        {
            var coord = queue.Dequeue();
            if (!seen.Add(coord))
                continue;

            var val = grid.ReadValueAt(coord);
            var adj = grid.OrthogonalAdjacentCoordsTo(coord);
            foreach (var adjCoord in adj)
            {
                if (seen.Contains(adjCoord))
                    continue;

                var adjVal = grid.ReadValueAt(adjCoord);
                var isValid = (excludeZero && adjVal > 0 || !excludeZero) && adjVal <= val; 
                if(isValid)
                    queue.Enqueue(adjCoord);
            }
        }

        return seen;
    }
}