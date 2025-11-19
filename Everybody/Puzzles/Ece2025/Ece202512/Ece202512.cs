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
        var origGrid = GridBuilder.BuildIntGridFromNonSeparated(input);
        var changingGrid = origGrid.Clone();
        
        (changingGrid, var best1) = FindBest(changingGrid);
        (changingGrid, var best2) = FindBest(changingGrid);
        var (_, best3) = FindBest(changingGrid);

        var result = Destroy(origGrid, best1);
        result.UnionWith(Destroy(origGrid, best2));
        result.UnionWith(Destroy(origGrid, best3));
        
        return new PuzzleResult(result.Count, "757124c4b4c1a7a826289c980216e1ed");
    }

    private static (Grid<int> grid, Coord coord) FindBest(Grid<int> grid)
    {
        var plausibleCoords = grid.Coords.Where(o => grid.ReadValueAt(o) > 2).ToList();
        var coordResults = new List<(Coord coord, HashSet<Coord> destroyed)>();
        foreach (var coord in plausibleCoords)
        {
            coordResults.Add((coord, Destroy(grid, coord, true)));
        }

        var mutableGrid = grid.Clone();
        var best1 = coordResults.MaxBy(o => o.destroyed.Count);
        foreach (var coord in best1.destroyed)
        {
            mutableGrid.WriteValueAt(coord, 0);
        }

        return (mutableGrid, best1.coord);
    }
    
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